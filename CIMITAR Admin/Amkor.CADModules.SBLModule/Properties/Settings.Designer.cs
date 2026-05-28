using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.SBLModule.Properties
{
	// Token: 0x02000024 RID: 36
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00010338 File Offset: 0x0000E538
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400010D RID: 269
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
