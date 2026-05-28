using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x0200007A RID: 122
	public sealed class RtfDocumentPropertyCollection : ReadOnlyBaseCollection, IRtfDocumentPropertyCollection, IEnumerable
	{
		// Token: 0x17000149 RID: 329
		public IRtfDocumentProperty this[int index]
		{
			get
			{
				return base.InnerList[index] as IRtfDocumentProperty;
			}
		}

		// Token: 0x1700014A RID: 330
		public IRtfDocumentProperty this[string name]
		{
			get
			{
				bool flag = name != null;
				if (flag)
				{
					foreach (object obj in base.InnerList)
					{
						IRtfDocumentProperty rtfDocumentProperty = (IRtfDocumentProperty)obj;
						bool flag2 = rtfDocumentProperty.Name.Equals(name);
						if (flag2)
						{
							return rtfDocumentProperty;
						}
					}
				}
				return null;
			}
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(IRtfDocumentProperty[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000A3D4 File Offset: 0x000085D4
		public void Add(IRtfDocumentProperty item)
		{
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentNullException("item");
			}
			base.InnerList.Add(item);
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000641C File Offset: 0x0000461C
		public void Clear()
		{
			base.InnerList.Clear();
		}
	}
}
