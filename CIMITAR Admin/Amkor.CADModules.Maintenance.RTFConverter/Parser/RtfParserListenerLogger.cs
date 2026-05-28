using System;
using System.Globalization;
using System.Text;
using Amkor.CADModules.Maintenance.RTFConverter.Logging;

namespace Amkor.CADModules.Maintenance.RTFConverter.Parser
{
	// Token: 0x0200006C RID: 108
	public class RtfParserListenerLogger : RtfParserListenerBase
	{
		// Token: 0x06000301 RID: 769 RVA: 0x000087C9 File Offset: 0x000069C9
		public RtfParserListenerLogger() : this(new RtfParserLoggerSettings(), RtfParserListenerLogger.systemLogger)
		{
		}

		// Token: 0x06000302 RID: 770 RVA: 0x000087DD File Offset: 0x000069DD
		public RtfParserListenerLogger(RtfParserLoggerSettings settings) : this(settings, RtfParserListenerLogger.systemLogger)
		{
		}

		// Token: 0x06000303 RID: 771 RVA: 0x000087ED File Offset: 0x000069ED
		public RtfParserListenerLogger(ILogger logger) : this(new RtfParserLoggerSettings(), logger)
		{
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00008800 File Offset: 0x00006A00
		public RtfParserListenerLogger(RtfParserLoggerSettings settings, ILogger logger)
		{
			bool flag = settings == null;
			if (flag)
			{
				throw new ArgumentNullException("settings");
			}
			bool flag2 = logger == null;
			if (flag2)
			{
				throw new ArgumentNullException("logger");
			}
			this.settings = settings;
			this.logger = logger;
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0000884C File Offset: 0x00006A4C
		public RtfParserLoggerSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000306 RID: 774 RVA: 0x00008864 File Offset: 0x00006A64
		public ILogger Logger
		{
			get
			{
				return this.logger;
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000887C File Offset: 0x00006A7C
		protected override void DoParseBegin()
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.ParseBeginText);
			if (flag)
			{
				this.Log(new string[]
				{
					this.settings.ParseBeginText
				});
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x000088DC File Offset: 0x00006ADC
		protected override void DoGroupBegin()
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.ParseGroupBeginText);
			if (flag)
			{
				this.Log(new string[]
				{
					this.settings.ParseGroupBeginText
				});
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000893C File Offset: 0x00006B3C
		protected override void DoTagFound(IRtfTag tag)
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.ParseTagText);
			if (flag)
			{
				this.Log(new string[]
				{
					string.Format(CultureInfo.InvariantCulture, this.settings.ParseTagText, new object[]
					{
						tag
					})
				});
			}
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000089B0 File Offset: 0x00006BB0
		protected override void DoTextFound(IRtfText text)
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.ParseTextText);
			if (flag)
			{
				string text2 = text.Text;
				bool flag2 = text2.Length > this.settings.TextMaxLength && !string.IsNullOrEmpty(this.settings.TextOverflowText);
				if (flag2)
				{
					text2 = text2.Substring(0, text2.Length - this.settings.TextOverflowText.Length) + this.settings.TextOverflowText;
				}
				this.Log(new string[]
				{
					string.Format(CultureInfo.InvariantCulture, this.settings.ParseTextText, new object[]
					{
						text2
					})
				});
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00008A8C File Offset: 0x00006C8C
		protected override void DoGroupEnd()
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.ParseGroupEndText);
			if (flag)
			{
				this.Log(new string[]
				{
					this.settings.ParseGroupEndText
				});
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00008AEC File Offset: 0x00006CEC
		protected override void DoParseSuccess()
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.ParseSuccessText);
			if (flag)
			{
				this.Log(new string[]
				{
					this.settings.ParseSuccessText
				});
			}
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00008B4C File Offset: 0x00006D4C
		protected override void DoParseFail(RtfException reason)
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled;
			if (flag)
			{
				bool flag2 = reason != null;
				if (flag2)
				{
					bool flag3 = !string.IsNullOrEmpty(this.settings.ParseFailKnownReasonText);
					if (flag3)
					{
						this.Log(new string[]
						{
							string.Format(CultureInfo.InvariantCulture, this.settings.ParseFailKnownReasonText, new object[]
							{
								reason.Message
							})
						});
					}
				}
				else
				{
					bool flag4 = !string.IsNullOrEmpty(this.settings.ParseFailUnknownReasonText);
					if (flag4)
					{
						this.Log(new string[]
						{
							this.settings.ParseFailUnknownReasonText
						});
					}
				}
			}
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00008C10 File Offset: 0x00006E10
		protected override void DoParseEnd()
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.ParseEndText);
			if (flag)
			{
				this.Log(new string[]
				{
					this.settings.ParseEndText
				});
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00008C70 File Offset: 0x00006E70
		private void Log(params string[] msg)
		{
			string message = this.Indent(msg);
			RtfParserListenerLogger.systemLogger.Info(message);
			bool flag = this.logger != null;
			if (flag)
			{
				this.logger.Info(message);
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00008CB0 File Offset: 0x00006EB0
		private string Indent(params string[] msg)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = msg != null;
			if (flag)
			{
				for (int i = 0; i < base.Level; i++)
				{
					stringBuilder.Append(" ");
				}
				foreach (string value in msg)
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000128 RID: 296
		private readonly RtfParserLoggerSettings settings;

		// Token: 0x04000129 RID: 297
		private readonly ILogger logger;

		// Token: 0x0400012A RID: 298
		private static readonly ILogger systemLogger = Amkor.CADModules.Maintenance.RTFConverter.Logging.Logger.GetLogger(typeof(RtfParserListenerLogger));
	}
}
