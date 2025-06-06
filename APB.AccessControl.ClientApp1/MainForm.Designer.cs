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
            xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            tabPass = new DevExpress.XtraTab.XtraTabPage();
            panelPass = new DevExpress.XtraEditors.PanelControl();
            panelEmployeeInfo = new DevExpress.XtraEditors.PanelControl();
            pictureEditEmployee = new DevExpress.XtraEditors.PictureEdit();
            labelEmployeeName = new DevExpress.XtraEditors.LabelControl();
            labelDepartment = new DevExpress.XtraEditors.LabelControl();
            labelAccessStatus = new DevExpress.XtraEditors.LabelControl();
            buttonManualInput = new DevExpress.XtraEditors.SimpleButton();
            panelRecentPasses = new DevExpress.XtraEditors.PanelControl();
            gridRecentPasses = new DevExpress.XtraGrid.GridControl();
            gridViewRecentPasses = new DevExpress.XtraGrid.Views.Grid.GridView();
            tabReaderSettings = new DevExpress.XtraTab.XtraTabPage();
            panelReaderSettings = new DevExpress.XtraEditors.PanelControl();
            comboBoxReaders = new DevExpress.XtraEditors.ComboBoxEdit();
            buttonStartReader = new DevExpress.XtraEditors.SimpleButton();
            buttonStopReader = new DevExpress.XtraEditors.SimpleButton();
            labelReaderStatus = new DevExpress.XtraEditors.LabelControl();
            tabHistory = new DevExpress.XtraTab.XtraTabPage();
            panelHistory = new DevExpress.XtraEditors.PanelControl();
            panelHistoryFilter = new DevExpress.XtraEditors.PanelControl();
            buttonRefresh = new DevExpress.XtraEditors.SimpleButton();
            gridHistory = new DevExpress.XtraGrid.GridControl();
            gridViewHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            tabNotifications = new DevExpress.XtraTab.XtraTabPage();
            panelNotifications = new DevExpress.XtraEditors.PanelControl();
            panelNotificationsFilter = new DevExpress.XtraEditors.PanelControl();
            buttonMarkAsRead = new DevExpress.XtraEditors.SimpleButton();
            gridNotifications = new DevExpress.XtraGrid.GridControl();
            gridViewNotifications = new DevExpress.XtraGrid.Views.Grid.GridView();
            tabPendingLogs = new DevExpress.XtraTab.XtraTabPage();
            panelPendingLogs = new DevExpress.XtraEditors.PanelControl();
            gridPendingLogs = new DevExpress.XtraGrid.GridControl();
            gridViewPendingLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            notificationTimer = new System.Windows.Forms.Timer(components);
            alertControl = new DevExpress.XtraBars.Alerter.AlertControl(components);
            labelCurrentCard = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl).BeginInit();
            xtraTabControl.SuspendLayout();
            tabPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelPass).BeginInit();
            panelPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelEmployeeInfo).BeginInit();
            panelEmployeeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEditEmployee.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelRecentPasses).BeginInit();
            panelRecentPasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRecentPasses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRecentPasses).BeginInit();
            tabReaderSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelReaderSettings).BeginInit();
            panelReaderSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxReaders.Properties).BeginInit();
            tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelHistory).BeginInit();
            panelHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelHistoryFilter).BeginInit();
            panelHistoryFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewHistory).BeginInit();
            tabNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelNotifications).BeginInit();
            panelNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelNotificationsFilter).BeginInit();
            panelNotificationsFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridNotifications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewNotifications).BeginInit();
            tabPendingLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelPendingLogs).BeginInit();
            panelPendingLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPendingLogs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPendingLogs).BeginInit();
            SuspendLayout();
            // 
            // xtraTabControl
            // 
            xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            xtraTabControl.Location = new System.Drawing.Point(0, 0);
            xtraTabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            xtraTabControl.Name = "xtraTabControl";
            xtraTabControl.SelectedTabPage = tabPass;
            xtraTabControl.Size = new System.Drawing.Size(1559, 727);
            xtraTabControl.TabIndex = 0;
            xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tabReaderSettings, tabPass, tabHistory, tabNotifications, tabPendingLogs });
            // 
            // tabPass
            // 
            tabPass.Controls.Add(panelPass);
            tabPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPass.Name = "tabPass";
            tabPass.Size = new System.Drawing.Size(1557, 690);
            tabPass.Text = "Проход";
            // 
            // panelPass
            // 
            panelPass.Controls.Add(panelEmployeeInfo);
            panelPass.Controls.Add(panelRecentPasses);
            panelPass.Dock = System.Windows.Forms.DockStyle.Fill;
            panelPass.Location = new System.Drawing.Point(0, 0);
            panelPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelPass.Name = "panelPass";
            panelPass.Size = new System.Drawing.Size(1557, 690);
            panelPass.TabIndex = 0;
            // 
            // panelEmployeeInfo
            // 
            panelEmployeeInfo.Controls.Add(pictureEditEmployee);
            panelEmployeeInfo.Controls.Add(labelEmployeeName);
            panelEmployeeInfo.Controls.Add(labelDepartment);
            panelEmployeeInfo.Controls.Add(labelAccessStatus);
            panelEmployeeInfo.Controls.Add(buttonManualInput);
            panelEmployeeInfo.Dock = System.Windows.Forms.DockStyle.Left;
            panelEmployeeInfo.Location = new System.Drawing.Point(2, 2);
            panelEmployeeInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelEmployeeInfo.Name = "panelEmployeeInfo";
            panelEmployeeInfo.Size = new System.Drawing.Size(450, 686);
            panelEmployeeInfo.TabIndex = 0;
            // 
            // pictureEditEmployee
            // 
            pictureEditEmployee.Location = new System.Drawing.Point(75, 32);
            pictureEditEmployee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pictureEditEmployee.Name = "pictureEditEmployee";
            pictureEditEmployee.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureEditEmployee.Size = new System.Drawing.Size(300, 323);
            pictureEditEmployee.TabIndex = 0;
            // 
            // labelEmployeeName
            // 
            labelEmployeeName.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            labelEmployeeName.Appearance.Options.UseFont = true;
            labelEmployeeName.Appearance.Options.UseTextOptions = true;
            labelEmployeeName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelEmployeeName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelEmployeeName.Location = new System.Drawing.Point(30, 388);
            labelEmployeeName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            labelEmployeeName.Name = "labelEmployeeName";
            labelEmployeeName.Size = new System.Drawing.Size(390, 48);
            labelEmployeeName.TabIndex = 1;
            labelEmployeeName.Text = "ФИО сотрудника";
            // 
            // labelDepartment
            // 
            labelDepartment.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            labelDepartment.Appearance.Options.UseFont = true;
            labelDepartment.Appearance.Options.UseTextOptions = true;
            labelDepartment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelDepartment.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelDepartment.Location = new System.Drawing.Point(30, 452);
            labelDepartment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            labelDepartment.Name = "labelDepartment";
            labelDepartment.Size = new System.Drawing.Size(390, 40);
            labelDepartment.TabIndex = 2;
            labelDepartment.Text = "Отдел";
            // 
            // labelAccessStatus
            // 
            labelAccessStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            labelAccessStatus.Appearance.Options.UseFont = true;
            labelAccessStatus.Appearance.Options.UseTextOptions = true;
            labelAccessStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelAccessStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelAccessStatus.Location = new System.Drawing.Point(30, 517);
            labelAccessStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            labelAccessStatus.Name = "labelAccessStatus";
            labelAccessStatus.Size = new System.Drawing.Size(390, 48);
            labelAccessStatus.TabIndex = 3;
            labelAccessStatus.Text = "Статус доступа";
            // 
            // buttonManualInput
            // 
            buttonManualInput.Location = new System.Drawing.Point(30, 598);
            buttonManualInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonManualInput.Name = "buttonManualInput";
            buttonManualInput.Size = new System.Drawing.Size(390, 65);
            buttonManualInput.TabIndex = 4;
            buttonManualInput.Text = "Ручной ввод";
            // 
            // panelRecentPasses
            // 
            panelRecentPasses.Controls.Add(gridRecentPasses);
            panelRecentPasses.Dock = System.Windows.Forms.DockStyle.Fill;
            panelRecentPasses.Location = new System.Drawing.Point(2, 2);
            panelRecentPasses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelRecentPasses.Name = "panelRecentPasses";
            panelRecentPasses.Size = new System.Drawing.Size(1553, 686);
            panelRecentPasses.TabIndex = 1;
            // 
            // gridRecentPasses
            // 
            gridRecentPasses.Dock = System.Windows.Forms.DockStyle.Fill;
            gridRecentPasses.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridRecentPasses.Location = new System.Drawing.Point(2, 2);
            gridRecentPasses.MainView = gridViewRecentPasses;
            gridRecentPasses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridRecentPasses.Name = "gridRecentPasses";
            gridRecentPasses.Size = new System.Drawing.Size(1549, 682);
            gridRecentPasses.TabIndex = 0;
            gridRecentPasses.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewRecentPasses });
            // 
            // gridViewRecentPasses
            // 
            gridViewRecentPasses.DetailHeight = 565;
            gridViewRecentPasses.GridControl = gridRecentPasses;
            gridViewRecentPasses.Name = "gridViewRecentPasses";
            gridViewRecentPasses.OptionsEditForm.PopupEditFormWidth = 1200;
            // 
            // tabReaderSettings
            // 
            tabReaderSettings.Controls.Add(panelReaderSettings);
            tabReaderSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabReaderSettings.Name = "tabReaderSettings";
            tabReaderSettings.Size = new System.Drawing.Size(1557, 690);
            tabReaderSettings.Text = "Настройки считывателя";
            // 
            // panelReaderSettings
            // 
            panelReaderSettings.Controls.Add(comboBoxReaders);
            panelReaderSettings.Controls.Add(buttonStartReader);
            panelReaderSettings.Controls.Add(buttonStopReader);
            panelReaderSettings.Controls.Add(labelCurrentCard);
            panelReaderSettings.Controls.Add(labelReaderStatus);
            panelReaderSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReaderSettings.Location = new System.Drawing.Point(0, 0);
            panelReaderSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelReaderSettings.Name = "panelReaderSettings";
            panelReaderSettings.Size = new System.Drawing.Size(1557, 690);
            panelReaderSettings.TabIndex = 0;
            // 
            // comboBoxReaders
            // 
            comboBoxReaders.Location = new System.Drawing.Point(30, 32);
            comboBoxReaders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            comboBoxReaders.Name = "comboBoxReaders";
            comboBoxReaders.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBoxReaders.Size = new System.Drawing.Size(450, 28);
            comboBoxReaders.TabIndex = 0;
            // 
            // buttonStartReader
            // 
            buttonStartReader.Location = new System.Drawing.Point(30, 97);
            buttonStartReader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonStartReader.Name = "buttonStartReader";
            buttonStartReader.Size = new System.Drawing.Size(210, 48);
            buttonStartReader.TabIndex = 1;
            buttonStartReader.Text = "Запустить";
            // 
            // buttonStopReader
            // 
            buttonStopReader.Location = new System.Drawing.Point(270, 97);
            buttonStopReader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonStopReader.Name = "buttonStopReader";
            buttonStopReader.Size = new System.Drawing.Size(210, 48);
            buttonStopReader.TabIndex = 2;
            buttonStopReader.Text = "Остановить";
            // 
            // labelReaderStatus
            // 
            labelReaderStatus.Location = new System.Drawing.Point(29, 160);
            labelReaderStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            labelReaderStatus.Name = "labelReaderStatus";
            labelReaderStatus.Size = new System.Drawing.Size(159, 21);
            labelReaderStatus.TabIndex = 4;
            labelReaderStatus.Text = "Статус: Не подключен";
            // 
            // tabHistory
            // 
            tabHistory.Controls.Add(panelHistory);
            tabHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabHistory.Name = "tabHistory";
            tabHistory.Size = new System.Drawing.Size(1557, 690);
            tabHistory.Text = "История проходов";
            // 
            // panelHistory
            // 
            panelHistory.Controls.Add(panelHistoryFilter);
            panelHistory.Controls.Add(gridHistory);
            panelHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            panelHistory.Location = new System.Drawing.Point(0, 0);
            panelHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelHistory.Name = "panelHistory";
            panelHistory.Size = new System.Drawing.Size(1557, 690);
            panelHistory.TabIndex = 0;
            // 
            // panelHistoryFilter
            // 
            panelHistoryFilter.Controls.Add(buttonRefresh);
            panelHistoryFilter.Dock = System.Windows.Forms.DockStyle.Top;
            panelHistoryFilter.Location = new System.Drawing.Point(2, 2);
            panelHistoryFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelHistoryFilter.Name = "panelHistoryFilter";
            panelHistoryFilter.Size = new System.Drawing.Size(1553, 81);
            panelHistoryFilter.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new System.Drawing.Point(15, 16);
            buttonRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new System.Drawing.Size(180, 48);
            buttonRefresh.TabIndex = 0;
            buttonRefresh.Text = "Обновить";
            // 
            // gridHistory
            // 
            gridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            gridHistory.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridHistory.Location = new System.Drawing.Point(2, 2);
            gridHistory.MainView = gridViewHistory;
            gridHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridHistory.Name = "gridHistory";
            gridHistory.Size = new System.Drawing.Size(1553, 686);
            gridHistory.TabIndex = 1;
            gridHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewHistory });
            // 
            // gridViewHistory
            // 
            gridViewHistory.DetailHeight = 565;
            gridViewHistory.GridControl = gridHistory;
            gridViewHistory.Name = "gridViewHistory";
            gridViewHistory.OptionsEditForm.PopupEditFormWidth = 1200;
            // 
            // tabNotifications
            // 
            tabNotifications.Controls.Add(panelNotifications);
            tabNotifications.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabNotifications.Name = "tabNotifications";
            tabNotifications.Size = new System.Drawing.Size(1557, 690);
            tabNotifications.Text = "Уведомления";
            // 
            // panelNotifications
            // 
            panelNotifications.Controls.Add(panelNotificationsFilter);
            panelNotifications.Controls.Add(gridNotifications);
            panelNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            panelNotifications.Location = new System.Drawing.Point(0, 0);
            panelNotifications.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelNotifications.Name = "panelNotifications";
            panelNotifications.Size = new System.Drawing.Size(1557, 690);
            panelNotifications.TabIndex = 0;
            // 
            // panelNotificationsFilter
            // 
            panelNotificationsFilter.Controls.Add(buttonMarkAsRead);
            panelNotificationsFilter.Dock = System.Windows.Forms.DockStyle.Top;
            panelNotificationsFilter.Location = new System.Drawing.Point(2, 2);
            panelNotificationsFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelNotificationsFilter.Name = "panelNotificationsFilter";
            panelNotificationsFilter.Size = new System.Drawing.Size(1553, 81);
            panelNotificationsFilter.TabIndex = 0;
            // 
            // buttonMarkAsRead
            // 
            buttonMarkAsRead.Location = new System.Drawing.Point(15, 16);
            buttonMarkAsRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonMarkAsRead.Name = "buttonMarkAsRead";
            buttonMarkAsRead.Size = new System.Drawing.Size(225, 48);
            buttonMarkAsRead.TabIndex = 0;
            buttonMarkAsRead.Text = "Пометить как прочитано";
            // 
            // gridNotifications
            // 
            gridNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            gridNotifications.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridNotifications.Location = new System.Drawing.Point(2, 2);
            gridNotifications.MainView = gridViewNotifications;
            gridNotifications.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridNotifications.Name = "gridNotifications";
            gridNotifications.Size = new System.Drawing.Size(1553, 686);
            gridNotifications.TabIndex = 1;
            gridNotifications.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewNotifications });
            // 
            // gridViewNotifications
            // 
            gridViewNotifications.DetailHeight = 565;
            gridViewNotifications.GridControl = gridNotifications;
            gridViewNotifications.Name = "gridViewNotifications";
            gridViewNotifications.OptionsEditForm.PopupEditFormWidth = 1200;
            // 
            // tabPendingLogs
            // 
            tabPendingLogs.Controls.Add(panelPendingLogs);
            tabPendingLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPendingLogs.Name = "tabPendingLogs";
            tabPendingLogs.Size = new System.Drawing.Size(1557, 690);
            tabPendingLogs.Text = "Отложенные записи";
            // 
            // panelPendingLogs
            // 
            panelPendingLogs.Controls.Add(gridPendingLogs);
            panelPendingLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            panelPendingLogs.Location = new System.Drawing.Point(0, 0);
            panelPendingLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelPendingLogs.Name = "panelPendingLogs";
            panelPendingLogs.Size = new System.Drawing.Size(1557, 690);
            panelPendingLogs.TabIndex = 0;
            // 
            // gridPendingLogs
            // 
            gridPendingLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            gridPendingLogs.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridPendingLogs.Location = new System.Drawing.Point(2, 2);
            gridPendingLogs.MainView = gridViewPendingLogs;
            gridPendingLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridPendingLogs.Name = "gridPendingLogs";
            gridPendingLogs.Size = new System.Drawing.Size(1553, 686);
            gridPendingLogs.TabIndex = 0;
            gridPendingLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewPendingLogs });
            // 
            // gridViewPendingLogs
            // 
            gridViewPendingLogs.DetailHeight = 565;
            gridViewPendingLogs.GridControl = gridPendingLogs;
            gridViewPendingLogs.Name = "gridViewPendingLogs";
            gridViewPendingLogs.OptionsEditForm.PopupEditFormWidth = 1200;
            // 
            // notificationTimer
            // 
            notificationTimer.Interval = 5000;
            notificationTimer.Tick += NotificationTimer_Tick;
            // 
            // alertControl
            // 
            alertControl.AutoFormDelay = 5000;
            alertControl.ShowPinButton = false;
            // 
            // labelCurrentCard
            // 
            labelCurrentCard.Location = new System.Drawing.Point(29, 209);
            labelCurrentCard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            labelCurrentCard.Name = "labelCurrentCard";
            labelCurrentCard.Size = new System.Drawing.Size(118, 21);
            labelCurrentCard.TabIndex = 3;
            labelCurrentCard.Text = "Текущая карта: -";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1559, 727);
            Controls.Add(xtraTabControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Система контроля доступа";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)xtraTabControl).EndInit();
            xtraTabControl.ResumeLayout(false);
            tabPass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelPass).EndInit();
            panelPass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelEmployeeInfo).EndInit();
            panelEmployeeInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureEditEmployee.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelRecentPasses).EndInit();
            panelRecentPasses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridRecentPasses).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRecentPasses).EndInit();
            tabReaderSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelReaderSettings).EndInit();
            panelReaderSettings.ResumeLayout(false);
            panelReaderSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxReaders.Properties).EndInit();
            tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelHistory).EndInit();
            panelHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelHistoryFilter).EndInit();
            panelHistoryFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewHistory).EndInit();
            tabNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelNotifications).EndInit();
            panelNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelNotificationsFilter).EndInit();
            panelNotificationsFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridNotifications).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewNotifications).EndInit();
            tabPendingLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelPendingLogs).EndInit();
            panelPendingLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridPendingLogs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPendingLogs).EndInit();
            ResumeLayout(false);

            this.IconOptions.ShowIcon = false;
        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage tabPass;
        private DevExpress.XtraTab.XtraTabPage tabHistory;
        private DevExpress.XtraTab.XtraTabPage tabNotifications;
        private DevExpress.XtraTab.XtraTabPage tabPendingLogs;
        private DevExpress.XtraTab.XtraTabPage tabReaderSettings;
        private System.Windows.Forms.Timer notificationTimer;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private DevExpress.XtraEditors.PanelControl panelPass;
        private DevExpress.XtraEditors.PanelControl panelEmployeeInfo;
        private DevExpress.XtraEditors.PictureEdit pictureEditEmployee;
        private DevExpress.XtraEditors.LabelControl labelEmployeeName;
        private DevExpress.XtraEditors.LabelControl labelDepartment;
        private DevExpress.XtraEditors.LabelControl labelAccessStatus;
        private DevExpress.XtraEditors.SimpleButton buttonManualInput;
        private DevExpress.XtraEditors.PanelControl panelRecentPasses;
        private DevExpress.XtraGrid.GridControl gridRecentPasses;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRecentPasses;
        private DevExpress.XtraEditors.PanelControl panelHistory;
        private DevExpress.XtraEditors.PanelControl panelHistoryFilter;
        private DevExpress.XtraEditors.SimpleButton buttonRefresh;
        private DevExpress.XtraGrid.GridControl gridHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHistory;
        private DevExpress.XtraEditors.PanelControl panelNotifications;
        private DevExpress.XtraEditors.PanelControl panelNotificationsFilter;
        private DevExpress.XtraEditors.SimpleButton buttonMarkAsRead;
        private DevExpress.XtraGrid.GridControl gridNotifications;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNotifications;
        private DevExpress.XtraEditors.PanelControl panelPendingLogs;
        private DevExpress.XtraGrid.GridControl gridPendingLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPendingLogs;
        private DevExpress.XtraEditors.PanelControl panelReaderSettings;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxReaders;
        private DevExpress.XtraEditors.SimpleButton buttonStartReader;
        private DevExpress.XtraEditors.SimpleButton buttonStopReader;
        private DevExpress.XtraEditors.LabelControl labelReaderStatus;
        private DevExpress.XtraEditors.LabelControl labelCurrentCard;
    }
}