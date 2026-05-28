using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000019 RID: 25
	[CompilerGenerated]
	[Guid("000208D7-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Sheets : IEnumerable
	{
		// Token: 0x060000AD RID: 173
		void _VtblGap1_3();

		// Token: 0x060000AE RID: 174
		[LCIDConversion(4)]
		[DispId(181)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Before, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object After, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Count, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Type);

		// Token: 0x060000AF RID: 175
		void _VtblGap2_1();

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000B0 RID: 176
		int Count { [DispId(118)] get; }

		// Token: 0x060000B1 RID: 177
		void _VtblGap3_12();

		// Token: 0x1700001A RID: 26
		[IndexerName("_Default")]
		object this[[MarshalAs(UnmanagedType.Struct)] [In] object Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}
}
