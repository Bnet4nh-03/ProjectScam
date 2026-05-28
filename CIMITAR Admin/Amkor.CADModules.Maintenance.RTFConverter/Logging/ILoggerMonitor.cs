using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000047 RID: 71
	public interface ILoggerMonitor
	{
		// Token: 0x06000187 RID: 391
		void Register(ILoggerListener loggerListener, string context);

		// Token: 0x06000188 RID: 392
		void Unregister(ILoggerListener loggerListener, string context);
	}
}
