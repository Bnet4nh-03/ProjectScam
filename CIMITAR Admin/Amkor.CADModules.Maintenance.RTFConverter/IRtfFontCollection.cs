using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200000A RID: 10
	public interface IRtfFontCollection : IEnumerable
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000052 RID: 82
		int Count { get; }

		// Token: 0x06000053 RID: 83
		bool ContainsFontWithId(string fontId);

		// Token: 0x17000049 RID: 73
		IRtfFont this[int index]
		{
			get;
		}

		// Token: 0x1700004A RID: 74
		IRtfFont this[string id]
		{
			get;
		}

		// Token: 0x06000056 RID: 86
		void CopyTo(IRtfFont[] array, int index);
	}
}
