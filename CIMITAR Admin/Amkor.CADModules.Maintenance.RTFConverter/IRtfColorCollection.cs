using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000004 RID: 4
	public interface IRtfColorCollection : IEnumerable
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000020 RID: 32
		int Count { get; }

		// Token: 0x17000019 RID: 25
		IRtfColor this[int index]
		{
			get;
		}

		// Token: 0x06000022 RID: 34
		void CopyTo(IRtfColor[] array, int index);
	}
}
