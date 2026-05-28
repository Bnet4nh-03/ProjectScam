using System;

namespace Amkor.CADModules.SAMSUNGModule.Class
{
	// Token: 0x02000014 RID: 20
	public class UnitResult
	{
		// Token: 0x040000B0 RID: 176
		public int iPassCnt;

		// Token: 0x040000B1 RID: 177
		public int iFailCnt;

		// Token: 0x040000B2 RID: 178
		public int iFail2Cnt;

		// Token: 0x040000B3 RID: 179
		public int iFail3Cnt;

		// Token: 0x040000B4 RID: 180
		public UnitData unit_Seq = new UnitData();
	}
}
