using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200002C RID: 44
	[Guid("00020893-0000-0000-C000-000000000046")]
	[CompilerGenerated]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[ComImport]
	public interface Window
	{
		// Token: 0x06000112 RID: 274
		void _VtblGap1_85();

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000113 RID: 275
		// (set) Token: 0x06000114 RID: 276
		object Zoom { [DispId(663)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(663)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
