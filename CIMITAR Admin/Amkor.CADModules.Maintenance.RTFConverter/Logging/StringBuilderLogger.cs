using System;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x0200005A RID: 90
	public sealed class StringBuilderLogger : LoggerImplBase
	{
		// Token: 0x06000256 RID: 598 RVA: 0x00005A87 File Offset: 0x00003C87
		public StringBuilderLogger()
		{
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00005A9C File Offset: 0x00003C9C
		public StringBuilderLogger(LoggerLevel level) : base(level)
		{
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00005AB4 File Offset: 0x00003CB4
		public string Buffer
		{
			get
			{
				return this.buffer.ToString();
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00005AD1 File Offset: 0x00003CD1
		public void Clear()
		{
			this.buffer.Remove(0, this.buffer.Length);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00005AEC File Offset: 0x00003CEC
		protected override void Output(LoggerLevel level, object message, Exception exception)
		{
			this.buffer.Append(level.ToString());
			this.buffer.Append(": ");
			this.buffer.AppendLine((message == null) ? "null" : message.ToString());
			this.Output(exception);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00005B48 File Offset: 0x00003D48
		private void Output(Exception exception)
		{
			bool flag = exception != null;
			if (flag)
			{
				this.buffer.Append(exception.GetType().FullName);
				this.buffer.Append(": ");
				this.buffer.AppendLine(exception.Message);
				this.buffer.AppendLine(exception.StackTrace);
				bool flag2 = exception.InnerException != null;
				if (flag2)
				{
					this.buffer.AppendLine("Caused by:");
					this.Output(exception.InnerException);
				}
			}
		}

		// Token: 0x04000103 RID: 259
		private readonly StringBuilder buffer = new StringBuilder();
	}
}
