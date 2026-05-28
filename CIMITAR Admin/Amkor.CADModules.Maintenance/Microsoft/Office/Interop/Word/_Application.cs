using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
	// Token: 0x0200007B RID: 123
	[CompilerGenerated]
	[DefaultMember("Name")]
	[Guid("00020970-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Application
	{
		// Token: 0x0600063B RID: 1595
		void _VtblGap1_3();

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600063C RID: 1596
		[DispId(0)]
		[IndexerName("Name")]
		string Name { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }
	}
}
