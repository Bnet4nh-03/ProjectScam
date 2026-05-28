using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x0200004A RID: 74
	internal sealed class LoggerContextDisposable : IDisposable
	{
		// Token: 0x06000199 RID: 409 RVA: 0x00003C96 File Offset: 0x00001E96
		public LoggerContextDisposable(ILogger logger)
		{
			this.logger = logger;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00003CA8 File Offset: 0x00001EA8
		void IDisposable.Dispose()
		{
			bool flag = this.logger != null;
			if (flag)
			{
				this.logger.PopContext();
			}
		}

		// Token: 0x040000E3 RID: 227
		private readonly ILogger logger;
	}
}
