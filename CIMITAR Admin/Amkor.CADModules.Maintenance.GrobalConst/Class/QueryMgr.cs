using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.Maintenance.GrobalConst.CIMitarAdminWS;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.GrobalConst.Class
{
	// Token: 0x02000019 RID: 25
	public class QueryMgr
	{
		// Token: 0x0600009C RID: 156 RVA: 0x00007A58 File Offset: 0x00005C58
		public QueryMgr()
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00007A69 File Offset: 0x00005C69
		public QueryMgr(FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00007A84 File Offset: 0x00005C84
		public DataSet queryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				string uri = this._factorySetting._urlServer + "CIMitarWebService/CIMitarWS.asmx";
				dataSet = new CIMitarWSSoapClient
				{
					Endpoint = 
					{
						Address = new EndpointAddress(uri)
					}
				}.CIMitarQuaryCall("CIMitarMasterDBConnect", sQuery);
				result = dataSet;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				result = null;
			}
			return result;
		}

		// Token: 0x040000FB RID: 251
		private FactorySettings _factorySetting = null;
	}
}
