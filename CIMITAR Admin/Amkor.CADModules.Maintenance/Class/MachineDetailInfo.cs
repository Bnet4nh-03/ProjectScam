using System;

namespace Amkor.CADModules.Maintenance.Class
{
	// Token: 0x0200005B RID: 91
	public class MachineDetailInfo
	{
		// Token: 0x060005F0 RID: 1520 RVA: 0x0008E18C File Offset: 0x0008C38C
		public MachineDetailInfo()
		{
			this.sReportName = string.Empty;
			this.sTeam = string.Empty;
			this.sName = string.Empty;
			this.sCategory = string.Empty;
			this.sType = string.Empty;
			this.sModel = string.Empty;
			this.sMachine = string.Empty;
			this.sCase = string.Empty;
			this.sComment = string.Empty;
			this.sAlterTime = string.Empty;
			this.sActionTeam = string.Empty;
			this.sActionName = string.Empty;
			this.sProblem = string.Empty;
			this.sAction = string.Empty;
			this.sPart = string.Empty;
			this.sPartDescription = string.Empty;
			this.sHold = string.Empty;
			this.sStatus = string.Empty;
			this.sDiff = string.Empty;
			this.bDiffTime = false;
			this.sMailForm = string.Empty;
			this.CalculationTime = default(TimeSpan);
		}

		// Token: 0x04000751 RID: 1873
		public string sStatus;

		// Token: 0x04000752 RID: 1874
		public string sReportName;

		// Token: 0x04000753 RID: 1875
		public string sTeam;

		// Token: 0x04000754 RID: 1876
		public string sName;

		// Token: 0x04000755 RID: 1877
		public string sCategory;

		// Token: 0x04000756 RID: 1878
		public string sType;

		// Token: 0x04000757 RID: 1879
		public string sModel;

		// Token: 0x04000758 RID: 1880
		public string sMachine;

		// Token: 0x04000759 RID: 1881
		public string sCase;

		// Token: 0x0400075A RID: 1882
		public string sComment;

		// Token: 0x0400075B RID: 1883
		public string sAlterTime;

		// Token: 0x0400075C RID: 1884
		public DateTime dtRequestDate;

		// Token: 0x0400075D RID: 1885
		public string sActionTeam;

		// Token: 0x0400075E RID: 1886
		public string sActionName;

		// Token: 0x0400075F RID: 1887
		public string sProblem;

		// Token: 0x04000760 RID: 1888
		public string sAction;

		// Token: 0x04000761 RID: 1889
		public string sPart;

		// Token: 0x04000762 RID: 1890
		public string sPartDescription;

		// Token: 0x04000763 RID: 1891
		public DateTime dtStartDate;

		// Token: 0x04000764 RID: 1892
		public DateTime dtEndDate;

		// Token: 0x04000765 RID: 1893
		public string sHold;

		// Token: 0x04000766 RID: 1894
		public string sDiff;

		// Token: 0x04000767 RID: 1895
		public bool bDiffTime;

		// Token: 0x04000768 RID: 1896
		public TimeSpan CalculationTime;

		// Token: 0x04000769 RID: 1897
		public string sMailForm;
	}
}
