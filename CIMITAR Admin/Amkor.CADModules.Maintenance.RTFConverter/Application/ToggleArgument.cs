using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Application
{
	// Token: 0x02000066 RID: 102
	public class ToggleArgument : Argument
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x00006BFF File Offset: 0x00004DFF
		public ToggleArgument(string name, bool defaultValue) : this(ArgumentType.None, name, defaultValue)
		{
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00006C0C File Offset: 0x00004E0C
		public ToggleArgument(ArgumentType argumentType, string name, bool defaultValue) : base(argumentType | ArgumentType.HasName | ArgumentType.ContainsValue, name, defaultValue)
		{
			bool flag = name == null;
			if (flag)
			{
				throw new ArgumentNullException("name");
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x00006C44 File Offset: 0x00004E44
		public new bool Value
		{
			get
			{
				return (bool)base.Value;
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00006C64 File Offset: 0x00004E64
		public override string ToString()
		{
			return base.Name + "=" + (this.Value ? "on" : "off");
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00006C9C File Offset: 0x00004E9C
		protected override bool OnLoad(string commandLineArg)
		{
			bool flag = !commandLineArg.StartsWith(base.Name, StringComparison.InvariantCultureIgnoreCase);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = commandLineArg.Equals(base.Name, StringComparison.InvariantCultureIgnoreCase);
				if (flag2)
				{
					base.Value = true;
					result = true;
				}
				else
				{
					string value = base.Name + "+";
					bool flag3 = commandLineArg.Equals(value, StringComparison.InvariantCultureIgnoreCase);
					if (flag3)
					{
						base.Value = true;
						result = true;
					}
					else
					{
						string value2 = base.Name + "-";
						bool flag4 = commandLineArg.Equals(value2, StringComparison.InvariantCultureIgnoreCase);
						if (flag4)
						{
							base.Value = false;
							result = true;
						}
						else
						{
							result = false;
						}
					}
				}
			}
			return result;
		}
	}
}
