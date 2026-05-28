using System;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200003F RID: 63
	internal class SiteMapToolStripLabel : ToolStripLabel
	{
		// Token: 0x060003D3 RID: 979 RVA: 0x0007228E File Offset: 0x0007048E
		public SiteMapToolStripLabel(string title)
		{
			this.Size = new Size(161, 25);
			base.AutoSize = false;
			this.TextAlign = ContentAlignment.MiddleCenter;
			this.Text = title;
		}
	}
}
