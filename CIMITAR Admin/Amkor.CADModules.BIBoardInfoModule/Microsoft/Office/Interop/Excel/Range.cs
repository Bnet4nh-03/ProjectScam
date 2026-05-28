using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000037 RID: 55
	[CompilerGenerated]
	[InterfaceType(2)]
	[Guid("00020846-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Range : IEnumerable
	{
		// Token: 0x060001A6 RID: 422
		void _VtblGap1_15();

		// Token: 0x060001A7 RID: 423
		[DispId(237)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object AutoFit();

		// Token: 0x060001A8 RID: 424
		void _VtblGap2_3();

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060001A9 RID: 425
		[DispId(435)]
		Borders Borders { [DispId(435)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060001AA RID: 426
		void _VtblGap3_25();

		// Token: 0x1700001C RID: 28
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

		// Token: 0x060001AD RID: 429
		void _VtblGap4_7();

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001AE RID: 430
		[DispId(246)]
		Range EntireColumn { [DispId(246)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060001AF RID: 431
		void _VtblGap5_8();

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060001B0 RID: 432
		[DispId(146)]
		Font Font { [DispId(146)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060001B1 RID: 433
		void _VtblGap6_22();

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060001B2 RID: 434
		// (set) Token: 0x060001B3 RID: 435
		[DispId(136)]
		object HorizontalAlignment { [DispId(136)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(136)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x060001B4 RID: 436
		void _VtblGap7_87();

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060001B5 RID: 437
		// (set) Token: 0x060001B6 RID: 438
		[DispId(1388)]
		object Value2 { [DispId(1388)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(1388)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
