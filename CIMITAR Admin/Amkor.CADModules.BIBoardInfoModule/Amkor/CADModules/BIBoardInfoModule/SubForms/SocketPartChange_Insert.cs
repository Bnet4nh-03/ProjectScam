using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using DATA;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000029 RID: 41
	public partial class SocketPartChange_Insert : Form
	{
		// Token: 0x06000112 RID: 274 RVA: 0x00017CA0 File Offset: 0x00015EA0
		public SocketPartChange_Insert(CBIBoardInfo cBIBoardInfo, int socketNo, string category, ArrayList alCategories, BIBoardInfoModule instance)
		{
			this.InitializeComponent();
			this._instance = instance;
			this._cBIBoardInfo = cBIBoardInfo;
			this._socketNo = socketNo;
			this._category = category;
			this._alCategories = (ArrayList)alCategories.Clone();
			if (this._instance._factorySetting._factoryName == "ATV")
			{
				this._isBarcodeValid = true;
				this.tb_SocketBarcode.Enabled = false;
				this.pb_Check.Image = Resources.Accept;
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00017D40 File Offset: 0x00015F40
		public SocketPartChange_Insert(CSocketPartChange cSocketPartChange, ArrayList alCategories, BIBoardInfoModule instance)
		{
			this.InitializeComponent();
			this._instance = instance;
			this._cSocketPartChange = cSocketPartChange;
			this._alCategories = (ArrayList)alCategories.Clone();
			this._isMod = true;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000055FE File Offset: 0x000037FE
		private void SocketPartChange_Insert_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00017D95 File Offset: 0x00015F95
		private void SocketPartChange_Insert_Load(object sender, EventArgs e)
		{
			this.SetInfos();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00017DA0 File Offset: 0x00015FA0
		private void tb_SocketBarcode_Leave(object sender, EventArgs e)
		{
			string text = this.tb_SocketBarcode.Text;
			if (text == "")
			{
				return;
			}
			string a = text.Substring(0, 2);
			string text2 = string.Empty;
			if (a != "AT")
			{
				text2 = "AT" + text;
			}
			else
			{
				text2 = text;
			}
			this.tb_SocketBarcode.Text = text2;
			this.SearchBarcode(text2);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00017E04 File Offset: 0x00016004
		private void tb_SocketBarcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				string text = this.tb_SocketBarcode.Text;
				if (text == "")
				{
					return;
				}
				string a = text.Substring(0, 2);
				string text2 = string.Empty;
				if (a != "AT")
				{
					text2 = "AT" + text;
				}
				else
				{
					text2 = text;
				}
				this.tb_SocketBarcode.Text = text2;
				this.SearchBarcode(text2);
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00017E72 File Offset: 0x00016072
		private void tb_SocketBarcode_TextChanged(object sender, EventArgs e)
		{
			if (this._isBarcodeValid)
			{
				this._isBarcodeValid = false;
				this.pb_Check.Image = Resources.Cancel;
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00017E94 File Offset: 0x00016094
		private void pb_Check_MouseUp(object sender, MouseEventArgs e)
		{
			string text = this.tb_SocketBarcode.Text;
			if (text == "")
			{
				return;
			}
			string a = text.Substring(0, 2);
			string text2 = string.Empty;
			if (a != "AT")
			{
				text2 = "AT" + text;
			}
			else
			{
				text2 = text;
			}
			this.tb_SocketBarcode.Text = text2;
			this.SearchBarcode(text2);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00017EF8 File Offset: 0x000160F8
		private void pb_Update_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave_Down;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00017F0C File Offset: 0x0001610C
		private void pb_Update_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Update.Image = Resources.TableSave;
			if (!this._isBarcodeValid)
			{
				MessageBox.Show("Invalid Socket barcode");
				return;
			}
			if (this.combo_Category.SelectedItem == null)
			{
				MessageBox.Show("Select Category");
				return;
			}
			string category = this.combo_Category.SelectedItem.ToString();
			string barcode_BiBoard = string.Empty;
			string bibNo = string.Empty;
			string barcode_Socket = string.Empty;
			string dateIn = string.Empty;
			int repairTime = 0;
			int socketNo;
			if (this._isMod)
			{
				barcode_BiBoard = this._cSocketPartChange.strBarcode_Board;
				bibNo = this._cSocketPartChange.strBibNo;
				socketNo = int.Parse(this.tb_SocketNo.Text);
				barcode_Socket = this.tb_SocketBarcode.Text;
				DateTime dateTime;
				if (!DateTime.TryParse(this.tb_DateIn.Text, out dateTime))
				{
					MessageBox.Show("In Date format is wrong!");
					return;
				}
				dateIn = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
			}
			else
			{
				barcode_BiBoard = this._cBIBoardInfo.strBarcode;
				bibNo = this._cBIBoardInfo.strBibNo;
				socketNo = this._socketNo;
				barcode_Socket = this._socketBarcode;
			}
			if (!int.TryParse(this.tb_RepairTime.Text, out repairTime))
			{
				MessageBox.Show("Input integer only in Repiar Time");
				return;
			}
			CheckBadgeNo checkBadgeNo = new CheckBadgeNo();
			checkBadgeNo.ShowDialog();
			string badgeNo = string.Empty;
			string comment = string.Empty;
			if (checkBadgeNo.DialogResult != DialogResult.OK)
			{
				return;
			}
			badgeNo = checkBadgeNo._badgeNo;
			comment = checkBadgeNo._comment;
			int num;
			if (this._isMod)
			{
				num = this.Update_Mod(this._cSocketPartChange.iId, category, barcode_BiBoard, bibNo, socketNo, barcode_Socket, repairTime, badgeNo, comment, dateIn);
			}
			else
			{
				num = this.Update(category, barcode_BiBoard, bibNo, socketNo, barcode_Socket, repairTime, badgeNo, comment);
			}
			if (num == 0)
			{
				MessageBox.Show("Success to Update");
				base.DialogResult = DialogResult.OK;
				base.Close();
				return;
			}
			MessageBox.Show("Fail to Update");
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000180E0 File Offset: 0x000162E0
		private void SetInfos()
		{
			if (this._isMod)
			{
				this.tb_SocketNo.Text = this._cSocketPartChange.iSocketNo.ToString();
				this.combo_Category.Items.AddRange(this._alCategories.ToArray());
				this.combo_Category.SelectedIndex = this.combo_Category.FindString(this._cSocketPartChange.strCategory);
				this.tb_SocketBarcode.Text = this._cSocketPartChange.strBarcode_Socket;
				this.tb_RepairTime.Text = this._cSocketPartChange.iRepairTime_Min.ToString();
				this.tb_DateIn.Text = this._cSocketPartChange.dtInTime.ToString("yyyy-MM-dd HH:mm:ss");
				List<CSocketPartChange> source = (from p in (from p in this._cBIBoardInfo.cSocketPartChanges
				orderby p.iId
				select p).ToList<CSocketPartChange>()
				where p.iSocketNo == int.Parse(this.tb_SocketNo.Text)
				select p).ToList<CSocketPartChange>();
				if (source.Count<CSocketPartChange>() > 0)
				{
					this.tb_SocketBarcode.Text = source.Last<CSocketPartChange>().strBarcode_Socket;
				}
				this.pb_Check.Image = Resources.Accept;
				this._isBarcodeValid = true;
				this._socketBarcode = this._cSocketPartChange.strBarcode_Socket;
				return;
			}
			this.tb_SocketNo.Text = this._socketNo.ToString();
			this._alCategories.Remove("ALL");
			this.combo_Category.Items.AddRange(this._alCategories.ToArray());
			List<CSocketPartChange> source2 = (from p in (from p in this._cBIBoardInfo.cSocketPartChanges
			orderby p.iId
			select p).ToList<CSocketPartChange>()
			where p.iSocketNo == int.Parse(this.tb_SocketNo.Text)
			select p).ToList<CSocketPartChange>();
			if (source2.Count<CSocketPartChange>() > 0)
			{
				this.tb_SocketBarcode.Text = source2.Last<CSocketPartChange>().strBarcode_Socket;
			}
			if (this._category == "ALL")
			{
				this.combo_Category.SelectedIndex = -1;
			}
			else
			{
				this.combo_Category.SelectedIndex = this.combo_Category.FindString(this._category);
			}
			if (this.combo_Category.Items.Count == 1)
			{
				this.combo_Category.SelectedIndex = 0;
			}
			this.tb_DateIn.Text = "";
			this.tb_DateIn.Enabled = false;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00018358 File Offset: 0x00016558
		private void SearchBarcode(string barcode)
		{
			if (this.USP_Get_HwInfo(barcode) == null)
			{
				this.pb_Check.Image = Resources.Cancel;
				this._isBarcodeValid = false;
				this._socketBarcode = string.Empty;
				return;
			}
			this.pb_Check.Image = Resources.Accept;
			this._isBarcodeValid = true;
			this._socketBarcode = barcode;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000183B0 File Offset: 0x000165B0
		private CEasyInputInfo USP_Get_HwInfo(string barcode)
		{
			if (barcode == "")
			{
				return null;
			}
			CEasyInputInfo result;
			try
			{
				string a = barcode.Substring(0, 2);
				CEasyInputInfo ceasyInputInfo = new CEasyInputInfo();
				string sQuery = "";
				if (a == "AT")
				{
					sQuery = "EXEC [dbo].[USP_Get_HwInfo] @flag = 'SOCKET', @barcode = '" + barcode + "'";
				}
				DataSet dataSet = this._instance.QueryCall(sQuery);
				if (dataSet.Tables[1].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[1].Rows.Count; i++)
					{
						ceasyInputInfo.strBarcode = dataSet.Tables[1].Rows[i]["barcode"].ToString();
					}
					result = ceasyInputInfo;
				}
				else
				{
					result = null;
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00018498 File Offset: 0x00016698
		private int Update(string category, string barcode_BiBoard, string bibNo, int socketNo, string barcode_Socket, int repairTime, string badgeNo, string comment)
		{
			DataSet dataSet = new DataSet();
			string sQuery = string.Concat(new string[]
			{
				"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Socket] @flag = 'INSERT_PART_CHANGE', @groupId = 0, @category = '",
				category,
				"', @barcode_Board = '",
				barcode_BiBoard,
				"', @bibNo = '",
				bibNo,
				"', @socketNo = ",
				socketNo.ToString(),
				", @barcode_Socket = '",
				barcode_Socket,
				"', @repairTime_Min = ",
				repairTime.ToString(),
				", @badgeNo = '",
				badgeNo,
				"', @comment = '",
				comment,
				"'"
			});
			dataSet = this._instance.QueryCall(sQuery);
			int result = -1;
			if (dataSet.Tables.Count > 0)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						result = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
					}
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000185C4 File Offset: 0x000167C4
		private int Update_Mod(int pId, string category, string barcode_BiBoard, string bibNo, int socketNo, string barcode_Socket, int repairTime, string badgeNo, string comment, string dateIn)
		{
			DataSet dataSet = new DataSet();
			string sQuery = string.Concat(new string[]
			{
				"EXEC [dbo].[USP_Addn_Board_BurnIn_Info_Socket] @flag = 'UPDATE_PART_CHANGE', @groupId = 0, @category = '",
				category,
				"', @socketNo = ",
				socketNo.ToString(),
				", @barcode_Socket = '",
				barcode_Socket,
				"', @repairTime_Min = ",
				repairTime.ToString(),
				", @badgeNo = '",
				badgeNo,
				"', @comment = '",
				comment,
				"', @inTime = '",
				dateIn,
				"', @pId = ",
				pId.ToString()
			});
			dataSet = this._instance.QueryCall(sQuery);
			int result = -1;
			if (dataSet.Tables.Count > 0)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						result = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
					}
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x040001DE RID: 478
		private BIBoardInfoModule _instance;

		// Token: 0x040001DF RID: 479
		private CBIBoardInfo _cBIBoardInfo;

		// Token: 0x040001E0 RID: 480
		private int _socketNo;

		// Token: 0x040001E1 RID: 481
		private string _category = string.Empty;

		// Token: 0x040001E2 RID: 482
		private ArrayList _alCategories;

		// Token: 0x040001E3 RID: 483
		private string _socketBarcode = string.Empty;

		// Token: 0x040001E4 RID: 484
		private bool _isBarcodeValid;

		// Token: 0x040001E5 RID: 485
		private CSocketPartChange _cSocketPartChange;

		// Token: 0x040001E6 RID: 486
		private bool _isMod;
	}
}
