using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200004E RID: 78
	public partial class ResetReason : Form
	{
		// Token: 0x06000392 RID: 914 RVA: 0x000563BC File Offset: 0x000545BC
		public ResetReason()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000393 RID: 915 RVA: 0x000563D5 File Offset: 0x000545D5
		private void ResultView_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000394 RID: 916 RVA: 0x000563D7 File Offset: 0x000545D7
		private void txtResetReason_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.cmdApply_Click(null, null);
			}
		}

		// Token: 0x06000395 RID: 917 RVA: 0x000563EB File Offset: 0x000545EB
		private void cmdApply_Click(object sender, EventArgs e)
		{
			this.sResult = this.txtResetReason.Text;
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00056405 File Offset: 0x00054605
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			base.Close();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00056414 File Offset: 0x00054614
		private void cmdApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00056431 File Offset: 0x00054631
		private void cmdApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0005644E File Offset: 0x0005464E
		private void cmdApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0005646B File Offset: 0x0005466B
		private void cmdApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00056478 File Offset: 0x00054678
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00056495 File Offset: 0x00054695
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000564B2 File Offset: 0x000546B2
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x000564CF File Offset: 0x000546CF
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x040005D3 RID: 1491
		public FactorySettings _factorySetting;

		// Token: 0x040005D4 RID: 1492
		public CIMitarAccount _cimitarUser;

		// Token: 0x040005D5 RID: 1493
		public string sResult = string.Empty;
	}
}
