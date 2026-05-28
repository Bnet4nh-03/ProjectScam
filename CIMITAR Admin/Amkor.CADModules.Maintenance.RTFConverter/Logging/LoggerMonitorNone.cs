using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000057 RID: 87
	internal sealed class LoggerMonitorNone : ILoggerMonitor
	{
		// Token: 0x0600020A RID: 522 RVA: 0x000053FC File Offset: 0x000035FC
		public void Register(ILoggerListener loggerListener, string context)
		{
			LoggerMonitorNone.logger.Warn(string.Concat(new object[]
			{
				"ignoring registration of ",
				loggerListener,
				" for context ",
				context
			}));
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000542D File Offset: 0x0000362D
		public void Unregister(ILoggerListener loggerListener, string context)
		{
			LoggerMonitorNone.logger.Warn(string.Concat(new object[]
			{
				"ignoring unregistration of ",
				loggerListener,
				" for context ",
				context
			}));
		}

		// Token: 0x040000FB RID: 251
		private static readonly ILogger logger = Logger.GetLogger(typeof(LoggerMonitorNone));
	}
}
