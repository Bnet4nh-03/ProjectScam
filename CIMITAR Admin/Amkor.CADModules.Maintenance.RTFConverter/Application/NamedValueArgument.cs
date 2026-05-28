using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Application
{
	// Token: 0x02000065 RID: 101
	public class NamedValueArgument : Argument
	{
		// Token: 0x060002AD RID: 685 RVA: 0x00006B40 File Offset: 0x00004D40
		public NamedValueArgument(string name) : this(ArgumentType.None, name, null)
		{
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00006B4D File Offset: 0x00004D4D
		public NamedValueArgument(string name, object defaultValue) : this(ArgumentType.None, name, defaultValue)
		{
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00006B5A File Offset: 0x00004D5A
		public NamedValueArgument(ArgumentType argumentType, string name, object defaultValue) : base(argumentType | ArgumentType.ContainsValue | ArgumentType.HasName, name, defaultValue)
		{
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00006B6C File Offset: 0x00004D6C
		public new string Value
		{
			get
			{
				return base.Value as string;
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00006B8C File Offset: 0x00004D8C
		public override string ToString()
		{
			return base.Name + "=" + this.Value;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00006BB4 File Offset: 0x00004DB4
		protected override bool OnLoad(string commandLineArg)
		{
			string text = base.Name + ":";
			bool flag = !commandLineArg.StartsWith(text, StringComparison.InvariantCultureIgnoreCase);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				base.Value = commandLineArg.Substring(text.Length);
				result = true;
			}
			return result;
		}
	}
}
