using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000038 RID: 56
	[CompilerGenerated]
	[DefaultMember("_Default")]
	[Guid("000208D7-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Sheets : IEnumerable
	{
		// Token: 0x060001B7 RID: 439
		void _VtblGap1_3();

		// Token: 0x060001B8 RID: 440
		[LCIDConversion(4)]
		[DispId(181)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Before, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object After, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Count, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Type);
	}
}
