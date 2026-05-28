using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Properties;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000037 RID: 55
	public partial class PartForm : Form
	{
		// Token: 0x06000373 RID: 883 RVA: 0x0006AA9C File Offset: 0x00068C9C
		private void pbCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0006AAAF File Offset: 0x00068CAF
		private void pbCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel_down;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0006AAC2 File Offset: 0x00068CC2
		private void pbApply_MouseEnter(object sender, EventArgs e)
		{
			this.pbApply.Image = Resources.apply_down;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0006AAD5 File Offset: 0x00068CD5
		private void pbApply_MouseLeave(object sender, EventArgs e)
		{
			this.pbApply.Image = Resources.apply;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0006AAE8 File Offset: 0x00068CE8
		public PartForm(List<string> PartList, List<string> PartDescription, bool bVisibleDelete)
		{
			this._PartList = PartList;
			this._PartDescription = PartDescription;
			this._bVisibleDalete = bVisibleDelete;
			this.InitializeComponent();
			this.dataGridView.Rows.Clear();
			this.dataGridView.Columns[3].Visible = this._bVisibleDalete;
			this.dataGridView.ReadOnly = !this._bVisibleDalete;
			this.loadData();
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0006AB88 File Offset: 0x00068D88
		private void loadData()
		{
			this.dataGridView.RowCount = this._PartList.Count + 1;
			for (int i = 0; i < this._PartList.Count; i++)
			{
				string[] array = this._PartList[i].Split(new char[]
				{
					'|'
				});
				this.dataGridView.Rows[i].Cells[0].Value = this._PartDescription[i];
				this.dataGridView.Rows[i].Cells[1].Value = array[0];
				bool flag = array.Length > 1;
				if (flag)
				{
					this.dataGridView.Rows[i].Cells[2].Value = array[1];
				}
			}
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0006AC74 File Offset: 0x00068E74
		public List<string> getPartList()
		{
			return this._PartList;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0006AC8C File Offset: 0x00068E8C
		public List<string> gePartDescription()
		{
			return this._PartDescription;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00061297 File Offset: 0x0005F497
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0006ACA4 File Offset: 0x00068EA4
		private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			string name = this.dataGridView.CurrentCell.OwningColumn.Name;
			bool flag = name == "Column3";
			if (flag)
			{
				e.Control.KeyPress -= this.txtCheckNumeric_KeyPress2;
				e.Control.KeyPress += this.txtCheckNumeric_KeyPress;
			}
			else
			{
				e.Control.KeyPress -= this.txtCheckNumeric_KeyPress;
				e.Control.KeyPress += this.txtCheckNumeric_KeyPress2;
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0006AD40 File Offset: 0x00068F40
		private void txtCheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back);
			if (flag)
			{
				e.Handled = true;
			}
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0006AD80 File Offset: 0x00068F80
		private void txtCheckNumeric_KeyPress2(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == Convert.ToChar('|');
			if (flag)
			{
				e.Handled = true;
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0006ADAC File Offset: 0x00068FAC
		private void btnOK_Click(object sender, EventArgs e)
		{
			this.dataGridView.ClearSelection();
			this.dataGridView.Rows[0].Cells[0].Selected = true;
			bool flag = !this._bVisibleDalete;
			if (flag)
			{
				base.DialogResult = DialogResult.No;
				base.Close();
			}
			else
			{
				this._PartList.Clear();
				this._PartDescription.Clear();
				for (int i = 0; i < this.dataGridView.Rows.Count; i++)
				{
					bool flag2 = this.dataGridView.Rows[i].Cells[1].Value == null || this.dataGridView.Rows[i].Cells[2].Value == null;
					if (!flag2)
					{
						bool flag3 = this.dataGridView.Rows[i].Cells[0].Value != null;
						string item;
						if (flag3)
						{
							item = this.dataGridView.Rows[i].Cells[0].Value.ToString();
							this._PartDescription.Add(item);
						}
						item = this.dataGridView.Rows[i].Cells[1].Value.ToString() + "|" + this.dataGridView.Rows[i].Cells[2].Value.ToString();
						this._PartList.Add(item);
					}
				}
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0006AF7C File Offset: 0x0006917C
		private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.ColumnIndex == 3 && e.RowIndex < this.dataGridView.RowCount - 1;
			if (flag)
			{
				for (int i = 0; i < this.dataGridView.RowCount - 1; i++)
				{
					bool flag2 = i >= e.RowIndex;
					if (flag2)
					{
						this.dataGridView.Rows[i].Cells[0].Value = this.dataGridView.Rows[i + 1].Cells[0].Value;
						this.dataGridView.Rows[i].Cells[1].Value = this.dataGridView.Rows[i + 1].Cells[1].Value;
						this.dataGridView.Rows[i].Cells[2].Value = this.dataGridView.Rows[i + 1].Cells[2].Value;
					}
				}
				this.dataGridView.RowCount = this.dataGridView.RowCount - 1;
			}
			else
			{
				bool flag3 = e.RowIndex == this.dataGridView.RowCount;
				if (flag3)
				{
					this.dataGridView.RowCount = this.dataGridView.RowCount - 1;
				}
			}
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0006B10C File Offset: 0x0006930C
		private void dataGridView_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < this.dataGridView.RowCount; i++)
			{
				bool flag = this.dataGridView.Rows[i].Cells[3].Value == null;
				if (flag)
				{
					this.dataGridView.Rows[i].Cells[3].Value = "Delete";
				}
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0006B187 File Offset: 0x00069387
		private void pbApply_Click(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.apply;
			this.btnOK_Click(null, null);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0006B1A4 File Offset: 0x000693A4
		private void pbCancel_Click(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
			this.btnCancel_Click(null, null);
		}

		// Token: 0x040005AD RID: 1453
		private List<string> _PartList = new List<string>();

		// Token: 0x040005AE RID: 1454
		private List<string> _PartDescription = new List<string>();

		// Token: 0x040005AF RID: 1455
		private bool _bVisibleDalete = false;
	}
}
