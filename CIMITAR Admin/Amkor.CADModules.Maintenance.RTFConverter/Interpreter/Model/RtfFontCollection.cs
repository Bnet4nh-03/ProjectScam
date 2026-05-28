using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x0200007C RID: 124
	public sealed class RtfFontCollection : ReadOnlyBaseCollection, IRtfFontCollection, IEnumerable
	{
		// Token: 0x060003CC RID: 972 RVA: 0x0000A6EC File Offset: 0x000088EC
		public bool ContainsFontWithId(string fontId)
		{
			return this.fontByIdMap.ContainsKey(fontId);
		}

		// Token: 0x17000151 RID: 337
		public IRtfFont this[int index]
		{
			get
			{
				return base.InnerList[index] as IRtfFont;
			}
		}

		// Token: 0x17000152 RID: 338
		public IRtfFont this[string id]
		{
			get
			{
				return this.fontByIdMap[id] as IRtfFont;
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(IRtfFont[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000A754 File Offset: 0x00008954
		public void Add(IRtfFont item)
		{
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentNullException("item");
			}
			base.InnerList.Add(item);
			this.fontByIdMap.Add(item.Id, item);
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0000A796 File Offset: 0x00008996
		public void Clear()
		{
			base.InnerList.Clear();
			this.fontByIdMap.Clear();
		}

		// Token: 0x04000171 RID: 369
		private readonly Hashtable fontByIdMap = new Hashtable();
	}
}
