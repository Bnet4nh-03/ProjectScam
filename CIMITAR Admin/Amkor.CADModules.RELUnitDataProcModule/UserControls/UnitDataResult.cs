using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.RELUnitDataProcModule.CommonClass;
using Amkor.CADModules.RELUnitDataProcModule.Properties;
using ATDFW.Classes.Acount;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.RELUnitDataProcModule.UserControls
{
	// Token: 0x02000014 RID: 20
	public class UnitDataResult : UserControl
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00009B84 File Offset: 0x00007D84
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x00009B8C File Offset: 0x00007D8C
		public CIMitarAccount UserAccount
		{
			get
			{
				return this._userAccount;
			}
			set
			{
				this._userAccount = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00009B95 File Offset: 0x00007D95
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x00009B9D File Offset: 0x00007D9D
		public CommonQuery CommonQry
		{
			get
			{
				return this._commonQry;
			}
			set
			{
				this._commonQry = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00009BA6 File Offset: 0x00007DA6
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00009BAE File Offset: 0x00007DAE
		public string Option
		{
			get
			{
				return this._option;
			}
			set
			{
				this._option = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00009BB7 File Offset: 0x00007DB7
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00009BBF File Offset: 0x00007DBF
		public DateTime StartTime
		{
			get
			{
				return this._startTime;
			}
			set
			{
				this._startTime = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00009BC8 File Offset: 0x00007DC8
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00009BD0 File Offset: 0x00007DD0
		public DateTime EndTime
		{
			get
			{
				return this._endTime;
			}
			set
			{
				this._endTime = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00009BD9 File Offset: 0x00007DD9
		// (set) Token: 0x060000AA RID: 170 RVA: 0x00009BE1 File Offset: 0x00007DE1
		public string Lot
		{
			get
			{
				return this._lot;
			}
			set
			{
				this._lot = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00009BEA File Offset: 0x00007DEA
		// (set) Token: 0x060000AC RID: 172 RVA: 0x00009BF2 File Offset: 0x00007DF2
		public string SN
		{
			get
			{
				return this._sn;
			}
			set
			{
				this._sn = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00009BFB File Offset: 0x00007DFB
		// (set) Token: 0x060000AE RID: 174 RVA: 0x00009C03 File Offset: 0x00007E03
		public string Product
		{
			get
			{
				return this._product;
			}
			set
			{
				this._product = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00009C0C File Offset: 0x00007E0C
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00009C14 File Offset: 0x00007E14
		public DataTable LotList
		{
			get
			{
				return this._lotList;
			}
			set
			{
				this._lotList = value;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00009C20 File Offset: 0x00007E20
		public UnitDataResult()
		{
			this.InitializeComponent();
			this.SetEvent();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00009CB0 File Offset: 0x00007EB0
		private void SetEvent()
		{
			base.Load += this.UnitDataResult_Load;
			this.cboReportType.PopupOpening += this.CboCommon_PopupOpening;
			this.btnSave.Click += this.btnSave_Click;
			this.btnRawData.Click += this.btnRawData_Click;
			this.btnSearch.Click += this.btnSearch_Click;
			this.grdUnit.SelectionChanged += this.GrdUnit_SelectionChanged;
			this.grdUnit.ViewCellFormatting += this.GrdCommon_ViewCellFormatting;
			this.grdUnitDetail.ViewCellFormatting += this.GrdCommon_ViewCellFormatting;
			this.grdFailSummary.ViewCellFormatting += this.GrdCommon_ViewCellFormatting;
			this.grdUnitDetail.ViewCellFormatting += this.GrdCommon_ViewCellFormatting;
			this.grdLotYield.ViewCellFormatting += this.GrdCommon_ViewCellFormatting;
			this.grdUnitDetail.CellFormatting += this.GrdUnitDetail_CellFormatting;
			this.grdUnitDetail.CellValidating += this.GrdUnitDetail_CellValidating;
			this.btnUnitResultDelete.Click += this.BtnUnitResultDelete_Click;
			this.btnUnitResultSave.Click += this.BtnUnitResultSave_Click;
			this.btnUnitResultRefresh.Click += this.BtnUnitResultRefresh_Click;
			this.btnUpdateHist.Click += this.BtnUpdateHist_Click;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00009E54 File Offset: 0x00008054
		private void BtnUpdateHist_Click(object sender, EventArgs e)
		{
			DataTable lotSn = this._dtSearchData.DefaultView.ToTable(true, new string[]
			{
				"lot",
				"sn"
			});
			new PopUpEditHistory
			{
				CommonQry = this._commonQry,
				LotSn = lotSn
			}.Show();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00009EAC File Offset: 0x000080AC
		private void UnitDataResult_Load(object sender, EventArgs e)
		{
			this.InitControl();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00009EB8 File Offset: 0x000080B8
		private void CboCommon_PopupOpening(object sender, CancelEventArgs e)
		{
			RadDropDownListElement radDropDownListElement = sender as RadDropDownListElement;
			float num = 0f;
			for (int i = 0; i < radDropDownListElement.Items.Count<RadListDataItem>(); i++)
			{
				num = Math.Max(num, (float)TextRenderer.MeasureText(radDropDownListElement.Items[i].Text, radDropDownListElement.Font).Width);
			}
			bool flag = radDropDownListElement.Items.Count * (radDropDownListElement.ItemHeight - 1) > radDropDownListElement.DropDownHeight;
			if (flag)
			{
				num += (float)radDropDownListElement.ListElement.VScrollBar.Size.Width;
			}
			num += 60f;
			radDropDownListElement.Popup.Width = (((sender as RadCheckedDropDownListElement).DesiredSize.Width < num) ? ((int)num) : ((int)(sender as RadCheckedDropDownListElement).DesiredSize.Width));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00009FA4 File Offset: 0x000081A4
		private void GrdUnitDetail_CellValidating(object sender, CellValidatingEventArgs e)
		{
			bool flag = !Convert.ToString(e.OldValue).Equals(Convert.ToString(e.Value));
			if (flag)
			{
				this._lstChangeCellIdx.Add(string.Format("{0}_{1}", e.RowIndex, e.ColumnIndex));
				bool flag2 = !Convert.ToString(e.Row.Cells["rowState"].Value).Equals("Delete");
				if (flag2)
				{
					e.Row.Cells["rowState"].Value = "Update";
				}
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000A052 File Offset: 0x00008252
		private void BtnUnitResultRefresh_Click(object sender, EventArgs e)
		{
			this._lstChangeCellIdx = new List<string>();
			this._dtSearchData = this._dtOriSearchData.Copy();
			this.grdUnitDetail.DataSource = this._dtSearchData;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000A084 File Offset: 0x00008284
		private void BtnUnitResultDelete_Click(object sender, EventArgs e)
		{
			foreach (GridViewRowInfo gridViewRowInfo in this.grdUnitDetail.Rows)
			{
				bool flag = Convert.ToString(gridViewRowInfo.Cells["chk"].Value).ToUpper().Equals("TRUE");
				if (flag)
				{
					gridViewRowInfo.Cells["chk"].Value = false;
					gridViewRowInfo.Cells["rowState"].Value = "Delete";
				}
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000A13C File Offset: 0x0000833C
		private void GrdUnitDetail_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = Convert.ToString(e.Row.Cells["rowState"].Value).Equals("Delete");
			if (flag)
			{
				e.CellElement.DrawFill = true;
				e.CellElement.GradientStyle = GradientStyles.Solid;
				e.CellElement.BackColor = Color.FromArgb(240, 135, 135);
			}
			else
			{
				bool flag2 = this._lstChangeCellIdx.Contains(string.Format("{0}_{1}", e.RowIndex, e.ColumnIndex)) && !e.Column.Name.Equals("chk");
				if (flag2)
				{
					e.CellElement.DrawFill = true;
					e.CellElement.GradientStyle = GradientStyles.Solid;
					e.CellElement.BackColor = Color.FromArgb(255, 255, 145);
				}
				else
				{
					e.CellElement.ResetValue(VisualElement.FontProperty, ValueResetFlags.Local);
					e.CellElement.ResetValue(VisualElement.ForeColorProperty, ValueResetFlags.Local);
					e.CellElement.ResetValue(VisualElement.BackColorProperty, ValueResetFlags.Local);
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000A280 File Offset: 0x00008480
		private void BtnUnitResultSave_Click(object sender, EventArgs e)
		{
			string text = "Are you sure you want to save?";
			bool flag = RadMessageBox.Show(text, "CIMitar Admin", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No;
			if (!flag)
			{
				this.SaveData();
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000A2B4 File Offset: 0x000084B4
		private void GrdCommon_ViewCellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement is GridRowHeaderCellElement && e.Row is GridViewDataRowInfo;
			if (flag)
			{
				e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
				e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.TextImageRelationProperty, ValueResetFlags.Local);
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000A32C File Offset: 0x0000852C
		private void GrdUnit_SelectionChanged(object sender, EventArgs e)
		{
			RadGridView radGridView = sender as RadGridView;
			List<string> lstSnLot = new List<string>();
			foreach (GridViewCellInfo gridViewCellInfo in radGridView.SelectedCells)
			{
				lstSnLot.Add(string.Format("{0}_{1}", radGridView.Rows[gridViewCellInfo.RowInfo.Index].Cells["sn"].Value, radGridView.Rows[gridViewCellInfo.RowInfo.Index].Cells["lot"].Value));
			}
			EnumerableRowCollection<DataRow> source = from c in this._dtSearchData.AsEnumerable()
			where lstSnLot.Contains(string.Format("{0}_{1}", c.Field("sn"), c.Field("lot")))
			select c;
			DataTable obj = source.Any<DataRow>() ? source.CopyToDataTable<DataRow>() : this._dtSearchData.Clone();
			this.cm.GridViewSetDataSource(this.grdUnitDetail, obj);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000A44C File Offset: 0x0000864C
		public void btnSearch_Click(object sender, EventArgs e)
		{
			this.pvMain.SelectedPage = this.pvMain.Pages[0];
			bool flag = this._lotList == null || this._lotList.Rows.Count == 0;
			if (flag)
			{
				RadMessageBox.Show(this, "Select Lot List", "CIMitar Admin", MessageBoxButtons.OK, RadMessageIcon.Error);
			}
			else
			{
				try
				{
					this.SearchData();
				}
				catch (Exception ex)
				{
					ex.Message.ToString();
					Thread.Sleep(100);
					bool flag2 = this._barPrograss != null;
					if (flag2)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000A504 File Offset: 0x00008704
		private void btnSave_Click(object sender, EventArgs e)
		{
			Dictionary<string, RadGridView> dictionary = new Dictionary<string, RadGridView>();
			dictionary.Add("Unit TestResult(Per unit)", this.grdUnitDetail);
			dictionary.Add("Lot Yield", this.grdLotYield);
			dictionary.Add("Failure Summary ", this.grdFailSummary);
			this.saveFileDialog.DefaultExt = ".xlsx";
			this.saveFileDialog.Filter = "Excel files|*.xlsx";
			this.saveFileDialog.FileName = string.Empty;
			DialogResult dialogResult = this.saveFileDialog.ShowDialog();
			bool flag = dialogResult == DialogResult.OK;
			if (flag)
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Save Data....");
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				ExcelControl.SaveExcel(this.saveFileDialog.FileName, dictionary);
				Thread.Sleep(100);
				bool flag2 = this._barPrograss != null;
				if (flag2)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000A624 File Offset: 0x00008824
		private void btnRawData_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(this._product);
			if (flag)
			{
				RadMessageBox.Show(this, "Select Product please", "CIMitar Admin", MessageBoxButtons.OK, RadMessageIcon.Error);
			}
			else
			{
				bool flag2 = RadMessageBox.Show(this, "Is the selected date correct? \nStartDate : " + this._startTime.ToShortDateString() + "\nEndDate : " + this._endTime.ToShortDateString(), "CIMitar Admin", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No;
				if (!flag2)
				{
					this.saveFileDialog.DefaultExt = ".xlsx";
					this.saveFileDialog.Filter = "Excel files|*.xlsx|CSV files|*.csv";
					this.saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = this.saveFileDialog.ShowDialog();
					bool flag3 = dialogResult == DialogResult.OK;
					if (flag3)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Fail Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						TimeSpan timeSpan = this._endTime.Subtract(this._startTime);
						DataSet dataSet = new DataSet();
						int num = 0;
						this._barPrograss.setMax(1);
						bool flag4 = timeSpan.Days > 30;
						if (flag4)
						{
							this._barPrograss.setMax(timeSpan.Days / 30);
						}
						DateTime t = this._startTime;
						while (t <= this._endTime)
						{
							DateTime t2 = t.AddDays(29.0);
							bool flag5 = t2 > this._endTime;
							if (flag5)
							{
								t2 = this._endTime;
							}
							this._barPrograss.progress_labelheader_set("Loading data : ~ " + t2.ToString("yyyy-MM-dd"));
							string text = "\r\n                                        EXEC [CIMitar_Unit].[dbo].[USP_ADMIN_RELUnitResultLastFail_Select] @startdate = @Vstartdate@\r\n                                                                                                , @enddate = @Venddate@\r\n                                                                                                , @product = @Vproduct@\r\n                                       ";
							text = text.Replace("@Vstartdate@", string.Format("'{0}'", t.ToShortDateString()));
							text = text.Replace("@Venddate@", string.Format("'{0}'", t2.ToShortDateString()));
							text = text.Replace("@Vproduct@", string.Format("'{0}'", this._product));
							this._barPrograss.setValue(num++);
							DataSet dataSet2 = this._commonQry.queryCall(text);
							dataSet.Merge(dataSet2);
							t = t.AddDays(30.0);
						}
						bool flag6 = dataSet == null || dataSet.Tables.Count == 0;
						if (flag6)
						{
							RadMessageBox.Show(this, "An error has occurred.", "CIMitar Admin", MessageBoxButtons.OK, RadMessageIcon.Error);
						}
						else
						{
							var enumerable = from c in dataSet.Tables[0].AsEnumerable()
							group c by new
							{
								lot = c.Field("lot"),
								sn = c.Field("sn")
							} into gcs
							select new
							{
								lot = gcs.Key.lot,
								sn = gcs.Key.sn,
								test_seq = gcs.Max((DataRow s) => s.Field("test_seq"))
							};
							List<string> lstLotSeq = new List<string>();
							foreach (var <>f__AnonymousType in enumerable)
							{
								lstLotSeq.Add(string.Format("{0}_{1}_{2}", <>f__AnonymousType.lot, <>f__AnonymousType.sn, <>f__AnonymousType.test_seq));
							}
							DataTable dataTable = (from c in dataSet.Tables[0].AsEnumerable()
							where lstLotSeq.Contains(string.Format("{0}_{1}_{2}", c.Field("lot"), c.Field("sn"), c.Field("test_seq")))
							select c).CopyToDataTable<DataRow>();
							dataTable.TableName = "LotSeq";
							bool flag7 = this.saveFileDialog.FilterIndex == 1;
							if (flag7)
							{
								SortedList sortedList = new SortedList();
								sortedList.Add(1, dataTable);
								ExcelControl.SaveExcel(this.saveFileDialog.FileName, sortedList, true);
							}
							else
							{
								ExcelControl.generateCSV(this.saveFileDialog.FileName, dataTable, true);
							}
							dataSet.Clear();
							Thread.Sleep(100);
							bool flag8 = this._barPrograss != null;
							if (flag8)
							{
								this._barPrograss._ischeck = true;
							}
							this._barPrograss = null;
						}
					}
				}
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000AA70 File Offset: 0x00008C70
		private void InitControl()
		{
			this.cbsUnitResult.OverflowButton.Visibility = ElementVisibility.Collapsed;
			this.InitGrid();
			this.InitCombo();
			this.InitGridStrip(false);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000AA9C File Offset: 0x00008C9C
		private void InitGrid()
		{
			this.InitDefaultGrid(this.grdUnit);
			this.grdUnit.Columns.Add(this.cm.SetGridViewColumn("sn", "SN", true, 125, true, true, false, "TextBox"));
			this.grdUnit.Columns.Add(this.cm.SetGridViewColumn("test_seq", "TestCount", true, 125, true, true, false, "TextBox"));
			this.grdUnit.Columns.Add(this.cm.SetGridViewColumn("lotid", "LotID", false, 125, true, true, false, "TextBox"));
			this.grdUnit.Columns.Add(this.cm.SetGridViewColumn("lot", "Lot", true, 125, true, true, false, "TextBox"));
			this.grdUnit.Columns.Add(this.cm.SetGridViewColumn("dcc", "Dcc", false, 125, true, true, false, "TextBox"));
			this.grdUnit.Columns.Add(this.cm.SetGridViewColumn("operation", "Operation", true, 125, true, true, false, "TextBox"));
			this.InitDefaultGrid(this.grdUnitDetail);
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("chk", "", true, 22, false, false, true, "CheckBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("rowState", "rowState", false, 22, false, false, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("unitdataid", "LotID", false, 80, true, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("lotid", "LotID", false, 125, true, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("lot", "Lot", true, 125, true, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("dcc", "Dcc", false, 125, true, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("sn", "SN", true, 125, true, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("starttime", "StartTime", true, 125, true, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("endtime", "EndTime", true, 125, true, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("testtime", "TestTime", true, 125, true, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("product", "Product", true, 125, false, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("operation", "Operation", true, 125, false, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("test_seq", "TestType", true, 125, true, true, false, "Decimal"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("program", "Program", true, 125, false, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("tester", "Tester", true, 125, false, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("site", "site Number", true, 125, false, true, false, "Decimal"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("result", "PASS/FAIL", true, 125, false, true, false, "ComboBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("ecid", "ECID", true, 125, false, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("fail_desc", "Fail Desc", true, 125, false, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("measure_result", "1st Failing Test", true, 125, false, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("retestcode", "retestcode", false, 125, false, true, false, "Decimal"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("hbin", "hbin", false, 125, false, true, false, "TextBox"));
			this.grdUnitDetail.Columns.Add(this.cm.SetGridViewColumn("sbin", "sbin", false, 125, false, true, false, "TextBox"));
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("value");
			dataTable.Rows.Add(new object[]
			{
				"PASS"
			});
			dataTable.Rows.Add(new object[]
			{
				"FAIL"
			});
			(this.grdUnitDetail.Columns["result"] as GridViewComboBoxColumn).DataSource = dataTable;
			(this.grdUnitDetail.Columns["result"] as GridViewComboBoxColumn).ValueMember = "value";
			(this.grdUnitDetail.Columns["result"] as GridViewComboBoxColumn).DisplayMember = "value";
			this.InitDefaultGrid(this.grdLotYield);
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("lotid", "lotid", false, 125, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("lot", "Lot", true, 125, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("dcc", "Dcc", false, 125, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("operation", "Operation", true, 125, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("product", "Product", true, 125, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("tester", "Tester", true, 125, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("program", "Program", true, 125, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("starttime", "StartTime", true, 125, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("endtime", "EndTime", true, 125, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("input", "Input", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("pass_final", "PASS_Final", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("fail_final", "FAIL_Final", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("yield", "Yield", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("pass_1st", "PASS_1st", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("fail_1st", "FAIL_1st", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("fpy", "FPY", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("retestrate", "Retest Rate", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("pass_2nd", "PASS_2nd", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("fail_2nd", "FAIL_2nd", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("pass_3rd", "PASS_3rd", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("fail_3rd", "FAIL_3rd", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("pass_4th", "PASS_4th", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("fail_4th", "FAIL_4th", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("pass_5th", "PASS_5th", true, 80, true, true, false, "TextBox"));
			this.grdLotYield.Columns.Add(this.cm.SetGridViewColumn("fail_5th", "FAIL_5th", true, 80, true, true, false, "TextBox"));
			this.InitDefaultGrid(this.grdFailSummary);
			this.grdFailSummary.Columns.Add(this.cm.SetGridViewColumn("product", "Product", true, 125, true, true, false, "TextBox"));
			this.grdFailSummary.Columns.Add(this.cm.SetGridViewColumn("device", "Device", true, 125, true, true, false, "TextBox"));
			this.grdFailSummary.Columns.Add(this.cm.SetGridViewColumn("lot", "Lot", true, 125, true, true, false, "TextBox"));
			this.grdFailSummary.Columns.Add(this.cm.SetGridViewColumn("dcc", "Dcc", false, 125, true, true, false, "TextBox"));
			this.grdFailSummary.Columns.Add(this.cm.SetGridViewColumn("operation", "Operation", true, 125, true, true, false, "TextBox"));
			this.grdFailSummary.Columns.Add(this.cm.SetGridViewColumn("testtype", "TestType", true, 125, true, true, false, "TextBox"));
			this.grdFailSummary.Columns.Add(this.cm.SetGridViewColumn("measure_result", "1st Failing Test", true, 125, true, true, false, "TextBox"));
			this.grdFailSummary.Columns.Add(this.cm.SetGridViewColumn("failureqty", "Failure Qty", true, 125, true, true, false, "TextBox"));
			this.grdFailSummary.Columns.Add(this.cm.SetGridViewColumn("failurerate", "Failure Rate", true, 125, true, true, false, "TextBox"));
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000B7A4 File Offset: 0x000099A4
		private void InitCombo()
		{
			try
			{
				string sQuery = "EXEC [CIMitar_Unit].[dbo].[ADMIN_CMN_UnitCode_Select] @CodeGroupID = 'UnitReportType'";
				DataSet dataSet = this._commonQry.queryCall(sQuery);
				bool flag = dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0;
				if (flag)
				{
					this.cboReportType.CheckedMember = null;
					foreach (object obj in dataSet.Tables[0].Rows)
					{
						DataRow dataRow = (DataRow)obj;
						RadCheckedListDataItem radCheckedListDataItem = new RadCheckedListDataItem();
						radCheckedListDataItem.Checked = true;
						radCheckedListDataItem.Text = Convert.ToString(dataRow["CodeName"]);
						radCheckedListDataItem.Value = Convert.ToString(dataRow["CodeID"]);
						this.cboReportType.Items.Add(radCheckedListDataItem);
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000B8D8 File Offset: 0x00009AD8
		private void SearchData()
		{
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this._barPrograss.setMax(100);
				this._dtSearchData = new DataTable();
				this._lstChangeCellIdx = new List<string>();
				List<string> list = (from s in this.cboReportType.CheckedItems.AsEnumerable<RadCheckedListDataItem>()
				select s.Text.Trim()).ToList<string>();
				foreach (object obj in this._lotList.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					this._barPrograss.setValue(this._barPrograss.ProgressBarValue + 70 / this._lotList.Rows.Count);
					string arg = Convert.ToString(dataRow["lotid"]);
					string arg2 = Convert.ToString(dataRow["lot"]);
					string sn = this._sn;
					string text = "\r\n                                        EXEC [CIMitar_Unit].[dbo].[ADMIN_UNIT_RELUnitData_Select] @lotid = @Vlotid@\r\n                                                                                                , @lot = @Vlot@\r\n                                                                                                , @sn = @Vsn@\r\n                                       ";
					text = text.Replace("@Vlotid@", string.Format("'{0}'", arg));
					text = text.Replace("@Vlot@", string.Format("'{0}'", arg2));
					text = text.Replace("@Vsn@", string.Format("'{0}'", sn));
					DataSet dataSet = this._commonQry.queryCall(text);
					bool flag = this._dtSearchData.Columns.Count == 0;
					if (flag)
					{
						dataSet.Tables[0].Clone();
					}
					this._dtSearchData.Merge(dataSet.Tables[0]);
				}
				bool flag2 = this.rdoPassResult.CheckState == CheckState.Checked;
				if (flag2)
				{
					EnumerableRowCollection<DataRow> source = from c in this._dtSearchData.AsEnumerable()
					where c.Field("result").ToUpper() == "PASS"
					select c;
					this._dtSearchData = (source.Any<DataRow>() ? source.CopyToDataTable<DataRow>() : this._dtSearchData.Clone());
				}
				bool flag3 = this.rdoFailResult.CheckState == CheckState.Checked;
				if (flag3)
				{
					EnumerableRowCollection<DataRow> source2 = from c in this._dtSearchData.AsEnumerable()
					where c.Field("result").ToUpper() != "PASS"
					select c;
					this._dtSearchData = (source2.Any<DataRow>() ? source2.CopyToDataTable<DataRow>() : this._dtSearchData.Clone());
				}
				var source3 = from c in this._dtSearchData.AsEnumerable()
				group c by new
				{
					sn = c.Field("sn"),
					lot = c.Field("lot"),
					dcc = c.Field("dcc"),
					operation = c.Field("operation"),
					lotid = c.Field("lotid")
				} into gcs
				select new
				{
					sn = gcs.Key.sn,
					lot = gcs.Key.lot,
					dcc = gcs.Key.dcc,
					operation = gcs.Key.operation,
					lotid = gcs.Key.lotid,
					test_seq = gcs.Max((DataRow s) => s.Field("test_seq")),
					result = gcs.Max((DataRow s) => s.Field("result")).ToUpper()
				};
				bool flag4 = this.rdo1st.CheckState == CheckState.Checked;
				if (flag4)
				{
					EnumerableRowCollection<DataRow> source4 = from c in this._dtSearchData.AsEnumerable()
					where c.Field("test_seq") == 1
					select c;
					this._dtSearchData = (source4.Any<DataRow>() ? source4.CopyToDataTable<DataRow>() : this._dtSearchData.Clone());
				}
				bool flag5 = this.rdoFinal.CheckState == CheckState.Checked;
				if (flag5)
				{
					List<string> lstFinalSeq = (from s in source3
					select string.Format("{0}_{1}", s.test_seq, s.lot)).ToList<string>();
					EnumerableRowCollection<DataRow> source5 = from c in this._dtSearchData.AsEnumerable()
					where lstFinalSeq.Contains(string.Format("{0}_{1}", c.Field("test_seq"), c.Field("lot")))
					select c;
					this._dtSearchData = (source5.Any<DataRow>() ? source5.CopyToDataTable<DataRow>() : this._dtSearchData.Clone());
				}
				var obj2 = from c in this._dtSearchData.AsEnumerable()
				group c by new
				{
					lotid = c.Field("lotid"),
					lot = c.Field("lot"),
					dcc = c.Field("dcc"),
					operation = c.Field("operation"),
					product = c.Field("product"),
					tester = c.Field("tester"),
					program = c.Field("program")
				} into gcs
				select new
				{
					lotid = gcs.Key.lotid,
					lot = gcs.Key.lot,
					dcc = gcs.Key.dcc,
					operation = gcs.Key.operation,
					product = gcs.Key.product,
					tester = gcs.Key.tester,
					program = gcs.Key.program,
					starttime = gcs.Min((DataRow s) => s.Field("starttime")),
					endtime = gcs.Max((DataRow s) => s.Field("endtime"))
				};
				bool flag6 = list.Contains("Lot Yield");
				if (flag6)
				{
					this.pvMain.Pages["pvLotYield"].Item.Visibility = ElementVisibility.Visible;
					this.cm.GridViewSetDataSource(this.grdLotYield, obj2);
				}
				else
				{
					this.pvMain.Pages["pvLotYield"].Item.Visibility = ElementVisibility.Collapsed;
				}
				foreach (GridViewRowInfo gridViewRowInfo in this.grdLotYield.Rows)
				{
					long num = Convert.ToInt64(gridViewRowInfo.Cells["lotid"].Value);
					string strLot = Convert.ToString(gridViewRowInfo.Cells["lot"].Value);
					int num2 = (from c in source3.AsEnumerable()
					where c.lot == strLot
					select c).Count();
					int num3 = (from c in source3.AsEnumerable()
					where c.lot == strLot && c.result == "PASS"
					select c).Count();
					int num4 = (from c in source3.AsEnumerable()
					where c.lot == strLot && c.result != "PASS"
					select c).Count();
					double num5 = Math.Round(Convert.ToDouble(num3) / (double)num2 * 100.0, 2);
					int num6 = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() == "PASS" && c.Field("test_seq") == 1
					select c).Count<DataRow>();
					int num7 = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() != "PASS" && c.Field("test_seq") == 1
					select c).Count<DataRow>();
					double num8 = Math.Round(Convert.ToDouble(num6) / (double)num2 * 100.0, 2);
					double num9 = Math.Round(num5 - num8, 2);
					gridViewRowInfo.Cells["input"].Value = num2;
					gridViewRowInfo.Cells["pass_final"].Value = num3;
					gridViewRowInfo.Cells["fail_final"].Value = num4;
					gridViewRowInfo.Cells["yield"].Value = num5;
					gridViewRowInfo.Cells["pass_1st"].Value = num6;
					gridViewRowInfo.Cells["fail_1st"].Value = num7;
					gridViewRowInfo.Cells["fpy"].Value = num8;
					gridViewRowInfo.Cells["retestrate"].Value = num9;
					gridViewRowInfo.Cells["pass_2nd"].Value = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() == "PASS" && c.Field("test_seq") == 2
					select c).Count<DataRow>();
					gridViewRowInfo.Cells["fail_2nd"].Value = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() != "PASS" && c.Field("test_seq") == 2
					select c).Count<DataRow>();
					gridViewRowInfo.Cells["pass_3rd"].Value = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() == "PASS" && c.Field("test_seq") == 3
					select c).Count<DataRow>();
					gridViewRowInfo.Cells["fail_3rd"].Value = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() != "PASS" && c.Field("test_seq") == 3
					select c).Count<DataRow>();
					gridViewRowInfo.Cells["pass_4th"].Value = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() == "PASS" && c.Field("test_seq") == 4
					select c).Count<DataRow>();
					gridViewRowInfo.Cells["fail_4th"].Value = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() != "PASS" && c.Field("test_seq") == 4
					select c).Count<DataRow>();
					gridViewRowInfo.Cells["pass_5th"].Value = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() == "PASS" && c.Field("test_seq") == 5
					select c).Count<DataRow>();
					gridViewRowInfo.Cells["fail_5th"].Value = (from c in this._dtSearchData.AsEnumerable()
					where c.Field("lot") == strLot && c.Field("result").ToUpper() != "PASS" && c.Field("test_seq") == 5
					select c).Count<DataRow>();
				}
				var inner = from c in source3
				group c by new
				{
					c.lot
				} into gcs
				select new
				{
					lot = gcs.Key.lot,
					test_seq_max = gcs.Max(s => s.test_seq),
					input = gcs.Count()
				};
				var obj3 = from c in this._dtSearchData.AsEnumerable()
				join u in inner on c.Field("lot") equals u.lot
				where (c.Field("test_seq") == 1 || c.Field("test_seq") == u.test_seq_max) && c.Field("result").ToUpper() != "PASS"
				group c by new
				{
					lotid = c.Field("lotid"),
					lot = c.Field("lot"),
					dcc = c.Field("dcc"),
					operation = c.Field("operation"),
					product = c.Field("product"),
					test_seq = c.Field("test_seq"),
					measure_result = c.Field("measure_result"),
					input = u.input
				} into gcs
				select new
				{
					lotid = gcs.Key.lotid,
					lot = gcs.Key.lot,
					dcc = gcs.Key.dcc,
					operation = gcs.Key.operation,
					product = gcs.Key.product,
					testtype = ((gcs.Key.test_seq == 1) ? "1st" : "Final"),
					measure_result = gcs.Key.measure_result,
					failureqty = gcs.Count<DataRow>(),
					failurerate = Math.Round(Convert.ToDouble(gcs.Count<DataRow>()) / (double)gcs.Key.input * 100.0, 4)
				};
				bool flag7 = list.Contains("Failure Summary");
				if (flag7)
				{
					this.pvMain.Pages["pvFailureSummary"].Item.Visibility = ElementVisibility.Visible;
					this.cm.GridViewSetDataSource(this.grdFailSummary, obj3);
				}
				else
				{
					this.pvMain.Pages["pvFailureSummary"].Item.Visibility = ElementVisibility.Collapsed;
				}
				bool flag8 = list.Contains("Unit TestResult(Per unit)");
				if (flag8)
				{
					this.pvMain.Pages["pvUnitTestResult"].Item.Visibility = ElementVisibility.Visible;
				}
				else
				{
					this.pvMain.Pages["pvUnitTestResult"].Item.Visibility = ElementVisibility.Collapsed;
					this.pvMain.SelectedPage = null;
				}
				this._dtOriSearchData = this._dtSearchData.Copy();
				this.cm.GridViewSetDataSource(this.grdUnitDetail, this._dtSearchData);
				this.InitGridStrip(true);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				bool flag9 = this._barPrograss != null;
				if (flag9)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000C4F4 File Offset: 0x0000A6F4
		private void SaveData()
		{
			string text = "PASS";
			string str = string.Empty;
			IEnumerable<GridViewRowInfo> enumerable = from c in this.grdUnitDetail.Rows.AsEnumerable<GridViewRowInfo>()
			where Convert.ToString(c.Cells["rowState"].Value) != string.Empty
			select c;
			foreach (GridViewRowInfo gridViewRowInfo in enumerable)
			{
				string arg = Convert.ToString(gridViewRowInfo.Cells["rowState"].Value).Equals("Delete") ? "4" : "3";
				List<string> list = new List<string>();
				list.Add("chk");
				list.Add("rowState");
				list.Add("testtime");
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("EXEC [CIMitar_Unit].[dbo].[ADMIN_UNIT_RELUnitData_Upsert]\n");
				stringBuilder.Append(string.Format("  @RequestType='{0}'\n", arg));
				stringBuilder.Append(string.Format(",  @modifier='{0}'\n", this._userAccount._id));
				foreach (object obj in gridViewRowInfo.Cells)
				{
					GridViewCellInfo gridViewCellInfo = (GridViewCellInfo)obj;
					bool flag = list.Contains(gridViewCellInfo.ColumnInfo.Name);
					if (!flag)
					{
						stringBuilder.Append(string.Format(", @{0}='{1}'\n", gridViewCellInfo.ColumnInfo.Name, gridViewCellInfo.Value));
					}
				}
				DataSet dataSet = this._commonQry.queryCall(stringBuilder.ToString());
				bool flag2 = Convert.ToString(dataSet.Tables[0].Rows[0][0]).Equals("FAIL");
				if (flag2)
				{
					text = "FAIL";
					str = Convert.ToString(dataSet.Tables[0].Rows[0][1]);
				}
			}
			bool flag3 = text.Equals("PASS");
			if (flag3)
			{
				string text2 = "Save completed.";
				RadMessageBox.Show(text2, "CIMitar Admin", MessageBoxButtons.OK, RadMessageIcon.Info);
			}
			else
			{
				string text3 = "An error occurred while saving.\n";
				text3 += str;
				RadMessageBox.Show(text3, "CIMitar Admin", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
			}
			this.SearchData();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000C798 File Offset: 0x0000A998
		private void InitDefaultGrid(RadGridView gv)
		{
			gv.MasterTemplate.MultiSelect = true;
			gv.AllowAddNewRow = false;
			gv.ShowGroupPanel = false;
			gv.EnableFiltering = true;
			gv.EnableSorting = true;
			gv.EnableGrouping = true;
			gv.MasterView.TableHeaderRow.IsVisible = true;
			gv.MasterTemplate.ShowHeaderCellButtons = true;
			gv.MasterTemplate.ShowFilteringRow = true;
			gv.MasterTemplate.AllowRowResize = false;
			gv.MasterTemplate.AllowDeleteRow = false;
			gv.ClipboardPasteMode = GridViewClipboardPasteMode.EnableWithNotifications;
			gv.SelectionMode = GridViewSelectionMode.CellSelect;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000C834 File Offset: 0x0000AA34
		private void InitGridStrip(bool enabled)
		{
			foreach (RadCommandBarBaseItem radCommandBarBaseItem in this.cbsUnitResult.Items)
			{
				radCommandBarBaseItem.Enabled = enabled;
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000C88C File Offset: 0x0000AA8C
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000C89C File Offset: 0x0000AA9C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000C8D4 File Offset: 0x0000AAD4
		private void InitializeComponent()
		{
			this.btnRawData = new RadButton();
			this.btnSearch = new RadButton();
			this.rdoPassResult = new RadRadioButton();
			this.rdoAllResult = new RadRadioButton();
			this.rdoFailResult = new RadRadioButton();
			this.btnSave = new RadButton();
			this.rdo1st = new RadRadioButton();
			this.rdoFinal = new RadRadioButton();
			this.rdoAll = new RadRadioButton();
			this.cboReportType = new RadCheckedDropDownList();
			this.grdUnit = new RadGridView();
			this.grdFailSummary = new RadGridView();
			this.grdUnitDetail = new RadGridView();
			this.grdLotYield = new RadGridView();
			this.saveFileDialog = new SaveFileDialog();
			this.radSplitContainer1 = new RadSplitContainer();
			this.splitPanel1 = new SplitPanel();
			this.radPanel1 = new RadPanel();
			this.splitPanel2 = new SplitPanel();
			this.pvMain = new RadPageView();
			this.pvUnitTestResult = new RadPageViewPage();
			this.radCommandBar1 = new RadCommandBar();
			this.cbUnitResult = new CommandBarRowElement();
			this.cbsUnitResult = new CommandBarStripElement();
			this.btnUnitResultDelete = new CommandBarButton();
			this.btnUnitResultSave = new CommandBarButton();
			this.btnUnitResultRefresh = new CommandBarButton();
			this.commandBarSeparator1 = new CommandBarSeparator();
			this.btnUpdateHist = new CommandBarButton();
			this.pvLotYield = new RadPageViewPage();
			this.pvFailureSummary = new RadPageViewPage();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.radPanel4 = new RadPanel();
			this.radPanel7 = new RadPanel();
			this.radPanel3 = new RadPanel();
			this.radPanel5 = new RadPanel();
			this.radPanel6 = new RadPanel();
			((ISupportInitialize)this.btnRawData).BeginInit();
			((ISupportInitialize)this.btnSearch).BeginInit();
			((ISupportInitialize)this.rdoPassResult).BeginInit();
			((ISupportInitialize)this.rdoAllResult).BeginInit();
			((ISupportInitialize)this.rdoFailResult).BeginInit();
			((ISupportInitialize)this.btnSave).BeginInit();
			((ISupportInitialize)this.rdo1st).BeginInit();
			((ISupportInitialize)this.rdoFinal).BeginInit();
			((ISupportInitialize)this.rdoAll).BeginInit();
			((ISupportInitialize)this.cboReportType).BeginInit();
			((ISupportInitialize)this.grdUnit).BeginInit();
			((ISupportInitialize)this.grdUnit.MasterTemplate).BeginInit();
			((ISupportInitialize)this.grdFailSummary).BeginInit();
			((ISupportInitialize)this.grdFailSummary.MasterTemplate).BeginInit();
			((ISupportInitialize)this.grdUnitDetail).BeginInit();
			((ISupportInitialize)this.grdUnitDetail.MasterTemplate).BeginInit();
			((ISupportInitialize)this.grdLotYield).BeginInit();
			((ISupportInitialize)this.grdLotYield.MasterTemplate).BeginInit();
			((ISupportInitialize)this.radSplitContainer1).BeginInit();
			this.radSplitContainer1.SuspendLayout();
			((ISupportInitialize)this.splitPanel1).BeginInit();
			this.splitPanel1.SuspendLayout();
			((ISupportInitialize)this.radPanel1).BeginInit();
			((ISupportInitialize)this.splitPanel2).BeginInit();
			((ISupportInitialize)this.pvMain).BeginInit();
			this.pvMain.SuspendLayout();
			this.pvUnitTestResult.SuspendLayout();
			((ISupportInitialize)this.radCommandBar1).BeginInit();
			this.pvLotYield.SuspendLayout();
			this.pvFailureSummary.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((ISupportInitialize)this.radPanel4).BeginInit();
			this.radPanel4.SuspendLayout();
			((ISupportInitialize)this.radPanel7).BeginInit();
			((ISupportInitialize)this.radPanel3).BeginInit();
			this.radPanel3.SuspendLayout();
			((ISupportInitialize)this.radPanel5).BeginInit();
			((ISupportInitialize)this.radPanel6).BeginInit();
			base.SuspendLayout();
			this.btnRawData.Dock = DockStyle.Fill;
			this.btnRawData.Location = new Point(915, 3);
			this.btnRawData.Name = "btnRawData";
			this.btnRawData.Size = new Size(82, 22);
			this.btnRawData.TabIndex = 168;
			this.btnRawData.Text = "FAIL Export";
			this.btnRawData.ThemeName = "CIMitarAdmin_Skin";
			this.btnSearch.Dock = DockStyle.Fill;
			this.btnSearch.Location = new Point(687, 3);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new Size(70, 22);
			this.btnSearch.TabIndex = 166;
			this.btnSearch.Text = "Search";
			this.btnSearch.ThemeName = "CIMitarAdmin_Skin";
			this.rdoPassResult.Dock = DockStyle.Left;
			this.rdoPassResult.Location = new Point(41, 3);
			this.rdoPassResult.Name = "rdoPassResult";
			this.rdoPassResult.Size = new Size(42, 16);
			this.rdoPassResult.TabIndex = 9;
			this.rdoPassResult.TabStop = false;
			this.rdoPassResult.Text = "Pass";
			this.rdoPassResult.ThemeName = "CIMitarAdmin_Skin";
			this.rdoAllResult.CheckState = CheckState.Checked;
			this.rdoAllResult.Dock = DockStyle.Left;
			this.rdoAllResult.Location = new Point(3, 3);
			this.rdoAllResult.Name = "rdoAllResult";
			this.rdoAllResult.Size = new Size(38, 16);
			this.rdoAllResult.TabIndex = 12;
			this.rdoAllResult.Text = "ALL";
			this.rdoAllResult.ThemeName = "CIMitarAdmin_Skin";
			this.rdoAllResult.ToggleState = ToggleState.On;
			this.rdoFailResult.Dock = DockStyle.Left;
			this.rdoFailResult.Location = new Point(83, 3);
			this.rdoFailResult.Name = "rdoFailResult";
			this.rdoFailResult.Size = new Size(37, 16);
			this.rdoFailResult.TabIndex = 11;
			this.rdoFailResult.TabStop = false;
			this.rdoFailResult.Text = "Fail";
			this.rdoFailResult.ThemeName = "CIMitarAdmin_Skin";
			this.btnSave.Dock = DockStyle.Fill;
			this.btnSave.Location = new Point(839, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new Size(70, 22);
			this.btnSave.TabIndex = 164;
			this.btnSave.Text = "Excel Export";
			this.btnSave.ThemeName = "CIMitarAdmin_Skin";
			this.rdo1st.Dock = DockStyle.Left;
			this.rdo1st.Location = new Point(41, 3);
			this.rdo1st.Name = "rdo1st";
			this.rdo1st.Size = new Size(35, 16);
			this.rdo1st.TabIndex = 12;
			this.rdo1st.TabStop = false;
			this.rdo1st.Text = "1st";
			this.rdo1st.ThemeName = "CIMitarAdmin_Skin";
			this.rdoFinal.Dock = DockStyle.Left;
			this.rdoFinal.Location = new Point(76, 3);
			this.rdoFinal.Name = "rdoFinal";
			this.rdoFinal.Size = new Size(43, 16);
			this.rdoFinal.TabIndex = 11;
			this.rdoFinal.TabStop = false;
			this.rdoFinal.Text = "Final";
			this.rdoFinal.ThemeName = "CIMitarAdmin_Skin";
			this.rdoAll.CheckState = CheckState.Checked;
			this.rdoAll.Dock = DockStyle.Left;
			this.rdoAll.Location = new Point(3, 3);
			this.rdoAll.Name = "rdoAll";
			this.rdoAll.Size = new Size(38, 16);
			this.rdoAll.TabIndex = 9;
			this.rdoAll.Text = "ALL";
			this.rdoAll.ThemeName = "CIMitarAdmin_Skin";
			this.rdoAll.ToggleState = ToggleState.On;
			this.tableLayoutPanel1.SetColumnSpan(this.cboReportType, 2);
			this.cboReportType.DefaultItemsCountInDropDown = 20;
			this.cboReportType.Dock = DockStyle.Fill;
			this.cboReportType.Location = new Point(79, 3);
			this.cboReportType.MaxDropDownItems = 50;
			this.cboReportType.Name = "cboReportType";
			this.cboReportType.Padding = new Padding(2, 2, 2, 1);
			this.cboReportType.Size = new Size(146, 23);
			this.cboReportType.TabIndex = 2;
			this.cboReportType.ThemeName = "CIMitarAdmin_Skin";
			this.grdUnit.Dock = DockStyle.Fill;
			this.grdUnit.Location = new Point(0, 22);
			this.grdUnit.MasterTemplate.MultiSelect = true;
			this.grdUnit.Name = "grdUnit";
			this.grdUnit.Size = new Size(252, 563);
			this.grdUnit.TabIndex = 0;
			this.grdUnit.ThemeName = "CIMitarAdmin_Skin";
			this.grdFailSummary.Dock = DockStyle.Fill;
			this.grdFailSummary.Location = new Point(0, 0);
			this.grdFailSummary.MasterTemplate.MultiSelect = true;
			this.grdFailSummary.Name = "grdFailSummary";
			this.grdFailSummary.Size = new Size(0, 0);
			this.grdFailSummary.TabIndex = 164;
			this.grdFailSummary.ThemeName = "CIMitarAdmin_Skin";
			this.grdUnitDetail.Dock = DockStyle.Fill;
			this.grdUnitDetail.Location = new Point(0, 40);
			this.grdUnitDetail.MasterTemplate.MultiSelect = true;
			this.grdUnitDetail.Name = "grdUnitDetail";
			this.grdUnitDetail.Size = new Size(979, 497);
			this.grdUnitDetail.TabIndex = 163;
			this.grdUnitDetail.ThemeName = "CIMitarAdmin_Skin";
			this.grdLotYield.Dock = DockStyle.Fill;
			this.grdLotYield.Location = new Point(0, 0);
			this.grdLotYield.MasterTemplate.MultiSelect = true;
			this.grdLotYield.Name = "grdLotYield";
			this.grdLotYield.Size = new Size(0, 0);
			this.grdLotYield.TabIndex = 150;
			this.grdLotYield.ThemeName = "CIMitarAdmin_Skin";
			this.radSplitContainer1.Controls.Add(this.splitPanel1);
			this.radSplitContainer1.Controls.Add(this.splitPanel2);
			this.radSplitContainer1.Dock = DockStyle.Fill;
			this.radSplitContainer1.EnableCollapsing = true;
			this.radSplitContainer1.Location = new Point(0, 28);
			this.radSplitContainer1.Name = "radSplitContainer1";
			this.radSplitContainer1.RootElement.MinSize = new Size(0, 0);
			this.radSplitContainer1.RootElement.ShouldPaint = true;
			this.radSplitContainer1.Size = new Size(1000, 585);
			this.radSplitContainer1.SplitterWidth = 8;
			this.radSplitContainer1.TabIndex = 7;
			this.radSplitContainer1.TabStop = false;
			this.radSplitContainer1.Text = "radSplitContainer1";
			this.radSplitContainer1.ThemeName = "CIMitarAdmin_Skin";
			this.radSplitContainer1.UseSplitterButtons = true;
			this.radSplitContainer1.Visible = false;
			this.splitPanel1.Controls.Add(this.grdUnit);
			this.splitPanel1.Controls.Add(this.radPanel1);
			this.splitPanel1.Location = new Point(0, 0);
			this.splitPanel1.Name = "splitPanel1";
			this.splitPanel1.RootElement.MinSize = new Size(0, 0);
			this.splitPanel1.Size = new Size(252, 585);
			this.splitPanel1.SizeInfo.AutoSizeScale = new SizeF(-0.2459677f, 0f);
			this.splitPanel1.SizeInfo.SplitterCorrection = new Size(-245, 0);
			this.splitPanel1.TabIndex = 0;
			this.splitPanel1.TabStop = false;
			this.splitPanel1.Text = "splitPanel1";
			this.splitPanel1.ThemeName = "CIMitarAdmin_Skin";
			this.radPanel1.BackColor = Color.FromArgb(241, 115, 174);
			this.radPanel1.Dock = DockStyle.Top;
			this.radPanel1.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.radPanel1.ForeColor = Color.White;
			this.radPanel1.Location = new Point(0, 0);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Padding = new Padding(3);
			this.radPanel1.Size = new Size(252, 22);
			this.radPanel1.TabIndex = 1;
			this.radPanel1.Text = "Unit List";
			this.radPanel1.ThemeName = "CIMitarAdmin_Skin";
			this.splitPanel2.Location = new Point(260, 0);
			this.splitPanel2.Name = "splitPanel2";
			this.splitPanel2.RootElement.MinSize = new Size(0, 0);
			this.splitPanel2.Size = new Size(740, 585);
			this.splitPanel2.SizeInfo.AutoSizeScale = new SizeF(0.2459677f, 0f);
			this.splitPanel2.SizeInfo.SplitterCorrection = new Size(245, 0);
			this.splitPanel2.TabIndex = 1;
			this.splitPanel2.TabStop = false;
			this.splitPanel2.Text = "splitPanel2";
			this.splitPanel2.ThemeName = "CIMitarAdmin_Skin";
			this.pvMain.Controls.Add(this.pvUnitTestResult);
			this.pvMain.Controls.Add(this.pvLotYield);
			this.pvMain.Controls.Add(this.pvFailureSummary);
			this.pvMain.DefaultPage = this.pvUnitTestResult;
			this.pvMain.Dock = DockStyle.Fill;
			this.pvMain.ItemSizeMode = PageViewItemSizeMode.EqualSize;
			this.pvMain.Location = new Point(0, 28);
			this.pvMain.Name = "pvMain";
			this.pvMain.SelectedPage = this.pvUnitTestResult;
			this.pvMain.Size = new Size(1000, 585);
			this.pvMain.TabIndex = 1;
			this.pvMain.Text = "radPageView1";
			this.pvMain.ThemeName = "CIMitarAdmin_Skin";
			((RadPageViewStripElement)this.pvMain.GetChildAt(0)).StripButtons = StripViewButtons.None;
			((RadPageViewStripElement)this.pvMain.GetChildAt(0)).ShowItemCloseButton = false;
			((RadPageViewStripElement)this.pvMain.GetChildAt(0)).ItemSizeMode = PageViewItemSizeMode.EqualSize;
			this.pvUnitTestResult.Controls.Add(this.grdUnitDetail);
			this.pvUnitTestResult.Controls.Add(this.radCommandBar1);
			this.pvUnitTestResult.ItemSize = new SizeF(140f, 28f);
			this.pvUnitTestResult.Location = new Point(10, 37);
			this.pvUnitTestResult.Name = "pvUnitTestResult";
			this.pvUnitTestResult.Size = new Size(979, 537);
			this.pvUnitTestResult.Text = "Unit Test Result(Per unit)";
			this.radCommandBar1.Dock = DockStyle.Top;
			this.radCommandBar1.Location = new Point(0, 0);
			this.radCommandBar1.Name = "radCommandBar1";
			this.radCommandBar1.Rows.AddRange(new CommandBarRowElement[]
			{
				this.cbUnitResult
			});
			this.radCommandBar1.Size = new Size(979, 40);
			this.radCommandBar1.TabIndex = 1;
			this.radCommandBar1.Text = "radCommandBar1";
			this.radCommandBar1.ThemeName = "CIMitarAdmin_Skin";
			this.cbUnitResult.MinSize = new Size(25, 25);
			this.cbUnitResult.Strips.AddRange(new CommandBarStripElement[]
			{
				this.cbsUnitResult
			});
			this.cbsUnitResult.DisplayName = "commandBarStripElement1";
			this.cbsUnitResult.Items.AddRange(new RadCommandBarBaseItem[]
			{
				this.btnUnitResultDelete,
				this.btnUnitResultSave,
				this.btnUnitResultRefresh,
				this.commandBarSeparator1,
				this.btnUpdateHist
			});
			this.cbsUnitResult.Name = "commandBarStripElement1";
			this.btnUnitResultDelete.AccessibleDescription = "Delete";
			this.btnUnitResultDelete.AccessibleName = "Delete";
			this.btnUnitResultDelete.DisplayName = "commandBarButton1";
			this.btnUnitResultDelete.Image = Resources.TableRemove;
			this.btnUnitResultDelete.Name = "btnUnitResultDelete";
			this.btnUnitResultDelete.Text = "Delete";
			this.btnUnitResultDelete.ToolTipText = "Row Delete";
			this.btnUnitResultSave.AccessibleDescription = "Save";
			this.btnUnitResultSave.AccessibleName = "Save";
			this.btnUnitResultSave.DisplayName = "commandBarButton2";
			this.btnUnitResultSave.Image = Resources.TableSave;
			this.btnUnitResultSave.Name = "btnUnitResultSave";
			this.btnUnitResultSave.Text = "Save";
			this.btnUnitResultSave.ToolTipText = "Save";
			this.btnUnitResultRefresh.AccessibleDescription = "Refresh";
			this.btnUnitResultRefresh.AccessibleName = "Refresh";
			this.btnUnitResultRefresh.DisplayName = "commandBarButton1";
			this.btnUnitResultRefresh.Image = Resources.TableRefresh;
			this.btnUnitResultRefresh.Name = "btnUnitResultRefresh";
			this.btnUnitResultRefresh.Text = "Refresh";
			this.btnUnitResultRefresh.ToolTipText = "Refresh";
			this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
			this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
			this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
			this.commandBarSeparator1.Name = "commandBarSeparator1";
			this.commandBarSeparator1.VisibleInOverflowMenu = false;
			this.btnUpdateHist.AccessibleDescription = "commandBarButton1";
			this.btnUpdateHist.AccessibleName = "commandBarButton1";
			this.btnUpdateHist.DisplayName = "commandBarButton1";
			this.btnUpdateHist.Image = Resources.TableSearch;
			this.btnUpdateHist.Name = "btnUpdateHist";
			this.btnUpdateHist.Text = "Edit History";
			this.btnUpdateHist.ToolTipText = "Edit History";
			this.pvLotYield.Controls.Add(this.grdLotYield);
			this.pvLotYield.ItemSize = new SizeF(140f, 28f);
			this.pvLotYield.Location = new Point(4, 4);
			this.pvLotYield.Name = "pvLotYield";
			this.pvLotYield.Size = new Size(0, 0);
			this.pvLotYield.Text = "Lot Yield";
			this.pvFailureSummary.Controls.Add(this.grdFailSummary);
			this.pvFailureSummary.ItemSize = new SizeF(140f, 28f);
			this.pvFailureSummary.Location = new Point(4, 4);
			this.pvFailureSummary.Name = "pvFailureSummary";
			this.pvFailureSummary.Size = new Size(0, 0);
			this.pvFailureSummary.Text = "Failure Summary";
			this.tableLayoutPanel1.ColumnCount = 13;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.692307f));
			this.tableLayoutPanel1.Controls.Add(this.btnRawData, 12, 0);
			this.tableLayoutPanel1.Controls.Add(this.radPanel4, 7, 0);
			this.tableLayoutPanel1.Controls.Add(this.radPanel7, 6, 0);
			this.tableLayoutPanel1.Controls.Add(this.radPanel3, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.radPanel5, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.radPanel6, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.cboReportType, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnSearch, 9, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnSave, 11, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Top;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.Size = new Size(1000, 28);
			this.tableLayoutPanel1.TabIndex = 168;
			this.tableLayoutPanel1.SetColumnSpan(this.radPanel4, 2);
			this.radPanel4.Controls.Add(this.rdoFailResult);
			this.radPanel4.Controls.Add(this.rdoPassResult);
			this.radPanel4.Controls.Add(this.rdoAllResult);
			this.radPanel4.Dock = DockStyle.Fill;
			this.radPanel4.Location = new Point(535, 3);
			this.radPanel4.Name = "radPanel4";
			this.radPanel4.Padding = new Padding(3);
			this.radPanel4.Size = new Size(146, 22);
			this.radPanel4.TabIndex = 169;
			this.radPanel4.ThemeName = "CIMitarAdmin_Skin";
			this.radPanel7.Dock = DockStyle.Fill;
			this.radPanel7.Location = new Point(459, 3);
			this.radPanel7.Name = "radPanel7";
			this.radPanel7.Size = new Size(70, 22);
			this.radPanel7.TabIndex = 171;
			this.radPanel7.Text = "Test Result";
			this.radPanel7.TextAlignment = ContentAlignment.MiddleCenter;
			this.radPanel7.ThemeName = "CIMitarAdmin_Skin";
			this.tableLayoutPanel1.SetColumnSpan(this.radPanel3, 2);
			this.radPanel3.Controls.Add(this.rdoFinal);
			this.radPanel3.Controls.Add(this.rdo1st);
			this.radPanel3.Controls.Add(this.rdoAll);
			this.radPanel3.Dock = DockStyle.Fill;
			this.radPanel3.Location = new Point(307, 3);
			this.radPanel3.Name = "radPanel3";
			this.radPanel3.Padding = new Padding(3);
			this.radPanel3.Size = new Size(146, 22);
			this.radPanel3.TabIndex = 168;
			this.radPanel3.ThemeName = "CIMitarAdmin_Skin";
			this.radPanel5.Dock = DockStyle.Fill;
			this.radPanel5.Location = new Point(3, 3);
			this.radPanel5.Name = "radPanel5";
			this.radPanel5.Size = new Size(70, 22);
			this.radPanel5.TabIndex = 170;
			this.radPanel5.Text = "Type";
			this.radPanel5.TextAlignment = ContentAlignment.MiddleCenter;
			this.radPanel5.ThemeName = "CIMitarAdmin_Skin";
			this.radPanel6.Dock = DockStyle.Fill;
			this.radPanel6.Location = new Point(231, 3);
			this.radPanel6.Name = "radPanel6";
			this.radPanel6.Size = new Size(70, 22);
			this.radPanel6.TabIndex = 170;
			this.radPanel6.Text = "Test Type";
			this.radPanel6.TextAlignment = ContentAlignment.MiddleCenter;
			this.radPanel6.ThemeName = "CIMitarAdmin_Skin";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.pvMain);
			base.Controls.Add(this.radSplitContainer1);
			base.Controls.Add(this.tableLayoutPanel1);
			base.Name = "UnitDataResult";
			base.Size = new Size(1000, 613);
			((ISupportInitialize)this.btnRawData).EndInit();
			((ISupportInitialize)this.btnSearch).EndInit();
			((ISupportInitialize)this.rdoPassResult).EndInit();
			((ISupportInitialize)this.rdoAllResult).EndInit();
			((ISupportInitialize)this.rdoFailResult).EndInit();
			((ISupportInitialize)this.btnSave).EndInit();
			((ISupportInitialize)this.rdo1st).EndInit();
			((ISupportInitialize)this.rdoFinal).EndInit();
			((ISupportInitialize)this.rdoAll).EndInit();
			((ISupportInitialize)this.cboReportType).EndInit();
			((ISupportInitialize)this.grdUnit.MasterTemplate).EndInit();
			((ISupportInitialize)this.grdUnit).EndInit();
			((ISupportInitialize)this.grdFailSummary.MasterTemplate).EndInit();
			((ISupportInitialize)this.grdFailSummary).EndInit();
			((ISupportInitialize)this.grdUnitDetail.MasterTemplate).EndInit();
			((ISupportInitialize)this.grdUnitDetail).EndInit();
			((ISupportInitialize)this.grdLotYield.MasterTemplate).EndInit();
			((ISupportInitialize)this.grdLotYield).EndInit();
			((ISupportInitialize)this.radSplitContainer1).EndInit();
			this.radSplitContainer1.ResumeLayout(false);
			((ISupportInitialize)this.splitPanel1).EndInit();
			this.splitPanel1.ResumeLayout(false);
			((ISupportInitialize)this.radPanel1).EndInit();
			((ISupportInitialize)this.splitPanel2).EndInit();
			((ISupportInitialize)this.pvMain).EndInit();
			this.pvMain.ResumeLayout(false);
			this.pvUnitTestResult.ResumeLayout(false);
			this.pvUnitTestResult.PerformLayout();
			((ISupportInitialize)this.radCommandBar1).EndInit();
			this.pvLotYield.ResumeLayout(false);
			this.pvFailureSummary.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((ISupportInitialize)this.radPanel4).EndInit();
			this.radPanel4.ResumeLayout(false);
			this.radPanel4.PerformLayout();
			((ISupportInitialize)this.radPanel7).EndInit();
			((ISupportInitialize)this.radPanel3).EndInit();
			this.radPanel3.ResumeLayout(false);
			this.radPanel3.PerformLayout();
			((ISupportInitialize)this.radPanel5).EndInit();
			((ISupportInitialize)this.radPanel6).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000094 RID: 148
		private DataTable _dtSearchData = new DataTable();

		// Token: 0x04000095 RID: 149
		private DataTable _dtOriSearchData = new DataTable();

		// Token: 0x04000096 RID: 150
		private List<string> _lstChangeCellIdx = new List<string>();

		// Token: 0x04000097 RID: 151
		private CommonMethod cm = new CommonMethod();

		// Token: 0x04000098 RID: 152
		private Thread _thread;

		// Token: 0x04000099 RID: 153
		private BarPrograss _barPrograss;

		// Token: 0x0400009A RID: 154
		private CIMitarAccount _userAccount;

		// Token: 0x0400009B RID: 155
		private CommonQuery _commonQry;

		// Token: 0x0400009C RID: 156
		private string _option = string.Empty;

		// Token: 0x0400009D RID: 157
		private DateTime _startTime;

		// Token: 0x0400009E RID: 158
		private DateTime _endTime;

		// Token: 0x0400009F RID: 159
		private string _lot = string.Empty;

		// Token: 0x040000A0 RID: 160
		private string _sn = string.Empty;

		// Token: 0x040000A1 RID: 161
		private string _product = string.Empty;

		// Token: 0x040000A2 RID: 162
		private DataTable _lotList = new DataTable();

		// Token: 0x040000A3 RID: 163
		private IContainer components = null;

		// Token: 0x040000A4 RID: 164
		private RadGridView grdUnit;

		// Token: 0x040000A5 RID: 165
		private SaveFileDialog saveFileDialog;

		// Token: 0x040000A6 RID: 166
		private RadRadioButton rdoFinal;

		// Token: 0x040000A7 RID: 167
		private RadRadioButton rdoAll;

		// Token: 0x040000A8 RID: 168
		private RadButton btnSave;

		// Token: 0x040000A9 RID: 169
		private RadRadioButton rdoPassResult;

		// Token: 0x040000AA RID: 170
		private RadRadioButton rdoAllResult;

		// Token: 0x040000AB RID: 171
		private RadRadioButton rdoFailResult;

		// Token: 0x040000AC RID: 172
		private RadButton btnSearch;

		// Token: 0x040000AD RID: 173
		private RadGridView grdLotYield;

		// Token: 0x040000AE RID: 174
		private RadCheckedDropDownList cboReportType;

		// Token: 0x040000AF RID: 175
		private RadGridView grdUnitDetail;

		// Token: 0x040000B0 RID: 176
		private RadRadioButton rdo1st;

		// Token: 0x040000B1 RID: 177
		private RadGridView grdFailSummary;

		// Token: 0x040000B2 RID: 178
		private RadButton btnRawData;

		// Token: 0x040000B3 RID: 179
		private RadSplitContainer radSplitContainer1;

		// Token: 0x040000B4 RID: 180
		private SplitPanel splitPanel1;

		// Token: 0x040000B5 RID: 181
		private SplitPanel splitPanel2;

		// Token: 0x040000B6 RID: 182
		private RadPanel radPanel1;

		// Token: 0x040000B7 RID: 183
		private TableLayoutPanel tableLayoutPanel1;

		// Token: 0x040000B8 RID: 184
		private RadPanel radPanel4;

		// Token: 0x040000B9 RID: 185
		private RadPanel radPanel3;

		// Token: 0x040000BA RID: 186
		private RadPanel radPanel5;

		// Token: 0x040000BB RID: 187
		private RadPanel radPanel7;

		// Token: 0x040000BC RID: 188
		private RadPanel radPanel6;

		// Token: 0x040000BD RID: 189
		private RadPageView pvMain;

		// Token: 0x040000BE RID: 190
		private RadPageViewPage pvLotYield;

		// Token: 0x040000BF RID: 191
		private RadPageViewPage pvFailureSummary;

		// Token: 0x040000C0 RID: 192
		private RadPageViewPage pvUnitTestResult;

		// Token: 0x040000C1 RID: 193
		private RadCommandBar radCommandBar1;

		// Token: 0x040000C2 RID: 194
		private CommandBarRowElement cbUnitResult;

		// Token: 0x040000C3 RID: 195
		private CommandBarStripElement cbsUnitResult;

		// Token: 0x040000C4 RID: 196
		private CommandBarButton btnUnitResultDelete;

		// Token: 0x040000C5 RID: 197
		private CommandBarButton btnUnitResultSave;

		// Token: 0x040000C6 RID: 198
		private CommandBarButton btnUnitResultRefresh;

		// Token: 0x040000C7 RID: 199
		private CommandBarSeparator commandBarSeparator1;

		// Token: 0x040000C8 RID: 200
		private CommandBarButton btnUpdateHist;
	}
}
