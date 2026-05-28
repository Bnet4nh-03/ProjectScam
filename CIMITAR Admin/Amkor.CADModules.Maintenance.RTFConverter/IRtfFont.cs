using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000009 RID: 9
	public interface IRtfFont
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600004C RID: 76
		string Id { get; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600004D RID: 77
		RtfFontKind Kind { get; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600004E RID: 78
		RtfFontPitch Pitch { get; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600004F RID: 79
		int CharSet { get; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000050 RID: 80
		int CodePage { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000051 RID: 81
		string Name { get; }
	}
}
