using System;
using System.Threading;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000049 RID: 73
	public abstract class LoggerBase
	{
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00003C14 File Offset: 0x00001E14
		public virtual string Context
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00003C2C File Offset: 0x00001E2C
		public virtual bool IsSupportedException(Exception exception)
		{
			return !(exception is ThreadAbortException);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00003C4C File Offset: 0x00001E4C
		public virtual IDisposable PushContext(string context)
		{
			bool flag = context == null;
			if (flag)
			{
				throw new ArgumentNullException("context");
			}
			return new LoggerContextDisposable(this.Logger);
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00003C80 File Offset: 0x00001E80
		public virtual int ContextDepth
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00003C93 File Offset: 0x00001E93
		public virtual void PopContext()
		{
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000197 RID: 407
		protected abstract ILogger Logger { get; }
	}
}
