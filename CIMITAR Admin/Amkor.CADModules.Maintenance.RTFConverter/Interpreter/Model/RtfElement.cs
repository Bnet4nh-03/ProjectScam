using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000086 RID: 134
	public abstract class RtfElement : IRtfElement
	{
		// Token: 0x06000437 RID: 1079 RVA: 0x0000BDD0 File Offset: 0x00009FD0
		protected RtfElement(RtfElementKind kind)
		{
			this.kind = kind;
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x0000BDE4 File Offset: 0x00009FE4
		public RtfElementKind Kind
		{
			get
			{
				return this.kind;
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0000BDFC File Offset: 0x00009FFC
		public void Visit(IRtfElementVisitor visitor)
		{
			bool flag = visitor == null;
			if (flag)
			{
				throw new ArgumentNullException("visitor");
			}
			this.DoVisit(visitor);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0000BE28 File Offset: 0x0000A028
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

		// Token: 0x0600043B RID: 1083 RVA: 0x0000BE70 File Offset: 0x0000A070
		public sealed override int GetHashCode()
		{
			return HashTool.AddHashCode(base.GetType().GetHashCode(), this.ComputeHashCode());
		}

		// Token: 0x0600043C RID: 1084
		protected abstract void DoVisit(IRtfElementVisitor visitor);

		// Token: 0x0600043D RID: 1085 RVA: 0x0000BE98 File Offset: 0x0000A098
		protected virtual bool IsEqual(object obj)
		{
			return true;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0000BEAC File Offset: 0x0000A0AC
		protected virtual int ComputeHashCode()
		{
			return 251705873;
		}

		// Token: 0x0400018C RID: 396
		private readonly RtfElementKind kind;
	}
}
