using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.UnitDataProcModule.CommonClass;
using Amkor.CADModules.UnitDataProcModule.Controls;
using Amkor.CADModules.UnitDataProcModule.DataClass;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Amkor.CADModules.UnitDataProcModule.AnalysisView
{
	// Token: 0x02000002 RID: 2
	public class UnitDataResult : UserControl
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000205E File Offset: 0x0000025E
		// (set) Token: 0x06000003 RID: 3 RVA: 0x00002066 File Offset: 0x00000266
		public cMainData Data
		{
			get
			{
				return this.mData;
			}
			set
			{
				this.mData = value;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002070 File Offset: 0x00000270
		public UnitDataResult()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020EC File Offset: 0x000002EC
		private void UnitDataResult_Load(object sender, EventArgs e)
		{
			this.getReportType();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020F4 File Offset: 0x000002F4
		private void getReportType()
		{
			DataSet dataSet = new DataSet();
			string text = string.Empty;
			try
			{
				string sQuery = "EXEC [CIMitar_Unit].[dbo].[USP_GetTypeDefList] @typename = 'ESI_ReportType'";
				dataSet = this.Data._CommonQry.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					this.chkcmb_ReportType.CheckedMember = null;
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						text = dataSet.Tables[0].Rows[i][0].ToString();
						RadCheckedListDataItem radCheckedListDataItem = new RadCheckedListDataItem();
						radCheckedListDataItem.Checked = true;
						radCheckedListDataItem.Text = text;
						this.chkcmb_ReportType.Items.Add(radCheckedListDataItem);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021EC File Offset: 0x000003EC
		private RadGridView createGrid()
		{
			return new RadGridView
			{
				MasterTemplate = 
				{
					MultiSelect = true
				},
				Name = "grid_Data",
				Size = new Size(100, 100)
			};
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002228 File Offset: 0x00000428
		public void btnSearch_Click(object sender, EventArgs e)
		{
			if (!this.mData.checkLot())
			{
				RadMessageBox.Show(this, "Select Lot List", "CIMitarAnalysis", MessageBoxButtons.OK, RadMessageIcon.Error);
				return;
			}
			try
			{
				this._slData.Clear();
				this._slSelectData.Clear();
				this.radDock1.RemoveAllDocumentWindows(DockWindowCloseAction.CloseAndDispose);
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this._barPrograss.setMax(100);
				this.initDataTable();
				this.getData();
				this.setUnitListGrid();
				for (int i = this.chkcmb_ReportType.CheckedItems.Count - 1; i >= 0; i--)
				{
					this.createMenuControl(this.radDock1, null, this.chkcmb_ReportType.CheckedItems[i].ToString());
					string a;
					if ((a = this.chkcmb_ReportType.CheckedItems[i].ToString().Trim()) != null)
					{
						if (!(a == "Lot Yield"))
						{
							if (!(a == "Unit TestResult(Per unit)"))
							{
								if (!(a == "Failure Summary"))
								{
									if (a == "BinPareto")
									{
										this._barPrograss.progress_labelheader_set("BinPareto ....");
										this.setBinParetoGrid();
										this._barPrograss.setValue(100);
									}
								}
								else
								{
									this._barPrograss.progress_labelheader_set("Failure Summary....");
									this.setFailSummaryGrid();
									this._barPrograss.setValue(100);
								}
							}
							else
							{
								this._barPrograss.progress_labelheader_set("Unit TestResult(Per unit)....");
								this.setUnitResultGrid();
								this._barPrograss.setValue(90);
							}
						}
						else
						{
							this._barPrograss.progress_labelheader_set("Lot Yield....");
							this.setLotYieldGrid();
							this._barPrograss.setValue(80);
						}
					}
				}
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
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002494 File Offset: 0x00000694
		private void initDataTable()
		{
			this.dtUnitList = null;
			this.dtUnitList = new DataTable();
			this.dtUnitList.Columns.Add("No", typeof(string));
			this.dtUnitList.Columns.Add("SN", typeof(string));
			this.dtUnitList.Columns.Add("TestCount", typeof(string));
			this.dtUnitList.Columns.Add("Lot", typeof(string));
			this.dtUnitList.Columns.Add("Dcc", typeof(string));
			this.dtUnitList.Columns.Add("Oper", typeof(string));
			this.dtUnitList.Columns.Add("LotID", typeof(string));
			this.dtYieldData = null;
			this.dtYieldData = new DataTable();
			this.dtYieldData.Columns.Add("No", typeof(string));
			this.dtYieldData.Columns.Add("Lot", typeof(string));
			this.dtYieldData.Columns.Add("DCC", typeof(string));
			this.dtYieldData.Columns.Add("Operation", typeof(string));
			this.dtYieldData.Columns.Add("Product", typeof(string));
			this.dtYieldData.Columns.Add("Tester", typeof(string));
			this.dtYieldData.Columns.Add("Program", typeof(string));
			this.dtYieldData.Columns.Add("StartTime", typeof(string));
			this.dtYieldData.Columns.Add("EndTime", typeof(string));
			this.dtYieldData.Columns.Add("Input", typeof(string));
			this.dtYieldData.Columns.Add("PASS_Final", typeof(string));
			this.dtYieldData.Columns.Add("FAIL_Final", typeof(string));
			this.dtYieldData.Columns.Add("Yield", typeof(string));
			this.dtYieldData.Columns.Add("1st_PASS", typeof(string));
			this.dtYieldData.Columns.Add("1st_FAIL", typeof(string));
			this.dtYieldData.Columns.Add("FPY", typeof(string));
			this.dtYieldData.Columns.Add("Retest Rate", typeof(string));
			this.dtYieldData.Columns.Add("2st_PASS", typeof(string));
			this.dtYieldData.Columns.Add("2st_FAIL", typeof(string));
			this.dtYieldData.Columns.Add("3st_PASS", typeof(string));
			this.dtYieldData.Columns.Add("3st_FAIL", typeof(string));
			this.dtYieldData.Columns.Add("4st_PASS", typeof(string));
			this.dtYieldData.Columns.Add("4st_FAIL", typeof(string));
			this.dtYieldData.Columns.Add("5st_PASS", typeof(string));
			this.dtYieldData.Columns.Add("5st_FAIL", typeof(string));
			this.dtUnitData = null;
			this.dtUnitData = new DataTable();
			this.dtUnitData.Columns.Add("No", typeof(string));
			this.dtUnitData.Columns.Add("SN", typeof(string));
			this.dtUnitData.Columns.Add("Product", typeof(string));
			this.dtUnitData.Columns.Add("Lot", typeof(string));
			this.dtUnitData.Columns.Add("DCC", typeof(string));
			this.dtUnitData.Columns.Add("Operation", typeof(string));
			this.dtUnitData.Columns.Add("TestType", typeof(string));
			this.dtUnitData.Columns.Add("Program", typeof(string));
			this.dtUnitData.Columns.Add("Spec/Flow", typeof(string));
			this.dtUnitData.Columns.Add("Tester", typeof(string));
			this.dtUnitData.Columns.Add("Site Number", typeof(string));
			this.dtUnitData.Columns.Add("PASS/FAIL", typeof(string));
			this.dtUnitData.Columns.Add("StartTime", typeof(string));
			this.dtUnitData.Columns.Add("EndTime", typeof(string));
			this.dtUnitData.Columns.Add("TestTime", typeof(string));
			this.dtUnitData.Columns.Add("ECID", typeof(string));
			this.dtUnitData.Columns.Add("FW Ver", typeof(string));
			this.dtUnitData.Columns.Add("Fail Desc", typeof(string));
			this.dtUnitData.Columns.Add("1st Failing Test", typeof(string));
			this.dtFailData = null;
			this.dtFailData = new DataTable();
			this.dtFailData.Columns.Add("Product", typeof(string));
			this.dtFailData.Columns.Add("Device", typeof(string));
			this.dtFailData.Columns.Add("Lot", typeof(string));
			this.dtFailData.Columns.Add("Dcc", typeof(string));
			this.dtFailData.Columns.Add("Operation", typeof(string));
			this.dtFailData.Columns.Add("TestType", typeof(string));
			this.dtFailData.Columns.Add("1st Failing Test", typeof(string));
			this.dtFailData.Columns.Add("Failure Qty", typeof(string));
			this.dtFailData.Columns.Add("Failure Rate", typeof(string));
			this.dtBinParetoData = null;
			this.dtBinParetoData = new DataTable();
			this.dtBinParetoData.Columns.Add("Supplier Name", typeof(string));
			this.dtBinParetoData.Columns.Add("APN", typeof(string));
			this.dtBinParetoData.Columns.Add("MPN", typeof(string));
			this.dtBinParetoData.Columns.Add("Lot Code", typeof(string));
			this.dtBinParetoData.Columns.Add("Date Code", typeof(string));
			this.dtBinParetoData.Columns.Add("Test Step", typeof(string));
			this.dtBinParetoData.Columns.Add("Tester Platform/Tester ID", typeof(string));
			this.dtBinParetoData.Columns.Add("Test Program Name", typeof(string));
			this.dtBinParetoData.Columns.Add("Manufacturing Flow", typeof(string));
			this.dtBinParetoData.Columns.Add("Date Tested", typeof(string));
			this.dtBinParetoData.Columns.Add("Bin #", typeof(string));
			this.dtBinParetoData.Columns.Add("Bin Name", typeof(string));
			this.dtBinParetoData.Columns.Add("Bin SYL or SBL Limit", typeof(string));
			this.dtBinParetoData.Columns.Add("Bin Qty", typeof(string));
			this.dtBinParetoData.Columns.Add("Bin %", typeof(string));
			this.dtBinParetoData.Columns.Add("Sigma Value for each bin (if Data is normalized)", typeof(string));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002E7C File Offset: 0x0000107C
		private void getUnitList()
		{
			try
			{
				string sQuery = "EXEC [CIMitar_Unit].[dbo].[USP_UNIT_GetUnitList] @lotid = '" + this.mData.chkProcessID + "'";
				DataSet dataSet = this.Data._CommonQry.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.dtUnitList.Rows.Add(new string[]
						{
							(i + 1).ToString(),
							dataSet.Tables[0].Rows[i]["sn"].ToString(),
							dataSet.Tables[0].Rows[i]["lot"].ToString(),
							dataSet.Tables[0].Rows[i]["dcc"].ToString(),
							dataSet.Tables[0].Rows[i]["operation"].ToString(),
							dataSet.Tables[0].Rows[i]["lotid"].ToString()
						});
					}
				}
				this.grid_UnitList.DataSource = this.dtUnitList;
				this.grid_UnitList.AllowEditRow = false;
				this.grid_UnitList.AllowAddNewRow = false;
				this.grid_UnitList.ShowGroupPanel = false;
				this.grid_UnitList.EnableFiltering = true;
				this.grid_UnitList.EnableSorting = true;
				this.grid_UnitList.EnableGrouping = true;
				this.grid_UnitList.MasterView.TableHeaderRow.IsVisible = true;
				this.grid_UnitList.Columns["No"].Width = 30;
				this.grid_UnitList.Columns["SN"].Width = 190;
				this.grid_UnitList.Columns["Lot"].Width = 60;
				this.grid_UnitList.Columns["Dcc"].Width = 40;
				this.grid_UnitList.Columns["Oper"].Width = 40;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00003148 File Offset: 0x00001348
		private void getData()
		{
			try
			{
				for (int i = 0; i < this.mData.drsLot.Length; i++)
				{
					double num = (double)(i + 1) / (double)this.mData.drsLot.Length * 70.0;
					int value = (int)num;
					this._barPrograss.setValue(value);
					Lot_Process lot_Process = new Lot_Process();
					string text = string.Empty;
					string sLotNo = this.mData.drsLot[i]["lot"].ToString();
					string text2 = this.mData.drsLot[i]["lotid"].ToString();
					string sDCC = this.mData.drsLot[i]["dcc"].ToString();
					string sOperationName = this.mData.drsLot[i]["operation"].ToString();
					string sProduct = this.mData.drsLot[i]["product"].ToString();
					if (!this._slData.ContainsKey(text2))
					{
						lot_Process = new Lot_Process();
						lot_Process.iIDX = i + 1;
						lot_Process.iLotId = int.Parse(text2);
						lot_Process.sLotNo = sLotNo;
						lot_Process.sDCC = sDCC;
						lot_Process.sOperationName = sOperationName;
						lot_Process.sProduct = sProduct;
						this._slData.Add(text2, lot_Process);
					}
					if (this.mData.sSearchType == "SN" && this.mData.slSearchSN.ContainsKey(text2))
					{
						ArrayList arrayList = (ArrayList)this.mData.slSearchSN[text2];
						for (int j = 0; j < arrayList.Count; j++)
						{
							text = text + arrayList[j].ToString() + ",";
						}
						if (text != string.Empty)
						{
							text = text.Substring(0, text.Length - 1);
						}
					}
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Unit].[dbo].[USP_UNIT_GetUnitResultData_NEW] @type  = '', @lotid  = '",
						this.mData.drsLot[i]["lotid"].ToString(),
						"', @sn  = '",
						text,
						"'"
					});
					DataSet dataSet = this.mData._CommonQry.queryCall(sQuery);
					if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
					{
						for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
						{
							string text3 = dataSet.Tables[0].Rows[k]["program"].ToString();
							string text4 = dataSet.Tables[0].Rows[k]["sn"].ToString();
							string text5 = dataSet.Tables[0].Rows[k]["result"].ToString();
							string text6 = dataSet.Tables[0].Rows[k]["starttime"].ToString();
							string text7 = dataSet.Tables[0].Rows[k]["endtime"].ToString();
							string tester = dataSet.Tables[0].Rows[k]["tester"].ToString();
							int num2 = int.Parse(dataSet.Tables[0].Rows[k]["test_seq"].ToString());
							string fail_Value = dataSet.Tables[0].Rows[k]["fail_desc"].ToString();
							string failure_message = dataSet.Tables[0].Rows[k]["measure_result"].ToString();
							dataSet.Tables[0].Rows[k]["testerid"].ToString();
							string site = dataSet.Tables[0].Rows[k]["site"].ToString();
							string hbin = dataSet.Tables[0].Rows[k]["hbin"].ToString();
							string sbin = dataSet.Tables[0].Rows[k]["sbin"].ToString();
							string specFlow = dataSet.Tables[0].Rows[k]["spec_flow"].ToString();
							string ecid = dataSet.Tables[0].Rows[k]["ecid"].ToString();
							string fm_Ver = dataSet.Tables[0].Rows[k]["fm_ver"].ToString();
							DateTime value2 = Convert.ToDateTime(text6);
							double totalSeconds = Convert.ToDateTime(text7).Subtract(value2).TotalSeconds;
							UnitInfo unitInfo = new UnitInfo();
							unitInfo.SN = text4;
							unitInfo.PF = text5;
							if (lot_Process.slUnitList.ContainsKey(unitInfo.SN))
							{
								unitInfo = (UnitInfo)lot_Process.slUnitList[text4];
							}
							else
							{
								lot_Process.slUnitList.Add(unitInfo.SN, unitInfo);
							}
							UnitData unitData = new UnitData();
							unitData.SN = text4;
							unitData.LotID = text2;
							unitData.Num = num2;
							unitData.StartTime = text6;
							unitData.StopTime = text7;
							unitData.Tester = tester;
							unitData.Fail_Value = fail_Value;
							unitData.Failure_message = failure_message;
							unitData.result = text5;
							unitData.TestTime = totalSeconds;
							unitData.Program = text3;
							unitData.Site = site;
							unitData.HBin = hbin;
							unitData.SBin = sbin;
							unitData.SpecFlow = specFlow;
							unitData.ECID = ecid;
							unitData.FM_Ver = fm_Ver;
							unitInfo.slSeq.Add(num2, unitData);
							lot_Process.setQty(num2, text5);
							lot_Process.sProgram = text3;
							if (lot_Process.sStartTime == string.Empty || lot_Process.sStartTime.CompareTo(text6) > 0)
							{
								lot_Process.sStartTime = text6;
							}
							if (lot_Process.sEndTime == string.Empty || lot_Process.sEndTime.CompareTo(text7) < 0)
							{
								lot_Process.sEndTime = text7;
							}
						}
					}
					for (int l = 0; l < lot_Process.slUnitList.Count; l++)
					{
						UnitInfo unitInfo2 = (UnitInfo)lot_Process.slUnitList.GetByIndex(l);
						UnitData unitData2 = (UnitData)unitInfo2.slSeq.GetByIndex(unitInfo2.slSeq.Count - 1);
						UnitData unitData3 = (UnitData)unitInfo2.slSeq.GetByIndex(0);
						if (unitData2.result.ToUpper() == "PASS")
						{
							lot_Process.iPassCnt++;
						}
						else
						{
							lot_Process.iFailCnt++;
							if (!lot_Process.slList_final.ContainsKey(unitData2.Failure_message))
							{
								lot_Process.slList_final.Add(unitData2.Failure_message, 1);
							}
							else
							{
								lot_Process.slList_final[unitData2.Failure_message] = lot_Process.slList_final[unitData2.Failure_message] + 1;
							}
						}
						if (unitData3.result.ToUpper() == "FAIL")
						{
							if (!lot_Process.slList_1st.ContainsKey(unitData3.Failure_message))
							{
								lot_Process.slList_1st.Add(unitData3.Failure_message, 1);
							}
							else
							{
								lot_Process.slList_1st[unitData3.Failure_message] = lot_Process.slList_1st[unitData3.Failure_message] + 1;
							}
						}
						for (int m = 0; m < unitInfo2.slSeq.Count; m++)
						{
							UnitData unitData4 = new UnitData();
							if (this.rdoFinal.CheckState == CheckState.Checked)
							{
								unitData4 = (UnitData)unitInfo2.slSeq.GetByIndex(unitInfo2.slSeq.Count - 1);
								m = unitInfo2.slSeq.Count;
							}
							else if (this.rdo1st.CheckState == CheckState.Checked)
							{
								unitData4 = (UnitData)unitInfo2.slSeq.GetByIndex(0);
								m = unitInfo2.slSeq.Count;
							}
							else
							{
								unitData4 = (UnitData)unitInfo2.slSeq.GetByIndex(m);
							}
							if ((this.rdoPassResult.CheckState == CheckState.Checked && unitData4.result.ToUpper() == "PASS") || (this.rdoFailResult.CheckState == CheckState.Checked && unitData4.result.ToUpper() == "FAIL") || this.rdoAllResult.CheckState == CheckState.Checked)
							{
								this.dtUnitData.Rows.Add(new string[]
								{
									(l + 1).ToString(),
									unitInfo2.SN,
									lot_Process.sProduct,
									lot_Process.sLotNo,
									lot_Process.sDCC,
									lot_Process.sOperationName,
									unitData4.Num.ToString(),
									unitData4.Program,
									unitData4.SpecFlow,
									unitData4.Tester,
									unitData4.Site,
									unitData4.result,
									unitData4.StartTime,
									unitData4.StopTime,
									unitData4.TestTime.ToString(),
									unitData4.ECID,
									unitData4.FM_Ver,
									unitData4.Fail_Value,
									unitData4.Failure_message
								});
							}
						}
						this.dtUnitList.Rows.Add(new string[]
						{
							(l + 1).ToString(),
							unitInfo2.SN,
							unitInfo2.slSeq.Count.ToString(),
							lot_Process.sLotNo,
							lot_Process.sDCC,
							lot_Process.sOperationName,
							lot_Process.iLotId.ToString()
						});
					}
					if (lot_Process.slUnitList.Count > 0)
					{
						lot_Process.dFTY = Math.Round(double.Parse(lot_Process.iPassCnt.ToString()) / (double)lot_Process.slUnitList.Count * 100.0, 2);
						lot_Process.dFPY = Math.Round(double.Parse(lot_Process.iPass1Cnt.ToString()) / (double)lot_Process.slUnitList.Count * 100.0, 2);
						lot_Process.dRT_Rate = Math.Round(lot_Process.dFTY - lot_Process.dFPY, 2);
					}
					this.dtYieldData.Rows.Add(new string[]
					{
						(i + 1).ToString(),
						lot_Process.sLotNo,
						lot_Process.sDCC,
						lot_Process.sOperationName,
						lot_Process.sProduct,
						lot_Process.sTester,
						lot_Process.sProgram,
						lot_Process.sStartTime,
						lot_Process.sEndTime,
						lot_Process.slUnitList.Count.ToString(),
						lot_Process.iPassCnt.ToString(),
						lot_Process.iFailCnt.ToString(),
						lot_Process.dFTY.ToString(),
						lot_Process.iPass1Cnt.ToString(),
						lot_Process.iFail1Cnt.ToString(),
						lot_Process.dFPY.ToString(),
						lot_Process.dRT_Rate.ToString(),
						lot_Process.iPass2Cnt.ToString(),
						lot_Process.iFail2Cnt.ToString(),
						lot_Process.iPass3Cnt.ToString(),
						lot_Process.iFail3Cnt.ToString(),
						lot_Process.iPass4Cnt.ToString(),
						lot_Process.iFail4Cnt.ToString(),
						lot_Process.iPass5Cnt.ToString(),
						lot_Process.iFail5Cnt.ToString()
					});
					List<KeyValuePair<string, int>> list = (from v in lot_Process.slList_1st
					orderby v.Value descending
					select v).ToList<KeyValuePair<string, int>>();
					List<KeyValuePair<string, int>> list2 = (from v in lot_Process.slList_final
					orderby v.Value descending
					select v).ToList<KeyValuePair<string, int>>();
					if (this.rdo1st.CheckState == CheckState.Checked || this.rdoAll.CheckState == CheckState.Checked)
					{
						for (int n = 0; n < list.Count; n++)
						{
							string key = list[n].Key;
							int value3 = int.Parse(list[n].Value.ToString());
							double num3 = Math.Round(Convert.ToDouble(value3) / Convert.ToDouble(lot_Process.slUnitList.Count) * 100.0, 4);
							this.dtFailData.Rows.Add(new string[]
							{
								lot_Process.sProduct,
								"",
								lot_Process.sLotNo,
								lot_Process.sDCC,
								lot_Process.sOperationName,
								"1st",
								key,
								value3.ToString(),
								num3.ToString()
							});
						}
					}
					if (this.rdoFinal.CheckState == CheckState.Checked || this.rdoAll.CheckState == CheckState.Checked)
					{
						for (int num4 = 0; num4 < list2.Count; num4++)
						{
							string key2 = list2[num4].Key;
							int value4 = int.Parse(list2[num4].Value.ToString());
							double num5 = Math.Round(Convert.ToDouble(value4) / Convert.ToDouble(lot_Process.slUnitList.Count) * 100.0, 4);
							this.dtFailData.Rows.Add(new string[]
							{
								lot_Process.sProduct,
								"",
								lot_Process.sLotNo,
								lot_Process.sDCC,
								lot_Process.sOperationName,
								"Final",
								key2,
								value4.ToString(),
								num5.ToString()
							});
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000040CC File Offset: 0x000022CC
		private void setUnitListGrid()
		{
			this.grid_UnitList.DataSource = this.dtUnitList;
			this.grid_UnitList.Refresh();
			this.grid_UnitList.AllowEditRow = false;
			this.grid_UnitList.AllowAddNewRow = false;
			this.grid_UnitList.ShowGroupPanel = false;
			this.grid_UnitList.EnableFiltering = true;
			this.grid_UnitList.EnableSorting = true;
			this.grid_UnitList.EnableGrouping = true;
			this.grid_UnitList.MasterView.TableHeaderRow.IsVisible = true;
			this.grid_UnitList.Columns["No"].Width = 30;
			this.grid_UnitList.Columns["SN"].Width = 190;
			this.grid_UnitList.Columns["Lot"].Width = 60;
			this.grid_UnitList.Columns["Dcc"].Width = 40;
			this.grid_UnitList.Columns["Oper"].Width = 40;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000041E4 File Offset: 0x000023E4
		private void setLotYieldGrid()
		{
			this.grid_Data = this.createGrid();
			DocumentWindow documentWindow = (DocumentWindow)this.radDock1.DocumentManager.ActiveDocument;
			documentWindow.Controls.Clear();
			documentWindow.Controls.Add(this.grid_Data);
			this.grid_Data.Dock = DockStyle.Fill;
			this.grid_Data.Visible = true;
			this.grid_Data.AllowAddNewRow = false;
			this.grid_Data.ShowGroupPanel = false;
			this.grid_Data.EnableFiltering = true;
			this.grid_Data.EnableSorting = true;
			this.grid_Data.EnableGrouping = true;
			this.grid_Data.MasterView.TableHeaderRow.IsVisible = true;
			this.grid_Data.MasterTemplate.ShowHeaderCellButtons = true;
			this.grid_Data.MasterTemplate.ShowFilteringRow = false;
			this.grid_Data.DataSource = this.dtYieldData;
			this.grid_Data.Columns["No"].Width = 30;
			this.grid_Data.Columns["Lot"].Width = 80;
			this.grid_Data.Columns["Dcc"].Width = 40;
			this.grid_Data.Columns["Operation"].Width = 50;
			this.grid_Data.Columns["StartTime"].Width = 120;
			this.grid_Data.Columns["EndTime"].Width = 120;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00004374 File Offset: 0x00002574
		private void setUnitResultGrid()
		{
			this.grid_UnitData = this.createGrid();
			DocumentWindow documentWindow = (DocumentWindow)this.radDock1.DocumentManager.ActiveDocument;
			documentWindow.Controls.Clear();
			documentWindow.Controls.Add(this.grid_UnitData);
			this.grid_UnitData.Dock = DockStyle.Fill;
			this.grid_UnitData.Visible = true;
			this.grid_UnitData.AllowAddNewRow = false;
			this.grid_UnitData.ShowGroupPanel = false;
			this.grid_UnitData.EnableFiltering = true;
			this.grid_UnitData.EnableSorting = true;
			this.grid_UnitData.EnableGrouping = true;
			this.grid_UnitData.MasterView.TableHeaderRow.IsVisible = true;
			this.grid_UnitData.MasterTemplate.ShowFilteringRow = true;
			this.grid_UnitData.DataSource = this.dtUnitData;
			this.grid_UnitData.Columns["No"].Width = 30;
			this.grid_UnitData.Columns["SN"].Width = 190;
			this.grid_UnitData.Columns["Lot"].Width = 80;
			this.grid_UnitData.Columns["Dcc"].Width = 40;
			this.grid_UnitData.Columns["Operation"].Width = 40;
			this.grid_UnitData.Columns["TestType"].Width = 60;
			this.grid_UnitData.Columns["StartTime"].Width = 120;
			this.grid_UnitData.Columns["EndTime"].Width = 120;
			this.grid_UnitData.Columns["PASS/FAIL"].Width = 60;
			this.grid_UnitData.Columns["Fail Desc"].Width = 100;
			this.grid_UnitData.Columns["1st Failing Test"].Width = 200;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00004588 File Offset: 0x00002788
		private void setFailSummaryGrid()
		{
			this.grid_FailSummary = this.createGrid();
			DocumentWindow documentWindow = (DocumentWindow)this.radDock1.DocumentManager.ActiveDocument;
			documentWindow.Controls.Clear();
			documentWindow.Controls.Add(this.grid_FailSummary);
			this.grid_FailSummary.Dock = DockStyle.Fill;
			this.grid_FailSummary.Visible = true;
			this.grid_FailSummary.AllowAddNewRow = false;
			this.grid_FailSummary.ShowGroupPanel = false;
			this.grid_FailSummary.EnableFiltering = true;
			this.grid_FailSummary.EnableSorting = true;
			this.grid_FailSummary.EnableGrouping = true;
			this.grid_FailSummary.MasterView.TableHeaderRow.IsVisible = true;
			this.grid_FailSummary.MasterTemplate.ShowHeaderCellButtons = true;
			this.grid_FailSummary.MasterTemplate.ShowFilteringRow = false;
			this.grid_FailSummary.DataSource = this.dtFailData;
			this.grid_FailSummary.Columns["Product"].Width = 100;
			this.grid_FailSummary.Columns["Device"].Width = 100;
			this.grid_FailSummary.Columns["Lot"].Width = 100;
			this.grid_FailSummary.Columns["Dcc"].Width = 40;
			this.grid_FailSummary.Columns["Operation"].Width = 80;
			this.grid_FailSummary.Columns["TestType"].Width = 100;
			this.grid_FailSummary.Columns["1st Failing Test"].Width = 200;
			this.grid_FailSummary.Columns["Failure Qty"].Width = 120;
			this.grid_FailSummary.Columns["Failure Rate"].Width = 120;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00004770 File Offset: 0x00002970
		private void setBinParetoGrid()
		{
			this.grid_BinPareto = this.createGrid();
			DocumentWindow documentWindow = (DocumentWindow)this.radDock1.DocumentManager.ActiveDocument;
			documentWindow.Controls.Clear();
			documentWindow.Controls.Add(this.grid_BinPareto);
			this.grid_BinPareto.Dock = DockStyle.Fill;
			this.grid_BinPareto.Visible = true;
			this.grid_BinPareto.AllowAddNewRow = false;
			this.grid_BinPareto.ShowGroupPanel = false;
			this.grid_BinPareto.EnableFiltering = true;
			this.grid_BinPareto.EnableSorting = true;
			this.grid_BinPareto.EnableGrouping = true;
			this.grid_BinPareto.MasterView.TableHeaderRow.IsVisible = true;
			this.grid_BinPareto.MasterTemplate.ShowHeaderCellButtons = true;
			this.grid_BinPareto.MasterTemplate.ShowFilteringRow = false;
			this.grid_BinPareto.DataSource = this.dtBinParetoData;
			this.grid_BinPareto.Columns["Supplier Name"].Width = 100;
			this.grid_BinPareto.Columns["APN"].Width = 100;
			this.grid_BinPareto.Columns["Lot Code"].Width = 100;
			this.grid_BinPareto.Columns["Test Step"].Width = 40;
			this.grid_BinPareto.Columns["Tester Platform/Tester ID"].Width = 80;
			this.grid_BinPareto.Columns["Test Program Name"].Width = 100;
			this.grid_BinPareto.Columns["Manufacturing Flow"].Width = 300;
			this.grid_BinPareto.Columns["Date Tested"].Width = 120;
			this.grid_BinPareto.Columns["Bin #"].Width = 120;
			this.grid_BinPareto.Columns["Bin Name"].Width = 120;
			this.grid_BinPareto.Columns["Bin SYL or SBL Limit"].Width = 120;
			this.grid_BinPareto.Columns["Bin Qty"].Width = 120;
			this.grid_BinPareto.Columns["Bin %"].Width = 120;
			this.grid_BinPareto.Columns["Sigma Value for each bin (if Data is normalized)"].Width = 120;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000049E4 File Offset: 0x00002BE4
		private void btnRawDataSave_Click(object sender, EventArgs e)
		{
			if (this.radDock1.DocumentManager.DocumentArray.Length == 0)
			{
				RadMessageBox.Show(this, "Data is not exist", "CIMitarAnalysis", MessageBoxButtons.OK, RadMessageIcon.Info);
				return;
			}
			SortedList sortedList = new SortedList();
			for (int i = 0; i < this.radDock1.DocumentManager.DocumentArray.Length; i++)
			{
				DocumentWindow documentWindow = (DocumentWindow)this.radDock1.DocumentManager.DocumentArray[i];
				RadGridView radGridView = (RadGridView)documentWindow.Controls[0];
				DataTable dataTable = (DataTable)radGridView.DataSource;
				sortedList.Add(i, dataTable);
				dataTable.TableName = documentWindow.Text;
			}
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
				ExcelControl.SaveExcel(this.saveFileDialog.FileName, sortedList, true);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00004B50 File Offset: 0x00002D50
		private void btnNewDoc_Click(object sender, EventArgs e)
		{
			string sMenuName = "Doc_" + this.radDock1.DockWindows.Count;
			this.createMenuControl(this.radDock1, null, sMenuName);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00004B8C File Offset: 0x00002D8C
		private void createMenuControl(RadDock radDoc_Menu, Control viewControl, string sMenuName)
		{
			DocumentWindow documentWindow = new DocumentWindow(sMenuName);
			radDoc_Menu.AddDocument(documentWindow);
			radDoc_Menu.ActiveWindow = documentWindow;
			documentWindow.AutoScroll = true;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00004BB8 File Offset: 0x00002DB8
		private void radGridView1_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
		{
			if (this._slSelectData.Count == 0)
			{
				return;
			}
			string value = (string)this._slSelectData.GetByIndex(0);
			this.grid_UnitData.BeginUpdate();
			e.Visible = false;
			string text = e.Row.Cells[1].Value.ToString();
			if (text.IndexOf(value, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
			{
				e.Visible = true;
			}
			this.grid_UnitData.EndUpdate(false);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00004C32 File Offset: 0x00002E32
		private void grid_UnitList_CellClick(object sender, GridViewCellEventArgs e)
		{
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00004C34 File Offset: 0x00002E34
		private void grid_UnitList_SelectionChanged(object sender, EventArgs e)
		{
			if (this.radDock1.DocumentManager.ActiveDocument == null)
			{
				return;
			}
			if (this.radDock1.DocumentManager.ActiveDocument.Text != "Unit TestResult(Per unit)")
			{
				bool flag = false;
				for (int i = 0; i < this.radDock1.DocumentManager.DocumentArray.Length; i++)
				{
					if (this.radDock1.DocumentManager.DocumentArray[i].Text == "Unit TestResult(Per unit)")
					{
						this.radDock1.DocumentManager.DocumentArray[1].Select();
						flag = true;
					}
				}
				if (!flag)
				{
					return;
				}
			}
			if (this.grid_UnitList.SelectedRows.Count <= 0)
			{
				this.grid_UnitList.ClearSelection();
				for (int j = 0; j < this.grid_UnitData.RowCount; j++)
				{
					this.grid_UnitData.Rows[j].IsVisible = true;
				}
				return;
			}
			string value = string.Empty;
			string key = string.Empty;
			this._slSelectData.Clear();
			for (int k = 0; k < this.grid_UnitList.SelectedRows.Count; k++)
			{
				int index = this.grid_UnitList.SelectedRows[k].Index;
				DataRowView dataRowView = (DataRowView)this.grid_UnitList.SelectedRows[k].DataBoundItem;
				value = dataRowView["lotid"].ToString();
				key = dataRowView["sn"].ToString();
				this._slSelectData.Add(key, value);
			}
			for (int l = 0; l < this.grid_UnitData.RowCount; l++)
			{
				string key2 = this.grid_UnitData.Rows[l].Cells["sn"].Value.ToString();
				if (this._slSelectData.ContainsKey(key2))
				{
					this.grid_UnitData.Rows[l].IsVisible = true;
				}
				else
				{
					this.grid_UnitData.Rows[l].IsVisible = false;
				}
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00004E50 File Offset: 0x00003050
		private void btnRawData_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (this.mData.sDevice == string.Empty)
			{
				RadMessageBox.Show(this, "Select Product please", "CIMitarAnalysis", MessageBoxButtons.OK, RadMessageIcon.Error);
				return;
			}
			if (RadMessageBox.Show(this, "Is the selected date correct? \nStartDate : " + this.mData.sDate_Start.ToShortDateString() + "\nEndDate : " + this.mData.sDate_End.ToShortDateString(), "CIMitarAnalysis", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
			{
				return;
			}
			this.saveFileDialog.DefaultExt = ".xlsx";
			this.saveFileDialog.Filter = "Excel files|*.xlsx|CSV files|*.csv";
			this.saveFileDialog.FileName = string.Empty;
			DialogResult dialogResult = this.saveFileDialog.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Save Fail Data....");
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				TimeSpan timeSpan = this.mData.sDate_End.Subtract(this.mData.sDate_Start);
				DataSet dataSet = new DataSet();
				int num = 0;
				this._barPrograss.setMax(1);
				if (timeSpan.Days > 30)
				{
					this._barPrograss.setMax(timeSpan.Days / 30);
				}
				DateTime t = this.mData.sDate_Start;
				while (t <= this.mData.sDate_End)
				{
					DateTime t2 = t.AddDays(29.0);
					if (t2 > this.mData.sDate_End)
					{
						t2 = this.mData.sDate_End;
					}
					this._barPrograss.progress_labelheader_set("Loading data : ~ " + t2.ToString("yyyy-MM-dd"));
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Unit].[dbo].[USP_UNIT_GetUnitRawData] @startdate = '",
						t.ToShortDateString(),
						"', @enddate = '",
						t2.ToShortDateString(),
						"', @product = '",
						this.mData.sDevice,
						"'"
					});
					this._barPrograss.setValue(num++);
					DataSet dataSet2 = this.Data._CommonQry.queryCall(sQuery);
					dataSet.Merge(dataSet2);
					t = t.AddDays(30.0);
				}
				if (dataSet.Tables.Count == 0)
				{
					RadMessageBox.Show(this, "An error has occurred.", "CIMitarAnalysis", MessageBoxButtons.OK, RadMessageIcon.Error);
					return;
				}
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					if (this.saveFileDialog.FilterIndex == 1)
					{
						SortedList sortedList = new SortedList();
						sortedList.Add(1, dataSet.Tables[0]);
						ExcelControl.SaveExcel(this.saveFileDialog.FileName, sortedList, true);
					}
					else
					{
						ExcelControl.generateCSV(this.saveFileDialog.FileName, dataSet.Tables[0], true);
					}
				}
				dataSet.Clear();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00005198 File Offset: 0x00003398
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000051B8 File Offset: 0x000033B8
		private void InitializeComponent()
		{
			this.radPanel2 = new RadPanel();
			this.btnRawData = new RadButton();
			this.btnNewDoc = new RadButton();
			this.btnSearch = new RadButton();
			this.radGroupBox8 = new RadGroupBox();
			this.rdoPassResult = new RadRadioButton();
			this.rdoAllResult = new RadRadioButton();
			this.rdoFailResult = new RadRadioButton();
			this.btnSave = new RadButton();
			this.radGroupBox1 = new RadGroupBox();
			this.rdo1st = new RadRadioButton();
			this.rdoFinal = new RadRadioButton();
			this.rdoAll = new RadRadioButton();
			this.radGroupBox3 = new RadGroupBox();
			this.chkcmb_ReportType = new RadCheckedDropDownList();
			this.radSplitContainer2 = new RadSplitContainer();
			this.splitPanel4 = new SplitPanel();
			this.radGroupBox2 = new RadGroupBox();
			this.grid_UnitList = new RadGridView();
			this.radDock1 = new RadDock();
			this.doc_Data = new DocumentWindow();
			this.grid_BinPareto = new RadGridView();
			this.grid_FailSummary = new RadGridView();
			this.grid_UnitData = new RadGridView();
			this.grid_Data = new RadGridView();
			this.toolTabStrip1 = new ToolTabStrip();
			this.toolWindow1 = new ToolWindow();
			this.documentContainer1 = new DocumentContainer();
			this.documentTabStrip1 = new DocumentTabStrip();
			this.telerikMetroBlueTheme1 = new TelerikMetroBlueTheme();
			this.radThemeManager1 = new RadThemeManager();
			this.saveFileDialog = new SaveFileDialog();
			((ISupportInitialize)this.radPanel2).BeginInit();
			this.radPanel2.SuspendLayout();
			((ISupportInitialize)this.btnRawData).BeginInit();
			((ISupportInitialize)this.btnNewDoc).BeginInit();
			((ISupportInitialize)this.btnSearch).BeginInit();
			((ISupportInitialize)this.radGroupBox8).BeginInit();
			this.radGroupBox8.SuspendLayout();
			((ISupportInitialize)this.rdoPassResult).BeginInit();
			((ISupportInitialize)this.rdoAllResult).BeginInit();
			((ISupportInitialize)this.rdoFailResult).BeginInit();
			((ISupportInitialize)this.btnSave).BeginInit();
			((ISupportInitialize)this.radGroupBox1).BeginInit();
			this.radGroupBox1.SuspendLayout();
			((ISupportInitialize)this.rdo1st).BeginInit();
			((ISupportInitialize)this.rdoFinal).BeginInit();
			((ISupportInitialize)this.rdoAll).BeginInit();
			((ISupportInitialize)this.radGroupBox3).BeginInit();
			this.radGroupBox3.SuspendLayout();
			((ISupportInitialize)this.chkcmb_ReportType).BeginInit();
			((ISupportInitialize)this.radSplitContainer2).BeginInit();
			this.radSplitContainer2.SuspendLayout();
			((ISupportInitialize)this.splitPanel4).BeginInit();
			this.splitPanel4.SuspendLayout();
			((ISupportInitialize)this.radGroupBox2).BeginInit();
			this.radGroupBox2.SuspendLayout();
			((ISupportInitialize)this.grid_UnitList).BeginInit();
			((ISupportInitialize)this.grid_UnitList.MasterTemplate).BeginInit();
			((ISupportInitialize)this.radDock1).BeginInit();
			this.radDock1.SuspendLayout();
			this.doc_Data.SuspendLayout();
			((ISupportInitialize)this.grid_BinPareto).BeginInit();
			((ISupportInitialize)this.grid_BinPareto.MasterTemplate).BeginInit();
			((ISupportInitialize)this.grid_FailSummary).BeginInit();
			((ISupportInitialize)this.grid_FailSummary.MasterTemplate).BeginInit();
			((ISupportInitialize)this.grid_UnitData).BeginInit();
			((ISupportInitialize)this.grid_UnitData.MasterTemplate).BeginInit();
			((ISupportInitialize)this.grid_Data).BeginInit();
			((ISupportInitialize)this.grid_Data.MasterTemplate).BeginInit();
			((ISupportInitialize)this.toolTabStrip1).BeginInit();
			this.toolTabStrip1.SuspendLayout();
			this.toolWindow1.SuspendLayout();
			((ISupportInitialize)this.documentContainer1).BeginInit();
			this.documentContainer1.SuspendLayout();
			((ISupportInitialize)this.documentTabStrip1).BeginInit();
			this.documentTabStrip1.SuspendLayout();
			base.SuspendLayout();
			this.radPanel2.BackColor = Color.White;
			this.radPanel2.Controls.Add(this.btnRawData);
			this.radPanel2.Controls.Add(this.btnSearch);
			this.radPanel2.Controls.Add(this.radGroupBox8);
			this.radPanel2.Controls.Add(this.btnSave);
			this.radPanel2.Controls.Add(this.radGroupBox1);
			this.radPanel2.Controls.Add(this.radGroupBox3);
			this.radPanel2.Dock = DockStyle.Top;
			this.radPanel2.Location = new Point(0, 0);
			this.radPanel2.Name = "radPanel2";
			this.radPanel2.Size = new Size(1000, 50);
			this.radPanel2.TabIndex = 6;
			this.btnRawData.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.btnRawData.Location = new Point(915, 11);
			this.btnRawData.Name = "btnRawData";
			this.btnRawData.Size = new Size(80, 32);
			this.btnRawData.TabIndex = 168;
			this.btnRawData.Text = "Fail RawData";
			this.btnRawData.ThemeName = "TelerikMetroBlue";
			this.btnRawData.Click += this.btnRawData_Click;
			this.btnNewDoc.Location = new Point(581, 345);
			this.btnNewDoc.Name = "btnNewDoc";
			this.btnNewDoc.Size = new Size(65, 32);
			this.btnNewDoc.TabIndex = 167;
			this.btnNewDoc.Text = "New Doc";
			this.btnNewDoc.ThemeName = "TelerikMetroBlue";
			this.btnNewDoc.Visible = false;
			this.btnNewDoc.Click += this.btnNewDoc_Click;
			this.btnSearch.Location = new Point(604, 11);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new Size(53, 32);
			this.btnSearch.TabIndex = 166;
			this.btnSearch.Text = "Search";
			this.btnSearch.ThemeName = "TelerikMetroBlue";
			this.btnSearch.Click += this.btnSearch_Click;
			this.radGroupBox8.AccessibleRole = AccessibleRole.Grouping;
			this.radGroupBox8.Controls.Add(this.rdoPassResult);
			this.radGroupBox8.Controls.Add(this.rdoAllResult);
			this.radGroupBox8.Controls.Add(this.rdoFailResult);
			this.radGroupBox8.HeaderText = "Test Result";
			this.radGroupBox8.Location = new Point(458, 4);
			this.radGroupBox8.Name = "radGroupBox8";
			this.radGroupBox8.Size = new Size(140, 42);
			this.radGroupBox8.TabIndex = 165;
			this.radGroupBox8.Text = "Test Result";
			this.radGroupBox8.ThemeName = "TelerikMetroBlue";
			((RadGroupBoxElement)this.radGroupBox8.GetChildAt(0)).Padding = new Padding(2, 18, 2, 2);
			((BorderPrimitive)this.radGroupBox8.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopColor = Color.FromArgb(240, 110, 170);
			((BorderPrimitive)this.radGroupBox8.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopShadowColor = Color.FromArgb(240, 110, 170);
			((BorderPrimitive)this.radGroupBox8.GetChildAt(0).GetChildAt(1).GetChildAt(1)).SmoothingMode = SmoothingMode.Default;
			this.rdoPassResult.Location = new Point(49, 21);
			this.rdoPassResult.Name = "rdoPassResult";
			this.rdoPassResult.Size = new Size(42, 18);
			this.rdoPassResult.TabIndex = 9;
			this.rdoPassResult.TabStop = false;
			this.rdoPassResult.Text = "Pass";
			this.rdoAllResult.CheckState = CheckState.Checked;
			this.rdoAllResult.Location = new Point(5, 21);
			this.rdoAllResult.Name = "rdoAllResult";
			this.rdoAllResult.Size = new Size(38, 18);
			this.rdoAllResult.TabIndex = 12;
			this.rdoAllResult.Text = "ALL";
			this.rdoAllResult.ToggleState = ToggleState.On;
			this.rdoFailResult.Location = new Point(97, 21);
			this.rdoFailResult.Name = "rdoFailResult";
			this.rdoFailResult.Size = new Size(37, 18);
			this.rdoFailResult.TabIndex = 11;
			this.rdoFailResult.TabStop = false;
			this.rdoFailResult.Text = "Fail";
			this.btnSave.Location = new Point(663, 11);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new Size(50, 32);
			this.btnSave.TabIndex = 164;
			this.btnSave.Text = "Save";
			this.btnSave.ThemeName = "TelerikMetroBlue";
			this.btnSave.Click += this.btnRawDataSave_Click;
			this.radGroupBox1.AccessibleRole = AccessibleRole.Grouping;
			this.radGroupBox1.Controls.Add(this.rdo1st);
			this.radGroupBox1.Controls.Add(this.rdoFinal);
			this.radGroupBox1.Controls.Add(this.rdoAll);
			this.radGroupBox1.HeaderText = "Test Type";
			this.radGroupBox1.Location = new Point(288, 4);
			this.radGroupBox1.Name = "radGroupBox1";
			this.radGroupBox1.Size = new Size(164, 42);
			this.radGroupBox1.TabIndex = 162;
			this.radGroupBox1.Text = "Test Type";
			this.radGroupBox1.ThemeName = "TelerikMetroBlue";
			((RadGroupBoxElement)this.radGroupBox1.GetChildAt(0)).Padding = new Padding(2, 18, 2, 2);
			((BorderPrimitive)this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopColor = Color.FromArgb(240, 110, 170);
			((BorderPrimitive)this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopShadowColor = Color.FromArgb(240, 110, 170);
			((BorderPrimitive)this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1)).SmoothingMode = SmoothingMode.Default;
			this.rdo1st.Location = new Point(51, 21);
			this.rdo1st.Name = "rdo1st";
			this.rdo1st.Size = new Size(35, 18);
			this.rdo1st.TabIndex = 12;
			this.rdo1st.TabStop = false;
			this.rdo1st.Text = "1st";
			this.rdoFinal.Location = new Point(95, 21);
			this.rdoFinal.Name = "rdoFinal";
			this.rdoFinal.Size = new Size(43, 18);
			this.rdoFinal.TabIndex = 11;
			this.rdoFinal.TabStop = false;
			this.rdoFinal.Text = "Final";
			this.rdoAll.CheckState = CheckState.Checked;
			this.rdoAll.Location = new Point(5, 21);
			this.rdoAll.Name = "rdoAll";
			this.rdoAll.Size = new Size(38, 18);
			this.rdoAll.TabIndex = 9;
			this.rdoAll.Text = "ALL";
			this.rdoAll.ToggleState = ToggleState.On;
			this.radGroupBox3.AccessibleRole = AccessibleRole.Grouping;
			this.radGroupBox3.Controls.Add(this.chkcmb_ReportType);
			this.radGroupBox3.HeaderText = "Type";
			this.radGroupBox3.Location = new Point(6, 4);
			this.radGroupBox3.Name = "radGroupBox3";
			this.radGroupBox3.Size = new Size(276, 42);
			this.radGroupBox3.TabIndex = 156;
			this.radGroupBox3.Text = "Type";
			this.radGroupBox3.ThemeName = "TelerikMetroBlue";
			((RadGroupBoxElement)this.radGroupBox3.GetChildAt(0)).Padding = new Padding(2, 18, 2, 2);
			((BorderPrimitive)this.radGroupBox3.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopColor = Color.FromArgb(240, 110, 170);
			((BorderPrimitive)this.radGroupBox3.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopShadowColor = Color.FromArgb(240, 110, 170);
			((BorderPrimitive)this.radGroupBox3.GetChildAt(0).GetChildAt(1).GetChildAt(1)).SmoothingMode = SmoothingMode.Default;
			this.chkcmb_ReportType.DefaultItemsCountInDropDown = 20;
			this.chkcmb_ReportType.Location = new Point(46, 17);
			this.chkcmb_ReportType.MaxDropDownItems = 50;
			this.chkcmb_ReportType.Name = "chkcmb_ReportType";
			this.chkcmb_ReportType.Size = new Size(225, 20);
			this.chkcmb_ReportType.TabIndex = 2;
			this.radSplitContainer2.Controls.Add(this.splitPanel4);
			this.radSplitContainer2.Dock = DockStyle.Fill;
			this.radSplitContainer2.IsCleanUpTarget = true;
			this.radSplitContainer2.Location = new Point(0, 0);
			this.radSplitContainer2.Name = "radSplitContainer2";
			this.radSplitContainer2.Orientation = Orientation.Horizontal;
			this.radSplitContainer2.Padding = new Padding(5);
			this.radSplitContainer2.RootElement.MinSize = new Size(0, 0);
			this.radSplitContainer2.Size = new Size(315, 531);
			this.radSplitContainer2.TabIndex = 0;
			this.radSplitContainer2.TabStop = false;
			this.radSplitContainer2.Text = "radSplitContainer2";
			this.radSplitContainer2.ThemeName = "TelerikMetroBlue";
			this.splitPanel4.Controls.Add(this.radGroupBox2);
			this.splitPanel4.Location = new Point(0, 0);
			this.splitPanel4.Name = "splitPanel4";
			this.splitPanel4.RootElement.MinSize = new Size(0, 0);
			this.splitPanel4.Size = new Size(315, 531);
			this.splitPanel4.SizeInfo.AutoSizeScale = new SizeF(0f, 0.3444445f);
			this.splitPanel4.SizeInfo.SplitterCorrection = new Size(0, 176);
			this.splitPanel4.TabIndex = 1;
			this.splitPanel4.TabStop = false;
			this.splitPanel4.Text = "splitPanel4";
			this.splitPanel4.ThemeName = "TelerikMetroBlue";
			this.radGroupBox2.AccessibleRole = AccessibleRole.Grouping;
			this.radGroupBox2.Controls.Add(this.grid_UnitList);
			this.radGroupBox2.Dock = DockStyle.Fill;
			this.radGroupBox2.Font = new Font("굴림", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 129);
			this.radGroupBox2.HeaderText = "";
			this.radGroupBox2.Location = new Point(0, 0);
			this.radGroupBox2.Name = "radGroupBox2";
			this.radGroupBox2.Padding = new Padding(2);
			this.radGroupBox2.Size = new Size(315, 531);
			this.radGroupBox2.TabIndex = 6;
			this.radGroupBox2.ThemeName = "TelerikMetroBlue";
			((RadGroupBoxElement)this.radGroupBox2.GetChildAt(0)).Padding = new Padding(2);
			((BorderPrimitive)this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopColor = Color.FromArgb(238, 236, 60);
			((BorderPrimitive)this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TopShadowColor = Color.FromArgb(238, 236, 60);
			((BorderPrimitive)this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(1)).SmoothingMode = SmoothingMode.Default;
			this.grid_UnitList.Dock = DockStyle.Fill;
			this.grid_UnitList.Location = new Point(2, 2);
			this.grid_UnitList.MasterTemplate.MultiSelect = true;
			this.grid_UnitList.Name = "grid_UnitList";
			this.grid_UnitList.Size = new Size(311, 527);
			this.grid_UnitList.TabIndex = 0;
			this.grid_UnitList.SelectionChanged += this.grid_UnitList_SelectionChanged;
			this.grid_UnitList.CellClick += this.grid_UnitList_CellClick;
			this.radDock1.ActiveWindow = this.doc_Data;
			this.radDock1.Controls.Add(this.toolTabStrip1);
			this.radDock1.Controls.Add(this.documentContainer1);
			this.radDock1.Cursor = Cursors.VSplit;
			this.radDock1.Dock = DockStyle.Fill;
			this.radDock1.IsCleanUpTarget = true;
			this.radDock1.Location = new Point(0, 50);
			this.radDock1.MainDocumentContainer = this.documentContainer1;
			this.radDock1.Name = "radDock1";
			this.radDock1.Padding = new Padding(0);
			this.radDock1.RootElement.MinSize = new Size(0, 0);
			this.radDock1.Size = new Size(1000, 563);
			this.radDock1.TabIndex = 0;
			this.radDock1.TabStop = false;
			this.radDock1.Text = "radDock1";
			this.radDock1.ThemeName = "TelerikMetroBlue";
			this.doc_Data.AutoScroll = true;
			this.doc_Data.Controls.Add(this.grid_BinPareto);
			this.doc_Data.Controls.Add(this.btnNewDoc);
			this.doc_Data.Controls.Add(this.grid_FailSummary);
			this.doc_Data.Controls.Add(this.grid_UnitData);
			this.doc_Data.Controls.Add(this.grid_Data);
			this.doc_Data.Location = new Point(5, 30);
			this.doc_Data.Name = "doc_Data";
			this.doc_Data.PreviousDockState = DockState.TabbedDocument;
			this.doc_Data.Size = new Size(669, 528);
			this.doc_Data.Text = "Doc";
			this.grid_BinPareto.Location = new Point(218, 188);
			this.grid_BinPareto.MasterTemplate.MultiSelect = true;
			this.grid_BinPareto.Name = "grid_BinPareto";
			this.grid_BinPareto.Size = new Size(206, 151);
			this.grid_BinPareto.TabIndex = 165;
			this.grid_BinPareto.Visible = false;
			this.grid_FailSummary.Location = new Point(440, 188);
			this.grid_FailSummary.MasterTemplate.MultiSelect = true;
			this.grid_FailSummary.Name = "grid_FailSummary";
			this.grid_FailSummary.Size = new Size(206, 151);
			this.grid_FailSummary.TabIndex = 164;
			this.grid_FailSummary.Visible = false;
			this.grid_UnitData.Location = new Point(440, 13);
			this.grid_UnitData.MasterTemplate.MultiSelect = true;
			this.grid_UnitData.Name = "grid_UnitData";
			this.grid_UnitData.Size = new Size(206, 151);
			this.grid_UnitData.TabIndex = 163;
			this.grid_UnitData.Visible = false;
			this.grid_Data.Location = new Point(218, 13);
			this.grid_Data.MasterTemplate.MultiSelect = true;
			this.grid_Data.Name = "grid_Data";
			this.grid_Data.Size = new Size(206, 151);
			this.grid_Data.TabIndex = 150;
			this.grid_Data.Visible = false;
			this.toolTabStrip1.CanUpdateChildIndex = true;
			this.toolTabStrip1.Controls.Add(this.toolWindow1);
			this.toolTabStrip1.Location = new Point(0, 0);
			this.toolTabStrip1.Name = "toolTabStrip1";
			this.toolTabStrip1.RootElement.MinSize = new Size(0, 0);
			this.toolTabStrip1.SelectedIndex = 0;
			this.toolTabStrip1.Size = new Size(317, 563);
			this.toolTabStrip1.SizeInfo.AbsoluteSize = new Size(317, 200);
			this.toolTabStrip1.SizeInfo.SplitterCorrection = new Size(117, 0);
			this.toolTabStrip1.TabIndex = 1;
			this.toolTabStrip1.TabStop = false;
			this.toolTabStrip1.ThemeName = "TelerikMetroBlue";
			this.toolWindow1.Caption = null;
			this.toolWindow1.Controls.Add(this.radSplitContainer2);
			this.toolWindow1.Location = new Point(1, 30);
			this.toolWindow1.Name = "toolWindow1";
			this.toolWindow1.PreviousDockState = DockState.Docked;
			this.toolWindow1.Size = new Size(315, 531);
			this.toolWindow1.Text = "Unit List";
			this.documentContainer1.Controls.Add(this.documentTabStrip1);
			this.documentContainer1.Name = "documentContainer1";
			this.documentContainer1.Orientation = Orientation.Horizontal;
			this.documentContainer1.RootElement.MinSize = new Size(0, 0);
			this.documentContainer1.SizeInfo.AbsoluteSize = new Size(679, 200);
			this.documentContainer1.SizeInfo.SizeMode = SplitPanelSizeMode.Fill;
			this.documentContainer1.SizeInfo.SplitterCorrection = new Size(-95, 0);
			this.documentContainer1.TabIndex = 2;
			this.documentContainer1.ThemeName = "TelerikMetroBlue";
			this.documentTabStrip1.CanUpdateChildIndex = true;
			this.documentTabStrip1.Controls.Add(this.doc_Data);
			this.documentTabStrip1.Location = new Point(0, 0);
			this.documentTabStrip1.Name = "documentTabStrip1";
			this.documentTabStrip1.RootElement.MinSize = new Size(0, 0);
			this.documentTabStrip1.SelectedIndex = 0;
			this.documentTabStrip1.Size = new Size(679, 563);
			this.documentTabStrip1.TabIndex = 0;
			this.documentTabStrip1.TabStop = false;
			this.documentTabStrip1.ThemeName = "TelerikMetroBlue";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.radDock1);
			base.Controls.Add(this.radPanel2);
			base.Name = "UnitDataResult";
			base.Size = new Size(1000, 613);
			base.Load += this.UnitDataResult_Load;
			((ISupportInitialize)this.radPanel2).EndInit();
			this.radPanel2.ResumeLayout(false);
			((ISupportInitialize)this.btnRawData).EndInit();
			((ISupportInitialize)this.btnNewDoc).EndInit();
			((ISupportInitialize)this.btnSearch).EndInit();
			((ISupportInitialize)this.radGroupBox8).EndInit();
			this.radGroupBox8.ResumeLayout(false);
			this.radGroupBox8.PerformLayout();
			((ISupportInitialize)this.rdoPassResult).EndInit();
			((ISupportInitialize)this.rdoAllResult).EndInit();
			((ISupportInitialize)this.rdoFailResult).EndInit();
			((ISupportInitialize)this.btnSave).EndInit();
			((ISupportInitialize)this.radGroupBox1).EndInit();
			this.radGroupBox1.ResumeLayout(false);
			this.radGroupBox1.PerformLayout();
			((ISupportInitialize)this.rdo1st).EndInit();
			((ISupportInitialize)this.rdoFinal).EndInit();
			((ISupportInitialize)this.rdoAll).EndInit();
			((ISupportInitialize)this.radGroupBox3).EndInit();
			this.radGroupBox3.ResumeLayout(false);
			this.radGroupBox3.PerformLayout();
			((ISupportInitialize)this.chkcmb_ReportType).EndInit();
			((ISupportInitialize)this.radSplitContainer2).EndInit();
			this.radSplitContainer2.ResumeLayout(false);
			((ISupportInitialize)this.splitPanel4).EndInit();
			this.splitPanel4.ResumeLayout(false);
			((ISupportInitialize)this.radGroupBox2).EndInit();
			this.radGroupBox2.ResumeLayout(false);
			((ISupportInitialize)this.grid_UnitList.MasterTemplate).EndInit();
			((ISupportInitialize)this.grid_UnitList).EndInit();
			((ISupportInitialize)this.radDock1).EndInit();
			this.radDock1.ResumeLayout(false);
			this.doc_Data.ResumeLayout(false);
			((ISupportInitialize)this.grid_BinPareto.MasterTemplate).EndInit();
			((ISupportInitialize)this.grid_BinPareto).EndInit();
			((ISupportInitialize)this.grid_FailSummary.MasterTemplate).EndInit();
			((ISupportInitialize)this.grid_FailSummary).EndInit();
			((ISupportInitialize)this.grid_UnitData.MasterTemplate).EndInit();
			((ISupportInitialize)this.grid_UnitData).EndInit();
			((ISupportInitialize)this.grid_Data.MasterTemplate).EndInit();
			((ISupportInitialize)this.grid_Data).EndInit();
			((ISupportInitialize)this.toolTabStrip1).EndInit();
			this.toolTabStrip1.ResumeLayout(false);
			this.toolWindow1.ResumeLayout(false);
			((ISupportInitialize)this.documentContainer1).EndInit();
			this.documentContainer1.ResumeLayout(false);
			((ISupportInitialize)this.documentTabStrip1).EndInit();
			this.documentTabStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private cMainData mData = new cMainData();

		// Token: 0x04000002 RID: 2
		private DataSet _dsMain = new DataSet();

		// Token: 0x04000003 RID: 3
		private SortedList _slData = new SortedList();

		// Token: 0x04000004 RID: 4
		private SortedList _slSelectData = new SortedList();

		// Token: 0x04000005 RID: 5
		private DataTable dtUnitList = new DataTable();

		// Token: 0x04000006 RID: 6
		private DataTable dtYieldData = new DataTable();

		// Token: 0x04000007 RID: 7
		private DataTable dtUnitData = new DataTable();

		// Token: 0x04000008 RID: 8
		private DataTable dtFailData = new DataTable();

		// Token: 0x04000009 RID: 9
		private DataTable dtBinParetoData = new DataTable();

		// Token: 0x0400000A RID: 10
		private Thread _thread;

		// Token: 0x0400000B RID: 11
		private BarPrograss _barPrograss;

		// Token: 0x0400000C RID: 12
		private IContainer components;

		// Token: 0x0400000D RID: 13
		private RadPanel radPanel2;

		// Token: 0x0400000E RID: 14
		private RadSplitContainer radSplitContainer2;

		// Token: 0x0400000F RID: 15
		private SplitPanel splitPanel4;

		// Token: 0x04000010 RID: 16
		private RadGroupBox radGroupBox2;

		// Token: 0x04000011 RID: 17
		private RadGridView grid_UnitList;

		// Token: 0x04000012 RID: 18
		private RadDock radDock1;

		// Token: 0x04000013 RID: 19
		private ToolWindow toolWindow1;

		// Token: 0x04000014 RID: 20
		private ToolTabStrip toolTabStrip1;

		// Token: 0x04000015 RID: 21
		private DocumentContainer documentContainer1;

		// Token: 0x04000016 RID: 22
		private DocumentTabStrip documentTabStrip1;

		// Token: 0x04000017 RID: 23
		private DocumentWindow doc_Data;

		// Token: 0x04000018 RID: 24
		private TelerikMetroBlueTheme telerikMetroBlueTheme1;

		// Token: 0x04000019 RID: 25
		private RadGroupBox radGroupBox3;

		// Token: 0x0400001A RID: 26
		private RadThemeManager radThemeManager1;

		// Token: 0x0400001B RID: 27
		private SaveFileDialog saveFileDialog;

		// Token: 0x0400001C RID: 28
		private RadGroupBox radGroupBox1;

		// Token: 0x0400001D RID: 29
		private RadRadioButton rdoFinal;

		// Token: 0x0400001E RID: 30
		private RadRadioButton rdoAll;

		// Token: 0x0400001F RID: 31
		private RadButton btnSave;

		// Token: 0x04000020 RID: 32
		private RadGroupBox radGroupBox8;

		// Token: 0x04000021 RID: 33
		private RadRadioButton rdoPassResult;

		// Token: 0x04000022 RID: 34
		private RadRadioButton rdoAllResult;

		// Token: 0x04000023 RID: 35
		private RadRadioButton rdoFailResult;

		// Token: 0x04000024 RID: 36
		private RadButton btnSearch;

		// Token: 0x04000025 RID: 37
		private RadGridView grid_Data;

		// Token: 0x04000026 RID: 38
		private RadButton btnNewDoc;

		// Token: 0x04000027 RID: 39
		private RadCheckedDropDownList chkcmb_ReportType;

		// Token: 0x04000028 RID: 40
		private RadGridView grid_UnitData;

		// Token: 0x04000029 RID: 41
		private RadRadioButton rdo1st;

		// Token: 0x0400002A RID: 42
		private RadGridView grid_FailSummary;

		// Token: 0x0400002B RID: 43
		private RadGridView grid_BinPareto;

		// Token: 0x0400002C RID: 44
		private RadButton btnRawData;
	}
}
