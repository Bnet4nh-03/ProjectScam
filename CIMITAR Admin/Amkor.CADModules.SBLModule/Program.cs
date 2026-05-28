using System;
using System.Windows.Forms;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x0200001D RID: 29
	internal static class Program
	{
		// Token: 0x060000DE RID: 222 RVA: 0x0000F7B8 File Offset: 0x0000D9B8
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new RULESBLManager());
		}
	}
}
