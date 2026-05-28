using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000B1 RID: 177
	public sealed class RtfHtmlCssStyleCollection : ReadOnlyCollectionBase, IRtfHtmlCssStyleCollection, IEnumerable
	{
		// Token: 0x1700020E RID: 526
		public IRtfHtmlCssStyle this[int index]
		{
			get
			{
				return base.InnerList[index] as RtfHtmlCssStyle;
			}
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00013D14 File Offset: 0x00011F14
		public bool Contains(string selectorName)
		{
			foreach (object obj in base.InnerList)
			{
				IRtfHtmlCssStyle rtfHtmlCssStyle = (IRtfHtmlCssStyle)obj;
				bool flag = rtfHtmlCssStyle.SelectorName.Equals(selectorName);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(IRtfHtmlCssStyle[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00013D88 File Offset: 0x00011F88
		public void Add(IRtfHtmlCssStyle item)
		{
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentNullException("item");
			}
			base.InnerList.Add(item);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0000641C File Offset: 0x0000461C
		public void Clear()
		{
			base.InnerList.Clear();
		}
	}
}
