using System;

namespace Amkor.CADModules.ESIModule.Class
{
	// Token: 0x02000019 RID: 25
	public class UnitResult
	{
		// Token: 0x040000ED RID: 237
		public int iPassCnt;

		// Token: 0x040000EE RID: 238
		public int iFailCnt;

		// Token: 0x040000EF RID: 239
		public int iFail2Cnt;

		// Token: 0x040000F0 RID: 240
		public int iFail3Cnt;

		// Token: 0x040000F1 RID: 241
		public UnitData unit_Seq = new UnitData();
	}
}
