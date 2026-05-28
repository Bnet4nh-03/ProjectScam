using System;
using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Amkor.CADModules.HccSTReportModule.CIMitarAdminWS
{
	// Token: 0x02000018 RID: 24
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[ServiceContract(Namespace = "http://Amkor.CIMitarWebService/", ConfigurationName = "CIMitarAdminWS.CIMitarWSSoap")]
	public interface CIMitarWSSoap
	{
		// Token: 0x060000C4 RID: 196
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string suyleeTest(string teststr);

		// Token: 0x060000C5 RID: 197
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		Task<string> suyleeTestAsync(string teststr);

		// Token: 0x060000C6 RID: 198
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage);

		// Token: 0x060000C7 RID: 199
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage);

		// Token: 0x060000C8 RID: 200
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		DataSet CIMitarQuaryCall(string servername, string quaryString);

		// Token: 0x060000C9 RID: 201
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString);
	}
}
