using System;
using System.Collections;

namespace Amkor.CADModules.SAMSUNGModule.Class
{
	// Token: 0x02000012 RID: 18
	public class UnitData
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00002914 File Offset: 0x00000B14
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

		// Token: 0x04000078 RID: 120
		public string UnitID = string.Empty;

		// Token: 0x04000079 RID: 121
		public string UN = string.Empty;

		// Token: 0x0400007A RID: 122
		public string SN = string.Empty;

		// Token: 0x0400007B RID: 123
		public string Status = string.Empty;

		// Token: 0x0400007C RID: 124
		public string Product = string.Empty;

		// Token: 0x0400007D RID: 125
		public string Test_station_name = string.Empty;

		// Token: 0x0400007E RID: 126
		public string Tester = string.Empty;

		// Token: 0x0400007F RID: 127
		public string Station_id = string.Empty;

		// Token: 0x04000080 RID: 128
		public string Sw_version = string.Empty;

		// Token: 0x04000081 RID: 129
		public string StartTime = string.Empty;

		// Token: 0x04000082 RID: 130
		public string StopTime = string.Empty;

		// Token: 0x04000083 RID: 131
		public string Failing_tests = string.Empty;

		// Token: 0x04000084 RID: 132
		public string Failure_message = string.Empty;

		// Token: 0x04000085 RID: 133
		public string Fail_Value = string.Empty;

		// Token: 0x04000086 RID: 134
		public DateTime Indate;

		// Token: 0x04000087 RID: 135
		public string Comment = string.Empty;

		// Token: 0x04000088 RID: 136
		public string Num = string.Empty;

		// Token: 0x04000089 RID: 137
		public string result = string.Empty;

		// Token: 0x0400008A RID: 138
		public string LotID = string.Empty;

		// Token: 0x0400008B RID: 139
		public string Dcc = string.Empty;

		// Token: 0x0400008C RID: 140
		public string TestHeadId = string.Empty;

		// Token: 0x0400008D RID: 141
		public double TestTime;

		// Token: 0x0400008E RID: 142
		public string Device = string.Empty;

		// Token: 0x0400008F RID: 143
		public string HBin = string.Empty;

		// Token: 0x04000090 RID: 144
		public string SBin = string.Empty;

		// Token: 0x04000091 RID: 145
		public string Fail_FT = string.Empty;

		// Token: 0x04000092 RID: 146
		public string FT_1_Value = string.Empty;

		// Token: 0x04000093 RID: 147
		public string FT_1_Units = string.Empty;

		// Token: 0x04000094 RID: 148
		public string FT_1_Upper_Limit = string.Empty;

		// Token: 0x04000095 RID: 149
		public string FT_1_Lower_Limit = string.Empty;

		// Token: 0x04000096 RID: 150
		public string Fail_FT2 = string.Empty;

		// Token: 0x04000097 RID: 151
		public string FT_2_Value = string.Empty;

		// Token: 0x04000098 RID: 152
		public string FT_2_Units = string.Empty;

		// Token: 0x04000099 RID: 153
		public string FT_2_Upper_Limit = string.Empty;

		// Token: 0x0400009A RID: 154
		public string FT_2_Lower_Limit = string.Empty;

		// Token: 0x0400009B RID: 155
		public string Fail_FT3 = string.Empty;

		// Token: 0x0400009C RID: 156
		public string FT_3_Value = string.Empty;

		// Token: 0x0400009D RID: 157
		public string FT_3_Units = string.Empty;

		// Token: 0x0400009E RID: 158
		public string FT_3_Upper_Limit = string.Empty;

		// Token: 0x0400009F RID: 159
		public string FT_3_Lower_Limit = string.Empty;

		// Token: 0x040000A0 RID: 160
		public string Fail_FT4 = string.Empty;

		// Token: 0x040000A1 RID: 161
		public string FT_4_Value = string.Empty;

		// Token: 0x040000A2 RID: 162
		public string FT_4_Units = string.Empty;

		// Token: 0x040000A3 RID: 163
		public string FT_4_Upper_Limit = string.Empty;

		// Token: 0x040000A4 RID: 164
		public string FT_4_Lower_Limit = string.Empty;

		// Token: 0x040000A5 RID: 165
		public string Fail_FT5 = string.Empty;

		// Token: 0x040000A6 RID: 166
		public string FT_5_Value = string.Empty;

		// Token: 0x040000A7 RID: 167
		public string FT_5_Units = string.Empty;

		// Token: 0x040000A8 RID: 168
		public string FT_5_Upper_Limit = string.Empty;

		// Token: 0x040000A9 RID: 169
		public string FT_5_Lower_Limit = string.Empty;

		// Token: 0x040000AA RID: 170
		public string CheckInFlag = string.Empty;

		// Token: 0x040000AB RID: 171
		public SortedList slSeq = new SortedList();
	}
}
