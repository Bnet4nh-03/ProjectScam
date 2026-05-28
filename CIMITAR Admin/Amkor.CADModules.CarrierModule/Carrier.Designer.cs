namespace Amkor.CADModules.CarrierModule
{
	// Token: 0x0200002D RID: 45
	public partial class Carrier : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x060001FF RID: 511 RVA: 0x0002A717 File Offset: 0x00028917
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0002A738 File Offset: 0x00028938
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.CarrierModule.Carrier));
			global::System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new global::System.Windows.Forms.DataVisualization.Charting.ChartArea();
			global::System.Windows.Forms.DataVisualization.Charting.Legend legend = new global::System.Windows.Forms.DataVisualization.Charting.Legend();
			global::System.Windows.Forms.DataVisualization.Charting.Title title = new global::System.Windows.Forms.DataVisualization.Charting.Title();
			global::System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new global::System.Windows.Forms.DataVisualization.Charting.ChartArea();
			global::System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new global::System.Windows.Forms.DataVisualization.Charting.Legend();
			global::System.Windows.Forms.DataVisualization.Charting.Title title2 = new global::System.Windows.Forms.DataVisualization.Charting.Title();
			global::System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new global::System.Windows.Forms.DataVisualization.Charting.ChartArea();
			global::System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new global::System.Windows.Forms.DataVisualization.Charting.Legend();
			global::System.Windows.Forms.DataVisualization.Charting.Series series = new global::System.Windows.Forms.DataVisualization.Charting.Series();
			global::System.Windows.Forms.DataVisualization.Charting.Title title3 = new global::System.Windows.Forms.DataVisualization.Charting.Title();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.gridCarrierList = new global::SourceGrid.Grid();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.groupBox31 = new global::System.Windows.Forms.GroupBox();
			this.cmdUserSetCarrier = new global::System.Windows.Forms.PictureBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cmbOpCode = new global::System.Windows.Forms.ComboBox();
			this.cmbCarrierType = new global::System.Windows.Forms.ComboBox();
			this.cmbTester = new global::System.Windows.Forms.ComboBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.cmbCorrelation = new global::System.Windows.Forms.ComboBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.txtBarcode = new global::System.Windows.Forms.TextBox();
			this.cmbStatus = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cmbDevice = new global::System.Windows.Forms.ComboBox();
			this.cmbCustomer = new global::System.Windows.Forms.ComboBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.cmdAdd = new global::System.Windows.Forms.PictureBox();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.cmdExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cmdSearch = new global::System.Windows.Forms.PictureBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label_copyright = new global::System.Windows.Forms.Label();
			this.splitter10 = new global::System.Windows.Forms.Splitter();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label12 = new global::System.Windows.Forms.Label();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.backgroundWorker1 = new global::System.ComponentModel.BackgroundWorker();
			this.tabCarrier = new global::System.Windows.Forms.TabControl();
			this.tpEnrollCarrier = new global::System.Windows.Forms.TabPage();
			this.tpChangeStatusCarrier = new global::System.Windows.Forms.TabPage();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.gridCarrierHistoryList = new global::SourceGrid.Grid();
			this.splitter2 = new global::System.Windows.Forms.Splitter();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.txtMCN = new global::System.Windows.Forms.TextBox();
			this.label19 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.button1 = new global::System.Windows.Forms.Button();
			this.txtStatusMemo = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label24 = new global::System.Windows.Forms.Label();
			this.txtRevision = new global::System.Windows.Forms.TextBox();
			this.txtStatusCorrelation = new global::System.Windows.Forms.TextBox();
			this.txtStatusSite = new global::System.Windows.Forms.TextBox();
			this.txtStatusCarrierStatus = new global::System.Windows.Forms.TextBox();
			this.txtStatusTouchDownCnt = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.txtStatusCarrierType = new global::System.Windows.Forms.TextBox();
			this.txtStatusCustomer = new global::System.Windows.Forms.TextBox();
			this.txtStatusLimitrepairCnt = new global::System.Windows.Forms.TextBox();
			this.label25 = new global::System.Windows.Forms.Label();
			this.txtStatusLimitCleanCnt = new global::System.Windows.Forms.TextBox();
			this.label26 = new global::System.Windows.Forms.Label();
			this.txtStatusTesterName = new global::System.Windows.Forms.TextBox();
			this.label21 = new global::System.Windows.Forms.Label();
			this.txtStatusOpCode = new global::System.Windows.Forms.TextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.txtStatusCarrierNo = new global::System.Windows.Forms.TextBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.label20 = new global::System.Windows.Forms.Label();
			this.txtStatusPkgType = new global::System.Windows.Forms.TextBox();
			this.label22 = new global::System.Windows.Forms.Label();
			this.label23 = new global::System.Windows.Forms.Label();
			this.txtStatusCleanCnt = new global::System.Windows.Forms.TextBox();
			this.label27 = new global::System.Windows.Forms.Label();
			this.txtStatusrepairCnt = new global::System.Windows.Forms.TextBox();
			this.label28 = new global::System.Windows.Forms.Label();
			this.label29 = new global::System.Windows.Forms.Label();
			this.label30 = new global::System.Windows.Forms.Label();
			this.txtStatusDevice = new global::System.Windows.Forms.TextBox();
			this.splitter1 = new global::System.Windows.Forms.Splitter();
			this.panelScan = new global::System.Windows.Forms.Panel();
			this.panelSubInfo = new global::System.Windows.Forms.Panel();
			this.grpSelectStatus = new global::System.Windows.Forms.GroupBox();
			this.cmbSelectStatus = new global::System.Windows.Forms.ComboBox();
			this.gridClassifiedBlacklist = new global::SourceGrid.Grid();
			this.gridClassifiedClean = new global::SourceGrid.Grid();
			this.panelRepairCode = new global::System.Windows.Forms.Panel();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.panelSIBDamage = new global::System.Windows.Forms.Panel();
			this.cmbSelectStatus2 = new global::System.Windows.Forms.ComboBox();
			this.label35 = new global::System.Windows.Forms.Label();
			this.label57 = new global::System.Windows.Forms.Label();
			this.label56 = new global::System.Windows.Forms.Label();
			this.cmbSuspectCause = new global::System.Windows.Forms.ComboBox();
			this.cmbDamage = new global::System.Windows.Forms.ComboBox();
			this.grpRepairReason = new global::System.Windows.Forms.GroupBox();
			this.panelPrintInfo = new global::System.Windows.Forms.Panel();
			this.txtSite2Yield = new global::System.Windows.Forms.TextBox();
			this.label37 = new global::System.Windows.Forms.Label();
			this.txtSite1Yield = new global::System.Windows.Forms.TextBox();
			this.txtSite1Reason = new global::System.Windows.Forms.TextBox();
			this.label40 = new global::System.Windows.Forms.Label();
			this.btnLabelPrint = new global::System.Windows.Forms.Button();
			this.txtSite2Reason = new global::System.Windows.Forms.TextBox();
			this.cmdAddCode = new global::System.Windows.Forms.PictureBox();
			this.txtRepairCode = new global::System.Windows.Forms.TextBox();
			this.grpLoadTester = new global::System.Windows.Forms.GroupBox();
			this.cmbLoadTester = new global::System.Windows.Forms.ComboBox();
			this.panel14 = new global::System.Windows.Forms.Panel();
			this.panelDefectUpload = new global::System.Windows.Forms.Panel();
			this.groupBox56 = new global::System.Windows.Forms.GroupBox();
			this.cmdUploadFile1 = new global::System.Windows.Forms.PictureBox();
			this.groupBox44 = new global::System.Windows.Forms.GroupBox();
			this.cmdRemoveFile = new global::System.Windows.Forms.PictureBox();
			this.pbUploadImage = new global::System.Windows.Forms.PictureBox();
			this.groupBox43 = new global::System.Windows.Forms.GroupBox();
			this.cmdUploadFile = new global::System.Windows.Forms.PictureBox();
			this.txtAttachFile = new global::System.Windows.Forms.TextBox();
			this.groupBox10 = new global::System.Windows.Forms.GroupBox();
			this.cmdStatusSearch = new global::System.Windows.Forms.PictureBox();
			this.groupBox9 = new global::System.Windows.Forms.GroupBox();
			this.cmdStatusApply = new global::System.Windows.Forms.PictureBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.cmdStatusExcel = new global::System.Windows.Forms.PictureBox();
			this.panelBarcode = new global::System.Windows.Forms.Panel();
			this.grpScan = new global::System.Windows.Forms.GroupBox();
			this.groupCarrier = new global::System.Windows.Forms.GroupBox();
			this.label32 = new global::System.Windows.Forms.Label();
			this.txtMainCarrier = new global::System.Windows.Forms.TextBox();
			this.chkAutoSelect = new global::System.Windows.Forms.CheckBox();
			this.groupSIB = new global::System.Windows.Forms.GroupBox();
			this.lblAssignSIB2 = new global::System.Windows.Forms.Label();
			this.lblAssignSIB1 = new global::System.Windows.Forms.Label();
			this.txtAssignSIB2 = new global::System.Windows.Forms.TextBox();
			this.txtAssignSIB1 = new global::System.Windows.Forms.TextBox();
			this.lblSIB2 = new global::System.Windows.Forms.Label();
			this.txtStatusSIB2Barcode = new global::System.Windows.Forms.TextBox();
			this.lblSIB1 = new global::System.Windows.Forms.Label();
			this.txtStatusSIB1Barcode = new global::System.Windows.Forms.TextBox();
			this.chkMultiBarcode = new global::System.Windows.Forms.CheckBox();
			this.chkBarcode = new global::System.Windows.Forms.CheckBox();
			this.lblBarcode = new global::System.Windows.Forms.Label();
			this.txtStatusBarcode = new global::System.Windows.Forms.TextBox();
			this.panelMenu = new global::System.Windows.Forms.Panel();
			this.rdoEngr = new global::System.Windows.Forms.RadioButton();
			this.rdoWareHouse = new global::System.Windows.Forms.RadioButton();
			this.rdoBatchChange = new global::System.Windows.Forms.RadioButton();
			this.rdoIdle = new global::System.Windows.Forms.RadioButton();
			this.rdoDefectStart = new global::System.Windows.Forms.RadioButton();
			this.rdoLoad = new global::System.Windows.Forms.RadioButton();
			this.rdoCleanStart = new global::System.Windows.Forms.RadioButton();
			this.rdorepairStart = new global::System.Windows.Forms.RadioButton();
			this.rdorepairEnd = new global::System.Windows.Forms.RadioButton();
			this.tpCarrierViewer = new global::System.Windows.Forms.TabPage();
			this.panel43 = new global::System.Windows.Forms.Panel();
			this.groupBox58 = new global::System.Windows.Forms.GroupBox();
			this.panel45 = new global::System.Windows.Forms.Panel();
			this.groupBox61 = new global::System.Windows.Forms.GroupBox();
			this.gridViewerList = new global::SourceGrid.Grid();
			this.panel44 = new global::System.Windows.Forms.Panel();
			this.groupBox62 = new global::System.Windows.Forms.GroupBox();
			this.panel41 = new global::System.Windows.Forms.Panel();
			this.gridViewerInfo = new global::SourceGrid.Grid();
			this.groupBox70 = new global::System.Windows.Forms.GroupBox();
			this.cmbViewerBarcode = new global::System.Windows.Forms.TextBox();
			this.groupBox69 = new global::System.Windows.Forms.GroupBox();
			this.cmbGroup = new global::System.Windows.Forms.ComboBox();
			this.panel42 = new global::System.Windows.Forms.Panel();
			this.ViewerList = new global::System.Windows.Forms.GroupBox();
			this.pnlViewer = new global::System.Windows.Forms.Panel();
			this.rdoViewDefect = new global::System.Windows.Forms.RadioButton();
			this.rdoViewEngr = new global::System.Windows.Forms.RadioButton();
			this.rdoViewWareHouse = new global::System.Windows.Forms.RadioButton();
			this.groupBox63 = new global::System.Windows.Forms.GroupBox();
			this.cmbProduct2 = new global::System.Windows.Forms.ComboBox();
			this.groupBox60 = new global::System.Windows.Forms.GroupBox();
			this.cmdWareHouseExport = new global::System.Windows.Forms.PictureBox();
			this.groupBox59 = new global::System.Windows.Forms.GroupBox();
			this.cmdWareHouseSearch = new global::System.Windows.Forms.PictureBox();
			this.tpViewCarrierData = new global::System.Windows.Forms.TabPage();
			this.splitter3 = new global::System.Windows.Forms.Splitter();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.chart_CarrierView = new global::System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.gridInventoryList = new global::SourceGrid.Grid();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.groupBox53 = new global::System.Windows.Forms.GroupBox();
			this.cmbFailMode = new global::System.Windows.Forms.ComboBox();
			this.groupBox30 = new global::System.Windows.Forms.GroupBox();
			this.cmbInventoryType = new global::System.Windows.Forms.ComboBox();
			this.groupBox15 = new global::System.Windows.Forms.GroupBox();
			this.cmdViewExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox12 = new global::System.Windows.Forms.GroupBox();
			this.rdoMonth = new global::System.Windows.Forms.RadioButton();
			this.rdoPeriod = new global::System.Windows.Forms.RadioButton();
			this.rdoWeek = new global::System.Windows.Forms.RadioButton();
			this.rdoDay = new global::System.Windows.Forms.RadioButton();
			this.dtp_End = new global::System.Windows.Forms.DateTimePicker();
			this.dtp_Start = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox14 = new global::System.Windows.Forms.GroupBox();
			this.cmbProduct = new global::System.Windows.Forms.ComboBox();
			this.groupBox13 = new global::System.Windows.Forms.GroupBox();
			this.cmdViewSearch = new global::System.Windows.Forms.PictureBox();
			this.tpCarrierHistory = new global::System.Windows.Forms.TabPage();
			this.panel16 = new global::System.Windows.Forms.Panel();
			this.panel17 = new global::System.Windows.Forms.Panel();
			this.groupBox18 = new global::System.Windows.Forms.GroupBox();
			this.gridSearchHistory = new global::SourceGrid.Grid();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.groupBox19 = new global::System.Windows.Forms.GroupBox();
			this.chkHistoryCarrierBarcode = new global::System.Windows.Forms.CheckBox();
			this.cmbHistoryCarrierCorrelation = new global::System.Windows.Forms.ComboBox();
			this.cmbHistoryCarrierTester = new global::System.Windows.Forms.ComboBox();
			this.cmbHistoryCarrierOpCode = new global::System.Windows.Forms.ComboBox();
			this.label61 = new global::System.Windows.Forms.Label();
			this.label60 = new global::System.Windows.Forms.Label();
			this.label59 = new global::System.Windows.Forms.Label();
			this.cmbHistoryCarrierCustomer = new global::System.Windows.Forms.ComboBox();
			this.label58 = new global::System.Windows.Forms.Label();
			this.groupBox29 = new global::System.Windows.Forms.GroupBox();
			this.cmdUserSetHistory = new global::System.Windows.Forms.PictureBox();
			this.cmbHistoryCarrierDevice = new global::System.Windows.Forms.Label();
			this.cmbHistoryCarrierType = new global::System.Windows.Forms.ComboBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.cmbHistoryProduct = new global::System.Windows.Forms.ComboBox();
			this.groupBox11 = new global::System.Windows.Forms.GroupBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.chkDate = new global::System.Windows.Forms.CheckBox();
			this.dtp_End_Histroy = new global::System.Windows.Forms.DateTimePicker();
			this.dtp_Start_History = new global::System.Windows.Forms.DateTimePicker();
			this.label17 = new global::System.Windows.Forms.Label();
			this.txtHistoryBarcode = new global::System.Windows.Forms.TextBox();
			this.chkcmbHistoryStatus = new global::Amkor.CADModules.CarrierModule.Control.CheckedComboBox();
			this.groupBox21 = new global::System.Windows.Forms.GroupBox();
			this.cmdHistoryExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox22 = new global::System.Windows.Forms.GroupBox();
			this.cmdHistorySearch = new global::System.Windows.Forms.PictureBox();
			this.tpSIBStatus = new global::System.Windows.Forms.TabPage();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.panel19 = new global::System.Windows.Forms.Panel();
			this.groupBox16 = new global::System.Windows.Forms.GroupBox();
			this.gridSIBStatusList = new global::SourceGrid.Grid();
			this.panel22 = new global::System.Windows.Forms.Panel();
			this.groupBox33 = new global::System.Windows.Forms.GroupBox();
			this.cmdModifyDefect = new global::System.Windows.Forms.PictureBox();
			this.cmbSIBPeriodDate = new global::System.Windows.Forms.ComboBox();
			this.panelDetail = new global::System.Windows.Forms.Panel();
			this.chkDefectCarrier = new global::System.Windows.Forms.CheckBox();
			this.chkDefectSIB = new global::System.Windows.Forms.CheckBox();
			this.rdoTotalData = new global::System.Windows.Forms.RadioButton();
			this.rdoPeriodData = new global::System.Windows.Forms.RadioButton();
			this.splitter4 = new global::System.Windows.Forms.Splitter();
			this.panel21 = new global::System.Windows.Forms.Panel();
			this.chart_SIBView = new global::System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel20 = new global::System.Windows.Forms.Panel();
			this.groupBox25 = new global::System.Windows.Forms.GroupBox();
			this.rdoMonth_SIB = new global::System.Windows.Forms.RadioButton();
			this.rdoPeriod_SIB = new global::System.Windows.Forms.RadioButton();
			this.rdoWeek_SIB = new global::System.Windows.Forms.RadioButton();
			this.rdoDay_SIB = new global::System.Windows.Forms.RadioButton();
			this.dtp_end_SIB = new global::System.Windows.Forms.DateTimePicker();
			this.dtp_start_SIB = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox26 = new global::System.Windows.Forms.GroupBox();
			this.cmbDefectProduct = new global::System.Windows.Forms.ComboBox();
			this.groupBox24 = new global::System.Windows.Forms.GroupBox();
			this.cmdDefectSearch = new global::System.Windows.Forms.PictureBox();
			this.groupBox23 = new global::System.Windows.Forms.GroupBox();
			this.cmdSIBExcel = new global::System.Windows.Forms.PictureBox();
			this.tpBlackList = new global::System.Windows.Forms.TabPage();
			this.panel23 = new global::System.Windows.Forms.Panel();
			this.txtMgrBarcode = new global::System.Windows.Forms.TextBox();
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.groupBox17 = new global::System.Windows.Forms.GroupBox();
			this.gridMgrCarrier = new global::SourceGrid.Grid();
			this.panel26 = new global::System.Windows.Forms.Panel();
			this.groupBox20 = new global::System.Windows.Forms.GroupBox();
			this.chkBarcodeFlag = new global::System.Windows.Forms.CheckBox();
			this.cmbMgrTester = new global::System.Windows.Forms.ComboBox();
			this.label36 = new global::System.Windows.Forms.Label();
			this.cmbMgrType = new global::System.Windows.Forms.ComboBox();
			this.label33 = new global::System.Windows.Forms.Label();
			this.label31 = new global::System.Windows.Forms.Label();
			this.cmbMgrProduct = new global::System.Windows.Forms.ComboBox();
			this.cmdMgrExcel = new global::System.Windows.Forms.PictureBox();
			this.cmdMgrSearch = new global::System.Windows.Forms.PictureBox();
			this.chkcmbStatus = new global::Amkor.CADModules.CarrierModule.Control.CheckedComboBox();
			this.label34 = new global::System.Windows.Forms.Label();
			this.tpSWHistory = new global::System.Windows.Forms.TabPage();
			this.panel27 = new global::System.Windows.Forms.Panel();
			this.panel28 = new global::System.Windows.Forms.Panel();
			this.groupBox27 = new global::System.Windows.Forms.GroupBox();
			this.gridSWHistory = new global::SourceGrid.Grid();
			this.panel29 = new global::System.Windows.Forms.Panel();
			this.groupBox28 = new global::System.Windows.Forms.GroupBox();
			this.cmdDelete = new global::System.Windows.Forms.PictureBox();
			this.cmdSWAdd = new global::System.Windows.Forms.PictureBox();
			this.label39 = new global::System.Windows.Forms.Label();
			this.txtSWVersion = new global::System.Windows.Forms.TextBox();
			this.cmdSWExcel = new global::System.Windows.Forms.PictureBox();
			this.cmdSWSearch = new global::System.Windows.Forms.PictureBox();
			this.tpSocketManage = new global::System.Windows.Forms.TabPage();
			this.tc_SM_Detail = new global::System.Windows.Forms.TabControl();
			this.tpSM_tpSocketComment = new global::System.Windows.Forms.TabPage();
			this.panel30 = new global::System.Windows.Forms.Panel();
			this.grid_socket_comment = new global::SourceGrid.Grid();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.groupBox32 = new global::System.Windows.Forms.GroupBox();
			this.groupBox34 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpComment_lblSocketType = new global::System.Windows.Forms.Label();
			this.label54 = new global::System.Windows.Forms.Label();
			this.tpSM_tpComment_lblMfg = new global::System.Windows.Forms.Label();
			this.label48 = new global::System.Windows.Forms.Label();
			this.tpSM_tpComment_lblPn = new global::System.Windows.Forms.Label();
			this.label46 = new global::System.Windows.Forms.Label();
			this.tpSM_tpComment_lblBarcode = new global::System.Windows.Forms.Label();
			this.tpSM_tpComment_lblPkgType = new global::System.Windows.Forms.Label();
			this.tpSM_tpComment_lblDevice = new global::System.Windows.Forms.Label();
			this.tpSM_tpComment_lblCustomer = new global::System.Windows.Forms.Label();
			this.label41 = new global::System.Windows.Forms.Label();
			this.label42 = new global::System.Windows.Forms.Label();
			this.label43 = new global::System.Windows.Forms.Label();
			this.label44 = new global::System.Windows.Forms.Label();
			this.groupBox35 = new global::System.Windows.Forms.GroupBox();
			this.pb_comment_insert = new global::System.Windows.Forms.PictureBox();
			this.groupBox36 = new global::System.Windows.Forms.GroupBox();
			this.pb_comment_excel = new global::System.Windows.Forms.PictureBox();
			this.splitter5 = new global::System.Windows.Forms.Splitter();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.listBox_Socket = new global::System.Windows.Forms.ListBox();
			this.panel32 = new global::System.Windows.Forms.Panel();
			this.btn_search = new global::System.Windows.Forms.Button();
			this.tb_barcode = new global::System.Windows.Forms.TextBox();
			this.panel35 = new global::System.Windows.Forms.Panel();
			this.cbx_bottom = new global::System.Windows.Forms.CheckBox();
			this.cbx_top = new global::System.Windows.Forms.CheckBox();
			this.label47 = new global::System.Windows.Forms.Label();
			this.panel31 = new global::System.Windows.Forms.Panel();
			this.label38 = new global::System.Windows.Forms.Label();
			this.tpSM_tpEnrollSocket = new global::System.Windows.Forms.TabPage();
			this.panel34 = new global::System.Windows.Forms.Panel();
			this.groupBox42 = new global::System.Windows.Forms.GroupBox();
			this.gridSocketList = new global::SourceGrid.Grid();
			this.panel12 = new global::System.Windows.Forms.Panel();
			this.groupBox37 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpEnroll_cmbSocketType = new global::System.Windows.Forms.ComboBox();
			this.label50 = new global::System.Windows.Forms.Label();
			this.groupBox38 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpEnroll_btnSetting = new global::System.Windows.Forms.PictureBox();
			this.tpSM_tpEnroll_txtBarcode = new global::System.Windows.Forms.TextBox();
			this.tpSM_tpEnroll_cmbStatus = new global::System.Windows.Forms.ComboBox();
			this.label49 = new global::System.Windows.Forms.Label();
			this.tpSM_tpEnroll_cmbDevice = new global::System.Windows.Forms.ComboBox();
			this.tpSM_tpEnroll_cmbCustomer = new global::System.Windows.Forms.ComboBox();
			this.label51 = new global::System.Windows.Forms.Label();
			this.groupBox39 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpEnroll_btnAdd = new global::System.Windows.Forms.PictureBox();
			this.groupBox40 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpEnroll_btnExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox41 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpEnroll_btnSearch = new global::System.Windows.Forms.PictureBox();
			this.label52 = new global::System.Windows.Forms.Label();
			this.label53 = new global::System.Windows.Forms.Label();
			this.tpSM_tpPeriodComment = new global::System.Windows.Forms.TabPage();
			this.panel37 = new global::System.Windows.Forms.Panel();
			this.groupBox50 = new global::System.Windows.Forms.GroupBox();
			this.gridPeriodSocketList = new global::SourceGrid.Grid();
			this.panel36 = new global::System.Windows.Forms.Panel();
			this.groupBox45 = new global::System.Windows.Forms.GroupBox();
			this.groupBox51 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpPeriod_cmbCompletedCommentStatus = new global::System.Windows.Forms.ComboBox();
			this.tpSM_tpPeriod_dtStart = new global::System.Windows.Forms.DateTimePicker();
			this.label55 = new global::System.Windows.Forms.Label();
			this.tpSM_tpPeriod_dtEnd = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox46 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpPeriod_btnSetting = new global::System.Windows.Forms.PictureBox();
			this.groupBox48 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpPeriod_btnExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox49 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpPeriod_btnSearch = new global::System.Windows.Forms.PictureBox();
			this.tpSM_tpCompledTrend = new global::System.Windows.Forms.TabPage();
			this.panel40 = new global::System.Windows.Forms.Panel();
			this.chartComptedTrend = new global::System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel39 = new global::System.Windows.Forms.Panel();
			this.gridCompletedList = new global::SourceGrid.Grid();
			this.panel38 = new global::System.Windows.Forms.Panel();
			this.groupBox47 = new global::System.Windows.Forms.GroupBox();
			this.groupBox52 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpCompleted_dtStart = new global::System.Windows.Forms.DateTimePicker();
			this.tpSM_tpCompleted_dtEnd = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox54 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpCompleted_btnExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox55 = new global::System.Windows.Forms.GroupBox();
			this.tpSM_tpCompleted_btnSearch = new global::System.Windows.Forms.PictureBox();
			this.panel33 = new global::System.Windows.Forms.Panel();
			this.label45 = new global::System.Windows.Forms.Label();
			this.tpWeeklyReport = new global::System.Windows.Forms.TabPage();
			this.groupBox65 = new global::System.Windows.Forms.GroupBox();
			this.gridWeeklyReport = new global::SourceGrid.Grid();
			this.label62 = new global::System.Windows.Forms.Label();
			this.WeeklyReportPanel = new global::System.Windows.Forms.Panel();
			this.groupBox83 = new global::System.Windows.Forms.GroupBox();
			this.pictureBox5 = new global::System.Windows.Forms.PictureBox();
			this.groupBox68 = new global::System.Windows.Forms.GroupBox();
			this.cmbProduct3 = new global::System.Windows.Forms.ComboBox();
			this.groupBox66 = new global::System.Windows.Forms.GroupBox();
			this.cmbWeeklyReportExport = new global::System.Windows.Forms.PictureBox();
			this.groupBox67 = new global::System.Windows.Forms.GroupBox();
			this.cmdWeeklyReportSearch = new global::System.Windows.Forms.PictureBox();
			this.groupBox64 = new global::System.Windows.Forms.GroupBox();
			this.WeeklyReportStatusPanel = new global::System.Windows.Forms.Panel();
			this.rdoWRDetectCarrier = new global::System.Windows.Forms.RadioButton();
			this.rdoWRTotal = new global::System.Windows.Forms.RadioButton();
			this.rdoWRSipCnt = new global::System.Windows.Forms.RadioButton();
			this.rdoWRSipFail = new global::System.Windows.Forms.RadioButton();
			this.dtp_week_End = new global::System.Windows.Forms.DateTimePicker();
			this.dtp_week_Start = new global::System.Windows.Forms.DateTimePicker();
			this.tpATPList = new global::System.Windows.Forms.TabPage();
			this.panel48 = new global::System.Windows.Forms.Panel();
			this.groupBox76 = new global::System.Windows.Forms.GroupBox();
			this.gridATPlist = new global::SourceGrid.Grid();
			this.panel47 = new global::System.Windows.Forms.Panel();
			this.groupBox79 = new global::System.Windows.Forms.GroupBox();
			this.pnlATPviewer = new global::System.Windows.Forms.Panel();
			this.rdoATPTotalList = new global::System.Windows.Forms.RadioButton();
			this.rdoATPDaily = new global::System.Windows.Forms.RadioButton();
			this.groupBox75 = new global::System.Windows.Forms.GroupBox();
			this.gridATPsummary = new global::SourceGrid.Grid();
			this.panel46 = new global::System.Windows.Forms.Panel();
			this.groupBox78 = new global::System.Windows.Forms.GroupBox();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.groupBox77 = new global::System.Windows.Forms.GroupBox();
			this.cmbATPexcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox74 = new global::System.Windows.Forms.GroupBox();
			this.cmbATPsearch = new global::System.Windows.Forms.PictureBox();
			this.groupBox73 = new global::System.Windows.Forms.GroupBox();
			this.dptATPend = new global::System.Windows.Forms.DateTimePicker();
			this.dptATPstart = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox72 = new global::System.Windows.Forms.GroupBox();
			this.cmbATPproduct = new global::System.Windows.Forms.ComboBox();
			this.groupBox57 = new global::System.Windows.Forms.GroupBox();
			this.txtATPname = new global::System.Windows.Forms.TextBox();
			this.cmbATPname = new global::System.Windows.Forms.ComboBox();
			this.groupBox71 = new global::System.Windows.Forms.GroupBox();
			this.txtATPhostname = new global::System.Windows.Forms.TextBox();
			this.cmbATPhostname = new global::System.Windows.Forms.ComboBox();
			this.tpCorrHistory = new global::System.Windows.Forms.TabPage();
			this.panel49 = new global::System.Windows.Forms.Panel();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.groupBox80 = new global::System.Windows.Forms.GroupBox();
			this.gridCorrList = new global::Telerik.WinControls.UI.RadGridView();
			this.groupBox90 = new global::System.Windows.Forms.GroupBox();
			this.gridCorrHistory = new global::Telerik.WinControls.UI.RadGridView();
			this.panel51 = new global::System.Windows.Forms.Panel();
			this.groupBox81 = new global::System.Windows.Forms.GroupBox();
			this.groupBox89 = new global::System.Windows.Forms.GroupBox();
			this.cmdDelCorrHistory = new global::System.Windows.Forms.PictureBox();
			this.groupBox88 = new global::System.Windows.Forms.GroupBox();
			this.txtCorrelationPart = new global::System.Windows.Forms.TextBox();
			this.groupBox85 = new global::System.Windows.Forms.GroupBox();
			this.cmdAddCorrHistory = new global::System.Windows.Forms.PictureBox();
			this.groupBox82 = new global::System.Windows.Forms.GroupBox();
			this.label64 = new global::System.Windows.Forms.Label();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.dateTimePicker1 = new global::System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new global::System.Windows.Forms.DateTimePicker();
			this.groupBox86 = new global::System.Windows.Forms.GroupBox();
			this.cmdCorrExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox87 = new global::System.Windows.Forms.GroupBox();
			this.cmdCorrSearch = new global::System.Windows.Forms.PictureBox();
			this.groupBox84 = new global::System.Windows.Forms.GroupBox();
			this.cmbProduct4 = new global::System.Windows.Forms.ComboBox();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radGridView1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radGridView1.MasterTemplate).BeginInit();
			this.radGridView1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox31.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUserSetCarrier).BeginInit();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdAdd).BeginInit();
			this.groupBox8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdExcel).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSearch).BeginInit();
			this.panel25.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tabCarrier.SuspendLayout();
			this.tpEnrollCarrier.SuspendLayout();
			this.tpChangeStatusCarrier.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel9.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panelScan.SuspendLayout();
			this.panelSubInfo.SuspendLayout();
			this.grpSelectStatus.SuspendLayout();
			this.panelRepairCode.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.panelSIBDamage.SuspendLayout();
			this.grpRepairReason.SuspendLayout();
			this.panelPrintInfo.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdAddCode).BeginInit();
			this.grpLoadTester.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panelDefectUpload.SuspendLayout();
			this.groupBox56.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUploadFile1).BeginInit();
			this.groupBox44.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdRemoveFile).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbUploadImage).BeginInit();
			this.groupBox43.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUploadFile).BeginInit();
			this.groupBox10.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdStatusSearch).BeginInit();
			this.groupBox9.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdStatusApply).BeginInit();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdStatusExcel).BeginInit();
			this.panelBarcode.SuspendLayout();
			this.grpScan.SuspendLayout();
			this.groupCarrier.SuspendLayout();
			this.groupSIB.SuspendLayout();
			this.panelMenu.SuspendLayout();
			this.tpCarrierViewer.SuspendLayout();
			this.panel43.SuspendLayout();
			this.groupBox58.SuspendLayout();
			this.panel45.SuspendLayout();
			this.groupBox61.SuspendLayout();
			this.panel44.SuspendLayout();
			this.groupBox62.SuspendLayout();
			this.panel41.SuspendLayout();
			this.groupBox70.SuspendLayout();
			this.groupBox69.SuspendLayout();
			this.panel42.SuspendLayout();
			this.ViewerList.SuspendLayout();
			this.pnlViewer.SuspendLayout();
			this.groupBox63.SuspendLayout();
			this.groupBox60.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdWareHouseExport).BeginInit();
			this.groupBox59.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdWareHouseSearch).BeginInit();
			this.tpViewCarrierData.SuspendLayout();
			this.panel10.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.chart_CarrierView).BeginInit();
			this.panel15.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox53.SuspendLayout();
			this.groupBox30.SuspendLayout();
			this.groupBox15.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdViewExcel).BeginInit();
			this.groupBox12.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.groupBox13.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdViewSearch).BeginInit();
			this.tpCarrierHistory.SuspendLayout();
			this.panel16.SuspendLayout();
			this.panel17.SuspendLayout();
			this.groupBox18.SuspendLayout();
			this.panel18.SuspendLayout();
			this.groupBox19.SuspendLayout();
			this.groupBox29.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUserSetHistory).BeginInit();
			this.groupBox11.SuspendLayout();
			this.groupBox21.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdHistoryExcel).BeginInit();
			this.groupBox22.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdHistorySearch).BeginInit();
			this.tpSIBStatus.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel19.SuspendLayout();
			this.groupBox16.SuspendLayout();
			this.panel22.SuspendLayout();
			this.groupBox33.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModifyDefect).BeginInit();
			this.panelDetail.SuspendLayout();
			this.panel21.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.chart_SIBView).BeginInit();
			this.panel20.SuspendLayout();
			this.groupBox25.SuspendLayout();
			this.groupBox26.SuspendLayout();
			this.groupBox24.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDefectSearch).BeginInit();
			this.groupBox23.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSIBExcel).BeginInit();
			this.tpBlackList.SuspendLayout();
			this.panel23.SuspendLayout();
			this.panel24.SuspendLayout();
			this.groupBox17.SuspendLayout();
			this.panel26.SuspendLayout();
			this.groupBox20.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdMgrExcel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdMgrSearch).BeginInit();
			this.tpSWHistory.SuspendLayout();
			this.panel27.SuspendLayout();
			this.panel28.SuspendLayout();
			this.groupBox27.SuspendLayout();
			this.panel29.SuspendLayout();
			this.groupBox28.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDelete).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSWAdd).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSWExcel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSWSearch).BeginInit();
			this.tpSocketManage.SuspendLayout();
			this.tc_SM_Detail.SuspendLayout();
			this.tpSM_tpSocketComment.SuspendLayout();
			this.panel30.SuspendLayout();
			this.panel7.SuspendLayout();
			this.groupBox32.SuspendLayout();
			this.groupBox34.SuspendLayout();
			this.groupBox35.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_comment_insert).BeginInit();
			this.groupBox36.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_comment_excel).BeginInit();
			this.panel11.SuspendLayout();
			this.panel32.SuspendLayout();
			this.panel35.SuspendLayout();
			this.panel31.SuspendLayout();
			this.tpSM_tpEnrollSocket.SuspendLayout();
			this.panel34.SuspendLayout();
			this.groupBox42.SuspendLayout();
			this.panel12.SuspendLayout();
			this.groupBox37.SuspendLayout();
			this.groupBox38.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpEnroll_btnSetting).BeginInit();
			this.groupBox39.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpEnroll_btnAdd).BeginInit();
			this.groupBox40.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpEnroll_btnExcel).BeginInit();
			this.groupBox41.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpEnroll_btnSearch).BeginInit();
			this.tpSM_tpPeriodComment.SuspendLayout();
			this.panel37.SuspendLayout();
			this.groupBox50.SuspendLayout();
			this.panel36.SuspendLayout();
			this.groupBox45.SuspendLayout();
			this.groupBox51.SuspendLayout();
			this.groupBox46.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpPeriod_btnSetting).BeginInit();
			this.groupBox48.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpPeriod_btnExcel).BeginInit();
			this.groupBox49.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpPeriod_btnSearch).BeginInit();
			this.tpSM_tpCompledTrend.SuspendLayout();
			this.panel40.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.chartComptedTrend).BeginInit();
			this.panel39.SuspendLayout();
			this.panel38.SuspendLayout();
			this.groupBox47.SuspendLayout();
			this.groupBox52.SuspendLayout();
			this.groupBox54.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpCompleted_btnExcel).BeginInit();
			this.groupBox55.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpCompleted_btnSearch).BeginInit();
			this.panel33.SuspendLayout();
			this.tpWeeklyReport.SuspendLayout();
			this.groupBox65.SuspendLayout();
			this.WeeklyReportPanel.SuspendLayout();
			this.groupBox83.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
			this.groupBox68.SuspendLayout();
			this.groupBox66.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmbWeeklyReportExport).BeginInit();
			this.groupBox67.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdWeeklyReportSearch).BeginInit();
			this.groupBox64.SuspendLayout();
			this.WeeklyReportStatusPanel.SuspendLayout();
			this.tpATPList.SuspendLayout();
			this.panel48.SuspendLayout();
			this.groupBox76.SuspendLayout();
			this.panel47.SuspendLayout();
			this.groupBox79.SuspendLayout();
			this.pnlATPviewer.SuspendLayout();
			this.groupBox75.SuspendLayout();
			this.panel46.SuspendLayout();
			this.groupBox78.SuspendLayout();
			this.groupBox77.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmbATPexcel).BeginInit();
			this.groupBox74.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmbATPsearch).BeginInit();
			this.groupBox73.SuspendLayout();
			this.groupBox72.SuspendLayout();
			this.groupBox57.SuspendLayout();
			this.groupBox71.SuspendLayout();
			this.tpCorrHistory.SuspendLayout();
			this.panel49.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox80.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.gridCorrList).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.gridCorrList.MasterTemplate).BeginInit();
			this.groupBox90.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.gridCorrHistory).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.gridCorrHistory.MasterTemplate).BeginInit();
			this.panel51.SuspendLayout();
			this.groupBox81.SuspendLayout();
			this.groupBox89.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDelCorrHistory).BeginInit();
			this.groupBox88.SuspendLayout();
			this.groupBox85.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdAddCorrHistory).BeginInit();
			this.groupBox82.SuspendLayout();
			this.groupBox86.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdCorrExcel).BeginInit();
			this.groupBox87.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdCorrSearch).BeginInit();
			this.groupBox84.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(3, 3);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1170, 691);
			this.panel1.TabIndex = 18;
			this.panel3.Controls.Add(this.groupBox6);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 80);
			this.panel3.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel3.Size = new global::System.Drawing.Size(1170, 611);
			this.panel3.TabIndex = 2;
			this.groupBox6.Controls.Add(this.radGridView1);
			this.groupBox6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox6.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox6.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox6.Size = new global::System.Drawing.Size(1164, 607);
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Carrier List";
			this.radGridView1.Controls.Add(this.gridCarrierList);
			this.radGridView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radGridView1.Location = new global::System.Drawing.Point(3, 20);
			this.radGridView1.MasterTemplate.MultiSelect = true;
			this.radGridView1.MasterTemplate.SelectionMode = global::Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.Size = new global::System.Drawing.Size(1158, 583);
			this.radGridView1.TabIndex = 14;
			this.radGridView1.Text = "radGridView1";
			this.radGridView1.CellDoubleClick += new global::Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellDoubleClick);
			this.gridCarrierList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridCarrierList.EnableSort = true;
			this.gridCarrierList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridCarrierList.Location = new global::System.Drawing.Point(649, 97);
			this.gridCarrierList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridCarrierList.Name = "gridCarrierList";
			this.gridCarrierList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridCarrierList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridCarrierList.Size = new global::System.Drawing.Size(327, 221);
			this.gridCarrierList.TabIndex = 13;
			this.gridCarrierList.TabStop = true;
			this.gridCarrierList.ToolTipText = "";
			this.gridCarrierList.Visible = false;
			this.gridCarrierList.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.gridCarrierList_MouseDoubleClick);
			this.gridCarrierList.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.gridCarrierList_MouseDown);
			this.gridCarrierList.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.panel5.Controls.Add(this.groupBox2);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel5.Size = new global::System.Drawing.Size(1170, 80);
			this.panel5.TabIndex = 60;
			this.groupBox2.Controls.Add(this.groupBox31);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.cmbOpCode);
			this.groupBox2.Controls.Add(this.cmbCarrierType);
			this.groupBox2.Controls.Add(this.cmbTester);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.cmbCorrelation);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.txtBarcode);
			this.groupBox2.Controls.Add(this.cmbStatus);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cmbDevice);
			this.groupBox2.Controls.Add(this.cmbCustomer);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.groupBox8);
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Size = new global::System.Drawing.Size(1164, 74);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox31.Controls.Add(this.cmdUserSetCarrier);
			this.groupBox31.Location = new global::System.Drawing.Point(1099, 11);
			this.groupBox31.Name = "groupBox31";
			this.groupBox31.Size = new global::System.Drawing.Size(59, 58);
			this.groupBox31.TabIndex = 86;
			this.groupBox31.TabStop = false;
			this.groupBox31.Text = "Setting";
			this.cmdUserSetCarrier.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.CellDesign;
			this.cmdUserSetCarrier.Location = new global::System.Drawing.Point(14, 18);
			this.cmdUserSetCarrier.Name = "cmdUserSetCarrier";
			this.cmdUserSetCarrier.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUserSetCarrier.TabIndex = 80;
			this.cmdUserSetCarrier.TabStop = false;
			this.cmdUserSetCarrier.Click += new global::System.EventHandler(this.cmdUserSetCarrier_Click);
			this.cmdUserSetCarrier.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdUserSetCarrier_MouseDown);
			this.cmdUserSetCarrier.MouseLeave += new global::System.EventHandler(this.cmdUserSetCarrier_MouseLeave);
			this.cmdUserSetCarrier.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdUserSetCarrier_MouseMove);
			this.cmdUserSetCarrier.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdUserSetCarrier_MouseUp);
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(357, 46);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(37, 15);
			this.label5.TabIndex = 53;
			this.label5.Text = "Tester";
			this.cmbOpCode.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbOpCode.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbOpCode.FormattingEnabled = true;
			this.cmbOpCode.Location = new global::System.Drawing.Point(417, 15);
			this.cmbOpCode.Name = "cmbOpCode";
			this.cmbOpCode.Size = new global::System.Drawing.Size(100, 23);
			this.cmbOpCode.TabIndex = 52;
			this.cmbOpCode.DropDown += new global::System.EventHandler(this.cmbOpCode_DropDown);
			this.cmbCarrierType.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbCarrierType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbCarrierType.FormattingEnabled = true;
			this.cmbCarrierType.Location = new global::System.Drawing.Point(71, 43);
			this.cmbCarrierType.Name = "cmbCarrierType";
			this.cmbCarrierType.Size = new global::System.Drawing.Size(109, 23);
			this.cmbCarrierType.TabIndex = 51;
			this.cmbCarrierType.DropDown += new global::System.EventHandler(this.cmbCarrierType_DropDown);
			this.cmbTester.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbTester.FormattingEnabled = true;
			this.cmbTester.Location = new global::System.Drawing.Point(417, 43);
			this.cmbTester.Name = "cmbTester";
			this.cmbTester.Size = new global::System.Drawing.Size(100, 23);
			this.cmbTester.TabIndex = 47;
			this.cmbTester.DropDown += new global::System.EventHandler(this.cmbTester_DropDown);
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(6, 46);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(31, 15);
			this.label16.TabIndex = 50;
			this.label16.Text = "Type";
			this.cmbCorrelation.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbCorrelation.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbCorrelation.FormattingEnabled = true;
			this.cmbCorrelation.Location = new global::System.Drawing.Point(600, 15);
			this.cmbCorrelation.Name = "cmbCorrelation";
			this.cmbCorrelation.Size = new global::System.Drawing.Size(87, 23);
			this.cmbCorrelation.TabIndex = 49;
			this.cmbCorrelation.DropDown += new global::System.EventHandler(this.cmbCorrelation_DropDown);
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(528, 18);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(66, 15);
			this.label8.TabIndex = 48;
			this.label8.Text = "Correlation";
			this.txtBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtBarcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtBarcode.Location = new global::System.Drawing.Point(600, 47);
			this.txtBarcode.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new global::System.Drawing.Size(260, 23);
			this.txtBarcode.TabIndex = 0;
			this.txtBarcode.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtCarrier_KeyPress);
			this.cmbStatus.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbStatus.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatus.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbStatus.FormattingEnabled = true;
			this.cmbStatus.Location = new global::System.Drawing.Point(240, 15);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new global::System.Drawing.Size(106, 23);
			this.cmbStatus.TabIndex = 44;
			this.cmbStatus.DropDown += new global::System.EventHandler(this.cmbStatus_DropDown);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(528, 47);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(50, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Barcode";
			this.cmbDevice.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbDevice.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbDevice.FormattingEnabled = true;
			this.cmbDevice.Location = new global::System.Drawing.Point(240, 43);
			this.cmbDevice.Name = "cmbDevice";
			this.cmbDevice.Size = new global::System.Drawing.Size(106, 23);
			this.cmbDevice.TabIndex = 46;
			this.cmbDevice.DropDown += new global::System.EventHandler(this.cmbDevice_DropDown);
			this.cmbCustomer.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbCustomer.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCustomer.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbCustomer.FormattingEnabled = true;
			this.cmbCustomer.Location = new global::System.Drawing.Point(71, 15);
			this.cmbCustomer.Name = "cmbCustomer";
			this.cmbCustomer.Size = new global::System.Drawing.Size(109, 23);
			this.cmbCustomer.TabIndex = 43;
			this.cmbCustomer.DropDown += new global::System.EventHandler(this.cmbCustomer_DropDown);
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(357, 18);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(54, 15);
			this.label7.TabIndex = 30;
			this.label7.Text = "OP Code";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(192, 46);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(42, 15);
			this.label6.TabIndex = 28;
			this.label6.Text = "Device";
			this.groupBox3.Controls.Add(this.cmdAdd);
			this.groupBox3.Location = new global::System.Drawing.Point(985, 11);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox3.TabIndex = 24;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Add";
			this.cmdAdd.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdAdd.Image");
			this.cmdAdd.Location = new global::System.Drawing.Point(9, 18);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new global::System.Drawing.Size(32, 32);
			this.cmdAdd.TabIndex = 84;
			this.cmdAdd.TabStop = false;
			this.cmdAdd.Click += new global::System.EventHandler(this.cmdAdd_Click);
			this.cmdAdd.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdAdd_MouseDown);
			this.cmdAdd.MouseLeave += new global::System.EventHandler(this.cmdAdd_MouseLeave);
			this.cmdAdd.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdAdd_MouseMove);
			this.cmdAdd.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdAdd_MouseUp);
			this.groupBox8.Controls.Add(this.cmdExcel);
			this.groupBox8.Location = new global::System.Drawing.Point(1042, 12);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox8.TabIndex = 17;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Excel";
			this.cmdExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdExcel.Image");
			this.cmdExcel.Location = new global::System.Drawing.Point(9, 18);
			this.cmdExcel.Name = "cmdExcel";
			this.cmdExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdExcel.TabIndex = 80;
			this.cmdExcel.TabStop = false;
			this.cmdExcel.Click += new global::System.EventHandler(this.cmdExcel_Click);
			this.cmdExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseDown);
			this.cmdExcel.MouseLeave += new global::System.EventHandler(this.cmdExcel_MouseLeave);
			this.cmdExcel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseMove);
			this.cmdExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseUp);
			this.groupBox1.Controls.Add(this.cmdSearch);
			this.groupBox1.Location = new global::System.Drawing.Point(921, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(58, 58);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.cmdSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdSearch.Image");
			this.cmdSearch.Location = new global::System.Drawing.Point(12, 18);
			this.cmdSearch.Name = "cmdSearch";
			this.cmdSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdSearch.TabIndex = 1;
			this.cmdSearch.TabStop = false;
			this.cmdSearch.Click += new global::System.EventHandler(this.cmdSearch_Click);
			this.cmdSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdSearch_MouseDown);
			this.cmdSearch.MouseLeave += new global::System.EventHandler(this.cmdSearch_MouseLeave);
			this.cmdSearch.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdSearch_MouseMove);
			this.cmdSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdSearch_MouseUp);
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(192, 18);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(39, 15);
			this.label4.TabIndex = 5;
			this.label4.Text = "Status";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(6, 18);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(59, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Customer";
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
			this.label12.Size = new global::System.Drawing.Size(140, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "Carrier Inventory";
			this.tabCarrier.Controls.Add(this.tpEnrollCarrier);
			this.tabCarrier.Controls.Add(this.tpChangeStatusCarrier);
			this.tabCarrier.Controls.Add(this.tpCarrierViewer);
			this.tabCarrier.Controls.Add(this.tpViewCarrierData);
			this.tabCarrier.Controls.Add(this.tpCarrierHistory);
			this.tabCarrier.Controls.Add(this.tpSIBStatus);
			this.tabCarrier.Controls.Add(this.tpBlackList);
			this.tabCarrier.Controls.Add(this.tpSWHistory);
			this.tabCarrier.Controls.Add(this.tpSocketManage);
			this.tabCarrier.Controls.Add(this.tpWeeklyReport);
			this.tabCarrier.Controls.Add(this.tpATPList);
			this.tabCarrier.Controls.Add(this.tpCorrHistory);
			this.tabCarrier.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabCarrier.Location = new global::System.Drawing.Point(0, 34);
			this.tabCarrier.Name = "tabCarrier";
			this.tabCarrier.SelectedIndex = 0;
			this.tabCarrier.Size = new global::System.Drawing.Size(1184, 725);
			this.tabCarrier.TabIndex = 25;
			this.tabCarrier.SelectedIndexChanged += new global::System.EventHandler(this.tabCarrier_SelectedIndexChanged);
			this.tpEnrollCarrier.Controls.Add(this.panel1);
			this.tpEnrollCarrier.Location = new global::System.Drawing.Point(4, 24);
			this.tpEnrollCarrier.Name = "tpEnrollCarrier";
			this.tpEnrollCarrier.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpEnrollCarrier.Size = new global::System.Drawing.Size(1176, 697);
			this.tpEnrollCarrier.TabIndex = 85;
			this.tpEnrollCarrier.Text = "Enroll Carrier";
			this.tpEnrollCarrier.UseVisualStyleBackColor = true;
			this.tpChangeStatusCarrier.Controls.Add(this.panel2);
			this.tpChangeStatusCarrier.Location = new global::System.Drawing.Point(4, 24);
			this.tpChangeStatusCarrier.Name = "tpChangeStatusCarrier";
			this.tpChangeStatusCarrier.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpChangeStatusCarrier.Size = new global::System.Drawing.Size(1176, 697);
			this.tpChangeStatusCarrier.TabIndex = 1;
			this.tpChangeStatusCarrier.Text = "Carrier Machine/Clean/Repair";
			this.tpChangeStatusCarrier.UseVisualStyleBackColor = true;
			this.panel2.Controls.Add(this.panel6);
			this.panel2.Controls.Add(this.splitter2);
			this.panel2.Controls.Add(this.panel9);
			this.panel2.Controls.Add(this.splitter1);
			this.panel2.Controls.Add(this.panelScan);
			this.panel2.Controls.Add(this.panelMenu);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(3, 3);
			this.panel2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel2.Size = new global::System.Drawing.Size(1170, 691);
			this.panel2.TabIndex = 19;
			this.panel6.Controls.Add(this.groupBox4);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new global::System.Drawing.Point(3, 448);
			this.panel6.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel6.Size = new global::System.Drawing.Size(1164, 240);
			this.panel6.TabIndex = 2;
			this.groupBox4.Controls.Add(this.gridCarrierHistoryList);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox4.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Size = new global::System.Drawing.Size(1158, 234);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Carrier History";
			this.gridCarrierHistoryList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridCarrierHistoryList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridCarrierHistoryList.EnableSort = true;
			this.gridCarrierHistoryList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridCarrierHistoryList.Location = new global::System.Drawing.Point(3, 20);
			this.gridCarrierHistoryList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridCarrierHistoryList.Name = "gridCarrierHistoryList";
			this.gridCarrierHistoryList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridCarrierHistoryList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridCarrierHistoryList.Size = new global::System.Drawing.Size(1152, 210);
			this.gridCarrierHistoryList.TabIndex = 13;
			this.gridCarrierHistoryList.TabStop = true;
			this.gridCarrierHistoryList.ToolTipText = "";
			this.gridCarrierHistoryList.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.splitter2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new global::System.Drawing.Point(3, 445);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new global::System.Drawing.Size(1164, 3);
			this.splitter2.TabIndex = 84;
			this.splitter2.TabStop = false;
			this.panel9.Controls.Add(this.groupBox5);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new global::System.Drawing.Point(3, 309);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new global::System.Windows.Forms.Padding(3, 0, 3, 3);
			this.panel9.Size = new global::System.Drawing.Size(1164, 136);
			this.panel9.TabIndex = 43;
			this.groupBox5.Controls.Add(this.txtMCN);
			this.groupBox5.Controls.Add(this.label19);
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.button1);
			this.groupBox5.Controls.Add(this.txtStatusMemo);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.label24);
			this.groupBox5.Controls.Add(this.txtRevision);
			this.groupBox5.Controls.Add(this.txtStatusCorrelation);
			this.groupBox5.Controls.Add(this.txtStatusSite);
			this.groupBox5.Controls.Add(this.txtStatusCarrierStatus);
			this.groupBox5.Controls.Add(this.txtStatusTouchDownCnt);
			this.groupBox5.Controls.Add(this.label10);
			this.groupBox5.Controls.Add(this.txtStatusCarrierType);
			this.groupBox5.Controls.Add(this.txtStatusCustomer);
			this.groupBox5.Controls.Add(this.txtStatusLimitrepairCnt);
			this.groupBox5.Controls.Add(this.label25);
			this.groupBox5.Controls.Add(this.txtStatusLimitCleanCnt);
			this.groupBox5.Controls.Add(this.label26);
			this.groupBox5.Controls.Add(this.txtStatusTesterName);
			this.groupBox5.Controls.Add(this.label21);
			this.groupBox5.Controls.Add(this.txtStatusOpCode);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.txtStatusCarrierNo);
			this.groupBox5.Controls.Add(this.label18);
			this.groupBox5.Controls.Add(this.label20);
			this.groupBox5.Controls.Add(this.txtStatusPkgType);
			this.groupBox5.Controls.Add(this.label22);
			this.groupBox5.Controls.Add(this.label23);
			this.groupBox5.Controls.Add(this.txtStatusCleanCnt);
			this.groupBox5.Controls.Add(this.label27);
			this.groupBox5.Controls.Add(this.txtStatusrepairCnt);
			this.groupBox5.Controls.Add(this.label28);
			this.groupBox5.Controls.Add(this.label29);
			this.groupBox5.Controls.Add(this.label30);
			this.groupBox5.Controls.Add(this.txtStatusDevice);
			this.groupBox5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox5.Location = new global::System.Drawing.Point(3, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(1158, 133);
			this.groupBox5.TabIndex = 42;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Carrier Info";
			this.txtMCN.Location = new global::System.Drawing.Point(922, 104);
			this.txtMCN.Name = "txtMCN";
			this.txtMCN.Size = new global::System.Drawing.Size(115, 23);
			this.txtMCN.TabIndex = 98;
			this.label19.AutoSize = true;
			this.label19.Location = new global::System.Drawing.Point(880, 107);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(42, 15);
			this.label19.TabIndex = 97;
			this.label19.Text = "MCN#";
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(673, 50);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(66, 15);
			this.label9.TabIndex = 59;
			this.label9.Text = "Correlation";
			this.button1.Location = new global::System.Drawing.Point(1063, 20);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 96;
			this.button1.Text = "Preview";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.txtStatusMemo.Location = new global::System.Drawing.Point(91, 103);
			this.txtStatusMemo.Multiline = true;
			this.txtStatusMemo.Name = "txtStatusMemo";
			this.txtStatusMemo.Size = new global::System.Drawing.Size(576, 23);
			this.txtStatusMemo.TabIndex = 21;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(673, 106);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(51, 15);
			this.label3.TabIndex = 61;
			this.label3.Text = "Revision";
			this.label24.AutoSize = true;
			this.label24.Location = new global::System.Drawing.Point(14, 106);
			this.label24.Name = "label24";
			this.label24.Size = new global::System.Drawing.Size(42, 15);
			this.label24.TabIndex = 22;
			this.label24.Text = "Memo";
			this.txtRevision.ForeColor = global::System.Drawing.Color.Blue;
			this.txtRevision.Location = new global::System.Drawing.Point(752, 103);
			this.txtRevision.Name = "txtRevision";
			this.txtRevision.Size = new global::System.Drawing.Size(122, 23);
			this.txtRevision.TabIndex = 60;
			this.txtStatusCorrelation.Location = new global::System.Drawing.Point(752, 47);
			this.txtStatusCorrelation.Name = "txtStatusCorrelation";
			this.txtStatusCorrelation.ReadOnly = true;
			this.txtStatusCorrelation.Size = new global::System.Drawing.Size(90, 23);
			this.txtStatusCorrelation.TabIndex = 58;
			this.txtStatusSite.Location = new global::System.Drawing.Point(752, 20);
			this.txtStatusSite.Name = "txtStatusSite";
			this.txtStatusSite.ReadOnly = true;
			this.txtStatusSite.Size = new global::System.Drawing.Size(90, 23);
			this.txtStatusSite.TabIndex = 57;
			this.txtStatusCarrierStatus.Location = new global::System.Drawing.Point(329, 47);
			this.txtStatusCarrierStatus.Name = "txtStatusCarrierStatus";
			this.txtStatusCarrierStatus.ReadOnly = true;
			this.txtStatusCarrierStatus.Size = new global::System.Drawing.Size(149, 23);
			this.txtStatusCarrierStatus.TabIndex = 55;
			this.txtStatusTouchDownCnt.Location = new global::System.Drawing.Point(965, 74);
			this.txtStatusTouchDownCnt.Name = "txtStatusTouchDownCnt";
			this.txtStatusTouchDownCnt.ReadOnly = true;
			this.txtStatusTouchDownCnt.Size = new global::System.Drawing.Size(72, 23);
			this.txtStatusTouchDownCnt.TabIndex = 50;
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(848, 77);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(109, 15);
			this.label10.TabIndex = 51;
			this.label10.Text = "Touch Down Count";
			this.txtStatusCarrierType.Location = new global::System.Drawing.Point(91, 74);
			this.txtStatusCarrierType.Name = "txtStatusCarrierType";
			this.txtStatusCarrierType.ReadOnly = true;
			this.txtStatusCarrierType.Size = new global::System.Drawing.Size(148, 23);
			this.txtStatusCarrierType.TabIndex = 54;
			this.txtStatusCustomer.Location = new global::System.Drawing.Point(91, 20);
			this.txtStatusCustomer.Name = "txtStatusCustomer";
			this.txtStatusCustomer.ReadOnly = true;
			this.txtStatusCustomer.Size = new global::System.Drawing.Size(148, 23);
			this.txtStatusCustomer.TabIndex = 53;
			this.txtStatusLimitrepairCnt.Location = new global::System.Drawing.Point(965, 47);
			this.txtStatusLimitrepairCnt.Name = "txtStatusLimitrepairCnt";
			this.txtStatusLimitrepairCnt.ReadOnly = true;
			this.txtStatusLimitrepairCnt.Size = new global::System.Drawing.Size(72, 23);
			this.txtStatusLimitrepairCnt.TabIndex = 17;
			this.label25.AutoSize = true;
			this.label25.Location = new global::System.Drawing.Point(848, 50);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(106, 15);
			this.label25.TabIndex = 18;
			this.label25.Text = "Limit Repair Count";
			this.txtStatusLimitCleanCnt.Location = new global::System.Drawing.Point(965, 20);
			this.txtStatusLimitCleanCnt.Name = "txtStatusLimitCleanCnt";
			this.txtStatusLimitCleanCnt.ReadOnly = true;
			this.txtStatusLimitCleanCnt.Size = new global::System.Drawing.Size(72, 23);
			this.txtStatusLimitCleanCnt.TabIndex = 15;
			this.label26.AutoSize = true;
			this.label26.Location = new global::System.Drawing.Point(848, 23);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(103, 15);
			this.label26.TabIndex = 16;
			this.label26.Text = "Limit Clean Count";
			this.txtStatusTesterName.Location = new global::System.Drawing.Point(568, 47);
			this.txtStatusTesterName.Name = "txtStatusTesterName";
			this.txtStatusTesterName.ReadOnly = true;
			this.txtStatusTesterName.Size = new global::System.Drawing.Size(99, 23);
			this.txtStatusTesterName.TabIndex = 29;
			this.label21.AutoSize = true;
			this.label21.Location = new global::System.Drawing.Point(485, 50);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(37, 15);
			this.label21.TabIndex = 30;
			this.label21.Text = "Tester";
			this.txtStatusOpCode.Location = new global::System.Drawing.Point(568, 20);
			this.txtStatusOpCode.Name = "txtStatusOpCode";
			this.txtStatusOpCode.ReadOnly = true;
			this.txtStatusOpCode.Size = new global::System.Drawing.Size(99, 23);
			this.txtStatusOpCode.TabIndex = 52;
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(246, 50);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(77, 15);
			this.label14.TabIndex = 46;
			this.label14.Text = "Carrier Status";
			this.label15.AutoSize = true;
			this.label15.Location = new global::System.Drawing.Point(246, 23);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(61, 15);
			this.label15.TabIndex = 40;
			this.label15.Text = "Carrier No";
			this.txtStatusCarrierNo.Location = new global::System.Drawing.Point(329, 20);
			this.txtStatusCarrierNo.Name = "txtStatusCarrierNo";
			this.txtStatusCarrierNo.ReadOnly = true;
			this.txtStatusCarrierNo.Size = new global::System.Drawing.Size(149, 23);
			this.txtStatusCarrierNo.TabIndex = 39;
			this.label18.AutoSize = true;
			this.label18.Location = new global::System.Drawing.Point(673, 23);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(26, 15);
			this.label18.TabIndex = 36;
			this.label18.Text = "Site";
			this.label20.AutoSize = true;
			this.label20.Location = new global::System.Drawing.Point(246, 77);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(54, 15);
			this.label20.TabIndex = 32;
			this.label20.Text = "Pkg Type";
			this.txtStatusPkgType.Location = new global::System.Drawing.Point(329, 74);
			this.txtStatusPkgType.Name = "txtStatusPkgType";
			this.txtStatusPkgType.ReadOnly = true;
			this.txtStatusPkgType.Size = new global::System.Drawing.Size(149, 23);
			this.txtStatusPkgType.TabIndex = 31;
			this.label22.AutoSize = true;
			this.label22.Location = new global::System.Drawing.Point(485, 23);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(54, 15);
			this.label22.TabIndex = 28;
			this.label22.Text = "OP Code";
			this.label23.AutoSize = true;
			this.label23.Location = new global::System.Drawing.Point(673, 77);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(73, 15);
			this.label23.TabIndex = 26;
			this.label23.Text = "Clean Count";
			this.txtStatusCleanCnt.Location = new global::System.Drawing.Point(752, 74);
			this.txtStatusCleanCnt.Name = "txtStatusCleanCnt";
			this.txtStatusCleanCnt.ReadOnly = true;
			this.txtStatusCleanCnt.Size = new global::System.Drawing.Size(90, 23);
			this.txtStatusCleanCnt.TabIndex = 25;
			this.label27.AutoSize = true;
			this.label27.Location = new global::System.Drawing.Point(485, 77);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(76, 15);
			this.label27.TabIndex = 14;
			this.label27.Text = "Repair Count";
			this.txtStatusrepairCnt.Location = new global::System.Drawing.Point(568, 74);
			this.txtStatusrepairCnt.Name = "txtStatusrepairCnt";
			this.txtStatusrepairCnt.ReadOnly = true;
			this.txtStatusrepairCnt.Size = new global::System.Drawing.Size(99, 23);
			this.txtStatusrepairCnt.TabIndex = 13;
			this.label28.AutoSize = true;
			this.label28.Location = new global::System.Drawing.Point(14, 23);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(59, 15);
			this.label28.TabIndex = 10;
			this.label28.Text = "Customer";
			this.label29.AutoSize = true;
			this.label29.Location = new global::System.Drawing.Point(14, 77);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(69, 15);
			this.label29.TabIndex = 8;
			this.label29.Text = "Carrier Type";
			this.label30.AutoSize = true;
			this.label30.Location = new global::System.Drawing.Point(14, 50);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(42, 15);
			this.label30.TabIndex = 6;
			this.label30.Text = "Device";
			this.txtStatusDevice.Location = new global::System.Drawing.Point(91, 47);
			this.txtStatusDevice.Name = "txtStatusDevice";
			this.txtStatusDevice.ReadOnly = true;
			this.txtStatusDevice.Size = new global::System.Drawing.Size(148, 23);
			this.txtStatusDevice.TabIndex = 5;
			this.splitter1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new global::System.Drawing.Point(3, 306);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new global::System.Drawing.Size(1164, 3);
			this.splitter1.TabIndex = 83;
			this.splitter1.TabStop = false;
			this.panelScan.Controls.Add(this.panelSubInfo);
			this.panelScan.Controls.Add(this.panel14);
			this.panelScan.Controls.Add(this.panelBarcode);
			this.panelScan.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panelScan.Location = new global::System.Drawing.Point(3, 57);
			this.panelScan.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panelScan.Name = "panelScan";
			this.panelScan.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 0);
			this.panelScan.Size = new global::System.Drawing.Size(1164, 249);
			this.panelScan.TabIndex = 44;
			this.panelSubInfo.Controls.Add(this.grpSelectStatus);
			this.panelSubInfo.Controls.Add(this.gridClassifiedBlacklist);
			this.panelSubInfo.Controls.Add(this.gridClassifiedClean);
			this.panelSubInfo.Controls.Add(this.panelRepairCode);
			this.panelSubInfo.Controls.Add(this.grpLoadTester);
			this.panelSubInfo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelSubInfo.Location = new global::System.Drawing.Point(326, 5);
			this.panelSubInfo.Name = "panelSubInfo";
			this.panelSubInfo.Size = new global::System.Drawing.Size(641, 244);
			this.panelSubInfo.TabIndex = 92;
			this.grpSelectStatus.Controls.Add(this.cmbSelectStatus);
			this.grpSelectStatus.Location = new global::System.Drawing.Point(112, 3);
			this.grpSelectStatus.Name = "grpSelectStatus";
			this.grpSelectStatus.Size = new global::System.Drawing.Size(101, 59);
			this.grpSelectStatus.TabIndex = 94;
			this.grpSelectStatus.TabStop = false;
			this.grpSelectStatus.Text = "Select Status";
			this.cmbSelectStatus.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbSelectStatus.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSelectStatus.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbSelectStatus.FormattingEnabled = true;
			this.cmbSelectStatus.Location = new global::System.Drawing.Point(6, 25);
			this.cmbSelectStatus.Name = "cmbSelectStatus";
			this.cmbSelectStatus.Size = new global::System.Drawing.Size(82, 23);
			this.cmbSelectStatus.TabIndex = 94;
			this.cmbSelectStatus.SelectedIndexChanged += new global::System.EventHandler(this.cmbSelectStatus_SelectedIndexChanged);
			this.gridClassifiedBlacklist.BackColor = global::System.Drawing.Color.White;
			this.gridClassifiedBlacklist.EnableSort = true;
			this.gridClassifiedBlacklist.Location = new global::System.Drawing.Point(219, 3);
			this.gridClassifiedBlacklist.Name = "gridClassifiedBlacklist";
			this.gridClassifiedBlacklist.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridClassifiedBlacklist.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridClassifiedBlacklist.Size = new global::System.Drawing.Size(173, 59);
			this.gridClassifiedBlacklist.TabIndex = 96;
			this.gridClassifiedBlacklist.TabStop = true;
			this.gridClassifiedBlacklist.ToolTipText = "";
			this.gridClassifiedClean.BackColor = global::System.Drawing.Color.White;
			this.gridClassifiedClean.EnableSort = true;
			this.gridClassifiedClean.Location = new global::System.Drawing.Point(420, 3);
			this.gridClassifiedClean.Margin = new global::System.Windows.Forms.Padding(5, 3, 3, 3);
			this.gridClassifiedClean.Name = "gridClassifiedClean";
			this.gridClassifiedClean.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridClassifiedClean.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridClassifiedClean.Size = new global::System.Drawing.Size(187, 58);
			this.gridClassifiedClean.TabIndex = 4;
			this.gridClassifiedClean.TabStop = true;
			this.gridClassifiedClean.ToolTipText = "";
			this.panelRepairCode.Controls.Add(this.tabControl1);
			this.panelRepairCode.Controls.Add(this.panelSIBDamage);
			this.panelRepairCode.Controls.Add(this.grpRepairReason);
			this.panelRepairCode.Location = new global::System.Drawing.Point(3, 68);
			this.panelRepairCode.Name = "panelRepairCode";
			this.panelRepairCode.Size = new global::System.Drawing.Size(635, 173);
			this.panelRepairCode.TabIndex = 0;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new global::System.Drawing.Point(0, 48);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(494, 125);
			this.tabControl1.TabIndex = 94;
			this.tabPage1.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(486, 97);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage2.Location = new global::System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(486, 97);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.panelSIBDamage.Controls.Add(this.cmbSelectStatus2);
			this.panelSIBDamage.Controls.Add(this.label35);
			this.panelSIBDamage.Controls.Add(this.label57);
			this.panelSIBDamage.Controls.Add(this.label56);
			this.panelSIBDamage.Controls.Add(this.cmbSuspectCause);
			this.panelSIBDamage.Controls.Add(this.cmbDamage);
			this.panelSIBDamage.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panelSIBDamage.Location = new global::System.Drawing.Point(494, 48);
			this.panelSIBDamage.Name = "panelSIBDamage";
			this.panelSIBDamage.Size = new global::System.Drawing.Size(141, 125);
			this.panelSIBDamage.TabIndex = 95;
			this.cmbSelectStatus2.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbSelectStatus2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbSelectStatus2.FormattingEnabled = true;
			this.cmbSelectStatus2.Location = new global::System.Drawing.Point(7, 105);
			this.cmbSelectStatus2.Name = "cmbSelectStatus2";
			this.cmbSelectStatus2.Size = new global::System.Drawing.Size(131, 23);
			this.cmbSelectStatus2.TabIndex = 99;
			this.label35.AutoSize = true;
			this.label35.Location = new global::System.Drawing.Point(9, 85);
			this.label35.Name = "label35";
			this.label35.Size = new global::System.Drawing.Size(110, 15);
			this.label35.TabIndex = 98;
			this.label35.Text = "Select Defect Status";
			this.label57.AutoSize = true;
			this.label57.Location = new global::System.Drawing.Point(5, 41);
			this.label57.Name = "label57";
			this.label57.Size = new global::System.Drawing.Size(83, 15);
			this.label57.TabIndex = 97;
			this.label57.Text = "Suspect Cause";
			this.label56.AutoSize = true;
			this.label56.Location = new global::System.Drawing.Point(10, 2);
			this.label56.Name = "label56";
			this.label56.Size = new global::System.Drawing.Size(51, 15);
			this.label56.TabIndex = 96;
			this.label56.Text = "Damage";
			this.cmbSuspectCause.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbSuspectCause.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSuspectCause.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbSuspectCause.FormattingEnabled = true;
			this.cmbSuspectCause.Location = new global::System.Drawing.Point(7, 59);
			this.cmbSuspectCause.Name = "cmbSuspectCause";
			this.cmbSuspectCause.Size = new global::System.Drawing.Size(132, 23);
			this.cmbSuspectCause.TabIndex = 95;
			this.cmbSuspectCause.DropDown += new global::System.EventHandler(this.cmbSuspectCause_DropDown);
			this.cmbDamage.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbDamage.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDamage.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbDamage.FormattingEnabled = true;
			this.cmbDamage.Location = new global::System.Drawing.Point(6, 20);
			this.cmbDamage.Name = "cmbDamage";
			this.cmbDamage.Size = new global::System.Drawing.Size(132, 23);
			this.cmbDamage.TabIndex = 94;
			this.cmbDamage.DropDown += new global::System.EventHandler(this.cmbDamage_DropDown);
			this.grpRepairReason.Controls.Add(this.panelPrintInfo);
			this.grpRepairReason.Controls.Add(this.cmdAddCode);
			this.grpRepairReason.Controls.Add(this.txtRepairCode);
			this.grpRepairReason.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.grpRepairReason.Location = new global::System.Drawing.Point(0, 0);
			this.grpRepairReason.Name = "grpRepairReason";
			this.grpRepairReason.Padding = new global::System.Windows.Forms.Padding(5, 3, 5, 5);
			this.grpRepairReason.Size = new global::System.Drawing.Size(635, 48);
			this.grpRepairReason.TabIndex = 88;
			this.grpRepairReason.TabStop = false;
			this.grpRepairReason.Text = "Code";
			this.panelPrintInfo.Controls.Add(this.txtSite2Yield);
			this.panelPrintInfo.Controls.Add(this.label37);
			this.panelPrintInfo.Controls.Add(this.txtSite1Yield);
			this.panelPrintInfo.Controls.Add(this.txtSite1Reason);
			this.panelPrintInfo.Controls.Add(this.label40);
			this.panelPrintInfo.Controls.Add(this.btnLabelPrint);
			this.panelPrintInfo.Controls.Add(this.txtSite2Reason);
			this.panelPrintInfo.Location = new global::System.Drawing.Point(264, 14);
			this.panelPrintInfo.Name = "panelPrintInfo";
			this.panelPrintInfo.Size = new global::System.Drawing.Size(326, 29);
			this.panelPrintInfo.TabIndex = 0;
			this.txtSite2Yield.Location = new global::System.Drawing.Point(230, 3);
			this.txtSite2Yield.Name = "txtSite2Yield";
			this.txtSite2Yield.ReadOnly = true;
			this.txtSite2Yield.Size = new global::System.Drawing.Size(38, 23);
			this.txtSite2Yield.TabIndex = 101;
			this.label37.AutoSize = true;
			this.label37.Location = new global::System.Drawing.Point(3, 7);
			this.label37.Name = "label37";
			this.label37.Size = new global::System.Drawing.Size(32, 15);
			this.label37.TabIndex = 87;
			this.label37.Text = "Site1";
			this.txtSite1Yield.Location = new global::System.Drawing.Point(95, 3);
			this.txtSite1Yield.Name = "txtSite1Yield";
			this.txtSite1Yield.ReadOnly = true;
			this.txtSite1Yield.Size = new global::System.Drawing.Size(38, 23);
			this.txtSite1Yield.TabIndex = 87;
			this.txtSite1Reason.Location = new global::System.Drawing.Point(38, 3);
			this.txtSite1Reason.Name = "txtSite1Reason";
			this.txtSite1Reason.ReadOnly = true;
			this.txtSite1Reason.Size = new global::System.Drawing.Size(54, 23);
			this.txtSite1Reason.TabIndex = 86;
			this.label40.AutoSize = true;
			this.label40.Location = new global::System.Drawing.Point(137, 7);
			this.label40.Name = "label40";
			this.label40.Size = new global::System.Drawing.Size(32, 15);
			this.label40.TabIndex = 100;
			this.label40.Text = "Site2";
			this.btnLabelPrint.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnLabelPrint.Location = new global::System.Drawing.Point(276, 3);
			this.btnLabelPrint.Name = "btnLabelPrint";
			this.btnLabelPrint.Size = new global::System.Drawing.Size(48, 23);
			this.btnLabelPrint.TabIndex = 97;
			this.btnLabelPrint.Text = "Print";
			this.btnLabelPrint.UseVisualStyleBackColor = true;
			this.btnLabelPrint.Click += new global::System.EventHandler(this.btnLabelPrint_Click);
			this.txtSite2Reason.Location = new global::System.Drawing.Point(173, 3);
			this.txtSite2Reason.Name = "txtSite2Reason";
			this.txtSite2Reason.ReadOnly = true;
			this.txtSite2Reason.Size = new global::System.Drawing.Size(54, 23);
			this.txtSite2Reason.TabIndex = 99;
			this.cmdAddCode.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdAddCode.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdAddCode.Image");
			this.cmdAddCode.Location = new global::System.Drawing.Point(596, 12);
			this.cmdAddCode.Name = "cmdAddCode";
			this.cmdAddCode.Size = new global::System.Drawing.Size(32, 32);
			this.cmdAddCode.TabIndex = 85;
			this.cmdAddCode.TabStop = false;
			this.cmdAddCode.Click += new global::System.EventHandler(this.cmdAddCode_Click);
			this.cmdAddCode.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdAddCode_MouseDown);
			this.cmdAddCode.MouseLeave += new global::System.EventHandler(this.cmdAddCode_MouseLeave);
			this.cmdAddCode.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdAddCode_MouseMove);
			this.cmdAddCode.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdAddCode_MouseUp);
			this.txtRepairCode.Location = new global::System.Drawing.Point(8, 17);
			this.txtRepairCode.Name = "txtRepairCode";
			this.txtRepairCode.Size = new global::System.Drawing.Size(253, 23);
			this.txtRepairCode.TabIndex = 2;
			this.txtRepairCode.TextChanged += new global::System.EventHandler(this.txtRepairCode_TextChanged);
			this.grpLoadTester.Controls.Add(this.cmbLoadTester);
			this.grpLoadTester.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.grpLoadTester.Location = new global::System.Drawing.Point(6, 3);
			this.grpLoadTester.Name = "grpLoadTester";
			this.grpLoadTester.Size = new global::System.Drawing.Size(100, 59);
			this.grpLoadTester.TabIndex = 87;
			this.grpLoadTester.TabStop = false;
			this.grpLoadTester.Text = "Load Tester";
			this.cmbLoadTester.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbLoadTester.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLoadTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbLoadTester.FormattingEnabled = true;
			this.cmbLoadTester.Location = new global::System.Drawing.Point(9, 25);
			this.cmbLoadTester.Name = "cmbLoadTester";
			this.cmbLoadTester.Size = new global::System.Drawing.Size(80, 23);
			this.cmbLoadTester.TabIndex = 93;
			this.cmbLoadTester.DropDown += new global::System.EventHandler(this.cmbLoadTester_DropDown);
			this.panel14.Controls.Add(this.panelDefectUpload);
			this.panel14.Controls.Add(this.groupBox10);
			this.panel14.Controls.Add(this.groupBox9);
			this.panel14.Controls.Add(this.groupBox7);
			this.panel14.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel14.Location = new global::System.Drawing.Point(967, 5);
			this.panel14.Name = "panel14";
			this.panel14.Size = new global::System.Drawing.Size(194, 244);
			this.panel14.TabIndex = 91;
			this.panelDefectUpload.Controls.Add(this.groupBox56);
			this.panelDefectUpload.Controls.Add(this.groupBox44);
			this.panelDefectUpload.Controls.Add(this.pbUploadImage);
			this.panelDefectUpload.Controls.Add(this.groupBox43);
			this.panelDefectUpload.Controls.Add(this.txtAttachFile);
			this.panelDefectUpload.Location = new global::System.Drawing.Point(4, 59);
			this.panelDefectUpload.Name = "panelDefectUpload";
			this.panelDefectUpload.Size = new global::System.Drawing.Size(187, 185);
			this.panelDefectUpload.TabIndex = 117;
			this.groupBox56.Controls.Add(this.cmdUploadFile1);
			this.groupBox56.Location = new global::System.Drawing.Point(126, 1);
			this.groupBox56.Name = "groupBox56";
			this.groupBox56.Size = new global::System.Drawing.Size(61, 62);
			this.groupBox56.TabIndex = 94;
			this.groupBox56.TabStop = false;
			this.groupBox56.Text = "Upload File";
			this.cmdUploadFile1.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.OpenTable;
			this.cmdUploadFile1.Location = new global::System.Drawing.Point(12, 29);
			this.cmdUploadFile1.Name = "cmdUploadFile1";
			this.cmdUploadFile1.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUploadFile1.TabIndex = 112;
			this.cmdUploadFile1.TabStop = false;
			this.cmdUploadFile1.Click += new global::System.EventHandler(this.cmdUploadFile1_Click);
			this.groupBox44.Controls.Add(this.cmdRemoveFile);
			this.groupBox44.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.groupBox44.Location = new global::System.Drawing.Point(63, 1);
			this.groupBox44.Name = "groupBox44";
			this.groupBox44.Size = new global::System.Drawing.Size(62, 62);
			this.groupBox44.TabIndex = 119;
			this.groupBox44.TabStop = false;
			this.groupBox44.Text = "Remove image";
			this.cmdRemoveFile.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableRemove;
			this.cmdRemoveFile.Location = new global::System.Drawing.Point(15, 27);
			this.cmdRemoveFile.Name = "cmdRemoveFile";
			this.cmdRemoveFile.Size = new global::System.Drawing.Size(32, 32);
			this.cmdRemoveFile.TabIndex = 86;
			this.cmdRemoveFile.TabStop = false;
			this.cmdRemoveFile.Click += new global::System.EventHandler(this.cmdRemoveFile_Click);
			this.pbUploadImage.Location = new global::System.Drawing.Point(3, 87);
			this.pbUploadImage.Name = "pbUploadImage";
			this.pbUploadImage.Size = new global::System.Drawing.Size(181, 96);
			this.pbUploadImage.TabIndex = 118;
			this.pbUploadImage.TabStop = false;
			this.groupBox43.Controls.Add(this.cmdUploadFile);
			this.groupBox43.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.groupBox43.Location = new global::System.Drawing.Point(0, 1);
			this.groupBox43.Name = "groupBox43";
			this.groupBox43.Size = new global::System.Drawing.Size(60, 62);
			this.groupBox43.TabIndex = 117;
			this.groupBox43.TabStop = false;
			this.groupBox43.Text = "Upload Image";
			this.cmdUploadFile.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.OpenTable;
			this.cmdUploadFile.Location = new global::System.Drawing.Point(13, 27);
			this.cmdUploadFile.Name = "cmdUploadFile";
			this.cmdUploadFile.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUploadFile.TabIndex = 111;
			this.cmdUploadFile.TabStop = false;
			this.cmdUploadFile.Click += new global::System.EventHandler(this.cmdUploadFile_Click);
			this.cmdUploadFile.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdUploadFile_MouseDown);
			this.cmdUploadFile.MouseLeave += new global::System.EventHandler(this.cmdUploadFile_MouseLeave);
			this.cmdUploadFile.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdUploadFile_MouseMove);
			this.cmdUploadFile.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdUploadFile_MouseUp);
			this.txtAttachFile.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtAttachFile.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtAttachFile.Location = new global::System.Drawing.Point(3, 63);
			this.txtAttachFile.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtAttachFile.Name = "txtAttachFile";
			this.txtAttachFile.ReadOnly = true;
			this.txtAttachFile.Size = new global::System.Drawing.Size(181, 23);
			this.txtAttachFile.TabIndex = 110;
			this.groupBox10.Controls.Add(this.cmdStatusSearch);
			this.groupBox10.Location = new global::System.Drawing.Point(4, 0);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new global::System.Drawing.Size(57, 57);
			this.groupBox10.TabIndex = 26;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Search";
			this.cmdStatusSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdStatusSearch.Image");
			this.cmdStatusSearch.Location = new global::System.Drawing.Point(12, 17);
			this.cmdStatusSearch.Name = "cmdStatusSearch";
			this.cmdStatusSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdStatusSearch.TabIndex = 25;
			this.cmdStatusSearch.TabStop = false;
			this.cmdStatusSearch.Click += new global::System.EventHandler(this.cmdStatusSearch_Click);
			this.groupBox9.Controls.Add(this.cmdStatusApply);
			this.groupBox9.Location = new global::System.Drawing.Point(67, 0);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(57, 57);
			this.groupBox9.TabIndex = 27;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Apply";
			this.cmdStatusApply.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdStatusApply.Image");
			this.cmdStatusApply.Location = new global::System.Drawing.Point(12, 17);
			this.cmdStatusApply.Name = "cmdStatusApply";
			this.cmdStatusApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmdStatusApply.TabIndex = 23;
			this.cmdStatusApply.TabStop = false;
			this.cmdStatusApply.Click += new global::System.EventHandler(this.cmdStatusApply_Click);
			this.cmdStatusApply.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdStatusApply_MouseDown);
			this.cmdStatusApply.MouseLeave += new global::System.EventHandler(this.cmdStatusApply_MouseLeave);
			this.cmdStatusApply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdStatusApply_MouseMove);
			this.cmdStatusApply.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdStatusApply_MouseUp);
			this.groupBox7.Controls.Add(this.cmdStatusExcel);
			this.groupBox7.Location = new global::System.Drawing.Point(130, 0);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(58, 57);
			this.groupBox7.TabIndex = 27;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Excel";
			this.cmdStatusExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdStatusExcel.Image");
			this.cmdStatusExcel.Location = new global::System.Drawing.Point(12, 17);
			this.cmdStatusExcel.Name = "cmdStatusExcel";
			this.cmdStatusExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdStatusExcel.TabIndex = 24;
			this.cmdStatusExcel.TabStop = false;
			this.cmdStatusExcel.Click += new global::System.EventHandler(this.cmdStatusExcel_Click);
			this.panelBarcode.Controls.Add(this.grpScan);
			this.panelBarcode.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panelBarcode.Location = new global::System.Drawing.Point(3, 5);
			this.panelBarcode.Name = "panelBarcode";
			this.panelBarcode.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panelBarcode.Size = new global::System.Drawing.Size(323, 244);
			this.panelBarcode.TabIndex = 90;
			this.grpScan.Controls.Add(this.groupCarrier);
			this.grpScan.Controls.Add(this.chkAutoSelect);
			this.grpScan.Controls.Add(this.groupSIB);
			this.grpScan.Controls.Add(this.lblSIB2);
			this.grpScan.Controls.Add(this.txtStatusSIB2Barcode);
			this.grpScan.Controls.Add(this.lblSIB1);
			this.grpScan.Controls.Add(this.txtStatusSIB1Barcode);
			this.grpScan.Controls.Add(this.chkMultiBarcode);
			this.grpScan.Controls.Add(this.chkBarcode);
			this.grpScan.Controls.Add(this.lblBarcode);
			this.grpScan.Controls.Add(this.txtStatusBarcode);
			this.grpScan.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grpScan.Location = new global::System.Drawing.Point(0, 0);
			this.grpScan.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grpScan.Name = "grpScan";
			this.grpScan.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grpScan.Size = new global::System.Drawing.Size(320, 244);
			this.grpScan.TabIndex = 86;
			this.grpScan.TabStop = false;
			this.grpScan.Text = "Scan";
			this.groupCarrier.Controls.Add(this.label32);
			this.groupCarrier.Controls.Add(this.txtMainCarrier);
			this.groupCarrier.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.groupCarrier.Location = new global::System.Drawing.Point(3, 113);
			this.groupCarrier.Name = "groupCarrier";
			this.groupCarrier.Size = new global::System.Drawing.Size(314, 49);
			this.groupCarrier.TabIndex = 5;
			this.groupCarrier.TabStop = false;
			this.groupCarrier.Text = "Carrier Info";
			this.label32.AutoSize = true;
			this.label32.Location = new global::System.Drawing.Point(9, 22);
			this.label32.Name = "label32";
			this.label32.Size = new global::System.Drawing.Size(42, 15);
			this.label32.TabIndex = 96;
			this.label32.Text = "Carrier";
			this.txtMainCarrier.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtMainCarrier.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtMainCarrier.Location = new global::System.Drawing.Point(89, 19);
			this.txtMainCarrier.Name = "txtMainCarrier";
			this.txtMainCarrier.ReadOnly = true;
			this.txtMainCarrier.Size = new global::System.Drawing.Size(214, 23);
			this.txtMainCarrier.TabIndex = 95;
			this.chkAutoSelect.AutoSize = true;
			this.chkAutoSelect.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.chkAutoSelect.Location = new global::System.Drawing.Point(4, 15);
			this.chkAutoSelect.Name = "chkAutoSelect";
			this.chkAutoSelect.Size = new global::System.Drawing.Size(83, 19);
			this.chkAutoSelect.TabIndex = 95;
			this.chkAutoSelect.Text = "AutoMode";
			this.chkAutoSelect.UseVisualStyleBackColor = true;
			this.chkAutoSelect.CheckedChanged += new global::System.EventHandler(this.chkAutoSelect_CheckedChanged);
			this.groupSIB.Controls.Add(this.lblAssignSIB2);
			this.groupSIB.Controls.Add(this.lblAssignSIB1);
			this.groupSIB.Controls.Add(this.txtAssignSIB2);
			this.groupSIB.Controls.Add(this.txtAssignSIB1);
			this.groupSIB.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.groupSIB.Location = new global::System.Drawing.Point(3, 162);
			this.groupSIB.Name = "groupSIB";
			this.groupSIB.Size = new global::System.Drawing.Size(314, 78);
			this.groupSIB.TabIndex = 4;
			this.groupSIB.TabStop = false;
			this.groupSIB.Text = "SIB Info";
			this.lblAssignSIB2.AutoSize = true;
			this.lblAssignSIB2.Location = new global::System.Drawing.Point(9, 50);
			this.lblAssignSIB2.Name = "lblAssignSIB2";
			this.lblAssignSIB2.Size = new global::System.Drawing.Size(70, 15);
			this.lblAssignSIB2.TabIndex = 98;
			this.lblAssignSIB2.Text = "Assign SIB 2";
			this.lblAssignSIB1.AutoSize = true;
			this.lblAssignSIB1.Location = new global::System.Drawing.Point(9, 21);
			this.lblAssignSIB1.Name = "lblAssignSIB1";
			this.lblAssignSIB1.Size = new global::System.Drawing.Size(70, 15);
			this.lblAssignSIB1.TabIndex = 96;
			this.lblAssignSIB1.Text = "Assign SIB 1";
			this.txtAssignSIB2.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtAssignSIB2.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtAssignSIB2.Location = new global::System.Drawing.Point(89, 47);
			this.txtAssignSIB2.Name = "txtAssignSIB2";
			this.txtAssignSIB2.ReadOnly = true;
			this.txtAssignSIB2.Size = new global::System.Drawing.Size(214, 23);
			this.txtAssignSIB2.TabIndex = 97;
			this.txtAssignSIB1.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtAssignSIB1.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtAssignSIB1.Location = new global::System.Drawing.Point(89, 18);
			this.txtAssignSIB1.Name = "txtAssignSIB1";
			this.txtAssignSIB1.ReadOnly = true;
			this.txtAssignSIB1.Size = new global::System.Drawing.Size(214, 23);
			this.txtAssignSIB1.TabIndex = 95;
			this.lblSIB2.AutoSize = true;
			this.lblSIB2.Location = new global::System.Drawing.Point(11, 95);
			this.lblSIB2.Name = "lblSIB2";
			this.lblSIB2.Size = new global::System.Drawing.Size(32, 15);
			this.lblSIB2.TabIndex = 94;
			this.lblSIB2.Text = "SIB 2";
			this.txtStatusSIB2Barcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtStatusSIB2Barcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtStatusSIB2Barcode.Location = new global::System.Drawing.Point(79, 92);
			this.txtStatusSIB2Barcode.Name = "txtStatusSIB2Barcode";
			this.txtStatusSIB2Barcode.Size = new global::System.Drawing.Size(228, 23);
			this.txtStatusSIB2Barcode.TabIndex = 93;
			this.lblSIB1.AutoSize = true;
			this.lblSIB1.Location = new global::System.Drawing.Point(11, 68);
			this.lblSIB1.Name = "lblSIB1";
			this.lblSIB1.Size = new global::System.Drawing.Size(32, 15);
			this.lblSIB1.TabIndex = 92;
			this.lblSIB1.Text = "SIB 1";
			this.txtStatusSIB1Barcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtStatusSIB1Barcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtStatusSIB1Barcode.Location = new global::System.Drawing.Point(79, 65);
			this.txtStatusSIB1Barcode.Name = "txtStatusSIB1Barcode";
			this.txtStatusSIB1Barcode.Size = new global::System.Drawing.Size(228, 23);
			this.txtStatusSIB1Barcode.TabIndex = 91;
			this.txtStatusSIB1Barcode.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtStatusSIB1Barcode_KeyPress);
			this.chkMultiBarcode.AutoSize = true;
			this.chkMultiBarcode.Location = new global::System.Drawing.Point(217, 15);
			this.chkMultiBarcode.Name = "chkMultiBarcode";
			this.chkMultiBarcode.Size = new global::System.Drawing.Size(100, 19);
			this.chkMultiBarcode.TabIndex = 90;
			this.chkMultiBarcode.Text = "Multi Barcode";
			this.chkMultiBarcode.UseVisualStyleBackColor = true;
			this.chkMultiBarcode.CheckedChanged += new global::System.EventHandler(this.chkMultiLot_CheckedChanged);
			this.chkBarcode.AutoSize = true;
			this.chkBarcode.Checked = true;
			this.chkBarcode.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkBarcode.Location = new global::System.Drawing.Point(87, 15);
			this.chkBarcode.Name = "chkBarcode";
			this.chkBarcode.Size = new global::System.Drawing.Size(131, 19);
			this.chkBarcode.TabIndex = 89;
			this.chkBarcode.Text = "Scan Barcode mode";
			this.chkBarcode.UseVisualStyleBackColor = true;
			this.lblBarcode.AutoSize = true;
			this.lblBarcode.Location = new global::System.Drawing.Point(11, 41);
			this.lblBarcode.Name = "lblBarcode";
			this.lblBarcode.Size = new global::System.Drawing.Size(50, 15);
			this.lblBarcode.TabIndex = 4;
			this.lblBarcode.Text = "Barcode";
			this.txtStatusBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtStatusBarcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtStatusBarcode.Location = new global::System.Drawing.Point(79, 38);
			this.txtStatusBarcode.Name = "txtStatusBarcode";
			this.txtStatusBarcode.Size = new global::System.Drawing.Size(228, 23);
			this.txtStatusBarcode.TabIndex = 0;
			this.txtStatusBarcode.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtStatusCarrierName_KeyPress);
			this.panelMenu.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMenu.Controls.Add(this.rdoEngr);
			this.panelMenu.Controls.Add(this.rdoWareHouse);
			this.panelMenu.Controls.Add(this.rdoBatchChange);
			this.panelMenu.Controls.Add(this.rdoIdle);
			this.panelMenu.Controls.Add(this.rdoDefectStart);
			this.panelMenu.Controls.Add(this.rdoLoad);
			this.panelMenu.Controls.Add(this.rdoCleanStart);
			this.panelMenu.Controls.Add(this.rdorepairStart);
			this.panelMenu.Controls.Add(this.rdorepairEnd);
			this.panelMenu.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panelMenu.Location = new global::System.Drawing.Point(3, 3);
			this.panelMenu.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panelMenu.Name = "panelMenu";
			this.panelMenu.Padding = new global::System.Windows.Forms.Padding(3);
			this.panelMenu.Size = new global::System.Drawing.Size(1164, 54);
			this.panelMenu.TabIndex = 82;
			this.rdoEngr.AutoSize = true;
			this.rdoEngr.Location = new global::System.Drawing.Point(853, 16);
			this.rdoEngr.Name = "rdoEngr";
			this.rdoEngr.Size = new global::System.Drawing.Size(49, 19);
			this.rdoEngr.TabIndex = 12;
			this.rdoEngr.TabStop = true;
			this.rdoEngr.Tag = "Engr";
			this.rdoEngr.Text = "Engr";
			this.rdoEngr.UseVisualStyleBackColor = true;
			this.rdoWareHouse.AutoSize = true;
			this.rdoWareHouse.Location = new global::System.Drawing.Point(745, 16);
			this.rdoWareHouse.Name = "rdoWareHouse";
			this.rdoWareHouse.Size = new global::System.Drawing.Size(86, 19);
			this.rdoWareHouse.TabIndex = 11;
			this.rdoWareHouse.TabStop = true;
			this.rdoWareHouse.Tag = "WareHouse";
			this.rdoWareHouse.Text = "WareHouse";
			this.rdoWareHouse.UseVisualStyleBackColor = true;
			this.rdoBatchChange.AutoSize = true;
			this.rdoBatchChange.Location = new global::System.Drawing.Point(934, 16);
			this.rdoBatchChange.Name = "rdoBatchChange";
			this.rdoBatchChange.Size = new global::System.Drawing.Size(96, 19);
			this.rdoBatchChange.TabIndex = 10;
			this.rdoBatchChange.TabStop = true;
			this.rdoBatchChange.Tag = "BatchChange";
			this.rdoBatchChange.Text = "BatchChange";
			this.rdoBatchChange.UseVisualStyleBackColor = true;
			this.rdoIdle.AutoSize = true;
			this.rdoIdle.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdoIdle.Location = new global::System.Drawing.Point(153, 16);
			this.rdoIdle.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdoIdle.Name = "rdoIdle";
			this.rdoIdle.Size = new global::System.Drawing.Size(47, 21);
			this.rdoIdle.TabIndex = 9;
			this.rdoIdle.Tag = "Idle";
			this.rdoIdle.Text = "Idle";
			this.rdoIdle.UseVisualStyleBackColor = true;
			this.rdoDefectStart.AutoSize = true;
			this.rdoDefectStart.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdoDefectStart.Location = new global::System.Drawing.Point(611, 16);
			this.rdoDefectStart.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdoDefectStart.Name = "rdoDefectStart";
			this.rdoDefectStart.Size = new global::System.Drawing.Size(90, 21);
			this.rdoDefectStart.TabIndex = 7;
			this.rdoDefectStart.Tag = "DefectStart";
			this.rdoDefectStart.Text = "DefectStart";
			this.rdoDefectStart.UseVisualStyleBackColor = true;
			this.rdoLoad.AutoSize = true;
			this.rdoLoad.Checked = true;
			this.rdoLoad.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdoLoad.Location = new global::System.Drawing.Point(16, 16);
			this.rdoLoad.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdoLoad.Name = "rdoLoad";
			this.rdoLoad.Size = new global::System.Drawing.Size(78, 21);
			this.rdoLoad.TabIndex = 6;
			this.rdoLoad.TabStop = true;
			this.rdoLoad.Tag = "Load";
			this.rdoLoad.Text = "Machine";
			this.rdoLoad.UseVisualStyleBackColor = true;
			this.rdoCleanStart.AutoSize = true;
			this.rdoCleanStart.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdoCleanStart.Location = new global::System.Drawing.Point(260, 16);
			this.rdoCleanStart.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdoCleanStart.Name = "rdoCleanStart";
			this.rdoCleanStart.Size = new global::System.Drawing.Size(58, 21);
			this.rdoCleanStart.TabIndex = 2;
			this.rdoCleanStart.Tag = "Clean";
			this.rdoCleanStart.Text = "Clean";
			this.rdoCleanStart.UseVisualStyleBackColor = true;
			this.rdorepairStart.AutoSize = true;
			this.rdorepairStart.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdorepairStart.Location = new global::System.Drawing.Point(361, 16);
			this.rdorepairStart.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdorepairStart.Name = "rdorepairStart";
			this.rdorepairStart.Size = new global::System.Drawing.Size(91, 21);
			this.rdorepairStart.TabIndex = 3;
			this.rdorepairStart.Tag = "RepairStart";
			this.rdorepairStart.Text = "RepairStart";
			this.rdorepairStart.UseVisualStyleBackColor = true;
			this.rdorepairEnd.AutoSize = true;
			this.rdorepairEnd.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdorepairEnd.Location = new global::System.Drawing.Point(490, 16);
			this.rdorepairEnd.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdorepairEnd.Name = "rdorepairEnd";
			this.rdorepairEnd.Size = new global::System.Drawing.Size(86, 21);
			this.rdorepairEnd.TabIndex = 5;
			this.rdorepairEnd.Tag = "RepairEnd";
			this.rdorepairEnd.Text = "RepairEnd";
			this.rdorepairEnd.UseVisualStyleBackColor = true;
			this.tpCarrierViewer.Controls.Add(this.panel43);
			this.tpCarrierViewer.Controls.Add(this.panel42);
			this.tpCarrierViewer.Location = new global::System.Drawing.Point(4, 24);
			this.tpCarrierViewer.Name = "tpCarrierViewer";
			this.tpCarrierViewer.Size = new global::System.Drawing.Size(1176, 697);
			this.tpCarrierViewer.TabIndex = 92;
			this.tpCarrierViewer.Text = "Carrier Viewer";
			this.tpCarrierViewer.UseVisualStyleBackColor = true;
			this.panel43.Controls.Add(this.groupBox58);
			this.panel43.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel43.Location = new global::System.Drawing.Point(0, 88);
			this.panel43.Name = "panel43";
			this.panel43.Size = new global::System.Drawing.Size(1176, 609);
			this.panel43.TabIndex = 2;
			this.groupBox58.Controls.Add(this.panel45);
			this.groupBox58.Controls.Add(this.panel44);
			this.groupBox58.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox58.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox58.Name = "groupBox58";
			this.groupBox58.Size = new global::System.Drawing.Size(1176, 609);
			this.groupBox58.TabIndex = 1;
			this.groupBox58.TabStop = false;
			this.groupBox58.Text = "Viewer";
			this.panel45.Controls.Add(this.groupBox61);
			this.panel45.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel45.Location = new global::System.Drawing.Point(3, 131);
			this.panel45.Name = "panel45";
			this.panel45.Size = new global::System.Drawing.Size(1170, 475);
			this.panel45.TabIndex = 4;
			this.groupBox61.Controls.Add(this.gridViewerList);
			this.groupBox61.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox61.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox61.Name = "groupBox61";
			this.groupBox61.Size = new global::System.Drawing.Size(1170, 475);
			this.groupBox61.TabIndex = 4;
			this.groupBox61.TabStop = false;
			this.groupBox61.Text = "Carrier List";
			this.gridViewerList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridViewerList.EnableSort = true;
			this.gridViewerList.Location = new global::System.Drawing.Point(3, 19);
			this.gridViewerList.Name = "gridViewerList";
			this.gridViewerList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridViewerList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridViewerList.Size = new global::System.Drawing.Size(1164, 453);
			this.gridViewerList.TabIndex = 0;
			this.gridViewerList.TabStop = true;
			this.gridViewerList.ToolTipText = "";
			this.panel44.Controls.Add(this.groupBox62);
			this.panel44.Controls.Add(this.groupBox70);
			this.panel44.Controls.Add(this.groupBox69);
			this.panel44.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel44.Location = new global::System.Drawing.Point(3, 19);
			this.panel44.Name = "panel44";
			this.panel44.Size = new global::System.Drawing.Size(1170, 112);
			this.panel44.TabIndex = 4;
			this.groupBox62.Controls.Add(this.panel41);
			this.groupBox62.Location = new global::System.Drawing.Point(9, 12);
			this.groupBox62.Name = "groupBox62";
			this.groupBox62.Size = new global::System.Drawing.Size(736, 81);
			this.groupBox62.TabIndex = 2;
			this.groupBox62.TabStop = false;
			this.groupBox62.Text = "Total Carrier";
			this.panel41.Controls.Add(this.gridViewerInfo);
			this.panel41.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel41.Location = new global::System.Drawing.Point(3, 19);
			this.panel41.Name = "panel41";
			this.panel41.Size = new global::System.Drawing.Size(730, 59);
			this.panel41.TabIndex = 0;
			this.gridViewerInfo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridViewerInfo.EnableSort = true;
			this.gridViewerInfo.Location = new global::System.Drawing.Point(0, 0);
			this.gridViewerInfo.Name = "gridViewerInfo";
			this.gridViewerInfo.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridViewerInfo.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridViewerInfo.Size = new global::System.Drawing.Size(730, 59);
			this.gridViewerInfo.TabIndex = 1;
			this.gridViewerInfo.TabStop = true;
			this.gridViewerInfo.ToolTipText = "";
			this.groupBox70.Controls.Add(this.cmbViewerBarcode);
			this.groupBox70.Location = new global::System.Drawing.Point(910, 15);
			this.groupBox70.Name = "groupBox70";
			this.groupBox70.Size = new global::System.Drawing.Size(195, 78);
			this.groupBox70.TabIndex = 57;
			this.groupBox70.TabStop = false;
			this.groupBox70.Text = "Barcode";
			this.cmbViewerBarcode.Location = new global::System.Drawing.Point(6, 30);
			this.cmbViewerBarcode.Name = "cmbViewerBarcode";
			this.cmbViewerBarcode.Size = new global::System.Drawing.Size(183, 23);
			this.cmbViewerBarcode.TabIndex = 3;
			this.cmbViewerBarcode.TextChanged += new global::System.EventHandler(this.cmbViewerBarcode_TextChanged);
			this.groupBox69.Controls.Add(this.cmbGroup);
			this.groupBox69.Location = new global::System.Drawing.Point(751, 15);
			this.groupBox69.Name = "groupBox69";
			this.groupBox69.Size = new global::System.Drawing.Size(153, 78);
			this.groupBox69.TabIndex = 1;
			this.groupBox69.TabStop = false;
			this.groupBox69.Text = "Group";
			this.cmbGroup.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbGroup.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGroup.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbGroup.FormattingEnabled = true;
			this.cmbGroup.Location = new global::System.Drawing.Point(17, 30);
			this.cmbGroup.Name = "cmbGroup";
			this.cmbGroup.Size = new global::System.Drawing.Size(121, 23);
			this.cmbGroup.TabIndex = 56;
			this.cmbGroup.DropDown += new global::System.EventHandler(this.cmbGroup_DropDown);
			this.cmbGroup.SelectedIndexChanged += new global::System.EventHandler(this.cmbGroup_SelectedIndexChanged);
			this.panel42.Controls.Add(this.ViewerList);
			this.panel42.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel42.Location = new global::System.Drawing.Point(0, 0);
			this.panel42.Name = "panel42";
			this.panel42.Size = new global::System.Drawing.Size(1176, 88);
			this.panel42.TabIndex = 0;
			this.ViewerList.Controls.Add(this.pnlViewer);
			this.ViewerList.Controls.Add(this.groupBox63);
			this.ViewerList.Controls.Add(this.groupBox60);
			this.ViewerList.Controls.Add(this.groupBox59);
			this.ViewerList.Location = new global::System.Drawing.Point(3, 3);
			this.ViewerList.Name = "ViewerList";
			this.ViewerList.Size = new global::System.Drawing.Size(1170, 85);
			this.ViewerList.TabIndex = 2;
			this.ViewerList.TabStop = false;
			this.ViewerList.Text = "Select View";
			this.pnlViewer.Controls.Add(this.rdoViewDefect);
			this.pnlViewer.Controls.Add(this.rdoViewEngr);
			this.pnlViewer.Controls.Add(this.rdoViewWareHouse);
			this.pnlViewer.Location = new global::System.Drawing.Point(24, 22);
			this.pnlViewer.Name = "pnlViewer";
			this.pnlViewer.Size = new global::System.Drawing.Size(520, 49);
			this.pnlViewer.TabIndex = 8;
			this.rdoViewDefect.AutoSize = true;
			this.rdoViewDefect.Location = new global::System.Drawing.Point(275, 16);
			this.rdoViewDefect.Name = "rdoViewDefect";
			this.rdoViewDefect.Size = new global::System.Drawing.Size(59, 19);
			this.rdoViewDefect.TabIndex = 7;
			this.rdoViewDefect.TabStop = true;
			this.rdoViewDefect.Tag = "Defect";
			this.rdoViewDefect.Text = "Defect";
			this.rdoViewDefect.UseVisualStyleBackColor = true;
			this.rdoViewEngr.AutoSize = true;
			this.rdoViewEngr.Location = new global::System.Drawing.Point(156, 16);
			this.rdoViewEngr.Name = "rdoViewEngr";
			this.rdoViewEngr.Size = new global::System.Drawing.Size(49, 19);
			this.rdoViewEngr.TabIndex = 6;
			this.rdoViewEngr.TabStop = true;
			this.rdoViewEngr.Tag = "Engr";
			this.rdoViewEngr.Text = "Engr";
			this.rdoViewEngr.UseVisualStyleBackColor = true;
			this.rdoViewWareHouse.AutoSize = true;
			this.rdoViewWareHouse.Location = new global::System.Drawing.Point(17, 16);
			this.rdoViewWareHouse.Name = "rdoViewWareHouse";
			this.rdoViewWareHouse.Size = new global::System.Drawing.Size(86, 19);
			this.rdoViewWareHouse.TabIndex = 0;
			this.rdoViewWareHouse.TabStop = true;
			this.rdoViewWareHouse.Tag = "WareHouse";
			this.rdoViewWareHouse.Text = "WareHouse";
			this.rdoViewWareHouse.UseVisualStyleBackColor = true;
			this.groupBox63.Controls.Add(this.cmbProduct2);
			this.groupBox63.Location = new global::System.Drawing.Point(855, 11);
			this.groupBox63.Name = "groupBox63";
			this.groupBox63.Size = new global::System.Drawing.Size(136, 60);
			this.groupBox63.TabIndex = 2;
			this.groupBox63.TabStop = false;
			this.groupBox63.Text = "Product";
			this.cmbProduct2.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbProduct2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProduct2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbProduct2.FormattingEnabled = true;
			this.cmbProduct2.Location = new global::System.Drawing.Point(14, 25);
			this.cmbProduct2.Name = "cmbProduct2";
			this.cmbProduct2.Size = new global::System.Drawing.Size(116, 23);
			this.cmbProduct2.TabIndex = 55;
			this.cmbProduct2.DropDown += new global::System.EventHandler(this.cmbProduct2_DropDown);
			this.groupBox60.Controls.Add(this.cmdWareHouseExport);
			this.groupBox60.Location = new global::System.Drawing.Point(1072, 10);
			this.groupBox60.Name = "groupBox60";
			this.groupBox60.Size = new global::System.Drawing.Size(56, 61);
			this.groupBox60.TabIndex = 3;
			this.groupBox60.TabStop = false;
			this.groupBox60.Text = "Export";
			this.cmdWareHouseExport.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.SaveExcel;
			this.cmdWareHouseExport.Location = new global::System.Drawing.Point(6, 19);
			this.cmdWareHouseExport.Name = "cmdWareHouseExport";
			this.cmdWareHouseExport.Size = new global::System.Drawing.Size(44, 36);
			this.cmdWareHouseExport.TabIndex = 0;
			this.cmdWareHouseExport.TabStop = false;
			this.cmdWareHouseExport.Click += new global::System.EventHandler(this.cmdWareHouseExport_Click);
			this.groupBox59.Controls.Add(this.cmdWareHouseSearch);
			this.groupBox59.Location = new global::System.Drawing.Point(1007, 11);
			this.groupBox59.Name = "groupBox59";
			this.groupBox59.Size = new global::System.Drawing.Size(59, 61);
			this.groupBox59.TabIndex = 2;
			this.groupBox59.TabStop = false;
			this.groupBox59.Text = "Search";
			this.cmdWareHouseSearch.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableSearch;
			this.cmdWareHouseSearch.Location = new global::System.Drawing.Point(15, 19);
			this.cmdWareHouseSearch.Name = "cmdWareHouseSearch";
			this.cmdWareHouseSearch.Size = new global::System.Drawing.Size(31, 30);
			this.cmdWareHouseSearch.TabIndex = 2;
			this.cmdWareHouseSearch.TabStop = false;
			this.cmdWareHouseSearch.Click += new global::System.EventHandler(this.cmdWareHouseSearch_Click);
			this.tpViewCarrierData.Controls.Add(this.splitter3);
			this.tpViewCarrierData.Controls.Add(this.panel10);
			this.tpViewCarrierData.Controls.Add(this.panel15);
			this.tpViewCarrierData.Controls.Add(this.panel8);
			this.tpViewCarrierData.Location = new global::System.Drawing.Point(4, 24);
			this.tpViewCarrierData.Name = "tpViewCarrierData";
			this.tpViewCarrierData.Size = new global::System.Drawing.Size(1176, 697);
			this.tpViewCarrierData.TabIndex = 2;
			this.tpViewCarrierData.Text = "View Daily Carrier Status";
			this.tpViewCarrierData.UseVisualStyleBackColor = true;
			this.splitter3.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.splitter3.Location = new global::System.Drawing.Point(0, 556);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new global::System.Drawing.Size(1176, 4);
			this.splitter3.TabIndex = 151;
			this.splitter3.TabStop = false;
			this.panel10.Controls.Add(this.chart_CarrierView);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel10.Location = new global::System.Drawing.Point(0, 70);
			this.panel10.Name = "panel10";
			this.panel10.Size = new global::System.Drawing.Size(1176, 490);
			this.panel10.TabIndex = 149;
			this.chart_CarrierView.BackGradientStyle = global::System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart_CarrierView.BackSecondaryColor = global::System.Drawing.Color.White;
			this.chart_CarrierView.BorderlineColor = global::System.Drawing.Color.Silver;
			this.chart_CarrierView.BorderlineDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
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
			this.chart_CarrierView.ChartAreas.Add(chartArea);
			this.chart_CarrierView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			legend.Alignment = global::System.Drawing.StringAlignment.Center;
			legend.BackColor = global::System.Drawing.Color.Transparent;
			legend.BorderColor = global::System.Drawing.Color.Transparent;
			legend.Docking = global::System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			legend.IsTextAutoFit = false;
			legend.Name = "Legend1";
			this.chart_CarrierView.Legends.Add(legend);
			this.chart_CarrierView.Location = new global::System.Drawing.Point(0, 0);
			this.chart_CarrierView.Name = "chart_CarrierView";
			this.chart_CarrierView.Size = new global::System.Drawing.Size(1176, 490);
			this.chart_CarrierView.TabIndex = 147;
			this.chart_CarrierView.Text = "chart_Tester";
			title.BackColor = global::System.Drawing.Color.Transparent;
			title.BackImageAlignment = global::System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
			title.BackImageWrapMode = global::System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
			title.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			title.Name = "Title1";
			title.ShadowColor = global::System.Drawing.Color.Silver;
			title.Text = "Carrier Inventory";
			this.chart_CarrierView.Titles.Add(title);
			this.chart_CarrierView.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.chart_CarrierView_MouseClick);
			this.chart_CarrierView.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.chart_CarrierView_MouseDoubleClick);
			this.panel15.Controls.Add(this.gridInventoryList);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel15.Location = new global::System.Drawing.Point(0, 560);
			this.panel15.Name = "panel15";
			this.panel15.Size = new global::System.Drawing.Size(1176, 137);
			this.panel15.TabIndex = 150;
			this.gridInventoryList.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.gridInventoryList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridInventoryList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridInventoryList.EnableSort = true;
			this.gridInventoryList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridInventoryList.Location = new global::System.Drawing.Point(0, 0);
			this.gridInventoryList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridInventoryList.Name = "gridInventoryList";
			this.gridInventoryList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridInventoryList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridInventoryList.Size = new global::System.Drawing.Size(1176, 137);
			this.gridInventoryList.TabIndex = 29;
			this.gridInventoryList.TabStop = true;
			this.gridInventoryList.ToolTipText = "";
			this.gridInventoryList.DoubleClick += new global::System.EventHandler(this.gridInventoryList_DoubleClick);
			this.gridInventoryList.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.panel8.Controls.Add(this.groupBox53);
			this.panel8.Controls.Add(this.groupBox30);
			this.panel8.Controls.Add(this.groupBox15);
			this.panel8.Controls.Add(this.groupBox12);
			this.panel8.Controls.Add(this.groupBox14);
			this.panel8.Controls.Add(this.groupBox13);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new global::System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(1176, 70);
			this.panel8.TabIndex = 148;
			this.groupBox53.Controls.Add(this.cmbFailMode);
			this.groupBox53.Location = new global::System.Drawing.Point(782, 6);
			this.groupBox53.Name = "groupBox53";
			this.groupBox53.Size = new global::System.Drawing.Size(122, 64);
			this.groupBox53.TabIndex = 151;
			this.groupBox53.TabStop = false;
			this.groupBox53.Text = "Mode";
			this.cmbFailMode.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbFailMode.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFailMode.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbFailMode.FormattingEnabled = true;
			this.cmbFailMode.Location = new global::System.Drawing.Point(6, 24);
			this.cmbFailMode.Name = "cmbFailMode";
			this.cmbFailMode.Size = new global::System.Drawing.Size(110, 23);
			this.cmbFailMode.TabIndex = 54;
			this.groupBox30.Controls.Add(this.cmbInventoryType);
			this.groupBox30.Location = new global::System.Drawing.Point(626, 4);
			this.groupBox30.Name = "groupBox30";
			this.groupBox30.Size = new global::System.Drawing.Size(150, 64);
			this.groupBox30.TabIndex = 150;
			this.groupBox30.TabStop = false;
			this.groupBox30.Text = "Type";
			this.cmbInventoryType.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbInventoryType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbInventoryType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbInventoryType.FormattingEnabled = true;
			this.cmbInventoryType.Location = new global::System.Drawing.Point(6, 24);
			this.cmbInventoryType.Name = "cmbInventoryType";
			this.cmbInventoryType.Size = new global::System.Drawing.Size(132, 23);
			this.cmbInventoryType.TabIndex = 54;
			this.cmbInventoryType.SelectedIndexChanged += new global::System.EventHandler(this.cmbInventoryType_SelectedIndexChanged);
			this.groupBox15.Controls.Add(this.cmdViewExcel);
			this.groupBox15.Location = new global::System.Drawing.Point(1092, 4);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new global::System.Drawing.Size(51, 64);
			this.groupBox15.TabIndex = 149;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Excel";
			this.cmdViewExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdViewExcel.Image");
			this.cmdViewExcel.Location = new global::System.Drawing.Point(9, 21);
			this.cmdViewExcel.Name = "cmdViewExcel";
			this.cmdViewExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdViewExcel.TabIndex = 80;
			this.cmdViewExcel.TabStop = false;
			this.cmdViewExcel.Click += new global::System.EventHandler(this.cmdViewExcel_Click);
			this.groupBox12.Controls.Add(this.rdoMonth);
			this.groupBox12.Controls.Add(this.rdoPeriod);
			this.groupBox12.Controls.Add(this.rdoWeek);
			this.groupBox12.Controls.Add(this.rdoDay);
			this.groupBox12.Controls.Add(this.dtp_End);
			this.groupBox12.Controls.Add(this.dtp_Start);
			this.groupBox12.Location = new global::System.Drawing.Point(8, 4);
			this.groupBox12.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox12.Size = new global::System.Drawing.Size(612, 64);
			this.groupBox12.TabIndex = 146;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Option";
			this.rdoMonth.AutoSize = true;
			this.rdoMonth.Location = new global::System.Drawing.Point(128, 27);
			this.rdoMonth.Name = "rdoMonth";
			this.rdoMonth.Size = new global::System.Drawing.Size(61, 19);
			this.rdoMonth.TabIndex = 87;
			this.rdoMonth.Text = "Month";
			this.rdoMonth.UseVisualStyleBackColor = true;
			this.rdoPeriod.AutoSize = true;
			this.rdoPeriod.Location = new global::System.Drawing.Point(195, 27);
			this.rdoPeriod.Name = "rdoPeriod";
			this.rdoPeriod.Size = new global::System.Drawing.Size(59, 19);
			this.rdoPeriod.TabIndex = 86;
			this.rdoPeriod.Text = "Period";
			this.rdoPeriod.UseVisualStyleBackColor = true;
			this.rdoWeek.AutoSize = true;
			this.rdoWeek.Location = new global::System.Drawing.Point(68, 27);
			this.rdoWeek.Name = "rdoWeek";
			this.rdoWeek.Size = new global::System.Drawing.Size(54, 19);
			this.rdoWeek.TabIndex = 85;
			this.rdoWeek.Text = "Week";
			this.rdoWeek.UseVisualStyleBackColor = true;
			this.rdoDay.AutoSize = true;
			this.rdoDay.Checked = true;
			this.rdoDay.Location = new global::System.Drawing.Point(17, 27);
			this.rdoDay.Name = "rdoDay";
			this.rdoDay.Size = new global::System.Drawing.Size(45, 19);
			this.rdoDay.TabIndex = 84;
			this.rdoDay.TabStop = true;
			this.rdoDay.Text = "Day";
			this.rdoDay.UseVisualStyleBackColor = true;
			this.dtp_End.CustomFormat = "'End Date : ' yyyy-MM-dd";
			this.dtp_End.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_End.Location = new global::System.Drawing.Point(430, 25);
			this.dtp_End.Name = "dtp_End";
			this.dtp_End.Size = new global::System.Drawing.Size(161, 23);
			this.dtp_End.TabIndex = 1;
			this.dtp_End.CloseUp += new global::System.EventHandler(this.dtp_End_CloseUp);
			this.dtp_Start.CustomFormat = "'Start Date : ' yyyy-MM-dd";
			this.dtp_Start.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_Start.Location = new global::System.Drawing.Point(260, 25);
			this.dtp_Start.Name = "dtp_Start";
			this.dtp_Start.Size = new global::System.Drawing.Size(161, 23);
			this.dtp_Start.TabIndex = 83;
			this.dtp_Start.CloseUp += new global::System.EventHandler(this.dtp_Start_CloseUp);
			this.groupBox14.Controls.Add(this.cmbProduct);
			this.groupBox14.Location = new global::System.Drawing.Point(910, 4);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new global::System.Drawing.Size(112, 64);
			this.groupBox14.TabIndex = 148;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Product";
			this.cmbProduct.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbProduct.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProduct.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbProduct.FormattingEnabled = true;
			this.cmbProduct.Location = new global::System.Drawing.Point(6, 25);
			this.cmbProduct.Name = "cmbProduct";
			this.cmbProduct.Size = new global::System.Drawing.Size(100, 23);
			this.cmbProduct.TabIndex = 54;
			this.cmbProduct.DropDown += new global::System.EventHandler(this.cmbProduct_DropDown);
			this.groupBox13.Controls.Add(this.cmdViewSearch);
			this.groupBox13.Location = new global::System.Drawing.Point(1028, 4);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new global::System.Drawing.Size(58, 64);
			this.groupBox13.TabIndex = 147;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Search";
			this.cmdViewSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdViewSearch.Image");
			this.cmdViewSearch.Location = new global::System.Drawing.Point(12, 20);
			this.cmdViewSearch.Name = "cmdViewSearch";
			this.cmdViewSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdViewSearch.TabIndex = 1;
			this.cmdViewSearch.TabStop = false;
			this.cmdViewSearch.Click += new global::System.EventHandler(this.cmdViewSearch_Click);
			this.tpCarrierHistory.Controls.Add(this.panel16);
			this.tpCarrierHistory.Location = new global::System.Drawing.Point(4, 24);
			this.tpCarrierHistory.Name = "tpCarrierHistory";
			this.tpCarrierHistory.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpCarrierHistory.Size = new global::System.Drawing.Size(1176, 697);
			this.tpCarrierHistory.TabIndex = 86;
			this.tpCarrierHistory.Text = "Carrier History";
			this.tpCarrierHistory.UseVisualStyleBackColor = true;
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
			this.panel17.Location = new global::System.Drawing.Point(0, 80);
			this.panel17.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel17.Name = "panel17";
			this.panel17.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel17.Size = new global::System.Drawing.Size(1170, 611);
			this.panel17.TabIndex = 2;
			this.groupBox18.Controls.Add(this.gridSearchHistory);
			this.groupBox18.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox18.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox18.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox18.Size = new global::System.Drawing.Size(1164, 607);
			this.groupBox18.TabIndex = 5;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Carrier History List";
			this.gridSearchHistory.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridSearchHistory.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridSearchHistory.EnableSort = true;
			this.gridSearchHistory.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridSearchHistory.Location = new global::System.Drawing.Point(3, 20);
			this.gridSearchHistory.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridSearchHistory.Name = "gridSearchHistory";
			this.gridSearchHistory.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridSearchHistory.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridSearchHistory.Size = new global::System.Drawing.Size(1158, 583);
			this.gridSearchHistory.TabIndex = 13;
			this.gridSearchHistory.TabStop = true;
			this.gridSearchHistory.ToolTipText = "";
			this.gridSearchHistory.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.panel18.Controls.Add(this.groupBox19);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel18.Location = new global::System.Drawing.Point(0, 0);
			this.panel18.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel18.Name = "panel18";
			this.panel18.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel18.Size = new global::System.Drawing.Size(1170, 80);
			this.panel18.TabIndex = 60;
			this.groupBox19.Controls.Add(this.chkHistoryCarrierBarcode);
			this.groupBox19.Controls.Add(this.cmbHistoryCarrierCorrelation);
			this.groupBox19.Controls.Add(this.cmbHistoryCarrierTester);
			this.groupBox19.Controls.Add(this.cmbHistoryCarrierOpCode);
			this.groupBox19.Controls.Add(this.label61);
			this.groupBox19.Controls.Add(this.label60);
			this.groupBox19.Controls.Add(this.label59);
			this.groupBox19.Controls.Add(this.cmbHistoryCarrierCustomer);
			this.groupBox19.Controls.Add(this.label58);
			this.groupBox19.Controls.Add(this.groupBox29);
			this.groupBox19.Controls.Add(this.cmbHistoryCarrierDevice);
			this.groupBox19.Controls.Add(this.cmbHistoryCarrierType);
			this.groupBox19.Controls.Add(this.label11);
			this.groupBox19.Controls.Add(this.cmbHistoryProduct);
			this.groupBox19.Controls.Add(this.groupBox11);
			this.groupBox19.Controls.Add(this.label17);
			this.groupBox19.Controls.Add(this.txtHistoryBarcode);
			this.groupBox19.Controls.Add(this.chkcmbHistoryStatus);
			this.groupBox19.Controls.Add(this.groupBox21);
			this.groupBox19.Controls.Add(this.groupBox22);
			this.groupBox19.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox19.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox19.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox19.Size = new global::System.Drawing.Size(1164, 74);
			this.groupBox19.TabIndex = 6;
			this.groupBox19.TabStop = false;
			this.chkHistoryCarrierBarcode.AutoSize = true;
			this.chkHistoryCarrierBarcode.Location = new global::System.Drawing.Point(488, 45);
			this.chkHistoryCarrierBarcode.Name = "chkHistoryCarrierBarcode";
			this.chkHistoryCarrierBarcode.Size = new global::System.Drawing.Size(69, 19);
			this.chkHistoryCarrierBarcode.TabIndex = 93;
			this.chkHistoryCarrierBarcode.Text = "Barcode";
			this.chkHistoryCarrierBarcode.UseVisualStyleBackColor = true;
			this.chkHistoryCarrierBarcode.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			this.cmbHistoryCarrierCorrelation.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbHistoryCarrierCorrelation.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbHistoryCarrierCorrelation.FormattingEnabled = true;
			this.cmbHistoryCarrierCorrelation.Location = new global::System.Drawing.Point(560, 14);
			this.cmbHistoryCarrierCorrelation.Name = "cmbHistoryCarrierCorrelation";
			this.cmbHistoryCarrierCorrelation.Size = new global::System.Drawing.Size(87, 23);
			this.cmbHistoryCarrierCorrelation.TabIndex = 93;
			this.cmbHistoryCarrierTester.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbHistoryCarrierTester.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHistoryCarrierTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbHistoryCarrierTester.FormattingEnabled = true;
			this.cmbHistoryCarrierTester.Location = new global::System.Drawing.Point(389, 44);
			this.cmbHistoryCarrierTester.Name = "cmbHistoryCarrierTester";
			this.cmbHistoryCarrierTester.Size = new global::System.Drawing.Size(90, 23);
			this.cmbHistoryCarrierTester.TabIndex = 92;
			this.cmbHistoryCarrierTester.DropDown += new global::System.EventHandler(this.cmbHistoryCarrierTester_DropDown);
			this.cmbHistoryCarrierOpCode.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbHistoryCarrierOpCode.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHistoryCarrierOpCode.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbHistoryCarrierOpCode.FormattingEnabled = true;
			this.cmbHistoryCarrierOpCode.Location = new global::System.Drawing.Point(389, 13);
			this.cmbHistoryCarrierOpCode.Name = "cmbHistoryCarrierOpCode";
			this.cmbHistoryCarrierOpCode.Size = new global::System.Drawing.Size(90, 23);
			this.cmbHistoryCarrierOpCode.TabIndex = 91;
			this.cmbHistoryCarrierOpCode.DropDown += new global::System.EventHandler(this.cmbHistoryCarrierOpCode_DropDown);
			this.label61.AutoSize = true;
			this.label61.Location = new global::System.Drawing.Point(488, 16);
			this.label61.Name = "label61";
			this.label61.Size = new global::System.Drawing.Size(66, 15);
			this.label61.TabIndex = 90;
			this.label61.Text = "Correlation";
			this.label60.AutoSize = true;
			this.label60.Location = new global::System.Drawing.Point(329, 19);
			this.label60.Name = "label60";
			this.label60.Size = new global::System.Drawing.Size(54, 15);
			this.label60.TabIndex = 89;
			this.label60.Text = "OP Code";
			this.label59.AutoSize = true;
			this.label59.Location = new global::System.Drawing.Point(344, 47);
			this.label59.Name = "label59";
			this.label59.Size = new global::System.Drawing.Size(37, 15);
			this.label59.TabIndex = 88;
			this.label59.Text = "Tester";
			this.cmbHistoryCarrierCustomer.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbHistoryCarrierCustomer.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHistoryCarrierCustomer.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbHistoryCarrierCustomer.FormattingEnabled = true;
			this.cmbHistoryCarrierCustomer.Location = new global::System.Drawing.Point(71, 16);
			this.cmbHistoryCarrierCustomer.Name = "cmbHistoryCarrierCustomer";
			this.cmbHistoryCarrierCustomer.Size = new global::System.Drawing.Size(91, 23);
			this.cmbHistoryCarrierCustomer.TabIndex = 87;
			this.label58.AutoSize = true;
			this.label58.Location = new global::System.Drawing.Point(6, 19);
			this.label58.Name = "label58";
			this.label58.Size = new global::System.Drawing.Size(59, 15);
			this.label58.TabIndex = 86;
			this.label58.Text = "Customer";
			this.groupBox29.Controls.Add(this.cmdUserSetHistory);
			this.groupBox29.Location = new global::System.Drawing.Point(1099, 15);
			this.groupBox29.Name = "groupBox29";
			this.groupBox29.Size = new global::System.Drawing.Size(59, 58);
			this.groupBox29.TabIndex = 85;
			this.groupBox29.TabStop = false;
			this.groupBox29.Text = "Setting";
			this.cmdUserSetHistory.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.CellDesign;
			this.cmdUserSetHistory.Location = new global::System.Drawing.Point(14, 18);
			this.cmdUserSetHistory.Name = "cmdUserSetHistory";
			this.cmdUserSetHistory.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUserSetHistory.TabIndex = 80;
			this.cmdUserSetHistory.TabStop = false;
			this.cmdUserSetHistory.Click += new global::System.EventHandler(this.cmdUserSetHistory_Click);
			this.cmdUserSetHistory.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdUserSetHistory_MouseDown);
			this.cmdUserSetHistory.MouseLeave += new global::System.EventHandler(this.cmdUserSetHistory_MouseLeave);
			this.cmdUserSetHistory.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdUserSetHistory_MouseMove);
			this.cmdUserSetHistory.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdUserSetHistory_MouseUp);
			this.cmbHistoryCarrierDevice.AutoSize = true;
			this.cmbHistoryCarrierDevice.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbHistoryCarrierDevice.Location = new global::System.Drawing.Point(168, 50);
			this.cmbHistoryCarrierDevice.Name = "cmbHistoryCarrierDevice";
			this.cmbHistoryCarrierDevice.Size = new global::System.Drawing.Size(42, 15);
			this.cmbHistoryCarrierDevice.TabIndex = 84;
			this.cmbHistoryCarrierDevice.Text = "Device";
			this.cmbHistoryCarrierType.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbHistoryCarrierType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHistoryCarrierType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbHistoryCarrierType.FormattingEnabled = true;
			this.cmbHistoryCarrierType.Location = new global::System.Drawing.Point(71, 45);
			this.cmbHistoryCarrierType.Name = "cmbHistoryCarrierType";
			this.cmbHistoryCarrierType.Size = new global::System.Drawing.Size(91, 23);
			this.cmbHistoryCarrierType.TabIndex = 48;
			this.cmbHistoryCarrierType.DropDown += new global::System.EventHandler(this.cmbHistoryCarrierType_DropDown);
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(168, 18);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(39, 15);
			this.label11.TabIndex = 45;
			this.label11.Text = "Status";
			this.cmbHistoryProduct.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbHistoryProduct.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHistoryProduct.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbHistoryProduct.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbHistoryProduct.FormattingEnabled = true;
			this.cmbHistoryProduct.Location = new global::System.Drawing.Point(223, 44);
			this.cmbHistoryProduct.Name = "cmbHistoryProduct";
			this.cmbHistoryProduct.Size = new global::System.Drawing.Size(100, 23);
			this.cmbHistoryProduct.TabIndex = 83;
			this.cmbHistoryProduct.DropDown += new global::System.EventHandler(this.cmbHistoryProduct_DropDown);
			this.groupBox11.Controls.Add(this.label13);
			this.groupBox11.Controls.Add(this.chkDate);
			this.groupBox11.Controls.Add(this.dtp_End_Histroy);
			this.groupBox11.Controls.Add(this.dtp_Start_History);
			this.groupBox11.Location = new global::System.Drawing.Point(724, 15);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new global::System.Drawing.Size(248, 55);
			this.groupBox11.TabIndex = 4;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Period";
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(128, 23);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(15, 15);
			this.label13.TabIndex = 92;
			this.label13.Text = "~";
			this.label13.Visible = false;
			this.chkDate.AutoSize = true;
			this.chkDate.Location = new global::System.Drawing.Point(6, 24);
			this.chkDate.Name = "chkDate";
			this.chkDate.Size = new global::System.Drawing.Size(15, 14);
			this.chkDate.TabIndex = 91;
			this.chkDate.UseVisualStyleBackColor = true;
			this.chkDate.Visible = false;
			this.dtp_End_Histroy.CustomFormat = "yyyy-MM-dd";
			this.dtp_End_Histroy.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_End_Histroy.Location = new global::System.Drawing.Point(148, 20);
			this.dtp_End_Histroy.Name = "dtp_End_Histroy";
			this.dtp_End_Histroy.Size = new global::System.Drawing.Size(95, 23);
			this.dtp_End_Histroy.TabIndex = 84;
			this.dtp_End_Histroy.Visible = false;
			this.dtp_Start_History.CustomFormat = "yyyy-MM-dd";
			this.dtp_Start_History.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_Start_History.Location = new global::System.Drawing.Point(28, 20);
			this.dtp_Start_History.Name = "dtp_Start_History";
			this.dtp_Start_History.Size = new global::System.Drawing.Size(95, 23);
			this.dtp_Start_History.TabIndex = 85;
			this.label17.AutoSize = true;
			this.label17.Location = new global::System.Drawing.Point(15, 47);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(31, 15);
			this.label17.TabIndex = 47;
			this.label17.Text = "Type";
			this.txtHistoryBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtHistoryBarcode.Enabled = false;
			this.txtHistoryBarcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtHistoryBarcode.Location = new global::System.Drawing.Point(560, 42);
			this.txtHistoryBarcode.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtHistoryBarcode.Name = "txtHistoryBarcode";
			this.txtHistoryBarcode.Size = new global::System.Drawing.Size(158, 23);
			this.txtHistoryBarcode.TabIndex = 0;
			this.txtHistoryBarcode.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtHistoryBarcode_KeyPress);
			this.chkcmbHistoryStatus.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.chkcmbHistoryStatus.CheckOnClick = true;
			this.chkcmbHistoryStatus.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkcmbHistoryStatus.DropDownHeight = 1;
			this.chkcmbHistoryStatus.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.chkcmbHistoryStatus.FormattingEnabled = true;
			this.chkcmbHistoryStatus.IntegralHeight = false;
			this.chkcmbHistoryStatus.Location = new global::System.Drawing.Point(223, 14);
			this.chkcmbHistoryStatus.MaxDropDownItems = 12;
			this.chkcmbHistoryStatus.Name = "chkcmbHistoryStatus";
			this.chkcmbHistoryStatus.Size = new global::System.Drawing.Size(100, 24);
			this.chkcmbHistoryStatus.TabIndex = 4;
			this.chkcmbHistoryStatus.ValueSeparator = ", ";
			this.groupBox21.Controls.Add(this.cmdHistoryExcel);
			this.groupBox21.Location = new global::System.Drawing.Point(1042, 15);
			this.groupBox21.Name = "groupBox21";
			this.groupBox21.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox21.TabIndex = 17;
			this.groupBox21.TabStop = false;
			this.groupBox21.Text = "Excel";
			this.cmdHistoryExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdHistoryExcel.Image");
			this.cmdHistoryExcel.Location = new global::System.Drawing.Point(9, 18);
			this.cmdHistoryExcel.Name = "cmdHistoryExcel";
			this.cmdHistoryExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdHistoryExcel.TabIndex = 80;
			this.cmdHistoryExcel.TabStop = false;
			this.cmdHistoryExcel.Click += new global::System.EventHandler(this.cmdHistoryExcel_Click);
			this.groupBox22.Controls.Add(this.cmdHistorySearch);
			this.groupBox22.Location = new global::System.Drawing.Point(978, 15);
			this.groupBox22.Name = "groupBox22";
			this.groupBox22.Size = new global::System.Drawing.Size(58, 58);
			this.groupBox22.TabIndex = 16;
			this.groupBox22.TabStop = false;
			this.groupBox22.Text = "Search";
			this.cmdHistorySearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdHistorySearch.Image");
			this.cmdHistorySearch.Location = new global::System.Drawing.Point(12, 18);
			this.cmdHistorySearch.Name = "cmdHistorySearch";
			this.cmdHistorySearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdHistorySearch.TabIndex = 1;
			this.cmdHistorySearch.TabStop = false;
			this.cmdHistorySearch.Click += new global::System.EventHandler(this.cmdHistorySearch_Click);
			this.tpSIBStatus.Controls.Add(this.panel13);
			this.tpSIBStatus.Location = new global::System.Drawing.Point(4, 24);
			this.tpSIBStatus.Name = "tpSIBStatus";
			this.tpSIBStatus.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpSIBStatus.Size = new global::System.Drawing.Size(1176, 697);
			this.tpSIBStatus.TabIndex = 87;
			this.tpSIBStatus.Text = "Defect Status";
			this.tpSIBStatus.UseVisualStyleBackColor = true;
			this.panel13.Controls.Add(this.panel19);
			this.panel13.Controls.Add(this.panel22);
			this.panel13.Controls.Add(this.splitter4);
			this.panel13.Controls.Add(this.panel21);
			this.panel13.Controls.Add(this.panel20);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel13.Location = new global::System.Drawing.Point(3, 3);
			this.panel13.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel13.Name = "panel13";
			this.panel13.Size = new global::System.Drawing.Size(1170, 691);
			this.panel13.TabIndex = 20;
			this.panel19.Controls.Add(this.groupBox16);
			this.panel19.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel19.Location = new global::System.Drawing.Point(0, 423);
			this.panel19.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel19.Name = "panel19";
			this.panel19.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel19.Size = new global::System.Drawing.Size(1170, 268);
			this.panel19.TabIndex = 2;
			this.groupBox16.Controls.Add(this.gridSIBStatusList);
			this.groupBox16.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox16.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox16.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox16.Size = new global::System.Drawing.Size(1164, 264);
			this.groupBox16.TabIndex = 5;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Defect Status List";
			this.gridSIBStatusList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridSIBStatusList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridSIBStatusList.EnableSort = true;
			this.gridSIBStatusList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridSIBStatusList.Location = new global::System.Drawing.Point(3, 20);
			this.gridSIBStatusList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridSIBStatusList.Name = "gridSIBStatusList";
			this.gridSIBStatusList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridSIBStatusList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridSIBStatusList.Size = new global::System.Drawing.Size(1158, 240);
			this.gridSIBStatusList.TabIndex = 13;
			this.gridSIBStatusList.TabStop = true;
			this.gridSIBStatusList.ToolTipText = "";
			this.gridSIBStatusList.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.gridSIBStatusList_MouseDoubleClick);
			this.gridSIBStatusList.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.panel22.Controls.Add(this.groupBox33);
			this.panel22.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel22.Location = new global::System.Drawing.Point(0, 379);
			this.panel22.Name = "panel22";
			this.panel22.Size = new global::System.Drawing.Size(1170, 44);
			this.panel22.TabIndex = 152;
			this.groupBox33.Controls.Add(this.cmdModifyDefect);
			this.groupBox33.Controls.Add(this.cmbSIBPeriodDate);
			this.groupBox33.Controls.Add(this.panelDetail);
			this.groupBox33.Controls.Add(this.rdoTotalData);
			this.groupBox33.Controls.Add(this.rdoPeriodData);
			this.groupBox33.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox33.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox33.Name = "groupBox33";
			this.groupBox33.Size = new global::System.Drawing.Size(1170, 44);
			this.groupBox33.TabIndex = 4;
			this.groupBox33.TabStop = false;
			this.groupBox33.Text = "Search Option";
			this.cmdModifyDefect.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdModifyDefect.Image");
			this.cmdModifyDefect.Location = new global::System.Drawing.Point(259, 10);
			this.cmdModifyDefect.Name = "cmdModifyDefect";
			this.cmdModifyDefect.Size = new global::System.Drawing.Size(32, 32);
			this.cmdModifyDefect.TabIndex = 4;
			this.cmdModifyDefect.TabStop = false;
			this.cmdModifyDefect.Click += new global::System.EventHandler(this.cmdModifyDefect_Click);
			this.cmdModifyDefect.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdModifyDefect_MouseDown);
			this.cmdModifyDefect.MouseLeave += new global::System.EventHandler(this.cmdModifyDefect_MouseLeave);
			this.cmdModifyDefect.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdModifyDefect_MouseMove);
			this.cmdModifyDefect.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdModifyDefect_MouseUp);
			this.cmbSIBPeriodDate.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbSIBPeriodDate.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSIBPeriodDate.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbSIBPeriodDate.FormattingEnabled = true;
			this.cmbSIBPeriodDate.Location = new global::System.Drawing.Point(507, 15);
			this.cmbSIBPeriodDate.Name = "cmbSIBPeriodDate";
			this.cmbSIBPeriodDate.Size = new global::System.Drawing.Size(171, 23);
			this.cmbSIBPeriodDate.TabIndex = 89;
			this.cmbSIBPeriodDate.Visible = false;
			this.cmbSIBPeriodDate.SelectedIndexChanged += new global::System.EventHandler(this.cmbSIBPeriodDate_SelectedIndexChanged);
			this.panelDetail.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelDetail.Controls.Add(this.chkDefectCarrier);
			this.panelDetail.Controls.Add(this.chkDefectSIB);
			this.panelDetail.Location = new global::System.Drawing.Point(136, 10);
			this.panelDetail.Name = "panelDetail";
			this.panelDetail.Size = new global::System.Drawing.Size(117, 32);
			this.panelDetail.TabIndex = 92;
			this.chkDefectCarrier.AutoSize = true;
			this.chkDefectCarrier.Checked = true;
			this.chkDefectCarrier.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkDefectCarrier.Location = new global::System.Drawing.Point(2, 6);
			this.chkDefectCarrier.Name = "chkDefectCarrier";
			this.chkDefectCarrier.Size = new global::System.Drawing.Size(61, 19);
			this.chkDefectCarrier.TabIndex = 90;
			this.chkDefectCarrier.Text = "Carrier";
			this.chkDefectCarrier.UseVisualStyleBackColor = true;
			this.chkDefectCarrier.CheckedChanged += new global::System.EventHandler(this.chkDefectCarrier_CheckedChanged);
			this.chkDefectSIB.AutoSize = true;
			this.chkDefectSIB.Checked = true;
			this.chkDefectSIB.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkDefectSIB.Location = new global::System.Drawing.Point(69, 6);
			this.chkDefectSIB.Name = "chkDefectSIB";
			this.chkDefectSIB.Size = new global::System.Drawing.Size(42, 19);
			this.chkDefectSIB.TabIndex = 91;
			this.chkDefectSIB.Text = "SIB";
			this.chkDefectSIB.UseVisualStyleBackColor = true;
			this.chkDefectSIB.CheckedChanged += new global::System.EventHandler(this.chkDefectSIB_CheckedChanged);
			this.rdoTotalData.AutoSize = true;
			this.rdoTotalData.Checked = true;
			this.rdoTotalData.Location = new global::System.Drawing.Point(6, 17);
			this.rdoTotalData.Name = "rdoTotalData";
			this.rdoTotalData.Size = new global::System.Drawing.Size(50, 19);
			this.rdoTotalData.TabIndex = 87;
			this.rdoTotalData.TabStop = true;
			this.rdoTotalData.Text = "Total";
			this.rdoTotalData.UseVisualStyleBackColor = true;
			this.rdoTotalData.CheckedChanged += new global::System.EventHandler(this.rdoTotalData_CheckedChanged);
			this.rdoPeriodData.AutoSize = true;
			this.rdoPeriodData.Location = new global::System.Drawing.Point(74, 17);
			this.rdoPeriodData.Name = "rdoPeriodData";
			this.rdoPeriodData.Size = new global::System.Drawing.Size(55, 19);
			this.rdoPeriodData.TabIndex = 88;
			this.rdoPeriodData.Text = "Detail";
			this.rdoPeriodData.UseVisualStyleBackColor = true;
			this.rdoPeriodData.CheckedChanged += new global::System.EventHandler(this.rdoPeriodData_CheckedChanged);
			this.splitter4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter4.Location = new global::System.Drawing.Point(0, 375);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new global::System.Drawing.Size(1170, 4);
			this.splitter4.TabIndex = 151;
			this.splitter4.TabStop = false;
			this.panel21.Controls.Add(this.chart_SIBView);
			this.panel21.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel21.Location = new global::System.Drawing.Point(0, 72);
			this.panel21.Name = "panel21";
			this.panel21.Size = new global::System.Drawing.Size(1170, 303);
			this.panel21.TabIndex = 150;
			this.chart_SIBView.BackGradientStyle = global::System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart_SIBView.BackSecondaryColor = global::System.Drawing.Color.White;
			this.chart_SIBView.BorderlineColor = global::System.Drawing.Color.Silver;
			this.chart_SIBView.BorderlineDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
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
			this.chart_SIBView.ChartAreas.Add(chartArea2);
			this.chart_SIBView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			legend2.Alignment = global::System.Drawing.StringAlignment.Center;
			legend2.BackColor = global::System.Drawing.Color.Transparent;
			legend2.BorderColor = global::System.Drawing.Color.Transparent;
			legend2.Docking = global::System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			legend2.IsTextAutoFit = false;
			legend2.Name = "Legend1";
			this.chart_SIBView.Legends.Add(legend2);
			this.chart_SIBView.Location = new global::System.Drawing.Point(0, 0);
			this.chart_SIBView.Name = "chart_SIBView";
			this.chart_SIBView.Size = new global::System.Drawing.Size(1170, 303);
			this.chart_SIBView.TabIndex = 147;
			this.chart_SIBView.Text = "chart_SIB";
			title2.BackColor = global::System.Drawing.Color.Transparent;
			title2.BackImageAlignment = global::System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
			title2.BackImageWrapMode = global::System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
			title2.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			title2.Name = "Title1";
			title2.ShadowColor = global::System.Drawing.Color.Silver;
			title2.Text = "SIB Defect Status";
			this.chart_SIBView.Titles.Add(title2);
			this.panel20.Controls.Add(this.groupBox25);
			this.panel20.Controls.Add(this.groupBox26);
			this.panel20.Controls.Add(this.groupBox24);
			this.panel20.Controls.Add(this.groupBox23);
			this.panel20.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel20.Location = new global::System.Drawing.Point(0, 0);
			this.panel20.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel20.Name = "panel20";
			this.panel20.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel20.Size = new global::System.Drawing.Size(1170, 72);
			this.panel20.TabIndex = 60;
			this.groupBox25.Controls.Add(this.rdoMonth_SIB);
			this.groupBox25.Controls.Add(this.rdoPeriod_SIB);
			this.groupBox25.Controls.Add(this.rdoWeek_SIB);
			this.groupBox25.Controls.Add(this.rdoDay_SIB);
			this.groupBox25.Controls.Add(this.dtp_end_SIB);
			this.groupBox25.Controls.Add(this.dtp_start_SIB);
			this.groupBox25.Location = new global::System.Drawing.Point(5, 4);
			this.groupBox25.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox25.Name = "groupBox25";
			this.groupBox25.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox25.Size = new global::System.Drawing.Size(612, 64);
			this.groupBox25.TabIndex = 149;
			this.groupBox25.TabStop = false;
			this.groupBox25.Text = "Option";
			this.rdoMonth_SIB.AutoSize = true;
			this.rdoMonth_SIB.Location = new global::System.Drawing.Point(128, 27);
			this.rdoMonth_SIB.Name = "rdoMonth_SIB";
			this.rdoMonth_SIB.Size = new global::System.Drawing.Size(61, 19);
			this.rdoMonth_SIB.TabIndex = 87;
			this.rdoMonth_SIB.Text = "Month";
			this.rdoMonth_SIB.UseVisualStyleBackColor = true;
			this.rdoPeriod_SIB.AutoSize = true;
			this.rdoPeriod_SIB.Location = new global::System.Drawing.Point(195, 27);
			this.rdoPeriod_SIB.Name = "rdoPeriod_SIB";
			this.rdoPeriod_SIB.Size = new global::System.Drawing.Size(59, 19);
			this.rdoPeriod_SIB.TabIndex = 86;
			this.rdoPeriod_SIB.Text = "Period";
			this.rdoPeriod_SIB.UseVisualStyleBackColor = true;
			this.rdoWeek_SIB.AutoSize = true;
			this.rdoWeek_SIB.Location = new global::System.Drawing.Point(68, 27);
			this.rdoWeek_SIB.Name = "rdoWeek_SIB";
			this.rdoWeek_SIB.Size = new global::System.Drawing.Size(54, 19);
			this.rdoWeek_SIB.TabIndex = 85;
			this.rdoWeek_SIB.Text = "Week";
			this.rdoWeek_SIB.UseVisualStyleBackColor = true;
			this.rdoDay_SIB.AutoSize = true;
			this.rdoDay_SIB.Checked = true;
			this.rdoDay_SIB.Location = new global::System.Drawing.Point(17, 27);
			this.rdoDay_SIB.Name = "rdoDay_SIB";
			this.rdoDay_SIB.Size = new global::System.Drawing.Size(45, 19);
			this.rdoDay_SIB.TabIndex = 84;
			this.rdoDay_SIB.TabStop = true;
			this.rdoDay_SIB.Text = "Day";
			this.rdoDay_SIB.UseVisualStyleBackColor = true;
			this.dtp_end_SIB.CustomFormat = "'End Date : ' yyyy-MM-dd";
			this.dtp_end_SIB.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_end_SIB.Location = new global::System.Drawing.Point(430, 25);
			this.dtp_end_SIB.Name = "dtp_end_SIB";
			this.dtp_end_SIB.Size = new global::System.Drawing.Size(161, 23);
			this.dtp_end_SIB.TabIndex = 1;
			this.dtp_end_SIB.CloseUp += new global::System.EventHandler(this.dtp_end_SIB_CloseUp);
			this.dtp_start_SIB.CustomFormat = "'Start Date : ' yyyy-MM-dd";
			this.dtp_start_SIB.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtp_start_SIB.Location = new global::System.Drawing.Point(260, 25);
			this.dtp_start_SIB.Name = "dtp_start_SIB";
			this.dtp_start_SIB.Size = new global::System.Drawing.Size(161, 23);
			this.dtp_start_SIB.TabIndex = 83;
			this.dtp_start_SIB.CloseUp += new global::System.EventHandler(this.dtp_start_SIB_CloseUp);
			this.groupBox26.Controls.Add(this.cmbDefectProduct);
			this.groupBox26.Location = new global::System.Drawing.Point(623, 4);
			this.groupBox26.Name = "groupBox26";
			this.groupBox26.Size = new global::System.Drawing.Size(137, 64);
			this.groupBox26.TabIndex = 150;
			this.groupBox26.TabStop = false;
			this.groupBox26.Text = "Product";
			this.cmbDefectProduct.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbDefectProduct.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDefectProduct.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbDefectProduct.FormattingEnabled = true;
			this.cmbDefectProduct.Location = new global::System.Drawing.Point(6, 24);
			this.cmbDefectProduct.Name = "cmbDefectProduct";
			this.cmbDefectProduct.Size = new global::System.Drawing.Size(126, 23);
			this.cmbDefectProduct.TabIndex = 54;
			this.cmbDefectProduct.DropDown += new global::System.EventHandler(this.cmbDefectProduct_DropDown);
			this.groupBox24.Controls.Add(this.cmdDefectSearch);
			this.groupBox24.Location = new global::System.Drawing.Point(766, 5);
			this.groupBox24.Name = "groupBox24";
			this.groupBox24.Size = new global::System.Drawing.Size(58, 63);
			this.groupBox24.TabIndex = 16;
			this.groupBox24.TabStop = false;
			this.groupBox24.Text = "Search";
			this.cmdDefectSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdDefectSearch.Image");
			this.cmdDefectSearch.Location = new global::System.Drawing.Point(12, 18);
			this.cmdDefectSearch.Name = "cmdDefectSearch";
			this.cmdDefectSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDefectSearch.TabIndex = 1;
			this.cmdDefectSearch.TabStop = false;
			this.cmdDefectSearch.Click += new global::System.EventHandler(this.cmdDefectSearch_Click);
			this.groupBox23.Controls.Add(this.cmdSIBExcel);
			this.groupBox23.Location = new global::System.Drawing.Point(830, 5);
			this.groupBox23.Name = "groupBox23";
			this.groupBox23.Size = new global::System.Drawing.Size(51, 63);
			this.groupBox23.TabIndex = 17;
			this.groupBox23.TabStop = false;
			this.groupBox23.Text = "Excel";
			this.cmdSIBExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdSIBExcel.Image");
			this.cmdSIBExcel.Location = new global::System.Drawing.Point(9, 18);
			this.cmdSIBExcel.Name = "cmdSIBExcel";
			this.cmdSIBExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdSIBExcel.TabIndex = 80;
			this.cmdSIBExcel.TabStop = false;
			this.cmdSIBExcel.Click += new global::System.EventHandler(this.cmdDefectExcel_Click);
			this.tpBlackList.Controls.Add(this.panel23);
			this.tpBlackList.Location = new global::System.Drawing.Point(4, 24);
			this.tpBlackList.Name = "tpBlackList";
			this.tpBlackList.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpBlackList.Size = new global::System.Drawing.Size(1176, 697);
			this.tpBlackList.TabIndex = 88;
			this.tpBlackList.Text = "BlackList";
			this.tpBlackList.UseVisualStyleBackColor = true;
			this.panel23.Controls.Add(this.txtMgrBarcode);
			this.panel23.Controls.Add(this.panel24);
			this.panel23.Controls.Add(this.panel26);
			this.panel23.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel23.Location = new global::System.Drawing.Point(3, 3);
			this.panel23.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel23.Name = "panel23";
			this.panel23.Size = new global::System.Drawing.Size(1170, 691);
			this.panel23.TabIndex = 20;
			this.txtMgrBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtMgrBarcode.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtMgrBarcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtMgrBarcode.Location = new global::System.Drawing.Point(827, 14);
			this.txtMgrBarcode.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtMgrBarcode.Multiline = true;
			this.txtMgrBarcode.Name = "txtMgrBarcode";
			this.txtMgrBarcode.Size = new global::System.Drawing.Size(218, 21);
			this.txtMgrBarcode.TabIndex = 0;
			this.txtMgrBarcode.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtMgrBarcode_KeyPress);
			this.txtMgrBarcode.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.txtMgrBarcode_MouseDoubleClick);
			this.panel24.Controls.Add(this.groupBox17);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel24.Location = new global::System.Drawing.Point(0, 47);
			this.panel24.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel24.Name = "panel24";
			this.panel24.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel24.Size = new global::System.Drawing.Size(1170, 644);
			this.panel24.TabIndex = 2;
			this.groupBox17.Controls.Add(this.gridMgrCarrier);
			this.groupBox17.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox17.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox17.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox17.Size = new global::System.Drawing.Size(1164, 640);
			this.groupBox17.TabIndex = 5;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Carrier History List";
			this.gridMgrCarrier.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridMgrCarrier.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridMgrCarrier.EnableSort = true;
			this.gridMgrCarrier.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridMgrCarrier.Location = new global::System.Drawing.Point(3, 20);
			this.gridMgrCarrier.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridMgrCarrier.Name = "gridMgrCarrier";
			this.gridMgrCarrier.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridMgrCarrier.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridMgrCarrier.Size = new global::System.Drawing.Size(1158, 616);
			this.gridMgrCarrier.TabIndex = 13;
			this.gridMgrCarrier.TabStop = true;
			this.gridMgrCarrier.ToolTipText = "";
			this.gridMgrCarrier.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.gridMgrCarrier_MouseDoubleClick);
			this.gridMgrCarrier.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.gridMgrCarrier_MouseDown);
			this.gridMgrCarrier.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.panel26.Controls.Add(this.groupBox20);
			this.panel26.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel26.Location = new global::System.Drawing.Point(0, 0);
			this.panel26.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel26.Name = "panel26";
			this.panel26.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel26.Size = new global::System.Drawing.Size(1170, 47);
			this.panel26.TabIndex = 60;
			this.groupBox20.Controls.Add(this.chkBarcodeFlag);
			this.groupBox20.Controls.Add(this.cmbMgrTester);
			this.groupBox20.Controls.Add(this.label36);
			this.groupBox20.Controls.Add(this.cmbMgrType);
			this.groupBox20.Controls.Add(this.label33);
			this.groupBox20.Controls.Add(this.label31);
			this.groupBox20.Controls.Add(this.cmbMgrProduct);
			this.groupBox20.Controls.Add(this.cmdMgrExcel);
			this.groupBox20.Controls.Add(this.cmdMgrSearch);
			this.groupBox20.Controls.Add(this.chkcmbStatus);
			this.groupBox20.Controls.Add(this.label34);
			this.groupBox20.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox20.Font = new global::System.Drawing.Font("Segoe UI", 1f);
			this.groupBox20.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox20.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox20.Size = new global::System.Drawing.Size(1164, 41);
			this.groupBox20.TabIndex = 6;
			this.groupBox20.TabStop = false;
			this.chkBarcodeFlag.AutoSize = true;
			this.chkBarcodeFlag.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.chkBarcodeFlag.Location = new global::System.Drawing.Point(752, 12);
			this.chkBarcodeFlag.Name = "chkBarcodeFlag";
			this.chkBarcodeFlag.Size = new global::System.Drawing.Size(69, 19);
			this.chkBarcodeFlag.TabIndex = 88;
			this.chkBarcodeFlag.Text = "Barcode";
			this.chkBarcodeFlag.UseVisualStyleBackColor = true;
			this.cmbMgrTester.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbMgrTester.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMgrTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbMgrTester.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbMgrTester.FormattingEnabled = true;
			this.cmbMgrTester.Location = new global::System.Drawing.Point(624, 10);
			this.cmbMgrTester.Name = "cmbMgrTester";
			this.cmbMgrTester.Size = new global::System.Drawing.Size(116, 23);
			this.cmbMgrTester.TabIndex = 82;
			this.cmbMgrTester.DropDown += new global::System.EventHandler(this.cmbMgrTester_DropDown);
			this.label36.AutoSize = true;
			this.label36.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label36.Location = new global::System.Drawing.Point(579, 13);
			this.label36.Name = "label36";
			this.label36.Size = new global::System.Drawing.Size(37, 15);
			this.label36.TabIndex = 87;
			this.label36.Text = "Tester";
			this.cmbMgrType.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbMgrType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMgrType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbMgrType.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbMgrType.FormattingEnabled = true;
			this.cmbMgrType.Location = new global::System.Drawing.Point(46, 10);
			this.cmbMgrType.Name = "cmbMgrType";
			this.cmbMgrType.Size = new global::System.Drawing.Size(132, 23);
			this.cmbMgrType.TabIndex = 85;
			this.cmbMgrType.DropDown += new global::System.EventHandler(this.cmbMgrType_DropDown);
			this.label33.AutoSize = true;
			this.label33.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label33.Location = new global::System.Drawing.Point(8, 13);
			this.label33.Name = "label33";
			this.label33.Size = new global::System.Drawing.Size(31, 15);
			this.label33.TabIndex = 84;
			this.label33.Text = "Type";
			this.label31.AutoSize = true;
			this.label31.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label31.Location = new global::System.Drawing.Point(195, 13);
			this.label31.Name = "label31";
			this.label31.Size = new global::System.Drawing.Size(49, 15);
			this.label31.TabIndex = 82;
			this.label31.Text = "Product";
			this.cmbMgrProduct.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.cmbMgrProduct.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMgrProduct.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbMgrProduct.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cmbMgrProduct.FormattingEnabled = true;
			this.cmbMgrProduct.Location = new global::System.Drawing.Point(250, 10);
			this.cmbMgrProduct.Name = "cmbMgrProduct";
			this.cmbMgrProduct.Size = new global::System.Drawing.Size(115, 23);
			this.cmbMgrProduct.TabIndex = 81;
			this.cmbMgrProduct.DropDown += new global::System.EventHandler(this.cmbMgrProduct_DropDown);
			this.cmdMgrExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdMgrExcel.Image");
			this.cmdMgrExcel.Location = new global::System.Drawing.Point(1104, 5);
			this.cmdMgrExcel.Name = "cmdMgrExcel";
			this.cmdMgrExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdMgrExcel.TabIndex = 80;
			this.cmdMgrExcel.TabStop = false;
			this.cmdMgrExcel.Click += new global::System.EventHandler(this.cmdMgrExcel_Click);
			this.cmdMgrSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdMgrSearch.Image");
			this.cmdMgrSearch.Location = new global::System.Drawing.Point(1061, 5);
			this.cmdMgrSearch.Name = "cmdMgrSearch";
			this.cmdMgrSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdMgrSearch.TabIndex = 1;
			this.cmdMgrSearch.TabStop = false;
			this.cmdMgrSearch.Click += new global::System.EventHandler(this.cmdMgrSearch_Click);
			this.chkcmbStatus.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.chkcmbStatus.CheckOnClick = true;
			this.chkcmbStatus.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.chkcmbStatus.DropDownHeight = 1;
			this.chkcmbStatus.DropDownWidth = 120;
			this.chkcmbStatus.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.chkcmbStatus.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.chkcmbStatus.FormattingEnabled = true;
			this.chkcmbStatus.IntegralHeight = false;
			this.chkcmbStatus.Location = new global::System.Drawing.Point(434, 7);
			this.chkcmbStatus.MaxDropDownItems = 12;
			this.chkcmbStatus.Name = "chkcmbStatus";
			this.chkcmbStatus.Size = new global::System.Drawing.Size(126, 24);
			this.chkcmbStatus.TabIndex = 4;
			this.chkcmbStatus.ValueSeparator = ", ";
			this.label34.AutoSize = true;
			this.label34.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label34.Location = new global::System.Drawing.Point(389, 13);
			this.label34.Name = "label34";
			this.label34.Size = new global::System.Drawing.Size(39, 15);
			this.label34.TabIndex = 45;
			this.label34.Text = "Status";
			this.tpSWHistory.Controls.Add(this.panel27);
			this.tpSWHistory.Location = new global::System.Drawing.Point(4, 24);
			this.tpSWHistory.Name = "tpSWHistory";
			this.tpSWHistory.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpSWHistory.Size = new global::System.Drawing.Size(1176, 697);
			this.tpSWHistory.TabIndex = 89;
			this.tpSWHistory.Text = "SW History";
			this.tpSWHistory.UseVisualStyleBackColor = true;
			this.panel27.Controls.Add(this.panel28);
			this.panel27.Controls.Add(this.panel29);
			this.panel27.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel27.Location = new global::System.Drawing.Point(3, 3);
			this.panel27.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel27.Name = "panel27";
			this.panel27.Size = new global::System.Drawing.Size(1170, 691);
			this.panel27.TabIndex = 21;
			this.panel28.Controls.Add(this.groupBox27);
			this.panel28.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel28.Location = new global::System.Drawing.Point(0, 47);
			this.panel28.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel28.Name = "panel28";
			this.panel28.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel28.Size = new global::System.Drawing.Size(1170, 644);
			this.panel28.TabIndex = 2;
			this.groupBox27.Controls.Add(this.gridSWHistory);
			this.groupBox27.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox27.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox27.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox27.Name = "groupBox27";
			this.groupBox27.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox27.Size = new global::System.Drawing.Size(1164, 640);
			this.groupBox27.TabIndex = 5;
			this.groupBox27.TabStop = false;
			this.groupBox27.Text = "SW History List";
			this.gridSWHistory.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridSWHistory.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridSWHistory.EnableSort = true;
			this.gridSWHistory.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridSWHistory.Location = new global::System.Drawing.Point(3, 20);
			this.gridSWHistory.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridSWHistory.Name = "gridSWHistory";
			this.gridSWHistory.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridSWHistory.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridSWHistory.Size = new global::System.Drawing.Size(1158, 616);
			this.gridSWHistory.TabIndex = 13;
			this.gridSWHistory.TabStop = true;
			this.gridSWHistory.ToolTipText = "";
			this.gridSWHistory.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.gridSWHistory_MouseDoubleClick);
			this.gridSWHistory.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.gridSWHistory_MouseDown);
			this.panel29.Controls.Add(this.groupBox28);
			this.panel29.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel29.Location = new global::System.Drawing.Point(0, 0);
			this.panel29.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel29.Name = "panel29";
			this.panel29.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel29.Size = new global::System.Drawing.Size(1170, 47);
			this.panel29.TabIndex = 60;
			this.groupBox28.Controls.Add(this.cmdDelete);
			this.groupBox28.Controls.Add(this.cmdSWAdd);
			this.groupBox28.Controls.Add(this.label39);
			this.groupBox28.Controls.Add(this.txtSWVersion);
			this.groupBox28.Controls.Add(this.cmdSWExcel);
			this.groupBox28.Controls.Add(this.cmdSWSearch);
			this.groupBox28.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox28.Font = new global::System.Drawing.Font("Segoe UI", 1f);
			this.groupBox28.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox28.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox28.Name = "groupBox28";
			this.groupBox28.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox28.Size = new global::System.Drawing.Size(1164, 41);
			this.groupBox28.TabIndex = 6;
			this.groupBox28.TabStop = false;
			this.cmdDelete.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableRemove;
			this.cmdDelete.Location = new global::System.Drawing.Point(467, 5);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDelete.TabIndex = 87;
			this.cmdDelete.TabStop = false;
			this.cmdDelete.Click += new global::System.EventHandler(this.cmdDelete_Click);
			this.cmdDelete.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDelete_MouseDown);
			this.cmdDelete.MouseLeave += new global::System.EventHandler(this.cmdDelete_MouseLeave);
			this.cmdDelete.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDelete_MouseMove);
			this.cmdDelete.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDelete_MouseUp);
			this.cmdSWAdd.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdSWAdd.Image");
			this.cmdSWAdd.Location = new global::System.Drawing.Point(423, 5);
			this.cmdSWAdd.Name = "cmdSWAdd";
			this.cmdSWAdd.Size = new global::System.Drawing.Size(32, 32);
			this.cmdSWAdd.TabIndex = 86;
			this.cmdSWAdd.TabStop = false;
			this.cmdSWAdd.Click += new global::System.EventHandler(this.cmdSWAdd_Click);
			this.label39.AutoSize = true;
			this.label39.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label39.Location = new global::System.Drawing.Point(15, 13);
			this.label39.Name = "label39";
			this.label39.Size = new global::System.Drawing.Size(65, 15);
			this.label39.TabIndex = 3;
			this.label39.Text = "SW Version";
			this.txtSWVersion.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtSWVersion.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtSWVersion.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtSWVersion.Location = new global::System.Drawing.Point(86, 10);
			this.txtSWVersion.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtSWVersion.Name = "txtSWVersion";
			this.txtSWVersion.Size = new global::System.Drawing.Size(203, 23);
			this.txtSWVersion.TabIndex = 0;
			this.txtSWVersion.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtSWVersion_KeyPress);
			this.cmdSWExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdSWExcel.Image");
			this.cmdSWExcel.Location = new global::System.Drawing.Point(350, 5);
			this.cmdSWExcel.Name = "cmdSWExcel";
			this.cmdSWExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdSWExcel.TabIndex = 80;
			this.cmdSWExcel.TabStop = false;
			this.cmdSWExcel.Click += new global::System.EventHandler(this.cmdSWExcel_Click);
			this.cmdSWSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdSWSearch.Image");
			this.cmdSWSearch.Location = new global::System.Drawing.Point(306, 5);
			this.cmdSWSearch.Name = "cmdSWSearch";
			this.cmdSWSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdSWSearch.TabIndex = 1;
			this.cmdSWSearch.TabStop = false;
			this.cmdSWSearch.Click += new global::System.EventHandler(this.cmdSWSearch_Click);
			this.tpSocketManage.Controls.Add(this.tc_SM_Detail);
			this.tpSocketManage.Controls.Add(this.panel33);
			this.tpSocketManage.Location = new global::System.Drawing.Point(4, 24);
			this.tpSocketManage.Name = "tpSocketManage";
			this.tpSocketManage.Size = new global::System.Drawing.Size(1176, 697);
			this.tpSocketManage.TabIndex = 91;
			this.tpSocketManage.Text = "Socket Management";
			this.tpSocketManage.UseVisualStyleBackColor = true;
			this.tc_SM_Detail.Controls.Add(this.tpSM_tpSocketComment);
			this.tc_SM_Detail.Controls.Add(this.tpSM_tpEnrollSocket);
			this.tc_SM_Detail.Controls.Add(this.tpSM_tpPeriodComment);
			this.tc_SM_Detail.Controls.Add(this.tpSM_tpCompledTrend);
			this.tc_SM_Detail.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tc_SM_Detail.Location = new global::System.Drawing.Point(0, 34);
			this.tc_SM_Detail.Name = "tc_SM_Detail";
			this.tc_SM_Detail.SelectedIndex = 0;
			this.tc_SM_Detail.Size = new global::System.Drawing.Size(1176, 663);
			this.tc_SM_Detail.TabIndex = 26;
			this.tpSM_tpSocketComment.Controls.Add(this.panel30);
			this.tpSM_tpSocketComment.Controls.Add(this.panel7);
			this.tpSM_tpSocketComment.Controls.Add(this.splitter5);
			this.tpSM_tpSocketComment.Controls.Add(this.panel11);
			this.tpSM_tpSocketComment.Location = new global::System.Drawing.Point(4, 24);
			this.tpSM_tpSocketComment.Name = "tpSM_tpSocketComment";
			this.tpSM_tpSocketComment.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpSM_tpSocketComment.Size = new global::System.Drawing.Size(1168, 635);
			this.tpSM_tpSocketComment.TabIndex = 0;
			this.tpSM_tpSocketComment.Text = "Comment History";
			this.tpSM_tpSocketComment.UseVisualStyleBackColor = true;
			this.panel30.Controls.Add(this.grid_socket_comment);
			this.panel30.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel30.Location = new global::System.Drawing.Point(255, 102);
			this.panel30.Name = "panel30";
			this.panel30.Size = new global::System.Drawing.Size(910, 530);
			this.panel30.TabIndex = 66;
			this.grid_socket_comment.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_socket_comment.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_socket_comment.EnableSort = true;
			this.grid_socket_comment.Font = new global::System.Drawing.Font("Segoe UI", 8.25f);
			this.grid_socket_comment.Location = new global::System.Drawing.Point(0, 0);
			this.grid_socket_comment.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grid_socket_comment.Name = "grid_socket_comment";
			this.grid_socket_comment.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_socket_comment.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_socket_comment.Size = new global::System.Drawing.Size(910, 530);
			this.grid_socket_comment.TabIndex = 16;
			this.grid_socket_comment.TabStop = true;
			this.grid_socket_comment.ToolTipText = "";
			this.grid_socket_comment.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.panel7.Controls.Add(this.groupBox32);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new global::System.Drawing.Point(255, 3);
			this.panel7.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel7.Size = new global::System.Drawing.Size(910, 99);
			this.panel7.TabIndex = 65;
			this.groupBox32.Controls.Add(this.groupBox34);
			this.groupBox32.Controls.Add(this.groupBox35);
			this.groupBox32.Controls.Add(this.groupBox36);
			this.groupBox32.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox32.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox32.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox32.Name = "groupBox32";
			this.groupBox32.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox32.Size = new global::System.Drawing.Size(904, 93);
			this.groupBox32.TabIndex = 6;
			this.groupBox32.TabStop = false;
			this.groupBox34.Controls.Add(this.tpSM_tpComment_lblSocketType);
			this.groupBox34.Controls.Add(this.label54);
			this.groupBox34.Controls.Add(this.tpSM_tpComment_lblMfg);
			this.groupBox34.Controls.Add(this.label48);
			this.groupBox34.Controls.Add(this.tpSM_tpComment_lblPn);
			this.groupBox34.Controls.Add(this.label46);
			this.groupBox34.Controls.Add(this.tpSM_tpComment_lblBarcode);
			this.groupBox34.Controls.Add(this.tpSM_tpComment_lblPkgType);
			this.groupBox34.Controls.Add(this.tpSM_tpComment_lblDevice);
			this.groupBox34.Controls.Add(this.tpSM_tpComment_lblCustomer);
			this.groupBox34.Controls.Add(this.label41);
			this.groupBox34.Controls.Add(this.label42);
			this.groupBox34.Controls.Add(this.label43);
			this.groupBox34.Controls.Add(this.label44);
			this.groupBox34.Location = new global::System.Drawing.Point(6, 13);
			this.groupBox34.Name = "groupBox34";
			this.groupBox34.Size = new global::System.Drawing.Size(754, 73);
			this.groupBox34.TabIndex = 25;
			this.groupBox34.TabStop = false;
			this.groupBox34.Text = "Socket Information";
			this.tpSM_tpComment_lblSocketType.AutoSize = true;
			this.tpSM_tpComment_lblSocketType.Location = new global::System.Drawing.Point(677, 20);
			this.tpSM_tpComment_lblSocketType.Name = "tpSM_tpComment_lblSocketType";
			this.tpSM_tpComment_lblSocketType.Size = new global::System.Drawing.Size(53, 15);
			this.tpSM_tpComment_lblSocketType.TabIndex = 21;
			this.tpSM_tpComment_lblSocketType.Text = "BOTTOM";
			this.label54.AutoSize = true;
			this.label54.Location = new global::System.Drawing.Point(595, 21);
			this.label54.Name = "label54";
			this.label54.Size = new global::System.Drawing.Size(75, 15);
			this.label54.TabIndex = 20;
			this.label54.Text = "SocketType : ";
			this.tpSM_tpComment_lblMfg.AutoSize = true;
			this.tpSM_tpComment_lblMfg.Location = new global::System.Drawing.Point(264, 20);
			this.tpSM_tpComment_lblMfg.Name = "tpSM_tpComment_lblMfg";
			this.tpSM_tpComment_lblMfg.Size = new global::System.Drawing.Size(55, 15);
			this.tpSM_tpComment_lblMfg.TabIndex = 19;
			this.tpSM_tpComment_lblMfg.Text = "Yamaichi";
			this.label48.AutoSize = true;
			this.label48.Location = new global::System.Drawing.Point(218, 21);
			this.label48.Name = "label48";
			this.label48.Size = new global::System.Drawing.Size(41, 15);
			this.label48.TabIndex = 18;
			this.label48.Text = "MFG : ";
			this.tpSM_tpComment_lblPn.AutoSize = true;
			this.tpSM_tpComment_lblPn.Location = new global::System.Drawing.Point(264, 48);
			this.tpSM_tpComment_lblPn.Name = "tpSM_tpComment_lblPn";
			this.tpSM_tpComment_lblPn.Size = new global::System.Drawing.Size(36, 15);
			this.tpSM_tpComment_lblPn.TabIndex = 17;
			this.tpSM_tpComment_lblPn.Text = "366-4";
			this.label46.AutoSize = true;
			this.label46.Location = new global::System.Drawing.Point(218, 48);
			this.label46.Name = "label46";
			this.label46.Size = new global::System.Drawing.Size(32, 15);
			this.label46.TabIndex = 16;
			this.label46.Text = "PN : ";
			this.tpSM_tpComment_lblBarcode.AutoSize = true;
			this.tpSM_tpComment_lblBarcode.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tpSM_tpComment_lblBarcode.ForeColor = global::System.Drawing.Color.Blue;
			this.tpSM_tpComment_lblBarcode.Location = new global::System.Drawing.Point(465, 21);
			this.tpSM_tpComment_lblBarcode.Name = "tpSM_tpComment_lblBarcode";
			this.tpSM_tpComment_lblBarcode.Size = new global::System.Drawing.Size(75, 15);
			this.tpSM_tpComment_lblBarcode.TabIndex = 15;
			this.tpSM_tpComment_lblBarcode.Text = "17351-330T";
			this.tpSM_tpComment_lblPkgType.AutoSize = true;
			this.tpSM_tpComment_lblPkgType.Location = new global::System.Drawing.Point(465, 48);
			this.tpSM_tpComment_lblPkgType.Name = "tpSM_tpComment_lblPkgType";
			this.tpSM_tpComment_lblPkgType.Size = new global::System.Drawing.Size(118, 15);
			this.tpSM_tpComment_lblPkgType.TabIndex = 14;
			this.tpSM_tpComment_lblPkgType.Text = "12.4X12.4 914B MPSP";
			this.tpSM_tpComment_lblDevice.AutoSize = true;
			this.tpSM_tpComment_lblDevice.Location = new global::System.Drawing.Point(84, 48);
			this.tpSM_tpComment_lblDevice.Name = "tpSM_tpComment_lblDevice";
			this.tpSM_tpComment_lblDevice.Size = new global::System.Drawing.Size(47, 15);
			this.tpSM_tpComment_lblDevice.TabIndex = 13;
			this.tpSM_tpComment_lblDevice.Text = "NAPALI";
			this.tpSM_tpComment_lblCustomer.AutoSize = true;
			this.tpSM_tpComment_lblCustomer.Location = new global::System.Drawing.Point(84, 21);
			this.tpSM_tpComment_lblCustomer.Name = "tpSM_tpComment_lblCustomer";
			this.tpSM_tpComment_lblCustomer.Size = new global::System.Drawing.Size(67, 15);
			this.tpSM_tpComment_lblCustomer.TabIndex = 12;
			this.tpSM_tpComment_lblCustomer.Text = "Qualcomm";
			this.label41.AutoSize = true;
			this.label41.Location = new global::System.Drawing.Point(371, 21);
			this.label41.Name = "label41";
			this.label41.Size = new global::System.Drawing.Size(59, 15);
			this.label41.TabIndex = 11;
			this.label41.Text = "Barcode : ";
			this.label42.AutoSize = true;
			this.label42.Location = new global::System.Drawing.Point(371, 48);
			this.label42.Name = "label42";
			this.label42.Size = new global::System.Drawing.Size(87, 15);
			this.label42.TabIndex = 10;
			this.label42.Text = "Package Type : ";
			this.label43.AutoSize = true;
			this.label43.Location = new global::System.Drawing.Point(10, 48);
			this.label43.Name = "label43";
			this.label43.Size = new global::System.Drawing.Size(51, 15);
			this.label43.TabIndex = 9;
			this.label43.Text = "Device : ";
			this.label44.AutoSize = true;
			this.label44.Location = new global::System.Drawing.Point(10, 21);
			this.label44.Name = "label44";
			this.label44.Size = new global::System.Drawing.Size(68, 15);
			this.label44.TabIndex = 8;
			this.label44.Text = "Customer : ";
			this.groupBox35.Controls.Add(this.pb_comment_insert);
			this.groupBox35.Location = new global::System.Drawing.Point(766, 13);
			this.groupBox35.Name = "groupBox35";
			this.groupBox35.Size = new global::System.Drawing.Size(63, 73);
			this.groupBox35.TabIndex = 24;
			this.groupBox35.TabStop = false;
			this.groupBox35.Text = "Insert";
			this.pb_comment_insert.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableAdd;
			this.pb_comment_insert.Location = new global::System.Drawing.Point(16, 26);
			this.pb_comment_insert.Name = "pb_comment_insert";
			this.pb_comment_insert.Size = new global::System.Drawing.Size(32, 32);
			this.pb_comment_insert.TabIndex = 84;
			this.pb_comment_insert.TabStop = false;
			this.pb_comment_insert.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_comment_insert_MouseDown);
			this.pb_comment_insert.MouseLeave += new global::System.EventHandler(this.pb_comment_insert_MouseLeave);
			this.pb_comment_insert.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pb_comment_insert_MouseMove);
			this.pb_comment_insert.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_comment_insert_MouseUp);
			this.groupBox36.Controls.Add(this.pb_comment_excel);
			this.groupBox36.Location = new global::System.Drawing.Point(835, 13);
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
			this.pb_comment_excel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_comment_excel_MouseDown);
			this.pb_comment_excel.MouseLeave += new global::System.EventHandler(this.pb_comment_excel_MouseLeave);
			this.pb_comment_excel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pb_comment_excel_MouseMove);
			this.pb_comment_excel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_comment_excel_MouseUp);
			this.splitter5.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter5.Location = new global::System.Drawing.Point(250, 3);
			this.splitter5.Name = "splitter5";
			this.splitter5.Size = new global::System.Drawing.Size(5, 629);
			this.splitter5.TabIndex = 64;
			this.splitter5.TabStop = false;
			this.panel11.Controls.Add(this.listBox_Socket);
			this.panel11.Controls.Add(this.panel32);
			this.panel11.Controls.Add(this.panel35);
			this.panel11.Controls.Add(this.panel31);
			this.panel11.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel11.Location = new global::System.Drawing.Point(3, 3);
			this.panel11.Name = "panel11";
			this.panel11.Size = new global::System.Drawing.Size(247, 629);
			this.panel11.TabIndex = 63;
			this.listBox_Socket.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.listBox_Socket.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listBox_Socket.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Socket.FormattingEnabled = true;
			this.listBox_Socket.ItemHeight = 15;
			this.listBox_Socket.Location = new global::System.Drawing.Point(0, 88);
			this.listBox_Socket.Name = "listBox_Socket";
			this.listBox_Socket.ScrollAlwaysVisible = true;
			this.listBox_Socket.Size = new global::System.Drawing.Size(247, 541);
			this.listBox_Socket.TabIndex = 242;
			this.listBox_Socket.SelectedIndexChanged += new global::System.EventHandler(this.listBox_Socket_SelectedIndexChanged);
			this.panel32.Controls.Add(this.btn_search);
			this.panel32.Controls.Add(this.tb_barcode);
			this.panel32.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel32.Location = new global::System.Drawing.Point(0, 57);
			this.panel32.Name = "panel32";
			this.panel32.Size = new global::System.Drawing.Size(247, 31);
			this.panel32.TabIndex = 3;
			this.btn_search.FlatAppearance.BorderColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.btn_search.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_search.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btn_search.Location = new global::System.Drawing.Point(186, 3);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new global::System.Drawing.Size(55, 24);
			this.btn_search.TabIndex = 240;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = true;
			this.btn_search.Click += new global::System.EventHandler(this.btn_search_Click);
			this.tb_barcode.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_barcode.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.tb_barcode.Location = new global::System.Drawing.Point(3, 4);
			this.tb_barcode.Name = "tb_barcode";
			this.tb_barcode.Size = new global::System.Drawing.Size(177, 23);
			this.tb_barcode.TabIndex = 239;
			this.tb_barcode.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tb_barcode_KeyDown);
			this.panel35.Controls.Add(this.cbx_bottom);
			this.panel35.Controls.Add(this.cbx_top);
			this.panel35.Controls.Add(this.label47);
			this.panel35.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel35.Location = new global::System.Drawing.Point(0, 28);
			this.panel35.Name = "panel35";
			this.panel35.Size = new global::System.Drawing.Size(247, 29);
			this.panel35.TabIndex = 3;
			this.cbx_bottom.AutoSize = true;
			this.cbx_bottom.Location = new global::System.Drawing.Point(158, 5);
			this.cbx_bottom.Name = "cbx_bottom";
			this.cbx_bottom.Size = new global::System.Drawing.Size(66, 19);
			this.cbx_bottom.TabIndex = 2;
			this.cbx_bottom.Text = "Bottom";
			this.cbx_bottom.UseVisualStyleBackColor = true;
			this.cbx_top.AutoSize = true;
			this.cbx_top.Location = new global::System.Drawing.Point(87, 5);
			this.cbx_top.Name = "cbx_top";
			this.cbx_top.Size = new global::System.Drawing.Size(45, 19);
			this.cbx_top.TabIndex = 1;
			this.cbx_top.Text = "Top";
			this.cbx_top.UseVisualStyleBackColor = true;
			this.label47.AutoSize = true;
			this.label47.ForeColor = global::System.Drawing.Color.Blue;
			this.label47.Location = new global::System.Drawing.Point(8, 6);
			this.label47.Name = "label47";
			this.label47.Size = new global::System.Drawing.Size(44, 15);
			this.label47.TabIndex = 0;
			this.label47.Text = "Option";
			this.panel31.BackColor = global::System.Drawing.Color.FromArgb(240, 110, 170);
			this.panel31.Controls.Add(this.label38);
			this.panel31.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel31.Location = new global::System.Drawing.Point(0, 0);
			this.panel31.Name = "panel31";
			this.panel31.Size = new global::System.Drawing.Size(247, 28);
			this.panel31.TabIndex = 2;
			this.label38.AutoSize = true;
			this.label38.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label38.Location = new global::System.Drawing.Point(5, 2);
			this.label38.Name = "label38";
			this.label38.Size = new global::System.Drawing.Size(127, 21);
			this.label38.TabIndex = 0;
			this.label38.Text = "Socket Barcode";
			this.tpSM_tpEnrollSocket.Controls.Add(this.panel34);
			this.tpSM_tpEnrollSocket.Controls.Add(this.panel12);
			this.tpSM_tpEnrollSocket.Location = new global::System.Drawing.Point(4, 24);
			this.tpSM_tpEnrollSocket.Name = "tpSM_tpEnrollSocket";
			this.tpSM_tpEnrollSocket.Size = new global::System.Drawing.Size(1168, 635);
			this.tpSM_tpEnrollSocket.TabIndex = 1;
			this.tpSM_tpEnrollSocket.Text = "Enroll Socket";
			this.tpSM_tpEnrollSocket.UseVisualStyleBackColor = true;
			this.panel34.Controls.Add(this.groupBox42);
			this.panel34.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel34.Location = new global::System.Drawing.Point(0, 80);
			this.panel34.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel34.Name = "panel34";
			this.panel34.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel34.Size = new global::System.Drawing.Size(1168, 555);
			this.panel34.TabIndex = 63;
			this.groupBox42.Controls.Add(this.gridSocketList);
			this.groupBox42.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox42.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox42.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox42.Name = "groupBox42";
			this.groupBox42.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox42.Size = new global::System.Drawing.Size(1162, 551);
			this.groupBox42.TabIndex = 5;
			this.groupBox42.TabStop = false;
			this.groupBox42.Text = "Socket List";
			this.gridSocketList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridSocketList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridSocketList.EnableSort = true;
			this.gridSocketList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridSocketList.Location = new global::System.Drawing.Point(3, 20);
			this.gridSocketList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridSocketList.Name = "gridSocketList";
			this.gridSocketList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridSocketList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridSocketList.Size = new global::System.Drawing.Size(1156, 527);
			this.gridSocketList.TabIndex = 13;
			this.gridSocketList.TabStop = true;
			this.gridSocketList.ToolTipText = "";
			this.gridSocketList.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.gridSocketList_MouseDoubleClick);
			this.gridSocketList.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.panel12.Controls.Add(this.groupBox37);
			this.panel12.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel12.Location = new global::System.Drawing.Point(0, 0);
			this.panel12.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel12.Name = "panel12";
			this.panel12.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel12.Size = new global::System.Drawing.Size(1168, 80);
			this.panel12.TabIndex = 62;
			this.groupBox37.Controls.Add(this.tpSM_tpEnroll_cmbSocketType);
			this.groupBox37.Controls.Add(this.label50);
			this.groupBox37.Controls.Add(this.groupBox38);
			this.groupBox37.Controls.Add(this.tpSM_tpEnroll_txtBarcode);
			this.groupBox37.Controls.Add(this.tpSM_tpEnroll_cmbStatus);
			this.groupBox37.Controls.Add(this.label49);
			this.groupBox37.Controls.Add(this.tpSM_tpEnroll_cmbDevice);
			this.groupBox37.Controls.Add(this.tpSM_tpEnroll_cmbCustomer);
			this.groupBox37.Controls.Add(this.label51);
			this.groupBox37.Controls.Add(this.groupBox39);
			this.groupBox37.Controls.Add(this.groupBox40);
			this.groupBox37.Controls.Add(this.groupBox41);
			this.groupBox37.Controls.Add(this.label52);
			this.groupBox37.Controls.Add(this.label53);
			this.groupBox37.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox37.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox37.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox37.Name = "groupBox37";
			this.groupBox37.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox37.Size = new global::System.Drawing.Size(1162, 74);
			this.groupBox37.TabIndex = 6;
			this.groupBox37.TabStop = false;
			this.tpSM_tpEnroll_cmbSocketType.BackColor = global::System.Drawing.Color.LightGray;
			this.tpSM_tpEnroll_cmbSocketType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tpSM_tpEnroll_cmbSocketType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.tpSM_tpEnroll_cmbSocketType.FormattingEnabled = true;
			this.tpSM_tpEnroll_cmbSocketType.Location = new global::System.Drawing.Point(81, 43);
			this.tpSM_tpEnroll_cmbSocketType.Name = "tpSM_tpEnroll_cmbSocketType";
			this.tpSM_tpEnroll_cmbSocketType.Size = new global::System.Drawing.Size(109, 23);
			this.tpSM_tpEnroll_cmbSocketType.TabIndex = 88;
			this.tpSM_tpEnroll_cmbSocketType.DropDown += new global::System.EventHandler(this.tpSM_tpEnroll_cmbSocketType_DropDown);
			this.label50.AutoSize = true;
			this.label50.Location = new global::System.Drawing.Point(6, 46);
			this.label50.Name = "label50";
			this.label50.Size = new global::System.Drawing.Size(66, 15);
			this.label50.TabIndex = 87;
			this.label50.Text = "SocketType";
			this.groupBox38.Controls.Add(this.tpSM_tpEnroll_btnSetting);
			this.groupBox38.Location = new global::System.Drawing.Point(1059, 11);
			this.groupBox38.Name = "groupBox38";
			this.groupBox38.Size = new global::System.Drawing.Size(59, 58);
			this.groupBox38.TabIndex = 86;
			this.groupBox38.TabStop = false;
			this.groupBox38.Text = "Setting";
			this.tpSM_tpEnroll_btnSetting.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.CellDesign;
			this.tpSM_tpEnroll_btnSetting.Location = new global::System.Drawing.Point(14, 18);
			this.tpSM_tpEnroll_btnSetting.Name = "tpSM_tpEnroll_btnSetting";
			this.tpSM_tpEnroll_btnSetting.Size = new global::System.Drawing.Size(32, 32);
			this.tpSM_tpEnroll_btnSetting.TabIndex = 80;
			this.tpSM_tpEnroll_btnSetting.TabStop = false;
			this.tpSM_tpEnroll_btnSetting.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnSetting_MouseDown);
			this.tpSM_tpEnroll_btnSetting.MouseLeave += new global::System.EventHandler(this.tpSM_tpEnroll_btnSetting_MouseLeave);
			this.tpSM_tpEnroll_btnSetting.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnSetting_MouseMove);
			this.tpSM_tpEnroll_btnSetting.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnSetting_MouseUp);
			this.tpSM_tpEnroll_txtBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tpSM_tpEnroll_txtBarcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.tpSM_tpEnroll_txtBarcode.Location = new global::System.Drawing.Point(607, 17);
			this.tpSM_tpEnroll_txtBarcode.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tpSM_tpEnroll_txtBarcode.Name = "tpSM_tpEnroll_txtBarcode";
			this.tpSM_tpEnroll_txtBarcode.Size = new global::System.Drawing.Size(230, 23);
			this.tpSM_tpEnroll_txtBarcode.TabIndex = 0;
			this.tpSM_tpEnroll_cmbStatus.BackColor = global::System.Drawing.Color.LightGray;
			this.tpSM_tpEnroll_cmbStatus.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tpSM_tpEnroll_cmbStatus.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.tpSM_tpEnroll_cmbStatus.FormattingEnabled = true;
			this.tpSM_tpEnroll_cmbStatus.Location = new global::System.Drawing.Point(253, 15);
			this.tpSM_tpEnroll_cmbStatus.Name = "tpSM_tpEnroll_cmbStatus";
			this.tpSM_tpEnroll_cmbStatus.Size = new global::System.Drawing.Size(106, 23);
			this.tpSM_tpEnroll_cmbStatus.TabIndex = 44;
			this.tpSM_tpEnroll_cmbStatus.DropDown += new global::System.EventHandler(this.tpSM_tpEnroll_cmbStatus_DropDown);
			this.label49.AutoSize = true;
			this.label49.Location = new global::System.Drawing.Point(544, 20);
			this.label49.Name = "label49";
			this.label49.Size = new global::System.Drawing.Size(50, 15);
			this.label49.TabIndex = 3;
			this.label49.Text = "Barcode";
			this.tpSM_tpEnroll_cmbDevice.BackColor = global::System.Drawing.Color.LightGray;
			this.tpSM_tpEnroll_cmbDevice.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.tpSM_tpEnroll_cmbDevice.FormattingEnabled = true;
			this.tpSM_tpEnroll_cmbDevice.Location = new global::System.Drawing.Point(423, 15);
			this.tpSM_tpEnroll_cmbDevice.Name = "tpSM_tpEnroll_cmbDevice";
			this.tpSM_tpEnroll_cmbDevice.Size = new global::System.Drawing.Size(106, 23);
			this.tpSM_tpEnroll_cmbDevice.TabIndex = 46;
			this.tpSM_tpEnroll_cmbDevice.DropDown += new global::System.EventHandler(this.tpSM_tpEnroll_cmbDevice_DropDown);
			this.tpSM_tpEnroll_cmbCustomer.BackColor = global::System.Drawing.Color.LightGray;
			this.tpSM_tpEnroll_cmbCustomer.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tpSM_tpEnroll_cmbCustomer.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.tpSM_tpEnroll_cmbCustomer.FormattingEnabled = true;
			this.tpSM_tpEnroll_cmbCustomer.Location = new global::System.Drawing.Point(81, 15);
			this.tpSM_tpEnroll_cmbCustomer.Name = "tpSM_tpEnroll_cmbCustomer";
			this.tpSM_tpEnroll_cmbCustomer.Size = new global::System.Drawing.Size(109, 23);
			this.tpSM_tpEnroll_cmbCustomer.TabIndex = 43;
			this.tpSM_tpEnroll_cmbCustomer.DropDown += new global::System.EventHandler(this.tpSM_tpEnroll_cmbCustomer_DropDown);
			this.label51.AutoSize = true;
			this.label51.Location = new global::System.Drawing.Point(375, 18);
			this.label51.Name = "label51";
			this.label51.Size = new global::System.Drawing.Size(42, 15);
			this.label51.TabIndex = 28;
			this.label51.Text = "Device";
			this.groupBox39.Controls.Add(this.tpSM_tpEnroll_btnAdd);
			this.groupBox39.Location = new global::System.Drawing.Point(945, 11);
			this.groupBox39.Name = "groupBox39";
			this.groupBox39.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox39.TabIndex = 24;
			this.groupBox39.TabStop = false;
			this.groupBox39.Text = "Add";
			this.tpSM_tpEnroll_btnAdd.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tpSM_tpEnroll_btnAdd.Image");
			this.tpSM_tpEnroll_btnAdd.Location = new global::System.Drawing.Point(9, 18);
			this.tpSM_tpEnroll_btnAdd.Name = "tpSM_tpEnroll_btnAdd";
			this.tpSM_tpEnroll_btnAdd.Size = new global::System.Drawing.Size(32, 32);
			this.tpSM_tpEnroll_btnAdd.TabIndex = 84;
			this.tpSM_tpEnroll_btnAdd.TabStop = false;
			this.tpSM_tpEnroll_btnAdd.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnAdd_MouseDown);
			this.tpSM_tpEnroll_btnAdd.MouseLeave += new global::System.EventHandler(this.tpSM_tpEnroll_btnAdd_MouseLeave);
			this.tpSM_tpEnroll_btnAdd.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnAdd_MouseMove);
			this.tpSM_tpEnroll_btnAdd.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnAdd_MouseUp);
			this.groupBox40.Controls.Add(this.tpSM_tpEnroll_btnExcel);
			this.groupBox40.Location = new global::System.Drawing.Point(1002, 11);
			this.groupBox40.Name = "groupBox40";
			this.groupBox40.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox40.TabIndex = 17;
			this.groupBox40.TabStop = false;
			this.groupBox40.Text = "Excel";
			this.tpSM_tpEnroll_btnExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tpSM_tpEnroll_btnExcel.Image");
			this.tpSM_tpEnroll_btnExcel.Location = new global::System.Drawing.Point(9, 18);
			this.tpSM_tpEnroll_btnExcel.Name = "tpSM_tpEnroll_btnExcel";
			this.tpSM_tpEnroll_btnExcel.Size = new global::System.Drawing.Size(32, 32);
			this.tpSM_tpEnroll_btnExcel.TabIndex = 80;
			this.tpSM_tpEnroll_btnExcel.TabStop = false;
			this.tpSM_tpEnroll_btnExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnExcel_MouseDown);
			this.tpSM_tpEnroll_btnExcel.MouseLeave += new global::System.EventHandler(this.tpSM_tpEnroll_btnExcel_MouseLeave);
			this.tpSM_tpEnroll_btnExcel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnExcel_MouseMove);
			this.tpSM_tpEnroll_btnExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnExcel_MouseUp);
			this.groupBox41.Controls.Add(this.tpSM_tpEnroll_btnSearch);
			this.groupBox41.Location = new global::System.Drawing.Point(881, 11);
			this.groupBox41.Name = "groupBox41";
			this.groupBox41.Size = new global::System.Drawing.Size(58, 58);
			this.groupBox41.TabIndex = 16;
			this.groupBox41.TabStop = false;
			this.groupBox41.Text = "Search";
			this.tpSM_tpEnroll_btnSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tpSM_tpEnroll_btnSearch.Image");
			this.tpSM_tpEnroll_btnSearch.Location = new global::System.Drawing.Point(12, 18);
			this.tpSM_tpEnroll_btnSearch.Name = "tpSM_tpEnroll_btnSearch";
			this.tpSM_tpEnroll_btnSearch.Size = new global::System.Drawing.Size(32, 32);
			this.tpSM_tpEnroll_btnSearch.TabIndex = 1;
			this.tpSM_tpEnroll_btnSearch.TabStop = false;
			this.tpSM_tpEnroll_btnSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnSearch_MouseDown);
			this.tpSM_tpEnroll_btnSearch.MouseLeave += new global::System.EventHandler(this.tpSM_tpEnroll_btnSearch_MouseLeave);
			this.tpSM_tpEnroll_btnSearch.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnSearch_MouseMove);
			this.tpSM_tpEnroll_btnSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpEnroll_btnSearch_MouseUp);
			this.label52.AutoSize = true;
			this.label52.Location = new global::System.Drawing.Point(205, 18);
			this.label52.Name = "label52";
			this.label52.Size = new global::System.Drawing.Size(39, 15);
			this.label52.TabIndex = 5;
			this.label52.Text = "Status";
			this.label53.AutoSize = true;
			this.label53.Location = new global::System.Drawing.Point(6, 18);
			this.label53.Name = "label53";
			this.label53.Size = new global::System.Drawing.Size(59, 15);
			this.label53.TabIndex = 2;
			this.label53.Text = "Customer";
			this.tpSM_tpPeriodComment.Controls.Add(this.panel37);
			this.tpSM_tpPeriodComment.Controls.Add(this.panel36);
			this.tpSM_tpPeriodComment.Location = new global::System.Drawing.Point(4, 24);
			this.tpSM_tpPeriodComment.Name = "tpSM_tpPeriodComment";
			this.tpSM_tpPeriodComment.Size = new global::System.Drawing.Size(1168, 635);
			this.tpSM_tpPeriodComment.TabIndex = 2;
			this.tpSM_tpPeriodComment.Text = "Period Comment";
			this.tpSM_tpPeriodComment.UseVisualStyleBackColor = true;
			this.panel37.Controls.Add(this.groupBox50);
			this.panel37.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel37.Location = new global::System.Drawing.Point(0, 80);
			this.panel37.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel37.Name = "panel37";
			this.panel37.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 3);
			this.panel37.Size = new global::System.Drawing.Size(1168, 555);
			this.panel37.TabIndex = 64;
			this.groupBox50.Controls.Add(this.gridPeriodSocketList);
			this.groupBox50.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox50.Location = new global::System.Drawing.Point(3, 1);
			this.groupBox50.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox50.Name = "groupBox50";
			this.groupBox50.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox50.Size = new global::System.Drawing.Size(1162, 551);
			this.groupBox50.TabIndex = 5;
			this.groupBox50.TabStop = false;
			this.groupBox50.Text = "Socket List";
			this.gridPeriodSocketList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridPeriodSocketList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridPeriodSocketList.EnableSort = true;
			this.gridPeriodSocketList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridPeriodSocketList.Location = new global::System.Drawing.Point(3, 20);
			this.gridPeriodSocketList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridPeriodSocketList.Name = "gridPeriodSocketList";
			this.gridPeriodSocketList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridPeriodSocketList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridPeriodSocketList.Size = new global::System.Drawing.Size(1156, 527);
			this.gridPeriodSocketList.TabIndex = 13;
			this.gridPeriodSocketList.TabStop = true;
			this.gridPeriodSocketList.ToolTipText = "";
			this.gridPeriodSocketList.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.gridPeriodSocketList_MouseDoubleClick);
			this.gridPeriodSocketList.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.panel36.Controls.Add(this.groupBox45);
			this.panel36.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel36.Location = new global::System.Drawing.Point(0, 0);
			this.panel36.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel36.Name = "panel36";
			this.panel36.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel36.Size = new global::System.Drawing.Size(1168, 80);
			this.panel36.TabIndex = 63;
			this.groupBox45.Controls.Add(this.groupBox51);
			this.groupBox45.Controls.Add(this.groupBox46);
			this.groupBox45.Controls.Add(this.groupBox48);
			this.groupBox45.Controls.Add(this.groupBox49);
			this.groupBox45.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox45.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox45.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox45.Name = "groupBox45";
			this.groupBox45.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox45.Size = new global::System.Drawing.Size(1162, 74);
			this.groupBox45.TabIndex = 6;
			this.groupBox45.TabStop = false;
			this.groupBox51.Controls.Add(this.tpSM_tpPeriod_cmbCompletedCommentStatus);
			this.groupBox51.Controls.Add(this.tpSM_tpPeriod_dtStart);
			this.groupBox51.Controls.Add(this.label55);
			this.groupBox51.Controls.Add(this.tpSM_tpPeriod_dtEnd);
			this.groupBox51.Location = new global::System.Drawing.Point(8, 11);
			this.groupBox51.Name = "groupBox51";
			this.groupBox51.Size = new global::System.Drawing.Size(924, 58);
			this.groupBox51.TabIndex = 17;
			this.groupBox51.TabStop = false;
			this.groupBox51.Text = "Request Date";
			this.tpSM_tpPeriod_cmbCompletedCommentStatus.BackColor = global::System.Drawing.Color.LightGray;
			this.tpSM_tpPeriod_cmbCompletedCommentStatus.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tpSM_tpPeriod_cmbCompletedCommentStatus.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.tpSM_tpPeriod_cmbCompletedCommentStatus.FormattingEnabled = true;
			this.tpSM_tpPeriod_cmbCompletedCommentStatus.Location = new global::System.Drawing.Point(542, 22);
			this.tpSM_tpPeriod_cmbCompletedCommentStatus.Name = "tpSM_tpPeriod_cmbCompletedCommentStatus";
			this.tpSM_tpPeriod_cmbCompletedCommentStatus.Size = new global::System.Drawing.Size(129, 23);
			this.tpSM_tpPeriod_cmbCompletedCommentStatus.TabIndex = 90;
			this.tpSM_tpPeriod_cmbCompletedCommentStatus.DropDown += new global::System.EventHandler(this.tpSM_tpPeriod_cmbCompletedCommentStatus_DropDown);
			this.tpSM_tpPeriod_dtStart.CustomFormat = "'Start Date : ' yyyy-MM-dd";
			this.tpSM_tpPeriod_dtStart.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tpSM_tpPeriod_dtStart.Location = new global::System.Drawing.Point(16, 22);
			this.tpSM_tpPeriod_dtStart.Name = "tpSM_tpPeriod_dtStart";
			this.tpSM_tpPeriod_dtStart.Size = new global::System.Drawing.Size(161, 23);
			this.tpSM_tpPeriod_dtStart.TabIndex = 88;
			this.tpSM_tpPeriod_dtStart.CloseUp += new global::System.EventHandler(this.tpSM_tpPeriod_dtStart_CloseUp);
			this.label55.AutoSize = true;
			this.label55.Location = new global::System.Drawing.Point(378, 26);
			this.label55.Name = "label55";
			this.label55.Size = new global::System.Drawing.Size(158, 15);
			this.label55.TabIndex = 89;
			this.label55.Text = "Completed Comment Status";
			this.tpSM_tpPeriod_dtEnd.CustomFormat = "'End Date : ' yyyy-MM-dd";
			this.tpSM_tpPeriod_dtEnd.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tpSM_tpPeriod_dtEnd.Location = new global::System.Drawing.Point(193, 22);
			this.tpSM_tpPeriod_dtEnd.Name = "tpSM_tpPeriod_dtEnd";
			this.tpSM_tpPeriod_dtEnd.Size = new global::System.Drawing.Size(161, 23);
			this.tpSM_tpPeriod_dtEnd.TabIndex = 87;
			this.tpSM_tpPeriod_dtEnd.CloseUp += new global::System.EventHandler(this.tpSM_tpPeriod_dtEnd_CloseUp);
			this.groupBox46.Controls.Add(this.tpSM_tpPeriod_btnSetting);
			this.groupBox46.Location = new global::System.Drawing.Point(1059, 11);
			this.groupBox46.Name = "groupBox46";
			this.groupBox46.Size = new global::System.Drawing.Size(59, 58);
			this.groupBox46.TabIndex = 86;
			this.groupBox46.TabStop = false;
			this.groupBox46.Text = "Setting";
			this.tpSM_tpPeriod_btnSetting.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.CellDesign;
			this.tpSM_tpPeriod_btnSetting.Location = new global::System.Drawing.Point(14, 18);
			this.tpSM_tpPeriod_btnSetting.Name = "tpSM_tpPeriod_btnSetting";
			this.tpSM_tpPeriod_btnSetting.Size = new global::System.Drawing.Size(32, 32);
			this.tpSM_tpPeriod_btnSetting.TabIndex = 80;
			this.tpSM_tpPeriod_btnSetting.TabStop = false;
			this.tpSM_tpPeriod_btnSetting.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpPeriod_btnSetting_MouseDown);
			this.tpSM_tpPeriod_btnSetting.MouseLeave += new global::System.EventHandler(this.tpSM_tpPeriod_btnSetting_MouseLeave);
			this.tpSM_tpPeriod_btnSetting.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpPeriod_btnSetting_MouseMove);
			this.tpSM_tpPeriod_btnSetting.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpPeriod_btnSetting_MouseUp);
			this.groupBox48.Controls.Add(this.tpSM_tpPeriod_btnExcel);
			this.groupBox48.Location = new global::System.Drawing.Point(1002, 11);
			this.groupBox48.Name = "groupBox48";
			this.groupBox48.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox48.TabIndex = 17;
			this.groupBox48.TabStop = false;
			this.groupBox48.Text = "Excel";
			this.tpSM_tpPeriod_btnExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tpSM_tpPeriod_btnExcel.Image");
			this.tpSM_tpPeriod_btnExcel.Location = new global::System.Drawing.Point(9, 18);
			this.tpSM_tpPeriod_btnExcel.Name = "tpSM_tpPeriod_btnExcel";
			this.tpSM_tpPeriod_btnExcel.Size = new global::System.Drawing.Size(32, 32);
			this.tpSM_tpPeriod_btnExcel.TabIndex = 80;
			this.tpSM_tpPeriod_btnExcel.TabStop = false;
			this.tpSM_tpPeriod_btnExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpPeriod_btnExcel_MouseDown);
			this.tpSM_tpPeriod_btnExcel.MouseLeave += new global::System.EventHandler(this.tpSM_tpPeriod_btnExcel_MouseLeave);
			this.tpSM_tpPeriod_btnExcel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpPeriod_btnExcel_MouseMove);
			this.tpSM_tpPeriod_btnExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpPeriod_btnExcel_MouseUp);
			this.groupBox49.Controls.Add(this.tpSM_tpPeriod_btnSearch);
			this.groupBox49.Location = new global::System.Drawing.Point(938, 11);
			this.groupBox49.Name = "groupBox49";
			this.groupBox49.Size = new global::System.Drawing.Size(58, 58);
			this.groupBox49.TabIndex = 16;
			this.groupBox49.TabStop = false;
			this.groupBox49.Text = "Search";
			this.tpSM_tpPeriod_btnSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tpSM_tpPeriod_btnSearch.Image");
			this.tpSM_tpPeriod_btnSearch.Location = new global::System.Drawing.Point(12, 18);
			this.tpSM_tpPeriod_btnSearch.Name = "tpSM_tpPeriod_btnSearch";
			this.tpSM_tpPeriod_btnSearch.Size = new global::System.Drawing.Size(32, 32);
			this.tpSM_tpPeriod_btnSearch.TabIndex = 1;
			this.tpSM_tpPeriod_btnSearch.TabStop = false;
			this.tpSM_tpPeriod_btnSearch.Click += new global::System.EventHandler(this.tpSM_tpPeriod_btnSearch_Click);
			this.tpSM_tpPeriod_btnSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpPeriod_btnSearch_MouseDown);
			this.tpSM_tpPeriod_btnSearch.MouseLeave += new global::System.EventHandler(this.tpSM_tpPeriod_btnSearch_MouseLeave);
			this.tpSM_tpPeriod_btnSearch.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpPeriod_btnSearch_MouseMove);
			this.tpSM_tpPeriod_btnSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpPeriod_btnSearch_MouseUp);
			this.tpSM_tpCompledTrend.Controls.Add(this.panel40);
			this.tpSM_tpCompledTrend.Controls.Add(this.panel39);
			this.tpSM_tpCompledTrend.Controls.Add(this.panel38);
			this.tpSM_tpCompledTrend.Location = new global::System.Drawing.Point(4, 24);
			this.tpSM_tpCompledTrend.Name = "tpSM_tpCompledTrend";
			this.tpSM_tpCompledTrend.Size = new global::System.Drawing.Size(1168, 635);
			this.tpSM_tpCompledTrend.TabIndex = 3;
			this.tpSM_tpCompledTrend.Text = "CompletedTrend";
			this.tpSM_tpCompledTrend.UseVisualStyleBackColor = true;
			this.panel40.Controls.Add(this.chartComptedTrend);
			this.panel40.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel40.Location = new global::System.Drawing.Point(0, 80);
			this.panel40.Name = "panel40";
			this.panel40.Size = new global::System.Drawing.Size(1168, 300);
			this.panel40.TabIndex = 152;
			this.chartComptedTrend.BackGradientStyle = global::System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chartComptedTrend.BackSecondaryColor = global::System.Drawing.Color.White;
			this.chartComptedTrend.BorderlineColor = global::System.Drawing.Color.Silver;
			this.chartComptedTrend.BorderlineDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea3.Area3DStyle.Inclination = 5;
			chartArea3.Area3DStyle.IsClustered = true;
			chartArea3.Area3DStyle.Rotation = 0;
			chartArea3.Area3DStyle.WallWidth = 0;
			chartArea3.AxisX.LineColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea3.AxisX.Maximum = 100.0;
			chartArea3.AxisY.IsLabelAutoFit = false;
			chartArea3.AxisY.LabelStyle.Font = new global::System.Drawing.Font("Arial", 8f);
			chartArea3.AxisY.LineColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea3.AxisY.Maximum = 100.0;
			chartArea3.AxisY.MaximumAutoSize = 100f;
			chartArea3.AxisY.Minimum = 0.0;
			chartArea3.BackColor = global::System.Drawing.Color.White;
			chartArea3.BackSecondaryColor = global::System.Drawing.Color.White;
			chartArea3.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 64, 64);
			chartArea3.BorderDashStyle = global::System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea3.Name = "ChartArea1";
			chartArea3.ShadowColor = global::System.Drawing.Color.Transparent;
			this.chartComptedTrend.ChartAreas.Add(chartArea3);
			this.chartComptedTrend.Dock = global::System.Windows.Forms.DockStyle.Fill;
			legend3.Alignment = global::System.Drawing.StringAlignment.Center;
			legend3.BackColor = global::System.Drawing.Color.Transparent;
			legend3.BorderColor = global::System.Drawing.Color.Transparent;
			legend3.Docking = global::System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend3.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			legend3.IsTextAutoFit = false;
			legend3.Name = "Legend1";
			this.chartComptedTrend.Legends.Add(legend3);
			this.chartComptedTrend.Location = new global::System.Drawing.Point(0, 0);
			this.chartComptedTrend.Name = "chartComptedTrend";
			series.BorderWidth = 3;
			series.ChartArea = "ChartArea1";
			series.ChartType = global::System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series.Color = global::System.Drawing.Color.FromArgb(51, 153, 51);
			series.Legend = "Legend1";
			series.LegendText = "TotalCount";
			series.MarkerSize = 8;
			series.MarkerStyle = global::System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series.Name = "Series_TotalCount";
			this.chartComptedTrend.Series.Add(series);
			this.chartComptedTrend.Size = new global::System.Drawing.Size(1168, 300);
			this.chartComptedTrend.TabIndex = 147;
			this.chartComptedTrend.Text = "chart_Tester";
			title3.BackColor = global::System.Drawing.Color.Transparent;
			title3.BackImageAlignment = global::System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
			title3.BackImageWrapMode = global::System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
			title3.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			title3.Name = "Title1";
			title3.ShadowColor = global::System.Drawing.Color.Silver;
			title3.Text = "Complated Trend";
			this.chartComptedTrend.Titles.Add(title3);
			this.panel39.Controls.Add(this.gridCompletedList);
			this.panel39.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel39.Location = new global::System.Drawing.Point(0, 380);
			this.panel39.Name = "panel39";
			this.panel39.Size = new global::System.Drawing.Size(1168, 255);
			this.panel39.TabIndex = 151;
			this.gridCompletedList.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.gridCompletedList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridCompletedList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridCompletedList.EnableSort = true;
			this.gridCompletedList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridCompletedList.Location = new global::System.Drawing.Point(0, 0);
			this.gridCompletedList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridCompletedList.Name = "gridCompletedList";
			this.gridCompletedList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridCompletedList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridCompletedList.Size = new global::System.Drawing.Size(1168, 255);
			this.gridCompletedList.TabIndex = 29;
			this.gridCompletedList.TabStop = true;
			this.gridCompletedList.ToolTipText = "";
			this.gridCompletedList.PreviewKeyDown += new global::System.Windows.Forms.PreviewKeyDownEventHandler(this.gridEvent_OnKeyDown);
			this.panel38.Controls.Add(this.groupBox47);
			this.panel38.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel38.Location = new global::System.Drawing.Point(0, 0);
			this.panel38.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel38.Name = "panel38";
			this.panel38.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel38.Size = new global::System.Drawing.Size(1168, 80);
			this.panel38.TabIndex = 64;
			this.groupBox47.Controls.Add(this.groupBox52);
			this.groupBox47.Controls.Add(this.groupBox54);
			this.groupBox47.Controls.Add(this.groupBox55);
			this.groupBox47.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox47.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox47.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox47.Name = "groupBox47";
			this.groupBox47.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox47.Size = new global::System.Drawing.Size(1162, 74);
			this.groupBox47.TabIndex = 6;
			this.groupBox47.TabStop = false;
			this.groupBox52.Controls.Add(this.tpSM_tpCompleted_dtStart);
			this.groupBox52.Controls.Add(this.tpSM_tpCompleted_dtEnd);
			this.groupBox52.Location = new global::System.Drawing.Point(8, 11);
			this.groupBox52.Name = "groupBox52";
			this.groupBox52.Size = new global::System.Drawing.Size(924, 58);
			this.groupBox52.TabIndex = 17;
			this.groupBox52.TabStop = false;
			this.groupBox52.Text = "Completed Date";
			this.tpSM_tpCompleted_dtStart.CustomFormat = "'Start Date : ' yyyy-MM-dd";
			this.tpSM_tpCompleted_dtStart.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tpSM_tpCompleted_dtStart.Location = new global::System.Drawing.Point(16, 22);
			this.tpSM_tpCompleted_dtStart.Name = "tpSM_tpCompleted_dtStart";
			this.tpSM_tpCompleted_dtStart.Size = new global::System.Drawing.Size(161, 23);
			this.tpSM_tpCompleted_dtStart.TabIndex = 88;
			this.tpSM_tpCompleted_dtEnd.CustomFormat = "'End Date : ' yyyy-MM-dd";
			this.tpSM_tpCompleted_dtEnd.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tpSM_tpCompleted_dtEnd.Location = new global::System.Drawing.Point(193, 22);
			this.tpSM_tpCompleted_dtEnd.Name = "tpSM_tpCompleted_dtEnd";
			this.tpSM_tpCompleted_dtEnd.Size = new global::System.Drawing.Size(161, 23);
			this.tpSM_tpCompleted_dtEnd.TabIndex = 87;
			this.groupBox54.Controls.Add(this.tpSM_tpCompleted_btnExcel);
			this.groupBox54.Location = new global::System.Drawing.Point(1002, 11);
			this.groupBox54.Name = "groupBox54";
			this.groupBox54.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox54.TabIndex = 17;
			this.groupBox54.TabStop = false;
			this.groupBox54.Text = "Excel";
			this.tpSM_tpCompleted_btnExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tpSM_tpCompleted_btnExcel.Image");
			this.tpSM_tpCompleted_btnExcel.Location = new global::System.Drawing.Point(9, 18);
			this.tpSM_tpCompleted_btnExcel.Name = "tpSM_tpCompleted_btnExcel";
			this.tpSM_tpCompleted_btnExcel.Size = new global::System.Drawing.Size(32, 32);
			this.tpSM_tpCompleted_btnExcel.TabIndex = 80;
			this.tpSM_tpCompleted_btnExcel.TabStop = false;
			this.tpSM_tpCompleted_btnExcel.Click += new global::System.EventHandler(this.tpSM_tpCompleted_btnExcel_Click);
			this.tpSM_tpCompleted_btnExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpCompleted_btnExcel_MouseDown);
			this.tpSM_tpCompleted_btnExcel.MouseLeave += new global::System.EventHandler(this.tpSM_tpCompleted_btnExcel_MouseLeave);
			this.tpSM_tpCompleted_btnExcel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpCompleted_btnExcel_MouseMove);
			this.tpSM_tpCompleted_btnExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpCompleted_btnExcel_MouseUp);
			this.groupBox55.Controls.Add(this.tpSM_tpCompleted_btnSearch);
			this.groupBox55.Location = new global::System.Drawing.Point(938, 11);
			this.groupBox55.Name = "groupBox55";
			this.groupBox55.Size = new global::System.Drawing.Size(58, 58);
			this.groupBox55.TabIndex = 16;
			this.groupBox55.TabStop = false;
			this.groupBox55.Text = "Search";
			this.tpSM_tpCompleted_btnSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tpSM_tpCompleted_btnSearch.Image");
			this.tpSM_tpCompleted_btnSearch.Location = new global::System.Drawing.Point(12, 18);
			this.tpSM_tpCompleted_btnSearch.Name = "tpSM_tpCompleted_btnSearch";
			this.tpSM_tpCompleted_btnSearch.Size = new global::System.Drawing.Size(32, 32);
			this.tpSM_tpCompleted_btnSearch.TabIndex = 1;
			this.tpSM_tpCompleted_btnSearch.TabStop = false;
			this.tpSM_tpCompleted_btnSearch.Click += new global::System.EventHandler(this.tpSM_tpCompleted_btnSearch_Click);
			this.tpSM_tpCompleted_btnSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpCompleted_btnSearch_MouseDown);
			this.tpSM_tpCompleted_btnSearch.MouseLeave += new global::System.EventHandler(this.tpSM_tpCompleted_btnSearch_MouseLeave);
			this.tpSM_tpCompleted_btnSearch.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpCompleted_btnSearch_MouseMove);
			this.tpSM_tpCompleted_btnSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tpSM_tpCompleted_btnSearch_MouseUp);
			this.panel33.Controls.Add(this.label45);
			this.panel33.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel33.Location = new global::System.Drawing.Point(0, 0);
			this.panel33.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel33.Name = "panel33";
			this.panel33.Size = new global::System.Drawing.Size(1176, 34);
			this.panel33.TabIndex = 25;
			this.label45.AutoSize = true;
			this.label45.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label45.ForeColor = global::System.Drawing.Color.Black;
			this.label45.Location = new global::System.Drawing.Point(12, 6);
			this.label45.Name = "label45";
			this.label45.Size = new global::System.Drawing.Size(133, 17);
			this.label45.TabIndex = 15;
			this.label45.Text = "Socket Management";
			this.tpWeeklyReport.Controls.Add(this.groupBox65);
			this.tpWeeklyReport.Controls.Add(this.WeeklyReportPanel);
			this.tpWeeklyReport.Location = new global::System.Drawing.Point(4, 24);
			this.tpWeeklyReport.Name = "tpWeeklyReport";
			this.tpWeeklyReport.Size = new global::System.Drawing.Size(1176, 697);
			this.tpWeeklyReport.TabIndex = 93;
			this.tpWeeklyReport.Text = "Weekly Report";
			this.tpWeeklyReport.UseVisualStyleBackColor = true;
			this.groupBox65.Controls.Add(this.gridWeeklyReport);
			this.groupBox65.Controls.Add(this.label62);
			this.groupBox65.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox65.Location = new global::System.Drawing.Point(0, 91);
			this.groupBox65.Name = "groupBox65";
			this.groupBox65.Size = new global::System.Drawing.Size(1176, 606);
			this.groupBox65.TabIndex = 1;
			this.groupBox65.TabStop = false;
			this.groupBox65.Text = "WeeklyReport Viewer";
			this.gridWeeklyReport.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridWeeklyReport.EnableSort = true;
			this.gridWeeklyReport.Location = new global::System.Drawing.Point(3, 19);
			this.gridWeeklyReport.Name = "gridWeeklyReport";
			this.gridWeeklyReport.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridWeeklyReport.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridWeeklyReport.Size = new global::System.Drawing.Size(1170, 584);
			this.gridWeeklyReport.TabIndex = 1;
			this.gridWeeklyReport.TabStop = true;
			this.gridWeeklyReport.ToolTipText = "";
			this.label62.AutoSize = true;
			this.label62.Location = new global::System.Drawing.Point(962, 37);
			this.label62.Name = "label62";
			this.label62.Size = new global::System.Drawing.Size(143, 15);
			this.label62.TabIndex = 0;
			this.label62.Text = "This page in development";
			this.WeeklyReportPanel.Controls.Add(this.groupBox83);
			this.WeeklyReportPanel.Controls.Add(this.groupBox68);
			this.WeeklyReportPanel.Controls.Add(this.groupBox66);
			this.WeeklyReportPanel.Controls.Add(this.groupBox67);
			this.WeeklyReportPanel.Controls.Add(this.groupBox64);
			this.WeeklyReportPanel.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.WeeklyReportPanel.Location = new global::System.Drawing.Point(0, 0);
			this.WeeklyReportPanel.Name = "WeeklyReportPanel";
			this.WeeklyReportPanel.Size = new global::System.Drawing.Size(1176, 91);
			this.WeeklyReportPanel.TabIndex = 2;
			this.groupBox83.Controls.Add(this.pictureBox5);
			this.groupBox83.Location = new global::System.Drawing.Point(1111, 4);
			this.groupBox83.Name = "groupBox83";
			this.groupBox83.Size = new global::System.Drawing.Size(55, 81);
			this.groupBox83.TabIndex = 4;
			this.groupBox83.TabStop = false;
			this.groupBox83.Text = "Setup";
			this.groupBox83.Visible = false;
			this.pictureBox5.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox5.Image");
			this.pictureBox5.Location = new global::System.Drawing.Point(11, 28);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new global::System.Drawing.Size(35, 36);
			this.pictureBox5.TabIndex = 87;
			this.pictureBox5.TabStop = false;
			this.groupBox68.Controls.Add(this.cmbProduct3);
			this.groupBox68.Location = new global::System.Drawing.Point(818, 4);
			this.groupBox68.Name = "groupBox68";
			this.groupBox68.Size = new global::System.Drawing.Size(161, 81);
			this.groupBox68.TabIndex = 1;
			this.groupBox68.TabStop = false;
			this.groupBox68.Text = "Product";
			this.cmbProduct3.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbProduct3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProduct3.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbProduct3.FormattingEnabled = true;
			this.cmbProduct3.Location = new global::System.Drawing.Point(6, 32);
			this.cmbProduct3.Name = "cmbProduct3";
			this.cmbProduct3.Size = new global::System.Drawing.Size(149, 23);
			this.cmbProduct3.TabIndex = 0;
			this.cmbProduct3.DropDown += new global::System.EventHandler(this.cmbProduct3_DropDown);
			this.groupBox66.Controls.Add(this.cmbWeeklyReportExport);
			this.groupBox66.Location = new global::System.Drawing.Point(1050, 4);
			this.groupBox66.Name = "groupBox66";
			this.groupBox66.Size = new global::System.Drawing.Size(55, 81);
			this.groupBox66.TabIndex = 3;
			this.groupBox66.TabStop = false;
			this.groupBox66.Text = "Export";
			this.cmbWeeklyReportExport.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.SaveExcel;
			this.cmbWeeklyReportExport.Location = new global::System.Drawing.Point(11, 28);
			this.cmbWeeklyReportExport.Name = "cmbWeeklyReportExport";
			this.cmbWeeklyReportExport.Size = new global::System.Drawing.Size(35, 36);
			this.cmbWeeklyReportExport.TabIndex = 1;
			this.cmbWeeklyReportExport.TabStop = false;
			this.cmbWeeklyReportExport.Click += new global::System.EventHandler(this.cmbWeeklyReportExport_Click);
			this.groupBox67.Controls.Add(this.cmdWeeklyReportSearch);
			this.groupBox67.Location = new global::System.Drawing.Point(985, 4);
			this.groupBox67.Name = "groupBox67";
			this.groupBox67.Size = new global::System.Drawing.Size(59, 81);
			this.groupBox67.TabIndex = 0;
			this.groupBox67.TabStop = false;
			this.groupBox67.Text = "Search";
			this.cmdWeeklyReportSearch.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableSearch;
			this.cmdWeeklyReportSearch.Location = new global::System.Drawing.Point(11, 26);
			this.cmdWeeklyReportSearch.Name = "cmdWeeklyReportSearch";
			this.cmdWeeklyReportSearch.Size = new global::System.Drawing.Size(35, 36);
			this.cmdWeeklyReportSearch.TabIndex = 2;
			this.cmdWeeklyReportSearch.TabStop = false;
			this.cmdWeeklyReportSearch.Click += new global::System.EventHandler(this.cmdWeeklyReportSearch_Click);
			this.groupBox64.Controls.Add(this.WeeklyReportStatusPanel);
			this.groupBox64.Controls.Add(this.dtp_week_End);
			this.groupBox64.Controls.Add(this.dtp_week_Start);
			this.groupBox64.Location = new global::System.Drawing.Point(8, 4);
			this.groupBox64.Name = "groupBox64";
			this.groupBox64.Size = new global::System.Drawing.Size(804, 81);
			this.groupBox64.TabIndex = 1;
			this.groupBox64.TabStop = false;
			this.groupBox64.Text = "Option";
			this.WeeklyReportStatusPanel.Controls.Add(this.rdoWRDetectCarrier);
			this.WeeklyReportStatusPanel.Controls.Add(this.rdoWRTotal);
			this.WeeklyReportStatusPanel.Controls.Add(this.rdoWRSipCnt);
			this.WeeklyReportStatusPanel.Controls.Add(this.rdoWRSipFail);
			this.WeeklyReportStatusPanel.Location = new global::System.Drawing.Point(6, 16);
			this.WeeklyReportStatusPanel.Name = "WeeklyReportStatusPanel";
			this.WeeklyReportStatusPanel.Size = new global::System.Drawing.Size(424, 59);
			this.WeeklyReportStatusPanel.TabIndex = 5;
			this.rdoWRDetectCarrier.AutoSize = true;
			this.rdoWRDetectCarrier.Location = new global::System.Drawing.Point(322, 20);
			this.rdoWRDetectCarrier.Name = "rdoWRDetectCarrier";
			this.rdoWRDetectCarrier.Size = new global::System.Drawing.Size(97, 19);
			this.rdoWRDetectCarrier.TabIndex = 3;
			this.rdoWRDetectCarrier.TabStop = true;
			this.rdoWRDetectCarrier.Tag = "DetectCarrier";
			this.rdoWRDetectCarrier.Text = "Detect Carrier";
			this.rdoWRDetectCarrier.UseVisualStyleBackColor = true;
			this.rdoWRTotal.AutoSize = true;
			this.rdoWRTotal.Location = new global::System.Drawing.Point(3, 20);
			this.rdoWRTotal.Name = "rdoWRTotal";
			this.rdoWRTotal.Size = new global::System.Drawing.Size(88, 19);
			this.rdoWRTotal.TabIndex = 0;
			this.rdoWRTotal.TabStop = true;
			this.rdoWRTotal.Tag = "Total";
			this.rdoWRTotal.Text = "Total Carrier";
			this.rdoWRTotal.UseVisualStyleBackColor = true;
			this.rdoWRSipCnt.AutoSize = true;
			this.rdoWRSipCnt.Location = new global::System.Drawing.Point(97, 20);
			this.rdoWRSipCnt.Name = "rdoWRSipCnt";
			this.rdoWRSipCnt.Size = new global::System.Drawing.Size(114, 19);
			this.rdoWRSipCnt.TabIndex = 1;
			this.rdoWRSipCnt.TabStop = true;
			this.rdoWRSipCnt.Tag = "SIBCount";
			this.rdoWRSipCnt.Text = "Defect Sib Count";
			this.rdoWRSipCnt.UseVisualStyleBackColor = true;
			this.rdoWRSipFail.AutoSize = true;
			this.rdoWRSipFail.Location = new global::System.Drawing.Point(217, 20);
			this.rdoWRSipFail.Name = "rdoWRSipFail";
			this.rdoWRSipFail.Size = new global::System.Drawing.Size(99, 19);
			this.rdoWRSipFail.TabIndex = 2;
			this.rdoWRSipFail.TabStop = true;
			this.rdoWRSipFail.Tag = "SIBFail";
			this.rdoWRSipFail.Text = "Defect Sib Fail";
			this.rdoWRSipFail.UseVisualStyleBackColor = true;
			this.dtp_week_End.Location = new global::System.Drawing.Point(623, 32);
			this.dtp_week_End.Name = "dtp_week_End";
			this.dtp_week_End.Size = new global::System.Drawing.Size(174, 23);
			this.dtp_week_End.TabIndex = 4;
			this.dtp_week_Start.Location = new global::System.Drawing.Point(436, 32);
			this.dtp_week_Start.Name = "dtp_week_Start";
			this.dtp_week_Start.Size = new global::System.Drawing.Size(170, 23);
			this.dtp_week_Start.TabIndex = 3;
			this.tpATPList.Controls.Add(this.panel48);
			this.tpATPList.Controls.Add(this.panel47);
			this.tpATPList.Controls.Add(this.panel46);
			this.tpATPList.Location = new global::System.Drawing.Point(4, 24);
			this.tpATPList.Name = "tpATPList";
			this.tpATPList.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpATPList.Size = new global::System.Drawing.Size(1176, 697);
			this.tpATPList.TabIndex = 94;
			this.tpATPList.Text = "ATP Viewer";
			this.tpATPList.UseVisualStyleBackColor = true;
			this.panel48.Controls.Add(this.groupBox76);
			this.panel48.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel48.Location = new global::System.Drawing.Point(3, 193);
			this.panel48.Name = "panel48";
			this.panel48.Size = new global::System.Drawing.Size(1170, 501);
			this.panel48.TabIndex = 4;
			this.groupBox76.Controls.Add(this.gridATPlist);
			this.groupBox76.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox76.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox76.Name = "groupBox76";
			this.groupBox76.Size = new global::System.Drawing.Size(1170, 501);
			this.groupBox76.TabIndex = 0;
			this.groupBox76.TabStop = false;
			this.groupBox76.Text = "ATP List";
			this.gridATPlist.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridATPlist.EnableSort = true;
			this.gridATPlist.Location = new global::System.Drawing.Point(3, 19);
			this.gridATPlist.Name = "gridATPlist";
			this.gridATPlist.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridATPlist.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridATPlist.Size = new global::System.Drawing.Size(1164, 479);
			this.gridATPlist.TabIndex = 0;
			this.gridATPlist.TabStop = true;
			this.gridATPlist.ToolTipText = "";
			this.panel47.Controls.Add(this.groupBox79);
			this.panel47.Controls.Add(this.groupBox75);
			this.panel47.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel47.Location = new global::System.Drawing.Point(3, 93);
			this.panel47.Name = "panel47";
			this.panel47.Size = new global::System.Drawing.Size(1170, 100);
			this.panel47.TabIndex = 3;
			this.groupBox79.Controls.Add(this.pnlATPviewer);
			this.groupBox79.Location = new global::System.Drawing.Point(882, 10);
			this.groupBox79.Name = "groupBox79";
			this.groupBox79.Size = new global::System.Drawing.Size(270, 90);
			this.groupBox79.TabIndex = 7;
			this.groupBox79.TabStop = false;
			this.groupBox79.Text = "View Option";
			this.pnlATPviewer.Controls.Add(this.rdoATPTotalList);
			this.pnlATPviewer.Controls.Add(this.rdoATPDaily);
			this.pnlATPviewer.Location = new global::System.Drawing.Point(6, 22);
			this.pnlATPviewer.Name = "pnlATPviewer";
			this.pnlATPviewer.Size = new global::System.Drawing.Size(258, 59);
			this.pnlATPviewer.TabIndex = 8;
			this.rdoATPTotalList.AutoSize = true;
			this.rdoATPTotalList.Location = new global::System.Drawing.Point(23, 20);
			this.rdoATPTotalList.Name = "rdoATPTotalList";
			this.rdoATPTotalList.Size = new global::System.Drawing.Size(71, 19);
			this.rdoATPTotalList.TabIndex = 5;
			this.rdoATPTotalList.TabStop = true;
			this.rdoATPTotalList.Tag = "TotalList";
			this.rdoATPTotalList.Text = "Total List";
			this.rdoATPTotalList.UseVisualStyleBackColor = true;
			this.rdoATPDaily.AutoSize = true;
			this.rdoATPDaily.Location = new global::System.Drawing.Point(125, 20);
			this.rdoATPDaily.Name = "rdoATPDaily";
			this.rdoATPDaily.Size = new global::System.Drawing.Size(120, 19);
			this.rdoATPDaily.TabIndex = 6;
			this.rdoATPDaily.TabStop = true;
			this.rdoATPDaily.Tag = "DailySummarized";
			this.rdoATPDaily.Text = "Daily Summarized";
			this.rdoATPDaily.UseVisualStyleBackColor = true;
			this.groupBox75.Controls.Add(this.gridATPsummary);
			this.groupBox75.Location = new global::System.Drawing.Point(9, 7);
			this.groupBox75.Name = "groupBox75";
			this.groupBox75.Size = new global::System.Drawing.Size(867, 90);
			this.groupBox75.TabIndex = 0;
			this.groupBox75.TabStop = false;
			this.groupBox75.Text = "Summary";
			this.gridATPsummary.EnableSort = true;
			this.gridATPsummary.Location = new global::System.Drawing.Point(30, 22);
			this.gridATPsummary.Name = "gridATPsummary";
			this.gridATPsummary.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridATPsummary.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridATPsummary.Size = new global::System.Drawing.Size(820, 59);
			this.gridATPsummary.TabIndex = 0;
			this.gridATPsummary.TabStop = true;
			this.gridATPsummary.ToolTipText = "";
			this.panel46.Controls.Add(this.groupBox78);
			this.panel46.Controls.Add(this.groupBox77);
			this.panel46.Controls.Add(this.groupBox74);
			this.panel46.Controls.Add(this.groupBox73);
			this.panel46.Controls.Add(this.groupBox72);
			this.panel46.Controls.Add(this.groupBox57);
			this.panel46.Controls.Add(this.groupBox71);
			this.panel46.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel46.Location = new global::System.Drawing.Point(3, 3);
			this.panel46.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel46.Name = "panel46";
			this.panel46.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel46.Size = new global::System.Drawing.Size(1170, 90);
			this.panel46.TabIndex = 1;
			this.groupBox78.Controls.Add(this.comboBox1);
			this.groupBox78.Location = new global::System.Drawing.Point(507, 8);
			this.groupBox78.Name = "groupBox78";
			this.groupBox78.Size = new global::System.Drawing.Size(120, 75);
			this.groupBox78.TabIndex = 9;
			this.groupBox78.TabStop = false;
			this.groupBox78.Text = "Class";
			this.comboBox1.BackColor = global::System.Drawing.Color.LightGray;
			this.comboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new global::System.Drawing.Point(8, 34);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(106, 23);
			this.comboBox1.TabIndex = 9;
			this.groupBox77.Controls.Add(this.cmbATPexcel);
			this.groupBox77.Location = new global::System.Drawing.Point(1080, 8);
			this.groupBox77.Name = "groupBox77";
			this.groupBox77.Size = new global::System.Drawing.Size(72, 76);
			this.groupBox77.TabIndex = 1;
			this.groupBox77.TabStop = false;
			this.groupBox77.Text = "Excel";
			this.cmbATPexcel.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.SaveExcel;
			this.cmbATPexcel.Location = new global::System.Drawing.Point(14, 23);
			this.cmbATPexcel.Name = "cmbATPexcel";
			this.cmbATPexcel.Size = new global::System.Drawing.Size(42, 42);
			this.cmbATPexcel.TabIndex = 1;
			this.cmbATPexcel.TabStop = false;
			this.cmbATPexcel.Click += new global::System.EventHandler(this.cmbATPexcel_Click);
			this.groupBox74.Controls.Add(this.cmbATPsearch);
			this.groupBox74.Location = new global::System.Drawing.Point(1002, 8);
			this.groupBox74.Name = "groupBox74";
			this.groupBox74.Size = new global::System.Drawing.Size(72, 76);
			this.groupBox74.TabIndex = 0;
			this.groupBox74.TabStop = false;
			this.groupBox74.Text = "Search";
			this.cmbATPsearch.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableSearch;
			this.cmbATPsearch.Location = new global::System.Drawing.Point(11, 23);
			this.cmbATPsearch.Name = "cmbATPsearch";
			this.cmbATPsearch.Size = new global::System.Drawing.Size(46, 40);
			this.cmbATPsearch.TabIndex = 0;
			this.cmbATPsearch.TabStop = false;
			this.cmbATPsearch.Click += new global::System.EventHandler(this.cmbATPsearch_Click);
			this.groupBox73.Controls.Add(this.dptATPend);
			this.groupBox73.Controls.Add(this.dptATPstart);
			this.groupBox73.Location = new global::System.Drawing.Point(633, 8);
			this.groupBox73.Name = "groupBox73";
			this.groupBox73.Size = new global::System.Drawing.Size(363, 76);
			this.groupBox73.TabIndex = 5;
			this.groupBox73.TabStop = false;
			this.groupBox73.Text = "Date";
			this.dptATPend.CustomFormat = "'End Date : ' yyyy-MM-dd";
			this.dptATPend.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dptATPend.Location = new global::System.Drawing.Point(193, 31);
			this.dptATPend.Name = "dptATPend";
			this.dptATPend.Size = new global::System.Drawing.Size(164, 23);
			this.dptATPend.TabIndex = 6;
			this.dptATPstart.CustomFormat = "'Start Date : ' yyyy-MM-dd";
			this.dptATPstart.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dptATPstart.Location = new global::System.Drawing.Point(6, 33);
			this.dptATPstart.Name = "dptATPstart";
			this.dptATPstart.Size = new global::System.Drawing.Size(164, 23);
			this.dptATPstart.TabIndex = 5;
			this.groupBox72.Controls.Add(this.cmbATPproduct);
			this.groupBox72.Location = new global::System.Drawing.Point(360, 8);
			this.groupBox72.Name = "groupBox72";
			this.groupBox72.Size = new global::System.Drawing.Size(141, 76);
			this.groupBox72.TabIndex = 5;
			this.groupBox72.TabStop = false;
			this.groupBox72.Text = "Product";
			this.cmbATPproduct.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbATPproduct.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbATPproduct.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbATPproduct.FormattingEnabled = true;
			this.cmbATPproduct.Location = new global::System.Drawing.Point(3, 34);
			this.cmbATPproduct.Name = "cmbATPproduct";
			this.cmbATPproduct.Size = new global::System.Drawing.Size(130, 23);
			this.cmbATPproduct.TabIndex = 8;
			this.cmbATPproduct.DropDown += new global::System.EventHandler(this.cmbATPproduct_DropDown);
			this.groupBox57.Controls.Add(this.txtATPname);
			this.groupBox57.Controls.Add(this.cmbATPname);
			this.groupBox57.Location = new global::System.Drawing.Point(183, 7);
			this.groupBox57.Name = "groupBox57";
			this.groupBox57.Size = new global::System.Drawing.Size(171, 76);
			this.groupBox57.TabIndex = 8;
			this.groupBox57.TabStop = false;
			this.groupBox57.Text = "ATP name";
			this.txtATPname.Location = new global::System.Drawing.Point(6, 19);
			this.txtATPname.Name = "txtATPname";
			this.txtATPname.Size = new global::System.Drawing.Size(157, 23);
			this.txtATPname.TabIndex = 7;
			this.cmbATPname.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbATPname.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbATPname.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbATPname.FormattingEnabled = true;
			this.cmbATPname.Location = new global::System.Drawing.Point(6, 48);
			this.cmbATPname.Name = "cmbATPname";
			this.cmbATPname.Size = new global::System.Drawing.Size(157, 23);
			this.cmbATPname.TabIndex = 0;
			this.cmbATPname.DropDown += new global::System.EventHandler(this.cmbATPname_DropDown);
			this.groupBox71.Controls.Add(this.txtATPhostname);
			this.groupBox71.Controls.Add(this.cmbATPhostname);
			this.groupBox71.Location = new global::System.Drawing.Point(9, 7);
			this.groupBox71.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox71.Name = "groupBox71";
			this.groupBox71.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox71.Size = new global::System.Drawing.Size(168, 76);
			this.groupBox71.TabIndex = 2;
			this.groupBox71.TabStop = false;
			this.groupBox71.Text = "hostname";
			this.txtATPhostname.Location = new global::System.Drawing.Point(6, 19);
			this.txtATPhostname.Name = "txtATPhostname";
			this.txtATPhostname.Size = new global::System.Drawing.Size(157, 23);
			this.txtATPhostname.TabIndex = 5;
			this.txtATPhostname.TextChanged += new global::System.EventHandler(this.txtATPhostname_TextChanged);
			this.cmbATPhostname.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbATPhostname.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbATPhostname.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbATPhostname.FormattingEnabled = true;
			this.cmbATPhostname.Location = new global::System.Drawing.Point(6, 48);
			this.cmbATPhostname.Name = "cmbATPhostname";
			this.cmbATPhostname.Size = new global::System.Drawing.Size(157, 23);
			this.cmbATPhostname.TabIndex = 1;
			this.cmbATPhostname.DropDown += new global::System.EventHandler(this.cmbATPhostname_DropDown);
			this.tpCorrHistory.Controls.Add(this.panel49);
			this.tpCorrHistory.Location = new global::System.Drawing.Point(4, 24);
			this.tpCorrHistory.Name = "tpCorrHistory";
			this.tpCorrHistory.Size = new global::System.Drawing.Size(1176, 697);
			this.tpCorrHistory.TabIndex = 95;
			this.tpCorrHistory.Text = "Correlation parts history";
			this.tpCorrHistory.UseVisualStyleBackColor = true;
			this.panel49.Controls.Add(this.splitContainer1);
			this.panel49.Controls.Add(this.panel51);
			this.panel49.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel49.Location = new global::System.Drawing.Point(0, 0);
			this.panel49.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel49.Name = "panel49";
			this.panel49.Size = new global::System.Drawing.Size(1176, 697);
			this.panel49.TabIndex = 22;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 73);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.Controls.Add(this.groupBox80);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox90);
			this.splitContainer1.Size = new global::System.Drawing.Size(1176, 624);
			this.splitContainer1.SplitterDistance = 305;
			this.splitContainer1.TabIndex = 62;
			this.groupBox80.Controls.Add(this.gridCorrList);
			this.groupBox80.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox80.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox80.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox80.Name = "groupBox80";
			this.groupBox80.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox80.Size = new global::System.Drawing.Size(1176, 305);
			this.groupBox80.TabIndex = 5;
			this.groupBox80.TabStop = false;
			this.groupBox80.Text = "Correlation Part List";
			this.gridCorrList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridCorrList.EnableFastScrolling = true;
			this.gridCorrList.Location = new global::System.Drawing.Point(3, 20);
			this.gridCorrList.MasterTemplate.AllowCellContextMenu = false;
			this.gridCorrList.Name = "gridCorrList";
			this.gridCorrList.Size = new global::System.Drawing.Size(1170, 281);
			this.gridCorrList.TabIndex = 15;
			this.gridCorrList.Text = "radGridView2";
			this.gridCorrList.CellClick += new global::Telerik.WinControls.UI.GridViewCellEventHandler(this.gridCorrList_CellClick);
			this.gridCorrList.CellDoubleClick += new global::Telerik.WinControls.UI.GridViewCellEventHandler(this.gridCorrList_CellDoubleClick);
			this.groupBox90.Controls.Add(this.gridCorrHistory);
			this.groupBox90.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox90.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox90.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox90.Name = "groupBox90";
			this.groupBox90.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox90.Size = new global::System.Drawing.Size(1176, 315);
			this.groupBox90.TabIndex = 6;
			this.groupBox90.TabStop = false;
			this.groupBox90.Text = "Correlation Part History";
			this.gridCorrHistory.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridCorrHistory.Location = new global::System.Drawing.Point(3, 20);
			this.gridCorrHistory.Name = "gridCorrHistory";
			this.gridCorrHistory.Size = new global::System.Drawing.Size(1170, 291);
			this.gridCorrHistory.TabIndex = 15;
			this.gridCorrHistory.Text = "radGridView2";
			this.panel51.Controls.Add(this.groupBox81);
			this.panel51.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel51.Location = new global::System.Drawing.Point(0, 0);
			this.panel51.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel51.Name = "panel51";
			this.panel51.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel51.Size = new global::System.Drawing.Size(1176, 73);
			this.panel51.TabIndex = 60;
			this.groupBox81.Controls.Add(this.groupBox89);
			this.groupBox81.Controls.Add(this.groupBox88);
			this.groupBox81.Controls.Add(this.groupBox85);
			this.groupBox81.Controls.Add(this.groupBox82);
			this.groupBox81.Controls.Add(this.groupBox86);
			this.groupBox81.Controls.Add(this.groupBox87);
			this.groupBox81.Controls.Add(this.groupBox84);
			this.groupBox81.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox81.Font = new global::System.Drawing.Font("Segoe UI", 1f);
			this.groupBox81.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox81.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox81.Name = "groupBox81";
			this.groupBox81.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox81.Size = new global::System.Drawing.Size(1170, 67);
			this.groupBox81.TabIndex = 6;
			this.groupBox81.TabStop = false;
			this.groupBox89.Controls.Add(this.cmdDelCorrHistory);
			this.groupBox89.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox89.Location = new global::System.Drawing.Point(687, 5);
			this.groupBox89.Name = "groupBox89";
			this.groupBox89.Size = new global::System.Drawing.Size(84, 59);
			this.groupBox89.TabIndex = 97;
			this.groupBox89.TabStop = false;
			this.groupBox89.Text = "Del History";
			this.cmdDelCorrHistory.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableRemove;
			this.cmdDelCorrHistory.Location = new global::System.Drawing.Point(25, 18);
			this.cmdDelCorrHistory.Name = "cmdDelCorrHistory";
			this.cmdDelCorrHistory.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDelCorrHistory.TabIndex = 96;
			this.cmdDelCorrHistory.TabStop = false;
			this.cmdDelCorrHistory.Click += new global::System.EventHandler(this.cmdDelCorrHistory_Click);
			this.groupBox88.Controls.Add(this.txtCorrelationPart);
			this.groupBox88.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox88.Location = new global::System.Drawing.Point(6, 8);
			this.groupBox88.Name = "groupBox88";
			this.groupBox88.Size = new global::System.Drawing.Size(292, 55);
			this.groupBox88.TabIndex = 95;
			this.groupBox88.TabStop = false;
			this.groupBox88.Text = "Barcode";
			this.txtCorrelationPart.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtCorrelationPart.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtCorrelationPart.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtCorrelationPart.Location = new global::System.Drawing.Point(6, 20);
			this.txtCorrelationPart.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtCorrelationPart.Name = "txtCorrelationPart";
			this.txtCorrelationPart.Size = new global::System.Drawing.Size(280, 23);
			this.txtCorrelationPart.TabIndex = 93;
			this.groupBox85.Controls.Add(this.cmdAddCorrHistory);
			this.groupBox85.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox85.Location = new global::System.Drawing.Point(597, 5);
			this.groupBox85.Name = "groupBox85";
			this.groupBox85.Size = new global::System.Drawing.Size(84, 59);
			this.groupBox85.TabIndex = 92;
			this.groupBox85.TabStop = false;
			this.groupBox85.Text = "Add History";
			this.cmdAddCorrHistory.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdAddCorrHistory.Image");
			this.cmdAddCorrHistory.Location = new global::System.Drawing.Point(24, 18);
			this.cmdAddCorrHistory.Name = "cmdAddCorrHistory";
			this.cmdAddCorrHistory.Size = new global::System.Drawing.Size(35, 32);
			this.cmdAddCorrHistory.TabIndex = 87;
			this.cmdAddCorrHistory.TabStop = false;
			this.cmdAddCorrHistory.Click += new global::System.EventHandler(this.cmdAddCorrHistory_Click);
			this.groupBox82.Controls.Add(this.label64);
			this.groupBox82.Controls.Add(this.checkBox1);
			this.groupBox82.Controls.Add(this.dateTimePicker1);
			this.groupBox82.Controls.Add(this.dateTimePicker2);
			this.groupBox82.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox82.Location = new global::System.Drawing.Point(916, 8);
			this.groupBox82.Name = "groupBox82";
			this.groupBox82.Size = new global::System.Drawing.Size(248, 55);
			this.groupBox82.TabIndex = 88;
			this.groupBox82.TabStop = false;
			this.groupBox82.Text = "Period";
			this.groupBox82.Visible = false;
			this.label64.AutoSize = true;
			this.label64.Location = new global::System.Drawing.Point(128, 23);
			this.label64.Name = "label64";
			this.label64.Size = new global::System.Drawing.Size(15, 15);
			this.label64.TabIndex = 92;
			this.label64.Text = "~";
			this.label64.Visible = false;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new global::System.Drawing.Point(6, 24);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox1.TabIndex = 91;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Visible = false;
			this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
			this.dateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new global::System.Drawing.Point(148, 20);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new global::System.Drawing.Size(95, 23);
			this.dateTimePicker1.TabIndex = 84;
			this.dateTimePicker1.Visible = false;
			this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
			this.dateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new global::System.Drawing.Point(28, 20);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new global::System.Drawing.Size(95, 23);
			this.dateTimePicker2.TabIndex = 85;
			this.groupBox86.Controls.Add(this.cmdCorrExcel);
			this.groupBox86.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox86.Location = new global::System.Drawing.Point(536, 5);
			this.groupBox86.Name = "groupBox86";
			this.groupBox86.Size = new global::System.Drawing.Size(55, 59);
			this.groupBox86.TabIndex = 91;
			this.groupBox86.TabStop = false;
			this.groupBox86.Text = "Export";
			this.cmdCorrExcel.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.SaveExcel;
			this.cmdCorrExcel.Location = new global::System.Drawing.Point(12, 18);
			this.cmdCorrExcel.Name = "cmdCorrExcel";
			this.cmdCorrExcel.Size = new global::System.Drawing.Size(35, 32);
			this.cmdCorrExcel.TabIndex = 1;
			this.cmdCorrExcel.TabStop = false;
			this.cmdCorrExcel.Click += new global::System.EventHandler(this.cmdCorrExcel_Click);
			this.groupBox87.Controls.Add(this.cmdCorrSearch);
			this.groupBox87.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox87.Location = new global::System.Drawing.Point(471, 5);
			this.groupBox87.Name = "groupBox87";
			this.groupBox87.Size = new global::System.Drawing.Size(59, 59);
			this.groupBox87.TabIndex = 90;
			this.groupBox87.TabStop = false;
			this.groupBox87.Text = "Search";
			this.cmdCorrSearch.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableSearch;
			this.cmdCorrSearch.Location = new global::System.Drawing.Point(12, 18);
			this.cmdCorrSearch.Name = "cmdCorrSearch";
			this.cmdCorrSearch.Size = new global::System.Drawing.Size(35, 32);
			this.cmdCorrSearch.TabIndex = 2;
			this.cmdCorrSearch.TabStop = false;
			this.cmdCorrSearch.Click += new global::System.EventHandler(this.cmdCorrSearch_Click);
			this.groupBox84.Controls.Add(this.cmbProduct4);
			this.groupBox84.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox84.Location = new global::System.Drawing.Point(304, 8);
			this.groupBox84.Name = "groupBox84";
			this.groupBox84.Size = new global::System.Drawing.Size(161, 55);
			this.groupBox84.TabIndex = 89;
			this.groupBox84.TabStop = false;
			this.groupBox84.Text = "Product";
			this.cmbProduct4.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbProduct4.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProduct4.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbProduct4.FormattingEnabled = true;
			this.cmbProduct4.Location = new global::System.Drawing.Point(6, 20);
			this.cmbProduct4.Name = "cmbProduct4";
			this.cmbProduct4.Size = new global::System.Drawing.Size(149, 23);
			this.cmbProduct4.TabIndex = 0;
			this.cmbProduct4.DropDown += new global::System.EventHandler(this.cmbProduct4_DropDown);
			this.openFileDialog.FileName = "openFileDialog1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1184, 799);
			base.Controls.Add(this.tabCarrier);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel4);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "Carrier";
			this.Text = "Carrier Inventory";
			base.Load += new global::System.EventHandler(this.Carrier_Load);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.radGridView1.MasterTemplate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radGridView1).EndInit();
			this.radGridView1.ResumeLayout(false);
			this.radGridView1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox31.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdUserSetCarrier).EndInit();
			this.groupBox3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdAdd).EndInit();
			this.groupBox8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdExcel).EndInit();
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdSearch).EndInit();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.tabCarrier.ResumeLayout(false);
			this.tpEnrollCarrier.ResumeLayout(false);
			this.tpChangeStatusCarrier.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.panelScan.ResumeLayout(false);
			this.panelSubInfo.ResumeLayout(false);
			this.grpSelectStatus.ResumeLayout(false);
			this.panelRepairCode.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.panelSIBDamage.ResumeLayout(false);
			this.panelSIBDamage.PerformLayout();
			this.grpRepairReason.ResumeLayout(false);
			this.grpRepairReason.PerformLayout();
			this.panelPrintInfo.ResumeLayout(false);
			this.panelPrintInfo.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdAddCode).EndInit();
			this.grpLoadTester.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panelDefectUpload.ResumeLayout(false);
			this.panelDefectUpload.PerformLayout();
			this.groupBox56.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdUploadFile1).EndInit();
			this.groupBox44.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdRemoveFile).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbUploadImage).EndInit();
			this.groupBox43.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdUploadFile).EndInit();
			this.groupBox10.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdStatusSearch).EndInit();
			this.groupBox9.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdStatusApply).EndInit();
			this.groupBox7.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdStatusExcel).EndInit();
			this.panelBarcode.ResumeLayout(false);
			this.grpScan.ResumeLayout(false);
			this.grpScan.PerformLayout();
			this.groupCarrier.ResumeLayout(false);
			this.groupCarrier.PerformLayout();
			this.groupSIB.ResumeLayout(false);
			this.groupSIB.PerformLayout();
			this.panelMenu.ResumeLayout(false);
			this.panelMenu.PerformLayout();
			this.tpCarrierViewer.ResumeLayout(false);
			this.panel43.ResumeLayout(false);
			this.groupBox58.ResumeLayout(false);
			this.panel45.ResumeLayout(false);
			this.groupBox61.ResumeLayout(false);
			this.panel44.ResumeLayout(false);
			this.groupBox62.ResumeLayout(false);
			this.panel41.ResumeLayout(false);
			this.groupBox70.ResumeLayout(false);
			this.groupBox70.PerformLayout();
			this.groupBox69.ResumeLayout(false);
			this.panel42.ResumeLayout(false);
			this.ViewerList.ResumeLayout(false);
			this.pnlViewer.ResumeLayout(false);
			this.pnlViewer.PerformLayout();
			this.groupBox63.ResumeLayout(false);
			this.groupBox60.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdWareHouseExport).EndInit();
			this.groupBox59.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdWareHouseSearch).EndInit();
			this.tpViewCarrierData.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.chart_CarrierView).EndInit();
			this.panel15.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox53.ResumeLayout(false);
			this.groupBox30.ResumeLayout(false);
			this.groupBox15.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdViewExcel).EndInit();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.groupBox14.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdViewSearch).EndInit();
			this.tpCarrierHistory.ResumeLayout(false);
			this.panel16.ResumeLayout(false);
			this.panel17.ResumeLayout(false);
			this.groupBox18.ResumeLayout(false);
			this.panel18.ResumeLayout(false);
			this.groupBox19.ResumeLayout(false);
			this.groupBox19.PerformLayout();
			this.groupBox29.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdUserSetHistory).EndInit();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.groupBox21.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdHistoryExcel).EndInit();
			this.groupBox22.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdHistorySearch).EndInit();
			this.tpSIBStatus.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel19.ResumeLayout(false);
			this.groupBox16.ResumeLayout(false);
			this.panel22.ResumeLayout(false);
			this.groupBox33.ResumeLayout(false);
			this.groupBox33.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModifyDefect).EndInit();
			this.panelDetail.ResumeLayout(false);
			this.panelDetail.PerformLayout();
			this.panel21.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.chart_SIBView).EndInit();
			this.panel20.ResumeLayout(false);
			this.groupBox25.ResumeLayout(false);
			this.groupBox25.PerformLayout();
			this.groupBox26.ResumeLayout(false);
			this.groupBox24.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdDefectSearch).EndInit();
			this.groupBox23.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdSIBExcel).EndInit();
			this.tpBlackList.ResumeLayout(false);
			this.panel23.ResumeLayout(false);
			this.panel23.PerformLayout();
			this.panel24.ResumeLayout(false);
			this.groupBox17.ResumeLayout(false);
			this.panel26.ResumeLayout(false);
			this.groupBox20.ResumeLayout(false);
			this.groupBox20.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdMgrExcel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdMgrSearch).EndInit();
			this.tpSWHistory.ResumeLayout(false);
			this.panel27.ResumeLayout(false);
			this.panel28.ResumeLayout(false);
			this.groupBox27.ResumeLayout(false);
			this.panel29.ResumeLayout(false);
			this.groupBox28.ResumeLayout(false);
			this.groupBox28.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDelete).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSWAdd).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSWExcel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSWSearch).EndInit();
			this.tpSocketManage.ResumeLayout(false);
			this.tc_SM_Detail.ResumeLayout(false);
			this.tpSM_tpSocketComment.ResumeLayout(false);
			this.panel30.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.groupBox32.ResumeLayout(false);
			this.groupBox34.ResumeLayout(false);
			this.groupBox34.PerformLayout();
			this.groupBox35.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_comment_insert).EndInit();
			this.groupBox36.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_comment_excel).EndInit();
			this.panel11.ResumeLayout(false);
			this.panel32.ResumeLayout(false);
			this.panel32.PerformLayout();
			this.panel35.ResumeLayout(false);
			this.panel35.PerformLayout();
			this.panel31.ResumeLayout(false);
			this.panel31.PerformLayout();
			this.tpSM_tpEnrollSocket.ResumeLayout(false);
			this.panel34.ResumeLayout(false);
			this.groupBox42.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.groupBox37.ResumeLayout(false);
			this.groupBox37.PerformLayout();
			this.groupBox38.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpEnroll_btnSetting).EndInit();
			this.groupBox39.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpEnroll_btnAdd).EndInit();
			this.groupBox40.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpEnroll_btnExcel).EndInit();
			this.groupBox41.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpEnroll_btnSearch).EndInit();
			this.tpSM_tpPeriodComment.ResumeLayout(false);
			this.panel37.ResumeLayout(false);
			this.groupBox50.ResumeLayout(false);
			this.panel36.ResumeLayout(false);
			this.groupBox45.ResumeLayout(false);
			this.groupBox51.ResumeLayout(false);
			this.groupBox51.PerformLayout();
			this.groupBox46.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpPeriod_btnSetting).EndInit();
			this.groupBox48.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpPeriod_btnExcel).EndInit();
			this.groupBox49.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpPeriod_btnSearch).EndInit();
			this.tpSM_tpCompledTrend.ResumeLayout(false);
			this.panel40.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.chartComptedTrend).EndInit();
			this.panel39.ResumeLayout(false);
			this.panel38.ResumeLayout(false);
			this.groupBox47.ResumeLayout(false);
			this.groupBox52.ResumeLayout(false);
			this.groupBox54.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpCompleted_btnExcel).EndInit();
			this.groupBox55.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.tpSM_tpCompleted_btnSearch).EndInit();
			this.panel33.ResumeLayout(false);
			this.panel33.PerformLayout();
			this.tpWeeklyReport.ResumeLayout(false);
			this.groupBox65.ResumeLayout(false);
			this.groupBox65.PerformLayout();
			this.WeeklyReportPanel.ResumeLayout(false);
			this.groupBox83.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
			this.groupBox68.ResumeLayout(false);
			this.groupBox66.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmbWeeklyReportExport).EndInit();
			this.groupBox67.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdWeeklyReportSearch).EndInit();
			this.groupBox64.ResumeLayout(false);
			this.WeeklyReportStatusPanel.ResumeLayout(false);
			this.WeeklyReportStatusPanel.PerformLayout();
			this.tpATPList.ResumeLayout(false);
			this.panel48.ResumeLayout(false);
			this.groupBox76.ResumeLayout(false);
			this.panel47.ResumeLayout(false);
			this.groupBox79.ResumeLayout(false);
			this.pnlATPviewer.ResumeLayout(false);
			this.pnlATPviewer.PerformLayout();
			this.groupBox75.ResumeLayout(false);
			this.panel46.ResumeLayout(false);
			this.groupBox78.ResumeLayout(false);
			this.groupBox77.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmbATPexcel).EndInit();
			this.groupBox74.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmbATPsearch).EndInit();
			this.groupBox73.ResumeLayout(false);
			this.groupBox72.ResumeLayout(false);
			this.groupBox57.ResumeLayout(false);
			this.groupBox57.PerformLayout();
			this.groupBox71.ResumeLayout(false);
			this.groupBox71.PerformLayout();
			this.tpCorrHistory.ResumeLayout(false);
			this.panel49.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox80.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.gridCorrList.MasterTemplate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.gridCorrList).EndInit();
			this.groupBox90.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.gridCorrHistory.MasterTemplate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.gridCorrHistory).EndInit();
			this.panel51.ResumeLayout(false);
			this.groupBox81.ResumeLayout(false);
			this.groupBox89.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdDelCorrHistory).EndInit();
			this.groupBox88.ResumeLayout(false);
			this.groupBox88.PerformLayout();
			this.groupBox85.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdAddCorrHistory).EndInit();
			this.groupBox82.ResumeLayout(false);
			this.groupBox82.PerformLayout();
			this.groupBox86.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdCorrExcel).EndInit();
			this.groupBox87.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdCorrSearch).EndInit();
			this.groupBox84.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400019F RID: 415
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040001A1 RID: 417
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001A4 RID: 420
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040001A5 RID: 421
		private global::System.Windows.Forms.TextBox txtBarcode;

		// Token: 0x040001A6 RID: 422
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x040001A7 RID: 423
		private global::System.Windows.Forms.Label label_copyright;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.Splitter splitter10;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040001AB RID: 427
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x040001AC RID: 428
		private global::SourceGrid.Grid gridCarrierList;

		// Token: 0x040001AD RID: 429
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040001AE RID: 430
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040001AF RID: 431
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.PictureBox cmdExcel;

		// Token: 0x040001B1 RID: 433
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040001B2 RID: 434
		private global::System.Windows.Forms.PictureBox cmdSearch;

		// Token: 0x040001B3 RID: 435
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040001B4 RID: 436
		private global::System.Windows.Forms.PictureBox cmdAdd;

		// Token: 0x040001B5 RID: 437
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040001B6 RID: 438
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040001B7 RID: 439
		private global::System.Windows.Forms.ComboBox cmbTester;

		// Token: 0x040001B8 RID: 440
		private global::System.Windows.Forms.ComboBox cmbDevice;

		// Token: 0x040001B9 RID: 441
		private global::System.Windows.Forms.ComboBox cmbStatus;

		// Token: 0x040001BA RID: 442
		private global::System.Windows.Forms.ComboBox cmbCustomer;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.ComboBox cmbCorrelation;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040001BE RID: 446
		private global::System.ComponentModel.BackgroundWorker backgroundWorker1;

		// Token: 0x040001BF RID: 447
		private global::System.Windows.Forms.TabControl tabCarrier;

		// Token: 0x040001C0 RID: 448
		private global::System.Windows.Forms.TabPage tpEnrollCarrier;

		// Token: 0x040001C1 RID: 449
		private global::System.Windows.Forms.TabPage tpChangeStatusCarrier;

		// Token: 0x040001C2 RID: 450
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040001C3 RID: 451
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040001C4 RID: 452
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x040001C5 RID: 453
		private global::SourceGrid.Grid gridCarrierHistoryList;

		// Token: 0x040001C6 RID: 454
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x040001C8 RID: 456
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040001C9 RID: 457
		private global::System.Windows.Forms.TextBox txtStatusCorrelation;

		// Token: 0x040001CA RID: 458
		private global::System.Windows.Forms.TextBox txtStatusSite;

		// Token: 0x040001CB RID: 459
		private global::System.Windows.Forms.TextBox txtStatusCarrierStatus;

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.TextBox txtStatusCarrierType;

		// Token: 0x040001CD RID: 461
		private global::System.Windows.Forms.TextBox txtStatusCustomer;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.TextBox txtStatusOpCode;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.TextBox txtStatusTouchDownCnt;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.TextBox txtStatusCarrierNo;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040001D5 RID: 469
		private global::System.Windows.Forms.Label label20;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.TextBox txtStatusPkgType;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.Label label21;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.TextBox txtStatusTesterName;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.Label label22;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.Label label23;

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.TextBox txtStatusCleanCnt;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.Label label24;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.TextBox txtStatusMemo;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.Label label25;

		// Token: 0x040001DF RID: 479
		private global::System.Windows.Forms.TextBox txtStatusLimitrepairCnt;

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.Label label26;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.TextBox txtStatusLimitCleanCnt;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.Label label27;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.TextBox txtStatusrepairCnt;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.Label label28;

		// Token: 0x040001E5 RID: 485
		private global::System.Windows.Forms.Label label29;

		// Token: 0x040001E6 RID: 486
		private global::System.Windows.Forms.Label label30;

		// Token: 0x040001E7 RID: 487
		private global::System.Windows.Forms.TextBox txtStatusDevice;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.Panel panelScan;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.PictureBox cmdStatusExcel;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.PictureBox cmdStatusApply;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.GroupBox groupBox10;

		// Token: 0x040001EE RID: 494
		private global::System.Windows.Forms.PictureBox cmdStatusSearch;

		// Token: 0x040001EF RID: 495
		private global::System.Windows.Forms.GroupBox grpScan;

		// Token: 0x040001F0 RID: 496
		private global::System.Windows.Forms.Label lblBarcode;

		// Token: 0x040001F1 RID: 497
		private global::System.Windows.Forms.TextBox txtStatusBarcode;

		// Token: 0x040001F2 RID: 498
		private global::System.Windows.Forms.Panel panelMenu;

		// Token: 0x040001F3 RID: 499
		private global::System.Windows.Forms.RadioButton rdoLoad;

		// Token: 0x040001F4 RID: 500
		private global::System.Windows.Forms.RadioButton rdoCleanStart;

		// Token: 0x040001F5 RID: 501
		private global::System.Windows.Forms.RadioButton rdorepairStart;

		// Token: 0x040001F6 RID: 502
		private global::System.Windows.Forms.RadioButton rdorepairEnd;

		// Token: 0x040001F7 RID: 503
		private global::System.Windows.Forms.TabPage tpViewCarrierData;

		// Token: 0x040001F8 RID: 504
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x040001F9 RID: 505
		private global::System.Windows.Forms.DataVisualization.Charting.Chart chart_CarrierView;

		// Token: 0x040001FA RID: 506
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x040001FB RID: 507
		private global::System.Windows.Forms.GroupBox groupBox12;

		// Token: 0x040001FC RID: 508
		private global::System.Windows.Forms.DateTimePicker dtp_End;

		// Token: 0x040001FD RID: 509
		private global::System.Windows.Forms.DateTimePicker dtp_Start;

		// Token: 0x040001FE RID: 510
		private global::System.Windows.Forms.GroupBox groupBox13;

		// Token: 0x040001FF RID: 511
		private global::System.Windows.Forms.PictureBox cmdViewSearch;

		// Token: 0x04000200 RID: 512
		private global::System.Windows.Forms.CheckBox chkBarcode;

		// Token: 0x04000201 RID: 513
		private global::System.Windows.Forms.ComboBox cmbCarrierType;

		// Token: 0x04000202 RID: 514
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000203 RID: 515
		private global::System.Windows.Forms.ComboBox cmbLoadTester;

		// Token: 0x04000204 RID: 516
		private global::System.Windows.Forms.GroupBox grpRepairReason;

		// Token: 0x04000205 RID: 517
		private global::System.Windows.Forms.GroupBox grpLoadTester;

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.Splitter splitter1;

		// Token: 0x04000207 RID: 519
		private global::System.Windows.Forms.GroupBox groupBox14;

		// Token: 0x04000208 RID: 520
		private global::System.Windows.Forms.ComboBox cmbProduct;

		// Token: 0x04000209 RID: 521
		private global::System.Windows.Forms.ComboBox cmbOpCode;

		// Token: 0x0400020A RID: 522
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.TextBox txtRevision;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400020D RID: 525
		private global::System.Windows.Forms.CheckBox chkMultiBarcode;

		// Token: 0x0400020E RID: 526
		private global::System.Windows.Forms.TextBox txtRepairCode;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.Splitter splitter2;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.Panel panel14;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.Panel panelBarcode;

		// Token: 0x04000212 RID: 530
		private global::System.Windows.Forms.PictureBox cmdAddCode;

		// Token: 0x04000213 RID: 531
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x04000214 RID: 532
		private global::SourceGrid.Grid gridInventoryList;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.Splitter splitter3;

		// Token: 0x04000216 RID: 534
		private global::System.Windows.Forms.TabPage tpCarrierHistory;

		// Token: 0x04000217 RID: 535
		private global::System.Windows.Forms.Panel panel16;

		// Token: 0x04000218 RID: 536
		private global::System.Windows.Forms.Panel panel17;

		// Token: 0x04000219 RID: 537
		private global::System.Windows.Forms.GroupBox groupBox18;

		// Token: 0x0400021A RID: 538
		private global::SourceGrid.Grid gridSearchHistory;

		// Token: 0x0400021B RID: 539
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x0400021C RID: 540
		private global::System.Windows.Forms.GroupBox groupBox19;

		// Token: 0x0400021D RID: 541
		private global::System.Windows.Forms.TextBox txtHistoryBarcode;

		// Token: 0x0400021E RID: 542
		private global::System.Windows.Forms.GroupBox groupBox21;

		// Token: 0x0400021F RID: 543
		private global::System.Windows.Forms.PictureBox cmdHistoryExcel;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.GroupBox groupBox22;

		// Token: 0x04000221 RID: 545
		private global::System.Windows.Forms.PictureBox cmdHistorySearch;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.RadioButton rdoMonth;

		// Token: 0x04000224 RID: 548
		private global::System.Windows.Forms.RadioButton rdoPeriod;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.RadioButton rdoWeek;

		// Token: 0x04000226 RID: 550
		private global::System.Windows.Forms.RadioButton rdoDay;

		// Token: 0x04000227 RID: 551
		private global::Amkor.CADModules.CarrierModule.Control.CheckedComboBox chkcmbHistoryStatus;

		// Token: 0x04000228 RID: 552
		private global::System.Windows.Forms.GroupBox groupBox15;

		// Token: 0x04000229 RID: 553
		private global::System.Windows.Forms.PictureBox cmdViewExcel;

		// Token: 0x0400022A RID: 554
		private global::System.Windows.Forms.GroupBox groupBox11;

		// Token: 0x0400022B RID: 555
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.CheckBox chkDate;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.DateTimePicker dtp_End_Histroy;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.DateTimePicker dtp_Start_History;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.RadioButton rdoDefectStart;

		// Token: 0x04000230 RID: 560
		private global::System.Windows.Forms.Label lblSIB1;

		// Token: 0x04000231 RID: 561
		private global::System.Windows.Forms.TextBox txtStatusSIB1Barcode;

		// Token: 0x04000232 RID: 562
		private global::System.Windows.Forms.ComboBox cmbHistoryCarrierType;

		// Token: 0x04000233 RID: 563
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000234 RID: 564
		private global::System.Windows.Forms.TabPage tpSIBStatus;

		// Token: 0x04000235 RID: 565
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x04000236 RID: 566
		private global::System.Windows.Forms.Panel panel19;

		// Token: 0x04000237 RID: 567
		private global::System.Windows.Forms.GroupBox groupBox16;

		// Token: 0x04000238 RID: 568
		private global::SourceGrid.Grid gridSIBStatusList;

		// Token: 0x04000239 RID: 569
		private global::System.Windows.Forms.Panel panel20;

		// Token: 0x0400023A RID: 570
		private global::System.Windows.Forms.GroupBox groupBox23;

		// Token: 0x0400023B RID: 571
		private global::System.Windows.Forms.PictureBox cmdSIBExcel;

		// Token: 0x0400023C RID: 572
		private global::System.Windows.Forms.GroupBox groupBox24;

		// Token: 0x0400023D RID: 573
		private global::System.Windows.Forms.PictureBox cmdDefectSearch;

		// Token: 0x0400023E RID: 574
		private global::System.Windows.Forms.GroupBox groupBox25;

		// Token: 0x0400023F RID: 575
		private global::System.Windows.Forms.RadioButton rdoMonth_SIB;

		// Token: 0x04000240 RID: 576
		private global::System.Windows.Forms.RadioButton rdoPeriod_SIB;

		// Token: 0x04000241 RID: 577
		private global::System.Windows.Forms.RadioButton rdoWeek_SIB;

		// Token: 0x04000242 RID: 578
		private global::System.Windows.Forms.RadioButton rdoDay_SIB;

		// Token: 0x04000243 RID: 579
		private global::System.Windows.Forms.DateTimePicker dtp_end_SIB;

		// Token: 0x04000244 RID: 580
		private global::System.Windows.Forms.DateTimePicker dtp_start_SIB;

		// Token: 0x04000245 RID: 581
		private global::System.Windows.Forms.GroupBox groupBox26;

		// Token: 0x04000246 RID: 582
		private global::System.Windows.Forms.ComboBox cmbDefectProduct;

		// Token: 0x04000247 RID: 583
		private global::System.Windows.Forms.Splitter splitter4;

		// Token: 0x04000248 RID: 584
		private global::System.Windows.Forms.Panel panel21;

		// Token: 0x04000249 RID: 585
		private global::System.Windows.Forms.DataVisualization.Charting.Chart chart_SIBView;

		// Token: 0x0400024A RID: 586
		private global::System.Windows.Forms.Label lblSIB2;

		// Token: 0x0400024B RID: 587
		private global::System.Windows.Forms.TextBox txtStatusSIB2Barcode;

		// Token: 0x0400024C RID: 588
		private global::System.Windows.Forms.Panel panel22;

		// Token: 0x0400024D RID: 589
		private global::System.Windows.Forms.ComboBox cmbSIBPeriodDate;

		// Token: 0x0400024E RID: 590
		private global::System.Windows.Forms.RadioButton rdoPeriodData;

		// Token: 0x0400024F RID: 591
		private global::System.Windows.Forms.RadioButton rdoTotalData;

		// Token: 0x04000250 RID: 592
		private global::System.Windows.Forms.Label lblAssignSIB2;

		// Token: 0x04000251 RID: 593
		private global::System.Windows.Forms.TextBox txtAssignSIB2;

		// Token: 0x04000252 RID: 594
		private global::System.Windows.Forms.Label lblAssignSIB1;

		// Token: 0x04000253 RID: 595
		private global::System.Windows.Forms.TextBox txtAssignSIB1;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.GroupBox groupSIB;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.GroupBox groupCarrier;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.Label label32;

		// Token: 0x04000257 RID: 599
		private global::System.Windows.Forms.TextBox txtMainCarrier;

		// Token: 0x04000258 RID: 600
		private global::System.Windows.Forms.TabPage tpBlackList;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.Panel panel23;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.GroupBox groupBox17;

		// Token: 0x0400025C RID: 604
		private global::SourceGrid.Grid gridMgrCarrier;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.Panel panel26;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.GroupBox groupBox20;

		// Token: 0x0400025F RID: 607
		private global::Amkor.CADModules.CarrierModule.Control.CheckedComboBox chkcmbStatus;

		// Token: 0x04000260 RID: 608
		private global::System.Windows.Forms.Label label34;

		// Token: 0x04000261 RID: 609
		private global::System.Windows.Forms.TextBox txtMgrBarcode;

		// Token: 0x04000262 RID: 610
		private global::System.Windows.Forms.PictureBox cmdMgrExcel;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.PictureBox cmdMgrSearch;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.GroupBox groupBox30;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.ComboBox cmbInventoryType;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.Label label33;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.Label label31;

		// Token: 0x04000268 RID: 616
		private global::System.Windows.Forms.ComboBox cmbMgrProduct;

		// Token: 0x04000269 RID: 617
		private global::System.Windows.Forms.ComboBox cmbMgrType;

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.ComboBox cmbMgrTester;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.Label label36;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.Panel panelSubInfo;

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.CheckBox chkAutoSelect;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.TabPage tpSWHistory;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.Panel panel27;

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.Panel panel28;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.GroupBox groupBox27;

		// Token: 0x04000272 RID: 626
		private global::SourceGrid.Grid gridSWHistory;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.Panel panel29;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.GroupBox groupBox28;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.Label label39;

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.TextBox txtSWVersion;

		// Token: 0x04000277 RID: 631
		private global::System.Windows.Forms.PictureBox cmdSWExcel;

		// Token: 0x04000278 RID: 632
		private global::System.Windows.Forms.PictureBox cmdSWSearch;

		// Token: 0x04000279 RID: 633
		private global::System.Windows.Forms.PictureBox cmdSWAdd;

		// Token: 0x0400027A RID: 634
		private global::System.Windows.Forms.PictureBox cmdDelete;

		// Token: 0x0400027B RID: 635
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400027C RID: 636
		private global::System.Windows.Forms.Button btnLabelPrint;

		// Token: 0x0400027D RID: 637
		private global::System.Windows.Forms.TextBox txtSite1Reason;

		// Token: 0x0400027E RID: 638
		private global::System.Windows.Forms.Label label37;

		// Token: 0x0400027F RID: 639
		private global::System.Windows.Forms.CheckBox chkBarcodeFlag;

		// Token: 0x04000280 RID: 640
		private global::System.Windows.Forms.Label cmbHistoryCarrierDevice;

		// Token: 0x04000281 RID: 641
		private global::System.Windows.Forms.ComboBox cmbHistoryProduct;

		// Token: 0x04000282 RID: 642
		private global::System.Windows.Forms.GroupBox groupBox29;

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.PictureBox cmdUserSetHistory;

		// Token: 0x04000284 RID: 644
		private global::System.Windows.Forms.GroupBox groupBox31;

		// Token: 0x04000285 RID: 645
		private global::System.Windows.Forms.PictureBox cmdUserSetCarrier;

		// Token: 0x04000286 RID: 646
		private global::System.Windows.Forms.TextBox txtSite2Reason;

		// Token: 0x04000287 RID: 647
		private global::System.Windows.Forms.Label label40;

		// Token: 0x04000288 RID: 648
		private global::System.Windows.Forms.TextBox txtSite2Yield;

		// Token: 0x04000289 RID: 649
		private global::System.Windows.Forms.TextBox txtSite1Yield;

		// Token: 0x0400028A RID: 650
		private global::System.Windows.Forms.RadioButton rdoIdle;

		// Token: 0x0400028B RID: 651
		private global::System.Windows.Forms.Panel panelRepairCode;

		// Token: 0x0400028C RID: 652
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x0400028D RID: 653
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x0400028E RID: 654
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x0400028F RID: 655
		private global::System.Windows.Forms.Panel panelPrintInfo;

		// Token: 0x04000290 RID: 656
		private global::System.Windows.Forms.Panel panelDetail;

		// Token: 0x04000291 RID: 657
		private global::System.Windows.Forms.CheckBox chkDefectCarrier;

		// Token: 0x04000292 RID: 658
		private global::System.Windows.Forms.CheckBox chkDefectSIB;

		// Token: 0x04000293 RID: 659
		private global::System.Windows.Forms.GroupBox groupBox33;

		// Token: 0x04000294 RID: 660
		private global::System.Windows.Forms.TabPage tpSocketManage;

		// Token: 0x04000295 RID: 661
		private global::System.Windows.Forms.TabControl tc_SM_Detail;

		// Token: 0x04000296 RID: 662
		private global::System.Windows.Forms.TabPage tpSM_tpSocketComment;

		// Token: 0x04000297 RID: 663
		private global::System.Windows.Forms.Panel panel33;

		// Token: 0x04000298 RID: 664
		private global::System.Windows.Forms.Label label45;

		// Token: 0x04000299 RID: 665
		private global::System.Windows.Forms.Panel panel30;

		// Token: 0x0400029A RID: 666
		private global::SourceGrid.Grid grid_socket_comment;

		// Token: 0x0400029B RID: 667
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x0400029C RID: 668
		private global::System.Windows.Forms.GroupBox groupBox32;

		// Token: 0x0400029D RID: 669
		private global::System.Windows.Forms.GroupBox groupBox34;

		// Token: 0x0400029E RID: 670
		private global::System.Windows.Forms.Label tpSM_tpComment_lblBarcode;

		// Token: 0x0400029F RID: 671
		private global::System.Windows.Forms.Label tpSM_tpComment_lblPkgType;

		// Token: 0x040002A0 RID: 672
		private global::System.Windows.Forms.Label tpSM_tpComment_lblDevice;

		// Token: 0x040002A1 RID: 673
		private global::System.Windows.Forms.Label tpSM_tpComment_lblCustomer;

		// Token: 0x040002A2 RID: 674
		private global::System.Windows.Forms.Label label41;

		// Token: 0x040002A3 RID: 675
		private global::System.Windows.Forms.Label label42;

		// Token: 0x040002A4 RID: 676
		private global::System.Windows.Forms.Label label43;

		// Token: 0x040002A5 RID: 677
		private global::System.Windows.Forms.Label label44;

		// Token: 0x040002A6 RID: 678
		private global::System.Windows.Forms.GroupBox groupBox35;

		// Token: 0x040002A7 RID: 679
		private global::System.Windows.Forms.PictureBox pb_comment_insert;

		// Token: 0x040002A8 RID: 680
		private global::System.Windows.Forms.GroupBox groupBox36;

		// Token: 0x040002A9 RID: 681
		private global::System.Windows.Forms.PictureBox pb_comment_excel;

		// Token: 0x040002AA RID: 682
		private global::System.Windows.Forms.Splitter splitter5;

		// Token: 0x040002AB RID: 683
		private global::System.Windows.Forms.TabPage tpSM_tpEnrollSocket;

		// Token: 0x040002AC RID: 684
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x040002AD RID: 685
		private global::System.Windows.Forms.TextBox txtAttachFile;

		// Token: 0x040002AE RID: 686
		private global::System.Windows.Forms.PictureBox cmdUploadFile;

		// Token: 0x040002AF RID: 687
		private global::System.Windows.Forms.Panel panelDefectUpload;

		// Token: 0x040002B0 RID: 688
		private global::System.Windows.Forms.GroupBox groupBox43;

		// Token: 0x040002B1 RID: 689
		private global::System.Windows.Forms.PictureBox pbUploadImage;

		// Token: 0x040002B2 RID: 690
		private global::System.Windows.Forms.GroupBox groupBox44;

		// Token: 0x040002B3 RID: 691
		private global::System.Windows.Forms.PictureBox cmdRemoveFile;

		// Token: 0x040002B4 RID: 692
		private global::System.Windows.Forms.PictureBox cmdModifyDefect;

		// Token: 0x040002B5 RID: 693
		private global::System.Windows.Forms.Panel panel34;

		// Token: 0x040002B6 RID: 694
		private global::System.Windows.Forms.GroupBox groupBox42;

		// Token: 0x040002B7 RID: 695
		private global::SourceGrid.Grid gridSocketList;

		// Token: 0x040002B8 RID: 696
		private global::System.Windows.Forms.Panel panel12;

		// Token: 0x040002B9 RID: 697
		private global::System.Windows.Forms.GroupBox groupBox37;

		// Token: 0x040002BA RID: 698
		private global::System.Windows.Forms.GroupBox groupBox38;

		// Token: 0x040002BB RID: 699
		private global::System.Windows.Forms.PictureBox tpSM_tpEnroll_btnSetting;

		// Token: 0x040002BC RID: 700
		private global::System.Windows.Forms.TextBox tpSM_tpEnroll_txtBarcode;

		// Token: 0x040002BD RID: 701
		private global::System.Windows.Forms.ComboBox tpSM_tpEnroll_cmbStatus;

		// Token: 0x040002BE RID: 702
		private global::System.Windows.Forms.Label label49;

		// Token: 0x040002BF RID: 703
		private global::System.Windows.Forms.ComboBox tpSM_tpEnroll_cmbDevice;

		// Token: 0x040002C0 RID: 704
		private global::System.Windows.Forms.ComboBox tpSM_tpEnroll_cmbCustomer;

		// Token: 0x040002C1 RID: 705
		private global::System.Windows.Forms.Label label51;

		// Token: 0x040002C2 RID: 706
		private global::System.Windows.Forms.GroupBox groupBox39;

		// Token: 0x040002C3 RID: 707
		private global::System.Windows.Forms.PictureBox tpSM_tpEnroll_btnAdd;

		// Token: 0x040002C4 RID: 708
		private global::System.Windows.Forms.GroupBox groupBox40;

		// Token: 0x040002C5 RID: 709
		private global::System.Windows.Forms.PictureBox tpSM_tpEnroll_btnExcel;

		// Token: 0x040002C6 RID: 710
		private global::System.Windows.Forms.GroupBox groupBox41;

		// Token: 0x040002C7 RID: 711
		private global::System.Windows.Forms.PictureBox tpSM_tpEnroll_btnSearch;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.Label label52;

		// Token: 0x040002C9 RID: 713
		private global::System.Windows.Forms.Label label53;

		// Token: 0x040002CA RID: 714
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x040002CB RID: 715
		private global::System.Windows.Forms.ListBox listBox_Socket;

		// Token: 0x040002CC RID: 716
		private global::System.Windows.Forms.Panel panel32;

		// Token: 0x040002CD RID: 717
		private global::System.Windows.Forms.Button btn_search;

		// Token: 0x040002CE RID: 718
		private global::System.Windows.Forms.TextBox tb_barcode;

		// Token: 0x040002CF RID: 719
		private global::System.Windows.Forms.Panel panel31;

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.Label label38;

		// Token: 0x040002D1 RID: 721
		private global::System.Windows.Forms.Label tpSM_tpComment_lblPn;

		// Token: 0x040002D2 RID: 722
		private global::System.Windows.Forms.Label label46;

		// Token: 0x040002D3 RID: 723
		private global::System.Windows.Forms.Label tpSM_tpComment_lblMfg;

		// Token: 0x040002D4 RID: 724
		private global::System.Windows.Forms.Label label48;

		// Token: 0x040002D5 RID: 725
		private global::System.Windows.Forms.Panel panel35;

		// Token: 0x040002D6 RID: 726
		private global::System.Windows.Forms.CheckBox cbx_bottom;

		// Token: 0x040002D7 RID: 727
		private global::System.Windows.Forms.CheckBox cbx_top;

		// Token: 0x040002D8 RID: 728
		private global::System.Windows.Forms.Label label47;

		// Token: 0x040002D9 RID: 729
		private global::System.Windows.Forms.ComboBox tpSM_tpEnroll_cmbSocketType;

		// Token: 0x040002DA RID: 730
		private global::System.Windows.Forms.Label label50;

		// Token: 0x040002DB RID: 731
		private global::System.Windows.Forms.Label tpSM_tpComment_lblSocketType;

		// Token: 0x040002DC RID: 732
		private global::System.Windows.Forms.Label label54;

		// Token: 0x040002DD RID: 733
		private global::System.Windows.Forms.TabPage tpSM_tpPeriodComment;

		// Token: 0x040002DE RID: 734
		private global::System.Windows.Forms.Panel panel37;

		// Token: 0x040002DF RID: 735
		private global::System.Windows.Forms.GroupBox groupBox50;

		// Token: 0x040002E0 RID: 736
		private global::SourceGrid.Grid gridPeriodSocketList;

		// Token: 0x040002E1 RID: 737
		private global::System.Windows.Forms.Panel panel36;

		// Token: 0x040002E2 RID: 738
		private global::System.Windows.Forms.GroupBox groupBox45;

		// Token: 0x040002E3 RID: 739
		private global::System.Windows.Forms.GroupBox groupBox51;

		// Token: 0x040002E4 RID: 740
		private global::System.Windows.Forms.DateTimePicker tpSM_tpPeriod_dtStart;

		// Token: 0x040002E5 RID: 741
		private global::System.Windows.Forms.DateTimePicker tpSM_tpPeriod_dtEnd;

		// Token: 0x040002E6 RID: 742
		private global::System.Windows.Forms.GroupBox groupBox46;

		// Token: 0x040002E7 RID: 743
		private global::System.Windows.Forms.PictureBox tpSM_tpPeriod_btnSetting;

		// Token: 0x040002E8 RID: 744
		private global::System.Windows.Forms.GroupBox groupBox48;

		// Token: 0x040002E9 RID: 745
		private global::System.Windows.Forms.PictureBox tpSM_tpPeriod_btnExcel;

		// Token: 0x040002EA RID: 746
		private global::System.Windows.Forms.GroupBox groupBox49;

		// Token: 0x040002EB RID: 747
		private global::System.Windows.Forms.PictureBox tpSM_tpPeriod_btnSearch;

		// Token: 0x040002EC RID: 748
		private global::System.Windows.Forms.ComboBox tpSM_tpPeriod_cmbCompletedCommentStatus;

		// Token: 0x040002ED RID: 749
		private global::System.Windows.Forms.Label label55;

		// Token: 0x040002EE RID: 750
		private global::System.Windows.Forms.TabPage tpSM_tpCompledTrend;

		// Token: 0x040002EF RID: 751
		private global::System.Windows.Forms.Panel panel38;

		// Token: 0x040002F0 RID: 752
		private global::System.Windows.Forms.GroupBox groupBox47;

		// Token: 0x040002F1 RID: 753
		private global::System.Windows.Forms.GroupBox groupBox52;

		// Token: 0x040002F2 RID: 754
		private global::System.Windows.Forms.DateTimePicker tpSM_tpCompleted_dtStart;

		// Token: 0x040002F3 RID: 755
		private global::System.Windows.Forms.DateTimePicker tpSM_tpCompleted_dtEnd;

		// Token: 0x040002F4 RID: 756
		private global::System.Windows.Forms.GroupBox groupBox54;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.PictureBox tpSM_tpCompleted_btnExcel;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.GroupBox groupBox55;

		// Token: 0x040002F7 RID: 759
		private global::System.Windows.Forms.PictureBox tpSM_tpCompleted_btnSearch;

		// Token: 0x040002F8 RID: 760
		private global::System.Windows.Forms.Panel panel40;

		// Token: 0x040002F9 RID: 761
		private global::System.Windows.Forms.DataVisualization.Charting.Chart chartComptedTrend;

		// Token: 0x040002FA RID: 762
		private global::System.Windows.Forms.Panel panel39;

		// Token: 0x040002FB RID: 763
		private global::SourceGrid.Grid gridCompletedList;

		// Token: 0x040002FC RID: 764
		private global::System.Windows.Forms.Panel panelSIBDamage;

		// Token: 0x040002FD RID: 765
		private global::System.Windows.Forms.Label label57;

		// Token: 0x040002FE RID: 766
		private global::System.Windows.Forms.Label label56;

		// Token: 0x040002FF RID: 767
		private global::System.Windows.Forms.ComboBox cmbSuspectCause;

		// Token: 0x04000300 RID: 768
		private global::System.Windows.Forms.ComboBox cmbDamage;

		// Token: 0x04000301 RID: 769
		private global::System.Windows.Forms.GroupBox groupBox53;

		// Token: 0x04000302 RID: 770
		private global::System.Windows.Forms.ComboBox cmbFailMode;

		// Token: 0x04000303 RID: 771
		private global::SourceGrid.Grid gridClassifiedBlacklist;

		// Token: 0x04000304 RID: 772
		private global::SourceGrid.Grid gridClassifiedClean;

		// Token: 0x04000305 RID: 773
		private global::System.Windows.Forms.ComboBox cmbHistoryCarrierCustomer;

		// Token: 0x04000306 RID: 774
		private global::System.Windows.Forms.Label label58;

		// Token: 0x04000307 RID: 775
		private global::System.Windows.Forms.ComboBox cmbHistoryCarrierCorrelation;

		// Token: 0x04000308 RID: 776
		private global::System.Windows.Forms.ComboBox cmbHistoryCarrierTester;

		// Token: 0x04000309 RID: 777
		private global::System.Windows.Forms.ComboBox cmbHistoryCarrierOpCode;

		// Token: 0x0400030A RID: 778
		private global::System.Windows.Forms.Label label61;

		// Token: 0x0400030B RID: 779
		private global::System.Windows.Forms.Label label60;

		// Token: 0x0400030C RID: 780
		private global::System.Windows.Forms.Label label59;

		// Token: 0x0400030D RID: 781
		private global::System.Windows.Forms.CheckBox chkHistoryCarrierBarcode;

		// Token: 0x0400030E RID: 782
		private global::System.Windows.Forms.RadioButton rdoBatchChange;

		// Token: 0x0400030F RID: 783
		private global::System.Windows.Forms.GroupBox groupBox56;

		// Token: 0x04000310 RID: 784
		private global::System.Windows.Forms.PictureBox cmdUploadFile1;

		// Token: 0x04000311 RID: 785
		private global::System.Windows.Forms.GroupBox grpSelectStatus;

		// Token: 0x04000312 RID: 786
		private global::System.Windows.Forms.ComboBox cmbSelectStatus;

		// Token: 0x04000313 RID: 787
		private global::System.Windows.Forms.RadioButton rdoWareHouse;

		// Token: 0x04000314 RID: 788
		private global::System.Windows.Forms.RadioButton rdoEngr;

		// Token: 0x04000315 RID: 789
		private global::System.Windows.Forms.TextBox txtMCN;

		// Token: 0x04000316 RID: 790
		private global::System.Windows.Forms.Label label19;

		// Token: 0x04000317 RID: 791
		private global::System.Windows.Forms.TabPage tpCarrierViewer;

		// Token: 0x04000318 RID: 792
		private global::System.Windows.Forms.GroupBox groupBox58;

		// Token: 0x04000319 RID: 793
		private global::SourceGrid.Grid gridViewerInfo;

		// Token: 0x0400031A RID: 794
		private global::System.Windows.Forms.GroupBox groupBox60;

		// Token: 0x0400031B RID: 795
		private global::System.Windows.Forms.GroupBox groupBox59;

		// Token: 0x0400031C RID: 796
		private global::System.Windows.Forms.PictureBox cmdWareHouseExport;

		// Token: 0x0400031D RID: 797
		private global::System.Windows.Forms.PictureBox cmdWareHouseSearch;

		// Token: 0x0400031E RID: 798
		private global::System.Windows.Forms.GroupBox groupBox63;

		// Token: 0x0400031F RID: 799
		private global::System.Windows.Forms.ComboBox cmbProduct2;

		// Token: 0x04000320 RID: 800
		private global::System.Windows.Forms.TabPage tpWeeklyReport;

		// Token: 0x04000321 RID: 801
		private global::System.Windows.Forms.Label label62;

		// Token: 0x04000322 RID: 802
		private global::System.Windows.Forms.GroupBox groupBox65;

		// Token: 0x04000323 RID: 803
		private global::System.Windows.Forms.GroupBox groupBox64;

		// Token: 0x04000324 RID: 804
		private global::System.Windows.Forms.GroupBox groupBox67;

		// Token: 0x04000325 RID: 805
		private global::System.Windows.Forms.GroupBox groupBox66;

		// Token: 0x04000326 RID: 806
		private global::System.Windows.Forms.RadioButton rdoWRSipFail;

		// Token: 0x04000327 RID: 807
		private global::System.Windows.Forms.RadioButton rdoWRSipCnt;

		// Token: 0x04000328 RID: 808
		private global::System.Windows.Forms.RadioButton rdoWRTotal;

		// Token: 0x04000329 RID: 809
		private global::SourceGrid.Grid gridViewerList;

		// Token: 0x0400032A RID: 810
		private global::System.Windows.Forms.GroupBox groupBox62;

		// Token: 0x0400032B RID: 811
		private global::System.Windows.Forms.Panel panel41;

		// Token: 0x0400032C RID: 812
		private global::System.Windows.Forms.GroupBox groupBox61;

		// Token: 0x0400032D RID: 813
		private global::System.Windows.Forms.Panel WeeklyReportPanel;

		// Token: 0x0400032E RID: 814
		private global::System.Windows.Forms.GroupBox groupBox68;

		// Token: 0x0400032F RID: 815
		private global::System.Windows.Forms.ComboBox cmbProduct3;

		// Token: 0x04000330 RID: 816
		private global::System.Windows.Forms.PictureBox cmbWeeklyReportExport;

		// Token: 0x04000331 RID: 817
		private global::System.Windows.Forms.PictureBox cmdWeeklyReportSearch;

		// Token: 0x04000332 RID: 818
		private global::System.Windows.Forms.DateTimePicker dtp_week_End;

		// Token: 0x04000333 RID: 819
		private global::System.Windows.Forms.DateTimePicker dtp_week_Start;

		// Token: 0x04000334 RID: 820
		private global::SourceGrid.Grid gridWeeklyReport;

		// Token: 0x04000335 RID: 821
		private global::System.Windows.Forms.Panel WeeklyReportStatusPanel;

		// Token: 0x04000336 RID: 822
		private global::System.Windows.Forms.GroupBox ViewerList;

		// Token: 0x04000337 RID: 823
		private global::System.Windows.Forms.GroupBox groupBox69;

		// Token: 0x04000338 RID: 824
		private global::System.Windows.Forms.ComboBox cmbGroup;

		// Token: 0x04000339 RID: 825
		private global::System.Windows.Forms.RadioButton rdoViewDefect;

		// Token: 0x0400033A RID: 826
		private global::System.Windows.Forms.RadioButton rdoViewEngr;

		// Token: 0x0400033B RID: 827
		private global::System.Windows.Forms.RadioButton rdoViewWareHouse;

		// Token: 0x0400033C RID: 828
		private global::System.Windows.Forms.GroupBox groupBox70;

		// Token: 0x0400033D RID: 829
		private global::System.Windows.Forms.Panel pnlViewer;

		// Token: 0x0400033E RID: 830
		private global::System.Windows.Forms.TextBox cmbViewerBarcode;

		// Token: 0x0400033F RID: 831
		private global::System.Windows.Forms.ComboBox cmbSelectStatus2;

		// Token: 0x04000340 RID: 832
		private global::System.Windows.Forms.Label label35;

		// Token: 0x04000341 RID: 833
		private global::System.Windows.Forms.Panel panel43;

		// Token: 0x04000342 RID: 834
		private global::System.Windows.Forms.Panel panel42;

		// Token: 0x04000343 RID: 835
		private global::System.Windows.Forms.Panel panel45;

		// Token: 0x04000344 RID: 836
		private global::System.Windows.Forms.Panel panel44;

		// Token: 0x04000345 RID: 837
		private global::System.Windows.Forms.TabPage tpATPList;

		// Token: 0x04000346 RID: 838
		private global::System.Windows.Forms.Panel panel47;

		// Token: 0x04000347 RID: 839
		private global::System.Windows.Forms.Panel panel48;

		// Token: 0x04000348 RID: 840
		private global::System.Windows.Forms.Panel panel46;

		// Token: 0x04000349 RID: 841
		private global::System.Windows.Forms.GroupBox groupBox71;

		// Token: 0x0400034A RID: 842
		private global::System.Windows.Forms.TextBox txtATPname;

		// Token: 0x0400034B RID: 843
		private global::System.Windows.Forms.TextBox txtATPhostname;

		// Token: 0x0400034C RID: 844
		private global::System.Windows.Forms.ComboBox cmbATPhostname;

		// Token: 0x0400034D RID: 845
		private global::System.Windows.Forms.ComboBox cmbATPname;

		// Token: 0x0400034E RID: 846
		private global::System.Windows.Forms.GroupBox groupBox76;

		// Token: 0x0400034F RID: 847
		private global::SourceGrid.Grid gridATPlist;

		// Token: 0x04000350 RID: 848
		private global::System.Windows.Forms.GroupBox groupBox75;

		// Token: 0x04000351 RID: 849
		private global::SourceGrid.Grid gridATPsummary;

		// Token: 0x04000352 RID: 850
		private global::System.Windows.Forms.GroupBox groupBox77;

		// Token: 0x04000353 RID: 851
		private global::System.Windows.Forms.PictureBox cmbATPexcel;

		// Token: 0x04000354 RID: 852
		private global::System.Windows.Forms.GroupBox groupBox74;

		// Token: 0x04000355 RID: 853
		private global::System.Windows.Forms.PictureBox cmbATPsearch;

		// Token: 0x04000356 RID: 854
		private global::System.Windows.Forms.GroupBox groupBox73;

		// Token: 0x04000357 RID: 855
		private global::System.Windows.Forms.DateTimePicker dptATPend;

		// Token: 0x04000358 RID: 856
		private global::System.Windows.Forms.DateTimePicker dptATPstart;

		// Token: 0x04000359 RID: 857
		private global::System.Windows.Forms.GroupBox groupBox72;

		// Token: 0x0400035A RID: 858
		private global::System.Windows.Forms.ComboBox cmbATPproduct;

		// Token: 0x0400035B RID: 859
		private global::System.Windows.Forms.GroupBox groupBox57;

		// Token: 0x0400035C RID: 860
		private global::System.Windows.Forms.GroupBox groupBox78;

		// Token: 0x0400035D RID: 861
		private global::System.Windows.Forms.ComboBox comboBox1;

		// Token: 0x0400035E RID: 862
		private global::System.Windows.Forms.GroupBox groupBox79;

		// Token: 0x0400035F RID: 863
		private global::System.Windows.Forms.RadioButton rdoATPTotalList;

		// Token: 0x04000360 RID: 864
		private global::System.Windows.Forms.RadioButton rdoATPDaily;

		// Token: 0x04000361 RID: 865
		private global::System.Windows.Forms.Panel pnlATPviewer;

		// Token: 0x04000362 RID: 866
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000363 RID: 867
		private global::System.Windows.Forms.PictureBox pictureBox5;

		// Token: 0x04000364 RID: 868
		private global::System.Windows.Forms.RadioButton rdoWRDetectCarrier;

		// Token: 0x04000365 RID: 869
		private global::System.Windows.Forms.TabPage tpCorrHistory;

		// Token: 0x04000366 RID: 870
		private global::System.Windows.Forms.Panel panel49;

		// Token: 0x04000367 RID: 871
		private global::System.Windows.Forms.GroupBox groupBox80;

		// Token: 0x04000368 RID: 872
		private global::System.Windows.Forms.Panel panel51;

		// Token: 0x04000369 RID: 873
		private global::System.Windows.Forms.GroupBox groupBox81;

		// Token: 0x0400036A RID: 874
		private global::System.Windows.Forms.GroupBox groupBox82;

		// Token: 0x0400036B RID: 875
		private global::System.Windows.Forms.Label label64;

		// Token: 0x0400036C RID: 876
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x0400036D RID: 877
		private global::System.Windows.Forms.DateTimePicker dateTimePicker1;

		// Token: 0x0400036E RID: 878
		private global::System.Windows.Forms.DateTimePicker dateTimePicker2;

		// Token: 0x0400036F RID: 879
		private global::System.Windows.Forms.GroupBox groupBox83;

		// Token: 0x04000370 RID: 880
		private global::System.Windows.Forms.GroupBox groupBox85;

		// Token: 0x04000371 RID: 881
		private global::System.Windows.Forms.PictureBox cmdAddCorrHistory;

		// Token: 0x04000372 RID: 882
		private global::System.Windows.Forms.GroupBox groupBox86;

		// Token: 0x04000373 RID: 883
		private global::System.Windows.Forms.PictureBox cmdCorrExcel;

		// Token: 0x04000374 RID: 884
		private global::System.Windows.Forms.GroupBox groupBox87;

		// Token: 0x04000375 RID: 885
		private global::System.Windows.Forms.PictureBox cmdCorrSearch;

		// Token: 0x04000376 RID: 886
		private global::System.Windows.Forms.GroupBox groupBox84;

		// Token: 0x04000377 RID: 887
		private global::System.Windows.Forms.ComboBox cmbProduct4;

		// Token: 0x04000378 RID: 888
		private global::Telerik.WinControls.UI.RadGridView gridCorrList;

		// Token: 0x04000379 RID: 889
		private global::System.Windows.Forms.TextBox txtCorrelationPart;

		// Token: 0x0400037A RID: 890
		private global::System.Windows.Forms.GroupBox groupBox88;

		// Token: 0x0400037B RID: 891
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x0400037C RID: 892
		private global::System.Windows.Forms.GroupBox groupBox90;

		// Token: 0x0400037D RID: 893
		private global::Telerik.WinControls.UI.RadGridView gridCorrHistory;

		// Token: 0x0400037E RID: 894
		private global::System.Windows.Forms.GroupBox groupBox89;

		// Token: 0x0400037F RID: 895
		private global::System.Windows.Forms.PictureBox cmdDelCorrHistory;
	}
}
