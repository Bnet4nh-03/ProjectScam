using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.Properties;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200002E RID: 46
	public partial class CancelForm : Form
	{
		// Token: 0x060002E3 RID: 739 RVA: 0x00061137 File Offset: 0x0005F337
		public RichTextBox getContent7()
		{
			return this.rbContent7;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0006113F File Offset: 0x0005F33F
		public string getContent7Text()
		{
			return this.rbContent7.Text;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0006114C File Offset: 0x0005F34C
		public CancelForm(bool isPM, bool enable)
		{
			this.InitializeComponent();
			this._isPM = isPM;
			if (enable)
			{
				if (isPM)
				{
					this.rbContent7.Text = this._sCancelInit;
				}
			}
			else
			{
				this.pbOK.Visible = false;
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void CancelForm_Shown(object sender, EventArgs e)
		{
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000611BC File Offset: 0x0005F3BC
		private void rbContent7_Click(object sender, EventArgs e)
		{
			bool flag = this.rbContent7.Text == this._sCancelInit && !this.rbContent7.ReadOnly;
			if (flag)
			{
				this.rbContent7.Text = string.Empty;
			}
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00061208 File Offset: 0x0005F408
		private void pbCancel_MouseEnter(object sender, EventArgs e)
		{
			bool flag = ((PictureBox)sender).Equals(this.pbCancel);
			if (flag)
			{
				((PictureBox)sender).Image = Resources.cancel_down;
			}
			else
			{
				((PictureBox)sender).Image = Resources.apply_down;
			}
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00061250 File Offset: 0x0005F450
		private void pbCancel_MouseLeave(object sender, EventArgs e)
		{
			bool flag = ((PictureBox)sender).Equals(this.pbCancel);
			if (flag)
			{
				((PictureBox)sender).Image = Resources.cancel;
			}
			else
			{
				((PictureBox)sender).Image = Resources.apply;
			}
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00061297 File Offset: 0x0005F497
		private void pbCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060002EB RID: 747 RVA: 0x000612AC File Offset: 0x0005F4AC
		private void pbOK_Click(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.apply;
			bool isPM = this._isPM;
			if (isPM)
			{
				bool flag = this.rbContent7.Text.Trim().Length == 0 || this.rbContent7.Text.Trim() == this._sCancelInit;
				if (flag)
				{
					MessageBox.Show(MessageLanguage.getMessage("input_cancel_comment"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					bool flag2 = MessageBox.Show(MessageLanguage.getMessage("check_cancel_comment"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes;
					if (flag2)
					{
						base.DialogResult = DialogResult.OK;
						base.Close();
					}
				}
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0006136C File Offset: 0x0005F56C
		public void seRichTextBox()
		{
			this.rbContent7.ReadOnly = true;
			bool flag = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.rtf");
			if (flag)
			{
				this.rbContent7.Rtf = File.ReadAllText("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.rtf");
			}
			else
			{
				this.rbContent7.Text = string.Empty;
			}
		}

		// Token: 0x04000523 RID: 1315
		private readonly string _sCancelInit = MessageLanguage.getMessage("pm_cancel_tip");

		// Token: 0x04000524 RID: 1316
		private bool _isPM = false;
	}
}
