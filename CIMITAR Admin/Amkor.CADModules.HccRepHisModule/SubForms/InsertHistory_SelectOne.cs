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

namespace Amkor.CADModules.HccRepHisModule.SubForms
{
	// Token: 0x02000009 RID: 9
	public partial class InsertHistory_SelectOne : Form
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00003CAF File Offset: 0x00001EAF
		public InsertHistory_SelectOne(List<CRepairHistoryItem> cRepairHistoryItems)
		{
			this.InitializeComponent();
			this._cRepairHistoryItems = cRepairHistoryItems;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003CC4 File Offset: 0x00001EC4
		private void BIBoardInsert_SelectOne_Load(object sender, EventArgs e)
		{
			this.InitGridCell();
			this.SetGridInfo(this._cRepairHistoryItems);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003CD8 File Offset: 0x00001ED8
		private void BIBoardInsert_SelectOne_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003CEC File Offset: 0x00001EEC
		private void grid_BIBoard_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.grid_RepairHistoryItem.Selection.ActivePosition.Row < 0)
			{
				return;
			}
			if (this.grid_RepairHistoryItem.Selection.ActivePosition.Column < 2)
			{
				return;
			}
			int row = this.grid_RepairHistoryItem.Selection.ActivePosition.Row;
			string a = this.grid_RepairHistoryItem[row, 2].ToString().Trim();
			foreach (CRepairHistoryItem crepairHistoryItem in this._cRepairHistoryItems)
			{
				if (a == crepairHistoryItem.strBarcode)
				{
					this._selItem = crepairHistoryItem;
					break;
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003DC8 File Offset: 0x00001FC8
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

		// Token: 0x0600003D RID: 61 RVA: 0x00003F9C File Offset: 0x0000219C
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

		// Token: 0x0600003E RID: 62 RVA: 0x00003FEC File Offset: 0x000021EC
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

		// Token: 0x0600003F RID: 63 RVA: 0x00004050 File Offset: 0x00002250
		private void SetGridInfo(List<CRepairHistoryItem> cRepairHistoryItems)
		{
			if (cRepairHistoryItems.Count == 0)
			{
				return;
			}
			this.ResetGrid(this.grid_RepairHistoryItem);
			int num = 1;
			string[] gridHeaders = "NO,CUSTOMER,BARCODE,SERIAL NO,BOARD".Split(new char[]
			{
				','
			});
			this.SetHeaderInfo(gridHeaders, this.grid_RepairHistoryItem);
			try
			{
				if (cRepairHistoryItems.Count != 0)
				{
					foreach (CRepairHistoryItem crepairHistoryItem in cRepairHistoryItems)
					{
						this.grid_RepairHistoryItem.Rows.Insert(num);
						this.grid_RepairHistoryItem[num, 0] = new SourceGrid.Cells.Cell(num);
						this.grid_RepairHistoryItem[num, 0].View = this.cell_center1;
						this.grid_RepairHistoryItem[num, 1] = new SourceGrid.Cells.Cell(crepairHistoryItem.strCustName);
						this.grid_RepairHistoryItem[num, 1].View = this.cell_center1;
						this.grid_RepairHistoryItem[num, 2] = new SourceGrid.Cells.Cell(crepairHistoryItem.strBarcode);
						this.grid_RepairHistoryItem[num, 2].View = this.cell_center1;
						this.grid_RepairHistoryItem[num, 3] = new SourceGrid.Cells.Cell(crepairHistoryItem.strSerialNo);
						this.grid_RepairHistoryItem[num, 3].View = this.cell_center1;
						this.grid_RepairHistoryItem[num, 4] = new SourceGrid.Cells.Cell(crepairHistoryItem.strBoard);
						this.grid_RepairHistoryItem[num, 4].View = this.cell_center1;
						num++;
					}
					this.grid_RepairHistoryItem.AutoSizeCells();
					int num2 = 0;
					for (int i = 0; i < this.grid_RepairHistoryItem.Columns.Count; i++)
					{
						num2 += this.grid_RepairHistoryItem.Columns[i].Width;
					}
					base.Width = num2 + 50;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x04000025 RID: 37
		private SourceGrid.Cells.Views.Cell cell_center1;

		// Token: 0x04000026 RID: 38
		private SourceGrid.Cells.Views.Cell cell_center2;

		// Token: 0x04000027 RID: 39
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x04000028 RID: 40
		private SourceGrid.Cells.Views.Cell cell_onflag;

		// Token: 0x04000029 RID: 41
		private List<CRepairHistoryItem> _cRepairHistoryItems;

		// Token: 0x0400002A RID: 42
		public CRepairHistoryItem _selItem;
	}
}
