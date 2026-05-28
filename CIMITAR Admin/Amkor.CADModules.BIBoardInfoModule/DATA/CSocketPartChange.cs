using System;

namespace DATA
{
	// Token: 0x02000009 RID: 9
	public class CSocketPartChange
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000036CA File Offset: 0x000018CA
		public CSocketPartChange()
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00005138 File Offset: 0x00003338
		public CSocketPartChange(CSocketPartChange cSocketPartChange)
		{
			this.iId = cSocketPartChange.iId;
			this.strCategory = cSocketPartChange.strCategory;
			this.strBarcode_Board = cSocketPartChange.strBarcode_Board;
			this.strBibNo = cSocketPartChange.strBibNo;
			this.iSocketNo = cSocketPartChange.iSocketNo;
			this.strBarcode_Socket = cSocketPartChange.strBarcode_Socket;
			this.iRepairTime_Min = cSocketPartChange.iRepairTime_Min;
			this.strBadgeNo = cSocketPartChange.strBadgeNo;
			this.strComment = cSocketPartChange.strComment;
			this.dtInTime = cSocketPartChange.dtInTime;
		}

		// Token: 0x0400003D RID: 61
		public int iId;

		// Token: 0x0400003E RID: 62
		public string strCategory;

		// Token: 0x0400003F RID: 63
		public string strBarcode_Board;

		// Token: 0x04000040 RID: 64
		public string strBibNo;

		// Token: 0x04000041 RID: 65
		public int iSocketNo;

		// Token: 0x04000042 RID: 66
		public string strBarcode_Socket;

		// Token: 0x04000043 RID: 67
		public int iRepairTime_Min;

		// Token: 0x04000044 RID: 68
		public string strBadgeNo;

		// Token: 0x04000045 RID: 69
		public string strComment;

		// Token: 0x04000046 RID: 70
		public DateTime dtInTime;
	}
}
