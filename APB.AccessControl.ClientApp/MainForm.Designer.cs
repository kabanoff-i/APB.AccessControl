namespace APB.AccessControl.ClientApp
{
    partial class MainForm
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
            buttonStopReader = new DevExpress.XtraEditors.SimpleButton();
            buttonStartReader = new DevExpress.XtraEditors.SimpleButton();
            comboBoxReaders = new DevExpress.XtraEditors.ComboBoxEdit();
            pictureEditEmployee = new DevExpress.XtraEditors.PictureEdit();
            labelReaderStatus = new DevExpress.XtraEditors.LabelControl();
            labelAccessStatus = new DevExpress.XtraEditors.LabelControl();
            labelDepartment = new DevExpress.XtraEditors.LabelControl();
            labelEmployeeName = new DevExpress.XtraEditors.LabelControl();
            labelCurrentCard = new DevExpress.XtraEditors.LabelControl();
            gridControlHistory = new DevExpress.XtraGrid.GridControl();
            gridViewHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridControlNotifications = new DevExpress.XtraGrid.GridControl();
            gridViewNotifications = new DevExpress.XtraGrid.Views.Grid.GridView();
            notificationTimer = new System.Windows.Forms.Timer(components);
            alertControl = new DevExpress.XtraBars.Alerter.AlertControl(components);
            tabFormControl1 = new DevExpress.XtraBars.TabFormControl();
            tabFormPagePass = new DevExpress.XtraBars.TabFormPage();
            tabFormContentContainer1 = new DevExpress.XtraBars.TabFormContentContainer();
            tabFormPageReaderSettings = new DevExpress.XtraBars.TabFormPage();
            tabFormContentContainer2 = new DevExpress.XtraBars.TabFormContentContainer();
            buttonStopReaderSettings = new DevExpress.XtraEditors.SimpleButton();
            buttonStartReaderSettings = new DevExpress.XtraEditors.SimpleButton();
            comboBoxReadersSettings = new DevExpress.XtraEditors.ComboBoxEdit();
            labelReaderStatusSettings = new DevExpress.XtraEditors.LabelControl();
            tabFormPageHistory = new DevExpress.XtraBars.TabFormPage();
            tabFormContentContainer3 = new DevExpress.XtraBars.TabFormContentContainer();
            tabFormPageNotifications = new DevExpress.XtraBars.TabFormPage();
            tabFormContentContainer4 = new DevExpress.XtraBars.TabFormContentContainer();
            tabFormPagePendingLogs = new DevExpress.XtraBars.TabFormPage();
            tabFormContentContainer5 = new DevExpress.XtraBars.TabFormContentContainer();
            ((System.ComponentModel.ISupportInitialize)comboBoxReaders.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEditEmployee.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlNotifications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewNotifications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabFormControl1).BeginInit();
            tabFormContentContainer1.SuspendLayout();
            tabFormContentContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxReadersSettings.Properties).BeginInit();
            tabFormContentContainer4.SuspendLayout();
            SuspendLayout();
            // 
            // buttonStopReader
            // 
            buttonStopReader.Enabled = false;
            buttonStopReader.Location = new Point(18, 576);
            buttonStopReader.Margin = new Padding(4);
            buttonStopReader.Name = "buttonStopReader";
            buttonStopReader.Size = new Size(142, 34);
            buttonStopReader.TabIndex = 8;
            buttonStopReader.Text = "Остановить";
            // 
            // buttonStartReader
            // 
            buttonStartReader.Location = new Point(176, 576);
            buttonStartReader.Margin = new Padding(4);
            buttonStartReader.Name = "buttonStartReader";
            buttonStartReader.Size = new Size(142, 34);
            buttonStartReader.TabIndex = 7;
            buttonStartReader.Text = "Запустить";
            // 
            // comboBoxReaders
            // 
            comboBoxReaders.Location = new Point(18, 538);
            comboBoxReaders.Margin = new Padding(4);
            comboBoxReaders.Name = "comboBoxReaders";
            comboBoxReaders.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxReaders.Size = new Size(300, 34);
            comboBoxReaders.TabIndex = 6;
            // 
            // pictureEditEmployee
            // 
            pictureEditEmployee.Location = new Point(18, 222);
            pictureEditEmployee.Margin = new Padding(4);
            pictureEditEmployee.Name = "pictureEditEmployee";
            pictureEditEmployee.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEditEmployee.Size = new Size(300, 292);
            pictureEditEmployee.TabIndex = 5;
            // 
            // labelReaderStatus
            // 
            labelReaderStatus.Location = new Point(18, 181);
            labelReaderStatus.Margin = new Padding(4);
            labelReaderStatus.Name = "labelReaderStatus";
            labelReaderStatus.Size = new Size(144, 21);
            labelReaderStatus.TabIndex = 4;
            labelReaderStatus.Text = "Статус считывателя:";
            // 
            // labelAccessStatus
            // 
            labelAccessStatus.Location = new Point(18, 140);
            labelAccessStatus.Margin = new Padding(4);
            labelAccessStatus.Name = "labelAccessStatus";
            labelAccessStatus.Size = new Size(111, 21);
            labelAccessStatus.TabIndex = 3;
            labelAccessStatus.Text = "Статус доступа:";
            // 
            // labelDepartment
            // 
            labelDepartment.Location = new Point(18, 99);
            labelDepartment.Margin = new Padding(4);
            labelDepartment.Name = "labelDepartment";
            labelDepartment.Size = new Size(47, 21);
            labelDepartment.TabIndex = 2;
            labelDepartment.Text = "Отдел:";
            // 
            // labelEmployeeName
            // 
            labelEmployeeName.Location = new Point(18, 58);
            labelEmployeeName.Margin = new Padding(4);
            labelEmployeeName.Name = "labelEmployeeName";
            labelEmployeeName.Size = new Size(81, 21);
            labelEmployeeName.TabIndex = 1;
            labelEmployeeName.Text = "Сотрудник:";
            // 
            // labelCurrentCard
            // 
            labelCurrentCard.Location = new Point(18, 18);
            labelCurrentCard.Margin = new Padding(4);
            labelCurrentCard.Name = "labelCurrentCard";
            labelCurrentCard.Size = new Size(108, 21);
            labelCurrentCard.TabIndex = 0;
            labelCurrentCard.Text = "Текущая карта:";
            // 
            // gridControlHistory
            // 
            gridControlHistory.Dock = DockStyle.Fill;
            gridControlHistory.EmbeddedNavigator.Margin = new Padding(4);
            gridControlHistory.Location = new Point(0, 0);
            gridControlHistory.MainView = gridViewHistory;
            gridControlHistory.Margin = new Padding(4);
            gridControlHistory.Name = "gridControlHistory";
            gridControlHistory.Size = new Size(1557, 605);
            gridControlHistory.TabIndex = 0;
            gridControlHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewHistory });
            // 
            // gridViewHistory
            // 
            gridViewHistory.GridControl = gridControlHistory;
            gridViewHistory.Name = "gridViewHistory";
            // 
            // gridControlNotifications
            // 
            gridControlNotifications.Dock = DockStyle.Fill;
            gridControlNotifications.EmbeddedNavigator.Margin = new Padding(4);
            gridControlNotifications.Location = new Point(0, 0);
            gridControlNotifications.MainView = gridViewNotifications;
            gridControlNotifications.Margin = new Padding(4);
            gridControlNotifications.Name = "gridControlNotifications";
            gridControlNotifications.Size = new Size(1557, 605);
            gridControlNotifications.TabIndex = 0;
            gridControlNotifications.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewNotifications });
            // 
            // gridViewNotifications
            // 
            gridViewNotifications.GridControl = gridControlNotifications;
            gridViewNotifications.Name = "gridViewNotifications";
            // 
            // tabFormControl1
            // 
            tabFormControl1.AllowMoveTabs = false;
            tabFormControl1.AllowMoveTabsToOuterForm = false;
            tabFormControl1.Location = new Point(0, 0);
            tabFormControl1.Name = "tabFormControl1";
            tabFormControl1.Pages.Add(tabFormPagePass);
            tabFormControl1.Pages.Add(tabFormPageReaderSettings);
            tabFormControl1.Pages.Add(tabFormPageHistory);
            tabFormControl1.Pages.Add(tabFormPageNotifications);
            tabFormControl1.Pages.Add(tabFormPagePendingLogs);
            tabFormControl1.SelectedPage = tabFormPagePass;
            tabFormControl1.ShowAddPageButton = false;
            tabFormControl1.ShowTabCloseButtons = false;
            tabFormControl1.Size = new Size(1557, 86);
            tabFormControl1.TabForm = this;
            tabFormControl1.TabIndex = 1;
            tabFormControl1.TabStop = false;
            tabFormControl1.SelectedPageChanged += TabFormControl1_SelectedPageChanged;
            // 
            // tabFormPagePass
            // 
            tabFormPagePass.ContentContainer = tabFormContentContainer1;
            tabFormPagePass.Name = "tabFormPagePass";
            tabFormPagePass.Text = "Пропуск";
            // 
            // tabFormContentContainer1
            // 
            tabFormContentContainer1.Controls.Add(buttonStopReader);
            tabFormContentContainer1.Controls.Add(buttonStartReader);
            tabFormContentContainer1.Controls.Add(comboBoxReaders);
            tabFormContentContainer1.Controls.Add(pictureEditEmployee);
            tabFormContentContainer1.Controls.Add(labelReaderStatus);
            tabFormContentContainer1.Controls.Add(labelAccessStatus);
            tabFormContentContainer1.Controls.Add(labelDepartment);
            tabFormContentContainer1.Controls.Add(labelEmployeeName);
            tabFormContentContainer1.Controls.Add(labelCurrentCard);
            tabFormContentContainer1.Dock = DockStyle.Fill;
            tabFormContentContainer1.Location = new Point(0, 86);
            tabFormContentContainer1.Name = "tabFormContentContainer1";
            tabFormContentContainer1.Size = new Size(1557, 605);
            tabFormContentContainer1.TabIndex = 0;
            // 
            // tabFormPageReaderSettings
            // 
            tabFormPageReaderSettings.ContentContainer = tabFormContentContainer2;
            tabFormPageReaderSettings.Name = "tabFormPageReaderSettings";
            tabFormPageReaderSettings.Text = "Настройки считывателя";
            // 
            // tabFormContentContainer2
            // 
            tabFormContentContainer2.Controls.Add(buttonStopReaderSettings);
            tabFormContentContainer2.Controls.Add(buttonStartReaderSettings);
            tabFormContentContainer2.Controls.Add(comboBoxReadersSettings);
            tabFormContentContainer2.Controls.Add(labelReaderStatusSettings);
            tabFormContentContainer2.Dock = DockStyle.Fill;
            tabFormContentContainer2.Location = new Point(0, 86);
            tabFormContentContainer2.Name = "tabFormContentContainer2";
            tabFormContentContainer2.Size = new Size(1557, 605);
            tabFormContentContainer2.TabIndex = 0;
            // 
            // buttonStopReaderSettings
            // 
            buttonStopReaderSettings.Enabled = false;
            buttonStopReaderSettings.Location = new Point(18, 124);
            buttonStopReaderSettings.Margin = new Padding(4);
            buttonStopReaderSettings.Name = "buttonStopReaderSettings";
            buttonStopReaderSettings.Size = new Size(142, 38);
            buttonStopReaderSettings.TabIndex = 3;
            buttonStopReaderSettings.Text = "Остановить";
            // 
            // buttonStartReaderSettings
            // 
            buttonStartReaderSettings.Location = new Point(176, 124);
            buttonStartReaderSettings.Margin = new Padding(4);
            buttonStartReaderSettings.Name = "buttonStartReaderSettings";
            buttonStartReaderSettings.Size = new Size(142, 38);
            buttonStartReaderSettings.TabIndex = 2;
            buttonStartReaderSettings.Text = "Запустить";
            // 
            // comboBoxReadersSettings
            // 
            comboBoxReadersSettings.Location = new Point(18, 82);
            comboBoxReadersSettings.Margin = new Padding(4);
            comboBoxReadersSettings.Name = "comboBoxReadersSettings";
            comboBoxReadersSettings.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxReadersSettings.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBoxReadersSettings.Size = new Size(300, 34);
            comboBoxReadersSettings.TabIndex = 1;
            // 
            // labelReaderStatusSettings
            // 
            labelReaderStatusSettings.Location = new Point(18, 20);
            labelReaderStatusSettings.Margin = new Padding(4);
            labelReaderStatusSettings.Name = "labelReaderStatusSettings";
            labelReaderStatusSettings.Size = new Size(144, 21);
            labelReaderStatusSettings.TabIndex = 0;
            labelReaderStatusSettings.Text = "Статус считывателя:";
            // 
            // tabFormPageHistory
            // 
            tabFormPageHistory.ContentContainer = tabFormContentContainer3;
            tabFormPageHistory.Name = "tabFormPageHistory";
            // 
            // tabFormContentContainer3
            // 
            tabFormContentContainer3.Dock = DockStyle.Fill;
            tabFormContentContainer3.Location = new Point(0, 86);
            tabFormContentContainer3.Name = "tabFormContentContainer3";
            tabFormContentContainer3.Size = new Size(1557, 605);
            tabFormContentContainer3.TabIndex = 2;
            // 
            // tabFormPageNotifications
            // 
            tabFormPageNotifications.ContentContainer = tabFormContentContainer4;
            tabFormPageNotifications.Name = "tabFormPageNotifications";
            tabFormPageNotifications.Text = "Уведомления";
            // 
            // tabFormContentContainer4
            // 
            tabFormContentContainer4.Controls.Add(gridControlNotifications);
            tabFormContentContainer4.Dock = DockStyle.Fill;
            tabFormContentContainer4.Location = new Point(0, 86);
            tabFormContentContainer4.Name = "tabFormContentContainer4";
            tabFormContentContainer4.Size = new Size(1557, 605);
            tabFormContentContainer4.TabIndex = 0;
            // 
            // tabFormPagePendingLogs
            // 
            tabFormPagePendingLogs.ContentContainer = tabFormContentContainer5;
            tabFormPagePendingLogs.Name = "tabFormPagePendingLogs";
            tabFormPagePendingLogs.Text = "Ожидающие логи";
            // 
            // tabFormContentContainer5
            // 
            tabFormContentContainer5.Dock = DockStyle.Fill;
            tabFormContentContainer5.Location = new Point(0, 86);
            tabFormContentContainer5.Name = "tabFormContentContainer5";
            tabFormContentContainer5.Size = new Size(1557, 605);
            tabFormContentContainer5.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 691);
            Controls.Add(tabFormContentContainer1);
            Controls.Add(tabFormControl1);
            Font = new Font("Segoe UI", 8F);
            IconOptions.ShowIcon = false;
            Name = "MainForm";
            TabFormControl = tabFormControl1;
            Text = "Система контроля доступа";
            ((System.ComponentModel.ISupportInitialize)comboBoxReaders.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEditEmployee.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlNotifications).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewNotifications).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabFormControl1).EndInit();
            tabFormContentContainer1.ResumeLayout(false);
            tabFormContentContainer1.PerformLayout();
            tabFormContentContainer2.ResumeLayout(false);
            tabFormContentContainer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxReadersSettings.Properties).EndInit();
            tabFormContentContainer4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelCurrentCard;
        private DevExpress.XtraEditors.LabelControl labelEmployeeName;
        private DevExpress.XtraEditors.LabelControl labelDepartment;
        private DevExpress.XtraEditors.LabelControl labelAccessStatus;
        private DevExpress.XtraEditors.LabelControl labelReaderStatus;
        private DevExpress.XtraEditors.PictureEdit pictureEditEmployee;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxReaders;
        private DevExpress.XtraEditors.SimpleButton buttonStartReader;
        private DevExpress.XtraEditors.SimpleButton buttonStopReader;
        private DevExpress.XtraGrid.GridControl gridControlHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHistory;
        private DevExpress.XtraGrid.GridControl gridControlNotifications;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNotifications;
        private System.Windows.Forms.Timer notificationTimer;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private DevExpress.XtraBars.TabFormControl tabFormControl1;
        private DevExpress.XtraBars.TabFormPage tabFormPagePass;
        private DevExpress.XtraBars.TabFormPage tabFormPageReaderSettings;
        private DevExpress.XtraBars.TabFormPage tabFormPageHistory;
        private DevExpress.XtraBars.TabFormPage tabFormPageNotifications;
        private DevExpress.XtraBars.TabFormPage tabFormPagePendingLogs;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer1;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer2;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer3;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer4;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer5;
        private DevExpress.XtraLayout.LayoutControl layoutControlReaderSettings;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton buttonStopReaderSettings;
        private DevExpress.XtraEditors.SimpleButton buttonStartReaderSettings;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxReadersSettings;
        private DevExpress.XtraEditors.LabelControl labelReaderStatusSettings;
    }
}

