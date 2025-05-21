using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.DXperience.Demos;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using APB.AccessControl.Shared.Models.DTOs;
using System.Linq;
using System.IO;
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
    /// Контрол для управления сотрудниками
    /// </summary>
    public partial class EmployeeManagementControl : TutorialControlBase, IEmployeeView
    {
        private readonly EmployeePresenter _presenter;
        private EmployeeDto _currentEmployee;
        private List<CardDto> _employeeCards;
        private int? _lastSelectedEmployeeId;

        #region События представления

        public event EventHandler<int> EmployeeSelected;
        public event EventHandler<EmployeeDto> CreateEmployee;
        public event EventHandler<EmployeeDto> UpdateEmployee;
        public event EventHandler<int> DeleteEmployee;
        public event EventHandler<int> AssignCardToEmployee;
        public event EventHandler<int> DeleteCardFromEmployee;
        public event EventHandler<int> ActivateCard;
        public event EventHandler<int> DeactivateCard;
        public event EventHandler<CardReadEventArgs> CardInfoReceived;

        #endregion

        public EmployeeManagementControl()
        {
            InitializeComponent();
            Name = "EmployeeManagementControl";

            // Создаем презентер и связываем с представлением
            _presenter = new EmployeePresenter(this);

            // Инициализируем обработчики событий
            InitializeEventHandlers();
        }

        #region Инициализация и загрузка

        private void ConfigureGridView()
        {
            // Скрываем колонку Photo
            if (gridViewEmployees.Columns["Photo"] != null)
            {
                gridViewEmployees.Columns["Photo"].Visible = false;
            }
            if (gridViewEmployees.Columns["Id"] != null)
            {
                gridViewEmployees.Columns["Id"].Visible = false;
            }


            // Настраиваем автоматическую подгонку ширины колонок по содержимому
            gridViewEmployees.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewEmployees.OptionsView.ColumnAutoWidth = true;
            gridViewEmployees.BestFitColumns();
        }

        private void InitializeEventHandlers()
        {
            // Обработчики для списка сотрудников
            gridViewEmployees.FocusedRowChanged += GridViewEmployees_FocusedRowChanged;

            // Обработчики для кнопок RibbonControl
            barBtnAddEmployee.ItemClick += BarBtnAddEmployee_ItemClick;
            barBtnEditEmployee.ItemClick += BarBtnEditEmployee_ItemClick;
            barBtnDeleteEmployee.ItemClick += BarBtnDeleteEmployee_ItemClick;
            barBtnAssignCard.ItemClick += BarBtnAssignCard_ItemClick;
            barBtnDeleteCard.ItemClick += BarBtnDeleteCard_ItemClick;
            barBtnActivateCard.ItemClick += BarBtnActivateCard_ItemClick;
            barBtnDeactivateCard.ItemClick += BarBtnDeactivateCard_ItemClick;

            // Добавляем обработчик активации контрола
            this.ParentChanged += EmployeeManagementControl_ParentChanged;
            
            // Добавляем обработчик выбора карты
            gridViewCards.FocusedRowChanged += GridViewCards_FocusedRowChanged;
        }

        private void EmployeeManagementControl_ParentChanged(object sender, EventArgs e)
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
        /// Обновить все данные с сервера (список сотрудников и текущего сотрудника)
        /// </summary>
        private async Task RefreshDataAsync()
        {
            try
            {
                this.SetBusy(true);

                // Загружаем актуальный список сотрудников
                await _presenter.LoadEmployeesAsync();

                // Если был выбран сотрудник, восстанавливаем выбор
                if (_lastSelectedEmployeeId.HasValue)
                {
                    // Находим сотрудника в гриде по ID
                    int rowHandle = FindRowHandleById(_lastSelectedEmployeeId.Value);
                    if (rowHandle >= 0)
                    {
                        // Выбираем строку без вызова события FocusedRowChanged
                        gridViewEmployees.FocusedRowChanged -= GridViewEmployees_FocusedRowChanged;
                        gridViewEmployees.FocusedRowHandle = rowHandle;
                        gridViewEmployees.FocusedRowChanged += GridViewEmployees_FocusedRowChanged;

                        // Загружаем данные сотрудника
                        await _presenter.LoadEmployeeByIdAsync(_lastSelectedEmployeeId.Value);
                    }
                }

                // Настраиваем отображение колонок
                ConfigureGridView();
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
        /// Найти индекс строки в гриде по ID сотрудника
        /// </summary>
        private int FindRowHandleById(int employeeId)
        {
            for (int i = 0; i < gridViewEmployees.RowCount; i++)
            {
                var employee = gridViewEmployees.GetRow(i) as EmployeeDto;
                if (employee != null && employee.Id == employeeId)
                {
                    return i;
                }
            }
            return -1;
        }

        private async void LoadData()
        {
            // Загружаем список сотрудников
            await _presenter.LoadEmployeesAsync();
            // Настраиваем отображение колонок
            ConfigureGridView();
        }

        #endregion

        #region Обработчики событий UI

        private void GridViewEmployees_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                var employee = gridViewEmployees.GetRow(e.FocusedRowHandle) as EmployeeDto;
                if (employee != null)
                {
                    // Сохраняем ID выбранного сотрудника
                    _lastSelectedEmployeeId = employee.Id;

                    // Вызываем событие выбора сотрудника
                    EmployeeSelected?.Invoke(this, employee.Id);
                }
            }
        }

        private void BarBtnAddEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Открываем форму для создания нового сотрудника
            using (var employeeForm = new EmployeeEditForm())
            {
                if (employeeForm.ShowDialog() == DialogResult.OK)
                {
                    // Вызываем событие создания сотрудника
                    CreateEmployee?.Invoke(this, employeeForm.Employee);
                }
            }
        }

        private async void BarBtnEditEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentEmployee != null)
            {
                // Открываем форму для редактирования выбранного сотрудника
                using (var employeeForm = new EmployeeEditForm(_currentEmployee))
                {
                    if (employeeForm.ShowDialog() == DialogResult.OK)
                    {
                        // Вызываем событие обновления данных сотрудника
                        UpdateEmployee?.Invoke(this, employeeForm.Employee);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите сотрудника для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BarBtnDeleteEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentEmployee != null)
            {
                if (XtraMessageBox.Show($"Вы действительно хотите удалить сотрудника {_currentEmployee.LastName} {_currentEmployee.FirstName}?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Вызываем событие удаления сотрудника
                    DeleteEmployee?.Invoke(this, _currentEmployee.Id);
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите сотрудника для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BarBtnAssignCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentEmployee != null)
            {
                // Вызываем событие привязки карты к сотруднику
                AssignCardToEmployee?.Invoke(this, _currentEmployee.Id);

                // Открываем форму для считывания карты
                using (var cardReaderForm = new CardReaderForm())
                {
                    if (cardReaderForm.ShowDialog() == DialogResult.OK && cardReaderForm.CardReadEventArgs != null)
                    {
                        // Передаем информацию о карте в презентер
                        CardInfoReceived?.Invoke(this, cardReaderForm.CardReadEventArgs);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите сотрудника для привязки карты", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BarBtnDeleteCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewCards.FocusedRowHandle >= 0)
            {
                var card = gridViewCards.GetRow(gridViewCards.FocusedRowHandle) as CardDto;
                if (card != null)
                {
                    if (XtraMessageBox.Show("Вы действительно хотите удалить эту карту?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Вызываем событие удаления карты
                        DeleteCardFromEmployee?.Invoke(this, card.Id);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите карту для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GridViewCards_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateCardButtonsState();
        }

        private void UpdateCardButtonsState()
        {
            // Проверяем, выбрана ли карта
            if (gridViewCards.FocusedRowHandle >= 0)
            {
                var card = gridViewCards.GetRow(gridViewCards.FocusedRowHandle) as CardDto;
                if (card != null)
                {
                    // Активируем/деактивируем кнопки в зависимости от статуса карты
                    barBtnActivateCard.Enabled = !card.IsActive;
                    barBtnDeactivateCard.Enabled = card.IsActive;
                    barBtnDeleteCard.Enabled = true;
                    return;
                }
            }
            
            // Если карта не выбрана, деактивируем все кнопки
            barBtnActivateCard.Enabled = false;
            barBtnDeactivateCard.Enabled = false;
            barBtnDeleteCard.Enabled = false;
        }

        private void BarBtnActivateCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewCards.FocusedRowHandle >= 0)
            {
                var card = gridViewCards.GetRow(gridViewCards.FocusedRowHandle) as CardDto;
                if (card != null)
                {
                    if (XtraMessageBox.Show("Вы действительно хотите активировать эту карту?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Вызываем событие активации карты
                        ActivateCard?.Invoke(this, card.Id);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите карту для активации", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BarBtnDeactivateCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewCards.FocusedRowHandle >= 0)
            {
                var card = gridViewCards.GetRow(gridViewCards.FocusedRowHandle) as CardDto;
                if (card != null)
                {
                    if (XtraMessageBox.Show("Вы действительно хотите деактивировать эту карту?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Вызываем событие деактивации карты
                        DeactivateCard?.Invoke(this, card.Id);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Выберите карту для деактивации", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Методы интерфейса IEmployeeView

        public void UpdateEmployeeList(IEnumerable<EmployeeDto> employees)
        {
            gridControlEmployees.DataSource = employees.ToList();
            gridViewEmployees.BestFitColumns();
        }

        public void ShowEmployeeDetails(EmployeeDto employee)
        {
            _currentEmployee = employee;

            lblPosition.Text = employee.Position ?? string.Empty;
            lblDepartment.Text = employee.Department ?? string.Empty;
            lblPassportNumber.Text = employee.PassportNumber ?? string.Empty;
            chkIsActive.Checked = employee.IsActive;

            // Устанавливаем фото сотрудника, если есть
            if (!string.IsNullOrEmpty(employee.Photo))
            {
                try
                {
                    byte[] imageBytes = Convert.FromBase64String(employee.Photo);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pictureEditPhoto.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                catch
                {
                    pictureEditPhoto.Image = null;
                }
            }
            else
            {
                pictureEditPhoto.Image = null;
            }

            lblEmployeeTitle.Text = $"{employee.LastName} {employee.FirstName} {employee.PatronymicName}";
        }

        public void ShowEmployeeCards(IEnumerable<CardDto> cards)
        {
            _employeeCards = cards.ToList();
            gridControlCards.DataSource = _employeeCards;
            
            // Скрываем колонку EmployeeId
            if (gridViewCards.Columns["EmployeeId"] != null)
            {
                gridViewCards.Columns["EmployeeId"].Visible = false;
            }
            
            gridViewCards.BestFitColumns();
            if (gridViewCards.Columns["Id"] != null)
            {
                gridViewCards.Columns["Id"].Visible = false;
            }

            // Обновляем состояние кнопок управления картами
            UpdateCardButtonsState();
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
            _currentEmployee = null;
            _lastSelectedEmployeeId = null;
            _employeeCards = new List<CardDto>();
            gridControlCards.DataSource = _employeeCards;
            lblEmployeeTitle.Text = "Сотрудник не выбран";

            lblPosition.Text = string.Empty;
            lblDepartment.Text = string.Empty;
            lblPassportNumber.Text = string.Empty;
            chkIsActive.Checked = true;
            pictureEditPhoto.Image = null;
        }

        #endregion

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            // Отписываемся от событий
            gridViewEmployees.FocusedRowChanged -= GridViewEmployees_FocusedRowChanged;
            gridViewCards.FocusedRowChanged -= GridViewCards_FocusedRowChanged;
            barBtnAddEmployee.ItemClick -= BarBtnAddEmployee_ItemClick;
            barBtnEditEmployee.ItemClick -= BarBtnEditEmployee_ItemClick;
            barBtnDeleteEmployee.ItemClick -= BarBtnDeleteEmployee_ItemClick;
            barBtnAssignCard.ItemClick -= BarBtnAssignCard_ItemClick;
            barBtnDeleteCard.ItemClick -= BarBtnDeleteCard_ItemClick;
            barBtnActivateCard.ItemClick -= BarBtnActivateCard_ItemClick;
            barBtnDeactivateCard.ItemClick -= BarBtnDeactivateCard_ItemClick;

            // Отписываемся от события родительского изменения
            this.ParentChanged -= EmployeeManagementControl_ParentChanged;
        }
    }
} 