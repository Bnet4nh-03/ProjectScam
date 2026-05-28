using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000065 RID: 101
	[CompilerGenerated]
	[InterfaceType(2)]
	[Guid("0002084D-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Font
	{
		// Token: 0x060005F7 RID: 1527
		void _VtblGap1_15();

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060005F8 RID: 1528
		// (set) Token: 0x060005F9 RID: 1529
		[DispId(110)]
		object Name { [DispId(110)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(110)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x060005FA RID: 1530
		void _VtblGap2_4();

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060005FB RID: 1531
		// (set) Token: 0x060005FC RID: 1532
		[DispId(104)]
		object Size { [DispId(104)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(104)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
