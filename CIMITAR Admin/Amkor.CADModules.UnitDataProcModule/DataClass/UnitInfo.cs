using System;
using System.Collections;

namespace Amkor.CADModules.UnitDataProcModule.DataClass
{
	// Token: 0x0200000B RID: 11
	public class UnitInfo
	{
		// Token: 0x04000040 RID: 64
		public string UnitID = string.Empty;

		// Token: 0x04000041 RID: 65
		public string UN = string.Empty;

		// Token: 0x04000042 RID: 66
		public string SN = string.Empty;

		// Token: 0x04000043 RID: 67
		public string PF = string.Empty;

		// Token: 0x04000044 RID: 68
		public SortedList slSeq = new SortedList();
	}
}
