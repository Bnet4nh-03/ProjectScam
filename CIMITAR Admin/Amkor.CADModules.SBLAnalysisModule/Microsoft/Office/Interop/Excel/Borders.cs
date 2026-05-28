using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000029 RID: 41
	[Guid("00020855-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[DefaultMember("_Default")]
	[CompilerGenerated]
	[ComImport]
	public interface Borders : IEnumerable
	{
		// Token: 0x0600010F RID: 271
		void _VtblGap1_14();

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000110 RID: 272
		// (set) Token: 0x06000111 RID: 273
		object Weight { [DispId(120)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(120)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
