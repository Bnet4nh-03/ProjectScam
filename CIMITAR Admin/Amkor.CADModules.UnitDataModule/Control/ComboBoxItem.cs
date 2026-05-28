using System;

namespace Amkor.CADModules.UnitDataModule.Control
{
	// Token: 0x02000015 RID: 21
	public class ComboBoxItem
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000033D5 File Offset: 0x000015D5
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000033DD File Offset: 0x000015DD
		public string Text { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000033E6 File Offset: 0x000015E6
		// (set) Token: 0x06000021 RID: 33 RVA: 0x000033EE File Offset: 0x000015EE
		public string Code { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000033F7 File Offset: 0x000015F7
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000033FF File Offset: 0x000015FF
		public string Name { get; set; }

		// Token: 0x06000024 RID: 36 RVA: 0x00003408 File Offset: 0x00001608
		public override string ToString()
		{
			return this.Text;
		}
	}
}
