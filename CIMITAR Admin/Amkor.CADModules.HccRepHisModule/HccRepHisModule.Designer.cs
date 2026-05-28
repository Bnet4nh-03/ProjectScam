namespace Amkor.CADModules.HccRepHisModule
{
	// Token: 0x02000003 RID: 3
	public partial class HccRepHisModule : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00003110 File Offset: 0x00001310
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003130 File Offset: 0x00001330
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.l_subject = new global::System.Windows.Forms.Label();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 712);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1166, 40);
			this.panel1.TabIndex = 20;
			this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(410, 11);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(368, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "Copyright ⓒ 2019 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 8);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(155, 21);
			this.l_subject.TabIndex = 21;
			this.l_subject.Text = "HCC Repair History";
			this.tabControl1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new global::System.Drawing.Point(12, 45);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(1142, 663);
			this.tabControl1.TabIndex = 27;
			this.tabPage1.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(1134, 635);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1166, 752);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.l_subject);
			base.Controls.Add(this.panel1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "HccRepHisModule";
			this.Text = "HCC Repair History";
			base.Load += new global::System.EventHandler(this.HccRepHisModule_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000013 RID: 19
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.TabPage tabPage1;
	}
}
