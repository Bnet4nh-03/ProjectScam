using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000032 RID: 50
	[Serializable]
	public class RtfBraceNestingException : RtfStructureException
	{
		// Token: 0x060000DC RID: 220 RVA: 0x000024FE File Offset: 0x000006FE
		public RtfBraceNestingException()
		{
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00002508 File Offset: 0x00000708
		public RtfBraceNestingException(string message) : base(message)
		{
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00002513 File Offset: 0x00000713
		public RtfBraceNestingException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000251F File Offset: 0x0000071F
		protected RtfBraceNestingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
