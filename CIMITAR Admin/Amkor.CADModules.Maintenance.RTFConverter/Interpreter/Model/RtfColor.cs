using System;
using System.Drawing;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000075 RID: 117
	public sealed class RtfColor : IRtfColor
	{
		// Token: 0x06000361 RID: 865 RVA: 0x000096E0 File Offset: 0x000078E0
		public RtfColor(int red, int green, int blue)
		{
			bool flag = red < 0 || red > 255;
			if (flag)
			{
				throw new RtfColorException(Strings.InvalidColor(red));
			}
			bool flag2 = green < 0 || green > 255;
			if (flag2)
			{
				throw new RtfColorException(Strings.InvalidColor(green));
			}
			bool flag3 = blue < 0 || blue > 255;
			if (flag3)
			{
				throw new RtfColorException(Strings.InvalidColor(blue));
			}
			this.red = red;
			this.green = green;
			this.blue = blue;
			this.drawingColor = Color.FromArgb(red, green, blue);
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00009778 File Offset: 0x00007978
		public int Red
		{
			get
			{
				return this.red;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000363 RID: 867 RVA: 0x00009790 File Offset: 0x00007990
		public int Green
		{
			get
			{
				return this.green;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000364 RID: 868 RVA: 0x000097A8 File Offset: 0x000079A8
		public int Blue
		{
			get
			{
				return this.blue;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000365 RID: 869 RVA: 0x000097C0 File Offset: 0x000079C0
		public Color AsDrawingColor
		{
			get
			{
				return this.drawingColor;
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x000097D8 File Offset: 0x000079D8
		public override bool Equals(object obj)
		{
			bool flag = obj == this;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = obj == null || base.GetType() != obj.GetType();
				result = (!flag2 && this.IsEqual(obj));
			}
			return result;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00009820 File Offset: 0x00007A20
		public override int GetHashCode()
		{
			return HashTool.AddHashCode(base.GetType().GetHashCode(), this.ComputeHashCode());
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00009848 File Offset: 0x00007A48
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"Color{",
				this.red,
				",",
				this.green,
				",",
				this.blue,
				"}"
			});
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000098B0 File Offset: 0x00007AB0
		private bool IsEqual(object obj)
		{
			RtfColor rtfColor = obj as RtfColor;
			return rtfColor != null && this.red == rtfColor.red && this.green == rtfColor.green && this.blue == rtfColor.blue;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x000098FC File Offset: 0x00007AFC
		private int ComputeHashCode()
		{
			int hash = this.red;
			hash = HashTool.AddHashCode(hash, this.green);
			return HashTool.AddHashCode(hash, this.blue);
		}

		// Token: 0x04000140 RID: 320
		public static readonly IRtfColor Black = new RtfColor(0, 0, 0);

		// Token: 0x04000141 RID: 321
		public static readonly IRtfColor White = new RtfColor(255, 255, 255);

		// Token: 0x04000142 RID: 322
		private readonly int red;

		// Token: 0x04000143 RID: 323
		private readonly int green;

		// Token: 0x04000144 RID: 324
		private readonly int blue;

		// Token: 0x04000145 RID: 325
		private readonly Color drawingColor;
	}
}
