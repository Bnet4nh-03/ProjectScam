using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000026 RID: 38
	[Guid("000208D7-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[CompilerGenerated]
	[DefaultMember("_Default")]
	[ComImport]
	public interface Sheets : IEnumerable
	{
		// Token: 0x06000107 RID: 263
		void _VtblGap1_3();

		// Token: 0x06000108 RID: 264
		[DispId(181)]
		[LCIDConversion(4)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Before, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object After, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Count, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Type);
	}
}
