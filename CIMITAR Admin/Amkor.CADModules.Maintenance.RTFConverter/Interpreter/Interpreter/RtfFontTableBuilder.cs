using System;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x0200008E RID: 142
	public sealed class RtfFontTableBuilder : RtfElementVisitorBase
	{
		// Token: 0x06000477 RID: 1143 RVA: 0x0000D410 File Offset: 0x0000B610
		public RtfFontTableBuilder(RtfFontCollection fontTable, bool ignoreDuplicatedFonts = false) : base(RtfElementVisitorOrder.NonRecursive)
		{
			bool flag = fontTable == null;
			if (flag)
			{
				throw new ArgumentNullException("fontTable");
			}
			this.fontTable = fontTable;
			this.ignoreDuplicatedFonts = ignoreDuplicatedFonts;
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x0000D454 File Offset: 0x0000B654
		public bool IgnoreDuplicatedFonts
		{
			get
			{
				return this.ignoreDuplicatedFonts;
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000D46C File Offset: 0x0000B66C
		public void Reset()
		{
			this.fontTable.Clear();
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0000D47C File Offset: 0x0000B67C
		protected override void DoVisitGroup(IRtfGroup group)
		{
			string destination = group.Destination;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(destination);
			if (num <= 1835979141U)
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
						if (num != 1835979141U)
						{
							return;
						}
						if (!(destination == "flomajor"))
						{
							return;
						}
					}
					else if (!(destination == "fdbminor"))
					{
						return;
					}
				}
				else if (!(destination == "flominor"))
				{
					return;
				}
			}
			else if (num <= 2466964733U)
			{
				if (num != 2134103081U)
				{
					if (num != 2466964733U)
					{
						return;
					}
					if (!(destination == "fbimajor"))
					{
						return;
					}
				}
				else if (!(destination == "fbiminor"))
				{
					return;
				}
			}
			else if (num != 3003421458U)
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
			else
			{
				if (!(destination == "fonttbl"))
				{
					return;
				}
				bool flag = group.Contents.Count > 1;
				if (flag)
				{
					bool flag2 = group.Contents[1].Kind == RtfElementKind.Group;
					if (flag2)
					{
						base.VisitGroupChildren(group);
					}
					else
					{
						int count = group.Contents.Count;
						this.fontBuilder.Reset();
						for (int i = 1; i < count; i++)
						{
							group.Contents[i].Visit(this.fontBuilder);
							bool flag3 = this.fontBuilder.FontName != null;
							if (flag3)
							{
								this.AddCurrentFont();
								this.fontBuilder.Reset();
							}
						}
					}
				}
				return;
			}
			this.BuildFontFromGroup(group);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0000D6B2 File Offset: 0x0000B8B2
		private void BuildFontFromGroup(IRtfGroup group)
		{
			this.fontBuilder.Reset();
			this.fontBuilder.VisitGroup(group);
			this.AddCurrentFont();
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000D6D8 File Offset: 0x0000B8D8
		private void AddCurrentFont()
		{
			bool flag = !this.fontTable.ContainsFontWithId(this.fontBuilder.FontId);
			if (flag)
			{
				this.fontTable.Add(this.fontBuilder.CreateFont());
			}
			else
			{
				bool flag2 = !this.IgnoreDuplicatedFonts;
				if (flag2)
				{
					throw new RtfFontTableFormatException(Strings.DuplicateFont(this.fontBuilder.FontId));
				}
			}
		}

		// Token: 0x040001A1 RID: 417
		private readonly RtfFontBuilder fontBuilder = new RtfFontBuilder();

		// Token: 0x040001A2 RID: 418
		private readonly RtfFontCollection fontTable;

		// Token: 0x040001A3 RID: 419
		private readonly bool ignoreDuplicatedFonts;
	}
}
