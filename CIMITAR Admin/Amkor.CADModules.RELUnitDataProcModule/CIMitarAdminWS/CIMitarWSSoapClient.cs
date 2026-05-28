using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.RELUnitDataProcModule.CIMitarAdminWS
{
	// Token: 0x02000012 RID: 18
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x06000085 RID: 133 RVA: 0x00007DF8 File Offset: 0x00005FF8
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00007E02 File Offset: 0x00006002
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00007E0D File Offset: 0x0000600D
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00007E19 File Offset: 0x00006019
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00007E25 File Offset: 0x00006025
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00007E34 File Offset: 0x00006034
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00007E54 File Offset: 0x00006054
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00007E74 File Offset: 0x00006074
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00007E94 File Offset: 0x00006094
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00007EB4 File Offset: 0x000060B4
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00007ED4 File Offset: 0x000060D4
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
