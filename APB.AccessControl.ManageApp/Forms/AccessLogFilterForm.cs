using APB.AccessControl.Shared.Models.DTOs;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Forms
{
    /// <summary>
    /// Форма для выбора параметров фильтрации логов доступа
    /// </summary>
    public partial class AccessLogFilterForm : XtraForm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SelectedEmployeeId { get; set; }
        public int SelectedAccessPointId { get; set; }
        
        private IEnumerable<EmployeeDto> _employees;
        private IEnumerable<AccessPointDto> _accessPoints;
        
        public AccessLogFilterForm()
        {
            InitializeComponent();
            
            // Установка даты по умолчанию
            StartDate = DateTime.Now.AddDays(-7);
            EndDate = DateTime.Now;
            
            // Инициализация контролов
            dateStart.DateTime = StartDate;
            dateEnd.DateTime = EndDate;
        }
        
        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void AccessLogFilterForm_Load(object sender, EventArgs e)
        {
            // Настраиваем внешний вид формы
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            
            // Если есть данные для выпадающих списков - заполняем их
            InitializeDropDowns();
        }
        
        /// <summary>
        /// Инициализация выпадающих списков
        /// </summary>
        private void InitializeDropDowns()
        {
            // Заполняем список сотрудников
            if (_employees != null && _employees.Any())
            {
                lookUpEmployees.Properties.DataSource = _employees.ToList();
                lookUpEmployees.Properties.DisplayMember = "LastName";
                lookUpEmployees.Properties.ValueMember = "Id";
                lookUpEmployees.Properties.NullText = "-- Все сотрудники --";
                
                // Настройка отображения колонок в выпадающем списке
                lookUpEmployees.Properties.Columns.Clear();
                lookUpEmployees.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "ID") { Visible = false });
                lookUpEmployees.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LastName", "Фамилия"));
                lookUpAccessPoints.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FirstName", "Имя"));
                lookUpAccessPoints.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PatronymicName", "Отчество"));


                if (SelectedEmployeeId > 0)
                {
                    lookUpEmployees.EditValue = SelectedEmployeeId;
                }
            }
            
            // Заполняем список точек доступа
            if (_accessPoints != null && _accessPoints.Any())
            {
                lookUpAccessPoints.Properties.DataSource = _accessPoints.ToList();
                lookUpAccessPoints.Properties.DisplayMember = "Name";
                lookUpAccessPoints.Properties.ValueMember = "Id";
                lookUpAccessPoints.Properties.NullText = "-- Все точки доступа --";
                
                // Настройка отображения колонок в выпадающем списке
                lookUpAccessPoints.Properties.Columns.Clear();
                lookUpAccessPoints.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "ID") { Visible = false });
                lookUpAccessPoints.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Точка доступа") { Width = 200 });
                
                if (SelectedAccessPointId > 0)
                {
                    lookUpAccessPoints.EditValue = SelectedAccessPointId;
                }
            }
        }
        
        /// <summary>
        /// Установка списка сотрудников для фильтрации
        /// </summary>
        public void SetEmployees(IEnumerable<EmployeeDto> employees)
        {
            _employees = employees;
        }
        
        /// <summary>
        /// Установка списка точек доступа для фильтрации
        /// </summary>
        public void SetAccessPoints(IEnumerable<AccessPointDto> accessPoints)
        {
            _accessPoints = accessPoints;
        }
        
        /// <summary>
        /// Обработчик кнопки применения фильтра
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            // Проверяем валидность дат
            if (dateStart.DateTime > dateEnd.DateTime)
            {
                XtraMessageBox.Show("Дата начала не может быть позже даты окончания",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Сохраняем значения в свойства формы
            StartDate = dateStart.DateTime.Date;
            EndDate = dateEnd.DateTime.Date.AddDays(1).AddSeconds(-1); // До конца дня
            
            // Сохраняем выбранные значения из выпадающих списков
            SelectedEmployeeId = lookUpEmployees.EditValue != null ? 
                Convert.ToInt32(lookUpEmployees.EditValue) : 0;
                
            SelectedAccessPointId = lookUpAccessPoints.EditValue != null ? 
                Convert.ToInt32(lookUpAccessPoints.EditValue) : 0;
            
            DialogResult = DialogResult.OK;
            Close();
        }
        
        /// <summary>
        /// Обработчик кнопки сброса фильтра
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Сбрасываем фильтры на значения по умолчанию
            dateStart.DateTime = DateTime.Now.AddDays(-7);
            dateEnd.DateTime = DateTime.Now;
            lookUpEmployees.EditValue = null;
            lookUpAccessPoints.EditValue = null;
        }
        
        /// <summary>
        /// Обработчик кнопки отмены
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 