using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using APB.AccessControl.ManageApp.Services;
using DevExpress.XtraEditors;

namespace APB.AccessControl.ManageApp.Controls
{
    public partial class LoginForm : XtraForm
    {
        private readonly AuthService _authService;
        
        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            
            // Предзаполняем имя пользователя по умолчанию и подсказку о пароле
            txtUsername.Text = "admin";
            lblStatus.Text = "Подсказка: По умолчанию пароль для admin указан в конфигурации сервера";
        }
        
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Предзаполняем имя пользователя и пароль для тестирования
            txtUsername.Text = "admin";
            txtPassword.Text = "Adminpassword777";

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                XtraMessageBox.Show("Введите имя пользователя и пароль", "Ошибка входа", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            btnLogin.Enabled = false;
            lblStatus.Text = "Выполняется вход...";
            Application.DoEvents();
            
            try
            {
                var result = await _authService.LoginAsync(txtUsername.Text, txtPassword.Text);
                
                if (result.IsSuccess)
                {
                    // Показываем информацию о токене
                    lblStatus.Text = $"Вход выполнен. Токен получен (действует до {result.ExpiresAt:dd.MM.yyyy HH:mm:ss})";
                    
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    lblStatus.Text = result.ErrorMessage;
                    XtraMessageBox.Show(result.ErrorMessage, "Ошибка входа", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Ошибка: {ex.Message}";
                XtraMessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка входа", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 