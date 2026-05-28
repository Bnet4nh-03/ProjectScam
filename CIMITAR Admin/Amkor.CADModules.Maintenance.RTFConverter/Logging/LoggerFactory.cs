using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x0200004C RID: 76
	internal abstract class LoggerFactory
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x00003DB4 File Offset: 0x00001FB4
		public static bool InitializeLoggerFactory(string factoryName)
		{
			bool flag = LoggerFactory.instance == null;
			if (flag)
			{
				object obj = LoggerFactory.mutex;
				lock (obj)
				{
					bool flag3 = LoggerFactory.instance == null;
					if (flag3)
					{
						LoggerFactoryBuilder.SetDefaultLoggerFactory(factoryName);
					}
				}
			}
			return string.Equals(LoggerFactory.Instance.GetType().FullName, factoryName);
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00003E34 File Offset: 0x00002034
		public static LoggerFactory Instance
		{
			get
			{
				bool flag = LoggerFactory.instance == null;
				if (flag)
				{
					object obj = LoggerFactory.mutex;
					lock (obj)
					{
						bool flag3 = LoggerFactory.instance == null;
						if (flag3)
						{
							LoggerFactory.instance = LoggerFactoryBuilder.BuildFactoryInstance();
						}
					}
				}
				return LoggerFactory.instance;
			}
		}

		// Token: 0x060001A3 RID: 419
		public abstract ILogger GetLogger(string name);

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00003EAC File Offset: 0x000020AC
		public ILoggerMonitor Monitor
		{
			get
			{
				bool flag = this.monitor == null;
				if (flag)
				{
					lock (this)
					{
						bool flag3 = this.monitor == null;
						if (flag3)
						{
							this.monitor = this.CreateMonitor();
						}
					}
				}
				return this.monitor;
			}
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00003F24 File Offset: 0x00002124
		protected virtual ILoggerMonitor CreateMonitor()
		{
			return new LoggerMonitorNone();
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00003F3B File Offset: 0x0000213B
		public virtual void SetLogFile(string absoluteLogFileName, bool append, string messagePattern)
		{
			throw new InvalidOperationException(Strings.LoggerLogFileNotSupportedByType(base.GetType().FullName));
		}

		// Token: 0x040000E9 RID: 233
		private static readonly object mutex = new object();

		// Token: 0x040000EA RID: 234
		private static volatile LoggerFactory instance;

		// Token: 0x040000EB RID: 235
		private volatile ILoggerMonitor monitor;
	}
}
