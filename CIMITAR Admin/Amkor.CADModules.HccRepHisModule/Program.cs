using System;
using System.Windows.Forms;

namespace Amkor.CADModules.HccRepHisModule
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000035B4 File Offset: 0x000017B4
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new HccRepHisModule());
		}
	}
}
