using System;
using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Amkor.CADModules.SAMSUNGModule.CIMitarAdminWS
{
	// Token: 0x0200001E RID: 30
	[ServiceContract(Namespace = "http://Amkor.CIMitarWebService/", ConfigurationName = "CIMitarAdminWS.CIMitarWSSoap")]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public interface CIMitarWSSoap
	{
		// Token: 0x06000079 RID: 121
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string suyleeTest(string teststr);

		// Token: 0x0600007A RID: 122
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		Task<string> suyleeTestAsync(string teststr);

		// Token: 0x0600007B RID: 123
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage);

		// Token: 0x0600007C RID: 124
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage);

		// Token: 0x0600007D RID: 125
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		DataSet CIMitarQuaryCall(string servername, string quaryString);

		// Token: 0x0600007E RID: 126
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString);
	}
}
