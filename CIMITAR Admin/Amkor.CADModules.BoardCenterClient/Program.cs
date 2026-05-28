using System;
using System.Windows.Forms;

namespace Amkor.CADModules.BoardCenterClient
{
	// Token: 0x02000006 RID: 6
	internal static class Program
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00006808 File Offset: 0x00004A08
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BoardCenterClientMain());
		}
	}
}
