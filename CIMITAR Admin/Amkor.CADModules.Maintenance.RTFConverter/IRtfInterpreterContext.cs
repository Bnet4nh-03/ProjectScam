using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200000C RID: 12
	public interface IRtfInterpreterContext
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600005B RID: 91
		RtfInterpreterState State { get; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600005C RID: 92
		int RtfVersion { get; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600005D RID: 93
		string DefaultFontId { get; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600005E RID: 94
		IRtfFont DefaultFont { get; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600005F RID: 95
		IRtfFontCollection FontTable { get; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000060 RID: 96
		IRtfColorCollection ColorTable { get; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000061 RID: 97
		string Generator { get; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000062 RID: 98
		IRtfTextFormatCollection UniqueTextFormats { get; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000063 RID: 99
		IRtfTextFormat CurrentTextFormat { get; }

		// Token: 0x06000064 RID: 100
		IRtfTextFormat GetSafeCurrentTextFormat();

		// Token: 0x06000065 RID: 101
		IRtfTextFormat GetUniqueTextFormatInstance(IRtfTextFormat templateFormat);

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000066 RID: 102
		IRtfDocumentInfo DocumentInfo { get; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000067 RID: 103
		IRtfDocumentPropertyCollection UserProperties { get; }
	}
}
