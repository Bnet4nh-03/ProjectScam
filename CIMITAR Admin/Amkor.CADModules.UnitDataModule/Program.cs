using System;
using System.Windows.Forms;

namespace Amkor.CADModules.UnitDataModule
{
	// Token: 0x0200001D RID: 29
	internal static class Program
	{
		// Token: 0x06000078 RID: 120 RVA: 0x000056D8 File Offset: 0x000038D8
		[STAThread]
		private static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new UnitDataAnalysis());
				return;
			}
			Application.Run(new UnitDataAnalysis());
		}
	}
}
