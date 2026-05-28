using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200002C RID: 44
	[TypeIdentifier]
	[Guid("000208DA-0000-0000-C000-000000000046")]
	[CompilerGenerated]
	[ComImport]
	public interface _Workbook
	{
		// Token: 0x06000143 RID: 323
		void _VtblGap1_20();

		// Token: 0x06000144 RID: 324
		[LCIDConversion(3)]
		[DispId(277)]
		void Close([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object SaveChanges, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Filename, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object RouteWorkbook);

		// Token: 0x06000145 RID: 325
		void _VtblGap2_103();

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000146 RID: 326
		Sheets Worksheets { [DispId(494)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000147 RID: 327
		void _VtblGap3_40();

		// Token: 0x06000148 RID: 328
		[DispId(1925)]
		[LCIDConversion(12)]
		void SaveAs([MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Filename, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object FileFormat, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Password, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object WriteResPassword, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object ReadOnlyRecommended, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object CreateBackup, [In] XlSaveAsAccessMode AccessMode = XlSaveAsAccessMode.xlNoChange, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object ConflictResolution, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object AddToMru, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object TextCodepage, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object TextVisualLayout, [MarshalAs(UnmanagedType.Struct)] [In] [Optional] object Local);
	}
}
