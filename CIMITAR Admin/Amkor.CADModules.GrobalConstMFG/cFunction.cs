using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Amkor.CADModules.ManufactureHistory.GrobalConstMFG.Class;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.ManufactureHistory.GrobalConstMFG
{
	// Token: 0x02000009 RID: 9
	public class cFunction
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000022C0 File Offset: 0x000004C0
		public static void setFactory(FactorySettings _factorySetting)
		{
			cFunction._queryMgr = new QueryMgr(_factorySetting);
			string factoryName = _factorySetting._factoryName;
			if (factoryName != null)
			{
				if (factoryName == "ATK")
				{
					cFunction._Factory = "K3";
					return;
				}
				if (factoryName == "ATK_K5")
				{
					cFunction._Factory = "K5";
					return;
				}
				if (factoryName == "ATK_E")
				{
					cFunction._Factory = "K3_E";
					return;
				}
				if (factoryName == "ATK_K5_M")
				{
					cFunction._Factory = "K5_M";
					return;
				}
			}
			cFunction._Factory = "K3";
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002358 File Offset: 0x00000558
		public static string getFactory()
		{
			return cFunction._Factory;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002370 File Offset: 0x00000570
		public static void getCategoryList(FactorySettings _factorySetting, string Plant, ComboBox cb, bool needAll)
		{
			if (cb != null)
			{
				cb.Items.Clear();
				if (needAll)
				{
					cb.Items.Add("All");
				}
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintCategory] @Plant=N'" + Plant + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				cConst.clearCategory();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text = dataSet.Tables[0].Rows[i]["CategoryName"].ToString();
					if (cb != null)
					{
						cb.Items.Add(text.Trim());
					}
					cConst.addCategory(text.Trim());
				}
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002474 File Offset: 0x00000674
		public static void getCustList(FactorySettings _factorySetting, ComboBox cb, bool needAll)
		{
			cFunction._queryMgr = new QueryMgr(_factorySetting);
			if (cb != null)
			{
				cb.Items.Clear();
				if (needAll)
				{
					cb.Items.Add("All");
				}
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMfgCust]";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				cConst.clearCategory();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string str = dataSet.Tables[0].Rows[i]["customercode"].ToString();
					string text = dataSet.Tables[0].Rows[i]["customername"].ToString();
					text = text + "(" + str + ")";
					if (cb != null && !cb.Items.Contains(text))
					{
						cb.Items.Add(text.Trim());
					}
				}
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000025C0 File Offset: 0x000007C0
		public static void getNickNameList(FactorySettings _factorySetting, string cust, ComboBox cb, bool needAll)
		{
			cFunction._queryMgr = new QueryMgr(_factorySetting);
			if (cb != null)
			{
				cb.Items.Clear();
				if (needAll)
				{
					cb.Items.Add("All");
				}
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMfgNickName] @_customercode=N'" + cust + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				cConst.clearCategory();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text = dataSet.Tables[0].Rows[i]["productname"].ToString();
					if (cb != null && !cb.Items.Contains(text))
					{
						cb.Items.Add(text.Trim());
					}
				}
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000026D4 File Offset: 0x000008D4
		public static void getCategoryListAll(FactorySettings _factorySetting, string Plant, List<ComboBox> list, bool needAll)
		{
			cFunction._queryMgr = new QueryMgr(_factorySetting);
			foreach (ComboBox comboBox in list)
			{
				comboBox.Items.Clear();
			}
			if (needAll)
			{
				foreach (ComboBox comboBox in list)
				{
					comboBox.Items.Add("All");
				}
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintCategory] @Plant=N'" + Plant + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text = dataSet.Tables[0].Rows[i]["CategoryName"].ToString();
					foreach (ComboBox comboBox in list)
					{
						comboBox.Items.Add(text.Trim());
					}
					cConst.addCategory(text.Trim());
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002894 File Offset: 0x00000A94
		public static void getCaseList(ComboBox cb, bool needAll)
		{
			cb.Items.Clear();
			if (needAll)
			{
				cb.Items.Add("All");
			}
			cb.Items.Add("HARDWARE");
			cb.Items.Add("SOFTWARE");
			cb.Items.Add("OTHER");
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000028FC File Offset: 0x00000AFC
		public static void getFactorList(FactorySettings _factorySetting, ComboBox cb, string category, int plant, Dictionary<string, string> factorlist, bool needAll)
		{
			cFunction._queryMgr = new QueryMgr(_factorySetting);
			factorlist.Clear();
			if (cb != null)
			{
				cb.Items.Clear();
				if (needAll)
				{
					cb.Items.Add("All");
				}
			}
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintFactorList]";
			if (plant == 0)
			{
				text += "@_plant=N'K3'";
			}
			else if (plant == 2)
			{
				text += "@_plant=N'K5'";
			}
			else if (plant == 3)
			{
				text += "@_plant=N'K3_E'";
			}
			else if (plant == 4)
			{
				text += "@_plant=N'K5_M'";
			}
			text = text + ", @_category=N'" + category.Trim() + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(text);
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					if (!factorlist.ContainsKey(dataSet.Tables[0].Rows[i]["factor"].ToString()))
					{
						factorlist.Add(dataSet.Tables[0].Rows[i]["factor"].ToString(), dataSet.Tables[0].Rows[i]["case"].ToString());
					}
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public static void setPlant(ComboBox cb, FactorySettings _factorySetting)
		{
			cb.Items.Clear();
			if (_factorySetting != null && _factorySetting._factoryName == "ATK_E")
			{
				foreach (string text in cConst.sPlant)
				{
					if (!(text != "K3_E"))
					{
						cb.Items.Add(text);
					}
				}
			}
			else if (_factorySetting != null && _factorySetting._factoryName == "ATK_K5_M")
			{
				foreach (string text in cConst.sPlant)
				{
					if (!(text != "K5_M"))
					{
						cb.Items.Add(text);
					}
				}
			}
			else
			{
				foreach (string text in cConst.sPlant)
				{
					if (!(text == "K4") && !(text == "K3_E") && !(text == "K5_M"))
					{
						cb.Items.Add(text);
					}
				}
			}
			cb.SelectedIndex = -1;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002C04 File Offset: 0x00000E04
		public static void setPlant(FactorySettings factorySetting, TreeView tv)
		{
			tv.LabelEdit = false;
			tv.Nodes.Clear();
			if (factorySetting != null && factorySetting._factoryName == "ATK_E")
			{
				foreach (string text in cConst.sPlant)
				{
					if (text == "K3_E")
					{
						tv.Nodes.Add(text, text);
					}
				}
			}
			else if (factorySetting != null && factorySetting._factoryName == "ATK_K5_M")
			{
				foreach (string text in cConst.sPlant)
				{
					if (text == "K5_M")
					{
						tv.Nodes.Add(text, text);
					}
				}
			}
			else
			{
				foreach (string text in cConst.sPlant)
				{
					tv.Nodes.Add(text, text);
				}
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002D20 File Offset: 0x00000F20
		public static Dictionary<string, Dictionary<string, EquipmentInfo>> getEquipmentList(FactorySettings _factorySetting, bool needAll)
		{
			Dictionary<string, Dictionary<string, EquipmentInfo>> dictionary = new Dictionary<string, Dictionary<string, EquipmentInfo>>();
			foreach (string text in cConst.sPlant)
			{
				foreach (string text2 in cConst.sCategory)
				{
					string text3 = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMachineList]";
					text3 = text3 + "@_plant=N'" + text + "'";
					text3 = text3 + ", @SearchType=N'" + text2 + "'";
					DataSet dataSet = cFunction._queryMgr.queryCall(text3);
					if (dataSet != null && dataSet.Tables.Count != 0)
					{
						Dictionary<string, EquipmentInfo> dictionary2 = new Dictionary<string, EquipmentInfo>();
						EquipmentInfo value = new EquipmentInfo();
						if (!dictionary.ContainsKey(text))
						{
							dictionary2.Add(text2, value);
							dictionary.Add(text, dictionary2);
						}
						else
						{
							dictionary2.Add(text2, value);
							dictionary[text].Add(text2, value);
						}
						for (int j = 0; j < dataSet.Tables[dataSet.Tables.Count - 1].Rows.Count; j++)
						{
							string model = dataSet.Tables[0].Rows[j]["Model"].ToString();
							string equipment = dataSet.Tables[0].Rows[j]["Name"].ToString();
							foreach (KeyValuePair<string, Dictionary<string, EquipmentInfo>> keyValuePair in dictionary)
							{
								if (keyValuePair.Key == text)
								{
									foreach (KeyValuePair<string, EquipmentInfo> keyValuePair2 in keyValuePair.Value)
									{
										if (keyValuePair2.Key == text2)
										{
											keyValuePair2.Value.setInfo(model, equipment);
										}
									}
								}
							}
						}
					}
				}
			}
			return dictionary;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002FEC File Offset: 0x000011EC
		public static bool getHCCInfo(string content, string location, out string type, out string nickname, out string hccid, out string boardid, out string device)
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintHCCInfo] @_Content=N'",
				content,
				"', @_Location=N'",
				location,
				"'"
			});
			type = string.Empty;
			nickname = string.Empty;
			hccid = string.Empty;
			boardid = string.Empty;
			device = string.Empty;
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				int num = 0;
				if (num < dataSet.Tables[0].Rows.Count)
				{
					if (dataSet.Tables[0].Columns.Contains("typedesc"))
					{
						type = dataSet.Tables[0].Rows[num]["typedesc"].ToString().Trim();
					}
					if (dataSet.Tables[0].Columns.Contains("nickname"))
					{
						nickname = dataSet.Tables[0].Rows[num]["nickname"].ToString().Trim();
					}
					if (dataSet.Tables[0].Columns.Contains("id"))
					{
						hccid = dataSet.Tables[0].Rows[num]["id"].ToString().Trim();
					}
					if (dataSet.Tables[0].Columns.Contains("boardno"))
					{
						boardid = dataSet.Tables[0].Rows[num]["boardno"].ToString().Trim();
					}
					if (string.IsNullOrEmpty(nickname.Trim()))
					{
						if (dataSet.Tables[0].Columns.Contains("device"))
						{
							device = dataSet.Tables[0].Rows[num]["device"].ToString().Trim();
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003270 File Offset: 0x00001470
		public static DataSet getMachineNumber(string category)
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMachineList] @_Plant = '",
				cFunction._Factory,
				"', @SearchType = '",
				category,
				"'"
			});
			return cFunction._queryMgr.queryCall(sQuery);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000032C4 File Offset: 0x000014C4
		public static DataSet getOperation()
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintOperation] @_Factory=N'" + cFunction._Factory + "'";
			return cFunction._queryMgr.queryCall(sQuery);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000032F8 File Offset: 0x000014F8
		public static bool setOperation(int operationcode, string operationname, out string error)
		{
			error = string.Empty;
			string sQuery = string.Concat(new object[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintOperation]@_Command=N'INSERT', @_OperationCode= ",
				operationcode,
				", @_OperationName=N'",
				operationname,
				"',@_Facotry=N'",
				cFunction._Factory,
				"'"
			});
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					if (dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK")
					{
						return true;
					}
				}
			}
			error = dataSet.Tables[0].Rows[0][0].ToString().ToUpper();
			return false;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003410 File Offset: 0x00001610
		public static bool deleteOperation(int operationcode, string operationname, out string error)
		{
			error = string.Empty;
			string sQuery = string.Concat(new object[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintOperation]@_Command=N'DELETE', @_OperationCode= ",
				operationcode,
				", @_OperationName=N'",
				operationname,
				"',@_Facotry=N'",
				cFunction._Factory,
				"'"
			});
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					if (dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK")
					{
						return true;
					}
				}
			}
			error = dataSet.Tables[0].Rows[0][0].ToString().ToUpper();
			return false;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003528 File Offset: 0x00001728
		public static int getReportCount(string report)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMfgListCount] @date=N'" + report + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				if (dataSet.Tables[dataSet.Tables.Count - 1].Rows.Count > 0)
				{
					string value = dataSet.Tables[dataSet.Tables.Count - 1].Rows[0][0].ToString();
					return Convert.ToInt32(value);
				}
			}
			return 0;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000035E0 File Offset: 0x000017E0
		public static bool sendReport(string id, string name, string team, ReportInfo reportInfo, out string error, bool edit)
		{
			error = string.Empty;
			bool result;
			if (reportInfo == null)
			{
				result = false;
			}
			else
			{
				string text = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMfgHistory] @_ReportName=N'",
					reportInfo.Title,
					"', @_Factory=N'",
					cFunction._Factory,
					"', @_Category=N'",
					reportInfo.Category,
					"', @_Equipment=N'",
					reportInfo.Equipment,
					"', @_Model=N'",
					reportInfo.Model,
					"', @_RscDec=N'",
					reportInfo.RscDec,
					"', @_CustName=N'",
					reportInfo.CustName,
					"', @_NickName=N'",
					reportInfo.NickName,
					"', @_id=N'",
					id,
					"', @_Team=N'",
					team,
					"', @_Name=N'",
					name,
					"', @_FileList=N'",
					reportInfo.FileList,
					"', @_Content1=N'",
					reportInfo.content.Trim().Replace("'", "''"),
					"', @_Content2=N'",
					reportInfo.content2.Trim().Replace("'", "''"),
					"', @_binary1=N'",
					Convert.ToBase64String(reportInfo.binary),
					"', @_binary2=N''"
				});
				if (!edit)
				{
					text += ", @_Command=N'INSERT'";
					text = text + ", @_datetime=N'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + ":00'";
					text = text + ", @_Operation=" + reportInfo.Operation.Substring(reportInfo.Operation.IndexOf("(") + 1, reportInfo.Operation.IndexOf(")") - reportInfo.Operation.IndexOf("(") - 1);
				}
				else
				{
					text += ", @_Command=N'UPDATE'";
				}
				DataSet dataSet = cFunction._queryMgr.queryCall(text);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					if (dataSet.Tables[dataSet.Tables.Count - 1].Rows.Count > 0)
					{
						if (dataSet.Tables[dataSet.Tables.Count - 1].Rows[0][0].ToString().ToUpper() == "OK")
						{
							dataSet.Dispose();
							return true;
						}
					}
				}
				if (dataSet.Tables.Count > 0)
				{
					error = dataSet.Tables[dataSet.Tables.Count - 1].Rows[0][0].ToString().ToUpper();
				}
				else
				{
					error = "FAIL,CONTACT TO TFA.";
				}
				dataSet.Dispose();
				result = false;
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000391C File Offset: 0x00001B1C
		public static void setCategoryListBox(ListBox listbox)
		{
			if (listbox != null)
			{
				listbox.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintCategory] @Plant=N'" + cFunction._Factory + "'";
				DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string item = dataSet.Tables[0].Rows[i]["CategoryName"].ToString();
						listbox.Items.Add(item);
					}
				}
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000039E4 File Offset: 0x00001BE4
		public static void setCustListListBox(ListBox listbox, bool needAll)
		{
			if (listbox != null)
			{
				listbox.Items.Clear();
				if (needAll)
				{
					listbox.Items.Add("(All)");
				}
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMfgCust]";
				DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					cConst.clearCategory();
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string str = dataSet.Tables[0].Rows[i]["customercode"].ToString();
						string text = dataSet.Tables[0].Rows[i]["customername"].ToString();
						text = text + "(" + str + ")";
						if (listbox != null && !listbox.Items.Contains(text))
						{
							listbox.Items.Add(text.Trim());
						}
					}
				}
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003B28 File Offset: 0x00001D28
		public static void getNickNameListListBox(string cust, ListBox listbox, bool needAll)
		{
			if (listbox != null)
			{
				listbox.Items.Clear();
				if (needAll)
				{
					listbox.Items.Add("(All)");
				}
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMfgNickName] @_customercode=N'" + cust.Substring(cust.IndexOf("(") + 1, cust.IndexOf(")") - cust.IndexOf("(") - 1) + "'";
				DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					cConst.clearCategory();
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string text = dataSet.Tables[0].Rows[i]["productname"].ToString();
						if (listbox != null && !listbox.Items.Contains(text))
						{
							listbox.Items.Add(text.Trim());
						}
					}
				}
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003C5C File Offset: 0x00001E5C
		public static void setOperationListBox(ListBox listbox, bool needAll)
		{
			if (listbox != null)
			{
				listbox.Items.Clear();
				if (needAll)
				{
					listbox.Items.Add("(All)");
				}
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintOperation] @_Factory=N'" + cFunction._Factory + "'";
				DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[dataSet.Tables.Count - 1].Rows.Count; i++)
					{
						string str = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["OperationCode"].ToString();
						string str2 = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["OperationName"].ToString();
						string text = str2 + "(" + str + ")";
						if (!listbox.Items.Contains(text))
						{
							listbox.Items.Add(text);
						}
					}
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003DC0 File Offset: 0x00001FC0
		public static DataSet searchReport(DateTime startdate, DateTime enddate, string category, string model, string equipment, int operation, string custname, string device, string keyword, string shfit)
		{
			string sQuery = string.Concat(new object[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMfgDataSearch] @_startdate = N'",
				startdate.ToString("yyyy-MM-dd HH:mm:ss"),
				"', @_enddate = N'",
				enddate.ToString("yyyy-MM-dd HH:mm:ss"),
				"', @_Factory = N'",
				cFunction._Factory,
				"', @_Category = N'",
				category,
				"', @_Equipment = N'",
				equipment,
				"', @_Model = N'",
				model,
				"', @_Operation =",
				operation,
				", @_CustName = N'",
				custname,
				"', @_NickName= N'",
				device,
				"', @_keyword= N'",
				keyword,
				"', @_Shift=N'",
				shfit,
				"'"
			});
			return cFunction._queryMgr.queryCall(sQuery);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003EB0 File Offset: 0x000020B0
		public static DataSet getReport(string title)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMfgReportInfo] @_Report=N'" + title + "'";
			return cFunction._queryMgr.queryCall(sQuery);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003EE0 File Offset: 0x000020E0
		public static bool setDeleteReport(string report)
		{
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMfgDelete]";
			text = text + " @_ReportName=N'" + report + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(text);
			if (dataSet != null && dataSet.Tables.Count != 0)
			{
				if (dataSet.Tables[0].Rows.Count != 0)
				{
					if (dataSet.Tables[0].Rows[0].ToString().CompareTo("OK") != 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x04000038 RID: 56
		private static QueryMgr _queryMgr;

		// Token: 0x04000039 RID: 57
		private static string _Factory = string.Empty;
	}
}
