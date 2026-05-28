using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using Amkor.CHModules.BIBoardInfoModule.SubForms;
using CommonLibrary;
using DATA;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000028 RID: 40
	public partial class SocketPartChange : Form
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x00014A68 File Offset: 0x00012C68
		public SocketPartChange(string boardNo, BIBoardInfoModule instance)
		{
			this.InitializeComponent();
			this._boardNo = boardNo;
			this._instance = instance;
			this._cGridIndex_SPC = new CGridIndex_BoardInfo_SocketPartChange();
			this._alCategories = new ArrayList();
			this.InitGridCell();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000055FE File Offset: 0x000037FE
		private void SocketPartChange_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00014AB8 File Offset: 0x00012CB8
		private void SocketPartChange_Load(object sender, EventArgs e)
		{
			if (this._boardNo != "")
			{
				this.tb_biboardno.Text = this._boardNo;
			}
			this.l_subject.Text = this._instance._factorySetting._factoryName;
			this.SetGridInfo_SocketNo();
			this.Clear();
			this._alCategories = this._instance._alCategory_SocketPartChange;
			this.combo_PartChange_Category.Items.Clear();
			this.combo_PartChange_Category.Items.AddRange(this._alCategories.ToArray());
			if (this.combo_PartChange_Category.Items.Count == 1)
			{
				this.combo_PartChange_Category.SelectedIndex = 0;
			}
			DateTime now = DateTime.Now;
			this.dtPicker_DateFrom.Value = now.AddDays(-7.0);
			this.dtPicker_DateTo.Value = now;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00014B98 File Offset: 0x00012D98
		private void InitGridCell()
		{
			Color color = Color.FromArgb(255, 255, 255);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			this.cell_center = new SourceGrid.Cells.Views.Cell();
			this.cell_center.BackColor = color;
			this.cell_center.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center.Border = rectangleBorder;
			this.cell_center.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center.ImageStretch = false;
			Color color2 = Color.FromArgb(130, 179, 237);
			RectangleBorder rectangleBorder2 = new RectangleBorder(new BorderLine(color2), new BorderLine(color2));
			this.cell_header1 = new SourceGrid.Cells.Views.Cell();
			this.cell_header1.BackColor = color2;
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header1.Border = rectangleBorder2;
			Color color3 = Color.FromArgb(253, 203, 110);
			RectangleBorder rectangleBorder3 = new RectangleBorder(new BorderLine(color3), new BorderLine(color3));
			this.cell_header2 = new SourceGrid.Cells.Views.Cell();
			this.cell_header2.BackColor = color3;
			this.cell_header2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header2.Border = rectangleBorder3;
			Color white = Color.White;
			RectangleBorder rectangleBorder4 = new RectangleBorder(new BorderLine(white), new BorderLine(white));
			this.cell_body1 = new SourceGrid.Cells.Views.Cell();
			this.cell_body1.BackColor = white;
			this.cell_body1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_body1.Border = rectangleBorder4;
			Color color4 = Color.FromArgb(225, 112, 85);
			RectangleBorder rectangleBorder5 = new RectangleBorder(new BorderLine(color4), new BorderLine(color4));
			this.cell_header3 = new SourceGrid.Cells.Views.Cell();
			this.cell_header3.BackColor = color4;
			this.cell_header3.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header3.Border = rectangleBorder5;
			Color color5 = Color.FromArgb(250, 177, 160);
			RectangleBorder rectangleBorder6 = new RectangleBorder(new BorderLine(color5), new BorderLine(color5));
			this.cell_body2 = new SourceGrid.Cells.Views.Cell();
			this.cell_body2.BackColor = color5;
			this.cell_body2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_body2.Border = rectangleBorder6;
			Color color6 = Color.FromArgb(253, 203, 110);
			RectangleBorder rectangleBorder7 = new RectangleBorder(new BorderLine(color6), new BorderLine(color6));
			this.cell_onflag = new SourceGrid.Cells.Views.Cell();
			this.cell_onflag.BackColor = color6;
			this.cell_onflag.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_onflag.Border = rectangleBorder7;
			Color color7 = Color.FromArgb(255, 255, 255);
			RectangleBorder rectangleBorder8 = new RectangleBorder(new BorderLine(color7), new BorderLine(color7));
			this.cell_row1 = new SourceGrid.Cells.Views.Cell();
			this.cell_row1.BackColor = color7;
			this.cell_row1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row1.Border = rectangleBorder8;
			this.cell_row1.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row1.ImageStretch = false;
			Color color8 = Color.FromArgb(255, 234, 167);
			RectangleBorder rectangleBorder9 = new RectangleBorder(new BorderLine(color8), new BorderLine(color8));
			this.cell_row2 = new SourceGrid.Cells.Views.Cell();
			this.cell_row2.BackColor = color8;
			this.cell_row2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row2.Border = rectangleBorder9;
			this.cell_row2.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row2.ImageStretch = false;
			Color color9 = Color.FromArgb(39, 174, 96);
			RectangleBorder rectangleBorder10 = new RectangleBorder(new BorderLine(color9), new BorderLine(color9));
			this.cell_good = new SourceGrid.Cells.Views.Cell();
			this.cell_good.BackColor = color9;
			this.cell_good.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_good.Border = rectangleBorder10;
			this.cell_good.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_good.ImageStretch = false;
			this.cell_good.ForeColor = Color.White;
			Color red = Color.Red;
			RectangleBorder rectangleBorder11 = new RectangleBorder(new BorderLine(red), new BorderLine(red));
			this.cell_bad = new SourceGrid.Cells.Views.Cell();
			this.cell_bad.BackColor = red;
			this.cell_bad.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_bad.Border = rectangleBorder11;
			this.cell_bad.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_bad.ImageStretch = false;
			this.cell_bad.ForeColor = Color.White;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00015040 File Offset: 0x00013240
		private void ResetGrid(Grid grid)
		{
			for (int i = grid.RowsCount - 1; i >= 0; i--)
			{
				grid.Rows.Remove(i);
			}
			grid.Selection.EnableMultiSelection = false;
			grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grid.CustomSort = true;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00015088 File Offset: 0x00013288
		private void SetHeaderInfo(string[] gridHeaders, Grid grid)
		{
			grid.ColumnsCount = gridHeaders.Length;
			grid.FixedRows = 1;
			grid.FixedColumns = 1;
			grid.Rows.Insert(0);
			for (int i = 0; i < gridHeaders.Length; i++)
			{
				grid[0, i] = new SourceGrid.Cells.ColumnHeader(gridHeaders[i]);
				grid[0, i].View = this.cell_header1;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000150EC File Offset: 0x000132EC
		private void SetGridInfo_SocketNo()
		{
			this.ResetGrid(this.grid_SocketNo);
			int num = 24;
			int num2 = 4;
			if (this._instance._factorySetting._factoryName == "ATV")
			{
				num = 144;
				num2 = 12;
			}
			this.grid_SocketNo.ColumnsCount = num / num2;
			this.grid_SocketNo.FixedRows = 1;
			this.grid_SocketNo.FixedColumns = 0;
			this.grid_SocketNo.Rows.Insert(0);
			for (int i = 0; i < this.grid_SocketNo.ColumnsCount; i++)
			{
				this.grid_SocketNo[0, i] = new SourceGrid.Cells.ColumnHeader("");
				this.grid_SocketNo[0, i].Column.Width = 40;
			}
			if (this._instance._factorySetting._factoryName == "ATV")
			{
				int num3 = 1;
				for (int j = 1; j <= num2 + 1; j++)
				{
					this.grid_SocketNo.Rows.Insert(j);
					for (int k = 0; k < this.grid_SocketNo.ColumnsCount; k++)
					{
						if (j == 1)
						{
							if (k == 0)
							{
								this.grid_SocketNo[j, k] = new SourceGrid.Cells.Cell("ALL");
								this.grid_SocketNo[j, k].View = this.cell_header1;
							}
							else
							{
								this.grid_SocketNo[j, k] = new SourceGrid.Cells.Cell("");
								this.grid_SocketNo[j, k].View = this.cell_body1;
							}
						}
						else
						{
							this.grid_SocketNo[j, k] = new SourceGrid.Cells.Cell(num3 - 1);
							this.grid_SocketNo[j, k].View = this.cell_header1;
							num3++;
						}
					}
				}
			}
			else
			{
				int num4 = num - num2;
				for (int l = 1; l <= num2 + 1; l++)
				{
					this.grid_SocketNo.Rows.Insert(l);
					for (int m = 0; m < this.grid_SocketNo.ColumnsCount; m++)
					{
						if (l == 1)
						{
							if (m == 0)
							{
								this.grid_SocketNo[l, m] = new SourceGrid.Cells.Cell("ALL");
								this.grid_SocketNo[l, m].View = this.cell_header1;
							}
							else
							{
								this.grid_SocketNo[l, m] = new SourceGrid.Cells.Cell("");
								this.grid_SocketNo[l, m].View = this.cell_body1;
							}
						}
						else
						{
							this.grid_SocketNo[l, m] = new SourceGrid.Cells.Cell(num4 - 1);
							this.grid_SocketNo[l, m].View = this.cell_header1;
							num4 -= num2;
						}
					}
					num4 = num - num2 + l;
				}
			}
			this.grid_SocketNo.AutoSizeCells();
			for (int n = 0; n < this.grid_SocketNo.ColumnsCount; n++)
			{
				this.grid_SocketNo[0, n].Column.Width = 50;
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00015410 File Offset: 0x00013610
		private void SetGrid_PartChangeHistory(List<CSocketPartChange> cSocketPartChanges, Grid grid)
		{
			if (cSocketPartChanges.Count == 0)
			{
				return;
			}
			List<CSocketPartChange> list = (from o in cSocketPartChanges
			orderby o.dtInTime descending
			select o).ToList<CSocketPartChange>();
			int num = 1;
			string[] headers = this._cGridIndex_SPC.headers;
			this.SetHeaderInfo(headers, grid);
			try
			{
				foreach (CSocketPartChange csocketPartChange in list)
				{
					if (csocketPartChange.iId != 0)
					{
						grid.Rows.Insert(num);
						CustomEvents customEvents = new CustomEvents();
						customEvents.Click += this.clickEvent_Id_Click;
						grid[num, this._cGridIndex_SPC.iId] = new SourceGrid.Cells.Button(csocketPartChange.iId);
						grid[num, this._cGridIndex_SPC.iId].AddController(customEvents);
						grid[num, this._cGridIndex_SPC.iDate] = new SourceGrid.Cells.Cell(csocketPartChange.dtInTime.ToString("yyyy-MM-dd HH:mm:ss"));
						grid[num, this._cGridIndex_SPC.iBibNo] = new SourceGrid.Cells.Cell(csocketPartChange.strBibNo);
						grid[num, this._cGridIndex_SPC.iBib_Loc] = new SourceGrid.Cells.Cell(csocketPartChange.strBarcode_Board);
						grid[num, this._cGridIndex_SPC.iSocket_No] = new SourceGrid.Cells.Cell(csocketPartChange.iSocketNo);
						grid[num, this._cGridIndex_SPC.iCategory] = new SourceGrid.Cells.Cell(csocketPartChange.strCategory);
						grid[num, this._cGridIndex_SPC.iSocket_Loc] = new SourceGrid.Cells.Cell(csocketPartChange.strBarcode_Socket);
						grid[num, this._cGridIndex_SPC.iRepairTime] = new SourceGrid.Cells.Cell(csocketPartChange.iRepairTime_Min);
						grid[num, this._cGridIndex_SPC.iBadgeNo] = new SourceGrid.Cells.Cell(csocketPartChange.strBadgeNo);
						grid[num, this._cGridIndex_SPC.iComment] = new SourceGrid.Cells.Cell(csocketPartChange.strComment);
						CustomEvents customEvents2 = new CustomEvents();
						customEvents2.Click += this.clickEvent_Click;
						grid[num, this._cGridIndex_SPC.iDelete] = new SourceGrid.Cells.Button("DELETE");
						grid[num, this._cGridIndex_SPC.iDelete].AddController(customEvents2);
						for (int i = 1; i < this._cGridIndex_SPC.headers.Length - 1; i++)
						{
							if (num % 2 == 0)
							{
								grid[num, i].View = this._instance._cell_center1;
							}
							else
							{
								grid[num, i].View = this._instance._cell_center2;
							}
						}
						num++;
					}
				}
				grid.AutoSizeCells();
				for (int j = 0; j < grid.Columns.Count; j++)
				{
					grid.Columns[j].Tag = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00015750 File Offset: 0x00013950
		private void clickEvent_Id_Click(object sender, EventArgs e)
		{
			int[] rowsIndex = this.grid_PartChangeHistory.Selection.GetSelectionRegion().GetRowsIndex();
			RowInfo[] array = new RowInfo[rowsIndex.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.grid_PartChangeHistory.Rows[rowsIndex[i]];
			}
			int id = 0;
			RowInfo[] array2 = array;
			int num = 0;
			if (num < array2.Length)
			{
				RowInfo rowInfo = array2[num];
				id = int.Parse(this.grid_PartChangeHistory[rowInfo.Index, this._cGridIndex_SPC.iId].ToString());
			}
			SocketPartChange_Insert socketPartChange_Insert = new SocketPartChange_Insert(new CSocketPartChange(this._cBIBoardInfo.cSocketPartChanges.SingleOrDefault((CSocketPartChange o) => o.iId == id)), this._alCategories, this._instance);
			socketPartChange_Insert.ShowDialog();
			if (socketPartChange_Insert.DialogResult == DialogResult.OK)
			{
				this.Refresh_Part();
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0001583C File Offset: 0x00013A3C
		private void clickEvent_Click(object sender, EventArgs e)
		{
			int num = -1;
			int[] rowsIndex = this.grid_PartChangeHistory.Selection.GetSelectionRegion().GetRowsIndex();
			RowInfo[] array = new RowInfo[rowsIndex.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.grid_PartChangeHistory.Rows[rowsIndex[i]];
			}
			CheckBadgeNo checkBadgeNo = new CheckBadgeNo();
			checkBadgeNo.ShowDialog();
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (checkBadgeNo.DialogResult != DialogResult.OK)
			{
				return;
			}
			string badgeNo = checkBadgeNo._badgeNo;
			string comment = checkBadgeNo._comment;
			RowInfo[] array2 = array;
			int num2 = 0;
			if (num2 < array2.Length)
			{
				RowInfo rowInfo = array2[num2];
				int id = int.Parse(this.grid_PartChangeHistory[rowInfo.Index, this._cGridIndex_SPC.iId].ToString());
				num = this.Delete_PChange(id);
			}
			if (num == 0)
			{
				MessageBox.Show("Success to Delete");
				this.Refresh_Part();
				return;
			}
			MessageBox.Show("Fail to Delete");
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00015930 File Offset: 0x00013B30
		private void btn_search_Click(object sender, EventArgs e)
		{
			this.Clear();
			string text = this.tb_biboardno.Text;
			if (text == "")
			{
				MessageBox.Show("Input BIBoard Number");
				return;
			}
			int num = text.IndexOf("#");
			if (num != -1)
			{
				if (num != 0)
				{
					MessageBox.Show("Invalid BIB No.");
					return;
				}
				text = text.Substring(1, text.Length - 1);
			}
			string dateFrom = this.dtPicker_DateFrom.Value.ToString("yyyy-MM-dd");
			string dateTo = this.dtPicker_DateTo.Value.ToString("yyyy-MM-dd");
			this.Search(text, dateFrom, dateTo);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000159D8 File Offset: 0x00013BD8
		private void tb_biboardno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.Clear();
				string text = this.tb_biboardno.Text;
				if (text == "")
				{
					MessageBox.Show("Input BIBoard Number");
					return;
				}
				int num = text.IndexOf("#");
				if (num != -1)
				{
					if (num != 0)
					{
						MessageBox.Show("Invalid BIB No.");
						return;
					}
					text = text.Substring(1, text.Length - 1);
				}
				string dateFrom = this.dtPicker_DateFrom.Value.ToString("yyyy-MM-dd");
				string dateTo = this.dtPicker_DateTo.Value.ToString("yyyy-MM-dd");
				this.Search(text, dateFrom, dateTo);
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00015A8C File Offset: 0x00013C8C
		private void grid_SocketNo_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.grid_SocketNo.Selection.ActivePosition.Row < 0)
			{
				return;
			}
			if (this.combo_PartChange_Category.SelectedItem == null)
			{
				return;
			}
			string category = this.combo_PartChange_Category.SelectedItem.ToString();
			if (this._cBIBoardInfo == null)
			{
				return;
			}
			int row = this.grid_SocketNo.Selection.ActivePosition.Row;
			int column = this.grid_SocketNo.Selection.ActivePosition.Column;
			string text = this.grid_SocketNo[row, column].ToString();
			if (text != "")
			{
				this.ResetGrid(this.grid_PartChangeHistory);
				if (this._cBIBoardInfo.cSocketPartChanges.Count == 0)
				{
					return;
				}
				List<CSocketPartChange> list = this.SetGridData(text, category);
				this.SetGrid_PartChangeHistory(list, this.grid_PartChangeHistory);
				this.lbl_SocketNo.Text = text;
				this.lbl_CntOfChange.Text = list.Count.ToString();
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00015B90 File Offset: 0x00013D90
		private void grid_SocketNo_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._cBIBoardInfo == null)
			{
				return;
			}
			if (this.grid_SocketNo.Selection.ActivePosition.Row < 0)
			{
				return;
			}
			string category = (this.combo_PartChange_Category.SelectedItem == null) ? "" : this.combo_PartChange_Category.SelectedItem.ToString();
			if (this._cBIBoardInfo == null)
			{
				return;
			}
			int row = this.grid_SocketNo.Selection.ActivePosition.Row;
			int column = this.grid_SocketNo.Selection.ActivePosition.Column;
			string text = this.grid_SocketNo[row, column].ToString();
			if (text != "")
			{
				if (text == "ALL")
				{
					return;
				}
				int socketNo = int.Parse(text);
				SocketPartChange_Insert socketPartChange_Insert = new SocketPartChange_Insert(this._cBIBoardInfo, socketNo, category, this._alCategories, this._instance);
				socketPartChange_Insert.ShowDialog();
				if (socketPartChange_Insert.DialogResult == DialogResult.OK)
				{
					string text2 = this.tb_biboardno.Text;
					string dateFrom = this.dtPicker_DateFrom.Value.ToString("yyyy-MM-dd");
					string dateTo = this.dtPicker_DateTo.Value.ToString("yyyy-MM-dd");
					this.Search(text2, dateFrom, dateTo);
				}
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00015CD8 File Offset: 0x00013ED8
		private void combo_PartChange_Category_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this._cBIBoardInfo == null)
			{
				return;
			}
			if (this.combo_PartChange_Category.SelectedItem == null)
			{
				return;
			}
			string category = this.combo_PartChange_Category.SelectedItem.ToString();
			this.ResetGrid(this.grid_PartChangeHistory);
			List<CSocketPartChange> list;
			if (category == "ALL")
			{
				list = this._cBIBoardInfo.cSocketPartChanges;
			}
			else
			{
				list = (from o in this._cBIBoardInfo.cSocketPartChanges
				where o.strCategory == category
				select o).ToList<CSocketPartChange>();
			}
			if (list.Count != 0)
			{
				this.SetGrid_PartChangeHistory(list, this.grid_PartChangeHistory);
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00015D80 File Offset: 0x00013F80
		private void dtPicker_DateFrom_ValueChanged(object sender, EventArgs e)
		{
			if ((this.dtPicker_DateTo.Value - this.dtPicker_DateFrom.Value).TotalMinutes < 0.0)
			{
				this.dtPicker_DateFrom.Value = DateTime.Now;
				return;
			}
			string text = this.tb_biboardno.Text;
			if (text == "")
			{
				return;
			}
			int num = text.IndexOf("#");
			if (num != -1)
			{
				if (num != 0)
				{
					return;
				}
				text = text.Substring(1, text.Length - 1);
			}
			string dateFrom = this.dtPicker_DateFrom.Value.ToString("yyyy-MM-dd");
			string dateTo = this.dtPicker_DateTo.Value.ToString("yyyy-MM-dd");
			this.Search(text, dateFrom, dateTo);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00015E4C File Offset: 0x0001404C
		private void dtPicker_DateTo_ValueChanged(object sender, EventArgs e)
		{
			if ((this.dtPicker_DateTo.Value - this.dtPicker_DateFrom.Value).TotalMinutes < 0.0)
			{
				this.dtPicker_DateFrom.Value = DateTime.Now;
				return;
			}
			string text = this.tb_biboardno.Text;
			if (text == "")
			{
				return;
			}
			int num = text.IndexOf("#");
			if (num != -1)
			{
				if (num != 0)
				{
					return;
				}
				text = text.Substring(1, text.Length - 1);
			}
			string dateFrom = this.dtPicker_DateFrom.Value.ToString("yyyy-MM-dd");
			string dateTo = this.dtPicker_DateTo.Value.ToString("yyyy-MM-dd");
			this.Search(text, dateFrom, dateTo);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00015F18 File Offset: 0x00014118
		private void btn_aWeek_Click(object sender, EventArgs e)
		{
			this.dtPicker_DateFrom.Value = DateTime.Now.AddDays(-7.0);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00015F48 File Offset: 0x00014148
		private void btn_aMonth_Click(object sender, EventArgs e)
		{
			this.dtPicker_DateFrom.Value = DateTime.Now.AddMonths(-1);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00015F70 File Offset: 0x00014170
		private void btn_threeMonth_Click(object sender, EventArgs e)
		{
			this.dtPicker_DateFrom.Value = DateTime.Now.AddMonths(-3);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00015F97 File Offset: 0x00014197
		private void pb_ExportExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_ExportExcel.Image = Resources.SaveExcel_Down;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00015FAC File Offset: 0x000141AC
		private void pb_ExportExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_ExportExcel.Image = Resources.SaveExcel;
			if (this.grid_PartChangeHistory.Rows.Count < 1)
			{
				MessageBox.Show("No Data");
				return;
			}
			string filename = string.Empty;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.Title = "Save File";
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.Filter = "CSV Fils (*.csv)|*.csv";
			saveFileDialog.FilterIndex = 2;
			saveFileDialog.FileName = "SocketPartChange_" + DateTime.Now.ToString("yyyy-MM-dd");
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				filename = saveFileDialog.FileName;
				if (new CSVControl().generateCSV(filename, this.grid_PartChangeHistory))
				{
					MessageBox.Show("Success to Save CSV");
					return;
				}
				MessageBox.Show("Fail to Save CSV");
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0001607B File Offset: 0x0001427B
		private void pb_ExportExcel_All_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_ExportExcel_All.Image = Resources.SaveExcel_Down;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00016090 File Offset: 0x00014290
		private void pb_ExportExcel_All_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_ExportExcel_All.Image = Resources.SaveExcel;
			DateCond dateCond = new DateCond();
			dateCond.ShowDialog();
			if (dateCond.DialogResult == DialogResult.OK)
			{
				string dateFrom = dateCond._dateFrom;
				string dateTo = dateCond._dateTo;
				Grid grid = this.Search_All(dateFrom, dateTo);
				if (grid == null)
				{
					return;
				}
				if (grid.Rows.Count < 1)
				{
					MessageBox.Show("No Data");
					return;
				}
				string filename = string.Empty;
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.Title = "Save File";
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.Filter = "CSV Fils (*.csv)|*.csv";
				saveFileDialog.FilterIndex = 2;
				saveFileDialog.FileName = "SocketPartChange_All_" + DateTime.Now.ToString("yyyy-MM-dd");
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					filename = saveFileDialog.FileName;
					if (new CSVControl().generateCSV(filename, grid))
					{
						MessageBox.Show("Success to Save CSV");
						return;
					}
					MessageBox.Show("Fail to Save CSV");
				}
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00016198 File Offset: 0x00014398
		private void Clear()
		{
			this.l_bib_No.Text = "";
			this.l_device.Text = "";
			this.l_customer.Text = "";
			this.l_barcode.Text = "";
			this.lbl_SocketNo.Text = "";
			this.lbl_CntOfChange.Text = "";
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00016208 File Offset: 0x00014408
		private void Search(string biBoardNo, string dateFrom, string dateTo)
		{
			this.ResetGrid(this.grid_PartChangeHistory);
			this.tb_biboardno.Text = biBoardNo;
			this._cBIBoardInfo = this._instance.GetBIBoardInfo_withPartChangeHistory(biBoardNo, dateFrom, dateTo);
			if (this._cBIBoardInfo == null)
			{
				MessageBox.Show("No Information");
				return;
			}
			if (this._cBIBoardInfo.cSocketPartChanges == null)
			{
				MessageBox.Show("No Information");
				return;
			}
			this.l_bib_No.Text = this._cBIBoardInfo.strBibNo;
			this.l_device.Text = this._cBIBoardInfo.strDevice;
			this.l_customer.Text = this._cBIBoardInfo.strCustomer;
			this.l_barcode.Text = this._cBIBoardInfo.strBarcode;
			if (this._cBIBoardInfo.cSocketPartChanges.Count != 0)
			{
				this.SetGrid_PartChangeHistory(this._cBIBoardInfo.cSocketPartChanges, this.grid_PartChangeHistory);
				this.lbl_SocketNo.Text = "ALL";
				this.lbl_CntOfChange.Text = this._cBIBoardInfo.cSocketPartChanges.Count.ToString();
				this.combo_PartChange_Category.SelectedIndex = this.combo_PartChange_Category.FindString("ALL");
				return;
			}
			MessageBox.Show("No history");
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0001634C File Offset: 0x0001454C
		private void Refresh_Part()
		{
			this.Clear();
			string text = this.tb_biboardno.Text;
			if (text == "")
			{
				return;
			}
			int num = text.IndexOf("#");
			if (num != -1)
			{
				if (num != 0)
				{
					return;
				}
				text = text.Substring(1, text.Length - 1);
			}
			string dateFrom = this.dtPicker_DateFrom.Value.ToString("yyyy-MM-dd");
			string dateTo = this.dtPicker_DateTo.Value.ToString("yyyy-MM-dd");
			this.Search(text, dateFrom, dateTo);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000163DC File Offset: 0x000145DC
		private Grid Search_All(string dateFrom, string dateTo)
		{
			Grid grid = new Grid();
			CBIBoardInfo biboardInfo_withPartChangeHistory_All = this._instance.GetBIBoardInfo_withPartChangeHistory_All(dateFrom, dateTo);
			if (biboardInfo_withPartChangeHistory_All == null)
			{
				MessageBox.Show("No Information");
				return null;
			}
			if (biboardInfo_withPartChangeHistory_All.cSocketPartChanges == null)
			{
				MessageBox.Show("No Information");
				return null;
			}
			if (biboardInfo_withPartChangeHistory_All.cSocketPartChanges.Count != 0)
			{
				this.ResetGrid(grid);
				this.SetGrid_PartChangeHistory(biboardInfo_withPartChangeHistory_All.cSocketPartChanges, grid);
			}
			return grid;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00016444 File Offset: 0x00014644
		private List<CSocketPartChange> SetGridData(string socketNo, string category)
		{
			if (socketNo == "ALL")
			{
				if (category == "ALL")
				{
					return this._cBIBoardInfo.cSocketPartChanges;
				}
				return (from o in this._cBIBoardInfo.cSocketPartChanges
				where o.strCategory == category
				select o).ToList<CSocketPartChange>();
			}
			else
			{
				int iSocketNo = int.Parse(socketNo);
				if (category == "ALL")
				{
					return (from o in this._cBIBoardInfo.cSocketPartChanges
					where o.iSocketNo == iSocketNo
					select o).ToList<CSocketPartChange>();
				}
				return (from o in this._cBIBoardInfo.cSocketPartChanges
				where o.iSocketNo == iSocketNo && o.strCategory == category
				select o).ToList<CSocketPartChange>();
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00016520 File Offset: 0x00014720
		private int Delete_PChange(int id)
		{
			int result = -1;
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Socket] @flag = 'DELETE_PART_CHANGE', @groupId = 0, @pId = " + id.ToString();
			dataSet = this._instance.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					result = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
				}
			}
			return result;
		}

		// Token: 0x040001AB RID: 427
		private SourceGrid.Cells.Views.Cell cell_center;

		// Token: 0x040001AC RID: 428
		private SourceGrid.Cells.Views.Cell cell_good;

		// Token: 0x040001AD RID: 429
		private SourceGrid.Cells.Views.Cell cell_bad;

		// Token: 0x040001AE RID: 430
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x040001AF RID: 431
		private SourceGrid.Cells.Views.Cell cell_header2;

		// Token: 0x040001B0 RID: 432
		private SourceGrid.Cells.Views.Cell cell_header3;

		// Token: 0x040001B1 RID: 433
		private SourceGrid.Cells.Views.Cell cell_body1;

		// Token: 0x040001B2 RID: 434
		private SourceGrid.Cells.Views.Cell cell_body2;

		// Token: 0x040001B3 RID: 435
		private SourceGrid.Cells.Views.Cell cell_onflag;

		// Token: 0x040001B4 RID: 436
		private SourceGrid.Cells.Views.Cell cell_row1;

		// Token: 0x040001B5 RID: 437
		private SourceGrid.Cells.Views.Cell cell_row2;

		// Token: 0x040001B6 RID: 438
		public BIBoardInfoModule _instance;

		// Token: 0x040001B7 RID: 439
		private string _boardNo = string.Empty;

		// Token: 0x040001B8 RID: 440
		private CBIBoardInfo _cBIBoardInfo;

		// Token: 0x040001B9 RID: 441
		private CGridIndex_BoardInfo_SocketPartChange _cGridIndex_SPC;

		// Token: 0x040001BA RID: 442
		private ArrayList _alCategories;
	}
}
