using System;
using System.Collections.Specialized;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000A8 RID: 168
	public interface IRtfHtmlCssStyle
	{
		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060005A7 RID: 1447
		NameValueCollection Properties { get; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060005A8 RID: 1448
		string SelectorName { get; }
	}
}
