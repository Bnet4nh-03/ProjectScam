using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000044 RID: 68
	public interface ILogger
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600015C RID: 348
		// (set) Token: 0x0600015D RID: 349
		LoggerLevel Level { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600015E RID: 350
		bool IsDebugEnabled { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600015F RID: 351
		bool IsInfoEnabled { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000160 RID: 352
		bool IsWarnEnabled { get; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000161 RID: 353
		bool IsErrorEnabled { get; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000162 RID: 354
		bool IsFatalEnabled { get; }

		// Token: 0x06000163 RID: 355
		bool IsEnabledFor(LoggerLevel level);

		// Token: 0x06000164 RID: 356
		bool IsSupportedException(Exception exception);

		// Token: 0x06000165 RID: 357
		void Debug(object message);

		// Token: 0x06000166 RID: 358
		void Debug(object message, Exception exception);

		// Token: 0x06000167 RID: 359
		void DebugFormat(string format, params object[] args);

		// Token: 0x06000168 RID: 360
		void DebugFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x06000169 RID: 361
		void Info(object message);

		// Token: 0x0600016A RID: 362
		void Info(object message, Exception exception);

		// Token: 0x0600016B RID: 363
		void InfoFormat(string format, params object[] args);

		// Token: 0x0600016C RID: 364
		void InfoFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x0600016D RID: 365
		void Warn(object message);

		// Token: 0x0600016E RID: 366
		void Warn(object message, Exception exception);

		// Token: 0x0600016F RID: 367
		void WarnFormat(string format, params object[] args);

		// Token: 0x06000170 RID: 368
		void WarnFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x06000171 RID: 369
		void Error(object message);

		// Token: 0x06000172 RID: 370
		void Error(object message, Exception exception);

		// Token: 0x06000173 RID: 371
		void ErrorFormat(string format, params object[] args);

		// Token: 0x06000174 RID: 372
		void ErrorFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x06000175 RID: 373
		void Fatal(object message);

		// Token: 0x06000176 RID: 374
		void Fatal(object message, Exception exception);

		// Token: 0x06000177 RID: 375
		void FatalFormat(string format, params object[] args);

		// Token: 0x06000178 RID: 376
		void FatalFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x06000179 RID: 377
		void Log(LoggerLevel level, object message);

		// Token: 0x0600017A RID: 378
		void Log(LoggerLevel level, object message, Exception exception);

		// Token: 0x0600017B RID: 379
		void LogFormat(LoggerLevel level, string format, params object[] args);

		// Token: 0x0600017C RID: 380
		void LogFormat(LoggerLevel level, IFormatProvider provider, string format, params object[] args);

		// Token: 0x0600017D RID: 381
		IDisposable PushContext(string context);

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600017E RID: 382
		int ContextDepth { get; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600017F RID: 383
		string Context { get; }

		// Token: 0x06000180 RID: 384
		void PopContext();
	}
}
