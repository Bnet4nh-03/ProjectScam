using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.BoardCenterClient.CIMitarAdminWS
{
	// Token: 0x0200000B RID: 11
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x0600004D RID: 77 RVA: 0x000068BD File Offset: 0x00004ABD
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000068C5 File Offset: 0x00004AC5
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000068CE File Offset: 0x00004ACE
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000068D8 File Offset: 0x00004AD8
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000068E2 File Offset: 0x00004AE2
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000068EC File Offset: 0x00004AEC
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000068FA File Offset: 0x00004AFA
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00006908 File Offset: 0x00004B08
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00006918 File Offset: 0x00004B18
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00006928 File Offset: 0x00004B28
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00006937 File Offset: 0x00004B37
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
