using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Forms
{
    public partial class AccessRuleEditForm : XtraForm
    {
        // Результат формы - запрос на создание или обновление правила
        public CreateAccessRuleReq CreateRequest { get; private set; }
        public UpdateAccessRuleReq UpdateRequest { get; private set; }
        
        // Режим формы (создание или редактирование)
        private bool _isEditMode;
        
        // Коллекции для выпадающих списков
        private IEnumerable<AccessGroupDto> _accessGroups;
        private IEnumerable<AccessPointDto> _accessPoints;
        
        // Исходные данные правила при редактировании
        private AccessRuleDto _originalRule;
        
        // Коллекция для работы со специальными датами
        private List<DateTime> _specificDates = new List<DateTime>();
        
        /// <summary>
        /// Конструктор формы для режима создания нового правила
        /// </summary>
        public AccessRuleEditForm(IEnumerable<AccessGroupDto> accessGroups, 
            IEnumerable<AccessPointDto> accessPoints)
        {
            InitializeComponent();
            
            _isEditMode = false;
            _accessGroups = accessGroups;
            _accessPoints = accessPoints;
            
            // Создаем новый запрос с значениями по умолчанию
            CreateRequest = new CreateAccessRuleReq
            {
                AllowedTimeStart = new TimeSpan(8, 0, 0),
                AllowedTimeEnd = new TimeSpan(18, 0, 0),
                DaysOfWeek = new bool[7] { true, true, true, true, true, true, true }, // Все дни недели по умолчанию
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddYears(1)
            };
            
            Text = "Создание правила доступа";
        }
        
        /// <summary>
        /// Конструктор формы для режима редактирования
        /// </summary>
        public AccessRuleEditForm(AccessRuleDto rule, 
            IEnumerable<AccessGroupDto> accessGroups, 
            IEnumerable<AccessPointDto> accessPoints)
        {
            InitializeComponent();
            
            _isEditMode = true;
            _originalRule = rule;
            _accessGroups = accessGroups;
            _accessPoints = accessPoints;
            
            // Создаем запрос редактирования на основе существующего правила
            UpdateRequest = new UpdateAccessRuleReq
            {
                Id = rule.Id,
                AccessGroupId = rule.AccessGroupId,
                AccessPointId = rule.AccessPointId,
                AllowedTimeStart = rule.AllowedTimeStart,
                AllowedTimeEnd = rule.AllowedTimeEnd,
                DaysOfWeek = rule.DaysOfWeek,
                SpecificDates = rule.SpecificDates,
                StartDate = rule.StartDate,
                EndDate = rule.EndDate,
                IsActive = rule.IsActive
            };
            
            // Распарсить специальные даты, если они есть
            if (!string.IsNullOrEmpty(rule.SpecificDates))
            {
                try
                {
                    _specificDates = JsonSerializer.Deserialize<List<DateTime>>(rule.SpecificDates);
                }
                catch
                {
                    // Если не удалось десериализовать, создаем пустой список
                    _specificDates = new List<DateTime>();
                }
            }
            
            Text = $"Редактирование правила доступа {rule.AccessPointName} - {rule.AccessGroupName}";
        }
      
        /// <summary>
        /// Инициализация формы при загрузке
        /// </summary>
        private void EditAccessRuleForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls();
                LoadDataToControls();
                RefreshSpecificDatesPanel();
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
            // Настройка комбобоксов
            lookUpAccessGroup.Properties.DataSource = _accessGroups;
            lookUpAccessGroup.Properties.DisplayMember = "Name";
            lookUpAccessGroup.Properties.ValueMember = "Id";
            lookUpAccessGroup.Properties.PopulateColumns();
            lookUpAccessGroup.Properties.ShowHeader = true;
            
            // Скрываем колонку с Id
            if (lookUpAccessGroup.Properties.Columns.Count > 0)
            {
                lookUpAccessGroup.Properties.Columns["Id"].Visible = false;
                // Устанавливаем ширину колонки Name
                if (lookUpAccessGroup.Properties.Columns["Name"] != null)
                {
                    lookUpAccessGroup.Properties.Columns["Name"].Caption = "Название группы";
                    lookUpAccessGroup.Properties.Columns["Name"].Width = 250;
                }
            }
            
            lookUpAccessPoint.Properties.DataSource = _accessPoints;
            lookUpAccessPoint.Properties.DisplayMember = "Name";
            lookUpAccessPoint.Properties.ValueMember = "Id";
            lookUpAccessPoint.Properties.PopulateColumns();
            lookUpAccessPoint.Properties.ShowHeader = true;
            
            // Скрываем колонку с Id
            if (lookUpAccessPoint.Properties.Columns.Count > 0)
            {
                lookUpAccessPoint.Properties.Columns["Id"].Visible = false;
                // Устанавливаем ширину колонки Name
                if (lookUpAccessPoint.Properties.Columns["Name"] != null)
                {
                    lookUpAccessPoint.Properties.Columns["Name"].Caption = "Название точки";
                    lookUpAccessPoint.Properties.Columns["Name"].Width = 250;
                }
            }
            
            // Настройка чекбоксов дней недели
            checkEditMonday.Tag = 0;
            checkEditTuesday.Tag = 1;
            checkEditWednesday.Tag = 2;
            checkEditThursday.Tag = 3;
            checkEditFriday.Tag = 4;
            checkEditSaturday.Tag = 5;
            checkEditSunday.Tag = 6;
            
            // Настройка выбора времени
            timeEditStart.Time = DateTime.Today.Add(_isEditMode 
                ? UpdateRequest.AllowedTimeStart 
                : CreateRequest.AllowedTimeStart);
                
            timeEditEnd.Time = DateTime.Today.Add(_isEditMode 
                ? UpdateRequest.AllowedTimeEnd 
                : CreateRequest.AllowedTimeEnd);
            
            // Настройка выбора дат
            dateEditStart.DateTime = _isEditMode 
                ? UpdateRequest.StartDate 
                : CreateRequest.StartDate;
                
            dateEditEnd.DateTime = _isEditMode 
                ? UpdateRequest.EndDate 
                : CreateRequest.EndDate;
            
            // Активность правила (только для режима редактирования)
            checkEditActive.Checked = _isEditMode ? UpdateRequest.IsActive : true;
        }
        
        /// <summary>
        /// Загрузка данных в элементы управления
        /// </summary>
        private void LoadDataToControls()
        {
            if (_isEditMode)
            {
                // Заполняем элементы управления данными существующего правила
                lookUpAccessGroup.EditValue = UpdateRequest.AccessGroupId;
                lookUpAccessPoint.EditValue = UpdateRequest.AccessPointId;
                
                // Отмечаем дни недели
                SetDaysOfWeekCheckboxes(UpdateRequest.DaysOfWeek);
            }
            else
            {
                // Проставляем все дни недели по умолчанию
                SetDaysOfWeekCheckboxes(CreateRequest.DaysOfWeek);
            }
        }
        
        /// <summary>
        /// Установка чекбоксов дней недели
        /// </summary>
        private void SetDaysOfWeekCheckboxes(bool[] daysOfWeek)
        {
            // Проверяем, что массив имеет достаточную длину
            if (daysOfWeek == null || daysOfWeek.Length < 7)
            {
                // Устанавливаем все дни в false
                checkEditMonday.Checked = false;
                checkEditTuesday.Checked = false;
                checkEditWednesday.Checked = false;
                checkEditThursday.Checked = false;
                checkEditFriday.Checked = false;
                checkEditSaturday.Checked = false;
                checkEditSunday.Checked = false;
                return;
            }
            
            // Задаем состояние чекбоксов на основе массива
            checkEditMonday.Checked = daysOfWeek[0];
            checkEditTuesday.Checked = daysOfWeek[1];
            checkEditWednesday.Checked = daysOfWeek[2];
            checkEditThursday.Checked = daysOfWeek[3];
            checkEditFriday.Checked = daysOfWeek[4];
            checkEditSaturday.Checked = daysOfWeek[5];
            checkEditSunday.Checked = daysOfWeek[6];
        }
        
        /// <summary>
        /// Получение массива дней недели из чекбоксов
        /// </summary>
        private bool[] GetDaysOfWeekFromCheckboxes()
        {
            return new bool[7]
            {
                checkEditMonday.Checked,
                checkEditTuesday.Checked,
                checkEditWednesday.Checked,
                checkEditThursday.Checked,
                checkEditFriday.Checked,
                checkEditSaturday.Checked,
                checkEditSunday.Checked
            };
        }
        
        /// <summary>
        /// Добавление специальной даты
        /// </summary>
        private void btnAddSpecificDate_Click(object sender, EventArgs e)
        {
            // Получаем выбранную дату из календаря
            DateTime selectedDate = specificDateCalendar.DateTime.Date;
            
            // Проверяем, не добавлена ли уже эта дата
            if (!_specificDates.Contains(selectedDate))
            {
                _specificDates.Add(selectedDate);
                RefreshSpecificDatesPanel();
            }
        }
        
        /// <summary>
        /// Очистка списка специальных дат
        /// </summary>
        private void btnClearSpecificDates_Click(object sender, EventArgs e)
        {
            _specificDates.Clear();
            RefreshSpecificDatesPanel();
        }
        
        /// <summary>
        /// Обновление панели со специальными датами
        /// </summary>
        private void RefreshSpecificDatesPanel()
        {
            // Очищаем панель
            flowPanelSpecificDates.Controls.Clear();
            
            // Сортируем даты
            _specificDates.Sort();
            
            // Добавляем плашки с датами
            foreach (var date in _specificDates)
            {
                // Создаем панель для даты в виде плашки
                var datePanel = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightBlue,
                    Margin = new Padding(3),
                    Size = new Size(180, 50)
                };
                
                // Добавляем метку с датой
                var dateLabel = new Label
                {
                    Text = date.ToString("d MMMM yyyy"),
                    Dock = DockStyle.Left,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = false,
                    Width = 130,
                    Padding = new Padding(5, 0, 0, 0)
                };
                datePanel.Controls.Add(dateLabel);
                
                // Добавляем кнопку для удаления даты
                var btnRemove = new Button
                {
                    Text = "×",
                    Dock = DockStyle.Right,
                    FlatStyle = FlatStyle.Flat,
                    Width = 30,
                    Tag = date,
                    Cursor = Cursors.Hand
                };
                btnRemove.FlatAppearance.BorderSize = 0;
                btnRemove.Click += (s, e) => RemoveSpecificDate((DateTime)((Button)s).Tag);
                datePanel.Controls.Add(btnRemove);
                
                // Добавляем панель на форму
                flowPanelSpecificDates.Controls.Add(datePanel);
            }
            
            // Обновляем скрытое поле с JSON строкой специальных дат
            memoEditSpecialDates.Text = _specificDates.Count > 0 
                ? JsonSerializer.Serialize(_specificDates) 
                : "[]";
        }
        
        /// <summary>
        /// Удаление специальной даты
        /// </summary>
        private void RemoveSpecificDate(DateTime date)
        {
            _specificDates.Remove(date);
            RefreshSpecificDatesPanel();
        }
        
        /// <summary>
        /// Проверка корректности введенных данных
        /// </summary>
        private bool ValidateInput()
        {
            // Проверка выбора группы доступа
            if (lookUpAccessGroup.EditValue == null)
            {
                XtraMessageBox.Show("Необходимо выбрать группу доступа", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Проверка выбора точки доступа
            if (lookUpAccessPoint.EditValue == null)
            {
                XtraMessageBox.Show("Необходимо выбрать точку доступа", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Проверка выбора хотя бы одного дня недели
            bool anyDaySelected = checkEditMonday.Checked || checkEditTuesday.Checked || 
                checkEditWednesday.Checked || checkEditThursday.Checked || 
                checkEditFriday.Checked || checkEditSaturday.Checked || checkEditSunday.Checked;
                
            if (!anyDaySelected)
            {
                XtraMessageBox.Show("Необходимо выбрать хотя бы один день недели", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Проверка временного диапазона
            if (timeEditStart.Time >= timeEditEnd.Time)
            {
                XtraMessageBox.Show("Время начала должно быть меньше времени окончания", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Проверка диапазона дат
            if (dateEditStart.DateTime > dateEditEnd.DateTime)
            {
                XtraMessageBox.Show("Дата начала не может быть позже даты окончания", 
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
            // Получаем данные из элементов управления
            int accessGroupId = Convert.ToInt32(lookUpAccessGroup.EditValue);
            int accessPointId = Convert.ToInt32(lookUpAccessPoint.EditValue);
            TimeSpan timeStart = timeEditStart.Time.TimeOfDay;
            TimeSpan timeEnd = timeEditEnd.Time.TimeOfDay;
            bool[] daysOfWeek = GetDaysOfWeekFromCheckboxes();
            string specialDates = memoEditSpecialDates.Text;
            DateTime startDate = dateEditStart.DateTime.Date;
            DateTime endDate = dateEditEnd.DateTime.Date;
            bool isActive = checkEditActive.Checked;
            
            if (_isEditMode)
            {
                // Обновляем запрос редактирования
                UpdateRequest.AccessGroupId = accessGroupId;
                UpdateRequest.AccessPointId = accessPointId;
                UpdateRequest.AllowedTimeStart = timeStart;
                UpdateRequest.AllowedTimeEnd = timeEnd;
                UpdateRequest.DaysOfWeek = daysOfWeek;
                UpdateRequest.SpecificDates = specialDates;
                UpdateRequest.StartDate = startDate;
                UpdateRequest.EndDate = endDate;
                UpdateRequest.IsActive = isActive;
            }
            else
            {
                // Обновляем запрос создания
                CreateRequest.AccessGroupId = accessGroupId;
                CreateRequest.AccessPointId = accessPointId;
                CreateRequest.AllowedTimeStart = timeStart;
                CreateRequest.AllowedTimeEnd = timeEnd;
                CreateRequest.DaysOfWeek = daysOfWeek;
                CreateRequest.SpecificDates = specialDates;
                CreateRequest.StartDate = startDate;
                CreateRequest.EndDate = endDate;
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
        
        /// <summary>
        /// Выбор всех дней недели
        /// </summary>
        private void btnSelectAllDays_Click(object sender, EventArgs e)
        {
            checkEditMonday.Checked = true;
            checkEditTuesday.Checked = true;
            checkEditWednesday.Checked = true;
            checkEditThursday.Checked = true;
            checkEditFriday.Checked = true;
            checkEditSaturday.Checked = true;
            checkEditSunday.Checked = true;
        }
        
        /// <summary>
        /// Выбор только рабочих дней
        /// </summary>
        private void btnSelectWorkDays_Click(object sender, EventArgs e)
        {
            checkEditMonday.Checked = true;
            checkEditTuesday.Checked = true;
            checkEditWednesday.Checked = true;
            checkEditThursday.Checked = true;
            checkEditFriday.Checked = true;
            checkEditSaturday.Checked = false;
            checkEditSunday.Checked = false;
        }
        
        /// <summary>
        /// Сброс выбора дней недели
        /// </summary>
        private void btnClearDays_Click(object sender, EventArgs e)
        {
            checkEditMonday.Checked = false;
            checkEditTuesday.Checked = false;
            checkEditWednesday.Checked = false;
            checkEditThursday.Checked = false;
            checkEditFriday.Checked = false;
            checkEditSaturday.Checked = false;
            checkEditSunday.Checked = false;
        }
    }
} 