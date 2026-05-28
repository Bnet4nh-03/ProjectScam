using System;
using Amkor.CADModules.Maintenance.GrobalConst;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support
{
	// Token: 0x02000072 RID: 114
	public class RtfVisualVisitorBase : IRtfVisualVisitor
	{
		// Token: 0x06000350 RID: 848 RVA: 0x000094C0 File Offset: 0x000076C0
		public void VisitText(IRtfVisualText visualText, cConst.Upload.HTMLtype type)
		{
			bool flag = visualText != null;
			if (flag)
			{
				this.DoVisitText(visualText, type);
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoVisitText(IRtfVisualText visualText, cConst.Upload.HTMLtype type)
		{
		}

		// Token: 0x06000352 RID: 850 RVA: 0x000094E4 File Offset: 0x000076E4
		public void VisitBreak(IRtfVisualBreak visualBreak, cConst.Upload.HTMLtype type)
		{
			bool flag = visualBreak != null;
			if (flag)
			{
				this.DoVisitBreak(visualBreak, type);
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoVisitBreak(IRtfVisualBreak visualBreak, cConst.Upload.HTMLtype type)
		{
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00009508 File Offset: 0x00007708
		public void VisitSpecial(IRtfVisualSpecialChar visualSpecialChar)
		{
			bool flag = visualSpecialChar != null;
			if (flag)
			{
				this.DoVisitSpecial(visualSpecialChar);
			}
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoVisitSpecial(IRtfVisualSpecialChar visualSpecialChar)
		{
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00009528 File Offset: 0x00007728
		public void VisitImage(IRtfVisualImage visualImage, cConst.Upload.HTMLtype type)
		{
			bool flag = visualImage != null;
			if (flag)
			{
				this.DoVisitImage(visualImage, type);
			}
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoVisitImage(IRtfVisualImage visualImage, cConst.Upload.HTMLtype type)
		{
		}
	}
}
