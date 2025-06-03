using DevExpress.DXperience.Demos;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APB.AccessControl.ManageApp.Controls;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using APB.AccessControl.ManageApp.Services;
using System.Threading;

namespace APB.AccessControl.ManageApp
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private List<ModuleInfo> _modules;
        private readonly AuthService _authService;
        private System.Windows.Forms.Timer _tokenCheckTimer;
        private BarStaticItem _tokenStatusItem;

        public MainForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            InitializeModules();

            InitilizeAccordion(accordionControl.Elements);

            // Добавляем отображение статуса токена
            AddTokenStatusIndicator();

            // Запускаем таймер для проверки состояния токена
            InitializeTokenExpiryCheck();
        }

        /// <summary>
        /// Инициализация модулей приложения
        /// </summary>
        private void InitializeModules()
        {
            _modules =
            [
                new ModuleInfo("EmployeeManagement", "APB.AccessControl.ManageApp.Controls.EmployeeManagementControl", "Управление сотрудниками"),
                new ModuleInfo("AccessGroupManagement", "APB.AccessControl.ManageApp.Controls.AccessGroupManagementControl", "Управление группами доступа"),
                new ModuleInfo("AccessPointManagement", "APB.AccessControl.ManageApp.Controls.AccessPointManagementControl", "Управление точками доступа"),
                new ModuleInfo("AccessRuleManagement", "APB.AccessControl.ManageApp.Controls.AccessRuleManagementControl", "Правила доступа"),
                new ModuleInfo("AccessLogView", "APB.AccessControl.ManageApp.Controls.AccessLogControl", "История доступа"),
                new ModuleInfo("NotificationsManagement", "APB.AccessControl.ManageApp.Controls.NotificationControl", "Уведомления"),
                new ModuleInfo("UserManagementControl", "APB.AccessControl.ManageApp.Controls.UserManagementControl", "Управление пользователями")
            ];
        }

        private void InitilizeAccordion(AccordionControlElementCollection elements)
        {
            itemNav.ItemAppearance.Normal.ForeColor = Color.White;

            // Создаем пункты меню для каждого модуля
            foreach (var element in elements)
            {
                if (element.Style == ElementStyle.Group)
                    InitilizeAccordion(element.Elements);

                element.Tag = _modules.FirstOrDefault(m => m.Name == element.Name);

                // Обработчик клика на пункт меню
                element.Click += async (s, e) =>
                {
                    if (s is AccordionControlElement element && element.Tag is ModuleInfo moduleInfo)
                    {
                        this.itemNav.Caption = $"{element.Text}";
                        // Загружаем соответствующий модуль
                        await LoadModuleAsync(moduleInfo);
                    }
                };
            }
        }

        async Task LoadModuleAsync(ModuleInfo module)
        {
            await Task.Factory.StartNew(() =>
            {
                MainFormContainer.Invoke(new MethodInvoker(() =>
                {
                    // Закрываем все открытые модули
                    foreach (Control control in MainFormContainer.Controls)
                    {
                        if (control is TutorialControlBase && control.Name != module.Name)
                        {
                            // Вызываем Dispose для освобождения ресурсов
                            control.Dispose();
                            MainFormContainer.Controls.Remove(control);
                            module.ResetModule();
                        }
                    }

                    // Проверяем, существует ли уже модуль с таким именем
                    if (!MainFormContainer.Controls.ContainsKey(module.Name))
                    {
                        // Создаем экземпляр контрола модуля
                        var control = module.TModule as TutorialControlBase;
                        if (control != null)
                        {
                            control.Dock = DockStyle.Fill;
                            MainFormContainer.Controls.Add(control);
                            control.BringToFront();
                        }
                    }
                    else
                    {
                        var control = MainFormContainer.Controls.Find(module.Name, true);
                        if (control.Length == 1)
                            control[0].BringToFront();
                    }
                }));
            });
        }

        /// <summary>
        /// Добавляет индикатор статуса токена в строку состояния
        /// </summary>
        private void AddTokenStatusIndicator()
        {
            if (MainFormControl.Items.Count > 0)
            {
                // Добавляем индикатор статуса в правую часть строки состояния
                _tokenStatusItem = new BarStaticItem();
                _tokenStatusItem.Caption = "Загрузка информации о токене...";
                MainFormControl.Items.Add(_tokenStatusItem);

                // Обновляем информацию о токене
                UpdateTokenStatusInfo();
            }
        }

        /// <summary>
        /// Инициализирует таймер для проверки срока действия токена
        /// </summary>
        private void InitializeTokenExpiryCheck()
        {
            _tokenCheckTimer = new System.Windows.Forms.Timer();
            _tokenCheckTimer.Interval = 30000; // Проверяем каждые 30 секунд
            _tokenCheckTimer.Tick += TokenCheckTimer_Tick;
            _tokenCheckTimer.Start();
        }

        /// <summary>
        /// Обработчик события таймера проверки токена
        /// </summary>
        private async void TokenCheckTimer_Tick(object sender, EventArgs e)
        {
            UpdateTokenStatusInfo();

            // Проверяем, не истекает ли скоро токен
            var timeLeft = _authService.GetTokenExpiryTimeLeft();

            // Если токен не активен или истекает менее чем через 5 минут, показываем предупреждение
            if (!_authService.IsAuthenticated() || (timeLeft.TotalMinutes < 5))
            {
                _tokenCheckTimer.Stop();

                var message = !_authService.IsAuthenticated()
                    ? "Ваша сессия истекла. Необходимо повторно войти в систему."
                    : $"Ваша сессия истекает через {timeLeft.Minutes} мин. {timeLeft.Seconds} сек. Желаете продлить сессию?";

                var result = XtraMessageBox.Show(message, "Предупреждение о сессии",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Показываем форму входа для обновления токена
                    using (var loginForm = new LoginForm())
                    {
                        if (loginForm.ShowDialog() == DialogResult.OK)
                        {
                            // Токен был обновлен успешно
                            XtraMessageBox.Show("Сессия успешно продлена.", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Пользователь отменил вход, продолжаем с текущим токеном
                            XtraMessageBox.Show("Продление сессии отменено пользователем.", "Внимание",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                _tokenCheckTimer.Start();
            }
        }

        /// <summary>
        /// Обновляет информацию о статусе токена
        /// </summary>
        private void UpdateTokenStatusInfo()
        {
            if (_tokenStatusItem != null)
            {
                if (_authService.IsAuthenticated())
                {
                    var timeLeft = _authService.GetTokenExpiryTimeLeft();
                    _tokenStatusItem.Caption = $"Токен активен. Осталось: {timeLeft.Hours:00}:{timeLeft.Minutes:00}:{timeLeft.Seconds:00}";

                    // Устанавливаем цвет в зависимости от оставшегося времени
                    if (timeLeft.TotalMinutes < 5)
                    {
                        _tokenStatusItem.ItemAppearance.Normal.ForeColor = Color.Red;
                    }
                    else if (timeLeft.TotalMinutes < 15)
                    {
                        _tokenStatusItem.ItemAppearance.Normal.ForeColor = Color.Orange;
                    }
                    else
                    {
                        _tokenStatusItem.ItemAppearance.Normal.ForeColor = Color.Green;
                    }
                }
                else
                {
                    _tokenStatusItem.Caption = "Токен неактивен! Требуется авторизация";
                    _tokenStatusItem.ItemAppearance.Normal.ForeColor = Color.Red;
                }
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Вы действительно хотите выйти из системы?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Выходим из системы
                _authService.Logout();
                System.Windows.Forms.Application.Restart();
            }
        }
    }
}
