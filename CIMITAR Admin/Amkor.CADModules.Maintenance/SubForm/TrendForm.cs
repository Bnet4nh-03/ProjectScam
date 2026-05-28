using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000F RID: 15
	public partial class TrendForm : BaseWinView, IHCC
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00029CCA File Offset: 0x00027ECA
		private void TrendForm_Load(object sender, EventArgs e)
		{
			this.tvList.DrawMode = TreeViewDrawMode.OwnerDrawText;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00029CD9 File Offset: 0x00027ED9
		private void TrendForm_Shown(object sender, EventArgs e)
		{
			this.initTreeView();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00029CE2 File Offset: 0x00027EE2
		private void btnGridClose_Click(object sender, EventArgs e)
		{
			this.splitContainer2.SplitterDistance = 0;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00029CF1 File Offset: 0x00027EF1
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00029CFF File Offset: 0x00027EFF
		public HCC _hCC { get; }

		// Token: 0x060000FB RID: 251 RVA: 0x00029D08 File Offset: 0x00027F08
		public TrendForm(CIMitarAccount _cimitarUser, FactorySettings factorySetting)
		{
			this._hCC = new HCC(factorySetting, factorySetting._factoryName, true);
			this._factorySetting = factorySetting;
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._queryMgr = new QueryMgr(this._factorySetting);
			this.DoubleBuffered = true;
			this._cimitarUser = _cimitarUser;
			this.InitializeComponent();
			base.Tag = MainPageType.Analysis;
			this.pnIndexType.Visible = false;
			this._listFacotr.Clear();
			this.pnChartMode.Visible = false;
			this.splitContainer2.SplitterDistance = 0;
			this.splitContainer3.SplitterDistance = 0;
			this.dtStartDate.Value = this.dtStartDate.Value.AddDays(-2.0);
			this.dtEndDate.Value = this.dtEndDate.Value.AddDays(-1.0);
			this.tcMainPage.TabPages.Remove(this.tabDeviceTrend);
			bool flag = this._factorySetting._factoryName == "ATK_E";
			if (flag)
			{
				this.rbK3.Visible = false;
				this.rbK5.Visible = false;
				this.rbK3EV.Visible = true;
				this.rbK5M.Visible = false;
			}
			else
			{
				bool flag2 = this._factorySetting._factoryName == "ATK_K5_M";
				if (flag2)
				{
					this.rbK3.Visible = false;
					this.rbK5.Visible = false;
					this.rbK3EV.Visible = false;
					this.rbK5M.Visible = true;
				}
				else
				{
					bool flag3 = this._factorySetting._factoryName == "ATK_K5";
					if (flag3)
					{
						this.rbK3.Visible = false;
						this.rbK5.Visible = true;
						this.rbK3EV.Visible = false;
						this.rbK5M.Visible = false;
					}
					else
					{
						this.rbK3.Visible = true;
						this.rbK5.Visible = true;
						this.rbK3EV.Visible = false;
						this.rbK5M.Visible = false;
					}
				}
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void initTreeView()
		{
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00029FAC File Offset: 0x000281AC
		private void subCheckNode(TreeNode node, bool bChecked)
		{
			bool flag = node != null;
			if (flag)
			{
				foreach (object obj in node.Nodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					treeNode.Checked = bChecked;
					bool flag2 = treeNode.Nodes.Count != 0;
					if (flag2)
					{
						this.subCheckNode(treeNode, bChecked);
					}
				}
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0002A034 File Offset: 0x00028234
		private bool checkStatus()
		{
			foreach (object obj in this.tvList.Nodes[0].Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				bool flag = treeNode.Nodes != null;
				if (flag)
				{
					foreach (object obj2 in treeNode.Nodes)
					{
						TreeNode treeNode2 = (TreeNode)obj2;
						bool flag2 = treeNode2.Nodes != null;
						if (flag2)
						{
							foreach (object obj3 in treeNode2.Nodes)
							{
								TreeNode treeNode3 = (TreeNode)obj3;
								bool @checked = treeNode3.Checked;
								if (@checked)
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0002A178 File Offset: 0x00028378
		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.bHandlerUtiliMode = false;
			this.splitContainer3.SplitterDistance = 0;
			this.splitContainer2.SplitterDistance = 0;
			string key = string.Empty;
			string text = string.Empty;
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Search Data....");
			this._barPrograss.setValue(100);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			bool flag = this.tcMainPage.SelectedTab != this.tbBoardTrend && this.tcMainPage.SelectedTab != this.tpHandlerUtili && this.tcMainPage.SelectedTab != this.tpTesterUtili && this.tcMainPage.SelectedTab != this.tabDeviceTrend;
			if (flag)
			{
				bool flag2 = this.dtStartDate.Value > this.dtEndDate.Value;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("check_period"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK);
					return;
				}
				bool flag3 = this.tvList.Nodes.Count == 0;
				if (flag3)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_factory"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				bool flag4 = !this.checkStatus();
				if (flag4)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_machine"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				this.list.Clear();
				text = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTrendData]@_StartDate=N'",
					this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00"),
					"', @_EndDate=N'",
					this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59"),
					"', @_flag=N'0', @_MTTRStartTime=N'",
					this.rbStartTime.Checked ? "1" : "0",
					"'"
				});
				bool @checked = this.rbK3.Checked;
				if (@checked)
				{
					text += ", @_Plant=N'K3'";
					key = "K3";
				}
				else
				{
					bool checked2 = this.rbK4.Checked;
					if (checked2)
					{
						text += ", @_Plant=N'K4'";
						key = "K4";
					}
					else
					{
						bool checked3 = this.rbK5.Checked;
						if (checked3)
						{
							text += ", @_Plant=N'K5'";
							key = "K5";
						}
						else
						{
							bool checked4 = this.rbK3EV.Checked;
							if (checked4)
							{
								text += ", @_Plant=N'K3_E'";
								key = "K3 E";
							}
							else
							{
								bool checked5 = this.rbK5M.Checked;
								if (checked5)
								{
									text += ", @_Plant=N'K5_M'";
									key = "K5 M";
								}
							}
						}
					}
				}
				DataSet dataSet = this._queryMgr.queryCall(text);
				bool flag5 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag5)
				{
					ReportList value = new ReportList(dataSet.Tables);
					this.list.Add(key, value);
				}
				switch (this.tcMainPage.SelectedIndex)
				{
				case 0:
					this.rbEquipment.Checked = true;
					this.pnChartMode.Visible = true;
					this.maintTrend();
					break;
				case 1:
					this.pnFactorBase.Visible = false;
					this.pnFactorBase2.Visible = false;
					this.pnFactorBase3.Visible = false;
					this.rbCaseEquipment.Checked = true;
					this.pnCaseChartMode.Visible = true;
					this.maintCaseTrend();
					break;
				case 2:
					this.pnOEEBase.Visible = true;
					this.pnOEEMode.Visible = true;
					this.pnZoom.Visible = true;
					this.maintOEETrend();
					break;
				}
			}
			else
			{
				bool flag6 = this.tcMainPage.SelectedTab == this.tbBoardTrend;
				if (flag6)
				{
					this.splitContainer4.SplitterDistance = 0;
					this.pnDetailSiteChart.Controls.Clear();
					this.pnDetailSiteChart.Visible = false;
					Chart chart = null;
					Chart chart2 = null;
					this.setBoardChart(out chart, true);
					this.setBoardChart(out chart2, false);
					this.setboardTrend(chart, chart2);
				}
				else
				{
					bool flag7 = this.dtStartDate.Value > this.dtEndDate.Value;
					if (flag7)
					{
						MessageBox.Show(MessageLanguage.getMessage("check_period"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK);
						return;
					}
					switch (this.tcMainPage.SelectedIndex)
					{
					case 3:
						this.getHandlerUtilization();
						break;
					case 4:
						this.getTesterUtilization();
						break;
					case 5:
						this.calculateDeviceTrend();
						break;
					}
				}
			}
			this._barPrograss.setMax(100);
			this._barPrograss.setValue(100);
			Thread.Sleep(100);
			bool flag8 = this._barPrograss != null;
			if (flag8)
			{
				this._barPrograss._ischeck = true;
			}
			this._barPrograss = null;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0002A6A0 File Offset: 0x000288A0
		private void getHandlerUtilization()
		{
			this.setUtilGridHeader();
			this.getUtilizationHandler();
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0002A6B1 File Offset: 0x000288B1
		private void getTesterUtilization()
		{
			this.setUtilGridTester();
			this.getUtilizationTester();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0002A6C4 File Offset: 0x000288C4
		private void setListbyReport()
		{
			this.tvList.Nodes.Clear();
			foreach (string text in this.list.Keys)
			{
				cFunction.getCategoryList(this._factorySetting, text, null, false, false);
				this.tvList.Nodes.Add(text, text);
				this.tvList.Nodes[text].Tag = "X";
				foreach (object obj in this.tvList.Nodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					foreach (string text2 in cConst.sCategory)
					{
						treeNode.Nodes.Add(text2, text2);
						treeNode.Nodes[text2].Tag = "X";
					}
					foreach (ReportList.ReportObject reportObject in this.list[text].getList())
					{
						bool flag = !treeNode.Nodes.ContainsKey(reportObject.Category);
						if (!flag)
						{
							bool flag2 = !treeNode.Nodes[reportObject.Category].Nodes.ContainsKey(reportObject.Model);
							if (flag2)
							{
								treeNode.Nodes[reportObject.Category].Nodes.Add(reportObject.Model, reportObject.Model);
								treeNode.Nodes[reportObject.Category].Tag = "X";
							}
							bool flag3 = !treeNode.Nodes[reportObject.Category].Nodes[reportObject.Model].Nodes.ContainsKey(reportObject.Machine);
							if (flag3)
							{
								treeNode.Nodes[reportObject.Category].Nodes[reportObject.Model].Nodes.Add(reportObject.Machine, reportObject.Machine);
							}
						}
					}
				}
			}
			this.tvList.Sort();
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0002A9CC File Offset: 0x00028BCC
		private void maintTrend()
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			this.setMaintChart();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			DateTime t = new DateTime(this.dtStartDate.Value.Year, this.dtStartDate.Value.Month, this.dtStartDate.Value.Day, 0, 0, 0);
			DateTime t2 = new DateTime(this.dtEndDate.Value.Year, this.dtEndDate.Value.Month, this.dtEndDate.Value.Day, 23, 59, 59);
			this.tbChartZoom.Value = 0;
			bool flag = this.tvList.Nodes.Count == 0 || this.list.Count == 0;
			if (!flag)
			{
				foreach (object obj in this.tvList.Nodes[0].Nodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					foreach (object obj2 in treeNode.Nodes)
					{
						TreeNode treeNode2 = (TreeNode)obj2;
						foreach (object obj3 in treeNode2.Nodes)
						{
							TreeNode treeNode3 = (TreeNode)obj3;
							bool flag2 = this.rbEquipment.Checked && treeNode3.Checked;
							if (flag2)
							{
								foreach (ReportList.ReportObject reportObject in this.list[this.tvList.Nodes[0].Text].getList())
								{
									bool flag3 = reportObject.Machine == treeNode3.Text;
									if (flag3)
									{
										DateTime t3;
										DateTime.TryParse(reportObject.RequestTime, out t3);
										bool flag4 = DateTime.TryParse(reportObject.RequestTime, out t3);
										if (flag4)
										{
											bool flag5 = !(t <= t3) && t2 > t3;
											if (flag5)
											{
												continue;
											}
										}
										string status = reportObject.Status;
										if (!(status == "Request") && (status == null || status.Length != 0))
										{
											if (!(status == "Close") && !(status == "Close(H)"))
											{
												if (status == "Hold")
												{
													num4++;
												}
											}
											else
											{
												num3++;
											}
										}
										else
										{
											num2++;
										}
									}
								}
								this.maintTrendChart.Series[0].Points.AddXY((double)num, (double)num2);
								this.maintTrendChart.Series[1].Points.AddXY((double)num, (double)num3);
								this.maintTrendChart.Series[2].Points.AddXY((double)num, (double)num4);
								this.maintTrendChart.Series[0].Points[num].AxisLabel = treeNode3.Text;
								this.maintTrendChart.Series[0].ToolTip = "#SERIESNAME #VALY{D}";
								this.maintTrendChart.Series[1].ToolTip = "#SERIESNAME #VALY{D}";
								this.maintTrendChart.Series[2].ToolTip = "#SERIESNAME #VALY{D}";
								bool flag6 = num2 != 0;
								if (flag6)
								{
									this.maintTrendChart.Series[0].Points[num].Label = num2.ToString();
								}
								bool flag7 = num3 != 0;
								if (flag7)
								{
									this.maintTrendChart.Series[1].Points[num].Label = num3.ToString();
								}
								bool flag8 = num4 != 0;
								if (flag8)
								{
									this.maintTrendChart.Series[2].Points[num].Label = num4.ToString();
								}
								num++;
								num2 = 0;
								num3 = 0;
								num4 = 0;
							}
							else
							{
								bool flag9 = this.rbModel.Checked && treeNode3.Checked;
								if (flag9)
								{
									bool flag10 = list.Contains(treeNode2.Text);
									if (!flag10)
									{
										list.Add(treeNode2.Text);
										foreach (ReportList.ReportObject reportObject2 in this.list[this.tvList.Nodes[0].Text].getList())
										{
											bool flag11 = reportObject2.Model == treeNode2.Text;
											if (flag11)
											{
												DateTime t4;
												DateTime.TryParse(reportObject2.RequestTime, out t4);
												bool flag12 = DateTime.TryParse(reportObject2.RequestTime, out t4);
												if (flag12)
												{
													bool flag13 = !(t <= t4) && t2 > t4;
													if (flag13)
													{
														continue;
													}
												}
												string status2 = reportObject2.Status;
												if (!(status2 == "Request") && (status2 == null || status2.Length != 0))
												{
													if (!(status2 == "Close") && !(status2 == "Close(H)"))
													{
														if (status2 == "Hold")
														{
															num4++;
														}
													}
													else
													{
														num3++;
													}
												}
												else
												{
													num2++;
												}
											}
										}
										this.maintTrendChart.Series[0].Points.AddXY((double)num, (double)num2);
										this.maintTrendChart.Series[1].Points.AddXY((double)num, (double)num3);
										this.maintTrendChart.Series[2].Points.AddXY((double)num, (double)num4);
										this.maintTrendChart.Series[0].Points[num].AxisLabel = treeNode2.Text;
										this.maintTrendChart.Series[0].ToolTip = "#SERIESNAME #VALY{D}";
										this.maintTrendChart.Series[1].ToolTip = "#SERIESNAME #VALY{D}";
										this.maintTrendChart.Series[2].ToolTip = "#SERIESNAME #VALY{D}";
										bool flag14 = num2 != 0;
										if (flag14)
										{
											this.maintTrendChart.Series[0].Points[num].Label = num2.ToString();
										}
										bool flag15 = num3 != 0;
										if (flag15)
										{
											this.maintTrendChart.Series[1].Points[num].Label = num3.ToString();
										}
										bool flag16 = num4 != 0;
										if (flag16)
										{
											this.maintTrendChart.Series[2].Points[num].Label = num4.ToString();
										}
										num2 = 0;
										num3 = 0;
										num4 = 0;
										num++;
									}
								}
								else
								{
									bool flag17 = this.rbCategory.Checked && treeNode3.Checked;
									if (flag17)
									{
										bool flag18 = list2.Contains(treeNode.Text);
										if (!flag18)
										{
											list2.Add(treeNode.Text);
											foreach (ReportList.ReportObject reportObject3 in this.list[this.tvList.Nodes[0].Text].getList())
											{
												bool flag19 = reportObject3.Category == treeNode.Text;
												if (flag19)
												{
													DateTime t5;
													DateTime.TryParse(reportObject3.RequestTime, out t5);
													bool flag20 = DateTime.TryParse(reportObject3.RequestTime, out t5);
													if (flag20)
													{
														bool flag21 = !(t <= t5) && t2 > t5;
														if (flag21)
														{
															continue;
														}
													}
													string status3 = reportObject3.Status;
													if (!(status3 == "Request") && (status3 == null || status3.Length != 0))
													{
														if (!(status3 == "Close") && !(status3 == "Close(H)"))
														{
															if (status3 == "Hold")
															{
																num4++;
															}
														}
														else
														{
															num3++;
														}
													}
													else
													{
														num2++;
													}
												}
											}
											this.maintTrendChart.Series[0].Points.AddXY((double)num, (double)num2);
											this.maintTrendChart.Series[1].Points.AddXY((double)num, (double)num3);
											this.maintTrendChart.Series[2].Points.AddXY((double)num, (double)num4);
											this.maintTrendChart.Series[0].Points[num].AxisLabel = treeNode.Text;
											this.maintTrendChart.Series[0].ToolTip = "#SERIESNAME #VALY{D}";
											this.maintTrendChart.Series[1].ToolTip = "#SERIESNAME #VALY{D}";
											this.maintTrendChart.Series[2].ToolTip = "#SERIESNAME #VALY{D}";
											bool flag22 = num2 != 0;
											if (flag22)
											{
												this.maintTrendChart.Series[0].Points[num].Label = num2.ToString();
											}
											bool flag23 = num3 != 0;
											if (flag23)
											{
												this.maintTrendChart.Series[1].Points[num].Label = num3.ToString();
											}
											bool flag24 = num4 != 0;
											if (flag24)
											{
												this.maintTrendChart.Series[2].Points[num].Label = num4.ToString();
											}
											num2 = 0;
											num3 = 0;
											num4 = 0;
											num++;
										}
									}
								}
							}
						}
					}
				}
				this.maintTrendChart.ChartAreas[0].RecalculateAxesScale();
				bool flag25 = this.maintTrendChart.ChartAreas[0].AxisY.Maximum <= 10.0;
				if (flag25)
				{
					this.maintTrendChart.ChartAreas[0].AxisY.Interval = 1.0;
				}
				else
				{
					bool flag26 = this.maintTrendChart.ChartAreas[0].AxisY.Maximum <= 50.0;
					if (flag26)
					{
						this.maintTrendChart.ChartAreas[0].AxisY.Interval = 5.0;
					}
					else
					{
						this.maintTrendChart.ChartAreas[0].AxisY.Interval = 100.0;
					}
				}
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0002B60C File Offset: 0x0002980C
		private void maintCaseTrend()
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			this.setCaseChart();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			DateTime t = new DateTime(this.dtStartDate.Value.Year, this.dtStartDate.Value.Month, this.dtStartDate.Value.Day, 0, 0, 0);
			DateTime t2 = new DateTime(this.dtEndDate.Value.Year, this.dtEndDate.Value.Month, this.dtEndDate.Value.Day, 23, 59, 59);
			this.tbFactorZoom.Value = 0;
			foreach (object obj in this.tvList.Nodes[0].Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				foreach (object obj2 in treeNode.Nodes)
				{
					TreeNode treeNode2 = (TreeNode)obj2;
					foreach (object obj3 in treeNode2.Nodes)
					{
						TreeNode treeNode3 = (TreeNode)obj3;
						bool flag = this.rbCaseEquipment.Checked && treeNode3.Checked;
						if (flag)
						{
							foreach (ReportList.ReportObject reportObject in this.list[this.tvList.Nodes[0].Text].getList())
							{
								bool flag2 = reportObject.Machine == treeNode3.Text;
								if (flag2)
								{
									DateTime t3;
									DateTime.TryParse(reportObject.RequestTime, out t3);
									bool flag3 = DateTime.TryParse(reportObject.RequestTime, out t3);
									if (flag3)
									{
										bool flag4 = !(t <= t3) && t2 > t3;
										if (flag4)
										{
											continue;
										}
									}
									string @case = reportObject.Case;
									if (!(@case == "HARDWARE"))
									{
										if (!(@case == "SOFTWARE"))
										{
											if (@case == "OTHER")
											{
												num4++;
											}
										}
										else
										{
											num3++;
										}
									}
									else
									{
										num2++;
									}
								}
							}
							this.maintCaseChart.Series[0].Points.AddXY((double)num, (double)num2);
							this.maintCaseChart.Series[1].Points.AddXY((double)num, (double)num3);
							this.maintCaseChart.Series[2].Points.AddXY((double)num, (double)num4);
							this.maintCaseChart.Series[0].Points[num].AxisLabel = treeNode3.Text;
							this.maintCaseChart.Series[0].ToolTip = "#SERIESNAME #VALY{D}";
							this.maintCaseChart.Series[1].ToolTip = "#SERIESNAME #VALY{D}";
							this.maintCaseChart.Series[2].ToolTip = "#SERIESNAME #VALY{D}";
							bool flag5 = num2 != 0;
							if (flag5)
							{
								this.maintCaseChart.Series[0].Points[num].Label = num2.ToString();
							}
							bool flag6 = num3 != 0;
							if (flag6)
							{
								this.maintCaseChart.Series[1].Points[num].Label = num3.ToString();
							}
							bool flag7 = num4 != 0;
							if (flag7)
							{
								this.maintCaseChart.Series[2].Points[num].Label = num4.ToString();
							}
							num2 = 0;
							num3 = 0;
							num4 = 0;
							num++;
						}
						else
						{
							bool flag8 = this.rbCaseModel.Checked && treeNode3.Checked;
							if (flag8)
							{
								bool flag9 = list.Contains(treeNode2.Text);
								if (!flag9)
								{
									list.Add(treeNode2.Text);
									foreach (ReportList.ReportObject reportObject2 in this.list[this.tvList.Nodes[0].Text].getList())
									{
										bool flag10 = reportObject2.Model == treeNode2.Text;
										if (flag10)
										{
											DateTime t4;
											DateTime.TryParse(reportObject2.RequestTime, out t4);
											bool flag11 = DateTime.TryParse(reportObject2.RequestTime, out t4);
											if (flag11)
											{
												bool flag12 = !(t <= t4) && t2 > t4;
												if (flag12)
												{
													continue;
												}
											}
											string case2 = reportObject2.Case;
											if (!(case2 == "HARDWARE"))
											{
												if (!(case2 == "SOFTWARE"))
												{
													if (case2 == "OTHER")
													{
														num4++;
													}
												}
												else
												{
													num3++;
												}
											}
											else
											{
												num2++;
											}
										}
									}
									this.maintCaseChart.Series[0].Points.AddXY((double)num, (double)num2);
									this.maintCaseChart.Series[1].Points.AddXY((double)num, (double)num3);
									this.maintCaseChart.Series[2].Points.AddXY((double)num, (double)num4);
									this.maintCaseChart.Series[0].Points[num].AxisLabel = treeNode2.Text;
									this.maintCaseChart.Series[0].ToolTip = "#SERIESNAME #VALY{D}";
									this.maintCaseChart.Series[1].ToolTip = "#SERIESNAME #VALY{D}";
									this.maintCaseChart.Series[2].ToolTip = "#SERIESNAME #VALY{D}";
									bool flag13 = num2 != 0;
									if (flag13)
									{
										this.maintCaseChart.Series[0].Points[num].Label = num2.ToString();
									}
									bool flag14 = num3 != 0;
									if (flag14)
									{
										this.maintCaseChart.Series[1].Points[num].Label = num3.ToString();
									}
									bool flag15 = num4 != 0;
									if (flag15)
									{
										this.maintCaseChart.Series[2].Points[num].Label = num4.ToString();
									}
									num2 = 0;
									num3 = 0;
									num4 = 0;
									num++;
								}
							}
							else
							{
								bool flag16 = this.rbCaseCategory.Checked && treeNode3.Checked;
								if (flag16)
								{
									bool flag17 = list2.Contains(treeNode.Text);
									if (!flag17)
									{
										list2.Add(treeNode.Text);
										foreach (ReportList.ReportObject reportObject3 in this.list[this.tvList.Nodes[0].Text].getList())
										{
											bool flag18 = reportObject3.Category == treeNode.Text;
											if (flag18)
											{
												DateTime t5;
												DateTime.TryParse(reportObject3.RequestTime, out t5);
												bool flag19 = DateTime.TryParse(reportObject3.RequestTime, out t5);
												if (flag19)
												{
													bool flag20 = !(t <= t5) && t2 > t5;
													if (flag20)
													{
														continue;
													}
												}
												string case3 = reportObject3.Case;
												if (!(case3 == "HARDWARE"))
												{
													if (!(case3 == "SOFTWARE"))
													{
														if (case3 == "OTHER")
														{
															num4++;
														}
													}
													else
													{
														num3++;
													}
												}
												else
												{
													num2++;
												}
											}
										}
										this.maintCaseChart.Series[0].Points.AddXY((double)num, (double)num2);
										this.maintCaseChart.Series[1].Points.AddXY((double)num, (double)num3);
										this.maintCaseChart.Series[2].Points.AddXY((double)num, (double)num4);
										this.maintCaseChart.Series[0].Points[num].AxisLabel = treeNode.Text;
										this.maintCaseChart.Series[0].ToolTip = "#SERIESNAME #VALY{D}";
										this.maintCaseChart.Series[1].ToolTip = "#SERIESNAME #VALY{D}";
										this.maintCaseChart.Series[2].ToolTip = "#SERIESNAME #VALY{D}";
										bool flag21 = num2 != 0;
										if (flag21)
										{
											this.maintCaseChart.Series[0].Points[num].Label = num2.ToString();
										}
										bool flag22 = num3 != 0;
										if (flag22)
										{
											this.maintCaseChart.Series[1].Points[num].Label = num3.ToString();
										}
										bool flag23 = num4 != 0;
										if (flag23)
										{
											this.maintCaseChart.Series[2].Points[num].Label = num4.ToString();
										}
										num2 = 0;
										num3 = 0;
										num4 = 0;
										num++;
									}
								}
							}
						}
					}
				}
			}
			this.maintCaseChart.ChartAreas[0].RecalculateAxesScale();
			bool flag24 = this.maintCaseChart.ChartAreas[0].AxisY.Maximum <= 10.0;
			if (flag24)
			{
				this.maintCaseChart.ChartAreas[0].AxisY.Interval = 1.0;
			}
			else
			{
				bool flag25 = this.maintCaseChart.ChartAreas[0].AxisY.Maximum <= 50.0;
				if (flag25)
				{
					this.maintCaseChart.ChartAreas[0].AxisY.Interval = 5.0;
				}
				else
				{
					this.maintCaseChart.ChartAreas[0].AxisY.Interval = 100.0;
				}
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0002C1CC File Offset: 0x0002A3CC
		private void setFactorList(string Equipment)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			Dictionary<string, int> dictionary3 = new Dictionary<string, int>();
			this.pnFactorBase.Visible = false;
			this.pnFactorBase2.Visible = false;
			this.pnFactorBase3.Visible = false;
			DateTime t = new DateTime(this.dtStartDate.Value.Year, this.dtStartDate.Value.Month, this.dtStartDate.Value.Day, 0, 0, 0);
			DateTime t2 = new DateTime(this.dtEndDate.Value.Year, this.dtEndDate.Value.Month, this.dtEndDate.Value.Day, 23, 59, 59);
			foreach (ReportList.ReportObject reportObject in this.list[this.tvList.Nodes[0].Text].getList())
			{
				bool flag = reportObject.Machine == Equipment || reportObject.Category == Equipment || reportObject.Model == Equipment;
				if (flag)
				{
					DateTime t3;
					DateTime.TryParse(reportObject.RequestTime, out t3);
					bool flag2 = DateTime.TryParse(reportObject.RequestTime, out t3);
					if (flag2)
					{
						bool flag3 = !(t <= t3) && t2 > t3;
						if (flag3)
						{
							continue;
						}
					}
					bool flag4 = reportObject.Case.ToUpper() == "HARDWARE";
					if (flag4)
					{
						string text = reportObject.Factor;
						bool flag5 = string.IsNullOrEmpty(text);
						if (flag5)
						{
							text = "UNKNOWN(OLD)";
						}
						bool flag6 = !dictionary.ContainsKey(text);
						if (flag6)
						{
							dictionary.Add(text, 1);
						}
						else
						{
							bool flag7 = dictionary.ContainsKey(text);
							if (flag7)
							{
								int num = dictionary[text];
								dictionary[text] = num + 1;
							}
						}
					}
					else
					{
						bool flag8 = reportObject.Case.ToUpper() == "SOFTWARE";
						if (flag8)
						{
							string text2 = reportObject.Factor;
							bool flag9 = string.IsNullOrEmpty(text2);
							if (flag9)
							{
								text2 = "UNKNOWN(OLD)";
							}
							bool flag10 = !dictionary2.ContainsKey(text2);
							if (flag10)
							{
								dictionary2.Add(text2, 1);
							}
							else
							{
								bool flag11 = dictionary2.ContainsKey(text2);
								if (flag11)
								{
									int num2 = dictionary2[text2];
									dictionary2[text2] = num2 + 1;
								}
							}
						}
						else
						{
							bool flag12 = reportObject.Case.ToUpper() == "OTHER";
							if (flag12)
							{
								string text3 = reportObject.Factor;
								bool flag13 = string.IsNullOrEmpty(text3);
								if (flag13)
								{
									text3 = "UNKNOWN(OLD)";
								}
								bool flag14 = !dictionary3.ContainsKey(text3);
								if (flag14)
								{
									dictionary3.Add(text3, 1);
								}
								else
								{
									bool flag15 = dictionary3.ContainsKey(text3);
									if (flag15)
									{
										int num3 = dictionary3[text3];
										dictionary3[text3] = num3 + 1;
									}
								}
							}
						}
					}
				}
			}
			bool flag16 = dictionary3.Count != 0;
			if (flag16)
			{
				this.setFactorChart3(Equipment);
				this.maintFactorChart3.Series.Clear();
				this.maintFactorChart3.Series.Add("Factor");
				this.maintFactorChart3.Series[0].ToolTip = "#VALX #VALY{D}";
				foreach (KeyValuePair<string, int> keyValuePair in dictionary3)
				{
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].ChartType = SeriesChartType.Pie;
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Font = new Font(this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Font.FontFamily, this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points.AddXY(keyValuePair.Key, new object[]
					{
						keyValuePair.Value
					});
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points[this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair.Key;
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points[this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				}
			}
			bool flag17 = dictionary2.Count != 0;
			if (flag17)
			{
				this.setFactorChart2(Equipment);
				this.maintFactorChart2.Series.Clear();
				this.maintFactorChart2.Series.Add("Factor");
				this.maintFactorChart2.Series[0].ToolTip = "#VALX #VALY{D}";
				foreach (KeyValuePair<string, int> keyValuePair2 in dictionary2)
				{
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].ChartType = SeriesChartType.Pie;
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Font = new Font(this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Font.FontFamily, this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points.AddXY(keyValuePair2.Key, new object[]
					{
						keyValuePair2.Value
					});
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points[this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair2.Key;
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points[this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				}
			}
			bool flag18 = dictionary.Count != 0;
			if (flag18)
			{
				this.setFactorChart1(Equipment);
				this.maintFactorChart1.Series.Clear();
				this.maintFactorChart1.Series.Add("Factor");
				this.maintFactorChart1.Series[0].ToolTip = "#VALX #VALY{D}";
				foreach (KeyValuePair<string, int> keyValuePair3 in dictionary)
				{
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].ChartType = SeriesChartType.Pie;
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Font = new Font(this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Font.FontFamily, this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points.AddXY(keyValuePair3.Key, new object[]
					{
						keyValuePair3.Value
					});
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points[this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair3.Key;
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points[this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				}
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0002CC78 File Offset: 0x0002AE78
		private void maintOEETrend()
		{
			List<double> list = new List<double>();
			List<int> list2 = new List<int>();
			DateTime dateTime = new DateTime(this.dtStartDate.Value.Year, this.dtStartDate.Value.Month, this.dtStartDate.Value.Day, 0, 0, 0);
			DateTime dateTime2 = new DateTime(this.dtEndDate.Value.Year, this.dtEndDate.Value.Month, this.dtEndDate.Value.Day, 23, 59, 59);
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 0;
			int num4 = 0;
			this.tbOEEChartZoom.Value = 0;
			this.OEEList.Clear();
			this.setOEEChart();
			string empty = string.Empty;
			foreach (object obj in this.tvList.Nodes[0].Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				foreach (object obj2 in treeNode.Nodes)
				{
					TreeNode treeNode2 = (TreeNode)obj2;
					foreach (object obj3 in treeNode2.Nodes)
					{
						TreeNode treeNode3 = (TreeNode)obj3;
						bool @checked = treeNode3.Checked;
						if (@checked)
						{
							bool flag = this.rbMTBF.Checked && this.rbProductionHour.Checked;
							if (flag)
							{
								string sQuery = string.Empty;
								bool flag2 = treeNode2.Parent.Text.ToUpper() == "TESTER";
								if (flag2)
								{
									sQuery = string.Concat(new string[]
									{
										"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintACTLTime]@_Name=N'",
										treeNode3.Text,
										"',@_Type=N'TESTER', @_StartDate=N'",
										this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00"),
										"', @_EndDate=N'",
										this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59"),
										"'"
									});
								}
								else
								{
									sQuery = string.Concat(new string[]
									{
										"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintACTLTime]@_Name=N'",
										treeNode3.Text,
										"',@_Type=N'HANDLER', @_StartDate=N'",
										this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00"),
										"', @_EndDate=N'",
										this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59"),
										"'"
									});
								}
								DataSet dataSet = this._queryMgr.queryCall(sQuery);
								bool flag3 = dataSet != null && dataSet.Tables.Count > 0;
								if (flag3)
								{
									int num5;
									for (int i = 0; i < dataSet.Tables[0].Rows.Count; i = num5 + 1)
									{
										TrendForm.OEEData oeedata = new TrendForm.OEEData();
										string key = dataSet.Tables[0].Rows[i]["name"].ToString().Trim();
										string value = dataSet.Tables[0].Rows[i]["ACTL_Minute"].ToString().Trim();
										oeedata.startTimeMTBF = Convert.ToDateTime(dataSet.Tables[0].Rows[i]["starttime"].ToString().Trim());
										oeedata.endTimeMTBF = Convert.ToDateTime(dataSet.Tables[0].Rows[i]["endtime"].ToString().Trim());
										oeedata.ACTLMin = Convert.ToDouble(value);
										bool flag4 = this.OEEList.ContainsKey(key);
										if (flag4)
										{
											this.OEEList[key].Add(oeedata);
										}
										else
										{
											this.OEEList.Add(key, new List<TrendForm.OEEData>());
											this.OEEList[key].Add(oeedata);
										}
										num5 = i;
									}
								}
							}
							foreach (ReportList.ReportObject reportObject in this.list[this.tvList.Nodes[0].Text].getList())
							{
								bool flag5 = reportObject.Machine == treeNode3.Text;
								if (flag5)
								{
									bool flag6 = (reportObject.Status == "PM(Request)" || reportObject.Status == "PM(Approval)" || reportObject.Status == "PM(Final)" || reportObject.Status == "PM(Done)" || reportObject.Status == "PM(Cancel)") && !reportObject.PMStatus;
									if (!flag6)
									{
										bool flag7 = false;
										bool flag8 = this.rbRequestTime.Checked || this.rbMTBF.Checked;
										DateTime dateTime3;
										if (flag8)
										{
											bool flag9 = reportObject.HoldTime != null && !string.IsNullOrEmpty(reportObject.HoldTime);
											if (flag9)
											{
												bool flag10 = flag7 && DateTime.TryParse(reportObject.HoldTime, out dateTime3);
											}
											flag7 = DateTime.TryParse(reportObject.RequestTime, out dateTime3);
										}
										else
										{
											flag7 = DateTime.TryParse(reportObject.StartTime, out dateTime3);
										}
										bool flag11 = flag7;
										if (flag11)
										{
											bool flag12 = dateTime >= dateTime3 && dateTime2 >= dateTime3;
											if (flag12)
											{
												bool flag13 = this.rbRequestTime.Checked || this.rbMTBF.Checked;
												if (flag13)
												{
													bool flag14 = reportObject.HoldTime != null && !string.IsNullOrEmpty(reportObject.HoldTime);
													if (flag14)
													{
														bool flag15 = flag7 && DateTime.TryParse(reportObject.HoldTime, out dateTime3);
														bool flag16 = dateTime > dateTime3 && !string.IsNullOrEmpty(reportObject.StartTime.Trim());
														if (flag16)
														{
															reportObject.RequestTime = reportObject.StartTime;
															reportObject.HoldTime = string.Empty;
														}
														else
														{
															reportObject.RequestTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
														}
													}
													else
													{
														bool flag17 = !string.IsNullOrEmpty(reportObject.StartTime.Trim());
														if (flag17)
														{
															reportObject.RequestTime = reportObject.StartTime;
														}
														else
														{
															reportObject.RequestTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
														}
													}
													flag7 = DateTime.TryParse(reportObject.RequestTime, out dateTime3);
												}
												else
												{
													bool flag18 = !string.IsNullOrEmpty(reportObject.StartTime.Trim());
													if (flag18)
													{
														reportObject.RequestTime = reportObject.StartTime;
														DateTime.TryParse(reportObject.RequestTime, out dateTime3);
													}
													else
													{
														reportObject.StartTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
														dateTime3 = dateTime;
													}
												}
											}
											bool flag19 = dateTime <= dateTime3 && dateTime2 >= dateTime3;
											if (flag19)
											{
												TrendForm.OEEData oeedata2 = new TrendForm.OEEData();
												bool flag20 = this.rbRequestTime.Checked || this.rbMTBF.Checked;
												if (flag20)
												{
													oeedata2.requestTime = dateTime3;
												}
												else
												{
													oeedata2.startTime = dateTime3;
												}
												DateTime.TryParse(reportObject.StartTime, out oeedata2.startTime);
												DateTime.TryParse(reportObject.EndTime, out oeedata2.endTime);
												DateTime.TryParse(reportObject.HoldTime, out oeedata2.HoldTime);
												bool checked2 = this.rbMTBF.Checked;
												if (checked2)
												{
													int num5 = num3;
													num3 = num5 + 1;
													oeedata2.bCount = true;
													bool flag21 = this.OEEList.ContainsKey(treeNode3.Text);
													if (flag21)
													{
														this.OEEList[treeNode3.Text].Add(oeedata2);
													}
													else
													{
														this.OEEList.Add(treeNode3.Text, new List<TrendForm.OEEData>());
														this.OEEList[treeNode3.Text].Add(oeedata2);
													}
												}
												else
												{
													bool checked3 = this.rbMTTR.Checked;
													if (checked3)
													{
														bool flag22 = false;
														bool flag23 = this.OEEList.ContainsKey(treeNode3.Text);
														if (flag23)
														{
															bool checked4 = this.rbRequestTime.Checked;
															if (checked4)
															{
																int num5;
																for (int j = 0; j < this.OEEList[treeNode3.Text].Count; j = num5 + 1)
																{
																	TrendForm.OEEData oeedata3 = this.OEEList[treeNode3.Text][j];
																	bool flag24 = oeedata3.requestTime.DayOfYear == oeedata2.requestTime.DayOfYear && oeedata3.requestTime.Year == oeedata2.requestTime.Year;
																	if (flag24)
																	{
																		bool flag25 = oeedata2.HoldTime.Year == 1;
																		if (flag25)
																		{
																			bool flag26 = oeedata3.requestTime >= oeedata2.requestTime && oeedata3.endTime <= oeedata2.endTime;
																			if (flag26)
																			{
																				oeedata3.requestTime = oeedata2.requestTime;
																				oeedata3.endTime = oeedata2.endTime;
																				flag22 = true;
																				break;
																			}
																			bool flag27 = oeedata3.requestTime >= oeedata2.requestTime && oeedata3.endTime >= oeedata2.endTime;
																			if (flag27)
																			{
																				oeedata3.requestTime = oeedata2.requestTime;
																				flag22 = true;
																				break;
																			}
																			bool flag28 = oeedata3.requestTime <= oeedata2.requestTime && oeedata3.endTime <= oeedata2.endTime;
																			if (flag28)
																			{
																				oeedata3.endTime = oeedata2.endTime;
																				flag22 = true;
																				break;
																			}
																			bool flag29 = oeedata3.requestTime <= oeedata2.requestTime && oeedata3.endTime >= oeedata2.endTime;
																			if (flag29)
																			{
																				flag22 = true;
																				break;
																			}
																		}
																		else
																		{
																			bool flag30 = oeedata3.requestTime >= oeedata2.requestTime && oeedata3.HoldTime <= oeedata2.HoldTime;
																			if (flag30)
																			{
																				oeedata3.requestTime = oeedata2.requestTime;
																				oeedata3.HoldTime = oeedata2.HoldTime;
																				flag22 = true;
																			}
																			else
																			{
																				bool flag31 = oeedata3.requestTime >= oeedata2.requestTime && oeedata3.HoldTime >= oeedata2.HoldTime && oeedata3.requestTime <= oeedata2.HoldTime;
																				if (flag31)
																				{
																					oeedata3.requestTime = oeedata2.requestTime;
																					flag22 = true;
																				}
																				else
																				{
																					bool flag32 = oeedata3.requestTime <= oeedata2.requestTime && oeedata3.HoldTime <= oeedata2.HoldTime;
																					if (flag32)
																					{
																						oeedata3.HoldTime = oeedata2.HoldTime;
																						flag22 = true;
																					}
																					else
																					{
																						bool flag33 = oeedata3.requestTime <= oeedata2.requestTime && oeedata3.HoldTime >= oeedata2.HoldTime;
																						if (flag33)
																						{
																							flag22 = true;
																						}
																					}
																				}
																			}
																			bool flag34 = oeedata3.startTime.DayOfYear == oeedata2.startTime.DayOfYear && oeedata3.startTime.Year == oeedata2.startTime.Year;
																			if (flag34)
																			{
																				bool flag35 = oeedata3.startTime >= oeedata2.startTime && oeedata3.endTime <= oeedata2.endTime;
																				if (flag35)
																				{
																					oeedata3.startTime = oeedata2.startTime;
																					oeedata3.endTime = oeedata2.endTime;
																					flag22 = true;
																				}
																				else
																				{
																					bool flag36 = oeedata3.startTime >= oeedata2.startTime && oeedata3.endTime >= oeedata2.endTime && oeedata3.startTime <= oeedata2.endTime;
																					if (flag36)
																					{
																						oeedata3.startTime = oeedata2.startTime;
																						flag22 = true;
																					}
																					else
																					{
																						bool flag37 = oeedata3.startTime <= oeedata2.startTime && oeedata3.endTime <= oeedata2.endTime;
																						if (flag37)
																						{
																							oeedata3.endTime = oeedata2.endTime;
																							flag22 = true;
																						}
																						else
																						{
																							bool flag38 = oeedata3.startTime <= oeedata2.startTime && oeedata3.endTime >= oeedata2.endTime;
																							if (flag38)
																							{
																								flag22 = true;
																							}
																						}
																					}
																				}
																			}
																			bool flag39 = flag22;
																			if (flag39)
																			{
																				break;
																			}
																		}
																	}
																	bool flag40 = oeedata2.requestTime < oeedata3.endTime || (oeedata3.HoldTime.Year != 1 && oeedata2.requestTime < oeedata3.HoldTime);
																	if (flag40)
																	{
																		bool flag41 = oeedata2.requestTime > oeedata3.requestTime;
																		if (flag41)
																		{
																			bool flag42 = oeedata3.endTime.DayOfYear != 1 && oeedata2.endTime.Year != 1 && oeedata3.endTime.DayOfYear == oeedata2.endTime.DayOfYear && oeedata3.endTime.Year == oeedata2.endTime.Year;
																			if (flag42)
																			{
																				bool flag43 = oeedata3.endTime < oeedata2.endTime;
																				if (flag43)
																				{
																					oeedata3.endTime = oeedata2.endTime;
																					flag22 = true;
																					break;
																				}
																				bool flag44 = oeedata3.startTime <= oeedata2.startTime && oeedata3.endTime >= oeedata2.endTime;
																				if (flag44)
																				{
																					flag22 = true;
																					break;
																				}
																			}
																			else
																			{
																				bool flag45 = oeedata3.endTime.DayOfYear != 1 && oeedata2.HoldTime.Year != 1 && oeedata3.endTime.DayOfYear == oeedata2.HoldTime.DayOfYear && oeedata3.endTime.Year == oeedata2.HoldTime.Year;
																				if (flag45)
																				{
																					bool flag46 = oeedata3.endTime < oeedata2.HoldTime;
																					if (flag46)
																					{
																						oeedata3.endTime = oeedata2.HoldTime;
																						flag22 = true;
																						break;
																					}
																					bool flag47 = oeedata3.endTime >= oeedata2.HoldTime;
																					if (flag47)
																					{
																						flag22 = true;
																						break;
																					}
																				}
																				else
																				{
																					bool flag48 = oeedata3.HoldTime.DayOfYear != 1 && oeedata2.endTime.Year != 1 && oeedata3.HoldTime.DayOfYear == oeedata2.endTime.DayOfYear && oeedata3.HoldTime.Year == oeedata2.endTime.Year;
																					if (flag48)
																					{
																						bool flag49 = oeedata3.HoldTime < oeedata2.endTime;
																						if (flag49)
																						{
																							oeedata3.HoldTime = oeedata2.endTime;
																							flag22 = true;
																							break;
																						}
																						bool flag50 = oeedata3.HoldTime >= oeedata2.endTime;
																						if (flag50)
																						{
																							flag22 = true;
																							break;
																						}
																					}
																					else
																					{
																						bool flag51 = oeedata3.HoldTime.DayOfYear != 1 && oeedata2.HoldTime.Year != 1 && oeedata3.HoldTime.DayOfYear == oeedata2.HoldTime.DayOfYear && oeedata3.HoldTime.Year == oeedata2.HoldTime.Year;
																						if (flag51)
																						{
																							bool flag52 = oeedata3.HoldTime < oeedata2.HoldTime;
																							if (flag52)
																							{
																								oeedata3.HoldTime = oeedata2.HoldTime;
																								flag22 = true;
																								break;
																							}
																							bool flag53 = oeedata3.HoldTime >= oeedata2.HoldTime;
																							if (flag53)
																							{
																								flag22 = true;
																								break;
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																	num5 = j;
																}
																bool flag54 = !flag22;
																if (flag54)
																{
																	num5 = num3;
																	num3 = num5 + 1;
																	this.OEEList[treeNode3.Text].Add(oeedata2);
																}
															}
															else
															{
																int num5;
																for (int k = 0; k < this.OEEList[treeNode3.Text].Count; k = num5 + 1)
																{
																	TrendForm.OEEData oeedata4 = this.OEEList[treeNode3.Text][k];
																	bool flag55 = oeedata4.startTime.DayOfYear == oeedata2.startTime.DayOfYear && oeedata4.startTime.Year == oeedata2.startTime.Year;
																	if (flag55)
																	{
																		bool flag56 = oeedata4.startTime >= oeedata2.startTime && oeedata4.endTime <= oeedata2.endTime;
																		if (flag56)
																		{
																			oeedata4.startTime = oeedata2.startTime;
																			oeedata4.endTime = oeedata2.endTime;
																			flag22 = true;
																			break;
																		}
																		bool flag57 = oeedata4.startTime >= oeedata2.startTime && oeedata4.endTime <= oeedata2.endTime;
																		if (flag57)
																		{
																			oeedata4.startTime = oeedata2.startTime;
																			flag22 = true;
																			break;
																		}
																		bool flag58 = oeedata4.startTime <= oeedata2.startTime && oeedata4.endTime >= oeedata2.endTime;
																		if (flag58)
																		{
																			flag22 = true;
																			break;
																		}
																	}
																	bool flag59 = oeedata4.endTime.DayOfYear == oeedata2.endTime.DayOfYear && oeedata4.endTime.Year == oeedata2.endTime.Year && oeedata4.endTime >= oeedata2.startTime;
																	if (flag59)
																	{
																		bool flag60 = oeedata4.endTime <= oeedata2.endTime;
																		if (flag60)
																		{
																			flag22 = true;
																			oeedata4.endTime = oeedata2.endTime;
																			break;
																		}
																	}
																	num5 = k;
																}
																bool flag61 = !flag22;
																if (flag61)
																{
																	num5 = num3;
																	num3 = num5 + 1;
																	this.OEEList[treeNode3.Text].Add(oeedata2);
																}
															}
														}
														else
														{
															bool checked5 = this.rbRequestTime.Checked;
															if (checked5)
															{
																int num5 = num3;
																num3 = num5 + 1;
															}
															else
															{
																int num5 = num3;
																num3 = num5 + 1;
															}
															this.OEEList.Add(treeNode3.Text, new List<TrendForm.OEEData>());
															oeedata2.bCount = false;
															this.OEEList[treeNode3.Text].Add(oeedata2);
														}
													}
												}
											}
										}
									}
								}
								else
								{
									bool flag62 = !this.OEEList.ContainsKey(treeNode3.Text);
									if (flag62)
									{
										this.OEEList.Add(treeNode3.Text, new List<TrendForm.OEEData>());
									}
								}
							}
						}
					}
				}
			}
			TimeSpan timeSpan = dateTime2 - dateTime;
			this.maintOEEChart.Titles.Clear();
			bool checked6 = this.rbMTBF.Checked;
			if (checked6)
			{
				this.maintOEEChart.Titles.Add("<MTBF>");
			}
			else
			{
				this.maintOEEChart.Titles.Add("<MTTR>");
			}
			this.maintOEEChart.Titles[0].Font = new Font("맑은 고딕", 15f, FontStyle.Bold);
			this.maintOEEChart.Titles[0].Alignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.maintOEEChart.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;
			this.maintOEEChart.ChartAreas[0].AxisX.TitleFont = new Font("맑은 고딕", 8f, FontStyle.Bold);
			this.maintOEEChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
			this.maintOEEChart.ChartAreas[0].AxisY.TitleFont = new Font("맑은 고딕", 10f, FontStyle.Bold);
			this.maintOEEChart.ChartAreas[0].AxisY2.TitleFont = new Font("맑은 고딕", 10f, FontStyle.Bold);
			this.maintOEEChart.ChartAreas[0].AxisY.Title = "TIME(hour)";
			this.maintOEEChart.ChartAreas[0].AxisY2.Title = "FAILURE(ea)";
			bool flag63 = this.OEEList.Count == 0;
			if (flag63)
			{
				this.maintOEEChart.Legends.Clear();
				bool flag64 = !this.rbMTBF.Checked;
				if (flag64)
				{
					this.maintOEEChart.Series.Add("");
				}
				else
				{
					this.maintOEEChart.Series.Add("");
				}
				this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].ChartType = SeriesChartType.Column;
				this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Font = new Font(this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Font.FontFamily, this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Font.Size, FontStyle.Bold);
				this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].YAxisType = AxisType.Primary;
				this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].XAxisType = AxisType.Primary;
				this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].YValueType = ChartValueType.Double;
				this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].XValueType = ChartValueType.Date;
				this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].ToolTip = "#SERIESNAME : #VALY{G}";
				this.maintOEEChart.ChartAreas[0].AxisY.Interval = 6.0;
				int num6 = 0;
				while ((double)num6 < timeSpan.TotalDays)
				{
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Points.AddXY(dateTime.AddDays((double)num6).Month + "/" + dateTime.AddDays((double)num6).Day, new object[]
					{
						0
					});
					int num5 = num6;
					num6 = num5 + 1;
				}
			}
			else
			{
				bool checked7 = this.rbMTBF.Checked;
				if (checked7)
				{
					num3 = 0;
				}
				num = 0.0;
				num2 = 0.0;
				foreach (KeyValuePair<string, List<TrendForm.OEEData>> keyValuePair in this.OEEList)
				{
					double num7 = 0.0;
					DateTime dateTime4 = dateTime;
					List<double> list3 = new List<double>();
					TimeSpan timeSpan2 = new TimeSpan(0L);
					num4 = 0;
					list.Clear();
					list2.Clear();
					bool flag65 = !this.rbMTBF.Checked;
					if (flag65)
					{
						this.maintOEEChart.Series.Add(keyValuePair.Key + " MTTR");
					}
					else
					{
						this.maintOEEChart.Series.Add(keyValuePair.Key + " MTBF");
					}
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].ChartType = SeriesChartType.Column;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Font = new Font(this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Font.FontFamily, this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].YAxisType = AxisType.Primary;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].XAxisType = AxisType.Primary;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].YValueType = ChartValueType.Double;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].XValueType = ChartValueType.Date;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].ToolTip = "#SERIESNAME : #VALY{G}";
					this.maintOEEChart.ChartAreas[0].AxisY.Interval = 6.0;
					int num8 = 0;
					while ((double)num8 < Math.Ceiling(timeSpan.TotalDays))
					{
						this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Points.AddXY(dateTime4.Month + "/" + dateTime4.Day, new object[]
						{
							0
						});
						dateTime4 = dateTime4.AddDays(1.0);
						list.Add(0.0);
						list2.Add(0);
						int num5 = num8;
						num8 = num5 + 1;
					}
					bool flag66 = !this.rbMTBF.Checked;
					if (flag66)
					{
						DateTime dateTime5 = DateTime.Now;
						DateTime dateTime6 = DateTime.Now;
						DateTime dateTime7 = DateTime.Now;
						foreach (TrendForm.OEEData oeedata5 in keyValuePair.Value)
						{
							bool flag67 = false;
							bool flag68 = false;
							bool checked8 = this.rbRequestTime.Checked;
							if (checked8)
							{
								dateTime5 = oeedata5.requestTime;
								dateTime6 = oeedata5.endTime;
							}
							else
							{
								bool checked9 = this.rbStartTime.Checked;
								if (checked9)
								{
									dateTime5 = oeedata5.startTime;
									dateTime6 = oeedata5.endTime;
								}
							}
							bool checked10 = this.rbRequestTime.Checked;
							if (checked10)
							{
								dateTime7 = oeedata5.requestTime;
							}
							else
							{
								dateTime7 = oeedata5.startTime;
							}
							bool flag69 = dateTime5 < dateTime7 && dateTime6 > oeedata5.endTime && oeedata5.endTime.Year > 2000;
							if (!flag69)
							{
								bool flag70 = dateTime6.DayOfYear == oeedata5.endTime.DayOfYear && dateTime6 > oeedata5.endTime && oeedata5.endTime.Year > 2000;
								if (flag70)
								{
									flag67 = true;
								}
								else
								{
									bool flag71 = (dateTime5.DayOfYear == dateTime7.DayOfYear && dateTime7 < dateTime6 && dateTime6 < oeedata5.endTime && oeedata5.endTime.Year > 2000) || (dateTime6.DayOfYear >= dateTime7.DayOfYear && dateTime6 < oeedata5.endTime && oeedata5.endTime.Year > 2000 && dateTime7 < dateTime6);
									if (flag71)
									{
										flag68 = true;
									}
									else
									{
										bool flag72 = dateTime5 <= dateTime7 && oeedata5.endTime.Year < 2000 && dateTime5.Year > 2000 && (oeedata5.HoldTime.Year == 1 || !this.rbRequestTime.Checked);
										if (flag72)
										{
											int num5;
											for (int l = 0; l < list.Count; l = num5 + 1)
											{
												DateTime t = dateTime.AddDays((double)l);
												bool flag73 = dateTime7 < t;
												if (flag73)
												{
													list[l] = 86400.0;
													list2[l] = 1;
												}
												else
												{
													bool flag74 = dateTime7.DayOfYear == t.DayOfYear;
													if (flag74)
													{
														double totalSeconds = (new DateTime(dateTime7.Year, dateTime7.Month, dateTime7.Day, 23, 59, 59) - dateTime7).TotalSeconds;
														list2[l] = 1;
														bool flag75 = list[l] + totalSeconds + 1.0 < 86400.0;
														if (flag75)
														{
															list[l] += totalSeconds;
														}
														else
														{
															list[l] = 86400.0;
														}
													}
													else
													{
														bool flag76 = dateTime7.Year < t.Year && dateTime7.DayOfYear >= t.DayOfYear;
														if (flag76)
														{
															list[l] = 86400.0;
															list2[l] = 1;
														}
													}
												}
												num5 = l;
											}
											continue;
										}
									}
								}
								bool flag77 = flag67;
								if (flag77)
								{
									int num9 = 0;
									while ((double)num9 < timeSpan.TotalDays)
									{
										DateTime dateTime8 = dateTime.AddDays((double)num9);
										bool flag78 = dateTime.DayOfYear == dateTime5.DayOfYear && dateTime7.DayOfYear == dateTime5.DayOfYear;
										int num5;
										if (flag78)
										{
											bool flag79 = this.rbRequestTime.Checked && oeedata5.HoldTime.Year != 1;
											double num10;
											if (flag79)
											{
												num10 = (oeedata5.HoldTime - dateTime7).TotalSeconds;
												num10 += (oeedata5.endTime - oeedata5.startTime).TotalSeconds;
											}
											else
											{
												num10 = (oeedata5.endTime - dateTime7).TotalSeconds;
											}
											bool flag80 = list[num9] + num10 + 1.0 < 86400.0;
											if (flag80)
											{
												list[num9] += num10;
												list2[num9]++;
											}
										}
										else
										{
											bool flag81 = dateTime8.DayOfYear == dateTime7.DayOfYear && dateTime7.DayOfYear != dateTime5.DayOfYear;
											if (flag81)
											{
												bool flag82 = this.rbRequestTime.Checked && oeedata5.HoldTime.Year != 1;
												double totalSeconds2;
												if (flag82)
												{
													totalSeconds2 = (oeedata5.HoldTime - dateTime7).TotalSeconds;
												}
												else
												{
													totalSeconds2 = (new DateTime(dateTime7.Year, dateTime7.Month, dateTime7.Day, 23, 59, 59) - dateTime7).TotalSeconds;
												}
												bool flag83 = list[num9] + totalSeconds2 + 1.0 < 86400.0;
												if (flag83)
												{
													list[num9] += totalSeconds2;
													list2[num9]++;
												}
												else
												{
													list[num9] = 86400.0;
													list2[num9]++;
												}
												bool flag84 = dateTime5.DayOfYear - dateTime7.DayOfYear >= 2 && (oeedata5.HoldTime.Year == 1 || !this.rbRequestTime.Checked);
												if (flag84)
												{
													for (int m = num9 + 1; m < list.Count; m = num5 + 1)
													{
														bool flag85 = dateTime5.DayOfYear < dateTime8.AddDays((double)m).DayOfYear;
														if (flag85)
														{
															list[m] = 86400.0;
															list2[m] = 1;
														}
														num5 = m;
													}
												}
												else
												{
													bool flag86 = oeedata5.HoldTime.Year == 1 || !this.rbRequestTime.Checked;
													if (flag86)
													{
														totalSeconds2 = (dateTime5 - new DateTime(dateTime5.Year, dateTime5.Month, dateTime5.Day, 0, 0, 0)).TotalSeconds;
														bool flag87 = list[num9] + totalSeconds2 + 1.0 < 86400.0;
														if (flag87)
														{
															list[num9] += totalSeconds2;
															list2[num9]++;
														}
														else
														{
															list[num9] = 86400.0;
															list2[num9]++;
														}
													}
													else
													{
														bool flag88 = this.rbRequestTime.Checked && oeedata5.HoldTime.Year != 1 && oeedata5.HoldTime.DayOfYear - dateTime7.DayOfYear >= 2;
														if (flag88)
														{
															for (int n = num9 + 1; n < list.Count; n = num5 + 1)
															{
																bool flag89 = oeedata5.HoldTime.DayOfYear < dateTime8.AddDays((double)n).DayOfYear;
																if (flag89)
																{
																	list[n] = 86400.0;
																	list2[n] = 1;
																}
																else
																{
																	bool flag90 = oeedata5.HoldTime.DayOfYear == dateTime8.AddDays((double)n).DayOfYear;
																	if (flag90)
																	{
																		totalSeconds2 = (oeedata5.HoldTime - dateTime8.AddDays((double)n)).TotalSeconds;
																		bool flag91 = list[n] + totalSeconds2 + 1.0 < 86400.0;
																		if (flag91)
																		{
																			list[n] += totalSeconds2;
																		}
																		else
																		{
																			list[n] = 86400.0;
																		}
																		list2[n]++;
																		break;
																	}
																}
																num5 = n;
															}
														}
													}
												}
											}
										}
										num5 = num9;
										num9 = num5 + 1;
									}
									dateTime5 = oeedata5.startTime;
								}
								else
								{
									bool flag92 = flag68;
									if (flag92)
									{
										int num11 = 0;
										while ((double)num11 < timeSpan.TotalDays)
										{
											DateTime dateTime9 = dateTime.AddDays((double)num11);
											bool flag93 = dateTime9.DayOfYear == dateTime6.DayOfYear && oeedata5.endTime.DayOfYear == dateTime6.DayOfYear;
											int num5;
											if (flag93)
											{
												double totalSeconds3 = (oeedata5.endTime - dateTime6).TotalSeconds;
												bool flag94 = totalSeconds3 + list[num11] + 1.0 < 86400.0 && oeedata5.endTime.Year > 2000;
												if (flag94)
												{
													list[num11] += totalSeconds3;
													list2[num11]++;
												}
												else
												{
													list[num11] = 86400.0;
												}
											}
											else
											{
												bool flag95 = dateTime9.DayOfYear == dateTime6.DayOfYear && oeedata5.endTime.DayOfYear > dateTime6.DayOfYear;
												if (flag95)
												{
													double totalSeconds4 = (new DateTime(dateTime6.Year, dateTime6.Month, dateTime6.Day, 23, 59, 59) - dateTime6).TotalSeconds;
													bool flag96 = list[num11] + totalSeconds4 + 1.0 < 86400.0;
													if (flag96)
													{
														list[num11] += totalSeconds4;
														list2[num11]++;
													}
													else
													{
														list[num11] = 86400.0;
														list2[num11]++;
													}
													int num12 = 1;
													while (num12 + num11 < list.Count)
													{
														bool flag97 = oeedata5.endTime > dateTime9.AddDays((double)num12) && oeedata5.endTime.DayOfYear != dateTime9.AddDays((double)num12).DayOfYear && dateTime7.DayOfYear == dateTime9.AddDays((double)num12).DayOfYear;
														if (flag97)
														{
															bool flag98 = oeedata5.HoldTime.Year == 1 || !this.rbRequestTime.Checked;
															if (flag98)
															{
																totalSeconds4 = (dateTime7 - new DateTime(dateTime7.Year, dateTime7.Month, dateTime7.Day, 0, 0, 0)).TotalSeconds;
															}
															else
															{
																bool flag99 = oeedata5.HoldTime.Year != 1 && this.rbRequestTime.Checked;
																if (flag99)
																{
																	totalSeconds4 = (oeedata5.HoldTime - dateTime7).TotalSeconds;
																}
															}
															bool flag100 = list[num12 + num11] + totalSeconds4 + 1.0 > 86400.0;
															if (flag100)
															{
																list2[num12 + num11] = 1;
																list[num12 + num11] = 86400.0;
															}
															else
															{
																list[num12 + num11] = list[num12 + num11] + totalSeconds4;
																list2[num12 + num11] = 1;
															}
														}
														else
														{
															bool flag101 = dateTime9.AddDays((double)num12).DayOfYear == oeedata5.endTime.DayOfYear;
															if (flag101)
															{
																totalSeconds4 = (oeedata5.endTime - new DateTime(oeedata5.endTime.Year, oeedata5.endTime.Month, oeedata5.endTime.Day, 0, 0, 0)).TotalSeconds;
																bool flag102 = list[num12 + num11] + totalSeconds4 + 1.0 < 86400.0;
																if (flag102)
																{
																	list[num12 + num11] = list[num12 + num11] + totalSeconds4;
																	list2[num12 + num11] = 1;
																}
																else
																{
																	list[num12 + num11] = 86400.0;
																	list2[num12 + num11] = 1;
																}
															}
															else
															{
																bool flag103 = dateTime9.AddDays((double)num12).DayOfYear < oeedata5.endTime.DayOfYear;
																if (flag103)
																{
																	list2[num12 + num11] = 1;
																	list[num12 + num11] = 86400.0;
																}
															}
														}
														num5 = num12;
														num12 = num5 + 1;
													}
												}
											}
											num5 = num11;
											num11 = num5 + 1;
										}
										dateTime6 = oeedata5.endTime;
									}
									else
									{
										bool flag104 = !flag67 && !flag68;
										if (flag104)
										{
											int num13 = 0;
											while ((double)num13 < timeSpan.TotalDays)
											{
												DateTime dateTime10 = dateTime.AddDays((double)num13);
												bool flag105 = dateTime7.DayOfYear == dateTime10.DayOfYear && oeedata5.endTime.DayOfYear == dateTime10.DayOfYear;
												int num5;
												if (flag105)
												{
													bool flag106 = oeedata5.HoldTime.Year == 1 || !this.rbRequestTime.Checked;
													if (flag106)
													{
														double totalSeconds5 = (oeedata5.endTime - dateTime7).TotalSeconds;
														bool flag107 = totalSeconds5 + 1.0 < 86400.0 && list[num13] + totalSeconds5 < 86400.0 && oeedata5.endTime.Year > 2000;
														if (flag107)
														{
															list[num13] += totalSeconds5;
														}
														else
														{
															list[num13] = 86400.0;
														}
													}
													else
													{
														bool flag108 = oeedata5.HoldTime.Year != 1 && this.rbRequestTime.Checked;
														if (flag108)
														{
															double num14 = (oeedata5.HoldTime - dateTime7).TotalSeconds;
															num14 += (oeedata5.endTime - oeedata5.startTime).TotalSeconds;
															bool flag109 = num14 + 1.0 < 86400.0;
															if (flag109)
															{
																list[num13] += num14;
															}
															else
															{
																list[num13] = 86400.0;
															}
														}
													}
													list2[num13]++;
													dateTime5 = dateTime7;
													dateTime6 = oeedata5.endTime;
												}
												else
												{
													bool flag110 = dateTime7.DayOfYear == dateTime10.DayOfYear && (oeedata5.HoldTime.Year == 1 || !this.rbRequestTime.Checked) && (oeedata5.endTime.Year > dateTime10.Year || oeedata5.endTime.DayOfYear > dateTime10.DayOfYear);
													if (flag110)
													{
														DateTime d = new DateTime(dateTime7.Year, dateTime7.Month, dateTime7.Day, 23, 59, 59);
														double totalSeconds6 = (d - dateTime7).TotalSeconds;
														bool flag111 = totalSeconds6 + 1.0 < 86400.0;
														if (flag111)
														{
															list[num13] += totalSeconds6;
														}
														else
														{
															list[num13] = 86400.0;
														}
														list2[num13]++;
														dateTime5 = dateTime7;
														dateTime6 = oeedata5.endTime;
														int num15 = 1;
														while ((double)num15 < Math.Ceiling(timeSpan.TotalDays))
														{
															bool flag112 = num15 + num13 >= list.Count;
															if (flag112)
															{
																break;
															}
															DateTime d2 = dateTime10.AddDays((double)num15);
															bool flag113 = oeedata5.endTime.DayOfYear >= d2.DayOfYear && oeedata5.endTime.Year == d2.Year;
															if (flag113)
															{
																totalSeconds6 = (oeedata5.endTime - d2).TotalSeconds;
																bool flag114 = totalSeconds6 + 1.0 < 86400.0 && oeedata5.endTime.Year > 2000;
																if (flag114)
																{
																	list[num15 + num13] = list[num15 + num13] + totalSeconds6;
																	list2[num15 + num13] = list2[num15 + num13] + 1;
																}
																else
																{
																	list[num13 + num15] = 86400.0;
																	list2[num13 + num15] = list2[num15 + num13] + 1;
																}
															}
															num5 = num15;
															num15 = num5 + 1;
														}
													}
													else
													{
														bool flag115 = dateTime7 < dateTime10 && oeedata5.HoldTime.Year != 1 && oeedata5.HoldTime.DayOfYear > dateTime10.DayOfYear && oeedata5.HoldTime.Year == dateTime10.Year && oeedata5.startTime.DayOfYear != dateTime10.DayOfYear && this.rbRequestTime.Checked;
														if (flag115)
														{
															list[num13] = 86400.0;
															list2[num13]++;
														}
														else
														{
															bool flag116 = oeedata5.HoldTime.Year != 1 && oeedata5.requestTime.DayOfYear == dateTime10.DayOfYear && oeedata5.requestTime.DayOfYear < oeedata5.HoldTime.DayOfYear && this.rbRequestTime.Checked;
															if (flag116)
															{
																DateTime dateTime11 = new DateTime(oeedata5.requestTime.Year, oeedata5.requestTime.Month, oeedata5.requestTime.Day, 23, 59, 59);
																double totalSeconds7 = new TimeSpan(dateTime11.Ticks - oeedata5.requestTime.Ticks).TotalSeconds;
																bool flag117 = list[num13] + totalSeconds7 < 86400.0;
																if (flag117)
																{
																	list[num13] += totalSeconds7;
																}
																else
																{
																	list[num13] = 86400.0;
																}
																list2[num13]++;
															}
															else
															{
																bool flag118 = oeedata5.HoldTime.Year != 1 && this.diffDay(oeedata5.HoldTime, dateTime10) == 0 && this.diffDay(oeedata5.requestTime, dateTime10) != 0 && this.rbRequestTime.Checked;
																if (flag118)
																{
																	DateTime dateTime12 = new DateTime(dateTime10.Year, dateTime10.Month, dateTime10.Day, 0, 0, 0);
																	double totalSeconds8 = new TimeSpan(oeedata5.HoldTime.Ticks - dateTime12.Ticks).TotalSeconds;
																	bool flag119 = list[num13] + totalSeconds8 < 86400.0;
																	if (flag119)
																	{
																		list[num13] += totalSeconds8;
																	}
																	else
																	{
																		list[num13] = 86400.0;
																	}
																	list2[num13]++;
																	bool flag120 = this.dtEndDate.Value >= oeedata5.startTime;
																	if (flag120)
																	{
																		bool flag121 = oeedata5.endTime.Year >= 2000;
																		if (flag121)
																		{
																			int num16 = oeedata5.endTime.DayOfYear - oeedata5.startTime.DayOfYear;
																			bool flag122 = num16 == 0;
																			if (flag122)
																			{
																				totalSeconds8 = new TimeSpan(oeedata5.endTime.Ticks - oeedata5.startTime.Ticks).TotalSeconds;
																				bool flag123 = oeedata5.startTime.Year != dateTime10.Year || (oeedata5.startTime.Year == dateTime10.Year && oeedata5.startTime.DayOfYear != dateTime10.DayOfYear);
																				if (flag123)
																				{
																					bool flag124 = totalSeconds8 + list[num13 + this.diffDay(oeedata5.startTime, dateTime10)] >= 86400.0;
																					if (flag124)
																					{
																						list[num13 + this.diffDay(oeedata5.startTime, dateTime10)] = 86400.0;
																					}
																					else
																					{
																						list[num13 + this.diffDay(oeedata5.startTime, dateTime10)] = list[num13 + this.diffDay(oeedata5.startTime, dateTime10)] + totalSeconds8;
																					}
																					list2[num13 + this.diffDay(oeedata5.startTime, dateTime10)] = list2[num13 + this.diffDay(oeedata5.startTime, dateTime10)] + 1;
																				}
																				else
																				{
																					bool flag125 = totalSeconds8 + list[num13] >= 86400.0;
																					if (flag125)
																					{
																						list[num13] = 86400.0;
																					}
																					else
																					{
																						list[num13] += totalSeconds8;
																					}
																				}
																			}
																			else
																			{
																				for (int num17 = 0; num17 <= num16; num17 = num5 + 1)
																				{
																					bool flag126 = dateTime10.AddDays((double)num17).DayOfYear < oeedata5.endTime.DayOfYear && oeedata5.startTime.DayOfYear != dateTime10.AddDays((double)num17).DayOfYear;
																					if (flag126)
																					{
																						list[num13 + num17] = 86400.0;
																					}
																					else
																					{
																						bool flag127 = false;
																						bool flag128 = oeedata5.startTime.DayOfYear == dateTime10.AddDays((double)num17).DayOfYear;
																						if (flag128)
																						{
																							totalSeconds8 = new TimeSpan(dateTime10.AddDays((double)num17).AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0).Ticks - oeedata5.startTime.Ticks).TotalSeconds;
																							flag127 = true;
																						}
																						else
																						{
																							bool flag129 = oeedata5.endTime.DayOfYear == dateTime10.AddDays((double)num17).DayOfYear;
																							if (flag129)
																							{
																								totalSeconds8 = new TimeSpan(oeedata5.endTime.Ticks - dateTime10.AddDays((double)num17).Ticks).TotalSeconds;
																								flag127 = true;
																							}
																						}
																						bool flag130 = flag127;
																						if (flag130)
																						{
																							bool flag131 = totalSeconds8 + list[num13 + num17] >= 86400.0;
																							if (flag131)
																							{
																								list[num13 + num17] = 86400.0;
																							}
																							else
																							{
																								list[num13 + num17] = list[num13 + num17] + totalSeconds8;
																							}
																						}
																					}
																					list2[num13 + num17] = 1;
																					num5 = num17;
																				}
																			}
																		}
																		else
																		{
																			list2[num13]++;
																		}
																	}
																}
																else
																{
																	bool flag132 = oeedata5.requestTime.DayOfYear == dateTime10.DayOfYear && oeedata5.HoldTime.Year != 1 && oeedata5.requestTime.DayOfYear != oeedata5.HoldTime.DayOfYear && this.rbRequestTime.Checked;
																	if (flag132)
																	{
																		double totalSeconds9 = new TimeSpan(new DateTime(oeedata5.requestTime.Year, oeedata5.requestTime.Month, oeedata5.requestTime.Day, 23, 59, 59).Ticks - oeedata5.requestTime.Ticks).TotalSeconds;
																		bool flag133 = list[num13] + totalSeconds9 < 86400.0;
																		if (flag133)
																		{
																			list[num13] += totalSeconds9;
																		}
																		else
																		{
																			list[num13] = 86400.0;
																		}
																		list2[num13]++;
																		int num18 = (int)new TimeSpan(new DateTime(oeedata5.HoldTime.Year, oeedata5.HoldTime.Month, oeedata5.HoldTime.Day, 0, 0, 0).Ticks - new DateTime(oeedata5.requestTime.Year, oeedata5.requestTime.Month, oeedata5.requestTime.Day, 0, 0, 0).Ticks).TotalDays;
																		for (int num19 = 1; num19 < num18; num19 = num5 + 1)
																		{
																			DateTime t2 = dateTime10.AddDays((double)num19);
																			bool flag134 = t2 < oeedata5.HoldTime;
																			if (!flag134)
																			{
																				totalSeconds9 = new TimeSpan(oeedata5.HoldTime.Ticks - t2.Ticks).TotalSeconds;
																				bool flag135 = list[num13] + totalSeconds9 < 86400.0;
																				if (flag135)
																				{
																					list[num13] += totalSeconds9;
																				}
																				else
																				{
																					list[num13] = 86400.0;
																				}
																				list2[num13 + num19] = list2[num13 + num19] + 1;
																				break;
																			}
																			list[num13 + num19] = 86400.0;
																			list2[num13 + num19] = list2[num13 + num19] + 1;
																			num5 = num19;
																		}
																	}
																	else
																	{
																		bool flag136 = oeedata5.HoldTime.Year != 1 && this.diffDay(oeedata5.HoldTime, dateTime10) == 0 && this.diffDay(oeedata5.HoldTime, oeedata5.requestTime) == 0 && this.rbRequestTime.Checked;
																		if (flag136)
																		{
																			double totalSeconds10 = new TimeSpan(oeedata5.HoldTime.Ticks - oeedata5.requestTime.Ticks).TotalSeconds;
																			bool flag137 = totalSeconds10 + list[num13] >= 86400.0;
																			if (flag137)
																			{
																				list[num13] = 86400.0;
																			}
																			else
																			{
																				list[num13] += totalSeconds10;
																			}
																			list2[num13]++;
																			bool flag138 = this.dtEndDate.Value >= oeedata5.startTime;
																			if (flag138)
																			{
																				bool flag139 = oeedata5.endTime.Year >= 2000;
																				if (flag139)
																				{
																					int num20 = oeedata5.endTime.DayOfYear - oeedata5.startTime.DayOfYear;
																					bool flag140 = num20 == 0;
																					if (flag140)
																					{
																						totalSeconds10 = new TimeSpan(oeedata5.endTime.Ticks - oeedata5.startTime.Ticks).TotalSeconds;
																						bool flag141 = oeedata5.startTime.Year != dateTime10.Year || (oeedata5.startTime.Year == dateTime10.Year && oeedata5.startTime.DayOfYear != dateTime10.DayOfYear);
																						if (flag141)
																						{
																							bool flag142 = totalSeconds10 + list[num13 + this.diffDay(oeedata5.startTime, dateTime10)] >= 86400.0;
																							if (flag142)
																							{
																								list[num13 + this.diffDay(oeedata5.startTime, dateTime10)] = 86400.0;
																							}
																							else
																							{
																								list[num13 + this.diffDay(oeedata5.startTime, dateTime10)] = list[num13 + this.diffDay(oeedata5.startTime, dateTime10)] + totalSeconds10;
																							}
																							bool flag143 = oeedata5.requestTime.DayOfYear != oeedata5.endTime.DayOfYear;
																							if (flag143)
																							{
																								list2[num13 + this.diffDay(oeedata5.startTime, dateTime10)] = list2[num13 + this.diffDay(oeedata5.startTime, dateTime10)] + 1;
																							}
																						}
																						else
																						{
																							bool flag144 = totalSeconds10 + list[num13] >= 86400.0;
																							if (flag144)
																							{
																								list[num13] = 86400.0;
																							}
																							else
																							{
																								list[num13] += totalSeconds10;
																							}
																							bool flag145 = oeedata5.requestTime.DayOfYear != oeedata5.endTime.DayOfYear;
																							if (flag145)
																							{
																								list2[num13]++;
																							}
																						}
																					}
																					else
																					{
																						bool flag146 = num20 == 0 && dateTime7.DayOfYear != oeedata5.endTime.DayOfYear && this.dtEndDate.Value >= oeedata5.endTime;
																						if (flag146)
																						{
																							int num21 = 0;
																							while ((double)num21 < timeSpan.TotalDays)
																							{
																								bool flag147 = dateTime7.AddDays((double)num21).DayOfYear == oeedata5.endTime.DayOfYear;
																								if (flag147)
																								{
																									totalSeconds10 = new TimeSpan(oeedata5.endTime.Ticks - oeedata5.startTime.Ticks).TotalSeconds;
																									bool flag148 = totalSeconds10 + list[num13 + num21] >= 86400.0;
																									if (flag148)
																									{
																										list[num13 + num21] = 86400.0;
																									}
																									else
																									{
																										list[num13 + num21] = list[num13 + num21] + totalSeconds10;
																									}
																									list2[num13 + num21] = 1;
																									break;
																								}
																								num5 = num21;
																								num21 = num5 + 1;
																							}
																						}
																						else
																						{
																							for (int num22 = 0; num22 <= num20; num22 = num5 + 1)
																							{
																								bool flag149 = dateTime10.AddDays((double)num22).DayOfYear < oeedata5.endTime.DayOfYear && oeedata5.startTime.DayOfYear < dateTime10.AddDays((double)num22).DayOfYear;
																								if (flag149)
																								{
																									list[num13 + num22] = 86400.0;
																								}
																								else
																								{
																									bool flag150 = false;
																									bool flag151 = oeedata5.startTime.DayOfYear == dateTime10.AddDays((double)num22).DayOfYear;
																									if (flag151)
																									{
																										totalSeconds10 = new TimeSpan(dateTime10.AddDays((double)num22).AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0).Ticks - oeedata5.startTime.Ticks).TotalSeconds;
																										flag150 = true;
																										bool flag152 = this.diffDay(oeedata5.requestTime, oeedata5.startTime) != 0;
																										if (flag152)
																										{
																											list2[num13 + num22] = list2[num13 + num22] + 1;
																										}
																									}
																									else
																									{
																										bool flag153 = oeedata5.endTime.DayOfYear == dateTime10.AddDays((double)num22).DayOfYear;
																										if (flag153)
																										{
																											totalSeconds10 = new TimeSpan(oeedata5.endTime.Ticks - dateTime10.AddDays((double)num22).Ticks).TotalSeconds;
																											flag150 = true;
																											bool flag154 = this.diffDay(oeedata5.requestTime, oeedata5.endTime) != 0;
																											if (flag154)
																											{
																												list2[num13 + num22] = list2[num13 + num22] + 1;
																											}
																										}
																									}
																									bool flag155 = flag150;
																									if (flag155)
																									{
																										bool flag156 = totalSeconds10 + list[num13 + num22] >= 86400.0;
																										if (flag156)
																										{
																											list[num13 + num22] = 86400.0;
																										}
																										else
																										{
																											list[num13 + num22] = list[num13 + num22] + totalSeconds10;
																										}
																									}
																								}
																								num5 = num22;
																							}
																						}
																					}
																				}
																				else
																				{
																					list2[num13]++;
																				}
																			}
																		}
																		else
																		{
																			bool flag157 = oeedata5.HoldTime.Year != 1 && oeedata5.startTime.DayOfYear == dateTime10.DayOfYear && this.rbRequestTime.Checked;
																			if (flag157)
																			{
																				double num23 = 0.0;
																				int num24 = oeedata5.endTime.DayOfYear - oeedata5.startTime.DayOfYear;
																				int num25 = 0;
																				while (num25 <= num24 && num24 != 0)
																				{
																					bool flag158 = dateTime10.AddDays((double)num25).DayOfYear < oeedata5.endTime.DayOfYear && oeedata5.startTime.DayOfYear != dateTime10.AddDays((double)num25).DayOfYear;
																					if (flag158)
																					{
																						list[num13 + num25] = 86400.0;
																						list2[num13 + num25] = list2[num13 + num25] + 1;
																					}
																					else
																					{
																						bool flag159 = false;
																						bool flag160 = oeedata5.startTime.DayOfYear == dateTime10.AddDays((double)num25).DayOfYear;
																						if (flag160)
																						{
																							num23 = new TimeSpan(dateTime10.AddDays((double)num25).AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0).Ticks - oeedata5.startTime.Ticks).TotalSeconds;
																							flag159 = true;
																						}
																						else
																						{
																							bool flag161 = oeedata5.endTime.DayOfYear == dateTime10.AddDays((double)num25).DayOfYear;
																							if (flag161)
																							{
																								num23 = new TimeSpan(oeedata5.endTime.Ticks - dateTime10.AddDays((double)num25).Ticks).TotalSeconds;
																								flag159 = true;
																							}
																						}
																						bool flag162 = flag159;
																						if (flag162)
																						{
																							bool flag163 = num23 + list[num13 + num25] >= 86400.0;
																							if (flag163)
																							{
																								list[num13 + num25] = 86400.0;
																							}
																							else
																							{
																								list[num13 + num25] = list[num13 + num25] + num23;
																							}
																							list2[num13 + num25] = list2[num13 + num25] + 1;
																						}
																					}
																					num5 = num25;
																					num25 = num5 + 1;
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
												num5 = num13;
												num13 = num5 + 1;
											}
										}
									}
								}
							}
						}
					}
					else
					{
						bool checked11 = this.rbMTBF.Checked;
						if (checked11)
						{
							bool checked12 = this.rbProductionHour.Checked;
							if (checked12)
							{
								foreach (TrendForm.OEEData oeedata6 in keyValuePair.Value)
								{
									bool flag164 = oeedata6.requestTime.Year > 2000;
									if (flag164)
									{
										int num5 = num3;
										num3 = num5 + 1;
									}
									bool flag165 = oeedata6.ACTLMin == 0.0;
									if (!flag165)
									{
										int num26 = 0;
										while ((double)num26 < Math.Ceiling(timeSpan.TotalDays))
										{
											DateTime t3 = new DateTime(dateTime.AddDays((double)num26).Year, dateTime.AddDays((double)num26).Month, dateTime.AddDays((double)num26).Day, 6, 0, 0);
											DateTime t4 = new DateTime(dateTime.AddDays((double)(num26 + 1)).Year, dateTime.AddDays((double)(num26 + 1)).Month, dateTime.AddDays((double)(num26 + 1)).Day, 6, 0, 0);
											bool flag166 = t3 <= oeedata6.startTimeMTBF && t4 >= oeedata6.endTimeMTBF && oeedata6.ACTLMin != 0.0;
											if (flag166)
											{
												list[num26] += oeedata6.ACTLMin * 60.0;
												break;
											}
											int num5 = num26;
											num26 = num5 + 1;
										}
									}
								}
							}
							else
							{
								bool checked13 = this.rbDayHour.Checked;
								if (checked13)
								{
									num3 += keyValuePair.Value.Count<TrendForm.OEEData>();
									int num27 = 0;
									while ((double)num27 < Math.Ceiling(timeSpan.TotalDays))
									{
										list[num27] = 86400.0;
										int num5 = num27;
										num27 = num5 + 1;
									}
								}
							}
							foreach (TrendForm.OEEData oeedata7 in keyValuePair.Value)
							{
								bool flag167 = oeedata7.ACTLMin != 0.0;
								if (!flag167)
								{
									int num28 = 0;
									while ((double)num28 < timeSpan.TotalDays)
									{
										DateTime t5 = dateTime.AddDays((double)num28);
										DateTime requestTime = oeedata7.requestTime;
										DateTime dateTime13 = new DateTime(t5.Year, t5.Month, t5.Day, 23, 59, 59);
										bool flag168 = oeedata7.requestTime.Year == t5.Year;
										if (flag168)
										{
											bool flag169 = oeedata7.HoldTime.Year == 1;
											if (flag169)
											{
												bool flag170 = oeedata7.requestTime >= t5 && oeedata7.requestTime <= dateTime13;
												if (flag170)
												{
													list2[num28]++;
												}
												else
												{
													bool flag171 = oeedata7.startTime >= t5 && oeedata7.endTime <= dateTime13;
													if (flag171)
													{
														list2[num28]++;
													}
												}
											}
											else
											{
												bool flag172 = (oeedata7.requestTime >= t5 && oeedata7.requestTime <= dateTime13) || (oeedata7.requestTime < t5 && dateTime13 < oeedata7.HoldTime);
												if (flag172)
												{
													list2[num28]++;
												}
												else
												{
													bool flag173 = oeedata7.HoldTime >= t5 && oeedata7.HoldTime <= dateTime13;
													if (flag173)
													{
														list2[num28]++;
													}
													else
													{
														bool flag174 = (oeedata7.startTime >= t5 && oeedata7.endTime <= dateTime13) || (oeedata7.startTime < t5 && dateTime13 < oeedata7.endTime) || (oeedata7.startTime.Year == t5.Year && oeedata7.startTime.Month == t5.Month && oeedata7.startTime.Day == t5.Day);
														if (flag174)
														{
															bool flag175 = oeedata7.startTime.DayOfYear != oeedata7.HoldTime.DayOfYear;
															if (flag175)
															{
																list2[num28]++;
															}
														}
														else
														{
															bool flag176 = oeedata7.endTime.Year == t5.Year && oeedata7.endTime.Month == t5.Month && oeedata7.endTime.Day == t5.Day;
															if (flag176)
															{
																list2[num28]++;
															}
														}
													}
												}
											}
										}
										else
										{
											bool flag177 = oeedata7.requestTime.Year < t5.Year;
											if (flag177)
											{
												bool flag178 = oeedata7.HoldTime >= t5 && oeedata7.HoldTime <= dateTime13;
												if (flag178)
												{
													list2[num28]++;
												}
												else
												{
													bool flag179 = oeedata7.startTime >= t5 && oeedata7.endTime <= dateTime13;
													if (flag179)
													{
														bool flag180 = oeedata7.startTime.DayOfYear != oeedata7.HoldTime.DayOfYear;
														if (flag180)
														{
															list2[num28]++;
														}
													}
												}
											}
										}
										int num5 = num28;
										num28 = num5 + 1;
									}
								}
							}
						}
					}
					bool flag181 = false;
					int num29 = 0;
					while ((double)num29 < timeSpan.TotalDays)
					{
						double num30 = 0.0;
						bool checked14 = this.rbMTTR.Checked;
						if (checked14)
						{
							bool flag182 = list2[num29] != 0;
							if (flag182)
							{
								bool flag183 = list[num29] < 86400.0;
								if (flag183)
								{
									num30 = list[num29] / (double)list2[num29];
								}
								else
								{
									num30 = 86400.0;
									list2[num29] = 1;
								}
								bool flag184 = list2[num29] > 5;
								if (flag184)
								{
									flag181 = true;
								}
								num += list[num29];
							}
						}
						else
						{
							bool checked15 = this.rbMTBF.Checked;
							if (checked15)
							{
								bool flag185 = list2[num29] != 0;
								if (flag185)
								{
									num30 = list[num29] / (double)(list2[num29] + 1);
									num4 += list2[num29];
								}
								else
								{
									num30 = list[num29];
								}
								num += list[num29];
								num7 += list[num29];
								bool flag186 = list2[num29] > 5;
								if (flag186)
								{
									flag181 = true;
								}
							}
						}
						double num31 = Math.Round(num30 / 3600.0 * 100.0) / 100.0;
						this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Points[num29].SetValueY(new object[]
						{
							num31
						});
						bool flag187 = num31 != 0.0;
						if (flag187)
						{
							this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Points[num29].Label = Convert.ToString(num31);
						}
						int num5 = num29;
						num29 = num5 + 1;
					}
					num2 += Math.Round(num7 / 3600.0 * 100.0) / 100.0 / (double)(num4 + 1);
					this.maintOEEChart.Series.Add(keyValuePair.Key + " FAILURE");
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].ChartType = SeriesChartType.Line;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Font = new Font(this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Font.FontFamily, this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].YAxisType = AxisType.Secondary;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].XAxisType = AxisType.Primary;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].BorderWidth = 2;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].YValueType = ChartValueType.Int32;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].XValueType = ChartValueType.Date;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].MarkerSize = 8;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].MarkerStyle = MarkerStyle.Circle;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].ToolTip = "#SERIESNAME : #VALY{G}";
					this.maintOEEChart.ChartAreas[0].AxisY2.Maximum = 4.0;
					this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].IsVisibleInLegend = false;
					int num32 = 0;
					while ((double)num32 < timeSpan.TotalDays)
					{
						this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Points.AddY((double)list2[num32]);
						bool flag188 = list2[num32] != 0;
						if (flag188)
						{
							this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Points[this.maintOEEChart.Series[this.maintOEEChart.Series.Count - 1].Points.Count - 1].Label = Convert.ToString(list2[num32]);
						}
						bool flag189 = this.maintOEEChart.ChartAreas[0].AxisY2.Maximum < (double)list2[num32];
						if (flag189)
						{
							bool flag190 = flag181;
							if (flag190)
							{
								this.maintOEEChart.ChartAreas[0].AxisY2.Maximum = (double)(list2[num32] + 5);
							}
							else
							{
								this.maintOEEChart.ChartAreas[0].AxisY2.Maximum = (double)(list2[num32] + 1);
							}
						}
						int num5 = num32;
						num32 = num5 + 1;
					}
					bool flag191 = flag181;
					if (flag191)
					{
						this.maintOEEChart.ChartAreas[0].AxisY2.IntervalAutoMode = IntervalAutoMode.FixedCount;
						this.maintOEEChart.ChartAreas[0].AxisY2.Interval = 5.0;
					}
					else
					{
						this.maintOEEChart.ChartAreas[0].AxisY2.Interval = 1.0;
					}
				}
				bool checked16 = this.rbMTBF.Checked;
				if (checked16)
				{
					num3++;
				}
				this.maintOEEChart.ChartAreas[0].RecalculateAxesScale();
				num = Math.Round(num / 3600.0 * 100.0) / 100.0;
				bool checked17 = this.rbMTBF.Checked;
				if (checked17)
				{
					this.maintOEEChart.ChartAreas[0].AxisX.Title = string.Format(string.Concat(new string[]
					{
						"MTBF - {0,2}",
						Environment.NewLine,
						"Average MTBF - {2,2}",
						Environment.NewLine,
						"Total Failure - {1}"
					}), this.rbMTBF.Checked ? Math.Round(num / (double)((num3 == 0) ? 1 : num3), 1) : Math.Round(num / (double)((num3 == 0) ? 1 : num3), 1), num3, Math.Round(num2 / (double)this.OEEList.Count, 2));
				}
				else
				{
					this.maintOEEChart.ChartAreas[0].AxisX.Title = string.Format("MTTR - {0,2}" + Environment.NewLine + "TOTAL FAILURE - {1}", this.rbMTBF.Checked ? Math.Round(num / (double)((num3 == 0) ? 1 : num3), 1) : Math.Round(num / (double)((num3 == 0) ? 1 : num3), 1), num3);
				}
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00032150 File Offset: 0x00030350
		private void setMaintChart()
		{
			bool flag = this.maintTrendChart != null;
			if (flag)
			{
				this.maintTrendChart.Dispose();
			}
			this.maintTrendChart = new TrendForm.DoubleBufferChart();
			this.maintTrendChart.Visible = true;
			this.maintTrendChart.Parent = this.pnChartBase;
			this.maintTrendChart.Dock = DockStyle.Fill;
			this.maintTrendChart.Cursor = Cursors.Hand;
			this.defaultHeight = this.maintTrendChart.Size.Height;
			this.defaultWidth = this.maintTrendChart.Size.Width;
			this.maintTrendChart.MouseClick += this.maintTrendChart_MouseClick;
			this.maintTrendChart.ChartAreas.Add(string.Empty);
			this.maintTrendChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
			this.maintTrendChart.ChartAreas[0].AlignWithChartArea = "NotSet";
			this.maintTrendChart.ChartAreas[0].AxisX.Interval = 1.0;
			this.maintTrendChart.ChartAreas[0].AxisY.Interval = 1.0;
			this.maintTrendChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.maintTrendChart.Titles.Add("※click chart bar for detail information");
			this.maintTrendChart.Titles[0].DockedToChartArea = this.maintTrendChart.ChartAreas[0].Name;
			this.maintTrendChart.Titles[0].Alignment = System.Drawing.ContentAlignment.TopRight;
			this.maintTrendChart.Titles[0].Font = new Font("맑은 고딕", 8f, FontStyle.Bold);
			this.maintTrendChart.ChartAreas[0].AxisY.TitleFont = new Font("맑은 고딕", 10f, FontStyle.Bold);
			this.maintTrendChart.ChartAreas[0].AxisY.Title = "REPORT(ea)";
			this.maintTrendChart.Legends.Clear();
			this.maintTrendChart.Series.Clear();
			this.maintTrendChart.Legends.Add(string.Empty);
			this.maintTrendChart.Legends[0].Font = new Font(this.maintTrendChart.Legends[0].Font.FontFamily, this.maintTrendChart.Legends[0].Font.Size, FontStyle.Bold);
			this.maintTrendChart.Legends[0].LegendStyle = LegendStyle.Row;
			this.maintTrendChart.Legends[0].Docking = Docking.Bottom;
			this.maintTrendChart.Legends[0].Alignment = StringAlignment.Center;
			this.maintTrendChart.Series.Add("Request");
			this.maintTrendChart.Series.Add("Close");
			this.maintTrendChart.Series.Add("Hold");
			this.maintTrendChart.Series[0].ChartType = SeriesChartType.StackedColumn;
			this.maintTrendChart.Series[1].ChartType = SeriesChartType.StackedColumn;
			this.maintTrendChart.Series[2].ChartType = SeriesChartType.StackedColumn;
			this.maintTrendChart.Series[0].Font = new Font(this.maintTrendChart.Series[0].Font.FontFamily, this.maintTrendChart.Series[0].Font.Size, FontStyle.Bold);
			this.maintTrendChart.Series[1].Font = new Font(this.maintTrendChart.Series[1].Font.FontFamily, this.maintTrendChart.Series[1].Font.Size, FontStyle.Bold);
			this.maintTrendChart.Series[2].Font = new Font(this.maintTrendChart.Series[2].Font.FontFamily, this.maintTrendChart.Series[2].Font.Size, FontStyle.Bold);
			this.maintTrendChart.Series[0].Color = Color.FromArgb(242, 203, 98);
			this.maintTrendChart.Series[1].Color = Color.Silver;
			this.maintTrendChart.Series[2].Color = Color.Yellow;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00032650 File Offset: 0x00030850
		private void setCaseChart()
		{
			bool flag = this.maintCaseChart != null;
			if (flag)
			{
				this.maintCaseChart.Dispose();
			}
			this.maintCaseChart = new TrendForm.DoubleBufferChart();
			this.maintCaseChart.Parent = this.pnCaseBase;
			this.maintCaseChart.Dock = DockStyle.Fill;
			this.defaultWidth = this.maintCaseChart.Size.Width;
			this.defaultHeight = this.maintCaseChart.Size.Height;
			this.maintCaseChart.Visible = true;
			this.maintCaseChart.MouseClick += this.maintCaseChart_MouseClick;
			this.maintCaseChart.ChartAreas.Add(string.Empty);
			this.maintCaseChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
			this.maintCaseChart.ChartAreas[0].AlignWithChartArea = "NotSet";
			this.maintCaseChart.ChartAreas[0].AxisX.Interval = 1.0;
			this.maintCaseChart.ChartAreas[0].AxisY.Interval = 1.0;
			this.maintCaseChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.maintCaseChart.Cursor = Cursors.Hand;
			this.maintCaseChart.ChartAreas[0].AxisY.TitleFont = new Font("맑은 고딕", 10f, FontStyle.Bold);
			this.maintCaseChart.ChartAreas[0].AxisY.Title = "FACTOR(ea)";
			this.maintCaseChart.Titles.Add("※click chart bar for detail information");
			this.maintCaseChart.Titles[0].DockedToChartArea = this.maintCaseChart.ChartAreas[0].Name;
			this.maintCaseChart.Titles[0].Alignment = System.Drawing.ContentAlignment.TopRight;
			this.maintCaseChart.Titles[0].Font = new Font("맑은 고딕", 8f, FontStyle.Bold);
			this.maintCaseChart.Legends.Clear();
			this.maintCaseChart.Series.Clear();
			this.maintCaseChart.Legends.Add(string.Empty);
			this.maintCaseChart.Legends[0].Font = new Font(this.maintCaseChart.Legends[0].Font.FontFamily, this.maintCaseChart.Legends[0].Font.Size, FontStyle.Bold);
			this.maintCaseChart.Legends[0].LegendStyle = LegendStyle.Row;
			this.maintCaseChart.Legends[0].Docking = Docking.Bottom;
			this.maintCaseChart.Legends[0].Alignment = StringAlignment.Center;
			this.maintCaseChart.Series.Add("Hardware");
			this.maintCaseChart.Series.Add("Software");
			this.maintCaseChart.Series.Add("Other");
			this.maintCaseChart.Series[0].ChartType = SeriesChartType.StackedColumn;
			this.maintCaseChart.Series[1].ChartType = SeriesChartType.StackedColumn;
			this.maintCaseChart.Series[2].ChartType = SeriesChartType.StackedColumn;
			this.maintCaseChart.Series[0].Font = new Font(this.maintCaseChart.Series[0].Font.FontFamily, this.maintCaseChart.Series[0].Font.Size, FontStyle.Bold);
			this.maintCaseChart.Series[1].Font = new Font(this.maintCaseChart.Series[1].Font.FontFamily, this.maintCaseChart.Series[1].Font.Size, FontStyle.Bold);
			this.maintCaseChart.Series[2].Font = new Font(this.maintCaseChart.Series[2].Font.FontFamily, this.maintCaseChart.Series[2].Font.Size, FontStyle.Bold);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00032AF0 File Offset: 0x00030CF0
		private void setFactorListbyModel(string Model)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			Dictionary<string, int> dictionary3 = new Dictionary<string, int>();
			foreach (ReportList.ReportObject reportObject in this.list[this.tvList.Nodes[0].Text].getList())
			{
				bool flag = reportObject.Model == Model;
				if (flag)
				{
					bool flag2 = reportObject.Case.ToUpper() == "HARDWARE";
					if (flag2)
					{
						string text = reportObject.Factor;
						bool flag3 = string.IsNullOrEmpty(text);
						if (flag3)
						{
							text = "UNKNOWN(OLD)";
						}
						bool flag4 = !dictionary.ContainsKey(text);
						if (flag4)
						{
							dictionary.Add(text, 1);
						}
						else
						{
							bool flag5 = dictionary.ContainsKey(text);
							if (flag5)
							{
								int num = dictionary[text];
								dictionary[text] = num + 1;
							}
						}
					}
					else
					{
						bool flag6 = reportObject.Case.ToUpper() == "SOFTWARE";
						if (flag6)
						{
							string text2 = reportObject.Factor;
							bool flag7 = string.IsNullOrEmpty(text2);
							if (flag7)
							{
								text2 = "UNKNOWN(OLD)";
							}
							bool flag8 = !dictionary2.ContainsKey(text2);
							if (flag8)
							{
								dictionary2.Add(text2, 1);
							}
							else
							{
								bool flag9 = dictionary2.ContainsKey(text2);
								if (flag9)
								{
									int num2 = dictionary2[text2];
									dictionary2[text2] = num2 + 1;
								}
							}
						}
						else
						{
							bool flag10 = reportObject.Case.ToUpper() == "OTHER";
							if (flag10)
							{
								string text3 = reportObject.Factor;
								bool flag11 = string.IsNullOrEmpty(text3);
								if (flag11)
								{
									text3 = "UNKNOWN(OLD)";
								}
								bool flag12 = !dictionary3.ContainsKey(text3);
								if (flag12)
								{
									dictionary3.Add(text3, 1);
								}
								else
								{
									bool flag13 = dictionary3.ContainsKey(text3);
									if (flag13)
									{
										int num3 = dictionary3[text3];
										dictionary3[text3] = num3 + 1;
									}
								}
							}
						}
					}
				}
			}
			bool flag14 = dictionary3.Count != 0;
			if (flag14)
			{
				this.setFactorChart3(Model);
				this.maintFactorChart3.Series.Clear();
				this.maintFactorChart3.Series.Add("Factor");
				foreach (KeyValuePair<string, int> keyValuePair in dictionary3)
				{
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].ChartType = SeriesChartType.Pie;
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Font = new Font(this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Font.FontFamily, this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points.AddXY(keyValuePair.Key, new object[]
					{
						keyValuePair.Value
					});
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points[this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair.Key;
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points[this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				}
			}
			bool flag15 = dictionary2.Count != 0;
			if (flag15)
			{
				this.setFactorChart2(Model);
				this.maintFactorChart2.Series.Clear();
				this.maintFactorChart2.Series.Add("Factor");
				foreach (KeyValuePair<string, int> keyValuePair2 in dictionary2)
				{
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].ChartType = SeriesChartType.Pie;
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Font = new Font(this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Font.FontFamily, this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points.AddXY(keyValuePair2.Key, new object[]
					{
						keyValuePair2.Value
					});
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points[this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair2.Key;
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points[this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				}
			}
			bool flag16 = dictionary.Count != 0;
			if (flag16)
			{
				this.setFactorChart1(Model);
				this.maintFactorChart1.Series.Clear();
				this.maintFactorChart1.Series.Add("Factor");
				foreach (KeyValuePair<string, int> keyValuePair3 in dictionary)
				{
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].ChartType = SeriesChartType.Pie;
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Font = new Font(this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Font.FontFamily, this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points.AddXY(keyValuePair3.Key, new object[]
					{
						keyValuePair3.Value
					});
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points[this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair3.Key;
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points[this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				}
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00033428 File Offset: 0x00031628
		private void setFactorListbyCategory(string Category)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			Dictionary<string, int> dictionary3 = new Dictionary<string, int>();
			foreach (ReportList.ReportObject reportObject in this.list[this.tvList.Nodes[0].Text].getList())
			{
				bool flag = reportObject.Category == Category;
				if (flag)
				{
					bool flag2 = reportObject.Case.ToUpper() == "HARDWARE";
					if (flag2)
					{
						string text = reportObject.Factor;
						bool flag3 = string.IsNullOrEmpty(text);
						if (flag3)
						{
							text = "UNKNOWN(OLD)";
						}
						bool flag4 = !dictionary.ContainsKey(text);
						if (flag4)
						{
							dictionary.Add(text, 1);
						}
						else
						{
							bool flag5 = dictionary.ContainsKey(text);
							if (flag5)
							{
								int num = dictionary[text];
								dictionary[text] = num + 1;
							}
						}
					}
					else
					{
						bool flag6 = reportObject.Case.ToUpper() == "SOFTWARE";
						if (flag6)
						{
							string text2 = reportObject.Factor;
							bool flag7 = string.IsNullOrEmpty(text2);
							if (flag7)
							{
								text2 = "UNKNOWN(OLD)";
							}
							bool flag8 = !dictionary2.ContainsKey(text2);
							if (flag8)
							{
								dictionary2.Add(text2, 1);
							}
							else
							{
								bool flag9 = dictionary2.ContainsKey(text2);
								if (flag9)
								{
									int num2 = dictionary2[text2];
									dictionary2[text2] = num2 + 1;
								}
							}
						}
						else
						{
							bool flag10 = reportObject.Case.ToUpper() == "OTHER";
							if (flag10)
							{
								string text3 = reportObject.Factor;
								bool flag11 = string.IsNullOrEmpty(text3);
								if (flag11)
								{
									text3 = "UNKNOWN(OLD)";
								}
								bool flag12 = !dictionary3.ContainsKey(text3);
								if (flag12)
								{
									dictionary3.Add(text3, 1);
								}
								else
								{
									bool flag13 = dictionary3.ContainsKey(text3);
									if (flag13)
									{
										int num3 = dictionary3[text3];
										dictionary3[text3] = num3 + 1;
									}
								}
							}
						}
					}
				}
			}
			bool flag14 = dictionary3.Count != 0;
			if (flag14)
			{
				this.setFactorChart3(Category);
				this.maintFactorChart3.Series.Clear();
				this.maintFactorChart3.Series.Add("Factor");
				foreach (KeyValuePair<string, int> keyValuePair in dictionary3)
				{
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].ChartType = SeriesChartType.Pie;
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Font = new Font(this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Font.FontFamily, this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points.AddXY(keyValuePair.Key, new object[]
					{
						keyValuePair.Value
					});
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points[this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair.Key;
					this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points[this.maintFactorChart3.Series[this.maintFactorChart3.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				}
			}
			bool flag15 = dictionary2.Count != 0;
			if (flag15)
			{
				this.setFactorChart2(Category);
				this.maintFactorChart2.Series.Clear();
				this.maintFactorChart2.Series.Add("Factor");
				foreach (KeyValuePair<string, int> keyValuePair2 in dictionary2)
				{
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].ChartType = SeriesChartType.Pie;
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Font = new Font(this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Font.FontFamily, this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points.AddXY(keyValuePair2.Key, new object[]
					{
						keyValuePair2.Value
					});
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points[this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair2.Key;
					this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points[this.maintFactorChart2.Series[this.maintFactorChart2.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				}
			}
			bool flag16 = dictionary.Count != 0;
			if (flag16)
			{
				this.setFactorChart1(Category);
				this.maintFactorChart1.Series.Clear();
				this.maintFactorChart1.Series.Add("Factor");
				foreach (KeyValuePair<string, int> keyValuePair3 in dictionary)
				{
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].ChartType = SeriesChartType.Pie;
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Font = new Font(this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Font.FontFamily, this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Font.Size, FontStyle.Bold);
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points.AddXY(keyValuePair3.Key, new object[]
					{
						keyValuePair3.Value
					});
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points[this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair3.Key;
					this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points[this.maintFactorChart1.Series[this.maintFactorChart1.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				}
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00033D60 File Offset: 0x00031F60
		private void setFactorChart1(string Equipment)
		{
			bool flag = this.maintFactorChart1 != null;
			if (flag)
			{
				this.maintFactorChart1.Dispose();
			}
			this.pnFactorBase.Visible = true;
			this.maintFactorChart1 = new Chart();
			this.maintFactorChart1.Parent = this.pnFactorBase;
			this.maintFactorChart1.Dock = DockStyle.Fill;
			this.maintFactorChart1.Visible = true;
			this.maintFactorChart1.Titles.Add("<" + Equipment + " HARDWARE FACTOR>");
			this.maintFactorChart1.Titles[0].Font = new Font("맑은 고딕", 8f, FontStyle.Bold);
			this.maintFactorChart1.Titles[0].Alignment = System.Drawing.ContentAlignment.TopCenter;
			this.maintFactorChart1.ChartAreas.Add(string.Empty);
			this.maintFactorChart1.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
			this.maintFactorChart1.ChartAreas[0].AlignWithChartArea = "NotSet";
			this.maintFactorChart1.ChartAreas[0].AxisX.Interval = 1.0;
			this.maintFactorChart1.ChartAreas[0].AxisY.Interval = 1.0;
			this.maintFactorChart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.maintFactorChart1.Legends.Clear();
			this.maintFactorChart1.Series.Clear();
			this.maintFactorChart1.Legends.Add(string.Empty);
			this.maintFactorChart1.Legends[0].Font = new Font(this.maintFactorChart1.Legends[0].Font.FontFamily, this.maintFactorChart1.Legends[0].Font.Size, FontStyle.Bold);
			this.maintFactorChart1.Legends[0].AutoFitMinFontSize = 8;
			string empty = string.Empty;
			string empty2 = string.Empty;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00033F98 File Offset: 0x00032198
		private void setFactorChart2(string Equipment)
		{
			bool flag = this.maintFactorChart2 != null;
			if (flag)
			{
				this.maintFactorChart2.Dispose();
			}
			this.pnFactorBase2.Visible = true;
			this.maintFactorChart2 = new Chart();
			this.maintFactorChart2.Parent = this.pnFactorBase2;
			this.maintFactorChart2.Dock = DockStyle.Fill;
			this.maintFactorChart2.Visible = true;
			this.maintFactorChart2.Titles.Add("<" + Equipment + " SOFTWARE FACTOR>");
			this.maintFactorChart2.Titles[0].Font = new Font("맑은 고딕", 8f, FontStyle.Bold);
			this.maintFactorChart2.Titles[0].Alignment = System.Drawing.ContentAlignment.TopCenter;
			this.maintFactorChart2.ChartAreas.Add(string.Empty);
			this.maintFactorChart2.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
			this.maintFactorChart2.ChartAreas[0].AlignWithChartArea = "NotSet";
			this.maintFactorChart2.ChartAreas[0].AxisX.Interval = 1.0;
			this.maintFactorChart2.ChartAreas[0].AxisY.Interval = 1.0;
			this.maintFactorChart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.maintFactorChart2.Legends.Clear();
			this.maintFactorChart2.Series.Clear();
			this.maintFactorChart2.Legends.Add(string.Empty);
			this.maintFactorChart2.Legends[0].Font = new Font(this.maintFactorChart2.Legends[0].Font.FontFamily, this.maintFactorChart2.Legends[0].Font.Size, FontStyle.Bold);
			string empty = string.Empty;
			string empty2 = string.Empty;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000341B8 File Offset: 0x000323B8
		private void setFactorChart3(string Equipment)
		{
			bool flag = this.maintFactorChart3 != null;
			if (flag)
			{
				this.maintFactorChart3.Dispose();
			}
			this.pnFactorBase3.Visible = true;
			this.maintFactorChart3 = new Chart();
			this.maintFactorChart3.Parent = this.pnFactorBase3;
			this.maintFactorChart3.Dock = DockStyle.Fill;
			this.maintFactorChart3.Visible = true;
			this.maintFactorChart3.Titles.Add("<" + Equipment + " OTHER FACTOR>");
			this.maintFactorChart3.Titles[0].Font = new Font("맑은 고딕", 8f, FontStyle.Bold);
			this.maintFactorChart3.Titles[0].Alignment = System.Drawing.ContentAlignment.TopCenter;
			this.maintFactorChart3.ChartAreas.Add(string.Empty);
			this.maintFactorChart3.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
			this.maintFactorChart3.ChartAreas[0].AlignWithChartArea = "NotSet";
			this.maintFactorChart3.ChartAreas[0].AxisX.Interval = 1.0;
			this.maintFactorChart3.ChartAreas[0].AxisY.Interval = 1.0;
			this.maintFactorChart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.maintFactorChart3.Legends.Clear();
			this.maintFactorChart3.Series.Clear();
			this.maintFactorChart3.Legends.Add(string.Empty);
			this.maintFactorChart3.Legends[0].Font = new Font(this.maintFactorChart3.Legends[0].Font.FontFamily, this.maintFactorChart3.Legends[0].Font.Size, FontStyle.Bold);
			string empty = string.Empty;
			string empty2 = string.Empty;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000343D8 File Offset: 0x000325D8
		private void setOEEChart()
		{
			bool flag = this.maintOEEChart != null;
			if (flag)
			{
				this.maintOEEChart.Dispose();
			}
			this.maintOEEChart = new Chart();
			this.maintOEEChart.Parent = this.pnOEEBase;
			this.maintOEEChart.Dock = DockStyle.Fill;
			this.maintOEEChart.Visible = true;
			this.defaultHeight = this.maintOEEChart.Size.Height;
			this.defaultWidth = this.maintOEEChart.Size.Width;
			this.maintOEEChart.ChartAreas.Add(string.Empty);
			this.maintOEEChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
			this.maintOEEChart.ChartAreas[0].AlignWithChartArea = "NotSet";
			this.maintOEEChart.ChartAreas[0].AxisX.Interval = 1.0;
			this.maintOEEChart.ChartAreas[0].AxisY.Interval = 1.0;
			this.maintOEEChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.maintOEEChart.Legends.Clear();
			this.maintOEEChart.Series.Clear();
			this.maintOEEChart.Legends.Add(string.Empty);
			this.maintOEEChart.Legends[0].Font = new Font(this.maintOEEChart.Legends[0].Font.FontFamily, this.maintOEEChart.Legends[0].Font.Size, FontStyle.Bold);
			this.maintOEEChart.Legends[0].LegendStyle = LegendStyle.Table;
			this.maintOEEChart.Legends[0].Docking = Docking.Bottom;
			this.maintOEEChart.Legends[0].Alignment = StringAlignment.Center;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000345F8 File Offset: 0x000327F8
		private void setBoardChart(out Chart chart, bool isSiteReject)
		{
			chart = new TrendForm.DoubleBufferChart();
			chart.Visible = true;
			chart.Parent = this.pnChartBase;
			chart.Dock = DockStyle.Fill;
			chart.Cursor = Cursors.Hand;
			this.defaultHeight = chart.Size.Height;
			this.defaultWidth = chart.Size.Width;
			chart.MouseClick += this.boardChart_MouseClick;
			chart.ChartAreas.Add(string.Empty);
			chart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
			chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			chart.ChartAreas[0].AxisX.IsLabelAutoFit = false;
			chart.ChartAreas[0].AlignWithChartArea = "NotSet";
			chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			chart.Titles.Add("※If you want to review detail factors, please click a bar in the chart");
			chart.Titles[0].DockedToChartArea = chart.ChartAreas[0].Name;
			chart.Titles[0].Alignment = System.Drawing.ContentAlignment.TopRight;
			chart.Titles[0].Font = new Font("맑은 고딕", 8f, FontStyle.Bold);
			chart.ChartAreas[0].AxisY.TitleFont = new Font("맑은 고딕", 10f, FontStyle.Bold);
			chart.ChartAreas[0].AxisX.TitleFont = new Font("맑은 고딕", 10f, FontStyle.Bold);
			chart.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
			chart.Legends.Clear();
			chart.Series.Clear();
			chart.Legends.Add(string.Empty);
			chart.Legends[0].Font = new Font(chart.Legends[0].Font.FontFamily, chart.Legends[0].Font.Size, FontStyle.Bold);
			chart.Legends[0].LegendStyle = LegendStyle.Table;
			chart.Legends[0].Docking = Docking.Bottom;
			chart.Legends[0].Alignment = StringAlignment.Center;
			if (isSiteReject)
			{
				chart.ChartAreas[0].AxisY.Title = "ea";
				chart.ChartAreas[0].AxisX.Title = "Site No.";
				chart.Series.Add("Good");
				chart.Series.Add("Reject");
				chart.Series.Add("Disable");
				chart.Series[0].ChartType = SeriesChartType.StackedColumn;
				chart.Series[1].ChartType = SeriesChartType.StackedColumn;
				chart.Series[2].ChartType = SeriesChartType.StackedColumn;
				chart.Series[0].Font = new Font(chart.Series[0].Font.FontFamily, chart.Series[0].Font.Size, FontStyle.Bold);
				chart.Series[1].Font = new Font(chart.Series[0].Font.FontFamily, chart.Series[1].Font.Size, FontStyle.Bold);
				chart.Series[2].Font = new Font(chart.Series[0].Font.FontFamily, chart.Series[2].Font.Size, FontStyle.Bold);
				chart.Series[0].Color = Color.LimeGreen;
				chart.Series[1].Color = Color.Red;
				chart.Series[2].Color = Color.Gray;
				chart.Series[0].ToolTip = "#SERIESNAME : #VALY{D}";
				chart.Series[1].ToolTip = "#SERIESNAME : #VALY{D}";
				chart.Series[2].ToolTip = "#SERIESNAME : #VALY{D}";
				this.pnSiteRejectChart.Controls.Clear();
				chart.Parent = this.pnSiteRejectChart;
			}
			else
			{
				chart.ChartAreas[0].AxisY.Title = "ea";
				chart.ChartAreas[0].AxisX.Title = "Reject";
				chart.Series.Add("Reject");
				chart.Series[0].ChartType = SeriesChartType.StackedColumn;
				chart.Series[0].Font = new Font(chart.Series[0].Font.FontFamily, chart.Series[0].Font.Size, FontStyle.Bold);
				chart.Series[0].ToolTip = "#VALX : #VALY{D}";
				this.pnBoardRejectChart.Controls.Clear();
				chart.Parent = this.pnBoardRejectChart;
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00034BBC File Offset: 0x00032DBC
		public void setboardTrend(Chart chart1, Chart chart2)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintBoardSiteMap_Trend]@_Location=N'" + this.tbLocation.Text.Trim() + "', @_isDevice = " + (this.cbDeviceSite.Checked ? "1" : "0");
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			this._SiteBuffer.Clear();
			bool flag = dataSet != null;
			if (flag)
			{
				Dictionary<string, TrendForm.totalstatus> dictionary = new Dictionary<string, TrendForm.totalstatus>();
				Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
				bool flag2 = dataSet.Tables != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataSet.Tables[dataSet.Tables.Count - 1].Rows.Count; i++)
					{
						string key = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["ReportName"].ToString();
						string value = dataSet.Tables[dataSet.Tables.Count - 1].Rows[i]["SiteMap"].ToString();
						bool flag3 = !this._SiteBuffer.ContainsKey(key);
						if (flag3)
						{
							this._SiteBuffer.Add(key, value);
						}
					}
				}
				foreach (KeyValuePair<string, string> keyValuePair in this._SiteBuffer)
				{
					string[] array = keyValuePair.Value.Split(new char[]
					{
						'|'
					});
					foreach (string text in array)
					{
						string[] array3 = text.Split(new char[]
						{
							'@'
						});
						int num3;
						int num2;
						int num = num2 = (num3 = 0);
						bool flag4 = array3 != null && array3.Length == 3;
						if (flag4)
						{
							string key2 = array3[0].Trim();
							string text2 = array3[1].Trim();
							string text3 = array3[2].Trim();
							bool flag5 = Convert.ToInt32(text2.Trim()) == 1;
							if (flag5)
							{
								num2++;
							}
							else
							{
								bool flag6 = Convert.ToInt32(text2.Trim()) == 3;
								if (flag6)
								{
									num++;
								}
								else
								{
									num3++;
								}
							}
							bool flag7 = !dictionary.ContainsKey(key2);
							if (flag7)
							{
								dictionary.Add(key2, new TrendForm.totalstatus
								{
									good = num2,
									disable = num,
									reject = num3
								});
							}
							else
							{
								TrendForm.totalstatus totalstatus = dictionary[key2];
								totalstatus.good += num2;
								totalstatus.reject += num3;
								totalstatus.disable += num;
								dictionary[key2] = totalstatus;
							}
							bool flag8 = Convert.ToInt32(text2.Trim()) == 2;
							if (flag8)
							{
								bool flag9 = text3.IndexOf(',') != -1;
								if (flag9)
								{
									string[] array4 = text3.Split(new char[]
									{
										','
									});
									foreach (string text4 in array4)
									{
										bool flag10 = dictionary2.ContainsKey(text4);
										if (flag10)
										{
											Dictionary<string, int> dictionary3 = dictionary2;
											string key3 = text4;
											int num4 = dictionary3[key3];
											dictionary3[key3] = num4 + 1;
										}
										else
										{
											dictionary2.Add(text4, 1);
										}
									}
								}
								else
								{
									bool flag11 = dictionary2.ContainsKey(text3);
									if (flag11)
									{
										Dictionary<string, int> dictionary4 = dictionary2;
										string key3 = text3;
										int num4 = dictionary4[key3];
										dictionary4[key3] = num4 + 1;
									}
									else
									{
										dictionary2.Add(text3, 1);
									}
								}
							}
						}
					}
				}
				foreach (KeyValuePair<string, TrendForm.totalstatus> keyValuePair2 in dictionary)
				{
					chart1.Series[0].Points.AddXY((double)Convert.ToInt32(keyValuePair2.Key), (double)keyValuePair2.Value.good);
					chart1.Series[1].Points.AddXY((double)Convert.ToInt32(keyValuePair2.Key), (double)keyValuePair2.Value.reject);
					chart1.Series[2].Points.AddXY((double)Convert.ToInt32(keyValuePair2.Key), (double)keyValuePair2.Value.disable);
				}
				from x in dictionary2
				orderby x.Value
				select x;
				foreach (KeyValuePair<string, int> keyValuePair3 in dictionary2)
				{
					chart2.Series[0].Points.AddXY(keyValuePair3.Key, new object[]
					{
						keyValuePair3.Value
					});
				}
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0003514C File Offset: 0x0003334C
		private void getTotalMainTime()
		{
			foreach (KeyValuePair<string, ReportList> keyValuePair in this.list)
			{
				foreach (ReportList.ReportObject reportObject in keyValuePair.Value.getList())
				{
					Convert.ToDateTime(reportObject.StartTime);
					Convert.ToDateTime(reportObject.EndTime);
				}
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000351FC File Offset: 0x000333FC
		private void maintCaseChart_MouseMove(object sender, MouseEventArgs e)
		{
			HitTestResult hitTestResult = this.maintCaseChart.HitTest(e.X, e.Y);
			bool flag = hitTestResult.ChartElementType == ChartElementType.DataPoint;
			if (flag)
			{
				int num = (int)((DataPoint)hitTestResult.Object).XValue;
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00035244 File Offset: 0x00033444
		private void maintCaseChart_MouseClick(object sender, MouseEventArgs e)
		{
			HitTestResult hitTestResult = this.maintCaseChart.HitTest(e.X, e.Y);
			string text = string.Empty;
			bool flag = hitTestResult.ChartElementType == ChartElementType.AxisLabels && hitTestResult.Axis == this.maintCaseChart.ChartAreas[0].AxisX;
			if (flag)
			{
				text = ((CustomLabel)hitTestResult.Object).Text;
			}
			else
			{
				bool flag2 = hitTestResult.ChartElementType == ChartElementType.DataPoint;
				if (flag2)
				{
					int index = (int)((DataPoint)hitTestResult.Object).XValue;
					text = ((Chart)sender).Series[0].Points[index].AxisLabel.ToString();
				}
			}
			bool flag3 = text != string.Empty;
			if (flag3)
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Search Data....");
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this.splitContainer3.SplitterDistance = 350;
				this.setFactorList(text);
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				bool flag4 = this._barPrograss != null;
				if (flag4)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000353C4 File Offset: 0x000335C4
		private void boardChart_MouseClick(object sender, MouseEventArgs e)
		{
			HitTestResult hitTestResult = ((Chart)sender).HitTest(e.X, e.Y);
			string empty = string.Empty;
			bool flag = hitTestResult.ChartElementType == ChartElementType.DataPoint;
			if (flag)
			{
				int num = (int)((DataPoint)hitTestResult.Object).XValue;
				bool flag2 = num > 0;
				if (flag2)
				{
					this.pnDetailSite.Visible = true;
					this.pnDetailSiteChart.Controls.Clear();
					this.splitContainer4.SplitterDistance = 300;
					this.setDetailSiteChart(num);
				}
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00035458 File Offset: 0x00033658
		private void maintTrendChart_MouseClick(object sender, MouseEventArgs e)
		{
			HitTestResult hitTestResult = this.maintTrendChart.HitTest(e.X, e.Y);
			string text = string.Empty;
			bool flag = hitTestResult.ChartElementType == ChartElementType.AxisLabels && hitTestResult.Axis == this.maintTrendChart.ChartAreas[0].AxisX;
			if (flag)
			{
				text = ((CustomLabel)hitTestResult.Object).Text;
			}
			else
			{
				bool flag2 = hitTestResult.ChartElementType == ChartElementType.DataPoint;
				if (flag2)
				{
					int index = (int)((DataPoint)hitTestResult.Object).XValue;
					text = ((Chart)sender).Series[0].Points[index].AxisLabel.ToString();
				}
			}
			bool flag3 = text != string.Empty;
			if (flag3)
			{
				this.splitContainer2.SplitterDistance = 550;
				this.initGrid();
				this.setReportGrid(text);
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00035548 File Offset: 0x00033748
		private void rbK3_CheckedChanged(object sender, EventArgs e)
		{
			this.list.Clear();
			string text = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTrendData] @_Plant=N'",
				((RadioButton)sender).Text.Trim(),
				"', @_StartDate=N'",
				this.dtStartDate.Value.ToString("yyyy-MM-dd hh:mm:ss"),
				"', @_EndDate=N'",
				this.dtEndDate.Value.ToString("yyyy-MM-dd hh:mm:ss"),
				"', @_flag=N'1'"
			});
			bool flag = this.tcMainPage.SelectedTab == this.tpOEETrand;
			if (flag)
			{
				text = text + ", @_Mode=N'" + (this.rbMTBF.Checked ? "MTBF" : "") + "'";
			}
			DataSet dataSet = this._queryMgr.queryCall(text);
			bool flag2 = dataSet != null && dataSet.Tables.Count > 0;
			if (flag2)
			{
				this.list.Add(((RadioButton)sender).Text.Trim(), new ReportList(dataSet.Tables));
			}
			this.setListbyReport();
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00035670 File Offset: 0x00033870
		private void rbChartMode_CheckedChanged(object sender, EventArgs e)
		{
			this.splitContainer2.SplitterDistance = 0;
			bool @checked = ((RadioButton)sender).Checked;
			if (@checked)
			{
				this.maintTrend();
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000356A4 File Offset: 0x000338A4
		private void tvList_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			bool flag = e.Node.Tag != null && e.Node.Tag.ToString() == "X";
			if (flag)
			{
				e.Node.HideCheckBox();
			}
			e.Node.NodeFont = new Font("굴림", 9f);
			e.DrawDefault = true;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00035710 File Offset: 0x00033910
		private void rbCase_CheckedChanged(object sender, EventArgs e)
		{
			this.splitContainer3.SplitterDistance = 0;
			this.pnFactorBase.Visible = false;
			this.pnFactorBase2.Visible = false;
			this.pnFactorBase3.Visible = false;
			bool @checked = ((RadioButton)sender).Checked;
			if (@checked)
			{
				this.maintCaseTrend();
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00035768 File Offset: 0x00033968
		private void btnSubClose_Click(object sender, EventArgs e)
		{
			this.splitContainer3.SplitterDistance = 0;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00035778 File Offset: 0x00033978
		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.pnDate.Visible = true;
			this.pnOEEType.Visible = false;
			this.gbExcel.Visible = false;
			this.pnMTBFType.Visible = false;
			this.rbK3.Checked = false;
			this.rbK4.Checked = false;
			this.rbK5.Checked = false;
			this.tvList.Nodes.Clear();
			bool flag = this.maintTrendChart != null;
			if (flag)
			{
				this.maintTrendChart.Dispose();
			}
			bool flag2 = this.maintCaseChart != null;
			if (flag2)
			{
				this.maintCaseChart.Dispose();
			}
			bool flag3 = this.maintFactorChart1 != null;
			if (flag3)
			{
				this.maintFactorChart1.Dispose();
			}
			bool flag4 = this.maintFactorChart2 != null;
			if (flag4)
			{
				this.maintFactorChart2.Dispose();
			}
			bool flag5 = this.maintFactorChart3 != null;
			if (flag5)
			{
				this.maintFactorChart3.Dispose();
			}
			bool flag6 = this.maintOEEChart != null;
			if (flag6)
			{
				this.maintOEEChart.Dispose();
			}
			bool flag7 = this.splitContainer2.SplitterDistance != 0;
			if (flag7)
			{
				this.splitContainer2.SplitterDistance = 0;
			}
			bool flag8 = this.splitContainer3.SplitterDistance != 0;
			if (flag8)
			{
				this.splitContainer3.SplitterDistance = 0;
			}
			this.pbSubIndex.Visible = true;
			switch (this.tcMainPage.SelectedIndex)
			{
			case 0:
			case 1:
				this.pnIndexType.Visible = false;
				this.pnOEEType.Visible = false;
				this.pnFactory.Visible = true;
				this.tvList.Visible = true;
				this.pnBaseSearch.Dock = DockStyle.Bottom;
				break;
			case 2:
			{
				bool @checked = this.rbMTBF.Checked;
				if (@checked)
				{
					this.pnIndexType.Visible = false;
					this.pnMTBFType.Visible = true;
				}
				else
				{
					this.pnIndexType.Visible = true;
					this.pnMTBFType.Visible = false;
				}
				this.pnOEEType.Visible = true;
				this.pnFactory.Visible = true;
				this.tvList.Visible = true;
				this.pnBaseSearch.Dock = DockStyle.Bottom;
				break;
			}
			case 3:
			case 4:
			{
				this.pnIndexType.Visible = false;
				this.pnOEEType.Visible = false;
				this.pnFactory.Visible = false;
				this.tvList.Visible = false;
				bool flag9 = this.tcMainPage.SelectedIndex != 5;
				if (flag9)
				{
					this.gbExcel.Visible = true;
				}
				else
				{
					this.gbExcel.Visible = false;
				}
				break;
			}
			case 5:
				this.pnSubIndex2.Visible = true;
				this.pbSubIndex.Visible = false;
				this.splitContainer4.SplitterDistance = 0;
				break;
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00035A6C File Offset: 0x00033C6C
		private void rbMTBF_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.rbMTBF.Checked;
			if (@checked)
			{
				this.pnIndexType.Visible = false;
				this.pnMTBFType.Visible = true;
			}
			else
			{
				this.pnIndexType.Visible = true;
				this.pnMTBFType.Visible = false;
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void maintTrendChart_MouseWheel(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00035AC4 File Offset: 0x00033CC4
		private void initGrid()
		{
			this.grid_trend.Rows.Clear();
			this.InitGridCell();
			this.grid_trend.ColumnsCount = 7;
			this.grid_trend.Rows.Insert(0);
			this.grid_trend[0, 0] = new SourceGrid.Cells.ColumnHeader("Priority");
			this.grid_trend[0, 0].View = this.cell_header1;
			this.grid_trend[0, 1] = new SourceGrid.Cells.ColumnHeader("Status");
			this.grid_trend[0, 1].View = this.cell_header1;
			this.grid_trend[0, 2] = new SourceGrid.Cells.ColumnHeader("Report");
			this.grid_trend[0, 2].View = this.cell_header1;
			this.grid_trend[0, 3] = new SourceGrid.Cells.ColumnHeader("");
			this.grid_trend[0, 3].View = this.cell_header1;
			this.grid_trend[0, 4] = new SourceGrid.Cells.ColumnHeader("Request Time");
			this.grid_trend[0, 4].View = this.cell_header1;
			this.grid_trend[0, 5] = new SourceGrid.Cells.ColumnHeader("Start Time");
			this.grid_trend[0, 5].View = this.cell_header1;
			this.grid_trend[0, 6] = new SourceGrid.Cells.ColumnHeader("End Time");
			this.grid_trend[0, 6].View = this.cell_header1;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00035C60 File Offset: 0x00033E60
		private void InitGridCell()
		{
			Color color = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader.BackColor = color;
			columnHeader.Border = RectangleBorder.NoBorder;
			columnHeader.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_header1 = new SourceGrid.Cells.Views.ColumnHeader();
			this.cell_header1.Background = columnHeader;
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			Color backColor = Color.FromArgb(242, 203, 98);
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader2 = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader2.BackColor = backColor;
			columnHeader2.Border = RectangleBorder.NoBorder;
			columnHeader2.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_Report = new SourceGrid.Cells.Views.Cell();
			this.cell_Report.Background = columnHeader2;
			this.cell_Report.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			Color yellow = Color.Yellow;
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader3 = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader3.BackColor = yellow;
			columnHeader3.Border = RectangleBorder.NoBorder;
			columnHeader3.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_HoldReport = new SourceGrid.Cells.Views.Cell();
			this.cell_HoldReport.Background = columnHeader3;
			this.cell_HoldReport.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			Color silver = Color.Silver;
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader4 = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader4.BackColor = silver;
			columnHeader4.Border = RectangleBorder.NoBorder;
			columnHeader4.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_CloseReport = new SourceGrid.Cells.Views.Cell();
			this.cell_CloseReport.Background = columnHeader4;
			this.cell_CloseReport.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00035DE8 File Offset: 0x00033FE8
		private void setReportGrid(string equipment)
		{
			int num = 1;
			DateTime t = new DateTime(this.dtStartDate.Value.Year, this.dtStartDate.Value.Month, this.dtStartDate.Value.Day, 0, 0, 0);
			DateTime t2 = new DateTime(this.dtEndDate.Value.Year, this.dtEndDate.Value.Month, this.dtEndDate.Value.Day, 23, 59, 59);
			foreach (KeyValuePair<string, ReportList> keyValuePair in this.list)
			{
				foreach (ReportList.ReportObject reportObject in keyValuePair.Value.getList())
				{
					bool flag = reportObject.Machine == equipment || reportObject.Model == equipment || reportObject.Category == equipment;
					if (flag)
					{
						DateTime t3;
						DateTime.TryParse(reportObject.RequestTime, out t3);
						bool flag2 = DateTime.TryParse(reportObject.RequestTime, out t3);
						if (flag2)
						{
							bool flag3 = !(t <= t3) && t2 > t3;
							if (flag3)
							{
								continue;
							}
						}
						this.grid_trend.Rows.Insert(num);
						this.grid_trend[num, 0] = new SourceGrid.Cells.Cell(cConst.convertPriority(reportObject.Priority));
						this.grid_trend[num, 1] = new SourceGrid.Cells.Cell(reportObject.Status);
						this.grid_trend[num, 2] = new SourceGrid.Cells.Cell(reportObject.Report);
						this.grid_trend[num, 3] = new SourceGrid.Cells.Button("View");
						this.grid_trend[num, 4] = new SourceGrid.Cells.Cell(reportObject.RequestTime);
						this.grid_trend[num, 5] = new SourceGrid.Cells.Cell(reportObject.StartTime);
						this.grid_trend[num, 6] = new SourceGrid.Cells.Cell(reportObject.EndTime);
						bool flag4 = reportObject.Status == "Hold";
						if (flag4)
						{
							this.grid_trend[num, 0].View = this.cell_HoldReport;
							this.grid_trend[num, 1].View = this.cell_HoldReport;
							this.grid_trend[num, 2].View = this.cell_HoldReport;
						}
						else
						{
							bool flag5 = reportObject.Status == "Request";
							if (flag5)
							{
								this.grid_trend[num, 0].View = this.cell_Report;
								this.grid_trend[num, 1].View = this.cell_Report;
								this.grid_trend[num, 2].View = this.cell_Report;
							}
							else
							{
								bool flag6 = reportObject.Status == "Close" || reportObject.Status == "Close(H)";
								if (flag6)
								{
									this.grid_trend[num, 0].View = this.cell_CloseReport;
									this.grid_trend[num, 1].View = this.cell_CloseReport;
									this.grid_trend[num, 2].View = this.cell_CloseReport;
								}
							}
						}
						num++;
					}
				}
			}
			this.grid_trend.AutoSizeCells();
			this.grid_trend.Refresh();
			this.grid_trend.Size = new Size(1, 1);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000361F4 File Offset: 0x000343F4
		private void tvList_AfterCheck(object sender, TreeViewEventArgs e)
		{
			bool flag = e.Node.Nodes.Count != 0;
			if (flag)
			{
				for (int i = 0; i < e.Node.Nodes.Count; i++)
				{
					e.Node.Nodes[i].Checked = e.Node.Checked;
				}
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00036260 File Offset: 0x00034460
		private void pnOEEBase_Resize(object sender, EventArgs e)
		{
			bool flag = this.maintOEEChart != null;
			if (flag)
			{
				bool flag2 = this.defaultHeight != this.pnOEEBase.Size.Height;
				if (flag2)
				{
					this.defaultHeight = this.pnOEEBase.Size.Height;
					this.tbChartZoom_MouseUp(this.tbOEEChartZoom, null);
				}
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000362C8 File Offset: 0x000344C8
		private void pnChartBase_Resize(object sender, EventArgs e)
		{
			bool flag = this.maintTrendChart != null;
			if (flag)
			{
				bool flag2 = this.defaultHeight != this.pnChartBase.Size.Height;
				if (flag2)
				{
					this.defaultHeight = this.pnChartBase.Size.Height;
					this.tbChartZoom_MouseUp(this.tbChartZoom, null);
				}
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00036330 File Offset: 0x00034530
		private void tbChartZoom_MouseUp(object sender, MouseEventArgs e)
		{
			bool flag = sender.Equals(this.tbChartZoom);
			if (flag)
			{
				this.maintTrendChart.Dock = DockStyle.None;
				bool flag2 = this.tbChartZoom.Value == 0;
				if (flag2)
				{
					this.maintTrendChart.Size = new Size(this.defaultWidth, this.defaultHeight);
				}
				else
				{
					this.maintTrendChart.Size = new Size(this.defaultWidth + this.defaultWidth / 100 * this.tbChartZoom.Value, this.defaultHeight);
				}
			}
			else
			{
				bool flag3 = sender.Equals(this.tbFactorZoom);
				if (flag3)
				{
					this.maintCaseChart.Dock = DockStyle.None;
					bool flag4 = this.tbFactorZoom.Value == 0;
					if (flag4)
					{
						this.maintCaseChart.Size = new Size(this.defaultWidth, this.defaultHeight);
					}
					else
					{
						this.maintCaseChart.Size = new Size(this.defaultWidth + this.defaultWidth / 100 * this.tbFactorZoom.Value, this.defaultHeight);
					}
				}
				else
				{
					bool flag5 = sender.Equals(this.tbOEEChartZoom) && this.maintOEEChart != null && this.maintOEEChart.Visible;
					if (flag5)
					{
						this.maintOEEChart.Dock = DockStyle.None;
						bool flag6 = this.tbOEEChartZoom.Value == 0;
						if (flag6)
						{
							this.maintOEEChart.Size = new Size(this.defaultWidth, this.defaultHeight);
						}
						else
						{
							int num = (int)(this.dtEndDate.Value - this.dtStartDate.Value).TotalDays / 30;
							bool flag7 = num == 0;
							if (flag7)
							{
								num = 1;
							}
							this.maintOEEChart.Size = new Size(this.defaultWidth + this.defaultWidth / 100 * (this.tbOEEChartZoom.Value * num), this.defaultHeight);
						}
					}
				}
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00036538 File Offset: 0x00034738
		private void pnCaseBase_Resize(object sender, EventArgs e)
		{
			bool flag = this.maintCaseChart != null;
			if (flag)
			{
				bool flag2 = this.defaultHeight != this.pnCaseBase.Size.Height;
				if (flag2)
				{
					this.defaultHeight = this.pnCaseBase.Size.Height;
					this.tbChartZoom_MouseUp(this.tbFactorZoom, null);
				}
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000365A0 File Offset: 0x000347A0
		private void tbChartZoom_KeyUp(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyValue == 37 || e.KeyValue == 39;
			if (flag)
			{
				bool flag2 = sender.Equals(this.tbChartZoom);
				if (flag2)
				{
					this.tbChartZoom_MouseUp(this.tbChartZoom, null);
				}
				else
				{
					bool flag3 = sender.Equals(this.tbFactorZoom);
					if (flag3)
					{
						this.tbChartZoom_MouseUp(this.tbFactorZoom, null);
					}
					else
					{
						bool flag4 = sender.Equals(this.tbOEEChartZoom);
						if (flag4)
						{
							this.tbChartZoom_MouseUp(this.tbOEEChartZoom, null);
						}
					}
				}
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0003662C File Offset: 0x0003482C
		private void tpMaintTrend_Resize(object sender, EventArgs e)
		{
			bool flag = sender.Equals(this.tpMaintTrend);
			if (flag)
			{
				bool flag2 = this.maintTrendChart != null;
				if (flag2)
				{
					this.maintTrendChart.Width = this.tpMaintTrend.Width;
					this.maintTrendChart.Height = this.tpMaintTrend.Height - this.pnCaseChartMode.Height;
					this.defaultWidth = this.maintTrendChart.Width;
					this.defaultHeight = this.maintTrendChart.Height;
					this.tbChartZoom_MouseUp(this.tbChartZoom, null);
				}
			}
			else
			{
				bool flag3 = sender.Equals(this.tpFactorTrend);
				if (flag3)
				{
					bool flag4 = this.maintCaseChart != null;
					if (flag4)
					{
						this.maintCaseChart.Width = this.tpFactorTrend.Width;
						this.maintCaseChart.Height = this.tpFactorTrend.Height - this.pnCaseChartMode.Height;
						this.defaultWidth = this.maintCaseChart.Width;
						this.defaultHeight = this.maintCaseChart.Height;
						this.tbChartZoom_MouseUp(this.tbFactorZoom, null);
					}
				}
				else
				{
					bool flag5 = sender.Equals(this.tpOEETrand);
					if (flag5)
					{
						bool flag6 = this.maintOEEChart != null;
						if (flag6)
						{
							this.maintOEEChart.Width = this.tpOEETrand.Width;
							this.maintOEEChart.Height = this.tpOEETrand.Height - this.pnOEEMode.Height;
							this.defaultWidth = this.maintOEEChart.Width;
							this.defaultHeight = this.maintOEEChart.Height;
							this.tbChartZoom_MouseUp(this.tbOEEChartZoom, null);
						}
					}
				}
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000367F0 File Offset: 0x000349F0
		private void dtStartDate_ValueChanged(object sender, EventArgs e)
		{
			bool @checked = this.rbK3.Checked;
			if (@checked)
			{
				this.rbK3_CheckedChanged(this.rbK3, null);
			}
			else
			{
				bool checked2 = this.rbK4.Checked;
				if (checked2)
				{
					this.rbK3_CheckedChanged(this.rbK4, null);
				}
				else
				{
					bool checked3 = this.rbK5.Checked;
					if (checked3)
					{
						this.rbK3_CheckedChanged(this.rbK5, null);
					}
				}
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0003685C File Offset: 0x00034A5C
		private void grid_trend_Click(object sender, EventArgs e)
		{
			SourceGrid.Grid grid = (SourceGrid.Grid)sender;
			int row = grid.MouseDownPosition.Row;
			int column = grid.MouseDownPosition.Column;
			bool flag = column == 3 && row != 0;
			if (flag)
			{
				string displayText = this.grid_trend[row, 1].DisplayText;
				string displayText2 = this.grid_trend[row, 2].DisplayText;
				string displayText3 = this.grid_trend[row, column - 1].DisplayText;
				cAction cAction = new cAction(displayText2, this._factorySetting, this._cimitarUser);
				cAction.ShowDialog();
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00036900 File Offset: 0x00034B00
		private void setUtilGridHeader()
		{
			this.grid_utilization.Rows.Clear();
			Color color = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader.BackColor = color;
			columnHeader.Border = RectangleBorder.NoBorder;
			columnHeader.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_header1 = new SourceGrid.Cells.Views.ColumnHeader();
			this.cell_header1.Background = columnHeader;
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.grid_utilization.ColumnsCount = 4;
			this.grid_utilization.Rows.Insert(0);
			this.grid_utilization[0, 0] = new SourceGrid.Cells.ColumnHeader("Platform");
			this.grid_utilization[0, 0].View = this.cell_header1;
			this.grid_utilization.Columns[0].Visible = true;
			this.grid_utilization[0, 1] = new SourceGrid.Cells.ColumnHeader("H-CNT");
			this.grid_utilization[0, 1].View = this.cell_header1;
			this.grid_utilization.Columns[1].Visible = true;
			this.grid_utilization[0, 2] = new SourceGrid.Cells.ColumnHeader("STD");
			this.grid_utilization[0, 2].View = this.cell_header1;
			this.grid_utilization.Columns[2].Visible = true;
			this.grid_utilization[0, 3] = new SourceGrid.Cells.ColumnHeader("ACTL");
			this.grid_utilization[0, 3].View = this.cell_header1;
			this.grid_utilization.Columns[3].Visible = true;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00036AD4 File Offset: 0x00034CD4
		private void setUtilGridTester()
		{
			this.grid_utilization_tester.Rows.Clear();
			Color color = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader.BackColor = color;
			columnHeader.Border = RectangleBorder.NoBorder;
			columnHeader.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_header1 = new SourceGrid.Cells.Views.ColumnHeader();
			this.cell_header1.Background = columnHeader;
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.grid_utilization_tester.ColumnsCount = 4;
			this.grid_utilization_tester.Rows.Insert(0);
			this.grid_utilization_tester[0, 0] = new SourceGrid.Cells.ColumnHeader("Platform");
			this.grid_utilization_tester[0, 0].View = this.cell_header1;
			this.grid_utilization_tester.Columns[0].Visible = true;
			this.grid_utilization_tester[0, 1] = new SourceGrid.Cells.ColumnHeader("T-CNT");
			this.grid_utilization_tester[0, 1].View = this.cell_header1;
			this.grid_utilization_tester.Columns[1].Visible = true;
			this.grid_utilization_tester[0, 2] = new SourceGrid.Cells.ColumnHeader("STD");
			this.grid_utilization_tester[0, 2].View = this.cell_header1;
			this.grid_utilization_tester.Columns[2].Visible = true;
			this.grid_utilization_tester[0, 3] = new SourceGrid.Cells.ColumnHeader("ACTL");
			this.grid_utilization_tester[0, 3].View = this.cell_header1;
			this.grid_utilization_tester.Columns[3].Visible = true;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00036CA8 File Offset: 0x00034EA8
		private void setUtilGridHeaderbyHandler()
		{
			this.grid_utilization.Rows.Clear();
			Color color = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader.BackColor = color;
			columnHeader.Border = RectangleBorder.NoBorder;
			columnHeader.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_header1 = new SourceGrid.Cells.Views.ColumnHeader();
			this.cell_header1.Background = columnHeader;
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.grid_utilization.ColumnsCount = 4;
			this.grid_utilization.Rows.Insert(0);
			this.grid_utilization[0, 0] = new SourceGrid.Cells.ColumnHeader("Platform");
			this.grid_utilization[0, 0].View = this.cell_header1;
			this.grid_utilization.Columns[0].Visible = true;
			this.grid_utilization[0, 1] = new SourceGrid.Cells.ColumnHeader("Handler");
			this.grid_utilization[0, 1].View = this.cell_header1;
			this.grid_utilization.Columns[1].Visible = true;
			this.grid_utilization[0, 2] = new SourceGrid.Cells.ColumnHeader("STD");
			this.grid_utilization[0, 2].View = this.cell_header1;
			this.grid_utilization.Columns[2].Visible = true;
			this.grid_utilization[0, 3] = new SourceGrid.Cells.ColumnHeader("ACTL");
			this.grid_utilization[0, 3].View = this.cell_header1;
			this.grid_utilization.Columns[3].Visible = true;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00036E7C File Offset: 0x0003507C
		private void setUtilGridHeaderbyTester()
		{
			this.grid_utilization_tester.Rows.Clear();
			Color color = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			DevAge.Drawing.VisualElements.ColumnHeader columnHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
			columnHeader.BackColor = color;
			columnHeader.Border = RectangleBorder.NoBorder;
			columnHeader.BackgroundColorStyle = BackgroundColorStyle.Solid;
			this.cell_header1 = new SourceGrid.Cells.Views.ColumnHeader();
			this.cell_header1.Background = columnHeader;
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.grid_utilization_tester.ColumnsCount = 4;
			this.grid_utilization_tester.Rows.Insert(0);
			this.grid_utilization_tester[0, 0] = new SourceGrid.Cells.ColumnHeader("Platform");
			this.grid_utilization_tester[0, 0].View = this.cell_header1;
			this.grid_utilization_tester.Columns[0].Visible = true;
			this.grid_utilization_tester[0, 1] = new SourceGrid.Cells.ColumnHeader("Tester");
			this.grid_utilization_tester[0, 1].View = this.cell_header1;
			this.grid_utilization_tester.Columns[1].Visible = true;
			this.grid_utilization_tester[0, 2] = new SourceGrid.Cells.ColumnHeader("STD");
			this.grid_utilization_tester[0, 2].View = this.cell_header1;
			this.grid_utilization_tester.Columns[2].Visible = true;
			this.grid_utilization_tester[0, 3] = new SourceGrid.Cells.ColumnHeader("ACTL");
			this.grid_utilization_tester[0, 3].View = this.cell_header1;
			this.grid_utilization_tester.Columns[3].Visible = true;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00037050 File Offset: 0x00035250
		private void getUtilizationHandler()
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintACTLTime] @_Name=N'', @_Type=N'UTILIZATION_SUMMARY', @_StartDate=N'",
				this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00"),
				"', @_EndDate=N'",
				this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59"),
				"'"
			});
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				TimeSpan timeSpan = this.dtEndDate.Value - this.dtStartDate.Value;
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.grid_utilization.Rows.Insert(i + 1);
					this.grid_utilization[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["result"].ToString());
					this.grid_utilization[i + 1, 2] = new SourceGrid.Cells.Cell(Convert.ToInt32(dataSet.Tables[0].Rows[i]["count"].ToString()) * 24 * ((int)timeSpan.TotalDays + 1));
					this.grid_utilization[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["count"].ToString());
					this.grid_utilization[i + 1, 0] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["hantypenm"].ToString());
				}
				this.grid_utilization.Refresh();
				this.grid_utilization.Size = new Size(1, 1);
				this.grid_utilization.AutoSizeCells();
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00037280 File Offset: 0x00035480
		private void grid_utilization_Click(object sender, EventArgs e)
		{
			SourceGrid.Grid grid = (SourceGrid.Grid)sender;
			int row = grid.MouseDownPosition.Row;
			int column = grid.MouseDownPosition.Column;
			bool flag = !this.bHandlerUtiliMode && column == 0 && row != 0;
			if (flag)
			{
				string displayText = this.grid_utilization[row, 0].DisplayText;
				bool flag2 = string.IsNullOrEmpty(displayText);
				if (!flag2)
				{
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintACTLTime] @_Name=N'', @_Type=N'UTILIZATION_HANDLER', @_StartDate=N'",
						this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00"),
						"', @_EndDate=N'",
						this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59"),
						"', @_handler=N'",
						displayText,
						"'"
					});
					DataSet dataSet = this._queryMgr.queryCall(sQuery);
					bool flag3 = dataSet != null && dataSet.Tables.Count > 0;
					if (flag3)
					{
						this.bHandlerUtiliMode = true;
						TimeSpan timeSpan = this.dtEndDate.Value - this.dtStartDate.Value;
						this.setUtilGridHeaderbyHandler();
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							this.grid_utilization.Rows.Insert(i + 1);
							this.grid_utilization[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["result"].ToString());
							this.grid_utilization[i + 1, 2] = new SourceGrid.Cells.Cell(24 * ((int)timeSpan.TotalDays + 1));
							this.grid_utilization[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["handlername"].ToString());
							this.grid_utilization[i + 1, 0] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["hantypenm"].ToString());
						}
						this.grid_utilization.Refresh();
						this.grid_utilization.Size = new Size(1, 1);
						this.grid_utilization.AutoSizeCells();
					}
				}
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00037514 File Offset: 0x00035714
		private void grid_utilization_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = !this.bHandlerUtiliMode;
			if (flag)
			{
				SourceGrid.Grid grid = (SourceGrid.Grid)sender;
				int row = grid.MouseCellPosition.Row;
				int column = grid.MouseCellPosition.Column;
				bool flag2 = row > 0 && column == 0;
				if (flag2)
				{
					this.Cursor = Cursors.Hand;
				}
				else
				{
					bool flag3 = this.Cursor == Cursors.Hand;
					if (flag3)
					{
						this.Cursor = Cursors.Default;
					}
				}
			}
			else
			{
				bool flag4 = this.Cursor == Cursors.Hand;
				if (flag4)
				{
					this.Cursor = Cursors.Default;
				}
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x000375C8 File Offset: 0x000357C8
		private void getUtilizationTester()
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintACTLTime] @_Name=N'', @_Type=N'UTILIZATION_SUMMARY_TESTER', @_StartDate=N'",
				this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00"),
				"', @_EndDate=N'",
				this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59"),
				"'"
			});
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				TimeSpan timeSpan = this.dtEndDate.Value - this.dtStartDate.Value;
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.grid_utilization_tester.Rows.Insert(i + 1);
					this.grid_utilization_tester[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["result"].ToString());
					this.grid_utilization_tester[i + 1, 2] = new SourceGrid.Cells.Cell(Convert.ToInt32(dataSet.Tables[0].Rows[i]["count"].ToString()) * 24 * ((int)timeSpan.TotalDays + 1));
					this.grid_utilization_tester[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["count"].ToString());
					this.grid_utilization_tester[i + 1, 0] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["platformname"].ToString());
				}
				this.grid_utilization_tester.Refresh();
				this.grid_utilization_tester.Size = new Size(1, 1);
				this.grid_utilization_tester.AutoSizeCells();
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000377F8 File Offset: 0x000359F8
		private void btnExcel_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.tcMainPage.SelectedIndex;
			if (selectedIndex != 3)
			{
				if (selectedIndex == 4)
				{
					this.saveExcel(this.grid_utilization_tester);
				}
			}
			else
			{
				this.saveExcel(this.grid_utilization);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0003783C File Offset: 0x00035A3C
		private void btnExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.btnExcel.Image = Resources.SaveExcel;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00037850 File Offset: 0x00035A50
		private void grid_utilization_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00037860 File Offset: 0x00035A60
		private void grid_utilization_tester_Click(object sender, EventArgs e)
		{
			SourceGrid.Grid grid = (SourceGrid.Grid)sender;
			int row = grid.MouseDownPosition.Row;
			int column = grid.MouseDownPosition.Column;
			bool flag = !this.bHandlerUtiliMode && column == 0 && row != 0;
			if (flag)
			{
				string displayText = this.grid_utilization_tester[row, 0].DisplayText;
				bool flag2 = string.IsNullOrEmpty(displayText);
				if (!flag2)
				{
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintACTLTime] @_Name=N'', @_Type=N'UTILIZATION_TESTER', @_StartDate=N'",
						this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00"),
						"', @_EndDate=N'",
						this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59"),
						"', @_handler=N'",
						displayText,
						"'"
					});
					DataSet dataSet = this._queryMgr.queryCall(sQuery);
					bool flag3 = dataSet != null && dataSet.Tables.Count > 0;
					if (flag3)
					{
						this.bHandlerUtiliMode = true;
						TimeSpan timeSpan = this.dtEndDate.Value - this.dtStartDate.Value;
						this.setUtilGridHeaderbyTester();
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							this.grid_utilization_tester.Rows.Insert(i + 1);
							this.grid_utilization_tester[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["result"].ToString());
							this.grid_utilization_tester[i + 1, 2] = new SourceGrid.Cells.Cell(24 * ((int)timeSpan.TotalDays + 1));
							this.grid_utilization_tester[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["testername"].ToString());
							this.grid_utilization_tester[i + 1, 0] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["platformname"].ToString());
						}
						this.grid_utilization_tester.Refresh();
						this.grid_utilization_tester.Size = new Size(1, 1);
						this.grid_utilization_tester.AutoSizeCells();
					}
				}
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00037AF4 File Offset: 0x00035CF4
		private void calculateDeviceTrend()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			int num = 0;
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTrendData]@_StartDate=N'",
				this.dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00"),
				"', @_EndDate=N'",
				this.dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59"),
				"', @_Plant='K3_DEVICE', @_flag=N'0'"
			});
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet.Tables.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string key = dataSet.Tables[0].Rows[i]["device"].ToString().Trim();
					bool flag2 = dictionary.ContainsKey(key);
					if (flag2)
					{
						int num2 = dictionary[key];
						num2++;
						dictionary[key] = num2;
					}
					else
					{
						dictionary.Add(key, 1);
					}
					num++;
				}
				this.setDeviceChart(dictionary, num);
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00037C34 File Offset: 0x00035E34
		private void setDeviceChart(Dictionary<string, int> data, int total)
		{
			bool flag = this.maintDeviceChart != null;
			if (flag)
			{
				this.maintDeviceChart.Dispose();
			}
			this.pnFactorBase.Visible = true;
			this.maintDeviceChart = new Chart();
			this.maintDeviceChart.Parent = this.pnDeviceTrendBase;
			this.maintDeviceChart.Dock = DockStyle.Fill;
			this.maintDeviceChart.Cursor = Cursors.Hand;
			this.maintDeviceChart.Visible = true;
			this.maintDeviceChart.Titles.Add("Device Maintenance Trend");
			this.maintDeviceChart.Titles[0].Font = new Font("맑은 고딕", 15f, FontStyle.Bold);
			this.maintDeviceChart.Titles[0].Alignment = System.Drawing.ContentAlignment.TopCenter;
			this.maintDeviceChart.ChartAreas.Add(string.Empty);
			this.maintDeviceChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
			this.maintDeviceChart.ChartAreas[0].AlignWithChartArea = "NotSet";
			this.maintDeviceChart.ChartAreas[0].AxisX.Interval = 1.0;
			this.maintDeviceChart.ChartAreas[0].AxisY.Interval = 1.0;
			this.maintDeviceChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.maintDeviceChart.Legends.Clear();
			this.maintDeviceChart.Series.Clear();
			this.maintDeviceChart.Legends.Add(string.Empty);
			this.maintDeviceChart.Legends[0].Font = new Font(this.maintDeviceChart.Legends[0].Font.FontFamily, this.maintDeviceChart.Legends[0].Font.Size, FontStyle.Bold);
			this.maintDeviceChart.Legends[0].Docking = Docking.Bottom;
			this.maintDeviceChart.Legends[0].Alignment = StringAlignment.Center;
			string empty = string.Empty;
			string empty2 = string.Empty;
			this.maintDeviceChart.Series.Clear();
			this.maintDeviceChart.Series.Add("");
			this.maintDeviceChart.Series[0].ToolTip = "#VALX : #VALY{F}%";
			foreach (KeyValuePair<string, int> keyValuePair in data)
			{
				this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].ChartType = SeriesChartType.Doughnut;
				this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Font = new Font(this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Font.FontFamily, this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Font.Size, FontStyle.Bold);
				this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Points.AddXY(keyValuePair.Key, new object[]
				{
					(double)keyValuePair.Value / (double)total * 100.0
				});
				this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Points[this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Points.Count - 1].LabelFormat = "{0:0.00}%";
				this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Points[this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Points.Count - 1].AxisLabel = keyValuePair.Key;
				this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Points[this.maintDeviceChart.Series[this.maintDeviceChart.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00038154 File Offset: 0x00036354
		private int diffDay(DateTime dtStart, DateTime dtEnd)
		{
			dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, 0, 0, 0);
			dtEnd = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, 0, 0, 0);
			return Math.Abs((dtStart - dtEnd).Days);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000381B8 File Offset: 0x000363B8
		private void saveExcel(SourceGrid.Grid grid)
		{
			try
			{
				bool flag = grid.RowsCount > 1;
				if (flag)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx";
					this.saveFileDialog.FilterIndex = 1;
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					bool flag2 = dialogResult == DialogResult.OK;
					if (flag2)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						this._barPrograss.setMax(100);
						this._barPrograss.setValue(100);
						Thread.Sleep(100);
						bool flag3 = this._barPrograss != null;
						if (flag3)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("no_data"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				bool flag4 = this._barPrograss != null;
				if (flag4)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00038358 File Offset: 0x00036558
		private void btnCloseSiteDetail_Click(object sender, EventArgs e)
		{
			this.pnDetailSite.Visible = false;
			this.splitContainer4.SplitterDistance = 0;
			this.pnDetailSiteChart.Controls.Clear();
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00038388 File Offset: 0x00036588
		private void setDetailSiteChart(int siteno)
		{
			Chart chart = new Chart();
			chart.Dock = DockStyle.Fill;
			chart.Visible = true;
			this.pnDetailSiteChart.Visible = true;
			this.pnDetailSite.Visible = true;
			chart.Parent = this.pnDetailSiteChart;
			chart.Titles.Add(this.tbLocation.Text.Trim() + "\r\n Site " + siteno.ToString() + " Detail Factor");
			chart.Titles[0].Font = new Font("맑은 고딕", 15f, FontStyle.Bold);
			chart.Titles[0].Alignment = System.Drawing.ContentAlignment.TopCenter;
			chart.ChartAreas.Add(string.Empty);
			chart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
			chart.ChartAreas[0].AlignWithChartArea = "NotSet";
			chart.ChartAreas[0].AxisX.Interval = 1.0;
			chart.ChartAreas[0].AxisY.Interval = 1.0;
			chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			chart.Legends.Clear();
			chart.Series.Clear();
			chart.Legends.Add(string.Empty);
			chart.Legends[0].Font = new Font(chart.Legends[0].Font.FontFamily, chart.Legends[0].Font.Size, FontStyle.Bold);
			chart.Legends[0].Docking = Docking.Bottom;
			chart.Legends[0].Alignment = StringAlignment.Center;
			string empty = string.Empty;
			string empty2 = string.Empty;
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (KeyValuePair<string, string> keyValuePair in this._SiteBuffer)
			{
				string[] array = keyValuePair.Value.Split(new char[]
				{
					'|'
				});
				foreach (string text in array)
				{
					string[] array3 = text.Split(new char[]
					{
						'@'
					});
					bool flag = siteno.ToString() == array3[0].Trim();
					if (flag)
					{
						string value = array3[1];
						string text2 = array3[2];
						bool flag2 = Convert.ToInt32(value) != 1 && Convert.ToInt32(value) != 3;
						if (flag2)
						{
							string[] array4 = text2.Split(new char[]
							{
								','
							});
							bool flag3 = array4.Length == 1 || array4.Length == 0;
							if (flag3)
							{
								bool flag4 = !dictionary.ContainsKey(text2);
								if (flag4)
								{
									dictionary.Add(text2, 1);
								}
								else
								{
									Dictionary<string, int> dictionary2 = dictionary;
									string key = text2;
									int num = dictionary2[key];
									dictionary2[key] = num + 1;
								}
							}
							else
							{
								foreach (string text3 in array4)
								{
									bool flag5 = !string.IsNullOrEmpty(text3.Trim());
									if (flag5)
									{
										bool flag6 = !dictionary.ContainsKey(text3);
										if (flag6)
										{
											dictionary.Add(text3, 1);
										}
										else
										{
											Dictionary<string, int> dictionary3 = dictionary;
											string key = text3;
											int num = dictionary3[key];
											dictionary3[key] = num + 1;
										}
									}
								}
							}
						}
					}
				}
			}
			chart.Series.Add(string.Empty);
			chart.Series[chart.Series.Count - 1].ToolTip = "#VALX : #VALY{D}";
			chart.Series[chart.Series.Count - 1].ChartType = SeriesChartType.Pie;
			foreach (KeyValuePair<string, int> keyValuePair2 in dictionary)
			{
				chart.Series[chart.Series.Count - 1].Points.AddXY(keyValuePair2.Key, new object[]
				{
					keyValuePair2.Value
				});
				chart.Series[chart.Series.Count - 1].Points[chart.Series[chart.Series.Count - 1].Points.Count - 1].IsValueShownAsLabel = true;
				chart.Series[chart.Series.Count - 1].Points[chart.Series[chart.Series.Count - 1].Points.Count - 1].LegendText = keyValuePair2.Key;
			}
		}

		// Token: 0x04000226 RID: 550
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x04000227 RID: 551
		private SourceGrid.Cells.Views.Cell cell_HoldReport;

		// Token: 0x04000228 RID: 552
		private SourceGrid.Cells.Views.Cell cell_CloseReport;

		// Token: 0x04000229 RID: 553
		private SourceGrid.Cells.Views.Cell cell_Report;

		// Token: 0x0400022A RID: 554
		private bool bHandlerUtiliMode = false;

		// Token: 0x0400022B RID: 555
		private Dictionary<string, ReportList> list = new Dictionary<string, ReportList>();

		// Token: 0x0400022C RID: 556
		private Chart maintTrendChart;

		// Token: 0x0400022D RID: 557
		private Chart maintCaseChart;

		// Token: 0x0400022E RID: 558
		private Chart maintFactorChart1;

		// Token: 0x0400022F RID: 559
		private Chart maintFactorChart2;

		// Token: 0x04000230 RID: 560
		private Chart maintFactorChart3;

		// Token: 0x04000231 RID: 561
		private Chart maintOEEChart;

		// Token: 0x04000232 RID: 562
		private Chart maintDeviceChart;

		// Token: 0x04000233 RID: 563
		private QueryMgr _queryMgr;

		// Token: 0x04000234 RID: 564
		private BarPrograss _barPrograss;

		// Token: 0x04000235 RID: 565
		private Thread _thread;

		// Token: 0x04000236 RID: 566
		private Dictionary<string, List<TrendForm.OEEData>> OEEList = new Dictionary<string, List<TrendForm.OEEData>>();

		// Token: 0x04000237 RID: 567
		private int defaultWidth = 0;

		// Token: 0x04000238 RID: 568
		private int defaultHeight = 0;

		// Token: 0x04000239 RID: 569
		private Dictionary<string, string> _listFacotr = new Dictionary<string, string>();

		// Token: 0x0400023A RID: 570
		private new CIMitarAccount _cimitarUser;

		// Token: 0x0400023B RID: 571
		private bool allowResize = false;

		// Token: 0x0400023D RID: 573
		private Dictionary<string, string> _SiteBuffer = new Dictionary<string, string>();

		// Token: 0x0200007E RID: 126
		private struct totalstatus
		{
			// Token: 0x040007CA RID: 1994
			public int good;

			// Token: 0x040007CB RID: 1995
			public int reject;

			// Token: 0x040007CC RID: 1996
			public int disable;
		}

		// Token: 0x0200007F RID: 127
		public class DoubleBufferChart : Chart
		{
			// Token: 0x06000649 RID: 1609 RVA: 0x0008E2E5 File Offset: 0x0008C4E5
			public DoubleBufferChart()
			{
				base.SetStyle(ControlStyles.DoubleBuffer, true);
				base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
				base.SetStyle(ControlStyles.UserPaint, true);
				base.UpdateStyles();
			}
		}

		// Token: 0x02000080 RID: 128
		private class OEEData
		{
			// Token: 0x040007CD RID: 1997
			public DateTime requestTime;

			// Token: 0x040007CE RID: 1998
			public DateTime startTime;

			// Token: 0x040007CF RID: 1999
			public DateTime endTime;

			// Token: 0x040007D0 RID: 2000
			public DateTime HoldTime;

			// Token: 0x040007D1 RID: 2001
			public TimeSpan reqeustTostartTime = default(TimeSpan);

			// Token: 0x040007D2 RID: 2002
			public TimeSpan requestToendTime = default(TimeSpan);

			// Token: 0x040007D3 RID: 2003
			public TimeSpan startToendTime = default(TimeSpan);

			// Token: 0x040007D4 RID: 2004
			public double tempTime = 0.0;

			// Token: 0x040007D5 RID: 2005
			public DateTime startTimeMTBF;

			// Token: 0x040007D6 RID: 2006
			public DateTime endTimeMTBF;

			// Token: 0x040007D7 RID: 2007
			public double ACTLMin;

			// Token: 0x040007D8 RID: 2008
			public bool bCount = false;
		}
	}
}
