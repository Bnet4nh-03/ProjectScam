using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using Amkor.CADModules.Maintenance.GrobalConst;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000082 RID: 130
	public sealed class RtfVisualImage : RtfVisual, IRtfVisualImage, IRtfVisual
	{
		// Token: 0x06000411 RID: 1041 RVA: 0x0000B584 File Offset: 0x00009784
		public RtfVisualImage(RtfVisualImageFormat format, RtfTextAlignment alignment, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex) : base(RtfVisualKind.Image)
		{
			bool flag = width <= 0;
			if (flag)
			{
				throw new ArgumentException(Strings.InvalidImageWidth(width));
			}
			bool flag2 = height <= 0;
			if (flag2)
			{
				throw new ArgumentException(Strings.InvalidImageHeight(height));
			}
			bool flag3 = desiredWidth <= 0;
			if (flag3)
			{
				throw new ArgumentException(Strings.InvalidImageDesiredWidth(desiredWidth));
			}
			bool flag4 = desiredHeight <= 0;
			if (flag4)
			{
				throw new ArgumentException(Strings.InvalidImageDesiredHeight(desiredHeight));
			}
			bool flag5 = scaleWidthPercent <= 0;
			if (flag5)
			{
				throw new ArgumentException(Strings.InvalidImageScaleWidth(scaleWidthPercent));
			}
			bool flag6 = scaleHeightPercent <= 0;
			if (flag6)
			{
				throw new ArgumentException(Strings.InvalidImageScaleHeight(scaleHeightPercent));
			}
			bool flag7 = imageDataHex == null;
			if (flag7)
			{
				throw new ArgumentNullException("imageDataHex");
			}
			this.format = format;
			this.alignment = alignment;
			this.width = width;
			this.height = height;
			this.desiredWidth = desiredWidth;
			this.desiredHeight = desiredHeight;
			this.scaleWidthPercent = scaleWidthPercent;
			this.scaleHeightPercent = scaleHeightPercent;
			this.imageDataHex = imageDataHex;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000B694 File Offset: 0x00009894
		protected override void DoVisit(IRtfVisualVisitor visitor, cConst.Upload.HTMLtype type)
		{
			visitor.VisitImage(this, type);
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x0000B6A0 File Offset: 0x000098A0
		public RtfVisualImageFormat Format
		{
			get
			{
				return this.format;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x0000B6B8 File Offset: 0x000098B8
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x0000B6D0 File Offset: 0x000098D0
		public RtfTextAlignment Alignment
		{
			get
			{
				return this.alignment;
			}
			set
			{
				this.alignment = value;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x0000B6DC File Offset: 0x000098DC
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000B6F4 File Offset: 0x000098F4
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x0000B70C File Offset: 0x0000990C
		public int DesiredWidth
		{
			get
			{
				return this.desiredWidth;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000B724 File Offset: 0x00009924
		public int DesiredHeight
		{
			get
			{
				return this.desiredHeight;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000B73C File Offset: 0x0000993C
		public int ScaleWidthPercent
		{
			get
			{
				return this.scaleWidthPercent;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x0000B754 File Offset: 0x00009954
		public int ScaleHeightPercent
		{
			get
			{
				return this.scaleHeightPercent;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x0000B76C File Offset: 0x0000996C
		public string ImageDataHex
		{
			get
			{
				return this.imageDataHex;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x0000B784 File Offset: 0x00009984
		public byte[] ImageDataBinary
		{
			get
			{
				byte[] result;
				if ((result = this.imageDataBinary) == null)
				{
					result = (this.imageDataBinary = RtfVisualImage.ToBinary(this.imageDataHex));
				}
				return result;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x0000B7B4 File Offset: 0x000099B4
		public Image ImageForDrawing
		{
			get
			{
				RtfVisualImageFormat rtfVisualImageFormat = this.format;
				Image result;
				if (rtfVisualImageFormat > RtfVisualImageFormat.Bmp)
				{
					result = null;
				}
				else
				{
					byte[] array = this.ImageDataBinary;
					result = Image.FromStream(new MemoryStream(array, 0, array.Length));
				}
				return result;
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0000B7F0 File Offset: 0x000099F0
		public static byte[] ToBinary(string imageDataHex)
		{
			bool flag = imageDataHex == null;
			if (flag)
			{
				throw new ArgumentNullException("imageDataHex");
			}
			int length = imageDataHex.Length;
			int num = length / 2;
			byte[] array = new byte[num];
			StringBuilder stringBuilder = new StringBuilder(2);
			int num2 = 0;
			for (int i = 0; i < length; i++)
			{
				char c = imageDataHex[i];
				bool flag2 = char.IsWhiteSpace(c);
				if (!flag2)
				{
					stringBuilder.Append(imageDataHex[i]);
					bool flag3 = stringBuilder.Length == 2;
					if (flag3)
					{
						array[num2] = byte.Parse(stringBuilder.ToString(), NumberStyles.HexNumber);
						num2++;
						stringBuilder.Remove(0, 2);
					}
				}
			}
			return array;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0000B8AC File Offset: 0x00009AAC
		protected override bool IsEqual(object obj)
		{
			RtfVisualImage rtfVisualImage = obj as RtfVisualImage;
			return rtfVisualImage != null && base.IsEqual(rtfVisualImage) && this.format == rtfVisualImage.format && this.alignment == rtfVisualImage.alignment && this.width == rtfVisualImage.width && this.height == rtfVisualImage.height && this.desiredWidth == rtfVisualImage.desiredWidth && this.desiredHeight == rtfVisualImage.desiredHeight && this.scaleWidthPercent == rtfVisualImage.scaleWidthPercent && this.scaleHeightPercent == rtfVisualImage.scaleHeightPercent && this.imageDataHex.Equals(rtfVisualImage.imageDataHex);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000B95C File Offset: 0x00009B5C
		protected override int ComputeHashCode()
		{
			int hash = base.ComputeHashCode();
			hash = HashTool.AddHashCode(hash, this.format);
			hash = HashTool.AddHashCode(hash, this.alignment);
			hash = HashTool.AddHashCode(hash, this.width);
			hash = HashTool.AddHashCode(hash, this.height);
			hash = HashTool.AddHashCode(hash, this.desiredWidth);
			hash = HashTool.AddHashCode(hash, this.desiredHeight);
			hash = HashTool.AddHashCode(hash, this.scaleWidthPercent);
			hash = HashTool.AddHashCode(hash, this.scaleHeightPercent);
			return HashTool.AddHashCode(hash, this.imageDataHex);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0000B9F8 File Offset: 0x00009BF8
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"[",
				this.format,
				": ",
				this.alignment,
				", ",
				this.width,
				" x ",
				this.height,
				" (",
				this.desiredWidth,
				" x ",
				this.desiredHeight,
				") {",
				this.scaleWidthPercent,
				"% x ",
				this.scaleHeightPercent,
				"%} :",
				this.imageDataHex.Length / 2,
				" bytes]"
			});
		}

		// Token: 0x0400017F RID: 383
		private readonly RtfVisualImageFormat format;

		// Token: 0x04000180 RID: 384
		private RtfTextAlignment alignment;

		// Token: 0x04000181 RID: 385
		private readonly int width;

		// Token: 0x04000182 RID: 386
		private readonly int height;

		// Token: 0x04000183 RID: 387
		private readonly int desiredWidth;

		// Token: 0x04000184 RID: 388
		private readonly int desiredHeight;

		// Token: 0x04000185 RID: 389
		private readonly int scaleWidthPercent;

		// Token: 0x04000186 RID: 390
		private readonly int scaleHeightPercent;

		// Token: 0x04000187 RID: 391
		private readonly string imageDataHex;

		// Token: 0x04000188 RID: 392
		private byte[] imageDataBinary;
	}
}
