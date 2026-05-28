using System;
using System.Runtime.Serialization;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200003C RID: 60
	[Serializable]
	public class RtfStructureException : RtfParserException
	{
		// Token: 0x060000FE RID: 254 RVA: 0x0000252B File Offset: 0x0000072B
		public RtfStructureException()
		{
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00002535 File Offset: 0x00000735
		public RtfStructureException(string message) : base(message)
		{
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00002540 File Offset: 0x00000740
		public RtfStructureException(string message, Exception cause) : base(message, cause)
		{
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000254C File Offset: 0x0000074C
		protected RtfStructureException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
