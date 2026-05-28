namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000022 RID: 34
	public partial class BIBoardPMList : global::System.Windows.Forms.Form
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x0000DA18 File Offset: 0x0000BC18
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000DA38 File Offset: 0x0000BC38
		private void InitializeComponent()
		{
			this.l_subject = new global::System.Windows.Forms.Label();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.grid_biboard_PM_List = new global::SourceGrid.Grid();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.l_barcode = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.l_location = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.l_customer = new global::System.Windows.Forms.Label();
			this.l_device = new global::System.Windows.Forms.Label();
			this.l_bib_No = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.btn_search = new global::System.Windows.Forms.Button();
			this.tb_biboardno = new global::System.Windows.Forms.TextBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.tb_PM_Info = new global::System.Windows.Forms.TextBox();
			this.pb_PM_Info = new global::System.Windows.Forms.PictureBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_PM_Info).BeginInit();
			base.SuspendLayout();
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 8);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(173, 21);
			this.l_subject.TabIndex = 21;
			this.l_subject.Text = "Burn In Board PM List";
			this.tabControl1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new global::System.Drawing.Point(16, 219);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(1071, 346);
			this.tabControl1.TabIndex = 29;
			this.tabPage1.Controls.Add(this.grid_biboard_PM_List);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(1063, 318);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Burn In PM List";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.grid_biboard_PM_List.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_biboard_PM_List.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_biboard_PM_List.EnableSort = true;
			this.grid_biboard_PM_List.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_biboard_PM_List.Location = new global::System.Drawing.Point(3, 3);
			this.grid_biboard_PM_List.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_biboard_PM_List.Name = "grid_biboard_PM_List";
			this.grid_biboard_PM_List.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_biboard_PM_List.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_biboard_PM_List.Size = new global::System.Drawing.Size(1057, 312);
			this.grid_biboard_PM_List.TabIndex = 16;
			this.grid_biboard_PM_List.TabStop = true;
			this.grid_biboard_PM_List.ToolTipText = "";
			this.grid_biboard_PM_List.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_biboard_PM_List_MouseClick);
			this.groupBox3.Controls.Add(this.l_barcode);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.l_location);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.l_customer);
			this.groupBox3.Controls.Add(this.l_device);
			this.groupBox3.Controls.Add(this.l_bib_No);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox3.Location = new global::System.Drawing.Point(16, 117);
			this.groupBox3.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Size = new global::System.Drawing.Size(818, 95);
			this.groupBox3.TabIndex = 28;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "BI Board Information";
			this.l_barcode.AutoSize = true;
			this.l_barcode.Location = new global::System.Drawing.Point(695, 30);
			this.l_barcode.Name = "l_barcode";
			this.l_barcode.Size = new global::System.Drawing.Size(79, 15);
			this.l_barcode.TabIndex = 10;
			this.l_barcode.Text = "ABBURN IN-7";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(591, 30);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 15);
			this.label7.TabIndex = 9;
			this.label7.Text = "Barcode :";
			this.l_location.AutoSize = true;
			this.l_location.Location = new global::System.Drawing.Point(395, 64);
			this.l_location.Name = "l_location";
			this.l_location.Size = new global::System.Drawing.Size(64, 15);
			this.l_location.TabIndex = 8;
			this.l_location.Text = "BURN IN-7";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(291, 64);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(59, 15);
			this.label6.TabIndex = 7;
			this.label6.Text = "Location :";
			this.l_customer.AutoSize = true;
			this.l_customer.Location = new global::System.Drawing.Point(395, 30);
			this.l_customer.Name = "l_customer";
			this.l_customer.Size = new global::System.Drawing.Size(77, 15);
			this.l_customer.TabIndex = 6;
			this.l_customer.Text = "QUALCOMM";
			this.l_device.AutoSize = true;
			this.l_device.Location = new global::System.Drawing.Point(127, 64);
			this.l_device.Name = "l_device";
			this.l_device.Size = new global::System.Drawing.Size(86, 15);
			this.l_device.TabIndex = 5;
			this.l_device.Text = "RADAGAST AU";
			this.l_bib_No.AutoSize = true;
			this.l_bib_No.Location = new global::System.Drawing.Point(127, 30);
			this.l_bib_No.Name = "l_bib_No";
			this.l_bib_No.Size = new global::System.Drawing.Size(38, 15);
			this.l_bib_No.TabIndex = 4;
			this.l_bib_No.Text = "#1029";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(291, 30);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(68, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Customer : ";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(23, 64);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(51, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Device : ";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(23, 30);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(44, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "BIB ID :";
			this.groupBox2.Controls.Add(this.btn_search);
			this.groupBox2.Controls.Add(this.tb_biboardno);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox2.Location = new global::System.Drawing.Point(16, 39);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Size = new global::System.Drawing.Size(268, 69);
			this.groupBox2.TabIndex = 27;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "BI Board No";
			this.btn_search.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_search.Location = new global::System.Drawing.Point(171, 25);
			this.btn_search.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new global::System.Drawing.Size(75, 29);
			this.btn_search.TabIndex = 14;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = true;
			this.btn_search.Click += new global::System.EventHandler(this.btn_search_Click);
			this.tb_biboardno.Location = new global::System.Drawing.Point(22, 31);
			this.tb_biboardno.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_biboardno.Name = "tb_biboardno";
			this.tb_biboardno.Size = new global::System.Drawing.Size(143, 23);
			this.tb_biboardno.TabIndex = 12;
			this.tb_biboardno.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tb_biboardno_KeyDown);
			this.groupBox1.Controls.Add(this.tb_PM_Info);
			this.groupBox1.Controls.Add(this.pb_PM_Info);
			this.groupBox1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox1.Location = new global::System.Drawing.Point(290, 39);
			this.groupBox1.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox1.Size = new global::System.Drawing.Size(185, 69);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PM Info";
			this.tb_PM_Info.BackColor = global::System.Drawing.Color.Red;
			this.tb_PM_Info.ForeColor = global::System.Drawing.Color.White;
			this.tb_PM_Info.Location = new global::System.Drawing.Point(53, 29);
			this.tb_PM_Info.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_PM_Info.Name = "tb_PM_Info";
			this.tb_PM_Info.ReadOnly = true;
			this.tb_PM_Info.Size = new global::System.Drawing.Size(83, 23);
			this.tb_PM_Info.TabIndex = 31;
			this.tb_PM_Info.Text = "NEED TO PM";
			this.tb_PM_Info.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.pb_PM_Info.BackColor = global::System.Drawing.Color.Red;
			this.pb_PM_Info.Location = new global::System.Drawing.Point(16, 21);
			this.pb_PM_Info.Name = "pb_PM_Info";
			this.pb_PM_Info.Size = new global::System.Drawing.Size(155, 36);
			this.pb_PM_Info.TabIndex = 0;
			this.pb_PM_Info.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1099, 577);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.l_subject);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "BIBoardPMList";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BIBoardPMList";
			base.Load += new global::System.EventHandler(this.BIBoardPMList_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.BIBoardPMList_KeyDown);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_PM_Info).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400012E RID: 302
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x04000132 RID: 306
		private global::SourceGrid.Grid grid_biboard_PM_List;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Label l_barcode;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.Label l_location;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.Label l_customer;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.Label l_device;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.Label l_bib_No;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400013C RID: 316
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400013F RID: 319
		private global::System.Windows.Forms.Button btn_search;

		// Token: 0x04000140 RID: 320
		private global::System.Windows.Forms.TextBox tb_biboardno;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.PictureBox pb_PM_Info;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.TextBox tb_PM_Info;
	}
}
