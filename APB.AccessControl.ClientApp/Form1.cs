using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using APB.AccessControl.ClientApp.Services;
using APB.AccessControl.Shared.Models.Responses;
using APB.AccessControl.Shared.Models.Common;

namespace APB.AccessControl.ClientApp
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private readonly CardReaderService _cardReaderService;
        private readonly AccessControlApiService _apiService;
        
        private ComboBox cmbReaders;
        private ComboBox cmbAccessPoints;
        private Button btnConnect;
        private TextBox txtCardInfo;
        private TextBox txtAccessResult;
        private Label lblStatus;
        private int _selectedAccessPointId = 1; // значение по умолчанию

        public Form1()
        {
            InitializeComponent();
            
            // Инициализируем сервисы
            _cardReaderService = new CardReaderService();
            _apiService = new AccessControlApiService();
            
            // Добавляем обработчики событий
            _cardReaderService.CardRead += CardReaderService_CardRead;
            _cardReaderService.ReaderStatusChanged += CardReaderService_ReaderStatusChanged;
            
            InitializeCustomComponents();
            LoadReaders();
            InitializeAccessPoints();
        }

        private void InitializeCustomComponents()
        {
            // ComboBox для выбора считывателя
            cmbReaders = new ComboBox();
            cmbReaders.Name = "cmbReaders";
            cmbReaders.Location = new Point(20, 20);
            cmbReaders.Width = 300;
            cmbReaders.DropDownStyle = ComboBoxStyle.DropDownList;

            // ComboBox для выбора точки доступа
            cmbAccessPoints = new ComboBox();
            cmbAccessPoints.Name = "cmbAccessPoints";
            cmbAccessPoints.Location = new Point(20, 50);
            cmbAccessPoints.Width = 300;
            cmbAccessPoints.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccessPoints.SelectedIndexChanged += CmbAccessPoints_SelectedIndexChanged;

            // Кнопка для подключения к считывателю
            btnConnect = new Button();
            btnConnect.Name = "btnConnect";
            btnConnect.Text = "Подключиться";
            btnConnect.Location = new Point(330, 20);
            btnConnect.Width = 150;
            btnConnect.Click += BtnConnect_Click;

            // Текстовое поле для информации о карте
            txtCardInfo = new TextBox();
            txtCardInfo.Name = "txtCardInfo";
            txtCardInfo.Location = new Point(20, 90);
            txtCardInfo.Width = 460;
            txtCardInfo.Height = 80;
            txtCardInfo.Multiline = true;
            txtCardInfo.ReadOnly = true;
            txtCardInfo.Text = "Ожидание карты ";

            // Текстовое поле для результата проверки доступа
            txtAccessResult = new TextBox();
            txtAccessResult.Name = "txtAccessResult";
            txtAccessResult.Location = new Point(20, 180);
            txtAccessResult.Width = 460;
            txtAccessResult.Height = 200;
            txtAccessResult.Multiline = true;
            txtAccessResult.ReadOnly = true;
            txtAccessResult.ScrollBars = ScrollBars.Vertical;

            // Метка статуса
            lblStatus = new Label();
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Ожидание выбора считывателя...";
            lblStatus.Location = new Point(20, 390);
            lblStatus.Width = 460;
            lblStatus.ForeColor = Color.Red;

            // Добавляем элементы на форму
            fluentDesignFormContainer1.Controls.Add(cmbReaders);
            fluentDesignFormContainer1.Controls.Add(cmbAccessPoints);
            fluentDesignFormContainer1.Controls.Add(btnConnect);
            fluentDesignFormContainer1.Controls.Add(txtCardInfo);
            fluentDesignFormContainer1.Controls.Add(txtAccessResult);
            fluentDesignFormContainer1.Controls.Add(lblStatus);
        }

        private void InitializeAccessPoints()
        {
            // Временно заполняем список точек доступа тестовыми данными
            // В реальном приложении эти данные должны загружаться с сервера
            cmbAccessPoints.Items.Clear();
            cmbAccessPoints.Items.Add(new AccessPointItem { Id = 1, Name = "Главный вход" });
            cmbAccessPoints.Items.Add(new AccessPointItem { Id = 2, Name = "Серверная" });
            cmbAccessPoints.Items.Add(new AccessPointItem { Id = 3, Name = "Офис" });
            cmbAccessPoints.Items.Add(new AccessPointItem { Id = 4, Name = "Лаборатория" });
            
            cmbAccessPoints.DisplayMember = "Name";
            cmbAccessPoints.ValueMember = "Id";
            cmbAccessPoints.SelectedIndex = 0;
        }

        private void CmbAccessPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccessPoints.SelectedItem is AccessPointItem selectedItem)
            {
                _selectedAccessPointId = selectedItem.Id;
                UpdateStatus($"Выбрана точка доступа: {selectedItem.Name}", Color.Blue);
            }
        }

        // Класс для хранения информации о точке доступа
        private class AccessPointItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            
            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadReaders()
        {
            try
            {
                string[] readers = _cardReaderService.GetAvailableReaders();
                if (readers.Length > 0)
                {
                    cmbReaders.Items.Clear();
                    foreach (string reader in readers)
                    {
                        cmbReaders.Items.Add(reader);
                    }
                    cmbReaders.SelectedIndex = 0;
                    
                    UpdateStatus($"Выберите считыватель и нажмите 'Подключиться'", Color.Blue);
                }
                else
                {
                    UpdateStatus("Не найдены доступные считыватели", Color.Red);
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Ошибка загрузки считывателей: {ex.Message}", Color.Red);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (cmbReaders.SelectedItem == null)
            {
                UpdateStatus("Выберите считыватель", Color.Red);
                return;
            }

            string selectedReader = cmbReaders.SelectedItem.ToString();
            
            // Начинаем опрос считывателя независимо от того, есть ли карта в данный момент
            _cardReaderService.StartPolling(selectedReader);
            btnConnect.Enabled = false;
            cmbReaders.Enabled = false;
            UpdateStatus($"Запущен постоянный опрос считывателя: {selectedReader}", Color.Green);
            txtCardInfo.Text = "Поднесите карту к считывателю...";
        }

        private async void CardReaderService_CardRead(object sender, CardReadEventArgs e)
        {
            try
            {
                // Этот метод может быть вызван из другого потока, поэтому используем Invoke
                if (InvokeRequired)
                {
                    Invoke(new Action(() => CardReaderService_CardRead(sender, e)));
                    return;
                }

                // Обновляем информацию о карте
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Карта обнаружена!");
                sb.AppendLine($"Хеш карты: {e.CardHash}");
                
                if (e.HasEmvData && e.CardData != null)
                {
                    sb.AppendLine($"EMV данные: Да");
                    if (!string.IsNullOrEmpty(e.CardData.CardHolder))
                        sb.AppendLine($"Держатель: {e.CardData.CardHolder}");
                    if (!string.IsNullOrEmpty(e.CardData.Pan))
                        sb.AppendLine($"PAN: {e.CardData.Pan.Substring(0, 4)}****{e.CardData.Pan.Substring(e.CardData.Pan.Length - 4)}");
                }
                else
                {
                    sb.AppendLine($"EMV данные: Нет");
                }
                
                txtCardInfo.Text = sb.ToString();
                UpdateStatus("Проверка доступа...", Color.Blue);

                // Сразу отправляем запрос на проверку доступа
                var response = await _apiService.CheckAccessAsync(e.CardHash, _selectedAccessPointId);
                
                // Отображаем результат
                DisplayAccessResult(response);
                
                // Показываем диалоговое окно с результатами
                ShowAccessResultDialog(response);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Ошибка обработки данных карты: {ex.Message}", Color.Red);
            }
        }

        private void CardReaderService_ReaderStatusChanged(object sender, ReaderStatusEventArgs e)
        {
            // Этот метод может быть вызван из другого потока, поэтому используем Invoke
            if (InvokeRequired)
            {
                Invoke(new Action(() => CardReaderService_ReaderStatusChanged(sender, e)));
                return;
            }

            // Обновляем статус и информацию в интерфейсе
            UpdateStatus(e.Message, e.IsConnected ? Color.Green : Color.Red);
            
            // Если произошла ошибка с картой, очищаем поле информации о карте
            if (!e.IsConnected && e.Message.Contains("Не удалось получить DataHash карты"))
            {
                txtCardInfo.Text = "Ожидание корректной карты с EMV данными...";
                txtAccessResult.Text = string.Empty;
            }
        }

        private void DisplayAccessResult(Result<AccessCheckResponse> response)
        {
            StringBuilder sb = new StringBuilder();
            
            // Выделяем результат проверки доступа
            string accessStatus = response.Data.IsSuccess ? "ДОСТУП РАЗРЕШЕН" : "ДОСТУП ЗАПРЕЩЕН";
            sb.AppendLine($"Результат: {accessStatus}");
            sb.AppendLine($"Сообщение: {response.Data.Message}");

            if (response.Data != null && response.Data.IsSuccess)
            {
                sb.AppendLine();
                sb.AppendLine("Информация о сотруднике:");
                sb.AppendLine($"ID: {response.Data?.Employee?.Id}");
                sb.AppendLine($"Имя: {response.Data?.Employee?.FirstName}");
                sb.AppendLine($"Фамилия: {response.Data?.Employee?.LastName}");
                if (!string.IsNullOrEmpty(response.Data?.Employee?.PassportNumber))
                    sb.AppendLine($"Номер паспорта: {response.Data?.Employee?.PassportNumber}");
                if (!string.IsNullOrEmpty(response.Data?.Employee?.Position))
                    sb.AppendLine($"Должность: {response.Data?.Employee?.Position}");
            }

            txtAccessResult.Text = sb.ToString();
            
            // Устанавливаем статус с более заметным визуальным оформлением
            UpdateStatus(
                response.Data.IsSuccess ? "✅ ДОСТУП РАЗРЕШЕН" : "❌ ДОСТУП ЗАПРЕЩЕН", 
                response.Data.IsSuccess ? Color.Green : Color.Red
            );
        }

        private void ShowAccessResultDialog(Result<AccessCheckResponse> response)
        {
            // Проигрываем звуковой сигнал в зависимости от результата
            if (response.Data.IsSuccess)
            {
                System.Media.SystemSounds.Asterisk.Play(); // позитивный звук для разрешения доступа
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play(); // предупреждающий звук для запрета доступа
            }

            // Создаем форму для отображения результатов
            using (Form resultDialog = new Form())
            {
                // Настраиваем внешний вид формы
                resultDialog.Text = response.Data.IsSuccess ? "Доступ разрешен" : "Доступ запрещен";
                resultDialog.Width = 450;
                resultDialog.Height = 350;
                resultDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                resultDialog.StartPosition = FormStartPosition.CenterParent;
                resultDialog.MaximizeBox = false;
                resultDialog.MinimizeBox = false;
                
                // Устанавливаем цвет фона в зависимости от результата
                resultDialog.BackColor = response.Data.IsSuccess 
                    ? Color.FromArgb(230, 255, 230) // светло-зеленый
                    : Color.FromArgb(255, 230, 230); // светло-красный
                
                // Добавляем иконку результата
                PictureBox resultIcon = new PictureBox();
                resultIcon.SizeMode = PictureBoxSizeMode.Zoom;
                resultIcon.Width = 64;
                resultIcon.Height = 64;
                resultIcon.Location = new Point(20, 20);
                resultIcon.Image = response.Data.IsSuccess 
                    ? System.Drawing.SystemIcons.Information.ToBitmap() 
                    : System.Drawing.SystemIcons.Error.ToBitmap();

                // Настраиваем метку с сообщением
                Label lblMessage = new Label();
                lblMessage.Text = response.Data.IsSuccess ? "ДОСТУП РАЗРЕШЕН" : "ДОСТУП ЗАПРЕЩЕН";
                lblMessage.Font = new Font(lblMessage.Font.FontFamily, 16, FontStyle.Bold);
                lblMessage.ForeColor = response.Data.IsSuccess ? Color.Green : Color.Red;
                lblMessage.Location = new Point(100, 30);
                lblMessage.Width = 250;
                lblMessage.Height = 30;

                // Добавляем метку времени
                Label lblTime = new Label();
                lblTime.Text = $"Время: {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}";
                lblTime.Location = new Point(100, 60);
                lblTime.Width = 250;
                lblTime.Height = 20;

                // Добавляем детальную информацию
                TextBox txtDetails = new TextBox();
                txtDetails.Multiline = true;
                txtDetails.ReadOnly = true;
                txtDetails.ScrollBars = ScrollBars.Vertical;
                txtDetails.Location = new Point(20, 100);
                txtDetails.Width = 395;
                txtDetails.Height = 150;
                txtDetails.BackColor = Color.White;
                
                StringBuilder detailsText = new StringBuilder();
                detailsText.AppendLine($"Сообщение: {response.Error.Message ?? "OK"}");
                detailsText.AppendLine($"Точка доступа: {cmbAccessPoints.Text}");
                
                if (response.Data != null && response.Data.IsSuccess)
                {
                    detailsText.AppendLine();
                    detailsText.AppendLine("Информация о сотруднике:");
                    detailsText.AppendLine($"ID: {response.Data.Employee.Id}");
                    detailsText.AppendLine($"ФИО: {response.Data.Employee.LastName} {response.Data.Employee.FirstName}");
                    
                    if (!string.IsNullOrEmpty(response.Data.Employee.Position))
                        detailsText.AppendLine($"Должность: {response.Data.Employee.Position}");
                        
                    if (!string.IsNullOrEmpty(response.Data.Employee.PassportNumber))
                        detailsText.AppendLine($"Номер паспорта: {response.Data.Employee.PassportNumber}");
                }
                
                txtDetails.Text = detailsText.ToString();

                // Кнопка ОК для закрытия диалога
                Button btnOk = new Button();
                btnOk.Text = "OK";
                btnOk.DialogResult = DialogResult.OK;
                btnOk.Location = new Point(175, 265);
                btnOk.Width = 100;
                btnOk.Height = 30;
                btnOk.BackColor = Color.White;

                // Добавляем элементы управления на форму
                resultDialog.Controls.Add(resultIcon);
                resultDialog.Controls.Add(lblMessage);
                resultDialog.Controls.Add(lblTime);
                resultDialog.Controls.Add(txtDetails);
                resultDialog.Controls.Add(btnOk);

                // Устанавливаем кнопку по умолчанию и обработчик на закрытие формы
                resultDialog.AcceptButton = btnOk;
                resultDialog.FormClosed += (s, args) => 
                {
                    // Сбрасываем все до начального состояния после закрытия диалога
                    ResetToInitialState();
                };

                // Показываем диалог
                resultDialog.ShowDialog(this);
            }
        }

        private void ResetToInitialState()
        {
            // Очищаем информацию о карте и результате
            txtCardInfo.Text = "Ожидание карты с EMV данными. Будет использоваться только DataHash.";
            txtAccessResult.Text = string.Empty;
            
            // Сбрасываем статус
            UpdateStatus("Готов к сканированию следующей карты", Color.Blue);
            
            // Сброс сервиса чтения карт не требуется,
            // так как сам сервис управляет состоянием через _cardWasRead
        }

        private void UpdateStatus(string message, Color color)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = color;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _cardReaderService.StopPolling();
        }
    }
}
