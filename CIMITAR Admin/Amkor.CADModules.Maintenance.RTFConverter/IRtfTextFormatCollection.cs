using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000010 RID: 16
	public interface IRtfTextFormatCollection : IEnumerable
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600007F RID: 127
		int Count { get; }

		// Token: 0x17000066 RID: 102
		IRtfTextFormat this[int index]
		{
			get;
		}

		// Token: 0x06000081 RID: 129
		bool Contains(IRtfTextFormat format);

		// Token: 0x06000082 RID: 130
		int IndexOf(IRtfTextFormat format);

		// Token: 0x06000083 RID: 131
		void CopyTo(IRtfTextFormat[] array, int index);
	}
}
