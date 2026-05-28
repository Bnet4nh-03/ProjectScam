using System;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x0200007B RID: 123
	public sealed class RtfFont : IRtfFont
	{
		// Token: 0x060003BF RID: 959 RVA: 0x0000A404 File Offset: 0x00008604
		public RtfFont(string id, RtfFontKind kind, RtfFontPitch pitch, int charSet, int codePage, string name)
		{
			bool flag = id == null;
			if (flag)
			{
				throw new ArgumentNullException("id");
			}
			bool flag2 = charSet < 0;
			if (flag2)
			{
				throw new ArgumentException(Strings.InvalidCharacterSet(charSet));
			}
			bool flag3 = codePage < 0;
			if (flag3)
			{
				throw new ArgumentException(Strings.InvalidCodePage(codePage));
			}
			bool flag4 = name == null;
			if (flag4)
			{
				throw new ArgumentNullException("name");
			}
			this.id = id;
			this.kind = kind;
			this.pitch = pitch;
			this.charSet = charSet;
			this.codePage = codePage;
			this.name = name;
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0000A4A0 File Offset: 0x000086A0
		public string Id
		{
			get
			{
				return this.id;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0000A4B8 File Offset: 0x000086B8
		public RtfFontKind Kind
		{
			get
			{
				return this.kind;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x0000A4D0 File Offset: 0x000086D0
		public RtfFontPitch Pitch
		{
			get
			{
				return this.pitch;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000A4E8 File Offset: 0x000086E8
		public int CharSet
		{
			get
			{
				return this.charSet;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x0000A500 File Offset: 0x00008700
		public int CodePage
		{
			get
			{
				bool flag = this.codePage == 0;
				int result;
				if (flag)
				{
					result = RtfSpec.GetCodePage(this.charSet);
				}
				else
				{
					result = this.codePage;
				}
				return result;
			}
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0000A534 File Offset: 0x00008734
		public Encoding GetEncoding()
		{
			return Encoding.GetEncoding(this.CodePage);
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000A554 File Offset: 0x00008754
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000A56C File Offset: 0x0000876C
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

		// Token: 0x060003C8 RID: 968 RVA: 0x0000A5B4 File Offset: 0x000087B4
		public override int GetHashCode()
		{
			return HashTool.AddHashCode(base.GetType().GetHashCode(), this.ComputeHashCode());
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000A5DC File Offset: 0x000087DC
		public override string ToString()
		{
			return this.id + ":" + this.name;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000A604 File Offset: 0x00008804
		private bool IsEqual(object obj)
		{
			RtfFont rtfFont = obj as RtfFont;
			return rtfFont != null && this.id.Equals(rtfFont.id) && this.kind == rtfFont.kind && this.pitch == rtfFont.pitch && this.charSet == rtfFont.charSet && this.codePage == rtfFont.codePage && this.name.Equals(rtfFont.name);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000A680 File Offset: 0x00008880
		private int ComputeHashCode()
		{
			int hash = this.id.GetHashCode();
			hash = HashTool.AddHashCode(hash, this.kind);
			hash = HashTool.AddHashCode(hash, this.pitch);
			hash = HashTool.AddHashCode(hash, this.charSet);
			hash = HashTool.AddHashCode(hash, this.codePage);
			return HashTool.AddHashCode(hash, this.name);
		}

		// Token: 0x0400016B RID: 363
		private readonly string id;

		// Token: 0x0400016C RID: 364
		private readonly RtfFontKind kind;

		// Token: 0x0400016D RID: 365
		private readonly RtfFontPitch pitch;

		// Token: 0x0400016E RID: 366
		private readonly int charSet;

		// Token: 0x0400016F RID: 367
		private readonly int codePage;

		// Token: 0x04000170 RID: 368
		private readonly string name;
	}
}
