using System;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200003E RID: 62
	internal class DoubleBufferCheckBox : CheckBox
	{
		// Token: 0x060003D2 RID: 978 RVA: 0x00072254 File Offset: 0x00070454
		public DoubleBufferCheckBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
		}

		// Token: 0x04000611 RID: 1553
		public bool isCol = false;

		// Token: 0x04000612 RID: 1554
		public bool isRow = false;

		// Token: 0x04000613 RID: 1555
		public int colPosition = 0;

		// Token: 0x04000614 RID: 1556
		public int rowPosition = 0;
	}
}
