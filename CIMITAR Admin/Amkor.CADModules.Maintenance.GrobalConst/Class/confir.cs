using System;

namespace Amkor.CADModules.Maintenance.GrobalConst.Class
{
	// Token: 0x0200000D RID: 13
	public class confir
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00005C93 File Offset: 0x00003E93
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00005C9B File Offset: 0x00003E9B
		public int index { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00005CA4 File Offset: 0x00003EA4
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00005CAC File Offset: 0x00003EAC
		public int dbindex { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00005CB5 File Offset: 0x00003EB5
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00005CBD File Offset: 0x00003EBD
		public object viewer { get; set; }

		// Token: 0x06000046 RID: 70 RVA: 0x00005CC6 File Offset: 0x00003EC6
		public confir(int index, int dbindex, object viewer)
		{
			this.index = index;
			this.dbindex = dbindex;
			this.viewer = viewer;
		}
	}
}
