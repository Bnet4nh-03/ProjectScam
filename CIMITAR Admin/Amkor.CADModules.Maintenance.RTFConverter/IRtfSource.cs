using System;
using System.IO;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200002F RID: 47
	public interface IRtfSource
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060000D5 RID: 213
		TextReader Reader { get; }
	}
}
