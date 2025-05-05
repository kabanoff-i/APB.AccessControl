using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using APB.AccessControl.ManageApp.Controls;
using APB.AccessControl.ManageApp.Services;

namespace APB.AccessControl.ManageApp.Forms
{
    /// <summary>
    /// Форма для считывания карты
    /// </summary>
    public partial class CardReaderForm : XtraForm
    {
        private CardReaderControl _cardReaderControl;
        
        /// <summary>
        /// Данные считанной карты
        /// </summary>
        public CardReadEventArgs CardReadEventArgs { get; private set; }
        
        public CardReaderForm()
        {
            InitializeComponent();
            
            try
            {
                InitializeCardReader();
                LogService.LogInfo("Форма CardReaderForm создана", "CardReaderForm");
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, "CardReaderForm.Constructor");
                XtraMessageBox.Show($"Ошибка инициализации считывателя карт: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void InitializeCardReader()
        {
            try
            {
                _cardReaderControl = new CardReaderControl();
                _cardReaderControl.Dock = DockStyle.Fill;
                _cardReaderControl.CardRead += CardReaderControl_CardRead;
                panelCardReader.Controls.Add(_cardReaderControl);
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, "CardReaderForm.InitializeCardReader");
                throw; // Пробрасываем исключение выше для обработки в конструкторе
            }
        }
        
        private void CardReaderControl_CardRead(object sender, CardReadEventArgs e)
        {
            try
            {
                CardReadEventArgs = e;
                LogService.LogInfo($"Карта считана: {e.CardHash}", "CardReaderForm");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, "CardReaderForm.CardReaderControl_CardRead");
            }
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                base.OnFormClosing(e);
                
                // Отписываемся от событий
                if (_cardReaderControl != null)
                {
                    _cardReaderControl.CardRead -= CardReaderControl_CardRead;
                }
                
                LogService.LogInfo("Форма CardReaderForm закрывается", "CardReaderForm");
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, "CardReaderForm.OnFormClosing");
            }
        }
    }
} 