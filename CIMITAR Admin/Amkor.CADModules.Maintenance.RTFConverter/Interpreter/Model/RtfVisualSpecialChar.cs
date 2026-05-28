using System;
using Amkor.CADModules.Maintenance.GrobalConst;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000083 RID: 131
	public sealed class RtfVisualSpecialChar : RtfVisual, IRtfVisualSpecialChar, IRtfVisual
	{
		// Token: 0x06000423 RID: 1059 RVA: 0x0000BAF5 File Offset: 0x00009CF5
		public RtfVisualSpecialChar(RtfVisualSpecialCharKind charKind) : base(RtfVisualKind.Special)
		{
			this.charKind = charKind;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000BB07 File Offset: 0x00009D07
		protected override void DoVisit(IRtfVisualVisitor visitor, cConst.Upload.HTMLtype type)
		{
			visitor.VisitSpecial(this);
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0000BB14 File Offset: 0x00009D14
		public RtfVisualSpecialCharKind CharKind
		{
			get
			{
				return this.charKind;
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000BB2C File Offset: 0x00009D2C
		protected override bool IsEqual(object obj)
		{
			RtfVisualSpecialChar rtfVisualSpecialChar = obj as RtfVisualSpecialChar;
			return rtfVisualSpecialChar != null && base.IsEqual(rtfVisualSpecialChar) && this.charKind == rtfVisualSpecialChar.charKind;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0000BB64 File Offset: 0x00009D64
		protected override int ComputeHashCode()
		{
			return HashTool.AddHashCode(base.ComputeHashCode(), this.charKind);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000BB8C File Offset: 0x00009D8C
		public override string ToString()
		{
			return this.charKind.ToString();
		}

		// Token: 0x04000189 RID: 393
		private readonly RtfVisualSpecialCharKind charKind;
	}
}
