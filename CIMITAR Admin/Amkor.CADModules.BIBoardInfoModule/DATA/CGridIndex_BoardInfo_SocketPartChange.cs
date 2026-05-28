using System;

namespace DATA
{
	// Token: 0x0200000D RID: 13
	public class CGridIndex_BoardInfo_SocketPartChange
	{
		// Token: 0x04000073 RID: 115
		public int iId;

		// Token: 0x04000074 RID: 116
		public int iDate = 1;

		// Token: 0x04000075 RID: 117
		public int iBibNo = 2;

		// Token: 0x04000076 RID: 118
		public int iBib_Loc = 3;

		// Token: 0x04000077 RID: 119
		public int iSocket_No = 4;

		// Token: 0x04000078 RID: 120
		public int iCategory = 5;

		// Token: 0x04000079 RID: 121
		public int iSocket_Loc = 6;

		// Token: 0x0400007A RID: 122
		public int iRepairTime = 7;

		// Token: 0x0400007B RID: 123
		public int iBadgeNo = 8;

		// Token: 0x0400007C RID: 124
		public int iComment = 9;

		// Token: 0x0400007D RID: 125
		public int iDelete = 10;

		// Token: 0x0400007E RID: 126
		public string[] headers = new string[]
		{
			"ID",
			"DATE",
			"BIB NO",
			"BIB BARCODE",
			"SOCKET#",
			"CAGEGORY",
			"SOCKET BARCODE",
			"REPAIR TIME",
			"BADGE NO",
			"COMMENT",
			"DELETE"
		};
	}
}
