using System;
using System.Windows.Forms;

namespace APB.AccessControl.ClientApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            { 
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                //System.Windows.Forms.Application.Run(new LoginForm());

                // Показываем форму логина перед запуском основной формы
                using (var loginForm = new LoginForm())
                {
                    var result = loginForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Если авторизация успешна, запускаем основное приложение
                        System.Windows.Forms.Application.Run(new MainForm());
                    }
                    else
                    {
                        // Выход, если пользователь отменил вход или не смог авторизоваться
                        MessageBox.Show("Приложение закрыто, так как не выполнен вход в систему.",
                            "Выход из приложения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла критическая ошибка при запуске приложения: {ex.Message}",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
