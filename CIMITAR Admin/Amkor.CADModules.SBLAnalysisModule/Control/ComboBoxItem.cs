using System;

namespace Amkor.CADModules.SBLAnalysisModule.Control
{
	// Token: 0x0200000A RID: 10
	public class ComboBoxItem
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000028A8 File Offset: 0x00000AA8
		// (set) Token: 0x06000013 RID: 19 RVA: 0x000028BF File Offset: 0x00000ABF
		public string Text { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000028C8 File Offset: 0x00000AC8
		// (set) Token: 0x06000015 RID: 21 RVA: 0x000028DF File Offset: 0x00000ADF
		public string Code { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000028E8 File Offset: 0x00000AE8
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000028FF File Offset: 0x00000AFF
		public string Name { get; set; }

		// Token: 0x06000018 RID: 24 RVA: 0x00002908 File Offset: 0x00000B08
		public override string ToString()
		{
			return this.Text;
		}
	}
}
