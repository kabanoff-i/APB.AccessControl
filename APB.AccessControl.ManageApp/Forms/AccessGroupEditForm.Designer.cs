using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace APB.AccessControl.ManageApp.Forms
{
    partial class AccessGroupEditForm
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
            components = new Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            btnCancel = new SimpleButton();
            btnSave = new SimpleButton();
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            textEditName = new TextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemName = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(components);
            ((ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((ISupportInitialize)textEditName.Properties).BeginInit();
            ((ISupportInitialize)Root).BeginInit();
            ((ISupportInitialize)layoutControlItemName).BeginInit();
            ((ISupportInitialize)layoutControlItem1).BeginInit();
            ((ISupportInitialize)layoutControlItem2).BeginInit();
            ((ISupportInitialize)emptySpaceItem1).BeginInit();
            ((ISupportInitialize)dxValidationProvider).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(340, 138);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(320, 41);
            btnCancel.StyleController = layoutControl;
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(14, 138);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(320, 41);
            btnSave.StyleController = layoutControl;
            btnSave.TabIndex = 2;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(btnCancel);
            layoutControl.Controls.Add(btnSave);
            layoutControl.Controls.Add(textEditName);
            layoutControl.Dock = DockStyle.Fill;
            layoutControl.Location = new System.Drawing.Point(0, 0);
            layoutControl.Name = "layoutControl";
            layoutControl.Root = Root;
            layoutControl.Size = new System.Drawing.Size(674, 195);
            layoutControl.TabIndex = 1;
            layoutControl.Text = "layoutControl";
            // 
            // textEditName
            // 
            textEditName.Location = new System.Drawing.Point(14, 49);
            textEditName.Name = "textEditName";
            textEditName.Size = new System.Drawing.Size(646, 48);
            textEditName.StyleController = layoutControl;
            textEditName.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Значение не может быть пустым";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            dxValidationProvider.SetValidationRule(textEditName, conditionValidationRule1);
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemName, layoutControlItem1, layoutControlItem2, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(674, 195);
            Root.TextVisible = false;
            // 
            // layoutControlItemName
            // 
            layoutControlItemName.Control = textEditName;
            layoutControlItemName.Location = new System.Drawing.Point(0, 0);
            layoutControlItemName.Name = "layoutControlItemName";
            layoutControlItemName.Size = new System.Drawing.Size(652, 87);
            layoutControlItemName.Text = "Название:";
            layoutControlItemName.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItemName.TextSize = new System.Drawing.Size(92, 28);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnSave;
            layoutControlItem1.Location = new System.Drawing.Point(0, 122);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(326, 47);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btnCancel;
            layoutControlItem2.Location = new System.Drawing.Point(326, 122);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(326, 47);
            layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new System.Drawing.Point(0, 87);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(652, 35);
            // 
            // dxValidationProvider
            // 
            dxValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // AccessGroupEditForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(674, 195);
            Controls.Add(layoutControl);
            Name = "AccessGroupEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Группа доступа";
            Load += AccessGroupEditForm_Load;
            ((ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((ISupportInitialize)textEditName.Properties).EndInit();
            ((ISupportInitialize)Root).EndInit();
            ((ISupportInitialize)layoutControlItemName).EndInit();
            ((ISupportInitialize)layoutControlItem1).EndInit();
            ((ISupportInitialize)layoutControlItem2).EndInit();
            ((ISupportInitialize)emptySpaceItem1).EndInit();
            ((ISupportInitialize)dxValidationProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
} 