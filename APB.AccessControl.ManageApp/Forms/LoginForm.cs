using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using APB.AccessControl.ManageApp.Services;
using DevExpress.XtraEditors;
using System.Linq;

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
            //lblStatus.Text = "Подсказка: По умолчанию пароль для admin указан в конфигурации сервера";
        }
        
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Предзаполняем имя пользователя и пароль для тестирования
            //txtUsername.Text = "admin";
            txtPassword.Text = string.IsNullOrEmpty(txtPassword.Text) ? "Adminpassword777" : txtPassword.Text;

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                XtraMessageBox.Show("Введите имя пользователя и пароль", "Ошибка входа", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            btnLogin.Enabled = false;
            lblStatus.Text = "Выполняется вход...";
            System.Windows.Forms.Application.DoEvents();
            
            try
            {
                var result = await _authService.LoginAsync(txtUsername.Text, txtPassword.Text);
                
                if (result.IsSuccess)
                {
                    // Проверяем роль пользователя
                    if (result.User?.Roles == null || !result.User.Roles.Contains("Admin"))
                    {
                        lblStatus.Text = "Доступ запрещен. Требуются права администратора.";
                        XtraMessageBox.Show("Доступ запрещен. Требуются права администратора.", "Ошибка доступа", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

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