using System;

namespace Amkor.CADModules.BoardCenterClient.Class
{
	// Token: 0x0200000D RID: 13
	public class CInsertInfo
	{
		// Token: 0x06000059 RID: 89 RVA: 0x000069DF File Offset: 0x00004BDF
		public CInsertInfo()
		{
			this.strTesterName = string.Empty;
			this.strSite = string.Empty;
			this.strName = string.Empty;
			this.strComment = string.Empty;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006A14 File Offset: 0x00004C14
		public int CheckInfo()
		{
			if (this.strTesterID != "" && this.strTesterName != "" && this.strSite != "" && this.strName != "" && this.strComment != "")
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x0400007D RID: 125
		public string strTesterID;

		// Token: 0x0400007E RID: 126
		public string strTesterName;

		// Token: 0x0400007F RID: 127
		public string strSite;

		// Token: 0x04000080 RID: 128
		public string strName;

		// Token: 0x04000081 RID: 129
		public string strComment;
	}
}
