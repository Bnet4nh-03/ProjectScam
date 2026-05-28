using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Image
{
	// Token: 0x0200009F RID: 159
	public interface IRtfConvertedImageInfoCollection : IEnumerable
	{
		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000556 RID: 1366
		int Count { get; }

		// Token: 0x170001CE RID: 462
		IRtfConvertedImageInfo this[int index]
		{
			get;
		}

		// Token: 0x06000558 RID: 1368
		void CopyTo(IRtfConvertedImageInfo[] array, int index);
	}
}
