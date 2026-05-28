using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Application
{
	// Token: 0x02000067 RID: 103
	public class ValueArgument : Argument
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x00006D52 File Offset: 0x00004F52
		public ValueArgument() : this(ArgumentType.None)
		{
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00006D5D File Offset: 0x00004F5D
		public ValueArgument(ArgumentType argumentType) : base(argumentType | ArgumentType.ContainsValue, null, null)
		{
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00006D6C File Offset: 0x00004F6C
		public new string Value
		{
			get
			{
				return base.Value as string;
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00006D8C File Offset: 0x00004F8C
		public override string ToString()
		{
			return this.Value;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00006DA4 File Offset: 0x00004FA4
		protected override bool OnLoad(string commandLineArg)
		{
			base.Value = commandLineArg;
			return true;
		}
	}
}
