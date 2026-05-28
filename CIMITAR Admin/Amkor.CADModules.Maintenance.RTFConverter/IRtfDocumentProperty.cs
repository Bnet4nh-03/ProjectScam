using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000007 RID: 7
	public interface IRtfDocumentProperty
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000043 RID: 67
		int PropertyKindCode { get; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000044 RID: 68
		RtfPropertyKind PropertyKind { get; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000045 RID: 69
		string Name { get; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000046 RID: 70
		string StaticValue { get; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000047 RID: 71
		string LinkValue { get; }
	}
}
