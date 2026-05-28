using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Application
{
	// Token: 0x02000061 RID: 97
	public sealed class ArgumentCollection : ReadOnlyCollectionBase
	{
		// Token: 0x170000FF RID: 255
		public IArgument this[int index]
		{
			get
			{
				return base.InnerList[index] as IArgument;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00006A84 File Offset: 0x00004C84
		public bool IsValid
		{
			get
			{
				foreach (object obj in base.InnerList)
				{
					IArgument argument = (IArgument)obj;
					bool flag = !argument.IsValid;
					if (flag)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(IArgument[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00006AF8 File Offset: 0x00004CF8
		public void Add(IArgument item)
		{
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentNullException("item");
			}
			base.InnerList.Add(item);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000641C File Offset: 0x0000461C
		public void Clear()
		{
			base.InnerList.Clear();
		}
	}
}
