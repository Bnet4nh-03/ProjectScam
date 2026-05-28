using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000037 RID: 55
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[CompilerGenerated]
	[Guid("00020870-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Interior
	{
		// Token: 0x06000157 RID: 343
		void _VtblGap1_3();

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000158 RID: 344
		// (set) Token: 0x06000159 RID: 345
		object Color { [DispId(99)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(99)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
