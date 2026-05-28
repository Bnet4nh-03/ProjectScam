using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Control;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000052 RID: 82
	public partial class DeviceView : Form
	{
		// Token: 0x060003E1 RID: 993 RVA: 0x0005A3DB File Offset: 0x000585DB
		public DeviceView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0005A415 File Offset: 0x00058615
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0005A420 File Offset: 0x00058620
		private void FilterView_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.lstDevice.View = View.Details;
			this.lstDevice.GridLines = false;
			this.lstDevice.FullRowSelect = true;
			this.lstDevice.CheckBoxes = true;
			this.lstDevice.MultiSelect = false;
			this.lstDevice.HideSelection = false;
			this.lstDevice.Columns.Clear();
			this.lstDevice.Columns.Add("");
			this.lstDevice.Columns.Add("Name");
			this.lstDevice.Columns[0].Width = 20;
			this.lstDevice.Columns[1].Width = 150;
			this.lstDevice.Items.Clear();
			this.lstSelectedDevice.View = View.Details;
			this.lstSelectedDevice.GridLines = false;
			this.lstSelectedDevice.FullRowSelect = true;
			this.lstSelectedDevice.CheckBoxes = true;
			this.lstSelectedDevice.MultiSelect = false;
			this.lstSelectedDevice.HideSelection = false;
			this.lstSelectedDevice.Columns.Clear();
			this.lstSelectedDevice.Columns.Add("");
			this.lstSelectedDevice.Columns.Add("Name");
			this.lstSelectedDevice.Columns[0].Width = 20;
			this.lstSelectedDevice.Columns[1].Width = 150;
			this.lstSelectedDevice.Items.Clear();
			this.rdoDevice.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdoNickName.CheckedChanged += this.rdoType_CheckedChanged;
			this.rdoType_CheckedChanged(null, null);
			if (this.sDevice != string.Empty)
			{
				string[] array = this.sDevice.Split(new char[]
				{
					'|'
				});
				this.lstSelectedDevice.BeginUpdate();
				for (int i = 0; i < array.Length; i++)
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.SubItems.Add(array[i].Trim());
					this.lstSelectedDevice.Items.Add(listViewItem);
				}
				this.lstSelectedDevice.EndUpdate();
			}
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0005A680 File Offset: 0x00058880
		private void cmbCustomer_DropDown(object sender, EventArgs e)
		{
			DataSet dataSet = new DataSet();
			int selectedIndex = this.cmbCustomer.SelectedIndex;
			string text = string.Empty;
			string str = string.Empty;
			try
			{
				this.cmbCustomer.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetCustomerList]";
				dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						ComboBoxItem comboBoxItem = new ComboBoxItem();
						text = dataSet.Tables[0].Rows[i][0].ToString();
						str = dataSet.Tables[0].Rows[i][1].ToString();
						text = "[" + str + "] " + text;
						comboBoxItem.Text = text;
						comboBoxItem.Name = dataSet.Tables[0].Rows[i]["customername"].ToString();
						comboBoxItem.Code = dataSet.Tables[0].Rows[i]["customercode"].ToString();
						this.cmbCustomer.Items.Add(comboBoxItem);
					}
					this.cmbCustomer.SelectedIndex = selectedIndex;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0005A83C File Offset: 0x00058A3C
		private void rdoType_CheckedChanged(object sender, EventArgs e)
		{
			foreach (object obj in this.grpMenu.Controls)
			{
				Control control = (Control)obj;
				RadioButton radioButton = (RadioButton)control;
				if (radioButton.Checked)
				{
					this.sMenu = radioButton.Text;
				}
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0005A8B0 File Offset: 0x00058AB0
		private void txtDevice_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.cmdDeviceSearch_Click(null, null);
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0005A8C4 File Offset: 0x00058AC4
		private void cmbCustomer_KeyPress(object sender, KeyPressEventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (e.KeyChar != '\b')
			{
				this._strFind += e.KeyChar;
				int num = -1;
				for (int i = 0; i < comboBox.Items.Count; i++)
				{
					if (comboBox.Items[i].ToString().Contains(this._strFind))
					{
						num = i;
					}
				}
				if (num != -1)
				{
					comboBox.SelectedText = "";
					comboBox.SelectedIndex = num;
					e.Handled = true;
					return;
				}
				this._strFind = e.KeyChar.ToString();
				e.Handled = false;
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0005A974 File Offset: 0x00058B74
		private void cmdDeviceSearch_Click(object sender, EventArgs e)
		{
			this.lstDevice.Items.Clear();
			if (this.cmbCustomer.Text.Trim() == string.Empty)
			{
				MessageBox.Show("select customer please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string text = (this.cmbCustomer.SelectedItem as ComboBoxItem).Code.ToString().Trim();
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_GetDeviceList] @customercode = '",
				text,
				"', @devicename = '",
				this.txtDevice.Text.Trim(),
				"', @flag = '",
				this.sMenu,
				"'"
			});
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				this.lstDevice.BeginUpdate();
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.SubItems.Add(dataSet.Tables[0].Rows[i]["device"].ToString());
				this.lstDevice.Items.Add(listViewItem);
				this.lstDevice.EndUpdate();
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0005AACC File Offset: 0x00058CCC
		private void cmdDeviceApply_Click(object sender, EventArgs e)
		{
			this.sDevice = string.Empty;
			for (int i = 0; i < this.lstSelectedDevice.Items.Count; i++)
			{
				if (this.sDevice != string.Empty)
				{
					this.sDevice += "  |  ";
				}
				this.sDevice += this.lstSelectedDevice.Items[i].SubItems[1].Text;
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0005AB66 File Offset: 0x00058D66
		private void cmdDeviceClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			base.Close();
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0005AB75 File Offset: 0x00058D75
		private void cmdDeviceSearch_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdDeviceSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0005AB92 File Offset: 0x00058D92
		private void cmdDeviceSearch_MouseLeave(object sender, EventArgs e)
		{
			this.cmdDeviceSearch.Image = Resources.TableSearch;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0005ABAF File Offset: 0x00058DAF
		private void cmdDeviceSearch_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdDeviceSearch.Image = Resources.TableSearch_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0005ABCC File Offset: 0x00058DCC
		private void cmdDeviceSearch_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0005ABD9 File Offset: 0x00058DD9
		private void cmdDeviceApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdDeviceApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0005ABF6 File Offset: 0x00058DF6
		private void cmdDeviceApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdDeviceApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0005AC13 File Offset: 0x00058E13
		private void cmdDeviceApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdDeviceApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0005AC30 File Offset: 0x00058E30
		private void cmdDeviceApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0005AC3D File Offset: 0x00058E3D
		private void cmdDeviceClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdDeviceClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0005AC5A File Offset: 0x00058E5A
		private void cmdDeviceClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdDeviceClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0005AC77 File Offset: 0x00058E77
		private void cmdDeviceClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdDeviceClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0005AC94 File Offset: 0x00058E94
		private void cmdDeviceClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0005ACA1 File Offset: 0x00058EA1
		private void cmdRight_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdRight.Image = Resources.ArrowRight;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0005ACBE File Offset: 0x00058EBE
		private void cmdRight_MouseLeave(object sender, EventArgs e)
		{
			this.cmdRight.Image = Resources.ArrowRight;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0005ACDB File Offset: 0x00058EDB
		private void cmdRight_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdRight.Image = Resources.ArrowRight_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0005ACF8 File Offset: 0x00058EF8
		private void cmdRight_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0005AD05 File Offset: 0x00058F05
		private void cmdLeft_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdLeft.Image = Resources.ArrowLeft;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0005AD22 File Offset: 0x00058F22
		private void cmdLeft_MouseLeave(object sender, EventArgs e)
		{
			this.cmdLeft.Image = Resources.ArrowLeft;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0005AD3F File Offset: 0x00058F3F
		private void cmdLeft_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdLeft.Image = Resources.ArrowLeft_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0005AD5C File Offset: 0x00058F5C
		private void cmdLeft_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0005AD69 File Offset: 0x00058F69
		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0005AD6B File Offset: 0x00058F6B
		private void txtSearch_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0005AD6D File Offset: 0x00058F6D
		private void lstViewFilter_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0005AD70 File Offset: 0x00058F70
		private void lstDevice_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.lstDevice.SelectedItems == null)
			{
				return;
			}
			for (int i = 0; i < this.lstDevice.SelectedItems.Count; i++)
			{
				bool flag = true;
				ListViewItem listViewItem = (ListViewItem)this.lstDevice.SelectedItems[i].Clone();
				for (int j = 0; j < this.lstSelectedDevice.Items.Count; j++)
				{
					if (this.lstSelectedDevice.Items[j].SubItems[1].Text.ToString() == listViewItem.SubItems[1].Text.ToString())
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.lstSelectedDevice.Items.Add(listViewItem);
					this.lstDevice.SelectedItems[i].Remove();
				}
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0005AE5C File Offset: 0x0005905C
		private void lstSelectedDevice_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.lstSelectedDevice.SelectedItems == null)
			{
				return;
			}
			for (int i = 0; i < this.lstSelectedDevice.SelectedItems.Count; i++)
			{
				bool flag = true;
				ListViewItem listViewItem = (ListViewItem)this.lstSelectedDevice.SelectedItems[i].Clone();
				for (int j = 0; j < this.lstDevice.Items.Count; j++)
				{
					if (this.lstDevice.Items[j].SubItems[1].Text.ToString() == listViewItem.SubItems[1].Text.ToString())
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.lstDevice.Items.Add(listViewItem);
					this.lstSelectedDevice.SelectedItems[i].Remove();
				}
				else
				{
					this.lstSelectedDevice.SelectedItems[i].Remove();
				}
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0005AF60 File Offset: 0x00059160
		private void cmdRight_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.lstDevice.CheckedItems.Count; i++)
			{
				bool flag = true;
				ListViewItem listViewItem = (ListViewItem)this.lstDevice.CheckedItems[i].Clone();
				for (int j = 0; j < this.lstSelectedDevice.Items.Count; j++)
				{
					if (this.lstSelectedDevice.Items[j].SubItems[1].Text.ToString() == listViewItem.SubItems[1].Text.ToString())
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.lstSelectedDevice.Items.Add(listViewItem);
					this.lstDevice.CheckedItems[i].Remove();
					i--;
				}
			}
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0005B040 File Offset: 0x00059240
		private void cmdLeft_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.lstSelectedDevice.CheckedItems.Count; i++)
			{
				bool flag = true;
				ListViewItem listViewItem = (ListViewItem)this.lstSelectedDevice.CheckedItems[i].Clone();
				for (int j = 0; j < this.lstDevice.Items.Count; j++)
				{
					if (this.lstDevice.Items[j].SubItems[1].Text.ToString() == listViewItem.SubItems[1].Text.ToString())
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.lstDevice.Items.Add(listViewItem);
					this.lstSelectedDevice.CheckedItems[i].Remove();
					i--;
				}
				else
				{
					this.lstSelectedDevice.CheckedItems[i].Remove();
					i--;
				}
			}
		}

		// Token: 0x0400062B RID: 1579
		public FactorySettings _factorySetting;

		// Token: 0x0400062C RID: 1580
		public string sType = string.Empty;

		// Token: 0x0400062D RID: 1581
		public string sDevice = string.Empty;

		// Token: 0x0400062E RID: 1582
		private string _strFind = string.Empty;

		// Token: 0x0400062F RID: 1583
		private string sMenu = string.Empty;

		// Token: 0x04000630 RID: 1584
		private QueryMgr queryMgr;
	}
}
