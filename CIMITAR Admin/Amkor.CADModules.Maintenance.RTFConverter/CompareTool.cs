using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000040 RID: 64
	public static class CompareTool
	{
		// Token: 0x06000151 RID: 337 RVA: 0x00003510 File Offset: 0x00001710
		public static bool AreEqual(object left, object right)
		{
			return left == right || (left != null && left.Equals(right));
		}
	}
}
