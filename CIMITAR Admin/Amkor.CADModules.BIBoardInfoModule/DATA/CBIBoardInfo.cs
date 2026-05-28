using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DATA
{
	// Token: 0x02000007 RID: 7
	public class CBIBoardInfo
	{
		// Token: 0x04000010 RID: 16
		public int iId;

		// Token: 0x04000011 RID: 17
		public string strBibNo;

		// Token: 0x04000012 RID: 18
		public string strDevice;

		// Token: 0x04000013 RID: 19
		public string strCustomer;

		// Token: 0x04000014 RID: 20
		public string strLocation;

		// Token: 0x04000015 RID: 21
		public string strBarcode;

		// Token: 0x04000016 RID: 22
		public string strUserId;

		// Token: 0x04000017 RID: 23
		public string strUserName;

		// Token: 0x04000018 RID: 24
		public string strUserBdno;

		// Token: 0x04000019 RID: 25
		public string strComment;

		// Token: 0x0400001A RID: 26
		public int iOnFlag;

		// Token: 0x0400001B RID: 27
		public DateTime dtPm;

		// Token: 0x0400001C RID: 28
		public DateTime dtInTime;

		// Token: 0x0400001D RID: 29
		public string strBad_bib;

		// Token: 0x0400001E RID: 30
		public string strGoldTab;

		// Token: 0x0400001F RID: 31
		public string strWarranty;

		// Token: 0x04000020 RID: 32
		public int iCntBadSocket;

		// Token: 0x04000021 RID: 33
		public List<CBIBoardSocketInfo> cSocketInfos;

		// Token: 0x04000022 RID: 34
		public List<CSocketPartChange> cSocketPartChanges;

		// Token: 0x04000023 RID: 35
		public SortedList slSocketList;

		// Token: 0x04000024 RID: 36
		public DataTable dataTSocket;

		// Token: 0x04000025 RID: 37
		public int iCntDDay;

		// Token: 0x04000026 RID: 38
		public int iAllSocket30w;
	}
}
