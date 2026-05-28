using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.DcolSummaryView.CIMitarAdminWS
{
	// Token: 0x0200001B RID: 27
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x0600007F RID: 127 RVA: 0x00007BBF File Offset: 0x00005DBF
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00007BC7 File Offset: 0x00005DC7
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00007BD0 File Offset: 0x00005DD0
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00007BDA File Offset: 0x00005DDA
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00007BE4 File Offset: 0x00005DE4
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00007BEE File Offset: 0x00005DEE
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00007BFC File Offset: 0x00005DFC
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00007C0A File Offset: 0x00005E0A
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00007C1A File Offset: 0x00005E1A
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00007C2A File Offset: 0x00005E2A
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00007C39 File Offset: 0x00005E39
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
