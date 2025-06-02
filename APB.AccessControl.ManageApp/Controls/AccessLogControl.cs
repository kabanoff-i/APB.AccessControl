using APB.AccessControl.ManageApp.Presenters;
using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Forms;
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
using DevExpress.XtraBars;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Controls
{
    /// <summary>
    /// Контрол для просмотра логов прохода
    /// </summary>
    public partial class AccessLogControl : TutorialControlBase, IAccessLogView
    {
        private AccessLogPresenter _presenter;
        private IEnumerable<AccessLogDto> _currentLogs;
        private IEnumerable<EmployeeDto> _employees;
        private IEnumerable<AccessPointDto> _accessPoints;
        
        private DateTime _startDate = DateTime.Now.AddDays(-7);
        private DateTime _endDate = DateTime.Now;
        private int _selectedEmployeeId = 0;
        private int _selectedAccessPointId = 0;
        
        public event EventHandler RefreshData;
        public event EventHandler<LogFilterOptions> FilterLogs;
        
        public AccessLogControl()
        {
            InitializeComponent();
            InitializeGridView();
            Name = "AccessLogControl";
            
            // Создаем сервисы для работы с API
            var accessLogService = new AccessLogService();
            var employeeService = new EmployeeService();
            var accessPointService = new AccessPointService();
            
            _presenter = new AccessLogPresenter(
                this,
                accessLogService,
                employeeService,
                accessPointService);
            
            btnExport.ItemClick += btnExport_Click;
        }
        
        /// <summary>
        /// Инициализация представления после загрузки
        /// </summary>
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            try 
            {
                // Загружаем только справочники
                await _presenter.LoadReferenceDataAsync();
                
                // Запрос параметров фильтрации
                ShowFilterDialog();
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при загрузке справочников: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Инициализация настроек отображения таблицы
        /// </summary>
        private void InitializeGridView()
        {
            // Настройка внешнего вида таблицы логов
            gridViewLogs.OptionsBehavior.Editable = false;
            gridViewLogs.OptionsBehavior.ReadOnly = true;
            gridViewLogs.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewLogs.OptionsView.ShowGroupPanel = false;
            gridViewLogs.OptionsView.ShowIndicator = false;
            gridViewLogs.OptionsView.ColumnAutoWidth = false;
            gridViewLogs.OptionsView.RowAutoHeight = true;

            // Устанавливаем начальный DataSource
            gridControlLogs.DataSource = new List<AccessLogDto>();

            // Настройка цветов строк таблицы
            gridViewLogs.Appearance.Row.BackColor = Color.White;
            gridViewLogs.Appearance.Row.Options.UseBackColor = true;
            
            // Настройка обработчиков форматирования данных
            gridViewLogs.CustomColumnDisplayText += GridViewLogs_CustomColumnDisplayText;
            gridControlLogs.DataSourceChanged += GridControlLogs_DataSourceChanged;
            gridViewLogs.RowStyle += GridViewLogs_RowStyle;
        }
        
        private void GridControlLogs_DataSourceChanged(object sender, EventArgs e)
        {
            // Скрываем ненужные колонки
            var columnsToHide = new[] { "Id", "EmployeeId", "AccessPointId", "CardId" };
            foreach (var columnName in columnsToHide)
            {
                if (gridViewLogs.Columns[columnName] != null)
                {
                    gridViewLogs.Columns[columnName].Visible = false;
                }
            }
        }
        
        /// <summary>
        /// Обработчик стиля строки
        /// </summary>
        private void GridViewLogs_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView view = sender as GridView;
                
                try
                {
                    int accessResult = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "AccessResult"));
                    
                    if (accessResult == 1)
                    {
                        // Для успешных проходов окрашиваем строку в светло-зеленый
                        e.Appearance.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        // Для отказов окрашиваем строку в светло-красный
                        e.Appearance.BackColor = Color.FromArgb(255, 153, 153);
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
        private void GridViewLogs_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                // Для колонок с сотрудником и картой показываем "Не определено"
                if (e.Column.FieldName == "EmployeeFullName" || e.Column.FieldName == "MaskPan")
                {
                    e.DisplayText = "Не определено";
                }
                return;
            }
                
            // Форматирование отображения времени
            if (e.Column.FieldName == "DateAccess" && e.Value is DateTime timeValue)
            {
                e.DisplayText = timeValue.ToString("dd.MM.yyyy HH:mm:ss");
                return;
            }
            
            // Форматирование статуса прохода
            if (e.Column.FieldName == "AccessResult")
            {
                if (e.Value is int accessResult)
                {
                    e.DisplayText = accessResult == 1 ? "Успешно" : "Отказано";
                    return;
                }
                
                if (e.Value is string statusText)
                {
                    if (statusText.Equals("1") || 
                        statusText.Equals("True", StringComparison.OrdinalIgnoreCase) || 
                        statusText.Equals("Success", StringComparison.OrdinalIgnoreCase))
                    {
                        e.DisplayText = "Успешно";
                    }
                    else
                    {
                        e.DisplayText = "Отказано";
                    }
                }
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
        /// Обработчик кнопки фильтрации
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            ShowFilterDialog();
        }
        
        /// <summary>
        /// Вызов события обновления данных
        /// </summary>
        private void OnRefreshData()
        {
            RefreshData?.Invoke(this, EventArgs.Empty);
        }
        
        /// <summary>
        /// Показывает диалог с параметрами фильтрации
        /// </summary>
        private void ShowFilterDialog()
        {
            using (var filterForm = new AccessLogFilterForm())
            {
                // Передаем параметры фильтра в форму
                filterForm.StartDate = _startDate;
                filterForm.EndDate = _endDate;
                filterForm.SelectedEmployeeId = _selectedEmployeeId;
                filterForm.SelectedAccessPointId = _selectedAccessPointId;
                
                // Передаем справочники
                if (_employees != null)
                {
                    filterForm.SetEmployees(_employees);
                }
                
                if (_accessPoints != null)
                {
                    filterForm.SetAccessPoints(_accessPoints);
                }
                
                // Показываем диалог и получаем параметры фильтра
                if (filterForm.ShowDialog() == DialogResult.OK)
                {
                    // Сохраняем новые значения фильтра
                    _startDate = filterForm.StartDate;
                    _endDate = filterForm.EndDate;
                    _selectedEmployeeId = filterForm.SelectedEmployeeId;
                    _selectedAccessPointId = filterForm.SelectedAccessPointId;
                    
                    // Вызываем фильтрацию данных
                    OnFilterLogs();
                }
            }
        }
        
        /// <summary>
        /// Вызов события фильтрации логов
        /// </summary>
        private void OnFilterLogs()
        {
            var filterOptions = new LogFilterOptions
            {
                StartDate = _startDate,
                EndDate = _endDate,
                EmployeeId = _selectedEmployeeId,
                AccessPointId = _selectedAccessPointId
            };
            
            FilterLogs?.Invoke(this, filterOptions);
        }
        
        /// <summary>
        /// Обработчик кнопки экспорта в Excel
        /// </summary>
        private void btnExport_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Проверяем наличие данных для экспорта
                if (_currentLogs == null || !_currentLogs.Any())
                {
                    ShowMessage("Нет данных для экспорта");
                    return;
                }

                // Создаем диалог сохранения файла
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Экспорт в Excel";
                    saveDialog.FileName = $"Логи доступа {DateTime.Now:yyyy-MM-dd}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Экспортируем данные в Excel
                        gridControlLogs.ExportToXlsx(saveDialog.FileName);
                        ShowMessage("Экспорт успешно завершен");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при экспорте в Excel: {ex.Message}");
            }
        }
        
        #region IAccessLogView
        
        /// <summary>
        /// Установка списка логов доступа в таблицу
        /// </summary>
        public void SetAccessLogs(IEnumerable<AccessLogDto> logs)
        {
            // Выполняем в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<AccessLogDto>>(SetAccessLogs), logs);
                return;
            }
            
            // Сохраняем полный список логов и обновляем грид
            _currentLogs = logs;
            gridControlLogs.DataSource = logs.ToList();
            
            // Настраиваем отображение таблицы
            gridViewLogs.OptionsView.RowAutoHeight = true;
            gridViewLogs.OptionsView.ColumnAutoWidth = true;
            gridViewLogs.BestFitColumns();
            
            // Обновляем статус количества записей
            UpdateStatusInfo();
        }
        
        /// <summary>
        /// Установка списка сотрудников для фильтрации
        /// </summary>
        public void SetEmployees(IEnumerable<EmployeeDto> employees)
        {
            // Выполняем в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<EmployeeDto>>(SetEmployees), employees);
                return;
            }
            
            _employees = employees;
        }
        
        /// <summary>
        /// Установка списка точек доступа для фильтрации
        /// </summary>
        public void SetAccessPoints(IEnumerable<AccessPointDto> accessPoints)
        {
            // Выполняем в потоке UI
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<AccessPointDto>>(SetAccessPoints), accessPoints);
                return;
            }
            
            _accessPoints = accessPoints;
        }
        
        /// <summary>
        /// Обновление статуса количества записей
        /// </summary>
        private void UpdateStatusInfo()
        {
            if (_currentLogs != null)
            {
                int totalCount = _currentLogs.Count();
                // Используем AccessResult = 1 как признак успешного прохода
                int successCount = _currentLogs.Count(l => l.AccessResult == 1);
                
                string statusInfo = $"Всего записей: {totalCount}, Успешных: {successCount}, Отказов: {totalCount - successCount}";
                lblStatus.Text = statusInfo;
            }
            else
            {
                lblStatus.Text = "Нет данных";
            }
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