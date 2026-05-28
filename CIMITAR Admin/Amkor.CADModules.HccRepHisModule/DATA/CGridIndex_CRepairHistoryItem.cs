using System;

namespace DATA
{
	// Token: 0x02000017 RID: 23
	public class CGridIndex_CRepairHistoryItem
	{
		// Token: 0x0400008F RID: 143
		public int iIdxNo = 1;

		// Token: 0x04000090 RID: 144
		public int iIdxId = 2;

		// Token: 0x04000091 RID: 145
		public int iIdxCustName = 3;

		// Token: 0x04000092 RID: 146
		public int iIdxBoard = 4;

		// Token: 0x04000093 RID: 147
		public int iIdxBarcode = 5;

		// Token: 0x04000094 RID: 148
		public int iIdxSerialNo = 6;

		// Token: 0x04000095 RID: 149
		public int iIdxNumOfSites = 7;

		// Token: 0x04000096 RID: 150
		public int iIdxDefectedSite = 8;

		// Token: 0x04000097 RID: 151
		public int iIdxProbDesc = 9;

		// Token: 0x04000098 RID: 152
		public int iIdxAction = 10;

		// Token: 0x04000099 RID: 153
		public int iIdxDate_Indate = 11;

		// Token: 0x0400009A RID: 154
		public int iIdxDate_Update = 12;

		// Token: 0x0400009B RID: 155
		public string[] headers = new string[]
		{
			"NO",
			"ID",
			"CUSTOMER",
			"BOARD",
			"BARCODE",
			"S/N",
			"NUM_OF_SITES",
			"DEFECT_SITE",
			"PROB_DESC",
			"ACTION",
			"IN_DATE",
			"UP_DATE"
		};
	}
}
