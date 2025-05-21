namespace APB.AccessControl.ManageApp.Forms
{
    partial class EmployeeEditForm
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
            components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            txtLastName = new DevExpress.XtraEditors.TextEdit();
            txtFirstName = new DevExpress.XtraEditors.TextEdit();
            txtPatronymicName = new DevExpress.XtraEditors.TextEdit();
            txtPassportNumber = new DevExpress.XtraEditors.TextEdit();
            txtDepartment = new DevExpress.XtraEditors.TextEdit();
            txtPosition = new DevExpress.XtraEditors.TextEdit();
            chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            pictureEditPhoto = new DevExpress.XtraEditors.PictureEdit();
            btnAddPhoto = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtLastName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFirstName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPatronymicName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassportNumber.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDepartment.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPosition.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkIsActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEditPhoto.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxValidationProvider).BeginInit();
            SuspendLayout();
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(txtLastName);
            layoutControl.Controls.Add(txtFirstName);
            layoutControl.Controls.Add(txtPatronymicName);
            layoutControl.Controls.Add(txtPassportNumber);
            layoutControl.Controls.Add(txtDepartment);
            layoutControl.Controls.Add(txtPosition);
            layoutControl.Controls.Add(chkIsActive);
            layoutControl.Controls.Add(pictureEditPhoto);
            layoutControl.Controls.Add(btnAddPhoto);
            layoutControl.Controls.Add(btnSave);
            layoutControl.Controls.Add(btnCancel);
            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl.Location = new System.Drawing.Point(0, 0);
            layoutControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            layoutControl.Name = "layoutControl";
            layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1372, -1167, 975, 600);
            layoutControl.Root = Root;
            layoutControl.Size = new System.Drawing.Size(803, 457);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl1";
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(10, 31);
            txtLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(389, 28);
            txtLastName.StyleController = layoutControl;
            txtLastName.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Поле не может быть пустым";
            dxValidationProvider.SetValidationRule(txtLastName, conditionValidationRule1);
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(10, 84);
            txtFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(389, 28);
            txtFirstName.StyleController = layoutControl;
            txtFirstName.TabIndex = 2;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Поле не может быть пустым";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            dxValidationProvider.SetValidationRule(txtFirstName, conditionValidationRule2);
            // 
            // txtPatronymicName
            // 
            txtPatronymicName.Location = new System.Drawing.Point(10, 137);
            txtPatronymicName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtPatronymicName.Name = "txtPatronymicName";
            txtPatronymicName.Size = new System.Drawing.Size(389, 28);
            txtPatronymicName.StyleController = layoutControl;
            txtPatronymicName.TabIndex = 3;
            // 
            // txtPassportNumber
            // 
            txtPassportNumber.Location = new System.Drawing.Point(10, 190);
            txtPassportNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtPassportNumber.Name = "txtPassportNumber";
            txtPassportNumber.Size = new System.Drawing.Size(389, 28);
            txtPassportNumber.StyleController = layoutControl;
            txtPassportNumber.TabIndex = 4;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new System.Drawing.Point(10, 243);
            txtDepartment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new System.Drawing.Size(389, 28);
            txtDepartment.StyleController = layoutControl;
            txtDepartment.TabIndex = 5;
            // 
            // txtPosition
            // 
            txtPosition.Location = new System.Drawing.Point(10, 296);
            txtPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new System.Drawing.Size(389, 28);
            txtPosition.StyleController = layoutControl;
            txtPosition.TabIndex = 6;
            // 
            // chkIsActive
            // 
            chkIsActive.Location = new System.Drawing.Point(10, 326);
            chkIsActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Properties.Caption = "Активен";
            chkIsActive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            chkIsActive.Size = new System.Drawing.Size(389, 27);
            chkIsActive.StyleController = layoutControl;
            chkIsActive.TabIndex = 7;
            // 
            // pictureEditPhoto
            // 
            pictureEditPhoto.Location = new System.Drawing.Point(403, 8);
            pictureEditPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            pictureEditPhoto.Name = "pictureEditPhoto";
            pictureEditPhoto.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEditPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureEditPhoto.Size = new System.Drawing.Size(390, 311);
            pictureEditPhoto.StyleController = layoutControl;
            pictureEditPhoto.TabIndex = 1;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Фото обязательно";
            dxValidationProvider.SetValidationRule(pictureEditPhoto, conditionValidationRule3);
            // 
            // btnAddPhoto
            // 
            btnAddPhoto.Location = new System.Drawing.Point(403, 321);
            btnAddPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnAddPhoto.Name = "btnAddPhoto";
            btnAddPhoto.Size = new System.Drawing.Size(390, 32);
            btnAddPhoto.StyleController = layoutControl;
            btnAddPhoto.TabIndex = 8;
            btnAddPhoto.Text = "Выбрать";
            btnAddPhoto.Click += btnAddPhoto_Click;
            // 
            // btnSave
            // 
            btnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            btnSave.Appearance.Options.UseBackColor = true;
            btnSave.Location = new System.Drawing.Point(10, 383);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(389, 32);
            btnSave.StyleController = layoutControl;
            btnSave.TabIndex = 9;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(403, 383);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(390, 32);
            btnCancel.StyleController = layoutControl;
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem8, layoutControlItem12, layoutControlItem9, layoutControlItem7, layoutControlItem11, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(803, 457);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtLastName;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(393, 53);
            layoutControlItem1.Text = "Фамилия *";
            layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem1.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtFirstName;
            layoutControlItem2.Location = new System.Drawing.Point(0, 53);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(393, 53);
            layoutControlItem2.Text = "Имя *";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtPatronymicName;
            layoutControlItem3.Location = new System.Drawing.Point(0, 106);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(393, 53);
            layoutControlItem3.Text = "Отчество";
            layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem3.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtPassportNumber;
            layoutControlItem4.Location = new System.Drawing.Point(0, 159);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(393, 53);
            layoutControlItem4.Text = "Номер паспорта*";
            layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem4.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = txtDepartment;
            layoutControlItem5.Location = new System.Drawing.Point(0, 212);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(393, 53);
            layoutControlItem5.Text = "Отдел";
            layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem5.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = txtPosition;
            layoutControlItem6.Location = new System.Drawing.Point(0, 265);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(393, 53);
            layoutControlItem6.Text = "Должность";
            layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem6.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = pictureEditPhoto;
            layoutControlItem8.Location = new System.Drawing.Point(393, 0);
            layoutControlItem8.MinSize = new System.Drawing.Size(177, 27);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new System.Drawing.Size(394, 313);
            layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            layoutControlItem12.Control = btnCancel;
            layoutControlItem12.Location = new System.Drawing.Point(393, 375);
            layoutControlItem12.Name = "layoutControlItem12";
            layoutControlItem12.Size = new System.Drawing.Size(394, 68);
            layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = btnAddPhoto;
            layoutControlItem9.Location = new System.Drawing.Point(393, 313);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.Size = new System.Drawing.Size(394, 34);
            layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = chkIsActive;
            layoutControlItem7.Location = new System.Drawing.Point(0, 318);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(393, 29);
            layoutControlItem7.Text = "Активен";
            layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Right;
            layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            layoutControlItem11.Control = btnSave;
            layoutControlItem11.Location = new System.Drawing.Point(0, 375);
            layoutControlItem11.Name = "layoutControlItem11";
            layoutControlItem11.Size = new System.Drawing.Size(393, 68);
            layoutControlItem11.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new System.Drawing.Point(0, 347);
            emptySpaceItem1.MaxSize = new System.Drawing.Size(769, 28);
            emptySpaceItem1.MinSize = new System.Drawing.Size(769, 28);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(787, 28);
            emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // dxValidationProvider
            // 
            dxValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // EmployeeEditForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(803, 457);
            Controls.Add(layoutControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Редактирование сотрудника";
            Load += EmployeeEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtLastName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFirstName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPatronymicName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassportNumber.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDepartment.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPosition.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkIsActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEditPhoto.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem12).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxValidationProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private DevExpress.XtraEditors.TextEdit txtFirstName;
        private DevExpress.XtraEditors.TextEdit txtPatronymicName;
        private DevExpress.XtraEditors.TextEdit txtPassportNumber;
        private DevExpress.XtraEditors.TextEdit txtDepartment;
        private DevExpress.XtraEditors.TextEdit txtPosition;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.SimpleButton btnAddPhoto;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.PictureEdit pictureEditPhoto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
    }
} 