using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.UnitDataProcModule.CIMitarAdminWS;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.UnitDataProcModule.CommonClass
{
	// Token: 0x02000004 RID: 4
	public class CommonQuery
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00006E84 File Offset: 0x00005084
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

		// Token: 0x06000021 RID: 33 RVA: 0x00006EFC File Offset: 0x000050FC
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

		// Token: 0x04000031 RID: 49
		public FactorySettings _factorySetting;
	}
}
