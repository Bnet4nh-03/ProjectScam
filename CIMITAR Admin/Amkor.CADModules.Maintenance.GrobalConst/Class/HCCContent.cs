using System;

namespace Amkor.CADModules.Maintenance.GrobalConst.Class
{
	// Token: 0x02000016 RID: 22
	public class HCCContent
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000062C3 File Offset: 0x000044C3
		// (set) Token: 0x0600005A RID: 90 RVA: 0x000062BA File Offset: 0x000044BA
		public string Board { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600005D RID: 93 RVA: 0x000062D4 File Offset: 0x000044D4
		// (set) Token: 0x0600005C RID: 92 RVA: 0x000062CB File Offset: 0x000044CB
		public string Socket { get; private set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600005F RID: 95 RVA: 0x000062E5 File Offset: 0x000044E5
		// (set) Token: 0x0600005E RID: 94 RVA: 0x000062DC File Offset: 0x000044DC
		public string Kit { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000061 RID: 97 RVA: 0x000062F6 File Offset: 0x000044F6
		// (set) Token: 0x06000060 RID: 96 RVA: 0x000062ED File Offset: 0x000044ED
		public string Correaltion { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00006307 File Offset: 0x00004507
		// (set) Token: 0x06000062 RID: 98 RVA: 0x000062FE File Offset: 0x000044FE
		public string Slk { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00006318 File Offset: 0x00004518
		// (set) Token: 0x06000064 RID: 100 RVA: 0x0000630F File Offset: 0x0000450F
		public string Etc { get; private set; }

		// Token: 0x06000066 RID: 102 RVA: 0x00006320 File Offset: 0x00004520
		public HCCContent()
		{
			this.Board = "BOARD";
			this.Socket = "SOCKET";
			this.Kit = "KIT";
			this.Correaltion = "CORRELATION";
			this.Slk = "SLK";
			this.Etc = "ETC";
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00006380 File Offset: 0x00004580
		public HCCContent(HCCParameter hCCParameter)
		{
			this.Board = "BOARD";
			this.Socket = "SOCKET";
			this.Kit = "KIT";
			this.Correaltion = "CORRELATION";
			this.Slk = "SLK";
			this.Etc = "ETC";
		}

		// Token: 0x040000D9 RID: 217
		public HCCTYPE type;
	}
}
