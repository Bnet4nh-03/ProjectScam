using System;
using System.Security;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x0200004D RID: 77
	internal static class LoggerFactoryBuilder
	{
		// Token: 0x060001A9 RID: 425 RVA: 0x00003F5F File Offset: 0x0000215F
		internal static void SetDefaultLoggerFactory(string factoryName)
		{
			LoggerFactoryBuilder.defaultLoggerFactoryName = factoryName;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00003F68 File Offset: 0x00002168
		internal static LoggerFactory BuildFactoryInstance()
		{
			LoggerFactory result;
			try
			{
				string environmentVariable = Environment.GetEnvironmentVariable(LoggerFactoryBuilder.environmentVariableName);
				LoggerFactory loggerFactory = LoggerFactoryBuilder.CreateInstance(environmentVariable);
				bool flag = loggerFactory == null && LoggerFactoryBuilder.defaultLoggerFactoryName != null;
				if (flag)
				{
					loggerFactory = LoggerFactoryBuilder.CreateInstance(LoggerFactoryBuilder.defaultLoggerFactoryName);
				}
				int num = 0;
				while (loggerFactory == null && num < LoggerFactoryBuilder.loggerFactoryChoices.Length)
				{
					loggerFactory = LoggerFactoryBuilder.CreateInstance(LoggerFactoryBuilder.loggerFactoryChoices[num]);
					num++;
				}
				bool flag2 = loggerFactory == null;
				if (flag2)
				{
					throw new InvalidOperationException(Strings.LoggerFactoryConfigError);
				}
				result = loggerFactory;
			}
			catch (SecurityException innerException)
			{
				throw new InvalidOperationException(Strings.LoggerFactoryConfigError, innerException);
			}
			return result;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00004014 File Offset: 0x00002214
		private static LoggerFactory CreateInstance(string typeName)
		{
			LoggerFactory result = null;
			bool flag = !string.IsNullOrEmpty(typeName);
			if (flag)
			{
				try
				{
					Type type = Type.GetType(typeName, false);
					LoggerFactory loggerFactory = (LoggerFactory)Activator.CreateInstance(type);
					ILogger logger = loggerFactory.GetLogger(typeof(LoggerFactory).FullName);
					logger.Info("using LoggerFactory: " + typeName);
					result = loggerFactory;
				}
				catch
				{
				}
			}
			return result;
		}

		// Token: 0x040000EC RID: 236
		private static readonly string environmentVariableName = typeof(LoggerFactory).FullName;

		// Token: 0x040000ED RID: 237
		private static readonly string[] loggerFactoryChoices = new string[]
		{
			typeof(LoggerFactoryLog4net).FullName,
			typeof(LoggerFactoryTrace).FullName,
			typeof(LoggerFactoryNone).FullName
		};

		// Token: 0x040000EE RID: 238
		private static string defaultLoggerFactoryName;
	}
}
