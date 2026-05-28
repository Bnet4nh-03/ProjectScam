namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000F RID: 15
	public partial class TrendForm : global::ATDFW.Controls.BaseWinForm.BaseWinView, global::Amkor.CADModules.Maintenance.GrobalConst.Interface.IHCC
	{
		// Token: 0x0600013C RID: 316 RVA: 0x000388D4 File Offset: 0x00036AD4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0003890C File Offset: 0x00036B0C
		private void InitializeComponent()
		{
			global::System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new global::System.Windows.Forms.DataVisualization.Charting.ChartArea();
			global::System.Windows.Forms.DataVisualization.Charting.Legend legend = new global::System.Windows.Forms.DataVisualization.Charting.Legend();
			global::System.Windows.Forms.DataVisualization.Charting.Series series = new global::System.Windows.Forms.DataVisualization.Charting.Series();
			global::System.Windows.Forms.DataVisualization.Charting.DataPoint item = new global::System.Windows.Forms.DataVisualization.Charting.DataPoint(1000.0, 1.0);
			global::System.Windows.Forms.DataVisualization.Charting.DataPoint item2 = new global::System.Windows.Forms.DataVisualization.Charting.DataPoint(2000.0, 10.0);
			global::System.Windows.Forms.DataVisualization.Charting.DataPoint item3 = new global::System.Windows.Forms.DataVisualization.Charting.DataPoint(3000.0, 100.0);
			global::System.Windows.Forms.DataVisualization.Charting.DataPoint item4 = new global::System.Windows.Forms.DataVisualization.Charting.DataPoint(4000.0, 100.0);
			global::System.Windows.Forms.DataVisualization.Charting.DataPoint item5 = new global::System.Windows.Forms.DataVisualization.Charting.DataPoint(5000.0, 0.0);
			global::System.Windows.Forms.DataVisualization.Charting.DataPoint item6 = new global::System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0, 0.0);
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.panel20 = new global::System.Windows.Forms.Panel();
			this.panel21 = new global::System.Windows.Forms.Panel();
			this.pbSubIndex = new global::System.Windows.Forms.Panel();
			this.tvList = new global::System.Windows.Forms.TreeView();
			this.pnFactory = new global::System.Windows.Forms.Panel();
			this.rbK5M = new global::System.Windows.Forms.RadioButton();
			this.rbK3EV = new global::System.Windows.Forms.RadioButton();
			this.rbK5 = new global::System.Windows.Forms.RadioButton();
			this.rbK4 = new global::System.Windows.Forms.RadioButton();
			this.rbK3 = new global::System.Windows.Forms.RadioButton();
			this.pnMTBFType = new global::System.Windows.Forms.Panel();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.rbProductionHour = new global::System.Windows.Forms.RadioButton();
			this.rbDayHour = new global::System.Windows.Forms.RadioButton();
			this.panel19 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.pnIndexType = new global::System.Windows.Forms.Panel();
			this.panel17 = new global::System.Windows.Forms.Panel();
			this.rbStartTime = new global::System.Windows.Forms.RadioButton();
			this.rbRequestTime = new global::System.Windows.Forms.RadioButton();
			this.panel16 = new global::System.Windows.Forms.Panel();
			this.label11 = new global::System.Windows.Forms.Label();
			this.pnOEEType = new global::System.Windows.Forms.Panel();
			this.panel14 = new global::System.Windows.Forms.Panel();
			this.rbMTTR = new global::System.Windows.Forms.RadioButton();
			this.rbMTBF = new global::System.Windows.Forms.RadioButton();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.label10 = new global::System.Windows.Forms.Label();
			this.pnSubIndex2 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.gbHccLocation = new global::System.Windows.Forms.GroupBox();
			this.tbLocation = new global::System.Windows.Forms.TextBox();
			this.pnDate = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.dtEndDate = new global::System.Windows.Forms.DateTimePicker();
			this.dtStartDate = new global::System.Windows.Forms.DateTimePicker();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pnBaseSearch = new global::System.Windows.Forms.Panel();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.btnSearch = new global::System.Windows.Forms.PictureBox();
			this.gbExcel = new global::System.Windows.Forms.GroupBox();
			this.btnExcel = new global::System.Windows.Forms.PictureBox();
			this.tcMainPage = new global::System.Windows.Forms.TabControl();
			this.tpMaintTrend = new global::System.Windows.Forms.TabPage();
			this.pnTrendBase = new global::System.Windows.Forms.Panel();
			this.splitContainer2 = new global::System.Windows.Forms.SplitContainer();
			this.pnTimeBase = new global::System.Windows.Forms.Panel();
			this.grid_trend = new global::SourceGrid.Grid();
			this.splitter1 = new global::System.Windows.Forms.Splitter();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.btnGridClose = new global::System.Windows.Forms.Button();
			this.pnChartBase = new global::System.Windows.Forms.Panel();
			this.pnChartMode = new global::System.Windows.Forms.Panel();
			this.tbChartZoom = new global::System.Windows.Forms.TrackBar();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.rbEquipment = new global::System.Windows.Forms.RadioButton();
			this.rbModel = new global::System.Windows.Forms.RadioButton();
			this.rbCategory = new global::System.Windows.Forms.RadioButton();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.tpFactorTrend = new global::System.Windows.Forms.TabPage();
			this.splitContainer3 = new global::System.Windows.Forms.SplitContainer();
			this.pnDetailFactor = new global::System.Windows.Forms.Panel();
			this.pnFactorBase3 = new global::System.Windows.Forms.Panel();
			this.pnFactorBase2 = new global::System.Windows.Forms.Panel();
			this.pnFactorBase = new global::System.Windows.Forms.Panel();
			this.pnSubClose = new global::System.Windows.Forms.Panel();
			this.btnSubClose = new global::System.Windows.Forms.Button();
			this.pnCaseBase = new global::System.Windows.Forms.Panel();
			this.pnCaseChartMode = new global::System.Windows.Forms.Panel();
			this.tbFactorZoom = new global::System.Windows.Forms.TrackBar();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.label9 = new global::System.Windows.Forms.Label();
			this.rbCaseEquipment = new global::System.Windows.Forms.RadioButton();
			this.rbCaseModel = new global::System.Windows.Forms.RadioButton();
			this.rbCaseCategory = new global::System.Windows.Forms.RadioButton();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.label6 = new global::System.Windows.Forms.Label();
			this.tpOEETrand = new global::System.Windows.Forms.TabPage();
			this.pnOEEBase = new global::System.Windows.Forms.Panel();
			this.pnOEEMode = new global::System.Windows.Forms.Panel();
			this.pnZoom = new global::System.Windows.Forms.Panel();
			this.tbOEEChartZoom = new global::System.Windows.Forms.TrackBar();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.tpHandlerUtili = new global::System.Windows.Forms.TabPage();
			this.panel12 = new global::System.Windows.Forms.Panel();
			this.grid_utilization = new global::SourceGrid.Grid();
			this.tpTesterUtili = new global::System.Windows.Forms.TabPage();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.grid_utilization_tester = new global::SourceGrid.Grid();
			this.tabDeviceTrend = new global::System.Windows.Forms.TabPage();
			this.scDevice = new global::System.Windows.Forms.SplitContainer();
			this.pnDeviceTrendBase = new global::System.Windows.Forms.Panel();
			this.tbBoardTrend = new global::System.Windows.Forms.TabPage();
			this.splitContainer4 = new global::System.Windows.Forms.SplitContainer();
			this.pnDetailSite = new global::System.Windows.Forms.Panel();
			this.pnDetailSiteChart = new global::System.Windows.Forms.Panel();
			this.panel23 = new global::System.Windows.Forms.Panel();
			this.btnCloseSiteDetail = new global::System.Windows.Forms.Button();
			this.pnSiteCharts = new global::System.Windows.Forms.Panel();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.cbDeviceSite = new global::System.Windows.Forms.CheckBox();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.pnSiteRejectChart = new global::System.Windows.Forms.Panel();
			this.pnBoardRejectChart = new global::System.Windows.Forms.Panel();
			this.chart1 = new global::System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel20.SuspendLayout();
			this.panel21.SuspendLayout();
			this.pbSubIndex.SuspendLayout();
			this.pnFactory.SuspendLayout();
			this.pnMTBFType.SuspendLayout();
			this.panel18.SuspendLayout();
			this.panel19.SuspendLayout();
			this.pnIndexType.SuspendLayout();
			this.panel17.SuspendLayout();
			this.panel16.SuspendLayout();
			this.pnOEEType.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel13.SuspendLayout();
			this.pnSubIndex2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.gbHccLocation.SuspendLayout();
			this.pnDate.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			this.pnBaseSearch.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).BeginInit();
			this.gbExcel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnExcel).BeginInit();
			this.tcMainPage.SuspendLayout();
			this.tpMaintTrend.SuspendLayout();
			this.pnTrendBase.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer2).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.pnTimeBase.SuspendLayout();
			this.grid_trend.SuspendLayout();
			this.panel5.SuspendLayout();
			this.pnChartMode.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tbChartZoom).BeginInit();
			this.panel9.SuspendLayout();
			this.panel7.SuspendLayout();
			this.tpFactorTrend.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer3).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.pnDetailFactor.SuspendLayout();
			this.pnSubClose.SuspendLayout();
			this.pnCaseChartMode.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tbFactorZoom).BeginInit();
			this.panel11.SuspendLayout();
			this.panel8.SuspendLayout();
			this.tpOEETrand.SuspendLayout();
			this.pnOEEMode.SuspendLayout();
			this.pnZoom.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tbOEEChartZoom).BeginInit();
			this.panel10.SuspendLayout();
			this.tpHandlerUtili.SuspendLayout();
			this.panel12.SuspendLayout();
			this.tpTesterUtili.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tabDeviceTrend.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.scDevice).BeginInit();
			this.scDevice.Panel2.SuspendLayout();
			this.scDevice.SuspendLayout();
			this.tbBoardTrend.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer4).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			this.pnDetailSite.SuspendLayout();
			this.panel23.SuspendLayout();
			this.pnSiteCharts.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.pnBoardRejectChart.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.chart1).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.panel1.Size = new global::System.Drawing.Size(1424, 865);
			this.panel1.TabIndex = 1;
			this.splitContainer1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.Controls.Add(this.panel15);
			this.splitContainer1.Panel1.Controls.Add(this.pnBaseSearch);
			this.splitContainer1.Panel1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Panel1MinSize = 15;
			this.splitContainer1.Panel2.Controls.Add(this.tcMainPage);
			this.splitContainer1.Panel2.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Size = new global::System.Drawing.Size(1424, 865);
			this.splitContainer1.SplitterDistance = 270;
			this.splitContainer1.TabIndex = 1;
			this.panel15.Controls.Add(this.panel20);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel15.Location = new global::System.Drawing.Point(0, 0);
			this.panel15.Name = "panel15";
			this.panel15.Size = new global::System.Drawing.Size(268, 795);
			this.panel15.TabIndex = 0;
			this.panel20.Controls.Add(this.panel21);
			this.panel20.Controls.Add(this.pnDate);
			this.panel20.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel20.Location = new global::System.Drawing.Point(0, 0);
			this.panel20.Name = "panel20";
			this.panel20.Size = new global::System.Drawing.Size(268, 795);
			this.panel20.TabIndex = 0;
			this.panel21.AutoSize = true;
			this.panel21.Controls.Add(this.pbSubIndex);
			this.panel21.Controls.Add(this.pnSubIndex2);
			this.panel21.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel21.Location = new global::System.Drawing.Point(0, 87);
			this.panel21.Name = "panel21";
			this.panel21.Size = new global::System.Drawing.Size(268, 708);
			this.panel21.TabIndex = 49;
			this.pbSubIndex.Controls.Add(this.tvList);
			this.pbSubIndex.Controls.Add(this.pnFactory);
			this.pbSubIndex.Controls.Add(this.pnMTBFType);
			this.pbSubIndex.Controls.Add(this.pnIndexType);
			this.pbSubIndex.Controls.Add(this.pnOEEType);
			this.pbSubIndex.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pbSubIndex.Location = new global::System.Drawing.Point(0, 64);
			this.pbSubIndex.Name = "pbSubIndex";
			this.pbSubIndex.Size = new global::System.Drawing.Size(268, 644);
			this.pbSubIndex.TabIndex = 0;
			this.tvList.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.tvList.CheckBoxes = true;
			this.tvList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tvList.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tvList.Location = new global::System.Drawing.Point(0, 250);
			this.tvList.Name = "tvList";
			this.tvList.Size = new global::System.Drawing.Size(268, 394);
			this.tvList.TabIndex = 46;
			this.tvList.AfterCheck += new global::System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterCheck);
			this.tvList.DrawNode += new global::System.Windows.Forms.DrawTreeNodeEventHandler(this.tvList_DrawNode);
			this.pnFactory.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnFactory.Controls.Add(this.rbK5M);
			this.pnFactory.Controls.Add(this.rbK3EV);
			this.pnFactory.Controls.Add(this.rbK5);
			this.pnFactory.Controls.Add(this.rbK4);
			this.pnFactory.Controls.Add(this.rbK3);
			this.pnFactory.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnFactory.Location = new global::System.Drawing.Point(0, 211);
			this.pnFactory.Name = "pnFactory";
			this.pnFactory.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.pnFactory.Size = new global::System.Drawing.Size(268, 39);
			this.pnFactory.TabIndex = 13;
			this.rbK5M.AutoSize = true;
			this.rbK5M.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbK5M.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbK5M.Location = new global::System.Drawing.Point(209, 0);
			this.rbK5M.Name = "rbK5M";
			this.rbK5M.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbK5M.Size = new global::System.Drawing.Size(65, 37);
			this.rbK5M.TabIndex = 4;
			this.rbK5M.Text = "K5 M";
			this.rbK5M.UseVisualStyleBackColor = true;
			this.rbK5M.Visible = false;
			this.rbK5M.Click += new global::System.EventHandler(this.rbK3_CheckedChanged);
			this.rbK3EV.AutoSize = true;
			this.rbK3EV.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbK3EV.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbK3EV.Location = new global::System.Drawing.Point(147, 0);
			this.rbK3EV.Name = "rbK3EV";
			this.rbK3EV.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbK3EV.Size = new global::System.Drawing.Size(62, 37);
			this.rbK3EV.TabIndex = 3;
			this.rbK3EV.Text = "K3 E";
			this.rbK3EV.UseVisualStyleBackColor = true;
			this.rbK3EV.Visible = false;
			this.rbK3EV.Click += new global::System.EventHandler(this.rbK3_CheckedChanged);
			this.rbK5.AutoSize = true;
			this.rbK5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbK5.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbK5.Location = new global::System.Drawing.Point(99, 0);
			this.rbK5.Name = "rbK5";
			this.rbK5.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbK5.Size = new global::System.Drawing.Size(48, 37);
			this.rbK5.TabIndex = 2;
			this.rbK5.Text = "K5";
			this.rbK5.UseVisualStyleBackColor = true;
			this.rbK5.Click += new global::System.EventHandler(this.rbK3_CheckedChanged);
			this.rbK4.AutoSize = true;
			this.rbK4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbK4.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbK4.Location = new global::System.Drawing.Point(51, 0);
			this.rbK4.Name = "rbK4";
			this.rbK4.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbK4.Size = new global::System.Drawing.Size(48, 37);
			this.rbK4.TabIndex = 1;
			this.rbK4.Text = "K4";
			this.rbK4.UseVisualStyleBackColor = true;
			this.rbK4.Visible = false;
			this.rbK4.Click += new global::System.EventHandler(this.rbK3_CheckedChanged);
			this.rbK3.AutoSize = true;
			this.rbK3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbK3.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbK3.Location = new global::System.Drawing.Point(3, 0);
			this.rbK3.Name = "rbK3";
			this.rbK3.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbK3.Size = new global::System.Drawing.Size(48, 37);
			this.rbK3.TabIndex = 0;
			this.rbK3.Text = "K3";
			this.rbK3.UseVisualStyleBackColor = true;
			this.rbK3.Click += new global::System.EventHandler(this.rbK3_CheckedChanged);
			this.pnMTBFType.Controls.Add(this.panel18);
			this.pnMTBFType.Controls.Add(this.panel19);
			this.pnMTBFType.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnMTBFType.Location = new global::System.Drawing.Point(0, 127);
			this.pnMTBFType.Name = "pnMTBFType";
			this.pnMTBFType.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 0);
			this.pnMTBFType.Size = new global::System.Drawing.Size(268, 84);
			this.pnMTBFType.TabIndex = 19;
			this.pnMTBFType.Visible = false;
			this.panel18.Controls.Add(this.rbProductionHour);
			this.panel18.Controls.Add(this.rbDayHour);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel18.Location = new global::System.Drawing.Point(0, 29);
			this.panel18.Name = "panel18";
			this.panel18.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel18.Size = new global::System.Drawing.Size(268, 55);
			this.panel18.TabIndex = 14;
			this.rbProductionHour.AutoSize = true;
			this.rbProductionHour.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbProductionHour.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbProductionHour.Location = new global::System.Drawing.Point(137, 3);
			this.rbProductionHour.Name = "rbProductionHour";
			this.rbProductionHour.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbProductionHour.Size = new global::System.Drawing.Size(114, 49);
			this.rbProductionHour.TabIndex = 10;
			this.rbProductionHour.Text = "Actual Hour\r\n(RFID)";
			this.rbProductionHour.UseVisualStyleBackColor = true;
			this.rbDayHour.AutoSize = true;
			this.rbDayHour.Checked = true;
			this.rbDayHour.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbDayHour.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbDayHour.Location = new global::System.Drawing.Point(3, 3);
			this.rbDayHour.Name = "rbDayHour";
			this.rbDayHour.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbDayHour.Size = new global::System.Drawing.Size(134, 49);
			this.rbDayHour.TabIndex = 9;
			this.rbDayHour.TabStop = true;
			this.rbDayHour.Text = "Day Hour(24h)";
			this.rbDayHour.UseVisualStyleBackColor = true;
			this.panel19.BackColor = global::System.Drawing.Color.Transparent;
			this.panel19.Controls.Add(this.label2);
			this.panel19.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel19.ForeColor = global::System.Drawing.Color.Black;
			this.panel19.Location = new global::System.Drawing.Point(0, 3);
			this.panel19.Name = "panel19";
			this.panel19.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 3);
			this.panel19.Size = new global::System.Drawing.Size(268, 26);
			this.panel19.TabIndex = 13;
			this.label2.BackColor = global::System.Drawing.Color.SkyBlue;
			this.label2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label2.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(0, 3);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(268, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "MTBF Type";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.pnIndexType.Controls.Add(this.panel17);
			this.pnIndexType.Controls.Add(this.panel16);
			this.pnIndexType.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnIndexType.Location = new global::System.Drawing.Point(0, 65);
			this.pnIndexType.Name = "pnIndexType";
			this.pnIndexType.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 0);
			this.pnIndexType.Size = new global::System.Drawing.Size(268, 62);
			this.pnIndexType.TabIndex = 18;
			this.panel17.Controls.Add(this.rbStartTime);
			this.panel17.Controls.Add(this.rbRequestTime);
			this.panel17.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel17.Location = new global::System.Drawing.Point(0, 29);
			this.panel17.Name = "panel17";
			this.panel17.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel17.Size = new global::System.Drawing.Size(268, 30);
			this.panel17.TabIndex = 12;
			this.rbStartTime.AutoSize = true;
			this.rbStartTime.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbStartTime.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbStartTime.Location = new global::System.Drawing.Point(102, 3);
			this.rbStartTime.Name = "rbStartTime";
			this.rbStartTime.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbStartTime.Size = new global::System.Drawing.Size(78, 24);
			this.rbStartTime.TabIndex = 13;
			this.rbStartTime.Text = "START";
			this.rbStartTime.UseVisualStyleBackColor = true;
			this.rbRequestTime.AutoSize = true;
			this.rbRequestTime.Checked = true;
			this.rbRequestTime.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbRequestTime.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbRequestTime.Location = new global::System.Drawing.Point(3, 3);
			this.rbRequestTime.Name = "rbRequestTime";
			this.rbRequestTime.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbRequestTime.Size = new global::System.Drawing.Size(99, 24);
			this.rbRequestTime.TabIndex = 11;
			this.rbRequestTime.TabStop = true;
			this.rbRequestTime.Text = "REQUEST";
			this.rbRequestTime.UseVisualStyleBackColor = true;
			this.panel16.Controls.Add(this.label11);
			this.panel16.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel16.Location = new global::System.Drawing.Point(0, 3);
			this.panel16.Name = "panel16";
			this.panel16.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 3);
			this.panel16.Size = new global::System.Drawing.Size(268, 26);
			this.panel16.TabIndex = 11;
			this.label11.BackColor = global::System.Drawing.Color.SkyBlue;
			this.label11.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label11.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label11.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.Location = new global::System.Drawing.Point(0, 3);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(268, 20);
			this.label11.TabIndex = 0;
			this.label11.Text = "Index Type";
			this.label11.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.pnOEEType.Controls.Add(this.panel14);
			this.pnOEEType.Controls.Add(this.panel13);
			this.pnOEEType.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnOEEType.Location = new global::System.Drawing.Point(0, 0);
			this.pnOEEType.Name = "pnOEEType";
			this.pnOEEType.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 0);
			this.pnOEEType.Size = new global::System.Drawing.Size(268, 65);
			this.pnOEEType.TabIndex = 17;
			this.pnOEEType.Visible = false;
			this.panel14.Controls.Add(this.rbMTTR);
			this.panel14.Controls.Add(this.rbMTBF);
			this.panel14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new global::System.Drawing.Point(0, 29);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel14.Size = new global::System.Drawing.Size(268, 30);
			this.panel14.TabIndex = 14;
			this.rbMTTR.AutoSize = true;
			this.rbMTTR.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbMTTR.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbMTTR.Location = new global::System.Drawing.Point(73, 3);
			this.rbMTTR.Name = "rbMTTR";
			this.rbMTTR.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbMTTR.Size = new global::System.Drawing.Size(71, 24);
			this.rbMTTR.TabIndex = 10;
			this.rbMTTR.Text = "MTTR";
			this.rbMTTR.UseVisualStyleBackColor = true;
			this.rbMTTR.CheckedChanged += new global::System.EventHandler(this.rbMTBF_CheckedChanged);
			this.rbMTBF.AutoSize = true;
			this.rbMTBF.Checked = true;
			this.rbMTBF.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbMTBF.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbMTBF.Location = new global::System.Drawing.Point(3, 3);
			this.rbMTBF.Name = "rbMTBF";
			this.rbMTBF.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbMTBF.Size = new global::System.Drawing.Size(70, 24);
			this.rbMTBF.TabIndex = 9;
			this.rbMTBF.TabStop = true;
			this.rbMTBF.Text = "MTBF";
			this.rbMTBF.UseVisualStyleBackColor = true;
			this.rbMTBF.CheckedChanged += new global::System.EventHandler(this.rbMTBF_CheckedChanged);
			this.panel13.BackColor = global::System.Drawing.Color.Transparent;
			this.panel13.Controls.Add(this.label10);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel13.ForeColor = global::System.Drawing.Color.Black;
			this.panel13.Location = new global::System.Drawing.Point(0, 3);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 3);
			this.panel13.Size = new global::System.Drawing.Size(268, 26);
			this.panel13.TabIndex = 13;
			this.label10.BackColor = global::System.Drawing.Color.SkyBlue;
			this.label10.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label10.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label10.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.Location = new global::System.Drawing.Point(0, 3);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(268, 20);
			this.label10.TabIndex = 1;
			this.label10.Text = "OEE Type";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.pnSubIndex2.AutoSize = true;
			this.pnSubIndex2.Controls.Add(this.panel2);
			this.pnSubIndex2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnSubIndex2.Location = new global::System.Drawing.Point(0, 0);
			this.pnSubIndex2.Name = "pnSubIndex2";
			this.pnSubIndex2.Size = new global::System.Drawing.Size(268, 64);
			this.pnSubIndex2.TabIndex = 0;
			this.pnSubIndex2.Visible = false;
			this.panel2.Controls.Add(this.gbHccLocation);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(268, 64);
			this.panel2.TabIndex = 0;
			this.gbHccLocation.Controls.Add(this.cbDeviceSite);
			this.gbHccLocation.Controls.Add(this.tbLocation);
			this.gbHccLocation.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gbHccLocation.Location = new global::System.Drawing.Point(0, 0);
			this.gbHccLocation.Name = "gbHccLocation";
			this.gbHccLocation.Size = new global::System.Drawing.Size(268, 64);
			this.gbHccLocation.TabIndex = 1;
			this.gbHccLocation.TabStop = false;
			this.gbHccLocation.Text = "Location";
			this.tbLocation.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbLocation.Location = new global::System.Drawing.Point(3, 17);
			this.tbLocation.Name = "tbLocation";
			this.tbLocation.Size = new global::System.Drawing.Size(262, 21);
			this.tbLocation.TabIndex = 0;
			this.pnDate.AutoSize = true;
			this.pnDate.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnDate.Controls.Add(this.panel3);
			this.pnDate.Controls.Add(this.label1);
			this.pnDate.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnDate.Location = new global::System.Drawing.Point(0, 0);
			this.pnDate.Name = "pnDate";
			this.pnDate.Padding = new global::System.Windows.Forms.Padding(3);
			this.pnDate.Size = new global::System.Drawing.Size(268, 87);
			this.pnDate.TabIndex = 48;
			this.panel3.AutoSize = true;
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(3, 26);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel3.Size = new global::System.Drawing.Size(260, 56);
			this.panel3.TabIndex = 19;
			this.panel6.AutoSize = true;
			this.panel6.Controls.Add(this.dtEndDate);
			this.panel6.Controls.Add(this.dtStartDate);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new global::System.Drawing.Point(3, 3);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(254, 50);
			this.panel6.TabIndex = 0;
			this.dtEndDate.CustomFormat = "'End Date' yyyy-MM-dd";
			this.dtEndDate.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.dtEndDate.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.dtEndDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtEndDate.Location = new global::System.Drawing.Point(0, 25);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new global::System.Drawing.Size(254, 25);
			this.dtEndDate.TabIndex = 18;
			this.dtEndDate.TabStop = false;
			this.dtStartDate.CustomFormat = "'Start Date' yyyy-MM-dd";
			this.dtStartDate.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.dtStartDate.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.dtStartDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtStartDate.Location = new global::System.Drawing.Point(0, 0);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new global::System.Drawing.Size(254, 25);
			this.dtStartDate.TabIndex = 13;
			this.dtStartDate.TabStop = false;
			this.label1.BackColor = global::System.Drawing.Color.SkyBlue;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(3, 3);
			this.label1.Margin = new global::System.Windows.Forms.Padding(3);
			this.label1.Name = "label1";
			this.label1.Padding = new global::System.Windows.Forms.Padding(3);
			this.label1.Size = new global::System.Drawing.Size(260, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Select Period";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.pnBaseSearch.Controls.Add(this.groupBox4);
			this.pnBaseSearch.Controls.Add(this.gbExcel);
			this.pnBaseSearch.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.pnBaseSearch.Location = new global::System.Drawing.Point(0, 795);
			this.pnBaseSearch.Name = "pnBaseSearch";
			this.pnBaseSearch.Padding = new global::System.Windows.Forms.Padding(3);
			this.pnBaseSearch.Size = new global::System.Drawing.Size(268, 68);
			this.pnBaseSearch.TabIndex = 47;
			this.groupBox4.Controls.Add(this.btnSearch);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.groupBox4.Font = new global::System.Drawing.Font("굴림체", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.groupBox4.Location = new global::System.Drawing.Point(103, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(81, 62);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Search";
			this.btnSearch.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnSearch.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.TableSearch;
			this.btnSearch.Location = new global::System.Drawing.Point(25, 24);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new global::System.Drawing.Size(36, 31);
			this.btnSearch.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.btnSearch.TabIndex = 10;
			this.btnSearch.TabStop = false;
			this.btnSearch.Click += new global::System.EventHandler(this.btnSearch_Click);
			this.gbExcel.Controls.Add(this.btnExcel);
			this.gbExcel.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.gbExcel.Font = new global::System.Drawing.Font("굴림체", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.gbExcel.Location = new global::System.Drawing.Point(184, 3);
			this.gbExcel.Name = "gbExcel";
			this.gbExcel.Size = new global::System.Drawing.Size(81, 62);
			this.gbExcel.TabIndex = 12;
			this.gbExcel.TabStop = false;
			this.gbExcel.Text = "Excel";
			this.gbExcel.Visible = false;
			this.btnExcel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnExcel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.SaveExcel;
			this.btnExcel.Location = new global::System.Drawing.Point(24, 24);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new global::System.Drawing.Size(36, 31);
			this.btnExcel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.btnExcel.TabIndex = 10;
			this.btnExcel.TabStop = false;
			this.btnExcel.Click += new global::System.EventHandler(this.btnExcel_Click);
			this.btnExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.btnExcel_MouseUp);
			this.tcMainPage.Controls.Add(this.tpMaintTrend);
			this.tcMainPage.Controls.Add(this.tpFactorTrend);
			this.tcMainPage.Controls.Add(this.tpOEETrand);
			this.tcMainPage.Controls.Add(this.tpHandlerUtili);
			this.tcMainPage.Controls.Add(this.tpTesterUtili);
			this.tcMainPage.Controls.Add(this.tabDeviceTrend);
			this.tcMainPage.Controls.Add(this.tbBoardTrend);
			this.tcMainPage.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tcMainPage.Location = new global::System.Drawing.Point(0, 0);
			this.tcMainPage.Name = "tcMainPage";
			this.tcMainPage.SelectedIndex = 0;
			this.tcMainPage.Size = new global::System.Drawing.Size(1148, 863);
			this.tcMainPage.TabIndex = 0;
			this.tcMainPage.SelectedIndexChanged += new global::System.EventHandler(this.tabControl1_SelectedIndexChanged);
			this.tcMainPage.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tbChartZoom_KeyUp);
			this.tpMaintTrend.AutoScroll = true;
			this.tpMaintTrend.Controls.Add(this.pnTrendBase);
			this.tpMaintTrend.Controls.Add(this.pnChartMode);
			this.tpMaintTrend.Location = new global::System.Drawing.Point(4, 22);
			this.tpMaintTrend.Name = "tpMaintTrend";
			this.tpMaintTrend.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpMaintTrend.Size = new global::System.Drawing.Size(1140, 837);
			this.tpMaintTrend.TabIndex = 0;
			this.tpMaintTrend.Text = "Maint' Trend";
			this.tpMaintTrend.UseVisualStyleBackColor = true;
			this.tpMaintTrend.Resize += new global::System.EventHandler(this.tpMaintTrend_Resize);
			this.pnTrendBase.Controls.Add(this.splitContainer2);
			this.pnTrendBase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnTrendBase.Location = new global::System.Drawing.Point(3, 43);
			this.pnTrendBase.Name = "pnTrendBase";
			this.pnTrendBase.Size = new global::System.Drawing.Size(1134, 791);
			this.pnTrendBase.TabIndex = 1;
			this.splitContainer2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Panel1.Controls.Add(this.pnTimeBase);
			this.splitContainer2.Panel1MinSize = 0;
			this.splitContainer2.Panel2.Controls.Add(this.pnChartBase);
			this.splitContainer2.Size = new global::System.Drawing.Size(1134, 791);
			this.splitContainer2.SplitterDistance = 173;
			this.splitContainer2.TabIndex = 9;
			this.pnTimeBase.AutoScroll = true;
			this.pnTimeBase.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnTimeBase.Controls.Add(this.grid_trend);
			this.pnTimeBase.Controls.Add(this.panel5);
			this.pnTimeBase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnTimeBase.Location = new global::System.Drawing.Point(0, 0);
			this.pnTimeBase.Name = "pnTimeBase";
			this.pnTimeBase.Size = new global::System.Drawing.Size(173, 791);
			this.pnTimeBase.TabIndex = 8;
			this.grid_trend.Controls.Add(this.splitter1);
			this.grid_trend.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_trend.EnableSort = true;
			this.grid_trend.Font = new global::System.Drawing.Font("굴림체", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.grid_trend.Location = new global::System.Drawing.Point(0, 35);
			this.grid_trend.Name = "grid_trend";
			this.grid_trend.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_trend.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_trend.Size = new global::System.Drawing.Size(171, 754);
			this.grid_trend.TabIndex = 20;
			this.grid_trend.TabStop = true;
			this.grid_trend.ToolTipText = "";
			this.grid_trend.Click += new global::System.EventHandler(this.grid_trend_Click);
			this.splitter1.Location = new global::System.Drawing.Point(0, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new global::System.Drawing.Size(3, 754);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			this.panel5.Controls.Add(this.btnGridClose);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel5.Size = new global::System.Drawing.Size(171, 35);
			this.panel5.TabIndex = 21;
			this.btnGridClose.BackColor = global::System.Drawing.Color.White;
			this.btnGridClose.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnGridClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnGridClose.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.btnGridClose.Location = new global::System.Drawing.Point(109, 3);
			this.btnGridClose.Name = "btnGridClose";
			this.btnGridClose.Size = new global::System.Drawing.Size(59, 29);
			this.btnGridClose.TabIndex = 0;
			this.btnGridClose.Text = "X";
			this.btnGridClose.UseVisualStyleBackColor = false;
			this.btnGridClose.Click += new global::System.EventHandler(this.btnGridClose_Click);
			this.pnChartBase.AutoScroll = true;
			this.pnChartBase.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.pnChartBase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnChartBase.Location = new global::System.Drawing.Point(0, 0);
			this.pnChartBase.Name = "pnChartBase";
			this.pnChartBase.Size = new global::System.Drawing.Size(957, 791);
			this.pnChartBase.TabIndex = 2;
			this.pnChartBase.Resize += new global::System.EventHandler(this.pnChartBase_Resize);
			this.pnChartMode.Controls.Add(this.tbChartZoom);
			this.pnChartMode.Controls.Add(this.panel9);
			this.pnChartMode.Controls.Add(this.rbEquipment);
			this.pnChartMode.Controls.Add(this.rbModel);
			this.pnChartMode.Controls.Add(this.rbCategory);
			this.pnChartMode.Controls.Add(this.panel7);
			this.pnChartMode.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnChartMode.Location = new global::System.Drawing.Point(3, 3);
			this.pnChartMode.Name = "pnChartMode";
			this.pnChartMode.Padding = new global::System.Windows.Forms.Padding(3);
			this.pnChartMode.Size = new global::System.Drawing.Size(1134, 40);
			this.pnChartMode.TabIndex = 0;
			this.tbChartZoom.BackColor = global::System.Drawing.Color.White;
			this.tbChartZoom.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tbChartZoom.LargeChange = 1;
			this.tbChartZoom.Location = new global::System.Drawing.Point(593, 3);
			this.tbChartZoom.Maximum = 100;
			this.tbChartZoom.Name = "tbChartZoom";
			this.tbChartZoom.Size = new global::System.Drawing.Size(260, 34);
			this.tbChartZoom.TabIndex = 14;
			this.tbChartZoom.TickFrequency = 10;
			this.tbChartZoom.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tbChartZoom_KeyUp);
			this.tbChartZoom.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tbChartZoom_MouseUp);
			this.panel9.BackColor = global::System.Drawing.Color.Transparent;
			this.panel9.Controls.Add(this.label7);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel9.ForeColor = global::System.Drawing.Color.Black;
			this.panel9.Location = new global::System.Drawing.Point(511, 3);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel9.Size = new global::System.Drawing.Size(82, 34);
			this.panel9.TabIndex = 15;
			this.label7.BackColor = global::System.Drawing.Color.SkyBlue;
			this.label7.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label7.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label7.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new global::System.Drawing.Point(3, 3);
			this.label7.Name = "label7";
			this.label7.Padding = new global::System.Windows.Forms.Padding(3);
			this.label7.Size = new global::System.Drawing.Size(76, 28);
			this.label7.TabIndex = 1;
			this.label7.Text = "ZOOM";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.rbEquipment.AutoSize = true;
			this.rbEquipment.Checked = true;
			this.rbEquipment.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbEquipment.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbEquipment.Location = new global::System.Drawing.Point(362, 3);
			this.rbEquipment.Name = "rbEquipment";
			this.rbEquipment.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbEquipment.Size = new global::System.Drawing.Size(149, 34);
			this.rbEquipment.TabIndex = 3;
			this.rbEquipment.TabStop = true;
			this.rbEquipment.Text = "Individual Status";
			this.rbEquipment.UseVisualStyleBackColor = true;
			this.rbEquipment.CheckedChanged += new global::System.EventHandler(this.rbChartMode_CheckedChanged);
			this.rbModel.AutoSize = true;
			this.rbModel.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbModel.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbModel.Location = new global::System.Drawing.Point(216, 3);
			this.rbModel.Name = "rbModel";
			this.rbModel.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbModel.Size = new global::System.Drawing.Size(146, 34);
			this.rbModel.TabIndex = 2;
			this.rbModel.Text = "Status by Model";
			this.rbModel.UseVisualStyleBackColor = true;
			this.rbModel.CheckedChanged += new global::System.EventHandler(this.rbChartMode_CheckedChanged);
			this.rbCategory.AutoSize = true;
			this.rbCategory.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbCategory.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbCategory.Location = new global::System.Drawing.Point(85, 3);
			this.rbCategory.Name = "rbCategory";
			this.rbCategory.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbCategory.Size = new global::System.Drawing.Size(131, 34);
			this.rbCategory.TabIndex = 1;
			this.rbCategory.Text = "Overall Status";
			this.rbCategory.UseVisualStyleBackColor = true;
			this.rbCategory.CheckedChanged += new global::System.EventHandler(this.rbChartMode_CheckedChanged);
			this.panel7.BackColor = global::System.Drawing.Color.Transparent;
			this.panel7.Controls.Add(this.label5);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel7.ForeColor = global::System.Drawing.Color.Black;
			this.panel7.Location = new global::System.Drawing.Point(3, 3);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel7.Size = new global::System.Drawing.Size(82, 34);
			this.panel7.TabIndex = 13;
			this.label5.BackColor = global::System.Drawing.Color.SkyBlue;
			this.label5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label5.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label5.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(3, 3);
			this.label5.Name = "label5";
			this.label5.Padding = new global::System.Windows.Forms.Padding(3);
			this.label5.Size = new global::System.Drawing.Size(76, 28);
			this.label5.TabIndex = 1;
			this.label5.Text = "TYPE";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.tpFactorTrend.Controls.Add(this.splitContainer3);
			this.tpFactorTrend.Controls.Add(this.pnCaseChartMode);
			this.tpFactorTrend.Location = new global::System.Drawing.Point(4, 22);
			this.tpFactorTrend.Name = "tpFactorTrend";
			this.tpFactorTrend.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpFactorTrend.Size = new global::System.Drawing.Size(1140, 837);
			this.tpFactorTrend.TabIndex = 1;
			this.tpFactorTrend.Text = "Maint' Factor Trend";
			this.tpFactorTrend.UseVisualStyleBackColor = true;
			this.tpFactorTrend.Resize += new global::System.EventHandler(this.tpMaintTrend_Resize);
			this.splitContainer3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new global::System.Drawing.Point(3, 43);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Panel1.Controls.Add(this.pnDetailFactor);
			this.splitContainer3.Panel1MinSize = 0;
			this.splitContainer3.Panel2.Controls.Add(this.pnCaseBase);
			this.splitContainer3.Size = new global::System.Drawing.Size(1134, 791);
			this.splitContainer3.SplitterDistance = 346;
			this.splitContainer3.TabIndex = 10;
			this.pnDetailFactor.AutoScroll = true;
			this.pnDetailFactor.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnDetailFactor.Controls.Add(this.pnFactorBase3);
			this.pnDetailFactor.Controls.Add(this.pnFactorBase2);
			this.pnDetailFactor.Controls.Add(this.pnFactorBase);
			this.pnDetailFactor.Controls.Add(this.pnSubClose);
			this.pnDetailFactor.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnDetailFactor.Location = new global::System.Drawing.Point(0, 0);
			this.pnDetailFactor.Name = "pnDetailFactor";
			this.pnDetailFactor.Size = new global::System.Drawing.Size(346, 791);
			this.pnDetailFactor.TabIndex = 2;
			this.pnFactorBase3.AutoScroll = true;
			this.pnFactorBase3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnFactorBase3.Location = new global::System.Drawing.Point(0, 545);
			this.pnFactorBase3.Name = "pnFactorBase3";
			this.pnFactorBase3.Size = new global::System.Drawing.Size(327, 255);
			this.pnFactorBase3.TabIndex = 3;
			this.pnFactorBase3.Visible = false;
			this.pnFactorBase2.AutoScroll = true;
			this.pnFactorBase2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnFactorBase2.Location = new global::System.Drawing.Point(0, 290);
			this.pnFactorBase2.Name = "pnFactorBase2";
			this.pnFactorBase2.Size = new global::System.Drawing.Size(327, 255);
			this.pnFactorBase2.TabIndex = 2;
			this.pnFactorBase2.Visible = false;
			this.pnFactorBase.AutoScroll = true;
			this.pnFactorBase.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnFactorBase.Location = new global::System.Drawing.Point(0, 35);
			this.pnFactorBase.Name = "pnFactorBase";
			this.pnFactorBase.Size = new global::System.Drawing.Size(327, 255);
			this.pnFactorBase.TabIndex = 1;
			this.pnFactorBase.Visible = false;
			this.pnSubClose.AutoScroll = true;
			this.pnSubClose.Controls.Add(this.btnSubClose);
			this.pnSubClose.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnSubClose.Location = new global::System.Drawing.Point(0, 0);
			this.pnSubClose.Name = "pnSubClose";
			this.pnSubClose.Padding = new global::System.Windows.Forms.Padding(3);
			this.pnSubClose.Size = new global::System.Drawing.Size(327, 35);
			this.pnSubClose.TabIndex = 4;
			this.btnSubClose.BackColor = global::System.Drawing.Color.White;
			this.btnSubClose.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnSubClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnSubClose.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.btnSubClose.Location = new global::System.Drawing.Point(265, 3);
			this.btnSubClose.Name = "btnSubClose";
			this.btnSubClose.Size = new global::System.Drawing.Size(59, 29);
			this.btnSubClose.TabIndex = 0;
			this.btnSubClose.Text = "X";
			this.btnSubClose.UseVisualStyleBackColor = false;
			this.btnSubClose.Click += new global::System.EventHandler(this.btnSubClose_Click);
			this.pnCaseBase.AutoScroll = true;
			this.pnCaseBase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnCaseBase.Location = new global::System.Drawing.Point(0, 0);
			this.pnCaseBase.Name = "pnCaseBase";
			this.pnCaseBase.Size = new global::System.Drawing.Size(784, 791);
			this.pnCaseBase.TabIndex = 7;
			this.pnCaseChartMode.Controls.Add(this.tbFactorZoom);
			this.pnCaseChartMode.Controls.Add(this.panel11);
			this.pnCaseChartMode.Controls.Add(this.rbCaseEquipment);
			this.pnCaseChartMode.Controls.Add(this.rbCaseModel);
			this.pnCaseChartMode.Controls.Add(this.rbCaseCategory);
			this.pnCaseChartMode.Controls.Add(this.panel8);
			this.pnCaseChartMode.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnCaseChartMode.Location = new global::System.Drawing.Point(3, 3);
			this.pnCaseChartMode.Name = "pnCaseChartMode";
			this.pnCaseChartMode.Padding = new global::System.Windows.Forms.Padding(3);
			this.pnCaseChartMode.Size = new global::System.Drawing.Size(1134, 40);
			this.pnCaseChartMode.TabIndex = 6;
			this.pnCaseChartMode.Visible = false;
			this.tbFactorZoom.BackColor = global::System.Drawing.Color.White;
			this.tbFactorZoom.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tbFactorZoom.LargeChange = 1;
			this.tbFactorZoom.Location = new global::System.Drawing.Point(583, 3);
			this.tbFactorZoom.Maximum = 100;
			this.tbFactorZoom.Name = "tbFactorZoom";
			this.tbFactorZoom.Size = new global::System.Drawing.Size(260, 34);
			this.tbFactorZoom.TabIndex = 16;
			this.tbFactorZoom.TickFrequency = 10;
			this.tbFactorZoom.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tbChartZoom_KeyUp);
			this.tbFactorZoom.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tbChartZoom_MouseUp);
			this.panel11.BackColor = global::System.Drawing.Color.Transparent;
			this.panel11.Controls.Add(this.label9);
			this.panel11.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel11.ForeColor = global::System.Drawing.Color.Black;
			this.panel11.Location = new global::System.Drawing.Point(501, 3);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel11.Size = new global::System.Drawing.Size(82, 34);
			this.panel11.TabIndex = 17;
			this.label9.BackColor = global::System.Drawing.Color.SkyBlue;
			this.label9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label9.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label9.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.Location = new global::System.Drawing.Point(3, 3);
			this.label9.Name = "label9";
			this.label9.Padding = new global::System.Windows.Forms.Padding(3);
			this.label9.Size = new global::System.Drawing.Size(76, 28);
			this.label9.TabIndex = 1;
			this.label9.Text = "ZOOM";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.rbCaseEquipment.AutoSize = true;
			this.rbCaseEquipment.Checked = true;
			this.rbCaseEquipment.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbCaseEquipment.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbCaseEquipment.Location = new global::System.Drawing.Point(352, 3);
			this.rbCaseEquipment.Name = "rbCaseEquipment";
			this.rbCaseEquipment.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbCaseEquipment.Size = new global::System.Drawing.Size(149, 34);
			this.rbCaseEquipment.TabIndex = 3;
			this.rbCaseEquipment.TabStop = true;
			this.rbCaseEquipment.Text = "Individual Factor";
			this.rbCaseEquipment.UseVisualStyleBackColor = true;
			this.rbCaseEquipment.CheckedChanged += new global::System.EventHandler(this.rbCase_CheckedChanged);
			this.rbCaseModel.AutoSize = true;
			this.rbCaseModel.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbCaseModel.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbCaseModel.Location = new global::System.Drawing.Point(206, 3);
			this.rbCaseModel.Name = "rbCaseModel";
			this.rbCaseModel.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbCaseModel.Size = new global::System.Drawing.Size(146, 34);
			this.rbCaseModel.TabIndex = 2;
			this.rbCaseModel.Text = "Factor by Model";
			this.rbCaseModel.UseVisualStyleBackColor = true;
			this.rbCaseModel.CheckedChanged += new global::System.EventHandler(this.rbCase_CheckedChanged);
			this.rbCaseCategory.AutoSize = true;
			this.rbCaseCategory.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rbCaseCategory.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbCaseCategory.Location = new global::System.Drawing.Point(75, 3);
			this.rbCaseCategory.Name = "rbCaseCategory";
			this.rbCaseCategory.Padding = new global::System.Windows.Forms.Padding(3);
			this.rbCaseCategory.Size = new global::System.Drawing.Size(131, 34);
			this.rbCaseCategory.TabIndex = 1;
			this.rbCaseCategory.Text = "Overall Factor";
			this.rbCaseCategory.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.rbCaseCategory.UseVisualStyleBackColor = true;
			this.rbCaseCategory.CheckedChanged += new global::System.EventHandler(this.rbCase_CheckedChanged);
			this.panel8.BackColor = global::System.Drawing.Color.Transparent;
			this.panel8.Controls.Add(this.label6);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel8.ForeColor = global::System.Drawing.Color.Black;
			this.panel8.Location = new global::System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel8.Size = new global::System.Drawing.Size(72, 34);
			this.panel8.TabIndex = 14;
			this.label6.BackColor = global::System.Drawing.Color.SkyBlue;
			this.label6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label6.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label6.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(3, 3);
			this.label6.Name = "label6";
			this.label6.Padding = new global::System.Windows.Forms.Padding(3, 3, 0, 3);
			this.label6.Size = new global::System.Drawing.Size(66, 28);
			this.label6.TabIndex = 1;
			this.label6.Text = "TYPE";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.tpOEETrand.Controls.Add(this.pnOEEBase);
			this.tpOEETrand.Controls.Add(this.pnOEEMode);
			this.tpOEETrand.Location = new global::System.Drawing.Point(4, 22);
			this.tpOEETrand.Name = "tpOEETrand";
			this.tpOEETrand.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpOEETrand.Size = new global::System.Drawing.Size(1140, 837);
			this.tpOEETrand.TabIndex = 2;
			this.tpOEETrand.Text = "OEE Trend";
			this.tpOEETrand.UseVisualStyleBackColor = true;
			this.tpOEETrand.Resize += new global::System.EventHandler(this.tpMaintTrend_Resize);
			this.pnOEEBase.AutoScroll = true;
			this.pnOEEBase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnOEEBase.Location = new global::System.Drawing.Point(3, 43);
			this.pnOEEBase.Name = "pnOEEBase";
			this.pnOEEBase.Size = new global::System.Drawing.Size(1134, 791);
			this.pnOEEBase.TabIndex = 0;
			this.pnOEEBase.Resize += new global::System.EventHandler(this.pnOEEBase_Resize);
			this.pnOEEMode.Controls.Add(this.pnZoom);
			this.pnOEEMode.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnOEEMode.Location = new global::System.Drawing.Point(3, 3);
			this.pnOEEMode.Name = "pnOEEMode";
			this.pnOEEMode.Padding = new global::System.Windows.Forms.Padding(3);
			this.pnOEEMode.Size = new global::System.Drawing.Size(1134, 40);
			this.pnOEEMode.TabIndex = 8;
			this.pnZoom.Controls.Add(this.tbOEEChartZoom);
			this.pnZoom.Controls.Add(this.panel10);
			this.pnZoom.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnZoom.Location = new global::System.Drawing.Point(3, 3);
			this.pnZoom.Name = "pnZoom";
			this.pnZoom.Size = new global::System.Drawing.Size(357, 34);
			this.pnZoom.TabIndex = 18;
			this.pnZoom.Visible = false;
			this.tbOEEChartZoom.BackColor = global::System.Drawing.Color.White;
			this.tbOEEChartZoom.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tbOEEChartZoom.LargeChange = 1;
			this.tbOEEChartZoom.Location = new global::System.Drawing.Point(82, 0);
			this.tbOEEChartZoom.Maximum = 100;
			this.tbOEEChartZoom.Name = "tbOEEChartZoom";
			this.tbOEEChartZoom.Size = new global::System.Drawing.Size(260, 34);
			this.tbOEEChartZoom.TabIndex = 19;
			this.tbOEEChartZoom.TickFrequency = 10;
			this.tbOEEChartZoom.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tbChartZoom_KeyUp);
			this.tbOEEChartZoom.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tbChartZoom_MouseUp);
			this.panel10.BackColor = global::System.Drawing.Color.Transparent;
			this.panel10.Controls.Add(this.label8);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel10.ForeColor = global::System.Drawing.Color.Black;
			this.panel10.Location = new global::System.Drawing.Point(0, 0);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel10.Size = new global::System.Drawing.Size(82, 34);
			this.panel10.TabIndex = 18;
			this.label8.BackColor = global::System.Drawing.Color.SkyBlue;
			this.label8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label8.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label8.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new global::System.Drawing.Point(3, 3);
			this.label8.Name = "label8";
			this.label8.Padding = new global::System.Windows.Forms.Padding(3);
			this.label8.Size = new global::System.Drawing.Size(76, 28);
			this.label8.TabIndex = 1;
			this.label8.Text = "ZOOM";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.tpHandlerUtili.Controls.Add(this.panel12);
			this.tpHandlerUtili.Location = new global::System.Drawing.Point(4, 22);
			this.tpHandlerUtili.Name = "tpHandlerUtili";
			this.tpHandlerUtili.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpHandlerUtili.Size = new global::System.Drawing.Size(1140, 837);
			this.tpHandlerUtili.TabIndex = 3;
			this.tpHandlerUtili.Text = "Handler ACTL W.H";
			this.tpHandlerUtili.UseVisualStyleBackColor = true;
			this.panel12.Controls.Add(this.grid_utilization);
			this.panel12.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel12.Location = new global::System.Drawing.Point(3, 3);
			this.panel12.Name = "panel12";
			this.panel12.Size = new global::System.Drawing.Size(1134, 831);
			this.panel12.TabIndex = 11;
			this.grid_utilization.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_utilization.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_utilization.EnableSort = true;
			this.grid_utilization.Font = new global::System.Drawing.Font("굴림체", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.grid_utilization.Location = new global::System.Drawing.Point(0, 0);
			this.grid_utilization.Name = "grid_utilization";
			this.grid_utilization.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_utilization.SelectionMode = global::SourceGrid.GridSelectionMode.Row;
			this.grid_utilization.Size = new global::System.Drawing.Size(1134, 831);
			this.grid_utilization.TabIndex = 19;
			this.grid_utilization.TabStop = true;
			this.grid_utilization.ToolTipText = "";
			this.grid_utilization.Click += new global::System.EventHandler(this.grid_utilization_Click);
			this.grid_utilization.MouseLeave += new global::System.EventHandler(this.grid_utilization_MouseLeave);
			this.grid_utilization.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.grid_utilization_MouseMove);
			this.tpTesterUtili.Controls.Add(this.panel4);
			this.tpTesterUtili.Location = new global::System.Drawing.Point(4, 22);
			this.tpTesterUtili.Name = "tpTesterUtili";
			this.tpTesterUtili.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpTesterUtili.Size = new global::System.Drawing.Size(1140, 837);
			this.tpTesterUtili.TabIndex = 4;
			this.tpTesterUtili.Text = "Tester ACTL W.H";
			this.tpTesterUtili.UseVisualStyleBackColor = true;
			this.panel4.Controls.Add(this.grid_utilization_tester);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1134, 831);
			this.panel4.TabIndex = 12;
			this.grid_utilization_tester.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_utilization_tester.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_utilization_tester.EnableSort = true;
			this.grid_utilization_tester.Font = new global::System.Drawing.Font("굴림체", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.grid_utilization_tester.Location = new global::System.Drawing.Point(0, 0);
			this.grid_utilization_tester.Name = "grid_utilization_tester";
			this.grid_utilization_tester.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_utilization_tester.SelectionMode = global::SourceGrid.GridSelectionMode.Row;
			this.grid_utilization_tester.Size = new global::System.Drawing.Size(1134, 831);
			this.grid_utilization_tester.TabIndex = 19;
			this.grid_utilization_tester.TabStop = true;
			this.grid_utilization_tester.ToolTipText = "";
			this.grid_utilization_tester.Click += new global::System.EventHandler(this.grid_utilization_tester_Click);
			this.grid_utilization_tester.MouseLeave += new global::System.EventHandler(this.grid_utilization_MouseLeave);
			this.grid_utilization_tester.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.grid_utilization_MouseMove);
			this.tabDeviceTrend.Controls.Add(this.scDevice);
			this.tabDeviceTrend.Location = new global::System.Drawing.Point(4, 22);
			this.tabDeviceTrend.Name = "tabDeviceTrend";
			this.tabDeviceTrend.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabDeviceTrend.Size = new global::System.Drawing.Size(1140, 837);
			this.tabDeviceTrend.TabIndex = 5;
			this.tabDeviceTrend.Text = "Device Maintenance Trend";
			this.tabDeviceTrend.UseVisualStyleBackColor = true;
			this.scDevice.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.scDevice.Location = new global::System.Drawing.Point(3, 3);
			this.scDevice.Name = "scDevice";
			this.scDevice.Panel1MinSize = 0;
			this.scDevice.Panel2.Controls.Add(this.pnDeviceTrendBase);
			this.scDevice.Size = new global::System.Drawing.Size(1134, 831);
			this.scDevice.SplitterDistance = 25;
			this.scDevice.TabIndex = 1;
			this.pnDeviceTrendBase.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnDeviceTrendBase.Location = new global::System.Drawing.Point(0, 0);
			this.pnDeviceTrendBase.Name = "pnDeviceTrendBase";
			this.pnDeviceTrendBase.Size = new global::System.Drawing.Size(1105, 831);
			this.pnDeviceTrendBase.TabIndex = 0;
			this.tbBoardTrend.Controls.Add(this.splitContainer4);
			this.tbBoardTrend.Location = new global::System.Drawing.Point(4, 22);
			this.tbBoardTrend.Name = "tbBoardTrend";
			this.tbBoardTrend.Padding = new global::System.Windows.Forms.Padding(3);
			this.tbBoardTrend.Size = new global::System.Drawing.Size(1140, 837);
			this.tbBoardTrend.TabIndex = 6;
			this.tbBoardTrend.Text = "Board Trend";
			this.tbBoardTrend.UseVisualStyleBackColor = true;
			this.splitContainer4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new global::System.Drawing.Point(3, 3);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Panel1.Controls.Add(this.pnDetailSite);
			this.splitContainer4.Panel2.Controls.Add(this.pnSiteCharts);
			this.splitContainer4.Size = new global::System.Drawing.Size(1134, 831);
			this.splitContainer4.SplitterDistance = 300;
			this.splitContainer4.TabIndex = 1;
			this.pnDetailSite.AutoScroll = true;
			this.pnDetailSite.Controls.Add(this.pnDetailSiteChart);
			this.pnDetailSite.Controls.Add(this.panel23);
			this.pnDetailSite.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnDetailSite.Location = new global::System.Drawing.Point(0, 0);
			this.pnDetailSite.Name = "pnDetailSite";
			this.pnDetailSite.Size = new global::System.Drawing.Size(300, 831);
			this.pnDetailSite.TabIndex = 0;
			this.pnDetailSite.Visible = false;
			this.pnDetailSiteChart.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnDetailSiteChart.Location = new global::System.Drawing.Point(0, 35);
			this.pnDetailSiteChart.Name = "pnDetailSiteChart";
			this.pnDetailSiteChart.Size = new global::System.Drawing.Size(300, 326);
			this.pnDetailSiteChart.TabIndex = 6;
			this.panel23.AutoScroll = true;
			this.panel23.Controls.Add(this.btnCloseSiteDetail);
			this.panel23.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel23.Location = new global::System.Drawing.Point(0, 0);
			this.panel23.Name = "panel23";
			this.panel23.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel23.Size = new global::System.Drawing.Size(300, 35);
			this.panel23.TabIndex = 5;
			this.btnCloseSiteDetail.BackColor = global::System.Drawing.Color.White;
			this.btnCloseSiteDetail.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnCloseSiteDetail.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCloseSiteDetail.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.btnCloseSiteDetail.Location = new global::System.Drawing.Point(238, 3);
			this.btnCloseSiteDetail.Name = "btnCloseSiteDetail";
			this.btnCloseSiteDetail.Size = new global::System.Drawing.Size(59, 29);
			this.btnCloseSiteDetail.TabIndex = 0;
			this.btnCloseSiteDetail.Text = "X";
			this.btnCloseSiteDetail.UseVisualStyleBackColor = false;
			this.btnCloseSiteDetail.Click += new global::System.EventHandler(this.btnCloseSiteDetail_Click);
			this.pnSiteCharts.Controls.Add(this.tabControl1);
			this.pnSiteCharts.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnSiteCharts.Location = new global::System.Drawing.Point(0, 0);
			this.pnSiteCharts.Name = "pnSiteCharts";
			this.pnSiteCharts.Size = new global::System.Drawing.Size(830, 831);
			this.pnSiteCharts.TabIndex = 0;
			this.cbDeviceSite.AutoSize = true;
			this.cbDeviceSite.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.cbDeviceSite.Location = new global::System.Drawing.Point(203, 38);
			this.cbDeviceSite.Name = "cbDeviceSite";
			this.cbDeviceSite.Size = new global::System.Drawing.Size(62, 23);
			this.cbDeviceSite.TabIndex = 1;
			this.cbDeviceSite.Text = "Device";
			this.cbDeviceSite.UseVisualStyleBackColor = true;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new global::System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(830, 831);
			this.tabControl1.TabIndex = 0;
			this.tabPage1.Controls.Add(this.pnSiteRejectChart);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(822, 805);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Site Reject Trend";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage2.Controls.Add(this.pnBoardRejectChart);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(822, 805);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Reject Trend";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.pnSiteRejectChart.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnSiteRejectChart.Location = new global::System.Drawing.Point(3, 3);
			this.pnSiteRejectChart.Name = "pnSiteRejectChart";
			this.pnSiteRejectChart.Size = new global::System.Drawing.Size(816, 799);
			this.pnSiteRejectChart.TabIndex = 0;
			this.pnBoardRejectChart.Controls.Add(this.chart1);
			this.pnBoardRejectChart.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnBoardRejectChart.Location = new global::System.Drawing.Point(3, 3);
			this.pnBoardRejectChart.Name = "pnBoardRejectChart";
			this.pnBoardRejectChart.Size = new global::System.Drawing.Size(816, 799);
			this.pnBoardRejectChart.TabIndex = 2;
			chartArea.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea);
			legend.Name = "Legend1";
			this.chart1.Legends.Add(legend);
			this.chart1.Location = new global::System.Drawing.Point(0, 0);
			this.chart1.Name = "chart1";
			series.ChartArea = "ChartArea1";
			series.Legend = "Legend1";
			series.Name = "Series1";
			series.Points.Add(item);
			series.Points.Add(item2);
			series.Points.Add(item3);
			series.Points.Add(item4);
			series.Points.Add(item5);
			series.Points.Add(item6);
			this.chart1.Series.Add(series);
			this.chart1.Size = new global::System.Drawing.Size(261, 300);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1424, 865);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "TrendForm";
			this.Text = "TrendForm";
			base.Load += new global::System.EventHandler(this.TrendForm_Load);
			base.Shown += new global::System.EventHandler(this.TrendForm_Shown);
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.panel20.PerformLayout();
			this.panel21.ResumeLayout(false);
			this.panel21.PerformLayout();
			this.pbSubIndex.ResumeLayout(false);
			this.pnFactory.ResumeLayout(false);
			this.pnFactory.PerformLayout();
			this.pnMTBFType.ResumeLayout(false);
			this.panel18.ResumeLayout(false);
			this.panel18.PerformLayout();
			this.panel19.ResumeLayout(false);
			this.pnIndexType.ResumeLayout(false);
			this.panel17.ResumeLayout(false);
			this.panel17.PerformLayout();
			this.panel16.ResumeLayout(false);
			this.pnOEEType.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			this.panel13.ResumeLayout(false);
			this.pnSubIndex2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.gbHccLocation.ResumeLayout(false);
			this.gbHccLocation.PerformLayout();
			this.pnDate.ResumeLayout(false);
			this.pnDate.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.pnBaseSearch.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnSearch).EndInit();
			this.gbExcel.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnExcel).EndInit();
			this.tcMainPage.ResumeLayout(false);
			this.tpMaintTrend.ResumeLayout(false);
			this.pnTrendBase.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer2).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.pnTimeBase.ResumeLayout(false);
			this.grid_trend.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.pnChartMode.ResumeLayout(false);
			this.pnChartMode.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tbChartZoom).EndInit();
			this.panel9.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.tpFactorTrend.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer3).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.pnDetailFactor.ResumeLayout(false);
			this.pnSubClose.ResumeLayout(false);
			this.pnCaseChartMode.ResumeLayout(false);
			this.pnCaseChartMode.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tbFactorZoom).EndInit();
			this.panel11.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.tpOEETrand.ResumeLayout(false);
			this.pnOEEMode.ResumeLayout(false);
			this.pnZoom.ResumeLayout(false);
			this.pnZoom.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tbOEEChartZoom).EndInit();
			this.panel10.ResumeLayout(false);
			this.tpHandlerUtili.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.tpTesterUtili.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.tabDeviceTrend.ResumeLayout(false);
			this.scDevice.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.scDevice).EndInit();
			this.scDevice.ResumeLayout(false);
			this.tbBoardTrend.ResumeLayout(false);
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer4).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.pnDetailSite.ResumeLayout(false);
			this.panel23.ResumeLayout(false);
			this.pnSiteCharts.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.pnBoardRejectChart.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.chart1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400023E RID: 574
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400023F RID: 575
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000240 RID: 576
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000241 RID: 577
		private global::System.Windows.Forms.TabControl tcMainPage;

		// Token: 0x04000242 RID: 578
		private global::System.Windows.Forms.TabPage tpMaintTrend;

		// Token: 0x04000243 RID: 579
		private global::System.Windows.Forms.Panel pnFactory;

		// Token: 0x04000244 RID: 580
		private global::System.Windows.Forms.RadioButton rbK5;

		// Token: 0x04000245 RID: 581
		private global::System.Windows.Forms.RadioButton rbK4;

		// Token: 0x04000246 RID: 582
		private global::System.Windows.Forms.RadioButton rbK3;

		// Token: 0x04000247 RID: 583
		private global::System.Windows.Forms.TreeView tvList;

		// Token: 0x04000248 RID: 584
		private global::System.Windows.Forms.Panel pnChartMode;

		// Token: 0x04000249 RID: 585
		private global::System.Windows.Forms.RadioButton rbEquipment;

		// Token: 0x0400024A RID: 586
		private global::System.Windows.Forms.RadioButton rbModel;

		// Token: 0x0400024B RID: 587
		private global::System.Windows.Forms.RadioButton rbCategory;

		// Token: 0x0400024C RID: 588
		private global::System.Windows.Forms.Panel pnTrendBase;

		// Token: 0x0400024D RID: 589
		private global::System.Windows.Forms.TabPage tpFactorTrend;

		// Token: 0x0400024E RID: 590
		private global::System.Windows.Forms.Panel pnDetailFactor;

		// Token: 0x0400024F RID: 591
		private global::System.Windows.Forms.Panel pnCaseChartMode;

		// Token: 0x04000250 RID: 592
		private global::System.Windows.Forms.RadioButton rbCaseEquipment;

		// Token: 0x04000251 RID: 593
		private global::System.Windows.Forms.RadioButton rbCaseModel;

		// Token: 0x04000252 RID: 594
		private global::System.Windows.Forms.RadioButton rbCaseCategory;

		// Token: 0x04000253 RID: 595
		private global::System.Windows.Forms.Panel pnFactorBase3;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.Panel pnFactorBase2;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.Panel pnFactorBase;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.Panel pnSubClose;

		// Token: 0x04000257 RID: 599
		private global::System.Windows.Forms.Button btnSubClose;

		// Token: 0x04000258 RID: 600
		private global::System.Windows.Forms.TabPage tpOEETrand;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.Panel pnOEEBase;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.Panel pnOEEMode;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.Panel pnDate;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x0400025F RID: 607
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000260 RID: 608
		private global::System.Windows.Forms.Panel pnChartBase;

		// Token: 0x04000261 RID: 609
		private global::System.Windows.Forms.TrackBar tbChartZoom;

		// Token: 0x04000262 RID: 610
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.TrackBar tbFactorZoom;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.Panel pnZoom;

		// Token: 0x04000268 RID: 616
		private global::System.Windows.Forms.TrackBar tbOEEChartZoom;

		// Token: 0x04000269 RID: 617
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.Panel pnIndexType;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.Panel panel17;

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.RadioButton rbStartTime;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.RadioButton rbRequestTime;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.Panel panel16;

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.Panel pnOEEType;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.Panel panel14;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.RadioButton rbMTTR;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.RadioButton rbMTBF;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000277 RID: 631
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000278 RID: 632
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000279 RID: 633
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x0400027A RID: 634
		private global::System.Windows.Forms.DateTimePicker dtEndDate;

		// Token: 0x0400027B RID: 635
		private global::System.Windows.Forms.DateTimePicker dtStartDate;

		// Token: 0x0400027C RID: 636
		private global::System.Windows.Forms.Panel pnCaseBase;

		// Token: 0x0400027D RID: 637
		private global::System.Windows.Forms.TabPage tpHandlerUtili;

		// Token: 0x0400027E RID: 638
		private global::System.Windows.Forms.Panel panel12;

		// Token: 0x0400027F RID: 639
		private global::SourceGrid.Grid grid_utilization;

		// Token: 0x04000280 RID: 640
		private global::System.Windows.Forms.Panel pnBaseSearch;

		// Token: 0x04000281 RID: 641
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000282 RID: 642
		private global::System.Windows.Forms.PictureBox btnSearch;

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.GroupBox gbExcel;

		// Token: 0x04000284 RID: 644
		private global::System.Windows.Forms.PictureBox btnExcel;

		// Token: 0x04000285 RID: 645
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x04000286 RID: 646
		private global::System.Windows.Forms.Panel pnTimeBase;

		// Token: 0x04000287 RID: 647
		private global::SourceGrid.Grid grid_trend;

		// Token: 0x04000288 RID: 648
		private global::System.Windows.Forms.Splitter splitter1;

		// Token: 0x04000289 RID: 649
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x0400028A RID: 650
		private global::System.Windows.Forms.Button btnGridClose;

		// Token: 0x0400028B RID: 651
		private global::System.Windows.Forms.SplitContainer splitContainer2;

		// Token: 0x0400028C RID: 652
		private global::System.Windows.Forms.SplitContainer splitContainer3;

		// Token: 0x0400028D RID: 653
		private global::System.Windows.Forms.Panel pbSubIndex;

		// Token: 0x0400028E RID: 654
		private global::System.Windows.Forms.TabPage tpTesterUtili;

		// Token: 0x0400028F RID: 655
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000290 RID: 656
		private global::SourceGrid.Grid grid_utilization_tester;

		// Token: 0x04000291 RID: 657
		private global::System.Windows.Forms.TabPage tabDeviceTrend;

		// Token: 0x04000292 RID: 658
		private global::System.Windows.Forms.Panel pnDeviceTrendBase;

		// Token: 0x04000293 RID: 659
		private global::System.Windows.Forms.SplitContainer scDevice;

		// Token: 0x04000294 RID: 660
		private global::System.Windows.Forms.Panel pnMTBFType;

		// Token: 0x04000295 RID: 661
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000296 RID: 662
		private global::System.Windows.Forms.RadioButton rbProductionHour;

		// Token: 0x04000297 RID: 663
		private global::System.Windows.Forms.RadioButton rbDayHour;

		// Token: 0x04000298 RID: 664
		private global::System.Windows.Forms.Panel panel19;

		// Token: 0x04000299 RID: 665
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400029A RID: 666
		private global::System.Windows.Forms.RadioButton rbK3EV;

		// Token: 0x0400029B RID: 667
		private global::System.Windows.Forms.RadioButton rbK5M;

		// Token: 0x0400029C RID: 668
		private global::System.Windows.Forms.TabPage tbBoardTrend;

		// Token: 0x0400029D RID: 669
		private global::System.Windows.Forms.SplitContainer splitContainer4;

		// Token: 0x0400029E RID: 670
		private global::System.Windows.Forms.Panel pnSiteCharts;

		// Token: 0x0400029F RID: 671
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x040002A0 RID: 672
		private global::System.Windows.Forms.Panel panel20;

		// Token: 0x040002A1 RID: 673
		private global::System.Windows.Forms.Panel panel21;

		// Token: 0x040002A2 RID: 674
		private global::System.Windows.Forms.Panel pnSubIndex2;

		// Token: 0x040002A3 RID: 675
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040002A4 RID: 676
		private global::System.Windows.Forms.GroupBox gbHccLocation;

		// Token: 0x040002A5 RID: 677
		private global::System.Windows.Forms.TextBox tbLocation;

		// Token: 0x040002A6 RID: 678
		private global::System.Windows.Forms.Panel pnDetailSite;

		// Token: 0x040002A7 RID: 679
		private global::System.Windows.Forms.Panel panel23;

		// Token: 0x040002A8 RID: 680
		private global::System.Windows.Forms.Button btnCloseSiteDetail;

		// Token: 0x040002A9 RID: 681
		private global::System.Windows.Forms.Panel pnDetailSiteChart;

		// Token: 0x040002AA RID: 682
		private global::System.Windows.Forms.CheckBox cbDeviceSite;

		// Token: 0x040002AB RID: 683
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x040002AC RID: 684
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x040002AD RID: 685
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x040002AE RID: 686
		private global::System.Windows.Forms.Panel pnSiteRejectChart;

		// Token: 0x040002AF RID: 687
		private global::System.Windows.Forms.Panel pnBoardRejectChart;

		// Token: 0x040002B0 RID: 688
		private global::System.Windows.Forms.DataVisualization.Charting.Chart chart1;
	}
}
