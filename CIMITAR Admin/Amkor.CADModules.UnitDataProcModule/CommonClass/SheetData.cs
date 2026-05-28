using System;
using System.Data;

namespace Amkor.CADModules.UnitDataProcModule.CommonClass
{
	// Token: 0x02000008 RID: 8
	public class SheetData
	{
		// Token: 0x0400003A RID: 58
		public string Name = string.Empty;

		// Token: 0x0400003B RID: 59
		public string DataType = string.Empty;

		// Token: 0x0400003C RID: 60
		public string FileName = string.Empty;

		// Token: 0x0400003D RID: 61
		public DataTable Table = new DataTable();
	}
}
