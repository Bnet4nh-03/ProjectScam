using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000027 RID: 39
	[Guid("0002084D-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[CompilerGenerated]
	[ComImport]
	public interface Font
	{
		// Token: 0x06000109 RID: 265
		void _VtblGap1_15();

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600010A RID: 266
		// (set) Token: 0x0600010B RID: 267
		object Name { [DispId(110)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(110)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x0600010C RID: 268
		void _VtblGap2_4();

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600010D RID: 269
		// (set) Token: 0x0600010E RID: 270
		object Size { [DispId(104)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(104)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
