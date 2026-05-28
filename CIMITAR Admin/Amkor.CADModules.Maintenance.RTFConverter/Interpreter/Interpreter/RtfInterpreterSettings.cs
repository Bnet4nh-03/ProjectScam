using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000098 RID: 152
	public sealed class RtfInterpreterSettings : IRtfInterpreterSettings
	{
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x00010906 File Offset: 0x0000EB06
		// (set) Token: 0x06000509 RID: 1289 RVA: 0x0001090E File Offset: 0x0000EB0E
		public bool IgnoreDuplicatedFonts { get; set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x00010917 File Offset: 0x0000EB17
		// (set) Token: 0x0600050B RID: 1291 RVA: 0x0001091F File Offset: 0x0000EB1F
		public bool IgnoreUnknownFonts { get; set; }
	}
}
