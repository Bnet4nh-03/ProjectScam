using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000058 RID: 88
	internal sealed class LoggerNone : LoggerBase, ILogger
	{
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00005474 File Offset: 0x00003674
		// (set) Token: 0x0600020F RID: 527 RVA: 0x00003C93 File Offset: 0x00001E93
		public LoggerLevel Level
		{
			get
			{
				return LoggerLevel.Fatal;
			}
			set
			{
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00005488 File Offset: 0x00003688
		public bool IsDebugEnabled
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000549C File Offset: 0x0000369C
		public bool IsInfoEnabled
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000212 RID: 530 RVA: 0x000054B0 File Offset: 0x000036B0
		public bool IsWarnEnabled
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000213 RID: 531 RVA: 0x000054C4 File Offset: 0x000036C4
		public bool IsErrorEnabled
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000214 RID: 532 RVA: 0x000054D8 File Offset: 0x000036D8
		public bool IsFatalEnabled
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000054EC File Offset: 0x000036EC
		public bool IsEnabledFor(LoggerLevel level)
		{
			return false;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Debug(object message)
		{
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Debug(object message, Exception exception)
		{
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00003C93 File Offset: 0x00001E93
		public void DebugFormat(string format, params object[] args)
		{
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00003C93 File Offset: 0x00001E93
		public void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Info(object message)
		{
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Info(object message, Exception exception)
		{
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00003C93 File Offset: 0x00001E93
		public void InfoFormat(string format, params object[] args)
		{
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00003C93 File Offset: 0x00001E93
		public void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Warn(object message)
		{
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Warn(object message, Exception exception)
		{
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00003C93 File Offset: 0x00001E93
		public void WarnFormat(string format, params object[] args)
		{
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00003C93 File Offset: 0x00001E93
		public void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Error(object message)
		{
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Error(object message, Exception exception)
		{
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00003C93 File Offset: 0x00001E93
		public void ErrorFormat(string format, params object[] args)
		{
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00003C93 File Offset: 0x00001E93
		public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Fatal(object message)
		{
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Fatal(object message, Exception exception)
		{
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00003C93 File Offset: 0x00001E93
		public void FatalFormat(string format, params object[] args)
		{
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00003C93 File Offset: 0x00001E93
		public void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Log(LoggerLevel level, object message)
		{
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00003C93 File Offset: 0x00001E93
		public void Log(LoggerLevel level, object message, Exception exception)
		{
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00003C93 File Offset: 0x00001E93
		public void LogFormat(LoggerLevel level, string format, params object[] args)
		{
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00003C93 File Offset: 0x00001E93
		public void LogFormat(LoggerLevel level, IFormatProvider provider, string format, params object[] args)
		{
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00005500 File Offset: 0x00003700
		protected override ILogger Logger
		{
			get
			{
				return this;
			}
		}
	}
}
