using System;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x0200000F RID: 15
	public class CInsertInfo
	{
		// Token: 0x0600000F RID: 15 RVA: 0x000026BF File Offset: 0x000008BF
		public CInsertInfo()
		{
			this.strSite = string.Empty;
			this.strName = string.Empty;
			this.strComment = string.Empty;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000026E8 File Offset: 0x000008E8
		public int CheckInfo()
		{
			if (this.strSite != "" && this.strName != "" && this.strComment != "")
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x04000098 RID: 152
		public string strSite;

		// Token: 0x04000099 RID: 153
		public string strName;

		// Token: 0x0400009A RID: 154
		public string strComment;
	}
}
