using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200001D RID: 29
	[DefaultMember("_Default")]
	[TypeIdentifier]
	[Guid("000208DB-0000-0000-C000-000000000046")]
	[CompilerGenerated]
	[ComImport]
	public interface Workbooks : IEnumerable
	{
		// Token: 0x060000D2 RID: 210
		void _VtblGap1_3();

		// Token: 0x060000D3 RID: 211
		[LCIDConversion(1)]
		[DispId(181)]
		[return: MarshalAs(UnmanagedType.Interface)]
		Workbook Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Template);
	}
}
