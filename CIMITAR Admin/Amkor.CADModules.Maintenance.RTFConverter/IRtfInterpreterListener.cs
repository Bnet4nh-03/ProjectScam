using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200000D RID: 13
	public interface IRtfInterpreterListener
	{
		// Token: 0x06000068 RID: 104
		void BeginDocument(IRtfInterpreterContext context);

		// Token: 0x06000069 RID: 105
		void InsertText(IRtfInterpreterContext context, string text);

		// Token: 0x0600006A RID: 106
		void InsertSpecialChar(IRtfInterpreterContext context, RtfVisualSpecialCharKind kind);

		// Token: 0x0600006B RID: 107
		void InsertBreak(IRtfInterpreterContext context, RtfVisualBreakKind kind);

		// Token: 0x0600006C RID: 108
		void InsertImage(IRtfInterpreterContext context, RtfVisualImageFormat format, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex);

		// Token: 0x0600006D RID: 109
		void EndDocument(IRtfInterpreterContext context);
	}
}
