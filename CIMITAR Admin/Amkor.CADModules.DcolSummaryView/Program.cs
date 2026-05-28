using System;
using System.Windows.Forms;

namespace Amkor.CADModules.DcolSummaryView
{
	// Token: 0x02000018 RID: 24
	internal static class Program
	{
		// Token: 0x06000078 RID: 120 RVA: 0x00007B98 File Offset: 0x00005D98
		[STAThread]
		private static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new DcolView());
				return;
			}
			Application.Run(new DcolView());
		}
	}
}
