using System;
using System.Collections;

namespace Amkor.CADModules.ESIModule.Class
{
	// Token: 0x02000017 RID: 23
	public class UnitData
	{
		// Token: 0x0600001F RID: 31 RVA: 0x0000295C File Offset: 0x00000B5C
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

		// Token: 0x040000B8 RID: 184
		public string UnitID = string.Empty;

		// Token: 0x040000B9 RID: 185
		public string SN = string.Empty;

		// Token: 0x040000BA RID: 186
		public string Status = string.Empty;

		// Token: 0x040000BB RID: 187
		public string Product = string.Empty;

		// Token: 0x040000BC RID: 188
		public string Test_station_name = string.Empty;

		// Token: 0x040000BD RID: 189
		public string Station_id = string.Empty;

		// Token: 0x040000BE RID: 190
		public string Sw_version = string.Empty;

		// Token: 0x040000BF RID: 191
		public string StartTime = string.Empty;

		// Token: 0x040000C0 RID: 192
		public string StopTime = string.Empty;

		// Token: 0x040000C1 RID: 193
		public string Failing_tests = string.Empty;

		// Token: 0x040000C2 RID: 194
		public string Failure_message = string.Empty;

		// Token: 0x040000C3 RID: 195
		public string Fail_Value = string.Empty;

		// Token: 0x040000C4 RID: 196
		public DateTime Indate;

		// Token: 0x040000C5 RID: 197
		public string Comment = string.Empty;

		// Token: 0x040000C6 RID: 198
		public string Num = string.Empty;

		// Token: 0x040000C7 RID: 199
		public string result = string.Empty;

		// Token: 0x040000C8 RID: 200
		public string LotID = string.Empty;

		// Token: 0x040000C9 RID: 201
		public string Dcc = string.Empty;

		// Token: 0x040000CA RID: 202
		public string TestHeadId = string.Empty;

		// Token: 0x040000CB RID: 203
		public double TestTime;

		// Token: 0x040000CC RID: 204
		public string Device = string.Empty;

		// Token: 0x040000CD RID: 205
		public string Fail_FT = string.Empty;

		// Token: 0x040000CE RID: 206
		public string FT_1_Value = string.Empty;

		// Token: 0x040000CF RID: 207
		public string FT_1_Units = string.Empty;

		// Token: 0x040000D0 RID: 208
		public string FT_1_Upper_Limit = string.Empty;

		// Token: 0x040000D1 RID: 209
		public string FT_1_Lower_Limit = string.Empty;

		// Token: 0x040000D2 RID: 210
		public string Fail_FT2 = string.Empty;

		// Token: 0x040000D3 RID: 211
		public string FT_2_Value = string.Empty;

		// Token: 0x040000D4 RID: 212
		public string FT_2_Units = string.Empty;

		// Token: 0x040000D5 RID: 213
		public string FT_2_Upper_Limit = string.Empty;

		// Token: 0x040000D6 RID: 214
		public string FT_2_Lower_Limit = string.Empty;

		// Token: 0x040000D7 RID: 215
		public string Fail_FT3 = string.Empty;

		// Token: 0x040000D8 RID: 216
		public string FT_3_Value = string.Empty;

		// Token: 0x040000D9 RID: 217
		public string FT_3_Units = string.Empty;

		// Token: 0x040000DA RID: 218
		public string FT_3_Upper_Limit = string.Empty;

		// Token: 0x040000DB RID: 219
		public string FT_3_Lower_Limit = string.Empty;

		// Token: 0x040000DC RID: 220
		public string Fail_FT4 = string.Empty;

		// Token: 0x040000DD RID: 221
		public string FT_4_Value = string.Empty;

		// Token: 0x040000DE RID: 222
		public string FT_4_Units = string.Empty;

		// Token: 0x040000DF RID: 223
		public string FT_4_Upper_Limit = string.Empty;

		// Token: 0x040000E0 RID: 224
		public string FT_4_Lower_Limit = string.Empty;

		// Token: 0x040000E1 RID: 225
		public string Fail_FT5 = string.Empty;

		// Token: 0x040000E2 RID: 226
		public string FT_5_Value = string.Empty;

		// Token: 0x040000E3 RID: 227
		public string FT_5_Units = string.Empty;

		// Token: 0x040000E4 RID: 228
		public string FT_5_Upper_Limit = string.Empty;

		// Token: 0x040000E5 RID: 229
		public string FT_5_Lower_Limit = string.Empty;

		// Token: 0x040000E6 RID: 230
		public string AuditMode = string.Empty;

		// Token: 0x040000E7 RID: 231
		public string CheckInFlag = string.Empty;

		// Token: 0x040000E8 RID: 232
		public SortedList slSeq = new SortedList();
	}
}
