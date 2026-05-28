using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.HccSTReportModule.CIMitarAdminWS
{
	// Token: 0x0200001A RID: 26
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x060000CA RID: 202 RVA: 0x0001A0F9 File Offset: 0x000182F9
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0001A101 File Offset: 0x00018301
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0001A10A File Offset: 0x0001830A
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0001A114 File Offset: 0x00018314
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0001A11E File Offset: 0x0001831E
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0001A128 File Offset: 0x00018328
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0001A136 File Offset: 0x00018336
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0001A144 File Offset: 0x00018344
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0001A154 File Offset: 0x00018354
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0001A164 File Offset: 0x00018364
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0001A173 File Offset: 0x00018373
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
