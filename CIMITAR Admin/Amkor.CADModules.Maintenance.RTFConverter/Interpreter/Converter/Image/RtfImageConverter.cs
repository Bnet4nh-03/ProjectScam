using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image
{
	// Token: 0x020000A3 RID: 163
	public class RtfImageConverter : RtfInterpreterListenerBase
	{
		// Token: 0x0600056C RID: 1388 RVA: 0x0001163C File Offset: 0x0000F83C
		public RtfImageConverter() : this(new RtfImageConvertSettings())
		{
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0001164C File Offset: 0x0000F84C
		public RtfImageConverter(RtfImageConvertSettings settings)
		{
			bool flag = settings == null;
			if (flag)
			{
				throw new ArgumentNullException("settings");
			}
			this.settings = settings;
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x00011688 File Offset: 0x0000F888
		public RtfImageConvertSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x000116A0 File Offset: 0x0000F8A0
		public RtfConvertedImageInfoCollection ConvertedImages
		{
			get
			{
				return this.convertedImages;
			}
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000116B8 File Offset: 0x0000F8B8
		protected override void DoBeginDocument(IRtfInterpreterContext context)
		{
			base.DoBeginDocument(context);
			this.convertedImages.Clear();
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x000116D0 File Offset: 0x0000F8D0
		protected override void DoInsertImage(IRtfInterpreterContext context, RtfVisualImageFormat format, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex)
		{
			int index = this.convertedImages.Count + 1;
			string imageFileName = this.settings.GetImageFileName(index, format);
			this.EnsureImagesPath(imageFileName);
			byte[] array = RtfVisualImage.ToBinary(imageDataHex);
			bool flag = this.settings.ImageAdapter.TargetFormat == null;
			ImageFormat format2;
			Size size;
			if (flag)
			{
				using (Image image = Image.FromStream(new MemoryStream(array)))
				{
					format2 = image.RawFormat;
					size = image.Size;
				}
				using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(imageFileName, FileMode.Create)))
				{
					binaryWriter.Write(array);
				}
			}
			else
			{
				format2 = this.settings.ImageAdapter.TargetFormat;
				bool scaleImage = this.settings.ScaleImage;
				if (scaleImage)
				{
					size = new Size(this.settings.ImageAdapter.CalcImageWidth(format, width, desiredWidth, scaleWidthPercent), this.settings.ImageAdapter.CalcImageHeight(format, height, desiredHeight, scaleHeightPercent));
				}
				else
				{
					size = new Size(width, height);
				}
				this.SaveImage(array, format, imageFileName, size);
			}
			this.convertedImages.Add(new RtfConvertedImageInfo(imageFileName, format2, size));
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00011824 File Offset: 0x0000FA24
		protected virtual void SaveImage(byte[] imageBuffer, RtfVisualImageFormat format, string fileName, Size size)
		{
			ImageFormat targetFormat = this.settings.ImageAdapter.TargetFormat;
			float scaleOffset = this.settings.ScaleOffset;
			float scaleExtension = this.settings.ScaleExtension;
			using (Image image = Image.FromStream(new MemoryStream(imageBuffer, 0, imageBuffer.Length)))
			{
				Bitmap bitmap = new Bitmap(new Bitmap(size.Width, size.Height, image.PixelFormat));
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				RectangleF rect = new RectangleF(scaleOffset, scaleOffset, (float)size.Width + scaleExtension, (float)size.Height + scaleExtension);
				bool flag = this.settings.BackgroundColor != null;
				if (flag)
				{
					graphics.Clear(this.settings.BackgroundColor.Value);
				}
				graphics.DrawImage(image, rect);
				bitmap.Save(fileName, targetFormat);
			}
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00011938 File Offset: 0x0000FB38
		protected virtual void EnsureImagesPath(string imageFileName)
		{
			FileInfo fileInfo = new FileInfo(imageFileName);
			bool flag = !string.IsNullOrEmpty(fileInfo.DirectoryName) && !Directory.Exists(fileInfo.DirectoryName);
			if (flag)
			{
				Directory.CreateDirectory(fileInfo.DirectoryName);
			}
		}

		// Token: 0x04000205 RID: 517
		private readonly RtfConvertedImageInfoCollection convertedImages = new RtfConvertedImageInfoCollection();

		// Token: 0x04000206 RID: 518
		private readonly RtfImageConvertSettings settings;
	}
}
