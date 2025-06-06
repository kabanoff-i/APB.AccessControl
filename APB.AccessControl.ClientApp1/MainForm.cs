using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APB.AccessControl.ClientApp.Services;
using APB.AccessControl.ClientApp.Resources;
using APB.AccessControl.ClientApp.Config;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Common;
using System.IO;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;

namespace APB.AccessControl.ClientApp
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly CardReaderService _cardReaderService;
        private readonly ApiService _apiService;
        private readonly NotificationService _notificationService;
        private readonly HistoryService _historyService;
        private readonly HeartbeatService _heartbeatService;
        private readonly QueueService _queueService;
        private bool _isServerAvailable = true;

        public MainForm()
        {
            InitializeComponent();
            
            // Инициализация сервисов
            var config = AppConfig.Load();
            _apiService = new ApiService();
            _cardReaderService = new CardReaderService();
            _notificationService = new NotificationService(alertControl, this);
            _historyService = new HistoryService(_apiService);
            _heartbeatService = new HeartbeatService(_apiService, _notificationService);
            _queueService = new QueueService(config.RedisConnectionString);

            // Подписка на события
            _cardReaderService.OnCardRead += CardReaderService_OnCardRead;
            _cardReaderService.OnReaderStatusChanged += CardReaderService_OnReaderStatusChanged;
            _notificationService.OnNotificationsChanged += NotificationService_OnNotificationsChanged;
            _historyService.OnHistoryChanged += HistoryService_OnHistoryChanged;
            _heartbeatService.OnNotificationReceived += HeartbeatService_OnNotificationReceived;

            // Настройка обработчиков событий
            buttonStartReader.Click += ButtonStartReader_Click;
            buttonStopReader.Click += ButtonStopReader_Click;
            comboBoxReaders.Properties.Items.AddRange(_cardReaderService.GetAvailableReaders().ToArray());
            comboBoxReaders.SelectedIndexChanged += ComboBoxReaders_SelectedIndexChanged;

            SetupTimers();
            _heartbeatService.Start();
            StartQueueProcessing();
        }

        private void SetupTimers()
        {
            notificationTimer.Start();
        }

        private void StartQueueProcessing()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    if (_isServerAvailable)
                    {
                        var queuedLog = await _queueService.DequeueAccessCheckAsync();
                        if (queuedLog != null)
                        {
                            try
                            {
                                // Отправляем лог на сервер
                                var result = await _apiService.LogAccessAsync(queuedLog);
                                if (!result.IsSuccess)
                                {
                                    // Если не удалось отправить лог, возвращаем его в очередь
                                    await _queueService.EnqueueAccessCheckAsync(queuedLog);
                                    _isServerAvailable = false;
                                }
                            }
                            catch
                            {
                                // Если сервер снова недоступен, возвращаем лог в очередь
                                await _queueService.EnqueueAccessCheckAsync(queuedLog);
                                _isServerAvailable = false;
                            }
                        }
                    }
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPageIndex != 0)
            {
                xtraTabControl.SelectedTabPageIndex = 0;
            }
        }

        private async void CardReaderService_OnCardRead(object sender, CardReadEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => CardReaderService_OnCardRead(sender, e)));
                return;
            }

            labelCurrentCard.Text = $"Текущая карта: {e.MaskPan}";
            
            try
            {
                var config = AppConfig.Load();
                
                if (!_isServerAvailable)
                {
                    // Показываем сообщение о ручном режиме
                    labelEmployeeName.Text = "Ручной режим";
                    labelDepartment.Text = string.Empty;
                    labelAccessStatus.Text = "Требуется решение";
                    labelAccessStatus.Appearance.ForeColor = Color.Orange;
                    pictureEditEmployee.Image = null;

                    XtraMessageBox.Show(
                        "Сервер недоступен. Требуется ручное решение.",
                        "Ручной режим",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    // Показываем диалог для ручного решения
                    var result = XtraMessageBox.Show(
                        "Сервер недоступен. Разрешить доступ?",
                        "Ручной режим",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    var isAccessGranted = result == DialogResult.Yes;
                    
                    // Создаем лог прохода
                    var accessLog = new CreateAccessLogReq
                    {
                        CardHash = e.CardHash,
                        AccessPointId = config.AccessPointId,
                        DateAccess = DateTime.Now,
                        AccessResult = isAccessGranted ? 1 : 0,
                        Message = "Ручной режим"
                    };

                    // Сохраняем лог в очередь
                    await _queueService.EnqueueAccessCheckAsync(accessLog);

                    if (isAccessGranted)
                    {
                        labelAccessStatus.Text = "Доступ разрешен (ручной режим)";
                        labelAccessStatus.Appearance.ForeColor = Color.Green;
                    }
                    else
                    {
                        labelAccessStatus.Text = "Доступ запрещен (ручной режим)";
                        labelAccessStatus.Appearance.ForeColor = Color.Red;
                    }

                    return;
                }

                var apiResult = await _apiService.CheckAccessAsync(e.CardHash, config.AccessPointId);
                
                if (apiResult.IsSuccess)
                {
                    var response = apiResult.Data;
                    if (response.Employee != null)
                    {
                        var fullName = string.Join(" ", response.Employee.LastName, response.Employee.FirstName, response.Employee.PatronymicName);
                        labelEmployeeName.Text = fullName;
                        labelDepartment.Text = response.Employee.Department;
                        labelAccessStatus.Text = response.IsSuccess ? "Доступ разрешен" : "Доступ запрещен";
                        labelAccessStatus.Appearance.ForeColor = response.IsSuccess ? Color.Green : Color.Red;
                        
                        if (!string.IsNullOrEmpty(response.Employee.Photo))
                        {
                            try
                            {
                                var photoBytes = Convert.FromBase64String(response.Employee.Photo);
                                using (var ms = new MemoryStream(photoBytes))
                                {
                                    pictureEditEmployee.Image = Image.FromStream(ms);
                                }
                            }
                            catch
                            {
                                pictureEditEmployee.Image = null;
                            }
                        }
                        else
                        {
                            pictureEditEmployee.Image = null;
                        }

                        // Создаем лог прохода
                        var accessLog = new CreateAccessLogReq
                        {
                            CardHash = e.CardHash,
                            AccessPointId = config.AccessPointId,
                            DateAccess = DateTime.Now,
                            AccessResult = response.IsSuccess ? 1 : 0,
                            Message = response.Message
                        };

                        // Сохраняем лог в очередь
                        await _queueService.EnqueueAccessCheckAsync(accessLog);

                        // Показываем сообщение о результате проверки доступа
                        XtraMessageBox.Show(
                            response.Message,
                            response.IsSuccess ? "Доступ разрешен" : "Доступ запрещен",
                            MessageBoxButtons.OK,
                            response.IsSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        labelEmployeeName.Text = "Сотрудник не найден";
                        labelDepartment.Text = string.Empty;
                        labelAccessStatus.Text = "Доступ запрещен";
                        labelAccessStatus.Appearance.ForeColor = Color.Red;
                        pictureEditEmployee.Image = null;

                        // Создаем лог прохода
                        var accessLog = new CreateAccessLogReq
                        {
                            CardHash = e.CardHash,
                            AccessPointId = config.AccessPointId,
                            DateAccess = DateTime.Now,
                            AccessResult = 0,
                            Message = "Сотрудник не найден"
                        };

                        // Сохраняем лог в очередь
                        await _queueService.EnqueueAccessCheckAsync(accessLog);

                        XtraMessageBox.Show(
                            "Сотрудник не найден",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    labelEmployeeName.Text = "Ошибка проверки";
                    labelDepartment.Text = string.Empty;
                    labelAccessStatus.Text = "Ошибка";
                    labelAccessStatus.Appearance.ForeColor = Color.Red;
                    pictureEditEmployee.Image = null;

                    // Создаем лог прохода
                    var accessLog = new CreateAccessLogReq
                    {
                        CardHash = e.CardHash,
                        AccessPointId = config.AccessPointId,
                        DateAccess = DateTime.Now,
                        AccessResult = 0,
                        Message = apiResult.Error?.Message ?? "Неизвестная ошибка"
                    };

                    // Сохраняем лог в очередь
                    await _queueService.EnqueueAccessCheckAsync(accessLog);

                    XtraMessageBox.Show(
                        apiResult.Error?.Message ?? "Неизвестная ошибка",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                _isServerAvailable = false;
                labelEmployeeName.Text = "Ошибка";
                labelDepartment.Text = string.Empty;
                labelAccessStatus.Text = "Ошибка";
                labelAccessStatus.Appearance.ForeColor = Color.Red;
                pictureEditEmployee.Image = null;

                var config = AppConfig.Load();

                // Создаем лог прохода
                var accessLog = new CreateAccessLogReq
                {
                    CardHash = e.CardHash,
                    AccessPointId = config.AccessPointId,
                    DateAccess = DateTime.Now,
                    AccessResult = 0,
                    Message = $"Ошибка при проверке доступа: {ex.Message}"
                };

                // Сохраняем лог в очередь
                await _queueService.EnqueueAccessCheckAsync(accessLog);

                XtraMessageBox.Show(
                    $"Ошибка при проверке доступа: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CardReaderService_OnReaderStatusChanged(object sender, ReaderStatusEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => CardReaderService_OnReaderStatusChanged(sender, e)));
                return;
            }

            labelReaderStatus.Text = $"Статус: {e.Status}";
            buttonStartReader.Enabled = !e.IsRunning;
            buttonStopReader.Enabled = e.IsRunning;
        }

        private void ButtonStartReader_Click(object sender, EventArgs e)
        {
            if (comboBoxReaders.SelectedItem != null)
            {
                _cardReaderService.StartReader(comboBoxReaders.SelectedItem.ToString());
            }
            else
            {
                XtraMessageBox.Show(
                    "Выберите считыватель",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ButtonStopReader_Click(object sender, EventArgs e)
        {
            _cardReaderService.StopReader();
        }

        private void ComboBoxReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonStartReader.Enabled = comboBoxReaders.SelectedItem != null;
        }

        private void NotificationService_OnNotificationsChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => NotificationService_OnNotificationsChanged(sender, e)));
                return;
            }

            // Обновляем грид уведомлений
            gridNotifications.DataSource = _notificationService.GetNotifications();
        }

        private void HistoryService_OnHistoryChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HistoryService_OnHistoryChanged(sender, e)));
                return;
            }

            // Обновляем грид истории
            gridHistory.DataSource = _historyService.GetHistory();
        }

        private void HeartbeatService_OnNotificationReceived(object sender, NotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HeartbeatService_OnNotificationReceived(sender, e)));
                return;
            }

            // Показываем уведомление
            _notificationService.ShowNotification(
                e.Notification.AccessPointName,
                e.Notification.Message,
                async (notification) =>
                {
                    // При клике на уведомление помечаем его как прочитанное
                    try
                    {
                        var result = await _apiService.ProcessNotificationAsync(notification.Id);
                        if (!result.IsSuccess)
                        {
                            XtraMessageBox.Show(
                                result.Error?.Message ?? "Неизвестная ошибка",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(
                            $"Ошибка при обработке уведомления: {ex.Message}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            );
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            notificationTimer.Stop();
            _cardReaderService.StopReader();
            _heartbeatService.Stop();
            base.OnFormClosing(e);
        }
    }
}