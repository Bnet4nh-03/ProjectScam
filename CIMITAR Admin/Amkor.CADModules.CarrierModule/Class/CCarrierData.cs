using System;
using System.Collections;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x0200000A RID: 10
	internal class CCarrierData
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002420 File Offset: 0x00000620
		public CCarrierData()
		{
			this.strTotalCount = string.Empty;
			this.slTypeCount = new SortedList();
			this.slCarrierDataHistory = new SortedList();
			this.slCarrierDevice = new SortedList();
			this.slCarrierTester = new SortedList();
			this.slCarrierFailMode = new SortedList();
		}

		// Token: 0x0400005F RID: 95
		public int iCarrierCount;

		// Token: 0x04000060 RID: 96
		public int iDutCount;

		// Token: 0x04000061 RID: 97
		public string strTotalCount;

		// Token: 0x04000062 RID: 98
		public SortedList slTypeCount;

		// Token: 0x04000063 RID: 99
		public SortedList slCarrierDataHistory;

		// Token: 0x04000064 RID: 100
		public SortedList slCarrierDevice;

		// Token: 0x04000065 RID: 101
		public SortedList slCarrierTester;

		// Token: 0x04000066 RID: 102
		public SortedList slCarrierFailMode;
	}
}
