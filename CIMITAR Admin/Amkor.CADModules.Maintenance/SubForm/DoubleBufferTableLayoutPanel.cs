using System;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x02000011 RID: 17
	internal class DoubleBufferTableLayoutPanel : TableLayoutPanel
	{
		// Token: 0x06000140 RID: 320 RVA: 0x0003E414 File Offset: 0x0003C614
		public DoubleBufferTableLayoutPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
		}
	}
}
