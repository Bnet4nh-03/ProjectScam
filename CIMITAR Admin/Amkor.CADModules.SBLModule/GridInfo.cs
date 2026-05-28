using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x0200000C RID: 12
	internal class GridInfo
	{
		// Token: 0x06000028 RID: 40 RVA: 0x000041D7 File Offset: 0x000023D7
		public GridInfo()
		{
			this.init();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000041E5 File Offset: 0x000023E5
		public void init()
		{
			this.CellColor = new GridInfo.CellColors();
			this.CellColor.InitGridCell();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004200 File Offset: 0x00002400
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

		// Token: 0x0600002B RID: 43 RVA: 0x000042C8 File Offset: 0x000024C8
		public void SetColumnCellColor(Grid grid, int rowIndex, SourceGrid.Cells.Views.Cell cell)
		{
			for (int i = 0; i < grid.Columns.Count; i++)
			{
				grid[rowIndex, i].View = cell;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000042FC File Offset: 0x000024FC
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

		// Token: 0x0600002D RID: 45 RVA: 0x0000439C File Offset: 0x0000259C
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

		// Token: 0x0600002E RID: 46 RVA: 0x00004424 File Offset: 0x00002624
		public void CheckAll(Grid grid, bool flag)
		{
			try
			{
				for (int i = 1; i < grid.RowsCount; i++)
				{
					grid[i, 0].Value = flag;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x04000050 RID: 80
		public GridInfo.CellColors CellColor;

		// Token: 0x0200000D RID: 13
		public class CellColors
		{
			// Token: 0x06000030 RID: 48 RVA: 0x00004480 File Offset: 0x00002680
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
				this.cell_back_red = new SourceGrid.Cells.Views.Cell();
				this.cell_back_red.BackColor = Color.FromArgb(255, 255, 0, 0);
				this.cell_back_red.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
				this.cell_back_yellow = new SourceGrid.Cells.Views.Cell();
				this.cell_back_yellow.BackColor = Color.Aquamarine;
				this.cell_back_yellow.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
				this.cell_back_white = new SourceGrid.Cells.Views.Cell();
				this.cell_back_white.BackColor = Color.Transparent;
				this.cell_back_white.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			}

			// Token: 0x04000051 RID: 81
			public SourceGrid.Cells.Views.Cell cell_gray_right;

			// Token: 0x04000052 RID: 82
			public SourceGrid.Cells.Views.Cell cell_gray_center;

			// Token: 0x04000053 RID: 83
			public SourceGrid.Cells.Views.Cell cell_total;

			// Token: 0x04000054 RID: 84
			public SourceGrid.Cells.Views.Cell cell_green;

			// Token: 0x04000055 RID: 85
			public SourceGrid.Cells.Views.Cell cell_right;

			// Token: 0x04000056 RID: 86
			public SourceGrid.Cells.Views.Cell cell_left;

			// Token: 0x04000057 RID: 87
			public SourceGrid.Cells.Views.Cell cell_limit;

			// Token: 0x04000058 RID: 88
			public SourceGrid.Cells.Views.Cell cell_header1;

			// Token: 0x04000059 RID: 89
			public SourceGrid.Cells.Views.Cell cell_header2;

			// Token: 0x0400005A RID: 90
			public SourceGrid.Cells.Views.Cell cell_header3;

			// Token: 0x0400005B RID: 91
			public SourceGrid.Cells.Views.Cell cell_header4;

			// Token: 0x0400005C RID: 92
			public SourceGrid.Cells.Views.Cell cell_header5;

			// Token: 0x0400005D RID: 93
			public SourceGrid.Cells.Views.Cell cell_header6;

			// Token: 0x0400005E RID: 94
			public SourceGrid.Cells.Views.Cell cell_header7;

			// Token: 0x0400005F RID: 95
			public SourceGrid.Cells.Views.Cell cell_font_blue;

			// Token: 0x04000060 RID: 96
			public SourceGrid.Cells.Views.Cell cell_font_red;

			// Token: 0x04000061 RID: 97
			public SourceGrid.Cells.Views.Cell cell_back_red;

			// Token: 0x04000062 RID: 98
			public SourceGrid.Cells.Views.Cell cell_back_yellow;

			// Token: 0x04000063 RID: 99
			public SourceGrid.Cells.Views.Cell cell_back_white;
		}

		// Token: 0x0200000E RID: 14
		public class ColHeader : SourceGrid.Cells.ColumnHeader
		{
			// Token: 0x06000031 RID: 49 RVA: 0x00004828 File Offset: 0x00002A28
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
