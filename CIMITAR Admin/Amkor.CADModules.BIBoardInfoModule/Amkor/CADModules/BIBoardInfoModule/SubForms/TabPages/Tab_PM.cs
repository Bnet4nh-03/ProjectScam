using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AlteraSocketView.View;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using DATA;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms.TabPages
{
	// Token: 0x0200002D RID: 45
	public class Tab_PM : Tab_Base
	{
		// Token: 0x0600015A RID: 346 RVA: 0x0001EBA8 File Offset: 0x0001CDA8
		public Tab_PM(string title)
		{
			this.Text = title;
			this.InitializeComponent();
			this._biBoardInfos = new List<CBIBoardInfo>();
			this._gridIdx_BIBoard = new CGridIndex_BoardInfo();
			this._gridIdx_BIBoard_Warranty = new CGridIndex_BoardInfo_Warranty();
			this.Clear();
			this._instance = BIBoardInfoModule._instance;
			this.InitContextBox();
			this.radioBtn_Under.Visible = false;
			this.radioBtn_OutOf.Visible = false;
			this.radioBtn_Under.Select();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0001EC3C File Offset: 0x0001CE3C
		private void btn_search_Click(object sender, EventArgs e)
		{
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
			if (this.chkBox_SearchPM.Checked)
			{
				BIBoardPMList biboardPMList = new BIBoardPMList(text, this._instance);
				biboardPMList.ShowDialog();
				if (biboardPMList.DialogResult == DialogResult.OK)
				{
					text = biboardPMList._biBoardNo;
				}
			}
			this.tb_biboardno.Text = text;
			this._biBoardInfos = this._instance.GetBIBoardInfo(text);
			if (this._biBoardInfos == null)
			{
				return;
			}
			if (this._biBoardInfos.Count == 0)
			{
				MessageBox.Show("No Information");
				return;
			}
			this.ResetGrid(this.grid_biboard_history_Curr);
			this.SetGridInfo_Curr(this._biBoardInfos);
			this.ResetGrid(this.grid_biboard_history_Old);
			this.SetGridInfo_Old(this._biBoardInfos);
			this.ResetGrid(this.grid_WarrantyInfo);
			this.SetGridInfo_Warranty(this._biBoardInfos);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0001ED58 File Offset: 0x0001CF58
		private void tb_biboardno_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Convert.ToInt32(e.KeyChar) == 13)
			{
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
				if (this.chkBox_SearchPM.Checked)
				{
					BIBoardPMList biboardPMList = new BIBoardPMList(text, this._instance);
					biboardPMList.ShowDialog();
					if (biboardPMList.DialogResult == DialogResult.OK)
					{
						text = biboardPMList._biBoardNo;
					}
				}
				this.tb_biboardno.Text = text;
				this._biBoardInfos = this._instance.GetBIBoardInfo(text);
				if (this._biBoardInfos == null)
				{
					return;
				}
				if (this._biBoardInfos.Count == 0)
				{
					MessageBox.Show("No Information");
					return;
				}
				this.ResetGrid(this.grid_biboard_history_Curr);
				this.SetGridInfo_Curr(this._biBoardInfos);
				this.ResetGrid(this.grid_biboard_history_Old);
				this.SetGridInfo_Old(this._biBoardInfos);
				this.ResetGrid(this.grid_WarrantyInfo);
				this.SetGridInfo_Warranty(this._biBoardInfos);
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0001EE88 File Offset: 0x0001D088
		private void btn_Insert_Click(object sender, EventArgs e)
		{
			CBIBoardInfo bibInfo = new CBIBoardInfo();
			this._instance.GetBIBoardSocketInfo_Insert(bibInfo, 24);
			BIBoardSocketInfo biboardSocketInfo = new BIBoardSocketInfo(bibInfo, this._instance._cimitarUser._id, this._instance._factorySetting._urlServer, this._instance, true);
			biboardSocketInfo.ShowDialog();
			if (biboardSocketInfo.DialogResult == DialogResult.OK)
			{
				string text = this.tb_biboardno.Text;
				if (text != "")
				{
					this._biBoardInfos = this._instance.GetBIBoardInfo(text);
					this.ResetGrid(this.grid_biboard_history_Curr);
					this.SetGridInfo_Curr(this._biBoardInfos);
					return;
				}
				this.Clear();
				this._biBoardInfos = this._instance.GetAllBIBoardInfo();
				this.ResetGrid(this.grid_biboard_history_Curr);
				this.SetGridInfo_Curr(this._biBoardInfos);
				this.ResetGrid(this.grid_biboard_history_Old);
				this.SetGridInfo_Old(this._biBoardInfos);
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0001EF74 File Offset: 0x0001D174
		private void pb_SearchAll_MouseUp(object sender, MouseEventArgs e)
		{
			this._biBoardInfos = this._instance.GetAllBIBoardInfo();
			this.ResetGrid(this.grid_biboard_history_Curr);
			this.SetGridInfo_Curr(this._biBoardInfos);
			this.ResetGrid(this.grid_biboard_history_Old);
			this.SetGridInfo_Old(this._biBoardInfos);
			this.ResetGrid(this.grid_WarrantyInfo);
			this.SetGridInfo_Warranty(this._biBoardInfos);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0001EFDA File Offset: 0x0001D1DA
		private void pb_SaveExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_SaveExcel.Image = Resources.SaveExcel_Down;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0001EFEC File Offset: 0x0001D1EC
		private void pb_SaveExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_SaveExcel.Image = Resources.SaveExcel;
			new SaveExcel_Sum(this._instance._factorySetting._urlServer).ShowDialog();
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0001F01C File Offset: 0x0001D21C
		private void pb_PartChange_MouseUp(object sender, MouseEventArgs e)
		{
			string text = this.tb_biboardno.Text;
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
			new SocketPartChange(text, this._instance).ShowDialog();
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0001F078 File Offset: 0x0001D278
		private void grid_biboard_history_Curr_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.grid_biboard_history_Curr.Selection.ActivePosition.Row < 0)
			{
				return;
			}
			int row = this.grid_biboard_history_Curr.Selection.ActivePosition.Row;
			int num = Convert.ToInt32(this.grid_biboard_history_Curr[row, this._gridIdx_BIBoard.iGridId].ToString());
			CBIBoardInfo cbiboardInfo = null;
			foreach (CBIBoardInfo cbiboardInfo2 in this._biBoardInfos)
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

		// Token: 0x06000163 RID: 355 RVA: 0x0001F184 File Offset: 0x0001D384
		private void grid_biboard_history_Curr_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.grid_biboard_history_Curr.Selection.ActivePosition.Row >= 0)
				{
					int row = this.grid_biboard_history_Curr.Selection.ActivePosition.Row;
					int num = Convert.ToInt32(this.grid_biboard_history_Curr[row, this._gridIdx_BIBoard.iGridId].ToString());
					CBIBoardInfo cbiboardInfo = null;
					foreach (CBIBoardInfo cbiboardInfo2 in this._biBoardInfos)
					{
						if (cbiboardInfo2.iId == num)
						{
							cbiboardInfo = cbiboardInfo2;
						}
					}
					if (cbiboardInfo != null)
					{
						this._instance.GetBIBoardSocketInfo(cbiboardInfo);
						BIBoardSocketInfo biboardSocketInfo = new BIBoardSocketInfo(cbiboardInfo, this._instance._cimitarUser._id, this._instance._factorySetting._urlServer, this._instance);
						biboardSocketInfo.ShowDialog();
						if (biboardSocketInfo.DialogResult == DialogResult.OK)
						{
							string text = this.tb_biboardno.Text;
							if (text != "")
							{
								this._biBoardInfos = this._instance.GetBIBoardInfo(text);
								this.ResetGrid(this.grid_biboard_history_Curr);
								this.SetGridInfo_Curr(this._biBoardInfos);
							}
							else
							{
								this.Clear();
								this._biBoardInfos = this._instance.GetAllBIBoardInfo();
								this.ResetGrid(this.grid_biboard_history_Curr);
								this.SetGridInfo_Curr(this._biBoardInfos);
								this.ResetGrid(this.grid_biboard_history_Old);
								this.SetGridInfo_Old(this._biBoardInfos);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("grid_ReqStatus_MouseDoubleClick: " + ex.Message);
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0001F35C File Offset: 0x0001D55C
		private void grid_biboard_history_Curr_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			this._cntxtMenu_Del_Pm.Show(this.grid_biboard_history_Curr, new Point(e.X, e.Y));
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0001F390 File Offset: 0x0001D590
		private void grid_biboard_history_Old_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.grid_biboard_history_Old.Selection.ActivePosition.Row < 0)
			{
				return;
			}
			int row = this.grid_biboard_history_Old.Selection.ActivePosition.Row;
			int num = Convert.ToInt32(this.grid_biboard_history_Old[row, this._gridIdx_BIBoard.iGridId].ToString());
			string b = this.grid_biboard_history_Old[row, this._gridIdx_BIBoard.iGridBarcode].ToString();
			CBIBoardInfo cbiboardInfo = null;
			if (num != 0)
			{
				using (List<CBIBoardInfo>.Enumerator enumerator = this._biBoardInfos.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CBIBoardInfo cbiboardInfo2 = enumerator.Current;
						if (cbiboardInfo2.iOnFlag == 1 && cbiboardInfo2.iId == num)
						{
							cbiboardInfo = cbiboardInfo2;
							break;
						}
					}
					goto IL_114;
				}
			}
			foreach (CBIBoardInfo cbiboardInfo3 in this._biBoardInfos)
			{
				if (cbiboardInfo3.iOnFlag == 1 && cbiboardInfo3.strBarcode == b)
				{
					cbiboardInfo = cbiboardInfo3;
					break;
				}
			}
			IL_114:
			if (cbiboardInfo != null)
			{
				this.l_bib_No.Text = cbiboardInfo.strBibNo;
				this.l_device.Text = cbiboardInfo.strDevice;
				this.l_customer.Text = cbiboardInfo.strCustomer;
				this.l_location.Text = cbiboardInfo.strLocation;
				this.l_barcode.Text = cbiboardInfo.strBarcode;
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0001F528 File Offset: 0x0001D728
		private void grid_biboard_history_Old_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.grid_biboard_history_Old.Selection.ActivePosition.Row >= 0)
				{
					int row = this.grid_biboard_history_Old.Selection.ActivePosition.Row;
					int num = Convert.ToInt32(this.grid_biboard_history_Old[row, this._gridIdx_BIBoard.iGridId].ToString());
					string b = this.grid_biboard_history_Old[row, this._gridIdx_BIBoard.iGridBarcode].ToString();
					CBIBoardInfo cbiboardInfo = null;
					if (num != 0)
					{
						foreach (CBIBoardInfo cbiboardInfo2 in this._biBoardInfos)
						{
							if (cbiboardInfo2.iOnFlag == 1 && cbiboardInfo2.iId == num)
							{
								cbiboardInfo = cbiboardInfo2;
								break;
							}
						}
						if (cbiboardInfo != null)
						{
							this._instance.GetBIBoardSocketInfo(cbiboardInfo);
							BIBoardSocketInfo biboardSocketInfo = new BIBoardSocketInfo(cbiboardInfo, this._instance._cimitarUser._id, this._instance._factorySetting._urlServer, this._instance);
							biboardSocketInfo.ShowDialog();
							if (biboardSocketInfo.DialogResult == DialogResult.OK)
							{
								string text = this.tb_biboardno.Text;
								if (text != "")
								{
									this._biBoardInfos = this._instance.GetBIBoardInfo(text);
									this.ResetGrid(this.grid_biboard_history_Curr);
									this.SetGridInfo_Curr(this._biBoardInfos);
								}
								else
								{
									this.Clear();
									this._biBoardInfos = this._instance.GetAllBIBoardInfo();
									this.ResetGrid(this.grid_biboard_history_Curr);
									this.SetGridInfo_Curr(this._biBoardInfos);
									this.ResetGrid(this.grid_biboard_history_Old);
									this.SetGridInfo_Old(this._biBoardInfos);
								}
							}
						}
					}
					else
					{
						MessageBox.Show("Selected Item isn't in DB");
						foreach (CBIBoardInfo cbiboardInfo3 in this._biBoardInfos)
						{
							if (cbiboardInfo3.iOnFlag == 1 && cbiboardInfo3.strBarcode == b)
							{
								cbiboardInfo = cbiboardInfo3;
								break;
							}
						}
						this._instance.GetBIBoardSocketInfo_Insert(cbiboardInfo, 24);
						BIBoardSocketInfo biboardSocketInfo2 = new BIBoardSocketInfo(cbiboardInfo, this._instance._cimitarUser._id, this._instance._factorySetting._urlServer, this._instance, true);
						biboardSocketInfo2.ShowDialog();
						if (biboardSocketInfo2.DialogResult == DialogResult.OK)
						{
							string text2 = this.tb_biboardno.Text;
							if (text2 != "")
							{
								this._biBoardInfos = this._instance.GetBIBoardInfo(text2);
								this.ResetGrid(this.grid_biboard_history_Curr);
								this.SetGridInfo_Curr(this._biBoardInfos);
							}
							else
							{
								this.Clear();
								this._biBoardInfos = this._instance.GetAllBIBoardInfo();
								this.ResetGrid(this.grid_biboard_history_Curr);
								this.SetGridInfo_Curr(this._biBoardInfos);
								this.ResetGrid(this.grid_biboard_history_Old);
								this.SetGridInfo_Old(this._biBoardInfos);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("grid_ReqStatus_MouseDoubleClick: " + ex.Message);
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0001F888 File Offset: 0x0001DA88
		private void grid_WarrantyInfo_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			this._cntxtMenu_Warranty.Show(this.grid_WarrantyInfo, new Point(e.X, e.Y));
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0001F8BA File Offset: 0x0001DABA
		private void tabCtrl_Grid_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SetRadioBtn(this.tabCtrl_Grid.SelectedIndex);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0001F8CD File Offset: 0x0001DACD
		private void radioBtn_Under_CheckedChanged(object sender, EventArgs e)
		{
			this.ResetGrid(this.grid_WarrantyInfo);
			this.SetGridInfo_Warranty(this._biBoardInfos);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0001F8E8 File Offset: 0x0001DAE8
		private void clickEvent_Click(object sender, EventArgs e)
		{
			if (this.grid_biboard_history_Curr.Selection.ActivePosition.Row < 0)
			{
				return;
			}
			int row = this.grid_biboard_history_Curr.Selection.ActivePosition.Row;
			int groupId = Convert.ToInt32(this.grid_biboard_history_Curr[row, this._gridIdx_BIBoard.iGridId].ToString());
			CheckBadgeNo checkBadgeNo = new CheckBadgeNo(this._instance._cimitarUser._badgeNo);
			checkBadgeNo.ShowDialog();
			string badgeNo = string.Empty;
			string comment = string.Empty;
			if (checkBadgeNo.DialogResult == DialogResult.OK)
			{
				badgeNo = checkBadgeNo._badgeNo;
				comment = checkBadgeNo._comment;
				this.UpdateComment(groupId, badgeNo, comment);
				return;
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0001F99C File Offset: 0x0001DB9C
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

		// Token: 0x0600016C RID: 364 RVA: 0x0001F9E4 File Offset: 0x0001DBE4
		private void SetHeaderInfo(string[] gridHeaders, Grid grid)
		{
			grid.ColumnsCount = gridHeaders.Length + 1;
			grid.FixedRows = 1;
			grid.FixedColumns = 4;
			grid.Rows.Insert(0);
			this.CreateColHeaderCheckBox(grid, new System.Windows.Forms.CheckBox());
			grid[0, 0] = new SourceGrid.Cells.ColumnHeader("");
			grid[0, 0].View = this._instance._cell_header1;
			for (int i = 0; i < gridHeaders.Length; i++)
			{
				grid[0, i + 1] = new SourceGrid.Cells.ColumnHeader(gridHeaders[i]);
				grid[0, i + 1].View = this._instance._cell_header1;
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0001FA88 File Offset: 0x0001DC88
		private void CreateColHeaderCheckBox(Grid grid, System.Windows.Forms.CheckBox checkBox)
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

		// Token: 0x0600016E RID: 366 RVA: 0x0001FB24 File Offset: 0x0001DD24
		private void checkBox_CheckedChanged(object sender, EventArgs e)
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

		// Token: 0x0600016F RID: 367 RVA: 0x0001FBA8 File Offset: 0x0001DDA8
		private void SetGridInfo_Curr(List<CBIBoardInfo> cBibInfos)
		{
			if (cBibInfos.Count == 0)
			{
				return;
			}
			cBibInfos = (from o in cBibInfos
			orderby o.dtPm descending
			select o).ToList<CBIBoardInfo>();
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Drawing..");
			this._barPrograss.setMax(cBibInfos.Count);
			this._barPrograss.setValue(0);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			int num = 1;
			string[] headers = this._gridIdx_BIBoard.headers;
			this.SetHeaderInfo(headers, this.grid_biboard_history_Curr);
			DateTime t = DateTime.Now.AddDays(-24.0);
			DateTime now = DateTime.Now;
			try
			{
				if (cBibInfos.Count != 0)
				{
					foreach (CBIBoardInfo cbiboardInfo in cBibInfos)
					{
						if (cbiboardInfo.iId != 0)
						{
							this.grid_biboard_history_Curr.Rows.Insert(num);
							this.grid_biboard_history_Curr[num, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iNo] = new Cell(num);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridId] = new Cell(cbiboardInfo.iId);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridBibNo] = new Cell(cbiboardInfo.strBibNo);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridDevice] = new Cell(cbiboardInfo.strDevice);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridCustomer] = new Cell(cbiboardInfo.strCustomer);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridLocation] = new Cell(cbiboardInfo.strLocation);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridBarcode] = new Cell(cbiboardInfo.strBarcode);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridUserId] = new Cell(cbiboardInfo.strUserId);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridUserName] = new Cell(cbiboardInfo.strUserName);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridUserBdno] = new Cell(cbiboardInfo.strUserBdno);
							if (cbiboardInfo.iOnFlag == 1)
							{
								CustomEvents customEvents = new CustomEvents();
								customEvents.Click += this.clickEvent_Click;
								this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridComment] = new SourceGrid.Cells.Button(cbiboardInfo.strComment);
								this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridComment].AddController(customEvents);
							}
							else
							{
								this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridComment] = new Cell(cbiboardInfo.strComment);
							}
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridPmDate] = new Cell(cbiboardInfo.dtPm.ToString("yyyy-MM-dd HH:mm:ss"));
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridIntime] = new Cell(cbiboardInfo.dtInTime.ToString("yyyy-MM-dd HH:mm:ss"));
							if (cbiboardInfo.strBad_bib == "0")
							{
								this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridBad] = new Cell("");
							}
							else
							{
								this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridBad] = new Cell("");
								this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridBad].Image = Resources.check;
							}
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridOnFlag] = new Cell(cbiboardInfo.iOnFlag);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridBadSocket] = new Cell(cbiboardInfo.iCntBadSocket);
							this.grid_biboard_history_Curr[num, this._gridIdx_BIBoard.iGridDDay] = new Cell(-1 * cbiboardInfo.iCntDDay);
							for (int i = 0; i < this._gridIdx_BIBoard.headers.Length + 1; i++)
							{
								if (i != this._gridIdx_BIBoard.iGridComment || cbiboardInfo.iOnFlag != 1)
								{
									if (cbiboardInfo.iOnFlag == 1)
									{
										if (i == 0)
										{
											if (cbiboardInfo.iId != 0 && cbiboardInfo.dtPm < t)
											{
												if (cbiboardInfo.iCntDDay <= 0)
												{
													this.grid_biboard_history_Curr[num, i].View = this._instance._checkBox_PmOverList;
												}
												else
												{
													this.grid_biboard_history_Curr[num, i].View = this._instance._checkBox_PmList;
												}
											}
											else
											{
												this.grid_biboard_history_Curr[num, i].View = this._instance._checkBox_OnFlag;
											}
										}
										else if (cbiboardInfo.iId != 0 && cbiboardInfo.dtPm < t)
										{
											if (cbiboardInfo.iCntDDay <= 0)
											{
												this.grid_biboard_history_Curr[num, i].View = this._instance._cell_PmOverList;
											}
											else
											{
												this.grid_biboard_history_Curr[num, i].View = this._instance._cell_PmList;
											}
										}
										else
										{
											this.grid_biboard_history_Curr[num, i].View = this._instance._cell_onflag;
										}
									}
									else if (num % 2 == 0)
									{
										if (i == 0)
										{
											this.grid_biboard_history_Curr[num, i].View = this._instance._checkBox_Normal1;
										}
										else
										{
											this.grid_biboard_history_Curr[num, i].View = this._instance._cell_center1;
										}
									}
									else if (i == 0)
									{
										this.grid_biboard_history_Curr[num, i].View = this._instance._checkBox_Normal2;
									}
									else
									{
										this.grid_biboard_history_Curr[num, i].View = this._instance._cell_center2;
									}
								}
							}
							num++;
							this._barPrograss.progress_increase();
						}
					}
				}
				this.SetColWidth(1, this.grid_biboard_history_Curr);
				Thread.Sleep(10);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Thread.Sleep(10);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000202C0 File Offset: 0x0001E4C0
		private void SetGridInfo_Old(List<CBIBoardInfo> cBibInfos)
		{
			if (cBibInfos.Count == 0)
			{
				return;
			}
			List<CBIBoardInfo> list = (from o in cBibInfos
			orderby o.dtPm
			select o).ToList<CBIBoardInfo>();
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Drawing..");
			this._barPrograss.setMax(list.Count);
			this._barPrograss.setValue(0);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			int num = 1;
			string[] headers = this._gridIdx_BIBoard.headers;
			this.SetHeaderInfo(headers, this.grid_biboard_history_Old);
			DateTime t = DateTime.Now.AddDays(-24.0);
			try
			{
				if (list.Count != 0)
				{
					foreach (CBIBoardInfo cbiboardInfo in list)
					{
						if (cbiboardInfo.iOnFlag == 1)
						{
							this.grid_biboard_history_Old.Rows.Insert(num);
							this.grid_biboard_history_Old[num, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iNo] = new Cell(num);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridId] = new Cell(cbiboardInfo.iId);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridBibNo] = new Cell(cbiboardInfo.strBibNo);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridDevice] = new Cell(cbiboardInfo.strDevice);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridCustomer] = new Cell(cbiboardInfo.strCustomer);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridLocation] = new Cell(cbiboardInfo.strLocation);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridBarcode] = new Cell(cbiboardInfo.strBarcode);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridUserId] = new Cell(cbiboardInfo.strUserId);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridUserName] = new Cell(cbiboardInfo.strUserName);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridUserBdno] = new Cell(cbiboardInfo.strUserBdno);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridComment] = new Cell(cbiboardInfo.strComment);
							if (cbiboardInfo.iId != 0)
							{
								this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridPmDate] = new Cell(cbiboardInfo.dtPm.ToString("yyyy-MM-dd HH:mm:ss"));
								this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridIntime] = new Cell(cbiboardInfo.dtInTime.ToString("yyyy-MM-dd HH:mm:ss"));
							}
							else
							{
								this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridPmDate] = new Cell(cbiboardInfo.dtPm.ToString("NULL"));
								this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridIntime] = new Cell(cbiboardInfo.dtInTime.ToString("NULL"));
							}
							if (cbiboardInfo.strBad_bib == "0")
							{
								this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridBad] = new Cell("");
							}
							else
							{
								this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridBad] = new Cell("");
								this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridBad].Image = Resources.check;
							}
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridOnFlag] = new Cell(cbiboardInfo.iOnFlag);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridBadSocket] = new Cell(cbiboardInfo.iCntBadSocket);
							this.grid_biboard_history_Old[num, this._gridIdx_BIBoard.iGridDDay] = new Cell(-1 * cbiboardInfo.iCntDDay);
							for (int i = 0; i < this._gridIdx_BIBoard.headers.Length + 1; i++)
							{
								if (cbiboardInfo.iOnFlag == 1)
								{
									if (cbiboardInfo.iId != 0)
									{
										if (i == 0)
										{
											if (cbiboardInfo.iId != 0 && cbiboardInfo.dtPm < t)
											{
												if (cbiboardInfo.iCntDDay <= 0)
												{
													this.grid_biboard_history_Old[num, i].View = this._instance._checkBox_PmOverList;
												}
												else
												{
													this.grid_biboard_history_Old[num, i].View = this._instance._checkBox_PmList;
												}
											}
											else
											{
												this.grid_biboard_history_Old[num, i].View = this._instance._checkBox_OnFlag;
											}
										}
										else if (cbiboardInfo.iId != 0 && cbiboardInfo.dtPm < t)
										{
											if (cbiboardInfo.iCntDDay <= 0)
											{
												this.grid_biboard_history_Old[num, i].View = this._instance._cell_PmOverList;
											}
											else
											{
												this.grid_biboard_history_Old[num, i].View = this._instance._cell_PmList;
											}
										}
										else
										{
											this.grid_biboard_history_Old[num, i].View = this._instance._cell_onflag;
										}
									}
									else if (num % 2 == 0)
									{
										if (i == 0)
										{
											this.grid_biboard_history_Old[num, i].View = this._instance._checkBox_Normal1;
										}
										else
										{
											this.grid_biboard_history_Old[num, i].View = this._instance._cell_center1;
										}
									}
									else if (i == 0)
									{
										this.grid_biboard_history_Old[num, i].View = this._instance._checkBox_Normal2;
									}
									else
									{
										this.grid_biboard_history_Old[num, i].View = this._instance._cell_center2;
									}
								}
								else if (num % 2 == 0)
								{
									if (i == 0)
									{
										this.grid_biboard_history_Old[num, i].View = this._instance._checkBox_Normal1;
									}
									else
									{
										this.grid_biboard_history_Old[num, i].View = this._instance._cell_center1;
									}
								}
								else if (i == 0)
								{
									this.grid_biboard_history_Old[num, i].View = this._instance._checkBox_Normal2;
								}
								else
								{
									this.grid_biboard_history_Old[num, i].View = this._instance._cell_center2;
								}
							}
							num++;
							this._barPrograss.progress_increase();
						}
					}
					this.SetColWidth(1, this.grid_biboard_history_Old);
				}
				Thread.Sleep(10);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Thread.Sleep(10);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00020A5C File Offset: 0x0001EC5C
		private void SetGridInfo_Warranty(List<CBIBoardInfo> cBibInfos)
		{
			if (cBibInfos.Count == 0)
			{
				return;
			}
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Drawing..");
			this._barPrograss.setMax(cBibInfos.Count);
			this._barPrograss.setValue(0);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			if (this.radioBtn_Under.Checked)
			{
				cBibInfos = (from o in cBibInfos
				where o.strWarranty == "Under"
				select o).ToList<CBIBoardInfo>();
			}
			else
			{
				cBibInfos = (from o in cBibInfos
				where o.strWarranty == "Out Of"
				select o).ToList<CBIBoardInfo>();
			}
			int num = 1;
			string[] headers = this._gridIdx_BIBoard_Warranty.headers;
			this.SetHeaderInfo(headers, this.grid_WarrantyInfo);
			try
			{
				if (cBibInfos.Count != 0)
				{
					foreach (CBIBoardInfo cbiboardInfo in cBibInfos)
					{
						if (cbiboardInfo.iOnFlag == 1 && cbiboardInfo.iId != 0 && cbiboardInfo.iId != 0)
						{
							this.grid_WarrantyInfo.Rows.Insert(num);
							this.grid_WarrantyInfo[num, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
							this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iNo] = new Cell(num);
							this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iWarranty] = new Cell(cbiboardInfo.strWarranty);
							this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridId] = new Cell(cbiboardInfo.iId);
							this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridBibNo] = new Cell(cbiboardInfo.strBibNo);
							this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridDevice] = new Cell(cbiboardInfo.strDevice);
							this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridCustomer] = new Cell(cbiboardInfo.strCustomer);
							this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridBarcode] = new Cell(cbiboardInfo.strBarcode);
							this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridComment] = new Cell(cbiboardInfo.strComment);
							if (cbiboardInfo.strBad_bib == "0")
							{
								this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridBad] = new Cell("");
							}
							else
							{
								this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridBad] = new Cell("");
								this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridBad].Image = Resources.check;
							}
							this.grid_WarrantyInfo[num, this._gridIdx_BIBoard_Warranty.iGridIntime] = new Cell(cbiboardInfo.dtInTime.ToString("yyyy-MM-dd HH:mm:ss"));
							for (int i = 0; i < this._gridIdx_BIBoard_Warranty.headers.Length + 1; i++)
							{
								if (num % 2 == 0)
								{
									if (i == 0)
									{
										this.grid_WarrantyInfo[num, i].View = this._instance._checkBox_Normal1;
									}
									else
									{
										this.grid_WarrantyInfo[num, i].View = this._instance._cell_center1;
									}
								}
								else if (i == 0)
								{
									this.grid_WarrantyInfo[num, i].View = this._instance._checkBox_Normal2;
								}
								else
								{
									this.grid_WarrantyInfo[num, i].View = this._instance._cell_center2;
								}
							}
							num++;
							this._barPrograss.progress_increase();
						}
					}
				}
				this.SetColWidth(2, this.grid_WarrantyInfo);
				Thread.Sleep(10);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Thread.Sleep(10);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00020EE0 File Offset: 0x0001F0E0
		private void SetColWidth(int typeNo, Grid grid)
		{
			if (typeNo == 1)
			{
				grid.Columns[0].Width = 10;
				grid.Columns[this._gridIdx_BIBoard.iNo].Width = 35;
				grid.Columns[this._gridIdx_BIBoard.iGridId].Width = 45;
				grid.Columns[this._gridIdx_BIBoard.iGridBibNo].Width = 60;
				grid.Columns[this._gridIdx_BIBoard.iGridDevice].Width = 100;
				grid.Columns[this._gridIdx_BIBoard.iGridCustomer].Width = 90;
				grid.Columns[this._gridIdx_BIBoard.iGridLocation].Width = 90;
				grid.Columns[this._gridIdx_BIBoard.iGridBarcode].Width = 110;
				grid.Columns[this._gridIdx_BIBoard.iGridUserId].Width = 100;
				grid.Columns[this._gridIdx_BIBoard.iGridUserName].Width = 100;
				grid.Columns[this._gridIdx_BIBoard.iGridUserBdno].Width = 70;
				grid.Columns[this._gridIdx_BIBoard.iGridComment].Width = 70;
				grid.Columns[this._gridIdx_BIBoard.iGridPmDate].Width = 130;
				grid.Columns[this._gridIdx_BIBoard.iGridIntime].Width = 130;
				grid.Columns[this._gridIdx_BIBoard.iGridBad].Width = 40;
				grid.Columns[this._gridIdx_BIBoard.iGridOnFlag].Width = 0;
				grid.Columns[this._gridIdx_BIBoard.iGridBadSocket].Width = 90;
				grid.Columns[this._gridIdx_BIBoard.iGridDDay].Width = 70;
				return;
			}
			if (typeNo != 2)
			{
				return;
			}
			grid.Columns[0].Width = 10;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iNo].Width = 35;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iWarranty].Width = 90;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iGridId].Width = 45;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iGridBibNo].Width = 60;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iGridDevice].Width = 100;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iGridCustomer].Width = 90;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iGridBarcode].Width = 110;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iGridComment].Width = 70;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iGridBad].Width = 40;
			grid.Columns[this._gridIdx_BIBoard_Warranty.iGridIntime].Width = 130;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00021238 File Offset: 0x0001F438
		private void Clear()
		{
			this.l_bib_No.Text = "";
			this.l_device.Text = "";
			this.l_customer.Text = "";
			this.l_location.Text = "";
			this.l_barcode.Text = "";
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00021298 File Offset: 0x0001F498
		private void InitContextBox()
		{
			this._cntxtMenu_Del_Pm.Items.Clear();
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Delete");
			toolStripMenuItem.Image = Resources.TableRemove;
			toolStripMenuItem.Click += this._cntxtMenu_Delete_Click;
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("UPDATE PM");
			toolStripMenuItem2.Image = Resources.TableSave;
			toolStripMenuItem2.Click += this._cntxtMenu_PM_Click;
			this._cntxtMenu_Del_Pm.Items.Add(toolStripMenuItem);
			this._cntxtMenu_Del_Pm.Items.Add(toolStripMenuItem2);
			this._cntxtMenu_Warranty.Items.Clear();
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("Under");
			toolStripMenuItem3.Image = Resources.TableSave;
			toolStripMenuItem3.Click += this._cntxtMenu_Warranty_Click;
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem("Out Of");
			toolStripMenuItem4.Image = Resources.TableSave;
			toolStripMenuItem4.Click += this._cntxtMenu_Warranty_Click;
			this._cntxtMenu_Warranty.Items.Add(toolStripMenuItem3);
			this._cntxtMenu_Warranty.Items.Add(toolStripMenuItem4);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000213B0 File Offset: 0x0001F5B0
		private void _cntxtMenu_Delete_Click(object sender, EventArgs e)
		{
			List<int> list = new List<int>();
			for (int i = 1; i < this.grid_biboard_history_Curr.Rows.Count; i++)
			{
				bool? @checked = ((SourceGrid.Cells.CheckBox)this.grid_biboard_history_Curr[i, 0]).Checked;
				bool flag = true;
				if (@checked.GetValueOrDefault() == flag & @checked != null)
				{
					int item = int.Parse(this.grid_biboard_history_Curr[i, this._gridIdx_BIBoard.iGridId].Value.ToString());
					if (int.Parse(this.grid_biboard_history_Curr[i, this._gridIdx_BIBoard.iGridOnFlag].Value.ToString()) == 1)
					{
						MessageBox.Show("Select History Info");
						return;
					}
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				MessageBox.Show("Select an item");
				return;
			}
			if (list.Count > 1)
			{
				MessageBox.Show("Select one");
				return;
			}
			CheckBadgeNo checkBadgeNo = new CheckBadgeNo();
			checkBadgeNo.ShowDialog();
			string badgeNo = string.Empty;
			string comment = string.Empty;
			if (checkBadgeNo.DialogResult == DialogResult.OK)
			{
				badgeNo = checkBadgeNo._badgeNo;
				comment = checkBadgeNo._comment;
				foreach (int groupId in list)
				{
					this.DeleteBIB(groupId, badgeNo, comment);
				}
				string text = this.tb_biboardno.Text;
				if (text == "")
				{
					this._biBoardInfos = this._instance.GetAllBIBoardInfo();
				}
				else
				{
					this._biBoardInfos = this._instance.GetBIBoardInfo(text);
				}
				this.ResetGrid(this.grid_biboard_history_Curr);
				this.SetGridInfo_Curr(this._biBoardInfos);
				return;
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00021580 File Offset: 0x0001F780
		private void _cntxtMenu_PM_Click(object sender, EventArgs e)
		{
			List<int> list = new List<int>();
			for (int i = 1; i < this.grid_biboard_history_Curr.Rows.Count; i++)
			{
				bool? @checked = ((SourceGrid.Cells.CheckBox)this.grid_biboard_history_Curr[i, 0]).Checked;
				bool flag = true;
				if (@checked.GetValueOrDefault() == flag & @checked != null)
				{
					int item = int.Parse(this.grid_biboard_history_Curr[i, this._gridIdx_BIBoard.iGridId].Value.ToString());
					if (int.Parse(this.grid_biboard_history_Curr[i, this._gridIdx_BIBoard.iGridOnFlag].Value.ToString()) == 0)
					{
						MessageBox.Show("Select Status Info");
						return;
					}
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				MessageBox.Show("Select an item");
				return;
			}
			if (list.Count > 1)
			{
				MessageBox.Show("Select one");
				return;
			}
			CheckBadgeNo checkBadgeNo = new CheckBadgeNo();
			checkBadgeNo.ShowDialog();
			string badgeNo = string.Empty;
			string comment = string.Empty;
			if (checkBadgeNo.DialogResult == DialogResult.OK)
			{
				badgeNo = checkBadgeNo._badgeNo;
				comment = checkBadgeNo._comment;
				foreach (int groupId in list)
				{
					this.UpdatePM(groupId, badgeNo, comment);
				}
				string text = this.tb_biboardno.Text;
				if (text == "")
				{
					this._biBoardInfos = this._instance.GetAllBIBoardInfo();
				}
				else
				{
					this._biBoardInfos = this._instance.GetBIBoardInfo(text);
				}
				this.ResetGrid(this.grid_biboard_history_Curr);
				this.SetGridInfo_Curr(this._biBoardInfos);
				return;
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0002174C File Offset: 0x0001F94C
		private void _cntxtMenu_Warranty_Click(object sender, EventArgs e)
		{
			string text = ((ToolStripMenuItem)sender).Text;
			List<int> list = new List<int>();
			for (int i = 1; i < this.grid_WarrantyInfo.Rows.Count; i++)
			{
				bool? @checked = ((SourceGrid.Cells.CheckBox)this.grid_WarrantyInfo[i, 0]).Checked;
				bool flag = true;
				if (@checked.GetValueOrDefault() == flag & @checked != null)
				{
					int item = int.Parse(this.grid_WarrantyInfo[i, this._gridIdx_BIBoard_Warranty.iGridId].Value.ToString());
					if (this.grid_WarrantyInfo[i, this._gridIdx_BIBoard_Warranty.iWarranty].Value.ToString() == text)
					{
						MessageBox.Show("Same Information");
						return;
					}
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				MessageBox.Show("Select an item");
				return;
			}
			CheckBadgeNo checkBadgeNo = new CheckBadgeNo();
			checkBadgeNo.ShowDialog();
			string badgeNo = string.Empty;
			string comment = string.Empty;
			if (checkBadgeNo.DialogResult == DialogResult.OK)
			{
				badgeNo = checkBadgeNo._badgeNo;
				comment = checkBadgeNo._comment;
				foreach (int groupId in list)
				{
					this.UpdateBIB(groupId, badgeNo, comment, text);
				}
				this._biBoardInfos = this._instance.GetAllBIBoardInfo();
				this.ResetGrid(this.grid_WarrantyInfo);
				this.SetGridInfo_Warranty(this._biBoardInfos);
				return;
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000218E4 File Offset: 0x0001FAE4
		private void DeleteBIB(int groupId, string badgeNo, string comment)
		{
			int num = 0;
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Delete..");
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'DEL', @groupId = ",
					groupId.ToString(),
					", @badgeNo = '",
					badgeNo,
					"', @comment = '",
					comment,
					"'"
				});
				dataSet = this._instance.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						num = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
					}
				}
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
				if (num == 0)
				{
					MessageBox.Show("Success to Delete");
				}
				else
				{
					MessageBox.Show("Fail to Delete");
				}
			}
			catch (Exception)
			{
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00021A90 File Offset: 0x0001FC90
		private void UpdatePM(int groupId, string badgeNo, string comment)
		{
			int num = 0;
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Update..");
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'UPDATE_PM', @groupId = ",
					groupId.ToString(),
					", @badgeNo = '",
					badgeNo,
					"', @comment = '",
					comment,
					"'"
				});
				dataSet = this._instance.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						num = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
					}
				}
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
				if (num == 0)
				{
					MessageBox.Show("Success to Update");
				}
				else
				{
					MessageBox.Show("Fail to Update");
				}
			}
			catch (Exception)
			{
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00021C3C File Offset: 0x0001FE3C
		private void UpdateBIB(int groupId, string badgeNo, string comment, string warranty)
		{
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Delete..");
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'UPDATE_WARRANTY', @groupId = ",
					groupId.ToString(),
					", @badgeNo = '",
					badgeNo,
					"', @comment = '",
					comment,
					"', @warranty = '",
					warranty,
					"'"
				});
				dataSet = this._instance.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						int num = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
					}
				}
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
			catch (Exception)
			{
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00021DDC File Offset: 0x0001FFDC
		private void UpdateComment(int groupId, string badgeNo, string comment)
		{
			int num = 0;
			try
			{
				this._barPrograss = new BarPrograss();
				this._barPrograss.progress_labelheader_set("Update..");
				this._barPrograss.setMax(100);
				this._barPrograss.setValue(100);
				this._thread = new Thread(new ThreadStart(this.BarPrograssView));
				this._thread.Start();
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'UPDATE_COMMENT', @groupId = ",
					groupId.ToString(),
					", @badgeNo = '",
					badgeNo,
					"', @comment = '",
					comment,
					"'"
				});
				dataSet = this._instance.QueryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						num = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
					}
				}
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
				if (num == 0)
				{
					MessageBox.Show("Success to Update");
					string text = this.tb_biboardno.Text;
					if (text != "")
					{
						this._biBoardInfos = this._instance.GetBIBoardInfo(text);
						this.ResetGrid(this.grid_biboard_history_Curr);
						this.SetGridInfo_Curr(this._biBoardInfos);
					}
					else
					{
						this.Clear();
						this._biBoardInfos = this._instance.GetAllBIBoardInfo();
						this.ResetGrid(this.grid_biboard_history_Curr);
						this.SetGridInfo_Curr(this._biBoardInfos);
					}
				}
				else
				{
					MessageBox.Show("Fail to Update");
				}
			}
			catch (Exception)
			{
				Thread.Sleep(100);
				if (this._barPrograss != null)
				{
					this._barPrograss._ischeck = true;
				}
				this._barPrograss = null;
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00022004 File Offset: 0x00020204
		private void SetRadioBtn(int tabIdx)
		{
			if (tabIdx == 2)
			{
				this.radioBtn_Under.Visible = true;
				this.radioBtn_OutOf.Visible = true;
				return;
			}
			this.radioBtn_Under.Visible = false;
			this.radioBtn_OutOf.Visible = false;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0002203B File Offset: 0x0002023B
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00022049 File Offset: 0x00020249
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00022068 File Offset: 0x00020268
		private void InitializeComponent()
		{
			this.groupBox4 = new GroupBox();
			this.pb_SaveExcel = new PictureBox();
			this.tabCtrl_Grid = new TabControl();
			this.tabPage1 = new TabPage();
			this.grid_biboard_history_Curr = new Grid();
			this.tabPage2 = new TabPage();
			this.grid_biboard_history_Old = new Grid();
			this.tabPage3 = new TabPage();
			this.grid_WarrantyInfo = new Grid();
			this.groupBox1 = new GroupBox();
			this.pb_SearchAll = new PictureBox();
			this.groupBox3 = new GroupBox();
			this.l_barcode = new Label();
			this.label7 = new Label();
			this.l_location = new Label();
			this.label6 = new Label();
			this.l_customer = new Label();
			this.l_device = new Label();
			this.l_bib_No = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label1 = new Label();
			this.groupBox2 = new GroupBox();
			this.chkBox_SearchPM = new System.Windows.Forms.CheckBox();
			this.btn_Insert = new System.Windows.Forms.Button();
			this.btn_search = new System.Windows.Forms.Button();
			this.tb_biboardno = new TextBox();
			this.radioBtn_Under = new RadioButton();
			this.radioBtn_OutOf = new RadioButton();
			this.groupBox5 = new GroupBox();
			this.pb_PartChange = new PictureBox();
			this.panel1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((ISupportInitialize)this.pb_SaveExcel).BeginInit();
			this.tabCtrl_Grid.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.pb_SearchAll).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((ISupportInitialize)this.pb_PartChange).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox5);
			this.panel1.Controls.Add(this.radioBtn_OutOf);
			this.panel1.Controls.Add(this.radioBtn_Under);
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.tabCtrl_Grid);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox2);
			this.groupBox4.Controls.Add(this.pb_SaveExcel);
			this.groupBox4.Location = new Point(442, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(74, 81);
			this.groupBox4.TabIndex = 32;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Export";
			this.pb_SaveExcel.Cursor = Cursors.Hand;
			this.pb_SaveExcel.Image = Resources.SaveExcel;
			this.pb_SaveExcel.InitialImage = Resources.SaveExcel;
			this.pb_SaveExcel.Location = new Point(21, 29);
			this.pb_SaveExcel.Name = "pb_SaveExcel";
			this.pb_SaveExcel.Size = new Size(32, 33);
			this.pb_SaveExcel.TabIndex = 0;
			this.pb_SaveExcel.TabStop = false;
			this.pb_SaveExcel.MouseDown += this.pb_SaveExcel_MouseDown;
			this.pb_SaveExcel.MouseUp += this.pb_SaveExcel_MouseUp;
			this.tabCtrl_Grid.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabCtrl_Grid.Controls.Add(this.tabPage1);
			this.tabCtrl_Grid.Controls.Add(this.tabPage2);
			this.tabCtrl_Grid.Controls.Add(this.tabPage3);
			this.tabCtrl_Grid.Location = new Point(6, 200);
			this.tabCtrl_Grid.Name = "tabCtrl_Grid";
			this.tabCtrl_Grid.SelectedIndex = 0;
			this.tabCtrl_Grid.Size = new Size(1116, 423);
			this.tabCtrl_Grid.TabIndex = 31;
			this.tabCtrl_Grid.SelectedIndexChanged += this.tabCtrl_Grid_SelectedIndexChanged;
			this.tabPage1.Controls.Add(this.grid_biboard_history_Curr);
			this.tabPage1.Location = new Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new Padding(3);
			this.tabPage1.Size = new Size(1108, 395);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Burn In Sorted From Newest";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.grid_biboard_history_Curr.BorderStyle = BorderStyle.FixedSingle;
			this.grid_biboard_history_Curr.ClipboardMode = ClipboardMode.Copy;
			this.grid_biboard_history_Curr.Dock = DockStyle.Fill;
			this.grid_biboard_history_Curr.EnableSort = true;
			this.grid_biboard_history_Curr.Font = new Font("Segoe UI", 9f);
			this.grid_biboard_history_Curr.Location = new Point(3, 3);
			this.grid_biboard_history_Curr.Margin = new Padding(3, 5, 3, 5);
			this.grid_biboard_history_Curr.Name = "grid_biboard_history_Curr";
			this.grid_biboard_history_Curr.OptimizeMode = CellOptimizeMode.ForRows;
			this.grid_biboard_history_Curr.SelectionMode = GridSelectionMode.Cell;
			this.grid_biboard_history_Curr.Size = new Size(1102, 389);
			this.grid_biboard_history_Curr.TabIndex = 16;
			this.grid_biboard_history_Curr.TabStop = true;
			this.grid_biboard_history_Curr.ToolTipText = "";
			this.grid_biboard_history_Curr.MouseClick += this.grid_biboard_history_Curr_MouseClick;
			this.grid_biboard_history_Curr.MouseDoubleClick += this.grid_biboard_history_Curr_MouseDoubleClick;
			this.grid_biboard_history_Curr.MouseDown += this.grid_biboard_history_Curr_MouseDown;
			this.tabPage2.Controls.Add(this.grid_biboard_history_Old);
			this.tabPage2.Location = new Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new Padding(3);
			this.tabPage2.Size = new Size(1108, 395);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Burn In Sorted From Oldest";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.grid_biboard_history_Old.BorderStyle = BorderStyle.FixedSingle;
			this.grid_biboard_history_Old.ClipboardMode = ClipboardMode.Copy;
			this.grid_biboard_history_Old.Dock = DockStyle.Fill;
			this.grid_biboard_history_Old.EnableSort = true;
			this.grid_biboard_history_Old.Font = new Font("Segoe UI", 9f);
			this.grid_biboard_history_Old.Location = new Point(3, 3);
			this.grid_biboard_history_Old.Margin = new Padding(3, 5, 3, 5);
			this.grid_biboard_history_Old.Name = "grid_biboard_history_Old";
			this.grid_biboard_history_Old.OptimizeMode = CellOptimizeMode.ForRows;
			this.grid_biboard_history_Old.SelectionMode = GridSelectionMode.Cell;
			this.grid_biboard_history_Old.Size = new Size(1102, 389);
			this.grid_biboard_history_Old.TabIndex = 17;
			this.grid_biboard_history_Old.TabStop = true;
			this.grid_biboard_history_Old.ToolTipText = "";
			this.grid_biboard_history_Old.MouseClick += this.grid_biboard_history_Old_MouseClick;
			this.grid_biboard_history_Old.MouseDoubleClick += this.grid_biboard_history_Old_MouseDoubleClick;
			this.tabPage3.Controls.Add(this.grid_WarrantyInfo);
			this.tabPage3.Location = new Point(4, 24);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new Padding(3);
			this.tabPage3.Size = new Size(1108, 395);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Warranty Info";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.grid_WarrantyInfo.BorderStyle = BorderStyle.FixedSingle;
			this.grid_WarrantyInfo.ClipboardMode = ClipboardMode.Copy;
			this.grid_WarrantyInfo.Dock = DockStyle.Fill;
			this.grid_WarrantyInfo.EnableSort = true;
			this.grid_WarrantyInfo.Font = new Font("Segoe UI", 9f);
			this.grid_WarrantyInfo.Location = new Point(3, 3);
			this.grid_WarrantyInfo.Margin = new Padding(3, 5, 3, 5);
			this.grid_WarrantyInfo.Name = "grid_WarrantyInfo";
			this.grid_WarrantyInfo.OptimizeMode = CellOptimizeMode.ForRows;
			this.grid_WarrantyInfo.SelectionMode = GridSelectionMode.Cell;
			this.grid_WarrantyInfo.Size = new Size(1102, 389);
			this.grid_WarrantyInfo.TabIndex = 18;
			this.grid_WarrantyInfo.TabStop = true;
			this.grid_WarrantyInfo.ToolTipText = "";
			this.grid_WarrantyInfo.MouseDown += this.grid_WarrantyInfo_MouseDown;
			this.groupBox1.Controls.Add(this.pb_SearchAll);
			this.groupBox1.Location = new Point(362, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(74, 81);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search All";
			this.pb_SearchAll.Cursor = Cursors.Hand;
			this.pb_SearchAll.Image = Resources.lothistory;
			this.pb_SearchAll.Location = new Point(21, 29);
			this.pb_SearchAll.Name = "pb_SearchAll";
			this.pb_SearchAll.Size = new Size(32, 33);
			this.pb_SearchAll.TabIndex = 0;
			this.pb_SearchAll.TabStop = false;
			this.pb_SearchAll.MouseUp += this.pb_SearchAll_MouseUp;
			this.groupBox3.Controls.Add(this.l_barcode);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.l_location);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.l_customer);
			this.groupBox3.Controls.Add(this.l_device);
			this.groupBox3.Controls.Add(this.l_bib_No);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox3.Location = new Point(6, 98);
			this.groupBox3.Margin = new Padding(3, 4, 3, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new Padding(3, 4, 3, 4);
			this.groupBox3.Size = new Size(818, 95);
			this.groupBox3.TabIndex = 29;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "BI Board Information";
			this.l_barcode.AutoSize = true;
			this.l_barcode.Location = new Point(695, 30);
			this.l_barcode.Name = "l_barcode";
			this.l_barcode.Size = new Size(79, 15);
			this.l_barcode.TabIndex = 10;
			this.l_barcode.Text = "ABBURN IN-7";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(591, 30);
			this.label7.Name = "label7";
			this.label7.Size = new Size(56, 15);
			this.label7.TabIndex = 9;
			this.label7.Text = "Barcode :";
			this.l_location.AutoSize = true;
			this.l_location.Location = new Point(395, 64);
			this.l_location.Name = "l_location";
			this.l_location.Size = new Size(64, 15);
			this.l_location.TabIndex = 8;
			this.l_location.Text = "BURN IN-7";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(291, 64);
			this.label6.Name = "label6";
			this.label6.Size = new Size(59, 15);
			this.label6.TabIndex = 7;
			this.label6.Text = "Location :";
			this.l_customer.AutoSize = true;
			this.l_customer.Location = new Point(395, 30);
			this.l_customer.Name = "l_customer";
			this.l_customer.Size = new Size(77, 15);
			this.l_customer.TabIndex = 6;
			this.l_customer.Text = "QUALCOMM";
			this.l_device.AutoSize = true;
			this.l_device.Location = new Point(127, 64);
			this.l_device.Name = "l_device";
			this.l_device.Size = new Size(85, 15);
			this.l_device.TabIndex = 5;
			this.l_device.Text = "RADAGAST AU";
			this.l_bib_No.AutoSize = true;
			this.l_bib_No.Location = new Point(127, 30);
			this.l_bib_No.Name = "l_bib_No";
			this.l_bib_No.Size = new Size(38, 15);
			this.l_bib_No.TabIndex = 4;
			this.l_bib_No.Text = "#1029";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(291, 30);
			this.label4.Name = "label4";
			this.label4.Size = new Size(68, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Customer : ";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(23, 64);
			this.label3.Name = "label3";
			this.label3.Size = new Size(51, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Device : ";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(23, 30);
			this.label1.Name = "label1";
			this.label1.Size = new Size(44, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "BIB ID :";
			this.groupBox2.Controls.Add(this.chkBox_SearchPM);
			this.groupBox2.Controls.Add(this.btn_Insert);
			this.groupBox2.Controls.Add(this.btn_search);
			this.groupBox2.Controls.Add(this.tb_biboardno);
			this.groupBox2.Font = new Font("Segoe UI", 9f);
			this.groupBox2.Location = new Point(6, 8);
			this.groupBox2.Margin = new Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new Padding(3, 5, 3, 5);
			this.groupBox2.Size = new Size(350, 81);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "BI Board No.";
			this.chkBox_SearchPM.AutoSize = true;
			this.chkBox_SearchPM.Location = new Point(22, 24);
			this.chkBox_SearchPM.Name = "chkBox_SearchPM";
			this.chkBox_SearchPM.Size = new Size(103, 19);
			this.chkBox_SearchPM.TabIndex = 16;
			this.chkBox_SearchPM.Text = "Search PM List";
			this.chkBox_SearchPM.UseVisualStyleBackColor = true;
			this.btn_Insert.FlatStyle = FlatStyle.Flat;
			this.btn_Insert.Location = new Point(254, 40);
			this.btn_Insert.Margin = new Padding(3, 5, 3, 5);
			this.btn_Insert.Name = "btn_Insert";
			this.btn_Insert.Size = new Size(75, 29);
			this.btn_Insert.TabIndex = 15;
			this.btn_Insert.Text = "Insert";
			this.btn_Insert.UseVisualStyleBackColor = true;
			this.btn_Insert.Click += this.btn_Insert_Click;
			this.btn_search.FlatStyle = FlatStyle.Flat;
			this.btn_search.Location = new Point(171, 40);
			this.btn_search.Margin = new Padding(3, 5, 3, 5);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new Size(75, 29);
			this.btn_search.TabIndex = 14;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = true;
			this.btn_search.Click += this.btn_search_Click;
			this.tb_biboardno.Location = new Point(22, 46);
			this.tb_biboardno.Margin = new Padding(3, 5, 3, 5);
			this.tb_biboardno.Name = "tb_biboardno";
			this.tb_biboardno.Size = new Size(143, 23);
			this.tb_biboardno.TabIndex = 12;
			this.tb_biboardno.KeyPress += this.tb_biboardno_KeyPress;
			this.radioBtn_Under.AutoSize = true;
			this.radioBtn_Under.Location = new Point(990, 199);
			this.radioBtn_Under.Name = "radioBtn_Under";
			this.radioBtn_Under.Size = new Size(57, 19);
			this.radioBtn_Under.TabIndex = 33;
			this.radioBtn_Under.TabStop = true;
			this.radioBtn_Under.Text = "Under";
			this.radioBtn_Under.UseVisualStyleBackColor = true;
			this.radioBtn_Under.CheckedChanged += this.radioBtn_Under_CheckedChanged;
			this.radioBtn_OutOf.AutoSize = true;
			this.radioBtn_OutOf.Location = new Point(1053, 199);
			this.radioBtn_OutOf.Name = "radioBtn_OutOf";
			this.radioBtn_OutOf.Size = new Size(61, 19);
			this.radioBtn_OutOf.TabIndex = 34;
			this.radioBtn_OutOf.TabStop = true;
			this.radioBtn_OutOf.Text = "Out Of";
			this.radioBtn_OutOf.UseVisualStyleBackColor = true;
			this.groupBox5.Controls.Add(this.pb_PartChange);
			this.groupBox5.Location = new Point(522, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(74, 81);
			this.groupBox5.TabIndex = 35;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "P Change";
			this.pb_PartChange.Cursor = Cursors.Hand;
			this.pb_PartChange.Image = Resources.VOS;
			this.pb_PartChange.InitialImage = Resources.VOS;
			this.pb_PartChange.Location = new Point(21, 29);
			this.pb_PartChange.Name = "pb_PartChange";
			this.pb_PartChange.Size = new Size(32, 33);
			this.pb_PartChange.TabIndex = 0;
			this.pb_PartChange.TabStop = false;
			this.pb_PartChange.MouseUp += this.pb_PartChange_MouseUp;
			base.Name = "Tab_PM";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			((ISupportInitialize)this.pb_SaveExcel).EndInit();
			this.tabCtrl_Grid.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.pb_SearchAll).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((ISupportInitialize)this.pb_PartChange).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000254 RID: 596
		public BarPrograss _barPrograss;

		// Token: 0x04000255 RID: 597
		public Thread _thread;

		// Token: 0x04000256 RID: 598
		private List<CBIBoardInfo> _biBoardInfos;

		// Token: 0x04000257 RID: 599
		public CGridIndex_BoardInfo _gridIdx_BIBoard;

		// Token: 0x04000258 RID: 600
		public CGridIndex_BoardInfo_Warranty _gridIdx_BIBoard_Warranty;

		// Token: 0x04000259 RID: 601
		public BIBoardInfoModule _instance;

		// Token: 0x0400025A RID: 602
		private ContextMenuStrip _cntxtMenu_Del_Pm = new ContextMenuStrip();

		// Token: 0x0400025B RID: 603
		private ContextMenuStrip _cntxtMenu_Warranty = new ContextMenuStrip();

		// Token: 0x0400025C RID: 604
		private IContainer components;

		// Token: 0x0400025D RID: 605
		private GroupBox groupBox4;

		// Token: 0x0400025E RID: 606
		private PictureBox pb_SaveExcel;

		// Token: 0x0400025F RID: 607
		private TabControl tabCtrl_Grid;

		// Token: 0x04000260 RID: 608
		private TabPage tabPage1;

		// Token: 0x04000261 RID: 609
		private Grid grid_biboard_history_Curr;

		// Token: 0x04000262 RID: 610
		private TabPage tabPage2;

		// Token: 0x04000263 RID: 611
		private Grid grid_biboard_history_Old;

		// Token: 0x04000264 RID: 612
		private GroupBox groupBox1;

		// Token: 0x04000265 RID: 613
		private PictureBox pb_SearchAll;

		// Token: 0x04000266 RID: 614
		private GroupBox groupBox3;

		// Token: 0x04000267 RID: 615
		private Label l_barcode;

		// Token: 0x04000268 RID: 616
		private Label label7;

		// Token: 0x04000269 RID: 617
		private Label l_location;

		// Token: 0x0400026A RID: 618
		private Label label6;

		// Token: 0x0400026B RID: 619
		private Label l_customer;

		// Token: 0x0400026C RID: 620
		private Label l_device;

		// Token: 0x0400026D RID: 621
		private Label l_bib_No;

		// Token: 0x0400026E RID: 622
		private Label label4;

		// Token: 0x0400026F RID: 623
		private Label label3;

		// Token: 0x04000270 RID: 624
		private Label label1;

		// Token: 0x04000271 RID: 625
		private GroupBox groupBox2;

		// Token: 0x04000272 RID: 626
		private System.Windows.Forms.CheckBox chkBox_SearchPM;

		// Token: 0x04000273 RID: 627
		private System.Windows.Forms.Button btn_Insert;

		// Token: 0x04000274 RID: 628
		private System.Windows.Forms.Button btn_search;

		// Token: 0x04000275 RID: 629
		private TextBox tb_biboardno;

		// Token: 0x04000276 RID: 630
		private TabPage tabPage3;

		// Token: 0x04000277 RID: 631
		private Grid grid_WarrantyInfo;

		// Token: 0x04000278 RID: 632
		private RadioButton radioBtn_OutOf;

		// Token: 0x04000279 RID: 633
		private RadioButton radioBtn_Under;

		// Token: 0x0400027A RID: 634
		private GroupBox groupBox5;

		// Token: 0x0400027B RID: 635
		private PictureBox pb_PartChange;
	}
}
