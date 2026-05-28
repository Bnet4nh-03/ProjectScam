using System;

namespace Amkor.CADModules.SAMSUNGModule.Control
{
	// Token: 0x02000015 RID: 21
	public class ComboBoxItem
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000033BE File Offset: 0x000015BE
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000033C6 File Offset: 0x000015C6
		public string Text { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000033CF File Offset: 0x000015CF
		// (set) Token: 0x06000021 RID: 33 RVA: 0x000033D7 File Offset: 0x000015D7
		public string Code { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000033E0 File Offset: 0x000015E0
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000033E8 File Offset: 0x000015E8
		public string Name { get; set; }

		// Token: 0x06000024 RID: 36 RVA: 0x000033F1 File Offset: 0x000015F1
		public override string ToString()
		{
			return this.Text;
		}
	}
}
