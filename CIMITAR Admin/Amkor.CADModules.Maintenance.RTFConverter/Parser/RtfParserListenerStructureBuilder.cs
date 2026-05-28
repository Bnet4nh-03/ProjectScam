using System;
using System.Collections;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;

namespace Amkor.CADModules.Maintenance.RTFConverter.Parser
{
	// Token: 0x0200006D RID: 109
	public sealed class RtfParserListenerStructureBuilder : RtfParserListenerBase
	{
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000312 RID: 786 RVA: 0x00008D3C File Offset: 0x00006F3C
		public IRtfGroup StructureRoot
		{
			get
			{
				return this.structureRoot;
			}
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00008D54 File Offset: 0x00006F54
		protected override void DoParseBegin()
		{
			this.openGroupStack.Clear();
			this.curGroup = null;
			this.structureRoot = null;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00008D74 File Offset: 0x00006F74
		protected override void DoGroupBegin()
		{
			RtfGroup item = new RtfGroup();
			bool flag = this.curGroup != null;
			if (flag)
			{
				this.openGroupStack.Push(this.curGroup);
				this.curGroup.WritableContents.Add(item);
			}
			this.curGroup = item;
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00008DC4 File Offset: 0x00006FC4
		protected override void DoTagFound(IRtfTag tag)
		{
			bool flag = this.curGroup == null;
			if (flag)
			{
				throw new RtfStructureException(Strings.MissingGroupForNewTag);
			}
			this.curGroup.WritableContents.Add(tag);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00008E00 File Offset: 0x00007000
		protected override void DoTextFound(IRtfText text)
		{
			bool flag = this.curGroup == null;
			if (flag)
			{
				throw new RtfStructureException(Strings.MissingGroupForNewText);
			}
			this.curGroup.WritableContents.Add(text);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00008E3C File Offset: 0x0000703C
		protected override void DoGroupEnd()
		{
			bool flag = this.openGroupStack.Count > 0;
			if (flag)
			{
				this.curGroup = (RtfGroup)this.openGroupStack.Pop();
			}
			else
			{
				bool flag2 = this.structureRoot != null;
				if (flag2)
				{
					throw new RtfStructureException(Strings.MultipleRootLevelGroups);
				}
				this.structureRoot = this.curGroup;
				this.curGroup = null;
			}
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00008EA4 File Offset: 0x000070A4
		protected override void DoParseEnd()
		{
			bool flag = this.openGroupStack.Count > 0;
			if (flag)
			{
				throw new RtfBraceNestingException(Strings.UnclosedGroups);
			}
		}

		// Token: 0x0400012B RID: 299
		private readonly Stack openGroupStack = new Stack();

		// Token: 0x0400012C RID: 300
		private RtfGroup curGroup;

		// Token: 0x0400012D RID: 301
		private RtfGroup structureRoot;
	}
}
