using System;
using System.Resources;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000042 RID: 66
	public abstract class StringsBase
	{
		// Token: 0x06000155 RID: 341 RVA: 0x00003614 File Offset: 0x00001814
		protected static string Format(string format, params object[] args)
		{
			return StringTool.FormatSafeInvariant(format, args);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00003630 File Offset: 0x00001830
		protected static ResourceManager NewInst(Type singletonType)
		{
			bool flag = singletonType == null;
			if (flag)
			{
				throw new ArgumentNullException("singletonType");
			}
			bool flag2 = string.IsNullOrEmpty(singletonType.FullName);
			if (flag2)
			{
				throw new ArgumentException("singletonType");
			}
			return new ResourceManager(singletonType.FullName, singletonType.Assembly);
		}
	}
}
