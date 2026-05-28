using System;
using System.Data;
using System.ServiceModel;
using Amkor.CADModules.RELUnitDataProcModule.CIMitarAdminWS;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.RELUnitDataProcModule.CommonClass
{
	// Token: 0x0200001A RID: 26
	public class CommonQuery
	{
		// Token: 0x06000104 RID: 260 RVA: 0x000104CC File Offset: 0x0000E6CC
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

		// Token: 0x06000105 RID: 261 RVA: 0x00010548 File Offset: 0x0000E748
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

		// Token: 0x040000E9 RID: 233
		public FactorySettings _factorySetting;
	}
}
