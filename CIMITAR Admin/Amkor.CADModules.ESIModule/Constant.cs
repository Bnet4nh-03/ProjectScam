using System;

namespace Amkor.CADModules.ESIModule
{
	// Token: 0x02000002 RID: 2
	public class Constant
	{
		// Token: 0x04000001 RID: 1
		public const string CHECKIN = "CHECKIN";

		// Token: 0x04000002 RID: 2
		public const string CHECKOUT = "CHECKOUT";

		// Token: 0x04000003 RID: 3
		public const string REQUEST = "REQUEST";

		// Token: 0x04000004 RID: 4
		public const string LOT = "LOT";

		// Token: 0x04000005 RID: 5
		public const string SN = "SN";

		// Token: 0x02000003 RID: 3
		public class YesOrNo
		{
			// Token: 0x04000006 RID: 6
			public const string Yes = "Y";

			// Token: 0x04000007 RID: 7
			public const string No = "N";
		}

		// Token: 0x02000004 RID: 4
		public class Delimiter
		{
			// Token: 0x04000008 RID: 8
			public const string COMMA = ",";

			// Token: 0x04000009 RID: 9
			public const string VBAR = "|";
		}

		// Token: 0x02000005 RID: 5
		public class DetailViewer
		{
			// Token: 0x0400000A RID: 10
			public const int AllUnit = 0;

			// Token: 0x0400000B RID: 11
			public const int PassUnit = 1;

			// Token: 0x0400000C RID: 12
			public const int Fail = 2;
		}

		// Token: 0x02000006 RID: 6
		public class GridYield
		{
			// Token: 0x0400000D RID: 13
			public const int Station = 0;

			// Token: 0x0400000E RID: 14
			public const int Product = 1;

			// Token: 0x0400000F RID: 15
			public const int Device = 2;

			// Token: 0x04000010 RID: 16
			public const int Lot = 3;

			// Token: 0x04000011 RID: 17
			public const int Dcc = 4;

			// Token: 0x04000012 RID: 18
			public const int TestProgram = 5;

			// Token: 0x04000013 RID: 19
			public const int StartTime = 6;

			// Token: 0x04000014 RID: 20
			public const int EndTime = 7;

			// Token: 0x04000015 RID: 21
			public const int Input = 8;

			// Token: 0x04000016 RID: 22
			public const int PASS_Final = 9;

			// Token: 0x04000017 RID: 23
			public const int FAIL_Final = 10;

			// Token: 0x04000018 RID: 24
			public const int Yield = 11;

			// Token: 0x04000019 RID: 25
			public const int PASS_1st = 12;

			// Token: 0x0400001A RID: 26
			public const int FAIL_1st = 13;

			// Token: 0x0400001B RID: 27
			public const int FPY = 14;

			// Token: 0x0400001C RID: 28
			public const int RetestRate = 15;

			// Token: 0x0400001D RID: 29
			public const int PASS_2nd = 16;

			// Token: 0x0400001E RID: 30
			public const int FAIL_2nd = 17;

			// Token: 0x0400001F RID: 31
			public const int PASS_3rd = 18;

			// Token: 0x04000020 RID: 32
			public const int FAIL_3rd = 19;

			// Token: 0x04000021 RID: 33
			public const int PASS_4th = 20;

			// Token: 0x04000022 RID: 34
			public const int FAIL_4th = 21;

			// Token: 0x04000023 RID: 35
			public const int MaxColumn = 22;
		}

		// Token: 0x02000007 RID: 7
		public class GridYield_StationID
		{
			// Token: 0x04000024 RID: 36
			public const int Station = 0;

			// Token: 0x04000025 RID: 37
			public const int StationID = 1;

			// Token: 0x04000026 RID: 38
			public const int Lot = 2;

			// Token: 0x04000027 RID: 39
			public const int Dcc = 3;

			// Token: 0x04000028 RID: 40
			public const int Input = 4;

			// Token: 0x04000029 RID: 41
			public const int PASS_Final = 5;

			// Token: 0x0400002A RID: 42
			public const int FAIL_Final = 6;

			// Token: 0x0400002B RID: 43
			public const int Yield = 7;

			// Token: 0x0400002C RID: 44
			public const int PASS_1st = 8;

			// Token: 0x0400002D RID: 45
			public const int FAIL_1st = 9;

			// Token: 0x0400002E RID: 46
			public const int FPY = 10;

			// Token: 0x0400002F RID: 47
			public const int RetestRate = 11;

			// Token: 0x04000030 RID: 48
			public const int PASS_2nd = 12;

			// Token: 0x04000031 RID: 49
			public const int FAIL_2nd = 13;

