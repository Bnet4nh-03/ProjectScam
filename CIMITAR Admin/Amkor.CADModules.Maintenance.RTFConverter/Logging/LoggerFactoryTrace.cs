using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000050 RID: 80
	internal sealed class LoggerFactoryTrace : LoggerFactory
	{
		// Token: 0x060001B4 RID: 436 RVA: 0x0000449C File Offset: 0x0000269C
		public override ILogger GetLogger(string name)
		{
			ILogger logger = (ILogger)LoggerFactoryTrace.loggers[name];
			bool flag = logger == null;
			if (flag)
			{
				lock (this)
				{
					logger = (ILogger)LoggerFactoryTrace.loggers[name];
					bool flag3 = logger == null;
					if (flag3)
					{
						ILogger logger2 = new LoggerTrace(name);
						LoggerFactoryTrace.loggers.Add(name, logger2);
						logger = logger2;
					}
				}
			}
			return logger;
		}

		// Token: 0x040000F1 RID: 241
		private static readonly Hashtable loggers = new Hashtable();
	}
}
