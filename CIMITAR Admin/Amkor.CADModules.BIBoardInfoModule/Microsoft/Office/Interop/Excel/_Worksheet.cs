using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000042 RID: 66
	[CompilerGenerated]
	[Guid("000208D8-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Worksheet
	{
		// Token: 0x060001CA RID: 458
		void _VtblGap1_11();

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060001CB RID: 459
		// (set) Token: 0x060001CC RID: 460
		[DispId(110)]
		string Name { [DispId(110)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(110)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x060001CD RID: 461
		void _VtblGap2_32();

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060001CE RID: 462
		[DispId(238)]
		Range Cells { [DispId(238)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060001CF RID: 463
		void _VtblGap3_47();

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060001D0 RID: 464
		[DispId(197)]
		Range Range { [DispId(197)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
