using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Collection
{
	// Token: 0x0200005C RID: 92
	public interface IStringCollection : IEnumerable
	{
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000268 RID: 616
		int Count { get; }

		// Token: 0x170000EA RID: 234
		string this[int index]
		{
			get;
		}

		// Token: 0x0600026A RID: 618
		void CopyTo(string[] array, int index);

		// Token: 0x0600026B RID: 619
		int IndexOf(string test);

		// Token: 0x0600026C RID: 620
		bool Contains(string test);

		// Token: 0x0600026D RID: 621
		string FormatCommaSeparated();
	}
}
