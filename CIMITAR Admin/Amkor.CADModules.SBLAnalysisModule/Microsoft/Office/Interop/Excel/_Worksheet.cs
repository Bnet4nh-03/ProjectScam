using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200001E RID: 30
	[TypeIdentifier]
	[Guid("000208D8-0000-0000-C000-000000000046")]
	[CompilerGenerated]
	[ComImport]
	public interface _Worksheet
	{
		// Token: 0x060000D9 RID: 217
		void _VtblGap1_11();

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000DA RID: 218
		// (set) Token: 0x060000DB RID: 219
		string Name { [DispId(110)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(110)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x060000DC RID: 220
		void _VtblGap2_32();

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000DD RID: 221
		Range Cells { [DispId(238)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000DE RID: 222
		void _VtblGap3_47();

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000DF RID: 223
		Range Range { [DispId(197)] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
