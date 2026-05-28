using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using Amkor.CADModules.HccRepHisModule.CIMitarAdminWS;
using Amkor.CADModules.HccRepHisModule.SubForms.TabPages;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using CommonLibrary;
using DATA;
using DevAge.Drawing;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.HccRepHisModule
{
	// Token: 0x02000003 RID: 3
	public partial class HccRepHisModule : BaseWinView
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002640 File Offset: 0x00000840
		public HccRepHisModule()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://testweb.amkor.co.kr/";
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this.InitializeComponent();
			this._cimitarUser._id = "dehlee";
			HccRepHisModule._instance = this;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000026AC File Offset: 0x000008AC
		public HccRepHisModule(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
			HccRepHisModule._instance = this;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000026F9 File Offset: 0x000008F9
		private void HccRepHisModule_Load(object sender, EventArgs e)
		{
			this.InitGridCell();
			this.SetPages();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002708 File Offset: 0x00000908
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
			this._checkBox_Normal1 = new CheckBoxBackColorAlternate(color, color);
			this._checkBox_Normal1.Border = RectangleBorder.NoBorder;
			this._checkBox_Normal2 = new CheckBoxBackColorAlternate(color2, color2);
			this._checkBox_Normal2.Border = RectangleBorder.NoBorder;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000028A7 File Offset: 0x00000AA7
		private void SetPages()
		{
			this.tabControl1.TabPages.Clear();
			this._tab_RepairHistory = new Tab_RepairHistory("Repair History");
			this.tabControl1.TabPages.Add(this._tab_RepairHistory);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000028E0 File Offset: 0x00000AE0
		public int GetHwTypeNo_Barcode(string barcode)
		{
			int result = 0;
			if (barcode != "")
			{
				string a = barcode.Substring(0, 2);
				if (!(a == "AB"))
				{
					if (!(a == "AT"))
					{
						if (!(a == "AC"))
						{
							if (!(a == "AD"))
							{
								if (!(a == "AS"))
								{
									if (a == "AE")
									{
										result = 6;
									}
								}
								else
								{
									result = 5;
								}
							}
							else
							{
								result = 4;
							}
						}
						else
						{
							result = 3;
						}
					}
					else
					{
						result = 2;
					}
				}
				else
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000296C File Offset: 0x00000B6C
		public int GetHwTypeNo_Type(string hwType)
		{
			int result = 0;
			if (hwType != "")
			{
				if (!(hwType == "BOARD"))
				{
					if (!(hwType == "SOCKET"))
					{
						if (!(hwType == "KIT"))
						{
							if (hwType == "CORR")
							{
								result = 4;
							}
						}
						else
						{
							result = 3;
						}
					}
					else
					{
						result = 2;
					}
				}
				else
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000029D0 File Offset: 0x00000BD0
		public string GetCustInfo(int typeNo, string desc, List<CCust> cCusts)
		{
			string result = string.Empty;
			if (typeNo != 1)
			{
				if (typeNo != 2)
				{
					return result;
				}
			}
			else
			{
				using (List<CCust>.Enumerator enumerator = cCusts.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CCust ccust = enumerator.Current;
						if (ccust.strCustName == desc)
						{
							result = ccust.strCustCode;
							break;
						}
					}
					return result;
				}
			}
			foreach (CCust ccust2 in cCusts)
			{
				if (ccust2.strCustCode == desc)
				{
					result = ccust2.strCustName;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002A90 File Offset: 0x00000C90
		public List<CCust> GetData_Cust()
		{
			List<CCust> list = new List<CCust>();
			string sQuery = string.Empty;
			sQuery = "EXEC [CIMitar_HCC].[dbo].[USP_Addn_RepairStatus] @flag = 'GET_CUST'";
			DataSet dataSet = this.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					CCust ccust = new CCust();
					ccust.strCustCode = dataSet.Tables[0].Rows[i]["customercode"].ToString();
					ccust.strCustName = dataSet.Tables[0].Rows[i]["customername"].ToString();
					ccust.strDesc = ccust.strCustName + "(" + ccust.strCustCode + ")";
					list.Add(ccust);
				}
			}
			return (from o in list
			orderby o.strCustName
			select o).ToList<CCust>();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002BC8 File Offset: 0x00000DC8
		public List<CPdt> GetData_Pdt(string custCode)
		{
			List<CPdt> list = new List<CPdt>();
			string sQuery = string.Empty;
			sQuery = "EXEC [CIMitar_HCC].[dbo].[USP_Addn_RepairStatus] @flag = 'GET_PDT', @custCode = '" + custCode + "'";
			DataSet dataSet = this.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					list.Add(new CPdt
					{
						strProduct = dataSet.Tables[0].Rows[i]["productname"].ToString()
					});
				}
			}
			return (from o in list
			orderby o.strProduct
			select o).ToList<CPdt>();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002CAC File Offset: 0x00000EAC
		public List<CRepairHistoryItem> GetData_History(string custCode, string board, string serialNo, string from, string to)
		{
			List<CRepairHistoryItem> list = new List<CRepairHistoryItem>();
			string sQuery = string.Empty;
			sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_HCC].[dbo].[USP_Addn_RepairStatus] @flag = 'GET_STATUS', @custCode = '",
				custCode,
				"', @board = '",
				board,
				"', @serialNo = '",
				serialNo,
				"', @from = '",
				from,
				"', @to = '",
				to,
				"'"
			});
			DataSet dataSet = this.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					CRepairHistoryItem crepairHistoryItem = new CRepairHistoryItem();
					crepairHistoryItem.iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString());
					crepairHistoryItem.strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString();
					crepairHistoryItem.strCustName = dataSet.Tables[0].Rows[i]["cust_name"].ToString();
					crepairHistoryItem.strCustCode = dataSet.Tables[0].Rows[i]["cust_code"].ToString();
					crepairHistoryItem.strBoard = dataSet.Tables[0].Rows[i]["device"].ToString();
					crepairHistoryItem.strSerialNo = dataSet.Tables[0].Rows[i]["serial_no"].ToString();
					crepairHistoryItem.iNumOfSites = int.Parse(dataSet.Tables[0].Rows[i]["sites"].ToString());
					if (!int.TryParse(dataSet.Tables[0].Rows[i]["sites_defect"].ToString(), out crepairHistoryItem.iDefectedSite))
					{
						crepairHistoryItem.iDefectedSite = 0;
					}
					crepairHistoryItem.strProbDesc = dataSet.Tables[0].Rows[i]["prob_desc"].ToString();
					crepairHistoryItem.strAction = dataSet.Tables[0].Rows[i]["action"].ToString();
					crepairHistoryItem.dtInDate = DateTime.Parse(dataSet.Tables[0].Rows[i]["in_time"].ToString());
					crepairHistoryItem.dtUpdateDate = DateTime.Parse(dataSet.Tables[0].Rows[i]["update_time"].ToString());
					list.Add(crepairHistoryItem);
				}
			}
			return list;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002FC8 File Offset: 0x000011C8
		public int DeleteRepHistory(int id, string badgeNo, string comment)
		{
			new List<CPdt>();
			string sQuery = string.Empty;
			sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_HCC].[dbo].[USP_Addn_RepairStatus] @flag = 'DEL', @historyId = ",
				id.ToString(),
				", @badgeNo = '",
				badgeNo,
				"', @comment = N'",
				comment,
				"'"
			});
			DataSet dataSet = this.QueryCall(sQuery);
			int result = 1;
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					result = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
				}
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000030A0 File Offset: 0x000012A0
		public DataSet QueryCall(string sQuery)
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

		// Token: 0x0400000C RID: 12
		public Cell _cell_center1;

		// Token: 0x0400000D RID: 13
		public Cell _cell_center2;

		// Token: 0x0400000E RID: 14
		public Cell _cell_header1;

		// Token: 0x0400000F RID: 15
		public CheckBoxBackColorAlternate _checkBox_Normal1;

		// Token: 0x04000010 RID: 16
		public CheckBoxBackColorAlternate _checkBox_Normal2;

		// Token: 0x04000011 RID: 17
		public static HccRepHisModule _instance;

		// Token: 0x04000012 RID: 18
		private Tab_RepairHistory _tab_RepairHistory;
	}
}
