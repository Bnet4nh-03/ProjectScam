using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Parser
{
	// Token: 0x0200006E RID: 110
	public class RtfParserLoggerSettings
	{
		// Token: 0x0600031A RID: 794 RVA: 0x00008EE4 File Offset: 0x000070E4
		public RtfParserLoggerSettings() : this(true)
		{
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00008EF0 File Offset: 0x000070F0
		public RtfParserLoggerSettings(bool enabled)
		{
			this.Enabled = enabled;
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00008F83 File Offset: 0x00007183
		// (set) Token: 0x0600031D RID: 797 RVA: 0x00008F8B File Offset: 0x0000718B
		public bool Enabled { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00008F94 File Offset: 0x00007194
		// (set) Token: 0x0600031F RID: 799 RVA: 0x00008FAC File Offset: 0x000071AC
		public string ParseBeginText
		{
			get
			{
				return this.parseBeginText;
			}
			set
			{
				this.parseBeginText = value;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000320 RID: 800 RVA: 0x00008FB8 File Offset: 0x000071B8
		// (set) Token: 0x06000321 RID: 801 RVA: 0x00008FD0 File Offset: 0x000071D0
		public string ParseEndText
		{
			get
			{
				return this.parseEndText;
			}
			set
			{
				this.parseEndText = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000322 RID: 802 RVA: 0x00008FDC File Offset: 0x000071DC
		// (set) Token: 0x06000323 RID: 803 RVA: 0x00008FF4 File Offset: 0x000071F4
		public string ParseGroupBeginText
		{
			get
			{
				return this.parseGroupBeginText;
			}
			set
			{
				this.parseGroupBeginText = value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000324 RID: 804 RVA: 0x00009000 File Offset: 0x00007200
		// (set) Token: 0x06000325 RID: 805 RVA: 0x00009018 File Offset: 0x00007218
		public string ParseGroupEndText
		{
			get
			{
				return this.parseGroupEndText;
			}
			set
			{
				this.parseGroupEndText = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000326 RID: 806 RVA: 0x00009024 File Offset: 0x00007224
		// (set) Token: 0x06000327 RID: 807 RVA: 0x0000903C File Offset: 0x0000723C
		public string ParseTagText
		{
			get
			{
				return this.parseTagText;
			}
			set
			{
				this.parseTagText = value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000328 RID: 808 RVA: 0x00009048 File Offset: 0x00007248
		// (set) Token: 0x06000329 RID: 809 RVA: 0x00009060 File Offset: 0x00007260
		public string TextOverflowText
		{
			get
			{
				return this.textOverflowText;
			}
			set
			{
				this.textOverflowText = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000906C File Offset: 0x0000726C
		// (set) Token: 0x0600032B RID: 811 RVA: 0x00009084 File Offset: 0x00007284
		public string ParseTextText
		{
			get
			{
				return this.parseTextText;
			}
			set
			{
				this.parseTextText = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600032C RID: 812 RVA: 0x00009090 File Offset: 0x00007290
		// (set) Token: 0x0600032D RID: 813 RVA: 0x000090A8 File Offset: 0x000072A8
		public string ParseSuccessText
		{
			get
			{
				return this.parseSuccessText;
			}
			set
			{
				this.parseSuccessText = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600032E RID: 814 RVA: 0x000090B4 File Offset: 0x000072B4
		// (set) Token: 0x0600032F RID: 815 RVA: 0x000090CC File Offset: 0x000072CC
		public string ParseFailKnownReasonText
		{
			get
			{
				return this.parseFailKnownReasonText;
			}
			set
			{
				this.parseFailKnownReasonText = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000330 RID: 816 RVA: 0x000090D8 File Offset: 0x000072D8
		// (set) Token: 0x06000331 RID: 817 RVA: 0x000090F0 File Offset: 0x000072F0
		public string ParseFailUnknownReasonText
		{
			get
			{
				return this.parseFailUnknownReasonText;
			}
			set
			{
				this.parseFailUnknownReasonText = value;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000332 RID: 818 RVA: 0x000090FC File Offset: 0x000072FC
		// (set) Token: 0x06000333 RID: 819 RVA: 0x00009114 File Offset: 0x00007314
		public int TextMaxLength
		{
			get
			{
				return this.textMaxLength;
			}
			set
			{
				this.textMaxLength = value;
			}
		}

		// Token: 0x0400012F RID: 303
		private string parseBeginText = Strings.LogParseBegin;

		// Token: 0x04000130 RID: 304
		private string parseEndText = Strings.LogParseEnd;

		// Token: 0x04000131 RID: 305
		private string parseGroupBeginText = Strings.LogGroupBegin;

		// Token: 0x04000132 RID: 306
		private string parseGroupEndText = Strings.LogGroupEnd;

		// Token: 0x04000133 RID: 307
		private string parseTagText = Strings.LogTag;

		// Token: 0x04000134 RID: 308
		private string parseTextText = Strings.LogText;

		// Token: 0x04000135 RID: 309
		private string textOverflowText = Strings.LogOverflowText;

		// Token: 0x04000136 RID: 310
		private string parseSuccessText = Strings.LogParseSuccess;

		// Token: 0x04000137 RID: 311
		private string parseFailKnownReasonText = Strings.LogParseFail;

		// Token: 0x04000138 RID: 312
		private string parseFailUnknownReasonText = Strings.LogParseFailUnknown;

		// Token: 0x04000139 RID: 313
		private int textMaxLength = 80;
	}
}
