using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.HccRepHisModule.CIMitarAdminWS
{
	// Token: 0x0200000F RID: 15
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x06000078 RID: 120 RVA: 0x000081F1 File Offset: 0x000063F1
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000081F9 File Offset: 0x000063F9
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00008202 File Offset: 0x00006402
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000820C File Offset: 0x0000640C
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00008216 File Offset: 0x00006416
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00008220 File Offset: 0x00006420
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000822E File Offset: 0x0000642E
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000823C File Offset: 0x0000643C
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000824C File Offset: 0x0000644C
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000825C File Offset: 0x0000645C
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000826B File Offset: 0x0000646B
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
