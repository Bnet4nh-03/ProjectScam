using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.SBLModule.CIMitarAdminWS
{
	// Token: 0x0200001B RID: 27
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x060000CF RID: 207 RVA: 0x0000F67B File Offset: 0x0000D87B
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000F683 File Offset: 0x0000D883
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000F68C File Offset: 0x0000D88C
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000F696 File Offset: 0x0000D896
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000F6A0 File Offset: 0x0000D8A0
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000F6AA File Offset: 0x0000D8AA
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000F6C6 File Offset: 0x0000D8C6
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000F6D6 File Offset: 0x0000D8D6
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000F6E6 File Offset: 0x0000D8E6
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000F6F5 File Offset: 0x0000D8F5
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
