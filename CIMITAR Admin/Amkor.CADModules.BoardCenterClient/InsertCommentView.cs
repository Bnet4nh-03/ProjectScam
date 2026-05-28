using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Amkor.CADModules.BoardCenterClient.CIMitarAdminWS;
using Amkor.CADModules.BoardCenterClient.Class;
using ATDFW.Classes.CIMitar;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.BoardCenterClient
{
	// Token: 0x02000004 RID: 4
	public partial class InsertCommentView : Form
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00004FFE File Offset: 0x000031FE
		public InsertCommentView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00005017 File Offset: 0x00003217
		public InsertCommentView(string strSearchSocketno, FactorySettings factorySetting)
		{
			this.strSearchSocketno = strSearchSocketno;
			this._factorySetting = factorySetting;
			this.bResult = false;
			this.InitializeComponent();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00005048 File Offset: 0x00003248
		private DataSet QueryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._factorySetting._urlServer + "CIMitarWebService/CIMitarWS.asmx";
				cimitarWSSoapClient.Endpoint.Address = new EndpointAddress(uri);
				dataSet = cimitarWSSoapClient.CIMitarQuaryCall("CIMitar_HCC", sQuery);
				result = dataSet;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				result = dataSet;
			}
			return result;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000050B8 File Offset: 0x000032B8
		private void GetTesterList()
		{
			try
			{
				DataSet dataSet = new DataSet();
				this._slTesterList.Clear();
				string str = this.tb_testername.Text.ToString();
				string sQuery = "EXEC [dbo].[USP_Socket_GetTesterList_Client] @testername = '" + str + "'";
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string key = dataSet.Tables[0].Rows[i]["testerid"].ToString();
						string value = dataSet.Tables[0].Rows[i]["testername"].ToString();
						this._slTesterList.Add(key, value);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000051C4 File Offset: 0x000033C4
		private string SetInsertComment()
		{
			string result = "-1";
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Socket_CommentHistory_MFG] @flag_ = 'SET_COMMENT', @newSocketNo_ = '",
					this.strSearchSocketno,
					"', @testerid_ = '",
					this.cInsertInfo.strTesterID,
					"', @site_ = '",
					this.cInsertInfo.strSite,
					"', @comment_ = N'",
					this.cInsertInfo.strComment,
					"', @name_ = N'",
					this.cInsertInfo.strName,
					"'"
				});
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						result = dataSet.Tables[0].Rows[i]["result"].ToString();
					}
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000052EC File Offset: 0x000034EC
		private void InitGridCell()
		{
			this.cell_right_gray = new SourceGrid.Cells.Views.Cell();
			this.cell_right_gray.BackColor = Color.FromArgb(224, 224, 224);
			this.cell_right_gray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
			this.cell_left_gray = new SourceGrid.Cells.Views.Cell();
			this.cell_left_gray.BackColor = Color.FromArgb(224, 224, 224);
			this.cell_left_gray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_total = new SourceGrid.Cells.Views.Cell();
			this.cell_total.BackColor = Color.FromArgb(224, 224, 224);
			this.cell_total.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_green = new SourceGrid.Cells.Views.Cell();
			this.cell_green.BackColor = Color.FromArgb(170, 235, 130);
			this.cell_green.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_red = new SourceGrid.Cells.Views.Cell();
			this.cell_red.BackColor = Color.FromArgb(235, 100, 100);
			this.cell_red.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_yello = new SourceGrid.Cells.Views.Cell();
			this.cell_yello.BackColor = Color.FromArgb(244, 230, 107);
			this.cell_yello.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_right_sgray = new SourceGrid.Cells.Views.Cell();
			this.cell_right_sgray.BackColor = Color.FromArgb(255, 255, 204);
			this.cell_right_sgray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
			this.cell_left_sgray = new SourceGrid.Cells.Views.Cell();
			this.cell_left_sgray.BackColor = Color.FromArgb(255, 255, 204);
			this.cell_left_sgray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_right_dark_sgray = new SourceGrid.Cells.Views.Cell();
			this.cell_right_dark_sgray.BackColor = Color.FromArgb(247, 240, 214);
			this.cell_right_dark_sgray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
			this.cell_left_dark_sgray = new SourceGrid.Cells.Views.Cell();
			this.cell_left_dark_sgray.BackColor = Color.FromArgb(247, 240, 214);
			this.cell_left_dark_sgray.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_right = new SourceGrid.Cells.Views.Cell();
			this.cell_right.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
			this.cell_left = new SourceGrid.Cells.Views.Cell();
			this.cell_left.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			this.cell_center = new SourceGrid.Cells.Views.Cell();
			this.cell_center.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_limit = new SourceGrid.Cells.Views.Cell();
			this.cell_limit.BackColor = Color.FromArgb(255, 192, 203);
			this.cell_limit.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
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
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000056D0 File Offset: 0x000038D0
		private void ResetGrid()
		{
			for (int i = this.grid_tester_list.RowsCount - 1; i >= 0; i--)
			{
				this.grid_tester_list.Rows.Remove(i);
			}
			this.grid_tester_list.Selection.EnableMultiSelection = false;
			this.grid_tester_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_tester_list.CustomSort = true;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00005730 File Offset: 0x00003930
		private void GridColumHeadSet()
		{
			int num = 0;
			this.grid_tester_list.ColumnsCount = 2;
			this.grid_tester_list.FixedRows = 1;
			this.grid_tester_list.FixedColumns = 0;
			this.grid_tester_list.Rows.Insert(num);
			this.grid_tester_list[num, 0] = new SourceGrid.Cells.ColumnHeader("No");
			this.grid_tester_list[num, 0].View = this.cell_header1;
			this.grid_tester_list[num, 1] = new SourceGrid.Cells.ColumnHeader("Tester#");
			this.grid_tester_list[num, 1].View = this.cell_header1;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000057D4 File Offset: 0x000039D4
		public void SetGrid()
		{
			this.GridColumHeadSet();
			int num = 1;
			foreach (object obj in this._slTesterList)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string tag = dictionaryEntry.Key.ToString();
				string cellValue = dictionaryEntry.Value.ToString();
				this.grid_tester_list.Rows.Insert(num);
				this.grid_tester_list[num, 0] = new SourceGrid.Cells.Cell(num.ToString());
				this.grid_tester_list[num, 0].View = this.cell_center;
				this.grid_tester_list[num, 1] = new SourceGrid.Cells.Cell(cellValue);
				this.grid_tester_list[num, 1].Tag = tag;
				this.grid_tester_list[num, 1].View = this.cell_left;
				num++;
			}
			this.AutoGridSet();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000058E0 File Offset: 0x00003AE0
		private void AutoGridSet()
		{
			this.grid_tester_list.AutoSizeCells();
			int num = 0;
			int num2 = 0;
			foreach (object obj in ((IEnumerable)this.grid_tester_list.Columns))
			{
				GridColumn gridColumn = (GridColumn)obj;
				num += gridColumn.Width;
			}
			foreach (RowInfo rowInfo in this.grid_tester_list.Rows)
			{
				GridRow gridRow = (GridRow)rowInfo;
				num2 += gridRow.Height;
			}
			this.grid_tester_list.Height = num2 + 2;
			this.grid_tester_list.Width = num + 2;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000059C0 File Offset: 0x00003BC0
		private void InsertCommentView_Load(object sender, EventArgs e)
		{
			this.InitGridCell();
			this._slTesterList = new SortedList();
			this.cInsertInfo = new CInsertInfo();
			DateTime now = DateTime.Now;
			this.l_Tester.ForeColor = Color.Red;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000059F4 File Offset: 0x00003BF4
		private void btn_select_Click(object sender, EventArgs e)
		{
			this.GetTesterList();
			this.ResetGrid();
			this.SetGrid();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00005A08 File Offset: 0x00003C08
		private void btn_ok_Click(object sender, EventArgs e)
		{
			string text = this.tb_site.Text.ToString().Trim();
			int num;
			if (int.TryParse(text, out num))
			{
				this.cInsertInfo.strSite = text;
				this.cInsertInfo.strName = this.tb_name.Text.ToString().Trim();
				this.cInsertInfo.strComment = this.tb_comment.Text.ToString().Trim();
				if (this.cInsertInfo.CheckInfo() != 0)
				{
					this.bResult = false;
					MessageBox.Show("Please fill in the item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				string a = this.SetInsertComment();
				if (a == "0")
				{
					this.bResult = true;
					MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (a == "-1")
				{
					this.bResult = false;
					MessageBox.Show("An unprocessed comment already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			else
			{
				this.bResult = false;
				MessageBox.Show("Sites are only numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00005B1D File Offset: 0x00003D1D
		private void btn_close_Click(object sender, EventArgs e)
		{
			if (this.bResult)
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.Cancel;
			}
			base.Close();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00005B40 File Offset: 0x00003D40
		private void grid_tester_list_MouseClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			string empty = string.Empty;
			int row = grid.MouseDownPosition.Row;
			int column = grid.MouseDownPosition.Column;
			if (row > 0)
			{
				string text = (string)grid[row, 0].Value;
				string strTesterID = this.grid_tester_list[row, 1].Tag.ToString();
				string text2 = this.grid_tester_list[row, 1].Value.ToString();
				this.l_Tester.Text = text2;
				this.cInsertInfo.strTesterName = text2;
				this.cInsertInfo.strTesterID = strTesterID;
				this.l_Tester.ForeColor = Color.Green;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00005BF6 File Offset: 0x00003DF6
		private void tb_comment_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ',')
			{
				e.Handled = true;
				MessageBox.Show("You can not type a comma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00005BF6 File Offset: 0x00003DF6
		private void tb_site_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ',')
			{
				e.Handled = true;
				MessageBox.Show("You can not type a comma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00005BF6 File Offset: 0x00003DF6
		private void tb_name_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ',')
			{
				e.Handled = true;
				MessageBox.Show("You can not type a comma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005B1D File Offset: 0x00003D1D
		private void InsertCommentView_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.bResult)
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.Cancel;
			}
			base.Close();
		}

		// Token: 0x04000042 RID: 66
		private SourceGrid.Cells.Views.Cell cell_right_gray;

		// Token: 0x04000043 RID: 67
		private SourceGrid.Cells.Views.Cell cell_left_gray;

		// Token: 0x04000044 RID: 68
		private SourceGrid.Cells.Views.Cell cell_total;

		// Token: 0x04000045 RID: 69
		private SourceGrid.Cells.Views.Cell cell_green;

		// Token: 0x04000046 RID: 70
		private SourceGrid.Cells.Views.Cell cell_red;

		// Token: 0x04000047 RID: 71
		private SourceGrid.Cells.Views.Cell cell_right_sgray;

		// Token: 0x04000048 RID: 72
		private SourceGrid.Cells.Views.Cell cell_left_sgray;

		// Token: 0x04000049 RID: 73
		private SourceGrid.Cells.Views.Cell cell_right_dark_sgray;

		// Token: 0x0400004A RID: 74
		private SourceGrid.Cells.Views.Cell cell_left_dark_sgray;

		// Token: 0x0400004B RID: 75
		private SourceGrid.Cells.Views.Cell cell_right;

		// Token: 0x0400004C RID: 76
		private SourceGrid.Cells.Views.Cell cell_left;

		// Token: 0x0400004D RID: 77
		private SourceGrid.Cells.Views.Cell cell_center;

		// Token: 0x0400004E RID: 78
		private SourceGrid.Cells.Views.Cell cell_limit;

		// Token: 0x0400004F RID: 79
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x04000050 RID: 80
		private SourceGrid.Cells.Views.Cell cell_header2;

		// Token: 0x04000051 RID: 81
		private SourceGrid.Cells.Views.Cell cell_header3;

		// Token: 0x04000052 RID: 82
		private SourceGrid.Cells.Views.Cell cell_header4;

		// Token: 0x04000053 RID: 83
		private SourceGrid.Cells.Views.Cell cell_header5;

		// Token: 0x04000054 RID: 84
		private SourceGrid.Cells.Views.Cell cell_header6;

		// Token: 0x04000055 RID: 85
		private SourceGrid.Cells.Views.Cell cell_yello;

		// Token: 0x04000056 RID: 86
		private SortedList _slTesterList;

		// Token: 0x04000057 RID: 87
		private CInsertInfo cInsertInfo;

		// Token: 0x04000058 RID: 88
		private string strSearchSocketno = "";

		// Token: 0x04000059 RID: 89
		private FactorySettings _factorySetting;

		// Token: 0x0400005A RID: 90
		private bool bResult;
	}
}
