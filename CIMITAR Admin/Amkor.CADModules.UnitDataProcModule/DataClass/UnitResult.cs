using System;

namespace Amkor.CADModules.UnitDataProcModule.DataClass
{
	// Token: 0x0200000C RID: 12
	public class UnitResult
	{
		// Token: 0x04000045 RID: 69
		public int iPassCnt;

		// Token: 0x04000046 RID: 70
		public int iFailCnt;

		// Token: 0x04000047 RID: 71
		public int iFail2Cnt;

		// Token: 0x04000048 RID: 72
		public int iFail3Cnt;

		// Token: 0x04000049 RID: 73
		public UnitData unit_Seq = new UnitData();
	}
}
