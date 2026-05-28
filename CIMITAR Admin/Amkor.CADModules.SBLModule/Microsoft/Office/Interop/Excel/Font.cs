using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200002E RID: 46
	[Guid("0002084D-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[CompilerGenerated]
	[ComImport]
	public interface Font
	{
		// Token: 0x0600014B RID: 331
		void _VtblGap1_15();

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600014C RID: 332
		// (set) Token: 0x0600014D RID: 333
		object Name { [DispId(110)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(110)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x0600014E RID: 334
		void _VtblGap2_4();

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600014F RID: 335
		// (set) Token: 0x06000150 RID: 336
		object Size { [DispId(104)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(104)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
