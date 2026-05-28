using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000077 RID: 119
	public sealed class RtfDocument : IRtfDocument
	{
		// Token: 0x06000371 RID: 881 RVA: 0x000099B4 File Offset: 0x00007BB4
		public RtfDocument(IRtfInterpreterContext context, IRtfVisualCollection visualContent) : this(context.RtfVersion, context.DefaultFont, context.FontTable, context.ColorTable, context.Generator, context.UniqueTextFormats, context.DocumentInfo, context.UserProperties, visualContent)
		{
		}

		// Token: 0x06000372 RID: 882 RVA: 0x000099FC File Offset: 0x00007BFC
		public RtfDocument(int rtfVersion, IRtfFont defaultFont, IRtfFontCollection fontTable, IRtfColorCollection colorTable, string generator, IRtfTextFormatCollection uniqueTextFormats, IRtfDocumentInfo documentInfo, IRtfDocumentPropertyCollection userProperties, IRtfVisualCollection visualContent)
		{
			bool flag = rtfVersion != 1;
			if (flag)
			{
				throw new RtfUnsupportedStructureException(Strings.UnsupportedRtfVersion(rtfVersion));
			}
			bool flag2 = defaultFont == null;
			if (flag2)
			{
				throw new ArgumentNullException("defaultFont");
			}
			bool flag3 = fontTable == null;
			if (flag3)
			{
				throw new ArgumentNullException("fontTable");
			}
			bool flag4 = colorTable == null;
			if (flag4)
			{
				throw new ArgumentNullException("colorTable");
			}
			bool flag5 = uniqueTextFormats == null;
			if (flag5)
			{
				throw new ArgumentNullException("uniqueTextFormats");
			}
			bool flag6 = documentInfo == null;
			if (flag6)
			{
				throw new ArgumentNullException("documentInfo");
			}
			bool flag7 = userProperties == null;
			if (flag7)
			{
				throw new ArgumentNullException("userProperties");
			}
			bool flag8 = visualContent == null;
			if (flag8)
			{
				throw new ArgumentNullException("visualContent");
			}
			this.rtfVersion = rtfVersion;
			this.defaultFont = defaultFont;
			this.defaultTextFormat = new RtfTextFormat(defaultFont, 24);
			this.fontTable = fontTable;
			this.colorTable = colorTable;
			this.generator = generator;
			this.uniqueTextFormats = uniqueTextFormats;
			this.documentInfo = documentInfo;
			this.userProperties = userProperties;
			this.visualContent = visualContent;
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00009B18 File Offset: 0x00007D18
		public int RtfVersion
		{
			get
			{
				return this.rtfVersion;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000374 RID: 884 RVA: 0x00009B30 File Offset: 0x00007D30
		public IRtfFont DefaultFont
		{
			get
			{
				return this.defaultFont;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000375 RID: 885 RVA: 0x00009B48 File Offset: 0x00007D48
		public IRtfTextFormat DefaultTextFormat
		{
			get
			{
				return this.defaultTextFormat;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000376 RID: 886 RVA: 0x00009B60 File Offset: 0x00007D60
		public IRtfFontCollection FontTable
		{
			get
			{
				return this.fontTable;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000377 RID: 887 RVA: 0x00009B78 File Offset: 0x00007D78
		public IRtfColorCollection ColorTable
		{
			get
			{
				return this.colorTable;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000378 RID: 888 RVA: 0x00009B90 File Offset: 0x00007D90
		public string Generator
		{
			get
			{
				return this.generator;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00009BA8 File Offset: 0x00007DA8
		public IRtfTextFormatCollection UniqueTextFormats
		{
			get
			{
				return this.uniqueTextFormats;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00009BC0 File Offset: 0x00007DC0
		public IRtfDocumentInfo DocumentInfo
		{
			get
			{
				return this.documentInfo;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600037B RID: 891 RVA: 0x00009BD8 File Offset: 0x00007DD8
		public IRtfDocumentPropertyCollection UserProperties
		{
			get
			{
				return this.userProperties;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600037C RID: 892 RVA: 0x00009BF0 File Offset: 0x00007DF0
		public IRtfVisualCollection VisualContent
		{
			get
			{
				return this.visualContent;
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00009C08 File Offset: 0x00007E08
		public override string ToString()
		{
			return "RTFv" + this.rtfVersion;
		}

		// Token: 0x04000146 RID: 326
		private readonly int rtfVersion;

		// Token: 0x04000147 RID: 327
		private readonly IRtfFont defaultFont;

		// Token: 0x04000148 RID: 328
		private readonly IRtfTextFormat defaultTextFormat;

		// Token: 0x04000149 RID: 329
		private readonly IRtfFontCollection fontTable;

		// Token: 0x0400014A RID: 330
		private readonly IRtfColorCollection colorTable;

		// Token: 0x0400014B RID: 331
		private readonly string generator;

		// Token: 0x0400014C RID: 332
		private readonly IRtfTextFormatCollection uniqueTextFormats;

		// Token: 0x0400014D RID: 333
		private readonly IRtfDocumentInfo documentInfo;

		// Token: 0x0400014E RID: 334
		private readonly IRtfDocumentPropertyCollection userProperties;

		// Token: 0x0400014F RID: 335
		private readonly IRtfVisualCollection visualContent;
	}
}
