using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Identity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Forms
{
    public partial class UserEditForm : XtraForm
    {
        // Результат формы - запрос на создание или обновление пользователя
        public CreateUserWithRolesReq CreateRequest { get; private set; }
        public UpdateUserReq UpdateRequest { get; private set; }
        
        // Режим формы (создание или редактирование)
        private bool _isEditMode;
        
        // Коллекция ролей
        private IEnumerable<RoleDto> _roles;
        
        // Исходные данные пользователя при редактировании
        private UserDto _originalUser;
        
        /// <summary>
        /// Конструктор формы для режима создания нового пользователя
        /// </summary>
        public UserEditForm(IEnumerable<RoleDto> roles)
        {
            InitializeComponent();
            
            _isEditMode = false;
            _roles = roles;
            
            // Создаем новый запрос
            CreateRequest = new CreateUserWithRolesReq
            {
                Username = string.Empty,
                Password = string.Empty,
                Roles = new List<string>()
            };
            
            Text = "Создание пользователя";
        }
        
        /// <summary>
        /// Конструктор формы для режима редактирования
        /// </summary>
        public UserEditForm(UserDto user, IEnumerable<RoleDto> roles)
        {
            InitializeComponent();
            
            _isEditMode = true;
            _originalUser = user;
            _roles = roles;
            
            // Создаем запрос редактирования на основе существующего пользователя
            UpdateRequest = new UpdateUserReq
            {
                Id = user.Id,
                Roles = user.Roles
            };
            
            Text = $"Редактирование пользователя {user.Username}";
        }
        
        /// <summary>
        /// Инициализация формы при загрузке
        /// </summary>
        private void UserEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls();
                LoadDataToControls();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Ошибка при инициализации формы: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
        
        /// <summary>
        /// Инициализация элементов управления
        /// </summary>
        private void InitializeControls()
        {
            try
            {
                // Проверяем, что роли пришли
                if (_roles == null)
                {
                    XtraMessageBox.Show("Список ролей не инициализирован", 
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var rolesList = _roles.ToList();
                if (!rolesList.Any())
                {
                    XtraMessageBox.Show("Список ролей пуст", 
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Настройка комбобокса ролей
                checkedComboBoxRoles.Properties.DataSource = rolesList;
                checkedComboBoxRoles.Properties.DisplayMember = "Name";
                checkedComboBoxRoles.Properties.ValueMember = "Name";
                checkedComboBoxRoles.Properties.SeparatorChar = ';';

                // Настройка полей в зависимости от режима
                if (_isEditMode)
                {
                    // В режиме редактирования скрываем поля логина и пароля
                    textEditUsername.Enabled = false;
                    textEditPassword.Enabled = false;
                    textEditPasswordConfirm.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Ошибка при инициализации контролов: {ex.Message}", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Загрузка данных в элементы управления
        /// </summary>
        private void LoadDataToControls()
        {
            if (_isEditMode)
            {
                // Заполняем элементы управления данными существующего пользователя
                textEditUsername.Text = _originalUser.Username;
                
                // Устанавливаем выбранные роли
                if (_originalUser.Roles != null && _originalUser.Roles.Any())
                {
                    var selectedRoles = string.Join(";", _originalUser.Roles);
                    checkedComboBoxRoles.EditValue = selectedRoles;
                }
            }
        }
        
        /// <summary>
        /// Проверка корректности введенных данных
        /// </summary>
        private bool ValidateInput()
        {
            // Проверка логина (только при создании)
            if (!_isEditMode && string.IsNullOrWhiteSpace(textEditUsername.Text))
            {
                XtraMessageBox.Show("Необходимо указать логин пользователя", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Проверка пароля (только при создании)
            if (!_isEditMode)
            {
                if (string.IsNullOrWhiteSpace(textEditPassword.Text))
                {
                    XtraMessageBox.Show("Необходимо указать пароль", 
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
                if (textEditPassword.Text != textEditPasswordConfirm.Text)
                {
                    XtraMessageBox.Show("Пароли не совпадают", 
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            
            // Проверка выбора хотя бы одной роли
            var selectedRoles = checkedComboBoxRoles.EditValue as string;
            if (string.IsNullOrEmpty(selectedRoles))
            {
                XtraMessageBox.Show("Необходимо выбрать хотя бы одну роль", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
        
        /// <summary>
        /// Сохранение данных из формы в объект запроса
        /// </summary>
        private void SaveDataToRequest()
        {
            var selectedRoles = checkedComboBoxRoles.EditValue as string;
            var roleNames = selectedRoles?.Split(';').Where(r => !string.IsNullOrEmpty(r)).ToList() ?? new List<string>();
            
            if (_isEditMode)
            {
                // Обновляем запрос редактирования
                UpdateRequest.Roles = roleNames;
            }
            else
            {
                // Обновляем запрос создания
                CreateRequest.Username = textEditUsername.Text;
                CreateRequest.Password = textEditPassword.Text;
                CreateRequest.Roles = roleNames;
            }
        }
        
        /// <summary>
        /// Обработчик кнопки "Сохранить"
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveDataToRequest();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        
        /// <summary>
        /// Обработчик кнопки "Отмена"
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 