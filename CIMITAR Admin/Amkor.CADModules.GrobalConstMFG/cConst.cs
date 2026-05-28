using System;
using System.Collections.Generic;

namespace Amkor.CADModules.ManufactureHistory.GrobalConstMFG
{
	// Token: 0x02000002 RID: 2
	public static class cConst
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void clearCategory()
		{
			cConst.sCategory.Clear();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
		public static void addCategory(string name)
		{
			if (!cConst.sCategory.Contains(name))
			{
				cConst.sCategory.Add(name);
			}
		}

		// Token: 0x04000001 RID: 1
		public const int K3 = 0;

		// Token: 0x04000002 RID: 2
		public const int K4 = 1;

		// Token: 0x04000003 RID: 3
		public const int K5 = 2;

		// Token: 0x04000004 RID: 4
		public const int K3_E = 3;

		// Token: 0x04000005 RID: 5
		public const int K5_M = 4;

		// Token: 0x04000006 RID: 6
		public const string sK3 = "K3";

		// Token: 0x04000007 RID: 7
		public const string sK4 = "K4";

		// Token: 0x04000008 RID: 8
		public const string sK5 = "K5";

		// Token: 0x04000009 RID: 9
		public const string sK3EV = "K3_E";

		// Token: 0x0400000A RID: 10
		public const string sK5M = "K5_M";

		// Token: 0x0400000B RID: 11
		public static readonly List<string> sCategory = new List<string>();

		// Token: 0x0400000C RID: 12
		public static readonly string[] sPlant = new string[]
		{
			"K3",
			"K4",
			"K5",
			"K3_E",
			"K5_M"
		};

		// Token: 0x02000003 RID: 3
		public class Upload
		{
			// Token: 0x0400000D RID: 13
			private const string _tempDir = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload";

			// Token: 0x0400000E RID: 14
			public const string _tempContDir = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content";

			// Token: 0x0400000F RID: 15
			public const string _Content1RTF = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content\\content1.rtf";

			// Token: 0x04000010 RID: 16
			public const string _Content2RTF = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content\\content2.rtf";

			// Token: 0x04000011 RID: 17
			public const string _Content1Zip = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content1.zip";

			// Token: 0x04000012 RID: 18
			public const string _Content2Zip = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content2.zip";

			// Token: 0x04000013 RID: 19
			public const string _AttachFileDir_K5_M = "\\\\k3tpasqlsvc\\Manufacture_Maintenance\\K5_M_Mfg\\";

			// Token: 0x04000014 RID: 20
			public const string _AttachFileTempDir = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Uploadattach\\";
		}

		// Token: 0x02000004 RID: 4
		public class Download
		{
			// Token: 0x04000015 RID: 21
			private const string _tempDir = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Download";

			// Token: 0x04000016 RID: 22
			public const string _tempContDir = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content";

			// Token: 0x04000017 RID: 23
			public const string _Content1RTF = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content1.rtf";

			// Token: 0x04000018 RID: 24
			public const string _Content2RTF = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content2.rtf";

			// Token: 0x04000019 RID: 25
			public const string _Content1Zip = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content1.zip";

			// Token: 0x0400001A RID: 26
			public const string _Content2Zip = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content2.zip";

			// Token: 0x0400001B RID: 27
			public const string _AttachFileDir_K5_M = "\\\\k3tpasqlsvc\\Manufacture_Maintenance\\K5_M_Mfg\\";

			// Token: 0x0400001C RID: 28
			public const string _AttachFileTempDir = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\";
		}
	}
}
