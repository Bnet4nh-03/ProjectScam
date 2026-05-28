using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200002B RID: 43
	public interface IRtfElementVisitor
	{
		// Token: 0x060000C1 RID: 193
		void VisitTag(IRtfTag tag);

		// Token: 0x060000C2 RID: 194
		void VisitGroup(IRtfGroup group);

		// Token: 0x060000C3 RID: 195
		void VisitText(IRtfText text);
	}
}
