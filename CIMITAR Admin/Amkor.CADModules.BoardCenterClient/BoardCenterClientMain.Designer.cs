namespace Amkor.CADModules.BoardCenterClient
{
	// Token: 0x02000003 RID: 3
	public partial class BoardCenterClientMain : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00003F44 File Offset: 0x00002144
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003F64 File Offset: 0x00002164
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.l_subject = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.btn_Insert = new global::System.Windows.Forms.Button();
			this.btn_search = new global::System.Windows.Forms.Button();
			this.tb_barcode = new global::System.Windows.Forms.TextBox();
			this.grid_socket_history = new global::SourceGrid.Grid();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.pb_excel = new global::System.Windows.Forms.PictureBox();
			this.saveFileDialog_csv = new global::System.Windows.Forms.SaveFileDialog();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.l_tcount = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.l_serial = new global::System.Windows.Forms.Label();
			this.l_ptype = new global::System.Windows.Forms.Label();
			this.l_device = new global::System.Windows.Forms.Label();
			this.l_customer = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.btn_search_tester = new global::System.Windows.Forms.Button();
			this.tb_tester = new global::System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_excel).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 727);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1084, 35);
			this.panel1.TabIndex = 10;
			this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f);
			this.label2.Location = new global::System.Drawing.Point(369, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(355, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Copyright ⓒ 2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 11);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(200, 21);
			this.l_subject.TabIndex = 11;
			this.l_subject.Text = "Socket Comment History";
			this.groupBox2.Controls.Add(this.btn_Insert);
			this.groupBox2.Controls.Add(this.btn_search);
			this.groupBox2.Controls.Add(this.tb_barcode);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox2.Location = new global::System.Drawing.Point(16, 36);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Size = new global::System.Drawing.Size(354, 74);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Socket Barcode";
			this.btn_Insert.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_Insert.Location = new global::System.Drawing.Point(260, 32);
			this.btn_Insert.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btn_Insert.Name = "btn_Insert";
			this.btn_Insert.Size = new global::System.Drawing.Size(75, 23);
			this.btn_Insert.TabIndex = 15;
			this.btn_Insert.Text = "Insert";
			this.btn_Insert.UseVisualStyleBackColor = true;
			this.btn_Insert.Click += new global::System.EventHandler(this.btn_Insert_Click);
			this.btn_search.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_search.Location = new global::System.Drawing.Point(177, 32);
			this.btn_search.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new global::System.Drawing.Size(75, 23);
			this.btn_search.TabIndex = 14;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = true;
			this.btn_search.Click += new global::System.EventHandler(this.btn_search_Click);
			this.tb_barcode.Location = new global::System.Drawing.Point(16, 32);
			this.tb_barcode.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_barcode.Name = "tb_barcode";
			this.tb_barcode.Size = new global::System.Drawing.Size(143, 23);
			this.tb_barcode.TabIndex = 12;
			this.tb_barcode.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tb_barcode_KeyDown);
			this.grid_socket_history.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_socket_history.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_socket_history.EnableSort = true;
			this.grid_socket_history.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_socket_history.Location = new global::System.Drawing.Point(0, 0);
			this.grid_socket_history.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grid_socket_history.Name = "grid_socket_history";
			this.grid_socket_history.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_socket_history.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_socket_history.Size = new global::System.Drawing.Size(1056, 509);
			this.grid_socket_history.TabIndex = 15;
			this.grid_socket_history.TabStop = true;
			this.grid_socket_history.ToolTipText = "";
			this.panel2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel2.Controls.Add(this.grid_socket_history);
			this.panel2.Location = new global::System.Drawing.Point(16, 211);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1056, 509);
			this.panel2.TabIndex = 16;
			this.groupBox1.Controls.Add(this.pb_excel);
			this.groupBox1.Location = new global::System.Drawing.Point(376, 36);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(73, 74);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Option";
			this.pb_excel.Image = global::Amkor.CADModules.BoardCenterClient.Properties.Resources.SaveExcel;
			this.pb_excel.Location = new global::System.Drawing.Point(21, 26);
			this.pb_excel.Name = "pb_excel";
			this.pb_excel.Size = new global::System.Drawing.Size(32, 32);
			this.pb_excel.TabIndex = 0;
			this.pb_excel.TabStop = false;
			this.pb_excel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_excel_MouseDown);
			this.pb_excel.MouseLeave += new global::System.EventHandler(this.pb_excel_MouseLeave);
			this.pb_excel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pb_excel_MouseMove);
			this.pb_excel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_excel_MouseUp);
			this.groupBox3.Controls.Add(this.l_tcount);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.l_serial);
			this.groupBox3.Controls.Add(this.l_ptype);
			this.groupBox3.Controls.Add(this.l_device);
			this.groupBox3.Controls.Add(this.l_customer);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new global::System.Drawing.Point(16, 118);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(751, 87);
			this.groupBox3.TabIndex = 18;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Socket Information";
			this.l_tcount.AutoSize = true;
			this.l_tcount.Location = new global::System.Drawing.Point(665, 29);
			this.l_tcount.Name = "l_tcount";
			this.l_tcount.Size = new global::System.Drawing.Size(13, 15);
			this.l_tcount.TabIndex = 9;
			this.l_tcount.Text = "0";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(596, 29);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(61, 15);
			this.label6.TabIndex = 8;
			this.label6.Text = "TCOUNT : ";
			this.l_serial.AutoSize = true;
			this.l_serial.Location = new global::System.Drawing.Point(395, 56);
			this.l_serial.Name = "l_serial";
			this.l_serial.Size = new global::System.Drawing.Size(51, 15);
			this.l_serial.TabIndex = 7;
			this.l_serial.Text = "HS-TEST";
			this.l_ptype.AutoSize = true;
			this.l_ptype.Location = new global::System.Drawing.Point(395, 29);
			this.l_ptype.Name = "l_ptype";
			this.l_ptype.Size = new global::System.Drawing.Size(26, 15);
			this.l_ptype.TabIndex = 6;
			this.l_ptype.Text = "3X3";
			this.l_device.AutoSize = true;
			this.l_device.Location = new global::System.Drawing.Point(127, 56);
			this.l_device.Name = "l_device";
			this.l_device.Size = new global::System.Drawing.Size(53, 15);
			this.l_device.TabIndex = 5;
			this.l_device.Text = "NAZGUL";
			this.l_customer.AutoSize = true;
			this.l_customer.Location = new global::System.Drawing.Point(127, 29);
			this.l_customer.Name = "l_customer";
			this.l_customer.Size = new global::System.Drawing.Size(67, 15);
			this.l_customer.TabIndex = 4;
			this.l_customer.Text = "Qualcomm";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(291, 56);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(44, 15);
			this.label5.TabIndex = 3;
			this.label5.Text = "Serial : ";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(291, 29);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(87, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Package Type : ";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(23, 56);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(51, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Device : ";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(23, 29);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(68, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Customer : ";
			this.groupBox4.Controls.Add(this.btn_search_tester);
			this.groupBox4.Controls.Add(this.tb_tester);
			this.groupBox4.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox4.Location = new global::System.Drawing.Point(455, 37);
			this.groupBox4.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Size = new global::System.Drawing.Size(269, 74);
			this.groupBox4.TabIndex = 19;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Tester #";
			this.btn_search_tester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_search_tester.Location = new global::System.Drawing.Point(177, 32);
			this.btn_search_tester.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btn_search_tester.Name = "btn_search_tester";
			this.btn_search_tester.Size = new global::System.Drawing.Size(75, 23);
			this.btn_search_tester.TabIndex = 14;
			this.btn_search_tester.Text = "Search";
			this.btn_search_tester.UseVisualStyleBackColor = true;
			this.btn_search_tester.Click += new global::System.EventHandler(this.btn_search_tester_Click);
			this.tb_tester.Location = new global::System.Drawing.Point(16, 32);
			this.tb_tester.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_tester.Name = "tb_tester";
			this.tb_tester.Size = new global::System.Drawing.Size(143, 23);
			this.tb_tester.TabIndex = 12;
			this.tb_tester.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tb_tester_KeyDown);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1084, 762);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.l_subject);
			base.Controls.Add(this.panel1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "BoardCenterClientMain";
			this.Text = " Socket Comment History";
			base.Load += new global::System.EventHandler(this.BoardCenterClientMain_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_excel).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000027 RID: 39
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Button btn_search;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.TextBox tb_barcode;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Button btn_Insert;

		// Token: 0x0400002F RID: 47
		private global::SourceGrid.Grid grid_socket_history;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.PictureBox pb_excel;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog_csv;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Label l_serial;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Label l_ptype;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Label l_device;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.Label l_customer;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.Label l_tcount;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.Button btn_search_tester;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.TextBox tb_tester;
	}
}
