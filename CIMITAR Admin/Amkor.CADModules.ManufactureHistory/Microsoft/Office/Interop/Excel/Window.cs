using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000025 RID: 37
	[CompilerGenerated]
	[Guid("00020893-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[ComImport]
	public interface Window
	{
		// Token: 0x060000E3 RID: 227
		void _VtblGap1_85();

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000E4 RID: 228
		// (set) Token: 0x060000E5 RID: 229
		object Zoom { [DispId(663)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(663)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
