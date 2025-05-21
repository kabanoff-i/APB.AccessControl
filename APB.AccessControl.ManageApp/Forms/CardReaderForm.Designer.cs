namespace APB.AccessControl.ManageApp.Forms
{
    partial class CardReaderForm
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
            panelCardReader = new DevExpress.XtraEditors.PanelControl();
            panelReaders = new DevExpress.XtraEditors.GroupControl();
            lblReaderList = new DevExpress.XtraEditors.LabelControl();
            cmbReaders = new DevExpress.XtraEditors.ComboBoxEdit();
            btnRefreshReaders = new DevExpress.XtraEditors.SimpleButton();
            btnStopPolling = new DevExpress.XtraEditors.SimpleButton();
            panelCardInfo = new DevExpress.XtraEditors.GroupControl();
            lblCardInfo = new DevExpress.XtraEditors.LabelControl();
            txtCardInfo = new DevExpress.XtraEditors.MemoEdit();
            lblCardHash = new DevExpress.XtraEditors.LabelControl();
            txtCardHash = new DevExpress.XtraEditors.TextEdit();
            lblPan = new DevExpress.XtraEditors.LabelControl();
            txtPan = new DevExpress.XtraEditors.TextEdit();
            lblCardHolder = new DevExpress.XtraEditors.LabelControl();
            txtCardHolder = new DevExpress.XtraEditors.TextEdit();
            btnClear = new DevExpress.XtraEditors.SimpleButton();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            btnStartReading = new DevExpress.XtraEditors.SimpleButton();
            btnClose = new DevExpress.XtraEditors.SimpleButton();
            btnLinkCard = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)panelCardReader).BeginInit();
            panelCardReader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelReaders).BeginInit();
            panelReaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbReaders.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelCardInfo).BeginInit();
            panelCardInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCardInfo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCardHash.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPan.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCardHolder.Properties).BeginInit();
            SuspendLayout();
            // 
            // panelCardReader
            // 
            panelCardReader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelCardReader.Controls.Add(panelReaders);
            panelCardReader.Controls.Add(panelCardInfo);
            panelCardReader.Controls.Add(lblStatus);
            panelCardReader.Location = new System.Drawing.Point(22, 90);
            panelCardReader.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            panelCardReader.Name = "panelCardReader";
            panelCardReader.Size = new System.Drawing.Size(1393, 970);
            panelCardReader.TabIndex = 0;
            // 
            // panelReaders
            // 
            panelReaders.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelReaders.Controls.Add(lblReaderList);
            panelReaders.Controls.Add(cmbReaders);
            panelReaders.Controls.Add(btnRefreshReaders);
            panelReaders.Controls.Add(btnStopPolling);
            panelReaders.Location = new System.Drawing.Point(10, 10);
            panelReaders.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            panelReaders.Name = "panelReaders";
            panelReaders.Size = new System.Drawing.Size(1375, 321);
            panelReaders.TabIndex = 0;
            panelReaders.Text = "Выбор устройства считывания";
            // 
            // lblReaderList
            // 
            lblReaderList.Location = new System.Drawing.Point(18, 85);
            lblReaderList.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lblReaderList.Name = "lblReaderList";
            lblReaderList.Size = new System.Drawing.Size(226, 28);
            lblReaderList.TabIndex = 0;
            lblReaderList.Text = "Доступные считыватели:";
            // 
            // cmbReaders
            // 
            cmbReaders.Location = new System.Drawing.Point(376, 80);
            cmbReaders.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            cmbReaders.Name = "cmbReaders";
            cmbReaders.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbReaders.Size = new System.Drawing.Size(733, 48);
            cmbReaders.TabIndex = 1;
            // 
            // btnRefreshReaders
            // 
            btnRefreshReaders.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRefreshReaders.Location = new System.Drawing.Point(1120, 80);
            btnRefreshReaders.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnRefreshReaders.Name = "btnRefreshReaders";
            btnRefreshReaders.Size = new System.Drawing.Size(246, 50);
            btnRefreshReaders.TabIndex = 2;
            btnRefreshReaders.Text = "Обновить";
            // 
            // btnStopPolling
            // 
            btnStopPolling.Appearance.BackColor = System.Drawing.Color.Red;
            btnStopPolling.Appearance.ForeColor = System.Drawing.Color.White;
            btnStopPolling.Appearance.Options.UseBackColor = true;
            btnStopPolling.Appearance.Options.UseForeColor = true;
            btnStopPolling.Enabled = false;
            btnStopPolling.Location = new System.Drawing.Point(716, 181);
            btnStopPolling.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnStopPolling.Name = "btnStopPolling";
            btnStopPolling.Size = new System.Drawing.Size(392, 50);
            btnStopPolling.TabIndex = 3;
            btnStopPolling.Text = "Остановить считывание";
            // 
            // panelCardInfo
            // 
            panelCardInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelCardInfo.Controls.Add(lblCardInfo);
            panelCardInfo.Controls.Add(txtCardInfo);
            panelCardInfo.Controls.Add(lblCardHash);
            panelCardInfo.Controls.Add(txtCardHash);
            panelCardInfo.Controls.Add(lblPan);
            panelCardInfo.Controls.Add(txtPan);
            panelCardInfo.Controls.Add(lblCardHolder);
            panelCardInfo.Controls.Add(txtCardHolder);
            panelCardInfo.Controls.Add(btnClear);
            panelCardInfo.Location = new System.Drawing.Point(10, 346);
            panelCardInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            panelCardInfo.Name = "panelCardInfo";
            panelCardInfo.Size = new System.Drawing.Size(1375, 538);
            panelCardInfo.TabIndex = 1;
            panelCardInfo.Text = "Информация о карте";
            // 
            // lblCardInfo
            // 
            lblCardInfo.Location = new System.Drawing.Point(18, 85);
            lblCardInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lblCardInfo.Name = "lblCardInfo";
            lblCardInfo.Size = new System.Drawing.Size(190, 28);
            lblCardInfo.TabIndex = 0;
            lblCardInfo.Text = "Данные считывания:";
            // 
            // txtCardInfo
            // 
            txtCardInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCardInfo.Location = new System.Drawing.Point(18, 140);
            txtCardInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtCardInfo.Name = "txtCardInfo";
            txtCardInfo.Properties.ReadOnly = true;
            txtCardInfo.Size = new System.Drawing.Size(1338, 130);
            txtCardInfo.TabIndex = 1;
            // 
            // lblCardHash
            // 
            lblCardHash.Location = new System.Drawing.Point(18, 281);
            lblCardHash.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lblCardHash.Name = "lblCardHash";
            lblCardHash.Size = new System.Drawing.Size(101, 28);
            lblCardHash.TabIndex = 2;
            lblCardHash.Text = "Хеш карты:";
            // 
            // txtCardHash
            // 
            txtCardHash.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCardHash.Location = new System.Drawing.Point(308, 281);
            txtCardHash.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtCardHash.Name = "txtCardHash";
            txtCardHash.Properties.ReadOnly = true;
            txtCardHash.Size = new System.Drawing.Size(1049, 48);
            txtCardHash.TabIndex = 3;
            // 
            // lblPan
            // 
            lblPan.Location = new System.Drawing.Point(18, 360);
            lblPan.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lblPan.Name = "lblPan";
            lblPan.Size = new System.Drawing.Size(43, 28);
            lblPan.TabIndex = 4;
            lblPan.Text = "PAN:";
            // 
            // txtPan
            // 
            txtPan.Location = new System.Drawing.Point(308, 360);
            txtPan.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtPan.Name = "txtPan";
            txtPan.Properties.ReadOnly = true;
            txtPan.Size = new System.Drawing.Size(733, 48);
            txtPan.TabIndex = 5;
            // 
            // lblCardHolder
            // 
            lblCardHolder.Location = new System.Drawing.Point(18, 438);
            lblCardHolder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lblCardHolder.Name = "lblCardHolder";
            lblCardHolder.Size = new System.Drawing.Size(104, 28);
            lblCardHolder.TabIndex = 6;
            lblCardHolder.Text = "Держатель:";
            // 
            // txtCardHolder
            // 
            txtCardHolder.Location = new System.Drawing.Point(308, 438);
            txtCardHolder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txtCardHolder.Name = "txtCardHolder";
            txtCardHolder.Properties.ReadOnly = true;
            txtCardHolder.Size = new System.Drawing.Size(733, 48);
            txtCardHolder.TabIndex = 7;
            // 
            // btnClear
            // 
            btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClear.Location = new System.Drawing.Point(1082, 438);
            btnClear.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(275, 50);
            btnClear.TabIndex = 8;
            btnClear.Text = "Очистить";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            lblStatus.Location = new System.Drawing.Point(10, 897);
            lblStatus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new System.Windows.Forms.Padding(10);
            lblStatus.Size = new System.Drawing.Size(1375, 60);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Выберите считыватель и нажмите 'Начать считывание'";
            // 
            // lblTitle
            // 
            lblTitle.Location = new System.Drawing.Point(22, 27);
            lblTitle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(509, 28);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Выберите считыватель и нажмите \"Начать считывание\"";
            // 
            // btnStartReading
            // 
            btnStartReading.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnStartReading.Appearance.BackColor = System.Drawing.Color.Green;
            btnStartReading.Appearance.ForeColor = System.Drawing.Color.White;
            btnStartReading.Appearance.Options.UseBackColor = true;
            btnStartReading.Appearance.Options.UseForeColor = true;
            btnStartReading.Location = new System.Drawing.Point(714, 1088);
            btnStartReading.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnStartReading.Name = "btnStartReading";
            btnStartReading.Size = new System.Drawing.Size(308, 50);
            btnStartReading.TabIndex = 2;
            btnStartReading.Text = "Начать считывание";
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(1230, 1088);
            btnClose.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(186, 50);
            btnClose.TabIndex = 4;
            btnClose.Text = "Закрыть";
            // 
            // btnLinkCard
            // 
            btnLinkCard.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnLinkCard.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 114, 198);
            btnLinkCard.Appearance.ForeColor = System.Drawing.Color.White;
            btnLinkCard.Appearance.Options.UseBackColor = true;
            btnLinkCard.Appearance.Options.UseForeColor = true;
            btnLinkCard.Enabled = false;
            btnLinkCard.Location = new System.Drawing.Point(1032, 1088);
            btnLinkCard.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnLinkCard.Name = "btnLinkCard";
            btnLinkCard.Size = new System.Drawing.Size(187, 50);
            btnLinkCard.TabIndex = 3;
            btnLinkCard.Text = "Привязать карту";
            // 
            // CardReaderForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new System.Drawing.Size(1437, 1167);
            Controls.Add(btnLinkCard);
            Controls.Add(btnClose);
            Controls.Add(btnStartReading);
            Controls.Add(lblTitle);
            Controls.Add(panelCardReader);
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(1439, 1214);
            Name = "CardReaderForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Считывание карты";
            ((System.ComponentModel.ISupportInitialize)panelCardReader).EndInit();
            panelCardReader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelReaders).EndInit();
            panelReaders.ResumeLayout(false);
            panelReaders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbReaders.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelCardInfo).EndInit();
            panelCardInfo.ResumeLayout(false);
            panelCardInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtCardInfo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCardHash.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPan.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCardHolder.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelCardReader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnStartReading;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnLinkCard;
        
        private DevExpress.XtraEditors.GroupControl panelReaders;
        private DevExpress.XtraEditors.GroupControl panelCardInfo;
        
        private DevExpress.XtraEditors.LabelControl lblReaderList;
        private DevExpress.XtraEditors.ComboBoxEdit cmbReaders;
        private DevExpress.XtraEditors.SimpleButton btnRefreshReaders;
        private DevExpress.XtraEditors.SimpleButton btnStopPolling;
        
        private DevExpress.XtraEditors.LabelControl lblCardInfo;
        private DevExpress.XtraEditors.MemoEdit txtCardInfo;
        private DevExpress.XtraEditors.LabelControl lblCardHash;
        private DevExpress.XtraEditors.TextEdit txtCardHash;
        private DevExpress.XtraEditors.LabelControl lblPan;
        private DevExpress.XtraEditors.TextEdit txtPan;
        private DevExpress.XtraEditors.LabelControl lblCardHolder;
        private DevExpress.XtraEditors.TextEdit txtCardHolder;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        
        private DevExpress.XtraEditors.LabelControl lblStatus;
    }
} 