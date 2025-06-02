using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Forms
{
    public partial class PasswordChangeForm : XtraForm
    {
        public string NewPassword { get; private set; }

        public PasswordChangeForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                NewPassword = textEditPassword.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textEditPassword.Text))
            {
                XtraMessageBox.Show("Необходимо ввести новый пароль", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (textEditPassword.Text.Length < 6)
            {
                XtraMessageBox.Show("Пароль должен содержать минимум 6 символов", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (textEditPassword.Text != textEditPasswordConfirm.Text)
            {
                XtraMessageBox.Show("Пароли не совпадают", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
} 