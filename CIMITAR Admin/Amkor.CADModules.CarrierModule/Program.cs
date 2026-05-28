using System;
using System.Windows.Forms;

namespace Amkor.CADModules.CarrierModule
{
	// Token: 0x02000035 RID: 53
	internal static class Program
	{
		// Token: 0x06000210 RID: 528 RVA: 0x0003EAF0 File Offset: 0x0003CCF0
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Carrier());
		}
	}
}
