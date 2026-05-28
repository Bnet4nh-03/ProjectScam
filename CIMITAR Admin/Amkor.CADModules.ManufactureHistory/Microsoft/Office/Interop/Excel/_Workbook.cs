using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200001F RID: 31
	[Guid("000208DA-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[CompilerGenerated]
	[ComImport]
	public interface _Workbook
	{
		// Token: 0x060000D4 RID: 212
		void _VtblGap1_20();

		// Token: 0x060000D5 RID: 213
		[DispId(277)]
		[LCIDConversion(3)]
		void Close([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object SaveChanges, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Filename, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object RouteWorkbook);

		// Token: 0x060000D6 RID: 214
		void _VtblGap2_103();

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000D7 RID: 215
		Sheets Worksheets { [DispId(494)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000D8 RID: 216
		void _VtblGap3_40();

		// Token: 0x060000D9 RID: 217
		[DispId(1925)]
		[LCIDConversion(12)]
		void SaveAs([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Filename, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object FileFormat, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Password, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object WriteResPassword, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object ReadOnlyRecommended, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object CreateBackup, [In] XlSaveAsAccessMode AccessMode = XlSaveAsAccessMode.xlNoChange, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object ConflictResolution, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object AddToMru, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object TextCodepage, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object TextVisualLayout, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Local);
	}
}
