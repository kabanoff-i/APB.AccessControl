using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APB.SV.CardData;
using Timer = System.Threading.Timer;

namespace APB.AccessControl.ClientApp.Services
{
    public class CardReaderService
    {
        private Timer _pollingTimer;
        private string _selectedReader;
        private bool _isPolling;
        private bool _cardWasRead = false;
        private string _lastReadCardHash = null;
        private readonly int _cardCooldownMs = 2000; // время задержки между считыванием одной и той же карты
        private bool _isRunning;

        public event EventHandler<CardReadEventArgs> OnCardRead;
        public event EventHandler<ReaderStatusEventArgs> OnReaderStatusChanged;

        public bool IsRunning => _isRunning;

        public IEnumerable<string> GetAvailableReaders()
        {
            try
            {
                return EmvCardData.GetReaders();
            }
            catch (Exception ex)
            {
                OnReaderStatusChanged(this, new ReaderStatusEventArgs { Status = $"Ошибка получения списка считывателей: {ex.Message}", IsRunning = false });
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
                OnReaderStatusChanged(this, new ReaderStatusEventArgs { Status = $"Ошибка проверки подключения считывателя: {ex.Message}", IsRunning = false });
                return false;
            }
        }

        public void StartPolling(string readerName, int pollingInterval = 1000)
        {
            if (_isPolling)
            {
                StopPolling();
            }

            _selectedReader = readerName;
            _isPolling = true;
            _pollingTimer = new Timer(PollReader, null, 0, pollingInterval);
            OnReaderStatusChanged(this, new ReaderStatusEventArgs { Status = $"Начато опрашивание считывателя: {readerName}", IsRunning = true });
        }

        public void StopPolling()
        {
            _isPolling = false;
            _pollingTimer?.Dispose();
            _pollingTimer = null;
            OnReaderStatusChanged(this, new ReaderStatusEventArgs { Status = "Опрашивание остановлено", IsRunning = false });
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
                        OnReaderStatusChanged(this, new ReaderStatusEventArgs { Status = "Считыватель готов. Ожидание карты...", IsRunning = true });
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

                    // Вызываем событие с прочитанными данными
                    OnCardRead(this, new CardReadEventArgs 
                    { 
                        MaskPan = $"**** **** **** {cardHash.Substring(cardHash.Length - 4)}",
                        CardHash = cardHash
                    });
                    
                    // Через некоторое время сбросим статус карты, если её не убрали
                    Task.Delay(_cardCooldownMs).ContinueWith(_ => 
                    {
                        _cardWasRead = false; // разрешаем новое считывание
                    });
                }
                else if (isCardPresent)
                {
                    // Если карта есть, но не удалось получить данные - сообщаем об ошибке
                    OnReaderStatusChanged(this, new ReaderStatusEventArgs { Status = "Не удалось получить DataHash карты. Попробуйте приложить карту снова.", IsRunning = false });
                }
            }
            catch (Exception ex)
            {
                OnReaderStatusChanged(this, new ReaderStatusEventArgs { Status = $"Ошибка при опросе считывателя: {ex.Message}", IsRunning = false });
            }
        }

        public void StartReader(string readerName)
        {
            if (_isRunning)
            {
                StopReader();
            }

            _selectedReader = readerName;
            _isRunning = true;
            StartPolling(readerName);
            OnReaderStatusChanged(this, new ReaderStatusEventArgs { Status = "Работает", IsRunning = true });
        }

        public void StopReader()
        {
            if (!_isRunning)
            {
                return;
            }

            StopPolling();
            _isRunning = false;
            _selectedReader = null;
            OnReaderStatusChanged(this, new ReaderStatusEventArgs { Status = "Остановлен", IsRunning = false });
        }
    }

    public class CardReadEventArgs : EventArgs
    {
        public string MaskPan { get; set; }
        public string CardHash { get; set; }
    }

    public class ReaderStatusEventArgs : EventArgs
    {
        public string Status { get; set; }
        public bool IsRunning { get; set; }
    }
} 