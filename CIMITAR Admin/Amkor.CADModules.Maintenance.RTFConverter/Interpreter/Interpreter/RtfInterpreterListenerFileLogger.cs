using System;
using System.Globalization;
using System.IO;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000095 RID: 149
	public class RtfInterpreterListenerFileLogger : RtfInterpreterListenerBase, IDisposable
	{
		// Token: 0x060004D7 RID: 1239 RVA: 0x0000FEB1 File Offset: 0x0000E0B1
		public RtfInterpreterListenerFileLogger(string fileName) : this(fileName, new RtfInterpreterLoggerSettings())
		{
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0000FEC4 File Offset: 0x0000E0C4
		public RtfInterpreterListenerFileLogger(string fileName, RtfInterpreterLoggerSettings settings)
		{
			bool flag = fileName == null;
			if (flag)
			{
				throw new ArgumentNullException("fileName");
			}
			bool flag2 = settings == null;
			if (flag2)
			{
				throw new ArgumentNullException("settings");
			}
			this.fileName = fileName;
			this.settings = settings;
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0000FF10 File Offset: 0x0000E110
		public string FileName
		{
			get
			{
				return this.fileName;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x0000FF28 File Offset: 0x0000E128
		public RtfInterpreterLoggerSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0000FF40 File Offset: 0x0000E140
		public virtual void Dispose()
		{
			this.CloseStream();
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000FF4C File Offset: 0x0000E14C
		protected override void DoBeginDocument(IRtfInterpreterContext context)
		{
			this.EnsureDirectory();
			this.OpenStream();
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.BeginDocumentText);
			if (flag)
			{
				this.WriteLine(this.settings.BeginDocumentText);
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0000FFA4 File Offset: 0x0000E1A4
		protected override void DoInsertText(IRtfInterpreterContext context, string text)
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.TextFormatText);
			if (flag)
			{
				string text2 = text;
				bool flag2 = text2.Length > this.settings.TextMaxLength && !string.IsNullOrEmpty(this.settings.TextOverflowText);
				if (flag2)
				{
					text2 = text2.Substring(0, text2.Length - this.settings.TextOverflowText.Length) + this.settings.TextOverflowText;
				}
				this.WriteLine(string.Format(CultureInfo.InvariantCulture, this.settings.TextFormatText, new object[]
				{
					text2,
					context.CurrentTextFormat
				}));
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00010070 File Offset: 0x0000E270
		protected override void DoInsertSpecialChar(IRtfInterpreterContext context, RtfVisualSpecialCharKind kind)
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.SpecialCharFormatText);
			if (flag)
			{
				this.WriteLine(string.Format(CultureInfo.InvariantCulture, this.settings.SpecialCharFormatText, new object[]
				{
					kind
				}));
			}
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x000100D4 File Offset: 0x0000E2D4
		protected override void DoInsertBreak(IRtfInterpreterContext context, RtfVisualBreakKind kind)
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.BreakFormatText);
			if (flag)
			{
				this.WriteLine(string.Format(CultureInfo.InvariantCulture, this.settings.BreakFormatText, new object[]
				{
					kind
				}));
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00010138 File Offset: 0x0000E338
		protected override void DoInsertImage(IRtfInterpreterContext context, RtfVisualImageFormat format, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex)
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.ImageFormatText);
			if (flag)
			{
				this.WriteLine(string.Format(CultureInfo.InvariantCulture, this.settings.ImageFormatText, new object[]
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

		// Token: 0x060004E1 RID: 1249 RVA: 0x000101EC File Offset: 0x0000E3EC
		protected override void DoEndDocument(IRtfInterpreterContext context)
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.EndDocumentText);
			if (flag)
			{
				this.WriteLine(this.settings.EndDocumentText);
			}
			this.CloseStream();
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0001023C File Offset: 0x0000E43C
		private void WriteLine(string message)
		{
			bool flag = this.streamWriter == null;
			if (!flag)
			{
				this.streamWriter.WriteLine(message);
				this.streamWriter.Flush();
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00010274 File Offset: 0x0000E474
		private void EnsureDirectory()
		{
			FileInfo fileInfo = new FileInfo(this.fileName);
			bool flag = !string.IsNullOrEmpty(fileInfo.DirectoryName) && !Directory.Exists(fileInfo.DirectoryName);
			if (flag)
			{
				Directory.CreateDirectory(fileInfo.DirectoryName);
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x000102C0 File Offset: 0x0000E4C0
		private void OpenStream()
		{
			bool flag = this.streamWriter != null;
			if (!flag)
			{
				this.streamWriter = new StreamWriter(this.fileName);
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x000102F0 File Offset: 0x0000E4F0
		private void CloseStream()
		{
			bool flag = this.streamWriter == null;
			if (!flag)
			{
				this.streamWriter.Close();
				this.streamWriter.Dispose();
				this.streamWriter = null;
			}
		}

		// Token: 0x040001C6 RID: 454
		public const string DefaultLogFileExtension = ".interpreter.log";

		// Token: 0x040001C7 RID: 455
		private readonly string fileName;

		// Token: 0x040001C8 RID: 456
		private readonly RtfInterpreterLoggerSettings settings;

		// Token: 0x040001C9 RID: 457
		private StreamWriter streamWriter;
	}
}
