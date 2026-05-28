using System;
using System.Collections;

namespace Amkor.CADModules.ESIModule.Class
{
	// Token: 0x02000010 RID: 16
	public class ParaSummary
	{
		// Token: 0x04000097 RID: 151
		public string sTester = string.Empty;

		// Token: 0x04000098 RID: 152
		public string sParameterName = string.Empty;

		// Token: 0x04000099 RID: 153
		public string sResult = string.Empty;

		// Token: 0x0400009A RID: 154
		public double dLSL;

		// Token: 0x0400009B RID: 155
		public double dUSL;

		// Token: 0x0400009C RID: 156
		public double dAvg;

		// Token: 0x0400009D RID: 157
		public double dUnit1;

		// Token: 0x0400009E RID: 158
		public double dUnit2;

		// Token: 0x0400009F RID: 159
		public double dUnit3;

		// Token: 0x040000A0 RID: 160
		public double dUnit4;

		// Token: 0x040000A1 RID: 161
		public double dUnit5;

		// Token: 0x040000A2 RID: 162
		private SortedList slSNList = new SortedList();
	}
}
