using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.BIBoardInfoModule.Properties
{
	// Token: 0x0200001F RID: 31
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000A1BC File Offset: 0x000083BC
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000ED RID: 237
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
