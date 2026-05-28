namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200003B RID: 59
	public partial class AnsSocketComment : global::System.Windows.Forms.Form
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x00049988 File Offset: 0x00047B88
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x000499A8 File Offset: 0x00047BA8
		private void InitializeComponent()
		{
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.l_copyright = new global::System.Windows.Forms.Label();
			this.splitter10 = new global::System.Windows.Forms.Splitter();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel34 = new global::System.Windows.Forms.Panel();
			this.groupBox42 = new global::System.Windows.Forms.GroupBox();
			this.grid_socket_comment = new global::SourceGrid.Grid();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.groupBox32 = new global::System.Windows.Forms.GroupBox();
			this.groupBox36 = new global::System.Windows.Forms.GroupBox();
			this.pb_comment_excel = new global::System.Windows.Forms.PictureBox();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			this.panel1.SuspendLayout();
			this.panel34.SuspendLayout();
			this.groupBox42.SuspendLayout();
			this.panel7.SuspendLayout();
			this.groupBox32.SuspendLayout();
			this.groupBox36.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_comment_excel).BeginInit();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(952, 44);
			this.panel24.TabIndex = 19;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(164, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Socket Comment";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.l_copyright);
			this.panel25.Controls.Add(this.splitter10);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 526);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(952, 32);
			this.panel25.TabIndex = 25;
			this.l_copyright.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.l_copyright.AutoSize = true;
			this.l_copyright.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.l_copyright.Location = new global::System.Drawing.Point(280, 8);
			this.l_copyright.Name = "l_copyright";
			this.l_copyright.Size = new global::System.Drawing.Size(398, 15);
			this.l_copyright.TabIndex = 15;
			this.l_copyright.Text = "Copyright © 2017-2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.l_copyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.splitter10.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter10.Location = new global::System.Drawing.Point(0, 0);
			this.splitter10.Name = "splitter10";
			this.splitter10.Size = new global::System.Drawing.Size(952, 3);
			this.splitter10.TabIndex = 14;
			this.splitter10.TabStop = false;
			this.panel2.Controls.Add(this.cmdClose);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 475);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(952, 51);
			this.panel2.TabIndex = 32;
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(908, 11);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 98;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			this.panel1.Controls.Add(this.panel34);
			this.panel1.Controls.Add(this.panel7);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 44);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(952, 431);
			this.panel1.TabIndex = 33;
			this.panel34.Controls.Add(this.groupBox42);
			this.panel34.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel34.Location = new global::System.Drawing.Point(0, 99);
			this.panel34.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel34.Name = "panel34";
			this.panel34.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel34.Size = new global::System.Drawing.Size(952, 332);
			this.panel34.TabIndex = 67;
			this.groupBox42.Controls.Add(this.grid_socket_comment);
			this.groupBox42.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox42.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox42.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox42.Name = "groupBox42";
			this.groupBox42.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox42.Size = new global::System.Drawing.Size(946, 328);
			this.groupBox42.TabIndex = 5;
			this.groupBox42.TabStop = false;
			this.groupBox42.Text = "Comment List";
			this.grid_socket_comment.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.grid_socket_comment.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_socket_comment.EnableSort = true;
			this.grid_socket_comment.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.grid_socket_comment.Location = new global::System.Drawing.Point(3, 18);
			this.grid_socket_comment.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grid_socket_comment.Name = "grid_socket_comment";
			this.grid_socket_comment.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_socket_comment.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_socket_comment.Size = new global::System.Drawing.Size(940, 306);
			this.grid_socket_comment.TabIndex = 13;
			this.grid_socket_comment.TabStop = true;
			this.grid_socket_comment.ToolTipText = "";
			this.panel7.Controls.Add(this.groupBox32);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel7.Size = new global::System.Drawing.Size(952, 99);
			this.panel7.TabIndex = 66;
			this.groupBox32.Controls.Add(this.groupBox36);
			this.groupBox32.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox32.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox32.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox32.Name = "groupBox32";
			this.groupBox32.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox32.Size = new global::System.Drawing.Size(946, 93);
			this.groupBox32.TabIndex = 6;
			this.groupBox32.TabStop = false;
			this.groupBox36.Controls.Add(this.pb_comment_excel);
			this.groupBox36.Location = new global::System.Drawing.Point(6, 13);
			this.groupBox36.Name = "groupBox36";
			this.groupBox36.Size = new global::System.Drawing.Size(63, 73);
			this.groupBox36.TabIndex = 17;
			this.groupBox36.TabStop = false;
			this.groupBox36.Text = "Excel";
			this.pb_comment_excel.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.SaveExcel;
			this.pb_comment_excel.Location = new global::System.Drawing.Point(15, 26);
			this.pb_comment_excel.Name = "pb_comment_excel";
			this.pb_comment_excel.Size = new global::System.Drawing.Size(32, 32);
			this.pb_comment_excel.TabIndex = 80;
			this.pb_comment_excel.TabStop = false;
			this.pb_comment_excel.Click += new global::System.EventHandler(this.pb_comment_excel_Click);
			this.pb_comment_excel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_comment_excel_MouseDown);
			this.pb_comment_excel.MouseLeave += new global::System.EventHandler(this.pb_comment_excel_MouseLeave);
			this.pb_comment_excel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pb_comment_excel_MouseMove);
			this.pb_comment_excel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_comment_excel_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(952, 558);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			base.Name = "AnsSocketComment";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AnsSocketComment";
			base.Load += new global::System.EventHandler(this.AnsSocketComment_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel34.ResumeLayout(false);
			this.groupBox42.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.groupBox32.ResumeLayout(false);
			this.groupBox36.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_comment_excel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040004CD RID: 1229
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040004CE RID: 1230
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x040004CF RID: 1231
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x040004D0 RID: 1232
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x040004D1 RID: 1233
		private global::System.Windows.Forms.Label l_copyright;

		// Token: 0x040004D2 RID: 1234
		private global::System.Windows.Forms.Splitter splitter10;

		// Token: 0x040004D3 RID: 1235
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040004D4 RID: 1236
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x040004D5 RID: 1237
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040004D6 RID: 1238
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x040004D7 RID: 1239
		private global::System.Windows.Forms.GroupBox groupBox32;

		// Token: 0x040004D8 RID: 1240
		private global::System.Windows.Forms.GroupBox groupBox36;

		// Token: 0x040004D9 RID: 1241
		private global::System.Windows.Forms.PictureBox pb_comment_excel;

		// Token: 0x040004DA RID: 1242
		private global::System.Windows.Forms.Panel panel34;

		// Token: 0x040004DB RID: 1243
		private global::System.Windows.Forms.GroupBox groupBox42;

		// Token: 0x040004DC RID: 1244
		private global::SourceGrid.Grid grid_socket_comment;
	}
}
