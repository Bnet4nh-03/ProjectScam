using System;
using System.Collections.Generic;

namespace Amkor.CADModules.Maintenance.GrobalConst
{
	// Token: 0x02000005 RID: 5
	public class EquipmentInfo
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000021AD File Offset: 0x000003AD
		public string getCategory()
		{
			return this.Category;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021B5 File Offset: 0x000003B5
		public Dictionary<string, List<string>> getEquipmentList()
		{
			return this._list;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021C0 File Offset: 0x000003C0
		public void setInfo(string Model, string Equipment)
		{
			bool flag = !this._list.ContainsKey(Model);
			if (flag)
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

		// Token: 0x0400003C RID: 60
		private string Category = string.Empty;

		// Token: 0x0400003D RID: 61
		private Dictionary<string, List<string>> _list = new Dictionary<string, List<string>>();

		// Token: 0x0400003E RID: 62
		private string Model = string.Empty;

		// Token: 0x0400003F RID: 63
		private string Equipment = string.Empty;
	}
}
