using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading.Tasks;
using System.Linq;
using DevExpress.Utils;
using APB.SV.CardData;

namespace APB.AccessControl.ManageApp.Forms
{
    /// <summary>
    /// Класс аргументов события чтения карты
    /// </summary>
    public class CardReadEventArgs : EventArgs
    {
        public string CardHash { get; set; }
        public string Pan { get; set; }
        public string MaskPan { get; set; }
        public string CardHolder { get; set; }
        public bool HasEmvData { get; set; }
    }

    /// <summary>
    /// Форма для считывания карты
    /// </summary>
    public partial class CardReaderForm : XtraForm
    {
        private bool _isPolling;
        private Timer _pollingTimer;
        private string _selectedReader;
        private bool _cardWasRead = false;
        private Dictionary<string, string> _lastCardData = new Dictionary<string, string>();
        private readonly int _pollingInterval = 1000; // интервал опроса считывателя в мс

        public string CardHash { get; private set; }
        public string PAN { get; private set; }
        public string CardHolder { get; private set; }

        public bool CardLinked { get; private set; }
        
        /// <summary>
        /// Результат чтения карты, доступный после закрытия формы с DialogResult.OK
        /// </summary>
        public CardReadEventArgs CardReadEventArgs { get; private set; }
        
        public CardReaderForm()
        {
            InitializeComponent();
            InitializeUI();
            InitializeReaders();
        }

        /// <summary>
        /// Инициализация пользовательского интерфейса
        /// </summary>
        private void InitializeUI()
        {
            // Настраиваем свойства формы
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            // Настраиваем кнопки
            this.btnStartReading.Click += BtnStartReading_Click;
            this.btnStopPolling.Click += BtnStopPolling_Click;
            this.btnRefreshReaders.Click += BtnRefreshReaders_Click;
            this.btnClear.Click += BtnClear_Click;
            this.btnLinkCard.Click += BtnLinkCard_Click;
            this.btnClose.Click += BtnClose_Click;
            
            // Визуальные улучшения
            this.panelCardReader.Appearance.BorderColor = Color.FromArgb(230, 230, 230);
            this.panelReaders.Appearance.BorderColor = Color.FromArgb(230, 230, 230);
            this.panelCardInfo.Appearance.BorderColor = Color.FromArgb(230, 230, 230);
            
            this.lblTitle.Font = new Font(lblTitle.Font.FontFamily, 12, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 114, 198);
            
            this.btnStartReading.Appearance.BackColor = Color.FromArgb(0, 150, 36);
            this.btnStartReading.Appearance.ForeColor = Color.White;
            this.btnStartReading.Appearance.Options.UseBackColor = true;
            this.btnStartReading.Appearance.Options.UseForeColor = true;
            this.btnStartReading.Appearance.Font = new Font(btnStartReading.Appearance.Font.FontFamily, 10);
            
            this.btnStopPolling.Appearance.BackColor = Color.FromArgb(200, 0, 0);
            this.btnStopPolling.Appearance.ForeColor = Color.White;
            this.btnStopPolling.Appearance.Options.UseBackColor = true;
            this.btnStopPolling.Appearance.Options.UseForeColor = true;
            this.btnStopPolling.Appearance.Font = new Font(btnStopPolling.Appearance.Font.FontFamily, 10);
            
            this.btnLinkCard.Appearance.BackColor = Color.FromArgb(0, 114, 198);
            this.btnLinkCard.Appearance.ForeColor = Color.White;
            this.btnLinkCard.Appearance.Options.UseBackColor = true;
            this.btnLinkCard.Appearance.Options.UseForeColor = true;
            this.btnLinkCard.Appearance.Font = new Font(btnLinkCard.Appearance.Font.FontFamily, 10);
            
            // Настройка внешнего вида статусной панели
            this.lblStatus.Appearance.Font = new Font(lblStatus.Appearance.Font.FontFamily, 9);
            this.lblStatus.Appearance.BackColor = Color.FromArgb(240, 240, 240);
            this.lblStatus.Appearance.Options.UseBackColor = true;
            
            // Настраиваем поля отображения информации
            this.txtCardInfo.Properties.Appearance.Font = new Font(txtCardInfo.Properties.Appearance.Font.FontFamily, 9);
            this.txtCardInfo.Properties.Appearance.ForeColor = Color.Navy;
            this.txtCardInfo.Properties.Appearance.Options.UseForeColor = true;
            this.txtCardInfo.Properties.ScrollBars = ScrollBars.Vertical;
            
            this.txtCardHash.Properties.Appearance.Font = new Font(txtCardHash.Properties.Appearance.Font.FontFamily, 9, FontStyle.Bold);
            this.txtCardHash.Properties.Appearance.ForeColor = Color.FromArgb(0, 114, 198);
            this.txtCardHash.Properties.Appearance.Options.UseForeColor = true;
            
            // Подготавливаем первоначальное состояние
            ShowStatus("Выберите считыватель и нажмите 'Начать считывание'", StatusType.Info);
            EnableControls(false);
            _isPolling = false;
        }

