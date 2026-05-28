using System;
using log4net.Appender;
using log4net.Core;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000055 RID: 85
	internal sealed class LoggerMonitorAppender : AppenderSkeleton
	{
		// Token: 0x06000204 RID: 516 RVA: 0x00004FAC File Offset: 0x000031AC
		protected override void Append(LoggingEvent loggingEvent)
		{
			LoggerMonitorLog4net loggerMonitorLog4net = Logger.Monitor as LoggerMonitorLog4net;
			bool flag = loggerMonitorLog4net != null;
			if (flag)
			{
				LoggerLevel level = LoggerLevel.Fatal;
				int value = loggingEvent.Level.Value;
				bool flag2 = value <= Level.Debug.Value;
				if (flag2)
				{
					level = LoggerLevel.Debug;
				}
				else
				{
					bool flag3 = value <= Level.Info.Value;
					if (flag3)
					{
						level = LoggerLevel.Info;
					}
					else
					{
						bool flag4 = value <= Level.Warn.Value;
						if (flag4)
						{
							level = LoggerLevel.Warn;
						}
						else
						{
							bool flag5 = value <= Level.Error.Value;
							if (flag5)
							{
								level = LoggerLevel.Error;
							}
						}
					}
				}
				string message = string.Concat(loggingEvent.MessageObject);
				string loggerName = loggingEvent.LoggerName;
				string context = Logger.GetLogger(loggerName).Context;
				Exception exceptionObject = loggingEvent.ExceptionObject;
				LoggerEvent loggerEvent = new LoggerEvent(level, loggerName, context, message, exceptionObject);
				loggerMonitorLog4net.Handle(loggerEvent);
			}
		}
	}
}
