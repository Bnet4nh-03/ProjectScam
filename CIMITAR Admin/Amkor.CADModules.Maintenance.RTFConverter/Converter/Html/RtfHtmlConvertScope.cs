using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000AE RID: 174
	[Flags]
	public enum RtfHtmlConvertScope
	{
		// Token: 0x0400022B RID: 555
		None = 0,
		// Token: 0x0400022C RID: 556
		Document = 1,
		// Token: 0x0400022D RID: 557
		Html = 16,
		// Token: 0x0400022E RID: 558
		Head = 256,
		// Token: 0x0400022F RID: 559
		Body = 4096,
		// Token: 0x04000230 RID: 560
		Content = 65536,
		// Token: 0x04000231 RID: 561
		All = 69905
	}
}
