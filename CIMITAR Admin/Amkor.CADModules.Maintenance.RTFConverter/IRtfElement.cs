using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000029 RID: 41
	public interface IRtfElement
	{
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060000BC RID: 188
		RtfElementKind Kind { get; }

		// Token: 0x060000BD RID: 189
		void Visit(IRtfElementVisitor visitor);
	}
}
