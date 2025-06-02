namespace APB.AccessControl.ManageApp.Controls
{
    partial class AccessPointManagementControl
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
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            gridControlAccessPoints = new DevExpress.XtraGrid.GridControl();
            gridViewAccessPoints = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            colIpAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            colAccessPointTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsOnline = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastHeartbeatAt = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnAdd = new DevExpress.XtraBars.BarButtonItem();
            btnEdit = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            btnSendNotification = new DevExpress.XtraBars.BarButtonItem();
            btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlAccessPoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAccessPoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(gridControlAccessPoints);
            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl.Location = new System.Drawing.Point(0, 187);
            layoutControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            layoutControl.Name = "layoutControl";
            layoutControl.Root = layoutControlGroup;
            layoutControl.Size = new System.Drawing.Size(1825, 706);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl1";
            // 
            // gridControlAccessPoints
            // 
            gridControlAccessPoints.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            gridControlAccessPoints.Location = new System.Drawing.Point(12, 12);
            gridControlAccessPoints.MainView = gridViewAccessPoints;
            gridControlAccessPoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridControlAccessPoints.MenuManager = ribbonControl;
            gridControlAccessPoints.Name = "gridControlAccessPoints";
            gridControlAccessPoints.Size = new System.Drawing.Size(1801, 682);
            gridControlAccessPoints.TabIndex = 4;
            gridControlAccessPoints.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewAccessPoints });
            // 
            // gridViewAccessPoints
            // 
            gridViewAccessPoints.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colName, colLocation, colIpAddress, colAccessPointTypeName, colIsActive, colIsOnline, colLastHeartbeatAt });
            gridViewAccessPoints.DetailHeight = 565;
            gridViewAccessPoints.GridControl = gridControlAccessPoints;
            gridViewAccessPoints.Name = "gridViewAccessPoints";
            gridViewAccessPoints.OptionsEditForm.PopupEditFormWidth = 1200;
            // 
            // colId
            // 
            colId.Caption = "ID";
            colId.FieldName = "Id";
            colId.MinWidth = 30;
            colId.Name = "colId";
            // 
            // colName
            // 
            colName.Caption = "Название";
            colName.FieldName = "Name";
            colName.MinWidth = 30;
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 0;
            colName.Width = 300;
            // 
            // colLocation
            // 
            colLocation.Caption = "Локация";
            colLocation.FieldName = "Location";
            colLocation.MinWidth = 30;
            colLocation.Name = "colLocation";
            colLocation.Visible = true;
            colLocation.VisibleIndex = 1;
            colLocation.Width = 300;
            // 
            // colIpAddress
            // 
            colIpAddress.Caption = "IP-адрес";
            colIpAddress.FieldName = "IpAddress";
            colIpAddress.MinWidth = 30;
            colIpAddress.Name = "colIpAddress";
            colIpAddress.Visible = true;
            colIpAddress.VisibleIndex = 2;
            colIpAddress.Width = 180;
            // 
            // colAccessPointTypeName
            // 
            colAccessPointTypeName.Caption = "Тип";
            colAccessPointTypeName.FieldName = "AccessPointTypeName";
            colAccessPointTypeName.MinWidth = 30;
            colAccessPointTypeName.Name = "colAccessPointTypeName";
            colAccessPointTypeName.Visible = true;
            colAccessPointTypeName.VisibleIndex = 3;
            colAccessPointTypeName.Width = 180;
            // 
            // colIsActive
            // 
            colIsActive.Caption = "Активна";
            colIsActive.FieldName = "IsActive";
            colIsActive.MinWidth = 30;
            colIsActive.Name = "colIsActive";
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 4;
            colIsActive.Width = 90;
            // 
            // colIsOnline
            // 
            colIsOnline.Caption = "Онлайн";
            colIsOnline.FieldName = "IsOnline";
            colIsOnline.MinWidth = 30;
            colIsOnline.Name = "colIsOnline";
            colIsOnline.Visible = true;
            colIsOnline.VisibleIndex = 5;
            colIsOnline.Width = 90;
            // 
            // colLastHeartbeatAt
            // 
            colLastHeartbeatAt.Caption = "Последний сигнал";
            colLastHeartbeatAt.DisplayFormat.FormatString = "g";
            colLastHeartbeatAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colLastHeartbeatAt.FieldName = "LastHeartbeatAt";
            colLastHeartbeatAt.MinWidth = 30;
            colLastHeartbeatAt.Name = "colLastHeartbeatAt";
            colLastHeartbeatAt.Visible = true;
            colLastHeartbeatAt.VisibleIndex = 6;
            colLastHeartbeatAt.Width = 225;
            // 
            // ribbonControl
            // 
            ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(45, 48, 45, 48);
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, btnAdd, btnEdit, btnDelete, btnSendNotification, btnRefresh });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ribbonControl.MaxItemId = 7;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.OptionsMenuMinWidth = 495;
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            ribbonControl.ShowQatLocationSelector = false;
            ribbonControl.ShowToolbarCustomizeItem = false;
            ribbonControl.Size = new System.Drawing.Size(1825, 187);
            ribbonControl.Toolbar.ShowCustomizeItem = false;
            ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnAdd
            // 
            btnAdd.Caption = "Добавить";
            btnAdd.Id = 1;
            btnAdd.ImageOptions.SvgImage = Properties.Resources.actions_add1;
            btnAdd.Name = "btnAdd";
            btnAdd.ItemClick += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Caption = "Изменить";
            btnEdit.Enabled = false;
            btnEdit.Id = 2;
            btnEdit.ImageOptions.SvgImage = Properties.Resources.editnames1;
            btnEdit.Name = "btnEdit";
            btnEdit.ItemClick += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Caption = "Удалить";
            btnDelete.Enabled = false;
            btnDelete.Id = 3;
            btnDelete.ImageOptions.SvgImage = Properties.Resources.actions_trash1;
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += btnDelete_Click;
            // 
            // btnSendNotification
            // 
            btnSendNotification.Caption = "Отправить\r\nуведомление";
            btnSendNotification.Enabled = false;
            btnSendNotification.Id = 5;
            btnSendNotification.ImageOptions.SvgImage = Properties.Resources.bo_notifications;
            btnSendNotification.Name = "btnSendNotification";
            btnSendNotification.ItemClick += btnSendNotification_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Caption = "Обновить";
            btnRefresh.Id = 6;
            btnRefresh.ImageOptions.SvgImage = Properties.Resources.actions_refresh1;
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
            ribbonPageGroup2.ItemLinks.Add(btnSendNotification);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Действия";
            // 
            // layoutControlGroup
            // 
            layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup.GroupBordersVisible = false;
            layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            layoutControlGroup.Name = "Root";
            layoutControlGroup.Size = new System.Drawing.Size(1825, 706);
            layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControlAccessPoints;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(1805, 686);
            layoutControlItem1.TextVisible = false;
            // 
            // AccessPointManagementControl
            // 
            Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl);
            Controls.Add(ribbonControl);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "AccessPointManagementControl";
            Size = new System.Drawing.Size(1825, 893);
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlAccessPoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAccessPoints).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnSendNotification;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.GridControl gridControlAccessPoints;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAccessPoints;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colIpAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colAccessPointTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colIsOnline;
        private DevExpress.XtraGrid.Columns.GridColumn colLastHeartbeatAt;
    }
} 