using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Application
{
	// Token: 0x02000060 RID: 96
	public abstract class Argument : IArgument
	{
		// Token: 0x06000291 RID: 657 RVA: 0x00006872 File Offset: 0x00004A72
		protected Argument(ArgumentType argumentType, string name, object defaultValue)
		{
			this.name = name;
			this.argumentType = argumentType;
			this.defaultValue = defaultValue;
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00006894 File Offset: 0x00004A94
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000293 RID: 659 RVA: 0x000068AC File Offset: 0x00004AAC
		// (set) Token: 0x06000294 RID: 660 RVA: 0x000068DB File Offset: 0x00004ADB
		public object Value
		{
			get
			{
				bool flag = this.value == null;
				object result;
				if (flag)
				{
					result = this.defaultValue;
				}
				else
				{
					result = this.value;
				}
				return result;
			}
			set
			{
				this.value = value;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000295 RID: 661 RVA: 0x000068E8 File Offset: 0x00004AE8
		public object DefaultValue
		{
			get
			{
				return this.defaultValue;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000296 RID: 662 RVA: 0x00006900 File Offset: 0x00004B00
		public ArgumentType ArgumentType
		{
			get
			{
				return this.argumentType;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00006918 File Offset: 0x00004B18
		public bool IsMandatory
		{
			get
			{
				return (this.argumentType & ArgumentType.Mandatory) == ArgumentType.Mandatory;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00006938 File Offset: 0x00004B38
		public bool HasName
		{
			get
			{
				return (this.argumentType & ArgumentType.HasName) == ArgumentType.HasName;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00006958 File Offset: 0x00004B58
		public bool ContainsValue
		{
			get
			{
				return (this.argumentType & ArgumentType.ContainsValue) == ArgumentType.ContainsValue;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00006978 File Offset: 0x00004B78
		public virtual bool IsValid
		{
			get
			{
				bool flag = this.IsMandatory && !this.isLoaded;
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					bool flag2 = this.IsMandatory && this.ContainsValue && this.Value == null && this.DefaultValue == null;
					result = !flag2;
				}
				return result;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600029B RID: 667 RVA: 0x000069D8 File Offset: 0x00004BD8
		public bool IsLoaded
		{
			get
			{
				return this.isLoaded;
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x000069F0 File Offset: 0x00004BF0
		public void Load(string commandLineArg)
		{
			bool flag = commandLineArg.StartsWith("/") || commandLineArg.StartsWith("-");
			bool hasName = this.HasName;
			if (hasName)
			{
				bool flag2 = !flag;
				if (flag2)
				{
					return;
				}
				commandLineArg = commandLineArg.Substring(1);
				bool flag3 = string.IsNullOrEmpty(commandLineArg);
				if (flag3)
				{
					return;
				}
			}
			else
			{
				bool flag4 = flag;
				if (flag4)
				{
					return;
				}
			}
			this.isLoaded = this.OnLoad(commandLineArg);
		}

		// Token: 0x0600029D RID: 669
		protected abstract bool OnLoad(string commandLineArg);

		// Token: 0x04000106 RID: 262
		private readonly string name;

		// Token: 0x04000107 RID: 263
		private readonly ArgumentType argumentType;

		// Token: 0x04000108 RID: 264
		private readonly object defaultValue;

		// Token: 0x04000109 RID: 265
		private bool isLoaded;

		// Token: 0x0400010A RID: 266
		private object value;
	}
}
