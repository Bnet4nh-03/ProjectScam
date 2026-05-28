using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Properties;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000047 RID: 71
	public partial class ResultSocketView : Form
	{
		// Token: 0x0600032A RID: 810 RVA: 0x000506D3 File Offset: 0x0004E8D3
		public ResultSocketView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00050702 File Offset: 0x0004E902
		// (set) Token: 0x0600032C RID: 812 RVA: 0x0005070F File Offset: 0x0004E90F
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

		// Token: 0x0600032D RID: 813 RVA: 0x0005071D File Offset: 0x0004E91D
		private void ResultSocketView_Load(object sender, EventArgs e)
		{
			this.init();
			this.viewGrid();
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0005072C File Offset: 0x0004E92C
		private void init()
		{
			this.grpApply.Visible = false;
			this.gridResultList.ColumnsCount = 4;
			this.gridResultList.RowsCount = 1;
			this.gridResultList.FixedRows = 1;
			this.gridResultList[0, 0] = new GridInfo.ColHeader("Result", false);
			this.gridResultList[0, 1] = new GridInfo.ColHeader("Line", false);
			this.gridResultList[0, 2] = new GridInfo.ColHeader("Socket Barcode", false);
			this.gridResultList[0, 3] = new GridInfo.ColHeader("Failture Reason", false);
			this.gridInfo.SetColumnCellColor(this.gridResultList, 0, this.gridInfo.CellColor.cell_gray_center);
			this.gridInfo.AutoSetGrid(this.gridResultList);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x000507FC File Offset: 0x0004E9FC
		private void viewGrid()
		{
			this.gridResultList.RowsCount = 1;
			for (int i = 0; i < this.slResult.Count; i++)
			{
				CSocketInfo csocketInfo = (CSocketInfo)this.slResult.GetByIndex(i);
				this.gridResultList.Rows.Insert(this.gridResultList.RowsCount);
				this.gridResultList[i + 1, 0] = new Cell(csocketInfo.Result);
				this.gridResultList[i + 1, 1] = new Cell(csocketInfo.Line.ToString());
				this.gridResultList[i + 1, 2] = new Cell(csocketInfo.Barcode);
				this.gridResultList[i + 1, 3] = new Cell(csocketInfo.Reason);
				if (this.gridResultList[i + 1, 0].ToString() == "Fail")
				{
					for (int j = 0; j < this.gridResultList.ColumnsCount; j++)
					{
						this.gridResultList[i + 1, j].View = this.gridInfo.CellColor.cell_font_red;
					}
				}
			}
			this.gridInfo.AutoSetGrid(this.gridResultList);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00050936 File Offset: 0x0004EB36
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0005093E File Offset: 0x0004EB3E
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0005095B File Offset: 0x0004EB5B
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00050978 File Offset: 0x0004EB78
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00050995 File Offset: 0x0004EB95
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x04000555 RID: 1365
		public string sType = string.Empty;

		// Token: 0x04000556 RID: 1366
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x04000557 RID: 1367
		public SortedList slResult = new SortedList();
	}
}