			// Token: 0x04000032 RID: 50
			public const int PASS_3rd = 14;

			// Token: 0x04000033 RID: 51
			public const int FAIL_3rd = 15;

			// Token: 0x04000034 RID: 52
			public const int PASS_4th = 16;

			// Token: 0x04000035 RID: 53
			public const int FAIL_4th = 17;

			// Token: 0x04000036 RID: 54
			public const int MaxColumn = 18;
		}

		// Token: 0x02000008 RID: 8
		public class Grid2DList
		{
			// Token: 0x04000037 RID: 55
			public const int No = 0;

			// Token: 0x04000038 RID: 56
			public const int Checkbox = 1;

			// Token: 0x04000039 RID: 57
			public const int SN = 2;

			// Token: 0x0400003A RID: 58
			public const int Status = 3;

			// Token: 0x0400003B RID: 59
			public const int Config = 4;

			// Token: 0x0400003C RID: 60
			public const int Dcc = 5;

			// Token: 0x0400003D RID: 61
			public const int Product = 6;

			// Token: 0x0400003E RID: 62
			public const int TestStation = 7;

			// Token: 0x0400003F RID: 63
			public const int StationID = 8;

			// Token: 0x04000040 RID: 64
			public const int SWVersion = 9;

			// Token: 0x04000041 RID: 65
			public const int StartTime = 10;

			// Token: 0x04000042 RID: 66
			public const int StopTime = 11;

			// Token: 0x04000043 RID: 67
			public const int FailTests = 12;

			// Token: 0x04000044 RID: 68
			public const int FailingMsg = 13;

			// Token: 0x04000045 RID: 69
			public const int MaxColumn = 14;
		}

		// Token: 0x02000009 RID: 9
		public class UnitHistoryGrid
		{
			// Token: 0x04000046 RID: 70
			public const int No = 0;

			// Token: 0x04000047 RID: 71
			public const int Config = 1;

			// Token: 0x04000048 RID: 72
			public const int Dcc = 2;

			// Token: 0x04000049 RID: 73
			public const int Station = 3;

			// Token: 0x0400004A RID: 74
			public const int Result = 4;

			// Token: 0x0400004B RID: 75
			public const int AuditMode = 5;

			// Token: 0x0400004C RID: 76
			public const int SWVersion = 6;

			// Token: 0x0400004D RID: 77
			public const int inDate = 7;

			// Token: 0x0400004E RID: 78
			public const int ft_test = 8;

			// Token: 0x0400004F RID: 79
			public const int faillog = 9;

			// Token: 0x04000050 RID: 80
			public const int MaxColumnCnt = 10;
		}

		// Token: 0x0200000A RID: 10
		public class UnitListGrid
		{
			// Token: 0x04000051 RID: 81
			public const int No = 0;

			// Token: 0x04000052 RID: 82
			public const int Status = 1;

			// Token: 0x04000053 RID: 83
			public const int SN = 2;

			// Token: 0x04000054 RID: 84
			public const int LotID = 3;

			// Token: 0x04000055 RID: 85
			public const int DCC = 4;

			// Token: 0x04000056 RID: 86
			public const int Product = 5;

			// Token: 0x04000057 RID: 87
			public const int Station = 6;

			// Token: 0x04000058 RID: 88
			public const int StationID = 7;

			// Token: 0x04000059 RID: 89
			public const int Version = 8;

			// Token: 0x0400005A RID: 90
			public const int Result = 9;

			// Token: 0x0400005B RID: 91
			public const int Failing = 10;

			// Token: 0x0400005C RID: 92
			public const int FailureMesg = 11;

			// Token: 0x0400005D RID: 93
			public const int inDate = 12;

			// Token: 0x0400005E RID: 94
			public const int Comment = 13;

			// Token: 0x0400005F RID: 95
			public const int Checbox = 14;

			// Token: 0x04000060 RID: 96
			public const int MaxColumnCnt = 15;
		}

		// Token: 0x0200000B RID: 11
		public class LotListGrid
		{
			// Token: 0x04000061 RID: 97
			public const int Check = 0;

			// Token: 0x04000062 RID: 98
			public const int No = 1;

			// Token: 0x04000063 RID: 99
			public const int LotID = 2;

			// Token: 0x04000064 RID: 100
			public const int Dcc = 3;

			// Token: 0x04000065 RID: 101
			public const int Device = 4;

			// Token: 0x04000066 RID: 102
			public const int Product = 5;

			// Token: 0x04000067 RID: 103
			public const int SN = 6;

			// Token: 0x04000068 RID: 104
			public const int MaxColumnCnt = 7;
		}
	}
}
