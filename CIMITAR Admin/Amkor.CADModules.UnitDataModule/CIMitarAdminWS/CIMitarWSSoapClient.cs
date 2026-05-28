using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.UnitDataModule.CIMitarAdminWS
{
	// Token: 0x02000020 RID: 32
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x0600007F RID: 127 RVA: 0x000056FF File Offset: 0x000038FF
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00005707 File Offset: 0x00003907
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00005710 File Offset: 0x00003910
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000571A File Offset: 0x0000391A
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005724 File Offset: 0x00003924
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000572E File Offset: 0x0000392E
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000573C File Offset: 0x0000393C
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000574A File Offset: 0x0000394A
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000575A File Offset: 0x0000395A
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000576A File Offset: 0x0000396A
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005779 File Offset: 0x00003979
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
