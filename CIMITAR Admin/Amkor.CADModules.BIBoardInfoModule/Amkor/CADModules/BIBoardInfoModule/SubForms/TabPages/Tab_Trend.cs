using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AlteraSocketView.View;
using Amkor.CADModules.BIBoardInfoModule.Class;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using DATA;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms.TabPages
{
	// Token: 0x0200002B RID: 43
	public class Tab_Trend : Tab_Base
	{
		// Token: 0x06000128 RID: 296 RVA: 0x000191A8 File Offset: 0x000173A8
		public Tab_Trend(string title)
		{
			this.Text = title;
			this.InitializeComponent();
			this._instance = BIBoardInfoModule._instance;
			this._cGetData = new CGetData(this._instance._factorySetting._urlServer);
			this._alProduct = this._cGetData.GetDevice();
			this.Init();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00019208 File Offset: 0x00017408
		private void Init()
		{
			this._cPmSumChartProperties = new List<CPmSumChartProperty>();
			this._cSrsInfos1 = new List<CSrsInfo>();
			this._cSrsInfos2 = new List<CSrsInfo>();
			this._alDailyList_1 = new ArrayList();
			this._alDailyList_2 = new ArrayList();
			this.combo_Product_1.Items.AddRange(this._alProduct.ToArray());
			this.combo_Product_2.Items.AddRange(this._alProduct.ToArray());
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00019284 File Offset: 0x00017484
		protected void InitChartStyle(Chart chart, string chartTitle, double maxY, double minY, double interval = double.NaN)
		{
			string familyName = "Segoe UI";
			try
			{
				chart.Palette = ChartColorPalette.None;
				chart.Titles.Add(new Title(chartTitle, Docking.Top, new Font(familyName, 12f, FontStyle.Bold), Color.Black));
				chart.Legends.Add(new Legend("Legend1"));
				chart.Legends["Legend1"].Docking = Docking.Bottom;
				chart.Legends["Legend1"].Alignment = StringAlignment.Center;
				chart.Legends["Legend1"].LegendItemOrder = LegendItemOrder.ReversedSeriesOrder;
				chart.Legends["Legend1"].Font = new Font(familyName, 8f);
				chart.Legends["Legend1"].Enabled = true;
				chart.ChartAreas["ChartArea1"].AxisX.Interval = 1.0;
				chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
				chart.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font(familyName, 8f, FontStyle.Bold);
				chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font(familyName, 8f);
				chart.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Segoe UI", 10f, FontStyle.Bold);
				chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "{#,##0}";
				chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font(familyName, 8f, FontStyle.Regular);
				chart.ChartAreas["ChartArea1"].AxisY.Enabled = AxisEnabled.True;
				chart.ChartAreas["ChartArea1"].AxisY.Maximum = double.NaN;
				chart.ChartAreas["ChartArea1"].AxisY2.TitleFont = new Font(familyName, 10f, FontStyle.Bold);
				chart.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Format = "{0.000}%";
				chart.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Font = new Font(familyName, 8f, FontStyle.Regular);
				chart.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
				chart.ChartAreas["ChartArea1"].AxisY2.Minimum = minY;
				chart.ChartAreas["ChartArea1"].AxisY2.Maximum = maxY;
				chart.ChartAreas["ChartArea1"].AxisY2.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
				chart.ChartAreas["ChartArea1"].AxisY2.MajorGrid.LineColor = Color.LightGray;
				chart.ChartAreas["ChartArea1"].AxisY2.Interval = interval;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000195E0 File Offset: 0x000177E0
		private void ClearChart(Chart chart)
		{
			chart.Series.Clear();
			chart.ChartAreas.Clear();
			chart.ChartAreas.Add("ChartArea1");
			chart.Legends.Clear();
			chart.Titles.Clear();
			if (chart.Series.Count != 0)
			{
				foreach (Series series in chart.Series)
				{
					series.Points.Clear();
				}
			}
			this.InitChartStyle(chart, "Trend", double.NaN, double.NaN, double.NaN);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000196A0 File Offset: 0x000178A0
		private void GetData(string dateFrom, string dateTo)
		{
			this._cPmSumChartProperties.Clear();
			DataSet dataSet = new DataSet();
			string sQuery = string.Concat(new string[]
			{
				"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_PM_SUM_DAILY', @dateFrom = '",
				dateFrom,
				"', @dateTo = '",
				dateTo,
				"'"
			});
			try
			{
				this._instance._barPrograss = new BarPrograss();
				this._instance._barPrograss.progress_labelheader_set("SCAN..");
				this._instance._barPrograss.setMax(100);
				this._instance._barPrograss.setValue(100);
				this._instance._thread = new Thread(new ThreadStart(this._instance.BarPrograssView));
				this._instance._thread.Start();
				dataSet = this._instance.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					foreach (object obj in dataSet.Tables[0].Rows)
					{
						DataRow dataRow = (DataRow)obj;
						using (IEnumerator enumerator2 = dataSet.Tables[0].Columns.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								DataColumn col = (DataColumn)enumerator2.Current;
								if (!(col.ColumnName == "product") && !(col.ColumnName == "in_date"))
								{
									CPmSumChartProperty cpmSumChartProperty = new CPmSumChartProperty();
									cpmSumChartProperty.strSrsName = col.ColumnName;
									cpmSumChartProperty.strProduct = dataRow["product"].ToString();
									cpmSumChartProperty.dtInTime = DateTime.Parse(dataRow["in_date"].ToString());
									cpmSumChartProperty.dVal = double.Parse(dataRow[col].ToString());
									if (col.ColumnName == "socket_fail_rate")
									{
										cpmSumChartProperty.iAxisNo = 1;
										cpmSumChartProperty.iChartType = 3;
									}
									else
									{
										cpmSumChartProperty.iAxisNo = 0;
										cpmSumChartProperty.iChartType = 11;
									}
									if (!this._cSrsInfos1.Exists((CSrsInfo o) => o.strSrsName == col.ColumnName))
									{
										CSrsInfo csrsInfo = new CSrsInfo();
										csrsInfo.strSrsName = col.ColumnName;
										if (csrsInfo.strSrsName == "bib_total")
										{
											csrsInfo.isVisible = true;
											csrsInfo.iChartType = 3;
										}
										else if (csrsInfo.strSrsName == "bib_fail" || csrsInfo.strSrsName == "bib_good")
										{
											csrsInfo.isVisible = true;
											csrsInfo.iChartType = 11;
										}
										else
										{
											csrsInfo.isVisible = false;
											csrsInfo.iChartType = cpmSumChartProperty.iChartType;
										}
										csrsInfo.iAxisNo = cpmSumChartProperty.iAxisNo;
										this._cSrsInfos1.Add(csrsInfo);
										CSrsInfo csrsInfo2 = new CSrsInfo();
										csrsInfo2.strSrsName = col.ColumnName;
										if (csrsInfo2.strSrsName == "socket_fail" || csrsInfo2.strSrsName == "socket_fail_rate")
										{
											csrsInfo2.isVisible = true;
										}
										else
										{
											csrsInfo2.isVisible = false;
										}
										csrsInfo2.iChartType = cpmSumChartProperty.iChartType;
										csrsInfo2.iAxisNo = cpmSumChartProperty.iAxisNo;
										this._cSrsInfos2.Add(csrsInfo2);
									}
									if (col.ColumnName == "bib_fail")
									{
										cpmSumChartProperty.clrSrsName = Color.CornflowerBlue;
									}
									else if (col.ColumnName == "bib_good")
									{
										cpmSumChartProperty.clrSrsName = Color.PowderBlue;
									}
									else if (col.ColumnName == "bib_total")
									{
										cpmSumChartProperty.clrSrsName = Color.PeachPuff;
									}
									this._cPmSumChartProperties.Add(cpmSumChartProperty);
								}
							}
						}
					}
				}
				Thread.Sleep(100);
				if (this._instance._barPrograss != null)
				{
					this._instance._barPrograss._ischeck = true;
				}
				this._instance._barPrograss = null;
			}
			catch (Exception)
			{
				Thread.Sleep(100);
				if (this._instance._barPrograss != null)
				{
					this._instance._barPrograss._ischeck = true;
				}
				this._instance._barPrograss = null;
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00019B90 File Offset: 0x00017D90
		private void SetChart(Chart chart, ArrayList alDailyList, List<CSrsInfo> cSrsInfos, string product)
		{
			this.ClearChart(chart);
			if ((from o in cSrsInfos
			where o.iAxisNo == 1 && o.isVisible
			select o).ToList<CSrsInfo>().Count == 0)
			{
				chart.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.False;
			}
			else
			{
				chart.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
			}
			if (this._cPmSumChartProperties.Count == 0)
			{
				MessageBox.Show("No Data");
				return;
			}
			int num = 0;
			using (IEnumerator enumerator = alDailyList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DateTime dt = (DateTime)enumerator.Current;
					string text = string.Empty;
					if (dt.ToString("MM.dd").IndexOf("12.31") != -1 || dt.ToString("MM.dd").IndexOf("01.01") != -1)
					{
						text = dt.ToString("yyyy\nMM.dd");
					}
					else
					{
						text = dt.ToString("MM.dd");
					}
					List<CPmSumChartProperty> list = (from o in this._cPmSumChartProperties
					where o.strProduct == product && o.dtInTime.ToString("yyyy.MM.dd") == dt.ToString("yyyy.MM.dd")
					select o).ToList<CPmSumChartProperty>();
					if (list.Count != 0)
					{
						foreach (CSrsInfo csrsInfo in (from o in cSrsInfos
						orderby o.iChartType descending
						select o).ToList<CSrsInfo>())
						{
							foreach (CPmSumChartProperty cpmSumChartProperty in list)
							{
								string srsName = cpmSumChartProperty.strSrsName;
								if (!(csrsInfo.strSrsName != srsName))
								{
									if (chart.Series.IndexOf(srsName) == -1)
									{
										chart.Series.Add(srsName);
										cSrsInfos.SingleOrDefault((CSrsInfo o) => o.strSrsName == srsName);
										chart.Series[srsName].ChartType = (SeriesChartType)csrsInfo.iChartType;
										chart.Series[srsName].YAxisType = (AxisType)cpmSumChartProperty.iAxisNo;
										chart.Series[srsName].Color = cpmSumChartProperty.clrSrsName;
										chart.Series[srsName].Enabled = csrsInfo.isVisible;
										if (csrsInfo.iChartType == 3)
										{
											chart.Series[srsName].MarkerSize = 7;
											chart.Series[srsName].MarkerStyle = MarkerStyle.Circle;
											chart.Series[srsName].BorderWidth = 3;
											chart.Series[srsName].IsValueShownAsLabel = true;
											chart.Series[srsName].LabelForeColor = Color.Black;
											chart.Series[srsName].Font = new Font("Segoe UI", 7f);
										}
										if (cpmSumChartProperty.iAxisNo == 1)
										{
											chart.Series[srsName].LabelFormat = "{0.000}%";
										}
									}
									chart.Series[srsName].Points.Add(new double[]
									{
										cpmSumChartProperty.dVal
									});
									if (cpmSumChartProperty.iAxisNo == 1)
									{
										chart.Series[srsName].Points[num].ToolTip = srsName + ": " + cpmSumChartProperty.dVal.ToString();
									}
									else
									{
										chart.Series[srsName].Points[num].ToolTip = srsName + ": " + cpmSumChartProperty.dVal.ToString("#,##0");
									}
								}
							}
						}
						chart.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add((double)num + 0.5, (double)num + 1.5, text);
						num++;
					}
				}
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0001A0A0 File Offset: 0x000182A0
		private void DrawChart(Chart chart)
		{
			string product = string.Empty;
			DateTime value;
			DateTime value2;
			ArrayList arrayList;
			List<CSrsInfo> cSrsInfos;
			if (chart.Name == "chart1")
			{
				this.checkBox_ShowLabel_1.Checked = false;
				value = this.dtPicker_DateFrom_1.Value;
				value2 = this.dtPicker_DateTo_1.Value;
				arrayList = this._alDailyList_1;
				cSrsInfos = this._cSrsInfos1;
				product = this.combo_Product_1.SelectedItem.ToString();
			}
			else
			{
				this.checkBox_ShowLabel_2.Checked = false;
				value = this.dtPicker_DateFrom_2.Value;
				value2 = this.dtPicker_DateTo_2.Value;
				arrayList = this._alDailyList_2;
				cSrsInfos = this._cSrsInfos2;
				product = this.combo_Product_2.SelectedItem.ToString();
			}
			TimeSpan timeSpan = value2 - value;
			string dateFrom = value.ToString("yyyy-MM-dd");
			string dateTo = value2.ToString("yyyy-MM-dd");
			arrayList.Clear();
			for (int i = -timeSpan.Days; i <= 0; i++)
			{
				arrayList.Add(DateTime.Now.AddDays((double)i));
			}
			this.GetData(dateFrom, dateTo);
			this.SetChart(chart, arrayList, cSrsInfos, product);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0001A1C8 File Offset: 0x000183C8
		private void btn_OneWeek_1_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_1.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.dtPicker_DateFrom_1.Value = DateTime.Now.AddDays(-6.0);
			this.dtPicker_DateTo_1.Value = DateTime.Now;
			this.DrawChart(this.chart1);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0001A22C File Offset: 0x0001842C
		private void btn_TwoWeek_1_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_1.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.dtPicker_DateFrom_1.Value = DateTime.Now.AddDays(-13.0);
			this.dtPicker_DateTo_1.Value = DateTime.Now;
			this.DrawChart(this.chart1);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0001A290 File Offset: 0x00018490
		private void btn_OneMonth_1_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_1.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.dtPicker_DateFrom_1.Value = DateTime.Now.AddDays(-30.0);
			this.dtPicker_DateTo_1.Value = DateTime.Now;
			this.DrawChart(this.chart1);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0001A2F4 File Offset: 0x000184F4
		private void btn_ThreeMonth_1_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_1.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.dtPicker_DateFrom_1.Value = DateTime.Now.AddDays(-91.0);
			this.dtPicker_DateTo_1.Value = DateTime.Now;
			this.DrawChart(this.chart1);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0001A358 File Offset: 0x00018558
		private void dtPicker_DateFrom_1_ValueChanged(object sender, EventArgs e)
		{
			if ((this.dtPicker_DateTo_1.Value - this.dtPicker_DateFrom_1.Value).TotalMinutes < 0.0)
			{
				this.dtPicker_DateFrom_1.Value = DateTime.Now;
				return;
			}
			this.dtPicker_DateFrom_1.Value.ToString("yyyy-MM-dd");
			this.dtPicker_DateTo_1.Value.ToString("yyyy-MM-dd");
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0001A3D8 File Offset: 0x000185D8
		private void dtPicker_DateTo_1_ValueChanged(object sender, EventArgs e)
		{
			if ((this.dtPicker_DateTo_1.Value - this.dtPicker_DateFrom_1.Value).TotalMinutes < 0.0)
			{
				this.dtPicker_DateFrom_1.Value = DateTime.Now;
				return;
			}
			this.dtPicker_DateFrom_1.Value.ToString("yyyy-MM-dd");
			this.dtPicker_DateTo_1.Value.ToString("yyyy-MM-dd");
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0001A456 File Offset: 0x00018656
		private void btn_Search_1_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_1.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.DrawChart(this.chart1);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0001A47D File Offset: 0x0001867D
		private void pb_CheckSrsEnabled_1_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_CheckSrsEnabled_1.Image = Resources.VOS;
			this.pb_CheckSrsEnabled_1.Cursor = Cursors.Default;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0001A49F File Offset: 0x0001869F
		private void pb_CheckSrsEnabled_1_MouseMove(object sender, MouseEventArgs e)
		{
			this.pb_CheckSrsEnabled_1.Image = Resources.VOS_Down;
			this.pb_CheckSrsEnabled_1.Cursor = Cursors.Hand;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0001A47D File Offset: 0x0001867D
		private void pb_CheckSrsEnabled_1_MouseLeave(object sender, EventArgs e)
		{
			this.pb_CheckSrsEnabled_1.Image = Resources.VOS;
			this.pb_CheckSrsEnabled_1.Cursor = Cursors.Default;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0001A4C4 File Offset: 0x000186C4
		private void pb_CheckSrsEnabled_1_MouseUp(object sender, MouseEventArgs e)
		{
			if (this._cSrsInfos1.Count == 0)
			{
				MessageBox.Show("Nothing to change");
				return;
			}
			if (this.combo_Product_1.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			string product = this.combo_Product_1.SelectedItem.ToString();
			CheckSeriesEnable checkSeriesEnable = new CheckSeriesEnable(this._cSrsInfos1);
			checkSeriesEnable.ShowDialog();
			if (checkSeriesEnable.DialogResult == DialogResult.OK)
			{
				this.SetChart(this.chart1, this._alDailyList_1, this._cSrsInfos1, product);
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0001A548 File Offset: 0x00018748
		private void checkBox_ShowLabel_1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox_ShowLabel_1.Checked)
			{
				using (IEnumerator<Series> enumerator = this.chart1.Series.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Series series = enumerator.Current;
						series.IsValueShownAsLabel = true;
					}
					return;
				}
			}
			foreach (Series series2 in this.chart1.Series)
			{
				series2.IsValueShownAsLabel = false;
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0001A5E4 File Offset: 0x000187E4
		private void btn_OneWeek_2_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_2.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.dtPicker_DateFrom_2.Value = DateTime.Now.AddDays(-6.0);
			this.dtPicker_DateTo_2.Value = DateTime.Now;
			this.DrawChart(this.chart2);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0001A648 File Offset: 0x00018848
		private void btn_TwoWeek_2_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_2.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.dtPicker_DateFrom_2.Value = DateTime.Now.AddDays(-13.0);
			this.dtPicker_DateTo_2.Value = DateTime.Now;
			this.DrawChart(this.chart2);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0001A6AC File Offset: 0x000188AC
		private void btn_OneMonth_2_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_2.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.dtPicker_DateFrom_2.Value = DateTime.Now.AddDays(-30.0);
			this.dtPicker_DateTo_2.Value = DateTime.Now;
			this.DrawChart(this.chart2);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0001A710 File Offset: 0x00018910
		private void btn_ThreeMonth_2_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_2.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.dtPicker_DateFrom_2.Value = DateTime.Now.AddDays(-91.0);
			this.dtPicker_DateTo_2.Value = DateTime.Now;
			this.DrawChart(this.chart2);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0001A774 File Offset: 0x00018974
		private void dtPicker_DateFrom_2_ValueChanged(object sender, EventArgs e)
		{
			if ((this.dtPicker_DateTo_2.Value - this.dtPicker_DateFrom_2.Value).TotalMinutes < 0.0)
			{
				this.dtPicker_DateFrom_2.Value = DateTime.Now;
				return;
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0001A7C0 File Offset: 0x000189C0
		private void dtPicker_DateTo_2_ValueChanged(object sender, EventArgs e)
		{
			if ((this.dtPicker_DateTo_2.Value - this.dtPicker_DateFrom_2.Value).TotalMinutes < 0.0)
			{
				this.dtPicker_DateFrom_2.Value = DateTime.Now;
				return;
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0001A80C File Offset: 0x00018A0C
		private void btn_Search_2_Click(object sender, EventArgs e)
		{
			if (this.combo_Product_2.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			this.DrawChart(this.chart2);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0001A833 File Offset: 0x00018A33
		private void pb_CheckSrsEnabled_2_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_CheckSrsEnabled_2.Image = Resources.VOS;
			this.pb_CheckSrsEnabled_2.Cursor = Cursors.Default;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0001A855 File Offset: 0x00018A55
		private void pb_CheckSrsEnabled_2_MouseMove(object sender, MouseEventArgs e)
		{
			this.pb_CheckSrsEnabled_2.Image = Resources.VOS_Down;
			this.pb_CheckSrsEnabled_2.Cursor = Cursors.Hand;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0001A833 File Offset: 0x00018A33
		private void pb_CheckSrsEnabled_2_MouseLeave(object sender, EventArgs e)
		{
			this.pb_CheckSrsEnabled_2.Image = Resources.VOS;
			this.pb_CheckSrsEnabled_2.Cursor = Cursors.Default;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0001A878 File Offset: 0x00018A78
		private void pb_CheckSrsEnabled_2_MouseUp(object sender, MouseEventArgs e)
		{
			if (this._cSrsInfos2.Count == 0)
			{
				MessageBox.Show("Nothing to change");
				return;
			}
			if (this.combo_Product_2.SelectedItem == null)
			{
				MessageBox.Show("Select Product");
				return;
			}
			string product = this.combo_Product_2.SelectedItem.ToString();
			CheckSeriesEnable checkSeriesEnable = new CheckSeriesEnable(this._cSrsInfos2);
			checkSeriesEnable.ShowDialog();
			if (checkSeriesEnable.DialogResult == DialogResult.OK)
			{
				this.SetChart(this.chart2, this._alDailyList_2, this._cSrsInfos2, product);
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0001A8FC File Offset: 0x00018AFC
		private void checkBox_ShowLabel_2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox_ShowLabel_2.Checked)
			{
				using (IEnumerator<Series> enumerator = this.chart2.Series.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Series series = enumerator.Current;
						series.IsValueShownAsLabel = true;
					}
					return;
				}
			}
			foreach (Series series2 in this.chart2.Series)
			{
				series2.IsValueShownAsLabel = false;
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0001A998 File Offset: 0x00018B98
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0001A9B8 File Offset: 0x00018BB8
		private void InitializeComponent()
		{
			ChartArea chartArea = new ChartArea();
			Legend legend = new Legend();
			Series series = new Series();
			ChartArea chartArea2 = new ChartArea();
			Legend legend2 = new Legend();
			Series series2 = new Series();
			this.groupBox1 = new GroupBox();
			this.checkBox_ShowLabel_1 = new CheckBox();
			this.btn_ThreeMonth_1 = new Button();
			this.btn_Search_1 = new Button();
			this.btn_TwoWeek_1 = new Button();
			this.pb_CheckSrsEnabled_1 = new PictureBox();
			this.btn_OneWeek_1 = new Button();
			this.label2 = new Label();
			this.dtPicker_DateTo_1 = new DateTimePicker();
			this.dtPicker_DateFrom_1 = new DateTimePicker();
			this.btn_OneMonth_1 = new Button();
			this.chart1 = new Chart();
			this.combo_Product_1 = new ComboBox();
			this.label9 = new Label();
			this.groupBox2 = new GroupBox();
			this.checkBox_ShowLabel_2 = new CheckBox();
			this.btn_ThreeMonth_2 = new Button();
			this.btn_Search_2 = new Button();
			this.btn_TwoWeek_2 = new Button();
			this.pb_CheckSrsEnabled_2 = new PictureBox();
			this.btn_OneWeek_2 = new Button();
			this.label1 = new Label();
			this.dtPicker_DateTo_2 = new DateTimePicker();
			this.dtPicker_DateFrom_2 = new DateTimePicker();
			this.btn_OneMonth_2 = new Button();
			this.chart2 = new Chart();
			this.combo_Product_2 = new ComboBox();
			this.label3 = new Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.pb_CheckSrsEnabled_1).BeginInit();
			((ISupportInitialize)this.chart1).BeginInit();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.pb_CheckSrsEnabled_2).BeginInit();
			((ISupportInitialize)this.chart2).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.checkBox_ShowLabel_1);
			this.groupBox1.Controls.Add(this.btn_ThreeMonth_1);
			this.groupBox1.Controls.Add(this.btn_Search_1);
			this.groupBox1.Controls.Add(this.btn_TwoWeek_1);
			this.groupBox1.Controls.Add(this.pb_CheckSrsEnabled_1);
			this.groupBox1.Controls.Add(this.btn_OneWeek_1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.dtPicker_DateTo_1);
			this.groupBox1.Controls.Add(this.dtPicker_DateFrom_1);
			this.groupBox1.Controls.Add(this.btn_OneMonth_1);
			this.groupBox1.Controls.Add(this.chart1);
			this.groupBox1.Controls.Add(this.combo_Product_1);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Location = new Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1116, 307);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Chart_1";
			this.checkBox_ShowLabel_1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.checkBox_ShowLabel_1.AutoSize = true;
			this.checkBox_ShowLabel_1.Location = new Point(978, 24);
			this.checkBox_ShowLabel_1.Name = "checkBox_ShowLabel_1";
			this.checkBox_ShowLabel_1.Size = new Size(83, 19);
			this.checkBox_ShowLabel_1.TabIndex = 48;
			this.checkBox_ShowLabel_1.Text = "ShowLabel";
			this.checkBox_ShowLabel_1.UseVisualStyleBackColor = true;
			this.checkBox_ShowLabel_1.CheckedChanged += this.checkBox_ShowLabel_1_CheckedChanged;
			this.btn_ThreeMonth_1.FlatStyle = FlatStyle.Flat;
			this.btn_ThreeMonth_1.Location = new Point(507, 22);
			this.btn_ThreeMonth_1.Margin = new Padding(3, 5, 3, 5);
			this.btn_ThreeMonth_1.Name = "btn_ThreeMonth_1";
			this.btn_ThreeMonth_1.Size = new Size(75, 23);
			this.btn_ThreeMonth_1.TabIndex = 47;
			this.btn_ThreeMonth_1.Text = "3 Month";
			this.btn_ThreeMonth_1.UseVisualStyleBackColor = true;
			this.btn_ThreeMonth_1.Click += this.btn_ThreeMonth_1_Click;
			this.btn_Search_1.FlatStyle = FlatStyle.Flat;
			this.btn_Search_1.Location = new Point(817, 22);
			this.btn_Search_1.Margin = new Padding(3, 5, 3, 5);
			this.btn_Search_1.Name = "btn_Search_1";
			this.btn_Search_1.Size = new Size(75, 23);
			this.btn_Search_1.TabIndex = 46;
			this.btn_Search_1.Text = "Search";
			this.btn_Search_1.UseVisualStyleBackColor = true;
			this.btn_Search_1.Click += this.btn_Search_1_Click;
			this.btn_TwoWeek_1.FlatStyle = FlatStyle.Flat;
			this.btn_TwoWeek_1.Location = new Point(345, 22);
			this.btn_TwoWeek_1.Margin = new Padding(3, 5, 3, 5);
			this.btn_TwoWeek_1.Name = "btn_TwoWeek_1";
			this.btn_TwoWeek_1.Size = new Size(75, 23);
			this.btn_TwoWeek_1.TabIndex = 45;
			this.btn_TwoWeek_1.Text = "2 Week";
			this.btn_TwoWeek_1.UseVisualStyleBackColor = true;
			this.btn_TwoWeek_1.Click += this.btn_TwoWeek_1_Click;
			this.pb_CheckSrsEnabled_1.Cursor = Cursors.Hand;
			this.pb_CheckSrsEnabled_1.Image = Resources.VOS;
			this.pb_CheckSrsEnabled_1.InitialImage = Resources.VOS;
			this.pb_CheckSrsEnabled_1.Location = new Point(1078, 14);
			this.pb_CheckSrsEnabled_1.Name = "pb_CheckSrsEnabled_1";
			this.pb_CheckSrsEnabled_1.Size = new Size(32, 33);
			this.pb_CheckSrsEnabled_1.TabIndex = 44;
			this.pb_CheckSrsEnabled_1.TabStop = false;
			this.pb_CheckSrsEnabled_1.MouseDown += this.pb_CheckSrsEnabled_1_MouseDown;
			this.pb_CheckSrsEnabled_1.MouseLeave += this.pb_CheckSrsEnabled_1_MouseLeave;
			this.pb_CheckSrsEnabled_1.MouseMove += this.pb_CheckSrsEnabled_1_MouseMove;
			this.pb_CheckSrsEnabled_1.MouseUp += this.pb_CheckSrsEnabled_1_MouseUp;
			this.btn_OneWeek_1.FlatStyle = FlatStyle.Flat;
			this.btn_OneWeek_1.Location = new Point(264, 22);
			this.btn_OneWeek_1.Margin = new Padding(3, 5, 3, 5);
			this.btn_OneWeek_1.Name = "btn_OneWeek_1";
			this.btn_OneWeek_1.Size = new Size(75, 23);
			this.btn_OneWeek_1.TabIndex = 43;
			this.btn_OneWeek_1.Text = "1 Week";
			this.btn_OneWeek_1.UseVisualStyleBackColor = true;
			this.btn_OneWeek_1.Click += this.btn_OneWeek_1_Click;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(692, 26);
			this.label2.Name = "label2";
			this.label2.Size = new Size(15, 15);
			this.label2.TabIndex = 42;
			this.label2.Text = "~";
			this.dtPicker_DateTo_1.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_DateTo_1.Format = DateTimePickerFormat.Custom;
			this.dtPicker_DateTo_1.Location = new Point(713, 22);
			this.dtPicker_DateTo_1.Name = "dtPicker_DateTo_1";
			this.dtPicker_DateTo_1.Size = new Size(98, 23);
			this.dtPicker_DateTo_1.TabIndex = 41;
			this.dtPicker_DateTo_1.ValueChanged += this.dtPicker_DateTo_1_ValueChanged;
			this.dtPicker_DateFrom_1.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_DateFrom_1.Format = DateTimePickerFormat.Custom;
			this.dtPicker_DateFrom_1.Location = new Point(588, 22);
			this.dtPicker_DateFrom_1.Name = "dtPicker_DateFrom_1";
			this.dtPicker_DateFrom_1.Size = new Size(98, 23);
			this.dtPicker_DateFrom_1.TabIndex = 40;
			this.dtPicker_DateFrom_1.ValueChanged += this.dtPicker_DateFrom_1_ValueChanged;
			this.btn_OneMonth_1.FlatStyle = FlatStyle.Flat;
			this.btn_OneMonth_1.Location = new Point(426, 22);
			this.btn_OneMonth_1.Margin = new Padding(3, 5, 3, 5);
			this.btn_OneMonth_1.Name = "btn_OneMonth_1";
			this.btn_OneMonth_1.Size = new Size(75, 23);
			this.btn_OneMonth_1.TabIndex = 39;
			this.btn_OneMonth_1.Text = "1 Month";
			this.btn_OneMonth_1.UseVisualStyleBackColor = true;
			this.btn_OneMonth_1.Click += this.btn_OneMonth_1_Click;
			this.chart1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			chartArea.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea);
			legend.Name = "Legend1";
			this.chart1.Legends.Add(legend);
			this.chart1.Location = new Point(6, 53);
			this.chart1.Name = "chart1";
			series.ChartArea = "ChartArea1";
			series.Legend = "Legend1";
			series.Name = "Series1";
			this.chart1.Series.Add(series);
			this.chart1.Size = new Size(1104, 248);
			this.chart1.TabIndex = 38;
			this.chart1.Text = "chart1";
			this.combo_Product_1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.combo_Product_1.FormattingEnabled = true;
			this.combo_Product_1.Location = new Point(82, 22);
			this.combo_Product_1.Name = "combo_Product_1";
			this.combo_Product_1.Size = new Size(176, 23);
			this.combo_Product_1.TabIndex = 37;
			this.label9.AutoSize = true;
			this.label9.Location = new Point(12, 25);
			this.label9.Name = "label9";
			this.label9.Size = new Size(58, 15);
			this.label9.TabIndex = 36;
			this.label9.Text = "Product : ";
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.checkBox_ShowLabel_2);
			this.groupBox2.Controls.Add(this.btn_ThreeMonth_2);
			this.groupBox2.Controls.Add(this.btn_Search_2);
			this.groupBox2.Controls.Add(this.btn_TwoWeek_2);
			this.groupBox2.Controls.Add(this.pb_CheckSrsEnabled_2);
			this.groupBox2.Controls.Add(this.btn_OneWeek_2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.dtPicker_DateTo_2);
			this.groupBox2.Controls.Add(this.dtPicker_DateFrom_2);
			this.groupBox2.Controls.Add(this.btn_OneMonth_2);
			this.groupBox2.Controls.Add(this.chart2);
			this.groupBox2.Controls.Add(this.combo_Product_2);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new Point(6, 319);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(1116, 307);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Chart_2";
			this.checkBox_ShowLabel_2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.checkBox_ShowLabel_2.AutoSize = true;
			this.checkBox_ShowLabel_2.Location = new Point(978, 24);
			this.checkBox_ShowLabel_2.Name = "checkBox_ShowLabel_2";
			this.checkBox_ShowLabel_2.Size = new Size(83, 19);
			this.checkBox_ShowLabel_2.TabIndex = 48;
			this.checkBox_ShowLabel_2.Text = "ShowLabel";
			this.checkBox_ShowLabel_2.UseVisualStyleBackColor = true;
			this.checkBox_ShowLabel_2.CheckedChanged += this.checkBox_ShowLabel_2_CheckedChanged;
			this.btn_ThreeMonth_2.FlatStyle = FlatStyle.Flat;
			this.btn_ThreeMonth_2.Location = new Point(507, 22);
			this.btn_ThreeMonth_2.Margin = new Padding(3, 5, 3, 5);
			this.btn_ThreeMonth_2.Name = "btn_ThreeMonth_2";
			this.btn_ThreeMonth_2.Size = new Size(75, 23);
			this.btn_ThreeMonth_2.TabIndex = 47;
			this.btn_ThreeMonth_2.Text = "3 Month";
			this.btn_ThreeMonth_2.UseVisualStyleBackColor = true;
			this.btn_ThreeMonth_2.Click += this.btn_ThreeMonth_2_Click;
			this.btn_Search_2.FlatStyle = FlatStyle.Flat;
			this.btn_Search_2.Location = new Point(817, 22);
			this.btn_Search_2.Margin = new Padding(3, 5, 3, 5);
			this.btn_Search_2.Name = "btn_Search_2";
			this.btn_Search_2.Size = new Size(75, 23);
			this.btn_Search_2.TabIndex = 46;
			this.btn_Search_2.Text = "Search";
			this.btn_Search_2.UseVisualStyleBackColor = true;
			this.btn_Search_2.Click += this.btn_Search_2_Click;
			this.btn_TwoWeek_2.FlatStyle = FlatStyle.Flat;
			this.btn_TwoWeek_2.Location = new Point(345, 22);
			this.btn_TwoWeek_2.Margin = new Padding(3, 5, 3, 5);
			this.btn_TwoWeek_2.Name = "btn_TwoWeek_2";
			this.btn_TwoWeek_2.Size = new Size(75, 23);
			this.btn_TwoWeek_2.TabIndex = 45;
			this.btn_TwoWeek_2.Text = "2 Week";
			this.btn_TwoWeek_2.UseVisualStyleBackColor = true;
			this.btn_TwoWeek_2.Click += this.btn_TwoWeek_2_Click;
			this.pb_CheckSrsEnabled_2.Cursor = Cursors.Hand;
			this.pb_CheckSrsEnabled_2.Image = Resources.VOS;
			this.pb_CheckSrsEnabled_2.InitialImage = Resources.VOS;
			this.pb_CheckSrsEnabled_2.Location = new Point(1078, 14);
			this.pb_CheckSrsEnabled_2.Name = "pb_CheckSrsEnabled_2";
			this.pb_CheckSrsEnabled_2.Size = new Size(32, 33);
			this.pb_CheckSrsEnabled_2.TabIndex = 44;
			this.pb_CheckSrsEnabled_2.TabStop = false;
			this.pb_CheckSrsEnabled_2.MouseDown += this.pb_CheckSrsEnabled_2_MouseDown;
			this.pb_CheckSrsEnabled_2.MouseLeave += this.pb_CheckSrsEnabled_2_MouseLeave;
			this.pb_CheckSrsEnabled_2.MouseMove += this.pb_CheckSrsEnabled_2_MouseMove;
			this.pb_CheckSrsEnabled_2.MouseUp += this.pb_CheckSrsEnabled_2_MouseUp;
			this.btn_OneWeek_2.FlatStyle = FlatStyle.Flat;
			this.btn_OneWeek_2.Location = new Point(264, 22);
			this.btn_OneWeek_2.Margin = new Padding(3, 5, 3, 5);
			this.btn_OneWeek_2.Name = "btn_OneWeek_2";
			this.btn_OneWeek_2.Size = new Size(75, 23);
			this.btn_OneWeek_2.TabIndex = 43;
			this.btn_OneWeek_2.Text = "1 Week";
			this.btn_OneWeek_2.UseVisualStyleBackColor = true;
			this.btn_OneWeek_2.Click += this.btn_OneWeek_2_Click;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(692, 26);
			this.label1.Name = "label1";
			this.label1.Size = new Size(15, 15);
			this.label1.TabIndex = 42;
			this.label1.Text = "~";
			this.dtPicker_DateTo_2.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_DateTo_2.Format = DateTimePickerFormat.Custom;
			this.dtPicker_DateTo_2.Location = new Point(713, 22);
			this.dtPicker_DateTo_2.Name = "dtPicker_DateTo_2";
			this.dtPicker_DateTo_2.Size = new Size(98, 23);
			this.dtPicker_DateTo_2.TabIndex = 41;
			this.dtPicker_DateTo_2.ValueChanged += this.dtPicker_DateTo_2_ValueChanged;
			this.dtPicker_DateFrom_2.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_DateFrom_2.Format = DateTimePickerFormat.Custom;
			this.dtPicker_DateFrom_2.Location = new Point(588, 22);
			this.dtPicker_DateFrom_2.Name = "dtPicker_DateFrom_2";
			this.dtPicker_DateFrom_2.Size = new Size(98, 23);
			this.dtPicker_DateFrom_2.TabIndex = 40;
			this.dtPicker_DateFrom_2.ValueChanged += this.dtPicker_DateFrom_2_ValueChanged;
			this.btn_OneMonth_2.FlatStyle = FlatStyle.Flat;
			this.btn_OneMonth_2.Location = new Point(426, 22);
			this.btn_OneMonth_2.Margin = new Padding(3, 5, 3, 5);
			this.btn_OneMonth_2.Name = "btn_OneMonth_2";
			this.btn_OneMonth_2.Size = new Size(75, 23);
			this.btn_OneMonth_2.TabIndex = 39;
			this.btn_OneMonth_2.Text = "1 Month";
			this.btn_OneMonth_2.UseVisualStyleBackColor = true;
			this.btn_OneMonth_2.Click += this.btn_OneMonth_2_Click;
			this.chart2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			chartArea2.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend1";
			this.chart2.Legends.Add(legend2);
			this.chart2.Location = new Point(6, 53);
			this.chart2.Name = "chart2";
			series2.ChartArea = "ChartArea1";
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			this.chart2.Series.Add(series2);
			this.chart2.Size = new Size(1104, 248);
			this.chart2.TabIndex = 38;
			this.chart2.Text = "chart2";
			this.combo_Product_2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.combo_Product_2.FormattingEnabled = true;
			this.combo_Product_2.Location = new Point(82, 22);
			this.combo_Product_2.Name = "combo_Product_2";
			this.combo_Product_2.Size = new Size(176, 23);
			this.combo_Product_2.TabIndex = 37;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(12, 25);
			this.label3.Name = "label3";
			this.label3.Size = new Size(58, 15);
			this.label3.TabIndex = 36;
			this.label3.Text = "Product : ";
			base.Name = "Tab_Trend";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.pb_CheckSrsEnabled_1).EndInit();
			((ISupportInitialize)this.chart1).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.pb_CheckSrsEnabled_2).EndInit();
			((ISupportInitialize)this.chart2).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040001F8 RID: 504
		private BIBoardInfoModule _instance;

		// Token: 0x040001F9 RID: 505
		private CGetData _cGetData;

		// Token: 0x040001FA RID: 506
		private ArrayList _alProduct;

		// Token: 0x040001FB RID: 507
		private List<CPmSumChartProperty> _cPmSumChartProperties;

		// Token: 0x040001FC RID: 508
		private List<CSrsInfo> _cSrsInfos1;

		// Token: 0x040001FD RID: 509
		private List<CSrsInfo> _cSrsInfos2;

		// Token: 0x040001FE RID: 510
		private ArrayList _alDailyList_1;

		// Token: 0x040001FF RID: 511
		private ArrayList _alDailyList_2;

		// Token: 0x04000200 RID: 512
		private IContainer components;

		// Token: 0x04000201 RID: 513
		private GroupBox groupBox1;

		// Token: 0x04000202 RID: 514
		private Chart chart1;

		// Token: 0x04000203 RID: 515
		private ComboBox combo_Product_1;

		// Token: 0x04000204 RID: 516
		private Label label9;

		// Token: 0x04000205 RID: 517
		private Label label2;

		// Token: 0x04000206 RID: 518
		private DateTimePicker dtPicker_DateTo_1;

		// Token: 0x04000207 RID: 519
		private DateTimePicker dtPicker_DateFrom_1;

		// Token: 0x04000208 RID: 520
		private Button btn_OneMonth_1;

		// Token: 0x04000209 RID: 521
		private Button btn_OneWeek_1;

		// Token: 0x0400020A RID: 522
		private PictureBox pb_CheckSrsEnabled_1;

		// Token: 0x0400020B RID: 523
		private Button btn_TwoWeek_1;

		// Token: 0x0400020C RID: 524
		private Button btn_Search_1;

		// Token: 0x0400020D RID: 525
		private Button btn_ThreeMonth_1;

		// Token: 0x0400020E RID: 526
		private CheckBox checkBox_ShowLabel_1;

		// Token: 0x0400020F RID: 527
		private GroupBox groupBox2;

		// Token: 0x04000210 RID: 528
		private CheckBox checkBox_ShowLabel_2;

		// Token: 0x04000211 RID: 529
		private Button btn_ThreeMonth_2;

		// Token: 0x04000212 RID: 530
		private Button btn_Search_2;

		// Token: 0x04000213 RID: 531
		private Button btn_TwoWeek_2;

		// Token: 0x04000214 RID: 532
		private PictureBox pb_CheckSrsEnabled_2;

		// Token: 0x04000215 RID: 533
		private Button btn_OneWeek_2;

		// Token: 0x04000216 RID: 534
		private Label label1;

		// Token: 0x04000217 RID: 535
		private DateTimePicker dtPicker_DateTo_2;

		// Token: 0x04000218 RID: 536
		private DateTimePicker dtPicker_DateFrom_2;

		// Token: 0x04000219 RID: 537
		private Button btn_OneMonth_2;

		// Token: 0x0400021A RID: 538
		private Chart chart2;

		// Token: 0x0400021B RID: 539
		private ComboBox combo_Product_2;

		// Token: 0x0400021C RID: 540
		private Label label3;
	}
}
