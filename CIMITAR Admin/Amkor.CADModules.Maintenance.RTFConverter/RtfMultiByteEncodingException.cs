using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000039 RID: 57
	[Serializable]
	public class RtfMultiByteEncodingException : RtfEncodingException
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x00002585 File Offset: 0x00000785
		public RtfMultiByteEncodingException()
		{
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000258F File Offset: 0x0000078F
		public RtfMultiByteEncodingException(string message) : base(message)
		{
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000259A File Offset: 0x0000079A
		public RtfMultiByteEncodingException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000025A6 File Offset: 0x000007A6
		protected RtfMultiByteEncodingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
