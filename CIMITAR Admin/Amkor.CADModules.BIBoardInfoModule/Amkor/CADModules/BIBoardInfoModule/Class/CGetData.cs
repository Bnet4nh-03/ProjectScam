using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using Amkor.CADModules.BIBoardInfoModule.CIMitarAdminWS;
using DATA;

namespace Amkor.CADModules.BIBoardInfoModule.Class
{
	// Token: 0x02000031 RID: 49
	internal class CGetData
	{
		// Token: 0x06000191 RID: 401 RVA: 0x00023698 File Offset: 0x00021898
		public CGetData(string url)
		{
			this._url = url;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000236B4 File Offset: 0x000218B4
		public ArrayList GetDevice()
		{
			ArrayList arrayList = new ArrayList();
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_DEV'";
			dataSet = this.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text = dataSet.Tables[0].Rows[i]["device"].ToString();
					if (text != "")
					{
						arrayList.Add(text);
					}
				}
			}
			return arrayList;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00023764 File Offset: 0x00021964
		public SortedList GetBIBoardSocketInfo(string targetDevice)
		{
			SortedList sortedList = new SortedList();
			new SortedList();
			SortedList result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_ALL', @device = '" + targetDevice + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string key = dataSet.Tables[0].Rows[i]["barcode"].ToString();
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
						cbiboardSocketInfo.strBad_sock = dataSet.Tables[0].Rows[i]["bad_sock"].ToString();
						cbiboardSocketInfo.strBentPins = dataSet.Tables[0].Rows[i]["bent_pins"].ToString();
						cbiboardSocketInfo.strStuckPins = dataSet.Tables[0].Rows[i]["stuck_pins"].ToString();
						cbiboardSocketInfo.strMeltedPins = dataSet.Tables[0].Rows[i]["melted_pins"].ToString();
						cbiboardSocketInfo.strBurntPins = dataSet.Tables[0].Rows[i]["burnt_pins"].ToString();
						cbiboardSocketInfo.strDmgSockHousing = dataSet.Tables[0].Rows[i]["dmg_sock_housing"].ToString();
						cbiboardSocketInfo.strCoverSprDegrad = dataSet.Tables[0].Rows[i]["cover_spr_degrad"].ToString();
						cbiboardSocketInfo.strHeaterCable = dataSet.Tables[0].Rows[i]["heater_cable"].ToString();
						cbiboardSocketInfo.strDterCardSetCond = dataSet.Tables[0].Rows[i]["dter_card_set_cond"].ToString();
						cbiboardSocketInfo.strFuncTest = dataSet.Tables[0].Rows[i]["func_test"].ToString();
						cbiboardSocketInfo.strRemark = dataSet.Tables[0].Rows[i]["remark"].ToString();
						cbiboardSocketInfo.dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString());
						if (!sortedList.ContainsKey(key))
						{
							sortedList.Add(key, new CBIBoardInfo
							{
								iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString()),
								strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString(),
								strBibNo = dataSet.Tables[0].Rows[i]["bibNo"].ToString(),
								strDevice = dataSet.Tables[0].Rows[i]["device"].ToString(),
								strCustomer = dataSet.Tables[0].Rows[i]["customer"].ToString(),
								strBad_bib = dataSet.Tables[0].Rows[i]["bad_bib"].ToString(),
								dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString()),
								cSocketInfos = new List<CBIBoardSocketInfo>(),
								cSocketInfos = 
								{
									cbiboardSocketInfo
								}
							});
						}
						else
						{
							((CBIBoardInfo)sortedList[key]).cSocketInfos.Add(cbiboardSocketInfo);
						}
					}
				}
				this.MakeDataTable(sortedList);
				result = sortedList;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00023DBC File Offset: 0x00021FBC
		public SortedList GetBIBoardSocketInfo_One(string targetBoardNo)
		{
			SortedList sortedList = new SortedList();
			new SortedList();
			SortedList result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_ONE_BOARD', @boardNo = '" + targetBoardNo + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string key = dataSet.Tables[0].Rows[i]["barcode"].ToString();
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
						cbiboardSocketInfo.strBad_sock = dataSet.Tables[0].Rows[i]["bad_sock"].ToString();
						cbiboardSocketInfo.strBentPins = dataSet.Tables[0].Rows[i]["bent_pins"].ToString();
						cbiboardSocketInfo.strStuckPins = dataSet.Tables[0].Rows[i]["stuck_pins"].ToString();
						cbiboardSocketInfo.strMeltedPins = dataSet.Tables[0].Rows[i]["melted_pins"].ToString();
						cbiboardSocketInfo.strBurntPins = dataSet.Tables[0].Rows[i]["burnt_pins"].ToString();
						cbiboardSocketInfo.strDmgSockHousing = dataSet.Tables[0].Rows[i]["dmg_sock_housing"].ToString();
						cbiboardSocketInfo.strCoverSprDegrad = dataSet.Tables[0].Rows[i]["cover_spr_degrad"].ToString();
						cbiboardSocketInfo.strHeaterCable = dataSet.Tables[0].Rows[i]["heater_cable"].ToString();
						cbiboardSocketInfo.strDterCardSetCond = dataSet.Tables[0].Rows[i]["dter_card_set_cond"].ToString();
						cbiboardSocketInfo.strFuncTest = dataSet.Tables[0].Rows[i]["func_test"].ToString();
						cbiboardSocketInfo.strRemark = dataSet.Tables[0].Rows[i]["remark"].ToString();
						cbiboardSocketInfo.dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString());
						if (!sortedList.ContainsKey(key))
						{
							sortedList.Add(key, new CBIBoardInfo
							{
								iId = int.Parse(dataSet.Tables[0].Rows[i]["id"].ToString()),
								strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString(),
								strBibNo = dataSet.Tables[0].Rows[i]["bibNo"].ToString(),
								strDevice = dataSet.Tables[0].Rows[i]["device"].ToString(),
								strCustomer = dataSet.Tables[0].Rows[i]["customer"].ToString(),
								strBad_bib = dataSet.Tables[0].Rows[i]["bad_bib"].ToString(),
								dtInTime = DateTime.Parse(dataSet.Tables[0].Rows[i]["intime"].ToString()),
								cSocketInfos = new List<CBIBoardSocketInfo>(),
								cSocketInfos = 
								{
									cbiboardSocketInfo
								}
							});
						}
						else
						{
							((CBIBoardInfo)sortedList[key]).cSocketInfos.Add(cbiboardSocketInfo);
						}
					}
				}
				this.MakeDataTable(sortedList);
				result = sortedList;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00024414 File Offset: 0x00022614
		public void MakeDataTable(SortedList slBoards)
		{
			foreach (object obj in slBoards)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				dictionaryEntry.Key.ToString();
				CBIBoardInfo cbiboardInfo = (CBIBoardInfo)dictionaryEntry.Value;
				cbiboardInfo.dataTSocket = new DataTable(cbiboardInfo.strBibNo);
				string text = "Category";
				cbiboardInfo.dataTSocket.Columns.Add(text, typeof(string));
				int num = Enum.GetNames(typeof(CGetData.idxNo)).Length;
				for (int i = 0; i < num; i++)
				{
					cbiboardInfo.dataTSocket.Rows.Add(new object[0]);
				}
				cbiboardInfo.dataTSocket.Rows[0][text] = "MISSING CAP";
				cbiboardInfo.dataTSocket.Rows[1][text] = "MISSING RESISTOR";
				cbiboardInfo.dataTSocket.Rows[2][text] = "MISSING IC";
				cbiboardInfo.dataTSocket.Rows[3][text] = "DAMAGE CAP";
				cbiboardInfo.dataTSocket.Rows[4][text] = "DAMAGE RESISTOR";
				cbiboardInfo.dataTSocket.Rows[5][text] = "DAMAGE IC";
				cbiboardInfo.dataTSocket.Rows[6][text] = "BAD SOCKET";
				cbiboardInfo.dataTSocket.Rows[7][text] = "BENT PINS";
				cbiboardInfo.dataTSocket.Rows[8][text] = "STUCK PINS";
				cbiboardInfo.dataTSocket.Rows[9][text] = "MELTED PINS";
				cbiboardInfo.dataTSocket.Rows[10][text] = "BURNT PINS";
				cbiboardInfo.dataTSocket.Rows[11][text] = "DMG SOCK HOUSING";
				cbiboardInfo.dataTSocket.Rows[12][text] = "COVER SPR DEGRAD";
				cbiboardInfo.dataTSocket.Rows[13][text] = "HEATER CABLE";
				cbiboardInfo.dataTSocket.Rows[14][text] = "DTER CARD SET COND";
				cbiboardInfo.dataTSocket.Rows[15][text] = "FUNC TEST";
				cbiboardInfo.dataTSocket.Rows[16][text] = "REMARK";
				cbiboardInfo.cSocketInfos = (from o in cbiboardInfo.cSocketInfos
				orderby o.iSocketNo
				select o).ToList<CBIBoardSocketInfo>();
				foreach (CBIBoardSocketInfo cbiboardSocketInfo in cbiboardInfo.cSocketInfos)
				{
					int iSocketNo = cbiboardSocketInfo.iSocketNo;
					if (iSocketNo == 1000)
					{
						text = "Other";
					}
					else
					{
						text = "Socket " + iSocketNo.ToString();
					}
					if (!cbiboardInfo.dataTSocket.Columns.Contains(text))
					{
						cbiboardInfo.dataTSocket.Columns.Add(text, typeof(string));
					}
					cbiboardInfo.dataTSocket.Rows[0][text] = cbiboardSocketInfo.strCap_Miss;
					cbiboardInfo.dataTSocket.Rows[1][text] = cbiboardSocketInfo.strResistor_Miss;
					cbiboardInfo.dataTSocket.Rows[2][text] = cbiboardSocketInfo.strIc_Miss;
					cbiboardInfo.dataTSocket.Rows[3][text] = cbiboardSocketInfo.strCap_Dmg;
					cbiboardInfo.dataTSocket.Rows[4][text] = cbiboardSocketInfo.strResistor_Dmg;
					cbiboardInfo.dataTSocket.Rows[5][text] = cbiboardSocketInfo.strIc_Dmg;
					if (text != "Other")
					{
						if (cbiboardSocketInfo.strBad_sock == "0")
						{
							cbiboardInfo.dataTSocket.Rows[6][text] = "";
						}
						else
						{
							cbiboardInfo.dataTSocket.Rows[6][text] = "BAD";
						}
						if (cbiboardSocketInfo.strBentPins == "0")
						{
							cbiboardInfo.dataTSocket.Rows[7][text] = "";
						}
						else
						{
							cbiboardInfo.dataTSocket.Rows[7][text] = "BAD";
						}
						if (cbiboardSocketInfo.strStuckPins == "0")
						{
							cbiboardInfo.dataTSocket.Rows[8][text] = "";
						}
						else
						{
							cbiboardInfo.dataTSocket.Rows[8][text] = "BAD";
						}
						if (cbiboardSocketInfo.strMeltedPins == "0")
						{
							cbiboardInfo.dataTSocket.Rows[9][text] = "";
						}
						else
						{
							cbiboardInfo.dataTSocket.Rows[9][text] = "BAD";
						}
						if (cbiboardSocketInfo.strBurntPins == "0")
						{
							cbiboardInfo.dataTSocket.Rows[10][text] = "";
						}
						else
						{
							cbiboardInfo.dataTSocket.Rows[10][text] = "BAD";
						}
						if (cbiboardSocketInfo.strDmgSockHousing == "0")
						{
							cbiboardInfo.dataTSocket.Rows[11][text] = "";
						}
						else
						{
							cbiboardInfo.dataTSocket.Rows[11][text] = "BAD";
						}
						cbiboardInfo.dataTSocket.Rows[12][text] = cbiboardSocketInfo.strCoverSprDegrad;
						cbiboardInfo.dataTSocket.Rows[13][text] = cbiboardSocketInfo.strHeaterCable;
						cbiboardInfo.dataTSocket.Rows[14][text] = cbiboardSocketInfo.strDterCardSetCond;
						cbiboardInfo.dataTSocket.Rows[15][text] = cbiboardSocketInfo.strFuncTest;
						cbiboardInfo.dataTSocket.Rows[16][text] = cbiboardSocketInfo.strRemark;
					}
					else
					{
						cbiboardInfo.dataTSocket.Rows[6][text] = "";
						cbiboardInfo.dataTSocket.Rows[7][text] = "";
						cbiboardInfo.dataTSocket.Rows[8][text] = "";
						cbiboardInfo.dataTSocket.Rows[9][text] = "";
						cbiboardInfo.dataTSocket.Rows[10][text] = "";
						cbiboardInfo.dataTSocket.Rows[11][text] = "";
						cbiboardInfo.dataTSocket.Rows[12][text] = "";
						cbiboardInfo.dataTSocket.Rows[13][text] = "";
						cbiboardInfo.dataTSocket.Rows[14][text] = "";
						cbiboardInfo.dataTSocket.Rows[15][text] = "";
						cbiboardInfo.dataTSocket.Rows[16][text] = "";
					}
				}
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00024C38 File Offset: 0x00022E38
		public DataTable GetSummary(string targetDevice)
		{
			Hashtable hashtable = new Hashtable();
			DataTable result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_SUM_TTL2', @device = '" + targetDevice + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					DataTable dataTable = dataSet.Tables[0].Copy();
					dataTable.TableName = "Summary_PM";
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							string key = dataSet.Tables[0].Rows[i]["BIB#"].ToString();
							hashtable.Add(key, i);
						}
					}
					if (this._slSockBadInfo == null)
					{
						this._slSockBadInfo = this.GetSockBad(targetDevice);
					}
					this.AddSockBad2SumDt(dataTable, this._slSockBadInfo, hashtable);
					CTotalInfo ctotalInfo = null;
					if (dataSet.Tables[1].Rows.Count > 0)
					{
						for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
						{
							ctotalInfo = new CTotalInfo();
							ctotalInfo.iTotal_Cnt = int.Parse(dataSet.Tables[1].Rows[j]["total_C"].ToString());
							ctotalInfo.iTotal_MissCap = int.Parse(dataSet.Tables[1].Rows[j]["total_MC"].ToString());
							ctotalInfo.iTotal_MissRstr = int.Parse(dataSet.Tables[1].Rows[j]["total_MR"].ToString());
							ctotalInfo.iTotal_MissIc = int.Parse(dataSet.Tables[1].Rows[j]["total_MI"].ToString());
							ctotalInfo.iTotal_DmgCap = int.Parse(dataSet.Tables[1].Rows[j]["total_DC"].ToString());
							ctotalInfo.iTotal_DmgRstr = int.Parse(dataSet.Tables[1].Rows[j]["total_DR"].ToString());
							ctotalInfo.iTotal_DmgIc = int.Parse(dataSet.Tables[1].Rows[j]["total_DI"].ToString());
							ctotalInfo.iTotal_BadBIB = int.Parse(dataSet.Tables[1].Rows[j]["total_BB"].ToString());
							ctotalInfo.iTotal_GoodBIB = ctotalInfo.iTotal_Cnt - ctotalInfo.iTotal_BadBIB;
							ctotalInfo.iTotal_TotalSock = ctotalInfo.iTotal_Cnt * int.Parse(dataSet.Tables[1].Rows[j]["total_SOCK"].ToString());
							ctotalInfo.iTotal_BadSock = int.Parse(dataSet.Tables[1].Rows[j]["total_BS"].ToString());
							ctotalInfo.iTotal_GoodSock = ctotalInfo.iTotal_TotalSock - ctotalInfo.iTotal_BadSock;
							ctotalInfo.iTotal_BS_HeaterOut = int.Parse(dataSet.Tables[1].Rows[j]["total_BS_HEARTER_OUT"].ToString());
							ctotalInfo.iTotal_BS_SensorOut = int.Parse(dataSet.Tables[1].Rows[j]["total_BS_SENSOR_OUT"].ToString());
							ctotalInfo.iTotal_BS_ETC = int.Parse(dataSet.Tables[1].Rows[j]["total_BS_ETC"].ToString());
						}
					}
					this.AddTotalSum2Dt(dataTable, ctotalInfo, this._slSockBadInfo);
					result = dataTable;
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

		// Token: 0x06000197 RID: 407 RVA: 0x00025090 File Offset: 0x00023290
		public DataTable GetSummary_BIB(string targetDevice)
		{
			new Hashtable();
			DataTable result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_SUM_BIB', @device = '" + targetDevice + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					DataTable dataTable = dataSet.Tables[0].Copy();
					dataTable.TableName = "Summary_BIB";
					result = dataTable;
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

		// Token: 0x06000198 RID: 408 RVA: 0x00025110 File Offset: 0x00023310
		private SortedList GetSockBad(string targetDevice)
		{
			SortedList sortedList = new SortedList();
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_SOCK_BAD', @device = '" + targetDevice + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						dataSet.Tables[0].Rows[i]["barcode"].ToString();
						string key = dataSet.Tables[0].Rows[i]["bibNo"].ToString();
						dataSet.Tables[0].Rows[i]["socketNo"].ToString();
						dataSet.Tables[0].Rows[i]["bad_sock"].ToString();
						string strBadSocketStatus = dataSet.Tables[0].Rows[i]["bad_socket_status"].ToString();
						CSockBadInfo csockBadInfo = new CSockBadInfo();
						csockBadInfo.iSocketNo = int.Parse(dataSet.Tables[0].Rows[i]["socketNo"].ToString());
						csockBadInfo.iBad = int.Parse(dataSet.Tables[0].Rows[i]["bad_sock"].ToString());
						csockBadInfo.strBadSocketStatus = strBadSocketStatus;
						if (!sortedList.ContainsKey(key))
						{
							sortedList.Add(key, new List<CSockBadInfo>
							{
								csockBadInfo
							});
						}
						else
						{
							((List<CSockBadInfo>)sortedList[key]).Add(csockBadInfo);
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return sortedList;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0002531C File Offset: 0x0002351C
		public DataTable GetPMHistory(string targetDevice)
		{
			new Hashtable();
			DataTable result;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [CIMitar_HCC].[dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_PM_HISTORY', @device = '" + targetDevice + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0)
				{
					DataTable dataTable = dataSet.Tables[0].Copy();
					dataTable.TableName = "PM_History";
					result = dataTable;
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

		// Token: 0x0600019A RID: 410 RVA: 0x0002539C File Offset: 0x0002359C
		private void AddSockBad2SumDt(DataTable dtSum, SortedList slSockBadInfo, Hashtable htBibOrder)
		{
			foreach (object obj in slSockBadInfo)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string key = dictionaryEntry.Key.ToString();
				int index = (int)htBibOrder[key];
				foreach (CSockBadInfo csockBadInfo in (from o in (List<CSockBadInfo>)dictionaryEntry.Value
				orderby o.iSocketNo
				select o).ToList<CSockBadInfo>())
				{
					string text = string.Empty;
					string empty = string.Empty;
					if (csockBadInfo.iSocketNo == 1000)
					{
						text = "Other";
					}
					else
					{
						text = "Socket " + csockBadInfo.iSocketNo.ToString();
					}
					if (!dtSum.Columns.Contains(text))
					{
						dtSum.Columns.Add(text);
					}
					if (csockBadInfo.iBad == 1)
					{
						dtSum.Rows[index][text] = csockBadInfo.strBadSocketStatus;
					}
					else
					{
						dtSum.Rows[index][text] = "";
					}
				}
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00025530 File Offset: 0x00023730
		private void AddTotalSum2Dt(DataTable dtSum, CTotalInfo totalInfo, SortedList slSockBadInfo)
		{
			int count = dtSum.Rows.Count;
			int count2 = dtSum.Rows.Count;
			for (int i = 0; i < 3; i++)
			{
				dtSum.Rows.Add(new object[0]);
			}
			dtSum.Rows[count]["BIB#"] = "Total_Good";
			dtSum.Rows[count]["MISSING_CAP"] = 0;
			dtSum.Rows[count]["MISSING_RESISTOR"] = 0;
			dtSum.Rows[count]["MISSING_IC"] = 0;
			dtSum.Rows[count]["DAMAGE_CAP"] = 0;
			dtSum.Rows[count]["DAMAGE_RESISTOR"] = 0;
			dtSum.Rows[count]["DAMAGE_IC"] = 0;
			dtSum.Rows[count]["UPDATE_DATE"] = "";
			dtSum.Rows[count]["BAD_BIB"] = totalInfo.iTotal_GoodBIB;
			dtSum.Rows[count]["BAD_SOCKET"] = totalInfo.iTotal_GoodSock;
			dtSum.Rows[count]["WARRANTY"] = "";
			dtSum.Rows[count]["GOLD_TAB"] = "";
			dtSum.Rows[count + 1]["BIB#"] = "Total_Bad";
			dtSum.Rows[count + 1]["MISSING_CAP"] = totalInfo.iTotal_MissCap;
			dtSum.Rows[count + 1]["MISSING_RESISTOR"] = totalInfo.iTotal_MissRstr;
			dtSum.Rows[count + 1]["MISSING_IC"] = totalInfo.iTotal_MissIc;
			dtSum.Rows[count + 1]["DAMAGE_CAP"] = totalInfo.iTotal_DmgCap;
			dtSum.Rows[count + 1]["DAMAGE_RESISTOR"] = totalInfo.iTotal_DmgRstr;
			dtSum.Rows[count + 1]["DAMAGE_IC"] = totalInfo.iTotal_DmgIc;
			dtSum.Rows[count + 1]["UPDATE_DATE"] = "";
			dtSum.Rows[count + 1]["BAD_BIB"] = totalInfo.iTotal_BadBIB;
			dtSum.Rows[count + 1]["BAD_SOCKET"] = totalInfo.iTotal_BadSock;
			dtSum.Rows[count + 1]["BS_HEARTER_OUT"] = totalInfo.iTotal_BS_HeaterOut;
			dtSum.Rows[count + 1]["BS_SENSOR_OUT"] = totalInfo.iTotal_BS_SensorOut;
			dtSum.Rows[count + 1]["BS_ETC"] = totalInfo.iTotal_BS_ETC;
			dtSum.Rows[count + 1]["WARRANTY"] = "";
			dtSum.Rows[count + 1]["GOLD_TAB"] = "";
			dtSum.Rows[count + 2]["BIB#"] = "Total";
			dtSum.Rows[count + 2]["MISSING_CAP"] = totalInfo.iTotal_MissCap;
			dtSum.Rows[count + 2]["MISSING_RESISTOR"] = totalInfo.iTotal_MissRstr;
			dtSum.Rows[count + 2]["MISSING_IC"] = totalInfo.iTotal_MissIc;
			dtSum.Rows[count + 2]["DAMAGE_CAP"] = totalInfo.iTotal_DmgCap;
			dtSum.Rows[count + 2]["DAMAGE_RESISTOR"] = totalInfo.iTotal_DmgRstr;
			dtSum.Rows[count + 2]["DAMAGE_IC"] = totalInfo.iTotal_DmgIc;
			dtSum.Rows[count + 2]["UPDATE_DATE"] = "";
			dtSum.Rows[count + 2]["BAD_BIB"] = totalInfo.iTotal_Cnt;
			dtSum.Rows[count + 2]["BAD_SOCKET"] = totalInfo.iTotal_TotalSock;
			dtSum.Rows[count + 2]["WARRANTY"] = "";
			dtSum.Rows[count + 2]["GOLD_TAB"] = "";
			SortedList sortedList = new SortedList();
			foreach (object obj in slSockBadInfo)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				dictionaryEntry.Key.ToString();
				foreach (CSockBadInfo csockBadInfo in (from o in (List<CSockBadInfo>)dictionaryEntry.Value
				orderby o.iSocketNo
				select o).ToList<CSockBadInfo>())
				{
					string key = string.Empty;
					string empty = string.Empty;
					if (csockBadInfo.iSocketNo != 1000)
					{
						key = "Socket " + csockBadInfo.iSocketNo.ToString();
						if (!sortedList.ContainsKey(key))
						{
							sortedList.Add(key, csockBadInfo.iBad);
						}
						else
						{
							int num = (int)sortedList[key];
							num += csockBadInfo.iBad;
							sortedList[key] = num;
						}
					}
				}
			}
			foreach (object obj2 in sortedList)
			{
				DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
				string columnName = dictionaryEntry2.Key.ToString();
				int num2 = (int)dictionaryEntry2.Value;
				int num3 = count2;
				int num4 = num3 - num2;
				dtSum.Rows[count][columnName] = num4.ToString();
				dtSum.Rows[count + 1][columnName] = num2.ToString();
				dtSum.Rows[count + 2][columnName] = num3.ToString();
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00025C80 File Offset: 0x00023E80
		private DataSet QueryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._url + "CIMitarWebService/CIMitarWS.asmx";
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

		// Token: 0x0400027C RID: 636
		private string _url = string.Empty;

		// Token: 0x0400027D RID: 637
		private SortedList _slSockBadInfo;

		// Token: 0x0200005E RID: 94
		private enum idxNo
		{
			// Token: 0x040002C8 RID: 712
			iMissingCap,
			// Token: 0x040002C9 RID: 713
			iMissingResistor,
			// Token: 0x040002CA RID: 714
			iMissingIc,
			// Token: 0x040002CB RID: 715
			iDamageCap,
			// Token: 0x040002CC RID: 716
			iDamageResistor,
			// Token: 0x040002CD RID: 717
			iDamageIc,
			// Token: 0x040002CE RID: 718
			iBad,
			// Token: 0x040002CF RID: 719
			iBentPins,
			// Token: 0x040002D0 RID: 720
			iStuckPins,
			// Token: 0x040002D1 RID: 721
			iMeltedPins,
			// Token: 0x040002D2 RID: 722
			iBurntPins,
			// Token: 0x040002D3 RID: 723
			iDmgSockHousing,
			// Token: 0x040002D4 RID: 724
			iCoverSprDegrad,
			// Token: 0x040002D5 RID: 725
			iHeaterCable,
			// Token: 0x040002D6 RID: 726
			iDterCardSetCond,
			// Token: 0x040002D7 RID: 727
			iFuncTest,
			// Token: 0x040002D8 RID: 728
			iRemark
		}
	}
}
