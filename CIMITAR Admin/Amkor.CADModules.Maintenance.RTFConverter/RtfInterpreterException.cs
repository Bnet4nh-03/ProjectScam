using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200001D RID: 29
	[Serializable]
	public class RtfInterpreterException : RtfException
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x000024D1 File Offset: 0x000006D1
		public RtfInterpreterException()
		{
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000024DB File Offset: 0x000006DB
		public RtfInterpreterException(string message) : base(message)
		{
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000024E6 File Offset: 0x000006E6
		public RtfInterpreterException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000024F2 File Offset: 0x000006F2
		protected RtfInterpreterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
