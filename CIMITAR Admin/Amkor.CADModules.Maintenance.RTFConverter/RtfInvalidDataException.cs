using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200001F RID: 31
	[Serializable]
	public class RtfInvalidDataException : RtfInterpreterException
	{
		// Token: 0x060000AC RID: 172 RVA: 0x000024A4 File Offset: 0x000006A4
		public RtfInvalidDataException()
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000024AE File Offset: 0x000006AE
		public RtfInvalidDataException(string message) : base(message)
		{
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000024B9 File Offset: 0x000006B9
		public RtfInvalidDataException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000024C5 File Offset: 0x000006C5
		protected RtfInvalidDataException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
