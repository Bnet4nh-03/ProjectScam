using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.UnitDataModule.CIMitarAdminWS;
using Amkor.CADModules.UnitDataModule.Class;
using Amkor.CADModules.UnitDataModule.Control;
using Amkor.CADModules.UnitDataModule.Properties;
using Amkor.CADModules.UnitDataModule.View;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.UnitDataModule
{
	// Token: 0x02000026 RID: 38
	public partial class UnitDataAnalysis : BaseWinView
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00005DE4 File Offset: 0x00003FE4
		public UnitDataAnalysis()
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

		// Token: 0x060000A7 RID: 167 RVA: 0x00005F10 File Offset: 0x00004110
		public UnitDataAnalysis(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00006004 File Offset: 0x00004204
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006014 File Offset: 0x00004214
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

		// Token: 0x060000AA RID: 170 RVA: 0x0000608C File Offset: 0x0000428C
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

		// Token: 0x060000AB RID: 171 RVA: 0x0000612C File Offset: 0x0000432C
		private void initLotListGrid()
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
			this.gridLotList[0, 4] = new GridInfo.ColHeader("Product");
			this.gridLotList.Columns[5].Width = 150;
			this.gridLotList[0, 5] = new GridInfo.ColHeader("SN");
			this.gridLotList.Columns[6].Width = 50;
			this.gridLotList[0, 6] = new GridInfo.ColHeader("LotId");
			this.gridInfo.CreateColHeaderCheckBox(this.gridLotList);
			this.gridInfo.SetColumnCellColor(this.gridLotList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridLotList.Columns[2].Visible = true;
			this.gridLotList.Columns[3].Visible = true;
			this.gridLotList.Columns[4].Visible = false;
			this.gridLotList.Columns[5].Visible = false;
			this.gridLotList.Columns[6].Visible = false;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000635C File Offset: 0x0000455C
		private void InitYieldReportGrid_PerOperation(Grid grid)
		{
			grid.ColumnsCount = 16;
			grid.RowsCount = 1;
			grid.FixedRows = 1;
			grid.Columns[0].Width = 150;
			grid[0, 0] = new GridInfo.ColHeader("Lot");
			grid.Columns[1].Width = 60;
			grid[0, 1] = new GridInfo.ColHeader("DCC");
			grid.Columns[2].Width = 80;
			grid[0, 2] = new GridInfo.ColHeader("Operation");
			grid.Columns[3].Width = 70;
			grid[0, 3] = new GridInfo.ColHeader("Product");
			grid.Columns[4].Width = 70;
			grid[0, 4] = new GridInfo.ColHeader("Tester");
			grid.Columns[5].Width = 150;
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
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00006600 File Offset: 0x00004800
		private void InitUnitResultGrid(Grid grid)
		{
			grid.ColumnsCount = 16;
			grid.RowsCount = 1;
			grid.FixedRows = 1;
			int p = 0;
			grid.Columns[p].Width = 40;
			grid[0, p++] = new GridInfo.ColHeader("No");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new GridInfo.ColHeader("SN");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("Product");
			grid.Columns[p].Width = 90;
			grid[0, p++] = new GridInfo.ColHeader("Lot");
			grid.Columns[p].Width = 50;
			grid[0, p++] = new GridInfo.ColHeader("DCC");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("Operation");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("TestType");
			grid.Columns[p].Width = 100;
			grid[0, p++] = new GridInfo.ColHeader("Test Program");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new GridInfo.ColHeader("Tester");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("PASS/FAIL");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("Start Time");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new GridInfo.ColHeader("End Time");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("Test Time");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new GridInfo.ColHeader("Tester ID");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new GridInfo.ColHeader("Fail Desc");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new GridInfo.ColHeader("MeasureValue");
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000068DC File Offset: 0x00004ADC
		private DataSet getTypeDefinitionList(string sTypeName, CheckedComboBox chkcmb)
		{
			DataSet dataSet = new DataSet();
			try
			{
				chkcmb.Items.Clear();
				string sQuery = "EXEC [CIMitar_Unit].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
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

		// Token: 0x060000AF RID: 175 RVA: 0x00006984 File Offset: 0x00004B84
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
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00006A4C File Offset: 0x00004C4C
		private void cmdSearch_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00006A78 File Offset: 0x00004C78
		private void cmdSearch_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00006AA4 File Offset: 0x00004CA4
		private void cmdSearch_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00006ACE File Offset: 0x00004CCE
		private void cmdSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00006ADC File Offset: 0x00004CDC
		private void cmdExcel_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006B08 File Offset: 0x00004D08
		private void cmdExcel_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00006B34 File Offset: 0x00004D34
		private void cmdExcel_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006B5E File Offset: 0x00004D5E
		private void cmdExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00006B6C File Offset: 0x00004D6C
		private void SAMSUNG_Load(object sender, EventArgs e)
		{
			try
			{
				this.initEvent();
				this.initLotListGrid();
				this.getTypeDefinitionList("ESI_ReportType", this.chkCmbReportType);
				if (this.chkCmbReportType.Items.Count > 0)
				{
					for (int i = 0; i < this.chkCmbReportType.Items.Count; i++)
					{
						this.chkCmbReportType.SetItemChecked(i, true);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006BF4 File Offset: 0x00004DF4
		private void btnLotSearch_Click(object sender, EventArgs e)
		{
			DataSet dataSet = new DataSet();
			this._slData.Clear();
			this.gridLotList.RowsCount = 1;
			try
			{
				string text = string.Empty;
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				string empty = string.Empty;
				string text5 = string.Empty;
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
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Lot List....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Unit].[dbo].[USP_UNIT_GetLotList] @startdate = '",
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
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					int num = this.gridLotList.RowsCount;
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string text6 = dataSet.Tables[0].Rows[i]["lotid"].ToString();
						string cellValue = dataSet.Tables[0].Rows[i]["lot"].ToString();
						string cellValue2 = dataSet.Tables[0].Rows[i]["dcc"].ToString();
						string cellValue3 = dataSet.Tables[0].Rows[i]["product"].ToString();
						string cellValue4 = string.Empty;
						if (this.rdoSN.Checked)
						{
							cellValue4 = dataSet.Tables[0].Rows[i]["sn"].ToString();
						}
						if (!(text6 == string.Empty))
						{
							this.gridLotList.Rows.Insert(num);
							if (!this.rdoDate.Checked)
							{
								this.gridLotList[num, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(true));
							}
							else
							{
								this.gridLotList[num, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
							}
							this.gridLotList[num, 1] = new Cell(num);
							this.gridLotList[num, 2] = new Cell(cellValue);
							this.gridLotList[num, 3] = new Cell(cellValue2);
							this.gridLotList[num, 4] = new Cell(cellValue3);
							this.gridLotList[num, 5] = new Cell(cellValue4);
							this.gridLotList[num, 6] = new Cell(text6);
							num++;
							this._barPrograss.setValue(i + 1);
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

		// Token: 0x060000BA RID: 186 RVA: 0x0000717C File Offset: 0x0000537C
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
					new StationIDData();
					LotData lotData = new LotData();
					UnitData unitData = new UnitData();
					SortedList sortedList = new SortedList();
					string text = string.Empty;
					string empty = string.Empty;
					string empty2 = string.Empty;
					if (this.rdoLot.Checked)
					{
						text = "LOT";
					}
					else if (this.rdoSN.Checked)
					{
						text = "SN";
					}
					for (int i = 1; i < this.gridLotList.Rows.Count; i++)
					{
						if ((bool)this.gridLotList[i, 0].Value)
						{
							lotData = new LotData();
							string key = this.gridLotList[i, 1].ToString();
							lotData.Lotid = this.gridLotList[i, 6].ToString();
							lotData.Lot = this.gridLotList[i, 2].ToString();
							lotData.Dcc = this.gridLotList[i, 3].ToString();
							lotData.sProduct = this.gridLotList[i, 4].ToString();
							lotData.sSN = this.gridLotList[i, 5].ToString();
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
						for (int j = 0; j < sortedList.Count; j++)
						{
							lotData = (LotData)sortedList.GetByIndex(j);
							string sQuery = string.Concat(new string[]
							{
								"EXEC [CIMitar_Unit].[dbo].[USP_UNIT_GetUnitResultData] @type  = '",
								text,
								"', @lot  = '",
								lotData.Lot,
								"', @sn  = '",
								lotData.sSN,
								"', @operation  = '",
								empty,
								"', @dcc  = '",
								lotData.Dcc,
								"', @testmode  = '",
								empty2,
								"'"
							});
							DataSet dataSet = this.queryCall(sQuery);
							if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
							{
								string empty3 = string.Empty;
								DataRow[] array = dataSet.Tables[0].Select(empty3, "test_seq");
								int k = 0;
								while (k < array.Length)
								{
									string device = lotData.Device;
									string sProduct = lotData.sProduct;
									string text2 = array[k]["program"].ToString();
									string text3 = array[k]["operation"].ToString();
									string key2 = array[k]["operation"].ToString();
									string text4 = array[k]["lot"].ToString();
									string text5 = array[k]["sn"].ToString();
									string text6 = array[k]["result"].ToString();
									string text7 = array[k]["dcc"].ToString();
									string text8 = array[k]["starttime"].ToString();
									string text9 = array[k]["endtime"].ToString();
									string text10 = array[k]["tester"].ToString();
									string text11 = array[k]["test_seq"].ToString();
									string fail_Value = array[k]["fail_desc"].ToString();
									string failure_message = array[k]["measure_result"].ToString();
									string testerID = array[k]["testerid"].ToString();
									DateTime value = Convert.ToDateTime(text8);
									double totalSeconds = Convert.ToDateTime(text9).Subtract(value).TotalSeconds;
									string key3 = text4 + "_" + text7;
									if (!this._slData.ContainsKey(key2))
									{
										stationData = new StationData();
										stationData.Station = text3;
										this._slData.Add(key2, stationData);
									}
									else
									{
										stationData = (StationData)this._slData[key2];
									}
									if (!stationData.slLot.ContainsKey(key3))
									{
										lotData = new LotData();
										lotData.Lotid = text4;
										lotData.Dcc = text7;
										lotData.Device = device;
										lotData.sProduct = sProduct;
										lotData.sProgram = text2;
										lotData.Station = text3;
										lotData.sStartTime = text8;
										lotData.sEndTime = text9;
										stationData.slLot.Add(key3, lotData);
									}
									else
									{
										lotData = (LotData)stationData.slLot[key3];
										lotData.sEndTime = text9;
									}
									if (!lotData.slUnit.ContainsKey(text5))
									{
										unitData = new UnitData();
										unitData.SN = text5;
										unitData.result = text6;
										unitData.StartTime = text8;
										unitData.Dcc = text7;
										unitData.Product = sProduct;
										lotData.slUnit.Add(unitData.SN, unitData);
									}
									else
									{
										unitData = (UnitData)lotData.slUnit[text5];
									}
									UnitResult unitResult = new UnitResult();
									if (text6.ToUpper() == "PASS")
									{
										unitResult.iPassCnt++;
									}
									else
									{
										unitResult.iFailCnt++;
										if (!lotData.slFailData.ContainsKey(text5))
										{
											lotData.slFailData.Add(unitData.SN, unitData);
										}
									}
									unitResult.unit_Seq = new UnitData();
									unitResult.unit_Seq.LotID = text4;
									unitResult.unit_Seq.Device = device;
									unitResult.unit_Seq.Product = sProduct;
									unitResult.unit_Seq.SN = text5;
									unitResult.unit_Seq.result = text6;
									unitResult.unit_Seq.Test_station_name = text3;
									unitResult.unit_Seq.Dcc = text7;
									unitResult.unit_Seq.StartTime = text8;
									unitResult.unit_Seq.StopTime = text9;
									unitResult.unit_Seq.Sw_version = text2;
									unitResult.unit_Seq.TestTime = totalSeconds;
									unitResult.unit_Seq.Tester = text10;
									unitResult.unit_Seq.Fail_Value = fail_Value;
									unitResult.unit_Seq.Failure_message = failure_message;
									unitResult.unit_Seq.TesterID = testerID;
									unitResult.unit_Seq.setFailData();
									string a;
									if ((a = text11) == null)
									{
										goto IL_76C;
									}
									if (!(a == "1"))
									{
										if (!(a == "2"))
										{
											if (!(a == "3"))
											{
												goto IL_76C;
											}
											unitResult.unit_Seq.Num = text11 + "rd";
										}
										else
										{
											unitResult.unit_Seq.Num = text11 + "nd";
										}
									}
									else
									{
										unitResult.unit_Seq.Num = text11 + "st";
									}
									IL_784:
									unitData.slSeq.Add(unitData.slSeq.Count + 1, unitResult);
									TesterData testerData = new TesterData();
									if (!lotData.slTester.ContainsKey(text10))
									{
										testerData = new TesterData();
										testerData.TesterName = text10;
										lotData.slTester.Add(text10, testerData);
									}
									else
									{
										testerData = (TesterData)lotData.slTester[text10];
									}
									if (!testerData.slUnit.ContainsKey(text5))
									{
										unitData = new UnitData();
										unitData.SN = text5;
										unitData.result = text6;
										unitData.StartTime = text8;
										unitData.Dcc = text7;
										unitData.Product = sProduct;
										testerData.slUnit.Add(unitData.SN, unitData);
									}
									else
									{
										unitData = (UnitData)testerData.slUnit[text5];
									}
									unitResult = new UnitResult();
									if (text6.ToUpper() == "PASS")
									{
										unitResult.iPassCnt++;
									}
									else
									{
										unitResult.iFailCnt++;
									}
									unitData.slSeq.Add(unitData.slSeq.Count + 1, unitResult);
									k++;
									continue;
									IL_76C:
									unitResult.unit_Seq.Num = text11 + "th";
									goto IL_784;
								}
							}
							this._barPrograss.setValue(j + 1);
						}
						for (int l = 0; l < this.chkCmbReportType.CheckedItems.Count; l++)
						{
							string a2;
							if ((a2 = this.chkCmbReportType.CheckedItems[l].ToString().Trim()) != null)
							{
								if (!(a2 == "Lot Yield"))
								{
									if (a2 == "Unit TestResult(Per unit)")
									{
										Grid grid = this.addControl("UnitTestResult", "Unit TestResult(Per unit)", this.tab_ReportView);
										this.InitUnitResultGrid(grid);
										this.setBinding_UnitTestResult(grid);
									}
								}
								else
								{
									Grid grid2 = this.addControl("LotYield", "Lot Yield", this.tab_ReportView);
									this.InitYieldReportGrid_PerOperation(grid2);
									grid2.Columns[4].Visible = false;
									this.setBinding_LotYield_PerStation(grid2);
								}
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

		// Token: 0x060000BB RID: 187 RVA: 0x00007BBC File Offset: 0x00005DBC
		private Grid addControl(string sPageName, string sPageText, TabControl tabControl)
		{
			Grid grid = new Grid();
			grid.BorderStyle = BorderStyle.FixedSingle;
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
			tabPage.Padding = new Padding(3);
			tabPage.Size = new Size(1, 1);
			tabPage.Font = new Font("Segoe UI", 8.25f);
			tabPage.TabIndex = 0;
			tabPage.UseVisualStyleBackColor = true;
			tabPage.Controls.Add(grid);
			tabControl.TabPages.Add(tabPage);
			grid.BringToFront();
			return grid;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00007CDC File Offset: 0x00005EDC
		private void setBinding_LotYield_PerStation(Grid gridYieldReport)
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
					gridYieldReport[num, 2] = new Cell(stationData.Station);
					gridYieldReport[num, 3] = new Cell(lotData.sProduct);
					gridYieldReport[num, 0] = new Cell(lotData.Lotid);
					gridYieldReport[num, 1] = new Cell(lotData.Dcc);
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
					if (sortedList.Count == 0)
					{
						arrayList = new ArrayList();
						arrayList.Add(gridYieldReport[0, 2].ToString());
						arrayList.Add(gridYieldReport[0, 3].ToString());
						arrayList.Add(gridYieldReport[0, 0].ToString());
						arrayList.Add(gridYieldReport[0, 1].ToString());
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
						sortedList.Add(0, arrayList);
					}
					arrayList = new ArrayList();
					arrayList.Add(stationData.Station);
					arrayList.Add(lotData.sProduct);
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
					sortedList.Add(num, arrayList);
				}
			}
			if (sortedList.Count > 0)
			{
				this._slBindingData.Add("LotYield", sortedList);
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00008408 File Offset: 0x00006608
		private void setBinding_LotYield_PerTester(Grid gridYieldReport)
		{
			SortedList slData = this._slData;
			StationData stationData = new StationData();
			new StationIDData();
			LotData lotData = new LotData();
			TesterData testerData = new TesterData();
			UnitData unitData = new UnitData();
			SortedList sortedList = new SortedList();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < slData.Count; i++)
			{
				stationData = (StationData)slData.GetByIndex(i);
				for (int j = 0; j < stationData.slLot.Count; j++)
				{
					lotData = (LotData)stationData.slLot.GetByIndex(j);
					for (int k = 0; k < lotData.slTester.Count; k++)
					{
						testerData = (TesterData)lotData.slTester.GetByIndex(k);
						for (int l = 0; l < testerData.slUnit.Count; l++)
						{
							unitData = (UnitData)testerData.slUnit.GetByIndex(l);
							if (unitData.slSeq.Count > 0)
							{
								UnitResult unitResult = (UnitResult)unitData.slSeq.GetByIndex(0);
								testerData.PASS_1A += unitResult.iPassCnt;
								testerData.FAIL_1A += unitResult.iFailCnt;
								if (unitData.slSeq.Count > 1)
								{
									unitResult = (UnitResult)unitData.slSeq.GetByIndex(1);
									testerData.PASS_2A += unitResult.iPassCnt;
									testerData.FAIL_2A += unitResult.iFailCnt;
								}
								if (unitData.slSeq.Count > 2)
								{
									unitResult = (UnitResult)unitData.slSeq.GetByIndex(2);
									testerData.PASS_1B += unitResult.iPassCnt;
									testerData.FAIL_1B += unitResult.iFailCnt;
								}
								if (unitData.slSeq.Count > 3)
								{
									unitResult = (UnitResult)unitData.slSeq.GetByIndex(3);
									testerData.PASS_2B += unitResult.iPassCnt;
									testerData.FAIL_2B += unitResult.iFailCnt;
								}
								unitResult = (UnitResult)unitData.slSeq.GetByIndex(unitData.slSeq.Count - 1);
								testerData.PASS_FINAL += unitResult.iPassCnt;
								testerData.FAIL_FINAL += unitResult.iFailCnt;
							}
						}
						gridYieldReport.Rows.Insert(gridYieldReport.RowsCount);
						int num = gridYieldReport.RowsCount - 1;
						double num2 = Math.Round(double.Parse(testerData.PASS_1A.ToString()) / (double)testerData.slUnit.Count * 100.0, 2);
						double num3 = Math.Round(double.Parse(testerData.PASS_FINAL.ToString()) / (double)testerData.slUnit.Count * 100.0, 2);
						double num4 = Math.Round(num3 - num2, 2);
						gridYieldReport[num, 2] = new Cell(stationData.Station);
						gridYieldReport[num, 3] = new Cell(lotData.sProduct);
						gridYieldReport[num, 0] = new Cell(lotData.Lotid);
						gridYieldReport[num, 1] = new Cell(lotData.Dcc);
						gridYieldReport[num, 4] = new Cell(testerData.TesterName);
						gridYieldReport[num, 5] = new Cell(lotData.sProgram);
						gridYieldReport[num, 6] = new Cell(lotData.sStartTime);
						gridYieldReport[num, 7] = new Cell(lotData.sEndTime);
						gridYieldReport[num, 8] = new Cell(testerData.slUnit.Count);
						gridYieldReport[num, 9] = new Cell(testerData.PASS_FINAL);
						gridYieldReport[num, 10] = new Cell(testerData.FAIL_FINAL);
						gridYieldReport[num, 11] = new Cell(num3.ToString() + "%");
						gridYieldReport[num, 12] = new Cell(testerData.PASS_1A);
						gridYieldReport[num, 13] = new Cell(testerData.FAIL_1A);
						gridYieldReport[num, 14] = new Cell(num2.ToString() + "%");
						gridYieldReport[num, 15] = new Cell(num4.ToString() + "%");
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
							sortedList.Add(0, arrayList);
						}
						arrayList = new ArrayList();
						arrayList.Add(lotData.Lotid);
						arrayList.Add(lotData.Dcc);
						arrayList.Add(stationData.Station);
						arrayList.Add(lotData.sProduct);
						arrayList.Add(testerData.TesterName);
						arrayList.Add(lotData.sProgram);
						arrayList.Add(lotData.sStartTime);
						arrayList.Add(lotData.sEndTime);
						arrayList.Add(testerData.slUnit.Count);
						arrayList.Add(testerData.PASS_FINAL);
						arrayList.Add(testerData.FAIL_FINAL);
						arrayList.Add(num3.ToString() + "%");
						arrayList.Add(testerData.PASS_1A);
						arrayList.Add(testerData.FAIL_1A);
						arrayList.Add(num2.ToString() + "%");
						arrayList.Add(num4.ToString() + "%");
						sortedList.Add(num, arrayList);
					}
				}
			}
			if (sortedList.Count > 0)
			{
				this._slBindingData.Add("LotYield_PerTester", sortedList);
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00008BA8 File Offset: 0x00006DA8
		private void setBinding_UnitTestResult(Grid gridYieldReport)
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
						for (int l = 0; l < unitData.slSeq.Count; l++)
						{
							UnitResult unitResult = (UnitResult)unitData.slSeq.GetByIndex(l);
							this.setBinding_row(gridYieldReport, unitResult.unit_Seq, sortedList);
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

		// Token: 0x060000BF RID: 191 RVA: 0x00008D00 File Offset: 0x00006F00
		private void setBinding_row(Grid gridYieldReport, UnitData unit, SortedList slDataList)
		{
			ArrayList arrayList = new ArrayList();
			gridYieldReport.Rows.Insert(gridYieldReport.RowsCount);
			int num = gridYieldReport.RowsCount - 1;
			int num2 = 0;
			gridYieldReport[num, num2++] = new Cell(num);
			gridYieldReport[num, num2++] = new Cell(unit.SN);
			gridYieldReport[num, num2++] = new Cell(unit.Product);
			gridYieldReport[num, num2++] = new Cell(unit.LotID);
			gridYieldReport[num, num2++] = new Cell(unit.Dcc);
			gridYieldReport[num, num2++] = new Cell(unit.Test_station_name);
			gridYieldReport[num, num2++] = new Cell(unit.Num);
			gridYieldReport[num, num2++] = new Cell(unit.Sw_version);
			gridYieldReport[num, num2++] = new Cell(unit.Tester);
			gridYieldReport[num, num2++] = new Cell(unit.result);
			gridYieldReport[num, num2++] = new Cell(unit.StartTime);
			gridYieldReport[num, num2++] = new Cell(unit.StopTime);
			gridYieldReport[num, num2++] = new Cell(unit.TestTime);
			gridYieldReport[num, num2++] = new Cell(unit.TesterID);
			gridYieldReport[num, num2++] = new Cell(unit.Fail_Value);
			gridYieldReport[num, num2++] = new Cell(unit.Failure_message);
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
			arrayList.Add(unit.LotID);
			arrayList.Add(unit.Dcc);
			arrayList.Add(unit.Test_station_name);
			arrayList.Add(unit.Num);
			arrayList.Add(unit.Sw_version);
			arrayList.Add(unit.Tester);
			arrayList.Add(unit.result);
			arrayList.Add(unit.StartTime);
			arrayList.Add(unit.StopTime);
			arrayList.Add(unit.TestTime);
			arrayList.Add(unit.TesterID);
			arrayList.Add(unit.Fail_Value);
			arrayList.Add(unit.Failure_message);
			slDataList.Add(num, arrayList);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00008FCC File Offset: 0x000071CC
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

		// Token: 0x040000D2 RID: 210
		private ContextMenu menuTypeGrid = new ContextMenu();

		// Token: 0x040000D3 RID: 211
		private ContextMenu menuGrid = new ContextMenu();

		// Token: 0x040000D4 RID: 212
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x040000D5 RID: 213
		private ToolTip toolTip = new ToolTip();

		// Token: 0x040000D6 RID: 214
		private SortedList _slData = new SortedList();

		// Token: 0x040000D7 RID: 215
		private SortedList _slBindingData = new SortedList();

		// Token: 0x040000D8 RID: 216
		private ArrayList arrCellColor = new ArrayList();

		// Token: 0x040000D9 RID: 217
		private SortedList slUploadData = new SortedList();

		// Token: 0x040000DA RID: 218
		private Thread _thread;

		// Token: 0x040000DB RID: 219
		private BarPrograss _barPrograss;

		// Token: 0x040000DC RID: 220
		private ArrayList arrExceptChar = new ArrayList
		{
			"\\",
			"/",
			"?",
			"*",
			"[",
			"]"
		};
	}
}
