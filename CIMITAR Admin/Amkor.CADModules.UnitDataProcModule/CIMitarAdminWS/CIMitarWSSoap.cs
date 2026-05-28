using System;
using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Amkor.CADModules.UnitDataProcModule.CIMitarAdminWS
{
	// Token: 0x0200001D RID: 29
	[ServiceContract(Namespace = "http://Amkor.CIMitarWebService/", ConfigurationName = "CIMitarAdminWS.CIMitarWSSoap")]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public interface CIMitarWSSoap
	{
		// Token: 0x060000A8 RID: 168
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string suyleeTest(string teststr);

		// Token: 0x060000A9 RID: 169
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		Task<string> suyleeTestAsync(string teststr);

		// Token: 0x060000AA RID: 170
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage);

		// Token: 0x060000AB RID: 171
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage);

		// Token: 0x060000AC RID: 172
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		DataSet CIMitarQuaryCall(string servername, string quaryString);

		// Token: 0x060000AD RID: 173
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString);
	}
}
