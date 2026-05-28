using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000072 RID: 114
	[CompilerGenerated]
	[DefaultMember("_Default")]
	[Guid("000208D5-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Application
	{
		// Token: 0x06000620 RID: 1568
		void _VtblGap1_10();

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000621 RID: 1569
		[DispId(759)]
		Window ActiveWindow { [DispId(759)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000622 RID: 1570
		void _VtblGap2_34();

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000623 RID: 1571
		[DispId(572)]
		Workbooks Workbooks { [DispId(572)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000624 RID: 1572
		void _VtblGap3_60();

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000625 RID: 1573
		[DispId(0)]
		[IndexerName("_Default")]
		string _Default { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x06000626 RID: 1574
		void _VtblGap4_5();

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000627 RID: 1575
		// (set) Token: 0x06000628 RID: 1576
		[DispId(343)]
		bool DisplayAlerts { [DispId(343)] [LCIDConversion(0)] [MethodImpl(MethodImplOptions.InternalCall)] get; [LCIDConversion(0)] [DispId(343)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x06000629 RID: 1577
		void _VtblGap5_109();

		// Token: 0x0600062A RID: 1578
		[DispId(302)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Quit();

		// Token: 0x0600062B RID: 1579
		void _VtblGap6_51();

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600062C RID: 1580
		// (set) Token: 0x0600062D RID: 1581
		[DispId(558)]
		bool Visible { [LCIDConversion(0)] [DispId(558)] [MethodImpl(MethodImplOptions.InternalCall)] get; [LCIDConversion(0)] [DispId(558)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }
	}
}
