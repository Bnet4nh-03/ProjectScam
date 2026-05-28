using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000050 RID: 80
	public partial class TestHistory : Form
	{
		// Token: 0x060003B8 RID: 952 RVA: 0x00057E4C File Offset: 0x0005604C
		public TestHistory()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x00057E7B File Offset: 0x0005607B
		// (set) Token: 0x060003BA RID: 954 RVA: 0x00057E88 File Offset: 0x00056088
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

		// Token: 0x060003BB RID: 955 RVA: 0x00057E96 File Offset: 0x00056096
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00057EA4 File Offset: 0x000560A4
		private void ResultView_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.getTypeDefinitionList("Site", this.cmbSite);
			this.getTypeDefinitionList("CarrierMgrType", this.cmbType);
			this.initGrid();
			this.getHistoryData();
			this.txtBarcode.Text = this.carrierInfo.Barcode;
			this.cmbSite.Text = this.carrierInfo.Site;
			this.cmbType.Text = this.carrierInfo.Type;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00057F34 File Offset: 0x00056134
		private DataSet getTypeDefinitionList(string sTypeName, ComboBox comboBox)
		{
			DataSet dataSet = new DataSet();
			try
			{
				comboBox.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					comboBox.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return dataSet;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00057FE4 File Offset: 0x000561E4
		private void initGrid()
		{
			this.gridTestHistory.ColumnsCount = 7;
			this.gridTestHistory.RowsCount = 2;
			this.gridTestHistory.FixedRows = 2;
			this.gridTestHistory.FixedColumns = 1;
			this.gridTestHistory[0, 0] = new GridInfo.ColHeader("No", false);
			this.gridTestHistory[0, 0].RowSpan = 2;
			this.gridTestHistory[0, 1] = new GridInfo.ColHeader("Softbin Status", false);
			this.gridTestHistory[0, 1].ColumnSpan = 2;
			this.gridTestHistory[0, 3] = new GridInfo.ColHeader("Last Test Location", false);
			this.gridTestHistory[0, 3].ColumnSpan = 2;
			this.gridTestHistory[0, 5] = new GridInfo.ColHeader("Test Date", false);
			this.gridTestHistory[0, 5].ColumnSpan = 2;
			this.gridTestHistory[1, 1] = new GridInfo.ColHeader("Softbin Nmae", false);
			this.gridTestHistory[1, 2] = new GridInfo.ColHeader("Status", false);
			this.gridTestHistory[1, 3] = new GridInfo.ColHeader("System Name", false);
			this.gridTestHistory[1, 4] = new GridInfo.ColHeader("Location", false);
			this.gridTestHistory[1, 5] = new GridInfo.ColHeader("Start", false);
			this.gridTestHistory[1, 6] = new GridInfo.ColHeader("End", false);
			this.gridInfo.SetColumnCellColor(this.gridTestHistory, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.SetColumnCellColor(this.gridTestHistory, 1, this.gridInfo.CellColor.cell_gray_center);
			this.gridTestHistory.Columns[0].Width = 40;
			this.gridTestHistory.Columns[1].Width = 150;
			this.gridTestHistory.Columns[2].Width = 50;
			this.gridTestHistory.Columns[3].Width = 80;
			this.gridTestHistory.Columns[4].Width = 80;
			this.gridTestHistory.Columns[5].Width = 150;
			this.gridTestHistory.Columns[6].Width = 150;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00058254 File Offset: 0x00056454
		private void getHistoryData()
		{
			try
			{
				this.gridTestHistory.RowsCount = 2;
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Search Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetCarrierBinHistory]  @carrierid = '",
					this.carrierInfo.CarrierId,
					"', @site = '",
					this.carrierInfo.Site,
					"', @type = '",
					this.carrierInfo.Type,
					"'"
				});
				DataSet dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					this._barPrograss.setMax(dataSet.Tables[0].Rows.Count);
					int num = 2;
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.gridTestHistory.Rows.Insert(num);
						this.gridTestHistory[num, 0] = new Cell((i + 1).ToString());
						this.gridTestHistory[num, 1] = new Cell(dataSet.Tables[0].Rows[i]["sbinname"].ToString());
						this.gridTestHistory[num, 2] = new Cell(dataSet.Tables[0].Rows[i]["testresult"].ToString());
						this.gridTestHistory[num, 3] = new Cell(dataSet.Tables[0].Rows[i]["testername"].ToString());
						this.gridTestHistory[num, 4] = new Cell(dataSet.Tables[0].Rows[i]["location"].ToString());
						this.gridTestHistory[num, 5] = new Cell(dataSet.Tables[0].Rows[i]["starttime"].ToString());
						this.gridTestHistory[num, 6] = new Cell(dataSet.Tables[0].Rows[i]["endtime"].ToString());
						num++;
						this._barPrograss.setValue(i + 1);
					}
				}
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
				ex.Message.ToString();
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000585DC File Offset: 0x000567DC
		private void cmdSearch_Click(object sender, EventArgs e)
		{
			this.carrierInfo.Type = this.cmbType.Text;
			this.carrierInfo.Site = this.cmbSite.Text;
			this.getHistoryData();
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00058610 File Offset: 0x00056810
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00058618 File Offset: 0x00056818
		private void cmdSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00058635 File Offset: 0x00056835
		private void cmdSearch_MouseLeave(object sender, EventArgs e)
		{
			this.cmdSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00058652 File Offset: 0x00056852
		private void cmdSearch_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdSearch.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0005866F File Offset: 0x0005686F
		private void cmdSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0005867C File Offset: 0x0005687C
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00058699 File Offset: 0x00056899
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x000586B6 File Offset: 0x000568B6
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x000586D3 File Offset: 0x000568D3
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x040005FC RID: 1532
		public FactorySettings _factorySetting;

		// Token: 0x040005FD RID: 1533
		public CIMitarAccount _cimitarUser;

		// Token: 0x040005FE RID: 1534
		private QueryMgr queryMgr;

		// Token: 0x040005FF RID: 1535
		private Thread _thread;

		// Token: 0x04000600 RID: 1536
		private BarPrograss _barPrograss;

		// Token: 0x04000601 RID: 1537
		public CarrierInfo carrierInfo = new CarrierInfo();

		// Token: 0x04000602 RID: 1538
		public string sType = string.Empty;

		// Token: 0x04000603 RID: 1539
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000604 RID: 1540
		private ContextMenu menuGrid;
	}
}
