using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000048 RID: 72
	public static class Logger
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00003A9C File Offset: 0x00001C9C
		public static string ActiveLoggerFactoryName
		{
			get
			{
				return LoggerFactory.Instance.GetType().FullName;
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00003AC0 File Offset: 0x00001CC0
		public static ILogger GetIgnoreAllLogger()
		{
			return LoggerFactory.Instance.GetLogger("dummy");
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00003AE4 File Offset: 0x00001CE4
		public static ILogger GetLogger(Type type)
		{
			bool flag = type == null;
			if (flag)
			{
				throw new ArgumentNullException("type");
			}
			return Logger.GetLogger(type.FullName);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00003B18 File Offset: 0x00001D18
		public static ILogger GetLogger(string name)
		{
			return LoggerFactory.Instance.GetLogger(name);
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00003B38 File Offset: 0x00001D38
		public static string CurrentContext
		{
			get
			{
				bool flag = Logger.logger == null;
				if (flag)
				{
					object obj = Logger.mutex;
					lock (obj)
					{
						bool flag3 = Logger.logger == null;
						if (flag3)
						{
							Logger.logger = Logger.GetLogger(typeof(Logger));
						}
					}
				}
				return Logger.logger.Context;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00003BC0 File Offset: 0x00001DC0
		public static ILoggerMonitor Monitor
		{
			get
			{
				return LoggerFactory.Instance.Monitor;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00003BDC File Offset: 0x00001DDC
		public static bool InitializeLoggerFactory(string factoryName)
		{
			return LoggerFactory.InitializeLoggerFactory(factoryName);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00003BF4 File Offset: 0x00001DF4
		public static void SetLogFile(string absoluteLogFileName, bool append, string messagePattern)
		{
			LoggerFactory.Instance.SetLogFile(absoluteLogFileName, append, messagePattern);
		}

		// Token: 0x040000E1 RID: 225
		private static readonly object mutex = new object();

		// Token: 0x040000E2 RID: 226
		private static volatile ILogger logger;
	}
}
