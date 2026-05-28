using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000069 RID: 105
	[CompilerGenerated]
	[InterfaceType(2)]
	[Guid("00020893-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Window
	{
		// Token: 0x0600061B RID: 1563
		void _VtblGap1_85();

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600061C RID: 1564
		// (set) Token: 0x0600061D RID: 1565
		[DispId(663)]
		object Zoom { [DispId(663)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(663)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
