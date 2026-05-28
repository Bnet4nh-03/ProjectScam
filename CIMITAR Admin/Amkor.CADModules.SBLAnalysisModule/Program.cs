using System;
using System.Windows.Forms;

namespace Amkor.CADModules.SBLAnalysisModule
{
	// Token: 0x02000015 RID: 21
	internal static class Program
	{
		// Token: 0x0600008F RID: 143 RVA: 0x0000A842 File Offset: 0x00008A42
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SBLAnalysis());
		}
	}
}
