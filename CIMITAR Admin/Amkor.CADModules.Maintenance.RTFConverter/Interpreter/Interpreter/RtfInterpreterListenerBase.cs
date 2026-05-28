using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000093 RID: 147
	public class RtfInterpreterListenerBase : IRtfInterpreterListener
	{
		// Token: 0x060004BD RID: 1213 RVA: 0x0000FAB4 File Offset: 0x0000DCB4
		public void BeginDocument(IRtfInterpreterContext context)
		{
			bool flag = context != null;
			if (flag)
			{
				this.DoBeginDocument(context);
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0000FAD4 File Offset: 0x0000DCD4
		public void InsertText(IRtfInterpreterContext context, string text)
		{
			bool flag = context != null;
			if (flag)
			{
				this.DoInsertText(context, text);
			}
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0000FAF8 File Offset: 0x0000DCF8
		public void InsertSpecialChar(IRtfInterpreterContext context, RtfVisualSpecialCharKind kind)
		{
			bool flag = context != null;
			if (flag)
			{
				this.DoInsertSpecialChar(context, kind);
			}
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000FB1C File Offset: 0x0000DD1C
		public void InsertBreak(IRtfInterpreterContext context, RtfVisualBreakKind kind)
		{
			bool flag = context != null;
			if (flag)
			{
				this.DoInsertBreak(context, kind);
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0000FB40 File Offset: 0x0000DD40
		public void InsertImage(IRtfInterpreterContext context, RtfVisualImageFormat format, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex)
		{
			bool flag = context != null;
			if (flag)
			{
				this.DoInsertImage(context, format, width, height, desiredWidth, desiredHeight, scaleWidthPercent, scaleHeightPercent, imageDataHex);
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0000FB70 File Offset: 0x0000DD70
		public void EndDocument(IRtfInterpreterContext context)
		{
			bool flag = context != null;
			if (flag)
			{
				this.DoEndDocument(context);
			}
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoBeginDocument(IRtfInterpreterContext context)
		{
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoInsertText(IRtfInterpreterContext context, string text)
		{
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoInsertSpecialChar(IRtfInterpreterContext context, RtfVisualSpecialCharKind kind)
		{
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoInsertBreak(IRtfInterpreterContext context, RtfVisualBreakKind kind)
		{
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoInsertImage(IRtfInterpreterContext context, RtfVisualImageFormat format, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex)
		{
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoEndDocument(IRtfInterpreterContext context)
		{
		}
	}
}
