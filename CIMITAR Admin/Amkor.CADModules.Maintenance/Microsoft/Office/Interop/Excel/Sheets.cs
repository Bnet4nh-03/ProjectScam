using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000068 RID: 104
	[CompilerGenerated]
	[Guid("000208D7-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Sheets : IEnumerable
	{
		// Token: 0x06000613 RID: 1555
		void _VtblGap1_3();

		// Token: 0x06000614 RID: 1556
		[LCIDConversion(4)]
		[DispId(181)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Add([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Before, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object After, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Count, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Type);

		// Token: 0x06000615 RID: 1557
		void _VtblGap2_1();

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000616 RID: 1558
		[DispId(118)]
		int Count { [DispId(118)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000617 RID: 1559
		void _VtblGap3_2();

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000618 RID: 1560
		[DispId(170)]
		object Item { [DispId(170)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.IDispatch)] get; }

		// Token: 0x06000619 RID: 1561
		void _VtblGap4_9();

		// Token: 0x17000179 RID: 377
		[DispId(0)]
		[IndexerName("_Default")]
		object this[[MarshalAs(UnmanagedType.Struct)] [In] object Index]
		{
			[DispId(0)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}
}
