using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000037 RID: 55
	[Serializable]
	public class RtfHexEncodingException : RtfEncodingException
	{
		// Token: 0x060000EC RID: 236 RVA: 0x00002585 File Offset: 0x00000785
		public RtfHexEncodingException()
		{
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000258F File Offset: 0x0000078F
		public RtfHexEncodingException(string message) : base(message)
		{
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000259A File Offset: 0x0000079A
		public RtfHexEncodingException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000025A6 File Offset: 0x000007A6
		protected RtfHexEncodingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
