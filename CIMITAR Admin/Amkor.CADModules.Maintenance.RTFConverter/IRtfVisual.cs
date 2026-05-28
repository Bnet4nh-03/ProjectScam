using System;
using Amkor.CADModules.Maintenance.GrobalConst;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000011 RID: 17
	public interface IRtfVisual
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000084 RID: 132
		RtfVisualKind Kind { get; }

		// Token: 0x06000085 RID: 133
		void Visit(IRtfVisualVisitor visitor, cConst.Upload.HTMLtype type);
	}
}
