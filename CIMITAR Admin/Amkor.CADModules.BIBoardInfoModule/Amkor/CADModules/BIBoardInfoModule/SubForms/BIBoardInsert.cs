using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AlteraSocketView.View;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using DATA;
using DevAge.Drawing;
using ETC;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000020 RID: 32
	public partial class BIBoardInsert : Form
	{
		// Token: 0x0600007D RID: 125 RVA: 0x0000A1E1 File Offset: 0x000083E1
		public BIBoardInsert()
		{
			this.InitializeComponent();
			this.Clear();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000A20B File Offset: 0x0000840B
		public BIBoardInsert(string userId)
		{
			this._userId = userId;
			this.InitializeComponent();
			this.Clear();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000A23C File Offset: 0x0000843C
		public BIBoardInsert(string userId, string url)
		{
			this._userId = userId;
			this._webServiceUrl = url;
			this.InitializeComponent();
			this.Clear();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000A274 File Offset: 0x00008474
		public BIBoardInsert(string userId, string url, CBIBoardInfo info)
		{
			this._userId = userId;
			this._webServiceUrl = url;
			this.InitializeComponent();
			this.Clear();
			this.l_bib_No.Text = info.strBibNo;
			this.l_device.Text = info.strDevice;
			this.l_customer.Text = info.strCustomer;
			this.l_location.Text = info.strLocation;
			this.l_barcode.Text = info.strBarcode;
			this.tb_biboardno.Enabled = false;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000A318 File Offset: 0x00008518
		private void BIBoardInsert_Load(object sender, EventArgs e)
		{
			this.InitGridCell();
			this._instance = (BIBoardInfoModule)base.Parent.Parent;
			this.SetComponent();
			int gridInfo_Indv = 0;
			if (!int.TryParse(this.tb_CountOfSockets.Text, out gridInfo_Indv))
			{
				return;
			}
			this.ResetGrid(this.grid_Socket_Indv);
			this.SetGridInfo_Indv2(gridInfo_Indv);
			this.tb_biboardno.Select();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000055FE File Offset: 0x000037FE
		private void BIBoardInsert_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000A37C File Offset: 0x0000857C
		private void pb_Search_Bdno_MouseUp(object sender, MouseEventArgs e)
		{
			string text = this.tb_biboardno.Text;
			if (text == "")
			{
				MessageBox.Show("Input BIBoard Number");
				return;
			}
			List<CBIBoardInfo> list = BIBoardInfoModule._instance.GetBIBoardInfo_Insert(text);
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

		// Token: 0x06000084 RID: 132 RVA: 0x0000A500 File Offset: 0x00008700
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
				List<CBIBoardInfo> list = BIBoardInfoModule._instance.GetBIBoardInfo_Insert(text);
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

		// Token: 0x06000085 RID: 133 RVA: 0x0000A694 File Offset: 0x00008894
		private void btn_set_Click(object sender, EventArgs e)
		{
			int gridInfo_Indv = 0;
			if (!int.TryParse(this.tb_CountOfSockets.Text, out gridInfo_Indv))
			{
				MessageBox.Show("Input Numbers only!");
				return;
			}
			try
			{
				this.ResetGrid(this.grid_Socket_Indv);
				this.SetGridInfo_Indv2(gridInfo_Indv);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000A6F8 File Offset: 0x000088F8
		private void pb_Update_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave_Down;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000A70C File Offset: 0x0000890C
		private void pb_Update_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave;
			if (this.l_bib_No.Text == "")
			{
				MessageBox.Show("Search BIB first");
				return;
			}
			if (this.tb_CountOfSockets.Text == "")
			{
				MessageBox.Show("Input the Number of sockets");
				return;
			}
			int countOfSockets = int.Parse(this.tb_CountOfSockets.Text);
			if (this.grid_Socket_Indv.Rows.Count < 2)
			{
				MessageBox.Show("Set Tables");
				return;
			}
			CParsingGrid cparsingGrid = new CParsingGrid();
			string text;
			if (this._instance._factorySetting._factoryName == "ATV")
			{
				text = cparsingGrid.ParseGrid_Indv_(countOfSockets, this.grid_Socket_Indv, 1);
			}
			else
			{
				text = cparsingGrid.ParseGrid_Indv_(countOfSockets, this.grid_Socket_Indv, 0);
			}
			if (text == "")
			{
				MessageBox.Show("Input Integer only");
				return;
			}
			CBIBoardInfo cbiboardInfo = new CBIBoardInfo();
			cbiboardInfo.strBibNo = this.l_bib_No.Text;
			cbiboardInfo.strUserId = this._userId;
			cbiboardInfo.strBad_bib = "0";
			cbiboardInfo.strBarcode = this.l_barcode.Text;
			cbiboardInfo.strGoldTab = this.combo_BIBGoldTab.Text;
			cbiboardInfo.strWarranty = this.combo_Warranty.Text;
			CheckBadgeNo checkBadgeNo = new CheckBadgeNo(BIBoardInfoModule._instance._cimitarUser._badgeNo);
			checkBadgeNo.ShowDialog();
			string empty = string.Empty;
			string comment = string.Empty;
			if (checkBadgeNo.DialogResult == DialogResult.OK)
			{
				string badgeNo = checkBadgeNo._badgeNo;
				comment = checkBadgeNo._comment;
				BIBoardInfoModule._instance.SetBIBoardInfo(cbiboardInfo, text, comment);
				base.DialogResult = DialogResult.OK;
				base.Close();
				base.DialogResult = DialogResult.OK;
				base.Dispose();
				return;
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000A8CC File Offset: 0x00008ACC
		private void InitGridCell()
		{
			Color color = Color.FromArgb(255, 255, 255);
			RectangleBorder rectangleBorder = new RectangleBorder(new BorderLine(color), new BorderLine(color));
			this.cell_center = new SourceGrid.Cells.Views.Cell();
			this.cell_center.BackColor = color;
			this.cell_center.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_center.Border = rectangleBorder;
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
			Color color9 = Color.FromArgb(255, 234, 167);
			RectangleBorder rectangleBorder9 = new RectangleBorder(new BorderLine(color9), new BorderLine(color9));
			this.cell_row2 = new SourceGrid.Cells.Views.Cell();
			this.cell_row2.BackColor = color9;
			this.cell_row2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.cell_row2.Border = rectangleBorder9;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000AC38 File Offset: 0x00008E38
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

		// Token: 0x0600008A RID: 138 RVA: 0x0000AC80 File Offset: 0x00008E80
		private void SetGridInfo_Indv2(int cntOfSockets)
		{
			int num = 4;
			int num2 = 5;
			int num3 = num * num2 + 1;
			int num4 = 4;
			int num5 = (cntOfSockets / num + 1) * num4;
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
			int num8;
			if (this._instance._factorySetting._factoryName == "ATV")
			{
				num8 = 1;
			}
			else
			{
				num8 = 0;
			}
			for (int k = 1; k <= cntOfSockets; k++)
			{
				string cellValue = "Socket " + (k - 1 + num8).ToString();
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
				this.grid_Socket_Indv[num6 + 2, num7 + 1] = new SourceGrid.Cells.Cell("", typeof(string));
				this.grid_Socket_Indv[num6 + 2, num7 + 1].View = this.cell_center;
				this.grid_Socket_Indv[num6 + 3, num7 + 1] = new SourceGrid.Cells.Cell("", typeof(string));
				this.grid_Socket_Indv[num6 + 3, num7 + 1].View = this.cell_center;
				this.grid_Socket_Indv[num6 + 4, num7 + 1] = new SourceGrid.Cells.Cell("", typeof(string));
				this.grid_Socket_Indv[num6 + 4, num7 + 1].View = this.cell_center;
				this.grid_Socket_Indv[num6 + 2, num7 + 2] = new SourceGrid.Cells.Cell("", typeof(string));
				this.grid_Socket_Indv[num6 + 2, num7 + 2].View = this.cell_center;
				this.grid_Socket_Indv[num6 + 3, num7 + 2] = new SourceGrid.Cells.Cell("", typeof(string));
				this.grid_Socket_Indv[num6 + 3, num7 + 2].View = this.cell_center;
				this.grid_Socket_Indv[num6 + 4, num7 + 2] = new SourceGrid.Cells.Cell("", typeof(string));
				this.grid_Socket_Indv[num6 + 4, num7 + 2].View = this.cell_center;
				num6 += num2;
				if (num6 > 20)
				{
					num6 = 1;
					num7 += num4;
				}
			}
			string cellValue2 = "Other";
			this.grid_Socket_Indv[num6, num7] = new SourceGrid.Cells.Cell(cellValue2);
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
			this.grid_Socket_Indv[num6 + 2, num7 + 1] = new SourceGrid.Cells.Cell("", typeof(string));
			this.grid_Socket_Indv[num6 + 2, num7 + 1].View = this.cell_center;
			this.grid_Socket_Indv[num6 + 3, num7 + 1] = new SourceGrid.Cells.Cell("", typeof(string));
			this.grid_Socket_Indv[num6 + 3, num7 + 1].View = this.cell_center;
			this.grid_Socket_Indv[num6 + 4, num7 + 1] = new SourceGrid.Cells.Cell("", typeof(string));
			this.grid_Socket_Indv[num6 + 4, num7 + 1].View = this.cell_center;
			this.grid_Socket_Indv[num6 + 2, num7 + 2] = new SourceGrid.Cells.Cell("", typeof(string));
			this.grid_Socket_Indv[num6 + 2, num7 + 2].View = this.cell_center;
			this.grid_Socket_Indv[num6 + 3, num7 + 2] = new SourceGrid.Cells.Cell("", typeof(string));
			this.grid_Socket_Indv[num6 + 3, num7 + 2].View = this.cell_center;
			this.grid_Socket_Indv[num6 + 4, num7 + 2] = new SourceGrid.Cells.Cell("", typeof(string));
			this.grid_Socket_Indv[num6 + 4, num7 + 2].View = this.cell_center;
			this.grid_Socket_Indv.AutoSizeCells();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000B414 File Offset: 0x00009614
		private void SetComponent()
		{
			this.tb_CountOfSockets.Text = "24";
			this.tb_CountOfSockets.Enabled = false;
			this.btn_set.Enabled = false;
			this.combo_BIBGoldTab.Items.Clear();
			this.combo_BIBGoldTab.Items.Add("Good");
			this.combo_BIBGoldTab.Items.Add("Bad");
			this.combo_BIBGoldTab.SelectedIndex = 0;
			this.combo_Warranty.Items.Clear();
			this.combo_Warranty.Items.Add("Under");
			this.combo_Warranty.Items.Add("Out Of");
			this.combo_Warranty.SelectedIndex = 0;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000B4DC File Offset: 0x000096DC
		private void Clear()
		{
			this.l_bib_No.Text = "";
			this.l_device.Text = "";
			this.l_customer.Text = "";
			this.l_location.Text = "";
			this.l_barcode.Text = "";
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000B539 File Offset: 0x00009739
		private void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x040000EE RID: 238
		private BarPrograss _barPrograss;

		// Token: 0x040000EF RID: 239
		private Thread _thread;

		// Token: 0x040000F0 RID: 240
		private BIBoardInfoModule _instance;

		// Token: 0x040000F1 RID: 241
		private SourceGrid.Cells.Views.Cell cell_center;

		// Token: 0x040000F2 RID: 242
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x040000F3 RID: 243
		private SourceGrid.Cells.Views.Cell cell_header2;

		// Token: 0x040000F4 RID: 244
		private SourceGrid.Cells.Views.Cell cell_header3;

		// Token: 0x040000F5 RID: 245
		private SourceGrid.Cells.Views.Cell cell_body1;

		// Token: 0x040000F6 RID: 246
		private SourceGrid.Cells.Views.Cell cell_body2;

		// Token: 0x040000F7 RID: 247
		private SourceGrid.Cells.Views.Cell cell_onflag;

		// Token: 0x040000F8 RID: 248
		private SourceGrid.Cells.Views.Cell cell_row1;

		// Token: 0x040000F9 RID: 249
		private SourceGrid.Cells.Views.Cell cell_row2;

		// Token: 0x040000FA RID: 250
		private string _userId = string.Empty;

		// Token: 0x040000FB RID: 251
		private string _webServiceUrl = string.Empty;
	}
}
