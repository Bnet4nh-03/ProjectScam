using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Amkor.CADModules.UnitDataProcModule.CIMitarAdminWS
{
	// Token: 0x0200001F RID: 31
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	public class CIMitarWSSoapClient : ClientBase<CIMitarWSSoap>, CIMitarWSSoap
	{
		// Token: 0x060000AE RID: 174 RVA: 0x0000E1F3 File Offset: 0x0000C3F3
		public CIMitarWSSoapClient()
		{
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000E1FB File Offset: 0x0000C3FB
		public CIMitarWSSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000E204 File Offset: 0x0000C404
		public CIMitarWSSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000E20E File Offset: 0x0000C40E
		public CIMitarWSSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000E218 File Offset: 0x0000C418
		public CIMitarWSSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000E222 File Offset: 0x0000C422
		public string suyleeTest(string teststr)
		{
			return base.Channel.suyleeTest(teststr);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000E230 File Offset: 0x0000C430
		public Task<string> suyleeTestAsync(string teststr)
		{
			return base.Channel.suyleeTestAsync(teststr);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000E23E File Offset: 0x0000C43E
		public string CIMitarMessageSender(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSender(serveripname, serverportname, sendmessage);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000E24E File Offset: 0x0000C44E
		public Task<string> CIMitarMessageSenderAsync(string serveripname, string serverportname, string sendmessage)
		{
			return base.Channel.CIMitarMessageSenderAsync(serveripname, serverportname, sendmessage);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000E25E File Offset: 0x0000C45E
		public DataSet CIMitarQuaryCall(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCall(servername, quaryString);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000E26D File Offset: 0x0000C46D
		public Task<DataSet> CIMitarQuaryCallAsync(string servername, string quaryString)
		{
			return base.Channel.CIMitarQuaryCallAsync(servername, quaryString);
		}
	}
}
