using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.DcolSummaryView.Properties
{
	// Token: 0x02000021 RID: 33
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x000083D9 File Offset: 0x000065D9
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400009E RID: 158
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
