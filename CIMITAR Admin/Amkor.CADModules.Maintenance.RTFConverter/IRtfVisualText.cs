using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000016 RID: 22
	public interface IRtfVisualText : IRtfVisual
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000096 RID: 150
		string Text { get; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000097 RID: 151
		IRtfTextFormat Format { get; }
	}
}
