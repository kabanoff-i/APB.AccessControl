using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using APB.AccessControl.ClientApp.Services;
using APB.AccessControl.ClientApp.Config;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Common;
using APB.AccessControl.Shared.Models.Requests;
using APB.AccessControl.Shared.Models.Responses;
using DevExpress.XtraLayout.Utils;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using APB.AccessControl.Shared.Models.Filters;

namespace APB.AccessControl.ClientApp
{
    public partial class MainForm : DevExpress.XtraBars.TabForm
    {
        private CardReaderService _cardReaderService;
        private ApiService _apiService;
        private NotificationService _notificationService;
        private HistoryService _historyService;

        public MainForm()
        {
            InitializeComponent();
            InitializeServices();
            InitializeReaderSettings();
            SubscribeToEvents();
        }

        private void InitializeServices()
        {
            // Инициализация сервисов
            var config = AppConfig.Load();
            _apiService = new ApiService();
            _cardReaderService = new CardReaderService();
            _notificationService = new NotificationService(alertControl, this);
            _historyService = new HistoryService(_apiService);
        }

        private void SubscribeToEvents()
        {
            // Подписка на события
            _cardReaderService.OnCardRead += CardReaderService_OnCardRead;
            _cardReaderService.OnReaderStatusChanged += CardReaderService_OnReaderStatusChanged;
            _notificationService.OnNotificationsChanged += NotificationService_OnNotificationsChanged;
            _historyService.OnHistoryChanged += HistoryService_OnHistoryChanged;

            // Настройка обработчиков событий
            buttonStartReader.Click += ButtonStartReader_Click;
            buttonStopReader.Click += ButtonStopReader_Click;
            comboBoxReaders.Properties.Items.AddRange(_cardReaderService.GetAvailableReaders().ToArray());
            comboBoxReaders.SelectedIndexChanged += ComboBoxReaders_SelectedIndexChanged;

            SetupTimers();

            // Инициализация отображения элементов управления
            TabFormControl1_SelectedPageChanged(this, EventArgs.Empty);
        }

        private void SetupTimers()
        {
            notificationTimer.Start();
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

                        foreach (var notification in response.Notifications)
                        {
                            _notificationService.ShowNotification(
                                "Уведомление для " + string.Join(' ', response.Employee.LastName, response.Employee.FirstName),
                                notification.Message
                            );
                        }

                        //var accessLog = new CreateAccessLogReq
                        //{
                        //    CardHash = e.CardHash,
                        //    AccessPointId = config.AccessPointId,
                        //    DateAccess = DateTime.Now,
                        //    AccessResult = response.IsSuccess ? 1 : 0,
                        //    Message = response.Message
                        //};

                        //var logResult = await _apiService.LogAccessAsync(accessLog);
                        //if (!logResult.IsSuccess)
                        //{
                        //    _notificationService.ShowNotification("Ошибка при записи лога", logResult.Error?.Message ?? "Неизвестная ошибка");
                        //}

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

                        //var accessLog = new CreateAccessLogReq
                        //{
                        //    CardHash = e.CardHash,
                        //    AccessPointId = config.AccessPointId,
                        //    DateAccess = DateTime.Now,
                        //    AccessResult = 0,
                        //    Message = "Сотрудник не найден"
                        //};

                        //var logResult = await _apiService.LogAccessAsync(accessLog);
                        //if (!logResult.IsSuccess)
                        //{
                        //    _notificationService.ShowNotification("Ошибка при записи лога", logResult.Error?.Message ?? "Неизвестная ошибка");
                        //}
                    }
                }
                else
                {
                    labelEmployeeName.Text = "Ошибка проверки доступа";
                    labelDepartment.Text = string.Empty;
                    labelAccessStatus.Text = "Ошибка";
                    labelAccessStatus.Appearance.ForeColor = Color.Red;
                    pictureEditEmployee.Image = null;
                    
                    XtraMessageBox.Show(apiResult.Error?.Message ?? "Неизвестная ошибка", "Ошибка при проверке доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                labelEmployeeName.Text = "Ошибка";
                labelDepartment.Text = string.Empty;
                labelAccessStatus.Text = "Ошибка";
                labelAccessStatus.Appearance.ForeColor = Color.Red;
                pictureEditEmployee.Image = null;
                
                XtraMessageBox.Show(ex.Message, "Ошибка при проверке доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardReaderService_OnReaderStatusChanged(object sender, ReaderStatusEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => CardReaderService_OnReaderStatusChanged(sender, e)));
                return;
            }

            labelReaderStatus.Text = $"Статус считывателя: {e.Status}";
            buttonStartReader.Enabled = !e.IsRunning;
            buttonStopReader.Enabled = e.IsRunning;
        }

        private void ButtonStartReader_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedReader = comboBoxReaders.Text;
                if (string.IsNullOrEmpty(selectedReader))
                {
                    XtraMessageBox.Show(
                        "Выберите считыватель из списка",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                _cardReaderService.StartReader(selectedReader);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Ошибка при запуске считывателя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonStopReader_Click(object sender, EventArgs e)
        {
            try
            {
                _cardReaderService.StopReader();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Ошибка при остановке считывателя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonStartReader.Enabled = !string.IsNullOrEmpty(comboBoxReaders.Text);
        }

        private void NotificationService_OnNotificationsChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => NotificationService_OnNotificationsChanged(sender, e)));
                return;
            }

            var notifications = _notificationService.GetNotifications();
            gridControlNotifications.DataSource = notifications;
            gridViewNotifications.BestFitColumns();
        }

