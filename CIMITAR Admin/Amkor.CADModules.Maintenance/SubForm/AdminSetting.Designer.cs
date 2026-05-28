namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000B RID: 11
	public partial class AdminSetting : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x000161A4 File Offset: 0x000143A4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000161DC File Offset: 0x000143DC
		private void InitializeComponent()
		{
			this.tcMenu = new global::System.Windows.Forms.TabControl();
			this.tpRegister = new global::System.Windows.Forms.TabPage();
			this.gbModel = new global::System.Windows.Forms.GroupBox();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.tbModelName = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.cbModelCategory = new global::System.Windows.Forms.ComboBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.cbModelPlant = new global::System.Windows.Forms.ComboBox();
			this.btnModelDelete = new global::System.Windows.Forms.Button();
			this.btnAddModel = new global::System.Windows.Forms.Button();
			this.label8 = new global::System.Windows.Forms.Label();
			this.tvModel = new global::System.Windows.Forms.TreeView();
			this.gbRscDec = new global::System.Windows.Forms.GroupBox();
			this.panel12 = new global::System.Windows.Forms.Panel();
			this.groupBox10 = new global::System.Windows.Forms.GroupBox();
			this.tbRscName = new global::System.Windows.Forms.TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.cbRscCategory = new global::System.Windows.Forms.ComboBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.cbRscPlant = new global::System.Windows.Forms.ComboBox();
			this.btnRscDelete = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.label13 = new global::System.Windows.Forms.Label();
			this.tvRscDec = new global::System.Windows.Forms.TreeView();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label6 = new global::System.Windows.Forms.Label();
			this.cbContents = new global::System.Windows.Forms.ComboBox();
			this.tpMachine = new global::System.Windows.Forms.TabPage();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.grid_Machine = new global::SourceGrid.Grid();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.cbPlantMachine = new global::System.Windows.Forms.ComboBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.btnMachineRemove = new global::System.Windows.Forms.Button();
			this.btnRegisterMachine = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.tbNameMachine = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.cbModelMachine = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cbCategoryMachine = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cbRscMachine = new global::System.Windows.Forms.ComboBox();
			this.tpMail = new global::System.Windows.Forms.TabPage();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.pnCCList = new global::System.Windows.Forms.Panel();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.groupBox12 = new global::System.Windows.Forms.GroupBox();
			this.cbMailList = new global::System.Windows.Forms.ComboBox();
			this.label23 = new global::System.Windows.Forms.Label();
			this.cbCCCategory = new global::System.Windows.Forms.ComboBox();
			this.label22 = new global::System.Windows.Forms.Label();
			this.cbCCMailTeam = new global::System.Windows.Forms.ComboBox();
			this.label21 = new global::System.Windows.Forms.Label();
			this.cbCCPlant = new global::System.Windows.Forms.ComboBox();
			this.btnCCDel = new global::System.Windows.Forms.Button();
			this.btnCCAdd = new global::System.Windows.Forms.Button();
			this.label20 = new global::System.Windows.Forms.Label();
			this.tvCCMail = new global::System.Windows.Forms.TreeView();
			this.pnToList = new global::System.Windows.Forms.Panel();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.groupBox9 = new global::System.Windows.Forms.GroupBox();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.comboBox2 = new global::System.Windows.Forms.ComboBox();
			this.comboBox3 = new global::System.Windows.Forms.ComboBox();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.cbMailList2 = new global::System.Windows.Forms.ComboBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.cbGroupMail = new global::System.Windows.Forms.ComboBox();
			this.label15 = new global::System.Windows.Forms.Label();
			this.cbToPlant = new global::System.Windows.Forms.ComboBox();
			this.btnGroupMainDelete = new global::System.Windows.Forms.Button();
			this.btnGroupMail = new global::System.Windows.Forms.Button();
			this.label14 = new global::System.Windows.Forms.Label();
			this.tvToMailNode = new global::System.Windows.Forms.TreeView();
			this.pnMailList = new global::System.Windows.Forms.Panel();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.groupBox11 = new global::System.Windows.Forms.GroupBox();
			this.tbMailModify = new global::System.Windows.Forms.TextBox();
			this.label19 = new global::System.Windows.Forms.Label();
			this.btnModify = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.tb_mail = new global::System.Windows.Forms.TextBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.cbMailPlant = new global::System.Windows.Forms.ComboBox();
			this.btnDelMail = new global::System.Windows.Forms.Button();
			this.btnAddMail = new global::System.Windows.Forms.Button();
			this.label17 = new global::System.Windows.Forms.Label();
			this.tv_MailList = new global::System.Windows.Forms.TreeView();
			this.groupBox13 = new global::System.Windows.Forms.GroupBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.cbMailContents = new global::System.Windows.Forms.ComboBox();
			this.tabpage_team = new global::System.Windows.Forms.TabPage();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.cbMailList3 = new global::System.Windows.Forms.ComboBox();
			this.label28 = new global::System.Windows.Forms.Label();
			this.cbTeamlist = new global::System.Windows.Forms.ComboBox();
			this.label27 = new global::System.Windows.Forms.Label();
			this.cbTeamPlant2 = new global::System.Windows.Forms.ComboBox();
			this.label26 = new global::System.Windows.Forms.Label();
			this.cb_MailDelete = new global::System.Windows.Forms.CheckBox();
			this.btn_TeamDelMail = new global::System.Windows.Forms.Button();
			this.btn_TeamAddMail = new global::System.Windows.Forms.Button();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.tb_team = new global::System.Windows.Forms.TextBox();
			this.label25 = new global::System.Windows.Forms.Label();
			this.cbTeamPlant = new global::System.Windows.Forms.ComboBox();
			this.label24 = new global::System.Windows.Forms.Label();
			this.btn_delTeam = new global::System.Windows.Forms.Button();
			this.btn_addTeam = new global::System.Windows.Forms.Button();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.tv_TeamList = new global::System.Windows.Forms.TreeView();
			this.tp_factor = new global::System.Windows.Forms.TabPage();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.panel27 = new global::System.Windows.Forms.Panel();
			this.panel26 = new global::System.Windows.Forms.Panel();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.tbFactor = new global::System.Windows.Forms.TextBox();
			this.label32 = new global::System.Windows.Forms.Label();
			this.cbFactorCase = new global::System.Windows.Forms.ComboBox();
			this.label31 = new global::System.Windows.Forms.Label();
			this.cbFactorCategory = new global::System.Windows.Forms.ComboBox();
			this.label30 = new global::System.Windows.Forms.Label();
			this.cbPlant = new global::System.Windows.Forms.ComboBox();
			this.label29 = new global::System.Windows.Forms.Label();
			this.btnFactorDel = new global::System.Windows.Forms.Button();
			this.btnFactorAdd = new global::System.Windows.Forms.Button();
			this.panel28 = new global::System.Windows.Forms.Panel();
			this.groupBox15 = new global::System.Windows.Forms.GroupBox();
			this.cbFactorSystem = new global::System.Windows.Forms.ComboBox();
			this.label41 = new global::System.Windows.Forms.Label();
			this.tvFactorList = new global::System.Windows.Forms.TreeView();
			this.tpVendor = new global::System.Windows.Forms.TabPage();
			this.panel14 = new global::System.Windows.Forms.Panel();
			this.groupBox14 = new global::System.Windows.Forms.GroupBox();
			this.tbVendor = new global::System.Windows.Forms.TextBox();
			this.label33 = new global::System.Windows.Forms.Label();
			this.cbVendorFactory = new global::System.Windows.Forms.ComboBox();
			this.label36 = new global::System.Windows.Forms.Label();
			this.btnDelVendor = new global::System.Windows.Forms.Button();
			this.btnAddVendor = new global::System.Windows.Forms.Button();
			this.tvVendor = new global::System.Windows.Forms.TreeView();
			this.tpAsset = new global::System.Windows.Forms.TabPage();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.grid_Asset = new global::SourceGrid.Grid();
			this.panel16 = new global::System.Windows.Forms.Panel();
			this.btnDeleteAsset = new global::System.Windows.Forms.Button();
			this.label37 = new global::System.Windows.Forms.Label();
			this.tbAsset = new global::System.Windows.Forms.TextBox();
			this.cbAssetFactory = new global::System.Windows.Forms.ComboBox();
			this.label34 = new global::System.Windows.Forms.Label();
			this.label35 = new global::System.Windows.Forms.Label();
			this.btnImport = new global::System.Windows.Forms.Button();
			this.btnAssetSearch = new global::System.Windows.Forms.Button();
			this.tbAssetEquipment = new global::System.Windows.Forms.TextBox();
			this.tpConfirmation = new global::System.Windows.Forms.TabPage();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.btnApply = new global::System.Windows.Forms.Button();
			this.panel23 = new global::System.Windows.Forms.Panel();
			this.tbContent = new global::System.Windows.Forms.TextBox();
			this.btModify = new global::System.Windows.Forms.Button();
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.label40 = new global::System.Windows.Forms.Label();
			this.panel21 = new global::System.Windows.Forms.Panel();
			this.cbConfirmType = new global::System.Windows.Forms.ComboBox();
			this.panel22 = new global::System.Windows.Forms.Panel();
			this.label39 = new global::System.Windows.Forms.Label();
			this.panel19 = new global::System.Windows.Forms.Panel();
			this.cbConfirmFactory = new global::System.Windows.Forms.ComboBox();
			this.panel20 = new global::System.Windows.Forms.Panel();
			this.label38 = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.btnDown = new global::System.Windows.Forms.Button();
			this.btnUp = new global::System.Windows.Forms.Button();
			this.panel17 = new global::System.Windows.Forms.Panel();
			this.cbListBox = new global::System.Windows.Forms.CheckedListBox();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.tcMenu.SuspendLayout();
			this.tpRegister.SuspendLayout();
			this.gbModel.SuspendLayout();
			this.panel13.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.gbRscDec.SuspendLayout();
			this.panel12.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tpMachine.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tpMail.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.pnCCList.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.pnToList.SuspendLayout();
			this.panel9.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.pnMailList.SuspendLayout();
			this.panel10.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabpage_team.SuspendLayout();
			this.panel7.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.tp_factor.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel27.SuspendLayout();
			this.panel26.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.panel28.SuspendLayout();
			this.groupBox15.SuspendLayout();
			this.tpVendor.SuspendLayout();
			this.panel14.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.tpAsset.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel16.SuspendLayout();
			this.tpConfirmation.SuspendLayout();
			this.panel18.SuspendLayout();
			this.panel23.SuspendLayout();
			this.panel24.SuspendLayout();
			this.panel21.SuspendLayout();
			this.panel22.SuspendLayout();
			this.panel19.SuspendLayout();
			this.panel20.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel17.SuspendLayout();
			base.SuspendLayout();
			this.tcMenu.Controls.Add(this.tpRegister);
			this.tcMenu.Controls.Add(this.tpMachine);
			this.tcMenu.Controls.Add(this.tpMail);
			this.tcMenu.Controls.Add(this.tabpage_team);
			this.tcMenu.Controls.Add(this.tp_factor);
			this.tcMenu.Controls.Add(this.tpVendor);
			this.tcMenu.Controls.Add(this.tpAsset);
			this.tcMenu.Controls.Add(this.tpConfirmation);
			this.tcMenu.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tcMenu.Location = new global::System.Drawing.Point(0, 0);
			this.tcMenu.Name = "tcMenu";
			this.tcMenu.SelectedIndex = 0;
			this.tcMenu.Size = new global::System.Drawing.Size(1365, 602);
			this.tcMenu.TabIndex = 5;
			this.tcMenu.SelectedIndexChanged += new global::System.EventHandler(this.tcMenu_SelectedIndexChanged);
			this.tpRegister.Controls.Add(this.gbModel);
			this.tpRegister.Controls.Add(this.gbRscDec);
			this.tpRegister.Controls.Add(this.groupBox3);
			this.tpRegister.Location = new global::System.Drawing.Point(4, 22);
			this.tpRegister.Name = "tpRegister";
			this.tpRegister.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpRegister.Size = new global::System.Drawing.Size(1357, 576);
			this.tpRegister.TabIndex = 0;
			this.tpRegister.Text = "Register Model & Rsc";
			this.tpRegister.UseVisualStyleBackColor = true;
			this.gbModel.Controls.Add(this.panel13);
			this.gbModel.Controls.Add(this.tvModel);
			this.gbModel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gbModel.Location = new global::System.Drawing.Point(225, 3);
			this.gbModel.Name = "gbModel";
			this.gbModel.Size = new global::System.Drawing.Size(1129, 570);
			this.gbModel.TabIndex = 7;
			this.gbModel.TabStop = false;
			this.gbModel.Text = "Register Model";
			this.panel13.Controls.Add(this.groupBox8);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel13.Location = new global::System.Drawing.Point(353, 17);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new global::System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panel13.Size = new global::System.Drawing.Size(243, 550);
			this.panel13.TabIndex = 7;
			this.groupBox8.Controls.Add(this.tbModelName);
			this.groupBox8.Controls.Add(this.label10);
			this.groupBox8.Controls.Add(this.cbModelCategory);
			this.groupBox8.Controls.Add(this.label9);
			this.groupBox8.Controls.Add(this.cbModelPlant);
			this.groupBox8.Controls.Add(this.btnModelDelete);
			this.groupBox8.Controls.Add(this.btnAddModel);
			this.groupBox8.Controls.Add(this.label8);
			this.groupBox8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox8.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(237, 178);
			this.groupBox8.TabIndex = 5;
			this.groupBox8.TabStop = false;
			this.tbModelName.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tbModelName.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbModelName.Location = new global::System.Drawing.Point(3, 116);
			this.tbModelName.Name = "tbModelName";
			this.tbModelName.Size = new global::System.Drawing.Size(231, 21);
			this.tbModelName.TabIndex = 3;
			this.label10.AutoSize = true;
			this.label10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label10.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label10.Location = new global::System.Drawing.Point(3, 99);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(46, 17);
			this.label10.TabIndex = 28;
			this.label10.Text = "Model";
			this.cbModelCategory.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbModelCategory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModelCategory.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbModelCategory.Items.AddRange(new object[]
			{
				"TEST"
			});
			this.cbModelCategory.Location = new global::System.Drawing.Point(3, 75);
			this.cbModelCategory.Name = "cbModelCategory";
			this.cbModelCategory.Size = new global::System.Drawing.Size(231, 24);
			this.cbModelCategory.TabIndex = 24;
			this.label9.AutoSize = true;
			this.label9.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label9.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label9.Location = new global::System.Drawing.Point(3, 58);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(61, 17);
			this.label9.TabIndex = 27;
			this.label9.Text = "Category";
			this.cbModelPlant.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbModelPlant.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModelPlant.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbModelPlant.Items.AddRange(new object[]
			{
				"TEST"
			});
			this.cbModelPlant.Location = new global::System.Drawing.Point(3, 34);
			this.cbModelPlant.Name = "cbModelPlant";
			this.cbModelPlant.Size = new global::System.Drawing.Size(231, 24);
			this.cbModelPlant.TabIndex = 25;
			this.cbModelPlant.SelectedValueChanged += new global::System.EventHandler(this.Plant_SelectedValueChanged);
			this.btnModelDelete.Location = new global::System.Drawing.Point(159, 144);
			this.btnModelDelete.Name = "btnModelDelete";
			this.btnModelDelete.Size = new global::System.Drawing.Size(75, 23);
			this.btnModelDelete.TabIndex = 10;
			this.btnModelDelete.Text = "Del";
			this.btnModelDelete.UseVisualStyleBackColor = true;
			this.btnModelDelete.Click += new global::System.EventHandler(this.btnModelDelete_Click);
			this.btnAddModel.Location = new global::System.Drawing.Point(81, 144);
			this.btnAddModel.Name = "btnAddModel";
			this.btnAddModel.Size = new global::System.Drawing.Size(75, 23);
			this.btnAddModel.TabIndex = 4;
			this.btnAddModel.Text = "Add";
			this.btnAddModel.UseVisualStyleBackColor = true;
			this.btnAddModel.Click += new global::System.EventHandler(this.btnAddModel_Click);
			this.label8.AutoSize = true;
			this.label8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label8.Location = new global::System.Drawing.Point(3, 17);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(50, 17);
			this.label8.TabIndex = 26;
			this.label8.Text = "Factory";
			this.tvModel.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tvModel.Location = new global::System.Drawing.Point(3, 17);
			this.tvModel.Name = "tvModel";
			this.tvModel.Size = new global::System.Drawing.Size(350, 550);
			this.tvModel.TabIndex = 6;
			this.gbRscDec.Controls.Add(this.panel12);
			this.gbRscDec.Controls.Add(this.tvRscDec);
			this.gbRscDec.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gbRscDec.Location = new global::System.Drawing.Point(225, 3);
			this.gbRscDec.Name = "gbRscDec";
			this.gbRscDec.Size = new global::System.Drawing.Size(1129, 570);
			this.gbRscDec.TabIndex = 5;
			this.gbRscDec.TabStop = false;
			this.gbRscDec.Text = "Register Rsc Dec";
			this.panel12.Controls.Add(this.groupBox10);
			this.panel12.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel12.Location = new global::System.Drawing.Point(353, 17);
			this.panel12.Name = "panel12";
			this.panel12.Padding = new global::System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panel12.Size = new global::System.Drawing.Size(245, 550);
			this.panel12.TabIndex = 7;
			this.groupBox10.Controls.Add(this.tbRscName);
			this.groupBox10.Controls.Add(this.label11);
			this.groupBox10.Controls.Add(this.cbRscCategory);
			this.groupBox10.Controls.Add(this.label12);
			this.groupBox10.Controls.Add(this.cbRscPlant);
			this.groupBox10.Controls.Add(this.btnRscDelete);
			this.groupBox10.Controls.Add(this.button2);
			this.groupBox10.Controls.Add(this.label13);
			this.groupBox10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox10.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new global::System.Drawing.Size(239, 167);
			this.groupBox10.TabIndex = 5;
			this.groupBox10.TabStop = false;
			this.tbRscName.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tbRscName.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbRscName.Location = new global::System.Drawing.Point(3, 116);
			this.tbRscName.Name = "tbRscName";
			this.tbRscName.Size = new global::System.Drawing.Size(233, 21);
			this.tbRscName.TabIndex = 3;
			this.label11.AutoSize = true;
			this.label11.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label11.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label11.Location = new global::System.Drawing.Point(3, 99);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(36, 17);
			this.label11.TabIndex = 31;
			this.label11.Text = "Type";
			this.cbRscCategory.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbRscCategory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRscCategory.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbRscCategory.Items.AddRange(new object[]
			{
				"TEST"
			});
			this.cbRscCategory.Location = new global::System.Drawing.Point(3, 75);
			this.cbRscCategory.Name = "cbRscCategory";
			this.cbRscCategory.Size = new global::System.Drawing.Size(233, 24);
			this.cbRscCategory.TabIndex = 23;
			this.label12.AutoSize = true;
			this.label12.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label12.Location = new global::System.Drawing.Point(3, 58);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(61, 17);
			this.label12.TabIndex = 30;
			this.label12.Text = "Category";
			this.cbRscPlant.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbRscPlant.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRscPlant.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbRscPlant.Items.AddRange(new object[]
			{
				"TEST"
			});
			this.cbRscPlant.Location = new global::System.Drawing.Point(3, 34);
			this.cbRscPlant.Name = "cbRscPlant";
			this.cbRscPlant.Size = new global::System.Drawing.Size(233, 24);
			this.cbRscPlant.TabIndex = 24;
			this.cbRscPlant.SelectedValueChanged += new global::System.EventHandler(this.Plant_SelectedValueChanged);
			this.btnRscDelete.Location = new global::System.Drawing.Point(158, 144);
			this.btnRscDelete.Name = "btnRscDelete";
			this.btnRscDelete.Size = new global::System.Drawing.Size(75, 23);
			this.btnRscDelete.TabIndex = 10;
			this.btnRscDelete.Text = "Del";
			this.btnRscDelete.UseVisualStyleBackColor = true;
			this.btnRscDelete.Click += new global::System.EventHandler(this.btnRscDelete_Click);
			this.button2.Location = new global::System.Drawing.Point(80, 144);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Add";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.btnAppend_Click);
			this.label13.AutoSize = true;
			this.label13.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label13.Location = new global::System.Drawing.Point(3, 17);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(36, 17);
			this.label13.TabIndex = 29;
			this.label13.Text = "Plant";
			this.tvRscDec.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tvRscDec.Location = new global::System.Drawing.Point(3, 17);
			this.tvRscDec.Name = "tvRscDec";
			this.tvRscDec.Size = new global::System.Drawing.Size(350, 550);
			this.tvRscDec.TabIndex = 6;
			this.groupBox3.Controls.Add(this.panel4);
			this.groupBox3.Controls.Add(this.cbContents);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox3.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(222, 570);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.panel4.BackColor = global::System.Drawing.Color.Green;
			this.panel4.Controls.Add(this.label6);
			this.panel4.Location = new global::System.Drawing.Point(9, 13);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(201, 26);
			this.panel4.TabIndex = 12;
			this.label6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(0, 0);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(201, 26);
			this.label6.TabIndex = 0;
			this.label6.Text = "Contents";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.cbContents.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbContents.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbContents.FormattingEnabled = true;
			this.cbContents.Items.AddRange(new object[]
			{
				"Model",
				"Rsc Dec"
			});
			this.cbContents.Location = new global::System.Drawing.Point(9, 41);
			this.cbContents.Name = "cbContents";
			this.cbContents.Size = new global::System.Drawing.Size(201, 28);
			this.cbContents.TabIndex = 8;
			this.cbContents.SelectedIndexChanged += new global::System.EventHandler(this.cbContents_SelectedIndexChanged);
			this.tpMachine.Controls.Add(this.panel2);
			this.tpMachine.Controls.Add(this.panel1);
			this.tpMachine.Location = new global::System.Drawing.Point(4, 22);
			this.tpMachine.Name = "tpMachine";
			this.tpMachine.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpMachine.Size = new global::System.Drawing.Size(1357, 576);
			this.tpMachine.TabIndex = 1;
			this.tpMachine.Text = "Register Machine & List";
			this.tpMachine.UseVisualStyleBackColor = true;
			this.panel2.Controls.Add(this.grid_Machine);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(3, 48);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1351, 525);
			this.panel2.TabIndex = 0;
			this.grid_Machine.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_Machine.EnableSort = true;
			this.grid_Machine.FixedColumns = 1;
			this.grid_Machine.FixedRows = 1;
			this.grid_Machine.Font = new global::System.Drawing.Font("굴림체", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.grid_Machine.Location = new global::System.Drawing.Point(0, 0);
			this.grid_Machine.Name = "grid_Machine";
			this.grid_Machine.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_Machine.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_Machine.Size = new global::System.Drawing.Size(1351, 525);
			this.grid_Machine.TabIndex = 19;
			this.grid_Machine.TabStop = true;
			this.grid_Machine.ToolTipText = "";
			this.panel1.Controls.Add(this.cbPlantMachine);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.btnMachineRemove);
			this.panel1.Controls.Add(this.btnRegisterMachine);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.tbNameMachine);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cbModelMachine);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cbCategoryMachine);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cbRscMachine);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1351, 45);
			this.panel1.TabIndex = 18;
			this.cbPlantMachine.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPlantMachine.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.cbPlantMachine.Location = new global::System.Drawing.Point(60, 11);
			this.cbPlantMachine.Name = "cbPlantMachine";
			this.cbPlantMachine.Size = new global::System.Drawing.Size(86, 24);
			this.cbPlantMachine.TabIndex = 30;
			this.cbPlantMachine.SelectedIndexChanged += new global::System.EventHandler(this.cbCategoryMachine_SelectedIndexChanged);
			this.cbPlantMachine.SelectedValueChanged += new global::System.EventHandler(this.Plant_SelectedValueChanged);
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label7.Location = new global::System.Drawing.Point(5, 15);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(50, 17);
			this.label7.TabIndex = 29;
			this.label7.Text = "Factory";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label5.Location = new global::System.Drawing.Point(831, 15);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(45, 17);
			this.label5.TabIndex = 28;
			this.label5.Text = "M/C #";
			this.btnMachineRemove.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.btnMachineRemove.Location = new global::System.Drawing.Point(1271, 10);
			this.btnMachineRemove.Name = "btnMachineRemove";
			this.btnMachineRemove.Size = new global::System.Drawing.Size(75, 27);
			this.btnMachineRemove.TabIndex = 27;
			this.btnMachineRemove.Text = "Delete";
			this.btnMachineRemove.UseVisualStyleBackColor = true;
			this.btnMachineRemove.Click += new global::System.EventHandler(this.btnMachineRemove_Click);
			this.btnRegisterMachine.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.btnRegisterMachine.Location = new global::System.Drawing.Point(1099, 9);
			this.btnRegisterMachine.Name = "btnRegisterMachine";
			this.btnRegisterMachine.Size = new global::System.Drawing.Size(75, 27);
			this.btnRegisterMachine.TabIndex = 26;
			this.btnRegisterMachine.Text = "Register";
			this.btnRegisterMachine.UseVisualStyleBackColor = true;
			this.btnRegisterMachine.Click += new global::System.EventHandler(this.btnRegisterMachine_Click);
			this.button1.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.button1.Location = new global::System.Drawing.Point(1020, 9);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 27);
			this.button1.TabIndex = 25;
			this.button1.Text = "Search";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click_1);
			this.tbNameMachine.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tbNameMachine.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.tbNameMachine.Location = new global::System.Drawing.Point(877, 12);
			this.tbNameMachine.Name = "tbNameMachine";
			this.tbNameMachine.Size = new global::System.Drawing.Size(134, 22);
			this.tbNameMachine.TabIndex = 24;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label3.Location = new global::System.Drawing.Point(611, 14);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(46, 17);
			this.label3.TabIndex = 23;
			this.label3.Text = "Model";
			this.cbModelMachine.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModelMachine.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbModelMachine.Location = new global::System.Drawing.Point(665, 11);
			this.cbModelMachine.Name = "cbModelMachine";
			this.cbModelMachine.Size = new global::System.Drawing.Size(157, 24);
			this.cbModelMachine.TabIndex = 22;
			this.cbModelMachine.SelectedIndexChanged += new global::System.EventHandler(this.cbModelMachine_SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label2.Location = new global::System.Drawing.Point(384, 14);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(54, 17);
			this.label2.TabIndex = 21;
			this.label2.Text = "Rsc Dec";
			this.cbCategoryMachine.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCategoryMachine.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.cbCategoryMachine.Location = new global::System.Drawing.Point(219, 11);
			this.cbCategoryMachine.Name = "cbCategoryMachine";
			this.cbCategoryMachine.Size = new global::System.Drawing.Size(157, 24);
			this.cbCategoryMachine.TabIndex = 20;
			this.cbCategoryMachine.SelectedIndexChanged += new global::System.EventHandler(this.cbCategoryMachine_SelectedIndexChanged);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label1.Location = new global::System.Drawing.Point(152, 14);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(61, 17);
			this.label1.TabIndex = 19;
			this.label1.Text = "Category";
			this.cbRscMachine.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRscMachine.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.cbRscMachine.Location = new global::System.Drawing.Point(445, 11);
			this.cbRscMachine.Name = "cbRscMachine";
			this.cbRscMachine.Size = new global::System.Drawing.Size(157, 24);
			this.cbRscMachine.TabIndex = 9;
			this.cbRscMachine.SelectedIndexChanged += new global::System.EventHandler(this.cbRscMachine_SelectedIndexChanged);
			this.tpMail.Controls.Add(this.groupBox2);
			this.tpMail.Controls.Add(this.groupBox13);
			this.tpMail.Location = new global::System.Drawing.Point(4, 22);
			this.tpMail.Name = "tpMail";
			this.tpMail.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpMail.Size = new global::System.Drawing.Size(1357, 576);
			this.tpMail.TabIndex = 2;
			this.tpMail.Text = "Register Mail";
			this.tpMail.UseVisualStyleBackColor = true;
			this.groupBox2.Controls.Add(this.pnCCList);
			this.groupBox2.Controls.Add(this.pnToList);
			this.groupBox2.Controls.Add(this.pnMailList);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new global::System.Drawing.Point(225, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(1129, 570);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.pnCCList.Controls.Add(this.panel8);
			this.pnCCList.Controls.Add(this.tvCCMail);
			this.pnCCList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnCCList.Location = new global::System.Drawing.Point(3, 17);
			this.pnCCList.Name = "pnCCList";
			this.pnCCList.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 3);
			this.pnCCList.Size = new global::System.Drawing.Size(1123, 550);
			this.pnCCList.TabIndex = 14;
			this.panel8.Controls.Add(this.groupBox12);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel8.Location = new global::System.Drawing.Point(353, 0);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new global::System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panel8.Size = new global::System.Drawing.Size(246, 547);
			this.panel8.TabIndex = 8;
			this.groupBox12.Controls.Add(this.cbMailList);
			this.groupBox12.Controls.Add(this.label23);
			this.groupBox12.Controls.Add(this.cbCCCategory);
			this.groupBox12.Controls.Add(this.label22);
			this.groupBox12.Controls.Add(this.cbCCMailTeam);
			this.groupBox12.Controls.Add(this.label21);
			this.groupBox12.Controls.Add(this.cbCCPlant);
			this.groupBox12.Controls.Add(this.btnCCDel);
			this.groupBox12.Controls.Add(this.btnCCAdd);
			this.groupBox12.Controls.Add(this.label20);
			this.groupBox12.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox12.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new global::System.Drawing.Size(240, 222);
			this.groupBox12.TabIndex = 6;
			this.groupBox12.TabStop = false;
			this.cbMailList.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbMailList.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMailList.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbMailList.FormattingEnabled = true;
			this.cbMailList.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbMailList.Location = new global::System.Drawing.Point(3, 154);
			this.cbMailList.Name = "cbMailList";
			this.cbMailList.Size = new global::System.Drawing.Size(234, 23);
			this.cbMailList.TabIndex = 74;
			this.label23.AutoSize = true;
			this.label23.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label23.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label23.Location = new global::System.Drawing.Point(3, 137);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(33, 17);
			this.label23.TabIndex = 82;
			this.label23.Text = "Mail";
			this.cbCCCategory.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbCCCategory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCCCategory.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbCCCategory.FormattingEnabled = true;
			this.cbCCCategory.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbCCCategory.Location = new global::System.Drawing.Point(3, 114);
			this.cbCCCategory.Name = "cbCCCategory";
			this.cbCCCategory.Size = new global::System.Drawing.Size(234, 23);
			this.cbCCCategory.TabIndex = 73;
			this.label22.AutoSize = true;
			this.label22.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label22.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label22.Location = new global::System.Drawing.Point(3, 97);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(61, 17);
			this.label22.TabIndex = 81;
			this.label22.Text = "Category";
			this.cbCCMailTeam.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbCCMailTeam.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCCMailTeam.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbCCMailTeam.FormattingEnabled = true;
			this.cbCCMailTeam.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbCCMailTeam.Location = new global::System.Drawing.Point(3, 74);
			this.cbCCMailTeam.Name = "cbCCMailTeam";
			this.cbCCMailTeam.Size = new global::System.Drawing.Size(234, 23);
			this.cbCCMailTeam.TabIndex = 72;
			this.label21.AutoSize = true;
			this.label21.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label21.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label21.Location = new global::System.Drawing.Point(3, 57);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(40, 17);
			this.label21.TabIndex = 80;
			this.label21.Text = "Team";
			this.cbCCPlant.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbCCPlant.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCCPlant.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbCCPlant.FormattingEnabled = true;
			this.cbCCPlant.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbCCPlant.Location = new global::System.Drawing.Point(3, 34);
			this.cbCCPlant.Name = "cbCCPlant";
			this.cbCCPlant.Size = new global::System.Drawing.Size(234, 23);
			this.cbCCPlant.TabIndex = 75;
			this.cbCCPlant.SelectedIndexChanged += new global::System.EventHandler(this.cbToPlant_SelectedIndexChanged);
			this.cbCCPlant.SelectedValueChanged += new global::System.EventHandler(this.Plant_SelectedValueChanged);
			this.btnCCDel.Location = new global::System.Drawing.Point(159, 190);
			this.btnCCDel.Name = "btnCCDel";
			this.btnCCDel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCCDel.TabIndex = 9;
			this.btnCCDel.Text = "Del";
			this.btnCCDel.UseVisualStyleBackColor = true;
			this.btnCCDel.Click += new global::System.EventHandler(this.btnCCDel_Click);
			this.btnCCAdd.Location = new global::System.Drawing.Point(80, 190);
			this.btnCCAdd.Name = "btnCCAdd";
			this.btnCCAdd.Size = new global::System.Drawing.Size(75, 23);
			this.btnCCAdd.TabIndex = 4;
			this.btnCCAdd.Text = "Add";
			this.btnCCAdd.UseVisualStyleBackColor = true;
			this.btnCCAdd.Click += new global::System.EventHandler(this.btnCCAdd_Click);
			this.label20.AutoSize = true;
			this.label20.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label20.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label20.Location = new global::System.Drawing.Point(3, 17);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(50, 17);
			this.label20.TabIndex = 79;
			this.label20.Text = "Factory";
			this.tvCCMail.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tvCCMail.Location = new global::System.Drawing.Point(3, 0);
			this.tvCCMail.Name = "tvCCMail";
			this.tvCCMail.Size = new global::System.Drawing.Size(350, 547);
			this.tvCCMail.TabIndex = 7;
			this.pnToList.Controls.Add(this.panel9);
			this.pnToList.Controls.Add(this.tvToMailNode);
			this.pnToList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnToList.Location = new global::System.Drawing.Point(3, 17);
			this.pnToList.Name = "pnToList";
			this.pnToList.Padding = new global::System.Windows.Forms.Padding(3);
			this.pnToList.Size = new global::System.Drawing.Size(1123, 550);
			this.pnToList.TabIndex = 13;
			this.panel9.Controls.Add(this.groupBox9);
			this.panel9.Controls.Add(this.groupBox6);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel9.Location = new global::System.Drawing.Point(353, 3);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new global::System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panel9.Size = new global::System.Drawing.Size(249, 544);
			this.panel9.TabIndex = 8;
			this.groupBox9.Controls.Add(this.comboBox1);
			this.groupBox9.Controls.Add(this.comboBox2);
			this.groupBox9.Controls.Add(this.comboBox3);
			this.groupBox9.Controls.Add(this.button3);
			this.groupBox9.Controls.Add(this.button4);
			this.groupBox9.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox9.Location = new global::System.Drawing.Point(3, 177);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(243, 174);
			this.groupBox9.TabIndex = 7;
			this.groupBox9.TabStop = false;
			this.groupBox9.Visible = false;
			this.comboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.comboBox1.Location = new global::System.Drawing.Point(6, 22);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(228, 23);
			this.comboBox1.TabIndex = 77;
			this.comboBox2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.comboBox2.Location = new global::System.Drawing.Point(7, 90);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new global::System.Drawing.Size(228, 23);
			this.comboBox2.TabIndex = 76;
			this.comboBox3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.comboBox3.Location = new global::System.Drawing.Point(6, 56);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new global::System.Drawing.Size(228, 23);
			this.comboBox3.TabIndex = 75;
			this.button3.Location = new global::System.Drawing.Point(159, 126);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(75, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "Del";
			this.button3.UseVisualStyleBackColor = true;
			this.button4.Location = new global::System.Drawing.Point(80, 126);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(75, 23);
			this.button4.TabIndex = 4;
			this.button4.Text = "Add";
			this.button4.UseVisualStyleBackColor = true;
			this.groupBox6.Controls.Add(this.cbMailList2);
			this.groupBox6.Controls.Add(this.label16);
			this.groupBox6.Controls.Add(this.cbGroupMail);
			this.groupBox6.Controls.Add(this.label15);
			this.groupBox6.Controls.Add(this.cbToPlant);
			this.groupBox6.Controls.Add(this.btnGroupMainDelete);
			this.groupBox6.Controls.Add(this.btnGroupMail);
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox6.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(243, 174);
			this.groupBox6.TabIndex = 6;
			this.groupBox6.TabStop = false;
			this.cbMailList2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbMailList2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMailList2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbMailList2.FormattingEnabled = true;
			this.cbMailList2.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbMailList2.Location = new global::System.Drawing.Point(3, 114);
			this.cbMailList2.Name = "cbMailList2";
			this.cbMailList2.Size = new global::System.Drawing.Size(237, 23);
			this.cbMailList2.TabIndex = 76;
			this.label16.AutoSize = true;
			this.label16.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label16.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label16.Location = new global::System.Drawing.Point(3, 97);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(33, 17);
			this.label16.TabIndex = 80;
			this.label16.Text = "Mail";
			this.cbGroupMail.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbGroupMail.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGroupMail.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbGroupMail.FormattingEnabled = true;
			this.cbGroupMail.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbGroupMail.Location = new global::System.Drawing.Point(3, 74);
			this.cbGroupMail.Name = "cbGroupMail";
			this.cbGroupMail.Size = new global::System.Drawing.Size(237, 23);
			this.cbGroupMail.TabIndex = 75;
			this.label15.AutoSize = true;
			this.label15.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label15.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label15.Location = new global::System.Drawing.Point(3, 57);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(61, 17);
			this.label15.TabIndex = 79;
			this.label15.Text = "Category";
			this.cbToPlant.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbToPlant.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbToPlant.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbToPlant.FormattingEnabled = true;
			this.cbToPlant.Location = new global::System.Drawing.Point(3, 34);
			this.cbToPlant.Name = "cbToPlant";
			this.cbToPlant.Size = new global::System.Drawing.Size(237, 23);
			this.cbToPlant.TabIndex = 77;
			this.cbToPlant.SelectedIndexChanged += new global::System.EventHandler(this.cbToPlant_SelectedIndexChanged);
			this.cbToPlant.SelectedValueChanged += new global::System.EventHandler(this.Plant_SelectedValueChanged);
			this.btnGroupMainDelete.Location = new global::System.Drawing.Point(158, 144);
			this.btnGroupMainDelete.Name = "btnGroupMainDelete";
			this.btnGroupMainDelete.Size = new global::System.Drawing.Size(75, 23);
			this.btnGroupMainDelete.TabIndex = 9;
			this.btnGroupMainDelete.Text = "Del";
			this.btnGroupMainDelete.UseVisualStyleBackColor = true;
			this.btnGroupMainDelete.Click += new global::System.EventHandler(this.btnGroupMainDelet_Click);
			this.btnGroupMail.Location = new global::System.Drawing.Point(79, 144);
			this.btnGroupMail.Name = "btnGroupMail";
			this.btnGroupMail.Size = new global::System.Drawing.Size(75, 23);
			this.btnGroupMail.TabIndex = 4;
			this.btnGroupMail.Text = "Add";
			this.btnGroupMail.UseVisualStyleBackColor = true;
			this.btnGroupMail.Click += new global::System.EventHandler(this.btnGroupMail_Click);
			this.label14.AutoSize = true;
			this.label14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label14.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label14.Location = new global::System.Drawing.Point(3, 17);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(36, 17);
			this.label14.TabIndex = 78;
			this.label14.Text = "Plant";
			this.tvToMailNode.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tvToMailNode.Location = new global::System.Drawing.Point(3, 3);
			this.tvToMailNode.Name = "tvToMailNode";
			this.tvToMailNode.Size = new global::System.Drawing.Size(350, 544);
			this.tvToMailNode.TabIndex = 7;
			this.pnMailList.Controls.Add(this.panel10);
			this.pnMailList.Controls.Add(this.tv_MailList);
			this.pnMailList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnMailList.Location = new global::System.Drawing.Point(3, 17);
			this.pnMailList.Name = "pnMailList";
			this.pnMailList.Padding = new global::System.Windows.Forms.Padding(3);
			this.pnMailList.Size = new global::System.Drawing.Size(1123, 550);
			this.pnMailList.TabIndex = 13;
			this.panel10.Controls.Add(this.groupBox11);
			this.panel10.Controls.Add(this.groupBox1);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel10.Location = new global::System.Drawing.Point(353, 3);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new global::System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panel10.Size = new global::System.Drawing.Size(249, 544);
			this.panel10.TabIndex = 10;
			this.groupBox11.Controls.Add(this.tbMailModify);
			this.groupBox11.Controls.Add(this.label19);
			this.groupBox11.Controls.Add(this.btnModify);
			this.groupBox11.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox11.Location = new global::System.Drawing.Point(3, 145);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new global::System.Drawing.Size(243, 91);
			this.groupBox11.TabIndex = 9;
			this.groupBox11.TabStop = false;
			this.tbMailModify.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbMailModify.Location = new global::System.Drawing.Point(3, 34);
			this.tbMailModify.Name = "tbMailModify";
			this.tbMailModify.Size = new global::System.Drawing.Size(237, 21);
			this.tbMailModify.TabIndex = 3;
			this.label19.AutoSize = true;
			this.label19.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label19.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label19.Location = new global::System.Drawing.Point(3, 17);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(33, 17);
			this.label19.TabIndex = 81;
			this.label19.Text = "Mail";
			this.btnModify.Location = new global::System.Drawing.Point(162, 62);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new global::System.Drawing.Size(75, 23);
			this.btnModify.TabIndex = 4;
			this.btnModify.Text = "Modify";
			this.btnModify.UseVisualStyleBackColor = true;
			this.btnModify.Click += new global::System.EventHandler(this.btnModify_Click);
			this.groupBox1.Controls.Add(this.tb_mail);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.cbMailPlant);
			this.groupBox1.Controls.Add(this.btnDelMail);
			this.groupBox1.Controls.Add(this.btnAddMail);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(243, 142);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.tb_mail.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tb_mail.Location = new global::System.Drawing.Point(3, 75);
			this.tb_mail.Name = "tb_mail";
			this.tb_mail.Size = new global::System.Drawing.Size(237, 21);
			this.tb_mail.TabIndex = 3;
			this.label18.AutoSize = true;
			this.label18.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label18.Location = new global::System.Drawing.Point(3, 58);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(33, 17);
			this.label18.TabIndex = 80;
			this.label18.Text = "Mail";
			this.cbMailPlant.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbMailPlant.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMailPlant.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbMailPlant.Items.AddRange(new object[]
			{
				"TEST"
			});
			this.cbMailPlant.Location = new global::System.Drawing.Point(3, 34);
			this.cbMailPlant.Name = "cbMailPlant";
			this.cbMailPlant.Size = new global::System.Drawing.Size(237, 24);
			this.cbMailPlant.TabIndex = 25;
			this.cbMailPlant.SelectedValueChanged += new global::System.EventHandler(this.Plant_SelectedValueChanged);
			this.btnDelMail.Location = new global::System.Drawing.Point(162, 105);
			this.btnDelMail.Name = "btnDelMail";
			this.btnDelMail.Size = new global::System.Drawing.Size(75, 23);
			this.btnDelMail.TabIndex = 9;
			this.btnDelMail.Text = "Del";
			this.btnDelMail.UseVisualStyleBackColor = true;
			this.btnDelMail.Click += new global::System.EventHandler(this.btnDelMail_Click);
			this.btnAddMail.Location = new global::System.Drawing.Point(77, 105);
			this.btnAddMail.Name = "btnAddMail";
			this.btnAddMail.Size = new global::System.Drawing.Size(75, 23);
			this.btnAddMail.TabIndex = 4;
			this.btnAddMail.Text = "Add";
			this.btnAddMail.UseVisualStyleBackColor = true;
			this.btnAddMail.Click += new global::System.EventHandler(this.btnAddMail_Click);
			this.label17.AutoSize = true;
			this.label17.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label17.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label17.Location = new global::System.Drawing.Point(3, 17);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(36, 17);
			this.label17.TabIndex = 79;
			this.label17.Text = "Plant";
			this.tv_MailList.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tv_MailList.Location = new global::System.Drawing.Point(3, 3);
			this.tv_MailList.Name = "tv_MailList";
			this.tv_MailList.Size = new global::System.Drawing.Size(350, 544);
			this.tv_MailList.TabIndex = 9;
			this.tv_MailList.AfterSelect += new global::System.Windows.Forms.TreeViewEventHandler(this.tv_MailList_AfterSelect);
			this.groupBox13.Controls.Add(this.panel3);
			this.groupBox13.Controls.Add(this.cbMailContents);
			this.groupBox13.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox13.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new global::System.Drawing.Size(222, 570);
			this.groupBox13.TabIndex = 8;
			this.groupBox13.TabStop = false;
			this.panel3.BackColor = global::System.Drawing.Color.Green;
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new global::System.Drawing.Point(9, 13);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(201, 26);
			this.panel3.TabIndex = 12;
			this.label4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(201, 26);
			this.label4.TabIndex = 0;
			this.label4.Text = "Contents";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.cbMailContents.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMailContents.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbMailContents.FormattingEnabled = true;
			this.cbMailContents.Items.AddRange(new object[]
			{
				"Mail List",
				"To Mail List",
				"CC Mail List "
			});
			this.cbMailContents.Location = new global::System.Drawing.Point(9, 41);
			this.cbMailContents.Name = "cbMailContents";
			this.cbMailContents.Size = new global::System.Drawing.Size(201, 28);
			this.cbMailContents.TabIndex = 8;
			this.cbMailContents.SelectedIndexChanged += new global::System.EventHandler(this.cbMailContents_SelectedIndexChanged);
			this.tabpage_team.Controls.Add(this.panel7);
			this.tabpage_team.Controls.Add(this.panel6);
			this.tabpage_team.Controls.Add(this.panel5);
			this.tabpage_team.Location = new global::System.Drawing.Point(4, 22);
			this.tabpage_team.Name = "tabpage_team";
			this.tabpage_team.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabpage_team.Size = new global::System.Drawing.Size(1357, 576);
			this.tabpage_team.TabIndex = 3;
			this.tabpage_team.Text = "Team";
			this.tabpage_team.UseVisualStyleBackColor = true;
			this.panel7.Controls.Add(this.groupBox5);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel7.Location = new global::System.Drawing.Point(602, 3);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel7.Size = new global::System.Drawing.Size(249, 570);
			this.panel7.TabIndex = 15;
			this.groupBox5.Controls.Add(this.cbMailList3);
			this.groupBox5.Controls.Add(this.label28);
			this.groupBox5.Controls.Add(this.cbTeamlist);
			this.groupBox5.Controls.Add(this.label27);
			this.groupBox5.Controls.Add(this.cbTeamPlant2);
			this.groupBox5.Controls.Add(this.label26);
			this.groupBox5.Controls.Add(this.cb_MailDelete);
			this.groupBox5.Controls.Add(this.btn_TeamDelMail);
			this.groupBox5.Controls.Add(this.btn_TeamAddMail);
			this.groupBox5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(246, 212);
			this.groupBox5.TabIndex = 12;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Department Mail";
			this.cbMailList3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbMailList3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMailList3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbMailList3.FormattingEnabled = true;
			this.cbMailList3.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbMailList3.Location = new global::System.Drawing.Point(3, 114);
			this.cbMailList3.Name = "cbMailList3";
			this.cbMailList3.Size = new global::System.Drawing.Size(240, 23);
			this.cbMailList3.TabIndex = 72;
			this.label28.AutoSize = true;
			this.label28.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label28.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label28.Location = new global::System.Drawing.Point(3, 97);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(33, 17);
			this.label28.TabIndex = 83;
			this.label28.Text = "Mail";
			this.cbTeamlist.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbTeamlist.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeamlist.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbTeamlist.FormattingEnabled = true;
			this.cbTeamlist.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbTeamlist.Location = new global::System.Drawing.Point(3, 74);
			this.cbTeamlist.Name = "cbTeamlist";
			this.cbTeamlist.Size = new global::System.Drawing.Size(240, 23);
			this.cbTeamlist.TabIndex = 71;
			this.label27.AutoSize = true;
			this.label27.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label27.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label27.Location = new global::System.Drawing.Point(3, 57);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(40, 17);
			this.label27.TabIndex = 82;
			this.label27.Text = "Team";
			this.cbTeamPlant2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbTeamPlant2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeamPlant2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbTeamPlant2.FormattingEnabled = true;
			this.cbTeamPlant2.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbTeamPlant2.Location = new global::System.Drawing.Point(3, 34);
			this.cbTeamPlant2.Name = "cbTeamPlant2";
			this.cbTeamPlant2.Size = new global::System.Drawing.Size(240, 23);
			this.cbTeamPlant2.TabIndex = 75;
			this.cbTeamPlant2.SelectedIndexChanged += new global::System.EventHandler(this.cbToPlant_SelectedIndexChanged);
			this.label26.AutoSize = true;
			this.label26.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label26.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label26.Location = new global::System.Drawing.Point(3, 17);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(50, 17);
			this.label26.TabIndex = 81;
			this.label26.Text = "Factory";
			this.cb_MailDelete.AutoSize = true;
			this.cb_MailDelete.Location = new global::System.Drawing.Point(149, 146);
			this.cb_MailDelete.Name = "cb_MailDelete";
			this.cb_MailDelete.Size = new global::System.Drawing.Size(87, 16);
			this.cb_MailDelete.TabIndex = 74;
			this.cb_MailDelete.Text = "Mail Delete";
			this.cb_MailDelete.UseVisualStyleBackColor = true;
			this.btn_TeamDelMail.Location = new global::System.Drawing.Point(165, 168);
			this.btn_TeamDelMail.Name = "btn_TeamDelMail";
			this.btn_TeamDelMail.Size = new global::System.Drawing.Size(75, 23);
			this.btn_TeamDelMail.TabIndex = 73;
			this.btn_TeamDelMail.Text = "Del";
			this.btn_TeamDelMail.UseVisualStyleBackColor = true;
			this.btn_TeamDelMail.Click += new global::System.EventHandler(this.btn_TeamDelMail_Click);
			this.btn_TeamAddMail.Location = new global::System.Drawing.Point(84, 167);
			this.btn_TeamAddMail.Name = "btn_TeamAddMail";
			this.btn_TeamAddMail.Size = new global::System.Drawing.Size(75, 23);
			this.btn_TeamAddMail.TabIndex = 4;
			this.btn_TeamAddMail.Text = "Add";
			this.btn_TeamAddMail.UseVisualStyleBackColor = true;
			this.btn_TeamAddMail.Click += new global::System.EventHandler(this.btn_TeamAddMail_Click);
			this.panel6.Controls.Add(this.groupBox4);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel6.Location = new global::System.Drawing.Point(353, 3);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel6.Size = new global::System.Drawing.Size(249, 570);
			this.panel6.TabIndex = 14;
			this.groupBox4.Controls.Add(this.tb_team);
			this.groupBox4.Controls.Add(this.label25);
			this.groupBox4.Controls.Add(this.cbTeamPlant);
			this.groupBox4.Controls.Add(this.label24);
			this.groupBox4.Controls.Add(this.btn_delTeam);
			this.groupBox4.Controls.Add(this.btn_addTeam);
			this.groupBox4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(246, 136);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Department";
			this.tb_team.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tb_team.Location = new global::System.Drawing.Point(3, 74);
			this.tb_team.Name = "tb_team";
			this.tb_team.Size = new global::System.Drawing.Size(240, 21);
			this.tb_team.TabIndex = 3;
			this.label25.AutoSize = true;
			this.label25.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label25.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label25.Location = new global::System.Drawing.Point(3, 57);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(40, 17);
			this.label25.TabIndex = 81;
			this.label25.Text = "Team";
			this.cbTeamPlant.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbTeamPlant.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeamPlant.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbTeamPlant.FormattingEnabled = true;
			this.cbTeamPlant.Items.AddRange(new object[]
			{
				"HIGH",
				"NORMAL",
				"LOW"
			});
			this.cbTeamPlant.Location = new global::System.Drawing.Point(3, 34);
			this.cbTeamPlant.Name = "cbTeamPlant";
			this.cbTeamPlant.Size = new global::System.Drawing.Size(240, 23);
			this.cbTeamPlant.TabIndex = 72;
			this.label24.AutoSize = true;
			this.label24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label24.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label24.Location = new global::System.Drawing.Point(3, 17);
			this.label24.Name = "label24";
			this.label24.Size = new global::System.Drawing.Size(50, 17);
			this.label24.TabIndex = 80;
			this.label24.Text = "Factory";
			this.btn_delTeam.Location = new global::System.Drawing.Point(164, 102);
			this.btn_delTeam.Name = "btn_delTeam";
			this.btn_delTeam.Size = new global::System.Drawing.Size(75, 23);
			this.btn_delTeam.TabIndex = 9;
			this.btn_delTeam.Text = "Del";
			this.btn_delTeam.UseVisualStyleBackColor = true;
			this.btn_delTeam.Click += new global::System.EventHandler(this.btn_delTeam_Click);
			this.btn_addTeam.Location = new global::System.Drawing.Point(79, 102);
			this.btn_addTeam.Name = "btn_addTeam";
			this.btn_addTeam.Size = new global::System.Drawing.Size(75, 23);
			this.btn_addTeam.TabIndex = 4;
			this.btn_addTeam.Text = "Add";
			this.btn_addTeam.UseVisualStyleBackColor = true;
			this.btn_addTeam.Click += new global::System.EventHandler(this.btn_addTeam_Click);
			this.panel5.Controls.Add(this.tv_TeamList);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel5.Location = new global::System.Drawing.Point(3, 3);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel5.Size = new global::System.Drawing.Size(350, 570);
			this.panel5.TabIndex = 13;
			this.tv_TeamList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tv_TeamList.Location = new global::System.Drawing.Point(0, 0);
			this.tv_TeamList.Name = "tv_TeamList";
			this.tv_TeamList.Size = new global::System.Drawing.Size(347, 570);
			this.tv_TeamList.TabIndex = 10;
			this.tp_factor.Controls.Add(this.panel11);
			this.tp_factor.Controls.Add(this.tvFactorList);
			this.tp_factor.Location = new global::System.Drawing.Point(4, 22);
			this.tp_factor.Name = "tp_factor";
			this.tp_factor.Padding = new global::System.Windows.Forms.Padding(3);
			this.tp_factor.Size = new global::System.Drawing.Size(1357, 576);
			this.tp_factor.TabIndex = 4;
			this.tp_factor.Text = "Factor List";
			this.tp_factor.UseVisualStyleBackColor = true;
			this.panel11.Controls.Add(this.panel27);
			this.panel11.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel11.Location = new global::System.Drawing.Point(353, 3);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new global::System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panel11.Size = new global::System.Drawing.Size(248, 570);
			this.panel11.TabIndex = 13;
			this.panel27.Controls.Add(this.panel26);
			this.panel27.Controls.Add(this.panel28);
			this.panel27.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel27.Location = new global::System.Drawing.Point(3, 3);
			this.panel27.Name = "panel27";
			this.panel27.Size = new global::System.Drawing.Size(242, 567);
			this.panel27.TabIndex = 14;
			this.panel26.Controls.Add(this.groupBox7);
			this.panel26.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel26.Location = new global::System.Drawing.Point(0, 71);
			this.panel26.Name = "panel26";
			this.panel26.Size = new global::System.Drawing.Size(242, 225);
			this.panel26.TabIndex = 13;
			this.groupBox7.Controls.Add(this.tbFactor);
			this.groupBox7.Controls.Add(this.label32);
			this.groupBox7.Controls.Add(this.cbFactorCase);
			this.groupBox7.Controls.Add(this.label31);
			this.groupBox7.Controls.Add(this.cbFactorCategory);
			this.groupBox7.Controls.Add(this.label30);
			this.groupBox7.Controls.Add(this.cbPlant);
			this.groupBox7.Controls.Add(this.label29);
			this.groupBox7.Controls.Add(this.btnFactorDel);
			this.groupBox7.Controls.Add(this.btnFactorAdd);
			this.groupBox7.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox7.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(242, 225);
			this.groupBox7.TabIndex = 12;
			this.groupBox7.TabStop = false;
			this.tbFactor.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tbFactor.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbFactor.Location = new global::System.Drawing.Point(3, 157);
			this.tbFactor.Name = "tbFactor";
			this.tbFactor.Size = new global::System.Drawing.Size(236, 21);
			this.tbFactor.TabIndex = 3;
			this.label32.AutoSize = true;
			this.label32.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label32.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label32.Location = new global::System.Drawing.Point(3, 140);
			this.label32.Name = "label32";
			this.label32.Size = new global::System.Drawing.Size(44, 17);
			this.label32.TabIndex = 84;
			this.label32.Text = "Factor";
			this.cbFactorCase.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbFactorCase.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFactorCase.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbFactorCase.Items.AddRange(new object[]
			{
				"HARDWARE",
				"SOFTWARE",
				"OTHER"
			});
			this.cbFactorCase.Location = new global::System.Drawing.Point(3, 116);
			this.cbFactorCase.Name = "cbFactorCase";
			this.cbFactorCase.Size = new global::System.Drawing.Size(236, 24);
			this.cbFactorCase.TabIndex = 24;
			this.label31.AutoSize = true;
			this.label31.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label31.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label31.Location = new global::System.Drawing.Point(3, 99);
			this.label31.Name = "label31";
			this.label31.Size = new global::System.Drawing.Size(36, 17);
			this.label31.TabIndex = 83;
			this.label31.Text = "Case";
			this.cbFactorCategory.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbFactorCategory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFactorCategory.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbFactorCategory.Location = new global::System.Drawing.Point(3, 75);
			this.cbFactorCategory.Name = "cbFactorCategory";
			this.cbFactorCategory.Size = new global::System.Drawing.Size(236, 24);
			this.cbFactorCategory.TabIndex = 25;
			this.cbFactorCategory.SelectedIndexChanged += new global::System.EventHandler(this.cbFactorCategory_SelectedIndexChanged);
			this.label30.AutoSize = true;
			this.label30.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label30.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label30.Location = new global::System.Drawing.Point(3, 58);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(61, 17);
			this.label30.TabIndex = 82;
			this.label30.Text = "Category";
			this.cbPlant.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbPlant.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPlant.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbPlant.Location = new global::System.Drawing.Point(3, 34);
			this.cbPlant.Name = "cbPlant";
			this.cbPlant.Size = new global::System.Drawing.Size(236, 24);
			this.cbPlant.TabIndex = 23;
			this.cbPlant.SelectedValueChanged += new global::System.EventHandler(this.Plant_SelectedValueChanged);
			this.label29.AutoSize = true;
			this.label29.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label29.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label29.Location = new global::System.Drawing.Point(3, 17);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(50, 17);
			this.label29.TabIndex = 81;
			this.label29.Text = "Factory";
			this.btnFactorDel.Location = new global::System.Drawing.Point(159, 187);
			this.btnFactorDel.Name = "btnFactorDel";
			this.btnFactorDel.Size = new global::System.Drawing.Size(75, 23);
			this.btnFactorDel.TabIndex = 10;
			this.btnFactorDel.Text = "Del";
			this.btnFactorDel.UseVisualStyleBackColor = true;
			this.btnFactorDel.Click += new global::System.EventHandler(this.btnFactorDel_Click);
			this.btnFactorAdd.Location = new global::System.Drawing.Point(81, 187);
			this.btnFactorAdd.Name = "btnFactorAdd";
			this.btnFactorAdd.Size = new global::System.Drawing.Size(75, 23);
			this.btnFactorAdd.TabIndex = 4;
			this.btnFactorAdd.Text = "Add";
			this.btnFactorAdd.UseVisualStyleBackColor = true;
			this.btnFactorAdd.Click += new global::System.EventHandler(this.btnFactorAdd_Click);
			this.panel28.Controls.Add(this.groupBox15);
			this.panel28.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel28.Location = new global::System.Drawing.Point(0, 0);
			this.panel28.Name = "panel28";
			this.panel28.Size = new global::System.Drawing.Size(242, 71);
			this.panel28.TabIndex = 14;
			this.groupBox15.Controls.Add(this.cbFactorSystem);
			this.groupBox15.Controls.Add(this.label41);
			this.groupBox15.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox15.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new global::System.Drawing.Size(242, 71);
			this.groupBox15.TabIndex = 0;
			this.groupBox15.TabStop = false;
			this.cbFactorSystem.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbFactorSystem.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFactorSystem.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbFactorSystem.Items.AddRange(new object[]
			{
				"Maintenanace & PM",
				"Board Site Map"
			});
			this.cbFactorSystem.Location = new global::System.Drawing.Point(3, 34);
			this.cbFactorSystem.Name = "cbFactorSystem";
			this.cbFactorSystem.Size = new global::System.Drawing.Size(236, 24);
			this.cbFactorSystem.TabIndex = 82;
			this.cbFactorSystem.SelectedIndexChanged += new global::System.EventHandler(this.cbFactorSystem_SelectedIndexChanged);
			this.label41.AutoSize = true;
			this.label41.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label41.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label41.Location = new global::System.Drawing.Point(3, 17);
			this.label41.Name = "label41";
			this.label41.Size = new global::System.Drawing.Size(49, 17);
			this.label41.TabIndex = 83;
			this.label41.Text = "System";
			this.tvFactorList.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tvFactorList.Location = new global::System.Drawing.Point(3, 3);
			this.tvFactorList.Name = "tvFactorList";
			this.tvFactorList.Size = new global::System.Drawing.Size(350, 570);
			this.tvFactorList.TabIndex = 11;
			this.tpVendor.Controls.Add(this.panel14);
			this.tpVendor.Controls.Add(this.tvVendor);
			this.tpVendor.Location = new global::System.Drawing.Point(4, 22);
			this.tpVendor.Name = "tpVendor";
			this.tpVendor.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpVendor.Size = new global::System.Drawing.Size(1357, 576);
			this.tpVendor.TabIndex = 5;
			this.tpVendor.Text = "Vendor";
			this.tpVendor.UseVisualStyleBackColor = true;
			this.panel14.Controls.Add(this.groupBox14);
			this.panel14.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel14.Location = new global::System.Drawing.Point(353, 3);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new global::System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panel14.Size = new global::System.Drawing.Size(248, 570);
			this.panel14.TabIndex = 14;
			this.groupBox14.Controls.Add(this.tbVendor);
			this.groupBox14.Controls.Add(this.label33);
			this.groupBox14.Controls.Add(this.cbVendorFactory);
			this.groupBox14.Controls.Add(this.label36);
			this.groupBox14.Controls.Add(this.btnDelVendor);
			this.groupBox14.Controls.Add(this.btnAddVendor);
			this.groupBox14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox14.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new global::System.Drawing.Size(242, 140);
			this.groupBox14.TabIndex = 12;
			this.groupBox14.TabStop = false;
			this.tbVendor.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tbVendor.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbVendor.Location = new global::System.Drawing.Point(3, 75);
			this.tbVendor.Name = "tbVendor";
			this.tbVendor.Size = new global::System.Drawing.Size(236, 21);
			this.tbVendor.TabIndex = 3;
			this.label33.AutoSize = true;
			this.label33.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label33.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label33.Location = new global::System.Drawing.Point(3, 58);
			this.label33.Name = "label33";
			this.label33.Size = new global::System.Drawing.Size(51, 17);
			this.label33.TabIndex = 84;
			this.label33.Text = "Vendor";
			this.cbVendorFactory.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbVendorFactory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbVendorFactory.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbVendorFactory.Location = new global::System.Drawing.Point(3, 34);
			this.cbVendorFactory.Name = "cbVendorFactory";
			this.cbVendorFactory.Size = new global::System.Drawing.Size(236, 24);
			this.cbVendorFactory.TabIndex = 23;
			this.cbVendorFactory.SelectedIndexChanged += new global::System.EventHandler(this.cbVendorFactory_SelectedIndexChanged);
			this.label36.AutoSize = true;
			this.label36.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label36.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label36.Location = new global::System.Drawing.Point(3, 17);
			this.label36.Name = "label36";
			this.label36.Size = new global::System.Drawing.Size(50, 17);
			this.label36.TabIndex = 81;
			this.label36.Text = "Factory";
			this.btnDelVendor.Location = new global::System.Drawing.Point(161, 102);
			this.btnDelVendor.Name = "btnDelVendor";
			this.btnDelVendor.Size = new global::System.Drawing.Size(75, 23);
			this.btnDelVendor.TabIndex = 10;
			this.btnDelVendor.Text = "Del";
			this.btnDelVendor.UseVisualStyleBackColor = true;
			this.btnDelVendor.Click += new global::System.EventHandler(this.btnDelVendor_Click);
			this.btnAddVendor.Location = new global::System.Drawing.Point(83, 102);
			this.btnAddVendor.Name = "btnAddVendor";
			this.btnAddVendor.Size = new global::System.Drawing.Size(75, 23);
			this.btnAddVendor.TabIndex = 4;
			this.btnAddVendor.Text = "Add";
			this.btnAddVendor.UseVisualStyleBackColor = true;
			this.btnAddVendor.Click += new global::System.EventHandler(this.btnAddVendor_Click);
			this.tvVendor.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.tvVendor.Location = new global::System.Drawing.Point(3, 3);
			this.tvVendor.Name = "tvVendor";
			this.tvVendor.Size = new global::System.Drawing.Size(350, 570);
			this.tvVendor.TabIndex = 12;
			this.tpAsset.Controls.Add(this.panel15);
			this.tpAsset.Location = new global::System.Drawing.Point(4, 22);
			this.tpAsset.Name = "tpAsset";
			this.tpAsset.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpAsset.Size = new global::System.Drawing.Size(1357, 576);
			this.tpAsset.TabIndex = 6;
			this.tpAsset.Text = "Asset";
			this.tpAsset.UseVisualStyleBackColor = true;
			this.panel15.Controls.Add(this.grid_Asset);
			this.panel15.Controls.Add(this.panel16);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel15.Location = new global::System.Drawing.Point(3, 3);
			this.panel15.Name = "panel15";
			this.panel15.Padding = new global::System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panel15.Size = new global::System.Drawing.Size(1351, 570);
			this.panel15.TabIndex = 15;
			this.grid_Asset.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_Asset.EnableSort = true;
			this.grid_Asset.FixedColumns = 1;
			this.grid_Asset.FixedRows = 1;
			this.grid_Asset.Font = new global::System.Drawing.Font("굴림체", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.grid_Asset.Location = new global::System.Drawing.Point(3, 48);
			this.grid_Asset.Name = "grid_Asset";
			this.grid_Asset.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_Asset.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_Asset.Size = new global::System.Drawing.Size(1345, 522);
			this.grid_Asset.TabIndex = 20;
			this.grid_Asset.TabStop = true;
			this.grid_Asset.ToolTipText = "";
			this.panel16.Controls.Add(this.btnDeleteAsset);
			this.panel16.Controls.Add(this.label37);
			this.panel16.Controls.Add(this.tbAsset);
			this.panel16.Controls.Add(this.cbAssetFactory);
			this.panel16.Controls.Add(this.label34);
			this.panel16.Controls.Add(this.label35);
			this.panel16.Controls.Add(this.btnImport);
			this.panel16.Controls.Add(this.btnAssetSearch);
			this.panel16.Controls.Add(this.tbAssetEquipment);
			this.panel16.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel16.Location = new global::System.Drawing.Point(3, 3);
			this.panel16.Name = "panel16";
			this.panel16.Size = new global::System.Drawing.Size(1345, 45);
			this.panel16.TabIndex = 19;
			this.btnDeleteAsset.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.btnDeleteAsset.Location = new global::System.Drawing.Point(1164, 9);
			this.btnDeleteAsset.Name = "btnDeleteAsset";
			this.btnDeleteAsset.Size = new global::System.Drawing.Size(75, 27);
			this.btnDeleteAsset.TabIndex = 33;
			this.btnDeleteAsset.Text = "Delete";
			this.btnDeleteAsset.UseVisualStyleBackColor = true;
			this.btnDeleteAsset.Click += new global::System.EventHandler(this.btnDeleteAsset_Click);
			this.label37.AutoSize = true;
			this.label37.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label37.Location = new global::System.Drawing.Point(360, 14);
			this.label37.Name = "label37";
			this.label37.Size = new global::System.Drawing.Size(51, 17);
			this.label37.TabIndex = 32;
			this.label37.Text = "Asset #";
			this.tbAsset.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tbAsset.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.tbAsset.Location = new global::System.Drawing.Point(416, 11);
			this.tbAsset.Name = "tbAsset";
			this.tbAsset.Size = new global::System.Drawing.Size(134, 22);
			this.tbAsset.TabIndex = 31;
			this.cbAssetFactory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAssetFactory.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.cbAssetFactory.Location = new global::System.Drawing.Point(61, 11);
			this.cbAssetFactory.Name = "cbAssetFactory";
			this.cbAssetFactory.Size = new global::System.Drawing.Size(96, 24);
			this.cbAssetFactory.TabIndex = 30;
			this.label34.AutoSize = true;
			this.label34.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label34.Location = new global::System.Drawing.Point(5, 15);
			this.label34.Name = "label34";
			this.label34.Size = new global::System.Drawing.Size(50, 17);
			this.label34.TabIndex = 29;
			this.label34.Text = "Factory";
			this.label35.AutoSize = true;
			this.label35.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label35.Location = new global::System.Drawing.Point(163, 14);
			this.label35.Name = "label35";
			this.label35.Size = new global::System.Drawing.Size(45, 17);
			this.label35.TabIndex = 28;
			this.label35.Text = "M/C #";
			this.btnImport.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.btnImport.Location = new global::System.Drawing.Point(647, 8);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new global::System.Drawing.Size(75, 27);
			this.btnImport.TabIndex = 26;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new global::System.EventHandler(this.btnImport_Click);
			this.btnAssetSearch.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.btnAssetSearch.Location = new global::System.Drawing.Point(564, 8);
			this.btnAssetSearch.Name = "btnAssetSearch";
			this.btnAssetSearch.Size = new global::System.Drawing.Size(75, 27);
			this.btnAssetSearch.TabIndex = 25;
			this.btnAssetSearch.Text = "Search";
			this.btnAssetSearch.UseVisualStyleBackColor = true;
			this.btnAssetSearch.Click += new global::System.EventHandler(this.btnAssetSearch_Click);
			this.tbAssetEquipment.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tbAssetEquipment.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.tbAssetEquipment.Location = new global::System.Drawing.Point(213, 11);
			this.tbAssetEquipment.Name = "tbAssetEquipment";
			this.tbAssetEquipment.Size = new global::System.Drawing.Size(134, 22);
			this.tbAssetEquipment.TabIndex = 24;
			this.tpConfirmation.Controls.Add(this.panel18);
			this.tpConfirmation.Controls.Add(this.panel25);
			this.tpConfirmation.Controls.Add(this.panel17);
			this.tpConfirmation.Location = new global::System.Drawing.Point(4, 22);
			this.tpConfirmation.Name = "tpConfirmation";
			this.tpConfirmation.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpConfirmation.Size = new global::System.Drawing.Size(1357, 576);
			this.tpConfirmation.TabIndex = 7;
			this.tpConfirmation.Text = "Confirmation";
			this.tpConfirmation.UseVisualStyleBackColor = true;
			this.panel18.Controls.Add(this.btnApply);
			this.panel18.Controls.Add(this.panel23);
			this.panel18.Controls.Add(this.panel21);
			this.panel18.Controls.Add(this.panel19);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel18.Location = new global::System.Drawing.Point(523, 3);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(321, 570);
			this.panel18.TabIndex = 2;
			this.btnApply.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.btnApply.Location = new global::System.Drawing.Point(0, 129);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new global::System.Drawing.Size(321, 30);
			this.btnApply.TabIndex = 4;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new global::System.EventHandler(this.btnApply_Click);
			this.panel23.Controls.Add(this.tbContent);
			this.panel23.Controls.Add(this.btModify);
			this.panel23.Controls.Add(this.panel24);
			this.panel23.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel23.Location = new global::System.Drawing.Point(0, 83);
			this.panel23.Name = "panel23";
			this.panel23.Size = new global::System.Drawing.Size(321, 46);
			this.panel23.TabIndex = 2;
			this.tbContent.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbContent.Location = new global::System.Drawing.Point(0, 13);
			this.tbContent.Multiline = true;
			this.tbContent.Name = "tbContent";
			this.tbContent.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbContent.Size = new global::System.Drawing.Size(246, 33);
			this.tbContent.TabIndex = 2;
			this.tbContent.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tbContent_KeyPress);
			this.btModify.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btModify.Location = new global::System.Drawing.Point(246, 13);
			this.btModify.Margin = new global::System.Windows.Forms.Padding(0);
			this.btModify.Name = "btModify";
			this.btModify.Size = new global::System.Drawing.Size(75, 33);
			this.btModify.TabIndex = 3;
			this.btModify.Text = "Modify";
			this.btModify.UseVisualStyleBackColor = true;
			this.btModify.Click += new global::System.EventHandler(this.btModify_Click);
			this.panel24.Controls.Add(this.label40);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(321, 13);
			this.panel24.TabIndex = 0;
			this.label40.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label40.Location = new global::System.Drawing.Point(0, 0);
			this.label40.Name = "label40";
			this.label40.Size = new global::System.Drawing.Size(321, 13);
			this.label40.TabIndex = 0;
			this.label40.Text = "Title(@,^ 사용불가!!)";
			this.panel21.Controls.Add(this.cbConfirmType);
			this.panel21.Controls.Add(this.panel22);
			this.panel21.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel21.Location = new global::System.Drawing.Point(0, 41);
			this.panel21.Name = "panel21";
			this.panel21.Size = new global::System.Drawing.Size(321, 42);
			this.panel21.TabIndex = 1;
			this.cbConfirmType.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbConfirmType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbConfirmType.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbConfirmType.Items.AddRange(new object[]
			{
				"HANDLER",
				"TESTER",
				"EOL",
				"AOI"
			});
			this.cbConfirmType.Location = new global::System.Drawing.Point(0, 15);
			this.cbConfirmType.Name = "cbConfirmType";
			this.cbConfirmType.Size = new global::System.Drawing.Size(321, 24);
			this.cbConfirmType.TabIndex = 24;
			this.cbConfirmType.SelectedIndexChanged += new global::System.EventHandler(this.cbConfirmType_SelectedIndexChanged);
			this.panel22.Controls.Add(this.label39);
			this.panel22.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel22.Location = new global::System.Drawing.Point(0, 0);
			this.panel22.Name = "panel22";
			this.panel22.Size = new global::System.Drawing.Size(321, 15);
			this.panel22.TabIndex = 0;
			this.label39.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label39.Location = new global::System.Drawing.Point(0, 0);
			this.label39.Name = "label39";
			this.label39.Size = new global::System.Drawing.Size(321, 15);
			this.label39.TabIndex = 0;
			this.label39.Text = "Type";
			this.panel19.Controls.Add(this.cbConfirmFactory);
			this.panel19.Controls.Add(this.panel20);
			this.panel19.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel19.Location = new global::System.Drawing.Point(0, 0);
			this.panel19.Name = "panel19";
			this.panel19.Size = new global::System.Drawing.Size(321, 41);
			this.panel19.TabIndex = 0;
			this.cbConfirmFactory.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.cbConfirmFactory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbConfirmFactory.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbConfirmFactory.Items.AddRange(new object[]
			{
				"K3",
				"K3_EV",
				"K5_PROBE",
				"K5"
			});
			this.cbConfirmFactory.Location = new global::System.Drawing.Point(0, 15);
			this.cbConfirmFactory.Name = "cbConfirmFactory";
			this.cbConfirmFactory.Size = new global::System.Drawing.Size(321, 24);
			this.cbConfirmFactory.TabIndex = 24;
			this.cbConfirmFactory.SelectedIndexChanged += new global::System.EventHandler(this.cbConfirFactory_SelectedIndexChanged);
			this.panel20.Controls.Add(this.label38);
			this.panel20.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel20.Location = new global::System.Drawing.Point(0, 0);
			this.panel20.Name = "panel20";
			this.panel20.Size = new global::System.Drawing.Size(321, 15);
			this.panel20.TabIndex = 0;
			this.label38.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label38.Location = new global::System.Drawing.Point(0, 0);
			this.label38.Name = "label38";
			this.label38.Size = new global::System.Drawing.Size(321, 15);
			this.label38.TabIndex = 0;
			this.label38.Text = "Factory";
			this.panel25.Controls.Add(this.btnDown);
			this.panel25.Controls.Add(this.btnUp);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel25.Location = new global::System.Drawing.Point(426, 3);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(97, 570);
			this.panel25.TabIndex = 3;
			this.btnDown.Location = new global::System.Drawing.Point(10, 293);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new global::System.Drawing.Size(75, 46);
			this.btnDown.TabIndex = 5;
			this.btnDown.Text = "▼";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new global::System.EventHandler(this.btnDown_Click);
			this.btnUp.Location = new global::System.Drawing.Point(9, 168);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new global::System.Drawing.Size(75, 46);
			this.btnUp.TabIndex = 4;
			this.btnUp.Text = "▲";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new global::System.EventHandler(this.btnUp_Click);
			this.panel17.Controls.Add(this.cbListBox);
			this.panel17.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel17.Location = new global::System.Drawing.Point(3, 3);
			this.panel17.Name = "panel17";
			this.panel17.Size = new global::System.Drawing.Size(423, 570);
			this.panel17.TabIndex = 1;
			this.cbListBox.CheckOnClick = true;
			this.cbListBox.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbListBox.Font = new global::System.Drawing.Font("굴림", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.cbListBox.FormattingEnabled = true;
			this.cbListBox.HorizontalScrollbar = true;
			this.cbListBox.Location = new global::System.Drawing.Point(0, 0);
			this.cbListBox.Name = "cbListBox";
			this.cbListBox.ScrollAlwaysVisible = true;
			this.cbListBox.Size = new global::System.Drawing.Size(423, 570);
			this.cbListBox.TabIndex = 4;
			this.cbListBox.ItemCheck += new global::System.Windows.Forms.ItemCheckEventHandler(this.cbListBox_ItemCheck);
			this.cbListBox.SelectedIndexChanged += new global::System.EventHandler(this.cbListBox_SelectedIndexChanged);
			this.cbListBox.SelectedValueChanged += new global::System.EventHandler(this.cbListBox_SelectedValueChanged);
			this.openFileDialog.Filter = "*.csv|";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1365, 602);
			base.Controls.Add(this.tcMenu);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "AdminSetting";
			this.Text = "AdminSetting";
			base.Shown += new global::System.EventHandler(this.AdminSetting_Shown);
			this.tcMenu.ResumeLayout(false);
			this.tpRegister.ResumeLayout(false);
			this.gbModel.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.gbRscDec.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.tpMachine.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tpMail.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.pnCCList.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.pnToList.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.pnMailList.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox13.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tabpage_team.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.tp_factor.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel27.ResumeLayout(false);
			this.panel26.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.panel28.ResumeLayout(false);
			this.groupBox15.ResumeLayout(false);
			this.groupBox15.PerformLayout();
			this.tpVendor.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			this.tpAsset.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.panel16.ResumeLayout(false);
			this.panel16.PerformLayout();
			this.tpConfirmation.ResumeLayout(false);
			this.panel18.ResumeLayout(false);
			this.panel23.ResumeLayout(false);
			this.panel23.PerformLayout();
			this.panel24.ResumeLayout(false);
			this.panel21.ResumeLayout(false);
			this.panel22.ResumeLayout(false);
			this.panel19.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.panel25.ResumeLayout(false);
			this.panel17.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040000C4 RID: 196
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.TabControl tcMenu;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.TabPage tpRegister;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.GroupBox gbModel;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.TreeView tvModel;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Button btnModelDelete;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Button btnAddModel;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.TextBox tbModelName;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.GroupBox gbRscDec;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.TreeView tvRscDec;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.GroupBox groupBox10;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.Button btnRscDelete;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.TextBox tbRscName;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.TabPage tpMachine;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000D6 RID: 214
		private global::SourceGrid.Grid grid_Machine;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.TextBox tbNameMachine;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.ComboBox cbModelMachine;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.ComboBox cbCategoryMachine;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.ComboBox cbRscMachine;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Button btnRegisterMachine;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Button btnMachineRemove;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.TabPage tpMail;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.Panel pnMailList;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.TreeView tv_MailList;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.Button btnDelMail;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.Button btnAddMail;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.TextBox tb_mail;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Panel pnCCList;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.TreeView tvCCMail;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.GroupBox groupBox12;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.Button btnCCDel;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.Button btnCCAdd;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Panel pnToList;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.TreeView tvToMailNode;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.Button btnGroupMainDelete;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.Button btnGroupMail;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.GroupBox groupBox13;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.ComboBox cbMailContents;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.ComboBox cbContents;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.ComboBox cbRscCategory;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.ComboBox cbModelCategory;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.TabPage tabpage_team;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.Button btn_delTeam;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.Button btn_addTeam;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.TextBox tb_team;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.TreeView tv_TeamList;

		// Token: 0x04000104 RID: 260
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x04000105 RID: 261
		private global::System.Windows.Forms.Button btn_TeamAddMail;

		// Token: 0x04000106 RID: 262
		private global::System.Windows.Forms.ComboBox cbMailList;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.ComboBox cbCCCategory;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.ComboBox cbCCMailTeam;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.ComboBox cbMailList2;

		// Token: 0x0400010A RID: 266
		private global::System.Windows.Forms.ComboBox cbGroupMail;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.ComboBox cbMailList3;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.ComboBox cbTeamlist;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.Button btn_TeamDelMail;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.CheckBox cb_MailDelete;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.TabPage tp_factor;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.ComboBox cbPlant;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.Button btnFactorDel;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Button btnFactorAdd;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.TextBox tbFactor;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.TreeView tvFactorList;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.ComboBox cbFactorCase;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.ComboBox cbFactorCategory;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.ComboBox cbRscPlant;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.ComboBox cbModelPlant;

		// Token: 0x0400011A RID: 282
		private global::System.Windows.Forms.ComboBox cbMailPlant;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.ComboBox cbToPlant;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.ComboBox cbCCPlant;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.ComboBox cbTeamPlant;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.ComboBox cbTeamPlant2;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.ComboBox cbPlantMachine;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.Panel panel12;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.GroupBox groupBox11;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.Button btnModify;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.TextBox tbMailModify;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.ComboBox comboBox1;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.ComboBox comboBox2;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.ComboBox comboBox3;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.Button button3;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.Button button4;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.Label label16;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.Label label15;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.Label label14;

		// Token: 0x0400013C RID: 316
		private global::System.Windows.Forms.Label label19;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.Label label18;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.Label label17;

		// Token: 0x0400013F RID: 319
		private global::System.Windows.Forms.Label label23;

		// Token: 0x04000140 RID: 320
		private global::System.Windows.Forms.Label label22;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.Label label21;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.Label label20;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.Label label25;

		// Token: 0x04000144 RID: 324
		private global::System.Windows.Forms.Label label24;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.Label label28;

		// Token: 0x04000146 RID: 326
		private global::System.Windows.Forms.Label label27;

		// Token: 0x04000147 RID: 327
		private global::System.Windows.Forms.Label label26;

		// Token: 0x04000148 RID: 328
		private global::System.Windows.Forms.Label label32;

		// Token: 0x04000149 RID: 329
		private global::System.Windows.Forms.Label label31;

		// Token: 0x0400014A RID: 330
		private global::System.Windows.Forms.Label label30;

		// Token: 0x0400014B RID: 331
		private global::System.Windows.Forms.Label label29;

		// Token: 0x0400014C RID: 332
		private global::System.Windows.Forms.TabPage tpVendor;

		// Token: 0x0400014D RID: 333
		private global::System.Windows.Forms.Panel panel14;

		// Token: 0x0400014E RID: 334
		private global::System.Windows.Forms.GroupBox groupBox14;

		// Token: 0x0400014F RID: 335
		private global::System.Windows.Forms.TextBox tbVendor;

		// Token: 0x04000150 RID: 336
		private global::System.Windows.Forms.Label label33;

		// Token: 0x04000151 RID: 337
		private global::System.Windows.Forms.ComboBox cbVendorFactory;

		// Token: 0x04000152 RID: 338
		private global::System.Windows.Forms.Label label36;

		// Token: 0x04000153 RID: 339
		private global::System.Windows.Forms.Button btnDelVendor;

		// Token: 0x04000154 RID: 340
		private global::System.Windows.Forms.Button btnAddVendor;

		// Token: 0x04000155 RID: 341
		private global::System.Windows.Forms.TreeView tvVendor;

		// Token: 0x04000156 RID: 342
		private global::System.Windows.Forms.TabPage tpAsset;

		// Token: 0x04000157 RID: 343
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x04000158 RID: 344
		private global::SourceGrid.Grid grid_Asset;

		// Token: 0x04000159 RID: 345
		private global::System.Windows.Forms.Panel panel16;

		// Token: 0x0400015A RID: 346
		private global::System.Windows.Forms.ComboBox cbAssetFactory;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.Label label34;

		// Token: 0x0400015C RID: 348
		private global::System.Windows.Forms.Label label35;

		// Token: 0x0400015D RID: 349
		private global::System.Windows.Forms.Button btnImport;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.Button btnAssetSearch;

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.TextBox tbAssetEquipment;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.Label label37;

		// Token: 0x04000162 RID: 354
		private global::System.Windows.Forms.TextBox tbAsset;

		// Token: 0x04000163 RID: 355
		private global::System.Windows.Forms.Button btnDeleteAsset;

		// Token: 0x04000164 RID: 356
		private global::System.Windows.Forms.TabPage tpConfirmation;

		// Token: 0x04000165 RID: 357
		private global::System.Windows.Forms.Panel panel17;

		// Token: 0x04000166 RID: 358
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000167 RID: 359
		private global::System.Windows.Forms.Panel panel23;

		// Token: 0x04000168 RID: 360
		private global::System.Windows.Forms.Button btModify;

		// Token: 0x04000169 RID: 361
		private global::System.Windows.Forms.TextBox tbContent;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.Label label40;

		// Token: 0x0400016C RID: 364
		private global::System.Windows.Forms.Panel panel21;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.ComboBox cbConfirmType;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.Panel panel22;

		// Token: 0x0400016F RID: 367
		private global::System.Windows.Forms.Label label39;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.Panel panel19;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.ComboBox cbConfirmFactory;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.Panel panel20;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.Label label38;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.Button btnDown;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.Button btnUp;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.CheckedListBox cbListBox;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.Button btnApply;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.Panel panel27;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.Panel panel26;

		// Token: 0x0400017B RID: 379
		private global::System.Windows.Forms.Panel panel28;

		// Token: 0x0400017C RID: 380
		private global::System.Windows.Forms.GroupBox groupBox15;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.ComboBox cbFactorSystem;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.Label label41;
	}
}
