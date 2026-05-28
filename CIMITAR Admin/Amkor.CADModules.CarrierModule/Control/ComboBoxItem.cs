using System;

namespace Amkor.CADModules.CarrierModule.Control
{
	// Token: 0x02000022 RID: 34
	public class ComboBoxItem
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00003467 File Offset: 0x00001667
		// (set) Token: 0x06000033 RID: 51 RVA: 0x0000346F File Offset: 0x0000166F
		public string Text { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00003478 File Offset: 0x00001678
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00003480 File Offset: 0x00001680
		public string Code { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00003489 File Offset: 0x00001689
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00003491 File Offset: 0x00001691
		public string Name { get; set; }

		// Token: 0x06000038 RID: 56 RVA: 0x0000349A File Offset: 0x0000169A
		public override string ToString()
		{
			return this.Text;
		}
	}
}
