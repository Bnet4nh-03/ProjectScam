using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Application
{
	// Token: 0x02000064 RID: 100
	public interface IArgument
	{
		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060002A5 RID: 677
		string Name { get; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060002A6 RID: 678
		object Value { get; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060002A7 RID: 679
		object DefaultValue { get; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060002A8 RID: 680
		bool IsMandatory { get; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060002A9 RID: 681
		bool HasName { get; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060002AA RID: 682
		bool IsValid { get; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060002AB RID: 683
		bool IsLoaded { get; }

		// Token: 0x060002AC RID: 684
		void Load(string commandLineArg);
	}
}
