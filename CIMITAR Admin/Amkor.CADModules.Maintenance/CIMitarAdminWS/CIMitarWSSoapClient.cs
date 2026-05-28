using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.Maintenance.CIMitarAdminWS
{
	// Token: 0x02000007 RID: 7
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x06000019 RID: 25 RVA: 0x0000325F File Offset: 0x0000145F
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003269 File Offset: 0x00001469
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003274 File Offset: 0x00001474
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003280 File Offset: 0x00001480
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000328C File Offset: 0x0000148C
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003298 File Offset: 0x00001498
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000032B8 File Offset: 0x000014B8
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000032D8 File Offset: 0x000014D8
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000032F8 File Offset: 0x000014F8
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003318 File Offset: 0x00001518
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003338 File Offset: 0x00001538
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
