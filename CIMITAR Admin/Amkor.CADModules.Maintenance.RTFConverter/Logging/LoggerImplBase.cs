using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000051 RID: 81
	public abstract class LoggerImplBase : LoggerBase, ILogger
	{
		// Token: 0x060001B7 RID: 439 RVA: 0x0000453C File Offset: 0x0000273C
		protected LoggerImplBase()
		{
			this.level = LoggerLevel.Warn;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000454D File Offset: 0x0000274D
		protected LoggerImplBase(LoggerLevel level)
		{
			this.level = level;
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00004560 File Offset: 0x00002760
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00004578 File Offset: 0x00002778
		public LoggerLevel Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00004584 File Offset: 0x00002784
		public bool IsDebugEnabled
		{
			get
			{
				return LoggerLevel.Debug.CompareTo(this.level) <= 0;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060001BC RID: 444 RVA: 0x000045B8 File Offset: 0x000027B8
		public bool IsInfoEnabled
		{
			get
			{
				return LoggerLevel.Info.CompareTo(this.level) <= 0;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060001BD RID: 445 RVA: 0x000045EC File Offset: 0x000027EC
		public bool IsWarnEnabled
		{
			get
			{
				return LoggerLevel.Warn.CompareTo(this.level) <= 0;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00004620 File Offset: 0x00002820
		public bool IsErrorEnabled
		{
			get
			{
				return LoggerLevel.Error.CompareTo(this.level) <= 0;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00004654 File Offset: 0x00002854
		public bool IsFatalEnabled
		{
			get
			{
				return LoggerLevel.Fatal.CompareTo(this.level) <= 0;
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00004688 File Offset: 0x00002888
		public bool IsEnabledFor(LoggerLevel loggerLevel)
		{
			return loggerLevel.CompareTo(this.level) <= 0;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000046B8 File Offset: 0x000028B8
		public virtual void Debug(object message)
		{
			this.Log(LoggerLevel.Debug, message);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x000046C4 File Offset: 0x000028C4
		public virtual void Debug(object message, Exception exception)
		{
			this.Log(LoggerLevel.Debug, message, exception);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000046D1 File Offset: 0x000028D1
		public virtual void DebugFormat(string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Debug, format, args);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000046DE File Offset: 0x000028DE
		public virtual void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Debug, provider, format, args);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x000046EC File Offset: 0x000028EC
		public virtual void Info(object message)
		{
			this.Log(LoggerLevel.Info, message);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000046F8 File Offset: 0x000028F8
		public virtual void Info(object message, Exception exception)
		{
			this.Log(LoggerLevel.Info, message, exception);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00004705 File Offset: 0x00002905
		public virtual void InfoFormat(string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Info, format, args);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00004712 File Offset: 0x00002912
		public virtual void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Info, provider, format, args);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00004720 File Offset: 0x00002920
		public virtual void Warn(object message)
		{
			this.Log(LoggerLevel.Warn, message);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000472C File Offset: 0x0000292C
		public virtual void Warn(object message, Exception exception)
		{
			this.Log(LoggerLevel.Warn, message, exception);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00004739 File Offset: 0x00002939
		public virtual void WarnFormat(string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Warn, format, args);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00004746 File Offset: 0x00002946
		public virtual void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Warn, provider, format, args);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00004754 File Offset: 0x00002954
		public virtual void Error(object message)
		{
			this.Log(LoggerLevel.Error, message);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00004760 File Offset: 0x00002960
		public virtual void Error(object message, Exception exception)
		{
			this.Log(LoggerLevel.Error, message, exception);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000476D File Offset: 0x0000296D
		public virtual void ErrorFormat(string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Error, format, args);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000477A File Offset: 0x0000297A
		public virtual void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Error, provider, format, args);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00004788 File Offset: 0x00002988
		public virtual void Fatal(object message)
		{
			this.Log(LoggerLevel.Fatal, message);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00004794 File Offset: 0x00002994
		public virtual void Fatal(object message, Exception exception)
		{
			this.Log(LoggerLevel.Fatal, message, exception);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000047A1 File Offset: 0x000029A1
		public virtual void FatalFormat(string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Fatal, format, args);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x000047AE File Offset: 0x000029AE
		public virtual void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(LoggerLevel.Fatal, provider, format, args);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000047BC File Offset: 0x000029BC
		public virtual void Log(LoggerLevel loggerLevel, object message)
		{
			this.Log(loggerLevel, message, null);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x000047CC File Offset: 0x000029CC
		public virtual void Log(LoggerLevel loggerLevel, object message, Exception exception)
		{
			bool flag = this.IsEnabledFor(loggerLevel);
			if (flag)
			{
				this.Output(loggerLevel, message, exception);
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x000047F1 File Offset: 0x000029F1
		public virtual void LogFormat(LoggerLevel loggerLevel, string format, params object[] args)
		{
			this.Log(loggerLevel, string.Format(format, args));
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00004803 File Offset: 0x00002A03
		public virtual void LogFormat(LoggerLevel loggerLevel, IFormatProvider provider, string format, params object[] args)
		{
			this.Log(loggerLevel, string.Format(provider, format, args));
		}

		// Token: 0x060001D9 RID: 473
		protected abstract void Output(LoggerLevel level, object message, Exception exception);

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00004818 File Offset: 0x00002A18
		protected sealed override ILogger Logger
		{
			get
			{
				return this;
			}
		}

		// Token: 0x040000F2 RID: 242
		private LoggerLevel level;
	}
}
