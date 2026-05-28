using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000025 RID: 37
	[Guid("000208D8-0000-0000-C000-000000000046")]
	[CompilerGenerated]
	[TypeIdentifier]
	[ComImport]
	public interface _Worksheet
	{
		// Token: 0x0600011B RID: 283
		void _VtblGap1_11();

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600011C RID: 284
		// (set) Token: 0x0600011D RID: 285
		string Name { [DispId(110)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(110)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x0600011E RID: 286
		void _VtblGap2_32();

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600011F RID: 287
		Range Cells { [DispId(238)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000120 RID: 288
		void _VtblGap3_47();

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000121 RID: 289
		Range Range { [DispId(197)] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
