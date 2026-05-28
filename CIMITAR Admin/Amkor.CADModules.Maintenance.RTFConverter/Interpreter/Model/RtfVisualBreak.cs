using System;
using Amkor.CADModules.Maintenance.GrobalConst;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000080 RID: 128
	public sealed class RtfVisualBreak : RtfVisual, IRtfVisualBreak, IRtfVisual
	{
		// Token: 0x06000406 RID: 1030 RVA: 0x0000B46F File Offset: 0x0000966F
		public RtfVisualBreak(RtfVisualBreakKind breakKind) : base(RtfVisualKind.Break)
		{
			this.breakKind = breakKind;
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x0000B484 File Offset: 0x00009684
		public RtfVisualBreakKind BreakKind
		{
			get
			{
				return this.breakKind;
			}
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000B49C File Offset: 0x0000969C
		public override string ToString()
		{
			return this.breakKind.ToString();
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000B4C2 File Offset: 0x000096C2
		protected override void DoVisit(IRtfVisualVisitor visitor, cConst.Upload.HTMLtype type)
		{
			visitor.VisitBreak(this, type);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000B4D0 File Offset: 0x000096D0
		protected override bool IsEqual(object obj)
		{
			RtfVisualBreak rtfVisualBreak = obj as RtfVisualBreak;
			return rtfVisualBreak != null && base.IsEqual(rtfVisualBreak) && this.breakKind == rtfVisualBreak.breakKind;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000B508 File Offset: 0x00009708
		protected override int ComputeHashCode()
		{
			return HashTool.AddHashCode(base.ComputeHashCode(), this.breakKind);
		}

		// Token: 0x0400017E RID: 382
		private readonly RtfVisualBreakKind breakKind;
	}
}
