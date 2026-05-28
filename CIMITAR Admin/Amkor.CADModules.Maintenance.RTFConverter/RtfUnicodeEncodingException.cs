using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200003D RID: 61
	[Serializable]
	public class RtfUnicodeEncodingException : RtfEncodingException
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00002585 File Offset: 0x00000785
		public RtfUnicodeEncodingException()
		{
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000258F File Offset: 0x0000078F
		public RtfUnicodeEncodingException(string message) : base(message)
		{
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000259A File Offset: 0x0000079A
		public RtfUnicodeEncodingException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000025A6 File Offset: 0x000007A6
		protected RtfUnicodeEncodingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
