using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Timer = System.Threading.Timer;
using System.Threading.Tasks;
using System.Windows.Forms;
using APB.SV.CardData;
using DevExpress.DXperience.Demos;
using DevExpress.XtraEditors;

namespace APB.AccessControl.ManageApp.Controls
{
    public partial class CardReaderControl : TutorialControlBase
    {
        private Timer _pollingTimer;
        private string _selectedReader;
        private bool _isPolling;
        private bool _cardWasRead = false;
        private string _lastReadCardHash = null;
        private readonly int _cardCooldownMs = 2000; // время задержки между считыванием одной и той же карты

        public event EventHandler<CardReadEventArgs> CardRead;
        public event EventHandler<ReaderStatusEventArgs> ReaderStatusChanged;

        public CardReaderControl()
        {
            InitializeComponent();
            Name = "CardReaderControl";
            InitializeEventHandlers();
        }

        #region Инициализация и обработчики событий

        private void InitializeEventHandlers()
        {
            btnRefreshReaders.Click += (s, e) => LoadReaders();
            btnStartPolling.Click += (s, e) => StartPolling();
            btnStopPolling.Click += (s, e) => StopPolling();
            btnClear.Click += (s, e) => ClearCardInfo();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadReaders();
        }

        private void LoadReaders()
        {
            try
            {
                string[] readers = GetAvailableReaders();
                cmbReaders.Properties.Items.Clear();
                
                if (readers.Length > 0)
                {
                    foreach (string reader in readers)
                    {
                        cmbReaders.Properties.Items.Add(reader);
                    }
                    
                    cmbReaders.SelectedIndex = 0;
                    SetStatus("Выберите считыватель и нажмите 'Начать считывание'", false);
                    btnStartPolling.Enabled = true;
                }
                else
                {
                    SetStatus("Не найдены доступные считыватели", true);
                    btnStartPolling.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                SetStatus($"Ошибка загрузки считывателей: {ex.Message}", true);
                btnStartPolling.Enabled = false;
            }
        }

        private void ClearCardInfo()
        {
            txtCardInfo.Text = string.Empty;
            txtCardHash.Text = string.Empty;
            txtPan.Text = string.Empty;
            txtCardHolder.Text = string.Empty;
        }

        #endregion

        #region Методы работы со считывателем

        public string[] GetAvailableReaders()
        {
            try
            {
                return EmvCardData.GetReaders();
            }
            catch (Exception ex)
            {
                OnReaderStatusChanged(false, $"Ошибка получения списка считывателей: {ex.Message}");
                return Array.Empty<string>();
            }
        }

        public bool IsReaderConnected(string readerName)
        {
            try
            {
                return EmvCardData.IsCardInReader(readerName);
            }
            catch (Exception ex)
            {
                OnReaderStatusChanged(false, $"Ошибка проверки подключения считывателя: {ex.Message}");
                return false;
            }
        }

        public void StartPolling()
        {
            if (_isPolling)
            {
                StopPolling();
            }

            if (cmbReaders.SelectedItem == null)
            {
                SetStatus("Выберите считыватель", true);
                return;
            }

            _selectedReader = cmbReaders.SelectedItem.ToString();
            _isPolling = true;
            _pollingTimer = new Timer(PollReader, null, 0, 1000);
            
            OnReaderStatusChanged(true, $"Начато опрашивание считывателя: {_selectedReader}");
            
            btnStartPolling.Enabled = false;
            btnStopPolling.Enabled = true;
            cmbReaders.Enabled = false;
            btnRefreshReaders.Enabled = false;
        }

        public void StopPolling()
        {
            _isPolling = false;
            _pollingTimer?.Dispose();
            _pollingTimer = null;
            
            OnReaderStatusChanged(false, "Опрашивание остановлено");
            
            btnStartPolling.Enabled = true;
            btnStopPolling.Enabled = false;
            cmbReaders.Enabled = true;
            btnRefreshReaders.Enabled = true;
        }

        private void PollReader(object state)
        {
            if (!_isPolling || string.IsNullOrEmpty(_selectedReader))
                return;

            try
            {
                // Проверяем наличие карты в считывателе
                bool isCardPresent = EmvCardData.IsCardInReader(_selectedReader);

                // Если карты нет, сбрасываем флаг прочитанной карты
                if (!isCardPresent)
                {
                    if (_cardWasRead)
                    {
                        _cardWasRead = false;
                        _lastReadCardHash = null;
                        OnReaderStatusChanged(true, "Считыватель готов. Ожидание карты...");
                    }
                    return;
                }

                // Если карта уже была прочитана, ждем ее удаления перед новым считыванием
                if (_cardWasRead)
                    return;

                // Пытаемся получить данные EMV
                CardData cardData = null;
                string cardHash = null;
                bool hasEmvData = false;

                if (EmvCardData.GetData(_selectedReader, out cardData, out string emvError) == EmvCardDataResultCode.Sucess && 
                    cardData != null && 
                    !string.IsNullOrEmpty(cardData.DataHash))
                {
                    hasEmvData = true;
                    cardHash = cardData.DataHash;

                    // Проверяем, не та же ли это карта, что была только что считана
                    if (cardHash == _lastReadCardHash)
                        return;

                    _cardWasRead = true;
                    _lastReadCardHash = cardHash;

                    // Вызываем событие с прочитанными данными и обновляем UI
                    var cardReadEvent = new CardReadEventArgs 
                    { 
                        CardHash = cardHash,
                        HasEmvData = hasEmvData,
                        CardData = cardData
                    };

                    OnCardRead(cardReadEvent);
                    UpdateCardInfo(cardReadEvent);
                    
                    // Через некоторое время сбросим статус карты, если её не убрали
                    Task.Delay(_cardCooldownMs).ContinueWith(_ => 
                    {
                        _cardWasRead = false; // разрешаем новое считывание
                    });
                }
                else if (isCardPresent)
                {
                    // Если карта есть, но не удалось получить данные - сообщаем об ошибке
                    OnReaderStatusChanged(false, "Не удалось получить DataHash карты. Попробуйте приложить карту снова.");
                }
            }
            catch (Exception ex)
            {
                OnReaderStatusChanged(false, $"Ошибка при опросе считывателя: {ex.Message}");
            }
        }

        private void UpdateCardInfo(CardReadEventArgs e)
        {
            // Обновляем UI в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateCardInfo(e)));
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Карта обнаружена!");
            sb.AppendLine($"Хеш карты: {e.CardHash}");
            
            if (e.HasEmvData && e.CardData != null)
            {
                sb.AppendLine("EMV данные: Да");
                
                if (!string.IsNullOrEmpty(e.CardData.CardHolder))
                    sb.AppendLine($"Держатель: {e.CardData.CardHolder}");
                
                if (!string.IsNullOrEmpty(e.CardData.Pan))
                {
                    string maskedPan = e.CardData.Pan;
                    if (maskedPan.Length > 10) // достаточно длинный для маскирования
                    {
                        maskedPan = $"{maskedPan.Substring(0, 6)}****{maskedPan.Substring(maskedPan.Length - 4)}";
                    }
                    sb.AppendLine($"PAN: {maskedPan}");
                    txtPan.Text = maskedPan;
                }
                
                txtCardHolder.Text = e.CardData.CardHolder ?? "";
            }
            else
            {
                sb.AppendLine("EMV данные: Нет");
            }
            
            txtCardInfo.Text = sb.ToString();
            txtCardHash.Text = e.CardHash;
        }

        protected virtual void OnCardRead(CardReadEventArgs e)
        {
            CardRead?.Invoke(this, e);
        }

        protected virtual void OnReaderStatusChanged(bool isConnected, string message)
        {
            // Обновляем UI в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetStatus(message, !isConnected)));
            }
            else
            {
                SetStatus(message, !isConnected);
            }

            ReaderStatusChanged?.Invoke(this, new ReaderStatusEventArgs { IsConnected = isConnected, Message = message });
        }

        private void SetStatus(string message, bool isError)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        #endregion

        #region Методы очистки ресурсов

        protected override void OnHandleDestroyed(EventArgs e)
        {
            StopPolling();
            base.OnHandleDestroyed(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StopPolling();
                _pollingTimer?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }

    #region Вспомогательные классы для событий

    public class CardReadEventArgs : EventArgs
    {
        public string CardHash { get; set; }
        public bool HasEmvData { get; set; }
        public CardData CardData { get; set; }
    }

    public class ReaderStatusEventArgs : EventArgs
    {
        public bool IsConnected { get; set; }
        public string Message { get; set; }
    }

    #endregion
} 