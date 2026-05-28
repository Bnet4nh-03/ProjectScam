using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200002C RID: 44
	public interface IRtfGroup : IRtfElement
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060000C4 RID: 196
		IRtfElementCollection Contents { get; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060000C5 RID: 197
		string Destination { get; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060000C6 RID: 198
		bool IsExtensionDestination { get; }

		// Token: 0x060000C7 RID: 199
		IRtfGroup SelectChildGroupWithDestination(string destination);
	}
}
