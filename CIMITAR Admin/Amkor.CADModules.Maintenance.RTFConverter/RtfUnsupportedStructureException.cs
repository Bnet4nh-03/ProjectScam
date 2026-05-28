using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000024 RID: 36
	[Serializable]
	public class RtfUnsupportedStructureException : RtfInterpreterException
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x000024A4 File Offset: 0x000006A4
		public RtfUnsupportedStructureException()
		{
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000024AE File Offset: 0x000006AE
		public RtfUnsupportedStructureException(string message) : base(message)
		{
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000024B9 File Offset: 0x000006B9
		public RtfUnsupportedStructureException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000024C5 File Offset: 0x000006C5
		protected RtfUnsupportedStructureException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
