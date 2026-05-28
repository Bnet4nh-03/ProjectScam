using System;
using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Amkor.CADModules.RELUnitDataProcModule.CIMitarAdminWS
{
	// Token: 0x02000010 RID: 16
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[ServiceContract(Namespace = "http://Amkor.CIMitarWebService/", ConfigurationName = "CIMitarAdminWS.CIMitarWSSoap")]
	public interface CIMitarWSSoap
	{
		// Token: 0x0600007F RID: 127
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string suyleeTest(string teststr);

		// Token: 0x06000080 RID: 128
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		Task<string> suyleeTestAsync(string teststr);

		// Token: 0x06000081 RID: 129
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage);

		// Token: 0x06000082 RID: 130
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage);

		// Token: 0x06000083 RID: 131
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		DataSet CIMitarQuaryCall(string servername, string quaryString);

		// Token: 0x06000084 RID: 132
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString);
	}
}
