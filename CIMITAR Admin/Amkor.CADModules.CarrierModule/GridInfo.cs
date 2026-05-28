using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.CarrierModule
{
	// Token: 0x0200001B RID: 27
	internal class GridInfo
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00002A90 File Offset: 0x00000C90
		public GridInfo()
		{
			this.init();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002A9E File Offset: 0x00000C9E
		public void init()
		{
			this.CellColor = new GridInfo.CellColors();
			this.CellColor.InitGridCell();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002AB8 File Offset: 0x00000CB8
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

		// Token: 0x06000024 RID: 36 RVA: 0x00002B80 File Offset: 0x00000D80
		public void SetColumnCellColor(Grid grid, int rowIndex, SourceGrid.Cells.Views.Cell cell)
		{
			for (int i = 0; i < grid.Columns.Count; i++)
			{
				grid[rowIndex, i].View = cell;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002BB4 File Offset: 0x00000DB4
		public void CreateColHeaderCheckBox(Grid grid, System.Windows.Forms.CheckBox checkBox, int iRowCount)
		{
			try
			{
				Rectangle rectangle = grid.PositionToRectangle(new Position(0, 0));
				rectangle.Offset(8, 5);
				if (iRowCount > 1)
				{
					rectangle.Offset(8, 12);
				}
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

		// Token: 0x06000026 RID: 38 RVA: 0x00002C60 File Offset: 0x00000E60
		public void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
				Grid grid = (Grid)checkBox.Parent;
				if (grid.RowsCount > 0)
				{
					for (int i = 1; i < grid.RowsCount; i++)
					{
						if (grid.Rows[i].Tag == null || grid.Rows[i].Tag.ToString() != "Header")
						{
							((Grid)checkBox.Parent)[i, 0].Value = checkBox.Checked;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002D14 File Offset: 0x00000F14
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

		// Token: 0x0400010E RID: 270
		public GridInfo.CellColors CellColor;

		// Token: 0x0200001C RID: 28
		public class CellColors
		{
			// Token: 0x06000029 RID: 41 RVA: 0x00002D70 File Offset: 0x00000F70
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

			// Token: 0x0400010F RID: 271
			public SourceGrid.Cells.Views.Cell cell_gray_right;

			// Token: 0x04000110 RID: 272
			public SourceGrid.Cells.Views.Cell cell_gray_center;

			// Token: 0x04000111 RID: 273
			public SourceGrid.Cells.Views.Cell cell_total;

			// Token: 0x04000112 RID: 274
			public SourceGrid.Cells.Views.Cell cell_green;

			// Token: 0x04000113 RID: 275
			public SourceGrid.Cells.Views.Cell cell_right;

			// Token: 0x04000114 RID: 276
			public SourceGrid.Cells.Views.Cell cell_left;

			// Token: 0x04000115 RID: 277
			public SourceGrid.Cells.Views.Cell cell_limit;

			// Token: 0x04000116 RID: 278
			public SourceGrid.Cells.Views.Cell cell_header1;

			// Token: 0x04000117 RID: 279
			public SourceGrid.Cells.Views.Cell cell_header2;

			// Token: 0x04000118 RID: 280
			public SourceGrid.Cells.Views.Cell cell_header3;

			// Token: 0x04000119 RID: 281
			public SourceGrid.Cells.Views.Cell cell_header4;

			// Token: 0x0400011A RID: 282
			public SourceGrid.Cells.Views.Cell cell_header5;

			// Token: 0x0400011B RID: 283
			public SourceGrid.Cells.Views.Cell cell_header6;

			// Token: 0x0400011C RID: 284
			public SourceGrid.Cells.Views.Cell cell_header7;

			// Token: 0x0400011D RID: 285
			public SourceGrid.Cells.Views.Cell cell_font_blue;

			// Token: 0x0400011E RID: 286
			public SourceGrid.Cells.Views.Cell cell_font_red;

			// Token: 0x0400011F RID: 287
			public SourceGrid.Cells.Views.Cell cell_back_red;

			// Token: 0x04000120 RID: 288
			public SourceGrid.Cells.Views.Cell cell_back_yellow;

			// Token: 0x04000121 RID: 289
			public SourceGrid.Cells.Views.Cell cell_back_white;
		}

		// Token: 0x0200001D RID: 29
		public class ColHeader : SourceGrid.Cells.ColumnHeader
		{
			// Token: 0x0600002A RID: 42 RVA: 0x00003118 File Offset: 0x00001318
			public ColHeader(object value, bool sort = false) : base(value)
			{
				this.View = new SourceGrid.Cells.Views.ColumnHeader
				{
					Font = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Regular),
					TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter
				};
				if (sort)
				{
					base.AutomaticSortEnabled = true;
					return;
				}
				base.AutomaticSortEnabled = false;
			}
		}
	}
}
