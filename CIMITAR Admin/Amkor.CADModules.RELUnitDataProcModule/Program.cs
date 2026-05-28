using System;
using System.Windows.Forms;

namespace Amkor.CADModules.RELUnitDataProcModule
{
	// Token: 0x0200000F RID: 15
	internal static class Program
	{
		// Token: 0x0600007E RID: 126 RVA: 0x00007DB8 File Offset: 0x00005FB8
		[STAThread]
		private static void Main(string[] args)
		{
			bool flag = args.Length == 0;
			if (flag)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new UnitDataAnalysis());
			}
			else
			{
				Application.Run(new UnitDataAnalysis());
			}
		}
	}
}
