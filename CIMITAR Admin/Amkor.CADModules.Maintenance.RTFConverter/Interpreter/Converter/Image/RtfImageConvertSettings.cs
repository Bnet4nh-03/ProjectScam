using System;
using System.Drawing;
using System.IO;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image
{
	// Token: 0x020000A4 RID: 164
	public class RtfImageConvertSettings
	{
		// Token: 0x06000574 RID: 1396 RVA: 0x0001197D File Offset: 0x0000FB7D
		public RtfImageConvertSettings() : this(new RtfVisualImageAdapter())
		{
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0001198C File Offset: 0x0000FB8C
		public RtfImageConvertSettings(IRtfVisualImageAdapter imageAdapter)
		{
			bool flag = imageAdapter == null;
			if (flag)
			{
				throw new ArgumentNullException("imageAdapter");
			}
			this.imageAdapter = imageAdapter;
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x000119C4 File Offset: 0x0000FBC4
		public IRtfVisualImageAdapter ImageAdapter
		{
			get
			{
				return this.imageAdapter;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x000119DC File Offset: 0x0000FBDC
		// (set) Token: 0x06000578 RID: 1400 RVA: 0x000119E4 File Offset: 0x0000FBE4
		public Color? BackgroundColor { get; set; }

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x000119F0 File Offset: 0x0000FBF0
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x00011A08 File Offset: 0x0000FC08
		public string ImagesPath
		{
			get
			{
				return this.imagesPath;
			}
			set
			{
				this.imagesPath = value;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x00011A14 File Offset: 0x0000FC14
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x00011A2C File Offset: 0x0000FC2C
		public bool ScaleImage
		{
			get
			{
				return this.scaleImage;
			}
			set
			{
				this.scaleImage = value;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x00011A36 File Offset: 0x0000FC36
		// (set) Token: 0x0600057E RID: 1406 RVA: 0x00011A3E File Offset: 0x0000FC3E
		public float ScaleOffset { get; set; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x00011A47 File Offset: 0x0000FC47
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x00011A4F File Offset: 0x0000FC4F
		public float ScaleExtension { get; set; }

		// Token: 0x06000581 RID: 1409 RVA: 0x00011A58 File Offset: 0x0000FC58
		public string GetImageFileName(int index, RtfVisualImageFormat rtfVisualImageFormat)
		{
			string text = this.imageAdapter.ResolveFileName(index, rtfVisualImageFormat);
			bool flag = !string.IsNullOrEmpty(this.imagesPath);
			if (flag)
			{
				text = Path.Combine(this.imagesPath, text);
			}
			return text;
		}

		// Token: 0x0400020A RID: 522
		private readonly IRtfVisualImageAdapter imageAdapter;

		// Token: 0x0400020B RID: 523
		private string imagesPath;

		// Token: 0x0400020C RID: 524
		private bool scaleImage = true;
	}
}
