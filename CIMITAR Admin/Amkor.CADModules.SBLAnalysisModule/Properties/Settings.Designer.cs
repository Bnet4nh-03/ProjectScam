using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.SBLAnalysisModule.Properties
{
	// Token: 0x0200001D RID: 29
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x0000BF48 File Offset: 0x0000A148
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000B5 RID: 181
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
