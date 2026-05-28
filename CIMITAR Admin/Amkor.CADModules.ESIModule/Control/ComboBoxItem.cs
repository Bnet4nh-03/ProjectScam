using System;

namespace Amkor.CADModules.ESIModule.Control
{
	// Token: 0x0200001A RID: 26
	public class ComboBoxItem
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000033E5 File Offset: 0x000015E5
		// (set) Token: 0x06000024 RID: 36 RVA: 0x000033ED File Offset: 0x000015ED
		public string Text { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000033F6 File Offset: 0x000015F6
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000033FE File Offset: 0x000015FE
		public string Code { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00003407 File Offset: 0x00001607
		// (set) Token: 0x06000028 RID: 40 RVA: 0x0000340F File Offset: 0x0000160F
		public string Name { get; set; }

		// Token: 0x06000029 RID: 41 RVA: 0x00003418 File Offset: 0x00001618
		public override string ToString()
		{
			return this.Text;
		}
	}
}
