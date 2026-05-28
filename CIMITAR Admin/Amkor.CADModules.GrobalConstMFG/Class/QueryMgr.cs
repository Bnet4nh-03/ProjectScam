using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.ManufactureHistory.GrobalConstMFG.CIMitarAdminWS;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.ManufactureHistory.GrobalConstMFG.Class
{
	// Token: 0x0200000A RID: 10
	public class QueryMgr
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00003F97 File Offset: 0x00002197
		public QueryMgr()
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003FA9 File Offset: 0x000021A9
		public QueryMgr(FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003FC4 File Offset: 0x000021C4
		public DataSet queryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._factorySetting._urlServer + "CIMitarWebService/CIMitarWS.asmx";
				cimitarWSSoapClient.Endpoint.Address = new EndpointAddress(uri);
				dataSet = cimitarWSSoapClient.CIMitarQuaryCall("CIMitarMasterDBConnect", sQuery);
				result = dataSet;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				result = null;
			}
			return result;
		}

		// Token: 0x0400003A RID: 58
		private FactorySettings _factorySetting = null;
	}
}
