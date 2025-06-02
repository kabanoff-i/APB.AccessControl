using APB.AccessControl.ManageApp.Forms;
using APB.AccessControl.ManageApp.Presenters;
using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Identity;
using DevExpress.DXperience.Demos;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Controls
{
    /// <summary>
    /// Контрол для управления пользователями
    /// </summary>
    public partial class UserManagementControl : TutorialControlBase, IUserView
    {
        private UserPresenter _presenter;
        private IEnumerable<UserDto> _currentUsers;
        private IEnumerable<RoleDto> _roles;

        public event EventHandler RefreshData;
        public event EventHandler<CreateUserReq> CreateUser;
        public event EventHandler<UpdateUserReq> UpdateUser;
        public event EventHandler<int> DeleteUser;
        public event EventHandler<ChangePasswordReq> ChangePassword;

        public UserManagementControl()
        {
            InitializeComponent();
            InitializeGridView();
            Name = "UserManagementControl";

            // Создаем сервисы для работы с API
            var userService = new UserService(new ApiService());

            _presenter = new UserPresenter(this, userService);
        }

        /// <summary>
        /// Инициализация представления после загрузки
        /// </summary>
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                await _presenter.InitializeAsync();
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при инициализации: {ex.Message}");
            }
        }

        /// <summary>
        /// Инициализация настроек отображения таблицы
        /// </summary>
        private void InitializeGridView()
        {
            // Настройка внешнего вида таблицы
            gridViewUsers.OptionsBehavior.Editable = false;
            gridViewUsers.OptionsBehavior.ReadOnly = true;
            gridViewUsers.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewUsers.OptionsView.ShowGroupPanel = false;
            gridViewUsers.OptionsView.ShowIndicator = false;
            gridViewUsers.OptionsView.ColumnAutoWidth = false;
            gridViewUsers.OptionsView.RowAutoHeight = true;

            // Устанавливаем начальный DataSource
            gridControlUsers.DataSource = new List<UserDto>();

            // Настройка цветов строк таблицы
            gridViewUsers.Appearance.Row.BackColor = Color.White;
            gridViewUsers.Appearance.Row.Options.UseBackColor = true;

            // Настройка обработчиков форматирования данных
            gridViewUsers.CustomColumnDisplayText += GridViewUsers_CustomColumnDisplayText;
            gridControlUsers.DataSourceChanged += GridControlUsers_DataSourceChanged;
            gridViewUsers.RowStyle += GridViewUsers_RowStyle;
        }

        private void GridControlUsers_DataSourceChanged(object sender, EventArgs e)
        {
            // Скрываем ненужные колонки
            var columnsToHide = new[] { "Id", "Roles" };
            foreach (var columnName in columnsToHide)
            {
                if (gridViewUsers.Columns[columnName] != null)
                {
                    gridViewUsers.Columns[columnName].Visible = false;
                }
            }
        }

        /// <summary>
        /// Обработчик стиля строки
        /// </summary>
        private void GridViewUsers_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView view = sender as GridView;

                try
                {
                    bool isActive = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "IsActive"));

                    if (!isActive)
                    {
                        // Для неактивных пользователей окрашиваем строку в серый
                        e.Appearance.BackColor = Color.LightGray;
                    }
                }
                catch
                {
                    // Игнорируем ошибки при получении значения
                }
            }
        }

        /// <summary>
        /// Обработчик для форматирования данных в колонках
        /// </summary>
        private void GridViewUsers_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }

            // Форматирование статуса активности
            if (e.Column.FieldName == "IsActive")
            {
                if (e.Value is bool isActive)
                {
                    e.DisplayText = isActive ? "Активен" : "Неактивен";
                    return;
                }
            }

            // Форматирование списка ролей
            if (e.Column.FieldName == "RolesList")
            {
                if (e.Value is string roles)
                {
                    e.DisplayText = roles;
                    return;
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки обновления данных
        /// </summary>
        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnRefreshData();
        }

        /// <summary>
        /// Обработчик кнопки создания пользователя
        /// </summary>
        private void btnCreate_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowCreateUserDialog();
        }

        /// <summary>
        /// Обработчик кнопки редактирования пользователя
        /// </summary>
        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser != null)
            {
                ShowEditUserDialog(selectedUser);
            }
        }

        /// <summary>
        /// Обработчик кнопки удаления пользователя
        /// </summary>
        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser != null)
            {
                if (XtraMessageBox.Show(
                    $"Вы уверены, что хотите удалить пользователя {selectedUser.Username}?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OnDeleteUser(selectedUser.Id);
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки изменения пароля
        /// </summary>
        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser != null)
            {
                ShowChangePasswordDialog(selectedUser);
            }
        }

        /// <summary>
        /// Получение выбранного пользователя
        /// </summary>
        private UserDto GetSelectedUser()
        {
            var selectedRows = gridViewUsers.GetSelectedRows();
            if (selectedRows.Length > 0)
            {
                return gridViewUsers.GetRow(selectedRows[0]) as UserDto;
            }
            return null;
        }

        /// <summary>
        /// Показывает диалог создания пользователя
        /// </summary>
        private void ShowCreateUserDialog()
        {
            using (var editForm = new UserEditForm(_roles))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    OnCreateUser(editForm.CreateRequest);
                }
            }
        }

        /// <summary>
        /// Показывает диалог редактирования пользователя
        /// </summary>
        private void ShowEditUserDialog(UserDto user)
        {
            using (var editForm = new UserEditForm(user, _roles))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    OnUpdateUser(editForm.UpdateRequest);
                }
            }
        }

        /// <summary>
        /// Показывает диалог изменения пароля
        /// </summary>
        private void ShowChangePasswordDialog(UserDto user)
        {
            using (var passwordForm = new PasswordChangeForm())
            {
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    var request = new ChangePasswordReq
                    {
                        UserId = user.Id.ToString(),
                        NewPassword = passwordForm.NewPassword
                    };
                    OnChangePassword(request);
                }
            }
        }

        /// <summary>
        /// Вызов события обновления данных
        /// </summary>
        private void OnRefreshData()
        {
            RefreshData?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Вызов события создания пользователя
        /// </summary>
        private void OnCreateUser(CreateUserReq request)
        {
            CreateUser?.Invoke(this, request);
        }

        /// <summary>
        /// Вызов события обновления пользователя
        /// </summary>
        private void OnUpdateUser(UpdateUserReq request)
        {
            UpdateUser?.Invoke(this, request);
        }

        /// <summary>
        /// Вызов события удаления пользователя
        /// </summary>
        private void OnDeleteUser(int userId)
        {
            DeleteUser?.Invoke(this, userId);
        }

        /// <summary>
        /// Вызов события изменения пароля
        /// </summary>
        private void OnChangePassword(ChangePasswordReq request)
        {
            ChangePassword?.Invoke(this, request);
        }

        #region IUserView

        /// <summary>
        /// Установка списка пользователей
        /// </summary>
        public void SetUsers(IEnumerable<UserDto> users)
        {
            // Выполняем в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<UserDto>>(SetUsers), users);
                return;
            }

            // Сохраняем полный список пользователей и обновляем грид
            _currentUsers = users;
            gridControlUsers.DataSource = users.ToList();

            // Настраиваем отображение таблицы
            gridViewUsers.OptionsView.RowAutoHeight = true;
            gridViewUsers.OptionsView.ColumnAutoWidth = true;
            gridViewUsers.BestFitColumns();
        }

        /// <summary>
        /// Установка списка ролей
        /// </summary>
        public void SetRoles(IEnumerable<RoleDto> roles)
        {
            // Выполняем в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<RoleDto>>(SetRoles), roles);
                return;
            }

            _roles = roles;
        }

        /// <summary>
        /// Отображение сообщения пользователю
        /// </summary>
        public void ShowMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowMessage), message);
                return;
            }

            XtraMessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        public void ShowError(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowError), message);
                return;
            }

            XtraMessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        /// <summary>
        /// Освобождение ресурсов при выгрузке контрола
        /// </summary>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            _presenter?.Dispose();
        }
    }
} 