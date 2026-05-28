using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.Maintenance.Properties
{
	// Token: 0x02000053 RID: 83
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.7.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x00086E38 File Offset: 0x00085038
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000730 RID: 1840
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
