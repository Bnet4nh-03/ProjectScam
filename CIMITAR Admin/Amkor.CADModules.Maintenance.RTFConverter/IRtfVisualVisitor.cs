using System;
using Amkor.CADModules.Maintenance.GrobalConst;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000017 RID: 23
	public interface IRtfVisualVisitor
	{
		// Token: 0x06000098 RID: 152
		void VisitText(IRtfVisualText visualText, cConst.Upload.HTMLtype type);

		// Token: 0x06000099 RID: 153
		void VisitBreak(IRtfVisualBreak visualBreak, cConst.Upload.HTMLtype type);

		// Token: 0x0600009A RID: 154
		void VisitSpecial(IRtfVisualSpecialChar visualSpecialChar);

		// Token: 0x0600009B RID: 155
		void VisitImage(IRtfVisualImage visualImage, cConst.Upload.HTMLtype type);
	}
}
