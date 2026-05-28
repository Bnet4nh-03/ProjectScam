using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200002E RID: 46
	public interface IRtfParserListener
	{
		// Token: 0x060000CD RID: 205
		void ParseBegin();

		// Token: 0x060000CE RID: 206
		void GroupBegin();

		// Token: 0x060000CF RID: 207
		void TagFound(IRtfTag tag);

		// Token: 0x060000D0 RID: 208
		void TextFound(IRtfText text);

		// Token: 0x060000D1 RID: 209
		void GroupEnd();

		// Token: 0x060000D2 RID: 210
		void ParseSuccess();

		// Token: 0x060000D3 RID: 211
		void ParseFail(RtfException reason);

		// Token: 0x060000D4 RID: 212
		void ParseEnd();
	}
}
