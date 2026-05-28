using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.SBLAnalysisModule.Class;
using Amkor.CADModules.SBLAnalysisModule.Properties;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.SBLAnalysisModule.View
{
	// Token: 0x0200001B RID: 27
	public partial class ResultView : Form
	{
		// Token: 0x060000AF RID: 175 RVA: 0x0000B0F6 File Offset: 0x000092F6
		public ResultView()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000B128 File Offset: 0x00009328
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000B145 File Offset: 0x00009345
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

		// Token: 0x060000B2 RID: 178 RVA: 0x0000B155 File Offset: 0x00009355
		private void ResultView_Load(object sender, EventArgs e)
		{
			this.init();
			this.viewGrid();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000B168 File Offset: 0x00009368
		private void init()
		{
			this.gridResultList.ColumnsCount = 4;
			this.gridResultList.RowsCount = 1;
			this.gridResultList.FixedRows = 1;
			this.gridResultList[0, 0] = new GridInfo.ColHeader("BinNo");
			this.gridResultList[0, 1] = new GridInfo.ColHeader("Type");
			this.gridResultList[0, 2] = new GridInfo.ColHeader("Limit");
			this.gridResultList[0, 3] = new GridInfo.ColHeader("Result");
			this.gridInfo.SetColumnCellColor(this.gridResultList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridResultList);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000B234 File Offset: 0x00009434
		private void viewGrid()
		{
			this.gridResultList.RowsCount = 1;
			if (this.slResult != null)
			{
				for (int i = 0; i < this.slResult.Count; i++)
				{
					Bin bin = (Bin)this.slResult.GetByIndex(i);
					this.gridResultList.Rows.Insert(i + 1);
					this.gridResultList[i + 1, 0] = new Cell(bin.BinNo);
					this.gridResultList[i + 1, 1] = new Cell(bin.LimitType);
					this.gridResultList[i + 1, 2] = new Cell(bin.Limit);
					this.gridResultList[i + 1, 3] = new Cell(bin.Result);
				}
				this.gridInfo.AutoSetGrid(this.gridResultList);
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000B327 File Offset: 0x00009527
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000B331 File Offset: 0x00009531
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000B351 File Offset: 0x00009551
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000B371 File Offset: 0x00009571
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000B391 File Offset: 0x00009591
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x040000A8 RID: 168
		public SortedList slResult = new SortedList();

		// Token: 0x040000A9 RID: 169
		private GridInfo gridInfo = new GridInfo();
	}
}
