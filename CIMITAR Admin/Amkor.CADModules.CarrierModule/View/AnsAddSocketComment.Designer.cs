namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200003A RID: 58
	public partial class AnsAddSocketComment : global::System.Windows.Forms.Form
	{
		// Token: 0x060002A0 RID: 672 RVA: 0x00047D54 File Offset: 0x00045F54
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00047D74 File Offset: 0x00045F74
		private void InitializeComponent()
		{
			this.tb_pincount = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.tb_name = new global::System.Windows.Forms.TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.tb_comment = new global::System.Windows.Forms.TextBox();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.cmdModify = new global::System.Windows.Forms.PictureBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.label23 = new global::System.Windows.Forms.Label();
			this.l_copyright = new global::System.Windows.Forms.Label();
			this.splitter10 = new global::System.Windows.Forms.Splitter();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel24 = new global::System.Windows.Forms.Panel();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModify).BeginInit();
			this.panel3.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel24.SuspendLayout();
			base.SuspendLayout();
			this.tb_pincount.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.tb_pincount.Location = new global::System.Drawing.Point(68, 23);
			this.tb_pincount.Name = "tb_pincount";
			this.tb_pincount.Size = new global::System.Drawing.Size(235, 23);
			this.tb_pincount.TabIndex = 0;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(3, 59);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(39, 15);
			this.label4.TabIndex = 32;
			this.label4.Text = "Name";
			this.tb_name.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.tb_name.Location = new global::System.Drawing.Point(68, 56);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new global::System.Drawing.Size(235, 23);
			this.tb_name.TabIndex = 1;
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(3, 94);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(61, 15);
			this.label16.TabIndex = 22;
			this.label16.Text = "Comment";
			this.tb_comment.Location = new global::System.Drawing.Point(66, 91);
			this.tb_comment.Multiline = true;
			this.tb_comment.Name = "tb_comment";
			this.tb_comment.Size = new global::System.Drawing.Size(560, 73);
			this.tb_comment.TabIndex = 2;
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(587, 179);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 23;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			this.cmdModify.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdModify.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdModify.Location = new global::System.Drawing.Point(549, 179);
			this.cmdModify.Name = "cmdModify";
			this.cmdModify.Size = new global::System.Drawing.Size(32, 32);
			this.cmdModify.TabIndex = 22;
			this.cmdModify.TabStop = false;
			this.cmdModify.Click += new global::System.EventHandler(this.cmdModify_Click);
			this.cmdModify.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseDown);
			this.cmdModify.MouseLeave += new global::System.EventHandler(this.cmdModify_MouseLeave);
			this.cmdModify.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseMove);
			this.cmdModify.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseUp);
			this.panel3.Controls.Add(this.groupBox3);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 44);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(5, 0, 5, 0);
			this.panel3.Size = new global::System.Drawing.Size(645, 228);
			this.panel3.TabIndex = 28;
			this.groupBox3.Controls.Add(this.tb_pincount);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.tb_name);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.tb_comment);
			this.groupBox3.Controls.Add(this.cmdClose);
			this.groupBox3.Controls.Add(this.cmdModify);
			this.groupBox3.Controls.Add(this.label23);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new global::System.Drawing.Point(5, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(635, 228);
			this.groupBox3.TabIndex = 41;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Insert Information";
			this.label23.AutoSize = true;
			this.label23.Location = new global::System.Drawing.Point(3, 26);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(60, 15);
			this.label23.TabIndex = 4;
			this.label23.Text = "Pin Count";
			this.l_copyright.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.l_copyright.AutoSize = true;
			this.l_copyright.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.l_copyright.Location = new global::System.Drawing.Point(126, 8);
			this.l_copyright.Name = "l_copyright";
			this.l_copyright.Size = new global::System.Drawing.Size(398, 15);
			this.l_copyright.TabIndex = 15;
			this.l_copyright.Text = "Copyright © 2017-2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.l_copyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.splitter10.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter10.Location = new global::System.Drawing.Point(0, 0);
			this.splitter10.Name = "splitter10";
			this.splitter10.Size = new global::System.Drawing.Size(645, 3);
			this.splitter10.TabIndex = 14;
			this.splitter10.TabStop = false;
			this.panel25.Controls.Add(this.l_copyright);
			this.panel25.Controls.Add(this.splitter10);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 272);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(645, 32);
			this.panel25.TabIndex = 27;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(221, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Insert Socket Comment";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(645, 44);
			this.panel24.TabIndex = 26;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(645, 304);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "AnsAddSocketComment";
			this.Text = "AnsAddSocketComment";
			base.Load += new global::System.EventHandler(this.AnsAddSocketComment_Load);
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModify).EndInit();
			this.panel3.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040004A0 RID: 1184
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040004A1 RID: 1185
		private global::System.Windows.Forms.TextBox tb_pincount;

		// Token: 0x040004A2 RID: 1186
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040004A3 RID: 1187
		private global::System.Windows.Forms.TextBox tb_name;

		// Token: 0x040004A4 RID: 1188
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040004A5 RID: 1189
		private global::System.Windows.Forms.TextBox tb_comment;

		// Token: 0x040004A6 RID: 1190
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x040004A7 RID: 1191
		private global::System.Windows.Forms.PictureBox cmdModify;

		// Token: 0x040004A8 RID: 1192
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040004A9 RID: 1193
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040004AA RID: 1194
		private global::System.Windows.Forms.Label label23;

		// Token: 0x040004AB RID: 1195
		private global::System.Windows.Forms.Label l_copyright;

		// Token: 0x040004AC RID: 1196
		private global::System.Windows.Forms.Splitter splitter10;

		// Token: 0x040004AD RID: 1197
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x040004AE RID: 1198
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x040004AF RID: 1199
		private global::System.Windows.Forms.Panel panel24;
	}
}
