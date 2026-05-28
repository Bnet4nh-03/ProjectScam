using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000029 RID: 41
	[CompilerGenerated]
	[Guid("00020870-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[ComImport]
	public interface Interior
	{
		// Token: 0x060000E6 RID: 230
		void _VtblGap1_3();

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000E7 RID: 231
		// (set) Token: 0x060000E8 RID: 232
		object Color { [DispId(99)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(99)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
