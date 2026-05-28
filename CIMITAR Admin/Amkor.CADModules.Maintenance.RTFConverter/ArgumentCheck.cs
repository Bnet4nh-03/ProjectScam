using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200003F RID: 63
	public static class ArgumentCheck
	{
		// Token: 0x0600014F RID: 335 RVA: 0x000034B0 File Offset: 0x000016B0
		public static string NonemptyTrimmedString(string value, string name)
		{
			return ArgumentCheck.NonemptyTrimmedString(value, Strings.ArgumentMayNotBeEmpty, name);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000034D0 File Offset: 0x000016D0
		public static string NonemptyTrimmedString(string value, string exceptionMessage, string name)
		{
			bool flag = value == null;
			if (flag)
			{
				throw new ArgumentNullException(name);
			}
			string text = value.Trim();
			bool flag2 = text.Length == 0;
			if (flag2)
			{
				throw new ArgumentException(exceptionMessage, name);
			}
			return text;
		}
	}
}
