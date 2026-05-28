using System;
using System.Windows.Forms;

namespace Amkor.CADModules.HccSTReportModule
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x06000027 RID: 39 RVA: 0x0000A168 File Offset: 0x00008368
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new HccSTReportModule());
		}
	}
}
