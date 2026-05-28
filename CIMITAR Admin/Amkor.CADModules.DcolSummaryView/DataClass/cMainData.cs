using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Amkor.CADModules.DcolSummaryView.CommonClass;

namespace Amkor.CADModules.DcolSummaryView.DataClass
{
	// Token: 0x0200000E RID: 14
	public class cMainData
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00007278 File Offset: 0x00005478
		public cMainData()
		{
			this.sCustomerCode = string.Empty;
			this.sDeviceType = string.Empty;
			this.sDeviceID = string.Empty;
			this.sOperation = string.Empty;
			this.sDateType = string.Empty;
			this.sDate_Start = string.Empty;
			this.sDate_End = string.Empty;
			this.sSearchType = string.Empty;
			this.slItem = new SortedList();
			this.slLot = new SortedList();
			this.slChk_Lot = new SortedList();
			this.dtDevice = new DataTable("DEVICE");
			this.dtLot = new DataTable("LOT");
		}

		// Token: 0x04000064 RID: 100
		public CommonQuery _CommonQry = new CommonQuery();

		// Token: 0x04000065 RID: 101
		public string sLot = string.Empty;

		// Token: 0x04000066 RID: 102
		public string sDcc = string.Empty;

		// Token: 0x04000067 RID: 103
		public string sCustomerCode = string.Empty;

		// Token: 0x04000068 RID: 104
		public string sDeviceType = string.Empty;

		// Token: 0x04000069 RID: 105
		public string sDeviceID = string.Empty;

		// Token: 0x0400006A RID: 106
		public string sOperation = string.Empty;

		// Token: 0x0400006B RID: 107
		public string sTester = string.Empty;

		// Token: 0x0400006C RID: 108
		public string sDateType = string.Empty;

		// Token: 0x0400006D RID: 109
		public string sDate_Start = string.Empty;

		// Token: 0x0400006E RID: 110
		public string sDate_End = string.Empty;

		// Token: 0x0400006F RID: 111
		public SortedList slItem;

		// Token: 0x04000070 RID: 112
		public SortedList slLot;

		// Token: 0x04000071 RID: 113
		public SortedList slChk_Lot;

		// Token: 0x04000072 RID: 114
		public DataTable dtDevice;

		// Token: 0x04000073 RID: 115
		public DataTable dtLot;

		// Token: 0x04000074 RID: 116
		public DataRow[] drsLot;

		// Token: 0x04000075 RID: 117
		public string chkProcessID = string.Empty;

		// Token: 0x04000076 RID: 118
		public string sSearchType = string.Empty;

		// Token: 0x04000077 RID: 119
		public SortedList slSearchSN = new SortedList();

		// Token: 0x04000078 RID: 120
		public string sInputData = string.Empty;

		// Token: 0x04000079 RID: 121
		public List<string> lInputData = new List<string>();

		// Token: 0x0400007A RID: 122
		public bool bNewDocFlag;

		// Token: 0x0400007B RID: 123
		public string sReportType = string.Empty;

		// Token: 0x0400007C RID: 124
		private string sExpression = "[Check] = true";
	}
}
