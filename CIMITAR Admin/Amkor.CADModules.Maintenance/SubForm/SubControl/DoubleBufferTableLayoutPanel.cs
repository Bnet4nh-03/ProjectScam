using System;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200003D RID: 61
	internal class DoubleBufferTableLayoutPanel : TableLayoutPanel
	{
		// Token: 0x060003D1 RID: 977 RVA: 0x0003E414 File Offset: 0x0003C614
		public DoubleBufferTableLayoutPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
		}
	}
}
