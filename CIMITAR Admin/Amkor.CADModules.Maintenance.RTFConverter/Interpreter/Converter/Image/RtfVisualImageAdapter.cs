using System;
using System.Drawing.Imaging;
using System.Globalization;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image
{
	// Token: 0x020000A5 RID: 165
	public class RtfVisualImageAdapter : IRtfVisualImageAdapter
	{
		// Token: 0x06000582 RID: 1410 RVA: 0x00011A9A File Offset: 0x0000FC9A
		public RtfVisualImageAdapter() : this("{0}{1}", null)
		{
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00011AAA File Offset: 0x0000FCAA
		public RtfVisualImageAdapter(string fileNamePattern) : this(fileNamePattern, null)
		{
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00011AB6 File Offset: 0x0000FCB6
		public RtfVisualImageAdapter(ImageFormat targetFormat) : this("{0}{1}", targetFormat)
		{
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00011AC8 File Offset: 0x0000FCC8
		public RtfVisualImageAdapter(string fileNamePattern, ImageFormat targetFormat) : this(fileNamePattern, targetFormat, 96.0, 96.0)
		{
			bool flag = fileNamePattern == null;
			if (flag)
			{
				throw new ArgumentNullException("fileNamePattern");
			}
			this.fileNamePattern = fileNamePattern;
			this.targetFormat = targetFormat;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00011B14 File Offset: 0x0000FD14
		public RtfVisualImageAdapter(string fileNamePattern, ImageFormat targetFormat, double dpiX, double dpiY)
		{
			bool flag = fileNamePattern == null;
			if (flag)
			{
				throw new ArgumentNullException("fileNamePattern");
			}
			this.fileNamePattern = fileNamePattern;
			this.targetFormat = targetFormat;
			this.dpiX = dpiX;
			this.dpiY = dpiY;
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x00011B5C File Offset: 0x0000FD5C
		public string FileNamePattern
		{
			get
			{
				return this.fileNamePattern;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x00011B74 File Offset: 0x0000FD74
		public ImageFormat TargetFormat
		{
			get
			{
				return this.targetFormat;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x00011B8C File Offset: 0x0000FD8C
		public double DpiX
		{
			get
			{
				return this.dpiX;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00011BA4 File Offset: 0x0000FDA4
		public double DpiY
		{
			get
			{
				return this.dpiY;
			}
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00011BBC File Offset: 0x0000FDBC
		public ImageFormat GetImageFormat(RtfVisualImageFormat rtfVisualImageFormat)
		{
			ImageFormat result = null;
			switch (rtfVisualImageFormat)
			{
			case RtfVisualImageFormat.Emf:
				result = ImageFormat.Emf;
				break;
			case RtfVisualImageFormat.Png:
				result = ImageFormat.Png;
				break;
			case RtfVisualImageFormat.Jpg:
				result = ImageFormat.Jpeg;
				break;
			case RtfVisualImageFormat.Wmf:
				result = ImageFormat.Wmf;
				break;
			case RtfVisualImageFormat.Bmp:
				result = ImageFormat.Bmp;
				break;
			}
			return result;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00011C18 File Offset: 0x0000FE18
		public string ResolveFileName(int index, RtfVisualImageFormat rtfVisualImageFormat)
		{
			ImageFormat imageFormat = this.targetFormat ?? this.GetImageFormat(rtfVisualImageFormat);
			return string.Format(CultureInfo.InvariantCulture, this.fileNamePattern, new object[]
			{
				index,
				RtfVisualImageAdapter.GetFileImageExtension(imageFormat)
			});
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00011C64 File Offset: 0x0000FE64
		public int CalcImageWidth(RtfVisualImageFormat format, int width, int desiredWidth, int scaleWidthPercent)
		{
			float num = (float)scaleWidthPercent / 100f;
			return (int)Math.Round((double)desiredWidth * (double)num / 1440.0 * this.dpiX);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00011C9C File Offset: 0x0000FE9C
		public int CalcImageHeight(RtfVisualImageFormat format, int height, int desiredHeight, int scaleHeightPercent)
		{
			float num = (float)scaleHeightPercent / 100f;
			return (int)Math.Round((double)desiredHeight * (double)num / 1440.0 * this.dpiY);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00011CD4 File Offset: 0x0000FED4
		private static string GetFileImageExtension(ImageFormat imageFormat)
		{
			string result = null;
			bool flag = imageFormat == ImageFormat.Bmp;
			if (flag)
			{
				result = ".bmp";
			}
			else
			{
				bool flag2 = imageFormat == ImageFormat.Emf;
				if (flag2)
				{
					result = ".emf";
				}
				else
				{
					bool flag3 = imageFormat == ImageFormat.Exif;
					if (flag3)
					{
						result = ".exif";
					}
					else
					{
						bool flag4 = imageFormat == ImageFormat.Gif;
						if (flag4)
						{
							result = ".gif";
						}
						else
						{
							bool flag5 = imageFormat == ImageFormat.Icon;
							if (flag5)
							{
								result = ".ico";
							}
							else
							{
								bool flag6 = imageFormat == ImageFormat.Jpeg;
								if (flag6)
								{
									result = ".jpg";
								}
								else
								{
									bool flag7 = imageFormat == ImageFormat.Png;
									if (flag7)
									{
										result = ".png";
									}
									else
									{
										bool flag8 = imageFormat == ImageFormat.Tiff;
										if (flag8)
										{
											result = ".tiff";
										}
										else
										{
											bool flag9 = imageFormat == ImageFormat.Wmf;
											if (flag9)
											{
												result = ".wmf";
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0400020D RID: 525
		public const double DefaultDpi = 96.0;

		// Token: 0x0400020E RID: 526
		private readonly string fileNamePattern;

		// Token: 0x0400020F RID: 527
		private readonly ImageFormat targetFormat;

		// Token: 0x04000210 RID: 528
		private readonly double dpiX;

		// Token: 0x04000211 RID: 529
		private readonly double dpiY;

		// Token: 0x04000212 RID: 530
		private const string defaultFileNamePattern = "{0}{1}";

		// Token: 0x04000213 RID: 531
		private const int twipsPerInch = 1440;
	}
}
