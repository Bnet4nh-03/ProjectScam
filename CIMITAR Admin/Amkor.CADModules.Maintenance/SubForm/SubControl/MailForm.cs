using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.Properties;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000035 RID: 53
	public partial class MailForm : Form
	{
		// Token: 0x06000342 RID: 834 RVA: 0x00066D9B File Offset: 0x00064F9B
		private void pbApply_MouseLeave(object sender, EventArgs e)
		{
			this.pbApply.Image = Resources.apply;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00066DAE File Offset: 0x00064FAE
		private void pbApply_MouseEnter(object sender, EventArgs e)
		{
			this.pbApply.Image = Resources.apply_down;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00066DC1 File Offset: 0x00064FC1
		private void pbCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00066DD4 File Offset: 0x00064FD4
		private void pbCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel_down;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00066DE7 File Offset: 0x00064FE7
		private void btnGridClose_Click(object sender, EventArgs e)
		{
			this.pnToInfo.Visible = false;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00066DF6 File Offset: 0x00064FF6
		private void btnGridClose2_Click(object sender, EventArgs e)
		{
			this.pnCCInfo.Visible = false;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00066E08 File Offset: 0x00065008
		public MailForm(string sTitle, string sCategory, string sPart, object DefaulMailList, object CCMailList, List<string> MailList)
		{
			this._sCategory = sCategory;
			this._sPart = sPart;
			this._lMailList = MailList;
			this._lDefaultMailList = (List<cEmailInfo>)DefaulMailList;
			this._lDefaultMailListTemp = new List<cEmailInfo>((List<cEmailInfo>)DefaulMailList);
			this._lCCMailList = (List<cEmailInfo>)CCMailList;
			this.InitializeComponent();
			this.InitGridCell();
			this.rbToInfo.Text = MessageLanguage.getMessage("tomail_comment");
			this.rbCCInfo.Text = MessageLanguage.getMessage("ccmail_comment");
			this.groupBox3.Text = sTitle;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00066EE4 File Offset: 0x000650E4
		private void InitGridCell()
		{
			this.grid_mail.Rows.Clear();
			this.grid_TempMail.Rows.Clear();
			this.grid_CCMail.Rows.Clear();
			this.grid_mail.Selection.EnableMultiSelection = false;
			this.grid_mail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_mail.CustomSort = true;
			this.grid_TempMail.Selection.EnableMultiSelection = false;
			this.grid_TempMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_TempMail.CustomSort = true;
			this.grid_CCMail.Selection.EnableMultiSelection = false;
			this.grid_CCMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_CCMail.CustomSort = true;
			this.cell_header1 = new SourceGrid.Cells.Views.Cell();
			this.cell_header1.BackColor = Color.FromArgb(130, 179, 237);
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.SetGridHeader();
			this.setMailList();
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00066FF0 File Offset: 0x000651F0
		private void SetGridHeader()
		{
			this.grid_mail.ColumnsCount = 3;
			this.grid_mail.FixedRows = 1;
			this.grid_mail.FixedColumns = 1;
			this.grid_TempMail.ColumnsCount = 3;
			this.grid_TempMail.FixedRows = 1;
			this.grid_TempMail.FixedColumns = 1;
			this.grid_CCMail.ColumnsCount = 3;
			this.grid_CCMail.FixedRows = 1;
			this.grid_CCMail.FixedColumns = 1;
			this.grid_mail.Rows.Insert(0);
			this.grid_TempMail.Rows.Insert(0);
			this.grid_CCMail.Rows.Insert(0);
			int col = 0;
			this.grid_mail[0, col] = new SourceGrid.Cells.ColumnHeader("Mail");
			this.grid_mail[0, col++].View = this.cell_header1;
			this.grid_mail[0, col] = new SourceGrid.Cells.ColumnHeader("Check");
			this.grid_mail[0, col++].View = this.cell_header1;
			col = 0;
			this.grid_TempMail[0, col] = new SourceGrid.Cells.ColumnHeader("Mail");
			this.grid_TempMail[0, col++].View = this.cell_header1;
			this.grid_TempMail[0, col] = new SourceGrid.Cells.ColumnHeader("Check");
			this.grid_TempMail[0, col++].View = this.cell_header1;
			col = 0;
			this.grid_CCMail[0, col] = new SourceGrid.Cells.ColumnHeader("Mail");
			this.grid_CCMail[0, col++].View = this.cell_header1;
			this.grid_CCMail[0, col] = new SourceGrid.Cells.ColumnHeader("Check");
			this.grid_CCMail[0, col++].View = this.cell_header1;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x000671F0 File Offset: 0x000653F0
		private void setMailList()
		{
			for (int i = 0; i < this._lDefaultMailListTemp.Count; i++)
			{
				this.grid_mail.Rows.Insert(i + 1);
				this.grid_mail[i + 1, 0] = new SourceGrid.Cells.Cell(this._lDefaultMailListTemp[i]._sEmail);
				this.grid_mail[i + 1, 1] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
			}
			for (int j = 0; j < this._lCCMailList.Count; j++)
			{
				this.grid_CCMail.Rows.Insert(j + 1);
				this.grid_CCMail[j + 1, 0] = new SourceGrid.Cells.Cell(this._lCCMailList[j]._sEmail);
				this.grid_CCMail[j + 1, 1] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
			}
			this.grid_mail.AutoSizeCells();
			for (int k = 0; k < this._lMailList.Count; k++)
			{
				this.grid_TempMail.Rows.Insert(k + 1);
				this.grid_TempMail[k + 1, 0] = new SourceGrid.Cells.Cell(this._lMailList[k]);
				this.grid_TempMail[k + 1, 1] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
			}
			this.grid_TempMail.AutoSizeCells();
			this.grid_CCMail.AutoSizeCells();
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0006737D File Offset: 0x0006557D
		private void btnOK_Click(object sender, EventArgs e)
		{
			this._lDefaultMailList = this._lDefaultMailListTemp;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00061297 File Offset: 0x0005F497
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0006739C File Offset: 0x0006559C
		private void btnAppend_Click(object sender, EventArgs e)
		{
			bool visible = this.pnToInfo.Visible;
			if (visible)
			{
				this.pnToInfo.Visible = false;
			}
			for (int i = 0; i < this.grid_TempMail.RowsCount - 1; i++)
			{
				bool flag = (bool)this.grid_TempMail[i + 1, 1].Value;
				if (flag)
				{
					bool flag2 = true;
					string text = this.grid_TempMail[i + 1, 0].Value.ToString();
					cEmailInfo cEmailInfo = new cEmailInfo();
					cEmailInfo._sEmail = text;
					for (int j = 0; j < this._lDefaultMailListTemp.Count; j++)
					{
						bool flag3 = this._lDefaultMailListTemp[j]._sEmail.CompareTo(text) == 0;
						if (flag3)
						{
							MessageBox.Show(text + MessageLanguage.getMessage("check_alreay_exist"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							flag2 = false;
							break;
						}
					}
					bool flag4 = flag2;
					if (flag4)
					{
						this._lDefaultMailListTemp.Add(cEmailInfo);
					}
				}
			}
			this.InitGridCell();
		}

		// Token: 0x0600034F RID: 847 RVA: 0x000674CC File Offset: 0x000656CC
		private void btnDelete_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.grid_mail.RowsCount - 1; i++)
			{
				bool flag = (bool)this.grid_mail[i + 1, 1].Value;
				if (flag)
				{
					for (int j = 0; j < this._lDefaultMailListTemp.Count; j++)
					{
						bool flag2 = this._lDefaultMailListTemp[j]._sEmail.CompareTo(this.grid_mail[i + 1, 0].Value.ToString()) == 0;
						if (flag2)
						{
							this._lDefaultMailListTemp.RemoveAt(j);
							break;
						}
					}
				}
			}
			this.InitGridCell();
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0006758C File Offset: 0x0006578C
		public object getEmailList()
		{
			return this._lDefaultMailList;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x000675A4 File Offset: 0x000657A4
		public object getCCEmailList()
		{
			return this._lCCMailList;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void grid_TempMail_DoubleClick(object sender, EventArgs e)
		{
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void grid_mail_DoubleClick(object sender, EventArgs e)
		{
		}

		// Token: 0x06000354 RID: 852 RVA: 0x000675BC File Offset: 0x000657BC
		private void btnCCAppend_Click(object sender, EventArgs e)
		{
			bool visible = this.pnCCInfo.Visible;
			if (visible)
			{
				this.pnCCInfo.Visible = false;
			}
			for (int i = 0; i < this.grid_TempMail.RowsCount - 1; i++)
			{
				bool flag = (bool)this.grid_TempMail[i + 1, 1].Value;
				if (flag)
				{
					bool flag2 = true;
					string text = this.grid_TempMail[i + 1, 0].Value.ToString();
					cEmailInfo cEmailInfo = new cEmailInfo();
					cEmailInfo._sEmail = text;
					for (int j = 0; j < this._lCCMailList.Count; j++)
					{
						bool flag3 = this._lCCMailList[j]._sEmail.CompareTo(text) == 0;
						if (flag3)
						{
							MessageBox.Show(text + MessageLanguage.getMessage("check_alreay_exist"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							flag2 = false;
							break;
						}
					}
					bool flag4 = flag2;
					if (flag4)
					{
						this._lCCMailList.Add(cEmailInfo);
					}
				}
			}
			this.InitGridCell();
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000676E8 File Offset: 0x000658E8
		private void btnCCDelete_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.grid_CCMail.RowsCount - 1; i++)
			{
				bool flag = (bool)this.grid_CCMail[i + 1, 1].Value;
				if (flag)
				{
					for (int j = 0; j < this._lCCMailList.Count; j++)
					{
						bool flag2 = this._lCCMailList[j]._sEmail.CompareTo(this.grid_CCMail[i + 1, 0].Value.ToString()) == 0;
						if (flag2)
						{
							this._lCCMailList.RemoveAt(j);
							break;
						}
					}
				}
			}
			this.InitGridCell();
		}

		// Token: 0x06000356 RID: 854 RVA: 0x000677A6 File Offset: 0x000659A6
		private void pbApply_Click(object sender, EventArgs e)
		{
			this.pbApply.Image = Resources.apply;
			this.btnOK_Click(null, null);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x000677C3 File Offset: 0x000659C3
		private void pbCancel_Click(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
			this.btnClose_Click(null, null);
		}

		// Token: 0x04000579 RID: 1401
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x0400057A RID: 1402
		private string _sCategory = string.Empty;

		// Token: 0x0400057B RID: 1403
		private string _sPart = string.Empty;

		// Token: 0x0400057C RID: 1404
		private List<string> _lMailList = new List<string>();

		// Token: 0x0400057D RID: 1405
		private List<cEmailInfo> _lDefaultMailList = new List<cEmailInfo>();

		// Token: 0x0400057E RID: 1406
		private List<cEmailInfo> _lCCMailList = new List<cEmailInfo>();

		// Token: 0x0400057F RID: 1407
		private List<cEmailInfo> _lDefaultMailListTemp;
	}
}
