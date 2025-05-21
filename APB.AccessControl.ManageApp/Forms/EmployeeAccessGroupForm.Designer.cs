namespace APB.AccessControl.ManageApp.Forms
{
    partial class EmployeeAccessGroupForm
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
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            gridControlAvailable = new DevExpress.XtraGrid.GridControl();
            gridViewAvailable = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridControlSelected = new DevExpress.XtraGrid.GridControl();
            gridViewSelected = new DevExpress.XtraGrid.Views.Grid.GridView();
            btnMoveToSelected = new DevExpress.XtraEditors.SimpleButton();
            btnMoveToAvailable = new DevExpress.XtraEditors.SimpleButton();
            btnMoveAllToSelected = new DevExpress.XtraEditors.SimpleButton();
            btnMoveAllToAvailable = new DevExpress.XtraEditors.SimpleButton();
            btnOk = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroupAvailable = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemAvailableGrid = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroupSelected = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemSelectedGrid = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroupButtons = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemMoveToSelected = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemMoveToAvailable = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemMoveAllToSelected = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemMoveAllToAvailable = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlGroupActions = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemOk = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlAvailable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAvailable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlSelected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSelected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupAvailable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemAvailableGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupSelected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSelectedGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupButtons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemMoveToSelected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemMoveToAvailable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemMoveAllToSelected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemMoveAllToAvailable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupActions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemOk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCancel).BeginInit();
            SuspendLayout();
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(gridControlAvailable);
            layoutControl.Controls.Add(gridControlSelected);
            layoutControl.Controls.Add(btnMoveToSelected);
            layoutControl.Controls.Add(btnMoveToAvailable);
            layoutControl.Controls.Add(btnMoveAllToSelected);
            layoutControl.Controls.Add(btnMoveAllToAvailable);
            layoutControl.Controls.Add(btnOk);
            layoutControl.Controls.Add(btnCancel);
            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl.Location = new System.Drawing.Point(0, 0);
            layoutControl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            layoutControl.Name = "layoutControl";
            layoutControl.Root = Root;
            layoutControl.Size = new System.Drawing.Size(1878, 971);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl";
            // 
            // gridControlAvailable
            // 
            gridControlAvailable.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            gridControlAvailable.Location = new System.Drawing.Point(57, 108);
            gridControlAvailable.MainView = gridViewAvailable;
            gridControlAvailable.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            gridControlAvailable.Name = "gridControlAvailable";
            gridControlAvailable.Size = new System.Drawing.Size(678, 677);
            gridControlAvailable.TabIndex = 4;
            gridControlAvailable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewAvailable });
            // 
            // gridViewAvailable
            // 
            gridViewAvailable.DetailHeight = 755;
            gridViewAvailable.GridControl = gridControlAvailable;
            gridViewAvailable.Name = "gridViewAvailable";
            gridViewAvailable.OptionsEditForm.PopupEditFormWidth = 1467;
            gridViewAvailable.SelectionChanged += gridView_SelectionChanged;
            // 
            // gridControlSelected
            // 
            gridControlSelected.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            gridControlSelected.Location = new System.Drawing.Point(1142, 108);
            gridControlSelected.MainView = gridViewSelected;
            gridControlSelected.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            gridControlSelected.Name = "gridControlSelected";
            gridControlSelected.Size = new System.Drawing.Size(679, 677);
            gridControlSelected.TabIndex = 5;
            gridControlSelected.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewSelected });
            // 
            // gridViewSelected
            // 
            gridViewSelected.DetailHeight = 755;
            gridViewSelected.GridControl = gridControlSelected;
            gridViewSelected.Name = "gridViewSelected";
            gridViewSelected.OptionsEditForm.PopupEditFormWidth = 1467;
            gridViewSelected.SelectionChanged += gridView_SelectionChanged;
            // 
            // btnMoveToSelected
            // 
            btnMoveToSelected.Location = new System.Drawing.Point(801, 67);
            btnMoveToSelected.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnMoveToSelected.Name = "btnMoveToSelected";
            btnMoveToSelected.Size = new System.Drawing.Size(275, 41);
            btnMoveToSelected.StyleController = layoutControl;
            btnMoveToSelected.TabIndex = 6;
            btnMoveToSelected.Text = ">";
            btnMoveToSelected.Click += btnMoveToSelected_Click;
            // 
            // btnMoveToAvailable
            // 
            btnMoveToAvailable.Location = new System.Drawing.Point(801, 120);
            btnMoveToAvailable.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnMoveToAvailable.Name = "btnMoveToAvailable";
            btnMoveToAvailable.Size = new System.Drawing.Size(275, 41);
            btnMoveToAvailable.StyleController = layoutControl;
            btnMoveToAvailable.TabIndex = 7;
            btnMoveToAvailable.Text = "<";
            btnMoveToAvailable.Click += btnMoveToAvailable_Click;
            // 
            // btnMoveAllToSelected
            // 
            btnMoveAllToSelected.Location = new System.Drawing.Point(801, 173);
            btnMoveAllToSelected.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnMoveAllToSelected.Name = "btnMoveAllToSelected";
            btnMoveAllToSelected.Size = new System.Drawing.Size(275, 41);
            btnMoveAllToSelected.StyleController = layoutControl;
            btnMoveAllToSelected.TabIndex = 8;
            btnMoveAllToSelected.Text = ">>";
            btnMoveAllToSelected.Click += btnMoveAllToSelected_Click;
            // 
            // btnMoveAllToAvailable
            // 
            btnMoveAllToAvailable.Location = new System.Drawing.Point(801, 226);
            btnMoveAllToAvailable.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnMoveAllToAvailable.Name = "btnMoveAllToAvailable";
            btnMoveAllToAvailable.Size = new System.Drawing.Size(275, 41);
            btnMoveAllToAvailable.StyleController = layoutControl;
            btnMoveAllToAvailable.TabIndex = 9;
            btnMoveAllToAvailable.Text = "<<";
            btnMoveAllToAvailable.Click += btnMoveAllToAvailable_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(57, 863);
            btnOk.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(875, 41);
            btnOk.StyleController = layoutControl;
            btnOk.TabIndex = 10;
            btnOk.Text = "ОК";
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(942, 863);
            btnCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(879, 41);
            btnCancel.StyleController = layoutControl;
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroupAvailable, layoutControlGroupSelected, layoutControlGroupButtons, layoutControlGroupActions });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(1878, 971);
            Root.TextVisible = false;
            // 
            // layoutControlGroupAvailable
            // 
            layoutControlGroupAvailable.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemAvailableGrid });
            layoutControlGroupAvailable.Location = new System.Drawing.Point(0, 0);
            layoutControlGroupAvailable.Name = "layoutControlGroupAvailable";
            layoutControlGroupAvailable.Size = new System.Drawing.Size(744, 796);
            layoutControlGroupAvailable.Text = "Доступные сотрудники";
            // 
            // layoutControlItemAvailableGrid
            // 
            layoutControlItemAvailableGrid.Control = gridControlAvailable;
            layoutControlItemAvailableGrid.Location = new System.Drawing.Point(0, 0);
            layoutControlItemAvailableGrid.Name = "layoutControlItemAvailableGrid";
            layoutControlItemAvailableGrid.Size = new System.Drawing.Size(688, 689);
            layoutControlItemAvailableGrid.TextVisible = false;
            // 
            // layoutControlGroupSelected
            // 
            layoutControlGroupSelected.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemSelectedGrid });
            layoutControlGroupSelected.Location = new System.Drawing.Point(1085, 0);
            layoutControlGroupSelected.Name = "layoutControlGroupSelected";
            layoutControlGroupSelected.Size = new System.Drawing.Size(745, 796);
            layoutControlGroupSelected.Text = "Выбранные сотрудники";
            // 
            // layoutControlItemSelectedGrid
            // 
            layoutControlItemSelectedGrid.Control = gridControlSelected;
            layoutControlItemSelectedGrid.Location = new System.Drawing.Point(0, 0);
            layoutControlItemSelectedGrid.Name = "layoutControlItemSelectedGrid";
            layoutControlItemSelectedGrid.Size = new System.Drawing.Size(689, 689);
            layoutControlItemSelectedGrid.TextVisible = false;
            // 
            // layoutControlGroupButtons
            // 
            layoutControlGroupButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemMoveToSelected, layoutControlItemMoveToAvailable, layoutControlItemMoveAllToSelected, layoutControlItemMoveAllToAvailable, emptySpaceItem1 });
            layoutControlGroupButtons.Location = new System.Drawing.Point(744, 0);
            layoutControlGroupButtons.Name = "layoutControlGroupButtons";
            layoutControlGroupButtons.Size = new System.Drawing.Size(341, 796);
            layoutControlGroupButtons.TextVisible = false;
            // 
            // layoutControlItemMoveToSelected
            // 
            layoutControlItemMoveToSelected.Control = btnMoveToSelected;
            layoutControlItemMoveToSelected.Location = new System.Drawing.Point(0, 0);
            layoutControlItemMoveToSelected.Name = "layoutControlItemMoveToSelected";
            layoutControlItemMoveToSelected.Size = new System.Drawing.Size(285, 53);
            layoutControlItemMoveToSelected.TextVisible = false;
            // 
            // layoutControlItemMoveToAvailable
            // 
            layoutControlItemMoveToAvailable.Control = btnMoveToAvailable;
            layoutControlItemMoveToAvailable.Location = new System.Drawing.Point(0, 53);
            layoutControlItemMoveToAvailable.Name = "layoutControlItemMoveToAvailable";
            layoutControlItemMoveToAvailable.Size = new System.Drawing.Size(285, 53);
            layoutControlItemMoveToAvailable.TextVisible = false;
            // 
            // layoutControlItemMoveAllToSelected
            // 
            layoutControlItemMoveAllToSelected.Control = btnMoveAllToSelected;
            layoutControlItemMoveAllToSelected.Location = new System.Drawing.Point(0, 106);
            layoutControlItemMoveAllToSelected.Name = "layoutControlItemMoveAllToSelected";
            layoutControlItemMoveAllToSelected.Size = new System.Drawing.Size(285, 53);
            layoutControlItemMoveAllToSelected.TextVisible = false;
            // 
            // layoutControlItemMoveAllToAvailable
            // 
            layoutControlItemMoveAllToAvailable.Control = btnMoveAllToAvailable;
            layoutControlItemMoveAllToAvailable.Location = new System.Drawing.Point(0, 159);
            layoutControlItemMoveAllToAvailable.Name = "layoutControlItemMoveAllToAvailable";
            layoutControlItemMoveAllToAvailable.Size = new System.Drawing.Size(285, 53);
            layoutControlItemMoveAllToAvailable.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new System.Drawing.Point(0, 212);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(285, 518);
            // 
            // layoutControlGroupActions
            // 
            layoutControlGroupActions.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemOk, layoutControlItemCancel });
            layoutControlGroupActions.Location = new System.Drawing.Point(0, 796);
            layoutControlGroupActions.Name = "layoutControlGroupActions";
            layoutControlGroupActions.Size = new System.Drawing.Size(1830, 119);
            layoutControlGroupActions.TextVisible = false;
            // 
            // layoutControlItemOk
            // 
            layoutControlItemOk.Control = btnOk;
            layoutControlItemOk.Location = new System.Drawing.Point(0, 0);
            layoutControlItemOk.Name = "layoutControlItemOk";
            layoutControlItemOk.Size = new System.Drawing.Size(885, 53);
            layoutControlItemOk.TextVisible = false;
            // 
            // layoutControlItemCancel
            // 
            layoutControlItemCancel.Control = btnCancel;
            layoutControlItemCancel.Location = new System.Drawing.Point(885, 0);
            layoutControlItemCancel.Name = "layoutControlItemCancel";
            layoutControlItemCancel.Size = new System.Drawing.Size(889, 53);
            layoutControlItemCancel.TextVisible = false;
            // 
            // EmployeeAccessGroupForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(1878, 971);
            Controls.Add(layoutControl);
            Font = new System.Drawing.Font("Segoe UI", 10F);
            IconOptions.ShowIcon = false;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MinimizeBox = false;
            Name = "EmployeeAccessGroupForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Управление сотрудниками в группе";
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlAvailable).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAvailable).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlSelected).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSelected).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupAvailable).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemAvailableGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupSelected).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSelectedGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupButtons).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemMoveToSelected).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemMoveToAvailable).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemMoveAllToSelected).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemMoveAllToAvailable).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupActions).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemOk).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCancel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraGrid.GridControl gridControlAvailable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAvailable;
        private DevExpress.XtraGrid.GridControl gridControlSelected;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSelected;
        private DevExpress.XtraEditors.SimpleButton btnMoveToSelected;
        private DevExpress.XtraEditors.SimpleButton btnMoveToAvailable;
        private DevExpress.XtraEditors.SimpleButton btnMoveAllToSelected;
        private DevExpress.XtraEditors.SimpleButton btnMoveAllToAvailable;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupAvailable;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemAvailableGrid;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupSelected;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSelectedGrid;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupButtons;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemMoveToSelected;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemMoveToAvailable;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemMoveAllToSelected;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemMoveAllToAvailable;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupActions;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCancel;
    }
} 