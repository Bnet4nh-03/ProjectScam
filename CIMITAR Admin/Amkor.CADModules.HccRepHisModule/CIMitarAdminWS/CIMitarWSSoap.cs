using System;
using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Amkor.CADModules.HccRepHisModule.CIMitarAdminWS
{
	// Token: 0x0200000D RID: 13
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[ServiceContract(Namespace = "http://Amkor.CIMitarWebService/", ConfigurationName = "CIMitarAdminWS.CIMitarWSSoap")]
	public interface CIMitarWSSoap
	{
		// Token: 0x06000072 RID: 114
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string suyleeTest(string teststr);

		// Token: 0x06000073 RID: 115
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		Task<string> suyleeTestAsync(string teststr);

		// Token: 0x06000074 RID: 116
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage);

		// Token: 0x06000075 RID: 117
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage);

		// Token: 0x06000076 RID: 118
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		DataSet CIMitarQuaryCall(string servername, string quaryString);

		// Token: 0x06000077 RID: 119
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString);
	}
}
