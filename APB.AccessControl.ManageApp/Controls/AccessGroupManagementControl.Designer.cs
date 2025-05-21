namespace APB.AccessControl.ManageApp.Controls
{
    partial class AccessGroupManagementControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessGroupManagementControl));
            panelMain = new DevExpress.XtraEditors.PanelControl();
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            splitContainerMain = new DevExpress.XtraEditors.SplitContainerControl();
            gridControlAccessGroups = new DevExpress.XtraGrid.GridControl();
            gridViewAccessGroups = new DevExpress.XtraGrid.Views.Grid.GridView();
            panelGroupDetails = new DevExpress.XtraEditors.PanelControl();
            layoutControlGroupDetails = new DevExpress.XtraLayout.LayoutControl();
            lblGroupName = new DevExpress.XtraEditors.LabelControl();
            gridControlEmployeesInGroup = new DevExpress.XtraGrid.GridControl();
            gridViewEmployeesInGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlIsActive = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroupName = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlEmployees = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutItemSplitContainer = new DevExpress.XtraLayout.LayoutControlItem();
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barBtnAddAccessGroup = new DevExpress.XtraBars.BarButtonItem();
            barBtnEditAccessGroup = new DevExpress.XtraBars.BarButtonItem();
            barBtnDeleteAccessGroup = new DevExpress.XtraBars.BarButtonItem();
            barBtnAddEmployeeToGroup = new DevExpress.XtraBars.BarButtonItem();
            barBtnRemoveEmployeeFromGroup = new DevExpress.XtraBars.BarButtonItem();
            ribbonPageAccessGroups = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroupAccessGroups = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupEmployees = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            layoutItemMain = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)panelMain).BeginInit();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain.Panel1).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain.Panel2).BeginInit();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlAccessGroups).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAccessGroups).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelGroupDetails).BeginInit();
            panelGroupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupDetails).BeginInit();
            layoutControlGroupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlEmployeesInGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewEmployeesInGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkIsActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlIsActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemSplitContainer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemMain).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(layoutControl);
            panelMain.Controls.Add(ribbonControl);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(2206, 1600);
            panelMain.TabIndex = 0;
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(splitContainerMain);
            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl.Location = new System.Drawing.Point(2, 225);
            layoutControl.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            layoutControl.Name = "layoutControl";
            layoutControl.Root = layoutControlGroup;
            layoutControl.Size = new System.Drawing.Size(2202, 1373);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl";
            // 
            // splitContainerMain
            // 
            splitContainerMain.Cursor = System.Windows.Forms.Cursors.No;
            splitContainerMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            splitContainerMain.IsSplitterFixed = true;
            splitContainerMain.Location = new System.Drawing.Point(12, 12);
            splitContainerMain.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(gridControlAccessGroups);
            splitContainerMain.Panel1.Text = "Группы доступа";
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelGroupDetails);
            splitContainerMain.Panel2.Text = "Информация о группе";
            splitContainerMain.Size = new System.Drawing.Size(2178, 1349);
            splitContainerMain.SplitterPosition = 1400;
            splitContainerMain.TabIndex = 1;
            // 
            // gridControlAccessGroups
            // 
            gridControlAccessGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlAccessGroups.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            gridControlAccessGroups.Location = new System.Drawing.Point(0, 0);
            gridControlAccessGroups.MainView = gridViewAccessGroups;
            gridControlAccessGroups.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            gridControlAccessGroups.Name = "gridControlAccessGroups";
            gridControlAccessGroups.Size = new System.Drawing.Size(763, 1349);
            gridControlAccessGroups.TabIndex = 0;
            gridControlAccessGroups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewAccessGroups });
            // 
            // gridViewAccessGroups
            // 
            gridViewAccessGroups.DetailHeight = 861;
            gridViewAccessGroups.GridControl = gridControlAccessGroups;
            gridViewAccessGroups.Name = "gridViewAccessGroups";
            gridViewAccessGroups.OptionsBehavior.Editable = false;
            gridViewAccessGroups.OptionsEditForm.PopupEditFormWidth = 1733;
            gridViewAccessGroups.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // panelGroupDetails
            // 
            panelGroupDetails.Controls.Add(layoutControlGroupDetails);
            panelGroupDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            panelGroupDetails.Location = new System.Drawing.Point(0, 0);
            panelGroupDetails.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            panelGroupDetails.Name = "panelGroupDetails";
            panelGroupDetails.Size = new System.Drawing.Size(1400, 1349);
            panelGroupDetails.TabIndex = 1;
            // 
            // layoutControlGroupDetails
            // 
            layoutControlGroupDetails.Controls.Add(lblGroupName);
            layoutControlGroupDetails.Controls.Add(gridControlEmployeesInGroup);
            layoutControlGroupDetails.Controls.Add(chkIsActive);
            layoutControlGroupDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlGroupDetails.Location = new System.Drawing.Point(2, 2);
            layoutControlGroupDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            layoutControlGroupDetails.Name = "layoutControlGroupDetails";
            layoutControlGroupDetails.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1248, 418, 975, 600);
            layoutControlGroupDetails.Root = Root;
            layoutControlGroupDetails.Size = new System.Drawing.Size(1396, 1345);
            layoutControlGroupDetails.TabIndex = 8;
            layoutControlGroupDetails.Text = "layoutControl1";
            // 
            // lblGroupName
            // 
            lblGroupName.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblGroupName.Appearance.Options.UseFont = true;
            lblGroupName.Location = new System.Drawing.Point(2, 2);
            lblGroupName.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            lblGroupName.Name = "lblGroupName";
            lblGroupName.Padding = new System.Windows.Forms.Padding(12);
            lblGroupName.Size = new System.Drawing.Size(254, 56);
            lblGroupName.StyleController = layoutControlGroupDetails;
            lblGroupName.TabIndex = 1;
            lblGroupName.Text = "Группа не выбрана";
            // 
            // gridControlEmployeesInGroup
            // 
            gridControlEmployeesInGroup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            gridControlEmployeesInGroup.Location = new System.Drawing.Point(2, 170);
            gridControlEmployeesInGroup.MainView = gridViewEmployeesInGroup;
            gridControlEmployeesInGroup.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            gridControlEmployeesInGroup.Name = "gridControlEmployeesInGroup";
            gridControlEmployeesInGroup.Size = new System.Drawing.Size(1392, 1162);
            gridControlEmployeesInGroup.TabIndex = 2;
            gridControlEmployeesInGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewEmployeesInGroup });
            // 
            // gridViewEmployeesInGroup
            // 
            gridViewEmployeesInGroup.DetailHeight = 861;
            gridViewEmployeesInGroup.GridControl = gridControlEmployeesInGroup;
            gridViewEmployeesInGroup.Name = "gridViewEmployeesInGroup";
            gridViewEmployeesInGroup.OptionsBehavior.Editable = false;
            gridViewEmployeesInGroup.OptionsEditForm.PopupEditFormWidth = 1733;
            gridViewEmployeesInGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewEmployeesInGroup.OptionsView.ShowGroupPanel = false;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSizeInLayoutControl = true;
            chkIsActive.Location = new System.Drawing.Point(2, 62);
            chkIsActive.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Properties.Caption = "Активна";
            chkIsActive.Properties.ReadOnly = true;
            chkIsActive.Size = new System.Drawing.Size(1392, 27);
            chkIsActive.StyleController = layoutControlGroupDetails;
            chkIsActive.TabIndex = 0;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlIsActive, layoutControlGroupName, layoutControlEmployees, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            Root.Size = new System.Drawing.Size(1396, 1345);
            Root.TextVisible = false;
            // 
            // layoutControlIsActive
            // 
            layoutControlIsActive.Control = chkIsActive;
            layoutControlIsActive.Location = new System.Drawing.Point(0, 60);
            layoutControlIsActive.MinSize = new System.Drawing.Size(105, 37);
            layoutControlIsActive.Name = "layoutControlIsActive";
            layoutControlIsActive.Size = new System.Drawing.Size(1396, 84);
            layoutControlIsActive.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlIsActive.TextVisible = false;
            // 
            // layoutControlGroupName
            // 
            layoutControlGroupName.Control = lblGroupName;
            layoutControlGroupName.Location = new System.Drawing.Point(0, 0);
            layoutControlGroupName.Name = "layoutControlGroupName";
            layoutControlGroupName.Size = new System.Drawing.Size(1396, 60);
            layoutControlGroupName.TextVisible = false;
            // 
            // layoutControlEmployees
            // 
            layoutControlEmployees.Control = gridControlEmployeesInGroup;
            layoutControlEmployees.Location = new System.Drawing.Point(0, 144);
            layoutControlEmployees.MinSize = new System.Drawing.Size(137, 53);
            layoutControlEmployees.Name = "layoutControlEmployees";
            layoutControlEmployees.Size = new System.Drawing.Size(1396, 1190);
            layoutControlEmployees.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlEmployees.Text = "Сотрудники в группе";
            layoutControlEmployees.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlEmployees.TextSize = new System.Drawing.Size(152, 21);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new System.Drawing.Point(0, 1334);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(1396, 11);
            // 
            // layoutControlGroup
            // 
            layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup.GroupBordersVisible = false;
            layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutItemSplitContainer });
            layoutControlGroup.Name = "layoutControlGroup";
            layoutControlGroup.Size = new System.Drawing.Size(2202, 1373);
            layoutControlGroup.TextVisible = false;
            // 
            // layoutItemSplitContainer
            // 
            layoutItemSplitContainer.Control = splitContainerMain;
            layoutItemSplitContainer.Location = new System.Drawing.Point(0, 0);
            layoutItemSplitContainer.Name = "layoutItemSplitContainer";
            layoutItemSplitContainer.Size = new System.Drawing.Size(2182, 1353);
            layoutItemSplitContainer.TextVisible = false;
            // 
            // ribbonControl
            // 
            ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(65, 73, 65, 73);
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, barBtnAddAccessGroup, barBtnEditAccessGroup, barBtnDeleteAccessGroup, barBtnAddEmployeeToGroup, barBtnRemoveEmployeeFromGroup });
            ribbonControl.Location = new System.Drawing.Point(2, 2);
            ribbonControl.Margin = new System.Windows.Forms.Padding(0);
            ribbonControl.MaxItemId = 6;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.OptionsMenuMinWidth = 715;
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPageAccessGroups });
            ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            ribbonControl.ShowPageKeyTipsMode = DevExpress.XtraBars.Ribbon.ShowPageKeyTipsMode.Hide;
            ribbonControl.Size = new System.Drawing.Size(2202, 223);
            ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // barBtnAddAccessGroup
            // 
            barBtnAddAccessGroup.Caption = "Добавить";
            barBtnAddAccessGroup.Id = 1;
            barBtnAddAccessGroup.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnAddAccessGroup.ImageOptions.SvgImage");
            barBtnAddAccessGroup.Name = "barBtnAddAccessGroup";
            // 
            // barBtnEditAccessGroup
            // 
            barBtnEditAccessGroup.Caption = "Изменить";
            barBtnEditAccessGroup.Id = 2;
            barBtnEditAccessGroup.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnEditAccessGroup.ImageOptions.SvgImage");
            barBtnEditAccessGroup.Name = "barBtnEditAccessGroup";
            // 
            // barBtnDeleteAccessGroup
            // 
            barBtnDeleteAccessGroup.Caption = "Удалить";
            barBtnDeleteAccessGroup.Id = 3;
            barBtnDeleteAccessGroup.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnDeleteAccessGroup.ImageOptions.SvgImage");
            barBtnDeleteAccessGroup.Name = "barBtnDeleteAccessGroup";
            // 
            // barBtnAddEmployeeToGroup
            // 
            barBtnAddEmployeeToGroup.Caption = "Добавить сотрудника";
            barBtnAddEmployeeToGroup.Id = 4;
            barBtnAddEmployeeToGroup.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnAddEmployeeToGroup.ImageOptions.SvgImage");
            barBtnAddEmployeeToGroup.Name = "barBtnAddEmployeeToGroup";
            // 
            // barBtnRemoveEmployeeFromGroup
            // 
            barBtnRemoveEmployeeFromGroup.Caption = "Удалить сотрудника";
            barBtnRemoveEmployeeFromGroup.Id = 5;
            barBtnRemoveEmployeeFromGroup.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnRemoveEmployeeFromGroup.ImageOptions.SvgImage");
            barBtnRemoveEmployeeFromGroup.Name = "barBtnRemoveEmployeeFromGroup";
            // 
            // ribbonPageAccessGroups
            // 
            ribbonPageAccessGroups.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroupAccessGroups, ribbonPageGroupEmployees });
            ribbonPageAccessGroups.Name = "ribbonPageAccessGroups";
            ribbonPageAccessGroups.Text = "Группы доступа";
            // 
            // ribbonPageGroupAccessGroups
            // 
            ribbonPageGroupAccessGroups.ItemLinks.Add(barBtnAddAccessGroup);
            ribbonPageGroupAccessGroups.ItemLinks.Add(barBtnEditAccessGroup);
            ribbonPageGroupAccessGroups.ItemLinks.Add(barBtnDeleteAccessGroup);
            ribbonPageGroupAccessGroups.Name = "ribbonPageGroupAccessGroups";
            ribbonPageGroupAccessGroups.Text = "Управление группами";
            // 
            // ribbonPageGroupEmployees
            // 
            ribbonPageGroupEmployees.ItemLinks.Add(barBtnAddEmployeeToGroup);
            ribbonPageGroupEmployees.ItemLinks.Add(barBtnRemoveEmployeeFromGroup);
            ribbonPageGroupEmployees.Name = "ribbonPageGroupEmployees";
            ribbonPageGroupEmployees.Text = "Сотрудники в группе";
            // 
            // layoutItemMain
            // 
            layoutItemMain.Location = new System.Drawing.Point(0, 0);
            layoutItemMain.Name = "layoutItemMain";
            layoutItemMain.TextSize = new System.Drawing.Size(50, 20);
            // 
            // AccessGroupManagementControl
            // 
            Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelMain);
            Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            Name = "AccessGroupManagementControl";
            Size = new System.Drawing.Size(2206, 1600);
            ((System.ComponentModel.ISupportInitialize)panelMain).EndInit();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain.Panel1).EndInit();
            splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain.Panel2).EndInit();
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlAccessGroups).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAccessGroups).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelGroupDetails).EndInit();
            panelGroupDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupDetails).EndInit();
            layoutControlGroupDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlEmployeesInGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewEmployeesInGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkIsActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlIsActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupName).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemSplitContainer).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutItemMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerMain;
        private DevExpress.XtraGrid.GridControl gridControlAccessGroups;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAccessGroups;
        private DevExpress.XtraEditors.PanelControl panelGroupDetails;
        private DevExpress.XtraLayout.LayoutControl layoutControlGroupDetails;
        private DevExpress.XtraEditors.LabelControl lblGroupName;
        private DevExpress.XtraGrid.GridControl gridControlEmployeesInGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEmployeesInGroup;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlIsActive;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlGroupName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlEmployees;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemSplitContainer;
        
        // RibbonControl
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem barBtnAddAccessGroup;
        private DevExpress.XtraBars.BarButtonItem barBtnEditAccessGroup;
        private DevExpress.XtraBars.BarButtonItem barBtnDeleteAccessGroup;
        private DevExpress.XtraBars.BarButtonItem barBtnAddEmployeeToGroup;
        private DevExpress.XtraBars.BarButtonItem barBtnRemoveEmployeeFromGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageAccessGroups;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAccessGroups;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupEmployees;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemMain;
    }
} 