using System;
using System.Globalization;
using System.Xml;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Xml
{
	// Token: 0x020000A6 RID: 166
	public class RtfXmlConverter : RtfVisualVisitorBase
	{
		// Token: 0x06000590 RID: 1424 RVA: 0x00011DC4 File Offset: 0x0000FFC4
		public RtfXmlConverter(IRtfDocument rtfDocument, XmlWriter writer) : this(rtfDocument, writer, new RtfXmlConvertSettings())
		{
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00011DD8 File Offset: 0x0000FFD8
		public RtfXmlConverter(IRtfDocument rtfDocument, XmlWriter writer, RtfXmlConvertSettings settings)
		{
			bool flag = rtfDocument == null;
			if (flag)
			{
				throw new ArgumentNullException("rtfDocument");
			}
			bool flag2 = writer == null;
			if (flag2)
			{
				throw new ArgumentNullException("writer");
			}
			bool flag3 = settings == null;
			if (flag3)
			{
				throw new ArgumentNullException("settings");
			}
			this.rtfDocument = rtfDocument;
			this.writer = writer;
			this.settings = settings;
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x00011E40 File Offset: 0x00010040
		public IRtfDocument RtfDocument
		{
			get
			{
				return this.rtfDocument;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x00011E58 File Offset: 0x00010058
		public XmlWriter Writer
		{
			get
			{
				return this.writer;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x00011E70 File Offset: 0x00010070
		public RtfXmlConvertSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00011E88 File Offset: 0x00010088
		public void Convert(cConst.Upload.HTMLtype type)
		{
			this.WriteStartElement("rtfVisuals");
			foreach (object obj in this.rtfDocument.VisualContent)
			{
				IRtfVisual rtfVisual = (IRtfVisual)obj;
				rtfVisual.Visit(this, type);
			}
			this.WriteEndElement();
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00011F00 File Offset: 0x00010100
		protected override void DoVisitText(IRtfVisualText visualText, cConst.Upload.HTMLtype type)
		{
			bool flag = visualText.Format.IsHidden && !this.settings.IsShowHiddenText;
			if (!flag)
			{
				this.WriteStartElement("rtfVisualText");
				this.WriteStartElement("format");
				this.WriteElementString("fontSize", visualText.Format.FontSize.ToString(CultureInfo.InvariantCulture));
				this.WriteColor("backgroundColor", visualText.Format.BackgroundColor);
				this.WriteColor("foregroundColor", visualText.Format.ForegroundColor);
				this.WriteElementString("alignment", visualText.Format.Alignment.ToString());
				this.WriteElementString("superScript", visualText.Format.SuperScript.ToString(CultureInfo.InvariantCulture));
				this.WriteElementString("isBold", visualText.Format.IsBold.ToString(CultureInfo.InvariantCulture));
				this.WriteElementString("isItalic", visualText.Format.IsItalic.ToString(CultureInfo.InvariantCulture));
				this.WriteElementString("isStrikeThrough", visualText.Format.IsStrikeThrough.ToString(CultureInfo.InvariantCulture));
				this.WriteElementString("isUnderline", visualText.Format.IsUnderline.ToString(CultureInfo.InvariantCulture));
				this.WriteEndElement();
				this.WriteStartElement("font");
				this.WriteElementString("id", visualText.Format.Font.Id);
				this.WriteElementString("kind", visualText.Format.Font.Kind.ToString());
				this.WriteElementString("name", visualText.Format.Font.Name);
				this.WriteElementString("charSet", visualText.Format.Font.CharSet.ToString(CultureInfo.InvariantCulture));
				this.WriteElementString("codePage", visualText.Format.Font.CodePage.ToString(CultureInfo.InvariantCulture));
				this.WriteElementString("pitch", visualText.Format.Font.Pitch.ToString());
				this.WriteEndElement();
				this.WriteElementString("text", visualText.Text);
				this.WriteEndElement();
			}
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0001218C File Offset: 0x0001038C
		protected override void DoVisitImage(IRtfVisualImage visualImage, cConst.Upload.HTMLtype type)
		{
			this.WriteStartElement("rtfVisualImage");
			this.WriteElementString("format", visualImage.Format.ToString());
			this.WriteElementString("width", visualImage.Width.ToString(CultureInfo.InvariantCulture));
			this.WriteElementString("height", visualImage.Height.ToString(CultureInfo.InvariantCulture));
			this.WriteElementString("desiredWidth", visualImage.DesiredWidth.ToString(CultureInfo.InvariantCulture));
			this.WriteElementString("desiredHeight", visualImage.DesiredHeight.ToString(CultureInfo.InvariantCulture));
			this.WriteElementString("scaleWidthPercent", visualImage.ScaleWidthPercent.ToString(CultureInfo.InvariantCulture));
			this.WriteElementString("scaleHeightPercent", visualImage.ScaleHeightPercent.ToString(CultureInfo.InvariantCulture));
			this.WriteElementString("alignment", visualImage.Alignment.ToString());
			this.WriteElementString("image", visualImage.ImageDataHex);
			this.WriteEndElement();
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x000122BC File Offset: 0x000104BC
		protected override void DoVisitSpecial(IRtfVisualSpecialChar visualSpecialChar)
		{
			this.WriteStartElement("rtfVisualSpecialChar");
			this.WriteElementString("charKind", visualSpecialChar.CharKind.ToString());
			this.WriteEndElement();
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00012300 File Offset: 0x00010500
		protected override void DoVisitBreak(IRtfVisualBreak visualBreak, cConst.Upload.HTMLtype type)
		{
			this.WriteStartElement("rtfVisualBreak");
			this.WriteElementString("breakKind", visualBreak.BreakKind.ToString());
			this.WriteEndElement();
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00012344 File Offset: 0x00010544
		private void WriteColor(string name, IRtfColor color)
		{
			this.WriteStartElement(name);
			this.WriteElementString("red", color.Red.ToString(CultureInfo.InvariantCulture));
			this.WriteElementString("green", color.Green.ToString(CultureInfo.InvariantCulture));
			this.WriteElementString("blue", color.Blue.ToString(CultureInfo.InvariantCulture));
			this.WriteEndElement();
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x000123C0 File Offset: 0x000105C0
		private void WriteStartElement(string localName)
		{
			bool flag = string.IsNullOrEmpty(this.settings.Prefix) && string.IsNullOrEmpty(this.settings.Ns);
			if (flag)
			{
				this.writer.WriteStartElement(localName);
			}
			else
			{
				bool flag2 = string.IsNullOrEmpty(this.settings.Prefix);
				if (flag2)
				{
					this.writer.WriteStartElement(localName, this.settings.Ns);
				}
				else
				{
					this.writer.WriteStartElement(this.settings.Prefix, localName, this.settings.Ns);
				}
			}
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0001245C File Offset: 0x0001065C
		private void WriteElementString(string localName, string value)
		{
			bool flag = string.IsNullOrEmpty(this.settings.Prefix) && string.IsNullOrEmpty(this.settings.Ns);
			if (flag)
			{
				this.writer.WriteElementString(localName, value);
			}
			else
			{
				bool flag2 = string.IsNullOrEmpty(this.settings.Prefix);
				if (flag2)
				{
					this.writer.WriteElementString(localName, this.settings.Ns, value);
				}
				else
				{
					this.writer.WriteElementString(this.settings.Prefix, localName, this.settings.Ns, value);
				}
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x000124F8 File Offset: 0x000106F8
		private void WriteEndElement()
		{
			this.writer.WriteEndElement();
		}

		// Token: 0x04000214 RID: 532
		public const string DefaultXmlFileExtension = ".xml";

		// Token: 0x04000215 RID: 533
		private readonly IRtfDocument rtfDocument;

		// Token: 0x04000216 RID: 534
		private readonly XmlWriter writer;

		// Token: 0x04000217 RID: 535
		private readonly RtfXmlConvertSettings settings;
	}
}
