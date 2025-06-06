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
            labelTitle = new DevExpress.XtraEditors.LabelControl();
            labelAccessPoint = new DevExpress.XtraEditors.LabelControl();
            comboBoxAccessPoints = new DevExpress.XtraEditors.ComboBoxEdit();
            buttonSave = new DevExpress.XtraEditors.SimpleButton();
            labelUsername = new DevExpress.XtraEditors.LabelControl();
            textEditUsername = new DevExpress.XtraEditors.TextEdit();
            labelPassword = new DevExpress.XtraEditors.LabelControl();
            textEditPassword = new DevExpress.XtraEditors.TextEdit();
            panelAccessPoint = new DevExpress.XtraEditors.PanelControl();
            panelLogin = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)comboBoxAccessPoints.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelAccessPoint).BeginInit();
            panelAccessPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelLogin).BeginInit();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            labelTitle.Appearance.Options.UseFont = true;
            labelTitle.Location = new Point(18, 20);
            labelTitle.Margin = new Padding(4);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(371, 34);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Настройка точки доступа";
            // 
            // labelAccessPoint
            // 
            labelAccessPoint.Location = new Point(18, 81);
            labelAccessPoint.Margin = new Padding(4);
            labelAccessPoint.Name = "labelAccessPoint";
            labelAccessPoint.Size = new Size(179, 21);
            labelAccessPoint.TabIndex = 1;
            labelAccessPoint.Text = "Выберите точку доступа:";
            // 
            // comboBoxAccessPoints
            // 
            comboBoxAccessPoints.Location = new Point(18, 112);
            comboBoxAccessPoints.Margin = new Padding(4);
            comboBoxAccessPoints.Name = "comboBoxAccessPoints";
            comboBoxAccessPoints.Properties.Appearance.Font = new Font("Tahoma", 12F);
            comboBoxAccessPoints.Properties.Appearance.Options.UseFont = true;
            comboBoxAccessPoints.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxAccessPoints.Properties.DropDownRows = 10;
            comboBoxAccessPoints.Properties.PopupFormSize = new Size(414, 300);
            comboBoxAccessPoints.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBoxAccessPoints.Size = new Size(414, 42);
            comboBoxAccessPoints.TabIndex = 2;
            // 
            // buttonSave
            // 
            buttonSave.Appearance.BackColor = Color.RoyalBlue;
            buttonSave.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSave.Appearance.Options.UseBackColor = true;
            buttonSave.Appearance.Options.UseFont = true;
            buttonSave.Location = new Point(18, 357);
            buttonSave.Margin = new Padding(4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(414, 56);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Сохранить";
            buttonSave.Click += ButtonSave_Click;
            buttonSave.Click += SaveAccessPoint_Click;
            // 
            // labelUsername
            // 
            labelUsername.Location = new Point(18, 169);
            labelUsername.Margin = new Padding(4);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(135, 21);
            labelUsername.TabIndex = 3;
            labelUsername.Text = "Имя пользователя:";
            // 
            // textEditUsername
            // 
            textEditUsername.Location = new Point(18, 200);
            textEditUsername.Margin = new Padding(4);
            textEditUsername.Name = "textEditUsername";
            textEditUsername.Properties.Appearance.Font = new Font("Tahoma", 12F);
            textEditUsername.Properties.Appearance.Options.UseFont = true;
            textEditUsername.Size = new Size(414, 42);
            textEditUsername.TabIndex = 4;
            // 
            // labelPassword
            // 
            labelPassword.Location = new Point(18, 259);
            labelPassword.Margin = new Padding(4);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(56, 21);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Пароль:";
            // 
            // textEditPassword
            // 
            textEditPassword.Location = new Point(18, 290);
            textEditPassword.Margin = new Padding(4);
            textEditPassword.Name = "textEditPassword";
            textEditPassword.Properties.Appearance.Font = new Font("Tahoma", 12F);
            textEditPassword.Properties.Appearance.Options.UseFont = true;
            textEditPassword.Properties.PasswordChar = '●';
            textEditPassword.Size = new Size(414, 42);
            textEditPassword.TabIndex = 6;
            // 
            // panelAccessPoint
            // 
            panelAccessPoint.Controls.Add(labelAccessPoint);
            panelAccessPoint.Controls.Add(comboBoxAccessPoints);
            panelAccessPoint.Dock = DockStyle.Top;
            panelAccessPoint.Location = new Point(0, 0);
            panelAccessPoint.Name = "panelAccessPoint";
            panelAccessPoint.Size = new Size(450, 170);
            panelAccessPoint.TabIndex = 8;
            panelAccessPoint.Visible = false;
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(labelTitle);
            panelLogin.Controls.Add(labelUsername);
            panelLogin.Controls.Add(textEditUsername);
            panelLogin.Controls.Add(labelPassword);
            panelLogin.Controls.Add(textEditPassword);
            panelLogin.Controls.Add(buttonSave);
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(0, 170);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(450, 450);
            panelLogin.TabIndex = 9;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 620);
            Controls.Add(panelLogin);
            Controls.Add(panelAccessPoint);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            IconOptions.ShowIcon = false;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)comboBoxAccessPoints.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelAccessPoint).EndInit();
            panelAccessPoint.ResumeLayout(false);
            panelAccessPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)panelLogin).EndInit();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
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
        private DevExpress.XtraEditors.PanelControl panelAccessPoint;
        private DevExpress.XtraEditors.PanelControl panelLogin;
    }
} 