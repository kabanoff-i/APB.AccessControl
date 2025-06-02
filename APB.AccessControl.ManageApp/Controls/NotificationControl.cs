using APB.AccessControl.ManageApp.Forms;
using APB.AccessControl.ManageApp.Presenters;
using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using DevExpress.DXperience.Demos;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Controls
{
    /// <summary>
    /// Контрол для управления уведомлениями
    /// </summary>
    public partial class NotificationControl : TutorialControlBase, INotificationView
    {
        private NotificationPresenter _presenter;
        private IEnumerable<NotificationDto> _currentNotifications;

        public NotificationControl()
        {
            InitializeComponent();
            InitializeGridView();
            Name = "NotificationControl";

            // Создаем сервис для работы с API
            var notificationService = new NotificationService();

            // Создаем презентер
            _presenter = new NotificationPresenter(this, notificationService);
        }

        /// <summary>
        /// Инициализация представления после загрузки
        /// </summary>
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                await _presenter.LoadNotificationsAsync();
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при загрузке уведомлений: {ex.Message}");
            }
        }

        /// <summary>
        /// Инициализация настроек отображения таблицы
        /// </summary>
        private void InitializeGridView()
        {
            // Настройка внешнего вида таблицы
            gridViewNotifications.OptionsBehavior.Editable = false;
            gridViewNotifications.OptionsBehavior.ReadOnly = true;
            gridViewNotifications.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewNotifications.OptionsView.ShowGroupPanel = false;
            gridViewNotifications.OptionsView.ShowIndicator = false;
            gridViewNotifications.OptionsView.ColumnAutoWidth = true;
            gridViewNotifications.OptionsView.RowAutoHeight = true;
            gridViewNotifications.BestFitColumns();

            // Устанавливаем начальный DataSource
            gridControlNotifications.DataSource = new List<NotificationDto>();

            // Настройка обработчиков форматирования данных
            gridViewNotifications.CustomColumnDisplayText += GridViewNotifications_CustomColumnDisplayText;
            gridControlNotifications.DataSourceChanged += GridControlNotifications_DataSourceChanged;

            // Настройка обработчиков событий таблицы
            gridViewNotifications.FocusedRowChanged += GridViewNotifications_FocusedRowChanged;
        }

        /// <summary>
        /// Обработчик смены выбранной строки в таблице
        /// </summary>
        private void GridViewNotifications_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Обновляем состояние кнопок в зависимости от выбора
            bool hasSelection = e.FocusedRowHandle >= 0;

            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void GridControlNotifications_DataSourceChanged(object sender, EventArgs e)
        {
            // Скрываем все колонки, содержащие "Id" в названии
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridViewNotifications.Columns)
            {
                if (column.FieldName.Contains("Id"))
                {
                    column.Visible = false;
                }
            }
        }

        /// <summary>
        /// Обработчик для форматирования данных в колонках
        /// </summary>
        private void GridViewNotifications_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }

            // Форматирование отображения дат
            if ((e.Column.FieldName == "StartDate" || e.Column.FieldName == "EndDate") && e.Value is DateTime dateValue)
            {
                e.DisplayText = dateValue.ToString("dd.MM.yyyy HH:mm:ss");
                return;
            }

            // Форматирование флага ShowOnPass
            if (e.Column.FieldName == "ShowOnPass")
            {
                if (e.Value is bool showOnPass)
                {
                    e.DisplayText = showOnPass ? "Да" : "Нет";
                    return;
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки добавления
        /// </summary>
        private async void btnAdd_Click(object sender, ItemClickEventArgs e)
        {
            using (var form = new NotificationEditForm(_presenter.NotificationService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await _presenter.LoadNotificationsAsync();
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки редактирования
        /// </summary>
        private async void btnEdit_Click(object sender, ItemClickEventArgs e)
        {
            var selectedNotification = GetSelectedNotification();
            if (selectedNotification == null)
            {
                ShowMessage("Выберите уведомление для редактирования");
                return;
            }

            using (var form = new NotificationEditForm(_presenter.NotificationService, selectedNotification))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await _presenter.LoadNotificationsAsync();
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки удаления
        /// </summary>
        private async void btnDelete_Click(object sender, ItemClickEventArgs e)
        {
            var selectedNotification = GetSelectedNotification();
            if (selectedNotification == null)
            {
                ShowMessage("Выберите уведомление для удаления");
                return;
            }

            if (XtraMessageBox.Show(
                "Вы уверены, что хотите удалить выбранное уведомление?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _presenter.DeleteNotificationAsync(selectedNotification.Id);
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка при удалении уведомления: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки обновления
        /// </summary>
        private async void btnRefresh_Click(object sender, ItemClickEventArgs e)
        {
            await _presenter.LoadNotificationsAsync();
        }

        /// <summary>
        /// Получение выбранного уведомления
        /// </summary>
        private NotificationDto GetSelectedNotification()
        {
            var selectedRows = gridViewNotifications.GetSelectedRows();
            if (selectedRows.Length == 0)
            {
                return null;
            }

            return gridViewNotifications.GetRow(selectedRows[0]) as NotificationDto;
        }

        #region INotificationView

        /// <summary>
        /// Установка списка уведомлений
        /// </summary>
        public void SetNotifications(IEnumerable<NotificationDto> notifications)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<NotificationDto>>(SetNotifications), notifications);
                return;
            }

            _currentNotifications = notifications;
            gridControlNotifications.DataSource = notifications.ToList();
            gridViewNotifications.OptionsView.ColumnAutoWidth = true;
            gridViewNotifications.BestFitColumns();
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