using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000022 RID: 34
	[DefaultMember("_Default")]
	[TypeIdentifier]
	[CompilerGenerated]
	[Guid("000208D5-0000-0000-C000-000000000046")]
	[ComImport]
	public interface _Application
	{
		// Token: 0x060000F3 RID: 243
		void _VtblGap1_10();

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000F4 RID: 244
		Window ActiveWindow { [DispId(759)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000F5 RID: 245
		void _VtblGap2_34();

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000F6 RID: 246
		Workbooks Workbooks { [DispId(572)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000F7 RID: 247
		void _VtblGap3_66();

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000F8 RID: 248
		// (set) Token: 0x060000F9 RID: 249
		bool DisplayAlerts { [DispId(343)] [LCIDConversion(0)] get; [LCIDConversion(0)] [DispId(343)] [param: In] set; }

		// Token: 0x060000FA RID: 250
		void _VtblGap4_109();

		// Token: 0x060000FB RID: 251
		[DispId(302)]
		void Quit();

		// Token: 0x060000FC RID: 252
		void _VtblGap5_51();

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000FD RID: 253
		// (set) Token: 0x060000FE RID: 254
		bool Visible { [LCIDConversion(0)] [DispId(558)] get; [DispId(558)] [LCIDConversion(0)] [param: In] set; }
	}
}
