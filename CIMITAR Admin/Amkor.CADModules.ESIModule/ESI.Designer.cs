namespace Amkor.CADModules.ESIModule
{
	// Token: 0x0200002D RID: 45
	public partial class ESI : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000163 RID: 355 RVA: 0x000194A1 File Offset: 0x000176A1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000194C0 File Offset: 0x000176C0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.ESIModule.ESI));
			global::System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new global::System.Windows.Forms.DataVisualization.Charting.ChartArea();
			global::System.Windows.Forms.DataVisualization.Charting.Legend legend = new global::System.Windows.Forms.DataVisualization.Charting.Legend();
			global::System.Windows.Forms.DataVisualization.Charting.Title title = new global::System.Windows.Forms.DataVisualization.Charting.Title();
			global::System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new global::System.Windows.Forms.DataVisualization.Charting.ChartArea();
			global::System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new global::System.Windows.Forms.DataVisualization.Charting.Legend();
			global::System.Windows.Forms.DataVisualization.Charting.Title title2 = new global::System.Windows.Forms.DataVisualization.Charting.Title();
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
			this.groupBox35 = new global::System.Windows.Forms.GroupBox();
			this.rdoAudit = new global::System.Windows.Forms.RadioButton();
			this.rdoAll = new global::System.Windows.Forms.RadioButton();
			this.rdoNormal = new global::System.Windows.Forms.RadioButton();
			this.label23 = new global::System.Windows.Forms.Label();
			this.cmbTestType = new global::System.Windows.Forms.ComboBox();
			this.label21 = new global::System.Windows.Forms.Label();
			this.cmbPF = new global::System.Windows.Forms.ComboBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.groupBox19 = new global::System.Windows.Forms.GroupBox();
			this.cmd_Yield_Search = new global::System.Windows.Forms.PictureBox();
			this.groupBox18 = new global::System.Windows.Forms.GroupBox();
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
			this.rdoLoadLot = new global::System.Windows.Forms.RadioButton();
			this.rdoLoadSN = new global::System.Windows.Forms.RadioButton();
			this.rdoSN = new global::System.Windows.Forms.RadioButton();
			this.rdoLot = new global::System.Windows.Forms.RadioButton();
			this.rdoDate = new global::System.Windows.Forms.RadioButton();
			this.label38 = new global::System.Windows.Forms.Label();
			this.txtSearchSN = new global::System.Windows.Forms.TextBox();
			this.date_End = new global::System.Windows.Forms.DateTimePicker();
			this.date_Start = new global::System.Windows.Forms.DateTimePicker();
			this.txtSearchLotid = new global::System.Windows.Forms.TextBox();
			this.tabFA_CheckIn = new global::System.Windows.Forms.TabPage();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.tabControl = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.groupBox9 = new global::System.Windows.Forms.GroupBox();
			this.label42 = new global::System.Windows.Forms.Label();
			this.txt_In_Dcc = new global::System.Windows.Forms.TextBox();
			this.label41 = new global::System.Windows.Forms.Label();
			this.txt_In_Config = new global::System.Windows.Forms.TextBox();
			this.txt_In_Comment = new global::System.Windows.Forms.TextBox();
			this.label33 = new global::System.Windows.Forms.Label();
			this.label27 = new global::System.Windows.Forms.Label();
			this.txt_In_Status = new global::System.Windows.Forms.TextBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.txt_In_StopTime = new global::System.Windows.Forms.TextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.txt_In_StartTime = new global::System.Windows.Forms.TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.txt_In_FailingMsg = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.txt_In_FailTests = new global::System.Windows.Forms.TextBox();
			this.txt_In_SWVersion = new global::System.Windows.Forms.TextBox();
			this.txt_In_SN = new global::System.Windows.Forms.TextBox();
			this.txt_In_TestStation = new global::System.Windows.Forms.TextBox();
			this.label15 = new global::System.Windows.Forms.Label();
			this.label17 = new global::System.Windows.Forms.Label();
			this.txt_In_Product = new global::System.Windows.Forms.TextBox();
			this.label22 = new global::System.Windows.Forms.Label();
			this.label28 = new global::System.Windows.Forms.Label();
			this.label30 = new global::System.Windows.Forms.Label();
			this.txt_In_StationID = new global::System.Windows.Forms.TextBox();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.gridUnitHistory = new global::SourceGrid.Grid();
			this.splitter1 = new global::System.Windows.Forms.Splitter();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.pb2DId = new global::System.Windows.Forms.PictureBox();
			this.gbExcel = new global::System.Windows.Forms.GroupBox();
			this.pbRequestExcel = new global::System.Windows.Forms.PictureBox();
			this.chk_AutoCheckIn = new global::System.Windows.Forms.CheckBox();
			this.groupBox16 = new global::System.Windows.Forms.GroupBox();
			this.cmd_In_Apply = new global::System.Windows.Forms.PictureBox();
			this.groupBox17 = new global::System.Windows.Forms.GroupBox();
			this.cmd_In_Search = new global::System.Windows.Forms.PictureBox();
			this.txtInputSN_In = new global::System.Windows.Forms.TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.label31 = new global::System.Windows.Forms.Label();
			this.tabFA_UnitList = new global::System.Windows.Forms.TabPage();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.gridUnitList = new global::SourceGrid.Grid();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cmbUnitStationId = new global::System.Windows.Forms.ComboBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.cbAll = new global::System.Windows.Forms.CheckBox();
			this.tbDcc = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.tbConfig = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.pbComment = new global::System.Windows.Forms.PictureBox();
			this.groupBox22 = new global::System.Windows.Forms.GroupBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.groupBox21 = new global::System.Windows.Forms.GroupBox();
			this.pbCheckIn = new global::System.Windows.Forms.PictureBox();
			this.label26 = new global::System.Windows.Forms.Label();
			this.cmbType = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label35 = new global::System.Windows.Forms.Label();
			this.cmbUnitStation = new global::System.Windows.Forms.ComboBox();
			this.cmbUnitProduct = new global::System.Windows.Forms.ComboBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.cmdUnitExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cmdUnitSearch = new global::System.Windows.Forms.PictureBox();
			this.txtUnitSN = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox11 = new global::System.Windows.Forms.GroupBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.dtp_End_Histroy = new global::System.Windows.Forms.DateTimePicker();
			this.dtp_Start_History = new global::System.Windows.Forms.DateTimePicker();
			this.tab_BT_Monitoring = new global::System.Windows.Forms.TabPage();
			this.panel14 = new global::System.Windows.Forms.Panel();
			this.groupBox23 = new global::System.Windows.Forms.GroupBox();
			this.gridBTMonitoring = new global::SourceGrid.Grid();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.groupBox12 = new global::System.Windows.Forms.GroupBox();
			this.label19 = new global::System.Windows.Forms.Label();
			this.groupBox25 = new global::System.Windows.Forms.GroupBox();
			this.rdo_BT_Month = new global::System.Windows.Forms.RadioButton();
			this.rdo_BT_SelectedDate = new global::System.Windows.Forms.RadioButton();
			this.dateTime_Month = new global::System.Windows.Forms.DateTimePicker();
			this.label24 = new global::System.Windows.Forms.Label();
			this.BT_Date_End = new global::System.Windows.Forms.DateTimePicker();
			this.label20 = new global::System.Windows.Forms.Label();
			this.BT_Date_Start = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox24 = new global::System.Windows.Forms.GroupBox();
			this.cmd_RawData_Excel = new global::System.Windows.Forms.PictureBox();
			this.groupBox13 = new global::System.Windows.Forms.GroupBox();
			this.cmd_BTOQC_Search = new global::System.Windows.Forms.PictureBox();
			this.groupBox15 = new global::System.Windows.Forms.GroupBox();
			this.cmd_BTOQC_Excel = new global::System.Windows.Forms.PictureBox();
			this.tab_UploadUnit = new global::System.Windows.Forms.TabPage();
			this.panel17 = new global::System.Windows.Forms.Panel();
			this.panel20 = new global::System.Windows.Forms.Panel();
			this.panel21 = new global::System.Windows.Forms.Panel();
			this.groupBox33 = new global::System.Windows.Forms.GroupBox();
			this.grid_SNList = new global::SourceGrid.Grid();
			this.panel16 = new global::System.Windows.Forms.Panel();
			this.groupBox26 = new global::System.Windows.Forms.GroupBox();
			this.label29 = new global::System.Windows.Forms.Label();
			this.txtOperation = new global::System.Windows.Forms.TextBox();
			this.label25 = new global::System.Windows.Forms.Label();
			this.txtDcc = new global::System.Windows.Forms.TextBox();
			this.groupBox31 = new global::System.Windows.Forms.GroupBox();
			this.cmd_UploadApply = new global::System.Windows.Forms.PictureBox();
			this.grpUpload = new global::System.Windows.Forms.GroupBox();
			this.cmd_Upload_Data = new global::System.Windows.Forms.PictureBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.txtUploadLot = new global::System.Windows.Forms.TextBox();
			this.splitter3 = new global::System.Windows.Forms.Splitter();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.panel22 = new global::System.Windows.Forms.Panel();
			this.groupBox30 = new global::System.Windows.Forms.GroupBox();
			this.gridUploadSNList = new global::SourceGrid.Grid();
			this.splitter4 = new global::System.Windows.Forms.Splitter();
			this.panel19 = new global::System.Windows.Forms.Panel();
			this.groupBox29 = new global::System.Windows.Forms.GroupBox();
			this.gridUploadLot = new global::SourceGrid.Grid();
			this.groupBox32 = new global::System.Windows.Forms.GroupBox();
			this.groupBox34 = new global::System.Windows.Forms.GroupBox();
			this.cmd_UploadDelete = new global::System.Windows.Forms.PictureBox();
			this.label32 = new global::System.Windows.Forms.Label();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.rdo_SearchUploadSN = new global::System.Windows.Forms.RadioButton();
			this.rdo_SearchUploadLot = new global::System.Windows.Forms.RadioButton();
			this.txtSearchUploadSN = new global::System.Windows.Forms.TextBox();
			this.groupBox27 = new global::System.Windows.Forms.GroupBox();
			this.cmd_UploadSearch = new global::System.Windows.Forms.PictureBox();
			this.txtSearchUploadLot = new global::System.Windows.Forms.TextBox();
			this.groupBox28 = new global::System.Windows.Forms.GroupBox();
			this.cmd_Download_Data = new global::System.Windows.Forms.PictureBox();
			this.tab_CheckSummary = new global::System.Windows.Forms.TabPage();
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.groupBox41 = new global::System.Windows.Forms.GroupBox();
			this.gridCheckSummary = new global::SourceGrid.Grid();
			this.rdo_Setup_Month = new global::System.Windows.Forms.RadioButton();
			this.label37 = new global::System.Windows.Forms.Label();
			this.dateTime_SetupMonth = new global::System.Windows.Forms.DateTimePicker();
			this.panel23 = new global::System.Windows.Forms.Panel();
			this.groupBox60 = new global::System.Windows.Forms.GroupBox();
			this.cmd_AddPara = new global::System.Windows.Forms.PictureBox();
			this.groupBox59 = new global::System.Windows.Forms.GroupBox();
			this.cmb_Summary_Device = new global::System.Windows.Forms.ComboBox();
			this.groupBox48 = new global::System.Windows.Forms.GroupBox();
			this.cmb_Summary_Result = new global::System.Windows.Forms.ComboBox();
			this.groupBox36 = new global::System.Windows.Forms.GroupBox();
			this.groupBox37 = new global::System.Windows.Forms.GroupBox();
			this.rdo_Setup_SelectDate = new global::System.Windows.Forms.RadioButton();
			this.label36 = new global::System.Windows.Forms.Label();
			this.Setup_Date_End = new global::System.Windows.Forms.DateTimePicker();
			this.Setup_Date_Start = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox38 = new global::System.Windows.Forms.GroupBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.groupBox39 = new global::System.Windows.Forms.GroupBox();
			this.cmd_ParaSummary_Search = new global::System.Windows.Forms.PictureBox();
			this.groupBox40 = new global::System.Windows.Forms.GroupBox();
			this.cmd_ParaSummary_Excel = new global::System.Windows.Forms.PictureBox();
			this.tab_CheckSummaryStatus = new global::System.Windows.Forms.TabPage();
			this.panel26 = new global::System.Windows.Forms.Panel();
			this.groupBox47 = new global::System.Windows.Forms.GroupBox();
			this.gridCheckStatus = new global::SourceGrid.Grid();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.groupBox58 = new global::System.Windows.Forms.GroupBox();
			this.cmb_Status_Tester = new global::System.Windows.Forms.ComboBox();
			this.groupBox42 = new global::System.Windows.Forms.GroupBox();
			this.groupBox43 = new global::System.Windows.Forms.GroupBox();
			this.rdo_Status_Month = new global::System.Windows.Forms.RadioButton();
			this.rdo_Status_SelectDate = new global::System.Windows.Forms.RadioButton();
			this.label40 = new global::System.Windows.Forms.Label();
			this.Status_Month = new global::System.Windows.Forms.DateTimePicker();
			this.Status_Date_End = new global::System.Windows.Forms.DateTimePicker();
			this.Status_Date_Start = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox44 = new global::System.Windows.Forms.GroupBox();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.groupBox45 = new global::System.Windows.Forms.GroupBox();
			this.cmd_CheckStatus_Search = new global::System.Windows.Forms.PictureBox();
			this.groupBox46 = new global::System.Windows.Forms.GroupBox();
			this.cmd_CheckStatus_Excel = new global::System.Windows.Forms.PictureBox();
			this.label43 = new global::System.Windows.Forms.Label();
			this.tab_CheckSummaryTrend = new global::System.Windows.Forms.TabPage();
			this.panel30 = new global::System.Windows.Forms.Panel();
			this.splitter5 = new global::System.Windows.Forms.Splitter();
			this.panel29 = new global::System.Windows.Forms.Panel();
			this.groupBox57 = new global::System.Windows.Forms.GroupBox();
			this.chart_RChart = new global::System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel28 = new global::System.Windows.Forms.Panel();
			this.groupBox56 = new global::System.Windows.Forms.GroupBox();
			this.chart_XBarChart = new global::System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel27 = new global::System.Windows.Forms.Panel();
			this.groupBox54 = new global::System.Windows.Forms.GroupBox();
			this.cmb_Trend_Device = new global::System.Windows.Forms.ComboBox();
			this.groupBox55 = new global::System.Windows.Forms.GroupBox();
			this.cmb_Trend_TestItem = new global::System.Windows.Forms.ComboBox();
			this.txtTrendTestItem = new global::System.Windows.Forms.TextBox();
			this.groupBox49 = new global::System.Windows.Forms.GroupBox();
			this.cmb_Trend_Tester = new global::System.Windows.Forms.ComboBox();
			this.groupBox50 = new global::System.Windows.Forms.GroupBox();
			this.rdo_Trend_Month = new global::System.Windows.Forms.RadioButton();
			this.rdo_Trend_SelectDate = new global::System.Windows.Forms.RadioButton();
			this.label47 = new global::System.Windows.Forms.Label();
			this.Trend_Month = new global::System.Windows.Forms.DateTimePicker();
			this.Trend_Date_End = new global::System.Windows.Forms.DateTimePicker();
			this.Trend_Date_Start = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox51 = new global::System.Windows.Forms.GroupBox();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.groupBox52 = new global::System.Windows.Forms.GroupBox();
			this.cmd_Trend_Search = new global::System.Windows.Forms.PictureBox();
			this.groupBox53 = new global::System.Windows.Forms.GroupBox();
			this.cmd_Trend_Excel = new global::System.Windows.Forms.PictureBox();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.chkCmbOperation = new global::Amkor.CADModules.ESIModule.Control.CheckedComboBox();
			this.chkCmbReportType = new global::Amkor.CADModules.ESIModule.Control.CheckedComboBox();
			this.chkcmbATETester = new global::Amkor.CADModules.ESIModule.Control.CheckedComboBox();
			this.chkcmb_BTOQCDate = new global::Amkor.CADModules.ESIModule.Control.CheckedComboBox();
			this.chkcmb_SetupDate = new global::Amkor.CADModules.ESIModule.Control.CheckedComboBox();
			this.chkcmb_Summary_Tester = new global::Amkor.CADModules.ESIModule.Control.CheckedComboBox();
			this.chkcmb_Status_Tester = new global::Amkor.CADModules.ESIModule.Control.CheckedComboBox();
			this.checkedComboBox2 = new global::Amkor.CADModules.ESIModule.Control.CheckedComboBox();
			this.panel3.SuspendLayout();
			this.panel15.SuspendLayout();
			this.chkBarcode_Out.SuspendLayout();
			this.tab_YieldReport.SuspendLayout();
			this.panelView.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox35.SuspendLayout();
			this.groupBox19.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Yield_Search).BeginInit();
			this.groupBox18.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Yield_Excel).BeginInit();
			this.panel10.SuspendLayout();
			this.panel11.SuspendLayout();
			this.groupBox20.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.tabFA_CheckIn.SuspendLayout();
			this.panel9.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb2DId).BeginInit();
			this.gbExcel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbRequestExcel).BeginInit();
			this.groupBox16.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_In_Apply).BeginInit();
			this.groupBox17.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_In_Search).BeginInit();
			this.panel7.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabFA_UnitList.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.gridUnitList.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbComment).BeginInit();
			this.groupBox22.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			this.groupBox21.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbCheckIn).BeginInit();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUnitExcel).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUnitSearch).BeginInit();
			this.groupBox11.SuspendLayout();
			this.tab_BT_Monitoring.SuspendLayout();
			this.panel14.SuspendLayout();
			this.groupBox23.SuspendLayout();
			this.panel13.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox25.SuspendLayout();
			this.groupBox24.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_RawData_Excel).BeginInit();
			this.groupBox13.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_BTOQC_Search).BeginInit();
			this.groupBox15.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_BTOQC_Excel).BeginInit();
			this.tab_UploadUnit.SuspendLayout();
			this.panel17.SuspendLayout();
			this.panel20.SuspendLayout();
			this.panel21.SuspendLayout();
			this.groupBox33.SuspendLayout();
			this.panel16.SuspendLayout();
			this.groupBox26.SuspendLayout();
			this.groupBox31.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_UploadApply).BeginInit();
			this.grpUpload.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Upload_Data).BeginInit();
			this.panel18.SuspendLayout();
			this.panel22.SuspendLayout();
			this.groupBox30.SuspendLayout();
			this.panel19.SuspendLayout();
			this.groupBox29.SuspendLayout();
			this.groupBox32.SuspendLayout();
			this.groupBox34.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_UploadDelete).BeginInit();
			this.groupBox27.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_UploadSearch).BeginInit();
			this.groupBox28.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Download_Data).BeginInit();
			this.tab_CheckSummary.SuspendLayout();
			this.panel24.SuspendLayout();
			this.groupBox41.SuspendLayout();
			this.gridCheckSummary.SuspendLayout();
			this.panel23.SuspendLayout();
			this.groupBox60.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_AddPara).BeginInit();
			this.groupBox59.SuspendLayout();
			this.groupBox48.SuspendLayout();
			this.groupBox36.SuspendLayout();
			this.groupBox37.SuspendLayout();
			this.groupBox38.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.groupBox39.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_ParaSummary_Search).BeginInit();
			this.groupBox40.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_ParaSummary_Excel).BeginInit();
			this.tab_CheckSummaryStatus.SuspendLayout();
			this.panel26.SuspendLayout();
			this.groupBox47.SuspendLayout();
			this.panel25.SuspendLayout();
			this.groupBox58.SuspendLayout();
			this.groupBox42.SuspendLayout();
			this.groupBox43.SuspendLayout();
			this.groupBox44.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			this.groupBox45.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_CheckStatus_Search).BeginInit();
			this.groupBox46.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_CheckStatus_Excel).BeginInit();
			this.tab_CheckSummaryTrend.SuspendLayout();
			this.panel30.SuspendLayout();
			this.panel29.SuspendLayout();
			this.groupBox57.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.chart_RChart).BeginInit();
			this.panel28.SuspendLayout();
			this.groupBox56.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.chart_XBarChart).BeginInit();
			this.panel27.SuspendLayout();
			this.groupBox54.SuspendLayout();
			this.groupBox55.SuspendLayout();
			this.groupBox49.SuspendLayout();
			this.groupBox50.SuspendLayout();
			this.groupBox51.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			this.groupBox52.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Trend_Search).BeginInit();
			this.groupBox53.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Trend_Excel).BeginInit();
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
			this.label12.Size = new global::System.Drawing.Size(96, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "ESI Module";
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
			this.label13.Size = new global::System.Drawing.Size(368, 15);
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
			this.chkBarcode_Out.Controls.Add(this.tabFA_CheckIn);
			this.chkBarcode_Out.Controls.Add(this.tabFA_UnitList);
			this.chkBarcode_Out.Controls.Add(this.tab_BT_Monitoring);
			this.chkBarcode_Out.Controls.Add(this.tab_UploadUnit);
			this.chkBarcode_Out.Controls.Add(this.tab_CheckSummary);
			this.chkBarcode_Out.Controls.Add(this.tab_CheckSummaryStatus);
			this.chkBarcode_Out.Controls.Add(this.tab_CheckSummaryTrend);
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
			this.tab_ReportView.TabIndex = 0;
			this.panel6.Controls.Add(this.groupBox10);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new global::System.Drawing.Point(301, 0);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 0);
			this.panel6.Size = new global::System.Drawing.Size(875, 77);
			this.panel6.TabIndex = 17;
			this.groupBox10.Controls.Add(this.groupBox35);
			this.groupBox10.Controls.Add(this.label23);
			this.groupBox10.Controls.Add(this.cmbTestType);
			this.groupBox10.Controls.Add(this.label21);
			this.groupBox10.Controls.Add(this.cmbPF);
			this.groupBox10.Controls.Add(this.label9);
			this.groupBox10.Controls.Add(this.chkCmbOperation);
			this.groupBox10.Controls.Add(this.label8);
			this.groupBox10.Controls.Add(this.chkCmbReportType);
			this.groupBox10.Controls.Add(this.groupBox19);
			this.groupBox10.Controls.Add(this.groupBox18);
			this.groupBox10.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox10.Location = new global::System.Drawing.Point(0, 3);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new global::System.Drawing.Size(875, 74);
			this.groupBox10.TabIndex = 4;
			this.groupBox10.TabStop = false;
			this.groupBox35.Controls.Add(this.rdoAudit);
			this.groupBox35.Controls.Add(this.rdoAll);
			this.groupBox35.Controls.Add(this.rdoNormal);
			this.groupBox35.Location = new global::System.Drawing.Point(483, 10);
			this.groupBox35.Name = "groupBox35";
			this.groupBox35.Size = new global::System.Drawing.Size(179, 58);
			this.groupBox35.TabIndex = 129;
			this.groupBox35.TabStop = false;
			this.groupBox35.Text = "Test Mode";
			this.rdoAudit.AutoSize = true;
			this.rdoAudit.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.rdoAudit.Location = new global::System.Drawing.Point(118, 24);
			this.rdoAudit.Name = "rdoAudit";
			this.rdoAudit.Size = new global::System.Drawing.Size(53, 17);
			this.rdoAudit.TabIndex = 130;
			this.rdoAudit.Text = "Audit";
			this.rdoAudit.UseVisualStyleBackColor = true;
			this.rdoAll.AutoSize = true;
			this.rdoAll.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.rdoAll.Location = new global::System.Drawing.Point(74, 24);
			this.rdoAll.Name = "rdoAll";
			this.rdoAll.Size = new global::System.Drawing.Size(38, 17);
			this.rdoAll.TabIndex = 129;
			this.rdoAll.Text = "All";
			this.rdoAll.UseVisualStyleBackColor = true;
			this.rdoNormal.AutoSize = true;
			this.rdoNormal.Checked = true;
			this.rdoNormal.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.rdoNormal.Location = new global::System.Drawing.Point(6, 24);
			this.rdoNormal.Name = "rdoNormal";
			this.rdoNormal.Size = new global::System.Drawing.Size(62, 17);
			this.rdoNormal.TabIndex = 128;
			this.rdoNormal.TabStop = true;
			this.rdoNormal.Text = "Normal";
			this.rdoNormal.UseVisualStyleBackColor = true;
			this.label23.AutoSize = true;
			this.label23.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label23.Location = new global::System.Drawing.Point(8, 48);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(51, 15);
			this.label23.TabIndex = 125;
			this.label23.Text = "TestType";
			this.cmbTestType.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbTestType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTestType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbTestType.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbTestType.FormattingEnabled = true;
			this.cmbTestType.Location = new global::System.Drawing.Point(81, 45);
			this.cmbTestType.Name = "cmbTestType";
			this.cmbTestType.Size = new global::System.Drawing.Size(120, 23);
			this.cmbTestType.TabIndex = 124;
			this.label21.AutoSize = true;
			this.label21.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label21.Location = new global::System.Drawing.Point(308, 48);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(25, 15);
			this.label21.TabIndex = 123;
			this.label21.Text = "P/F";
			this.cmbPF.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbPF.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPF.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbPF.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbPF.FormattingEnabled = true;
			this.cmbPF.Location = new global::System.Drawing.Point(357, 45);
			this.cmbPF.Name = "cmbPF";
			this.cmbPF.Size = new global::System.Drawing.Size(120, 23);
			this.cmbPF.TabIndex = 122;
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label9.Location = new global::System.Drawing.Point(308, 20);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(44, 15);
			this.label9.TabIndex = 117;
			this.label9.Text = "Station";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label8.Location = new global::System.Drawing.Point(8, 20);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(66, 15);
			this.label8.TabIndex = 115;
			this.label8.Text = "ReportType";
			this.groupBox19.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox19.Controls.Add(this.cmd_Yield_Search);
			this.groupBox19.Location = new global::System.Drawing.Point(668, 10);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox19.TabIndex = 4;
			this.groupBox19.TabStop = false;
			this.groupBox19.Text = "Search";
			this.cmd_Yield_Search.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_Yield_Search.Image");
			this.cmd_Yield_Search.Location = new global::System.Drawing.Point(14, 19);
			this.cmd_Yield_Search.Name = "cmd_Yield_Search";
			this.cmd_Yield_Search.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_Yield_Search.TabIndex = 102;
			this.cmd_Yield_Search.TabStop = false;
			this.cmd_Yield_Search.Click += new global::System.EventHandler(this.cmd_Yield_Search_Click);
			this.groupBox18.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox18.Controls.Add(this.cmd_Yield_Excel);
			this.groupBox18.Location = new global::System.Drawing.Point(736, 10);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox18.TabIndex = 103;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Excel";
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
			this.panel11.Location = new global::System.Drawing.Point(2, 138);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new global::System.Windows.Forms.Padding(0, 5, 0, 0);
			this.panel11.Size = new global::System.Drawing.Size(292, 531);
			this.panel11.TabIndex = 119;
			this.groupBox20.Controls.Add(this.gridLotList);
			this.groupBox20.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox20.Font = new global::System.Drawing.Font("Segoe UI", 1.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox20.Location = new global::System.Drawing.Point(0, 33);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new global::System.Drawing.Size(292, 498);
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
			this.gridLotList.Size = new global::System.Drawing.Size(286, 489);
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
			this.panel8.Location = new global::System.Drawing.Point(2, 114);
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
			this.groupBox14.Controls.Add(this.rdoLoadLot);
			this.groupBox14.Controls.Add(this.rdoLoadSN);
			this.groupBox14.Controls.Add(this.rdoSN);
			this.groupBox14.Controls.Add(this.rdoLot);
			this.groupBox14.Controls.Add(this.rdoDate);
			this.groupBox14.Controls.Add(this.label38);
			this.groupBox14.Controls.Add(this.txtSearchSN);
			this.groupBox14.Controls.Add(this.date_End);
			this.groupBox14.Controls.Add(this.date_Start);
			this.groupBox14.Controls.Add(this.txtSearchLotid);
			this.groupBox14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox14.Location = new global::System.Drawing.Point(2, 2);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Padding = new global::System.Windows.Forms.Padding(3, 6, 3, 3);
			this.groupBox14.Size = new global::System.Drawing.Size(292, 112);
			this.groupBox14.TabIndex = 1;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Search";
			this.rdoLoadLot.AutoSize = true;
			this.rdoLoadLot.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.rdoLoadLot.Location = new global::System.Drawing.Point(227, 54);
			this.rdoLoadLot.Name = "rdoLoadLot";
			this.rdoLoadLot.Size = new global::System.Drawing.Size(66, 17);
			this.rdoLoadLot.TabIndex = 127;
			this.rdoLoadLot.Text = "LoadLot";
			this.rdoLoadLot.UseVisualStyleBackColor = true;
			this.rdoLoadSN.AutoSize = true;
			this.rdoLoadSN.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.rdoLoadSN.Location = new global::System.Drawing.Point(227, 83);
			this.rdoLoadSN.Name = "rdoLoadSN";
			this.rdoLoadSN.Size = new global::System.Drawing.Size(64, 17);
			this.rdoLoadSN.TabIndex = 126;
			this.rdoLoadSN.Text = "LoadSN";
			this.rdoLoadSN.UseVisualStyleBackColor = true;
			this.rdoLoadSN.CheckedChanged += new global::System.EventHandler(this.rdoLoadSN_CheckedChanged);
			this.rdoSN.AutoSize = true;
			this.rdoSN.Location = new global::System.Drawing.Point(6, 82);
			this.rdoSN.Name = "rdoSN";
			this.rdoSN.Size = new global::System.Drawing.Size(40, 19);
			this.rdoSN.TabIndex = 124;
			this.rdoSN.Text = "SN";
			this.rdoSN.UseVisualStyleBackColor = true;
			this.rdoSN.CheckedChanged += new global::System.EventHandler(this.rdoSN_CheckedChanged);
			this.rdoLot.AutoSize = true;
			this.rdoLot.Location = new global::System.Drawing.Point(6, 53);
			this.rdoLot.Name = "rdoLot";
			this.rdoLot.Size = new global::System.Drawing.Size(42, 19);
			this.rdoLot.TabIndex = 123;
			this.rdoLot.Text = "Lot";
			this.rdoLot.UseVisualStyleBackColor = true;
			this.rdoLot.CheckedChanged += new global::System.EventHandler(this.rdoLot_CheckedChanged);
			this.rdoDate.AutoSize = true;
			this.rdoDate.Checked = true;
			this.rdoDate.Location = new global::System.Drawing.Point(6, 25);
			this.rdoDate.Name = "rdoDate";
			this.rdoDate.Size = new global::System.Drawing.Size(49, 19);
			this.rdoDate.TabIndex = 122;
			this.rdoDate.TabStop = true;
			this.rdoDate.Text = "Date";
			this.rdoDate.UseVisualStyleBackColor = true;
			this.rdoDate.CheckedChanged += new global::System.EventHandler(this.rdoDate_CheckedChanged);
			this.label38.AutoSize = true;
			this.label38.Location = new global::System.Drawing.Point(156, 27);
			this.label38.Name = "label38";
			this.label38.Size = new global::System.Drawing.Size(15, 15);
			this.label38.TabIndex = 92;
			this.label38.Text = "~";
			this.txtSearchSN.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtSearchSN.Location = new global::System.Drawing.Point(58, 81);
			this.txtSearchSN.Name = "txtSearchSN";
			this.txtSearchSN.Size = new global::System.Drawing.Size(160, 23);
			this.txtSearchSN.TabIndex = 120;
			this.txtSearchSN.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtSearchSN_KeyPress);
			this.date_End.CustomFormat = "yyyy-MM-dd";
			this.date_End.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.date_End.Location = new global::System.Drawing.Point(174, 23);
			this.date_End.Name = "date_End";
			this.date_End.Size = new global::System.Drawing.Size(95, 23);
			this.date_End.TabIndex = 84;
			this.date_Start.CustomFormat = "yyyy-MM-dd";
			this.date_Start.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.date_Start.Location = new global::System.Drawing.Point(58, 23);
			this.date_Start.Name = "date_Start";
			this.date_Start.Size = new global::System.Drawing.Size(95, 23);
			this.date_Start.TabIndex = 85;
			this.txtSearchLotid.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtSearchLotid.Location = new global::System.Drawing.Point(58, 52);
			this.txtSearchLotid.Name = "txtSearchLotid";
			this.txtSearchLotid.Size = new global::System.Drawing.Size(160, 23);
			this.txtSearchLotid.TabIndex = 100;
			this.txtSearchLotid.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtLotid_KeyPress);
			this.tabFA_CheckIn.Controls.Add(this.panel9);
			this.tabFA_CheckIn.Controls.Add(this.splitter1);
			this.tabFA_CheckIn.Controls.Add(this.panel5);
			this.tabFA_CheckIn.Controls.Add(this.panel7);
			this.tabFA_CheckIn.Location = new global::System.Drawing.Point(4, 24);
			this.tabFA_CheckIn.Name = "tabFA_CheckIn";
			this.tabFA_CheckIn.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabFA_CheckIn.Size = new global::System.Drawing.Size(1176, 671);
			this.tabFA_CheckIn.TabIndex = 3;
			this.tabFA_CheckIn.Text = "FA_Request";
			this.tabFA_CheckIn.UseVisualStyleBackColor = true;
			this.panel9.Controls.Add(this.tabControl);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel9.Location = new global::System.Drawing.Point(3, 136);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new global::System.Windows.Forms.Padding(3, 0, 3, 3);
			this.panel9.Size = new global::System.Drawing.Size(1170, 534);
			this.panel9.TabIndex = 85;
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new global::System.Drawing.Point(3, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new global::System.Drawing.Size(1164, 531);
			this.tabControl.TabIndex = 43;
			this.tabControl.SelectedIndexChanged += new global::System.EventHandler(this.tabControl_SelectedIndexChanged);
			this.tabPage1.Controls.Add(this.groupBox9);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(1156, 503);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Information";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.groupBox9.Controls.Add(this.label42);
			this.groupBox9.Controls.Add(this.txt_In_Dcc);
			this.groupBox9.Controls.Add(this.label41);
			this.groupBox9.Controls.Add(this.txt_In_Config);
			this.groupBox9.Controls.Add(this.txt_In_Comment);
			this.groupBox9.Controls.Add(this.label33);
			this.groupBox9.Controls.Add(this.label27);
			this.groupBox9.Controls.Add(this.txt_In_Status);
			this.groupBox9.Controls.Add(this.label18);
			this.groupBox9.Controls.Add(this.txt_In_StopTime);
			this.groupBox9.Controls.Add(this.label14);
			this.groupBox9.Controls.Add(this.txt_In_StartTime);
			this.groupBox9.Controls.Add(this.label11);
			this.groupBox9.Controls.Add(this.txt_In_FailingMsg);
			this.groupBox9.Controls.Add(this.label10);
			this.groupBox9.Controls.Add(this.txt_In_FailTests);
			this.groupBox9.Controls.Add(this.txt_In_SWVersion);
			this.groupBox9.Controls.Add(this.txt_In_SN);
			this.groupBox9.Controls.Add(this.txt_In_TestStation);
			this.groupBox9.Controls.Add(this.label15);
			this.groupBox9.Controls.Add(this.label17);
			this.groupBox9.Controls.Add(this.txt_In_Product);
			this.groupBox9.Controls.Add(this.label22);
			this.groupBox9.Controls.Add(this.label28);
			this.groupBox9.Controls.Add(this.label30);
			this.groupBox9.Controls.Add(this.txt_In_StationID);
			this.groupBox9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox9.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(1150, 497);
			this.groupBox9.TabIndex = 43;
			this.groupBox9.TabStop = false;
			this.label42.AutoSize = true;
			this.label42.Location = new global::System.Drawing.Point(846, 79);
			this.label42.Name = "label42";
			this.label42.Size = new global::System.Drawing.Size(27, 15);
			this.label42.TabIndex = 71;
			this.label42.Text = "Dcc";
			this.txt_In_Dcc.Location = new global::System.Drawing.Point(905, 76);
			this.txt_In_Dcc.Name = "txt_In_Dcc";
			this.txt_In_Dcc.ReadOnly = true;
			this.txt_In_Dcc.Size = new global::System.Drawing.Size(98, 23);
			this.txt_In_Dcc.TabIndex = 70;
			this.label41.AutoSize = true;
			this.label41.Location = new global::System.Drawing.Point(846, 50);
			this.label41.Name = "label41";
			this.label41.Size = new global::System.Drawing.Size(43, 15);
			this.label41.TabIndex = 69;
			this.label41.Text = "Config";
			this.txt_In_Config.Location = new global::System.Drawing.Point(905, 47);
			this.txt_In_Config.Name = "txt_In_Config";
			this.txt_In_Config.ReadOnly = true;
			this.txt_In_Config.Size = new global::System.Drawing.Size(98, 23);
			this.txt_In_Config.TabIndex = 68;
			this.txt_In_Comment.Location = new global::System.Drawing.Point(91, 301);
			this.txt_In_Comment.Multiline = true;
			this.txt_In_Comment.Name = "txt_In_Comment";
			this.txt_In_Comment.Size = new global::System.Drawing.Size(912, 84);
			this.txt_In_Comment.TabIndex = 67;
			this.label33.AutoSize = true;
			this.label33.Location = new global::System.Drawing.Point(14, 304);
			this.label33.Name = "label33";
			this.label33.Size = new global::System.Drawing.Size(61, 15);
			this.label33.TabIndex = 66;
			this.label33.Text = "Comment";
			this.label27.AutoSize = true;
			this.label27.Location = new global::System.Drawing.Point(846, 23);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(39, 15);
			this.label27.TabIndex = 65;
			this.label27.Text = "Status";
			this.txt_In_Status.Location = new global::System.Drawing.Point(905, 20);
			this.txt_In_Status.Name = "txt_In_Status";
			this.txt_In_Status.ReadOnly = true;
			this.txt_In_Status.Size = new global::System.Drawing.Size(98, 23);
			this.txt_In_Status.TabIndex = 64;
			this.label18.AutoSize = true;
			this.label18.Location = new global::System.Drawing.Point(427, 79);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(60, 15);
			this.label18.TabIndex = 63;
			this.label18.Text = "Stop Time";
			this.txt_In_StopTime.Location = new global::System.Drawing.Point(510, 76);
			this.txt_In_StopTime.Name = "txt_In_StopTime";
			this.txt_In_StopTime.ReadOnly = true;
			this.txt_In_StopTime.Size = new global::System.Drawing.Size(316, 23);
			this.txt_In_StopTime.TabIndex = 62;
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(14, 79);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(60, 15);
			this.label14.TabIndex = 61;
			this.label14.Text = "Start Time";
			this.txt_In_StartTime.Location = new global::System.Drawing.Point(91, 76);
			this.txt_In_StartTime.Name = "txt_In_StartTime";
			this.txt_In_StartTime.ReadOnly = true;
			this.txt_In_StartTime.Size = new global::System.Drawing.Size(305, 23);
			this.txt_In_StartTime.TabIndex = 60;
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(14, 199);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(68, 15);
			this.label11.TabIndex = 59;
			this.label11.Text = "Failing Msg";
			this.txt_In_FailingMsg.Location = new global::System.Drawing.Point(91, 196);
			this.txt_In_FailingMsg.Multiline = true;
			this.txt_In_FailingMsg.Name = "txt_In_FailingMsg";
			this.txt_In_FailingMsg.ReadOnly = true;
			this.txt_In_FailingMsg.Size = new global::System.Drawing.Size(912, 99);
			this.txt_In_FailingMsg.TabIndex = 58;
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(14, 108);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(53, 15);
			this.label10.TabIndex = 57;
			this.label10.Text = "Fail Tests";
			this.txt_In_FailTests.Location = new global::System.Drawing.Point(91, 105);
			this.txt_In_FailTests.Multiline = true;
			this.txt_In_FailTests.Name = "txt_In_FailTests";
			this.txt_In_FailTests.ReadOnly = true;
			this.txt_In_FailTests.Size = new global::System.Drawing.Size(912, 85);
			this.txt_In_FailTests.TabIndex = 56;
			this.txt_In_SWVersion.Location = new global::System.Drawing.Point(510, 47);
			this.txt_In_SWVersion.Name = "txt_In_SWVersion";
			this.txt_In_SWVersion.ReadOnly = true;
			this.txt_In_SWVersion.Size = new global::System.Drawing.Size(316, 23);
			this.txt_In_SWVersion.TabIndex = 55;
			this.txt_In_SN.Location = new global::System.Drawing.Point(91, 20);
			this.txt_In_SN.Name = "txt_In_SN";
			this.txt_In_SN.ReadOnly = true;
			this.txt_In_SN.Size = new global::System.Drawing.Size(186, 23);
			this.txt_In_SN.TabIndex = 53;
			this.txt_In_TestStation.Location = new global::System.Drawing.Point(600, 20);
			this.txt_In_TestStation.Name = "txt_In_TestStation";
			this.txt_In_TestStation.ReadOnly = true;
			this.txt_In_TestStation.Size = new global::System.Drawing.Size(226, 23);
			this.txt_In_TestStation.TabIndex = 52;
			this.label15.AutoSize = true;
			this.label15.Location = new global::System.Drawing.Point(427, 50);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(65, 15);
			this.label15.TabIndex = 46;
			this.label15.Text = "SW Version";
			this.label17.AutoSize = true;
			this.label17.Location = new global::System.Drawing.Point(302, 23);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(49, 15);
			this.label17.TabIndex = 40;
			this.label17.Text = "Product";
			this.txt_In_Product.Location = new global::System.Drawing.Point(361, 20);
			this.txt_In_Product.Name = "txt_In_Product";
			this.txt_In_Product.ReadOnly = true;
			this.txt_In_Product.Size = new global::System.Drawing.Size(118, 23);
			this.txt_In_Product.TabIndex = 39;
			this.label22.AutoSize = true;
			this.label22.Location = new global::System.Drawing.Point(517, 23);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(67, 15);
			this.label22.TabIndex = 28;
			this.label22.Text = "Test Station";
			this.label28.AutoSize = true;
			this.label28.Location = new global::System.Drawing.Point(14, 23);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(22, 15);
			this.label28.TabIndex = 10;
			this.label28.Text = "SN";
			this.label30.AutoSize = true;
			this.label30.Location = new global::System.Drawing.Point(14, 50);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(58, 15);
			this.label30.TabIndex = 6;
			this.label30.Text = "Station ID";
			this.txt_In_StationID.Location = new global::System.Drawing.Point(91, 47);
			this.txt_In_StationID.Name = "txt_In_StationID";
			this.txt_In_StationID.ReadOnly = true;
			this.txt_In_StationID.Size = new global::System.Drawing.Size(305, 23);
			this.txt_In_StationID.TabIndex = 5;
			this.tabPage2.AutoScroll = true;
			this.tabPage2.Controls.Add(this.panel1);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage2.Margin = new global::System.Windows.Forms.Padding(0);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new global::System.Drawing.Size(1156, 503);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "History";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.gridUnitHistory);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1156, 505);
			this.panel1.TabIndex = 122;
			this.gridUnitHistory.AutoSize = true;
			this.gridUnitHistory.EnableSort = true;
			this.gridUnitHistory.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridUnitHistory.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridUnitHistory.Location = new global::System.Drawing.Point(0, 0);
			this.gridUnitHistory.Margin = new global::System.Windows.Forms.Padding(0);
			this.gridUnitHistory.Name = "gridUnitHistory";
			this.gridUnitHistory.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridUnitHistory.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridUnitHistory.Size = new global::System.Drawing.Size(1305, 501);
			this.gridUnitHistory.TabIndex = 124;
			this.gridUnitHistory.TabStop = true;
			this.gridUnitHistory.ToolTipText = "";
			this.splitter1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new global::System.Drawing.Point(3, 133);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new global::System.Drawing.Size(1170, 3);
			this.splitter1.TabIndex = 84;
			this.splitter1.TabStop = false;
			this.panel5.Controls.Add(this.groupBox8);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(3, 54);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new global::System.Windows.Forms.Padding(2);
			this.panel5.Size = new global::System.Drawing.Size(1170, 79);
			this.panel5.TabIndex = 14;
			this.groupBox8.Controls.Add(this.groupBox6);
			this.groupBox8.Controls.Add(this.gbExcel);
			this.groupBox8.Controls.Add(this.chk_AutoCheckIn);
			this.groupBox8.Controls.Add(this.groupBox16);
			this.groupBox8.Controls.Add(this.groupBox17);
			this.groupBox8.Controls.Add(this.txtInputSN_In);
			this.groupBox8.Controls.Add(this.label16);
			this.groupBox8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox8.Location = new global::System.Drawing.Point(2, 2);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Padding = new global::System.Windows.Forms.Padding(3, 6, 3, 3);
			this.groupBox8.Size = new global::System.Drawing.Size(1166, 75);
			this.groupBox8.TabIndex = 1;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Scan";
			this.groupBox6.Controls.Add(this.pb2DId);
			this.groupBox6.Location = new global::System.Drawing.Point(503, 11);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(67, 61);
			this.groupBox6.TabIndex = 106;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "2D List";
			this.pb2DId.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pb2DId.Image");
			this.pb2DId.Location = new global::System.Drawing.Point(19, 20);
			this.pb2DId.Name = "pb2DId";
			this.pb2DId.Size = new global::System.Drawing.Size(32, 32);
			this.pb2DId.TabIndex = 103;
			this.pb2DId.TabStop = false;
			this.pb2DId.Click += new global::System.EventHandler(this.pb2DId_Click);
			this.pb2DId.MouseLeave += new global::System.EventHandler(this.pb2DId_MouseLeave);
			this.pb2DId.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pb2DId_MouseMove);
			this.gbExcel.Controls.Add(this.pbRequestExcel);
			this.gbExcel.Location = new global::System.Drawing.Point(576, 11);
			this.gbExcel.Name = "gbExcel";
			this.gbExcel.Size = new global::System.Drawing.Size(55, 61);
			this.gbExcel.TabIndex = 105;
			this.gbExcel.TabStop = false;
			this.gbExcel.Text = "Excel";
			this.gbExcel.Visible = false;
			this.pbRequestExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbRequestExcel.Image");
			this.pbRequestExcel.Location = new global::System.Drawing.Point(12, 19);
			this.pbRequestExcel.Name = "pbRequestExcel";
			this.pbRequestExcel.Size = new global::System.Drawing.Size(32, 32);
			this.pbRequestExcel.TabIndex = 103;
			this.pbRequestExcel.TabStop = false;
			this.pbRequestExcel.Click += new global::System.EventHandler(this.pbRequestExcel_Click);
			this.chk_AutoCheckIn.AutoSize = true;
			this.chk_AutoCheckIn.Location = new global::System.Drawing.Point(10, 18);
			this.chk_AutoCheckIn.Name = "chk_AutoCheckIn";
			this.chk_AutoCheckIn.Size = new global::System.Drawing.Size(97, 19);
			this.chk_AutoCheckIn.TabIndex = 104;
			this.chk_AutoCheckIn.Text = "Auto Request";
			this.chk_AutoCheckIn.UseVisualStyleBackColor = true;
			this.groupBox16.Controls.Add(this.cmd_In_Apply);
			this.groupBox16.Location = new global::System.Drawing.Point(430, 11);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new global::System.Drawing.Size(67, 61);
			this.groupBox16.TabIndex = 103;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Request";
			this.cmd_In_Apply.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_In_Apply.Image");
			this.cmd_In_Apply.Location = new global::System.Drawing.Point(18, 19);
			this.cmd_In_Apply.Name = "cmd_In_Apply";
			this.cmd_In_Apply.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_In_Apply.TabIndex = 104;
			this.cmd_In_Apply.TabStop = false;
			this.cmd_In_Apply.Click += new global::System.EventHandler(this.cmd_In_Apply_Click);
			this.groupBox17.Controls.Add(this.cmd_In_Search);
			this.groupBox17.Location = new global::System.Drawing.Point(362, 11);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox17.TabIndex = 4;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Search";
			this.cmd_In_Search.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_In_Search.Image");
			this.cmd_In_Search.Location = new global::System.Drawing.Point(14, 19);
			this.cmd_In_Search.Name = "cmd_In_Search";
			this.cmd_In_Search.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_In_Search.TabIndex = 102;
			this.cmd_In_Search.TabStop = false;
			this.cmd_In_Search.Click += new global::System.EventHandler(this.cmd_In_Search_Click);
			this.txtInputSN_In.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtInputSN_In.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtInputSN_In.Location = new global::System.Drawing.Point(39, 43);
			this.txtInputSN_In.Name = "txtInputSN_In";
			this.txtInputSN_In.Size = new global::System.Drawing.Size(313, 23);
			this.txtInputSN_In.TabIndex = 100;
			this.txtInputSN_In.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtSN_KeyPress);
			this.label16.AutoSize = true;
			this.label16.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.label16.Location = new global::System.Drawing.Point(11, 46);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(22, 15);
			this.label16.TabIndex = 101;
			this.label16.Text = "SN";
			this.panel7.Controls.Add(this.groupBox4);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new global::System.Drawing.Point(3, 3);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(2);
			this.panel7.Size = new global::System.Drawing.Size(1170, 51);
			this.panel7.TabIndex = 87;
			this.groupBox4.Controls.Add(this.label31);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Font = new global::System.Drawing.Font("Segoe UI", 1f);
			this.groupBox4.Location = new global::System.Drawing.Point(2, 2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(1166, 47);
			this.groupBox4.TabIndex = 66;
			this.groupBox4.TabStop = false;
			this.label31.AutoSize = true;
			this.label31.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label31.ForeColor = global::System.Drawing.Color.Blue;
			this.label31.Location = new global::System.Drawing.Point(10, 13);
			this.label31.Name = "label31";
			this.label31.Size = new global::System.Drawing.Size(66, 21);
			this.label31.TabIndex = 60;
			this.label31.Text = "Request";
			this.tabFA_UnitList.Controls.Add(this.panel4);
			this.tabFA_UnitList.Controls.Add(this.panel2);
			this.tabFA_UnitList.Location = new global::System.Drawing.Point(4, 24);
			this.tabFA_UnitList.Name = "tabFA_UnitList";
			this.tabFA_UnitList.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabFA_UnitList.Size = new global::System.Drawing.Size(1176, 671);
			this.tabFA_UnitList.TabIndex = 1;
			this.tabFA_UnitList.Text = "FA Unit List";
			this.tabFA_UnitList.UseVisualStyleBackColor = true;
			this.panel4.Controls.Add(this.groupBox3);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(3, 83);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel4.Size = new global::System.Drawing.Size(1170, 587);
			this.panel4.TabIndex = 14;
			this.groupBox3.Controls.Add(this.gridUnitList);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(1164, 581);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "FA List";
			this.gridUnitList.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.gridUnitList.Controls.Add(this.label5);
			this.gridUnitList.Controls.Add(this.cmbUnitStationId);
			this.gridUnitList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridUnitList.EnableSort = true;
			this.gridUnitList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridUnitList.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridUnitList.Location = new global::System.Drawing.Point(3, 19);
			this.gridUnitList.Name = "gridUnitList";
			this.gridUnitList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridUnitList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridUnitList.Size = new global::System.Drawing.Size(1158, 559);
			this.gridUnitList.TabIndex = 0;
			this.gridUnitList.TabStop = true;
			this.gridUnitList.ToolTipText = "";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label5.Location = new global::System.Drawing.Point(106, 60);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(58, 15);
			this.label5.TabIndex = 110;
			this.label5.Text = "Station ID";
			this.label5.Visible = false;
			this.cmbUnitStationId.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbUnitStationId.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbUnitStationId.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbUnitStationId.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbUnitStationId.FormattingEnabled = true;
			this.cmbUnitStationId.Location = new global::System.Drawing.Point(170, 57);
			this.cmbUnitStationId.Name = "cmbUnitStationId";
			this.cmbUnitStationId.Size = new global::System.Drawing.Size(215, 23);
			this.cmbUnitStationId.TabIndex = 109;
			this.cmbUnitStationId.Visible = false;
			this.cmbUnitStationId.DropDown += new global::System.EventHandler(this.cmbUnitStationId_DropDown);
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(2);
			this.panel2.Size = new global::System.Drawing.Size(1170, 80);
			this.panel2.TabIndex = 13;
			this.groupBox2.Controls.Add(this.cbAll);
			this.groupBox2.Controls.Add(this.tbDcc);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.tbConfig);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.groupBox5);
			this.groupBox2.Controls.Add(this.groupBox22);
			this.groupBox2.Controls.Add(this.groupBox21);
			this.groupBox2.Controls.Add(this.label26);
			this.groupBox2.Controls.Add(this.cmbType);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label35);
			this.groupBox2.Controls.Add(this.cmbUnitStation);
			this.groupBox2.Controls.Add(this.cmbUnitProduct);
			this.groupBox2.Controls.Add(this.groupBox7);
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Controls.Add(this.txtUnitSN);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.groupBox11);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new global::System.Drawing.Point(2, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 6, 3, 3);
			this.groupBox2.Size = new global::System.Drawing.Size(1166, 76);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Search";
			this.cbAll.AutoSize = true;
			this.cbAll.Location = new global::System.Drawing.Point(755, 44);
			this.cbAll.Name = "cbAll";
			this.cbAll.Size = new global::System.Drawing.Size(76, 19);
			this.cbAll.TabIndex = 15;
			this.cbAll.Text = "All Check";
			this.cbAll.UseVisualStyleBackColor = true;
			this.cbAll.CheckedChanged += new global::System.EventHandler(this.cbAll_CheckedChanged);
			this.tbDcc.Location = new global::System.Drawing.Point(638, 41);
			this.tbDcc.Name = "tbDcc";
			this.tbDcc.Size = new global::System.Drawing.Size(96, 23);
			this.tbDcc.TabIndex = 119;
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(606, 46);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(27, 15);
			this.label6.TabIndex = 118;
			this.label6.Text = "Dcc";
			this.tbConfig.Location = new global::System.Drawing.Point(365, 42);
			this.tbConfig.Name = "tbConfig";
			this.tbConfig.Size = new global::System.Drawing.Size(220, 23);
			this.tbConfig.TabIndex = 117;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(316, 47);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(43, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Config";
			this.groupBox5.Controls.Add(this.pbComment);
			this.groupBox5.Location = new global::System.Drawing.Point(1102, 12);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(75, 61);
			this.groupBox5.TabIndex = 116;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Comment";
			this.pbComment.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbComment.Image");
			this.pbComment.Location = new global::System.Drawing.Point(22, 19);
			this.pbComment.Name = "pbComment";
			this.pbComment.Size = new global::System.Drawing.Size(32, 32);
			this.pbComment.TabIndex = 104;
			this.pbComment.TabStop = false;
			this.pbComment.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.pbComment.MouseLeave += new global::System.EventHandler(this.pbComment_MouseLeave);
			this.pbComment.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pbComment_MouseMove);
			this.groupBox22.Controls.Add(this.pictureBox2);
			this.groupBox22.Location = new global::System.Drawing.Point(1024, 12);
			this.groupBox22.Name = "groupBox22";
			this.groupBox22.Size = new global::System.Drawing.Size(74, 61);
			this.groupBox22.TabIndex = 114;
			this.groupBox22.TabStop = false;
			this.groupBox22.Text = "CheckOut";
			this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new global::System.Drawing.Point(21, 19);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(32, 32);
			this.pictureBox2.TabIndex = 104;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
			this.pictureBox2.MouseLeave += new global::System.EventHandler(this.cmdApply_MouseLeave);
			this.pictureBox2.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseMove);
			this.groupBox21.Controls.Add(this.pbCheckIn);
			this.groupBox21.Location = new global::System.Drawing.Point(954, 12);
			this.groupBox21.Name = "groupBox21";
			this.groupBox21.Size = new global::System.Drawing.Size(67, 61);
			this.groupBox21.TabIndex = 115;
			this.groupBox21.TabStop = false;
			this.groupBox21.Text = "CheckIn";
			this.pbCheckIn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbCheckIn.Image");
			this.pbCheckIn.Location = new global::System.Drawing.Point(18, 19);
			this.pbCheckIn.Name = "pbCheckIn";
			this.pbCheckIn.Size = new global::System.Drawing.Size(32, 32);
			this.pbCheckIn.TabIndex = 104;
			this.pbCheckIn.TabStop = false;
			this.pbCheckIn.Click += new global::System.EventHandler(this.pbCheckIn_Click);
			this.pbCheckIn.MouseLeave += new global::System.EventHandler(this.cmdApply_MouseLeave);
			this.pbCheckIn.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseMove);
			this.label26.AutoSize = true;
			this.label26.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label26.Location = new global::System.Drawing.Point(11, 17);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(31, 15);
			this.label26.TabIndex = 112;
			this.label26.Text = "Type";
			this.cmbType.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbType.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Location = new global::System.Drawing.Point(75, 14);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new global::System.Drawing.Size(90, 23);
			this.cmbType.TabIndex = 111;
			this.cmbType.DropDown += new global::System.EventHandler(this.cmbType_DropDown);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label4.Location = new global::System.Drawing.Point(360, 17);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(44, 15);
			this.label4.TabIndex = 108;
			this.label4.Text = "Station";
			this.label4.Visible = false;
			this.label35.AutoSize = true;
			this.label35.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label35.Location = new global::System.Drawing.Point(171, 17);
			this.label35.Name = "label35";
			this.label35.Size = new global::System.Drawing.Size(49, 15);
			this.label35.TabIndex = 106;
			this.label35.Text = "Product";
			this.label35.Visible = false;
			this.cmbUnitStation.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbUnitStation.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbUnitStation.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbUnitStation.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbUnitStation.FormattingEnabled = true;
			this.cmbUnitStation.Location = new global::System.Drawing.Point(410, 14);
			this.cmbUnitStation.Name = "cmbUnitStation";
			this.cmbUnitStation.Size = new global::System.Drawing.Size(204, 23);
			this.cmbUnitStation.TabIndex = 107;
			this.cmbUnitStation.Visible = false;
			this.cmbUnitStation.DropDown += new global::System.EventHandler(this.cmbUnitStation_DropDown);
			this.cmbUnitProduct.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbUnitProduct.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbUnitProduct.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbUnitProduct.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbUnitProduct.FormattingEnabled = true;
			this.cmbUnitProduct.Location = new global::System.Drawing.Point(226, 14);
			this.cmbUnitProduct.Name = "cmbUnitProduct";
			this.cmbUnitProduct.Size = new global::System.Drawing.Size(128, 23);
			this.cmbUnitProduct.TabIndex = 105;
			this.cmbUnitProduct.Visible = false;
			this.cmbUnitProduct.DropDown += new global::System.EventHandler(this.cmbUnitProduct_DropDown);
			this.groupBox7.Controls.Add(this.cmdUnitExcel);
			this.groupBox7.Location = new global::System.Drawing.Point(1183, 11);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox7.TabIndex = 103;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Excel";
			this.cmdUnitExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdUnitExcel.Image");
			this.cmdUnitExcel.Location = new global::System.Drawing.Point(12, 19);
			this.cmdUnitExcel.Name = "cmdUnitExcel";
			this.cmdUnitExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUnitExcel.TabIndex = 103;
			this.cmdUnitExcel.TabStop = false;
			this.cmdUnitExcel.Click += new global::System.EventHandler(this.cmdUnitExcel_Click);
			this.groupBox1.Controls.Add(this.cmdUnitSearch);
			this.groupBox1.Location = new global::System.Drawing.Point(887, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.cmdUnitSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdUnitSearch.Image");
			this.cmdUnitSearch.Location = new global::System.Drawing.Point(14, 19);
			this.cmdUnitSearch.Name = "cmdUnitSearch";
			this.cmdUnitSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUnitSearch.TabIndex = 102;
			this.cmdUnitSearch.TabStop = false;
			this.cmdUnitSearch.Click += new global::System.EventHandler(this.cmdUnitSearch_Click);
			this.txtUnitSN.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtUnitSN.Location = new global::System.Drawing.Point(75, 43);
			this.txtUnitSN.Name = "txtUnitSN";
			this.txtUnitSN.Size = new global::System.Drawing.Size(230, 23);
			this.txtUnitSN.TabIndex = 100;
			this.txtUnitSN.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtUnitSN_KeyPress);
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.label1.Location = new global::System.Drawing.Point(11, 46);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(22, 15);
			this.label1.TabIndex = 101;
			this.label1.Text = "SN";
			this.groupBox11.Controls.Add(this.label3);
			this.groupBox11.Controls.Add(this.dtp_End_Histroy);
			this.groupBox11.Controls.Add(this.dtp_Start_History);
			this.groupBox11.Location = new global::System.Drawing.Point(825, 15);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new global::System.Drawing.Size(251, 61);
			this.groupBox11.TabIndex = 104;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Period";
			this.groupBox11.Visible = false;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(118, 28);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(15, 15);
			this.label3.TabIndex = 92;
			this.label3.Text = "~";
			this.dtp_End_Histroy.CustomFormat = "yyyy-MM-dd";
			this.dtp_End_Histroy.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_End_Histroy.Location = new global::System.Drawing.Point(139, 24);
			this.dtp_End_Histroy.Name = "dtp_End_Histroy";
			this.dtp_End_Histroy.Size = new global::System.Drawing.Size(100, 23);
			this.dtp_End_Histroy.TabIndex = 84;
			this.dtp_Start_History.CustomFormat = "yyyy-MM-dd";
			this.dtp_Start_History.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_Start_History.Location = new global::System.Drawing.Point(12, 24);
			this.dtp_Start_History.Name = "dtp_Start_History";
			this.dtp_Start_History.Size = new global::System.Drawing.Size(100, 23);
			this.dtp_Start_History.TabIndex = 85;
			this.tab_BT_Monitoring.Controls.Add(this.panel14);
			this.tab_BT_Monitoring.Controls.Add(this.panel13);
			this.tab_BT_Monitoring.Location = new global::System.Drawing.Point(4, 24);
			this.tab_BT_Monitoring.Name = "tab_BT_Monitoring";
			this.tab_BT_Monitoring.Size = new global::System.Drawing.Size(1176, 671);
			this.tab_BT_Monitoring.TabIndex = 5;
			this.tab_BT_Monitoring.Text = "BT-OQC Monitoring";
			this.tab_BT_Monitoring.UseVisualStyleBackColor = true;
			this.panel14.Controls.Add(this.groupBox23);
			this.panel14.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel14.Location = new global::System.Drawing.Point(0, 77);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel14.Size = new global::System.Drawing.Size(1176, 596);
			this.panel14.TabIndex = 19;
			this.groupBox23.Controls.Add(this.gridBTMonitoring);
			this.groupBox23.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox23.Font = new global::System.Drawing.Font("Segoe UI", 1.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox23.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox23.Name = "groupBox23";
			this.groupBox23.Size = new global::System.Drawing.Size(1170, 590);
			this.groupBox23.TabIndex = 117;
			this.groupBox23.TabStop = false;
			this.gridBTMonitoring.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.gridBTMonitoring.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridBTMonitoring.EnableSort = true;
			this.gridBTMonitoring.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridBTMonitoring.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridBTMonitoring.Location = new global::System.Drawing.Point(3, 6);
			this.gridBTMonitoring.Name = "gridBTMonitoring";
			this.gridBTMonitoring.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridBTMonitoring.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridBTMonitoring.Size = new global::System.Drawing.Size(1164, 581);
			this.gridBTMonitoring.TabIndex = 116;
			this.gridBTMonitoring.TabStop = true;
			this.gridBTMonitoring.ToolTipText = "";
			this.panel13.Controls.Add(this.groupBox12);
			this.panel13.Controls.Add(this.groupBox25);
			this.panel13.Controls.Add(this.groupBox24);
			this.panel13.Controls.Add(this.groupBox13);
			this.panel13.Controls.Add(this.groupBox15);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel13.Location = new global::System.Drawing.Point(0, 0);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel13.Size = new global::System.Drawing.Size(1176, 77);
			this.panel13.TabIndex = 18;
			this.groupBox12.Controls.Add(this.label19);
			this.groupBox12.Controls.Add(this.chkcmbATETester);
			this.groupBox12.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox12.Location = new global::System.Drawing.Point(332, 3);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new global::System.Drawing.Size(204, 71);
			this.groupBox12.TabIndex = 4;
			this.groupBox12.TabStop = false;
			this.label19.AutoSize = true;
			this.label19.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label19.Location = new global::System.Drawing.Point(10, 29);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(37, 15);
			this.label19.TabIndex = 117;
			this.label19.Text = "Tester";
			this.groupBox25.Controls.Add(this.rdo_BT_Month);
			this.groupBox25.Controls.Add(this.rdo_BT_SelectedDate);
			this.groupBox25.Controls.Add(this.dateTime_Month);
			this.groupBox25.Controls.Add(this.label24);
			this.groupBox25.Controls.Add(this.chkcmb_BTOQCDate);
			this.groupBox25.Controls.Add(this.BT_Date_End);
			this.groupBox25.Controls.Add(this.label20);
			this.groupBox25.Controls.Add(this.BT_Date_Start);
			this.groupBox25.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox25.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox25.Name = "groupBox25";
			this.groupBox25.Size = new global::System.Drawing.Size(329, 71);
			this.groupBox25.TabIndex = 5;
			this.groupBox25.TabStop = false;
			this.groupBox25.Text = "Date";
			this.rdo_BT_Month.AutoSize = true;
			this.rdo_BT_Month.Location = new global::System.Drawing.Point(9, 44);
			this.rdo_BT_Month.Name = "rdo_BT_Month";
			this.rdo_BT_Month.Size = new global::System.Drawing.Size(61, 19);
			this.rdo_BT_Month.TabIndex = 124;
			this.rdo_BT_Month.Text = "Month";
			this.rdo_BT_Month.UseVisualStyleBackColor = true;
			this.rdo_BT_Month.CheckedChanged += new global::System.EventHandler(this.rdo_BT_Month_CheckedChanged);
			this.rdo_BT_SelectedDate.AutoSize = true;
			this.rdo_BT_SelectedDate.Checked = true;
			this.rdo_BT_SelectedDate.Location = new global::System.Drawing.Point(9, 16);
			this.rdo_BT_SelectedDate.Name = "rdo_BT_SelectedDate";
			this.rdo_BT_SelectedDate.Size = new global::System.Drawing.Size(96, 19);
			this.rdo_BT_SelectedDate.TabIndex = 123;
			this.rdo_BT_SelectedDate.TabStop = true;
			this.rdo_BT_SelectedDate.Text = "Selected Date";
			this.rdo_BT_SelectedDate.UseVisualStyleBackColor = true;
			this.rdo_BT_SelectedDate.CheckedChanged += new global::System.EventHandler(this.rdo_BT_SelectedDate_CheckedChanged);
			this.dateTime_Month.CustomFormat = "yyyy-MM";
			this.dateTime_Month.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTime_Month.Location = new global::System.Drawing.Point(111, 43);
			this.dateTime_Month.Name = "dateTime_Month";
			this.dateTime_Month.ShowUpDown = true;
			this.dateTime_Month.Size = new global::System.Drawing.Size(70, 23);
			this.dateTime_Month.TabIndex = 107;
			this.label24.AutoSize = true;
			this.label24.Location = new global::System.Drawing.Point(209, 18);
			this.label24.Name = "label24";
			this.label24.Size = new global::System.Drawing.Size(15, 15);
			this.label24.TabIndex = 122;
			this.label24.Text = "~";
			this.BT_Date_End.CustomFormat = "yyyy-MM-dd";
			this.BT_Date_End.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.BT_Date_End.Location = new global::System.Drawing.Point(227, 14);
			this.BT_Date_End.Name = "BT_Date_End";
			this.BT_Date_End.Size = new global::System.Drawing.Size(95, 23);
			this.BT_Date_End.TabIndex = 120;
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label20.Location = new global::System.Drawing.Point(193, 46);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(31, 15);
			this.label20.TabIndex = 119;
			this.label20.Text = "Date";
			this.BT_Date_Start.CustomFormat = "yyyy-MM-dd";
			this.BT_Date_Start.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.BT_Date_Start.Location = new global::System.Drawing.Point(111, 14);
			this.BT_Date_Start.Name = "BT_Date_Start";
			this.BT_Date_Start.Size = new global::System.Drawing.Size(95, 23);
			this.BT_Date_Start.TabIndex = 121;
			this.groupBox24.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox24.Controls.Add(this.cmd_RawData_Excel);
			this.groupBox24.Location = new global::System.Drawing.Point(684, 10);
			this.groupBox24.Name = "groupBox24";
			this.groupBox24.Size = new global::System.Drawing.Size(67, 61);
			this.groupBox24.TabIndex = 108;
			this.groupBox24.TabStop = false;
			this.groupBox24.Text = "RawData";
			this.groupBox24.Visible = false;
			this.cmd_RawData_Excel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_RawData_Excel.Image");
			this.cmd_RawData_Excel.Location = new global::System.Drawing.Point(17, 19);
			this.cmd_RawData_Excel.Name = "cmd_RawData_Excel";
			this.cmd_RawData_Excel.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_RawData_Excel.TabIndex = 103;
			this.cmd_RawData_Excel.TabStop = false;
			this.cmd_RawData_Excel.Click += new global::System.EventHandler(this.cmd_RawData_Excel_Click);
			this.groupBox13.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox13.Controls.Add(this.cmd_BTOQC_Search);
			this.groupBox13.Location = new global::System.Drawing.Point(555, 10);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox13.TabIndex = 4;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Search";
			this.cmd_BTOQC_Search.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_BTOQC_Search.Image");
			this.cmd_BTOQC_Search.Location = new global::System.Drawing.Point(14, 19);
			this.cmd_BTOQC_Search.Name = "cmd_BTOQC_Search";
			this.cmd_BTOQC_Search.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_BTOQC_Search.TabIndex = 102;
			this.cmd_BTOQC_Search.TabStop = false;
			this.cmd_BTOQC_Search.Click += new global::System.EventHandler(this.cmd_BTOQC_Search_Click);
			this.groupBox15.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox15.Controls.Add(this.cmd_BTOQC_Excel);
			this.groupBox15.Location = new global::System.Drawing.Point(623, 10);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox15.TabIndex = 103;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Excel";
			this.cmd_BTOQC_Excel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_BTOQC_Excel.Image");
			this.cmd_BTOQC_Excel.Location = new global::System.Drawing.Point(12, 19);
			this.cmd_BTOQC_Excel.Name = "cmd_BTOQC_Excel";
			this.cmd_BTOQC_Excel.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_BTOQC_Excel.TabIndex = 103;
			this.cmd_BTOQC_Excel.TabStop = false;
			this.cmd_BTOQC_Excel.Click += new global::System.EventHandler(this.cmd_BTOQC_Excel_Click);
			this.tab_UploadUnit.Controls.Add(this.panel17);
			this.tab_UploadUnit.Location = new global::System.Drawing.Point(4, 24);
			this.tab_UploadUnit.Name = "tab_UploadUnit";
			this.tab_UploadUnit.Size = new global::System.Drawing.Size(1176, 671);
			this.tab_UploadUnit.TabIndex = 6;
			this.tab_UploadUnit.Text = "Upload Unit ";
			this.tab_UploadUnit.UseVisualStyleBackColor = true;
			this.panel17.Controls.Add(this.panel20);
			this.panel17.Controls.Add(this.splitter3);
			this.panel17.Controls.Add(this.panel18);
			this.panel17.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel17.Location = new global::System.Drawing.Point(0, 0);
			this.panel17.Name = "panel17";
			this.panel17.Size = new global::System.Drawing.Size(1176, 673);
			this.panel17.TabIndex = 19;
			this.panel20.Controls.Add(this.panel21);
			this.panel20.Controls.Add(this.panel16);
			this.panel20.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel20.Location = new global::System.Drawing.Point(643, 0);
			this.panel20.Name = "panel20";
			this.panel20.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel20.Size = new global::System.Drawing.Size(533, 673);
			this.panel20.TabIndex = 122;
			this.panel21.Controls.Add(this.groupBox33);
			this.panel21.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel21.Location = new global::System.Drawing.Point(3, 80);
			this.panel21.Name = "panel21";
			this.panel21.Padding = new global::System.Windows.Forms.Padding(0, 5, 0, 0);
			this.panel21.Size = new global::System.Drawing.Size(527, 590);
			this.panel21.TabIndex = 127;
			this.groupBox33.Controls.Add(this.grid_SNList);
			this.groupBox33.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox33.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox33.Location = new global::System.Drawing.Point(0, 5);
			this.groupBox33.Name = "groupBox33";
			this.groupBox33.Size = new global::System.Drawing.Size(527, 585);
			this.groupBox33.TabIndex = 117;
			this.groupBox33.TabStop = false;
			this.groupBox33.Text = "Upload SN";
			this.grid_SNList.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.grid_SNList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_SNList.EnableSort = true;
			this.grid_SNList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.grid_SNList.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.grid_SNList.Location = new global::System.Drawing.Point(3, 19);
			this.grid_SNList.Name = "grid_SNList";
			this.grid_SNList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_SNList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_SNList.Size = new global::System.Drawing.Size(521, 563);
			this.grid_SNList.TabIndex = 116;
			this.grid_SNList.TabStop = true;
			this.grid_SNList.ToolTipText = "";
			this.panel16.Controls.Add(this.groupBox26);
			this.panel16.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel16.Location = new global::System.Drawing.Point(3, 3);
			this.panel16.Name = "panel16";
			this.panel16.Padding = new global::System.Windows.Forms.Padding(0, 3, 0, 0);
			this.panel16.Size = new global::System.Drawing.Size(527, 77);
			this.panel16.TabIndex = 18;
			this.groupBox26.Controls.Add(this.label29);
			this.groupBox26.Controls.Add(this.txtOperation);
			this.groupBox26.Controls.Add(this.label25);
			this.groupBox26.Controls.Add(this.txtDcc);
			this.groupBox26.Controls.Add(this.groupBox31);
			this.groupBox26.Controls.Add(this.grpUpload);
			this.groupBox26.Controls.Add(this.label7);
			this.groupBox26.Controls.Add(this.txtUploadLot);
			this.groupBox26.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox26.Location = new global::System.Drawing.Point(0, 3);
			this.groupBox26.Name = "groupBox26";
			this.groupBox26.Size = new global::System.Drawing.Size(527, 74);
			this.groupBox26.TabIndex = 4;
			this.groupBox26.TabStop = false;
			this.groupBox26.Text = "Upload Info";
			this.label29.AutoSize = true;
			this.label29.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label29.Location = new global::System.Drawing.Point(364, 32);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(60, 15);
			this.label29.TabIndex = 129;
			this.label29.Text = "Operation";
			this.txtOperation.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtOperation.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtOperation.Location = new global::System.Drawing.Point(430, 29);
			this.txtOperation.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtOperation.Name = "txtOperation";
			this.txtOperation.Size = new global::System.Drawing.Size(79, 23);
			this.txtOperation.TabIndex = 128;
			this.label25.AutoSize = true;
			this.label25.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label25.Location = new global::System.Drawing.Point(238, 33);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(31, 15);
			this.label25.TabIndex = 127;
			this.label25.Text = "DCC";
			this.txtDcc.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtDcc.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtDcc.Location = new global::System.Drawing.Point(275, 30);
			this.txtDcc.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtDcc.Name = "txtDcc";
			this.txtDcc.Size = new global::System.Drawing.Size(82, 23);
			this.txtDcc.TabIndex = 126;
			this.groupBox31.Controls.Add(this.cmd_UploadApply);
			this.groupBox31.Location = new global::System.Drawing.Point(580, 10);
			this.groupBox31.Name = "groupBox31";
			this.groupBox31.Size = new global::System.Drawing.Size(53, 61);
			this.groupBox31.TabIndex = 125;
			this.groupBox31.TabStop = false;
			this.groupBox31.Text = "Apply";
			this.cmd_UploadApply.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_UploadApply.Image");
			this.cmd_UploadApply.Location = new global::System.Drawing.Point(10, 20);
			this.cmd_UploadApply.Name = "cmd_UploadApply";
			this.cmd_UploadApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_UploadApply.TabIndex = 104;
			this.cmd_UploadApply.TabStop = false;
			this.cmd_UploadApply.Click += new global::System.EventHandler(this.cmd_Apply_Click);
			this.grpUpload.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.grpUpload.Controls.Add(this.cmd_Upload_Data);
			this.grpUpload.Location = new global::System.Drawing.Point(515, 10);
			this.grpUpload.Name = "grpUpload";
			this.grpUpload.Size = new global::System.Drawing.Size(59, 61);
			this.grpUpload.TabIndex = 117;
			this.grpUpload.TabStop = false;
			this.grpUpload.Text = "Upload";
			this.cmd_Upload_Data.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmd_Upload_Data.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_Upload_Data.Image");
			this.cmd_Upload_Data.Location = new global::System.Drawing.Point(13, 20);
			this.cmd_Upload_Data.Name = "cmd_Upload_Data";
			this.cmd_Upload_Data.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_Upload_Data.TabIndex = 104;
			this.cmd_Upload_Data.TabStop = false;
			this.cmd_Upload_Data.Click += new global::System.EventHandler(this.cmd_Upload_Data_Click);
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label7.Location = new global::System.Drawing.Point(9, 33);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(24, 15);
			this.label7.TabIndex = 116;
			this.label7.Text = "Lot";
			this.txtUploadLot.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtUploadLot.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtUploadLot.Location = new global::System.Drawing.Point(39, 29);
			this.txtUploadLot.Name = "txtUploadLot";
			this.txtUploadLot.Size = new global::System.Drawing.Size(192, 23);
			this.txtUploadLot.TabIndex = 104;
			this.splitter3.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter3.Location = new global::System.Drawing.Point(638, 0);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new global::System.Drawing.Size(5, 673);
			this.splitter3.TabIndex = 121;
			this.splitter3.TabStop = false;
			this.panel18.Controls.Add(this.panel22);
			this.panel18.Controls.Add(this.splitter4);
			this.panel18.Controls.Add(this.panel19);
			this.panel18.Controls.Add(this.groupBox32);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel18.Location = new global::System.Drawing.Point(0, 0);
			this.panel18.Name = "panel18";
			this.panel18.Padding = new global::System.Windows.Forms.Padding(2);
			this.panel18.Size = new global::System.Drawing.Size(638, 673);
			this.panel18.TabIndex = 123;
			this.panel22.Controls.Add(this.groupBox30);
			this.panel22.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel22.Location = new global::System.Drawing.Point(274, 80);
			this.panel22.Name = "panel22";
			this.panel22.Padding = new global::System.Windows.Forms.Padding(0, 5, 0, 0);
			this.panel22.Size = new global::System.Drawing.Size(362, 591);
			this.panel22.TabIndex = 126;
			this.groupBox30.Controls.Add(this.gridUploadSNList);
			this.groupBox30.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox30.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox30.Location = new global::System.Drawing.Point(0, 5);
			this.groupBox30.Name = "groupBox30";
			this.groupBox30.Size = new global::System.Drawing.Size(362, 586);
			this.groupBox30.TabIndex = 117;
			this.groupBox30.TabStop = false;
			this.groupBox30.Text = "SN";
			this.gridUploadSNList.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.gridUploadSNList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridUploadSNList.EnableSort = true;
			this.gridUploadSNList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridUploadSNList.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridUploadSNList.Location = new global::System.Drawing.Point(3, 19);
			this.gridUploadSNList.Name = "gridUploadSNList";
			this.gridUploadSNList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridUploadSNList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridUploadSNList.Size = new global::System.Drawing.Size(356, 564);
			this.gridUploadSNList.TabIndex = 116;
			this.gridUploadSNList.TabStop = true;
			this.gridUploadSNList.ToolTipText = "";
			this.splitter4.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter4.Location = new global::System.Drawing.Point(269, 80);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new global::System.Drawing.Size(5, 591);
			this.splitter4.TabIndex = 125;
			this.splitter4.TabStop = false;
			this.panel19.Controls.Add(this.groupBox29);
			this.panel19.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel19.Location = new global::System.Drawing.Point(2, 80);
			this.panel19.Name = "panel19";
			this.panel19.Padding = new global::System.Windows.Forms.Padding(0, 5, 0, 0);
			this.panel19.Size = new global::System.Drawing.Size(267, 591);
			this.panel19.TabIndex = 119;
			this.groupBox29.Controls.Add(this.gridUploadLot);
			this.groupBox29.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox29.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox29.Location = new global::System.Drawing.Point(0, 5);
			this.groupBox29.Name = "groupBox29";
			this.groupBox29.Size = new global::System.Drawing.Size(267, 586);
			this.groupBox29.TabIndex = 116;
			this.groupBox29.TabStop = false;
			this.groupBox29.Text = "Lot";
			this.gridUploadLot.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.gridUploadLot.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridUploadLot.EnableSort = true;
			this.gridUploadLot.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridUploadLot.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridUploadLot.Location = new global::System.Drawing.Point(3, 19);
			this.gridUploadLot.Name = "gridUploadLot";
			this.gridUploadLot.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridUploadLot.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridUploadLot.Size = new global::System.Drawing.Size(261, 564);
			this.gridUploadLot.TabIndex = 116;
			this.gridUploadLot.TabStop = true;
			this.gridUploadLot.ToolTipText = "";
			this.groupBox32.Controls.Add(this.groupBox34);
			this.groupBox32.Controls.Add(this.label32);
			this.groupBox32.Controls.Add(this.textBox1);
			this.groupBox32.Controls.Add(this.rdo_SearchUploadSN);
			this.groupBox32.Controls.Add(this.rdo_SearchUploadLot);
			this.groupBox32.Controls.Add(this.txtSearchUploadSN);
			this.groupBox32.Controls.Add(this.groupBox27);
			this.groupBox32.Controls.Add(this.txtSearchUploadLot);
			this.groupBox32.Controls.Add(this.groupBox28);
			this.groupBox32.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox32.Location = new global::System.Drawing.Point(2, 2);
			this.groupBox32.Name = "groupBox32";
			this.groupBox32.Padding = new global::System.Windows.Forms.Padding(3, 6, 3, 3);
			this.groupBox32.Size = new global::System.Drawing.Size(634, 78);
			this.groupBox32.TabIndex = 1;
			this.groupBox32.TabStop = false;
			this.groupBox32.Text = "Search";
			this.groupBox34.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox34.Controls.Add(this.cmd_UploadDelete);
			this.groupBox34.Location = new global::System.Drawing.Point(359, 14);
			this.groupBox34.Name = "groupBox34";
			this.groupBox34.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox34.TabIndex = 130;
			this.groupBox34.TabStop = false;
			this.groupBox34.Text = "Delete";
			this.cmd_UploadDelete.Image = global::Amkor.CADModules.ESIModule.Properties.Resources.TableRemove;
			this.cmd_UploadDelete.Location = new global::System.Drawing.Point(12, 19);
			this.cmd_UploadDelete.Name = "cmd_UploadDelete";
			this.cmd_UploadDelete.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_UploadDelete.TabIndex = 103;
			this.cmd_UploadDelete.TabStop = false;
			this.cmd_UploadDelete.Click += new global::System.EventHandler(this.cmd_UploadDelete_Click);
			this.label32.AutoSize = true;
			this.label32.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label32.Location = new global::System.Drawing.Point(487, 46);
			this.label32.Name = "label32";
			this.label32.Size = new global::System.Drawing.Size(31, 15);
			this.label32.TabIndex = 129;
			this.label32.Text = "DCC";
			this.label32.Visible = false;
			this.textBox1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.textBox1.Location = new global::System.Drawing.Point(524, 43);
			this.textBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(82, 23);
			this.textBox1.TabIndex = 128;
			this.textBox1.Visible = false;
			this.rdo_SearchUploadSN.AutoSize = true;
			this.rdo_SearchUploadSN.Location = new global::System.Drawing.Point(15, 50);
			this.rdo_SearchUploadSN.Name = "rdo_SearchUploadSN";
			this.rdo_SearchUploadSN.Size = new global::System.Drawing.Size(40, 19);
			this.rdo_SearchUploadSN.TabIndex = 126;
			this.rdo_SearchUploadSN.Text = "SN";
			this.rdo_SearchUploadSN.UseVisualStyleBackColor = true;
			this.rdo_SearchUploadLot.AutoSize = true;
			this.rdo_SearchUploadLot.Checked = true;
			this.rdo_SearchUploadLot.Location = new global::System.Drawing.Point(15, 22);
			this.rdo_SearchUploadLot.Name = "rdo_SearchUploadLot";
			this.rdo_SearchUploadLot.Size = new global::System.Drawing.Size(42, 19);
			this.rdo_SearchUploadLot.TabIndex = 125;
			this.rdo_SearchUploadLot.TabStop = true;
			this.rdo_SearchUploadLot.Text = "Lot";
			this.rdo_SearchUploadLot.UseVisualStyleBackColor = true;
			this.txtSearchUploadSN.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtSearchUploadSN.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtSearchUploadSN.Location = new global::System.Drawing.Point(63, 49);
			this.txtSearchUploadSN.Name = "txtSearchUploadSN";
			this.txtSearchUploadSN.Size = new global::System.Drawing.Size(222, 23);
			this.txtSearchUploadSN.TabIndex = 119;
			this.groupBox27.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox27.Controls.Add(this.cmd_UploadSearch);
			this.groupBox27.Location = new global::System.Drawing.Point(291, 14);
			this.groupBox27.Name = "groupBox27";
			this.groupBox27.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox27.TabIndex = 118;
			this.groupBox27.TabStop = false;
			this.groupBox27.Text = "Search";
			this.cmd_UploadSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_UploadSearch.Image");
			this.cmd_UploadSearch.Location = new global::System.Drawing.Point(15, 19);
			this.cmd_UploadSearch.Name = "cmd_UploadSearch";
			this.cmd_UploadSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_UploadSearch.TabIndex = 102;
			this.cmd_UploadSearch.TabStop = false;
			this.cmd_UploadSearch.Click += new global::System.EventHandler(this.cmdUploadSearch_Click);
			this.txtSearchUploadLot.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtSearchUploadLot.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtSearchUploadLot.Location = new global::System.Drawing.Point(63, 21);
			this.txtSearchUploadLot.Name = "txtSearchUploadLot";
			this.txtSearchUploadLot.Size = new global::System.Drawing.Size(222, 23);
			this.txtSearchUploadLot.TabIndex = 100;
			this.groupBox28.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox28.Controls.Add(this.cmd_Download_Data);
			this.groupBox28.Location = new global::System.Drawing.Point(420, 14);
			this.groupBox28.Name = "groupBox28";
			this.groupBox28.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox28.TabIndex = 103;
			this.groupBox28.TabStop = false;
			this.groupBox28.Text = "Excel";
			this.cmd_Download_Data.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_Download_Data.Image");
			this.cmd_Download_Data.Location = new global::System.Drawing.Point(12, 19);
			this.cmd_Download_Data.Name = "cmd_Download_Data";
			this.cmd_Download_Data.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_Download_Data.TabIndex = 103;
			this.cmd_Download_Data.TabStop = false;
			this.cmd_Download_Data.Click += new global::System.EventHandler(this.cmd_Download_Data_Click);
			this.tab_CheckSummary.Controls.Add(this.panel24);
			this.tab_CheckSummary.Controls.Add(this.panel23);
			this.tab_CheckSummary.Location = new global::System.Drawing.Point(4, 24);
			this.tab_CheckSummary.Name = "tab_CheckSummary";
			this.tab_CheckSummary.Size = new global::System.Drawing.Size(1176, 671);
			this.tab_CheckSummary.TabIndex = 7;
			this.tab_CheckSummary.Text = "Daily Setup Check Summary";
			this.tab_CheckSummary.UseVisualStyleBackColor = true;
			this.panel24.Controls.Add(this.groupBox41);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel24.Location = new global::System.Drawing.Point(0, 77);
			this.panel24.Name = "panel24";
			this.panel24.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel24.Size = new global::System.Drawing.Size(1176, 594);
			this.panel24.TabIndex = 20;
			this.groupBox41.Controls.Add(this.gridCheckSummary);
			this.groupBox41.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox41.Font = new global::System.Drawing.Font("Segoe UI", 1.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox41.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox41.Name = "groupBox41";
			this.groupBox41.Size = new global::System.Drawing.Size(1170, 588);
			this.groupBox41.TabIndex = 117;
			this.groupBox41.TabStop = false;
			this.gridCheckSummary.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.gridCheckSummary.Controls.Add(this.rdo_Setup_Month);
			this.gridCheckSummary.Controls.Add(this.label37);
			this.gridCheckSummary.Controls.Add(this.dateTime_SetupMonth);
			this.gridCheckSummary.Controls.Add(this.chkcmb_SetupDate);
			this.gridCheckSummary.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridCheckSummary.EnableSort = true;
			this.gridCheckSummary.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridCheckSummary.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridCheckSummary.Location = new global::System.Drawing.Point(3, 6);
			this.gridCheckSummary.Name = "gridCheckSummary";
			this.gridCheckSummary.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridCheckSummary.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridCheckSummary.Size = new global::System.Drawing.Size(1164, 579);
			this.gridCheckSummary.TabIndex = 116;
			this.gridCheckSummary.TabStop = true;
			this.gridCheckSummary.ToolTipText = "";
			this.rdo_Setup_Month.AutoSize = true;
			this.rdo_Setup_Month.Location = new global::System.Drawing.Point(996, 24);
			this.rdo_Setup_Month.Name = "rdo_Setup_Month";
			this.rdo_Setup_Month.Size = new global::System.Drawing.Size(60, 17);
			this.rdo_Setup_Month.TabIndex = 124;
			this.rdo_Setup_Month.Text = "Month";
			this.rdo_Setup_Month.UseVisualStyleBackColor = true;
			this.rdo_Setup_Month.Visible = false;
			this.label37.AutoSize = true;
			this.label37.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label37.Location = new global::System.Drawing.Point(1026, 52);
			this.label37.Name = "label37";
			this.label37.Size = new global::System.Drawing.Size(31, 15);
			this.label37.TabIndex = 119;
			this.label37.Text = "Date";
			this.label37.Visible = false;
			this.dateTime_SetupMonth.CustomFormat = "yyyy-MM";
			this.dateTime_SetupMonth.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTime_SetupMonth.Location = new global::System.Drawing.Point(1063, 20);
			this.dateTime_SetupMonth.Name = "dateTime_SetupMonth";
			this.dateTime_SetupMonth.ShowUpDown = true;
			this.dateTime_SetupMonth.Size = new global::System.Drawing.Size(70, 22);
			this.dateTime_SetupMonth.TabIndex = 107;
			this.dateTime_SetupMonth.Visible = false;
			this.panel23.Controls.Add(this.groupBox60);
			this.panel23.Controls.Add(this.groupBox59);
			this.panel23.Controls.Add(this.groupBox48);
			this.panel23.Controls.Add(this.groupBox36);
			this.panel23.Controls.Add(this.groupBox37);
			this.panel23.Controls.Add(this.groupBox38);
			this.panel23.Controls.Add(this.groupBox39);
			this.panel23.Controls.Add(this.groupBox40);
			this.panel23.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel23.Location = new global::System.Drawing.Point(0, 0);
			this.panel23.Name = "panel23";
			this.panel23.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel23.Size = new global::System.Drawing.Size(1176, 77);
			this.panel23.TabIndex = 19;
			this.groupBox60.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox60.Controls.Add(this.cmd_AddPara);
			this.groupBox60.Location = new global::System.Drawing.Point(1103, 13);
			this.groupBox60.Name = "groupBox60";
			this.groupBox60.Size = new global::System.Drawing.Size(67, 61);
			this.groupBox60.TabIndex = 127;
			this.groupBox60.TabStop = false;
			this.groupBox60.Text = "Setting";
			this.cmd_AddPara.Image = global::Amkor.CADModules.ESIModule.Properties.Resources.TableAdd;
			this.cmd_AddPara.Location = new global::System.Drawing.Point(17, 19);
			this.cmd_AddPara.Name = "cmd_AddPara";
			this.cmd_AddPara.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_AddPara.TabIndex = 103;
			this.cmd_AddPara.TabStop = false;
			this.cmd_AddPara.Click += new global::System.EventHandler(this.cmd_AddPara_Click);
			this.groupBox59.Controls.Add(this.cmb_Summary_Device);
			this.groupBox59.Location = new global::System.Drawing.Point(338, 3);
			this.groupBox59.Name = "groupBox59";
			this.groupBox59.Size = new global::System.Drawing.Size(154, 71);
			this.groupBox59.TabIndex = 126;
			this.groupBox59.TabStop = false;
			this.groupBox59.Text = "Device";
			this.cmb_Summary_Device.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmb_Summary_Device.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_Summary_Device.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmb_Summary_Device.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmb_Summary_Device.FormattingEnabled = true;
			this.cmb_Summary_Device.Location = new global::System.Drawing.Point(6, 29);
			this.cmb_Summary_Device.Name = "cmb_Summary_Device";
			this.cmb_Summary_Device.Size = new global::System.Drawing.Size(142, 23);
			this.cmb_Summary_Device.TabIndex = 120;
			this.groupBox48.Controls.Add(this.cmb_Summary_Result);
			this.groupBox48.Location = new global::System.Drawing.Point(657, 3);
			this.groupBox48.Name = "groupBox48";
			this.groupBox48.Size = new global::System.Drawing.Size(139, 71);
			this.groupBox48.TabIndex = 125;
			this.groupBox48.TabStop = false;
			this.groupBox48.Text = "Result";
			this.cmb_Summary_Result.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmb_Summary_Result.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_Summary_Result.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmb_Summary_Result.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmb_Summary_Result.FormattingEnabled = true;
			this.cmb_Summary_Result.Location = new global::System.Drawing.Point(6, 27);
			this.cmb_Summary_Result.Name = "cmb_Summary_Result";
			this.cmb_Summary_Result.Size = new global::System.Drawing.Size(127, 23);
			this.cmb_Summary_Result.TabIndex = 118;
			this.groupBox36.Controls.Add(this.chkcmb_Summary_Tester);
			this.groupBox36.Location = new global::System.Drawing.Point(498, 3);
			this.groupBox36.Name = "groupBox36";
			this.groupBox36.Size = new global::System.Drawing.Size(153, 71);
			this.groupBox36.TabIndex = 4;
			this.groupBox36.TabStop = false;
			this.groupBox36.Text = "Tester";
			this.groupBox37.Controls.Add(this.rdo_Setup_SelectDate);
			this.groupBox37.Controls.Add(this.label36);
			this.groupBox37.Controls.Add(this.Setup_Date_End);
			this.groupBox37.Controls.Add(this.Setup_Date_Start);
			this.groupBox37.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox37.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox37.Name = "groupBox37";
			this.groupBox37.Size = new global::System.Drawing.Size(329, 71);
			this.groupBox37.TabIndex = 5;
			this.groupBox37.TabStop = false;
			this.groupBox37.Text = "Date";
			this.rdo_Setup_SelectDate.AutoSize = true;
			this.rdo_Setup_SelectDate.Checked = true;
			this.rdo_Setup_SelectDate.Location = new global::System.Drawing.Point(9, 28);
			this.rdo_Setup_SelectDate.Name = "rdo_Setup_SelectDate";
			this.rdo_Setup_SelectDate.Size = new global::System.Drawing.Size(96, 19);
			this.rdo_Setup_SelectDate.TabIndex = 123;
			this.rdo_Setup_SelectDate.TabStop = true;
			this.rdo_Setup_SelectDate.Text = "Selected Date";
			this.rdo_Setup_SelectDate.UseVisualStyleBackColor = true;
			this.label36.AutoSize = true;
			this.label36.Location = new global::System.Drawing.Point(209, 30);
			this.label36.Name = "label36";
			this.label36.Size = new global::System.Drawing.Size(15, 15);
			this.label36.TabIndex = 122;
			this.label36.Text = "~";
			this.Setup_Date_End.CustomFormat = "yyyy-MM-dd";
			this.Setup_Date_End.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.Setup_Date_End.Location = new global::System.Drawing.Point(227, 26);
			this.Setup_Date_End.Name = "Setup_Date_End";
			this.Setup_Date_End.Size = new global::System.Drawing.Size(95, 23);
			this.Setup_Date_End.TabIndex = 120;
			this.Setup_Date_Start.CustomFormat = "yyyy-MM-dd";
			this.Setup_Date_Start.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.Setup_Date_Start.Location = new global::System.Drawing.Point(111, 26);
			this.Setup_Date_Start.Name = "Setup_Date_Start";
			this.Setup_Date_Start.Size = new global::System.Drawing.Size(95, 23);
			this.Setup_Date_Start.TabIndex = 121;
			this.groupBox38.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox38.Controls.Add(this.pictureBox1);
			this.groupBox38.Location = new global::System.Drawing.Point(931, 13);
			this.groupBox38.Name = "groupBox38";
			this.groupBox38.Size = new global::System.Drawing.Size(67, 61);
			this.groupBox38.TabIndex = 108;
			this.groupBox38.TabStop = false;
			this.groupBox38.Text = "RawData";
			this.groupBox38.Visible = false;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(17, 19);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(32, 32);
			this.pictureBox1.TabIndex = 103;
			this.pictureBox1.TabStop = false;
			this.groupBox39.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox39.Controls.Add(this.cmd_ParaSummary_Search);
			this.groupBox39.Location = new global::System.Drawing.Point(802, 13);
			this.groupBox39.Name = "groupBox39";
			this.groupBox39.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox39.TabIndex = 4;
			this.groupBox39.TabStop = false;
			this.groupBox39.Text = "Search";
			this.cmd_ParaSummary_Search.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_ParaSummary_Search.Image");
			this.cmd_ParaSummary_Search.Location = new global::System.Drawing.Point(14, 19);
			this.cmd_ParaSummary_Search.Name = "cmd_ParaSummary_Search";
			this.cmd_ParaSummary_Search.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_ParaSummary_Search.TabIndex = 102;
			this.cmd_ParaSummary_Search.TabStop = false;
			this.cmd_ParaSummary_Search.Click += new global::System.EventHandler(this.cmd_ParaSummary_Search_Click);
			this.groupBox40.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox40.Controls.Add(this.cmd_ParaSummary_Excel);
			this.groupBox40.Location = new global::System.Drawing.Point(870, 13);
			this.groupBox40.Name = "groupBox40";
			this.groupBox40.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox40.TabIndex = 103;
			this.groupBox40.TabStop = false;
			this.groupBox40.Text = "Excel";
			this.cmd_ParaSummary_Excel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_ParaSummary_Excel.Image");
			this.cmd_ParaSummary_Excel.Location = new global::System.Drawing.Point(12, 19);
			this.cmd_ParaSummary_Excel.Name = "cmd_ParaSummary_Excel";
			this.cmd_ParaSummary_Excel.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_ParaSummary_Excel.TabIndex = 103;
			this.cmd_ParaSummary_Excel.TabStop = false;
			this.cmd_ParaSummary_Excel.Click += new global::System.EventHandler(this.cmd_ParaSummary_Excel_Click);
			this.tab_CheckSummaryStatus.Controls.Add(this.panel26);
			this.tab_CheckSummaryStatus.Controls.Add(this.panel25);
			this.tab_CheckSummaryStatus.Location = new global::System.Drawing.Point(4, 24);
			this.tab_CheckSummaryStatus.Name = "tab_CheckSummaryStatus";
			this.tab_CheckSummaryStatus.Size = new global::System.Drawing.Size(1176, 671);
			this.tab_CheckSummaryStatus.TabIndex = 8;
			this.tab_CheckSummaryStatus.Text = "Daily Setup Check Status";
			this.tab_CheckSummaryStatus.UseVisualStyleBackColor = true;
			this.panel26.Controls.Add(this.groupBox47);
			this.panel26.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel26.Location = new global::System.Drawing.Point(0, 77);
			this.panel26.Name = "panel26";
			this.panel26.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel26.Size = new global::System.Drawing.Size(1176, 596);
			this.panel26.TabIndex = 21;
			this.groupBox47.Controls.Add(this.gridCheckStatus);
			this.groupBox47.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox47.Font = new global::System.Drawing.Font("Segoe UI", 1.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox47.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox47.Name = "groupBox47";
			this.groupBox47.Size = new global::System.Drawing.Size(1170, 590);
			this.groupBox47.TabIndex = 117;
			this.groupBox47.TabStop = false;
			this.gridCheckStatus.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.gridCheckStatus.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridCheckStatus.EnableSort = true;
			this.gridCheckStatus.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridCheckStatus.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridCheckStatus.Location = new global::System.Drawing.Point(3, 6);
			this.gridCheckStatus.Name = "gridCheckStatus";
			this.gridCheckStatus.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridCheckStatus.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridCheckStatus.Size = new global::System.Drawing.Size(1164, 581);
			this.gridCheckStatus.TabIndex = 116;
			this.gridCheckStatus.TabStop = true;
			this.gridCheckStatus.ToolTipText = "";
			this.panel25.Controls.Add(this.groupBox58);
			this.panel25.Controls.Add(this.groupBox42);
			this.panel25.Controls.Add(this.groupBox43);
			this.panel25.Controls.Add(this.groupBox44);
			this.panel25.Controls.Add(this.checkedComboBox2);
			this.panel25.Controls.Add(this.groupBox45);
			this.panel25.Controls.Add(this.groupBox46);
			this.panel25.Controls.Add(this.label43);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel25.Location = new global::System.Drawing.Point(0, 0);
			this.panel25.Name = "panel25";
			this.panel25.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel25.Size = new global::System.Drawing.Size(1176, 77);
			this.panel25.TabIndex = 20;
			this.groupBox58.Controls.Add(this.cmb_Status_Tester);
			this.groupBox58.Location = new global::System.Drawing.Point(338, 3);
			this.groupBox58.Name = "groupBox58";
			this.groupBox58.Size = new global::System.Drawing.Size(154, 71);
			this.groupBox58.TabIndex = 120;
			this.groupBox58.TabStop = false;
			this.groupBox58.Text = "Device";
			this.cmb_Status_Tester.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmb_Status_Tester.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_Status_Tester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmb_Status_Tester.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmb_Status_Tester.FormattingEnabled = true;
			this.cmb_Status_Tester.Location = new global::System.Drawing.Point(6, 29);
			this.cmb_Status_Tester.Name = "cmb_Status_Tester";
			this.cmb_Status_Tester.Size = new global::System.Drawing.Size(142, 23);
			this.cmb_Status_Tester.TabIndex = 120;
			this.groupBox42.Controls.Add(this.chkcmb_Status_Tester);
			this.groupBox42.Location = new global::System.Drawing.Point(498, 3);
			this.groupBox42.Name = "groupBox42";
			this.groupBox42.Size = new global::System.Drawing.Size(160, 71);
			this.groupBox42.TabIndex = 4;
			this.groupBox42.TabStop = false;
			this.groupBox42.Text = "Tester";
			this.groupBox43.Controls.Add(this.rdo_Status_Month);
			this.groupBox43.Controls.Add(this.rdo_Status_SelectDate);
			this.groupBox43.Controls.Add(this.label40);
			this.groupBox43.Controls.Add(this.Status_Month);
			this.groupBox43.Controls.Add(this.Status_Date_End);
			this.groupBox43.Controls.Add(this.Status_Date_Start);
			this.groupBox43.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox43.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox43.Name = "groupBox43";
			this.groupBox43.Size = new global::System.Drawing.Size(329, 71);
			this.groupBox43.TabIndex = 5;
			this.groupBox43.TabStop = false;
			this.groupBox43.Text = "Date";
			this.rdo_Status_Month.AutoSize = true;
			this.rdo_Status_Month.Checked = true;
			this.rdo_Status_Month.Location = new global::System.Drawing.Point(9, 44);
			this.rdo_Status_Month.Name = "rdo_Status_Month";
			this.rdo_Status_Month.Size = new global::System.Drawing.Size(61, 19);
			this.rdo_Status_Month.TabIndex = 124;
			this.rdo_Status_Month.TabStop = true;
			this.rdo_Status_Month.Text = "Month";
			this.rdo_Status_Month.UseVisualStyleBackColor = true;
			this.rdo_Status_SelectDate.AutoSize = true;
			this.rdo_Status_SelectDate.Location = new global::System.Drawing.Point(9, 16);
			this.rdo_Status_SelectDate.Name = "rdo_Status_SelectDate";
			this.rdo_Status_SelectDate.Size = new global::System.Drawing.Size(96, 19);
			this.rdo_Status_SelectDate.TabIndex = 123;
			this.rdo_Status_SelectDate.Text = "Selected Date";
			this.rdo_Status_SelectDate.UseVisualStyleBackColor = true;
			this.label40.AutoSize = true;
			this.label40.Location = new global::System.Drawing.Point(209, 18);
			this.label40.Name = "label40";
			this.label40.Size = new global::System.Drawing.Size(15, 15);
			this.label40.TabIndex = 122;
			this.label40.Text = "~";
			this.Status_Month.CustomFormat = "yyyy-MM";
			this.Status_Month.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.Status_Month.Location = new global::System.Drawing.Point(111, 43);
			this.Status_Month.Name = "Status_Month";
			this.Status_Month.ShowUpDown = true;
			this.Status_Month.Size = new global::System.Drawing.Size(70, 23);
			this.Status_Month.TabIndex = 107;
			this.Status_Date_End.CustomFormat = "yyyy-MM-dd";
			this.Status_Date_End.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.Status_Date_End.Location = new global::System.Drawing.Point(227, 14);
			this.Status_Date_End.Name = "Status_Date_End";
			this.Status_Date_End.Size = new global::System.Drawing.Size(95, 23);
			this.Status_Date_End.TabIndex = 120;
			this.Status_Date_Start.CustomFormat = "yyyy-MM-dd";
			this.Status_Date_Start.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.Status_Date_Start.Location = new global::System.Drawing.Point(111, 14);
			this.Status_Date_Start.Name = "Status_Date_Start";
			this.Status_Date_Start.Size = new global::System.Drawing.Size(95, 23);
			this.Status_Date_Start.TabIndex = 121;
			this.groupBox44.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox44.Controls.Add(this.pictureBox3);
			this.groupBox44.Location = new global::System.Drawing.Point(793, 10);
			this.groupBox44.Name = "groupBox44";
			this.groupBox44.Size = new global::System.Drawing.Size(67, 61);
			this.groupBox44.TabIndex = 108;
			this.groupBox44.TabStop = false;
			this.groupBox44.Text = "RawData";
			this.groupBox44.Visible = false;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(17, 19);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(32, 32);
			this.pictureBox3.TabIndex = 103;
			this.pictureBox3.TabStop = false;
			this.groupBox45.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox45.Controls.Add(this.cmd_CheckStatus_Search);
			this.groupBox45.Location = new global::System.Drawing.Point(664, 10);
			this.groupBox45.Name = "groupBox45";
			this.groupBox45.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox45.TabIndex = 4;
			this.groupBox45.TabStop = false;
			this.groupBox45.Text = "Search";
			this.cmd_CheckStatus_Search.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_CheckStatus_Search.Image");
			this.cmd_CheckStatus_Search.Location = new global::System.Drawing.Point(14, 19);
			this.cmd_CheckStatus_Search.Name = "cmd_CheckStatus_Search";
			this.cmd_CheckStatus_Search.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_CheckStatus_Search.TabIndex = 102;
			this.cmd_CheckStatus_Search.TabStop = false;
			this.cmd_CheckStatus_Search.Click += new global::System.EventHandler(this.cmd_CheckStatus_Search_Click);
			this.groupBox46.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox46.Controls.Add(this.cmd_CheckStatus_Excel);
			this.groupBox46.Location = new global::System.Drawing.Point(732, 10);
			this.groupBox46.Name = "groupBox46";
			this.groupBox46.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox46.TabIndex = 103;
			this.groupBox46.TabStop = false;
			this.groupBox46.Text = "Excel";
			this.cmd_CheckStatus_Excel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_CheckStatus_Excel.Image");
			this.cmd_CheckStatus_Excel.Location = new global::System.Drawing.Point(12, 19);
			this.cmd_CheckStatus_Excel.Name = "cmd_CheckStatus_Excel";
			this.cmd_CheckStatus_Excel.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_CheckStatus_Excel.TabIndex = 103;
			this.cmd_CheckStatus_Excel.TabStop = false;
			this.cmd_CheckStatus_Excel.Click += new global::System.EventHandler(this.cmd_CheckStatus_Excel_Click);
			this.label43.AutoSize = true;
			this.label43.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label43.Location = new global::System.Drawing.Point(965, 35);
			this.label43.Name = "label43";
			this.label43.Size = new global::System.Drawing.Size(31, 15);
			this.label43.TabIndex = 119;
			this.label43.Text = "Date";
			this.label43.Visible = false;
			this.tab_CheckSummaryTrend.Controls.Add(this.panel30);
			this.tab_CheckSummaryTrend.Controls.Add(this.panel27);
			this.tab_CheckSummaryTrend.Location = new global::System.Drawing.Point(4, 24);
			this.tab_CheckSummaryTrend.Name = "tab_CheckSummaryTrend";
			this.tab_CheckSummaryTrend.Size = new global::System.Drawing.Size(1176, 671);
			this.tab_CheckSummaryTrend.TabIndex = 9;
			this.tab_CheckSummaryTrend.Text = "Historical Trend Chart";
			this.tab_CheckSummaryTrend.UseVisualStyleBackColor = true;
			this.panel30.Controls.Add(this.splitter5);
			this.panel30.Controls.Add(this.panel29);
			this.panel30.Controls.Add(this.panel28);
			this.panel30.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel30.Location = new global::System.Drawing.Point(0, 82);
			this.panel30.Name = "panel30";
			this.panel30.Size = new global::System.Drawing.Size(1176, 589);
			this.panel30.TabIndex = 154;
			this.splitter5.Location = new global::System.Drawing.Point(708, 0);
			this.splitter5.Name = "splitter5";
			this.splitter5.Size = new global::System.Drawing.Size(5, 589);
			this.splitter5.TabIndex = 154;
			this.splitter5.TabStop = false;
			this.panel29.Controls.Add(this.groupBox57);
			this.panel29.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel29.Location = new global::System.Drawing.Point(708, 0);
			this.panel29.Name = "panel29";
			this.panel29.Padding = new global::System.Windows.Forms.Padding(10, 5, 0, 0);
			this.panel29.Size = new global::System.Drawing.Size(468, 589);
			this.panel29.TabIndex = 152;
			this.groupBox57.Controls.Add(this.chart_RChart);
			this.groupBox57.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox57.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox57.Location = new global::System.Drawing.Point(10, 5);
			this.groupBox57.Name = "groupBox57";
			this.groupBox57.Size = new global::System.Drawing.Size(458, 584);
			this.groupBox57.TabIndex = 148;
			this.groupBox57.TabStop = false;
			this.groupBox57.Text = "R chart (Max – Min) ";
			this.chart_RChart.BackGradientStyle = global::System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart_RChart.BackSecondaryColor = global::System.Drawing.Color.White;
			this.chart_RChart.BorderlineColor = global::System.Drawing.Color.Silver;
			this.chart_RChart.BorderlineDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
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
			this.chart_RChart.ChartAreas.Add(chartArea);
			this.chart_RChart.Dock = global::System.Windows.Forms.DockStyle.Fill;
			legend.Alignment = global::System.Drawing.StringAlignment.Center;
			legend.BackColor = global::System.Drawing.Color.Transparent;
			legend.BorderColor = global::System.Drawing.Color.Transparent;
			legend.Docking = global::System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			legend.IsTextAutoFit = false;
			legend.Name = "Legend1";
			this.chart_RChart.Legends.Add(legend);
			this.chart_RChart.Location = new global::System.Drawing.Point(3, 21);
			this.chart_RChart.Name = "chart_RChart";
			this.chart_RChart.Size = new global::System.Drawing.Size(452, 560);
			this.chart_RChart.TabIndex = 147;
			this.chart_RChart.Text = "chart_TestItem";
			title.BackColor = global::System.Drawing.Color.Transparent;
			title.BackImageAlignment = global::System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
			title.BackImageWrapMode = global::System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
			title.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			title.Name = "Title1";
			title.ShadowColor = global::System.Drawing.Color.Silver;
			title.Text = "Test Item";
			this.chart_RChart.Titles.Add(title);
			this.panel28.Controls.Add(this.groupBox56);
			this.panel28.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel28.Location = new global::System.Drawing.Point(0, 0);
			this.panel28.Name = "panel28";
			this.panel28.Padding = new global::System.Windows.Forms.Padding(0, 5, 5, 0);
			this.panel28.Size = new global::System.Drawing.Size(708, 589);
			this.panel28.TabIndex = 151;
			this.groupBox56.Controls.Add(this.chart_XBarChart);
			this.groupBox56.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox56.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox56.Location = new global::System.Drawing.Point(0, 5);
			this.groupBox56.Name = "groupBox56";
			this.groupBox56.Size = new global::System.Drawing.Size(703, 584);
			this.groupBox56.TabIndex = 148;
			this.groupBox56.TabStop = false;
			this.groupBox56.Text = "X-bar Chart (Average)";
			this.chart_XBarChart.BackGradientStyle = global::System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart_XBarChart.BackSecondaryColor = global::System.Drawing.Color.White;
			this.chart_XBarChart.BorderlineColor = global::System.Drawing.Color.Silver;
			this.chart_XBarChart.BorderlineDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea2.Area3DStyle.Inclination = 5;
			chartArea2.Area3DStyle.IsClustered = true;
			chartArea2.Area3DStyle.Rotation = 0;
			chartArea2.Area3DStyle.WallWidth = 0;
			chartArea2.AxisX.LineColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea2.AxisX.Maximum = 100.0;
			chartArea2.AxisY.IsLabelAutoFit = false;
			chartArea2.AxisY.LabelStyle.Font = new global::System.Drawing.Font("Arial", 8f);
			chartArea2.AxisY.LineColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea2.AxisY.Maximum = 100.0;
			chartArea2.AxisY.MaximumAutoSize = 100f;
			chartArea2.AxisY.Minimum = 0.0;
			chartArea2.BackColor = global::System.Drawing.Color.White;
			chartArea2.BackSecondaryColor = global::System.Drawing.Color.White;
			chartArea2.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea2.BorderDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea2.Name = "ChartArea1";
			chartArea2.ShadowColor = global::System.Drawing.Color.Transparent;
			this.chart_XBarChart.ChartAreas.Add(chartArea2);
			this.chart_XBarChart.Dock = global::System.Windows.Forms.DockStyle.Fill;
			legend2.Alignment = global::System.Drawing.StringAlignment.Center;
			legend2.BackColor = global::System.Drawing.Color.Transparent;
			legend2.BorderColor = global::System.Drawing.Color.Transparent;
			legend2.Docking = global::System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			legend2.IsTextAutoFit = false;
			legend2.Name = "Legend1";
			this.chart_XBarChart.Legends.Add(legend2);
			this.chart_XBarChart.Location = new global::System.Drawing.Point(3, 21);
			this.chart_XBarChart.Name = "chart_XBarChart";
			this.chart_XBarChart.Size = new global::System.Drawing.Size(697, 560);
			this.chart_XBarChart.TabIndex = 147;
			this.chart_XBarChart.Text = "chart_TestItem";
			title2.BackColor = global::System.Drawing.Color.Transparent;
			title2.BackImageAlignment = global::System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
			title2.BackImageWrapMode = global::System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
			title2.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			title2.Name = "Title1";
			title2.ShadowColor = global::System.Drawing.Color.Silver;
			title2.Text = "Test Item";
			this.chart_XBarChart.Titles.Add(title2);
			this.panel27.Controls.Add(this.groupBox54);
			this.panel27.Controls.Add(this.groupBox55);
			this.panel27.Controls.Add(this.groupBox49);
			this.panel27.Controls.Add(this.groupBox50);
			this.panel27.Controls.Add(this.groupBox51);
			this.panel27.Controls.Add(this.groupBox52);
			this.panel27.Controls.Add(this.groupBox53);
			this.panel27.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel27.Location = new global::System.Drawing.Point(0, 0);
			this.panel27.Name = "panel27";
			this.panel27.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel27.Size = new global::System.Drawing.Size(1176, 82);
			this.panel27.TabIndex = 21;
			this.groupBox54.Controls.Add(this.cmb_Trend_Device);
			this.groupBox54.Location = new global::System.Drawing.Point(338, 3);
			this.groupBox54.Name = "groupBox54";
			this.groupBox54.Size = new global::System.Drawing.Size(132, 73);
			this.groupBox54.TabIndex = 122;
			this.groupBox54.TabStop = false;
			this.groupBox54.Text = "Device";
			this.cmb_Trend_Device.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmb_Trend_Device.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_Trend_Device.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmb_Trend_Device.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmb_Trend_Device.FormattingEnabled = true;
			this.cmb_Trend_Device.Location = new global::System.Drawing.Point(6, 29);
			this.cmb_Trend_Device.Name = "cmb_Trend_Device";
			this.cmb_Trend_Device.Size = new global::System.Drawing.Size(120, 23);
			this.cmb_Trend_Device.TabIndex = 119;
			this.groupBox55.Controls.Add(this.cmb_Trend_TestItem);
			this.groupBox55.Controls.Add(this.txtTrendTestItem);
			this.groupBox55.Location = new global::System.Drawing.Point(614, 3);
			this.groupBox55.Name = "groupBox55";
			this.groupBox55.Size = new global::System.Drawing.Size(358, 73);
			this.groupBox55.TabIndex = 121;
			this.groupBox55.TabStop = false;
			this.groupBox55.Text = "Test Item";
			this.cmb_Trend_TestItem.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmb_Trend_TestItem.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmb_Trend_TestItem.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmb_Trend_TestItem.FormattingEnabled = true;
			this.cmb_Trend_TestItem.Location = new global::System.Drawing.Point(6, 43);
			this.cmb_Trend_TestItem.Name = "cmb_Trend_TestItem";
			this.cmb_Trend_TestItem.Size = new global::System.Drawing.Size(346, 23);
			this.cmb_Trend_TestItem.TabIndex = 120;
			this.cmb_Trend_TestItem.DropDown += new global::System.EventHandler(this.cmb_Trend_TestItem_DropDown);
			this.txtTrendTestItem.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.txtTrendTestItem.Location = new global::System.Drawing.Point(6, 15);
			this.txtTrendTestItem.Name = "txtTrendTestItem";
			this.txtTrendTestItem.Size = new global::System.Drawing.Size(346, 23);
			this.txtTrendTestItem.TabIndex = 118;
			this.groupBox49.Controls.Add(this.cmb_Trend_Tester);
			this.groupBox49.Location = new global::System.Drawing.Point(476, 3);
			this.groupBox49.Name = "groupBox49";
			this.groupBox49.Size = new global::System.Drawing.Size(132, 73);
			this.groupBox49.TabIndex = 4;
			this.groupBox49.TabStop = false;
			this.groupBox49.Text = "Tester";
			this.cmb_Trend_Tester.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmb_Trend_Tester.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_Trend_Tester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmb_Trend_Tester.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmb_Trend_Tester.FormattingEnabled = true;
			this.cmb_Trend_Tester.Location = new global::System.Drawing.Point(6, 29);
			this.cmb_Trend_Tester.Name = "cmb_Trend_Tester";
			this.cmb_Trend_Tester.Size = new global::System.Drawing.Size(120, 23);
			this.cmb_Trend_Tester.TabIndex = 119;
			this.groupBox50.Controls.Add(this.rdo_Trend_Month);
			this.groupBox50.Controls.Add(this.rdo_Trend_SelectDate);
			this.groupBox50.Controls.Add(this.label47);
			this.groupBox50.Controls.Add(this.Trend_Month);
			this.groupBox50.Controls.Add(this.Trend_Date_End);
			this.groupBox50.Controls.Add(this.Trend_Date_Start);
			this.groupBox50.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox50.Name = "groupBox50";
			this.groupBox50.Size = new global::System.Drawing.Size(329, 73);
			this.groupBox50.TabIndex = 5;
			this.groupBox50.TabStop = false;
			this.groupBox50.Text = "Date";
			this.rdo_Trend_Month.AutoSize = true;
			this.rdo_Trend_Month.Checked = true;
			this.rdo_Trend_Month.Location = new global::System.Drawing.Point(9, 44);
			this.rdo_Trend_Month.Name = "rdo_Trend_Month";
			this.rdo_Trend_Month.Size = new global::System.Drawing.Size(61, 19);
			this.rdo_Trend_Month.TabIndex = 124;
			this.rdo_Trend_Month.TabStop = true;
			this.rdo_Trend_Month.Text = "Month";
			this.rdo_Trend_Month.UseVisualStyleBackColor = true;
			this.rdo_Trend_SelectDate.AutoSize = true;
			this.rdo_Trend_SelectDate.Location = new global::System.Drawing.Point(9, 16);
			this.rdo_Trend_SelectDate.Name = "rdo_Trend_SelectDate";
			this.rdo_Trend_SelectDate.Size = new global::System.Drawing.Size(96, 19);
			this.rdo_Trend_SelectDate.TabIndex = 123;
			this.rdo_Trend_SelectDate.Text = "Selected Date";
			this.rdo_Trend_SelectDate.UseVisualStyleBackColor = true;
			this.label47.AutoSize = true;
			this.label47.Location = new global::System.Drawing.Point(209, 18);
			this.label47.Name = "label47";
			this.label47.Size = new global::System.Drawing.Size(15, 15);
			this.label47.TabIndex = 122;
			this.label47.Text = "~";
			this.Trend_Month.CustomFormat = "yyyy-MM";
			this.Trend_Month.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.Trend_Month.Location = new global::System.Drawing.Point(111, 43);
			this.Trend_Month.Name = "Trend_Month";
			this.Trend_Month.ShowUpDown = true;
			this.Trend_Month.Size = new global::System.Drawing.Size(70, 23);
			this.Trend_Month.TabIndex = 107;
			this.Trend_Date_End.CustomFormat = "yyyy-MM-dd";
			this.Trend_Date_End.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.Trend_Date_End.Location = new global::System.Drawing.Point(227, 14);
			this.Trend_Date_End.Name = "Trend_Date_End";
			this.Trend_Date_End.Size = new global::System.Drawing.Size(95, 23);
			this.Trend_Date_End.TabIndex = 120;
			this.Trend_Date_Start.CustomFormat = "yyyy-MM-dd";
			this.Trend_Date_Start.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.Trend_Date_Start.Location = new global::System.Drawing.Point(111, 14);
			this.Trend_Date_Start.Name = "Trend_Date_Start";
			this.Trend_Date_Start.Size = new global::System.Drawing.Size(95, 23);
			this.Trend_Date_Start.TabIndex = 121;
			this.groupBox51.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox51.Controls.Add(this.pictureBox4);
			this.groupBox51.Location = new global::System.Drawing.Point(1107, 15);
			this.groupBox51.Name = "groupBox51";
			this.groupBox51.Size = new global::System.Drawing.Size(67, 61);
			this.groupBox51.TabIndex = 108;
			this.groupBox51.TabStop = false;
			this.groupBox51.Text = "RawData";
			this.groupBox51.Visible = false;
			this.pictureBox4.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new global::System.Drawing.Point(17, 19);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(32, 32);
			this.pictureBox4.TabIndex = 103;
			this.pictureBox4.TabStop = false;
			this.groupBox52.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox52.Controls.Add(this.cmd_Trend_Search);
			this.groupBox52.Location = new global::System.Drawing.Point(978, 15);
			this.groupBox52.Name = "groupBox52";
			this.groupBox52.Size = new global::System.Drawing.Size(62, 61);
			this.groupBox52.TabIndex = 4;
			this.groupBox52.TabStop = false;
			this.groupBox52.Text = "Search";
			this.cmd_Trend_Search.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_Trend_Search.Image");
			this.cmd_Trend_Search.Location = new global::System.Drawing.Point(14, 19);
			this.cmd_Trend_Search.Name = "cmd_Trend_Search";
			this.cmd_Trend_Search.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_Trend_Search.TabIndex = 102;
			this.cmd_Trend_Search.TabStop = false;
			this.cmd_Trend_Search.Click += new global::System.EventHandler(this.cmd_Trend_Search_Click);
			this.groupBox53.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.groupBox53.Controls.Add(this.cmd_Trend_Excel);
			this.groupBox53.Location = new global::System.Drawing.Point(1046, 15);
			this.groupBox53.Name = "groupBox53";
			this.groupBox53.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox53.TabIndex = 103;
			this.groupBox53.TabStop = false;
			this.groupBox53.Text = "Excel";
			this.groupBox53.Visible = false;
			this.cmd_Trend_Excel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmd_Trend_Excel.Image");
			this.cmd_Trend_Excel.Location = new global::System.Drawing.Point(12, 19);
			this.cmd_Trend_Excel.Name = "cmd_Trend_Excel";
			this.cmd_Trend_Excel.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_Trend_Excel.TabIndex = 103;
			this.cmd_Trend_Excel.TabStop = false;
			this.openFileDialog.FileName = "openFileDialog";
			this.chkCmbOperation.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.chkCmbOperation.CheckOnClick = true;
			this.chkCmbOperation.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkCmbOperation.DropDownHeight = 1;
			this.chkCmbOperation.DropDownWidth = 160;
			this.chkCmbOperation.FormattingEnabled = true;
			this.chkCmbOperation.IntegralHeight = false;
			this.chkCmbOperation.Location = new global::System.Drawing.Point(357, 17);
			this.chkCmbOperation.MaxDropDownItems = 10;
			this.chkCmbOperation.Name = "chkCmbOperation";
			this.chkCmbOperation.Size = new global::System.Drawing.Size(120, 24);
			this.chkCmbOperation.TabIndex = 116;
			this.chkCmbOperation.ValueSeparator = ", ";
			this.chkCmbReportType.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.chkCmbReportType.CheckOnClick = true;
			this.chkCmbReportType.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkCmbReportType.DropDownHeight = 1;
			this.chkCmbReportType.FormattingEnabled = true;
			this.chkCmbReportType.IntegralHeight = false;
			this.chkCmbReportType.Location = new global::System.Drawing.Point(81, 17);
			this.chkCmbReportType.Name = "chkCmbReportType";
			this.chkCmbReportType.Size = new global::System.Drawing.Size(214, 24);
			this.chkCmbReportType.TabIndex = 4;
			this.chkCmbReportType.ValueSeparator = ", ";
			this.chkcmbATETester.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.chkcmbATETester.CheckOnClick = true;
			this.chkcmbATETester.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkcmbATETester.DropDownHeight = 1;
			this.chkcmbATETester.FormattingEnabled = true;
			this.chkcmbATETester.IntegralHeight = false;
			this.chkcmbATETester.Location = new global::System.Drawing.Point(54, 26);
			this.chkcmbATETester.MaxDropDownItems = 30;
			this.chkcmbATETester.Name = "chkcmbATETester";
			this.chkcmbATETester.Size = new global::System.Drawing.Size(142, 24);
			this.chkcmbATETester.TabIndex = 116;
			this.chkcmbATETester.ValueSeparator = ", ";
			this.chkcmb_BTOQCDate.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.chkcmb_BTOQCDate.CheckOnClick = true;
			this.chkcmb_BTOQCDate.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkcmb_BTOQCDate.DropDownHeight = 1;
			this.chkcmb_BTOQCDate.FormattingEnabled = true;
			this.chkcmb_BTOQCDate.IntegralHeight = false;
			this.chkcmb_BTOQCDate.Location = new global::System.Drawing.Point(227, 43);
			this.chkcmb_BTOQCDate.MaxDropDownItems = 30;
			this.chkcmb_BTOQCDate.Name = "chkcmb_BTOQCDate";
			this.chkcmb_BTOQCDate.Size = new global::System.Drawing.Size(95, 24);
			this.chkcmb_BTOQCDate.TabIndex = 118;
			this.chkcmb_BTOQCDate.ValueSeparator = ", ";
			this.chkcmb_SetupDate.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.chkcmb_SetupDate.CheckOnClick = true;
			this.chkcmb_SetupDate.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkcmb_SetupDate.DropDownHeight = 1;
			this.chkcmb_SetupDate.FormattingEnabled = true;
			this.chkcmb_SetupDate.IntegralHeight = false;
			this.chkcmb_SetupDate.Location = new global::System.Drawing.Point(1060, 49);
			this.chkcmb_SetupDate.MaxDropDownItems = 30;
			this.chkcmb_SetupDate.Name = "chkcmb_SetupDate";
			this.chkcmb_SetupDate.Size = new global::System.Drawing.Size(95, 23);
			this.chkcmb_SetupDate.TabIndex = 118;
			this.chkcmb_SetupDate.ValueSeparator = ", ";
			this.chkcmb_SetupDate.Visible = false;
			this.chkcmb_Summary_Tester.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.chkcmb_Summary_Tester.CheckOnClick = true;
			this.chkcmb_Summary_Tester.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkcmb_Summary_Tester.DropDownHeight = 1;
			this.chkcmb_Summary_Tester.FormattingEnabled = true;
			this.chkcmb_Summary_Tester.IntegralHeight = false;
			this.chkcmb_Summary_Tester.Location = new global::System.Drawing.Point(6, 28);
			this.chkcmb_Summary_Tester.MaxDropDownItems = 30;
			this.chkcmb_Summary_Tester.Name = "chkcmb_Summary_Tester";
			this.chkcmb_Summary_Tester.Size = new global::System.Drawing.Size(142, 24);
			this.chkcmb_Summary_Tester.TabIndex = 116;
			this.chkcmb_Summary_Tester.ValueSeparator = ", ";
			this.chkcmb_Status_Tester.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.chkcmb_Status_Tester.CheckOnClick = true;
			this.chkcmb_Status_Tester.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkcmb_Status_Tester.DropDownHeight = 1;
			this.chkcmb_Status_Tester.FormattingEnabled = true;
			this.chkcmb_Status_Tester.IntegralHeight = false;
			this.chkcmb_Status_Tester.Location = new global::System.Drawing.Point(6, 29);
			this.chkcmb_Status_Tester.MaxDropDownItems = 30;
			this.chkcmb_Status_Tester.Name = "chkcmb_Status_Tester";
			this.chkcmb_Status_Tester.Size = new global::System.Drawing.Size(148, 24);
			this.chkcmb_Status_Tester.TabIndex = 116;
			this.chkcmb_Status_Tester.ValueSeparator = ", ";
			this.checkedComboBox2.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.checkedComboBox2.CheckOnClick = true;
			this.checkedComboBox2.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.checkedComboBox2.DropDownHeight = 1;
			this.checkedComboBox2.FormattingEnabled = true;
			this.checkedComboBox2.IntegralHeight = false;
			this.checkedComboBox2.Location = new global::System.Drawing.Point(999, 32);
			this.checkedComboBox2.MaxDropDownItems = 30;
			this.checkedComboBox2.Name = "checkedComboBox2";
			this.checkedComboBox2.Size = new global::System.Drawing.Size(95, 24);
			this.checkedComboBox2.TabIndex = 118;
			this.checkedComboBox2.ValueSeparator = ", ";
			this.checkedComboBox2.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1184, 761);
			base.Controls.Add(this.chkBarcode_Out);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel15);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Name = "ESI";
			this.Text = "ESI";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.ESI_FormClosing);
			base.Load += new global::System.EventHandler(this.Modeler_Load);
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
			this.groupBox35.ResumeLayout(false);
			this.groupBox35.PerformLayout();
			this.groupBox19.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Yield_Search).EndInit();
			this.groupBox18.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Yield_Excel).EndInit();
			this.panel10.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.groupBox20.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			this.tabFA_CheckIn.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb2DId).EndInit();
			this.gbExcel.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbRequestExcel).EndInit();
			this.groupBox16.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_In_Apply).EndInit();
			this.groupBox17.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_In_Search).EndInit();
			this.panel7.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.tabFA_UnitList.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.gridUnitList.ResumeLayout(false);
			this.gridUnitList.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbComment).EndInit();
			this.groupBox22.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			this.groupBox21.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbCheckIn).EndInit();
			this.groupBox7.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdUnitExcel).EndInit();
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdUnitSearch).EndInit();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.tab_BT_Monitoring.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.groupBox23.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.groupBox25.ResumeLayout(false);
			this.groupBox25.PerformLayout();
			this.groupBox24.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_RawData_Excel).EndInit();
			this.groupBox13.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_BTOQC_Search).EndInit();
			this.groupBox15.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_BTOQC_Excel).EndInit();
			this.tab_UploadUnit.ResumeLayout(false);
			this.panel17.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.panel21.ResumeLayout(false);
			this.groupBox33.ResumeLayout(false);
			this.panel16.ResumeLayout(false);
			this.groupBox26.ResumeLayout(false);
			this.groupBox26.PerformLayout();
			this.groupBox31.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_UploadApply).EndInit();
			this.grpUpload.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Upload_Data).EndInit();
			this.panel18.ResumeLayout(false);
			this.panel22.ResumeLayout(false);
			this.groupBox30.ResumeLayout(false);
			this.panel19.ResumeLayout(false);
			this.groupBox29.ResumeLayout(false);
			this.groupBox32.ResumeLayout(false);
			this.groupBox32.PerformLayout();
			this.groupBox34.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_UploadDelete).EndInit();
			this.groupBox27.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_UploadSearch).EndInit();
			this.groupBox28.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Download_Data).EndInit();
			this.tab_CheckSummary.ResumeLayout(false);
			this.panel24.ResumeLayout(false);
			this.groupBox41.ResumeLayout(false);
			this.gridCheckSummary.ResumeLayout(false);
			this.gridCheckSummary.PerformLayout();
			this.panel23.ResumeLayout(false);
			this.groupBox60.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_AddPara).EndInit();
			this.groupBox59.ResumeLayout(false);
			this.groupBox48.ResumeLayout(false);
			this.groupBox36.ResumeLayout(false);
			this.groupBox37.ResumeLayout(false);
			this.groupBox37.PerformLayout();
			this.groupBox38.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.groupBox39.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_ParaSummary_Search).EndInit();
			this.groupBox40.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_ParaSummary_Excel).EndInit();
			this.tab_CheckSummaryStatus.ResumeLayout(false);
			this.panel26.ResumeLayout(false);
			this.groupBox47.ResumeLayout(false);
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.groupBox58.ResumeLayout(false);
			this.groupBox42.ResumeLayout(false);
			this.groupBox43.ResumeLayout(false);
			this.groupBox43.PerformLayout();
			this.groupBox44.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			this.groupBox45.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_CheckStatus_Search).EndInit();
			this.groupBox46.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_CheckStatus_Excel).EndInit();
			this.tab_CheckSummaryTrend.ResumeLayout(false);
			this.panel30.ResumeLayout(false);
			this.panel29.ResumeLayout(false);
			this.groupBox57.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.chart_RChart).EndInit();
			this.panel28.ResumeLayout(false);
			this.groupBox56.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.chart_XBarChart).EndInit();
			this.panel27.ResumeLayout(false);
			this.groupBox54.ResumeLayout(false);
			this.groupBox55.ResumeLayout(false);
			this.groupBox55.PerformLayout();
			this.groupBox49.ResumeLayout(false);
			this.groupBox50.ResumeLayout(false);
			this.groupBox50.PerformLayout();
			this.groupBox51.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			this.groupBox52.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Trend_Search).EndInit();
			this.groupBox53.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Trend_Excel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000154 RID: 340
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000155 RID: 341
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000156 RID: 342
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000157 RID: 343
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x04000158 RID: 344
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000159 RID: 345
		private global::System.Windows.Forms.Splitter splitter8;

		// Token: 0x0400015A RID: 346
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.TabControl chkBarcode_Out;

		// Token: 0x0400015C RID: 348
		private global::System.Windows.Forms.TabPage tabFA_UnitList;

		// Token: 0x0400015D RID: 349
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x0400015F RID: 351
		private global::SourceGrid.Grid gridUnitList;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000162 RID: 354
		private global::System.Windows.Forms.PictureBox cmdUnitExcel;

		// Token: 0x04000163 RID: 355
		private global::System.Windows.Forms.PictureBox cmdUnitSearch;

		// Token: 0x04000164 RID: 356
		private global::System.Windows.Forms.TextBox txtUnitSN;

		// Token: 0x04000165 RID: 357
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000166 RID: 358
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x04000167 RID: 359
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000168 RID: 360
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000169 RID: 361
		private global::System.Windows.Forms.ComboBox cmbUnitStationId;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.Label label35;

		// Token: 0x0400016C RID: 364
		private global::System.Windows.Forms.ComboBox cmbUnitStation;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.ComboBox cmbUnitProduct;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.GroupBox groupBox11;

		// Token: 0x0400016F RID: 367
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.DateTimePicker dtp_End_Histroy;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.DateTimePicker dtp_Start_History;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.TabPage tabFA_CheckIn;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.Splitter splitter1;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.CheckBox chk_AutoCheckIn;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.GroupBox groupBox16;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.PictureBox cmd_In_Apply;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.GroupBox groupBox17;

		// Token: 0x0400017B RID: 379
		private global::System.Windows.Forms.PictureBox cmd_In_Search;

		// Token: 0x0400017C RID: 380
		private global::System.Windows.Forms.TextBox txtInputSN_In;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.Label label16;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.Label label26;

		// Token: 0x0400017F RID: 383
		private global::System.Windows.Forms.ComboBox cmbType;

		// Token: 0x04000180 RID: 384
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000181 RID: 385
		private global::System.Windows.Forms.Label label31;

		// Token: 0x04000182 RID: 386
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000183 RID: 387
		private global::System.Windows.Forms.TabPage tab_YieldReport;

		// Token: 0x04000184 RID: 388
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x04000185 RID: 389
		private global::System.Windows.Forms.GroupBox groupBox14;

		// Token: 0x04000186 RID: 390
		private global::System.Windows.Forms.Label label38;

		// Token: 0x04000187 RID: 391
		private global::System.Windows.Forms.DateTimePicker date_End;

		// Token: 0x04000188 RID: 392
		private global::System.Windows.Forms.DateTimePicker date_Start;

		// Token: 0x04000189 RID: 393
		private global::System.Windows.Forms.GroupBox groupBox18;

		// Token: 0x0400018A RID: 394
		private global::System.Windows.Forms.PictureBox cmd_Yield_Excel;

		// Token: 0x0400018B RID: 395
		private global::System.Windows.Forms.GroupBox groupBox19;

		// Token: 0x0400018C RID: 396
		private global::System.Windows.Forms.PictureBox cmd_Yield_Search;

		// Token: 0x0400018D RID: 397
		private global::System.Windows.Forms.TextBox txtSearchLotid;

		// Token: 0x0400018E RID: 398
		private global::System.Windows.Forms.GroupBox groupBox20;

		// Token: 0x0400018F RID: 399
		private global::SourceGrid.Grid gridLotList;

		// Token: 0x04000190 RID: 400
		private global::System.Windows.Forms.GroupBox groupBox22;

		// Token: 0x04000191 RID: 401
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000192 RID: 402
		private global::System.Windows.Forms.GroupBox groupBox21;

		// Token: 0x04000193 RID: 403
		private global::System.Windows.Forms.PictureBox pbCheckIn;

		// Token: 0x04000194 RID: 404
		private global::System.Windows.Forms.TabControl tabControl;

		// Token: 0x04000195 RID: 405
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x04000196 RID: 406
		private global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x04000197 RID: 407
		private global::System.Windows.Forms.Label label42;

		// Token: 0x04000198 RID: 408
		private global::System.Windows.Forms.TextBox txt_In_Dcc;

		// Token: 0x04000199 RID: 409
		private global::System.Windows.Forms.Label label41;

		// Token: 0x0400019A RID: 410
		private global::System.Windows.Forms.TextBox txt_In_Config;

		// Token: 0x0400019B RID: 411
		private global::System.Windows.Forms.TextBox txt_In_Comment;

		// Token: 0x0400019C RID: 412
		private global::System.Windows.Forms.Label label33;

		// Token: 0x0400019D RID: 413
		private global::System.Windows.Forms.Label label27;

		// Token: 0x0400019E RID: 414
		private global::System.Windows.Forms.TextBox txt_In_Status;

		// Token: 0x0400019F RID: 415
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.TextBox txt_In_StopTime;

		// Token: 0x040001A1 RID: 417
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.TextBox txt_In_StartTime;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040001A4 RID: 420
		private global::System.Windows.Forms.TextBox txt_In_FailingMsg;

		// Token: 0x040001A5 RID: 421
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040001A6 RID: 422
		private global::System.Windows.Forms.TextBox txt_In_FailTests;

		// Token: 0x040001A7 RID: 423
		private global::System.Windows.Forms.TextBox txt_In_SWVersion;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.TextBox txt_In_SN;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.TextBox txt_In_TestStation;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040001AB RID: 427
		private global::System.Windows.Forms.Label label17;

		// Token: 0x040001AC RID: 428
		private global::System.Windows.Forms.TextBox txt_In_Product;

		// Token: 0x040001AD RID: 429
		private global::System.Windows.Forms.Label label22;

		// Token: 0x040001AE RID: 430
		private global::System.Windows.Forms.Label label28;

		// Token: 0x040001AF RID: 431
		private global::System.Windows.Forms.Label label30;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.TextBox txt_In_StationID;

		// Token: 0x040001B1 RID: 433
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x040001B2 RID: 434
		private global::System.Windows.Forms.GroupBox gbExcel;

		// Token: 0x040001B3 RID: 435
		private global::System.Windows.Forms.PictureBox pbRequestExcel;

		// Token: 0x040001B4 RID: 436
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x040001B5 RID: 437
		private global::System.Windows.Forms.PictureBox pbComment;

		// Token: 0x040001B6 RID: 438
		private global::System.Windows.Forms.TextBox tbConfig;

		// Token: 0x040001B7 RID: 439
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001B8 RID: 440
		private global::System.Windows.Forms.TextBox tbDcc;

		// Token: 0x040001B9 RID: 441
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040001BA RID: 442
		private global::System.Windows.Forms.CheckBox cbAll;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040001BC RID: 444
		private global::SourceGrid.Grid gridUnitHistory;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x040001BE RID: 446
		private global::System.Windows.Forms.PictureBox pb2DId;

		// Token: 0x040001BF RID: 447
		private global::Amkor.CADModules.ESIModule.Control.CheckedComboBox chkCmbReportType;

		// Token: 0x040001C0 RID: 448
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040001C1 RID: 449
		private global::System.Windows.Forms.Splitter splitter2;

		// Token: 0x040001C2 RID: 450
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040001C3 RID: 451
		private global::System.Windows.Forms.Button btnLotSearch;

		// Token: 0x040001C4 RID: 452
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x040001C5 RID: 453
		private global::System.Windows.Forms.GroupBox groupBox10;

		// Token: 0x040001C6 RID: 454
		private global::System.Windows.Forms.Panel panelView;

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.Label label23;

		// Token: 0x040001C8 RID: 456
		private global::System.Windows.Forms.ComboBox cmbTestType;

		// Token: 0x040001C9 RID: 457
		private global::System.Windows.Forms.Label label21;

		// Token: 0x040001CA RID: 458
		private global::System.Windows.Forms.ComboBox cmbPF;

		// Token: 0x040001CB RID: 459
		private global::System.Windows.Forms.TextBox txtSearchSN;

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040001CD RID: 461
		private global::Amkor.CADModules.ESIModule.Control.CheckedComboBox chkCmbOperation;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.Panel panel12;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.Label label45;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.TabControl tab_ReportView;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.RadioButton rdoSN;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.RadioButton rdoLot;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.RadioButton rdoDate;

		// Token: 0x040001D5 RID: 469
		private global::System.Windows.Forms.TabPage tab_BT_Monitoring;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.Panel panel14;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.GroupBox groupBox12;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.GroupBox groupBox13;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.PictureBox cmd_BTOQC_Search;

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.GroupBox groupBox15;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.PictureBox cmd_BTOQC_Excel;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.GroupBox groupBox23;

		// Token: 0x040001DE RID: 478
		private global::SourceGrid.Grid gridBTMonitoring;

		// Token: 0x040001DF RID: 479
		private global::System.Windows.Forms.DateTimePicker dateTime_Month;

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.GroupBox groupBox24;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.PictureBox cmd_RawData_Excel;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.Label label19;

		// Token: 0x040001E3 RID: 483
		private global::Amkor.CADModules.ESIModule.Control.CheckedComboBox chkcmbATETester;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.Label label20;

		// Token: 0x040001E5 RID: 485
		private global::Amkor.CADModules.ESIModule.Control.CheckedComboBox chkcmb_BTOQCDate;

		// Token: 0x040001E6 RID: 486
		private global::System.Windows.Forms.RadioButton rdo_BT_Month;

		// Token: 0x040001E7 RID: 487
		private global::System.Windows.Forms.RadioButton rdo_BT_SelectedDate;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.Label label24;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.DateTimePicker BT_Date_End;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.DateTimePicker BT_Date_Start;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.GroupBox groupBox25;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.RadioButton rdoLoadSN;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x040001EE RID: 494
		private global::System.Windows.Forms.RadioButton rdoLoadLot;

		// Token: 0x040001EF RID: 495
		private global::System.Windows.Forms.TabPage tab_UploadUnit;

		// Token: 0x040001F0 RID: 496
		private global::System.Windows.Forms.Panel panel17;

		// Token: 0x040001F1 RID: 497
		private global::System.Windows.Forms.Panel panel20;

		// Token: 0x040001F2 RID: 498
		private global::System.Windows.Forms.GroupBox groupBox30;

		// Token: 0x040001F3 RID: 499
		private global::SourceGrid.Grid gridUploadSNList;

		// Token: 0x040001F4 RID: 500
		private global::System.Windows.Forms.Splitter splitter3;

		// Token: 0x040001F5 RID: 501
		private global::System.Windows.Forms.Panel panel16;

		// Token: 0x040001F6 RID: 502
		private global::System.Windows.Forms.GroupBox groupBox26;

		// Token: 0x040001F7 RID: 503
		private global::System.Windows.Forms.GroupBox grpUpload;

		// Token: 0x040001F8 RID: 504
		private global::System.Windows.Forms.PictureBox cmd_Upload_Data;

		// Token: 0x040001F9 RID: 505
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040001FA RID: 506
		private global::System.Windows.Forms.TextBox txtUploadLot;

		// Token: 0x040001FB RID: 507
		private global::System.Windows.Forms.GroupBox groupBox28;

		// Token: 0x040001FC RID: 508
		private global::System.Windows.Forms.PictureBox cmd_Download_Data;

		// Token: 0x040001FD RID: 509
		private global::System.Windows.Forms.GroupBox groupBox31;

		// Token: 0x040001FE RID: 510
		private global::System.Windows.Forms.PictureBox cmd_UploadApply;

		// Token: 0x040001FF RID: 511
		private global::System.Windows.Forms.Label label25;

		// Token: 0x04000200 RID: 512
		private global::System.Windows.Forms.TextBox txtDcc;

		// Token: 0x04000201 RID: 513
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000202 RID: 514
		private global::System.Windows.Forms.Panel panel19;

		// Token: 0x04000203 RID: 515
		private global::System.Windows.Forms.GroupBox groupBox29;

		// Token: 0x04000204 RID: 516
		private global::SourceGrid.Grid gridUploadLot;

		// Token: 0x04000205 RID: 517
		private global::System.Windows.Forms.GroupBox groupBox32;

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.TextBox txtSearchUploadLot;

		// Token: 0x04000207 RID: 519
		private global::System.Windows.Forms.GroupBox groupBox27;

		// Token: 0x04000208 RID: 520
		private global::System.Windows.Forms.PictureBox cmd_UploadSearch;

		// Token: 0x04000209 RID: 521
		private global::System.Windows.Forms.Panel panel22;

		// Token: 0x0400020A RID: 522
		private global::System.Windows.Forms.Splitter splitter4;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.Panel panel21;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.GroupBox groupBox33;

		// Token: 0x0400020D RID: 525
		private global::SourceGrid.Grid grid_SNList;

		// Token: 0x0400020E RID: 526
		private global::System.Windows.Forms.Label label29;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.TextBox txtOperation;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.RadioButton rdo_SearchUploadSN;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.RadioButton rdo_SearchUploadLot;

		// Token: 0x04000212 RID: 530
		private global::System.Windows.Forms.TextBox txtSearchUploadSN;

		// Token: 0x04000213 RID: 531
		private global::System.Windows.Forms.Label label32;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.GroupBox groupBox34;

		// Token: 0x04000216 RID: 534
		private global::System.Windows.Forms.PictureBox cmd_UploadDelete;

		// Token: 0x04000217 RID: 535
		private global::System.Windows.Forms.GroupBox groupBox35;

		// Token: 0x04000218 RID: 536
		private global::System.Windows.Forms.RadioButton rdoAll;

		// Token: 0x04000219 RID: 537
		private global::System.Windows.Forms.RadioButton rdoNormal;

		// Token: 0x0400021A RID: 538
		private global::System.Windows.Forms.RadioButton rdoAudit;

		// Token: 0x0400021B RID: 539
		private global::System.Windows.Forms.TabPage tab_CheckSummary;

		// Token: 0x0400021C RID: 540
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x0400021D RID: 541
		private global::System.Windows.Forms.GroupBox groupBox41;

		// Token: 0x0400021E RID: 542
		private global::SourceGrid.Grid gridCheckSummary;

		// Token: 0x0400021F RID: 543
		private global::System.Windows.Forms.Panel panel23;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.GroupBox groupBox36;

		// Token: 0x04000221 RID: 545
		private global::Amkor.CADModules.ESIModule.Control.CheckedComboBox chkcmb_Summary_Tester;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.GroupBox groupBox37;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.RadioButton rdo_Setup_Month;

		// Token: 0x04000224 RID: 548
		private global::System.Windows.Forms.RadioButton rdo_Setup_SelectDate;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.DateTimePicker dateTime_SetupMonth;

		// Token: 0x04000226 RID: 550
		private global::System.Windows.Forms.Label label36;

		// Token: 0x04000227 RID: 551
		private global::Amkor.CADModules.ESIModule.Control.CheckedComboBox chkcmb_SetupDate;

		// Token: 0x04000228 RID: 552
		private global::System.Windows.Forms.DateTimePicker Setup_Date_End;

		// Token: 0x04000229 RID: 553
		private global::System.Windows.Forms.Label label37;

		// Token: 0x0400022A RID: 554
		private global::System.Windows.Forms.DateTimePicker Setup_Date_Start;

		// Token: 0x0400022B RID: 555
		private global::System.Windows.Forms.GroupBox groupBox38;

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.GroupBox groupBox39;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.PictureBox cmd_ParaSummary_Search;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.GroupBox groupBox40;

		// Token: 0x04000230 RID: 560
		private global::System.Windows.Forms.PictureBox cmd_ParaSummary_Excel;

		// Token: 0x04000231 RID: 561
		private global::System.Windows.Forms.TabPage tab_CheckSummaryStatus;

		// Token: 0x04000232 RID: 562
		private global::System.Windows.Forms.Panel panel26;

		// Token: 0x04000233 RID: 563
		private global::System.Windows.Forms.GroupBox groupBox47;

		// Token: 0x04000234 RID: 564
		private global::SourceGrid.Grid gridCheckStatus;

		// Token: 0x04000235 RID: 565
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000236 RID: 566
		private global::System.Windows.Forms.RadioButton rdo_Status_Month;

		// Token: 0x04000237 RID: 567
		private global::System.Windows.Forms.GroupBox groupBox42;

		// Token: 0x04000238 RID: 568
		private global::Amkor.CADModules.ESIModule.Control.CheckedComboBox chkcmb_Status_Tester;

		// Token: 0x04000239 RID: 569
		private global::System.Windows.Forms.GroupBox groupBox43;

		// Token: 0x0400023A RID: 570
		private global::System.Windows.Forms.RadioButton rdo_Status_SelectDate;

		// Token: 0x0400023B RID: 571
		private global::System.Windows.Forms.Label label40;

		// Token: 0x0400023C RID: 572
		private global::System.Windows.Forms.DateTimePicker Status_Date_End;

		// Token: 0x0400023D RID: 573
		private global::System.Windows.Forms.DateTimePicker Status_Date_Start;

		// Token: 0x0400023E RID: 574
		private global::System.Windows.Forms.DateTimePicker Status_Month;

		// Token: 0x0400023F RID: 575
		private global::System.Windows.Forms.GroupBox groupBox44;

		// Token: 0x04000240 RID: 576
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000241 RID: 577
		private global::Amkor.CADModules.ESIModule.Control.CheckedComboBox checkedComboBox2;

		// Token: 0x04000242 RID: 578
		private global::System.Windows.Forms.GroupBox groupBox45;

		// Token: 0x04000243 RID: 579
		private global::System.Windows.Forms.PictureBox cmd_CheckStatus_Search;

		// Token: 0x04000244 RID: 580
		private global::System.Windows.Forms.GroupBox groupBox46;

		// Token: 0x04000245 RID: 581
		private global::System.Windows.Forms.PictureBox cmd_CheckStatus_Excel;

		// Token: 0x04000246 RID: 582
		private global::System.Windows.Forms.Label label43;

		// Token: 0x04000247 RID: 583
		private global::System.Windows.Forms.GroupBox groupBox48;

		// Token: 0x04000248 RID: 584
		private global::System.Windows.Forms.ComboBox cmb_Summary_Result;

		// Token: 0x04000249 RID: 585
		private global::System.Windows.Forms.TabPage tab_CheckSummaryTrend;

		// Token: 0x0400024A RID: 586
		private global::System.Windows.Forms.Panel panel28;

		// Token: 0x0400024B RID: 587
		private global::System.Windows.Forms.DataVisualization.Charting.Chart chart_XBarChart;

		// Token: 0x0400024C RID: 588
		private global::System.Windows.Forms.Panel panel27;

		// Token: 0x0400024D RID: 589
		private global::System.Windows.Forms.GroupBox groupBox55;

		// Token: 0x0400024E RID: 590
		private global::System.Windows.Forms.TextBox txtTrendTestItem;

		// Token: 0x0400024F RID: 591
		private global::System.Windows.Forms.GroupBox groupBox49;

		// Token: 0x04000250 RID: 592
		private global::System.Windows.Forms.GroupBox groupBox50;

		// Token: 0x04000251 RID: 593
		private global::System.Windows.Forms.RadioButton rdo_Trend_Month;

		// Token: 0x04000252 RID: 594
		private global::System.Windows.Forms.RadioButton rdo_Trend_SelectDate;

		// Token: 0x04000253 RID: 595
		private global::System.Windows.Forms.Label label47;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.DateTimePicker Trend_Month;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.DateTimePicker Trend_Date_End;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.DateTimePicker Trend_Date_Start;

		// Token: 0x04000257 RID: 599
		private global::System.Windows.Forms.GroupBox groupBox51;

		// Token: 0x04000258 RID: 600
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.GroupBox groupBox52;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.PictureBox cmd_Trend_Search;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.GroupBox groupBox53;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.PictureBox cmd_Trend_Excel;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.ComboBox cmb_Trend_TestItem;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.ComboBox cmb_Trend_Tester;

		// Token: 0x0400025F RID: 607
		private global::System.Windows.Forms.Panel panel29;

		// Token: 0x04000260 RID: 608
		private global::System.Windows.Forms.DataVisualization.Charting.Chart chart_RChart;

		// Token: 0x04000261 RID: 609
		private global::System.Windows.Forms.GroupBox groupBox57;

		// Token: 0x04000262 RID: 610
		private global::System.Windows.Forms.GroupBox groupBox56;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.Panel panel30;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.Splitter splitter5;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.GroupBox groupBox54;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.ComboBox cmb_Trend_Device;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.GroupBox groupBox58;

		// Token: 0x04000268 RID: 616
		private global::System.Windows.Forms.ComboBox cmb_Status_Tester;

		// Token: 0x04000269 RID: 617
		private global::System.Windows.Forms.GroupBox groupBox59;

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.ComboBox cmb_Summary_Device;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.GroupBox groupBox60;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.PictureBox cmd_AddPara;
	}
}
