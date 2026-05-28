using System;
using System.Data;

namespace Amkor.CADModules.DcolSummaryView.CommonClass
{
	// Token: 0x02000008 RID: 8
	public class SheetData
	{
		// Token: 0x04000028 RID: 40
		public string Name = string.Empty;

		// Token: 0x04000029 RID: 41
		public string DataType = string.Empty;

		// Token: 0x0400002A RID: 42
		public string FileName = string.Empty;

		// Token: 0x0400002B RID: 43
		public DataTable Table = new DataTable();
	}
}
