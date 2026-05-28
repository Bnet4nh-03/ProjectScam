using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Parser
{
	// Token: 0x0200006A RID: 106
	public class RtfParserListenerBase : IRtfParserListener
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060002DD RID: 733 RVA: 0x00008160 File Offset: 0x00006360
		public int Level
		{
			get
			{
				return this.level;
			}
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00008178 File Offset: 0x00006378
		public void ParseBegin()
		{
			this.level = 0;
			this.DoParseBegin();
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoParseBegin()
		{
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00008189 File Offset: 0x00006389
		public void GroupBegin()
		{
			this.DoGroupBegin();
			this.level++;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoGroupBegin()
		{
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000081A4 File Offset: 0x000063A4
		public void TagFound(IRtfTag tag)
		{
			bool flag = tag != null;
			if (flag)
			{
				this.DoTagFound(tag);
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoTagFound(IRtfTag tag)
		{
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000081C4 File Offset: 0x000063C4
		public void TextFound(IRtfText text)
		{
			bool flag = text != null;
			if (flag)
			{
				this.DoTextFound(text);
			}
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoTextFound(IRtfText text)
		{
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000081E4 File Offset: 0x000063E4
		public void GroupEnd()
		{
			this.level--;
			this.DoGroupEnd();
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoGroupEnd()
		{
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000081FC File Offset: 0x000063FC
		public void ParseSuccess()
		{
			this.DoParseSuccess();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoParseSuccess()
		{
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00008206 File Offset: 0x00006406
		public void ParseFail(RtfException reason)
		{
			this.DoParseFail(reason);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoParseFail(RtfException reason)
		{
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00008211 File Offset: 0x00006411
		public void ParseEnd()
		{
			this.DoParseEnd();
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoParseEnd()
		{
		}

		// Token: 0x04000123 RID: 291
		private int level;
	}
}
