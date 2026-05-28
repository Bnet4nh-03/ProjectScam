using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.BIBoardInfoModule.CIMitarAdminWS
{
	// Token: 0x02000030 RID: 48
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x06000186 RID: 390 RVA: 0x0002360F File Offset: 0x0002180F
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00023617 File Offset: 0x00021817
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00023620 File Offset: 0x00021820
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0002362A File Offset: 0x0002182A
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00023634 File Offset: 0x00021834
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0002363E File Offset: 0x0002183E
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0002364C File Offset: 0x0002184C
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0002365A File Offset: 0x0002185A
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0002366A File Offset: 0x0002186A
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0002367A File Offset: 0x0002187A
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00023689 File Offset: 0x00021889
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
