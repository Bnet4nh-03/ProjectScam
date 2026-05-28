using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200002D RID: 45
	public interface IRtfParser
	{
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060000C8 RID: 200
		// (set) Token: 0x060000C9 RID: 201
		bool IgnoreContentAfterRootGroup { get; set; }

		// Token: 0x060000CA RID: 202
		void AddParserListener(IRtfParserListener listener);

		// Token: 0x060000CB RID: 203
		void RemoveParserListener(IRtfParserListener listener);

		// Token: 0x060000CC RID: 204
		void Parse(IRtfSource rtfTextSource);
	}
}
