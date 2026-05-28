using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using DATA;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms.TabPages
{
	// Token: 0x0200002C RID: 44
	public class Tab_Unload : Tab_Base
	{
		// Token: 0x06000149 RID: 329 RVA: 0x0001BE0C File Offset: 0x0001A00C
		public Tab_Unload(string title)
		{
			this.Text = title;
			this.InitializeComponent();
			this.InitGridCell();
			this._instance = BIBoardInfoModule._instance;
			this._slResults = new SortedList();
			this.Clear();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0001BE44 File Offset: 0x0001A044
		private void tb_LotNo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				string text = this.tb_LotNo.Text;
				if (text == "")
				{
					MessageBox.Show("Input Lot No.");
					return;
				}
				this.SeatchLot(text);
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0001BE88 File Offset: 0x0001A088
		private void pb_Search_MouseUp(object sender, MouseEventArgs e)
		{
			string text = this.tb_LotNo.Text;
			if (text == "")
			{
				MessageBox.Show("Input Lot No.");
				return;
			}
			string text2 = this.tb_bibNo.Text;
			if (text2 == "")
			{
				MessageBox.Show("Input Board No.");
				return;
			}
			this.tb_bibNo.SelectAll();
			int num;
			if (!int.TryParse(text2, out num))
			{
				MessageBox.Show("Input Number only!");
				this.tb_bibNo.SelectAll();
				return;
			}
			if (this._fileInfos == null)
			{
				this.SeatchLot(text);
			}
			this._boardInfos = this._instance.GetBinSort_BoardInfo(text, num);
			if (this._boardInfos.Count == 0)
			{
				MessageBox.Show("No Board information");
				this.tb_bibNo.SelectAll();
				return;
			}
			DateTime d = DateTime.Now.AddDays(-24.0);
			int num2 = (int)(this._boardInfos[0].dtPmDate - d).TotalDays;
			string empty = string.Empty;
			if (num2 <= 0)
			{
				MessageBox.Show(this._boardInfos[0].strBibNo + " : " + (-1 * num2).ToString() + " days passed since Inspection(Min. 24 days). Need to Inspect!" + "\nLast Inspection : " + this._boardInfos[0].dtPmDate.ToString("yyyy-MM-dd"));
				this._boardInfos[0].iInsptNeeded = 1;
			}
			else
			{
				this._boardInfos[0].iInsptNeeded = 0;
			}
			if (this._boardInfos[0].strBarcode != "")
			{
				this.l_Barcode.Text = this._boardInfos[0].strBarcode;
			}
			this._socketInfos = this._instance.GetBinSort_SocketInfo(this._boardInfos[0].iBoardId);
			if (this._socketInfos.Count == 0)
			{
				MessageBox.Show("No Socket Information");
				this.tb_bibNo.SelectAll();
				return;
			}
			this.ResetGrid(this.grid_BinSort_Layout);
			this.SetGrid_BinSortLayout(this._socketInfos);
			this.SetResult(num);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0001C0B4 File Offset: 0x0001A2B4
		private void tb_bibNo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				string text = this.tb_LotNo.Text;
				if (text == "")
				{
					MessageBox.Show("Input Lot No.");
					return;
				}
				string text2 = this.tb_bibNo.Text;
				if (text2 == "")
				{
					MessageBox.Show("Input Board No.");
					return;
				}
				this.tb_bibNo.SelectAll();
				int num;
				if (!int.TryParse(text2, out num))
				{
					MessageBox.Show("Input Number only!");
					this.tb_bibNo.SelectAll();
					return;
				}
				if (this._fileInfos == null)
				{
					this.SeatchLot(text);
				}
				this._boardInfos = this._instance.GetBinSort_BoardInfo(text, num);
				if (this._boardInfos.Count == 0)
				{
					MessageBox.Show("No Board information");
					this.tb_bibNo.SelectAll();
					return;
				}
				DateTime d = DateTime.Now.AddDays(-24.0);
				int num2 = (int)(this._boardInfos[0].dtPmDate - d).TotalDays;
				string empty = string.Empty;
				if (num2 <= 0)
				{
					MessageBox.Show(this._boardInfos[0].strBibNo + " : " + (-1 * num2).ToString() + " days passed since Inspection(Min. 24 days). Need to Inspect!" + "\nLast Inspection : " + this._boardInfos[0].dtPmDate.ToString("yyyy-MM-dd"));
					this._boardInfos[0].iInsptNeeded = 1;
				}
				else
				{
					this._boardInfos[0].iInsptNeeded = 0;
				}
				if (this._boardInfos[0].strBarcode != "")
				{
					this.l_Barcode.Text = this._boardInfos[0].strBarcode;
				}
				this._socketInfos = this._instance.GetBinSort_SocketInfo(this._boardInfos[0].iBoardId);
				if (this._socketInfos.Count == 0)
				{
					MessageBox.Show("No Socket Information");
					this.tb_bibNo.SelectAll();
					return;
				}
				this.ResetGrid(this.grid_BinSort_Layout);
				this.SetGrid_BinSortLayout(this._socketInfos);
				this.SetResult(num);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0001C2EC File Offset: 0x0001A4EC
		private void InitGridCell()
		{
			Color color = Color.FromArgb(255, 255, 255);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			this.cell_center = new SourceGrid.Cells.Views.Cell();
			this.cell_center.BackColor = color;
			this.cell_center.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center.Border = rectangleBorder;
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
			Color color4 = Color.FromArgb(255, 234, 167);
			RectangleBorder rectangleBorder4 = new RectangleBorder(new BorderLine(color4), new BorderLine(color4));
			this.cell_body1 = new SourceGrid.Cells.Views.Cell();
			this.cell_body1.BackColor = color4;
			this.cell_body1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_body1.Border = rectangleBorder4;
			Color color5 = Color.FromArgb(225, 112, 85);
			RectangleBorder rectangleBorder5 = new RectangleBorder(new BorderLine(color5), new BorderLine(color5));
			this.cell_header3 = new SourceGrid.Cells.Views.Cell();
			this.cell_header3.BackColor = color5;
			this.cell_header3.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_header3.Border = rectangleBorder5;
			Color color6 = Color.FromArgb(250, 177, 160);
			RectangleBorder rectangleBorder6 = new RectangleBorder(new BorderLine(color6), new BorderLine(color6));
			this.cell_body2 = new SourceGrid.Cells.Views.Cell();
			this.cell_body2.BackColor = color6;
			this.cell_body2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_body2.Border = rectangleBorder6;
			Color color7 = Color.FromArgb(253, 203, 110);
			RectangleBorder rectangleBorder7 = new RectangleBorder(new BorderLine(color7), new BorderLine(color7));
			this.cell_onflag = new SourceGrid.Cells.Views.Cell();
			this.cell_onflag.BackColor = color7;
			this.cell_onflag.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_onflag.Border = rectangleBorder7;
			Color color8 = Color.FromArgb(255, 255, 255);
			RectangleBorder rectangleBorder8 = new RectangleBorder(new BorderLine(color8), new BorderLine(color8));
			this.cell_row1 = new SourceGrid.Cells.Views.Cell();
			this.cell_row1.BackColor = color8;
			this.cell_row1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row1.Border = rectangleBorder8;
			Color color9 = Color.FromArgb(255, 234, 167);
			RectangleBorder rectangleBorder9 = new RectangleBorder(new BorderLine(color9), new BorderLine(color9));
			this.cell_row2 = new SourceGrid.Cells.Views.Cell();
			this.cell_row2.BackColor = color9;
			this.cell_row2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row2.Border = rectangleBorder9;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0001C658 File Offset: 0x0001A858
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

		// Token: 0x0600014F RID: 335 RVA: 0x0001C6A0 File Offset: 0x0001A8A0
		private void SetGrid_BinSortLayout(List<CBinSort_SocketInfo> socketInfos)
		{
			int count = socketInfos.Count;
			int num = 4;
			int num2 = 4;
			int num3 = num * num2 + 1;
			int num4 = 4;
			int num5 = count / num * num4;
			this.grid_BinSort_Layout.ColumnsCount = num5;
			this.grid_BinSort_Layout.FixedRows = 1;
			this.grid_BinSort_Layout.FixedColumns = 0;
			this.grid_BinSort_Layout.Rows.Insert(0);
			for (int i = 0; i < num5; i++)
			{
				this.grid_BinSort_Layout[0, i] = new SourceGrid.Cells.ColumnHeader("");
				this.grid_BinSort_Layout[0, i].View = this.cell_center;
			}
			for (int j = 1; j <= num3; j++)
			{
				this.grid_BinSort_Layout.Rows.Insert(j);
			}
			int num6 = 1;
			int num7 = num5 - 3;
			foreach (CBinSort_SocketInfo cbinSort_SocketInfo in socketInfos)
			{
				CBinSort_BinProperty gridColor = this.GetGridColor(cbinSort_SocketInfo.strBinNo);
				Color color = Color.FromArgb(231, 76, 60);
				if (gridColor != null)
				{
					color = Color.FromArgb(gridColor.iColor_r, gridColor.iColor_g, gridColor.iColor_b);
				}
				RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
				SourceGrid.Cells.Views.Cell cell = new SourceGrid.Cells.Views.Cell();
				cell.BackColor = color;
				cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				cell.Border = rectangleBorder;
				cell.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
				cell.ImageStretch = false;
				int iSockNo = cbinSort_SocketInfo.iSockNo;
				string cellValue = "Socket " + iSockNo.ToString();
				this.grid_BinSort_Layout[num6, num7 - 1] = new SourceGrid.Cells.Cell(cellValue);
				this.grid_BinSort_Layout[num6, num7 - 1].View = this.cell_header1;
				this.grid_BinSort_Layout[num6, num7 - 1].ColumnSpan = num4 - 1;
				this.grid_BinSort_Layout[num6 + 1, num7 - 1] = new SourceGrid.Cells.Cell("");
				this.grid_BinSort_Layout[num6 + 1, num7 - 1].View = this.cell_center;
				this.grid_BinSort_Layout[num6 + 1, num7 - 1].ColumnSpan = num4 - 1;
				this.grid_BinSort_Layout[num6 + 2, num7 - 1] = new SourceGrid.Cells.Cell("");
				this.grid_BinSort_Layout[num6 + 2, num7 - 1].View = this.cell_center;
				this.grid_BinSort_Layout[num6 + 2, num7] = new SourceGrid.Cells.Cell(cbinSort_SocketInfo.strBinNo);
				this.grid_BinSort_Layout[num6 + 2, num7].View = cell;
				this.grid_BinSort_Layout[num6 + 2, num7 + 1] = new SourceGrid.Cells.Cell("");
				this.grid_BinSort_Layout[num6 + 2, num7 + 1].View = this.cell_center;
				this.grid_BinSort_Layout[num6 + 3, num7 - 1] = new SourceGrid.Cells.Cell("");
				this.grid_BinSort_Layout[num6 + 3, num7 - 1].View = this.cell_center;
				this.grid_BinSort_Layout[num6 + 3, num7 - 1].ColumnSpan = num4 - 1;
				num6 += num2;
				if (num6 > num2 * num)
				{
					num6 = 1;
					num7 -= num4;
				}
			}
			for (int k = 0; k < num3; k += 2)
			{
				this.grid_BinSort_Layout.Rows[k].Height = 10;
			}
			for (int l = 0; l < num5; l++)
			{
				if ((l + 1) % 4 == 0)
				{
					this.grid_BinSort_Layout.Columns[l].Width = 20;
				}
				else
				{
					this.grid_BinSort_Layout.Columns[l].Width = 40;
				}
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0001CA98 File Offset: 0x0001AC98
		private void SetGrid_BinSortBinning_Pre()
		{
			int num = 0;
			if (this._total_Sum != null)
			{
				num = this._total_Sum.binningInfos.Count + 1;
				this.grid_BinSort_Summary.ColumnsCount = num;
				this.grid_BinSort_Summary.FixedRows = 1;
				this.grid_BinSort_Summary.FixedColumns = 0;
				this.grid_BinSort_Summary.Rows.Insert(0);
				this.grid_BinSort_Summary.Rows.Insert(0);
				this.grid_BinSort_Summary.Rows.Insert(0);
				this.grid_BinSort_Summary.Rows.Insert(0);
				this.grid_BinSort_Summary[0, 0] = new SourceGrid.Cells.ColumnHeader("BIN NO");
				this.grid_BinSort_Summary[0, 0].View = this.cell_header1;
				this.grid_BinSort_Summary[1, 0] = new SourceGrid.Cells.Cell("BOARD");
				this.grid_BinSort_Summary[1, 0].View = this.cell_header2;
				this.grid_BinSort_Summary[2, 0] = new SourceGrid.Cells.Cell("ACCUM");
				this.grid_BinSort_Summary[2, 0].View = this.cell_header2;
				this.grid_BinSort_Summary[3, 0] = new SourceGrid.Cells.Cell("TOTAL");
				this.grid_BinSort_Summary[3, 0].View = this.cell_header2;
				foreach (CBinSort_BinningInfo cbinSort_BinningInfo in this._total_Sum.binningInfos)
				{
					CBinSort_BinProperty gridIdx = this.GetGridIdx(cbinSort_BinningInfo.strBinNo);
					this.grid_BinSort_Summary[0, gridIdx.iIndex] = new SourceGrid.Cells.ColumnHeader(cbinSort_BinningInfo.strBinNo);
					this.grid_BinSort_Summary[0, gridIdx.iIndex].View = this.cell_header1;
					this.grid_BinSort_Summary[1, gridIdx.iIndex] = new SourceGrid.Cells.Cell(0, typeof(int));
					this.grid_BinSort_Summary[1, gridIdx.iIndex].View = this.cell_center;
					this.grid_BinSort_Summary[2, gridIdx.iIndex] = new SourceGrid.Cells.Cell(0, typeof(int));
					this.grid_BinSort_Summary[2, gridIdx.iIndex].View = this.cell_center;
					this.grid_BinSort_Summary[3, gridIdx.iIndex] = new SourceGrid.Cells.Cell(cbinSort_BinningInfo.iCount, typeof(int));
					this.grid_BinSort_Summary[3, gridIdx.iIndex].View = this.cell_center;
				}
			}
			for (int i = 0; i < num; i++)
			{
				this.grid_BinSort_Summary.Columns[i].Width = 70;
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0001CD80 File Offset: 0x0001AF80
		private void SetGrid_BinSortBinning_Session()
		{
			if (this._total_Board != null)
			{
				for (int i = 1; i < this.grid_BinSort_Summary.Columns.Count; i++)
				{
					this.grid_BinSort_Summary[1, i].Value = 0;
				}
				foreach (CBinSort_BinningInfo cbinSort_BinningInfo in this._total_Board.binningInfos)
				{
					CBinSort_BinProperty gridIdx = this.GetGridIdx(cbinSort_BinningInfo.strBinNo);
					if (gridIdx == null)
					{
						MessageBox.Show("The board unloaded desn't include in the latest result");
						break;
					}
					this.grid_BinSort_Summary[1, gridIdx.iIndex].Value = cbinSort_BinningInfo.iCount;
				}
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0001CE50 File Offset: 0x0001B050
		private void SetGrid_BinSortBinning_Session_Accum()
		{
			if (this._total_Accum != null)
			{
				foreach (CBinSort_BinningInfo cbinSort_BinningInfo in this._total_Accum.binningInfos)
				{
					CBinSort_BinProperty gridIdx = this.GetGridIdx(cbinSort_BinningInfo.strBinNo);
					if (gridIdx == null)
					{
						break;
					}
					this.grid_BinSort_Summary[2, gridIdx.iIndex].Value = cbinSort_BinningInfo.iCount;
				}
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0001CEE0 File Offset: 0x0001B0E0
		private void Clear()
		{
			this.l_Lot_No.Text = "";
			this.l_Operation.Text = "";
			this.l_Operator.Text = "";
			this.l_Barcode.Text = "";
			this.l_Tester.Text = "";
			this.l_FileName.Text = "";
			this.l_FileDate.Text = "";
			this.tb_bibNo.Text = "";
			this._fileInfos = null;
			this._boardInfos = null;
			this._socketInfos = null;
			this._total_Sum = null;
			this._total_Board = null;
			this._total_Accum = null;
			this._slResults.Clear();
			this.ResetGrid(this.grid_BinSort_Layout);
			this.ResetGrid(this.grid_BinSort_Summary);
			this.lv_Sequence.Items.Clear();
			this.pb_Session_Info.BackColor = Color.FromArgb(189, 195, 199);
			this.tb_Session_Info.BackColor = Color.White;
			this.tb_Session_Info.ForeColor = Color.Black;
			this.tb_Session_Info.Text = "On Going";
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0001D01C File Offset: 0x0001B21C
		private void SeatchLot(string lotNo)
		{
			this.Clear();
			this._fileInfos = this._instance.GetBinSort_FileInfo(lotNo);
			if (this._fileInfos.Count == 0)
			{
				MessageBox.Show("No Results");
				this.tb_LotNo.SelectAll();
				return;
			}
			this.l_Lot_No.Text = this._fileInfos[0].strLotNo;
			this.l_Operation.Text = this._fileInfos[0].strOpr;
			this.l_Operator.Text = this._fileInfos[0].strBadgeNo;
			this.l_Tester.Text = this._fileInfos[0].strTesterName;
			this.l_FileName.Text = this._fileInfos[0].strFileName;
			this.l_FileDate.Text = this._fileInfos[0].dtIntime.ToString("yyyy-MM-dd HH:mm:ss");
			this.tb_bibNo.Select();
			this._total_Sum = this._instance.GetBinSort_BinningInfo_Sum_File(this._fileInfos[0].iProcessId, this._fileInfos[0].iId);
			this.ResetGrid(this.grid_BinSort_Summary);
			this.SetGrid_BinSortBinning_Pre();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001D168 File Offset: 0x0001B368
		private CBinSort_BinProperty GetGridIdx(string binNo)
		{
			CBinSort_BinProperty result = null;
			foreach (CBinSort_BinProperty cbinSort_BinProperty in this._instance._BinSort_Grids)
			{
				if (binNo == cbinSort_BinProperty.strBinNo)
				{
					result = cbinSort_BinProperty;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0001D1D0 File Offset: 0x0001B3D0
		private CBinSort_BinProperty GetGridColor(string binNo)
		{
			CBinSort_BinProperty result = null;
			foreach (CBinSort_BinProperty cbinSort_BinProperty in this._instance._BinSort_Grids_Ref)
			{
				if (binNo == cbinSort_BinProperty.strBinNo)
				{
					result = cbinSort_BinProperty;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0001D238 File Offset: 0x0001B438
		private void SetResult(int boardNo)
		{
			if (this._slResults.ContainsKey(boardNo))
			{
				return;
			}
			this._total_Board = this._instance.GetBinSort_BinningInfo_Board(this._boardInfos[0].iBoardId);
			if (this._total_Board != null)
			{
				if (this._total_Accum == null)
				{
					this._total_Accum = new CSessionTotal(this._total_Board);
				}
				else
				{
					this._total_Accum.iTotal += this._total_Board.iTotal;
					this._total_Accum.iGood += this._total_Board.iGood;
					this._total_Accum.iFail += this._total_Board.iFail;
					bool flag = false;
					foreach (CBinSort_BinningInfo cbinSort_BinningInfo in this._total_Board.binningInfos)
					{
						flag = false;
						foreach (CBinSort_BinningInfo cbinSort_BinningInfo2 in this._total_Accum.binningInfos)
						{
							if (cbinSort_BinningInfo.strBinNo == cbinSort_BinningInfo2.strBinNo)
							{
								cbinSort_BinningInfo2.iCount += cbinSort_BinningInfo.iCount;
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							CBinSort_BinningInfo cbinSort_BinningInfo3 = new CBinSort_BinningInfo();
							cbinSort_BinningInfo3.strBinNo = cbinSort_BinningInfo.strBinNo;
							cbinSort_BinningInfo3.iCount = cbinSort_BinningInfo.iCount;
							this._total_Accum.binningInfos.Add(cbinSort_BinningInfo3);
						}
					}
				}
				this._slResults.Add(boardNo, this._total_Board);
				ListViewItem listViewItem = new ListViewItem(new string[]
				{
					(this.lv_Sequence.Items.Count + 1).ToString(),
					boardNo.ToString(),
					this._boardInfos[0].iSlotNo.ToString(),
					this._boardInfos[0].iZoneNo.ToString()
				});
				if (this._boardInfos[0].iInsptNeeded == 1)
				{
					listViewItem.BackColor = Color.FromArgb(217, 128, 250);
				}
				this.lv_Sequence.Items.Add(listViewItem);
				this.lv_Sequence.Items[this.lv_Sequence.Items.Count - 1].EnsureVisible();
			}
			if (this._total_Sum.iTotal == this._total_Accum.iTotal)
			{
				this.pb_Session_Info.BackColor = Color.FromArgb(46, 204, 113);
				this.tb_Session_Info.BackColor = Color.FromArgb(46, 204, 113);
				this.tb_Session_Info.ForeColor = Color.White;
				this.tb_Session_Info.Text = "Completed";
				this.tb_LotNo.SelectAll();
			}
			this.SetGrid_BinSortBinning_Session();
			this.SetGrid_BinSortBinning_Session_Accum();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0001D554 File Offset: 0x0001B754
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0001D574 File Offset: 0x0001B774
		private void InitializeComponent()
		{
			this.groupBox2 = new GroupBox();
			this.tb_LotNo = new TextBox();
			this.groupBox3 = new GroupBox();
			this.l_Tester = new Label();
			this.label8 = new Label();
			this.l_Barcode = new Label();
			this.label2 = new Label();
			this.l_Operator = new Label();
			this.label7 = new Label();
			this.l_FileDate = new Label();
			this.label6 = new Label();
			this.l_Operation = new Label();
			this.l_FileName = new Label();
			this.l_Lot_No = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label5 = new Label();
			this.groupBox1 = new GroupBox();
			this.pb_Search = new PictureBox();
			this.groupBox4 = new GroupBox();
			this.tb_bibNo = new TextBox();
			this.grid_BinSort_Layout = new Grid();
			this.groupBox5 = new GroupBox();
			this.panel2 = new Panel();
			this.groupBox6 = new GroupBox();
			this.panel3 = new Panel();
			this.grid_BinSort_Summary = new Grid();
			this.groupBox7 = new GroupBox();
			this.panel4 = new Panel();
			this.lv_Sequence = new ListView();
			this.NO = new System.Windows.Forms.ColumnHeader();
			this.BOARD_NO = new System.Windows.Forms.ColumnHeader();
			this.SLOT_NO = new System.Windows.Forms.ColumnHeader();
			this.ZONE_NO = new System.Windows.Forms.ColumnHeader();
			this.groupBox8 = new GroupBox();
			this.tb_Session_Info = new TextBox();
			this.pb_Session_Info = new PictureBox();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.pb_Search).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((ISupportInitialize)this.pb_Session_Info).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox8);
			this.panel1.Controls.Add(this.groupBox7);
			this.panel1.Controls.Add(this.groupBox6);
			this.panel1.Controls.Add(this.groupBox5);
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Size = new Size(1128, 609);
			this.groupBox2.Controls.Add(this.tb_LotNo);
			this.groupBox2.Font = new Font("Segoe UI", 9f);
			this.groupBox2.Location = new Point(6, 8);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Size = new Size(237, 70);
			this.groupBox2.TabIndex = 33;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Lot No";
			this.tb_LotNo.Location = new Point(19, 29);
			this.tb_LotNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_LotNo.Name = "tb_LotNo";
			this.tb_LotNo.Size = new Size(198, 23);
			this.tb_LotNo.TabIndex = 36;
			this.tb_LotNo.KeyDown += this.tb_LotNo_KeyDown;
			this.groupBox3.Controls.Add(this.l_Tester);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.l_Barcode);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.l_Operator);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.l_FileDate);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.l_Operation);
			this.groupBox3.Controls.Add(this.l_FileName);
			this.groupBox3.Controls.Add(this.l_Lot_No);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox3.Location = new Point(6, 85);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Size = new Size(1116, 95);
			this.groupBox3.TabIndex = 36;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "BI Board Information";
			this.l_Tester.AutoSize = true;
			this.l_Tester.Location = new Point(1031, 30);
			this.l_Tester.Name = "l_Tester";
			this.l_Tester.Size = new Size(34, 15);
			this.l_Tester.TabIndex = 14;
			this.l_Tester.Text = "MCC";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(966, 30);
			this.label8.Name = "label8";
			this.label8.Size = new Size(44, 15);
			this.label8.TabIndex = 13;
			this.label8.Text = "Tester :";
			this.l_Barcode.AutoSize = true;
			this.l_Barcode.Location = new Point(815, 30);
			this.l_Barcode.Name = "l_Barcode";
			this.l_Barcode.Size = new Size(79, 15);
			this.l_Barcode.TabIndex = 12;
			this.l_Barcode.Text = "ABBURN IN-7";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(741, 30);
			this.label2.Name = "label2";
			this.label2.Size = new Size(56, 15);
			this.label2.TabIndex = 11;
			this.label2.Text = "Barcode :";
			this.l_Operator.AutoSize = true;
			this.l_Operator.Location = new Point(618, 30);
			this.l_Operator.Name = "l_Operator";
			this.l_Operator.Size = new Size(43, 15);
			this.l_Operator.TabIndex = 10;
			this.l_Operator.Text = "123123";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(521, 30);
			this.label7.Name = "label7";
			this.label7.Size = new Size(79, 15);
			this.label7.TabIndex = 9;
			this.label7.Text = "Operator No :";
			this.l_FileDate.AutoSize = true;
			this.l_FileDate.Location = new Point(96, 64);
			this.l_FileDate.Name = "l_FileDate";
			this.l_FileDate.Size = new Size(95, 15);
			this.l_FileDate.TabIndex = 8;
			this.l_FileDate.Text = "2019-05-27 14:00";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(23, 64);
			this.label6.Name = "label6";
			this.label6.Size = new Size(58, 15);
			this.label6.TabIndex = 7;
			this.label6.Text = "File Date :";
			this.l_Operation.AutoSize = true;
			this.l_Operation.Location = new Point(390, 30);
			this.l_Operation.Name = "l_Operation";
			this.l_Operation.Size = new Size(54, 15);
			this.l_Operation.TabIndex = 6;
			this.l_Operation.Text = "BI/TEST1";
			this.l_FileName.AutoSize = true;
			this.l_FileName.Location = new Point(390, 64);
			this.l_FileName.Name = "l_FileName";
			this.l_FileName.Size = new Size(32, 15);
			this.l_FileName.TabIndex = 5;
			this.l_FileName.Text = "file...";
			this.l_Lot_No.AutoSize = true;
			this.l_Lot_No.Location = new Point(96, 30);
			this.l_Lot_No.Name = "l_Lot_No";
			this.l_Lot_No.Size = new Size(173, 15);
			this.l_Lot_No.TabIndex = 4;
			this.l_Lot_No.Text = "Q00FC910W6X.0100#T8H643.00";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(306, 30);
			this.label4.Name = "label4";
			this.label4.Size = new Size(69, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Operation : ";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(306, 64);
			this.label3.Name = "label3";
			this.label3.Size = new Size(69, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "File Name : ";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(23, 30);
			this.label5.Name = "label5";
			this.label5.Size = new Size(49, 15);
			this.label5.TabIndex = 0;
			this.label5.Text = "Lot No :";
			this.groupBox1.Controls.Add(this.pb_Search);
			this.groupBox1.Location = new Point(409, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(68, 70);
			this.groupBox1.TabIndex = 37;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.pb_Search.Cursor = Cursors.Hand;
			this.pb_Search.Image = Resources.lothistory;
			this.pb_Search.Location = new Point(18, 22);
			this.pb_Search.Name = "pb_Search";
			this.pb_Search.Size = new Size(32, 33);
			this.pb_Search.TabIndex = 0;
			this.pb_Search.TabStop = false;
			this.pb_Search.MouseUp += this.pb_Search_MouseUp;
			this.groupBox4.Controls.Add(this.tb_bibNo);
			this.groupBox4.Font = new Font("Segoe UI", 9f);
			this.groupBox4.Location = new Point(249, 8);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox4.Size = new Size(154, 70);
			this.groupBox4.TabIndex = 34;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "BI Board No.";
			this.tb_bibNo.Location = new Point(19, 29);
			this.tb_bibNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_bibNo.Name = "tb_bibNo";
			this.tb_bibNo.Size = new Size(114, 23);
			this.tb_bibNo.TabIndex = 36;
			this.tb_bibNo.KeyDown += this.tb_bibNo_KeyDown;
			this.grid_BinSort_Layout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_BinSort_Layout.Dock = DockStyle.Fill;
			this.grid_BinSort_Layout.EnableSort = true;
			this.grid_BinSort_Layout.Font = new Font("Segoe UI", 9f);
			this.grid_BinSort_Layout.Location = new Point(3, 3);
			this.grid_BinSort_Layout.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_BinSort_Layout.Name = "grid_BinSort_Layout";
			this.grid_BinSort_Layout.OptimizeMode = CellOptimizeMode.ForRows;
			this.grid_BinSort_Layout.SelectionMode = GridSelectionMode.Cell;
			this.grid_BinSort_Layout.Size = new Size(854, 280);
			this.grid_BinSort_Layout.TabIndex = 40;
			this.grid_BinSort_Layout.TabStop = true;
			this.grid_BinSort_Layout.ToolTipText = "";
			this.groupBox5.Controls.Add(this.panel2);
			this.groupBox5.Location = new Point(6, 187);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(866, 308);
			this.groupBox5.TabIndex = 41;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Layout for Bin";
			this.panel2.Controls.Add(this.grid_BinSort_Layout);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(3, 19);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(3);
			this.panel2.Size = new Size(860, 286);
			this.panel2.TabIndex = 0;
			this.groupBox6.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			this.groupBox6.Controls.Add(this.panel3);
			this.groupBox6.Location = new Point(6, 501);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new Size(866, 102);
			this.groupBox6.TabIndex = 42;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Bin Result";
			this.panel3.Controls.Add(this.grid_BinSort_Summary);
			this.panel3.Dock = DockStyle.Fill;
			this.panel3.Location = new Point(3, 19);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(3);
			this.panel3.Size = new Size(860, 80);
			this.panel3.TabIndex = 0;
			this.grid_BinSort_Summary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_BinSort_Summary.Dock = DockStyle.Fill;
			this.grid_BinSort_Summary.EnableSort = true;
			this.grid_BinSort_Summary.Font = new Font("Segoe UI", 9f);
			this.grid_BinSort_Summary.Location = new Point(3, 3);
			this.grid_BinSort_Summary.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_BinSort_Summary.Name = "grid_BinSort_Summary";
			this.grid_BinSort_Summary.OptimizeMode = CellOptimizeMode.ForRows;
			this.grid_BinSort_Summary.SelectionMode = GridSelectionMode.Cell;
			this.grid_BinSort_Summary.Size = new Size(854, 74);
			this.grid_BinSort_Summary.TabIndex = 41;
			this.grid_BinSort_Summary.TabStop = true;
			this.grid_BinSort_Summary.ToolTipText = "";
			this.groupBox7.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			this.groupBox7.Controls.Add(this.panel4);
			this.groupBox7.Location = new Point(878, 187);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new Size(244, 416);
			this.groupBox7.TabIndex = 43;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Sequence";
			this.panel4.Controls.Add(this.lv_Sequence);
			this.panel4.Dock = DockStyle.Fill;
			this.panel4.Location = new Point(3, 19);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(3);
			this.panel4.Size = new Size(238, 394);
			this.panel4.TabIndex = 0;
			this.lv_Sequence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_Sequence.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
			{
				this.NO,
				this.BOARD_NO,
				this.SLOT_NO,
				this.ZONE_NO
			});
			this.lv_Sequence.Dock = DockStyle.Fill;
			this.lv_Sequence.Location = new Point(3, 3);
			this.lv_Sequence.Name = "lv_Sequence";
			this.lv_Sequence.Size = new Size(232, 388);
			this.lv_Sequence.TabIndex = 1;
			this.lv_Sequence.UseCompatibleStateImageBehavior = false;
			this.lv_Sequence.View = View.Details;
			this.NO.Text = "NO";
			this.NO.Width = 36;
			this.BOARD_NO.Text = "BOARD #";
			this.BOARD_NO.Width = 72;
			this.SLOT_NO.Text = "SLOT #";
			this.SLOT_NO.Width = 62;
			this.ZONE_NO.Text = "ZONE #";
			this.groupBox8.Controls.Add(this.tb_Session_Info);
			this.groupBox8.Controls.Add(this.pb_Session_Info);
			this.groupBox8.Font = new Font("Segoe UI", 9f);
			this.groupBox8.Location = new Point(1007, 8);
			this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox8.Size = new Size(115, 70);
			this.groupBox8.TabIndex = 44;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Session Info";
			this.tb_Session_Info.BackColor = Color.Red;
			this.tb_Session_Info.ForeColor = Color.White;
			this.tb_Session_Info.Location = new Point(21, 29);
			this.tb_Session_Info.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_Session_Info.Name = "tb_Session_Info";
			this.tb_Session_Info.ReadOnly = true;
			this.tb_Session_Info.Size = new Size(74, 23);
			this.tb_Session_Info.TabIndex = 31;
			this.tb_Session_Info.Text = "Completed";
			this.tb_Session_Info.TextAlign = HorizontalAlignment.Center;
			this.pb_Session_Info.BackColor = Color.Red;
			this.pb_Session_Info.Location = new Point(12, 22);
			this.pb_Session_Info.Name = "pb_Session_Info";
			this.pb_Session_Info.Size = new Size(90, 36);
			this.pb_Session_Info.TabIndex = 0;
			this.pb_Session_Info.TabStop = false;
			base.Name = "Tab_Unload";
			base.Size = new Size(1134, 615);
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.pb_Search).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			((ISupportInitialize)this.pb_Session_Info).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400021D RID: 541
		public BIBoardInfoModule _instance;

		// Token: 0x0400021E RID: 542
		private SourceGrid.Cells.Views.Cell cell_center;

		// Token: 0x0400021F RID: 543
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x04000220 RID: 544
		private SourceGrid.Cells.Views.Cell cell_header2;

		// Token: 0x04000221 RID: 545
		private SourceGrid.Cells.Views.Cell cell_header3;

		// Token: 0x04000222 RID: 546
		private SourceGrid.Cells.Views.Cell cell_body1;

		// Token: 0x04000223 RID: 547
		private SourceGrid.Cells.Views.Cell cell_body2;

		// Token: 0x04000224 RID: 548
		private SourceGrid.Cells.Views.Cell cell_onflag;

		// Token: 0x04000225 RID: 549
		private SourceGrid.Cells.Views.Cell cell_row1;

		// Token: 0x04000226 RID: 550
		private SourceGrid.Cells.Views.Cell cell_row2;

		// Token: 0x04000227 RID: 551
		private List<CBinSort_FileInfo> _fileInfos;

		// Token: 0x04000228 RID: 552
		private List<CBinSort_BoardInfo> _boardInfos;

		// Token: 0x04000229 RID: 553
		private List<CBinSort_SocketInfo> _socketInfos;

		// Token: 0x0400022A RID: 554
		private CSessionTotal _total_Sum;

		// Token: 0x0400022B RID: 555
		private CSessionTotal _total_Board;

		// Token: 0x0400022C RID: 556
		private CSessionTotal _total_Accum;

		// Token: 0x0400022D RID: 557
		private SortedList _slResults;

		// Token: 0x0400022E RID: 558
		private IContainer components;

		// Token: 0x0400022F RID: 559
		private GroupBox groupBox2;

		// Token: 0x04000230 RID: 560
		private TextBox tb_LotNo;

		// Token: 0x04000231 RID: 561
		private GroupBox groupBox3;

		// Token: 0x04000232 RID: 562
		private Label l_Operator;

		// Token: 0x04000233 RID: 563
		private Label label7;

		// Token: 0x04000234 RID: 564
		private Label l_FileDate;

		// Token: 0x04000235 RID: 565
		private Label label6;

		// Token: 0x04000236 RID: 566
		private Label l_Operation;

		// Token: 0x04000237 RID: 567
		private Label l_FileName;

		// Token: 0x04000238 RID: 568
		private Label l_Lot_No;

		// Token: 0x04000239 RID: 569
		private Label label4;

		// Token: 0x0400023A RID: 570
		private Label label3;

		// Token: 0x0400023B RID: 571
		private Label label5;

		// Token: 0x0400023C RID: 572
		private GroupBox groupBox1;

		// Token: 0x0400023D RID: 573
		private PictureBox pb_Search;

		// Token: 0x0400023E RID: 574
		private GroupBox groupBox4;

		// Token: 0x0400023F RID: 575
		private TextBox tb_bibNo;

		// Token: 0x04000240 RID: 576
		private Grid grid_BinSort_Layout;

		// Token: 0x04000241 RID: 577
		private Label l_Barcode;

		// Token: 0x04000242 RID: 578
		private Label label2;

		// Token: 0x04000243 RID: 579
		private GroupBox groupBox5;

		// Token: 0x04000244 RID: 580
		private Panel panel2;

		// Token: 0x04000245 RID: 581
		private GroupBox groupBox6;

		// Token: 0x04000246 RID: 582
		private Panel panel3;

		// Token: 0x04000247 RID: 583
		private Grid grid_BinSort_Summary;

		// Token: 0x04000248 RID: 584
		private GroupBox groupBox7;

		// Token: 0x04000249 RID: 585
		private Panel panel4;

		// Token: 0x0400024A RID: 586
		private ListView lv_Sequence;

		// Token: 0x0400024B RID: 587
		private System.Windows.Forms.ColumnHeader NO;

		// Token: 0x0400024C RID: 588
		private System.Windows.Forms.ColumnHeader BOARD_NO;

		// Token: 0x0400024D RID: 589
		private System.Windows.Forms.ColumnHeader SLOT_NO;

		// Token: 0x0400024E RID: 590
		private System.Windows.Forms.ColumnHeader ZONE_NO;

		// Token: 0x0400024F RID: 591
		private GroupBox groupBox8;

		// Token: 0x04000250 RID: 592
		private TextBox tb_Session_Info;

		// Token: 0x04000251 RID: 593
		private PictureBox pb_Session_Info;

		// Token: 0x04000252 RID: 594
		private Label l_Tester;

		// Token: 0x04000253 RID: 595
		private Label label8;
	}
}
