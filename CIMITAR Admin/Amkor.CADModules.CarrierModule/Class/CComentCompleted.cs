using System;
using System.Collections;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x0200000D RID: 13
	public class CComentCompleted
	{
		// Token: 0x0600000D RID: 13 RVA: 0x0000260B File Offset: 0x0000080B
		public CComentCompleted()
		{
			this.iCompletedPinTotal = 0;
			this._slCommentHistory = new SortedList();
		}

		// Token: 0x04000089 RID: 137
		public int iCompletedPinTotal;

		// Token: 0x0400008A RID: 138
		public SortedList _slCommentHistory;
	}
}
