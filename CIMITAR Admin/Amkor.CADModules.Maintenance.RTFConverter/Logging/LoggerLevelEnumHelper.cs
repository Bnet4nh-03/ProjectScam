using System;
using Amkor.CADModules.Maintenance.RTFConverter.Collection;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000053 RID: 83
	public static class LoggerLevelEnumHelper
	{
		// Token: 0x060001DB RID: 475 RVA: 0x0000482C File Offset: 0x00002A2C
		public static LoggerLevel Parse(string value)
		{
			return (LoggerLevel)CollectionTool.ParseEnumValue(typeof(LoggerLevel), value, true);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00004850 File Offset: 0x00002A50
		public static string Format(LoggerLevel value)
		{
			return value.ToString();
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00004870 File Offset: 0x00002A70
		public static string PossibleValues()
		{
			return CollectionTool.EnumValuesToString(typeof(LoggerLevel));
		}
	}
}
