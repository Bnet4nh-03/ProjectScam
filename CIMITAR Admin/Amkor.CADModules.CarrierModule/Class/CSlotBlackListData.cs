using System;
using System.Collections;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x02000013 RID: 19
	public class CSlotBlackListData
	{
		// Token: 0x040000EB RID: 235
		public string Name = string.Empty;

		// Token: 0x040000EC RID: 236
		public int Count;

		// Token: 0x040000ED RID: 237
		public SortedList slSlotFailList = new SortedList();

		// Token: 0x040000EE RID: 238
		public SortedList slSlotTester = new SortedList();
	}
}
