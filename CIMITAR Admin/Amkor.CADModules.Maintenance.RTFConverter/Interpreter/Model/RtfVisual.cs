using System;
using Amkor.CADModules.Maintenance.GrobalConst;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x0200007F RID: 127
	public abstract class RtfVisual : IRtfVisual
	{
		// Token: 0x060003FE RID: 1022 RVA: 0x0000B37F File Offset: 0x0000957F
		protected RtfVisual(RtfVisualKind kind)
		{
			this.kind = kind;
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000B390 File Offset: 0x00009590
		public RtfVisualKind Kind
		{
			get
			{
				return this.kind;
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0000B3A8 File Offset: 0x000095A8
		public void Visit(IRtfVisualVisitor visitor, cConst.Upload.HTMLtype type)
		{
			bool flag = visitor == null;
			if (flag)
			{
				throw new ArgumentNullException("visitor");
			}
			this.DoVisit(visitor, type);
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0000B3D4 File Offset: 0x000095D4
		public sealed override bool Equals(object obj)
		{
			bool flag = obj == this;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = obj == null || base.GetType() != obj.GetType();
				result = (!flag2 && this.IsEqual(obj));
			}
			return result;
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0000B41C File Offset: 0x0000961C
		public sealed override int GetHashCode()
		{
			return HashTool.AddHashCode(base.GetType().GetHashCode(), this.ComputeHashCode());
		}

		// Token: 0x06000403 RID: 1027
		protected abstract void DoVisit(IRtfVisualVisitor visitor, cConst.Upload.HTMLtype type);

		// Token: 0x06000404 RID: 1028 RVA: 0x0000B444 File Offset: 0x00009644
		protected virtual bool IsEqual(object obj)
		{
			return true;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000B458 File Offset: 0x00009658
		protected virtual int ComputeHashCode()
		{
			return 251705873;
		}

		// Token: 0x0400017D RID: 381
		private readonly RtfVisualKind kind;
	}
}
