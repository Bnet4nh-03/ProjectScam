using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image
{
	// Token: 0x0200009E RID: 158
	public interface IRtfConvertedImageInfo
	{
		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000553 RID: 1363
		string FileName { get; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000554 RID: 1364
		ImageFormat Format { get; }

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000555 RID: 1365
		Size Size { get; }
	}
}
