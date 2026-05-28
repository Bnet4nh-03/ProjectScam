namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000037 RID: 55
	public partial class AddCarrier : global::System.Windows.Forms.Form
	{
		// Token: 0x06000266 RID: 614 RVA: 0x0004333A File Offset: 0x0004153A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0004335C File Offset: 0x0004155C
		private void InitializeComponent()
		{
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.grpCarrierInfo = new global::System.Windows.Forms.GroupBox();
			this.txtMCN = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.cmbLoadTester = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cmbOpCode = new global::System.Windows.Forms.ComboBox();
			this.cmbDevice = new global::System.Windows.Forms.ComboBox();
			this.txtDevice = new global::System.Windows.Forms.TextBox();
			this.grpUpload = new global::System.Windows.Forms.GroupBox();
			this.cmdUpload = new global::System.Windows.Forms.PictureBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.grpFormat = new global::System.Windows.Forms.GroupBox();
			this.cmdDownLoad = new global::System.Windows.Forms.PictureBox();
			this.txtRevision = new global::System.Windows.Forms.TextBox();
			this.txtBarcode = new global::System.Windows.Forms.TextBox();
			this.cmbTester = new global::System.Windows.Forms.ComboBox();
			this.cmbCorrelation = new global::System.Windows.Forms.ComboBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.txtTouchDownCnt = new global::System.Windows.Forms.TextBox();
			this.cmbStatus = new global::System.Windows.Forms.ComboBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.cmbSite = new global::System.Windows.Forms.ComboBox();
			this.cmbCustomer = new global::System.Windows.Forms.ComboBox();
			this.cmbCarrierType = new global::System.Windows.Forms.ComboBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.txtCarrierNo = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.txtPkgType = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtCleanCnt = new global::System.Windows.Forms.TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.txtMemo = new global::System.Windows.Forms.TextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.txtLimitRepairCnt = new global::System.Windows.Forms.TextBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.txtLimitCleanCnt = new global::System.Windows.Forms.TextBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.txtRepairCnt = new global::System.Windows.Forms.TextBox();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.cmdModify = new global::System.Windows.Forms.PictureBox();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label21 = new global::System.Windows.Forms.Label();
			this.label22 = new global::System.Windows.Forms.Label();
			this.label23 = new global::System.Windows.Forms.Label();
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.l_copyright = new global::System.Windows.Forms.Label();
			this.splitter10 = new global::System.Windows.Forms.Splitter();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.panel3.SuspendLayout();
			this.grpCarrierInfo.SuspendLayout();
			this.grpUpload.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUpload).BeginInit();
			this.grpFormat.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDownLoad).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModify).BeginInit();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			base.SuspendLayout();
			this.panel3.Controls.Add(this.grpCarrierInfo);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 44);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new global::System.Windows.Forms.Padding(5, 0, 5, 0);
			this.panel3.Size = new global::System.Drawing.Size(647, 484);
			this.panel3.TabIndex = 5;
			this.grpCarrierInfo.Controls.Add(this.txtMCN);
			this.grpCarrierInfo.Controls.Add(this.label7);
			this.grpCarrierInfo.Controls.Add(this.cmbLoadTester);
			this.grpCarrierInfo.Controls.Add(this.label5);
			this.grpCarrierInfo.Controls.Add(this.cmbOpCode);
			this.grpCarrierInfo.Controls.Add(this.cmbDevice);
			this.grpCarrierInfo.Controls.Add(this.txtDevice);
			this.grpCarrierInfo.Controls.Add(this.grpUpload);
			this.grpCarrierInfo.Controls.Add(this.label13);
			this.grpCarrierInfo.Controls.Add(this.grpFormat);
			this.grpCarrierInfo.Controls.Add(this.txtRevision);
			this.grpCarrierInfo.Controls.Add(this.txtBarcode);
			this.grpCarrierInfo.Controls.Add(this.cmbTester);
			this.grpCarrierInfo.Controls.Add(this.cmbCorrelation);
			this.grpCarrierInfo.Controls.Add(this.label12);
			this.grpCarrierInfo.Controls.Add(this.label11);
			this.grpCarrierInfo.Controls.Add(this.txtTouchDownCnt);
			this.grpCarrierInfo.Controls.Add(this.cmbStatus);
			this.grpCarrierInfo.Controls.Add(this.label10);
			this.grpCarrierInfo.Controls.Add(this.cmbSite);
			this.grpCarrierInfo.Controls.Add(this.cmbCustomer);
			this.grpCarrierInfo.Controls.Add(this.cmbCarrierType);
			this.grpCarrierInfo.Controls.Add(this.label8);
			this.grpCarrierInfo.Controls.Add(this.txtCarrierNo);
			this.grpCarrierInfo.Controls.Add(this.label6);
			this.grpCarrierInfo.Controls.Add(this.label4);
			this.grpCarrierInfo.Controls.Add(this.txtPkgType);
			this.grpCarrierInfo.Controls.Add(this.label3);
			this.grpCarrierInfo.Controls.Add(this.label2);
			this.grpCarrierInfo.Controls.Add(this.label1);
			this.grpCarrierInfo.Controls.Add(this.txtCleanCnt);
			this.grpCarrierInfo.Controls.Add(this.label16);
			this.grpCarrierInfo.Controls.Add(this.txtMemo);
			this.grpCarrierInfo.Controls.Add(this.label14);
			this.grpCarrierInfo.Controls.Add(this.txtLimitRepairCnt);
			this.grpCarrierInfo.Controls.Add(this.label17);
			this.grpCarrierInfo.Controls.Add(this.txtLimitCleanCnt);
			this.grpCarrierInfo.Controls.Add(this.label18);
			this.grpCarrierInfo.Controls.Add(this.txtRepairCnt);
			this.grpCarrierInfo.Controls.Add(this.cmdClose);
			this.grpCarrierInfo.Controls.Add(this.cmdModify);
			this.grpCarrierInfo.Controls.Add(this.label20);
			this.grpCarrierInfo.Controls.Add(this.label21);
			this.grpCarrierInfo.Controls.Add(this.label22);
			this.grpCarrierInfo.Controls.Add(this.label23);
			this.grpCarrierInfo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grpCarrierInfo.Location = new global::System.Drawing.Point(5, 0);
			this.grpCarrierInfo.Name = "grpCarrierInfo";
			this.grpCarrierInfo.Size = new global::System.Drawing.Size(637, 484);
			this.grpCarrierInfo.TabIndex = 41;
			this.grpCarrierInfo.TabStop = false;
			this.grpCarrierInfo.Text = "Carrier Info";
			this.txtMCN.Location = new global::System.Drawing.Point(68, 301);
			this.txtMCN.Name = "txtMCN";
			this.txtMCN.Size = new global::System.Drawing.Size(235, 23);
			this.txtMCN.TabIndex = 112;
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(9, 304);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(42, 15);
			this.label7.TabIndex = 111;
			this.label7.Text = "MCN#";
			this.label7.Click += new global::System.EventHandler(this.label7_Click);
			this.cmbLoadTester.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbLoadTester.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLoadTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbLoadTester.FormattingEnabled = true;
			this.cmbLoadTester.Location = new global::System.Drawing.Point(479, 265);
			this.cmbLoadTester.Name = "cmbLoadTester";
			this.cmbLoadTester.Size = new global::System.Drawing.Size(149, 23);
			this.cmbLoadTester.TabIndex = 110;
			this.cmbLoadTester.DropDown += new global::System.EventHandler(this.cmbLoadTester_DropDown);
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(328, 268);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(66, 15);
			this.label5.TabIndex = 109;
			this.label5.Text = "Load Tester";
			this.cmbOpCode.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbOpCode.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOpCode.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbOpCode.FormattingEnabled = true;
			this.cmbOpCode.Location = new global::System.Drawing.Point(68, 175);
			this.cmbOpCode.Name = "cmbOpCode";
			this.cmbOpCode.Size = new global::System.Drawing.Size(235, 23);
			this.cmbOpCode.TabIndex = 108;
			this.cmbOpCode.DropDown += new global::System.EventHandler(this.cmbOpCode_DropDown);
			this.cmbDevice.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbDevice.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDevice.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbDevice.FormattingEnabled = true;
			this.cmbDevice.Location = new global::System.Drawing.Point(68, 85);
			this.cmbDevice.Name = "cmbDevice";
			this.cmbDevice.Size = new global::System.Drawing.Size(235, 23);
			this.cmbDevice.TabIndex = 107;
			this.cmbDevice.DropDown += new global::System.EventHandler(this.cmbDevice_DropDown);
			this.txtDevice.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtDevice.Location = new global::System.Drawing.Point(246, 422);
			this.txtDevice.Multiline = true;
			this.txtDevice.Name = "txtDevice";
			this.txtDevice.ReadOnly = true;
			this.txtDevice.Size = new global::System.Drawing.Size(235, 47);
			this.txtDevice.TabIndex = 3;
			this.txtDevice.Text = "COMMENT : 현재 사용 않함";
			this.txtDevice.Visible = false;
			this.txtDevice.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.txtDevice_MouseDoubleClick);
			this.grpUpload.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.grpUpload.Controls.Add(this.cmdUpload);
			this.grpUpload.Location = new global::System.Drawing.Point(69, 419);
			this.grpUpload.Name = "grpUpload";
			this.grpUpload.Size = new global::System.Drawing.Size(59, 59);
			this.grpUpload.TabIndex = 106;
			this.grpUpload.TabStop = false;
			this.grpUpload.Text = "Upload";
			this.cmdUpload.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdUpload.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.OpenTable;
			this.cmdUpload.Location = new global::System.Drawing.Point(13, 18);
			this.cmdUpload.Name = "cmdUpload";
			this.cmdUpload.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUpload.TabIndex = 104;
			this.cmdUpload.TabStop = false;
			this.cmdUpload.Click += new global::System.EventHandler(this.cmdUpload_Click);
			this.cmdUpload.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdUpload_MouseDown);
			this.cmdUpload.MouseLeave += new global::System.EventHandler(this.cmdUpload_MouseLeave);
			this.cmdUpload.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdUpload_MouseMove);
			this.cmdUpload.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdUpload_MouseUp);
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(3, 268);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(51, 15);
			this.label13.TabIndex = 102;
			this.label13.Text = "Revision";
			this.grpFormat.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.grpFormat.Controls.Add(this.cmdDownLoad);
			this.grpFormat.Location = new global::System.Drawing.Point(4, 419);
			this.grpFormat.Name = "grpFormat";
			this.grpFormat.Size = new global::System.Drawing.Size(59, 59);
			this.grpFormat.TabIndex = 105;
			this.grpFormat.TabStop = false;
			this.grpFormat.Text = "Format";
			this.cmdDownLoad.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdDownLoad.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.SaveExcel;
			this.cmdDownLoad.Location = new global::System.Drawing.Point(13, 18);
			this.cmdDownLoad.Name = "cmdDownLoad";
			this.cmdDownLoad.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDownLoad.TabIndex = 103;
			this.cmdDownLoad.TabStop = false;
			this.cmdDownLoad.Click += new global::System.EventHandler(this.cmdDownLoad_Click);
			this.cmdDownLoad.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDownLoad_MouseDown);
			this.cmdDownLoad.MouseLeave += new global::System.EventHandler(this.cmdDownLoad_MouseLeave);
			this.cmdDownLoad.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDownLoad_MouseMove);
			this.cmdDownLoad.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDownLoad_MouseUp);
			this.txtRevision.Location = new global::System.Drawing.Point(68, 265);
			this.txtRevision.Name = "txtRevision";
			this.txtRevision.Size = new global::System.Drawing.Size(235, 23);
			this.txtRevision.TabIndex = 101;
			this.txtBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtBarcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtBarcode.Location = new global::System.Drawing.Point(68, 25);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new global::System.Drawing.Size(235, 23);
			this.txtBarcode.TabIndex = 1;
			this.cmbTester.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbTester.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTester.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbTester.FormattingEnabled = true;
			this.cmbTester.Location = new global::System.Drawing.Point(68, 205);
			this.cmbTester.Name = "cmbTester";
			this.cmbTester.Size = new global::System.Drawing.Size(236, 23);
			this.cmbTester.TabIndex = 54;
			this.cmbTester.DropDown += new global::System.EventHandler(this.cmbTester_DropDown);
			this.cmbCorrelation.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbCorrelation.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCorrelation.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbCorrelation.FormattingEnabled = true;
			this.cmbCorrelation.Location = new global::System.Drawing.Point(68, 235);
			this.cmbCorrelation.Name = "cmbCorrelation";
			this.cmbCorrelation.Size = new global::System.Drawing.Size(235, 23);
			this.cmbCorrelation.TabIndex = 53;
			this.cmbCorrelation.DropDown += new global::System.EventHandler(this.cmbCorrelation_DropDown);
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(3, 238);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(66, 15);
			this.label12.TabIndex = 52;
			this.label12.Text = "Correlation";
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(327, 238);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(109, 15);
			this.label11.TabIndex = 51;
			this.label11.Text = "Touch Down Count";
			this.txtTouchDownCnt.Location = new global::System.Drawing.Point(479, 235);
			this.txtTouchDownCnt.Name = "txtTouchDownCnt";
			this.txtTouchDownCnt.Size = new global::System.Drawing.Size(149, 23);
			this.txtTouchDownCnt.TabIndex = 50;
			this.cmbStatus.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbStatus.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatus.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbStatus.FormattingEnabled = true;
			this.cmbStatus.Location = new global::System.Drawing.Point(479, 55);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new global::System.Drawing.Size(149, 23);
			this.cmbStatus.TabIndex = 48;
			this.cmbStatus.DropDown += new global::System.EventHandler(this.cmbStatus_DropDown);
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(328, 58);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(77, 15);
			this.label10.TabIndex = 46;
			this.label10.Text = "Carrier Status";
			this.cmbSite.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbSite.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSite.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbSite.FormattingEnabled = true;
			this.cmbSite.Location = new global::System.Drawing.Point(479, 85);
			this.cmbSite.Name = "cmbSite";
			this.cmbSite.Size = new global::System.Drawing.Size(149, 23);
			this.cmbSite.TabIndex = 44;
			this.cmbSite.DropDown += new global::System.EventHandler(this.cmbSite_DropDown);
			this.cmbCustomer.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbCustomer.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCustomer.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbCustomer.FormattingEnabled = true;
			this.cmbCustomer.Location = new global::System.Drawing.Point(68, 115);
			this.cmbCustomer.Name = "cmbCustomer";
			this.cmbCustomer.Size = new global::System.Drawing.Size(235, 23);
			this.cmbCustomer.TabIndex = 43;
			this.cmbCustomer.DropDown += new global::System.EventHandler(this.cmbCustomer_DropDown);
			this.cmbCarrierType.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbCarrierType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCarrierType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbCarrierType.FormattingEnabled = true;
			this.cmbCarrierType.Location = new global::System.Drawing.Point(68, 145);
			this.cmbCarrierType.Name = "cmbCarrierType";
			this.cmbCarrierType.Size = new global::System.Drawing.Size(235, 23);
			this.cmbCarrierType.TabIndex = 42;
			this.cmbCarrierType.DropDown += new global::System.EventHandler(this.cmbCarrierType_DropDown);
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(328, 28);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(61, 15);
			this.label8.TabIndex = 40;
			this.label8.Text = "Carrier No";
			this.txtCarrierNo.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtCarrierNo.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtCarrierNo.Location = new global::System.Drawing.Point(479, 25);
			this.txtCarrierNo.Name = "txtCarrierNo";
			this.txtCarrierNo.Size = new global::System.Drawing.Size(149, 23);
			this.txtCarrierNo.TabIndex = 2;
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(328, 88);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(26, 15);
			this.label6.TabIndex = 36;
			this.label6.Text = "Site";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(3, 58);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(54, 15);
			this.label4.TabIndex = 32;
			this.label4.Text = "Pkg Type";
			this.txtPkgType.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtPkgType.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtPkgType.Location = new global::System.Drawing.Point(68, 55);
			this.txtPkgType.Name = "txtPkgType";
			this.txtPkgType.Size = new global::System.Drawing.Size(235, 23);
			this.txtPkgType.TabIndex = 3;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(3, 208);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(37, 15);
			this.label3.TabIndex = 30;
			this.label3.Text = "Tester";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(3, 178);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(54, 15);
			this.label2.TabIndex = 28;
			this.label2.Text = "OP Code";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(328, 148);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(73, 15);
			this.label1.TabIndex = 26;
			this.label1.Text = "Clean Count";
			this.txtCleanCnt.Location = new global::System.Drawing.Point(479, 145);
			this.txtCleanCnt.Name = "txtCleanCnt";
			this.txtCleanCnt.Size = new global::System.Drawing.Size(149, 23);
			this.txtCleanCnt.TabIndex = 25;
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(6, 343);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(42, 15);
			this.label16.TabIndex = 22;
			this.label16.Text = "Memo";
			this.txtMemo.Location = new global::System.Drawing.Point(69, 343);
			this.txtMemo.Multiline = true;
			this.txtMemo.Name = "txtMemo";
			this.txtMemo.Size = new global::System.Drawing.Size(560, 73);
			this.txtMemo.TabIndex = 21;
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(327, 208);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(106, 15);
			this.label14.TabIndex = 18;
			this.label14.Text = "Limit Repair Count";
			this.txtLimitRepairCnt.Location = new global::System.Drawing.Point(479, 205);
			this.txtLimitRepairCnt.Name = "txtLimitRepairCnt";
			this.txtLimitRepairCnt.Size = new global::System.Drawing.Size(149, 23);
			this.txtLimitRepairCnt.TabIndex = 17;
			this.label17.AutoSize = true;
			this.label17.Location = new global::System.Drawing.Point(327, 178);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(103, 15);
			this.label17.TabIndex = 16;
			this.label17.Text = "Limit Clean Count";
			this.txtLimitCleanCnt.Location = new global::System.Drawing.Point(479, 175);
			this.txtLimitCleanCnt.Name = "txtLimitCleanCnt";
			this.txtLimitCleanCnt.Size = new global::System.Drawing.Size(149, 23);
			this.txtLimitCleanCnt.TabIndex = 15;
			this.label18.AutoSize = true;
			this.label18.Location = new global::System.Drawing.Point(328, 118);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(76, 15);
			this.label18.TabIndex = 14;
			this.label18.Text = "Repair Count";
			this.txtRepairCnt.Location = new global::System.Drawing.Point(479, 115);
			this.txtRepairCnt.Name = "txtRepairCnt";
			this.txtRepairCnt.Size = new global::System.Drawing.Size(149, 23);
			this.txtRepairCnt.TabIndex = 13;
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(589, 441);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 23;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			this.cmdModify.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdModify.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdModify.Location = new global::System.Drawing.Point(551, 441);
			this.cmdModify.Name = "cmdModify";
			this.cmdModify.Size = new global::System.Drawing.Size(32, 32);
			this.cmdModify.TabIndex = 22;
			this.cmdModify.TabStop = false;
			this.cmdModify.Click += new global::System.EventHandler(this.cmdModify_Click);
			this.cmdModify.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseDown);
			this.cmdModify.MouseLeave += new global::System.EventHandler(this.cmdModify_MouseLeave);
			this.cmdModify.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseMove);
			this.cmdModify.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdModify_MouseUp);
			this.label20.AutoSize = true;
			this.label20.Location = new global::System.Drawing.Point(3, 118);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(59, 15);
			this.label20.TabIndex = 10;
			this.label20.Text = "Customer";
			this.label21.AutoSize = true;
			this.label21.Location = new global::System.Drawing.Point(3, 148);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(31, 15);
			this.label21.TabIndex = 8;
			this.label21.Text = "Type";
			this.label22.AutoSize = true;
			this.label22.Location = new global::System.Drawing.Point(3, 88);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(42, 15);
			this.label22.TabIndex = 6;
			this.label22.Text = "Device";
			this.label23.AutoSize = true;
			this.label23.Location = new global::System.Drawing.Point(3, 28);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(50, 15);
			this.label23.TabIndex = 4;
			this.label23.Text = "Barcode";
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(647, 44);
			this.panel24.TabIndex = 17;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(73, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Carrier";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.l_copyright);
			this.panel25.Controls.Add(this.splitter10);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 528);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(647, 32);
			this.panel25.TabIndex = 23;
			this.l_copyright.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.l_copyright.AutoSize = true;
			this.l_copyright.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.l_copyright.Location = new global::System.Drawing.Point(199, 8);
			this.l_copyright.Name = "l_copyright";
			this.l_copyright.Size = new global::System.Drawing.Size(237, 15);
			this.l_copyright.TabIndex = 15;
			this.l_copyright.Text = "Copyright © 2015 Amkor Technology Korea";
			this.l_copyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.splitter10.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter10.Location = new global::System.Drawing.Point(0, 0);
			this.splitter10.Name = "splitter10";
			this.splitter10.Size = new global::System.Drawing.Size(647, 3);
			this.splitter10.TabIndex = 14;
			this.splitter10.TabStop = false;
			this.openFileDialog.FileName = "openFileDialog1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(647, 560);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "AddCarrier";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Carrier Information";
			base.Load += new global::System.EventHandler(this.ModifyItem_Load);
			this.panel3.ResumeLayout(false);
			this.grpCarrierInfo.ResumeLayout(false);
			this.grpCarrierInfo.PerformLayout();
			this.grpUpload.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdUpload).EndInit();
			this.grpFormat.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdDownLoad).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdModify).EndInit();
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000423 RID: 1059
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000424 RID: 1060
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000425 RID: 1061
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000426 RID: 1062
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x04000427 RID: 1063
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000428 RID: 1064
		private global::System.Windows.Forms.Label l_copyright;

		// Token: 0x04000429 RID: 1065
		private global::System.Windows.Forms.Splitter splitter10;

		// Token: 0x0400042A RID: 1066
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x0400042B RID: 1067
		private global::System.Windows.Forms.PictureBox cmdModify;

		// Token: 0x0400042C RID: 1068
		private global::System.Windows.Forms.GroupBox grpCarrierInfo;

		// Token: 0x0400042D RID: 1069
		private global::System.Windows.Forms.Label label16;

		// Token: 0x0400042E RID: 1070
		private global::System.Windows.Forms.TextBox txtMemo;

		// Token: 0x0400042F RID: 1071
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000430 RID: 1072
		private global::System.Windows.Forms.TextBox txtLimitRepairCnt;

		// Token: 0x04000431 RID: 1073
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000432 RID: 1074
		private global::System.Windows.Forms.TextBox txtLimitCleanCnt;

		// Token: 0x04000433 RID: 1075
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04000434 RID: 1076
		private global::System.Windows.Forms.TextBox txtRepairCnt;

		// Token: 0x04000435 RID: 1077
		private global::System.Windows.Forms.Label label20;

		// Token: 0x04000436 RID: 1078
		private global::System.Windows.Forms.Label label21;

		// Token: 0x04000437 RID: 1079
		private global::System.Windows.Forms.Label label22;

		// Token: 0x04000438 RID: 1080
		private global::System.Windows.Forms.TextBox txtDevice;

		// Token: 0x04000439 RID: 1081
		private global::System.Windows.Forms.Label label23;

		// Token: 0x0400043A RID: 1082
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400043B RID: 1083
		private global::System.Windows.Forms.TextBox txtCleanCnt;

		// Token: 0x0400043C RID: 1084
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400043D RID: 1085
		private global::System.Windows.Forms.TextBox txtCarrierNo;

		// Token: 0x0400043E RID: 1086
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400043F RID: 1087
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000440 RID: 1088
		private global::System.Windows.Forms.TextBox txtPkgType;

		// Token: 0x04000441 RID: 1089
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000442 RID: 1090
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000443 RID: 1091
		private global::System.Windows.Forms.ComboBox cmbSite;

		// Token: 0x04000444 RID: 1092
		private global::System.Windows.Forms.ComboBox cmbCustomer;

		// Token: 0x04000445 RID: 1093
		private global::System.Windows.Forms.ComboBox cmbCarrierType;

		// Token: 0x04000446 RID: 1094
		private global::System.Windows.Forms.ComboBox cmbStatus;

		// Token: 0x04000447 RID: 1095
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000448 RID: 1096
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000449 RID: 1097
		private global::System.Windows.Forms.TextBox txtTouchDownCnt;

		// Token: 0x0400044A RID: 1098
		private global::System.Windows.Forms.ComboBox cmbCorrelation;

		// Token: 0x0400044B RID: 1099
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400044C RID: 1100
		private global::System.Windows.Forms.ComboBox cmbTester;

		// Token: 0x0400044D RID: 1101
		private global::System.Windows.Forms.TextBox txtBarcode;

		// Token: 0x0400044E RID: 1102
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400044F RID: 1103
		private global::System.Windows.Forms.TextBox txtRevision;

		// Token: 0x04000450 RID: 1104
		private global::System.Windows.Forms.GroupBox grpUpload;

		// Token: 0x04000451 RID: 1105
		private global::System.Windows.Forms.GroupBox grpFormat;

		// Token: 0x04000452 RID: 1106
		private global::System.Windows.Forms.PictureBox cmdDownLoad;

		// Token: 0x04000453 RID: 1107
		private global::System.Windows.Forms.PictureBox cmdUpload;

		// Token: 0x04000454 RID: 1108
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x04000455 RID: 1109
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x04000456 RID: 1110
		private global::System.Windows.Forms.ComboBox cmbDevice;

		// Token: 0x04000457 RID: 1111
		private global::System.Windows.Forms.ComboBox cmbOpCode;

		// Token: 0x04000458 RID: 1112
		private global::System.Windows.Forms.ComboBox cmbLoadTester;

		// Token: 0x04000459 RID: 1113
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400045A RID: 1114
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400045B RID: 1115
		private global::System.Windows.Forms.TextBox txtMCN;
	}
}
