using System;
using System.Collections.Specialized;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000AF RID: 175
	public class RtfHtmlConvertSettings
	{
		// Token: 0x060005FF RID: 1535 RVA: 0x00013A2E File Offset: 0x00011C2E
		public RtfHtmlConvertSettings() : this(new RtfVisualImageAdapter(), RtfHtmlConvertScope.All)
		{
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00013A42 File Offset: 0x00011C42
		public RtfHtmlConvertSettings(RtfHtmlConvertScope convertScope) : this(new RtfVisualImageAdapter(), convertScope)
		{
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00013A52 File Offset: 0x00011C52
		public RtfHtmlConvertSettings(IRtfVisualImageAdapter imageAdapter) : this(imageAdapter, RtfHtmlConvertScope.All)
		{
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00013A64 File Offset: 0x00011C64
		public RtfHtmlConvertSettings(IRtfVisualImageAdapter imageAdapter, RtfHtmlConvertScope convertScope)
		{
			bool flag = imageAdapter == null;
			if (flag)
			{
				throw new ArgumentNullException("imageAdapter");
			}
			this.imageAdapter = imageAdapter;
			this.ConvertScope = convertScope;
			this.VisualHyperlinkPattern = "[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\\-\\._\\?\\,\\'/\\\\\\+&%\\$#\\=~])*";
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000603 RID: 1539 RVA: 0x00013AC0 File Offset: 0x00011CC0
		public IRtfVisualImageAdapter ImageAdapter
		{
			get
			{
				return this.imageAdapter;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x00013AD8 File Offset: 0x00011CD8
		// (set) Token: 0x06000605 RID: 1541 RVA: 0x00013AE0 File Offset: 0x00011CE0
		public RtfHtmlConvertScope ConvertScope { get; set; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000606 RID: 1542 RVA: 0x00013AEC File Offset: 0x00011CEC
		public bool HasStyles
		{
			get
			{
				return this.styles != null && this.styles.Count > 0;
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000607 RID: 1543 RVA: 0x00013B18 File Offset: 0x00011D18
		public RtfHtmlCssStyleCollection Styles
		{
			get
			{
				RtfHtmlCssStyleCollection result;
				if ((result = this.styles) == null)
				{
					result = (this.styles = new RtfHtmlCssStyleCollection());
				}
				return result;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x00013B44 File Offset: 0x00011D44
		public bool HasStyleSheetLinks
		{
			get
			{
				return this.styleSheetLinks != null && this.styleSheetLinks.Count > 0;
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x00013B70 File Offset: 0x00011D70
		public StringCollection StyleSheetLinks
		{
			get
			{
				StringCollection result;
				if ((result = this.styleSheetLinks) == null)
				{
					result = (this.styleSheetLinks = new StringCollection());
				}
				return result;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x0600060A RID: 1546 RVA: 0x00013B9C File Offset: 0x00011D9C
		// (set) Token: 0x0600060B RID: 1547 RVA: 0x00013BB4 File Offset: 0x00011DB4
		public string DocumentHeader
		{
			get
			{
				return this.documentHeader;
			}
			set
			{
				this.documentHeader = value;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x0600060C RID: 1548 RVA: 0x00013BBE File Offset: 0x00011DBE
		// (set) Token: 0x0600060D RID: 1549 RVA: 0x00013BC6 File Offset: 0x00011DC6
		public string Title { get; set; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x00013BD0 File Offset: 0x00011DD0
		// (set) Token: 0x0600060F RID: 1551 RVA: 0x00013BE8 File Offset: 0x00011DE8
		public string CharacterSet
		{
			get
			{
				return this.characterSet;
			}
			set
			{
				this.characterSet = value;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000610 RID: 1552 RVA: 0x00013BF2 File Offset: 0x00011DF2
		// (set) Token: 0x06000611 RID: 1553 RVA: 0x00013BFA File Offset: 0x00011DFA
		public string VisualHyperlinkPattern { get; set; }

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x00013C03 File Offset: 0x00011E03
		// (set) Token: 0x06000613 RID: 1555 RVA: 0x00013C0B File Offset: 0x00011E0B
		public string SpecialCharsRepresentation { get; set; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x00013C14 File Offset: 0x00011E14
		// (set) Token: 0x06000615 RID: 1557 RVA: 0x00013C1C File Offset: 0x00011E1C
		public bool IsShowHiddenText { get; set; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x00013C25 File Offset: 0x00011E25
		// (set) Token: 0x06000617 RID: 1559 RVA: 0x00013C2D File Offset: 0x00011E2D
		public bool ConvertVisualHyperlinks { get; set; }

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000618 RID: 1560 RVA: 0x00013C36 File Offset: 0x00011E36
		// (set) Token: 0x06000619 RID: 1561 RVA: 0x00013C3E File Offset: 0x00011E3E
		public bool UseNonBreakingSpaces { get; set; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x0600061A RID: 1562 RVA: 0x00013C47 File Offset: 0x00011E47
		// (set) Token: 0x0600061B RID: 1563 RVA: 0x00013C4F File Offset: 0x00011E4F
		public string ImagesPath { get; set; }

		// Token: 0x0600061C RID: 1564 RVA: 0x00013C58 File Offset: 0x00011E58
		public string GetImageUrl(int index, RtfVisualImageFormat rtfVisualImageFormat)
		{
			string text = this.imageAdapter.ResolveFileName(index, rtfVisualImageFormat);
			return text.Replace('\\', '/');
		}

		// Token: 0x04000232 RID: 562
		public const string DefaultDocumentHeader = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//DE\" \"http://www.w3.org/TR/html4/loose.dtd\">";

		// Token: 0x04000233 RID: 563
		public const string DefaultDocumentCharacterSet = "UTF-8";

		// Token: 0x04000234 RID: 564
		public const string DefaultVisualHyperlinkPattern = "[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\\-\\._\\?\\,\\'/\\\\\\+&%\\$#\\=~])*";

		// Token: 0x0400023D RID: 573
		private readonly IRtfVisualImageAdapter imageAdapter;

		// Token: 0x0400023E RID: 574
		private RtfHtmlCssStyleCollection styles;

		// Token: 0x0400023F RID: 575
		private StringCollection styleSheetLinks;

		// Token: 0x04000240 RID: 576
		private string documentHeader = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//DE\" \"http://www.w3.org/TR/html4/loose.dtd\">";

		// Token: 0x04000241 RID: 577
		private string characterSet = "UTF-8";
	}
}
