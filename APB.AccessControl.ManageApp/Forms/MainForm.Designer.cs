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
            MainFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            MainFormContainer.Location = new System.Drawing.Point(377, 46);
            MainFormContainer.Name = "MainFormContainer";
            MainFormContainer.Size = new System.Drawing.Size(1269, 817);
            MainFormContainer.TabIndex = 0;
            // 
            // accordionControl
            // 
            accordionControl.AllowItemSelection = true;
            accordionControl.Appearance.Item.Default.Font = new System.Drawing.Font("Segoe UI", 11F);
            accordionControl.Appearance.Item.Default.Options.UseFont = true;
            accordionControl.Dock = System.Windows.Forms.DockStyle.Left;
            accordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { group, logout });
            accordionControl.ExpandGroupOnHeaderClick = false;
            accordionControl.ExpandItemOnHeaderClick = false;
            accordionControl.Location = new System.Drawing.Point(0, 46);
            accordionControl.Name = "accordionControl";
            accordionControl.OptionsFooter.ActiveGroupDisplayMode = DevExpress.XtraBars.Navigation.ActiveGroupDisplayMode.GroupHeaderAndContent;
            accordionControl.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            accordionControl.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            accordionControl.ShowGroupExpandButtons = false;
            accordionControl.ShowItemExpandButtons = false;
            accordionControl.ShowToolTips = false;
            accordionControl.Size = new System.Drawing.Size(377, 817);
            accordionControl.TabIndex = 1;
            accordionControl.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // group
            // 
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
            EmployeeManagement.Height = -1;
            EmployeeManagement.ImageOptions.SvgImage = Properties.Resources.Contact;
            EmployeeManagement.Name = "EmployeeManagement";
            EmployeeManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            EmployeeManagement.Text = "Сотрудники и карты";
            // 
            // AccessGroupManagement
            // 
            AccessGroupManagement.ImageOptions.SvgImage = Properties.Resources.People;
            AccessGroupManagement.Name = "AccessGroupManagement";
            AccessGroupManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            AccessGroupManagement.Text = "Группы доступа";
            // 
            // AccessPointManagement
            // 
            AccessPointManagement.ImageOptions.SvgImage = Properties.Resources.DirectAccess;
            AccessPointManagement.Name = "AccessPointManagement";
            AccessPointManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            AccessPointManagement.Text = "Точки доступа";
            // 
            // AccessRuleManagement
            // 
            AccessRuleManagement.ImageOptions.SvgImage = Properties.Resources.font_icon59812;
            AccessRuleManagement.Name = "AccessRuleManagement";
            AccessRuleManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            AccessRuleManagement.Text = "Правила доступа";
            // 
            // AccessLogView
            // 
            AccessLogView.ImageOptions.SvgImage = Properties.Resources.SetHistoryStatus;
            AccessLogView.Name = "AccessLogView";
            AccessLogView.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            AccessLogView.Text = "История проходов";
            // 
            // NotificationsManagement
            // 
            NotificationsManagement.ImageOptions.SvgImage = Properties.Resources.Ringer;
            NotificationsManagement.Name = "NotificationsManagement";
            NotificationsManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            NotificationsManagement.Text = "Уведомления";
            // 
            // UserManagementControl
            // 
            UserManagementControl.Name = "UserManagementControl";
            UserManagementControl.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            UserManagementControl.Text = "Пользователи";
            // 
            // logout
            // 
            logout.ControlFooterAlignment = DevExpress.XtraBars.Navigation.AccordionItemFooterAlignment.Far;
            logout.ImageOptions.SvgImage = Properties.Resources.SignOut;
            logout.Name = "logout";
            logout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            logout.Click += logout_Click;
            // 
            // MainFormControl
            // 
            MainFormControl.FluentDesignForm = this;
            MainFormControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { itemNav });
            MainFormControl.Location = new System.Drawing.Point(0, 0);
            MainFormControl.Manager = MainFormDefaultManager;
            MainFormControl.Name = "MainFormControl";
            MainFormControl.Size = new System.Drawing.Size(1646, 46);
            MainFormControl.TabIndex = 2;
            MainFormControl.TabStop = false;
            MainFormControl.TitleItemLinks.Add(itemNav);
            // 
            // itemNav
            // 
            itemNav.Id = 0;
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
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1646, 863);
            ControlContainer = MainFormContainer;
            Controls.Add(MainFormContainer);
            Controls.Add(accordionControl);
            Controls.Add(MainFormControl);
            FluentDesignFormControl = MainFormControl;
            Font = new System.Drawing.Font("Segoe UI", 8F);
            Name = "MainForm";
            NavigationControl = accordionControl;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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