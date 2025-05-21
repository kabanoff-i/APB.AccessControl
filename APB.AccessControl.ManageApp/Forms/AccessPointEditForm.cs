using APB.AccessControl.Shared.Models.DTOs;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Forms
{
    public partial class AccessPointEditForm : XtraForm
    {
        /// <summary>
        /// Данные точки доступа
        /// </summary>
        public AccessPointDto AccessPointData { get; private set; }

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="accessPoint">Точка доступа для редактирования (null для создания новой)</param>
        /// <param name="accessPointTypes">Список типов точек доступа</param>
        public AccessPointEditForm(AccessPointDto accessPoint, IEnumerable<AccessPointTypeDto> accessPointTypes)
        {
            InitializeComponent();

            // Заполняем комбобокс с типами точек доступа
            comboBoxType.Properties.DisplayMember = "Name";
            comboBoxType.Properties.ValueMember = "Id";
            comboBoxType.Properties.DataSource = accessPointTypes;

            // Если передана точка доступа, заполняем поля формы
            if (accessPoint != null)
            {
                Text = "Редактирование точки доступа";
                textBoxName.Text = accessPoint.Name;
                textBoxLocation.Text = accessPoint.Location;
                textBoxIpAddress.Text = accessPoint.IpAddress;
                comboBoxType.EditValue = accessPoint.AccessPointTypeId;
                checkBoxIsActive.Checked = accessPoint.IsActive;
                
                // Статус онлайн только для отображения
                labelOnlineStatus.Text = accessPoint.IsOnline ? "Онлайн" : "Оффлайн";
                labelLastHeartbeat.Text = accessPoint.LastHeartbeatAt.HasValue 
                    ? accessPoint.LastHeartbeatAt.Value.ToString() 
                    : "Нет данных";
            }
            else
            {
                Text = "Добавление точки доступа";
                checkBoxIsActive.Checked = true;
                panelOnlineStatus.Visible = false;
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку ОК
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Проверяем заполнение обязательных полей
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                XtraMessageBox.Show("Необходимо ввести название точки доступа", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBoxIpAddress.Text))
            {
                XtraMessageBox.Show("Необходимо ввести IP-адрес точки доступа", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxIpAddress.Focus();
                return;
            }

            if (comboBoxType.EditValue == null)
            {
                XtraMessageBox.Show("Необходимо выбрать тип точки доступа", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxType.Focus();
                return;
            }

            // Создаем объект с данными точки доступа
            AccessPointData = new AccessPointDto
            {
                Name = textBoxName.Text,
                Location = textBoxLocation.Text,
                IpAddress = textBoxIpAddress.Text,
                AccessPointTypeId = (int)comboBoxType.EditValue,
                IsActive = checkBoxIsActive.Checked
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку Отмена
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 