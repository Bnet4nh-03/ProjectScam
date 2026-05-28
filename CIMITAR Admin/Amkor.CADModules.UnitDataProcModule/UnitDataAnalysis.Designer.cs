namespace Amkor.CADModules.UnitDataProcModule
{
	// Token: 0x02000010 RID: 16
	public partial class UnitDataAnalysis : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000064 RID: 100 RVA: 0x0000AD77 File Offset: 0x00008F77
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000AD98 File Offset: 0x00008F98
		private void InitializeComponent()
		{
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label12 = new global::System.Windows.Forms.Label();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.splitter8 = new global::System.Windows.Forms.Splitter();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.btnRawData = new global::Telerik.WinControls.UI.RadButton();
			this.btnNewDoc = new global::Telerik.WinControls.UI.RadButton();
			this.btnLotLoad = new global::Telerik.WinControls.UI.RadButton();
			this.btnSNLoad = new global::Telerik.WinControls.UI.RadButton();
			this.rdoSN = new global::Telerik.WinControls.UI.RadRadioButton();
			this.btnLotSearch = new global::Telerik.WinControls.UI.RadButton();
			this.radLabel5 = new global::Telerik.WinControls.UI.RadLabel();
			this.rdoDate = new global::Telerik.WinControls.UI.RadRadioButton();
			this.txtSN = new global::Telerik.WinControls.UI.RadTextBox();
			this.chkcmb_Product = new global::Telerik.WinControls.UI.RadCheckedDropDownList();
			this.rdoLot = new global::Telerik.WinControls.UI.RadRadioButton();
			this.txtLot = new global::Telerik.WinControls.UI.RadTextBox();
			this.dateTimeEnd = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.dateTimeStart = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radcmb_DateType = new global::Telerik.WinControls.UI.RadDropDownList();
			this.radLabel9 = new global::Telerik.WinControls.UI.RadLabel();
			this.radcmb_Device = new global::Telerik.WinControls.UI.RadDropDownList();
			this.radLabel1 = new global::Telerik.WinControls.UI.RadLabel();
			this.radchkcmb_Customer = new global::Telerik.WinControls.UI.RadCheckedDropDownList();
			this.splitter4 = new global::System.Windows.Forms.Splitter();
			this.panelInfo = new global::System.Windows.Forms.Panel();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.grid_Lot = new global::Telerik.WinControls.UI.RadGridView();
			this.splitter2 = new global::System.Windows.Forms.Splitter();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.grid_Device = new global::Telerik.WinControls.UI.RadGridView();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.txtDevice = new global::Telerik.WinControls.UI.RadTextBox();
			this.btnDeviceSearch = new global::Telerik.WinControls.UI.RadButton();
			this.panel14 = new global::System.Windows.Forms.Panel();
			this.radLabel6 = new global::Telerik.WinControls.UI.RadLabel();
			this.rdoProd = new global::Telerik.WinControls.UI.RadRadioButton();
			this.rdoENick = new global::Telerik.WinControls.UI.RadRadioButton();
			this.rdoDevice = new global::Telerik.WinControls.UI.RadRadioButton();
			this.backgroundWorker1 = new global::System.ComponentModel.BackgroundWorker();
			this.radDock1 = new global::Telerik.WinControls.UI.Docking.RadDock();
			this.toolWindow1 = new global::Telerik.WinControls.UI.Docking.ToolWindow();
			this.toolTabStrip3 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.documentContainer1 = new global::Telerik.WinControls.UI.Docking.DocumentContainer();
			this.radThemeManager1 = new global::Telerik.WinControls.RadThemeManager();
			this.documentWindow2 = new global::Telerik.WinControls.UI.Docking.DocumentWindow();
			this.documentTabStrip1 = new global::Telerik.WinControls.UI.Docking.DocumentTabStrip();
			this.documentWindow1 = new global::Telerik.WinControls.UI.Docking.DocumentWindow();
			this.telerikMetroTheme1 = new global::Telerik.WinControls.Themes.TelerikMetroTheme();
			this.office2010BlueTheme1 = new global::Telerik.WinControls.Themes.Office2010BlueTheme();
			this.telerikMetroBlueTheme1 = new global::Telerik.WinControls.Themes.TelerikMetroBlueTheme();
			this.toolTabStrip2 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.toolTabStrip1 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.toolTabStrip5 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.toolTabStrip6 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.openFileDialog1 = new global::System.Windows.Forms.OpenFileDialog();
			this.panel3.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnRawData).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnNewDoc).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnLotLoad).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnSNLoad).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoSN).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnLotSearch).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoDate).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.txtSN).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.chkcmb_Product).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoLot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.txtLot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dateTimeEnd).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dateTimeStart).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radcmb_DateType).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel9).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radcmb_Device).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radchkcmb_Customer).BeginInit();
			this.panelInfo.SuspendLayout();
			this.panel8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.grid_Lot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.grid_Lot.MasterTemplate).BeginInit();
			this.grid_Lot.SuspendLayout();
			this.panel6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.grid_Device).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.grid_Device.MasterTemplate).BeginInit();
			this.panel11.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.txtDevice).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnDeviceSearch).BeginInit();
			this.panel14.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel6).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoProd).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoENick).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoDevice).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radDock1).BeginInit();
			this.radDock1.SuspendLayout();
			this.toolWindow1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip3).BeginInit();
			this.toolTabStrip3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.documentContainer1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.documentTabStrip1).BeginInit();
			this.documentTabStrip1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip6).BeginInit();
			base.SuspendLayout();
			this.panel3.Controls.Add(this.label12);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1331, 30);
			this.panel3.TabIndex = 15;
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold);
			this.label12.Location = new global::System.Drawing.Point(12, 5);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(79, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "UnitData";
			this.panel15.Controls.Add(this.label13);
			this.panel15.Controls.Add(this.splitter8);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel15.Location = new global::System.Drawing.Point(0, 609);
			this.panel15.Name = "panel15";
			this.panel15.Size = new global::System.Drawing.Size(1331, 32);
			this.panel15.TabIndex = 21;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(497, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(368, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.splitter8.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter8.Location = new global::System.Drawing.Point(0, 0);
			this.splitter8.Name = "splitter8";
			this.splitter8.Size = new global::System.Drawing.Size(1331, 3);
			this.splitter8.TabIndex = 14;
			this.splitter8.TabStop = false;
			this.panel7.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.btnRawData);
			this.panel7.Controls.Add(this.btnNewDoc);
			this.panel7.Controls.Add(this.btnLotLoad);
			this.panel7.Controls.Add(this.btnSNLoad);
			this.panel7.Controls.Add(this.rdoSN);
			this.panel7.Controls.Add(this.btnLotSearch);
			this.panel7.Controls.Add(this.radLabel5);
			this.panel7.Controls.Add(this.rdoDate);
			this.panel7.Controls.Add(this.txtSN);
			this.panel7.Controls.Add(this.chkcmb_Product);
			this.panel7.Controls.Add(this.rdoLot);
			this.panel7.Controls.Add(this.txtLot);
			this.panel7.Controls.Add(this.dateTimeEnd);
			this.panel7.Controls.Add(this.dateTimeStart);
			this.panel7.Controls.Add(this.label1);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 1);
			this.panel7.Size = new global::System.Drawing.Size(298, 134);
			this.panel7.TabIndex = 4;
			this.btnRawData.Location = new global::System.Drawing.Point(167, 105);
			this.btnRawData.Name = "btnRawData";
			this.btnRawData.Size = new global::System.Drawing.Size(63, 22);
			this.btnRawData.TabIndex = 100;
			this.btnRawData.Text = "Raw data";
			this.btnRawData.ThemeName = "TelerikMetroBlue";
			this.btnRawData.Click += new global::System.EventHandler(this.btnRawData_Click);
			this.btnNewDoc.Location = new global::System.Drawing.Point(3, 105);
			this.btnNewDoc.Name = "btnNewDoc";
			this.btnNewDoc.Size = new global::System.Drawing.Size(105, 22);
			this.btnNewDoc.TabIndex = 99;
			this.btnNewDoc.Text = "New Document";
			this.btnNewDoc.ThemeName = "TelerikMetroBlue";
			this.btnNewDoc.Click += new global::System.EventHandler(this.btnNewDoc_Click);
			this.btnLotLoad.Location = new global::System.Drawing.Point(254, 27);
			this.btnLotLoad.Name = "btnLotLoad";
			this.btnLotLoad.Size = new global::System.Drawing.Size(39, 22);
			this.btnLotLoad.TabIndex = 98;
			this.btnLotLoad.Text = "Load";
			this.btnLotLoad.ThemeName = "TelerikMetroBlue";
			this.btnLotLoad.Click += new global::System.EventHandler(this.btnLotLoad_Click);
			this.btnSNLoad.Location = new global::System.Drawing.Point(254, 53);
			this.btnSNLoad.Name = "btnSNLoad";
			this.btnSNLoad.Size = new global::System.Drawing.Size(39, 22);
			this.btnSNLoad.TabIndex = 19;
			this.btnSNLoad.Text = "Load";
			this.btnSNLoad.ThemeName = "TelerikMetroBlue";
			this.btnSNLoad.Click += new global::System.EventHandler(this.btnLoad_Click);
			this.rdoSN.Location = new global::System.Drawing.Point(3, 54);
			this.rdoSN.Name = "rdoSN";
			this.rdoSN.Size = new global::System.Drawing.Size(35, 18);
			this.rdoSN.TabIndex = 22;
			this.rdoSN.TabStop = false;
			this.rdoSN.Text = "SN";
			this.rdoSN.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.rdoSN_ToggleStateChanged);
			this.btnLotSearch.Location = new global::System.Drawing.Point(236, 105);
			this.btnLotSearch.Name = "btnLotSearch";
			this.btnLotSearch.Size = new global::System.Drawing.Size(57, 22);
			this.btnLotSearch.TabIndex = 2;
			this.btnLotSearch.Text = "Search";
			this.btnLotSearch.ThemeName = "TelerikMetroBlue";
			this.btnLotSearch.Click += new global::System.EventHandler(this.btnLotSearch_Click);
			this.radLabel5.Location = new global::System.Drawing.Point(3, 81);
			this.radLabel5.Name = "radLabel5";
			this.radLabel5.Size = new global::System.Drawing.Size(45, 18);
			this.radLabel5.TabIndex = 18;
			this.radLabel5.Text = "Product";
			this.rdoDate.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.rdoDate.Location = new global::System.Drawing.Point(3, 4);
			this.rdoDate.Name = "rdoDate";
			this.rdoDate.Size = new global::System.Drawing.Size(44, 18);
			this.rdoDate.TabIndex = 97;
			this.rdoDate.TabStop = false;
			this.rdoDate.Text = "Date";
			this.rdoDate.ToggleState = global::Telerik.WinControls.Enumerations.ToggleState.On;
			this.rdoDate.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.rdoDate_ToggleStateChanged);
			this.txtSN.Location = new global::System.Drawing.Point(50, 53);
			this.txtSN.Name = "txtSN";
			this.txtSN.Size = new global::System.Drawing.Size(198, 20);
			this.txtSN.TabIndex = 21;
			this.chkcmb_Product.DefaultItemsCountInDropDown = 15;
			this.chkcmb_Product.Location = new global::System.Drawing.Point(50, 79);
			this.chkcmb_Product.MaxDropDownItems = 50;
			this.chkcmb_Product.Name = "chkcmb_Product";
			this.chkcmb_Product.Size = new global::System.Drawing.Size(243, 20);
			this.chkcmb_Product.TabIndex = 17;
			this.chkcmb_Product.ItemCheckedChanged += new global::Telerik.WinControls.UI.RadCheckedListDataItemEventHandler(this.chkcmb_Product_ItemCheckedChanged);
			this.chkcmb_Product.SelectedValueChanged += new global::System.EventHandler(this.chkcmb_Product_SelectedValueChanged);
			this.rdoLot.Location = new global::System.Drawing.Point(3, 28);
			this.rdoLot.Name = "rdoLot";
			this.rdoLot.Size = new global::System.Drawing.Size(36, 18);
			this.rdoLot.TabIndex = 20;
			this.rdoLot.TabStop = false;
			this.rdoLot.Text = "Lot";
			this.rdoLot.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.rdoLot_ToggleStateChanged);
			this.txtLot.Location = new global::System.Drawing.Point(50, 27);
			this.txtLot.Name = "txtLot";
			this.txtLot.Size = new global::System.Drawing.Size(198, 20);
			this.txtLot.TabIndex = 17;
			this.txtLot.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtLot_KeyPress);
			this.dateTimeEnd.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimeEnd.Location = new global::System.Drawing.Point(162, 3);
			this.dateTimeEnd.Name = "dateTimeEnd";
			this.dateTimeEnd.Size = new global::System.Drawing.Size(86, 20);
			this.dateTimeEnd.TabIndex = 85;
			this.dateTimeEnd.TabStop = false;
			this.dateTimeEnd.Text = "2020-04-03";
			this.dateTimeEnd.Value = new global::System.DateTime(2020, 4, 3, 15, 36, 44, 994);
			this.dateTimeEnd.ValueChanged += new global::System.EventHandler(this.dateTimeEnd_ValueChanged);
			this.dateTimeStart.CustomFormat = "yyyy-MM-dd";
			this.dateTimeStart.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimeStart.Location = new global::System.Drawing.Point(50, 3);
			this.dateTimeStart.Name = "dateTimeStart";
			this.dateTimeStart.Size = new global::System.Drawing.Size(85, 20);
			this.dateTimeStart.TabIndex = 84;
			this.dateTimeStart.TabStop = false;
			this.dateTimeStart.Text = "2020-04-03";
			this.dateTimeStart.Value = new global::System.DateTime(2020, 4, 3, 0, 0, 0, 0);
			this.dateTimeStart.ValueChanged += new global::System.EventHandler(this.dateTimeStart_ValueChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(141, 4);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(15, 15);
			this.label1.TabIndex = 90;
			this.label1.Text = "~";
			this.radcmb_DateType.Location = new global::System.Drawing.Point(72, 37);
			this.radcmb_DateType.Name = "radcmb_DateType";
			this.radcmb_DateType.Size = new global::System.Drawing.Size(55, 20);
			this.radcmb_DateType.TabIndex = 95;
			this.radcmb_DateType.Visible = false;
			this.radLabel9.Location = new global::System.Drawing.Point(11, 87);
			this.radLabel9.Name = "radLabel9";
			this.radLabel9.Size = new global::System.Drawing.Size(39, 18);
			this.radLabel9.TabIndex = 92;
			this.radLabel9.Text = "Device";
			this.radLabel9.Visible = false;
			this.radcmb_Device.DefaultItemsCountInDropDown = 15;
			this.radcmb_Device.Location = new global::System.Drawing.Point(72, 87);
			this.radcmb_Device.Name = "radcmb_Device";
			this.radcmb_Device.Size = new global::System.Drawing.Size(151, 20);
			this.radcmb_Device.TabIndex = 93;
			this.radcmb_Device.Visible = false;
			this.radLabel1.Location = new global::System.Drawing.Point(11, 63);
			this.radLabel1.Name = "radLabel1";
			this.radLabel1.Size = new global::System.Drawing.Size(55, 18);
			this.radLabel1.TabIndex = 1;
			this.radLabel1.Text = "Customer";
			this.radLabel1.Visible = false;
			this.radchkcmb_Customer.DefaultItemsCountInDropDown = 20;
			this.radchkcmb_Customer.Location = new global::System.Drawing.Point(72, 63);
			this.radchkcmb_Customer.MaxDropDownItems = 50;
			this.radchkcmb_Customer.Name = "radchkcmb_Customer";
			this.radchkcmb_Customer.Size = new global::System.Drawing.Size(151, 20);
			this.radchkcmb_Customer.TabIndex = 1;
			this.radchkcmb_Customer.Visible = false;
			this.radchkcmb_Customer.ItemCheckedChanged += new global::Telerik.WinControls.UI.RadCheckedListDataItemEventHandler(this.radchkcmb_Customer_ItemCheckedChanged);
			this.splitter4.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter4.Location = new global::System.Drawing.Point(0, 134);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new global::System.Drawing.Size(298, 5);
			this.splitter4.TabIndex = 5;
			this.splitter4.TabStop = false;
			this.splitter4.Visible = false;
			this.panelInfo.Controls.Add(this.panel8);
			this.panelInfo.Controls.Add(this.splitter2);
			this.panelInfo.Controls.Add(this.panel6);
			this.panelInfo.Controls.Add(this.splitter4);
			this.panelInfo.Controls.Add(this.panel7);
			this.panelInfo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelInfo.Location = new global::System.Drawing.Point(0, 0);
			this.panelInfo.Name = "panelInfo";
			this.panelInfo.Size = new global::System.Drawing.Size(298, 547);
			this.panelInfo.TabIndex = 16;
			this.panel8.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel8.Controls.Add(this.grid_Lot);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new global::System.Drawing.Point(0, 177);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 1);
			this.panel8.Size = new global::System.Drawing.Size(298, 370);
			this.panel8.TabIndex = 13;
			this.grid_Lot.Controls.Add(this.radLabel1);
			this.grid_Lot.Controls.Add(this.radchkcmb_Customer);
			this.grid_Lot.Controls.Add(this.radcmb_Device);
			this.grid_Lot.Controls.Add(this.radLabel9);
			this.grid_Lot.Controls.Add(this.radcmb_DateType);
			this.grid_Lot.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_Lot.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.grid_Lot.Location = new global::System.Drawing.Point(3, 1);
			this.grid_Lot.MasterTemplate.AllowAddNewRow = false;
			this.grid_Lot.MasterTemplate.MultiSelect = true;
			this.grid_Lot.Name = "grid_Lot";
			this.grid_Lot.Size = new global::System.Drawing.Size(290, 366);
			this.grid_Lot.TabIndex = 14;
			this.grid_Lot.Text = "radGridView1";
			this.grid_Lot.CellClick += new global::Telerik.WinControls.UI.GridViewCellEventHandler(this.grid_Lot_CellClick);
			this.splitter2.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new global::System.Drawing.Point(0, 172);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new global::System.Drawing.Size(298, 5);
			this.splitter2.TabIndex = 11;
			this.splitter2.TabStop = false;
			this.splitter2.Visible = false;
			this.panel6.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.grid_Device);
			this.panel6.Controls.Add(this.panel11);
			this.panel6.Controls.Add(this.panel14);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new global::System.Drawing.Point(0, 139);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 1);
			this.panel6.Size = new global::System.Drawing.Size(298, 33);
			this.panel6.TabIndex = 10;
			this.panel6.Visible = false;
			this.grid_Device.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_Device.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.grid_Device.Location = new global::System.Drawing.Point(3, 51);
			this.grid_Device.Name = "grid_Device";
			this.grid_Device.Size = new global::System.Drawing.Size(290, 0);
			this.grid_Device.TabIndex = 14;
			this.grid_Device.Text = "radGridView2";
			this.panel11.Controls.Add(this.txtDevice);
			this.panel11.Controls.Add(this.btnDeviceSearch);
			this.panel11.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new global::System.Drawing.Point(3, 24);
			this.panel11.Name = "panel11";
			this.panel11.Size = new global::System.Drawing.Size(290, 27);
			this.panel11.TabIndex = 4;
			this.txtDevice.Location = new global::System.Drawing.Point(4, 5);
			this.txtDevice.Name = "txtDevice";
			this.txtDevice.Size = new global::System.Drawing.Size(218, 20);
			this.txtDevice.TabIndex = 1;
			this.btnDeviceSearch.Location = new global::System.Drawing.Point(228, 3);
			this.btnDeviceSearch.Name = "btnDeviceSearch";
			this.btnDeviceSearch.Size = new global::System.Drawing.Size(57, 24);
			this.btnDeviceSearch.TabIndex = 1;
			this.btnDeviceSearch.Text = "Search";
			this.btnDeviceSearch.ThemeName = "TelerikMetroBlue";
			this.btnDeviceSearch.Click += new global::System.EventHandler(this.btnDeviceSearch_Click);
			this.panel14.Controls.Add(this.radLabel6);
			this.panel14.Controls.Add(this.rdoProd);
			this.panel14.Controls.Add(this.rdoENick);
			this.panel14.Controls.Add(this.rdoDevice);
			this.panel14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new global::System.Drawing.Point(3, 1);
			this.panel14.Name = "panel14";
			this.panel14.Size = new global::System.Drawing.Size(290, 23);
			this.panel14.TabIndex = 13;
			this.radLabel6.Location = new global::System.Drawing.Point(4, 3);
			this.radLabel6.Name = "radLabel6";
			this.radLabel6.Size = new global::System.Drawing.Size(72, 18);
			this.radLabel6.TabIndex = 19;
			this.radLabel6.Text = "Dev Option : ";
			this.rdoProd.Location = new global::System.Drawing.Point(231, 3);
			this.rdoProd.Name = "rdoProd";
			this.rdoProd.Size = new global::System.Drawing.Size(44, 18);
			this.rdoProd.TabIndex = 3;
			this.rdoProd.TabStop = false;
			this.rdoProd.Text = "Prod";
			this.rdoENick.Location = new global::System.Drawing.Point(147, 3);
			this.rdoENick.Name = "rdoENick";
			this.rdoENick.Size = new global::System.Drawing.Size(76, 18);
			this.rdoENick.TabIndex = 2;
			this.rdoENick.TabStop = false;
			this.rdoENick.Text = "eMes(Nick)";
			this.rdoDevice.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.rdoDevice.Location = new global::System.Drawing.Point(86, 3);
			this.rdoDevice.Name = "rdoDevice";
			this.rdoDevice.Size = new global::System.Drawing.Size(53, 18);
			this.rdoDevice.TabIndex = 1;
			this.rdoDevice.Text = "Device";
			this.rdoDevice.ToggleState = global::Telerik.WinControls.Enumerations.ToggleState.On;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.radDock1.ActiveWindow = this.toolWindow1;
			this.radDock1.CausesValidation = false;
			this.radDock1.Controls.Add(this.toolTabStrip3);
			this.radDock1.Controls.Add(this.documentContainer1);
			this.radDock1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radDock1.IsCleanUpTarget = true;
			this.radDock1.Location = new global::System.Drawing.Point(0, 30);
			this.radDock1.MainDocumentContainer = this.documentContainer1;
			this.radDock1.Name = "radDock1";
			this.radDock1.Padding = new global::System.Windows.Forms.Padding(0);
			this.radDock1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.radDock1.Size = new global::System.Drawing.Size(1331, 579);
			this.radDock1.TabIndex = 24;
			this.radDock1.TabStop = false;
			this.radDock1.Text = "radDock1";
			this.radDock1.ThemeName = "TelerikMetroBlue";
			this.toolWindow1.Caption = null;
			this.toolWindow1.Controls.Add(this.panelInfo);
			this.toolWindow1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.toolWindow1.Location = new global::System.Drawing.Point(1, 30);
			this.toolWindow1.Name = "toolWindow1";
			this.toolWindow1.PreviousDockState = global::Telerik.WinControls.UI.Docking.DockState.Docked;
			this.toolWindow1.Size = new global::System.Drawing.Size(298, 547);
			this.toolWindow1.Text = "Search";
			this.toolWindow1.ToolCaptionButtons = global::Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.AutoHide;
			this.toolTabStrip3.CanUpdateChildIndex = true;
			this.toolTabStrip3.Controls.Add(this.toolWindow1);
			this.toolTabStrip3.Location = new global::System.Drawing.Point(0, 0);
			this.toolTabStrip3.Name = "toolTabStrip3";
			this.toolTabStrip3.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.toolTabStrip3.SelectedIndex = 0;
			this.toolTabStrip3.Size = new global::System.Drawing.Size(300, 579);
			this.toolTabStrip3.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(300, 200);
			this.toolTabStrip3.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(100, 0);
			this.toolTabStrip3.TabIndex = 6;
			this.toolTabStrip3.TabStop = false;
			this.toolTabStrip3.ThemeName = "TelerikMetroBlue";
			this.documentContainer1.Name = "documentContainer1";
			this.documentContainer1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.documentContainer1.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(917, 200);
			this.documentContainer1.SizeInfo.SizeMode = global::Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
			this.documentContainer1.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(106, 0);
			this.documentContainer1.TabIndex = 2;
			this.documentContainer1.ThemeName = "TelerikMetroBlue";
			this.documentWindow2.CloseAction = global::Telerik.WinControls.UI.Docking.DockWindowCloseAction.Hide;
			this.documentWindow2.DesiredDockState = global::Telerik.WinControls.UI.Docking.DockState.Hidden;
			this.documentWindow2.DocumentButtons = global::Telerik.WinControls.UI.Docking.DocumentStripButtons.ActiveWindowList;
			this.documentWindow2.Location = new global::System.Drawing.Point(6, 29);
			this.documentWindow2.Name = "documentWindow2";
			this.documentWindow2.PreviousDockState = global::Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
			this.documentWindow2.Size = new global::System.Drawing.Size(752, 466);
			this.documentWindow2.Text = "documentWindow2";
			this.documentTabStrip1.CanUpdateChildIndex = true;
			this.documentTabStrip1.Controls.Add(this.documentWindow1);
			this.documentTabStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.documentTabStrip1.Name = "documentTabStrip1";
			this.documentTabStrip1.RootElement.MinSize = new global::System.Drawing.Size(25, 25);
			this.documentTabStrip1.SelectedIndex = 0;
			this.documentTabStrip1.Size = new global::System.Drawing.Size(742, 501);
			this.documentTabStrip1.TabIndex = 0;
			this.documentTabStrip1.TabStop = false;
			this.documentWindow1.DocumentButtons = global::Telerik.WinControls.UI.Docking.DocumentStripButtons.ActiveWindowList;
			this.documentWindow1.Location = new global::System.Drawing.Point(4, 4);
			this.documentWindow1.Name = "documentWindow1";
			this.documentWindow1.PreviousDockState = global::Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
			this.documentWindow1.Size = new global::System.Drawing.Size(734, 493);
			this.documentWindow1.Text = "documentWindow1";
			this.toolTabStrip2.CanUpdateChildIndex = true;
			this.toolTabStrip2.Location = new global::System.Drawing.Point(0, 0);
			this.toolTabStrip2.Name = "toolTabStrip2";
			this.toolTabStrip2.RootElement.MinSize = new global::System.Drawing.Size(25, 25);
			this.toolTabStrip2.SelectedIndex = 0;
			this.toolTabStrip2.Size = new global::System.Drawing.Size(200, 200);
			this.toolTabStrip2.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(296, 200);
			this.toolTabStrip2.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(96, 0);
			this.toolTabStrip2.TabIndex = 0;
			this.toolTabStrip2.TabStop = false;
			this.toolTabStrip2.ThemeName = "TelerikMetroBlue";
			this.toolTabStrip1.CanUpdateChildIndex = true;
			this.toolTabStrip1.CausesValidation = false;
			this.toolTabStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.toolTabStrip1.Name = "toolTabStrip1";
			this.toolTabStrip1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.toolTabStrip1.Size = new global::System.Drawing.Size(296, 579);
			this.toolTabStrip1.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(296, 200);
			this.toolTabStrip1.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(96, 0);
			this.toolTabStrip1.TabIndex = 3;
			this.toolTabStrip1.TabStop = false;
			this.toolTabStrip1.ThemeName = "TelerikMetroBlue";
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.toolTabStrip1.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.FromArgb(0, 156, 20, 20);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.toolTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			this.toolTabStrip5.CanUpdateChildIndex = true;
			this.toolTabStrip5.Location = new global::System.Drawing.Point(0, 0);
			this.toolTabStrip5.Name = "toolTabStrip5";
			this.toolTabStrip5.RootElement.MinSize = new global::System.Drawing.Size(25, 25);
			this.toolTabStrip5.SelectedIndex = 0;
			this.toolTabStrip5.Size = new global::System.Drawing.Size(200, 200);
			this.toolTabStrip5.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(296, 200);
			this.toolTabStrip5.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(96, 0);
			this.toolTabStrip5.TabIndex = 0;
			this.toolTabStrip5.TabStop = false;
			this.toolTabStrip5.ThemeName = "TelerikMetroBlue";
			this.toolTabStrip6.CanUpdateChildIndex = true;
			this.toolTabStrip6.Location = new global::System.Drawing.Point(0, 0);
			this.toolTabStrip6.Name = "toolTabStrip6";
			this.toolTabStrip6.RootElement.MinSize = new global::System.Drawing.Size(25, 25);
			this.toolTabStrip6.SelectedIndex = 0;
			this.toolTabStrip6.Size = new global::System.Drawing.Size(200, 200);
			this.toolTabStrip6.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(106, 200);
			this.toolTabStrip6.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(-94, 0);
			this.toolTabStrip6.TabIndex = 0;
			this.toolTabStrip6.TabStop = false;
			this.toolTabStrip6.ThemeName = "TelerikMetroBlue";
			this.openFileDialog1.FileName = "openFileDialog1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1331, 641);
			base.Controls.Add(this.radDock1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel15);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Name = "UnitDataAnalysis";
			this.Text = "UnitData";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.UnitDataAnalysis_FormClosing);
			base.Load += new global::System.EventHandler(this.ParameterAnalysis_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnRawData).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnNewDoc).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnLotLoad).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnSNLoad).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoSN).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnLotSearch).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoDate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.txtSN).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.chkcmb_Product).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoLot).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.txtLot).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dateTimeEnd).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dateTimeStart).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radcmb_DateType).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel9).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radcmb_Device).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radchkcmb_Customer).EndInit();
			this.panelInfo.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.grid_Lot.MasterTemplate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.grid_Lot).EndInit();
			this.grid_Lot.ResumeLayout(false);
			this.grid_Lot.PerformLayout();
			this.panel6.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.grid_Device.MasterTemplate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.grid_Device).EndInit();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.txtDevice).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnDeviceSearch).EndInit();
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radLabel6).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoProd).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoENick).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoDevice).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radDock1).EndInit();
			this.radDock1.ResumeLayout(false);
			this.toolWindow1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip3).EndInit();
			this.toolTabStrip3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.documentContainer1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.documentTabStrip1).EndInit();
			this.documentTabStrip1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.toolTabStrip6).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400009C RID: 156
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.Splitter splitter8;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.Splitter splitter4;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Panel panelInfo;

		// Token: 0x040000A6 RID: 166
		private global::System.ComponentModel.BackgroundWorker backgroundWorker1;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.Panel panel14;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.Splitter splitter2;

		// Token: 0x040000AC RID: 172
		private global::Telerik.WinControls.UI.RadGridView grid_Device;

		// Token: 0x040000AD RID: 173
		private global::Telerik.WinControls.UI.RadCheckedDropDownList radchkcmb_Customer;

		// Token: 0x040000AE RID: 174
		private global::Telerik.WinControls.UI.RadDateTimePicker dateTimeEnd;

		// Token: 0x040000AF RID: 175
		private global::Telerik.WinControls.UI.RadDateTimePicker dateTimeStart;

		// Token: 0x040000B0 RID: 176
		private global::Telerik.WinControls.UI.RadLabel radLabel1;

		// Token: 0x040000B1 RID: 177
		private global::Telerik.WinControls.UI.RadRadioButton rdoProd;

		// Token: 0x040000B2 RID: 178
		private global::Telerik.WinControls.UI.RadRadioButton rdoENick;

		// Token: 0x040000B3 RID: 179
		private global::Telerik.WinControls.UI.RadRadioButton rdoDevice;

		// Token: 0x040000B4 RID: 180
		private global::Telerik.WinControls.UI.RadButton btnDeviceSearch;

		// Token: 0x040000B5 RID: 181
		private global::Telerik.WinControls.UI.RadLabel radLabel6;

		// Token: 0x040000B6 RID: 182
		private global::Telerik.WinControls.UI.RadTextBox txtDevice;

		// Token: 0x040000B7 RID: 183
		private global::Telerik.WinControls.UI.Docking.RadDock radDock1;

		// Token: 0x040000B8 RID: 184
		private global::Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;

		// Token: 0x040000B9 RID: 185
		private global::Telerik.WinControls.UI.Docking.ToolWindow toolWindow1;

		// Token: 0x040000BA RID: 186
		private global::Telerik.WinControls.RadThemeManager radThemeManager1;

		// Token: 0x040000BB RID: 187
		private global::Telerik.WinControls.UI.Docking.DocumentWindow documentWindow2;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x040000BD RID: 189
		private global::Telerik.WinControls.UI.RadGridView grid_Lot;

		// Token: 0x040000BE RID: 190
		private global::Telerik.WinControls.UI.RadTextBox txtLot;

		// Token: 0x040000BF RID: 191
		private global::Telerik.WinControls.UI.RadLabel radLabel5;

		// Token: 0x040000C0 RID: 192
		private global::Telerik.WinControls.UI.RadButton btnLotSearch;

		// Token: 0x040000C1 RID: 193
		private global::Telerik.WinControls.UI.RadCheckedDropDownList chkcmb_Product;

		// Token: 0x040000C2 RID: 194
		private global::Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;

		// Token: 0x040000C3 RID: 195
		private global::Telerik.WinControls.UI.Docking.DocumentWindow documentWindow1;

		// Token: 0x040000C4 RID: 196
		private global::Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;

		// Token: 0x040000C5 RID: 197
		private global::Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;

		// Token: 0x040000C6 RID: 198
		private global::Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;

		// Token: 0x040000C7 RID: 199
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip2;

		// Token: 0x040000C8 RID: 200
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;

		// Token: 0x040000C9 RID: 201
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip5;

		// Token: 0x040000CA RID: 202
		private global::Telerik.WinControls.UI.RadLabel radLabel9;

		// Token: 0x040000CB RID: 203
		private global::Telerik.WinControls.UI.RadDropDownList radcmb_Device;

		// Token: 0x040000CC RID: 204
		private global::Telerik.WinControls.UI.RadDropDownList radcmb_DateType;

		// Token: 0x040000CD RID: 205
		private global::Telerik.WinControls.UI.RadButton btnSNLoad;

		// Token: 0x040000CE RID: 206
		private global::Telerik.WinControls.UI.RadRadioButton rdoSN;

		// Token: 0x040000CF RID: 207
		private global::Telerik.WinControls.UI.RadRadioButton rdoDate;

		// Token: 0x040000D0 RID: 208
		private global::Telerik.WinControls.UI.RadTextBox txtSN;

		// Token: 0x040000D1 RID: 209
		private global::Telerik.WinControls.UI.RadRadioButton rdoLot;

		// Token: 0x040000D2 RID: 210
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip3;

		// Token: 0x040000D3 RID: 211
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip6;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.OpenFileDialog openFileDialog1;

		// Token: 0x040000D5 RID: 213
		private global::Telerik.WinControls.UI.RadButton btnLotLoad;

		// Token: 0x040000D6 RID: 214
		private global::Telerik.WinControls.UI.RadButton btnNewDoc;

		// Token: 0x040000D7 RID: 215
		private global::Telerik.WinControls.UI.RadButton btnRawData;
	}
}
