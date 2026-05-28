using System;

namespace Amkor.CADModules.ManufactureHistory.GrobalConstMFG
{
	// Token: 0x02000008 RID: 8
	public class ReportInfo
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000021F8 File Offset: 0x000003F8
		public ReportInfo(string name)
		{
			this.Title = name;
		}

		// Token: 0x04000027 RID: 39
		public string Title = string.Empty;

		// Token: 0x04000028 RID: 40
		public string Category = string.Empty;

		// Token: 0x04000029 RID: 41
		public string Model = string.Empty;

		// Token: 0x0400002A RID: 42
		public string Equipment = string.Empty;

		// Token: 0x0400002B RID: 43
		public string RscDec = string.Empty;

		// Token: 0x0400002C RID: 44
		public string Operation = string.Empty;

		// Token: 0x0400002D RID: 45
		public string CustName = string.Empty;

		// Token: 0x0400002E RID: 46
		public string NickName = string.Empty;

		// Token: 0x0400002F RID: 47
		public DateTime dateTime;

		// Token: 0x04000030 RID: 48
		public string content = string.Empty;

		// Token: 0x04000031 RID: 49
		public string content2 = string.Empty;

		// Token: 0x04000032 RID: 50
		public byte[] binary = null;

		// Token: 0x04000033 RID: 51
		public byte[] binary2 = null;

		// Token: 0x04000034 RID: 52
		public string FileList = string.Empty;

		// Token: 0x04000035 RID: 53
		public string Shift = string.Empty;

		// Token: 0x04000036 RID: 54
		public string editerName = string.Empty;

		// Token: 0x04000037 RID: 55
		public string editerDepart = string.Empty;
	}
}
