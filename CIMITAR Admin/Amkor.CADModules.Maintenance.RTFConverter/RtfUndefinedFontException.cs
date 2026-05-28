using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000023 RID: 35
	[Serializable]
	public class RtfUndefinedFontException : RtfInterpreterException
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x000024A4 File Offset: 0x000006A4
		public RtfUndefinedFontException()
		{
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000024AE File Offset: 0x000006AE
		public RtfUndefinedFontException(string message) : base(message)
		{
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000024B9 File Offset: 0x000006B9
		public RtfUndefinedFontException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000024C5 File Offset: 0x000006C5
		protected RtfUndefinedFontException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
