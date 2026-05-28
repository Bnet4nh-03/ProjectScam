using System;
using System.Collections;
using System.Collections.Generic;

namespace Amkor.CADModules.UnitDataProcModule.DataClass
{
	// Token: 0x02000012 RID: 18
	public class Lot_Process
	{
		// Token: 0x0600006D RID: 109 RVA: 0x0000D888 File Offset: 0x0000BA88
		public void setQty(int iSeq, string sPF)
		{
			if (!(sPF.ToUpper() == "PASS"))
			{
				if (sPF == "FAIL")
				{
					switch (iSeq)
					{
					case 1:
						this.iFail1Cnt++;
						return;
					case 2:
						this.iFail2Cnt++;
						return;
					case 3:
						this.iFail3Cnt++;
						return;
					case 4:
						this.iFail4Cnt++;
						return;
					case 5:
						this.iFail5Cnt++;
						break;
					default:
						return;
					}
				}
				return;
			}
			switch (iSeq)
			{
			case 1:
				this.iPass1Cnt++;
				return;
			case 2:
				this.iPass2Cnt++;
				return;
			case 3:
				this.iPass3Cnt++;
				return;
			case 4:
				this.iPass4Cnt++;
				return;
			case 5:
				this.iPass5Cnt++;
				return;
			default:
				return;
			}
		}

		// Token: 0x040000F0 RID: 240
		public object checkFlag;

		// Token: 0x040000F1 RID: 241
		public int iIDX;

		// Token: 0x040000F2 RID: 242
		public int iLotId;

		// Token: 0x040000F3 RID: 243
		public string sLotNo = string.Empty;

		// Token: 0x040000F4 RID: 244
		public string sDCC = string.Empty;

		// Token: 0x040000F5 RID: 245
		public string sOperationName = string.Empty;

		// Token: 0x040000F6 RID: 246
		public string sProduct = string.Empty;

		// Token: 0x040000F7 RID: 247
		public string sStartTime = string.Empty;

		// Token: 0x040000F8 RID: 248
		public string sEndTime = string.Empty;

		// Token: 0x040000F9 RID: 249
		public string sTester = string.Empty;

		// Token: 0x040000FA RID: 250
		public string sProgram = string.Empty;

		// Token: 0x040000FB RID: 251
		public int iPassCnt;

		// Token: 0x040000FC RID: 252
		public int iFailCnt;

		// Token: 0x040000FD RID: 253
		public double dFTY;

		// Token: 0x040000FE RID: 254
		public int iPass1Cnt;

		// Token: 0x040000FF RID: 255
		public int iFail1Cnt;

		// Token: 0x04000100 RID: 256
		public double dFPY;

		// Token: 0x04000101 RID: 257
		public double dRT_Rate;

		// Token: 0x04000102 RID: 258
		public int iPass2Cnt;

		// Token: 0x04000103 RID: 259
		public int iFail2Cnt;

		// Token: 0x04000104 RID: 260
		public int iPass3Cnt;

		// Token: 0x04000105 RID: 261
		public int iFail3Cnt;

		// Token: 0x04000106 RID: 262
		public int iPass4Cnt;

		// Token: 0x04000107 RID: 263
		public int iFail4Cnt;

		// Token: 0x04000108 RID: 264
		public int iPass5Cnt;

		// Token: 0x04000109 RID: 265
		public int iFail5Cnt;

		// Token: 0x0400010A RID: 266
		public SortedList slUnitList = new SortedList();

		// Token: 0x0400010B RID: 267
		public SortedList<string, int> slList_1st = new SortedList<string, int>();

		// Token: 0x0400010C RID: 268
		public SortedList<string, int> slList_final = new SortedList<string, int>();

		// Token: 0x0400010D RID: 269
		public SortedList<string, int> slList_BinPareto = new SortedList<string, int>();
	}
}
