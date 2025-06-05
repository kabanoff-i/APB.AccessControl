using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Forms
{
    public partial class NotificationEditForm : XtraForm
    {
        private readonly NotificationService _notificationService;
        private readonly NotificationDto _notification;
        private readonly EmployeeService _employeeService;
        private readonly AccessPointService _accessPointService;
        private List<EmployeeDto> _employees;
        private List<AccessPointDto> _accessPoints;

        public NotificationEditForm(NotificationService notificationService, NotificationDto notification = null)
        {
            InitializeComponent();
            _notificationService = notificationService;
            _notification = notification ?? new NotificationDto();
            _employeeService = new EmployeeService();
            _accessPointService = new AccessPointService();

            // Инициализация формы
            EditNotificationForm_Load(this, EventArgs.Empty);
        }

        /// <summary>
        /// Инициализация формы при загрузке
        /// </summary>
        private void EditNotificationForm_Load(object sender, EventArgs e)
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
            // Настройка выпадающего списка сотрудников
            lookUpEmployee.Properties.DataSource = _employees;
            lookUpEmployee.Properties.DisplayMember = "LastName";
            lookUpEmployee.Properties.ValueMember = "Id";
            lookUpEmployee.Properties.ShowHeader = true;
            lookUpEmployee.Properties.Columns.Clear();
            lookUpEmployee.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LastName", "Фамилия", 120));
            lookUpEmployee.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FirstName", "Имя", 100));
            lookUpEmployee.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PatronymicName", "Отчество", 120));
            lookUpEmployee.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Department", "Отдел", 150));
            lookUpEmployee.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Position", "Должность", 150));

            // Настройка выпадающего списка точек доступа
            lookUpAccessPoint.Properties.DataSource = _accessPoints;
            lookUpAccessPoint.Properties.DisplayMember = "Name";
            lookUpAccessPoint.Properties.ValueMember = "Id";
            lookUpAccessPoint.Properties.ShowHeader = true;
            lookUpAccessPoint.Properties.Columns.Clear();
            lookUpAccessPoint.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Название", 200));
            lookUpAccessPoint.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Location", "Локация", 200));

            // Изначально скрываем выбор сотрудника
            lookUpEmployee.Visible = false;
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        /// <summary>
        /// Загрузка данных в элементы управления
        /// </summary>
        private async void LoadDataToControls()
        {
            // Загрузка списка сотрудников
            _employees = (await _employeeService.GetAllEmployeesAsync()).Where(x => x.IsActive == true).ToList();
            lookUpEmployee.Properties.DataSource = _employees;

            // Загрузка списка точек доступа
            _accessPoints = (await _accessPointService.GetAllAsync()).Where(x => x.IsActive == true).ToList();
            lookUpAccessPoint.Properties.DataSource = _accessPoints;

            // Если это редактирование, заполняем поля
            if (_notification.Id != 0)
            {
                txtMessage.Text = _notification.Message;
                dateExpiration.DateTime = _notification.ExpirationDate ?? DateTime.Now;
                chkShowOnPass.Checked = _notification.ShowOnPass;
                
                if (_notification.EmployeeId.HasValue)
                {
                    lookUpEmployee.EditValue = _notification.EmployeeId;
                }

                if (_notification.AccessPointId != 0)
                {
                    lookUpAccessPoint.EditValue = _notification.AccessPointId;
                }
            }
            else
            {
                // Для нового уведомления устанавливаем дату истечения на конец текущего дня
                dateExpiration.DateTime = DateTime.Today.AddDays(1).AddSeconds(-1);

                // Если есть предварительно выбранная точка доступа, устанавливаем её
                if (_notification.AccessPointId != 0)
                {
                    lookUpAccessPoint.EditValue = _notification.AccessPointId;
                }
            }
        }

        private void chkShowOnPass_CheckedChanged(object sender, EventArgs e)
        {
            // Показываем/скрываем выбор сотрудника в зависимости от состояния чекбокса
            lookUpEmployee.Visible = chkShowOnPass.Checked;
            layoutControlItem4.Visibility = chkShowOnPass.Checked 
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always 
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация
                if (string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    XtraMessageBox.Show("Введите сообщение", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lookUpAccessPoint.EditValue == null)
                {
                    XtraMessageBox.Show("Выберите точку доступа", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (chkShowOnPass.Checked && lookUpEmployee.EditValue == null)
                {
                    XtraMessageBox.Show("Выберите сотрудника", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Заполняем модель
                _notification.Message = txtMessage.Text;
                _notification.ExpirationDate = dateExpiration.DateTime;
                _notification.ShowOnPass = chkShowOnPass.Checked;
                _notification.EmployeeId = chkShowOnPass.Checked ? (int?)lookUpEmployee.EditValue : null;
                _notification.AccessPointId = (int)lookUpAccessPoint.EditValue;

                // Сохраняем
                if (_notification.Id == 0)
                {
                    var request = new CreateNotificationReq
                    {
                        Message = _notification.Message,
                        ShowOnPass = _notification.ShowOnPass,
                        ExpirationDate = _notification.ExpirationDate,
                        EmployeeId = _notification.EmployeeId,
                        AccessPointId = _notification.AccessPointId
                    };
                    await _notificationService.CreateAsync(request);
                }
                else
                {
                    var request = new UpdateNotificationReq
                    {
                        Id = _notification.Id,
                        Message = _notification.Message,
                        ShowOnPass = _notification.ShowOnPass,
                        ExpirationDate = _notification.ExpirationDate,
                        EmployeeId = _notification.EmployeeId,
                        AccessPointId = _notification.AccessPointId
                    };
                    await _notificationService.UpdateAsync(request);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 