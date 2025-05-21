namespace APB.AccessControl.ManageApp.Forms
{
    partial class AccessPointEditForm
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
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            this.textBoxName = new DevExpress.XtraEditors.TextEdit();
            this.labelLocation = new DevExpress.XtraEditors.LabelControl();
            this.textBoxLocation = new DevExpress.XtraEditors.TextEdit();
            this.labelIpAddress = new DevExpress.XtraEditors.LabelControl();
            this.textBoxIpAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelType = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxType = new DevExpress.XtraEditors.LookUpEdit();
            this.checkBoxIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelOnlineStatus = new DevExpress.XtraEditors.PanelControl();
            this.labelLastHeartbeat = new DevExpress.XtraEditors.LabelControl();
            this.labelLastHeartbeatTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelOnlineStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelOnlineStatusTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxIpAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOnlineStatus)).BeginInit();
            this.panelOnlineStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(12, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(142, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(330, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelLocation
            // 
            this.labelLocation.Location = new System.Drawing.Point(12, 41);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(55, 13);
            this.labelLocation.TabIndex = 2;
            this.labelLocation.Text = "Локация:";
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(142, 38);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(330, 20);
            this.textBoxLocation.TabIndex = 3;
            // 
            // labelIpAddress
            // 
            this.labelIpAddress.Location = new System.Drawing.Point(12, 67);
            this.labelIpAddress.Name = "labelIpAddress";
            this.labelIpAddress.Size = new System.Drawing.Size(53, 13);
            this.labelIpAddress.TabIndex = 4;
            this.labelIpAddress.Text = "IP-адрес:";
            // 
            // textBoxIpAddress
            // 
            this.textBoxIpAddress.Location = new System.Drawing.Point(142, 64);
            this.textBoxIpAddress.Name = "textBoxIpAddress";
            this.textBoxIpAddress.Size = new System.Drawing.Size(330, 20);
            this.textBoxIpAddress.TabIndex = 5;
            // 
            // labelType
            // 
            this.labelType.Location = new System.Drawing.Point(12, 93);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(29, 13);
            this.labelType.TabIndex = 6;
            this.labelType.Text = "Тип:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Location = new System.Drawing.Point(142, 90);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxType.Properties.DisplayMember = "Name";
            this.comboBoxType.Properties.ValueMember = "Id";
            this.comboBoxType.Size = new System.Drawing.Size(330, 20);
            this.comboBoxType.TabIndex = 7;
            // 
            // checkBoxIsActive
            // 
            this.checkBoxIsActive.Location = new System.Drawing.Point(142, 117);
            this.checkBoxIsActive.Name = "checkBoxIsActive";
            this.checkBoxIsActive.Properties.Caption = "Активна";
            this.checkBoxIsActive.Size = new System.Drawing.Size(69, 19);
            this.checkBoxIsActive.TabIndex = 8;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(316, 195);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(397, 195);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panelOnlineStatus
            // 
            this.panelOnlineStatus.Controls.Add(this.labelLastHeartbeat);
            this.panelOnlineStatus.Controls.Add(this.labelLastHeartbeatTitle);
            this.panelOnlineStatus.Controls.Add(this.labelOnlineStatus);
            this.panelOnlineStatus.Controls.Add(this.labelOnlineStatusTitle);
            this.panelOnlineStatus.Location = new System.Drawing.Point(15, 140);
            this.panelOnlineStatus.Name = "panelOnlineStatus";
            this.panelOnlineStatus.Size = new System.Drawing.Size(457, 49);
            this.panelOnlineStatus.TabIndex = 11;
            // 
            // labelLastHeartbeat
            // 
            this.labelLastHeartbeat.Location = new System.Drawing.Point(160, 25);
            this.labelLastHeartbeat.Name = "labelLastHeartbeat";
            this.labelLastHeartbeat.Size = new System.Drawing.Size(66, 13);
            this.labelLastHeartbeat.TabIndex = 3;
            this.labelLastHeartbeat.Text = "Нет данных";
            // 
            // labelLastHeartbeatTitle
            // 
            this.labelLastHeartbeatTitle.Location = new System.Drawing.Point(5, 25);
            this.labelLastHeartbeatTitle.Name = "labelLastHeartbeatTitle";
            this.labelLastHeartbeatTitle.Size = new System.Drawing.Size(151, 13);
            this.labelLastHeartbeatTitle.TabIndex = 2;
            this.labelLastHeartbeatTitle.Text = "Последний сигнал (heartbeat):";
            // 
            // labelOnlineStatus
            // 
            this.labelOnlineStatus.Location = new System.Drawing.Point(127, 7);
            this.labelOnlineStatus.Name = "labelOnlineStatus";
            this.labelOnlineStatus.Size = new System.Drawing.Size(54, 13);
            this.labelOnlineStatus.TabIndex = 1;
            this.labelOnlineStatus.Text = "Оффлайн";
            // 
            // labelOnlineStatusTitle
            // 
            this.labelOnlineStatusTitle.Location = new System.Drawing.Point(5, 7);
            this.labelOnlineStatusTitle.Name = "labelOnlineStatusTitle";
            this.labelOnlineStatusTitle.Size = new System.Drawing.Size(118, 13);
            this.labelOnlineStatusTitle.TabIndex = 0;
            this.labelOnlineStatusTitle.Text = "Состояние устройства:";
            // 
            // AccessPointEditForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(484, 230);
            this.Controls.Add(this.panelOnlineStatus);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxIsActive);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.textBoxIpAddress);
            this.Controls.Add(this.labelIpAddress);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccessPointEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Точка доступа";
            ((System.ComponentModel.ISupportInitialize)(this.textBoxName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxIpAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOnlineStatus)).EndInit();
            this.panelOnlineStatus.ResumeLayout(false);
            this.panelOnlineStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.TextEdit textBoxName;
        private DevExpress.XtraEditors.LabelControl labelLocation;
        private DevExpress.XtraEditors.TextEdit textBoxLocation;
        private DevExpress.XtraEditors.LabelControl labelIpAddress;
        private DevExpress.XtraEditors.TextEdit textBoxIpAddress;
        private DevExpress.XtraEditors.LabelControl labelType;
        private DevExpress.XtraEditors.LookUpEdit comboBoxType;
        private DevExpress.XtraEditors.CheckEdit checkBoxIsActive;
        private DevExpress.XtraEditors.SimpleButton buttonOK;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.PanelControl panelOnlineStatus;
        private DevExpress.XtraEditors.LabelControl labelLastHeartbeat;
        private DevExpress.XtraEditors.LabelControl labelLastHeartbeatTitle;
        private DevExpress.XtraEditors.LabelControl labelOnlineStatus;
        private DevExpress.XtraEditors.LabelControl labelOnlineStatusTitle;
    }
} 