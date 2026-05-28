using System;
using System.Collections.Generic;

namespace Amkor.CADModules.Maintenance.Class
{
	// Token: 0x0200005A RID: 90
	public class MachineInfo
	{
		// Token: 0x060005EF RID: 1519 RVA: 0x0008E138 File Offset: 0x0008C338
		public MachineInfo()
		{
			this.TotalTime = null;
		}

		// Token: 0x0400074B RID: 1867
		public string sSelectModel = string.Empty;

		// Token: 0x0400074C RID: 1868
		public string sSelectMachine = string.Empty;

		// Token: 0x0400074D RID: 1869
		public string sSelectRsc = string.Empty;

		// Token: 0x0400074E RID: 1870
		public Dictionary<int, TimeSpan> diTime = new Dictionary<int, TimeSpan>();

		// Token: 0x0400074F RID: 1871
		public List<MachineDetailInfo> detailInfo = new List<MachineDetailInfo>();

		// Token: 0x04000750 RID: 1872
		public TimeSpan[] TotalTime;
	}
}
