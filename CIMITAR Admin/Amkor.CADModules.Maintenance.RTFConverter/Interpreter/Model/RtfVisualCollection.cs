using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000081 RID: 129
	public sealed class RtfVisualCollection : ReadOnlyBaseCollection, IRtfVisualCollection, IEnumerable
	{
		// Token: 0x17000163 RID: 355
		public IRtfVisual this[int index]
		{
			get
			{
				return base.InnerList[index] as IRtfVisual;
			}
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(IRtfVisual[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000B554 File Offset: 0x00009754
		public void Add(IRtfVisual item)
		{
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentNullException("item");
			}
			base.InnerList.Add(item);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000641C File Offset: 0x0000461C
		public void Clear()
		{
			base.InnerList.Clear();
		}
	}
}
