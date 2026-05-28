using System;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.GrobalConst.Class
{
	// Token: 0x02000014 RID: 20
	public class HCC
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00006105 File Offset: 0x00004305
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000060FC File Offset: 0x000042FC
		public string Name { get; private set; } = "HCC";

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00006116 File Offset: 0x00004316
		// (set) Token: 0x0600004B RID: 75 RVA: 0x0000610D File Offset: 0x0000430D
		public HCCContent hCCContent { get; private set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00006127 File Offset: 0x00004327
		// (set) Token: 0x0600004D RID: 77 RVA: 0x0000611E File Offset: 0x0000431E
		public HCCParameter hCCParameter { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00006138 File Offset: 0x00004338
		// (set) Token: 0x0600004F RID: 79 RVA: 0x0000612F File Offset: 0x0000432F
		public SiteMap siteMap { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00006149 File Offset: 0x00004349
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00006140 File Offset: 0x00004340
		public string LotNumber { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000054 RID: 84 RVA: 0x0000615A File Offset: 0x0000435A
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00006151 File Offset: 0x00004351
		public string Machine { get; set; }

		// Token: 0x06000055 RID: 85 RVA: 0x00006164 File Offset: 0x00004364
		public HCC(FactorySettings factorySettings, string factory, bool useSiteMap)
		{
			this._factorySettings = factorySettings;
			this.hCCContent = new HCCContent();
			this.hCCParameter = new HCCParameter();
			if (useSiteMap)
			{
				this.siteMap = new SiteMap(this._factorySettings, factory);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000061BC File Offset: 0x000043BC
		public bool Equals(string name)
		{
			return this.Name == name.ToUpper().Trim();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000061ED File Offset: 0x000043ED
		public void getInformation(string factory, string content, string location)
		{
			this.hCCParameter = cFunction.getHCCInfo(this._factorySettings, factory, content, location);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00006207 File Offset: 0x00004407
		public void initialize()
		{
			this.hCCParameter = new HCCParameter();
		}

		// Token: 0x040000CA RID: 202
		private FactorySettings _factorySettings;
	}
}
