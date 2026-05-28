namespace Amkor.CADModules.RELUnitDataProcModule
{
	// Token: 0x0200000E RID: 14
	public partial class UnitDataAnalysis : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x0600007C RID: 124 RVA: 0x00004EC4 File Offset: 0x000030C4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00004EFC File Offset: 0x000030FC
		private void InitializeComponent()
		{
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label12 = new global::System.Windows.Forms.Label();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.splitter8 = new global::System.Windows.Forms.Splitter();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.panel12 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel9 = new global::System.Windows.Forms.TableLayoutPanel();
			this.btnLotSearch = new global::Telerik.WinControls.UI.RadButton();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel8 = new global::System.Windows.Forms.TableLayoutPanel();
			this.radPanel15 = new global::Telerik.WinControls.UI.RadPanel();
			this.cboProduct = new global::Telerik.WinControls.UI.RadCheckedDropDownList();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel7 = new global::System.Windows.Forms.TableLayoutPanel();
			this.btnLotSNLoad = new global::Telerik.WinControls.UI.RadButton();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel6 = new global::System.Windows.Forms.TableLayoutPanel();
			this.radPanel14 = new global::Telerik.WinControls.UI.RadPanel();
			this.txtSN = new global::Telerik.WinControls.UI.RadTextBox();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel5 = new global::System.Windows.Forms.TableLayoutPanel();
			this.txtLot = new global::Telerik.WinControls.UI.RadTextBox();
			this.radPanel13 = new global::Telerik.WinControls.UI.RadPanel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel4 = new global::System.Windows.Forms.TableLayoutPanel();
			this.dtmEndTime = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel3 = new global::System.Windows.Forms.TableLayoutPanel();
			this.dtmStartTime = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.radPanel12 = new global::Telerik.WinControls.UI.RadPanel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel2 = new global::System.Windows.Forms.TableLayoutPanel();
			this.radPanel3 = new global::Telerik.WinControls.UI.RadPanel();
			this.rdoSN = new global::Telerik.WinControls.UI.RadRadioButton();
			this.rdoLot = new global::Telerik.WinControls.UI.RadRadioButton();
			this.rdoDate = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radPanel11 = new global::Telerik.WinControls.UI.RadPanel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.btnNewDoc = new global::Telerik.WinControls.UI.RadButton();
			this.panelInfo = new global::System.Windows.Forms.Panel();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.grdLot = new global::Telerik.WinControls.UI.RadGridView();
			this.radDock1 = new global::Telerik.WinControls.UI.Docking.RadDock();
			this.toolWindow1 = new global::Telerik.WinControls.UI.Docking.ToolWindow();
			this.toolTabStrip3 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.documentContainer1 = new global::Telerik.WinControls.UI.Docking.DocumentContainer();
			this.documentWindow2 = new global::Telerik.WinControls.UI.Docking.DocumentWindow();
			this.documentTabStrip1 = new global::Telerik.WinControls.UI.Docking.DocumentTabStrip();
			this.documentWindow1 = new global::Telerik.WinControls.UI.Docking.DocumentWindow();
			this.toolTabStrip2 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.toolTabStrip1 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.toolTabStrip5 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.toolTabStrip6 = new global::Telerik.WinControls.UI.Docking.ToolTabStrip();
			this.panel3.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel12.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnLotSearch).BeginInit();
			this.panel11.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel15).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cboProduct).BeginInit();
			this.panel10.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnLotSNLoad).BeginInit();
			this.panel9.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel14).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.txtSN).BeginInit();
			this.panel6.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.txtLot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel13).BeginInit();
			this.panel5.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dtmEndTime).BeginInit();
			this.panel4.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dtmStartTime).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel12).BeginInit();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel3).BeginInit();
			this.radPanel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.rdoSN).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoLot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoDate).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel11).BeginInit();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnNewDoc).BeginInit();
			this.panelInfo.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.grdLot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.grdLot.MasterTemplate).BeginInit();
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
			this.label12.Size = new global::System.Drawing.Size(110, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "REL UnitData";
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
			this.panel7.BackColor = global::System.Drawing.Color.Transparent;
			this.panel7.Controls.Add(this.panel12);
			this.panel7.Controls.Add(this.panel11);
			this.panel7.Controls.Add(this.panel10);
			this.panel7.Controls.Add(this.panel9);
			this.panel7.Controls.Add(this.panel6);
			this.panel7.Controls.Add(this.panel5);
			this.panel7.Controls.Add(this.panel4);
			this.panel7.Controls.Add(this.panel2);
			this.panel7.Controls.Add(this.panel1);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 1);
			this.panel7.Size = new global::System.Drawing.Size(378, 291);
			this.panel7.TabIndex = 4;
			this.panel12.Controls.Add(this.tableLayoutPanel9);
			this.panel12.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel12.Location = new global::System.Drawing.Point(3, 257);
			this.panel12.Name = "panel12";
			this.panel12.Size = new global::System.Drawing.Size(372, 32);
			this.panel12.TabIndex = 116;
			this.tableLayoutPanel9.ColumnCount = 2;
			this.tableLayoutPanel9.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel9.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel9.Controls.Add(this.btnLotSearch, 0, 0);
			this.tableLayoutPanel9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel9.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel9.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel9.Size = new global::System.Drawing.Size(372, 32);
			this.tableLayoutPanel9.TabIndex = 0;
			this.tableLayoutPanel9.SetColumnSpan(this.btnLotSearch, 2);
			this.btnLotSearch.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnLotSearch.Location = new global::System.Drawing.Point(3, 3);
			this.btnLotSearch.Name = "btnLotSearch";
			this.btnLotSearch.Size = new global::System.Drawing.Size(366, 26);
			this.btnLotSearch.TabIndex = 2;
			this.btnLotSearch.Text = "Search";
			this.btnLotSearch.ThemeName = "CIMitarAdmin_Skin";
			this.panel11.Controls.Add(this.tableLayoutPanel8);
			this.panel11.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new global::System.Drawing.Point(3, 225);
			this.panel11.Name = "panel11";
			this.panel11.Size = new global::System.Drawing.Size(372, 32);
			this.panel11.TabIndex = 115;
			this.tableLayoutPanel8.ColumnCount = 2;
			this.tableLayoutPanel8.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel8.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel8.Controls.Add(this.radPanel15, 0, 0);
			this.tableLayoutPanel8.Controls.Add(this.cboProduct, 1, 0);
			this.tableLayoutPanel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel8.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 1;
			this.tableLayoutPanel8.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel8.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel8.Size = new global::System.Drawing.Size(372, 32);
			this.tableLayoutPanel8.TabIndex = 0;
			this.radPanel15.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel15.Location = new global::System.Drawing.Point(3, 3);
			this.radPanel15.Name = "radPanel15";
			this.radPanel15.Size = new global::System.Drawing.Size(180, 26);
			this.radPanel15.TabIndex = 5;
			this.radPanel15.Text = "Family Name";
			this.radPanel15.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radPanel15.ThemeName = "CIMitarAdmin_Skin";
			this.cboProduct.DefaultItemsCountInDropDown = 15;
			this.cboProduct.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cboProduct.Location = new global::System.Drawing.Point(189, 3);
			this.cboProduct.MaxDropDownItems = 50;
			this.cboProduct.Name = "cboProduct";
			this.cboProduct.Padding = new global::System.Windows.Forms.Padding(2, 2, 2, 3);
			this.cboProduct.Size = new global::System.Drawing.Size(180, 25);
			this.cboProduct.TabIndex = 17;
			this.cboProduct.ThemeName = "CIMitarAdmin_Skin";
			this.panel10.Controls.Add(this.tableLayoutPanel7);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new global::System.Drawing.Point(3, 193);
			this.panel10.Name = "panel10";
			this.panel10.Size = new global::System.Drawing.Size(372, 32);
			this.panel10.TabIndex = 114;
			this.tableLayoutPanel7.ColumnCount = 2;
			this.tableLayoutPanel7.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel7.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel7.Controls.Add(this.btnLotSNLoad, 0, 0);
			this.tableLayoutPanel7.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel7.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel7.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel7.Size = new global::System.Drawing.Size(372, 32);
			this.tableLayoutPanel7.TabIndex = 0;
			this.tableLayoutPanel7.SetColumnSpan(this.btnLotSNLoad, 2);
			this.btnLotSNLoad.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnLotSNLoad.Location = new global::System.Drawing.Point(3, 3);
			this.btnLotSNLoad.Name = "btnLotSNLoad";
			this.btnLotSNLoad.Size = new global::System.Drawing.Size(366, 26);
			this.btnLotSNLoad.TabIndex = 98;
			this.btnLotSNLoad.Text = "Lot/SN Load";
			this.btnLotSNLoad.ThemeName = "CIMitarAdmin_Skin";
			this.panel9.Controls.Add(this.tableLayoutPanel6);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new global::System.Drawing.Point(3, 161);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(372, 32);
			this.panel9.TabIndex = 113;
			this.tableLayoutPanel6.ColumnCount = 2;
			this.tableLayoutPanel6.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel6.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel6.Controls.Add(this.radPanel14, 0, 0);
			this.tableLayoutPanel6.Controls.Add(this.txtSN, 1, 0);
			this.tableLayoutPanel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel6.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel6.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel6.Size = new global::System.Drawing.Size(372, 32);
			this.tableLayoutPanel6.TabIndex = 0;
			this.radPanel14.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel14.Location = new global::System.Drawing.Point(3, 3);
			this.radPanel14.Name = "radPanel14";
			this.radPanel14.Size = new global::System.Drawing.Size(180, 26);
			this.radPanel14.TabIndex = 4;
			this.radPanel14.Text = "S/N";
			this.radPanel14.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radPanel14.ThemeName = "CIMitarAdmin_Skin";
			this.txtSN.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txtSN.Location = new global::System.Drawing.Point(189, 3);
			this.txtSN.Name = "txtSN";
			this.txtSN.Padding = new global::System.Windows.Forms.Padding(2, 4, 2, 4);
			this.txtSN.Size = new global::System.Drawing.Size(180, 25);
			this.txtSN.TabIndex = 21;
			this.txtSN.ThemeName = "CIMitarAdmin_Skin";
			this.panel6.Controls.Add(this.tableLayoutPanel5);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new global::System.Drawing.Point(3, 129);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(372, 32);
			this.panel6.TabIndex = 112;
			this.tableLayoutPanel5.ColumnCount = 2;
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel5.Controls.Add(this.txtLot, 1, 0);
			this.tableLayoutPanel5.Controls.Add(this.radPanel13, 0, 0);
			this.tableLayoutPanel5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel5.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel5.Size = new global::System.Drawing.Size(372, 32);
			this.tableLayoutPanel5.TabIndex = 0;
			this.txtLot.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txtLot.Location = new global::System.Drawing.Point(189, 3);
			this.txtLot.Name = "txtLot";
			this.txtLot.Padding = new global::System.Windows.Forms.Padding(2, 4, 2, 4);
			this.txtLot.Size = new global::System.Drawing.Size(180, 25);
			this.txtLot.TabIndex = 17;
			this.txtLot.ThemeName = "CIMitarAdmin_Skin";
			this.radPanel13.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel13.Location = new global::System.Drawing.Point(3, 3);
			this.radPanel13.Name = "radPanel13";
			this.radPanel13.Size = new global::System.Drawing.Size(180, 26);
			this.radPanel13.TabIndex = 3;
			this.radPanel13.Text = "Lot";
			this.radPanel13.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radPanel13.ThemeName = "CIMitarAdmin_Skin";
			this.panel5.Controls.Add(this.tableLayoutPanel4);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(3, 97);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(372, 32);
			this.panel5.TabIndex = 111;
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel4.Controls.Add(this.dtmEndTime, 1, 0);
			this.tableLayoutPanel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel4.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel4.Size = new global::System.Drawing.Size(372, 32);
			this.tableLayoutPanel4.TabIndex = 0;
			this.dtmEndTime.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dtmEndTime.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dtmEndTime.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtmEndTime.Location = new global::System.Drawing.Point(189, 3);
			this.dtmEndTime.Name = "dtmEndTime";
			this.dtmEndTime.Padding = new global::System.Windows.Forms.Padding(2, 3, 2, 2);
			this.dtmEndTime.Size = new global::System.Drawing.Size(180, 26);
			this.dtmEndTime.TabIndex = 85;
			this.dtmEndTime.TabStop = false;
			this.dtmEndTime.Text = "2020-04-03";
			this.dtmEndTime.ThemeName = "CIMitarAdmin_Skin";
			this.dtmEndTime.Value = new global::System.DateTime(2020, 4, 3, 15, 36, 44, 994);
			this.panel4.Controls.Add(this.tableLayoutPanel3);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(3, 65);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(372, 32);
			this.panel4.TabIndex = 110;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel3.Controls.Add(this.dtmStartTime, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.radPanel12, 0, 0);
			this.tableLayoutPanel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel3.Size = new global::System.Drawing.Size(372, 32);
			this.tableLayoutPanel3.TabIndex = 0;
			this.dtmStartTime.CustomFormat = "yyyy-MM-dd";
			this.dtmStartTime.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dtmStartTime.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dtmStartTime.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtmStartTime.Location = new global::System.Drawing.Point(189, 3);
			this.dtmStartTime.Name = "dtmStartTime";
			this.dtmStartTime.Padding = new global::System.Windows.Forms.Padding(2, 3, 2, 2);
			this.dtmStartTime.Size = new global::System.Drawing.Size(180, 26);
			this.dtmStartTime.TabIndex = 84;
			this.dtmStartTime.TabStop = false;
			this.dtmStartTime.Text = "2020-04-03";
			this.dtmStartTime.ThemeName = "CIMitarAdmin_Skin";
			this.dtmStartTime.Value = new global::System.DateTime(2020, 4, 3, 0, 0, 0, 0);
			this.radPanel12.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel12.Location = new global::System.Drawing.Point(3, 3);
			this.radPanel12.Name = "radPanel12";
			this.radPanel12.Size = new global::System.Drawing.Size(180, 26);
			this.radPanel12.TabIndex = 2;
			this.radPanel12.Text = "Date";
			this.radPanel12.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radPanel12.ThemeName = "CIMitarAdmin_Skin";
			this.panel2.Controls.Add(this.tableLayoutPanel2);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(3, 33);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(372, 32);
			this.panel2.TabIndex = 109;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel2.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel2.Controls.Add(this.radPanel3, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.radPanel11, 0, 0);
			this.tableLayoutPanel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel2.Size = new global::System.Drawing.Size(372, 32);
			this.tableLayoutPanel2.TabIndex = 0;
			this.radPanel3.Controls.Add(this.rdoSN);
			this.radPanel3.Controls.Add(this.rdoLot);
			this.radPanel3.Controls.Add(this.rdoDate);
			this.radPanel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel3.Location = new global::System.Drawing.Point(189, 3);
			this.radPanel3.Name = "radPanel3";
			this.radPanel3.Padding = new global::System.Windows.Forms.Padding(4);
			this.radPanel3.Size = new global::System.Drawing.Size(180, 26);
			this.radPanel3.TabIndex = 102;
			this.radPanel3.ThemeName = "CIMitarAdmin_Skin";
			this.rdoSN.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rdoSN.Location = new global::System.Drawing.Point(84, 4);
			this.rdoSN.Name = "rdoSN";
			this.rdoSN.Size = new global::System.Drawing.Size(35, 18);
			this.rdoSN.TabIndex = 22;
			this.rdoSN.TabStop = false;
			this.rdoSN.Text = "SN";
			this.rdoSN.ThemeName = "CIMitarAdmin_Skin";
			this.rdoLot.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rdoLot.Location = new global::System.Drawing.Point(48, 4);
			this.rdoLot.Name = "rdoLot";
			this.rdoLot.Size = new global::System.Drawing.Size(36, 18);
			this.rdoLot.TabIndex = 20;
			this.rdoLot.TabStop = false;
			this.rdoLot.Text = "Lot";
			this.rdoLot.ThemeName = "CIMitarAdmin_Skin";
			this.rdoDate.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.rdoDate.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.rdoDate.Location = new global::System.Drawing.Point(4, 4);
			this.rdoDate.Name = "rdoDate";
			this.rdoDate.Size = new global::System.Drawing.Size(44, 18);
			this.rdoDate.TabIndex = 97;
			this.rdoDate.TabStop = false;
			this.rdoDate.Text = "Date";
			this.rdoDate.ThemeName = "CIMitarAdmin_Skin";
			this.rdoDate.ToggleState = global::Telerik.WinControls.Enumerations.ToggleState.On;
			this.radPanel11.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radPanel11.Location = new global::System.Drawing.Point(3, 3);
			this.radPanel11.Name = "radPanel11";
			this.radPanel11.Size = new global::System.Drawing.Size(180, 26);
			this.radPanel11.TabIndex = 1;
			this.radPanel11.Text = "Option";
			this.radPanel11.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radPanel11.ThemeName = "CIMitarAdmin_Skin";
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(3, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(372, 32);
			this.panel1.TabIndex = 1;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.btnNewDoc, 0, 0);
			this.tableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel1.Size = new global::System.Drawing.Size(372, 32);
			this.tableLayoutPanel1.TabIndex = 0;
			this.tableLayoutPanel1.SetColumnSpan(this.btnNewDoc, 2);
			this.btnNewDoc.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.btnNewDoc.Location = new global::System.Drawing.Point(3, 3);
			this.btnNewDoc.Name = "btnNewDoc";
			this.btnNewDoc.Size = new global::System.Drawing.Size(366, 26);
			this.btnNewDoc.TabIndex = 99;
			this.btnNewDoc.Text = "New Document";
			this.btnNewDoc.ThemeName = "CIMitarAdmin_Skin";
			this.panelInfo.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelInfo.Controls.Add(this.panel13);
			this.panelInfo.Controls.Add(this.panel7);
			this.panelInfo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelInfo.Location = new global::System.Drawing.Point(0, 0);
			this.panelInfo.Name = "panelInfo";
			this.panelInfo.Size = new global::System.Drawing.Size(380, 543);
			this.panelInfo.TabIndex = 16;
			this.panel13.Controls.Add(this.panel8);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel13.Location = new global::System.Drawing.Point(0, 291);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 1);
			this.panel13.Size = new global::System.Drawing.Size(378, 250);
			this.panel13.TabIndex = 14;
			this.panel8.Controls.Add(this.grdLot);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new global::System.Drawing.Point(3, 1);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new global::System.Windows.Forms.Padding(3, 1, 3, 1);
			this.panel8.Size = new global::System.Drawing.Size(372, 248);
			this.panel8.TabIndex = 13;
			this.grdLot.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grdLot.Location = new global::System.Drawing.Point(3, 1);
			this.grdLot.MasterTemplate.MultiSelect = true;
			this.grdLot.Name = "grdLot";
			this.grdLot.Size = new global::System.Drawing.Size(366, 246);
			this.grdLot.TabIndex = 151;
			this.grdLot.ThemeName = "CIMitarAdmin_Skin";
			this.radDock1.ActiveWindow = this.toolWindow1;
			this.radDock1.CausesValidation = false;
			this.radDock1.Controls.Add(this.toolTabStrip3);
			this.radDock1.Controls.Add(this.documentContainer1);
			this.radDock1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.radDock1.IsCleanUpTarget = true;
			this.radDock1.Location = new global::System.Drawing.Point(0, 30);
			this.radDock1.MainDocumentContainer = this.documentContainer1;
			this.radDock1.Name = "radDock1";
			this.radDock1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.radDock1.Size = new global::System.Drawing.Size(1331, 579);
			this.radDock1.TabIndex = 24;
			this.radDock1.TabStop = false;
			this.radDock1.Text = "radDock1";
			this.radDock1.ThemeName = "CIMitarAdmin_Skin";
			this.toolWindow1.Caption = null;
			this.toolWindow1.Controls.Add(this.panelInfo);
			this.toolWindow1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.toolWindow1.Location = new global::System.Drawing.Point(1, 24);
			this.toolWindow1.Name = "toolWindow1";
			this.toolWindow1.PreviousDockState = global::Telerik.WinControls.UI.Docking.DockState.Docked;
			this.toolWindow1.Size = new global::System.Drawing.Size(380, 543);
			this.toolWindow1.Text = "Condition";
			this.toolWindow1.ToolCaptionButtons = global::Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.AutoHide;
			this.toolTabStrip3.CanUpdateChildIndex = true;
			this.toolTabStrip3.Controls.Add(this.toolWindow1);
			this.toolTabStrip3.Location = new global::System.Drawing.Point(5, 5);
			this.toolTabStrip3.Name = "toolTabStrip3";
			this.toolTabStrip3.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.toolTabStrip3.SelectedIndex = 0;
			this.toolTabStrip3.Size = new global::System.Drawing.Size(382, 569);
			this.toolTabStrip3.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(382, 200);
			this.toolTabStrip3.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(182, 0);
			this.toolTabStrip3.TabIndex = 6;
			this.toolTabStrip3.TabStop = false;
			this.toolTabStrip3.ThemeName = "CIMitarAdmin_Skin";
			this.documentContainer1.Name = "documentContainer1";
			this.documentContainer1.RootElement.MinSize = new global::System.Drawing.Size(0, 0);
			this.documentContainer1.SizeInfo.AbsoluteSize = new global::System.Drawing.Size(945, 200);
			this.documentContainer1.SizeInfo.SizeMode = global::Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
			this.documentContainer1.SizeInfo.SplitterCorrection = new global::System.Drawing.Size(24, 0);
			this.documentContainer1.TabIndex = 2;
			this.documentContainer1.ThemeName = "CIMitarAdmin_Skin";
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
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1331, 641);
			base.Controls.Add(this.radDock1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel15);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Name = "UnitDataAnalysis";
			base.ShowIcon = false;
			this.Text = "REL UnitData";
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.tableLayoutPanel9.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnLotSearch).EndInit();
			this.panel11.ResumeLayout(false);
			this.tableLayoutPanel8.ResumeLayout(false);
			this.tableLayoutPanel8.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel15).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cboProduct).EndInit();
			this.panel10.ResumeLayout(false);
			this.tableLayoutPanel7.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnLotSNLoad).EndInit();
			this.panel9.ResumeLayout(false);
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel6.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel14).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.txtSN).EndInit();
			this.panel6.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.txtLot).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel13).EndInit();
			this.panel5.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dtmEndTime).EndInit();
			this.panel4.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dtmStartTime).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel12).EndInit();
			this.panel2.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.radPanel3).EndInit();
			this.radPanel3.ResumeLayout(false);
			this.radPanel3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.rdoSN).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoLot).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.rdoDate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.radPanel11).EndInit();
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnNewDoc).EndInit();
			this.panelInfo.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.grdLot.MasterTemplate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.grdLot).EndInit();
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

		// Token: 0x0400003F RID: 63
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.Splitter splitter8;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.Panel panelInfo;

		// Token: 0x04000047 RID: 71
		private global::Telerik.WinControls.UI.RadDateTimePicker dtmEndTime;

		// Token: 0x04000048 RID: 72
		private global::Telerik.WinControls.UI.RadDateTimePicker dtmStartTime;

		// Token: 0x04000049 RID: 73
		private global::Telerik.WinControls.UI.Docking.RadDock radDock1;

		// Token: 0x0400004A RID: 74
		private global::Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;

		// Token: 0x0400004B RID: 75
		private global::Telerik.WinControls.UI.Docking.ToolWindow toolWindow1;

		// Token: 0x0400004C RID: 76
		private global::Telerik.WinControls.UI.Docking.DocumentWindow documentWindow2;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x0400004E RID: 78
		private global::Telerik.WinControls.UI.RadTextBox txtLot;

		// Token: 0x0400004F RID: 79
		private global::Telerik.WinControls.UI.RadButton btnLotSearch;

		// Token: 0x04000050 RID: 80
		private global::Telerik.WinControls.UI.RadCheckedDropDownList cboProduct;

		// Token: 0x04000051 RID: 81
		private global::Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;

		// Token: 0x04000052 RID: 82
		private global::Telerik.WinControls.UI.Docking.DocumentWindow documentWindow1;

		// Token: 0x04000053 RID: 83
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip2;

		// Token: 0x04000054 RID: 84
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;

		// Token: 0x04000055 RID: 85
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip5;

		// Token: 0x04000056 RID: 86
		private global::Telerik.WinControls.UI.RadRadioButton rdoSN;

		// Token: 0x04000057 RID: 87
		private global::Telerik.WinControls.UI.RadRadioButton rdoDate;

		// Token: 0x04000058 RID: 88
		private global::Telerik.WinControls.UI.RadTextBox txtSN;

		// Token: 0x04000059 RID: 89
		private global::Telerik.WinControls.UI.RadRadioButton rdoLot;

		// Token: 0x0400005A RID: 90
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip3;

		// Token: 0x0400005B RID: 91
		private global::Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip6;

		// Token: 0x0400005C RID: 92
		private global::Telerik.WinControls.UI.RadButton btnLotSNLoad;

		// Token: 0x0400005D RID: 93
		private global::Telerik.WinControls.UI.RadButton btnNewDoc;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

		// Token: 0x04000060 RID: 96
		private global::Telerik.WinControls.UI.RadPanel radPanel3;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;

		// Token: 0x04000068 RID: 104
		private global::Telerik.WinControls.UI.RadPanel radPanel11;

		// Token: 0x04000069 RID: 105
		private global::Telerik.WinControls.UI.RadPanel radPanel12;

		// Token: 0x0400006A RID: 106
		private global::Telerik.WinControls.UI.RadPanel radPanel13;

		// Token: 0x0400006B RID: 107
		private global::Telerik.WinControls.UI.RadPanel radPanel14;

		// Token: 0x0400006C RID: 108
		private global::Telerik.WinControls.UI.RadPanel radPanel15;

		// Token: 0x0400006D RID: 109
		private global::Telerik.WinControls.UI.RadGridView grdLot;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.Panel panel12;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.Panel panel11;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.Panel panel13;
	}
}
