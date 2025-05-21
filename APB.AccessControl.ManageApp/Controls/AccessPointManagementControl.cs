using APB.AccessControl.ManageApp.Presenters;
using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using DevExpress.DXperience.Demos;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Controls
{
    public partial class AccessPointManagementControl : TutorialControlBase, IAccessPointView
    {
        private AccessPointPresenter _presenter;

        public event EventHandler AddAccessPoint;
        public event EventHandler<int> EditAccessPoint;
        public event EventHandler<int> DeleteAccessPoint;
        public event EventHandler<int> ViewAccessPointRules;
        public event EventHandler<int> SendNotification;
        public event EventHandler RefreshData;

        public AccessPointManagementControl()
        {
            InitializeComponent();
            InitializeGridView();
            Name = "AccessPointManagementControl";

            _presenter = new AccessPointPresenter(this);
        }

        /// <summary>
        /// Инициализация настроек отображения таблицы
        /// </summary>
        private void InitializeGridView()
        {
            // Настройка внешнего вида таблицы
            gridViewAccessPoints.OptionsBehavior.Editable = false;
            gridViewAccessPoints.OptionsBehavior.ReadOnly = true;
            gridViewAccessPoints.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewAccessPoints.OptionsView.ShowGroupPanel = false;
            gridViewAccessPoints.OptionsView.ShowIndicator = false;
            gridViewAccessPoints.OptionsView.ColumnAutoWidth = true;
            
            // Настройка форматирования колонки IsOnline
            var textEditRepo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            gridControlAccessPoints.RepositoryItems.Add(textEditRepo);
            colIsOnline.ColumnEdit = textEditRepo;
            
            // Настройка обработчика отображения ячейки для колонки IsOnline
            gridViewAccessPoints.CustomColumnDisplayText += GridViewAccessPoints_CustomColumnDisplayText;
            
            // Настройка обработки событий таблицы
            // Сначала регистрируем стиль строки, затем стиль ячейки (порядок важен для приоритета)
            gridViewAccessPoints.RowStyle += GridViewAccessPoints_RowStyle;
            
            gridViewAccessPoints.FocusedRowChanged += GridViewAccessPoints_FocusedRowChanged;
            gridViewAccessPoints.DoubleClick += GridViewAccessPoints_DoubleClick;
        }

        /// <summary>
        /// Обработчик отображения текста ячеек
        /// </summary>
        private void GridViewAccessPoints_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IsOnline" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                try
                {
                    if (e.Value != null)
                    {
                        bool isOnline = Convert.ToBoolean(e.Value);
                        e.DisplayText = isOnline ? "В сети" : "Не в сети";
                    }
                }
                catch
                {
                    e.DisplayText = "Н/Д";
                }
            }
        }

        /// <summary>
        /// Обработчик стиля строки
        /// </summary>
        private void GridViewAccessPoints_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView view = sender as GridView;
                
                try
                {
                    bool isOnline = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "IsOnline"));
                    
                    if (isOnline)
                    {
                        // Для онлайн-точек окрашиваем строку в светло-зеленый
                        e.Appearance.BackColor = Color.LightGreen; // Очень светлый зеленый
                    }
                    else
                    {
                        // Для оффлайн-точек окрашиваем строку в светло-красный
                        e.Appearance.BackColor = Color.FromArgb(255,153,153); // Очень светлый красный
                    }
                }
                catch
                {
                    // Игнорируем ошибки при получении значения
                }
            }
        }


        /// <summary>
        /// Обработчик смены выбранной строки в таблице
        /// </summary>
        private void GridViewAccessPoints_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Обновляем состояние кнопок в зависимости от выбора
            bool hasSelection = e.FocusedRowHandle >= 0;

            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnSendNotification.Enabled = hasSelection;
        }

        /// <summary>
        /// Обработчик двойного клика по строке таблицы
        /// </summary>
        private void GridViewAccessPoints_DoubleClick(object sender, EventArgs e)
        {
            int accessPointId = GetSelectedAccessPointId();
            if (accessPointId > 0)
            {
                OnEditAccessPoint(accessPointId);
            }
        }

        /// <summary>
        /// Обработчик события добавления точки доступа
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddAccessPoint();
        }

        /// <summary>
        /// Обработчик события редактирования точки доступа
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int accessPointId = GetSelectedAccessPointId();
            if (accessPointId > 0)
            {
                OnEditAccessPoint(accessPointId);
            }
        }

        /// <summary>
        /// Обработчик события удаления точки доступа
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int accessPointId = GetSelectedAccessPointId();
            if (accessPointId > 0)
            {
                OnDeleteAccessPoint(accessPointId);
            }
        }

        /// <summary>
        /// Обработчик события просмотра правил точки доступа
        /// </summary>
        private void btnViewRules_Click(object sender, EventArgs e)
        {
            int accessPointId = GetSelectedAccessPointId();
            if (accessPointId > 0)
            {
                OnViewAccessPointRules(accessPointId);
            }
        }

        /// <summary>
        /// Обработчик события отправки уведомления
        /// </summary>
        private void btnSendNotification_Click(object sender, EventArgs e)
        {
            int accessPointId = GetSelectedAccessPointId();
            if (accessPointId > 0)
            {
                OnSendNotification(accessPointId);
            }
        }

        /// <summary>
        /// Обработчик события обновления данных
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshData();
        }

        /// <summary>
        /// Вызов события добавления
        /// </summary>
        private void OnAddAccessPoint()
        {
            AddAccessPoint?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Вызов события редактирования
        /// </summary>
        private void OnEditAccessPoint(int accessPointId)
        {
            EditAccessPoint?.Invoke(this, accessPointId);
        }

        /// <summary>
        /// Вызов события удаления
        /// </summary>
        private void OnDeleteAccessPoint(int accessPointId)
        {
            DeleteAccessPoint?.Invoke(this, accessPointId);
        }

        /// <summary>
        /// Вызов события просмотра правил
        /// </summary>
        private void OnViewAccessPointRules(int accessPointId)
        {
            ViewAccessPointRules?.Invoke(this, accessPointId);
        }

        /// <summary>
        /// Вызов события отправки уведомления
        /// </summary>
        private void OnSendNotification(int accessPointId)
        {
            SendNotification?.Invoke(this, accessPointId);
        }

        /// <summary>
        /// Вызов события обновления данных
        /// </summary>
        private void OnRefreshData()
        {
            RefreshData?.Invoke(this, EventArgs.Empty);
        }

        #region IAccessPointView

        /// <summary>
        /// Установка списка точек доступа в таблицу
        /// </summary>
        public void SetAccessPoints(IEnumerable<AccessPointDto> accessPoints)
        {
            // Выполняем в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<AccessPointDto>>(SetAccessPoints), accessPoints);
                return;
            }

            // Перед установкой источника данных отключаем обработчики для избежания лишних перерисовок
            gridViewAccessPoints.RowStyle -= GridViewAccessPoints_RowStyle;
            
            // Обновляем источник данных
            gridControlAccessPoints.DataSource = null;
            gridControlAccessPoints.DataSource = accessPoints;
            
            // Обновляем отображение
            gridViewAccessPoints.BestFitColumns();
            
            // Восстанавливаем обработчики событий
            gridViewAccessPoints.RowStyle += GridViewAccessPoints_RowStyle;
            
            // Принудительно обновляем представление
            gridViewAccessPoints.RefreshData();
        }

        /// <summary>
        /// Получение выбранного идентификатора точки доступа
        /// </summary>
        public int GetSelectedAccessPointId()
        {
            int rowHandle = gridViewAccessPoints.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                return Convert.ToInt32(gridViewAccessPoints.GetRowCellValue(rowHandle, "Id"));
            }
            return 0;
        }

        /// <summary>
        /// Очистка выбора в таблице
        /// </summary>
        public void ClearSelection()
        {
            gridViewAccessPoints.ClearSelection();
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