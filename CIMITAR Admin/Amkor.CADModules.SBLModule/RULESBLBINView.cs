using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000016 RID: 22
	public partial class RULESBLBINView : Form
	{
		// Token: 0x0600006E RID: 110 RVA: 0x000065F8 File Offset: 0x000047F8
		public RULESBLBINView(RULESBLManager rulemanager, RefInfo refinfo)
		{
			this.InitializeComponent();
			this._refINFO = refinfo;
			this._rulemanager = rulemanager;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00006622 File Offset: 0x00004822
		public RULESBLBINView(RULESBLManager rulemanager, RefInfo refinfo, SortedList sl_SBLS)
		{
			this.InitializeComponent();
			this._sl_SBLS = sl_SBLS;
			this._refINFO = refinfo;
			this._rulemanager = rulemanager;
			this.initSetup();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000665C File Offset: 0x0000485C
		private void initSetup()
		{
			this.comboBox_OPT.Items.Add("0");
			if (this._refINFO.al_Operation.Count > 0)
			{
				foreach (object obj in this._refINFO.al_Operation)
				{
					refOPT refOPT = (refOPT)obj;
					this.comboBox_OPT.Items.Add(refOPT.operationName);
				}
			}
			this.comboBox_OPT.SelectedIndex = 0;
			if (this._refINFO.al_StatusID.Count > 0)
			{
				SortedList sortedList = new SortedList();
				this.comboBox_statusid.Tag = sortedList;
				foreach (object obj2 in this._refINFO.al_StatusID)
				{
					refStatusID refStatusID = (refStatusID)obj2;
					string text = refStatusID.StatusID + "(" + refStatusID.Status + ")";
					this.comboBox_statusid.Items.Add(text);
					sortedList.Add(text, refStatusID);
				}
				this.comboBox_statusid.SelectedIndex = 0;
			}
			if (this._sl_SBLS != null)
			{
				this.SetGrid(this._sl_SBLS);
				if (this._sl_SBLS.Count > 0)
				{
					this._selectedSBLITEM = (SBLItem)this._sl_SBLS.GetByIndex(0);
					this.changeinfo(this._selectedSBLITEM);
				}
			}
			this.textBox_basecount.Text = "-1";
			this.textBox_basepercent.Text = "-1";
			this.textBox_basesitecount.Text = "-1";
			this.textBox_statusid.Text = (string)this.comboBox_statusid.SelectedItem;
			SortedList sortedList2 = (SortedList)this.comboBox_statusid.Tag;
			this.textBox_statusid.Tag = ((refStatusID)sortedList2[this.comboBox_statusid.SelectedItem]).StatusID;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00006888 File Offset: 0x00004A88
		private void ResetGrid()
		{
			this.grid_sbls.Rows.Clear();
			this.grid_sbls.Selection.EnableMultiSelection = false;
			this.grid_sbls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_sbls.CustomSort = true;
			this.grid_sbls.Rows.Clear();
			this.grid_sbls.Selection.EnableMultiSelection = false;
			this.grid_sbls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_sbls.CustomSort = true;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00006908 File Offset: 0x00004B08
		private void SetGrid(SortedList sbls)
		{
			this.ResetGrid();
			SourceGrid.Cells.Views.Cell cell = new SourceGrid.Cells.Views.Cell();
			cell.BackColor = Color.FromArgb(130, 179, 237);
			cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			SourceGrid.Cells.Views.Cell cell2 = new SourceGrid.Cells.Views.Cell();
			cell2.BackColor = Color.FromArgb(255, 192, 203);
			this.grid_sbls.ColumnsCount = 19;
			this.grid_sbls.FixedRows = 2;
			this.grid_sbls.Rows.Insert(0);
			this.grid_sbls.Rows.Insert(1);
			this.grid_sbls[0, 0] = new SourceGrid.Cells.ColumnHeader("#");
			this.grid_sbls[0, 0].View = cell;
			this.grid_sbls[0, 0].RowSpan = 2;
			this.grid_sbls[0, 1] = new SourceGrid.Cells.ColumnHeader("BinNo");
			this.grid_sbls[0, 1].View = cell;
			this.grid_sbls[0, 1].RowSpan = 2;
			this.grid_sbls[0, 2] = new SourceGrid.Cells.ColumnHeader("Stop Limit");
			this.grid_sbls[0, 2].View = cell;
			this.grid_sbls[0, 2].ColumnSpan = 5;
			this.grid_sbls[1, 2] = new SourceGrid.Cells.ColumnHeader("% Limit");
			this.grid_sbls[1, 2].View = cell;
			this.grid_sbls[1, 3] = new SourceGrid.Cells.ColumnHeader("Count Limit");
			this.grid_sbls[1, 3].View = cell;
			this.grid_sbls[1, 4] = new SourceGrid.Cells.ColumnHeader("Site Limit");
			this.grid_sbls[1, 4].View = cell;
			this.grid_sbls[1, 5] = new SourceGrid.Cells.ColumnHeader("CN Limit");
			this.grid_sbls[1, 5].View = cell;
			this.grid_sbls[1, 6] = new SourceGrid.Cells.ColumnHeader("BIN Site Limit");
			this.grid_sbls[1, 6].View = cell;
			this.grid_sbls[0, 7] = new SourceGrid.Cells.ColumnHeader("Alarm Limit");
			this.grid_sbls[0, 7].View = cell;
			this.grid_sbls[0, 7].ColumnSpan = 5;
			this.grid_sbls[1, 7] = new SourceGrid.Cells.ColumnHeader("% Limit");
			this.grid_sbls[1, 7].View = cell;
			this.grid_sbls[1, 8] = new SourceGrid.Cells.ColumnHeader("Count Limit");
			this.grid_sbls[1, 8].View = cell;
			this.grid_sbls[1, 9] = new SourceGrid.Cells.ColumnHeader("Site Limit");
			this.grid_sbls[1, 9].View = cell;
			this.grid_sbls[1, 10] = new SourceGrid.Cells.ColumnHeader("CN Limit");
			this.grid_sbls[1, 10].View = cell;
			this.grid_sbls[1, 11] = new SourceGrid.Cells.ColumnHeader("BIN Site Limit");
			this.grid_sbls[1, 11].View = cell;
			this.grid_sbls[0, 12] = new SourceGrid.Cells.ColumnHeader("Base Limit");
			this.grid_sbls[0, 12].View = cell;
			this.grid_sbls[0, 12].ColumnSpan = 3;
			this.grid_sbls[1, 12] = new SourceGrid.Cells.ColumnHeader("cnt");
			this.grid_sbls[1, 12].View = cell;
			this.grid_sbls[1, 13] = new SourceGrid.Cells.ColumnHeader("%");
			this.grid_sbls[1, 13].View = cell;
			this.grid_sbls[1, 14] = new SourceGrid.Cells.ColumnHeader("site");
			this.grid_sbls[1, 14].View = cell;
			this.grid_sbls[0, 15] = new SourceGrid.Cells.ColumnHeader("calc base");
			this.grid_sbls[0, 15].View = cell;
			this.grid_sbls[0, 15].ColumnSpan = 2;
			this.grid_sbls[1, 15] = new SourceGrid.Cells.ColumnHeader("ispass");
			this.grid_sbls[1, 15].View = cell;
			this.grid_sbls[1, 16] = new SourceGrid.Cells.ColumnHeader("fwaferID");
			this.grid_sbls[1, 16].View = cell;
			this.grid_sbls[0, 17] = new SourceGrid.Cells.ColumnHeader("filter option");
			this.grid_sbls[0, 17].View = cell;
			this.grid_sbls[0, 17].ColumnSpan = 2;
			this.grid_sbls[1, 17] = new SourceGrid.Cells.ColumnHeader("OPT");
			this.grid_sbls[1, 17].View = cell;
			this.grid_sbls[1, 18] = new SourceGrid.Cells.ColumnHeader("StatusID");
			this.grid_sbls[1, 18].View = cell;
			int num = 2;
			foreach (object obj in sbls)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				this.grid_sbls.Rows.Insert(num);
				SBLItem sblitem = (SBLItem)dictionaryEntry.Value;
				this.grid_sbls[num, 0] = new SourceGrid.Cells.Cell(sblitem._no);
				this.grid_sbls[num, 0].Tag = sblitem;
				this.grid_sbls[num, 1] = new SourceGrid.Cells.Cell(sblitem._binno);
				this.grid_sbls[num, 2] = new SourceGrid.Cells.Cell(sblitem._plimit);
				this.grid_sbls[num, 3] = new SourceGrid.Cells.Cell(sblitem._climit);
				this.grid_sbls[num, 4] = new SourceGrid.Cells.Cell(sblitem._slimit);
				this.grid_sbls[num, 5] = new SourceGrid.Cells.Cell(sblitem._cnlimit);
				this.grid_sbls[num, 6] = new SourceGrid.Cells.Cell(sblitem._bslimit);
				this.grid_sbls[num, 7] = new SourceGrid.Cells.Cell(sblitem._aplimit);
				this.grid_sbls[num, 8] = new SourceGrid.Cells.Cell(sblitem._aclimit);
				this.grid_sbls[num, 9] = new SourceGrid.Cells.Cell(sblitem._aslimit);
				this.grid_sbls[num, 10] = new SourceGrid.Cells.Cell(sblitem._acnlimit);
				this.grid_sbls[num, 11] = new SourceGrid.Cells.Cell(sblitem._abslimit);
				this.grid_sbls[num, 12] = new SourceGrid.Cells.Cell(sblitem._basecount);
				this.grid_sbls[num, 13] = new SourceGrid.Cells.Cell(sblitem._basepercent);
				this.grid_sbls[num, 14] = new SourceGrid.Cells.Cell(sblitem._basecountsite);
				this.grid_sbls[num, 15] = new SourceGrid.Cells.Cell(sblitem._ispass);
				this.grid_sbls[num, 16] = new SourceGrid.Cells.Cell(sblitem._fwaferid);
				this.grid_sbls[num, 17] = new SourceGrid.Cells.Cell(sblitem._opt);
				this.grid_sbls[num, 18] = new SourceGrid.Cells.Cell(sblitem._fstatusid);
				num++;
			}
			this.grid_sbls.AutoSizeCells();
			int num2 = 0;
			int num3 = 0;
			foreach (object obj2 in ((IEnumerable)this.grid_sbls.Columns))
			{
				GridColumn gridColumn = (GridColumn)obj2;
				num2 += gridColumn.Width;
			}
			foreach (RowInfo rowInfo in this.grid_sbls.Rows)
			{
				GridRow gridRow = (GridRow)rowInfo;
				num3 += gridRow.Height;
			}
			this.panel_grid.Height = num3 + 20;
			this.panel_grid.Width = num2 + 20;
			if (this.panel_grid.Height > 250)
			{
				this.panel_grid.Height = 250;
			}
			if (this.panel_grid.Width < 850)
			{
				this.panel_grid.Width = 850;
			}
			base.Width = this.panel_grid.Right + 50;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00007244 File Offset: 0x00005444
		protected override Point ScrollToControl(Control activeControl)
		{
			return this.DisplayRectangle.Location;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00007260 File Offset: 0x00005460
		private SBLItem Getinfo(SBLItem sbli)
		{
			SBLItem sblitem = sbli ?? new SBLItem();
			sblitem._binno = this.textBox_bins.Text;
			sblitem._ispass = Convert.ToInt32(this.checkBox_ispass.Checked);
			sblitem._fwaferid = Convert.ToInt32(this.checkBox_fwaferid.Checked);
			sblitem._plimit = Convert.ToDouble(this.textBox_plimit.Text);
			sblitem._climit = Convert.ToInt32(this.textBox_climit.Text);
			sblitem._slimit = Convert.ToDouble(this.textBox_slimit.Text);
			sblitem._cnlimit = Convert.ToInt32(this.textBox_cnlimit.Text);
			sblitem._bslimit = (double)Convert.ToInt32(this.textBox_bslimit.Text);
			sblitem._aplimit = Convert.ToDouble(this.textBox_aplimit.Text);
			sblitem._aclimit = Convert.ToInt32(this.textBox_aclimit.Text);
			sblitem._aslimit = Convert.ToDouble(this.textBox_aslimit.Text);
			sblitem._acnlimit = Convert.ToInt32(this.textBox_acnlimit.Text);
			sblitem._abslimit = (double)Convert.ToInt32(this.textBox_abslimit.Text);
			sblitem._basecount = Convert.ToInt32(this.textBox_basecount.Text);
			sblitem._basepercent = Convert.ToDouble(this.textBox_basepercent.Text);
			sblitem._basecountsite = Convert.ToInt32(this.textBox_basesitecount.Text);
			sblitem._opt = this.comboBox_OPT.SelectedItem.ToString();
			sblitem._fstatusid = (string)this.textBox_statusid.Tag;
			return sblitem;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00007404 File Offset: 0x00005604
		private SBLItem Getinfobulk()
		{
			return new SBLItem
			{
				_ispass = Convert.ToInt32(this.checkBox_ispass.Checked),
				_fwaferid = Convert.ToInt32(this.checkBox_fwaferid.Checked),
				_basecount = Convert.ToInt32(this.textBox_basecount.Text),
				_basepercent = Convert.ToDouble(this.textBox_basepercent.Text),
				_basecountsite = Convert.ToInt32(this.textBox_basesitecount.Text),
				_opt = this.comboBox_OPT.SelectedItem.ToString(),
				_fstatusid = (string)this.textBox_statusid.Tag
			};
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000074B4 File Offset: 0x000056B4
		private void changeinfo(SBLItem sbli)
		{
			if (sbli != null)
			{
				this.textBox_bins.Text = sbli._binno;
				this.checkBox_ispass.Checked = Convert.ToBoolean(sbli._ispass);
				this.checkBox_fwaferid.Checked = Convert.ToBoolean(sbli._fwaferid);
				this.textBox_plimit.Text = sbli._plimit.ToString();
				this.textBox_climit.Text = sbli._climit.ToString();
				this.textBox_slimit.Text = sbli._slimit.ToString();
				this.textBox_cnlimit.Text = sbli._cnlimit.ToString();
				this.textBox_bslimit.Text = sbli._bslimit.ToString();
				this.textBox_aplimit.Text = sbli._aplimit.ToString();
				this.textBox_aclimit.Text = sbli._aclimit.ToString();
				this.textBox_aslimit.Text = sbli._aslimit.ToString();
				this.textBox_acnlimit.Text = sbli._acnlimit.ToString();
				this.textBox_abslimit.Text = sbli._abslimit.ToString();
				this.textBox_basecount.Text = sbli._basecount.ToString();
				this.textBox_basepercent.Text = sbli._basepercent.ToString();
				this.textBox_basesitecount.Text = sbli._basecountsite.ToString();
				if (this.comboBox_OPT.Items.Contains(sbli._opt.ToString()))
				{
					this.comboBox_OPT.SelectedItem = sbli._opt.ToString();
				}
				this.textBox_statusid.Text = "";
				foreach (string value in sbli._fstatusid.Split(new char[]
				{
					'|'
				}))
				{
					foreach (object obj in this.comboBox_statusid.Items)
					{
						string text = (string)obj;
						if (text.Contains(value))
						{
							this.comboBox_statusid.SelectedItem = text;
							this.button_addstatusid_Click(null, null);
						}
					}
				}
				return;
			}
			this.textBox_bins.Text = "";
			this.checkBox_ispass.Checked = false;
			this.checkBox_fwaferid.Checked = false;
			this.textBox_plimit.Text = "-1";
			this.textBox_climit.Text = "-1";
			this.textBox_slimit.Text = "-1";
			this.textBox_cnlimit.Text = "-1";
			this.textBox_bslimit.Text = "-1";
			this.textBox_aplimit.Text = "-1";
			this.textBox_aclimit.Text = "-1";
			this.textBox_aslimit.Text = "-1";
			this.textBox_acnlimit.Text = "-1";
			this.textBox_abslimit.Text = "-1";
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000077CC File Offset: 0x000059CC
		private void RULESBLBINView_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000077D0 File Offset: 0x000059D0
		private void grid_sbls_MouseClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			string empty = string.Empty;
			int row = grid.MouseDownPosition.Row;
			if (row >= 0)
			{
				SBLItem sblitem = (SBLItem)this.grid_sbls[row, 0].Tag;
				if (sblitem != null)
				{
					this._selectedindex = row;
					this._selectedSBLITEM = sblitem;
					this.changeinfo(sblitem);
				}
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00007830 File Offset: 0x00005A30
		private void button_addstatusid_Click(object sender, EventArgs e)
		{
			string text = this.comboBox_statusid.SelectedItem.ToString();
			if (this.textBox_statusid.Text != "")
			{
				if (text != "0")
				{
					if (!this.textBox_statusid.Text.Contains(text))
					{
						this.textBox_statusid.Text = this.textBox_statusid.Text + "|" + text;
						SortedList sortedList = (SortedList)this.comboBox_statusid.Tag;
						this.textBox_statusid.Tag = this.textBox_statusid.Tag.ToString() + "|" + ((refStatusID)sortedList[this.comboBox_statusid.SelectedItem]).StatusID;
						return;
					}
				}
				else if (this.textBox_statusid.Text.Contains("|"))
				{
					if (!this.textBox_statusid.Text.Contains(text + "|") && !this.textBox_statusid.Text.Contains("|" + text))
					{
						this.textBox_statusid.Text = this.textBox_statusid.Text + "|" + text;
						SortedList sortedList2 = (SortedList)this.comboBox_statusid.Tag;
						this.textBox_statusid.Tag = this.textBox_statusid.Tag.ToString() + "|" + ((refStatusID)sortedList2[this.comboBox_statusid.SelectedItem]).StatusID;
						return;
					}
				}
				else
				{
					if (!this.textBox_statusid.Text.Contains(text))
					{
						this.textBox_statusid.Text = this.textBox_statusid.Text + "|" + text;
						SortedList sortedList3 = (SortedList)this.comboBox_statusid.Tag;
						this.textBox_statusid.Tag = this.textBox_statusid.Tag.ToString() + "|" + ((refStatusID)sortedList3[this.comboBox_statusid.SelectedItem]).StatusID;
						return;
					}
					if (this.textBox_statusid.Text.IndexOf("0") != 0)
					{
						this.textBox_statusid.Text = this.textBox_statusid.Text + "|" + text;
						SortedList sortedList4 = (SortedList)this.comboBox_statusid.Tag;
						this.textBox_statusid.Tag = this.textBox_statusid.Tag.ToString() + "|" + ((refStatusID)sortedList4[this.comboBox_statusid.SelectedItem]).StatusID;
						return;
					}
				}
			}
			else
			{
				this.textBox_statusid.Text = text;
				SortedList sortedList5 = (SortedList)this.comboBox_statusid.Tag;
				this.textBox_statusid.Tag = ((refStatusID)sortedList5[this.comboBox_statusid.SelectedItem]).StatusID;
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00007B28 File Offset: 0x00005D28
		private void button_delStatus_Click(object sender, EventArgs e)
		{
			string text = this.comboBox_statusid.SelectedItem.ToString();
			if (this.textBox_statusid.Text != "" && this.textBox_statusid.Text.Contains("|"))
			{
				if (this.textBox_statusid.Text.Contains("|" + text + "|"))
				{
					this.textBox_statusid.Text = this.textBox_statusid.Text.Replace("|" + text + "|", "|");
					SortedList sortedList = (SortedList)this.comboBox_statusid.Tag;
					this.textBox_statusid.Tag = ((string)this.textBox_statusid.Tag).Replace("|" + ((refStatusID)sortedList[this.comboBox_statusid.SelectedItem]).StatusID + "|", "|");
					return;
				}
				if (this.textBox_statusid.Text.Contains(text + "|"))
				{
					this.textBox_statusid.Text = this.textBox_statusid.Text.Replace(text + "|", "");
					SortedList sortedList2 = (SortedList)this.comboBox_statusid.Tag;
					this.textBox_statusid.Tag = ((string)this.textBox_statusid.Tag).Replace(((refStatusID)sortedList2[this.comboBox_statusid.SelectedItem]).StatusID + "|", "");
					return;
				}
				if (this.textBox_statusid.Text.Contains("|" + text))
				{
					this.textBox_statusid.Text = this.textBox_statusid.Text.Replace("|" + text, "");
					SortedList sortedList3 = (SortedList)this.comboBox_statusid.Tag;
					this.textBox_statusid.Tag = ((string)this.textBox_statusid.Tag).Replace("|" + ((refStatusID)sortedList3[this.comboBox_statusid.SelectedItem]).StatusID, "");
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00007D80 File Offset: 0x00005F80
		private void button_edit_Click(object sender, EventArgs e)
		{
			if (this._selectedSBLITEM != null)
			{
				this._mode = 1;
				this.label_mode.Text = "Edit SBL";
				this.SetMode(true);
				this.button_NEW.Enabled = false;
				this.button_Close.Enabled = false;
				this.button_edit.Enabled = false;
				this.button_save.Enabled = true;
				this.button_cancle.Enabled = true;
				this.grid_sbls.Enabled = false;
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00007DFC File Offset: 0x00005FFC
		private void button_save_Click(object sender, EventArgs e)
		{
			this.SetMode(false);
			this.label_mode.Text = "View SBL";
			this.button_NEW.Enabled = true;
			this.button_Close.Enabled = true;
			this.button_edit.Enabled = true;
			this.button_save.Enabled = false;
			this.button_cancle.Enabled = false;
			this.grid_sbls.Enabled = true;
			if (this._mode == 1)
			{
				if (this._selectedSBLITEM != null)
				{
					this.Getinfo(this._selectedSBLITEM);
					this.SetGrid(this._sl_SBLS);
				}
				else
				{
					this._sl_SBLS = this.GridToSortedList();
					this.SetGrid(this._sl_SBLS);
				}
			}
			else if (this._mode == 2)
			{
				SBLItem sblitem = this.Getinfo(null);
				int num = this.checSBLS(sblitem);
				if (num == -1)
				{
					MessageBox.Show(string.Concat(new string[]
					{
						"Dont insert this SBLS \r\n Has Same Bins,OPT,STATUSID : ",
						sblitem._binno,
						" , ",
						sblitem._opt,
						" , ",
						sblitem._fstatusid
					}));
				}
				else
				{
					sblitem._no = this._sl_SBLS.Count + 1;
					this._sl_SBLS.Add(sblitem._no, sblitem);
					this._selectedSBLITEM = sblitem;
					this.SetGrid(this._sl_SBLS);
				}
				this._mode = 1;
			}
			this.ismodified = true;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00007F68 File Offset: 0x00006168
		private void button_cancle_Click(object sender, EventArgs e)
		{
			this.SetMode(false);
			this.label_mode.Text = "View SBL";
			this.button_NEW.Enabled = true;
			this.button_Close.Enabled = true;
			this.button_edit.Enabled = true;
			this.button_save.Enabled = false;
			this.button_cancle.Enabled = false;
			this.grid_sbls.Enabled = true;
			this.changeinfo(this._selectedSBLITEM);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00007FE0 File Offset: 0x000061E0
		private void button_Close_Click(object sender, EventArgs e)
		{
			if (this.ismodified)
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.Cancel;
			}
			base.Close();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00008000 File Offset: 0x00006200
		private void button_NEW_Click(object sender, EventArgs e)
		{
			this._mode = 2;
			this.label_mode.Text = "NEW SBL";
			this.SetMode(true);
			this.changeinfo(null);
			this.button_NEW.Enabled = false;
			this.button_Close.Enabled = false;
			this.button_edit.Enabled = false;
			this.button_save.Enabled = true;
			this.button_cancle.Enabled = true;
			this.grid_sbls.Enabled = false;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000807C File Offset: 0x0000627C
		private void SetMode(bool edit)
		{
			if (this.NOWMODE != edit)
			{
				if (edit)
				{
					this.checkBox_ispass.Enabled = true;
					this.checkBox_fwaferid.Enabled = true;
					this.textBox_plimit.ReadOnly = false;
					this.textBox_climit.ReadOnly = false;
					this.textBox_slimit.ReadOnly = false;
					this.textBox_cnlimit.ReadOnly = false;
					this.textBox_bslimit.ReadOnly = false;
					if (this._rulemanager._factory == "ATT")
					{
						this.textBox_aplimit.ReadOnly = false;
						this.textBox_aclimit.ReadOnly = false;
						this.textBox_aslimit.ReadOnly = false;
						this.textBox_acnlimit.ReadOnly = false;
						this.textBox_bslimit.ReadOnly = false;
					}
					this.button_delete.Enabled = true;
					if (this._mode == 2)
					{
						this.textBox_bins.ReadOnly = false;
						this.button_delete.Enabled = false;
					}
				}
				else
				{
					this.checkBox_ispass.Enabled = false;
					this.checkBox_fwaferid.Enabled = false;
					this.textBox_plimit.ReadOnly = true;
					this.textBox_climit.ReadOnly = true;
					this.textBox_slimit.ReadOnly = true;
					this.textBox_cnlimit.ReadOnly = true;
					this.textBox_bslimit.ReadOnly = true;
					if (this._rulemanager._factory == "ATT")
					{
						this.textBox_aplimit.ReadOnly = true;
						this.textBox_aclimit.ReadOnly = true;
						this.textBox_aslimit.ReadOnly = true;
						this.textBox_acnlimit.ReadOnly = true;
						this.textBox_abslimit.ReadOnly = true;
					}
					this.button_delete.Enabled = false;
					if (this._mode == 2)
					{
						this.textBox_bins.ReadOnly = true;
						this.button_delete.Enabled = false;
					}
				}
				this.NOWMODE = edit;
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00008254 File Offset: 0x00006454
		private SortedList GridToSortedList()
		{
			SortedList sortedList = new SortedList();
			if (this.grid_sbls.RowsCount > 2)
			{
				int num = 1;
				for (int i = 2; i < this.grid_sbls.RowsCount; i++)
				{
					SBLItem sblitem = (SBLItem)this.grid_sbls[i, 0].Tag;
					if (sblitem != null)
					{
						sblitem._no = num;
						sortedList.Add(num, sblitem);
						num++;
					}
				}
			}
			return sortedList;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000082C4 File Offset: 0x000064C4
		private void button_delete_Click(object sender, EventArgs e)
		{
			if (this._selectedSBLITEM != null)
			{
				DialogResult dialogResult = MessageBox.Show("do you want to delete bin#  : " + this._selectedSBLITEM._binno + " ?", "delete SBLS", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.grid_sbls.Rows.Remove(this._selectedindex);
					this._selectedindex = -1;
					this._selectedSBLITEM = null;
					this.SetGrid(this.GridToSortedList());
				}
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00008334 File Offset: 0x00006534
		private void button_bulkInsert_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = this.openFileDialog_csv.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this.changeinfo(null);
				string fileName = this.openFileDialog_csv.FileName;
				StreamReader streamReader = new StreamReader(fileName);
				while (streamReader.Peek() >= 0)
				{
					string text = streamReader.ReadLine();
					string[] array = text.Split(new char[]
					{
						','
					});
					if (!array[0].ToUpper().Contains("BINNO") && array.Length >= 11)
					{
						string binno = array[0];
						double plimit = Convert.ToDouble(array[1]);
						int climit = Convert.ToInt32(array[2]);
						double slimit = Convert.ToDouble(array[3]);
						int cnlimit = Convert.ToInt32(array[4]);
						double bslimit = Convert.ToDouble(array[5]);
						double aplimit = Convert.ToDouble(array[6]);
						int aclimit = Convert.ToInt32(array[7]);
						double aslimit = Convert.ToDouble(array[8]);
						int acnlimit = Convert.ToInt32(array[9]);
						int num = Convert.ToInt32(array[10]);
						SBLItem sblitem = this.Getinfobulk();
						sblitem._no = this._sl_SBLS.Count + 1;
						sblitem._binno = binno;
						sblitem._plimit = plimit;
						sblitem._climit = climit;
						sblitem._slimit = slimit;
						sblitem._cnlimit = cnlimit;
						sblitem._bslimit = bslimit;
						sblitem._aplimit = aplimit;
						sblitem._aclimit = aclimit;
						sblitem._aslimit = aslimit;
						sblitem._acnlimit = acnlimit;
						sblitem._abslimit = (double)num;
						if (array.Length >= 18)
						{
							int basecount = Convert.ToInt32(array[11]);
							double basepercent = Convert.ToDouble(array[12]);
							int basecountsite = Convert.ToInt32(array[13]);
							int ispass = Convert.ToInt32(array[14]);
							int fwaferid = Convert.ToInt32(array[15]);
							string opt = array[16];
							string fstatusid = array[17];
							sblitem._basecount = basecount;
							sblitem._basepercent = basepercent;
							sblitem._basecountsite = basecountsite;
							sblitem._ispass = ispass;
							sblitem._fwaferid = fwaferid;
							sblitem._opt = opt;
							sblitem._fstatusid = fstatusid;
						}
						int num2 = this.checSBLS(sblitem);
						if (num2 == -1)
						{
							MessageBox.Show(string.Concat(new string[]
							{
								"Dont insert this SBLS \r\n Has Same Bins,OPT,STATUSID : ",
								sblitem._binno,
								" , ",
								sblitem._opt,
								" , ",
								sblitem._fstatusid
							}));
						}
						else
						{
							this._sl_SBLS.Add(sblitem._no, sblitem);
						}
					}
				}
				streamReader.Close();
				this.SetGrid(this._sl_SBLS);
				this.ismodified = true;
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000085E0 File Offset: 0x000067E0
		private int checSBLS(SBLItem newsbl)
		{
			foreach (object obj in this._sl_SBLS)
			{
				SBLItem sblitem = (SBLItem)((DictionaryEntry)obj).Value;
				if (sblitem._binno == newsbl._binno && sblitem._opt == newsbl._opt)
				{
					string[] array = sblitem._fstatusid.Split(new char[]
					{
						'|'
					});
					string[] array2 = newsbl._fstatusid.Split(new char[]
					{
						'|'
					});
					foreach (string a in array)
					{
						foreach (string b in array2)
						{
							if (a == b)
							{
								return -1;
							}
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00008700 File Offset: 0x00006900
		private void button_Export_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = this.saveFileDialog_csv.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(this.saveFileDialog_csv.FileName);
				for (int i = 0; i < this.grid_sbls.Rows.Count; i++)
				{
					string text = "";
					for (int j = 1; j < this.grid_sbls.Columns.Count; j++)
					{
						text += this.grid_sbls[i, j].Value.ToString();
						if (j != this.grid_sbls.Columns.Count - 1)
						{
							text += ",";
						}
					}
					streamWriter.WriteLine(text);
				}
				streamWriter.Close();
			}
		}

		// Token: 0x04000074 RID: 116
		public RULESBLManager _rulemanager;

		// Token: 0x04000075 RID: 117
		private bool NOWMODE;

		// Token: 0x04000076 RID: 118
		public SortedList _sl_SBLS;

		// Token: 0x04000077 RID: 119
		private RefInfo _refINFO;

		// Token: 0x04000078 RID: 120
		private SBLItem _selectedSBLITEM;

		// Token: 0x04000079 RID: 121
		private int _selectedindex = -1;

		// Token: 0x0400007A RID: 122
		private bool ismodified;

		// Token: 0x0400007B RID: 123
		private int _mode = 1;
	}
}
