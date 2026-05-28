using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000025 RID: 37
	[Guid("000208DA-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[CompilerGenerated]
	[ComImport]
	public interface _Workbook
	{
		// Token: 0x06000101 RID: 257
		void _VtblGap1_20();

		// Token: 0x06000102 RID: 258
		[LCIDConversion(3)]
		[DispId(277)]
		void Close([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object SaveChanges, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Filename, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object RouteWorkbook);

		// Token: 0x06000103 RID: 259
		void _VtblGap2_103();

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000104 RID: 260
		Sheets Worksheets { [DispId(494)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000105 RID: 261
		void _VtblGap3_40();

		// Token: 0x06000106 RID: 262
		[DispId(1925)]
		[LCIDConversion(12)]
		void SaveAs([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Filename, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object FileFormat, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Password, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object WriteResPassword, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object ReadOnlyRecommended, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object CreateBackup, [In] XlSaveAsAccessMode AccessMode = XlSaveAsAccessMode.xlNoChange, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object ConflictResolution, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object AddToMru, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object TextCodepage, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object TextVisualLayout, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Local);
	}
}
