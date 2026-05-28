using System;
using System.Collections;

namespace Amkor.CADModules.UnitDataModule.Class
{
	// Token: 0x0200000B RID: 11
	public class LotData
	{
		// Token: 0x04000036 RID: 54
		public string Lotid = string.Empty;

		// Token: 0x04000037 RID: 55
		public string Lot = string.Empty;

		// Token: 0x04000038 RID: 56
		public string Dcc = string.Empty;

		// Token: 0x04000039 RID: 57
		public string Station = string.Empty;

		// Token: 0x0400003A RID: 58
		public string Device = string.Empty;

		// Token: 0x0400003B RID: 59
		public string sProduct = string.Empty;

		// Token: 0x0400003C RID: 60
		public string sProgram = string.Empty;

		// Token: 0x0400003D RID: 61
		public string sBuild = string.Empty;

		// Token: 0x0400003E RID: 62
		public string sStartTime = string.Empty;

		// Token: 0x0400003F RID: 63
		public string sEndTime = string.Empty;

		// Token: 0x04000040 RID: 64
		public string sSN = string.Empty;

		// Token: 0x04000041 RID: 65
		public SortedList slTester = new SortedList();

		// Token: 0x04000042 RID: 66
		public SortedList slUnit = new SortedList();

		// Token: 0x04000043 RID: 67
		public SortedList slFailData = new SortedList();

		// Token: 0x04000044 RID: 68
		public int InputQty;

		// Token: 0x04000045 RID: 69
		public int PASS_1A;

		// Token: 0x04000046 RID: 70
		public int FAIL_1A;

		// Token: 0x04000047 RID: 71
		public int PASS_2A;

		// Token: 0x04000048 RID: 72
		public int FAIL_2A;

		// Token: 0x04000049 RID: 73
		public int PASS_1B;

		// Token: 0x0400004A RID: 74
		public int FAIL_1B;

		// Token: 0x0400004B RID: 75
		public int PASS_2B;

		// Token: 0x0400004C RID: 76
		public int FAIL_2B;

		// Token: 0x0400004D RID: 77
		public int PASS_FINAL;

		// Token: 0x0400004E RID: 78
		public int FAIL_FINAL;

		// Token: 0x0400004F RID: 79
		public double FPY;

		// Token: 0x04000050 RID: 80
		public double Yield;

		// Token: 0x04000051 RID: 81
		public double RTRate;
	}
}
