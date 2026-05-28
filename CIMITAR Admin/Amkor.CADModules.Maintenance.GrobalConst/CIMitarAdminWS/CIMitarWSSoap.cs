using System;
using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Amkor.CADModules.Maintenance.GrobalConst.CIMitarAdminWS
{
	// Token: 0x02000009 RID: 9
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[ServiceContract(Namespace = "http://Amkor.CIMitarWebService/", ConfigurationName = "CIMitarAdminWS.CIMitarWSSoap")]
	public interface CIMitarWSSoap
	{
		// Token: 0x0600002E RID: 46
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string suyleeTest(string teststr);

		// Token: 0x0600002F RID: 47
		[OperationContract(Action = "http://Amkor.CIMitarWebService/suyleeTest", ReplyAction = "*")]
		Task<string> suyleeTestAsync(string teststr);

		// Token: 0x06000030 RID: 48
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage);

		// Token: 0x06000031 RID: 49
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarMessageSender", ReplyAction = "*")]
		Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage);

		// Token: 0x06000032 RID: 50
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		[XmlSerializerFormat(SupportFaults = true)]
		DataSet CIMitarQuaryCall(string servername, string quaryString);

		// Token: 0x06000033 RID: 51
		[OperationContract(Action = "http://Amkor.CIMitarWebService/CIMitarQuaryCall", ReplyAction = "*")]
		Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString);
	}
}
