using System;

namespace Amkor.CADModules.SBLModule.Control
{
	// Token: 0x02000010 RID: 16
	public class ComboBoxItem
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00004900 File Offset: 0x00002B00
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00004908 File Offset: 0x00002B08
		public string Text { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00004911 File Offset: 0x00002B11
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00004919 File Offset: 0x00002B19
		public string Code { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00004922 File Offset: 0x00002B22
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000492A File Offset: 0x00002B2A
		public string Name { get; set; }

		// Token: 0x0600003B RID: 59 RVA: 0x00004933 File Offset: 0x00002B33
		public override string ToString()
		{
			return this.Text;
		}
	}
}
