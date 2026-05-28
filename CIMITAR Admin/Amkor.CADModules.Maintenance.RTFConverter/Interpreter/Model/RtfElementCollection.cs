using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000087 RID: 135
	public sealed class RtfElementCollection : ReadOnlyBaseCollection, IRtfElementCollection, IEnumerable
	{
		// Token: 0x17000173 RID: 371
		public IRtfElement this[int index]
		{
			get
			{
				return base.InnerList[index] as IRtfElement;
			}
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(IRtfElement[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0000BEE8 File Offset: 0x0000A0E8
		public void Add(IRtfElement item)
		{
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentNullException("item");
			}
			base.InnerList.Add(item);
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0000641C File Offset: 0x0000461C
		public void Clear()
		{
			base.InnerList.Clear();
		}
	}
}
