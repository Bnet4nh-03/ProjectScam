using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200001C RID: 28
	[DefaultMember("_Default")]
	[TypeIdentifier]
	[Guid("000208D5-0000-0000-C000-000000000046")]
	[CompilerGenerated]
	[ComImport]
	public interface _Application
	{
		// Token: 0x060000C6 RID: 198
		void _VtblGap1_10();

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000C7 RID: 199
		Window ActiveWindow { [DispId(759)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000C8 RID: 200
		void _VtblGap2_34();

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000C9 RID: 201
		Workbooks Workbooks { [DispId(572)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000CA RID: 202
		void _VtblGap3_66();

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000CB RID: 203
		// (set) Token: 0x060000CC RID: 204
		bool DisplayAlerts { [DispId(343)] [LCIDConversion(0)] get; [LCIDConversion(0)] [DispId(343)] [param: In] set; }

		// Token: 0x060000CD RID: 205
		void _VtblGap4_109();

		// Token: 0x060000CE RID: 206
		[DispId(302)]
		void Quit();

		// Token: 0x060000CF RID: 207
		void _VtblGap5_51();

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000D0 RID: 208
		// (set) Token: 0x060000D1 RID: 209
		bool Visible { [LCIDConversion(0)] [DispId(558)] get; [LCIDConversion(0)] [DispId(558)] [param: In] set; }
	}
}
