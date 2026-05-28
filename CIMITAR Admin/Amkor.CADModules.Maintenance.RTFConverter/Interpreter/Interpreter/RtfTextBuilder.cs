using System;
using System.Text;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000099 RID: 153
	public sealed class RtfTextBuilder : RtfElementVisitorBase
	{
		// Token: 0x0600050D RID: 1293 RVA: 0x00010928 File Offset: 0x0000EB28
		public RtfTextBuilder() : base(RtfElementVisitorOrder.DepthFirst)
		{
			this.Reset();
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x00010948 File Offset: 0x0000EB48
		public string CombinedText
		{
			get
			{
				return this.buffer.ToString();
			}
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00010965 File Offset: 0x0000EB65
		public void Reset()
		{
			this.buffer.Remove(0, this.buffer.Length);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00010980 File Offset: 0x0000EB80
		protected override void DoVisitText(IRtfText text)
		{
			this.buffer.Append(text.Text);
		}

		// Token: 0x040001D8 RID: 472
		private readonly StringBuilder buffer = new StringBuilder();
	}
}
