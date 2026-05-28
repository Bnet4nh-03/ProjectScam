using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.CarrierModule.Properties
{
	// Token: 0x02000054 RID: 84
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0005C4FC File Offset: 0x0005A6FC
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000647 RID: 1607
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
