using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000AC RID: 172
	public class RtfEmptyHtmlStyleConverter : IRtfHtmlStyleConverter
	{
		// Token: 0x060005B7 RID: 1463 RVA: 0x0001256C File Offset: 0x0001076C
		public virtual IRtfHtmlStyle TextToHtml(IRtfVisualText visualText)
		{
			return RtfHtmlStyle.Empty;
		}
	}
}
