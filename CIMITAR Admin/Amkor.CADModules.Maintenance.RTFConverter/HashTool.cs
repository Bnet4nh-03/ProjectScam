using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000041 RID: 65
	public static class HashTool
	{
		// Token: 0x06000152 RID: 338 RVA: 0x00003538 File Offset: 0x00001738
		public static int AddHashCode(int hash, object obj)
		{
			int num = (obj != null) ? obj.GetHashCode() : 0;
			bool flag = hash != 0;
			if (flag)
			{
				num += hash * 31;
			}
			return num;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000356C File Offset: 0x0000176C
		public static int AddHashCode(int hash, int objHash)
		{
			int num = objHash;
			bool flag = hash != 0;
			if (flag)
			{
				num += hash * 31;
			}
			return num;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00003594 File Offset: 0x00001794
		public static int ComputeHashCode(IEnumerable enumerable)
		{
			int num = 1;
			bool flag = enumerable == null;
			if (flag)
			{
				throw new ArgumentNullException("enumerable");
			}
			foreach (object obj in enumerable)
			{
				num = num * 31 + ((obj != null) ? obj.GetHashCode() : 0);
			}
			return num;
		}
	}
}
