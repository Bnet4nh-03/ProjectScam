using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000046 RID: 70
	public interface ILoggerListener
	{
		// Token: 0x06000186 RID: 390
		void Handle(ILoggerEvent loggerEvent);
	}
}
