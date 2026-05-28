namespace Amkor.CADModules.UnitDataModule
{
	// Token: 0x02000026 RID: 38
	public partial class UnitDataAnalysis : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x00009108 File Offset: 0x00007308
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00009128 File Offset: 0x00007328
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.UnitDataModule.UnitDataAnalysis));
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label12 = new global::System.Windows.Forms.Label();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.splitter8 = new global::System.Windows.Forms.Splitter();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.chkBarcode_Out = new global::System.Windows.Forms.TabControl();
			this.tab_YieldReport = new global::System.Windows.Forms.TabPage();
			this.panelView = new global::System.Windows.Forms.Panel();
			this.tab_ReportView = new global::System.Windows.Forms.TabControl();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.groupBox10 = new global::System.Windows.Forms.GroupBox();
			this.chkCmbReportType = new global::Amkor.CADModules.UnitDataModule.Control.CheckedComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cmd_Yield_Search = new global::System.Windows.Forms.PictureBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.cmd_Yield_Excel = new global::System.Windows.Forms.PictureBox();
			this.splitter2 = new global::System.Windows.Forms.Splitter();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.groupBox20 = new global::System.Windows.Forms.GroupBox();
			this.gridLotList = new global::SourceGrid.Grid();
			this.panel12 = new global::System.Windows.Forms.Panel();
			this.label45 = new global::System.Windows.Forms.Label();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.btnLotSearch = new global::System.Windows.Forms.Button();
			this.groupBox14 = new global::System.Windows.Forms.GroupBox();
			this.rdoLot = new global::System.Windows.Forms.RadioButton();
			this.rdoDate = new global::System.Windows.Forms.RadioButton();
			this.label38 = new global::System.Windows.Forms.Label();
			this.date_End = new global::System.Windows.Forms.DateTimePicker();
			this.rdoSN = new global::System.Windows.Forms.RadioButton();
			this.date_Start = new global::System.Windows.Forms.DateTimePicker();
			this.txtSearchLotid = new global::System.Windows.Forms.TextBox();
			this.txtSearchSN = new global::System.Windows.Forms.TextBox();
			this.groupBox19 = new global::System.Windows.Forms.GroupBox();
			this.groupBox18 = new global::System.Windows.Forms.GroupBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.panel3.SuspendLayout();
			this.panel15.SuspendLayout();
			this.chkBarcode_Out.SuspendLayout();
			this.tab_YieldReport.SuspendLayout();
			this.panelView.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Yield_Search).BeginInit();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Yield_Excel).BeginInit();
			this.panel10.SuspendLayout();
			this.panel11.SuspendLayout();
			this.groupBox20.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox14.SuspendLayout();
			base.SuspendLayout();
			this.panel3.Controls.Add(this.label12);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1184, 30);
			this.panel3.TabIndex = 15;
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold);
			this.label12.Location = new global::System.Drawing.Point(12, 5);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(142, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "UnitData Module";
			this.panel15.Controls.Add(this.label13);
			this.panel15.Controls.Add(this.splitter8);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel15.Location = new global::System.Drawing.Point(0, 729);
			this.panel15.Name = "panel15";
			this.panel15.Size = new global::System.Drawing.Size(1184, 32);
			this.panel15.TabIndex = 21;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(424, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(369, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.splitter8.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter8.Location = new global::System.Drawing.Point(0, 0);
			this.splitter8.Name = "splitter8";
			this.splitter8.Size = new global::System.Drawing.Size(1184, 3);
			this.splitter8.TabIndex = 14;
			this.splitter8.TabStop = false;
			this.chkBarcode_Out.Controls.Add(this.tab_YieldReport);
			this.chkBarcode_Out.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.chkBarcode_Out.Location = new global::System.Drawing.Point(0, 30);
			this.chkBarcode_Out.Name = "chkBarcode_Out";
			this.chkBarcode_Out.SelectedIndex = 0;
			this.chkBarcode_Out.Size = new global::System.Drawing.Size(1184, 699);
			this.chkBarcode_Out.TabIndex = 22;
			this.tab_YieldReport.Controls.Add(this.panelView);
			this.tab_YieldReport.Controls.Add(this.panel6);
			this.tab_YieldReport.Controls.Add(this.splitter2);
			this.tab_YieldReport.Controls.Add(this.panel10);
			this.tab_YieldReport.Location = new global::System.Drawing.Point(4, 24);
			this.tab_YieldReport.Name = "tab_YieldReport";
			this.tab_YieldReport.Size = new global::System.Drawing.Size(1176, 671);
			this.tab_YieldReport.TabIndex = 4;
			this.tab_YieldReport.Text = "YieldReport";
			this.tab_YieldReport.UseVisualStyleBackColor = true;
			this.panelView.Controls.Add(this.tab_ReportView);
			this.panelView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelView.Location = new global::System.Drawing.Point(301, 77);
			this.panelView.Name = "panelView";
			this.panelView.Size = new global::System.Drawing.Size(875, 594);
			this.panelView.TabIndex = 18;
			this.tab_ReportView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tab_ReportView.Location = new global::System.Drawing.Point(0, 0);
			this.tab_ReportView.Name = "tab_ReportView";
			this.tab_ReportView.SelectedIndex = 0;
			this.tab_ReportView.Size = new global::System.Drawing.Size(875, 594);
			this.tab_ReportView.TabIndex = 1;
			this.panel6.Controls.Add(this.groupBox10);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new global::System.Drawing.Point(301, 0);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 0);
			this.panel6.Size = new global::System.Drawing.Size(875, 77);
			this.panel6.TabIndex = 17;
			this.groupBox10.Controls.Add(this.chkCmbReportType);
			this.groupBox10.Controls.Add(this.label1);
			this.groupBox10.Controls.Add(this.groupBox1);
			this.groupBox10.Controls.Add(this.groupBox2);
			this.groupBox10.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox10.Location = new global::System.Drawing.Point(0, 3);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new global::System.Drawing.Size(875, 74);
			this.groupBox10.TabIndex = 4;
			this.groupBox10.TabStop = false;
			this.chkCmbReportType.CheckOnClick = true;
			this.chkCmbReportType.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkCmbReportType.DropDownHeight = 1;
			this.chkCmbReportType.FormattingEnabled = true;
			this.chkCmbReportType.IntegralHeight = false;
			this.chkCmbReportType.Location = new global::System.Drawing.Point(91, 29);
			this.chkCmbReportType.Name = "chkCmbReportType";
			this.chkCmbReportType.Size = new global::System.Drawing.Size(219, 24);
			this.chkCmbReportType.TabIndex = 117;
			this.chkCmbReportType.ValueSeparator = ", ";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label1.Location = new global::System.Drawing.Point(18, 32);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(67, 15);
			this.label1.TabIndex = 116;
			this.label1.Text = "ReportType";
			this.groupBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox1.Controls.Add(this.cmd_Yield_Search);
			this.groupBox1.Location = new global::System.Drawing.Point(326, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox1.TabIndex = 104;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.cmd_Yield_Search.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_Yield_Search.Image");
			this.cmd_Yield_Search.Location = new global::System.Drawing.Point(14, 19);
			this.cmd_Yield_Search.Name = "cmd_Yield_Search";
			this.cmd_Yield_Search.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_Yield_Search.TabIndex = 102;
			this.cmd_Yield_Search.TabStop = false;
			this.cmd_Yield_Search.Click += new global::System.EventHandler(this.cmd_Yield_Search_Click);
			this.groupBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox2.Controls.Add(this.cmd_Yield_Excel);
			this.groupBox2.Location = new global::System.Drawing.Point(394, 7);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox2.TabIndex = 105;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Excel";
			this.cmd_Yield_Excel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_Yield_Excel.Image");
			this.cmd_Yield_Excel.Location = new global::System.Drawing.Point(12, 19);
			this.cmd_Yield_Excel.Name = "cmd_Yield_Excel";
			this.cmd_Yield_Excel.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_Yield_Excel.TabIndex = 103;
			this.cmd_Yield_Excel.TabStop = false;
			this.cmd_Yield_Excel.Click += new global::System.EventHandler(this.cmd_Yield_Excel_Click);
			this.splitter2.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter2.Location = new global::System.Drawing.Point(296, 0);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new global::System.Drawing.Size(5, 671);
			this.splitter2.TabIndex = 16;
			this.splitter2.TabStop = false;
			this.panel10.Controls.Add(this.panel11);
			this.panel10.Controls.Add(this.panel8);
			this.panel10.Controls.Add(this.groupBox14);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel10.Location = new global::System.Drawing.Point(0, 0);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new global::System.Windows.Forms.Padding(2);
			this.panel10.Size = new global::System.Drawing.Size(296, 671);
			this.panel10.TabIndex = 14;
			this.panel11.Controls.Add(this.groupBox20);
			this.panel11.Controls.Add(this.panel12);
			this.panel11.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel11.Location = new global::System.Drawing.Point(2, 139);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new global::System.Windows.Forms.Padding(0, 5, 0, 0);
			this.panel11.Size = new global::System.Drawing.Size(292, 530);
			this.panel11.TabIndex = 119;
			this.groupBox20.Controls.Add(this.gridLotList);
			this.groupBox20.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox20.Font = new global::System.Drawing.Font("Segoe UI", 1.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox20.Location = new global::System.Drawing.Point(0, 33);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new global::System.Drawing.Size(292, 497);
			this.groupBox20.TabIndex = 116;
			this.groupBox20.TabStop = false;
			this.gridLotList.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.gridLotList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridLotList.EnableSort = true;
			this.gridLotList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridLotList.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridLotList.Location = new global::System.Drawing.Point(3, 6);
			this.gridLotList.Name = "gridLotList";
			this.gridLotList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridLotList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridLotList.Size = new global::System.Drawing.Size(286, 488);
			this.gridLotList.TabIndex = 116;
			this.gridLotList.TabStop = true;
			this.gridLotList.ToolTipText = "";
			this.panel12.BackColor = global::System.Drawing.Color.SkyBlue;
			this.panel12.Controls.Add(this.label45);
			this.panel12.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel12.Location = new global::System.Drawing.Point(0, 5);
			this.panel12.Name = "panel12";
			this.panel12.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel12.Size = new global::System.Drawing.Size(292, 28);
			this.panel12.TabIndex = 116;
			this.label45.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label45.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label45.Location = new global::System.Drawing.Point(3, 3);
			this.label45.Name = "label45";
			this.label45.Size = new global::System.Drawing.Size(286, 22);
			this.label45.TabIndex = 0;
			this.label45.Text = "Lot List";
			this.label45.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel8.Controls.Add(this.btnLotSearch);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new global::System.Drawing.Point(2, 115);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(292, 24);
			this.panel8.TabIndex = 118;
			this.btnLotSearch.BackColor = global::System.Drawing.Color.White;
			this.btnLotSearch.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnLotSearch.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnLotSearch.ForeColor = global::System.Drawing.Color.Black;
			this.btnLotSearch.Location = new global::System.Drawing.Point(0, 0);
			this.btnLotSearch.Name = "btnLotSearch";
			this.btnLotSearch.Size = new global::System.Drawing.Size(292, 24);
			this.btnLotSearch.TabIndex = 5;
			this.btnLotSearch.Text = "Search && Load";
			this.btnLotSearch.UseVisualStyleBackColor = false;
			this.btnLotSearch.Click += new global::System.EventHandler(this.btnLotSearch_Click);
			this.groupBox14.Controls.Add(this.rdoLot);
			this.groupBox14.Controls.Add(this.rdoDate);
			this.groupBox14.Controls.Add(this.label38);
			this.groupBox14.Controls.Add(this.date_End);
			this.groupBox14.Controls.Add(this.rdoSN);
			this.groupBox14.Controls.Add(this.date_Start);
			this.groupBox14.Controls.Add(this.txtSearchLotid);
			this.groupBox14.Controls.Add(this.txtSearchSN);
			this.groupBox14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox14.Location = new global::System.Drawing.Point(2, 2);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Padding = new global::System.Windows.Forms.Padding(3, 6, 3, 3);
			this.groupBox14.Size = new global::System.Drawing.Size(292, 113);
			this.groupBox14.TabIndex = 1;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Search";
			this.rdoLot.AutoSize = true;
			this.rdoLot.Location = new global::System.Drawing.Point(6, 53);
			this.rdoLot.Name = "rdoLot";
			this.rdoLot.Size = new global::System.Drawing.Size(42, 19);
			this.rdoLot.TabIndex = 123;
			this.rdoLot.Text = "Lot";
			this.rdoLot.UseVisualStyleBackColor = true;
			this.rdoDate.AutoSize = true;
			this.rdoDate.Checked = true;
			this.rdoDate.Location = new global::System.Drawing.Point(6, 25);
			this.rdoDate.Name = "rdoDate";
			this.rdoDate.Size = new global::System.Drawing.Size(49, 19);
			this.rdoDate.TabIndex = 122;
			this.rdoDate.TabStop = true;
			this.rdoDate.Text = "Date";
			this.rdoDate.UseVisualStyleBackColor = true;
			this.label38.AutoSize = true;
			this.label38.Location = new global::System.Drawing.Point(156, 27);
			this.label38.Name = "label38";
			this.label38.Size = new global::System.Drawing.Size(15, 15);
			this.label38.TabIndex = 92;
			this.label38.Text = "~";
			this.date_End.CustomFormat = "yyyy-MM-dd";
			this.date_End.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.date_End.Location = new global::System.Drawing.Point(174, 23);
			this.date_End.Name = "date_End";
			this.date_End.Size = new global::System.Drawing.Size(95, 23);
			this.date_End.TabIndex = 84;
			this.rdoSN.AutoSize = true;
			this.rdoSN.Location = new global::System.Drawing.Point(6, 82);
			this.rdoSN.Name = "rdoSN";
			this.rdoSN.Size = new global::System.Drawing.Size(40, 19);
			this.rdoSN.TabIndex = 124;
			this.rdoSN.Text = "SN";
			this.rdoSN.UseVisualStyleBackColor = true;
			this.date_Start.CustomFormat = "yyyy-MM-dd";
			this.date_Start.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.date_Start.Location = new global::System.Drawing.Point(58, 23);
			this.date_Start.Name = "date_Start";
			this.date_Start.Size = new global::System.Drawing.Size(95, 23);
			this.date_Start.TabIndex = 85;
			this.txtSearchLotid.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtSearchLotid.Location = new global::System.Drawing.Point(58, 52);
			this.txtSearchLotid.Name = "txtSearchLotid";
			this.txtSearchLotid.Size = new global::System.Drawing.Size(211, 23);
			this.txtSearchLotid.TabIndex = 100;
			this.txtSearchSN.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtSearchSN.Location = new global::System.Drawing.Point(58, 81);
			this.txtSearchSN.Name = "txtSearchSN";
			this.txtSearchSN.Size = new global::System.Drawing.Size(211, 23);
			this.txtSearchSN.TabIndex = 120;
			this.groupBox19.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox19.Location = new global::System.Drawing.Point(308, 10);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox19.TabIndex = 4;
			this.groupBox19.TabStop = false;
			this.groupBox19.Text = "Search";
			this.groupBox18.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox18.Location = new global::System.Drawing.Point(376, 10);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox18.TabIndex = 103;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Excel";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label8.Location = new global::System.Drawing.Point(15, 32);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(67, 15);
			this.label8.TabIndex = 115;
			this.label8.Text = "ReportType";
			this.openFileDialog.FileName = "openFileDialog";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1184, 761);
			base.Controls.Add(this.chkBarcode_Out);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel15);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Name = "UnitDataAnalysis";
			this.Text = "UnitData";
			base.Load += new global::System.EventHandler(this.SAMSUNG_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			this.chkBarcode_Out.ResumeLayout(false);
			this.tab_YieldReport.ResumeLayout(false);
			this.panelView.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Yield_Search).EndInit();
			this.groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Yield_Excel).EndInit();
			this.panel10.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.groupBox20.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000DD RID: 221
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.Splitter splitter8;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.TabControl chkBarcode_Out;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.TabPage tab_YieldReport;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.GroupBox groupBox14;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.Label label38;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.DateTimePicker date_End;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.DateTimePicker date_Start;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.GroupBox groupBox18;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.GroupBox groupBox19;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.TextBox txtSearchLotid;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.GroupBox groupBox20;

		// Token: 0x040000EF RID: 239
		private global::SourceGrid.Grid gridLotList;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.Splitter splitter2;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.Button btnLotSearch;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.GroupBox groupBox10;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.Panel panelView;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.TextBox txtSearchSN;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.Panel panel12;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.Label label45;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.RadioButton rdoSN;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.RadioButton rdoLot;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.RadioButton rdoDate;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.TabControl tab_ReportView;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.PictureBox cmd_Yield_Search;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000104 RID: 260
		private global::System.Windows.Forms.PictureBox cmd_Yield_Excel;

		// Token: 0x04000105 RID: 261
		private global::Amkor.CADModules.UnitDataModule.Control.CheckedComboBox chkCmbReportType;
	}
}
