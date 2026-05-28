using System;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x0200007D RID: 125
	public sealed class RtfTextFormat : IRtfTextFormat
	{
		// Token: 0x060003D3 RID: 979 RVA: 0x0000A7C8 File Offset: 0x000089C8
		public RtfTextFormat(IRtfFont font, int fontSize)
		{
			bool flag = font == null;
			if (flag)
			{
				throw new ArgumentNullException("font");
			}
			bool flag2 = fontSize <= 0 || fontSize > 65535;
			if (flag2)
			{
				throw new ArgumentException(Strings.FontSizeOutOfRange(fontSize));
			}
			this.font = font;
			this.fontSize = fontSize;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000A83C File Offset: 0x00008A3C
		public RtfTextFormat(IRtfTextFormat copy)
		{
			bool flag = copy == null;
			if (flag)
			{
				throw new ArgumentNullException("copy");
			}
			this.font = copy.Font;
			this.fontSize = copy.FontSize;
			this.superScript = copy.SuperScript;
			this.bold = copy.IsBold;
			this.italic = copy.IsItalic;
			this.underline = copy.IsUnderline;
			this.strikeThrough = copy.IsStrikeThrough;
			this.hidden = copy.IsHidden;
			this.backgroundColor = copy.BackgroundColor;
			this.foregroundColor = copy.ForegroundColor;
			this.alignment = copy.Alignment;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000A908 File Offset: 0x00008B08
		public RtfTextFormat(RtfTextFormat copy)
		{
			bool flag = copy == null;
			if (flag)
			{
				throw new ArgumentNullException("copy");
			}
			this.font = copy.font;
			this.fontSize = copy.fontSize;
			this.superScript = copy.superScript;
			this.bold = copy.bold;
			this.italic = copy.italic;
			this.underline = copy.underline;
			this.strikeThrough = copy.strikeThrough;
			this.hidden = copy.hidden;
			this.backgroundColor = copy.backgroundColor;
			this.foregroundColor = copy.foregroundColor;
			this.alignment = copy.alignment;
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x0000A9D4 File Offset: 0x00008BD4
		public string FontDescriptionDebug
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(this.font.Name);
				stringBuilder.Append(", ");
				stringBuilder.Append(this.fontSize);
				stringBuilder.Append((this.superScript >= 0) ? "+" : "");
				stringBuilder.Append(this.superScript);
				stringBuilder.Append(", ");
				bool flag = this.bold || this.italic || this.underline || this.strikeThrough;
				if (flag)
				{
					bool flag2 = false;
					bool flag3 = this.bold;
					if (flag3)
					{
						stringBuilder.Append("bold");
						flag2 = true;
					}
					bool flag4 = this.italic;
					if (flag4)
					{
						stringBuilder.Append(flag2 ? "+italic" : "italic");
						flag2 = true;
					}
					bool flag5 = this.underline;
					if (flag5)
					{
						stringBuilder.Append(flag2 ? "+underline" : "underline");
						flag2 = true;
					}
					bool flag6 = this.strikeThrough;
					if (flag6)
					{
						stringBuilder.Append(flag2 ? "+strikethrough" : "strikethrough");
					}
				}
				else
				{
					stringBuilder.Append("plain");
				}
				bool flag7 = this.hidden;
				if (flag7)
				{
					stringBuilder.Append(", hidden");
				}
				return stringBuilder.ToString();
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x0000AB30 File Offset: 0x00008D30
		public IRtfFont Font
		{
			get
			{
				return this.font;
			}
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000AB48 File Offset: 0x00008D48
		public RtfTextFormat DeriveWithFont(IRtfFont rtfFont)
		{
			bool flag = rtfFont == null;
			if (flag)
			{
				throw new ArgumentNullException("rtfFont");
			}
			bool flag2 = this.font.Equals(rtfFont);
			RtfTextFormat result;
			if (flag2)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					font = rtfFont
				};
			}
			return result;
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x0000AB94 File Offset: 0x00008D94
		public int FontSize
		{
			get
			{
				return this.fontSize;
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000ABAC File Offset: 0x00008DAC
		public RtfTextFormat DeriveWithFontSize(int derivedFontSize)
		{
			bool flag = derivedFontSize < 0 || derivedFontSize > 65535;
			if (flag)
			{
				throw new ArgumentException(Strings.FontSizeOutOfRange(derivedFontSize));
			}
			bool flag2 = this.fontSize == derivedFontSize;
			RtfTextFormat result;
			if (flag2)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					fontSize = derivedFontSize
				};
			}
			return result;
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060003DB RID: 987 RVA: 0x0000AC00 File Offset: 0x00008E00
		public int SuperScript
		{
			get
			{
				return this.superScript;
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000AC18 File Offset: 0x00008E18
		public RtfTextFormat DeriveWithSuperScript(int deviation)
		{
			bool flag = this.superScript == deviation;
			RtfTextFormat result;
			if (flag)
			{
				result = this;
			}
			else
			{
				RtfTextFormat rtfTextFormat = new RtfTextFormat(this);
				rtfTextFormat.superScript = deviation;
				bool flag2 = deviation == 0;
				if (flag2)
				{
					rtfTextFormat.fontSize = this.fontSize / 2 * 3;
				}
				result = rtfTextFormat;
			}
			return result;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000AC68 File Offset: 0x00008E68
		public RtfTextFormat DeriveWithSuperScript(bool super)
		{
			return new RtfTextFormat(this)
			{
				fontSize = Math.Max(1, this.fontSize * 2 / 3),
				superScript = (super ? 1 : -1) * Math.Max(1, this.fontSize / 2)
			};
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060003DE RID: 990 RVA: 0x0000ACB4 File Offset: 0x00008EB4
		public bool IsNormal
		{
			get
			{
				return !this.bold && !this.italic && !this.underline && !this.strikeThrough && !this.hidden && this.fontSize == 24 && this.superScript == 0 && RtfColor.Black.Equals(this.foregroundColor) && RtfColor.White.Equals(this.backgroundColor);
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000AD28 File Offset: 0x00008F28
		public RtfTextFormat DeriveNormal()
		{
			bool isNormal = this.IsNormal;
			RtfTextFormat result;
			if (isNormal)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this.font, 24)
				{
					alignment = this.alignment
				};
			}
			return result;
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x0000AD64 File Offset: 0x00008F64
		public bool IsBold
		{
			get
			{
				return this.bold;
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000AD7C File Offset: 0x00008F7C
		public RtfTextFormat DeriveWithBold(bool derivedBold)
		{
			bool flag = this.bold == derivedBold;
			RtfTextFormat result;
			if (flag)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					bold = derivedBold
				};
			}
			return result;
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x0000ADB0 File Offset: 0x00008FB0
		public bool IsItalic
		{
			get
			{
				return this.italic;
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000ADC8 File Offset: 0x00008FC8
		public RtfTextFormat DeriveWithItalic(bool derivedItalic)
		{
			bool flag = this.italic == derivedItalic;
			RtfTextFormat result;
			if (flag)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					italic = derivedItalic
				};
			}
			return result;
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x0000ADFC File Offset: 0x00008FFC
		public bool IsUnderline
		{
			get
			{
				return this.underline;
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0000AE14 File Offset: 0x00009014
		public RtfTextFormat DeriveWithUnderline(bool derivedUnderline)
		{
			bool flag = this.underline == derivedUnderline;
			RtfTextFormat result;
			if (flag)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					underline = derivedUnderline
				};
			}
			return result;
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x0000AE48 File Offset: 0x00009048
		public bool IsStrikeThrough
		{
			get
			{
				return this.strikeThrough;
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000AE60 File Offset: 0x00009060
		public RtfTextFormat DeriveWithStrikeThrough(bool derivedStrikeThrough)
		{
			bool flag = this.strikeThrough == derivedStrikeThrough;
			RtfTextFormat result;
			if (flag)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					strikeThrough = derivedStrikeThrough
				};
			}
			return result;
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x0000AE94 File Offset: 0x00009094
		public bool IsHidden
		{
			get
			{
				return this.hidden;
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000AEAC File Offset: 0x000090AC
		public RtfTextFormat DeriveWithHidden(bool derivedHidden)
		{
			bool flag = this.hidden == derivedHidden;
			RtfTextFormat result;
			if (flag)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					hidden = derivedHidden
				};
			}
			return result;
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0000AEE0 File Offset: 0x000090E0
		public IRtfColor BackgroundColor
		{
			get
			{
				return this.backgroundColor;
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000AEF8 File Offset: 0x000090F8
		public RtfTextFormat DeriveWithBackgroundColor(IRtfColor derivedBackgroundColor)
		{
			bool flag = derivedBackgroundColor == null;
			if (flag)
			{
				throw new ArgumentNullException("derivedBackgroundColor");
			}
			bool flag2 = this.backgroundColor.Equals(derivedBackgroundColor);
			RtfTextFormat result;
			if (flag2)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					backgroundColor = derivedBackgroundColor
				};
			}
			return result;
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x0000AF44 File Offset: 0x00009144
		public IRtfColor ForegroundColor
		{
			get
			{
				return this.foregroundColor;
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0000AF5C File Offset: 0x0000915C
		public RtfTextFormat DeriveWithForegroundColor(IRtfColor derivedForegroundColor)
		{
			bool flag = derivedForegroundColor == null;
			if (flag)
			{
				throw new ArgumentNullException("derivedForegroundColor");
			}
			bool flag2 = this.foregroundColor.Equals(derivedForegroundColor);
			RtfTextFormat result;
			if (flag2)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					foregroundColor = derivedForegroundColor
				};
			}
			return result;
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x0000AFA8 File Offset: 0x000091A8
		public RtfTextAlignment Alignment
		{
			get
			{
				return this.alignment;
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000AFC0 File Offset: 0x000091C0
		public RtfTextFormat DeriveWithAlignment(RtfTextAlignment derivedAlignment)
		{
			bool flag = this.alignment == derivedAlignment;
			RtfTextFormat result;
			if (flag)
			{
				result = this;
			}
			else
			{
				result = new RtfTextFormat(this)
				{
					alignment = derivedAlignment
				};
			}
			return result;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000AFF4 File Offset: 0x000091F4
		IRtfTextFormat IRtfTextFormat.Duplicate()
		{
			return new RtfTextFormat(this);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0000B00C File Offset: 0x0000920C
		public RtfTextFormat Duplicate()
		{
			return new RtfTextFormat(this);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000B024 File Offset: 0x00009224
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

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000B06C File Offset: 0x0000926C
		public override int GetHashCode()
		{
			return HashTool.AddHashCode(base.GetType().GetHashCode(), this.ComputeHashCode());
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000B094 File Offset: 0x00009294
		private bool IsEqual(object obj)
		{
			RtfTextFormat rtfTextFormat = obj as RtfTextFormat;
			return rtfTextFormat != null && this.font.Equals(rtfTextFormat.font) && this.fontSize == rtfTextFormat.fontSize && this.superScript == rtfTextFormat.superScript && this.bold == rtfTextFormat.bold && this.italic == rtfTextFormat.italic && this.underline == rtfTextFormat.underline && this.strikeThrough == rtfTextFormat.strikeThrough && this.hidden == rtfTextFormat.hidden && this.backgroundColor.Equals(rtfTextFormat.backgroundColor) && this.foregroundColor.Equals(rtfTextFormat.foregroundColor) && this.alignment == rtfTextFormat.alignment;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000B168 File Offset: 0x00009368
		private int ComputeHashCode()
		{
			int hash = this.font.GetHashCode();
			hash = HashTool.AddHashCode(hash, this.fontSize);
			hash = HashTool.AddHashCode(hash, this.superScript);
			hash = HashTool.AddHashCode(hash, this.bold);
			hash = HashTool.AddHashCode(hash, this.italic);
			hash = HashTool.AddHashCode(hash, this.underline);
			hash = HashTool.AddHashCode(hash, this.strikeThrough);
			hash = HashTool.AddHashCode(hash, this.hidden);
			hash = HashTool.AddHashCode(hash, this.backgroundColor);
			hash = HashTool.AddHashCode(hash, this.foregroundColor);
			return HashTool.AddHashCode(hash, this.alignment);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000B228 File Offset: 0x00009428
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("Font ");
			stringBuilder.Append(this.FontDescriptionDebug);
			stringBuilder.Append(", ");
			stringBuilder.Append(this.alignment);
			stringBuilder.Append(", ");
			stringBuilder.Append(this.foregroundColor.ToString());
			stringBuilder.Append(" on ");
			stringBuilder.Append(this.backgroundColor.ToString());
			return stringBuilder.ToString();
		}

		// Token: 0x04000172 RID: 370
		private IRtfFont font;

		// Token: 0x04000173 RID: 371
		private int fontSize;

		// Token: 0x04000174 RID: 372
		private int superScript;

		// Token: 0x04000175 RID: 373
		private bool bold;

		// Token: 0x04000176 RID: 374
		private bool italic;

		// Token: 0x04000177 RID: 375
		private bool underline;

		// Token: 0x04000178 RID: 376
		private bool strikeThrough;

		// Token: 0x04000179 RID: 377
		private bool hidden;

		// Token: 0x0400017A RID: 378
		private IRtfColor backgroundColor = RtfColor.White;

		// Token: 0x0400017B RID: 379
		private IRtfColor foregroundColor = RtfColor.Black;

		// Token: 0x0400017C RID: 380
		private RtfTextAlignment alignment = RtfTextAlignment.Left;
	}
}
