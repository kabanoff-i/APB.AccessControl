namespace APB.AccessControl.ManageApp.Forms
{
    partial class NotificationEditForm
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
            txtMessage = new DevExpress.XtraEditors.MemoEdit();
            chkShowOnPass = new DevExpress.XtraEditors.CheckEdit();
            dateExpiration = new DevExpress.XtraEditors.DateEdit();
            lookUpEmployee = new DevExpress.XtraEditors.LookUpEdit();
            lookUpAccessPoint = new DevExpress.XtraEditors.LookUpEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMessage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkShowOnPass.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateExpiration.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateExpiration.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEmployee.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpAccessPoint.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            SuspendLayout();
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(txtMessage);
            layoutControl.Controls.Add(chkShowOnPass);
            layoutControl.Controls.Add(dateExpiration);
            layoutControl.Controls.Add(lookUpEmployee);
            layoutControl.Controls.Add(lookUpAccessPoint);
            layoutControl.Controls.Add(btnSave);
            layoutControl.Controls.Add(btnCancel);
            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl.Location = new System.Drawing.Point(0, 0);
            layoutControl.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            layoutControl.Name = "layoutControl";
            layoutControl.Root = layoutControlGroup;
            layoutControl.Size = new System.Drawing.Size(683, 346);
            layoutControl.TabIndex = 0;
            layoutControl.Text = "layoutControl1";
            // 
            // txtMessage
            // 
            txtMessage.Location = new System.Drawing.Point(139, 12);
            txtMessage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new System.Drawing.Size(532, 191);
            txtMessage.StyleController = layoutControl;
            txtMessage.TabIndex = 5;
            // 
            // chkShowOnPass
            // 
            chkShowOnPass.Location = new System.Drawing.Point(12, 239);
            chkShowOnPass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            chkShowOnPass.Name = "chkShowOnPass";
            chkShowOnPass.Properties.Caption = "Показывать при проходе";
            chkShowOnPass.Size = new System.Drawing.Size(659, 27);
            chkShowOnPass.StyleController = layoutControl;
            chkShowOnPass.TabIndex = 6;
            chkShowOnPass.CheckedChanged += chkShowOnPass_CheckedChanged;
            // 
            // dateExpiration
            // 
            dateExpiration.EditValue = null;
            dateExpiration.Location = new System.Drawing.Point(139, 207);
            dateExpiration.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            dateExpiration.Name = "dateExpiration";
            dateExpiration.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateExpiration.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateExpiration.Properties.CalendarTimeProperties.Mask.EditMask = "dd.MM.yyyy HH:mm";
            dateExpiration.Properties.CalendarTimeProperties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateExpiration.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = true;
            dateExpiration.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm";
            dateExpiration.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateExpiration.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateExpiration.Size = new System.Drawing.Size(532, 28);
            dateExpiration.StyleController = layoutControl;
            dateExpiration.TabIndex = 7;
            // 
            // lookUpEmployee
            // 
            lookUpEmployee.Location = new System.Drawing.Point(139, 270);
            lookUpEmployee.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lookUpEmployee.Name = "lookUpEmployee";
            lookUpEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEmployee.Properties.NullText = "Выберите сотрудника...";
            lookUpEmployee.Properties.PopupFormSize = new System.Drawing.Size(800, 400);
            lookUpEmployee.Size = new System.Drawing.Size(532, 28);
            lookUpEmployee.StyleController = layoutControl;
            lookUpEmployee.TabIndex = 8;
            // 
            // lookUpAccessPoint
            // 
            lookUpAccessPoint.Location = new System.Drawing.Point(139, 179);
            lookUpAccessPoint.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            lookUpAccessPoint.Name = "lookUpAccessPoint";
            lookUpAccessPoint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpAccessPoint.Properties.NullText = "Выберите точку доступа...";
            lookUpAccessPoint.Properties.PopupFormSize = new System.Drawing.Size(800, 400);
            lookUpAccessPoint.Size = new System.Drawing.Size(532, 28);
            lookUpAccessPoint.StyleController = layoutControl;
            lookUpAccessPoint.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(12, 302);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(327, 32);
            btnSave.StyleController = layoutControl;
            btnSave.TabIndex = 9;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(343, 302);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(328, 32);
            btnCancel.StyleController = layoutControl;
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // layoutControlGroup
            // 
            layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup.GroupBordersVisible = false;
            layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem7 });
            layoutControlGroup.Name = "layoutControlGroup";
            layoutControlGroup.Size = new System.Drawing.Size(683, 346);
            layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtMessage;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(663, 167);
            layoutControlItem1.Text = "Сообщение:";
            layoutControlItem1.TextSize = new System.Drawing.Size(115, 21);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = dateExpiration;
            layoutControlItem2.Location = new System.Drawing.Point(0, 195);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(663, 28);
            layoutControlItem2.Text = "Дата истечения:";
            layoutControlItem2.TextSize = new System.Drawing.Size(115, 21);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = chkShowOnPass;
            layoutControlItem3.Location = new System.Drawing.Point(0, 227);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(663, 27);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = lookUpEmployee;
            layoutControlItem4.Location = new System.Drawing.Point(0, 254);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(663, 36);
            layoutControlItem4.Text = "Сотрудник:";
            layoutControlItem4.TextSize = new System.Drawing.Size(115, 21);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = btnSave;
            layoutControlItem5.Location = new System.Drawing.Point(0, 290);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(331, 36);
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = btnCancel;
            layoutControlItem6.Location = new System.Drawing.Point(331, 290);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(332, 36);
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = lookUpAccessPoint;
            layoutControlItem7.Location = new System.Drawing.Point(0, 167);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(663, 28);
            layoutControlItem7.Text = "Точка доступа:";
            layoutControlItem7.TextSize = new System.Drawing.Size(115, 21);
            // 
            // NotificationEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(683, 346);
            Controls.Add(layoutControl);
            Font = new System.Drawing.Font("Segoe UI", 8F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NotificationEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Уведомление";
            Load += new System.EventHandler(this.EditNotificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtMessage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkShowOnPass.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateExpiration.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateExpiration.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEmployee.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpAccessPoint.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.MemoEdit txtMessage;
        private DevExpress.XtraEditors.CheckEdit chkShowOnPass;
        private DevExpress.XtraEditors.DateEdit dateExpiration;
        private DevExpress.XtraEditors.LookUpEdit lookUpEmployee;
        private DevExpress.XtraEditors.LookUpEdit lookUpAccessPoint;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
} 