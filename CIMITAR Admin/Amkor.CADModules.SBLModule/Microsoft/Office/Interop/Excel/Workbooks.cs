using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200002A RID: 42
	[CompilerGenerated]
	[TypeIdentifier]
	[Guid("000208DB-0000-0000-C000-000000000046")]
	[DefaultMember("_Default")]
	[ComImport]
	public interface Workbooks : IEnumerable
	{
		// Token: 0x06000141 RID: 321
		void _VtblGap1_3();

		// Token: 0x06000142 RID: 322
		[LCIDConversion(1)]
		[DispId(181)]
		[return: MarshalAs(UnmanagedType.Interface)]
		Workbook Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Template);
	}
}
