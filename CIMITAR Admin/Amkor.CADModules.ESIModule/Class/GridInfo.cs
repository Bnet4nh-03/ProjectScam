using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.ESIModule.Class
{
	// Token: 0x0200000C RID: 12
	internal class GridInfo
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000020A0 File Offset: 0x000002A0
		public GridInfo()
		{
			this.init();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020AE File Offset: 0x000002AE
		public void init()
		{
			this.CellColor = new GridInfo.CellColors();
			this.CellColor.InitGridCell();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020C8 File Offset: 0x000002C8
		public void AutoSetGrid(Grid grid)
		{
			grid.AutoSizeCells();
			int num = 0;
			int num2 = 0;
			foreach (object obj in ((IEnumerable)grid.Columns))
			{
				GridColumn gridColumn = (GridColumn)obj;
				num += gridColumn.Width;
			}
			foreach (RowInfo rowInfo in grid.Rows)
			{
				GridRow gridRow = (GridRow)rowInfo;
				num2 += gridRow.Height;
			}
			grid.Height = num2 + 2;
			grid.Width = num + 2;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002190 File Offset: 0x00000390
		public void SetColumnCellColor(Grid grid, int rowIndex, SourceGrid.Cells.Views.Cell cell)
		{
			for (int i = 0; i < grid.Columns.Count; i++)
			{
				grid[rowIndex, i].View = cell;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021C4 File Offset: 0x000003C4
		public void SetColumnCellColor(Grid grid, int rowIndex, int colIndex, SourceGrid.Cells.Views.Cell cell)
		{
			for (int i = 0; i < grid.Columns.Count; i++)
			{
				grid[rowIndex, i].View = cell;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000021F6 File Offset: 0x000003F6
		public void CreateColHeaderCheckBox(Grid grid)
		{
			this.CreateColHeaderCheckBox(grid, new System.Windows.Forms.CheckBox());
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002204 File Offset: 0x00000404
		public void CreateColHeaderCheckBox(Grid grid, System.Windows.Forms.CheckBox checkBox)
		{
			try
			{
				Rectangle rectangle = grid.PositionToRectangle(new Position(0, 0));
				rectangle.Offset(8, 4);
				checkBox.Size = new Size(15, 15);
				checkBox.BackColor = Color.Transparent;
				checkBox.Location = rectangle.Location;
				checkBox.CheckedChanged += this.checkBox_CheckedChanged;
				grid.Controls.Add(checkBox);
				grid.Columns[0].MinimalWidth = 30;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022A4 File Offset: 0x000004A4
		public void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
				if (((Grid)checkBox.Parent).RowsCount > 0)
				{
					for (int i = 1; i < ((Grid)checkBox.Parent).RowsCount; i++)
					{
						((Grid)checkBox.Parent)[i, 0].Value = checkBox.Checked;
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x04000069 RID: 105
		public GridInfo.CellColors CellColor;

		// Token: 0x0200000D RID: 13
		public class CellColors
		{
			// Token: 0x06000014 RID: 20 RVA: 0x00002334 File Offset: 0x00000534
			public void InitGridCell()
			{
				this.cell_gray_right = new SourceGrid.Cells.Views.Cell();
				this.cell_gray_right.BackColor = Color.FromArgb(224, 224, 224);
				this.cell_gray_right.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
				this.cell_gray_center = new SourceGrid.Cells.Views.Cell();
				this.cell_gray_center.BackColor = Color.FromArgb(224, 224, 224);
				this.cell_gray_center.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				this.cell_total = new SourceGrid.Cells.Views.Cell();
				this.cell_total.BackColor = Color.FromArgb(224, 224, 224);
				this.cell_total.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
				this.cell_green = new SourceGrid.Cells.Views.Cell();
				this.cell_green.BackColor = Color.FromArgb(170, 235, 130);
				this.cell_green.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
				this.cell_right = new SourceGrid.Cells.Views.Cell();
				this.cell_right.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
				this.cell_left = new SourceGrid.Cells.Views.Cell();
				this.cell_left.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
				this.cell_limit = new SourceGrid.Cells.Views.Cell();
				this.cell_limit.BackColor = Color.FromArgb(255, 192, 203);
				this.cell_limit.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
				this.cell_header1 = new SourceGrid.Cells.Views.Cell();
				this.cell_header1.BackColor = Color.FromArgb(130, 179, 237);
				this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				this.cell_header2 = new SourceGrid.Cells.Views.Cell();
				this.cell_header2.BackColor = Color.FromArgb(150, 199, 237);
				this.cell_header2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				this.cell_header3 = new SourceGrid.Cells.Views.Cell();
				this.cell_header3.BackColor = Color.FromArgb(94, 199, 94);
				this.cell_header3.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				this.cell_header4 = new SourceGrid.Cells.Views.Cell();
				this.cell_header4.BackColor = Color.FromArgb(119, 199, 119);
				this.cell_header4.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				this.cell_header5 = new SourceGrid.Cells.Views.Cell();
				this.cell_header5.BackColor = Color.FromArgb(245, 120, 120);
				this.cell_header5.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				this.cell_header6 = new SourceGrid.Cells.Views.Cell();
				this.cell_header6.BackColor = Color.FromArgb(240, 170, 170);
				this.cell_header6.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				this.cell_header7 = new SourceGrid.Cells.Views.Cell();
				this.cell_header7.BackColor = Color.FromArgb(255, 128, 0);
				this.cell_header7.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				this.cell_font_blue = new SourceGrid.Cells.Views.Cell();
				this.cell_font_blue.ForeColor = Color.FromArgb(255, 0, 0, 255);
				this.cell_font_blue.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
				this.cell_font_red = new SourceGrid.Cells.Views.Cell();
				this.cell_font_red.ForeColor = Color.FromArgb(255, 255, 0, 0);
				this.cell_font_red.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
				this.cell_palegreen = new SourceGrid.Cells.Views.Cell();
				this.cell_palegreen.BackColor = Color.PaleGreen;
				this.cell_palegreen.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
				this.cell_lightgreen = new SourceGrid.Cells.Views.Cell();
				this.cell_lightgreen.BackColor = Color.FromArgb(146, 208, 80);
				this.cell_lightgreen.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
				this.cell_red = new SourceGrid.Cells.Views.Cell();
				this.cell_red.BackColor = Color.FromArgb(255, 0, 0);
				this.cell_red.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			}

			// Token: 0x0400006A RID: 106
			public SourceGrid.Cells.Views.Cell cell_gray_right;

			// Token: 0x0400006B RID: 107
			public SourceGrid.Cells.Views.Cell cell_gray_center;

			// Token: 0x0400006C RID: 108
			public SourceGrid.Cells.Views.Cell cell_total;

			// Token: 0x0400006D RID: 109
			public SourceGrid.Cells.Views.Cell cell_green;

			// Token: 0x0400006E RID: 110
			public SourceGrid.Cells.Views.Cell cell_right;

			// Token: 0x0400006F RID: 111
			public SourceGrid.Cells.Views.Cell cell_left;

			// Token: 0x04000070 RID: 112
			public SourceGrid.Cells.Views.Cell cell_limit;

			// Token: 0x04000071 RID: 113
			public SourceGrid.Cells.Views.Cell cell_header1;

			// Token: 0x04000072 RID: 114
			public SourceGrid.Cells.Views.Cell cell_header2;

			// Token: 0x04000073 RID: 115
			public SourceGrid.Cells.Views.Cell cell_header3;

			// Token: 0x04000074 RID: 116
			public SourceGrid.Cells.Views.Cell cell_header4;

			// Token: 0x04000075 RID: 117
			public SourceGrid.Cells.Views.Cell cell_header5;

			// Token: 0x04000076 RID: 118
			public SourceGrid.Cells.Views.Cell cell_header6;

			// Token: 0x04000077 RID: 119
			public SourceGrid.Cells.Views.Cell cell_header7;

			// Token: 0x04000078 RID: 120
			public SourceGrid.Cells.Views.Cell cell_font_blue;

			// Token: 0x04000079 RID: 121
			public SourceGrid.Cells.Views.Cell cell_font_red;

			// Token: 0x0400007A RID: 122
			public SourceGrid.Cells.Views.Cell cell_palegreen;

			// Token: 0x0400007B RID: 123
			public SourceGrid.Cells.Views.Cell cell_lightgreen;

			// Token: 0x0400007C RID: 124
			public SourceGrid.Cells.Views.Cell cell_red;
		}

		// Token: 0x0200000E RID: 14
		public class ColHeader : SourceGrid.Cells.ColumnHeader
		{
			// Token: 0x06000015 RID: 21 RVA: 0x000026E4 File Offset: 0x000008E4
			public ColHeader(object value) : base(value)
			{
				this.View = new SourceGrid.Cells.Views.ColumnHeader
				{
					Font = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Regular),
					TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter
				};
				base.AutomaticSortEnabled = false;
			}
		}
	}
}
