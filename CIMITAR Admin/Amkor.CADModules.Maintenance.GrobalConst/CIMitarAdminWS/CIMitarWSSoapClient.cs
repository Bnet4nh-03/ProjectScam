using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.Maintenance.GrobalConst.CIMitarAdminWS
{
	// Token: 0x0200000B RID: 11
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00005B9A File Offset: 0x00003D9A
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00005BA4 File Offset: 0x00003DA4
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005BAF File Offset: 0x00003DAF
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00005BBB File Offset: 0x00003DBB
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005BC7 File Offset: 0x00003DC7
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00005BD4 File Offset: 0x00003DD4
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00005BF4 File Offset: 0x00003DF4
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005C14 File Offset: 0x00003E14
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005C34 File Offset: 0x00003E34
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005C54 File Offset: 0x00003E54
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005C74 File Offset: 0x00003E74
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
