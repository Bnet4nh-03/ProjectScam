using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.SBLModule.CIMitarAdminWS;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x0200000F RID: 15
	public class QueryMgr
	{
		// Token: 0x06000032 RID: 50 RVA: 0x0000486E File Offset: 0x00002A6E
		public QueryMgr()
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004876 File Offset: 0x00002A76
		public QueryMgr(FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004888 File Offset: 0x00002A88
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

		// Token: 0x04000064 RID: 100
		private FactorySettings _factorySetting;
	}
}
