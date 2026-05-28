using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Control;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000048 RID: 72
	public partial class SlotBlackListClustered : Form
	{
		// Token: 0x06000337 RID: 823 RVA: 0x00051229 File Offset: 0x0004F429
		public SlotBlackListClustered(string targetDate, SortedList slTyle)
		{
			this.slSlotType = slTyle;
			this.targetDate = targetDate;
			this.InitializeComponent();
			base.Shown += this.initSlotBlackListClustered;
			base.Shown += this.getSlotInfoByTester;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0005126C File Offset: 0x0004F46C
		private void saveExcel(Grid grid)
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

		// Token: 0x06000339 RID: 825 RVA: 0x00051430 File Offset: 0x0004F630
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0005143E File Offset: 0x0004F63E
		private void SlotBlackListClustered_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.gridInfo = new GridInfo();
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0005145C File Offset: 0x0004F65C
		public void initSlotBlackListClustered(object sender, EventArgs e)
		{
			this.gridSlotBlackList.ColumnsCount = 5 + this.slSlotType.Count;
			this.gridSlotBlackList.RowsCount = 1;
			this.gridSlotBlackList.FixedRows = 1;
			int num = 0;
			this.gridSlotBlackList[0, num] = new GridInfo.ColHeader("No", true);
			num++;
			this.gridSlotBlackList[0, num] = new GridInfo.ColHeader("TesterName", false);
			num++;
			this.gridSlotBlackList[0, num] = new GridInfo.ColHeader("TesterNo", false);
			num++;
			this.gridSlotBlackList[0, num] = new GridInfo.ColHeader("TesterSubNo", false);
			num++;
			for (int i = 0; i < this.slSlotType.Count; i++)
			{
				this.strName = this.slSlotType.GetKey(i).ToString();
				this.gridSlotBlackList[0, num] = new GridInfo.ColHeader(this.strName, false);
				num++;
			}
			this.gridSlotBlackList[0, num] = new GridInfo.ColHeader("Total", true);
			num++;
			this.gridInfo.SetColumnCellColor(this.gridSlotBlackList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridSlotBlackList);
			this.gridSlotBlackList.Dock = DockStyle.Fill;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x000515B0 File Offset: 0x0004F7B0
		public void getSlotInfoByTester(object sender, EventArgs e)
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetSlotInfoByTester] @targetdate  = '" + this.targetDate + "'";
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			this.textBox1.Text = this.targetDate;
			if (dataSet.Tables.Count > 0)
			{
				string text = string.Empty;
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this.gridSlotBlackList.Rows.Insert(this.gridSlotBlackList.RowsCount);
					this.gridSlotBlackList[i + 1, 0] = new Cell((i + 1).ToString());
					text = dataSet.Tables[0].Rows[i]["testername"].ToString();
					string[] array = text.Replace("#", "-").Split(new char[]
					{
						'-'
					});
					this.gridSlotBlackList[i + 1, 1] = new Cell(dataSet.Tables[0].Rows[i]["testername"].ToString());
					this.gridSlotBlackList[i + 1, 2] = new Cell(array.GetValue(1));
					this.gridSlotBlackList[i + 1, 3] = new Cell(array.GetValue(2));
					this.gridSlotBlackList[i + 1, 4] = new Cell(dataSet.Tables[0].Rows[i]["err1"].ToString());
					this.gridSlotBlackList[i + 1, 5] = new Cell(dataSet.Tables[0].Rows[i]["err2"].ToString());
					this.gridSlotBlackList[i + 1, 6] = new Cell(dataSet.Tables[0].Rows[i]["err3"].ToString());
					this.gridSlotBlackList[i + 1, 7] = new Cell(dataSet.Tables[0].Rows[i]["err4"].ToString());
					this.gridSlotBlackList[i + 1, 8] = new Cell(dataSet.Tables[0].Rows[i]["total"].ToString());
				}
			}
			this.gridInfo.AutoSetGrid(this.gridSlotBlackList);
			this.gridSlotBlackList.Update();
			this.gridSlotBlackList.BringToFront();
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00051873 File Offset: 0x0004FA73
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			this.panel1.AutoScroll = true;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00051881 File Offset: 0x0004FA81
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00051883 File Offset: 0x0004FA83
		private void cmdSlotExcel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.gridSlotBlackList);
		}

		// Token: 0x04000564 RID: 1380
		public FactorySettings _factorySetting;

		// Token: 0x04000565 RID: 1381
		public CIMitarAccount _cimitarUser;

		// Token: 0x04000566 RID: 1382
		private string targetDate;

		// Token: 0x04000567 RID: 1383
		private string strName;

		// Token: 0x04000568 RID: 1384
		private QueryMgr queryMgr;

		// Token: 0x04000569 RID: 1385
		private GridInfo gridInfo;

		// Token: 0x0400056A RID: 1386
		private SortedList slSlotType;

		// Token: 0x0400056B RID: 1387
		private BarPrograss _barPrograss;

		// Token: 0x0400056C RID: 1388
		private Thread _thread;
	}
}
