using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.ManufactureHistory.GrobalConstMFG.CIMitarAdminWS
{
	// Token: 0x0200000D RID: 13
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x06000031 RID: 49 RVA: 0x00004040 File Offset: 0x00002240
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000404B File Offset: 0x0000224B
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004057 File Offset: 0x00002257
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004064 File Offset: 0x00002264
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004071 File Offset: 0x00002271
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004080 File Offset: 0x00002280
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000040A0 File Offset: 0x000022A0
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000040C0 File Offset: 0x000022C0
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000040E0 File Offset: 0x000022E0
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004100 File Offset: 0x00002300
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004120 File Offset: 0x00002320
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
