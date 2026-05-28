using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DATA;
using SourceGrid;

namespace ETC
{
	// Token: 0x02000006 RID: 6
	internal class CParsingGrid
	{
		// Token: 0x0600001A RID: 26 RVA: 0x000039DC File Offset: 0x00001BDC
		public DataTable ParseGrid_Ovv(int countOfSockets, Grid grid)
		{
			DataTable dataTable = new DataTable();
			string text = string.Empty;
			for (int i = 0; i < grid.Columns.Count; i++)
			{
				for (int j = 0; j < grid.Rows.Count; j++)
				{
					if (j == 0)
					{
						if (grid[j, i].Value != null)
						{
							text = grid[j, i].Value.ToString();
						}
						if (!dataTable.Columns.Contains(text))
						{
							dataTable.Columns.Add(text);
						}
					}
					else
					{
						if (dataTable.Rows.Count < j)
						{
							dataTable.Rows.Add(new object[0]);
						}
						string value = string.Empty;
						if (grid[j, i].Value != null)
						{
							value = grid[j, i].Value.ToString();
						}
						if (grid[j, i].Image != null)
						{
							value = "1";
						}
						dataTable.Rows[j - 1][text] = value;
					}
				}
			}
			return dataTable;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003AEC File Offset: 0x00001CEC
		public string ParseGrid_Indv_(int countOfSockets, Grid grid, int startFrom)
		{
			string text = string.Empty;
			int num = 5;
			int num2 = 4;
			int num3 = 0;
			int num4 = 1;
			int num5 = 0;
			for (int i = 1; i <= countOfSockets; i++)
			{
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				if (grid[num4 + 2, num5 + 1].Value != null)
				{
					text4 = grid[num4 + 2, num5 + 1].Value.ToString();
					if (!int.TryParse(text4, out num3))
					{
						return "";
					}
				}
				string text5 = string.Empty;
				if (grid[num4 + 3, num5 + 1].Value != null)
				{
					text5 = grid[num4 + 3, num5 + 1].Value.ToString();
					if (!int.TryParse(text5, out num3))
					{
						return "";
					}
				}
				string text6 = string.Empty;
				if (grid[num4 + 4, num5 + 1].Value != null)
				{
					text6 = grid[num4 + 4, num5 + 1].Value.ToString();
					if (!int.TryParse(text6, out num3))
					{
						return "";
					}
				}
				text2 = string.Concat(new string[]
				{
					(i - 1 + startFrom).ToString(),
					",",
					text4.Replace(',', '`').Replace(';', '`'),
					",",
					text5.Replace(',', '`').Replace(';', '`'),
					",",
					text6.Replace(',', '`').Replace(';', '`')
				});
				string text7 = string.Empty;
				if (grid[num4 + 2, num5 + 2].Value != null)
				{
					text7 = grid[num4 + 2, num5 + 2].Value.ToString();
					if (!int.TryParse(text7, out num3))
					{
						return "";
					}
				}
				string text8 = string.Empty;
				if (grid[num4 + 3, num5 + 2].Value != null)
				{
					text8 = grid[num4 + 3, num5 + 2].Value.ToString();
					if (!int.TryParse(text8, out num3))
					{
						return "";
					}
				}
				string text9 = string.Empty;
				if (grid[num4 + 4, num5 + 2].Value != null)
				{
					text9 = grid[num4 + 4, num5 + 2].Value.ToString();
					if (!int.TryParse(text9, out num3))
					{
						return "";
					}
				}
				text3 = string.Concat(new string[]
				{
					text7.Replace(',', '`').Replace(';', '`'),
					",",
					text8.Replace(',', '`').Replace(';', '`'),
					",",
					text9.Replace(',', '`').Replace(';', '`')
				});
				if (i == 1)
				{
					text = text2 + "," + text3;
				}
				else
				{
					text = string.Concat(new string[]
					{
						text,
						";",
						text2,
						",",
						text3
					});
				}
				num4 += num;
				if (num4 > 20)
				{
					num4 = 1;
					num5 += num2;
				}
			}
			string text10 = string.Empty;
			string text11 = string.Empty;
			string text12 = string.Empty;
			if (grid[num4 + 2, num5 + 1].Value != null)
			{
				text12 = grid[num4 + 2, num5 + 1].Value.ToString();
				if (!int.TryParse(text12, out num3))
				{
					return "";
				}
			}
			string text13 = string.Empty;
			if (grid[num4 + 3, num5 + 1].Value != null)
			{
				text13 = grid[num4 + 3, num5 + 1].Value.ToString();
				if (!int.TryParse(text13, out num3))
				{
					return "";
				}
			}
			string text14 = string.Empty;
			if (grid[num4 + 4, num5 + 1].Value != null)
			{
				text14 = grid[num4 + 4, num5 + 1].Value.ToString();
				if (!int.TryParse(text14, out num3))
				{
					return "";
				}
			}
			text10 = string.Concat(new string[]
			{
				"Other,",
				text12.Replace(',', '`').Replace(';', '`'),
				",",
				text13.Replace(',', '`').Replace(';', '`'),
				",",
				text14.Replace(',', '`').Replace(';', '`')
			});
			string text15 = string.Empty;
			if (grid[num4 + 2, num5 + 2].Value != null)
			{
				text15 = grid[num4 + 2, num5 + 2].Value.ToString();
				if (!int.TryParse(text15, out num3))
				{
					return "";
				}
			}
			string text16 = string.Empty;
			if (grid[num4 + 3, num5 + 2].Value != null)
			{
				text16 = grid[num4 + 3, num5 + 2].Value.ToString();
				if (!int.TryParse(text16, out num3))
				{
					return "";
				}
			}
			string text17 = string.Empty;
			if (grid[num4 + 4, num5 + 2].Value != null)
			{
				text17 = grid[num4 + 4, num5 + 2].Value.ToString();
				if (!int.TryParse(text17, out num3))
				{
					return "";
				}
			}
			text11 = string.Concat(new string[]
			{
				text15.Replace(',', '`').Replace(';', '`'),
				",",
				text16.Replace(',', '`').Replace(';', '`'),
				",",
				text17.Replace(',', '`').Replace(';', '`')
			});
			return string.Concat(new string[]
			{
				text,
				";",
				text10,
				",",
				text11
			});
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000040D4 File Offset: 0x000022D4
		public string ParseGrid_Indv2_(int countOfSockets, Grid grid, int startFrom)
		{
			string text = string.Empty;
			int num = 16;
			int num2 = 4;
			int num3 = 0;
			int num4 = 1;
			int num5 = 0;
			for (int i = 1; i <= countOfSockets; i++)
			{
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				if (grid[num4 + 2, num5 + 1].Value != null)
				{
					text4 = grid[num4 + 2, num5 + 1].Value.ToString();
					if (!int.TryParse(text4, out num3))
					{
						return "";
					}
				}
				string text5 = string.Empty;
				if (grid[num4 + 3, num5 + 1].Value != null)
				{
					text5 = grid[num4 + 3, num5 + 1].Value.ToString();
					if (!int.TryParse(text5, out num3))
					{
						return "";
					}
				}
				string text6 = string.Empty;
				if (grid[num4 + 4, num5 + 1].Value != null)
				{
					text6 = grid[num4 + 4, num5 + 1].Value.ToString();
					if (!int.TryParse(text6, out num3))
					{
						return "";
					}
				}
				text2 = string.Concat(new string[]
				{
					(i - 1 + startFrom).ToString(),
					",",
					text4,
					",",
					text5,
					",",
					text6
				});
				string text7 = string.Empty;
				if (grid[num4 + 2, num5 + 2].Value != null)
				{
					text7 = grid[num4 + 2, num5 + 2].Value.ToString();
					if (!int.TryParse(text7, out num3))
					{
						return "";
					}
				}
				string text8 = string.Empty;
				if (grid[num4 + 3, num5 + 2].Value != null)
				{
					text8 = grid[num4 + 3, num5 + 2].Value.ToString();
					if (!int.TryParse(text8, out num3))
					{
						return "";
					}
				}
				string text9 = string.Empty;
				if (grid[num4 + 4, num5 + 2].Value != null)
				{
					text9 = grid[num4 + 4, num5 + 2].Value.ToString();
					if (!int.TryParse(text9, out num3))
					{
						return "";
					}
				}
				text3 = string.Concat(new string[]
				{
					text7,
					",",
					text8,
					",",
					text9
				});
				string text10 = string.Empty;
				for (int j = 0; j < 6; j++)
				{
					if (grid[num4 + 5 + j, num5 + 1].Value == null)
					{
						return "";
					}
					if (grid[num4 + 5 + j, num5 + 1].Value.ToString() == "True")
					{
						if (j == 0)
						{
							text10 = "1";
						}
						else
						{
							text10 += ",1";
						}
					}
					else if (j == 0)
					{
						text10 = "0";
					}
					else
					{
						text10 += ",0";
					}
				}
				string text11 = string.Empty;
				for (int j = 0; j < 4; j++)
				{
					if (grid[num4 + 11 + j, num5 + 1].Value == null)
					{
						return "";
					}
					if (j == 0)
					{
						text11 = grid[num4 + 11 + j, num5 + 1].Value.ToString();
					}
					else
					{
						text11 = text11 + "," + grid[num4 + 11 + j, num5 + 1].Value.ToString();
					}
				}
				string text12 = string.Empty;
				if (grid[num4 + 15, num5 + 1].Value != null)
				{
					text12 = grid[num4 + 15, num5 + 1].Value.ToString();
				}
				if (i == 1)
				{
					text = string.Concat(new string[]
					{
						text2,
						",",
						text3,
						",",
						text10,
						",",
						text11,
						",",
						text12
					});
				}
				else
				{
					text = string.Concat(new string[]
					{
						text,
						";",
						text2,
						",",
						text3,
						",",
						text10,
						",",
						text11,
						",",
						text12
					});
				}
				num4 += num;
				if (num4 > num * num2 - 1)
				{
					num4 = 1;
					num5 += num2;
				}
			}
			string text13 = string.Empty;
			string text14 = string.Empty;
			string text15 = string.Empty;
			if (grid[num4 + 2, num5 + 1].Value != null)
			{
				text15 = grid[num4 + 2, num5 + 1].Value.ToString();
				if (!int.TryParse(text15, out num3))
				{
					return "";
				}
			}
			string text16 = string.Empty;
			if (grid[num4 + 3, num5 + 1].Value != null)
			{
				text16 = grid[num4 + 3, num5 + 1].Value.ToString();
				if (!int.TryParse(text16, out num3))
				{
					return "";
				}
			}
			string text17 = string.Empty;
			if (grid[num4 + 4, num5 + 1].Value != null)
			{
				text17 = grid[num4 + 4, num5 + 1].Value.ToString();
				if (!int.TryParse(text17, out num3))
				{
					return "";
				}
			}
			text13 = string.Concat(new string[]
			{
				"Other,",
				text15,
				",",
				text16,
				",",
				text17
			});
			string text18 = string.Empty;
			if (grid[num4 + 2, num5 + 2].Value != null)
			{
				text18 = grid[num4 + 2, num5 + 2].Value.ToString();
				if (!int.TryParse(text18, out num3))
				{
					return "";
				}
			}
			string text19 = string.Empty;
			if (grid[num4 + 3, num5 + 2].Value != null)
			{
				text19 = grid[num4 + 3, num5 + 2].Value.ToString();
				if (!int.TryParse(text19, out num3))
				{
					return "";
				}
			}
			string text20 = string.Empty;
			if (grid[num4 + 4, num5 + 2].Value != null)
			{
				text20 = grid[num4 + 4, num5 + 2].Value.ToString();
				if (!int.TryParse(text20, out num3))
				{
					return "";
				}
			}
			text14 = string.Concat(new string[]
			{
				text18,
				",",
				text19,
				",",
				text20
			});
			string text21 = string.Empty;
			for (int k = 0; k < 6; k++)
			{
				if (k == 0)
				{
					text21 = "0";
				}
				else
				{
					text21 += ",0";
				}
			}
			string text22 = string.Empty;
			for (int k = 0; k < 4; k++)
			{
				if (k == 0)
				{
					text22 = "Good";
				}
				else
				{
					text22 += ",Good";
				}
			}
			return string.Concat(new string[]
			{
				text,
				";",
				text13,
				",",
				text14,
				",",
				text21,
				",",
				text22,
				","
			});
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00004834 File Offset: 0x00002A34
		public string ParseGrid_Indv3_(int countOfSockets, Grid grid, List<CBadSocketStatus> cBadSocketStatuses, int startFrom)
		{
			string text = string.Empty;
			int num = 12;
			int num2 = 4;
			int num3 = 0;
			int num4 = 1;
			int num5 = 0;
			int i;
			int i2;
			for (i = 1; i <= countOfSockets; i = i2 + 1)
			{
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				if (grid[num4 + 2, num5 + 1].Value != null)
				{
					text4 = grid[num4 + 2, num5 + 1].Value.ToString();
					if (!int.TryParse(text4, out num3))
					{
						return "";
					}
				}
				string text5 = string.Empty;
				if (grid[num4 + 3, num5 + 1].Value != null)
				{
					text5 = grid[num4 + 3, num5 + 1].Value.ToString();
					if (!int.TryParse(text5, out num3))
					{
						return "";
					}
				}
				string text6 = string.Empty;
				if (grid[num4 + 4, num5 + 1].Value != null)
				{
					text6 = grid[num4 + 4, num5 + 1].Value.ToString();
					if (!int.TryParse(text6, out num3))
					{
						return "";
					}
				}
				text2 = string.Concat(new string[]
				{
					(i - 1 + startFrom).ToString(),
					",",
					text4.Replace(',', '`').Replace(';', '`'),
					",",
					text5.Replace(',', '`').Replace(';', '`'),
					",",
					text6.Replace(',', '`').Replace(';', '`')
				});
				string text7 = string.Empty;
				if (grid[num4 + 2, num5 + 2].Value != null)
				{
					text7 = grid[num4 + 2, num5 + 2].Value.ToString();
					if (!int.TryParse(text7, out num3))
					{
						return "";
					}
				}
				string text8 = string.Empty;
				if (grid[num4 + 3, num5 + 2].Value != null)
				{
					text8 = grid[num4 + 3, num5 + 2].Value.ToString();
					if (!int.TryParse(text8, out num3))
					{
						return "";
					}
				}
				string text9 = string.Empty;
				if (grid[num4 + 4, num5 + 2].Value != null)
				{
					text9 = grid[num4 + 4, num5 + 2].Value.ToString();
					if (!int.TryParse(text9, out num3))
					{
						return "";
					}
				}
				text3 = string.Concat(new string[]
				{
					text7.Replace(',', '`').Replace(';', '`'),
					",",
					text8.Replace(',', '`').Replace(';', '`'),
					",",
					text9.Replace(',', '`').Replace(';', '`')
				});
				string text10 = string.Empty;
				for (int k = 0; k < 2; k++)
				{
					if (grid[num4 + 5 + k, num5 + 1].Value == null)
					{
						return "";
					}
					if (grid[num4 + 5 + k, num5 + 1].Value.ToString() == "True")
					{
						if (k == 0)
						{
							text10 = "1";
						}
						else
						{
							text10 += ",1";
						}
					}
					else if (k == 0)
					{
						text10 = "0";
					}
					else
					{
						text10 += ",0";
					}
				}
				string text11 = string.Empty;
				for (int k = 0; k < 4; k++)
				{
					if (grid[num4 + 7 + k, num5 + 1].Value == null)
					{
						return "";
					}
					if (k == 0)
					{
						text11 = grid[num4 + 7 + k, num5 + 1].Value.ToString().Replace(',', '`').Replace(';', '`');
					}
					else
					{
						text11 = text11 + "," + grid[num4 + 7 + k, num5 + 1].Value.ToString().Replace(',', '`').Replace(';', '`');
					}
				}
				string text12 = string.Empty;
				if (grid[num4 + 11, num5 + 1].Value != null)
				{
					text12 = grid[num4 + 11, num5 + 1].Value.ToString().Replace(',', '`').Replace(';', '`');
				}
				string text13 = string.Empty;
				List<CBadSocketStatus> list = (from o in cBadSocketStatuses
				where o.iSocketNo == i - 1
				select o).ToList<CBadSocketStatus>();
				if (list.Count != 0)
				{
					text13 = list[0].strBadSocketStatus.Replace(',', '`').Replace(';', '`');
				}
				if (i == 1)
				{
					text = string.Concat(new string[]
					{
						text2,
						",",
						text3,
						",",
						text10,
						",",
						text11,
						",",
						text12,
						",",
						text13
					});
				}
				else
				{
					text = string.Concat(new string[]
					{
						text,
						";",
						text2,
						",",
						text3,
						",",
						text10,
						",",
						text11,
						",",
						text12,
						",",
						text13
					});
				}
				num4 += num;
				if (num4 > num * num2 - 1)
				{
					num4 = 1;
					num5 += num2;
				}
				i2 = i;
			}
			string text14 = string.Empty;
			string text15 = string.Empty;
			string text16 = string.Empty;
			if (grid[num4 + 2, num5 + 1].Value != null)
			{
				text16 = grid[num4 + 2, num5 + 1].Value.ToString();
				if (!int.TryParse(text16, out num3))
				{
					return "";
				}
			}
			string text17 = string.Empty;
			if (grid[num4 + 3, num5 + 1].Value != null)
			{
				text17 = grid[num4 + 3, num5 + 1].Value.ToString();
				if (!int.TryParse(text17, out num3))
				{
					return "";
				}
			}
			string text18 = string.Empty;
			if (grid[num4 + 4, num5 + 1].Value != null)
			{
				text18 = grid[num4 + 4, num5 + 1].Value.ToString();
				if (!int.TryParse(text18, out num3))
				{
					return "";
				}
			}
			text14 = string.Concat(new string[]
			{
				"Other,",
				text16.Replace(',', '`').Replace(';', '`'),
				",",
				text17.Replace(',', '`').Replace(';', '`'),
				",",
				text18.Replace(',', '`').Replace(';', '`')
			});
			string text19 = string.Empty;
			if (grid[num4 + 2, num5 + 2].Value != null)
			{
				text19 = grid[num4 + 2, num5 + 2].Value.ToString();
				if (!int.TryParse(text19, out num3))
				{
					return "";
				}
			}
			string text20 = string.Empty;
			if (grid[num4 + 3, num5 + 2].Value != null)
			{
				text20 = grid[num4 + 3, num5 + 2].Value.ToString();
				if (!int.TryParse(text20, out num3))
				{
					return "";
				}
			}
			string text21 = string.Empty;
			if (grid[num4 + 4, num5 + 2].Value != null)
			{
				text21 = grid[num4 + 4, num5 + 2].Value.ToString();
				if (!int.TryParse(text21, out num3))
				{
					return "";
				}
			}
			text15 = string.Concat(new string[]
			{
				text19.Replace(',', '`').Replace(';', '`'),
				",",
				text20.Replace(',', '`').Replace(';', '`'),
				",",
				text21.Replace(',', '`').Replace(';', '`')
			});
			string text22 = string.Empty;
			for (int j = 0; j < 2; j++)
			{
				if (j == 0)
				{
					text22 = "0";
				}
				else
				{
					text22 += ",0";
				}
			}
			string text23 = string.Empty;
			for (int j = 0; j < 4; j++)
			{
				if (j == 0)
				{
					text23 = "Good";
				}
				else
				{
					text23 += ",Good";
				}
			}
			return string.Concat(new string[]
			{
				text,
				";",
				text14,
				",",
				text15,
				",",
				text22,
				",",
				text23,
				","
			});
		}
	}
}
