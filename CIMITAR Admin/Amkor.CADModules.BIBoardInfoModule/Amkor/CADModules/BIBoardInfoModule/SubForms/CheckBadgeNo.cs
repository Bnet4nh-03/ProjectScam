using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000025 RID: 37
	public partial class CheckBadgeNo : Form
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x00013616 File Offset: 0x00011816
		public CheckBadgeNo()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0001363A File Offset: 0x0001183A
		public CheckBadgeNo(string badgeNo)
		{
			this.InitializeComponent();
			this._badgeNo = badgeNo;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00013668 File Offset: 0x00011868
		public CheckBadgeNo(string badgeNo, string comment, bool isPM)
		{
			this.InitializeComponent();
			this._badgeNo = badgeNo;
			this._comment = comment;
			if (isPM)
			{
				this.lbl_Comment.Visible = false;
				this.rtb_Comment.Visible = false;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000136C0 File Offset: 0x000118C0
		private void CheckBadgeNo_Load(object sender, EventArgs e)
		{
			if (this._badgeNo != "")
			{
				this.tb_BadgeNo.Text = this._badgeNo;
			}
			if (this._comment != "")
			{
				this.rtb_Comment.Text = this._comment;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000055FE File Offset: 0x000037FE
		private void CheckBadgeNo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00013714 File Offset: 0x00011914
		private void btn_Confirm_Click(object sender, EventArgs e)
		{
			this._badgeNo = this.tb_BadgeNo.Text.Trim();
			this._comment = this.rtb_Comment.Text.Trim();
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [dbo].[USP_Get_OperatorInfo] @flag = 'NUM', @badgeNo = '" + this._badgeNo + "'";
			dataSet = BIBoardInfoModule._instance.QueryCall(sQuery);
			if (dataSet.Tables.Count == 0)
			{
				MessageBox.Show("Fail to check!");
				return;
			}
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				MessageBox.Show("Invalid Badge Number!");
				return;
			}
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x04000195 RID: 405
		public string _badgeNo = string.Empty;

		// Token: 0x04000196 RID: 406
		public string _comment = string.Empty;
	}
}
