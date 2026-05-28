namespace Amkor.CADModules.BoardCenterClient
{
	// Token: 0x02000004 RID: 4
	public partial class InsertCommentView : global::System.Windows.Forms.Form
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00005C1C File Offset: 0x00003E1C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005C3C File Offset: 0x00003E3C
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btn_close = new global::System.Windows.Forms.Button();
			this.btn_ok = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.grid_tester_list = new global::SourceGrid.Grid();
			this.tb_testername = new global::System.Windows.Forms.TextBox();
			this.tb_comment = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.tb_name = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.tb_site = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.btn_select = new global::System.Windows.Forms.Button();
			this.l_Tester = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 481);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(595, 28);
			this.panel1.TabIndex = 11;
			this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f);
			this.label2.Location = new global::System.Drawing.Point(124, 7);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(358, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Copyright ⓒ 2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.btn_close.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_close.Location = new global::System.Drawing.Point(494, 443);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new global::System.Drawing.Size(75, 23);
			this.btn_close.TabIndex = 28;
			this.btn_close.Text = "Close";
			this.btn_close.UseVisualStyleBackColor = true;
			this.btn_close.Click += new global::System.EventHandler(this.btn_close_Click);
			this.btn_ok.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_ok.Location = new global::System.Drawing.Point(407, 443);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new global::System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 27;
			this.btn_ok.Text = "Request";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new global::System.EventHandler(this.btn_ok_Click);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.tb_testername);
			this.groupBox1.Controls.Add(this.tb_comment);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tb_name);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_site);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.btn_select);
			this.groupBox1.Controls.Add(this.l_Tester);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(571, 415);
			this.groupBox1.TabIndex = 29;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Insert Information";
			this.panel2.Controls.Add(this.grid_tester_list);
			this.panel2.Location = new global::System.Drawing.Point(103, 88);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(218, 193);
			this.panel2.TabIndex = 40;
			this.grid_tester_list.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_tester_list.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_tester_list.EnableSort = true;
			this.grid_tester_list.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_tester_list.Location = new global::System.Drawing.Point(0, 0);
			this.grid_tester_list.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grid_tester_list.Name = "grid_tester_list";
			this.grid_tester_list.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_tester_list.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_tester_list.Size = new global::System.Drawing.Size(218, 193);
			this.grid_tester_list.TabIndex = 39;
			this.grid_tester_list.TabStop = true;
			this.grid_tester_list.ToolTipText = "";
			this.grid_tester_list.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_tester_list_MouseClick);
			this.tb_testername.Location = new global::System.Drawing.Point(102, 59);
			this.tb_testername.Name = "tb_testername";
			this.tb_testername.Size = new global::System.Drawing.Size(129, 23);
			this.tb_testername.TabIndex = 38;
			this.tb_comment.Location = new global::System.Drawing.Point(103, 374);
			this.tb_comment.Name = "tb_comment";
			this.tb_comment.Size = new global::System.Drawing.Size(405, 23);
			this.tb_comment.TabIndex = 37;
			this.tb_comment.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tb_comment_KeyPress);
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label6.Location = new global::System.Drawing.Point(22, 377);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(67, 15);
			this.label6.TabIndex = 36;
			this.label6.Text = "Comment :";
			this.tb_name.Location = new global::System.Drawing.Point(103, 333);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new global::System.Drawing.Size(203, 23);
			this.tb_name.TabIndex = 35;
			this.tb_name.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tb_name_KeyPress);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label3.Location = new global::System.Drawing.Point(22, 336);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(48, 15);
			this.label3.TabIndex = 34;
			this.label3.Text = "Name : ";
			this.tb_site.Location = new global::System.Drawing.Point(103, 292);
			this.tb_site.Name = "tb_site";
			this.tb_site.Size = new global::System.Drawing.Size(203, 23);
			this.tb_site.TabIndex = 33;
			this.tb_site.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tb_site_KeyPress);
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label5.Location = new global::System.Drawing.Point(22, 295);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(35, 15);
			this.label5.TabIndex = 31;
			this.label5.Text = "Site : ";
			this.btn_select.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_select.Location = new global::System.Drawing.Point(246, 58);
			this.btn_select.Name = "btn_select";
			this.btn_select.Size = new global::System.Drawing.Size(75, 23);
			this.btn_select.TabIndex = 30;
			this.btn_select.Text = "Search";
			this.btn_select.UseVisualStyleBackColor = true;
			this.btn_select.Click += new global::System.EventHandler(this.btn_select_Click);
			this.l_Tester.AutoSize = true;
			this.l_Tester.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.l_Tester.Location = new global::System.Drawing.Point(99, 27);
			this.l_Tester.Name = "l_Tester";
			this.l_Tester.Size = new global::System.Drawing.Size(29, 15);
			this.l_Tester.TabIndex = 3;
			this.l_Tester.Text = "N/A";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label4.Location = new global::System.Drawing.Point(21, 27);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(48, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Tester : ";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(595, 509);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btn_close);
			base.Controls.Add(this.btn_ok);
			base.Controls.Add(this.panel1);
			base.Name = "InsertCommentView";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "InsertCommentView";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.InsertCommentView_FormClosed);
			base.Load += new global::System.EventHandler(this.InsertCommentView_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400005B RID: 91
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.Button btn_close;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.Button btn_ok;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.TextBox tb_comment;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.TextBox tb_name;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.TextBox tb_site;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.Button btn_select;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.Label l_Tester;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.TextBox tb_testername;

		// Token: 0x0400006B RID: 107
		private global::SourceGrid.Grid grid_tester_list;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.Panel panel2;
	}
}
