using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.UnitDataProcModule.Properties
{
	// Token: 0x02000025 RID: 37
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x0000EA0D File Offset: 0x0000CC0D
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400012F RID: 303
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
