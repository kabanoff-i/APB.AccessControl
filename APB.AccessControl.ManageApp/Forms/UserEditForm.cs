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
        public CreateUserReq CreateRequest { get; private set; }
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
            CreateRequest = new CreateUserReq
            {
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
                FullName = user.FullName,
                Roles = user.Roles,
                IsActive = user.IsActive
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
            // Настройка комбобокса ролей
            checkedComboBoxRoles.Properties.DataSource = _roles;
            checkedComboBoxRoles.Properties.DisplayMember = "Name";
            checkedComboBoxRoles.Properties.ValueMember = "Name";
            
            // Настройка полей в зависимости от режима
            if (_isEditMode)
            {
                // В режиме редактирования скрываем поля логина и пароля
                textEditUsername.Enabled = false;
                textEditPassword.Enabled = false;
                textEditPasswordConfirm.Enabled = false;
                
                // Показываем чекбокс активности
                checkEditActive.Visible = true;
            }
            else
            {
                // В режиме создания скрываем чекбокс активности
                checkEditActive.Visible = false;
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
                textEditFullName.Text = UpdateRequest.FullName;
                checkedComboBoxRoles.EditValue = UpdateRequest.Roles;
                checkEditActive.Checked = UpdateRequest.IsActive;
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
            
            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(textEditFullName.Text))
            {
                XtraMessageBox.Show("Необходимо указать ФИО", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Проверка выбора хотя бы одной роли
            var selectedRoles = checkedComboBoxRoles.EditValue as List<string>;
            if (selectedRoles == null || selectedRoles.Count == 0)
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
            var selectedRoles = checkedComboBoxRoles.EditValue as List<string>;
            
            if (_isEditMode)
            {
                // Обновляем запрос редактирования
                UpdateRequest.FullName = textEditFullName.Text;
                UpdateRequest.Roles = selectedRoles;
                UpdateRequest.IsActive = checkEditActive.Checked;
            }
            else
            {
                // Обновляем запрос создания
                CreateRequest.Username = textEditUsername.Text;
                CreateRequest.Password = textEditPassword.Text;
                CreateRequest.FullName = textEditFullName.Text;
                CreateRequest.Roles = selectedRoles;
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