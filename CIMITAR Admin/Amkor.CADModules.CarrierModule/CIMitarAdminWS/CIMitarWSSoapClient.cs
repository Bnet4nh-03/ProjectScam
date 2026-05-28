using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.CarrierModule.CIMitarAdminWS
{
	// Token: 0x0200002C RID: 44
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00006C10 File Offset: 0x00004E10
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006C18 File Offset: 0x00004E18
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00006C21 File Offset: 0x00004E21
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00006C2B File Offset: 0x00004E2B
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00006C35 File Offset: 0x00004E35
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00006C3F File Offset: 0x00004E3F
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006C4D File Offset: 0x00004E4D
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00006C5B File Offset: 0x00004E5B
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00006C6B File Offset: 0x00004E6B
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006C7B File Offset: 0x00004E7B
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006C8A File Offset: 0x00004E8A
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
