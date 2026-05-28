using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.RELUnitDataProcModule.CommonClass;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.RELUnitDataProcModule.UserControls
{
	// Token: 0x02000013 RID: 19
	public partial class PopUpEditHistory : RadForm
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00007EF3 File Offset: 0x000060F3
		// (set) Token: 0x06000091 RID: 145 RVA: 0x00007EFB File Offset: 0x000060FB
		public DataTable LotSn
		{
			get
			{
				return this._lotSn;
			}
			set
			{
				this._lotSn = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00007F04 File Offset: 0x00006104
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00007F0C File Offset: 0x0000610C
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

		// Token: 0x06000094 RID: 148 RVA: 0x00007F15 File Offset: 0x00006115
		public PopUpEditHistory()
		{
			this.InitializeComponent();
			this.SetEvent();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00007F4C File Offset: 0x0000614C
		private void SetEvent()
		{
			base.Load += this.PopUpEditaHistory_Load;
			this.grdUnitHist.ViewCellFormatting += this.GrdCommon_ViewCellFormatting;
			this.btnSearch.Click += this.BtnSearch_Click;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00007F9D File Offset: 0x0000619D
		private void PopUpEditaHistory_Load(object sender, EventArgs e)
		{
			this.InitControl();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00007FA8 File Offset: 0x000061A8
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

		// Token: 0x06000098 RID: 152 RVA: 0x0000801F File Offset: 0x0000621F
		private void BtnSearch_Click(object sender, EventArgs e)
		{
			this.SearchData();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000802C File Offset: 0x0000622C
		private void InitControl()
		{
			this.dtmStartTime.Value = DateTime.Now.AddDays(-7.0);
			this.dtmEndTime.Value = DateTime.Now.AddDays(1.0);
			this.InitGrid();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00008088 File Offset: 0x00006288
		private void InitGrid()
		{
			this.grdUnitHist.MasterTemplate.MultiSelect = true;
			this.grdUnitHist.AllowAddNewRow = false;
			this.grdUnitHist.ShowGroupPanel = false;
			this.grdUnitHist.EnableFiltering = true;
			this.grdUnitHist.EnableSorting = true;
			this.grdUnitHist.EnableGrouping = true;
			this.grdUnitHist.MasterView.TableHeaderRow.IsVisible = true;
			this.grdUnitHist.MasterTemplate.ShowHeaderCellButtons = true;
			this.grdUnitHist.MasterTemplate.ShowFilteringRow = true;
			this.grdUnitHist.MasterTemplate.AllowRowResize = false;
			this.grdUnitHist.MasterTemplate.AllowDeleteRow = false;
			this.grdUnitHist.SelectionMode = GridViewSelectionMode.FullRowSelect;
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("eventTime", "EventTime", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("activity", "Activity", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("modifier", "modifier", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("unitdataid", "LotID", false, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("lotid", "LotID", false, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("lot", "Lot", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("dcc", "Dcc", false, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("sn", "SN", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("starttime", "StartTime", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("endtime", "EndTime", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("testtime", "TestTime", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("product", "Product", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("operation", "Operation", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("test_seq", "TestType", true, 125, true, true, false, "Decimal"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("program", "Program", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("tester", "Tester", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("site", "site Number", true, 125, true, true, false, "Decimal"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("result", "PASS/FAIL", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("ecid", "ECID", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("fail_desc", "Fail Desc", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("measure_result", "1st Failing Test", true, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("retestcode", "retestcode", false, 125, true, true, false, "Decimal"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("hbin", "hbin", false, 125, true, true, false, "TextBox"));
			this.grdUnitHist.Columns.Add(this.cm.SetGridViewColumn("sbin", "sbin", false, 125, true, true, false, "TextBox"));
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000085F0 File Offset: 0x000067F0
		private void SearchData()
		{
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Loading data....");
			this._barPrograss.setValue(0);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			this._barPrograss.setMax(100);
			DataTable dataTable = new DataTable();
			int num = (this.dtmEndTime.Value.Year - this.dtmStartTime.Value.Year) * 12 + (this.dtmEndTime.Value.Month - this.dtmStartTime.Value.Month) + 1;
			DateTime dateTime = this.dtmStartTime.Value;
			DateTime dateTime2 = this.dtmStartTime.Value;
			for (int i = 0; i < num; i++)
			{
				this._barPrograss.setValue(this._barPrograss.ProgressBarValue + 70 / num);
				dateTime = dateTime2;
				dateTime2 = Convert.ToDateTime(dateTime.AddMonths(1).ToString("yyyy-MM-01"));
				bool flag = dateTime2 > this.dtmEndTime.Value;
				if (flag)
				{
					dateTime2 = this.dtmEndTime.Value;
				}
				string arg = string.Join(",", new string[]
				{
					this.txtLot.Text
				});
				string arg2 = string.Join(",", new string[]
				{
					this.txtSN.Text
				});
				string text = "\r\n                                    EXEC [CIMitar_Unit].[dbo].[ADMIN_UNIT_RELUnitDataHIST_Select] @startTime = @VstartTime@\r\n                                                                                                , @endTime = @VendTime@\r\n                                                                                                , @lot = @Vlot@\r\n                                                                                                , @sn = @Vsn@\r\n                                   ";
				text = text.Replace("@VstartTime@", string.Format("'{0}'", dateTime.ToString("yyyy-MM-dd")));
				text = text.Replace("@VendTime@", string.Format("'{0}'", dateTime2.ToString("yyyy-MM-dd")));
				text = text.Replace("@Vlot@", string.Format("'{0}'", arg));
				text = text.Replace("@Vsn@", string.Format("'{0}'", arg2));
				DataSet dataSet = this._commonQry.queryCall(text);
				bool flag2 = dataTable.Columns.Count == 0;
				if (flag2)
				{
					dataSet.Tables[0].Clone();
				}
				dataTable.Merge(dataSet.Tables[0]);
			}
			this.cm.GridViewSetDataSource(this.grdUnitHist, dataTable);
			this._barPrograss.setValue(100);
			Thread.Sleep(100);
			bool flag3 = this._barPrograss != null;
			if (flag3)
			{
				this._barPrograss._ischeck = true;
			}
			this._barPrograss = null;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000088A2 File Offset: 0x00006AA2
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x04000078 RID: 120
		private CommonMethod cm = new CommonMethod();

		// Token: 0x04000079 RID: 121
		private BarPrograss _barPrograss = new BarPrograss();

		// Token: 0x0400007A RID: 122
		private Thread _thread;

		// Token: 0x0400007B RID: 123
		private DataTable _lotSn;

		// Token: 0x0400007C RID: 124
		private CommonQuery _commonQry;
	}
}
