using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.SBLAnalysisModule.CIMitarAdminWS
{
	// Token: 0x02000012 RID: 18
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x06000051 RID: 81 RVA: 0x00004B08 File Offset: 0x00002D08
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004B13 File Offset: 0x00002D13
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004B1F File Offset: 0x00002D1F
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004B2C File Offset: 0x00002D2C
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004B39 File Offset: 0x00002D39
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004B48 File Offset: 0x00002D48
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004B68 File Offset: 0x00002D68
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004B88 File Offset: 0x00002D88
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004BA8 File Offset: 0x00002DA8
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004BC8 File Offset: 0x00002DC8
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004BE8 File Offset: 0x00002DE8
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
