namespace APB.AccessControl.ManageApp.Controls
{
    partial class AccessLogControl
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            gridControlLogs = new DevExpress.XtraGrid.GridControl();
            gridViewLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            btnFilter = new DevExpress.XtraBars.BarButtonItem();
            btnExport = new DevExpress.XtraBars.BarButtonItem();
            ribPageLogs = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlLogs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewLogs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            SuspendLayout();
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(gridControlLogs);
            layoutControl.Controls.Add(lblStatus);
            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl.Location = new System.Drawing.Point(0, 187);
            layoutControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            layoutControl.Name = "layoutControl";
            layoutControl.Root = layoutControlGroup;
            layoutControl.Size = new System.Drawing.Size(1809, 794);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl1";
            // 
            // gridControlLogs
            // 
            gridLevelNode1.RelationName = "Level1";
            gridControlLogs.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
            gridControlLogs.Location = new System.Drawing.Point(12, 12);
            gridControlLogs.MainView = gridViewLogs;
            gridControlLogs.MenuManager = ribbonControl;
            gridControlLogs.Name = "gridControlLogs";
            gridControlLogs.Size = new System.Drawing.Size(1785, 745);
            gridControlLogs.TabIndex = 4;
            gridControlLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewLogs });
            // 
            // gridViewLogs
            // 
            gridViewLogs.DetailHeight = 367;
            gridViewLogs.GridControl = gridControlLogs;
            gridViewLogs.Name = "gridViewLogs";
            gridViewLogs.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridViewLogs.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridViewLogs.OptionsBehavior.Editable = false;
            gridViewLogs.OptionsBehavior.ReadOnly = true;
            // 
            // ribbonControl
            // 
            ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(30, 31, 30, 31);
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, btnRefresh, btnFilter, btnExport });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.MaxItemId = 9;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribPageLogs });
            ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            ribbonControl.Size = new System.Drawing.Size(1809, 187);
            ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnRefresh
            // 
            btnRefresh.Caption = "Обновить";
            btnRefresh.Id = 1;
            btnRefresh.ImageOptions.SvgImage = Properties.Resources.actions_refresh;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ItemClick += btnRefresh_Click;
            // 
            // btnFilter
            // 
            btnFilter.Caption = "Фильтр";
            btnFilter.Id = 2;
            btnFilter.ImageOptions.SvgImage = Properties.Resources.filterquery;
            btnFilter.Name = "btnFilter";
            btnFilter.ItemClick += btnFilter_Click;
            // 
            // btnExport
            // 
            btnExport.Caption = "Экспорт";
            btnExport.Id = 3;
            btnExport.ImageOptions.SvgImage = Properties.Resources.exportfile;
            btnExport.Name = "btnExport";
            // 
            // ribPageLogs
            // 
            ribPageLogs.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribGroupActions });
            ribPageLogs.Name = "ribPageLogs";
            ribPageLogs.Text = "Логи доступа";
            // 
            // ribGroupActions
            // 
            ribGroupActions.ItemLinks.Add(btnFilter);
            ribGroupActions.ItemLinks.Add(btnRefresh);
            ribGroupActions.ItemLinks.Add(btnExport);
            ribGroupActions.Name = "ribGroupActions";
            ribGroupActions.Text = "Действия";
            // 
            // lblStatus
            // 
            lblStatus.Appearance.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            lblStatus.Appearance.Options.UseBackColor = true;
            lblStatus.Appearance.Options.UseTextOptions = true;
            lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblStatus.Location = new System.Drawing.Point(12, 761);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(1785, 21);
            lblStatus.StyleController = layoutControl;
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Нет данных";
            // 
            // layoutControlGroup
            // 
            layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup.GroupBordersVisible = false;
            layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2 });
            layoutControlGroup.Name = "layoutControlGroup";
            layoutControlGroup.Size = new System.Drawing.Size(1809, 794);
            layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControlLogs;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(1789, 749);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = lblStatus;
            layoutControlItem2.Location = new System.Drawing.Point(0, 749);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(1789, 25);
            layoutControlItem2.TextVisible = false;
            // 
            // AccessLogControl
            // 
            Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl);
            Controls.Add(ribbonControl);
            Name = "AccessLogControl";
            Size = new System.Drawing.Size(1809, 981);
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlLogs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewLogs).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraGrid.GridControl gridControlLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLogs;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnFilter;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribPageLogs;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribGroupActions;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
} 