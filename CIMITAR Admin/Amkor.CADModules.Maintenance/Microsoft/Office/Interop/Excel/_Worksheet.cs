using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000074 RID: 116
	[CompilerGenerated]
	[Guid("000208D8-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Worksheet
	{
		// Token: 0x06000634 RID: 1588
		void _VtblGap1_11();

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000635 RID: 1589
		// (set) Token: 0x06000636 RID: 1590
		[DispId(110)]
		string Name { [DispId(110)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(110)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x06000637 RID: 1591
		void _VtblGap2_32();

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000638 RID: 1592
		[DispId(238)]
		Range Cells { [DispId(238)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000639 RID: 1593
		void _VtblGap3_47();

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600063A RID: 1594
		[DispId(197)]
		Range Range { [DispId(197)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
