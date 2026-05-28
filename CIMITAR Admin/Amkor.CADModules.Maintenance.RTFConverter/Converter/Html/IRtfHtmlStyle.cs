using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000AA RID: 170
	public interface IRtfHtmlStyle
	{
		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060005AD RID: 1453
		// (set) Token: 0x060005AE RID: 1454
		string ForegroundColor { get; set; }

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060005AF RID: 1455
		// (set) Token: 0x060005B0 RID: 1456
		string BackgroundColor { get; set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060005B1 RID: 1457
		// (set) Token: 0x060005B2 RID: 1458
		string FontFamily { get; set; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060005B3 RID: 1459
		// (set) Token: 0x060005B4 RID: 1460
		string FontSize { get; set; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060005B5 RID: 1461
		bool IsEmpty { get; }
	}
}
