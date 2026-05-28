using System;
using System.Collections;

namespace Amkor.CADModules.UnitDataProcModule.DataClass
{
	// Token: 0x0200000D RID: 13
	public class UnitData
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00007B3C File Offset: 0x00005D3C
		public void setFailData()
		{
			if (this.Fail_Value == string.Empty)
			{
				return;
			}
			string[] array = this.Fail_Value.Split(new char[]
			{
				','
			});
			if (array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(new char[]
					{
						'='
					});
					string text = string.Empty;
					if (array2.Length > 1)
					{
						text = array2[0];
						string key;
						switch (key = text)
						{
						case "ft_1_test":
							this.Fail_FT = array[i].Replace("ft_1_test=", "");
							break;
						case "ft_1_sub_test":
							this.Fail_FT += "@";
							this.Fail_FT += array[i].Replace("ft_1_sub_test=", "");
							break;
						case "ft_1_sub_sub_test":
							this.Fail_FT += "@";
							this.Fail_FT += array[i].Replace("ft_1_sub_sub_test=", "");
							break;
						case "ft_1_value":
							this.FT_1_Value = array[i].Replace("ft_1_value=", "");
							break;
						case "ft_1_units":
							this.FT_1_Units = array[i].Replace("ft_1_units=", "");
							break;
						case "ft_1_upper_limit":
							this.FT_1_Upper_Limit = array[i].Replace("ft_1_upper_limit=", "");
							break;
						case "ft_1_lower_limit":
							this.FT_1_Lower_Limit = array[i].Replace("ft_1_lower_limit=", "");
							break;
						case "ft_2_test":
							this.Fail_FT2 = array[i].Replace("ft_2_test=", "");
							break;
						case "ft_2_sub_test":
							this.Fail_FT2 += "@";
							this.Fail_FT2 += array[i].Replace("ft_2_sub_test=", "");
							break;
						case "ft_2_sub_sub_test":
							this.Fail_FT2 += "@";
							this.Fail_FT2 += array[i].Replace("ft_2_sub_sub_test=", "");
							break;
						case "ft_2_value":
							this.FT_2_Value = array[i].Replace("ft_2_value=", "");
							break;
						case "ft_2_units":
							this.FT_2_Units = array[i].Replace("ft_2_units=", "");
							break;
						case "ft_2_upper_limit":
							this.FT_2_Upper_Limit = array[i].Replace("ft_2_upper_limit=", "");
							break;
						case "ft_2_lower_limit":
							this.FT_2_Lower_Limit = array[i].Replace("ft_2_lower_limit=", "");
							break;
						case "ft_3_test":
							this.Fail_FT3 = array[i].Replace("ft_3_test=", "");
							break;
						case "ft_3_sub_test":
							this.Fail_FT3 += "@";
							this.Fail_FT3 += array[i].Replace("ft_3_sub_test=", "");
							break;
						case "ft_3_sub_sub_test":
							this.Fail_FT3 += "@";
							this.Fail_FT3 += array[i].Replace("ft_3_sub_sub_test=", "");
							break;
						case "ft_3_value":
							this.FT_3_Value = array[i].Replace("ft_3_value=", "");
							break;
						case "ft_3_units":
							this.FT_3_Units = array[i].Replace("ft_3_units=", "");
							break;
						case "ft_3_upper_limit":
							this.FT_3_Upper_Limit = array[i].Replace("ft_3_upper_limit=", "");
							break;
						case "ft_3_lower_limit":
							this.FT_3_Lower_Limit = array[i].Replace("ft_3_lower_limit=", "");
							break;
						case "ft_4_test":
							this.Fail_FT4 = array[i].Replace("ft_4_test=", "");
							break;
						case "ft_4_sub_test":
							this.Fail_FT4 += "@";
							this.Fail_FT4 += array[i].Replace("ft_4_sub_test=", "");
							break;
						case "ft_4_sub_sub_test":
							this.Fail_FT4 += "@";
							this.Fail_FT4 += array[i].Replace("ft_4_sub_sub_test=", "");
							break;
						case "ft_4_value":
							this.FT_4_Value = array[i].Replace("ft_4_value=", "");
							break;
						case "ft_4_units":
							this.FT_4_Units = array[i].Replace("ft_4_units=", "");
							break;
						case "ft_4_upper_limit":
							this.FT_4_Upper_Limit = array[i].Replace("ft_4_upper_limit=", "");
							break;
						case "ft_4_lower_limit":
							this.FT_4_Lower_Limit = array[i].Replace("ft_4_lower_limit=", "");
							break;
						case "ft_5_test":
							this.Fail_FT5 = array[i].Replace("ft_5_test=", "");
							break;
						case "ft_5_sub_test":
							this.Fail_FT5 += "@";
							this.Fail_FT5 += array[i].Replace("ft_5_sub_test=", "");
							break;
						case "ft_5_sub_sub_test":
							this.Fail_FT5 += "@";
							this.Fail_FT5 += array[i].Replace("ft_5_sub_sub_test=", "");
							break;
						case "ft_5_value":
							this.FT_5_Value = array[i].Replace("ft_5_value=", "");
							break;
						case "ft_5_units":
							this.FT_5_Units = array[i].Replace("ft_5_units=", "");
							break;
						case "ft_5_upper_limit":
							this.FT_5_Upper_Limit = array[i].Replace("ft_5_upper_limit=", "");
							break;
						case "ft_5_lower_limit":
							this.FT_5_Lower_Limit = array[i].Replace("ft_5_lower_limit=", "");
							break;
						}
					}
				}
			}
		}

		// Token: 0x0400004A RID: 74
		public string UnitID = string.Empty;

		// Token: 0x0400004B RID: 75
		public string UN = string.Empty;

		// Token: 0x0400004C RID: 76
		public string SN = string.Empty;

		// Token: 0x0400004D RID: 77
		public string Status = string.Empty;

		// Token: 0x0400004E RID: 78
		public string Product = string.Empty;

		// Token: 0x0400004F RID: 79
		public string Test_station_name = string.Empty;

		// Token: 0x04000050 RID: 80
		public string Tester = string.Empty;

		// Token: 0x04000051 RID: 81
		public string Station_id = string.Empty;

		// Token: 0x04000052 RID: 82
		public string Sw_version = string.Empty;

		// Token: 0x04000053 RID: 83
		public string StartTime = string.Empty;

		// Token: 0x04000054 RID: 84
		public string StopTime = string.Empty;

		// Token: 0x04000055 RID: 85
		public string Failing_tests = string.Empty;

		// Token: 0x04000056 RID: 86
		public string Failure_message = string.Empty;

		// Token: 0x04000057 RID: 87
		public string Fail_Value = string.Empty;

		// Token: 0x04000058 RID: 88
		public string TesterID = string.Empty;

		// Token: 0x04000059 RID: 89
		public string Program = string.Empty;

		// Token: 0x0400005A RID: 90
		public double dTestTime;

		// Token: 0x0400005B RID: 91
		public DateTime Indate;

		// Token: 0x0400005C RID: 92
		public string Comment = string.Empty;

		// Token: 0x0400005D RID: 93
		public int Num;

		// Token: 0x0400005E RID: 94
		public string result = string.Empty;

		// Token: 0x0400005F RID: 95
		public string LotID = string.Empty;

		// Token: 0x04000060 RID: 96
		public string Dcc = string.Empty;

		// Token: 0x04000061 RID: 97
		public string TestHeadId = string.Empty;

		// Token: 0x04000062 RID: 98
		public double TestTime;

		// Token: 0x04000063 RID: 99
		public string Device = string.Empty;

		// Token: 0x04000064 RID: 100
		public string Site = string.Empty;

		// Token: 0x04000065 RID: 101
		public string HBin = string.Empty;

		// Token: 0x04000066 RID: 102
		public string SBin = string.Empty;

		// Token: 0x04000067 RID: 103
		public string SpecFlow = string.Empty;

		// Token: 0x04000068 RID: 104
		public string ECID = string.Empty;

		// Token: 0x04000069 RID: 105
		public string FM_Ver = string.Empty;

		// Token: 0x0400006A RID: 106
		public string Fail_FT = string.Empty;

		// Token: 0x0400006B RID: 107
		public string FT_1_Value = string.Empty;

		// Token: 0x0400006C RID: 108
		public string FT_1_Units = string.Empty;

		// Token: 0x0400006D RID: 109
		public string FT_1_Upper_Limit = string.Empty;

		// Token: 0x0400006E RID: 110
		public string FT_1_Lower_Limit = string.Empty;

		// Token: 0x0400006F RID: 111
		public string Fail_FT2 = string.Empty;

		// Token: 0x04000070 RID: 112
		public string FT_2_Value = string.Empty;

		// Token: 0x04000071 RID: 113
		public string FT_2_Units = string.Empty;

		// Token: 0x04000072 RID: 114
		public string FT_2_Upper_Limit = string.Empty;

		// Token: 0x04000073 RID: 115
		public string FT_2_Lower_Limit = string.Empty;

		// Token: 0x04000074 RID: 116
		public string Fail_FT3 = string.Empty;

		// Token: 0x04000075 RID: 117
		public string FT_3_Value = string.Empty;

		// Token: 0x04000076 RID: 118
		public string FT_3_Units = string.Empty;

		// Token: 0x04000077 RID: 119
		public string FT_3_Upper_Limit = string.Empty;

		// Token: 0x04000078 RID: 120
		public string FT_3_Lower_Limit = string.Empty;

		// Token: 0x04000079 RID: 121
		public string Fail_FT4 = string.Empty;

		// Token: 0x0400007A RID: 122
		public string FT_4_Value = string.Empty;

		// Token: 0x0400007B RID: 123
		public string FT_4_Units = string.Empty;

		// Token: 0x0400007C RID: 124
		public string FT_4_Upper_Limit = string.Empty;

		// Token: 0x0400007D RID: 125
		public string FT_4_Lower_Limit = string.Empty;

		// Token: 0x0400007E RID: 126
		public string Fail_FT5 = string.Empty;

		// Token: 0x0400007F RID: 127
		public string FT_5_Value = string.Empty;

		// Token: 0x04000080 RID: 128
		public string FT_5_Units = string.Empty;

		// Token: 0x04000081 RID: 129
		public string FT_5_Upper_Limit = string.Empty;

		// Token: 0x04000082 RID: 130
		public string FT_5_Lower_Limit = string.Empty;

		// Token: 0x04000083 RID: 131
		public string CheckInFlag = string.Empty;

		// Token: 0x04000084 RID: 132
		public SortedList slSeq = new SortedList();
	}
}
