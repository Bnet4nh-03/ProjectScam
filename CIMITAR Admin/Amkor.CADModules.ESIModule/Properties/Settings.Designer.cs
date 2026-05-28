using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.ESIModule.Properties
{
	// Token: 0x02000032 RID: 50
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00026F70 File Offset: 0x00025170
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400029D RID: 669
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
