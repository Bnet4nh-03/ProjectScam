using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AlteraSocketView.View;
using Amkor.CADModules.BoardCenterClient.CIMitarAdminWS;
using Amkor.CADModules.BoardCenterClient.Class;
using Amkor.CADModules.BoardCenterClient.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.BoardCenterClient
{
	// Token: 0x02000003 RID: 3
	public partial class BoardCenterClientMain : BaseWinView
	{
		// Token: 0x0600000C RID: 12 RVA: 0x0000263E File Offset: 0x0000083E
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000264C File Offset: 0x0000084C
		public BoardCenterClientMain()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://testweb.amkor.co.kr/";
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this.InitializeComponent();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000026C4 File Offset: 0x000008C4
		public BoardCenterClientMain(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
			this.l_subject.Text = this._factorySetting._factoryName + " " + this.l_subject.Text;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002758 File Offset: 0x00000958
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

		// Token: 0x06000010 RID: 16 RVA: 0x000027C8 File Offset: 0x000009C8
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

		// Token: 0x06000011 RID: 17 RVA: 0x00002BAC File Offset: 0x00000DAC
		private void ResetGrid()
		{
			for (int i = this.grid_socket_history.RowsCount - 1; i >= 0; i--)
			{
				this.grid_socket_history.Rows.Remove(i);
			}
			this.grid_socket_history.Selection.EnableMultiSelection = false;
			this.grid_socket_history.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_socket_history.CustomSort = true;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002C0C File Offset: 0x00000E0C
		private void GridColumHeadSet()
		{
			int num = 0;
			this.grid_socket_history.ColumnsCount = 11;
			this.grid_socket_history.FixedRows = 1;
			this.grid_socket_history.FixedColumns = 0;
			this.grid_socket_history.Rows.Insert(num);
			this.grid_socket_history[num, 0] = new SourceGrid.Cells.ColumnHeader("No");
			this.grid_socket_history[num, 0].View = this.cell_header1;
			this.grid_socket_history[num, 1] = new SourceGrid.Cells.ColumnHeader("Request Date");
			this.grid_socket_history[num, 1].View = this.cell_header1;
			this.grid_socket_history[num, 2] = new SourceGrid.Cells.ColumnHeader("Tester#");
			this.grid_socket_history[num, 2].View = this.cell_header1;
			this.grid_socket_history[num, 3] = new SourceGrid.Cells.ColumnHeader("Socket#");
			this.grid_socket_history[num, 3].View = this.cell_header1;
			this.grid_socket_history[num, 4] = new SourceGrid.Cells.ColumnHeader("Site");
			this.grid_socket_history[num, 4].View = this.cell_header1;
			this.grid_socket_history[num, 5] = new SourceGrid.Cells.ColumnHeader("T-Count");
			this.grid_socket_history[num, 5].View = this.cell_header1;
			this.grid_socket_history[num, 6] = new SourceGrid.Cells.ColumnHeader("Problem/Request Comment");
			this.grid_socket_history[num, 6].View = this.cell_header1;
			this.grid_socket_history[num, 7] = new SourceGrid.Cells.ColumnHeader("Name");
			this.grid_socket_history[num, 7].View = this.cell_header1;
			this.grid_socket_history[num, 8] = new SourceGrid.Cells.ColumnHeader("Completed Date");
			this.grid_socket_history[num, 8].View = this.cell_header3;
			this.grid_socket_history[num, 9] = new SourceGrid.Cells.ColumnHeader("Taken Action");
			this.grid_socket_history[num, 9].View = this.cell_header3;
			this.grid_socket_history[num, 10] = new SourceGrid.Cells.ColumnHeader("Name");
			this.grid_socket_history[num, 10].View = this.cell_header3;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002E5C File Offset: 0x0000105C
		public void SetGrid()
		{
			this.GridColumHeadSet();
			int num = 1;
			foreach (object obj in this._slCommentHistory)
			{
				CCommentHistory ccommentHistory = (CCommentHistory)((DictionaryEntry)obj).Value;
				this.grid_socket_history.Rows.Insert(num);
				this.grid_socket_history[num, 0] = new SourceGrid.Cells.Cell(num.ToString());
				this.grid_socket_history[num, 0].View = this.cell_center;
				this.grid_socket_history[num, 1] = new SourceGrid.Cells.Cell(ccommentHistory.strRequestDate);
				this.grid_socket_history[num, 1].View = this.cell_left;
				this.grid_socket_history[num, 2] = new SourceGrid.Cells.Cell(ccommentHistory.strTesterName);
				this.grid_socket_history[num, 2].View = this.cell_left;
				this.grid_socket_history[num, 3] = new SourceGrid.Cells.Cell(ccommentHistory.strSocketBarcode);
				this.grid_socket_history[num, 3].View = this.cell_left;
				this.grid_socket_history[num, 4] = new SourceGrid.Cells.Cell(ccommentHistory.strSite);
				this.grid_socket_history[num, 4].View = this.cell_right;
				this.grid_socket_history[num, 5] = new SourceGrid.Cells.Cell(ccommentHistory.strNowLifeTime);
				this.grid_socket_history[num, 5].View = this.cell_right;
				this.grid_socket_history[num, 6] = new SourceGrid.Cells.Cell(ccommentHistory.strRequestComment);
				this.grid_socket_history[num, 6].View = this.cell_left;
				this.grid_socket_history[num, 7] = new SourceGrid.Cells.Cell(ccommentHistory.strRequestName);
				this.grid_socket_history[num, 7].View = this.cell_left;
				this.grid_socket_history[num, 8] = new SourceGrid.Cells.Cell(ccommentHistory.strCompletedDate);
				this.grid_socket_history[num, 8].View = this.cell_left;
				this.grid_socket_history[num, 9] = new SourceGrid.Cells.Cell(ccommentHistory.strTakenAction);
				this.grid_socket_history[num, 9].View = this.cell_left;
				this.grid_socket_history[num, 10] = new SourceGrid.Cells.Cell(ccommentHistory.strCompletedName);
				this.grid_socket_history[num, 10].View = this.cell_left;
				num++;
			}
			this.AutoGridSet();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003108 File Offset: 0x00001308
		private void AutoGridSet()
		{
			this.grid_socket_history.AutoSizeCells();
			int num = 0;
			int num2 = 0;
			foreach (object obj in ((IEnumerable)this.grid_socket_history.Columns))
			{
				GridColumn gridColumn = (GridColumn)obj;
				num += gridColumn.Width;
			}
			foreach (RowInfo rowInfo in this.grid_socket_history.Rows)
			{
				GridRow gridRow = (GridRow)rowInfo;
				num2 += gridRow.Height;
			}
			this.grid_socket_history.Height = num2 + 2;
			this.grid_socket_history.Width = num + 2;
			base.Width = this.grid_socket_history.Width + 50;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000031FC File Offset: 0x000013FC
		private void btn_search_Click(object sender, EventArgs e)
		{
			try
			{
				this._slCommentHistory.Clear();
				this.strBarcode = this.tb_barcode.Text.ToString().Trim();
				if (this.strBarcode != "")
				{
					if (this.GetCommentHistory("Socket") == 0)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Socket Comment History");
						this._barPrograss.setValue(100);
						this._barPrograss.StartPosition = FormStartPosition.Manual;
						this._barPrograss.Location = new Point(base.Location.X + base.Width / 3, base.Location.Y + base.Height / 3 + this._barPrograss.Height);
						this._barPrograss.progress_label_set("Loading");
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						this.ResetGrid();
						this.SetGrid();
						Thread.Sleep(1000);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
					else
					{
						MessageBox.Show("There is no socket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Please fill in the barcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000338C File Offset: 0x0000158C
		private void btn_search_tester_Click(object sender, EventArgs e)
		{
			try
			{
				this._slCommentHistory.Clear();
				this.strTester = this.tb_tester.Text.ToString().Trim();
				if (this.strTester != "")
				{
					if (this.GetCommentHistory("Tester") == 0)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Socket Comment History");
						this._barPrograss.setValue(100);
						this._barPrograss.StartPosition = FormStartPosition.Manual;
						this._barPrograss.Location = new Point(base.Location.X + base.Width / 3, base.Location.Y + base.Height / 3 + this._barPrograss.Height);
						this._barPrograss.progress_label_set("Loading");
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						this.ResetGrid();
						this.SetGrid();
						Thread.Sleep(1000);
						if (this._barPrograss != null)
						{
							this._barPrograss._ischeck = true;
						}
						this._barPrograss = null;
					}
					else
					{
						MessageBox.Show("There is no tester #.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Please fill in the tester #.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000351C File Offset: 0x0000171C
		private int GetCommentHistory(string searchtype)
		{
			int result = 0;
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "";
				if (searchtype == "Socket")
				{
					sQuery = "EXEC [dbo].[USP_Socket_CommentHistory_MFG] @flag_ = 'GET_HISTORY', @Barcode = '" + this.strBarcode + "'";
				}
				else if (searchtype == "Tester")
				{
					sQuery = "EXEC [dbo].[USP_Socket_CommentHistory_MFG] @flag_ = 'GET_HISTORY_BY_TESTER', @Barcode = '" + this.strTester + "'";
				}
				dataSet = this.QueryCall(sQuery);
				if (dataSet.Tables.Count > 1)
				{
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							this.strSearchSocketno = dataSet.Tables[0].Rows[i]["no"].ToString();
							this.l_customer.Text = dataSet.Tables[0].Rows[i]["customer"].ToString();
							this.l_device.Text = dataSet.Tables[0].Rows[i]["device"].ToString();
							this.l_ptype.Text = dataSet.Tables[0].Rows[i]["pkgtype"].ToString();
							this.l_serial.Text = dataSet.Tables[0].Rows[i]["serial"].ToString();
							this.l_tcount.Text = dataSet.Tables[0].Rows[i]["nowLifeTime"].ToString();
						}
						result = 0;
					}
					else
					{
						result = -1;
					}
					if (dataSet.Tables[1].Rows.Count > 0)
					{
						for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
						{
							CCommentHistory ccommentHistory = new CCommentHistory();
							ccommentHistory.strNo = dataSet.Tables[1].Rows[j]["no"].ToString();
							ccommentHistory.strNewSocketNo = dataSet.Tables[1].Rows[j]["newSocketNo"].ToString();
							ccommentHistory.strRequestDate = dataSet.Tables[1].Rows[j]["requestDate"].ToString();
							ccommentHistory.strTesterName = dataSet.Tables[1].Rows[j]["testername"].ToString();
							ccommentHistory.strSocketBarcode = this.strBarcode;
							ccommentHistory.strSite = dataSet.Tables[1].Rows[j]["site"].ToString();
							ccommentHistory.strNowLifeTime = dataSet.Tables[1].Rows[j]["nowLifeTime"].ToString();
							ccommentHistory.strRequestComment = dataSet.Tables[1].Rows[j]["requestComment"].ToString();
							ccommentHistory.strRequestName = dataSet.Tables[1].Rows[j]["requestName"].ToString();
							ccommentHistory.strCompletedDate = dataSet.Tables[1].Rows[j]["completedDate"].ToString();
							ccommentHistory.strTakenAction = dataSet.Tables[1].Rows[j]["takenAction"].ToString();
							ccommentHistory.strCompletedName = dataSet.Tables[1].Rows[j]["completedName"].ToString();
							this._slCommentHistory.Add(j, ccommentHistory);
						}
					}
				}
				else if (dataSet.Tables.Count == 1)
				{
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
						{
							CCommentHistory ccommentHistory2 = new CCommentHistory();
							ccommentHistory2.strNo = dataSet.Tables[0].Rows[k]["no"].ToString();
							ccommentHistory2.strNewSocketNo = dataSet.Tables[0].Rows[k]["newSocketNo"].ToString();
							ccommentHistory2.strRequestDate = dataSet.Tables[0].Rows[k]["requestDate"].ToString();
							ccommentHistory2.strTesterName = dataSet.Tables[0].Rows[k]["testername"].ToString();
							ccommentHistory2.strSocketBarcode = dataSet.Tables[0].Rows[k]["barcode"].ToString();
							ccommentHistory2.strSite = dataSet.Tables[0].Rows[k]["site"].ToString();
							ccommentHistory2.strNowLifeTime = dataSet.Tables[0].Rows[k]["nowLifeTime"].ToString();
							ccommentHistory2.strRequestComment = dataSet.Tables[0].Rows[k]["requestComment"].ToString();
							ccommentHistory2.strRequestName = dataSet.Tables[0].Rows[k]["requestName"].ToString();
							ccommentHistory2.strCompletedDate = dataSet.Tables[0].Rows[k]["completedDate"].ToString();
							ccommentHistory2.strTakenAction = dataSet.Tables[0].Rows[k]["takenAction"].ToString();
							ccommentHistory2.strCompletedName = dataSet.Tables[0].Rows[k]["completedName"].ToString();
							this._slCommentHistory.Add(k, ccommentHistory2);
						}
					}
				}
				else
				{
					result = -1;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003C3C File Offset: 0x00001E3C
		private void BoardCenterClientMain_Load(object sender, EventArgs e)
		{
			this.InitGridCell();
			this.l_customer.Text = "";
			this.l_device.Text = "";
			this.l_ptype.Text = "";
			this.l_serial.Text = "";
			this._slCommentHistory = new SortedList();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003C9C File Offset: 0x00001E9C
		private void btn_Insert_Click(object sender, EventArgs e)
		{
			if (this.strSearchSocketno != "")
			{
				if (new InsertCommentView(this.strSearchSocketno, this._factorySetting).ShowDialog() == DialogResult.OK)
				{
					this.ResetGrid();
					this._slCommentHistory.Clear();
					this.GetCommentHistory("Socket");
					this.SetGrid();
					return;
				}
			}
			else
			{
				MessageBox.Show("Please Search Socket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003D0B File Offset: 0x00001F0B
		private void tb_barcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.btn_search.PerformClick();
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003D22 File Offset: 0x00001F22
		private void tb_tester_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.btn_search_tester.PerformClick();
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003D39 File Offset: 0x00001F39
		private void pb_excel_MouseMove(object sender, MouseEventArgs e)
		{
			this.pb_excel.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003D56 File Offset: 0x00001F56
		private void pb_excel_MouseLeave(object sender, EventArgs e)
		{
			this.pb_excel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003D56 File Offset: 0x00001F56
		private void pb_excel_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_excel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003D73 File Offset: 0x00001F73
		private void pb_excel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
			this.SaveCSV();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003D88 File Offset: 0x00001F88
		private void SaveCSV()
		{
			string fileName = "(" + this.strBarcode + ") SocketCommentHistory.csv";
			this.saveFileDialog_csv.FileName = fileName;
			this.saveFileDialog_csv.DefaultExt = "csv";
			this.saveFileDialog_csv.Filter = "CSV files|*.csv";
			if (this.saveFileDialog_csv.ShowDialog() == DialogResult.OK)
			{
				if (this.SaveToCSVFormat(this.saveFileDialog_csv.FileName, this.grid_socket_history) == 0)
				{
					MessageBox.Show("Sucess Create CSV file : " + this.saveFileDialog_csv.FileName);
					return;
				}
				MessageBox.Show("Fail to Export CSV");
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003E28 File Offset: 0x00002028
		private int SaveToCSVFormat(string path, Grid grid)
		{
			int result;
			try
			{
				if (grid != null)
				{
					StreamWriter streamWriter = new StreamWriter(path, false, Encoding.GetEncoding("euc-kr"));
					for (int i = 0; i < grid.Rows.Count; i++)
					{
						for (int j = 0; j < grid.Columns.Count; j++)
						{
							string text;
							if (grid[i, j] == null)
							{
								text = "";
							}
							else if (grid[i, j].Value == null)
							{
								text = "";
							}
							else
							{
								text = grid[i, j].Value.ToString();
							}
							if (text.Contains("\n"))
							{
								text = text.Replace("\n", "");
							}
							else if (text.Contains(","))
							{
								text = text.Replace(",", "/");
							}
							streamWriter.Write(text + ",");
						}
						streamWriter.Write("\n");
					}
					streamWriter.Close();
				}
				result = 0;
			}
			catch (Exception)
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0400000C RID: 12
		private SourceGrid.Cells.Views.Cell cell_right_gray;

		// Token: 0x0400000D RID: 13
		private SourceGrid.Cells.Views.Cell cell_left_gray;

		// Token: 0x0400000E RID: 14
		private SourceGrid.Cells.Views.Cell cell_total;

		// Token: 0x0400000F RID: 15
		private SourceGrid.Cells.Views.Cell cell_green;

		// Token: 0x04000010 RID: 16
		private SourceGrid.Cells.Views.Cell cell_red;

		// Token: 0x04000011 RID: 17
		private SourceGrid.Cells.Views.Cell cell_right_sgray;

		// Token: 0x04000012 RID: 18
		private SourceGrid.Cells.Views.Cell cell_left_sgray;

		// Token: 0x04000013 RID: 19
		private SourceGrid.Cells.Views.Cell cell_right_dark_sgray;

		// Token: 0x04000014 RID: 20
		private SourceGrid.Cells.Views.Cell cell_left_dark_sgray;

		// Token: 0x04000015 RID: 21
		private SourceGrid.Cells.Views.Cell cell_right;

		// Token: 0x04000016 RID: 22
		private SourceGrid.Cells.Views.Cell cell_left;

		// Token: 0x04000017 RID: 23
		private SourceGrid.Cells.Views.Cell cell_center;

		// Token: 0x04000018 RID: 24
		private SourceGrid.Cells.Views.Cell cell_limit;

		// Token: 0x04000019 RID: 25
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x0400001A RID: 26
		private SourceGrid.Cells.Views.Cell cell_header2;

		// Token: 0x0400001B RID: 27
		private SourceGrid.Cells.Views.Cell cell_header3;

		// Token: 0x0400001C RID: 28
		private SourceGrid.Cells.Views.Cell cell_header4;

		// Token: 0x0400001D RID: 29
		private SourceGrid.Cells.Views.Cell cell_header5;

		// Token: 0x0400001E RID: 30
		private SourceGrid.Cells.Views.Cell cell_header6;

		// Token: 0x0400001F RID: 31
		private SourceGrid.Cells.Views.Cell cell_yello;

		// Token: 0x04000020 RID: 32
		private string strBarcode = "";

		// Token: 0x04000021 RID: 33
		private string strTester = "";

		// Token: 0x04000022 RID: 34
		private string strSearchSocketno = "";

		// Token: 0x04000023 RID: 35
		private SortedList _slCommentHistory;

		// Token: 0x04000024 RID: 36
		private Thread _thread;

		// Token: 0x04000025 RID: 37
		private BarPrograss _barPrograss;

		// Token: 0x04000026 RID: 38
		private string _strPrograssBarHeader;
	}
}
