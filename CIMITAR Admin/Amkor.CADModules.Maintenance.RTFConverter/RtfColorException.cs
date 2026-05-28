using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000018 RID: 24
	[Serializable]
	public class RtfColorException : RtfInterpreterException
	{
		// Token: 0x0600009C RID: 156 RVA: 0x000024A4 File Offset: 0x000006A4
		public RtfColorException()
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000024AE File Offset: 0x000006AE
		public RtfColorException(string message) : base(message)
		{
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000024B9 File Offset: 0x000006B9
		public RtfColorException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000024C5 File Offset: 0x000006C5
		protected RtfColorException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
