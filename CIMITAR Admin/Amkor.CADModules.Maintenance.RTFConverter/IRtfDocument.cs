using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000005 RID: 5
	public interface IRtfDocument
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000023 RID: 35
		int RtfVersion { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000024 RID: 36
		IRtfFont DefaultFont { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000025 RID: 37
		IRtfTextFormat DefaultTextFormat { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000026 RID: 38
		IRtfFontCollection FontTable { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000027 RID: 39
		IRtfColorCollection ColorTable { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000028 RID: 40
		string Generator { get; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000029 RID: 41
		IRtfTextFormatCollection UniqueTextFormats { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600002A RID: 42
		IRtfDocumentInfo DocumentInfo { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600002B RID: 43
		IRtfDocumentPropertyCollection UserProperties { get; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600002C RID: 44
		IRtfVisualCollection VisualContent { get; }
	}
}
