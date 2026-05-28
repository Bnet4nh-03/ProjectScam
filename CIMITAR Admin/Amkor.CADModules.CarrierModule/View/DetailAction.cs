using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Control;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000043 RID: 67
	public partial class DetailAction : Form
	{
		// Token: 0x060002DC RID: 732 RVA: 0x0004AD04 File Offset: 0x00048F04
		public DetailAction()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0004AD5F File Offset: 0x00048F5F
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0004AD6D File Offset: 0x00048F6D
		// (set) Token: 0x060002DF RID: 735 RVA: 0x0004AD7A File Offset: 0x00048F7A
		public string Caption
		{
			get
			{
				return this.lblTop.Text;
			}
			set
			{
				this.lblTop.Text = value;
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0004AD88 File Offset: 0x00048F88
		private void DetailAction_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.initGrid();
			this.viewGrid();
			this.DrawChart();
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0004ADB0 File Offset: 0x00048FB0
		private void initGrid()
		{
			if (this.sType == "BlacklistTrend" || this.sType == "Action")
			{
				this.gridActionList.ColumnsCount = 3;
				this.gridActionList.RowsCount = 1;
				this.gridActionList.FixedRows = 1;
				this.gridActionList[0, 0] = new GridInfo.ColHeader("No", false);
				this.gridActionList[0, 1] = new GridInfo.ColHeader("Action", false);
				this.gridActionList[0, 2] = new GridInfo.ColHeader("Quantity of Blacklist", false);
			}
			else if (this.sType == "TopFailCount")
			{
				this.gridActionList.ColumnsCount = 7;
				this.gridActionList.RowsCount = 1;
				this.gridActionList.FixedRows = 1;
				this.gridActionList[0, 0] = new GridInfo.ColHeader("No", false);
				this.gridActionList[0, 1] = new GridInfo.ColHeader("Carrier", false);
				this.gridActionList[0, 2] = new GridInfo.ColHeader("Site", false);
				this.gridActionList[0, 3] = new GridInfo.ColHeader("Fail\nCount", false);
				this.gridActionList[0, 4] = new GridInfo.ColHeader("Total\nTestCount", false);
				this.gridActionList[0, 5] = new GridInfo.ColHeader("BlackList\nCount", false);
				this.gridActionList[0, 6] = new GridInfo.ColHeader("Fail\nLoss(%)", false);
			}
			this.gridInfo.SetColumnCellColor(this.gridActionList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridActionList);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0004AF68 File Offset: 0x00049168
		private ArrayList orderByFailList(SortedList slList, int iCount = 0)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in slList)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				dictionaryEntry.Key.ToString();
				CCarrierFailModeData value = (CCarrierFailModeData)dictionaryEntry.Value;
				arrayList.Add(value);
			}
			arrayList.Sort(new DetailAction.sorting());
			if (iCount > 0 && arrayList.Count > iCount)
			{
				ArrayList arrayList2 = new ArrayList();
				for (int i = 0; i < iCount; i++)
				{
					arrayList2.Add(arrayList[i]);
				}
				arrayList = arrayList2;
			}
			return arrayList;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0004B024 File Offset: 0x00049224
		private void viewGrid()
		{
			int num = 1;
			string text = string.Empty;
			string text2 = string.Empty;
			this.gridActionList.RowsCount = 1;
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this._barPrograss.setMax(this.arrDataList.Count);
				if (this.sType == "TopFailCount")
				{
					new ArrayList();
					foreach (object obj in this.arrDataList)
					{
						CCarrierFailModeData ccarrierFailModeData = (CCarrierFailModeData)obj;
						this._barPrograss.setValue(num++);
						if (ccarrierFailModeData.Name.Contains(":"))
						{
							text = ccarrierFailModeData.Name.Split(new char[]
							{
								':'
							})[0].Trim();
							text2 = ccarrierFailModeData.Name.Split(new char[]
							{
								':'
							})[1].Trim();
						}
						string sQuery = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierBinCount] @startdate  = '",
							this.sStartDate,
							"', @enddate  = '",
							this.sEndDate,
							"', @carriername  = '",
							text,
							"', @site  = '",
							text2,
							"'"
						});
						DataSet dataSet = this.queryMgr.queryCall(sQuery);
						if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
						{
							ccarrierFailModeData.TotalBinCount = int.Parse(dataSet.Tables[0].Rows[0]["TotalBinCount"].ToString());
							ccarrierFailModeData.BlackListCount = int.Parse(dataSet.Tables[0].Rows[0]["BlackListCount"].ToString());
							if (ccarrierFailModeData.TotalBinCount > 0)
							{
								double failLoss = Math.Round(Convert.ToDouble(ccarrierFailModeData.Count) / Convert.ToDouble(ccarrierFailModeData.TotalBinCount) * 100.0, 2);
								ccarrierFailModeData.FailLoss = failLoss;
							}
						}
					}
					this.arrDataList.Sort(new DetailAction.sorting());
					using (IEnumerator enumerator2 = this.arrDataList.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj2 = enumerator2.Current;
							CCarrierFailModeData ccarrierFailModeData2 = (CCarrierFailModeData)obj2;
							if (ccarrierFailModeData2.Name.Contains(":"))
							{
								text = ccarrierFailModeData2.Name.Split(new char[]
								{
									':'
								})[0].Trim();
								text2 = ccarrierFailModeData2.Name.Split(new char[]
								{
									':'
								})[1].Trim();
							}
							this.gridActionList.Rows.Insert(this.gridActionList.RowsCount);
							this.gridActionList[this.gridActionList.RowsCount - 1, 0] = new Cell((this.gridActionList.RowsCount - 1).ToString());
							this.gridActionList[this.gridActionList.RowsCount - 1, 1] = new Cell(text);
							this.gridActionList[this.gridActionList.RowsCount - 1, 2] = new Cell(text2);
							this.gridActionList[this.gridActionList.RowsCount - 1, 3] = new Cell(ccarrierFailModeData2.Count);
							this.gridActionList[this.gridActionList.RowsCount - 1, 4] = new Cell(ccarrierFailModeData2.TotalBinCount);
							this.gridActionList[this.gridActionList.RowsCount - 1, 5] = new Cell(ccarrierFailModeData2.BlackListCount);
							this.gridActionList[this.gridActionList.RowsCount - 1, 6] = new Cell(ccarrierFailModeData2.FailLoss);
						}
						goto IL_555;
					}
				}
				foreach (object obj3 in this.arrDataList)
				{
					CCarrierFailModeData ccarrierFailModeData3 = (CCarrierFailModeData)obj3;
					this._barPrograss.setValue(num++);
					this.gridActionList.Rows.Insert(this.gridActionList.RowsCount);
					this.gridActionList[this.gridActionList.RowsCount - 1, 0] = new Cell((this.gridActionList.RowsCount - 1).ToString());
					this.gridActionList[this.gridActionList.RowsCount - 1, 1] = new Cell(ccarrierFailModeData3.Name);
					this.gridActionList[this.gridActionList.RowsCount - 1, 2] = new Cell(ccarrierFailModeData3.Count);
				}
				IL_555:
				this.gridInfo.AutoSetGrid(this.gridActionList);
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
				ex.ToString();
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

		// Token: 0x060002E4 RID: 740 RVA: 0x0004B684 File Offset: 0x00049884
		private void InitChart_CarrierView()
		{
			if (this.chart_CarrierView.Series.Count > 0)
			{
				this.chart_CarrierView.Series.Clear();
			}
			this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Clear();
			this.chart_CarrierView.Update();
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0004B6E0 File Offset: 0x000498E0
		private void CreateSeries_BlackListFailCount(string sType)
		{
			Series series = new Series();
			series.ChartType = SeriesChartType.Column;
			series.ChartArea = "ChartArea1";
			series.Font = new Font("Segoe UI", 8f);
			series.LabelForeColor = Color.Empty;
			series.XValueType = ChartValueType.String;
			series.YValueType = ChartValueType.Int32;
			series.Legend = "Legend1";
			if (sType == "BlacklistTrend" || sType == "Action")
			{
				series.LegendText = "Quantity of Blacklist";
				series.Name = "Quantity of Blacklist";
				this.chart_CarrierView.Series.Add(series);
				this.chart_CarrierView.Titles[0].Text = "Action for " + this.sFailName;
				return;
			}
			if (sType == "TopFailCount")
			{
				series.LegendText = "Carrier : Site";
				series.Name = "Carrier : Site";
				this.chart_CarrierView.Series.Add(series);
				this.chart_CarrierView.Titles[0].Text = "Top 100 Fail Carrier";
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0004B7F8 File Offset: 0x000499F8
		private void DrawChart()
		{
			this.InitChart_CarrierView();
			this.CreateSeries_BlackListFailCount(this.sType);
			int num = 0;
			double num2 = 1.5;
			string toolTip = string.Empty;
			foreach (object obj in this.arrDataList)
			{
				CCarrierFailModeData ccarrierFailModeData = (CCarrierFailModeData)obj;
				string text = ccarrierFailModeData.Name.ToString();
				if (this.sType == "TopFailCount")
				{
					this.chart_CarrierView.Series[0].Points.Add(new double[]
					{
						ccarrierFailModeData.FailLoss
					});
					toolTip = text + "\r\n" + ccarrierFailModeData.FailLoss.ToString();
					this.chart_CarrierView.Series[0].Points[num].ToolTip = toolTip;
					if (ccarrierFailModeData.FailLoss > 0.0)
					{
						this.chart_CarrierView.Series[0].Points[num].Label = ccarrierFailModeData.FailLoss.ToString();
						this.chart_CarrierView.Series[0].Font = new Font("Segoe UI", 9f, FontStyle.Regular);
						this.chart_CarrierView.Series[0].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
					}
				}
				else
				{
					this.chart_CarrierView.Series[0].Points.Add(new double[]
					{
						(double)ccarrierFailModeData.Count
					});
					toolTip = text + "\r\n" + ccarrierFailModeData.Count.ToString();
					this.chart_CarrierView.Series[0].Points[num].ToolTip = toolTip;
					if (ccarrierFailModeData.Count > 0)
					{
						this.chart_CarrierView.Series[0].Points[num].Label = ccarrierFailModeData.Count.ToString();
						this.chart_CarrierView.Series[0].Font = new Font("Segoe UI", 9f, FontStyle.Regular);
						this.chart_CarrierView.Series[0].Points[num].LabelForeColor = Color.FromArgb(0, 0, 0);
					}
				}
				CustomLabel customLabel = new CustomLabel();
				customLabel.Text = text;
				customLabel.FromPosition = 0.5;
				if (num == 0)
				{
					customLabel.ToPosition = num2;
				}
				else
				{
					num2 += 2.0;
					customLabel.ToPosition = num2;
				}
				customLabel.RowIndex = 0;
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8f, FontStyle.Regular);
				this.chart_CarrierView.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
				num++;
			}
			this.chart_CarrierView.ChartAreas[0].Position.Auto = false;
			this.chart_CarrierView.ChartAreas[0].Position.X = 0f;
			this.chart_CarrierView.ChartAreas[0].Position.Y = 10f;
			this.chart_CarrierView.ChartAreas[0].Position.Height = 75f;
			this.chart_CarrierView.ChartAreas[0].Position.Width = 99f;
			this.chart_CarrierView.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLogarithmic = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.Maximum = (double)(this.arrDataList.Count + 1);
			this.chart_CarrierView.ChartAreas[0].AxisX.Minimum = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
			this.chart_CarrierView.ChartAreas[0].AxisX.Interval = 2.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IntervalOffset = 1.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsLabelAutoFit = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 9;
			this.chart_CarrierView.ChartAreas[0].AxisX.IsReversed = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Interval = 0.0;
			this.chart_CarrierView.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
			this.chart_CarrierView.ChartAreas[0].RecalculateAxesScale();
			this.chart_CarrierView.ChartAreas[0].AxisY.Maximum = double.NaN;
			for (int i = 0; i < this.chart_CarrierView.Series.Count; i++)
			{
				this.chart_CarrierView.Series[i]["PointWidth"] = "0.4";
			}
			this.chart_CarrierView.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
			this.chart_CarrierView.ChartAreas[0].AxisX.ScrollBar.BackColor = Color.White;
			this.chart_CarrierView.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.LightGray;
			this.chart_CarrierView.ChartAreas[0].AxisX.ScrollBar.Size = 15.0;
			this.chart_CarrierView.ChartAreas[0].CursorX.AutoScroll = true;
			this.chart_CarrierView.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
			if (this.arrDataList.Count > 50)
			{
				this.chart_CarrierView.ChartAreas[0].AxisX.ScaleView.Size = 15.0;
				this.chart_CarrierView.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
			}
			this.chart_CarrierView.Update();
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0004BF90 File Offset: 0x0004A190
		private void saveExcel(SourceGrid.Grid grid)
		{
			try
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
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						if (this.saveFileDialog.FilterIndex == 1)
						{
							ExcelControl.Save(this.saveFileDialog.FileName, grid, true, null);
						}
						else if (this.saveFileDialog.FilterIndex == 2)
						{
							ExcelControl.SaveCSV(this.saveFileDialog.FileName, grid, this._cimitarUser._exeExcel);
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
				}
				else
				{
					MessageBox.Show("data is not exist ", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
				if (this._barPrograss != null)
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
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0004C154 File Offset: 0x0004A354
		private void cmdExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridActionList);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0004C162 File Offset: 0x0004A362
		private void cmdApply_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			base.Close();
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0004C171 File Offset: 0x0004A371
		private void cmdApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0004C18E File Offset: 0x0004A38E
		private void cmdApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0004C1AB File Offset: 0x0004A3AB
		private void cmdApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0004C1C8 File Offset: 0x0004A3C8
		private void cmdApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0004C1D5 File Offset: 0x0004A3D5
		private void cmdExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0004C1F2 File Offset: 0x0004A3F2
		private void cmdExcel_MouseLeave(object sender, EventArgs e)
		{
			this.cmdExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0004C20F File Offset: 0x0004A40F
		private void cmdExcel_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdExcel.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0004C22C File Offset: 0x0004A42C
		private void cmdExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x040004F6 RID: 1270
		public FactorySettings _factorySetting;

		// Token: 0x040004F7 RID: 1271
		public CIMitarAccount _cimitarUser;

		// Token: 0x040004F8 RID: 1272
		public string sType = string.Empty;

		// Token: 0x040004F9 RID: 1273
		public string sFailName = string.Empty;

		// Token: 0x040004FA RID: 1274
		public string sStartDate = string.Empty;

		// Token: 0x040004FB RID: 1275
		public string sEndDate = string.Empty;

		// Token: 0x040004FC RID: 1276
		public ArrayList arrDataList = new ArrayList();

		// Token: 0x040004FD RID: 1277
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x040004FE RID: 1278
		private Thread _thread;

		// Token: 0x040004FF RID: 1279
		private BarPrograss _barPrograss;

		// Token: 0x04000500 RID: 1280
		private QueryMgr queryMgr;

		// Token: 0x02000044 RID: 68
		private class sorting : IComparer, IComparer<CCarrierFailModeData>
		{
			// Token: 0x060002F4 RID: 756 RVA: 0x0004CDC8 File Offset: 0x0004AFC8
			public int Compare(CCarrierFailModeData one, CCarrierFailModeData two)
			{
				return two.FailLoss.CompareTo(one.FailLoss);
			}

			// Token: 0x060002F5 RID: 757 RVA: 0x0004CDDB File Offset: 0x0004AFDB
			public int Compare(object one, object two)
			{
				return this.Compare((CCarrierFailModeData)one, (CCarrierFailModeData)two);
			}
		}
	}
}
