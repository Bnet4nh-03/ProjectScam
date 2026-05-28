using System;
using Amkor.CADModules.Maintenance.GrobalConst;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000084 RID: 132
	public sealed class RtfVisualText : RtfVisual, IRtfVisualText, IRtfVisual
	{
		// Token: 0x06000429 RID: 1065 RVA: 0x0000BBB4 File Offset: 0x00009DB4
		public RtfVisualText(string text, cConst.Upload.HTMLtype type, IRtfTextFormat format) : base(RtfVisualKind.Text)
		{
			bool flag = text == null;
			if (flag)
			{
				throw new ArgumentNullException("text");
			}
			bool flag2 = format == null;
			if (flag2)
			{
				throw new ArgumentNullException("format");
			}
			this.text = text;
			this.format = format;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0000BC00 File Offset: 0x00009E00
		protected override void DoVisit(IRtfVisualVisitor visitor, cConst.Upload.HTMLtype type)
		{
			visitor.VisitText(this, cConst.Upload.HTMLtype.none);
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0000BC0C File Offset: 0x00009E0C
		public string Text
		{
			get
			{
				return this.text;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x0000BC24 File Offset: 0x00009E24
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x0000BC3C File Offset: 0x00009E3C
		public IRtfTextFormat Format
		{
			get
			{
				return this.format;
			}
			set
			{
				bool flag = this.format == null;
				if (flag)
				{
					throw new ArgumentNullException("value");
				}
				this.format = value;
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000BC6C File Offset: 0x00009E6C
		protected override bool IsEqual(object obj)
		{
			RtfVisualText rtfVisualText = obj as RtfVisualText;
			return rtfVisualText != null && base.IsEqual(rtfVisualText) && this.text.Equals(rtfVisualText.text) && this.format.Equals(rtfVisualText.format);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000BCB8 File Offset: 0x00009EB8
		protected override int ComputeHashCode()
		{
			int hash = base.ComputeHashCode();
			hash = HashTool.AddHashCode(hash, this.text);
			return HashTool.AddHashCode(hash, this.format);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0000BCEC File Offset: 0x00009EEC
		public override string ToString()
		{
			return "'" + this.text + "'";
		}

		// Token: 0x0400018A RID: 394
		private readonly string text;

		// Token: 0x0400018B RID: 395
		private IRtfTextFormat format;
	}
}
