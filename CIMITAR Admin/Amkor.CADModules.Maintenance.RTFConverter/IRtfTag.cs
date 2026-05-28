using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000030 RID: 48
	public interface IRtfTag : IRtfElement
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060000D6 RID: 214
		string FullName { get; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060000D7 RID: 215
		string Name { get; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060000D8 RID: 216
		bool HasValue { get; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060000D9 RID: 217
		string ValueAsText { get; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060000DA RID: 218
		int ValueAsNumber { get; }
	}
}
