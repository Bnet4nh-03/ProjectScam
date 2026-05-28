using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000023 RID: 35
	[CompilerGenerated]
	[TypeIdentifier]
	[Guid("000208DB-0000-0000-C000-000000000046")]
	[DefaultMember("_Default")]
	[ComImport]
	public interface Workbooks : IEnumerable
	{
		// Token: 0x060000FF RID: 255
		void _VtblGap1_3();

		// Token: 0x06000100 RID: 256
		[LCIDConversion(1)]
		[DispId(181)]
		[return: MarshalAs(UnmanagedType.Interface)]
		Workbook Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Template);
	}
}
