using System;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x0200008F RID: 143
	public sealed class RtfImageBuilder : RtfElementVisitorBase
	{
		// Token: 0x0600047D RID: 1149 RVA: 0x0000D742 File Offset: 0x0000B942
		public RtfImageBuilder() : base(RtfElementVisitorOrder.DepthFirst)
		{
			this.Reset();
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000D754 File Offset: 0x0000B954
		public void Reset()
		{
			this.format = RtfVisualImageFormat.Bmp;
			this.width = 0;
			this.height = 0;
			this.desiredWidth = 0;
			this.desiredHeight = 0;
			this.scaleWidthPercent = 100;
			this.scaleHeightPercent = 100;
			this.imageDataHex = null;
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x0000D794 File Offset: 0x0000B994
		public RtfVisualImageFormat Format
		{
			get
			{
				return this.format;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0000D7AC File Offset: 0x0000B9AC
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0000D7C4 File Offset: 0x0000B9C4
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x0000D7DC File Offset: 0x0000B9DC
		public int DesiredWidth
		{
			get
			{
				return this.desiredWidth;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0000D7F4 File Offset: 0x0000B9F4
		public int DesiredHeight
		{
			get
			{
				return this.desiredHeight;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0000D80C File Offset: 0x0000BA0C
		public int ScaleWidthPercent
		{
			get
			{
				return this.scaleWidthPercent;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000D824 File Offset: 0x0000BA24
		public int ScaleHeightPercent
		{
			get
			{
				return this.scaleHeightPercent;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x0000D83C File Offset: 0x0000BA3C
		public string ImageDataHex
		{
			get
			{
				return this.imageDataHex;
			}
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0000D854 File Offset: 0x0000BA54
		protected override void DoVisitGroup(IRtfGroup group)
		{
			string destination = group.Destination;
			if (destination == "pict")
			{
				this.Reset();
				base.VisitGroupChildren(group);
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0000D88C File Offset: 0x0000BA8C
		protected override void DoVisitTag(IRtfTag tag)
		{
			string name = tag.Name;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			if (num <= 1666178777U)
			{
				if (num <= 1098216500U)
				{
					if (num != 104988892U)
					{
						if (num != 171713509U)
						{
							if (num == 1098216500U)
							{
								if (name == "jpegblip")
								{
									this.format = RtfVisualImageFormat.Jpg;
								}
							}
						}
						else if (name == "wmetafile")
						{
							this.format = RtfVisualImageFormat.Wmf;
						}
					}
					else if (name == "picw")
					{
						this.width = Math.Abs(tag.ValueAsNumber);
						this.desiredWidth = this.width;
					}
				}
				else if (num != 1489552147U)
				{
					if (num != 1649401158U)
					{
						if (num == 1666178777U)
						{
							if (name == "picscalex")
							{
								this.scaleWidthPercent = Math.Abs(tag.ValueAsNumber);
							}
						}
					}
					else if (name == "picscaley")
					{
						this.scaleHeightPercent = Math.Abs(tag.ValueAsNumber);
					}
				}
				else if (name == "pngblip")
				{
					this.format = RtfVisualImageFormat.Png;
				}
			}
			else
			{
				if (num <= 2404747860U)
				{
					if (num != 1799583997U)
					{
						if (num != 2338465226U)
						{
							if (num != 2404747860U)
							{
								return;
							}
							if (!(name == "emfblip"))
							{
								return;
							}
							this.format = RtfVisualImageFormat.Emf;
							return;
						}
						else
						{
							if (!(name == "pichgoal"))
							{
								return;
							}
							this.desiredHeight = Math.Abs(tag.ValueAsNumber);
							bool flag = this.height == 0;
							if (flag)
							{
								this.height = this.desiredHeight;
							}
							return;
						}
					}
					else if (!(name == "wbitmap"))
					{
						return;
					}
				}
				else if (num != 2438597557U)
				{
					if (num != 3872902567U)
					{
						if (num != 4248957617U)
						{
							return;
						}
						if (!(name == "pich"))
						{
							return;
						}
						this.height = Math.Abs(tag.ValueAsNumber);
						this.desiredHeight = this.height;
						return;
					}
					else
					{
						if (!(name == "picwgoal"))
						{
							return;
						}
						this.desiredWidth = Math.Abs(tag.ValueAsNumber);
						bool flag2 = this.width == 0;
						if (flag2)
						{
							this.width = this.desiredWidth;
						}
						return;
					}
				}
				else if (!(name == "dibitmap"))
				{
					return;
				}
				this.format = RtfVisualImageFormat.Bmp;
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0000DB5D File Offset: 0x0000BD5D
		protected override void DoVisitText(IRtfText text)
		{
			this.imageDataHex = text.Text;
		}

		// Token: 0x040001A4 RID: 420
		private RtfVisualImageFormat format;

		// Token: 0x040001A5 RID: 421
		private int width;

		// Token: 0x040001A6 RID: 422
		private int height;

		// Token: 0x040001A7 RID: 423
		private int desiredWidth;

		// Token: 0x040001A8 RID: 424
		private int desiredHeight;

		// Token: 0x040001A9 RID: 425
		private int scaleWidthPercent;

		// Token: 0x040001AA RID: 426
		private int scaleHeightPercent;

		// Token: 0x040001AB RID: 427
		private string imageDataHex;
	}
}
