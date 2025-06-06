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
            layoutControlHistory = new DevExpress.XtraLayout.LayoutControl();
            dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            dateEditTo = new DevExpress.XtraEditors.DateEdit();
            buttonRefresh = new DevExpress.XtraEditors.SimpleButton();
            labelTo = new DevExpress.XtraEditors.LabelControl();
            layoutControlGroupHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemDateFrom = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemDateTo = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
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
            tabFormContentContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlHistory).BeginInit();
            layoutControlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dateEditFrom.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditFrom.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditTo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditTo.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemDateFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemDateTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemRefresh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemGrid).BeginInit();
            tabFormContentContainer4.SuspendLayout();
            SuspendLayout();
            // 
            // buttonStopReader
            // 
            buttonStopReader.Appearance.BackColor = Color.FromArgb(0, 120, 215);
            buttonStopReader.Appearance.Font = new Font("Segoe UI", 9F);
            buttonStopReader.Appearance.ForeColor = Color.White;
            buttonStopReader.Appearance.Options.UseBackColor = true;
            buttonStopReader.Appearance.Options.UseFont = true;
            buttonStopReader.Appearance.Options.UseForeColor = true;
            buttonStopReader.Enabled = false;
            buttonStopReader.Location = new Point(18, 576);
            buttonStopReader.LookAndFeel.SkinName = "Office 2019 Colorful";
            buttonStopReader.LookAndFeel.UseDefaultLookAndFeel = false;
            buttonStopReader.Margin = new Padding(4);
            buttonStopReader.Name = "buttonStopReader";
            buttonStopReader.Size = new Size(142, 34);
            buttonStopReader.TabIndex = 8;
            buttonStopReader.Text = "Остановить";
            // 
            // buttonStartReader
            // 
            buttonStartReader.Appearance.BackColor = Color.FromArgb(0, 120, 215);
            buttonStartReader.Appearance.Font = new Font("Segoe UI", 9F);
            buttonStartReader.Appearance.ForeColor = Color.White;
            buttonStartReader.Appearance.Options.UseBackColor = true;
            buttonStartReader.Appearance.Options.UseFont = true;
            buttonStartReader.Appearance.Options.UseForeColor = true;
            buttonStartReader.Location = new Point(176, 576);
            buttonStartReader.LookAndFeel.SkinName = "Office 2019 Colorful";
            buttonStartReader.LookAndFeel.UseDefaultLookAndFeel = false;
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
            comboBoxReaders.Properties.Appearance.BackColor = Color.White;
            comboBoxReaders.Properties.Appearance.BorderColor = Color.FromArgb(200, 200, 200);
            comboBoxReaders.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            comboBoxReaders.Properties.Appearance.Options.UseBackColor = true;
            comboBoxReaders.Properties.Appearance.Options.UseBorderColor = true;
            comboBoxReaders.Properties.Appearance.Options.UseFont = true;
            comboBoxReaders.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxReaders.Properties.LookAndFeel.SkinName = "Office 2019 Colorful";
            comboBoxReaders.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            comboBoxReaders.Size = new Size(300, 32);
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
            labelReaderStatus.Appearance.Font = new Font("Segoe UI", 9F);
            labelReaderStatus.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            labelReaderStatus.Appearance.Options.UseFont = true;
            labelReaderStatus.Appearance.Options.UseForeColor = true;
            labelReaderStatus.Location = new Point(18, 181);
            labelReaderStatus.LookAndFeel.SkinName = "Office 2019 Colorful";
            labelReaderStatus.LookAndFeel.UseDefaultLookAndFeel = false;
            labelReaderStatus.Margin = new Padding(4);
            labelReaderStatus.Name = "labelReaderStatus";
            labelReaderStatus.Size = new Size(161, 25);
            labelReaderStatus.TabIndex = 4;
            labelReaderStatus.Text = "Статус считывателя:";
            // 
            // labelAccessStatus
            // 
            labelAccessStatus.Appearance.Font = new Font("Segoe UI", 9F);
            labelAccessStatus.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            labelAccessStatus.Appearance.Options.UseFont = true;
            labelAccessStatus.Appearance.Options.UseForeColor = true;
            labelAccessStatus.Location = new Point(18, 140);
            labelAccessStatus.LookAndFeel.SkinName = "Office 2019 Colorful";
            labelAccessStatus.LookAndFeel.UseDefaultLookAndFeel = false;
            labelAccessStatus.Margin = new Padding(4);
            labelAccessStatus.Name = "labelAccessStatus";
            labelAccessStatus.Size = new Size(124, 25);
            labelAccessStatus.TabIndex = 3;
            labelAccessStatus.Text = "Статус доступа:";
            // 
            // labelDepartment
            // 
            labelDepartment.Appearance.Font = new Font("Segoe UI", 9F);
            labelDepartment.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            labelDepartment.Appearance.Options.UseFont = true;
            labelDepartment.Appearance.Options.UseForeColor = true;
            labelDepartment.Location = new Point(18, 99);
            labelDepartment.LookAndFeel.SkinName = "Office 2019 Colorful";
            labelDepartment.LookAndFeel.UseDefaultLookAndFeel = false;
            labelDepartment.Margin = new Padding(4);
            labelDepartment.Name = "labelDepartment";
            labelDepartment.Size = new Size(53, 25);
            labelDepartment.TabIndex = 2;
            labelDepartment.Text = "Отдел:";
            // 
            // labelEmployeeName
            // 
            labelEmployeeName.Appearance.Font = new Font("Segoe UI", 9F);
            labelEmployeeName.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            labelEmployeeName.Appearance.Options.UseFont = true;
            labelEmployeeName.Appearance.Options.UseForeColor = true;
            labelEmployeeName.Location = new Point(18, 58);
            labelEmployeeName.LookAndFeel.SkinName = "Office 2019 Colorful";
            labelEmployeeName.LookAndFeel.UseDefaultLookAndFeel = false;
            labelEmployeeName.Margin = new Padding(4);
            labelEmployeeName.Name = "labelEmployeeName";
            labelEmployeeName.Size = new Size(92, 25);
            labelEmployeeName.TabIndex = 1;
            labelEmployeeName.Text = "Сотрудник:";
            // 
            // labelCurrentCard
            // 
            labelCurrentCard.Appearance.Font = new Font("Segoe UI", 9F);
            labelCurrentCard.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            labelCurrentCard.Appearance.Options.UseFont = true;
            labelCurrentCard.Appearance.Options.UseForeColor = true;
            labelCurrentCard.Location = new Point(18, 18);
            labelCurrentCard.LookAndFeel.SkinName = "Office 2019 Colorful";
            labelCurrentCard.LookAndFeel.UseDefaultLookAndFeel = false;
            labelCurrentCard.Margin = new Padding(4);
            labelCurrentCard.Name = "labelCurrentCard";
            labelCurrentCard.Size = new Size(123, 25);
            labelCurrentCard.TabIndex = 0;
            labelCurrentCard.Text = "Текущая карта:";
            // 
            // gridControlHistory
            // 
            gridControlHistory.Location = new Point(11, 50);
            gridControlHistory.MainView = gridViewHistory;
            gridControlHistory.Name = "gridControlHistory";
            gridControlHistory.Size = new Size(1535, 543);
            gridControlHistory.TabIndex = 0;
            gridControlHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewHistory });
            // 
            // gridViewHistory
            // 
            gridViewHistory.Appearance.EvenRow.BackColor = Color.FromArgb(245, 245, 245);
            gridViewHistory.Appearance.FocusedRow.BackColor = Color.FromArgb(230, 240, 255);
            gridViewHistory.Appearance.FocusedRow.ForeColor = Color.FromArgb(0, 0, 0);
            gridViewHistory.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 240, 240);
            gridViewHistory.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridViewHistory.Appearance.HeaderPanel.ForeColor = Color.FromArgb(64, 64, 64);
            gridViewHistory.Appearance.OddRow.BackColor = Color.White;
            gridViewHistory.Appearance.Row.Font = new Font("Segoe UI", 9F);
            gridViewHistory.DetailHeight = 387;
            gridViewHistory.GridControl = gridControlHistory;
            gridViewHistory.Name = "gridViewHistory";
            gridViewHistory.OptionsBehavior.Editable = false;
            gridViewHistory.OptionsView.ShowAutoFilterRow = true;
            gridViewHistory.OptionsView.ShowIndicator = false;
            // 
            // gridControlNotifications
            // 
            gridControlNotifications.Dock = DockStyle.Fill;
            gridControlNotifications.EmbeddedNavigator.Margin = new Padding(4);
            gridControlNotifications.Location = new Point(0, 0);
            gridControlNotifications.LookAndFeel.SkinName = "Office 2019 Colorful";
            gridControlNotifications.LookAndFeel.UseDefaultLookAndFeel = false;
            gridControlNotifications.MainView = gridViewNotifications;
            gridControlNotifications.Margin = new Padding(4);
            gridControlNotifications.Name = "gridControlNotifications";
            gridControlNotifications.Size = new Size(1557, 605);
            gridControlNotifications.TabIndex = 0;
            gridControlNotifications.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewNotifications });
            // 
            // gridViewNotifications
            // 
            gridViewNotifications.Appearance.EvenRow.BackColor = Color.FromArgb(245, 245, 245);
            gridViewNotifications.GridControl = gridControlNotifications;
            gridViewNotifications.Name = "gridViewNotifications";
            gridViewNotifications.OptionsView.EnableAppearanceEvenRow = true;
            gridViewNotifications.OptionsView.EnableAppearanceOddRow = true;
            gridViewNotifications.OptionsView.ShowAutoFilterRow = true;
            gridViewNotifications.OptionsView.ShowFooter = true;
            gridViewNotifications.OptionsView.ShowGroupPanel = false;
            gridViewNotifications.OptionsView.ShowIndicator = false;
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
            tabFormControl1.SelectedPage = tabFormPageHistory;
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
            tabFormPageReaderSettings.Visible = false;
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
            labelReaderStatusSettings.Size = new Size(153, 19);
            labelReaderStatusSettings.TabIndex = 0;
            labelReaderStatusSettings.Text = "Статус считывателя:";
            // 
            // tabFormPageHistory
            // 
            tabFormPageHistory.ContentContainer = tabFormContentContainer3;
            tabFormPageHistory.Name = "tabFormPageHistory";
            tabFormPageHistory.Text = "История проходов";
            // 
            // tabFormContentContainer3
            // 
            tabFormContentContainer3.Controls.Add(layoutControlHistory);
            tabFormContentContainer3.Dock = DockStyle.Fill;
            tabFormContentContainer3.Location = new Point(0, 86);
            tabFormContentContainer3.Name = "tabFormContentContainer3";
            tabFormContentContainer3.Size = new Size(1557, 605);
            tabFormContentContainer3.TabIndex = 0;
            // 
            // layoutControlHistory
            // 
            layoutControlHistory.Controls.Add(gridControlHistory);
            layoutControlHistory.Controls.Add(dateEditFrom);
            layoutControlHistory.Controls.Add(dateEditTo);
            layoutControlHistory.Controls.Add(buttonRefresh);
            layoutControlHistory.Controls.Add(labelTo);
            layoutControlHistory.Dock = DockStyle.Fill;
            layoutControlHistory.Location = new Point(0, 0);
            layoutControlHistory.Name = "layoutControlHistory";
            layoutControlHistory.Root = layoutControlGroupHistory;
            layoutControlHistory.Size = new Size(1557, 605);
            layoutControlHistory.TabIndex = 0;
            // 
            // dateEditFrom
            // 
            dateEditFrom.EditValue = null;
            dateEditFrom.Location = new Point(75, 12);
            dateEditFrom.Name = "dateEditFrom";
            dateEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditFrom.Size = new Size(410, 34);
            dateEditFrom.StyleController = layoutControlHistory;
            dateEditFrom.TabIndex = 0;
            // 
            // dateEditTo
            // 
            dateEditTo.EditValue = null;
            dateEditTo.Location = new Point(553, 12);
            dateEditTo.Name = "dateEditTo";
            dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditTo.Size = new Size(408, 34);
            dateEditTo.StyleController = layoutControlHistory;
            dateEditTo.TabIndex = 1;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(965, 12);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(581, 32);
            buttonRefresh.StyleController = layoutControlHistory;
            buttonRefresh.TabIndex = 2;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // labelTo
            // 
            labelTo.Location = new Point(254, 13);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(42, 27);
            labelTo.StyleController = layoutControlHistory;
            labelTo.TabIndex = 4;
            labelTo.Text = "По:";
            // 
            // layoutControlGroupHistory
            // 
            layoutControlGroupHistory.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroupHistory.GroupBordersVisible = false;
            layoutControlGroupHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemDateFrom, layoutControlItemDateTo, layoutControlItemRefresh, layoutControlItemGrid });
            layoutControlGroupHistory.Name = "layoutControlGroupHistory";
            layoutControlGroupHistory.Size = new Size(1557, 605);
            layoutControlGroupHistory.TextVisible = false;
            // 
            // layoutControlItemDateFrom
            // 
            layoutControlItemDateFrom.Control = dateEditFrom;
            layoutControlItemDateFrom.Location = new Point(0, 0);
            layoutControlItemDateFrom.Name = "layoutControlItemDateFrom";
            layoutControlItemDateFrom.Size = new Size(478, 38);
            layoutControlItemDateFrom.Text = "С даты:";
            layoutControlItemDateFrom.TextSize = new Size(52, 21);
            // 
            // layoutControlItemDateTo
            // 
            layoutControlItemDateTo.Control = dateEditTo;
            layoutControlItemDateTo.Location = new Point(478, 0);
            layoutControlItemDateTo.Name = "layoutControlItemDateTo";
            layoutControlItemDateTo.Size = new Size(476, 38);
            layoutControlItemDateTo.Text = "По:";
            layoutControlItemDateTo.TextSize = new Size(52, 21);
            // 
            // layoutControlItemRefresh
            // 
            layoutControlItemRefresh.Control = buttonRefresh;
            layoutControlItemRefresh.Location = new Point(954, 0);
            layoutControlItemRefresh.Name = "layoutControlItemRefresh";
            layoutControlItemRefresh.Size = new Size(585, 38);
            layoutControlItemRefresh.TextVisible = false;
            // 
            // layoutControlItemGrid
            // 
            layoutControlItemGrid.Control = gridControlHistory;
            layoutControlItemGrid.Location = new Point(0, 38);
            layoutControlItemGrid.Name = "layoutControlItemGrid";
            layoutControlItemGrid.Size = new Size(1539, 547);
            layoutControlItemGrid.TextVisible = false;
            // 
            // tabFormPageNotifications
            // 
            tabFormPageNotifications.ContentContainer = tabFormContentContainer4;
            tabFormPageNotifications.Name = "tabFormPageNotifications";
            tabFormPageNotifications.Text = "Уведомления";
            tabFormPageNotifications.Visible = false;
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
            tabFormPagePendingLogs.Visible = false;
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
            Controls.Add(tabFormContentContainer3);
            Controls.Add(tabFormControl1);
            Font = new Font("Segoe UI", 8F);
            IconOptions.ShowIcon = false;
            Name = "MainForm";
            TabFormControl = tabFormControl1;
            Text = "Система контроля доступа";
            Load += MainForm_Load;
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
            tabFormContentContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlHistory).EndInit();
            layoutControlHistory.ResumeLayout(false);
            layoutControlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dateEditFrom.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditFrom.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditTo.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditTo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemDateFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemDateTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemRefresh).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemGrid).EndInit();
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
        private DevExpress.XtraEditors.DateEdit dateEditFrom;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.SimpleButton buttonRefresh;
        private DevExpress.XtraEditors.LabelControl labelTo;
        private DevExpress.XtraLayout.LayoutControl layoutControlHistory;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupHistory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDateTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemGrid;
        private DevExpress.XtraEditors.SimpleButton buttonStopReaderSettings;
        private DevExpress.XtraEditors.SimpleButton buttonStartReaderSettings;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxReadersSettings;
        private DevExpress.XtraEditors.LabelControl labelReaderStatusSettings;
    }
}