        /// <summary>
        /// Инициализирует список доступных считывателей
        /// </summary>
        private void InitializeReaders()
        {
            try
            {
                var readers = EmvCardData.GetReaders();
                cmbReaders.Properties.Items.Clear();
                
                foreach (var reader in readers)
                {
                    cmbReaders.Properties.Items.Add(reader);
                }

                if (cmbReaders.Properties.Items.Count > 0)
                {
                    cmbReaders.SelectedIndex = 0;
                    btnStartReading.Enabled = true;
                }
                else
                {
                    ShowStatus("Считыватели не найдены. Подключите считыватель и нажмите 'Обновить'", StatusType.Warning);
                    btnStartReading.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"Ошибка при инициализации считывателей: {ex.Message}", StatusType.Error);
                btnStartReading.Enabled = false;
            }
        }
        
        /// <summary>
        /// Начало мониторинга считывателя
        /// </summary>
        private void BtnStartReading_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedReader = cmbReaders.SelectedItem.ToString();
                if (string.IsNullOrEmpty(_selectedReader))
                {
                    ShowStatus("Выберите считыватель", StatusType.Warning);
                    return;
                }

                _isPolling = true;
                _pollingTimer = new Timer();
                _pollingTimer.Interval = _pollingInterval;
                _pollingTimer.Tick += PollingTimer_Tick;
                _pollingTimer.Start();
                
