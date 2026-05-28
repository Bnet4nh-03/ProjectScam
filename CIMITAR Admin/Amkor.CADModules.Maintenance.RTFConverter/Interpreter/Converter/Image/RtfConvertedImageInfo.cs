using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image
{
	// Token: 0x020000A1 RID: 161
	public class RtfConvertedImageInfo : IRtfConvertedImageInfo
	{
		// Token: 0x06000561 RID: 1377 RVA: 0x000114D4 File Offset: 0x0000F6D4
		public RtfConvertedImageInfo(string fileName, ImageFormat format, Size size)
		{
			bool flag = fileName == null;
			if (flag)
			{
				throw new ArgumentNullException("fileName");
			}
			this.fileName = fileName;
			this.format = format;
			this.size = size;
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x00011514 File Offset: 0x0000F714
		public string FileName
		{
			get
			{
				return this.fileName;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000563 RID: 1379 RVA: 0x0001152C File Offset: 0x0000F72C
		public ImageFormat Format
		{
			get
			{
				return this.format;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x00011544 File Offset: 0x0000F744
		public Size Size
		{
			get
			{
				return this.size;
			}
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0001155C File Offset: 0x0000F75C
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				this.fileName,
				" ",
				this.format,
				" ",
				this.size.Width,
				"x",
				this.size.Height
			});
		}

		// Token: 0x04000202 RID: 514
		private readonly string fileName;

		// Token: 0x04000203 RID: 515
		private readonly ImageFormat format;

		// Token: 0x04000204 RID: 516
		private readonly Size size;
	}
}
