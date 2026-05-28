using System;
using System.IO;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support
{
	// Token: 0x02000074 RID: 116
	public sealed class RtfSource : IRtfSource
	{
		// Token: 0x0600035D RID: 861 RVA: 0x00009624 File Offset: 0x00007824
		public RtfSource(string rtf)
		{
			bool flag = rtf == null;
			if (flag)
			{
				throw new ArgumentNullException("rtf");
			}
			this.reader = new StringReader(rtf);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000965C File Offset: 0x0000785C
		public RtfSource(TextReader rtf)
		{
			bool flag = rtf == null;
			if (flag)
			{
				throw new ArgumentNullException("rtf");
			}
			this.reader = rtf;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000968C File Offset: 0x0000788C
		public RtfSource(Stream rtf)
		{
			bool flag = rtf == null;
			if (flag)
			{
				throw new ArgumentNullException("rtf");
			}
			this.reader = new StreamReader(rtf, RtfSpec.AnsiEncoding);
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000360 RID: 864 RVA: 0x000096C8 File Offset: 0x000078C8
		public TextReader Reader
		{
			get
			{
				return this.reader;
			}
		}

		// Token: 0x0400013F RID: 319
		private readonly TextReader reader;
	}
}
