using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000015 RID: 21
	public interface IRtfVisualSpecialChar : IRtfVisual
	{
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000095 RID: 149
		RtfVisualSpecialCharKind CharKind { get; }
	}
}
