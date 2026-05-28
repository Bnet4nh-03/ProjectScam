using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000022 RID: 34
	[Serializable]
	public class RtfUndefinedColorException : RtfInterpreterException
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x000024A4 File Offset: 0x000006A4
		public RtfUndefinedColorException()
		{
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000024AE File Offset: 0x000006AE
		public RtfUndefinedColorException(string message) : base(message)
		{
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000024B9 File Offset: 0x000006B9
		public RtfUndefinedColorException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000024C5 File Offset: 0x000006C5
		protected RtfUndefinedColorException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
