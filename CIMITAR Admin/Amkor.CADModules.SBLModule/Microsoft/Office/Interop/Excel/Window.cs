using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000033 RID: 51
	[Guid("00020893-0000-0000-C000-000000000046")]
	[CompilerGenerated]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[ComImport]
	public interface Window
	{
		// Token: 0x06000154 RID: 340
		void _VtblGap1_85();

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000155 RID: 341
		// (set) Token: 0x06000156 RID: 342
		object Zoom { [DispId(663)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(663)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
