using APB.AccessControl.ManageApp.Presenters;
using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using DevExpress.DXperience.Demos;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Controls
{
    public partial class AccessRuleManagementControl : TutorialControlBase, IAccessRuleView
    {
        private AccessRulePresenter _presenter;
        private IEnumerable<AccessRuleDto> _currentRules;
        private IEnumerable<AccessGroupDto> _accessGroups;
        private IEnumerable<AccessPointDto> _accessPoints;
        
        // Репозитории для отображения значений
        private RepositoryItemMemoEdit _specificDatesRepository;
        private RepositoryItemMemoEdit _daysOfWeekRepository;

        public event EventHandler CreateRule;
        public event EventHandler<int> EditRule;
        public event EventHandler<int> DeleteRule;
        public event EventHandler<int> CopyRule;
        public event EventHandler RefreshData;

        public AccessRuleManagementControl()
        {
            InitializeComponent();
            InitializeGridView();
            Name = "EmployeeAccessRuleControl";

            // Создаем сервисы для работы с API
            var apiService = new ApiService();
            var accessRuleService = new AccessRuleService(apiService);
            
            // Для сервисов групп и точек доступа создаем экземпляры без параметров
            // т.к. они сами создают экземпляр ApiService внутри
            var accessGroupService = new AccessGroupService();
            var accessPointService = new AccessPointService();

            _presenter = new AccessRulePresenter(
                this, 
                accessRuleService, 
                accessGroupService, 
                accessPointService);
        }

        /// <summary>
        /// Инициализация представления после загрузки
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            // Асинхронная инициализация презентера
            _ = _presenter.InitializeAsync();
        }

        /// <summary>
        /// Инициализация настроек отображения таблицы
        /// </summary>
        private void InitializeGridView()
        {
            // Настройка внешнего вида таблицы правил доступа
            gridViewRules.OptionsBehavior.Editable = false;
            gridViewRules.OptionsBehavior.ReadOnly = true;
            gridViewRules.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewRules.OptionsView.ShowGroupPanel = false;
            gridViewRules.OptionsView.ShowIndicator = false;
            gridViewRules.OptionsView.ColumnAutoWidth = false;
            gridViewRules.OptionsView.RowAutoHeight = true;
            
            // Настройка цветов строк таблицы
            gridViewRules.Appearance.Row.BackColor = Color.White;
            gridViewRules.Appearance.Row.BackColor2 = Color.FromArgb(245, 245, 245);
            gridViewRules.Appearance.Row.Options.UseBackColor = true;
            
            // Настройка обработки событий таблицы
            gridViewRules.FocusedRowChanged += GridViewRules_FocusedRowChanged;
            gridViewRules.DoubleClick += GridViewRules_DoubleClick;
            
            // Настройка репозиториев для особых колонок
            InitializeRepositories();
            
            // Скрытие лишних колонок и переименование существующих
            gridViewRules.Columns["Id"].Visible = false;
            
            // Автоматическая подгонка ширины колонок под содержимое при загрузке
            gridViewRules.OptionsView.ShowAutoFilterRow = false;
            gridViewRules.OptionsView.ColumnAutoWidth = true;
            gridViewRules.BestFitColumns();
        }
        
        /// <summary>
        /// Инициализация репозиториев для отображения специальных колонок
        /// </summary>
        private void InitializeRepositories()
        {
            // Репозиторий для дней недели
            _daysOfWeekRepository = new RepositoryItemMemoEdit();
            _daysOfWeekRepository.ReadOnly = true;
            _daysOfWeekRepository.WordWrap = true;
            _daysOfWeekRepository.ScrollBars = ScrollBars.None;
            _daysOfWeekRepository.AutoHeight = true;
            
            // Репозиторий для специальных дат
            _specificDatesRepository = new RepositoryItemMemoEdit();
            _specificDatesRepository.ReadOnly = true;
            _specificDatesRepository.WordWrap = true;
            _specificDatesRepository.ScrollBars = ScrollBars.Vertical;
            _specificDatesRepository.AutoHeight = true;
            
            // Назначение репозиториев колонкам
            gridControlRules.RepositoryItems.Add(_daysOfWeekRepository);
            gridControlRules.RepositoryItems.Add(_specificDatesRepository);
            
            colDaysOfWeek.ColumnEdit = _daysOfWeekRepository;
            colSpecificDates.ColumnEdit = _specificDatesRepository;
            
            // Настройка обработчиков форматирования данных
            gridViewRules.CustomColumnDisplayText += GridViewRules_CustomColumnDisplayText;
        }
        
        /// <summary>
        /// Обработчик для форматирования данных в колонках
        /// </summary>
        private void GridViewRules_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null)
                return;
                
            // Форматирование отображения дней недели
            if (e.Column == colDaysOfWeek)
            {
                // Обработка для bool[] (новый формат данных DaysOfWeek)
                if (e.Value is bool[] boolDays)
                {
                    string[] dayNames = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
                    List<string> selectedDays = new List<string>();
                    
                    for (int i = 0; i < boolDays.Length && i < 7; i++)
                    {
                        if (boolDays[i])
                        {
                            selectedDays.Add(dayNames[i]);
                        }
                    }
                    
                    e.DisplayText = string.Join(", ", selectedDays);
                    return;
                }
                
                // Обработка для строкового формата (старый формат данных)
                string daysText = e.Value.ToString();
                if (!string.IsNullOrEmpty(daysText))
                {
                    // Преобразуем текстовое представление в формате "0,1,5,6" в читаемый вид
                    string[] dayNames = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
                    string[] dayNumbers = daysText.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    List<string> selectedDays = new List<string>();
                    foreach (string dayNumber in dayNumbers)
                    {
                        if (int.TryParse(dayNumber.Trim(), out int index) && index >= 0 && index < 7)
                        {
                            selectedDays.Add(dayNames[index]);
                        }
                    }
                    
                    e.DisplayText = string.Join(", ", selectedDays);
                }
            }
            
            // Форматирование отображения специальных дат
            else if (e.Column == colSpecificDates)
            {
                // Обработка для массива DateTime[] (формат массива дат)
                if (e.Value is DateTime[] dateTimes)
                {
                    List<string> formattedDates = new List<string>();
                    foreach (var date in dateTimes)
                    {
                        formattedDates.Add(date.Date.ToString("dd.MM.yyyy"));
                    }
                    e.DisplayText = string.Join("\r\n", formattedDates);
                    return;
                }
                
                // Обработка для строкового формата 
                string datesText = e.Value.ToString();
                if (!string.IsNullOrEmpty(datesText))
                {
                    // Преобразуем строковое представление дат в более читаемый вид
                    string[] dates = datesText.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> formattedDates = new List<string>();
                    
                    foreach (string dateStr in dates)
                    {
                        if (DateTime.TryParse(dateStr.Trim(), out DateTime date))
                        {
                            formattedDates.Add(date.Date.ToString("dd.MM.yyyy"));
                        }
                        else
                        {
                            formattedDates.Add(dateStr.Trim());
                        }
                    }
                    
                    e.DisplayText = string.Join("\r\n", formattedDates);
                }
            }
        }

        /// <summary>
        /// Обработчик смены выбранной строки в таблице
        /// </summary>
        private void GridViewRules_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Обновляем состояние кнопок в зависимости от выбора
            bool hasSelection = e.FocusedRowHandle >= 0;

            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnCopy.Enabled = hasSelection;
        }

        /// <summary>
        /// Обработчик двойного клика по строке таблицы
        /// </summary>
        private void GridViewRules_DoubleClick(object sender, EventArgs e)
        {
            int ruleId = GetSelectedRuleId();
            if (ruleId > 0)
            {
                OnEditRule(ruleId);
            }
        }

        /// <summary>
        /// Обработчик кнопки создания правила
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnCreateRule();
        }

        /// <summary>
        /// Обработчик кнопки редактирования правила
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ruleId = GetSelectedRuleId();
            if (ruleId > 0)
            {
                OnEditRule(ruleId);
            }
        }

        /// <summary>
        /// Обработчик кнопки удаления правила
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ruleId = GetSelectedRuleId();
            if (ruleId > 0)
            {
                OnDeleteRule(ruleId);
            }
        }

        /// <summary>
        /// Обработчик кнопки копирования правила
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            int ruleId = GetSelectedRuleId();
            if (ruleId > 0)
            {
                OnCopyRule(ruleId);
            }
        }

        /// <summary>
        /// Обработчик кнопки обновления данных
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshData();
        }

        /// <summary>
        /// Вызов события создания правила
        /// </summary>
        private void OnCreateRule()
        {
            CreateRule?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Вызов события редактирования правила
        /// </summary>
        private void OnEditRule(int ruleId)
        {
            EditRule?.Invoke(this, ruleId);
        }

        /// <summary>
        /// Вызов события удаления правила
        /// </summary>
        private void OnDeleteRule(int ruleId)
        {
            DeleteRule?.Invoke(this, ruleId);
        }

        /// <summary>
        /// Вызов события копирования правила
        /// </summary>
        private void OnCopyRule(int ruleId)
        {
            CopyRule?.Invoke(this, ruleId);
        }

        /// <summary>
        /// Вызов события обновления данных
        /// </summary>
        private void OnRefreshData()
        {
            RefreshData?.Invoke(this, EventArgs.Empty);
        }

        #region IEmployeeAccessRuleView

        /// <summary>
        /// Установка списка правил доступа в таблицу
        /// </summary>
        public void SetAccessRules(IEnumerable<AccessRuleDto> rules)
        {
            // Выполняем в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<AccessRuleDto>>(SetAccessRules), rules);
                return;
            }

            // Сохраняем полный список правил и обновляем грид
            _currentRules = rules;
            gridControlRules.DataSource = rules.ToList();
            
            // Настраиваем отображение таблицы
            gridViewRules.OptionsView.RowAutoHeight = true;
            gridViewRules.BestFitColumns();
        }

        /// <summary>
        /// Установка списка групп доступа
        /// </summary>
        public void SetAccessGroups(IEnumerable<AccessGroupDto> groups)
        {
            // Выполняем в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<AccessGroupDto>>(SetAccessGroups), groups);
                return;
            }
            
            _accessGroups = groups;
        }

        /// <summary>
        /// Установка списка точек доступа
        /// </summary>
        public void SetAccessPoints(IEnumerable<AccessPointDto> points)
        {
            // Выполняем в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<AccessPointDto>>(SetAccessPoints), points);
                return;
            }
            
            _accessPoints = points;
        }

        /// <summary>
        /// Получение выбранного идентификатора правила доступа
        /// </summary>
        public int GetSelectedRuleId()
        {
            int rowHandle = gridViewRules.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                return Convert.ToInt32(gridViewRules.GetRowCellValue(rowHandle, "Id"));
            }
            return 0;
        }

        /// <summary>
        /// Очистка выбора в таблице
        /// </summary>
        public void ClearSelection()
        {
            gridViewRules.ClearSelection();
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