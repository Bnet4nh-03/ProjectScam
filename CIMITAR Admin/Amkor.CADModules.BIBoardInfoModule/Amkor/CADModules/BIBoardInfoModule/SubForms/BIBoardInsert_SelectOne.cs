using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DATA;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000021 RID: 33
	public partial class BIBoardInsert_SelectOne : Form
	{
		// Token: 0x06000090 RID: 144 RVA: 0x0000C5D1 File Offset: 0x0000A7D1
		public BIBoardInsert_SelectOne(List<CBIBoardInfo> bibInfos)
		{
			this.InitializeComponent();
			this._bibInfos = bibInfos;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000C5E6 File Offset: 0x0000A7E6
		private void BIBoardInsert_SelectOne_Load(object sender, EventArgs e)
		{
			this.InitGridCell();
			this.SetGridInfo(this._bibInfos);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000055FE File Offset: 0x000037FE
		private void BIBoardInsert_SelectOne_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000C5FC File Offset: 0x0000A7FC
		private void grid_BIBoard_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.grid_BIBoard.Selection.ActivePosition.Row < 0)
			{
				return;
			}
			if (this.grid_BIBoard.Selection.ActivePosition.Column < 2)
			{
				return;
			}
			int row = this.grid_BIBoard.Selection.ActivePosition.Row;
			string a = this.grid_BIBoard[row, 1].ToString().Trim();
			foreach (CBIBoardInfo cbiboardInfo in this._bibInfos)
			{
				if (a == cbiboardInfo.strBarcode)
				{
					this._selBibInfo = cbiboardInfo;
					break;
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000C6D8 File Offset: 0x0000A8D8
		private void InitGridCell()
		{
			Color color = Color.FromArgb(255, 255, 255);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			this.cell_center1 = new SourceGrid.Cells.Views.Cell();
			this.cell_center1.BackColor = color;
			this.cell_center1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center1.Border = rectangleBorder;
			this.cell_center1.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center1.ImageStretch = false;
			Color color2 = Color.FromArgb(223, 230, 233);
			RectangleBorder rectangleBorder2 = new RectangleBorder(new BorderLine(color2), new BorderLine(color2));
			this.cell_center2 = new SourceGrid.Cells.Views.Cell();
			this.cell_center2.BackColor = color2;
			this.cell_center2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center2.Border = rectangleBorder2;
			this.cell_center2.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center2.ImageStretch = false;
			Color color3 = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder3 = new RectangleBorder(new BorderLine(color3), new BorderLine(color3));
			this.cell_header1 = new SourceGrid.Cells.Views.Cell();
			this.cell_header1.BackColor = color3;
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header1.Border = rectangleBorder3;
			Color color4 = Color.FromArgb(253, 203, 110);
			RectangleBorder rectangleBorder4 = new RectangleBorder(new BorderLine(color4), new BorderLine(color4));
			this.cell_onflag = new SourceGrid.Cells.Views.Cell();
			this.cell_onflag.BackColor = color4;
			this.cell_onflag.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_onflag.Border = rectangleBorder4;
			this.cell_onflag.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_onflag.ImageStretch = false;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000C8AC File Offset: 0x0000AAAC
		private void ResetGrid(Grid grid)
		{
			for (int i = grid.RowsCount - 1; i >= 0; i--)
			{
				grid.Rows.Remove(i);
			}
			grid.Selection.EnableMultiSelection = false;
			grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grid.CustomSort = true;
			grid.SelectionMode = GridSelectionMode.Row;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000C8FC File Offset: 0x0000AAFC
		private void SetHeaderInfo(string[] gridHeaders, Grid grid)
		{
			grid.ColumnsCount = gridHeaders.Length;
			grid.FixedRows = 1;
			grid.FixedColumns = 0;
			grid.Rows.Insert(0);
			for (int i = 0; i < gridHeaders.Length; i++)
			{
				grid[0, i] = new SourceGrid.Cells.ColumnHeader(gridHeaders[i]);
				grid[0, i].View = this.cell_header1;
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000C960 File Offset: 0x0000AB60
		private void SetGridInfo(List<CBIBoardInfo> cBibInfos)
		{
			if (cBibInfos.Count == 0)
			{
				return;
			}
			this.ResetGrid(this.grid_BIBoard);
			int num = 1;
			string[] gridHeaders = "NO,BARCODE,BIB NO,LOCATION,CUSTOMER,DEVICE".Split(new char[]
			{
				','
			});
			this.SetHeaderInfo(gridHeaders, this.grid_BIBoard);
			try
			{
				if (cBibInfos.Count != 0)
				{
					foreach (CBIBoardInfo cbiboardInfo in cBibInfos)
					{
						this.grid_BIBoard.Rows.Insert(num);
						this.grid_BIBoard[num, 0] = new SourceGrid.Cells.Cell(num);
						this.grid_BIBoard[num, 0].View = this.cell_center1;
						this.grid_BIBoard[num, 1] = new SourceGrid.Cells.Cell(cbiboardInfo.strBarcode);
						this.grid_BIBoard[num, 1].View = this.cell_center1;
						this.grid_BIBoard[num, 2] = new SourceGrid.Cells.Cell(cbiboardInfo.strBibNo);
						this.grid_BIBoard[num, 2].View = this.cell_center1;
						this.grid_BIBoard[num, 3] = new SourceGrid.Cells.Cell(cbiboardInfo.strLocation);
						this.grid_BIBoard[num, 3].View = this.cell_center1;
						this.grid_BIBoard[num, 4] = new SourceGrid.Cells.Cell(cbiboardInfo.strCustomer);
						this.grid_BIBoard[num, 4].View = this.cell_center1;
						this.grid_BIBoard[num, 5] = new SourceGrid.Cells.Cell(cbiboardInfo.strDevice);
						this.grid_BIBoard[num, 5].View = this.cell_center1;
						num++;
					}
					this.grid_BIBoard.AutoSizeCells();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x04000117 RID: 279
		private SourceGrid.Cells.Views.Cell cell_center1;

		// Token: 0x04000118 RID: 280
		private SourceGrid.Cells.Views.Cell cell_center2;

		// Token: 0x04000119 RID: 281
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x0400011A RID: 282
		private SourceGrid.Cells.Views.Cell cell_onflag;

		// Token: 0x0400011B RID: 283
		private List<CBIBoardInfo> _bibInfos;

		// Token: 0x0400011C RID: 284
		public CBIBoardInfo _selBibInfo;
	}
}
