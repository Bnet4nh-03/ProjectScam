using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.SAMSUNGModule.CIMitarAdminWS;
using Amkor.CADModules.SAMSUNGModule.Class;
using Amkor.CADModules.SAMSUNGModule.Control;
using Amkor.CADModules.SAMSUNGModule.Properties;
using Amkor.CADModules.SAMSUNGModule.View;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.SAMSUNGModule
{
	// Token: 0x02000026 RID: 38
	public partial class SAMSUNG : BaseWinView
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00005DCC File Offset: 0x00003FCC
		public SAMSUNG()
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

		// Token: 0x060000A7 RID: 167 RVA: 0x00005EF8 File Offset: 0x000040F8
		public SAMSUNG(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00005FEC File Offset: 0x000041EC
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00005FFC File Offset: 0x000041FC
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

		// Token: 0x060000AA RID: 170 RVA: 0x00006074 File Offset: 0x00004274
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

		// Token: 0x060000AB RID: 171 RVA: 0x00006114 File Offset: 0x00004314
		private void initLotListGrid()
		{
			this.gridLotList.ColumnsCount = 7;
			this.gridLotList.RowsCount = 1;
			this.gridLotList.FixedRows = 1;
			this.gridLotList.FixedColumns = 1;
			this.gridLotList.Columns[0].Width = 30;
			this.gridLotList[0, 0] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("");
			this.gridLotList.Columns[1].Width = 40;
			this.gridLotList[0, 1] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("No");
			this.gridLotList.Columns[2].Width = 110;
			this.gridLotList[0, 2] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Lot");
			this.gridLotList.Columns[3].Width = 50;
			this.gridLotList[0, 3] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Dcc");
			this.gridLotList.Columns[4].Width = 50;
			this.gridLotList[0, 4] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Device");
			this.gridLotList.Columns[5].Width = 50;
			this.gridLotList[0, 5] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Product");
			this.gridLotList.Columns[6].Width = 150;
			this.gridLotList[0, 6] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("SN");
			this.gridInfo.CreateColHeaderCheckBox(this.gridLotList);
			this.gridInfo.SetColumnCellColor(this.gridLotList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridLotList.Columns[2].Visible = true;
			this.gridLotList.Columns[3].Visible = true;
			this.gridLotList.Columns[5].Visible = false;
			this.gridLotList.Columns[4].Visible = false;
			this.gridLotList.Columns[6].Visible = false;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00006344 File Offset: 0x00004544
		private void InitYieldReportGrid_PerOperation(Grid grid)
		{
			grid.ColumnsCount = 17;
			grid.RowsCount = 1;
			grid.FixedRows = 1;
			grid.Columns[0].Width = 90;
			grid[0, 0] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Lot");
			grid.Columns[1].Width = 60;
			grid[0, 1] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("DCC");
			grid.Columns[2].Width = 80;
			grid[0, 2] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Operation");
			grid.Columns[3].Width = 70;
			grid[0, 3] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Product");
			grid.Columns[4].Width = 100;
			grid[0, 4] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Device");
			grid.Columns[5].Width = 70;
			grid[0, 5] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Tester");
			grid.Columns[6].Width = 150;
			grid[0, 6] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Test Program");
			grid.Columns[7].Width = 150;
			grid[0, 7] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Lot Start Time");
			grid.Columns[8].Width = 150;
			grid[0, 8] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Lot End Time");
			grid.Columns[9].Width = 80;
			grid[0, 9] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Input");
			grid.Columns[10].Width = 80;
			grid[0, 10] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("PASS_Final");
			grid.Columns[11].Width = 80;
			grid[0, 11] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("FAIL_Final");
			grid.Columns[12].Width = 80;
			grid[0, 12] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Yield");
			grid.Columns[13].Width = 80;
			grid[0, 13] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("PASS_1st");
			grid.Columns[14].Width = 80;
			grid[0, 14] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("FAIL_1st");
			grid.Columns[15].Width = 80;
			grid[0, 15] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("FPY");
			grid.Columns[16].Width = 80;
			grid[0, 16] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Retest Rate");
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00006614 File Offset: 0x00004814
		private void InitUnitResultGrid(Grid grid)
		{
			grid.ColumnsCount = 20;
			grid.RowsCount = 1;
			grid.FixedRows = 1;
			int p = 0;
			grid.Columns[p].Width = 40;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("No");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("UN");
			grid.Columns[p].Width = 120;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("SN");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Product");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Device");
			grid.Columns[p].Width = 90;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Lot");
			grid.Columns[p].Width = 50;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("DCC");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Operation");
			grid.Columns[p].Width = 150;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Test Program");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Tester");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Station ID");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Site Number");
			grid.Columns[p].Width = 70;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("PASS/FAIL");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("HBin");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("SBin");
			grid.Columns[p].Width = 150;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Start Time");
			grid.Columns[p].Width = 150;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("End Time");
			grid.Columns[p].Width = 80;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Test Time");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("Fail Desc");
			grid.Columns[p].Width = 200;
			grid[0, p++] = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo.ColHeader("MeasureValue");
			this.gridInfo.SetColumnCellColor(grid, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000699C File Offset: 0x00004B9C
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

		// Token: 0x060000AF RID: 175 RVA: 0x00006A44 File Offset: 0x00004C44
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

		// Token: 0x060000B0 RID: 176 RVA: 0x00006B0C File Offset: 0x00004D0C
		private void cmdSearch_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00006B38 File Offset: 0x00004D38
		private void cmdSearch_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00006B64 File Offset: 0x00004D64
		private void cmdSearch_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00006B8E File Offset: 0x00004D8E
		private void cmdSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00006B9C File Offset: 0x00004D9C
		private void cmdExcel_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006BC8 File Offset: 0x00004DC8
		private void cmdExcel_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00006BF4 File Offset: 0x00004DF4
		private void cmdExcel_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006C1E File Offset: 0x00004E1E
		private void cmdExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00006C2C File Offset: 0x00004E2C
		private void SAMSUNG_Load(object sender, EventArgs e)
		{
			try
			{
				this.initEvent();
				this.initLotListGrid();
				this.getTypeDefinitionList("GB_ReportType", this.chkCmbReportType);
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

		// Token: 0x060000B9 RID: 185 RVA: 0x00006CB4 File Offset: 0x00004EB4
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
				string text5 = string.Empty;
				string text6 = string.Empty;
				if (this.rdoDate.Checked)
				{
					text6 = "DATE";
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
					text6 = "LOT";
					text3 = this.txtSearchLotid.Text.Trim();
				}
				else if (this.rdoSN.Checked)
				{
					if (this.txtSearchSN.Text.Trim() == string.Empty)
					{
						MessageBox.Show("Input SN please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					text6 = "SN";
					text4 = this.txtSearchSN.Text.Trim();
				}
				else if (this.rdoUN.Checked)
				{
					if (this.txtSearchUN.Text.Trim() == string.Empty)
					{
						MessageBox.Show("Input UN please", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					text6 = "UN";
					text5 = this.txtSearchUN.Text.Trim();
				}
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Lot List....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_SAMSUNG_GetLotList] @startdate = '",
					text,
					"', @enddate = '",
					text2,
					"', @type = '",
					text6,
					"', @lot = '",
					text3,
					"', @sn = '",
					text4,
					"', @un = '",
					text5,
					"'"
				});
				dataSet = this.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					int num = this.gridLotList.RowsCount;
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string text7 = dataSet.Tables[0].Rows[i]["lotid"].ToString();
						string cellValue = dataSet.Tables[0].Rows[i]["dcc"].ToString();
						string cellValue2 = dataSet.Tables[0].Rows[i]["devicename"].ToString();
						string cellValue3 = dataSet.Tables[0].Rows[i]["productname"].ToString();
						string cellValue4 = string.Empty;
						if (this.rdoSN.Checked || this.rdoLoadSN.Checked)
						{
							cellValue4 = dataSet.Tables[0].Rows[i]["sn"].ToString();
						}
						if (!(text7 == string.Empty))
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
							this.gridLotList[num, 2] = new Cell(text7);
							this.gridLotList[num, 3] = new Cell(cellValue);
							this.gridLotList[num, 4] = new Cell(cellValue2);
							this.gridLotList[num, 5] = new Cell(cellValue3);
							this.gridLotList[num, 6] = new Cell(cellValue4);
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

		// Token: 0x060000BA RID: 186 RVA: 0x000072BC File Offset: 0x000054BC
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
					Amkor.CADModules.SAMSUNGModule.Class.StationData stationData = new Amkor.CADModules.SAMSUNGModule.Class.StationData();
					new Amkor.CADModules.SAMSUNGModule.Class.StationIDData();
					Amkor.CADModules.SAMSUNGModule.Class.LotData lotData = new Amkor.CADModules.SAMSUNGModule.Class.LotData();
					Amkor.CADModules.SAMSUNGModule.Class.UnitData unitData = new Amkor.CADModules.SAMSUNGModule.Class.UnitData();
					SortedList sortedList = new SortedList();
					string text = string.Empty;
					string empty = string.Empty;
					string empty2 = string.Empty;
					if (this.rdoLot.Checked)
					{
						text = "LOT";
					}
					else if (this.rdoSN.Checked || this.rdoLoadSN.Checked)
					{
						text = "SN";
					}
					for (int i = 1; i < this.gridLotList.Rows.Count; i++)
					{
						if ((bool)this.gridLotList[i, 0].Value)
						{
							lotData = new Amkor.CADModules.SAMSUNGModule.Class.LotData();
							string key = this.gridLotList[i, 1].ToString();
							lotData.Lotid = this.gridLotList[i, 2].ToString();
							lotData.Dcc = this.gridLotList[i, 3].ToString();
							lotData.Device = this.gridLotList[i, 4].ToString();
							lotData.sProduct = this.gridLotList[i, 5].ToString();
							lotData.sSN = this.gridLotList[i, 6].ToString();
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
							lotData = (Amkor.CADModules.SAMSUNGModule.Class.LotData)sortedList.GetByIndex(j);
							string sQuery = string.Concat(new string[]
							{
								"EXEC [CIMitar_Factory].[dbo].[USP_SAMSUNG_GetUnitResultData] @type  = '",
								text,
								"', @lot  = '",
								lotData.Lotid,
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
								DataRow[] array = dataSet.Tables[0].Select(empty3, "starttime");
								int k = 0;
								while (k < array.Length)
								{
									string device = lotData.Device;
									string sProduct = lotData.sProduct;
									string text2 = this.UTF8ConvertToCharAll(array[k]["program"].ToString());
									string text3 = array[k]["operation"].ToString();
									string text4 = array[k]["stationid"].ToString();
									string key2 = array[k]["operation"].ToString();
									string text5 = array[k]["lot"].ToString();
									string un = array[k]["un"].ToString();
									string text6 = array[k]["sn"].ToString();
									string text7 = array[k]["result"].ToString();
									string text8 = array[k]["dcc"].ToString();
									string value = array[k]["indate"].ToString();
									string text9 = array[k]["starttime"].ToString();
									string text10 = array[k]["endtime"].ToString();
									string fail_Value = this.UTF8ConvertToCharAll(array[k]["fail_desc"].ToString());
									string failure_message = this.UTF8ConvertToCharAll(array[k]["measurevalue"].ToString());
									string testHeadId = array[k]["site"].ToString();
									string text11 = array[k]["hostname"].ToString();
									string hbin = array[k]["hbin"].ToString();
									string sbin = array[k]["sbin"].ToString();
									string text12 = array[k]["num"].ToString();
									DateTime value2 = Convert.ToDateTime(text9);
									double totalSeconds = Convert.ToDateTime(text10).Subtract(value2).TotalSeconds;
									string key3 = text5 + "_" + text8;
									if (!this._slData.ContainsKey(key2))
									{
										stationData = new Amkor.CADModules.SAMSUNGModule.Class.StationData();
										stationData.Station = text3;
										this._slData.Add(key2, stationData);
									}
									else
									{
										stationData = (Amkor.CADModules.SAMSUNGModule.Class.StationData)this._slData[key2];
									}
									if (!stationData.slLot.ContainsKey(key3))
									{
										lotData = new Amkor.CADModules.SAMSUNGModule.Class.LotData();
										lotData.Lotid = text5;
										lotData.Dcc = text8;
										lotData.Device = device;
										lotData.sProduct = sProduct;
										lotData.sProgram = text2;
										lotData.Station = text3;
										lotData.sStartTime = text9;
										lotData.sEndTime = text10;
										stationData.slLot.Add(key3, lotData);
									}
									else
									{
										lotData = (Amkor.CADModules.SAMSUNGModule.Class.LotData)stationData.slLot[key3];
										lotData.sEndTime = text10;
									}
									if (!lotData.slUnit.ContainsKey(text6))
									{
										unitData = new Amkor.CADModules.SAMSUNGModule.Class.UnitData();
										unitData.UN = un;
										unitData.SN = text6;
										unitData.result = text7;
										unitData.Indate = Convert.ToDateTime(value);
										unitData.StartTime = text9;
										unitData.Dcc = text8;
										unitData.Product = sProduct;
										lotData.slUnit.Add(unitData.SN, unitData);
									}
									else
									{
										unitData = (Amkor.CADModules.SAMSUNGModule.Class.UnitData)lotData.slUnit[text6];
									}
									Amkor.CADModules.SAMSUNGModule.Class.UnitResult unitResult = new Amkor.CADModules.SAMSUNGModule.Class.UnitResult();
									if (text7.ToUpper() == "PASS")
									{
										unitResult.iPassCnt++;
									}
									else
									{
										unitResult.iFailCnt++;
										if (!lotData.slFailData.ContainsKey(text6))
										{
											lotData.slFailData.Add(unitData.SN, unitData);
										}
									}
									unitResult.unit_Seq = new Amkor.CADModules.SAMSUNGModule.Class.UnitData();
									unitResult.unit_Seq.LotID = text5;
									unitResult.unit_Seq.Device = device;
									unitResult.unit_Seq.Product = sProduct;
									unitResult.unit_Seq.UN = un;
									unitResult.unit_Seq.SN = text6;
									unitResult.unit_Seq.result = text7;
									unitResult.unit_Seq.Indate = Convert.ToDateTime(value);
									unitResult.unit_Seq.Test_station_name = text3;
									unitResult.unit_Seq.Dcc = text8;
									unitResult.unit_Seq.StartTime = text9;
									unitResult.unit_Seq.StopTime = text10;
									unitResult.unit_Seq.Fail_Value = fail_Value;
									unitResult.unit_Seq.Failure_message = failure_message;
									unitResult.unit_Seq.Sw_version = text2;
									unitResult.unit_Seq.TestHeadId = testHeadId;
									unitResult.unit_Seq.TestTime = totalSeconds;
									unitResult.unit_Seq.Station_id = text4;
									unitResult.unit_Seq.Tester = text11;
									unitResult.unit_Seq.HBin = hbin;
									unitResult.unit_Seq.SBin = sbin;
									unitResult.unit_Seq.setFailData();
									string a;
									if ((a = text12) == null)
									{
										goto IL_859;
									}
									if (!(a == "1"))
									{
										if (!(a == "2"))
										{
											if (!(a == "3"))
											{
												goto IL_859;
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
									IL_871:
									if (text4 != string.Empty)
									{
										string[] array2 = text4.Split(new char[]
										{
											'_'
										});
										if (array2.Length > 2)
										{
											unitResult.unit_Seq.Station_id = array2[2];
										}
									}
									unitData.slSeq.Add(unitData.slSeq.Count + 1, unitResult);
									Amkor.CADModules.SAMSUNGModule.Class.TesterData testerData = new Amkor.CADModules.SAMSUNGModule.Class.TesterData();
									if (!lotData.slTester.ContainsKey(text11))
									{
										testerData = new Amkor.CADModules.SAMSUNGModule.Class.TesterData();
										testerData.TesterName = text11;
										lotData.slTester.Add(text11, testerData);
									}
									else
									{
										testerData = (Amkor.CADModules.SAMSUNGModule.Class.TesterData)lotData.slTester[text11];
									}
									if (!testerData.slUnit.ContainsKey(text6))
									{
										unitData = new Amkor.CADModules.SAMSUNGModule.Class.UnitData();
										unitData.UN = un;
										unitData.SN = text6;
										unitData.result = text7;
										unitData.Indate = Convert.ToDateTime(value);
										unitData.StartTime = text9;
										unitData.Dcc = text8;
										unitData.Product = sProduct;
										testerData.slUnit.Add(unitData.SN, unitData);
									}
									else
									{
										unitData = (Amkor.CADModules.SAMSUNGModule.Class.UnitData)testerData.slUnit[text6];
									}
									unitResult = new Amkor.CADModules.SAMSUNGModule.Class.UnitResult();
									if (text7.ToUpper() == "PASS")
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
									IL_859:
									unitResult.unit_Seq.Num = text12 + "th";
									goto IL_871;
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
									if (!(a2 == "Lot Yield(Per Tester)"))
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
										Grid grid2 = this.addControl("LotYield_PerTester", "Lot Yield(Per Tester)", this.tab_ReportView);
										this.InitYieldReportGrid_PerOperation(grid2);
										grid2.Columns[5].Visible = true;
										this.setBinding_LotYield_PerTester(grid2);
									}
								}
								else
								{
									Grid grid3 = this.addControl("LotYield", "Lot Yield", this.tab_ReportView);
									this.InitYieldReportGrid_PerOperation(grid3);
									grid3.Columns[5].Visible = false;
									this.setBinding_LotYield_PerStation(grid3);
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

		// Token: 0x060000BB RID: 187 RVA: 0x00007E90 File Offset: 0x00006090
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

		// Token: 0x060000BC RID: 188 RVA: 0x00007FB0 File Offset: 0x000061B0
		private void setBinding_LotYield_PerStation(Grid gridYieldReport)
		{
			SortedList slData = this._slData;
			Amkor.CADModules.SAMSUNGModule.Class.StationData stationData = new Amkor.CADModules.SAMSUNGModule.Class.StationData();
			new Amkor.CADModules.SAMSUNGModule.Class.StationIDData();
			Amkor.CADModules.SAMSUNGModule.Class.LotData lotData = new Amkor.CADModules.SAMSUNGModule.Class.LotData();
			Amkor.CADModules.SAMSUNGModule.Class.UnitData unitData = new Amkor.CADModules.SAMSUNGModule.Class.UnitData();
			SortedList sortedList = new SortedList();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < slData.Count; i++)
			{
				stationData = (Amkor.CADModules.SAMSUNGModule.Class.StationData)slData.GetByIndex(i);
				for (int j = 0; j < stationData.slLot.Count; j++)
				{
					lotData = (Amkor.CADModules.SAMSUNGModule.Class.LotData)stationData.slLot.GetByIndex(j);
					for (int k = 0; k < lotData.slUnit.Count; k++)
					{
						unitData = (Amkor.CADModules.SAMSUNGModule.Class.UnitData)lotData.slUnit.GetByIndex(k);
						if (unitData.slSeq.Count > 0)
						{
							Amkor.CADModules.SAMSUNGModule.Class.UnitResult unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(0);
							lotData.PASS_1A += unitResult.iPassCnt;
							lotData.FAIL_1A += unitResult.iFailCnt;
							if (unitData.slSeq.Count > 1)
							{
								unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(1);
								lotData.PASS_2A += unitResult.iPassCnt;
								lotData.FAIL_2A += unitResult.iFailCnt;
							}
							if (unitData.slSeq.Count > 2)
							{
								unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(2);
								lotData.PASS_1B += unitResult.iPassCnt;
								lotData.FAIL_1B += unitResult.iFailCnt;
							}
							if (unitData.slSeq.Count > 3)
							{
								unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(3);
								lotData.PASS_2B += unitResult.iPassCnt;
								lotData.FAIL_2B += unitResult.iFailCnt;
							}
							unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(unitData.slSeq.Count - 1);
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
					gridYieldReport[num, 4] = new Cell(lotData.Device);
					gridYieldReport[num, 0] = new Cell(lotData.Lotid);
					gridYieldReport[num, 1] = new Cell(lotData.Dcc);
					gridYieldReport[num, 6] = new Cell(lotData.sProgram);
					gridYieldReport[num, 7] = new Cell(lotData.sStartTime);
					gridYieldReport[num, 8] = new Cell(lotData.sEndTime);
					gridYieldReport[num, 9] = new Cell(lotData.slUnit.Count);
					gridYieldReport[num, 10] = new Cell(lotData.PASS_FINAL);
					gridYieldReport[num, 11] = new Cell(lotData.FAIL_FINAL);
					gridYieldReport[num, 12] = new Cell(num3.ToString() + "%");
					gridYieldReport[num, 13] = new Cell(lotData.PASS_1A);
					gridYieldReport[num, 14] = new Cell(lotData.FAIL_1A);
					gridYieldReport[num, 15] = new Cell(num2.ToString() + "%");
					gridYieldReport[num, 16] = new Cell(num4.ToString() + "%");
					if (sortedList.Count == 0)
					{
						arrayList = new ArrayList();
						arrayList.Add(gridYieldReport[0, 2].ToString());
						arrayList.Add(gridYieldReport[0, 3].ToString());
						arrayList.Add(gridYieldReport[0, 4].ToString());
						arrayList.Add(gridYieldReport[0, 0].ToString());
						arrayList.Add(gridYieldReport[0, 1].ToString());
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
					sortedList.Add(num, arrayList);
				}
			}
			if (sortedList.Count > 0)
			{
				this._slBindingData.Add("LotYield", sortedList);
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00008718 File Offset: 0x00006918
		private void setBinding_LotYield_PerTester(Grid gridYieldReport)
		{
			SortedList slData = this._slData;
			Amkor.CADModules.SAMSUNGModule.Class.StationData stationData = new Amkor.CADModules.SAMSUNGModule.Class.StationData();
			new Amkor.CADModules.SAMSUNGModule.Class.StationIDData();
			Amkor.CADModules.SAMSUNGModule.Class.LotData lotData = new Amkor.CADModules.SAMSUNGModule.Class.LotData();
			Amkor.CADModules.SAMSUNGModule.Class.TesterData testerData = new Amkor.CADModules.SAMSUNGModule.Class.TesterData();
			Amkor.CADModules.SAMSUNGModule.Class.UnitData unitData = new Amkor.CADModules.SAMSUNGModule.Class.UnitData();
			SortedList sortedList = new SortedList();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < slData.Count; i++)
			{
				stationData = (Amkor.CADModules.SAMSUNGModule.Class.StationData)slData.GetByIndex(i);
				for (int j = 0; j < stationData.slLot.Count; j++)
				{
					lotData = (Amkor.CADModules.SAMSUNGModule.Class.LotData)stationData.slLot.GetByIndex(j);
					for (int k = 0; k < lotData.slTester.Count; k++)
					{
						testerData = (Amkor.CADModules.SAMSUNGModule.Class.TesterData)lotData.slTester.GetByIndex(k);
						for (int l = 0; l < testerData.slUnit.Count; l++)
						{
							unitData = (Amkor.CADModules.SAMSUNGModule.Class.UnitData)testerData.slUnit.GetByIndex(l);
							if (unitData.slSeq.Count > 0)
							{
								Amkor.CADModules.SAMSUNGModule.Class.UnitResult unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(0);
								testerData.PASS_1A += unitResult.iPassCnt;
								testerData.FAIL_1A += unitResult.iFailCnt;
								if (unitData.slSeq.Count > 1)
								{
									unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(1);
									testerData.PASS_2A += unitResult.iPassCnt;
									testerData.FAIL_2A += unitResult.iFailCnt;
								}
								if (unitData.slSeq.Count > 2)
								{
									unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(2);
									testerData.PASS_1B += unitResult.iPassCnt;
									testerData.FAIL_1B += unitResult.iFailCnt;
								}
								if (unitData.slSeq.Count > 3)
								{
									unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(3);
									testerData.PASS_2B += unitResult.iPassCnt;
									testerData.FAIL_2B += unitResult.iFailCnt;
								}
								unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(unitData.slSeq.Count - 1);
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
						gridYieldReport[num, 4] = new Cell(lotData.Device);
						gridYieldReport[num, 0] = new Cell(lotData.Lotid);
						gridYieldReport[num, 1] = new Cell(lotData.Dcc);
						gridYieldReport[num, 5] = new Cell(testerData.TesterName);
						gridYieldReport[num, 6] = new Cell(lotData.sProgram);
						gridYieldReport[num, 7] = new Cell(lotData.sStartTime);
						gridYieldReport[num, 8] = new Cell(lotData.sEndTime);
						gridYieldReport[num, 9] = new Cell(testerData.slUnit.Count);
						gridYieldReport[num, 10] = new Cell(testerData.PASS_FINAL);
						gridYieldReport[num, 11] = new Cell(testerData.FAIL_FINAL);
						gridYieldReport[num, 12] = new Cell(num3.ToString() + "%");
						gridYieldReport[num, 13] = new Cell(testerData.PASS_1A);
						gridYieldReport[num, 14] = new Cell(testerData.FAIL_1A);
						gridYieldReport[num, 15] = new Cell(num2.ToString() + "%");
						gridYieldReport[num, 16] = new Cell(num4.ToString() + "%");
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
							sortedList.Add(0, arrayList);
						}
						arrayList = new ArrayList();
						arrayList.Add(lotData.Lotid);
						arrayList.Add(lotData.Dcc);
						arrayList.Add(stationData.Station);
						arrayList.Add(lotData.sProduct);
						arrayList.Add(lotData.Device);
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

		// Token: 0x060000BE RID: 190 RVA: 0x00008EF4 File Offset: 0x000070F4
		private void setBinding_UnitTestResult(Grid gridYieldReport)
		{
			SortedList slData = this._slData;
			Amkor.CADModules.SAMSUNGModule.Class.StationData stationData = new Amkor.CADModules.SAMSUNGModule.Class.StationData();
			new Amkor.CADModules.SAMSUNGModule.Class.StationIDData();
			Amkor.CADModules.SAMSUNGModule.Class.LotData lotData = new Amkor.CADModules.SAMSUNGModule.Class.LotData();
			Amkor.CADModules.SAMSUNGModule.Class.UnitData unitData = new Amkor.CADModules.SAMSUNGModule.Class.UnitData();
			Console.WriteLine("Start : " + DateTime.Now);
			gridYieldReport.RowsCount = 1;
			SortedList sortedList = new SortedList();
			new ArrayList();
			for (int i = 0; i < slData.Count; i++)
			{
				stationData = (Amkor.CADModules.SAMSUNGModule.Class.StationData)slData.GetByIndex(i);
				for (int j = 0; j < stationData.slLot.Count; j++)
				{
					lotData = (Amkor.CADModules.SAMSUNGModule.Class.LotData)stationData.slLot.GetByIndex(j);
					for (int k = 0; k < lotData.slUnit.Count; k++)
					{
						unitData = (Amkor.CADModules.SAMSUNGModule.Class.UnitData)lotData.slUnit.GetByIndex(k);
						if (this.cmbTestType.Text == "1st")
						{
							Amkor.CADModules.SAMSUNGModule.Class.UnitResult unitResult = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(0);
						}
						else if (this.cmbTestType.Text == "Final")
						{
							Amkor.CADModules.SAMSUNGModule.Class.UnitResult unitResult2 = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(unitData.slSeq.Count - 1);
						}
						else
						{
							for (int l = 0; l < unitData.slSeq.Count; l++)
							{
								Amkor.CADModules.SAMSUNGModule.Class.UnitResult unitResult3 = (Amkor.CADModules.SAMSUNGModule.Class.UnitResult)unitData.slSeq.GetByIndex(l);
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

		// Token: 0x060000BF RID: 191 RVA: 0x000090B4 File Offset: 0x000072B4
		private void setBinding_row(Grid gridYieldReport, Amkor.CADModules.SAMSUNGModule.Class.UnitData unit, SortedList slDataList)
		{
			ArrayList arrayList = new ArrayList();
			gridYieldReport.Rows.Insert(gridYieldReport.RowsCount);
			int num = gridYieldReport.RowsCount - 1;
			int num2 = 0;
			gridYieldReport[num, num2++] = new Cell(num);
			gridYieldReport[num, num2++] = new Cell(unit.UN);
			gridYieldReport[num, num2++] = new Cell(unit.SN);
			gridYieldReport[num, num2++] = new Cell(unit.Product);
			gridYieldReport[num, num2++] = new Cell(unit.Device);
			gridYieldReport[num, num2++] = new Cell(unit.LotID);
			gridYieldReport[num, num2++] = new Cell(unit.Dcc);
			gridYieldReport[num, num2++] = new Cell(unit.Test_station_name);
			gridYieldReport[num, num2++] = new Cell(unit.Sw_version);
			gridYieldReport[num, num2++] = new Cell(unit.Tester);
			gridYieldReport[num, num2++] = new Cell(unit.Station_id);
			gridYieldReport[num, num2++] = new Cell(unit.TestHeadId);
			gridYieldReport[num, num2++] = new Cell(unit.result);
			gridYieldReport[num, num2++] = new Cell(unit.HBin);
			gridYieldReport[num, num2++] = new Cell(unit.SBin);
			gridYieldReport[num, num2++] = new Cell(unit.StartTime);
			gridYieldReport[num, num2++] = new Cell(unit.StopTime);
			gridYieldReport[num, num2++] = new Cell(unit.TestTime);
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
			arrayList.Add(unit.UN);
			arrayList.Add(unit.SN);
			arrayList.Add(unit.Product);
			arrayList.Add(unit.Device);
			arrayList.Add(unit.LotID);
			arrayList.Add(unit.Dcc);
			arrayList.Add(unit.Test_station_name);
			arrayList.Add(unit.Sw_version);
			arrayList.Add(unit.Tester);
			arrayList.Add(unit.Station_id);
			arrayList.Add(unit.TestHeadId);
			arrayList.Add(unit.result);
			arrayList.Add(unit.HBin);
			arrayList.Add(unit.SBin);
			arrayList.Add(unit.StartTime);
			arrayList.Add(unit.StopTime);
			arrayList.Add(unit.TestTime);
			arrayList.Add(unit.Fail_Value);
			arrayList.Add(unit.Failure_message);
			slDataList.Add(num, arrayList);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00009410 File Offset: 0x00007610
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

		// Token: 0x040000D1 RID: 209
		private ContextMenu menuTypeGrid = new ContextMenu();

		// Token: 0x040000D2 RID: 210
		private ContextMenu menuGrid = new ContextMenu();

		// Token: 0x040000D3 RID: 211
		private Amkor.CADModules.SAMSUNGModule.Class.GridInfo gridInfo = new Amkor.CADModules.SAMSUNGModule.Class.GridInfo();

		// Token: 0x040000D4 RID: 212
		private ToolTip toolTip = new ToolTip();

		// Token: 0x040000D5 RID: 213
		private SortedList _slData = new SortedList();

		// Token: 0x040000D6 RID: 214
		private SortedList _slBindingData = new SortedList();

		// Token: 0x040000D7 RID: 215
		private ArrayList arrCellColor = new ArrayList();

		// Token: 0x040000D8 RID: 216
		private SortedList slUploadData = new SortedList();

		// Token: 0x040000D9 RID: 217
		private Thread _thread;

		// Token: 0x040000DA RID: 218
		private BarPrograss _barPrograss;

		// Token: 0x040000DB RID: 219
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
