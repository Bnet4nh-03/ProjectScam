using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.HccSTReportModule.CIMitarAdminWS;

namespace Amkor.CADModules.HccSTReportModule.Class
{
	// Token: 0x0200001B RID: 27
	public class CCommon
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x0001A182 File Offset: 0x00018382
		public CCommon(string url)
		{
			this._url = url;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0001A19C File Offset: 0x0001839C
		public DataSet QueryCall(string sQuery)
		{
			DataSet dataSet = new DataSet();
			DataSet result;
			try
			{
				CIMitarWSSoapClient cimitarWSSoapClient = new CIMitarWSSoapClient();
				string uri = this._url + "CIMitarWebService/CIMitarWS.asmx";
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

		// Token: 0x040001B0 RID: 432
		private string _url = string.Empty;
	}
}
