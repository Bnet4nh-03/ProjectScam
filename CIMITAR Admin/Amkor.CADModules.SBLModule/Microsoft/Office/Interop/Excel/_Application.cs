using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000029 RID: 41
	[CompilerGenerated]
	[DefaultMember("_Default")]
	[TypeIdentifier]
	[Guid("000208D5-0000-0000-C000-000000000046")]
	[ComImport]
	public interface _Application
	{
		// Token: 0x06000135 RID: 309
		void _VtblGap1_10();

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000136 RID: 310
		Window ActiveWindow { [DispId(759)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000137 RID: 311
		void _VtblGap2_34();

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000138 RID: 312
		Workbooks Workbooks { [DispId(572)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000139 RID: 313
		void _VtblGap3_66();

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600013A RID: 314
		// (set) Token: 0x0600013B RID: 315
		bool DisplayAlerts { [DispId(343)] [LCIDConversion(0)] get; [DispId(343)] [LCIDConversion(0)] [param: In] set; }

		// Token: 0x0600013C RID: 316
		void _VtblGap4_109();

		// Token: 0x0600013D RID: 317
		[DispId(302)]
		void Quit();

		// Token: 0x0600013E RID: 318
		void _VtblGap5_51();

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600013F RID: 319
		// (set) Token: 0x06000140 RID: 320
		bool Visible { [LCIDConversion(0)] [DispId(558)] get; [DispId(558)] [LCIDConversion(0)] [param: In] set; }
	}
}
