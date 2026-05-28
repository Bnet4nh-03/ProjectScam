using System;
using System.Windows.Forms;

namespace Amkor.CADModules.ManufactureHistory
{
	// Token: 0x02000007 RID: 7
	internal static class Program
	{
		// Token: 0x0600001C RID: 28 RVA: 0x000042F2 File Offset: 0x000024F2
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ManufactureHistory());
		}
	}
}
