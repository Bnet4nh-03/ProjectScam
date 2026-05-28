using System;
using System.Collections;

namespace Amkor.CADModules.SBLAnalysisModule.Class
{
	// Token: 0x02000007 RID: 7
	internal class GroupBin
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000027B1 File Offset: 0x000009B1
		public GroupBin()
		{
			this.slBinList = new SortedList();
		}

		// Token: 0x04000038 RID: 56
		public int sCount;

		// Token: 0x04000039 RID: 57
		public string sName;

		// Token: 0x0400003A RID: 58
		public SortedList slBinList;
	}
}
