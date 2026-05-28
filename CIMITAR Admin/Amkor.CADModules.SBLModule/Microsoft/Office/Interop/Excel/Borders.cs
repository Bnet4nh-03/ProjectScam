using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000030 RID: 48
	[CompilerGenerated]
	[Guid("00020855-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[TypeIdentifier]
	[DefaultMember("_Default")]
	[ComImport]
	public interface Borders : IEnumerable
	{
		// Token: 0x06000151 RID: 337
		void _VtblGap1_14();

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000152 RID: 338
		// (set) Token: 0x06000153 RID: 339
		object Weight { [DispId(120)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(120)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
