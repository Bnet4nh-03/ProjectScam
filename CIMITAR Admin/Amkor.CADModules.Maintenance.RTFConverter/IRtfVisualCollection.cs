using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000013 RID: 19
	public interface IRtfVisualCollection : IEnumerable
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000087 RID: 135
		int Count { get; }

		// Token: 0x1700006A RID: 106
		IRtfVisual this[int index]
		{
			get;
		}

		// Token: 0x06000089 RID: 137
		void CopyTo(IRtfVisual[] array, int index);
	}
}
