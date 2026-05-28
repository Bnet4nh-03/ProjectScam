using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.ManufactureHistory.GrobalConstMFG.CIMitarAdminWS;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.ManufactureHistory.GrobalConstMFG.Class
{
	// Token: 0x02000004 RID: 4
	public class QueryMgr
	{
		// Token: 0x0600000C RID: 12 RVA: 0x0000397C File Offset: 0x00001B7C
		public QueryMgr()
		{
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000398E File Offset: 0x00001B8E
		public QueryMgr(FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000039A8 File Offset: 0x00001BA8
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

		// Token: 0x04000002 RID: 2
		private FactorySettings _factorySetting = null;
	}
}
