using System;
using System.Collections.Generic;
using System.Data;

namespace Amkor.CADModules.Maintenance.Class
{
	// Token: 0x02000057 RID: 87
	public class ReportList
	{
		// Token: 0x060005E8 RID: 1512 RVA: 0x0008BFE8 File Offset: 0x0008A1E8
		public ReportList(DataTableCollection dt)
		{
			this.listReport = new List<ReportList.ReportObject>();
			for (int i = 0; i < dt.Count; i++)
			{
				for (int j = 0; j < dt[i].Rows.Count; j++)
				{
					ReportList.ReportObject reportObject = new ReportList.ReportObject();
					bool flag = dt[i].Columns.Contains("status");
					if (flag)
					{
						bool flag2 = dt[i].Rows[j]["status"].ToString().CompareTo("1") == 0;
						if (flag2)
						{
							reportObject.Status = "Request";
						}
						else
						{
							bool flag3 = dt[i].Rows[j]["status"].ToString().CompareTo("2") == 0;
							if (flag3)
							{
								bool flag4 = dt[i].Columns.Contains("Hold");
								if (flag4)
								{
									bool flag5 = dt[i].Rows[j]["Hold"].ToString().CompareTo("1") == 0;
									if (flag5)
									{
										reportObject.Status = "Close(H)";
									}
									else
									{
										reportObject.Status = "Close";
									}
								}
							}
							else
							{
								bool flag6 = dt[i].Rows[j]["status"].ToString().CompareTo("3") == 0;
								if (flag6)
								{
									reportObject.Status = "Hold";
								}
								else
								{
									bool flag7 = dt[i].Rows[j]["status"].ToString().CompareTo("11") == 0;
									if (flag7)
									{
										reportObject.Status = "PM(Request)";
									}
									else
									{
										bool flag8 = dt[i].Rows[j]["status"].ToString().CompareTo("12") == 0;
										if (flag8)
										{
											reportObject.Status = "PM(Approval)";
										}
										else
										{
											bool flag9 = dt[i].Rows[j]["status"].ToString().CompareTo("13") == 0;
											if (flag9)
											{
												reportObject.Status = "PM(Done)";
											}
											else
											{
												bool flag10 = dt[i].Rows[j]["status"].ToString().CompareTo("14") == 0;
												if (flag10)
												{
													reportObject.Status = "PM(Final)";
												}
												else
												{
													bool flag11 = dt[i].Rows[j]["status"].ToString().CompareTo("98") == 0 || dt[i].Rows[j]["status"].ToString().CompareTo("97") == 0 || dt[i].Rows[j]["status"].ToString().Trim() == "96";
													if (flag11)
													{
														reportObject.Status = "PM(Cancel)";
													}
												}
											}
										}
									}
								}
							}
						}
					}
					bool flag12 = this.reportCount == 0L && dt[0].Columns.Contains("count");
					if (flag12)
					{
						long.TryParse(dt[i].Rows[j]["count"].ToString(), out this.reportCount);
					}
					bool flag13 = dt[i].Columns.Contains("ReportName");
					if (flag13)
					{
						reportObject.Report = dt[i].Rows[j]["ReportName"].ToString();
					}
					bool flag14 = dt[i].Columns.Contains("PMReport");
					if (flag14)
					{
						reportObject.Report = dt[i].Rows[j]["PMReport"].ToString();
					}
					bool flag15 = dt[i].Columns.Contains("RequestTime");
					if (flag15)
					{
						reportObject.RequestTime = dt[i].Rows[j]["RequestTime"].ToString();
					}
					bool flag16 = dt[i].Columns.Contains("StartTime");
					if (flag16)
					{
						bool flag17 = dt[i].Rows[j]["StartTime"].ToString().IndexOf("1900") != 0;
						if (flag17)
						{
							reportObject.StartTime = dt[i].Rows[j]["StartTime"].ToString();
						}
						else
						{
							reportObject.StartTime = string.Empty;
						}
					}
					bool flag18 = dt[i].Columns.Contains("HoldTime");
					if (flag18)
					{
						bool flag19 = dt[i].Rows[j]["HoldTime"] != null && !string.IsNullOrEmpty(dt[i].Rows[j]["HoldTime"].ToString()) && dt[i].Rows[j]["HoldTime"].ToString().IndexOf("1900") != 0;
						if (flag19)
						{
							reportObject.HoldTime = dt[i].Rows[j]["HoldTime"].ToString();
						}
						else
						{
							reportObject.HoldTime = string.Empty;
						}
					}
					bool flag20 = dt[i].Columns.Contains("EndTime");
					if (flag20)
					{
						bool flag21 = dt[i].Rows[j]["EndTime"].ToString().IndexOf("1900") != 0;
						if (flag21)
						{
							reportObject.EndTime = dt[i].Rows[j]["EndTime"].ToString();
						}
						else
						{
							reportObject.EndTime = string.Empty;
						}
					}
					bool flag22 = dt[i].Columns.Contains("FinalTime");
					if (flag22)
					{
						bool flag23 = dt[i].Rows[j]["FinalTime"].ToString().IndexOf("1900") != 0;
						if (flag23)
						{
							reportObject.FinalTime = dt[i].Rows[j]["FinalTime"].ToString();
						}
						else
						{
							reportObject.FinalTime = string.Empty;
						}
					}
					bool flag24 = dt[i].Columns.Contains("Team");
					if (flag24)
					{
						reportObject.Part_Team = dt[i].Rows[j]["Team"].ToString();
					}
					bool flag25 = dt[i].Columns.Contains("Category");
					if (flag25)
					{
						reportObject.Category = dt[i].Rows[j]["Category"].ToString();
					}
					bool flag26 = dt[i].Columns.Contains("Machine");
					if (flag26)
					{
						reportObject.Machine = dt[i].Rows[j]["Machine"].ToString();
					}
					bool flag27 = dt[i].Columns.Contains("Type");
					if (flag27)
					{
						reportObject.RscDec = dt[i].Rows[j]["Type"].ToString();
					}
					bool flag28 = dt[i].Columns.Contains("Model");
					if (flag28)
					{
						reportObject.Model = dt[i].Rows[j]["Model"].ToString();
					}
					bool flag29 = dt[i].Columns.Contains("Case");
					if (flag29)
					{
						reportObject.Case = dt[i].Rows[j]["Case"].ToString();
					}
					bool flag30 = dt[i].Columns.Contains("factor");
					if (flag30)
					{
						reportObject.Factor = dt[i].Rows[j]["factor"].ToString();
					}
					bool flag31 = dt[i].Columns.Contains("PMStatus");
					if (flag31)
					{
						reportObject.PMStatus = Convert.ToBoolean(dt[i].Rows[j]["PMStatus"].ToString());
					}
					bool flag32 = dt[i].Columns.Contains("diff");
					if (flag32)
					{
						bool flag33 = dt[i].Rows[j]["diff"].ToString().IndexOf("0") == -1;
						if (flag33)
						{
							reportObject.Difficult = dt[i].Rows[j]["diff"].ToString();
						}
						else
						{
							reportObject.Difficult = string.Empty;
						}
					}
					bool flag34 = dt[i].Columns.Contains("Emergency");
					if (flag34)
					{
						int priority;
						int.TryParse(dt[i].Rows[j]["Emergency"].ToString(), out priority);
						reportObject.Priority = priority;
					}
					bool flag35 = dt[i].Columns.Contains("CheckItem");
					if (flag35)
					{
						reportObject.CheckItem = dt[i].Rows[j]["CheckItem"].ToString();
					}
					bool flag36 = dt[i].Columns.Contains("Requirement");
					if (flag36)
					{
						reportObject.Requirment = dt[i].Rows[j]["Requirement"].ToString();
					}
					bool flag37 = dt[i].Columns.Contains("Result");
					if (flag37)
					{
						reportObject.Result = dt[i].Rows[j]["Result"].ToString();
					}
					bool flag38 = dt[i].Columns.Contains("Comment");
					if (flag38)
					{
						reportObject.Comment = dt[i].Rows[j]["Comment"].ToString();
					}
					bool flag39 = dt[i].Columns.Contains("Problem");
					if (flag39)
					{
						reportObject.Problem = dt[i].Rows[j]["Problem"].ToString();
					}
					bool flag40 = dt[i].Columns.Contains("Action");
					if (flag40)
					{
						reportObject.Action = dt[i].Rows[j]["Action"].ToString();
					}
					bool flag41 = dt[i].Columns.Contains("Plant");
					if (flag41)
					{
						reportObject.Plant = dt[i].Rows[j]["Plant"].ToString();
					}
					bool flag42 = dt[i].Columns.Contains("PMStatus");
					if (flag42)
					{
						reportObject.PMStatus = Convert.ToBoolean(dt[i].Rows[j]["PMStatus"].ToString());
					}
					bool flag43 = dt[i].Columns.Contains("Asset");
					if (flag43)
					{
						reportObject.PMAsset = dt[i].Rows[j]["Asset"].ToString();
					}
					bool flag44 = dt[i].Columns.Contains("ApprovalTime");
					if (flag44)
					{
						bool flag45 = dt[i].Rows[j]["ApprovalTime"].ToString().IndexOf("1900") != 0;
						if (flag45)
						{
							reportObject.PMApprovalTime = dt[i].Rows[j]["ApprovalTime"].ToString();
						}
						else
						{
							reportObject.PMApprovalTime = string.Empty;
						}
					}
					bool flag46 = dt[i].Columns.Contains("PMStatus");
					if (flag46)
					{
						reportObject.PMStatus = Convert.ToBoolean(dt[i].Rows[j]["PMStatus"].ToString());
					}
					bool flag47 = dt[i].Columns.Contains("WorkType");
					if (flag47)
					{
						reportObject.PMWorkType = dt[i].Rows[j]["WorkType"].ToString();
					}
					bool flag48 = dt[i].Columns.Contains("Vendor");
					if (flag48)
					{
						reportObject.PMVendor = dt[i].Rows[j]["Vendor"].ToString();
					}
					bool flag49 = dt[i].Columns.Contains("content1");
					if (flag49)
					{
						reportObject.Content1 = dt[i].Rows[j]["content1"].ToString();
					}
					bool flag50 = dt[i].Columns.Contains("content2");
					if (flag50)
					{
						reportObject.Content2 = dt[i].Rows[j]["content2"].ToString();
					}
					bool flag51 = dt[i].Columns.Contains("content3");
					if (flag51)
					{
						reportObject.Content3 = dt[i].Rows[j]["content3"].ToString();
					}
					bool flag52 = dt[i].Columns.Contains("content4");
					if (flag52)
					{
						reportObject.Content4 = dt[i].Rows[j]["content4"].ToString();
					}
					bool flag53 = dt[i].Columns.Contains("content5");
					if (flag53)
					{
						reportObject.Content5 = dt[i].Rows[j]["content5"].ToString();
					}
					bool flag54 = dt[i].Columns.Contains("content6");
					if (flag54)
					{
						reportObject.Content6 = dt[i].Rows[j]["content6"].ToString();
					}
					bool flag55 = dt[i].Columns.Contains("content7");
					if (flag55)
					{
						reportObject.Content7 = dt[i].Rows[j]["content7"].ToString();
					}
					bool flag56 = dt[i].Columns.Contains("content8");
					if (flag56)
					{
						reportObject.Content8 = dt[i].Rows[j]["content8"].ToString();
					}
					bool flag57 = dt[i].Columns.Contains("Name");
					if (flag57)
					{
						reportObject.requester = dt[i].Rows[j]["Name"].ToString();
					}
					this.listReport.Add(reportObject);
				}
			}
			this.listReport.Sort((ReportList.ReportObject x1, ReportList.ReportObject x2) => x2.RequestTime.CompareTo(x1.RequestTime));
			this.setIndex(0);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0008D114 File Offset: 0x0008B314
		public void setIndex(int startIndex)
		{
			int num = 0;
			this.listTeam.Clear();
			this.listModel.Clear();
			this.listMachine.Clear();
			this.listCase.Clear();
			this.listDifficulty.Clear();
			this.listStatus.Clear();
			this.listFactor.Clear();
			this.listPMTeam.Clear();
			this.listPMModel.Clear();
			this.listPMMachine.Clear();
			this.listPMCase.Clear();
			this.listPMStatus.Clear();
			this.listPMFactor.Clear();
			this.listPMWorkType.Clear();
			this.listPMVendor.Clear();
			this.listPMAsset.Clear();
			this.listCategory.Clear();
			foreach (ReportList.ReportObject reportObject in this.listReport)
			{
				num++;
				this.listCategory.Add(reportObject.Category);
				this.listTotalModel.Add(reportObject.Model);
				bool flag = reportObject.Status == "PM(Final)" || reportObject.Status == "PM(Request)" || reportObject.Status == "PM(Approval)" || reportObject.Status == "PM(Done)" || reportObject.Status == "PM(Cancel)";
				if (flag)
				{
					bool flag2 = this.listPMTeam.IndexOf(reportObject.Part_Team) == -1;
					if (flag2)
					{
						this.listPMTeam.Add(reportObject.Part_Team);
					}
					bool flag3 = this.listPMModel.IndexOf(reportObject.Model) == -1;
					if (flag3)
					{
						this.listPMModel.Add(reportObject.Model);
					}
					bool flag4 = this.listPMMachine.IndexOf(reportObject.Machine) == -1;
					if (flag4)
					{
						this.listPMMachine.Add(reportObject.Machine);
					}
					bool flag5 = this.listPMCase.IndexOf(reportObject.Case) == -1;
					if (flag5)
					{
						this.listPMCase.Add(reportObject.Case);
					}
					bool flag6 = this.listPMAsset.IndexOf(reportObject.PMAsset) == -1;
					if (flag6)
					{
						this.listPMAsset.Add(reportObject.PMAsset);
					}
					bool flag7 = this.listDifficulty.IndexOf(reportObject.Difficult) == -1;
					if (flag7)
					{
						this.listDifficulty.Add(reportObject.Difficult);
					}
					bool flag8 = reportObject.Status != null && this.listPMStatus.IndexOf(reportObject.Status) == -1;
					if (flag8)
					{
						this.listPMStatus.Add(reportObject.Status);
					}
					bool flag9 = this.listPMFactor.IndexOf(reportObject.Factor) == -1;
					if (flag9)
					{
						this.listPMFactor.Add(reportObject.Factor);
					}
					bool flag10 = this.listPMWorkType.IndexOf(reportObject.PMWorkType) == -1;
					if (flag10)
					{
						this.listPMWorkType.Add(reportObject.PMWorkType);
					}
					bool flag11 = this.listPMVendor.IndexOf(reportObject.PMVendor) == -1;
					if (flag11)
					{
						this.listPMVendor.Add(reportObject.PMVendor);
					}
				}
				else
				{
					bool flag12 = this.listTeam.IndexOf(reportObject.Part_Team) == -1;
					if (flag12)
					{
						this.listTeam.Add(reportObject.Part_Team);
					}
					bool flag13 = this.listModel.IndexOf(reportObject.Model) == -1;
					if (flag13)
					{
						this.listModel.Add(reportObject.Model);
					}
					bool flag14 = this.listMachine.IndexOf(reportObject.Machine) == -1;
					if (flag14)
					{
						this.listMachine.Add(reportObject.Machine);
					}
					bool flag15 = this.listCase.IndexOf(reportObject.Case) == -1;
					if (flag15)
					{
						this.listCase.Add(reportObject.Case);
					}
					bool flag16 = this.listDifficulty.IndexOf(reportObject.Difficult) == -1;
					if (flag16)
					{
						this.listDifficulty.Add(reportObject.Difficult);
					}
					bool flag17 = reportObject.Status != null && this.listStatus.IndexOf(reportObject.Status) == -1;
					if (flag17)
					{
						this.listStatus.Add(reportObject.Status);
					}
					bool flag18 = this.listFactor.IndexOf(reportObject.Factor) == -1;
					if (flag18)
					{
						this.listFactor.Add(reportObject.Factor);
					}
				}
			}
			this.listCategory.Sort();
			this.listTeam.Sort();
			this.listModel.Sort();
			this.listMachine.Sort();
			this.listCase.Sort();
			this.listDifficulty.Sort();
			this.listStatus.Sort();
			this.listFactor.Sort();
			this.listPMTeam.Sort();
			this.listPMModel.Sort();
			this.listPMMachine.Sort();
			this.listPMCase.Sort();
			this.listPMStatus.Sort();
			this.listPMFactor.Sort();
			this.listPMWorkType.Sort();
			this.listPMVendor.Sort();
			this.listPMAsset.Sort();
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0008D6C8 File Offset: 0x0008B8C8
		public ReportList(DataTableCollection dt, List<ReportList.ReportObject> listReport, bool bPrevious)
		{
			bool flag = !bPrevious;
			if (flag)
			{
				this.listReport = listReport;
				for (int i = 0; i < dt.Count; i++)
				{
					for (int j = 0; j < dt[0].Rows.Count; j++)
					{
						ReportList.ReportObject reportObject = new ReportList.ReportObject();
						bool flag2 = dt[i].Columns.Contains("status");
						if (flag2)
						{
							bool flag3 = dt[i].Rows[j]["status"].ToString().CompareTo("1") == 0;
							if (flag3)
							{
								reportObject.Status = string.Empty;
							}
							else
							{
								bool flag4 = dt[i].Rows[j]["status"].ToString().CompareTo("2") == 0;
								if (flag4)
								{
									bool flag5 = dt[i].Rows[j]["Hold"].ToString().CompareTo("1") == 0;
									if (flag5)
									{
										reportObject.Status = "Close(H)";
									}
									else
									{
										reportObject.Status = "Close";
									}
								}
								else
								{
									bool flag6 = dt[i].Rows[j]["status"].ToString().CompareTo("3") == 0;
									if (flag6)
									{
										reportObject.Status = "Hold";
									}
									else
									{
										bool flag7 = dt[i].Rows[j]["status"].ToString().CompareTo("11") == 0;
										if (flag7)
										{
											reportObject.Status = "PM(Request)";
										}
									}
								}
							}
						}
						reportObject.Report = dt[i].Rows[j]["ReportName"].ToString();
						bool flag8 = dt[0].Columns.Contains("RequestTime");
						if (flag8)
						{
							reportObject.RequestTime = dt[0].Rows[j]["RequestTime"].ToString();
						}
						bool flag9 = dt[i].Columns.Contains("StartTime");
						if (flag9)
						{
							bool flag10 = dt[i].Rows[j]["StartTime"].ToString().IndexOf("1900") != 0;
							if (flag10)
							{
								reportObject.StartTime = dt[i].Rows[j]["StartTime"].ToString();
							}
							else
							{
								reportObject.StartTime = string.Empty;
							}
						}
						bool flag11 = dt[i].Columns.Contains("EndTime");
						if (flag11)
						{
							bool flag12 = dt[i].Rows[j]["EndTime"].ToString().IndexOf("1900") != 0;
							if (flag12)
							{
								reportObject.EndTime = dt[i].Rows[j]["EndTime"].ToString();
							}
							else
							{
								reportObject.EndTime = string.Empty;
							}
						}
						bool flag13 = dt[i].Columns.Contains("HoldTime");
						if (flag13)
						{
							bool flag14 = dt[i].Rows[j]["HoldTime"] != null && dt[i].Rows[j]["HoldTime"].ToString().IndexOf("1900") != 0;
							if (flag14)
							{
								reportObject.HoldTime = dt[i].Rows[j]["EndTime"].ToString();
							}
							else
							{
								reportObject.HoldTime = string.Empty;
							}
						}
						reportObject.Part_Team = dt[i].Rows[j]["Team"].ToString();
						reportObject.Category = dt[i].Rows[j]["Category"].ToString();
						reportObject.Machine = dt[i].Rows[j]["Machine"].ToString();
						reportObject.RscDec = dt[i].Rows[j]["Type"].ToString();
						reportObject.Model = dt[i].Rows[j]["Model"].ToString();
						reportObject.Case = dt[i].Rows[j]["Case"].ToString();
						bool flag15 = dt[i].Columns.Contains("factor");
						if (flag15)
						{
							reportObject.Factor = dt[i].Rows[j]["factor"].ToString();
						}
						bool flag16 = dt[i].Columns.Contains("diff");
						if (flag16)
						{
							bool flag17 = dt[i].Rows[j]["diff"].ToString().IndexOf("0") == -1;
							if (flag17)
							{
								reportObject.Difficult = dt[i].Rows[j]["diff"].ToString();
							}
							else
							{
								reportObject.Difficult = string.Empty;
							}
						}
						bool flag18 = dt[i].Columns.Contains("CheckItem");
						if (flag18)
						{
							reportObject.CheckItem = dt[i].Rows[j]["CheckItem"].ToString();
						}
						bool flag19 = dt[i].Columns.Contains("Requirement");
						if (flag19)
						{
							reportObject.Requirment = dt[i].Rows[j]["Requirement"].ToString();
						}
						bool flag20 = dt[i].Columns.Contains("Problem");
						if (flag20)
						{
							reportObject.Problem = dt[i].Rows[j]["Problem"].ToString();
						}
						bool flag21 = dt[i].Columns.Contains("Action");
						if (flag21)
						{
							reportObject.Action = dt[i].Rows[j]["Action"].ToString();
						}
						bool flag22 = dt[i].Columns.Contains("Result");
						if (flag22)
						{
							reportObject.Result = dt[i].Rows[j]["Result"].ToString();
						}
						bool flag23 = dt[i].Columns.Contains("Comment");
						if (flag23)
						{
							reportObject.Comment = dt[i].Rows[j]["Comment"].ToString();
						}
						bool flag24 = this.listTeam.IndexOf(reportObject.Part_Team) == -1;
						if (flag24)
						{
							this.listTeam.Add(reportObject.Part_Team);
						}
						bool flag25 = this.listModel.IndexOf(reportObject.Model) == -1;
						if (flag25)
						{
							this.listModel.Add(reportObject.Model);
						}
						bool flag26 = this.listMachine.IndexOf(reportObject.Machine) == -1;
						if (flag26)
						{
							this.listMachine.Add(reportObject.Machine);
						}
						bool flag27 = this.listCase.IndexOf(reportObject.Case) == -1;
						if (flag27)
						{
							this.listCase.Add(reportObject.Case);
						}
						bool flag28 = this.listDifficulty.IndexOf(reportObject.Difficult) == -1;
						if (flag28)
						{
							this.listDifficulty.Add(reportObject.Difficult);
						}
						bool flag29 = reportObject.Status != null && this.listStatus.IndexOf(reportObject.Status) == -1;
						if (flag29)
						{
							this.listStatus.Add(reportObject.Status);
						}
						this.listTeam.Sort();
						this.listModel.Sort();
						this.listMachine.Sort();
						this.listCase.Sort();
						this.listDifficulty.Sort();
						this.listStatus.Sort();
						this.listReport.Add(reportObject);
					}
				}
			}
			else
			{
				this.listReport = listReport;
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0008E088 File Offset: 0x0008C288
		public void ClearListBuffer()
		{
			this.listReport.Clear();
			this.listTeam.Clear();
			this.listModel.Clear();
			this.listMachine.Clear();
			this.listCase.Clear();
			this.listDifficulty.Clear();
			this.listStatus.Clear();
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0008E0EC File Offset: 0x0008C2EC
		public List<ReportList.ReportObject> getList()
		{
			return this.listReport;
		}

		// Token: 0x04000734 RID: 1844
		public long reportCount = 0L;

		// Token: 0x04000735 RID: 1845
		public readonly List<ReportList.ReportObject> listReport;

		// Token: 0x04000736 RID: 1846
		public readonly List<string> listCategory = new List<string>();

		// Token: 0x04000737 RID: 1847
		public readonly List<string> listTeam = new List<string>();

		// Token: 0x04000738 RID: 1848
		public readonly List<string> listModel = new List<string>();

		// Token: 0x04000739 RID: 1849
		public readonly List<string> listMachine = new List<string>();

		// Token: 0x0400073A RID: 1850
		public readonly List<string> listCase = new List<string>();

		// Token: 0x0400073B RID: 1851
		public readonly List<string> listDifficulty = new List<string>();

		// Token: 0x0400073C RID: 1852
		public readonly List<string> listStatus = new List<string>();

		// Token: 0x0400073D RID: 1853
		public readonly List<string> listFactor = new List<string>();

		// Token: 0x0400073E RID: 1854
		public readonly List<string> listPMTeam = new List<string>();

		// Token: 0x0400073F RID: 1855
		public readonly List<string> listPMModel = new List<string>();

		// Token: 0x04000740 RID: 1856
		public readonly List<string> listPMMachine = new List<string>();

		// Token: 0x04000741 RID: 1857
		public readonly List<string> listPMCase = new List<string>();

		// Token: 0x04000742 RID: 1858
		public readonly List<string> listPMStatus = new List<string>();

		// Token: 0x04000743 RID: 1859
		public readonly List<string> listPMFactor = new List<string>();

		// Token: 0x04000744 RID: 1860
		public readonly List<string> listPMWorkType = new List<string>();

		// Token: 0x04000745 RID: 1861
		public readonly List<string> listPMVendor = new List<string>();

		// Token: 0x04000746 RID: 1862
		public readonly List<string> listPMAsset = new List<string>();

		// Token: 0x04000747 RID: 1863
		public readonly List<string> listTotalModel = new List<string>();

		// Token: 0x0200009D RID: 157
		public class ReportObject
		{
			// Token: 0x0400081F RID: 2079
			public string Report = string.Empty;

			// Token: 0x04000820 RID: 2080
			public string Status = string.Empty;

			// Token: 0x04000821 RID: 2081
			public string RequestTime = string.Empty;

			// Token: 0x04000822 RID: 2082
			public string StartTime = string.Empty;

			// Token: 0x04000823 RID: 2083
			public string EndTime = string.Empty;

			// Token: 0x04000824 RID: 2084
			public string FinalTime = string.Empty;

			// Token: 0x04000825 RID: 2085
			public string Part_Team = string.Empty;

			// Token: 0x04000826 RID: 2086
			public string Category = string.Empty;

			// Token: 0x04000827 RID: 2087
			public string Machine = string.Empty;

			// Token: 0x04000828 RID: 2088
			public string RscDec = string.Empty;

			// Token: 0x04000829 RID: 2089
			public string Model = string.Empty;

			// Token: 0x0400082A RID: 2090
			public string Case = string.Empty;

			// Token: 0x0400082B RID: 2091
			public string Difficult = string.Empty;

			// Token: 0x0400082C RID: 2092
			public string CheckItem = string.Empty;

			// Token: 0x0400082D RID: 2093
			public string Requirment = string.Empty;

			// Token: 0x0400082E RID: 2094
			public string Problem = string.Empty;

			// Token: 0x0400082F RID: 2095
			public string Action = string.Empty;

			// Token: 0x04000830 RID: 2096
			public string Plant = string.Empty;

			// Token: 0x04000831 RID: 2097
			public string Factor = string.Empty;

			// Token: 0x04000832 RID: 2098
			public string HoldTime = string.Empty;

			// Token: 0x04000833 RID: 2099
			public string Result = string.Empty;

			// Token: 0x04000834 RID: 2100
			public string Comment = string.Empty;

			// Token: 0x04000835 RID: 2101
			public string PMAsset = string.Empty;

			// Token: 0x04000836 RID: 2102
			public string PMApprovalTime = string.Empty;

			// Token: 0x04000837 RID: 2103
			public string PMWorkType = string.Empty;

			// Token: 0x04000838 RID: 2104
			public string PMVendor = string.Empty;

			// Token: 0x04000839 RID: 2105
			public bool PMStatus = false;

			// Token: 0x0400083A RID: 2106
			public int Priority = 0;

			// Token: 0x0400083B RID: 2107
			public string requester = string.Empty;

			// Token: 0x0400083C RID: 2108
			public string Content1 = string.Empty;

			// Token: 0x0400083D RID: 2109
			public string Content2 = string.Empty;

			// Token: 0x0400083E RID: 2110
			public string Content3 = string.Empty;

			// Token: 0x0400083F RID: 2111
			public string Content4 = string.Empty;

			// Token: 0x04000840 RID: 2112
			public string Content5 = string.Empty;

			// Token: 0x04000841 RID: 2113
			public string Content6 = string.Empty;

			// Token: 0x04000842 RID: 2114
			public string Content7 = string.Empty;

			// Token: 0x04000843 RID: 2115
			public string Content8 = string.Empty;
		}
	}
}
