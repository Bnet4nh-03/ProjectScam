using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using AlteraSocketView.View;
using Amkor.CADModules.BIBoardInfoModule.CIMitarAdminWS;
using Amkor.CADModules.BIBoardInfoModule.Class;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using CommonLibrary;
using DATA;
using DevAge.Drawing;
using ETC;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000023 RID: 35
	public partial class BIBoardSocketInfo : Form
	{
		// Token: 0x060000A9 RID: 169 RVA: 0x0000E86C File Offset: 0x0000CA6C
		public BIBoardSocketInfo()
		{
			this.InitializeComponent();
			this.Clear();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000E90C File Offset: 0x0000CB0C
		public BIBoardSocketInfo(CBIBoardInfo bibInfo, string userId, string url, BIBoardInfoModule instance)
		{
			this.InitializeComponent();
			this._webServiceUrl = url;
			this.Clear();
			this._cBIBoardInfo = bibInfo;
			this._instance = instance;
			this._iBibId = bibInfo.iId;
			this.l_bib_No.Text = bibInfo.strBibNo;
			this.l_device.Text = bibInfo.strDevice;
			this.l_customer.Text = bibInfo.strCustomer;
			this.l_location.Text = bibInfo.strLocation;
			this.l_barcode.Text = bibInfo.strBarcode;
			this.chk_AllSocket30W.Checked = (bibInfo.iAllSocket30w == 1);
			this.combo_BIBGoldTab.Items.Add("Good");
			this.combo_BIBGoldTab.Items.Add("Bad");
			this.combo_BIBGoldTab.SelectedIndex = this.combo_BIBGoldTab.FindString(bibInfo.strGoldTab);
			this.combo_Warranty.Items.Add("Under");
			this.combo_Warranty.Items.Add("Out Of");
			this.combo_Warranty.SelectedIndex = this.combo_Warranty.FindString(bibInfo.strWarranty);
			this.GetCntOfSock();
			foreach (string item in this._cntOfSockDesc.Split(new char[]
			{
				';'
			}))
			{
				this.combo_CntOfSock.Items.Add(item);
			}
			this.combo_CntOfSock.SelectedIndex = 0;
			this.combo_CntOfSock.Enabled = false;
			this.SetBadCheckBox(int.Parse(bibInfo.strBad_bib), bibInfo.iOnFlag);
			this._onFlag = bibInfo.iOnFlag;
			this._slSocketList = bibInfo.slSocketList;
			this._userId = userId;
			this.SetLocation();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000EB60 File Offset: 0x0000CD60
		public BIBoardSocketInfo(CBIBoardInfo bibInfo, string userId, string url, BIBoardInfoModule instance, bool isInsert)
		{
			this.InitializeComponent();
			this._webServiceUrl = url;
			this.Clear();
			this._cBIBoardInfo = bibInfo;
			this._instance = instance;
			this.GetCntOfSock();
			if (isInsert)
			{
				this._isInsert = isInsert;
				this.l_bib_No.Text = bibInfo.strBibNo;
				this.l_device.Text = bibInfo.strDevice;
				this.l_customer.Text = bibInfo.strCustomer;
				this.l_location.Text = bibInfo.strLocation;
				this.l_barcode.Text = bibInfo.strBarcode;
				this.combo_BIBGoldTab.Items.Add("Good");
				this.combo_BIBGoldTab.Items.Add("Bad");
				this.combo_BIBGoldTab.SelectedIndex = 0;
				this.combo_Warranty.Items.Add("Under");
				this.combo_Warranty.Items.Add("Out Of");
				this.combo_Warranty.SelectedIndex = 0;
				foreach (string item in this._cntOfSockDesc.Split(new char[]
				{
					';'
				}))
				{
					this.combo_CntOfSock.Items.Add(item);
				}
				this.combo_CntOfSock.SelectedIndex = 0;
				this.SetBadCheckBox(0, 0);
				this._onFlag = bibInfo.iOnFlag;
				this._slSocketList = bibInfo.slSocketList;
			}
			else
			{
				this.l_bib_No.Text = bibInfo.strBibNo;
				this.l_device.Text = bibInfo.strDevice;
				this.l_customer.Text = bibInfo.strCustomer;
				this.l_location.Text = bibInfo.strLocation;
				this.l_barcode.Text = bibInfo.strBarcode;
				this.combo_BIBGoldTab.Items.Add("Good");
				this.combo_BIBGoldTab.Items.Add("Bad");
				this.combo_BIBGoldTab.SelectedIndex = this.combo_BIBGoldTab.FindString(bibInfo.strGoldTab);
				this.combo_Warranty.Items.Add("Under");
				this.combo_Warranty.Items.Add("Out Of");
				this.combo_Warranty.SelectedIndex = this.combo_Warranty.FindString(bibInfo.strWarranty);
				foreach (string item2 in this._cntOfSockDesc.Split(new char[]
				{
					';'
				}))
				{
					this.combo_CntOfSock.Items.Add(item2);
				}
				this.combo_CntOfSock.SelectedIndex = this.combo_Warranty.FindString(bibInfo.cSocketInfos.Count.ToString());
				this.SetBadCheckBox(int.Parse(bibInfo.strBad_bib), bibInfo.iOnFlag);
				this._onFlag = bibInfo.iOnFlag;
				this._slSocketList = bibInfo.slSocketList;
			}
			this._userId = userId;
			this.SetLocation();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000EEE4 File Offset: 0x0000D0E4
		private void BIBoardSocketInfo_Load(object sender, EventArgs e)
		{
			this.InitGridCell();
			this._parsGrid = new CParsingGrid();
			this._cBadSocketStatuses = new List<CBadSocketStatus>();
			this._cGetData = new CGetData(this._webServiceUrl);
			this._csvControl = new CSVControl();
			this.ResetGrid(this.grid_Socket_Ovv);
			this.SetGridInfo_Ovv(this._slSocketList);
			this.ResetGrid(this.grid_Socket_Indv);
			this.SetGridInfo_Indv(this._slSocketList);
			if (this._onFlag == 1)
			{
				this.pb_Update.Enabled = true;
				this.pb_UpdatePM.Enabled = true;
				return;
			}
			this.pb_Update.Enabled = false;
			this.pb_UpdatePM.Enabled = false;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000055FE File Offset: 0x000037FE
		private void BIBoardSocketInfo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000EF94 File Offset: 0x0000D194
		private void pb_Search_Bdno_MouseUp(object sender, MouseEventArgs e)
		{
			this.Clear();
			string text = this.tb_biboardno.Text;
			if (text == "")
			{
				MessageBox.Show("Input BIBoard Number");
				return;
			}
			List<CBIBoardInfo> list = this._instance.GetBIBoardInfo_Insert(text);
			list = (from o in list
			where o.iOnFlag == 1
			select o).ToList<CBIBoardInfo>();
			if (list.Count > 1)
			{
				BIBoardInsert_SelectOne biboardInsert_SelectOne = new BIBoardInsert_SelectOne(list);
				biboardInsert_SelectOne.ShowDialog();
				if (biboardInsert_SelectOne.DialogResult == DialogResult.OK)
				{
					CBIBoardInfo selBibInfo = biboardInsert_SelectOne._selBibInfo;
					this.l_bib_No.Text = selBibInfo.strBibNo;
					this.l_device.Text = selBibInfo.strDevice;
					this.l_customer.Text = selBibInfo.strCustomer;
					this.l_location.Text = selBibInfo.strLocation;
					this.l_barcode.Text = selBibInfo.strBarcode;
					return;
				}
			}
			else
			{
				using (List<CBIBoardInfo>.Enumerator enumerator = list.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						CBIBoardInfo cbiboardInfo = enumerator.Current;
						this.l_bib_No.Text = cbiboardInfo.strBibNo;
						this.l_device.Text = cbiboardInfo.strDevice;
						this.l_customer.Text = cbiboardInfo.strCustomer;
						this.l_location.Text = cbiboardInfo.strLocation;
						this.l_barcode.Text = cbiboardInfo.strBarcode;
					}
				}
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000F11C File Offset: 0x0000D31C
		private void tb_biboardno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.Clear();
				string text = this.tb_biboardno.Text;
				if (text == "")
				{
					MessageBox.Show("Input BIBoard Number");
					return;
				}
				List<CBIBoardInfo> list = this._instance.GetBIBoardInfo_Insert(text);
				list = (from o in list
				where o.iOnFlag == 1
				select o).ToList<CBIBoardInfo>();
				if (list.Count > 1)
				{
					BIBoardInsert_SelectOne biboardInsert_SelectOne = new BIBoardInsert_SelectOne(list);
					biboardInsert_SelectOne.ShowDialog();
					if (biboardInsert_SelectOne.DialogResult == DialogResult.OK)
					{
						CBIBoardInfo selBibInfo = biboardInsert_SelectOne._selBibInfo;
						this.l_bib_No.Text = selBibInfo.strBibNo;
						this.l_device.Text = selBibInfo.strDevice;
						this.l_customer.Text = selBibInfo.strCustomer;
						this.l_location.Text = selBibInfo.strLocation;
						this.l_barcode.Text = selBibInfo.strBarcode;
						return;
					}
				}
				else
				{
					using (List<CBIBoardInfo>.Enumerator enumerator = list.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							CBIBoardInfo cbiboardInfo = enumerator.Current;
							this.l_bib_No.Text = cbiboardInfo.strBibNo;
							this.l_device.Text = cbiboardInfo.strDevice;
							this.l_customer.Text = cbiboardInfo.strCustomer;
							this.l_location.Text = cbiboardInfo.strLocation;
							this.l_barcode.Text = cbiboardInfo.strBarcode;
						}
					}
				}
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000F2B4 File Offset: 0x0000D4B4
		private void pb_excel_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_excel.Image = Resources.SaveExcel_Down;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000F2C8 File Offset: 0x0000D4C8
		private void pb_excel_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				this.pb_excel.Image = Resources.SaveExcel;
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
					DataTable dt = this._parsGrid.ParseGrid_Ovv(this._slSocketList.Count, this.grid_Socket_Ovv);
					new CSVControl().generateCSV(filename, dt);
					MessageBox.Show("Success to Save CSV");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("pb_excel_MouseUp: " + ex.Message);
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000F38C File Offset: 0x0000D58C
		private void pb_excel_MouseHover(object sender, EventArgs e)
		{
			new ToolTip().SetToolTip(this.pb_excel, "Save *.csv");
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000F3A3 File Offset: 0x0000D5A3
		private void pb_Update_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave_Down;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000F3B8 File Offset: 0x0000D5B8
		private void pb_Update_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave;
			string text;
			if (this._instance._factorySetting._factoryName == "ATV")
			{
				text = this._parsGrid.ParseGrid_Indv3_(this._slSocketList.Count - 1, this.grid_Socket_Indv, this._cBadSocketStatuses, 1);
			}
			else
			{
				text = this._parsGrid.ParseGrid_Indv3_(this._slSocketList.Count - 1, this.grid_Socket_Indv, this._cBadSocketStatuses, 0);
			}
			if (text == "")
			{
				MessageBox.Show("Input Integer only");
				return;
			}
			int num;
			if (this.chk_BadBIB.Checked)
			{
				num = 1;
			}
			else
			{
				num = 0;
			}
			CBIBoardInfo cbiboardInfo = new CBIBoardInfo();
			cbiboardInfo.strBibNo = this.l_bib_No.Text;
			cbiboardInfo.strUserId = this._userId;
			cbiboardInfo.strBad_bib = num.ToString();
			cbiboardInfo.strBarcode = this.l_barcode.Text;
			cbiboardInfo.strGoldTab = this.combo_BIBGoldTab.Text;
			cbiboardInfo.strWarranty = this.combo_Warranty.Text;
			cbiboardInfo.iAllSocket30w = (this.chk_AllSocket30W.Checked ? 1 : 0);
			CheckBadgeNo checkBadgeNo;
			if (!this._isInsert)
			{
				checkBadgeNo = new CheckBadgeNo(BIBoardInfoModule._instance._cimitarUser._badgeNo, this._cBIBoardInfo.strComment, true);
			}
			else
			{
				checkBadgeNo = new CheckBadgeNo(BIBoardInfoModule._instance._cimitarUser._badgeNo);
			}
			checkBadgeNo.ShowDialog();
			string empty = string.Empty;
			string comment = string.Empty;
			if (checkBadgeNo.DialogResult == DialogResult.OK)
			{
				string badgeNo = checkBadgeNo._badgeNo;
				comment = checkBadgeNo._comment;
				BIBoardInfoModule._instance.SetBIBoardInfo(cbiboardInfo, text, comment);
				this.CopyFile(cbiboardInfo);
				base.DialogResult = DialogResult.OK;
				base.Close();
				base.DialogResult = DialogResult.OK;
				base.Dispose();
				return;
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000F587 File Offset: 0x0000D787
		private void pb_UpdatePM_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_UpdatePM.Image = Resources.TableSave_Down;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000F59C File Offset: 0x0000D79C
		private void pb_UpdatePM_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_UpdatePM.Image = Resources.TableSave;
			if (this._iBibId == 0)
			{
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
				this.UpdatePM(this._iBibId, badgeNo, comment);
				this.CopyFile(new CBIBoardInfo
				{
					strBibNo = this.l_bib_No.Text,
					strUserId = this._userId,
					strBarcode = this.l_barcode.Text
				});
				base.DialogResult = DialogResult.OK;
				base.Close();
				return;
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000F64C File Offset: 0x0000D84C
		private void InitGridCell()
		{
			Color color = Color.FromArgb(255, 255, 255);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			this.cell_center = new SourceGrid.Cells.Views.Cell();
			this.cell_center.BackColor = color;
			this.cell_center.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center.Border = rectangleBorder;
			this.cell_center.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center.ImageStretch = false;
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
			this.cell_row1.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row1.ImageStretch = false;
			Color color9 = Color.FromArgb(255, 234, 167);
			RectangleBorder rectangleBorder9 = new RectangleBorder(new BorderLine(color9), new BorderLine(color9));
			this.cell_row2 = new SourceGrid.Cells.Views.Cell();
			this.cell_row2.BackColor = color9;
			this.cell_row2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row2.Border = rectangleBorder9;
			this.cell_row2.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row2.ImageStretch = false;
			this._checkBox = new CheckBoxBackColorAlternate(color, color);
			this._checkBox.Border = rectangleBorder;
			Color color10 = Color.FromArgb(39, 174, 96);
			RectangleBorder rectangleBorder10 = new RectangleBorder(new BorderLine(color10), new BorderLine(color10));
			this.cell_good = new SourceGrid.Cells.Views.Cell();
			this.cell_good.BackColor = color10;
			this.cell_good.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_good.Border = rectangleBorder10;
			this.cell_good.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_good.ImageStretch = false;
			this.cell_good.ForeColor = Color.White;
			Color red = Color.Red;
			RectangleBorder rectangleBorder11 = new RectangleBorder(new BorderLine(red), new BorderLine(red));
			this.cell_bad = new SourceGrid.Cells.Views.Cell();
			this.cell_bad.BackColor = red;
			this.cell_bad.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_bad.Border = rectangleBorder11;
			this.cell_bad.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_bad.ImageStretch = false;
			this.cell_bad.ForeColor = Color.White;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000FB20 File Offset: 0x0000DD20
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

		// Token: 0x060000B9 RID: 185 RVA: 0x0000FB68 File Offset: 0x0000DD68
		private void SetHeaderInfo(string[] gridHeaders, Grid grid)
		{
			grid.ColumnsCount = gridHeaders.Length;
			grid.FixedRows = 1;
			grid.FixedColumns = 1;
			grid.Rows.Insert(0);
			for (int i = 0; i < gridHeaders.Length; i++)
			{
				grid[0, i] = new SourceGrid.Cells.ColumnHeader(gridHeaders[i]);
				grid[0, i].View = this.cell_header1;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000FBCC File Offset: 0x0000DDCC
		private void SetGridInfo_Ovv(SortedList slSocketList)
		{
			int count = slSocketList.Count;
			string text = "TYPE";
			foreach (object obj in slSocketList)
			{
				int num = int.Parse(((DictionaryEntry)obj).Key.ToString());
				if (num == 1000)
				{
					text += ",Other ";
				}
				else
				{
					text = text + ",Socket " + num.ToString();
				}
			}
			string[] gridHeaders = text.Split(new char[]
			{
				','
			});
			this.SetHeaderInfo(gridHeaders, this.grid_Socket_Ovv);
			for (int i = 1; i <= 13; i++)
			{
				this.grid_Socket_Ovv.Rows.Insert(i);
			}
			this.grid_Socket_Ovv[this._iMissingCap, 0] = new SourceGrid.Cells.Cell("MISSING CAP");
			this.grid_Socket_Ovv[this._iMissingResistor, 0] = new SourceGrid.Cells.Cell("MISSING RESISTOR");
			this.grid_Socket_Ovv[this._iMissingIc, 0] = new SourceGrid.Cells.Cell("MISSING IC");
			this.grid_Socket_Ovv[this._iDamageCap, 0] = new SourceGrid.Cells.Cell("DAMAGE CAP");
			this.grid_Socket_Ovv[this._iDamageResistor, 0] = new SourceGrid.Cells.Cell("DAMAGE RESISTOR");
			this.grid_Socket_Ovv[this._iDamageIc, 0] = new SourceGrid.Cells.Cell("DAMAGE IC");
			this.grid_Socket_Ovv[this._iBadSocket, 0] = new SourceGrid.Cells.Cell("BAD SOCKET");
			this.grid_Socket_Ovv[this._iDmgSockHousing, 0] = new SourceGrid.Cells.Cell("DMG SOCK HOUSING");
			this.grid_Socket_Ovv[this._iCoverSprDegrad, 0] = new SourceGrid.Cells.Cell("COVER SPR DEGRAD");
			this.grid_Socket_Ovv[this._iHeaterCable, 0] = new SourceGrid.Cells.Cell("HEATER CABLE");
			this.grid_Socket_Ovv[this._iDterCardSetCond, 0] = new SourceGrid.Cells.Cell("DTER CARD SET COND");
			this.grid_Socket_Ovv[this._iFuncTest, 0] = new SourceGrid.Cells.Cell("FUNC TEST");
			this.grid_Socket_Ovv[this._iRemark, 0] = new SourceGrid.Cells.Cell("REMARK");
			try
			{
				if (slSocketList.Count != 0)
				{
					int num2 = 0;
					foreach (object obj2 in slSocketList)
					{
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj2;
						int num3 = int.Parse(dictionaryEntry.Key.ToString());
						foreach (object obj3 in ((SortedList)dictionaryEntry.Value))
						{
							CBIBoardSocketInfo cbiboardSocketInfo = (CBIBoardSocketInfo)((DictionaryEntry)obj3).Value;
							this.grid_Socket_Ovv[this._iMissingCap, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strCap_Miss);
							this.grid_Socket_Ovv[this._iMissingResistor, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strResistor_Miss);
							this.grid_Socket_Ovv[this._iMissingIc, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strIc_Miss);
							this.grid_Socket_Ovv[this._iDamageCap, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strCap_Dmg);
							this.grid_Socket_Ovv[this._iDamageResistor, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strResistor_Dmg);
							this.grid_Socket_Ovv[this._iDamageIc, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strIc_Dmg);
							this.grid_Socket_Ovv[this._iBadSocket, num2 + 1] = new SourceGrid.Cells.Cell("");
							if (cbiboardSocketInfo.strBad_sock != "0")
							{
								this.grid_Socket_Ovv[this._iBadSocket, num2 + 1].Image = Resources.check;
							}
							this.grid_Socket_Ovv[this._iDmgSockHousing, num2 + 1] = new SourceGrid.Cells.Cell("");
							if (cbiboardSocketInfo.strDmgSockHousing != "0")
							{
								this.grid_Socket_Ovv[this._iDmgSockHousing, num2 + 1].Image = Resources.check;
							}
							this.grid_Socket_Ovv[this._iCoverSprDegrad, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strCoverSprDegrad);
							this.grid_Socket_Ovv[this._iHeaterCable, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strHeaterCable);
							this.grid_Socket_Ovv[this._iDterCardSetCond, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strDterCardSetCond);
							this.grid_Socket_Ovv[this._iFuncTest, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strFuncTest);
							this.grid_Socket_Ovv[this._iRemark, num2 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strRemark);
							if (num3 == 1000)
							{
								this.grid_Socket_Ovv[this._iCoverSprDegrad, num2 + 1] = new SourceGrid.Cells.Cell("");
								this.grid_Socket_Ovv[this._iHeaterCable, num2 + 1] = new SourceGrid.Cells.Cell("");
								this.grid_Socket_Ovv[this._iDterCardSetCond, num2 + 1] = new SourceGrid.Cells.Cell("");
								this.grid_Socket_Ovv[this._iFuncTest, num2 + 1] = new SourceGrid.Cells.Cell("");
							}
						}
						num2++;
					}
				}
				for (int j = 1; j < this.grid_Socket_Ovv.Rows.Count; j++)
				{
					for (int k = 0; k < this.grid_Socket_Ovv.Columns.Count; k++)
					{
						if (j % 2 != 0)
						{
							this.grid_Socket_Ovv[j, k].View = this.cell_row1;
						}
						else
						{
							this.grid_Socket_Ovv[j, k].View = this.cell_row2;
						}
					}
				}
				this.grid_Socket_Ovv.AutoSizeCells();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00010248 File Offset: 0x0000E448
		private void SetGridInfo_Indv(SortedList slSocketList)
		{
			this._cBadSocketStatuses.Clear();
			int count = slSocketList.Count;
			int num = 4;
			int num2 = 12;
			int num3 = num * num2 + 1;
			int num4 = 4;
			int num5 = (count / num + 1) * num4;
			this.grid_Socket_Indv.ColumnsCount = num5;
			this.grid_Socket_Indv.FixedRows = 1;
			this.grid_Socket_Indv.FixedColumns = 0;
			this.grid_Socket_Indv.Rows.Insert(0);
			for (int i = 0; i < num5; i++)
			{
				this.grid_Socket_Indv[0, i] = new SourceGrid.Cells.ColumnHeader("");
			}
			for (int j = 1; j <= num3; j++)
			{
				this.grid_Socket_Indv.Rows.Insert(j);
			}
			int num6 = 1;
			int num7 = 0;
			foreach (object obj in this._slSocketList)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				int iSockNo = int.Parse(dictionaryEntry.Key.ToString());
				string cellValue = string.Empty;
				if (iSockNo == 1000)
				{
					cellValue = "Other";
				}
				else
				{
					cellValue = "Socket " + iSockNo.ToString();
				}
				this.grid_Socket_Indv[num6, num7] = new SourceGrid.Cells.Cell(cellValue);
				this.grid_Socket_Indv[num6, num7].View = this.cell_header1;
				this.grid_Socket_Indv[num6, num7].ColumnSpan = 3;
				this.grid_Socket_Indv[num6 + 1, num7] = new SourceGrid.Cells.Cell("");
				this.grid_Socket_Indv[num6 + 1, num7].View = this.cell_header2;
				this.grid_Socket_Indv[num6 + 1, num7 + 1] = new SourceGrid.Cells.Cell("MISSING");
				this.grid_Socket_Indv[num6 + 1, num7 + 1].View = this.cell_header2;
				this.grid_Socket_Indv[num6 + 1, num7 + 2] = new SourceGrid.Cells.Cell("DAMAGE");
				this.grid_Socket_Indv[num6 + 1, num7 + 2].View = this.cell_header2;
				this.grid_Socket_Indv[num6 + 2, num7] = new SourceGrid.Cells.Cell("CAP");
				this.grid_Socket_Indv[num6 + 2, num7].View = this.cell_header3;
				this.grid_Socket_Indv[num6 + 3, num7] = new SourceGrid.Cells.Cell("RESISTOR");
				this.grid_Socket_Indv[num6 + 3, num7].View = this.cell_header3;
				this.grid_Socket_Indv[num6 + 4, num7] = new SourceGrid.Cells.Cell("IC");
				this.grid_Socket_Indv[num6 + 4, num7].View = this.cell_header3;
				CustomEvents customEvents = new CustomEvents();
				customEvents.Click += this.BadSocketStatus_Click;
				this.grid_Socket_Indv[num6 + 5, num7] = new SourceGrid.Cells.Cell("BAD SOCKET");
				this.grid_Socket_Indv[num6 + 5, num7].View = this.cell_header3;
				this.grid_Socket_Indv[num6 + 5, num7].AddController(customEvents);
				this.grid_Socket_Indv[num6 + 6, num7] = new SourceGrid.Cells.Cell("DMG SOCK HOUSIN");
				this.grid_Socket_Indv[num6 + 6, num7].View = this.cell_header3;
				this.grid_Socket_Indv[num6 + 7, num7] = new SourceGrid.Cells.Cell("COVER SPR DEGRAD");
				this.grid_Socket_Indv[num6 + 7, num7].View = this.cell_header3;
				this.grid_Socket_Indv[num6 + 8, num7] = new SourceGrid.Cells.Cell("HEATER CABLE");
				this.grid_Socket_Indv[num6 + 8, num7].View = this.cell_header3;
				this.grid_Socket_Indv[num6 + 9, num7] = new SourceGrid.Cells.Cell("D CARD SET COND");
				this.grid_Socket_Indv[num6 + 9, num7].View = this.cell_header3;
				this.grid_Socket_Indv[num6 + 10, num7] = new SourceGrid.Cells.Cell("FUNC TEST");
				this.grid_Socket_Indv[num6 + 10, num7].View = this.cell_header3;
				this.grid_Socket_Indv[num6 + 11, num7] = new SourceGrid.Cells.Cell("REMARK");
				this.grid_Socket_Indv[num6 + 11, num7].View = this.cell_header3;
				Predicate<CBadSocketStatus> <>9__0;
				Predicate<CBadSocketStatus> <>9__1;
				foreach (object obj2 in ((SortedList)dictionaryEntry.Value))
				{
					CBIBoardSocketInfo cbiboardSocketInfo = (CBIBoardSocketInfo)((DictionaryEntry)obj2).Value;
					if (this._onFlag == 0)
					{
						this.grid_Socket_Indv[num6 + 2, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strCap_Miss);
						this.grid_Socket_Indv[num6 + 3, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strResistor_Miss);
						this.grid_Socket_Indv[num6 + 4, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strIc_Miss);
						this.grid_Socket_Indv[num6 + 2, num7 + 2] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strCap_Dmg);
						this.grid_Socket_Indv[num6 + 3, num7 + 2] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strResistor_Dmg);
						this.grid_Socket_Indv[num6 + 4, num7 + 2] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strIc_Dmg);
					}
					else
					{
						this.grid_Socket_Indv[num6 + 2, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strCap_Miss, typeof(string));
						this.grid_Socket_Indv[num6 + 3, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strResistor_Miss, typeof(string));
						this.grid_Socket_Indv[num6 + 4, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strIc_Miss, typeof(string));
						this.grid_Socket_Indv[num6 + 2, num7 + 2] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strCap_Dmg, typeof(string));
						this.grid_Socket_Indv[num6 + 3, num7 + 2] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strResistor_Dmg, typeof(string));
						this.grid_Socket_Indv[num6 + 4, num7 + 2] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strIc_Dmg, typeof(string));
					}
					this.grid_Socket_Indv[num6 + 2, num7 + 1].View = this.cell_center;
					this.grid_Socket_Indv[num6 + 3, num7 + 1].View = this.cell_center;
					this.grid_Socket_Indv[num6 + 4, num7 + 1].View = this.cell_center;
					this.grid_Socket_Indv[num6 + 2, num7 + 2].View = this.cell_center;
					this.grid_Socket_Indv[num6 + 3, num7 + 2].View = this.cell_center;
					this.grid_Socket_Indv[num6 + 4, num7 + 2].View = this.cell_center;
					if (this._onFlag == 0)
					{
						if (cbiboardSocketInfo.strBad_sock == "0")
						{
							this.grid_Socket_Indv[num6 + 5, num7 + 1] = new SourceGrid.Cells.Cell("");
						}
						else
						{
							this.grid_Socket_Indv[num6 + 5, num7 + 1] = new SourceGrid.Cells.Cell("");
							this.grid_Socket_Indv[num6 + 5, num7 + 1].Image = Resources.check;
							List<CBadSocketStatus> cBadSocketStatuses = this._cBadSocketStatuses;
							Predicate<CBadSocketStatus> match;
							if ((match = <>9__0) == null)
							{
								match = (<>9__0 = ((CBadSocketStatus o) => o.iSocketNo == iSockNo));
							}
							if (!cBadSocketStatuses.Exists(match))
							{
								CBadSocketStatus cbadSocketStatus = new CBadSocketStatus();
								cbadSocketStatus.iSocketNo = iSockNo;
								cbadSocketStatus.strBadSocketStatus = cbiboardSocketInfo.strBadSocketStatus;
								this._cBadSocketStatuses.Add(cbadSocketStatus);
							}
						}
						this.grid_Socket_Indv[num6 + 7, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strCoverSprDegrad);
						this.grid_Socket_Indv[num6 + 8, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strHeaterCable);
						this.grid_Socket_Indv[num6 + 9, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strDterCardSetCond);
						this.grid_Socket_Indv[num6 + 10, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strCoverSprDegrad);
						if (cbiboardSocketInfo.strDmgSockHousing == "0")
						{
							this.grid_Socket_Indv[num6 + 6, num7 + 1] = new SourceGrid.Cells.Cell("");
						}
						else
						{
							this.grid_Socket_Indv[num6 + 6, num7 + 1] = new SourceGrid.Cells.Cell("");
							this.grid_Socket_Indv[num6 + 6, num7 + 1].Image = Resources.check;
						}
						this.grid_Socket_Indv[num6 + 11, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strRemark);
						for (int k = 0; k < 7; k++)
						{
							this.grid_Socket_Indv[num6 + 5 + k, num7 + 1].View = this.cell_center;
						}
					}
					else
					{
						CustomEvents customEvents2 = new CustomEvents();
						customEvents2.Click += this.BadSocketCheck_Click;
						if (cbiboardSocketInfo.strBad_sock == "0")
						{
							this.grid_Socket_Indv[num6 + 5, num7 + 1] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
						}
						else
						{
							this.grid_Socket_Indv[num6 + 5, num7 + 1] = new SourceGrid.Cells.CheckBox(null, new bool?(true));
							List<CBadSocketStatus> cBadSocketStatuses2 = this._cBadSocketStatuses;
							Predicate<CBadSocketStatus> match2;
							if ((match2 = <>9__1) == null)
							{
								match2 = (<>9__1 = ((CBadSocketStatus o) => o.iSocketNo == iSockNo));
							}
							if (!cBadSocketStatuses2.Exists(match2))
							{
								CBadSocketStatus cbadSocketStatus2 = new CBadSocketStatus();
								cbadSocketStatus2.iSocketNo = iSockNo;
								cbadSocketStatus2.strBadSocketStatus = cbiboardSocketInfo.strBadSocketStatus;
								this._cBadSocketStatuses.Add(cbadSocketStatus2);
							}
						}
						this.grid_Socket_Indv[num6 + 5, num7 + 1].AddController(customEvents2);
						if (cbiboardSocketInfo.strDmgSockHousing == "0")
						{
							this.grid_Socket_Indv[num6 + 6, num7 + 1] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
						}
						else
						{
							this.grid_Socket_Indv[num6 + 6, num7 + 1] = new SourceGrid.Cells.CheckBox(null, new bool?(true));
						}
						for (int k = 0; k < 2; k++)
						{
							this.grid_Socket_Indv[num6 + 5 + k, num7 + 1].View = this._checkBox;
						}
						SourceGrid.Cells.Controllers.Button button = new SourceGrid.Cells.Controllers.Button();
						button.Executed += this.CellButton_Click;
						this.grid_Socket_Indv[num6 + 7, num7 + 1] = new SourceGrid.Cells.Button(cbiboardSocketInfo.strCoverSprDegrad);
						this.grid_Socket_Indv[num6 + 7, num7 + 1].Controller.AddController(button);
						if (cbiboardSocketInfo.strCoverSprDegrad == "Good")
						{
							this.grid_Socket_Indv[num6 + 7, num7 + 1].View = this.cell_good;
						}
						else
						{
							this.grid_Socket_Indv[num6 + 7, num7 + 1].View = this.cell_bad;
						}
						this.grid_Socket_Indv[num6 + 8, num7 + 1] = new SourceGrid.Cells.Button(cbiboardSocketInfo.strHeaterCable);
						this.grid_Socket_Indv[num6 + 8, num7 + 1].Controller.AddController(button);
						if (cbiboardSocketInfo.strHeaterCable == "Good")
						{
							this.grid_Socket_Indv[num6 + 8, num7 + 1].View = this.cell_good;
						}
						else
						{
							this.grid_Socket_Indv[num6 + 8, num7 + 1].View = this.cell_bad;
						}
						this.grid_Socket_Indv[num6 + 9, num7 + 1] = new SourceGrid.Cells.Button(cbiboardSocketInfo.strDterCardSetCond);
						this.grid_Socket_Indv[num6 + 9, num7 + 1].Controller.AddController(button);
						if (cbiboardSocketInfo.strDterCardSetCond == "Good")
						{
							this.grid_Socket_Indv[num6 + 9, num7 + 1].View = this.cell_good;
						}
						else
						{
							this.grid_Socket_Indv[num6 + 9, num7 + 1].View = this.cell_bad;
						}
						this.grid_Socket_Indv[num6 + 10, num7 + 1] = new SourceGrid.Cells.Button(cbiboardSocketInfo.strFuncTest);
						this.grid_Socket_Indv[num6 + 10, num7 + 1].Controller.AddController(button);
						if (cbiboardSocketInfo.strFuncTest == "Good")
						{
							this.grid_Socket_Indv[num6 + 10, num7 + 1].View = this.cell_good;
						}
						else
						{
							this.grid_Socket_Indv[num6 + 10, num7 + 1].View = this.cell_bad;
						}
						this.grid_Socket_Indv[num6 + 11, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strRemark, typeof(string));
						this.grid_Socket_Indv[num6 + 11, num7 + 1].View = this.cell_center;
						if (iSockNo == 1000)
						{
							for (int k = 0; k < 6; k++)
							{
								this.grid_Socket_Indv[num6 + 5 + k, num7 + 1] = new SourceGrid.Cells.Cell("");
								this.grid_Socket_Indv[num6 + 5 + k, num7 + 1].View = this.cell_center;
							}
							this.grid_Socket_Indv[num6 + 11, num7 + 1] = new SourceGrid.Cells.Cell(cbiboardSocketInfo.strRemark, typeof(string));
							this.grid_Socket_Indv[num6 + 11, num7 + 1].View = this.cell_center;
						}
					}
					for (int k = 0; k < 7; k++)
					{
						this.grid_Socket_Indv[num6 + 5 + k, num7 + 1].ColumnSpan = 2;
					}
				}
				num6 += num2;
				if (num6 > num2 * num - 1)
				{
					num6 = 1;
					num7 += num4;
				}
			}
			this.grid_Socket_Indv.AutoSizeCells();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00011118 File Offset: 0x0000F318
		private void CellButton_Click(object sender, EventArgs e)
		{
			SourceGrid.Cells.Button button = (SourceGrid.Cells.Button)((CellContext)sender).Cell;
			if (button.Value.ToString() == "Good")
			{
				button.Value = "Bad";
				button.View = this.cell_bad;
				return;
			}
			button.Value = "Good";
			button.View = this.cell_good;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0001117C File Offset: 0x0000F37C
		private void BadSocketCheck_Click(object sender, EventArgs e)
		{
			if (this._isInsert)
			{
				return;
			}
			CellContext cellContext = (CellContext)sender;
			int row = cellContext.Position.Row;
			int column = cellContext.Position.Column;
			string text = this.grid_Socket_Indv[row - 5, column].ToString();
			bool flag = bool.Parse(this.grid_Socket_Indv[row, column].ToString());
			if (text.IndexOf("OTHER") != -1)
			{
				return;
			}
			int iSocketNo = int.Parse(text.Split(new char[]
			{
				' '
			})[1]);
			if (flag)
			{
				CAddCategory caddCategory = new CAddCategory(this._instance._alCategory_SocketStatus);
				caddCategory.ShowDialog();
				if (caddCategory.DialogResult != DialogResult.OK)
				{
					this.grid_Socket_Indv[row, column].Value = false;
					return;
				}
				string selectedCategory = caddCategory._selectedCategory;
				if (!string.IsNullOrEmpty(selectedCategory))
				{
					CBadSocketStatus cbadSocketStatus = new CBadSocketStatus();
					cbadSocketStatus.iSocketNo = iSocketNo;
					cbadSocketStatus.strBadSocketStatus = selectedCategory;
					this._cBadSocketStatuses.Add(cbadSocketStatus);
					return;
				}
			}
			else
			{
				this._cBadSocketStatuses.Remove(this._cBadSocketStatuses.FirstOrDefault((CBadSocketStatus o) => o.iSocketNo == iSocketNo));
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000112B8 File Offset: 0x0000F4B8
		private void BadSocketStatus_Click(object sender, EventArgs e)
		{
			if (this._isInsert)
			{
				return;
			}
			CellContext cellContext = (CellContext)sender;
			int row = cellContext.Position.Row;
			int column = cellContext.Position.Column;
			string text = this.grid_Socket_Indv[row - 5, column].ToString();
			if (text.IndexOf("OTHER") != -1)
			{
				return;
			}
			int iSocketNo = int.Parse(text.Split(new char[]
			{
				' '
			})[1]);
			List<CBadSocketStatus> list = (from o in this._cBadSocketStatuses
			where o.iSocketNo == iSocketNo
			select o).ToList<CBadSocketStatus>();
			if (list.Count == 0)
			{
				return;
			}
			MessageBox.Show("Bad Socket Status: " + list[0].strBadSocketStatus);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00011380 File Offset: 0x0000F580
		private void combo_CntOfSock_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.combo_CntOfSock.SelectedItem == null)
			{
				return;
			}
			int cntOfSock = int.Parse(this.combo_CntOfSock.SelectedItem.ToString());
			this._instance.GetBIBoardSocketInfo_Insert(this._cBIBoardInfo, cntOfSock);
			this._slSocketList = this._cBIBoardInfo.slSocketList;
			this.ResetGrid(this.grid_Socket_Ovv);
			this.SetGridInfo_Ovv(this._slSocketList);
			this.ResetGrid(this.grid_Socket_Indv);
			this.SetGridInfo_Indv(this._slSocketList);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00011404 File Offset: 0x0000F604
		private void SetLocation()
		{
			if (this._isInsert)
			{
				this.tabCtrl_SockInfo.SelectedIndex = 1;
				return;
			}
			int num = 79;
			this.group_Info.Location = new Point(this.group_Info.Location.X, this.group_Info.Location.Y - num);
			this.group_Update.Location = new Point(this.group_Update.Location.X, this.group_Update.Location.Y - num);
			this.group_Export.Location = new Point(this.group_Export.Location.X, this.group_Export.Location.Y - num);
			this.group_PM.Location = new Point(this.group_PM.Location.X, this.group_PM.Location.Y - num);
			this.tabCtrl_SockInfo.Location = new Point(this.tabCtrl_SockInfo.Location.X, this.tabCtrl_SockInfo.Location.Y - num);
			this.tabCtrl_SockInfo.Height += num;
			this.group_Search.Visible = false;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00011560 File Offset: 0x0000F760
		private void SetBadCheckBox(int badFlag, int onFlag)
		{
			if (badFlag != 0)
			{
				this.chk_BadBIB.Checked = true;
			}
			else
			{
				this.chk_BadBIB.Checked = false;
			}
			if (onFlag == 0)
			{
				this.chk_BadBIB.Enabled = false;
				return;
			}
			this.chk_BadBIB.Enabled = true;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0001159C File Offset: 0x0000F79C
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
					"', @comment = 'N",
					comment,
					"'"
				});
				dataSet = this.QueryCall(sQuery);
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

		// Token: 0x060000C3 RID: 195 RVA: 0x00011744 File Offset: 0x0000F944
		private void GetCntOfSock()
		{
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'GET_SOCK_CNT'";
			dataSet = this.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this._cntOfSockDesc = dataSet.Tables[0].Rows[i]["cnt_of_sock"].ToString();
				}
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000117DC File Offset: 0x0000F9DC
		private void CopyFile(CBIBoardInfo bibInfo)
		{
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Group] @flag = 'COPY_INFO'";
			dataSet = this.QueryCall(sQuery);
			string str = string.Empty;
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					str = dataSet.Tables[0].Rows[i]["file_dest"].ToString();
				}
			}
			CBIBoardInfo cbiboardInfo = (CBIBoardInfo)this._cGetData.GetBIBoardSocketInfo_One(bibInfo.strBibNo)[bibInfo.strBarcode];
			DataTable dataTSocket = cbiboardInfo.dataTSocket;
			string text = Environment.CurrentDirectory + "\\PM_Info\\";
			if (Directory.Exists(text))
			{
				if (Directory.GetFiles(text).Length != 0)
				{
					Directory.Delete(text, true);
				}
				Directory.CreateDirectory(text);
			}
			else
			{
				Directory.CreateDirectory(text);
			}
			string text2 = string.Empty;
			text2 = text + cbiboardInfo.strBibNo.Substring(1, cbiboardInfo.strBibNo.Length - 1) + ".csv";
			if (this._csvControl.generateCSV(text2, dataTSocket))
			{
				string destFileName = str + cbiboardInfo.strBibNo.Substring(1, cbiboardInfo.strBibNo.Length - 1) + ".csv";
				try
				{
					this._barPrograss = new BarPrograss();
					this._barPrograss.progress_labelheader_set("Copy..");
					this._barPrograss.setMax(100);
					this._barPrograss.setValue(100);
					this._thread = new Thread(new ThreadStart(this.BarPrograssView));
					this._thread.Start();
					File.Copy(text2, destFileName, true);
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					Thread.Sleep(100);
					if (this._barPrograss != null)
					{
						this._barPrograss._ischeck = true;
					}
					this._barPrograss = null;
				}
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00011A0C File Offset: 0x0000FC0C
		private DataSet QueryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._webServiceUrl + "CIMitarWebService/CIMitarWS.asmx";
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

		// Token: 0x060000C6 RID: 198 RVA: 0x00011A78 File Offset: 0x0000FC78
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00011A88 File Offset: 0x0000FC88
		private void Clear()
		{
			this.l_bib_No.Text = "";
			this.l_device.Text = "";
			this.l_customer.Text = "";
			this.l_location.Text = "";
			this.l_barcode.Text = "";
		}

		// Token: 0x04000144 RID: 324
		private BarPrograss _barPrograss;

		// Token: 0x04000145 RID: 325
		private Thread _thread;

		// Token: 0x04000146 RID: 326
		private SourceGrid.Cells.Views.Cell cell_center;

		// Token: 0x04000147 RID: 327
		private SourceGrid.Cells.Views.Cell cell_good;

		// Token: 0x04000148 RID: 328
		private SourceGrid.Cells.Views.Cell cell_bad;

		// Token: 0x04000149 RID: 329
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x0400014A RID: 330
		private SourceGrid.Cells.Views.Cell cell_header2;

		// Token: 0x0400014B RID: 331
		private SourceGrid.Cells.Views.Cell cell_header3;

		// Token: 0x0400014C RID: 332
		private SourceGrid.Cells.Views.Cell cell_body1;

		// Token: 0x0400014D RID: 333
		private SourceGrid.Cells.Views.Cell cell_body2;

		// Token: 0x0400014E RID: 334
		private SourceGrid.Cells.Views.Cell cell_onflag;

		// Token: 0x0400014F RID: 335
		private SourceGrid.Cells.Views.Cell cell_row1;

		// Token: 0x04000150 RID: 336
		private SourceGrid.Cells.Views.Cell cell_row2;

		// Token: 0x04000151 RID: 337
		public CheckBoxBackColorAlternate _checkBox;

		// Token: 0x04000152 RID: 338
		private int _iMissingCap = 1;

		// Token: 0x04000153 RID: 339
		private int _iMissingResistor = 2;

		// Token: 0x04000154 RID: 340
		private int _iMissingIc = 3;

		// Token: 0x04000155 RID: 341
		private int _iDamageCap = 4;

		// Token: 0x04000156 RID: 342
		private int _iDamageResistor = 5;

		// Token: 0x04000157 RID: 343
		private int _iDamageIc = 6;

		// Token: 0x04000158 RID: 344
		private int _iBadSocket = 7;

		// Token: 0x04000159 RID: 345
		private int _iDmgSockHousing = 8;

		// Token: 0x0400015A RID: 346
		private int _iCoverSprDegrad = 9;

		// Token: 0x0400015B RID: 347
		private int _iHeaterCable = 10;

		// Token: 0x0400015C RID: 348
		private int _iDterCardSetCond = 11;

		// Token: 0x0400015D RID: 349
		private int _iFuncTest = 12;

		// Token: 0x0400015E RID: 350
		private int _iRemark = 13;

		// Token: 0x0400015F RID: 351
		private CParsingGrid _parsGrid;

		// Token: 0x04000160 RID: 352
		private string _userId = string.Empty;

		// Token: 0x04000161 RID: 353
		private string _webServiceUrl = string.Empty;

		// Token: 0x04000162 RID: 354
		private CBIBoardInfo _cBIBoardInfo;

		// Token: 0x04000163 RID: 355
		private SortedList _slSocketList;

		// Token: 0x04000164 RID: 356
		private BIBoardInfoModule _instance;

		// Token: 0x04000165 RID: 357
		private List<CBadSocketStatus> _cBadSocketStatuses;

		// Token: 0x04000166 RID: 358
		private CGetData _cGetData;

		// Token: 0x04000167 RID: 359
		private CSVControl _csvControl;

		// Token: 0x04000168 RID: 360
		private int _onFlag;

		// Token: 0x04000169 RID: 361
		private bool _isInsert;

		// Token: 0x0400016A RID: 362
		private int _iBibId;

		// Token: 0x0400016B RID: 363
		private string _cntOfSockDesc = string.Empty;
	}
}
