using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using AlteraSocketView.View;
using Amkor.CADModules.BIBoardInfoModule.CIMitarAdminWS;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using Amkor.CADModules.BIBoardInfoModule.SubForms.TabPages;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DATA;
using DevAge.ComponentModel.Validator;
using DevAge.Drawing;
using ETC;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.BIBoardInfoModule
{
	// Token: 0x0200001B RID: 27
	public partial class BIBoardInfoModule : BaseWinView
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00006028 File Offset: 0x00004228
		public BIBoardInfoModule()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://10.201.16.55/";
			this._factorySetting._factoryName = "ATV";
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this.InitializeComponent();
			this._cimitarUser._id = "hhpark01";
			this._cimitarUser._badgeNo = "395358";
			BIBoardInfoModule._instance = this;
			this._BinSort_Grids_Ref = new List<CBinSort_BinProperty>();
			this._BinSort_Grids = new List<CBinSort_BinProperty>();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000060CC File Offset: 0x000042CC
		public BIBoardInfoModule(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
			BIBoardInfoModule._instance = this;
			this._BinSort_Grids_Ref = new List<CBinSort_BinProperty>();
			this._BinSort_Grids = new List<CBinSort_BinProperty>();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00006130 File Offset: 0x00004330
		private void BIBoardInfoModule_Load(object sender, EventArgs e)
		{
			this.l_subject.Text = this._factorySetting._factoryName + " Burn In Board Integrated System";
			this.InitGridCell();
			this._biBoardInfos = new List<CBIBoardInfo>();
			this._gridIdx_BIBoard = new CGridIndex_BoardInfo();
			this._alCategory_SocketPartChange = new ArrayList();
			this._alCategory_SocketStatus = new ArrayList();
			this.SetPages();
			this.GetCategory();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000619C File Offset: 0x0000439C
		public void InitGridCell()
		{
			Color color = Color.FromArgb(255, 255, 255);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			this._cell_center1 = new Cell();
			this._cell_center1.BackColor = color;
			this._cell_center1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_center1.Border = rectangleBorder;
			this._cell_center1.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_center1.ImageStretch = false;
			Color color2 = Color.FromArgb(223, 230, 233);
			RectangleBorder rectangleBorder2 = new RectangleBorder(new BorderLine(color2), new BorderLine(color2));
			this._cell_center2 = new Cell();
			this._cell_center2.BackColor = color2;
			this._cell_center2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_center2.Border = rectangleBorder2;
			this._cell_center2.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_center2.ImageStretch = false;
			Color color3 = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder3 = new RectangleBorder(new BorderLine(color3), new BorderLine(color3));
			this._cell_header1 = new Cell();
			this._cell_header1.BackColor = color3;
			this._cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_header1.Border = rectangleBorder3;
			Color color4 = Color.FromArgb(253, 203, 110);
			RectangleBorder rectangleBorder4 = new RectangleBorder(new BorderLine(color4), new BorderLine(color4));
			this._cell_onflag = new Cell();
			this._cell_onflag.BackColor = color4;
			this._cell_onflag.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_onflag.Border = rectangleBorder4;
			this._cell_onflag.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_onflag.ImageStretch = false;
			Color color5 = Color.FromArgb(217, 128, 250);
			RectangleBorder rectangleBorder5 = new RectangleBorder(new BorderLine(color5), new BorderLine(color5));
			this._cell_PmList = new Cell();
			this._cell_PmList.BackColor = color5;
			this._cell_PmList.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_PmList.Border = rectangleBorder5;
			this._cell_PmList.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_PmList.ImageStretch = false;
			Color color6 = Color.FromArgb(231, 83, 83);
			RectangleBorder rectangleBorder6 = new RectangleBorder(new BorderLine(color6), new BorderLine(color6));
			this._cell_PmOverList = new Cell();
			this._cell_PmOverList.BackColor = color6;
			this._cell_PmOverList.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_PmOverList.Border = rectangleBorder6;
			this._cell_PmOverList.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this._cell_PmOverList.ImageStretch = false;
			this._checkBox_Normal1 = new CheckBoxBackColorAlternate(color, color);
			this._checkBox_Normal1.Border = RectangleBorder.NoBorder;
			this._checkBox_Normal2 = new CheckBoxBackColorAlternate(color2, color2);
			this._checkBox_Normal2.Border = RectangleBorder.NoBorder;
			this._checkBox_OnFlag = new CheckBoxBackColorAlternate(color4, color4);
			this._checkBox_OnFlag.Border = RectangleBorder.NoBorder;
			this._checkBox_PmList = new CheckBoxBackColorAlternate(color5, color5);
			this._checkBox_PmList.Border = RectangleBorder.NoBorder;
			this._checkBox_PmOverList = new CheckBoxBackColorAlternate(color6, color6);
			this._checkBox_PmOverList.Border = RectangleBorder.NoBorder;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00006510 File Offset: 0x00004710
		private void SetPages()
		{
			foreach (object obj in this.tabControl1.TabPages)
			{
				BIBoardInfoModule.UnloadTabpage((TabPage)obj);
			}
			this.tabControl1.TabPages.Clear();
			if (this._factorySetting._factoryName != "ATV")
			{
				this._tab_Opr = new Tab_Unload("UNLOAD");
			}
			this._tab_PM = new Tab_PM("PROGRESSIVE_MAINTENANCE");
			if (this._factorySetting._factoryName != "ATV")
			{
				this._tab_Trend = new Tab_Trend("TREND");
			}
			if (this._factorySetting._factoryName != "ATV")
			{
				this.tabControl1.TabPages.Add(this._tab_Opr);
			}
			this.tabControl1.TabPages.Add(this._tab_PM);
			if (this._factorySetting._factoryName != "ATV")
			{
				this.tabControl1.TabPages.Add(this._tab_Trend);
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000664C File Offset: 0x0000484C
		public List<CBIBoardInfo> GetBIBoardInfo_Insert(string biboardNo)
		{
			int num;
			if (!int.TryParse(biboardNo, out num))
			{
				MessageBox.Show("Input Number only!");
				return null;
			}
			this._biBoardInfos.Clear();
			List<CBIBoardInfo> result;
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("SCAN..");
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET2', @boardNo = '#" + num.ToString() + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CBIBoardInfo cbiboardInfo = new CBIBoardInfo();
						cbiboardInfo.strBibNo = dataSet.Tables[0].Rows[i]["bibNo"].ToString();
						cbiboardInfo.strDevice = dataSet.Tables[0].Rows[i]["device"].ToString();
						cbiboardInfo.strCustomer = dataSet.Tables[0].Rows[i]["customer"].ToString();
						cbiboardInfo.strLocation = dataSet.Tables[0].Rows[i]["location"].ToString();
						cbiboardInfo.strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString();
						cbiboardInfo.iOnFlag = int.Parse(dataSet.Tables[0].Rows[i]["onflag"].ToString());
						this._biBoardInfos.Add(cbiboardInfo);
					}
				}
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
				result = this._biBoardInfos;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000068C4 File Offset: 0x00004AC4
		public List<CBIBoardInfo> GetBIBoardInfo(string biboardNo)
		{
			int num;
			if (!int.TryParse(biboardNo, out num))
			{
				MessageBox.Show("Input Number only!");
				return null;
			}
			this._biBoardInfos.Clear();
			List<CBIBoardInfo> result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET1', @boardNo = '#",
					num.ToString(),
					"', @userId = '",
					this._cimitarUser._id,
					"', @cntOfSites = '', @socketDesc = '', @comment = ''"
				});
				dataSet = this.QueryCall(sQuery);
				DateTime now = DateTime.Now;
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CBIBoardInfo cbiboardInfo = new CBIBoardInfo();
						cbiboardInfo.iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString());
						cbiboardInfo.strBibNo = dataSet.Tables[0].Rows[i]["bibNo"].ToString();
						cbiboardInfo.strDevice = dataSet.Tables[0].Rows[i]["device"].ToString();
						cbiboardInfo.strCustomer = dataSet.Tables[0].Rows[i]["customer"].ToString();
						cbiboardInfo.strLocation = dataSet.Tables[0].Rows[i]["location"].ToString();
						cbiboardInfo.strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString();
						cbiboardInfo.strUserId = dataSet.Tables[0].Rows[i]["userId"].ToString();
						cbiboardInfo.strUserName = dataSet.Tables[0].Rows[i]["username"].ToString();
						cbiboardInfo.strUserBdno = dataSet.Tables[0].Rows[i]["badgeno"].ToString();
						cbiboardInfo.strComment = dataSet.Tables[0].Rows[i]["comment"].ToString();
						cbiboardInfo.iOnFlag = int.Parse(dataSet.Tables[0].Rows[i]["onflag"].ToString());
						cbiboardInfo.dtPm = DateTime.Parse(dataSet.Tables[0].Rows[i]["pmdate"].ToString());
						cbiboardInfo.dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString());
						cbiboardInfo.strBad_bib = dataSet.Tables[0].Rows[i]["bad"].ToString();
						cbiboardInfo.strGoldTab = dataSet.Tables[0].Rows[i]["gold_tab"].ToString();
						cbiboardInfo.strWarranty = dataSet.Tables[0].Rows[i]["warranty"].ToString();
						cbiboardInfo.iCntBadSocket = int.Parse(dataSet.Tables[0].Rows[i]["bad_socket"].ToString());
						cbiboardInfo.iAllSocket30w = int.Parse(dataSet.Tables[0].Rows[i]["all_30w"].ToString());
						cbiboardInfo.iCntDDay = 27 - (int)Math.Round((now - cbiboardInfo.dtPm).TotalDays);
						this._biBoardInfos.Add(cbiboardInfo);
					}
				}
				result = this._biBoardInfos;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00006D60 File Offset: 0x00004F60
		public List<CBIBoardInfo> GetBIBoardInfo_byBarcode(string barcode)
		{
			if (barcode == "")
			{
				MessageBox.Show("Input BIBoard Number");
				return null;
			}
			this._biBoardInfos.Clear();
			List<CBIBoardInfo> result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET4', @barcode = '",
					barcode,
					"', @userId = '",
					this._cimitarUser._id,
					"', @cntOfSites = '', @socketDesc = '', @comment = ''"
				});
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CBIBoardInfo cbiboardInfo = new CBIBoardInfo();
						cbiboardInfo.iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString());
						cbiboardInfo.strBibNo = dataSet.Tables[0].Rows[i]["bibNo"].ToString();
						cbiboardInfo.strDevice = dataSet.Tables[0].Rows[i]["device"].ToString();
						cbiboardInfo.strCustomer = dataSet.Tables[0].Rows[i]["customer"].ToString();
						cbiboardInfo.strLocation = dataSet.Tables[0].Rows[i]["location"].ToString();
						cbiboardInfo.strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString();
						cbiboardInfo.strUserId = dataSet.Tables[0].Rows[i]["userId"].ToString();
						cbiboardInfo.strUserName = dataSet.Tables[0].Rows[i]["username"].ToString();
						cbiboardInfo.strUserBdno = dataSet.Tables[0].Rows[i]["badgeno"].ToString();
						cbiboardInfo.strComment = dataSet.Tables[0].Rows[i]["comment"].ToString();
						cbiboardInfo.iOnFlag = int.Parse(dataSet.Tables[0].Rows[i]["onflag"].ToString());
						cbiboardInfo.dtPm = DateTime.Parse(dataSet.Tables[0].Rows[i]["pmdate"].ToString());
						cbiboardInfo.dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString());
						cbiboardInfo.strBad_bib = dataSet.Tables[0].Rows[i]["bad"].ToString();
						cbiboardInfo.strGoldTab = dataSet.Tables[0].Rows[i]["gold_tab"].ToString();
						cbiboardInfo.strWarranty = dataSet.Tables[0].Rows[i]["warranty"].ToString();
						this._biBoardInfos.Add(cbiboardInfo);
					}
				}
				result = this._biBoardInfos;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00007140 File Offset: 0x00005340
		public CBIBoardInfo GetBIBoardInfo_withPartChangeHistory(string biboardNo, string dateFrom, string dateTo)
		{
			int num;
			if (!int.TryParse(biboardNo, out num))
			{
				MessageBox.Show("Input Number only!");
				return null;
			}
			CBIBoardInfo result;
			try
			{
				CBIBoardInfo cbiboardInfo = new CBIBoardInfo();
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET6', @boardNo = '#",
					num.ToString(),
					"', @dateFrom = '",
					dateFrom,
					"', @dateTo = '",
					dateTo,
					"'"
				});
				dataSet = this.QueryCall(sQuery);
				DateTime now = DateTime.Now;
				if (dataSet.Tables.Count > 0)
				{
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							cbiboardInfo.iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString());
							cbiboardInfo.strUserId = dataSet.Tables[0].Rows[i]["userId"].ToString();
							cbiboardInfo.strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString();
							cbiboardInfo.strBibNo = dataSet.Tables[0].Rows[i]["bibNo"].ToString();
							cbiboardInfo.strCustomer = dataSet.Tables[0].Rows[i]["customer"].ToString();
							cbiboardInfo.strDevice = dataSet.Tables[0].Rows[i]["device"].ToString();
							cbiboardInfo.strComment = dataSet.Tables[0].Rows[i]["comment"].ToString();
							cbiboardInfo.strBad_bib = dataSet.Tables[0].Rows[i]["bad"].ToString();
							cbiboardInfo.strGoldTab = dataSet.Tables[0].Rows[i]["gold_tab"].ToString();
							cbiboardInfo.strWarranty = dataSet.Tables[0].Rows[i]["warranty"].ToString();
							cbiboardInfo.iAllSocket30w = int.Parse(dataSet.Tables[0].Rows[i]["all_30w"].ToString());
							cbiboardInfo.iOnFlag = int.Parse(dataSet.Tables[0].Rows[i]["onflag"].ToString());
							cbiboardInfo.dtPm = DateTime.Parse(dataSet.Tables[0].Rows[i]["pmdate"].ToString());
							cbiboardInfo.dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString());
							cbiboardInfo.cSocketPartChanges = new List<CSocketPartChange>();
							cbiboardInfo.iCntDDay = 27 - (int)Math.Round((now - cbiboardInfo.dtPm).TotalDays);
						}
					}
					if (dataSet.Tables.Count > 1 && dataSet.Tables[1].Rows.Count > 0)
					{
						for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
						{
							CSocketPartChange csocketPartChange = new CSocketPartChange();
							csocketPartChange.iId = int.Parse(dataSet.Tables[1].Rows[j]["id"].ToString());
							csocketPartChange.strCategory = dataSet.Tables[1].Rows[j]["category"].ToString();
							csocketPartChange.strBarcode_Board = dataSet.Tables[1].Rows[j]["barcode_board"].ToString();
							csocketPartChange.strBibNo = dataSet.Tables[1].Rows[j]["bibNo"].ToString();
							csocketPartChange.iSocketNo = int.Parse(dataSet.Tables[1].Rows[j]["socketNo"].ToString());
							csocketPartChange.strBarcode_Socket = dataSet.Tables[1].Rows[j]["barcode_socket"].ToString();
							csocketPartChange.iRepairTime_Min = int.Parse(dataSet.Tables[1].Rows[j]["repairTime_min"].ToString());
							csocketPartChange.strBadgeNo = dataSet.Tables[1].Rows[j]["badgeno"].ToString();
							csocketPartChange.strComment = dataSet.Tables[1].Rows[j]["comment"].ToString();
							csocketPartChange.dtInTime = DateTime.Parse(dataSet.Tables[1].Rows[j]["intime"].ToString());
							cbiboardInfo.cSocketPartChanges.Add(csocketPartChange);
						}
					}
					result = cbiboardInfo;
				}
				else
				{
					result = null;
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00007754 File Offset: 0x00005954
		public CBIBoardInfo GetBIBoardInfo_withPartChangeHistory_All(string dateFrom, string dateTo)
		{
			CBIBoardInfo result;
			try
			{
				CBIBoardInfo cbiboardInfo = new CBIBoardInfo();
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_P_CHANGE_ALL', @dateFrom = '",
					dateFrom,
					"', @dateTo = '",
					dateTo,
					"'"
				});
				dataSet = this.QueryCall(sQuery);
				cbiboardInfo.cSocketPartChanges = new List<CSocketPartChange>();
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CSocketPartChange csocketPartChange = new CSocketPartChange();
						csocketPartChange.iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString());
						csocketPartChange.strCategory = dataSet.Tables[0].Rows[i]["category"].ToString();
						csocketPartChange.strBarcode_Board = dataSet.Tables[0].Rows[i]["barcode_board"].ToString();
						csocketPartChange.strBibNo = dataSet.Tables[0].Rows[i]["bibNo"].ToString();
						csocketPartChange.iSocketNo = int.Parse(dataSet.Tables[0].Rows[i]["socketNo"].ToString());
						csocketPartChange.strBarcode_Socket = dataSet.Tables[0].Rows[i]["barcode_socket"].ToString();
						csocketPartChange.iRepairTime_Min = int.Parse(dataSet.Tables[0].Rows[i]["repairTime_min"].ToString());
						csocketPartChange.strBadgeNo = dataSet.Tables[0].Rows[i]["badgeno"].ToString();
						csocketPartChange.strComment = dataSet.Tables[0].Rows[i]["comment"].ToString();
						csocketPartChange.dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString());
						cbiboardInfo.cSocketPartChanges.Add(csocketPartChange);
					}
				}
				result = cbiboardInfo;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00007A14 File Offset: 0x00005C14
		public List<CBinSort_FileInfo> GetBinSort_FileInfo(string lotNo)
		{
			List<CBinSort_FileInfo> list = new List<CBinSort_FileInfo>();
			List<CBinSort_FileInfo> result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_BinSort_Unload] @flag = 'LOT_INFO', @lotNo = '" + lotNo + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						list.Add(new CBinSort_FileInfo
						{
							iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString()),
							strLotNo = dataSet.Tables[0].Rows[i]["lotno"].ToString(),
							strDcc = dataSet.Tables[0].Rows[i]["dcc"].ToString(),
							strOpr = dataSet.Tables[0].Rows[i]["operation"].ToString(),
							strFileName = dataSet.Tables[0].Rows[i]["filename"].ToString(),
							strTesterName = dataSet.Tables[0].Rows[i]["tester"].ToString(),
							iProcessId = int.Parse(dataSet.Tables[0].Rows[i]["processid"].ToString()),
							strBadgeNo = dataSet.Tables[0].Rows[i]["badgeno"].ToString(),
							dtIntime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString())
						});
					}
				}
				result = list;
			}
			catch (Exception)
			{
				list.Clear();
				result = list;
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00007C7C File Offset: 0x00005E7C
		public List<CBinSort_BoardInfo> GetBinSort_BoardInfo(string lotNo, int boardNo)
		{
			List<CBinSort_BoardInfo> list = new List<CBinSort_BoardInfo>();
			List<CBinSort_BoardInfo> result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_BinSort_Unload] @flag = 'BOARD_INFO', @lotNo = '",
					lotNo,
					"', @boardNo = '",
					boardNo.ToString(),
					"'"
				});
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						list.Add(new CBinSort_BoardInfo
						{
							iBoardId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString()),
							strBibNo = dataSet.Tables[0].Rows[i]["bibno"].ToString(),
							iFileId = int.Parse(dataSet.Tables[0].Rows[i]["fileid"].ToString()),
							iZoneNo = int.Parse(dataSet.Tables[0].Rows[i]["zoneno"].ToString()),
							iSlotNo = int.Parse(dataSet.Tables[0].Rows[i]["slotno"].ToString()),
							strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString(),
							dtIntime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString()),
							dtPmDate = DateTime.Parse(dataSet.Tables[0].Rows[i]["pm_date"].ToString())
						});
					}
				}
				result = list;
			}
			catch (Exception)
			{
				list.Clear();
				result = list;
			}
			return result;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00007EE8 File Offset: 0x000060E8
		public List<CBinSort_SocketInfo> GetBinSort_SocketInfo(int boardId)
		{
			List<CBinSort_SocketInfo> list = new List<CBinSort_SocketInfo>();
			List<CBinSort_SocketInfo> result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_BinSort_Unload] @flag = 'SOCK_INFO', @boardId = " + boardId.ToString();
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						list.Add(new CBinSort_SocketInfo
						{
							iSockNo = int.Parse(dataSet.Tables[0].Rows[i]["socketno"].ToString()),
							strBinNo = dataSet.Tables[0].Rows[i]["binno"].ToString(),
							iGood = int.Parse(dataSet.Tables[0].Rows[i]["ispassbin"].ToString())
						});
					}
				}
				list = (from o in list
				orderby o.iSockNo
				select o).ToList<CBinSort_SocketInfo>();
				result = list;
			}
			catch (Exception)
			{
				list.Clear();
				result = list;
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000806C File Offset: 0x0000626C
		public CSessionTotal GetBinSort_BinningInfo_Board(int boardId)
		{
			CSessionTotal csessionTotal = new CSessionTotal();
			List<CBinSort_BinningInfo> list = new List<CBinSort_BinningInfo>();
			CSessionTotal result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_BinSort_Summary] @flag = 'GET_BIN_BOARD', @boardId = " + boardId.ToString();
				dataSet = this.QueryCall(sQuery);
				int num = 0;
				int num2 = 0;
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CBinSort_BinningInfo cbinSort_BinningInfo = new CBinSort_BinningInfo();
						cbinSort_BinningInfo.strBinNo = dataSet.Tables[0].Rows[i]["binno"].ToString();
						cbinSort_BinningInfo.iCount = int.Parse(dataSet.Tables[0].Rows[i]["count"].ToString());
						cbinSort_BinningInfo.iGood = int.Parse(dataSet.Tables[0].Rows[i]["ispassbin"].ToString());
						list.Add(cbinSort_BinningInfo);
						num += cbinSort_BinningInfo.iCount;
						if (cbinSort_BinningInfo.iGood == 1)
						{
							num2 += cbinSort_BinningInfo.iCount;
						}
					}
				}
				csessionTotal.iTotal = num;
				csessionTotal.iGood = num2;
				csessionTotal.iFail = num - num2;
				csessionTotal.binningInfos = list;
				result = csessionTotal;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00008214 File Offset: 0x00006414
		public CSessionTotal GetBinSort_BinningInfo_Sum_File(int processId, int fileId)
		{
			CSessionTotal csessionTotal = new CSessionTotal();
			List<CBinSort_BinningInfo> list = new List<CBinSort_BinningInfo>();
			this.GetBinProperties(fileId);
			this._BinSort_Grids.Clear();
			CSessionTotal result;
			try
			{
				string sQuery = string.Empty;
				sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_BinSort_Summary] @flag = 'GET_BIN_SUM_FILE', @fileId = " + fileId.ToString();
				DataSet dataSet = this.QueryCall(sQuery);
				int num = 0;
				int num2 = 0;
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CBinSort_BinningInfo cbinSort_BinningInfo = new CBinSort_BinningInfo();
						cbinSort_BinningInfo.strBinNo = dataSet.Tables[0].Rows[i]["binno"].ToString();
						cbinSort_BinningInfo.iCount = int.Parse(dataSet.Tables[0].Rows[i]["count"].ToString());
						cbinSort_BinningInfo.iGood = int.Parse(dataSet.Tables[0].Rows[i]["ispassbin"].ToString());
						list.Add(cbinSort_BinningInfo);
						num += cbinSort_BinningInfo.iCount;
						if (cbinSort_BinningInfo.iGood == 1)
						{
							num2 += cbinSort_BinningInfo.iCount;
						}
						CBinSort_BinProperty cbinSort_BinProperty = new CBinSort_BinProperty();
						cbinSort_BinProperty.strBinNo = cbinSort_BinningInfo.strBinNo;
						cbinSort_BinProperty.iIndex = i + 1;
						cbinSort_BinProperty.iColor_r = int.Parse(dataSet.Tables[0].Rows[i]["color_r"].ToString());
						cbinSort_BinProperty.iColor_g = int.Parse(dataSet.Tables[0].Rows[i]["color_g"].ToString());
						cbinSort_BinProperty.iColor_b = int.Parse(dataSet.Tables[0].Rows[i]["color_b"].ToString());
						this._BinSort_Grids.Add(cbinSort_BinProperty);
					}
				}
				csessionTotal.iTotal = num;
				csessionTotal.iGood = num2;
				csessionTotal.iFail = num - num2;
				csessionTotal.binningInfos = list;
				result = csessionTotal;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00008498 File Offset: 0x00006698
		public void GetBinProperties(int fileId)
		{
			this._BinSort_Grids_Ref.Clear();
			string sQuery = string.Empty;
			sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_BinSort_Summary] @flag = 'GET_BIN_DESC', @fileId = " + fileId.ToString();
			DataSet dataSet = this.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					CBinSort_BinProperty cbinSort_BinProperty = new CBinSort_BinProperty();
					cbinSort_BinProperty.strBinNo = dataSet.Tables[0].Rows[i]["binno"].ToString();
					cbinSort_BinProperty.iIndex = i + 1;
					cbinSort_BinProperty.iColor_r = int.Parse(dataSet.Tables[0].Rows[i]["color_r"].ToString());
					cbinSort_BinProperty.iColor_g = int.Parse(dataSet.Tables[0].Rows[i]["color_g"].ToString());
					cbinSort_BinProperty.iColor_b = int.Parse(dataSet.Tables[0].Rows[i]["color_b"].ToString());
					this._BinSort_Grids_Ref.Add(cbinSort_BinProperty);
				}
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00008600 File Offset: 0x00006800
		public void GetBIBoardSocketInfo(CBIBoardInfo bibInfo)
		{
			bibInfo.cSocketInfos = new List<CBIBoardSocketInfo>();
			SortedList sortedList = new SortedList();
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Socket] @flag = 'GET', @groupId = '" + bibInfo.iId.ToString() + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CBIBoardSocketInfo cbiboardSocketInfo = new CBIBoardSocketInfo();
						cbiboardSocketInfo.iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString());
						cbiboardSocketInfo.iGroupId = int.Parse(dataSet.Tables[0].Rows[i]["groupId"].ToString());
						if (!int.TryParse(dataSet.Tables[0].Rows[i]["socketNo"].ToString(), out cbiboardSocketInfo.iSocketNo))
						{
							cbiboardSocketInfo.iSocketNo = 1000;
						}
						cbiboardSocketInfo.strCap_Miss = dataSet.Tables[0].Rows[i]["cap_missing"].ToString();
						cbiboardSocketInfo.strResistor_Miss = dataSet.Tables[0].Rows[i]["resistor_missing"].ToString();
						cbiboardSocketInfo.strIc_Miss = dataSet.Tables[0].Rows[i]["ic_missing"].ToString();
						cbiboardSocketInfo.strCap_Dmg = dataSet.Tables[0].Rows[i]["cap_damage"].ToString();
						cbiboardSocketInfo.strResistor_Dmg = dataSet.Tables[0].Rows[i]["resistor_damage"].ToString();
						cbiboardSocketInfo.strIc_Dmg = dataSet.Tables[0].Rows[i]["ic_damage"].ToString();
						cbiboardSocketInfo.strBad_sock = dataSet.Tables[0].Rows[i]["bad"].ToString();
						cbiboardSocketInfo.strCoverSprDegrad = dataSet.Tables[0].Rows[i]["cover_spr_degrad"].ToString();
						cbiboardSocketInfo.strHeaterCable = dataSet.Tables[0].Rows[i]["heater_cable"].ToString();
						cbiboardSocketInfo.strDterCardSetCond = dataSet.Tables[0].Rows[i]["dter_card_set_cond"].ToString();
						cbiboardSocketInfo.strFuncTest = dataSet.Tables[0].Rows[i]["func_test"].ToString();
						cbiboardSocketInfo.strBentPins = dataSet.Tables[0].Rows[i]["bent_pins"].ToString();
						cbiboardSocketInfo.strStuckPins = dataSet.Tables[0].Rows[i]["stuck_pins"].ToString();
						cbiboardSocketInfo.strMeltedPins = dataSet.Tables[0].Rows[i]["melted_pins"].ToString();
						cbiboardSocketInfo.strBurntPins = dataSet.Tables[0].Rows[i]["burnt_pins"].ToString();
						cbiboardSocketInfo.strDmgSockHousing = dataSet.Tables[0].Rows[i]["dmg_sock_housing"].ToString();
						cbiboardSocketInfo.strRemark = dataSet.Tables[0].Rows[i]["remark"].ToString();
						cbiboardSocketInfo.strBadSocketStatus = dataSet.Tables[0].Rows[i]["bad_socket_status"].ToString();
						cbiboardSocketInfo.dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString());
						bibInfo.cSocketInfos.Add(cbiboardSocketInfo);
						if (!sortedList.ContainsKey(cbiboardSocketInfo.iSocketNo))
						{
							sortedList.Add(cbiboardSocketInfo.iSocketNo, new SortedList());
							SortedList sortedList2 = (SortedList)sortedList[cbiboardSocketInfo.iSocketNo];
							sortedList2.Add(sortedList2.Count, cbiboardSocketInfo);
						}
						else
						{
							SortedList sortedList3 = (SortedList)sortedList[cbiboardSocketInfo.iSocketNo];
							sortedList3.Add(sortedList3.Count, cbiboardSocketInfo);
						}
					}
				}
				bibInfo.slSocketList = sortedList;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00008B58 File Offset: 0x00006D58
		public void GetBIBoardSocketInfo_Insert(CBIBoardInfo bibInfo, int cntOfSock = 24)
		{
			bibInfo.cSocketInfos = new List<CBIBoardSocketInfo>();
			bibInfo.iOnFlag = 1;
			SortedList sortedList = new SortedList();
			int num;
			if (this._factorySetting._factoryName == "ATV")
			{
				num = 1;
			}
			else
			{
				num = 0;
			}
			try
			{
				for (int i = num; i <= cntOfSock; i++)
				{
					CBIBoardSocketInfo cbiboardSocketInfo = new CBIBoardSocketInfo();
					cbiboardSocketInfo.iId = 0;
					cbiboardSocketInfo.iGroupId = 0;
					cbiboardSocketInfo.iSocketNo = i;
					cbiboardSocketInfo.strCap_Miss = "";
					cbiboardSocketInfo.strResistor_Miss = "";
					cbiboardSocketInfo.strIc_Miss = "";
					cbiboardSocketInfo.strCap_Dmg = "";
					cbiboardSocketInfo.strResistor_Dmg = "";
					cbiboardSocketInfo.strIc_Dmg = "";
					cbiboardSocketInfo.strBad_sock = "0";
					cbiboardSocketInfo.strCoverSprDegrad = "Good";
					cbiboardSocketInfo.strHeaterCable = "Good";
					cbiboardSocketInfo.strDterCardSetCond = "Good";
					cbiboardSocketInfo.strFuncTest = "Good";
					cbiboardSocketInfo.strBentPins = "0";
					cbiboardSocketInfo.strStuckPins = "0";
					cbiboardSocketInfo.strMeltedPins = "0";
					cbiboardSocketInfo.strBurntPins = "0";
					cbiboardSocketInfo.strDmgSockHousing = "0";
					cbiboardSocketInfo.strRemark = "";
					cbiboardSocketInfo.dtInTime = DateTime.Now;
					bibInfo.cSocketInfos.Add(cbiboardSocketInfo);
					sortedList.Add(cbiboardSocketInfo.iSocketNo, new SortedList());
					SortedList sortedList2 = (SortedList)sortedList[cbiboardSocketInfo.iSocketNo];
					sortedList2.Add(sortedList2.Count, cbiboardSocketInfo);
				}
				CBIBoardSocketInfo cbiboardSocketInfo2 = new CBIBoardSocketInfo();
				cbiboardSocketInfo2.iId = 0;
				cbiboardSocketInfo2.iGroupId = 0;
				cbiboardSocketInfo2.iSocketNo = 1000;
				cbiboardSocketInfo2.strCap_Miss = "";
				cbiboardSocketInfo2.strResistor_Miss = "";
				cbiboardSocketInfo2.strIc_Miss = "";
				cbiboardSocketInfo2.strCap_Dmg = "";
				cbiboardSocketInfo2.strResistor_Dmg = "";
				cbiboardSocketInfo2.strIc_Dmg = "";
				cbiboardSocketInfo2.strBad_sock = "0";
				cbiboardSocketInfo2.strCoverSprDegrad = "Good";
				cbiboardSocketInfo2.strHeaterCable = "Good";
				cbiboardSocketInfo2.strDterCardSetCond = "Good";
				cbiboardSocketInfo2.strFuncTest = "Good";
				cbiboardSocketInfo2.strBentPins = "0";
				cbiboardSocketInfo2.strStuckPins = "0";
				cbiboardSocketInfo2.strMeltedPins = "0";
				cbiboardSocketInfo2.strBurntPins = "0";
				cbiboardSocketInfo2.strDmgSockHousing = "0";
				cbiboardSocketInfo2.strRemark = "";
				cbiboardSocketInfo2.dtInTime = DateTime.Now;
				bibInfo.cSocketInfos.Add(cbiboardSocketInfo2);
				sortedList.Add(cbiboardSocketInfo2.iSocketNo, new SortedList());
				SortedList sortedList3 = (SortedList)sortedList[cbiboardSocketInfo2.iSocketNo];
				sortedList3.Add(sortedList3.Count, cbiboardSocketInfo2);
				bibInfo.slSocketList = sortedList;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00008E4C File Offset: 0x0000704C
		public List<CBIBoardInfo> GetAllBIBoardInfo()
		{
			List<CBIBoardInfo> list = new List<CBIBoardInfo>();
			List<CBIBoardInfo> result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET3', @boardNo = '', @userId = '', @cntOfSites = '', @socketDesc = '', @comment = ''";
				dataSet = this.QueryCall(sQuery);
				DateTime now = DateTime.Now;
				if (dataSet.Tables.Count > 0)
				{
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							CBIBoardInfo cbiboardInfo = new CBIBoardInfo();
							cbiboardInfo.iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString());
							cbiboardInfo.strBibNo = dataSet.Tables[0].Rows[i]["bibNo"].ToString();
							cbiboardInfo.strDevice = dataSet.Tables[0].Rows[i]["device"].ToString();
							cbiboardInfo.strCustomer = dataSet.Tables[0].Rows[i]["customer"].ToString();
							cbiboardInfo.strLocation = dataSet.Tables[0].Rows[i]["location"].ToString();
							cbiboardInfo.strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString();
							cbiboardInfo.strUserId = dataSet.Tables[0].Rows[i]["userId"].ToString();
							cbiboardInfo.strUserName = dataSet.Tables[0].Rows[i]["username"].ToString();
							cbiboardInfo.strUserBdno = dataSet.Tables[0].Rows[i]["badgeno"].ToString();
							cbiboardInfo.strComment = dataSet.Tables[0].Rows[i]["comment"].ToString();
							cbiboardInfo.iOnFlag = int.Parse(dataSet.Tables[0].Rows[i]["onflag"].ToString());
							cbiboardInfo.dtPm = DateTime.Parse(dataSet.Tables[0].Rows[i]["pmdate"].ToString());
							cbiboardInfo.dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString());
							cbiboardInfo.strBad_bib = dataSet.Tables[0].Rows[i]["bad"].ToString();
							cbiboardInfo.strGoldTab = dataSet.Tables[0].Rows[i]["gold_tab"].ToString();
							cbiboardInfo.strWarranty = dataSet.Tables[0].Rows[i]["warranty"].ToString();
							cbiboardInfo.iCntBadSocket = int.Parse(dataSet.Tables[0].Rows[i]["bad_socket"].ToString());
							cbiboardInfo.iAllSocket30w = int.Parse(dataSet.Tables[0].Rows[i]["all_30w"].ToString());
							cbiboardInfo.iCntDDay = 27 - (int)Math.Round((now - cbiboardInfo.dtPm).TotalDays);
							list.Add(cbiboardInfo);
						}
					}
					if (dataSet.Tables[1].Rows.Count > 0)
					{
						for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
						{
							list.Add(new CBIBoardInfo
							{
								iId = 0,
								strBibNo = dataSet.Tables[1].Rows[j]["bibNo"].ToString(),
								strDevice = dataSet.Tables[1].Rows[j]["device"].ToString(),
								strCustomer = dataSet.Tables[1].Rows[j]["customer"].ToString(),
								strLocation = dataSet.Tables[1].Rows[j]["location"].ToString(),
								strBarcode = dataSet.Tables[1].Rows[j]["barcode"].ToString(),
								strUserId = "",
								strUserName = "",
								strUserBdno = "",
								strComment = "",
								iOnFlag = 1,
								strBad_bib = "0"
							});
						}
					}
				}
				result = list;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00009414 File Offset: 0x00007614
		public void SetBIBoardInfo(CBIBoardInfo bibInfo, string socketDesc, string comment)
		{
			int num = 0;
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("SCAN..");
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'SET2', @boardNo = '",
					bibInfo.strBibNo,
					"', @userId = '",
					bibInfo.strUserId,
					"', @cntOfSites = '', @socketDesc = N'",
					socketDesc,
					"', @comment = '",
					comment,
					"', @badFlag_Board = '",
					bibInfo.strBad_bib,
					"', @barcode = '",
					bibInfo.strBarcode,
					"', @goldTab = '",
					bibInfo.strGoldTab,
					"', @warranty = '",
					bibInfo.strWarranty,
					"', @all_30w_flag = ",
					bibInfo.iAllSocket30w.ToString()
				});
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						num = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
					}
				}
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
				if (num == 0)
				{
					MessageBox.Show("Success to Update");
				}
				else
				{
					MessageBox.Show("Fail to update");
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

		// Token: 0x06000054 RID: 84 RVA: 0x00009628 File Offset: 0x00007828
		public ArrayList GetSocketChangeCategory()
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add("ALL");
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_PART_CHANGE_CATEGORY'";
			dataSet = this.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					foreach (string text in dataSet.Tables[0].Rows[i]["category"].ToString().Split(new char[]
					{
						';'
					}))
					{
						if (text != "")
						{
							arrayList.Add(text);
						}
					}
				}
			}
			return arrayList;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00009718 File Offset: 0x00007918
		public void GetCategory()
		{
			this._alCategory_SocketPartChange.Clear();
			this._alCategory_SocketStatus.Clear();
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_CATEGORY'";
			dataSet = this.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					this._alCategory_SocketPartChange.Add("ALL");
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						foreach (string text in dataSet.Tables[0].Rows[i]["category"].ToString().Split(new char[]
						{
							';'
						}))
						{
							if (text != "")
							{
								this._alCategory_SocketPartChange.Add(text);
							}
						}
					}
				}
				if (dataSet.Tables[1].Rows.Count > 0)
				{
					for (int k = 0; k < dataSet.Tables[1].Rows.Count; k++)
					{
						foreach (string text2 in dataSet.Tables[1].Rows[k]["category"].ToString().Split(new char[]
						{
							';'
						}))
						{
							if (text2 != "")
							{
								this._alCategory_SocketStatus.Add(text2);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000098CC File Offset: 0x00007ACC
		public static void UnloadTabpage(TabPage page)
		{
			for (int i = page.Controls.Count - 1; i >= 0; i--)
			{
				page.Controls[i].Dispose();
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00009904 File Offset: 0x00007B04
		public DataSet QueryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._factorySetting._urlServer + "CIMitarWebService/CIMitarWS.asmx";
				cimitarWSSoapClient.Endpoint.Address = new EndpointAddress(uri);
				dataSet = cimitarWSSoapClient.CIMitarQuaryCall("CIMitar_HCC", sQuery);
				result = dataSet;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				result = dataSet;
			}
			return result;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00009974 File Offset: 0x00007B74
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00009982 File Offset: 0x00007B82
		private void pb_Help_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Help.Image = Resources.Help;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000999F File Offset: 0x00007B9F
		private void pb_Help_MouseMove(object sender, MouseEventArgs e)
		{
			this.pb_Help.Image = Resources.Help_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00009982 File Offset: 0x00007B82
		private void pb_Help_MouseLeave(object sender, EventArgs e)
		{
			this.pb_Help.Image = Resources.Help;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000099BC File Offset: 0x00007BBC
		private void pb_Help_MouseUp(object sender, MouseEventArgs e)
		{
			Process.Start("http://testweb.amkor.co.kr/cimitaradmin/download/CIMitarAdmin_BurnIn.pdf");
		}

		// Token: 0x040000CC RID: 204
		public BarPrograss _barPrograss;

		// Token: 0x040000CD RID: 205
		public Thread _thread;

		// Token: 0x040000CE RID: 206
		private List<CBIBoardInfo> _biBoardInfos;

		// Token: 0x040000CF RID: 207
		public CGridIndex_BoardInfo _gridIdx_BIBoard;

		// Token: 0x040000D0 RID: 208
		private Tab_Unload _tab_Opr;

		// Token: 0x040000D1 RID: 209
		private Tab_PM _tab_PM;

		// Token: 0x040000D2 RID: 210
		private Tab_Trend _tab_Trend;

		// Token: 0x040000D3 RID: 211
		public List<CBinSort_BinProperty> _BinSort_Grids_Ref;

		// Token: 0x040000D4 RID: 212
		public List<CBinSort_BinProperty> _BinSort_Grids;

		// Token: 0x040000D5 RID: 213
		public Cell _cell_center1;

		// Token: 0x040000D6 RID: 214
		public Cell _cell_center2;

		// Token: 0x040000D7 RID: 215
		public Cell _cell_header1;

		// Token: 0x040000D8 RID: 216
		public Cell _cell_onflag;

		// Token: 0x040000D9 RID: 217
		public Cell _cell_PmList;

		// Token: 0x040000DA RID: 218
		public Cell _cell_PmOverList;

		// Token: 0x040000DB RID: 219
		public CheckBoxBackColorAlternate _checkBox_Normal1;

		// Token: 0x040000DC RID: 220
		public CheckBoxBackColorAlternate _checkBox_Normal2;

		// Token: 0x040000DD RID: 221
		public CheckBoxBackColorAlternate _checkBox_OnFlag;

		// Token: 0x040000DE RID: 222
		public CheckBoxBackColorAlternate _checkBox_PmList;

		// Token: 0x040000DF RID: 223
		public CheckBoxBackColorAlternate _checkBox_PmOverList;

		// Token: 0x040000E0 RID: 224
		public static BIBoardInfoModule _instance;

		// Token: 0x040000E1 RID: 225
		public ArrayList _alCategory_SocketPartChange;

		// Token: 0x040000E2 RID: 226
		public ArrayList _alCategory_SocketStatus;
	}
}
