using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support
{
	// Token: 0x0200006F RID: 111
	public class RtfElementVisitorBase : IRtfElementVisitor
	{
		// Token: 0x06000334 RID: 820 RVA: 0x0000911E File Offset: 0x0000731E
		public RtfElementVisitorBase(RtfElementVisitorOrder order)
		{
			this.order = order;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00009130 File Offset: 0x00007330
		public void VisitTag(IRtfTag tag)
		{
			bool flag = tag != null;
			if (flag)
			{
				this.DoVisitTag(tag);
			}
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoVisitTag(IRtfTag tag)
		{
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00009150 File Offset: 0x00007350
		public void VisitGroup(IRtfGroup group)
		{
			bool flag = group != null;
			if (flag)
			{
				bool flag2 = this.order == RtfElementVisitorOrder.DepthFirst;
				if (flag2)
				{
					this.VisitGroupChildren(group);
				}
				this.DoVisitGroup(group);
				bool flag3 = this.order == RtfElementVisitorOrder.BreadthFirst;
				if (flag3)
				{
					this.VisitGroupChildren(group);
				}
			}
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoVisitGroup(IRtfGroup group)
		{
		}

		// Token: 0x06000339 RID: 825 RVA: 0x000091A0 File Offset: 0x000073A0
		protected void VisitGroupChildren(IRtfGroup group)
		{
			foreach (object obj in group.Contents)
			{
				IRtfElement rtfElement = (IRtfElement)obj;
				rtfElement.Visit(this);
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00009200 File Offset: 0x00007400
		public void VisitText(IRtfText text)
		{
			bool flag = text != null;
			if (flag)
			{
				this.DoVisitText(text);
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00003C93 File Offset: 0x00001E93
		protected virtual void DoVisitText(IRtfText text)
		{
		}

		// Token: 0x0400013A RID: 314
		private readonly RtfElementVisitorOrder order;
	}
}
