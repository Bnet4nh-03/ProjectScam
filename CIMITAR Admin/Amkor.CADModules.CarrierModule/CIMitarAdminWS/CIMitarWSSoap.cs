using System;
using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Amkor.CADModules.CarrierModule.CIMitarAdminWS
{
	// Token: 0x0200002A RID: 42
	[ServiceContract(ConfigurationName = "CIMitarAdminWS.CIMitarWSSoap")]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public interface CIMitarWSSoap
	{
		// Token: 0x06000085 RID: 133
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://tempuri.org/suyleeTest", ReplyAction = "*")]
		string suyleeTest(string teststr);

		// Token: 0x06000086 RID: 134
		[OperationContract(Action = "http://tempuri.org/suyleeTest", ReplyAction = "*")]
		Task<string> suyleeTestAsync(string teststr);

		// Token: 0x06000087 RID: 135
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://tempuri.org/CIMitarMessageSender", ReplyAction = "*")]
		string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage);

		// Token: 0x06000088 RID: 136
		[OperationContract(Action = "http://tempuri.org/CIMitarMessageSender", ReplyAction = "*")]
		Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage);

		// Token: 0x06000089 RID: 137
		[OperationContract(Action = "http://tempuri.org/CIMitarQuaryCall", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		DataSet CIMitarQuaryCall(string servername, string quaryString);

		// Token: 0x0600008A RID: 138
		[OperationContract(Action = "http://tempuri.org/CIMitarQuaryCall", ReplyAction = "*")]
		Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString);
	}
}
