using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000036 RID: 54
	[CompilerGenerated]
	[InterfaceType(2)]
	[Guid("0002084D-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Font
	{
		// Token: 0x060001A0 RID: 416
		void _VtblGap1_15();

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060001A1 RID: 417
		// (set) Token: 0x060001A2 RID: 418
		[DispId(110)]
		object Name { [DispId(110)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(110)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x060001A3 RID: 419
		void _VtblGap2_4();

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060001A4 RID: 420
		// (set) Token: 0x060001A5 RID: 421
		[DispId(104)]
		object Size { [DispId(104)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(104)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
