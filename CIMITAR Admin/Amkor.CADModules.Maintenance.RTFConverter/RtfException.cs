using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000036 RID: 54
	[Serializable]
	public class RtfException : Exception
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00002558 File Offset: 0x00000758
		public RtfException()
		{
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00002562 File Offset: 0x00000762
		public RtfException(string message) : base(message)
		{
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000256D File Offset: 0x0000076D
		public RtfException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00002579 File Offset: 0x00000779
		protected RtfException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
