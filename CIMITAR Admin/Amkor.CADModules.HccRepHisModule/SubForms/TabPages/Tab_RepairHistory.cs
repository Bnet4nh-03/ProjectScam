using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AlteraSocketView.View;
using Amkor.CADModules.HccRepHisModule.Properties;
using CommonLibrary;
using DATA;
using SourceGrid;
using SourceGrid.Cells;

namespace Amkor.CADModules.HccRepHisModule.SubForms.TabPages
{
	// Token: 0x0200000C RID: 12
	public class Tab_RepairHistory : Tab_Base
	{
		// Token: 0x06000056 RID: 86 RVA: 0x000061FC File Offset: 0x000043FC
		public Tab_RepairHistory(string title)
		{
			this.Text = title;
			this.InitializeComponent();
			this._instance = HccRepHisModule._instance;
			this._gridIdx = new CGridIndex_CRepairHistoryItem();
			this._cParsingGrid = new CParsingGrid();
			this._cRepairHistoryItems = new List<CRepairHistoryItem>();
			this._cCusts = new List<CCust>();
			this._cPdts = new List<CPdt>();
			this.InitCombos(1, "");
			this.InitContextBox();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000627C File Offset: 0x0000447C
		private void ResetGrid(Grid grid)
		{
			for (int i = grid.RowsCount - 1; i >= 0; i--)
			{
				grid.Rows.Remove(i);
			}
			grid.Selection.EnableMultiSelection = false;
			grid.BorderStyle = BorderStyle.FixedSingle;
			grid.SelectionMode = GridSelectionMode.Row;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000062C4 File Offset: 0x000044C4
		private void SetHeaderInfo(string[] gridHeaders, Grid grid)
		{
			grid.ColumnsCount = gridHeaders.Length + 1;
			grid.FixedRows = 0;
			grid.FixedColumns = 0;
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

		// Token: 0x06000059 RID: 89 RVA: 0x00006368 File Offset: 0x00004568
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

		// Token: 0x0600005A RID: 90 RVA: 0x00006404 File Offset: 0x00004604
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

		// Token: 0x0600005B RID: 91 RVA: 0x00006488 File Offset: 0x00004688
		private void SetGridInfo(List<CRepairHistoryItem> cRepairHistoryItems)
		{
			this.ResetGrid(this.grid_RepairHistory);
			if (cRepairHistoryItems.Count == 0)
			{
				return;
			}
			List<CRepairHistoryItem> list = (from o in cRepairHistoryItems
			orderby o.dtInDate descending
			select o).ToList<CRepairHistoryItem>();
			this._barPrograss = new BarPrograss();
			this._barPrograss.progress_labelheader_set("Drawing..");
			this._barPrograss.setMax(list.Count);
			this._barPrograss.setValue(0);
			this._thread = new Thread(new ThreadStart(this.BarPrograssView));
			this._thread.Start();
			int num = 1;
			string[] headers = this._gridIdx.headers;
			this.SetHeaderInfo(headers, this.grid_RepairHistory);
			DateTime.Now.AddDays(-24.0);
			try
			{
				if (list.Count != 0)
				{
					foreach (CRepairHistoryItem crepairHistoryItem in list)
					{
						this.grid_RepairHistory.Rows.Insert(num);
						this.grid_RepairHistory[num, 0] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
						this.grid_RepairHistory[num, this._gridIdx.iIdxNo] = new Cell(num);
						this.grid_RepairHistory[num, this._gridIdx.iIdxId] = new Cell(crepairHistoryItem.iId);
						this.grid_RepairHistory[num, this._gridIdx.iIdxCustName] = new Cell(crepairHistoryItem.strCustName);
						this.grid_RepairHistory[num, this._gridIdx.iIdxBoard] = new Cell(crepairHistoryItem.strBoard);
						this.grid_RepairHistory[num, this._gridIdx.iIdxBarcode] = new Cell(crepairHistoryItem.strBarcode);
						this.grid_RepairHistory[num, this._gridIdx.iIdxSerialNo] = new Cell(crepairHistoryItem.strSerialNo);
						this.grid_RepairHistory[num, this._gridIdx.iIdxNumOfSites] = new Cell(crepairHistoryItem.iNumOfSites);
						if (crepairHistoryItem.iDefectedSite == 0)
						{
							this.grid_RepairHistory[num, this._gridIdx.iIdxDefectedSite] = new Cell("");
						}
						else
						{
							this.grid_RepairHistory[num, this._gridIdx.iIdxDefectedSite] = new Cell(crepairHistoryItem.iDefectedSite);
						}
						this.grid_RepairHistory[num, this._gridIdx.iIdxProbDesc] = new Cell(crepairHistoryItem.strProbDesc);
						this.grid_RepairHistory[num, this._gridIdx.iIdxAction] = new Cell(crepairHistoryItem.strAction);
						this.grid_RepairHistory[num, this._gridIdx.iIdxDate_Indate] = new Cell(crepairHistoryItem.dtInDate.ToString("yyyy-MM-dd HH:mm:ss"));
						this.grid_RepairHistory[num, this._gridIdx.iIdxDate_Update] = new Cell(crepairHistoryItem.dtUpdateDate.ToString("yyyy-MM-dd HH:mm:ss"));
						for (int i = 0; i < this._gridIdx.headers.Length + 1; i++)
						{
							if (num % 2 == 0)
							{
								if (i == 0)
								{
									this.grid_RepairHistory[num, i].View = this._instance._checkBox_Normal1;
								}
								else
								{
									this.grid_RepairHistory[num, i].View = this._instance._cell_center1;
								}
							}
							else if (i == 0)
							{
								this.grid_RepairHistory[num, i].View = this._instance._checkBox_Normal2;
							}
							else
							{
								this.grid_RepairHistory[num, i].View = this._instance._cell_center2;
							}
						}
						num++;
						this._barPrograss.progress_increase();
					}
					this.SetColWidth(1, this.grid_RepairHistory);
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

		// Token: 0x0600005C RID: 92 RVA: 0x0000690C File Offset: 0x00004B0C
		private void SetColWidth(int typeNo, Grid grid)
		{
			if (typeNo == 1)
			{
				grid.Columns[0].Width = 10;
				grid.Columns[this._gridIdx.iIdxNo].Width = 35;
				grid.Columns[this._gridIdx.iIdxId].Width = 45;
				grid.Columns[this._gridIdx.iIdxCustName].Width = 100;
				grid.Columns[this._gridIdx.iIdxBoard].Width = 100;
				grid.Columns[this._gridIdx.iIdxBarcode].Width = 110;
				grid.Columns[this._gridIdx.iIdxSerialNo].Width = 60;
				grid.Columns[this._gridIdx.iIdxNumOfSites].Width = 100;
				grid.Columns[this._gridIdx.iIdxDefectedSite].Width = 100;
				grid.Columns[this._gridIdx.iIdxProbDesc].Width = 200;
				grid.Columns[this._gridIdx.iIdxAction].Width = 250;
				grid.Columns[this._gridIdx.iIdxDate_Indate].Width = 130;
				grid.Columns[this._gridIdx.iIdxDate_Update].Width = 130;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00006A9C File Offset: 0x00004C9C
		public void InitCombos(int typeNo, string desc)
		{
			if (typeNo != 1)
			{
				if (typeNo != 2)
				{
					return;
				}
				this._cPdts = this._instance.GetData_Pdt(desc);
				if (this._cPdts.Count != 0)
				{
					string[] array = (from o in this._cPdts
					select o.strProduct).ToArray<string>();
					this.combo_Board.Items.Clear();
					ComboBox.ObjectCollection items = this.combo_Board.Items;
					object[] items2 = array;
					items.AddRange(items2);
				}
			}
			else
			{
				this._cCusts = this._instance.GetData_Cust();
				if (this._cCusts.Count != 0)
				{
					string[] array2 = (from o in this._cCusts
					select o.strDesc).ToArray<string>();
					this.combo_Customer.Items.Clear();
					ComboBox.ObjectCollection items3 = this.combo_Customer.Items;
					object[] items2 = array2;
					items3.AddRange(items2);
					return;
				}
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00006B9C File Offset: 0x00004D9C
		private void InitContextBox()
		{
			this._cntxtMenu_Delete.Items.Clear();
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Delete");
			toolStripMenuItem.Image = Resources.TableRemove;
			toolStripMenuItem.Click += this._cntxtMenu_Delete_Click;
			this._cntxtMenu_Delete.Items.Add(toolStripMenuItem);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00006BF4 File Offset: 0x00004DF4
		private void Event_Search(string type)
		{
			this.ResetGrid(this.grid_RepairHistory);
			string text = (this.combo_Customer.SelectedItem != null) ? this.combo_Customer.SelectedItem.ToString() : "";
			string custInfo = this._instance.GetCustInfo(1, text, this._cCusts);
			string text2 = (this.combo_Board.SelectedItem != null) ? this.combo_Board.SelectedItem.ToString() : "";
			string text3 = this.tb_SN.Text.Trim();
			if (text3 != "" && text3.Substring(0, 1) != "#")
			{
				text3 = "#" + text3;
				this.tb_SN.Text = text3;
			}
			string from = this.dtPicker_From.Value.ToString("yyyy-MM-dd");
			string to = this.dtPicker_To.Value.ToString("yyyy-MM-dd");
			if (!(type == "ALL"))
			{
				if (!(type == "COND"))
				{
					return;
				}
				if (text == "" || text2 == "" || text3 == "")
				{
					MessageBox.Show("Set conditions");
					return;
				}
				this._cRepairHistoryItems = this._instance.GetData_History(custInfo, text2, text3, from, to);
				if (this._cRepairHistoryItems.Count > 0)
				{
					this.SetGridInfo(this._cRepairHistoryItems);
				}
			}
			else
			{
				this._cRepairHistoryItems = this._instance.GetData_History(custInfo, text2, text3, from, to);
				if (this._cRepairHistoryItems.Count > 0)
				{
					this.SetGridInfo(this._cRepairHistoryItems);
					return;
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006DA0 File Offset: 0x00004FA0
		private void _cntxtMenu_Delete_Click(object sender, EventArgs e)
		{
			List<int> list = new List<int>();
			for (int i = 1; i < this.grid_RepairHistory.Rows.Count; i++)
			{
				bool? @checked = ((SourceGrid.Cells.CheckBox)this.grid_RepairHistory[i, 0]).Checked;
				bool flag = true;
				if (@checked.GetValueOrDefault() == flag & @checked != null)
				{
					int item = int.Parse(this.grid_RepairHistory[i, this._gridIdx.iIdxId].Value.ToString());
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
				foreach (int id in list)
				{
					if (this.DeleteRepHistory(id, badgeNo, comment) == 1)
					{
						MessageBox.Show("Fail to Delete");
						break;
					}
				}
				this.Event_Search("ALL");
				return;
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00006EF0 File Offset: 0x000050F0
		private int DeleteRepHistory(int id, string badgeNo, string comment)
		{
			return this._instance.DeleteRepHistory(id, badgeNo, comment);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00006F00 File Offset: 0x00005100
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00006F10 File Offset: 0x00005110
		private void combo_Customer_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.combo_Customer.SelectedItem != null)
			{
				string b = this.combo_Customer.SelectedItem.ToString();
				CCust ccust = null;
				foreach (CCust ccust2 in this._cCusts)
				{
					if (ccust2.strDesc == b)
					{
						ccust = ccust2;
						break;
					}
				}
				this.InitCombos(2, ccust.strCustCode);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00006F9C File Offset: 0x0000519C
		private void pb_Search_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Search.Image = Resources.TableSearch_Down;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00006FAE File Offset: 0x000051AE
		private void pb_Search_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Search.Image = Resources.TableSearch;
			this.Event_Search("COND");
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00006FCB File Offset: 0x000051CB
		private void pb_SearchAll_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_SearchAll.Image = Resources.TableSearch_Down;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00006FDD File Offset: 0x000051DD
		private void pb_SearchAll_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_SearchAll.Image = Resources.TableSearch;
			this.Event_Search("ALL");
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00006FFA File Offset: 0x000051FA
		private void pb_Insert_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Insert.Image = Resources.TableSave_Down;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000700C File Offset: 0x0000520C
		private void pb_Insert_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Insert.Image = Resources.TableSave;
			new InsertHistory(this._cCusts).ShowDialog();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000702F File Offset: 0x0000522F
		private void dtPicker_From_ValueChanged(object sender, EventArgs e)
		{
			if (this.dtPicker_From.Value > this.dtPicker_To.Value)
			{
				this.dtPicker_From.Value = this.dtPicker_To.Value;
				return;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00007065 File Offset: 0x00005265
		private void dtPicker_To_ValueChanged(object sender, EventArgs e)
		{
			if (this.dtPicker_To.Value > DateTime.Now)
			{
				this.dtPicker_To.Value = DateTime.Now;
				return;
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00007090 File Offset: 0x00005290
		private void grid_RepairHistory_DoubleClick(object sender, EventArgs e)
		{
			if (this.grid_RepairHistory.Selection.ActivePosition.Row < 0)
			{
				return;
			}
			if (this.grid_RepairHistory.Selection.ActivePosition.Column < 2)
			{
				return;
			}
			int row = this.grid_RepairHistory.Selection.ActivePosition.Row;
			int num = int.Parse(this.grid_RepairHistory[row, 2].ToString());
			CRepairHistoryItem cRepairHistoryItem = null;
			foreach (CRepairHistoryItem crepairHistoryItem in this._cRepairHistoryItems)
			{
				if (num == crepairHistoryItem.iId)
				{
					cRepairHistoryItem = crepairHistoryItem;
					break;
				}
			}
			new InsertHistory(this._cCusts, cRepairHistoryItem).ShowDialog();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000716C File Offset: 0x0000536C
		private void grid_RepairHistory_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			this._cntxtMenu_Delete.Show(this.grid_RepairHistory, new Point(e.X, e.Y));
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000719E File Offset: 0x0000539E
		private void pb_SaveExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_SaveExcel.Image = Resources.SaveExcel_Down;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000071B0 File Offset: 0x000053B0
		private void pb_SaveExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_SaveExcel.Image = Resources.SaveExcel;
			if (this._cRepairHistoryItems.Count == 0)
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
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				filename = saveFileDialog.FileName;
				DataTable dt = this._cParsingGrid.ParseGrid(this.grid_RepairHistory);
				new CSVControl().generateCSV(filename, dt);
				MessageBox.Show("Success to Save CSV");
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00007257 File Offset: 0x00005457
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00007278 File Offset: 0x00005478
		private void InitializeComponent()
		{
			this.groupBox4 = new GroupBox();
			this.pb_SaveExcel = new PictureBox();
			this.groupBox1 = new GroupBox();
			this.pb_Search = new PictureBox();
			this.groupBox2 = new GroupBox();
			this.tb_SN = new TextBox();
			this.label6 = new Label();
			this.label5 = new Label();
			this.combo_Customer = new ComboBox();
			this.combo_Board = new ComboBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.dtPicker_From = new DateTimePicker();
			this.dtPicker_To = new DateTimePicker();
			this.label2 = new Label();
			this.label1 = new Label();
			this.groupBox5 = new GroupBox();
			this.panel2 = new Panel();
			this.grid_RepairHistory = new Grid();
			this.groupBox3 = new GroupBox();
			this.pb_Insert = new PictureBox();
			this.groupBox6 = new GroupBox();
			this.pb_SearchAll = new PictureBox();
			this.panel1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((ISupportInitialize)this.pb_SaveExcel).BeginInit();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.pb_Search).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((ISupportInitialize)this.pb_Insert).BeginInit();
			this.groupBox6.SuspendLayout();
			((ISupportInitialize)this.pb_SearchAll).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox6);
			this.panel1.Controls.Add(this.groupBox5);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.groupBox2);
			this.groupBox4.Controls.Add(this.pb_SaveExcel);
			this.groupBox4.Location = new Point(1048, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(74, 81);
			this.groupBox4.TabIndex = 39;
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
			this.groupBox1.Controls.Add(this.pb_Search);
			this.groupBox1.Location = new Point(681, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(74, 81);
			this.groupBox1.TabIndex = 38;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.pb_Search.Cursor = Cursors.Hand;
			this.pb_Search.Image = Resources.TableSearch;
			this.pb_Search.InitialImage = Resources.TableSearch;
			this.pb_Search.Location = new Point(21, 29);
			this.pb_Search.Name = "pb_Search";
			this.pb_Search.Size = new Size(32, 33);
			this.pb_Search.TabIndex = 0;
			this.pb_Search.TabStop = false;
			this.pb_Search.MouseDown += this.pb_Search_MouseDown;
			this.pb_Search.MouseUp += this.pb_Search_MouseUp;
			this.groupBox2.Controls.Add(this.tb_SN);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.combo_Customer);
			this.groupBox2.Controls.Add(this.combo_Board);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.dtPicker_From);
			this.groupBox2.Controls.Add(this.dtPicker_To);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Font = new Font("Segoe UI", 9f);
			this.groupBox2.Location = new Point(6, 8);
			this.groupBox2.Margin = new Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new Padding(3, 5, 3, 5);
			this.groupBox2.Size = new Size(669, 81);
			this.groupBox2.TabIndex = 37;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Search Condition";
			this.tb_SN.CharacterCasing = CharacterCasing.Upper;
			this.tb_SN.Location = new Point(317, 43);
			this.tb_SN.Name = "tb_SN";
			this.tb_SN.Size = new Size(91, 23);
			this.tb_SN.TabIndex = 49;
			this.label6.AutoSize = true;
			this.label6.Location = new Point(314, 23);
			this.label6.Name = "label6";
			this.label6.Size = new Size(33, 15);
			this.label6.TabIndex = 48;
			this.label6.Text = "S/N :";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(165, 23);
			this.label5.Name = "label5";
			this.label5.Size = new Size(44, 15);
			this.label5.TabIndex = 46;
			this.label5.Text = "Board :";
			this.combo_Customer.DropDownStyle = ComboBoxStyle.DropDownList;
			this.combo_Customer.FlatStyle = FlatStyle.Flat;
			this.combo_Customer.FormattingEnabled = true;
			this.combo_Customer.Location = new Point(19, 43);
			this.combo_Customer.Name = "combo_Customer";
			this.combo_Customer.Size = new Size(143, 23);
			this.combo_Customer.TabIndex = 45;
			this.combo_Customer.SelectionChangeCommitted += this.combo_Customer_SelectionChangeCommitted;
			this.combo_Board.DropDownStyle = ComboBoxStyle.DropDownList;
			this.combo_Board.FlatStyle = FlatStyle.Flat;
			this.combo_Board.FormattingEnabled = true;
			this.combo_Board.Location = new Point(168, 43);
			this.combo_Board.Name = "combo_Board";
			this.combo_Board.Size = new Size(143, 23);
			this.combo_Board.TabIndex = 44;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(541, 23);
			this.label4.Name = "label4";
			this.label4.Size = new Size(26, 15);
			this.label4.TabIndex = 43;
			this.label4.Text = "To :";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(523, 46);
			this.label3.Name = "label3";
			this.label3.Size = new Size(15, 15);
			this.label3.TabIndex = 18;
			this.label3.Text = "~";
			this.dtPicker_From.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_From.Format = DateTimePickerFormat.Custom;
			this.dtPicker_From.Location = new Point(414, 43);
			this.dtPicker_From.Name = "dtPicker_From";
			this.dtPicker_From.Size = new Size(103, 23);
			this.dtPicker_From.TabIndex = 17;
			this.dtPicker_From.ValueChanged += this.dtPicker_From_ValueChanged;
			this.dtPicker_To.CustomFormat = "yyyy-MM-dd";
			this.dtPicker_To.Format = DateTimePickerFormat.Custom;
			this.dtPicker_To.Location = new Point(544, 43);
			this.dtPicker_To.Name = "dtPicker_To";
			this.dtPicker_To.Size = new Size(103, 23);
			this.dtPicker_To.TabIndex = 16;
			this.dtPicker_To.ValueChanged += this.dtPicker_To_ValueChanged;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(16, 23);
			this.label2.Name = "label2";
			this.label2.Size = new Size(65, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Customer :";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(411, 23);
			this.label1.Name = "label1";
			this.label1.Size = new Size(41, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "From :";
			this.groupBox5.Controls.Add(this.panel2);
			this.groupBox5.Location = new Point(6, 95);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(1116, 528);
			this.groupBox5.TabIndex = 42;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Repair History Info";
			this.panel2.Controls.Add(this.grid_RepairHistory);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(3, 19);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new Padding(3);
			this.panel2.Size = new Size(1110, 506);
			this.panel2.TabIndex = 0;
			this.grid_RepairHistory.BorderStyle = BorderStyle.FixedSingle;
			this.grid_RepairHistory.Dock = DockStyle.Fill;
			this.grid_RepairHistory.EnableSort = true;
			this.grid_RepairHistory.Font = new Font("Segoe UI", 9f);
			this.grid_RepairHistory.Location = new Point(3, 3);
			this.grid_RepairHistory.Margin = new Padding(3, 5, 3, 5);
			this.grid_RepairHistory.Name = "grid_RepairHistory";
			this.grid_RepairHistory.OptimizeMode = CellOptimizeMode.ForRows;
			this.grid_RepairHistory.SelectionMode = GridSelectionMode.Cell;
			this.grid_RepairHistory.Size = new Size(1104, 500);
			this.grid_RepairHistory.TabIndex = 40;
			this.grid_RepairHistory.TabStop = true;
			this.grid_RepairHistory.ToolTipText = "";
			this.grid_RepairHistory.DoubleClick += this.grid_RepairHistory_DoubleClick;
			this.grid_RepairHistory.MouseDown += this.grid_RepairHistory_MouseDown;
			this.groupBox3.Controls.Add(this.pb_Insert);
			this.groupBox3.Location = new Point(968, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(74, 81);
			this.groupBox3.TabIndex = 40;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Insert";
			this.pb_Insert.Cursor = Cursors.Hand;
			this.pb_Insert.Image = Resources.TableSave;
			this.pb_Insert.InitialImage = Resources.TableSave;
			this.pb_Insert.Location = new Point(21, 29);
			this.pb_Insert.Name = "pb_Insert";
			this.pb_Insert.Size = new Size(32, 33);
			this.pb_Insert.TabIndex = 0;
			this.pb_Insert.TabStop = false;
			this.pb_Insert.MouseDown += this.pb_Insert_MouseDown;
			this.pb_Insert.MouseUp += this.pb_Insert_MouseUp;
			this.groupBox6.Controls.Add(this.pb_SearchAll);
			this.groupBox6.Location = new Point(761, 8);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new Size(74, 81);
			this.groupBox6.TabIndex = 43;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "SearchAll";
			this.pb_SearchAll.Cursor = Cursors.Hand;
			this.pb_SearchAll.Image = Resources.TableSearch;
			this.pb_SearchAll.InitialImage = Resources.TableSearch;
			this.pb_SearchAll.Location = new Point(21, 29);
			this.pb_SearchAll.Name = "pb_SearchAll";
			this.pb_SearchAll.Size = new Size(32, 33);
			this.pb_SearchAll.TabIndex = 0;
			this.pb_SearchAll.TabStop = false;
			this.pb_SearchAll.MouseDown += this.pb_SearchAll_MouseDown;
			this.pb_SearchAll.MouseUp += this.pb_SearchAll_MouseUp;
			base.Name = "Tab_RepairHistory";
			this.panel1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((ISupportInitialize)this.pb_SaveExcel).EndInit();
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.pb_Search).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((ISupportInitialize)this.pb_Insert).EndInit();
			this.groupBox6.ResumeLayout(false);
			((ISupportInitialize)this.pb_SearchAll).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000055 RID: 85
		public HccRepHisModule _instance;

		// Token: 0x04000056 RID: 86
		public BarPrograss _barPrograss;

		// Token: 0x04000057 RID: 87
		public Thread _thread;

		// Token: 0x04000058 RID: 88
		public CGridIndex_CRepairHistoryItem _gridIdx;

		// Token: 0x04000059 RID: 89
		private List<CRepairHistoryItem> _cRepairHistoryItems;

		// Token: 0x0400005A RID: 90
		private List<CCust> _cCusts;

		// Token: 0x0400005B RID: 91
		private List<CPdt> _cPdts;

		// Token: 0x0400005C RID: 92
		private CParsingGrid _cParsingGrid;

		// Token: 0x0400005D RID: 93
		private ContextMenuStrip _cntxtMenu_Delete = new ContextMenuStrip();

		// Token: 0x0400005E RID: 94
		private IContainer components;

		// Token: 0x0400005F RID: 95
		private GroupBox groupBox4;

		// Token: 0x04000060 RID: 96
		private PictureBox pb_SaveExcel;

		// Token: 0x04000061 RID: 97
		private GroupBox groupBox1;

		// Token: 0x04000062 RID: 98
		private PictureBox pb_Search;

		// Token: 0x04000063 RID: 99
		private GroupBox groupBox2;

		// Token: 0x04000064 RID: 100
		private GroupBox groupBox5;

		// Token: 0x04000065 RID: 101
		private Panel panel2;

		// Token: 0x04000066 RID: 102
		private Grid grid_RepairHistory;

		// Token: 0x04000067 RID: 103
		private GroupBox groupBox3;

		// Token: 0x04000068 RID: 104
		private PictureBox pb_Insert;

		// Token: 0x04000069 RID: 105
		private Label label5;

		// Token: 0x0400006A RID: 106
		private ComboBox combo_Customer;

		// Token: 0x0400006B RID: 107
		private ComboBox combo_Board;

		// Token: 0x0400006C RID: 108
		private Label label4;

		// Token: 0x0400006D RID: 109
		private Label label3;

		// Token: 0x0400006E RID: 110
		private DateTimePicker dtPicker_From;

		// Token: 0x0400006F RID: 111
		private DateTimePicker dtPicker_To;

		// Token: 0x04000070 RID: 112
		private Label label2;

		// Token: 0x04000071 RID: 113
		private Label label1;

		// Token: 0x04000072 RID: 114
		private TextBox tb_SN;

		// Token: 0x04000073 RID: 115
		private Label label6;

		// Token: 0x04000074 RID: 116
		private GroupBox groupBox6;

		// Token: 0x04000075 RID: 117
		private PictureBox pb_SearchAll;
	}
}
