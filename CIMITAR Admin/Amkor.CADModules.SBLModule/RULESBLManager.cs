using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Amkor.CADModules.SBLModule.CIMitarAdminWS;
using Amkor.CADModules.SBLModule.Control;
using Amkor.CADModules.SBLModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Compenents.XMLData;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000018 RID: 24
	public partial class RULESBLManager : BaseWinView
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
		public RULESBLManager()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://testweb.amkor.co.kr/";
			this._factorySetting._startHour = 6;
			this._factorySetting._startMin = 0;
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this.InitializeComponent();
			this._factory = "ATK";
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000D860 File Offset: 0x0000BA60
		public RULESBLManager(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
			this._factory = this._factorySetting._factoryName;
			if (!this.getAuth())
			{
				MessageBox.Show("You are not authorized.", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.isReadOnly = true;
				this.cmdAdd.Enabled = false;
				this.cmdAdd.Image = Resources.TableAdd_Down;
				this.cmdDelete.Enabled = false;
				this.cmdDelete.Image = Resources.TableRemove_Donw;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000D928 File Offset: 0x0000BB28
		private bool getAuth()
		{
			bool result = false;
			string sQuery = "EXEC [CIMitar_AppConfig].[dbo].[USP_AppConfig_GetUserMenuAuth] @userid = '" + this._cimitarUser._id + "', @authcode = 'CAD_SBL'";
			DataSet dataSet = this.queryCall(sQuery);
			if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000D988 File Offset: 0x0000BB88
		private void RULESBLManager_Load(object sender, EventArgs e)
		{
			this.SetupBaseInfos();
			this.SetupBaseRules(this.textBox_keyword.Text.Trim());
			this.label_copyright.Text = "Copyright © 2017-" + DateTime.Today.Year.ToString() + " Amkor Technology Korea, Inc. All Rights Reserved.";
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000D9E0 File Offset: 0x0000BBE0
		private void SetupBaseInfos()
		{
			DataSet devices = this.GetDevices();
			if (devices != null)
			{
				this._refinfo = new RefInfo();
				if (devices.Tables.Count >= 4)
				{
					if (devices.Tables[0].Rows.Count > 0)
					{
						string text = "";
						foreach (object obj in devices.Tables[0].Rows)
						{
							DataRow dataRow = (DataRow)obj;
							text += dataRow[0].ToString();
						}
						this._refinfo.DeviceXML = new XMLManager(text);
						this._refinfo.MakeDeviceList();
					}
					if (devices.Tables[1].Rows.Count > 0)
					{
						string text2 = "";
						foreach (object obj2 in devices.Tables[1].Rows)
						{
							DataRow dataRow2 = (DataRow)obj2;
							text2 += dataRow2[0].ToString();
						}
						this._refinfo.NICKXML = new XMLManager(text2);
						this._refinfo.MakeNickList();
					}
					if (devices.Tables[2].Rows.Count > 0)
					{
						this._refinfo.al_Operation = new ArrayList();
						foreach (object obj3 in devices.Tables[2].Rows)
						{
							DataRow dataRow3 = (DataRow)obj3;
							refOPT refOPT = new refOPT();
							refOPT.operationName = dataRow3["name"].ToString();
							refOPT.operationcode = dataRow3["code"].ToString();
							this._refinfo.al_Operation.Add(refOPT);
						}
					}
					if (devices.Tables[3].Rows.Count > 0)
					{
						this._refinfo.al_StatusID = new ArrayList();
						foreach (object obj4 in devices.Tables[3].Rows)
						{
							DataRow dataRow4 = (DataRow)obj4;
							refStatusID refStatusID = new refStatusID();
							refStatusID.Status = dataRow4["status"].ToString();
							refStatusID.StatusID = dataRow4["statusid"].ToString();
							this._refinfo.al_StatusID.Add(refStatusID);
						}
					}
				}
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000DCF4 File Offset: 0x0000BEF4
		private void SetupBaseRules(string sKey)
		{
			this.sl_sbls_base = new SortedList();
			DataSet dataSet = new DataSet();
			try
			{
				string sQuery = "EXEC [CIMitar_Master].[dbo].[USP_RULESBL_GetRuleFilterList] @FILTERSTR = '" + sKey + "'";
				dataSet = this.queryCall(sQuery);
				if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					foreach (object obj in dataSet.Tables[0].Rows)
					{
						DataRow dataRow = (DataRow)obj;
						RuleSBLItem ruleSBLItem = new RuleSBLItem();
						ruleSBLItem._ruleID = Convert.ToInt32(dataRow["ruleid"].ToString());
						ruleSBLItem._typecode = Convert.ToInt32(dataRow["typecode"].ToString());
						ruleSBLItem._actioncode = Convert.ToInt32(dataRow["actioncode"].ToString());
						ruleSBLItem._userID = dataRow["userid"].ToString();
						ruleSBLItem._skey = dataRow["skey"].ToString();
						ruleSBLItem._skeysub1 = dataRow["skeysub1"].ToString();
						ruleSBLItem.insertSBLS(dataRow["argv"].ToString());
						ruleSBLItem._mailaddr = dataRow["argvsub1"].ToString();
						ruleSBLItem._active = Convert.ToInt32(dataRow["active"]);
						ruleSBLItem._comment = dataRow["comment"].ToString();
						this.sl_sbls_base.Add(ruleSBLItem._ruleID, ruleSBLItem);
					}
				}
				this.SetGrid(this.sl_sbls_base);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000DF08 File Offset: 0x0000C108
		private void ResetGrid()
		{
			this.grid_rules.Rows.Clear();
			this.grid_rules.Selection.EnableMultiSelection = false;
			this.grid_rules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_rules.CustomSort = true;
			this.grid_rules.Rows.Clear();
			this.grid_rules.Selection.EnableMultiSelection = false;
			this.grid_rules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_rules.CustomSort = true;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000DF88 File Offset: 0x0000C188
		private void SetGrid(SortedList sbls)
		{
			this.ResetGrid();
			SourceGrid.Cells.Views.Cell cell = new SourceGrid.Cells.Views.Cell();
			cell.BackColor = Color.FromArgb(130, 179, 237);
			cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			SourceGrid.Cells.Views.Cell cell2 = new SourceGrid.Cells.Views.Cell();
			cell2.BackColor = Color.FromArgb(255, 192, 203);
			this.grid_rules.ColumnsCount = 8;
			this.grid_rules.FixedRows = 1;
			this.grid_rules.Rows.Insert(0);
			this.grid_rules[0, 0] = new SourceGrid.Cells.ColumnHeader("RULE ID");
			this.grid_rules[0, 0].View = cell;
			this.grid_rules[0, 1] = new SourceGrid.Cells.ColumnHeader("Device");
			this.grid_rules[0, 1].View = cell;
			this.grid_rules[0, 2] = new SourceGrid.Cells.ColumnHeader("Customer");
			this.grid_rules[0, 2].View = cell;
			this.grid_rules[0, 3] = new SourceGrid.Cells.ColumnHeader("USERID");
			this.grid_rules[0, 3].View = cell;
			this.grid_rules[0, 4] = new SourceGrid.Cells.ColumnHeader("TYPECODE");
			this.grid_rules[0, 4].View = cell;
			this.grid_rules[0, 5] = new SourceGrid.Cells.ColumnHeader("ACTIONCODE");
			this.grid_rules[0, 5].View = cell;
			this.grid_rules[0, 6] = new SourceGrid.Cells.ColumnHeader("active");
			this.grid_rules[0, 6].View = cell;
			this.grid_rules[0, 7] = new SourceGrid.Cells.ColumnHeader("Comment");
			this.grid_rules[0, 7].View = cell;
			int num = 1;
			if (sbls != null)
			{
				foreach (object obj in sbls)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					this.grid_rules.Rows.Insert(num);
					RuleSBLItem ruleSBLItem = (RuleSBLItem)dictionaryEntry.Value;
					this.grid_rules[num, 0] = new SourceGrid.Cells.Cell(ruleSBLItem._ruleID);
					this.grid_rules[num, 0].Tag = ruleSBLItem;
					this.grid_rules[num, 1] = new SourceGrid.Cells.Cell(ruleSBLItem._skey);
					this.grid_rules[num, 2] = new SourceGrid.Cells.Cell(ruleSBLItem._skeysub1);
					this.grid_rules[num, 3] = new SourceGrid.Cells.Cell(ruleSBLItem._userID);
					this.grid_rules[num, 4] = new SourceGrid.Cells.Cell(ruleSBLItem._typecode);
					this.grid_rules[num, 5] = new SourceGrid.Cells.Cell(ruleSBLItem._actioncode);
					this.grid_rules[num, 6] = new SourceGrid.Cells.Cell(ruleSBLItem._active);
					this.grid_rules[num, 7] = new SourceGrid.Cells.Cell(ruleSBLItem._comment);
					num++;
				}
			}
			this.gridInfo.AutoSetGrid(this.grid_rules);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000E2E4 File Offset: 0x0000C4E4
		private void grid_rules_MouseClick(object sender, MouseEventArgs e)
		{
			Grid grid = (Grid)sender;
			string empty = string.Empty;
			int row = grid.MouseDownPosition.Row;
			if (row >= 0 && this.grid_rules[row, 0].Tag != null)
			{
				this._selected_ruleSBLITEM = (RuleSBLItem)this.grid_rules[row, 0].Tag;
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000E344 File Offset: 0x0000C544
		private void grid_rules_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.isReadOnly)
			{
				return;
			}
			Grid grid = (Grid)sender;
			string empty = string.Empty;
			int row = grid.MouseDownPosition.Row;
			if (row >= 0 && this.grid_rules[row, 0].Tag != null)
			{
				RuleSBLItem ruleSBLItem = (RuleSBLItem)this.grid_rules[row, 0].Tag;
				if (ruleSBLItem != null)
				{
					this._selected_ruleSBLITEM = ruleSBLItem;
					RULESBLDetailView rulesbldetailView = new RULESBLDetailView(this, this._refinfo, ruleSBLItem);
					DialogResult dialogResult = rulesbldetailView.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						this.SetGrid(this.sl_sbls_base);
					}
				}
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000E3D8 File Offset: 0x0000C5D8
		protected override Point ScrollToControl(Control activeControl)
		{
			return this.DisplayRectangle.Location;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000E3F4 File Offset: 0x0000C5F4
		private DataSet queryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._factorySetting._urlServer + "CIMitarWebService/CIMitarWS.asmx";
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

		// Token: 0x060000AF RID: 175 RVA: 0x0000E46C File Offset: 0x0000C66C
		private DataSet GetDevices()
		{
			DataSet result = new DataSet();
			try
			{
				string sQuery = "EXEC [CIMitar_Master].[dbo].[USP_RULESBL_GetDevicList]";
				result = this.queryCall(sQuery);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return result;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000E4B0 File Offset: 0x0000C6B0
		public void DelRule(int ruleID)
		{
			new DataSet();
			try
			{
				string sQuery = "EXEC [CIMitar_Master].[dbo].[USP_RULESBL_DelRule] @RULEID = '" + ruleID + "'";
				this.queryCall(sQuery);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000E504 File Offset: 0x0000C704
		public bool AddRules(RuleSBLItem rulesblitem)
		{
			if (this.sl_sbls_base == null)
			{
				this.sl_sbls_base = new SortedList();
			}
			if (this.sl_sbls_base.ContainsKey(rulesblitem._ruleID))
			{
				return false;
			}
			this.sl_sbls_base.Add(rulesblitem._ruleID, rulesblitem);
			return true;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000E556 File Offset: 0x0000C756
		private void textBox_keyword_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.cmdSearch_Click(null, null);
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000E56A File Offset: 0x0000C76A
		private void cmdSearch_Click(object sender, EventArgs e)
		{
			this.SetupBaseRules(this.textBox_keyword.Text.ToUpper());
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000E584 File Offset: 0x0000C784
		private void cmdAdd_Click(object sender, EventArgs e)
		{
			RULESBLDetailView rulesbldetailView = new RULESBLDetailView(this, this._refinfo);
			DialogResult dialogResult = rulesbldetailView.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this.cmdSearch_Click(null, null);
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000E5B4 File Offset: 0x0000C7B4
		private void cmdDelete_Click(object sender, EventArgs e)
		{
			if (this._selected_ruleSBLITEM != null)
			{
				DialogResult dialogResult = MessageBox.Show("do you want to delete sky : " + this._selected_ruleSBLITEM._skey + " ?", "delete RULS", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.sl_sbls_base.Remove(this._selected_ruleSBLITEM._ruleID);
					this.DelRule(this._selected_ruleSBLITEM._ruleID);
					this.SetGrid(this.sl_sbls_base);
				}
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000E62C File Offset: 0x0000C82C
		private void cmdExcel_Click(object sender, EventArgs e)
		{
			if (this.grid_rules.RowsCount > 1)
			{
				this.saveFileDialog.DefaultExt = ".xlsx";
				this.saveFileDialog.Filter = "Excel files|*.xlsx|CSV files|*.csv";
				this.saveFileDialog.FilterIndex = 1;
				this.saveFileDialog.FileName = string.Empty;
				DialogResult dialogResult = this.saveFileDialog.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					if (this.saveFileDialog.FilterIndex == 1)
					{
						ExcelControl.Save(this.saveFileDialog.FileName, this.grid_rules, true);
						return;
					}
					if (this.saveFileDialog.FilterIndex == 2)
					{
						ExcelControl.SaveCSV(this.saveFileDialog.FileName, this.grid_rules, this._cimitarUser._exeExcel);
						return;
					}
				}
			}
			else
			{
				MessageBox.Show("data is not exist ", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000E701 File Offset: 0x0000C901
		private void cmdSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000E71E File Offset: 0x0000C91E
		private void cmdSearch_MouseLeave(object sender, EventArgs e)
		{
			this.cmdSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000E73B File Offset: 0x0000C93B
		private void cmdSearch_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdSearch.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000E758 File Offset: 0x0000C958
		private void cmdSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000E765 File Offset: 0x0000C965
		private void cmdAdd_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdAdd.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000E782 File Offset: 0x0000C982
		private void cmdAdd_MouseLeave(object sender, EventArgs e)
		{
			this.cmdAdd.Image = Resources.TableAdd;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000E79F File Offset: 0x0000C99F
		private void cmdAdd_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdAdd.Image = Resources.TableAdd_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000E7BC File Offset: 0x0000C9BC
		private void cmdAdd_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000E7C9 File Offset: 0x0000C9C9
		private void cmdDelete_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdDelete.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000E7E6 File Offset: 0x0000C9E6
		private void cmdDelete_MouseLeave(object sender, EventArgs e)
		{
			this.cmdDelete.Image = Resources.TableRemove;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000E803 File Offset: 0x0000CA03
		private void cmdDelete_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdDelete.Image = Resources.TableRemove_Donw;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000E820 File Offset: 0x0000CA20
		private void cmdDelete_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000E82D File Offset: 0x0000CA2D
		private void cmdExcel_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000E84A File Offset: 0x0000CA4A
		private void cmdExcel_MouseLeave(object sender, EventArgs e)
		{
			this.cmdExcel.Image = Resources.SaveExcel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000E867 File Offset: 0x0000CA67
		private void cmdExcel_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdExcel.Image = Resources.SaveExcel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000E884 File Offset: 0x0000CA84
		private void cmdExcel_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x040000E4 RID: 228
		public string _factory = string.Empty;

		// Token: 0x040000E5 RID: 229
		private SortedList sl_sbls_base;

		// Token: 0x040000E6 RID: 230
		private RuleSBLItem _selected_ruleSBLITEM;

		// Token: 0x040000E7 RID: 231
		private RefInfo _refinfo;

		// Token: 0x040000E8 RID: 232
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x040000E9 RID: 233
		private bool isReadOnly;
	}
}
