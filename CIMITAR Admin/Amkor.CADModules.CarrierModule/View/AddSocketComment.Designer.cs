namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000038 RID: 56
	public partial class AddSocketComment : global::System.Windows.Forms.Form
	{
		// Token: 0x0600027E RID: 638 RVA: 0x00045A4F File Offset: 0x00043C4F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00045A70 File Offset: 0x00043C70
		private void InitializeComponent()
		{
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.l_copyright = new global::System.Windows.Forms.Label();
			this.splitter10 = new global::System.Windows.Forms.Splitter();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.cmbTester = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tb_site = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.tb_name = new global::System.Windows.Forms.TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.tb_comment = new global::System.Windows.Forms.TextBox();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.cmdModify = new global::System.Windows.Forms.PictureBox();
			this.label23 = new global::System.Windows.Forms.Label();
			this.cmb_comment = new global::System.Windows.Forms.ComboBox();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModify).BeginInit();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(643, 44);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(221, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Insert Socket Comment";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.l_copyright);
			this.panel25.Controls.Add(this.splitter10);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 298);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(643, 32);
			this.panel25.TabIndex = 24;
			this.l_copyright.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.l_copyright.AutoSize = true;
			this.l_copyright.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.l_copyright.Location = new global::System.Drawing.Point(125, 8);
			this.l_copyright.Name = "l_copyright";
			this.l_copyright.Size = new global::System.Drawing.Size(398, 15);
			this.l_copyright.TabIndex = 15;
			this.l_copyright.Text = "Copyright © 2017-2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.l_copyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.splitter10.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter10.Location = new global::System.Drawing.Point(0, 0);
			this.splitter10.Name = "splitter10";
			this.splitter10.Size = new global::System.Drawing.Size(643, 3);
			this.splitter10.TabIndex = 14;
			this.splitter10.TabStop = false;
			this.panel3.Controls.Add(this.groupBox3);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 44);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(5, 0, 5, 0);
			this.panel3.Size = new global::System.Drawing.Size(643, 254);
			this.panel3.TabIndex = 25;
			this.groupBox3.Controls.Add(this.cmb_comment);
			this.groupBox3.Controls.Add(this.cmbTester);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.tb_site);
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
			this.groupBox3.Size = new global::System.Drawing.Size(633, 254);
			this.groupBox3.TabIndex = 41;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Insert Information";
			this.cmbTester.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbTester.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbTester.FormattingEnabled = true;
			this.cmbTester.Location = new global::System.Drawing.Point(68, 22);
			this.cmbTester.Name = "cmbTester";
			this.cmbTester.Size = new global::System.Drawing.Size(236, 23);
			this.cmbTester.TabIndex = 56;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(3, 25);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(38, 15);
			this.label2.TabIndex = 55;
			this.label2.Text = "Tester";
			this.tb_site.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.tb_site.Location = new global::System.Drawing.Point(68, 52);
			this.tb_site.Name = "tb_site";
			this.tb_site.Size = new global::System.Drawing.Size(235, 23);
			this.tb_site.TabIndex = 0;
			this.tb_site.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tb_site_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(3, 88);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(39, 15);
			this.label4.TabIndex = 32;
			this.label4.Text = "Name";
			this.tb_name.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.tb_name.Location = new global::System.Drawing.Point(68, 85);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new global::System.Drawing.Size(235, 23);
			this.tb_name.TabIndex = 1;
			this.tb_name.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tb_name_KeyPress);
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(3, 123);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(61, 15);
			this.label16.TabIndex = 22;
			this.label16.Text = "Comment";
			this.tb_comment.Location = new global::System.Drawing.Point(372, 22);
			this.tb_comment.Multiline = true;
			this.tb_comment.Name = "tb_comment";
			this.tb_comment.Size = new global::System.Drawing.Size(245, 79);
			this.tb_comment.TabIndex = 2;
			this.tb_comment.Visible = false;
			this.tb_comment.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tb_comment_KeyPress);
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(585, 205);
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
			this.cmdModify.Location = new global::System.Drawing.Point(547, 205);
			this.cmdModify.Name = "cmdModify";
			this.cmdModify.Size = new global::System.Drawing.Size(32, 32);
			this.cmdModify.TabIndex = 22;
			this.cmdModify.TabStop = false;
			this.cmdModify.Click += new global::System.EventHandler(this.cmdModify_Click);
			this.cmdModify.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseDown);
			this.cmdModify.MouseLeave += new global::System.EventHandler(this.cmdModify_MouseLeave);
			this.cmdModify.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseMove);
			this.cmdModify.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseUp);
			this.label23.AutoSize = true;
			this.label23.Location = new global::System.Drawing.Point(3, 55);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(26, 15);
			this.label23.TabIndex = 4;
			this.label23.Text = "Site";
			this.cmb_comment.FormattingEnabled = true;
			this.cmb_comment.Location = new global::System.Drawing.Point(68, 123);
			this.cmb_comment.Name = "cmb_comment";
			this.cmb_comment.Size = new global::System.Drawing.Size(549, 23);
			this.cmb_comment.TabIndex = 57;
			this.cmb_comment.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.cmb_comment_KeyPress);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(643, 330);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MaximizeBox = false;
			base.Name = "AddSocketComment";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AddSocketComment";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.AddSocketComment_FormClosed);
			base.Load += new global::System.EventHandler(this.AddSocketComment_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModify).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000462 RID: 1122
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000463 RID: 1123
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000464 RID: 1124
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x04000465 RID: 1125
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000466 RID: 1126
		private global::System.Windows.Forms.Label l_copyright;

		// Token: 0x04000467 RID: 1127
		private global::System.Windows.Forms.Splitter splitter10;

		// Token: 0x04000468 RID: 1128
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000469 RID: 1129
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x0400046A RID: 1130
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400046B RID: 1131
		private global::System.Windows.Forms.TextBox tb_site;

		// Token: 0x0400046C RID: 1132
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400046D RID: 1133
		private global::System.Windows.Forms.TextBox tb_name;

		// Token: 0x0400046E RID: 1134
		private global::System.Windows.Forms.Label label16;

		// Token: 0x0400046F RID: 1135
		private global::System.Windows.Forms.TextBox tb_comment;

		// Token: 0x04000470 RID: 1136
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x04000471 RID: 1137
		private global::System.Windows.Forms.PictureBox cmdModify;

		// Token: 0x04000472 RID: 1138
		private global::System.Windows.Forms.Label label23;

		// Token: 0x04000473 RID: 1139
		private global::System.Windows.Forms.ComboBox cmbTester;

		// Token: 0x04000474 RID: 1140
		private global::System.Windows.Forms.ComboBox cmb_comment;
	}
}
