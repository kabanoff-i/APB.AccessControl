namespace APB.AccessControl.ManageApp.Controls
{
    partial class NotificationControl
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
            gridControlNotifications = new DevExpress.XtraGrid.GridControl();
            gridViewNotifications = new DevExpress.XtraGrid.Views.Grid.GridView();
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnAdd = new DevExpress.XtraBars.BarButtonItem();
            btnEdit = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)gridControlNotifications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewNotifications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            SuspendLayout();
            // 
            // gridControlNotifications
            // 
            gridControlNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlNotifications.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridControlNotifications.Location = new System.Drawing.Point(0, 223);
            gridControlNotifications.MainView = gridViewNotifications;
            gridControlNotifications.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridControlNotifications.Name = "gridControlNotifications";
            gridControlNotifications.Size = new System.Drawing.Size(1200, 504);
            gridControlNotifications.TabIndex = 0;
            gridControlNotifications.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewNotifications });
            // 
            // gridViewNotifications
            // 
            gridViewNotifications.DetailHeight = 565;
            gridViewNotifications.GridControl = gridControlNotifications;
            gridViewNotifications.Name = "gridViewNotifications";
            gridViewNotifications.OptionsBehavior.Editable = false;
            gridViewNotifications.OptionsEditForm.PopupEditFormWidth = 1200;
            // 
            // ribbonControl
            // 
            ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(45, 48, 45, 48);
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, btnAdd, btnEdit, btnDelete, btnRefresh });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ribbonControl.MaxItemId = 5;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.OptionsMenuMinWidth = 495;
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage });
            ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            ribbonControl.ShowPageKeyTipsMode = DevExpress.XtraBars.Ribbon.ShowPageKeyTipsMode.Hide;
            ribbonControl.ShowQatLocationSelector = false;
            ribbonControl.ShowToolbarCustomizeItem = false;
            ribbonControl.Size = new System.Drawing.Size(1200, 223);
            ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnAdd
            // 
            btnAdd.Caption = "Добавить";
            btnAdd.Id = 1;
            btnAdd.ImageOptions.SvgImage = Properties.Resources.actions_add4;
            btnAdd.Name = "btnAdd";
            btnAdd.ItemClick += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Caption = "Редактировать";
            btnEdit.Id = 2;
            btnEdit.ImageOptions.SvgImage = Properties.Resources.editnames4;
            btnEdit.Name = "btnEdit";
            btnEdit.ItemClick += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Caption = "Удалить";
            btnDelete.Id = 3;
            btnDelete.ImageOptions.SvgImage = Properties.Resources.actions_trash4;
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Caption = "Обновить";
            btnRefresh.Id = 4;
            btnRefresh.ImageOptions.SvgImage = Properties.Resources.actions_refresh3;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ItemClick += btnRefresh_Click;
            // 
            // ribbonPage
            // 
            ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup });
            ribbonPage.Name = "ribbonPage";
            ribbonPage.Text = "Уведомления";
            // 
            // ribbonPageGroup
            // 
            ribbonPageGroup.ItemLinks.Add(btnAdd);
            ribbonPageGroup.ItemLinks.Add(btnEdit);
            ribbonPageGroup.ItemLinks.Add(btnDelete);
            ribbonPageGroup.ItemLinks.Add(btnRefresh);
            ribbonPageGroup.Name = "ribbonPageGroup";
            ribbonPageGroup.Text = "Действия";
            // 
            // NotificationControl
            // 
            Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(gridControlNotifications);
            Controls.Add(ribbonControl);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "NotificationControl";
            Size = new System.Drawing.Size(1200, 727);
            ((System.ComponentModel.ISupportInitialize)gridControlNotifications).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewNotifications).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlNotifications;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNotifications;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
    }
} 