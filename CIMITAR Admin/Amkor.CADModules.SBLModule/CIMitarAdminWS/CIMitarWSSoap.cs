using System;
using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Amkor.CADModules.SBLModule.CIMitarAdminWS
{
	// Token: 0x02000019 RID: 25
	[ServiceContract(Namespace = "http://Amkor.CIMitarWebService/", ConfigurationName = "CIMitarAdminWS.CIMitarWSSoap")]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public interface CIMitarWSSoap
	{
		// Token: 0x060000C9 RID: 201
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		string suyleeTest(string teststr);

		// Token: 0x060000CA RID: 202
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		Task<string> suyleeTestAsync(string teststr);

		// Token: 0x060000CB RID: 203
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage);

		// Token: 0x060000CC RID: 204
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage);

		// Token: 0x060000CD RID: 205
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		DataSet CIMitarQuaryCall(string servername, string quaryString);

		// Token: 0x060000CE RID: 206
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString);
	}
}
