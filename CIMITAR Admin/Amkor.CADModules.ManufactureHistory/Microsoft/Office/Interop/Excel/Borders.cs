using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000022 RID: 34
	[DefaultMember("_Default")]
	[CompilerGenerated]
	[Guid("00020855-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[TypeIdentifier]
	[ComImport]
	public interface Borders : IEnumerable
	{
		// Token: 0x060000E0 RID: 224
		void _VtblGap1_14();

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000E1 RID: 225
		// (set) Token: 0x060000E2 RID: 226
		object Weight { [DispId(120)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(120)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
