using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.ManufactureHistory.Class;

namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x02000010 RID: 16
	public partial class Login : Form
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00005A32 File Offset: 0x00003C32
		public Login()
		{
			this.InitializeComponent();
			base.DialogResult = DialogResult.No;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00005A60 File Offset: 0x00003C60
		private void btnLogin_Click(object sender, EventArgs e)
		{
			if (CIMitarLogin.Login(this.tbID.Text.Trim(), this.tbPassword.Text.Trim()) == 0)
			{
				this.id = this.tbID.Text.Trim();
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
			else
			{
				MessageBox.Show("Please check your id or password.");
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00005AD4 File Offset: 0x00003CD4
		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (string.IsNullOrEmpty(this.id))
			{
				base.DialogResult = DialogResult.No;
			}
		}

		// Token: 0x0400002A RID: 42
		public string id = string.Empty;
	}
}
