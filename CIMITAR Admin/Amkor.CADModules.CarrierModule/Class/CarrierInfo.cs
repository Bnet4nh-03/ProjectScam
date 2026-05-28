using System;
using System.Collections;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x02000009 RID: 9
	public class CarrierInfo
	{
		// Token: 0x04000033 RID: 51
		public string Location = string.Empty;

		// Token: 0x04000034 RID: 52
		public string Type = string.Empty;

		// Token: 0x04000035 RID: 53
		public string CarrierId = string.Empty;

		// Token: 0x04000036 RID: 54
		public string Device = string.Empty;

		// Token: 0x04000037 RID: 55
		public string CarrierNo = string.Empty;

		// Token: 0x04000038 RID: 56
		public string OperationCode = string.Empty;

		// Token: 0x04000039 RID: 57
		public string CarrierType = string.Empty;

		// Token: 0x0400003A RID: 58
		public string Customer = string.Empty;

		// Token: 0x0400003B RID: 59
		public string Site = string.Empty;

		// Token: 0x0400003C RID: 60
		public string LoadTester = string.Empty;

		// Token: 0x0400003D RID: 61
		public string TesterName = string.Empty;

		// Token: 0x0400003E RID: 62
		public string PkgType = string.Empty;

		// Token: 0x0400003F RID: 63
		public string Barcode = string.Empty;

		// Token: 0x04000040 RID: 64
		public string Status = string.Empty;

		// Token: 0x04000041 RID: 65
		public string RepairCodeSite1 = string.Empty;

		// Token: 0x04000042 RID: 66
		public string RepairCodeSite2 = string.Empty;

		// Token: 0x04000043 RID: 67
		public string TouchDownCnt = string.Empty;

		// Token: 0x04000044 RID: 68
		public string CleanCnt = string.Empty;

		// Token: 0x04000045 RID: 69
		public string repairCnt = string.Empty;

		// Token: 0x04000046 RID: 70
		public string LimitCleanCnt = string.Empty;

		// Token: 0x04000047 RID: 71
		public string LimitrepairCnt = string.Empty;

		// Token: 0x04000048 RID: 72
		public string Correlation = string.Empty;

		// Token: 0x04000049 RID: 73
		public string Memo = string.Empty;

		// Token: 0x0400004A RID: 74
		public string Revision = string.Empty;

		// Token: 0x0400004B RID: 75
		public string LastCleanTime = string.Empty;

		// Token: 0x0400004C RID: 76
		public string LastrepairTime = string.Empty;

		// Token: 0x0400004D RID: 77
		public string CreateUser = string.Empty;

		// Token: 0x0400004E RID: 78
		public string CreateTime = string.Empty;

		// Token: 0x0400004F RID: 79
		public string LastEventUser = string.Empty;

		// Token: 0x04000050 RID: 80
		public string LastEventTime = string.Empty;

		// Token: 0x04000051 RID: 81
		public string SubBarcode1 = string.Empty;

		// Token: 0x04000052 RID: 82
		public string SubBarcode2 = string.Empty;

		// Token: 0x04000053 RID: 83
		public string MainBarcode = string.Empty;

		// Token: 0x04000054 RID: 84
		public string BatchStatus = string.Empty;

		// Token: 0x04000055 RID: 85
		public string MCN = string.Empty;

		// Token: 0x04000056 RID: 86
		public string SubStatus = string.Empty;

		// Token: 0x04000057 RID: 87
		public string DateSearchMode = string.Empty;

		// Token: 0x04000058 RID: 88
		public int Line;

		// Token: 0x04000059 RID: 89
		public string Result = string.Empty;

		// Token: 0x0400005A RID: 90
		public string Reason = string.Empty;

		// Token: 0x0400005B RID: 91
		public string StartDate = string.Empty;

		// Token: 0x0400005C RID: 92
		public string EndDate = string.Empty;

		// Token: 0x0400005D RID: 93
		public int RepairCnt;

		// Token: 0x0400005E RID: 94
		public SortedList CarrierSites = new SortedList();
	}
}
