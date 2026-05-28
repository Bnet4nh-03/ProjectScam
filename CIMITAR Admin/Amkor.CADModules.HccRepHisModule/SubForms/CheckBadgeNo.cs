using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.HccRepHisModule.SubForms
{
	// Token: 0x02000008 RID: 8
	public partial class CheckBadgeNo : Form
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00003741 File Offset: 0x00001941
		public CheckBadgeNo()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003765 File Offset: 0x00001965
		public CheckBadgeNo(string badgeNo)
		{
			this.InitializeComponent();
			this._badgeNo = badgeNo;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003790 File Offset: 0x00001990
		private void CheckBadgeNo_Load(object sender, EventArgs e)
		{
			if (this._badgeNo != "")
			{
				this.tb_BadgeNo.Text = this._badgeNo;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000037B8 File Offset: 0x000019B8
		private void btn_Confirm_Click(object sender, EventArgs e)
		{
			this._badgeNo = this.tb_BadgeNo.Text.Trim();
			this._comment = this.rtb_Comment.Text.Trim();
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [CIMitar_HCC].[dbo].[USP_Get_OperatorInfo] @flag = 'NUM', @badgeNo = '" + this._badgeNo + "'";
			dataSet = HccRepHisModule._instance.QueryCall(sQuery);
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

		// Token: 0x0400001C RID: 28
		public string _badgeNo = string.Empty;

		// Token: 0x0400001D RID: 29
		public string _comment = string.Empty;
	}
}
