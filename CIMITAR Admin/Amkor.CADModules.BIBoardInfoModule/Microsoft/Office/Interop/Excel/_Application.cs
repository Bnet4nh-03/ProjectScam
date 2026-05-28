using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000040 RID: 64
	[CompilerGenerated]
	[DefaultMember("_Default")]
	[Guid("000208D5-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Application
	{
		// Token: 0x060001BB RID: 443
		void _VtblGap1_45();

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060001BC RID: 444
		[DispId(572)]
		Workbooks Workbooks { [DispId(572)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060001BD RID: 445
		void _VtblGap2_60();

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060001BE RID: 446
		[DispId(0)]
		[IndexerName("_Default")]
		string _Default { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060001BF RID: 447
		void _VtblGap3_5();

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060001C0 RID: 448
		// (set) Token: 0x060001C1 RID: 449
		[DispId(343)]
		bool DisplayAlerts { [DispId(343)] [LCIDConversion(0)] [MethodImpl(MethodImplOptions.InternalCall)] get; [LCIDConversion(0)] [DispId(343)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x060001C2 RID: 450
		void _VtblGap4_109();

		// Token: 0x060001C3 RID: 451
		[DispId(302)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Quit();
	}
}
