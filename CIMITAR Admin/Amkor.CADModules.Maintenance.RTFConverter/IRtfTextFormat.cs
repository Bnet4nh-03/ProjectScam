using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200000F RID: 15
	public interface IRtfTextFormat
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000072 RID: 114
		IRtfFont Font { get; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000073 RID: 115
		int FontSize { get; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000074 RID: 116
		int SuperScript { get; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000075 RID: 117
		bool IsBold { get; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000076 RID: 118
		bool IsItalic { get; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000077 RID: 119
		bool IsUnderline { get; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000078 RID: 120
		bool IsStrikeThrough { get; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000079 RID: 121
		bool IsHidden { get; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600007A RID: 122
		string FontDescriptionDebug { get; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600007B RID: 123
		IRtfColor BackgroundColor { get; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600007C RID: 124
		IRtfColor ForegroundColor { get; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600007D RID: 125
		RtfTextAlignment Alignment { get; }

		// Token: 0x0600007E RID: 126
		IRtfTextFormat Duplicate();
	}
}
