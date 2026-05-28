using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000003 RID: 3
	public partial class SelectNick : Form
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002BA7 File Offset: 0x00000DA7
		public SelectNick(RefInfo refinfo)
		{
			this._refInfo = refinfo;
			this.InitializeComponent();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002BBC File Offset: 0x00000DBC
		private void SelectNick_Load(object sender, EventArgs e)
		{
			this.SetGrid(this._refInfo.al_Nick);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002BD0 File Offset: 0x00000DD0
		protected override Point ScrollToControl(Control activeControl)
		{
			return this.DisplayRectangle.Location;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002BEC File Offset: 0x00000DEC
		private void ResetGrid()
		{
			this.grid_nick.Rows.Clear();
			this.grid_nick.Selection.EnableMultiSelection = false;
			this.grid_nick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_nick.CustomSort = true;
			this.grid_nick.Rows.Clear();
			this.grid_nick.Selection.EnableMultiSelection = false;
			this.grid_nick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_nick.CustomSort = true;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002C6C File Offset: 0x00000E6C
		private void SetGrid(ArrayList alist)
		{
			this.ResetGrid();
			SourceGrid.Cells.Views.Cell cell = new SourceGrid.Cells.Views.Cell();
			cell.BackColor = Color.FromArgb(130, 179, 237);
			cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			SourceGrid.Cells.Views.Cell cell2 = new SourceGrid.Cells.Views.Cell();
			cell2.BackColor = Color.FromArgb(255, 192, 203);
			this.grid_nick.ColumnsCount = 3;
			this.grid_nick.FixedRows = 1;
			this.grid_nick.Rows.Insert(0);
			this.grid_nick[0, 0] = new SourceGrid.Cells.ColumnHeader("#");
			this.grid_nick[0, 0].View = cell;
			this.grid_nick[0, 1] = new SourceGrid.Cells.ColumnHeader("Nick");
			this.grid_nick[0, 1].View = cell;
			this.grid_nick[0, 2] = new SourceGrid.Cells.ColumnHeader("Customer");
			this.grid_nick[0, 2].View = cell;
			int num = 1;
			if (alist != null)
			{
				foreach (object obj in alist)
				{
					NickList nickList = (NickList)obj;
					this.grid_nick.Rows.Insert(num);
					this.grid_nick[num, 0] = new SourceGrid.Cells.Cell(nickList.no);
					this.grid_nick[num, 0].Tag = nickList;
					this.grid_nick[num, 1] = new SourceGrid.Cells.Cell(nickList.NICK);
					this.grid_nick[num, 2] = new SourceGrid.Cells.Cell(nickList.customername);
					num++;
				}
			}
			this.grid_nick.AutoSizeCells();
			int num2 = 0;
			int num3 = 0;
			foreach (object obj2 in ((IEnumerable)this.grid_nick.Columns))
			{
				GridColumn gridColumn = (GridColumn)obj2;
				num2 += gridColumn.Width;
			}
			foreach (RowInfo rowInfo in this.grid_nick.Rows)
			{
				GridRow gridRow = (GridRow)rowInfo;
				num3 += gridRow.Height;
			}
			this.panel_grid.Height = num3 + 20;
			this.panel_grid.Width = num2 + 20;
			base.Width = this.panel_grid.Width + 50;
			if (base.Width < 350)
			{
				base.Width = 350;
			}
			if (this.panel_grid.Height > 350)
			{
				this.panel_grid.Height = 350;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002F64 File Offset: 0x00001164
		private void grid_nick_MouseClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			string empty = string.Empty;
			int row = grid.MouseDownPosition.Row;
			if (row >= 0 && this.grid_nick[row, 0].Tag != null)
			{
				this._selectNick = (NickList)this.grid_nick[row, 0].Tag;
				this.label_selectedNick.Text = this._selectNick.NICK;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002FD8 File Offset: 0x000011D8
		private void button_Search_Click(object sender, EventArgs e)
		{
			if (this.textBox_filter.Text != "")
			{
				string value = this.textBox_filter.Text.ToUpper();
				ArrayList arrayList = new ArrayList();
				foreach (object obj in this._refInfo.al_Nick)
				{
					NickList nickList = (NickList)obj;
					if (nickList.NICK.ToUpper().Contains(value))
					{
						arrayList.Add(nickList);
					}
					else if (nickList.customername.ToUpper().Contains(value))
					{
						arrayList.Add(nickList);
					}
				}
				this.SetGrid(arrayList);
				this.issearch = true;
				return;
			}
			if (this.issearch)
			{
				this.SetGrid(this._refInfo.al_Nick);
				this.issearch = false;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000030CC File Offset: 0x000012CC
		private void grid_nick_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			string empty = string.Empty;
			int row = grid.MouseDownPosition.Row;
			if (row >= 0 && this.grid_nick[row, 0].Tag != null)
			{
				this._selectNick = (NickList)this.grid_nick[row, 0].Tag;
				this.label_selectedNick.Text = this._selectNick.NICK;
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000314D File Offset: 0x0000134D
		private void button_select_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000315C File Offset: 0x0000135C
		private void button_CF_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0400000D RID: 13
		private bool issearch;

		// Token: 0x0400000E RID: 14
		public NickList _selectNick;

		// Token: 0x0400000F RID: 15
		private RefInfo _refInfo;
	}
}
