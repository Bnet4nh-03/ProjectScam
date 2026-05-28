using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000034 RID: 52
	public partial class Login : Form
	{
		// Token: 0x0600033D RID: 829 RVA: 0x000668AA File Offset: 0x00064AAA
		public Login()
		{
			this.InitializeComponent();
			base.DialogResult = DialogResult.No;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000668D8 File Offset: 0x00064AD8
		private void btnLogin_Click(object sender, EventArgs e)
		{
			bool flag = CIMitarLogin.Login(this.tbID.Text.Trim(), this.tbPassword.Text.Trim()) == 0;
			if (flag)
			{
				this.id = this.tbID.Text.Trim();
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
			else
			{
				MessageBox.Show(MessageLanguage.getMessage("check_id_password"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0006695C File Offset: 0x00064B5C
		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = string.IsNullOrEmpty(this.id);
			if (flag)
			{
				base.DialogResult = DialogResult.No;
			}
		}

		// Token: 0x04000571 RID: 1393
		public string id = string.Empty;
	}
}
