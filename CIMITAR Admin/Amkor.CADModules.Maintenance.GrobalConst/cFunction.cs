using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using SevenZip;

namespace Amkor.CADModules.Maintenance.GrobalConst
{
	// Token: 0x02000008 RID: 8
	public class cFunction
	{
		// Token: 0x0600000A RID: 10 RVA: 0x0000224B File Offset: 0x0000044B
		public static void Initialize(FactorySettings factorySettings)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002258 File Offset: 0x00000458
		public static void getCategoryList(FactorySettings factorySettings, string plant, ComboBox cb, bool needAll, bool isPM)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			bool flag = cb != null;
			if (flag)
			{
				cb.Items.Clear();
				if (needAll)
				{
					cb.Items.Add("All");
				}
			}
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintCategory] @Plant=N'" + plant + "'";
			if (isPM)
			{
				text += ", @Mode=1";
			}
			else
			{
				text += ", @Mode=0";
			}
			DataSet dataSet = cFunction._queryMgr.queryCall(text);
			bool flag2 = dataSet != null && dataSet.Tables.Count > 0;
			if (flag2)
			{
				cConst.clearCategory();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text2 = dataSet.Tables[0].Rows[i]["CategoryName"].ToString();
					bool flag3 = cb != null;
					if (flag3)
					{
						cb.Items.Add(text2.Trim());
					}
					cConst.addCategory(text2.Trim());
				}
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002388 File Offset: 0x00000588
		public static void getCategoryListAll(FactorySettings factorySettings, string Plant, List<ComboBox> list, bool needAll)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			foreach (ComboBox comboBox in list)
			{
				comboBox.Items.Clear();
			}
			if (needAll)
			{
				foreach (ComboBox comboBox2 in list)
				{
					comboBox2.Items.Add("All");
				}
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintCategory] @Plant=N'" + Plant + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text = dataSet.Tables[0].Rows[i]["CategoryName"].ToString();
					foreach (ComboBox comboBox3 in list)
					{
						comboBox3.Items.Add(text.Trim());
					}
					cConst.addCategory(text.Trim());
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002538 File Offset: 0x00000738
		public static void getCaseList(ComboBox cb, bool needAll)
		{
			cb.Items.Clear();
			if (needAll)
			{
				cb.Items.Add("All");
			}
			cb.Items.Add("HARDWARE");
			cb.Items.Add("SOFTWARE");
			cb.Items.Add("ELECTRICAL & ELECTRONICS");
			cb.Items.Add("OTHER");
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000025B0 File Offset: 0x000007B0
		public static void getFactorList(FactorySettings factorySettings, ComboBox cb, string category, string factory, Dictionary<string, string> factorlist, bool needAll)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			factorlist.Clear();
			bool flag = cb != null;
			if (flag)
			{
				cb.Items.Clear();
				if (needAll)
				{
					cb.Items.Add("All");
				}
			}
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintFactorList]";
			text = text + " @_plant=N'" + factory + "'";
			text = text + ", @_category=N'" + category.Trim() + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(text);
			bool flag2 = dataSet != null && dataSet.Tables.Count > 0;
			if (flag2)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					bool flag3 = !factorlist.ContainsKey(dataSet.Tables[0].Rows[i]["factor"].ToString());
					if (flag3)
					{
						factorlist.Add(dataSet.Tables[0].Rows[i]["factor"].ToString(), dataSet.Tables[0].Rows[i]["case"].ToString());
					}
				}
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000271C File Offset: 0x0000091C
		public static Dictionary<string, Dictionary<string, List<string>>> getFactorList(FactorySettings factorySettings, SYSTEMTYPE system, string factory, string category)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			Dictionary<string, Dictionary<string, List<string>>> dictionary = new Dictionary<string, Dictionary<string, List<string>>>();
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintFactorList] @_system=" + Convert.ToInt32(system);
			bool flag = factory == "K3" || factory == "ATK";
			if (flag)
			{
				text += ", @_plant=N'K3'";
			}
			else
			{
				bool flag2 = factory == "K5" || factory == "ATK_K5_M";
				if (flag2)
				{
					text += ", @_plant=N'K5'";
				}
				else
				{
					bool flag3 = factory == "K3_E" || factory == "ATK_E";
					if (flag3)
					{
						text += ", @_plant=N'K3_E'";
					}
					else
					{
						bool flag4 = factory == "K5_M" || factory == "ATK_K5_M";
						if (flag4)
						{
							text += ", @_plant=N'K5_M'";
						}
						else
						{
							bool flag5 = factory == "ATV";
							if (flag5)
							{
								text += ", @_plant=N'ATV'";
							}
						}
					}
				}
			}
			text = text + ", @_category=N'" + category.Trim() + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(text);
			bool flag6 = dataSet != null && dataSet.Tables.Count > 0;
			if (flag6)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					bool flag7 = !dictionary.ContainsKey(dataSet.Tables[0].Rows[i]["category"].ToString());
					if (flag7)
					{
						dictionary.Add(dataSet.Tables[0].Rows[i]["category"].ToString(), new Dictionary<string, List<string>>());
						dictionary[dataSet.Tables[0].Rows[i]["category"].ToString()].Add(dataSet.Tables[0].Rows[i]["case"].ToString(), new List<string>());
					}
					bool flag8 = !dictionary[dataSet.Tables[0].Rows[i]["category"].ToString()].ContainsKey(dataSet.Tables[0].Rows[i]["case"].ToString());
					if (flag8)
					{
						dictionary[dataSet.Tables[0].Rows[i]["category"].ToString()].Add(dataSet.Tables[0].Rows[i]["case"].ToString(), new List<string>());
						dictionary[dataSet.Tables[0].Rows[i]["category"].ToString()][dataSet.Tables[0].Rows[i]["case"].ToString()].Add(dataSet.Tables[0].Rows[i]["factor"].ToString());
					}
					else
					{
						dictionary[dataSet.Tables[0].Rows[i]["category"].ToString()][dataSet.Tables[0].Rows[i]["case"].ToString()].Add(dataSet.Tables[0].Rows[i]["factor"].ToString());
					}
				}
			}
			return dictionary;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002B54 File Offset: 0x00000D54
		public static void setPlant(ComboBox cb, string factory)
		{
			cb.Items.Clear();
			bool flag = !string.IsNullOrEmpty(factory) && factory == "ATK_E";
			if (flag)
			{
				cb.Items.Add("K3_E");
			}
			else
			{
				bool flag2 = !string.IsNullOrEmpty(factory) && factory == "ATK_K5_M";
				if (flag2)
				{
					cb.Items.Add("K5_M");
				}
				else
				{
					bool flag3 = !string.IsNullOrEmpty(factory) && factory == "ATK_K5";
					if (flag3)
					{
						cb.Items.Add("K5");
					}
					else
					{
						bool flag4 = !string.IsNullOrEmpty(factory) && factory == "ATV";
						if (flag4)
						{
							cb.Items.Add("ATV");
						}
						else
						{
							cb.Items.Add("K3");
						}
					}
				}
			}
			cb.SelectedIndex = -1;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002C40 File Offset: 0x00000E40
		public static void setPlant(TreeView tv, string factory)
		{
			tv.LabelEdit = false;
			tv.Nodes.Clear();
			bool flag = !string.IsNullOrEmpty(factory) && factory == "ATK_E";
			if (flag)
			{
				tv.Nodes.Add("K3_E", "K3_E");
			}
			else
			{
				bool flag2 = !string.IsNullOrEmpty(factory) && factory == "ATK_K5_M";
				if (flag2)
				{
					tv.Nodes.Add("K5_M", "K5_M");
				}
				else
				{
					bool flag3 = !string.IsNullOrEmpty(factory) && factory == "ATK_K5";
					if (flag3)
					{
						tv.Nodes.Add("K5", "K5");
					}
					else
					{
						bool flag4 = !string.IsNullOrEmpty(factory) && factory == "ATV";
						if (flag4)
						{
							tv.Nodes.Add("ATV", "ATV");
						}
						else
						{
							tv.Nodes.Add("K3", "K3");
						}
					}
				}
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002D44 File Offset: 0x00000F44
		public static Dictionary<string, Dictionary<string, EquipmentInfo>> getEquipmentList(FactorySettings factorySettings, bool needAll)
		{
			Dictionary<string, Dictionary<string, EquipmentInfo>> dictionary = new Dictionary<string, Dictionary<string, EquipmentInfo>>();
			cFunction._queryMgr = new QueryMgr(factorySettings);
			foreach (string text in cConst.sPlant)
			{
				foreach (string text2 in cConst.sCategory)
				{
					string text3 = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMachineList]";
					text3 = text3 + "@_plant=N'" + text + "'";
					text3 = text3 + ", @SearchType=N'" + text2 + "'";
					DataSet dataSet = cFunction._queryMgr.queryCall(text3);
					bool flag = dataSet != null && dataSet.Tables.Count != 0;
					if (flag)
					{
						Dictionary<string, EquipmentInfo> dictionary2 = new Dictionary<string, EquipmentInfo>();
						EquipmentInfo value = new EquipmentInfo();
						bool flag2 = !dictionary.ContainsKey(text);
						if (flag2)
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
								bool flag3 = keyValuePair.Key == text;
								if (flag3)
								{
									foreach (KeyValuePair<string, EquipmentInfo> keyValuePair2 in keyValuePair.Value)
									{
										bool flag4 = keyValuePair2.Key == text2;
										if (flag4)
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

		// Token: 0x06000013 RID: 19 RVA: 0x00003000 File Offset: 0x00001200
		public static HCCParameter getHCCInfo(FactorySettings factorySettings, string factory, string content, string location)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintHCCInfo] @_Content=N'",
				content,
				"', @_Location=N'",
				location,
				"', @_Factory=N'",
				factory,
				"'"
			});
			HCCParameter hccparameter = new HCCParameter();
			hccparameter.location = location;
			hccparameter.nickname = string.Empty;
			hccparameter.hccid = string.Empty;
			hccparameter.boardid = string.Empty;
			hccparameter.device = string.Empty;
			hccparameter.pkgType = string.Empty;
			hccparameter.handlerType = string.Empty;
			hccparameter.site = string.Empty;
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				int num = 0;
				if (num < dataSet.Tables[0].Rows.Count)
				{
					bool flag2 = dataSet.Tables[0].Columns.Contains("typedesc");
					if (flag2)
					{
						hccparameter.boardType = dataSet.Tables[0].Rows[num]["typedesc"].ToString().Trim();
					}
					bool flag3 = dataSet.Tables[0].Columns.Contains("nickname");
					if (flag3)
					{
						hccparameter.nickname = dataSet.Tables[0].Rows[num]["nickname"].ToString().Trim();
					}
					bool flag4 = dataSet.Tables[0].Columns.Contains("id");
					if (flag4)
					{
						hccparameter.hccid = dataSet.Tables[0].Rows[num]["id"].ToString().Trim();
					}
					bool flag5 = dataSet.Tables[0].Columns.Contains("boardno");
					if (flag5)
					{
						hccparameter.boardid = dataSet.Tables[0].Rows[num]["boardno"].ToString().Trim();
					}
					bool flag6 = dataSet.Tables[0].Columns.Contains("pkgType");
					if (flag6)
					{
						hccparameter.pkgType = dataSet.Tables[0].Rows[num]["pkgType"].ToString().Trim();
					}
					bool flag7 = dataSet.Tables[0].Columns.Contains("handlerType");
					if (flag7)
					{
						hccparameter.handlerType = dataSet.Tables[0].Rows[num]["handlerType"].ToString().Trim();
					}
					bool flag8 = dataSet.Tables[0].Columns.Contains("site");
					if (flag8)
					{
						hccparameter.site = dataSet.Tables[0].Rows[num]["site"].ToString().Trim();
					}
					bool flag9 = dataSet.Tables[0].Columns.Contains("device");
					if (flag9)
					{
						hccparameter.device = dataSet.Tables[0].Rows[num]["device"].ToString().Trim();
					}
					bool flag10 = dataSet.Tables[0].Columns.Contains("SiteRow");
					if (flag10)
					{
						bool flag11 = string.IsNullOrEmpty(dataSet.Tables[0].Rows[num]["SiteRow"].ToString().Trim()) || dataSet.Tables[0].Rows[num]["SiteRow"].ToString().IndexOf("r:") == -1;
						if (flag11)
						{
							hccparameter.siteRow = 0;
						}
						else
						{
							hccparameter.siteRow = Convert.ToInt32(dataSet.Tables[0].Rows[num]["SiteRow"].ToString().Replace("r:", "").Trim());
						}
					}
					bool flag12 = dataSet.Tables[0].Columns.Contains("SiteColumn");
					if (flag12)
					{
						bool flag13 = string.IsNullOrEmpty(dataSet.Tables[0].Rows[num]["SiteColumn"].ToString().Trim()) || dataSet.Tables[0].Rows[num]["SiteColumn"].ToString().IndexOf("c:") == -1;
						if (flag13)
						{
							hccparameter.siteCol = 0;
						}
						else
						{
							hccparameter.siteCol = Convert.ToInt32(dataSet.Tables[0].Rows[num]["SiteColumn"].ToString().Replace("c:", "").Trim());
						}
					}
					bool flag14 = dataSet.Tables[0].Columns.Contains("SiteDirection");
					if (flag14)
					{
						bool flag15 = string.IsNullOrEmpty(dataSet.Tables[0].Rows[num]["SiteDirection"].ToString().Trim()) || dataSet.Tables[0].Rows[num]["SiteDirection"].ToString().IndexOf("d:") == -1;
						if (flag15)
						{
							hccparameter.siteDirection = SITE_DRIECTION.RIGHT;
						}
						else
						{
							hccparameter.siteDirection = (SITE_DRIECTION)Convert.ToInt32(dataSet.Tables[0].Rows[num]["SiteDirection"].ToString().Replace("d:", "").Trim());
						}
					}
					bool flag16 = dataSet.Tables[0].Columns.Contains("SiteDirectionDescription");
					if (flag16)
					{
						hccparameter.siteDirectionDesc = dataSet.Tables[0].Rows[num]["SiteDirectionDescription"].ToString().Trim();
					}
					bool flag17 = dataSet.Tables[0].Columns.Contains("NumberOfSite");
					if (flag17)
					{
						bool flag18 = string.IsNullOrEmpty(dataSet.Tables[0].Rows[num]["NumberOfSite"].ToString().Trim()) || dataSet.Tables[0].Rows[num]["NumberOfSite"].ToString().IndexOf("no:") == -1;
						if (flag18)
						{
							hccparameter.numberOfSite = string.Empty;
						}
						else
						{
							hccparameter.numberOfSite = dataSet.Tables[0].Rows[num]["NumberOfSite"].ToString().Replace("no:", "").Trim();
						}
					}
					return hccparameter;
				}
			}
			return hccparameter;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000378C File Offset: 0x0000198C
		public static bool getHCCInfo(FactorySettings factorySettings, string factory, string content, string location, out HCCParameter hCCParameter)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintHCCInfo] @_Content=N'",
				content,
				"', @_Location=N'",
				location,
				"', @_Factory=N'",
				factory,
				"'"
			});
			hCCParameter = new HCCParameter();
			hCCParameter.location = location;
			hCCParameter.nickname = string.Empty;
			hCCParameter.hccid = string.Empty;
			hCCParameter.boardid = string.Empty;
			hCCParameter.device = string.Empty;
			hCCParameter.pkgType = string.Empty;
			hCCParameter.handlerType = string.Empty;
			hCCParameter.site = string.Empty;
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				int num = 0;
				if (num < dataSet.Tables[0].Rows.Count)
				{
					bool flag2 = dataSet.Tables[0].Columns.Contains("typedesc");
					if (flag2)
					{
						hCCParameter.boardType = dataSet.Tables[0].Rows[num]["typedesc"].ToString().Trim();
					}
					bool flag3 = dataSet.Tables[0].Columns.Contains("nickname");
					if (flag3)
					{
						hCCParameter.nickname = dataSet.Tables[0].Rows[num]["nickname"].ToString().Trim();
					}
					bool flag4 = dataSet.Tables[0].Columns.Contains("id");
					if (flag4)
					{
						hCCParameter.hccid = dataSet.Tables[0].Rows[num]["id"].ToString().Trim();
					}
					bool flag5 = dataSet.Tables[0].Columns.Contains("boardno");
					if (flag5)
					{
						hCCParameter.boardid = dataSet.Tables[0].Rows[num]["boardno"].ToString().Trim();
					}
					bool flag6 = dataSet.Tables[0].Columns.Contains("pkgType");
					if (flag6)
					{
						hCCParameter.pkgType = dataSet.Tables[0].Rows[num]["pkgType"].ToString().Trim();
					}
					bool flag7 = dataSet.Tables[0].Columns.Contains("handlerType");
					if (flag7)
					{
						hCCParameter.handlerType = dataSet.Tables[0].Rows[num]["handlerType"].ToString().Trim();
					}
					bool flag8 = dataSet.Tables[0].Columns.Contains("site");
					if (flag8)
					{
						hCCParameter.site = dataSet.Tables[0].Rows[num]["site"].ToString().Trim();
					}
					bool flag9 = dataSet.Tables[0].Columns.Contains("device");
					if (flag9)
					{
						hCCParameter.device = dataSet.Tables[0].Rows[num]["device"].ToString().Trim();
					}
					bool flag10 = dataSet.Tables[0].Columns.Contains("SiteRow");
					if (flag10)
					{
						bool flag11 = string.IsNullOrEmpty(dataSet.Tables[0].Rows[num]["SiteRow"].ToString().Trim()) || dataSet.Tables[0].Rows[num]["SiteRow"].ToString().IndexOf("r:") == -1;
						if (flag11)
						{
							hCCParameter.siteRow = 0;
						}
						else
						{
							hCCParameter.siteRow = Convert.ToInt32(dataSet.Tables[0].Rows[num]["SiteRow"].ToString().Replace("r:", "").Trim());
						}
					}
					bool flag12 = dataSet.Tables[0].Columns.Contains("SiteColumn");
					if (flag12)
					{
						bool flag13 = string.IsNullOrEmpty(dataSet.Tables[0].Rows[num]["SiteColumn"].ToString().Trim()) || dataSet.Tables[0].Rows[num]["SiteColumn"].ToString().IndexOf("c:") == -1;
						if (flag13)
						{
							hCCParameter.siteCol = 0;
						}
						else
						{
							hCCParameter.siteCol = Convert.ToInt32(dataSet.Tables[0].Rows[num]["SiteColumn"].ToString().Replace("c:", "").Trim());
						}
					}
					bool flag14 = dataSet.Tables[0].Columns.Contains("SiteDirection");
					if (flag14)
					{
						bool flag15 = string.IsNullOrEmpty(dataSet.Tables[0].Rows[num]["SiteDirection"].ToString().Trim()) || dataSet.Tables[0].Rows[num]["SiteDirection"].ToString().IndexOf("d:") == -1;
						if (flag15)
						{
							hCCParameter.siteDirection = SITE_DRIECTION.RIGHT;
						}
						else
						{
							hCCParameter.siteDirection = (SITE_DRIECTION)Convert.ToInt32(dataSet.Tables[0].Rows[num]["SiteDirection"].ToString().Replace("d:", "").Trim());
						}
					}
					bool flag16 = dataSet.Tables[0].Columns.Contains("SiteDirectionDescription");
					if (flag16)
					{
						hCCParameter.siteDirectionDesc = dataSet.Tables[0].Rows[num]["SiteDirectionDescription"].ToString().Trim();
					}
					bool flag17 = dataSet.Tables[0].Columns.Contains("NumberOfSite");
					if (flag17)
					{
						bool flag18 = string.IsNullOrEmpty(dataSet.Tables[0].Rows[num]["NumberOfSite"].ToString().Trim()) || dataSet.Tables[0].Rows[num]["NumberOfSite"].ToString().IndexOf("no:") == -1;
						if (flag18)
						{
							hCCParameter.numberOfSite = string.Empty;
						}
						else
						{
							hCCParameter.numberOfSite = dataSet.Tables[0].Rows[num]["NumberOfSite"].ToString().Replace("no:", "").Trim();
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003F34 File Offset: 0x00002134
		public static bool checkFactory(ComboBox combobox, string factory)
		{
			bool flag = combobox.SelectedItem != null;
			return flag && combobox.SelectedItem.ToString().Trim() == factory.Trim();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003F7C File Offset: 0x0000217C
		public static bool attachZip(string report, string reuestTime, cReportItem reportItem, List<cFileList> files, bool isAction, bool isPM)
		{
			bool result;
			try
			{
				DateTime dateTime = Convert.ToDateTime(reuestTime.Trim());
				string text = string.Empty;
				bool flag = reportItem.sFactory == "ATV";
				if (flag)
				{
					if (isAction)
					{
						if (isPM)
						{
							text = string.Concat(new string[]
							{
								"\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\PMAction\\",
								dateTime.Year.ToString(),
								"\\",
								dateTime.Month.ToString(),
								"\\",
								dateTime.Day.ToString()
							});
						}
						else
						{
							text = string.Concat(new string[]
							{
								"\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\Action\\",
								dateTime.Year.ToString(),
								"\\",
								dateTime.Month.ToString(),
								"\\",
								dateTime.Day.ToString()
							});
						}
					}
					else
					{
						if (isPM)
						{
							return false;
						}
						text = string.Concat(new string[]
						{
							"\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\Report\\",
							dateTime.Year.ToString(),
							"\\",
							dateTime.Month.ToString(),
							"\\",
							dateTime.Day.ToString()
						});
					}
				}
				string text2 = string.Empty;
				if (isAction)
				{
					text2 = report.Replace("/", "_").Trim() + "_Action.zip";
				}
				else
				{
					text2 = report.Replace("/", "_").Trim() + ".zip";
				}
				string text3 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\" + text2;
				string destFileName = text + "\\" + text2;
				bool flag2 = File.Exists(text3);
				if (flag2)
				{
					File.Delete(text3);
				}
				bool flag3 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\attach\\File");
				if (flag3)
				{
					Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\attach\\File");
				}
				else
				{
					Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\attach\\File", true);
					Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\attach\\File");
				}
				bool flag4 = !Directory.Exists(text);
				if (flag4)
				{
					Directory.CreateDirectory(text);
				}
				for (int i = 0; i < files.Count; i++)
				{
					cFileList cFileList = files[i];
					bool flag5 = File.Exists(cFileList.sFilePath);
					if (flag5)
					{
						File.Copy(cFileList.sFilePath, "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\attach\\File\\" + cFileList.sFileName, true);
					}
				}
				ZipFile.CreateFromDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\attach\\File", text3, System.IO.Compression.CompressionLevel.Optimal, false);
				bool flag6 = File.Exists(text3);
				if (flag6)
				{
					File.Copy(text3, destFileName, true);
					File.Delete(text3);
				}
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000042A0 File Offset: 0x000024A0
		public static bool setMaintHCCStatus(FactorySettings factorySettings, string content, string location, int status, string factory)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string text = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintHCCStatus] @_Content=N'",
				content,
				"', @_Location=N'",
				location,
				"'"
			});
			switch (status)
			{
			case 1:
			{
				bool flag = factory == "K3" || factory == "K3_E";
				if (flag)
				{
					text += ", @_Status =N'GOOD_K3'";
				}
				else
				{
					text += ", @_Status =N'GOOD'";
				}
				break;
			}
			case 2:
			{
				bool flag2 = factory == "K3" || factory == "K3_E";
				if (flag2)
				{
					text += ", @_Status =N'CHECK_K3'";
				}
				else
				{
					text += ", @_Status =N'CHECK'";
				}
				break;
			}
			case 3:
			{
				bool flag3 = factory == "K3" || factory == "K3_E";
				if (flag3)
				{
					text += ", @_Status =N'PARTIAL_K3'";
				}
				break;
			}
			}
			DataSet dataSet = cFunction._queryMgr.queryCall(text);
			bool flag4 = dataSet != null && dataSet.Tables != null;
			if (flag4)
			{
				bool flag5 = dataSet.Tables.Count != 0;
				if (flag5)
				{
					bool flag6 = dataSet.Tables[0].Rows.Count != 0;
					if (flag6)
					{
						bool flag7 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() != "OK";
						if (flag7)
						{
							return false;
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000445C File Offset: 0x0000265C
		public static List<string> getMailList(FactorySettings factorySettings, string factory)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			List<string> list = new List<string>();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMail]";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string item = dataSet.Tables[0].Rows[i]["mail"].ToString();
					string text = dataSet.Tables[0].Rows[i]["Plant"].ToString();
					bool flag2 = text.Trim() == factory.Trim();
					if (flag2)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00004554 File Offset: 0x00002754
		public static bool getUserData(cReportItem report, string sUserID)
		{
			string userData_SubFunc = cFunction.getUserData_SubFunc(sUserID);
			bool flag = userData_SubFunc.ToUpper().IndexOf("NOT EXIST") == -1;
			bool result;
			if (flag)
			{
				string[] array = userData_SubFunc.Split(new char[]
				{
					';'
				});
				bool flag2 = array.Length != 0 && array.Length == 3 && report.sReportStauts == string.Empty;
				if (flag2)
				{
					report.sName = array[0];
					report.sTeam = array[1];
					report.sFrom = array[2];
				}
				else
				{
					bool flag3 = array.Length != 0 && array.Length == 3 && report.sReportStauts == "11";
					if (flag3)
					{
						report.sApprovalName = array[0];
						report.sApprovalTeam = array[1];
						report.sFromAction = array[2];
					}
					else
					{
						bool flag4 = array.Length != 0 && array.Length == 3 && report.sReportStauts == "12";
						if (flag4)
						{
							report.sActionName = array[0];
							report.sActionTeam = array[1];
							report.sFromAction = array[2];
						}
						else
						{
							bool flag5 = array.Length != 0 && array.Length == 3 && report.sReportStauts == "13";
							if (flag5)
							{
								report.sPMFinalName = array[0];
								report.sPMFinalTeam = array[1];
								report.sFromAction = array[2];
							}
							else
							{
								bool flag6 = array.Length != 0 && array.Length == 3 && (report.sReportStauts == "14" || report.sReportStauts == "98" || report.sReportStauts == "97" || report.sReportStauts == "96");
								if (!flag6)
								{
									MessageBox.Show("Can not receive Data from eMES (" + sUserID + ")\r\nPlease contact to TFA Team");
									return false;
								}
							}
						}
					}
				}
				result = true;
			}
			else
			{
				bool flag7 = report.sReportStauts == "11";
				if (flag7)
				{
					result = false;
				}
				else
				{
					bool flag8 = report.sReportStauts == "12";
					if (flag8)
					{
						result = false;
					}
					else
					{
						bool flag9 = report.sReportStauts == "13";
						result = (flag9 && false);
					}
				}
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00004784 File Offset: 0x00002984
		public static void getTeam(FactorySettings factorySettings, ComboBox cb, Dictionary<string, string> deptMailList)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			deptMailList.Clear();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTeamInfo]";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					cb.Items.Add(dataSet.Tables[0].Rows[i]["Name"].ToString());
					deptMailList.Add(dataSet.Tables[0].Rows[i]["Name"].ToString(), dataSet.Tables[0].Rows[i]["Mail"].ToString());
				}
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00004888 File Offset: 0x00002A88
		public static string MakeRFTFile(RichTextBox rb)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = rb.Tag.ToString();
			uint num = <PrivateImplementationDetails>.ComputeStringHash(text3);
			if (num <= 856466825U)
			{
				if (num <= 822911587U)
				{
					if (num != 806133968U)
					{
						if (num == 822911587U)
						{
							if (text3 == "4")
							{
								text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content4.rtf";
								text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content4.7z";
							}
						}
					}
					else if (text3 == "5")
					{
						text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content5.rtf";
						text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content5.7z";
					}
				}
				else if (num != 839689206U)
				{
					if (num == 856466825U)
					{
						if (text3 == "6")
						{
							text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content6.rtf";
							text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content6.7z";
						}
					}
				}
				else if (text3 == "7")
				{
					text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content7.rtf";
					text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content7.7z";
				}
			}
			else if (num <= 906799682U)
			{
				if (num != 873244444U)
				{
					if (num == 906799682U)
					{
						if (text3 == "3")
						{
							text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content3.rtf";
							text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content3.7z";
						}
					}
				}
				else if (text3 == "1")
				{
					text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content1.rtf";
					text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content1.7z";
				}
			}
			else if (num != 923577301U)
			{
				if (num == 1024243015U)
				{
					if (text3 == "8")
					{
						text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content8.rtf";
						text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content8.7z";
					}
				}
			}
			else if (text3 == "2")
			{
				text = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content2.rtf";
				text2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content2.7z";
			}
			bool flag = File.Exists(text);
			if (flag)
			{
				File.Delete(text);
			}
			bool flag2 = File.Exists(text2);
			if (flag2)
			{
				File.Delete(text2);
			}
			byte[] bytes = Encoding.UTF8.GetBytes(rb.Rtf.Replace("\\pichgoal-", "\\pichgoal").Replace("\\picwgoal-", "\\picwgoal"));
			File.WriteAllBytes(text, bytes);
			cFunction.CreateSevenZipFile(text, text2, false);
			FileInfo fileInfo = new FileInfo(text2);
			return Convert.ToBase64String(cFunction.getBinarySevenFile(text2));
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004AD0 File Offset: 0x00002CD0
		private static byte[] getBinarySevenFile(string sSevenZipFile)
		{
			FileStream fileStream = new FileStream(sSevenZipFile, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return array;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00004B0C File Offset: 0x00002D0C
		private static void CreateSevenZipFile(string sTargetFile, string sSevenZipFile, bool Directory)
		{
			try
			{
				bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
				if (is64BitOperatingSystem)
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x64.dll");
				}
				else
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x86.dll");
				}
				SevenZipCompressor sevenZipCompressor = new SevenZipCompressor();
				sevenZipCompressor.CompressionMethod = CompressionMethod.Lzma;
				sevenZipCompressor.CompressionMode = SevenZip.CompressionMode.Create;
				sevenZipCompressor.CompressionLevel = SevenZip.CompressionLevel.Ultra;
				if (Directory)
				{
					sevenZipCompressor.CompressDirectory(sTargetFile, sSevenZipFile);
				}
				else
				{
					sevenZipCompressor.CompressFiles(sSevenZipFile, new string[]
					{
						sTargetFile
					});
				}
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "CreateSevenZipFile", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance.GrobalConst\\cFunction.cs", 1036);
			}
			finally
			{
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00004BDC File Offset: 0x00002DDC
		public static void ExcuteSevenZipReport(string sBody, RichTextBox rb)
		{
			bool flag = rb == null || string.IsNullOrEmpty(sBody);
			if (!flag)
			{
				SevenZipExtractor sevenZipExtractor = null;
				FileStream fileStream = null;
				try
				{
					byte[] array = Convert.FromBase64String(sBody);
					string text = string.Empty;
					short num = short.Parse(rb.Tag.ToString());
					bool flag2 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.7z");
					if (flag2)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.7z");
					}
					bool flag3 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content2.7z");
					if (flag3)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content2.7z");
					}
					bool flag4 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.7z");
					if (flag4)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.7z");
					}
					bool flag5 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.7z");
					if (flag5)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.7z");
					}
					bool flag6 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.7z");
					if (flag6)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.7z");
					}
					bool flag7 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content6.7z");
					if (flag7)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content6.7z");
					}
					bool flag8 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z");
					if (flag8)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z");
					}
					bool flag9 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.7z");
					if (flag9)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.7z");
					}
					bool flag10 = rb != null;
					if (flag10)
					{
						switch (num)
						{
						case 1:
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.7z";
							break;
						case 2:
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content2.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content2.7z";
							break;
						case 3:
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.7z";
							break;
						case 4:
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.7z";
							break;
						case 5:
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.7z";
							break;
						case 6:
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content6.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content6.7z";
							break;
						case 8:
							fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.7z", FileMode.Create);
							text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.7z";
							break;
						}
					}
					else
					{
						fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z", FileMode.Create);
						text = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z";
					}
					bool flag11 = fileStream != null;
					if (flag11)
					{
						fileStream.Write(array, 0, array.Length);
						fileStream.Close();
						bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
						if (is64BitOperatingSystem)
						{
							SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x64.dll");
						}
						else
						{
							SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x86.dll");
						}
						sevenZipExtractor = new SevenZipExtractor(text);
						bool flag12 = File.Exists(text);
						if (flag12)
						{
							sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
						}
						bool flag13 = rb != null;
						if (flag13)
						{
							bool flag14 = array.Length != 0 && File.Exists(text);
							if (flag14)
							{
								switch (num)
								{
								case 1:
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.rtf", FileMode.Open);
									break;
								case 2:
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content2.rtf", FileMode.Open);
									break;
								case 3:
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.rtf", FileMode.Open);
									break;
								case 4:
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.rtf", FileMode.Open);
									break;
								case 5:
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.rtf", FileMode.Open);
									break;
								case 6:
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content6.rtf", FileMode.Open);
									break;
								case 8:
									fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.rtf", FileMode.Open);
									break;
								}
							}
							else
							{
								fileStream = null;
							}
							bool flag15 = fileStream != null;
							if (flag15)
							{
								array = new byte[fileStream.Length];
								fileStream.Read(array, 0, array.Length);
								fileStream.Close();
								rb.Rtf = Encoding.ASCII.GetString(array);
							}
							else
							{
								rb.Text = string.Empty;
							}
						}
					}
				}
				catch (Exception ex)
				{
					rb.Text = ex.Message.ToString();
					cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipReport", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance.GrobalConst\\cFunction.cs", 1190);
				}
				finally
				{
					bool flag16 = sevenZipExtractor != null;
					if (flag16)
					{
						sevenZipExtractor.Dispose();
					}
					bool flag17 = fileStream != null;
					if (flag17)
					{
						fileStream.Dispose();
					}
				}
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00005010 File Offset: 0x00003210
		public static Dictionary<int, string> getConfirmList(FactorySettings factorySettings, string factory, string type)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintConfirmList] @_factory=N'",
				factory,
				"', @_type=N'",
				type,
				"'"
			});
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				bool flag2 = dataSet.Tables[0].Rows.Count > 0;
				if (flag2)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						dictionary.Add(Convert.ToInt32(dataSet.Tables[0].Rows[i]["columnindex"].ToString()), dataSet.Tables[0].Rows[i]["content"].ToString());
					}
					return dictionary;
				}
			}
			return dictionary;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00005140 File Offset: 0x00003340
		public static MainPageType checkMaintPage(Control cp)
		{
			bool flag = cp == null || cp.Tag == null || cp.Tag.GetType() != typeof(MainPageType);
			MainPageType result;
			if (flag)
			{
				result = MainPageType.Maintenance;
			}
			else
			{
				switch ((MainPageType)cp.Tag)
				{
				case MainPageType.Maintenance:
					result = MainPageType.Maintenance;
					break;
				case MainPageType.PreventMaintenance:
					result = MainPageType.PreventMaintenance;
					break;
				case MainPageType.History:
					result = MainPageType.History;
					break;
				case MainPageType.Search:
					result = MainPageType.Search;
					break;
				case MainPageType.Analysis:
					result = MainPageType.Analysis;
					break;
				default:
					result = MainPageType.Maintenance;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000051C4 File Offset: 0x000033C4
		public static Control FindTopForm(Control temp)
		{
			bool flag = temp.Parent != null;
			if (flag)
			{
				bool flag2 = temp.GetType().BaseType != typeof(Form) && temp.GetType().BaseType != typeof(BaseWinView);
				if (flag2)
				{
					return cFunction.FindTopForm(temp.Parent);
				}
			}
			return temp;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00005234 File Offset: 0x00003434
		public static void ErrorMessageBox(string Message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			MessageBox.Show(string.Concat(new object[]
			{
				Message,
				"\rClass : ",
				(sourceFilePath.LastIndexOf("\\") != -1) ? sourceFilePath.Substring(sourceFilePath.LastIndexOf("\\") + 1, sourceFilePath.Length - sourceFilePath.LastIndexOf("\\") - 1) : string.Empty,
				"\rFunction : ",
				memberName,
				"\rLine : ",
				sourceLineNumber,
				"\r"
			}), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000052CC File Offset: 0x000034CC
		public static string setBoardSiteMap(FactorySettings factorySettings, string report, string location, int col, int row, SITE_DRIECTION direction, string NumberOfSite, string SiteMap)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string sQuery = string.Concat(new string[]
			{
				string.Concat(new object[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintBoardSiteMap] @_Location=N'",
					location.Trim(),
					"', @_COL=",
					col
				}) + ", @_ROW=" + row + ", @_Direction=" + (int)direction,
				", @_NumberOfSite=N'",
				NumberOfSite,
				"', @_SiteMap=N'",
				SiteMap,
				"'"
			});
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				bool flag2 = dataSet.Tables[0].Rows.Count > 0;
				if (flag2)
				{
					return (dataSet.Tables[0].Rows[0][0].ToString().ToUpper() != "OK") ? dataSet.Tables[0].Rows[0][0].ToString().ToUpper() : string.Empty;
				}
			}
			return "SITE MAP SERVER ERROR!";
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000541C File Offset: 0x0000361C
		public static string getBoardSiteMap(FactorySettings factorySettings, string location, bool realMap, string report)
		{
			string result = string.Empty;
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintBoardSiteMap] @_Location=N'",
				location.Trim(),
				"', @_RealMap=N'",
				realMap ? "1" : "0",
				"', @_ReportName=N'",
				realMap ? string.Empty : report,
				"'"
			});
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				bool flag2 = dataSet.Tables[0].Rows.Count > 0;
				if (flag2)
				{
					result = dataSet.Tables[0].Rows[0]["SiteMap"].ToString();
				}
			}
			return result;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00005504 File Offset: 0x00003704
		public static DataSet getboardTrend(FactorySettings factorySettings, string location, string startDate, string endDate)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintBoardSiteMap_Trend]@_Location=N'",
				location,
				"', @_isDevice = 0, @_startDate='",
				startDate,
				"', @_endDate='",
				endDate,
				"'"
			});
			return cFunction._queryMgr.queryCall(sQuery);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00005564 File Offset: 0x00003764
		public static string getSitemapRejectCount(FactorySettings factorySettings, string location)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintBoardSiteMap_RejectCount] @_Location=N'" + location + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			string result = "0";
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					result = dataSet.Tables[0].Rows[i]["TOTAL_REJECT"].ToString();
				}
			}
			return result;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00005618 File Offset: 0x00003818
		public static string getUpdateMessage(FactorySettings factorySettings, string userid)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintUpdateNotes] @_userid=N'" + userid + "'";
			DataSet dataSet = cFunction._queryMgr.queryCall(sQuery);
			string text = string.Empty;
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
				{
					text = text + dataSet.Tables[0].Rows[0][i].ToString() + Environment.NewLine;
				}
			}
			return text;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000056D4 File Offset: 0x000038D4
		public static string saveLayout(FactorySettings factorySettings, string userid, GridViewType type, string layout)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string text = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintLayout] @_userid=N'",
				userid,
				"', @_layout=N'",
				layout,
				"'"
			});
			switch (type)
			{
			case GridViewType.HISTORY_MAINT:
				text += ", @_type=N'HISTORY_MAINT'";
				break;
			case GridViewType.HISTORY_PM:
				text += ", @_type=N'HISTORY_PM'";
				break;
			case GridViewType.SEARCH_MAINT:
				text += ", @_type=N'SEARCH_MAINT'";
				break;
			case GridViewType.SEARCH_PM:
				text += ", @_type=N'SEARCH_PM'";
				break;
			default:
				return string.Empty;
			}
			string result;
			try
			{
				DataSet dataSet = cFunction._queryMgr.queryCall(text);
				bool flag = dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count != 0;
				if (flag)
				{
					result = dataSet.Tables[0].Rows[0][0].ToString() + Environment.NewLine;
				}
				else
				{
					result = string.Empty;
				}
			}
			catch (Exception ex)
			{
				result = ex.Message.ToString();
			}
			return result;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00005814 File Offset: 0x00003A14
		public static bool loadLayout(FactorySettings factorySettings, string userid, GridViewType type, out string layout)
		{
			cFunction._queryMgr = new QueryMgr(factorySettings);
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintLayout] @_userid=N'" + userid + "'";
			switch (type)
			{
			case GridViewType.HISTORY_MAINT:
				text += ",@_type=N'HISTORY_MAINT'";
				break;
			case GridViewType.HISTORY_PM:
				text += ",@_type=N'HISTORY_PM'";
				break;
			case GridViewType.SEARCH_MAINT:
				text += ",@_type=N'SEARCH_MAINT'";
				break;
			case GridViewType.SEARCH_PM:
				text += ",@_type=N'SEARCH_PM'";
				break;
			default:
				layout = string.Empty;
				return false;
			}
			bool result;
			try
			{
				DataSet dataSet = cFunction._queryMgr.queryCall(text);
				bool flag = dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count != 0;
				if (flag)
				{
					layout = dataSet.Tables[0].Rows[0]["layout"].ToString();
					result = true;
				}
				else
				{
					layout = string.Empty;
					result = false;
				}
			}
			catch (Exception ex)
			{
				layout = ex.Message.ToString();
				result = false;
			}
			return result;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00005940 File Offset: 0x00003B40
		public static string GetAppSetting(Configuration config, string key)
		{
			KeyValueConfigurationElement keyValueConfigurationElement = config.AppSettings.Settings[key];
			bool flag = keyValueConfigurationElement != null;
			if (flag)
			{
				string value = keyValueConfigurationElement.Value;
				bool flag2 = !string.IsNullOrEmpty(value);
				if (flag2)
				{
					return value;
				}
			}
			return string.Empty;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00005990 File Offset: 0x00003B90
		public static string getUserData_SubFunc(string sUserID)
		{
			string result = string.Empty;
			Configuration config = null;
			string location = typeof(cFunction).Assembly.Location;
			try
			{
				config = ConfigurationManager.OpenExeConfiguration(location);
			}
			catch (Exception ex)
			{
			}
			bool flag = cFunction.GetAppSetting(config, "GCLoginMethod").CompareTo("eMES") == 0;
			if (flag)
			{
				string requestUriString = cFunction.GetAppSetting(config, "GCeMesUrl") + sUserID;
				WebRequest webRequest = WebRequest.Create(requestUriString);
				webRequest.Credentials = CredentialCache.DefaultCredentials;
				WebResponse response = webRequest.GetResponse();
				Console.WriteLine(((HttpWebResponse)response).StatusDescription);
				Stream responseStream = response.GetResponseStream();
				Encoding utf = Encoding.UTF8;
				StreamReader streamReader = new StreamReader(responseStream, utf);
				result = streamReader.ReadToEnd();
				streamReader.Close();
				response.Close();
			}
			else
			{
				bool flag2 = cFunction.GetAppSetting(config, "GCLoginMethod").CompareTo("CIMitarAcc") == 0;
				if (flag2)
				{
					string text = "EXEC [CIMitar_AppConfig].[dbo].[USP_AppConfig_GetUserSettings]";
					text = text + " @ID=N'" + sUserID + "'";
					DataSet dataSet = cFunction._queryMgr.queryCall(text);
					bool flag3 = dataSet != null && dataSet.Tables.Count > 0;
					if (flag3)
					{
						result = string.Concat(new string[]
						{
							dataSet.Tables[0].Rows[0]["username"].ToString(),
							";",
							dataSet.Tables[0].Rows[0]["usergroup"].ToString(),
							";",
							dataSet.Tables[0].Rows[0]["mailaddress"].ToString()
						});
					}
				}
			}
			return result;
		}

		// Token: 0x04000046 RID: 70
		private static QueryMgr _queryMgr;

		// Token: 0x04000047 RID: 71
		private static long _fileSizeRTF = 0L;
	}
}
