using System;
using System.Collections;

namespace Amkor.CADModules.UnitDataModule.Class
{
	// Token: 0x0200000D RID: 13
	public class TesterData
	{
		// Token: 0x04000059 RID: 89
		public string TesterNo = string.Empty;

		// Token: 0x0400005A RID: 90
		public string TesterName = string.Empty;

		// Token: 0x0400005B RID: 91
		public SortedList slStationId = new SortedList();

		// Token: 0x0400005C RID: 92
		public SortedList slLot = new SortedList();

		// Token: 0x0400005D RID: 93
		public SortedList slUnit = new SortedList();

		// Token: 0x0400005E RID: 94
		public SortedList slFailData = new SortedList();

		// Token: 0x0400005F RID: 95
		public int InputQty;

		// Token: 0x04000060 RID: 96
		public int PASS_1A;

		// Token: 0x04000061 RID: 97
		public int FAIL_1A;

		// Token: 0x04000062 RID: 98
		public int PASS_2A;

		// Token: 0x04000063 RID: 99
		public int FAIL_2A;

		// Token: 0x04000064 RID: 100
		public int PASS_1B;

		// Token: 0x04000065 RID: 101
		public int FAIL_1B;

		// Token: 0x04000066 RID: 102
		public int PASS_2B;

		// Token: 0x04000067 RID: 103
		public int FAIL_2B;

		// Token: 0x04000068 RID: 104
		public int PASS_FINAL;

		// Token: 0x04000069 RID: 105
		public int FAIL_FINAL;

		// Token: 0x0400006A RID: 106
		public double FPY;

		// Token: 0x0400006B RID: 107
		public double Yield;

		// Token: 0x0400006C RID: 108
		public double RTRate;
	}
}
