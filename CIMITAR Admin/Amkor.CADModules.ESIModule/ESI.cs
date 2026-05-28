using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Amkor.CADModules.ESIModule.CIMitarAdminWS;
using Amkor.CADModules.ESIModule.Class;
using Amkor.CADModules.ESIModule.Control;
using Amkor.CADModules.ESIModule.Properties;
using Amkor.CADModules.ESIModule.View;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;

namespace Amkor.CADModules.ESIModule
{
	// Token: 0x0200002D RID: 45
	public partial class ESI : BaseWinView
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x0000BA90 File Offset: 0x00009C90
		public ESI()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://10.101.5.190/";
			this._factorySetting._startHour = 6;
			this._factorySetting._startMin = 0;
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this.InitializeComponent();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000BBBC File Offset: 0x00009DBC
		public ESI(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000BCB0 File Offset: 0x00009EB0
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000BCC0 File Offset: 0x00009EC0
		private void Modeler_Load(object sender, EventArgs e)
		{
			try
			{
				this.initDataGrid();
				this.initLotListGrid("LOT");
				this.initEvent();
				this.getTypeDefinitionList("ESI_ReportType", this.chkCmbReportType);
				this.getTypeDefinitionList("ESI_P/F", this.cmbPF);
				this.getTypeDefinitionList("ESI_TestType", this.cmbTestType);
				this.initStationInfo();
				object[] chktester = new object[]
				{
					this.chkcmb_Summary_Tester,
					this.chkcmb_Status_Tester,
					this.cmb_Trend_Tester
				};
				this.getATETesterList("ATE", this.chkcmbATETester);
				this.getCheckStatusTesterList("DMDX", chktester);
				this.getTypeDefinitionList("ESI_P/F", this.cmb_Summary_Result);
				this.getBTOQCDate();
				if (this.chkCmbReportType.Items.Count > 0)
				{
					for (int i = 0; i < this.chkCmbReportType.Items.Count; i++)
					{
						this.chkCmbReportType.SetItemChecked(i, true);
					}
				}
				this.BT_Date_Start.Value = DateTime.Now.AddDays(-1.0);
				this.BT_Date_End.Value = DateTime.Now.AddDays(-1.0);
				this.Setup_Date_Start.Value = DateTime.Now.AddDays(-1.0);
				this.Setup_Date_End.Value = DateTime.Now.AddDays(-1.0);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000BE6C File Offset: 0x0000A06C
		private void initStationInfo()
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetStationInfo]";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count != 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.chkCmbOperation.Items.Add(dataSet.Tables[0].Rows[i]["name"].ToString());
				}
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		private void initDataGrid()
		{
			this.gridUnitList.ColumnsCount = 15;
			this.gridUnitList.RowsCount = 1;
			this.gridUnitList.FixedRows = 1;
			this.gridUnitList.Columns[0].Width = 30;
			this.gridUnitList[0, 0] = new GridInfo.ColHeader("No");
			this.gridUnitList.Columns[1].Width = 80;
			this.gridUnitList[0, 1] = new GridInfo.ColHeader("Status");
			this.gridUnitList.Columns[2].Width = 150;
			this.gridUnitList[0, 2] = new GridInfo.ColHeader("SN");
			this.gridUnitList.Columns[3].Width = 70;
			this.gridUnitList[0, 3] = new GridInfo.ColHeader("Config");
			this.gridUnitList.Columns[4].Width = 60;
			this.gridUnitList[0, 4] = new GridInfo.ColHeader("Dcc");
			this.gridUnitList.Columns[5].Width = 80;
			this.gridUnitList[0, 5] = new GridInfo.ColHeader("Product");
			this.gridUnitList.Columns[6].Width = 70;
			this.gridUnitList[0, 6] = new GridInfo.ColHeader("TestStation");
			this.gridUnitList.Columns[7].Width = 160;
			this.gridUnitList[0, 7] = new GridInfo.ColHeader("TestStation ID");
			this.gridUnitList.Columns[8].Width = 160;
			this.gridUnitList[0, 8] = new GridInfo.ColHeader("SW Version");
			this.gridUnitList.Columns[9].Width = 60;
			this.gridUnitList[0, 9] = new GridInfo.ColHeader("Result");
			this.gridUnitList.Columns[10].Width = 200;
			this.gridUnitList[0, 10] = new GridInfo.ColHeader("Failing_Tests");
			this.gridUnitList.Columns[11].Width = 200;
			this.gridUnitList[0, 11] = new GridInfo.ColHeader("Failure_Message");
			this.gridUnitList.Columns[12].Width = 150;
			this.gridUnitList[0, 12] = new GridInfo.ColHeader("Date");
			this.gridUnitList.Columns[13].Width = 200;
			this.gridUnitList[0, 13] = new GridInfo.ColHeader("Comment");
			this.gridUnitList.Columns[14].Width = 50;
			this.gridUnitList[0, 14] = new GridInfo.ColHeader("Check");
			this.gridInfo.SetColumnCellColor(this.gridUnitList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridUnitHistory.ColumnsCount = 10;
			this.gridUnitHistory.RowsCount = 1;
			this.gridUnitHistory.FixedRows = 1;
			this.gridUnitHistory.Columns[0].Width = 35;
			this.gridUnitHistory[0, 0] = new GridInfo.ColHeader("No.");
			this.gridUnitHistory.Columns[1].Width = 180;
			this.gridUnitHistory[0, 1] = new GridInfo.ColHeader("Config");
			this.gridUnitHistory.Columns[2].Width = 180;
			this.gridUnitHistory[0, 2] = new GridInfo.ColHeader("Dcc");
			this.gridUnitHistory.Columns[3].Width = 180;
			this.gridUnitHistory[0, 3] = new GridInfo.ColHeader("Station");
			this.gridUnitHistory.Columns[4].Width = 70;
			this.gridUnitHistory[0, 4] = new GridInfo.ColHeader("Result");
			this.gridUnitHistory.Columns[5].Width = 100;
			this.gridUnitHistory[0, 5] = new GridInfo.ColHeader("Audit Mode");
			this.gridUnitHistory.Columns[6].Width = 100;
			this.gridUnitHistory[0, 6] = new GridInfo.ColHeader("SW Version");
			this.gridUnitHistory.Columns[7].Width = 150;
			this.gridUnitHistory[0, 7] = new GridInfo.ColHeader("In Date");
			this.gridUnitHistory.Columns[8].Width = 150;
			this.gridUnitHistory[0, 8] = new GridInfo.ColHeader("Fail Reason");
			this.gridUnitHistory.Columns[9].Width = 150;
			this.gridUnitHistory[0, 9] = new GridInfo.ColHeader("Fail Log");
			this.gridInfo.SetColumnCellColor(this.gridUnitHistory, 0, this.gridInfo.CellColor.cell_gray_center);
			this.initUploadLotGrid();
			this.initUploadSNGrid();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000C464 File Offset: 0x0000A664
		private void InitYieldReportGrid_PerStation(SourceGrid.Grid grid)
		{
			grid.ColumnsCount = 22;
			grid.RowsCount = 1;
			grid.FixedRows = 1;
			grid.Columns[0].Width = 80;
			grid[0, 0] = new GridInfo.ColHeader("Station");
			grid.Columns[1].Width = 70;
			grid[0, 1] = new GridInfo.ColHeader("Product");
			grid.Columns[2].Width = 70;
			grid[0, 2] = new GridInfo.ColHeader("Device");
			grid.Columns[3].Width = 100;
			grid[0, 3] = new GridInfo.ColHeader("Lot");
			grid.Columns[4].Width = 60;
			grid[0, 4] = new GridInfo.ColHeader("DCC");
			grid.Columns[5].Width = 120;
			grid[0, 5] = new GridInfo.ColHeader("Test Program");
			grid.Columns[6].Width = 120;
			grid[0, 6] = new GridInfo.ColHeader("Lot Start Time");
			grid.Columns[7].Width = 120;
			grid[0, 7] = new GridInfo.ColHeader("Lot End Time");
			grid.Columns[8].Width = 80;
			grid[0, 8] = new GridInfo.ColHeader("Input");
			grid.Columns[9].Width = 80;
			grid[0, 9] = new GridInfo.ColHeader("PASS_Final");
			grid.Columns[10].Width = 80;
			grid[0, 10] = new GridInfo.ColHeader("FAIL_Final");
			grid.Columns[11].Width = 80;
			grid[0, 11] = new GridInfo.ColHeader("Yield");
			grid.Columns[12].Width = 80;
			grid[0, 12] = new GridInfo.ColHeader("PASS_1st");
			grid.Columns[13].Width = 80;
			grid[0, 13] = new GridInfo.ColHeader("FAIL_1st");
			grid.Columns[14].Width = 80;
			grid[0, 14] = new GridInfo.ColHeader("FPY");
			grid.Columns[15].Width = 80;
			grid[0, 15] = new GridInfo.ColHeader("Retest Rate");
			grid.Columns[16].Width = 80;
			grid[0, 16] = new GridInfo.ColHeader("PASS_2nd");
			grid.Columns[17].Width = 80;
			grid[0, 17] = new GridInfo.ColHeader("FAIL_2nd");
			grid.Columns[18].Width = 80;
			grid[0, 18] = new GridInfo.ColHeader("PASS_3rd");
			grid.Columns[19].Width = 80;
			grid[0, 19] = new GridInfo.ColHeader("FAIL_3rd");
			grid.Columns[20].Width = 80;
			grid[0, 20] = new GridInfo.ColHeader("PASS_4th");
			grid.Columns[21].Width = 80;
			grid[0, 21] = new GridInfo.ColHeader("FAIL_4th");
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000C7EC File Offset: 0x0000A9EC
		private void InitYieldReportGrid_PerStationID(SourceGrid.Grid grid)
		{
			grid.ColumnsCount = 18;
			grid.RowsCount = 1;
			grid.FixedRows = 1;
			grid.Columns[0].Width = 80;
			grid[0, 0] = new GridInfo.ColHeader("Station");
			grid.Columns[1].Width = 70;
			grid[0, 1] = new GridInfo.ColHeader("Station ID");
			grid.Columns[2].Width = 100;
			grid[0, 2] = new GridInfo.ColHeader("Lot");
			grid.Columns[3].Width = 60;
			grid[0, 3] = new GridInfo.ColHeader("DCC");
			grid.Columns[4].Width = 80;
			grid[0, 4] = new GridInfo.ColHeader("Input");
			grid.Columns[5].Width = 80;
			grid[0, 5] = new GridInfo.ColHeader("PASS_Final");
			grid.Columns[6].Width = 80;
			grid[0, 6] = new GridInfo.ColHeader("FAIL_Final");
			grid.Columns[7].Width = 80;
			grid[0, 7] = new GridInfo.ColHeader("Yield");
			grid.Columns[8].Width = 80;
			grid[0, 8] = new GridInfo.ColHeader("PASS_1st");
			grid.Columns[9].Width = 80;
			grid[0, 9] = new GridInfo.ColHeader("FAIL_1st");
			grid.Columns[10].Width = 80;
			grid[0, 10] = new GridInfo.ColHeader("FPY");
			grid.Columns[11].Width = 80;
			grid[0, 11] = new GridInfo.ColHeader("Retest Rate");
			grid.Columns[12].Width = 80;
			grid[0, 12] = new GridInfo.ColHeader("PASS_2nd");
			grid.Columns[13].Width = 80;
			grid[0, 13] = new GridInfo.ColHeader("FAIL_2nd");
			grid.Columns[14].Width = 80;
			grid[0, 14] = new GridInfo.ColHeader("PASS_3rd");
			grid.Columns[15].Width = 80;
			grid[0, 15] = new GridInfo.ColHeader("FAIL_3rd");
			grid.Columns[16].Width = 80;
			grid[0, 16] = new GridInfo.ColHeader("PASS_4th");
			grid.Columns[17].Width = 80;
			grid[0, 17] = new GridInfo.ColHeader("FAIL_4th");
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000CAD8 File Offset: 0x0000ACD8
		private void InitUnitResultGrid(SourceGrid.Grid grid)
		{
			grid.ColumnsCount = 41;
			grid.RowsCount = 1;
			grid.FixedRows = 1;
			int p = 0;
			grid.Columns[p].Width = 40;
			grid[0, p++] = new GridInfo.ColHeader("No");
			grid.Columns[p].Width = 150;
			grid[0, p++] = new GridInfo.ColHeader("Serial Number");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("Product");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("Device");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("Lot");
			grid.Columns[p].Width = 50;
			grid[0, p++] = new GridInfo.ColHeader("DCC");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("Station");
			grid.Columns[p].Width = 60;
			grid[0, p++] = new GridInfo.ColHeader("Test Type");
			grid.Columns[p].Width = 150;
			grid[0, p++] = new GridInfo.ColHeader("Test Program");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Station ID");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Site Number");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("PASS/FAIL");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("Start Time");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("End Time");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Test Time");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Audit Mode");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new GridInfo.ColHeader("1st Failing Test");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_1_Value");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_1_Units");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_1_Upper_Limit");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_1_Lower_Limit");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new GridInfo.ColHeader("2nd Failing Test");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_2_Value");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_2_Units");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_2_Upper_Limit");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_2_Lower_Limit");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new GridInfo.ColHeader("3rd Failing Test");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_3_Value");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_3_Units");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_3_Upper_Limit");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_3_Lower_Limit");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new GridInfo.ColHeader("4th Failing Test");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_4_Value");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_4_Units");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_4_Upper_Limit");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_4_Lower_Limit");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new GridInfo.ColHeader("5th Failing Test");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_5_Value");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("FT_5_Units");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_5_Upper_Limit");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("FT_5_Lower_Limit");
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000D1C0 File Offset: 0x0000B3C0
		private void InitFailureSummaryGrid(SourceGrid.Grid grid)
		{
			grid.ColumnsCount = 9;
			grid.RowsCount = 1;
			grid.FixedRows = 1;
			int p = 0;
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Product");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Device");
			grid.Columns[p].Width = 100;
			grid[0, p++] = new GridInfo.ColHeader("Lot");
			grid.Columns[p].Width = 50;
			grid[0, p++] = new GridInfo.ColHeader("DCC");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Station");
			grid.Columns[p].Width = 60;
			grid[0, p++] = new GridInfo.ColHeader("Test Type");
			grid.Columns[p].Width = 400;
			grid[0, p++] = new GridInfo.ColHeader("1st Failing Test");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Failure Qty");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Failure Rate");
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000D378 File Offset: 0x0000B578
		private void initLotListGrid(string sType)
		{
			this.gridLotList.ColumnsCount = 7;
			this.gridLotList.RowsCount = 1;
			this.gridLotList.FixedRows = 1;
			this.gridLotList.FixedColumns = 1;
			this.gridLotList.Columns[0].Width = 30;
			this.gridLotList[0, 0] = new GridInfo.ColHeader("");
			this.gridLotList.Columns[1].Width = 40;
			this.gridLotList[0, 1] = new GridInfo.ColHeader("No");
			this.gridLotList.Columns[2].Width = 110;
			this.gridLotList[0, 2] = new GridInfo.ColHeader("Lot");
			this.gridLotList.Columns[3].Width = 50;
			this.gridLotList[0, 3] = new GridInfo.ColHeader("Dcc");
			this.gridLotList.Columns[4].Width = 50;
			this.gridLotList[0, 4] = new GridInfo.ColHeader("Device");
			this.gridLotList.Columns[5].Width = 50;
			this.gridLotList[0, 5] = new GridInfo.ColHeader("Product");
			this.gridLotList.Columns[6].Width = 150;
			this.gridLotList[0, 6] = new GridInfo.ColHeader("SN");
			this.gridInfo.CreateColHeaderCheckBox(this.gridLotList);
			this.gridInfo.SetColumnCellColor(this.gridLotList, 0, this.gridInfo.CellColor.cell_gray_center);
			if (sType == "LOT")
			{
				this.gridLotList.Columns[2].Visible = true;
				this.gridLotList.Columns[3].Visible = true;
				this.gridLotList.Columns[5].Visible = false;
				this.gridLotList.Columns[4].Visible = false;
				this.gridLotList.Columns[6].Visible = false;
				return;
			}
			this.gridLotList.Columns[2].Visible = false;
			this.gridLotList.Columns[3].Visible = false;
			this.gridLotList.Columns[5].Visible = false;
			this.gridLotList.Columns[4].Visible = false;
			this.gridLotList.Columns[6].Visible = true;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000D628 File Offset: 0x0000B828
		private DataSet queryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._factorySetting._urlServer + "CIMitarWebService/CIMitarWS.asmx";
				cimitarWSSoapClient.Endpoint.Address = new EndpointAddress(uri);
				dataSet = cimitarWSSoapClient.CIMitarQuaryCall("CIMitarMasterDBConnect", sQuery);
				result = dataSet;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				result = dataSet;
			}
			return result;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000D6A0 File Offset: 0x0000B8A0
		private DataSet getTypeDefinitionList(string sTypeName)
		{
			DataSet result = new DataSet();
			try
			{
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_CR_GetTypeDefList] @typename = '" + sTypeName + "'";
				result = this.queryCall(sQuery);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return result;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000D6F0 File Offset: 0x0000B8F0
		private DataSet getTypeDefinitionList(string sTypeName, ComboBox comboBox)
		{
			DataSet dataSet = new DataSet();
			try
			{
				comboBox.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
				dataSet = this.queryCall(sQuery);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					comboBox.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return dataSet;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000D798 File Offset: 0x0000B998
		private DataSet getTypeDefinitionList(string sTypeName, CheckedComboBox chkcmb)
		{
			DataSet dataSet = new DataSet();
			try
			{
				chkcmb.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
				dataSet = this.queryCall(sQuery);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					chkcmb.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return dataSet;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000D840 File Offset: 0x0000BA40
		private void initEvent()
		{
			this.cmd_Yield_Search.MouseDown += this.cmdSearch_MouseDown;
			this.cmd_Yield_Search.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmd_Yield_Search.MouseMove += this.cmdSearch_MouseMove;
			this.cmd_Yield_Search.MouseUp += this.cmdSearch_MouseUp;
			this.cmd_Yield_Excel.MouseDown += this.cmdExcel_MouseDown;
			this.cmd_Yield_Excel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmd_Yield_Excel.MouseMove += this.cmdExcel_MouseMove;
			this.cmd_Yield_Excel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdUnitSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdUnitSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdUnitSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdUnitSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdUnitExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdUnitExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdUnitExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdUnitExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmd_In_Search.MouseDown += this.cmdSearch_MouseDown;
			this.cmd_In_Search.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmd_In_Search.MouseMove += this.cmdSearch_MouseMove;
			this.cmd_In_Search.MouseUp += this.cmdSearch_MouseUp;
			this.cmd_In_Apply.MouseDown += this.cmdApply_MouseDown;
			this.cmd_In_Apply.MouseLeave += this.cmdApply_MouseLeave;
			this.cmd_In_Apply.MouseMove += this.cmdApply_MouseMove;
			this.cmd_In_Apply.MouseUp += this.cmdApply_MouseUp;
			this.pbComment.MouseDown += this.pbComment_MouseDown;
			this.pbComment.MouseLeave += this.pbComment_MouseLeave;
			this.pbComment.MouseMove += this.pbComment_MouseMove;
			this.pbComment.MouseUp += this.pbComment_MouseUp;
			this.cmd_BTOQC_Search.MouseDown += this.cmdSearch_MouseDown;
			this.cmd_BTOQC_Search.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmd_BTOQC_Search.MouseMove += this.cmdSearch_MouseMove;
			this.cmd_BTOQC_Search.MouseUp += this.cmdSearch_MouseUp;
			this.cmd_BTOQC_Excel.MouseDown += this.cmdExcel_MouseDown;
			this.cmd_BTOQC_Excel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmd_BTOQC_Excel.MouseMove += this.cmdExcel_MouseMove;
			this.cmd_BTOQC_Excel.MouseUp += this.cmdExcel_MouseUp;
			this.cmd_UploadSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmd_UploadSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmd_UploadSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmd_UploadSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmd_UploadDelete.MouseDown += this.cmdUploadDelete_MouseDown;
			this.cmd_UploadDelete.MouseLeave += this.cmdUploadDelete_MouseLeave;
			this.cmd_UploadDelete.MouseMove += this.cmdUploadDelete_MouseMove;
			this.cmd_UploadDelete.MouseUp += this.cmdUploadDelete_MouseUp;
			this.cmd_Download_Data.MouseDown += this.cmdExcel_MouseDown;
			this.cmd_Download_Data.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmd_Download_Data.MouseMove += this.cmdExcel_MouseMove;
			this.cmd_Download_Data.MouseUp += this.cmdExcel_MouseUp;
			this.cmd_Upload_Data.MouseDown += this.cmdUpload_MouseDown;
			this.cmd_Upload_Data.MouseLeave += this.cmdUpload_MouseLeave;
			this.cmd_Upload_Data.MouseMove += this.cmdUpload_MouseMove;
			this.cmd_Upload_Data.MouseUp += this.cmdUpload_MouseUp;
			this.cmd_UploadApply.MouseDown += this.cmdApply_MouseDown;
			this.cmd_UploadApply.MouseLeave += this.cmdApply_MouseLeave;
			this.cmd_UploadApply.MouseMove += this.cmdApply_MouseMove;
			this.cmd_UploadApply.MouseUp += this.cmdApply_MouseUp;
			this.cmd_ParaSummary_Search.MouseDown += this.cmdSearch_MouseDown;
			this.cmd_ParaSummary_Search.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmd_ParaSummary_Search.MouseMove += this.cmdSearch_MouseMove;
			this.cmd_ParaSummary_Search.MouseUp += this.cmdSearch_MouseUp;
			this.cmd_ParaSummary_Excel.MouseDown += this.cmdExcel_MouseDown;
			this.cmd_ParaSummary_Excel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmd_ParaSummary_Excel.MouseMove += this.cmdExcel_MouseMove;
			this.cmd_ParaSummary_Excel.MouseUp += this.cmdExcel_MouseUp;
			this.cmd_CheckStatus_Search.MouseDown += this.cmdSearch_MouseDown;
			this.cmd_CheckStatus_Search.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmd_CheckStatus_Search.MouseMove += this.cmdSearch_MouseMove;
			this.cmd_CheckStatus_Search.MouseUp += this.cmdSearch_MouseUp;
			this.cmd_CheckStatus_Excel.MouseDown += this.cmdExcel_MouseDown;
			this.cmd_CheckStatus_Excel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmd_CheckStatus_Excel.MouseMove += this.cmdExcel_MouseMove;
			this.cmd_CheckStatus_Excel.MouseUp += this.cmdExcel_MouseUp;
			this.cmd_Trend_Search.MouseDown += this.cmdSearch_MouseDown;
			this.cmd_Trend_Search.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmd_Trend_Search.MouseMove += this.cmdSearch_MouseMove;
			this.cmd_Trend_Search.MouseUp += this.cmdSearch_MouseUp;
			this.cmd_Trend_Excel.MouseDown += this.cmdExcel_MouseDown;
			this.cmd_Trend_Excel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmd_Trend_Excel.MouseMove += this.cmdExcel_MouseMove;
			this.cmd_Trend_Excel.MouseUp += this.cmdExcel_MouseUp;
			this.cmd_AddPara.MouseDown += this.cmdAdd_MouseDown;
			this.cmd_AddPara.MouseLeave += this.cmdAdd_MouseLeave;
			this.cmd_AddPara.MouseMove += this.cmdAdd_MouseMove;
			this.cmd_AddPara.MouseUp += this.cmdAdd_MouseUp;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000DFDC File Offset: 0x0000C1DC
		private UnitData getSN_Info(string sType, string sInputSN)
		{
			this.initTextBox();
			UnitData unitData = new UnitData();
			try
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUnitData]  @type  = '",
					sType,
					"', @sn  = '",
					sInputSN.Trim(),
					"'"
				});
				DataSet dataSet = this.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					unitData.UnitID = dataSet.Tables[0].Rows[0]["id"].ToString();
					unitData.SN = dataSet.Tables[0].Rows[0]["sn"].ToString();
					unitData.Status = dataSet.Tables[0].Rows[0]["status"].ToString();
					unitData.Product = dataSet.Tables[0].Rows[0]["product"].ToString();
					unitData.Test_station_name = dataSet.Tables[0].Rows[0]["test_station_name"].ToString();
					unitData.Station_id = dataSet.Tables[0].Rows[0]["station_id"].ToString();
					unitData.Sw_version = dataSet.Tables[0].Rows[0]["sw_version"].ToString();
					unitData.StartTime = dataSet.Tables[0].Rows[0]["start_time"].ToString();
					unitData.StopTime = dataSet.Tables[0].Rows[0]["stop_time"].ToString();
					unitData.Failing_tests = dataSet.Tables[0].Rows[0]["failing_tests"].ToString();
					unitData.Failure_message = dataSet.Tables[0].Rows[0]["failure_message"].ToString();
					unitData.CheckInFlag = dataSet.Tables[0].Rows[0]["checkinflag"].ToString();
					unitData.LotID = dataSet.Tables[0].Rows[0]["lotid"].ToString();
					unitData.Dcc = dataSet.Tables[0].Rows[0]["dcc"].ToString();
					if (sType == "CHECKIN" || sType == "REQUEST")
					{
						this.txt_In_SN.Text = unitData.SN;
						this.txt_In_Product.Text = unitData.Product;
						this.txt_In_TestStation.Text = unitData.Test_station_name;
						this.txt_In_StationID.Text = unitData.Station_id;
						this.txt_In_SWVersion.Text = unitData.Sw_version;
						this.txt_In_StartTime.Text = unitData.StartTime;
						this.txt_In_StopTime.Text = unitData.StopTime;
						this.txt_In_FailTests.Text = unitData.Failing_tests;
						this.txt_In_FailingMsg.Text = unitData.Failure_message;
						this.txt_In_Status.Text = unitData.Status;
						this.txt_In_Config.Text = unitData.LotID;
						this.txt_In_Dcc.Text = unitData.Dcc;
						if (sType == "REQUEST")
						{
							sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUnitHisotry] @sn  = '" + sInputSN.Trim() + "'";
							dataSet = this.queryCall(sQuery);
							if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
							{
								this.gridUnitHistory.RowsCount = 1;
								for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
								{
									this.gridUnitHistory.Rows.Insert(this.gridUnitHistory.RowsCount);
									this.gridUnitHistory[i + 1, 0] = new Cell((i + 1).ToString());
									this.gridUnitHistory[i + 1, 1] = new Cell(dataSet.Tables[0].Rows[i]["lotid"].ToString());
									this.gridUnitHistory[i + 1, 2] = new Cell(dataSet.Tables[0].Rows[i]["dcc"].ToString());
									this.gridUnitHistory[i + 1, 9] = new Cell(this.UTF8ConvertToCharAll(dataSet.Tables[0].Rows[i]["failure_message"].ToString()));
									this.gridUnitHistory[i + 1, 3] = new Cell(dataSet.Tables[0].Rows[i]["station_id"].ToString());
									this.gridUnitHistory[i + 1, 4] = new Cell(dataSet.Tables[0].Rows[i]["result"].ToString());
									this.gridUnitHistory[i + 1, 5] = new Cell(dataSet.Tables[0].Rows[i]["audit_mode"].ToString());
									this.gridUnitHistory[i + 1, 6] = new Cell(dataSet.Tables[0].Rows[i]["sw_version"].ToString());
									this.gridUnitHistory[i + 1, 7] = new Cell(dataSet.Tables[0].Rows[i]["indate"].ToString());
									this.gridUnitHistory[i + 1, 8] = new Cell("");
									if (dataSet.Tables[0].Rows[i]["fail_value"].ToString().Length != 0)
									{
										string[] array = dataSet.Tables[0].Rows[i]["fail_value"].ToString().Split(new char[]
										{
											','
										});
										if (array != null && array.Length != 0)
										{
											string[] array2 = new string[]
											{
												"ft_1_test",
												"ft_1_sub_test"
											};
											int num = 8;
											while (num < 9 && array[0] != string.Empty)
											{
												for (int j = 0; j < array2.Length; j++)
												{
													for (int k = 0; k < array.Length; k++)
													{
														string text = array2[j];
														if (array[k] != null && !(array[k].Length <= 1 | text.Length <= 1) && text.CompareTo(array[k].Substring(0, array[k].IndexOf('='))) == 0 && array[k].Substring(3, 1).CompareTo("1") == 0)
														{
															string text2 = array[k].Substring(array[k].IndexOf(text) + text.Length + 1, array[k].Length - text.Length - 1);
															if (text2.IndexOf('%') > 0)
															{
																do
																{
																	text2 = this.UTF8ConvertToChar(text2);
																}
																while (text2.IndexOf('%') > 0);
															}
															if (this.gridUnitHistory[i + 1, num].Value == null || this.gridUnitHistory[i + 1, num].Value.ToString() == string.Empty)
															{
																this.gridUnitHistory[i + 1, num] = new Cell(text2);
															}
															else
															{
																text2 = this.gridUnitHistory[i + 1, num].Value.ToString() + "@" + text2;
																this.gridUnitHistory[i + 1, num] = new Cell(text2);
															}
														}
													}
												}
												num++;
											}
										}
									}
								}
								this.gridUnitHistory.AutoSizeCells();
								int num2 = 0;
								for (int l = 0; l < this.gridUnitHistory.ColumnsCount; l++)
								{
									num2 += this.gridUnitHistory.Columns[l].Width;
								}
								this.gridUnitHistory.Width = num2 + 10;
								this.gridUnitHistory.Height = this.gridUnitHistory.Rows[0].Height * this.gridUnitHistory.RowsCount + 10;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return unitData;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000E978 File Offset: 0x0000CB78
		private string UTF8ConvertToChar(string sString)
		{
			string result;
			try
			{
				string text = sString.Substring(sString.IndexOf('%'), 3);
				int value = Convert.ToInt32(text.Substring(1, 2), 16);
				char c = Convert.ToChar(value);
				sString = sString.Replace('+', ' ');
				sString = sString.Replace(text, c.ToString());
				result = sString;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), "UTF8ConvertoChar");
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000EA00 File Offset: 0x0000CC00
		private string UTF8ConvertToCharAll(string sString)
		{
			string result;
			try
			{
				sString = sString.Replace("+", " ");
				while (sString.IndexOf("%") > 0)
				{
					string text = sString.Substring(sString.IndexOf('%'), 3);
					int value = Convert.ToInt32(text.Substring(1, 2), 16);
					sString = sString.Replace(text, Convert.ToChar(value).ToString());
				}
				result = sString;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), "UTF8ConvertoChar");
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000EAA0 File Offset: 0x0000CCA0
		private void initTextBox()
		{
			this.txt_In_SN.Text = string.Empty;
			this.txt_In_Product.Text = string.Empty;
			this.txt_In_TestStation.Text = string.Empty;
			this.txt_In_StationID.Text = string.Empty;
			this.txt_In_SWVersion.Text = string.Empty;
			this.txt_In_StartTime.Text = string.Empty;
			this.txt_In_StopTime.Text = string.Empty;
			this.txt_In_FailTests.Text = string.Empty;
			this.txt_In_FailingMsg.Text = string.Empty;
			this.txt_In_Status.Text = string.Empty;
			this.txt_In_Config.Text = string.Empty;
			this.txt_In_Dcc.Text = string.Empty;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000EB70 File Offset: 0x0000CD70
		private void SetCheckInOut(UnitData unit, bool bDialog)
		{
			if (unit.SN == string.Empty)
			{
				MessageBox.Show("sn is not exist. check please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (unit.SN != string.Empty)
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC CIMitar_Factory.dbo.USP_ESI_SetUnitData_FA  @unitid  = '",
					unit.UnitID,
					"', @sn  = '",
					unit.SN,
					"', @status  = '",
					unit.Status,
					"', @product  = '",
					unit.Product,
					"', @test_station_name  = '",
					unit.Test_station_name,
					"', @station_id  = '",
					unit.Station_id,
					"', @comment  = '",
					unit.Comment,
					"', @userid  = '",
					this._cimitarUser._id,
					"'"
				});
				DataSet dataSet = this.queryCall(sQuery);
				if (bDialog)
				{
					if (dataSet != null && dataSet.Tables.Count > 0)
					{
						if (dataSet.Tables[0].Rows.Count <= 0)
						{
							MessageBox.Show("Request is failed. please cotact to TFA team", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return;
						}
						if (dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper().CompareTo("OK") == 0)
						{
							MessageBox.Show(unit.Status + " Completed", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							return;
						}
						MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					else
					{
						MessageBox.Show("Request is failed. please cotact to TFA team", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000ED60 File Offset: 0x0000CF60
		private void txtSN_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				UnitData sn_Info = this.getSN_Info("REQUEST", this.txtInputSN_In.Text);
				if (sn_Info.SN == string.Empty)
				{
					MessageBox.Show("sn is not exist. please check", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				if (sn_Info.Status == "REQUEST")
				{
					MessageBox.Show("sn is already Request. please check", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				if (this.chk_AutoCheckIn.Checked)
				{
					sn_Info.Status = "REQUEST";
					sn_Info.Comment = this.txt_In_Comment.Text;
					this.SetCheckInOut(sn_Info, true);
					this.txtInputSN_In.Text = string.Empty;
					this.txtInputSN_In.Focus();
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000EE2A File Offset: 0x0000D02A
		private void cmd_In_Search_Click(object sender, EventArgs e)
		{
			this.gridUnitHistory.RowsCount = 1;
			this.getSN_Info("REQUEST", this.txtInputSN_In.Text);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000EE50 File Offset: 0x0000D050
		private void cmd_In_Apply_Click(object sender, EventArgs e)
		{
			UnitData sn_Info = this.getSN_Info("REQUEST", this.txtInputSN_In.Text);
			if (sn_Info.SN == string.Empty)
			{
				MessageBox.Show("sn is not exist. please check", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (sn_Info.Status == "CHECKIN")
			{
				MessageBox.Show("sn is Check in. please check", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (sn_Info.Status == "REQUEST")
			{
				MessageBox.Show("sn is already REQUEST. please check", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			sn_Info.Status = "REQUEST";
			sn_Info.Comment = this.txt_In_Comment.Text;
			this.SetCheckInOut(sn_Info, true);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000EF0C File Offset: 0x0000D10C
		private void cmdSearch_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000EF38 File Offset: 0x0000D138
		private void cmdSearch_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000EF64 File Offset: 0x0000D164
		private void cmdSearch_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000EF8E File Offset: 0x0000D18E
		private void cmdSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000EF9C File Offset: 0x0000D19C
		private void cmdExcel_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000EFC8 File Offset: 0x0000D1C8
		private void cmdExcel_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000EFF4 File Offset: 0x0000D1F4
		private void cmdExcel_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000F01E File Offset: 0x0000D21E
		private void cmdExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000F02C File Offset: 0x0000D22C
		private void cmdAdd_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000F058 File Offset: 0x0000D258
		private void cmdAdd_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000F084 File Offset: 0x0000D284
		private void cmdAdd_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableAdd_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000F0AE File Offset: 0x0000D2AE
		private void cmdAdd_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000F0BC File Offset: 0x0000D2BC
		private void cmdApply_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000F0E8 File Offset: 0x0000D2E8
		private void cmdApply_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000F114 File Offset: 0x0000D314
		private void cmdApply_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000F13E File Offset: 0x0000D33E
		private void cmdApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000F14C File Offset: 0x0000D34C
		private void pbComment_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableComment_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000F178 File Offset: 0x0000D378
		private void pbComment_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableComment;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000F1A4 File Offset: 0x0000D3A4
		private void pbComment_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableComment_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000F1CE File Offset: 0x0000D3CE
		private void pbComment_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000F1DC File Offset: 0x0000D3DC
		private void cmdUpload_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000F208 File Offset: 0x0000D408
		private void cmdUpload_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000F234 File Offset: 0x0000D434
		private void cmdUpload_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.OpenTable_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000F25E File Offset: 0x0000D45E
		private void cmdUpload_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000F26C File Offset: 0x0000D46C
		private void cmdUploadDelete_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000F298 File Offset: 0x0000D498
		private void cmdUploadDelete_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000F2C4 File Offset: 0x0000D4C4
		private void cmdUploadDelete_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableRemove_Donw;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000F2EE File Offset: 0x0000D4EE
		private void cmdUploadDelete_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000F2FC File Offset: 0x0000D4FC
		private void saveExcel(SourceGrid.Grid grid)
		{
			try
			{
				if (grid.RowsCount >= 2)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						ExcelControl.Save(this.saveFileDialog.FileName, grid, true);
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000F41C File Offset: 0x0000D61C
		private void cmdUnitSearch_Click(object sender, EventArgs e)
		{
			this.cbAll.Checked = false;
			DataSet dataSet = new DataSet();
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this.gridUnitList.RowsCount = 1;
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUnitList_FA]  @type  = 'List', @sn  = '",
					this.txtUnitSN.Text.Trim(),
					"', @status  = '",
					this.cmbType.Text,
					"', @config = N'",
					this.tbConfig.Text,
					"', @Dcc = N'",
					this.tbDcc.Text,
					"'"
				});
				dataSet = this.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.gridUnitList.Rows.Insert(this.gridUnitList.RowsCount);
						this.gridUnitList[i + 1, 0] = new Cell((i + 1).ToString());
						this.gridUnitList[i + 1, 1] = new Cell(dataSet.Tables[0].Rows[i]["status"].ToString());
						this.gridUnitList[i + 1, 2] = new Cell(dataSet.Tables[0].Rows[i]["sn"].ToString());
						this.gridUnitList[i + 1, 3] = new Cell(dataSet.Tables[0].Rows[i]["lotid"].ToString());
						this.gridUnitList[i + 1, 4] = new Cell(dataSet.Tables[0].Rows[i]["dcc"].ToString());
						this.gridUnitList[i + 1, 5] = new Cell(dataSet.Tables[0].Rows[i]["product"].ToString());
						this.gridUnitList[i + 1, 6] = new Cell(dataSet.Tables[0].Rows[i]["test_station_name"].ToString());
						this.gridUnitList[i + 1, 7] = new Cell(dataSet.Tables[0].Rows[i]["station_id"].ToString());
						this.gridUnitList[i + 1, 8] = new Cell(dataSet.Tables[0].Rows[i]["sw_version"].ToString());
						this.gridUnitList[i + 1, 9] = new Cell(dataSet.Tables[0].Rows[i]["result"].ToString());
						this.gridUnitList[i + 1, 10] = new Cell(dataSet.Tables[0].Rows[i]["failing_tests"].ToString());
						this.gridUnitList[i + 1, 11] = new Cell(dataSet.Tables[0].Rows[i]["failure_message"].ToString());
						this.gridUnitList[i + 1, 12] = new Cell(dataSet.Tables[0].Rows[i]["indate"].ToString());
						this.gridUnitList[i + 1, 13] = new Cell(dataSet.Tables[0].Rows[i]["comment"].ToString());
						this.gridUnitList[i + 1, 14] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
						this._barPrograss.setValue(i + 1);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			finally
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000F96C File Offset: 0x0000DB6C
		private void cmdUnitExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridUnitList);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000F97A File Offset: 0x0000DB7A
		private void cmbType_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("ESI_FA_Type", this.cmbType);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000F990 File Offset: 0x0000DB90
		private void cmbUnitProduct_DropDown(object sender, EventArgs e)
		{
			this.cmbUnitProduct.Items.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUnitList_FA]  @type  = 'Product'";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cmbUnitProduct.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000FA38 File Offset: 0x0000DC38
		private void cmbUnitStation_DropDown(object sender, EventArgs e)
		{
			this.cmbUnitStation.Items.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUnitList_FA]  @type  = 'Station'";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cmbUnitStation.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000FAE0 File Offset: 0x0000DCE0
		private void cmbUnitStationId_DropDown(object sender, EventArgs e)
		{
			this.cmbUnitStationId.Items.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUnitList_FA]  @type  = 'StationId'";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cmbUnitStationId.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000FB86 File Offset: 0x0000DD86
		private void txtUnitSN_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.cmdUnitSearch_Click(null, null);
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000FB9C File Offset: 0x0000DD9C
		private string loadData(List<string> lstSN)
		{
			string text = string.Empty;
			this.openFileDialog.Filter = "*.txt|*.TXT";
			this.openFileDialog.FileName = string.Empty;
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamReader streamReader = new StreamReader(this.openFileDialog.FileName);
				string text2 = string.Empty;
				while ((text2 = streamReader.ReadLine()) != null)
				{
					string[] array = text2.Split(new string[]
					{
						"\t"
					}, StringSplitOptions.RemoveEmptyEntries);
					if (array.Length > 0)
					{
						string text3 = array[0];
						lstSN.Add(text3);
						text = text + text3 + ",";
					}
				}
				streamReader.Close();
				if (text != string.Empty)
				{
					text = text.Substring(0, text.Length - 1);
				}
			}
			return text;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000FC68 File Offset: 0x0000DE68
		private void btnLotSearch_Click(object sender, EventArgs e)
		{
			DataSet dataSet = new DataSet();
			this._slData.Clear();
			this.tab_ReportView.TabPages.Clear();
			this.gridLotList.RowsCount = 1;
			try
			{
				string text = string.Empty;
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				string text5 = string.Empty;
				List<string> list = new List<string>();
				if (this.rdoDate.Checked)
				{
					text5 = "DATE";
					text = Convert.ToDateTime(this.date_Start.Value).ToString("yyyy-MM-dd");
					text2 = Convert.ToDateTime(this.date_End.Value).ToString("yyyy-MM-dd");
				}
				else if (this.rdoLot.Checked)
				{
					if (this.txtSearchLotid.Text.Trim() == string.Empty)
					{
						MessageBox.Show("Input LotID please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					text5 = "LOT";
					text3 = this.txtSearchLotid.Text.Trim();
				}
				else if (this.rdoSN.Checked)
				{
					if (this.txtSearchSN.Text.Trim() == string.Empty)
					{
						MessageBox.Show("Input SN please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					text5 = "SN";
					text4 = this.txtSearchSN.Text.Trim();
				}
				else if (this.rdoLoadSN.Checked)
				{
					text5 = "SN";
					text4 = this.loadData(list);
					if (text4 == string.Empty)
					{
						MessageBox.Show("load SN List please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				else if (this.rdoLoadLot.Checked)
				{
					text5 = "LOT";
					text3 = this.loadData(list);
					if (text3 == string.Empty)
					{
						MessageBox.Show("load Lot List please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (list.Count > 300)
					{
						MessageBox.Show("Check load Lot count : up to 300.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Lot List....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				if (this.rdoLoadSN.Checked && list.Count > 300)
				{
					this._barPrograss.setMax(list.Count);
					this.gridLotList.RowsCount = 1;
					int num = 0;
					int num2 = list.Count / 300;
					int num3 = list.Count % 300;
					int num4 = 0;
					for (int i = 1; i <= num2; i++)
					{
						text4 = string.Empty;
						int num5 = i * 300;
						if (i == num2)
						{
							num5 += num3;
						}
						for (int j = num4; j < num5; j++)
						{
							text4 = text4 + list[j] + ",";
						}
						num4 = num5;
						if (text4 != string.Empty)
						{
							text4 = text4.Substring(0, text4.Length - 1);
						}
						string sQuery = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetLotList] @startdate = '",
							text,
							"', @enddate = '",
							text2,
							"', @type = '",
							text5,
							"', @lot = '",
							text3,
							"', @sn = '",
							text4,
							"'"
						});
						dataSet = this.queryCall(sQuery);
						if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
						{
							int num6 = this.gridLotList.RowsCount;
							for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
							{
								string text6 = dataSet.Tables[0].Rows[k]["lotid"].ToString();
								string cellValue = dataSet.Tables[0].Rows[k]["dcc"].ToString();
								string cellValue2 = dataSet.Tables[0].Rows[k]["devicename"].ToString();
								string cellValue3 = dataSet.Tables[0].Rows[k]["productname"].ToString();
								string cellValue4 = string.Empty;
								if (this.rdoSN.Checked || this.rdoLoadSN.Checked)
								{
									cellValue4 = dataSet.Tables[0].Rows[k]["sn"].ToString();
								}
								if (!(text6 == string.Empty))
								{
									this.gridLotList.Rows.Insert(num6);
									if (!this.rdoDate.Checked)
									{
										this.gridLotList[num6, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(true));
									}
									else
									{
										this.gridLotList[num6, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
									}
									this.gridLotList[num6, 1] = new Cell(num6);
									this.gridLotList[num6, 2] = new Cell(text6);
									this.gridLotList[num6, 3] = new Cell(cellValue);
									this.gridLotList[num6, 4] = new Cell(cellValue2);
									this.gridLotList[num6, 5] = new Cell(cellValue3);
									this.gridLotList[num6, 6] = new Cell(cellValue4);
									num6++;
									this._barPrograss.setValue(num + 1);
									num++;
								}
							}
						}
					}
					if (this._barPrograss != null)
					{
						this._barPrograss.setMax(100);
						this._barPrograss.setValue(100);
						Thread.Sleep(100);
						this._barPrograss._ischeck = true;
						this._barPrograss = null;
					}
					if (!this.rdoDate.Checked)
					{
						this.cmd_Yield_Search_Click(null, null);
					}
				}
				else
				{
					string sQuery2 = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetLotList] @startdate = '",
						text,
						"', @enddate = '",
						text2,
						"', @type = '",
						text5,
						"', @lot = '",
						text3,
						"', @sn = '",
						text4,
						"'"
					});
					dataSet = this.queryCall(sQuery2);
					if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
						int num7 = this.gridLotList.RowsCount;
						for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
						{
							string text7 = dataSet.Tables[0].Rows[l]["lotid"].ToString();
							string cellValue5 = dataSet.Tables[0].Rows[l]["dcc"].ToString();
							string cellValue6 = dataSet.Tables[0].Rows[l]["devicename"].ToString();
							string cellValue7 = dataSet.Tables[0].Rows[l]["productname"].ToString();
							string cellValue8 = string.Empty;
							if (this.rdoSN.Checked || this.rdoLoadSN.Checked)
							{
								cellValue8 = dataSet.Tables[0].Rows[l]["sn"].ToString();
							}
							if (!(text7 == string.Empty))
							{
								this.gridLotList.Rows.Insert(num7);
								if (!this.rdoDate.Checked)
								{
									this.gridLotList[num7, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(true));
								}
								else
								{
									this.gridLotList[num7, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
								}
								this.gridLotList[num7, 1] = new Cell(num7);
								this.gridLotList[num7, 2] = new Cell(text7);
								this.gridLotList[num7, 3] = new Cell(cellValue5);
								this.gridLotList[num7, 4] = new Cell(cellValue6);
								this.gridLotList[num7, 5] = new Cell(cellValue7);
								this.gridLotList[num7, 6] = new Cell(cellValue8);
								num7++;
								this._barPrograss.setValue(l + 1);
							}
						}
						if (this._barPrograss != null)
						{
							this._barPrograss.setMax(100);
							this._barPrograss.setValue(100);
							Thread.Sleep(100);
							this._barPrograss._ischeck = true;
							this._barPrograss = null;
						}
						if (!this.rdoDate.Checked)
						{
							this.cmd_Yield_Search_Click(null, null);
						}
					}
					else
					{
						if (this._barPrograss != null)
						{
							this._barPrograss.setMax(100);
							this._barPrograss.setValue(100);
							Thread.Sleep(100);
							this._barPrograss._ischeck = true;
							this._barPrograss = null;
						}
						MessageBox.Show("Data does not exist", "CIMitarReport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000106CC File Offset: 0x0000E8CC
		private void cmd_Yield_Search_Click(object sender, EventArgs e)
		{
			try
			{
				this._slData.Clear();
				this._slBindingData.Clear();
				this.tab_ReportView.TabPages.Clear();
				if (this.chkCmbReportType.CheckedItems.Count == 0)
				{
					MessageBox.Show("Select Reporttype please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					StationData stationData = new StationData();
					StationIDData stationIDData = new StationIDData();
					LotData lotData = new LotData();
					UnitData unitData = new UnitData();
					SortedList sortedList = new SortedList();
					string text = string.Empty;
					string text2 = string.Empty;
					string text3 = string.Empty;
					if (this.rdoLot.Checked)
					{
						text = "LOT";
					}
					else if (this.rdoSN.Checked || this.rdoLoadSN.Checked)
					{
						text = "SN";
					}
					if (this.rdoNormal.Checked)
					{
						text3 = "Normal";
					}
					else if (this.rdoAll.Checked)
					{
						text3 = "All";
					}
					else if (this.rdoAudit.Checked)
					{
						text3 = "Audit";
					}
					if (this.chkCmbOperation.CheckedItems.Count > 0)
					{
						for (int i = 0; i < this.chkCmbOperation.CheckedItems.Count; i++)
						{
							if (text2 != string.Empty)
							{
								text2 += ",";
							}
							text2 = text2 + "''" + this.chkCmbOperation.CheckedItems[i].ToString() + "''";
						}
					}
					for (int j = 1; j < this.gridLotList.Rows.Count; j++)
					{
						if ((bool)this.gridLotList[j, 0].Value)
						{
							lotData = new LotData();
							string key = this.gridLotList[j, 1].ToString();
							lotData.Lotid = this.gridLotList[j, 2].ToString();
							lotData.Dcc = this.gridLotList[j, 3].ToString();
							lotData.Device = this.gridLotList[j, 4].ToString();
							lotData.sProduct = this.gridLotList[j, 5].ToString();
							lotData.sSN = this.gridLotList[j, 6].ToString();
							sortedList.Add(key, lotData);
						}
					}
					if (sortedList.Count == 0)
					{
						MessageBox.Show("There is no selected lot. \nSelect lot please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Loading Data....");
						this._barPrograss.setValue(0);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						this._barPrograss.setMax(sortedList.Count);
						for (int k = 0; k < sortedList.Count; k++)
						{
							lotData = (LotData)sortedList.GetByIndex(k);
							string sQuery = string.Concat(new string[]
							{
								"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUnitResultData] @type  = '",
								text,
								"', @lot  = '",
								lotData.Lotid,
								"', @sn  = '",
								lotData.sSN,
								"', @stationname  = '",
								text2,
								"', @dcc  = '",
								lotData.Dcc,
								"', @testmode  = '",
								text3,
								"'"
							});
							DataSet dataSet = this.queryCall(sQuery);
							if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
							{
								string empty = string.Empty;
								DataRow[] array = dataSet.Tables[0].Select(empty, "start_time");
								int l = 0;
								while (l < array.Length)
								{
									string device = lotData.Device;
									string sProduct = lotData.sProduct;
									string empty2 = string.Empty;
									string sProgram = array[l]["sw_version"].ToString();
									string text4 = array[l]["test_station_name"].ToString();
									string text5 = array[l]["station_id"].ToString();
									string key2 = array[l]["idx"].ToString();
									string text6 = array[l]["lotid"].ToString();
									string text7 = array[l]["sn"].ToString();
									string text8 = array[l]["result"].ToString();
									string text9 = array[l]["dcc"].ToString();
									string value = array[l]["indate"].ToString();
									string text10 = array[l]["start_time"].ToString();
									string text11 = array[l]["stop_time"].ToString();
									string fail_Value = this.UTF8ConvertToCharAll(array[l]["fail_value"].ToString());
									string failure_message = this.UTF8ConvertToCharAll(array[l]["failure_message"].ToString());
									string sw_version = array[l]["sw_version"].ToString();
									string testHeadId = array[l]["test_head_id"].ToString();
									string text12 = array[l]["num"].ToString();
									string auditMode = array[l]["audit_mode"].ToString();
									text12 == "4";
									DateTime value2 = Convert.ToDateTime(text10);
									double totalSeconds = Convert.ToDateTime(text11).Subtract(value2).TotalSeconds;
									string key3 = text6 + "_" + text9;
									if (!this._slData.ContainsKey(key2))
									{
										stationData = new StationData();
										stationData.Station = text4;
										this._slData.Add(key2, stationData);
									}
									else
									{
										stationData = (StationData)this._slData[key2];
									}
									if (!stationData.slLot.ContainsKey(key3))
									{
										lotData = new LotData();
										lotData.Lotid = text6;
										lotData.Dcc = text9;
										lotData.Device = device;
										lotData.sProduct = sProduct;
										lotData.sBuild = empty2;
										lotData.sProgram = sProgram;
										lotData.Station = text4;
										lotData.sStartTime = text10;
										lotData.sEndTime = text11;
										stationData.slLot.Add(key3, lotData);
									}
									else
									{
										lotData = (LotData)stationData.slLot[key3];
										lotData.sEndTime = text11;
										lotData.sProgram = sProgram;
									}
									if (!lotData.slUnit.ContainsKey(text7))
									{
										unitData = new UnitData();
										unitData.SN = text7;
										unitData.result = text8;
										unitData.Indate = Convert.ToDateTime(value);
										unitData.StartTime = text10;
										unitData.Dcc = text9;
										unitData.Product = sProduct;
										lotData.slUnit.Add(unitData.SN, unitData);
									}
									else
									{
										unitData = (UnitData)lotData.slUnit[text7];
									}
									UnitResult unitResult = new UnitResult();
									if (text8.ToUpper() == "PASS")
									{
										unitResult.iPassCnt++;
									}
									else
									{
										unitResult.iFailCnt++;
										if (!lotData.slFailData.ContainsKey(text7))
										{
											lotData.slFailData.Add(unitData.SN, unitData);
										}
									}
									unitResult.unit_Seq = new UnitData();
									unitResult.unit_Seq.LotID = text6;
									unitResult.unit_Seq.Device = device;
									unitResult.unit_Seq.Product = sProduct;
									unitResult.unit_Seq.SN = text7;
									unitResult.unit_Seq.result = text8;
									unitResult.unit_Seq.Indate = Convert.ToDateTime(value);
									unitResult.unit_Seq.Test_station_name = text4;
									unitResult.unit_Seq.Dcc = text9;
									unitResult.unit_Seq.StartTime = text10;
									unitResult.unit_Seq.StopTime = text11;
									unitResult.unit_Seq.Fail_Value = fail_Value;
									unitResult.unit_Seq.Failure_message = failure_message;
									unitResult.unit_Seq.Sw_version = sw_version;
									unitResult.unit_Seq.TestHeadId = testHeadId;
									unitResult.unit_Seq.TestTime = totalSeconds;
									unitResult.unit_Seq.Station_id = text5;
									unitResult.unit_Seq.AuditMode = auditMode;
									unitResult.unit_Seq.setFailData();
									string a;
									if ((a = text12) == null)
									{
										goto IL_8D6;
									}
									if (!(a == "1"))
									{
										if (!(a == "2"))
										{
											if (!(a == "3"))
											{
												goto IL_8D6;
											}
											unitResult.unit_Seq.Num = text12 + "rd";
										}
										else
										{
											unitResult.unit_Seq.Num = text12 + "nd";
										}
									}
									else
									{
										unitResult.unit_Seq.Num = text12 + "st";
									}
									IL_8EE:
									if (text5 != string.Empty)
									{
										string[] array2 = text5.Split(new char[]
										{
											'_'
										});
										if (array2.Length > 2)
										{
											unitResult.unit_Seq.Station_id = array2[2];
										}
									}
									unitData.slSeq.Add(unitData.slSeq.Count + 1, unitResult);
									if (!stationData.slStationId.ContainsKey(text5))
									{
										stationIDData = new StationIDData();
										stationIDData.StationID = text5;
										stationIDData.StationID_Number = stationIDData.setStationID_Number();
										stationData.slStationId.Add(text5, stationIDData);
									}
									else
									{
										stationIDData = (StationIDData)stationData.slStationId[text5];
									}
									if (!stationIDData.slLot.ContainsKey(key3))
									{
										lotData = new LotData();
										lotData.Lotid = text6;
										lotData.Dcc = text9;
										lotData.Device = device;
										lotData.sProduct = sProduct;
										lotData.Station = text4;
										stationIDData.slLot.Add(key3, lotData);
									}
									else
									{
										lotData = (LotData)stationIDData.slLot[key3];
									}
									if (!lotData.slUnit.ContainsKey(text7))
									{
										unitData = new UnitData();
										unitData.SN = text7;
										unitData.result = text8;
										unitData.Indate = Convert.ToDateTime(value);
										unitData.Station_id = text5;
										unitData.Product = sProduct;
										lotData.slUnit.Add(unitData.SN, unitData);
									}
									else
									{
										unitData = (UnitData)lotData.slUnit[text7];
									}
									unitResult = new UnitResult();
									if (text8.ToUpper() == "PASS")
									{
										unitResult.iPassCnt++;
									}
									else
									{
										unitResult.iFailCnt++;
									}
									unitData.slSeq.Add(unitData.slSeq.Count + 1, unitResult);
									l++;
									continue;
									IL_8D6:
									unitResult.unit_Seq.Num = text12 + "th";
									goto IL_8EE;
								}
							}
							this._barPrograss.setValue(k + 1);
						}
						for (int m = 0; m < this.chkCmbReportType.CheckedItems.Count; m++)
						{
							string a2;
							if ((a2 = this.chkCmbReportType.CheckedItems[m].ToString().Trim()) != null)
							{
								if (!(a2 == "Lot Yield"))
								{
									if (!(a2 == "Lot Yield(Per Station ID)"))
									{
										if (!(a2 == "Unit TestResult(Per unit)"))
										{
											if (a2 == "Failure Summary")
											{
												SourceGrid.Grid grid = this.addControl("FailureSummary", "Failure Summary", this.tab_ReportView);
												this.InitFailureSummaryGrid(grid);
												this.setBinding_FailureSummary(grid);
											}
										}
										else
										{
											SourceGrid.Grid grid2 = this.addControl("UnitTestResult", "Unit TestResult(Per unit)", this.tab_ReportView);
											this.InitUnitResultGrid(grid2);
											this.setBinding_UnitTestResult(grid2);
										}
									}
									else
									{
										SourceGrid.Grid grid3 = this.addControl("LotYield_PerstationID", "Lot Yield(Per Station ID)", this.tab_ReportView);
										this.InitYieldReportGrid_PerStationID(grid3);
										this.setBinding_LotYield_PerStationID(grid3);
									}
								}
								else
								{
									SourceGrid.Grid grid4 = this.addControl("LotYield", "Lot Yield", this.tab_ReportView);
									this.InitYieldReportGrid_PerStation(grid4);
									this.setBinding_LotYield_PerStation(grid4);
								}
							}
						}
						if (this.rdoLot.Checked)
						{
							if (this.tab_ReportView.TabPages.ContainsKey("LotYield"))
							{
								this.tab_ReportView.SelectTab("LotYield");
							}
						}
						else if (this.rdoSN.Checked && this.tab_ReportView.TabPages.ContainsKey("UnitTestResult"))
						{
							this.tab_ReportView.SelectTab("UnitTestResult");
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			finally
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000113E8 File Offset: 0x0000F5E8
		private void setBinding_LotYield_PerStationID(SourceGrid.Grid gridYieldReport)
		{
			SortedList slData = this._slData;
			StationData stationData = new StationData();
			StationIDData stationIDData = new StationIDData();
			LotData lotData = new LotData();
			UnitData unitData = new UnitData();
			SortedList sortedList = new SortedList();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < slData.Count; i++)
			{
				stationData = (StationData)slData.GetByIndex(i);
				for (int j = 0; j < stationData.slStationId.Count; j++)
				{
					stationIDData = (StationIDData)stationData.slStationId.GetByIndex(j);
					for (int k = 0; k < stationIDData.slLot.Count; k++)
					{
						lotData = (LotData)stationIDData.slLot.GetByIndex(k);
						for (int l = 0; l < lotData.slUnit.Count; l++)
						{
							unitData = (UnitData)lotData.slUnit.GetByIndex(l);
							int count = unitData.slSeq.Count;
							if (unitData.slSeq.Count > 0)
							{
								UnitResult unitResult = (UnitResult)unitData.slSeq.GetByIndex(0);
								lotData.PASS_1A += unitResult.iPassCnt;
								lotData.FAIL_1A += unitResult.iFailCnt;
								if (unitData.slSeq.Count > 1)
								{
									unitResult = (UnitResult)unitData.slSeq.GetByIndex(1);
									lotData.PASS_2A += unitResult.iPassCnt;
									lotData.FAIL_2A += unitResult.iFailCnt;
								}
								if (unitData.slSeq.Count > 2)
								{
									unitResult = (UnitResult)unitData.slSeq.GetByIndex(2);
									lotData.PASS_1B += unitResult.iPassCnt;
									lotData.FAIL_1B += unitResult.iFailCnt;
								}
								if (unitData.slSeq.Count > 3)
								{
									unitResult = (UnitResult)unitData.slSeq.GetByIndex(3);
									lotData.PASS_2B += unitResult.iPassCnt;
									lotData.FAIL_2B += unitResult.iFailCnt;
								}
								unitResult = (UnitResult)unitData.slSeq.GetByIndex(unitData.slSeq.Count - 1);
								lotData.PASS_FINAL += unitResult.iPassCnt;
								lotData.FAIL_FINAL += unitResult.iFailCnt;
							}
						}
						gridYieldReport.Rows.Insert(gridYieldReport.RowsCount);
						int num = gridYieldReport.RowsCount - 1;
						double num2 = Math.Round(double.Parse(lotData.PASS_1A.ToString()) / (double)lotData.slUnit.Count * 100.0, 2);
						double num3 = Math.Round(double.Parse(lotData.PASS_FINAL.ToString()) / (double)lotData.slUnit.Count * 100.0, 2);
						double num4 = Math.Round(num3 - num2, 2);
						gridYieldReport[num, 0] = new Cell(stationData.Station);
						gridYieldReport[num, 1] = new Cell(stationIDData.StationID_Number);
						gridYieldReport[num, 2] = new Cell(lotData.Lotid);
						gridYieldReport[num, 3] = new Cell(lotData.Dcc);
						gridYieldReport[num, 4] = new Cell(lotData.slUnit.Count);
						gridYieldReport[num, 5] = new Cell(lotData.PASS_FINAL);
						gridYieldReport[num, 6] = new Cell(lotData.FAIL_FINAL);
						gridYieldReport[num, 7] = new Cell(num3.ToString() + "%");
						gridYieldReport[num, 8] = new Cell(lotData.PASS_1A);
						gridYieldReport[num, 9] = new Cell(lotData.FAIL_1A);
						gridYieldReport[num, 10] = new Cell(num2.ToString() + "%");
						gridYieldReport[num, 11] = new Cell(num4 + "%");
						gridYieldReport[num, 12] = new Cell(lotData.PASS_2A);
						gridYieldReport[num, 13] = new Cell(lotData.FAIL_2A);
						gridYieldReport[num, 14] = new Cell(lotData.PASS_1B);
						gridYieldReport[num, 15] = new Cell(lotData.FAIL_1B);
						gridYieldReport[num, 16] = new Cell(lotData.PASS_2B);
						gridYieldReport[num, 17] = new Cell(lotData.FAIL_2B);
						if (sortedList.Count == 0)
						{
							arrayList = new ArrayList();
							arrayList.Add(gridYieldReport[0, 0].ToString());
							arrayList.Add(gridYieldReport[0, 1].ToString());
							arrayList.Add(gridYieldReport[0, 2].ToString());
							arrayList.Add(gridYieldReport[0, 3].ToString());
							arrayList.Add(gridYieldReport[0, 4].ToString());
							arrayList.Add(gridYieldReport[0, 5].ToString());
							arrayList.Add(gridYieldReport[0, 6].ToString());
							arrayList.Add(gridYieldReport[0, 7].ToString());
							arrayList.Add(gridYieldReport[0, 8].ToString());
							arrayList.Add(gridYieldReport[0, 9].ToString());
							arrayList.Add(gridYieldReport[0, 10].ToString());
							arrayList.Add(gridYieldReport[0, 11].ToString());
							arrayList.Add(gridYieldReport[0, 12].ToString());
							arrayList.Add(gridYieldReport[0, 13].ToString());
							arrayList.Add(gridYieldReport[0, 14].ToString());
							arrayList.Add(gridYieldReport[0, 15].ToString());
							arrayList.Add(gridYieldReport[0, 16].ToString());
							arrayList.Add(gridYieldReport[0, 17].ToString());
							sortedList.Add(0, arrayList);
						}
						arrayList = new ArrayList();
						arrayList.Add(stationData.Station);
						arrayList.Add(stationIDData.StationID_Number);
						arrayList.Add(lotData.Lotid);
						arrayList.Add(lotData.Dcc);
						arrayList.Add(lotData.slUnit.Count);
						arrayList.Add(lotData.PASS_FINAL);
						arrayList.Add(lotData.FAIL_FINAL);
						arrayList.Add(num3.ToString() + "%");
						arrayList.Add(lotData.PASS_1A);
						arrayList.Add(lotData.FAIL_1A);
						arrayList.Add(num2.ToString() + "%");
						arrayList.Add(num4 + "%");
						arrayList.Add(lotData.PASS_2A);
						arrayList.Add(lotData.FAIL_2A);
						arrayList.Add(lotData.PASS_1B);
						arrayList.Add(lotData.FAIL_1B);
						arrayList.Add(lotData.PASS_2B);
						arrayList.Add(lotData.FAIL_2B);
						sortedList.Add(num, arrayList);
					}
				}
			}
			if (sortedList.Count > 0)
			{
				this._slBindingData.Add("LotYield_PerstationID", sortedList);
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00011C44 File Offset: 0x0000FE44
		private void setBinding_LotYield_PerStation(SourceGrid.Grid gridYieldReport)
		{
			SortedList slData = this._slData;
			StationData stationData = new StationData();
			new StationIDData();
			LotData lotData = new LotData();
			UnitData unitData = new UnitData();
			SortedList sortedList = new SortedList();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < slData.Count; i++)
			{
				stationData = (StationData)slData.GetByIndex(i);
				for (int j = 0; j < stationData.slLot.Count; j++)
				{
					lotData = (LotData)stationData.slLot.GetByIndex(j);
					for (int k = 0; k < lotData.slUnit.Count; k++)
					{
						unitData = (UnitData)lotData.slUnit.GetByIndex(k);
						int count = unitData.slSeq.Count;
						if (unitData.slSeq.Count > 0)
						{
							UnitResult unitResult = (UnitResult)unitData.slSeq.GetByIndex(0);
							lotData.PASS_1A += unitResult.iPassCnt;
							lotData.FAIL_1A += unitResult.iFailCnt;
							if (unitData.slSeq.Count > 1)
							{
								unitResult = (UnitResult)unitData.slSeq.GetByIndex(1);
								lotData.PASS_2A += unitResult.iPassCnt;
								lotData.FAIL_2A += unitResult.iFailCnt;
							}
							if (unitData.slSeq.Count > 2)
							{
								unitResult = (UnitResult)unitData.slSeq.GetByIndex(2);
								lotData.PASS_1B += unitResult.iPassCnt;
								lotData.FAIL_1B += unitResult.iFailCnt;
							}
							if (unitData.slSeq.Count > 3)
							{
								unitResult = (UnitResult)unitData.slSeq.GetByIndex(3);
								lotData.PASS_2B += unitResult.iPassCnt;
								lotData.FAIL_2B += unitResult.iFailCnt;
							}
							unitResult = (UnitResult)unitData.slSeq.GetByIndex(unitData.slSeq.Count - 1);
							lotData.PASS_FINAL += unitResult.iPassCnt;
							lotData.FAIL_FINAL += unitResult.iFailCnt;
						}
					}
					gridYieldReport.Rows.Insert(gridYieldReport.RowsCount);
					int num = gridYieldReport.RowsCount - 1;
					double num2 = Math.Round(double.Parse(lotData.PASS_1A.ToString()) / (double)lotData.slUnit.Count * 100.0, 2);
					double num3 = Math.Round(double.Parse(lotData.PASS_FINAL.ToString()) / (double)lotData.slUnit.Count * 100.0, 2);
					double num4 = Math.Round(num3 - num2, 2);
					gridYieldReport[num, 0] = new Cell(stationData.Station);
					gridYieldReport[num, 1] = new Cell(lotData.sProduct);
					gridYieldReport[num, 2] = new Cell(lotData.Device);
					gridYieldReport[num, 3] = new Cell(lotData.Lotid);
					gridYieldReport[num, 4] = new Cell(lotData.Dcc);
					gridYieldReport[num, 5] = new Cell(lotData.sProgram);
					gridYieldReport[num, 6] = new Cell(lotData.sStartTime);
					gridYieldReport[num, 7] = new Cell(lotData.sEndTime);
					gridYieldReport[num, 8] = new Cell(lotData.slUnit.Count);
					gridYieldReport[num, 9] = new Cell(lotData.PASS_FINAL);
					gridYieldReport[num, 10] = new Cell(lotData.FAIL_FINAL);
					gridYieldReport[num, 11] = new Cell(num3.ToString() + "%");
					gridYieldReport[num, 12] = new Cell(lotData.PASS_1A);
					gridYieldReport[num, 13] = new Cell(lotData.FAIL_1A);
					gridYieldReport[num, 14] = new Cell(num2.ToString() + "%");
					gridYieldReport[num, 15] = new Cell(num4.ToString() + "%");
					gridYieldReport[num, 16] = new Cell(lotData.PASS_2A);
					gridYieldReport[num, 17] = new Cell(lotData.FAIL_2A);
					gridYieldReport[num, 18] = new Cell(lotData.PASS_1B);
					gridYieldReport[num, 19] = new Cell(lotData.FAIL_1B);
					gridYieldReport[num, 20] = new Cell(lotData.PASS_2B);
					gridYieldReport[num, 21] = new Cell(lotData.FAIL_2B);
					if (sortedList.Count == 0)
					{
						arrayList = new ArrayList();
						arrayList.Add(gridYieldReport[0, 0].ToString());
						arrayList.Add(gridYieldReport[0, 1].ToString());
						arrayList.Add(gridYieldReport[0, 2].ToString());
						arrayList.Add(gridYieldReport[0, 3].ToString());
						arrayList.Add(gridYieldReport[0, 4].ToString());
						arrayList.Add(gridYieldReport[0, 5].ToString());
						arrayList.Add(gridYieldReport[0, 6].ToString());
						arrayList.Add(gridYieldReport[0, 7].ToString());
						arrayList.Add(gridYieldReport[0, 8].ToString());
						arrayList.Add(gridYieldReport[0, 9].ToString());
						arrayList.Add(gridYieldReport[0, 10].ToString());
						arrayList.Add(gridYieldReport[0, 11].ToString());
						arrayList.Add(gridYieldReport[0, 12].ToString());
						arrayList.Add(gridYieldReport[0, 13].ToString());
						arrayList.Add(gridYieldReport[0, 14].ToString());
						arrayList.Add(gridYieldReport[0, 15].ToString());
						arrayList.Add(gridYieldReport[0, 16].ToString());
						arrayList.Add(gridYieldReport[0, 17].ToString());
						arrayList.Add(gridYieldReport[0, 18].ToString());
						arrayList.Add(gridYieldReport[0, 19].ToString());
						arrayList.Add(gridYieldReport[0, 20].ToString());
						arrayList.Add(gridYieldReport[0, 21].ToString());
						sortedList.Add(0, arrayList);
					}
					arrayList = new ArrayList();
					arrayList.Add(stationData.Station);
					arrayList.Add(lotData.sProduct);
					arrayList.Add(lotData.Device);
					arrayList.Add(lotData.Lotid);
					arrayList.Add(lotData.Dcc);
					arrayList.Add(lotData.sProgram);
					arrayList.Add(lotData.sStartTime);
					arrayList.Add(lotData.sEndTime);
					arrayList.Add(lotData.slUnit.Count);
					arrayList.Add(lotData.PASS_FINAL);
					arrayList.Add(lotData.FAIL_FINAL);
					arrayList.Add(num3.ToString() + "%");
					arrayList.Add(lotData.PASS_1A);
					arrayList.Add(lotData.FAIL_1A);
					arrayList.Add(num2.ToString() + "%");
					arrayList.Add(num4.ToString() + "%");
					arrayList.Add(lotData.PASS_2A);
					arrayList.Add(lotData.FAIL_2A);
					arrayList.Add(lotData.PASS_1B);
					arrayList.Add(lotData.FAIL_1B);
					arrayList.Add(lotData.PASS_2B);
					arrayList.Add(lotData.FAIL_2B);
					sortedList.Add(num, arrayList);
				}
			}
			if (sortedList.Count > 0)
			{
				this._slBindingData.Add("LotYield", sortedList);
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00012554 File Offset: 0x00010754
		private void setBinding_UnitTestResult(SourceGrid.Grid gridYieldReport)
		{
			SortedList slData = this._slData;
			StationData stationData = new StationData();
			new StationIDData();
			LotData lotData = new LotData();
			UnitData unitData = new UnitData();
			Console.WriteLine("Start : " + DateTime.Now);
			gridYieldReport.RowsCount = 1;
			SortedList sortedList = new SortedList();
			new ArrayList();
			for (int i = 0; i < slData.Count; i++)
			{
				stationData = (StationData)slData.GetByIndex(i);
				for (int j = 0; j < stationData.slLot.Count; j++)
				{
					lotData = (LotData)stationData.slLot.GetByIndex(j);
					for (int k = 0; k < lotData.slUnit.Count; k++)
					{
						unitData = (UnitData)lotData.slUnit.GetByIndex(k);
						if (this.cmbTestType.Text == "1st")
						{
							UnitResult unitResult = (UnitResult)unitData.slSeq.GetByIndex(0);
							this.setBinding_row(gridYieldReport, unitResult.unit_Seq, sortedList);
						}
						else if (this.cmbTestType.Text == "Final")
						{
							UnitResult unitResult2 = (UnitResult)unitData.slSeq.GetByIndex(unitData.slSeq.Count - 1);
							this.setBinding_row(gridYieldReport, unitResult2.unit_Seq, sortedList);
						}
						else
						{
							for (int l = 0; l < unitData.slSeq.Count; l++)
							{
								UnitResult unitResult3 = (UnitResult)unitData.slSeq.GetByIndex(l);
								this.setBinding_row(gridYieldReport, unitResult3.unit_Seq, sortedList);
							}
						}
					}
				}
			}
			if (sortedList.Count > 0)
			{
				this._slBindingData.Add("UnitTestResult", sortedList);
			}
			Console.WriteLine("End : " + DateTime.Now);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00012748 File Offset: 0x00010948
		private void setBinding_FailureSummary(SourceGrid.Grid gridYieldReport)
		{
			SortedList slData = this._slData;
			StationData stationData = new StationData();
			new StationIDData();
			LotData lotData = new LotData();
			UnitData unitData = new UnitData();
			new ArrayList();
			SortedList sortedList = new SortedList();
			Console.WriteLine("Start : " + DateTime.Now);
			gridYieldReport.RowsCount = 1;
			for (int i = 0; i < slData.Count; i++)
			{
				stationData = (StationData)slData.GetByIndex(i);
				for (int j = 0; j < stationData.slLot.Count; j++)
				{
					SortedList<string, int> sortedList2 = new SortedList<string, int>();
					SortedList<string, int> sortedList3 = new SortedList<string, int>();
					lotData = (LotData)stationData.slLot.GetByIndex(j);
					for (int k = 0; k < lotData.slFailData.Count; k++)
					{
						unitData = (UnitData)lotData.slFailData.GetByIndex(k);
						UnitResult unitResult = null;
						UnitResult unitResult2 = null;
						if (unitData.slSeq.Count > 0)
						{
							unitResult = (UnitResult)unitData.slSeq.GetByIndex(0);
							unitResult2 = (UnitResult)unitData.slSeq.GetByIndex(unitData.slSeq.Count - 1);
						}
						if ((this.cmbTestType.Text == string.Empty || this.cmbTestType.Text == "ALL" || this.cmbTestType.Text == "1st") && unitResult != null && unitResult.unit_Seq.result == "FAIL")
						{
							if (!sortedList2.ContainsKey(unitResult.unit_Seq.Fail_FT))
							{
								sortedList2.Add(unitResult.unit_Seq.Fail_FT, 1);
							}
							else
							{
								sortedList2[unitResult.unit_Seq.Fail_FT] = sortedList2[unitResult.unit_Seq.Fail_FT] + 1;
							}
						}
						if ((this.cmbTestType.Text == string.Empty || this.cmbTestType.Text == "ALL" || this.cmbTestType.Text == "Final") && unitResult2 != null && unitResult2.unit_Seq.result == "FAIL")
						{
							if (!sortedList3.ContainsKey(unitResult2.unit_Seq.Fail_FT))
							{
								sortedList3.Add(unitResult2.unit_Seq.Fail_FT, 1);
							}
							else
							{
								sortedList3[unitResult2.unit_Seq.Fail_FT] = sortedList3[unitResult2.unit_Seq.Fail_FT] + 1;
							}
						}
					}
					List<KeyValuePair<string, int>> list = (from v in sortedList2
					orderby v.Value descending
					select v).ToList<KeyValuePair<string, int>>();
					List<KeyValuePair<string, int>> list2 = (from v in sortedList3
					orderby v.Value descending
					select v).ToList<KeyValuePair<string, int>>();
					if (list.Count > 0)
					{
						this.setBinding_row(gridYieldReport, lotData, "1st", list, sortedList);
					}
					if (list2.Count > 0)
					{
						this.setBinding_row(gridYieldReport, lotData, "Final", list2, sortedList);
					}
				}
			}
			if (sortedList.Count > 0)
			{
				this._slBindingData.Add("Failure Summary", sortedList);
			}
			Console.WriteLine("End : " + DateTime.Now);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00012AB0 File Offset: 0x00010CB0
		private void setBinding_row(SourceGrid.Grid gridYieldReport, LotData lot, string sTestType, List<KeyValuePair<string, int>> slList, SortedList slExcelBindList)
		{
			int num = 0;
			ArrayList arrayList = new ArrayList();
			int count = lot.slUnit.Count;
			if (slExcelBindList.Count == 0)
			{
				arrayList = new ArrayList();
				for (int i = 0; i < gridYieldReport.ColumnsCount; i++)
				{
					arrayList.Add(gridYieldReport[0, i].ToString());
				}
				slExcelBindList.Add(0, arrayList);
			}
			int num2;
			for (int j = 0; j < slList.Count; j++)
			{
				gridYieldReport.Rows.Insert(gridYieldReport.RowsCount);
				num2 = gridYieldReport.RowsCount - 1;
				string key = slList[j].Key;
				int num3 = int.Parse(slList[j].Value.ToString());
				double num4 = Math.Round(Convert.ToDouble(num3) / Convert.ToDouble(count) * 100.0, 4);
				gridYieldReport[num2, 0] = new Cell(lot.sProduct);
				gridYieldReport[num2, 1] = new Cell(lot.Device);
				gridYieldReport[num2, 2] = new Cell(lot.Lotid);
				gridYieldReport[num2, 3] = new Cell(lot.Dcc);
				gridYieldReport[num2, 4] = new Cell(lot.Station);
				gridYieldReport[num2, 5] = new Cell(sTestType);
				gridYieldReport[num2, 6] = new Cell(key);
				gridYieldReport[num2, 7] = new Cell(num3.ToString());
				gridYieldReport[num2, 8] = new Cell(num4.ToString() + "%");
				num += num3;
				arrayList = new ArrayList();
				arrayList.Add(lot.sProduct);
				arrayList.Add(lot.Device);
				arrayList.Add(lot.Lotid);
				arrayList.Add(lot.Dcc);
				arrayList.Add(lot.Station);
				arrayList.Add(sTestType);
				arrayList.Add(key);
				arrayList.Add(num3.ToString());
				arrayList.Add(num4.ToString() + "%");
				slExcelBindList.Add(num2, arrayList);
			}
			gridYieldReport.Rows.Insert(gridYieldReport.RowsCount);
			num2 = gridYieldReport.RowsCount - 1;
			double num5 = Math.Round(Convert.ToDouble(num) / Convert.ToDouble(count) * 100.0, 4);
			gridYieldReport[num2, 0] = new Cell(string.Empty);
			gridYieldReport[num2, 1] = new Cell(string.Empty);
			gridYieldReport[num2, 2] = new Cell(string.Empty);
			gridYieldReport[num2, 3] = new Cell(string.Empty);
			gridYieldReport[num2, 4] = new Cell(string.Empty);
			gridYieldReport[num2, 5] = new Cell(string.Empty);
			gridYieldReport[num2, 6] = new Cell("Total");
			gridYieldReport[num2, 7] = new Cell(num.ToString());
			gridYieldReport[num2, 8] = new Cell(num5.ToString() + "%");
			arrayList = new ArrayList();
			arrayList.Add(string.Empty);
			arrayList.Add(string.Empty);
			arrayList.Add(string.Empty);
			arrayList.Add(string.Empty);
			arrayList.Add(string.Empty);
			arrayList.Add(string.Empty);
			arrayList.Add("Total");
			arrayList.Add(num.ToString());
			arrayList.Add(num5.ToString() + "%");
			slExcelBindList.Add(num2, arrayList);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00012E68 File Offset: 0x00011068
		private void setBinding_row(SourceGrid.Grid gridYieldReport, UnitData unit, SortedList slDataList)
		{
			if ((this.cmbPF.Text == "FAIL" && unit.result != "FAIL") || (this.cmbPF.Text == "PASS" && unit.result != "PASS"))
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			gridYieldReport.Rows.Insert(gridYieldReport.RowsCount);
			int num = gridYieldReport.RowsCount - 1;
			int num2 = 0;
			gridYieldReport[num, num2++] = new Cell(num);
			gridYieldReport[num, num2++] = new Cell(unit.SN);
			gridYieldReport[num, num2++] = new Cell(unit.Product);
			gridYieldReport[num, num2++] = new Cell(unit.Device);
			gridYieldReport[num, num2++] = new Cell(unit.LotID);
			gridYieldReport[num, num2++] = new Cell(unit.Dcc);
			gridYieldReport[num, num2++] = new Cell(unit.Test_station_name);
			gridYieldReport[num, num2++] = new Cell(unit.Num);
			gridYieldReport[num, num2++] = new Cell(unit.Sw_version);
			gridYieldReport[num, num2++] = new Cell(unit.Station_id);
			gridYieldReport[num, num2++] = new Cell(unit.TestHeadId);
			gridYieldReport[num, num2++] = new Cell(unit.result);
			gridYieldReport[num, num2++] = new Cell(unit.StartTime);
			gridYieldReport[num, num2++] = new Cell(unit.StopTime);
			gridYieldReport[num, num2++] = new Cell(unit.TestTime);
			gridYieldReport[num, num2++] = new Cell(unit.AuditMode);
			gridYieldReport[num, num2++] = new Cell(unit.Fail_FT);
			gridYieldReport[num, num2++] = new Cell(unit.FT_1_Value);
			gridYieldReport[num, num2++] = new Cell(unit.FT_1_Units);
			gridYieldReport[num, num2++] = new Cell(unit.FT_1_Upper_Limit);
			gridYieldReport[num, num2++] = new Cell(unit.FT_1_Lower_Limit);
			gridYieldReport[num, num2++] = new Cell(unit.Fail_FT2);
			gridYieldReport[num, num2++] = new Cell(unit.FT_2_Value);
			gridYieldReport[num, num2++] = new Cell(unit.FT_2_Units);
			gridYieldReport[num, num2++] = new Cell(unit.FT_2_Upper_Limit);
			gridYieldReport[num, num2++] = new Cell(unit.FT_2_Lower_Limit);
			gridYieldReport[num, num2++] = new Cell(unit.Fail_FT3);
			gridYieldReport[num, num2++] = new Cell(unit.FT_3_Value);
			gridYieldReport[num, num2++] = new Cell(unit.FT_3_Units);
			gridYieldReport[num, num2++] = new Cell(unit.FT_3_Upper_Limit);
			gridYieldReport[num, num2++] = new Cell(unit.FT_3_Lower_Limit);
			gridYieldReport[num, num2++] = new Cell(unit.Fail_FT4);
			gridYieldReport[num, num2++] = new Cell(unit.FT_4_Value);
			gridYieldReport[num, num2++] = new Cell(unit.FT_4_Units);
			gridYieldReport[num, num2++] = new Cell(unit.FT_4_Upper_Limit);
			gridYieldReport[num, num2++] = new Cell(unit.FT_4_Lower_Limit);
			gridYieldReport[num, num2++] = new Cell(unit.Fail_FT5);
			gridYieldReport[num, num2++] = new Cell(unit.FT_5_Value);
			gridYieldReport[num, num2++] = new Cell(unit.FT_5_Units);
			gridYieldReport[num, num2++] = new Cell(unit.FT_5_Upper_Limit);
			gridYieldReport[num, num2++] = new Cell(unit.FT_5_Lower_Limit);
			if (slDataList.Count == 0)
			{
				arrayList = new ArrayList();
				for (int i = 0; i < gridYieldReport.ColumnsCount; i++)
				{
					arrayList.Add(gridYieldReport[0, i].ToString());
				}
				slDataList.Add(0, arrayList);
			}
			arrayList = new ArrayList();
			arrayList.Add(num);
			arrayList.Add(unit.SN);
			arrayList.Add(unit.Product);
			arrayList.Add(unit.Device);
			arrayList.Add(unit.LotID);
			arrayList.Add(unit.Dcc);
			arrayList.Add(unit.Test_station_name);
			arrayList.Add(unit.Num);
			arrayList.Add(unit.Sw_version);
			arrayList.Add(unit.Station_id);
			arrayList.Add(unit.TestHeadId);
			arrayList.Add(unit.result);
			arrayList.Add(unit.StartTime);
			arrayList.Add(unit.StopTime);
			arrayList.Add(unit.TestTime);
			arrayList.Add(unit.AuditMode);
			arrayList.Add(unit.Fail_FT);
			arrayList.Add(unit.FT_1_Value);
			arrayList.Add(unit.FT_1_Units);
			arrayList.Add(unit.FT_1_Upper_Limit);
			arrayList.Add(unit.FT_1_Lower_Limit);
			arrayList.Add(unit.Fail_FT2);
			arrayList.Add(unit.FT_2_Value);
			arrayList.Add(unit.FT_2_Units);
			arrayList.Add(unit.FT_2_Upper_Limit);
			arrayList.Add(unit.FT_2_Lower_Limit);
			arrayList.Add(unit.Fail_FT3);
			arrayList.Add(unit.FT_3_Value);
			arrayList.Add(unit.FT_3_Units);
			arrayList.Add(unit.FT_3_Upper_Limit);
			arrayList.Add(unit.FT_3_Lower_Limit);
			arrayList.Add(unit.Fail_FT4);
			arrayList.Add(unit.FT_4_Value);
			arrayList.Add(unit.FT_4_Units);
			arrayList.Add(unit.FT_4_Upper_Limit);
			arrayList.Add(unit.FT_4_Lower_Limit);
			arrayList.Add(unit.Fail_FT5);
			arrayList.Add(unit.FT_5_Value);
			arrayList.Add(unit.FT_5_Units);
			arrayList.Add(unit.FT_5_Upper_Limit);
			arrayList.Add(unit.FT_5_Lower_Limit);
			slDataList.Add(num, arrayList);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0001350C File Offset: 0x0001170C
		private TabControl addTabControl(bool visibleFlag)
		{
			TabControl tabControl = new TabControl();
			tabControl.Location = new Point(1, 6);
			tabControl.Name = "tabControlPreview";
			tabControl.Size = new Size(600, 400);
			if (visibleFlag)
			{
				this.panelView.Controls.Add(tabControl);
				tabControl.Dock = DockStyle.Fill;
				tabControl.Visible = true;
			}
			else
			{
				tabControl.Visible = false;
			}
			return tabControl;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00013578 File Offset: 0x00011778
		private SourceGrid.Grid addControl(string sPageName, string sPageText, TabControl tabControl)
		{
			SourceGrid.Grid grid = new SourceGrid.Grid();
			grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grid.ClipboardMode = ClipboardMode.Copy;
			grid.Dock = DockStyle.Fill;
			grid.EnableSort = true;
			grid.Font = new Font("Segoe UI", 8.25f);
			grid.Location = new Point(8, 8);
			grid.Name = "grid" + sPageName;
			grid.OptimizeMode = CellOptimizeMode.ForRows;
			grid.SelectionMode = GridSelectionMode.Cell;
			grid.Size = new Size(200, 10);
			grid.TabIndex = 6;
			grid.TabStop = true;
			grid.ToolTipText = "";
			grid.EnableSort = false;
			TabPage tabPage = new TabPage();
			tabPage.Location = new Point(4, 22);
			tabPage.Name = sPageName;
			tabPage.Text = sPageText;
			tabPage.Padding = new System.Windows.Forms.Padding(3);
			tabPage.Size = new Size(1, 1);
			tabPage.Font = new Font("Segoe UI", 8.25f);
			tabPage.TabIndex = 0;
			tabPage.UseVisualStyleBackColor = true;
			tabPage.Controls.Add(grid);
			tabControl.TabPages.Add(tabPage);
			grid.BringToFront();
			return grid;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00013698 File Offset: 0x00011898
		private void cmd_Yield_Excel_Click(object sender, EventArgs e)
		{
			try
			{
				if (this._slBindingData.Count == 0)
				{
					MessageBox.Show("Data does not exist", "CIMitarReport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						ExcelControl.Save(this.saveFileDialog.FileName, this._slBindingData, true);
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x000137D4 File Offset: 0x000119D4
		private void ESI_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (sender != this)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000137E4 File Offset: 0x000119E4
		private void pbCheckIn_Click(object sender, EventArgs e)
		{
			bool flag = false;
			string empty = string.Empty;
			for (int i = 1; i < this.gridUnitList.RowsCount; i++)
			{
				if ((bool)this.gridUnitList[i, 14].Value)
				{
					flag = true;
					UnitData sn_Info = this.getSN_Info("CHECKIN", (string)this.gridUnitList[i, 2].Value);
					if (sn_Info.SN == string.Empty)
					{
						MessageBox.Show("sn is not exist. check please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (sn_Info.Status != "REQUEST")
					{
						MessageBox.Show(" sn is not request status. check please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (sn_Info.Status == "CHECKIN")
					{
						MessageBox.Show("sn:" + sn_Info.SN + " is already checkin. check please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					sn_Info.Status = "CHECKIN";
					this.SetCheckInOut(sn_Info, false);
					this.gridUnitList[i, 14].Value = false;
				}
			}
			if (flag)
			{
				this.cmdUnitSearch_Click(this.cmdUnitSearch, null);
				MessageBox.Show("Check in Completed", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00013928 File Offset: 0x00011B28
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			bool flag = false;
			string empty = string.Empty;
			for (int i = 1; i < this.gridUnitList.RowsCount; i++)
			{
				if ((bool)this.gridUnitList[i, 14].Value)
				{
					flag = true;
					UnitData sn_Info = this.getSN_Info("CHECKOUT", (string)this.gridUnitList[i, 2].Value);
					if (sn_Info.SN == string.Empty)
					{
						MessageBox.Show(" sn is not exist. check please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (sn_Info.Status != "CHECKIN")
					{
						MessageBox.Show(" sn is not checkIn status. check please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					sn_Info.Status = "CHECKOUT";
					this.SetCheckInOut(sn_Info, false);
					this.gridUnitList[i, 14].Value = false;
				}
			}
			if (flag)
			{
				this.cmdUnitSearch_Click(this.cmdUnitSearch, null);
				MessageBox.Show("Check out Completed", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00013A36 File Offset: 0x00011C36
		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tabControl.SelectedIndex == 1)
			{
				this.gbExcel.Visible = true;
				return;
			}
			this.gbExcel.Visible = false;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00013A5F File Offset: 0x00011C5F
		private void pbRequestExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridUnitHistory);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00013A70 File Offset: 0x00011C70
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			CommentForm commentForm = new CommentForm();
			if (commentForm.ShowDialog() == DialogResult.Yes)
			{
				string sComment = commentForm._sComment;
				bool flag = false;
				for (int i = 1; i < this.gridUnitList.RowsCount; i++)
				{
					if ((bool)this.gridUnitList[i, 14].Value)
					{
						string a = (string)this.gridUnitList[i, 1].Value;
						if (a != "CHECKIN")
						{
							this.gridUnitList[i, 14].Value = false;
						}
						else
						{
							flag = true;
							string sUnitSN = (string)this.gridUnitList[i, 2].Value;
							this.updateComment(sUnitSN, sComment);
							this.gridUnitList[i, 14].Value = false;
						}
					}
				}
				if (flag)
				{
					this.cmdUnitSearch_Click(this.cmdUnitSearch, null);
					MessageBox.Show("comment update completed", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00013B70 File Offset: 0x00011D70
		private void updateComment(string sUnitSN, string sComment)
		{
			try
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_ESI_SetUnitData_FA_Comment]  @sn  = '",
					sUnitSN,
					"',  @comment  = '",
					sComment,
					"',  @userid  = '",
					this._cimitarUser._id,
					"'"
				});
				this.queryCall(sQuery);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00013BEC File Offset: 0x00011DEC
		private void cbAll_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cbAll.Checked)
			{
				if (this.gridUnitList.Rows.Count > 1)
				{
					for (int i = 1; i < this.gridUnitList.Rows.Count; i++)
					{
						this.gridUnitList[i, 14].Value = true;
					}
					return;
				}
			}
			else if (this.gridUnitList.Rows.Count > 1)
			{
				for (int j = 1; j < this.gridUnitList.Rows.Count; j++)
				{
					this.gridUnitList[j, 14].Value = false;
				}
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00013C98 File Offset: 0x00011E98
		private void pb2DId_Click(object sender, EventArgs e)
		{
			_2DList 2DList = new _2DList(this._factorySetting, this._cimitarUser._id);
			2DList.ShowDialog();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00013CC4 File Offset: 0x00011EC4
		private void pb2DId_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.Table2DListDown;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00013CF0 File Offset: 0x00011EF0
		private void pb2DId_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.Table2DList;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00013D1A File Offset: 0x00011F1A
		private void txtLotid_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r' && this.rdoLot.Checked)
			{
				this.btnLotSearch_Click(null, null);
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00013D3B File Offset: 0x00011F3B
		private void txtSearchSN_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r' && this.rdoSN.Checked)
			{
				this.btnLotSearch_Click(null, null);
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00013D5C File Offset: 0x00011F5C
		private void rdoDate_CheckedChanged(object sender, EventArgs e)
		{
			this._slData.Clear();
			this.gridLotList.RowsCount = 1;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00013D75 File Offset: 0x00011F75
		private void rdoLot_CheckedChanged(object sender, EventArgs e)
		{
			this._slData.Clear();
			this.gridLotList.RowsCount = 1;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00013D8E File Offset: 0x00011F8E
		private void rdoSN_CheckedChanged(object sender, EventArgs e)
		{
			this._slData.Clear();
			this.gridLotList.RowsCount = 1;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00013DA8 File Offset: 0x00011FA8
		private void getATETesterList(string sTestType, CheckedComboBox chkcmbTester)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetTesterList] @testtype = '" + sTestType + "'";
			DataSet dataSet = this.queryCall(sQuery);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				ComboBoxItem comboBoxItem = new ComboBoxItem();
				comboBoxItem.Name = dataSet.Tables[0].Rows[i]["ESI_testername"].ToString();
				comboBoxItem.Text = dataSet.Tables[0].Rows[i]["ESI_testername"].ToString();
				comboBoxItem.Code = dataSet.Tables[0].Rows[i]["ESI_testerid"].ToString();
				chkcmbTester.Items.Add(comboBoxItem);
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00013E8C File Offset: 0x0001208C
		private void getCheckStatusTesterList(string sTestType, object[] chktester)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetTesterList] @testtype = '" + sTestType + "'";
			DataSet dataSet = this.queryCall(sQuery);
			for (int i = 0; i < chktester.Length; i++)
			{
				object obj = chktester[i];
				for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
				{
					ComboBoxItem comboBoxItem = new ComboBoxItem();
					comboBoxItem.Name = dataSet.Tables[0].Rows[j]["ESI_testername"].ToString();
					comboBoxItem.Text = dataSet.Tables[0].Rows[j]["ESI_testername"].ToString();
					comboBoxItem.Code = dataSet.Tables[0].Rows[j]["ESI_testerid"].ToString();
					if (chktester[i].GetType().Name == "CheckedComboBox")
					{
						(chktester[i] as CheckedComboBox).Items.Add(comboBoxItem);
					}
					else
					{
						(chktester[i] as ComboBox).Items.Add(comboBoxItem);
					}
				}
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00013FC4 File Offset: 0x000121C4
		private void getBTOQCDate()
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			comboBoxItem.Text = "Day1~10";
			comboBoxItem.Code = "1";
			ComboBoxItem comboBoxItem2 = new ComboBoxItem();
			comboBoxItem2.Text = "Day11~20";
			comboBoxItem2.Code = "2";
			ComboBoxItem comboBoxItem3 = new ComboBoxItem();
			comboBoxItem3.Text = "Day21~30";
			comboBoxItem3.Code = "3";
			this.chkcmb_BTOQCDate.Items.Add(comboBoxItem);
			this.chkcmb_BTOQCDate.Items.Add(comboBoxItem2);
			this.chkcmb_BTOQCDate.Items.Add(comboBoxItem3);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0001405C File Offset: 0x0001225C
		private void cmd_BTOQC_Search_Click(object sender, EventArgs e)
		{
			DataSet dataSet = new DataSet();
			SortedList sortedList = new SortedList();
			this.cmd_BTOQC_Search.Select();
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string text = string.Empty;
				string text2 = this.InitBTOQCGrid(this.gridBTMonitoring, sortedList);
				if (this.rdo_BT_SelectedDate.Checked)
				{
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetATECheckSite] @startdate = '",
						this.BT_Date_Start.Value.ToShortDateString(),
						"', @enddate = '",
						this.BT_Date_End.Value.ToShortDateString(),
						"', @testerid = '",
						text2,
						"', @type = 'Day'"
					});
					dataSet = this.queryCall(sQuery);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						int num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ATE_testerid"].ToString());
						string key = dataSet.Tables[0].Rows[i]["seq"].ToString();
						string key2 = dataSet.Tables[0].Rows[i]["site"].ToString();
						if (sortedList.ContainsKey(num))
						{
							ATE_Tester ate_Tester = (ATE_Tester)sortedList[num];
							SortedList sortedList2 = (SortedList)ate_Tester.slSeq[key];
							if (!sortedList2.ContainsKey(key2))
							{
								sortedList2.Add(key2, true);
							}
						}
					}
					int num2 = 2;
					int num3 = 1;
					this.arrCellColor.Clear();
					for (int j = 0; j < sortedList.Count; j++)
					{
						ATE_Tester ate_Tester2 = (ATE_Tester)sortedList.GetByIndex(j);
						for (int k = 0; k < ate_Tester2.slSeq.Count; k++)
						{
							SortedList sortedList3 = (SortedList)ate_Tester2.slSeq.GetByIndex(k);
							for (int l = 0; l < sortedList3.Count; l++)
							{
								if ((bool)sortedList3.GetByIndex(l))
								{
									int num4 = num3 + Convert.ToInt32(sortedList3.GetKey(l));
									this.gridBTMonitoring[num2, num4].View = this.gridInfo.CellColor.cell_lightgreen;
									int[] value = new int[]
									{
										num2 + 1,
										num4 + 1
									};
									this.arrCellColor.Add(value);
								}
							}
							num2++;
						}
					}
					this.gridBTMonitoring.Refresh();
				}
				else if (this.rdo_BT_Month.Checked)
				{
					if (this.chkcmb_BTOQCDate.CheckedItems.Count > 0)
					{
						for (int m = 0; m < this.chkcmb_BTOQCDate.CheckedItems.Count; m++)
						{
							ComboBoxItem comboBoxItem = (ComboBoxItem)this.chkcmb_BTOQCDate.CheckedItems[m];
							text = text + comboBoxItem.Code + ",";
						}
						if (text != string.Empty)
						{
							text = text.Substring(0, text.Length - 1);
						}
					}
					string sQuery2 = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetATECheckSite] @date = '",
						this.dateTime_Month.Value.ToShortDateString(),
						"', @testerid = '",
						text2,
						"', @seq = '",
						text,
						"'"
					});
					dataSet = this.queryCall(sQuery2);
					for (int n = 0; n < dataSet.Tables[0].Rows.Count; n++)
					{
						int num5 = Convert.ToInt32(dataSet.Tables[0].Rows[n]["ATE_testerid"].ToString());
						int num6 = Convert.ToInt32(dataSet.Tables[0].Rows[n]["seq"].ToString());
						string key3 = dataSet.Tables[0].Rows[n]["site"].ToString();
						if (sortedList.ContainsKey(num5))
						{
							ATE_Tester ate_Tester3 = (ATE_Tester)sortedList[num5];
							SortedList sortedList4 = (SortedList)ate_Tester3.slSeq[num6];
							if (!sortedList4.ContainsKey(key3))
							{
								sortedList4.Add(key3, true);
							}
						}
					}
					int num7 = 2;
					int num8 = 1;
					this.arrCellColor.Clear();
					for (int num9 = 0; num9 < sortedList.Count; num9++)
					{
						ATE_Tester ate_Tester4 = (ATE_Tester)sortedList.GetByIndex(num9);
						for (int num10 = 0; num10 < ate_Tester4.slSeq.Count; num10++)
						{
							SortedList sortedList5 = (SortedList)ate_Tester4.slSeq.GetByIndex(num10);
							for (int num11 = 0; num11 < sortedList5.Count; num11++)
							{
								if ((bool)sortedList5.GetByIndex(num11))
								{
									int num12 = num8 + Convert.ToInt32(sortedList5.GetKey(num11));
									this.gridBTMonitoring[num7, num12].View = this.gridInfo.CellColor.cell_lightgreen;
									int[] value2 = new int[]
									{
										num7 + 1,
										num12 + 1
									};
									this.arrCellColor.Add(value2);
								}
							}
							num7++;
						}
					}
					this.gridBTMonitoring.Refresh();
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			finally
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000146F4 File Offset: 0x000128F4
		private string InitBTOQCGrid(SourceGrid.Grid grid, SortedList slData)
		{
			grid.RowsCount = 0;
			grid.ColumnsCount = 0;
			grid.FixedColumns = 2;
			grid.FixedRows = 2;
			grid.Columns.InsertRange(0, 35);
			grid.Rows.InsertRange(0, 2);
			int num = 0;
			grid[0, num] = new Cell("Tester");
			grid[0, num++].RowSpan = 2;
			grid[0, num] = new Cell("Date");
			grid[0, num++].RowSpan = 2;
			grid[0, num] = new Cell("SITE#");
			grid[0, num].ColumnSpan = 32;
			grid[0, num].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			for (int i = 1; i <= 32; i++)
			{
				grid.Columns[num].Width = 30;
				grid[1, num++] = new Cell(i);
			}
			grid[0, num] = new Cell("Remark");
			grid[0, num].RowSpan = 2;
			string text = string.Empty;
			if (this.chkcmbATETester.CheckedItems.Count > 0)
			{
				for (int j = 0; j < this.chkcmbATETester.CheckedItems.Count; j++)
				{
					ComboBoxItem comboBoxItem = (ComboBoxItem)this.chkcmbATETester.CheckedItems[j];
					text = text + comboBoxItem.Code + ",";
				}
			}
			if (text != string.Empty)
			{
				text = text.Substring(0, text.Length - 1);
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetTesterList] @testtype = 'ATE', @testerid = '" + text + "'";
			DataSet dataSet = this.queryCall(sQuery);
			for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
			{
				int num2 = Convert.ToInt32(dataSet.Tables[0].Rows[k]["ESI_testerid"].ToString());
				string text2 = dataSet.Tables[0].Rows[k]["ESI_testername"].ToString();
				ATE_Tester ate_Tester = new ATE_Tester();
				ate_Tester.ATE_TesterId = num2;
				ate_Tester.ATE_TesterName = text2;
				int num3 = grid.RowsCount;
				if (this.rdo_BT_SelectedDate.Checked)
				{
					DateTime date = this.BT_Date_Start.Value.Date;
					DateTime date2 = this.BT_Date_End.Value.Date;
					DateTime t = date;
					while (t <= date2)
					{
						grid.Rows.InsertRange(num3, 1);
						grid[num3, 0] = new Cell(text2);
						grid[num3, 1] = new Cell(t.ToShortDateString());
						for (int l = 2; l <= 34; l++)
						{
							grid[num3, l] = new Cell(string.Empty);
						}
						num3++;
						ate_Tester.slSeq.Add(t.ToShortDateString(), new SortedList());
						t = t.AddDays(1.0);
					}
				}
				else if (this.rdo_BT_Month.Checked)
				{
					if (this.chkcmb_BTOQCDate.CheckedItems.Count == 0)
					{
						grid.Rows.InsertRange(num3, 3);
						grid[num3, 0] = new Cell(text2);
						grid[num3, 0].RowSpan = 3;
						for (int m = 0; m < this.chkcmb_BTOQCDate.Items.Count; m++)
						{
							ComboBoxItem comboBoxItem2 = (ComboBoxItem)this.chkcmb_BTOQCDate.Items[m];
							grid[num3, 1] = new Cell(comboBoxItem2.Text);
							for (int n = 2; n <= 34; n++)
							{
								grid[num3, n] = new Cell(string.Empty);
							}
							num3++;
							ate_Tester.slSeq.Add(int.Parse(comboBoxItem2.Code), new SortedList());
						}
					}
					else
					{
						int count = this.chkcmb_BTOQCDate.CheckedItems.Count;
						grid.Rows.InsertRange(num3, count);
						grid[num3, 0] = new Cell(text2);
						grid[num3, 0].RowSpan = count;
						for (int num4 = 0; num4 < this.chkcmb_BTOQCDate.CheckedItems.Count; num4++)
						{
							ComboBoxItem comboBoxItem3 = (ComboBoxItem)this.chkcmb_BTOQCDate.CheckedItems[num4];
							grid[num3, 1] = new Cell(comboBoxItem3.Text);
							for (int num5 = 2; num5 <= 34; num5++)
							{
								grid[num3, num5] = new Cell(string.Empty);
							}
							num3++;
							ate_Tester.slSeq.Add(int.Parse(comboBoxItem3.Code), new SortedList());
						}
					}
				}
				slData.Add(num2, ate_Tester);
			}
			grid.Columns[0].Width = 70;
			grid.Columns[1].Width = 80;
			return text;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00014C28 File Offset: 0x00012E28
		private void cmd_BTOQC_Excel_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.gridBTMonitoring.RowsCount >= 3)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						ExcelControl.Save(this.saveFileDialog.FileName, this.gridBTMonitoring, true, this.arrCellColor);
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00014D58 File Offset: 0x00012F58
		private void cmd_RawData_Excel_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.gridBTMonitoring.RowsCount >= 3)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						ExcelControl.Save(this.saveFileDialog.FileName, this.gridBTMonitoring, true, this.arrCellColor);
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00014E88 File Offset: 0x00013088
		private void rdo_BT_SelectedDate_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdo_BT_SelectedDate.Checked)
			{
				this.BT_Date_Start.Enabled = true;
				this.BT_Date_End.Enabled = true;
				return;
			}
			this.BT_Date_Start.Enabled = false;
			this.BT_Date_End.Enabled = false;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00014EC8 File Offset: 0x000130C8
		private void rdo_BT_Month_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdo_BT_Month.Checked)
			{
				this.dateTime_Month.Enabled = true;
				this.chkcmb_BTOQCDate.Enabled = true;
				return;
			}
			this.dateTime_Month.Enabled = false;
			this.chkcmb_BTOQCDate.Enabled = false;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00014F08 File Offset: 0x00013108
		private void rdoLoadSN_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdoLoadSN.Checked)
			{
				this.initLotListGrid("SN");
				return;
			}
			this.initLotListGrid("LOT");
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00014F30 File Offset: 0x00013130
		private void initUploadLotGrid()
		{
			this.gridUploadLot.ColumnsCount = 5;
			this.gridUploadLot.RowsCount = 1;
			this.gridUploadLot.FixedRows = 1;
			this.gridUploadLot[0, 0] = new GridInfo.ColHeader("");
			this.gridUploadLot[0, 1] = new GridInfo.ColHeader("No");
			this.gridUploadLot[0, 2] = new GridInfo.ColHeader("Lot");
			this.gridUploadLot[0, 3] = new GridInfo.ColHeader("DCC");
			this.gridUploadLot[0, 4] = new GridInfo.ColHeader("LotID");
			this.gridUploadLot.Columns[0].Width = 30;
			this.gridUploadLot.Columns[1].Width = 50;
			this.gridUploadLot.Columns[2].Width = 100;
			this.gridUploadLot.Columns[4].Visible = false;
			this.gridInfo.CreateColHeaderCheckBox(this.gridUploadLot);
			this.gridInfo.SetColumnCellColor(this.gridUploadLot, 0, this.gridInfo.CellColor.cell_gray_center);
			CustomEvents customEvents = new CustomEvents();
			customEvents.Click += this.gridUploadLot_CellClickEvent;
			this.gridUploadLot.Controller.AddController(customEvents);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00015090 File Offset: 0x00013290
		private void initUploadSNGrid()
		{
			this.gridUploadSNList.ColumnsCount = 3;
			this.gridUploadSNList.RowsCount = 1;
			this.gridUploadSNList.FixedRows = 1;
			this.gridUploadSNList[0, 0] = new GridInfo.ColHeader("No");
			this.gridUploadSNList[0, 1] = new GridInfo.ColHeader("SN");
			this.gridUploadSNList[0, 2] = new GridInfo.ColHeader("Updatetime");
			this.gridUploadSNList.Columns[0].Width = 50;
			this.gridUploadSNList.Columns[1].Width = 150;
			this.gridUploadSNList.Columns[2].Width = 150;
			this.gridInfo.SetColumnCellColor(this.gridUploadSNList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.grid_SNList.ColumnsCount = 2;
			this.grid_SNList.RowsCount = 1;
			this.grid_SNList.FixedRows = 1;
			this.grid_SNList[0, 0] = new GridInfo.ColHeader("No");
			this.grid_SNList[0, 1] = new GridInfo.ColHeader("SN");
			this.grid_SNList.Columns[0].Width = 50;
			this.grid_SNList.Columns[1].Width = 150;
			this.gridInfo.SetColumnCellColor(this.grid_SNList, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0001521D File Offset: 0x0001341D
		private void cmd_Download_Data_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00015220 File Offset: 0x00013420
		private void cmd_Upload_Data_Click(object sender, EventArgs e)
		{
			this.openFileDialog.DefaultExt = ".csv";
			this.openFileDialog.Filter = "CSV files|*.csv";
			this.openFileDialog.FilterIndex = 1;
			this.openFileDialog.FileName = string.Empty;
			try
			{
				DialogResult dialogResult = this.openFileDialog.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Uploading Format....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					this.slUploadData = new SortedList();
					this.grid_SNList.RowsCount = 1;
					if (this.setCSVData())
					{
						this.setBindingData();
					}
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00015350 File Offset: 0x00013550
		private bool setCSVData()
		{
			SortedList sortedList = new SortedList();
			string text = string.Empty;
			try
			{
				using (StreamReader streamReader = new StreamReader(this.openFileDialog.FileName, Encoding.Default))
				{
					text = streamReader.ReadToEnd();
					streamReader.Close();
				}
				if (text == string.Empty)
				{
					MessageBox.Show("Uploading data does not exist.", "Error");
					return false;
				}
				string[] array = text.Split(new char[]
				{
					'\n'
				});
				string[] array2 = array[0].Split(new string[]
				{
					","
				}, StringSplitOptions.RemoveEmptyEntries);
				if (array2.Length > 1)
				{
					MessageBox.Show("Data format is wrong.", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
				for (int i = 0; i < array.Length; i++)
				{
					string[] array3 = array[i].Split(new char[]
					{
						','
					});
					if (array3.Length == 1 && array3[0] != string.Empty)
					{
						UnitData unitData = new UnitData();
						unitData.SN = array3[0].ToUpper().Trim();
						if (sortedList.ContainsKey(unitData.SN))
						{
							Thread.Sleep(100);
							if (this._barPrograss != null)
							{
								this._barPrograss._ischeck = true;
							}
							this._barPrograss = null;
							MessageBox.Show("duplicate SN : " + unitData.SN + "\ncheck please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return false;
						}
						sortedList.Add(unitData.SN, i);
						this.slUploadData.Add(i, unitData);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return true;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00015550 File Offset: 0x00013750
		private void setBindingData()
		{
			if (this.slUploadData.Count > 0)
			{
				for (int i = 0; i < this.slUploadData.Count; i++)
				{
					UnitData unitData = (UnitData)this.slUploadData.GetByIndex(i);
					this.grid_SNList.Rows.Insert(this.grid_SNList.RowsCount);
					this.grid_SNList[i + 1, 0] = new Cell((i + 1).ToString());
					this.grid_SNList[i + 1, 1] = new Cell(unitData.SN);
				}
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000155E8 File Offset: 0x000137E8
		private void updateUploadData()
		{
			try
			{
				string text = string.Empty;
				string sQuery = string.Empty;
				DataSet dataSet = new DataSet();
				this._barPrograss.setValue(0);
				this._barPrograss.progress_labelheader_set("Check Uploading Lot....");
				sQuery = string.Concat(new object[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_ESI_CheckUploadLot]  @lotno = '",
					this.txtUploadLot.Text,
					"', @dcc = '",
					this.txtDcc.Text,
					"', @operation = '",
					this.txtOperation.Text,
					"', @qty = '",
					this.slUploadData.Count,
					"', @type = 'DATA400'"
				});
				dataSet = this.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["returncode"].ToString() == "-1")
				{
					string str = dataSet.Tables[0].Rows[0]["returnvalue"].ToString();
					DialogResult dialogResult = MessageBox.Show(str + "\nDo you want to proceed?", "ESI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.No)
					{
						MessageBox.Show("Cancel upload data", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				sQuery = string.Concat(new object[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_ESI_CheckUploadLot]  @lotno = '",
					this.txtUploadLot.Text,
					"', @dcc = '",
					this.txtDcc.Text,
					"', @operation = '",
					this.txtOperation.Text,
					"', @qty = '",
					this.slUploadData.Count,
					"'"
				});
				dataSet = this.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["returncode"].ToString() == "-1")
				{
					string str2 = dataSet.Tables[0].Rows[0]["returnvalue"].ToString();
					DialogResult dialogResult2 = MessageBox.Show(str2 + "\nDo you want to upload new data?\n(Existing data will be deleted.)", "ESI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dialogResult2 == DialogResult.No)
					{
						MessageBox.Show("Cancel upload data", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				this._barPrograss.progress_labelheader_set("Check Uploading SN....");
				this._barPrograss.setMax(this.slUploadData.Count);
				SortedList sortedList = new SortedList();
				for (int i = 0; i < this.slUploadData.Count; i++)
				{
					UnitData unitData = (UnitData)this.slUploadData.GetByIndex(i);
					sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_CheckUploadUnit]  @sn = '" + unitData.SN + "'";
					dataSet = this.queryCall(sQuery);
					if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["returncode"].ToString() == "-1")
					{
						unitData.Failure_message = dataSet.Tables[0].Rows[0]["returnvalue"].ToString();
						sortedList.Add(i, unitData);
					}
					this._barPrograss.setValue(i + 1);
				}
				if (sortedList.Count > 0)
				{
					DialogResult dialogResult3 = new ResultView
					{
						slData = sortedList
					}.ShowDialog();
					if (dialogResult3 == DialogResult.No || dialogResult3 == DialogResult.Cancel)
					{
						MessageBox.Show("Cancel upload data", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				this._barPrograss.progress_label_set("Uploading Data....");
				this._barPrograss.setMax(this.slUploadData.Count);
				sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_ESI_SetUploadLot]  @lotno = '",
					this.txtUploadLot.Text,
					"', @dcc = '",
					this.txtDcc.Text,
					"', @operation = '",
					this.txtOperation.Text,
					"'"
				});
				dataSet = this.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					if (dataSet.Tables[0].Rows[0]["returncode"].ToString() == "1")
					{
						text = dataSet.Tables[0].Rows[0]["lotid"].ToString();
						for (int j = 0; j < this.slUploadData.Count; j++)
						{
							UnitData unitData2 = (UnitData)this.slUploadData.GetByIndex(j);
							sQuery = string.Concat(new string[]
							{
								"EXEC [CIMitar_Factory].[dbo].[USP_ESI_SetUploadUnitData]  @lotid = '",
								text,
								"', @sn = '",
								unitData2.SN,
								"'"
							});
							dataSet = this.queryCall(sQuery);
							this._barPrograss.setValue(j + 1);
						}
						MessageBox.Show("Success upload data", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Fail upload data", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00015C0C File Offset: 0x00013E0C
		private void cmd_Apply_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.slUploadData.Count > 0)
				{
					if (this.txtUploadLot.Text == string.Empty)
					{
						MessageBox.Show("Input LotID please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else if (this.txtDcc.Text == string.Empty)
					{
						MessageBox.Show("Input DCC please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else if (this.txtOperation.Text == string.Empty)
					{
						MessageBox.Show("Input Operation please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Check Uploading SN....");
						this._barPrograss.setValue(0);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						this.updateUploadData();
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
			}
			catch (Exception)
			{
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00015D6C File Offset: 0x00013F6C
		private void cmdUploadSearch_Click(object sender, EventArgs e)
		{
			this.gridUploadLot.RowsCount = 1;
			this.gridUploadSNList.RowsCount = 1;
			if (this.rdo_SearchUploadLot.Checked)
			{
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUploadLot] @lotno  = '" + this.txtSearchUploadLot.Text + "'";
				DataSet dataSet = this.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.gridUploadLot.Rows.Insert(this.gridUploadLot.RowsCount);
						this.gridUploadLot[i + 1, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
						this.gridUploadLot[i + 1, 1] = new Cell((i + 1).ToString());
						this.gridUploadLot[i + 1, 2] = new Cell(dataSet.Tables[0].Rows[i]["lotno"].ToString());
						this.gridUploadLot[i + 1, 3] = new Cell(dataSet.Tables[0].Rows[i]["dcc"].ToString());
						this.gridUploadLot[i + 1, 4] = new Cell(dataSet.Tables[0].Rows[i]["lotid"].ToString());
					}
					return;
				}
			}
			else
			{
				if (this.txtSearchUploadSN.Text == string.Empty)
				{
					MessageBox.Show("Input SN please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				string sQuery2 = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUploadSN] @sn  = '" + this.txtSearchUploadSN.Text + "'";
				DataSet dataSet2 = this.queryCall(sQuery2);
				if (dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0)
				{
					this.gridUploadLot.Rows.Insert(this.gridUploadLot.RowsCount);
					this.gridUploadLot[1, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
					this.gridUploadLot[1, 1] = new Cell("1");
					this.gridUploadLot[1, 2] = new Cell(dataSet2.Tables[0].Rows[0]["lotno"].ToString());
					this.gridUploadLot[1, 3] = new Cell(dataSet2.Tables[0].Rows[0]["dcc"].ToString());
					this.gridUploadSNList.Rows.Insert(this.gridUploadSNList.RowsCount);
					this.gridUploadSNList[1, 0] = new Cell("1");
					this.gridUploadSNList[1, 1] = new Cell(dataSet2.Tables[0].Rows[0]["sn"].ToString());
					this.gridUploadSNList[1, 2] = new Cell(dataSet2.Tables[0].Rows[0]["updatedate"].ToString());
				}
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000160FC File Offset: 0x000142FC
		private void gridUploadLot_CellClickEvent(object sender, EventArgs e)
		{
			if (this.rdo_SearchUploadSN.Checked)
			{
				return;
			}
			this.gridUploadSNList.RowsCount = 1;
			CellContext cellContext = (CellContext)sender;
			try
			{
				string str = string.Empty;
				int row = cellContext.Position.Row;
				int column = cellContext.Position.Column;
				SourceGrid.Grid grid = (SourceGrid.Grid)cellContext.Grid;
				Cell cell = (Cell)cellContext.Cell;
				if (row != 0)
				{
					str = this.gridUploadLot[row, 4].ToString();
					string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetUploadSN]  @lotid  = '" + str + "'";
					DataSet dataSet = this.queryCall(sQuery);
					if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							this.gridUploadSNList.Rows.Insert(this.gridUploadSNList.RowsCount);
							this.gridUploadSNList[i + 1, 0] = new Cell((i + 1).ToString());
							this.gridUploadSNList[i + 1, 1] = new Cell(dataSet.Tables[0].Rows[i]["sn"].ToString());
							this.gridUploadSNList[i + 1, 2] = new Cell(dataSet.Tables[0].Rows[i]["updatedate"].ToString());
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000162DC File Offset: 0x000144DC
		private void cmd_UploadDelete_Click(object sender, EventArgs e)
		{
			if (this.gridUploadLot.RowsCount > 1)
			{
				SortedList sortedList = new SortedList();
				for (int i = 1; i < this.gridUploadLot.RowsCount; i++)
				{
					if ((bool)this.gridUploadLot[i, 0].Value)
					{
						sortedList.Add(i, this.gridUploadLot[i, 4].ToString());
					}
				}
				if (sortedList.Count > 0)
				{
					DialogResult dialogResult = MessageBox.Show("Do you want to delete checked data?", "ESI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Yes)
					{
						new DataSet();
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Check Uploading SN....");
						this._barPrograss.setValue(0);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						for (int j = 0; j < sortedList.Count; j++)
						{
							string str = sortedList.GetByIndex(j).ToString();
							string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_SetDeleteUploadLot]  @lotid = '" + str + "'";
							this.queryCall(sQuery);
							this._barPrograss.setValue(j + 1);
						}
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
						MessageBox.Show("Completed", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.cmdUploadSearch_Click(null, null);
					}
				}
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00016448 File Offset: 0x00014648
		private void InitParaSummaryGrid(SourceGrid.Grid grid)
		{
			grid.RowsCount = 1;
			grid.ColumnsCount = 19;
			grid.FixedRows = 1;
			int p = 0;
			grid.Columns[p].Width = 50;
			grid[0, p++] = new GridInfo.ColHeader("No");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("Date");
			grid.Columns[p].Width = 90;
			grid[0, p++] = new GridInfo.ColHeader("Device");
			grid.Columns[p].Width = 90;
			grid[0, p++] = new GridInfo.ColHeader("Tester");
			grid.Columns[p].Width = 280;
			grid[0, p++] = new GridInfo.ColHeader("Item");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Unit#1");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Unit#2");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Unit#3");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Unit#4");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Unit#5");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("LCL");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("UCL");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("AVERAGE");
			grid.Columns[p].Width = 60;
			grid[0, p++] = new GridInfo.ColHeader("X_Result");
			grid.Columns[p].Width = 60;
			grid[0, p++] = new GridInfo.ColHeader("R_LCL");
			grid.Columns[p].Width = 60;
			grid[0, p++] = new GridInfo.ColHeader("R_UCL");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("R(MAX-MIN)");
			grid.Columns[p].Width = 60;
			grid[0, p++] = new GridInfo.ColHeader("R_Result");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("FinalResult");
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00016798 File Offset: 0x00014998
		private void cmd_ParaSummary_Search_Click(object sender, EventArgs e)
		{
			DataSet dataSet = new DataSet();
			new SortedList();
			new SortedList();
			this.cmd_ParaSummary_Search.Select();
			this.gridCheckSummary.RowsCount = 1;
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string empty = string.Empty;
				string text = string.Empty;
				string text2 = string.Empty;
				if (this.chkcmb_Summary_Tester.CheckedItems.Count > 0)
				{
					for (int i = 0; i < this.chkcmb_Summary_Tester.CheckedItems.Count; i++)
					{
						ComboBoxItem comboBoxItem = (ComboBoxItem)this.chkcmb_Summary_Tester.CheckedItems[i];
						text = text + comboBoxItem.Code + ",";
					}
				}
				this.InitParaSummaryGrid(this.gridCheckSummary);
				if (this.rdo_Setup_SelectDate.Checked)
				{
					if (this.cmb_Summary_Result.Text != string.Empty && this.cmb_Summary_Result.Text != "ALL")
					{
						text2 = this.cmb_Summary_Result.Text;
					}
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetParameterSummaryData] @startdate = '",
						this.Setup_Date_Start.Value.ToShortDateString(),
						"', @enddate = '",
						this.Setup_Date_End.Value.ToShortDateString(),
						"', @device = '",
						this.cmb_Summary_Device.Text,
						"', @testerid = '",
						text,
						"', @result = '",
						text2,
						"'"
					});
					dataSet = this.queryCall(sQuery);
					for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
					{
						int num = 0;
						string cellValue = Convert.ToDateTime(dataSet.Tables[0].Rows[j]["summarydate"].ToString()).ToShortDateString();
						string cellValue2 = dataSet.Tables[0].Rows[j]["device"].ToString();
						string cellValue3 = dataSet.Tables[0].Rows[j]["tester"].ToString();
						string cellValue4 = dataSet.Tables[0].Rows[j]["parameter"].ToString();
						string cellValue5 = dataSet.Tables[0].Rows[j]["unit1"].ToString();
						string cellValue6 = dataSet.Tables[0].Rows[j]["unit2"].ToString();
						string cellValue7 = dataSet.Tables[0].Rows[j]["unit3"].ToString();
						string cellValue8 = dataSet.Tables[0].Rows[j]["unit4"].ToString();
						string cellValue9 = dataSet.Tables[0].Rows[j]["unit5"].ToString();
						string cellValue10 = dataSet.Tables[0].Rows[j]["lsl"].ToString();
						string cellValue11 = dataSet.Tables[0].Rows[j]["usl"].ToString();
						string cellValue12 = dataSet.Tables[0].Rows[j]["avg"].ToString();
						string cellValue13 = dataSet.Tables[0].Rows[j]["r_lsl"].ToString();
						string cellValue14 = dataSet.Tables[0].Rows[j]["r_usl"].ToString();
						string cellValue15 = dataSet.Tables[0].Rows[j]["range"].ToString();
						string text3 = dataSet.Tables[0].Rows[j]["result"].ToString();
						string text4 = dataSet.Tables[0].Rows[j]["r_result"].ToString();
						string text5 = "PASS";
						if (text3 == "FAIL" || text4 == "FAIL")
						{
							text5 = "FAIL";
						}
						this.gridCheckSummary.Rows.Insert(this.gridCheckSummary.RowsCount);
						this.gridCheckSummary[j + 1, num++] = new Cell((j + 1).ToString());
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue2);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue3);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue4);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue5);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue6);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue7);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue8);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue9);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue10);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue11);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue12);
						this.gridCheckSummary[j + 1, num++] = new Cell(text3);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue13);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue14);
						this.gridCheckSummary[j + 1, num++] = new Cell(cellValue15);
						this.gridCheckSummary[j + 1, num++] = new Cell(text4);
						this.gridCheckSummary[j + 1, num++] = new Cell(text5);
						if (text5 != "PASS")
						{
							for (int k = 0; k < this.gridCheckSummary.ColumnsCount; k++)
							{
								this.gridCheckSummary[j + 1, k].View = this.gridInfo.CellColor.cell_red;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			finally
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00016FB8 File Offset: 0x000151B8
		private void cmd_ParaSummary_Excel_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.gridCheckSummary.RowsCount >= 2)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						ExcelControl.Save(this.saveFileDialog.FileName, this.gridCheckSummary, true, this.arrCellColor);
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000170E8 File Offset: 0x000152E8
		private string InitCheckStatusGrid(SourceGrid.Grid grid, SortedList slData)
		{
			grid.RowsCount = 1;
			grid.ColumnsCount = 32;
			grid.FixedColumns = 1;
			grid.FixedRows = 1;
			int num = 0;
			grid[0, num] = new Cell("Tester");
			for (int i = 1; i <= 31; i++)
			{
				grid.Columns[num].Width = 30;
				grid[1, num++] = new Cell(i);
			}
			string text = string.Empty;
			if (this.chkcmbATETester.CheckedItems.Count > 0)
			{
				for (int j = 0; j < this.chkcmbATETester.CheckedItems.Count; j++)
				{
					ComboBoxItem comboBoxItem = (ComboBoxItem)this.chkcmbATETester.CheckedItems[j];
					text = text + comboBoxItem.Code + ",";
				}
			}
			if (text != string.Empty)
			{
				text = text.Substring(0, text.Length - 1);
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetTesterList] @testtype = 'ATE', @testerid = '" + text + "'";
			DataSet dataSet = this.queryCall(sQuery);
			for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
			{
				int num2 = Convert.ToInt32(dataSet.Tables[0].Rows[k]["ESI_testerid"].ToString());
				string ate_TesterName = dataSet.Tables[0].Rows[k]["ESI_testername"].ToString();
				ATE_Tester ate_Tester = new ATE_Tester();
				ate_Tester.ATE_TesterId = num2;
				ate_Tester.ATE_TesterName = ate_TesterName;
				slData.Add(num2, ate_Tester);
			}
			grid.Columns[0].Width = 70;
			grid.Columns[1].Width = 80;
			return text;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000172CC File Offset: 0x000154CC
		private void cmd_CheckStatus_Search_Click(object sender, EventArgs e)
		{
			DataSet dataSet = new DataSet();
			SortedList sortedList = new SortedList();
			this.cmd_CheckStatus_Search.Select();
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string empty = string.Empty;
				string text = string.Empty;
				if (this.chkcmb_Status_Tester.CheckedItems.Count > 0)
				{
					for (int i = 0; i < this.chkcmb_Status_Tester.CheckedItems.Count; i++)
					{
						ComboBoxItem comboBoxItem = (ComboBoxItem)this.chkcmb_Status_Tester.CheckedItems[i];
						text = text + comboBoxItem.Code + ",";
						ATE_Tester ate_Tester = new ATE_Tester();
						ate_Tester.ATE_TesterId = int.Parse(comboBoxItem.Code);
						ate_Tester.ATE_TesterName = comboBoxItem.Name;
						sortedList.Add(ate_Tester.ATE_TesterId, ate_Tester);
					}
					if (text != string.Empty)
					{
						text = text.Substring(0, text.Length - 1);
					}
				}
				else
				{
					for (int j = 0; j < this.chkcmb_Status_Tester.Items.Count; j++)
					{
						ComboBoxItem comboBoxItem2 = (ComboBoxItem)this.chkcmb_Status_Tester.Items[j];
						ATE_Tester ate_Tester2 = new ATE_Tester();
						ate_Tester2.ATE_TesterId = int.Parse(comboBoxItem2.Code);
						ate_Tester2.ATE_TesterName = comboBoxItem2.Name;
						sortedList.Add(ate_Tester2.ATE_TesterId, ate_Tester2);
					}
				}
				DateTime date = this.Status_Date_Start.Value.Date;
				DateTime date2 = this.Status_Date_End.Value.Date;
				if (this.rdo_Status_Month.Checked)
				{
					date = new DateTime(this.Status_Month.Value.Year, this.Status_Month.Value.Month, 1);
					date2 = new DateTime(this.Status_Month.Value.Year, this.Status_Month.Value.Month, DateTime.DaysInMonth(this.Status_Month.Value.Year, this.Status_Month.Value.Month));
				}
				int num = 1;
				this.gridCheckStatus.RowsCount = 1;
				this.gridCheckStatus.ColumnsCount = 1;
				this.gridCheckStatus[0, 0] = new Cell("Tester/Date");
				this.gridCheckStatus.Columns[0].Width = 100;
				DateTime t = date;
				while (t <= date2)
				{
					this.gridCheckStatus.Columns.InsertRange(num, 1);
					this.gridCheckStatus[0, num] = new Cell(t.Day);
					this.gridCheckStatus.Columns[num].Width = 25;
					num++;
					for (int k = 0; k < sortedList.Count; k++)
					{
						ATE_Tester ate_Tester3 = (ATE_Tester)sortedList.GetByIndex(k);
						ate_Tester3.slSeq.Add(t.ToShortDateString(), string.Empty);
					}
					t = t.AddDays(1.0);
				}
				this.gridInfo.SetColumnCellColor(this.gridCheckStatus, 0, this.gridInfo.CellColor.cell_gray_center);
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetParameterCheckStatus] @startdate = '",
					date.ToShortDateString(),
					"', @enddate = '",
					date2.ToShortDateString(),
					"', @testerid = '",
					text,
					"', @device = '",
					this.cmb_Status_Tester.Text,
					"', @type = 'Day'"
				});
				dataSet = this.queryCall(sQuery);
				for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
				{
					int num2 = int.Parse(dataSet.Tables[0].Rows[l]["testerid"].ToString());
					dataSet.Tables[0].Rows[l]["tester"].ToString();
					string key = dataSet.Tables[0].Rows[l]["date"].ToString();
					string value = dataSet.Tables[0].Rows[l]["result"].ToString();
					if (sortedList.ContainsKey(num2))
					{
						ATE_Tester ate_Tester4 = (ATE_Tester)sortedList[num2];
						if (ate_Tester4.slSeq.ContainsKey(key))
						{
							ate_Tester4.slSeq[key] = value;
						}
					}
				}
				if (sortedList.Count > 0)
				{
					for (int m = 0; m < sortedList.Count; m++)
					{
						this.gridCheckStatus.Rows.Insert(this.gridCheckStatus.RowsCount);
						ATE_Tester ate_Tester5 = (ATE_Tester)sortedList.GetByIndex(m);
						int num3 = 0;
						this.gridCheckStatus[m + 1, num3++] = new Cell(ate_Tester5.ATE_TesterName);
						for (int n = 0; n < ate_Tester5.slSeq.Count; n++)
						{
							this.gridCheckStatus[m + 1, num3] = new Cell(string.Empty);
							if (ate_Tester5.slSeq.GetByIndex(n).ToString() == "PASS")
							{
								this.gridCheckStatus[m + 1, num3].View = this.gridInfo.CellColor.cell_lightgreen;
							}
							else if (ate_Tester5.slSeq.GetByIndex(n).ToString() == "FAIL")
							{
								this.gridCheckStatus[m + 1, num3].View = this.gridInfo.CellColor.cell_red;
							}
							num3++;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			finally
			{
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					this._barPrograss._ischeck = true;
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000179B0 File Offset: 0x00015BB0
		private void cmd_CheckStatus_Excel_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.gridCheckStatus.RowsCount >= 2)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						ExcelControl.Save(this.saveFileDialog.FileName, this.gridCheckStatus, true, true);
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00017ADC File Offset: 0x00015CDC
		private void cmd_Trend_Search_Click(object sender, EventArgs e)
		{
			this.cmd_Trend_Search.Select();
			DateTime date = this.Trend_Date_Start.Value.Date;
			DateTime date2 = this.Trend_Date_End.Value.Date;
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (this.rdo_Trend_Month.Checked)
			{
				date = new DateTime(this.Trend_Month.Value.Year, this.Trend_Month.Value.Month, 1);
				date2 = new DateTime(this.Trend_Month.Value.Year, this.Trend_Month.Value.Month, DateTime.DaysInMonth(this.Trend_Month.Value.Year, this.Trend_Month.Value.Month));
			}
			if (this.cmb_Trend_Tester.Text == string.Empty)
			{
				MessageBox.Show("select Tester please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.cmb_Trend_TestItem.Text == string.Empty)
			{
				MessageBox.Show("select TestItem please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			ComboBoxItem comboBoxItem = (ComboBoxItem)this.cmb_Trend_Tester.SelectedItem;
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetParameterSummaryData] @startdate = '",
				date.ToShortDateString(),
				"', @enddate = '",
				date2.ToShortDateString(),
				"', @device = '",
				this.cmb_Trend_Device.Text,
				"', @testerid = '",
				comboBoxItem.Code.ToString(),
				"', @parameter = '",
				this.cmb_Trend_TestItem.Text,
				"'"
			});
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count != 0)
			{
				this.setXBarChart(dataSet);
				this.setRChart(dataSet);
				return;
			}
			MessageBox.Show("data is not exist. check please", "ESI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00017CF8 File Offset: 0x00015EF8
		private void setXBarChart(DataSet dsData)
		{
			this.initChartView(this.chart_XBarChart);
			int num = 0;
			double num2 = 1.5;
			string text = string.Empty;
			string empty = string.Empty;
			string text2 = this.cmb_Trend_Tester.Text;
			this.chart_XBarChart.Titles["Title1"].Text = this.cmb_Trend_TestItem.Text;
			Series series;
			for (int i = 0; i < 5; i++)
			{
				series = new Series();
				series.ChartArea = "ChartArea1";
				series.Font = new Font("Segoe UI", 8f);
				series.LabelForeColor = Color.Empty;
				series.XValueType = ChartValueType.String;
				series.YValueType = ChartValueType.Double;
				series.Legend = "Legend1";
				series.LegendText = "Unit" + (i + 1).ToString();
				series.Name = "Unit" + (i + 1).ToString();
				series.ChartType = SeriesChartType.Line;
				this.chart_XBarChart.Series.Add(series);
			}
			series = new Series();
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Double;
			series.Legend = "Legend1";
			series.LegendText = "UCL";
			series.Name = "UCL";
			series.ChartType = SeriesChartType.Line;
			series.Color = Color.Blue;
			series.BorderWidth = 3;
			this.chart_XBarChart.Series.Add(series);
			series = new Series();
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Double;
			series.Legend = "Legend1";
			series.LegendText = "LCL";
			series.Name = "LCL";
			series.ChartType = SeriesChartType.Line;
			series.Color = Color.Red;
			series.BorderWidth = 3;
			this.chart_XBarChart.Series.Add(series);
			series = new Series();
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Double;
			series.Legend = "Legend1";
			series.LegendText = "AVG";
			series.Name = "AVG";
			series.ChartType = SeriesChartType.Line;
			series.Color = Color.Gold;
			series.BorderWidth = 3;
			this.chart_XBarChart.Series.Add(series);
			for (int j = 0; j < dsData.Tables[0].Rows.Count; j++)
			{
				text = Convert.ToDateTime(dsData.Tables[0].Rows[j]["summarydate"].ToString()).ToShortDateString();
				double num3 = this.convertValue(dsData.Tables[0].Rows[0]["USL"].ToString());
				double num4 = this.convertValue(dsData.Tables[0].Rows[0]["LSL"].ToString());
				double num5 = this.convertValue(dsData.Tables[0].Rows[j]["AVG"].ToString());
				this.chart_XBarChart.Series["Unit1"].Points.Add(new double[]
				{
					this.convertValue(dsData.Tables[0].Rows[j]["unit1"].ToString())
				});
				this.chart_XBarChart.Series["Unit2"].Points.Add(new double[]
				{
					this.convertValue(dsData.Tables[0].Rows[j]["unit2"].ToString())
				});
				this.chart_XBarChart.Series["Unit3"].Points.Add(new double[]
				{
					this.convertValue(dsData.Tables[0].Rows[j]["unit3"].ToString())
				});
				this.chart_XBarChart.Series["Unit4"].Points.Add(new double[]
				{
					this.convertValue(dsData.Tables[0].Rows[j]["unit4"].ToString())
				});
				this.chart_XBarChart.Series["Unit5"].Points.Add(new double[]
				{
					this.convertValue(dsData.Tables[0].Rows[j]["unit5"].ToString())
				});
				this.chart_XBarChart.Series["UCL"].Points.Add(new double[]
				{
					num3
				});
				this.chart_XBarChart.Series["LCL"].Points.Add(new double[]
				{
					num4
				});
				this.chart_XBarChart.Series["AVG"].Points.Add(new double[]
				{
					num5
				});
				if (num3.Equals(double.NaN))
				{
					this.chart_XBarChart.Series["UCL"].Points[j].IsEmpty = true;
				}
				if (num4.Equals(double.NaN))
				{
					this.chart_XBarChart.Series["LCL"].Points[j].IsEmpty = true;
				}
				if (num5.Equals(double.NaN))
				{
					this.chart_XBarChart.Series["AVG"].Points[j].IsEmpty = true;
				}
				if (j == 0)
				{
					this.chart_XBarChart.Series["UCL"].Points[j].Label = "UCL";
					this.chart_XBarChart.Series["LCL"].Points[j].Label = "LCL";
					this.chart_XBarChart.Series["AVG"].Points[j].Label = "AVG";
					this.chart_XBarChart.Series["AVG"].Font = new Font("Segoe UI", 10f, FontStyle.Regular);
					this.chart_XBarChart.Series["AVG"].Points[j].LabelForeColor = Color.FromArgb(0, 0, 0);
					this.chart_XBarChart.Series["UCL"].Font = new Font("Segoe UI", 10f, FontStyle.Regular);
					this.chart_XBarChart.Series["UCL"].Points[j].LabelForeColor = Color.FromArgb(0, 0, 0);
					this.chart_XBarChart.Series["LCL"].Font = new Font("Segoe UI", 10f, FontStyle.Regular);
					this.chart_XBarChart.Series["LCL"].Points[j].LabelForeColor = Color.FromArgb(0, 0, 0);
				}
				CustomLabel customLabel = new CustomLabel();
				customLabel.Text = text;
				customLabel.FromPosition = 0.5;
				if (num == 0)
				{
					customLabel.ToPosition = num2;
				}
				else
				{
					num2 += 2.0;
					customLabel.ToPosition = num2;
				}
				customLabel.RowIndex = 0;
				this.chart_XBarChart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_XBarChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_XBarChart.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_XBarChart.ChartAreas[0].Position.Auto = false;
			this.chart_XBarChart.ChartAreas[0].Position.X = 0f;
			this.chart_XBarChart.ChartAreas[0].Position.Y = 10f;
			this.chart_XBarChart.ChartAreas[0].Position.Height = 80f;
			this.chart_XBarChart.ChartAreas[0].Position.Width = 99f;
			this.chart_XBarChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_XBarChart.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_XBarChart.ChartAreas[0].AxisX.Maximum = (double)dsData.Tables[0].Rows.Count;
			this.chart_XBarChart.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_XBarChart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_XBarChart.ChartAreas[0].AxisX.Interval = 1.0;
			this.chart_XBarChart.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_XBarChart.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_XBarChart.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_XBarChart.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_XBarChart.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_XBarChart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_XBarChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_XBarChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
			this.chart_XBarChart.ChartAreas[0].AxisY.Maximum = double.NaN;
			this.chart_XBarChart.ChartAreas[0].AxisY.Minimum = double.NaN;
			this.chart_XBarChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
			this.chart_XBarChart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
			this.chart_XBarChart.ChartAreas[0].RecalculateAxesScale();
			this.chart_XBarChart.Update();
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00018970 File Offset: 0x00016B70
		private void setRChart(DataSet dsData)
		{
			this.initChartView(this.chart_RChart);
			int num = 0;
			double num2 = 1.5;
			string text = string.Empty;
			string empty = string.Empty;
			string text2 = this.cmb_Trend_Tester.Text;
			this.chart_RChart.Titles["Title1"].Text = this.cmb_Trend_TestItem.Text;
			Series series = new Series();
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Double;
			series.Legend = "Legend1";
			series.LegendText = "UCL";
			series.Name = "UCL";
			series.ChartType = SeriesChartType.Line;
			series.Color = Color.Blue;
			series.BorderWidth = 3;
			this.chart_RChart.Series.Add(series);
			series = new Series();
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Double;
			series.Legend = "Legend1";
			series.LegendText = "LCL";
			series.Name = "LCL";
			series.ChartType = SeriesChartType.Line;
			series.Color = Color.Red;
			series.BorderWidth = 3;
			this.chart_RChart.Series.Add(series);
			series = new Series();
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Double;
			series.Legend = "Legend1";
			series.LegendText = "R";
			series.Name = "R";
			series.ChartType = SeriesChartType.Line;
			series.Color = Color.Gold;
			series.BorderWidth = 3;
			this.chart_RChart.Series.Add(series);
			for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
			{
				text = Convert.ToDateTime(dsData.Tables[0].Rows[i]["summarydate"].ToString()).ToShortDateString();
				double num3 = this.convertValue(dsData.Tables[0].Rows[0]["R_USL"].ToString());
				double num4 = this.convertValue(dsData.Tables[0].Rows[0]["R_LSL"].ToString());
				double num5 = this.convertValue(dsData.Tables[0].Rows[i]["RANGE"].ToString());
				this.chart_RChart.Series["UCL"].Points.Add(new double[]
				{
					num3
				});
				this.chart_RChart.Series["LCL"].Points.Add(new double[]
				{
					num4
				});
				this.chart_RChart.Series["R"].Points.Add(new double[]
				{
					num5
				});
				if (num3.Equals(double.NaN))
				{
					this.chart_RChart.Series["UCL"].Points[i].IsEmpty = true;
				}
				if (num4.Equals(double.NaN))
				{
					this.chart_RChart.Series["LCL"].Points[i].IsEmpty = true;
				}
				if (num5.Equals(double.NaN))
				{
					this.chart_RChart.Series["R"].Points[i].IsEmpty = true;
				}
				if (i == 0)
				{
					this.chart_RChart.Series["UCL"].Points[i].Label = "UCL";
					this.chart_RChart.Series["LCL"].Points[i].Label = "LCL";
					this.chart_RChart.Series["R"].Points[i].Label = "R";
					this.chart_RChart.Series["R"].Font = new Font("Segoe UI", 10f, FontStyle.Regular);
					this.chart_RChart.Series["R"].Points[i].LabelForeColor = Color.FromArgb(0, 0, 0);
					this.chart_RChart.Series["UCL"].Font = new Font("Segoe UI", 10f, FontStyle.Regular);
					this.chart_RChart.Series["UCL"].Points[i].LabelForeColor = Color.FromArgb(0, 0, 0);
					this.chart_RChart.Series["LCL"].Font = new Font("Segoe UI", 10f, FontStyle.Regular);
					this.chart_RChart.Series["LCL"].Points[i].LabelForeColor = Color.FromArgb(0, 0, 0);
				}
				CustomLabel customLabel = new CustomLabel();
				customLabel.Text = text;
				customLabel.FromPosition = 0.5;
				if (num == 0)
				{
					customLabel.ToPosition = num2;
				}
				else
				{
					num2 += 2.0;
					customLabel.ToPosition = num2;
				}
				customLabel.RowIndex = 0;
				this.chart_RChart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_RChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_RChart.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_RChart.ChartAreas[0].Position.Auto = false;
			this.chart_RChart.ChartAreas[0].Position.X = 0f;
			this.chart_RChart.ChartAreas[0].Position.Y = 10f;
			this.chart_RChart.ChartAreas[0].Position.Height = 80f;
			this.chart_RChart.ChartAreas[0].Position.Width = 99f;
			this.chart_RChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_RChart.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_RChart.ChartAreas[0].AxisX.Maximum = (double)dsData.Tables[0].Rows.Count;
			this.chart_RChart.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_RChart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_RChart.ChartAreas[0].AxisX.Interval = 1.0;
			this.chart_RChart.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_RChart.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_RChart.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_RChart.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_RChart.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_RChart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_RChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_RChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
			this.chart_RChart.ChartAreas[0].AxisY.Maximum = double.NaN;
			this.chart_RChart.ChartAreas[0].AxisY.Minimum = double.NaN;
			this.chart_RChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
			this.chart_RChart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
			this.chart_RChart.ChartAreas[0].RecalculateAxesScale();
			this.chart_RChart.Update();
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00019341 File Offset: 0x00017541
		private void initChartView(Chart chart)
		{
			if (chart.Series.Count > 0)
			{
				chart.Series.Clear();
			}
			chart.ChartAreas[0].AxisX.CustomLabels.Clear();
			chart.Update();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00019380 File Offset: 0x00017580
		private void cmb_Trend_TestItem_DropDown(object sender, EventArgs e)
		{
			this.cmb_Trend_TestItem.Items.Clear();
			string text = this.txtTrendTestItem.Text;
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ESI_GetParameterName]  @parameter = '" + text + "'";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.cmb_Trend_TestItem.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00019440 File Offset: 0x00017640
		private double convertValue(string sValue)
		{
			double result = 0.0;
			if (sValue != string.Empty && double.TryParse(sValue, out result))
			{
				return result;
			}
			result = double.NaN;
			return result;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0001947C File Offset: 0x0001767C
		private void cmd_AddPara_Click(object sender, EventArgs e)
		{
			new AddParameter
			{
				_factorySettings = this._factorySetting
			}.Show();
		}

		// Token: 0x04000149 RID: 329
		private ContextMenu menuTypeGrid = new ContextMenu();

		// Token: 0x0400014A RID: 330
		private ContextMenu menuGrid = new ContextMenu();

		// Token: 0x0400014B RID: 331
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x0400014C RID: 332
		private ToolTip toolTip = new ToolTip();

		// Token: 0x0400014D RID: 333
		private SortedList _slData = new SortedList();

		// Token: 0x0400014E RID: 334
		private SortedList _slBindingData = new SortedList();

		// Token: 0x0400014F RID: 335
		private ArrayList arrCellColor = new ArrayList();

		// Token: 0x04000150 RID: 336
		private SortedList slUploadData = new SortedList();

		// Token: 0x04000151 RID: 337
		private Thread _thread;

		// Token: 0x04000152 RID: 338
		private BarPrograss _barPrograss;

		// Token: 0x04000153 RID: 339
		private ArrayList arrExceptChar = new ArrayList
		{
			"\\",
			"/",
			"?",
			"*",
			"[",
			"]"
		};

		// Token: 0x0200002E RID: 46
		private class sorting : IComparer, IComparer<int>
		{
			// Token: 0x06000167 RID: 359 RVA: 0x00024D41 File Offset: 0x00022F41
			public int Compare(int one, int two)
			{
				return two.CompareTo(one);
			}

			// Token: 0x06000168 RID: 360 RVA: 0x00024D4B File Offset: 0x00022F4B
			public int Compare(object one, object two)
			{
				return this.Compare((int)one, (int)two);
			}
		}
	}
}
