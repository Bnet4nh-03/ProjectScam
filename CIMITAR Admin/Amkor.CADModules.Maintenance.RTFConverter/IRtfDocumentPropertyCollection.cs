using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000008 RID: 8
	public interface IRtfDocumentPropertyCollection : IEnumerable
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000048 RID: 72
		int Count { get; }

		// Token: 0x17000040 RID: 64
		IRtfDocumentProperty this[int index]
		{
			get;
		}

		// Token: 0x17000041 RID: 65
		IRtfDocumentProperty this[string name]
		{
			get;
		}

		// Token: 0x0600004B RID: 75
		void CopyTo(IRtfDocumentProperty[] array, int index);
	}
}
