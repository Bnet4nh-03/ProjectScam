using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.ManufactureHistory.CIMitarAdminWS
{
	// Token: 0x0200000A RID: 10
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x06000023 RID: 35 RVA: 0x0000430D File Offset: 0x0000250D
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00004318 File Offset: 0x00002518
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00004324 File Offset: 0x00002524
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00004331 File Offset: 0x00002531
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000433E File Offset: 0x0000253E
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000434C File Offset: 0x0000254C
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000436C File Offset: 0x0000256C
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000438C File Offset: 0x0000258C
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000043AC File Offset: 0x000025AC
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000043CC File Offset: 0x000025CC
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000043EC File Offset: 0x000025EC
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
