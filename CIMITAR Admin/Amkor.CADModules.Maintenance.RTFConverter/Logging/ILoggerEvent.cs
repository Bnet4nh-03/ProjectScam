using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000045 RID: 69
	public interface ILoggerEvent
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000181 RID: 385
		LoggerLevel Level { get; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000182 RID: 386
		string Source { get; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000183 RID: 387
		string Context { get; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000184 RID: 388
		string Message { get; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000185 RID: 389
		Exception CaughtException { get; }
	}
}
