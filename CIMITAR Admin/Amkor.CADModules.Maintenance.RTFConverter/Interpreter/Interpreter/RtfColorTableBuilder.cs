using System;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x0200008B RID: 139
	public sealed class RtfColorTableBuilder : RtfElementVisitorBase
	{
		// Token: 0x0600045F RID: 1119 RVA: 0x0000C538 File Offset: 0x0000A738
		public RtfColorTableBuilder(RtfColorCollection colorTable) : base(RtfElementVisitorOrder.NonRecursive)
		{
			bool flag = colorTable == null;
			if (flag)
			{
				throw new ArgumentNullException("colorTable");
			}
			this.colorTable = colorTable;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0000C569 File Offset: 0x0000A769
		public void Reset()
		{
			this.colorTable.Clear();
			this.curRed = 0;
			this.curGreen = 0;
			this.curBlue = 0;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0000C590 File Offset: 0x0000A790
		protected override void DoVisitGroup(IRtfGroup group)
		{
			bool flag = "colortbl".Equals(group.Destination);
			if (flag)
			{
				base.VisitGroupChildren(group);
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0000C5BC File Offset: 0x0000A7BC
		protected override void DoVisitTag(IRtfTag tag)
		{
			string name = tag.Name;
			if (!(name == "red"))
			{
				if (!(name == "green"))
				{
					if (name == "blue")
					{
						this.curBlue = tag.ValueAsNumber;
					}
				}
				else
				{
					this.curGreen = tag.ValueAsNumber;
				}
			}
			else
			{
				this.curRed = tag.ValueAsNumber;
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000C624 File Offset: 0x0000A824
		protected override void DoVisitText(IRtfText text)
		{
			bool flag = ";".Equals(text.Text);
			if (flag)
			{
				this.colorTable.Add(new RtfColor(this.curRed, this.curGreen, this.curBlue));
				this.curRed = 0;
				this.curGreen = 0;
				this.curBlue = 0;
				return;
			}
			throw new RtfColorTableFormatException(Strings.ColorTableUnsupportedText(text.Text));
		}

		// Token: 0x04000193 RID: 403
		private readonly RtfColorCollection colorTable;

		// Token: 0x04000194 RID: 404
		private int curRed;

		// Token: 0x04000195 RID: 405
		private int curGreen;

		// Token: 0x04000196 RID: 406
		private int curBlue;
	}
}
