using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000035 RID: 53
	[Serializable]
	public class RtfEncodingException : RtfParserException
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x0000252B File Offset: 0x0000072B
		public RtfEncodingException()
		{
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00002535 File Offset: 0x00000735
		public RtfEncodingException(string message) : base(message)
		{
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00002540 File Offset: 0x00000740
		public RtfEncodingException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000254C File Offset: 0x0000074C
		protected RtfEncodingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
