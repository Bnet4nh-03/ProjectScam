using System;
using System.Collections.Generic;

namespace Amkor.CADModules.ManufactureHistory.GrobalConstMFG
{
	// Token: 0x02000005 RID: 5
	public class EquipmentInfo
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002120 File Offset: 0x00000320
		public void setInfo(string Model, string Equipment)
		{
			if (!this._list.ContainsKey(Model))
			{
				List<string> list = new List<string>();
				list.Add(Equipment);
				this._list.Add(Model, list);
			}
			else
			{
				this._list[Model].Add(Equipment);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002174 File Offset: 0x00000374
		public string getCategory()
		{
			return this.Category;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000218C File Offset: 0x0000038C
		public Dictionary<string, List<string>> getEquipmentList()
		{
			return this._list;
		}

		// Token: 0x0400001D RID: 29
		private string Category = string.Empty;

		// Token: 0x0400001E RID: 30
		private Dictionary<string, List<string>> _list = new Dictionary<string, List<string>>();

		// Token: 0x0400001F RID: 31
		private string Model = string.Empty;

		// Token: 0x04000020 RID: 32
		private string Equipment = string.Empty;
	}
}
