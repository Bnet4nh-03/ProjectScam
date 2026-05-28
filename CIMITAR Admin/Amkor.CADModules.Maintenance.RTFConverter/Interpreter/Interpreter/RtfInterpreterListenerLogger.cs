using System;
using System.Globalization;
using Amkor.CADModules.Maintenance.RTFConverter.Logging;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000096 RID: 150
	public class RtfInterpreterListenerLogger : RtfInterpreterListenerBase
	{
		// Token: 0x060004E6 RID: 1254 RVA: 0x0001032D File Offset: 0x0000E52D
		public RtfInterpreterListenerLogger() : this(new RtfInterpreterLoggerSettings(), RtfInterpreterListenerLogger.systemLogger)
		{
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00010341 File Offset: 0x0000E541
		public RtfInterpreterListenerLogger(RtfInterpreterLoggerSettings settings) : this(settings, RtfInterpreterListenerLogger.systemLogger)
		{
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00010351 File Offset: 0x0000E551
		public RtfInterpreterListenerLogger(ILogger logger) : this(new RtfInterpreterLoggerSettings(), logger)
		{
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00010364 File Offset: 0x0000E564
		public RtfInterpreterListenerLogger(RtfInterpreterLoggerSettings settings, ILogger logger)
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

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x000103B0 File Offset: 0x0000E5B0
		public RtfInterpreterLoggerSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x000103C8 File Offset: 0x0000E5C8
		public ILogger Logger
		{
			get
			{
				return this.logger;
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x000103E0 File Offset: 0x0000E5E0
		protected override void DoBeginDocument(IRtfInterpreterContext context)
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.BeginDocumentText);
			if (flag)
			{
				this.Log(this.settings.BeginDocumentText);
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00010438 File Offset: 0x0000E638
		protected override void DoInsertText(IRtfInterpreterContext context, string text)
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.TextFormatText);
			if (flag)
			{
				string text2 = text;
				bool flag2 = text2.Length > this.settings.TextMaxLength && !string.IsNullOrEmpty(this.settings.TextOverflowText);
				if (flag2)
				{
					text2 = text2.Substring(0, text2.Length - this.settings.TextOverflowText.Length) + this.settings.TextOverflowText;
				}
				this.Log(string.Format(CultureInfo.InvariantCulture, this.settings.TextFormatText, new object[]
				{
					text2,
					context.GetSafeCurrentTextFormat()
				}));
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00010510 File Offset: 0x0000E710
		protected override void DoInsertSpecialChar(IRtfInterpreterContext context, RtfVisualSpecialCharKind kind)
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.SpecialCharFormatText);
			if (flag)
			{
				this.Log(string.Format(CultureInfo.InvariantCulture, this.settings.SpecialCharFormatText, new object[]
				{
					kind
				}));
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00010580 File Offset: 0x0000E780
		protected override void DoInsertBreak(IRtfInterpreterContext context, RtfVisualBreakKind kind)
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.BreakFormatText);
			if (flag)
			{
				this.Log(string.Format(CultureInfo.InvariantCulture, this.settings.BreakFormatText, new object[]
				{
					kind
				}));
			}
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x000105F0 File Offset: 0x0000E7F0
		protected override void DoInsertImage(IRtfInterpreterContext context, RtfVisualImageFormat format, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex)
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.ImageFormatText);
			if (flag)
			{
				this.Log(string.Format(CultureInfo.InvariantCulture, this.settings.ImageFormatText, new object[]
				{
					format,
					width,
					height,
					desiredWidth,
					desiredHeight,
					scaleWidthPercent,
					scaleHeightPercent,
					imageDataHex,
					imageDataHex.Length / 2
				}));
			}
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x000106B4 File Offset: 0x0000E8B4
		protected override void DoEndDocument(IRtfInterpreterContext context)
		{
			bool flag = this.settings.Enabled && this.logger.IsInfoEnabled && !string.IsNullOrEmpty(this.settings.EndDocumentText);
			if (flag)
			{
				this.Log(this.settings.EndDocumentText);
			}
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0001070C File Offset: 0x0000E90C
		private void Log(string message)
		{
			RtfInterpreterListenerLogger.systemLogger.Info(message);
			bool flag = this.logger != null;
			if (flag)
			{
				this.logger.Info(message);
			}
		}

		// Token: 0x040001CA RID: 458
		private readonly RtfInterpreterLoggerSettings settings;

		// Token: 0x040001CB RID: 459
		private readonly ILogger logger;

		// Token: 0x040001CC RID: 460
		private static readonly ILogger systemLogger = Amkor.CADModules.Maintenance.RTFConverter.Logging.Logger.GetLogger(typeof(RtfInterpreterListenerLogger));
	}
}
