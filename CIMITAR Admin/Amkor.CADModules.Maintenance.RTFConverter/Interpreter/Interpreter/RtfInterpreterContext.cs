using System;
using System.Collections;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000092 RID: 146
	public sealed class RtfInterpreterContext : IRtfInterpreterContext
	{
		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000F6DC File Offset: 0x0000D8DC
		// (set) Token: 0x060004A3 RID: 1187 RVA: 0x0000F6F4 File Offset: 0x0000D8F4
		public RtfInterpreterState State
		{
			get
			{
				return this.state;
			}
			set
			{
				this.state = value;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x0000F700 File Offset: 0x0000D900
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x0000F718 File Offset: 0x0000D918
		public int RtfVersion
		{
			get
			{
				return this.rtfVersion;
			}
			set
			{
				this.rtfVersion = value;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0000F724 File Offset: 0x0000D924
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x0000F73C File Offset: 0x0000D93C
		public string DefaultFontId
		{
			get
			{
				return this.defaultFontId;
			}
			set
			{
				this.defaultFontId = value;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0000F748 File Offset: 0x0000D948
		public IRtfFont DefaultFont
		{
			get
			{
				IRtfFont rtfFont = this.fontTable[this.defaultFontId];
				bool flag = rtfFont != null;
				if (flag)
				{
					return rtfFont;
				}
				throw new RtfUndefinedFontException(Strings.InvalidDefaultFont(this.defaultFontId, this.fontTable.ToString()));
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x0000F794 File Offset: 0x0000D994
		public IRtfFontCollection FontTable
		{
			get
			{
				return this.fontTable;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0000F7AC File Offset: 0x0000D9AC
		public RtfFontCollection WritableFontTable
		{
			get
			{
				return this.fontTable;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0000F7C4 File Offset: 0x0000D9C4
		public IRtfColorCollection ColorTable
		{
			get
			{
				return this.colorTable;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0000F7DC File Offset: 0x0000D9DC
		public RtfColorCollection WritableColorTable
		{
			get
			{
				return this.colorTable;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000F7F4 File Offset: 0x0000D9F4
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x0000F80C File Offset: 0x0000DA0C
		public string Generator
		{
			get
			{
				return this.generator;
			}
			set
			{
				this.generator = value;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x0000F818 File Offset: 0x0000DA18
		public IRtfTextFormatCollection UniqueTextFormats
		{
			get
			{
				return this.uniqueTextFormats;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x0000F830 File Offset: 0x0000DA30
		public IRtfTextFormat CurrentTextFormat
		{
			get
			{
				return this.currentTextFormat;
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0000F848 File Offset: 0x0000DA48
		public IRtfTextFormat GetSafeCurrentTextFormat()
		{
			return this.currentTextFormat ?? this.WritableCurrentTextFormat;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0000F86C File Offset: 0x0000DA6C
		public IRtfTextFormat GetUniqueTextFormatInstance(IRtfTextFormat templateFormat)
		{
			bool flag = templateFormat == null;
			if (flag)
			{
				throw new ArgumentNullException("templateFormat");
			}
			int num = this.uniqueTextFormats.IndexOf(templateFormat);
			bool flag2 = num >= 0;
			IRtfTextFormat result;
			if (flag2)
			{
				result = this.uniqueTextFormats[num];
			}
			else
			{
				this.uniqueTextFormats.Add(templateFormat);
				result = templateFormat;
			}
			return result;
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x0000F8D0 File Offset: 0x0000DAD0
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x0000F90B File Offset: 0x0000DB0B
		public RtfTextFormat WritableCurrentTextFormat
		{
			get
			{
				bool flag = this.currentTextFormat == null;
				if (flag)
				{
					this.WritableCurrentTextFormat = new RtfTextFormat(this.DefaultFont, 24);
				}
				return this.currentTextFormat;
			}
			set
			{
				this.currentTextFormat = (RtfTextFormat)this.GetUniqueTextFormatInstance(value);
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060004B5 RID: 1205 RVA: 0x0000F920 File Offset: 0x0000DB20
		public IRtfDocumentInfo DocumentInfo
		{
			get
			{
				return this.documentInfo;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0000F938 File Offset: 0x0000DB38
		public RtfDocumentInfo WritableDocumentInfo
		{
			get
			{
				return this.documentInfo;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x0000F950 File Offset: 0x0000DB50
		public IRtfDocumentPropertyCollection UserProperties
		{
			get
			{
				return this.userProperties;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0000F968 File Offset: 0x0000DB68
		public RtfDocumentPropertyCollection WritableUserProperties
		{
			get
			{
				return this.userProperties;
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0000F980 File Offset: 0x0000DB80
		public void PushCurrentTextFormat()
		{
			this.textFormatStack.Push(this.WritableCurrentTextFormat);
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0000F998 File Offset: 0x0000DB98
		public void PopCurrentTextFormat()
		{
			bool flag = this.textFormatStack.Count == 0;
			if (flag)
			{
				throw new RtfStructureException(Strings.InvalidTextContextState);
			}
			this.currentTextFormat = (RtfTextFormat)this.textFormatStack.Pop();
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000F9DC File Offset: 0x0000DBDC
		public void Reset()
		{
			this.state = RtfInterpreterState.Init;
			this.rtfVersion = 1;
			this.defaultFontId = "f0";
			this.fontTable.Clear();
			this.colorTable.Clear();
			this.generator = null;
			this.uniqueTextFormats.Clear();
			this.textFormatStack.Clear();
			this.currentTextFormat = null;
			this.documentInfo.Reset();
			this.userProperties.Clear();
		}

		// Token: 0x040001B5 RID: 437
		private RtfInterpreterState state;

		// Token: 0x040001B6 RID: 438
		private int rtfVersion;

		// Token: 0x040001B7 RID: 439
		private string defaultFontId;

		// Token: 0x040001B8 RID: 440
		private readonly RtfFontCollection fontTable = new RtfFontCollection();

		// Token: 0x040001B9 RID: 441
		private readonly RtfColorCollection colorTable = new RtfColorCollection();

		// Token: 0x040001BA RID: 442
		private string generator;

		// Token: 0x040001BB RID: 443
		private readonly RtfTextFormatCollection uniqueTextFormats = new RtfTextFormatCollection();

		// Token: 0x040001BC RID: 444
		private readonly Stack textFormatStack = new Stack();

		// Token: 0x040001BD RID: 445
		private RtfTextFormat currentTextFormat;

		// Token: 0x040001BE RID: 446
		private readonly RtfDocumentInfo documentInfo = new RtfDocumentInfo();

		// Token: 0x040001BF RID: 447
		private readonly RtfDocumentPropertyCollection userProperties = new RtfDocumentPropertyCollection();
	}
}
