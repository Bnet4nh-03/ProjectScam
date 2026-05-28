using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000019 RID: 25
	[Serializable]
	public class RtfColorTableFormatException : RtfInterpreterException
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x000024A4 File Offset: 0x000006A4
		public RtfColorTableFormatException()
		{
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000024AE File Offset: 0x000006AE
		public RtfColorTableFormatException(string message) : base(message)
		{
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000024B9 File Offset: 0x000006B9
		public RtfColorTableFormatException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000024C5 File Offset: 0x000006C5
		protected RtfColorTableFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
