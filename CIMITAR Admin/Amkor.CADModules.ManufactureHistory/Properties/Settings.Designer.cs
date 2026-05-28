using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Amkor.CADModules.ManufactureHistory.Properties
{
	// Token: 0x02000015 RID: 21
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00012C00 File Offset: 0x00010E00
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000103 RID: 259
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
