using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200001C RID: 28
	[Serializable]
	public class RtfFontTableFormatException : RtfInterpreterException
	{
		// Token: 0x060000A4 RID: 164 RVA: 0x000024A4 File Offset: 0x000006A4
		public RtfFontTableFormatException()
		{
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000024AE File Offset: 0x000006AE
		public RtfFontTableFormatException(string message) : base(message)
		{
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000024B9 File Offset: 0x000006B9
		public RtfFontTableFormatException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000024C5 File Offset: 0x000006C5
		protected RtfFontTableFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
