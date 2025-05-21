using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using APB.AccessControl.Shared.Models.DTOs;
using DevExpress.CodeParser;

namespace APB.AccessControl.ManageApp.Forms
{
    /// <summary>
    /// Форма для добавления/редактирования группы доступа
    /// </summary>
    public partial class AccessGroupEditForm : XtraForm
    {
        private bool _isEditMode = false;
        
        /// <summary>
        /// Группа доступа
        /// </summary>
        public AccessGroupDto AccessGroup { get; private set; }
        
        /// <summary>
        /// Конструктор для создания новой группы доступа
        /// </summary>
        public AccessGroupEditForm()
        {
            InitializeComponent();
            Text = "Добавление группы доступа";
            
            AccessGroup = new AccessGroupDto();
            _isEditMode = false;
        }
        
        /// <summary>
        /// Конструктор для редактирования существующей группы доступа
        /// </summary>
        public AccessGroupEditForm(AccessGroupDto accessGroup)
        {
            InitializeComponent();
            Text = "Редактирование группы доступа";
            
            AccessGroup = accessGroup ?? throw new ArgumentNullException(nameof(accessGroup));
            _isEditMode = true;
            
            // Заполняем поля формы данными из переданной группы доступа
            textEditName.Text = accessGroup.Name;
        }
        
        private void AccessGroupEditForm_Load(object sender, EventArgs e)
        {
            dxValidationProvider.SetValidationRule(btnCancel, null);
            btnCancel.CausesValidation = false;
            // Настраиваем фокус на первое поле при загрузке формы
            textEditName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider.Validate())
            { 
                // Обновляем объект AccessGroup данными из формы
                AccessGroup.Name = textEditName.Text.Trim();

                // Закрываем форму с результатом OK
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                return;
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Закрываем форму с результатом Cancel
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 