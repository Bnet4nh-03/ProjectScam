using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000020 RID: 32
	[Guid("00020846-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[TypeIdentifier]
	[CompilerGenerated]
	[ComImport]
	public interface Range : IEnumerable
	{
		// Token: 0x060000E0 RID: 224
		void _VtblGap1_15();

		// Token: 0x060000E1 RID: 225
		[DispId(237)]
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Struct)]
		object AutoFit();

		// Token: 0x060000E2 RID: 226
		void _VtblGap2_3();

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000E3 RID: 227
		Borders Borders { [DispId(435)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000E4 RID: 228
		void _VtblGap3_25();

		// Token: 0x1700002D RID: 45
		[IndexerName("_Default")]
		object this[[MarshalAs(UnmanagedType.Struct)] [In] [Optional] object RowIndex, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object ColumnIndex]
		{
			[DispId(0)]
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(0)]
			[PreserveSig]
			[param: MarshalAs(UnmanagedType.Struct)]
			[param: In]
			[param: Optional]
			set;
		}

		// Token: 0x060000E7 RID: 231
		void _VtblGap4_7();

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000E8 RID: 232
		Range EntireColumn { [DispId(246)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000E9 RID: 233
		void _VtblGap5_8();

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000EA RID: 234
		Font Font { [DispId(146)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000EB RID: 235
		void _VtblGap6_22();

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000EC RID: 236
		// (set) Token: 0x060000ED RID: 237
		object HorizontalAlignment { [DispId(136)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(136)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x060000EE RID: 238
		void _VtblGap7_4();

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000EF RID: 239
		Interior Interior { [DispId(129)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000F0 RID: 240
		void _VtblGap8_82();

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000F1 RID: 241
		// (set) Token: 0x060000F2 RID: 242
		object Value2 { [DispId(1388)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(1388)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
