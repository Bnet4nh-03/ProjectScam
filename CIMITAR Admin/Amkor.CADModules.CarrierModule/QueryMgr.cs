using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.CarrierModule.CIMitarAdminWS;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.CarrierModule
{
	// Token: 0x0200001E RID: 30
	public class QueryMgr
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00003169 File Offset: 0x00001369
		public QueryMgr()
		{
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003171 File Offset: 0x00001371
		public QueryMgr(FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003180 File Offset: 0x00001380
		public DataSet queryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._factorySetting._urlServer + "CIMitarWS/CIMitarWS.asmx";
				cimitarWSSoapClient.Endpoint.Address = new EndpointAddress(uri);
				dataSet = cimitarWSSoapClient.CIMitarQuaryCall("CIMitarMasterDBConnect", sQuery);
				result = dataSet;
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				result = dataSet;
			}
			return result;
		}

		// Token: 0x04000122 RID: 290
		private FactorySettings _factorySetting;
	}
}
