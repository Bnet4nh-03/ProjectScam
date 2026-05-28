using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000012 RID: 18
	public interface IRtfVisualBreak : IRtfVisual
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000086 RID: 134
		RtfVisualBreakKind BreakKind { get; }
	}
}
