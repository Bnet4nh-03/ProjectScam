using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccRepHisModule.Properties;
using DATA;

namespace Amkor.CADModules.HccRepHisModule.SubForms
{
	// Token: 0x0200000A RID: 10
	public partial class InsertHistory : Form
	{
		// Token: 0x06000042 RID: 66 RVA: 0x000045B6 File Offset: 0x000027B6
		public InsertHistory(List<CCust> cCusts)
		{
			this.InitializeComponent();
			this._cCusts = cCusts;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000045CB File Offset: 0x000027CB
		public InsertHistory(List<CCust> cCusts, CRepairHistoryItem cRepairHistoryItem)
		{
			this.InitializeComponent();
			this._cCusts = cCusts;
			this._cRepairHistoryItem = cRepairHistoryItem;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000045E7 File Offset: 0x000027E7
		private void InsertHistory_Load(object sender, EventArgs e)
		{
			this._instance = HccRepHisModule._instance;
			this._cRepairHistoryItems = new List<CRepairHistoryItem>();
			this.Clear();
			this.SetCombos();
			this.SetInfo(this._cRepairHistoryItem);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00004617 File Offset: 0x00002817
		private void InsertHistory_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000462C File Offset: 0x0000282C
		public void Clear()
		{
			this.l_customer.Text = "";
			this.l_barcode.Text = "";
			this.tb_Device.Text = "";
			this.l_NumOfSites.Text = "";
			this.l_SerialNo.Text = "";
			this.tb_CustCode.Text = "";
			this.tb_DefectedSite.Text = "";
			this.tb_ProbDesc.Text = "";
			this.tb_Action.Text = "";
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000046CC File Offset: 0x000028CC
		public void SetCombos()
		{
			this.combo_HwType.Items.Clear();
			this.combo_HwType.Items.Add("BOARD");
			this.combo_HwType.Items.Add("SOCKET");
			this.combo_HwType.Items.Add("KIT");
			this.combo_HwType.Items.Add("CORR");
			this.combo_HwType.SelectedIndex = 0;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00004750 File Offset: 0x00002950
		public void SearchHW(int hwTypeNo, string barcode, string serialNo)
		{
			this._cRepairHistoryItems.Clear();
			string sQuery = string.Empty;
			sQuery = string.Concat(new object[]
			{
				"EXEC [CIMitar_HCC].[dbo].[USP_Addn_RepairStatus] @flag = 'GET_HW', @hwTypeNo = ",
				hwTypeNo,
				", @barcode = '",
				barcode,
				"', @serialNo = '",
				serialNo,
				"'"
			});
			DataSet dataSet = this._instance.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					CRepairHistoryItem crepairHistoryItem = new CRepairHistoryItem();
					crepairHistoryItem.iId = 0;
					crepairHistoryItem.strBarcode = dataSet.Tables[0].Rows[i]["barcode"].ToString();
					crepairHistoryItem.strCustName = dataSet.Tables[0].Rows[i]["cust_name"].ToString();
					crepairHistoryItem.strBoard = dataSet.Tables[0].Rows[i]["board"].ToString();
					crepairHistoryItem.strSerialNo = dataSet.Tables[0].Rows[i]["serial_no"].ToString();
					crepairHistoryItem.iNumOfSites = int.Parse(dataSet.Tables[0].Rows[i]["sites"].ToString());
					this._cRepairHistoryItems.Add(crepairHistoryItem);
				}
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004908 File Offset: 0x00002B08
		private void SetInfo(CRepairHistoryItem info)
		{
			if (info != null)
			{
				this.l_customer.Text = info.strCustName;
				this.tb_CustCode.Text = info.strCustCode;
				this.l_barcode.Text = info.strBarcode;
				this.tb_Device.Text = info.strBoard;
				this.l_NumOfSites.Text = info.iNumOfSites.ToString();
				this.l_SerialNo.Text = info.strSerialNo;
				this.tb_DefectedSite.Text = ((info.iDefectedSite == 0) ? "" : info.iDefectedSite.ToString());
				this.tb_ProbDesc.Text = info.strProbDesc;
				this.tb_Action.Text = info.strAction;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000049D0 File Offset: 0x00002BD0
		private void Event_SearchHW()
		{
			string text = this.tb_Barcode.Text.Trim();
			string text2 = this.tb_SerialNo.Text.Trim();
			int hwTypeNo;
			if (text != "")
			{
				hwTypeNo = this._instance.GetHwTypeNo_Barcode(text);
			}
			else
			{
				string hwType = (this.combo_HwType.SelectedItem != null) ? this.combo_HwType.SelectedItem.ToString() : "";
				hwTypeNo = this._instance.GetHwTypeNo_Type(hwType);
			}
			if (text2 != "" && text2.Substring(0, 1) != "#")
			{
				text2 = "#" + text2;
				this.tb_SerialNo.Text = text2;
			}
			if (text != "" || text2 != "")
			{
				this.SearchHW(hwTypeNo, text, text2);
				if (this._cRepairHistoryItems.Count == 0)
				{
					return;
				}
				if (this._cRepairHistoryItems.Count == 1)
				{
					this.SetInfo(this._cRepairHistoryItems[0]);
					return;
				}
				if (this._cRepairHistoryItems.Count > 1)
				{
					InsertHistory_SelectOne insertHistory_SelectOne = new InsertHistory_SelectOne(this._cRepairHistoryItems);
					insertHistory_SelectOne.ShowDialog();
					if (insertHistory_SelectOne.DialogResult == DialogResult.OK)
					{
						CRepairHistoryItem selItem = insertHistory_SelectOne._selItem;
						this.SetInfo(selItem);
					}
				}
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004B18 File Offset: 0x00002D18
		private void pb_Search_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Search.Image = Resources.TableSearch_Down;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004B2A File Offset: 0x00002D2A
		private void pb_Search_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Search.Image = Resources.TableSearch;
			this.Clear();
			this.Event_SearchHW();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004B48 File Offset: 0x00002D48
		private void tb_SerialNo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.Event_SearchHW();
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004B5A File Offset: 0x00002D5A
		private void tb_Barcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.Event_SearchHW();
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004B6C File Offset: 0x00002D6C
		private void pb_Insert_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_Insert.Image = Resources.TableSave_Down;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004B80 File Offset: 0x00002D80
		private void pb_Insert_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_Insert.Image = Resources.TableSave;
			if (this.l_barcode.Text == "")
			{
				MessageBox.Show("No Data");
				return;
			}
			int num = 0;
			if (this.tb_CustCode.Text == "")
			{
				MessageBox.Show("Input Customer's code");
				return;
			}
			if (!int.TryParse(this.tb_CustCode.Text, out num))
			{
				MessageBox.Show("Customer's code must be Integer!");
				return;
			}
			string text = this.l_barcode.Text.Trim();
			int hwTypeNo_Barcode = this._instance.GetHwTypeNo_Barcode(text);
			string custInfo = this._instance.GetCustInfo(2, num.ToString(), this._cCusts);
			string text2 = this.tb_Device.Text;
			string text3 = this.l_SerialNo.Text;
			string text4 = this.l_NumOfSites.Text;
			string text5 = this.tb_DefectedSite.Text;
			string text6 = this.tb_ProbDesc.Text;
			string text7 = this.tb_Action.Text;
			string sQuery = string.Empty;
			if (this._cRepairHistoryItem != null && this._cRepairHistoryItem.iId != 0)
			{
				sQuery = string.Concat(new object[]
				{
					"EXEC [CIMitar_HCC].[dbo].[USP_Addn_RepairStatus] @flag = 'UPDATE', @historyId = ",
					this._cRepairHistoryItem.iId,
					", @defectedSite = '",
					text5,
					"', @probDesc = N'",
					text6,
					"', @action = N'",
					text7,
					"', @userId = '",
					this._instance._cimitarUser._id,
					"'"
				});
			}
			else
			{
				sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_HCC].[dbo].[USP_Addn_RepairStatus] @flag = 'INSERT', @barcode = '",
					text,
					"', @hwTypeNo = ",
					hwTypeNo_Barcode.ToString(),
					", @custName = '",
					custInfo,
					"', @custCode = '",
					num.ToString(),
					"', @board = '",
					text2,
					"', @serialNo = '",
					text3,
					"', @numOfSites = '",
					text4,
					"', @defectedSite = '",
					text5,
					"', @probDesc = N'",
					text6,
					"', @action = N'",
					text7,
					"', @userId = '",
					this._instance._cimitarUser._id,
					"'"
				});
			}
			DataSet dataSet = this._instance.QueryCall(sQuery);
			int num2 = 1;
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					num2 = int.Parse(dataSet.Tables[0].Rows[i]["result"].ToString());
				}
			}
			if (num2 == 0)
			{
				MessageBox.Show("Success to Insert");
			}
			base.Close();
		}

		// Token: 0x0400002F RID: 47
		public HccRepHisModule _instance;

		// Token: 0x04000030 RID: 48
		private List<CCust> _cCusts;

		// Token: 0x04000031 RID: 49
		private List<CRepairHistoryItem> _cRepairHistoryItems;

		// Token: 0x04000032 RID: 50
		private CRepairHistoryItem _cRepairHistoryItem;
	}
}
