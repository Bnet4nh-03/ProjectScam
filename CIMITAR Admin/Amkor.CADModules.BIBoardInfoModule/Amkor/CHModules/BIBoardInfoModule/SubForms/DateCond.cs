using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.BIBoardInfoModule.Properties;

namespace Amkor.CHModules.BIBoardInfoModule.SubForms
{
	// Token: 0x0200001A RID: 26
	public partial class DateCond : Form
	{
		// Token: 0x06000034 RID: 52 RVA: 0x000055AF File Offset: 0x000037AF
		public DateCond()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000055C0 File Offset: 0x000037C0
		private void DateCond_Load(object sender, EventArgs e)
		{
			this.dtPicker_DateFrom.Value = DateTime.Now.AddDays(-7.0);
			this.dtPicker_DateTo.Value = DateTime.Now;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000055FE File Offset: 0x000037FE
		private void DateCond_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00005610 File Offset: 0x00003810
		private void pb_SearchInfo_All_MouseDown(object sender, MouseEventArgs e)
		{
			this.pb_SearchInfo_All.Image = Resources.TableSearch_Down;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005624 File Offset: 0x00003824
		private void pb_SearchInfo_All_MouseUp(object sender, MouseEventArgs e)
		{
			this.pb_SearchInfo_All.Image = Resources.TableSearch;
			this._dateFrom = this.dtPicker_DateFrom.Value.ToString("yyyy-MM-dd");
			this._dateTo = this.dtPicker_DateTo.Value.ToString("yyyy-MM-dd");
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00005684 File Offset: 0x00003884
		private void btn_aWeek_Click(object sender, EventArgs e)
		{
			this._dateFrom = DateTime.Now.AddDays(-7.0).ToString("yyyy-MM-dd");
			this._dateTo = DateTime.Now.ToString("yyyy-MM-dd");
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000056DC File Offset: 0x000038DC
		private void btn_aMonth_Click(object sender, EventArgs e)
		{
			this._dateFrom = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
			this._dateTo = DateTime.Now.ToString("yyyy-MM-dd");
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000572C File Offset: 0x0000392C
		private void btn_threeMonth_Click(object sender, EventArgs e)
		{
			this._dateFrom = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
			this._dateTo = DateTime.Now.ToString("yyyy-MM-dd");
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000577C File Offset: 0x0000397C
		private void btn_sixMonth_Click(object sender, EventArgs e)
		{
			this._dateFrom = DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd");
			this._dateTo = DateTime.Now.ToString("yyyy-MM-dd");
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000057CC File Offset: 0x000039CC
		private void btn_oneYear_Click(object sender, EventArgs e)
		{
			this._dateFrom = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
			this._dateTo = DateTime.Now.ToString("yyyy-MM-dd");
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x040000BE RID: 190
		public string _dateFrom;

		// Token: 0x040000BF RID: 191
		public string _dateTo;
	}
}
