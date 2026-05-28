using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000066 RID: 102
	[CompilerGenerated]
	[InterfaceType(2)]
	[Guid("00020870-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Interior
	{
		// Token: 0x060005FD RID: 1533
		void _VtblGap1_3();

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060005FE RID: 1534
		// (set) Token: 0x060005FF RID: 1535
		[DispId(99)]
		object Color { [DispId(99)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(99)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
