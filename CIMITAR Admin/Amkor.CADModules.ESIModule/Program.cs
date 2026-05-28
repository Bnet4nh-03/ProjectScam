using System;
using System.Windows.Forms;

namespace Amkor.CADModules.ESIModule
{
	// Token: 0x02000022 RID: 34
	internal static class Program
	{
		// Token: 0x0600007E RID: 126 RVA: 0x00005BA0 File Offset: 0x00003DA0
		[STAThread]
		private static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new ESI());
				return;
			}
			Application.Run(new ESI());
		}
	}
}
