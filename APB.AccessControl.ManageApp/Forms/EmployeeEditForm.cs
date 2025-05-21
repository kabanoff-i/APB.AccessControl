using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using APB.AccessControl.Shared.Models.DTOs;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Text.RegularExpressions;

namespace APB.AccessControl.ManageApp.Forms
{
    /// <summary>
    /// Форма для добавления/редактирования сотрудника
    /// </summary>
    public partial class EmployeeEditForm : XtraForm
    {
        public EmployeeDto Employee { get; private set; }
        private string _photoBase64;

        /// <summary>
        /// Конструктор для создания нового сотрудника
        /// </summary>
        public EmployeeEditForm()
        {
            InitializeComponent();
            Text = "Добавление сотрудника";

            // Настройка формы для создания нового сотрудника
            chkIsActive.Checked = true;

            // Скрываем поле "Активен" при создании нового сотрудника
            chkIsActive.Visible = false;
            chkIsActive.Enabled = false;
            layoutControlItem7.Control.Visible = false;
        }

        /// <summary>
        /// Конструктор для редактирования существующего сотрудника
        /// </summary>
        public EmployeeEditForm(EmployeeDto employee)
        {
            InitializeComponent();
            Text = "Редактирование сотрудника";

            // Заполняем поля данными сотрудника
            txtLastName.Text = employee.LastName;
            txtFirstName.Text = employee.FirstName;
            txtPatronymicName.Text = employee.PatronymicName;
            txtPassportNumber.Text = employee.PassportNumber;
            txtDepartment.Text = employee.Department;
            txtPosition.Text = employee.Position;
            chkIsActive.Checked = employee.IsActive;

            // Устанавливаем фото сотрудника если есть
            if (!string.IsNullOrEmpty(employee.Photo))
            {
                _photoBase64 = employee.Photo;
                try
                {
                    byte[] imageBytes = Convert.FromBase64String(employee.Photo);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pictureEditPhoto.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    pictureEditPhoto.Image = null;
                }
            }

            // Сохраняем ID сотрудника
            Employee = new EmployeeDto { Id = employee.Id };

            txtPassportNumber.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider.Validate())
            {
                return;
            }

            // Создаем/обновляем объект сотрудника
            if (Employee == null)
            {
                Employee = new EmployeeDto();
            }

            Employee.LastName = txtLastName.Text;
            Employee.FirstName = txtFirstName.Text;
            Employee.PatronymicName = txtPatronymicName.Text;
            Employee.PassportNumber = txtPassportNumber.Text;
            Employee.Department = txtDepartment.Text;
            Employee.Position = txtPosition.Text;
            Employee.IsActive = chkIsActive.Checked;
            Employee.Photo = _photoBase64;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        { 
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Выберите фотографию";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var image = Image.FromFile(openFileDialog.FileName))
                        {
                            // Устанавливаем изображение в PictureEdit
                            pictureEditPhoto.Image = new Bitmap(image);

                            // Конвертируем изображение в Base64
                            using (var ms = new MemoryStream())
                            {
                                image.Save(ms, image.RawFormat);
                                byte[] imageBytes = ms.ToArray();
                                _photoBase64 = Convert.ToBase64String(imageBytes);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {

            var rule = new PasspostNumberValidationRule();

            //остальные в дизайнере

            dxValidationProvider.SetValidationRule(btnCancel, null);

            dxValidationProvider.SetValidationRule(txtPassportNumber, rule);
            btnCancel.CausesValidation = false;
        }

        private class PasspostNumberValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                if (value is string passportNumber)
                {
                    // Проверяем, что номер паспорта состоит из 7 цифр
                    return Regex.IsMatch(passportNumber, "^[0-9]{7}$");
                }
                return false;
            }
        }
    }
} 