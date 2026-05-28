using System;
using System.Collections.Generic;
using System.Drawing;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.GrobalConst.Class
{
	// Token: 0x02000018 RID: 24
	public class SiteMap
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00006401 File Offset: 0x00004601
		// (set) Token: 0x06000069 RID: 105 RVA: 0x000063F8 File Offset: 0x000045F8
		public string SPLITCHAR { get; private set; } = "@";

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00006412 File Offset: 0x00004612
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00006409 File Offset: 0x00004609
		public string SITEPANEL { get; private set; } = "SITE";

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00006423 File Offset: 0x00004623
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000641A File Offset: 0x0000461A
		public string STATUSLABEL { get; private set; } = "STATUS";

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00006434 File Offset: 0x00004634
		// (set) Token: 0x0600006F RID: 111 RVA: 0x0000642B File Offset: 0x0000462B
		public string NUMBERPANEL { get; private set; } = "NUMBER";

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00006445 File Offset: 0x00004645
		// (set) Token: 0x06000071 RID: 113 RVA: 0x0000643C File Offset: 0x0000463C
		public string CHACKLABEL_COL { get; private set; } = "CBCOL";

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00006456 File Offset: 0x00004656
		// (set) Token: 0x06000073 RID: 115 RVA: 0x0000644D File Offset: 0x0000464D
		public string CHACKLABEL_ROW { get; private set; } = "CBROW";

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00006467 File Offset: 0x00004667
		// (set) Token: 0x06000075 RID: 117 RVA: 0x0000645E File Offset: 0x0000465E
		public string GOOD { get; private set; } = "Good";

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00006478 File Offset: 0x00004678
		// (set) Token: 0x06000077 RID: 119 RVA: 0x0000646F File Offset: 0x0000466F
		public string REJECT { get; private set; } = "Reject";

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00006489 File Offset: 0x00004689
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00006480 File Offset: 0x00004680
		public string DISABLE { get; private set; } = "Disable";

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000649A File Offset: 0x0000469A
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00006491 File Offset: 0x00004691
		public string HARDWARE { get; private set; } = "HARDWARE";

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000064AB File Offset: 0x000046AB
		// (set) Token: 0x0600007D RID: 125 RVA: 0x000064A2 File Offset: 0x000046A2
		public string CONTACT { get; private set; } = "CONTACT";

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000080 RID: 128 RVA: 0x000064BC File Offset: 0x000046BC
		// (set) Token: 0x0600007F RID: 127 RVA: 0x000064B3 File Offset: 0x000046B3
		public string FUNCTION { get; private set; } = "FUNCTION";

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000064CD File Offset: 0x000046CD
		// (set) Token: 0x06000081 RID: 129 RVA: 0x000064C4 File Offset: 0x000046C4
		public string OTHER { get; private set; } = "OTHER";

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000084 RID: 132 RVA: 0x000064DE File Offset: 0x000046DE
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000064D5 File Offset: 0x000046D5
		public Color GOOD_COLOR { get; private set; } = Color.LimeGreen;

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000086 RID: 134 RVA: 0x000064EF File Offset: 0x000046EF
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000064E6 File Offset: 0x000046E6
		public Color REJECT_COLOR { get; private set; } = Color.Red;

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00006500 File Offset: 0x00004700
		// (set) Token: 0x06000087 RID: 135 RVA: 0x000064F7 File Offset: 0x000046F7
		public Color DISABLE_COLOR { get; private set; } = Color.Gray;

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00006511 File Offset: 0x00004711
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00006508 File Offset: 0x00004708
		public Color OVERLAB_REJECT_COLOR { get; private set; } = Color.Orange;

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00006522 File Offset: 0x00004722
		// (set) Token: 0x0600008B RID: 139 RVA: 0x00006519 File Offset: 0x00004719
		public Color NOTUSE_COLOR { get; private set; } = Color.White;

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00006533 File Offset: 0x00004733
		// (set) Token: 0x0600008D RID: 141 RVA: 0x0000652A File Offset: 0x0000472A
		public Dictionary<string, Dictionary<string, List<string>>> factors { get; set; } = new Dictionary<string, Dictionary<string, List<string>>>();

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00006544 File Offset: 0x00004744
		// (set) Token: 0x0600008F RID: 143 RVA: 0x0000653B File Offset: 0x0000473B
		public string[] mapData { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00006555 File Offset: 0x00004755
		// (set) Token: 0x06000091 RID: 145 RVA: 0x0000654C File Offset: 0x0000474C
		public int _iGood { get; private set; } = 0;

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00006566 File Offset: 0x00004766
		// (set) Token: 0x06000093 RID: 147 RVA: 0x0000655D File Offset: 0x0000475D
		public int _iReject { get; private set; } = 0;

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00006577 File Offset: 0x00004777
		// (set) Token: 0x06000095 RID: 149 RVA: 0x0000656E File Offset: 0x0000476E
		public int _iDisable { get; private set; } = 0;

		// Token: 0x06000097 RID: 151 RVA: 0x00006580 File Offset: 0x00004780
		public SiteMap(FactorySettings factorySettings, string factory)
		{
			this._factorySettings = factorySettings;
			this.factors = cFunction.getFactorList(this._factorySettings, SYSTEMTYPE.SITMAP_FACTOR, factory, "All");
			this.mapData = null;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000066A4 File Offset: 0x000048A4
		public void siteFactor()
		{
			this.factors.Add("REJECT", new Dictionary<string, List<string>>());
			this.factors["REJECT"].Add("HARDWARE", new List<string>());
			this.factors["REJECT"]["HARDWARE"].Add("PCB DAMAGE");
			this.factors["REJECT"]["HARDWARE"].Add("COMPONENT");
			this.factors["REJECT"]["HARDWARE"].Add("RELAY");
			this.factors["REJECT"]["HARDWARE"].Add("IC");
			this.factors["REJECT"]["HARDWARE"].Add("CONNECTOR");
			this.factors["REJECT"]["HARDWARE"].Add("PEMNUT");
			this.factors["REJECT"]["HARDWARE"].Add("SCREW");
			this.factors["REJECT"]["HARDWARE"].Add("GOLD PAD");
			this.factors["REJECT"]["HARDWARE"].Add("CABLE");
			this.factors["REJECT"]["HARDWARE"].Add("BUSHING");
			this.factors["REJECT"].Add("CONTACT", new List<string>());
			this.factors["REJECT"]["CONTACT"].Add("CONT");
			this.factors["REJECT"]["CONTACT"].Add("DPS SHORT");
			this.factors["REJECT"]["CONTACT"].Add("DC CURRENT");
			this.factors["REJECT"]["CONTACT"].Add("CMUX");
			this.factors["REJECT"]["CONTACT"].Add("FMUX");
			this.factors["REJECT"]["CONTACT"].Add("DIRECT");
			this.factors["REJECT"].Add("FUNCTION", new List<string>());
			this.factors["REJECT"]["FUNCTION"].Add("HSIO");
			this.factors["REJECT"]["FUNCTION"].Add("BSDL");
			this.factors["REJECT"]["FUNCTION"].Add("VOLH");
			this.factors["REJECT"]["FUNCTION"].Add("QFPROM");
			this.factors["REJECT"]["FUNCTION"].Add("DC LKG");
			this.factors["REJECT"]["FUNCTION"].Add("JTAG");
			this.factors["REJECT"]["FUNCTION"].Add("ICCSTANDBY");
			this.factors["REJECT"]["FUNCTION"].Add("AN PLL");
			this.factors["REJECT"]["FUNCTION"].Add("MBIST");
			this.factors["REJECT"]["FUNCTION"].Add("TSENSE");
			this.factors["REJECT"].Add("OTHER", new List<string>());
			this.factors["REJECT"]["OTHER"].Add("ENG'R REQUEST");
			this.factors["REJECT"]["OTHER"].Add("CUSTOMER REQUEST");
			this.factors["REJECT"]["OTHER"].Add("AWW REQUEST");
			this.factors["REJECT"]["OTHER"].Add("OUTSOURCING");
			this.factors.Add("DISABLE", new Dictionary<string, List<string>>());
			this.factors["DISABLE"].Add("DISABLE", new List<string>());
			this.factors["DISABLE"]["DISABLE"].Add("DISABLE1");
			this.factors["DISABLE"]["DISABLE"].Add("DISABLE2");
			this.factors["DISABLE"]["DISABLE"].Add("DISABLE3");
			this.factors["DISABLE"]["DISABLE"].Add("DISABLE4");
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006C68 File Offset: 0x00004E68
		public string convertHTMLSitemap(HCCParameter parameter, bool realMap, string report)
		{
			string text = "<div><table style='border:1px solid black;'>";
			string[] array = cFunction.getBoardSiteMap(this._factorySettings, parameter.location, realMap, report).Trim().Split(new char[]
			{
				'|'
			});
			bool flag = array == null || array.Length == 0 || array.Length == 1;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				int num = 0;
				this._iGood = 0;
				this._iReject = 0;
				this._iDisable = 0;
				switch (parameter.siteDirection)
				{
				case SITE_DRIECTION.NONE:
				{
					string[] array2 = parameter.numberOfSite.Split(new char[]
					{
						','
					});
					int num2 = 1;
					for (int i = 0; i < parameter.siteCol; i++)
					{
						text += "<tr>";
						for (int j = 0; j < parameter.siteRow; j++)
						{
							text += "<td>";
							bool flag2 = array2[num].Trim() == "0";
							if (flag2)
							{
								text += "<td style ='border:1px solid black;'>N/A</td>";
							}
							else
							{
								string empty = string.Empty;
								string text2 = "WHITE";
								this.siteCheck(array[num].Split(new char[]
								{
									'@'
								}), num2++, out empty, out text2);
								text = string.Concat(new string[]
								{
									text,
									"<td bgcolor='",
									text2,
									"'>",
									empty,
									"</td>"
								});
							}
							num++;
						}
						text += "</tr>";
					}
					break;
				}
				case SITE_DRIECTION.RIGHT:
					for (int k = 0; k < parameter.siteCol; k++)
					{
						text += "<tr>";
						for (int l = 0; l < parameter.siteRow; l++)
						{
							string empty2 = string.Empty;
							string text3 = "WHITE";
							this.siteCheck(array[parameter.siteRow * k + l].Split(new char[]
							{
								'@'
							}), out empty2, out text3);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text3,
								"'>",
								empty2,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.DOWN:
					for (int m = 0; m < parameter.siteCol; m++)
					{
						text += "<tr>";
						for (int n = 0; n < parameter.siteRow; n++)
						{
							string empty3 = string.Empty;
							string text4 = "WHITE";
							this.siteCheck(array[parameter.siteCol * n + m].Split(new char[]
							{
								'@'
							}), out empty3, out text4);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text4,
								"'>",
								empty3,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.LEFT:
					for (int num3 = 0; num3 < parameter.siteCol; num3++)
					{
						text += "<tr>";
						for (int num4 = 0; num4 < parameter.siteRow; num4++)
						{
							string empty4 = string.Empty;
							string text5 = "WHITE";
							this.siteCheck(array[parameter.siteRow - num4 - 1 + num3 * parameter.siteRow].Split(new char[]
							{
								'@'
							}), out empty4, out text5);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text5,
								"'>",
								empty4,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.UP:
					for (int num5 = 0; num5 < parameter.siteCol; num5++)
					{
						text += "<tr>";
						for (int num6 = 0; num6 < parameter.siteRow; num6++)
						{
							string empty5 = string.Empty;
							string text6 = "WHITE";
							this.siteCheck(array[parameter.siteCol * (num6 + 1) - 1 - num5].Split(new char[]
							{
								'@'
							}), out empty5, out text6);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text6,
								"'>",
								empty5,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.RIGHT_DOWN_RIGHT:
					for (int num7 = 0; num7 < parameter.siteCol; num7++)
					{
						text += "<tr>";
						for (int num8 = 0; num8 < parameter.siteRow; num8++)
						{
							string empty6 = string.Empty;
							string text7 = "WHITE";
							this.siteCheck(array[parameter.siteRow * num7 + num8].Split(new char[]
							{
								'@'
							}), out empty6, out text7);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text7,
								"'>",
								empty6,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.LEFT_UP_LEFT:
					for (int num9 = 0; num9 < parameter.siteCol; num9++)
					{
						text += "<tr>";
						for (int num10 = 0; num10 < parameter.siteRow; num10++)
						{
							string empty7 = string.Empty;
							string text8 = "WHITE";
							this.siteCheck(array[parameter.siteCol * parameter.siteRow - parameter.siteRow * num9 - num10 - 1].Split(new char[]
							{
								'@'
							}), out empty7, out text8);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text8,
								"'>",
								empty7,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.DOWN_RIGHT_DOWN:
					for (int num11 = 0; num11 < parameter.siteCol; num11++)
					{
						text += "<tr>";
						for (int num12 = 0; num12 < parameter.siteRow; num12++)
						{
							string empty8 = string.Empty;
							string text9 = "WHITE";
							this.siteCheck(array[parameter.siteCol * num12 + num11].Split(new char[]
							{
								'@'
							}), out empty8, out text9);
							text = string.Concat(new string[]
							{
								text,
								"<td width='100' bgcolor ='",
								text9,
								"'>",
								empty8,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.UP_LEFT_UP:
					for (int num13 = 0; num13 < parameter.siteCol; num13++)
					{
						text += "<tr>";
						for (int num14 = 0; num14 < parameter.siteRow; num14++)
						{
							string empty9 = string.Empty;
							string text10 = "WHITE";
							this.siteCheck(array[parameter.siteRow * parameter.siteCol - parameter.siteCol * num14 - num13 - 1].Split(new char[]
							{
								'@'
							}), out empty9, out text10);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text10,
								"'>",
								empty9,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.LEFT_DOWN_LEFT:
					for (int num15 = 0; num15 < parameter.siteCol; num15++)
					{
						text += "<tr>";
						for (int num16 = 0; num16 < parameter.siteRow; num16++)
						{
							string empty10 = string.Empty;
							string text11 = "WHITE";
							this.siteCheck(array[parameter.siteRow - num16 - 1 + num15 * parameter.siteRow].Split(new char[]
							{
								'@'
							}), out empty10, out text11);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text11,
								"'>",
								empty10,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.RIGHT_UP_RIGHT:
					for (int num17 = 0; num17 < parameter.siteCol; num17++)
					{
						text += "<tr>";
						for (int num18 = 0; num18 < parameter.siteRow; num18++)
						{
							string empty11 = string.Empty;
							string text12 = "WHITE";
							this.siteCheck(array[parameter.siteCol * parameter.siteRow - parameter.siteRow * num17 - parameter.siteRow + num18].Split(new char[]
							{
								'@'
							}), out empty11, out text12);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text12,
								"'>",
								empty11,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.DOWN_LEFT_DOWN:
					for (int num19 = 0; num19 < parameter.siteCol; num19++)
					{
						text += "<tr>";
						for (int num20 = 0; num20 < parameter.siteRow; num20++)
						{
							string empty12 = string.Empty;
							string text13 = "WHITE";
							this.siteCheck(array[parameter.siteRow * parameter.siteCol - parameter.siteCol * (num20 + 1) + num19].Split(new char[]
							{
								'@'
							}), out empty12, out text13);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text13,
								"'>",
								empty12,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				case SITE_DRIECTION.UP_RIGHT_UP:
					for (int num21 = 0; num21 < parameter.siteCol; num21++)
					{
						text += "<tr>";
						for (int num22 = 0; num22 < parameter.siteRow; num22++)
						{
							string empty13 = string.Empty;
							string text14 = "WHITE";
							this.siteCheck(array[parameter.siteCol * (num22 + 1) - 1 - num21].Split(new char[]
							{
								'@'
							}), out empty13, out text14);
							text = string.Concat(new string[]
							{
								text,
								"<td bgcolor='",
								text14,
								"'>",
								empty13,
								"</td>"
							});
						}
						text += "</tr>";
					}
					break;
				}
				text += "</table></div>";
				result = text;
			}
			return result;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00007834 File Offset: 0x00005A34
		public void siteCheck(string[] siteInformation, out string data, out string backgroud)
		{
			bool flag = siteInformation.Length != 3;
			if (flag)
			{
				data = string.Empty;
				backgroud = "WHITE";
			}
			else
			{
				SITESTATUS sitestatus = (SITESTATUS)Convert.ToInt32(siteInformation[1]);
				switch (sitestatus)
				{
				case SITESTATUS.GOOD:
				{
					int num = this._iGood;
					this._iGood = num + 1;
					break;
				}
				case SITESTATUS.REJECT:
				{
					int num = this._iReject;
					this._iReject = num + 1;
					break;
				}
				case SITESTATUS.DISABLE:
				{
					int num = this._iDisable;
					this._iDisable = num + 1;
					break;
				}
				}
				data = string.Concat(new string[]
				{
					"<div style='color:black;'>",
					siteInformation[0],
					"</div><div style='color:black;'>",
					(siteInformation[2].Length <= 6) ? siteInformation[2] : (siteInformation[2].Substring(0, 6) + "....."),
					"</div>"
				});
				backgroud = ((sitestatus == SITESTATUS.GOOD) ? "LIMEGREEN" : ((sitestatus == SITESTATUS.DISABLE) ? "GRAY" : ((siteInformation[2].IndexOf(',') == -1) ? "RED" : "RED")));
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007944 File Offset: 0x00005B44
		public void siteCheck(string[] siteInformation, int sitenumber, out string data, out string backgroud)
		{
			bool flag = siteInformation.Length != 3;
			if (flag)
			{
				data = string.Empty;
				backgroud = "WHITE";
			}
			else
			{
				SITESTATUS sitestatus = (SITESTATUS)Convert.ToInt32(siteInformation[1]);
				switch (sitestatus)
				{
				case SITESTATUS.GOOD:
				{
					int num = this._iGood;
					this._iGood = num + 1;
					break;
				}
				case SITESTATUS.REJECT:
				{
					int num = this._iReject;
					this._iReject = num + 1;
					break;
				}
				case SITESTATUS.DISABLE:
				{
					int num = this._iDisable;
					this._iDisable = num + 1;
					break;
				}
				}
				data = string.Concat(new string[]
				{
					"<div style='color:black;'>",
					sitenumber.ToString(),
					"</div><div style='color:black;'>",
					(siteInformation[2].Length <= 6) ? siteInformation[2] : (siteInformation[2].Substring(0, 6) + "....."),
					"</div>"
				});
				backgroud = ((sitestatus == SITESTATUS.GOOD) ? "LIMEGREEN" : ((sitestatus == SITESTATUS.DISABLE) ? "GRAY" : ((siteInformation[2].IndexOf(',') == -1) ? "RED" : "ORANGE")));
			}
		}

		// Token: 0x040000FA RID: 250
		private FactorySettings _factorySettings;
	}
}
