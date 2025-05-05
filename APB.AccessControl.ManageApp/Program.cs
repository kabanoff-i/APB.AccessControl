using System;
using System.Windows.Forms;
using APB.AccessControl.ManageApp.Controls;
using APB.AccessControl.ManageApp.Services;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace APB.AccessControl.ManageApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Настройка темы приложения
            UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");

            // Настройка шрифта по умолчанию для всего приложения
            WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Segoe UI", 11F);
            WindowsFormsSettings.DefaultMenuFont = new System.Drawing.Font("Segoe UI", 11F);
            DefaultBoolean.True.ToString();
            AppearanceObject.DefaultFont = new System.Drawing.Font("Segoe UI", 11F);

            // Регистрируем обработчик необработанных исключений
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            try
            {
                LogService.LogInfo("Запуск приложения APB.AccessControl.ManageApp", "Program");
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                // Показываем форму логина перед запуском основной формы
                using (var loginForm = new LoginForm())
                {
                    LogService.LogInfo("Отображение формы авторизации", "Program");
                    var result = loginForm.ShowDialog();
                    
                    if (result == DialogResult.OK)
                    {
                        // Если авторизация успешна, запускаем основное приложение
                        LogService.LogInfo("Авторизация успешна. Запуск основной формы", "Program");
                        Application.Run(new MainForm());
                    }
                    else
                    {
                        // Выход, если пользователь отменил вход или не смог авторизоваться
                        LogService.LogInfo("Авторизация отменена. Выход из приложения", "Program");
                        MessageBox.Show("Приложение закрыто, так как не выполнен вход в систему.", 
                            "Выход из приложения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, "Program.Main");
                MessageBox.Show($"Произошла критическая ошибка при запуске приложения: {ex.Message}",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Обработчик необработанных исключений в UI потоке
        /// </summary>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogService.LogError(e.Exception, "Необработанное исключение в UI потоке");
            MessageBox.Show($"Произошла непредвиденная ошибка: {e.Exception.Message}\nПриложение может работать нестабильно.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        /// <summary>
        /// Обработчик необработанных исключений в других потоках
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                LogService.LogError(ex, "Необработанное исключение в фоновом потоке");
                MessageBox.Show($"Произошла критическая ошибка: {ex.Message}\nПриложение будет закрыто.",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LogService.LogError("Неизвестное необработанное исключение", "UnhandledException");
            }
        }
    }
}