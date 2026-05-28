using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Application
{
	// Token: 0x02000062 RID: 98
	[Flags]
	public enum ArgumentType
	{
		// Token: 0x0400010C RID: 268
		None = 0,
		// Token: 0x0400010D RID: 269
		Mandatory = 1,
		// Token: 0x0400010E RID: 270
		HasName = 2,
		// Token: 0x0400010F RID: 271
		ContainsValue = 4
	}
}
