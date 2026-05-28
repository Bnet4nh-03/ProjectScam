using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Xml
{
	// Token: 0x020000A7 RID: 167
	public class RtfXmlConvertSettings
	{
		// Token: 0x0600059E RID: 1438 RVA: 0x00012507 File Offset: 0x00010707
		public RtfXmlConvertSettings() : this(null, null)
		{
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00012513 File Offset: 0x00010713
		public RtfXmlConvertSettings(string ns) : this(null, ns)
		{
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0001251F File Offset: 0x0001071F
		public RtfXmlConvertSettings(string prefix, string ns)
		{
			this.Prefix = prefix;
			this.Ns = ns;
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x00012539 File Offset: 0x00010739
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x00012541 File Offset: 0x00010741
		public string Prefix { get; set; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0001254A File Offset: 0x0001074A
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x00012552 File Offset: 0x00010752
		public string Ns { get; set; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0001255B File Offset: 0x0001075B
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x00012563 File Offset: 0x00010763
		public bool IsShowHiddenText { get; set; }
	}
}
