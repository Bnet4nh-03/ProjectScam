using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Control;
using Amkor.CADModules.CarrierModule.Properties;
using Amkor.CADModules.CarrierModule.View;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.CarrierModule
{
	// Token: 0x0200002D RID: 45
	public partial class Carrier : BaseWinView
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00006C9C File Offset: 0x00004E9C
		public Carrier()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://testweb.amkor.co.kr/";
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this._cimitarUser._userstring1 = "CAD_SOCKET_ADMIN";
			this.InitializeComponent();
			this._slAuthList.Add("CAD_CARRIER_ADMIN", "CAD_CARRIER_ADMIN");
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006E20 File Offset: 0x00005020
		public Carrier(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00006F60 File Offset: 0x00005160
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006F70 File Offset: 0x00005170
		private void Carrier_Load(object sender, EventArgs e)
		{
			this.checkUserAuth();
			this._slCarrierType = new SortedList();
			this._slAllData = new SortedList();
			this._slAllData2 = new SortedList();
			this._slCarrierTypeSIB = new SortedList();
			this._slAllDataSIB = new SortedList();
			this._slSlotType = new SortedList();
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.initItemGridContextMenu();
			this.initCarrierList();
			this.initCarrierHistory(this.gridSearchHistory);
			this.initCarrierHistory(this.gridCarrierHistoryList);
			this.initUserField();
			this.initMgrCarrierList();
			this.initSWVersionList();
			this.cmbCarrierType_DropDown(null, null);
			this.cmbCustomer_DropDown(null, null);
			this.cmbOpCode_DropDown(null, null);
			this.cmbInventoryType_DropDown(null, null);
			this.cmbFailMode_DropDown(null, null);
			this.getCarrierStatus();
			this.cmbHistoryCarrierType_DropDown(null, null);
			this.cmbHistoryProduct_DropDown(null, null);
			this.cmbHistoryCarrierCustomer_DropDown(null, null);
			this.cmbHistoryCarrierOpCode_DropDown(null, null);
			this.cmbHistoryCarrierCorrelation_DropDown(null, null);
			this.cmbHistoryCarrierTester_DropDown(null, null);
			this.groupBox11.Size = new Size(130, 55);
			this.cmbATPproduct_DropDown(null, null);
			this._slSearchSocketList = new SortedList();
			this._slCommentHistory = new SortedList();
			this._strSearchSocketid = string.Empty;
			this.InitGridCell();
			this.initCommentInfoLabel();
			this.tpSM_tpEnroll_cmbCustomer_DropDown(null, null);
			this.tpSM_tpPeriod_cmbCompletedCommentStatus_DropDown(null, null);
			this._slCommentCompleted = new SortedList();
			this.initEvent();
			this.rdoType_CheckedChanged(null, null);
			this.rdoDateOption_CheckedChanged(null, null);
			this.txtBarcode.TabIndex = 0;
			this.txtBarcode.Focus();
			this.txtBarcode.Select();
			this.panelDetail.Visible = false;
			if (!this.bSocketAdmin)
			{
				this.tc_SM_Detail.TabPages.Remove(this.tpSM_tpEnrollSocket);
				this.tc_SM_Detail.TabPages.Remove(this.tpSM_tpPeriodComment);
				this.tc_SM_Detail.TabPages.Remove(this.tpSM_tpCompledTrend);
			}
			this.radGridView1.RowFormatting += this.grid_Data_RowFormatting;
			this.label_copyright.Text = "Copyright © 2017-" + DateTime.Today.Year.ToString() + " Amkor Technology Korea, Inc. All Rights Reserved.";
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000071A8 File Offset: 0x000053A8
		private void setUserAuthList()
		{
			if (this._cimitarUser._userstring1 != null)
			{
				string[] array = this._cimitarUser._userstring1.ToString().Split(new char[]
				{
					';'
				});
				if (array.Length > 0)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (!this._slAuthList.ContainsKey(array[i]))
						{
							this._slAuthList.Add(array[i], array[i]);
						}
					}
				}
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000721A File Offset: 0x0000541A
		private void checkUserAuth()
		{
			this.setUserAuthList();
			if (this._slAuthList.ContainsKey("CAD_CARRIER_ADMIN"))
			{
				this.bAdminFlag = true;
			}
			if (this._slAuthList.ContainsKey("CAD_SOCKET_ADMIN"))
			{
				this.bSocketAdmin = true;
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00007254 File Offset: 0x00005454
		private bool checkMenuAuth(string sAuthCode, bool bPopupFlag)
		{
			if (this.bAdminFlag)
			{
				return true;
			}
			if (!this._slAuthList.ContainsKey(sAuthCode))
			{
				if (bPopupFlag)
				{
					MessageBox.Show("You do not have permission. Auth Code : " + sAuthCode, "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00007290 File Offset: 0x00005490
		private void saveExcel(SourceGrid.Grid grid)
		{
			try
			{
				if (grid.RowsCount > 1)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx|CSV files|*.csv";
					this.saveFileDialog.FilterIndex = 1;
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						if (this.saveFileDialog.FilterIndex == 1)
						{
							ExcelControl.Save(this.saveFileDialog.FileName, grid, true, null);
						}
						else if (this.saveFileDialog.FilterIndex == 2)
						{
							ExcelControl.SaveCSV(this.saveFileDialog.FileName, grid, this._cimitarUser._exeExcel);
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
				}
				else
				{
					MessageBox.Show("data is not exist ", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00007454 File Offset: 0x00005654
		private void saveExcel(DataTable dtData)
		{
			try
			{
				if (dtData.Rows.Count > 0)
				{
					this.saveFileDialog.DefaultExt = ".csv";
					this.saveFileDialog.Filter = "CSV files|*.csv";
					this.saveFileDialog.FilterIndex = 1;
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						ExcelControl.SaveCSV(this.saveFileDialog.FileName, dtData, this._cimitarUser._exeExcel);
					}
					if (this._barPrograss != null)
					{
						this._barPrograss.setMax(100);
						this._barPrograss.setValue(100);
						Thread.Sleep(100);
						this._barPrograss._ischeck = true;
						this._barPrograss = null;
					}
				}
				else
				{
					MessageBox.Show("data is not exist ", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000075EC File Offset: 0x000057EC
		private void initUserField()
		{
			string sFilePath = Application.StartupPath + "\\Carrier.xml";
			SortedList sortedList = new SortedList();
			this.getUserSettingField(sFilePath, sortedList);
			this.setUserField(this.gridCarrierList, sortedList);
			sFilePath = Application.StartupPath + "\\CarrierHistory.xml";
			sortedList = new SortedList();
			this.getUserSettingField(sFilePath, sortedList);
			this.setUserField(this.gridSearchHistory, sortedList);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00007654 File Offset: 0x00005854
		private DataSet getTypeDefinitionList(string sTypeName)
		{
			DataSet result = new DataSet();
			try
			{
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
				result = this.queryMgr.queryCall(sQuery);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return result;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000076A8 File Offset: 0x000058A8
		private DataSet getTypeDefinitionList(string sTypeName, System.Windows.Forms.ComboBox comboBox)
		{
			DataSet dataSet = new DataSet();
			try
			{
				comboBox.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
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

		// Token: 0x060000A2 RID: 162 RVA: 0x00007758 File Offset: 0x00005958
		private DataSet getATPDefinitionList(string sTypeName, System.Windows.Forms.ComboBox comboBox)
		{
			DataSet dataSet = new DataSet();
			try
			{
				comboBox.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetATPDefList] @typename = '" + sTypeName + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					comboBox.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
				if (sTypeName == "Hostname" && this.txtATPhostname.Text.ToString() != string.Empty && this.txtATPhostname.Text.ToString() != "")
				{
					comboBox.Items.Clear();
					if (dataSet.Tables.Count > 0)
					{
						DataRow[] array = dataSet.Tables[0].Select("[datatype] LIKE '%" + this.txtATPhostname.Text.ToString() + "%'");
						for (int j = 0; j < array.Length; j++)
						{
							comboBox.Items.Add(array[j][0].ToString());
						}
					}
				}
				else if (sTypeName == "ATPname" && this.txtATPname.Text.ToString() != string.Empty && this.txtATPname.Text.ToString() != "")
				{
					comboBox.Items.Clear();
					if (dataSet.Tables.Count > 0)
					{
						DataRow[] array2 = dataSet.Tables[0].Select("[datatype] LIKE '%" + this.txtATPname.Text.ToString() + "%'");
						for (int k = 0; k < array2.Length; k++)
						{
							comboBox.Items.Add(array2[k][0].ToString());
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return dataSet;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000079A4 File Offset: 0x00005BA4
		private DataSet getTypeDefinitionList(string sTypeName, System.Windows.Forms.ComboBox comboBox, string addition)
		{
			DataSet dataSet = new DataSet();
			try
			{
				comboBox.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					comboBox.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
				string[] array = addition.Split(new char[]
				{
					','
				});
				for (int j = 0; j < array.Length; j++)
				{
					comboBox.Items.Add(array[j]);
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return dataSet;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00007A8C File Offset: 0x00005C8C
		private void getTesterList(System.Windows.Forms.ComboBox comboBox)
		{
			comboBox.Items.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTesterList]";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				comboBox.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00007B08 File Offset: 0x00005D08
		private void getStatusList(System.Windows.Forms.ComboBox comboBox)
		{
			comboBox.Items.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetBachStatusList]";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				comboBox.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00007B84 File Offset: 0x00005D84
		private void initEvent()
		{
			this.rdoLoad.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdoIdle.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdoCleanStart.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdorepairStart.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdorepairEnd.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdoDefectStart.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdoBatchChange.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdoWareHouse.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdoEngr.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdoATPTotalList.CheckedChanged += this.rdoATPType_CheckedChanged;
			this.rdoATPDaily.CheckedChanged += this.rdoATPType_CheckedChanged;
			this.rdoViewWareHouse.CheckedChanged += this.rdoViewType_CheckChanged;
			this.rdoViewEngr.CheckedChanged += this.rdoViewType_CheckChanged;
			this.rdoViewDefect.CheckedChanged += this.rdoViewType_CheckChanged;
			this.rdoWRTotal.CheckedChanged += this.rdoWrType_CheckChanged;
			this.rdoWRSipCnt.CheckedChanged += this.rdoWrType_CheckChanged;
			this.rdoWRSipFail.CheckedChanged += this.rdoWrType_CheckChanged;
			this.rdoWRDetectCarrier.CheckedChanged += this.rdoWrType_CheckChanged;
			this.rdoDay.CheckedChanged += this.rdoDateOption_CheckedChanged;
			this.rdoWeek.CheckedChanged += this.rdoDateOption_CheckedChanged;
			this.rdoMonth.CheckedChanged += this.rdoDateOption_CheckedChanged;
			this.rdoPeriod.CheckedChanged += this.rdoDateOption_CheckedChanged;
			this.cmdExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdViewExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdViewExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdViewExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdViewExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdHistoryExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdHistoryExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdHistoryExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdHistoryExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdStatusExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdStatusExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdStatusExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdStatusExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdSIBExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdSIBExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdSIBExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdSIBExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdMgrExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdMgrExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdMgrExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdMgrExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdSWExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdSWExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdSWExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdSWExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdViewSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdViewSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdViewSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdViewSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdHistorySearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdHistorySearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdHistorySearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdHistorySearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdStatusSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdStatusSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdStatusSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdStatusSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdDefectSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdDefectSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdDefectSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdDefectSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdMgrSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdMgrSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdMgrSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdMgrSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdSWSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdSWSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdSWSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdSWSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdSWAdd.MouseDown += this.cmdAdd_MouseDown;
			this.cmdSWAdd.MouseLeave += this.cmdAdd_MouseLeave;
			this.cmdSWAdd.MouseMove += this.cmdAdd_MouseMove;
			this.cmdSWAdd.MouseUp += this.cmdAdd_MouseUp;
			this.cmdCorrSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdCorrSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdCorrSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdCorrSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdCorrExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdCorrExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdCorrExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdCorrExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdAddCorrHistory.MouseDown += this.cmdAdd_MouseDown;
			this.cmdAddCorrHistory.MouseLeave += this.cmdAdd_MouseLeave;
			this.cmdAddCorrHistory.MouseMove += this.cmdAdd_MouseMove;
			this.cmdAddCorrHistory.MouseUp += this.cmdAdd_MouseUp;
			this.cmdDelCorrHistory.MouseDown += this.cmdDelete_MouseDown;
			this.cmdDelCorrHistory.MouseLeave += this.cmdDelete_MouseLeave;
			this.cmdDelCorrHistory.MouseMove += this.cmdDelete_MouseMove;
			this.cmdDelCorrHistory.MouseUp += this.cmdDelete_MouseUp;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00008460 File Offset: 0x00006660
		private void initCarrierList()
		{
			ArrayList arrayList = new ArrayList
			{
				"No",
				"CarrierId",
				"Barcode",
				"CarrierNo",
				"Status",
				"SubStatus",
				"Device",
				"Correlation",
				"OP Code",
				"Carrier Type",
				"Customer",
				"Site",
				"LoadTester",
				"TesterName",
				"PkgType",
				"TouchDownCnt",
				"CleanCnt",
				"repairCnt",
				"LimitCleanCnt",
				"LimitrepairCnt",
				"Memo",
				"LastCleanTime",
				"LastrepairTime",
				"CreateUser",
				"CreateTime",
				"LastEventUser",
				"LastEventTime",
				"LastLoadTester",
				"Revision",
				"MCN#",
				"Main_Barcode",
				"SIB1_Barcode",
				"SIB2_Barcode",
				"RepairCode_Site1",
				"RepairCode_Site2"
			};
			this.dtCarrierList = null;
			this.dtCarrierList = new DataTable();
			for (int i = 0; i < arrayList.Count; i++)
			{
				this.dtCarrierList.Columns.Add(arrayList[i].ToString(), typeof(string));
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00008664 File Offset: 0x00006864
		private void initWareHouseList()
		{
			this.gridViewerList.Rows.Clear();
			this.gridViewerList.ColumnsCount = 5;
			this.gridViewerList.RowsCount = 1;
			this.gridViewerList.FixedRows = 1;
			this.gridViewerList.FixedColumns = 5;
			this.gridViewerList[0, 0] = new GridInfo.ColHeader("No", false);
			this.gridViewerList[0, 1] = new GridInfo.ColHeader("Barcode", false);
			this.gridViewerList[0, 2] = new GridInfo.ColHeader("Carrier No", false);
			this.gridViewerList[0, 3] = new GridInfo.ColHeader("Status", false);
			this.gridViewerList[0, 4] = new GridInfo.ColHeader("Device", false);
			this.gridInfo.SetColumnCellColor(this.gridViewerList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridViewerList);
			this.gridViewerList.Columns[0].Width = 200;
			this.gridViewerList.Columns[1].Width = 200;
			this.gridViewerList.Columns[2].Width = 200;
			this.gridViewerList.Columns[3].Width = 200;
			this.gridViewerList.Columns[4].Width = 200;
			this.gridViewerList.Size = new Size(1050, 1050);
			this.gridViewerList.BringToFront();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00008808 File Offset: 0x00006A08
		private void initWareHouseTotalList()
		{
			this.gridViewerInfo.Rows.Clear();
			this.gridViewerInfo.ColumnsCount = 6;
			this.gridViewerInfo.RowsCount = 1;
			this.gridViewerInfo.FixedRows = 1;
			this.gridViewerInfo.FixedColumns = 6;
			this.gridViewerInfo[0, 0] = new GridInfo.ColHeader("Total", false);
			this.gridViewerInfo[0, 1] = new GridInfo.ColHeader("A Carrier", false);
			this.gridViewerInfo[0, 2] = new GridInfo.ColHeader("C Carrier", false);
			this.gridViewerInfo[0, 3] = new GridInfo.ColHeader("Empty Carrier", false);
			this.gridViewerInfo[0, 4] = new GridInfo.ColHeader("Bad Carrier", false);
			this.gridViewerInfo[0, 5] = new GridInfo.ColHeader("Not Assigned", false);
			this.gridInfo.SetColumnCellColor(this.gridViewerInfo, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridViewerInfo);
			this.gridViewerInfo.Columns[0].Width = 120;
			this.gridViewerInfo.Columns[1].Width = 120;
			this.gridViewerInfo.Columns[2].Width = 120;
			this.gridViewerInfo.Columns[3].Width = 120;
			this.gridViewerInfo.Columns[4].Width = 120;
			this.gridViewerInfo.Columns[5].Width = 120;
			this.gridViewerInfo.Size = new Size(860, 850);
			this.gridViewerInfo.BringToFront();
			this.gridViewerInfo.Update();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000089D8 File Offset: 0x00006BD8
		private void initViewerGridSelected(string sStr)
		{
			this.gridViewerList.Rows.Clear();
			this.gridViewerList.ColumnsCount = 5;
			this.gridViewerList.RowsCount = 1;
			this.gridViewerList.FixedRows = 1;
			this.gridViewerList.FixedColumns = 5;
			this.gridViewerList[0, 0] = new GridInfo.ColHeader("No", false);
			this.gridViewerList[0, 1] = new GridInfo.ColHeader("Barcode", false);
			this.gridViewerList[0, 2] = new GridInfo.ColHeader("Carrier No", false);
			this.gridViewerList[0, 3] = new GridInfo.ColHeader("Status", false);
			this.gridViewerList[0, 4] = new GridInfo.ColHeader("Device", false);
			this.gridInfo.SetColumnCellColor(this.gridViewerList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridViewerList);
			this.gridViewerList.Columns[0].Width = 200;
			this.gridViewerList.Columns[1].Width = 200;
			this.gridViewerList.Columns[2].Width = 200;
			this.gridViewerList.Columns[3].Width = 200;
			this.gridViewerList.Columns[4].Width = 200;
			this.gridViewerList.Size = new Size(1050, 1050);
			this.gridViewerList.BringToFront();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00008B7C File Offset: 0x00006D7C
		private void initViewerGridTotal(string sStr)
		{
			this.gridViewerInfo.Rows.Clear();
			if (sStr == "WareHouse")
			{
				this.gridViewerInfo.ColumnsCount = 6;
				this.gridViewerInfo.RowsCount = 1;
				this.gridViewerInfo.FixedRows = 1;
				this.gridViewerInfo.FixedColumns = 6;
				this.gridViewerInfo[0, 0] = new GridInfo.ColHeader("Total", false);
				this.gridViewerInfo[0, 1] = new GridInfo.ColHeader("A Carrier", false);
				this.gridViewerInfo[0, 2] = new GridInfo.ColHeader("C Carrier", false);
				this.gridViewerInfo[0, 3] = new GridInfo.ColHeader("Bad Carrier", false);
				this.gridViewerInfo[0, 4] = new GridInfo.ColHeader("Empty Carrier", false);
				this.gridViewerInfo[0, 5] = new GridInfo.ColHeader("Not Assigned", false);
				this.gridInfo.SetColumnCellColor(this.gridViewerInfo, 0, this.gridInfo.CellColor.cell_gray_center);
				this.gridInfo.AutoSetGrid(this.gridViewerInfo);
				this.gridViewerInfo.Columns[0].Width = 100;
				this.gridViewerInfo.Columns[1].Width = 120;
				this.gridViewerInfo.Columns[2].Width = 120;
				this.gridViewerInfo.Columns[3].Width = 120;
				this.gridViewerInfo.Columns[4].Width = 120;
				this.gridViewerInfo.Columns[5].Width = 120;
				this.gridViewerInfo.Size = new Size(860, 850);
				this.gridViewerInfo.BringToFront();
				this.gridViewerInfo.Update();
				return;
			}
			if (sStr == "Engr")
			{
				this.gridViewerInfo.Rows.Clear();
				this.gridViewerInfo.ColumnsCount = 5;
				this.gridViewerInfo.RowsCount = 1;
				this.gridViewerInfo.FixedRows = 1;
				this.gridViewerInfo.FixedColumns = 5;
				this.gridViewerInfo[0, 0] = new GridInfo.ColHeader("Total", false);
				this.gridViewerInfo[0, 1] = new GridInfo.ColHeader("Stand by for the Return", false);
				this.gridViewerInfo[0, 2] = new GridInfo.ColHeader("Stand by for the Verification", false);
				this.gridViewerInfo[0, 3] = new GridInfo.ColHeader("In Engr Use", false);
				this.gridViewerInfo[0, 4] = new GridInfo.ColHeader("Not Assigned", false);
				this.gridInfo.SetColumnCellColor(this.gridViewerInfo, 0, this.gridInfo.CellColor.cell_gray_center);
				this.gridInfo.AutoSetGrid(this.gridViewerInfo);
				this.gridViewerInfo.Columns[0].Width = 100;
				this.gridViewerInfo.Columns[1].Width = 140;
				this.gridViewerInfo.Columns[2].Width = 140;
				this.gridViewerInfo.Columns[3].Width = 140;
				this.gridViewerInfo.Columns[4].Width = 140;
				this.gridViewerInfo.Size = new Size(860, 850);
				this.gridViewerInfo.BringToFront();
				this.gridViewerInfo.Update();
				return;
			}
			if (sStr == "Defect")
			{
				this.gridViewerInfo.Rows.Clear();
				this.gridViewerInfo.ColumnsCount = 4;
				this.gridViewerInfo.RowsCount = 1;
				this.gridViewerInfo.FixedRows = 1;
				this.gridViewerInfo.FixedColumns = 4;
				this.gridViewerInfo[0, 0] = new GridInfo.ColHeader("Total", false);
				this.gridViewerInfo[0, 1] = new GridInfo.ColHeader("Low Yield", false);
				this.gridViewerInfo[0, 2] = new GridInfo.ColHeader("8 Strike", false);
				this.gridViewerInfo[0, 3] = new GridInfo.ColHeader("Not Assigned", false);
				this.gridInfo.SetColumnCellColor(this.gridViewerInfo, 0, this.gridInfo.CellColor.cell_gray_center);
				this.gridInfo.AutoSetGrid(this.gridViewerInfo);
				this.gridViewerInfo.Columns[0].Width = 130;
				this.gridViewerInfo.Columns[1].Width = 130;
				this.gridViewerInfo.Columns[2].Width = 130;
				this.gridViewerInfo.Columns[3].Width = 130;
				this.gridViewerInfo.Size = new Size(860, 850);
				this.gridViewerInfo.BringToFront();
				this.gridViewerInfo.Update();
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000908C File Offset: 0x0000728C
		private void initSelectWareHouse()
		{
			this.iRIndex = 1;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00009098 File Offset: 0x00007298
		private void initItemGridContextMenu()
		{
			this.menuCarrierList.MenuItems.Clear();
			this.menuCarrierList.MenuItems.Add("View Carrier History", new EventHandler(this.viewCarrierHistory_Click));
			this.menuCarrierList.MenuItems.Add("Download Excel", new EventHandler(this.cmdExcel_Click));
			this.menuCarrierMgr.MenuItems.Clear();
			this.menuCarrierMgr.MenuItems.Add("Clear", new EventHandler(this.checkGridClear_Click));
			this.menuCarrierMgr.MenuItems.Add("Check All", new EventHandler(this.checkAllGridCell_Click));
			this.menuCarrierMgr.MenuItems.Add("UnCheck All", new EventHandler(this.checkAllGridCell_Click));
			this.menuCarrierMgr.MenuItems.Add("Reset", new EventHandler(this.cmdReset_Click));
			this.menuCarrierMgr.MenuItems.Add("Test History", new EventHandler(this.cmdTestHistory_Click));
			this.menuSWVersion.MenuItems.Clear();
			this.menuSWVersion.MenuItems.Add("Download File", new EventHandler(this.cmdDownloadFile_Click));
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000091E8 File Offset: 0x000073E8
		private void viewCarrierHistory_Click(object sender, EventArgs e)
		{
			SourceGrid.Grid grid = ((sender as MenuItem).Parent as ContextMenu).SourceControl as SourceGrid.Grid;
			int row = grid.Selection.ActivePosition.Row;
			if (row > 0)
			{
				this.tabCarrier.SelectedIndex = 3;
				this.txtHistoryBarcode.Text = grid[row, 2].ToString();
				this.cmdHistorySearch_Click(null, null);
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00009254 File Offset: 0x00007454
		private void gridCarrierList_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Right)
				{
					if (this.gridCarrierList.RowsCount > 0)
					{
						this.menuCarrierList.Show(this.gridCarrierList, new Point(e.X, e.Y));
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000092C4 File Offset: 0x000074C4
		private void cmbCustomer_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierCustomer", this.cmbCustomer);
			if (this.cmbCustomer.Items.Count > 0)
			{
				this.cmbCustomer.SelectedIndex = 0;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000092F7 File Offset: 0x000074F7
		private void cmbStatus_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierStatus", this.cmbStatus);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000930B File Offset: 0x0000750B
		private void cmbDevice_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbDevice);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000931F File Offset: 0x0000751F
		private void cmbOpCode_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("Opcode", this.cmbOpCode);
			if (this.cmbOpCode.Items.Count > 1)
			{
				this.cmbOpCode.SelectedIndex = 1;
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00009352 File Offset: 0x00007552
		private void cmbCorrelation_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierCorrelation", this.cmbCorrelation);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00009366 File Offset: 0x00007566
		private void cmbCarrierType_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierType", this.cmbCarrierType);
			if (this.cmbCarrierType.Items.Count > 0)
			{
				this.cmbCarrierType.SelectedIndex = 0;
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00009399 File Offset: 0x00007599
		private void cmbTester_DropDown(object sender, EventArgs e)
		{
			this.getTesterList(this.cmbTester);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000093A8 File Offset: 0x000075A8
		private void gridCarrierList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.gridCarrierList.Selection.ActivePosition.Row > 0)
			{
				int row = this.gridCarrierList.Selection.ActivePosition.Row;
				int column = this.gridCarrierList.Selection.ActivePosition.Column;
				if (new AddCarrier(new CarrierInfo
				{
					CarrierId = this.gridCarrierList[row, 1].ToString(),
					Barcode = this.gridCarrierList[row, 2].ToString(),
					CarrierNo = this.gridCarrierList[row, 3].ToString(),
					CarrierType = this.gridCarrierList[row, 9].ToString(),
					CleanCnt = this.gridCarrierList[row, 16].ToString(),
					CreateTime = this.gridCarrierList[row, 24].ToString(),
					CreateUser = this.gridCarrierList[row, 23].ToString(),
					Customer = this.gridCarrierList[row, 10].ToString(),
					Device = this.gridCarrierList[row, 6].ToString(),
					LastCleanTime = this.gridCarrierList[row, 21].ToString(),
					LastEventTime = this.gridCarrierList[row, 26].ToString(),
					LastEventUser = this.gridCarrierList[row, 25].ToString(),
					LastrepairTime = this.gridCarrierList[row, 22].ToString(),
					LimitCleanCnt = this.gridCarrierList[row, 18].ToString(),
					LimitrepairCnt = this.gridCarrierList[row, 19].ToString(),
					Memo = this.gridCarrierList[row, 20].ToString(),
					OperationCode = this.gridCarrierList[row, 8].ToString(),
					PkgType = this.gridCarrierList[row, 14].ToString(),
					repairCnt = this.gridCarrierList[row, 17].ToString(),
					Site = this.gridCarrierList[row, 11].ToString(),
					Status = this.gridCarrierList[row, 4].ToString(),
					TesterName = this.gridCarrierList[row, 13].ToString(),
					LoadTester = this.gridCarrierList[row, 12].ToString(),
					TouchDownCnt = this.gridCarrierList[row, 15].ToString(),
					Correlation = this.gridCarrierList[row, 7].ToString(),
					MainBarcode = this.gridCarrierList[row, 30].ToString(),
					SubBarcode1 = this.gridCarrierList[row, 31].ToString(),
					SubBarcode2 = this.gridCarrierList[row, 32].ToString(),
					RepairCodeSite1 = this.gridCarrierList[row, 33].ToString(),
					RepairCodeSite2 = this.gridCarrierList[row, 33].ToString(),
					MCN = this.gridCarrierList[row, 29].ToString(),
					Revision = this.gridCarrierList[row, 28].ToString(),
					SubStatus = this.gridCarrierList[row, 5].ToString()
				}, this._slAuthList)
				{
					_factorySetting = this._factorySetting,
					_cimitarUser = this._cimitarUser,
					sType = "Modify"
				}.ShowDialog() == DialogResult.OK)
				{
					this.cmdSearch_Click(null, null);
				}
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00009780 File Offset: 0x00007980
		private void grid_Data_RowFormatting(object sender, RowFormattingEventArgs e)
		{
			if ((string)e.RowElement.RowInfo.Cells["Correlation"].Value == "생산 불가능")
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = GradientStyles.Solid;
				e.RowElement.BackColor = Color.Pink;
				return;
			}
			e.RowElement.ResetValue(VisualElement.BackColorProperty, ValueResetFlags.Local);
			e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
			e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00009820 File Offset: 0x00007A20
		private void cmdSearch_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			string empty = string.Empty;
			this.gridCarrierList.RowsCount = 1;
			if (this.cmbCorrelation.Text != string.Empty)
			{
				if (this.cmbCorrelation.Text == "생산 가능")
				{
					text = "1";
				}
				else if (this.cmbCorrelation.Text == "생산 불가능")
				{
					text = "0";
				}
			}
			try
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierList]  @customerid = '",
					this.cmbCustomer.Text,
					"', @status = '",
					this.cmbStatus.Text,
					"', @location = '",
					this.txtBarcode.Text.Trim(),
					"', @device = '",
					this.cmbDevice.Text.Trim(),
					"', @operationcode = '",
					this.cmbOpCode.Text,
					"', @correlation = '",
					text,
					"', @carriertype = '",
					this.cmbCarrierType.Text,
					"', @testername = '",
					this.cmbTester.Text,
					"'"
				});
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				this.initCarrierList();
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.dtCarrierList.Rows.Add(new string[]
						{
							(i + 1).ToString(),
							dataSet.Tables[0].Rows[i]["CarrierId"].ToString(),
							dataSet.Tables[0].Rows[i]["Location"].ToString(),
							dataSet.Tables[0].Rows[i]["CarrierNo"].ToString(),
							dataSet.Tables[0].Rows[i]["Status"].ToString(),
							dataSet.Tables[0].Rows[i]["SubStatus"].ToString(),
							dataSet.Tables[0].Rows[i]["Device"].ToString(),
							dataSet.Tables[0].Rows[i]["Correlation"].ToString(),
							dataSet.Tables[0].Rows[i]["OperationCode"].ToString(),
							dataSet.Tables[0].Rows[i]["CarrierType"].ToString(),
							dataSet.Tables[0].Rows[i]["Customer"].ToString(),
							dataSet.Tables[0].Rows[i]["Site"].ToString(),
							dataSet.Tables[0].Rows[i]["LoadTester"].ToString(),
							dataSet.Tables[0].Rows[i]["TesterName"].ToString(),
							dataSet.Tables[0].Rows[i]["PkgType"].ToString(),
							dataSet.Tables[0].Rows[i]["TouchDownCnt"].ToString(),
							dataSet.Tables[0].Rows[i]["CleanCnt"].ToString(),
							dataSet.Tables[0].Rows[i]["repairCnt"].ToString(),
							dataSet.Tables[0].Rows[i]["LimitCleanCnt"].ToString(),
							dataSet.Tables[0].Rows[i]["LimitrepairCnt"].ToString(),
							dataSet.Tables[0].Rows[i]["Memo"].ToString(),
							dataSet.Tables[0].Rows[i]["LastCleanTime"].ToString(),
							dataSet.Tables[0].Rows[i]["LastrepairTime"].ToString(),
							dataSet.Tables[0].Rows[i]["CreateUser"].ToString(),
							dataSet.Tables[0].Rows[i]["CreateTime"].ToString(),
							dataSet.Tables[0].Rows[i]["LastEventUser"].ToString(),
							dataSet.Tables[0].Rows[i]["LastEventTime"].ToString(),
							dataSet.Tables[0].Rows[i]["LastLoadTester"].ToString(),
							dataSet.Tables[0].Rows[i]["revision"].ToString(),
							dataSet.Tables[0].Rows[i]["MCN"].ToString(),
							dataSet.Tables[0].Rows[i]["main_barcode"].ToString(),
							dataSet.Tables[0].Rows[i]["sub1_barcode"].ToString(),
							dataSet.Tables[0].Rows[i]["sub2_barcode"].ToString(),
							dataSet.Tables[0].Rows[i]["RepairCode"].ToString(),
							dataSet.Tables[0].Rows[i]["RepairCode1"].ToString()
						});
					}
					this.radGridView1.DataSource = this.dtCarrierList;
					this.radGridView1.AllowEditRow = false;
					this.radGridView1.AllowAddNewRow = false;
					this.radGridView1.ShowGroupPanel = false;
					this.radGridView1.EnableFiltering = true;
					this.radGridView1.EnableSorting = true;
					this.radGridView1.EnableGrouping = true;
					this.radGridView1.MasterView.TableHeaderRow.IsVisible = true;
					this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
					this.radGridView1.Columns[0].Width = 40;
					this.radGridView1.Columns[2].Width = 150;
					this.radGridView1.Columns[10].Width = 80;
					this.radGridView1.Columns[6].Width = 60;
					this.radGridView1.Columns[12].Width = 80;
					this.radGridView1.Columns[14].Width = 120;
					this.radGridView1.Columns[4].Width = 80;
					this.radGridView1.Columns[5].Width = 80;
					this.radGridView1.Columns[7].Width = 70;
					this.radGridView1.Columns[20].Width = 200;
					this.radGridView1.Columns[21].Width = 150;
					this.radGridView1.Columns[22].Width = 150;
					this.radGridView1.Columns[23].Width = 80;
					this.radGridView1.Columns[24].Width = 150;
					this.radGridView1.Columns[29].Width = 120;
					this.radGridView1.Columns[25].Width = 80;
					this.radGridView1.Columns[26].Width = 150;
					this.radGridView1.Columns[27].Width = 100;
					this.radGridView1.Columns[30].Width = 150;
					this.radGridView1.Columns[31].Width = 150;
					this.radGridView1.Columns[32].Width = 150;
					this.radGridView1.Columns[33].Width = 200;
					this.radGridView1.Columns[34].Width = 200;
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000A370 File Offset: 0x00008570
		private void cmdAdd_Click(object sender, EventArgs e)
		{
			if (this.checkMenuAuth("CAD_CARRIER_REGISTER", true))
			{
				new AddCarrier
				{
					_factorySetting = this._factorySetting,
					_cimitarUser = this._cimitarUser,
					sType = "Create"
				}.ShowDialog();
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000A3BB File Offset: 0x000085BB
		private void cmdExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel((DataTable)this.radGridView1.DataSource);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000A3D3 File Offset: 0x000085D3
		private void cmdWareHouseExport_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridViewerList);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000A3E1 File Offset: 0x000085E1
		private void cmbWeeklyReportExport_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridWeeklyReport);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000A3EF File Offset: 0x000085EF
		private void initGrpAtSelection(GroupBox g, System.Windows.Forms.ComboBox c)
		{
			c.Text = string.Empty;
			g.Size = new Size(210, 60);
			g.Location = new Point(6, 3);
			c.Size = new Size(180, 23);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000A430 File Offset: 0x00008630
		private void initText()
		{
			this.txtStatusBarcode.Text = string.Empty;
			this.txtStatusDevice.Text = string.Empty;
			this.txtStatusCarrierNo.Text = string.Empty;
			this.txtStatusOpCode.Text = string.Empty;
			this.txtStatusCarrierType.Text = string.Empty;
			this.txtStatusCustomer.Text = string.Empty;
			this.txtStatusSite.Text = string.Empty;
			this.txtStatusTesterName.Text = string.Empty;
			this.txtStatusPkgType.Text = string.Empty;
			this.txtStatusCarrierStatus.Text = string.Empty;
			this.txtStatusTouchDownCnt.Text = string.Empty;
			this.txtStatusCleanCnt.Text = string.Empty;
			this.txtStatusrepairCnt.Text = string.Empty;
			this.txtStatusLimitCleanCnt.Text = string.Empty;
			this.txtStatusLimitrepairCnt.Text = string.Empty;
			this.txtStatusMemo.Text = string.Empty;
			this.txtStatusCorrelation.Text = string.Empty;
			this.txtRevision.Text = string.Empty;
			this.txtStatusSIB1Barcode.Text = string.Empty;
			this.txtStatusSIB2Barcode.Text = string.Empty;
			this.txtAssignSIB1.Text = string.Empty;
			this.txtAssignSIB2.Text = string.Empty;
			this.txtMainCarrier.Text = string.Empty;
			this.txtSite1Reason.Text = string.Empty;
			this.txtSite2Reason.Text = string.Empty;
			this.txtSite1Yield.Text = string.Empty;
			this.txtSite2Yield.Text = string.Empty;
			this.txtAttachFile.Text = string.Empty;
			this.pbUploadImage.Image = null;
			this.selectedCarrier = new CarrierInfo();
			this.groupCarrier.Visible = false;
			this.groupSIB.Visible = false;
			this.lblBarcode.Text = "Barcode";
			this.lblSIB1.Visible = false;
			this.lblSIB2.Visible = false;
			this.txtStatusSIB1Barcode.Visible = false;
			this.txtStatusSIB2Barcode.Visible = false;
			this.txtStatusSIB1Barcode.ReadOnly = false;
			this.txtStatusSIB2Barcode.ReadOnly = false;
			this.chkAutoSelect.Visible = false;
			this.chkMultiBarcode.Visible = true;
			this.cmbSelectStatus.SelectedText = string.Empty;
			this.cmbSelectStatus2.SelectedText = string.Empty;
			this.chkMultiBarcode.Enabled = true;
			this.chkBarcode.Enabled = true;
			if (this.rdoIdle.Checked)
			{
				this.chkAutoSelect.Text = "AutoSelect";
				this.chkAutoSelect.Visible = true;
			}
			else if (this.rdoDefectStart.Checked)
			{
				this.panelPrintInfo.Visible = false;
				this.chkMultiBarcode.Checked = false;
				this.chkMultiBarcode.Visible = false;
				this.groupCarrier.Visible = true;
			}
			else if (this.rdorepairStart.Checked)
			{
				this.panelPrintInfo.Visible = true;
				this.chkAutoSelect.Text = "AutoPrint";
				this.chkAutoSelect.Visible = true;
				this.chkMultiBarcode.Checked = false;
				this.chkMultiBarcode.Visible = true;
				this.groupSIB.Visible = true;
			}
			else if (this.rdorepairEnd.Checked)
			{
				this.panelPrintInfo.Visible = true;
				this.chkAutoSelect.Text = "AutoPrint";
				this.chkAutoSelect.Visible = true;
				this.lblSIB1.Visible = true;
				this.lblSIB2.Visible = true;
				this.txtStatusSIB1Barcode.Visible = true;
				this.txtStatusSIB2Barcode.Visible = true;
				this.chkMultiBarcode.Checked = false;
				this.chkMultiBarcode.Visible = false;
				this.groupSIB.Visible = true;
			}
			else if (this.rdoBatchChange.Checked)
			{
				this.chkMultiBarcode.Checked = true;
				this.chkMultiBarcode.Visible = true;
				this.chkMultiBarcode.Enabled = false;
				this.chkBarcode.Checked = true;
				this.chkBarcode.Enabled = false;
			}
			else if (this.rdoWareHouse.Checked)
			{
				this.chkMultiBarcode.Visible = true;
			}
			else if (this.rdoEngr.Checked)
			{
				this.chkMultiBarcode.Visible = true;
				this.txtStatusSIB1Barcode.Visible = true;
				this.txtStatusSIB2Barcode.Visible = true;
			}
			if (this.grpScan.Controls["TXTMEMO"] != null)
			{
				this.grpScan.Controls["TXTMEMO"].Text = string.Empty;
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000A900 File Offset: 0x00008B00
		private void initCarrierHistory(SourceGrid.Grid grid)
		{
			grid.ColumnsCount = 34;
			grid.RowsCount = 1;
			grid.FixedRows = 1;
			grid[0, 0] = new GridInfo.ColHeader("No", false);
			grid[0, 1] = new GridInfo.ColHeader("CarrierId", false);
			grid[0, 2] = new GridInfo.ColHeader("Barcode", false);
			grid[0, 5] = new GridInfo.ColHeader("Device", false);
			grid[0, 3] = new GridInfo.ColHeader("CarrierNo", false);
			grid[0, 25] = new GridInfo.ColHeader("OP Code", false);
			grid[0, 7] = new GridInfo.ColHeader("Carrier Type", false);
			grid[0, 26] = new GridInfo.ColHeader("Customer", false);
			grid[0, 27] = new GridInfo.ColHeader("Site", false);
			grid[0, 8] = new GridInfo.ColHeader("LoadTester", false);
			grid[0, 28] = new GridInfo.ColHeader("TesterName", false);
			grid[0, 29] = new GridInfo.ColHeader("PkgType", false);
			grid[0, 4] = new GridInfo.ColHeader("Status", false);
			grid[0, 9] = new GridInfo.ColHeader("TouchDownCnt", false);
			grid[0, 10] = new GridInfo.ColHeader("CleanCnt", false);
			grid[0, 11] = new GridInfo.ColHeader("repairCnt", false);
			grid[0, 30] = new GridInfo.ColHeader("LimitCleanCnt", false);
			grid[0, 31] = new GridInfo.ColHeader("LimitrepairCnt", false);
			grid[0, 6] = new GridInfo.ColHeader("Correlation", false);
			grid[0, 17] = new GridInfo.ColHeader("Memo", false);
			grid[0, 23] = new GridInfo.ColHeader("LastCleanTime", false);
			grid[0, 24] = new GridInfo.ColHeader("LastrepairTime", false);
			grid[0, 32] = new GridInfo.ColHeader("CreateUser", false);
			grid[0, 33] = new GridInfo.ColHeader("CreateTime", false);
			grid[0, 12] = new GridInfo.ColHeader("LastEventUser", false);
			grid[0, 13] = new GridInfo.ColHeader("LastEventTime", false);
			grid[0, 14] = new GridInfo.ColHeader("LastLoadTester", false);
			grid[0, 15] = new GridInfo.ColHeader("Revision", false);
			grid[0, 16] = new GridInfo.ColHeader("MCN#", false);
			grid[0, 18] = new GridInfo.ColHeader("Main", false);
			grid[0, 19] = new GridInfo.ColHeader("SIB1_Barcode", false);
			grid[0, 20] = new GridInfo.ColHeader("SIB2_Barcode", false);
			grid[0, 21] = new GridInfo.ColHeader("RepairCode_Site1", false);
			grid[0, 22] = new GridInfo.ColHeader("RepairCode_Site2", false);
			grid.Columns[1].Visible = false;
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(grid);
			grid.Columns[0].Width = 40;
			grid.Columns[2].Width = 150;
			grid.Columns[26].Width = 80;
			grid.Columns[5].Width = 60;
			grid.Columns[8].Width = 80;
			grid.Columns[29].Width = 120;
			grid.Columns[4].Width = 80;
			grid.Columns[17].Width = 200;
			grid.Columns[23].Width = 150;
			grid.Columns[24].Width = 150;
			grid.Columns[32].Width = 80;
			grid.Columns[33].Width = 150;
			grid.Columns[12].Width = 80;
			grid.Columns[13].Width = 150;
			grid.Columns[14].Width = 100;
			grid.Columns[18].Width = 150;
			grid.Columns[19].Width = 150;
			grid.Columns[20].Width = 150;
			grid.Columns[21].Width = 200;
			grid.Columns[22].Width = 200;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000ADAC File Offset: 0x00008FAC
		private void getLastRepairCode(string sBarcode)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetLastRepairCode] @location = '" + sBarcode + "'";
			DataSet ds = this.queryMgr.queryCall(sQuery);
			RepairInfo repairInfo = (RepairInfo)((TabPage)base.Controls.Find("TP1", true)[0]).Controls[0];
			repairInfo.getLastRepairCode(ds);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000AE07 File Offset: 0x00009007
		private void cmbDamage_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("SIB_Damage", this.cmbDamage);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000AE1B File Offset: 0x0000901B
		private void cmbSuspectCause_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("SIB_SuspectCause", this.cmbSuspectCause);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000AE30 File Offset: 0x00009030
		private DataSet getReasonCodeList(string sReasonType, string sReasonCategory, string sDevice, string sPageName)
		{
			DataSet dataSet = new DataSet();
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_GetReasonCode] @type = 'Info', @reasontype = '",
				sReasonType,
				"', @reasoncategory = '",
				sReasonCategory,
				"', @device = '",
				sDevice,
				"'"
			});
			dataSet = this.queryMgr.queryCall(sQuery);
			RepairInfo repairInfo = (RepairInfo)((TabPage)base.Controls.Find(sPageName, true)[0]).Controls[0];
			repairInfo.InitRepairData(dataSet, "", true);
			return dataSet;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000AEC0 File Offset: 0x000090C0
		private void getCarrierHistory(CarrierInfo carrier, SourceGrid.Grid grid, bool progressFlag)
		{
			grid.RowsCount = 1;
			try
			{
				if (progressFlag)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Loading Data....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
				}
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierHistory] @location = '",
					carrier.Barcode,
					"', @status = '",
					carrier.Status,
					"', @carriertype = '",
					carrier.CarrierType,
					"', @startdate = '",
					carrier.StartDate,
					"', @enddate = '",
					carrier.EndDate,
					"', @device = '",
					carrier.Device,
					"', @customerid = '",
					carrier.Customer,
					"', @operationcode = '",
					carrier.OperationCode,
					"', @correlation = '",
					carrier.Correlation,
					"', @testername = '",
					carrier.TesterName,
					"', @datesearchmode = '",
					carrier.DateSearchMode,
					"'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					if (progressFlag)
					{
						this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					}
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						grid.Rows.Insert(grid.RowsCount);
						grid[i + 1, 0] = new SourceGrid.Cells.Cell((grid.RowsCount - 1).ToString());
						grid[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CarrierId"].ToString());
						grid[i + 1, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Location"].ToString());
						grid[i + 1, 5] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Device"].ToString());
						grid[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CarrierNo"].ToString());
						grid[i + 1, 25] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["OperationCode"].ToString());
						grid[i + 1, 7] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CarrierType"].ToString());
						grid[i + 1, 26] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Customer"].ToString());
						grid[i + 1, 27] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Site"].ToString());
						grid[i + 1, 8] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LoadTester"].ToString());
						grid[i + 1, 28] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["TesterName"].ToString());
						grid[i + 1, 29] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["PkgType"].ToString());
						grid[i + 1, 4] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Status"].ToString());
						grid[i + 1, 9] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["TouchDownCnt"].ToString());
						grid[i + 1, 10] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CleanCnt"].ToString());
						grid[i + 1, 11] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["repairCnt"].ToString());
						grid[i + 1, 30] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LimitCleanCnt"].ToString());
						grid[i + 1, 31] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LimitrepairCnt"].ToString());
						grid[i + 1, 6] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Correlation"].ToString());
						grid[i + 1, 17] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Memo"].ToString());
						grid[i + 1, 23] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastCleanTime"].ToString());
						grid[i + 1, 24] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastrepairTime"].ToString());
						grid[i + 1, 32] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CreateUser"].ToString());
						grid[i + 1, 33] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CreateTime"].ToString());
						grid[i + 1, 12] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastEventUser"].ToString());
						grid[i + 1, 13] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastEventTime"].ToString());
						grid[i + 1, 14] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastLoadTester"].ToString());
						grid[i + 1, 15] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Revision"].ToString());
						grid[i + 1, 16] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["MCN"].ToString());
						grid[i + 1, 18] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["main_barcode"].ToString());
						grid[i + 1, 19] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["sub1_barcode"].ToString());
						grid[i + 1, 20] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["sub2_barcode"].ToString());
						grid[i + 1, 21] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["RepairCode"].ToString());
						grid[i + 1, 22] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["RepairCode1"].ToString());
						if (progressFlag)
						{
							this._barPrograss.setValue(i + 1);
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

		// Token: 0x060000C6 RID: 198 RVA: 0x0000B854 File Offset: 0x00009A54
		private void getCarrierHistoryTotal(SourceGrid.Grid grid, bool progressFlag)
		{
			grid.RowsCount = 1;
			try
			{
				if (progressFlag)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Loading Data....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
				}
				string text = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierList_test]  @customerid = '",
					this.cmbHistoryCarrierCustomer.Text,
					"', @status = '",
					this.chkcmbHistoryStatus.Text,
					"', @location = '",
					this.txtBarcode.Text.Trim(),
					"', @device = '",
					this.cmbHistoryProduct.Text.Trim(),
					"', @operationcode = '",
					this.cmbHistoryCarrierOpCode.Text,
					"', @correlation = '",
					this.cmbHistoryCarrierCorrelation.Text,
					"', @carriertype = '",
					this.cmbHistoryCarrierType.Text,
					"', @testername = '",
					this.cmbHistoryCarrierTester.Text,
					"'"
				});
				text = text + ", @targetdate = '" + this.dtp_Start_History.Value.ToString("yyyy-MM-dd") + "' , @datsearchmode = '1'";
				DataSet dataSet = this.queryMgr.queryCall(text);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					if (progressFlag)
					{
						this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					}
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						grid.Rows.Insert(grid.RowsCount);
						grid[i + 1, 0] = new SourceGrid.Cells.Cell((grid.RowsCount - 1).ToString());
						grid[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CarrierId"].ToString());
						grid[i + 1, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Location"].ToString());
						grid[i + 1, 5] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Device"].ToString());
						grid[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CarrierNo"].ToString());
						grid[i + 1, 25] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["OperationCode"].ToString());
						grid[i + 1, 7] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CarrierType"].ToString());
						grid[i + 1, 26] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Customer"].ToString());
						grid[i + 1, 27] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Site"].ToString());
						grid[i + 1, 8] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LoadTester"].ToString());
						grid[i + 1, 28] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["TesterName"].ToString());
						grid[i + 1, 29] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["PkgType"].ToString());
						grid[i + 1, 4] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Status"].ToString());
						grid[i + 1, 9] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["TouchDownCnt"].ToString());
						grid[i + 1, 10] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CleanCnt"].ToString());
						grid[i + 1, 11] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["repairCnt"].ToString());
						grid[i + 1, 30] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LimitCleanCnt"].ToString());
						grid[i + 1, 31] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LimitrepairCnt"].ToString());
						grid[i + 1, 6] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Correlation"].ToString());
						grid[i + 1, 17] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Memo"].ToString());
						grid[i + 1, 23] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastCleanTime"].ToString());
						grid[i + 1, 24] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastrepairTime"].ToString());
						grid[i + 1, 32] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CreateUser"].ToString());
						grid[i + 1, 33] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CreateTime"].ToString());
						grid[i + 1, 12] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastEventUser"].ToString());
						grid[i + 1, 13] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastEventTime"].ToString());
						grid[i + 1, 14] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastLoadTester"].ToString());
						grid[i + 1, 15] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Revision"].ToString());
						grid[i + 1, 18] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["main_barcode"].ToString());
						grid[i + 1, 19] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["sub1_barcode"].ToString());
						grid[i + 1, 20] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["sub2_barcode"].ToString());
						grid[i + 1, 21] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["RepairCode"].ToString());
						grid[i + 1, 22] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["RepairCode1"].ToString());
						if (progressFlag)
						{
							this._barPrograss.setValue(i + 1);
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
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000C1B8 File Offset: 0x0000A3B8
		private bool checkValue()
		{
			bool result = false;
			if (this.txtStatusBarcode.Text == string.Empty)
			{
				MessageBox.Show("Input barcode please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.rdoLoad.Checked && this.cmbLoadTester.Text == string.Empty)
			{
				MessageBox.Show("select Load Tester please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.rdorepairEnd.Checked && (this.txtStatusSIB1Barcode.Text == string.Empty || this.txtStatusSIB2Barcode.Text == string.Empty))
			{
				MessageBox.Show("Input SIB barcode please.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.rdorepairEnd.Checked && this.txtStatusSIB1Barcode.Text == this.txtStatusSIB2Barcode.Text)
			{
				MessageBox.Show("The sib barcode is the same.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (this.rdoDefectStart.Checked)
			{
				if (this.txtStatusCarrierType.Text == "DUT" && this.txtRevision.Text == string.Empty)
				{
					MessageBox.Show("Input Revision please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (this.cmbDamage.Text == string.Empty && this.cmbSuspectCause.Text != string.Empty)
				{
					MessageBox.Show("Input SIB Damage please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (this.cmbDamage.Text != string.Empty && this.cmbSuspectCause.Text == string.Empty)
				{
					MessageBox.Show("Input SIB Suspect Cause please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					result = true;
				}
			}
			else if (this.rdoWareHouse.Checked)
			{
				if (this.cmbSelectStatus.Text == string.Empty || this.cmbSelectStatus.Text == "")
				{
					MessageBox.Show("Select status for WareHouse among A, C, Empty, Bad", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					result = true;
				}
			}
			else if (this.rdoBatchChange.Checked)
			{
				if (this.cmbSelectStatus.Text == string.Empty || this.cmbSelectStatus.Text == "")
				{
					MessageBox.Show("Select status among Bad, Return, Scrap", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					result = true;
				}
			}
			else if (this.rdoEngr.Checked)
			{
				if (this.cmbSelectStatus.Text == string.Empty || this.cmbSelectStatus.Text == "")
				{
					MessageBox.Show("Select status among Return, Verification, Engr use.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000C4B5 File Offset: 0x0000A6B5
		private void initGridWeeklyReport(string sType)
		{
			if (sType == "Total")
			{
				return;
			}
			if (sType == "SIBCount")
			{
				return;
			}
			sType == "SIBFail";
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000C4E0 File Offset: 0x0000A6E0
		private void rdoWrType_CheckChanged(object sender, EventArgs e)
		{
			if (sender != null && !(sender as RadioButton).Checked)
			{
				return;
			}
			foreach (object obj in this.WeeklyReportStatusPanel.Controls)
			{
				Control control = (Control)obj;
				RadioButton radioButton = (RadioButton)control;
				this.gridWeeklyReport.Rows.Clear();
				if (radioButton.Checked)
				{
					this.sType = radioButton.Tag.ToString();
					if (this.sType == "Total")
					{
						this.groupBox68.Visible = true;
					}
					else if (this.sType == "SIBCount")
					{
						this.groupBox68.Visible = true;
					}
					else if (this.sType == "SIBFail")
					{
						this.groupBox68.Visible = true;
					}
				}
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000C5DC File Offset: 0x0000A7DC
		private void rdoType_CheckedChanged(object sender, EventArgs e)
		{
			if (sender != null && !(sender as RadioButton).Checked)
			{
				return;
			}
			this.initText();
			this.grpLoadTester.Visible = false;
			this.grpSelectStatus.Visible = false;
			this.chkMultiBarcode.Checked = false;
			this.gridClassifiedClean.Visible = false;
			this.gridClassifiedBlacklist.Visible = false;
			this.panelRepairCode.Visible = false;
			this.panelDefectUpload.Visible = false;
			this.panelSIBDamage.Visible = false;
			this.grpRepairReason.Visible = false;
			this.panelRepairCode.Dock = DockStyle.Fill;
			this.txtStatusBarcode.Focus();
			this.txtStatusBarcode.Select();
			this.gridCarrierHistoryList.RowsCount = 1;
			this.cmbLoadTester.Items.Clear();
			this.cmbSelectStatus.Items.Clear();
			this.cmbSelectStatus2.Items.Clear();
			this.panelScan.Size = new Size(1164, 70);
			this.tabControl1.TabPages.Clear();
			this._slCode.Clear();
			foreach (object obj in this.panelMenu.Controls)
			{
				Control control = (Control)obj;
				RadioButton radioButton = (RadioButton)control;
				if (radioButton.Checked)
				{
					this.sType = radioButton.Tag.ToString();
					if (this.sType == "Idle")
					{
						this.chkAutoSelect.Visible = true;
						this.chkMultiLot_CheckedChanged(null, null);
						this.chkAutoSelect_CheckedChanged(null, null);
					}
					else if (this.sType == "Load")
					{
						this.initGrpAtSelection(this.grpLoadTester, this.cmbLoadTester);
						this.grpLoadTester.Visible = true;
					}
					else if (this.sType == "Clean")
					{
						this.chkMultiLot_CheckedChanged(null, null);
						this.gridClassifiedBlacklist.Visible = false;
						this.gridClassifiedClean.Visible = false;
					}
					else if (this.sType == "RepairStart" || this.sType == "RepairEnd")
					{
						this.panelRepairCode.Visible = true;
						this.grpRepairReason.Visible = true;
						this.chkMultiLot_CheckedChanged(null, null);
						this.panelScan.Size = new Size(800, 300);
						if (this.sType == "RepairStart")
						{
							this.addTabPage("TP1", "Cause");
						}
						else
						{
							this.addTabPage("TP1", "Action");
						}
						this.tabControl1.TabPages[0].Controls.Add(new RepairInfo(this.sType));
						this.addTabPage("TP2", "RepairHistory");
						this.tabControl1.TabPages[1].Controls.Add(new RepairHistoryInfo());
					}
					else if (this.sType == "DefectStart")
					{
						this.cmbSelectStatus2.Items.Clear();
						this.cmbSelectStatus2.SelectedItem = "";
						this.getTypeDefinitionList("CarrierDefect", this.cmbSelectStatus2);
						this.openFileDialog.FileName = string.Empty;
						this.panelDefectUpload.Visible = true;
						this.groupBox56.Visible = false;
						this.panelSIBDamage.Visible = true;
						this.panelRepairCode.Visible = true;
						this.cmbDamage.SelectedIndex = -1;
						this.cmbSuspectCause.SelectedIndex = -1;
						this.grpRepairReason.Visible = true;
						this.panelScan.Size = new Size(1164, 300);
						this.addTabPage("TP1", "Reason");
						this.tabControl1.TabPages[0].Controls.Add(new RepairInfo(this.sType));
						this.addTabPage("TP2", "Action");
						this.tabControl1.TabPages[1].Controls.Add(new RepairInfo(this.sType));
					}
					else if (this.sType == "BatchChange")
					{
						this.cmbSelectStatus.Items.Clear();
						this.getStatusList(this.cmbSelectStatus);
						this.initGrpAtSelection(this.grpSelectStatus, this.cmbSelectStatus);
						this.grpSelectStatus.Visible = true;
						this.panelDefectUpload.Visible = true;
						this.groupBox44.Visible = false;
						this.groupBox43.Visible = false;
						this.pbUploadImage.Visible = false;
					}
					else if (this.sType == "WareHouse")
					{
						this.cmbSelectStatus.Items.Clear();
						this.cmbSelectStatus.SelectedItem = "";
						this.getTypeDefinitionList("CarrierWareHouse", this.cmbSelectStatus);
						this.initGrpAtSelection(this.grpSelectStatus, this.cmbSelectStatus);
						this.grpSelectStatus.Visible = true;
					}
					else if (this.sType == "Engr")
					{
						this.cmbSelectStatus.Items.Clear();
						this.cmbSelectStatus.SelectedItem = "";
						this.getTypeDefinitionList("CarrierStore", this.cmbSelectStatus);
						this.initGrpAtSelection(this.grpSelectStatus, this.cmbSelectStatus);
						this.grpSelectStatus.Visible = true;
						this.panelScan.Size = new Size(800, 150);
					}
				}
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000CBA4 File Offset: 0x0000ADA4
		private void setWareHouseTotalTable()
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierWareHouse]";
			this.queryMgr.queryCall(sQuery);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000CBC4 File Offset: 0x0000ADC4
		private void addTabPage(string sPageName, string sPageText)
		{
			TabPage tabPage = new TabPage();
			tabPage.Location = new Point(4, 22);
			tabPage.Name = sPageName;
			tabPage.Text = sPageText;
			tabPage.Padding = new System.Windows.Forms.Padding(3);
			tabPage.Size = new Size(1, 1);
			tabPage.Font = new Font("Segoe UI", 8.25f);
			tabPage.TabIndex = 0;
			tabPage.UseVisualStyleBackColor = true;
			this.tabControl1.TabPages.Add(tabPage);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000CC40 File Offset: 0x0000AE40
		private CarrierInfo chkStatus(string location)
		{
			CarrierInfo carrierInfo = null;
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_CheckCurrentStatus_test] @location = '" + location + "'";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				try
				{
					carrierInfo = new CarrierInfo();
					carrierInfo.Barcode = location;
					carrierInfo.Status = dataSet.Tables[0].Rows[0]["status"].ToString();
					carrierInfo.LastEventTime = dataSet.Tables[0].Rows[0]["lasteventtime"].ToString();
				}
				catch (Exception ex)
				{
					Console.WriteLine("chkStatus ArrayOutOfBounds&Instance Exception : " + ex.Message);
				}
			}
			return carrierInfo;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000CD30 File Offset: 0x0000AF30
		private void txtStatusCarrierName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				if (this.rdorepairStart.Checked && this.chkMultiBarcode.Checked)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Uploading Format....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					string[] array = this.txtStatusBarcode.Text.Split(new char[]
					{
						'\n'
					});
					string text = array[array.Length - 1];
					string cellValue = "";
					string cellValue2 = "";
					string cellValue3 = "";
					string cellValue4 = "";
					this._slCode.Add(array.Length, text);
					this.selectedCarrier = new CarrierInfo();
					string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_CheckCarrierBlackList_PerSite] @location = '" + text.Trim() + "', @site = '1'";
					DataSet dataSet = this.queryMgr.queryCall(sQuery);
					this.selectedCarrier.Location = text.Trim();
					if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						cellValue = dataSet.Tables[0].Rows[0]["result"].ToString();
						cellValue2 = dataSet.Tables[0].Rows[0]["yield"].ToString();
						CCarrierSite ccarrierSite = new CCarrierSite();
						ccarrierSite.FailReason = dataSet.Tables[0].Rows[0]["result"].ToString();
						ccarrierSite.SiteYield = dataSet.Tables[0].Rows[0]["yield"].ToString();
						this.selectedCarrier.CarrierSites.Add("1", ccarrierSite);
						if (dataSet.Tables[1].Rows.Count > 0)
						{
							if (dataSet.Tables[1].Rows.Count == 1)
							{
								ccarrierSite.Top1_Fail = dataSet.Tables[1].Rows[0]["binname"].ToString();
								ccarrierSite.Top1_FailCount = dataSet.Tables[1].Rows[0]["bincnt"].ToString();
							}
							else if (dataSet.Tables[1].Rows.Count == 2)
							{
								ccarrierSite.Top1_Fail = dataSet.Tables[1].Rows[0]["binname"].ToString();
								ccarrierSite.Top1_FailCount = dataSet.Tables[1].Rows[0]["bincnt"].ToString();
								ccarrierSite.Top2_Fail = dataSet.Tables[1].Rows[1]["binname"].ToString();
								ccarrierSite.Top2_FailCount = dataSet.Tables[1].Rows[1]["bincnt"].ToString();
							}
						}
						if (dataSet.Tables[2].Rows.Count > 0)
						{
							string text2 = dataSet.Tables[2].Rows[0]["RepairCnt"].ToString();
							if (text2 != "" || text2 != string.Empty || text2 != null)
							{
								this.selectedCarrier.RepairCnt = int.Parse(dataSet.Tables[2].Rows[0]["RepairCnt"].ToString());
							}
						}
					}
					sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_CheckCarrierBlackList_PerSite] @location = '" + text.Trim() + "', @site = '2'";
					dataSet = new DataSet();
					dataSet = this.queryMgr.queryCall(sQuery);
					if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						cellValue3 = dataSet.Tables[0].Rows[0]["result"].ToString();
						cellValue4 = dataSet.Tables[0].Rows[0]["yield"].ToString();
						CCarrierSite ccarrierSite2 = new CCarrierSite();
						ccarrierSite2.FailReason = dataSet.Tables[0].Rows[0]["result"].ToString();
						ccarrierSite2.SiteYield = dataSet.Tables[0].Rows[0]["yield"].ToString();
						this.selectedCarrier.CarrierSites.Add("2", ccarrierSite2);
						if (dataSet.Tables[1].Rows.Count > 0)
						{
							if (dataSet.Tables[1].Rows.Count == 1)
							{
								ccarrierSite2.Top1_Fail = dataSet.Tables[1].Rows[0]["binname"].ToString();
								ccarrierSite2.Top1_FailCount = dataSet.Tables[1].Rows[0]["bincnt"].ToString();
							}
							else if (dataSet.Tables[1].Rows.Count == 2)
							{
								ccarrierSite2.Top1_Fail = dataSet.Tables[1].Rows[0]["binname"].ToString();
								ccarrierSite2.Top1_FailCount = dataSet.Tables[1].Rows[0]["bincnt"].ToString();
								ccarrierSite2.Top2_Fail = dataSet.Tables[1].Rows[1]["binname"].ToString();
								ccarrierSite2.Top2_FailCount = dataSet.Tables[1].Rows[1]["bincnt"].ToString();
							}
						}
						if (dataSet.Tables[2].Rows.Count > 0)
						{
							string text3 = dataSet.Tables[2].Rows[0]["RepairCnt"].ToString();
							if (text3 != "" || text3 != string.Empty || text3 != null)
							{
								this.selectedCarrier.RepairCnt = int.Parse(dataSet.Tables[2].Rows[0]["RepairCnt"].ToString());
							}
						}
					}
					this.gridClassifiedClean.Rows.Insert(this.iCleanRow);
					this.gridClassifiedClean[this.iCleanRow, 0] = new SourceGrid.Cells.Cell(this.iCleanRow);
					this.gridClassifiedClean[this.iCleanRow, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridClassifiedClean[this.iCleanRow, 1] = new SourceGrid.Cells.Cell(text.Trim());
					this.gridClassifiedClean[this.iCleanRow, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridClassifiedClean[this.iCleanRow, 2] = new SourceGrid.Cells.Cell(cellValue);
					this.gridClassifiedClean[this.iCleanRow, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridClassifiedClean[this.iCleanRow, 3] = new SourceGrid.Cells.Cell(cellValue2);
					this.gridClassifiedClean[this.iCleanRow, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridClassifiedClean[this.iCleanRow, 4] = new SourceGrid.Cells.Cell(cellValue3);
					this.gridClassifiedClean[this.iCleanRow, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridClassifiedClean[this.iCleanRow, 5] = new SourceGrid.Cells.Cell(cellValue4);
					this.gridClassifiedClean[this.iCleanRow, 5].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.iCleanRow++;
					if (this.rdorepairStart.Checked && this.chkAutoSelect.Checked)
					{
						this.setPrint();
					}
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
					return;
				}
				if (this.rdorepairStart.Checked || this.rdorepairEnd.Checked || this.rdoDefectStart.Checked)
				{
					if (this.getCarrierInfo())
					{
						if (this.rdoDefectStart.Checked)
						{
							CarrierInfo carrierInfo = this.chkStatus(this.txtStatusBarcode.Text.Trim());
							if (carrierInfo != null && MessageBox.Show(string.Concat(new string[]
							{
								"There is already defected record of [",
								carrierInfo.Barcode,
								"] at ",
								carrierInfo.LastEventTime,
								".\ndo you want to continue?"
							}), "CIMitarAdmin", MessageBoxButtons.YesNo) == DialogResult.No)
							{
								this.txtStatusBarcode.Text = string.Empty;
								this.gridCarrierHistoryList.Rows.Clear();
								this.initText();
								return;
							}
							this.dsFailCode = this.getReasonCodeList("RepairFail", string.Empty, this.txtStatusDevice.Text, "TP1");
							this.dsRepairCode = this.getReasonCodeList("Repair", string.Empty, string.Empty, "TP2");
							return;
						}
						else
						{
							if (this.rdorepairStart.Checked)
							{
								this.dsFailCode = this.getReasonCodeList("RepairFail", string.Empty, this.txtStatusDevice.Text, "TP1");
								this.getLastRepairCode(this.txtStatusBarcode.Text.Trim());
								string sQuery2 = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_CheckCarrierBlackList_PerSite] @location = '" + this.txtStatusBarcode.Text.Trim() + "', @site = '1'";
								DataSet dataSet2 = this.queryMgr.queryCall(sQuery2);
								this.selectedCarrier.Location = this.txtStatusBarcode.Text.Trim();
								if (dataSet2 != null && dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0)
								{
									this.txtSite1Reason.Text = dataSet2.Tables[0].Rows[0]["result"].ToString();
									this.txtSite1Yield.Text = dataSet2.Tables[0].Rows[0]["yield"].ToString();
									CCarrierSite ccarrierSite3 = new CCarrierSite();
									ccarrierSite3.FailReason = dataSet2.Tables[0].Rows[0]["result"].ToString();
									ccarrierSite3.SiteYield = dataSet2.Tables[0].Rows[0]["yield"].ToString();
									this.selectedCarrier.CarrierSites.Add("1", ccarrierSite3);
									if (dataSet2.Tables[1].Rows.Count > 0)
									{
										if (dataSet2.Tables[1].Rows.Count == 1)
										{
											ccarrierSite3.Top1_Fail = dataSet2.Tables[1].Rows[0]["binname"].ToString();
											ccarrierSite3.Top1_FailCount = dataSet2.Tables[1].Rows[0]["bincnt"].ToString();
										}
										else if (dataSet2.Tables[1].Rows.Count == 2)
										{
											ccarrierSite3.Top1_Fail = dataSet2.Tables[1].Rows[0]["binname"].ToString();
											ccarrierSite3.Top1_FailCount = dataSet2.Tables[1].Rows[0]["bincnt"].ToString();
											ccarrierSite3.Top2_Fail = dataSet2.Tables[1].Rows[1]["binname"].ToString();
											ccarrierSite3.Top2_FailCount = dataSet2.Tables[1].Rows[1]["bincnt"].ToString();
										}
									}
									if (dataSet2.Tables[2].Rows.Count > 0)
									{
										this.selectedCarrier.RepairCnt = int.Parse(dataSet2.Tables[2].Rows[0]["RepairCnt"].ToString());
									}
								}
								sQuery2 = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_CheckCarrierBlackList_PerSite] @location = '" + this.txtStatusBarcode.Text.Trim() + "', @site = '2'";
								dataSet2 = new DataSet();
								dataSet2 = this.queryMgr.queryCall(sQuery2);
								if (dataSet2 != null && dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0)
								{
									this.txtSite2Reason.Text = dataSet2.Tables[0].Rows[0]["result"].ToString();
									this.txtSite2Yield.Text = dataSet2.Tables[0].Rows[0]["yield"].ToString();
									CCarrierSite ccarrierSite4 = new CCarrierSite();
									ccarrierSite4.FailReason = dataSet2.Tables[0].Rows[0]["result"].ToString();
									ccarrierSite4.SiteYield = dataSet2.Tables[0].Rows[0]["yield"].ToString();
									this.selectedCarrier.CarrierSites.Add("2", ccarrierSite4);
									if (dataSet2.Tables[1].Rows.Count > 0)
									{
										if (dataSet2.Tables[1].Rows.Count == 1)
										{
											ccarrierSite4.Top1_Fail = dataSet2.Tables[1].Rows[0]["binname"].ToString();
											ccarrierSite4.Top1_FailCount = dataSet2.Tables[1].Rows[0]["bincnt"].ToString();
										}
										else if (dataSet2.Tables[1].Rows.Count == 2)
										{
											ccarrierSite4.Top1_Fail = dataSet2.Tables[1].Rows[0]["binname"].ToString();
											ccarrierSite4.Top1_FailCount = dataSet2.Tables[1].Rows[0]["bincnt"].ToString();
											ccarrierSite4.Top2_Fail = dataSet2.Tables[1].Rows[1]["binname"].ToString();
											ccarrierSite4.Top2_FailCount = dataSet2.Tables[1].Rows[1]["bincnt"].ToString();
										}
									}
									if (dataSet2.Tables[2].Rows.Count > 0)
									{
										this.selectedCarrier.RepairCnt = int.Parse(dataSet2.Tables[2].Rows[0]["RepairCnt"].ToString());
									}
								}
								if (this.txtSite1Reason.Text == "N/A" && this.txtSite2Reason.Text == "N/A")
								{
									this.txtSite1Reason.Text = "OTHER";
									this.txtSite2Reason.Text = "OTHER";
								}
								this.txtStatusSIB1Barcode.Text = string.Empty;
								this.txtStatusSIB2Barcode.Text = string.Empty;
								this.txtStatusSIB1Barcode.Focus();
								return;
							}
							if (this.rdorepairEnd.Checked)
							{
								this.dsFailCode = this.getReasonCodeList("Repair", string.Empty, string.Empty, "TP1");
								this.txtStatusSIB1Barcode.Focus();
								return;
							}
							this.txtStatusBarcode.Text = string.Empty;
							this.txtStatusBarcode.Focus();
							return;
						}
					}
				}
				else if (this.chkBarcode.Checked)
				{
					if (!this.chkMultiBarcode.Checked)
					{
						if (this.getCarrierInfo())
						{
							this.cmdStatusApply_Click(null, null);
						}
						this.txtStatusBarcode.Focus();
						return;
					}
					string[] array2 = this.txtStatusBarcode.Text.Split(new char[]
					{
						'\n'
					});
					SortedList sortedList = new SortedList();
					for (int i = 0; i < array2.Length; i++)
					{
						if (array2[i] != string.Empty)
						{
							sortedList.Add(i, array2[i].ToString().ToUpper().Trim());
						}
					}
					if (sortedList.Count > 0)
					{
						string sInput = sortedList.GetByIndex(sortedList.Count - 1).ToString();
						if (this.ConvertString(sInput) == "END")
						{
							this.cmdStatusApply_Click(null, null);
							this.txtStatusBarcode.Text = string.Empty;
							this.txtStatusBarcode.Text.Trim();
							this.txtStatusBarcode.Focus();
							return;
						}
						if (this.ConvertString(sInput) == "BACK")
						{
							this.txtStatusBarcode.Text = string.Empty;
							this.txtStatusBarcode.Text.Trim();
							string empty = string.Empty;
							if (sortedList.Count == 1)
							{
								sortedList.RemoveAt(sortedList.Count - 1);
							}
							else if (sortedList.Count > 1)
							{
								sortedList.RemoveAt(sortedList.Count - 1);
								sortedList.RemoveAt(sortedList.Count - 1);
							}
							for (int j = 0; j < sortedList.Count; j++)
							{
								this.txtStatusBarcode.AppendText(sortedList.GetByIndex(j).ToString());
								if (j < sortedList.Count - 1)
								{
									this.txtStatusBarcode.AppendText("\n");
								}
							}
							return;
						}
					}
				}
				else
				{
					this.getCarrierInfo();
				}
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000E09C File Offset: 0x0000C29C
		private bool getCarrierInfo()
		{
			CarrierInfo carrierInfo = new CarrierInfo();
			carrierInfo.Barcode = this.txtStatusBarcode.Text.Trim();
			this.initText();
			if (carrierInfo.Barcode == string.Empty)
			{
				MessageBox.Show("Input carrier name please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			this.gridCarrierHistoryList.RowsCount = 1;
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierInfo] @location = '" + carrierInfo.Barcode + "'";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
			{
				MessageBox.Show(carrierInfo.Barcode + "  carrier is not exist.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if ((this.rdorepairStart.Checked || this.rdorepairEnd.Checked) && dataSet.Tables[0].Rows[0]["CarrierType"].ToString() != "CARRIER")
			{
				MessageBox.Show(carrierInfo.Barcode + " : CarrierType is not a CARRIER", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			this.txtStatusBarcode.Text = dataSet.Tables[0].Rows[0]["Location"].ToString();
			this.txtStatusDevice.Text = dataSet.Tables[0].Rows[0]["Device"].ToString();
			this.txtStatusCarrierNo.Text = dataSet.Tables[0].Rows[0]["CarrierNo"].ToString();
			this.txtStatusOpCode.Text = dataSet.Tables[0].Rows[0]["OperationCode"].ToString();
			this.txtStatusCarrierType.Text = dataSet.Tables[0].Rows[0]["CarrierType"].ToString();
			this.txtStatusCustomer.Text = dataSet.Tables[0].Rows[0]["Customer"].ToString();
			this.txtStatusSite.Text = dataSet.Tables[0].Rows[0]["Site"].ToString();
			this.txtStatusTesterName.Text = dataSet.Tables[0].Rows[0]["TesterName"].ToString();
			this.txtStatusPkgType.Text = dataSet.Tables[0].Rows[0]["PkgType"].ToString();
			this.txtStatusCarrierStatus.Text = dataSet.Tables[0].Rows[0]["Status"].ToString();
			this.txtStatusTouchDownCnt.Text = dataSet.Tables[0].Rows[0]["TouchDownCnt"].ToString();
			this.txtStatusCleanCnt.Text = dataSet.Tables[0].Rows[0]["CleanCnt"].ToString();
			this.txtStatusrepairCnt.Text = dataSet.Tables[0].Rows[0]["repairCnt"].ToString();
			this.txtStatusLimitCleanCnt.Text = dataSet.Tables[0].Rows[0]["LimitCleanCnt"].ToString();
			this.txtStatusLimitrepairCnt.Text = dataSet.Tables[0].Rows[0]["LimitrepairCnt"].ToString();
			this.txtStatusMemo.Text = dataSet.Tables[0].Rows[0]["Memo"].ToString();
			this.txtStatusCorrelation.Text = dataSet.Tables[0].Rows[0]["Correlation"].ToString();
			this.txtRevision.Text = dataSet.Tables[0].Rows[0]["Revision"].ToString();
			if (this.rdoEngr.Checked)
			{
				this.txtStatusSIB1Barcode.Text = dataSet.Tables[0].Rows[0]["sub1_barcode"].ToString();
				this.txtStatusSIB2Barcode.Text = dataSet.Tables[0].Rows[0]["sub2_barcode"].ToString();
			}
			else
			{
				this.txtAssignSIB1.Text = dataSet.Tables[0].Rows[0]["sub1_barcode"].ToString();
				this.txtAssignSIB2.Text = dataSet.Tables[0].Rows[0]["sub2_barcode"].ToString();
			}
			this.txtMainCarrier.Text = dataSet.Tables[0].Rows[0]["main_barcode"].ToString();
			this.txtMCN.Text = dataSet.Tables[0].Rows[0]["MCN"].ToString();
			this.getCarrierHistory(carrierInfo, this.gridCarrierHistoryList, false);
			if (this.rdorepairStart.Checked || this.rdorepairEnd.Checked)
			{
				this.getRepairHistory(carrierInfo);
			}
			return true;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000E6B4 File Offset: 0x0000C8B4
		private string getInput(string sInput)
		{
			string text = string.Empty;
			if (sInput != string.Empty)
			{
				string[] array = sInput.Split(new char[]
				{
					'\n'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (this.ConvertString(array[i].Trim().ToUpper()) != string.Empty)
					{
						if (this.ConvertString(array[i].Trim().ToUpper()) == "END")
						{
							break;
						}
						if (text != string.Empty)
						{
							text += ",";
						}
					}
					text += this.ConvertString(array[i].Trim());
				}
			}
			return text;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000E778 File Offset: 0x0000C978
		private void setPrint()
		{
			try
			{
				if (this.selectedCarrier.CarrierSites.Count != 0)
				{
					PrintDocument printDocument = new PrintDocument();
					printDocument.PrintPage += delegate(object send, PrintPageEventArgs ee)
					{
						this.printPage(this.selectedCarrier, ee);
					};
					printDocument.Print();
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000E7E0 File Offset: 0x0000C9E0
		private void cmdStatusSearch_Click(object sender, EventArgs e)
		{
			if (this.rdoIdle.Checked && this.chkAutoSelect.Checked && this.chkMultiBarcode.Checked)
			{
				this.makeMultiBarcodeScan();
				string text = this.txtStatusBarcode.Text.Trim();
				text = this.getInput(text);
				new SortedList();
				string[] array = text.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetInfoOfYieldAndBlacklist_test] @location = '" + array[i].Trim() + "'";
					DataSet dataSet = this.queryMgr.queryCall(sQuery);
					if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						if (dataSet.Tables[0].Rows[0]["type"].ToString() == "Clean")
						{
							this.gridClassifiedClean.Rows.Insert(this.iCleanRow);
							this.gridClassifiedClean[this.iCleanRow, 1] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "result1"));
							this.gridClassifiedClean[this.iCleanRow, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridClassifiedClean[this.iCleanRow, 2] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "result2"));
							this.gridClassifiedClean[this.iCleanRow, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridClassifiedClean[this.iCleanRow, 3] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "yield1"));
							this.gridClassifiedClean[this.iCleanRow, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridClassifiedClean[this.iCleanRow, 4] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "yield2"));
							this.gridClassifiedClean[this.iCleanRow, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.iCleanRow++;
							this.gridClassifiedClean.Rows.Insert(this.iCleanRow);
							this.gridClassifiedClean[this.iCleanRow, 1] = new SourceGrid.Cells.Cell("Barcode");
							this.gridClassifiedClean[this.iCleanRow, 2] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "barcode"));
							this.gridClassifiedClean[this.iCleanRow, 2].ColumnSpan = 3;
							this.gridClassifiedClean[this.iCleanRow - 1, 0] = new SourceGrid.Cells.Cell(this.iCIndex++.ToString());
							this.gridClassifiedClean[this.iCleanRow - 1, 0].RowSpan = 2;
							this.gridClassifiedClean[this.iCleanRow - 1, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.iCleanRow++;
						}
						else
						{
							this.gridClassifiedBlacklist.Rows.Insert(this.iRepairRow);
							this.gridClassifiedBlacklist[this.iRepairRow, 1] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "result1"));
							this.gridClassifiedBlacklist[this.iRepairRow, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridClassifiedBlacklist[this.iRepairRow, 2] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "result2"));
							this.gridClassifiedBlacklist[this.iRepairRow, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridClassifiedBlacklist[this.iRepairRow, 3] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "yield1"));
							this.gridClassifiedBlacklist[this.iRepairRow, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridClassifiedBlacklist[this.iRepairRow, 4] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "yield2"));
							this.gridClassifiedBlacklist[this.iRepairRow, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.iRepairRow++;
							this.gridClassifiedBlacklist.Rows.Insert(this.iRepairRow);
							this.gridClassifiedBlacklist[this.iRepairRow, 1] = new SourceGrid.Cells.Cell("Barcode");
							this.gridClassifiedBlacklist[this.iRepairRow, 2] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet.Tables[0].Rows, "barcode"));
							this.gridClassifiedBlacklist[this.iRepairRow, 2].ColumnSpan = 3;
							this.gridClassifiedBlacklist[this.iRepairRow - 1, 0] = new SourceGrid.Cells.Cell(this.iRIndex++.ToString());
							this.gridClassifiedBlacklist[this.iRepairRow - 1, 0].RowSpan = 2;
							this.gridClassifiedBlacklist[this.iRepairRow - 1, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.iRepairRow++;
						}
					}
					else
					{
						this.gridClassifiedClean.Rows.Insert(this.iCleanRow);
						this.gridClassifiedClean[this.iCleanRow, 1] = new SourceGrid.Cells.Cell("This data is ");
						this.gridClassifiedClean[this.iCleanRow, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridClassifiedClean[this.iCleanRow, 2] = new SourceGrid.Cells.Cell("not exist or");
						this.gridClassifiedClean[this.iCleanRow, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridClassifiedClean[this.iCleanRow, 3] = new SourceGrid.Cells.Cell(" searched.");
						this.gridClassifiedClean[this.iCleanRow, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridClassifiedClean[this.iCleanRow, 4] = new SourceGrid.Cells.Cell("Check the barcode.");
						this.gridClassifiedClean[this.iCleanRow, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.iCleanRow++;
						this.gridClassifiedClean.Rows.Insert(this.iCleanRow);
						this.gridClassifiedClean[this.iCleanRow, 1] = new SourceGrid.Cells.Cell("Barcode");
						this.gridClassifiedClean[this.iCleanRow, 2] = new SourceGrid.Cells.Cell(array[i].Trim());
						this.gridClassifiedClean[this.iCleanRow, 2].ColumnSpan = 3;
						this.gridClassifiedClean[this.iCleanRow - 1, 0] = new SourceGrid.Cells.Cell(this.iCIndex++.ToString());
						this.gridClassifiedClean[this.iCleanRow - 1, 0].RowSpan = 2;
						this.gridClassifiedClean[this.iCleanRow - 1, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.iCleanRow++;
					}
				}
				return;
			}
			if (this.rdorepairStart.Checked && this.chkMultiBarcode.Checked)
			{
				return;
			}
			this.getCarrierInfo();
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000EFEC File Offset: 0x0000D1EC
		private void cmdUploadFile_Click(object sender, EventArgs e)
		{
			this.openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
			this.openFileDialog.FilterIndex = 1;
			this.openFileDialog.FileName = string.Empty;
			DialogResult dialogResult = this.openFileDialog.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				string a = Path.GetExtension(this.openFileDialog.FileName).ToUpper();
				if (a != ".BMP" && a != ".JPG" && a != ".GIF")
				{
					MessageBox.Show("Invalid file extension.\nOnly bmp, jpg, gif are available.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.openFileDialog.FileName = string.Empty;
					return;
				}
				System.Drawing.Image image = System.Drawing.Image.FromFile(this.openFileDialog.FileName);
				if (image.Size.Height > 800 || image.Size.Width > 800)
				{
					MessageBox.Show("Invalid file size.\nMax 800x800 image size are available.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.openFileDialog.FileName = string.Empty;
					return;
				}
				this.txtAttachFile.Text = this.openFileDialog.SafeFileName;
				this.pbUploadImage.Image = null;
				this.pbUploadImage.Image = image;
				this.pbUploadImage.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000F134 File Offset: 0x0000D334
		private bool setCSVData(List<string> lData)
		{
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
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].ToString() != "" && array[i] != string.Empty)
					{
						lData.Add(array[i]);
					}
				}
				this.txtAttachFile.Text = this.openFileDialog.SafeFileName;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return true;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000F234 File Offset: 0x0000D434
		private void uploadData(SortedList slData)
		{
			if (slData.Count > 0)
			{
				this._barPrograss.progress_label_set("Uploading....");
				this._barPrograss.setMax(slData.Count);
				for (int i = 0; i < slData.Count; i++)
				{
					CarrierInfo carrierInfo = (CarrierInfo)slData.GetByIndex(i);
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ApplyCarrier]  @type = 'Create', @location = '",
						carrierInfo.Barcode,
						"', @device = '",
						carrierInfo.Device,
						"', @carrierno = '",
						carrierInfo.CarrierNo,
						"', @operationcode = '",
						carrierInfo.OperationCode,
						"', @carriertype = '",
						carrierInfo.CarrierType,
						"', @customerid = '",
						carrierInfo.Customer,
						"', @site = '",
						carrierInfo.Site,
						"', @testername = '",
						carrierInfo.TesterName,
						"', @pkgtype = '",
						carrierInfo.PkgType,
						"', @status = '",
						carrierInfo.Status,
						"', @limitcleancnt = '",
						carrierInfo.LimitCleanCnt,
						"', @limitrepaircnt = '",
						carrierInfo.LimitrepairCnt,
						"', @correlation = '",
						carrierInfo.Correlation,
						"', @memo = N'",
						carrierInfo.Memo,
						"', @userid = '",
						this._cimitarUser._id,
						"', @revision = '",
						carrierInfo.Revision,
						"'"
					});
					DataSet dataSet = this.queryMgr.queryCall(sQuery);
					if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						if (dataSet.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
						{
							carrierInfo.Line = i + 1;
							carrierInfo.Result = "Fail";
							carrierInfo.Reason = dataSet.Tables[0].Rows[0]["ReturnValue"].ToString();
						}
						else
						{
							carrierInfo.Line = i + 1;
							carrierInfo.Result = "Success";
						}
					}
					this._barPrograss.setValue(i + 1);
				}
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000F4D0 File Offset: 0x0000D6D0
		private bool setExcelData(List<string> lData)
		{
			try
			{
				OleDbConnection oleDbConnection = new OleDbConnection();
				string format = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.openFileDialog.FileName + ";Mode=ReadWrite|Share Deny None;Extended Properties='Excel 12.0; HDR=yes; IMEX=1';Persist Security Info=False";
				string str = "Sheet1";
				oleDbConnection = new OleDbConnection(string.Format(format, this.openFileDialog.FileName));
				oleDbConnection.Open();
				DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[]
				{
					null,
					null,
					null,
					"TABLE"
				});
				if (oleDbSchemaTable.Rows.Count == 0)
				{
					MessageBox.Show("Uploading data does not exist.", "Error");
					return false;
				}
				for (int i = 0; i < oleDbSchemaTable.Rows.Count; i++)
				{
					if (oleDbSchemaTable.Rows[i]["TABLE_NAME"].ToString().ToUpper() == "UPLOAD$")
					{
						string selectCommandText = "Select * From [" + str + "$]";
						OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(selectCommandText, oleDbConnection);
						DataTable dataTable = new DataTable();
						oleDbDataAdapter.Fill(dataTable);
						Console.WriteLine(dataTable);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				MessageBox.Show("Error : " + ex.Message.ToString(), "Error");
			}
			return true;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000F644 File Offset: 0x0000D844
		private void cmdUploadFile1_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			this.openFileDialog.DefaultExt = ".csv";
			this.openFileDialog.Filter = "CSV, TXT files|*.csv;*.txt;";
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
					new DataSet();
					if (this.openFileDialog.FilterIndex == 1 && this.setCSVData(list))
					{
						this.txtStatusBarcode.Text = list.Aggregate((string a, string b) => a + "\n" + b);
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

		// Token: 0x060000D8 RID: 216 RVA: 0x0000F7A0 File Offset: 0x0000D9A0
		private void cmdRemoveFile_Click(object sender, EventArgs e)
		{
			this.txtAttachFile.Text = string.Empty;
			if (this.pbUploadImage.Image != null)
			{
				this.pbUploadImage.Image = null;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000F7CC File Offset: 0x0000D9CC
		private string uploadFileCheck()
		{
			string result = string.Empty;
			try
			{
				if (this.txtAttachFile.Text != string.Empty && this.pbUploadImage.Image != null)
				{
					byte[] array = StreamManager.ObjectToByteArray(this.pbUploadImage.Image);
					if (array != null)
					{
						result = Convert.ToBase64String(array);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000F840 File Offset: 0x0000DA40
		private void cmdModifyDefect_Click(object sender, EventArgs e)
		{
			if (this._slAllDataSIB.Count == 0)
			{
				MessageBox.Show("Please search data first", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (!this.checkMenuAuth("CAD_CARRIER_OPERATOR", true))
			{
				return;
			}
			CCarrierDataHistory ccarrierDataHistory = new CCarrierDataHistory();
			ccarrierDataHistory.init();
			if (this.rdoPeriodData.Checked && this.gridSIBStatusList.Selection.ActivePosition.Row > 0)
			{
				int row = this.gridSIBStatusList.Selection.ActivePosition.Row;
				int column = this.gridSIBStatusList.Selection.ActivePosition.Column;
				ccarrierDataHistory.strlasteventtime = this.gridSIBStatusList[row, 1].ToString();
				ccarrierDataHistory.strbarcode = this.gridSIBStatusList[row, 2].ToString();
				ccarrierDataHistory.strrevision = this.gridSIBStatusList[row, 3].ToString();
				ccarrierDataHistory.strrepaircode = this.gridSIBStatusList[row, 4].ToString();
				ccarrierDataHistory.strdamage = this.gridSIBStatusList[row, 5].ToString();
				ccarrierDataHistory.strsuspectcause = this.gridSIBStatusList[row, 6].ToString();
				ccarrierDataHistory.strrepaircode1 = this.gridSIBStatusList[row, 7].ToString();
				ccarrierDataHistory.strmemo = this.gridSIBStatusList[row, 8].ToString();
				ccarrierDataHistory.strid = this.gridSIBStatusList[row, 9].ToString();
				ccarrierDataHistory.strdevice = this.gridSIBStatusList[row, 10].ToString();
			}
			if (new ModifyDefect(ccarrierDataHistory)
			{
				_cimitarUser = this._cimitarUser,
				_factorySetting = this._factorySetting,
				Caption = "Modify Defect",
				slDefectList = this._slAllDataSIB
			}.ShowDialog() == DialogResult.OK)
			{
				this.cmdDefectSearch_Click(null, null);
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000FA24 File Offset: 0x0000DC24
		private void gridSIBStatusList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.cmdModifyDefect_Click(null, null);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000FA30 File Offset: 0x0000DC30
		private void cmdStatusApply_Click(object sender, EventArgs e)
		{
			if (!this.checkValue())
			{
				return;
			}
			if (this.rdoDefectStart.Checked)
			{
				CarrierInfo carrierInfo = this.chkStatus(this.txtStatusBarcode.Text.Trim());
				if (carrierInfo != null && MessageBox.Show(string.Concat(new string[]
				{
					"There is already defected record of [",
					carrierInfo.Barcode,
					"] at ",
					carrierInfo.LastEventTime,
					".\nDo you want to continue?"
				}), "CIMitarAdmin", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					this.txtStatusBarcode.Text = string.Empty;
					this.gridCarrierHistoryList.Rows.Clear();
					this.initText();
					return;
				}
			}
			string text = this.txtStatusBarcode.Text.Trim();
			string subBarcode = this.txtStatusSIB1Barcode.Text.Trim();
			string subBarcode2 = this.txtStatusSIB2Barcode.Text.Trim();
			string repairCodeSite = string.Empty;
			string repairCodeSite2 = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			string text5 = string.Empty;
			string text6 = string.Empty;
			string empty = string.Empty;
			string empty2 = string.Empty;
			string text7 = string.Empty;
			if (this.rdorepairStart.Checked || this.rdorepairEnd.Checked)
			{
				if (this.rdorepairStart.Checked && this.txtSite1Reason.Text != string.Empty)
				{
					string text8 = text2;
					text2 = string.Concat(new string[]
					{
						text8,
						"  |  Site1 : ",
						this.txtSite1Reason.Text,
						", Site2 : ",
						this.txtSite2Reason.Text
					});
				}
				RepairInfo repairInfo = (RepairInfo)((TabPage)base.Controls.Find("TP1", true)[0]).Controls[0];
				repairInfo.setRepairCode();
				repairCodeSite = repairInfo.sRepairCode1;
				repairCodeSite2 = repairInfo.sRepairCode2;
			}
			else if (this.rdoDefectStart.Checked)
			{
				text4 = this.uploadFileCheck();
				text3 = this.txtAttachFile.Text;
				text5 = this.cmbDamage.Text;
				text6 = this.cmbSuspectCause.Text;
				RepairInfo repairInfo2 = (RepairInfo)((TabPage)base.Controls.Find("TP1", true)[0]).Controls[0];
				repairCodeSite = repairInfo2.setDefectCode();
				RepairInfo repairInfo3 = (RepairInfo)((TabPage)base.Controls.Find("TP2", true)[0]).Controls[0];
				repairCodeSite2 = repairInfo3.setDefectActionCode();
			}
			try
			{
				DialogResult dialogResult;
				if (this.chkBarcode.Checked)
				{
					dialogResult = DialogResult.Yes;
				}
				else
				{
					dialogResult = MessageBox.Show("Do you want to " + this.sType + "?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				}
				if (dialogResult == DialogResult.Yes)
				{
					text = this.getInput(text);
					if (this.cmbSelectStatus.Text != string.Empty && this.sType == "Engr")
					{
						text2 = text2 + "| Engr : " + this.cmbSelectStatus.Text;
						text7 = this.cmbSelectStatus.Text;
					}
					if (this.cmbSelectStatus.Text != string.Empty && this.sType == "WareHouse")
					{
						text7 = this.cmbSelectStatus.Text;
					}
					if (this.cmbSelectStatus2.Text != string.Empty && this.sType == "DefectStart")
					{
						text7 = this.cmbSelectStatus2.Text;
					}
					if (this.chkMultiBarcode.Checked)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Apply Data....");
						this._barPrograss.setValue(0);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						text2 = this.grpScan.Controls["TXTMEMO"].Text + text2;
						SortedList sortedList = new SortedList();
						string[] array = text.Split(new char[]
						{
							','
						});
						this._barPrograss.setMax(array.Length);
						for (int i = 0; i < array.Length; i++)
						{
							CarrierInfo carrierInfo2 = new CarrierInfo();
							carrierInfo2.Barcode = array[i];
							carrierInfo2.Memo = text2;
							carrierInfo2.LoadTester = this.cmbLoadTester.Text;
							carrierInfo2.RepairCodeSite1 = repairCodeSite;
							carrierInfo2.RepairCodeSite2 = repairCodeSite2;
							carrierInfo2.Revision = this.txtRevision.Text;
							carrierInfo2.SubBarcode1 = subBarcode;
							carrierInfo2.SubBarcode2 = subBarcode2;
							carrierInfo2.Line = i + 1;
							carrierInfo2.BatchStatus = this.cmbSelectStatus.Text;
							carrierInfo2.MCN = this.txtMCN.Text;
							if (!sortedList.ContainsKey(carrierInfo2.Barcode))
							{
								string sQuery = string.Concat(new string[]
								{
									"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ChangeCarrierStatus]  @type = '",
									this.sType,
									"', @location = '",
									carrierInfo2.Barcode,
									"', @memo = N'",
									carrierInfo2.Memo,
									"', @userid = '",
									this._cimitarUser._id,
									"', @loadtester = '",
									carrierInfo2.LoadTester,
									"', @repaircode = '",
									carrierInfo2.RepairCodeSite1,
									"', @repaircode1 = '",
									carrierInfo2.RepairCodeSite2,
									"', @revision = '",
									carrierInfo2.Revision,
									"', @subbarcode1 = '",
									carrierInfo2.SubBarcode1,
									"', @subbarcode2 = '",
									carrierInfo2.SubBarcode2,
									"', @batchstatus = '",
									carrierInfo2.BatchStatus,
									"', @mcn = '",
									carrierInfo2.MCN,
									"', @substatus = '",
									text7,
									"'"
								});
								DataSet dataSet = this.queryMgr.queryCall(sQuery);
								if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
								{
									if (dataSet.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
									{
										carrierInfo2.Result = "Fail";
										carrierInfo2.Reason = dataSet.Tables[0].Rows[0]["ReturnValue"].ToString();
									}
									else
									{
										carrierInfo2.Result = "Success";
									}
								}
								sortedList.Add(carrierInfo2.Barcode, carrierInfo2);
							}
							this._barPrograss.setValue(i + 1);
						}
						this._barPrograss.setMax(100);
						this._barPrograss.setValue(100);
						Thread.Sleep(100);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
						new ResultView
						{
							_factorySetting = this._factorySetting,
							_cimitarUser = this._cimitarUser,
							slResult = sortedList,
							sType = this.sType,
							Caption = this.sType + " Result"
						}.ShowDialog();
						this.initText();
					}
					else
					{
						CarrierInfo carrierInfo3 = new CarrierInfo();
						carrierInfo3.Barcode = text;
						carrierInfo3.Memo = this.txtStatusMemo.Text + text2;
						carrierInfo3.LoadTester = this.cmbLoadTester.Text;
						carrierInfo3.RepairCodeSite1 = repairCodeSite;
						carrierInfo3.RepairCodeSite2 = repairCodeSite2;
						carrierInfo3.Revision = this.txtRevision.Text;
						carrierInfo3.SubBarcode1 = subBarcode;
						carrierInfo3.SubBarcode2 = subBarcode2;
						SortedList sortedList2 = new SortedList();
						if (this.rdoIdle.Checked && this.chkAutoSelect.Checked)
						{
							string sQuery2 = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetInfoOfYieldAndBlacklist_test] @location = '" + carrierInfo3.Barcode + "'";
							DataSet dataSet2 = this.queryMgr.queryCall(sQuery2);
							if (dataSet2 != null && dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0)
							{
								if (dataSet2.Tables[0].Rows[0]["type"].ToString() == "Clean")
								{
									this.gridClassifiedClean[2, 1] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "result1"));
									this.gridClassifiedClean[2, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
									this.gridClassifiedClean[2, 2] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "result2"));
									this.gridClassifiedClean[2, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
									this.gridClassifiedClean[2, 3] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "yield1"));
									this.gridClassifiedClean[2, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
									this.gridClassifiedClean[2, 4] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "yield2"));
									this.gridClassifiedClean[2, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
								}
								else
								{
									this.gridClassifiedBlacklist[2, 1] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "result1"));
									this.gridClassifiedBlacklist[2, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
									this.gridClassifiedBlacklist[2, 2] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "result2"));
									this.gridClassifiedBlacklist[2, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
									this.gridClassifiedBlacklist[2, 3] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "yield1"));
									this.gridClassifiedBlacklist[2, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
									this.gridClassifiedBlacklist[2, 4] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "yield2"));
									this.gridClassifiedBlacklist[2, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
								}
							}
							else
							{
								this.gridClassifiedClean[2, 1] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "result1"));
								this.gridClassifiedClean[2, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
								this.gridClassifiedClean[2, 2] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "result2"));
								this.gridClassifiedClean[2, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
								this.gridClassifiedClean[2, 3] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "yield1"));
								this.gridClassifiedClean[2, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
								this.gridClassifiedClean[2, 4] = new SourceGrid.Cells.Cell(this.checkEmptyString(dataSet2.Tables[0].Rows, "yield2"));
								this.gridClassifiedClean[2, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							}
							this.gridClassifiedBlacklist.Refresh();
						}
						string sQuery3 = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ChangeCarrierStatus]  @type = '",
							this.sType,
							"', @location = '",
							carrierInfo3.Barcode,
							"', @memo = N'",
							carrierInfo3.Memo,
							"', @userid = '",
							this._cimitarUser._id,
							"', @loadtester = '",
							carrierInfo3.LoadTester,
							"', @repaircode = '",
							carrierInfo3.RepairCodeSite1,
							"', @repaircode1 = '",
							carrierInfo3.RepairCodeSite2,
							"', @revision = '",
							carrierInfo3.Revision,
							"', @subbarcode1 = '",
							carrierInfo3.SubBarcode1,
							"', @subbarcode2 = '",
							carrierInfo3.SubBarcode2,
							"', @filename = '",
							text3,
							"', @reference = '",
							text4,
							"', @damage = '",
							text5,
							"', @suspectcause = '",
							text6,
							"', @blacklistcause = '",
							this.txtSite1Reason.Text,
							"', @blacklistcause1 = '",
							this.txtSite2Reason.Text,
							"', @mcn = '",
							carrierInfo3.MCN,
							"', @substatus = '",
							text7,
							"', @assignSIB1 = '",
							this.txtAssignSIB1.Text,
							"', @assignSIB2 = '",
							this.txtAssignSIB2.Text,
							"'"
						});
						DataSet dataSet3 = this.queryMgr.queryCall(sQuery3);
						if (dataSet3 != null && dataSet3.Tables.Count > 0 && dataSet3.Tables[0].Rows.Count > 0)
						{
							if (dataSet3.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
							{
								if (!(this.sType == "Clean"))
								{
									carrierInfo3.Result = "Fail";
									MessageBox.Show(dataSet3.Tables[0].Rows[0]["ReturnValue"].ToString(), "Error");
									return;
								}
								if (MessageBox.Show(dataSet3.Tables[0].Rows[0]["ReturnValue"].ToString() + "\nDo you want to " + this.sType + "?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
								{
									sQuery3 = string.Concat(new string[]
									{
										"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ChangeCarrierStatus]  @type = '",
										this.sType,
										"', @location = '",
										carrierInfo3.Barcode,
										"', @memo = N'",
										carrierInfo3.Memo,
										"', @userid = '",
										this._cimitarUser._id,
										"', @loadtester = '",
										this.cmbLoadTester.Text,
										"', @repaircode = '",
										carrierInfo3.RepairCodeSite1,
										"', @repaircode1 = '",
										carrierInfo3.RepairCodeSite2,
										"', @revision = '",
										carrierInfo3.Revision,
										"', @checkflag = 'N'"
									});
									dataSet3 = this.queryMgr.queryCall(sQuery3);
									if (dataSet3 != null && dataSet3.Tables.Count > 0 && dataSet3.Tables[0].Rows.Count > 0)
									{
										if (dataSet3.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
										{
											carrierInfo3.Result = "Fail";
											MessageBox.Show(dataSet3.Tables[0].Rows[0]["ReturnValue"].ToString(), "Error");
											return;
										}
										if (!this.chkBarcode.Checked)
										{
											MessageBox.Show("Carrier " + this.sType + " Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
										}
										carrierInfo3.Result = "Success";
										sortedList2.Add(carrierInfo3.Barcode, carrierInfo3);
									}
								}
							}
							else
							{
								if (!this.chkBarcode.Checked)
								{
									MessageBox.Show("Carrier " + this.sType + " Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
								carrierInfo3.Result = "Success";
								sortedList2.Add(carrierInfo3.Barcode, carrierInfo3);
							}
							if (this.rdorepairStart.Checked && this.chkAutoSelect.Checked)
							{
								this.setPrint();
							}
							new ResultView
							{
								_factorySetting = this._factorySetting,
								_cimitarUser = this._cimitarUser,
								slResult = sortedList2,
								sType = this.sType,
								Caption = this.sType + " Result"
							}.ShowDialog();
							this.initText();
							this.getCarrierHistory(carrierInfo3, this.gridCarrierHistoryList, false);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00010C80 File Offset: 0x0000EE80
		private string checkEmptyString(DataRowCollection data, string key)
		{
			string result = "";
			try
			{
				result = data[0][key].ToString();
			}
			catch (Exception)
			{
				return result;
			}
			return result;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00010CC0 File Offset: 0x0000EEC0
		private void cmdStatusExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridCarrierHistoryList);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00010CD0 File Offset: 0x0000EED0
		private string ConvertString(string sInput)
		{
			string text = sInput;
			if (sInput != string.Empty)
			{
				text = text.Replace("\t", string.Empty);
				text = text.Replace("\r", string.Empty);
				text = text.Replace("\"", string.Empty);
			}
			return text;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00010D20 File Offset: 0x0000EF20
		private void txtCarrier_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.cmdSearch_Click(null, null);
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00010D34 File Offset: 0x0000EF34
		private void tabCarrier_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tabCarrier.SelectedIndex == 0)
			{
				this.txtBarcode.TabIndex = 0;
				this.txtBarcode.Focus();
				this.txtBarcode.Select();
				return;
			}
			if (this.tabCarrier.SelectedIndex == 1)
			{
				this.txtStatusBarcode.TabIndex = 0;
				this.txtStatusBarcode.Focus();
				this.txtStatusBarcode.Select();
				return;
			}
			if (this.tabCarrier.SelectedIndex == 2)
			{
				this.rdoViewWareHouse.Checked = true;
				return;
			}
			if (this.tabCarrier.SelectedIndex == 9)
			{
				this.rdoWRTotal.Checked = true;
				return;
			}
			if (this.tabCarrier.SelectedIndex == 10)
			{
				this.rdoATPTotalList.Checked = true;
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00010DF6 File Offset: 0x0000EFF6
		private void cmbLoadTester_DropDown(object sender, EventArgs e)
		{
			this.getTesterList(this.cmbLoadTester);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00010E04 File Offset: 0x0000F004
		private void cmbSelectStatus_DropDown(object sender, EventArgs e)
		{
			this.getStatusList(this.cmbSelectStatus);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00010E12 File Offset: 0x0000F012
		private void txtRepairCode_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00010E14 File Offset: 0x0000F014
		private void chkMultiLot_CheckedChanged(object sender, EventArgs e)
		{
			this.txtStatusBarcode.Text = string.Empty;
			if (this.chkMultiBarcode.Checked)
			{
				this.txtStatusBarcode.Size = new Size(228, 480);
				this.txtStatusBarcode.Multiline = true;
				this.panelScan.Dock = DockStyle.Fill;
				this.grpScan.Size = new Size(314, 600);
				this.panel9.Hide();
				this.panel6.Hide();
				if (this.chkAutoSelect.Checked && this.rdoIdle.Checked)
				{
					this.gridClassifiedBlacklist.Rows.Clear();
					this.gridClassifiedClean.Rows.Clear();
					this.makeMultiBarcodeScan();
				}
				else if (this.rdorepairStart.Checked)
				{
					this.gridClassifiedClean.Rows.Clear();
					this.txtStatusBarcode.Text = string.Empty;
					this.groupSIB.Visible = false;
					this.grpRepairReason.Visible = false;
					this.panelRepairCode.Visible = false;
					this.makeMultiRepairScan();
					this._slCode.Clear();
				}
				else if (this.rdoEngr.Checked)
				{
					this.txtStatusSIB1Barcode.Visible = false;
					this.txtStatusSIB2Barcode.Visible = false;
				}
				else
				{
					this.gridClassifiedClean.Rows.Clear();
					this.gridClassifiedBlacklist.Rows.Clear();
					this.gridClassifiedClean.Visible = false;
					this.gridClassifiedBlacklist.Visible = false;
				}
				if (this.grpScan.Controls["LBMEMO"] == null)
				{
					Label label = new Label();
					label.Name = "LBMEMO";
					label.Size = new Size(this.lblBarcode.Size.Width, this.lblBarcode.Size.Height);
					label.Location = new Point(this.lblBarcode.Location.X, this.txtStatusBarcode.Location.Y + this.txtStatusBarcode.Size.Height + 5);
					label.Text = "Memo";
					this.grpScan.Controls.Add(label);
				}
				if (this.grpScan.Controls["TXTMEMO"] == null)
				{
					TextBox textBox = new TextBox();
					textBox.Name = "TXTMEMO";
					textBox.Size = new Size(228, 60);
					textBox.Multiline = true;
					textBox.Location = new Point(this.txtStatusBarcode.Location.X, this.txtStatusBarcode.Location.Y + this.txtStatusBarcode.Size.Height + 5);
					textBox.Text = "";
					this.grpScan.Controls.Add(textBox);
					return;
				}
			}
			else
			{
				this.initCleanControl();
				if (this.rdorepairStart.Checked)
				{
					this.groupSIB.Visible = true;
					this.grpRepairReason.Visible = true;
					this.panelRepairCode.Visible = true;
					this.gridClassifiedClean.Visible = false;
					this.txtStatusBarcode.Text = string.Empty;
				}
				if (this.chkAutoSelect.Checked && this.rdoIdle.Checked)
				{
					this.makeSingleBarcodeScan();
					return;
				}
				this.gridClassifiedClean.Visible = false;
				this.gridClassifiedBlacklist.Visible = false;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000111A4 File Offset: 0x0000F3A4
		private void initCleanControl()
		{
			this.panelBarcode.Width = 320;
			this.panelScan.Dock = DockStyle.Top;
			this.grpScan.Size = new Size(314, 56);
			this.gridClassifiedBlacklist.Size = new Size(228, 25);
			this.gridClassifiedBlacklist.Dock = DockStyle.None;
			this.gridClassifiedClean.Size = new Size(228, 25);
			this.gridClassifiedClean.Dock = DockStyle.None;
			this.panel9.Show();
			this.panel6.Show();
			this.txtStatusBarcode.Size = new Size(228, 23);
			this.txtStatusBarcode.Multiline = false;
			foreach (object obj in this.grpScan.Controls)
			{
				Control control = (Control)obj;
				if (control.Name == "TXTMEMO")
				{
					control.Dispose();
				}
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000112C8 File Offset: 0x0000F4C8
		private void txtRepairCode_TextChanged(object sender, EventArgs e)
		{
			string text = this.txtRepairCode.Text;
			if (this.rdoDefectStart.Checked)
			{
				RepairInfo repairInfo = (RepairInfo)((TabPage)base.Controls.Find("TP1", true)[0]).Controls[0];
				repairInfo.InitRepairData(this.dsFailCode, text, false);
				RepairInfo repairInfo2 = (RepairInfo)((TabPage)base.Controls.Find("TP2", true)[0]).Controls[0];
				repairInfo2.InitRepairData(this.dsRepairCode, text, false);
				return;
			}
			if (this.rdorepairStart.Checked)
			{
				RepairInfo repairInfo3 = (RepairInfo)((TabPage)base.Controls.Find("TP1", true)[0]).Controls[0];
				repairInfo3.InitRepairData(this.dsFailCode, text, false);
				return;
			}
			if (this.rdorepairEnd.Checked)
			{
				RepairInfo repairInfo4 = (RepairInfo)((TabPage)base.Controls.Find("TP1", true)[0]).Controls[0];
				repairInfo4.InitRepairData(this.dsRepairCode, text, false);
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000113E8 File Offset: 0x0000F5E8
		private void cmdAddCode_Click(object sender, EventArgs e)
		{
			new RepairCodeView
			{
				_factorySetting = this._factorySetting,
				_cimitarUser = this._cimitarUser
			}.ShowDialog();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0001141C File Offset: 0x0000F61C
		private void makeMultiRepairScan()
		{
			this.iCleanRow = 1;
			this.panel9.Hide();
			this.panel6.Hide();
			this.gridClassifiedClean.Visible = true;
			this.gridClassifiedClean.ColumnsCount = 6;
			this.gridClassifiedClean.RowsCount = 1;
			this.gridClassifiedClean.FixedRows = 1;
			this.gridClassifiedClean.FixedColumns = 6;
			this.gridClassifiedClean[0, 0] = new GridInfo.ColHeader("No", false);
			this.gridClassifiedClean[0, 1] = new GridInfo.ColHeader("Barcode", false);
			this.gridClassifiedClean[0, 2] = new GridInfo.ColHeader("SITE 1 Reason", false);
			this.gridClassifiedClean[0, 3] = new GridInfo.ColHeader("SITE 1 Yield", false);
			this.gridClassifiedClean[0, 4] = new GridInfo.ColHeader("SITE 2 Reason", false);
			this.gridClassifiedClean[0, 5] = new GridInfo.ColHeader("SITE 2 Yield", false);
			this.gridInfo.SetColumnCellColor(this.gridClassifiedClean, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridClassifiedClean.Columns[0].Width = 25;
			this.gridClassifiedClean.Columns[1].Width = 150;
			this.gridClassifiedClean.Columns[2].Width = 110;
			this.gridClassifiedClean.Columns[3].Width = 100;
			this.gridClassifiedClean.Columns[4].Width = 110;
			this.gridClassifiedClean.Columns[5].Width = 100;
			this.gridClassifiedClean.Dock = DockStyle.Left;
			this.gridClassifiedClean.Size = new Size(620, 850);
			this.gridClassifiedClean.BringToFront();
			this.gridClassifiedClean.Update();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00011604 File Offset: 0x0000F804
		private void makeMultiBarcodeScan()
		{
			this.iRepairRow = 3;
			this.iCleanRow = 3;
			this.iRIndex = 1;
			this.iCIndex = 1;
			this.txtStatusBarcode.Size = new Size(228, 480);
			this.txtStatusBarcode.Multiline = true;
			this.gridClassifiedBlacklist.Rows.Clear();
			this.gridClassifiedClean.Rows.Clear();
			this.gridClassifiedBlacklist.Refresh();
			this.gridClassifiedClean.Refresh();
			this.panel9.Hide();
			this.panel6.Hide();
			this.panelScan.Dock = DockStyle.Fill;
			this.gridClassifiedBlacklist.Visible = true;
			this.gridClassifiedBlacklist.ColumnsCount = 5;
			this.gridClassifiedBlacklist.FixedColumns = 5;
			this.gridClassifiedBlacklist.RowsCount = 3;
			this.gridClassifiedBlacklist.FixedRows = 3;
			this.gridClassifiedBlacklist[0, 0] = new GridInfo.ColHeader("Repair", false);
			this.gridClassifiedBlacklist[0, 0].ColumnSpan = 5;
			this.gridClassifiedBlacklist[1, 0] = new GridInfo.ColHeader("", false);
			this.gridClassifiedBlacklist[1, 1] = new GridInfo.ColHeader("Blacklist", false);
			this.gridClassifiedBlacklist[1, 1].ColumnSpan = 2;
			this.gridClassifiedBlacklist[1, 3] = new GridInfo.ColHeader("Yield", false);
			this.gridClassifiedBlacklist[1, 3].ColumnSpan = 2;
			this.gridClassifiedBlacklist[2, 0] = new GridInfo.ColHeader("No", false);
			this.gridClassifiedBlacklist[2, 1] = new GridInfo.ColHeader("site1", false);
			this.gridClassifiedBlacklist[2, 2] = new GridInfo.ColHeader("site2", false);
			this.gridClassifiedBlacklist[2, 3] = new GridInfo.ColHeader("site1", false);
			this.gridClassifiedBlacklist[2, 4] = new GridInfo.ColHeader("site2", false);
			this.gridClassifiedBlacklist.Dock = DockStyle.Left;
			this.gridClassifiedBlacklist.Size = new Size(320, 100);
			this.gridClassifiedBlacklist.Columns[0].Width = 30;
			this.gridClassifiedBlacklist.Columns[1].Width = 75;
			this.gridClassifiedBlacklist.Columns[2].Width = 75;
			this.gridClassifiedBlacklist.Columns[3].Width = 70;
			this.gridClassifiedBlacklist.Columns[4].Width = 70;
			this.gridInfo.SetColumnCellColor(this.gridClassifiedBlacklist, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridClassifiedBlacklist, 1, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridClassifiedBlacklist, 2, this.gridInfo.CellColor.cell_gray_center);
			this.gridClassifiedClean.Visible = true;
			this.gridClassifiedClean.ColumnsCount = 5;
			this.gridClassifiedClean.RowsCount = 3;
			this.gridClassifiedClean.FixedRows = 3;
			this.gridClassifiedClean.FixedColumns = 5;
			this.gridClassifiedClean[0, 0] = new GridInfo.ColHeader("Clean", false);
			this.gridClassifiedClean[0, 0].ColumnSpan = 5;
			this.gridClassifiedClean[1, 0] = new GridInfo.ColHeader("", false);
			this.gridClassifiedClean[1, 1] = new GridInfo.ColHeader("Blacklist", false);
			this.gridClassifiedClean[1, 1].ColumnSpan = 2;
			this.gridClassifiedClean[1, 3] = new GridInfo.ColHeader("Yield", false);
			this.gridClassifiedClean[1, 3].ColumnSpan = 2;
			this.gridClassifiedClean[2, 0] = new GridInfo.ColHeader("No", false);
			this.gridClassifiedClean[2, 1] = new GridInfo.ColHeader("site1", false);
			this.gridClassifiedClean[2, 2] = new GridInfo.ColHeader("site2", false);
			this.gridClassifiedClean[2, 3] = new GridInfo.ColHeader("site1", false);
			this.gridClassifiedClean[2, 4] = new GridInfo.ColHeader("site2", false);
			this.gridInfo.SetColumnCellColor(this.gridClassifiedClean, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridClassifiedClean, 1, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridClassifiedClean, 2, this.gridInfo.CellColor.cell_gray_center);
			this.gridClassifiedClean.Columns[0].Width = 30;
			this.gridClassifiedClean.Columns[1].Width = 75;
			this.gridClassifiedClean.Columns[2].Width = 75;
			this.gridClassifiedClean.Columns[3].Width = 70;
			this.gridClassifiedClean.Columns[4].Width = 70;
			this.gridClassifiedClean.Dock = DockStyle.Left;
			this.gridClassifiedClean.Size = new Size(320, 100);
			this.gridClassifiedClean.BringToFront();
			this.gridClassifiedClean.Update();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00011B60 File Offset: 0x0000FD60
		private void makeSingleBarcodeScan()
		{
			this.panelScan.Location = new Point(3, 57);
			this.gridClassifiedBlacklist.Rows.Clear();
			this.gridClassifiedBlacklist.Visible = true;
			this.gridClassifiedBlacklist.ColumnsCount = 5;
			this.gridClassifiedBlacklist.FixedColumns = 5;
			this.gridClassifiedBlacklist.RowsCount = 3;
			this.gridClassifiedBlacklist.FixedRows = 3;
			this.gridClassifiedBlacklist[0, 0] = new GridInfo.ColHeader("Repair", false);
			this.gridClassifiedBlacklist[0, 0].RowSpan = 3;
			this.gridClassifiedBlacklist[0, 1] = new GridInfo.ColHeader("Blacklist", false);
			this.gridClassifiedBlacklist[0, 1].ColumnSpan = 2;
			this.gridClassifiedBlacklist[0, 3] = new GridInfo.ColHeader("Yield", false);
			this.gridClassifiedBlacklist[0, 3].ColumnSpan = 2;
			this.gridClassifiedBlacklist[1, 1] = new GridInfo.ColHeader("site1", false);
			this.gridClassifiedBlacklist[1, 2] = new GridInfo.ColHeader("site2", false);
			this.gridClassifiedBlacklist[1, 3] = new GridInfo.ColHeader("site1", false);
			this.gridClassifiedBlacklist[1, 4] = new GridInfo.ColHeader("site2", false);
			this.gridClassifiedBlacklist.Dock = DockStyle.Left;
			this.gridClassifiedBlacklist.Size = new Size(320, 48);
			this.gridClassifiedBlacklist.Columns[0].Width = 45;
			this.gridClassifiedBlacklist.Columns[1].Width = 70;
			this.gridClassifiedBlacklist.Columns[2].Width = 70;
			this.gridClassifiedBlacklist.Columns[3].Width = 70;
			this.gridClassifiedBlacklist.Columns[4].Width = 70;
			this.gridClassifiedClean.Rows.Clear();
			this.gridClassifiedClean.Visible = true;
			this.gridClassifiedClean.ColumnsCount = 5;
			this.gridClassifiedClean.FixedColumns = 5;
			this.gridClassifiedClean.RowsCount = 3;
			this.gridClassifiedClean.FixedRows = 3;
			this.gridClassifiedClean[0, 0] = new GridInfo.ColHeader("Clean", false);
			this.gridClassifiedClean[0, 0].RowSpan = 3;
			this.gridClassifiedClean[0, 1] = new GridInfo.ColHeader("Blacklist", false);
			this.gridClassifiedClean[0, 1].ColumnSpan = 2;
			this.gridClassifiedClean[0, 3] = new GridInfo.ColHeader("Yield", false);
			this.gridClassifiedClean[0, 3].ColumnSpan = 2;
			this.gridClassifiedClean[1, 1] = new GridInfo.ColHeader("site1", false);
			this.gridClassifiedClean[1, 2] = new GridInfo.ColHeader("site2", false);
			this.gridClassifiedClean[1, 3] = new GridInfo.ColHeader("site1", false);
			this.gridClassifiedClean[1, 4] = new GridInfo.ColHeader("site2", false);
			this.gridInfo.SetColumnCellColor(this.gridClassifiedClean, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridClassifiedClean, 1, this.gridInfo.CellColor.cell_gray_center);
			this.gridClassifiedClean.Columns[0].Width = 45;
			this.gridClassifiedClean.Columns[1].Width = 70;
			this.gridClassifiedClean.Columns[2].Width = 70;
			this.gridClassifiedClean.Columns[3].Width = 70;
			this.gridClassifiedClean.Columns[4].Width = 70;
			this.gridClassifiedClean.Dock = DockStyle.Left;
			this.gridClassifiedClean.Size = new Size(320, 48);
			this.gridClassifiedClean.BringToFront();
			this.gridClassifiedClean.Update();
			this.gridInfo.SetColumnCellColor(this.gridClassifiedBlacklist, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridClassifiedBlacklist, 1, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00011FB0 File Offset: 0x000101B0
		private void chkAutoSelect_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkAutoSelect.Checked && this.rdoIdle.Checked)
			{
				if (!this.chkMultiBarcode.Checked)
				{
					this.initCleanControl();
					this.makeSingleBarcodeScan();
					return;
				}
				this.makeMultiBarcodeScan();
				if (this.grpScan.Controls["LBMEMO"] == null)
				{
					Label label = new Label();
					label.Name = "LBMEMO";
					label.Size = new Size(this.lblBarcode.Size.Width, this.lblBarcode.Size.Height);
					label.Location = new Point(this.lblBarcode.Location.X, this.txtStatusBarcode.Location.Y + this.txtStatusBarcode.Size.Height + 5);
					label.Text = "Memo";
					this.grpScan.Controls.Add(label);
				}
				if (this.grpScan.Controls["TXTMEMO"] == null)
				{
					TextBox textBox = new TextBox();
					textBox.Name = "TXTMEMO";
					textBox.Size = new Size(228, 60);
					textBox.Multiline = true;
					textBox.Location = new Point(this.txtStatusBarcode.Location.X, this.txtStatusBarcode.Location.Y + this.txtStatusBarcode.Size.Height + 5);
					textBox.Text = "";
					this.grpScan.Controls.Add(textBox);
					return;
				}
			}
			else
			{
				if (this.chkAutoSelect.Checked && this.rdorepairStart.Checked && this.chkMultiBarcode.Checked)
				{
					this.makeMultiRepairScan();
					return;
				}
				this.gridClassifiedClean.Visible = false;
				this.gridClassifiedBlacklist.Visible = false;
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000121B4 File Offset: 0x000103B4
		private void GetCarrierCategory(string sTypeName)
		{
			try
			{
				DataSet dataSet = new DataSet();
				this._slCarrierType.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename  = '" + sTypeName + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CCarrierType ccarrierType = new CCarrierType();
						ccarrierType.strTypeValue = dataSet.Tables[0].Rows[i]["typevalue"].ToString();
						ccarrierType.strCustomValue = dataSet.Tables[0].Rows[i]["customvalue"].ToString();
						this._slCarrierType.Add(ccarrierType.strTypeValue, ccarrierType);
					}
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000122B4 File Offset: 0x000104B4
		private void GetSlotCategory(string sTypeName)
		{
			try
			{
				DataSet dataSet = new DataSet();
				this._slSlotType.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename  = '" + sTypeName + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CSlotType cslotType = new CSlotType();
						cslotType.strTypeValue = dataSet.Tables[0].Rows[i]["typevalue"].ToString();
						cslotType.strCustomValue = dataSet.Tables[0].Rows[i]["customvalue"].ToString();
						this._slSlotType.Add(cslotType.strTypeValue, cslotType);
					}
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000123B4 File Offset: 0x000105B4
		private void cmbProduct_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbProduct);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000123C8 File Offset: 0x000105C8
		private void cmbProduct2_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbProduct2);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000123DC File Offset: 0x000105DC
		private void cmbProduct3_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbProduct3);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000123F0 File Offset: 0x000105F0
		private void cmbInventoryType_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierInventoryType", this.cmbInventoryType);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00012404 File Offset: 0x00010604
		private void cmbFailMode_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierFailMode", this.cmbFailMode);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00012418 File Offset: 0x00010618
		private void GetPeriodData(string sType, string sLine = "")
		{
			try
			{
				this._slAllData.Clear();
				int num = 1;
				DateTime dateTime = default(DateTime);
				DateTime t = default(DateTime);
				if (this.rdoDay.Checked)
				{
					dateTime = DateTime.Now;
					t = DateTime.Now;
				}
				else if (this.rdoWeek.Checked)
				{
					dateTime = DateTime.Now.AddDays(-6.0);
					t = DateTime.Now;
				}
				else if (this.rdoMonth.Checked)
				{
					dateTime = DateTime.Now.AddDays(-29.0);
					t = DateTime.Now;
				}
				else if (this.rdoPeriod.Checked)
				{
					dateTime = this.dtp_Start.Value;
					t = this.dtp_End.Value;
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				t = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				TimeSpan timeSpan = t.Subtract(dateTime);
				this._barPrograss.setMax(timeSpan.Days + 1);
				DateTime t2 = dateTime;
				while (t2 <= t)
				{
					try
					{
						string sStartDate = t2.ToString("yyyy-MM-dd");
						this._barPrograss.setValue(num++);
						this.SetCarrierHistory(sStartDate, sType, sLine);
					}
					catch (Exception ex)
					{
						ex.ToString();
					}
					t2 = t2.AddDays(1.0);
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex2)
			{
				ex2.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00012694 File Offset: 0x00010894
		private void GetCarrierUtil_Device()
		{
			try
			{
				this._slAllData.Clear();
				int num = 1;
				string sQuery = string.Empty;
				DateTime dateTime = default(DateTime);
				DateTime t = default(DateTime);
				if (this.rdoDay.Checked)
				{
					dateTime = DateTime.Now;
					t = DateTime.Now;
				}
				else if (this.rdoWeek.Checked)
				{
					dateTime = DateTime.Now.AddDays(-7.0);
					t = DateTime.Now.AddDays(-1.0);
				}
				else if (this.rdoMonth.Checked)
				{
					dateTime = DateTime.Now.AddDays(-30.0);
					t = DateTime.Now.AddDays(-1.0);
				}
				else if (this.rdoPeriod.Checked)
				{
					dateTime = this.dtp_Start.Value;
					t = this.dtp_End.Value;
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				t = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				if (this.rdoDay.Checked)
				{
					sQuery = "EXEC CIMitar_Factory.dbo.USP_Admin_Summary_CarrierDaily @enddate  = '" + t.AddDays(1.0).ToString("yyyy-MM-dd") + "'";
					this.queryMgr.queryCall(sQuery);
				}
				sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].USP_Admin_GetSummary_CarrierDaily @startdate  = '",
					dateTime.ToString("yyyy-MM-dd"),
					"', @enddate  = '",
					t.ToString("yyyy-MM-dd"),
					"', @product  = '",
					this.cmbProduct.Text,
					"', @type  = 'DeviceUtil'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					TimeSpan timeSpan = t.Subtract(dateTime);
					this._barPrograss.setMax(timeSpan.Days + 1);
					DateTime t2 = dateTime;
					while (t2 <= t)
					{
						try
						{
							CCarrierData ccarrierData = new CCarrierData();
							foreach (object obj in this._slCarrierType)
							{
								CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj).Value;
								ccarrierData.slTypeCount.Add(ccarrierType.strTypeValue, 0);
							}
							string text = t2.ToString("yyyy-MM-dd");
							string filterExpression = "date = '" + text + "'";
							DataRow[] array = dataSet.Tables[0].Select(filterExpression);
							if (array.Length > 0)
							{
								for (int i = 0; i < array.Length; i++)
								{
									CCarrierUtilData ccarrierUtilData = new CCarrierUtilData();
									ccarrierUtilData.Name = array[i]["device"].ToString();
									ccarrierUtilData.LoadTesterCnt = (int)array[i]["loadtestercnt"];
									ccarrierUtilData.LoadCarrierCnt = (int)array[i]["loadcarriercnt"];
									ccarrierUtilData.MaxCarrierCnt = (int)array[i]["maxcarriercnt"];
									ccarrierUtilData.BinQty = (int)array[i]["binqty"];
									ccarrierUtilData.Util = (double)array[i]["util"];
									ccarrierData.slCarrierDevice.Add(array[i]["device"].ToString(), ccarrierUtilData);
								}
							}
							else
							{
								for (int j = 0; j < ccarrierData.slTypeCount.Count; j++)
								{
									CCarrierUtilData ccarrierUtilData2 = new CCarrierUtilData();
									ccarrierUtilData2.Name = ccarrierData.slTypeCount.GetKey(j).ToString();
									ccarrierData.slCarrierDevice.Add(ccarrierUtilData2.Name, ccarrierUtilData2);
								}
							}
							this._slAllData.Add(text, ccarrierData);
							this._barPrograss.setValue(num++);
						}
						catch (Exception ex)
						{
							ex.ToString();
						}
						t2 = t2.AddDays(1.0);
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex2)
			{
				ex2.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00012C00 File Offset: 0x00010E00
		private void GetCarrierUtil_Tester()
		{
			try
			{
				this._slAllData.Clear();
				this._slCarrierType.Clear();
				int num = 1;
				string sQuery = string.Empty;
				DateTime dateTime = default(DateTime);
				DateTime t = default(DateTime);
				if (this.rdoDay.Checked)
				{
					dateTime = DateTime.Now;
					t = DateTime.Now;
				}
				else if (this.rdoWeek.Checked)
				{
					dateTime = DateTime.Now.AddDays(-7.0);
					t = DateTime.Now.AddDays(-1.0);
				}
				else if (this.rdoMonth.Checked)
				{
					dateTime = DateTime.Now.AddDays(-30.0);
					t = DateTime.Now.AddDays(-1.0);
				}
				else if (this.rdoPeriod.Checked)
				{
					dateTime = this.dtp_Start.Value;
					t = this.dtp_End.Value;
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				t = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				if (this.rdoDay.Checked)
				{
					sQuery = "EXEC CIMitar_Factory.dbo.USP_Admin_Summary_CarrierDaily @enddate  = '" + t.AddDays(1.0).ToString("yyyy-MM-dd") + "'";
					this.queryMgr.queryCall(sQuery);
				}
				sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTesterList]";
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].USP_Admin_GetSummary_CarrierDaily @startdate  = '",
					dateTime.ToString("yyyy-MM-dd"),
					"', @enddate  = '",
					t.ToString("yyyy-MM-dd"),
					"', @product  = '",
					this.cmbProduct.Text,
					"', @type  = 'TesterUtil'"
				});
				DataSet dataSet2 = this.queryMgr.queryCall(sQuery);
				if (dataSet2.Tables.Count > 0)
				{
					TimeSpan timeSpan = t.Subtract(dateTime);
					this._barPrograss.setMax(timeSpan.Days + 1);
					if (this.cmbProduct.Text == string.Empty)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							CCarrierType ccarrierType = new CCarrierType();
							ccarrierType.strTypeValue = dataSet.Tables[0].Rows[i][0].ToString();
							this._slCarrierType.Add(i + 1, ccarrierType);
						}
					}
					else
					{
						DataTable dataTable = dataSet2.Tables[0].DefaultView.ToTable(true, new string[]
						{
							"Tester"
						});
						for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
						{
							for (int k = 0; k < dataTable.Rows.Count; k++)
							{
								if (dataSet.Tables[0].Rows[j][0].ToString() == dataTable.Rows[k][0].ToString())
								{
									CCarrierType ccarrierType2 = new CCarrierType();
									ccarrierType2.strTypeValue = dataSet.Tables[0].Rows[j][0].ToString();
									this._slCarrierType.Add(j + 1, ccarrierType2);
									break;
								}
							}
						}
					}
					DateTime t2 = dateTime;
					while (t2 <= t)
					{
						try
						{
							CCarrierData ccarrierData = new CCarrierData();
							foreach (object obj in this._slCarrierType)
							{
								CCarrierType ccarrierType3 = (CCarrierType)((DictionaryEntry)obj).Value;
								ccarrierData.slTypeCount.Add(ccarrierType3.strTypeValue, 0);
							}
							string text = t2.ToString("yyyy-MM-dd");
							string filterExpression = "date = '" + text + "'";
							DataRow[] array = dataSet2.Tables[0].Select(filterExpression);
							if (array.Length > 0)
							{
								for (int l = 0; l < ccarrierData.slTypeCount.Count; l++)
								{
									CCarrierUtilData ccarrierUtilData = new CCarrierUtilData();
									ccarrierUtilData.Name = ccarrierData.slTypeCount.GetKey(l).ToString();
									ccarrierData.slCarrierTester.Add(ccarrierUtilData.Name, ccarrierUtilData);
									for (int m = 0; m < array.Length; m++)
									{
										if (array[m]["tester"].ToString() == ccarrierUtilData.Name)
										{
											ccarrierUtilData.Name = array[m]["tester"].ToString();
											ccarrierUtilData.Device = array[m]["device"].ToString();
											ccarrierUtilData.LoadCarrierCnt = Convert.ToInt32(array[m]["loadcarriercnt"].ToString());
											ccarrierUtilData.MaxCarrierCnt = Convert.ToInt32(array[m]["maxcarriercnt"].ToString());
											ccarrierUtilData.BinQty = Convert.ToInt32(array[m]["binqty"].ToString());
											ccarrierUtilData.Util = Convert.ToDouble(array[m]["util"].ToString());
											break;
										}
									}
								}
							}
							else
							{
								for (int n = 0; n < ccarrierData.slTypeCount.Count; n++)
								{
									CCarrierUtilData ccarrierUtilData2 = new CCarrierUtilData();
									ccarrierUtilData2.Name = ccarrierData.slTypeCount.GetKey(n).ToString();
									ccarrierData.slCarrierTester.Add(ccarrierUtilData2.Name, ccarrierUtilData2);
								}
							}
							this._slAllData.Add(text, ccarrierData);
							this._barPrograss.setValue(num++);
						}
						catch (Exception ex)
						{
							ex.ToString();
						}
						t2 = t2.AddDays(1.0);
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex2)
			{
				ex2.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00013384 File Offset: 0x00011584
		private void GetBlacklistTrend()
		{
			try
			{
				this._slAllData.Clear();
				int num = 1;
				string sQuery = string.Empty;
				DateTime dateTime = default(DateTime);
				DateTime t = default(DateTime);
				if (this.rdoDay.Checked)
				{
					dateTime = DateTime.Now;
					t = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoWeek.Checked)
				{
					dateTime = DateTime.Now.AddDays(-6.0);
					t = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoMonth.Checked)
				{
					dateTime = DateTime.Now.AddDays(-30.0);
					t = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoPeriod.Checked)
				{
					dateTime = this.dtp_Start.Value;
					t = this.dtp_End.Value.AddDays(1.0);
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				t = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].USP_Admin_GetSummary_CarrierDaily @startdate  = '",
					dateTime.ToString("yyyy-MM-dd"),
					"', @enddate  = '",
					t.ToString("yyyy-MM-dd"),
					"', @product  = '",
					this.cmbProduct.Text,
					"', @type  = 'BlacklistTrend'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					TimeSpan timeSpan = t.Subtract(dateTime);
					this._barPrograss.setMax(timeSpan.Days + 1);
					DateTime t2 = dateTime;
					while (t2 < t)
					{
						try
						{
							CCarrierData ccarrierData = new CCarrierData();
							foreach (object obj in this._slCarrierType)
							{
								CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj).Value;
								ccarrierData.slTypeCount.Add(ccarrierType.strTypeValue, 0);
							}
							string text = t2.ToString("yyyy-MM-dd");
							string filterExpression = "date = '" + text + "' and status = 'Blacklisted'";
							DataRow[] array = dataSet.Tables[0].Select(filterExpression);
							if (array.Length > 0)
							{
								for (int i = 0; i < ccarrierData.slTypeCount.Count; i++)
								{
									CCarrierFailModeData ccarrierFailModeData = new CCarrierFailModeData();
									ccarrierFailModeData.Name = ccarrierData.slTypeCount.GetKey(i).ToString();
									for (int j = 0; j < array.Length; j++)
									{
										if (array[j]["result"].ToString() == ccarrierFailModeData.Name)
										{
											ccarrierFailModeData.Count++;
										}
									}
									ccarrierData.slCarrierFailMode.Add(ccarrierFailModeData.Name, ccarrierFailModeData);
								}
							}
							else
							{
								for (int k = 0; k < ccarrierData.slTypeCount.Count; k++)
								{
									CCarrierFailModeData ccarrierFailModeData2 = new CCarrierFailModeData();
									ccarrierFailModeData2.Name = ccarrierData.slTypeCount.GetKey(k).ToString();
									ccarrierData.slCarrierFailMode.Add(ccarrierFailModeData2.Name, ccarrierFailModeData2);
								}
							}
							this._slAllData.Add(text, ccarrierData);
							this._barPrograss.setValue(num++);
						}
						catch (Exception ex)
						{
							ex.ToString();
						}
						t2 = t2.AddDays(1.0);
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex2)
			{
				ex2.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00013884 File Offset: 0x00011A84
		private void GetSlotBlacklistTrend()
		{
			try
			{
				this._slAllData.Clear();
				int num = 1;
				string sQuery = string.Empty;
				DateTime dateTime = default(DateTime);
				DateTime t = default(DateTime);
				if (this.rdoDay.Checked)
				{
					dateTime = DateTime.Now;
					t = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoWeek.Checked)
				{
					dateTime = DateTime.Now.AddDays(-6.0);
					t = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoMonth.Checked)
				{
					dateTime = DateTime.Now.AddDays(-30.0);
					t = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoPeriod.Checked)
				{
					dateTime = this.dtp_Start.Value;
					t = this.dtp_End.Value.AddDays(1.0);
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				t = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].USP_Admin_GetSummary_SlotDaily @startdate  = '",
					dateTime.ToString("yyyy-MM-dd"),
					"', @enddate  = '",
					t.ToString("yyyy-MM-dd"),
					"'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					TimeSpan timeSpan = t.Subtract(dateTime);
					this._barPrograss.setMax(timeSpan.Days + 1);
					DateTime t2 = dateTime;
					while (t2 < t)
					{
						try
						{
							CSlotData cslotData = new CSlotData();
							foreach (object obj in this._slSlotType)
							{
								CSlotType cslotType = (CSlotType)((DictionaryEntry)obj).Value;
								cslotData.slTypeCount.Add(cslotType.strTypeValue, 0);
							}
							string text = t2.ToString("yyyy-MM-dd");
							string filterExpression = "date = '" + text + "'";
							DataRow[] array = dataSet.Tables[0].Select(filterExpression);
							if (array.Length > 0)
							{
								for (int i = 0; i < cslotData.slTypeCount.Count; i++)
								{
									CSlotBlackListData cslotBlackListData = new CSlotBlackListData();
									cslotBlackListData.Name = cslotData.slTypeCount.GetKey(i).ToString();
									for (int j = 0; j < array.Length; j++)
									{
										if (array[j]["result"].ToString() == cslotBlackListData.Name)
										{
											cslotBlackListData.Count++;
										}
									}
									cslotData.slSlotBlackListMode.Add(cslotBlackListData.Name, cslotBlackListData);
								}
							}
							else
							{
								for (int k = 0; k < cslotData.slTypeCount.Count; k++)
								{
									CSlotBlackListData cslotBlackListData2 = new CSlotBlackListData();
									cslotBlackListData2.Name = cslotData.slTypeCount.GetKey(k).ToString();
									cslotData.slSlotBlackListMode.Add(cslotBlackListData2.Name, cslotBlackListData2);
								}
							}
							this._slAllData.Add(text, cslotData);
							this._barPrograss.setValue(num++);
						}
						catch (Exception ex)
						{
							ex.ToString();
						}
						t2 = t2.AddDays(1.0);
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex2)
			{
				ex2.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00013D6C File Offset: 0x00011F6C
		private void GetBlacklistFailCount()
		{
			try
			{
				this._slCarrierType.Clear();
				this._slAllData.Clear();
				int num = 1;
				string sQuery = string.Empty;
				DateTime dateTime = default(DateTime);
				DateTime t = default(DateTime);
				if (this.rdoDay.Checked)
				{
					dateTime = DateTime.Now;
					t = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoWeek.Checked)
				{
					dateTime = DateTime.Now.AddDays(-6.0);
					t = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoMonth.Checked)
				{
					dateTime = DateTime.Now.AddDays(-30.0);
					t = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoPeriod.Checked)
				{
					dateTime = this.dtp_Start.Value;
					t = this.dtp_End.Value.AddDays(1.0);
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				t = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				TimeSpan timeSpan = t.Subtract(dateTime);
				this._barPrograss.setMax(timeSpan.Days);
				DateTime t2 = dateTime;
				while (t2 < t)
				{
					string text = t2.ToString("yyyy-MM-dd");
					string text2 = t2.AddDays(1.0).ToString("yyyy-MM-dd");
					sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].USP_Admin_GetSummary_CarrierDaily @startdate  = '",
						text,
						"', @enddate  = '",
						text2,
						"', @product  = '",
						this.cmbProduct.Text,
						"', @type  = 'FailCount', @failmode  = '",
						this.cmbFailMode.Text,
						"'"
					});
					DataSet dataSet = this.queryMgr.queryCall(sQuery);
					if (dataSet.Tables.Count > 0)
					{
						CCarrierFailModeData ccarrierFailModeData = new CCarrierFailModeData();
						CCarrierFailModeData ccarrierFailModeData2 = new CCarrierFailModeData();
						string a = string.Empty;
						string text3 = string.Empty;
						string text4 = string.Empty;
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							string text5 = dataSet.Tables[0].Rows[i]["carrierid"].ToString();
							string a2 = dataSet.Tables[0].Rows[i]["status"].ToString();
							dataSet.Tables[0].Rows[i]["result"].ToString();
							if (a != text5)
							{
								a = text5;
								ccarrierFailModeData = new CCarrierFailModeData();
								text3 = string.Empty;
								text4 = string.Empty;
							}
							if (a2 == "BlackListed")
							{
								text3 = dataSet.Tables[0].Rows[i]["site1_fail"].ToString();
								text4 = dataSet.Tables[0].Rows[i]["site2_fail"].ToString();
								if (text3 != string.Empty)
								{
									if (this._slAllData.ContainsKey(text3))
									{
										ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text3];
										ccarrierFailModeData.Count++;
									}
									else
									{
										ccarrierFailModeData = new CCarrierFailModeData();
										ccarrierFailModeData.Name = text3;
										ccarrierFailModeData.Count++;
										this._slAllData.Add(text3, ccarrierFailModeData);
									}
								}
								if (text4 != string.Empty)
								{
									if (this._slAllData.ContainsKey(text4))
									{
										ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text4];
										ccarrierFailModeData.Count++;
									}
									else
									{
										ccarrierFailModeData = new CCarrierFailModeData();
										ccarrierFailModeData.Name = text4;
										ccarrierFailModeData.Count++;
										this._slAllData.Add(text4, ccarrierFailModeData);
									}
								}
							}
							else if (a2 == "RepairEnd" || a2 == "Clean")
							{
								string text6 = string.Empty;
								string text7 = string.Empty;
								if (a2 == "Clean")
								{
									text6 = "Laser Cleaning";
									text7 = "Laser Cleaning";
								}
								else
								{
									text6 = dataSet.Tables[0].Rows[i]["site1"].ToString();
									text7 = dataSet.Tables[0].Rows[i]["site2"].ToString();
								}
								if (this._slAllData.ContainsKey(text3))
								{
									ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text3];
									if (text6 != string.Empty)
									{
										string[] array = text6.Split(new char[]
										{
											','
										});
										for (int j = 0; j < array.Length; j++)
										{
											if (ccarrierFailModeData.slActionList.ContainsKey(array[j].Trim()))
											{
												ccarrierFailModeData2 = (CCarrierFailModeData)ccarrierFailModeData.slActionList[array[j].Trim()];
												ccarrierFailModeData2.Count++;
											}
											else
											{
												ccarrierFailModeData2 = new CCarrierFailModeData();
												ccarrierFailModeData2.Name = array[j].Trim();
												ccarrierFailModeData2.Count++;
												ccarrierFailModeData.slActionList.Add(ccarrierFailModeData2.Name, ccarrierFailModeData2);
											}
										}
									}
								}
								if (this._slAllData.ContainsKey(text4))
								{
									ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text4];
									if (text7 != string.Empty)
									{
										string[] array2 = text7.Split(new char[]
										{
											','
										});
										for (int k = 0; k < array2.Length; k++)
										{
											if (ccarrierFailModeData.slActionList.ContainsKey(array2[k].Trim()))
											{
												ccarrierFailModeData2 = (CCarrierFailModeData)ccarrierFailModeData.slActionList[array2[k].Trim()];
												ccarrierFailModeData2.Count++;
											}
											else
											{
												ccarrierFailModeData2 = new CCarrierFailModeData();
												ccarrierFailModeData2.Name = array2[k].Trim();
												ccarrierFailModeData2.Count++;
												ccarrierFailModeData.slActionList.Add(ccarrierFailModeData2.Name, ccarrierFailModeData2);
											}
										}
									}
								}
							}
						}
						this._barPrograss.setValue(num++);
					}
					t2 = t2.AddDays(1.0);
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00014574 File Offset: 0x00012774
		private void FailCount()
		{
			try
			{
				this._slCarrierType.Clear();
				this._slAllData.Clear();
				int num = 1;
				string sQuery = string.Empty;
				DateTime dateTime = default(DateTime);
				DateTime dateTime2 = default(DateTime);
				if (this.rdoDay.Checked)
				{
					dateTime = DateTime.Now;
					dateTime2 = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoWeek.Checked)
				{
					dateTime = DateTime.Now.AddDays(-6.0);
					dateTime2 = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoMonth.Checked)
				{
					dateTime = DateTime.Now.AddDays(-30.0);
					dateTime2 = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoPeriod.Checked)
				{
					dateTime = this.dtp_Start.Value;
					dateTime2 = this.dtp_End.Value.AddDays(1.0);
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				dateTime2 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].USP_Admin_GetSummary_CarrierDaily @startdate  = '",
					dateTime.ToString("yyyy-MM-dd"),
					"', @enddate  = '",
					dateTime2.ToString("yyyy-MM-dd"),
					"', @product  = '",
					this.cmbProduct.Text,
					"', @type  = 'FailCount', @failmode  = '",
					this.cmbFailMode.Text,
					"'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					CCarrierFailModeData ccarrierFailModeData = new CCarrierFailModeData();
					CCarrierFailModeData ccarrierFailModeData2 = new CCarrierFailModeData();
					string a = string.Empty;
					string text = string.Empty;
					string text2 = string.Empty;
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						try
						{
							string text3 = dataSet.Tables[0].Rows[i]["carrierid"].ToString();
							string a2 = dataSet.Tables[0].Rows[i]["status"].ToString();
							dataSet.Tables[0].Rows[i]["result"].ToString();
							if (a != text3)
							{
								a = text3;
								ccarrierFailModeData = new CCarrierFailModeData();
								text = string.Empty;
								text2 = string.Empty;
							}
							if (a2 == "RepairStart")
							{
								text = dataSet.Tables[0].Rows[i]["site1"].ToString();
								text2 = dataSet.Tables[0].Rows[i]["site2"].ToString();
								if (text != string.Empty)
								{
									if (this._slAllData.ContainsKey(text))
									{
										ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text];
										ccarrierFailModeData.Count++;
									}
									else
									{
										ccarrierFailModeData = new CCarrierFailModeData();
										ccarrierFailModeData.Name = text;
										ccarrierFailModeData.Count++;
										this._slAllData.Add(text, ccarrierFailModeData);
									}
								}
								if (text2 != string.Empty)
								{
									if (this._slAllData.ContainsKey(text2))
									{
										ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text2];
										ccarrierFailModeData.Count++;
									}
									else
									{
										ccarrierFailModeData = new CCarrierFailModeData();
										ccarrierFailModeData.Name = text2;
										ccarrierFailModeData.Count++;
										this._slAllData.Add(text2, ccarrierFailModeData);
									}
								}
							}
							else if (a2 == "RepairEnd")
							{
								string text4 = dataSet.Tables[0].Rows[i]["site1"].ToString();
								string text5 = dataSet.Tables[0].Rows[i]["site2"].ToString();
								if (this._slAllData.ContainsKey(text))
								{
									ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text];
									if (text4 != string.Empty)
									{
										string[] array = text4.Split(new char[]
										{
											','
										});
										for (int j = 0; j < array.Length; j++)
										{
											if (ccarrierFailModeData.slActionList.ContainsKey(array[j].Trim()))
											{
												ccarrierFailModeData2 = (CCarrierFailModeData)ccarrierFailModeData.slActionList[array[j].Trim()];
												ccarrierFailModeData2.Count++;
											}
											else
											{
												ccarrierFailModeData2 = new CCarrierFailModeData();
												ccarrierFailModeData2.Name = array[j].Trim();
												ccarrierFailModeData2.Count++;
												ccarrierFailModeData.slActionList.Add(ccarrierFailModeData2.Name, ccarrierFailModeData2);
											}
										}
									}
								}
								if (this._slAllData.ContainsKey(text2))
								{
									ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text2];
									if (text5 != string.Empty)
									{
										string[] array2 = text5.Split(new char[]
										{
											','
										});
										for (int k = 0; k < array2.Length; k++)
										{
											if (ccarrierFailModeData.slActionList.ContainsKey(array2[k].Trim()))
											{
												ccarrierFailModeData2 = (CCarrierFailModeData)ccarrierFailModeData.slActionList[array2[k].Trim()];
												ccarrierFailModeData2.Count++;
											}
											else
											{
												ccarrierFailModeData2 = new CCarrierFailModeData();
												ccarrierFailModeData2.Name = array2[k].Trim();
												ccarrierFailModeData2.Count++;
												ccarrierFailModeData.slActionList.Add(ccarrierFailModeData2.Name, ccarrierFailModeData2);
											}
										}
									}
								}
							}
							this._barPrograss.setValue(num++);
						}
						catch (Exception ex)
						{
							ex.ToString();
						}
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex2)
			{
				ex2.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00014D2C File Offset: 0x00012F2C
		private void GetBlacklistActionCount()
		{
			try
			{
				this._slCarrierType.Clear();
				this._slAllData.Clear();
				int num = 1;
				string sQuery = string.Empty;
				DateTime dateTime = default(DateTime);
				DateTime dateTime2 = default(DateTime);
				if (this.rdoDay.Checked)
				{
					dateTime = DateTime.Now;
					dateTime2 = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoWeek.Checked)
				{
					dateTime = DateTime.Now.AddDays(-6.0);
					dateTime2 = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoMonth.Checked)
				{
					dateTime = DateTime.Now.AddDays(-30.0);
					dateTime2 = DateTime.Now.AddDays(1.0);
				}
				else if (this.rdoPeriod.Checked)
				{
					dateTime = this.dtp_Start.Value;
					dateTime2 = this.dtp_End.Value.AddDays(1.0);
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				dateTime2 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].USP_Admin_GetSummary_CarrierDaily @startdate  = '",
					dateTime.ToString("yyyy-MM-dd"),
					"', @enddate  = '",
					dateTime2.ToString("yyyy-MM-dd"),
					"', @product  = '",
					this.cmbProduct.Text,
					"', @type  = 'BlacklistTrend'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					CCarrierFailModeData ccarrierFailModeData = new CCarrierFailModeData();
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						try
						{
							string a = dataSet.Tables[0].Rows[i]["status"].ToString();
							if (a == "RepairEnd" || a == "Clean")
							{
								string text = string.Empty;
								string text2 = string.Empty;
								if (a == "Clean")
								{
									text = "Laser Cleaning";
									text2 = "Laser Cleaning";
								}
								else
								{
									text = dataSet.Tables[0].Rows[i]["site1"].ToString();
									text2 = dataSet.Tables[0].Rows[i]["site2"].ToString();
								}
								if (text != string.Empty)
								{
									string[] array = text.Split(new char[]
									{
										','
									});
									for (int j = 0; j < array.Length; j++)
									{
										if (this._slAllData.ContainsKey(array[j].Trim()))
										{
											ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[array[j].Trim()];
											ccarrierFailModeData.Count++;
										}
										else
										{
											ccarrierFailModeData = new CCarrierFailModeData();
											ccarrierFailModeData.Name = array[j].Trim();
											ccarrierFailModeData.Count++;
											this._slAllData.Add(ccarrierFailModeData.Name, ccarrierFailModeData);
										}
									}
									if (text == text2)
									{
										goto IL_4C9;
									}
								}
								if (text2 != string.Empty)
								{
									string[] array2 = text2.Split(new char[]
									{
										','
									});
									for (int k = 0; k < array2.Length; k++)
									{
										if (this._slAllData.ContainsKey(array2[k].Trim()))
										{
											ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[array2[k].Trim()];
											ccarrierFailModeData.Count++;
										}
										else
										{
											ccarrierFailModeData = new CCarrierFailModeData();
											ccarrierFailModeData.Name = array2[k].Trim();
											ccarrierFailModeData.Count++;
											this._slAllData.Add(ccarrierFailModeData.Name, ccarrierFailModeData);
										}
									}
								}
							}
							this._barPrograss.setValue(num++);
						}
						catch (Exception ex)
						{
							ex.ToString();
						}
						IL_4C9:;
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex2)
			{
				ex2.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000152E0 File Offset: 0x000134E0
		private void GetTopFailCount()
		{
			try
			{
				this._slAllData.Clear();
				int num = 1;
				string sQuery = string.Empty;
				DateTime dateTime = default(DateTime);
				DateTime t = default(DateTime);
				if (this.rdoDay.Checked)
				{
					dateTime = DateTime.Now.AddDays(-1.0);
					t = DateTime.Now.AddDays(-1.0);
				}
				else if (this.rdoWeek.Checked)
				{
					dateTime = DateTime.Now.AddDays(-7.0);
					t = DateTime.Now.AddDays(-1.0);
				}
				else if (this.rdoMonth.Checked)
				{
					dateTime = DateTime.Now.AddDays(-30.0);
					t = DateTime.Now.AddDays(-1.0);
				}
				else if (this.rdoPeriod.Checked)
				{
					dateTime = this.dtp_Start.Value;
					t = this.dtp_End.Value.AddDays(1.0);
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				t = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				TimeSpan timeSpan = t.Subtract(dateTime);
				this._barPrograss.setMax(timeSpan.Days + 1);
				CCarrierFailModeData ccarrierFailModeData = new CCarrierFailModeData();
				CCarrierFailModeData ccarrierFailModeData2 = new CCarrierFailModeData();
				DateTime t2 = dateTime;
				while (t2 <= t)
				{
					new CCarrierData();
					string text = t2.ToString("yyyy-MM-dd");
					string text2 = t2.ToString("yyyy-MM-dd");
					sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierTop10Fail] @startdate  = '",
						text,
						"', @enddate  = '",
						text2,
						"', @product  = '",
						this.cmbProduct.Text,
						"'"
					});
					DataSet dataSet = this.queryMgr.queryCall(sQuery);
					if (dataSet.Tables.Count > 0)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							string text3 = dataSet.Tables[0].Rows[i]["failname"].ToString();
							string text4 = dataSet.Tables[0].Rows[i]["carrier"].ToString();
							string str = dataSet.Tables[0].Rows[i]["site"].ToString();
							text4 = text4 + " : " + str;
							if (this._slAllData.ContainsKey(text3))
							{
								ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text3];
								ccarrierFailModeData.Count++;
							}
							else
							{
								ccarrierFailModeData = new CCarrierFailModeData();
								ccarrierFailModeData.Name = text3;
								ccarrierFailModeData.Count = 1;
								this._slAllData.Add(ccarrierFailModeData.Name, ccarrierFailModeData);
							}
							if (ccarrierFailModeData.slActionList.ContainsKey(text4))
							{
								ccarrierFailModeData2 = (CCarrierFailModeData)ccarrierFailModeData.slActionList[text4];
								ccarrierFailModeData2.Count++;
							}
							else
							{
								ccarrierFailModeData2 = new CCarrierFailModeData();
								ccarrierFailModeData2.Name = text4;
								ccarrierFailModeData2.Count = 1;
								ccarrierFailModeData.slActionList.Add(ccarrierFailModeData2.Name, ccarrierFailModeData2);
							}
						}
					}
					this._barPrograss.setValue(num++);
					t2 = t2.AddDays(1.0);
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000157A4 File Offset: 0x000139A4
		private void gridInventoryList_DoubleClick(object sender, EventArgs e)
		{
			if ((this.cmbInventoryType.Text == "BlacklistTrend" && this.cmbFailMode.Text != "Trend") || this.cmbInventoryType.Text == "TopFailCount")
			{
				int row = this.gridInventoryList.Selection.ActivePosition.Row;
				if (row > 0)
				{
					string text = string.Empty;
					string text2 = this.gridInventoryList[row, 1].ToString();
					if (this.cmbInventoryType.Text == "TopFailCount")
					{
						text = "Fail Carrier List";
					}
					else
					{
						text = "Action";
					}
					DateTime dateTime = default(DateTime);
					DateTime dateTime2 = default(DateTime);
					if (this.rdoDay.Checked)
					{
						dateTime = DateTime.Now.AddDays(-1.0);
						dateTime2 = DateTime.Now.AddDays(-1.0);
					}
					else if (this.rdoWeek.Checked)
					{
						dateTime = DateTime.Now.AddDays(-7.0);
						dateTime2 = DateTime.Now.AddDays(-1.0);
					}
					else if (this.rdoMonth.Checked)
					{
						dateTime = DateTime.Now.AddDays(-30.0);
						dateTime2 = DateTime.Now.AddDays(-1.0);
					}
					else if (this.rdoPeriod.Checked)
					{
						dateTime = this.dtp_Start.Value;
						dateTime2 = this.dtp_End.Value.AddDays(1.0);
					}
					string sStartDate = dateTime.ToString("yyyy-MM-dd");
					string sEndDate = dateTime2.ToString("yyyy-MM-dd");
					if (this._slAllData.ContainsKey(text2))
					{
						CCarrierFailModeData ccarrierFailModeData = (CCarrierFailModeData)this._slAllData[text2];
						if (ccarrierFailModeData.slActionList.Count > 0)
						{
							ArrayList arrDataList = this.orderByFailList(ccarrierFailModeData.slActionList, 100);
							new DetailAction
							{
								_factorySetting = this._factorySetting,
								_cimitarUser = this._cimitarUser,
								sFailName = text2,
								sType = this.cmbInventoryType.Text,
								sStartDate = sStartDate,
								sEndDate = sEndDate,
								Caption = text,
								Text = text,
								arrDataList = arrDataList
							}.ShowDialog();
							return;
						}
						MessageBox.Show("Action is not exist.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00015A48 File Offset: 0x00013C48
		private void getWeeklyReport(string sType)
		{
			if (sType == "Total")
			{
				int num = 1;
				bool flag = true;
				using (IDictionaryEnumerator enumerator = this._slAllData.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
						string cellValue = dictionaryEntry.Key.ToString();
						SortedList sortedList = (SortedList)dictionaryEntry.Value;
						int col = 2;
						this.gridWeeklyReport.Rows.Insert(num);
						this.gridWeeklyReport.Rows.Insert(num + 1);
						this.gridWeeklyReport.Rows.Insert(num + 2);
						this.gridWeeklyReport[num, 0] = new SourceGrid.Cells.Cell(cellValue);
						this.gridWeeklyReport[num, 0].RowSpan = 3;
						this.gridWeeklyReport[num, 0].View = this.gridInfo.CellColor.cell_gray_center;
						this.gridWeeklyReport[num, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridWeeklyReport[num++, 1] = new SourceGrid.Cells.Cell("On-hand Carrier\r\n(Functional + Non-Functional)");
						this.gridWeeklyReport[num++, 1] = new SourceGrid.Cells.Cell("Functional Carrier");
						this.gridWeeklyReport[num, 1] = new SourceGrid.Cells.Cell("Non-Functional\r\n(including Verification)");
						foreach (object obj2 in sortedList)
						{
							DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
							dictionaryEntry2.Key.ToString();
							CWeeklyReportResult cweeklyReportResult = (CWeeklyReportResult)dictionaryEntry2.Value;
							this.gridWeeklyReport[num - 2, col] = new SourceGrid.Cells.Cell(cweeklyReportResult.onhand.ToString());
							this.gridWeeklyReport[num - 2, col].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridWeeklyReport[num - 1, col] = new SourceGrid.Cells.Cell(cweeklyReportResult.func.ToString());
							this.gridWeeklyReport[num - 1, col].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridWeeklyReport[num, col] = new SourceGrid.Cells.Cell(cweeklyReportResult.nonfunc.ToString());
							this.gridWeeklyReport[num, col++].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						}
						if (flag)
						{
							flag = false;
						}
						num++;
					}
					return;
				}
			}
			if (sType == "SIBCount")
			{
				int num2 = 1;
				using (IDictionaryEnumerator enumerator3 = this._slAllData.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						object obj3 = enumerator3.Current;
						DictionaryEntry dictionaryEntry3 = (DictionaryEntry)obj3;
						string cellValue2 = dictionaryEntry3.Key.ToString();
						this.gridWeeklyReport.Rows.Insert(num2);
						CWeeklyReportResult cweeklyReportResult2 = (CWeeklyReportResult)dictionaryEntry3.Value;
						this.gridWeeklyReport[num2, 0] = new SourceGrid.Cells.Cell(cellValue2);
						this.gridWeeklyReport[num2, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridWeeklyReport[num2, 1] = new SourceGrid.Cells.Cell("0");
						this.gridWeeklyReport[num2, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridWeeklyReport[num2, 2] = new SourceGrid.Cells.Cell(cweeklyReportResult2.sAccumedCnt);
						this.gridWeeklyReport[num2, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridWeeklyReport[num2, 3] = new SourceGrid.Cells.Cell(cweeklyReportResult2.sReturnCnt);
						this.gridWeeklyReport[num2, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridWeeklyReport[num2, 4] = new SourceGrid.Cells.Cell(cweeklyReportResult2.sDayDefectCnt);
						this.gridWeeklyReport[num2, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						num2++;
					}
					return;
				}
			}
			if (sType == "SIBFail")
			{
				int num3 = 1;
				foreach (object obj4 in this._slAllData)
				{
					CWeeklyReportResult cweeklyReportResult3 = (CWeeklyReportResult)((DictionaryEntry)obj4).Value;
					this.gridWeeklyReport.Rows.Insert(num3);
					this.gridWeeklyReport[num3, 0] = new SourceGrid.Cells.Cell(cweeklyReportResult3.sCheckDate);
					this.gridWeeklyReport[num3, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridWeeklyReport[num3, 1] = new SourceGrid.Cells.Cell(cweeklyReportResult3.sSIB);
					this.gridWeeklyReport[num3, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridWeeklyReport[num3, 2] = new SourceGrid.Cells.Cell(cweeklyReportResult3.sRev);
					this.gridWeeklyReport[num3, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridWeeklyReport[num3, 3] = new SourceGrid.Cells.Cell(cweeklyReportResult3.sFailName);
					this.gridWeeklyReport[num3, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridWeeklyReport[num3, 4] = new SourceGrid.Cells.Cell(cweeklyReportResult3.sDamage);
					this.gridWeeklyReport[num3, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					num3++;
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0001603C File Offset: 0x0001423C
		private void setATPList()
		{
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00016040 File Offset: 0x00014240
		private void SetATPReport()
		{
			DataSet dataSet = new DataSet();
			this.cmbProduct3.Text.Trim();
			this._slAllData.Clear();
			this._slAllData2.Clear();
			DateTime dateTime = new DateTime(this.dptATPstart.Value.Year, this.dptATPstart.Value.Month, this.dptATPstart.Value.Day, 0, 0, 0);
			DateTime dateTime2 = new DateTime(this.dptATPend.Value.Year, this.dptATPend.Value.Month, this.dptATPend.Value.Day, 0, 0, 0);
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_GetATPList] @hostname  = '",
				this.cmbATPhostname.Text,
				"',@atpname  = '",
				this.cmbATPname.Text,
				"',@product  = '",
				this.cmbATPproduct.Text,
				"',@startdate  = '",
				dateTime.ToString("yyyy-MM-dd"),
				"',@enddate  = '",
				dateTime2.ToString("yyyy-MM-dd"),
				"'"
			});
			dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet.Tables.Count > 1)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					CATPList catplist = new CATPList();
					catplist.hostname = dataSet.Tables[0].Rows[i]["hostname"].ToString();
					catplist.ATPname = dataSet.Tables[0].Rows[i]["ATPname"].ToString();
					catplist.device = dataSet.Tables[0].Rows[i]["device"].ToString();
					catplist.hbin = dataSet.Tables[0].Rows[i]["hbin"].ToString();
					catplist.hbinname = dataSet.Tables[0].Rows[i]["hbinname"].ToString();
					catplist.sbin = dataSet.Tables[0].Rows[i]["sbin"].ToString();
					catplist.sbinname = dataSet.Tables[0].Rows[i]["sbinname"].ToString();
					catplist.startdate = dataSet.Tables[0].Rows[i]["startdate"].ToString();
					catplist.enddate = dataSet.Tables[0].Rows[i]["enddate"].ToString();
					this._slAllData.Add(i, catplist);
				}
				for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
				{
					this.gridATPsummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					this.gridATPsummary.ColumnsCount = 9;
					this.gridATPsummary.RowsCount = 1;
					this.gridATPsummary.Rows.Insert(1);
					this.gridATPsummary[0, 0] = new GridInfo.ColHeader("INQTY", false);
					this.gridATPsummary[0, 1] = new GridInfo.ColHeader("PASS", false);
					this.gridATPsummary[0, 2] = new GridInfo.ColHeader("FAIL", false);
					this.gridATPsummary[0, 3] = new GridInfo.ColHeader("PASSYIELD", false);
					this.gridATPsummary[0, 4] = new GridInfo.ColHeader("FAILYIELD", false);
					this.gridATPsummary[0, 5] = new GridInfo.ColHeader("A", false);
					this.gridATPsummary[0, 6] = new GridInfo.ColHeader("B", false);
					this.gridATPsummary[0, 7] = new GridInfo.ColHeader("C", false);
					this.gridATPsummary[0, 8] = new GridInfo.ColHeader("D", false);
					this.gridATPsummary.Columns[0].Width = 80;
					this.gridATPsummary.Columns[1].Width = 90;
					this.gridATPsummary.Columns[2].Width = 80;
					this.gridATPsummary.Columns[3].Width = 90;
					this.gridATPsummary.Columns[4].Width = 90;
					this.gridATPsummary.Columns[5].Width = 90;
					this.gridATPsummary.Columns[6].Width = 90;
					this.gridATPsummary.Columns[7].Width = 90;
					this.gridATPsummary.Columns[8].Width = 90;
					this.gridATPsummary[0, 0].View = this.gridInfo.CellColor.cell_gray_center;
					this.gridATPsummary[0, 1].View = this.gridInfo.CellColor.cell_gray_center;
					this.gridATPsummary[0, 2].View = this.gridInfo.CellColor.cell_gray_center;
					this.gridATPsummary[0, 3].View = this.gridInfo.CellColor.cell_gray_center;
					this.gridATPsummary[0, 4].View = this.gridInfo.CellColor.cell_gray_center;
					this.gridATPsummary[0, 5].View = this.gridInfo.CellColor.cell_gray_center;
					this.gridATPsummary[0, 6].View = this.gridInfo.CellColor.cell_gray_center;
					this.gridATPsummary[0, 7].View = this.gridInfo.CellColor.cell_gray_center;
					this.gridATPsummary[0, 8].View = this.gridInfo.CellColor.cell_gray_center;
					this.gridATPsummary[1, 0] = new SourceGrid.Cells.Cell(dataSet.Tables[1].Rows[j]["inqty"].ToString());
					this.gridATPsummary[1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[1].Rows[j]["good"].ToString());
					this.gridATPsummary[1, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[1].Rows[j]["fail"].ToString());
					this.gridATPsummary[1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[1].Rows[j]["passyield"].ToString());
					this.gridATPsummary[1, 4] = new SourceGrid.Cells.Cell(dataSet.Tables[1].Rows[j]["failyield"].ToString());
					this.gridATPsummary[1, 5] = new SourceGrid.Cells.Cell("0");
					this.gridATPsummary[1, 6] = new SourceGrid.Cells.Cell("0");
					this.gridATPsummary[1, 7] = new SourceGrid.Cells.Cell("0");
					this.gridATPsummary[1, 8] = new SourceGrid.Cells.Cell("0");
				}
				for (int k = 0; k < dataSet.Tables[2].Rows.Count; k++)
				{
					CATPDailySummary catpdailySummary = new CATPDailySummary();
					catpdailySummary.groupdate = dataSet.Tables[2].Rows[k]["groupdate"].ToString();
					catpdailySummary.device = dataSet.Tables[2].Rows[k]["device"].ToString();
					catpdailySummary.ATPname = dataSet.Tables[2].Rows[k]["ATPname"].ToString();
					catpdailySummary.inqty = dataSet.Tables[2].Rows[k]["inqty"].ToString();
					catpdailySummary.good = dataSet.Tables[2].Rows[k]["good"].ToString();
					catpdailySummary.fail = dataSet.Tables[2].Rows[k]["fail"].ToString();
					catpdailySummary.yield = dataSet.Tables[2].Rows[k]["yield"].ToString();
					this._slAllData2.Add(k, catpdailySummary);
				}
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000169E4 File Offset: 0x00014BE4
		private void SetWeeklyReport(string strDate, string sType)
		{
			DataSet dataSet = new DataSet();
			this.cmbProduct3.Text.Trim();
			string text = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierWeeklyReport_TEST] @device  = '",
				this.cmbProduct3.Text,
				"', @search  = '",
				sType,
				"'"
			});
			if (sType == "Total")
			{
				text = text + ", @startdate  = '" + strDate + "'";
			}
			if (sType == "SIBCount")
			{
				text = text + ", @startdate  = '" + strDate + "'";
				text = text + ", @stddate  = '" + this.dtStdDate.ToString("yyyy-MM-dd") + "'";
			}
			else if (sType == "SIBFail")
			{
				text = text + ", @startdate  = '" + this.dtStdDate.ToString("yyyy-MM-dd") + "'";
				text = text + ", @stddate  = '" + strDate + "'";
			}
			dataSet = this.queryMgr.queryCall(text);
			if (sType == "Total")
			{
				if (dataSet.Tables.Count > 1)
				{
					new List<string>();
					new SortedList();
					SortedList sortedList = new SortedList();
					SortedList sortedList2 = new SortedList();
					SortedList sortedList3 = new SortedList();
					for (int i = 0; i < dataSet.Tables[1].Rows.Count; i++)
					{
						string key = dataSet.Tables[1].Rows[i]["device"].ToString();
						string value = dataSet.Tables[1].Rows[i]["cnt"].ToString();
						sortedList.Add(key, value);
					}
					for (int j = 0; j < dataSet.Tables[2].Rows.Count; j++)
					{
						string key2 = dataSet.Tables[2].Rows[j]["device"].ToString();
						string value2 = dataSet.Tables[2].Rows[j]["cnt"].ToString();
						sortedList2.Add(key2, value2);
					}
					for (int k = 0; k < dataSet.Tables[3].Rows.Count; k++)
					{
						string key3 = dataSet.Tables[3].Rows[k]["device"].ToString();
						string value3 = dataSet.Tables[3].Rows[k]["cnt"].ToString();
						sortedList3.Add(key3, value3);
					}
					new CWeeklyReport();
					for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
					{
						CWeeklyReportResult cweeklyReportResult = new CWeeklyReportResult();
						string key4 = dataSet.Tables[0].Rows[l]["typevalue"].ToString();
						if (sortedList.Contains(key4))
						{
							cweeklyReportResult.onhand = sortedList[key4].ToString();
						}
						if (sortedList2.Contains(key4))
						{
							cweeklyReportResult.func = sortedList2[key4].ToString();
						}
						if (sortedList3.Contains(key4))
						{
							cweeklyReportResult.nonfunc = sortedList3[key4].ToString();
						}
						if (this._slAllData.Contains(key4))
						{
							SortedList sortedList4 = (SortedList)this._slAllData[key4];
							sortedList4.Add(strDate, cweeklyReportResult);
						}
						else
						{
							this._slAllData.Add(key4, new SortedList());
							SortedList sortedList5 = (SortedList)this._slAllData[key4];
							sortedList5.Add(strDate, cweeklyReportResult);
						}
					}
					return;
				}
			}
			else if (sType == "SIBCount")
			{
				if (dataSet.Tables.Count > 0)
				{
					for (int m = 0; m < dataSet.Tables[0].Rows.Count; m++)
					{
						CWeeklyReportResult cweeklyReportResult2 = new CWeeklyReportResult();
						cweeklyReportResult2.sAccumedCnt = dataSet.Tables[0].Rows[m]["accumdcnt"].ToString();
						cweeklyReportResult2.sDayDefectCnt = dataSet.Tables[0].Rows[m]["daydefectcnt"].ToString();
						cweeklyReportResult2.sReturnCnt = dataSet.Tables[0].Rows[m]["dayreturncnt"].ToString();
						this._slAllData.Add(strDate, cweeklyReportResult2);
					}
					return;
				}
			}
			else if (sType == "SIBFail" && dataSet.Tables.Count > 0)
			{
				for (int n = 0; n < dataSet.Tables[0].Rows.Count; n++)
				{
					CWeeklyReportResult cweeklyReportResult3 = new CWeeklyReportResult();
					cweeklyReportResult3.sCheckDate = dataSet.Tables[0].Rows[n]["datetime"].ToString();
					cweeklyReportResult3.sSIB = dataSet.Tables[0].Rows[n]["location"].ToString();
					cweeklyReportResult3.sRev = dataSet.Tables[0].Rows[n]["revision"].ToString();
					cweeklyReportResult3.sFailName = dataSet.Tables[0].Rows[n]["repaircode"].ToString();
					cweeklyReportResult3.sDamage = dataSet.Tables[0].Rows[n]["damage"].ToString();
					this._slAllData.Add(n, cweeklyReportResult3);
				}
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00017010 File Offset: 0x00015210
		private void SetCarrierHistory(string sStartDate, string sType, string line = "")
		{
			string text = string.Empty;
			string text2 = this.cmbProduct.Text;
			DataSet dataSet = new DataSet();
			if (sType == "Total")
			{
				text = "[USP_Admin_GetCarrierDailyData]";
			}
			else
			{
				text = "[USP_Admin_GetCarrierRepairDailyData]";
			}
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].",
				text,
				" @startdate  = '",
				sStartDate,
				"', @product  = '",
				this.cmbProduct.Text,
				"', @line  = '",
				line,
				"'"
			});
			dataSet = this.queryMgr.queryCall(sQuery);
			CCarrierData ccarrierData = new CCarrierData();
			foreach (object obj in this._slCarrierType)
			{
				CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj).Value;
				ccarrierData.slTypeCount.Add(ccarrierType.strTypeValue, 0);
			}
			if (dataSet.Tables.Count > 1)
			{
				int index = 0;
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					CCarrierDataHistory ccarrierDataHistory = new CCarrierDataHistory();
					ccarrierDataHistory.strcategory = dataSet.Tables[index].Rows[i]["category"].ToString();
					ccarrierDataHistory.strcarrierid = dataSet.Tables[index].Rows[i]["carrierid"].ToString();
					ccarrierDataHistory.strdevice = dataSet.Tables[index].Rows[i]["device"].ToString();
					ccarrierDataHistory.strcarrierno = dataSet.Tables[index].Rows[i]["carrierno"].ToString();
					ccarrierDataHistory.stroperationcode = dataSet.Tables[index].Rows[i]["operationcode"].ToString();
					ccarrierDataHistory.strcarriertype = dataSet.Tables[index].Rows[i]["carriertype"].ToString();
					ccarrierDataHistory.strcustomer = dataSet.Tables[index].Rows[i]["customer"].ToString();
					ccarrierDataHistory.strsite = dataSet.Tables[index].Rows[i]["site"].ToString();
					ccarrierDataHistory.strtestername = dataSet.Tables[index].Rows[i]["testername"].ToString();
					ccarrierDataHistory.strpkgtype = dataSet.Tables[index].Rows[i]["pkgtype"].ToString();
					ccarrierDataHistory.strbarcode = dataSet.Tables[index].Rows[i]["location"].ToString();
					ccarrierDataHistory.strstatus = dataSet.Tables[index].Rows[i]["status"].ToString();
					ccarrierDataHistory.strtouchdowncnt = dataSet.Tables[index].Rows[i]["touchdowncnt"].ToString();
					ccarrierDataHistory.strcleancnt = dataSet.Tables[index].Rows[i]["cleancnt"].ToString();
					ccarrierDataHistory.strrepaircnt = dataSet.Tables[index].Rows[i]["repaircnt"].ToString();
					ccarrierDataHistory.strlimitcleancnt = dataSet.Tables[index].Rows[i]["limitcleancnt"].ToString();
					ccarrierDataHistory.strlimitrepaircnt = dataSet.Tables[index].Rows[i]["limitrepaircnt"].ToString();
					ccarrierDataHistory.strmemo = dataSet.Tables[index].Rows[i]["memo"].ToString();
					ccarrierDataHistory.strlastcleantime = dataSet.Tables[index].Rows[i]["lastcleantime"].ToString();
					ccarrierDataHistory.strlastrepairtime = dataSet.Tables[index].Rows[i]["lastrepairtime"].ToString();
					ccarrierDataHistory.strcreateuser = dataSet.Tables[index].Rows[i]["createuser"].ToString();
					ccarrierDataHistory.strcreatetime = dataSet.Tables[index].Rows[i]["createtime"].ToString();
					ccarrierDataHistory.strlasteventuser = dataSet.Tables[index].Rows[i]["lasteventuser"].ToString();
					ccarrierDataHistory.strlasteventtime = dataSet.Tables[index].Rows[i]["lasteventtime"].ToString();
					ccarrierDataHistory.strcorrelation = dataSet.Tables[index].Rows[i]["correlation"].ToString();
					ccarrierData.slCarrierDataHistory.Add(i, ccarrierDataHistory);
					if (ccarrierData.slTypeCount.ContainsKey(ccarrierDataHistory.strcategory))
					{
						int num = (int)ccarrierData.slTypeCount[ccarrierDataHistory.strcategory];
						num++;
						ccarrierData.slTypeCount[ccarrierDataHistory.strcategory] = num;
					}
				}
				index = 1;
				ccarrierData.strTotalCount = dataSet.Tables[index].Rows[0]["totalQty"].ToString();
			}
			this._slAllData.Add(sStartDate, ccarrierData);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0001769C File Offset: 0x0001589C
		private void gridInventoryList_OnKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.C && e.Control)
			{
				string text = this.ConvDataToStr(this.gridInventoryList);
				Clipboard.SetDataObject(text);
				Console.WriteLine(text);
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000176D4 File Offset: 0x000158D4
		private void gridEvent_OnKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.C && e.Control && sender is SourceGrid.Grid)
			{
				string text = this.ConvDataToStr((SourceGrid.Grid)sender);
				Clipboard.SetDataObject(text);
				Console.WriteLine(text);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00017714 File Offset: 0x00015914
		private string ConvDataToStr(SourceGrid.Grid grid)
		{
			new SortedList();
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			for (int i = 0; i < grid.RowsCount; i++)
			{
				for (int j = 0; j < grid.ColumnsCount; j++)
				{
					if (grid.Selection.IsSelectedCell(new Position(i, j)) && num3 == -1)
					{
						num3 = i;
						num = j;
						int row = i;
						while (grid.Selection.IsSelectedCell(new Position(row, j)))
						{
							num4 = row++;
						}
						while (grid.Selection.IsSelectedCell(new Position(num4, j)))
						{
							num2 = j++;
						}
					}
				}
			}
			if (num3 == -1 || num4 == -1 || num == -1 || num2 == -1)
			{
				return "Can't read the data";
			}
			string text = string.Empty;
			try
			{
				for (int k = num3; k <= num4; k++)
				{
					for (int l = num; l <= num2; l++)
					{
						text = text + grid[k, l].ToString() + "\t";
					}
					text += "\n";
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return text;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0001784C File Offset: 0x00015A4C
		private void cmdViewSearch_Click(object sender, EventArgs e)
		{
			if (this.cmbInventoryType.Text == string.Empty || this.cmbInventoryType.Text == "Total")
			{
				this.GetCarrierCategory("CarrierCategory");
				this.GetPeriodData("Total", "");
				this.initGridInventory();
				this.BindingGrid();
				this.DrawChart_CarrierView();
				return;
			}
			if (this.cmbInventoryType.Text == "Repair")
			{
				this.GetCarrierCategory("CarrierRepairCategory");
				this.GetPeriodData("Repair", "");
				this.initGridInventory();
				this.BindingGrid();
				this.DrawChart_CarrierRepairView();
				return;
			}
			if (this.cmbInventoryType.Text == "DeviceUtil")
			{
				if (this.cmbProduct.Text == string.Empty)
				{
					this.GetCarrierCategory("CarrierProduct");
				}
				else
				{
					this._slCarrierType.Clear();
					CCarrierType ccarrierType = new CCarrierType();
					ccarrierType.strTypeValue = this.cmbProduct.Text;
					this._slCarrierType.Add(ccarrierType.strTypeValue, ccarrierType);
				}
				this.GetCarrierUtil_Device();
				this.initGrid_Util_Device();
				this.BindingGrid_Util_Device();
				this.DrawChart_Util_Device();
				return;
			}
			if (this.cmbInventoryType.Text == "TesterUtil")
			{
				this.GetCarrierUtil_Tester();
				this.initGrid_Util_Tester();
				this.BindingGrid_Util_Tester();
				this.DrawChart_Util_Tester();
				return;
			}
			if (this.cmbInventoryType.Text == "BlacklistTrend")
			{
				if (this.cmbFailMode.Text == "Trend")
				{
					this.GetCarrierCategory("BlackListCategory");
					this.GetBlacklistTrend();
					this.initGrid_BlacklistTrend();
					this.BindingGrid_BlacklistTrend();
					this.DrawChart_BlacklistTrend();
					return;
				}
				this.GetBlacklistFailCount();
				this.initGrid_BlacklistFailCount();
				this.BindingGrid_BlacklistModeCount(0);
				this.DrawChart_BlacklistModeCount("BlacklistTrend", 0);
				return;
			}
			else
			{
				if (this.cmbInventoryType.Text == "Action")
				{
					this.GetBlacklistActionCount();
					this.initGrid_BlacklistActionCount();
					this.BindingGrid_BlacklistModeCount(0);
					this.DrawChart_BlacklistModeCount("Action", 0);
					return;
				}
				if (this.cmbInventoryType.Text == "TopFailCount")
				{
					this.GetTopFailCount();
					this.initGrid_TopFailCount();
					this.BindingGrid_BlacklistModeCount(10);
					this.DrawChart_BlacklistModeCount("TopFailCount", 10);
					return;
				}
				if (this.cmbInventoryType.Text == "SlotBlacklistTrend")
				{
					this.GetSlotCategory("SlotBlackListCategory");
					this.GetSlotBlacklistTrend();
					this.initGrid_SlotBlacklistTrend();
					this.BindingGrid_SlotBlackTrend();
					this.DrawChart_SlotBlacklistTrend();
					return;
				}
				if (this.cmbInventoryType.Text == "Line Actual")
				{
					this.GetCarrierCategory("LineActl");
					this.GetPeriodData("Total", "ACTL");
					this.initGridInventory();
					this.BindingGrid();
					this.DrawChart_CarrierView();
				}
				return;
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00017B14 File Offset: 0x00015D14
		private void InitChart_CarrierView()
		{
			if (this.chart_CarrierView.Series.Count > 0)
			{
				this.chart_CarrierView.Series.Clear();
			}
			this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Clear();
			this.chart_CarrierView.Update();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00017B70 File Offset: 0x00015D70
		private void CreateSeries_CarrierView()
		{
			Series series = new Series();
			series.ChartType = SeriesChartType.Line;
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Int32;
			series.Legend = "Legend1";
			series.LegendText = "Total";
			series.Name = "Total";
			this.chart_CarrierView.Series.Add(series);
			foreach (object obj in this._slCarrierType)
			{
				CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj).Value;
				Series series2 = new Series();
				series2.ChartType = SeriesChartType.StackedColumn;
				series2.ChartArea = "ChartArea1";
				series2.Font = new Font("Segoe UI", 8f);
				series2.LabelForeColor = Color.Empty;
				series2.XValueType = ChartValueType.String;
				series2.YValueType = ChartValueType.Int32;
				series2.Legend = "Legend1";
				series2.LegendText = ccarrierType.strTypeValue;
				series2.Name = ccarrierType.strTypeValue;
				if (ccarrierType.strTypeValue == "Return")
				{
					series2.Color = Color.SlateGray;
				}
				else if (ccarrierType.strTypeValue == "Repairing")
				{
					series2.Color = Color.Tomato;
				}
				else if (ccarrierType.strTypeValue == "Machine")
				{
					series2.Color = Color.DodgerBlue;
				}
				else if (ccarrierType.strTypeValue == "Create")
				{
					series2.Color = Color.PaleGreen;
				}
				else if (ccarrierType.strTypeValue == "Idle")
				{
					series2.Color = Color.DarkGray;
				}
				else if (ccarrierType.strTypeValue == "Cleaning")
				{
					series2.Color = Color.Gold;
				}
				this.chart_CarrierView.Series.Add(series2);
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00017D98 File Offset: 0x00015F98
		private void CreateSeries_CarrierRepairView()
		{
			foreach (object obj in this._slCarrierType)
			{
				CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj).Value;
				Series series = new Series();
				series.ChartType = SeriesChartType.Line;
				series.ChartArea = "ChartArea1";
				series.Font = new Font("Segoe UI", 8f);
				series.LabelForeColor = Color.Empty;
				series.XValueType = ChartValueType.String;
				series.YValueType = ChartValueType.Int32;
				series.Legend = "Legend1";
				series.LegendText = ccarrierType.strTypeValue;
				series.Name = ccarrierType.strTypeValue;
				if (ccarrierType.strTypeValue == "RepairIn")
				{
					series.Color = Color.LawnGreen;
				}
				else if (ccarrierType.strTypeValue == "RepairOut")
				{
					series.Color = Color.DodgerBlue;
				}
				this.chart_CarrierView.Series.Add(series);
			}
			Series series2 = new Series();
			series2.ChartType = SeriesChartType.Column;
			series2.ChartArea = "ChartArea1";
			series2.Font = new Font("Segoe UI", 8f);
			series2.LabelForeColor = Color.Empty;
			series2.XValueType = ChartValueType.String;
			series2.YValueType = ChartValueType.Int32;
			series2.Legend = "Legend1";
			series2.LegendText = "Total";
			series2.Name = "Total";
			series2.Color = Color.FromArgb(120, 255, 0, 0);
			this.chart_CarrierView.Series.Add(series2);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00017F48 File Offset: 0x00016148
		private void CreateSeries_Util_Device()
		{
			foreach (object obj in this._slCarrierType)
			{
				CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj).Value;
				Series series = new Series();
				series.ChartType = SeriesChartType.Line;
				series.ChartArea = "ChartArea1";
				series.Font = new Font("Segoe UI", 8f);
				series.LabelForeColor = Color.Empty;
				series.XValueType = ChartValueType.String;
				series.YValueType = ChartValueType.Int32;
				series.Legend = "Legend1";
				series.LegendText = ccarrierType.strTypeValue;
				series.Name = ccarrierType.strTypeValue;
				this.chart_CarrierView.Series.Add(series);
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0001802C File Offset: 0x0001622C
		private void CreateSeries_BlackListTrend()
		{
			foreach (object obj in this._slCarrierType)
			{
				CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj).Value;
				Series series = new Series();
				series.ChartType = SeriesChartType.StackedColumn;
				series.ChartArea = "ChartArea1";
				series.Font = new Font("Segoe UI", 8f);
				series.LabelForeColor = Color.Empty;
				series.XValueType = ChartValueType.String;
				series.YValueType = ChartValueType.Int32;
				series.Legend = "Legend1";
				series.LegendText = ccarrierType.strTypeValue;
				series.Name = ccarrierType.strTypeValue;
				this.chart_CarrierView.Series.Add(series);
				this.chart_CarrierView.Titles[0].Text = "Blacklist Trend";
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0001812C File Offset: 0x0001632C
		private void CreateSeries_SlotBlackListTrend()
		{
			foreach (object obj in this._slSlotType)
			{
				CSlotType cslotType = (CSlotType)((DictionaryEntry)obj).Value;
				Series series = new Series();
				series.ChartType = SeriesChartType.StackedColumn;
				series.ChartArea = "ChartArea1";
				series.Font = new Font("Segoe UI", 8f);
				series.LabelForeColor = Color.Empty;
				series.XValueType = ChartValueType.String;
				series.YValueType = ChartValueType.Int32;
				series.Legend = "Legend1";
				series.LegendText = cslotType.strTypeValue;
				series.Name = cslotType.strTypeValue;
				this.chart_CarrierView.Series.Add(series);
				this.chart_CarrierView.Titles[0].Text = "SlotBlacklist Trend";
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0001822C File Offset: 0x0001642C
		private void chart_CarrierView_MouserClick(object sender, MouseEventArgs e)
		{
			this.chart_CarrierView.HitTest(e.X, e.Y, ChartElementType.DataPoint);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00018248 File Offset: 0x00016448
		private void CreateSeries_BlackListFailCount(string sType)
		{
			Series series = new Series();
			series.ChartType = SeriesChartType.Column;
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Int32;
			series.Legend = "Legend1";
			if (sType == "BlacklistTrend" || sType == "Action")
			{
				series.LegendText = "Quantity of Blacklist";
				series.Name = "Quantity of Blacklist";
				this.chart_CarrierView.Series.Add(series);
				this.chart_CarrierView.Titles[0].Text = "Blacklist Fail/Action Mode";
				return;
			}
			if (sType == "TopFailCount")
			{
				series.LegendText = "Fail Name";
				series.Name = "Fail Name";
				this.chart_CarrierView.Series.Add(series);
				this.chart_CarrierView.Titles[0].Text = "Top 10 Fail";
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00018354 File Offset: 0x00016554
		private void initGridInventory()
		{
			this.gridInventoryList.ColumnsCount = 0;
			this.gridInventoryList.ColumnsCount = 3 + this._slCarrierType.Count;
			this.gridInventoryList.RowsCount = 1;
			this.gridInventoryList.FixedRows = 1;
			this.gridInventoryList.FixedColumns = 1;
			this.gridInventoryList[0, 0] = new GridInfo.ColHeader("No", false);
			this.gridInventoryList[0, 1] = new GridInfo.ColHeader("Date", false);
			this.gridInventoryList[0, 2] = new GridInfo.ColHeader("Total", false);
			for (int i = 0; i < this._slCarrierType.Count; i++)
			{
				CCarrierType ccarrierType = (CCarrierType)this._slCarrierType.GetByIndex(i);
				this.gridInventoryList[0, i + 3] = new GridInfo.ColHeader(ccarrierType.strTypeValue, false);
			}
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00018468 File Offset: 0x00016668
		private void initGrid_Util_Device()
		{
			this.gridInventoryList.ColumnsCount = 0;
			this.gridInventoryList.ColumnsCount = 2 + this._slCarrierType.Count * 4;
			this.gridInventoryList.RowsCount = 2;
			this.gridInventoryList.FixedRows = 2;
			this.gridInventoryList.FixedColumns = 1;
			int num = 0;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("No", false);
			this.gridInventoryList[0, num].RowSpan = 2;
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Date", false);
			this.gridInventoryList[0, num].RowSpan = 2;
			num++;
			for (int i = 0; i < this._slCarrierType.Count; i++)
			{
				CCarrierType ccarrierType = (CCarrierType)this._slCarrierType.GetByIndex(i);
				this.gridInventoryList[0, num] = new GridInfo.ColHeader(ccarrierType.strTypeValue, false);
				this.gridInventoryList[0, num].ColumnSpan = 4;
				this.gridInventoryList[1, num++] = new GridInfo.ColHeader("Tester", false);
				this.gridInventoryList[1, num++] = new GridInfo.ColHeader("LoadCarrier", false);
				this.gridInventoryList[1, num++] = new GridInfo.ColHeader("BinQty", false);
				this.gridInventoryList[1, num++] = new GridInfo.ColHeader("Util", false);
			}
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 1, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00018640 File Offset: 0x00016840
		private void initGrid_Util_Tester()
		{
			this.gridInventoryList.ColumnsCount = 0;
			this.gridInventoryList.ColumnsCount = 2 + this._slCarrierType.Count * 4;
			this.gridInventoryList.RowsCount = 2;
			this.gridInventoryList.FixedRows = 2;
			this.gridInventoryList.FixedColumns = 2;
			int num = 0;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("No", false);
			this.gridInventoryList[0, num].RowSpan = 2;
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Date", false);
			this.gridInventoryList[0, num].RowSpan = 2;
			num++;
			for (int i = 0; i < this._slCarrierType.Count; i++)
			{
				CCarrierType ccarrierType = (CCarrierType)this._slCarrierType.GetByIndex(i);
				this.gridInventoryList[0, num] = new GridInfo.ColHeader(ccarrierType.strTypeValue, false);
				this.gridInventoryList[0, num].ColumnSpan = 4;
				this.gridInventoryList[1, num++] = new GridInfo.ColHeader("Device", false);
				this.gridInventoryList[1, num++] = new GridInfo.ColHeader("LoadCarrier", false);
				this.gridInventoryList[1, num++] = new GridInfo.ColHeader("BinQty", false);
				this.gridInventoryList[1, num++] = new GridInfo.ColHeader("Util", false);
			}
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 1, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00018818 File Offset: 0x00016A18
		private void initGrid_BlacklistTrend()
		{
			this.gridInventoryList.ColumnsCount = 0;
			this.gridInventoryList.ColumnsCount = 2 + this._slCarrierType.Count;
			this.gridInventoryList.RowsCount = 1;
			this.gridInventoryList.FixedRows = 1;
			this.gridInventoryList.FixedColumns = 1;
			int num = 0;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("No", false);
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Date", false);
			num++;
			for (int i = 0; i < this._slCarrierType.Count; i++)
			{
				CCarrierType ccarrierType = (CCarrierType)this._slCarrierType.GetByIndex(i);
				this.gridInventoryList[0, num] = new GridInfo.ColHeader(ccarrierType.strTypeValue, false);
				num++;
			}
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00018920 File Offset: 0x00016B20
		private void initGrid_SlotBlacklistTrend()
		{
			this.gridInventoryList.ColumnsCount = 0;
			this.gridInventoryList.ColumnsCount = 2 + this._slSlotType.Count;
			this.gridInventoryList.RowsCount = 1;
			this.gridInventoryList.FixedRows = 1;
			this.gridInventoryList.FixedColumns = 1;
			int num = 0;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("No", false);
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Date", false);
			num++;
			for (int i = 0; i < this._slSlotType.Count; i++)
			{
				CSlotType cslotType = (CSlotType)this._slSlotType.GetByIndex(i);
				this.gridInventoryList[0, num] = new GridInfo.ColHeader(cslotType.strTypeValue, false);
				num++;
			}
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00018A28 File Offset: 0x00016C28
		private void initGrid_BlacklistFailCount()
		{
			this.gridInventoryList.ColumnsCount = 0;
			this.gridInventoryList.ColumnsCount = 3;
			this.gridInventoryList.RowsCount = 1;
			this.gridInventoryList.FixedRows = 1;
			this.gridInventoryList.FixedColumns = 1;
			int num = 0;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("No", false);
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Fail Mode", false);
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Quantity of Blacklist", false);
			num++;
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00018AFC File Offset: 0x00016CFC
		private void initGrid_BlacklistActionCount()
		{
			this.gridInventoryList.ColumnsCount = 0;
			this.gridInventoryList.ColumnsCount = 3;
			this.gridInventoryList.RowsCount = 1;
			this.gridInventoryList.FixedRows = 1;
			this.gridInventoryList.FixedColumns = 1;
			int num = 0;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("No", false);
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Action", false);
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Quantity of Blacklist", false);
			num++;
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00018BD0 File Offset: 0x00016DD0
		private void initGrid_TopFailCount()
		{
			this.gridInventoryList.ColumnsCount = 0;
			this.gridInventoryList.ColumnsCount = 3;
			this.gridInventoryList.RowsCount = 1;
			this.gridInventoryList.FixedRows = 1;
			this.gridInventoryList.FixedColumns = 1;
			int num = 0;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("No", false);
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Fail Name", false);
			num++;
			this.gridInventoryList[0, num] = new GridInfo.ColHeader("Fail Count", false);
			num++;
			this.gridInfo.SetColumnCellColor(this.gridInventoryList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00018CA4 File Offset: 0x00016EA4
		private void BindingGrid()
		{
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string cellValue = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				string cellValue2 = (this.gridInventoryList.RowsCount - 1).ToString();
				this.gridInventoryList.Rows.Insert(this.gridInventoryList.RowsCount);
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 0] = new SourceGrid.Cells.Cell(cellValue2);
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 1] = new SourceGrid.Cells.Cell(cellValue);
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 2] = new SourceGrid.Cells.Cell(ccarrierData.strTotalCount);
				int num = 3;
				foreach (object obj2 in ccarrierData.slTypeCount)
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
					dictionaryEntry2.Key.ToString();
					int num2 = (int)dictionaryEntry2.Value;
					this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(num2.ToString());
				}
			}
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00018E6C File Offset: 0x0001706C
		private void BindingGrid_Util_Device()
		{
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string cellValue = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				this.gridInventoryList.Rows.Insert(this.gridInventoryList.RowsCount);
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 0] = new SourceGrid.Cells.Cell((this.gridInventoryList.RowsCount - 2).ToString());
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 1] = new SourceGrid.Cells.Cell(cellValue);
				int num = 2;
				foreach (object obj2 in this._slCarrierType)
				{
					string key = ((DictionaryEntry)obj2).Key.ToString();
					if (ccarrierData.slCarrierDevice.ContainsKey(key))
					{
						CCarrierUtilData ccarrierUtilData = (CCarrierUtilData)ccarrierData.slCarrierDevice[key];
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(ccarrierUtilData.LoadTesterCnt);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(ccarrierUtilData.LoadCarrierCnt);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(ccarrierUtilData.BinQty);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(ccarrierUtilData.Util);
					}
					else
					{
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
					}
				}
			}
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00019160 File Offset: 0x00017360
		private void BindingGrid_Util_Tester()
		{
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string cellValue = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				this.gridInventoryList.Rows.Insert(this.gridInventoryList.RowsCount);
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 0] = new SourceGrid.Cells.Cell((this.gridInventoryList.RowsCount - 2).ToString());
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 1] = new SourceGrid.Cells.Cell(cellValue);
				int num = 2;
				foreach (object obj2 in this._slCarrierType)
				{
					CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj2).Value;
					string strTypeValue = ccarrierType.strTypeValue;
					if (ccarrierData.slCarrierTester.ContainsKey(strTypeValue))
					{
						CCarrierUtilData ccarrierUtilData = (CCarrierUtilData)ccarrierData.slCarrierTester[strTypeValue];
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(ccarrierUtilData.Device);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(ccarrierUtilData.LoadCarrierCnt);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(ccarrierUtilData.BinQty);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(ccarrierUtilData.Util);
					}
					else
					{
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
					}
				}
			}
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00019458 File Offset: 0x00017658
		private void BindingGrid_BlacklistTrend()
		{
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string cellValue = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				this.gridInventoryList.Rows.Insert(this.gridInventoryList.RowsCount);
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 0] = new SourceGrid.Cells.Cell((this.gridInventoryList.RowsCount - 2).ToString());
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 1] = new SourceGrid.Cells.Cell(cellValue);
				int num = 2;
				foreach (object obj2 in this._slCarrierType)
				{
					CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj2).Value;
					string strTypeValue = ccarrierType.strTypeValue;
					if (ccarrierData.slCarrierFailMode.ContainsKey(strTypeValue))
					{
						CCarrierFailModeData ccarrierFailModeData = (CCarrierFailModeData)ccarrierData.slCarrierFailMode[strTypeValue];
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(ccarrierFailModeData.Count);
					}
					else
					{
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
					}
				}
			}
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0001964C File Offset: 0x0001784C
		private void BindingGrid_SlotBlackTrend()
		{
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string cellValue = dictionaryEntry.Key.ToString();
				CSlotData cslotData = (CSlotData)dictionaryEntry.Value;
				this.gridInventoryList.Rows.Insert(this.gridInventoryList.RowsCount);
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 0] = new SourceGrid.Cells.Cell((this.gridInventoryList.RowsCount - 2).ToString());
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 1] = new SourceGrid.Cells.Cell(cellValue);
				int num = 2;
				foreach (object obj2 in this._slSlotType)
				{
					CSlotType cslotType = (CSlotType)((DictionaryEntry)obj2).Value;
					string strTypeValue = cslotType.strTypeValue;
					if (cslotData.slSlotBlackListMode.ContainsKey(strTypeValue))
					{
						CSlotBlackListData cslotBlackListData = (CSlotBlackListData)cslotData.slSlotBlackListMode[strTypeValue];
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(cslotBlackListData.Count);
					}
					else
					{
						this.gridInventoryList[this.gridInventoryList.RowsCount - 1, num++] = new SourceGrid.Cells.Cell(0);
					}
				}
			}
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00019840 File Offset: 0x00017A40
		private void BindingGrid_BlacklistModeCount(int iCount = 0)
		{
			ArrayList arrayList = this.orderByFailList(this._slAllData, iCount);
			foreach (object obj in arrayList)
			{
				CCarrierFailModeData ccarrierFailModeData = (CCarrierFailModeData)obj;
				this.gridInventoryList.Rows.Insert(this.gridInventoryList.RowsCount);
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 0] = new SourceGrid.Cells.Cell((this.gridInventoryList.RowsCount - 1).ToString());
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 1] = new SourceGrid.Cells.Cell(ccarrierFailModeData.Name);
				this.gridInventoryList[this.gridInventoryList.RowsCount - 1, 2] = new SourceGrid.Cells.Cell(ccarrierFailModeData.Count);
			}
			this.gridInfo.AutoSetGrid(this.gridInventoryList);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00019950 File Offset: 0x00017B50
		private ArrayList orderByFailList(SortedList slList, int iCount = 0)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in slList)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				dictionaryEntry.Key.ToString();
				CCarrierFailModeData value = (CCarrierFailModeData)dictionaryEntry.Value;
				arrayList.Add(value);
			}
			arrayList.Sort(new Carrier.sorting());
			if (iCount > 0 && arrayList.Count > iCount)
			{
				ArrayList arrayList2 = new ArrayList();
				for (int i = 0; i < iCount; i++)
				{
					arrayList2.Add(arrayList[i]);
				}
				arrayList = arrayList2;
			}
			return arrayList;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00019A0C File Offset: 0x00017C0C
		private void DrawChart_CarrierView()
		{
			this.InitChart_CarrierView();
			this.CreateSeries_CarrierView();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			double num4 = 1.5;
			string toolTip = string.Empty;
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				num2 = 0;
				num2 = Convert.ToInt32(ccarrierData.strTotalCount);
				this.chart_CarrierView.Series["Total"].Points.Add(new double[]
				{
					(double)num2
				});
				toolTip = "Total\r\n" + ccarrierData.strTotalCount;
				this.chart_CarrierView.Series["Total"].Points[num].ToolTip = toolTip;
				this.chart_CarrierView.Series["Total"].Points[num].Label = ccarrierData.strTotalCount;
				this.chart_CarrierView.Series["Total"].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
				this.chart_CarrierView.Series["Total"].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
				this.chart_CarrierView.Series["Total"].MarkerStyle = MarkerStyle.Circle;
				this.chart_CarrierView.Series["Total"].BorderWidth = 2;
				foreach (object obj2 in ccarrierData.slTypeCount)
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
					string text2 = dictionaryEntry2.Key.ToString();
					int num5 = (int)dictionaryEntry2.Value;
					this.chart_CarrierView.Series[text2].Points.Add(new double[]
					{
						(double)num5
					});
					toolTip = text2 + "\r\n" + num5.ToString();
					this.chart_CarrierView.Series[text2].Points[num].ToolTip = toolTip;
					if (num5 > 0)
					{
						this.chart_CarrierView.Series[text2].Points[num].Label = num5.ToString();
						this.chart_CarrierView.Series[text2].Font = new Font("Segoe UI", 8f, FontStyle.Regular);
						this.chart_CarrierView.Series[text2].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
					}
				}
				if (num2 > num3)
				{
					num3 = num2;
				}
				CustomLabel customLabel = new CustomLabel();
				customLabel.Text = text;
				customLabel.FromPosition = 0.5;
				if (num == 0)
				{
					customLabel.ToPosition = num4;
				}
				else
				{
					num4 += 2.0;
					customLabel.ToPosition = num4;
				}
				customLabel.RowIndex = 0;
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_CarrierView.ChartAreas[0].Position.Auto = false;
			this.chart_CarrierView.ChartAreas[0].Position.X = 0f;
			this.chart_CarrierView.ChartAreas[0].Position.Y = 10f;
			this.chart_CarrierView.ChartAreas[0].Position.Height = 75f;
			this.chart_CarrierView.ChartAreas[0].Position.Width = 99f;
			this.chart_CarrierView.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.Maximum = (double)(this._slAllData.Count + 1);
			this.chart_CarrierView.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_CarrierView.ChartAreas[0].AxisX.Interval = 2.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			double maximum = Math.Ceiling(Convert.ToDouble(num3 / 100)) * 100.0 + 200.0;
			this.chart_CarrierView.ChartAreas[0].AxisY.Maximum = maximum;
			for (int i = 0; i < this.chart_CarrierView.Series.Count; i++)
			{
				this.chart_CarrierView.Series[i]["PointWidth"] = "0.4";
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0001A0D4 File Offset: 0x000182D4
		private void DrawChart_CarrierRepairView()
		{
			this.InitChart_CarrierView();
			this.CreateSeries_CarrierRepairView();
			int num = 0;
			double num2 = 1.5;
			string toolTip = string.Empty;
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				int num3 = Convert.ToInt32(ccarrierData.strTotalCount);
				this.chart_CarrierView.Series["Total"].Points.Add(new double[]
				{
					(double)num3
				});
				toolTip = "Total\r\n" + ccarrierData.strTotalCount;
				this.chart_CarrierView.Series["Total"].Points[num].ToolTip = toolTip;
				this.chart_CarrierView.Series["Total"].Points[num].Label = ccarrierData.strTotalCount;
				this.chart_CarrierView.Series["Total"].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
				this.chart_CarrierView.Series["Total"].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
				foreach (object obj2 in ccarrierData.slTypeCount)
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
					string text2 = dictionaryEntry2.Key.ToString();
					int num4 = (int)dictionaryEntry2.Value;
					this.chart_CarrierView.Series[text2].Points.Add(new double[]
					{
						(double)num4
					});
					toolTip = text2 + "\r\n" + num4.ToString();
					this.chart_CarrierView.Series[text2].Points[num].ToolTip = toolTip;
					this.chart_CarrierView.Series[text2].MarkerStyle = MarkerStyle.Circle;
					this.chart_CarrierView.Series[text2].MarkerSize = 7;
					this.chart_CarrierView.Series[text2].BorderWidth = 2;
					if (num4 > 0)
					{
						this.chart_CarrierView.Series[text2].Points[num].Label = num4.ToString();
						this.chart_CarrierView.Series[text2].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
						this.chart_CarrierView.Series[text2].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
					}
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
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_CarrierView.ChartAreas[0].Position.Auto = false;
			this.chart_CarrierView.ChartAreas[0].Position.X = 0f;
			this.chart_CarrierView.ChartAreas[0].Position.Y = 10f;
			this.chart_CarrierView.ChartAreas[0].Position.Height = 75f;
			this.chart_CarrierView.ChartAreas[0].Position.Width = 99f;
			this.chart_CarrierView.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.Maximum = (double)(this._slAllData.Count + 1);
			this.chart_CarrierView.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_CarrierView.ChartAreas[0].AxisX.Interval = 2.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_CarrierView.ChartAreas[0].RecalculateAxesScale();
			this.chart_CarrierView.ChartAreas[0].AxisY.Maximum = double.NaN;
			for (int i = 0; i < this.chart_CarrierView.Series.Count; i++)
			{
				this.chart_CarrierView.Series[i]["PointWidth"] = "0.4";
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0001A79C File Offset: 0x0001899C
		private void DrawChart_Util_Device()
		{
			this.InitChart_CarrierView();
			this.CreateSeries_Util_Device();
			int num = 0;
			double num2 = 1.5;
			string toolTip = string.Empty;
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				foreach (object obj2 in this._slCarrierType)
				{
					string text2 = ((DictionaryEntry)obj2).Key.ToString();
					if (ccarrierData.slCarrierDevice.ContainsKey(text2))
					{
						CCarrierUtilData ccarrierUtilData = (CCarrierUtilData)ccarrierData.slCarrierDevice[text2];
						this.chart_CarrierView.Series[text2].Points.Add(new double[]
						{
							ccarrierUtilData.Util
						});
						toolTip = text2 + "\r\n" + ccarrierUtilData.Util.ToString();
						this.chart_CarrierView.Series[text2].Points[num].ToolTip = toolTip;
						this.chart_CarrierView.Series[text2].MarkerStyle = MarkerStyle.Circle;
						this.chart_CarrierView.Series[text2].MarkerSize = 7;
						this.chart_CarrierView.Series[text2].BorderWidth = 2;
						if (ccarrierUtilData.Util > 0.0)
						{
							this.chart_CarrierView.Series[text2].Points[num].Label = ccarrierUtilData.Util.ToString();
							this.chart_CarrierView.Series[text2].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
							this.chart_CarrierView.Series[text2].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
						}
					}
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
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_CarrierView.ChartAreas[0].Position.Auto = false;
			this.chart_CarrierView.ChartAreas[0].Position.X = 0f;
			this.chart_CarrierView.ChartAreas[0].Position.Y = 10f;
			this.chart_CarrierView.ChartAreas[0].Position.Height = 75f;
			this.chart_CarrierView.ChartAreas[0].Position.Width = 99f;
			this.chart_CarrierView.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.Maximum = (double)(this._slAllData.Count + 1);
			this.chart_CarrierView.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_CarrierView.ChartAreas[0].AxisX.Interval = 2.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_CarrierView.ChartAreas[0].RecalculateAxesScale();
			this.chart_CarrierView.ChartAreas[0].AxisY.Maximum = double.NaN;
			for (int i = 0; i < this.chart_CarrierView.Series.Count; i++)
			{
				this.chart_CarrierView.Series[i]["PointWidth"] = "0.4";
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0001AD98 File Offset: 0x00018F98
		private void DrawChart_Util_Tester()
		{
			this.InitChart_CarrierView();
			this.CreateSeries_Util_Device();
			int num = 0;
			double num2 = 1.5;
			string toolTip = string.Empty;
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				foreach (object obj2 in this._slCarrierType)
				{
					CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj2).Value;
					string strTypeValue = ccarrierType.strTypeValue;
					if (ccarrierData.slCarrierTester.ContainsKey(strTypeValue))
					{
						CCarrierUtilData ccarrierUtilData = (CCarrierUtilData)ccarrierData.slCarrierTester[strTypeValue];
						this.chart_CarrierView.Series[strTypeValue].Points.Add(new double[]
						{
							ccarrierUtilData.Util
						});
						toolTip = strTypeValue + "\r\n" + ccarrierUtilData.Util.ToString();
						this.chart_CarrierView.Series[strTypeValue].Points[num].ToolTip = toolTip;
						this.chart_CarrierView.Series[strTypeValue].MarkerStyle = MarkerStyle.Circle;
						this.chart_CarrierView.Series[strTypeValue].MarkerSize = 7;
						this.chart_CarrierView.Series[strTypeValue].BorderWidth = 2;
					}
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
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_CarrierView.ChartAreas[0].Position.Auto = false;
			this.chart_CarrierView.ChartAreas[0].Position.X = 0f;
			this.chart_CarrierView.ChartAreas[0].Position.Y = 10f;
			this.chart_CarrierView.ChartAreas[0].Position.Height = 75f;
			this.chart_CarrierView.ChartAreas[0].Position.Width = 99f;
			this.chart_CarrierView.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.Maximum = (double)(this._slAllData.Count + 1);
			this.chart_CarrierView.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_CarrierView.ChartAreas[0].AxisX.Interval = 2.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_CarrierView.ChartAreas[0].RecalculateAxesScale();
			this.chart_CarrierView.ChartAreas[0].AxisY.Maximum = double.NaN;
			for (int i = 0; i < this.chart_CarrierView.Series.Count; i++)
			{
				this.chart_CarrierView.Series[i]["PointWidth"] = "0.4";
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0001B30C File Offset: 0x0001950C
		private void DrawChart_BlacklistTrend()
		{
			this.InitChart_CarrierView();
			this.CreateSeries_BlackListTrend();
			int num = 0;
			double num2 = 1.5;
			string toolTip = string.Empty;
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				foreach (object obj2 in this._slCarrierType)
				{
					CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj2).Value;
					string strTypeValue = ccarrierType.strTypeValue;
					if (ccarrierData.slCarrierFailMode.ContainsKey(strTypeValue))
					{
						CCarrierFailModeData ccarrierFailModeData = (CCarrierFailModeData)ccarrierData.slCarrierFailMode[strTypeValue];
						this.chart_CarrierView.Series[strTypeValue].Points.Add(new double[]
						{
							(double)ccarrierFailModeData.Count
						});
						toolTip = strTypeValue + "\r\n" + ccarrierFailModeData.Count.ToString();
						this.chart_CarrierView.Series[strTypeValue].Points[num].ToolTip = toolTip;
						if (ccarrierFailModeData.Count > 0)
						{
							this.chart_CarrierView.Series[strTypeValue].Points[num].Label = ccarrierFailModeData.Count.ToString();
							this.chart_CarrierView.Series[strTypeValue].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
							this.chart_CarrierView.Series[strTypeValue].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
						}
					}
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
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_CarrierView.ChartAreas[0].Position.Auto = false;
			this.chart_CarrierView.ChartAreas[0].Position.X = 0f;
			this.chart_CarrierView.ChartAreas[0].Position.Y = 10f;
			this.chart_CarrierView.ChartAreas[0].Position.Height = 75f;
			this.chart_CarrierView.ChartAreas[0].Position.Width = 99f;
			this.chart_CarrierView.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.Maximum = (double)(this._slAllData.Count + 1);
			this.chart_CarrierView.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_CarrierView.ChartAreas[0].AxisX.Interval = 2.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_CarrierView.ChartAreas[0].RecalculateAxesScale();
			this.chart_CarrierView.ChartAreas[0].AxisY.Maximum = double.NaN;
			for (int i = 0; i < this.chart_CarrierView.Series.Count; i++)
			{
				this.chart_CarrierView.Series[i]["PointWidth"] = "0.4";
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0001B8C4 File Offset: 0x00019AC4
		private void DrawChart_SlotBlacklistTrend()
		{
			this.InitChart_CarrierView();
			this.CreateSeries_SlotBlackListTrend();
			int num = 0;
			double num2 = 1.5;
			string toolTip = string.Empty;
			foreach (object obj in this._slAllData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key.ToString();
				CSlotData cslotData = (CSlotData)dictionaryEntry.Value;
				foreach (object obj2 in this._slSlotType)
				{
					CSlotType cslotType = (CSlotType)((DictionaryEntry)obj2).Value;
					string strTypeValue = cslotType.strTypeValue;
					if (cslotData.slSlotBlackListMode.ContainsKey(strTypeValue))
					{
						CSlotBlackListData cslotBlackListData = (CSlotBlackListData)cslotData.slSlotBlackListMode[strTypeValue];
						this.chart_CarrierView.Series[strTypeValue].Points.Add(new double[]
						{
							(double)cslotBlackListData.Count
						});
						toolTip = strTypeValue + "\r\n" + cslotBlackListData.Count.ToString();
						this.chart_CarrierView.Series[strTypeValue].Points[num].ToolTip = toolTip;
						if (cslotBlackListData.Count > 0)
						{
							this.chart_CarrierView.Series[strTypeValue].Points[num].Label = cslotBlackListData.Count.ToString();
							this.chart_CarrierView.Series[strTypeValue].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
							this.chart_CarrierView.Series[strTypeValue].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
						}
					}
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
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_CarrierView.ChartAreas[0].Position.Auto = false;
			this.chart_CarrierView.ChartAreas[0].Position.X = 0f;
			this.chart_CarrierView.ChartAreas[0].Position.Y = 10f;
			this.chart_CarrierView.ChartAreas[0].Position.Height = 75f;
			this.chart_CarrierView.ChartAreas[0].Position.Width = 99f;
			this.chart_CarrierView.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.Maximum = (double)(this._slAllData.Count + 1);
			this.chart_CarrierView.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_CarrierView.ChartAreas[0].AxisX.Interval = 2.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_CarrierView.ChartAreas[0].RecalculateAxesScale();
			this.chart_CarrierView.ChartAreas[0].AxisY.Maximum = double.NaN;
			for (int i = 0; i < this.chart_CarrierView.Series.Count; i++)
			{
				this.chart_CarrierView.Series[i]["PointWidth"] = "0.4";
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0001BE7C File Offset: 0x0001A07C
		private void DrawChart_BlacklistModeCount(string sType, int iCount = 0)
		{
			this.InitChart_CarrierView();
			this.CreateSeries_BlackListFailCount(sType);
			int num = 0;
			double num2 = 1.5;
			string toolTip = string.Empty;
			ArrayList arrayList = this.orderByFailList(this._slAllData, iCount);
			foreach (object obj in arrayList)
			{
				CCarrierFailModeData ccarrierFailModeData = (CCarrierFailModeData)obj;
				string text = ccarrierFailModeData.Name.ToString();
				this.chart_CarrierView.Series[0].Points.Add(new double[]
				{
					(double)ccarrierFailModeData.Count
				});
				toolTip = text + "\r\n" + ccarrierFailModeData.Count.ToString();
				this.chart_CarrierView.Series[0].Points[num].ToolTip = toolTip;
				if (ccarrierFailModeData.Count > 0)
				{
					this.chart_CarrierView.Series[0].Points[num].Label = ccarrierFailModeData.Count.ToString();
					this.chart_CarrierView.Series[0].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
					this.chart_CarrierView.Series[0].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
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
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_CarrierView.ChartAreas[0].Position.Auto = false;
			this.chart_CarrierView.ChartAreas[0].Position.X = 0f;
			this.chart_CarrierView.ChartAreas[0].Position.Y = 10f;
			this.chart_CarrierView.ChartAreas[0].Position.Height = 75f;
			this.chart_CarrierView.ChartAreas[0].Position.Width = 99f;
			this.chart_CarrierView.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.Maximum = (double)(arrayList.Count + 1);
			this.chart_CarrierView.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_CarrierView.ChartAreas[0].AxisX.Interval = 2.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
			this.chart_CarrierView.ChartAreas[0].RecalculateAxesScale();
			this.chart_CarrierView.ChartAreas[0].AxisY.Maximum = double.NaN;
			for (int i = 0; i < this.chart_CarrierView.Series.Count; i++)
			{
				this.chart_CarrierView.Series[i]["PointWidth"] = "0.4";
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0001C3B0 File Offset: 0x0001A5B0
		private void dtp_Start_CloseUp(object sender, EventArgs e)
		{
			DateTimePicker dateTimePicker = (DateTimePicker)sender;
			DateTime value = dateTimePicker.Value;
			value = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
			DateTime now = DateTime.Now;
			now = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
			if (value > now)
			{
				this.dtp_Start.Value = now;
				MessageBox.Show("Please select previously day.");
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0001C430 File Offset: 0x0001A630
		private void dtp_End_CloseUp(object sender, EventArgs e)
		{
			DateTimePicker dateTimePicker = (DateTimePicker)sender;
			DateTime value = dateTimePicker.Value;
			value = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
			DateTime now = DateTime.Now;
			now = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
			if (value > now)
			{
				this.dtp_End.Value = now;
				MessageBox.Show("Please select previously day.");
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0001C4AF File Offset: 0x0001A6AF
		private void cmdViewExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridInventoryList);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0001C4C0 File Offset: 0x0001A6C0
		private void cmbInventoryType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbInventoryType.Text == "BlacklistTrend")
			{
				this.cmbFailMode.Enabled = true;
				this.cmbFailMode.SelectedIndex = 0;
				return;
			}
			if (this.cmbInventoryType.Text == "SlotBlacklistTrend")
			{
				this.cmbFailMode.Enabled = false;
				this.cmbFailMode.SelectedIndex = -1;
				this.cmbProduct.Enabled = false;
				this.cmbProduct.SelectedIndex = -1;
				return;
			}
			this.cmbFailMode.Enabled = false;
			this.cmbFailMode.SelectedIndex = -1;
			this.cmbProduct.Enabled = true;
			this.cmbProduct.SelectedIndex = -1;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0001C578 File Offset: 0x0001A778
		private void chart_CarrierView_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left)
				{
					HitTestResult hitTestResult = this.chart_CarrierView.HitTest(e.X, e.Y);
					int num = 1;
					if (this.cmbInventoryType.Text == "DeviceUtil" || this.cmbInventoryType.Text == "TesterUtil")
					{
						num = 2;
					}
					if (hitTestResult.ChartElementType == ChartElementType.DataPoint || hitTestResult.ChartElementType == ChartElementType.DataPointLabel)
					{
						int pointIndex = this.chart_CarrierView.HitTest(e.X, e.Y).PointIndex;
						if (pointIndex >= 0)
						{
							this.gridInventoryList.Selection.FocusRow(pointIndex + num);
							this.gridInventoryList.Selection.SelectRow(pointIndex + num, true);
						}
					}
					else if (hitTestResult.ChartElementType == ChartElementType.AxisLabels)
					{
						int pointIndex2 = this.chart_CarrierView.HitTest(e.X, e.Y - 60).PointIndex;
						if (pointIndex2 >= 0)
						{
							this.gridInventoryList.Selection.FocusRow(pointIndex2 + num);
							this.gridInventoryList.Selection.SelectRow(pointIndex2 + num, true);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0001C6C4 File Offset: 0x0001A8C4
		private void chart_CarrierView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			HitTestResult hitTestResult = this.chart_CarrierView.HitTest(e.X, e.Y);
			int num = 1;
			if (this.cmbInventoryType.Text == "DeviceUtil" || this.cmbInventoryType.Text == "TesterUtil")
			{
				num = 2;
			}
			if (hitTestResult.ChartElementType == ChartElementType.DataPoint || hitTestResult.ChartElementType == ChartElementType.DataPointLabel)
			{
				int pointIndex = this.chart_CarrierView.HitTest(e.X, e.Y).PointIndex;
				if (this.cmbInventoryType.Text == "SlotBlacklistTrend")
				{
					new SlotBlackListClustered(this._slAllData.GetKey(pointIndex).ToString().Trim(), this._slSlotType)
					{
						_factorySetting = this._factorySetting,
						_cimitarUser = this._cimitarUser
					}.ShowDialog();
				}
				if (pointIndex >= 0)
				{
					this.gridInventoryList.Selection.FocusRow(pointIndex + num);
					this.gridInventoryList.Selection.SelectRow(pointIndex + num, true);
				}
			}
			else if (hitTestResult.ChartElementType == ChartElementType.AxisLabels)
			{
				int pointIndex2 = this.chart_CarrierView.HitTest(e.X, e.Y - 60).PointIndex;
				if (pointIndex2 >= 0)
				{
					this.gridInventoryList.Selection.FocusRow(pointIndex2 + num);
					this.gridInventoryList.Selection.SelectRow(pointIndex2 + num, true);
				}
			}
			this.gridInventoryList_DoubleClick(null, null);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0001C83C File Offset: 0x0001AA3C
		private void getCarrierStatus()
		{
			DataSet dataSet = new DataSet();
			try
			{
				dataSet = this.getTypeDefinitionList("CarrierStatus");
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.chkcmbHistoryStatus.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
					this.chkcmbStatus.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0001C908 File Offset: 0x0001AB08
		private void cmdHistorySearch_Click(object sender, EventArgs e)
		{
			if (this.chkHistoryCarrierBarcode.Checked)
			{
				if (!this.chkDate.Checked)
				{
					if (this.txtHistoryBarcode.Text.Trim() == string.Empty)
					{
						MessageBox.Show("Please input Carrier Barcode.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (this.txtHistoryBarcode.Text.Trim().Length < 3)
					{
						MessageBox.Show("Please enter at least 5 digits for the Carrier Barcode..", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				SortedList sortedList = new SortedList();
				if (this.txtHistoryBarcode.Text.Trim() != string.Empty)
				{
					string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierList] @location = '%" + this.txtHistoryBarcode.Text.Trim() + "%'";
					DataSet dataSet = this.queryMgr.queryCall(sQuery);
					if (dataSet == null || dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
					{
						MessageBox.Show("Carrier does not exist.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (dataSet.Tables[0].Rows.Count == 1)
					{
						this.txtHistoryBarcode.Text = dataSet.Tables[0].Rows[0]["location"].ToString();
					}
					else if (dataSet.Tables[0].Rows.Count > 1)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							CarrierInfo carrierInfo = new CarrierInfo();
							carrierInfo.Line = i + 1;
							carrierInfo.Barcode = dataSet.Tables[0].Rows[i]["location"].ToString();
							carrierInfo.Device = dataSet.Tables[0].Rows[i]["device"].ToString();
							carrierInfo.CarrierNo = dataSet.Tables[0].Rows[i]["carrierno"].ToString();
							carrierInfo.CarrierType = dataSet.Tables[0].Rows[i]["carriertype"].ToString();
							carrierInfo.Status = dataSet.Tables[0].Rows[i]["status"].ToString();
							sortedList.Add(carrierInfo.Line, carrierInfo);
						}
						CarrierList carrierList = new CarrierList();
						carrierList._factorySetting = this._factorySetting;
						carrierList.slResult = sortedList;
						carrierList.ShowDialog();
						this.txtHistoryBarcode.Text = carrierList.sBarcode;
						if (carrierList.sBarcode == string.Empty)
						{
							return;
						}
					}
				}
				CarrierInfo carrierInfo2 = new CarrierInfo();
				carrierInfo2.Barcode = this.txtHistoryBarcode.Text.Trim();
				carrierInfo2.Status = this.chkcmbHistoryStatus.Text;
				carrierInfo2.CarrierType = this.cmbHistoryCarrierType.Text;
				carrierInfo2.Device = this.cmbHistoryProduct.Text;
				carrierInfo2.Customer = this.cmbHistoryCarrierCustomer.Text;
				carrierInfo2.OperationCode = this.cmbHistoryCarrierOpCode.Text;
				carrierInfo2.Correlation = this.cmbHistoryCarrierCorrelation.Text;
				carrierInfo2.TesterName = this.cmbHistoryCarrierTester.Text;
				if (this.chkDate.Checked)
				{
					carrierInfo2.StartDate = this.dtp_Start_History.Text;
					carrierInfo2.EndDate = this.dtp_End_Histroy.Text;
				}
				this.getCarrierHistory(carrierInfo2, this.gridSearchHistory, true);
				return;
			}
			this.getCarrierHistory(new CarrierInfo
			{
				Barcode = this.txtHistoryBarcode.Text.Trim(),
				Status = this.chkcmbHistoryStatus.Text,
				CarrierType = this.cmbHistoryCarrierType.Text,
				Device = this.cmbHistoryProduct.Text,
				Customer = this.cmbHistoryCarrierCustomer.Text,
				OperationCode = this.cmbHistoryCarrierOpCode.Text,
				Correlation = this.cmbHistoryCarrierCorrelation.Text,
				TesterName = this.cmbHistoryCarrierTester.Text,
				StartDate = this.dtp_Start_History.Text,
				DateSearchMode = "1"
			}, this.gridSearchHistory, true);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0001CDAF File Offset: 0x0001AFAF
		private void cmdHistoryExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridSearchHistory);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0001CDBD File Offset: 0x0001AFBD
		private void txtHistoryBarcode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.cmdHistorySearch_Click(null, null);
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0001CDD1 File Offset: 0x0001AFD1
		private void rdoDateOption_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdoPeriod.Checked)
			{
				this.dtp_Start.Enabled = true;
				this.dtp_End.Enabled = true;
				return;
			}
			this.dtp_Start.Enabled = false;
			this.dtp_End.Enabled = false;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0001CE14 File Offset: 0x0001B014
		private void dtp_start_SIB_CloseUp(object sender, EventArgs e)
		{
			DateTimePicker dateTimePicker = (DateTimePicker)sender;
			DateTime value = dateTimePicker.Value;
			value = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
			DateTime now = DateTime.Now;
			now = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
			if (value > now)
			{
				this.dtp_start_SIB.Value = now;
				MessageBox.Show("Please select previously day.");
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0001CE94 File Offset: 0x0001B094
		private void dtp_end_SIB_CloseUp(object sender, EventArgs e)
		{
			DateTimePicker dateTimePicker = (DateTimePicker)sender;
			DateTime value = dateTimePicker.Value;
			value = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
			DateTime now = DateTime.Now;
			now = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
			if (value > now)
			{
				this.dtp_end_SIB.Value = now;
				MessageBox.Show("Please select previously day.");
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0001CF14 File Offset: 0x0001B114
		private void GetSIBType()
		{
			try
			{
				this._slCarrierTypeSIB.Clear();
				CCarrierType ccarrierType = new CCarrierType();
				ccarrierType.strTypeValue = "Fail";
				this._slCarrierTypeSIB.Add(ccarrierType.strTypeValue, ccarrierType);
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0001CF6C File Offset: 0x0001B16C
		private void initGridDefectStatus(string sType)
		{
			if (sType == "TotalData")
			{
				this.gridSIBStatusList.ColumnsCount = 5;
				this.gridSIBStatusList.RowsCount = 1;
				this.gridSIBStatusList.FixedRows = 1;
				this.gridSIBStatusList.FixedColumns = 1;
				this.gridSIBStatusList[0, 0] = new GridInfo.ColHeader("No", false);
				this.gridSIBStatusList[0, 1] = new GridInfo.ColHeader("Date", false);
				this.gridSIBStatusList[0, 2] = new GridInfo.ColHeader("Carrier", false);
				this.gridSIBStatusList[0, 3] = new GridInfo.ColHeader("SIB", false);
				this.gridSIBStatusList[0, 4] = new GridInfo.ColHeader("Daily Defect", false);
			}
			else if (sType == "PeriodData")
			{
				this.gridSIBStatusList.ColumnsCount = 11;
				this.gridSIBStatusList.RowsCount = 1;
				this.gridSIBStatusList.FixedRows = 1;
				this.gridSIBStatusList.FixedColumns = 1;
				this.gridSIBStatusList[0, 0] = new GridInfo.ColHeader("No", false);
				this.gridSIBStatusList[0, 1] = new GridInfo.ColHeader("Date", false);
				this.gridSIBStatusList[0, 2] = new GridInfo.ColHeader("Barcode", false);
				this.gridSIBStatusList[0, 3] = new GridInfo.ColHeader("Rev", false);
				this.gridSIBStatusList[0, 4] = new GridInfo.ColHeader("Defect Code", false);
				this.gridSIBStatusList[0, 5] = new GridInfo.ColHeader("Damage", false);
				this.gridSIBStatusList[0, 6] = new GridInfo.ColHeader("Suspect Cause", false);
				this.gridSIBStatusList[0, 7] = new GridInfo.ColHeader("Action", false);
				this.gridSIBStatusList[0, 8] = new GridInfo.ColHeader("Remark", false);
				this.gridSIBStatusList[0, 9] = new GridInfo.ColHeader("HistoryId", false);
				this.gridSIBStatusList[0, 10] = new GridInfo.ColHeader("Device", false);
				this.gridSIBStatusList.Columns[9].Visible = false;
				this.gridSIBStatusList.Columns[10].Visible = false;
			}
			this.gridInfo.SetColumnCellColor(this.gridSIBStatusList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridSIBStatusList);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
		private void BindingDefectGrid(string sType)
		{
			this.gridSIBStatusList.RowsCount = 1;
			if (sType == "TotalData")
			{
				using (IDictionaryEnumerator enumerator = this._slAllDataSIB.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
						string str = dictionaryEntry.Key.ToString();
						CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
						this.gridSIBStatusList.Rows.Insert(this.gridSIBStatusList.RowsCount);
						this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 0] = new SourceGrid.Cells.Cell((this.gridSIBStatusList.RowsCount - 1).ToString() + " ");
						this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 1] = new SourceGrid.Cells.Cell(str + " ");
						this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 2] = new SourceGrid.Cells.Cell(ccarrierData.iCarrierCount + " ");
						this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 3] = new SourceGrid.Cells.Cell(ccarrierData.iDutCount + " ");
						this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 4] = new SourceGrid.Cells.Cell(ccarrierData.iCarrierCount + ccarrierData.iDutCount + " ");
					}
					goto IL_425;
				}
			}
			if (sType == "PeriodData")
			{
				for (int i = 0; i < this._slAllDataSIB.Count; i++)
				{
					CCarrierData ccarrierData2 = (CCarrierData)this._slAllDataSIB.GetByIndex(i);
					for (int j = 0; j < ccarrierData2.slCarrierDataHistory.Count; j++)
					{
						CCarrierDataHistory ccarrierDataHistory = (CCarrierDataHistory)ccarrierData2.slCarrierDataHistory.GetByIndex(j);
						if ((this.chkDefectCarrier.Checked && ccarrierDataHistory.strcarriertype == "CARRIER") || (this.chkDefectSIB.Checked && ccarrierDataHistory.strcarriertype == "DUT"))
						{
							this.gridSIBStatusList.Rows.Insert(this.gridSIBStatusList.RowsCount);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 0] = new SourceGrid.Cells.Cell((this.gridSIBStatusList.RowsCount - 1).ToString() + " ");
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 1] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strlasteventtime);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 2] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strbarcode);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 3] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strrevision);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 4] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strrepaircode);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 5] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strdamage);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 6] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strsuspectcause);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 7] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strrepaircode1);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 8] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strmemo);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 9] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strid);
							this.gridSIBStatusList[this.gridSIBStatusList.RowsCount - 1, 10] = new SourceGrid.Cells.Cell(ccarrierDataHistory.strdevice);
						}
					}
				}
			}
			IL_425:
			this.gridInfo.AutoSetGrid(this.gridSIBStatusList);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0001D644 File Offset: 0x0001B844
		private void GetDefectPeriodData()
		{
			try
			{
				DataSet dataSet = new DataSet();
				int num = 1;
				DateTime dateTime = default(DateTime);
				DateTime t = default(DateTime);
				if (this.rdoDay_SIB.Checked)
				{
					dateTime = DateTime.Now;
					t = DateTime.Now;
				}
				else if (this.rdoWeek_SIB.Checked)
				{
					dateTime = DateTime.Now.AddDays(-6.0);
					t = DateTime.Now;
				}
				else if (this.rdoMonth_SIB.Checked)
				{
					dateTime = DateTime.Now.AddDays(-29.0);
					t = DateTime.Now;
				}
				else if (this.rdoPeriod_SIB.Checked)
				{
					dateTime = this.dtp_start_SIB.Value;
					t = this.dtp_end_SIB.Value;
				}
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
				t = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				TimeSpan timeSpan = t.Subtract(dateTime);
				this._barPrograss.setMax(timeSpan.Days + 1);
				DateTime t2 = dateTime;
				while (t2 <= t)
				{
					try
					{
						string text = t2.ToString("yyyy-MM-dd");
						string text2 = t2.ToString("yyyy-MM-dd");
						string text3 = this.cmbProduct.Text;
						string text4 = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetDefectDailyData] @startdate  = '",
							text,
							"', @product  = '",
							this.cmbDefectProduct.Text,
							"'"
						});
						dataSet = this.queryMgr.queryCall(text4);
						CCarrierData ccarrierData = new CCarrierData();
						foreach (object obj in this._slCarrierTypeSIB)
						{
							CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj).Value;
							ccarrierData.slTypeCount.Add(ccarrierType.strTypeValue, 0);
						}
						Console.WriteLine("strQuery defect : " + text4);
						this._barPrograss.setValue(num++);
						if (dataSet.Tables.Count > 1)
						{
							int index = 0;
							for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
							{
								CCarrierDataHistory ccarrierDataHistory = new CCarrierDataHistory();
								ccarrierDataHistory.strcategory = dataSet.Tables[index].Rows[i]["category"].ToString();
								ccarrierDataHistory.strid = dataSet.Tables[index].Rows[i]["id"].ToString();
								ccarrierDataHistory.strcarrierid = dataSet.Tables[index].Rows[i]["carrierid"].ToString();
								ccarrierDataHistory.strdevice = dataSet.Tables[index].Rows[i]["device"].ToString();
								ccarrierDataHistory.strcarrierno = dataSet.Tables[index].Rows[i]["carrierno"].ToString();
								ccarrierDataHistory.stroperationcode = dataSet.Tables[index].Rows[i]["operationcode"].ToString();
								ccarrierDataHistory.strcarriertype = dataSet.Tables[index].Rows[i]["carriertype"].ToString();
								ccarrierDataHistory.strcustomer = dataSet.Tables[index].Rows[i]["customer"].ToString();
								ccarrierDataHistory.strsite = dataSet.Tables[index].Rows[i]["site"].ToString();
								ccarrierDataHistory.strtestername = dataSet.Tables[index].Rows[i]["testername"].ToString();
								ccarrierDataHistory.strpkgtype = dataSet.Tables[index].Rows[i]["pkgtype"].ToString();
								ccarrierDataHistory.strbarcode = dataSet.Tables[index].Rows[i]["location"].ToString();
								ccarrierDataHistory.strstatus = dataSet.Tables[index].Rows[i]["status"].ToString();
								ccarrierDataHistory.strtouchdowncnt = dataSet.Tables[index].Rows[i]["touchdowncnt"].ToString();
								ccarrierDataHistory.strcleancnt = dataSet.Tables[index].Rows[i]["cleancnt"].ToString();
								ccarrierDataHistory.strrepaircnt = dataSet.Tables[index].Rows[i]["repaircnt"].ToString();
								ccarrierDataHistory.strlimitcleancnt = dataSet.Tables[index].Rows[i]["limitcleancnt"].ToString();
								ccarrierDataHistory.strlimitrepaircnt = dataSet.Tables[index].Rows[i]["limitrepaircnt"].ToString();
								ccarrierDataHistory.strmemo = dataSet.Tables[index].Rows[i]["memo"].ToString();
								ccarrierDataHistory.strlastcleantime = dataSet.Tables[index].Rows[i]["lastcleantime"].ToString();
								ccarrierDataHistory.strlastrepairtime = dataSet.Tables[index].Rows[i]["lastrepairtime"].ToString();
								ccarrierDataHistory.strcreateuser = dataSet.Tables[index].Rows[i]["createuser"].ToString();
								ccarrierDataHistory.strcreatetime = dataSet.Tables[index].Rows[i]["createtime"].ToString();
								ccarrierDataHistory.strlasteventuser = dataSet.Tables[index].Rows[i]["lasteventuser"].ToString();
								ccarrierDataHistory.strlasteventtime = dataSet.Tables[index].Rows[i]["lasteventtime"].ToString();
								ccarrierDataHistory.strcorrelation = dataSet.Tables[index].Rows[i]["correlation"].ToString();
								ccarrierDataHistory.strrepaircode = dataSet.Tables[index].Rows[i]["repaircode"].ToString();
								ccarrierDataHistory.strrepaircode1 = dataSet.Tables[index].Rows[i]["repaircode1"].ToString();
								ccarrierDataHistory.strrevision = dataSet.Tables[index].Rows[i]["revision"].ToString();
								ccarrierDataHistory.strdamage = dataSet.Tables[index].Rows[i]["damage"].ToString();
								ccarrierDataHistory.strsuspectcause = dataSet.Tables[index].Rows[i]["suspectcause"].ToString();
								ccarrierData.slCarrierDataHistory.Add(i, ccarrierDataHistory);
								if (ccarrierDataHistory.strcarriertype == "CARRIER")
								{
									ccarrierData.iCarrierCount++;
								}
								else if (ccarrierDataHistory.strcarriertype == "DUT")
								{
									ccarrierData.iDutCount++;
									if (ccarrierData.slTypeCount.ContainsKey(ccarrierDataHistory.strcategory))
									{
										int num2 = (int)ccarrierData.slTypeCount[ccarrierDataHistory.strcategory];
										num2++;
										ccarrierData.slTypeCount[ccarrierDataHistory.strcategory] = num2;
									}
								}
							}
							index = 1;
							ccarrierData.strTotalCount = dataSet.Tables[index].Rows[0]["totalQty"].ToString();
						}
						this._slAllDataSIB.Add(text2, ccarrierData);
						this.cmbSIBPeriodDate.Items.Add(text2);
					}
					catch (Exception ex)
					{
						ex.ToString();
					}
					t2 = t2.AddDays(1.0);
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex2)
			{
				ex2.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0001E090 File Offset: 0x0001C290
		private void InitChart_DefectView()
		{
			if (this.chart_SIBView.Series.Count > 0)
			{
				this.chart_SIBView.Series.Clear();
			}
			this.chart_SIBView.ChartAreas[0].AxisX.CustomLabels.Clear();
			this.chart_SIBView.Update();
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0001E0EC File Offset: 0x0001C2EC
		private void CreateSeries_DefectView()
		{
			foreach (object obj in this._slCarrierTypeSIB)
			{
				CCarrierType ccarrierType = (CCarrierType)((DictionaryEntry)obj).Value;
				Series series = new Series();
				series.ChartType = SeriesChartType.StackedColumn;
				series.ChartArea = "ChartArea1";
				series.Font = new Font("Segoe UI", 8f);
				series.LabelForeColor = Color.Empty;
				series.XValueType = ChartValueType.String;
				series.YValueType = ChartValueType.Int32;
				series.Legend = "Legend1";
				series.LegendText = ccarrierType.strTypeValue;
				series.Name = ccarrierType.strTypeValue;
				if (ccarrierType.strTypeValue == "Fail")
				{
					series.Color = Color.Tomato;
				}
				else if (ccarrierType.strTypeValue == "Pass")
				{
					series.Color = Color.DodgerBlue;
				}
				this.chart_SIBView.Series.Add(series);
			}
			Series series2 = new Series();
			series2.ChartType = SeriesChartType.Line;
			series2.ChartArea = "ChartArea1";
			series2.Font = new Font("Segoe UI", 8f);
			series2.LabelForeColor = Color.Empty;
			series2.XValueType = ChartValueType.String;
			series2.YValueType = ChartValueType.Int32;
			series2.Legend = "Legend1";
			series2.LegendText = "Total";
			series2.Name = "Total";
			series2.Color = Color.Black;
			this.chart_SIBView.Series.Add(series2);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0001E294 File Offset: 0x0001C494
		private void DrawChart_DefectView()
		{
			this.InitChart_DefectView();
			this.CreateSeries_DefectView();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			double num4 = 1.5;
			string toolTip = string.Empty;
			foreach (object obj in this._slAllDataSIB)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key.ToString();
				CCarrierData ccarrierData = (CCarrierData)dictionaryEntry.Value;
				int num5 = Convert.ToInt32(ccarrierData.strTotalCount);
				this.chart_SIBView.Series["Total"].Points.Add(new double[]
				{
					(double)num5
				});
				toolTip = "Total\r\n" + ccarrierData.strTotalCount;
				this.chart_SIBView.Series["Total"].Points[num].ToolTip = toolTip;
				this.chart_SIBView.Series["Total"].Points[num].Label = ccarrierData.strTotalCount;
				this.chart_SIBView.Series["Total"].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
				this.chart_SIBView.Series["Total"].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
				this.chart_SIBView.Series["Total"].YAxisType = AxisType.Secondary;
				this.chart_SIBView.Series["Total"].MarkerStyle = MarkerStyle.Circle;
				this.chart_SIBView.Series["Total"].BorderWidth = 2;
				foreach (object obj2 in ccarrierData.slTypeCount)
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
					string text2 = dictionaryEntry2.Key.ToString();
					int num6 = (int)dictionaryEntry2.Value;
					this.chart_SIBView.Series[text2].Points.Add(new double[]
					{
						(double)num6
					});
					toolTip = text2 + "\r\n" + num6.ToString();
					this.chart_SIBView.Series[text2].Points[num].ToolTip = toolTip;
					if (num6 > 0)
					{
						this.chart_SIBView.Series[text2].Points[num].Label = num6.ToString();
						this.chart_SIBView.Series[text2].Font = new Font("Segoe UI", 8f, FontStyle.Regular);
						this.chart_SIBView.Series[text2].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
					}
					num2 += num6;
				}
				if (num2 > num3)
				{
					num3 = num2;
				}
				CustomLabel customLabel = new CustomLabel();
				customLabel.Text = text;
				customLabel.FromPosition = 0.5;
				if (num == 0)
				{
					customLabel.ToPosition = num4;
				}
				else
				{
					num4 += 2.0;
					customLabel.ToPosition = num4;
				}
				customLabel.RowIndex = 0;
				this.chart_SIBView.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
				this.chart_SIBView.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_SIBView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_SIBView.ChartAreas[0].Position.Auto = false;
			this.chart_SIBView.ChartAreas[0].Position.X = 0f;
			this.chart_SIBView.ChartAreas[0].Position.Y = 10f;
			this.chart_SIBView.ChartAreas[0].Position.Height = 75f;
			this.chart_SIBView.ChartAreas[0].Position.Width = 99f;
			this.chart_SIBView.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_SIBView.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_SIBView.ChartAreas[0].AxisX.Maximum = (double)(this._slAllDataSIB.Count + 1);
			this.chart_SIBView.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_SIBView.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_SIBView.ChartAreas[0].AxisX.Interval = 2.0;
			this.chart_SIBView.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_SIBView.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_SIBView.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_SIBView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_SIBView.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_SIBView.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_SIBView.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_SIBView.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
			this.chart_SIBView.ChartAreas[0].AxisY2.Maximum = double.NaN;
			this.chart_SIBView.ChartAreas[0].RecalculateAxesScale();
			double num7 = Math.Ceiling(Convert.ToDouble(num3) / 100.0) * 100.0;
			if (num7 == 0.0)
			{
				this.chart_SIBView.ChartAreas[0].AxisY.Maximum = 10.0;
			}
			else
			{
				this.chart_SIBView.ChartAreas[0].AxisY.Maximum = num7;
			}
			for (int i = 0; i < this.chart_SIBView.Series.Count; i++)
			{
				this.chart_SIBView.Series[i]["PointWidth"] = "0.4";
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0001EA10 File Offset: 0x0001CC10
		private void cmdDefectSearch_Click(object sender, EventArgs e)
		{
			this.cmdDefectSearch.Focus();
			this.cmbSIBPeriodDate.Items.Clear();
			this._slAllDataSIB.Clear();
			this.GetSIBType();
			this.GetDefectPeriodData();
			if (this.rdoTotalData.Checked)
			{
				this.initGridDefectStatus("TotalData");
				this.BindingDefectGrid("TotalData");
			}
			else
			{
				this.initGridDefectStatus("PeriodData");
				this.BindingDefectGrid("PeriodData");
			}
			this.DrawChart_DefectView();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0001EA91 File Offset: 0x0001CC91
		private void cmdDefectExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridSIBStatusList);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0001EA9F File Offset: 0x0001CC9F
		private void cmbDefectProduct_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbDefectProduct);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0001EAB4 File Offset: 0x0001CCB4
		private void rdoTotalData_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				this.panelDetail.Visible = false;
				this.cmbSIBPeriodDate.SelectedIndex = -1;
				this.cmbSIBPeriodDate.Enabled = false;
				this.initGridDefectStatus("TotalData");
				this.BindingDefectGrid("TotalData");
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0001EB0C File Offset: 0x0001CD0C
		private void rdoPeriodData_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				this.panelDetail.Visible = true;
				if (this.cmbSIBPeriodDate.Items.Count > 0 && this.cmbSIBPeriodDate.SelectedIndex < 0)
				{
					this.cmbSIBPeriodDate.SelectedIndex = 0;
				}
				this.cmbSIBPeriodDate.Enabled = true;
				this.initGridDefectStatus("PeriodData");
				this.BindingDefectGrid("PeriodData");
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0001EB83 File Offset: 0x0001CD83
		private void chkDefectCarrier_CheckedChanged(object sender, EventArgs e)
		{
			this.BindingDefectGrid("PeriodData");
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0001EB90 File Offset: 0x0001CD90
		private void chkDefectSIB_CheckedChanged(object sender, EventArgs e)
		{
			this.BindingDefectGrid("PeriodData");
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0001EB9D File Offset: 0x0001CD9D
		private void cmbSIBPeriodDate_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.rdoPeriodData.Checked)
			{
				this.initGridDefectStatus("PeriodData");
				this.BindingDefectGrid("PeriodData");
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0001EBC2 File Offset: 0x0001CDC2
		private void txtStatusSIB1Barcode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.txtStatusSIB2Barcode.Text = string.Empty;
				this.txtStatusSIB2Barcode.Focus();
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0001EBEA File Offset: 0x0001CDEA
		private void cmbMgrType_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierMgrType", this.cmbMgrType);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0001EBFE File Offset: 0x0001CDFE
		private void cmbMgrProduct_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbMgrProduct);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0001EC12 File Offset: 0x0001CE12
		private void cmbMgrTester_DropDown(object sender, EventArgs e)
		{
			this.getTesterList(this.cmbMgrTester);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0001EC20 File Offset: 0x0001CE20
		private void initMgrCarrierList()
		{
			this.gridMgrCarrier.ColumnsCount = 21;
			this.gridMgrCarrier.RowsCount = 2;
			this.gridMgrCarrier.FixedRows = 2;
			this.gridMgrCarrier.FixedColumns = 11;
			this.gridMgrCarrier[0, 0] = new GridInfo.ColHeader("", false);
			this.gridMgrCarrier[0, 0].RowSpan = 2;
			this.gridMgrCarrier[0, 1] = new GridInfo.ColHeader("No", false);
			this.gridMgrCarrier[0, 1].RowSpan = 2;
			this.gridMgrCarrier[0, 2] = new GridInfo.ColHeader("CarrierId", false);
			this.gridMgrCarrier[0, 2].RowSpan = 2;
			this.gridMgrCarrier[0, 3] = new GridInfo.ColHeader("Carriers", false);
			this.gridMgrCarrier[0, 3].ColumnSpan = 2;
			this.gridMgrCarrier[0, 5] = new GridInfo.ColHeader("Yields", false);
			this.gridMgrCarrier[0, 5].ColumnSpan = 2;
			this.gridMgrCarrier[0, 7] = new GridInfo.ColHeader("Result", false);
			this.gridMgrCarrier[0, 7].ColumnSpan = 4;
			this.gridMgrCarrier[0, 11] = new GridInfo.ColHeader("Last Location", false);
			this.gridMgrCarrier[0, 11].ColumnSpan = 3;
			this.gridMgrCarrier[0, 14] = new GridInfo.ColHeader("Repair", false);
			this.gridMgrCarrier[0, 14].ColumnSpan = 1;
			this.gridMgrCarrier[0, 15] = new GridInfo.ColHeader("Reset Info", false);
			this.gridMgrCarrier[0, 15].ColumnSpan = 2;
			this.gridMgrCarrier[0, 17] = new GridInfo.ColHeader("Most Seen SoftBin", false);
			this.gridMgrCarrier[0, 17].ColumnSpan = 2;
			this.gridMgrCarrier[0, 19] = new GridInfo.ColHeader("Second Seen SoftBin", false);
			this.gridMgrCarrier[0, 19].ColumnSpan = 2;
			this.gridMgrCarrier[1, 3] = new GridInfo.ColHeader("Barcode", false);
			this.gridMgrCarrier[1, 4] = new GridInfo.ColHeader("Site", false);
			this.gridMgrCarrier[1, 5] = new GridInfo.ColHeader("Barcode", true);
			this.gridMgrCarrier[1, 6] = new GridInfo.ColHeader("Site", false);
			this.gridMgrCarrier[1, 7] = new GridInfo.ColHeader("Test", false);
			this.gridMgrCarrier[1, 8] = new GridInfo.ColHeader("Pass", false);
			this.gridMgrCarrier[1, 9] = new GridInfo.ColHeader("Fail", false);
			this.gridMgrCarrier[1, 10] = new GridInfo.ColHeader("Status", false);
			this.gridMgrCarrier[1, 11] = new GridInfo.ColHeader("System", false);
			this.gridMgrCarrier[1, 12] = new GridInfo.ColHeader("Location", false);
			this.gridMgrCarrier[1, 13] = new GridInfo.ColHeader("Last Updated", false);
			this.gridMgrCarrier[1, 14] = new GridInfo.ColHeader("Count", false);
			this.gridMgrCarrier[1, 15] = new GridInfo.ColHeader("Date", false);
			this.gridMgrCarrier[1, 16] = new GridInfo.ColHeader("Reason", false);
			this.gridMgrCarrier[1, 17] = new GridInfo.ColHeader("Name", false);
			this.gridMgrCarrier[1, 18] = new GridInfo.ColHeader("Count", false);
			this.gridMgrCarrier[1, 19] = new GridInfo.ColHeader("Name", false);
			this.gridMgrCarrier[1, 20] = new GridInfo.ColHeader("Count", false);
			this.gridMgrCarrier.Rows[0].Tag = "Header";
			this.gridMgrCarrier.Rows[1].Tag = "Header";
			this.gridMgrCarrier.Columns[0].Width = 30;
			this.gridMgrCarrier.Columns[1].Width = 40;
			this.gridMgrCarrier.Columns[3].Width = 150;
			this.gridMgrCarrier.Columns[4].Width = 30;
			this.gridMgrCarrier.Columns[5].Width = 50;
			this.gridMgrCarrier.Columns[6].Width = 50;
			this.gridMgrCarrier.Columns[10].Width = 80;
			this.gridMgrCarrier.Columns[11].Width = 80;
			this.gridMgrCarrier.Columns[12].Width = 80;
			this.gridMgrCarrier.Columns[13].Width = 140;
			this.gridMgrCarrier.Columns[14].Width = 60;
			this.gridMgrCarrier.Columns[15].Width = 150;
			this.gridMgrCarrier.Columns[16].Width = 100;
			this.gridMgrCarrier.Columns[17].Width = 150;
			this.gridMgrCarrier.Columns[18].Width = 50;
			this.gridMgrCarrier.Columns[19].Width = 150;
			this.gridMgrCarrier.Columns[20].Width = 50;
			this.gridInfo.CreateColHeaderCheckBox(this.gridMgrCarrier, new System.Windows.Forms.CheckBox(), 2);
			this.gridInfo.SetColumnCellColor(this.gridMgrCarrier, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridMgrCarrier, 1, this.gridInfo.CellColor.cell_gray_center);
			this.gridMgrCarrier.Columns[2].Visible = false;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0001F258 File Offset: 0x0001D458
		private void getCarrierMgrList()
		{
			try
			{
				int num = 2;
				string empty = string.Empty;
				string text = this.txtMgrBarcode.Text;
				if (this.chkBarcodeFlag.Checked)
				{
					for (int i = 2; i < this.gridMgrCarrier.RowsCount; i++)
					{
						if (!this._slSelectedCarrier.ContainsKey(this.gridMgrCarrier[i, 3].ToString()))
						{
							this._slSelectedCarrier.Add(this.gridMgrCarrier[i, 3].ToString(), this.gridMgrCarrier[i, 1].ToString());
						}
					}
					text = this.getInput(text);
					for (int j = 0; j < this._slSelectedCarrier.Count; j++)
					{
						text += ",";
						text += this._slSelectedCarrier.GetKey(j);
					}
				}
				else
				{
					this._slSelectedCarrier.Clear();
					text = this.getInput(text);
				}
				this.gridMgrCarrier.RowsCount = num;
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierList_PerSite]  @type = '",
					this.cmbMgrType.Text,
					"', @product = '",
					this.cmbMgrProduct.Text,
					"', @status = '",
					this.chkcmbStatus.Text,
					"', @tester = '",
					this.cmbMgrTester.Text,
					"', @barcode = '",
					text.Trim(),
					"'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
					{
						this.gridMgrCarrier.Rows.Insert(num);
						this.gridMgrCarrier[num, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
						this.gridMgrCarrier[num, 1] = new SourceGrid.Cells.Cell(num - 1);
						this.gridMgrCarrier[num, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["carrierid"]);
						this.gridMgrCarrier[num, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["barcode"]);
						this.gridMgrCarrier[num, 4] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["site"]);
						string str = dataSet.Tables[0].Rows[k]["carrierid"].ToString();
						int num2 = int.Parse(dataSet.Tables[0].Rows[k]["testqty"].ToString());
						int num3 = int.Parse(dataSet.Tables[0].Rows[k]["passqty"].ToString());
						double num4 = 0.0;
						int num5 = 0;
						int num6 = 0;
						double num7 = 0.0;
						string filterExpression = "carrierid = '" + str + "'";
						DataRow[] array = dataSet.Tables[0].Select(filterExpression);
						foreach (DataRow dataRow in array)
						{
							num5 += int.Parse(dataRow["testqty"].ToString());
							num6 += int.Parse(dataRow["passqty"].ToString());
						}
						if (num2 > 0)
						{
							num4 = Math.Round((double)num3 / (double)num2 * 100.0, 2);
						}
						if (num5 > 0)
						{
							num7 = Math.Round((double)num6 / (double)num5 * 100.0, 2);
						}
						this.gridMgrCarrier[num, 5] = new SourceGrid.Cells.Cell(num7.ToString());
						this.gridMgrCarrier[num, 6] = new SourceGrid.Cells.Cell(num4.ToString());
						this.gridMgrCarrier[num, 7] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["testqty"]);
						this.gridMgrCarrier[num, 8] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["passqty"]);
						this.gridMgrCarrier[num, 9] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["failqty"]);
						this.gridMgrCarrier[num, 10] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["status"]);
						this.gridMgrCarrier[num, 11] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["testername"]);
						this.gridMgrCarrier[num, 12] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["location"]);
						this.gridMgrCarrier[num, 13] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["lastupdatetime"]);
						this.gridMgrCarrier[num, 14] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["repaircnt"]);
						this.gridMgrCarrier[num, 15] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["resetdate"]);
						this.gridMgrCarrier[num, 16] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["resetreason"]);
						this.gridMgrCarrier[num, 17] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["top1sbin"]);
						this.gridMgrCarrier[num, 18] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["top1sbincnt"]);
						this.gridMgrCarrier[num, 19] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["top2sbin"]);
						this.gridMgrCarrier[num, 20] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[k]["top2sbincnt"]);
						num++;
						this._barPrograss.setValue(k + 1);
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
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
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0001FAB8 File Offset: 0x0001DCB8
		private void cmdMgrSearch_Click(object sender, EventArgs e)
		{
			this.getCarrierMgrList();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0001FAC0 File Offset: 0x0001DCC0
		private void cmdMgrExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridMgrCarrier);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0001FAD0 File Offset: 0x0001DCD0
		private void checkAllGridCell_Click(object sender, EventArgs e)
		{
			SourceGrid.Grid grid = ((sender as MenuItem).Parent as ContextMenu).SourceControl as SourceGrid.Grid;
			for (int i = 2; i < grid.RowsCount; i++)
			{
				if ((sender as MenuItem).Text == "Check All")
				{
					grid[i, 0].Value = true;
				}
				else
				{
					grid[i, 0].Value = false;
				}
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0001FB48 File Offset: 0x0001DD48
		private void gridMgrCarrier_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Right)
				{
					if (this.gridMgrCarrier.RowsCount > 0)
					{
						this.menuCarrierMgr.Show(this.gridMgrCarrier, new Point(e.X, e.Y));
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0001FBB8 File Offset: 0x0001DDB8
		private void txtMgrBarcode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r' && this.chkBarcodeFlag.Checked)
			{
				this.cmdMgrSearch_Click(null, null);
				this.txtMgrBarcode.SelectAll();
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0001FBE4 File Offset: 0x0001DDE4
		private void checkGridClear_Click(object sender, EventArgs e)
		{
			this.gridMgrCarrier.RowsCount = 2;
			this._slSelectedCarrier.Clear();
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0001FC00 File Offset: 0x0001DE00
		private void cmdReset_Click(object sender, EventArgs e)
		{
			SortedList sortedList = new SortedList();
			try
			{
				if (MessageBox.Show("Do you want to reset?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					ResetReason resetReason = new ResetReason();
					if (resetReason.ShowDialog() == DialogResult.OK)
					{
						string sResult = resetReason.sResult;
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Reset Data....");
						this._barPrograss.setValue(0);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						for (int i = 2; i < this.gridMgrCarrier.RowsCount; i++)
						{
							if ((bool)this.gridMgrCarrier[i, 0].Value)
							{
								this.gridMgrCarrier[i, 2].ToString();
								CarrierInfo carrierInfo = new CarrierInfo();
								carrierInfo.CarrierId = this.gridMgrCarrier[i, 2].ToString();
								if (!sortedList.ContainsKey(carrierInfo.CarrierId))
								{
									sortedList.Add(carrierInfo.CarrierId, carrierInfo);
								}
							}
						}
						if (sortedList.Count == 0)
						{
							MessageBox.Show("please check barcode ", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							this._barPrograss.setMax(sortedList.Count);
							for (int j = 0; j < sortedList.Count; j++)
							{
								CarrierInfo carrierInfo2 = (CarrierInfo)sortedList.GetByIndex(j);
								string sQuery = string.Concat(new string[]
								{
									"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetCarrierReset]  @carrierid = '",
									carrierInfo2.CarrierId,
									"',  @resetreason = '",
									sResult,
									"'"
								});
								this.queryMgr.queryCall(sQuery);
								this._barPrograss.setValue(j + 1);
							}
							this._barPrograss.setMax(100);
							this._barPrograss.setValue(100);
							Thread.Sleep(100);
							if (this._barPrograss != null)
							{
								this._barPrograss._ischeck = true;
							}
							this._barPrograss = null;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0001FE64 File Offset: 0x0001E064
		private void cmdTestHistory_Click(object sender, EventArgs e)
		{
			new SortedList();
			if (this.gridMgrCarrier.Selection.ActivePosition.Row > 0)
			{
				int row = this.gridMgrCarrier.Selection.ActivePosition.Row;
				int column = this.gridMgrCarrier.Selection.ActivePosition.Column;
				CarrierInfo carrierInfo = new CarrierInfo();
				carrierInfo.CarrierId = this.gridMgrCarrier[row, 2].ToString();
				carrierInfo.Barcode = this.gridMgrCarrier[row, 3].ToString();
				carrierInfo.Site = this.gridMgrCarrier[row, 4].ToString();
				carrierInfo.Type = this.cmbMgrType.Text;
				new TestHistory
				{
					_cimitarUser = this._cimitarUser,
					_factorySetting = this._factorySetting,
					carrierInfo = carrierInfo
				}.ShowDialog();
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0001FF54 File Offset: 0x0001E154
		private void gridMgrCarrier_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.cmdTestHistory_Click(null, null);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0001FF5E File Offset: 0x0001E15E
		private void txtMgrBarcode_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.txtMgrBarcode.Height == 300)
			{
				this.txtMgrBarcode.Height = 20;
				return;
			}
			this.txtMgrBarcode.Height = 300;
			this.txtMgrBarcode.BringToFront();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0001FF9C File Offset: 0x0001E19C
		private void initSWVersionList()
		{
			this.gridSWHistory.ColumnsCount = 10;
			this.gridSWHistory.RowsCount = 1;
			this.gridSWHistory.FixedRows = 1;
			this.gridSWHistory.FixedColumns = 1;
			this.gridSWHistory[0, 0] = new GridInfo.ColHeader("", false);
			this.gridSWHistory[0, 1] = new GridInfo.ColHeader("No", false);
			this.gridSWHistory[0, 2] = new GridInfo.ColHeader("VersionID", false);
			this.gridSWHistory[0, 3] = new GridInfo.ColHeader("Version", false);
			this.gridSWHistory[0, 4] = new GridInfo.ColHeader("Approval Date", false);
			this.gridSWHistory[0, 5] = new GridInfo.ColHeader("Fan-Out Done Date", false);
			this.gridSWHistory[0, 6] = new GridInfo.ColHeader("Comment", false);
			this.gridSWHistory[0, 7] = new GridInfo.ColHeader("Attachment File", false);
			this.gridSWHistory[0, 8] = new GridInfo.ColHeader("UpdateUser", false);
			this.gridSWHistory[0, 9] = new GridInfo.ColHeader("UpdateTime", false);
			this.gridInfo.SetColumnCellColor(this.gridSWHistory, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridSWHistory);
			this.gridSWHistory.Columns[1].Visible = false;
			CustomEvents customEvents = new CustomEvents();
			customEvents.Click += this.cellClickEvent_Click;
			this.gridSWHistory.Controller.AddController(customEvents);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00020140 File Offset: 0x0001E340
		private void cellClickEvent_Click(object sender, EventArgs e)
		{
			CellContext cellContext = (CellContext)sender;
			try
			{
				int row = cellContext.Position.Row;
				int column = cellContext.Position.Column;
				SourceGrid.Grid grid = (SourceGrid.Grid)cellContext.Grid;
				SourceGrid.Cells.Cell cell = (SourceGrid.Cells.Cell)cellContext.Cell;
				if (row > 0 && column == 0 && (bool)cell.Value)
				{
					for (int i = 1; i < grid.RowsCount; i++)
					{
						grid[i, 0].Value = false;
					}
					cell.Value = true;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000201F8 File Offset: 0x0001E3F8
		private void getSWVersionList()
		{
			try
			{
				this.gridSWHistory.RowsCount = 1;
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetSWVersion] @version = '" + this.txtSWVersion.Text.Trim() + "'";
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				int num = 1;
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.gridSWHistory.Rows.Insert(num);
						this.gridSWHistory[num, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
						this.gridSWHistory[num, 1] = new SourceGrid.Cells.Cell(i + 1);
						this.gridSWHistory[num, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["id"]);
						this.gridSWHistory[num, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["version"]);
						this.gridSWHistory[num, 4] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["approvaldate"]);
						this.gridSWHistory[num, 5] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["donedate"]);
						this.gridSWHistory[num, 6] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["comment"]);
						this.gridSWHistory[num, 7] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["filename"]);
						this.gridSWHistory[num, 8] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["updateuser"]);
						this.gridSWHistory[num, 9] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["updatetime"]);
						num++;
						this._barPrograss.setValue(i + 1);
					}
				}
				this.gridInfo.AutoSetGrid(this.gridSWHistory);
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00020590 File Offset: 0x0001E790
		private void cmdSWSearch_Click(object sender, EventArgs e)
		{
			this.getSWVersionList();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00020598 File Offset: 0x0001E798
		private void cmdSWExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridSWHistory);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000205A8 File Offset: 0x0001E7A8
		private void cmdSWAdd_Click(object sender, EventArgs e)
		{
			if (new AddCorrelationPartHistory
			{
				_cimitarUser = this._cimitarUser,
				_factorySetting = this._factorySetting,
				Caption = "Create S/W Version",
				sType = "Create"
			}.ShowDialog() == DialogResult.OK)
			{
				this.getSWVersionList();
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000205F8 File Offset: 0x0001E7F8
		private void cmdDelete_Click(object sender, EventArgs e)
		{
			try
			{
				SortedList sortedList = new SortedList();
				for (int i = 1; i < this.gridSWHistory.RowsCount; i++)
				{
					if ((bool)this.gridSWHistory[i, 0].Value)
					{
						SWVersion swversion = new SWVersion();
						swversion.id = this.gridSWHistory[i, 2].ToString();
						swversion.Version = this.gridSWHistory[i, 3].ToString();
						swversion.Approvaldate = this.gridSWHistory[i, 4].ToString();
						swversion.Donedate = this.gridSWHistory[i, 5].ToString();
						swversion.Comment = this.gridSWHistory[i, 6].ToString();
						swversion.Filename = this.gridSWHistory[i, 7].ToString();
						sortedList.Add(swversion.id, swversion);
					}
				}
				if (sortedList.Count == 0)
				{
					MessageBox.Show("Please chheck S/W version", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					DialogResult dialogResult = MessageBox.Show("Do you want to delete SW version?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Yes)
					{
						for (int j = 0; j < sortedList.Count; j++)
						{
							SWVersion swversion2 = (SWVersion)sortedList.GetByIndex(j);
							string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_ApplySWVersion]  @type = 'Remove', @id = '" + swversion2.id + "'";
							DataSet dataSet = this.queryMgr.queryCall(sQuery);
							if (dataSet == null || dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
							{
								MessageBox.Show("Delete Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return;
							}
							if (dataSet.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
							{
								MessageBox.Show("Delete Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return;
							}
							if (swversion2.Filename != string.Empty)
							{
								string id = swversion2.id;
								string filename = swversion2.Filename;
								string text = "\\\\10.121.1.91\\TitanSW";
								string text2 = text;
								text = string.Concat(new string[]
								{
									text2,
									"\\",
									id,
									"\\",
									filename
								});
								if (File.Exists(text))
								{
									File.Delete(text);
								}
							}
							MessageBox.Show("Delete Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						this.cmdSWSearch_Click(null, null);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				MessageBox.Show("Delete Fail : " + ex.Message.ToString(), "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000208EC File Offset: 0x0001EAEC
		private void gridSWHistory_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int row = this.gridSWHistory.Selection.ActivePosition.Row;
			int column = this.gridSWHistory.Selection.ActivePosition.Column;
			if (row > 0 && column > 0)
			{
				SWVersion swversion = new SWVersion();
				swversion.id = this.gridSWHistory[row, 2].ToString();
				swversion.Version = this.gridSWHistory[row, 3].ToString();
				swversion.Approvaldate = this.gridSWHistory[row, 4].ToString();
				swversion.Donedate = this.gridSWHistory[row, 5].ToString();
				swversion.Comment = this.gridSWHistory[row, 6].ToString();
				swversion.Filename = this.gridSWHistory[row, 7].ToString();
				if (new AddSWHistory
				{
					_cimitarUser = this._cimitarUser,
					_factorySetting = this._factorySetting,
					Caption = "Modify S/W Version",
					sType = "Modify",
					SW = swversion
				}.ShowDialog() == DialogResult.OK)
				{
					this.getSWVersionList();
				}
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00020A1C File Offset: 0x0001EC1C
		private void gridSWHistory_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Right)
				{
					if (this.gridSWHistory.RowsCount > 0)
					{
						this.menuSWVersion.Show(this.gridSWHistory, new Point(e.X, e.Y));
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00020A8C File Offset: 0x0001EC8C
		private void cmdDownloadFile_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.gridSWHistory.Selection.ActivePosition.Row > 0)
				{
					int row = this.gridSWHistory.Selection.ActivePosition.Row;
					string text = this.gridSWHistory[row, 2].ToString();
					string text2 = this.gridSWHistory[row, 7].ToString();
					string text3 = "\\\\10.121.1.91\\TitanSW";
					if (text2 == string.Empty)
					{
						MessageBox.Show("No attachmen file found", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						string text4 = text3;
						text3 = string.Concat(new string[]
						{
							text4,
							"\\",
							text,
							"\\",
							text2
						});
						if (!File.Exists(text3))
						{
							MessageBox.Show("server file is not exist : " + text3, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							this.saveFileDialog.Filter = "(*.*)|*.*";
							this.saveFileDialog.FilterIndex = 1;
							this.saveFileDialog.FileName = text2;
							if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								File.Copy(text3, this.saveFileDialog.FileName, true);
								MessageBox.Show("Success file download", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
						}
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Fail file download", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00020C0C File Offset: 0x0001EE0C
		private void txtSWVersion_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.cmdSWSearch_Click(null, null);
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00020C20 File Offset: 0x0001EE20
		private void cmdUserSetCarrier_Click(object sender, EventArgs e)
		{
			this.setUserSettingField("Carrier", this.gridCarrierList);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00020C33 File Offset: 0x0001EE33
		private void cmdUserSetHistory_Click(object sender, EventArgs e)
		{
			this.setUserSettingField("CarrierHistory", this.gridSearchHistory);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00020C48 File Offset: 0x0001EE48
		private void setUserSettingField(string sName, SourceGrid.Grid grid)
		{
			if (grid.RowsCount > 0)
			{
				UserDefColumn userDefColumn = new UserDefColumn();
				userDefColumn.sName = sName;
				userDefColumn.slAllList = new SortedList();
				userDefColumn.slSelectList = new SortedList();
				for (int i = 2; i < grid.ColumnsCount; i++)
				{
					userDefColumn.slAllList.Add(i, grid[0, i].ToString());
					if (grid.Columns[i].Visible)
					{
						userDefColumn.slSelectList.Add(i, grid[0, i].ToString());
					}
				}
				userDefColumn.ShowDialog();
				this.setUserField(grid, userDefColumn.slSelectList);
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00020CF8 File Offset: 0x0001EEF8
		private SortedList getUserSettingField(string sFilePath, SortedList slList)
		{
			try
			{
				if (File.Exists(sFilePath))
				{
					if (slList == null)
					{
						slList = new SortedList();
					}
					else
					{
						slList.Clear();
					}
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(sFilePath);
					XmlElement documentElement = xmlDocument.DocumentElement;
					XmlNodeList childNodes = documentElement.ChildNodes;
					foreach (object obj in childNodes)
					{
						XmlNode xmlNode = (XmlNode)obj;
						string key = xmlNode.Attributes["key"].Value.ToString();
						string value = xmlNode.Attributes["value"].Value.ToString();
						slList.Add(key, value);
					}
					return slList;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return slList;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00020DF0 File Offset: 0x0001EFF0
		private void setUserField(SourceGrid.Grid grid, SortedList slFieldList)
		{
			if (slFieldList.Count > 0)
			{
				for (int i = 2; i < grid.ColumnsCount; i++)
				{
					string value = grid[0, i].ToString();
					if (slFieldList.ContainsValue(value))
					{
						grid.Columns[i].Visible = true;
					}
					else
					{
						grid.Columns[i].Visible = false;
					}
				}
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00020E54 File Offset: 0x0001F054
		private void printPage(object sender, PrintPageEventArgs e)
		{
			CarrierInfo carrierInfo = (CarrierInfo)sender;
			Graphics graphics = e.Graphics;
			Font font = new Font("굴림체", 8f, FontStyle.Bold);
			Font font2 = new Font("굴림체", 7f, FontStyle.Bold);
			string text = string.Empty;
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Near;
			stringFormat.LineAlignment = StringAlignment.Near;
			Rectangle rectangle = default(Rectangle);
			CCarrierSite ccarrierSite = (CCarrierSite)carrierInfo.CarrierSites["1"];
			CCarrierSite ccarrierSite2 = (CCarrierSite)carrierInfo.CarrierSites["2"];
			int num = 7;
			if (ccarrierSite == null)
			{
				return;
			}
			rectangle = new Rectangle(5, 0, 260, font.Height * 2 - num);
			graphics.DrawString(carrierInfo.Location.ToString() + " / Rep : " + carrierInfo.RepairCnt.ToString(), font, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(5, 12, 11, 11);
			if (ccarrierSite.FailReason == "N/A" || ccarrierSite.FailReason == "OTHER")
			{
				graphics.DrawRectangle(Pens.Black, rectangle);
			}
			else
			{
				graphics.FillRectangle(Brushes.Black, rectangle);
			}
			rectangle = new Rectangle(33, 12, 50, font.Height * 2 - num);
			graphics.DrawString("Site1", font, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(90, 12, 50, font.Height * 2 - num);
			graphics.DrawString(ccarrierSite.FailReason, font, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(130, 12, 50, font.Height * 2 - num);
			graphics.DrawString(ccarrierSite.SiteYield, font, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(20, 25, 200, 11);
			text = "1.";
			if (ccarrierSite.Top1_Fail != string.Empty)
			{
				text = text + ccarrierSite.Top1_Fail + " - " + ccarrierSite.Top1_FailCount;
			}
			graphics.DrawString(text, font2, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(20, 35, 200, 11);
			text = "2.";
			if (ccarrierSite.Top2_Fail != string.Empty)
			{
				text = text + ccarrierSite.Top2_Fail + " - " + ccarrierSite.Top2_FailCount;
			}
			graphics.DrawString(text, font2, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(5, 45, 10, 10);
			if (ccarrierSite2.FailReason == "N/A" || ccarrierSite2.FailReason == "OTHER")
			{
				graphics.DrawRectangle(Pens.Black, rectangle);
			}
			else
			{
				graphics.FillRectangle(Brushes.Black, rectangle);
			}
			rectangle = new Rectangle(33, 45, 50, font.Height * 2 - num);
			graphics.DrawString("Site2", font, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(90, 45, 50, font.Height * 2 - num);
			graphics.DrawString(ccarrierSite2.FailReason, font, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(130, 45, 50, font.Height * 2 - num);
			graphics.DrawString(ccarrierSite2.SiteYield, font, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(20, 57, 200, 10);
			text = "1.";
			if (ccarrierSite2.Top1_Fail != string.Empty)
			{
				text = text + ccarrierSite2.Top1_Fail + " - " + ccarrierSite2.Top1_FailCount;
			}
			graphics.DrawString(text, font2, Brushes.Black, rectangle, stringFormat);
			rectangle = new Rectangle(20, 67, 200, 10);
			text = "2.";
			if (ccarrierSite2.Top2_Fail != string.Empty)
			{
				text = text + ccarrierSite2.Top2_Fail + " - " + ccarrierSite2.Top2_FailCount;
			}
			graphics.DrawString(text, font2, Brushes.Black, rectangle, stringFormat);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00021291 File Offset: 0x0001F491
		private void btnLabelPrint_Click(object sender, EventArgs e)
		{
			this.setPrint();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000212A8 File Offset: 0x0001F4A8
		private void button1_Click(object sender, EventArgs e)
		{
			if (this.selectedCarrier.CarrierSites.Count == 0)
			{
				return;
			}
			PrintDocument printDocument = new PrintDocument();
			printDocument.DocumentName = "Test";
			PageSettings pageSettings = new PageSettings();
			pageSettings.Margins = new System.Drawing.Printing.Margins(0, 10, 10, 10);
			pageSettings.PaperSize = new PaperSize("Test", 100, 112);
			printDocument.PrintPage += delegate(object send, PrintPageEventArgs ee)
			{
				this.printPage(this.selectedCarrier, ee);
			};
			new PrintPreviewDialog
			{
				Document = printDocument
			}.ShowDialog();
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0002132B File Offset: 0x0001F52B
		private void cmdStatusApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdStatusApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00021348 File Offset: 0x0001F548
		private void cmdStatusApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdStatusApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00021365 File Offset: 0x0001F565
		private void cmdStatusApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdStatusApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00021382 File Offset: 0x0001F582
		private void cmdStatusApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0002138F File Offset: 0x0001F58F
		private void cmdAddCode_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdAddCode.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000213AC File Offset: 0x0001F5AC
		private void cmdAddCode_MouseLeave(object sender, EventArgs e)
		{
			this.cmdAddCode.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000213C9 File Offset: 0x0001F5C9
		private void cmdAddCode_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdAddCode.Image = Resources.TableAdd_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000213E6 File Offset: 0x0001F5E6
		private void cmdAddCode_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000213F4 File Offset: 0x0001F5F4
		private void cmdSearch_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00021420 File Offset: 0x0001F620
		private void cmdSearch_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0002144C File Offset: 0x0001F64C
		private void cmdSearch_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00021476 File Offset: 0x0001F676
		private void cmdSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00021484 File Offset: 0x0001F684
		private void cmdExcel_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000214B0 File Offset: 0x0001F6B0
		private void cmdExcel_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000214DC File Offset: 0x0001F6DC
		private void cmdExcel_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00021506 File Offset: 0x0001F706
		private void cmdExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00021514 File Offset: 0x0001F714
		private void cmdAdd_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00021540 File Offset: 0x0001F740
		private void cmdAdd_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0002156C File Offset: 0x0001F76C
		private void cmdAdd_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableAdd_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00021596 File Offset: 0x0001F796
		private void cmdAdd_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000215A4 File Offset: 0x0001F7A4
		private void cmdDelete_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000215D0 File Offset: 0x0001F7D0
		private void cmdDelete_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000215FC File Offset: 0x0001F7FC
		private void cmdDelete_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableRemove_Donw;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00021626 File Offset: 0x0001F826
		private void cmdDelete_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00021633 File Offset: 0x0001F833
		private void cmdUserSetCarrier_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdUserSetCarrier.Image = Resources.CellDesign;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00021650 File Offset: 0x0001F850
		private void cmdUserSetCarrier_MouseLeave(object sender, EventArgs e)
		{
			this.cmdUserSetCarrier.Image = Resources.CellDesign;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0002166D File Offset: 0x0001F86D
		private void cmdUserSetCarrier_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdUserSetCarrier.Image = Resources.CellDesign_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0002168A File Offset: 0x0001F88A
		private void cmdUserSetCarrier_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00021697 File Offset: 0x0001F897
		private void cmdUserSetHistory_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdUserSetHistory.Image = Resources.CellDesign;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000216B4 File Offset: 0x0001F8B4
		private void cmdUserSetHistory_MouseLeave(object sender, EventArgs e)
		{
			this.cmdUserSetHistory.Image = Resources.CellDesign;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000216D1 File Offset: 0x0001F8D1
		private void cmdUserSetHistory_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdUserSetHistory.Image = Resources.CellDesign_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000216EE File Offset: 0x0001F8EE
		private void cmdUserSetHistory_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000216FB File Offset: 0x0001F8FB
		private void cmdUploadFile_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdUploadFile.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00021718 File Offset: 0x0001F918
		private void cmdUploadFile_MouseLeave(object sender, EventArgs e)
		{
			this.cmdUploadFile.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00021735 File Offset: 0x0001F935
		private void cmdUploadFile_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdUploadFile.Image = Resources.OpenTable_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00021752 File Offset: 0x0001F952
		private void cmdUploadFile_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0002175F File Offset: 0x0001F95F
		private void cmdModifyDefect_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdModifyDefect.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0002177C File Offset: 0x0001F97C
		private void cmdModifyDefect_MouseLeave(object sender, EventArgs e)
		{
			this.cmdModifyDefect.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00021799 File Offset: 0x0001F999
		private void cmdModifyDefect_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdModifyDefect.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000217B6 File Offset: 0x0001F9B6
		private void cmdModifyDefect_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000217C4 File Offset: 0x0001F9C4
		private void initCommentInfoLabel()
		{
			this.tpSM_tpComment_lblCustomer.Text = "";
			this.tpSM_tpComment_lblDevice.Text = "";
			this.tpSM_tpComment_lblMfg.Text = "";
			this.tpSM_tpComment_lblPn.Text = "";
			this.tpSM_tpComment_lblBarcode.Text = "";
			this.tpSM_tpComment_lblPkgType.Text = "";
			this.tpSM_tpComment_lblSocketType.Text = "";
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00021844 File Offset: 0x0001FA44
		private int GetTitanSocketList(string strBarcode, string strSocketType)
		{
			int result = 0;
			this._slSearchSocketList.Clear();
			this.listBox_Socket.Items.Clear();
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetSocketList]  @customerid = '', @status = '', @barcode = '",
					strBarcode.Trim(),
					"', @sockettype = '",
					strSocketType.Trim(),
					"', @device = ''"
				});
				dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							CSocketInfo csocketInfo = new CSocketInfo();
							csocketInfo.SocketId = dataSet.Tables[0].Rows[i]["socketid"].ToString().Trim();
							csocketInfo.Barcode = dataSet.Tables[0].Rows[i]["barcode"].ToString().Trim();
							csocketInfo.Device = dataSet.Tables[0].Rows[i]["device"].ToString().Trim();
							csocketInfo.SocketType = dataSet.Tables[0].Rows[i]["sockettype"].ToString().Trim();
							csocketInfo.Pn = dataSet.Tables[0].Rows[i]["pn"].ToString().Trim();
							csocketInfo.Customer = dataSet.Tables[0].Rows[i]["customer"].ToString().Trim();
							csocketInfo.PkgType = dataSet.Tables[0].Rows[i]["pkgtype"].ToString().Trim();
							csocketInfo.Mfg = dataSet.Tables[0].Rows[i]["mfg"].ToString().Trim();
							csocketInfo.Status = dataSet.Tables[0].Rows[i]["status"].ToString().Trim();
							csocketInfo.TesterName = dataSet.Tables[0].Rows[i]["testername"].ToString().Trim();
							csocketInfo.Memo = dataSet.Tables[0].Rows[i]["memo"].ToString().Trim();
							csocketInfo.CreateUser = dataSet.Tables[0].Rows[i]["CreateUser"].ToString().Trim();
							csocketInfo.CreateTime = dataSet.Tables[0].Rows[i]["CreateTime"].ToString().Trim();
							csocketInfo.LastEventUser = dataSet.Tables[0].Rows[i]["LastEventUser"].ToString().Trim();
							csocketInfo.LastEventTime = dataSet.Tables[0].Rows[i]["LastEventTime"].ToString().Trim();
							this._slSearchSocketList.Add(csocketInfo.Barcode, csocketInfo);
							this.listBox_Socket.Items.Add(csocketInfo.Barcode);
							result = 0;
						}
					}
					else
					{
						result = -1;
					}
				}
				else
				{
					result = -1;
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			return result;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00021C6C File Offset: 0x0001FE6C
		private void listBox_Socket_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_Socket.Items.Count > 0 && this.listBox_Socket.SelectedItem != null)
			{
				CSocketInfo csocketInfo = (CSocketInfo)this._slSearchSocketList[this.listBox_Socket.SelectedItem.ToString()];
				this.tpSM_tpComment_lblCustomer.Text = csocketInfo.Customer;
				this.tpSM_tpComment_lblDevice.Text = csocketInfo.Device;
				this.tpSM_tpComment_lblMfg.Text = csocketInfo.Mfg;
				this.tpSM_tpComment_lblPn.Text = csocketInfo.Pn;
				this.tpSM_tpComment_lblBarcode.Text = csocketInfo.Barcode;
				this.tpSM_tpComment_lblPkgType.Text = csocketInfo.PkgType;
				this.tpSM_tpComment_lblSocketType.Text = csocketInfo.SocketType;
				this._strSearchSocketid = csocketInfo.SocketId;
				this.GetCommentHistory();
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Socket Comment History");
				this._barPrograss.setValue(100);
				this._barPrograss.StartPosition = FormStartPosition.Manual;
				this._barPrograss.Location = new Point(base.Location.X + base.Width / 3, base.Location.Y + base.Height / 3 + this._barPrograss.Height);
				this._barPrograss.progress_label_set("Loading");
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this.ResetGrid();
				this.SetGrid();
				Thread.Sleep(1000);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00021E2C File Offset: 0x0002002C
		private void GetCommentHistory()
		{
			try
			{
				this._slCommentHistory.Clear();
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetSocketCommentHistory] @socketid = '" + this._strSearchSocketid + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CCommentHistory ccommentHistory = new CCommentHistory();
						ccommentHistory.strNo = dataSet.Tables[0].Rows[i]["no"].ToString();
						ccommentHistory.strSocketID = dataSet.Tables[0].Rows[i]["socketid"].ToString();
						ccommentHistory.strSite = dataSet.Tables[0].Rows[i]["site"].ToString();
						ccommentHistory.strTesterName = dataSet.Tables[0].Rows[i]["testername"].ToString();
						ccommentHistory.strRequestDate = dataSet.Tables[0].Rows[i]["requestDate"].ToString();
						ccommentHistory.strRequestComment = dataSet.Tables[0].Rows[i]["requestComment"].ToString();
						ccommentHistory.strRequestName = dataSet.Tables[0].Rows[i]["requestName"].ToString();
						ccommentHistory.strCompletedDate = dataSet.Tables[0].Rows[i]["completedDate"].ToString();
						ccommentHistory.strCompletedComment = dataSet.Tables[0].Rows[i]["completedComment"].ToString();
						ccommentHistory.strPinCount = dataSet.Tables[0].Rows[i]["pincount"].ToString();
						ccommentHistory.strCompletedName = dataSet.Tables[0].Rows[i]["completedName"].ToString();
						this._slCommentHistory.Add(i, ccommentHistory);
					}
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x000220E8 File Offset: 0x000202E8
		private string GetOption()
		{
			string result = "";
			if (this.cbx_top.Checked && this.cbx_bottom.Checked)
			{
				result = "";
			}
			else if (!this.cbx_top.Checked && !this.cbx_bottom.Checked)
			{
				result = "";
			}
			else if (this.cbx_top.Checked)
			{
				result = "TOP";
			}
			else if (this.cbx_bottom.Checked)
			{
				result = "BOTTOM";
			}
			return result;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00022168 File Offset: 0x00020368
		private void btn_search_Click(object sender, EventArgs e)
		{
			try
			{
				string strBarcode = this.tb_barcode.Text.ToString().Trim();
				string option = this.GetOption();
				int titanSocketList = this.GetTitanSocketList(strBarcode, option);
				if (titanSocketList != 0)
				{
					MessageBox.Show("There is no socket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000221D4 File Offset: 0x000203D4
		private void tb_barcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.btn_search_Click(this, new EventArgs());
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000221EC File Offset: 0x000203EC
		private void InitGridCell()
		{
			this.cell_right_gray = new SourceGrid.Cells.Views.Cell();
			this.cell_right_gray.BackColor = Color.FromArgb(224, 224, 224);
			this.cell_right_gray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
			this.cell_left_gray = new SourceGrid.Cells.Views.Cell();
			this.cell_left_gray.BackColor = Color.FromArgb(224, 224, 224);
			this.cell_left_gray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_total = new SourceGrid.Cells.Views.Cell();
			this.cell_total.BackColor = Color.FromArgb(224, 224, 224);
			this.cell_total.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_green = new SourceGrid.Cells.Views.Cell();
			this.cell_green.BackColor = Color.FromArgb(170, 235, 130);
			this.cell_green.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_red = new SourceGrid.Cells.Views.Cell();
			this.cell_red.BackColor = Color.FromArgb(235, 100, 100);
			this.cell_red.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_yello = new SourceGrid.Cells.Views.Cell();
			this.cell_yello.BackColor = Color.FromArgb(244, 230, 107);
			this.cell_yello.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_right_sgray = new SourceGrid.Cells.Views.Cell();
			this.cell_right_sgray.BackColor = Color.FromArgb(255, 255, 204);
			this.cell_right_sgray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
			this.cell_left_sgray = new SourceGrid.Cells.Views.Cell();
			this.cell_left_sgray.BackColor = Color.FromArgb(255, 255, 204);
			this.cell_left_sgray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_right_dark_sgray = new SourceGrid.Cells.Views.Cell();
			this.cell_right_dark_sgray.BackColor = Color.FromArgb(247, 240, 214);
			this.cell_right_dark_sgray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
			this.cell_left_dark_sgray = new SourceGrid.Cells.Views.Cell();
			this.cell_left_dark_sgray.BackColor = Color.FromArgb(247, 240, 214);
			this.cell_left_dark_sgray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_right = new SourceGrid.Cells.Views.Cell();
			this.cell_right.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
			this.cell_left = new SourceGrid.Cells.Views.Cell();
			this.cell_left.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_center = new SourceGrid.Cells.Views.Cell();
			this.cell_center.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_limit = new SourceGrid.Cells.Views.Cell();
			this.cell_limit.BackColor = Color.FromArgb(255, 192, 203);
			this.cell_limit.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header1 = new SourceGrid.Cells.Views.Cell();
			this.cell_header1.BackColor = Color.FromArgb(130, 179, 237);
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header2 = new SourceGrid.Cells.Views.Cell();
			this.cell_header2.BackColor = Color.FromArgb(150, 199, 237);
			this.cell_header2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header3 = new SourceGrid.Cells.Views.Cell();
			this.cell_header3.BackColor = Color.FromArgb(94, 199, 94);
			this.cell_header3.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header4 = new SourceGrid.Cells.Views.Cell();
			this.cell_header4.BackColor = Color.FromArgb(119, 199, 119);
			this.cell_header4.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header5 = new SourceGrid.Cells.Views.Cell();
			this.cell_header5.BackColor = Color.FromArgb(245, 120, 120);
			this.cell_header5.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header6 = new SourceGrid.Cells.Views.Cell();
			this.cell_header6.BackColor = Color.FromArgb(240, 170, 170);
			this.cell_header6.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000225D0 File Offset: 0x000207D0
		private void ResetGrid()
		{
			int num = this.grid_socket_comment.RowsCount - 1;
			for (int i = num; i >= 0; i--)
			{
				this.grid_socket_comment.Rows.Remove(i);
			}
			this.grid_socket_comment.Selection.EnableMultiSelection = false;
			this.grid_socket_comment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_socket_comment.CustomSort = true;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00022634 File Offset: 0x00020834
		private void GridColumHeadSet()
		{
			int num = 0;
			this.grid_socket_comment.ColumnsCount = 10;
			this.grid_socket_comment.FixedRows = 1;
			this.grid_socket_comment.FixedColumns = 3;
			this.grid_socket_comment.Rows.Insert(num);
			this.grid_socket_comment[num, 0] = new SourceGrid.Cells.ColumnHeader("No");
			this.grid_socket_comment[num, 0].View = this.cell_header1;
			this.grid_socket_comment[num, 1] = new SourceGrid.Cells.ColumnHeader("Site");
			this.grid_socket_comment[num, 1].View = this.cell_header1;
			this.grid_socket_comment[num, 2] = new SourceGrid.Cells.ColumnHeader("Tester");
			this.grid_socket_comment[num, 2].View = this.cell_header1;
			this.grid_socket_comment[num, 3] = new SourceGrid.Cells.ColumnHeader("Request Date");
			this.grid_socket_comment[num, 3].View = this.cell_header1;
			this.grid_socket_comment[num, 4] = new SourceGrid.Cells.ColumnHeader("Request Comment");
			this.grid_socket_comment[num, 4].View = this.cell_header1;
			this.grid_socket_comment[num, 5] = new SourceGrid.Cells.ColumnHeader("Name");
			this.grid_socket_comment[num, 5].View = this.cell_header1;
			this.grid_socket_comment[num, 6] = new SourceGrid.Cells.ColumnHeader("Completed Date");
			this.grid_socket_comment[num, 6].View = this.cell_header3;
			this.grid_socket_comment[num, 7] = new SourceGrid.Cells.ColumnHeader("Completed Comment");
			this.grid_socket_comment[num, 7].View = this.cell_header3;
			this.grid_socket_comment[num, 8] = new SourceGrid.Cells.ColumnHeader("PinCount");
			this.grid_socket_comment[num, 8].View = this.cell_header3;
			this.grid_socket_comment[num, 9] = new SourceGrid.Cells.ColumnHeader("Name");
			this.grid_socket_comment[num, 9].View = this.cell_header3;
			this.grid_socket_comment.Columns[0].Width = 40;
			this.grid_socket_comment.Columns[1].Width = 40;
			this.grid_socket_comment.Columns[2].Width = 60;
			this.grid_socket_comment.Columns[3].Width = 100;
			this.grid_socket_comment.Columns[4].Width = 300;
			this.grid_socket_comment.Columns[5].Width = 60;
			this.grid_socket_comment.Columns[6].Width = 100;
			this.grid_socket_comment.Columns[7].Width = 300;
			this.grid_socket_comment.Columns[8].Width = 40;
			this.grid_socket_comment.Columns[9].Width = 60;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00022948 File Offset: 0x00020B48
		public void SetGrid()
		{
			try
			{
				this.GridColumHeadSet();
				int num = 1;
				foreach (object obj in this._slCommentHistory)
				{
					CCommentHistory ccommentHistory = (CCommentHistory)((DictionaryEntry)obj).Value;
					this.grid_socket_comment.Rows.Insert(num);
					this.grid_socket_comment[num, 0] = new SourceGrid.Cells.Cell(num.ToString());
					this.grid_socket_comment[num, 0].View = this.cell_center;
					this.grid_socket_comment[num, 1] = new SourceGrid.Cells.Cell(ccommentHistory.strSite);
					this.grid_socket_comment[num, 1].View = this.cell_left;
					this.grid_socket_comment[num, 2] = new SourceGrid.Cells.Cell(ccommentHistory.strTesterName);
					this.grid_socket_comment[num, 2].View = this.cell_left;
					this.grid_socket_comment[num, 3] = new SourceGrid.Cells.Cell(ccommentHistory.strRequestDate);
					this.grid_socket_comment[num, 3].View = this.cell_left;
					this.grid_socket_comment[num, 4] = new SourceGrid.Cells.Cell(ccommentHistory.strRequestComment);
					this.grid_socket_comment[num, 4].View = this.cell_left;
					this.grid_socket_comment[num, 5] = new SourceGrid.Cells.Cell(ccommentHistory.strRequestName);
					this.grid_socket_comment[num, 5].View = this.cell_left;
					this.grid_socket_comment[num, 6] = new SourceGrid.Cells.Cell(ccommentHistory.strCompletedDate);
					this.grid_socket_comment[num, 6].View = this.cell_left;
					this.grid_socket_comment[num, 7] = new SourceGrid.Cells.Cell(ccommentHistory.strCompletedComment);
					this.grid_socket_comment[num, 7].View = this.cell_left;
					this.grid_socket_comment[num, 8] = new SourceGrid.Cells.Cell(ccommentHistory.strPinCount);
					this.grid_socket_comment[num, 8].View = this.cell_left;
					this.grid_socket_comment[num, 9] = new SourceGrid.Cells.Cell(ccommentHistory.strCompletedName);
					this.grid_socket_comment[num, 9].View = this.cell_left;
					num++;
				}
				this.gridInfo.AutoSetGrid(this.grid_socket_comment);
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00022BF8 File Offset: 0x00020DF8
		private void pb_comment_insert_MouseMove(object sender, MouseEventArgs e)
		{
			this.pb_comment_insert.Image = Resources.TableAdd_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00022C15 File Offset: 0x00020E15
		private void pb_comment_insert_MouseLeave(object sender, EventArgs e)
		{
			this.pb_comment_insert.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00022C32 File Offset: 0x00020E32
		private void pb_comment_insert_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_comment_insert.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00022C4F File Offset: 0x00020E4F
		private void pb_comment_insert_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
			this.InsertView();
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00022C64 File Offset: 0x00020E64
		private void InsertView()
		{
			if (this._strSearchSocketid != "")
			{
				if (new AddSocketComment(this._strSearchSocketid)
				{
					_factorySetting = this._factorySetting
				}.ShowDialog() == DialogResult.OK)
				{
					this._slCommentHistory.Clear();
					this.GetCommentHistory();
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Socket Comment History");
					this._barPrograss.setValue(100);
					this._barPrograss.StartPosition = FormStartPosition.Manual;
					this._barPrograss.Location = new Point(base.Location.X + base.Width / 3, base.Location.Y + base.Height / 3 + this._barPrograss.Height);
					this._barPrograss.progress_label_set("Loading");
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					this.ResetGrid();
					this.SetGrid();
					Thread.Sleep(1000);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
					return;
				}
			}
			else
			{
				MessageBox.Show("Please Search Socket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00022DB0 File Offset: 0x00020FB0
		private void pb_comment_excel_MouseMove(object sender, MouseEventArgs e)
		{
			this.pb_comment_excel.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00022DCD File Offset: 0x00020FCD
		private void pb_comment_excel_MouseLeave(object sender, EventArgs e)
		{
			this.pb_comment_excel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00022DEA File Offset: 0x00020FEA
		private void pb_comment_excel_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_comment_excel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00022E07 File Offset: 0x00021007
		private void pb_comment_excel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
			this.saveExcel(this.grid_socket_comment);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00022E20 File Offset: 0x00021020
		private ToolTipText CreateSourceGridToolTipController(string strSubject)
		{
			return new ToolTipText
			{
				ToolTipTitle = strSubject,
				ToolTipIcon = ToolTipIcon.Info,
				IsBalloon = true
			};
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00022E4C File Offset: 0x0002104C
		private void SocketList_ResetGrid()
		{
			int num = this.gridSocketList.RowsCount - 1;
			for (int i = num; i >= 0; i--)
			{
				this.gridSocketList.Rows.Remove(i);
			}
			this.gridSocketList.Selection.EnableMultiSelection = false;
			this.gridSocketList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gridSocketList.CustomSort = true;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00022EB0 File Offset: 0x000210B0
		private void SocketList_GridColumHeadSet()
		{
			int num = 0;
			this.gridSocketList.ColumnsCount = 16;
			this.gridSocketList.FixedRows = 1;
			this.gridSocketList.FixedColumns = 2;
			this.gridSocketList.Rows.Insert(num);
			this.gridSocketList[num, 0] = new SourceGrid.Cells.ColumnHeader("No");
			this.gridSocketList[num, 1] = new SourceGrid.Cells.ColumnHeader("SocketID");
			this.gridSocketList[num, 2] = new SourceGrid.Cells.ColumnHeader("Barcode");
			this.gridSocketList[num, 3] = new SourceGrid.Cells.ColumnHeader("Device");
			this.gridSocketList[num, 4] = new SourceGrid.Cells.ColumnHeader("Type");
			this.gridSocketList[num, 5] = new SourceGrid.Cells.ColumnHeader("PN");
			this.gridSocketList[num, 6] = new SourceGrid.Cells.ColumnHeader("Customer");
			this.gridSocketList[num, 7] = new SourceGrid.Cells.ColumnHeader("PkgType");
			this.gridSocketList[num, 8] = new SourceGrid.Cells.ColumnHeader("MFG");
			this.gridSocketList[num, 9] = new SourceGrid.Cells.ColumnHeader("Status");
			ToolTipText controller = this.CreateSourceGridToolTipController("Status Info");
			this.gridSocketList[num, 9].AddController(controller);
			string toolTipText = "Blank : 등록후 모든 Socket\r\nRMA : RMA 처리된 Socket\r\nSupplier Return : 업체 리턴\r\nCustomer Return : 고객 리턴";
			this.gridSocketList[num, 9].ToolTipText = toolTipText;
			this.gridSocketList[num, 10] = new SourceGrid.Cells.ColumnHeader("TesterName");
			this.gridSocketList[num, 11] = new SourceGrid.Cells.ColumnHeader("Memo");
			this.gridSocketList[num, 12] = new GridInfo.ColHeader("CreateUser", false);
			this.gridSocketList[num, 13] = new GridInfo.ColHeader("CreateTime", false);
			this.gridSocketList[num, 14] = new GridInfo.ColHeader("LastEventUser", false);
			this.gridSocketList[num, 15] = new GridInfo.ColHeader("LastEventTime", false);
			this.gridSocketList.Columns[1].Visible = false;
			this.gridInfo.SetColumnCellColor(this.gridSocketList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridSocketList.Columns[0].Width = 40;
			this.gridSocketList.Columns[2].Width = 150;
			this.gridSocketList.Columns[3].Width = 60;
			this.gridSocketList.Columns[4].Width = 60;
			this.gridSocketList.Columns[5].Width = 80;
			this.gridSocketList.Columns[6].Width = 80;
			this.gridSocketList.Columns[7].Width = 120;
			this.gridSocketList.Columns[8].Width = 80;
			this.gridSocketList.Columns[9].Width = 80;
			this.gridSocketList.Columns[10].Width = 80;
			this.gridSocketList.Columns[11].Width = 200;
			this.gridSocketList.Columns[12].Width = 80;
			this.gridSocketList.Columns[13].Width = 150;
			this.gridSocketList.Columns[14].Width = 80;
			this.gridSocketList.Columns[15].Width = 150;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0002325E File Offset: 0x0002145E
		private void tpSM_tpEnroll_cmbCustomer_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierCustomer", this.tpSM_tpEnroll_cmbCustomer);
			if (this.tpSM_tpEnroll_cmbCustomer.Items.Count > 0)
			{
				this.tpSM_tpEnroll_cmbCustomer.SelectedIndex = 0;
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00023291 File Offset: 0x00021491
		private void tpSM_tpEnroll_cmbStatus_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("SocketStatus", this.tpSM_tpEnroll_cmbStatus);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000232A5 File Offset: 0x000214A5
		private void tpSM_tpEnroll_cmbSocketType_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("SocketType", this.tpSM_tpEnroll_cmbSocketType);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000232B9 File Offset: 0x000214B9
		private void tpSM_tpEnroll_cmbDevice_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.tpSM_tpEnroll_cmbDevice);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000232D0 File Offset: 0x000214D0
		private void gridSocketList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.gridSocketList.Selection.ActivePosition.Row > 0)
			{
				int row = this.gridSocketList.Selection.ActivePosition.Row;
				int column = this.gridSocketList.Selection.ActivePosition.Column;
				if (new AddSocket(new CSocketInfo
				{
					SocketId = this.gridSocketList[row, 1].ToString(),
					Barcode = this.gridSocketList[row, 2].ToString(),
					Device = this.gridSocketList[row, 3].ToString(),
					SocketType = this.gridSocketList[row, 4].ToString(),
					Pn = this.gridSocketList[row, 5].ToString(),
					Customer = this.gridSocketList[row, 6].ToString(),
					PkgType = this.gridSocketList[row, 7].ToString(),
					Mfg = this.gridSocketList[row, 8].ToString(),
					Status = this.gridSocketList[row, 9].ToString(),
					TesterName = this.gridSocketList[row, 10].ToString(),
					Memo = this.gridSocketList[row, 11].ToString()
				})
				{
					_factorySetting = this._factorySetting,
					_cimitarUser = this._cimitarUser,
					sType = "Modify"
				}.ShowDialog() == DialogResult.OK)
				{
					this.SearchView();
				}
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00023479 File Offset: 0x00021679
		private void tpSM_tpEnroll_btnSearch_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpSM_tpEnroll_btnSearch.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00023496 File Offset: 0x00021696
		private void tpSM_tpEnroll_btnSearch_MouseLeave(object sender, EventArgs e)
		{
			this.tpSM_tpEnroll_btnSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000234B3 File Offset: 0x000216B3
		private void tpSM_tpEnroll_btnSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.tpSM_tpEnroll_btnSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000234D0 File Offset: 0x000216D0
		private void tpSM_tpEnroll_btnSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
			this.SearchView();
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000234E4 File Offset: 0x000216E4
		private void SearchView()
		{
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this.SocketList_ResetGrid();
				this.SocketList_GridColumHeadSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetSocketList]  @customerid = '",
					this.tpSM_tpEnroll_cmbCustomer.Text,
					"', @status = '",
					this.tpSM_tpEnroll_cmbStatus.Text,
					"', @barcode = '",
					this.tpSM_tpEnroll_txtBarcode.Text.Trim(),
					"', @sockettype = '",
					this.tpSM_tpEnroll_cmbSocketType.Text.Trim(),
					"', @device = '",
					this.tpSM_tpEnroll_cmbDevice.Text.Trim(),
					"'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.gridSocketList.Rows.Insert(this.gridSocketList.RowsCount);
						this.gridSocketList[i + 1, 0] = new SourceGrid.Cells.Cell((this.gridSocketList.RowsCount - 1).ToString());
						this.gridSocketList[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["socketid"].ToString());
						this.gridSocketList[i + 1, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["barcode"].ToString());
						this.gridSocketList[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["device"].ToString());
						this.gridSocketList[i + 1, 4] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["sockettype"].ToString());
						this.gridSocketList[i + 1, 5] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["pn"].ToString());
						this.gridSocketList[i + 1, 6] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["customer"].ToString());
						this.gridSocketList[i + 1, 7] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["pkgtype"].ToString());
						this.gridSocketList[i + 1, 8] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["mfg"].ToString());
						this.gridSocketList[i + 1, 9] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["status"].ToString());
						this.gridSocketList[i + 1, 10] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["testername"].ToString());
						this.gridSocketList[i + 1, 11] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["memo"].ToString());
						this.gridSocketList[i + 1, 12] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CreateUser"].ToString());
						this.gridSocketList[i + 1, 13] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["CreateTime"].ToString());
						this.gridSocketList[i + 1, 14] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastEventUser"].ToString());
						this.gridSocketList[i + 1, 15] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["LastEventTime"].ToString());
						this._barPrograss.setValue(i + 1);
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00023ABC File Offset: 0x00021CBC
		private void tpSM_tpEnroll_btnAdd_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpSM_tpEnroll_btnAdd.Image = Resources.TableAdd_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00023AD9 File Offset: 0x00021CD9
		private void tpSM_tpEnroll_btnAdd_MouseLeave(object sender, EventArgs e)
		{
			this.tpSM_tpEnroll_btnAdd.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00023AF6 File Offset: 0x00021CF6
		private void tpSM_tpEnroll_btnAdd_MouseDown(object sender, MouseEventArgs e)
		{
			this.tpSM_tpEnroll_btnAdd.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00023B14 File Offset: 0x00021D14
		private void tpSM_tpEnroll_btnAdd_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
			new AddSocket
			{
				_factorySetting = this._factorySetting,
				_cimitarUser = this._cimitarUser,
				sType = "Create"
			}.ShowDialog();
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00023B5C File Offset: 0x00021D5C
		private void tpSM_tpEnroll_btnExcel_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpSM_tpEnroll_btnExcel.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00023B79 File Offset: 0x00021D79
		private void tpSM_tpEnroll_btnExcel_MouseLeave(object sender, EventArgs e)
		{
			this.tpSM_tpEnroll_btnExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00023B96 File Offset: 0x00021D96
		private void tpSM_tpEnroll_btnExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.tpSM_tpEnroll_btnExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00023BB3 File Offset: 0x00021DB3
		private void tpSM_tpEnroll_btnExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
			this.saveExcel(this.gridSocketList);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00023BCC File Offset: 0x00021DCC
		private void tpSM_tpEnroll_btnSetting_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpSM_tpEnroll_btnSetting.Image = Resources.CellDesign_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00023BE9 File Offset: 0x00021DE9
		private void tpSM_tpEnroll_btnSetting_MouseLeave(object sender, EventArgs e)
		{
			this.tpSM_tpEnroll_btnSetting.Image = Resources.CellDesign;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00023C06 File Offset: 0x00021E06
		private void tpSM_tpEnroll_btnSetting_MouseDown(object sender, MouseEventArgs e)
		{
			this.tpSM_tpEnroll_btnSetting.Image = Resources.CellDesign;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00023C23 File Offset: 0x00021E23
		private void tpSM_tpEnroll_btnSetting_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
			this.setUserSettingField("Socket", this.gridSocketList);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00023C44 File Offset: 0x00021E44
		private void SocketPeriodList_ResetGrid()
		{
			int num = this.gridPeriodSocketList.RowsCount - 1;
			for (int i = num; i >= 0; i--)
			{
				this.gridPeriodSocketList.Rows.Remove(i);
			}
			this.gridPeriodSocketList.Selection.EnableMultiSelection = false;
			this.gridPeriodSocketList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gridPeriodSocketList.CustomSort = true;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00023CA8 File Offset: 0x00021EA8
		private void SocketPeriodList_GridColumHeadSet()
		{
			int num = 0;
			this.gridPeriodSocketList.ColumnsCount = 12;
			this.gridPeriodSocketList.FixedRows = 1;
			this.gridPeriodSocketList.FixedColumns = 2;
			this.gridPeriodSocketList.Rows.Insert(num);
			this.gridPeriodSocketList[num, 0] = new SourceGrid.Cells.ColumnHeader("No");
			this.gridPeriodSocketList[num, 1] = new SourceGrid.Cells.ColumnHeader("SocketID");
			this.gridPeriodSocketList[num, 2] = new SourceGrid.Cells.ColumnHeader("Barcode");
			this.gridPeriodSocketList[num, 3] = new SourceGrid.Cells.ColumnHeader("Site");
			this.gridPeriodSocketList[num, 4] = new SourceGrid.Cells.ColumnHeader("TesterName");
			this.gridPeriodSocketList[num, 5] = new SourceGrid.Cells.ColumnHeader("RequestDate");
			this.gridPeriodSocketList[num, 6] = new SourceGrid.Cells.ColumnHeader("RequestComment");
			this.gridPeriodSocketList[num, 7] = new SourceGrid.Cells.ColumnHeader("RequestName");
			this.gridPeriodSocketList[num, 8] = new SourceGrid.Cells.ColumnHeader("CompletedDate");
			this.gridPeriodSocketList[num, 9] = new SourceGrid.Cells.ColumnHeader("CompletedComment");
			this.gridPeriodSocketList[num, 10] = new SourceGrid.Cells.ColumnHeader("PinCount");
			this.gridPeriodSocketList[num, 11] = new GridInfo.ColHeader("CompletedName", false);
			this.gridPeriodSocketList.Columns[1].Visible = false;
			this.gridInfo.SetColumnCellColor(this.gridPeriodSocketList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridPeriodSocketList.Columns[0].Width = 40;
			this.gridPeriodSocketList.Columns[2].Width = 80;
			this.gridPeriodSocketList.Columns[3].Width = 40;
			this.gridPeriodSocketList.Columns[4].Width = 80;
			this.gridPeriodSocketList.Columns[5].Width = 140;
			this.gridPeriodSocketList.Columns[6].Width = 250;
			this.gridPeriodSocketList.Columns[7].Width = 100;
			this.gridPeriodSocketList.Columns[8].Width = 140;
			this.gridPeriodSocketList.Columns[9].Width = 250;
			this.gridPeriodSocketList.Columns[10].Width = 60;
			this.gridPeriodSocketList.Columns[11].Width = 100;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00023F55 File Offset: 0x00022155
		private void tpSM_tpPeriod_cmbCompletedCommentStatus_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("SocketCommentStatus", this.tpSM_tpPeriod_cmbCompletedCommentStatus);
			if (this.tpSM_tpPeriod_cmbCompletedCommentStatus.Items.Count > 0)
			{
				this.tpSM_tpPeriod_cmbCompletedCommentStatus.SelectedIndex = 0;
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00023F88 File Offset: 0x00022188
		private void tpSM_tpPeriod_dtStart_CloseUp(object sender, EventArgs e)
		{
			DateTimePicker dateTimePicker = (DateTimePicker)sender;
			DateTime value = dateTimePicker.Value;
			value = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
			DateTime now = DateTime.Now;
			now = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
			if (value > now)
			{
				this.tpSM_tpPeriod_dtStart.Value = now;
				MessageBox.Show("Please select previously day.");
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00024008 File Offset: 0x00022208
		private void tpSM_tpPeriod_dtEnd_CloseUp(object sender, EventArgs e)
		{
			DateTimePicker dateTimePicker = (DateTimePicker)sender;
			DateTime value = dateTimePicker.Value;
			value = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
			DateTime now = DateTime.Now;
			now = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
			if (value > now)
			{
				this.tpSM_tpPeriod_dtEnd.Value = now;
				MessageBox.Show("Please select previously day.");
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00024088 File Offset: 0x00022288
		private void gridPeriodSocketList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.gridPeriodSocketList.Selection.ActivePosition.Row > 0)
			{
				int row = this.gridPeriodSocketList.Selection.ActivePosition.Row;
				int column = this.gridPeriodSocketList.Selection.ActivePosition.Column;
				string strSocketId = this.gridPeriodSocketList[row, 1].ToString();
				string strBarcode = this.gridPeriodSocketList[row, 2].ToString();
				new AnsSocketComment(strSocketId, strBarcode)
				{
					_factorySetting = this._factorySetting,
					_cimitarUser = this._cimitarUser
				}.ShowDialog();
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00024138 File Offset: 0x00022338
		private void tpSM_tpPeriod_btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this.SocketPeriodList_ResetGrid();
				this.SocketPeriodList_GridColumHeadSet();
				DateTime dateTime = new DateTime(this.tpSM_tpPeriod_dtStart.Value.Year, this.tpSM_tpPeriod_dtStart.Value.Month, this.tpSM_tpPeriod_dtStart.Value.Day, 0, 0, 0);
				DateTime dateTime2 = new DateTime(this.tpSM_tpPeriod_dtEnd.Value.Year, this.tpSM_tpPeriod_dtEnd.Value.Month, this.tpSM_tpPeriod_dtEnd.Value.Day, 0, 0, 0);
				string text = dateTime.ToString("yyyy-MM-dd");
				string text2 = dateTime2.ToString("yyyy-MM-dd");
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetSocketCommentStatusHistory]  @dtStart = '",
					text,
					"', @dtEnd = '",
					text2,
					"', @CommentStatus = '",
					this.tpSM_tpPeriod_cmbCompletedCommentStatus.Text.Trim(),
					"'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.gridPeriodSocketList.Rows.Insert(this.gridPeriodSocketList.RowsCount);
						this.gridPeriodSocketList[i + 1, 0] = new SourceGrid.Cells.Cell((this.gridPeriodSocketList.RowsCount - 1).ToString());
						this.gridPeriodSocketList[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["socketid"].ToString());
						this.gridPeriodSocketList[i + 1, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["barcode"].ToString());
						this.gridPeriodSocketList[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["site"].ToString());
						this.gridPeriodSocketList[i + 1, 4] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["testername"].ToString());
						this.gridPeriodSocketList[i + 1, 5] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["requestDate"].ToString());
						this.gridPeriodSocketList[i + 1, 6] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["requestComment"].ToString());
						this.gridPeriodSocketList[i + 1, 7] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["requestName"].ToString());
						this.gridPeriodSocketList[i + 1, 8] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["completedDate"].ToString());
						this.gridPeriodSocketList[i + 1, 9] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["completedComment"].ToString());
						this.gridPeriodSocketList[i + 1, 10] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["pincount"].ToString());
						this.gridPeriodSocketList[i + 1, 11] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["completedName"].ToString());
						this._barPrograss.setValue(i + 1);
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x000246A8 File Offset: 0x000228A8
		private void tpSM_tpPeriod_btnSearch_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpSM_tpPeriod_btnSearch.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000246C5 File Offset: 0x000228C5
		private void tpSM_tpPeriod_btnSearch_MouseLeave(object sender, EventArgs e)
		{
			this.tpSM_tpPeriod_btnSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x000246E2 File Offset: 0x000228E2
		private void tpSM_tpPeriod_btnSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.tpSM_tpPeriod_btnSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000246FF File Offset: 0x000228FF
		private void tpSM_tpPeriod_btnSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0002470C File Offset: 0x0002290C
		private void tpSM_tpPeriod_btnExcel_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpSM_tpPeriod_btnExcel.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00024729 File Offset: 0x00022929
		private void tpSM_tpPeriod_btnExcel_MouseLeave(object sender, EventArgs e)
		{
			this.tpSM_tpPeriod_btnExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00024746 File Offset: 0x00022946
		private void tpSM_tpPeriod_btnExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.tpSM_tpPeriod_btnExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00024763 File Offset: 0x00022963
		private void tpSM_tpPeriod_btnExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
			this.saveExcel(this.gridPeriodSocketList);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0002477C File Offset: 0x0002297C
		private void tpSM_tpPeriod_btnSetting_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpSM_tpPeriod_btnSetting.Image = Resources.CellDesign_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00024799 File Offset: 0x00022999
		private void tpSM_tpPeriod_btnSetting_MouseLeave(object sender, EventArgs e)
		{
			this.tpSM_tpPeriod_btnSetting.Image = Resources.CellDesign;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000247B6 File Offset: 0x000229B6
		private void tpSM_tpPeriod_btnSetting_MouseDown(object sender, MouseEventArgs e)
		{
			this.tpSM_tpPeriod_btnSetting.Image = Resources.CellDesign;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000247D3 File Offset: 0x000229D3
		private void tpSM_tpPeriod_btnSetting_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
			this.setUserSettingField("Socket", this.gridPeriodSocketList);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000247F4 File Offset: 0x000229F4
		private string GetDateTime(string strDateTime)
		{
			DateTime dateTime = Convert.ToDateTime(strDateTime);
			string result = string.Empty;
			if (dateTime.Hour > 6)
			{
				result = dateTime.ToString("yyyy-MM-dd");
			}
			else if (dateTime.Hour <= 6)
			{
				result = dateTime.AddDays(-1.0).ToString("yyyy-MM-dd");
			}
			return result;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00024850 File Offset: 0x00022A50
		private void SocketCompletedList_ResetGrid()
		{
			int num = this.gridCompletedList.RowsCount - 1;
			for (int i = num; i >= 0; i--)
			{
				this.gridCompletedList.Rows.Remove(i);
			}
			this.gridCompletedList.Selection.EnableMultiSelection = false;
			this.gridCompletedList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gridCompletedList.CustomSort = true;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000248B4 File Offset: 0x00022AB4
		private void SocketCompletedList_GridColumHeadSet()
		{
			int num = 0;
			this.gridCompletedList.ColumnsCount = 12;
			this.gridCompletedList.FixedRows = 1;
			this.gridCompletedList.FixedColumns = 2;
			this.gridCompletedList.Rows.Insert(num);
			this.gridCompletedList[num, 0] = new SourceGrid.Cells.ColumnHeader("No");
			this.gridCompletedList[num, 1] = new SourceGrid.Cells.ColumnHeader("SocketID");
			this.gridCompletedList[num, 2] = new SourceGrid.Cells.ColumnHeader("Barcode");
			this.gridCompletedList[num, 3] = new SourceGrid.Cells.ColumnHeader("Site");
			this.gridCompletedList[num, 4] = new SourceGrid.Cells.ColumnHeader("TesterName");
			this.gridCompletedList[num, 5] = new SourceGrid.Cells.ColumnHeader("RequestDate");
			this.gridCompletedList[num, 6] = new SourceGrid.Cells.ColumnHeader("RequestComment");
			this.gridCompletedList[num, 7] = new SourceGrid.Cells.ColumnHeader("RequestName");
			this.gridCompletedList[num, 8] = new SourceGrid.Cells.ColumnHeader("CompletedDate");
			this.gridCompletedList[num, 9] = new SourceGrid.Cells.ColumnHeader("CompletedComment");
			this.gridCompletedList[num, 10] = new SourceGrid.Cells.ColumnHeader("PinCount");
			this.gridCompletedList[num, 11] = new GridInfo.ColHeader("CompletedName", false);
			this.gridCompletedList.Columns[1].Visible = false;
			this.gridInfo.SetColumnCellColor(this.gridCompletedList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridCompletedList.Columns[0].Width = 40;
			this.gridCompletedList.Columns[2].Width = 80;
			this.gridCompletedList.Columns[3].Width = 40;
			this.gridCompletedList.Columns[4].Width = 80;
			this.gridCompletedList.Columns[5].Width = 140;
			this.gridCompletedList.Columns[6].Width = 250;
			this.gridCompletedList.Columns[7].Width = 100;
			this.gridCompletedList.Columns[8].Width = 140;
			this.gridCompletedList.Columns[9].Width = 250;
			this.gridCompletedList.Columns[10].Width = 60;
			this.gridCompletedList.Columns[11].Width = 100;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00024B64 File Offset: 0x00022D64
		private void InitChart()
		{
			for (int i = 0; i < this.chartComptedTrend.Series["Series_TotalCount"].Points.Count; i++)
			{
				this.chartComptedTrend.Series["Series_TotalCount"].Points[i].Label = null;
			}
			this.chartComptedTrend.Series["Series_TotalCount"].Points.Clear();
			this.chartComptedTrend.ChartAreas[0].AxisX.CustomLabels.Clear();
			this.chartComptedTrend.Update();
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00024C0C File Offset: 0x00022E0C
		private void DrawChart(string strStratDate, string strEndDate)
		{
			this.InitChart();
			int num = 0;
			double num2 = 1.5;
			int num3 = 0;
			if (this._slCommentCompleted.Count > 0)
			{
				foreach (object obj in this._slCommentCompleted)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					string text = dictionaryEntry.Key.ToString();
					CComentCompleted ccomentCompleted = (CComentCompleted)dictionaryEntry.Value;
					int count = ccomentCompleted._slCommentHistory.Count;
					if (count > num3)
					{
						num3 = count;
					}
					this.chartComptedTrend.Series["Series_TotalCount"].Points.Add(new double[]
					{
						(double)count
					});
					string text2 = string.Empty;
					foreach (object obj2 in ccomentCompleted._slCommentHistory)
					{
						CCommentHistory ccommentHistory = (CCommentHistory)((DictionaryEntry)obj2).Value;
						string text3 = text2;
						text2 = string.Concat(new string[]
						{
							text3,
							"[",
							ccommentHistory.strBarcode,
							"] : ",
							ccommentHistory.strPinCount,
							"\r\n"
						});
					}
					text2 = text2 + "TotalPinCount : " + ccomentCompleted.iCompletedPinTotal.ToString();
					this.chartComptedTrend.Series["Series_TotalCount"].Points[num].ToolTip = text2;
					this.chartComptedTrend.Series["Series_TotalCount"].Points[num].Label = count.ToString();
					this.chartComptedTrend.Series["Series_TotalCount"].Points[num].Font = new Font("Segoe UI", 8f, FontStyle.Bold);
					this.chartComptedTrend.Series["Series_TotalCount"].Points[num].LabelForeColor = Color.FromArgb(51, 153, 51);
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
					this.chartComptedTrend.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
					this.chartComptedTrend.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
					this.chartComptedTrend.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
					num++;
				}
			}
			this.chartComptedTrend.ChartAreas[0].Position.Auto = false;
			this.chartComptedTrend.ChartAreas[0].Position.X = 0f;
			this.chartComptedTrend.ChartAreas[0].Position.Y = 10f;
			this.chartComptedTrend.ChartAreas[0].Position.Height = 75f;
			this.chartComptedTrend.ChartAreas[0].Position.Width = 99f;
			this.chartComptedTrend.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chartComptedTrend.ChartAreas[0].AxisY.Maximum = double.NaN;
			this.chartComptedTrend.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chartComptedTrend.ChartAreas[0].AxisX.Maximum = (double)(this._slCommentCompleted.Count + 1);
			this.chartComptedTrend.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chartComptedTrend.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chartComptedTrend.ChartAreas[0].AxisX.Interval = 2.0;
			this.chartComptedTrend.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chartComptedTrend.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chartComptedTrend.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chartComptedTrend.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chartComptedTrend.ChartAreas[0].AxisX.IsReversed = false;
			this.chartComptedTrend.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chartComptedTrend.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chartComptedTrend.Series["Series_TotalCount"]["PointWidth"] = "0.8";
			this.chartComptedTrend.Titles["Title1"].Text = string.Concat(new string[]
			{
				"Complated Trend [",
				strStratDate,
				" - ",
				strEndDate,
				"]"
			});
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00025228 File Offset: 0x00023428
		private void tpSM_tpCompleted_btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this.SocketCompletedList_ResetGrid();
				this.SocketCompletedList_GridColumHeadSet();
				this._slCommentCompleted.Clear();
				DateTime dateTime = new DateTime(this.tpSM_tpCompleted_dtStart.Value.Year, this.tpSM_tpCompleted_dtStart.Value.Month, this.tpSM_tpCompleted_dtStart.Value.Day, 0, 0, 0);
				DateTime t = new DateTime(this.tpSM_tpCompleted_dtEnd.Value.Year, this.tpSM_tpCompleted_dtEnd.Value.Month, this.tpSM_tpCompleted_dtEnd.Value.Day, 0, 0, 0);
				string text = dateTime.ToString("yyyy-MM-dd");
				string text2 = t.ToString("yyyy-MM-dd");
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetSocketCommentCompletedTrend]  @dtStart = '",
					text,
					"', @dtEnd = '",
					text2,
					"'"
				});
				DateTime t2 = dateTime;
				while (t2 <= t)
				{
					CComentCompleted ccomentCompleted = new CComentCompleted();
					ccomentCompleted._slCommentHistory = new SortedList();
					this._slCommentCompleted.Add(t2.ToString("yyyy-MM-dd"), ccomentCompleted);
					t2 = t2.AddDays(1.0);
				}
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.gridCompletedList.Rows.Insert(this.gridCompletedList.RowsCount);
						this.gridCompletedList[i + 1, 0] = new SourceGrid.Cells.Cell((this.gridCompletedList.RowsCount - 1).ToString());
						this.gridCompletedList[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["socketid"].ToString());
						this.gridCompletedList[i + 1, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["barcode"].ToString());
						this.gridCompletedList[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["site"].ToString());
						this.gridCompletedList[i + 1, 4] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["testername"].ToString());
						this.gridCompletedList[i + 1, 5] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["requestDate"].ToString());
						this.gridCompletedList[i + 1, 6] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["requestComment"].ToString());
						this.gridCompletedList[i + 1, 7] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["requestName"].ToString());
						this.gridCompletedList[i + 1, 8] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["completedDate"].ToString());
						this.gridCompletedList[i + 1, 9] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["completedComment"].ToString());
						this.gridCompletedList[i + 1, 10] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["pincount"].ToString());
						this.gridCompletedList[i + 1, 11] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["completedName"].ToString());
						CCommentHistory ccommentHistory = new CCommentHistory();
						ccommentHistory.strSocketID = dataSet.Tables[0].Rows[i]["socketid"].ToString();
						ccommentHistory.strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString();
						ccommentHistory.strSite = dataSet.Tables[0].Rows[i]["site"].ToString();
						ccommentHistory.strTesterName = dataSet.Tables[0].Rows[i]["testername"].ToString();
						ccommentHistory.strRequestDate = dataSet.Tables[0].Rows[i]["requestDate"].ToString();
						ccommentHistory.strRequestComment = dataSet.Tables[0].Rows[i]["requestComment"].ToString();
						ccommentHistory.strRequestName = dataSet.Tables[0].Rows[i]["requestName"].ToString();
						ccommentHistory.strCompletedDate = dataSet.Tables[0].Rows[i]["completedDate"].ToString();
						ccommentHistory.strCompletedComment = dataSet.Tables[0].Rows[i]["completedComment"].ToString();
						ccommentHistory.strPinCount = dataSet.Tables[0].Rows[i]["pincount"].ToString();
						ccommentHistory.strCompletedName = dataSet.Tables[0].Rows[i]["completedName"].ToString();
						string key = dataSet.Tables[0].Rows[i]["definedate"].ToString();
						if (this._slCommentCompleted.Contains(key))
						{
							CComentCompleted ccomentCompleted2 = (CComentCompleted)this._slCommentCompleted[key];
							ccomentCompleted2.iCompletedPinTotal += Convert.ToInt32(ccommentHistory.strPinCount);
							ccomentCompleted2._slCommentHistory.Add(ccomentCompleted2._slCommentHistory.Count, ccommentHistory);
						}
						this._barPrograss.setValue(i + 1);
					}
				}
				this.DrawChart(text, text2);
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00025A6C File Offset: 0x00023C6C
		private void tpSM_tpCompleted_btnSearch_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpSM_tpCompleted_btnSearch.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00025A89 File Offset: 0x00023C89
		private void tpSM_tpCompleted_btnSearch_MouseLeave(object sender, EventArgs e)
		{
			this.tpSM_tpCompleted_btnSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00025AA6 File Offset: 0x00023CA6
		private void tpSM_tpCompleted_btnSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.tpSM_tpCompleted_btnSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00025AC3 File Offset: 0x00023CC3
		private void tpSM_tpCompleted_btnSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00025AD0 File Offset: 0x00023CD0
		private void tpSM_tpCompleted_btnExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridCompletedList);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00025ADE File Offset: 0x00023CDE
		private void tpSM_tpCompleted_btnExcel_MouseMove(object sender, MouseEventArgs e)
		{
			this.tpSM_tpCompleted_btnExcel.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00025AFB File Offset: 0x00023CFB
		private void tpSM_tpCompleted_btnExcel_MouseLeave(object sender, EventArgs e)
		{
			this.tpSM_tpCompleted_btnExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00025B18 File Offset: 0x00023D18
		private void tpSM_tpCompleted_btnExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.tpSM_tpCompleted_btnExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00025B35 File Offset: 0x00023D35
		private void tpSM_tpCompleted_btnExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00025B44 File Offset: 0x00023D44
		private void getRepairHistory(CarrierInfo carrier)
		{
			RepairHistoryInfo repairHistoryInfo = (RepairHistoryInfo)((TabPage)base.Controls.Find("TP2", true)[0]).Controls[0];
			repairHistoryInfo.setGridRepairHistory(carrier, this.queryMgr);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00025B88 File Offset: 0x00023D88
		private void cmdATPSearch_Click(object sender, EventArgs e)
		{
			DateTime dateTime = new DateTime(this.dptATPstart.Value.Year, this.dptATPstart.Value.Month, this.dptATPstart.Value.Day, 0, 0, 0);
			DateTime t = new DateTime(this.dptATPend.Value.Year, this.dptATPend.Value.Month, this.dptATPend.Value.Day, 0, 0, 0);
			DateTime t2 = dateTime;
			while (t2 <= t)
			{
				string strDate = t2.ToString("yyyy-MM-dd");
				this.SetWeeklyReport(strDate, this.sType);
				t2 = t2.AddDays(1.0);
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00025C5C File Offset: 0x00023E5C
		private void cmdWeeklyReportSearch_Click(object sender, EventArgs e)
		{
			DateTime dateTime = new DateTime(this.dtp_week_Start.Value.Year, this.dtp_week_Start.Value.Month, this.dtp_week_Start.Value.Day, 0, 0, 0);
			DateTime dateTime2 = new DateTime(this.dtp_week_End.Value.Year, this.dtp_week_End.Value.Month, this.dtp_week_End.Value.Day, 0, 0, 0);
			foreach (object obj in this.WeeklyReportStatusPanel.Controls)
			{
				Control control = (Control)obj;
				RadioButton radioButton = (RadioButton)control;
				if (radioButton.Checked)
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Loading Data....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					int num = 1;
					this.sType = radioButton.Tag.ToString();
					if (this.sType == "DetectCarrier")
					{
						this.dtStdDate = new DateTime(this.dtp_week_Start.Value.Year, this.dtp_week_Start.Value.Month, this.dtp_week_Start.Value.Day, 0, 0, 0);
						dateTime2.Subtract(dateTime);
						this.gridWeeklyReport.Rows.Clear();
						this.gridWeeklyReport.RowsCount = 1;
						this.gridWeeklyReport.FixedRows = 1;
						this.gridWeeklyReport.ColumnsCount = 4;
						this.gridWeeklyReport[0, 0] = new GridInfo.ColHeader("No", false);
						this.gridWeeklyReport[0, 1] = new GridInfo.ColHeader("CarrierNmae", false);
						this.gridWeeklyReport[0, 2] = new GridInfo.ColHeader("Site", false);
						this.gridWeeklyReport[0, 3] = new GridInfo.ColHeader("Result", false);
						this.gridWeeklyReport.Columns[0].Width = 50;
						this.gridWeeklyReport.Columns[1].Width = 200;
						this.gridWeeklyReport.Columns[2].Width = 80;
						this.gridWeeklyReport.Columns[3].Width = 200;
						this.gridInfo.SetColumnCellColor(this.gridWeeklyReport, 0, this.gridInfo.CellColor.cell_gray_center);
						string sQuery = string.Concat(new object[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierCheckBin] @startdate = '",
							dateTime.ToShortDateString(),
							"', @enddate = '",
							dateTime2.ToShortDateString(),
							"', @product = '",
							this.cmbProduct3.Text.ToString(),
							"', @count_limit = '",
							3,
							"', @yield_limit = '",
							10,
							"'"
						});
						this.dsViewer = this.queryMgr.queryCall(sQuery);
						if (this.dsViewer != null && this.dsViewer.Tables.Count > 0 && this.dsViewer.Tables[0].Rows.Count > 0)
						{
							for (int i = 0; i < this.dsViewer.Tables[0].Rows.Count; i++)
							{
								this.gridWeeklyReport.Rows.Insert(this.gridWeeklyReport.RowsCount);
								this.gridWeeklyReport[this.gridWeeklyReport.RowsCount - 1, 0] = new SourceGrid.Cells.Cell((i + 1).ToString());
								this.gridWeeklyReport[this.gridWeeklyReport.RowsCount - 1, 1] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[i]["carriername"].ToString());
								this.gridWeeklyReport[this.gridWeeklyReport.RowsCount - 1, 2] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[i]["site"].ToString());
								this.gridWeeklyReport[this.gridWeeklyReport.RowsCount - 1, 3] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[i]["result"].ToString());
							}
						}
					}
					else if (this.sType == "Total")
					{
						TimeSpan timeSpan = dateTime2.Subtract(dateTime);
						this.gridWeeklyReport.Rows.Clear();
						this.gridWeeklyReport.RowsCount = 1;
						this.gridWeeklyReport.FixedRows = 1;
						this.gridWeeklyReport.FixedColumns = 3 + timeSpan.Days;
						this.gridWeeklyReport.ColumnsCount = 3 + timeSpan.Days;
						this.gridWeeklyReport[0, 0] = new GridInfo.ColHeader("   ", false);
						this.gridWeeklyReport[0, 0].View = this.gridInfo.CellColor.cell_back_red;
						this.gridWeeklyReport[0, 1] = new GridInfo.ColHeader("Items", false);
						this.gridWeeklyReport.Columns[0].Width = 150;
						this.gridWeeklyReport.Columns[1].Width = 200;
						this._slAllData.Clear();
						DateTime t = dateTime;
						while (t <= dateTime2)
						{
							try
							{
								string text = t.ToString("yyyy-MM-dd");
								this._barPrograss.setValue(num);
								this.gridWeeklyReport[0, ++num] = new GridInfo.ColHeader(text, false);
								this.gridWeeklyReport.Columns[num].Width = 150;
								this.SetWeeklyReport(text, this.sType);
							}
							catch (Exception ex)
							{
								ex.ToString();
							}
							t = t.AddDays(1.0);
						}
						this.getWeeklyReport(this.sType);
						this.gridInfo.SetColumnCellColor(this.gridWeeklyReport, 0, this.gridInfo.CellColor.cell_gray_center);
						this.gridWeeklyReport[0, 1].View = this.gridInfo.CellColor.cell_green;
						this.gridWeeklyReport[0, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridInfo.AutoSetGrid(this.gridWeeklyReport);
						this.gridWeeklyReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					}
					else if (this.sType == "SIBCount")
					{
						this.dtStdDate = new DateTime(this.dtp_week_Start.Value.Year, this.dtp_week_Start.Value.Month, this.dtp_week_Start.Value.Day, 0, 0, 0);
						dateTime2.Subtract(dateTime);
						this.gridWeeklyReport.Rows.Clear();
						this.gridWeeklyReport.RowsCount = 1;
						this.gridWeeklyReport.FixedRows = 1;
						this.gridWeeklyReport.FixedColumns = 5;
						this.gridWeeklyReport.ColumnsCount = 5;
						this.gridWeeklyReport[0, 0] = new GridInfo.ColHeader("Date", false);
						this.gridWeeklyReport[0, 1] = new GridInfo.ColHeader("Total number of\r\nReveived SIB", false);
						this.gridWeeklyReport[0, 2] = new GridInfo.ColHeader("Accumulated\r\ndefected Q'ty", false);
						this.gridWeeklyReport[0, 3] = new GridInfo.ColHeader("Return to SD", false);
						this.gridWeeklyReport[0, 4] = new GridInfo.ColHeader("Daily confirmed defective\r\nQ'ty", false);
						this.gridWeeklyReport.Columns[0].Width = 200;
						this.gridWeeklyReport.Columns[1].Width = 200;
						this.gridWeeklyReport.Columns[2].Width = 200;
						this.gridWeeklyReport.Columns[3].Width = 200;
						this.gridWeeklyReport.Columns[4].Width = 200;
						this.gridInfo.SetColumnCellColor(this.gridWeeklyReport, 0, this.gridInfo.CellColor.cell_gray_center);
						this._slAllData.Clear();
						DateTime t2 = dateTime;
						while (t2 <= dateTime2)
						{
							try
							{
								string strDate = t2.ToString("yyyy-MM-dd");
								this._barPrograss.setValue(num++);
								this.SetWeeklyReport(strDate, this.sType);
							}
							catch (Exception ex2)
							{
								ex2.ToString();
							}
							t2 = t2.AddDays(1.0);
						}
						this.getWeeklyReport(this.sType);
					}
					else if (this.sType == "SIBFail")
					{
						this.dtStdDate = new DateTime(this.dtp_week_Start.Value.Year, this.dtp_week_Start.Value.Month, this.dtp_week_Start.Value.Day, 0, 0, 0);
						this.gridWeeklyReport.RowsCount = 1;
						this.gridWeeklyReport.FixedRows = 1;
						this.gridWeeklyReport.FixedColumns = 5;
						this.gridWeeklyReport.ColumnsCount = 5;
						this.gridWeeklyReport[0, 0] = new GridInfo.ColHeader("Check Date", false);
						this.gridWeeklyReport[0, 1] = new GridInfo.ColHeader("SIB #", false);
						this.gridWeeklyReport[0, 2] = new GridInfo.ColHeader("Rev", false);
						this.gridWeeklyReport[0, 3] = new GridInfo.ColHeader("Fail Name", false);
						this.gridWeeklyReport[0, 4] = new GridInfo.ColHeader("Damage", false);
						this.gridWeeklyReport.Columns[0].Width = 200;
						this.gridWeeklyReport.Columns[1].Width = 200;
						this.gridWeeklyReport.Columns[2].Width = 200;
						this.gridWeeklyReport.Columns[3].Width = 200;
						this.gridWeeklyReport.Columns[4].Width = 200;
						this.gridInfo.SetColumnCellColor(this.gridWeeklyReport, 0, this.gridInfo.CellColor.cell_gray_center);
						this._slAllData.Clear();
						try
						{
							DateTime dateTime3 = dateTime2;
							string strDate2 = dateTime3.ToString("yyyy-MM-dd");
							this._barPrograss.setValue(num++);
							this.SetWeeklyReport(strDate2, this.sType);
						}
						catch (Exception ex3)
						{
							ex3.ToString();
						}
						this.getWeeklyReport(this.sType);
					}
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00026870 File Offset: 0x00024A70
		private void txtATPhostname_TextChanged(object sender, EventArgs e)
		{
			string text = this.cmbViewerBarcode.Text;
			if ((text != string.Empty || text != "") && this.dsATPhostname.Tables.Count > 0)
			{
				this.dsATPhostname.Clear();
				DataRow[] array = this.dsATPhostname.Tables[0].Select("[datatype] LIKE '%" + text + "%'");
				for (int i = 1; i <= array.Length; i++)
				{
				}
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000268F8 File Offset: 0x00024AF8
		private void cmbViewerBarcode_TextChanged(object sender, EventArgs e)
		{
			string text = this.cmbViewerBarcode.Text;
			if (text == string.Empty || text == "")
			{
				if (this.dsViewer.Tables.Count > 0)
				{
					DataRow[] array = this.dsViewer.Tables[1].Select("[location] is not null");
					this.initWareHouseList();
					for (int i = 1; i <= array.Length; i++)
					{
						this.gridViewerList.Rows.Insert(i);
						this.gridViewerList[i, 0] = new SourceGrid.Cells.Cell(i.ToString());
						this.gridViewerList[i, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 1] = new SourceGrid.Cells.Cell(array[i - 1]["location"].ToString());
						this.gridViewerList[i, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 2] = new SourceGrid.Cells.Cell(array[i - 1]["carrierno"].ToString());
						this.gridViewerList[i, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 3] = new SourceGrid.Cells.Cell(array[i - 1]["substatus"].ToString());
						this.gridViewerList[i, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 4] = new SourceGrid.Cells.Cell(array[i - 1]["device"].ToString());
						this.gridViewerList[i, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					}
					return;
				}
			}
			else if (this.dsViewer.Tables.Count > 0)
			{
				DataRow[] array = this.dsViewer.Tables[1].Select("[location] LIKE '%" + text + "%'");
				this.initWareHouseList();
				for (int j = 1; j <= array.Length; j++)
				{
					this.gridViewerList.Rows.Insert(j);
					this.gridViewerList[j, 0] = new SourceGrid.Cells.Cell(j.ToString());
					this.gridViewerList[j, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerList[j, 1] = new SourceGrid.Cells.Cell(array[j - 1]["location"].ToString());
					this.gridViewerList[j, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerList[j, 2] = new SourceGrid.Cells.Cell(array[j - 1]["carrierno"].ToString());
					this.gridViewerList[j, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerList[j, 3] = new SourceGrid.Cells.Cell(array[j - 1]["substatus"].ToString());
					this.gridViewerList[j, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerList[j, 4] = new SourceGrid.Cells.Cell(array[j - 1]["device"].ToString());
					this.gridViewerList[j, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				}
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00026C50 File Offset: 0x00024E50
		private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			string a = this.cmbGroup.SelectedItem.ToString();
			this.cmbViewerBarcode.Text = "";
			foreach (object obj in this.pnlViewer.Controls)
			{
				Control control = (Control)obj;
				RadioButton radioButton = (RadioButton)control;
				if (radioButton.Checked)
				{
					this.sType = radioButton.Tag.ToString();
					if (this.dsViewer.Tables.Count <= 0)
					{
						this.cmbGroup.SelectedText = "";
						break;
					}
					DataRow[] array = new DataRow[this.dsViewer.Tables[1].Rows.Count];
					if (this.sType == "WareHouse")
					{
						if (a == "A")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='A'");
						}
						else if (a == "C")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='C'");
						}
						else if (a == "Empty")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='Empty'");
						}
						else if (a == "Bad")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='Bad'");
						}
						else if (a == "Not Assigned")
						{
							array = this.dsViewer.Tables[1].Select("[substatus] is null or [substatus] = ''");
						}
						else
						{
							array = this.dsViewer.Tables[1].Select("[location] is not null");
						}
						this.initWareHouseList();
						for (int i = 1; i <= array.Length; i++)
						{
							this.gridViewerList.Rows.Insert(i);
							this.gridViewerList[i, 0] = new SourceGrid.Cells.Cell(i.ToString());
							this.gridViewerList[i, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[i, 1] = new SourceGrid.Cells.Cell(array[i - 1]["location"].ToString());
							this.gridViewerList[i, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[i, 2] = new SourceGrid.Cells.Cell(array[i - 1]["carrierno"].ToString());
							this.gridViewerList[i, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[i, 3] = new SourceGrid.Cells.Cell(array[i - 1]["substatus"].ToString());
							this.gridViewerList[i, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[i, 4] = new SourceGrid.Cells.Cell(array[i - 1]["device"].ToString());
							this.gridViewerList[i, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						}
					}
					else if (this.sType == "Engr")
					{
						if (this.dsViewer.Tables.Count > 0)
						{
							array = new DataRow[this.dsViewer.Tables[1].Rows.Count];
						}
						if (a == "In Engr Use")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='In Engr Use'");
						}
						else if (a == "Stand by for the Return")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='Stand by for the Return'");
						}
						else if (a == "Stand by for the Verification")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='Stand by for the Verification'");
						}
						else if (a == "Stand by for the Verification")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='Not Assigned' or [substatus] = '' or [substatus] is null");
						}
						else
						{
							array = this.dsViewer.Tables[1].Select("[location] is not null");
						}
						this.initWareHouseList();
						for (int j = 1; j <= array.Length; j++)
						{
							this.gridViewerList.Rows.Insert(j);
							this.gridViewerList[j, 0] = new SourceGrid.Cells.Cell(j.ToString());
							this.gridViewerList[j, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[j, 1] = new SourceGrid.Cells.Cell(array[j - 1]["location"].ToString());
							this.gridViewerList[j, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[j, 2] = new SourceGrid.Cells.Cell(array[j - 1]["carrierno"].ToString());
							this.gridViewerList[j, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[j, 3] = new SourceGrid.Cells.Cell(array[j - 1]["substatus"].ToString());
							this.gridViewerList[j, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[j, 4] = new SourceGrid.Cells.Cell(array[j - 1]["device"].ToString());
							this.gridViewerList[j, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						}
					}
					else if (this.sType == "Defect")
					{
						if (this.dsViewer.Tables.Count > 0)
						{
							array = new DataRow[this.dsViewer.Tables[1].Rows.Count];
						}
						if (a == "Low Yield")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='Low Yield'");
						}
						else if (a == "8 Strike")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='8 Strike'");
						}
						else if (a == "Not Assigned")
						{
							array = this.dsViewer.Tables[1].Select("[substatus]='Not Assigned' or [substatus] = '' or [substatus] is null");
						}
						else
						{
							array = this.dsViewer.Tables[1].Select("[location] is not null");
						}
						this.initWareHouseList();
						for (int k = 1; k <= array.Length; k++)
						{
							this.gridViewerList.Rows.Insert(k);
							this.gridViewerList[k, 0] = new SourceGrid.Cells.Cell(k.ToString());
							this.gridViewerList[k, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[k, 1] = new SourceGrid.Cells.Cell(array[k - 1]["location"].ToString());
							this.gridViewerList[k, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[k, 2] = new SourceGrid.Cells.Cell(array[k - 1]["carrierno"].ToString());
							this.gridViewerList[k, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[k, 3] = new SourceGrid.Cells.Cell(array[k - 1]["substatus"].ToString());
							this.gridViewerList[k, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
							this.gridViewerList[k, 4] = new SourceGrid.Cells.Cell(array[k - 1]["device"].ToString());
							this.gridViewerList[k, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						}
					}
				}
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x000274A8 File Offset: 0x000256A8
		private void cmbGroup_DropDown(object sender, EventArgs e)
		{
			foreach (object obj in this.pnlViewer.Controls)
			{
				Control control = (Control)obj;
				RadioButton radioButton = (RadioButton)control;
				if (radioButton.Checked)
				{
					string a = radioButton.Tag.ToString();
					if (a == "WareHouse")
					{
						this.getTypeDefinitionList("CarrierWareHouse", this.cmbGroup, "Total,Not Assigned");
					}
					else if (a == "Engr")
					{
						this.getTypeDefinitionList("CarrierEngr", this.cmbGroup, "Total,Not Assigned");
					}
					else if (a == "Defect")
					{
						this.getTypeDefinitionList("CarrierDefect", this.cmbGroup, "Total,Not Assigned");
					}
				}
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00027594 File Offset: 0x00025794
		private void rdoViewType_CheckChanged(object sender, EventArgs e)
		{
			this.gridViewerInfo.Rows.Clear();
			this.gridViewerList.Rows.Clear();
			this.dsViewer.Clear();
			if (sender != null && !(sender as RadioButton).Checked)
			{
				return;
			}
			foreach (object obj in this.pnlViewer.Controls)
			{
				Control control = (Control)obj;
				if (this.dsViewer.Tables.Count > 0)
				{
					RadioButton radioButton = (RadioButton)control;
					if (radioButton.Checked)
					{
						string a = radioButton.Tag.ToString();
						if (a == "WareHouse")
						{
							this.getTypeDefinitionList("CarrierWareHouse", this.cmbGroup, "Total,Not Assigned");
						}
						else if (a == "Engr")
						{
							this.getTypeDefinitionList("CarrierEngr", this.cmbGroup, "Total,Not Assigned");
						}
						else if (a == "Defect")
						{
							this.getTypeDefinitionList("CarrierDefect", this.cmbGroup, "Total,Not Assigned");
						}
					}
				}
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x000276D4 File Offset: 0x000258D4
		private void cmdWareHouseSearch_Click(object sender, EventArgs e)
		{
			this.cmbGroup.Items.Clear();
			this.dsViewer.Clear();
			foreach (object obj in this.pnlViewer.Controls)
			{
				Control control = (Control)obj;
				RadioButton radioButton = (RadioButton)control;
				if (radioButton.Checked)
				{
					string text = radioButton.Tag.ToString();
					this.initViewerGridTotal(text);
					this.initViewerGridSelected(text);
					if (text == "WareHouse")
					{
						this.setWareHouseViewer(text);
					}
					else if (text == "Engr")
					{
						this.setEngrViewer(text);
					}
					else if (text == "Defect")
					{
						this.setDefectViewer(text);
					}
				}
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x000277B4 File Offset: 0x000259B4
		private void setATPViewer(string sStr)
		{
			this.gridATPlist.Rows.Clear();
			this.gridATPlist.RowsCount = 1;
			int num = 1;
			if (sStr == "TotalList")
			{
				this.gridATPlist.ColumnsCount = 10;
				this.gridATPlist.RowsCount = 1;
				this.gridATPlist.FixedRows = 1;
				this.gridATPlist.FixedColumns = 10;
				this.gridATPlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.gridATPlist[0, 0] = new GridInfo.ColHeader("No", false);
				this.gridATPlist[0, 1] = new GridInfo.ColHeader("Hostname", false);
				this.gridATPlist[0, 2] = new GridInfo.ColHeader("ATPname", false);
				this.gridATPlist[0, 3] = new GridInfo.ColHeader("Device", false);
				this.gridATPlist[0, 4] = new GridInfo.ColHeader("HBin", false);
				this.gridATPlist[0, 5] = new GridInfo.ColHeader("HBinName", false);
				this.gridATPlist[0, 6] = new GridInfo.ColHeader("SBin", false);
				this.gridATPlist[0, 7] = new GridInfo.ColHeader("SBinName", false);
				this.gridATPlist[0, 8] = new GridInfo.ColHeader("Startdate", false);
				this.gridATPlist[0, 9] = new GridInfo.ColHeader("Enddate", false);
				this.gridATPlist.Columns[0].Width = 60;
				this.gridATPlist.Columns[1].Width = 160;
				this.gridATPlist.Columns[2].Width = 120;
				this.gridATPlist.Columns[3].Width = 100;
				this.gridATPlist.Columns[4].Width = 70;
				this.gridATPlist.Columns[5].Width = 120;
				this.gridATPlist.Columns[6].Width = 70;
				this.gridATPlist.Columns[7].Width = 140;
				this.gridATPlist.Columns[8].Width = 130;
				this.gridATPlist.Columns[9].Width = 130;
				this.gridInfo.SetColumnCellColor(this.gridATPlist, 0, this.gridInfo.CellColor.cell_gray_center);
				using (IDictionaryEnumerator enumerator = this._slAllData.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						CATPList catplist = (CATPList)((DictionaryEntry)obj).Value;
						this.gridATPlist.Rows.Insert(num);
						this.gridATPlist[num, 0] = new SourceGrid.Cells.Cell(num.ToString());
						this.gridATPlist[num, 1] = new SourceGrid.Cells.Cell(catplist.hostname.ToString());
						this.gridATPlist[num, 2] = new SourceGrid.Cells.Cell(catplist.ATPname.ToString());
						this.gridATPlist[num, 3] = new SourceGrid.Cells.Cell(catplist.device.ToString());
						this.gridATPlist[num, 4] = new SourceGrid.Cells.Cell(catplist.hbin.ToString());
						this.gridATPlist[num, 5] = new SourceGrid.Cells.Cell(catplist.hbinname.ToString());
						this.gridATPlist[num, 6] = new SourceGrid.Cells.Cell(catplist.sbin.ToString());
						this.gridATPlist[num, 7] = new SourceGrid.Cells.Cell(catplist.sbinname.ToString());
						this.gridATPlist[num, 8] = new SourceGrid.Cells.Cell(catplist.startdate.ToString());
						this.gridATPlist[num, 9] = new SourceGrid.Cells.Cell(catplist.enddate.ToString());
						num++;
					}
					return;
				}
			}
			if (sStr == "DailySummarized")
			{
				this.gridATPlist.ColumnsCount = 8;
				this.gridATPlist.RowsCount = 1;
				this.gridATPlist.FixedRows = 1;
				this.gridATPlist.FixedColumns = 8;
				this.gridATPlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.gridATPlist[0, 0] = new GridInfo.ColHeader("No", false);
				this.gridATPlist[0, 1] = new GridInfo.ColHeader("Date", false);
				this.gridATPlist[0, 2] = new GridInfo.ColHeader("Device", false);
				this.gridATPlist[0, 3] = new GridInfo.ColHeader("ATPname", false);
				this.gridATPlist[0, 4] = new GridInfo.ColHeader("Inqty", false);
				this.gridATPlist[0, 5] = new GridInfo.ColHeader("PASS", false);
				this.gridATPlist[0, 6] = new GridInfo.ColHeader("FAIL", false);
				this.gridATPlist[0, 7] = new GridInfo.ColHeader("Yield", false);
				this.gridATPlist.Columns[0].Width = 100;
				this.gridATPlist.Columns[1].Width = 150;
				this.gridATPlist.Columns[2].Width = 120;
				this.gridATPlist.Columns[3].Width = 150;
				this.gridATPlist.Columns[4].Width = 100;
				this.gridATPlist.Columns[5].Width = 100;
				this.gridATPlist.Columns[6].Width = 120;
				this.gridATPlist.Columns[7].Width = 120;
				this.gridInfo.SetColumnCellColor(this.gridATPlist, 0, this.gridInfo.CellColor.cell_gray_center);
				foreach (object obj2 in this._slAllData2)
				{
					CATPDailySummary catpdailySummary = (CATPDailySummary)((DictionaryEntry)obj2).Value;
					this.gridATPlist.Rows.Insert(num);
					this.gridATPlist[num, 0] = new SourceGrid.Cells.Cell(num.ToString());
					this.gridATPlist[num, 1] = new SourceGrid.Cells.Cell(catpdailySummary.groupdate.ToString());
					this.gridATPlist[num, 2] = new SourceGrid.Cells.Cell(catpdailySummary.device.ToString());
					this.gridATPlist[num, 3] = new SourceGrid.Cells.Cell(catpdailySummary.ATPname.ToString());
					this.gridATPlist[num, 4] = new SourceGrid.Cells.Cell(catpdailySummary.inqty.ToString());
					this.gridATPlist[num, 5] = new SourceGrid.Cells.Cell(catpdailySummary.good.ToString());
					this.gridATPlist[num, 6] = new SourceGrid.Cells.Cell(catpdailySummary.fail.ToString());
					this.gridATPlist[num, 7] = new SourceGrid.Cells.Cell(catpdailySummary.yield.ToString());
					num++;
				}
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00027F3C File Offset: 0x0002613C
		private void setWareHouseViewer(string sStr)
		{
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierViewer] @device = '",
					this.cmbProduct2.Text.ToString(),
					"',@search = '",
					sStr,
					"'"
				});
				this.dsViewer = this.queryMgr.queryCall(sQuery);
				if (this.dsViewer != null && this.dsViewer.Tables.Count > 0 && this.dsViewer.Tables[0].Rows.Count > 0)
				{
					this.gridViewerInfo.Rows.Insert(1);
					int num = int.Parse(this.dsViewer.Tables[0].Rows[0]["A"].ToString()) + int.Parse(this.dsViewer.Tables[0].Rows[0]["C"].ToString()) + int.Parse(this.dsViewer.Tables[0].Rows[0]["Bad"].ToString()) + int.Parse(this.dsViewer.Tables[0].Rows[0]["Empty"].ToString()) + int.Parse(this.dsViewer.Tables[0].Rows[0]["Other"].ToString());
					this.gridViewerInfo[1, 0] = new SourceGrid.Cells.Cell(num.ToString());
					this.gridViewerInfo[1, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 1] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["A"].ToString());
					this.gridViewerInfo[1, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 2] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["C"].ToString());
					this.gridViewerInfo[1, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 3] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["Bad"].ToString());
					this.gridViewerInfo[1, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 4] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["Empty"].ToString());
					this.gridViewerInfo[1, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 5] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["Other"].ToString());
					this.gridViewerInfo[1, 5].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				}
				if (this.dsViewer != null && this.dsViewer.Tables.Count > 0 && this.dsViewer.Tables[1].Rows.Count > 0)
				{
					for (int i = 1; i <= this.dsViewer.Tables[1].Rows.Count; i++)
					{
						this.gridViewerList.Rows.Insert(i);
						this.gridViewerList[i, 0] = new SourceGrid.Cells.Cell(i.ToString());
						this.gridViewerList[i, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 1] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["location"].ToString());
						this.gridViewerList[i, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 2] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["carrierno"].ToString());
						this.gridViewerList[i, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 3] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["substatus"].ToString());
						this.gridViewerList[i, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 4] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["device"].ToString());
						this.gridViewerList[i, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0002858C File Offset: 0x0002678C
		private void setEngrViewer(string sStr)
		{
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierViewer] @device = '",
					this.cmbProduct2.Text.ToString(),
					"',@search = '",
					sStr,
					"'"
				});
				this.dsViewer = this.queryMgr.queryCall(sQuery);
				if (this.dsViewer != null && this.dsViewer.Tables.Count > 0 && this.dsViewer.Tables[0].Rows.Count > 0)
				{
					int num = int.Parse(this.dsViewer.Tables[0].Rows[0]["stdreturn"].ToString()) + int.Parse(this.dsViewer.Tables[0].Rows[0]["stdveri"].ToString()) + int.Parse(this.dsViewer.Tables[0].Rows[0]["engruse"].ToString()) + int.Parse(this.dsViewer.Tables[0].Rows[0]["Other"].ToString());
					this.gridViewerInfo.Rows.Insert(1);
					this.gridViewerInfo[1, 0] = new SourceGrid.Cells.Cell(num.ToString());
					this.gridViewerInfo[1, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 1] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["stdreturn"].ToString());
					this.gridViewerInfo[1, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 2] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["stdveri"].ToString());
					this.gridViewerInfo[1, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 3] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["engruse"].ToString());
					this.gridViewerInfo[1, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 4] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["Other"].ToString());
					this.gridViewerInfo[1, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				}
				if (this.dsViewer != null && this.dsViewer.Tables.Count > 0 && this.dsViewer.Tables[1].Rows.Count > 0)
				{
					for (int i = 1; i <= this.dsViewer.Tables[1].Rows.Count; i++)
					{
						this.gridViewerList.Rows.Insert(i);
						this.gridViewerList[i, 0] = new SourceGrid.Cells.Cell(i.ToString());
						this.gridViewerList[i, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 1] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["location"].ToString());
						this.gridViewerList[i, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 2] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["carrierno"].ToString());
						this.gridViewerList[i, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 3] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["substatus"].ToString());
						this.gridViewerList[i, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 4] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["device"].ToString());
						this.gridViewerList[i, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00028B54 File Offset: 0x00026D54
		private void setDefectViewer(string sStr)
		{
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierViewer] @device = '",
					this.cmbProduct2.Text.ToString(),
					"',@search = '",
					sStr,
					"'"
				});
				this.dsViewer = this.queryMgr.queryCall(sQuery);
				if (this.dsViewer != null && this.dsViewer.Tables.Count > 0 && this.dsViewer.Tables[0].Rows.Count > 0)
				{
					int num = int.Parse(this.dsViewer.Tables[0].Rows[0]["lowyield"].ToString()) + int.Parse(this.dsViewer.Tables[0].Rows[0]["eightstk"].ToString()) + int.Parse(this.dsViewer.Tables[0].Rows[0]["Other"].ToString());
					this.gridViewerInfo.Rows.Insert(1);
					this.gridViewerInfo[1, 0] = new SourceGrid.Cells.Cell(num.ToString());
					this.gridViewerInfo[1, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 1] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["lowyield"].ToString());
					this.gridViewerInfo[1, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 2] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["eightstk"].ToString());
					this.gridViewerInfo[1, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					this.gridViewerInfo[1, 3] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[0].Rows[0]["Other"].ToString());
					this.gridViewerInfo[1, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				}
				if (this.dsViewer != null && this.dsViewer.Tables.Count > 0 && this.dsViewer.Tables[1].Rows.Count > 0)
				{
					for (int i = 1; i <= this.dsViewer.Tables[1].Rows.Count; i++)
					{
						this.gridViewerList.Rows.Insert(i);
						this.gridViewerList[i, 0] = new SourceGrid.Cells.Cell(i.ToString());
						this.gridViewerList[i, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 1] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["location"].ToString());
						this.gridViewerList[i, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 2] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["carrierno"].ToString());
						this.gridViewerList[i, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 3] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["substatus"].ToString());
						this.gridViewerList[i, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
						this.gridViewerList[i, 4] = new SourceGrid.Cells.Cell(this.dsViewer.Tables[1].Rows[i - 1]["device"].ToString());
						this.gridViewerList[i, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00029094 File Offset: 0x00027294
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			this.txtHistoryBarcode.Enabled = this.chkHistoryCarrierBarcode.Checked;
			this.label13.Visible = this.chkHistoryCarrierBarcode.Checked;
			this.dtp_End_Histroy.Visible = this.chkHistoryCarrierBarcode.Checked;
			this.chkDate.Visible = this.chkHistoryCarrierBarcode.Checked;
			this.txtHistoryBarcode.Text = string.Empty;
			if (this.txtHistoryBarcode.Enabled)
			{
				this.chkDate.Checked = false;
				this.groupBox11.Size = new Size(248, 55);
				return;
			}
			this.groupBox11.Size = new Size(130, 55);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00029169 File Offset: 0x00027369
		private void cmbHistoryCarrierCustomer_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierCustomer", this.cmbHistoryCarrierCustomer);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0002917D File Offset: 0x0002737D
		private void cmbHistoryProduct_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbHistoryProduct);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00029191 File Offset: 0x00027391
		private void cmbHistoryCarrierOpCode_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("Opcode", this.cmbHistoryCarrierOpCode);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000291A5 File Offset: 0x000273A5
		private void cmbHistoryCarrierCorrelation_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierCorrelation", this.cmbHistoryCarrierCorrelation);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000291B9 File Offset: 0x000273B9
		private void cmbHistoryCarrierType_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierType", this.cmbHistoryCarrierType);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x000291CD File Offset: 0x000273CD
		private void cmbHistoryCarrierTester_DropDown(object sender, EventArgs e)
		{
			this.getTesterList(this.cmbHistoryCarrierTester);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x000291DB File Offset: 0x000273DB
		private void cmbATPproduct_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbATPproduct);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000291EF File Offset: 0x000273EF
		private void cmbATPhostname_DropDown(object sender, EventArgs e)
		{
			this.getATPDefinitionList("Hostname", this.cmbATPhostname);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00029203 File Offset: 0x00027403
		private void cmbATPname_DropDown(object sender, EventArgs e)
		{
			this.getATPDefinitionList("ATPname", this.cmbATPname);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00029217 File Offset: 0x00027417
		private void cmbSelectStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0002921C File Offset: 0x0002741C
		private void cmbATPsearch_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.pnlATPviewer.Controls)
			{
				Control control = (Control)obj;
				RadioButton radioButton = (RadioButton)control;
				if (radioButton.Checked)
				{
					string atpviewer = radioButton.Tag.ToString();
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Loading Data....");
					this._barPrograss.setValue(0);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					this.SetATPReport();
					this.setATPViewer(atpviewer);
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0002932C File Offset: 0x0002752C
		private void rdoATPType_CheckedChanged(object sender, EventArgs e)
		{
			foreach (object obj in this.pnlATPviewer.Controls)
			{
				Control control = (Control)obj;
				RadioButton radioButton = (RadioButton)control;
				if (radioButton.Checked)
				{
					this.sType = radioButton.Tag.ToString();
					this.setATPViewer(this.sType);
				}
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x000293B0 File Offset: 0x000275B0
		private void cmbATPexcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridATPlist);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x000293C0 File Offset: 0x000275C0
		private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				int rowIndex = e.RowIndex;
				if (new AddCarrier(new CarrierInfo
				{
					CarrierId = this.radGridView1.Rows[rowIndex].Cells["CarrierId"].Value.ToString(),
					Barcode = this.radGridView1.Rows[rowIndex].Cells["Barcode"].Value.ToString(),
					CarrierNo = this.radGridView1.Rows[rowIndex].Cells["CarrierNo"].Value.ToString(),
					Status = this.radGridView1.Rows[rowIndex].Cells["Status"].Value.ToString(),
					SubStatus = this.radGridView1.Rows[rowIndex].Cells["SubStatus"].Value.ToString(),
					Device = this.radGridView1.Rows[rowIndex].Cells["Device"].Value.ToString(),
					Correlation = this.radGridView1.Rows[rowIndex].Cells["Correlation"].Value.ToString(),
					OperationCode = this.radGridView1.Rows[rowIndex].Cells["OP Code"].Value.ToString(),
					CarrierType = this.radGridView1.Rows[rowIndex].Cells["Carrier Type"].Value.ToString(),
					Customer = this.radGridView1.Rows[rowIndex].Cells["Customer"].Value.ToString(),
					Site = this.radGridView1.Rows[rowIndex].Cells["Site"].Value.ToString(),
					CleanCnt = this.radGridView1.Rows[rowIndex].Cells["CleanCnt"].Value.ToString(),
					CreateTime = this.radGridView1.Rows[rowIndex].Cells["CreateTime"].Value.ToString(),
					CreateUser = this.radGridView1.Rows[rowIndex].Cells["CreateUser"].Value.ToString(),
					LastCleanTime = this.radGridView1.Rows[rowIndex].Cells["LastCleanTime"].Value.ToString(),
					LastEventTime = this.radGridView1.Rows[rowIndex].Cells["LastEventTime"].Value.ToString(),
					LastEventUser = this.radGridView1.Rows[rowIndex].Cells["LastEventUser"].Value.ToString(),
					LastrepairTime = this.radGridView1.Rows[rowIndex].Cells["LastrepairTime"].Value.ToString(),
					LimitCleanCnt = this.radGridView1.Rows[rowIndex].Cells["LimitCleanCnt"].Value.ToString(),
					LimitrepairCnt = this.radGridView1.Rows[rowIndex].Cells["LimitrepairCnt"].Value.ToString(),
					Memo = this.radGridView1.Rows[rowIndex].Cells["Memo"].Value.ToString(),
					PkgType = this.radGridView1.Rows[rowIndex].Cells["PkgType"].Value.ToString(),
					repairCnt = this.radGridView1.Rows[rowIndex].Cells["repairCnt"].Value.ToString(),
					TesterName = this.radGridView1.Rows[rowIndex].Cells["TesterName"].Value.ToString(),
					LoadTester = this.radGridView1.Rows[rowIndex].Cells["LoadTester"].Value.ToString(),
					TouchDownCnt = this.radGridView1.Rows[rowIndex].Cells["TouchDownCnt"].Value.ToString(),
					MainBarcode = this.radGridView1.Rows[rowIndex].Cells["Main_Barcode"].Value.ToString(),
					SubBarcode1 = this.radGridView1.Rows[rowIndex].Cells["SIB1_Barcode"].Value.ToString(),
					SubBarcode2 = this.radGridView1.Rows[rowIndex].Cells["SIB2_Barcode"].Value.ToString(),
					RepairCodeSite1 = this.radGridView1.Rows[rowIndex].Cells["RepairCode_Site1"].Value.ToString(),
					RepairCodeSite2 = this.radGridView1.Rows[rowIndex].Cells["RepairCode_Site2"].Value.ToString(),
					MCN = this.radGridView1.Rows[rowIndex].Cells["MCN#"].Value.ToString(),
					Revision = this.radGridView1.Rows[rowIndex].Cells["Revision"].Value.ToString()
				}, this._slAuthList)
				{
					_factorySetting = this._factorySetting,
					_cimitarUser = this._cimitarUser,
					sType = "Modify"
				}.ShowDialog() == DialogResult.OK)
				{
					this.cmdSearch_Click(null, null);
				}
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00029A57 File Offset: 0x00027C57
		private void cmbProduct4_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("CarrierProduct", this.cmbProduct4);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00029A6C File Offset: 0x00027C6C
		private void cmdCorrSearch_Click(object sender, EventArgs e)
		{
			try
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCorrelationList]  @barcode = '",
					this.txtCorrelationPart.Text,
					"',  @product = '",
					this.cmbProduct4.Text,
					"'"
				});
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					this.gridCorrList.DataSource = new DataTable();
					this.gridCorrHistory.DataSource = new DataTable();
					this.gridCorrList.DataSource = dataSet.Tables[0];
					this.gridCorrList.AllowEditRow = false;
					this.gridCorrList.AllowAddNewRow = false;
					this.gridCorrList.ShowGroupPanel = false;
					this.gridCorrList.EnableFiltering = true;
					this.gridCorrList.EnableSorting = true;
					this.gridCorrList.EnableGrouping = true;
					this.gridCorrList.MasterView.TableHeaderRow.IsVisible = true;
					this.gridCorrList.MasterTemplate.AllowCellContextMenu = false;
					this.gridCorrList.Columns[0].Width = 120;
					this.gridCorrList.Columns[1].Width = 100;
					this.gridCorrList.Columns[2].Width = 100;
					this.gridCorrList.Columns[3].Width = 100;
					this.gridCorrList.Columns[4].Width = 150;
					this.gridCorrList.Columns[5].Width = 150;
					this.gridCorrList.Columns[6].Width = 150;
					this.gridCorrList.Columns[7].Width = 80;
					this.gridCorrList.Columns[8].Width = 250;
					this.gridCorrList.Columns[9].Width = 250;
					this.gridCorrList.Columns[10].Width = 150;
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						this.getCorrPartHistory(dataSet.Tables[0].Rows[0]["Barcode"].ToString());
					}
				}
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00029DD4 File Offset: 0x00027FD4
		private void getCorrPartHistory(string sBarcode)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Check", typeof(bool)));
			dataTable.Columns.Add(new DataColumn("HistoryID", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Barcode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("NickName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Prod Remark", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CheckQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ConfirmDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ConfirmUser", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Special remark", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UpdateTime", typeof(string)));
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCorrelationPartHistory]   @barcode = '" + sBarcode + "'";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				dataTable.Rows.Add(new string[]
				{
					"false",
					dataSet.Tables[0].Rows[i]["HistoryId"].ToString(),
					dataSet.Tables[0].Rows[i]["Barcode"].ToString(),
					dataSet.Tables[0].Rows[i]["NickName"].ToString(),
					dataSet.Tables[0].Rows[i]["ProdRemark"].ToString(),
					dataSet.Tables[0].Rows[i]["Qty"].ToString(),
					dataSet.Tables[0].Rows[i]["CheckQty"].ToString(),
					dataSet.Tables[0].Rows[i]["ConfirmDate"].ToString(),
					dataSet.Tables[0].Rows[i]["ConfirmUser"].ToString(),
					dataSet.Tables[0].Rows[i]["SpecialRemark"].ToString(),
					dataSet.Tables[0].Rows[i]["UpdateTime"].ToString()
				});
			}
			this.gridCorrHistory.DataSource = dataTable;
			GridViewCheckBoxColumn gridViewCheckBoxColumn = (GridViewCheckBoxColumn)this.gridCorrHistory.Columns[0];
			gridViewCheckBoxColumn.HeaderText = "";
			gridViewCheckBoxColumn.Name = "Check";
			gridViewCheckBoxColumn.Width = 20;
			gridViewCheckBoxColumn.EnableHeaderCheckBox = true;
			this.gridCorrHistory.AllowAddNewRow = false;
			this.gridCorrHistory.ShowGroupPanel = false;
			this.gridCorrHistory.EnableFiltering = true;
			this.gridCorrHistory.EnableSorting = true;
			this.gridCorrHistory.EnableGrouping = true;
			this.gridCorrHistory.MasterView.TableHeaderRow.IsVisible = true;
			this.gridCorrHistory.MasterTemplate.AllowCellContextMenu = false;
			this.gridCorrHistory.Columns[1].IsVisible = false;
			this.gridCorrHistory.Columns[0].Width = 20;
			this.gridCorrHistory.Columns[1].Width = 60;
			this.gridCorrHistory.Columns[2].Width = 120;
			this.gridCorrHistory.Columns[3].Width = 100;
			this.gridCorrHistory.Columns[4].Width = 250;
			this.gridCorrHistory.Columns[5].Width = 100;
			this.gridCorrHistory.Columns[6].Width = 100;
			this.gridCorrHistory.Columns[7].Width = 150;
			this.gridCorrHistory.Columns[8].Width = 150;
			this.gridCorrHistory.Columns[9].Width = 250;
			this.gridCorrHistory.Columns[10].Width = 150;
			for (int j = 1; j < this.gridCorrHistory.Columns.Count; j++)
			{
				this.gridCorrHistory.Columns[j].ReadOnly = true;
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0002A360 File Offset: 0x00028560
		private void gridCorrList_CellClick(object sender, GridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				int rowIndex = e.RowIndex;
				string sBarcode = this.gridCorrList.Rows[rowIndex].Cells["Barcode"].Value.ToString();
				this.getCorrPartHistory(sBarcode);
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0002A3B0 File Offset: 0x000285B0
		private void gridCorrList_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				int rowIndex = e.RowIndex;
				string text = this.gridCorrList.Rows[rowIndex].Cells["Barcode"].Value.ToString();
				string product = this.gridCorrList.Rows[rowIndex].Cells["NickName"].Value.ToString();
				string prodRemark = this.gridCorrList.Rows[rowIndex].Cells["Prod Remark"].Value.ToString();
				if (new AddCorrelationPartHistory
				{
					_factorySetting = this._factorySetting,
					_cimitarUser = this._cimitarUser,
					corrHistory = 
					{
						Barcode = text,
						Product = product,
						ProdRemark = prodRemark
					}
				}.ShowDialog() == DialogResult.OK)
				{
					this.getCorrPartHistory(text);
				}
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0002A4AC File Offset: 0x000286AC
		private void cmdAddCorrHistory_Click(object sender, EventArgs e)
		{
			if (this.gridCorrList.RowCount == 0 || this.gridCorrList.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select correlation part list", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			AddCorrelationPartHistory addCorrelationPartHistory = new AddCorrelationPartHistory();
			addCorrelationPartHistory._factorySetting = this._factorySetting;
			addCorrelationPartHistory._cimitarUser = this._cimitarUser;
			int index = this.gridCorrList.SelectedRows[0].Index;
			addCorrelationPartHistory.corrHistory.Barcode = this.gridCorrList.Rows[index].Cells["Barcode"].Value.ToString();
			addCorrelationPartHistory.corrHistory.Product = this.gridCorrList.Rows[index].Cells["NickName"].Value.ToString();
			addCorrelationPartHistory.corrHistory.ProdRemark = this.gridCorrList.Rows[index].Cells["Prod Remark"].Value.ToString();
			if (addCorrelationPartHistory.ShowDialog() == DialogResult.OK)
			{
				this.getCorrPartHistory(addCorrelationPartHistory.corrHistory.Barcode);
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0002A5DA File Offset: 0x000287DA
		private void cmdCorrExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel((DataTable)this.gridCorrList.DataSource);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0002A5F4 File Offset: 0x000287F4
		private void cmdDelCorrHistory_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to delete checked history?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string sBarcode = string.Empty;
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i < this.gridCorrHistory.RowCount; i++)
				{
					if ((bool)this.gridCorrHistory.Rows[i].Cells[0].Value)
					{
						sBarcode = this.gridCorrHistory.Rows[i].Cells[2].Value.ToString();
						arrayList.Add(this.gridCorrHistory.Rows[i].Cells[1].Value.ToString());
					}
				}
				if (arrayList.Count == 0)
				{
					MessageBox.Show("Please Check the history to be deleted", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				for (int j = 0; j < arrayList.Count; j++)
				{
					string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetCorrelationPartHistory]   @type = 'Remove',  @historyid = '" + arrayList[j] + "'";
					this.queryMgr.queryCall(sQuery);
				}
				this.getCorrPartHistory(sBarcode);
			}
		}

		// Token: 0x04000164 RID: 356
		private QueryMgr queryMgr;

		// Token: 0x04000165 RID: 357
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000166 RID: 358
		private string _strFind = string.Empty;

		// Token: 0x04000167 RID: 359
		private string sMenu = string.Empty;

		// Token: 0x04000168 RID: 360
		private string sType = string.Empty;

		// Token: 0x04000169 RID: 361
		private SortedList _slCarrierType;

		// Token: 0x0400016A RID: 362
		private SortedList _slCarrierTypeSIB;

		// Token: 0x0400016B RID: 363
		private SortedList _slAllData;

		// Token: 0x0400016C RID: 364
		private SortedList _slAllData2;

		// Token: 0x0400016D RID: 365
		private SortedList _slAllDataSIB;

		// Token: 0x0400016E RID: 366
		public SortedList _slSlotType;

		// Token: 0x0400016F RID: 367
		private string sReasonCode = string.Empty;

		// Token: 0x04000170 RID: 368
		private SortedList _slCode = new SortedList();

		// Token: 0x04000171 RID: 369
		private ContextMenu menuCarrierList = new ContextMenu();

		// Token: 0x04000172 RID: 370
		private ContextMenu menuCarrierMgr = new ContextMenu();

		// Token: 0x04000173 RID: 371
		private ContextMenu menuSWVersion = new ContextMenu();

		// Token: 0x04000174 RID: 372
		private ContextMenu menuChart = new ContextMenu();

		// Token: 0x04000175 RID: 373
		private SortedList _slAuthList = new SortedList();

		// Token: 0x04000176 RID: 374
		private SortedList _slSelectedCarrier = new SortedList();

		// Token: 0x04000177 RID: 375
		private bool bAdminFlag;

		// Token: 0x04000178 RID: 376
		private DataSet dsFailCode = new DataSet();

		// Token: 0x04000179 RID: 377
		private DataSet dsRepairCode = new DataSet();

		// Token: 0x0400017A RID: 378
		private DataSet dsViewer = new DataSet();

		// Token: 0x0400017B RID: 379
		private DateTime dtStdDate = default(DateTime);

		// Token: 0x0400017C RID: 380
		private DataSet dsATPhostname = new DataSet();

		// Token: 0x0400017D RID: 381
		private DataSet dsATPatp = new DataSet();

		// Token: 0x0400017E RID: 382
		private DataTable dtCarrierList = new DataTable();

		// Token: 0x0400017F RID: 383
		private CarrierInfo selectedCarrier = new CarrierInfo();

		// Token: 0x04000180 RID: 384
		private Thread _thread;

		// Token: 0x04000181 RID: 385
		private BarPrograss _barPrograss;

		// Token: 0x04000182 RID: 386
		private SortedList _slSearchSocketList;

		// Token: 0x04000183 RID: 387
		private SortedList _slCommentHistory;

		// Token: 0x04000184 RID: 388
		private string _strSearchSocketid;

		// Token: 0x04000185 RID: 389
		private bool bSocketAdmin;

		// Token: 0x04000186 RID: 390
		private SortedList _slCommentCompleted;

		// Token: 0x04000187 RID: 391
		private int iRepairRow = 3;

		// Token: 0x04000188 RID: 392
		private int iCleanRow = 3;

		// Token: 0x04000189 RID: 393
		private int iRIndex = 1;

		// Token: 0x0400018A RID: 394
		private int iCIndex = 1;

		// Token: 0x0400018B RID: 395
		private SourceGrid.Cells.Views.Cell cell_right_gray;

		// Token: 0x0400018C RID: 396
		private SourceGrid.Cells.Views.Cell cell_left_gray;

		// Token: 0x0400018D RID: 397
		private SourceGrid.Cells.Views.Cell cell_total;

		// Token: 0x0400018E RID: 398
		private SourceGrid.Cells.Views.Cell cell_green;

		// Token: 0x0400018F RID: 399
		private SourceGrid.Cells.Views.Cell cell_red;

		// Token: 0x04000190 RID: 400
		private SourceGrid.Cells.Views.Cell cell_right_sgray;

		// Token: 0x04000191 RID: 401
		private SourceGrid.Cells.Views.Cell cell_left_sgray;

		// Token: 0x04000192 RID: 402
		private SourceGrid.Cells.Views.Cell cell_right_dark_sgray;

		// Token: 0x04000193 RID: 403
		private SourceGrid.Cells.Views.Cell cell_left_dark_sgray;

		// Token: 0x04000194 RID: 404
		private SourceGrid.Cells.Views.Cell cell_right;

		// Token: 0x04000195 RID: 405
		private SourceGrid.Cells.Views.Cell cell_left;

		// Token: 0x04000196 RID: 406
		private SourceGrid.Cells.Views.Cell cell_center;

		// Token: 0x04000197 RID: 407
		private SourceGrid.Cells.Views.Cell cell_limit;

		// Token: 0x04000198 RID: 408
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x04000199 RID: 409
		private SourceGrid.Cells.Views.Cell cell_header2;

		// Token: 0x0400019A RID: 410
		private SourceGrid.Cells.Views.Cell cell_header3;

		// Token: 0x0400019B RID: 411
		private SourceGrid.Cells.Views.Cell cell_header4;

		// Token: 0x0400019C RID: 412
		private SourceGrid.Cells.Views.Cell cell_header5;

		// Token: 0x0400019D RID: 413
		private SourceGrid.Cells.Views.Cell cell_header6;

		// Token: 0x0400019E RID: 414
		private SourceGrid.Cells.Views.Cell cell_yello;

		// Token: 0x0200002E RID: 46
		public class CarrierColumn
		{
			// Token: 0x04000381 RID: 897
			public const int No = 0;

			// Token: 0x04000382 RID: 898
			public const int CarrierId = 1;

			// Token: 0x04000383 RID: 899
			public const int Barcode = 2;

			// Token: 0x04000384 RID: 900
			public const int CarrierNo = 3;

			// Token: 0x04000385 RID: 901
			public const int Status = 4;

			// Token: 0x04000386 RID: 902
			public const int SubStatus = 5;

			// Token: 0x04000387 RID: 903
			public const int Device = 6;

			// Token: 0x04000388 RID: 904
			public const int Correlation = 7;

			// Token: 0x04000389 RID: 905
			public const int OperationCode = 8;

			// Token: 0x0400038A RID: 906
			public const int CarrierType = 9;

			// Token: 0x0400038B RID: 907
			public const int Customer = 10;

			// Token: 0x0400038C RID: 908
			public const int Site = 11;

			// Token: 0x0400038D RID: 909
			public const int LoadTester = 12;

			// Token: 0x0400038E RID: 910
			public const int TesterName = 13;

			// Token: 0x0400038F RID: 911
			public const int PkgType = 14;

			// Token: 0x04000390 RID: 912
			public const int TouchDownCnt = 15;

			// Token: 0x04000391 RID: 913
			public const int CleanCnt = 16;

			// Token: 0x04000392 RID: 914
			public const int repairCnt = 17;

			// Token: 0x04000393 RID: 915
			public const int LimitCleanCnt = 18;

			// Token: 0x04000394 RID: 916
			public const int LimitrepairCnt = 19;

			// Token: 0x04000395 RID: 917
			public const int Memo = 20;

			// Token: 0x04000396 RID: 918
			public const int LastCleanTime = 21;

			// Token: 0x04000397 RID: 919
			public const int LastrepairTime = 22;

			// Token: 0x04000398 RID: 920
			public const int CreateUser = 23;

			// Token: 0x04000399 RID: 921
			public const int CreateTime = 24;

			// Token: 0x0400039A RID: 922
			public const int LastEventUser = 25;

			// Token: 0x0400039B RID: 923
			public const int LastEventTime = 26;

			// Token: 0x0400039C RID: 924
			public const int LastLoadTester = 27;

			// Token: 0x0400039D RID: 925
			public const int Revision = 28;

			// Token: 0x0400039E RID: 926
			public const int MCN = 29;

			// Token: 0x0400039F RID: 927
			public const int MainCarrier = 30;

			// Token: 0x040003A0 RID: 928
			public const int SIB1 = 31;

			// Token: 0x040003A1 RID: 929
			public const int SIB2 = 32;

			// Token: 0x040003A2 RID: 930
			public const int RepairCodeSite1 = 33;

			// Token: 0x040003A3 RID: 931
			public const int RepairCodeSite2 = 34;
		}

		// Token: 0x0200002F RID: 47
		public class HistoryColumn
		{
			// Token: 0x040003A4 RID: 932
			public const int No = 0;

			// Token: 0x040003A5 RID: 933
			public const int CarrierId = 1;

			// Token: 0x040003A6 RID: 934
			public const int Barcode = 2;

			// Token: 0x040003A7 RID: 935
			public const int CarrierNo = 3;

			// Token: 0x040003A8 RID: 936
			public const int Status = 4;

			// Token: 0x040003A9 RID: 937
			public const int Device = 5;

			// Token: 0x040003AA RID: 938
			public const int Correlation = 6;

			// Token: 0x040003AB RID: 939
			public const int CarrierType = 7;

			// Token: 0x040003AC RID: 940
			public const int LoadTester = 8;

			// Token: 0x040003AD RID: 941
			public const int TouchDownCnt = 9;

			// Token: 0x040003AE RID: 942
			public const int CleanCnt = 10;

			// Token: 0x040003AF RID: 943
			public const int repairCnt = 11;

			// Token: 0x040003B0 RID: 944
			public const int LastEventUser = 12;

			// Token: 0x040003B1 RID: 945
			public const int LastEventTime = 13;

			// Token: 0x040003B2 RID: 946
			public const int LastLoadTester = 14;

			// Token: 0x040003B3 RID: 947
			public const int Revision = 15;

			// Token: 0x040003B4 RID: 948
			public const int MCN = 16;

			// Token: 0x040003B5 RID: 949
			public const int Memo = 17;

			// Token: 0x040003B6 RID: 950
			public const int MainCarrier = 18;

			// Token: 0x040003B7 RID: 951
			public const int SIB1 = 19;

			// Token: 0x040003B8 RID: 952
			public const int SIB2 = 20;

			// Token: 0x040003B9 RID: 953
			public const int RepairCodeSite1 = 21;

			// Token: 0x040003BA RID: 954
			public const int RepairCodeSite2 = 22;

			// Token: 0x040003BB RID: 955
			public const int LastCleanTime = 23;

			// Token: 0x040003BC RID: 956
			public const int LastrepairTime = 24;

			// Token: 0x040003BD RID: 957
			public const int OperationCode = 25;

			// Token: 0x040003BE RID: 958
			public const int Customer = 26;

			// Token: 0x040003BF RID: 959
			public const int Site = 27;

			// Token: 0x040003C0 RID: 960
			public const int TesterName = 28;

			// Token: 0x040003C1 RID: 961
			public const int PkgType = 29;

			// Token: 0x040003C2 RID: 962
			public const int LimitCleanCnt = 30;

			// Token: 0x040003C3 RID: 963
			public const int LimitrepairCnt = 31;

			// Token: 0x040003C4 RID: 964
			public const int CreateUser = 32;

			// Token: 0x040003C5 RID: 965
			public const int CreateTime = 33;
		}

		// Token: 0x02000030 RID: 48
		public class SocketCommentHistoryColumn
		{
			// Token: 0x040003C6 RID: 966
			public const int No = 0;

			// Token: 0x040003C7 RID: 967
			public const int Site = 1;

			// Token: 0x040003C8 RID: 968
			public const int Tester = 2;

			// Token: 0x040003C9 RID: 969
			public const int RequestDate = 3;

			// Token: 0x040003CA RID: 970
			public const int RequestComment = 4;

			// Token: 0x040003CB RID: 971
			public const int RequestName = 5;

			// Token: 0x040003CC RID: 972
			public const int CompletedDate = 6;

			// Token: 0x040003CD RID: 973
			public const int CompletedComment = 7;

			// Token: 0x040003CE RID: 974
			public const int PinCount = 8;

			// Token: 0x040003CF RID: 975
			public const int CompletedName = 9;
		}

		// Token: 0x02000031 RID: 49
		public class SocketCommentHistoryPeriodColumn
		{
			// Token: 0x040003D0 RID: 976
			public const int No = 0;

			// Token: 0x040003D1 RID: 977
			public const int Socketid = 1;

			// Token: 0x040003D2 RID: 978
			public const int Barcode = 2;

			// Token: 0x040003D3 RID: 979
			public const int Site = 3;

			// Token: 0x040003D4 RID: 980
			public const int TesterName = 4;

			// Token: 0x040003D5 RID: 981
			public const int RequestDate = 5;

			// Token: 0x040003D6 RID: 982
			public const int RequestComment = 6;

			// Token: 0x040003D7 RID: 983
			public const int RequestName = 7;

			// Token: 0x040003D8 RID: 984
			public const int CompletedDate = 8;

			// Token: 0x040003D9 RID: 985
			public const int CompletedComment = 9;

			// Token: 0x040003DA RID: 986
			public const int PinCount = 10;

			// Token: 0x040003DB RID: 987
			public const int CompletedName = 11;
		}

		// Token: 0x02000032 RID: 50
		public class SocketColumn
		{
			// Token: 0x040003DC RID: 988
			public const int No = 0;

			// Token: 0x040003DD RID: 989
			public const int Socketid = 1;

			// Token: 0x040003DE RID: 990
			public const int Barcode = 2;

			// Token: 0x040003DF RID: 991
			public const int Device = 3;

			// Token: 0x040003E0 RID: 992
			public const int SocketType = 4;

			// Token: 0x040003E1 RID: 993
			public const int Pn = 5;

			// Token: 0x040003E2 RID: 994
			public const int Customer = 6;

			// Token: 0x040003E3 RID: 995
			public const int PkgType = 7;

			// Token: 0x040003E4 RID: 996
			public const int Mfg = 8;

			// Token: 0x040003E5 RID: 997
			public const int Status = 9;

			// Token: 0x040003E6 RID: 998
			public const int TesterName = 10;

			// Token: 0x040003E7 RID: 999
			public const int Memo = 11;

			// Token: 0x040003E8 RID: 1000
			public const int CreateUser = 12;

			// Token: 0x040003E9 RID: 1001
			public const int CreateTime = 13;

			// Token: 0x040003EA RID: 1002
			public const int LastEventUser = 14;

			// Token: 0x040003EB RID: 1003
			public const int LastEventTime = 15;
		}

		// Token: 0x02000033 RID: 51
		private class sorting : IComparer, IComparer<CCarrierFailModeData>
		{
			// Token: 0x06000209 RID: 521 RVA: 0x0003EA0C File Offset: 0x0003CC0C
			public int Compare(CCarrierFailModeData one, CCarrierFailModeData two)
			{
				return two.Count.CompareTo(one.Count);
			}

			// Token: 0x0600020A RID: 522 RVA: 0x0003EA1F File Offset: 0x0003CC1F
			public int Compare(object one, object two)
			{
				return this.Compare((CCarrierFailModeData)one, (CCarrierFailModeData)two);
			}
		}
	}
}
