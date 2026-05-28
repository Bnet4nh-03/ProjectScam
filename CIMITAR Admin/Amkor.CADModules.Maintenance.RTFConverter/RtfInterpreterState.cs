using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200001E RID: 30
	public enum RtfInterpreterState
	{
		// Token: 0x04000010 RID: 16
		Init,
		// Token: 0x04000011 RID: 17
		InHeader,
		// Token: 0x04000012 RID: 18
		InDocument,
		// Token: 0x04000013 RID: 19
		Ended
	}
}
