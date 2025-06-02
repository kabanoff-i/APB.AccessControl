namespace APB.AccessControl.ManageApp.Controls
{
    partial class AccessRuleManagementControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessRuleManagementControl));
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            gridControlRules = new DevExpress.XtraGrid.GridControl();
            gridViewRules = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colAccessGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            colAccessPointName = new DevExpress.XtraGrid.Columns.GridColumn();
            colAllowedTimeStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colAllowedTimeEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            colDaysOfWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            colSpecificDates = new DevExpress.XtraGrid.Columns.GridColumn();
            colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnAdd = new DevExpress.XtraBars.BarButtonItem();
            btnEdit = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            btnCopy = new DevExpress.XtraBars.BarButtonItem();
            btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlRules).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRules).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(gridControlRules);
            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl.Location = new System.Drawing.Point(0, 187);
            layoutControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            layoutControl.Name = "layoutControl";
            layoutControl.Root = layoutControlGroup;
            layoutControl.Size = new System.Drawing.Size(1809, 747);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl1";
            // 
            // gridControlRules
            // 
            gridControlRules.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            gridControlRules.Location = new System.Drawing.Point(2, 2);
            gridControlRules.MainView = gridViewRules;
            gridControlRules.Margin = new System.Windows.Forms.Padding(0);
            gridControlRules.MenuManager = ribbonControl;
            gridControlRules.Name = "gridControlRules";
            gridControlRules.Size = new System.Drawing.Size(1805, 743);
            gridControlRules.TabIndex = 4;
            gridControlRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewRules });
            // 
            // gridViewRules
            // 
            gridViewRules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colAccessGroupName, colAccessPointName, colAllowedTimeStart, colAllowedTimeEnd, colDaysOfWeek, colSpecificDates, colStartDate, colEndDate, colIsActive });
            gridViewRules.DetailHeight = 565;
            gridViewRules.GridControl = gridControlRules;
            gridViewRules.Name = "gridViewRules";
            gridViewRules.OptionsEditForm.PopupEditFormWidth = 1050;
            gridViewRules.OptionsView.ColumnAutoWidth = false;
            gridViewRules.OptionsView.RowAutoHeight = true;
            // 
            // colId
            // 
            colId.Caption = "ID";
            colId.FieldName = "Id";
            colId.MinWidth = 30;
            colId.Name = "colId";
            colId.Width = 60;
            // 
            // colAccessGroupName
            // 
            colAccessGroupName.Caption = "Группа доступа";
            colAccessGroupName.FieldName = "AccessGroupName";
            colAccessGroupName.MinWidth = 30;
            colAccessGroupName.Name = "colAccessGroupName";
            colAccessGroupName.OptionsColumn.AllowEdit = false;
            colAccessGroupName.OptionsColumn.ReadOnly = true;
            colAccessGroupName.Visible = true;
            colAccessGroupName.VisibleIndex = 0;
            colAccessGroupName.Width = 200;
            // 
            // colAccessPointName
            // 
            colAccessPointName.Caption = "Точка доступа";
            colAccessPointName.FieldName = "AccessPointName";
            colAccessPointName.MinWidth = 30;
            colAccessPointName.Name = "colAccessPointName";
            colAccessPointName.OptionsColumn.AllowEdit = false;
            colAccessPointName.OptionsColumn.ReadOnly = true;
            colAccessPointName.Visible = true;
            colAccessPointName.VisibleIndex = 1;
            colAccessPointName.Width = 200;
            // 
            // colAllowedTimeStart
            // 
            colAllowedTimeStart.Caption = "Время начала";
            colAllowedTimeStart.DisplayFormat.FormatString = "HH:mm";
            colAllowedTimeStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colAllowedTimeStart.FieldName = "AllowedTimeStart";
            colAllowedTimeStart.MinWidth = 30;
            colAllowedTimeStart.Name = "colAllowedTimeStart";
            colAllowedTimeStart.OptionsColumn.AllowEdit = false;
            colAllowedTimeStart.OptionsColumn.ReadOnly = true;
            colAllowedTimeStart.Visible = true;
            colAllowedTimeStart.VisibleIndex = 2;
            colAllowedTimeStart.Width = 100;
            // 
            // colAllowedTimeEnd
            // 
            colAllowedTimeEnd.Caption = "Время окончания";
            colAllowedTimeEnd.DisplayFormat.FormatString = "HH:mm";
            colAllowedTimeEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colAllowedTimeEnd.FieldName = "AllowedTimeEnd";
            colAllowedTimeEnd.MinWidth = 30;
            colAllowedTimeEnd.Name = "colAllowedTimeEnd";
            colAllowedTimeEnd.OptionsColumn.AllowEdit = false;
            colAllowedTimeEnd.OptionsColumn.ReadOnly = true;
            colAllowedTimeEnd.Visible = true;
            colAllowedTimeEnd.VisibleIndex = 3;
            colAllowedTimeEnd.Width = 100;
            // 
            // colDaysOfWeek
            // 
            colDaysOfWeek.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            colDaysOfWeek.Caption = "Дни недели";
            colDaysOfWeek.FieldName = "DaysOfWeek";
            colDaysOfWeek.MinWidth = 30;
            colDaysOfWeek.Name = "colDaysOfWeek";
            colDaysOfWeek.OptionsColumn.AllowEdit = false;
            colDaysOfWeek.OptionsColumn.ReadOnly = true;
            colDaysOfWeek.Visible = true;
            colDaysOfWeek.VisibleIndex = 4;
            colDaysOfWeek.Width = 150;
            // 
            // colSpecificDates
            // 
            colSpecificDates.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            colSpecificDates.Caption = "Специальные даты";
            colSpecificDates.FieldName = "SpecificDates";
            colSpecificDates.MinWidth = 30;
            colSpecificDates.Name = "colSpecificDates";
            colSpecificDates.OptionsColumn.AllowEdit = false;
            colSpecificDates.OptionsColumn.ReadOnly = true;
            colSpecificDates.Visible = true;
            colSpecificDates.VisibleIndex = 5;
            colSpecificDates.Width = 180;
            // 
            // colStartDate
            // 
            colStartDate.Caption = "Дата начала";
            colStartDate.DisplayFormat.FormatString = "d";
            colStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colStartDate.FieldName = "StartDate";
            colStartDate.MinWidth = 30;
            colStartDate.Name = "colStartDate";
            colStartDate.OptionsColumn.AllowEdit = false;
            colStartDate.OptionsColumn.ReadOnly = true;
            colStartDate.Visible = true;
            colStartDate.VisibleIndex = 6;
            colStartDate.Width = 100;
            // 
            // colEndDate
            // 
            colEndDate.Caption = "Дата окончания";
            colEndDate.DisplayFormat.FormatString = "d";
            colEndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colEndDate.FieldName = "EndDate";
            colEndDate.MinWidth = 30;
            colEndDate.Name = "colEndDate";
            colEndDate.OptionsColumn.AllowEdit = false;
            colEndDate.OptionsColumn.ReadOnly = true;
            colEndDate.Visible = true;
            colEndDate.VisibleIndex = 7;
            colEndDate.Width = 100;
            // 
            // colIsActive
            // 
            colIsActive.Caption = "Активно";
            colIsActive.FieldName = "IsActive";
            colIsActive.MinWidth = 30;
            colIsActive.Name = "colIsActive";
            colIsActive.OptionsColumn.AllowEdit = false;
            colIsActive.OptionsColumn.ReadOnly = true;
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 8;
            colIsActive.Width = 80;
            // 
            // ribbonControl
            // 
            ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(45, 48, 45, 48);
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, btnAdd, btnEdit, btnDelete, btnCopy, btnRefresh });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ribbonControl.MaxItemId = 6;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.OptionsMenuMinWidth = 495;
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            ribbonControl.ShowQatLocationSelector = false;
            ribbonControl.ShowToolbarCustomizeItem = false;
            ribbonControl.Size = new System.Drawing.Size(1809, 187);
            ribbonControl.Toolbar.ShowCustomizeItem = false;
            ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnAdd
            // 
            btnAdd.Caption = "Добавить";
            btnAdd.Id = 1;
            btnAdd.ImageOptions.SvgImage = global::DevExpress.Images.ImageResourceCache.Default.GetSvgImage("actions/add");
            btnAdd.Name = "btnAdd";
            btnAdd.ItemClick += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Caption = "Изменить";
            btnEdit.Enabled = false;
            btnEdit.Id = 2;
            btnEdit.ImageOptions.SvgImage = global::DevExpress.Images.ImageResourceCache.Default.GetSvgImage("actions/edit");
            btnEdit.Name = "btnEdit";
            btnEdit.ItemClick += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Caption = "Удалить";
            btnDelete.Enabled = false;
            btnDelete.Id = 3;
            btnDelete.ImageOptions.SvgImage = global::DevExpress.Images.ImageResourceCache.Default.GetSvgImage("actions/delete");
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += btnDelete_Click;
            // 
            // btnCopy
            // 
            btnCopy.Caption = "Копировать";
            btnCopy.Enabled = false;
            btnCopy.Id = 4;
            btnCopy.ImageOptions.SvgImage = global::DevExpress.Images.ImageResourceCache.Default.GetSvgImage("actions/copy");
            btnCopy.Name = "btnCopy";
            btnCopy.ItemClick += btnCopy_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Caption = "Обновить";
            btnRefresh.Id = 5;
            btnRefresh.ImageOptions.SvgImage = global::DevExpress.Images.ImageResourceCache.Default.GetSvgImage("actions/refresh");
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ItemClick += btnRefresh_Click;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Главная";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.AllowTextClipping = false;
            ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            ribbonPageGroup1.ItemLinks.Add(btnAdd);
            ribbonPageGroup1.ItemLinks.Add(btnEdit);
            ribbonPageGroup1.ItemLinks.Add(btnDelete);
            ribbonPageGroup1.ItemLinks.Add(btnRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Операции";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.AllowTextClipping = false;
            ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            ribbonPageGroup2.ItemLinks.Add(btnCopy);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Специальные";
            // 
            // layoutControlGroup
            // 
            layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup.GroupBordersVisible = false;
            layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            layoutControlGroup.Name = "Root";
            layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            layoutControlGroup.Size = new System.Drawing.Size(1809, 747);
            layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControlRules;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(1809, 747);
            layoutControlItem1.TextVisible = false;
            // 
            // AccessRuleManagementControl
            // 
            Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl);
            Controls.Add(ribbonControl);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "AccessRuleManagementControl";
            Size = new System.Drawing.Size(1809, 934);
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlRules).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRules).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnCopy;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.GridControl gridControlRules;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRules;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAccessGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccessPointName;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowedTimeStart;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowedTimeEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysOfWeek;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecificDates;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
    }
} 