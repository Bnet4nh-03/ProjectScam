using System;
using System.Collections.Generic;
using System.Linq;

namespace DATA
{
	// Token: 0x02000014 RID: 20
	public class CSessionTotal
	{
		// Token: 0x0600002D RID: 45 RVA: 0x000036CA File Offset: 0x000018CA
		public CSessionTotal()
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00005572 File Offset: 0x00003772
		public CSessionTotal(CSessionTotal session)
		{
			this.iTotal = session.iTotal;
			this.iGood = session.iGood;
			this.iFail = session.iFail;
			this.binningInfos = session.binningInfos.ToList<CBinSort_BinningInfo>();
		}

		// Token: 0x040000A7 RID: 167
		public int iTotal;

		// Token: 0x040000A8 RID: 168
		public int iGood;

		// Token: 0x040000A9 RID: 169
		public int iFail;

		// Token: 0x040000AA RID: 170
		public List<CBinSort_BinningInfo> binningInfos;
	}
}
