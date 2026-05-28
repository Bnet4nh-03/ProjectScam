using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.Properties;

namespace Amkor.CADModules.Maintenance.SubForm.MaintReportControl
{
	// Token: 0x0200002D RID: 45
	public partial class Emergency : Form
	{
		// Token: 0x060002DD RID: 733 RVA: 0x00060CAB File Offset: 0x0005EEAB
		public Emergency()
		{
			this.InitializeComponent();
			this.label3.Text = MessageLanguage.getMessage("emergency_comment");
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00060CD9 File Offset: 0x0005EED9
		private void pbCancel_Click(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
			base.Close();
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00060CF4 File Offset: 0x0005EEF4
		private void pbCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00060D07 File Offset: 0x0005EF07
		private void pbCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel_down;
		}
	}
}
