using System;
using System.Collections;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x02000017 RID: 23
	internal class CWeeklyReport
	{
		// Token: 0x040000F9 RID: 249
		public string sDevice = string.Empty;

		// Token: 0x040000FA RID: 250
		public string sDate = string.Empty;

		// Token: 0x040000FB RID: 251
		public SortedList resultData = new SortedList();

		// Token: 0x040000FC RID: 252
		public SortedList onhand = new SortedList();

		// Token: 0x040000FD RID: 253
		public SortedList func = new SortedList();

		// Token: 0x040000FE RID: 254
		public SortedList nonfunc = new SortedList();
	}
}
