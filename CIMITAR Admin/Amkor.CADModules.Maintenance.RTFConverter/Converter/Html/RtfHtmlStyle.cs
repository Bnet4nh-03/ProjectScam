using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000B4 RID: 180
	public class RtfHtmlStyle : IRtfHtmlStyle
	{
		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x000140AC File Offset: 0x000122AC
		// (set) Token: 0x06000633 RID: 1587 RVA: 0x000140C4 File Offset: 0x000122C4
		public string ForegroundColor
		{
			get
			{
				return this.foregroundColor;
			}
			set
			{
				this.foregroundColor = value;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x000140D0 File Offset: 0x000122D0
		// (set) Token: 0x06000635 RID: 1589 RVA: 0x000140E8 File Offset: 0x000122E8
		public string BackgroundColor
		{
			get
			{
				return this.backgroundColor;
			}
			set
			{
				this.backgroundColor = value;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000636 RID: 1590 RVA: 0x000140F4 File Offset: 0x000122F4
		// (set) Token: 0x06000637 RID: 1591 RVA: 0x0001410C File Offset: 0x0001230C
		public string FontFamily
		{
			get
			{
				return this.fontFamily;
			}
			set
			{
				this.fontFamily = value;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x00014118 File Offset: 0x00012318
		// (set) Token: 0x06000639 RID: 1593 RVA: 0x00014130 File Offset: 0x00012330
		public string FontSize
		{
			get
			{
				return this.fontSize;
			}
			set
			{
				this.fontSize = value;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x0001413C File Offset: 0x0001233C
		public bool IsEmpty
		{
			get
			{
				return this.Equals(RtfHtmlStyle.Empty);
			}
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0001415C File Offset: 0x0001235C
		public sealed override bool Equals(object obj)
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

		// Token: 0x0600063C RID: 1596 RVA: 0x000141A4 File Offset: 0x000123A4
		public sealed override int GetHashCode()
		{
			return HashTool.AddHashCode(base.GetType().GetHashCode(), this.ComputeHashCode());
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x000141CC File Offset: 0x000123CC
		private bool IsEqual(object obj)
		{
			RtfHtmlStyle rtfHtmlStyle = obj as RtfHtmlStyle;
			return rtfHtmlStyle != null && string.Equals(this.foregroundColor, rtfHtmlStyle.foregroundColor) && string.Equals(this.backgroundColor, rtfHtmlStyle.backgroundColor) && string.Equals(this.fontFamily, rtfHtmlStyle.fontFamily) && string.Equals(this.fontSize, rtfHtmlStyle.fontSize);
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00014238 File Offset: 0x00012438
		private int ComputeHashCode()
		{
			int hash = this.foregroundColor.GetHashCode();
			hash = HashTool.AddHashCode(hash, this.backgroundColor);
			hash = HashTool.AddHashCode(hash, this.fontFamily);
			return HashTool.AddHashCode(hash, this.fontSize);
		}

		// Token: 0x04000245 RID: 581
		public static RtfHtmlStyle Empty = new RtfHtmlStyle();

		// Token: 0x04000246 RID: 582
		private string foregroundColor;

		// Token: 0x04000247 RID: 583
		private string backgroundColor;

		// Token: 0x04000248 RID: 584
		private string fontFamily;

		// Token: 0x04000249 RID: 585
		private string fontSize;
	}
}
