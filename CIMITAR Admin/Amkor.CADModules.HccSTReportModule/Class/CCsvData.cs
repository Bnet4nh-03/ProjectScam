using System;

namespace Amkor.CADModules.HccSTReportModule.Class
{
	// Token: 0x02000021 RID: 33
	public class CCsvData
	{
		// Token: 0x060000DA RID: 218 RVA: 0x0001A2F4 File Offset: 0x000184F4
		public CCsvData()
		{
			this.cCommonVal = null;
			this.cEWS_PC = null;
			this.cEWS_PIB = null;
			this.cEWS_PT = null;
			this.cEWS_KIT = null;
			this.cEQ = null;
		}

		// Token: 0x040001DF RID: 479
		public CCommonVal cCommonVal;

		// Token: 0x040001E0 RID: 480
		public CEWS_PC cEWS_PC;

		// Token: 0x040001E1 RID: 481
		public CEWS_PIB cEWS_PIB;

		// Token: 0x040001E2 RID: 482
		public CEWS_PT cEWS_PT;

		// Token: 0x040001E3 RID: 483
		public CEWS_KIT cEWS_KIT;

		// Token: 0x040001E4 RID: 484
		public CEQ cEQ;
	}
}
