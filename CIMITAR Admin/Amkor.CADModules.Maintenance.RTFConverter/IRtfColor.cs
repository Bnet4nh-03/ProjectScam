using System;
using System.Drawing;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000003 RID: 3
	public interface IRtfColor
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600001C RID: 28
		int Red { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600001D RID: 29
		int Green { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600001E RID: 30
		int Blue { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600001F RID: 31
		Color AsDrawingColor { get; }
	}
}
