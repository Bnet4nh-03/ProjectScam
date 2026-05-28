using System;

namespace DATA
{
	// Token: 0x0200000B RID: 11
	public class CGridIndex_BoardInfo_PMList
	{
		// Token: 0x04000059 RID: 89
		public int iNo;

		// Token: 0x0400005A RID: 90
		public int iGridId = 1;

		// Token: 0x0400005B RID: 91
		public int iGridBibNo = 2;

		// Token: 0x0400005C RID: 92
		public int iGridDevice = 3;

		// Token: 0x0400005D RID: 93
		public int iGridCustomer = 4;

		// Token: 0x0400005E RID: 94
		public int iGridLocation = 5;

		// Token: 0x0400005F RID: 95
		public int iGridBarcode = 6;

		// Token: 0x04000060 RID: 96
		public int iGridUserId = 7;

		// Token: 0x04000061 RID: 97
		public int iGridUserName = 8;

		// Token: 0x04000062 RID: 98
		public int iGridUserBdno = 9;

		// Token: 0x04000063 RID: 99
		public int iGridComment = 10;

		// Token: 0x04000064 RID: 100
		public int iGridPmDate = 11;

		// Token: 0x04000065 RID: 101
		public int iGridIntime = 12;

		// Token: 0x04000066 RID: 102
		public int iGridBad = 13;

		// Token: 0x04000067 RID: 103
		public string[] headers = new string[]
		{
			"NO",
			"ID",
			"BIB NO",
			"DEVICE",
			"CUSTOMER",
			"LOCATION",
			"BARCODE",
			"USER ID",
			"USER NAME",
			"BADGE NO",
			"COMMENT",
			"PM DATE",
			"IN TIME",
			"BAD"
		};
	}
}
