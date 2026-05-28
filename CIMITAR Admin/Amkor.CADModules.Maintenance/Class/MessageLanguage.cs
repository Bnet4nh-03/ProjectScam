using System;
using System.Reflection;
using System.Resources;

namespace Amkor.CADModules.Maintenance.Class
{
	// Token: 0x02000056 RID: 86
	public static class MessageLanguage
	{
		// Token: 0x060005E6 RID: 1510 RVA: 0x0008BF9C File Offset: 0x0008A19C
		public static string getMessage(string title)
		{
			title = "eng_" + title;
			return MessageLanguage.resourceManager.GetString(title);
		}

		// Token: 0x04000732 RID: 1842
		private static ResourceManager resourceManager = new ResourceManager("Amkor.CADModules.Maintenance.Properties.Resources", Assembly.GetExecutingAssembly());

		// Token: 0x04000733 RID: 1843
		public static readonly string type = "ENG";
	}
}