                EnableControls(true);
                ShowStatus($"Мониторинг считывателя '{_selectedReader}' начат. Приложите карту...", StatusType.Success);
            }
            catch (Exception ex)
            {
                ShowStatus($"Ошибка при запуске мониторинга: {ex.Message}", StatusType.Error);
                StopMonitoring();
            }
        }

        /// <summary>
        /// Обработчик таймера опроса считывателя
        /// </summary>
        private void PollingTimer_Tick(object sender, EventArgs e)
        {
            if (!_isPolling || string.IsNullOrEmpty(_selectedReader))
                return;

            try
            {
                // Проверяем наличие карты в считывателе
                bool isCardPresent = EmvCardData.IsCardInReader(_selectedReader);

                // Если карты нет, просто выходим (ждем следующего тика)
                if (!isCardPresent)
                {
                    // Сбрасываем флаг прочитанной карты при ее удалении
                    if (_cardWasRead)
                    {
                        _cardWasRead = false;
                        ShowStatus("Карта извлечена. Ожидание новой карты...", StatusType.Info);
                    }
                    return;
                }

                // Если карта уже была прочитана, не читаем её повторно (ждем удаления)
                if (_cardWasRead)
                    return;

                // Пытаемся получить данные карты
                CardData cardData = null;
                string errorMessage = string.Empty;

                if (EmvCardData.GetData(_selectedReader, out cardData, out errorMessage) == EmvCardDataResultCode.Sucess && 
                    cardData != null && 
                    !string.IsNullOrEmpty(cardData.DataHash))
                {
                    _cardWasRead = true;
                    CardHash = cardData.DataHash;
                    PAN = cardData.Pan;
                    CardHolder = cardData.CardHolder;

                    // Сохраняем извлеченные данные для отображения
                    _lastCardData.Clear();
                    if (!string.IsNullOrEmpty(cardData.Pan))
                        _lastCardData["PAN"] = MaskPan(cardData.Pan);
                    if (!string.IsNullOrEmpty(cardData.CardHolder))
                        _lastCardData["CardHolder"] = cardData.CardHolder;
                    _lastCardData["DataHash"] = cardData.DataHash;

                    // Создаем и сохраняем аргументы события чтения карты
                    CardReadEventArgs = new CardReadEventArgs
                    {
                        CardHash = CardHash,
                        Pan = PAN,
                        MaskPan = MaskPan(PAN),
                        CardHolder = CardHolder,
                        HasEmvData = true
                    };

                    // Отображаем информацию на форме
                    DisplayCardInfo(cardData);
                }
                else if (isCardPresent)
                {
                    ShowStatus($"Ошибка чтения карты: {errorMessage}", StatusType.Error);
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"Ошибка при опросе считывателя: {ex.Message}", StatusType.Error);
            }
        }

        /// <summary>
        /// Отображает информацию о карте на форме
        /// </summary>
        private void DisplayCardInfo(CardData cardData)
        {
            var cardInfo = new StringBuilder();
            cardInfo.AppendLine("Данные карты:");
            
            if (!string.IsNullOrEmpty(cardData.Pan))
                cardInfo.AppendLine($"PAN: {MaskPan(cardData.Pan)}");
            
            if (!string.IsNullOrEmpty(cardData.CardHolder))
                cardInfo.AppendLine($"Держатель: {cardData.CardHolder}");
            
            cardInfo.AppendLine($"Хеш данных: {cardData.DataHash}");
            
            // Дополнительные данные, если доступны
            if (!string.IsNullOrEmpty(cardData.ApplicationLabel))
                cardInfo.AppendLine($"Приложение: {cardData.ApplicationLabel}");

            // Обновляем информацию на форме
            BeginInvoke(new Action(() =>
            {
                txtCardInfo.Text = cardInfo.ToString();
                txtCardHash.Text = CardHash;
                txtPan.Text = MaskPan(PAN);
                txtCardHolder.Text = CardHolder ?? "Неизвестно";

                btnLinkCard.Enabled = !string.IsNullOrEmpty(CardHash);
                
                ShowStatus("Карта успешно считана", StatusType.Success);
            }));
        }

        /// <summary>
        /// Маскирует номер карты, оставляя видимыми только первые и последние 4 цифры
        /// </summary>
        private string MaskPan(string pan)
        {
            if (string.IsNullOrEmpty(pan) || pan.Length < 10)
                return pan;

            return pan.Substring(0, 4) + new string('*', pan.Length - 8) + pan.Substring(pan.Length - 4);
        }

        /// <summary>
        /// Остановка мониторинга считывателя
        /// </summary>
        private void BtnStopPolling_Click(object sender, EventArgs e)
        {
            StopMonitoring();
            ShowStatus("Мониторинг остановлен", StatusType.Info);
        }

        /// <summary>
        /// Остановка мониторинга и освобождение ресурсов
        /// </summary>
        private void StopMonitoring()
        {
            if (_pollingTimer != null)
            {
                _pollingTimer.Stop();
                _pollingTimer.Tick -= PollingTimer_Tick;
                _pollingTimer.Dispose();
                _pollingTimer = null;
            }

            _isPolling = false;
            _cardWasRead = false;
            EnableControls(false);
        }

        /// <summary>
        /// Обновление списка считывателей
        /// </summary>
        private void BtnRefreshReaders_Click(object sender, EventArgs e)
        {
            InitializeReaders();
        }

        /// <summary>
        /// Очистка полей формы
        /// </summary>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtCardInfo.Text = string.Empty;
            txtCardHash.Text = string.Empty;
            txtPan.Text = string.Empty;
            txtCardHolder.Text = string.Empty;
            CardHash = null;
            PAN = null;
            CardHolder = null;
            btnLinkCard.Enabled = false;
        }

        /// <summary>
        /// Привязка карты
        /// </summary>
        private void BtnLinkCard_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CardHash))
            {
                ShowStatus("Нет данных карты для привязки", StatusType.Warning);
                return;
            }

            // Убедимся, что аргументы события чтения карты созданы
            if (CardReadEventArgs == null)
            {
                CardReadEventArgs = new CardReadEventArgs
                {
                    CardHash = CardHash,
                    Pan = PAN,
                    MaskPan = MaskPan(PAN),
                    CardHolder = CardHolder,
                    HasEmvData = true
                };
            }

            CardLinked = true;
            ShowStatus("Карта успешно привязана!", StatusType.Success);
            
            // Визуально показываем успешную привязку
            btnLinkCard.Enabled = false;
            btnLinkCard.Text = "Карта привязана";
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            StopMonitoring();
            this.DialogResult = CardLinked ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Включение/отключение элементов управления
        /// </summary>
        private void EnableControls(bool isReading)
        {
            btnStartReading.Enabled = !isReading;
            btnStopPolling.Enabled = isReading;
            cmbReaders.Enabled = !isReading;
            btnRefreshReaders.Enabled = !isReading;
        }

        /// <summary>
        /// Типы статусных сообщений
        /// </summary>
        private enum StatusType
        {
            Info,
            Success,
            Warning,
            Error
        }

        /// <summary>
        /// Отображение статусного сообщения
        /// </summary>
        private void ShowStatus(string message, StatusType type)
        {
            BeginInvoke(new Action(() =>
            {
                lblStatus.Text = message;

                switch (type)
                {
                    case StatusType.Info:
                        lblStatus.Appearance.BackColor = Color.FromArgb(240, 240, 240);
                        lblStatus.Appearance.ForeColor = Color.Black;
                        break;
                    case StatusType.Success:
                        lblStatus.Appearance.BackColor = Color.FromArgb(230, 250, 230);
                        lblStatus.Appearance.ForeColor = Color.DarkGreen;
                        break;
                    case StatusType.Warning:
                        lblStatus.Appearance.BackColor = Color.FromArgb(255, 252, 220);
                        lblStatus.Appearance.ForeColor = Color.DarkGoldenrod;
                        break;
                    case StatusType.Error:
                        lblStatus.Appearance.BackColor = Color.FromArgb(255, 232, 232);
                        lblStatus.Appearance.ForeColor = Color.DarkRed;
                        break;
                }
                
                lblStatus.Appearance.Options.UseBackColor = true;
                lblStatus.Appearance.Options.UseForeColor = true;
            }));
        }

        /// <summary>
        /// Освобождение ресурсов при закрытии формы
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopMonitoring();
            base.OnFormClosing(e);
        }
    }
} 