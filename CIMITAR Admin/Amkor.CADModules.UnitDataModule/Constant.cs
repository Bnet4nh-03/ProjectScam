using System;

namespace Amkor.CADModules.UnitDataModule
{
	// Token: 0x02000002 RID: 2
	public class Constant
	{
		// Token: 0x04000001 RID: 1
		public const string LOT = "LOT";

		// Token: 0x04000002 RID: 2
		public const string SN = "SN";

		// Token: 0x02000003 RID: 3
		public class YesOrNo
		{
			// Token: 0x04000003 RID: 3
			public const string Yes = "Y";

			// Token: 0x04000004 RID: 4
			public const string No = "N";
		}

		// Token: 0x02000004 RID: 4
		public class Delimiter
		{
			// Token: 0x04000005 RID: 5
			public const string COMMA = ",";

			// Token: 0x04000006 RID: 6
			public const string VBAR = "|";
		}

		// Token: 0x02000005 RID: 5
		public class DetailViewer
		{
			// Token: 0x04000007 RID: 7
			public const int AllUnit = 0;

			// Token: 0x04000008 RID: 8
			public const int PassUnit = 1;

			// Token: 0x04000009 RID: 9
			public const int Fail = 2;
		}

		// Token: 0x02000006 RID: 6
		public class GridYield
		{
			// Token: 0x0400000A RID: 10
			public const int Lot = 0;

			// Token: 0x0400000B RID: 11
			public const int Dcc = 1;

			// Token: 0x0400000C RID: 12
			public const int Station = 2;

			// Token: 0x0400000D RID: 13
			public const int Product = 3;

			// Token: 0x0400000E RID: 14
			public const int Tester = 4;

			// Token: 0x0400000F RID: 15
			public const int TestProgram = 5;

			// Token: 0x04000010 RID: 16
			public const int StartTime = 6;

			// Token: 0x04000011 RID: 17
			public const int EndTime = 7;

			// Token: 0x04000012 RID: 18
			public const int Input = 8;

			// Token: 0x04000013 RID: 19
			public const int PASS_Final = 9;

			// Token: 0x04000014 RID: 20
			public const int FAIL_Final = 10;

			// Token: 0x04000015 RID: 21
			public const int Yield = 11;

			// Token: 0x04000016 RID: 22
			public const int PASS_1st = 12;

			// Token: 0x04000017 RID: 23
			public const int FAIL_1st = 13;

			// Token: 0x04000018 RID: 24
			public const int FPY = 14;

			// Token: 0x04000019 RID: 25
			public const int RetestRate = 15;

			// Token: 0x0400001A RID: 26
			public const int MaxColumn = 16;
		}

		// Token: 0x02000007 RID: 7
		public class LotListGrid
		{
			// Token: 0x0400001B RID: 27
			public const int Check = 0;

			// Token: 0x0400001C RID: 28
			public const int No = 1;

			// Token: 0x0400001D RID: 29
			public const int Lot = 2;

			// Token: 0x0400001E RID: 30
			public const int Dcc = 3;

			// Token: 0x0400001F RID: 31
			public const int Product = 4;

			// Token: 0x04000020 RID: 32
			public const int SN = 5;

			// Token: 0x04000021 RID: 33
			public const int LotId = 6;

			// Token: 0x04000022 RID: 34
			public const int MaxColumnCnt = 7;
		}
	}
}
