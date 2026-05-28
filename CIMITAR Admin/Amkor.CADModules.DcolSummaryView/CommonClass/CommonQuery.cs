using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.DcolSummaryView.CIMitarAdminWS;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.DcolSummaryView.CommonClass
{
	// Token: 0x02000004 RID: 4
	public class CommonQuery
	{
		// Token: 0x06000014 RID: 20 RVA: 0x0000436C File Offset: 0x0000256C
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

		// Token: 0x06000015 RID: 21 RVA: 0x000043E4 File Offset: 0x000025E4
		public DataSet getTypeDef(string sTypeName, string sTypeValue)
		{
			DataSet result = new DataSet();
			try
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Report].[dbo].[USP_CR_GetTypeDefList] @typename = '",
					sTypeName,
					"', @typevalue = '",
					sTypeValue,
					"'"
				});
				result = this.queryCall(sQuery);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return result;
		}

		// Token: 0x0400001F RID: 31
		public FactorySettings _factorySetting;
	}
}
