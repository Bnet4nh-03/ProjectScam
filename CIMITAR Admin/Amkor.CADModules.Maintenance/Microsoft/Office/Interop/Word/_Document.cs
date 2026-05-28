using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
	// Token: 0x0200007C RID: 124
	[CompilerGenerated]
	[DefaultMember("Name")]
	[Guid("0002096B-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Document
	{
		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600063D RID: 1597
		[DispId(0)]
		[IndexerName("Name")]
		string Name { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }
	}
}
