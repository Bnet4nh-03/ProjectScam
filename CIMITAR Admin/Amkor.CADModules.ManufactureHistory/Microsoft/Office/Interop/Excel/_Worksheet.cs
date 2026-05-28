using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000016 RID: 22
	[TypeIdentifier]
	[Guid("000208D8-0000-0000-C000-000000000046")]
	[CompilerGenerated]
	[ComImport]
	public interface _Worksheet
	{
		// Token: 0x060000A6 RID: 166
		void _VtblGap1_11();

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000A7 RID: 167
		// (set) Token: 0x060000A8 RID: 168
		string Name { [DispId(110)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(110)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x060000A9 RID: 169
		void _VtblGap2_32();

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000AA RID: 170
		Range Cells { [DispId(238)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060000AB RID: 171
		void _VtblGap3_47();

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000AC RID: 172
		Range Range { [DispId(197)] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
