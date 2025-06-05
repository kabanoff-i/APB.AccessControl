namespace APB.AccessControl.ManageApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainFormContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            accordionControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            group = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            EmployeeManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            AccessGroupManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            AccessPointManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            AccessRuleManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            AccessLogView = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            NotificationsManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            UserManagementControl = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            logout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            MainFormControl = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            itemNav = new DevExpress.XtraBars.BarStaticItem();
            MainFormDefaultManager = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            ((System.ComponentModel.ISupportInitialize)accordionControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainFormControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainFormDefaultManager).BeginInit();
            SuspendLayout();
            // 
            // MainFormContainer
            // 
            resources.ApplyResources(MainFormContainer, "MainFormContainer");
            MainFormContainer.Name = "MainFormContainer";
            // 
            // accordionControl
            // 
            resources.ApplyResources(accordionControl, "accordionControl");
            accordionControl.AllowItemSelection = true;
            accordionControl.Appearance.Item.Default.Font = (System.Drawing.Font)resources.GetObject("accordionControl.Appearance.Item.Default.Font");
            accordionControl.Appearance.Item.Default.Options.UseFont = true;
            accordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { group, logout });
            accordionControl.ExpandGroupOnHeaderClick = false;
            accordionControl.ExpandItemOnHeaderClick = false;
            accordionControl.Name = "accordionControl";
            accordionControl.OptionsFooter.ActiveGroupDisplayMode = DevExpress.XtraBars.Navigation.ActiveGroupDisplayMode.GroupHeaderAndContent;
            accordionControl.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            accordionControl.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            accordionControl.ShowGroupExpandButtons = false;
            accordionControl.ShowItemExpandButtons = false;
            accordionControl.ShowToolTips = false;
            accordionControl.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // group
            // 
            resources.ApplyResources(group, "group");
            group.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { EmployeeManagement, AccessGroupManagement, AccessPointManagement, AccessRuleManagement, AccessLogView, NotificationsManagement, UserManagementControl });
            group.Expanded = true;
            group.HeaderVisible = false;
            group.Height = -1;
            group.Name = "group";
            group.Tag = 1;
            group.VisibleInFooter = false;
            // 
            // EmployeeManagement
            // 
            resources.ApplyResources(EmployeeManagement, "EmployeeManagement");
            EmployeeManagement.Height = -1;
            EmployeeManagement.ImageOptions.ImageKey = resources.GetString("EmployeeManagement.ImageOptions.ImageKey");
            EmployeeManagement.ImageOptions.SvgImage = Properties.Resources.Contact;
            EmployeeManagement.Name = "EmployeeManagement";
            EmployeeManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // AccessGroupManagement
            // 
            resources.ApplyResources(AccessGroupManagement, "AccessGroupManagement");
            AccessGroupManagement.ImageOptions.ImageKey = resources.GetString("AccessGroupManagement.ImageOptions.ImageKey");
            AccessGroupManagement.ImageOptions.SvgImage = Properties.Resources.People;
            AccessGroupManagement.Name = "AccessGroupManagement";
            AccessGroupManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // AccessPointManagement
            // 
            resources.ApplyResources(AccessPointManagement, "AccessPointManagement");
            AccessPointManagement.ImageOptions.ImageKey = resources.GetString("AccessPointManagement.ImageOptions.ImageKey");
            AccessPointManagement.ImageOptions.SvgImage = Properties.Resources.DirectAccess;
            AccessPointManagement.Name = "AccessPointManagement";
            AccessPointManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // AccessRuleManagement
            // 
            resources.ApplyResources(AccessRuleManagement, "AccessRuleManagement");
            AccessRuleManagement.ImageOptions.ImageKey = resources.GetString("AccessRuleManagement.ImageOptions.ImageKey");
            AccessRuleManagement.ImageOptions.SvgImage = Properties.Resources.font_icon59812;
            AccessRuleManagement.Name = "AccessRuleManagement";
            AccessRuleManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // AccessLogView
            // 
            resources.ApplyResources(AccessLogView, "AccessLogView");
            AccessLogView.ImageOptions.ImageKey = resources.GetString("AccessLogView.ImageOptions.ImageKey");
            AccessLogView.ImageOptions.SvgImage = Properties.Resources.SetHistoryStatus;
            AccessLogView.Name = "AccessLogView";
            AccessLogView.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // NotificationsManagement
            // 
            resources.ApplyResources(NotificationsManagement, "NotificationsManagement");
            NotificationsManagement.ImageOptions.ImageKey = resources.GetString("NotificationsManagement.ImageOptions.ImageKey");
            NotificationsManagement.ImageOptions.SvgImage = Properties.Resources.Ringer;
            NotificationsManagement.Name = "NotificationsManagement";
            NotificationsManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // UserManagementControl
            // 
            resources.ApplyResources(UserManagementControl, "UserManagementControl");
            UserManagementControl.ImageOptions.ImageKey = resources.GetString("UserManagementControl.ImageOptions.ImageKey");
            UserManagementControl.ImageOptions.SvgImage = Properties.Resources.Permissions3;
            UserManagementControl.Name = "UserManagementControl";
            UserManagementControl.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // logout
            // 
            resources.ApplyResources(logout, "logout");
            logout.ControlFooterAlignment = DevExpress.XtraBars.Navigation.AccordionItemFooterAlignment.Far;
            logout.ImageOptions.ImageKey = resources.GetString("logout.ImageOptions.ImageKey");
            logout.ImageOptions.SvgImage = Properties.Resources.SignOut;
            logout.Name = "logout";
            logout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            logout.Click += logout_Click;
            // 
            // MainFormControl
            // 
            resources.ApplyResources(MainFormControl, "MainFormControl");
            MainFormControl.FluentDesignForm = this;
            MainFormControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { itemNav });
            MainFormControl.Manager = MainFormDefaultManager;
            MainFormControl.Name = "MainFormControl";
            MainFormControl.TabStop = false;
            MainFormControl.TitleItemLinks.Add(itemNav);
            // 
            // itemNav
            // 
            resources.ApplyResources(itemNav, "itemNav");
            itemNav.Id = 0;
            itemNav.ImageOptions.ImageIndex = (int)resources.GetObject("itemNav.ImageOptions.ImageIndex");
            itemNav.ImageOptions.ImageKey = resources.GetString("itemNav.ImageOptions.ImageKey");
            itemNav.ImageOptions.LargeImageIndex = (int)resources.GetObject("itemNav.ImageOptions.LargeImageIndex");
            itemNav.ImageOptions.LargeImageKey = resources.GetString("itemNav.ImageOptions.LargeImageKey");
            itemNav.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("itemNav.ImageOptions.SvgImage");
            itemNav.Name = "itemNav";
            // 
            // MainFormDefaultManager
            // 
            MainFormDefaultManager.Form = this;
            MainFormDefaultManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] { itemNav });
            MainFormDefaultManager.MaxItemId = 2;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            Appearance.Options.UseFont = true;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ControlContainer = MainFormContainer;
            Controls.Add(MainFormContainer);
            Controls.Add(accordionControl);
            Controls.Add(MainFormControl);
            FluentDesignFormControl = MainFormControl;
            IconOptions.ShowIcon = false;
            Name = "MainForm";
            NavigationControl = accordionControl;
            ((System.ComponentModel.ISupportInitialize)accordionControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainFormControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainFormDefaultManager).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer MainFormContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl MainFormControl;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager MainFormDefaultManager;
        private DevExpress.XtraBars.BarStaticItem itemNav;
        private DevExpress.XtraBars.Navigation.AccordionControlElement EmployeeManagement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement logout;
        private DevExpress.XtraBars.Navigation.AccordionControlElement group;
        private DevExpress.XtraBars.Navigation.AccordionControlElement AccessGroupManagement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement AccessPointManagement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement AccessRuleManagement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement AccessLogView;
        private DevExpress.XtraBars.Navigation.AccordionControlElement NotificationsManagement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement UserManagementControl;
    }
}