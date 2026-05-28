using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200006D RID: 109
	[CompilerGenerated]
	[Guid("000208DB-0000-0000-C000-000000000046")]
	[DefaultMember("_Default")]
	[TypeIdentifier]
	[ComImport]
	public interface Workbooks : IEnumerable
	{
		// Token: 0x0600061E RID: 1566
		void _VtblGap1_3();

		// Token: 0x0600061F RID: 1567
		[DispId(181)]
		[LCIDConversion(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		Workbook Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Template);
	}
}
