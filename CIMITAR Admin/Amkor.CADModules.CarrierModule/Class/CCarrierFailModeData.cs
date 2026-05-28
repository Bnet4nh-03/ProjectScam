using System;
using System.Collections;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x02000006 RID: 6
	public class CCarrierFailModeData
	{
		// Token: 0x04000016 RID: 22
		public string Name = string.Empty;

		// Token: 0x04000017 RID: 23
		public int Count;

		// Token: 0x04000018 RID: 24
		public int TotalBinCount;

		// Token: 0x04000019 RID: 25
		public int BlackListCount;

		// Token: 0x0400001A RID: 26
		public double FailLoss;

		// Token: 0x0400001B RID: 27
		public SortedList slActionList = new SortedList();

		// Token: 0x0400001C RID: 28
		public SortedList slCarrierList = new SortedList();
	}
}
