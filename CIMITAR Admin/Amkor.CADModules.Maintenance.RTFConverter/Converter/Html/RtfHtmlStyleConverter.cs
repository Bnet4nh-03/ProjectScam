using System;
using System.Drawing;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000B5 RID: 181
	public class RtfHtmlStyleConverter : IRtfHtmlStyleConverter
	{
		// Token: 0x06000641 RID: 1601 RVA: 0x0001428C File Offset: 0x0001248C
		public virtual IRtfHtmlStyle TextToHtml(IRtfVisualText visualText)
		{
			bool flag = visualText == null;
			if (flag)
			{
				throw new ArgumentNullException("visualText");
			}
			RtfHtmlStyle rtfHtmlStyle = new RtfHtmlStyle();
			IRtfTextFormat format = visualText.Format;
			Color asDrawingColor = format.BackgroundColor.AsDrawingColor;
			bool flag2 = asDrawingColor.R != 0 || asDrawingColor.G != 0 || asDrawingColor.B > 0;
			if (flag2)
			{
				rtfHtmlStyle.BackgroundColor = ColorTranslator.ToHtml(asDrawingColor);
			}
			Color asDrawingColor2 = format.ForegroundColor.AsDrawingColor;
			bool flag3 = asDrawingColor2.R != 0 || asDrawingColor2.G != 0 || asDrawingColor2.B > 0;
			if (flag3)
			{
				rtfHtmlStyle.ForegroundColor = ColorTranslator.ToHtml(asDrawingColor2);
			}
			rtfHtmlStyle.FontFamily = format.Font.Name;
			bool flag4 = format.FontSize > 0;
			if (flag4)
			{
				rtfHtmlStyle.FontSize = format.FontSize / 2 + "pt";
			}
			return rtfHtmlStyle;
		}
	}
}
