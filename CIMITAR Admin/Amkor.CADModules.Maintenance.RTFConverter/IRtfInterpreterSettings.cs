using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200000E RID: 14
	public interface IRtfInterpreterSettings
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600006E RID: 110
		// (set) Token: 0x0600006F RID: 111
		bool IgnoreDuplicatedFonts { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000070 RID: 112
		// (set) Token: 0x06000071 RID: 113
		bool IgnoreUnknownFonts { get; set; }
	}
}
