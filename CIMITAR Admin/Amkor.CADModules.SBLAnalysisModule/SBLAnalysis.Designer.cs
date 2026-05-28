namespace Amkor.CADModules.SBLAnalysisModule
{
	// Token: 0x02000013 RID: 19
	public partial class SBLAnalysis : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000089 RID: 137 RVA: 0x0000761C File Offset: 0x0000581C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00007654 File Offset: 0x00005854
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.SBLAnalysisModule.SBLAnalysis));
			global::System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new global::System.Windows.Forms.DataVisualization.Charting.ChartArea();
			global::System.Windows.Forms.DataVisualization.Charting.Legend legend = new global::System.Windows.Forms.DataVisualization.Charting.Legend();
			global::System.Windows.Forms.DataVisualization.Charting.Title title = new global::System.Windows.Forms.DataVisualization.Charting.Title();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label_copyright = new global::System.Windows.Forms.Label();
			this.splitter10 = new global::System.Windows.Forms.Splitter();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label12 = new global::System.Windows.Forms.Label();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.backgroundWorker1 = new global::System.ComponentModel.BackgroundWorker();
			this.tabSBL = new global::System.Windows.Forms.TabControl();
			this.tpSBLHistory = new global::System.Windows.Forms.TabPage();
			this.panel16 = new global::System.Windows.Forms.Panel();
			this.panel17 = new global::System.Windows.Forms.Panel();
			this.groupBox18 = new global::System.Windows.Forms.GroupBox();
			this.gridSBLHistory = new global::SourceGrid.Grid();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.groupBox19 = new global::System.Windows.Forms.GroupBox();
			this.cmbPlatformType = new global::System.Windows.Forms.ComboBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.cmbType = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cmbTester = new global::System.Windows.Forms.ComboBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.label19 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtLotid = new global::System.Windows.Forms.TextBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.dtp_End_Histroy = new global::System.Windows.Forms.DateTimePicker();
			this.dtp_Start_History = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox21 = new global::System.Windows.Forms.GroupBox();
			this.cmdHistoryExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox22 = new global::System.Windows.Forms.GroupBox();
			this.cmdHistorySearch = new global::System.Windows.Forms.PictureBox();
			this.tpFailBinTrend = new global::System.Windows.Forms.TabPage();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.chart_FailBin = new global::System.Windows.Forms.DataVisualization.Charting.Chart();
			this.splitter1 = new global::System.Windows.Forms.Splitter();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.gridBinTrend = new global::SourceGrid.Grid();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.cmbTrendTester = new global::System.Windows.Forms.ComboBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.dtp_End_Trend = new global::System.Windows.Forms.DateTimePicker();
			this.dtp_Start_Trend = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.cmdBinTrendExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.cmdBinTrendSearch = new global::System.Windows.Forms.PictureBox();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.gridSetupList = new global::SourceGrid.Grid();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.cbHSFlag = new global::System.Windows.Forms.ComboBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.cbHSFSetup = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cbPlatform = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.pbSetupExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.pbSetupSearch = new global::System.Windows.Forms.PictureBox();
			this.colorDialog1 = new global::System.Windows.Forms.ColorDialog();
			this.panel25.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tabSBL.SuspendLayout();
			this.tpSBLHistory.SuspendLayout();
			this.panel16.SuspendLayout();
			this.panel17.SuspendLayout();
			this.groupBox18.SuspendLayout();
			this.panel18.SuspendLayout();
			this.groupBox19.SuspendLayout();
			this.groupBox21.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdHistoryExcel).BeginInit();
			this.groupBox22.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdHistorySearch).BeginInit();
			this.tpFailBinTrend.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel10.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.chart_FailBin).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdBinTrendExcel).BeginInit();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdBinTrendSearch).BeginInit();
			this.tabPage1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbSetupExcel).BeginInit();
			this.groupBox8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbSetupSearch).BeginInit();
			base.SuspendLayout();
			this.panel25.Controls.Add(this.label_copyright);
			this.panel25.Controls.Add(this.splitter10);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 759);
			this.panel25.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(1184, 40);
			this.panel25.TabIndex = 23;
			this.label_copyright.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label_copyright.AutoSize = true;
			this.label_copyright.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label_copyright.Location = new global::System.Drawing.Point(381, 11);
			this.label_copyright.Name = "label_copyright";
			this.label_copyright.Size = new global::System.Drawing.Size(397, 15);
			this.label_copyright.TabIndex = 15;
			this.label_copyright.Text = "Copyright © 2017-2017 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.label_copyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.splitter10.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter10.Location = new global::System.Drawing.Point(0, 0);
			this.splitter10.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.splitter10.Name = "splitter10";
			this.splitter10.Size = new global::System.Drawing.Size(1184, 1);
			this.splitter10.TabIndex = 14;
			this.splitter10.TabStop = false;
			this.panel4.Controls.Add(this.label12);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1184, 34);
			this.panel4.TabIndex = 24;
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold);
			this.label12.Location = new global::System.Drawing.Point(12, 6);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(37, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "SBL";
			this.tabSBL.Controls.Add(this.tpSBLHistory);
			this.tabSBL.Controls.Add(this.tpFailBinTrend);
			this.tabSBL.Controls.Add(this.tabPage1);
			this.tabSBL.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabSBL.Location = new global::System.Drawing.Point(0, 34);
			this.tabSBL.Name = "tabSBL";
			this.tabSBL.SelectedIndex = 0;
			this.tabSBL.Size = new global::System.Drawing.Size(1184, 725);
			this.tabSBL.TabIndex = 25;
			this.tpSBLHistory.Controls.Add(this.panel16);
			this.tpSBLHistory.Location = new global::System.Drawing.Point(4, 24);
			this.tpSBLHistory.Name = "tpSBLHistory";
			this.tpSBLHistory.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpSBLHistory.Size = new global::System.Drawing.Size(1176, 697);
			this.tpSBLHistory.TabIndex = 86;
			this.tpSBLHistory.Text = "SBL History";
			this.tpSBLHistory.UseVisualStyleBackColor = true;
			this.panel16.Controls.Add(this.panel17);
			this.panel16.Controls.Add(this.panel18);
			this.panel16.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel16.Location = new global::System.Drawing.Point(3, 3);
			this.panel16.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel16.Name = "panel16";
			this.panel16.Size = new global::System.Drawing.Size(1170, 691);
			this.panel16.TabIndex = 19;
			this.panel17.Controls.Add(this.groupBox18);
			this.panel17.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel17.Location = new global::System.Drawing.Point(0, 77);
			this.panel17.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel17.Name = "panel17";
			this.panel17.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel17.Size = new global::System.Drawing.Size(1170, 614);
			this.panel17.TabIndex = 2;
			this.groupBox18.Controls.Add(this.gridSBLHistory);
			this.groupBox18.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox18.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox18.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox18.Size = new global::System.Drawing.Size(1164, 610);
			this.groupBox18.TabIndex = 5;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "SBL History List";
			this.gridSBLHistory.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridSBLHistory.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridSBLHistory.EnableSort = true;
			this.gridSBLHistory.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridSBLHistory.Location = new global::System.Drawing.Point(3, 20);
			this.gridSBLHistory.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridSBLHistory.Name = "gridSBLHistory";
			this.gridSBLHistory.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridSBLHistory.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridSBLHistory.Size = new global::System.Drawing.Size(1158, 586);
			this.gridSBLHistory.TabIndex = 13;
			this.gridSBLHistory.TabStop = true;
			this.gridSBLHistory.ToolTipText = "";
			this.gridSBLHistory.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.gridSBLHistory_MouseDoubleClick);
			this.panel18.Controls.Add(this.groupBox19);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel18.Location = new global::System.Drawing.Point(0, 0);
			this.panel18.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel18.Name = "panel18";
			this.panel18.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel18.Size = new global::System.Drawing.Size(1170, 77);
			this.panel18.TabIndex = 60;
			this.groupBox19.Controls.Add(this.cmbPlatformType);
			this.groupBox19.Controls.Add(this.label3);
			this.groupBox19.Controls.Add(this.cmbType);
			this.groupBox19.Controls.Add(this.label2);
			this.groupBox19.Controls.Add(this.cmbTester);
			this.groupBox19.Controls.Add(this.label17);
			this.groupBox19.Controls.Add(this.label19);
			this.groupBox19.Controls.Add(this.label1);
			this.groupBox19.Controls.Add(this.txtLotid);
			this.groupBox19.Controls.Add(this.label13);
			this.groupBox19.Controls.Add(this.dtp_End_Histroy);
			this.groupBox19.Controls.Add(this.dtp_Start_History);
			this.groupBox19.Controls.Add(this.groupBox21);
			this.groupBox19.Controls.Add(this.groupBox22);
			this.groupBox19.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox19.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox19.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox19.Size = new global::System.Drawing.Size(1164, 71);
			this.groupBox19.TabIndex = 6;
			this.groupBox19.TabStop = false;
			this.cmbPlatformType.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbPlatformType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlatformType.FormattingEnabled = true;
			this.cmbPlatformType.Location = new global::System.Drawing.Point(383, 17);
			this.cmbPlatformType.Name = "cmbPlatformType";
			this.cmbPlatformType.Size = new global::System.Drawing.Size(98, 23);
			this.cmbPlatformType.TabIndex = 97;
			this.cmbPlatformType.DropDown += new global::System.EventHandler(this.cmbPlatformType_DropDown);
			this.cmbPlatformType.SelectedIndexChanged += new global::System.EventHandler(this.cmbPlatformType_SelectedIndexChanged);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(299, 21);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(77, 15);
			this.label3.TabIndex = 96;
			this.label3.Text = "PlatformType";
			this.cmbType.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Location = new global::System.Drawing.Point(54, 44);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new global::System.Drawing.Size(104, 23);
			this.cmbType.TabIndex = 95;
			this.cmbType.DropDown += new global::System.EventHandler(this.cmbType_DropDown);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(10, 48);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(31, 15);
			this.label2.TabIndex = 94;
			this.label2.Text = "Type";
			this.cmbTester.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbTester.FormattingEnabled = true;
			this.cmbTester.Location = new global::System.Drawing.Point(546, 17);
			this.cmbTester.Name = "cmbTester";
			this.cmbTester.Size = new global::System.Drawing.Size(122, 23);
			this.cmbTester.TabIndex = 48;
			this.cmbTester.DropDown += new global::System.EventHandler(this.cmbTester_DropDown);
			this.label17.AutoSize = true;
			this.label17.Location = new global::System.Drawing.Point(502, 21);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(37, 15);
			this.label17.TabIndex = 47;
			this.label17.Text = "Tester";
			this.label19.AutoSize = true;
			this.label19.Location = new global::System.Drawing.Point(178, 48);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(24, 15);
			this.label19.TabIndex = 3;
			this.label19.Text = "Lot";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(6, 20);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(41, 15);
			this.label1.TabIndex = 93;
			this.label1.Text = "Period";
			this.txtLotid.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtLotid.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtLotid.Location = new global::System.Drawing.Point(208, 44);
			this.txtLotid.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtLotid.Name = "txtLotid";
			this.txtLotid.Size = new global::System.Drawing.Size(273, 23);
			this.txtLotid.TabIndex = 0;
			this.txtLotid.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtLotid_KeyPress);
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(160, 20);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(15, 15);
			this.label13.TabIndex = 92;
			this.label13.Text = "~";
			this.dtp_End_Histroy.CustomFormat = "yyyy-MM-dd";
			this.dtp_End_Histroy.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_End_Histroy.Location = new global::System.Drawing.Point(181, 16);
			this.dtp_End_Histroy.Name = "dtp_End_Histroy";
			this.dtp_End_Histroy.Size = new global::System.Drawing.Size(100, 23);
			this.dtp_End_Histroy.TabIndex = 84;
			this.dtp_Start_History.CustomFormat = "yyyy-MM-dd";
			this.dtp_Start_History.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_Start_History.Location = new global::System.Drawing.Point(54, 16);
			this.dtp_Start_History.Name = "dtp_Start_History";
			this.dtp_Start_History.Size = new global::System.Drawing.Size(100, 23);
			this.dtp_Start_History.TabIndex = 85;
			this.groupBox21.Controls.Add(this.cmdHistoryExcel);
			this.groupBox21.Location = new global::System.Drawing.Point(918, 10);
			this.groupBox21.Name = "groupBox21";
			this.groupBox21.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox21.TabIndex = 17;
			this.groupBox21.TabStop = false;
			this.groupBox21.Text = "Excel";
			this.cmdHistoryExcel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.cmdHistoryExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdHistoryExcel.Image");
			this.cmdHistoryExcel.Location = new global::System.Drawing.Point(9, 18);
			this.cmdHistoryExcel.Name = "cmdHistoryExcel";
			this.cmdHistoryExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdHistoryExcel.TabIndex = 80;
			this.cmdHistoryExcel.TabStop = false;
			this.cmdHistoryExcel.Click += new global::System.EventHandler(this.cmdHistoryExcel_Click);
			this.groupBox22.Controls.Add(this.cmdHistorySearch);
			this.groupBox22.Location = new global::System.Drawing.Point(854, 10);
			this.groupBox22.Name = "groupBox22";
			this.groupBox22.Size = new global::System.Drawing.Size(58, 58);
			this.groupBox22.TabIndex = 16;
			this.groupBox22.TabStop = false;
			this.groupBox22.Text = "Search";
			this.cmdHistorySearch.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.cmdHistorySearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdHistorySearch.Image");
			this.cmdHistorySearch.Location = new global::System.Drawing.Point(12, 18);
			this.cmdHistorySearch.Name = "cmdHistorySearch";
			this.cmdHistorySearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdHistorySearch.TabIndex = 1;
			this.cmdHistorySearch.TabStop = false;
			this.cmdHistorySearch.Click += new global::System.EventHandler(this.cmdHistorySearch_Click);
			this.tpFailBinTrend.Controls.Add(this.panel1);
			this.tpFailBinTrend.Location = new global::System.Drawing.Point(4, 24);
			this.tpFailBinTrend.Name = "tpFailBinTrend";
			this.tpFailBinTrend.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpFailBinTrend.Size = new global::System.Drawing.Size(1176, 697);
			this.tpFailBinTrend.TabIndex = 87;
			this.tpFailBinTrend.Text = "FailBin Trend";
			this.tpFailBinTrend.UseVisualStyleBackColor = true;
			this.panel1.Controls.Add(this.panel10);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(3, 3);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1170, 691);
			this.panel1.TabIndex = 20;
			this.panel10.Controls.Add(this.chart_FailBin);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel10.Location = new global::System.Drawing.Point(0, 62);
			this.panel10.Name = "panel10";
			this.panel10.Size = new global::System.Drawing.Size(1170, 444);
			this.panel10.TabIndex = 150;
			this.chart_FailBin.BackGradientStyle = global::System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart_FailBin.BackSecondaryColor = global::System.Drawing.Color.White;
			this.chart_FailBin.BorderlineColor = global::System.Drawing.Color.Silver;
			this.chart_FailBin.BorderlineDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea.Area3DStyle.Inclination = 5;
			chartArea.Area3DStyle.IsClustered = true;
			chartArea.Area3DStyle.Rotation = 0;
			chartArea.Area3DStyle.WallWidth = 0;
			chartArea.AxisX.LineColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea.AxisX.Maximum = 100.0;
			chartArea.AxisY.IsLabelAutoFit = false;
			chartArea.AxisY.LabelStyle.Font = new global::System.Drawing.Font("Arial", 8f);
			chartArea.AxisY.LineColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea.AxisY.Maximum = 100.0;
			chartArea.AxisY.MaximumAutoSize = 100f;
			chartArea.AxisY.Minimum = 0.0;
			chartArea.BackColor = global::System.Drawing.Color.White;
			chartArea.BackSecondaryColor = global::System.Drawing.Color.White;
			chartArea.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea.BorderDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea.Name = "ChartArea1";
			chartArea.ShadowColor = global::System.Drawing.Color.Transparent;
			this.chart_FailBin.ChartAreas.Add(chartArea);
			this.chart_FailBin.Dock = global::System.Windows.Forms.DockStyle.Fill;
			legend.Alignment = global::System.Drawing.StringAlignment.Center;
			legend.BackColor = global::System.Drawing.Color.Transparent;
			legend.BorderColor = global::System.Drawing.Color.Transparent;
			legend.Docking = global::System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			legend.IsTextAutoFit = false;
			legend.Name = "Legend1";
			this.chart_FailBin.Legends.Add(legend);
			this.chart_FailBin.Location = new global::System.Drawing.Point(0, 0);
			this.chart_FailBin.Name = "chart_FailBin";
			this.chart_FailBin.Size = new global::System.Drawing.Size(1170, 444);
			this.chart_FailBin.TabIndex = 147;
			this.chart_FailBin.Text = "chart_Tester";
			title.BackColor = global::System.Drawing.Color.Transparent;
			title.BackImageAlignment = global::System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
			title.BackImageWrapMode = global::System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
			title.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			title.Name = "Title1";
			title.ShadowColor = global::System.Drawing.Color.Silver;
			title.Text = "FailBin Trend";
			this.chart_FailBin.Titles.Add(title);
			this.chart_FailBin.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.chart_FailBin_MouseClick);
			this.splitter1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new global::System.Drawing.Point(0, 506);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new global::System.Drawing.Size(1170, 4);
			this.splitter1.TabIndex = 151;
			this.splitter1.TabStop = false;
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 510);
			this.panel2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel2.Size = new global::System.Drawing.Size(1170, 181);
			this.panel2.TabIndex = 2;
			this.groupBox1.Controls.Add(this.gridBinTrend);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Size = new global::System.Drawing.Size(1164, 177);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Fail Bin History List";
			this.gridBinTrend.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridBinTrend.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridBinTrend.EnableSort = true;
			this.gridBinTrend.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridBinTrend.Location = new global::System.Drawing.Point(3, 20);
			this.gridBinTrend.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridBinTrend.Name = "gridBinTrend";
			this.gridBinTrend.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridBinTrend.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridBinTrend.Size = new global::System.Drawing.Size(1158, 153);
			this.gridBinTrend.TabIndex = 13;
			this.gridBinTrend.TabStop = true;
			this.gridBinTrend.ToolTipText = "";
			this.panel3.Controls.Add(this.groupBox2);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel3.Size = new global::System.Drawing.Size(1170, 62);
			this.panel3.TabIndex = 60;
			this.groupBox2.Controls.Add(this.cmbTrendTester);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.dtp_End_Trend);
			this.groupBox2.Controls.Add(this.dtp_Start_Trend);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 1.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox2.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Size = new global::System.Drawing.Size(1164, 56);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.cmbTrendTester.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbTrendTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbTrendTester.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cmbTrendTester.FormattingEnabled = true;
			this.cmbTrendTester.Location = new global::System.Drawing.Point(401, 17);
			this.cmbTrendTester.Name = "cmbTrendTester";
			this.cmbTrendTester.Size = new global::System.Drawing.Size(122, 23);
			this.cmbTrendTester.TabIndex = 48;
			this.cmbTrendTester.DropDown += new global::System.EventHandler(this.cmbTrendTester_DropDown);
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(357, 21);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(37, 15);
			this.label6.TabIndex = 47;
			this.label6.Text = "Tester";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new global::System.Drawing.Point(9, 21);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(41, 15);
			this.label8.TabIndex = 93;
			this.label8.Text = "Period";
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.Location = new global::System.Drawing.Point(190, 21);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(15, 15);
			this.label9.TabIndex = 92;
			this.label9.Text = "~";
			this.dtp_End_Trend.CustomFormat = "yyyy-MM-dd HH:mm";
			this.dtp_End_Trend.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dtp_End_Trend.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_End_Trend.Location = new global::System.Drawing.Point(212, 17);
			this.dtp_End_Trend.Name = "dtp_End_Trend";
			this.dtp_End_Trend.Size = new global::System.Drawing.Size(125, 23);
			this.dtp_End_Trend.TabIndex = 84;
			this.dtp_Start_Trend.CustomFormat = "yyyy-MM-dd HH:mm";
			this.dtp_Start_Trend.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dtp_Start_Trend.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_Start_Trend.Location = new global::System.Drawing.Point(57, 17);
			this.dtp_Start_Trend.Name = "dtp_Start_Trend";
			this.dtp_Start_Trend.Size = new global::System.Drawing.Size(125, 23);
			this.dtp_Start_Trend.TabIndex = 85;
			this.groupBox3.Controls.Add(this.cmdBinTrendExcel);
			this.groupBox3.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.groupBox3.Location = new global::System.Drawing.Point(606, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(48, 50);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Excel";
			this.cmdBinTrendExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdBinTrendExcel.Image");
			this.cmdBinTrendExcel.Location = new global::System.Drawing.Point(8, 14);
			this.cmdBinTrendExcel.Name = "cmdBinTrendExcel";
			this.cmdBinTrendExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdBinTrendExcel.TabIndex = 80;
			this.cmdBinTrendExcel.TabStop = false;
			this.cmdBinTrendExcel.Click += new global::System.EventHandler(this.cmbBinTrendExcel_Click);
			this.groupBox4.Controls.Add(this.cmdBinTrendSearch);
			this.groupBox4.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.groupBox4.Location = new global::System.Drawing.Point(542, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(55, 50);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Search";
			this.cmdBinTrendSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdBinTrendSearch.Image");
			this.cmdBinTrendSearch.Location = new global::System.Drawing.Point(11, 14);
			this.cmdBinTrendSearch.Name = "cmdBinTrendSearch";
			this.cmdBinTrendSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdBinTrendSearch.TabIndex = 1;
			this.cmdBinTrendSearch.TabStop = false;
			this.cmdBinTrendSearch.Click += new global::System.EventHandler(this.cmbBinTrendSearch_Click);
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Controls.Add(this.panel5);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(1176, 697);
			this.tabPage1.TabIndex = 88;
			this.tabPage1.Text = "HSF Setup List";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.groupBox5.Controls.Add(this.gridSetupList);
			this.groupBox5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox5.Location = new global::System.Drawing.Point(3, 80);
			this.groupBox5.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox5.Size = new global::System.Drawing.Size(1170, 614);
			this.groupBox5.TabIndex = 61;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "SBL Setup List";
			this.gridSetupList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridSetupList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridSetupList.EnableSort = true;
			this.gridSetupList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridSetupList.Location = new global::System.Drawing.Point(3, 20);
			this.gridSetupList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridSetupList.Name = "gridSetupList";
			this.gridSetupList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridSetupList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridSetupList.Size = new global::System.Drawing.Size(1164, 590);
			this.gridSetupList.TabIndex = 13;
			this.gridSetupList.TabStop = true;
			this.gridSetupList.ToolTipText = "";
			this.panel5.Controls.Add(this.groupBox6);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(3, 3);
			this.panel5.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel5.Size = new global::System.Drawing.Size(1170, 77);
			this.panel5.TabIndex = 62;
			this.groupBox6.Controls.Add(this.cbHSFlag);
			this.groupBox6.Controls.Add(this.label7);
			this.groupBox6.Controls.Add(this.cbHSFSetup);
			this.groupBox6.Controls.Add(this.label5);
			this.groupBox6.Controls.Add(this.cbPlatform);
			this.groupBox6.Controls.Add(this.label4);
			this.groupBox6.Controls.Add(this.groupBox7);
			this.groupBox6.Controls.Add(this.groupBox8);
			this.groupBox6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox6.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox6.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox6.Size = new global::System.Drawing.Size(1164, 71);
			this.groupBox6.TabIndex = 6;
			this.groupBox6.TabStop = false;
			this.cbHSFlag.BackColor = global::System.Drawing.Color.LightGray;
			this.cbHSFlag.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cbHSFlag.FormattingEnabled = true;
			this.cbHSFlag.Items.AddRange(new object[]
			{
				"All",
				"True",
				"False"
			});
			this.cbHSFlag.Location = new global::System.Drawing.Point(76, 43);
			this.cbHSFlag.Name = "cbHSFlag";
			this.cbHSFlag.Size = new global::System.Drawing.Size(98, 23);
			this.cbHSFlag.TabIndex = 101;
			this.cbHSFlag.Text = "All";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(6, 47);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(53, 15);
			this.label7.TabIndex = 100;
			this.label7.Text = "HSF Flag";
			this.cbHSFSetup.BackColor = global::System.Drawing.Color.LightGray;
			this.cbHSFSetup.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cbHSFSetup.FormattingEnabled = true;
			this.cbHSFSetup.Items.AddRange(new object[]
			{
				"All",
				"True",
				"False"
			});
			this.cbHSFSetup.Location = new global::System.Drawing.Point(76, 16);
			this.cbHSFSetup.Name = "cbHSFSetup";
			this.cbHSFSetup.Size = new global::System.Drawing.Size(98, 23);
			this.cbHSFSetup.TabIndex = 99;
			this.cbHSFSetup.Text = "All";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(6, 20);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(61, 15);
			this.label5.TabIndex = 98;
			this.label5.Text = "HSF Setup";
			this.cbPlatform.BackColor = global::System.Drawing.Color.LightGray;
			this.cbPlatform.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cbPlatform.FormattingEnabled = true;
			this.cbPlatform.Location = new global::System.Drawing.Point(705, 24);
			this.cbPlatform.Name = "cbPlatform";
			this.cbPlatform.Size = new global::System.Drawing.Size(98, 23);
			this.cbPlatform.TabIndex = 97;
			this.cbPlatform.Visible = false;
			this.cbPlatform.DropDown += new global::System.EventHandler(this.cmbPlatformType_DropDown);
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(621, 28);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(77, 15);
			this.label4.TabIndex = 96;
			this.label4.Text = "PlatformType";
			this.label4.Visible = false;
			this.groupBox7.Controls.Add(this.pbSetupExcel);
			this.groupBox7.Location = new global::System.Drawing.Point(243, 10);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox7.TabIndex = 17;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Excel";
			this.pbSetupExcel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbSetupExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbSetupExcel.Image");
			this.pbSetupExcel.Location = new global::System.Drawing.Point(9, 18);
			this.pbSetupExcel.Name = "pbSetupExcel";
			this.pbSetupExcel.Size = new global::System.Drawing.Size(32, 32);
			this.pbSetupExcel.TabIndex = 80;
			this.pbSetupExcel.TabStop = false;
			this.pbSetupExcel.Click += new global::System.EventHandler(this.pbSetupExcel_Click);
			this.groupBox8.Controls.Add(this.pbSetupSearch);
			this.groupBox8.Location = new global::System.Drawing.Point(179, 10);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(58, 58);
			this.groupBox8.TabIndex = 16;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Search";
			this.pbSetupSearch.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbSetupSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbSetupSearch.Image");
			this.pbSetupSearch.Location = new global::System.Drawing.Point(12, 18);
			this.pbSetupSearch.Name = "pbSetupSearch";
			this.pbSetupSearch.Size = new global::System.Drawing.Size(32, 32);
			this.pbSetupSearch.TabIndex = 1;
			this.pbSetupSearch.TabStop = false;
			this.pbSetupSearch.Click += new global::System.EventHandler(this.pbSetupSearch_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1184, 799);
			base.Controls.Add(this.tabSBL);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel4);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "SBLAnalysis";
			this.Text = "SBL Analysis";
			base.Load += new global::System.EventHandler(this.SBLAnalysis_Load);
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.tabSBL.ResumeLayout(false);
			this.tpSBLHistory.ResumeLayout(false);
			this.panel16.ResumeLayout(false);
			this.panel17.ResumeLayout(false);
			this.groupBox18.ResumeLayout(false);
			this.panel18.ResumeLayout(false);
			this.groupBox19.ResumeLayout(false);
			this.groupBox19.PerformLayout();
			this.groupBox21.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdHistoryExcel).EndInit();
			this.groupBox22.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdHistorySearch).EndInit();
			this.tpFailBinTrend.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.chart_FailBin).EndInit();
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdBinTrendExcel).EndInit();
			this.groupBox4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdBinTrendSearch).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbSetupExcel).EndInit();
			this.groupBox8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbSetupSearch).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000057 RID: 87
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.Label label_copyright;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Splitter splitter10;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400005E RID: 94
		private global::System.ComponentModel.BackgroundWorker backgroundWorker1;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.TabControl tabSBL;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.TabPage tpSBLHistory;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.Panel panel16;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.Panel panel17;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.GroupBox groupBox18;

		// Token: 0x04000064 RID: 100
		private global::SourceGrid.Grid gridSBLHistory;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.GroupBox groupBox19;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.TextBox txtLotid;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.Label label19;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.GroupBox groupBox21;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.PictureBox cmdHistoryExcel;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.GroupBox groupBox22;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.PictureBox cmdHistorySearch;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.DateTimePicker dtp_End_Histroy;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.DateTimePicker dtp_Start_History;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.ComboBox cmbTester;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.ColorDialog colorDialog1;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.ComboBox cmbType;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.ComboBox cmbPlatformType;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.TabPage tpFailBinTrend;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.DataVisualization.Charting.Chart chart_FailBin;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400007D RID: 125
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400007E RID: 126
		private global::SourceGrid.Grid gridBinTrend;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.ComboBox cmbTrendTester;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.DateTimePicker dtp_End_Trend;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.DateTimePicker dtp_Start_Trend;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.PictureBox cmdBinTrendExcel;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.PictureBox cmdBinTrendSearch;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Splitter splitter1;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x0400008E RID: 142
		private global::SourceGrid.Grid gridSetupList;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.ComboBox cbPlatform;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.PictureBox pbSetupExcel;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.PictureBox pbSetupSearch;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.ComboBox cbHSFlag;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.ComboBox cbHSFSetup;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.Label label5;
	}
}
