namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000028 RID: 40
	public partial class SocketPartChange : global::System.Windows.Forms.Form
	{
		// Token: 0x06000110 RID: 272 RVA: 0x000165C9 File Offset: 0x000147C9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000165E8 File Offset: 0x000147E8
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.grid_SocketNo = new global::SourceGrid.Grid();
			this.l_subject = new global::System.Windows.Forms.Label();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.combo_PartChange_Category = new global::System.Windows.Forms.ComboBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.lbl_CntOfChange = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.lbl_SocketNo = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.btn_search = new global::System.Windows.Forms.Button();
			this.tb_biboardno = new global::System.Windows.Forms.TextBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.l_barcode = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.l_customer = new global::System.Windows.Forms.Label();
			this.l_device = new global::System.Windows.Forms.Label();
			this.l_bib_No = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.dtPicker_DateTo = new global::System.Windows.Forms.DateTimePicker();
			this.dtPicker_DateFrom = new global::System.Windows.Forms.DateTimePicker();
			this.btn_threeMonth = new global::System.Windows.Forms.Button();
			this.btn_aMonth = new global::System.Windows.Forms.Button();
			this.btn_aWeek = new global::System.Windows.Forms.Button();
			this.grid_PartChangeHistory = new global::SourceGrid.Grid();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.pb_ExportExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.pb_ExportExcel_All = new global::System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_ExportExcel).BeginInit();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_ExportExcel_All).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.grid_SocketNo);
			this.groupBox1.Location = new global::System.Drawing.Point(16, 194);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(313, 152);
			this.groupBox1.TabIndex = 23;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Socket Site No.";
			this.grid_SocketNo.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_SocketNo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_SocketNo.EnableSort = true;
			this.grid_SocketNo.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_SocketNo.Location = new global::System.Drawing.Point(3, 19);
			this.grid_SocketNo.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_SocketNo.Name = "grid_SocketNo";
			this.grid_SocketNo.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_SocketNo.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_SocketNo.Size = new global::System.Drawing.Size(307, 130);
			this.grid_SocketNo.TabIndex = 18;
			this.grid_SocketNo.TabStop = true;
			this.grid_SocketNo.ToolTipText = "";
			this.grid_SocketNo.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_SocketNo_MouseClick);
			this.grid_SocketNo.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_SocketNo_MouseDoubleClick);
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 8);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(158, 21);
			this.l_subject.TabIndex = 24;
			this.l_subject.Text = "Socket Part Change";
			this.groupBox3.Controls.Add(this.combo_PartChange_Category);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.lbl_CntOfChange);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.lbl_SocketNo);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Location = new global::System.Drawing.Point(16, 352);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(313, 126);
			this.groupBox3.TabIndex = 25;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Part Info";
			this.combo_PartChange_Category.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_PartChange_Category.FormattingEnabled = true;
			this.combo_PartChange_Category.Location = new global::System.Drawing.Point(111, 91);
			this.combo_PartChange_Category.Name = "combo_PartChange_Category";
			this.combo_PartChange_Category.Size = new global::System.Drawing.Size(170, 23);
			this.combo_PartChange_Category.TabIndex = 33;
			this.combo_PartChange_Category.SelectionChangeCommitted += new global::System.EventHandler(this.combo_PartChange_Category_SelectionChangeCommitted);
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(23, 94);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(64, 15);
			this.label9.TabIndex = 9;
			this.label9.Text = "Category : ";
			this.lbl_CntOfChange.AutoSize = true;
			this.lbl_CntOfChange.Location = new global::System.Drawing.Point(158, 59);
			this.lbl_CntOfChange.Name = "lbl_CntOfChange";
			this.lbl_CntOfChange.Size = new global::System.Drawing.Size(13, 15);
			this.lbl_CntOfChange.TabIndex = 8;
			this.lbl_CntOfChange.Text = "4";
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(23, 59);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(107, 15);
			this.label12.TabIndex = 7;
			this.label12.Text = "Count of Change : ";
			this.lbl_SocketNo.AutoSize = true;
			this.lbl_SocketNo.Location = new global::System.Drawing.Point(108, 26);
			this.lbl_SocketNo.Name = "lbl_SocketNo";
			this.lbl_SocketNo.Size = new global::System.Drawing.Size(19, 15);
			this.lbl_SocketNo.TabIndex = 6;
			this.lbl_SocketNo.Text = "23";
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(23, 26);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(67, 15);
			this.label11.TabIndex = 5;
			this.label11.Text = "Socket No :";
			this.groupBox2.Controls.Add(this.btn_search);
			this.groupBox2.Controls.Add(this.tb_biboardno);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox2.Location = new global::System.Drawing.Point(16, 39);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Size = new global::System.Drawing.Size(272, 71);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "BI Board No.";
			this.btn_search.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_search.Location = new global::System.Drawing.Point(178, 25);
			this.btn_search.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new global::System.Drawing.Size(75, 29);
			this.btn_search.TabIndex = 14;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = true;
			this.btn_search.Click += new global::System.EventHandler(this.btn_search_Click);
			this.tb_biboardno.Location = new global::System.Drawing.Point(22, 29);
			this.tb_biboardno.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_biboardno.Name = "tb_biboardno";
			this.tb_biboardno.Size = new global::System.Drawing.Size(143, 23);
			this.tb_biboardno.TabIndex = 12;
			this.tb_biboardno.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tb_biboardno_KeyDown);
			this.groupBox4.Controls.Add(this.l_barcode);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.l_customer);
			this.groupBox4.Controls.Add(this.l_device);
			this.groupBox4.Controls.Add(this.l_bib_No);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox4.Location = new global::System.Drawing.Point(16, 119);
			this.groupBox4.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Size = new global::System.Drawing.Size(882, 68);
			this.groupBox4.TabIndex = 30;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "BI Board Information";
			this.l_barcode.AutoSize = true;
			this.l_barcode.Location = new global::System.Drawing.Point(723, 30);
			this.l_barcode.Name = "l_barcode";
			this.l_barcode.Size = new global::System.Drawing.Size(79, 15);
			this.l_barcode.TabIndex = 10;
			this.l_barcode.Text = "ABBURN IN-7";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(661, 30);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 15);
			this.label7.TabIndex = 9;
			this.label7.Text = "Barcode :";
			this.l_customer.AutoSize = true;
			this.l_customer.Location = new global::System.Drawing.Point(259, 30);
			this.l_customer.Name = "l_customer";
			this.l_customer.Size = new global::System.Drawing.Size(77, 15);
			this.l_customer.TabIndex = 6;
			this.l_customer.Text = "QUALCOMM";
			this.l_device.AutoSize = true;
			this.l_device.Location = new global::System.Drawing.Point(475, 30);
			this.l_device.Name = "l_device";
			this.l_device.Size = new global::System.Drawing.Size(85, 15);
			this.l_device.TabIndex = 5;
			this.l_device.Text = "RADAGAST AU";
			this.l_bib_No.AutoSize = true;
			this.l_bib_No.Location = new global::System.Drawing.Point(73, 30);
			this.l_bib_No.Name = "l_bib_No";
			this.l_bib_No.Size = new global::System.Drawing.Size(38, 15);
			this.l_bib_No.TabIndex = 4;
			this.l_bib_No.Text = "#1029";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(185, 30);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(68, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Customer : ";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(418, 30);
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
			this.groupBox5.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.dtPicker_DateTo);
			this.groupBox5.Controls.Add(this.dtPicker_DateFrom);
			this.groupBox5.Controls.Add(this.btn_threeMonth);
			this.groupBox5.Controls.Add(this.btn_aMonth);
			this.groupBox5.Controls.Add(this.btn_aWeek);
			this.groupBox5.Controls.Add(this.grid_PartChangeHistory);
			this.groupBox5.Location = new global::System.Drawing.Point(335, 194);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(907, 402);
			this.groupBox5.TabIndex = 31;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Part Change History";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(353, 31);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(15, 15);
			this.label2.TabIndex = 26;
			this.label2.Text = "~";
			this.dtPicker_DateTo.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_DateTo.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtPicker_DateTo.Location = new global::System.Drawing.Point(374, 27);
			this.dtPicker_DateTo.Name = "dtPicker_DateTo";
			this.dtPicker_DateTo.Size = new global::System.Drawing.Size(98, 23);
			this.dtPicker_DateTo.TabIndex = 25;
			this.dtPicker_DateTo.ValueChanged += new global::System.EventHandler(this.dtPicker_DateTo_ValueChanged);
			this.dtPicker_DateFrom.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_DateFrom.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtPicker_DateFrom.Location = new global::System.Drawing.Point(249, 27);
			this.dtPicker_DateFrom.Name = "dtPicker_DateFrom";
			this.dtPicker_DateFrom.Size = new global::System.Drawing.Size(98, 23);
			this.dtPicker_DateFrom.TabIndex = 24;
			this.dtPicker_DateFrom.ValueChanged += new global::System.EventHandler(this.dtPicker_DateFrom_ValueChanged);
			this.btn_threeMonth.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_threeMonth.Location = new global::System.Drawing.Point(168, 24);
			this.btn_threeMonth.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_threeMonth.Name = "btn_threeMonth";
			this.btn_threeMonth.Size = new global::System.Drawing.Size(75, 29);
			this.btn_threeMonth.TabIndex = 23;
			this.btn_threeMonth.Text = "3 Month";
			this.btn_threeMonth.UseVisualStyleBackColor = true;
			this.btn_threeMonth.Click += new global::System.EventHandler(this.btn_threeMonth_Click);
			this.btn_aMonth.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_aMonth.Location = new global::System.Drawing.Point(87, 24);
			this.btn_aMonth.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_aMonth.Name = "btn_aMonth";
			this.btn_aMonth.Size = new global::System.Drawing.Size(75, 29);
			this.btn_aMonth.TabIndex = 22;
			this.btn_aMonth.Text = "1 Month";
			this.btn_aMonth.UseVisualStyleBackColor = true;
			this.btn_aMonth.Click += new global::System.EventHandler(this.btn_aMonth_Click);
			this.btn_aWeek.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_aWeek.Location = new global::System.Drawing.Point(6, 24);
			this.btn_aWeek.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_aWeek.Name = "btn_aWeek";
			this.btn_aWeek.Size = new global::System.Drawing.Size(75, 29);
			this.btn_aWeek.TabIndex = 21;
			this.btn_aWeek.Text = "1 Week";
			this.btn_aWeek.UseVisualStyleBackColor = true;
			this.btn_aWeek.Click += new global::System.EventHandler(this.btn_aWeek_Click);
			this.grid_PartChangeHistory.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.grid_PartChangeHistory.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_PartChangeHistory.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.grid_PartChangeHistory.EnableSort = true;
			this.grid_PartChangeHistory.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_PartChangeHistory.Location = new global::System.Drawing.Point(3, 58);
			this.grid_PartChangeHistory.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_PartChangeHistory.Name = "grid_PartChangeHistory";
			this.grid_PartChangeHistory.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_PartChangeHistory.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_PartChangeHistory.Size = new global::System.Drawing.Size(901, 341);
			this.grid_PartChangeHistory.TabIndex = 20;
			this.grid_PartChangeHistory.TabStop = true;
			this.grid_PartChangeHistory.ToolTipText = "";
			this.groupBox6.Controls.Add(this.pb_ExportExcel);
			this.groupBox6.Location = new global::System.Drawing.Point(294, 39);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(70, 71);
			this.groupBox6.TabIndex = 33;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Export";
			this.pb_ExportExcel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_ExportExcel.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.SaveExcel;
			this.pb_ExportExcel.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.SaveExcel;
			this.pb_ExportExcel.Location = new global::System.Drawing.Point(19, 23);
			this.pb_ExportExcel.Name = "pb_ExportExcel";
			this.pb_ExportExcel.Size = new global::System.Drawing.Size(32, 33);
			this.pb_ExportExcel.TabIndex = 0;
			this.pb_ExportExcel.TabStop = false;
			this.pb_ExportExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_ExportExcel_MouseDown);
			this.pb_ExportExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_ExportExcel_MouseUp);
			this.groupBox7.Controls.Add(this.pb_ExportExcel_All);
			this.groupBox7.Location = new global::System.Drawing.Point(370, 39);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(70, 71);
			this.groupBox7.TabIndex = 34;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Export A";
			this.pb_ExportExcel_All.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_ExportExcel_All.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.SaveExcel;
			this.pb_ExportExcel_All.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.SaveExcel;
			this.pb_ExportExcel_All.Location = new global::System.Drawing.Point(19, 23);
			this.pb_ExportExcel_All.Name = "pb_ExportExcel_All";
			this.pb_ExportExcel_All.Size = new global::System.Drawing.Size(32, 33);
			this.pb_ExportExcel_All.TabIndex = 0;
			this.pb_ExportExcel_All.TabStop = false;
			this.pb_ExportExcel_All.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_ExportExcel_All_MouseDown);
			this.pb_ExportExcel_All.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_ExportExcel_All_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1251, 605);
			base.Controls.Add(this.groupBox7);
			base.Controls.Add(this.groupBox6);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.l_subject);
			base.Controls.Add(this.groupBox1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "SocketPartChange";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SocketPartChange";
			base.Load += new global::System.EventHandler(this.SocketPartChange_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.SocketPartChange_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_ExportExcel).EndInit();
			this.groupBox7.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_ExportExcel_All).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001BB RID: 443
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040001BD RID: 445
		private global::SourceGrid.Grid grid_SocketNo;

		// Token: 0x040001BE RID: 446
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x040001BF RID: 447
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040001C0 RID: 448
		private global::System.Windows.Forms.ComboBox combo_PartChange_Category;

		// Token: 0x040001C1 RID: 449
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040001C2 RID: 450
		private global::System.Windows.Forms.Label lbl_CntOfChange;

		// Token: 0x040001C3 RID: 451
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040001C4 RID: 452
		private global::System.Windows.Forms.Label lbl_SocketNo;

		// Token: 0x040001C5 RID: 453
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040001C6 RID: 454
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.Button btn_search;

		// Token: 0x040001C8 RID: 456
		private global::System.Windows.Forms.TextBox tb_biboardno;

		// Token: 0x040001C9 RID: 457
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x040001CA RID: 458
		private global::System.Windows.Forms.Label l_barcode;

		// Token: 0x040001CB RID: 459
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.Label l_customer;

		// Token: 0x040001CD RID: 461
		private global::System.Windows.Forms.Label l_device;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.Label l_bib_No;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x040001D3 RID: 467
		private global::SourceGrid.Grid grid_PartChangeHistory;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.Button btn_threeMonth;

		// Token: 0x040001D5 RID: 469
		private global::System.Windows.Forms.Button btn_aMonth;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.Button btn_aWeek;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.DateTimePicker dtPicker_DateTo;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.DateTimePicker dtPicker_DateFrom;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.PictureBox pb_ExportExcel;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.PictureBox pb_ExportExcel_All;
	}
}
