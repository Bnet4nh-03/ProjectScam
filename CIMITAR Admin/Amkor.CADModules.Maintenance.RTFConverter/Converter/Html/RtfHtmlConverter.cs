using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;
using Amkor.CADModules.Maintenance.RTFConverter.Logging;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000AD RID: 173
	public class RtfHtmlConverter : RtfVisualVisitorBase
	{
		// Token: 0x060005B9 RID: 1465 RVA: 0x00012583 File Offset: 0x00010783
		public RtfHtmlConverter(IRtfDocument rtfDocument) : this(rtfDocument, new RtfHtmlConvertSettings())
		{
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00012594 File Offset: 0x00010794
		public RtfHtmlConverter(IRtfDocument rtfDocument, RtfHtmlConvertSettings settings)
		{
			bool flag = rtfDocument == null;
			if (flag)
			{
				throw new ArgumentNullException("rtfDocument");
			}
			bool flag2 = settings == null;
			if (flag2)
			{
				throw new ArgumentNullException("settings");
			}
			this.rtfDocument = rtfDocument;
			this.settings = settings;
			this.specialCharacters = new RtfHtmlSpecialCharCollection(settings.SpecialCharsRepresentation);
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x00012614 File Offset: 0x00010814
		public IRtfDocument RtfDocument
		{
			get
			{
				return this.rtfDocument;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x0001262C File Offset: 0x0001082C
		public RtfHtmlConvertSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x060005BD RID: 1469 RVA: 0x00012644 File Offset: 0x00010844
		// (set) Token: 0x060005BE RID: 1470 RVA: 0x0001265C File Offset: 0x0001085C
		public IRtfHtmlStyleConverter StyleConverter
		{
			get
			{
				return this.styleConverter;
			}
			set
			{
				bool flag = value == null;
				if (flag)
				{
					throw new ArgumentNullException("value");
				}
				this.styleConverter = value;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x00012688 File Offset: 0x00010888
		public RtfHtmlSpecialCharCollection SpecialCharacters
		{
			get
			{
				return this.specialCharacters;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x000126A0 File Offset: 0x000108A0
		public RtfConvertedImageInfoCollection DocumentImages
		{
			get
			{
				return this.documentImages;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x000126B8 File Offset: 0x000108B8
		protected HtmlTextWriter Writer
		{
			get
			{
				return this.writer;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x000126D0 File Offset: 0x000108D0
		protected RtfHtmlElementPath ElementPath
		{
			get
			{
				return this.elementPath;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x000126E8 File Offset: 0x000108E8
		protected bool IsInParagraph
		{
			get
			{
				return this.IsInElement(HtmlTextWriterTag.P);
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x00012704 File Offset: 0x00010904
		protected bool IsInList
		{
			get
			{
				return this.IsInElement(HtmlTextWriterTag.Ul) || this.IsInElement(HtmlTextWriterTag.Ol);
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x0001272C File Offset: 0x0001092C
		protected bool IsInListItem
		{
			get
			{
				return this.IsInElement(HtmlTextWriterTag.Li);
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00012748 File Offset: 0x00010948
		protected virtual string Generator
		{
			get
			{
				return "Rtf2Html Converter";
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00012760 File Offset: 0x00010960
		public string Convert(cConst.Upload.HTMLtype type)
		{
			this.documentImages.Clear();
			string result;
			using (StringWriter stringWriter = new StringWriter())
			{
				using (this.writer = new HtmlTextWriter(stringWriter))
				{
					this.RenderHtmlSection(type);
				}
				result = stringWriter.ToString();
			}
			bool flag = this.elementPath.Count != 0;
			if (flag)
			{
				RtfHtmlConverter.logger.Error("unbalanced element structure");
			}
			return result;
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00012808 File Offset: 0x00010A08
		protected bool IsCurrentElement(HtmlTextWriterTag tag)
		{
			return this.elementPath.IsCurrent(tag);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00012828 File Offset: 0x00010A28
		protected bool IsInElement(HtmlTextWriterTag tag)
		{
			return this.elementPath.Contains(tag);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00012846 File Offset: 0x00010A46
		protected void RenderBeginTag(HtmlTextWriterTag tag)
		{
			this.Writer.RenderBeginTag(tag);
			this.elementPath.Push(tag);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00012863 File Offset: 0x00010A63
		protected void RenderEndTag()
		{
			this.RenderEndTag(false);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00012870 File Offset: 0x00010A70
		protected virtual void RenderEndTag(bool lineBreak)
		{
			this.Writer.RenderEndTag();
			if (lineBreak)
			{
				this.Writer.WriteLine();
			}
			this.elementPath.Pop();
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x000128A9 File Offset: 0x00010AA9
		protected virtual void RenderTitleTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Title);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x000128B5 File Offset: 0x00010AB5
		protected virtual void RenderMetaTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Meta);
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x000128C1 File Offset: 0x00010AC1
		protected virtual void RenderHtmlTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Html);
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x000128CD File Offset: 0x00010ACD
		protected virtual void RenderLinkTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Link);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x000128D9 File Offset: 0x00010AD9
		protected virtual void RenderHeadTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Head);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x000128E5 File Offset: 0x00010AE5
		protected virtual void RenderBodyTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Body);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x000128F1 File Offset: 0x00010AF1
		protected virtual void RenderLineBreak()
		{
			this.writer.WriteBreak();
			this.writer.WriteLine();
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0001290C File Offset: 0x00010B0C
		protected virtual void RenderATag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.A);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00012917 File Offset: 0x00010B17
		protected virtual void RenderPTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.P);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00012923 File Offset: 0x00010B23
		protected virtual void RenderBTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.B);
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0001292E File Offset: 0x00010B2E
		protected virtual void RenderITag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.I);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001293A File Offset: 0x00010B3A
		protected virtual void RenderUTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.U);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00012946 File Offset: 0x00010B46
		protected virtual void RenderSTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.S);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00012952 File Offset: 0x00010B52
		protected virtual void RenderSubTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Sub);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0001295E File Offset: 0x00010B5E
		protected virtual void RenderSupTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Sup);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0001296A File Offset: 0x00010B6A
		protected virtual void RenderSpanTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Span);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x00012976 File Offset: 0x00010B76
		protected virtual void RenderUlTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Ul);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00012982 File Offset: 0x00010B82
		protected virtual void RenderOlTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Ol);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0001298E File Offset: 0x00010B8E
		protected virtual void RenderLiTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Li);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001299A File Offset: 0x00010B9A
		protected virtual void RenderImgTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Img);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x000129A6 File Offset: 0x00010BA6
		protected virtual void RenderStyleTag()
		{
			this.RenderBeginTag(HtmlTextWriterTag.Style);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x000129B4 File Offset: 0x00010BB4
		protected virtual void RenderDocumentHeader()
		{
			bool flag = string.IsNullOrEmpty(this.settings.DocumentHeader);
			if (!flag)
			{
				this.Writer.WriteLine(this.settings.DocumentHeader);
			}
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000129F0 File Offset: 0x00010BF0
		protected virtual void RenderMetaContentType()
		{
			this.Writer.AddAttribute("http-equiv", "content-type");
			string text = "text/html";
			bool flag = !string.IsNullOrEmpty(this.settings.CharacterSet);
			if (flag)
			{
				text = text + "; charset=" + this.settings.CharacterSet;
			}
			this.Writer.AddAttribute(HtmlTextWriterAttribute.Content, text);
			this.RenderMetaTag();
			this.RenderEndTag();
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00012A68 File Offset: 0x00010C68
		protected virtual void RenderMetaGenerator()
		{
			string generator = this.Generator;
			bool flag = string.IsNullOrEmpty(generator);
			if (!flag)
			{
				this.Writer.WriteLine();
				this.Writer.AddAttribute(HtmlTextWriterAttribute.Name, "generator");
				this.Writer.AddAttribute(HtmlTextWriterAttribute.Content, generator);
				this.RenderMetaTag();
				this.RenderEndTag();
			}
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00012AC8 File Offset: 0x00010CC8
		protected virtual void RenderLinkStyleSheets()
		{
			bool flag = !this.settings.HasStyleSheetLinks;
			if (!flag)
			{
				foreach (string value in this.settings.StyleSheetLinks)
				{
					bool flag2 = string.IsNullOrEmpty(value);
					if (!flag2)
					{
						this.Writer.WriteLine();
						this.Writer.AddAttribute(HtmlTextWriterAttribute.Href, value);
						this.Writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
						this.Writer.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
						this.RenderLinkTag();
						this.RenderEndTag();
					}
				}
			}
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00012B98 File Offset: 0x00010D98
		protected virtual void RenderHeadAttributes()
		{
			this.RenderMetaContentType();
			this.RenderMetaGenerator();
			this.RenderLinkStyleSheets();
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x00012BB0 File Offset: 0x00010DB0
		protected virtual void RenderTitle()
		{
			bool flag = string.IsNullOrEmpty(this.settings.Title);
			if (!flag)
			{
				this.Writer.WriteLine();
				this.RenderTitleTag();
				this.Writer.Write(this.settings.Title);
				this.RenderEndTag();
			}
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00012C08 File Offset: 0x00010E08
		protected virtual void RenderStyles()
		{
			bool flag = !this.settings.HasStyles;
			if (!flag)
			{
				this.Writer.WriteLine();
				this.RenderStyleTag();
				bool flag2 = true;
				foreach (object obj in this.settings.Styles)
				{
					IRtfHtmlCssStyle rtfHtmlCssStyle = (IRtfHtmlCssStyle)obj;
					bool flag3 = rtfHtmlCssStyle.Properties.Count == 0;
					if (!flag3)
					{
						bool flag4 = !flag2;
						if (flag4)
						{
							this.Writer.WriteLine();
						}
						this.Writer.WriteLine(rtfHtmlCssStyle.SelectorName);
						this.Writer.WriteLine("{");
						for (int i = 0; i < rtfHtmlCssStyle.Properties.Count; i++)
						{
							this.Writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "  {0}: {1};", new object[]
							{
								rtfHtmlCssStyle.Properties.Keys[i],
								rtfHtmlCssStyle.Properties[i]
							}));
						}
						this.Writer.Write("}");
						flag2 = false;
					}
				}
				this.RenderEndTag();
			}
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00012D74 File Offset: 0x00010F74
		protected virtual void RenderRtfContent(cConst.Upload.HTMLtype type)
		{
			foreach (object obj in this.rtfDocument.VisualContent)
			{
				IRtfVisual rtfVisual = (IRtfVisual)obj;
				rtfVisual.Visit(this, type);
			}
			this.EnsureClosedList();
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00012DE0 File Offset: 0x00010FE0
		protected virtual void BeginParagraph()
		{
			bool isInParagraph = this.IsInParagraph;
			if (!isInParagraph)
			{
				this.RenderPTag();
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00012E04 File Offset: 0x00011004
		protected virtual void EndParagraph()
		{
			bool flag = !this.IsInParagraph;
			if (!flag)
			{
				this.RenderEndTag(true);
			}
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x00012E2C File Offset: 0x0001102C
		protected virtual bool OnEnterVisual(IRtfVisual rtfVisual)
		{
			return true;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void OnLeaveVisual(IRtfVisual rtfVisual)
		{
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x00012E40 File Offset: 0x00011040
		protected virtual IRtfHtmlStyle GetHtmlStyle(IRtfVisual rtfVisual)
		{
			IRtfHtmlStyle result = RtfHtmlStyle.Empty;
			RtfVisualKind kind = rtfVisual.Kind;
			if (kind == RtfVisualKind.Text)
			{
				result = this.styleConverter.TextToHtml(rtfVisual as IRtfVisualText);
			}
			return result;
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x00012E7C File Offset: 0x0001107C
		protected virtual string FormatHtmlText(string rtfText)
		{
			string text = HttpUtility.HtmlEncode(rtfText);
			bool useNonBreakingSpaces = this.settings.UseNonBreakingSpaces;
			if (useNonBreakingSpaces)
			{
				text = text.Replace(" ", "&nbsp;");
			}
			return text;
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00012EB8 File Offset: 0x000110B8
		protected override void DoVisitText(IRtfVisualText visualText, cConst.Upload.HTMLtype type)
		{
			bool flag = !this.EnterVisual(visualText);
			if (!flag)
			{
				bool flag2 = visualText.Format.IsHidden && !this.settings.IsShowHiddenText;
				if (!flag2)
				{
					IRtfTextFormat format = visualText.Format;
					switch (format.Alignment)
					{
					case RtfTextAlignment.Center:
						this.Writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
						break;
					case RtfTextAlignment.Right:
						this.Writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "right");
						break;
					case RtfTextAlignment.Justify:
						this.Writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "justify");
						break;
					}
					bool flag3 = !this.IsInListItem;
					if (flag3)
					{
						this.BeginParagraph();
					}
					bool isBold = format.IsBold;
					if (isBold)
					{
						this.RenderBTag();
					}
					bool isItalic = format.IsItalic;
					if (isItalic)
					{
						this.RenderITag();
					}
					bool isUnderline = format.IsUnderline;
					if (isUnderline)
					{
						this.RenderUTag();
					}
					bool isStrikeThrough = format.IsStrikeThrough;
					if (isStrikeThrough)
					{
						this.RenderSTag();
					}
					IRtfHtmlStyle htmlStyle = this.GetHtmlStyle(visualText);
					bool flag4 = !htmlStyle.IsEmpty;
					if (flag4)
					{
						bool flag5 = !string.IsNullOrEmpty(htmlStyle.ForegroundColor);
						if (flag5)
						{
							this.Writer.AddStyleAttribute(HtmlTextWriterStyle.Color, htmlStyle.ForegroundColor);
						}
						bool flag6 = !string.IsNullOrEmpty(htmlStyle.BackgroundColor);
						if (flag6)
						{
							this.Writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, htmlStyle.BackgroundColor);
						}
						bool flag7 = !string.IsNullOrEmpty(htmlStyle.FontFamily);
						if (flag7)
						{
							this.Writer.AddStyleAttribute(HtmlTextWriterStyle.FontFamily, htmlStyle.FontFamily);
						}
						bool flag8 = !string.IsNullOrEmpty(htmlStyle.FontSize);
						if (flag8)
						{
							this.Writer.AddStyleAttribute(HtmlTextWriterStyle.FontSize, htmlStyle.FontSize);
						}
						this.RenderSpanTag();
					}
					bool flag9 = false;
					bool convertVisualHyperlinks = this.settings.ConvertVisualHyperlinks;
					if (convertVisualHyperlinks)
					{
						string value = this.ConvertVisualHyperlink(visualText.Text);
						bool flag10 = !string.IsNullOrEmpty(value);
						if (flag10)
						{
							flag9 = true;
							this.Writer.AddAttribute(HtmlTextWriterAttribute.Href, value);
							this.RenderATag();
						}
					}
					bool flag11 = format.SuperScript < 0;
					if (flag11)
					{
						this.RenderSubTag();
					}
					else
					{
						bool flag12 = format.SuperScript > 0;
						if (flag12)
						{
							this.RenderSupTag();
						}
					}
					string value2 = this.FormatHtmlText(visualText.Text);
					this.Writer.Write(value2);
					bool flag13 = format.SuperScript < 0;
					if (flag13)
					{
						this.RenderEndTag();
					}
					else
					{
						bool flag14 = format.SuperScript > 0;
						if (flag14)
						{
							this.RenderEndTag();
						}
					}
					bool flag15 = flag9;
					if (flag15)
					{
						this.RenderEndTag();
					}
					bool flag16 = !htmlStyle.IsEmpty;
					if (flag16)
					{
						this.RenderEndTag();
					}
					bool isStrikeThrough2 = format.IsStrikeThrough;
					if (isStrikeThrough2)
					{
						this.RenderEndTag();
					}
					bool isUnderline2 = format.IsUnderline;
					if (isUnderline2)
					{
						this.RenderEndTag();
					}
					bool isItalic2 = format.IsItalic;
					if (isItalic2)
					{
						this.RenderEndTag();
					}
					bool isBold2 = format.IsBold;
					if (isBold2)
					{
						this.RenderEndTag();
					}
					this.LeaveVisual(visualText);
				}
			}
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x000131F4 File Offset: 0x000113F4
		protected override void DoVisitImage(IRtfVisualImage visualImage, cConst.Upload.HTMLtype type)
		{
			bool flag = !this.EnterVisual(visualImage);
			if (!flag)
			{
				switch (visualImage.Alignment)
				{
				case RtfTextAlignment.Left:
					this.Writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "left");
					break;
				case RtfTextAlignment.Center:
					this.Writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
					break;
				case RtfTextAlignment.Right:
					this.Writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "right");
					break;
				case RtfTextAlignment.Justify:
					this.Writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "justify");
					break;
				}
				this.BeginParagraph();
				int index = this.documentImages.Count + 1;
				string imageUrl = this.settings.GetImageUrl(index, visualImage.Format);
				int width = this.settings.ImageAdapter.CalcImageWidth(visualImage.Format, visualImage.Width, visualImage.DesiredWidth, visualImage.ScaleWidthPercent);
				int height = this.settings.ImageAdapter.CalcImageHeight(visualImage.Format, visualImage.Height, visualImage.DesiredHeight, visualImage.ScaleHeightPercent);
				this.Writer.AddAttribute(HtmlTextWriterAttribute.Width, width.ToString(CultureInfo.InvariantCulture));
				this.Writer.AddAttribute(HtmlTextWriterAttribute.Height, height.ToString(CultureInfo.InvariantCulture));
				string text = HttpUtility.HtmlEncode(imageUrl);
				using (Metafile metafile = new Metafile(new MemoryStream(visualImage.ImageDataBinary)))
				{
					MetafileHeader metafileHeader = metafile.GetMetafileHeader();
					using (Bitmap bitmap = new Bitmap(metafile, visualImage.DesiredWidth / 15, visualImage.DesiredHeight / 15))
					{
						DateTime now = DateTime.Now;
						text = text.ToUpper().Replace("WMF", "png");
						bool flag2 = type == cConst.Upload.HTMLtype.action;
						if (flag2)
						{
							bool flag3 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action\\action.files");
							if (flag3)
							{
								Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action\\action.files");
							}
							this.Writer.AddAttribute(HtmlTextWriterAttribute.Src, "action.files/" + now.ToString("yyyyMMddHHmmssffff") + "_" + text, false);
							bitmap.Save("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action\\action.files/" + now.ToString("yyyyMMddHHmmssffff") + "_" + text, ImageFormat.Png);
						}
						else
						{
							bool flag4 = type == cConst.Upload.HTMLtype.report;
							if (flag4)
							{
								bool flag5 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.files");
								if (flag5)
								{
									Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.files");
								}
								this.Writer.AddAttribute(HtmlTextWriterAttribute.Src, "report.files/" + now.ToString("yyyyMMddHHmmssffff") + "_" + text, false);
								bitmap.Save("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.files/" + now.ToString("yyyyMMddHHmmssffff") + "_" + text, ImageFormat.Png);
							}
							else
							{
								bool flag6 = type == cConst.Upload.HTMLtype.pm;
								if (flag6)
								{
									bool flag7 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm.files");
									if (flag7)
									{
										Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm.files");
									}
									this.Writer.AddAttribute(HtmlTextWriterAttribute.Src, "pm.files/" + now.ToString("yyyyMMddHHmmssffff") + "_" + text, false);
									bitmap.Save("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm.files/" + now.ToString("yyyyMMddHHmmssffff") + "_" + text, ImageFormat.Png);
								}
							}
						}
					}
				}
				this.RenderImgTag();
				this.RenderEndTag();
				this.documentImages.Add(new RtfConvertedImageInfo(text, this.settings.ImageAdapter.TargetFormat, new Size(width, height)));
				this.LeaveVisual(visualImage);
			}
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x000135C0 File Offset: 0x000117C0
		protected override void DoVisitSpecial(IRtfVisualSpecialChar visualSpecialChar)
		{
			bool flag = !this.EnterVisual(visualSpecialChar);
			if (!flag)
			{
				RtfVisualSpecialCharKind charKind = visualSpecialChar.CharKind;
				if (charKind != RtfVisualSpecialCharKind.ParagraphNumberBegin)
				{
					if (charKind != RtfVisualSpecialCharKind.ParagraphNumberEnd)
					{
						bool flag2 = this.SpecialCharacters.ContainsKey(visualSpecialChar.CharKind);
						if (flag2)
						{
							this.Writer.Write(this.SpecialCharacters[visualSpecialChar.CharKind]);
						}
					}
					else
					{
						this.isInParagraphNumber = false;
					}
				}
				else
				{
					this.isInParagraphNumber = true;
				}
				this.LeaveVisual(visualSpecialChar);
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00013644 File Offset: 0x00011844
		protected override void DoVisitBreak(IRtfVisualBreak visualBreak, cConst.Upload.HTMLtype type)
		{
			bool flag = !this.EnterVisual(visualBreak);
			if (!flag)
			{
				switch (visualBreak.BreakKind)
				{
				case RtfVisualBreakKind.Line:
					this.RenderLineBreak();
					break;
				case RtfVisualBreakKind.Paragraph:
				{
					bool isInParagraph = this.IsInParagraph;
					if (isInParagraph)
					{
						this.EndParagraph();
					}
					else
					{
						bool isInListItem = this.IsInListItem;
						if (isInListItem)
						{
							this.EndParagraph();
							this.RenderEndTag(true);
						}
						else
						{
							this.BeginParagraph();
							this.Writer.Write("&nbsp;");
							this.EndParagraph();
						}
					}
					break;
				}
				}
				this.LeaveVisual(visualBreak);
			}
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x000136F0 File Offset: 0x000118F0
		private string ConvertVisualHyperlink(string text)
		{
			bool flag = string.IsNullOrEmpty(text);
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = this.hyperlinkRegEx == null;
				if (flag2)
				{
					bool flag3 = string.IsNullOrEmpty(this.settings.VisualHyperlinkPattern);
					if (flag3)
					{
						return null;
					}
					this.hyperlinkRegEx = new Regex(this.settings.VisualHyperlinkPattern);
				}
				result = (this.hyperlinkRegEx.IsMatch(text) ? text : null);
			}
			return result;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00013764 File Offset: 0x00011964
		private void RenderDocumentSection()
		{
			bool flag = (this.settings.ConvertScope & RtfHtmlConvertScope.Document) != RtfHtmlConvertScope.Document;
			if (!flag)
			{
				this.RenderDocumentHeader();
			}
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00013794 File Offset: 0x00011994
		private void RenderHtmlSection(cConst.Upload.HTMLtype type)
		{
			bool flag = (this.settings.ConvertScope & RtfHtmlConvertScope.Html) == RtfHtmlConvertScope.Html;
			if (flag)
			{
				this.RenderHtmlTag();
			}
			this.RenderBodySection(type);
			bool flag2 = (this.settings.ConvertScope & RtfHtmlConvertScope.Html) == RtfHtmlConvertScope.Html;
			if (flag2)
			{
				this.RenderEndTag(true);
			}
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x000137EC File Offset: 0x000119EC
		private void RenderHeadSection()
		{
			bool flag = (this.settings.ConvertScope & RtfHtmlConvertScope.Head) != RtfHtmlConvertScope.Head;
			if (!flag)
			{
				this.RenderHeadTag();
				this.RenderHeadAttributes();
				this.RenderTitle();
				this.RenderStyles();
				this.RenderEndTag(true);
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00013840 File Offset: 0x00011A40
		private void RenderBodySection(cConst.Upload.HTMLtype type)
		{
			bool flag = (this.settings.ConvertScope & RtfHtmlConvertScope.Body) == RtfHtmlConvertScope.Body;
			if (flag)
			{
				this.RenderBodyTag();
			}
			bool flag2 = (this.settings.ConvertScope & RtfHtmlConvertScope.Content) == RtfHtmlConvertScope.Content;
			if (flag2)
			{
				this.RenderRtfContent(type);
			}
			bool flag3 = (this.settings.ConvertScope & RtfHtmlConvertScope.Body) == RtfHtmlConvertScope.Body;
			if (flag3)
			{
				this.RenderEndTag();
			}
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x000138C0 File Offset: 0x00011AC0
		private bool EnterVisual(IRtfVisual rtfVisual)
		{
			bool flag = this.EnsureOpenList(rtfVisual);
			bool flag2 = flag;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				this.EnsureClosedList(rtfVisual);
				result = this.OnEnterVisual(rtfVisual);
			}
			return result;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x000138F3 File Offset: 0x00011AF3
		private void LeaveVisual(IRtfVisual rtfVisual)
		{
			this.OnLeaveVisual(rtfVisual);
			this.lastVisual = rtfVisual;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00013908 File Offset: 0x00011B08
		private bool EnsureOpenList(IRtfVisual rtfVisual)
		{
			IRtfVisualText rtfVisualText = rtfVisual as IRtfVisualText;
			bool flag = rtfVisualText == null || !this.isInParagraphNumber;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this.IsInList;
				if (flag2)
				{
					bool flag3 = "·".Equals(rtfVisualText.Text);
					bool flag4 = flag3;
					if (flag4)
					{
						this.RenderUlTag();
					}
					else
					{
						this.RenderOlTag();
					}
				}
				this.RenderLiTag();
				result = true;
			}
			return result;
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00013980 File Offset: 0x00011B80
		private void EnsureClosedList()
		{
			bool flag = this.lastVisual == null;
			if (!flag)
			{
				this.EnsureClosedList(this.lastVisual);
			}
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x000139AC File Offset: 0x00011BAC
		private void EnsureClosedList(IRtfVisual rtfVisual)
		{
			bool flag = !this.IsInList;
			if (!flag)
			{
				IRtfVisualBreak rtfVisualBreak = this.lastVisual as IRtfVisualBreak;
				bool flag2 = rtfVisualBreak == null || rtfVisualBreak.BreakKind != RtfVisualBreakKind.Paragraph;
				if (!flag2)
				{
					IRtfVisualSpecialChar rtfVisualSpecialChar = rtfVisual as IRtfVisualSpecialChar;
					bool flag3 = rtfVisualSpecialChar == null || rtfVisualSpecialChar.CharKind != RtfVisualSpecialCharKind.ParagraphNumberBegin;
					if (flag3)
					{
						this.RenderEndTag(true);
					}
				}
			}
		}

		// Token: 0x0400021B RID: 539
		public const string DefaultHtmlFileExtension = ".html";

		// Token: 0x0400021C RID: 540
		private readonly RtfConvertedImageInfoCollection documentImages = new RtfConvertedImageInfoCollection();

		// Token: 0x0400021D RID: 541
		private readonly RtfHtmlElementPath elementPath = new RtfHtmlElementPath();

		// Token: 0x0400021E RID: 542
		private readonly IRtfDocument rtfDocument;

		// Token: 0x0400021F RID: 543
		private readonly RtfHtmlConvertSettings settings;

		// Token: 0x04000220 RID: 544
		private IRtfHtmlStyleConverter styleConverter = new RtfHtmlStyleConverter();

		// Token: 0x04000221 RID: 545
		private readonly RtfHtmlSpecialCharCollection specialCharacters;

		// Token: 0x04000222 RID: 546
		private HtmlTextWriter writer;

		// Token: 0x04000223 RID: 547
		private IRtfVisual lastVisual;

		// Token: 0x04000224 RID: 548
		private bool isInParagraphNumber;

		// Token: 0x04000225 RID: 549
		private const string generatorName = "Rtf2Html Converter";

		// Token: 0x04000226 RID: 550
		private const string nonBreakingSpace = "&nbsp;";

		// Token: 0x04000227 RID: 551
		private const string unsortedListValue = "·";

		// Token: 0x04000228 RID: 552
		private Regex hyperlinkRegEx;

		// Token: 0x04000229 RID: 553
		private static readonly ILogger logger = Logger.GetLogger(typeof(RtfHtmlConverter));
	}
}
