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
            MainFormContainer.Size = new System.Drawing.Size(1269, 735);
            MainFormContainer.TabIndex = 0;
            // 
            // accordionControl
            // 
            accordionControl.Dock = System.Windows.Forms.DockStyle.Left;
            accordionControl.Location = new System.Drawing.Point(0, 46);
            accordionControl.Name = "accordionControl";
            accordionControl.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            accordionControl.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.AutoCollapse;
            accordionControl.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Auto;
            accordionControl.Size = new System.Drawing.Size(377, 735);
            accordionControl.TabIndex = 1;
            accordionControl.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
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
            MainFormDefaultManager.MaxItemId = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1646, 781);
            ControlContainer = MainFormContainer;
            Controls.Add(MainFormContainer);
            Controls.Add(accordionControl);
            Controls.Add(MainFormControl);
            FluentDesignFormControl = MainFormControl;
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
    }
}