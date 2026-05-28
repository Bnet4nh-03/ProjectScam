using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000076 RID: 118
	public sealed class RtfColorCollection : ReadOnlyBaseCollection, IRtfColorCollection, IEnumerable
	{
		// Token: 0x17000123 RID: 291
		public IRtfColor this[int index]
		{
			get
			{
				return base.InnerList[index] as IRtfColor;
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(IRtfColor[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000997C File Offset: 0x00007B7C
		public void Add(IRtfColor item)
		{
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentNullException("item");
			}
			base.InnerList.Add(item);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0000641C File Offset: 0x0000461C
		public void Clear()
		{
			base.InnerList.Clear();
		}
	}
}
