using System;
using System.Collections;

namespace Amkor.CADModules.ESIModule.Class
{
	// Token: 0x0200000F RID: 15
	public class LotData
	{
		// Token: 0x0400007D RID: 125
		public string Lotid = string.Empty;

		// Token: 0x0400007E RID: 126
		public string Dcc = string.Empty;

		// Token: 0x0400007F RID: 127
		public string Station = string.Empty;

		// Token: 0x04000080 RID: 128
		public string Device = string.Empty;

		// Token: 0x04000081 RID: 129
		public string sProduct = string.Empty;

		// Token: 0x04000082 RID: 130
		public string sProgram = string.Empty;

		// Token: 0x04000083 RID: 131
		public string sBuild = string.Empty;

		// Token: 0x04000084 RID: 132
		public string sStartTime = string.Empty;

		// Token: 0x04000085 RID: 133
		public string sEndTime = string.Empty;

		// Token: 0x04000086 RID: 134
		public string sSN = string.Empty;

		// Token: 0x04000087 RID: 135
		public SortedList slUnit = new SortedList();

		// Token: 0x04000088 RID: 136
		public SortedList slFailData = new SortedList();

		// Token: 0x04000089 RID: 137
		public int InputQty;

		// Token: 0x0400008A RID: 138
		public int PASS_1A;

		// Token: 0x0400008B RID: 139
		public int FAIL_1A;

		// Token: 0x0400008C RID: 140
		public int PASS_2A;

		// Token: 0x0400008D RID: 141
		public int FAIL_2A;

		// Token: 0x0400008E RID: 142
		public int PASS_1B;

		// Token: 0x0400008F RID: 143
		public int FAIL_1B;

		// Token: 0x04000090 RID: 144
		public int PASS_2B;

		// Token: 0x04000091 RID: 145
		public int FAIL_2B;

		// Token: 0x04000092 RID: 146
		public int PASS_FINAL;

		// Token: 0x04000093 RID: 147
		public int FAIL_FINAL;

		// Token: 0x04000094 RID: 148
		public double FPY;

		// Token: 0x04000095 RID: 149
		public double Yield;

		// Token: 0x04000096 RID: 150
		public double RTRate;
	}
}
