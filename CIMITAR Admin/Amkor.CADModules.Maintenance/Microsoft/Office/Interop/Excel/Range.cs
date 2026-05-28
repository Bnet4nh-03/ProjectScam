using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000067 RID: 103
	[CompilerGenerated]
	[InterfaceType(2)]
	[Guid("00020846-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Range : IEnumerable
	{
		// Token: 0x06000600 RID: 1536
		void _VtblGap1_15();

		// Token: 0x06000601 RID: 1537
		[DispId(237)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object AutoFit();

		// Token: 0x06000602 RID: 1538
		void _VtblGap2_3();

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000603 RID: 1539
		[DispId(435)]
		Borders Borders { [DispId(435)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000604 RID: 1540
		void _VtblGap3_25();

		// Token: 0x17000171 RID: 369
		[DispId(0)]
		[IndexerName("_Default")]
		object this[[MarshalAs(UnmanagedType.Struct)] [In] [Optional] object RowIndex, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object ColumnIndex]
		{
			[DispId(0)]
			[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(0)]
			[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
			[param: MarshalAs(UnmanagedType.Struct)]
			[param: In]
			[param: Optional]
			set;
		}

		// Token: 0x06000607 RID: 1543
		void _VtblGap4_7();

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000608 RID: 1544
		[DispId(246)]
		Range EntireColumn { [DispId(246)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000609 RID: 1545
		void _VtblGap5_8();

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600060A RID: 1546
		[DispId(146)]
		Font Font { [DispId(146)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x0600060B RID: 1547
		void _VtblGap6_22();

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600060C RID: 1548
		// (set) Token: 0x0600060D RID: 1549
		[DispId(136)]
		object HorizontalAlignment { [DispId(136)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(136)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x0600060E RID: 1550
		void _VtblGap7_4();

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600060F RID: 1551
		[DispId(129)]
		Interior Interior { [DispId(129)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000610 RID: 1552
		void _VtblGap8_82();

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000611 RID: 1553
		// (set) Token: 0x06000612 RID: 1554
		[DispId(1388)]
		object Value2 { [DispId(1388)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(1388)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
