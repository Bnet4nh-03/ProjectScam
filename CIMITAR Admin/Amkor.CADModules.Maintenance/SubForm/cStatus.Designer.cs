namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000E RID: 14
	public partial class cStatus : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x00028534 File Offset: 0x00026734
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0002856C File Offset: 0x0002676C
		private void InitializeComponent()
		{
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.btnSearch = new global::System.Windows.Forms.PictureBox();
			this.groupBox_Export = new global::System.Windows.Forms.GroupBox();
			this.btnExcel = new global::System.Windows.Forms.PictureBox();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.pbLayout = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.combo_Category = new global::System.Windows.Forms.ComboBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.combo_SearchStatus = new global::System.Windows.Forms.ComboBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.panel17 = new global::System.Windows.Forms.Panel();
			this.combo_Index = new global::System.Windows.Forms.ComboBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.dtEndDate = new global::System.Windows.Forms.DateTimePicker();
			this.label2 = new global::System.Windows.Forms.Label();
			this.dtStartDate = new global::System.Windows.Forms.DateTimePicker();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.combo_Plant = new global::System.Windows.Forms.ComboBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.tbGridType = new global::System.Windows.Forms.TabControl();
			this.tpMaintStatus = new global::System.Windows.Forms.TabPage();
			this.tpPMStatus = new global::System.Windows.Forms.TabPage();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).BeginInit();
			this.groupBox_Export.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnExcel).BeginInit();
			this.panel1.SuspendLayout();
			this.panel15.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbLayout).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel17.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel11.SuspendLayout();
			this.tbGridType.SuspendLayout();
			base.SuspendLayout();
			this.groupBox4.Controls.Add(this.btnSearch);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox4.Font = new global::System.Drawing.Font("굴림체", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.groupBox4.Location = new global::System.Drawing.Point(865, 1);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(84, 62);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Search";
			this.btnSearch.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnSearch.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.TableSearch;
			this.btnSearch.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.search;
			this.btnSearch.Location = new global::System.Drawing.Point(24, 23);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new global::System.Drawing.Size(35, 30);
			this.btnSearch.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.btnSearch.TabIndex = 10;
			this.btnSearch.TabStop = false;
			this.btnSearch.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.btnSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.btnSearch_MouseDown);
			this.btnSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.btnSearch_MouseUp);
			this.groupBox_Export.Controls.Add(this.btnExcel);
			this.groupBox_Export.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox_Export.Font = new global::System.Drawing.Font("굴림체", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.groupBox_Export.Location = new global::System.Drawing.Point(949, 1);
			this.groupBox_Export.Name = "groupBox_Export";
			this.groupBox_Export.Size = new global::System.Drawing.Size(84, 62);
			this.groupBox_Export.TabIndex = 11;
			this.groupBox_Export.TabStop = false;
			this.groupBox_Export.Text = "Excel";
			this.groupBox_Export.Visible = false;
			this.btnExcel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnExcel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.SaveExcel;
			this.btnExcel.Location = new global::System.Drawing.Point(26, 23);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new global::System.Drawing.Size(35, 30);
			this.btnExcel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.btnExcel.TabIndex = 10;
			this.btnExcel.TabStop = false;
			this.btnExcel.Click += new global::System.EventHandler(this.btnExcel_Click);
			this.btnExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.btnExcel_MouseDown);
			this.btnExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.btnExcel_MouseUp);
			this.panel1.Controls.Add(this.panel15);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1410, 66);
			this.panel1.TabIndex = 17;
			this.panel15.Controls.Add(this.groupBox3);
			this.panel15.Controls.Add(this.groupBox_Export);
			this.panel15.Controls.Add(this.groupBox4);
			this.panel15.Controls.Add(this.groupBox1);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel15.Location = new global::System.Drawing.Point(0, 0);
			this.panel15.Margin = new global::System.Windows.Forms.Padding(3, 1, 1, 1);
			this.panel15.Name = "panel15";
			this.panel15.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel15.Size = new global::System.Drawing.Size(1410, 66);
			this.panel15.TabIndex = 12;
			this.groupBox3.Controls.Add(this.pbLayout);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox3.Font = new global::System.Drawing.Font("굴림체", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.groupBox3.Location = new global::System.Drawing.Point(1033, 1);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(84, 62);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Layout";
			this.groupBox3.Visible = false;
			this.pbLayout.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbLayout.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.SaveDB;
			this.pbLayout.Location = new global::System.Drawing.Point(25, 23);
			this.pbLayout.Name = "pbLayout";
			this.pbLayout.Size = new global::System.Drawing.Size(35, 30);
			this.pbLayout.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbLayout.TabIndex = 11;
			this.pbLayout.TabStop = false;
			this.pbLayout.Click += new global::System.EventHandler(this.pbLayout_Click);
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Controls.Add(this.panel7);
			this.groupBox1.Controls.Add(this.panel17);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.panel11);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox1.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 3);
			this.groupBox1.Size = new global::System.Drawing.Size(862, 62);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.panel9.Controls.Add(this.combo_Category);
			this.panel9.Controls.Add(this.label10);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel9.Location = new global::System.Drawing.Point(679, 15);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel9.Size = new global::System.Drawing.Size(162, 44);
			this.panel9.TabIndex = 14;
			this.combo_Category.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.combo_Category.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Category.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.combo_Category.FormattingEnabled = true;
			this.combo_Category.Location = new global::System.Drawing.Point(0, 17);
			this.combo_Category.Name = "combo_Category";
			this.combo_Category.Size = new global::System.Drawing.Size(159, 25);
			this.combo_Category.TabIndex = 0;
			this.label10.AutoSize = true;
			this.label10.BackColor = global::System.Drawing.Color.White;
			this.label10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label10.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(0, 0);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(61, 17);
			this.label10.TabIndex = 10;
			this.label10.Text = "Category";
			this.panel7.Controls.Add(this.combo_SearchStatus);
			this.panel7.Controls.Add(this.label9);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel7.Location = new global::System.Drawing.Point(546, 15);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel7.Size = new global::System.Drawing.Size(133, 44);
			this.panel7.TabIndex = 13;
			this.combo_SearchStatus.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.combo_SearchStatus.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_SearchStatus.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.combo_SearchStatus.FormattingEnabled = true;
			this.combo_SearchStatus.Items.AddRange(new object[]
			{
				"All",
				"Request",
				"Closed",
				"Hold"
			});
			this.combo_SearchStatus.Location = new global::System.Drawing.Point(0, 17);
			this.combo_SearchStatus.Name = "combo_SearchStatus";
			this.combo_SearchStatus.Size = new global::System.Drawing.Size(130, 25);
			this.combo_SearchStatus.TabIndex = 0;
			this.label9.AutoSize = true;
			this.label9.BackColor = global::System.Drawing.Color.White;
			this.label9.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label9.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label9.ForeColor = global::System.Drawing.Color.Black;
			this.label9.Location = new global::System.Drawing.Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(43, 17);
			this.label9.TabIndex = 9;
			this.label9.Text = "Status";
			this.panel17.Controls.Add(this.combo_Index);
			this.panel17.Controls.Add(this.label14);
			this.panel17.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel17.Location = new global::System.Drawing.Point(413, 15);
			this.panel17.Name = "panel17";
			this.panel17.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel17.Size = new global::System.Drawing.Size(133, 44);
			this.panel17.TabIndex = 16;
			this.combo_Index.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.combo_Index.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Index.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.combo_Index.FormattingEnabled = true;
			this.combo_Index.Items.AddRange(new object[]
			{
				"Maint'",
				"PM"
			});
			this.combo_Index.Location = new global::System.Drawing.Point(0, 17);
			this.combo_Index.Name = "combo_Index";
			this.combo_Index.Size = new global::System.Drawing.Size(130, 25);
			this.combo_Index.TabIndex = 0;
			this.combo_Index.SelectedIndexChanged += new global::System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.label14.AutoSize = true;
			this.label14.BackColor = global::System.Drawing.Color.White;
			this.label14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label14.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label14.ForeColor = global::System.Drawing.Color.Black;
			this.label14.Location = new global::System.Drawing.Point(0, 0);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(36, 17);
			this.label14.TabIndex = 9;
			this.label14.Text = "Type";
			this.panel2.Controls.Add(this.dtEndDate);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.dtStartDate);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new global::System.Drawing.Point(76, 15);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(3, 0, 3, 0);
			this.panel2.Size = new global::System.Drawing.Size(337, 44);
			this.panel2.TabIndex = 11;
			this.dtEndDate.CustomFormat = "yyyy-MM-dd";
			this.dtEndDate.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.dtEndDate.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.dtEndDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtEndDate.Location = new global::System.Drawing.Point(169, 17);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new global::System.Drawing.Size(152, 25);
			this.dtEndDate.TabIndex = 8;
			this.dtEndDate.TabStop = false;
			this.label2.AutoSize = true;
			this.label2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(152, 17);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(17, 17);
			this.label2.TabIndex = 53;
			this.label2.Text = "~";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.dtStartDate.CustomFormat = "yyyy-MM-dd";
			this.dtStartDate.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.dtStartDate.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.dtStartDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtStartDate.Location = new global::System.Drawing.Point(3, 17);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new global::System.Drawing.Size(149, 25);
			this.dtStartDate.TabIndex = 7;
			this.dtStartDate.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(84, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "Select Period";
			this.panel11.Controls.Add(this.combo_Plant);
			this.panel11.Controls.Add(this.label12);
			this.panel11.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel11.Location = new global::System.Drawing.Point(3, 15);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel11.Size = new global::System.Drawing.Size(73, 44);
			this.panel11.TabIndex = 15;
			this.combo_Plant.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.combo_Plant.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Plant.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.combo_Plant.FormattingEnabled = true;
			this.combo_Plant.Items.AddRange(new object[]
			{
				"All",
				"Request",
				"Closed",
				"Hold"
			});
			this.combo_Plant.Location = new global::System.Drawing.Point(0, 17);
			this.combo_Plant.Name = "combo_Plant";
			this.combo_Plant.Size = new global::System.Drawing.Size(70, 25);
			this.combo_Plant.TabIndex = 0;
			this.combo_Plant.SelectedValueChanged += new global::System.EventHandler(this.combo_Plant_SelectedValueChanged);
			this.label12.AutoSize = true;
			this.label12.BackColor = global::System.Drawing.Color.White;
			this.label12.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label12.ForeColor = global::System.Drawing.Color.Black;
			this.label12.Location = new global::System.Drawing.Point(0, 0);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(50, 17);
			this.label12.TabIndex = 9;
			this.label12.Text = "Factory";
			this.tbGridType.Controls.Add(this.tpMaintStatus);
			this.tbGridType.Controls.Add(this.tpPMStatus);
			this.tbGridType.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbGridType.Location = new global::System.Drawing.Point(0, 66);
			this.tbGridType.Name = "tbGridType";
			this.tbGridType.SelectedIndex = 0;
			this.tbGridType.Size = new global::System.Drawing.Size(1410, 514);
			this.tbGridType.TabIndex = 20;
			this.tpMaintStatus.Location = new global::System.Drawing.Point(4, 22);
			this.tpMaintStatus.Name = "tpMaintStatus";
			this.tpMaintStatus.Size = new global::System.Drawing.Size(1402, 488);
			this.tpMaintStatus.TabIndex = 0;
			this.tpMaintStatus.Text = "Maint' Status";
			this.tpMaintStatus.UseVisualStyleBackColor = true;
			this.tpPMStatus.Location = new global::System.Drawing.Point(4, 22);
			this.tpPMStatus.Name = "tpPMStatus";
			this.tpPMStatus.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpPMStatus.Size = new global::System.Drawing.Size(1402, 488);
			this.tpPMStatus.TabIndex = 2;
			this.tpPMStatus.Text = "PM Status";
			this.tpPMStatus.UseVisualStyleBackColor = true;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1410, 580);
			base.Controls.Add(this.tbGridType);
			base.Controls.Add(this.panel1);
			this.ForeColor = global::System.Drawing.SystemColors.ControlLight;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "cStatus";
			this.Text = "cStatus";
			base.Shown += new global::System.EventHandler(this.cStatus_Shown);
			this.groupBox4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).EndInit();
			this.groupBox_Export.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnExcel).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbLayout).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel17.ResumeLayout(false);
			this.panel17.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			this.tbGridType.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000207 RID: 519
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000208 RID: 520
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000209 RID: 521
		private global::System.Windows.Forms.PictureBox btnSearch;

		// Token: 0x0400020A RID: 522
		private global::System.Windows.Forms.GroupBox groupBox_Export;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.PictureBox btnExcel;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400020D RID: 525
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400020E RID: 526
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.ComboBox combo_Category;

		// Token: 0x04000212 RID: 530
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000213 RID: 531
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.ComboBox combo_SearchStatus;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000216 RID: 534
		private global::System.Windows.Forms.DateTimePicker dtEndDate;

		// Token: 0x04000217 RID: 535
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000218 RID: 536
		private global::System.Windows.Forms.DateTimePicker dtStartDate;

		// Token: 0x04000219 RID: 537
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400021A RID: 538
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x0400021B RID: 539
		private global::System.Windows.Forms.ComboBox combo_Plant;

		// Token: 0x0400021C RID: 540
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400021D RID: 541
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400021E RID: 542
		private global::System.Windows.Forms.TabControl tbGridType;

		// Token: 0x0400021F RID: 543
		private global::System.Windows.Forms.TabPage tpMaintStatus;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.TabPage tpPMStatus;

		// Token: 0x04000221 RID: 545
		private global::System.Windows.Forms.Panel panel17;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.ComboBox combo_Index;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000224 RID: 548
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.PictureBox pbLayout;
	}
}
