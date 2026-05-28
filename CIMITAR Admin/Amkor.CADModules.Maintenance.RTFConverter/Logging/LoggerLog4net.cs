using System;
using System.Xml;
using log4net;
using log4net.Repository;
using log4net.Util;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000054 RID: 84
	internal sealed class LoggerLog4net : LoggerBase, ILogger
	{
		// Token: 0x060001DE RID: 478 RVA: 0x00004891 File Offset: 0x00002A91
		public LoggerLog4net(string name)
		{
			this.logger = LogManager.GetLogger(name);
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060001DF RID: 479 RVA: 0x000048A8 File Offset: 0x00002AA8
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00004900 File Offset: 0x00002B00
		public LoggerLevel Level
		{
			get
			{
				LoggerLevel result = LoggerLevel.Fatal;
				bool isDebugEnabled = this.IsDebugEnabled;
				if (isDebugEnabled)
				{
					result = LoggerLevel.Debug;
				}
				else
				{
					bool isInfoEnabled = this.IsInfoEnabled;
					if (isInfoEnabled)
					{
						result = LoggerLevel.Info;
					}
					else
					{
						bool isWarnEnabled = this.IsWarnEnabled;
						if (isWarnEnabled)
						{
							result = LoggerLevel.Warn;
						}
						else
						{
							bool isErrorEnabled = this.IsErrorEnabled;
							if (isErrorEnabled)
							{
								result = LoggerLevel.Error;
							}
						}
					}
				}
				return result;
			}
			set
			{
				IXmlRepositoryConfigurator xmlRepositoryConfigurator = this.logger.Logger.Repository as IXmlRepositoryConfigurator;
				bool flag = xmlRepositoryConfigurator != null;
				if (flag)
				{
					try
					{
						XmlDocument xmlDocument = new XmlDocument();
						XmlElement xmlElement = xmlDocument.CreateElement("log4net");
						XmlElement xmlElement2 = xmlDocument.CreateElement("logger");
						xmlElement2.SetAttribute("name", this.logger.Logger.Name);
						XmlElement xmlElement3 = xmlDocument.CreateElement("level");
						xmlElement3.SetAttribute("value", value.ToString());
						xmlElement2.AppendChild(xmlElement3);
						xmlElement.AppendChild(xmlElement2);
						xmlDocument.AppendChild(xmlElement);
						xmlRepositoryConfigurator.Configure(xmlElement);
					}
					catch (XmlException ex)
					{
						this.logger.Warn("cannot set new logging-level due to an XmlException", ex);
					}
				}
				else
				{
					this.logger.Warn("cannot set new logging-level as the repository is not configurable");
				}
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x000049FC File Offset: 0x00002BFC
		public bool IsDebugEnabled
		{
			get
			{
				return this.logger.IsDebugEnabled;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00004A1C File Offset: 0x00002C1C
		public bool IsInfoEnabled
		{
			get
			{
				return this.logger.IsInfoEnabled;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00004A3C File Offset: 0x00002C3C
		public bool IsWarnEnabled
		{
			get
			{
				return this.logger.IsWarnEnabled;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x00004A5C File Offset: 0x00002C5C
		public bool IsErrorEnabled
		{
			get
			{
				return this.logger.IsErrorEnabled;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00004A7C File Offset: 0x00002C7C
		public bool IsFatalEnabled
		{
			get
			{
				return this.logger.IsFatalEnabled;
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00004A9C File Offset: 0x00002C9C
		public bool IsEnabledFor(LoggerLevel level)
		{
			bool result = false;
			switch (level)
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

		// Token: 0x060001E7 RID: 487 RVA: 0x00004AFC File Offset: 0x00002CFC
		public void Debug(object message)
		{
			this.logger.Debug(message);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00004B0C File Offset: 0x00002D0C
		public void Debug(object message, Exception exception)
		{
			bool flag = this.IsSupportedException(exception);
			if (flag)
			{
				this.logger.Debug(message, exception);
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00004B35 File Offset: 0x00002D35
		public void DebugFormat(string format, params object[] args)
		{
			this.logger.DebugFormat(format, args);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00004B46 File Offset: 0x00002D46
		public void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.logger.DebugFormat(provider, format, args);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00004B58 File Offset: 0x00002D58
		public void Info(object message)
		{
			this.logger.Info(message);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00004B68 File Offset: 0x00002D68
		public void Info(object message, Exception exception)
		{
			bool flag = this.IsSupportedException(exception);
			if (flag)
			{
				this.logger.Info(message, exception);
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00004B91 File Offset: 0x00002D91
		public void InfoFormat(string format, params object[] args)
		{
			this.logger.InfoFormat(format, args);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00004BA2 File Offset: 0x00002DA2
		public void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.logger.InfoFormat(provider, format, args);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00004BB4 File Offset: 0x00002DB4
		public void Warn(object message)
		{
			this.logger.Warn(message);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00004BC4 File Offset: 0x00002DC4
		public void Warn(object message, Exception exception)
		{
			bool flag = this.IsSupportedException(exception);
			if (flag)
			{
				this.logger.Warn(message, exception);
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00004BED File Offset: 0x00002DED
		public void WarnFormat(string format, params object[] args)
		{
			this.logger.WarnFormat(format, args);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00004BFE File Offset: 0x00002DFE
		public void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.logger.WarnFormat(provider, format, args);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00004C10 File Offset: 0x00002E10
		public void Error(object message)
		{
			this.logger.Error(message);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00004C20 File Offset: 0x00002E20
		public void Error(object message, Exception exception)
		{
			bool flag = this.IsSupportedException(exception);
			if (flag)
			{
				this.logger.Error(message, exception);
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00004C49 File Offset: 0x00002E49
		public void ErrorFormat(string format, params object[] args)
		{
			this.logger.ErrorFormat(format, args);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00004C5A File Offset: 0x00002E5A
		public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.logger.ErrorFormat(provider, format, args);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00004C6C File Offset: 0x00002E6C
		public void Fatal(object message)
		{
			this.logger.Fatal(message);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00004C7C File Offset: 0x00002E7C
		public void Fatal(object message, Exception exception)
		{
			bool flag = this.IsSupportedException(exception);
			if (flag)
			{
				this.logger.Fatal(message, exception);
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00004CA5 File Offset: 0x00002EA5
		public void FatalFormat(string format, params object[] args)
		{
			this.logger.FatalFormat(format, args);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00004CB6 File Offset: 0x00002EB6
		public void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.logger.FatalFormat(provider, format, args);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00004CC8 File Offset: 0x00002EC8
		public void Log(LoggerLevel level, object message)
		{
			switch (level)
			{
			case LoggerLevel.Fatal:
				this.logger.Fatal(message);
				break;
			case LoggerLevel.Error:
				this.logger.Error(message);
				break;
			case LoggerLevel.Warn:
				this.logger.Warn(message);
				break;
			case LoggerLevel.Info:
				this.logger.Info(message);
				break;
			case LoggerLevel.Debug:
				this.logger.Debug(message);
				break;
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00004D40 File Offset: 0x00002F40
		public void Log(LoggerLevel level, object message, Exception exception)
		{
			bool flag = !this.IsSupportedException(exception);
			if (!flag)
			{
				switch (level)
				{
				case LoggerLevel.Fatal:
					this.logger.Fatal(message, exception);
					break;
				case LoggerLevel.Error:
					this.logger.Error(message, exception);
					break;
				case LoggerLevel.Warn:
					this.logger.Warn(message, exception);
					break;
				case LoggerLevel.Info:
					this.logger.Info(message, exception);
					break;
				case LoggerLevel.Debug:
					this.logger.Debug(message, exception);
					break;
				}
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00004DD0 File Offset: 0x00002FD0
		public void LogFormat(LoggerLevel level, string format, params object[] args)
		{
			switch (level)
			{
			case LoggerLevel.Fatal:
				this.logger.FatalFormat(format, args);
				break;
			case LoggerLevel.Error:
				this.logger.ErrorFormat(format, args);
				break;
			case LoggerLevel.Warn:
				this.logger.WarnFormat(format, args);
				break;
			case LoggerLevel.Info:
				this.logger.InfoFormat(format, args);
				break;
			case LoggerLevel.Debug:
				this.logger.DebugFormat(format, args);
				break;
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00004E4C File Offset: 0x0000304C
		public void LogFormat(LoggerLevel level, IFormatProvider provider, string format, params object[] args)
		{
			switch (level)
			{
			case LoggerLevel.Fatal:
				this.logger.FatalFormat(provider, format, args);
				break;
			case LoggerLevel.Error:
				this.logger.ErrorFormat(provider, format, args);
				break;
			case LoggerLevel.Warn:
				this.logger.WarnFormat(provider, format, args);
				break;
			case LoggerLevel.Info:
				this.logger.InfoFormat(provider, format, args);
				break;
			case LoggerLevel.Debug:
				this.logger.DebugFormat(provider, format, args);
				break;
			}
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00004ED4 File Offset: 0x000030D4
		public override IDisposable PushContext(string context)
		{
			IDisposable result = base.PushContext(context);
			ThreadContext.Stacks["NDC"].Push(context);
			return result;
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000200 RID: 512 RVA: 0x00004F08 File Offset: 0x00003108
		public override int ContextDepth
		{
			get
			{
				return ThreadContext.Stacks["NDC"].Count;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00004F30 File Offset: 0x00003130
		public override string Context
		{
			get
			{
				ThreadContextStack threadContextStack = ThreadContext.Stacks["NDC"];
				string text = (threadContextStack != null) ? threadContextStack.ToString() : null;
				text = ((text != null) ? text.Trim() : null);
				return text ?? "(null)";
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00004F78 File Offset: 0x00003178
		public override void PopContext()
		{
			base.PopContext();
			ThreadContext.Stacks["NDC"].Pop();
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00004F98 File Offset: 0x00003198
		protected override ILogger Logger
		{
			get
			{
				return this;
			}
		}

		// Token: 0x040000F9 RID: 249
		private readonly ILog logger;
	}
}
