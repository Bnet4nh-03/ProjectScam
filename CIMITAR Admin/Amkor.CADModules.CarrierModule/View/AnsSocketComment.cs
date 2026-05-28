using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Control;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200003B RID: 59
	public partial class AnsSocketComment : Form
	{
		// Token: 0x060002A2 RID: 674 RVA: 0x00048797 File Offset: 0x00046997
		public AnsSocketComment()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x000487B0 File Offset: 0x000469B0
		public AnsSocketComment(string strSocketId, string strBarcode)
		{
			this._strSocketId = strSocketId;
			this._strBarcode = strBarcode;
			this.InitializeComponent();
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x000487D7 File Offset: 0x000469D7
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x000487E8 File Offset: 0x000469E8
		private void AnsSocketComment_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.InitGridCell();
			this._slCommentHistory = new SortedList();
			this.lblTop.Text = "Socket Comment (" + this._strBarcode + ")";
			this.GetCommentHistory();
			this.SetGrid();
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00048844 File Offset: 0x00046A44
		private void GetCommentHistory()
		{
			try
			{
				this._slCommentHistory.Clear();
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetSocketCommentHistory] @socketid = '" + this._strSocketId + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						CCommentHistory ccommentHistory = new CCommentHistory();
						ccommentHistory.strNo = dataSet.Tables[0].Rows[i]["no"].ToString();
						ccommentHistory.strSocketID = dataSet.Tables[0].Rows[i]["socketid"].ToString();
						ccommentHistory.strSite = dataSet.Tables[0].Rows[i]["site"].ToString();
						ccommentHistory.strTesterName = dataSet.Tables[0].Rows[i]["testername"].ToString();
						ccommentHistory.strRequestDate = dataSet.Tables[0].Rows[i]["requestDate"].ToString();
						ccommentHistory.strRequestComment = dataSet.Tables[0].Rows[i]["requestComment"].ToString();
						ccommentHistory.strRequestName = dataSet.Tables[0].Rows[i]["requestName"].ToString();
						ccommentHistory.strCompletedDate = dataSet.Tables[0].Rows[i]["completedDate"].ToString();
						ccommentHistory.strCompletedComment = dataSet.Tables[0].Rows[i]["completedComment"].ToString();
						ccommentHistory.strPinCount = dataSet.Tables[0].Rows[i]["pincount"].ToString();
						ccommentHistory.strCompletedName = dataSet.Tables[0].Rows[i]["completedName"].ToString();
						this._slCommentHistory.Add(i, ccommentHistory);
					}
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00048B00 File Offset: 0x00046D00
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

		// Token: 0x060002A8 RID: 680 RVA: 0x00048EE4 File Offset: 0x000470E4
		private void ResetGrid()
		{
			int num = this.grid_socket_comment.RowsCount - 1;
			for (int i = num; i >= 0; i--)
			{
				this.grid_socket_comment.Rows.Remove(i);
			}
			this.grid_socket_comment.Selection.EnableMultiSelection = false;
			this.grid_socket_comment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_socket_comment.CustomSort = true;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00048F48 File Offset: 0x00047148
		private void GridColumHeadSet()
		{
			int num = 0;
			this.grid_socket_comment.ColumnsCount = 11;
			this.grid_socket_comment.FixedRows = 1;
			this.grid_socket_comment.FixedColumns = 3;
			this.grid_socket_comment.Rows.Insert(num);
			this.grid_socket_comment[num, 0] = new SourceGrid.Cells.ColumnHeader("No");
			this.grid_socket_comment[num, 0].View = this.cell_header1;
			this.grid_socket_comment[num, 1] = new SourceGrid.Cells.ColumnHeader("Site");
			this.grid_socket_comment[num, 1].View = this.cell_header1;
			this.grid_socket_comment[num, 2] = new SourceGrid.Cells.ColumnHeader("Tester");
			this.grid_socket_comment[num, 2].View = this.cell_header1;
			this.grid_socket_comment[num, 3] = new SourceGrid.Cells.ColumnHeader("Request Date");
			this.grid_socket_comment[num, 3].View = this.cell_header1;
			this.grid_socket_comment[num, 4] = new SourceGrid.Cells.ColumnHeader("Request Comment");
			this.grid_socket_comment[num, 4].View = this.cell_header1;
			this.grid_socket_comment[num, 5] = new SourceGrid.Cells.ColumnHeader("Name");
			this.grid_socket_comment[num, 5].View = this.cell_header1;
			this.grid_socket_comment[num, 6] = new SourceGrid.Cells.ColumnHeader("Completed Date");
			this.grid_socket_comment[num, 6].View = this.cell_header3;
			this.grid_socket_comment[num, 7] = new SourceGrid.Cells.ColumnHeader("Completed Comment");
			this.grid_socket_comment[num, 7].View = this.cell_header3;
			this.grid_socket_comment[num, 8] = new SourceGrid.Cells.ColumnHeader("PinCount");
			this.grid_socket_comment[num, 8].View = this.cell_header3;
			this.grid_socket_comment[num, 9] = new SourceGrid.Cells.ColumnHeader("Name");
			this.grid_socket_comment[num, 9].View = this.cell_header3;
			this.grid_socket_comment[num, 10] = new SourceGrid.Cells.ColumnHeader("Select");
			this.grid_socket_comment[num, 10].View = this.cell_header3;
			this.grid_socket_comment.Columns[0].Width = 40;
			this.grid_socket_comment.Columns[1].Width = 40;
			this.grid_socket_comment.Columns[2].Width = 60;
			this.grid_socket_comment.Columns[3].Width = 100;
			this.grid_socket_comment.Columns[4].Width = 300;
			this.grid_socket_comment.Columns[5].Width = 60;
			this.grid_socket_comment.Columns[6].Width = 100;
			this.grid_socket_comment.Columns[7].Width = 300;
			this.grid_socket_comment.Columns[8].Width = 40;
			this.grid_socket_comment.Columns[9].Width = 60;
			this.grid_socket_comment.Columns[10].Width = 40;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000492A8 File Offset: 0x000474A8
		public void SetGrid()
		{
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Loading Data....");
				this._barPrograss.setValue(0);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				this.ResetGrid();
				this.GridColumHeadSet();
				int num = 1;
				this._barPrograss.setMax(this._slCommentHistory.Count);
				foreach (object obj in this._slCommentHistory)
				{
					CCommentHistory ccommentHistory = (CCommentHistory)((DictionaryEntry)obj).Value;
					this.grid_socket_comment.Rows.Insert(num);
					this.grid_socket_comment[num, 0] = new SourceGrid.Cells.Cell(num.ToString());
					this.grid_socket_comment[num, 0].View = this.cell_center;
					this.grid_socket_comment[num, 1] = new SourceGrid.Cells.Cell(ccommentHistory.strSite);
					this.grid_socket_comment[num, 1].View = this.cell_left;
					this.grid_socket_comment[num, 2] = new SourceGrid.Cells.Cell(ccommentHistory.strTesterName);
					this.grid_socket_comment[num, 2].View = this.cell_left;
					this.grid_socket_comment[num, 3] = new SourceGrid.Cells.Cell(ccommentHistory.strRequestDate);
					this.grid_socket_comment[num, 3].View = this.cell_left;
					this.grid_socket_comment[num, 4] = new SourceGrid.Cells.Cell(ccommentHistory.strRequestComment);
					this.grid_socket_comment[num, 4].View = this.cell_left;
					this.grid_socket_comment[num, 5] = new SourceGrid.Cells.Cell(ccommentHistory.strRequestName);
					this.grid_socket_comment[num, 5].View = this.cell_left;
					this.grid_socket_comment[num, 6] = new SourceGrid.Cells.Cell(ccommentHistory.strCompletedDate);
					this.grid_socket_comment[num, 6].View = this.cell_left;
					this.grid_socket_comment[num, 7] = new SourceGrid.Cells.Cell(ccommentHistory.strCompletedComment);
					this.grid_socket_comment[num, 7].View = this.cell_left;
					this.grid_socket_comment[num, 8] = new SourceGrid.Cells.Cell(ccommentHistory.strPinCount);
					this.grid_socket_comment[num, 8].View = this.cell_left;
					this.grid_socket_comment[num, 9] = new SourceGrid.Cells.Cell(ccommentHistory.strCompletedName);
					this.grid_socket_comment[num, 9].View = this.cell_left;
					this.grid_socket_comment[num, 10] = new SourceGrid.Cells.Button("Input");
					this.grid_socket_comment[num, 10].Tag = ccommentHistory.strNo;
					this.grid_socket_comment[num, 10].Image = Resources.page_white_edit;
					SourceGrid.Cells.Controllers.Button button = new SourceGrid.Cells.Controllers.Button();
					button.Executed += this.CellButton_Click;
					this.grid_socket_comment[num, 10].Controller.AddController(button);
					num++;
				}
				this.gridInfo.AutoSetGrid(this.grid_socket_comment);
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				ex.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000496B0 File Offset: 0x000478B0
		private void CellButton_Click(object sender, EventArgs e)
		{
			SourceGrid.Cells.Button button = (SourceGrid.Cells.Button)((CellContext)sender).Cell;
			string strNo = button.Tag.ToString();
			new AnsAddSocketComment(strNo)
			{
				_factorySetting = this._factorySetting
			}.ShowDialog();
			this._slCommentHistory.Clear();
			this.ResetGrid();
			this.GetCommentHistory();
			this.SetGrid();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00049714 File Offset: 0x00047914
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0004971C File Offset: 0x0004791C
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00049739 File Offset: 0x00047939
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00049756 File Offset: 0x00047956
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00049773 File Offset: 0x00047973
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00049780 File Offset: 0x00047980
		private void pb_comment_excel_Click(object sender, EventArgs e)
		{
			this.saveExcel(this.grid_socket_comment);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0004978E File Offset: 0x0004798E
		private void pb_comment_excel_MouseMove(object sender, MouseEventArgs e)
		{
			this.pb_comment_excel.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x000497AB File Offset: 0x000479AB
		private void pb_comment_excel_MouseLeave(object sender, EventArgs e)
		{
			this.pb_comment_excel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x000497C8 File Offset: 0x000479C8
		private void pb_comment_excel_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_comment_excel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x000497E5 File Offset: 0x000479E5
		private void pb_comment_excel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000497F4 File Offset: 0x000479F4
		private void saveExcel(Grid grid)
		{
			try
			{
				if (grid.RowsCount > 1)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.DefaultExt = ".xlsx";
					saveFileDialog.Filter = "Excel files|*.xlsx|CSV files|*.csv";
					saveFileDialog.FilterIndex = 1;
					saveFileDialog.FileName = string.Empty;
					DialogResult dialogResult = saveFileDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this._barPrograss = new BarPrograss();
						this._barPrograss.progress_labelheader_set("Save Data....");
						this._barPrograss.setValue(100);
						this._thread = new Thread(new ThreadStart(this.BarPrograssView));
						this._thread.Start();
						if (saveFileDialog.FilterIndex == 1)
						{
							ExcelControl.Save(saveFileDialog.FileName, grid, true);
						}
						else if (saveFileDialog.FilterIndex == 2)
						{
							ExcelControl.SaveCSV(saveFileDialog.FileName, grid, this._cimitarUser._exeExcel);
						}
					}
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
				else
				{
					MessageBox.Show("data is not exist ", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x040004B0 RID: 1200
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x040004B1 RID: 1201
		public FactorySettings _factorySetting;

		// Token: 0x040004B2 RID: 1202
		public CIMitarAccount _cimitarUser;

		// Token: 0x040004B3 RID: 1203
		private QueryMgr queryMgr;

		// Token: 0x040004B4 RID: 1204
		private Thread _thread;

		// Token: 0x040004B5 RID: 1205
		private BarPrograss _barPrograss;

		// Token: 0x040004B6 RID: 1206
		private SortedList _slCommentHistory;

		// Token: 0x040004B7 RID: 1207
		private string _strSocketId;

		// Token: 0x040004B8 RID: 1208
		private string _strBarcode;

		// Token: 0x040004B9 RID: 1209
		private SourceGrid.Cells.Views.Cell cell_right_gray;

		// Token: 0x040004BA RID: 1210
		private SourceGrid.Cells.Views.Cell cell_left_gray;

		// Token: 0x040004BB RID: 1211
		private SourceGrid.Cells.Views.Cell cell_total;

		// Token: 0x040004BC RID: 1212
		private SourceGrid.Cells.Views.Cell cell_green;

		// Token: 0x040004BD RID: 1213
		private SourceGrid.Cells.Views.Cell cell_red;

		// Token: 0x040004BE RID: 1214
		private SourceGrid.Cells.Views.Cell cell_right_sgray;

		// Token: 0x040004BF RID: 1215
		private SourceGrid.Cells.Views.Cell cell_left_sgray;

		// Token: 0x040004C0 RID: 1216
		private SourceGrid.Cells.Views.Cell cell_right_dark_sgray;

		// Token: 0x040004C1 RID: 1217
		private SourceGrid.Cells.Views.Cell cell_left_dark_sgray;

		// Token: 0x040004C2 RID: 1218
		private SourceGrid.Cells.Views.Cell cell_right;

		// Token: 0x040004C3 RID: 1219
		private SourceGrid.Cells.Views.Cell cell_left;

		// Token: 0x040004C4 RID: 1220
		private SourceGrid.Cells.Views.Cell cell_center;

		// Token: 0x040004C5 RID: 1221
		private SourceGrid.Cells.Views.Cell cell_limit;

		// Token: 0x040004C6 RID: 1222
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x040004C7 RID: 1223
		private SourceGrid.Cells.Views.Cell cell_header2;

		// Token: 0x040004C8 RID: 1224
		private SourceGrid.Cells.Views.Cell cell_header3;

		// Token: 0x040004C9 RID: 1225
		private SourceGrid.Cells.Views.Cell cell_header4;

		// Token: 0x040004CA RID: 1226
		private SourceGrid.Cells.Views.Cell cell_header5;

		// Token: 0x040004CB RID: 1227
		private SourceGrid.Cells.Views.Cell cell_header6;

		// Token: 0x040004CC RID: 1228
		private SourceGrid.Cells.Views.Cell cell_yello;

		// Token: 0x0200003C RID: 60
		public class SocketCommentHistoryColumn
		{
			// Token: 0x040004DD RID: 1245
			public const int No = 0;

			// Token: 0x040004DE RID: 1246
			public const int Site = 1;

			// Token: 0x040004DF RID: 1247
			public const int Tester = 2;

			// Token: 0x040004E0 RID: 1248
			public const int RequestDate = 3;

			// Token: 0x040004E1 RID: 1249
			public const int RequestComment = 4;

			// Token: 0x040004E2 RID: 1250
			public const int RequestName = 5;

			// Token: 0x040004E3 RID: 1251
			public const int CompletedDate = 6;

			// Token: 0x040004E4 RID: 1252
			public const int CompletedComment = 7;

			// Token: 0x040004E5 RID: 1253
			public const int PinCount = 8;

			// Token: 0x040004E6 RID: 1254
			public const int CompletedName = 9;

			// Token: 0x040004E7 RID: 1255
			public const int Select = 10;
		}
	}
}
