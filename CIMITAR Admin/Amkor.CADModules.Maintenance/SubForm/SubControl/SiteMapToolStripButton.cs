using System;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000041 RID: 65
	internal class SiteMapToolStripButton : ToolStripButton
	{
		// Token: 0x060003D6 RID: 982 RVA: 0x000723A5 File Offset: 0x000705A5
		public SiteMapToolStripButton(string title)
		{
			this.Text = title;
			base.AutoSize = false;
			this.Size = new Size(161, 25);
			this.TextAlign = ContentAlignment.MiddleCenter;
		}
	}
}
