using System;
using System.Windows.Forms;

namespace Amkor.CADModules.UnitDataProcModule
{
	// Token: 0x0200001C RID: 28
	internal static class Program
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x0000E1CC File Offset: 0x0000C3CC
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
