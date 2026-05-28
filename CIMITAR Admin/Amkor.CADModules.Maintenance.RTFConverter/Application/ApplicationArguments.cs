using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Application
{
	// Token: 0x0200005E RID: 94
	public class ApplicationArguments
	{
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000285 RID: 645 RVA: 0x0000655C File Offset: 0x0000475C
		public ArgumentCollection Arguments
		{
			get
			{
				return this.arguments;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00006574 File Offset: 0x00004774
		public bool IsValid
		{
			get
			{
				return this.arguments.IsValid;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00006594 File Offset: 0x00004794
		public bool IsHelpMode
		{
			get
			{
				foreach (object obj in this.arguments)
				{
					IArgument argument = (IArgument)obj;
					bool flag = argument is HelpModeArgument;
					if (flag)
					{
						return (bool)argument.Value;
					}
				}
				return false;
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00006610 File Offset: 0x00004810
		public void Load()
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 1; i < commandLineArgs.Length; i++)
			{
				string commandLineArg = commandLineArgs[i];
				foreach (object obj in this.arguments)
				{
					IArgument argument = (IArgument)obj;
					bool isLoaded = argument.IsLoaded;
					if (!isLoaded)
					{
						argument.Load(commandLineArg);
						bool isLoaded2 = argument.IsLoaded;
						if (isLoaded2)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x04000105 RID: 261
		private readonly ArgumentCollection arguments = new ArgumentCollection();
	}
}
