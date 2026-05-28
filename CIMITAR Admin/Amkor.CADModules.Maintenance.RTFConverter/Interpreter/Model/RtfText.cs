using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x0200008A RID: 138
	public sealed class RtfText : RtfElement, IRtfText, IRtfElement
	{
		// Token: 0x06000459 RID: 1113 RVA: 0x0000C468 File Offset: 0x0000A668
		public RtfText(string text) : base(RtfElementKind.Text)
		{
			bool flag = text == null;
			if (flag)
			{
				throw new ArgumentNullException("text");
			}
			this.text = text;
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x0000C49C File Offset: 0x0000A69C
		public string Text
		{
			get
			{
				return this.text;
			}
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0000C4B4 File Offset: 0x0000A6B4
		public override string ToString()
		{
			return this.text;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0000C4CC File Offset: 0x0000A6CC
		protected override void DoVisit(IRtfElementVisitor visitor)
		{
			visitor.VisitText(this);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0000C4D8 File Offset: 0x0000A6D8
		protected override bool IsEqual(object obj)
		{
			RtfText rtfText = obj as RtfText;
			return rtfText != null && base.IsEqual(obj) && this.text.Equals(rtfText.text);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0000C514 File Offset: 0x0000A714
		protected override int ComputeHashCode()
		{
			return HashTool.AddHashCode(base.ComputeHashCode(), this.text);
		}

		// Token: 0x04000192 RID: 402
		private readonly string text;
	}
}
