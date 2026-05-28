using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.Properties;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000033 RID: 51
	public partial class HoldForm : Form
	{
		// Token: 0x0600032F RID: 815 RVA: 0x00065E84 File Offset: 0x00064084
		private void pbCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel_down;
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00065E97 File Offset: 0x00064097
		private void pbCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00065EAA File Offset: 0x000640AA
		private void pbHold_MouseEnter(object sender, EventArgs e)
		{
			this.pbHold.Image = Resources.hold_down;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00065EBD File Offset: 0x000640BD
		private void pbHold_MouseLeave(object sender, EventArgs e)
		{
			this.pbHold.Image = Resources.hold;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00065ED0 File Offset: 0x000640D0
		public string getHoldComment()
		{
			return this.rb_HoldComment.Text;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00065EE0 File Offset: 0x000640E0
		public HoldForm()
		{
			this.InitializeComponent();
			this.rbHoldComment.Text = MessageLanguage.getMessage("hold_comment");
			this.rb_HoldComment.Text = this.msg;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00065F3C File Offset: 0x0006413C
		private void btn_OK_Click(object sender, EventArgs e)
		{
			bool flag = this.rb_HoldComment.Text == string.Empty || this.rb_HoldComment.Text == this.msg;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("check_comment"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00065047 File Offset: 0x00063247
		private void btn_Cancle_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00065FA8 File Offset: 0x000641A8
		private void rb_HoldComment_Click(object sender, EventArgs e)
		{
			bool flag = this.rb_HoldComment.Text == this.msg;
			if (flag)
			{
				this.rb_HoldComment.Text = string.Empty;
			}
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00065FE1 File Offset: 0x000641E1
		private void pbCancel_Click(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00066004 File Offset: 0x00064204
		private void pbHold_Click(object sender, EventArgs e)
		{
			this.pbHold.Image = Resources.hold;
			this.btn_OK_Click(null, null);
			base.Close();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00066028 File Offset: 0x00064228
		private void rb_HoldComment_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.rb_HoldComment.Text == this.msg;
			if (flag)
			{
				this.rb_HoldComment.Text = string.Empty;
			}
		}

		// Token: 0x04000566 RID: 1382
		private readonly string msg = MessageLanguage.getMessage("hold_tip");
	}
}
