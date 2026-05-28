using System;
using System.Globalization;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000089 RID: 137
	public sealed class RtfTag : RtfElement, IRtfTag, IRtfElement
	{
		// Token: 0x0600044E RID: 1102 RVA: 0x0000C290 File Offset: 0x0000A490
		public RtfTag(string name) : base(RtfElementKind.Tag)
		{
			bool flag = name == null;
			if (flag)
			{
				throw new ArgumentNullException("name");
			}
			this.fullName = name;
			this.name = name;
			this.valueAsText = null;
			this.valueAsNumber = -1;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0000C2D8 File Offset: 0x0000A4D8
		public RtfTag(string name, string value) : base(RtfElementKind.Tag)
		{
			bool flag = name == null;
			if (flag)
			{
				throw new ArgumentNullException("name");
			}
			bool flag2 = value == null;
			if (flag2)
			{
				throw new ArgumentNullException("value");
			}
			this.fullName = name + value;
			this.name = name;
			this.valueAsText = value;
			int num;
			bool flag3 = int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out num);
			if (flag3)
			{
				this.valueAsNumber = num;
			}
			else
			{
				this.valueAsNumber = -1;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x0000C358 File Offset: 0x0000A558
		public string FullName
		{
			get
			{
				return this.fullName;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x0000C370 File Offset: 0x0000A570
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x0000C388 File Offset: 0x0000A588
		public bool HasValue
		{
			get
			{
				return this.valueAsText != null;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0000C3A4 File Offset: 0x0000A5A4
		public string ValueAsText
		{
			get
			{
				return this.valueAsText;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x0000C3BC File Offset: 0x0000A5BC
		public int ValueAsNumber
		{
			get
			{
				return this.valueAsNumber;
			}
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0000C3D4 File Offset: 0x0000A5D4
		public override string ToString()
		{
			return "\\" + this.fullName;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0000C3F6 File Offset: 0x0000A5F6
		protected override void DoVisit(IRtfElementVisitor visitor)
		{
			visitor.VisitTag(this);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0000C404 File Offset: 0x0000A604
		protected override bool IsEqual(object obj)
		{
			RtfTag rtfTag = obj as RtfTag;
			return rtfTag != null && base.IsEqual(obj) && this.fullName.Equals(rtfTag.fullName);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0000C440 File Offset: 0x0000A640
		protected override int ComputeHashCode()
		{
			int hash = base.ComputeHashCode();
			return HashTool.AddHashCode(hash, this.fullName);
		}

		// Token: 0x0400018E RID: 398
		private readonly string fullName;

		// Token: 0x0400018F RID: 399
		private readonly string name;

		// Token: 0x04000190 RID: 400
		private readonly string valueAsText;

		// Token: 0x04000191 RID: 401
		private readonly int valueAsNumber;
	}
}
