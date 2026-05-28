using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.SAMSUNGModule.CIMitarAdminWS
{
	// Token: 0x02000020 RID: 32
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x0600007F RID: 127 RVA: 0x000056E7 File Offset: 0x000038E7
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000056EF File Offset: 0x000038EF
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000056F8 File Offset: 0x000038F8
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00005702 File Offset: 0x00003902
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000570C File Offset: 0x0000390C
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00005716 File Offset: 0x00003916
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005724 File Offset: 0x00003924
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005732 File Offset: 0x00003932
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005742 File Offset: 0x00003942
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005752 File Offset: 0x00003952
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005761 File Offset: 0x00003961
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
