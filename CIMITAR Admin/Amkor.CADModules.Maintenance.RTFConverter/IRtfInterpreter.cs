using System;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200000B RID: 11
	public interface IRtfInterpreter
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000057 RID: 87
		IRtfInterpreterSettings Settings { get; }

		// Token: 0x06000058 RID: 88
		void AddInterpreterListener(IRtfInterpreterListener listener);

		// Token: 0x06000059 RID: 89
		void RemoveInterpreterListener(IRtfInterpreterListener listener);

		// Token: 0x0600005A RID: 90
		void Interpret(IRtfGroup rtfDocument);
	}
}
