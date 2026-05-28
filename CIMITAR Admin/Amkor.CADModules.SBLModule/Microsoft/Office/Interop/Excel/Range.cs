using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000027 RID: 39
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[CompilerGenerated]
	[TypeIdentifier]
	[Guid("00020846-0000-0000-C000-000000000046")]
	[ComImport]
	public interface Range : IEnumerable
	{
		// Token: 0x06000122 RID: 290
		void _VtblGap1_15();

		// Token: 0x06000123 RID: 291
		[DispId(237)]
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Struct)]
		object AutoFit();

		// Token: 0x06000124 RID: 292
		void _VtblGap2_3();

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000125 RID: 293
		Borders Borders { [DispId(435)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000126 RID: 294
		void _VtblGap3_25();

		// Token: 0x1700002C RID: 44
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

		// Token: 0x06000129 RID: 297
		void _VtblGap4_7();

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600012A RID: 298
		Range EntireColumn { [DispId(246)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x0600012B RID: 299
		void _VtblGap5_8();

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600012C RID: 300
		Font Font { [DispId(146)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x0600012D RID: 301
		void _VtblGap6_22();

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600012E RID: 302
		// (set) Token: 0x0600012F RID: 303
		object HorizontalAlignment { [DispId(136)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(136)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		// Token: 0x06000130 RID: 304
		void _VtblGap7_4();

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000131 RID: 305
		Interior Interior { [DispId(129)] [PreserveSig] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000132 RID: 306
		void _VtblGap8_82();

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000133 RID: 307
		// (set) Token: 0x06000134 RID: 308
		object Value2 { [DispId(1388)] [PreserveSig] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(1388)] [PreserveSig] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
