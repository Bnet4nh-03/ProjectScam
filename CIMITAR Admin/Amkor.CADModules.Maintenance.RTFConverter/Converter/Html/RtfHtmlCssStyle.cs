using System;
using System.Collections.Specialized;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000B0 RID: 176
	public class RtfHtmlCssStyle : IRtfHtmlCssStyle
	{
		// Token: 0x0600061D RID: 1565 RVA: 0x00013C84 File Offset: 0x00011E84
		public RtfHtmlCssStyle(string selectorName)
		{
			bool flag = selectorName == null;
			if (flag)
			{
				throw new ArgumentNullException("selectorName");
			}
			this.selectorName = selectorName;
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x0600061E RID: 1566 RVA: 0x00013CC0 File Offset: 0x00011EC0
		public NameValueCollection Properties
		{
			get
			{
				return this.properties;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x00013CD8 File Offset: 0x00011ED8
		public string SelectorName
		{
			get
			{
				return this.selectorName;
			}
		}

		// Token: 0x04000242 RID: 578
		private readonly NameValueCollection properties = new NameValueCollection();

		// Token: 0x04000243 RID: 579
		private readonly string selectorName;
	}
}
