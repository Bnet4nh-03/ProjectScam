using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Parser
{
	// Token: 0x0200006B RID: 107
	public class RtfParserListenerFileLogger : RtfParserListenerBase, IDisposable
	{
		// Token: 0x060002EF RID: 751 RVA: 0x0000821B File Offset: 0x0000641B
		public RtfParserListenerFileLogger(string fileName) : this(fileName, new RtfParserLoggerSettings())
		{
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000822C File Offset: 0x0000642C
		public RtfParserListenerFileLogger(string fileName, RtfParserLoggerSettings settings)
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

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x00008278 File Offset: 0x00006478
		public string FileName
		{
			get
			{
				return this.fileName;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00008290 File Offset: 0x00006490
		public RtfParserLoggerSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x000082A8 File Offset: 0x000064A8
		public virtual void Dispose()
		{
			this.CloseStream();
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000082B4 File Offset: 0x000064B4
		protected override void DoParseBegin()
		{
			this.EnsureDirectory();
			this.OpenStream();
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.ParseBeginText);
			if (flag)
			{
				this.WriteLine(new string[]
				{
					this.settings.ParseBeginText
				});
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00008314 File Offset: 0x00006514
		protected override void DoGroupBegin()
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.ParseGroupBeginText);
			if (flag)
			{
				this.WriteLine(new string[]
				{
					this.settings.ParseGroupBeginText
				});
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00008368 File Offset: 0x00006568
		protected override void DoTagFound(IRtfTag tag)
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.ParseTagText);
			if (flag)
			{
				this.WriteLine(new string[]
				{
					string.Format(CultureInfo.InvariantCulture, this.settings.ParseTagText, new object[]
					{
						tag
					})
				});
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x000083D0 File Offset: 0x000065D0
		protected override void DoTextFound(IRtfText text)
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.ParseTextText);
			if (flag)
			{
				string text2 = text.Text;
				bool flag2 = text2.Length > this.settings.TextMaxLength && !string.IsNullOrEmpty(this.settings.TextOverflowText);
				if (flag2)
				{
					text2 = text2.Substring(0, text2.Length - this.settings.TextOverflowText.Length) + this.settings.TextOverflowText;
				}
				this.WriteLine(new string[]
				{
					string.Format(CultureInfo.InvariantCulture, this.settings.ParseTextText, new object[]
					{
						text2
					})
				});
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x000084A0 File Offset: 0x000066A0
		protected override void DoGroupEnd()
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.ParseGroupEndText);
			if (flag)
			{
				this.WriteLine(new string[]
				{
					this.settings.ParseGroupEndText
				});
			}
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x000084F4 File Offset: 0x000066F4
		protected override void DoParseSuccess()
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.ParseSuccessText);
			if (flag)
			{
				this.WriteLine(new string[]
				{
					this.settings.ParseSuccessText
				});
			}
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00008548 File Offset: 0x00006748
		protected override void DoParseFail(RtfException reason)
		{
			bool enabled = this.settings.Enabled;
			if (enabled)
			{
				bool flag = reason != null;
				if (flag)
				{
					bool flag2 = !string.IsNullOrEmpty(this.settings.ParseFailKnownReasonText);
					if (flag2)
					{
						this.WriteLine(new string[]
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
					bool flag3 = !string.IsNullOrEmpty(this.settings.ParseFailUnknownReasonText);
					if (flag3)
					{
						this.WriteLine(new string[]
						{
							this.settings.ParseFailUnknownReasonText
						});
					}
				}
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000085FC File Offset: 0x000067FC
		protected override void DoParseEnd()
		{
			bool flag = this.settings.Enabled && !string.IsNullOrEmpty(this.settings.ParseEndText);
			if (flag)
			{
				this.WriteLine(new string[]
				{
					this.settings.ParseEndText
				});
			}
			this.CloseStream();
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00008658 File Offset: 0x00006858
		private void WriteLine(params string[] msg)
		{
			bool flag = this.streamWriter == null;
			if (!flag)
			{
				string value = this.Indent(msg);
				this.streamWriter.WriteLine(value);
				this.streamWriter.Flush();
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00008698 File Offset: 0x00006898
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

		// Token: 0x060002FE RID: 766 RVA: 0x00008710 File Offset: 0x00006910
		private void EnsureDirectory()
		{
			FileInfo fileInfo = new FileInfo(this.fileName);
			bool flag = !string.IsNullOrEmpty(fileInfo.DirectoryName) && !Directory.Exists(fileInfo.DirectoryName);
			if (flag)
			{
				Directory.CreateDirectory(fileInfo.DirectoryName);
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000875C File Offset: 0x0000695C
		private void OpenStream()
		{
			bool flag = this.streamWriter != null;
			if (!flag)
			{
				this.streamWriter = new StreamWriter(this.fileName);
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000878C File Offset: 0x0000698C
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

		// Token: 0x04000124 RID: 292
		public const string DefaultLogFileExtension = ".parser.log";

		// Token: 0x04000125 RID: 293
		private readonly string fileName;

		// Token: 0x04000126 RID: 294
		private readonly RtfParserLoggerSettings settings;

		// Token: 0x04000127 RID: 295
		private StreamWriter streamWriter;
	}
}
