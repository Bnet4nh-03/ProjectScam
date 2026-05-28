using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000038 RID: 56
	[Serializable]
	public class RtfMissingCharacterException : RtfStructureException
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x000024FE File Offset: 0x000006FE
		public RtfMissingCharacterException()
		{
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00002508 File Offset: 0x00000708
		public RtfMissingCharacterException(string message) : base(message)
		{
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00002513 File Offset: 0x00000713
		public RtfMissingCharacterException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000251F File Offset: 0x0000071F
		protected RtfMissingCharacterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
