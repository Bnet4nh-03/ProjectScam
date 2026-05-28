using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x0200007E RID: 126
	public sealed class RtfTextFormatCollection : ReadOnlyBaseCollection, IRtfTextFormatCollection, IEnumerable
	{
		// Token: 0x17000160 RID: 352
		public IRtfTextFormat this[int index]
		{
			get
			{
				return base.InnerList[index] as IRtfTextFormat;
			}
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000B2D8 File Offset: 0x000094D8
		public bool Contains(IRtfTextFormat format)
		{
			return this.IndexOf(format) >= 0;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000B2F8 File Offset: 0x000094F8
		public int IndexOf(IRtfTextFormat format)
		{
			bool flag = format != null;
			if (flag)
			{
				int count = this.Count;
				for (int i = 0; i < count; i++)
				{
					bool flag2 = format.Equals(base.InnerList[i]);
					if (flag2)
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(IRtfTextFormat[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000B350 File Offset: 0x00009550
		public void Add(IRtfTextFormat item)
		{
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentNullException("item");
			}
			base.InnerList.Add(item);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000641C File Offset: 0x0000461C
		public void Clear()
		{
			base.InnerList.Clear();
		}
	}
}
