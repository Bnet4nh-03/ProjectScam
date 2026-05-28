using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200002A RID: 42
	public interface IRtfElementCollection : IEnumerable
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060000BE RID: 190
		int Count { get; }

		// Token: 0x1700007B RID: 123
		IRtfElement this[int index]
		{
			get;
		}

		// Token: 0x060000C0 RID: 192
		void CopyTo(IRtfElement[] array, int index);
	}
}
