using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000A9 RID: 169
	public interface IRtfHtmlCssStyleCollection : IEnumerable
	{
		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060005A9 RID: 1449
		int Count { get; }

		// Token: 0x170001EC RID: 492
		IRtfHtmlCssStyle this[int index]
		{
			get;
		}

		// Token: 0x060005AB RID: 1451
		bool Contains(string selectorName);

		// Token: 0x060005AC RID: 1452
		void CopyTo(IRtfHtmlCssStyle[] array, int index);
	}
}
