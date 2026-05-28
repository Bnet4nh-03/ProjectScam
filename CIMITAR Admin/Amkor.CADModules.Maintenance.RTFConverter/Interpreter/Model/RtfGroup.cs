using System;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000088 RID: 136
	public sealed class RtfGroup : RtfElement, IRtfGroup, IRtfElement
	{
		// Token: 0x06000444 RID: 1092 RVA: 0x0000BF17 File Offset: 0x0000A117
		public RtfGroup() : base(RtfElementKind.Group)
		{
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000BF30 File Offset: 0x0000A130
		public IRtfElementCollection Contents
		{
			get
			{
				return this.contents;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x0000BF48 File Offset: 0x0000A148
		public RtfElementCollection WritableContents
		{
			get
			{
				return this.contents;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x0000BF60 File Offset: 0x0000A160
		public string Destination
		{
			get
			{
				bool flag = this.contents.Count > 0;
				if (flag)
				{
					IRtfElement rtfElement = this.contents[0];
					bool flag2 = rtfElement.Kind == RtfElementKind.Tag;
					if (flag2)
					{
						IRtfTag rtfTag = (IRtfTag)rtfElement;
						bool flag3 = "*".Equals(rtfTag.Name);
						if (flag3)
						{
							bool flag4 = this.contents.Count > 1;
							if (flag4)
							{
								IRtfElement rtfElement2 = this.contents[1];
								bool flag5 = rtfElement2.Kind == RtfElementKind.Tag;
								if (flag5)
								{
									IRtfTag rtfTag2 = (IRtfTag)rtfElement2;
									return rtfTag2.Name;
								}
							}
						}
						return rtfTag.Name;
					}
				}
				return null;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x0000C01C File Offset: 0x0000A21C
		public bool IsExtensionDestination
		{
			get
			{
				bool flag = this.contents.Count > 0;
				if (flag)
				{
					IRtfElement rtfElement = this.contents[0];
					bool flag2 = rtfElement.Kind == RtfElementKind.Tag;
					if (flag2)
					{
						IRtfTag rtfTag = (IRtfTag)rtfElement;
						bool flag3 = "*".Equals(rtfTag.Name);
						if (flag3)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0000C084 File Offset: 0x0000A284
		public IRtfGroup SelectChildGroupWithDestination(string destination)
		{
			bool flag = destination == null;
			if (flag)
			{
				throw new ArgumentNullException("destination");
			}
			foreach (object obj in this.contents)
			{
				IRtfElement rtfElement = (IRtfElement)obj;
				bool flag2 = rtfElement.Kind == RtfElementKind.Group;
				if (flag2)
				{
					IRtfGroup rtfGroup = (IRtfGroup)rtfElement;
					bool flag3 = destination.Equals(rtfGroup.Destination);
					if (flag3)
					{
						return rtfGroup;
					}
				}
			}
			return null;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0000C12C File Offset: 0x0000A32C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("{");
			int count = this.contents.Count;
			stringBuilder.Append(count);
			stringBuilder.Append(" items");
			bool flag = count > 0;
			if (flag)
			{
				stringBuilder.Append(": [");
				stringBuilder.Append(this.contents[0]);
				bool flag2 = count > 1;
				if (flag2)
				{
					stringBuilder.Append(", ");
					stringBuilder.Append(this.contents[1]);
					bool flag3 = count > 2;
					if (flag3)
					{
						stringBuilder.Append(", ");
						bool flag4 = count > 3;
						if (flag4)
						{
							stringBuilder.Append("..., ");
						}
						stringBuilder.Append(this.contents[count - 1]);
					}
				}
				stringBuilder.Append("]");
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0000C223 File Offset: 0x0000A423
		protected override void DoVisit(IRtfElementVisitor visitor)
		{
			visitor.VisitGroup(this);
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0000C230 File Offset: 0x0000A430
		protected override bool IsEqual(object obj)
		{
			RtfGroup rtfGroup = obj as RtfGroup;
			return rtfGroup != null && base.IsEqual(obj) && this.contents.Equals(rtfGroup.contents);
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0000C26C File Offset: 0x0000A46C
		protected override int ComputeHashCode()
		{
			return HashTool.AddHashCode(base.ComputeHashCode(), this.contents);
		}

		// Token: 0x0400018D RID: 397
		private readonly RtfElementCollection contents = new RtfElementCollection();
	}
}
