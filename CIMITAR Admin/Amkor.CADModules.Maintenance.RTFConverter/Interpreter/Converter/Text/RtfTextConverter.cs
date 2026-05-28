using System;
using System.Globalization;
using System.Text;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Text
{
	// Token: 0x0200009C RID: 156
	public class RtfTextConverter : RtfInterpreterListenerBase
	{
		// Token: 0x0600051A RID: 1306 RVA: 0x00010C9A File Offset: 0x0000EE9A
		public RtfTextConverter() : this(new RtfTextConvertSettings())
		{
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00010CAC File Offset: 0x0000EEAC
		public RtfTextConverter(RtfTextConvertSettings settings)
		{
			bool flag = settings == null;
			if (flag)
			{
				throw new ArgumentNullException("settings");
			}
			this.settings = settings;
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00010CE8 File Offset: 0x0000EEE8
		public string PlainText
		{
			get
			{
				return this.plainText.ToString();
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x00010D08 File Offset: 0x0000EF08
		public RtfTextConvertSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00010D20 File Offset: 0x0000EF20
		public void Clear()
		{
			this.plainText.Remove(0, this.plainText.Length);
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00010D3B File Offset: 0x0000EF3B
		protected override void DoBeginDocument(IRtfInterpreterContext context)
		{
			this.Clear();
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00010D48 File Offset: 0x0000EF48
		protected override void DoInsertText(IRtfInterpreterContext context, string text)
		{
			bool flag = context.CurrentTextFormat == null;
			if (!flag)
			{
				bool flag2 = !context.CurrentTextFormat.IsHidden || this.settings.IsShowHiddenText;
				if (flag2)
				{
					this.plainText.Append(text);
				}
			}
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00010D94 File Offset: 0x0000EF94
		protected override void DoInsertSpecialChar(IRtfInterpreterContext context, RtfVisualSpecialCharKind kind)
		{
			switch (kind)
			{
			case RtfVisualSpecialCharKind.Tabulator:
				this.plainText.Append(this.settings.TabulatorText);
				return;
			case RtfVisualSpecialCharKind.NonBreakingSpace:
				this.plainText.Append(this.settings.NonBreakingSpaceText);
				return;
			case RtfVisualSpecialCharKind.EmDash:
				this.plainText.Append(this.settings.EmDashText);
				return;
			case RtfVisualSpecialCharKind.EnDash:
				this.plainText.Append(this.settings.EnDashText);
				return;
			case RtfVisualSpecialCharKind.EmSpace:
				this.plainText.Append(this.settings.EmSpaceText);
				return;
			case RtfVisualSpecialCharKind.EnSpace:
				this.plainText.Append(this.settings.EnSpaceText);
				return;
			case RtfVisualSpecialCharKind.QmSpace:
				this.plainText.Append(this.settings.QmSpaceText);
				return;
			case RtfVisualSpecialCharKind.Bullet:
				this.plainText.Append(this.settings.BulletText);
				return;
			case RtfVisualSpecialCharKind.LeftSingleQuote:
				this.plainText.Append(this.settings.LeftSingleQuoteText);
				return;
			case RtfVisualSpecialCharKind.RightSingleQuote:
				this.plainText.Append(this.settings.RightSingleQuoteText);
				return;
			case RtfVisualSpecialCharKind.LeftDoubleQuote:
				this.plainText.Append(this.settings.LeftDoubleQuoteText);
				return;
			case RtfVisualSpecialCharKind.RightDoubleQuote:
				this.plainText.Append(this.settings.RightDoubleQuoteText);
				return;
			case RtfVisualSpecialCharKind.OptionalHyphen:
				this.plainText.Append(this.settings.OptionalHyphenText);
				return;
			case RtfVisualSpecialCharKind.NonBreakingHyphen:
				this.plainText.Append(this.settings.NonBreakingHyphenText);
				return;
			}
			this.plainText.Append(this.settings.UnknownSpecialCharText);
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00010F84 File Offset: 0x0000F184
		protected override void DoInsertBreak(IRtfInterpreterContext context, RtfVisualBreakKind kind)
		{
			switch (kind)
			{
			case RtfVisualBreakKind.Line:
				this.plainText.Append(this.settings.LineBreakText);
				break;
			case RtfVisualBreakKind.Page:
				this.plainText.Append(this.settings.PageBreakText);
				break;
			case RtfVisualBreakKind.Paragraph:
				this.plainText.Append(this.settings.ParagraphBreakText);
				break;
			case RtfVisualBreakKind.Section:
				this.plainText.Append(this.settings.SectionBreakText);
				break;
			default:
				this.plainText.Append(this.settings.UnknownBreakText);
				break;
			}
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001102C File Offset: 0x0000F22C
		protected override void DoInsertImage(IRtfInterpreterContext context, RtfVisualImageFormat format, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex)
		{
			string imageFormatText = this.settings.ImageFormatText;
			bool flag = string.IsNullOrEmpty(imageFormatText);
			if (!flag)
			{
				string value = string.Format(CultureInfo.InvariantCulture, imageFormatText, new object[]
				{
					format,
					width,
					height,
					desiredWidth,
					desiredHeight,
					scaleWidthPercent,
					scaleHeightPercent,
					imageDataHex
				});
				this.plainText.Append(value);
			}
		}

		// Token: 0x040001E5 RID: 485
		public const string DefaultTextFileExtension = ".txt";

		// Token: 0x040001E6 RID: 486
		private readonly StringBuilder plainText = new StringBuilder();

		// Token: 0x040001E7 RID: 487
		private readonly RtfTextConvertSettings settings;
	}
}