        private void HistoryService_OnHistoryChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HistoryService_OnHistoryChanged(sender, e)));
                return;
            }

            var history = _historyService.GetHistory();
            gridControlHistory.DataSource = history;
            gridViewHistory.BestFitColumns();
        }

        private void TabFormControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            // Скрываем все контейнеры
            tabFormContentContainer1.Visible = false;
            tabFormContentContainer2.Visible = false;
            tabFormContentContainer3.Visible = false;
            tabFormContentContainer4.Visible = false;
            tabFormContentContainer5.Visible = false;

            // Показываем нужный контейнер
            if (tabFormControl1.SelectedPage == tabFormPagePass)
            {
                tabFormContentContainer1.Visible = true;
            }
            else if (tabFormControl1.SelectedPage == tabFormPageReaderSettings)
            {
                tabFormContentContainer2.Visible = true;
            }
            else if (tabFormControl1.SelectedPage == tabFormPageHistory)
            {
                tabFormContentContainer3.Visible = true;
            }
            else if (tabFormControl1.SelectedPage == tabFormPageNotifications)
            {
                tabFormContentContainer4.Visible = true;
            }
            else if (tabFormControl1.SelectedPage == tabFormPagePendingLogs)
            {
                tabFormContentContainer5.Visible = true;
            }
        }

        private void ButtonStopReaderSettings_Click(object sender, EventArgs e)
        {
            try
            {
                _cardReaderService.StopPolling();
                buttonStartReaderSettings.Enabled = true;
                buttonStopReaderSettings.Enabled = false;
                labelReaderStatusSettings.Text = "Статус считывателя: Остановлен";
                _notificationService.ShowNotification("Считыватель остановлен", "Считывание карт остановлено");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Не удалось остановить считыватель: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonStartReaderSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxReadersSettings.SelectedItem == null)
                {
                    _notificationService.ShowNotification("Ошибка", "Выберите считыватель");
                    return;
                }

                _cardReaderService.StartPolling(comboBoxReadersSettings.SelectedItem.ToString());
                buttonStartReaderSettings.Enabled = false;
                buttonStopReaderSettings.Enabled = true;
                labelReaderStatusSettings.Text = "Статус считывателя: Работает";
                _notificationService.ShowNotification("Считыватель запущен", "Считывание карт начато");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Не удалось запустить считыватель: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxReadersSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonStartReaderSettings.Enabled = comboBoxReadersSettings.SelectedItem != null;
        }

        private void InitializeReaderSettings()
        {
            try
            {
                var readers = _cardReaderService.GetAvailableReaders();
                comboBoxReadersSettings.Properties.Items.Clear();
                comboBoxReadersSettings.Properties.Items.AddRange(readers.ToArray());
                
                if (readers.Any())
                {
                    comboBoxReadersSettings.SelectedIndex = 0;
                }

                buttonStartReaderSettings.Enabled = comboBoxReadersSettings.SelectedItem != null;
                buttonStopReaderSettings.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Не удалось инициализировать настройки считывателя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cardReaderService.StopReader();
            base.OnFormClosing(e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Инициализация дат
            dateEditFrom.EditValue = DateTime.Today.AddDays(-6);
            dateEditTo.EditValue = DateTime.Today.AddDays(1);
            
            LoadAccessLogs();
        }

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            await LoadAccessLogs();
        }

        private async Task LoadAccessLogs()
        {
            try
            {
                var filter = new AccessLogFilterDto
                {
                    AccessTimeStart = dateEditFrom.DateTime.ToUniversalTime(),
                    AccessTimeEnd = dateEditTo.DateTime.ToUniversalTime(),
                    AccessPointId = AppConfig.Load().AccessPointId
                };

                var result = await _apiService.GetAccessLogsAsync(filter);
                if (result.IsSuccess)
                {
                    gridControlHistory.DataSource = result.Data;
                    gridViewHistory.BestFitColumns();

                    if (!result.Data?.Any() ?? true)
                    {
                        XtraMessageBox.Show("Нет доступных логов за выбранный период", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show(result.Error?.Message ?? "Неизвестная ошибка", "Ошибка при загрузке логов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Ошибка при загрузке логов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
