using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000020 RID: 32
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[TypeIdentifier]
	[CompilerGenerated]
	[Guid("0002084D-0000-0000-C000-000000000046")]
	[ComImport]
	public interface Font
	{
		// Token: 0x060000DA RID: 218
		void _VtblGap1_15();

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000DB RID: 219
		// (set) Token: 0x060000DC RID: 220
		object Name { [DispId(110)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(110)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x060000DD RID: 221
		void _VtblGap2_4();

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000DE RID: 222
		// (set) Token: 0x060000DF RID: 223
		object Size { [DispId(104)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(104)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
