using DevExpress.Images;

namespace APB.AccessControl.ManageApp.Controls
{
    partial class UserManagementControl
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
            gridControlUsers = new DevExpress.XtraGrid.GridControl();
            gridViewUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            btnCreate = new DevExpress.XtraBars.BarButtonItem();
            btnEdit = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            btnChangePassword = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)gridControlUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gridControlUsers
            // 
            gridControlUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlUsers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            gridControlUsers.Location = new System.Drawing.Point(0, 187);
            gridControlUsers.MainView = gridViewUsers;
            gridControlUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridControlUsers.Name = "gridControlUsers";
            gridControlUsers.Size = new System.Drawing.Size(1581, 782);
            gridControlUsers.TabIndex = 0;
            gridControlUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewUsers });
            // 
            // gridViewUsers
            // 
            gridViewUsers.DetailHeight = 565;
            gridViewUsers.GridControl = gridControlUsers;
            gridViewUsers.Name = "gridViewUsers";
            gridViewUsers.OptionsBehavior.Editable = false;
            gridViewUsers.OptionsEditForm.PopupEditFormWidth = 1200;
            gridViewUsers.OptionsView.ShowGroupPanel = false;
            // 
            // ribbonControl1
            // 
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(45, 48, 45, 48);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, btnRefresh, btnCreate, btnEdit, btnDelete, btnChangePassword });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ribbonControl1.MaxItemId = 7;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 495;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            ribbonControl1.ShowPageKeyTipsMode = DevExpress.XtraBars.Ribbon.ShowPageKeyTipsMode.Hide;
            ribbonControl1.ShowQatLocationSelector = false;
            ribbonControl1.ShowToolbarCustomizeItem = false;
            ribbonControl1.Size = new System.Drawing.Size(1581, 187);
            ribbonControl1.Toolbar.ShowCustomizeItem = false;
            ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnRefresh
            // 
            btnRefresh.Caption = "Обновить";
            btnRefresh.Id = 1;
            btnRefresh.ImageOptions.SvgImage = Properties.Resources.actions_refresh4;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ItemClick += btnRefresh_ItemClick;
            // 
            // btnCreate
            // 
            btnCreate.Caption = "Создать";
            btnCreate.Id = 2;
            btnCreate.ImageOptions.SvgImage = Properties.Resources.actions_add5;
            btnCreate.Name = "btnCreate";
            btnCreate.ItemClick += btnCreate_ItemClick;
            // 
            // btnEdit
            // 
            btnEdit.Caption = "Редактировать";
            btnEdit.Id = 3;
            btnEdit.ImageOptions.SvgImage = Properties.Resources.editnames5;
            btnEdit.Name = "btnEdit";
            btnEdit.ItemClick += btnEdit_ItemClick;
            // 
            // btnDelete
            // 
            btnDelete.Caption = "Удалить";
            btnDelete.Id = 4;
            btnDelete.ImageOptions.SvgImage = Properties.Resources.actions_trash5;
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += btnDelete_ItemClick;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Caption = "Изменить пароль";
            btnChangePassword.Id = 5;
            btnChangePassword.ImageOptions.SvgImage = Properties.Resources.security_key;
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.ItemClick += btnChangePassword_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Управление пользователями";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btnRefresh);
            ribbonPageGroup1.ItemLinks.Add(btnCreate);
            ribbonPageGroup1.ItemLinks.Add(btnEdit);
            ribbonPageGroup1.ItemLinks.Add(btnDelete);
            ribbonPageGroup1.ItemLinks.Add(btnChangePassword);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Действия";
            // 
            // UserManagementControl
            // 
            Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(gridControlUsers);
            Controls.Add(ribbonControl1);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "UserManagementControl";
            Size = new System.Drawing.Size(1581, 969);
            ((System.ComponentModel.ISupportInitialize)gridControlUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUsers;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnCreate;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnChangePassword;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
} 