using System;
using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Amkor.CADModules.ManufactureHistory.GrobalConstMFG.CIMitarAdminWS
{
	// Token: 0x0200000B RID: 11
	[ServiceContract(Namespace = "http://Amkor.CIMitarWebService/", ConfigurationName = "CIMitarAdminWS.CIMitarWSSoap")]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public interface CIMitarWSSoap
	{
		// Token: 0x0600002B RID: 43
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		string suyleeTest(string teststr);

		// Token: 0x0600002C RID: 44
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		Task<string> suyleeTestAsync(string teststr);

		// Token: 0x0600002D RID: 45
		[XmlSerializerFormat(SupportFaults = true)]
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage);

		// Token: 0x0600002E RID: 46
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage);

		// Token: 0x0600002F RID: 47
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		DataSet CIMitarQuaryCall(string servername, string quaryString);

		// Token: 0x06000030 RID: 48
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString);
	}
}
