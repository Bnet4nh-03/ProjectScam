using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200001A RID: 26
	[Guid("00020846-0000-0000-C000-000000000046")]
	[CompilerGenerated]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[ComImport]
	public interface Range : IEnumerable
	{
		// Token: 0x060000B3 RID: 179
		void _VtblGap1_15();

		// Token: 0x060000B4 RID: 180
		[DispId(237)]
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Struct)]
		object AutoFit();

		// Token: 0x060000B5 RID: 181
		void _VtblGap2_3();

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000B6 RID: 182
		Borders Borders { [DispId(435)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000B7 RID: 183
		void _VtblGap3_25();

		// Token: 0x1700001C RID: 28
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

		// Token: 0x060000BA RID: 186
		void _VtblGap4_7();

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000BB RID: 187
		Range EntireColumn { [DispId(246)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000BC RID: 188
		void _VtblGap5_8();

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000BD RID: 189
		Font Font { [DispId(146)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000BE RID: 190
		void _VtblGap6_22();

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000BF RID: 191
		// (set) Token: 0x060000C0 RID: 192
		object HorizontalAlignment { [DispId(136)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(136)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x060000C1 RID: 193
		void _VtblGap7_4();

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000C2 RID: 194
		Interior Interior { [DispId(129)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000C3 RID: 195
		void _VtblGap8_82();

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000C4 RID: 196
		// (set) Token: 0x060000C5 RID: 197
		object Value2 { [DispId(1388)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(1388)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
