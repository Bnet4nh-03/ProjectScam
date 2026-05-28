using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.RELUnitDataProcModule.Properties
{
	// Token: 0x02000018 RID: 24
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00010340 File Offset: 0x0000E540
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000E8 RID: 232
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
