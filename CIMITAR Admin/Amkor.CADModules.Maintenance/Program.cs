using System;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00003244 File Offset: 0x00001444
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Maintenance());
		}
	}
}
