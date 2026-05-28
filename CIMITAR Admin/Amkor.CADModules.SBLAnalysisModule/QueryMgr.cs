using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.SBLAnalysisModule.CIMitarAdminWS;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.SBLAnalysisModule
{
	// Token: 0x02000008 RID: 8
	public class QueryMgr
	{
		// Token: 0x0600000E RID: 14 RVA: 0x000027C7 File Offset: 0x000009C7
		public QueryMgr()
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000027D9 File Offset: 0x000009D9
		public QueryMgr(FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000027F4 File Offset: 0x000009F4
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
				result = dataSet;
			}
			return result;
		}

		// Token: 0x0400003B RID: 59
		private FactorySettings _factorySetting = null;
	}
}
