using System;

namespace Amkor.CADModules.CarrierModule.Class
{
	// Token: 0x0200001F RID: 31
	public class CSocketInfo : ICloneable
	{
		// Token: 0x0600002E RID: 46 RVA: 0x000031F8 File Offset: 0x000013F8
		public object Clone()
		{
			return new CSocketInfo
			{
				SocketId = this.SocketId,
				Barcode = this.Barcode,
				Device = this.Device,
				SocketType = this.SocketType,
				Pn = this.Pn,
				Customer = this.Customer,
				PkgType = this.PkgType,
				Mfg = this.Mfg,
				Status = this.Status,
				Memo = this.Memo,
				TesterName = this.TesterName,
				CreateUser = this.CreateUser,
				CreateTime = this.CreateTime,
				LastEventUser = this.LastEventUser,
				LastEventTime = this.LastEventTime
			};
		}

		// Token: 0x04000123 RID: 291
		public string SocketId = string.Empty;

		// Token: 0x04000124 RID: 292
		public string Barcode = string.Empty;

		// Token: 0x04000125 RID: 293
		public string Device = string.Empty;

		// Token: 0x04000126 RID: 294
		public string SocketType = string.Empty;

		// Token: 0x04000127 RID: 295
		public string Pn = string.Empty;

		// Token: 0x04000128 RID: 296
		public string Customer = string.Empty;

		// Token: 0x04000129 RID: 297
		public string PkgType = string.Empty;

		// Token: 0x0400012A RID: 298
		public string Mfg = string.Empty;

		// Token: 0x0400012B RID: 299
		public string Status = string.Empty;

		// Token: 0x0400012C RID: 300
		public string Memo = string.Empty;

		// Token: 0x0400012D RID: 301
		public string TesterName = string.Empty;

		// Token: 0x0400012E RID: 302
		public string CreateUser = string.Empty;

		// Token: 0x0400012F RID: 303
		public string CreateTime = string.Empty;

		// Token: 0x04000130 RID: 304
		public string LastEventUser = string.Empty;

		// Token: 0x04000131 RID: 305
		public string LastEventTime = string.Empty;

		// Token: 0x04000132 RID: 306
		public int Line;

		// Token: 0x04000133 RID: 307
		public string Result = string.Empty;

		// Token: 0x04000134 RID: 308
		public string Reason = string.Empty;
	}
}
