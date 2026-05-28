using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using DATA;
using ETC;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000022 RID: 34
	public partial class BIBoardPMList : Form
	{
		// Token: 0x0600009A RID: 154 RVA: 0x0000CEAB File Offset: 0x0000B0AB
		public BIBoardPMList(string biBoardNo, BIBoardInfoModule instance)
		{
			this._biBoardNo = biBoardNo;
			this._instance = instance;
			this.InitializeComponent();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000CED2 File Offset: 0x0000B0D2
		private void BIBoardPMList_Load(object sender, EventArgs e)
		{
			this.InitGridCell();
			this._gridIdx_BIBoard = new CGridIndex_BoardInfo_PMList();
			this._dtNow = DateTime.Now;
			this.Clear();
			this.GetBoard_PM();
			this.SetBoard_PM(this._biBoardNo);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000055FE File Offset: 0x000037FE
		private void BIBoardPMList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000CF08 File Offset: 0x0000B108
		private void InitGridCell()
		{
			this.cell_center1 = BIBoardInfoModule._instance._cell_center1;
			this.cell_center2 = BIBoardInfoModule._instance._cell_center2;
			this.cell_header1 = BIBoardInfoModule._instance._cell_header1;
			this.cell_onflag = BIBoardInfoModule._instance._cell_onflag;
			this._checkBox_Normal1 = BIBoardInfoModule._instance._checkBox_Normal1;
			this._checkBox_Normal2 = BIBoardInfoModule._instance._checkBox_Normal2;
			this._checkBox_OnFlag = BIBoardInfoModule._instance._checkBox_OnFlag;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000CF88 File Offset: 0x0000B188
		private void ResetGrid(Grid grid)
		{
			for (int i = grid.RowsCount - 1; i >= 0; i--)
			{
				grid.Rows.Remove(i);
			}
			grid.Selection.EnableMultiSelection = false;
			grid.BorderStyle = BorderStyle.FixedSingle;
			grid.CustomSort = true;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000CFD0 File Offset: 0x0000B1D0
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

		// Token: 0x060000A0 RID: 160 RVA: 0x0000D034 File Offset: 0x0000B234
		private void SetGridInfo(List<CBIBoardInfo> cBibInfos)
		{
			if (cBibInfos.Count == 0)
			{
				return;
			}
			this.ResetGrid(this.grid_biboard_PM_List);
			int num = 1;
			string[] headers = this._gridIdx_BIBoard.headers;
			this.SetHeaderInfo(headers, this.grid_biboard_PM_List);
			try
			{
				if (cBibInfos.Count != 0)
				{
					foreach (CBIBoardInfo cbiboardInfo in cBibInfos)
					{
						if (cbiboardInfo.iId != 0)
						{
							this.grid_biboard_PM_List.Rows.Insert(num);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iNo] = new SourceGrid.Cells.Cell(num);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridId] = new SourceGrid.Cells.Cell(cbiboardInfo.iId);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridBibNo] = new SourceGrid.Cells.Cell(cbiboardInfo.strBibNo);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridDevice] = new SourceGrid.Cells.Cell(cbiboardInfo.strDevice);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridCustomer] = new SourceGrid.Cells.Cell(cbiboardInfo.strCustomer);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridLocation] = new SourceGrid.Cells.Cell(cbiboardInfo.strLocation);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridBarcode] = new SourceGrid.Cells.Cell(cbiboardInfo.strBarcode);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridUserId] = new SourceGrid.Cells.Cell(cbiboardInfo.strUserId);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridUserName] = new SourceGrid.Cells.Cell(cbiboardInfo.strUserName);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridUserBdno] = new SourceGrid.Cells.Cell(cbiboardInfo.strUserBdno);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridComment] = new SourceGrid.Cells.Cell(cbiboardInfo.strComment);
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridPmDate] = new SourceGrid.Cells.Cell(cbiboardInfo.dtPm.ToString("yyyy-MM-dd HH:mm:ss"));
							this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridIntime] = new SourceGrid.Cells.Cell(cbiboardInfo.dtInTime.ToString("yyyy-MM-dd HH:mm:ss"));
							if (cbiboardInfo.strBad_bib == "0")
							{
								this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridBad] = new SourceGrid.Cells.Cell("");
							}
							else
							{
								this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridBad] = new SourceGrid.Cells.Cell("");
								this.grid_biboard_PM_List[num, this._gridIdx_BIBoard.iGridBad].Image = Resources.check;
							}
							for (int i = 0; i < this._gridIdx_BIBoard.headers.Length; i++)
							{
								this.grid_biboard_PM_List[num, i].View = BIBoardInfoModule._instance._cell_PmList;
							}
							num++;
						}
					}
				}
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iNo].Width = 35;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridId].Width = 45;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridBibNo].Width = 60;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridDevice].Width = 100;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridCustomer].Width = 90;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridLocation].Width = 90;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridBarcode].Width = 110;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridUserId].Width = 100;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridUserName].Width = 100;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridUserBdno].Width = 70;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridComment].Width = 70;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridPmDate].Width = 130;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridIntime].Width = 130;
				this.grid_biboard_PM_List.Columns[this._gridIdx_BIBoard.iGridBad].Width = 40;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000D574 File Offset: 0x0000B774
		private void GetBoard_PM()
		{
			this._dtNow = DateTime.Now;
			this._biBoardInfos = this._instance.GetAllBIBoardInfo();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000D594 File Offset: 0x0000B794
		private void SetBoard_PM(string biBNo)
		{
			if ((int)Math.Round((DateTime.Now - this._dtNow).TotalDays) != 0)
			{
				this.GetBoard_PM();
			}
			DateTime dtSearch = this._dtNow.AddDays(-24.0);
			this._biBoardInfos_PM = (from o in this._biBoardInfos
			where o.iOnFlag == 1 && o.dtPm < dtSearch && o.iId != 0
			orderby o.dtPm
			select o).ToList<CBIBoardInfo>();
			this.SetGridInfo(this._biBoardInfos_PM);
			string text = string.Empty;
			if (biBNo.IndexOf("#") == -1)
			{
				text = "#" + biBNo;
			}
			else
			{
				text = biBNo;
			}
			CBIBoardInfo cbiboardInfo = null;
			foreach (CBIBoardInfo cbiboardInfo2 in this._biBoardInfos_PM)
			{
				if (cbiboardInfo2.strBibNo == text)
				{
					cbiboardInfo = cbiboardInfo2;
					break;
				}
			}
			if (cbiboardInfo == null)
			{
				this.pb_PM_Info.BackColor = Color.FromArgb(39, 174, 96);
				this.tb_PM_Info.BackColor = Color.FromArgb(39, 174, 96);
				this.tb_PM_Info.Text = "NO NEED";
				this.tb_biboardno.SelectAll();
				return;
			}
			this.pb_PM_Info.BackColor = Color.Red;
			this.tb_PM_Info.BackColor = Color.Red;
			this.tb_PM_Info.Text = "NEED TO PM";
			DateTime d = this._dtNow.AddDays(-27.0);
			int num = (int)Math.Round((cbiboardInfo.dtPm - d).TotalDays);
			string empty = string.Empty;
			if (num <= 0)
			{
				MessageBox.Show(text + " : " + (-1 * num).ToString() + " days passed since Inspection. Need to Inspect!");
				this._biBoardNo = biBNo;
				base.DialogResult = DialogResult.OK;
				base.Close();
				return;
			}
			MessageBox.Show(text + " : " + num.ToString() + " days left.");
			this.tb_biboardno.SelectAll();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000D7D4 File Offset: 0x0000B9D4
		private void Clear()
		{
			this.l_bib_No.Text = "";
			this.l_device.Text = "";
			this.l_customer.Text = "";
			this.l_location.Text = "";
			this.l_barcode.Text = "";
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000D834 File Offset: 0x0000BA34
		private void btn_search_Click(object sender, EventArgs e)
		{
			string text = this.tb_biboardno.Text;
			if (text == "")
			{
				MessageBox.Show("Input Burn In Board No");
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
			this.SetBoard_PM(text);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000D8A0 File Offset: 0x0000BAA0
		private void tb_biboardno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				string text = this.tb_biboardno.Text;
				if (text == "")
				{
					MessageBox.Show("Input Burn In Board No");
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
				this.SetBoard_PM(text);
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000D914 File Offset: 0x0000BB14
		private void grid_biboard_PM_List_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.grid_biboard_PM_List.Selection.ActivePosition.Row < 0)
			{
				return;
			}
			int row = this.grid_biboard_PM_List.Selection.ActivePosition.Row;
			int num = Convert.ToInt32(this.grid_biboard_PM_List[row, 1].ToString());
			CBIBoardInfo cbiboardInfo = null;
			foreach (CBIBoardInfo cbiboardInfo2 in this._biBoardInfos_PM)
			{
				if (cbiboardInfo2.iId == num)
				{
					cbiboardInfo = cbiboardInfo2;
				}
			}
			if (cbiboardInfo != null)
			{
				this.l_bib_No.Text = cbiboardInfo.strBibNo;
				this.l_device.Text = cbiboardInfo.strDevice;
				this.l_customer.Text = cbiboardInfo.strCustomer;
				this.l_location.Text = cbiboardInfo.strLocation;
				this.l_barcode.Text = cbiboardInfo.strBarcode;
			}
		}

		// Token: 0x04000121 RID: 289
		private SourceGrid.Cells.Views.Cell cell_center1;

		// Token: 0x04000122 RID: 290
		private SourceGrid.Cells.Views.Cell cell_center2;

		// Token: 0x04000123 RID: 291
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x04000124 RID: 292
		private SourceGrid.Cells.Views.Cell cell_onflag;

		// Token: 0x04000125 RID: 293
		private CheckBoxBackColorAlternate _checkBox_Normal1;

		// Token: 0x04000126 RID: 294
		private CheckBoxBackColorAlternate _checkBox_Normal2;

		// Token: 0x04000127 RID: 295
		private CheckBoxBackColorAlternate _checkBox_OnFlag;

		// Token: 0x04000128 RID: 296
		private BIBoardInfoModule _instance;

		// Token: 0x04000129 RID: 297
		public string _biBoardNo = string.Empty;

		// Token: 0x0400012A RID: 298
		private CGridIndex_BoardInfo_PMList _gridIdx_BIBoard;

		// Token: 0x0400012B RID: 299
		private List<CBIBoardInfo> _biBoardInfos;

		// Token: 0x0400012C RID: 300
		private List<CBIBoardInfo> _biBoardInfos_PM;

		// Token: 0x0400012D RID: 301
		private DateTime _dtNow;
	}
}
