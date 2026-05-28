using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x0200004F RID: 79
	internal sealed class LoggerFactoryNone : LoggerFactory
	{
		// Token: 0x060001B1 RID: 433 RVA: 0x0000440C File Offset: 0x0000260C
		public override ILogger GetLogger(string name)
		{
			bool flag = LoggerFactoryNone.logger == null;
			if (flag)
			{
				object obj = LoggerFactoryNone.mutex;
				lock (obj)
				{
					bool flag3 = LoggerFactoryNone.logger == null;
					if (flag3)
					{
						LoggerFactoryNone.logger = new LoggerNone();
					}
				}
			}
			return LoggerFactoryNone.logger;
		}

		// Token: 0x040000EF RID: 239
		private static readonly object mutex = new object();

		// Token: 0x040000F0 RID: 240
		private static volatile LoggerNone logger;
	}
}
