namespace APB.AccessControl.ManageApp.Controls
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
            lblUsername = new DevExpress.XtraEditors.LabelControl();
            lblPassword = new DevExpress.XtraEditors.LabelControl();
            txtUsername = new DevExpress.XtraEditors.TextEdit();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            btnLogin = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.Location = new System.Drawing.Point(76, 124);
            lblUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(140, 19);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Имя пользователя:";
            // 
            // lblPassword
            // 
            lblPassword.Location = new System.Drawing.Point(76, 197);
            lblPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(60, 19);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Пароль:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(76, 153);
            txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(447, 26);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(76, 227);
            txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(447, 26);
            txtPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Location = new System.Drawing.Point(76, 292);
            btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(214, 44);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Войти";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(298, 292);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(225, 44);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Location = new System.Drawing.Point(207, 44);
            lblTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(189, 34);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Авторизация";
            // 
            // lblStatus
            // 
            lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
            lblStatus.Appearance.Options.UseForeColor = true;
            lblStatus.Location = new System.Drawing.Point(76, 358);
            lblStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(0, 19);
            lblStatus.TabIndex = 7;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(576, 411);
            Controls.Add(lblStatus);
            Controls.Add(lblTitle);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblUsername;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblStatus;
    }
} 