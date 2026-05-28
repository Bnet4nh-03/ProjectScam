using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Amkor.CADModules.SBLAnalysisModule.Class;
using Amkor.CADModules.SBLAnalysisModule.Control;
using Amkor.CADModules.SBLAnalysisModule.Properties;
using Amkor.CADModules.SBLAnalysisModule.View;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.SBLAnalysisModule
{
	// Token: 0x02000013 RID: 19
	public partial class SBLAnalysis : BaseWinView
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00004C08 File Offset: 0x00002E08
		public SBLAnalysis()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://testweb.amkor.co.kr/";
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this.InitializeComponent();
			this._cimitarUser._id = "wogud0609";
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004CC0 File Offset: 0x00002EC0
		public SBLAnalysis(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004D4A File Offset: 0x00002F4A
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004D5C File Offset: 0x00002F5C
		private void SBLAnalysis_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.getPlatFormType();
			this.initEvent();
			this.initSBLHistoryGrid();
			this.initSBLSetupGrid();
			this.initItemGridContextMenu();
			this.dtp_Start_Trend.Value = this.dtp_Start_Trend.Value.Date;
			this.dtp_End_Trend.Value = this.dtp_End_Trend.Value.Date.AddHours(23.99);
			this.label_copyright.Text = "Copyright © 2017-" + DateTime.Today.Year.ToString() + " Amkor Technology Korea, Inc. All Rights Reserved.";
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004E20 File Offset: 0x00003020
		private void saveExcel(SourceGrid.Grid grid)
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
					if (this.saveFileDialog.FilterIndex == 1)
					{
						ExcelControl.Save(this.saveFileDialog.FileName, grid, true);
					}
					else if (this.saveFileDialog.FilterIndex == 2)
					{
						ExcelControl.SaveCSV(this.saveFileDialog.FileName, grid, this._cimitarUser._exeExcel);
					}
				}
			}
			else
			{
				MessageBox.Show("data is not exist ", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004F14 File Offset: 0x00003114
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

		// Token: 0x06000062 RID: 98 RVA: 0x00004F74 File Offset: 0x00003174
		private DataSet getTypeDefinitionList(string sTypeName, ComboBox comboBox)
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

		// Token: 0x06000063 RID: 99 RVA: 0x00005038 File Offset: 0x00003238
		private void getPlatFormType()
		{
			this.cmbPlatformType.Items.Clear();
			this.cbPlatform.Items.Clear();
			DataSet dataSet = new DataSet();
			try
			{
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetHSFPlatForm_Tester] @type = 'PlatFormType'";
				dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.cmbPlatformType.Items.Add(dataSet.Tables[0].Rows[i]["platformtypename"].ToString());
						this.cbPlatform.Items.Add(dataSet.Tables[0].Rows[i]["platformtypename"].ToString());
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005180 File Offset: 0x00003380
		private void getTester(string sPlatFormType, ComboBox combo)
		{
			this.cmbTester.Items.Clear();
			DataSet dataSet = new DataSet();
			try
			{
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetHSFPlatForm_Tester] @type = 'Tester', @platformtype = '" + sPlatFormType + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						combo.Items.Add(dataSet.Tables[0].Rows[i]["testername"].ToString());
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00005280 File Offset: 0x00003480
		private void initEvent()
		{
			this.cmdHistorySearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdHistorySearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdHistorySearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdHistorySearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdHistoryExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdHistoryExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdHistoryExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdHistoryExcel.MouseUp += this.cmdExcel_MouseUp;
			this.cmdBinTrendSearch.MouseDown += this.cmdSearch_MouseDown;
			this.cmdBinTrendSearch.MouseLeave += this.cmdSearch_MouseLeave;
			this.cmdBinTrendSearch.MouseMove += this.cmdSearch_MouseMove;
			this.cmdBinTrendSearch.MouseUp += this.cmdSearch_MouseUp;
			this.cmdBinTrendExcel.MouseDown += this.cmdExcel_MouseDown;
			this.cmdBinTrendExcel.MouseLeave += this.cmdExcel_MouseLeave;
			this.cmdBinTrendExcel.MouseMove += this.cmdExcel_MouseMove;
			this.cmdBinTrendExcel.MouseUp += this.cmdExcel_MouseUp;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000540E File Offset: 0x0000360E
		private void initItemGridContextMenu()
		{
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00005411 File Offset: 0x00003611
		private void cmbPlatformType_DropDown(object sender, EventArgs e)
		{
			this.getPlatFormType();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000541B File Offset: 0x0000361B
		private void cmbTester_DropDown(object sender, EventArgs e)
		{
			this.getTester(this.cmbPlatformType.Text, this.cmbTester);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005436 File Offset: 0x00003636
		private void cmbType_DropDown(object sender, EventArgs e)
		{
			this.getTypeDefinitionList("HSFType", this.cmbType);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000544C File Offset: 0x0000364C
		private void initSBLHistoryGrid()
		{
			this.gridSBLHistory.ColumnsCount = 11;
			this.gridSBLHistory.RowsCount = 1;
			this.gridSBLHistory.FixedRows = 1;
			this.gridSBLHistory.FixedColumns = 1;
			this.gridSBLHistory[0, 0] = new GridInfo.ColHeader("No");
			this.gridSBLHistory[0, 1] = new GridInfo.ColHeader("HSF Time");
			this.gridSBLHistory[0, 2] = new GridInfo.ColHeader("HSF Type");
			this.gridSBLHistory[0, 3] = new GridInfo.ColHeader("Tester");
			this.gridSBLHistory[0, 4] = new GridInfo.ColHeader("Lot");
			this.gridSBLHistory[0, 5] = new GridInfo.ColHeader("Operation");
			this.gridSBLHistory[0, 6] = new GridInfo.ColHeader("SBLRuleID");
			this.gridSBLHistory[0, 7] = new GridInfo.ColHeader("SBLType");
			this.gridSBLHistory[0, 8] = new GridInfo.ColHeader("ResultBin");
			this.gridSBLHistory[0, 9] = new GridInfo.ColHeader("Action");
			this.gridSBLHistory[0, 10] = new GridInfo.ColHeader("Action Time");
			this.gridSBLHistory.Columns[0].Width = 40;
			this.gridSBLHistory.Columns[1].Width = 140;
			this.gridSBLHistory.Columns[2].Width = 60;
			this.gridSBLHistory.Columns[3].Width = 80;
			this.gridSBLHistory.Columns[4].Width = 180;
			this.gridSBLHistory.Columns[5].Width = 60;
			this.gridSBLHistory.Columns[6].Width = 60;
			this.gridSBLHistory.Columns[7].Width = 60;
			this.gridSBLHistory.Columns[8].Width = 120;
			this.gridSBLHistory.Columns[9].Width = 200;
			this.gridSBLHistory.Columns[10].Width = 140;
			this.gridInfo.SetColumnCellColor(this.gridSBLHistory, 0, this.gridInfo.CellColor.cell_gray_center);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000056E0 File Offset: 0x000038E0
		private string xmlParsingNode(string sValue, string sSearchText)
		{
			string result = string.Empty;
			if (sValue != string.Empty)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(sValue);
				XmlNode xmlNode = xmlDocument;
				result = xmlNode.SelectSingleNode(sSearchText).InnerXml;
			}
			return result;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00005730 File Offset: 0x00003930
		private string setResultBinList(string sValue, int iRow)
		{
			string text = string.Empty;
			SortedList sortedList = new SortedList();
			try
			{
				if (sValue != string.Empty)
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(sValue);
					XmlNode xmlNode = xmlDocument;
					XmlNodeList xmlNodeList = xmlNode.SelectNodes("CIMITARSBL/SBLRESULTS");
					int num = 1;
					foreach (object obj in xmlNodeList)
					{
						XmlNode xmlNode2 = (XmlNode)obj;
						foreach (object obj2 in xmlNode2.ChildNodes)
						{
							XmlNode xmlNode3 = (XmlNode)obj2;
							Bin bin = new Bin();
							bin.BinNo = xmlNode3.Attributes["binno"].Value;
							bin.LimitType = this.getSBLType(xmlNode3.SelectSingleNode("RESULT/SBLS/SBL/@ftype").InnerXml);
							bin.Limit = xmlNode3.SelectSingleNode("RESULT/SBLS/SBL/RSTS/RST/@limit").InnerXml;
							bin.Result = xmlNode3.SelectSingleNode("RESULT/SBLS/SBL/RSTS/RST/@result").InnerXml;
							sortedList.Add(num, bin);
							num++;
							if (text != string.Empty)
							{
								text += ",";
							}
							text += bin.BinNo;
						}
					}
					this.slResultList.Add(iRow, sortedList);
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return text;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00005960 File Offset: 0x00003B60
		private string getSBLType(string sType)
		{
			string result = string.Empty;
			if (sType != string.Empty)
			{
				if (sType != null)
				{
					if (!(sType == "C"))
					{
						if (!(sType == "P"))
						{
							if (!(sType == "S"))
							{
								if (sType == "BS")
								{
									result = "Bin SVR";
								}
							}
							else
							{
								result = "SVR";
							}
						}
						else
						{
							result = "Yield";
						}
					}
					else
					{
						result = "Count";
					}
				}
			}
			return result;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000059E8 File Offset: 0x00003BE8
		private void getSBLHistory()
		{
			try
			{
				this.slResultList.Clear();
				this.gridSBLHistory.RowsCount = 1;
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetHSFHistory]  @startdate = '",
					this.dtp_Start_History.Text.Trim(),
					"', @enddate = '",
					this.dtp_End_Histroy.Text.Trim(),
					"', @platformtype = '",
					this.cmbPlatformType.Text.Trim(),
					"', @tester = '",
					this.cmbTester.Text.Trim(),
					"', @hsftype = '",
					this.cmbType.Text.Trim(),
					"', @lotid = '",
					this.txtLotid.Text.Trim(),
					"'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				int num = 1;
				if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string sValue = dataSet.Tables[0].Rows[i]["result"].ToString();
						this.gridSBLHistory.Rows.Insert(num);
						this.gridSBLHistory[num, 0] = new Cell(num);
						this.gridSBLHistory[num, 1] = new Cell(dataSet.Tables[0].Rows[i]["intime"]);
						this.gridSBLHistory[num, 2] = new Cell(dataSet.Tables[0].Rows[i]["hsftype"]);
						this.gridSBLHistory[num, 3] = new Cell(dataSet.Tables[0].Rows[i]["testername"]);
						this.gridSBLHistory[num, 4] = new Cell(dataSet.Tables[0].Rows[i]["lotno"]);
						this.gridSBLHistory[num, 5] = new Cell(dataSet.Tables[0].Rows[i]["operationname"]);
						string cellValue = this.xmlParsingNode(sValue, "CIMITARSBL/@ruleid");
						string sbltype = this.getSBLType(this.xmlParsingNode(sValue, "CIMITARSBL/SBLRESULTS/SBLRESULT/RESULT/SBLS/SBL/@ftype"));
						string cellValue2 = this.setResultBinList(sValue, num);
						this.gridSBLHistory[num, 6] = new Cell(cellValue);
						this.gridSBLHistory[num, 7] = new Cell(sbltype);
						this.gridSBLHistory[num, 8] = new Cell(cellValue2);
						this.gridSBLHistory[num, 9] = new Cell(dataSet.Tables[0].Rows[i]["action"]);
						this.gridSBLHistory[num, 10] = new Cell(dataSet.Tables[0].Rows[i]["actiontime"]);
						num++;
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

		// Token: 0x0600006F RID: 111 RVA: 0x00005EC8 File Offset: 0x000040C8
		private void cmdHistorySearch_Click(object sender, EventArgs e)
		{
			this.getSBLHistory();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005ED2 File Offset: 0x000040D2
		private void cmdHistoryExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridSBLHistory);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005EE4 File Offset: 0x000040E4
		private void txtLotid_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.getSBLHistory();
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00005F0C File Offset: 0x0000410C
		private void gridSBLHistory_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int row = this.gridSBLHistory.Selection.ActivePosition.Row;
			if (this.gridSBLHistory.RowsCount > 1 && row > 0)
			{
				ResultView resultView = new ResultView();
				string s = this.gridSBLHistory[row, 0].ToString();
				resultView.slResult = (SortedList)this.slResultList[int.Parse(s)];
				resultView.ShowDialog();
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00005F95 File Offset: 0x00004195
		private void cmbPlatformType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cmbTester.Text = string.Empty;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00005FAC File Offset: 0x000041AC
		private void cmdSearch_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005FDC File Offset: 0x000041DC
		private void cmdSearch_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000600C File Offset: 0x0000420C
		private void cmdSearch_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00006039 File Offset: 0x00004239
		private void cmdSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00006048 File Offset: 0x00004248
		private void cmdExcel_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00006078 File Offset: 0x00004278
		private void cmdExcel_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000060A8 File Offset: 0x000042A8
		private void cmdExcel_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			pictureBox.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000060D5 File Offset: 0x000042D5
		private void cmdExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000060E4 File Offset: 0x000042E4
		private void cmbTrendTester_DropDown(object sender, EventArgs e)
		{
			this.getTester("HP93K", this.cmbTrendTester);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000060FC File Offset: 0x000042FC
		private void InitBinTrendGrid()
		{
			this.gridBinTrend.ColumnsCount = 4;
			this.gridBinTrend.RowsCount = 1;
			this.gridBinTrend.FixedRows = 1;
			this.gridBinTrend.FixedColumns = 1;
			this.gridBinTrend[0, 0] = new GridInfo.ColHeader("No");
			this.gridBinTrend[0, 1] = new GridInfo.ColHeader("Date");
			this.gridBinTrend[0, 2] = new GridInfo.ColHeader("VOLH");
			this.gridBinTrend[0, 3] = new GridInfo.ColHeader("CONT");
			this.gridInfo.SetColumnCellColor(this.gridBinTrend, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridBinTrend);
			this.gridBinTrend.Columns[0].Width = 40;
			this.gridBinTrend.Columns[1].Width = 120;
			this.gridBinTrend.Columns[2].Width = 60;
			this.gridBinTrend.Columns[3].Width = 60;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00006238 File Offset: 0x00004438
		private bool setBinTrendBinding()
		{
			try
			{
				if (this.cmbTrendTester.Text == string.Empty)
				{
					MessageBox.Show("Please select the tester.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
				this.slResultList.Clear();
				this.gridSBLHistory.RowsCount = 1;
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetBinHistory]  @startdate = '",
					this.dtp_Start_Trend.Text.Trim(),
					"', @enddate = '",
					this.dtp_End_Trend.Text.Trim(),
					"', @tester = '",
					this.cmbTrendTester.Text.Trim(),
					"'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				SortedList sortedList = new SortedList();
				if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string value = dataSet.Tables[0].Rows[i]["intime"].ToString();
						string text = dataSet.Tables[0].Rows[i]["binno"].ToString();
						string key = dataSet.Tables[0].Rows[i]["binname"].ToString();
						string text2 = Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm");
						if (!this.slResultList.ContainsKey(text2))
						{
							this.slResultList.Add(text2, new SortedList());
						}
						sortedList = (SortedList)this.slResultList[text2];
						if (sortedList.Count == 0)
						{
							GroupBin groupBin = new GroupBin();
							groupBin.sName = "CONT";
							sortedList.Add(groupBin.sName, groupBin);
							groupBin = new GroupBin();
							groupBin.sName = "VOLH";
							sortedList.Add(groupBin.sName, groupBin);
						}
						GroupBin groupBin2 = (GroupBin)sortedList[key];
						groupBin2.sCount++;
						this._barPrograss.setValue(i + 1);
					}
				}
				int num = 1;
				for (int i = 0; i < this.slResultList.Count; i++)
				{
					SortedList sortedList2 = (SortedList)this.slResultList.GetByIndex(i);
					string text2 = this.slResultList.GetKey(i).ToString();
					this.gridBinTrend.Rows.Insert(num);
					this.gridBinTrend[num, 0] = new Cell(num);
					this.gridBinTrend[num, 1] = new Cell(text2);
					for (int j = 0; j < sortedList2.Count; j++)
					{
						GroupBin groupBin3 = (GroupBin)sortedList2.GetByIndex(j);
						if (groupBin3.sName == "VOLH")
						{
							this.gridBinTrend[num, 2] = new Cell(groupBin3.sCount);
						}
						else if (groupBin3.sName == "CONT")
						{
							this.gridBinTrend[num, 3] = new Cell(groupBin3.sCount);
						}
					}
					num++;
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
				return false;
			}
			return true;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00006758 File Offset: 0x00004958
		private void setDateYieldChart()
		{
			int num = 0;
			double num2 = 1.5;
			string text = string.Empty;
			string toolTip = string.Empty;
			for (int i = 0; i < this.slResultList.Count; i++)
			{
				text = Convert.ToDateTime(this.slResultList.GetKey(i).ToString()).ToString("MM-dd HH:mm").ToString();
				SortedList sortedList = (SortedList)this.slResultList.GetByIndex(i);
				for (int j = 0; j < sortedList.Count; j++)
				{
					GroupBin groupBin = (GroupBin)sortedList.GetByIndex(j);
					int count = this.chart_FailBin.Series[groupBin.sName].Points.Count;
					this.chart_FailBin.Series[groupBin.sName].Points.Add(new double[]
					{
						(double)groupBin.sCount
					});
					toolTip = groupBin.sName + "\r\n" + groupBin.sCount;
					this.chart_FailBin.Series[groupBin.sName].Points[count].ToolTip = toolTip;
					this.chart_FailBin.Series[groupBin.sName].Font = new Font("Segoe UI", 8f, FontStyle.Bold);
					this.chart_FailBin.Series[groupBin.sName].Points[count].LabelForeColor = Color.FromArgb(0, 0, 0);
					this.chart_FailBin.Series[groupBin.sName].BorderWidth = 2;
					if (groupBin.sCount > num)
					{
						num = groupBin.sCount;
					}
				}
				CustomLabel customLabel = new CustomLabel();
				customLabel.Text = text;
				customLabel.FromPosition = 0.5;
				if (i == 0)
				{
					customLabel.ToPosition = num2;
				}
				else
				{
					num2 += 2.0;
					customLabel.ToPosition = num2;
				}
				customLabel.RowIndex = 0;
				this.chart_FailBin.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 7f, FontStyle.Regular);
				this.chart_FailBin.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_FailBin.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
			}
			this.chart_FailBin.ChartAreas[0].Position.Auto = false;
			this.chart_FailBin.ChartAreas[0].Position.X = 0f;
			this.chart_FailBin.ChartAreas[0].Position.Y = 10f;
			this.chart_FailBin.ChartAreas[0].Position.Height = 75f;
			this.chart_FailBin.ChartAreas[0].Position.Width = 99f;
			this.chart_FailBin.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_FailBin.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_FailBin.ChartAreas[0].AxisX.Maximum = (double)(this.slResultList.Count + 1);
			this.chart_FailBin.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_FailBin.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_FailBin.ChartAreas[0].AxisX.Interval = 1.0;
			this.chart_FailBin.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_FailBin.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_FailBin.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 5;
			this.chart_FailBin.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_FailBin.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_FailBin.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_FailBin.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_FailBin.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
			this.chart_FailBin.ChartAreas[0].AxisY.Maximum = (double)num;
			this.chart_FailBin.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
			this.chart_FailBin.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
			this.chart_FailBin.ChartAreas[0].AxisX.ScrollBar.BackColor = Color.White;
			this.chart_FailBin.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.LightGray;
			this.chart_FailBin.ChartAreas[0].AxisX.ScrollBar.Size = 15.0;
			this.chart_FailBin.ChartAreas[0].CursorX.AutoScroll = true;
			this.chart_FailBin.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
			if (this.slResultList.Count < 100)
			{
				this.chart_FailBin.ChartAreas[0].AxisX.ScaleView.Size = (double)this.slResultList.Count;
			}
			else
			{
				this.chart_FailBin.ChartAreas[0].AxisX.ScaleView.Size = 100.0;
			}
			this.chart_FailBin.Update();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00006E38 File Offset: 0x00005038
		private void initChartView()
		{
			if (this.chart_FailBin.Series.Count > 0)
			{
				this.chart_FailBin.Series.Clear();
			}
			this.chart_FailBin.ChartAreas[0].AxisX.CustomLabels.Clear();
			this.chart_FailBin.ChartAreas[0].AxisX.ScaleView.Scroll(0.0);
			this.chart_FailBin.Update();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00006ECC File Offset: 0x000050CC
		private void setFailBinSeries()
		{
			Series series = new Series();
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Int32;
			series.Legend = "Legend1";
			series.LegendText = "VOLH";
			series.Name = "VOLH";
			series.ChartType = SeriesChartType.Line;
			this.chart_FailBin.Series.Add(series);
			series = new Series();
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Int32;
			series.Legend = "Legend1";
			series.LegendText = "CONT";
			series.Name = "CONT";
			series.ChartType = SeriesChartType.Line;
			this.chart_FailBin.Series.Add(series);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00006FE0 File Offset: 0x000051E0
		private void cmbBinTrendSearch_Click(object sender, EventArgs e)
		{
			this.InitBinTrendGrid();
			this.initChartView();
			this.setFailBinSeries();
			if (this.setBinTrendBinding())
			{
				this.setDateYieldChart();
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00007019 File Offset: 0x00005219
		private void cmbBinTrendExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridBinTrend);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000702C File Offset: 0x0000522C
		private void chart_FailBin_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left)
				{
					int pointIndex = this.chart_FailBin.HitTest(e.X, e.Y).PointIndex;
					if (pointIndex >= 0)
					{
						this.gridBinTrend.Selection.FocusRow(pointIndex + 1);
						this.gridBinTrend.Selection.SelectRow(pointIndex + 1, true);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000070C8 File Offset: 0x000052C8
		private void initSBLSetupGrid()
		{
			this.gridSetupList.Rows.Clear();
			this.gridSetupList.ColumnsCount = 4;
			this.gridSetupList.RowsCount = 1;
			this.gridSetupList.FixedRows = 1;
			this.gridSetupList.FixedColumns = 1;
			this.gridSetupList[0, 0] = new GridInfo.ColHeader("No");
			this.gridSetupList[0, 1] = new GridInfo.ColHeader("Tester");
			this.gridSetupList[0, 2] = new GridInfo.ColHeader("HSF Setup");
			this.gridSetupList[0, 3] = new GridInfo.ColHeader("HSF Flag");
			this.gridInfo.SetColumnCellColor(this.gridSetupList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridSetupList.AutoSizeCells();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000071AC File Offset: 0x000053AC
		private void getSBLSetupList()
		{
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Loading Data....");
			this._barPrograss.setValue(0);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			try
			{
				this.initSBLSetupGrid();
				this._Setuplist.Clear();
				this._Setuplist2.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetHSFMonitor]  @_testername=N''";
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count != 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						SBLSetupInfo sblsetupInfo = new SBLSetupInfo();
						string text = dataSet.Tables[0].Rows[i]["platformname"].ToString();
						sblsetupInfo.testername = dataSet.Tables[0].Rows[i]["testername"].ToString();
						sblsetupInfo.onFlag = dataSet.Tables[0].Rows[i]["on_hsf"].ToString();
						sblsetupInfo.factory = dataSet.Tables[0].Rows[i]["factory"].ToString();
						sblsetupInfo.hsfSetup = dataSet.Tables[0].Rows[i]["hsf_setup"].ToString();
						if (this.cbHSFSetup.SelectedIndex != 1 || sblsetupInfo.hsfSetup.ToUpper().CompareTo("TRUE") == 0)
						{
							if (this.cbHSFSetup.SelectedIndex != 2 || sblsetupInfo.hsfSetup.ToUpper().CompareTo("FALSE") == 0)
							{
								if (this.cbHSFlag.SelectedIndex != 1 || sblsetupInfo.onFlag.ToUpper().CompareTo("1") == 0)
								{
									if (this.cbHSFlag.SelectedIndex != 2 || sblsetupInfo.onFlag.ToUpper().CompareTo("0") == 0)
									{
										this._Setuplist2.Add(sblsetupInfo);
									}
								}
							}
						}
					}
				}
				int num = 0;
				foreach (SBLSetupInfo sblsetupInfo2 in this._Setuplist2)
				{
					this.gridSetupList.Rows.Insert(num + 1);
					this.gridSetupList[num + 1, 0] = new Cell(num + 1);
					this.gridSetupList[num + 1, 1] = new Cell(sblsetupInfo2.testername);
					this.gridSetupList[num + 1, 2] = new Cell(sblsetupInfo2.hsfSetup);
					this.gridSetupList[num + 1, 3] = new Cell((sblsetupInfo2.onFlag == "0") ? "False" : "True");
					num++;
				}
				this.gridSetupList.AutoSizeCells();
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

		// Token: 0x06000087 RID: 135 RVA: 0x00007600 File Offset: 0x00005800
		private void pbSetupSearch_Click(object sender, EventArgs e)
		{
			this.getSBLSetupList();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000760A File Offset: 0x0000580A
		private void pbSetupExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridSetupList);
		}

		// Token: 0x0400004F RID: 79
		private QueryMgr queryMgr;

		// Token: 0x04000050 RID: 80
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000051 RID: 81
		private ContextMenu menuSBLHistory = new ContextMenu();

		// Token: 0x04000052 RID: 82
		private SortedList slResultList = new SortedList();

		// Token: 0x04000053 RID: 83
		private Thread _thread;

		// Token: 0x04000054 RID: 84
		private BarPrograss _barPrograss;

		// Token: 0x04000055 RID: 85
		private Dictionary<string, List<SBLSetupInfo>> _Setuplist = new Dictionary<string, List<SBLSetupInfo>>();

		// Token: 0x04000056 RID: 86
		private List<SBLSetupInfo> _Setuplist2 = new List<SBLSetupInfo>();
	}
}
