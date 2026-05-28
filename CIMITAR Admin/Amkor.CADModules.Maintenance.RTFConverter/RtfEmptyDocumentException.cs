using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000034 RID: 52
	[Serializable]
	public class RtfEmptyDocumentException : RtfStructureException
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x000024FE File Offset: 0x000006FE
		public RtfEmptyDocumentException()
		{
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00002508 File Offset: 0x00000708
		public RtfEmptyDocumentException(string message) : base(message)
		{
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00002513 File Offset: 0x00000713
		public RtfEmptyDocumentException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000251F File Offset: 0x0000071F
		protected RtfEmptyDocumentException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
