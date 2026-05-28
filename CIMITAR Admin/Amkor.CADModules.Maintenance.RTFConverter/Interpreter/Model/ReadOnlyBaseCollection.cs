using System;
using System.Collections;
using Amkor.CADModules.Maintenance.RTFConverter.Collection;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000085 RID: 133
	public abstract class ReadOnlyBaseCollection : ReadOnlyCollectionBase
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x0000BD14 File Offset: 0x00009F14
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

		// Token: 0x06000432 RID: 1074 RVA: 0x0000BD5C File Offset: 0x00009F5C
		public override string ToString()
		{
			return CollectionTool.ToString(this);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0000BD74 File Offset: 0x00009F74
		protected virtual bool IsEqual(object obj)
		{
			return CollectionTool.AreEqual(this, obj);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0000BD90 File Offset: 0x00009F90
		public sealed override int GetHashCode()
		{
			return HashTool.AddHashCode(base.GetType().GetHashCode(), this.ComputeHashCode());
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0000BDB8 File Offset: 0x00009FB8
		protected virtual int ComputeHashCode()
		{
			return HashTool.ComputeHashCode(this);
		}
	}
}
