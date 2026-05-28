using System;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000079 RID: 121
	public sealed class RtfDocumentProperty : IRtfDocumentProperty
	{
		// Token: 0x060003AD RID: 941 RVA: 0x0000A03F File Offset: 0x0000823F
		public RtfDocumentProperty(int propertyKindCode, string name, string staticValue) : this(propertyKindCode, name, staticValue, null)
		{
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000A050 File Offset: 0x00008250
		public RtfDocumentProperty(int propertyKindCode, string name, string staticValue, string linkValue)
		{
			bool flag = name == null;
			if (flag)
			{
				throw new ArgumentNullException("name");
			}
			bool flag2 = staticValue == null;
			if (flag2)
			{
				throw new ArgumentNullException("staticValue");
			}
			this.propertyKindCode = propertyKindCode;
			if (propertyKindCode <= 5)
			{
				if (propertyKindCode == 3)
				{
					this.propertyKind = RtfPropertyKind.IntegerNumber;
					goto IL_94;
				}
				if (propertyKindCode == 5)
				{
					this.propertyKind = RtfPropertyKind.RealNumber;
					goto IL_94;
				}
			}
			else
			{
				if (propertyKindCode == 11)
				{
					this.propertyKind = RtfPropertyKind.Boolean;
					goto IL_94;
				}
				if (propertyKindCode == 30)
				{
					this.propertyKind = RtfPropertyKind.Text;
					goto IL_94;
				}
				if (propertyKindCode == 64)
				{
					this.propertyKind = RtfPropertyKind.Date;
					goto IL_94;
				}
			}
			this.propertyKind = RtfPropertyKind.Unknown;
			IL_94:
			this.name = name;
			this.staticValue = staticValue;
			this.linkValue = linkValue;
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060003AF RID: 943 RVA: 0x0000A108 File Offset: 0x00008308
		public int PropertyKindCode
		{
			get
			{
				return this.propertyKindCode;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x0000A120 File Offset: 0x00008320
		public RtfPropertyKind PropertyKind
		{
			get
			{
				return this.propertyKind;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x0000A138 File Offset: 0x00008338
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x0000A150 File Offset: 0x00008350
		public string StaticValue
		{
			get
			{
				return this.staticValue;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x0000A168 File Offset: 0x00008368
		public string LinkValue
		{
			get
			{
				return this.linkValue;
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000A180 File Offset: 0x00008380
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

		// Token: 0x060003B5 RID: 949 RVA: 0x0000A1C8 File Offset: 0x000083C8
		private bool IsEqual(object obj)
		{
			RtfDocumentProperty rtfDocumentProperty = obj as RtfDocumentProperty;
			return rtfDocumentProperty != null && this.propertyKindCode == rtfDocumentProperty.propertyKindCode && this.propertyKind == rtfDocumentProperty.propertyKind && this.name.Equals(rtfDocumentProperty.name) && CompareTool.AreEqual(this.staticValue, rtfDocumentProperty.staticValue) && CompareTool.AreEqual(this.linkValue, rtfDocumentProperty.linkValue);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000A23C File Offset: 0x0000843C
		public override int GetHashCode()
		{
			return HashTool.AddHashCode(base.GetType().GetHashCode(), this.ComputeHashCode());
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000A264 File Offset: 0x00008464
		private int ComputeHashCode()
		{
			int hash = this.propertyKindCode;
			hash = HashTool.AddHashCode(hash, this.propertyKind);
			hash = HashTool.AddHashCode(hash, this.name);
			hash = HashTool.AddHashCode(hash, this.staticValue);
			return HashTool.AddHashCode(hash, this.linkValue);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000A2B8 File Offset: 0x000084B8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(this.name);
			bool flag = this.staticValue != null;
			if (flag)
			{
				stringBuilder.Append("=");
				stringBuilder.Append(this.staticValue);
			}
			bool flag2 = this.linkValue != null;
			if (flag2)
			{
				stringBuilder.Append("@");
				stringBuilder.Append(this.linkValue);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000166 RID: 358
		private readonly int propertyKindCode;

		// Token: 0x04000167 RID: 359
		private readonly RtfPropertyKind propertyKind;

		// Token: 0x04000168 RID: 360
		private readonly string name;

		// Token: 0x04000169 RID: 361
		private readonly string staticValue;

		// Token: 0x0400016A RID: 362
		private readonly string linkValue;
	}
}
