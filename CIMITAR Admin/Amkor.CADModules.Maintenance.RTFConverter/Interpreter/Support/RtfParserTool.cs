using System;
using System.IO;
using Amkor.CADModules.Maintenance.RTFConverter.Parser;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support
{
	// Token: 0x02000073 RID: 115
	public static class RtfParserTool
	{
		// Token: 0x06000359 RID: 857 RVA: 0x0000954C File Offset: 0x0000774C
		public static IRtfGroup Parse(string rtfText, params IRtfParserListener[] listeners)
		{
			return RtfParserTool.Parse(new RtfSource(rtfText), listeners);
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000956C File Offset: 0x0000776C
		public static IRtfGroup Parse(TextReader rtfTextSource, params IRtfParserListener[] listeners)
		{
			return RtfParserTool.Parse(new RtfSource(rtfTextSource), listeners);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000958C File Offset: 0x0000778C
		public static IRtfGroup Parse(Stream rtfTextSource, params IRtfParserListener[] listeners)
		{
			return RtfParserTool.Parse(new RtfSource(rtfTextSource), listeners);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000095AC File Offset: 0x000077AC
		public static IRtfGroup Parse(IRtfSource rtfTextSource, params IRtfParserListener[] listeners)
		{
			RtfParserListenerStructureBuilder rtfParserListenerStructureBuilder = new RtfParserListenerStructureBuilder();
			RtfParser rtfParser = new RtfParser(new IRtfParserListener[]
			{
				rtfParserListenerStructureBuilder
			});
			bool flag = listeners != null;
			if (flag)
			{
				foreach (IRtfParserListener rtfParserListener in listeners)
				{
					bool flag2 = rtfParserListener != null;
					if (flag2)
					{
						rtfParser.AddParserListener(rtfParserListener);
					}
				}
			}
			rtfParser.Parse(rtfTextSource);
			return rtfParserListenerStructureBuilder.StructureRoot;
		}
	}
}
