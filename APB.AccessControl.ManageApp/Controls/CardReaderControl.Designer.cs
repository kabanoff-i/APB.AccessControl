namespace APB.AccessControl.ManageApp.Controls
{
    partial class CardReaderControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            
            // Панели
            this.panelReaders = new DevExpress.XtraEditors.PanelControl();
            this.panelCardInfo = new DevExpress.XtraEditors.PanelControl();
            this.panelButtons = new DevExpress.XtraEditors.PanelControl();
            
            // Элементы для выбора и управления считывателем
            this.lblReaderList = new DevExpress.XtraEditors.LabelControl();
            this.cmbReaders = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnRefreshReaders = new DevExpress.XtraEditors.SimpleButton();
            this.btnStartPolling = new DevExpress.XtraEditors.SimpleButton();
            this.btnStopPolling = new DevExpress.XtraEditors.SimpleButton();
            
            // Элементы отображения информации о карте
            this.lblCardInfo = new DevExpress.XtraEditors.LabelControl();
            this.txtCardInfo = new DevExpress.XtraEditors.MemoEdit();
            this.lblCardHash = new DevExpress.XtraEditors.LabelControl();
            this.txtCardHash = new DevExpress.XtraEditors.TextEdit();
            this.lblPan = new DevExpress.XtraEditors.LabelControl();
            this.txtPan = new DevExpress.XtraEditors.TextEdit();
            this.lblCardHolder = new DevExpress.XtraEditors.LabelControl();
            this.txtCardHolder = new DevExpress.XtraEditors.TextEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            
            // Статус
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            
            // SuspendLayout
            this.SuspendLayout();
            
            // layoutControl
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 158, 650, 400);
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(800, 600);
            this.layoutControl.TabIndex = 0;
            
            // layoutControlGroup
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Name = "Root";
            this.layoutControlGroup.Size = new System.Drawing.Size(800, 600);
            this.layoutControlGroup.TextVisible = false;

            // panelReaders
            this.panelReaders.Location = new System.Drawing.Point(12, 12);
            this.panelReaders.Name = "panelReaders";
            this.panelReaders.Size = new System.Drawing.Size(776, 100);
            this.panelReaders.TabIndex = 0;
            
            // Настройка элементов панели выбора считывателя
            this.lblReaderList.Parent = this.panelReaders;
            this.lblReaderList.Location = new System.Drawing.Point(10, 10);
            this.lblReaderList.Name = "lblReaderList";
            this.lblReaderList.Size = new System.Drawing.Size(115, 13);
            this.lblReaderList.Text = "Доступные считыватели:";
            
            this.cmbReaders.Parent = this.panelReaders;
            this.cmbReaders.Location = new System.Drawing.Point(10, 30);
            this.cmbReaders.Name = "cmbReaders";
            this.cmbReaders.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbReaders.Size = new System.Drawing.Size(300, 20);
            
            this.btnRefreshReaders.Parent = this.panelReaders;
            this.btnRefreshReaders.Location = new System.Drawing.Point(320, 30);
            this.btnRefreshReaders.Name = "btnRefreshReaders";
            this.btnRefreshReaders.Size = new System.Drawing.Size(100, 22);
            this.btnRefreshReaders.Text = "Обновить";
            
            this.btnStartPolling.Parent = this.panelReaders;
            this.btnStartPolling.Location = new System.Drawing.Point(10, 60);
            this.btnStartPolling.Name = "btnStartPolling";
            this.btnStartPolling.Size = new System.Drawing.Size(150, 22);
            this.btnStartPolling.Text = "Начать считывание";
            
            this.btnStopPolling.Parent = this.panelReaders;
            this.btnStopPolling.Location = new System.Drawing.Point(170, 60);
            this.btnStopPolling.Name = "btnStopPolling";
            this.btnStopPolling.Size = new System.Drawing.Size(150, 22);
            this.btnStopPolling.Text = "Остановить считывание";
            this.btnStopPolling.Enabled = false;
            
            // panelCardInfo
            this.panelCardInfo.Location = new System.Drawing.Point(12, 116);
            this.panelCardInfo.Name = "panelCardInfo";
            this.panelCardInfo.Size = new System.Drawing.Size(776, 300);
            this.panelCardInfo.TabIndex = 1;
            
            // Настройка элементов панели информации о карте
            this.lblCardInfo.Parent = this.panelCardInfo;
            this.lblCardInfo.Location = new System.Drawing.Point(10, 10);
            this.lblCardInfo.Name = "lblCardInfo";
            this.lblCardInfo.Size = new System.Drawing.Size(100, 13);
            this.lblCardInfo.Text = "Информация о карте:";
            
            this.txtCardInfo.Parent = this.panelCardInfo;
            this.txtCardInfo.Location = new System.Drawing.Point(10, 30);
            this.txtCardInfo.Name = "txtCardInfo";
            this.txtCardInfo.Size = new System.Drawing.Size(756, 100);
            this.txtCardInfo.Properties.ReadOnly = true;
            
            this.lblCardHash.Parent = this.panelCardInfo;
            this.lblCardHash.Location = new System.Drawing.Point(10, 140);
            this.lblCardHash.Name = "lblCardHash";
            this.lblCardHash.Size = new System.Drawing.Size(55, 13);
            this.lblCardHash.Text = "Хеш карты:";
            
            this.txtCardHash.Parent = this.panelCardInfo;
            this.txtCardHash.Location = new System.Drawing.Point(10, 160);
            this.txtCardHash.Name = "txtCardHash";
            this.txtCardHash.Size = new System.Drawing.Size(756, 20);
            this.txtCardHash.Properties.ReadOnly = true;
            
            this.lblPan.Parent = this.panelCardInfo;
            this.lblPan.Location = new System.Drawing.Point(10, 190);
            this.lblPan.Name = "lblPan";
            this.lblPan.Size = new System.Drawing.Size(26, 13);
            this.lblPan.Text = "PAN:";
            
            this.txtPan.Parent = this.panelCardInfo;
            this.txtPan.Location = new System.Drawing.Point(10, 210);
            this.txtPan.Name = "txtPan";
            this.txtPan.Size = new System.Drawing.Size(300, 20);
            this.txtPan.Properties.ReadOnly = true;
            
            this.lblCardHolder.Parent = this.panelCardInfo;
            this.lblCardHolder.Location = new System.Drawing.Point(10, 240);
            this.lblCardHolder.Name = "lblCardHolder";
            this.lblCardHolder.Size = new System.Drawing.Size(90, 13);
            this.lblCardHolder.Text = "Держатель карты:";
            
            this.txtCardHolder.Parent = this.panelCardInfo;
            this.txtCardHolder.Location = new System.Drawing.Point(10, 260);
            this.txtCardHolder.Name = "txtCardHolder";
            this.txtCardHolder.Size = new System.Drawing.Size(300, 20);
            this.txtCardHolder.Properties.ReadOnly = true;
            
            // panelButtons
            this.panelButtons.Location = new System.Drawing.Point(12, 420);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(776, 50);
            this.panelButtons.TabIndex = 2;
            
            // Настройка кнопок
            this.btnClear.Parent = this.panelButtons;
            this.btnClear.Location = new System.Drawing.Point(10, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 22);
            this.btnClear.Text = "Очистить";
            
            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(12, 480);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(776, 20);
            this.lblStatus.Text = "Статус: Готово";
            
            // CardReaderControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelReaders);
            this.Controls.Add(this.panelCardInfo);
            this.Controls.Add(this.panelButtons);
            this.Name = "CardReaderControl";
            this.Size = new System.Drawing.Size(800, 510);
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        
        private DevExpress.XtraEditors.PanelControl panelReaders;
        private DevExpress.XtraEditors.PanelControl panelCardInfo;
        private DevExpress.XtraEditors.PanelControl panelButtons;
        
        private DevExpress.XtraEditors.LabelControl lblReaderList;
        private DevExpress.XtraEditors.ComboBoxEdit cmbReaders;
        private DevExpress.XtraEditors.SimpleButton btnRefreshReaders;
        private DevExpress.XtraEditors.SimpleButton btnStartPolling;
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