using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200003A RID: 58
	[Serializable]
	public class RtfParserException : RtfException
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x000024D1 File Offset: 0x000006D1
		public RtfParserException()
		{
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000024DB File Offset: 0x000006DB
		public RtfParserException(string message) : base(message)
		{
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000024E6 File Offset: 0x000006E6
		public RtfParserException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000024F2 File Offset: 0x000006F2
		protected RtfParserException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
