using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Properties;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000032 RID: 50
	public partial class HoldInfoForm : Form
	{
		// Token: 0x06000328 RID: 808 RVA: 0x00065047 File Offset: 0x00063247
		private void btn_Cancle_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00065051 File Offset: 0x00063251
		private void pbCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00065064 File Offset: 0x00063264
		private void pbCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel_down;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00065078 File Offset: 0x00063278
		public HoldInfoForm(string depart, string name, string time, string comment)
		{
			this.InitializeComponent();
			bool flag = string.IsNullOrEmpty(comment);
			if (flag)
			{
				base.Close();
			}
			else
			{
				this.tbHoldTeam.Text = depart;
				this.tbHoldName.Text = name;
				this.tbHoldTime.Text = Convert.ToDateTime(time).ToString("yyy-MM-dd HH:mm:ss");
				this.rbHoldComment.Text = comment;
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x000650F7 File Offset: 0x000632F7
		private void pbCancel_Click(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
			this.btn_Cancle_Click(null, null);
			base.Close();
		}
	}
}
