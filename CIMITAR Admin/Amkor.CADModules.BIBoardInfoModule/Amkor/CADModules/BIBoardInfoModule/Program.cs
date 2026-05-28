using System;
using System.Windows.Forms;

namespace Amkor.CADModules.BIBoardInfoModule
{
	// Token: 0x0200001D RID: 29
	internal static class Program
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00009F84 File Offset: 0x00008184
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BIBoardInfoModule());
		}
	}
}
