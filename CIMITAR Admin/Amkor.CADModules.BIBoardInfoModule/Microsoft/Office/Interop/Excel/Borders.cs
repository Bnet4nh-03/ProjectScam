using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000035 RID: 53
	[CompilerGenerated]
	[InterfaceType(2)]
	[DefaultMember("_Default")]
	[Guid("00020855-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Borders : IEnumerable
	{
		// Token: 0x0600019D RID: 413
		void _VtblGap1_14();

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600019E RID: 414
		// (set) Token: 0x0600019F RID: 415
		[DispId(120)]
		object Weight { [DispId(120)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(120)] [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }
	}
}
