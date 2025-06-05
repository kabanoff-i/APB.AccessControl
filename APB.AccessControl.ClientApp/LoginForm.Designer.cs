namespace APB.AccessControl.ClientApp
{
    partial class LoginForm
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
            this.labelTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelAccessPoint = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxAccessPoints = new DevExpress.XtraEditors.ComboBoxEdit();
            this.buttonSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelUsername = new DevExpress.XtraEditors.LabelControl();
            this.textEditUsername = new DevExpress.XtraEditors.TextEdit();
            this.labelPassword = new DevExpress.XtraEditors.LabelControl();
            this.textEditPassword = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAccessPoints.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Appearance.Options.UseFont = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(276, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Настройка точки доступа";
            // 
            // labelAccessPoint
            // 
            this.labelAccessPoint.Location = new System.Drawing.Point(12, 50);
            this.labelAccessPoint.Name = "labelAccessPoint";
            this.labelAccessPoint.Size = new System.Drawing.Size(276, 13);
            this.labelAccessPoint.TabIndex = 1;
            this.labelAccessPoint.Text = "Выберите точку доступа:";
            // 
            // comboBoxAccessPoints
            // 
            this.comboBoxAccessPoints.Location = new System.Drawing.Point(12, 69);
            this.comboBoxAccessPoints.Name = "comboBoxAccessPoints";
            this.comboBoxAccessPoints.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.comboBoxAccessPoints.Properties.Appearance.Options.UseFont = true;
            this.comboBoxAccessPoints.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxAccessPoints.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxAccessPoints.Size = new System.Drawing.Size(276, 26);
            this.comboBoxAccessPoints.TabIndex = 2;
            // 
            // labelUsername
            // 
            this.labelUsername.Location = new System.Drawing.Point(12, 105);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(276, 13);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Имя пользователя:";
            // 
            // textEditUsername
            // 
            this.textEditUsername.Location = new System.Drawing.Point(12, 124);
            this.textEditUsername.Name = "textEditUsername";
            this.textEditUsername.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textEditUsername.Properties.Appearance.Options.UseFont = true;
            this.textEditUsername.Size = new System.Drawing.Size(276, 26);
            this.textEditUsername.TabIndex = 4;
            // 
            // labelPassword
            // 
            this.labelPassword.Location = new System.Drawing.Point(12, 160);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(276, 13);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Пароль:";
            // 
            // textEditPassword
            // 
            this.textEditPassword.Location = new System.Drawing.Point(12, 179);
            this.textEditPassword.Name = "textEditPassword";
            this.textEditPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textEditPassword.Properties.Appearance.Options.UseFont = true;
            this.textEditPassword.Properties.PasswordChar = '●';
            this.textEditPassword.Size = new System.Drawing.Size(276, 26);
            this.textEditPassword.TabIndex = 6;
            // 
            // buttonSave
            // 
            this.buttonSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.buttonSave.Appearance.Options.UseFont = true;
            this.buttonSave.Location = new System.Drawing.Point(12, 211);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(276, 35);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 258);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textEditPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textEditUsername);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.comboBoxAccessPoints);
            this.Controls.Add(this.labelAccessPoint);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAccessPoints.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelTitle;
        private DevExpress.XtraEditors.LabelControl labelAccessPoint;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxAccessPoints;
        private DevExpress.XtraEditors.LabelControl labelUsername;
        private DevExpress.XtraEditors.TextEdit textEditUsername;
        private DevExpress.XtraEditors.LabelControl labelPassword;
        private DevExpress.XtraEditors.TextEdit textEditPassword;
        private DevExpress.XtraEditors.SimpleButton buttonSave;
    }
} 