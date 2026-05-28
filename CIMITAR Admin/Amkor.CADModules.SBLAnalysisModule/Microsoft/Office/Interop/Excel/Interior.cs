using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000030 RID: 48
	[Guid("00020870-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[TypeIdentifier]
	[CompilerGenerated]
	[ComImport]
	public interface Interior
	{
		// Token: 0x06000115 RID: 277
		void _VtblGap1_3();

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000116 RID: 278
		// (set) Token: 0x06000117 RID: 279
		object Color { [DispId(99)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(99)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
