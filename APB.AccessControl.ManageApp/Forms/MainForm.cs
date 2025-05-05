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
            
            // Добавляем кнопку выхода из системы
            AddLogoutButton();
            
            // Добавляем отображение статуса токена
            AddTokenStatusIndicator();
            
            // Запускаем таймер для проверки состояния токена
            InitializeTokenExpiryCheck();
        }
        
        private void InitializeModules()
        {
            _modules =
            [
                // Добавляем модуль управления сотрудниками
                new ModuleInfo("EmployeeManagement", "APB.AccessControl.ManageApp.Controls.EmployeeManagementControl", "Управление сотрудниками"),
            ];
            
            // Создаем пункты меню для каждого модуля
            foreach (var module in _modules)
            {
                var item = new AccordionControlElement
                {
                    Text = module.Name,
                    Tag = module,
                    Style = ElementStyle.Item
                };
                
                // Добавляем в аккордион главной формы
                accordionControl.Elements.Add(item);
                
                // Обработчик клика на пункт меню
                item.Click += async (s, e) =>
                {
                    if (s is AccordionControlElement element && element.Tag is ModuleInfo moduleInfo)
                    {
                        this.itemNav.Caption = $"{element.Name}";
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
                if (!MainFormContainer.Controls.ContainsKey(module.Name))
                {
                    // Создаем экземпляр контрола модуля
                    TutorialControlBase control = module.TModule as TutorialControlBase;
                    if (control != null)
                    {
                        control.Dock = DockStyle.Fill;
                        control.CreateWaitDialog();
                        MainFormContainer.Invoke(new MethodInvoker(() => 
                        {
                            MainFormContainer.Controls.Add(control);
                            control.BringToFront();
                        }));
                    }
                }
                else
                {
                    var control = MainFormContainer.Controls.Find(module.Name, true);
                    if (control.Length == 1)
                        MainFormContainer.Invoke(new MethodInvoker(() => { control[0].BringToFront(); }));
                }
            });
        }

        /// <summary>
        /// Добавляет кнопку выхода из системы в меню
        /// </summary>
        private void AddLogoutButton()
        {
            var logoutElement = new AccordionControlElement
            {
                Text = "Выход из системы",
                Style = ElementStyle.Item
            };
            
            accordionControl.Elements.Add(logoutElement);
            
            logoutElement.Click += (s, e) =>
            {
                if (XtraMessageBox.Show("Вы действительно хотите выйти из системы?", 
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Выходим из системы
                    _authService.Logout();
                    Application.Restart();
                }
            };
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
    }
}
