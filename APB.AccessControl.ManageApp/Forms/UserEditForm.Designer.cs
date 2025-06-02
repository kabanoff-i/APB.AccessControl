namespace APB.AccessControl.ManageApp.Forms
{
    partial class UserEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            checkEditActive = new DevExpress.XtraEditors.CheckEdit();
            checkedComboBoxRoles = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            textEditFullName = new DevExpress.XtraEditors.TextEdit();
            textEditPasswordConfirm = new DevExpress.XtraEditors.TextEdit();
            textEditPassword = new DevExpress.XtraEditors.TextEdit();
            textEditUsername = new DevExpress.XtraEditors.TextEdit();
            layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkEditActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkedComboBoxRoles.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditFullName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditPasswordConfirm.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            SuspendLayout();
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(btnCancel);
            layoutControl.Controls.Add(btnSave);
            layoutControl.Controls.Add(checkEditActive);
            layoutControl.Controls.Add(checkedComboBoxRoles);
            layoutControl.Controls.Add(textEditFullName);
            layoutControl.Controls.Add(textEditPasswordConfirm);
            layoutControl.Controls.Add(textEditPassword);
            layoutControl.Controls.Add(textEditUsername);
            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl.Location = new System.Drawing.Point(0, 0);
            layoutControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            layoutControl.Name = "layoutControl";
            layoutControl.Root = layoutControlGroup;
            layoutControl.Size = new System.Drawing.Size(726, 470);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl1";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(366, 403);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(342, 32);
            btnCancel.StyleController = layoutControl;
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(18, 403);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(342, 32);
            btnSave.StyleController = layoutControl;
            btnSave.TabIndex = 7;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // checkEditActive
            // 
            checkEditActive.Location = new System.Drawing.Point(18, 370);
            checkEditActive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkEditActive.Name = "checkEditActive";
            checkEditActive.Properties.Caption = "Активен";
            checkEditActive.Size = new System.Drawing.Size(690, 27);
            checkEditActive.StyleController = layoutControl;
            checkEditActive.TabIndex = 6;
            // 
            // checkedComboBoxRoles
            // 
            checkedComboBoxRoles.Location = new System.Drawing.Point(18, 336);
            checkedComboBoxRoles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkedComboBoxRoles.Name = "checkedComboBoxRoles";
            checkedComboBoxRoles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            checkedComboBoxRoles.Size = new System.Drawing.Size(690, 28);
            checkedComboBoxRoles.StyleController = layoutControl;
            checkedComboBoxRoles.TabIndex = 5;
            // 
            // textEditFullName
            // 
            textEditFullName.Location = new System.Drawing.Point(18, 263);
            textEditFullName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textEditFullName.Name = "textEditFullName";
            textEditFullName.Size = new System.Drawing.Size(690, 28);
            textEditFullName.StyleController = layoutControl;
            textEditFullName.TabIndex = 4;
            // 
            // textEditPasswordConfirm
            // 
            textEditPasswordConfirm.Location = new System.Drawing.Point(18, 190);
            textEditPasswordConfirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textEditPasswordConfirm.Name = "textEditPasswordConfirm";
            textEditPasswordConfirm.Properties.PasswordChar = '*';
            textEditPasswordConfirm.Size = new System.Drawing.Size(690, 28);
            textEditPasswordConfirm.StyleController = layoutControl;
            textEditPasswordConfirm.TabIndex = 2;
            // 
            // textEditPassword
            // 
            textEditPassword.Location = new System.Drawing.Point(18, 117);
            textEditPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textEditPassword.Name = "textEditPassword";
            textEditPassword.Properties.PasswordChar = '*';
            textEditPassword.Size = new System.Drawing.Size(690, 28);
            textEditPassword.StyleController = layoutControl;
            textEditPassword.TabIndex = 1;
            // 
            // textEditUsername
            // 
            textEditUsername.Location = new System.Drawing.Point(18, 44);
            textEditUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textEditUsername.Name = "textEditUsername";
            textEditUsername.Size = new System.Drawing.Size(690, 28);
            textEditUsername.StyleController = layoutControl;
            textEditUsername.TabIndex = 0;
            // 
            // layoutControlGroup
            // 
            layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup.GroupBordersVisible = false;
            layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem5, layoutControlItem6, layoutControlItem7, layoutControlItem8, layoutControlItem9 });
            layoutControlGroup.Name = "layoutControlGroup";
            layoutControlGroup.Size = new System.Drawing.Size(726, 470);
            layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = textEditUsername;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(696, 59);
            layoutControlItem1.Text = "Логин";
            layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem1.TextSize = new System.Drawing.Size(171, 21);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = textEditPassword;
            layoutControlItem2.Location = new System.Drawing.Point(0, 59);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(696, 73);
            layoutControlItem2.Text = "Пароль";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new System.Drawing.Size(171, 21);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = textEditPasswordConfirm;
            layoutControlItem3.Location = new System.Drawing.Point(0, 132);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(696, 73);
            layoutControlItem3.Text = "Подтверждение пароля";
            layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem3.TextSize = new System.Drawing.Size(171, 21);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = textEditFullName;
            layoutControlItem5.Location = new System.Drawing.Point(0, 205);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(696, 73);
            layoutControlItem5.Text = "ФИО";
            layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem5.TextSize = new System.Drawing.Size(171, 21);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = checkedComboBoxRoles;
            layoutControlItem6.Location = new System.Drawing.Point(0, 278);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(696, 73);
            layoutControlItem6.Text = "Роли";
            layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem6.TextSize = new System.Drawing.Size(171, 21);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = checkEditActive;
            layoutControlItem7.Location = new System.Drawing.Point(0, 351);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(696, 33);
            layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = btnSave;
            layoutControlItem8.Location = new System.Drawing.Point(0, 384);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new System.Drawing.Size(348, 54);
            layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = btnCancel;
            layoutControlItem9.Location = new System.Drawing.Point(348, 384);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.Size = new System.Drawing.Size(348, 54);
            layoutControlItem9.TextVisible = false;
            // 
            // UserEditForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(726, 470);
            Controls.Add(layoutControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Редактирование пользователя";
            Load += UserEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)checkEditActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkedComboBoxRoles.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditFullName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditPasswordConfirm.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.CheckEdit checkEditActive;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxRoles;
        private DevExpress.XtraEditors.TextEdit textEditFullName;
        private DevExpress.XtraEditors.TextEdit textEditPasswordConfirm;
        private DevExpress.XtraEditors.TextEdit textEditPassword;
        private DevExpress.XtraEditors.TextEdit textEditUsername;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
} 