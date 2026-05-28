using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x0200004B RID: 75
	public sealed class LoggerEvent : ILoggerEvent
	{
		// Token: 0x0600019B RID: 411 RVA: 0x00003CD4 File Offset: 0x00001ED4
		public LoggerEvent(LoggerLevel level, string source, string context, string message, Exception caughtException)
		{
			this.level = ((level < LoggerLevel.Fatal) ? LoggerLevel.Fatal : ((level > LoggerLevel.Debug) ? LoggerLevel.Fatal : level));
			this.source = ArgumentCheck.NonemptyTrimmedString(source, "source");
			this.context = (context ?? string.Empty);
			this.message = (message ?? string.Empty);
			this.caughtException = caughtException;
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00003D3C File Offset: 0x00001F3C
		public LoggerLevel Level
		{
			get
			{
				return this.level;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00003D54 File Offset: 0x00001F54
		public string Source
		{
			get
			{
				return this.source;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00003D6C File Offset: 0x00001F6C
		public string Context
		{
			get
			{
				return this.context;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00003D84 File Offset: 0x00001F84
		public string Message
		{
			get
			{
				return this.message;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00003D9C File Offset: 0x00001F9C
		public Exception CaughtException
		{
			get
			{
				return this.caughtException;
			}
		}

		// Token: 0x040000E4 RID: 228
		private readonly LoggerLevel level;

		// Token: 0x040000E5 RID: 229
		private readonly string source;

		// Token: 0x040000E6 RID: 230
		private readonly string context;

		// Token: 0x040000E7 RID: 231
		private readonly string message;

		// Token: 0x040000E8 RID: 232
		private readonly Exception caughtException;
	}
}
