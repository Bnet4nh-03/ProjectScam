using System;
using System.Text;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000094 RID: 148
	public sealed class RtfInterpreterListenerDocumentBuilder : RtfInterpreterListenerBase
	{
		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x0000FB90 File Offset: 0x0000DD90
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x0000FBA8 File Offset: 0x0000DDA8
		public bool CombineTextWithSameFormat
		{
			get
			{
				return this.combineTextWithSameFormat;
			}
			set
			{
				this.combineTextWithSameFormat = value;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x0000FBB4 File Offset: 0x0000DDB4
		public IRtfDocument Document
		{
			get
			{
				return this.document;
			}
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0000FBCC File Offset: 0x0000DDCC
		protected override void DoBeginDocument(IRtfInterpreterContext context)
		{
			this.document = null;
			this.visualDocumentContent = new RtfVisualCollection();
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0000FBE4 File Offset: 0x0000DDE4
		protected override void DoInsertText(IRtfInterpreterContext context, string text)
		{
			bool flag = this.combineTextWithSameFormat;
			if (flag)
			{
				IRtfTextFormat safeCurrentTextFormat = context.GetSafeCurrentTextFormat();
				bool flag2 = !safeCurrentTextFormat.Equals(this.pendingTextFormat);
				if (flag2)
				{
					this.FlushPendingText();
				}
				this.pendingTextFormat = safeCurrentTextFormat;
				this.pendingText.Append(text);
			}
			else
			{
				this.AppendAlignedVisual(new RtfVisualText(text, cConst.Upload.HTMLtype.none, context.GetSafeCurrentTextFormat()));
			}
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0000FC4D File Offset: 0x0000DE4D
		protected override void DoInsertSpecialChar(IRtfInterpreterContext context, RtfVisualSpecialCharKind kind)
		{
			this.FlushPendingText();
			this.visualDocumentContent.Add(new RtfVisualSpecialChar(kind));
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000FC6C File Offset: 0x0000DE6C
		protected override void DoInsertBreak(IRtfInterpreterContext context, RtfVisualBreakKind kind)
		{
			this.FlushPendingText();
			this.visualDocumentContent.Add(new RtfVisualBreak(kind));
			if (kind - RtfVisualBreakKind.Paragraph <= 1)
			{
				this.EndParagraph(context);
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0000FCA8 File Offset: 0x0000DEA8
		protected override void DoInsertImage(IRtfInterpreterContext context, RtfVisualImageFormat format, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex)
		{
			this.FlushPendingText();
			this.AppendAlignedVisual(new RtfVisualImage(format, context.GetSafeCurrentTextFormat().Alignment, width, height, desiredWidth, desiredHeight, scaleWidthPercent, scaleHeightPercent, imageDataHex));
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000FCE2 File Offset: 0x0000DEE2
		protected override void DoEndDocument(IRtfInterpreterContext context)
		{
			this.FlushPendingText();
			this.EndParagraph(context);
			this.document = new RtfDocument(context, this.visualDocumentContent);
			this.visualDocumentContent = null;
			this.visualDocumentContent = null;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0000FD14 File Offset: 0x0000DF14
		private void EndParagraph(IRtfInterpreterContext context)
		{
			RtfTextAlignment alignment = context.GetSafeCurrentTextFormat().Alignment;
			foreach (object obj in this.pendingParagraphContent)
			{
				IRtfVisual rtfVisual = (IRtfVisual)obj;
				RtfVisualKind kind = rtfVisual.Kind;
				if (kind != RtfVisualKind.Text)
				{
					if (kind == RtfVisualKind.Image)
					{
						RtfVisualImage rtfVisualImage = (RtfVisualImage)rtfVisual;
						bool flag = rtfVisualImage.Alignment != alignment;
						if (flag)
						{
							rtfVisualImage.Alignment = alignment;
						}
					}
				}
				else
				{
					RtfVisualText rtfVisualText = (RtfVisualText)rtfVisual;
					bool flag2 = rtfVisualText.Format.Alignment != alignment;
					if (flag2)
					{
						IRtfTextFormat templateFormat = ((RtfTextFormat)rtfVisualText.Format).DeriveWithAlignment(alignment);
						IRtfTextFormat uniqueTextFormatInstance = context.GetUniqueTextFormatInstance(templateFormat);
						rtfVisualText.Format = uniqueTextFormatInstance;
					}
				}
			}
			this.pendingParagraphContent.Clear();
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0000FE14 File Offset: 0x0000E014
		private void FlushPendingText()
		{
			bool flag = this.pendingTextFormat != null;
			if (flag)
			{
				this.AppendAlignedVisual(new RtfVisualText(this.pendingText.ToString(), cConst.Upload.HTMLtype.none, this.pendingTextFormat));
				this.pendingTextFormat = null;
				this.pendingText.Remove(0, this.pendingText.Length);
			}
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0000FE6E File Offset: 0x0000E06E
		private void AppendAlignedVisual(RtfVisual visual)
		{
			this.visualDocumentContent.Add(visual);
			this.pendingParagraphContent.Add(visual);
		}

		// Token: 0x040001C0 RID: 448
		private bool combineTextWithSameFormat = true;

		// Token: 0x040001C1 RID: 449
		private RtfDocument document;

		// Token: 0x040001C2 RID: 450
		private RtfVisualCollection visualDocumentContent;

		// Token: 0x040001C3 RID: 451
		private readonly RtfVisualCollection pendingParagraphContent = new RtfVisualCollection();

		// Token: 0x040001C4 RID: 452
		private IRtfTextFormat pendingTextFormat;

		// Token: 0x040001C5 RID: 453
		private readonly StringBuilder pendingText = new StringBuilder();
	}
}
