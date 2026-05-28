using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.SAMSUNGModule.Class
{
	// Token: 0x02000008 RID: 8
	internal class GridInfo
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002080 File Offset: 0x00000280
		public GridInfo()
		{
			this.init();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000208E File Offset: 0x0000028E
		public void init()
		{
			this.CellColor = new GridInfo.CellColors();
			this.CellColor.InitGridCell();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020A8 File Offset: 0x000002A8
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

		// Token: 0x0600000A RID: 10 RVA: 0x00002170 File Offset: 0x00000370
		public void SetColumnCellColor(Grid grid, int rowIndex, SourceGrid.Cells.Views.Cell cell)
		{
			for (int i = 0; i < grid.Columns.Count; i++)
			{
				grid[rowIndex, i].View = cell;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021A4 File Offset: 0x000003A4
		public void SetColumnCellColor(Grid grid, int rowIndex, int colIndex, SourceGrid.Cells.Views.Cell cell)
		{
			for (int i = 0; i < grid.Columns.Count; i++)
			{
				grid[rowIndex, i].View = cell;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021D6 File Offset: 0x000003D6
		public void CreateColHeaderCheckBox(Grid grid)
		{
			this.CreateColHeaderCheckBox(grid, new System.Windows.Forms.CheckBox());
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021E4 File Offset: 0x000003E4
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

		// Token: 0x0600000E RID: 14 RVA: 0x00002284 File Offset: 0x00000484
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

		// Token: 0x04000024 RID: 36
		public GridInfo.CellColors CellColor;

		// Token: 0x02000009 RID: 9
		public class CellColors
		{
			// Token: 0x06000010 RID: 16 RVA: 0x00002314 File Offset: 0x00000514
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
			}

			// Token: 0x04000025 RID: 37
			public SourceGrid.Cells.Views.Cell cell_gray_right;

			// Token: 0x04000026 RID: 38
			public SourceGrid.Cells.Views.Cell cell_gray_center;

			// Token: 0x04000027 RID: 39
			public SourceGrid.Cells.Views.Cell cell_total;

			// Token: 0x04000028 RID: 40
			public SourceGrid.Cells.Views.Cell cell_green;

			// Token: 0x04000029 RID: 41
			public SourceGrid.Cells.Views.Cell cell_right;

			// Token: 0x0400002A RID: 42
			public SourceGrid.Cells.Views.Cell cell_left;

			// Token: 0x0400002B RID: 43
			public SourceGrid.Cells.Views.Cell cell_limit;

			// Token: 0x0400002C RID: 44
			public SourceGrid.Cells.Views.Cell cell_header1;

			// Token: 0x0400002D RID: 45
			public SourceGrid.Cells.Views.Cell cell_header2;

			// Token: 0x0400002E RID: 46
			public SourceGrid.Cells.Views.Cell cell_header3;

			// Token: 0x0400002F RID: 47
			public SourceGrid.Cells.Views.Cell cell_header4;

			// Token: 0x04000030 RID: 48
			public SourceGrid.Cells.Views.Cell cell_header5;

			// Token: 0x04000031 RID: 49
			public SourceGrid.Cells.Views.Cell cell_header6;

			// Token: 0x04000032 RID: 50
			public SourceGrid.Cells.Views.Cell cell_header7;

			// Token: 0x04000033 RID: 51
			public SourceGrid.Cells.Views.Cell cell_font_blue;

			// Token: 0x04000034 RID: 52
			public SourceGrid.Cells.Views.Cell cell_font_red;

			// Token: 0x04000035 RID: 53
			public SourceGrid.Cells.Views.Cell cell_palegreen;

			// Token: 0x04000036 RID: 54
			public SourceGrid.Cells.Views.Cell cell_lightgreen;
		}

		// Token: 0x0200000A RID: 10
		public class ColHeader : SourceGrid.Cells.ColumnHeader
		{
			// Token: 0x06000011 RID: 17 RVA: 0x00002694 File Offset: 0x00000894
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
