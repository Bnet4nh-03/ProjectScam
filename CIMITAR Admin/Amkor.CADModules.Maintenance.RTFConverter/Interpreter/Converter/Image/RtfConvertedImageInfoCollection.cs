using System;
using System.Collections;
using Amkor.CADModules.Maintenance.RTFConverter.Collection;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image
{
	// Token: 0x020000A2 RID: 162
	public sealed class RtfConvertedImageInfoCollection : ReadOnlyCollectionBase, IRtfConvertedImageInfoCollection, IEnumerable
	{
		// Token: 0x170001D6 RID: 470
		public IRtfConvertedImageInfo this[int index]
		{
			get
			{
				return base.InnerList[index] as RtfConvertedImageInfo;
			}
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(IRtfConvertedImageInfo[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x000115F4 File Offset: 0x0000F7F4
		public void Add(IRtfConvertedImageInfo item)
		{
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentNullException("item");
			}
			base.InnerList.Add(item);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0000641C File Offset: 0x0000461C
		public void Clear()
		{
			base.InnerList.Clear();
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00011624 File Offset: 0x0000F824
		public override string ToString()
		{
			return CollectionTool.ToString(this);
		}
	}
}
