namespace Amkor.CADModules.BIBoardInfoModule
{
	// Token: 0x0200001B RID: 27
	public partial class BIBoardInfoModule : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x0600005D RID: 93 RVA: 0x000099C9 File Offset: 0x00007BC9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000099E8 File Offset: 0x00007BE8
		private void InitializeComponent()
		{
			this.l_subject = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.validatorTypeConverter1 = new global::DevAge.ComponentModel.Validator.ValidatorTypeConverter();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.pb_Help = new global::System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Help).BeginInit();
			base.SuspendLayout();
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 8);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(257, 21);
			this.l_subject.TabIndex = 20;
			this.l_subject.Text = "Burn In Board Integrated System";
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 712);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1166, 40);
			this.panel1.TabIndex = 19;
			this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(410, 11);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(367, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "Copyright ⓒ 2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.tabControl1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new global::System.Drawing.Point(12, 44);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(1142, 663);
			this.tabControl1.TabIndex = 26;
			this.tabPage1.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(1134, 635);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.pb_Help.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Help.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.Help;
			this.pb_Help.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.Help;
			this.pb_Help.Location = new global::System.Drawing.Point(1118, 23);
			this.pb_Help.Name = "pb_Help";
			this.pb_Help.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Help.TabIndex = 27;
			this.pb_Help.TabStop = false;
			this.pb_Help.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Help_MouseDown);
			this.pb_Help.MouseLeave += new global::System.EventHandler(this.pb_Help_MouseLeave);
			this.pb_Help.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pb_Help_MouseMove);
			this.pb_Help.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Help_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1166, 752);
			base.Controls.Add(this.pb_Help);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.l_subject);
			base.Controls.Add(this.panel1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "BIBoardInfoModule";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Burn In Board Information";
			base.Load += new global::System.EventHandler(this.BIBoardInfoModule_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Help).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000E3 RID: 227
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000E7 RID: 231
		private global::DevAge.ComponentModel.Validator.ValidatorTypeConverter validatorTypeConverter1;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.PictureBox pb_Help;
	}
}
