using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APB.SV.CardData;

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

        public event EventHandler<CardReadEventArgs> CardRead;
        public event EventHandler<ReaderStatusEventArgs> ReaderStatusChanged;

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

        public void StartPolling(string readerName, int pollingInterval = 1000)
        {
            if (_isPolling)
            {
                StopPolling();
            }

            _selectedReader = readerName;
            _isPolling = true;
            _pollingTimer = new Timer(PollReader, null, 0, pollingInterval);
            OnReaderStatusChanged(true, $"Начато опрашивание считывателя: {readerName}");
        }

        public void StopPolling()
        {
            _isPolling = false;
            _pollingTimer?.Dispose();
            _pollingTimer = null;
            OnReaderStatusChanged(false, "Опрашивание остановлено");
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

                    // Вызываем событие с прочитанными данными
                    OnCardRead(new CardReadEventArgs 
                    { 
                        CardHash = cardHash,
                        HasEmvData = hasEmvData,
                        CardData = cardData
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
                    OnReaderStatusChanged(false, "Не удалось получить DataHash карты. Попробуйте приложить карту снова.");
                }
            }
            catch (Exception ex)
            {
                OnReaderStatusChanged(false, $"Ошибка при опросе считывателя: {ex.Message}");
            }
        }

        protected virtual void OnCardRead(CardReadEventArgs e)
        {
            CardRead?.Invoke(this, e);
        }

        protected virtual void OnReaderStatusChanged(bool isConnected, string message)
        {
            ReaderStatusChanged?.Invoke(this, new ReaderStatusEventArgs { IsConnected = isConnected, Message = message });
        }
    }

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
} 