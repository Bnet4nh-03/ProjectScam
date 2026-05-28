using System;
using System.Text;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x0200008D RID: 141
	public sealed class RtfFontBuilder : RtfElementVisitorBase
	{
		// Token: 0x0600046A RID: 1130 RVA: 0x0000CD26 File Offset: 0x0000AF26
		public RtfFontBuilder() : base(RtfElementVisitorOrder.NonRecursive)
		{
			this.Reset();
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x0000CD44 File Offset: 0x0000AF44
		public string FontId
		{
			get
			{
				return this.fontId;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x0000CD5C File Offset: 0x0000AF5C
		public int FontIndex
		{
			get
			{
				return this.fontIndex;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x0000CD74 File Offset: 0x0000AF74
		public int FontCharset
		{
			get
			{
				return this.fontCharset;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x0000CD8C File Offset: 0x0000AF8C
		public int FontCodePage
		{
			get
			{
				return this.fontCodePage;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x0000CDA4 File Offset: 0x0000AFA4
		public RtfFontKind FontKind
		{
			get
			{
				return this.fontKind;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x0000CDBC File Offset: 0x0000AFBC
		public RtfFontPitch FontPitch
		{
			get
			{
				return this.fontPitch;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x0000CDD4 File Offset: 0x0000AFD4
		public string FontName
		{
			get
			{
				string text = null;
				int length = this.fontNameBuffer.Length;
				bool flag = length > 0 && this.fontNameBuffer[length - 1] == ';';
				if (flag)
				{
					text = this.fontNameBuffer.ToString().Substring(0, length - 1).Trim();
					bool flag2 = text.Length == 0;
					if (flag2)
					{
						text = null;
					}
				}
				return text;
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0000CE44 File Offset: 0x0000B044
		public IRtfFont CreateFont()
		{
			string text = this.FontName;
			bool flag = string.IsNullOrEmpty(text);
			if (flag)
			{
				text = "UnnamedFont_" + this.fontId;
			}
			return new RtfFont(this.fontId, this.fontKind, this.fontPitch, this.fontCharset, this.fontCodePage, text);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0000CE9E File Offset: 0x0000B09E
		public void Reset()
		{
			this.fontIndex = 0;
			this.fontCharset = 0;
			this.fontCodePage = 0;
			this.fontKind = RtfFontKind.Nil;
			this.fontPitch = RtfFontPitch.Default;
			this.fontNameBuffer.Remove(0, this.fontNameBuffer.Length);
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0000CEDC File Offset: 0x0000B0DC
		protected override void DoVisitGroup(IRtfGroup group)
		{
			string destination = group.Destination;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(destination);
			if (num <= 875660080U)
			{
				if (num <= 644779004U)
				{
					if (num != 596946891U)
					{
						if (num != 644779004U)
						{
							return;
						}
						if (!(destination == "fdbmajor"))
						{
							return;
						}
					}
					else if (!(destination == "fhimajor"))
					{
						return;
					}
				}
				else if (num != 747407905U)
				{
					if (num != 875660080U)
					{
						return;
					}
					if (!(destination == "fdbminor"))
					{
						return;
					}
				}
				else if (!(destination == "flominor"))
				{
					return;
				}
			}
			else if (num <= 2134103081U)
			{
				if (num != 1835979141U)
				{
					if (num != 2134103081U)
					{
						return;
					}
					if (!(destination == "fbiminor"))
					{
						return;
					}
				}
				else if (!(destination == "flomajor"))
				{
					return;
				}
			}
			else if (num != 2466964733U)
			{
				if (num != 3672565719U)
				{
					if (num != 3809224601U)
					{
						return;
					}
					if (!(destination == "f"))
					{
						return;
					}
				}
				else if (!(destination == "fhiminor"))
				{
					return;
				}
			}
			else if (!(destination == "fbimajor"))
			{
				return;
			}
			base.VisitGroupChildren(group);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0000D01C File Offset: 0x0000B21C
		protected override void DoVisitTag(IRtfTag tag)
		{
			string name = tag.Name;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			if (num <= 2134103081U)
			{
				if (num <= 878424022U)
				{
					if (num <= 644779004U)
					{
						if (num != 596946891U)
						{
							if (num == 644779004U)
							{
								if (!(name == "fdbmajor"))
								{
								}
							}
						}
						else if (!(name == "fhimajor"))
						{
						}
					}
					else if (num != 747407905U)
					{
						if (num != 875660080U)
						{
							if (num == 878424022U)
							{
								if (name == "fscript")
								{
									this.fontKind = RtfFontKind.Script;
								}
							}
						}
						else if (!(name == "fdbminor"))
						{
						}
					}
					else if (!(name == "flominor"))
					{
					}
				}
				else if (num <= 1265622565U)
				{
					if (num != 1158515092U)
					{
						if (num == 1265622565U)
						{
							if (name == "ftech")
							{
								this.fontKind = RtfFontKind.Tech;
							}
						}
					}
					else if (name == "fswiss")
					{
						this.fontKind = RtfFontKind.Swiss;
					}
				}
				else if (num != 1835979141U)
				{
					if (num != 1990774951U)
					{
						if (num == 2134103081U)
						{
							if (!(name == "fbiminor"))
							{
							}
						}
					}
					else if (name == "fbidi")
					{
						this.fontKind = RtfFontKind.Bidi;
					}
				}
				else if (!(name == "flomajor"))
				{
				}
			}
			else if (num <= 2963347582U)
			{
				if (num <= 2466964733U)
				{
					if (num != 2365460039U)
					{
						if (num == 2466964733U)
						{
							if (!(name == "fbimajor"))
							{
							}
						}
					}
					else if (name == "fcharset")
					{
						this.fontCharset = tag.ValueAsNumber;
					}
				}
				else if (num != 2657895686U)
				{
					if (num != 2888623432U)
					{
						if (num == 2963347582U)
						{
							if (name == "fprq")
							{
								switch (tag.ValueAsNumber)
								{
								case 0:
									this.fontPitch = RtfFontPitch.Default;
									break;
								case 1:
									this.fontPitch = RtfFontPitch.Fixed;
									break;
								case 2:
									this.fontPitch = RtfFontPitch.Variable;
									break;
								}
							}
						}
					}
					else if (name == "fnil")
					{
						this.fontKind = RtfFontKind.Nil;
					}
				}
				else if (name == "fmodern")
				{
					this.fontKind = RtfFontKind.Modern;
				}
			}
			else if (num <= 3809224601U)
			{
				if (num != 3672565719U)
				{
					if (num == 3809224601U)
					{
						if (name == "f")
						{
							this.fontId = tag.FullName;
							this.fontIndex = tag.ValueAsNumber;
						}
					}
				}
				else if (!(name == "fhiminor"))
				{
				}
			}
			else if (num != 3880443187U)
			{
				if (num != 3985183974U)
				{
					if (num == 4000999766U)
					{
						if (name == "froman")
						{
							this.fontKind = RtfFontKind.Roman;
						}
					}
				}
				else if (name == "fdecor")
				{
					this.fontKind = RtfFontKind.Decor;
				}
			}
			else if (name == "cpg")
			{
				this.fontCodePage = tag.ValueAsNumber;
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0000D3FA File Offset: 0x0000B5FA
		protected override void DoVisitText(IRtfText text)
		{
			this.fontNameBuffer.Append(text.Text);
		}

		// Token: 0x0400019A RID: 410
		private string fontId;

		// Token: 0x0400019B RID: 411
		private int fontIndex;

		// Token: 0x0400019C RID: 412
		private int fontCharset;

		// Token: 0x0400019D RID: 413
		private int fontCodePage;

		// Token: 0x0400019E RID: 414
		private RtfFontKind fontKind;

		// Token: 0x0400019F RID: 415
		private RtfFontPitch fontPitch;

		// Token: 0x040001A0 RID: 416
		private readonly StringBuilder fontNameBuffer = new StringBuilder();
	}
}
