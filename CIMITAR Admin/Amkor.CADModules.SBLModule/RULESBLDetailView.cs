using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Amkor.CADModules.SBLModule.CIMitarAdminWS;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000017 RID: 23
	public partial class RULESBLDetailView : Form
	{
		// Token: 0x06000088 RID: 136 RVA: 0x0000A7B4 File Offset: 0x000089B4
		public RULESBLDetailView(RULESBLManager rulemanager, RefInfo refinfo, RuleSBLItem RuleSBL)
		{
			this.InitializeComponent();
			this._RuleSBL = RuleSBL;
			this._refINFO = refinfo;
			this._rulemanager = rulemanager;
			this.initSetupForRULESBL();
			this._mode = 1;
			this.label_MODE.Text = "Modify RULE";
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000A830 File Offset: 0x00008A30
		public RULESBLDetailView(RULESBLManager rulemanager, RefInfo refinfo)
		{
			this.InitializeComponent();
			this._RuleSBL = new RuleSBLItem();
			this._refINFO = refinfo;
			this._rulemanager = rulemanager;
			this.initSetupForRULESBL();
			this.comboBox_sbltype.SelectedIndex = 0;
			this.comboBox_actiontype.SelectedIndex = 0;
			this._mode = 2;
			this.label_MODE.Text = "Create NEW RULE ";
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000A8C8 File Offset: 0x00008AC8
		private void initSetupForRULESBL()
		{
			if (this._rulemanager._factory == "ATT")
			{
				this.comboBox_sbltype.Items.AddRange(new object[]
				{
					"SINGLE BIN by DEV",
					"MULTI BIN by DEV"
				});
			}
			else if (this._rulemanager._factory == "ATK")
			{
				this.comboBox_sbltype.Items.AddRange(new object[]
				{
					"SINGLE BIN by DEV",
					"MULTI BIN by DEV"
				});
			}
			else
			{
				this.comboBox_sbltype.Items.AddRange(new object[]
				{
					"SINGLE BIN by DEV",
					"MULTI BIN by DEV"
				});
			}
			SortedList sortedList = new SortedList();
			this.comboBox_sbltype.Tag = sortedList;
			sortedList.Add("SINGLE BIN by DEV", "10100001");
			sortedList.Add("MULTI BIN by DEV", "10100002");
			sortedList.Add("SINGLE BIN by NICK", "10100003");
			sortedList.Add("MULTI BIN by NICK", "10100004");
			this.comboBox_actiontype.Items.AddRange(new object[]
			{
				"Default Action"
			});
			SortedList sortedList2 = new SortedList();
			this.comboBox_actiontype.Tag = sortedList2;
			sortedList2.Add("Default Action", "10100001");
			foreach (object obj in ((SortedList)this.comboBox_sbltype.Tag))
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				if ((string)dictionaryEntry.Value == this._RuleSBL._typecode.ToString())
				{
					this.comboBox_sbltype.SelectedItem = dictionaryEntry.Key;
				}
			}
			if (this.comboBox_sbltype.SelectedItem == null)
			{
				this.comboBox_sbltype.SelectedIndex = 0;
			}
			foreach (object obj2 in ((SortedList)this.comboBox_actiontype.Tag))
			{
				DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
				if ((string)dictionaryEntry2.Value == this._RuleSBL._actioncode.ToString())
				{
					this.comboBox_actiontype.SelectedItem = dictionaryEntry2.Key;
				}
			}
			if (this.comboBox_actiontype.SelectedItem == null)
			{
				this.comboBox_actiontype.SelectedIndex = 0;
			}
			this.checkBox_active.Checked = Convert.ToBoolean(this._RuleSBL._active);
			if (this._RuleSBL._typecode < 10100003)
			{
				this.textBox_DEVICE.Text = this._RuleSBL._skey;
			}
			else if (this._RuleSBL._typecode < 10100005)
			{
				this.textBox_NICK.Text = this._RuleSBL._skey;
			}
			this.textBox_CUSTOMER.Text = this._RuleSBL._skeysub1;
			this.textBox_userid.Text = this._RuleSBL._userID;
			this.textBox_mailaddr.Text = this._RuleSBL._mailaddr;
			this.textBox_comment.Text = this._RuleSBL._comment;
			this.SetGrid(this._RuleSBL._sbls);
			this.SetMode(false);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000AC44 File Offset: 0x00008E44
		private int SaveRuleSBL()
		{
			int result = 0;
			this._RuleSBL._typecode = Convert.ToInt32(((SortedList)this.comboBox_sbltype.Tag)[this.comboBox_sbltype.SelectedItem]);
			this._RuleSBL._actioncode = Convert.ToInt32(((SortedList)this.comboBox_actiontype.Tag)[this.comboBox_actiontype.SelectedItem]);
			this._RuleSBL._active = Convert.ToInt32(this.checkBox_active.Checked);
			if (this._RuleSBL._typecode < 10100003)
			{
				this._RuleSBL._skey = this.textBox_DEVICE.Text;
			}
			else if (this._RuleSBL._typecode < 10100005)
			{
				this._RuleSBL._skey = this.textBox_NICK.Text;
			}
			this._RuleSBL._skeysub1 = this.textBox_CUSTOMER.Text;
			this._RuleSBL._userID = this.textBox_userid.Text;
			this._RuleSBL._mailaddr = this.textBox_mailaddr.Text;
			this._RuleSBL._comment = this.textBox_comment.Text;
			if (this._RuleSBL._sbls != null)
			{
				this._RuleSBL._sbls.Clear();
				this._RuleSBL._sbls = null;
			}
			this._RuleSBL._sbls = this.GridToSortedList();
			return result;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000ADB4 File Offset: 0x00008FB4
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

		// Token: 0x0600008D RID: 141 RVA: 0x0000AE24 File Offset: 0x00009024
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

		// Token: 0x0600008E RID: 142 RVA: 0x0000AEA4 File Offset: 0x000090A4
		private void SetGrid(SortedList sbls)
		{
			this.ResetGrid();
			SourceGrid.Cells.Views.Cell cell = new SourceGrid.Cells.Views.Cell();
			cell.BackColor = Color.FromArgb(130, 179, 237);
			cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			SourceGrid.Cells.Views.Cell cell2 = new SourceGrid.Cells.Views.Cell();
			cell2.BackColor = Color.FromArgb(255, 192, 203);
			this.grid_sbls.ColumnsCount = 12;
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
			int num = 2;
			if (sbls != null)
			{
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
					num++;
				}
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
			base.Width = this.panel_grid.Right + 50;
			if (this.panel_grid.Height > 150)
			{
				this.panel_grid.Height = 150;
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000B500 File Offset: 0x00009700
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

		// Token: 0x06000090 RID: 144 RVA: 0x0000B520 File Offset: 0x00009720
		private void comboBox_sbltype_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this._mode == 2)
			{
				if (this.comboBox_sbltype.SelectedIndex < 2)
				{
					this.textBox_DEVICE.Enabled = true;
					this.button_change_devie.Enabled = true;
					if (this.tmp_device != "")
					{
						this.textBox_DEVICE.Text = this.tmp_device;
					}
					this.textBox_NICK.Enabled = false;
					this.button_change_nick.Enabled = false;
					if (this.textBox_NICK.Text != "")
					{
						this.tmp_nick = this.textBox_NICK.Text;
						this.textBox_NICK.Text = "";
						return;
					}
				}
				else if (this.comboBox_sbltype.SelectedIndex < 4)
				{
					this.textBox_DEVICE.Enabled = false;
					this.button_change_devie.Enabled = false;
					if (this.textBox_DEVICE.Text != "")
					{
						this.tmp_device = this.textBox_DEVICE.Text;
						this.textBox_DEVICE.Text = "";
					}
					this.textBox_NICK.Enabled = true;
					this.button_change_nick.Enabled = true;
					if (this.tmp_nick != "")
					{
						this.textBox_NICK.Text = this.tmp_nick;
						return;
					}
				}
				else
				{
					this.textBox_DEVICE.Enabled = true;
					this.textBox_NICK.Enabled = false;
				}
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000B690 File Offset: 0x00009890
		private void button_editSBLS_Click(object sender, EventArgs e)
		{
			SortedList sl_SBLS = this.GridToSortedList();
			RULESBLBINView rulesblbinview = new RULESBLBINView(this._rulemanager, this._refINFO, sl_SBLS);
			DialogResult dialogResult = rulesblbinview.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this.SetGrid(rulesblbinview._sl_SBLS);
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000B6D0 File Offset: 0x000098D0
		private void button_edit_Click(object sender, EventArgs e)
		{
			this.SetMode(true);
			this.button_Close.Enabled = false;
			this.button_edit.Enabled = false;
			this.button_save.Enabled = true;
			this.button_cancle.Enabled = true;
			this.comboBox_sbltype_SelectedIndexChanged(null, null);
			this.textBox_userid.Text = this._rulemanager._cimitarUser._id;
			this._OR_RuleSBL = this._RuleSBL.ClonRuleSBLItem();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000B748 File Offset: 0x00009948
		private DataSet queryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._rulemanager._factorySetting._urlServer + "CIMitarWebService/CIMitarWS.asmx";
				cimitarWSSoapClient.Endpoint.Address = new EndpointAddress(uri);
				dataSet = cimitarWSSoapClient.CIMitarQuaryCall("CIMitarMasterDBConnect", sQuery);
				result = dataSet;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				result = dataSet;
			}
			return result;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000B7C4 File Offset: 0x000099C4
		public int UpdateRule(RuleSBLItem RuleSBL)
		{
			string sQuery = string.Concat(new object[]
			{
				"EXEC [CIMitar_Master].[dbo].[USP_RULESBL_UpdateRule] @ruleid = '",
				RuleSBL._ruleID.ToString(),
				"', @typecode = '",
				RuleSBL._typecode.ToString(),
				"', @actioncode = '",
				RuleSBL._actioncode.ToString(),
				"', @userid = '",
				RuleSBL._userID,
				"', @skey = '",
				RuleSBL._skey,
				"', @skeysub1 = '",
				RuleSBL._skeysub1,
				"', @argv = '",
				RuleSBL.makeXMLString(),
				"', @argvsub1 = '",
				RuleSBL._mailaddr,
				"', @active = '",
				RuleSBL._active,
				"', @comment = '",
				RuleSBL._comment,
				"'"
			});
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != null)
			{
				return Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			return -1;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000B928 File Offset: 0x00009B28
		public int InsertRule(RuleSBLItem RuleSBL)
		{
			string sQuery = string.Concat(new object[]
			{
				"EXEC [CIMitar_Master].[dbo].[USP_RULESBL_InsertRule] @typecode = '",
				RuleSBL._typecode.ToString(),
				"', @actioncode = '",
				RuleSBL._actioncode.ToString(),
				"', @userid = '",
				RuleSBL._userID,
				"', @skey = '",
				RuleSBL._skey,
				"', @skeysub1 = '",
				RuleSBL._skeysub1,
				"', @argv = '",
				RuleSBL.makeXMLString(),
				"', @argvsub1 = '",
				RuleSBL._mailaddr,
				"', @active = '",
				RuleSBL._active,
				"', @comment = '",
				RuleSBL._comment,
				"'"
			});
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != null)
			{
				return Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			return -1;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000BA74 File Offset: 0x00009C74
		private void button_save_Click(object sender, EventArgs e)
		{
			this.SetMode(false);
			this.button_Close.Enabled = true;
			this.button_edit.Enabled = true;
			this.button_save.Enabled = false;
			this.button_cancle.Enabled = false;
			this.SaveRuleSBL();
			this.ismodified = true;
			if (this._mode == 2)
			{
				int num = this.InsertRule(this._RuleSBL);
				if (num <= -1)
				{
					MessageBox.Show("Insert Fail");
					this.ismodified = false;
					return;
				}
				this._RuleSBL._ruleID = num;
				if (!this._rulemanager.AddRules(this._RuleSBL))
				{
					MessageBox.Show("has same keys");
					this.ismodified = false;
					return;
				}
				MessageBox.Show(string.Concat(new string[]
				{
					"Insert Sucess \r\n ruleID : ",
					this._RuleSBL._ruleID.ToString(),
					"\r\n typecode : ",
					this._RuleSBL._typecode.ToString(),
					"\r\n skey : ",
					this._RuleSBL._skey,
					"\r\n skeysub1 : ",
					this._RuleSBL._skeysub1
				}));
				this._mode = 1;
				this.label_MODE.Text = "Modify RULE";
				return;
			}
			else
			{
				if (this.UpdateRule(this._RuleSBL) == 0)
				{
					MessageBox.Show(string.Concat(new string[]
					{
						"Update Sucess \r\n ruleID : ",
						this._RuleSBL._ruleID.ToString(),
						"\r\n typecode : ",
						this._RuleSBL._typecode.ToString(),
						"\r\n skey : ",
						this._RuleSBL._skey,
						"\r\n skeysub1 : ",
						this._RuleSBL._skeysub1
					}));
					return;
				}
				MessageBox.Show("update Fail");
				this.ismodified = false;
				return;
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000BC4E File Offset: 0x00009E4E
		private void button_cancle_Click(object sender, EventArgs e)
		{
			this.SetMode(false);
			this.button_Close.Enabled = true;
			this.button_edit.Enabled = true;
			this.button_save.Enabled = false;
			this.button_cancle.Enabled = false;
			this.initSetupForRULESBL();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000BC90 File Offset: 0x00009E90
		private void button_change_devie_Click(object sender, EventArgs e)
		{
			SelectDevice selectDevice = new SelectDevice(this._refINFO);
			DialogResult dialogResult = selectDevice.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this.textBox_DEVICE.Text = selectDevice._selectDevice.Devicename;
				this.textBox_CUSTOMER.Text = selectDevice._selectDevice.customername;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000BCE0 File Offset: 0x00009EE0
		private void button_change_nick_Click(object sender, EventArgs e)
		{
			SelectNick selectNick = new SelectNick(this._refINFO);
			DialogResult dialogResult = selectNick.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this.textBox_NICK.Text = selectNick._selectNick.NICK;
				this.textBox_CUSTOMER.Text = selectNick._selectNick.customername;
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000BD30 File Offset: 0x00009F30
		protected override Point ScrollToControl(Control activeControl)
		{
			return this.DisplayRectangle.Location;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000BD4C File Offset: 0x00009F4C
		private void SetMode(bool edit)
		{
			if (edit)
			{
				this.label_modestr.Text = "EDITING";
				this.checkBox_active.Enabled = true;
				this.comboBox_actiontype.Enabled = true;
				this.textBox_mailaddr.ReadOnly = false;
				this.textBox_comment.ReadOnly = false;
				this.button_editSBLS.Enabled = true;
				this.button_delete.Enabled = true;
				this.button_delALL.Enabled = true;
				this.textBox_DEVICE.ReadOnly = false;
				this.textBox_CUSTOMER.ReadOnly = false;
				this.textBox_NICK.ReadOnly = false;
				if (this._mode == 2)
				{
					this.comboBox_sbltype.Enabled = true;
					this.button_change_devie.Enabled = true;
					this.button_change_nick.Enabled = true;
				}
			}
			else
			{
				this.label_modestr.Text = "VIEW";
				this.checkBox_active.Enabled = false;
				this.comboBox_actiontype.Enabled = false;
				this.textBox_mailaddr.ReadOnly = true;
				this.textBox_comment.ReadOnly = true;
				this.button_editSBLS.Enabled = false;
				this.button_delete.Enabled = false;
				this.button_delALL.Enabled = false;
				this.textBox_DEVICE.ReadOnly = true;
				this.textBox_CUSTOMER.ReadOnly = true;
				this.textBox_NICK.ReadOnly = true;
				if (this._mode == 2)
				{
					this.comboBox_sbltype.Enabled = false;
					this.button_change_devie.Enabled = false;
					this.button_change_nick.Enabled = false;
				}
			}
			this.NOWMODE = edit;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000BED8 File Offset: 0x0000A0D8
		private void grid_sbls_DoubleClick(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000BEDC File Offset: 0x0000A0DC
		private void grid_sbls_MouseClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			string empty = string.Empty;
			int row = grid.MouseDownPosition.Row;
			if (row >= 0 && grid[row, 0].Tag != null)
			{
				this._selectedSBLITEM = (SBLItem)grid[row, 0].Tag;
				this._selectRow = row;
				this.label_selectedSBL.Text = this._selectedSBLITEM._binno;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000BF50 File Offset: 0x0000A150
		private void button_delete_Click(object sender, EventArgs e)
		{
			if (this._selectedSBLITEM != null)
			{
				DialogResult dialogResult = MessageBox.Show("do you want to delete bin#  : " + this._selectedSBLITEM._binno + " ?", "delete SBLS", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.grid_sbls.Rows.Remove(this._selectRow);
					this._selectRow = -1;
					this._selectedSBLITEM = null;
					this.label_selectedSBL.Text = "Select Bin#";
					this.SetGrid(this.GridToSortedList());
				}
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000BFCF File Offset: 0x0000A1CF
		private void button_delALL_Click(object sender, EventArgs e)
		{
			this._selectRow = -1;
			this._selectedSBLITEM = null;
			this.label_selectedSBL.Text = "Select Bin#";
			this.SetGrid(null);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000BFF6 File Offset: 0x0000A1F6
		private void RULESBLDetailView_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x040000B3 RID: 179
		public RULESBLManager _rulemanager;

		// Token: 0x040000B4 RID: 180
		private RuleSBLItem _OR_RuleSBL;

		// Token: 0x040000B5 RID: 181
		private bool ismodified;

		// Token: 0x040000B6 RID: 182
		private int _mode = 1;

		// Token: 0x040000B7 RID: 183
		private bool NOWMODE;

		// Token: 0x040000B8 RID: 184
		private string tmp_device = "";

		// Token: 0x040000B9 RID: 185
		private string tmp_nick = "";

		// Token: 0x040000BA RID: 186
		private string tmp_customer = "";

		// Token: 0x040000BB RID: 187
		private RuleSBLItem _RuleSBL;

		// Token: 0x040000BC RID: 188
		private RefInfo _refINFO;

		// Token: 0x040000BD RID: 189
		private SBLItem _selectedSBLITEM;

		// Token: 0x040000BE RID: 190
		private int _selectRow = -1;
	}
}
