using System;

namespace Amkor.CADModules.HccSTReportModule.Class
{
	// Token: 0x02000020 RID: 32
	public class CCommonVal
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x0001A23C File Offset: 0x0001843C
		public CCommonVal()
		{
			this.strPeriod = string.Empty;
			this.strPlantCode = string.Empty;
			this.strOwnership = string.Empty;
			this.strHwType = string.Empty;
			this.strSTDivName = string.Empty;
			this.strSTDivHwId = string.Empty;
			this.strOsatCodifiedId = string.Empty;
			this.strOsatCodifiedSn = string.Empty;
			this.strConditionStatus = string.Empty;
			this.strDevFamily = string.Empty;
			this.strLocation = string.Empty;
			this.strTransTrackingNo = string.Empty;
			this.strIncommChkReportNo = string.Empty;
			this.strRemark = string.Empty;
			this.strDataType = string.Empty;
		}

		// Token: 0x040001CB RID: 459
		public int iId;

		// Token: 0x040001CC RID: 460
		public string strPeriod;

		// Token: 0x040001CD RID: 461
		public string strPlantCode;

		// Token: 0x040001CE RID: 462
		public string strOwnership;

		// Token: 0x040001CF RID: 463
		public string strHwType;

		// Token: 0x040001D0 RID: 464
		public string strSTDivName;

		// Token: 0x040001D1 RID: 465
		public string strSTDivHwId;

		// Token: 0x040001D2 RID: 466
		public int iGobmAssetNumber;

		// Token: 0x040001D3 RID: 467
		public string strOsatCodifiedId;

		// Token: 0x040001D4 RID: 468
		public string strOsatCodifiedSn;

		// Token: 0x040001D5 RID: 469
		public string strConditionStatus;

		// Token: 0x040001D6 RID: 470
		public DateTime dtLastStatusUpDate;

		// Token: 0x040001D7 RID: 471
		public string strDevFamily;

		// Token: 0x040001D8 RID: 472
		public string strLocation;

		// Token: 0x040001D9 RID: 473
		public DateTime dtRecvDate;

		// Token: 0x040001DA RID: 474
		public string strTransTrackingNo;

		// Token: 0x040001DB RID: 475
		public string strIncommChkReportNo;

		// Token: 0x040001DC RID: 476
		public string strRemark;

		// Token: 0x040001DD RID: 477
		public string strDataType;

		// Token: 0x040001DE RID: 478
		public int iDataTypeId;
	}
}
