using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000006 RID: 6
	public interface IRtfDocumentInfo
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600002D RID: 45
		int? Id { get; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600002E RID: 46
		int? Version { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600002F RID: 47
		int? Revision { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000030 RID: 48
		string Title { get; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000031 RID: 49
		string Subject { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000032 RID: 50
		string Author { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000033 RID: 51
		string Manager { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000034 RID: 52
		string Company { get; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000035 RID: 53
		string Operator { get; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000036 RID: 54
		string Category { get; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000037 RID: 55
		string Keywords { get; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000038 RID: 56
		string Comment { get; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000039 RID: 57
		string DocumentComment { get; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600003A RID: 58
		string HyperLinkbase { get; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600003B RID: 59
		DateTime? CreationTime { get; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600003C RID: 60
		DateTime? RevisionTime { get; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600003D RID: 61
		DateTime? PrintTime { get; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600003E RID: 62
		DateTime? BackupTime { get; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600003F RID: 63
		int? NumberOfPages { get; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000040 RID: 64
		int? NumberOfWords { get; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000041 RID: 65
		int? NumberOfCharacters { get; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000042 RID: 66
		int? EditingTimeInMinutes { get; }
	}
}
