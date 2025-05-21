using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.DXperience.Demos;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using APB.AccessControl.Shared.Models.DTOs;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using APB.AccessControl.ManageApp.Presenters;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.ManageApp.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Controls
{
    /// <summary>
    /// Контрол для управления группами доступа
    /// </summary>
    public partial class AccessGroupManagementControl : TutorialControlBase, IAccessGroupView
    {
        private readonly AccessGroupPresenter _presenter;
        private AccessGroupDto _currentAccessGroup;
        private List<EmployeeDto> _employeesInGroup;
        private int? _lastSelectedAccessGroupId;

        #region События представления

        public event EventHandler<int> AccessGroupSelected;
        public event EventHandler<AccessGroupDto> CreateAccessGroup;
        public event EventHandler<AccessGroupDto> UpdateAccessGroup;
        public event EventHandler<int> DeleteAccessGroup;
        public event EventHandler<Tuple<int, int>> AddEmployeeToGroup;
        public event EventHandler<Tuple<int, int>> RemoveEmployeeFromGroup;

        #endregion

        public AccessGroupManagementControl()
        {
            InitializeComponent();
            Name = "AccessGroupManagementControl";

            // Создаем презентер и связываем с представлением
            _presenter = new AccessGroupPresenter(this);

            // Инициализируем обработчики событий
            InitializeEventHandlers();
        }

        #region Инициализация и загрузка

        private void ConfigureGridViews()
        {
            // Настраиваем автоматическую подгонку ширины колонок по содержимому
            gridViewAccessGroups.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewAccessGroups.OptionsView.ColumnAutoWidth = true;
            gridViewAccessGroups.BestFitColumns();
            if (gridViewAccessGroups.Columns["Id"] != null)
            {
                gridViewAccessGroups.Columns["Id"].Visible = false;
            }



            gridViewEmployeesInGroup.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewEmployeesInGroup.OptionsView.ColumnAutoWidth = true;
            gridViewEmployeesInGroup.BestFitColumns();
        }

        private void InitializeEventHandlers()
        {
            // Обработчики для списка групп доступа
            gridViewAccessGroups.FocusedRowChanged += GridViewAccessGroups_FocusedRowChanged;

            // Обработчики для кнопок RibbonControl
            barBtnAddAccessGroup.ItemClick += BarBtnAddAccessGroup_ItemClick;
            barBtnEditAccessGroup.ItemClick += BarBtnEditAccessGroup_ItemClick;
            barBtnDeleteAccessGroup.ItemClick += BarBtnDeleteAccessGroup_ItemClick;
            barBtnAddEmployeeToGroup.ItemClick += BarBtnAddEmployeeToGroup_ItemClick;
            barBtnRemoveEmployeeFromGroup.ItemClick += BarBtnRemoveEmployeeFromGroup_ItemClick;

            // Добавляем обработчик активации контрола
            this.ParentChanged += AccessGroupManagementControl_ParentChanged;
        }

        private void AccessGroupManagementControl_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                var form = FindForm();
                if (form != null)
                {
                    form.Activated += Form_Activated;
                    form.FormClosed += Form_FormClosed;
                }
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Отписываемся от событий при закрытии формы
            var form = sender as Form;
            if (form != null)
            {
                form.Activated -= Form_Activated;
                form.FormClosed -= Form_FormClosed;
            }
        }

        private async void Form_Activated(object sender, EventArgs e)
        {
            // Обновляем данные при активации формы
            await RefreshDataAsync();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Загружаем данные при открытии контрола
            LoadData();
        }

        /// <summary>
        /// Обновить все данные с сервера (список групп доступа и текущую группу)
        /// </summary>
        private async Task RefreshDataAsync()
        {
            try
            {
                this.SetBusy(true);

                // Загружаем актуальный список групп доступа
                await _presenter.LoadAccessGroupsAsync();

                // Если была выбрана группа доступа, восстанавливаем выбор
                if (_lastSelectedAccessGroupId.HasValue)
                {
                    // Находим группу в гриде по ID
                    int rowHandle = FindRowHandleById(_lastSelectedAccessGroupId.Value);
                    if (rowHandle >= 0)
                    {
                        // Выбираем строку без вызова события FocusedRowChanged
                        gridViewAccessGroups.FocusedRowChanged -= GridViewAccessGroups_FocusedRowChanged;
                        gridViewAccessGroups.FocusedRowHandle = rowHandle;
                        gridViewAccessGroups.FocusedRowChanged += GridViewAccessGroups_FocusedRowChanged;

                        // Загружаем данные группы
                        await _presenter.LoadAccessGroupByIdAsync(_lastSelectedAccessGroupId.Value);
                    }
                }

                // Настраиваем отображение колонок
                ConfigureGridViews();
            }
            catch (Exception ex)
            {
                this.ShowError($"Ошибка обновления данных: {ex.Message}");
            }
            finally
            {
                this.SetBusy(false);
            }
        }

        /// <summary>
        /// Найти индекс строки в гриде по ID группы доступа
        /// </summary>
        private int FindRowHandleById(int accessGroupId)
        {
            for (int i = 0; i < gridViewAccessGroups.RowCount; i++)
            {
                var accessGroup = gridViewAccessGroups.GetRow(i) as AccessGroupDto;
                if (accessGroup != null && accessGroup.Id == accessGroupId)
                {
                    return i;
                }
            }
            return -1;
        }

        private async void LoadData()
        {
            // Загружаем список групп доступа
            await _presenter.LoadAccessGroupsAsync();
            // Настраиваем отображение колонок
            ConfigureGridViews();
        }

        #endregion

        #region Обработчики событий UI

        private void GridViewAccessGroups_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                var accessGroup = gridViewAccessGroups.GetRow(e.FocusedRowHandle) as AccessGroupDto;
                if (accessGroup != null)
                {
                    // Сохраняем ID выбранной группы доступа
                    _lastSelectedAccessGroupId = accessGroup.Id;

                    // Вызываем событие выбора группы доступа
                    AccessGroupSelected?.Invoke(this, accessGroup.Id);
                }
            }
        }

        private void BarBtnAddAccessGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Открываем форму для создания новой группы доступа
            using (var accessGroupForm = new AccessGroupEditForm())
            {
                if (accessGroupForm.ShowDialog() == DialogResult.OK)
                {
                    // Вызываем событие создания группы доступа
                    CreateAccessGroup?.Invoke(this, accessGroupForm.AccessGroup);
                }
            }
        }

        private void BarBtnEditAccessGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentAccessGroup != null)
            {
                // Открываем форму для редактирования выбранной группы доступа
                using (var accessGroupForm = new AccessGroupEditForm(_currentAccessGroup))
                {
                    if (accessGroupForm.ShowDialog() == DialogResult.OK)
                    {
                        // Вызываем событие обновления данных группы доступа
                        UpdateAccessGroup?.Invoke(this, accessGroupForm.AccessGroup);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите группу доступа для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BarBtnDeleteAccessGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentAccessGroup != null)
            {
                if (XtraMessageBox.Show($"Вы действительно хотите удалить группу доступа {_currentAccessGroup.Name}?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Вызываем событие удаления группы доступа
                    DeleteAccessGroup?.Invoke(this, _currentAccessGroup.Id);
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите группу доступа для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BarBtnAddEmployeeToGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentAccessGroup != null)
            {
                try
                {
                    var allEmployees = await _presenter.GetAllEmployees();
                    using (var form = new EmployeeAccessGroupForm(
                        _currentAccessGroup.Name,
                        allEmployees,
                        _employeesInGroup))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            var selectedEmployees = form.SelectedEmployees;
                            var addedEmployees = selectedEmployees.Except(_employeesInGroup).ToList();
                            var removedEmployees = _employeesInGroup.Except(selectedEmployees).ToList();

                            // Добавляем новых сотрудников
                            foreach (var employee in addedEmployees)
                            {
                                AddEmployeeToGroup?.Invoke(this, Tuple.Create(employee.Id, _currentAccessGroup.Id));
                            }

                            // Удаляем исключенных сотрудников
                            foreach (var employee in removedEmployees)
                            {
                                RemoveEmployeeFromGroup?.Invoke(this, Tuple.Create(employee.Id, _currentAccessGroup.Id));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Ошибка при управлении сотрудниками в группе: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите группу доступа для добавления сотрудника", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BarBtnRemoveEmployeeFromGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentAccessGroup != null && gridViewEmployeesInGroup.FocusedRowHandle >= 0)
            {
                var employee = gridViewEmployeesInGroup.GetRow(gridViewEmployeesInGroup.FocusedRowHandle) as EmployeeDto;
                if (employee != null)
                {
                    if (XtraMessageBox.Show($"Вы действительно хотите удалить сотрудника {employee.LastName} {employee.FirstName} из группы доступа?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Вызываем событие удаления сотрудника из группы
                        RemoveEmployeeFromGroup?.Invoke(this, Tuple.Create(employee.Id, _currentAccessGroup.Id));
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите сотрудника для удаления из группы доступа", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Методы интерфейса IAccessGroupView

        public void UpdateAccessGroupList(IEnumerable<AccessGroupDto> accessGroups)
        {
            gridControlAccessGroups.DataSource = accessGroups.ToList();
            gridViewAccessGroups.BestFitColumns();
        }

        public void ShowAccessGroupDetails(AccessGroupDto accessGroup)
        {
            _currentAccessGroup = accessGroup;

            lblGroupName.Text = accessGroup.Name;
            chkIsActive.Checked = accessGroup.IsActive;
        }

        public void ShowEmployeesInGroup(IEnumerable<EmployeeDto> employees)
        {
            _employeesInGroup = employees.ToList();
            gridControlEmployeesInGroup.DataSource = _employeesInGroup;
            gridViewEmployeesInGroup.BestFitColumns();

            if (gridViewEmployeesInGroup.Columns["Photo"] != null)
            {
                gridViewEmployeesInGroup.Columns["Photo"].Visible = false;
            }
            if (gridViewEmployeesInGroup.Columns["Id"] != null)
            {
                gridViewEmployeesInGroup.Columns["Id"].Visible = false;
            }
        }

        public void ShowError(string message)
        {
            XtraMessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfo(string message)
        {
            XtraMessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetBusy(bool isBusy)
        {
            if (isBusy)
            {
                Cursor = Cursors.WaitCursor;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        public void ClearForm()
        {
            _currentAccessGroup = null;
            _lastSelectedAccessGroupId = null;
            _employeesInGroup = new List<EmployeeDto>();
            gridControlEmployeesInGroup.DataSource = _employeesInGroup;
            lblGroupName.Text = "Группа не выбрана";
            chkIsActive.Checked = false;
        }

        #endregion

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            // Отписываемся от событий
            gridViewAccessGroups.FocusedRowChanged -= GridViewAccessGroups_FocusedRowChanged;
            barBtnAddAccessGroup.ItemClick -= BarBtnAddAccessGroup_ItemClick;
            barBtnEditAccessGroup.ItemClick -= BarBtnEditAccessGroup_ItemClick;
            barBtnDeleteAccessGroup.ItemClick -= BarBtnDeleteAccessGroup_ItemClick;
            barBtnAddEmployeeToGroup.ItemClick -= BarBtnAddEmployeeToGroup_ItemClick;
            barBtnRemoveEmployeeFromGroup.ItemClick -= BarBtnRemoveEmployeeFromGroup_ItemClick;

            // Отписываемся от события родительского изменения
            this.ParentChanged -= AccessGroupManagementControl_ParentChanged;
        }
    }
} 