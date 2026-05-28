using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.ESIModule.CIMitarAdminWS
{
	// Token: 0x02000025 RID: 37
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x06000085 RID: 133 RVA: 0x00005BC7 File Offset: 0x00003DC7
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005BCF File Offset: 0x00003DCF
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005BD8 File Offset: 0x00003DD8
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005BE2 File Offset: 0x00003DE2
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005BEC File Offset: 0x00003DEC
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00005BF6 File Offset: 0x00003DF6
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005C04 File Offset: 0x00003E04
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005C12 File Offset: 0x00003E12
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005C22 File Offset: 0x00003E22
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00005C32 File Offset: 0x00003E32
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00005C41 File Offset: 0x00003E41
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
