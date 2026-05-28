using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200002D RID: 45
	[CompilerGenerated]
	[TypeIdentifier]
	[Guid("000208D7-0000-0000-C000-000000000046")]
	[DefaultMember("_Default")]
	[ComImport]
	public interface Sheets : IEnumerable
	{
		// Token: 0x06000149 RID: 329
		void _VtblGap1_3();

		// Token: 0x0600014A RID: 330
		[DispId(181)]
		[LCIDConversion(4)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Before, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object After, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Count, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Type);
	}
}
