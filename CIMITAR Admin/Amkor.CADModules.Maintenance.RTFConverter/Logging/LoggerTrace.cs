using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000059 RID: 89
	internal sealed class LoggerTrace : LoggerBase, ILogger
	{
		// Token: 0x06000230 RID: 560 RVA: 0x0000551C File Offset: 0x0000371C
		public LoggerTrace(string name)
		{
			this.name = ArgumentCheck.NonemptyTrimmedString(name, Strings.LoggerNameMayNotBeEmpty, "name");
			this.level = new TraceSwitch(name, "trace switch for " + name + " from the application config file");
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00005558 File Offset: 0x00003758
		// (set) Token: 0x06000232 RID: 562 RVA: 0x0000557C File Offset: 0x0000377C
		public LoggerLevel Level
		{
			get
			{
				return LoggerTrace.TraceLevelToLoggerLevel(this.level.Level);
			}
			set
			{
				TraceSwitch obj = this.level;
				lock (obj)
				{
					this.level.Level = LoggerTrace.LoggerLevelToTraceLevel(value);
				}
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000233 RID: 563 RVA: 0x000055D0 File Offset: 0x000037D0
		public bool IsDebugEnabled
		{
			get
			{
				return this.level.TraceVerbose;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000234 RID: 564 RVA: 0x000055F0 File Offset: 0x000037F0
		public bool IsInfoEnabled
		{
			get
			{
				return this.level.TraceInfo;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00005610 File Offset: 0x00003810
		public bool IsWarnEnabled
		{
			get
			{
				return this.level.TraceWarning;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000236 RID: 566 RVA: 0x00005630 File Offset: 0x00003830
		public bool IsErrorEnabled
		{
			get
			{
				return this.level.TraceError;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00005650 File Offset: 0x00003850
		public bool IsFatalEnabled
		{
			get
			{
				return this.level.Level > TraceLevel.Off;
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00005670 File Offset: 0x00003870
		public bool IsEnabledFor(LoggerLevel loggerLevel)
		{
			bool result = false;
			switch (loggerLevel)
			{
			case LoggerLevel.Fatal:
				result = this.IsFatalEnabled;
				break;
			case LoggerLevel.Error:
				result = this.IsErrorEnabled;
				break;
			case LoggerLevel.Warn:
				result = this.IsWarnEnabled;
				break;
			case LoggerLevel.Info:
				result = this.IsInfoEnabled;
				break;
			case LoggerLevel.Debug:
				result = this.IsDebugEnabled;
				break;
			}
			return result;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000056D0 File Offset: 0x000038D0
		public void Debug(object message)
		{
			this.Log(TraceLevel.Verbose, message, null);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000056DD File Offset: 0x000038DD
		public void Debug(object message, Exception exception)
		{
			this.Log(TraceLevel.Verbose, message, exception);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000056EA File Offset: 0x000038EA
		public void DebugFormat(string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Verbose, null, format, args);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000056F8 File Offset: 0x000038F8
		public void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Verbose, provider, format, args);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00005706 File Offset: 0x00003906
		public void Info(object message)
		{
			this.Log(TraceLevel.Info, message, null);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00005713 File Offset: 0x00003913
		public void Info(object message, Exception exception)
		{
			this.Log(TraceLevel.Info, message, exception);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00005720 File Offset: 0x00003920
		public void InfoFormat(string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Info, null, format, args);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000572E File Offset: 0x0000392E
		public void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Info, provider, format, args);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000573C File Offset: 0x0000393C
		public void Warn(object message)
		{
			this.Log(TraceLevel.Warning, message, null);
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00005749 File Offset: 0x00003949
		public void Warn(object message, Exception exception)
		{
			this.Log(TraceLevel.Warning, message, exception);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00005756 File Offset: 0x00003956
		public void WarnFormat(string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Warning, null, format, args);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00005764 File Offset: 0x00003964
		public void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Warning, provider, format, args);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00005772 File Offset: 0x00003972
		public void Error(object message)
		{
			this.Log(TraceLevel.Error, message, null);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000577F File Offset: 0x0000397F
		public void Error(object message, Exception exception)
		{
			this.Log(TraceLevel.Error, message, exception);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000578C File Offset: 0x0000398C
		public void ErrorFormat(string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Error, null, format, args);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000579A File Offset: 0x0000399A
		public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Error, provider, format, args);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x000057A8 File Offset: 0x000039A8
		public void Fatal(object message)
		{
			this.Log(TraceLevel.Off, message, null);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x000057B5 File Offset: 0x000039B5
		public void Fatal(object message, Exception exception)
		{
			this.Log(TraceLevel.Off, message, exception);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x000057C2 File Offset: 0x000039C2
		public void FatalFormat(string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Off, null, format, args);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x000057D0 File Offset: 0x000039D0
		public void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(TraceLevel.Off, provider, format, args);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x000057DE File Offset: 0x000039DE
		public void Log(LoggerLevel loggerLevel, object message)
		{
			this.Log(LoggerTrace.LoggerLevelToTraceLevel(loggerLevel), message, null);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x000057F0 File Offset: 0x000039F0
		public void Log(LoggerLevel loggerLevel, object message, Exception exception)
		{
			this.Log(LoggerTrace.LoggerLevelToTraceLevel(loggerLevel), message, exception);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00005802 File Offset: 0x00003A02
		public void LogFormat(LoggerLevel loggerLevel, string format, params object[] args)
		{
			this.LogFormat(LoggerTrace.LoggerLevelToTraceLevel(loggerLevel), null, format, args);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00005815 File Offset: 0x00003A15
		public void LogFormat(LoggerLevel loggerLevel, IFormatProvider provider, string format, params object[] args)
		{
			this.LogFormat(LoggerTrace.LoggerLevelToTraceLevel(loggerLevel), provider, format, args);
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000251 RID: 593 RVA: 0x0000582C File Offset: 0x00003A2C
		protected override ILogger Logger
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00005840 File Offset: 0x00003A40
		private void Log(TraceLevel logLevel, object message, Exception exception)
		{
			bool flag = !this.IsSupportedException(exception);
			if (!flag)
			{
				bool flag2 = this.level.Level >= logLevel;
				if (flag2)
				{
					StringBuilder stringBuilder = new StringBuilder(this.name);
					stringBuilder.Append(": ");
					TraceLevel traceLevel = logLevel;
					if (traceLevel != TraceLevel.Off)
					{
						if (traceLevel != TraceLevel.Verbose)
						{
							stringBuilder.Append(logLevel.ToString());
						}
						else
						{
							stringBuilder.Append("Debug");
						}
					}
					else
					{
						stringBuilder.Append("Fatal");
					}
					stringBuilder.Append(": ");
					bool flag3 = message != null;
					if (flag3)
					{
						stringBuilder.Append(message);
					}
					bool flag4 = exception != null;
					if (flag4)
					{
						stringBuilder.Append(": ");
						stringBuilder.Append(exception.ToString());
					}
					switch (logLevel)
					{
					case TraceLevel.Off:
					case TraceLevel.Error:
						Trace.TraceError(stringBuilder.ToString());
						goto IL_118;
					case TraceLevel.Warning:
						Trace.TraceWarning(stringBuilder.ToString());
						goto IL_118;
					}
					Trace.TraceInformation(stringBuilder.ToString());
					IL_118:;
				}
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00005968 File Offset: 0x00003B68
		private void LogFormat(TraceLevel logLevel, IFormatProvider provider, string format, params object[] args)
		{
			bool flag = this.level.Level >= logLevel;
			if (flag)
			{
				IFormatProvider provider2 = provider ?? CultureInfo.InvariantCulture;
				try
				{
					string message = string.Format(provider2, format, args);
					this.Log(logLevel, message, null);
				}
				catch (FormatException ex)
				{
					this.Log(LoggerLevel.Fatal, "invalid log-message-format: " + ex.Message, ex);
					this.Log(LoggerLevel.Fatal, "original log-message was:");
					this.Log(logLevel, format, null);
				}
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000059F8 File Offset: 0x00003BF8
		private static TraceLevel LoggerLevelToTraceLevel(LoggerLevel loggerLevel)
		{
			TraceLevel result = TraceLevel.Off;
			switch (loggerLevel)
			{
			case LoggerLevel.Fatal:
				result = TraceLevel.Off;
				break;
			case LoggerLevel.Error:
				result = TraceLevel.Error;
				break;
			case LoggerLevel.Warn:
				result = TraceLevel.Warning;
				break;
			case LoggerLevel.Info:
				result = TraceLevel.Info;
				break;
			case LoggerLevel.Debug:
				result = TraceLevel.Verbose;
				break;
			}
			return result;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00005A40 File Offset: 0x00003C40
		private static LoggerLevel TraceLevelToLoggerLevel(TraceLevel traceLevel)
		{
			LoggerLevel result = LoggerLevel.Fatal;
			switch (traceLevel)
			{
			case TraceLevel.Off:
				result = LoggerLevel.Fatal;
				break;
			case TraceLevel.Error:
				result = LoggerLevel.Error;
				break;
			case TraceLevel.Warning:
				result = LoggerLevel.Warn;
				break;
			case TraceLevel.Info:
				result = LoggerLevel.Info;
				break;
			case TraceLevel.Verbose:
				result = LoggerLevel.Debug;
				break;
			}
			return result;
		}

		// Token: 0x040000FC RID: 252
		private const TraceLevel logLevelDebug = TraceLevel.Verbose;

		// Token: 0x040000FD RID: 253
		private const TraceLevel logLevelInfo = TraceLevel.Info;

		// Token: 0x040000FE RID: 254
		private const TraceLevel logLevelWarn = TraceLevel.Warning;

		// Token: 0x040000FF RID: 255
		private const TraceLevel logLevelError = TraceLevel.Error;

		// Token: 0x04000100 RID: 256
		private const TraceLevel logLevelFatal = TraceLevel.Off;

		// Token: 0x04000101 RID: 257
		private readonly string name;

		// Token: 0x04000102 RID: 258
		private readonly TraceSwitch level;
	}
}
