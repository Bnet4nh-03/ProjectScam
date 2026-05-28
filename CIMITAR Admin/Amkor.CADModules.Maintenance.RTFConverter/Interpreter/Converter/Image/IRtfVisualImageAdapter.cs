using System;
using System.Drawing.Imaging;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image
{
	// Token: 0x020000A0 RID: 160
	public interface IRtfVisualImageAdapter
	{
		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000559 RID: 1369
		string FileNamePattern { get; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x0600055A RID: 1370
		ImageFormat TargetFormat { get; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x0600055B RID: 1371
		double DpiX { get; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600055C RID: 1372
		double DpiY { get; }

		// Token: 0x0600055D RID: 1373
		ImageFormat GetImageFormat(RtfVisualImageFormat rtfVisualImageFormat);

		// Token: 0x0600055E RID: 1374
		string ResolveFileName(int index, RtfVisualImageFormat rtfVisualImageFormat);

		// Token: 0x0600055F RID: 1375
		int CalcImageWidth(RtfVisualImageFormat format, int width, int desiredWidth, int scaleWidthPercent);

		// Token: 0x06000560 RID: 1376
		int CalcImageHeight(RtfVisualImageFormat format, int height, int desiredHeight, int scaleHeightPercent);
	}
}
