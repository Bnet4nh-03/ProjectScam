using System;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200003B RID: 59
	public static class RtfSpec
	{
		// Token: 0x060000FC RID: 252 RVA: 0x000025B4 File Offset: 0x000007B4
		public static int GetCodePage(int charSet)
		{
			if (charSet <= 186)
			{
				if (charSet <= 89)
				{
					switch (charSet)
					{
					case 0:
						return 1252;
					case 1:
						return 0;
					case 2:
						return 42;
					default:
						switch (charSet)
						{
						case 77:
							return 10000;
						case 78:
							return 10001;
						case 79:
							return 10003;
						case 80:
							return 10008;
						case 81:
							return 10002;
						case 82:
							return 0;
						case 83:
							return 10005;
						case 84:
							return 10004;
						case 85:
							return 10006;
						case 86:
							return 10081;
						case 87:
							return 10021;
						case 88:
							return 10029;
						case 89:
							return 10007;
						}
						break;
					}
				}
				else
				{
					switch (charSet)
					{
					case 128:
						return 932;
					case 129:
						return 949;
					case 130:
						return 1361;
					case 131:
					case 132:
					case 133:
					case 135:
						break;
					case 134:
						return 936;
					case 136:
						return 950;
					default:
						switch (charSet)
						{
						case 161:
							return 1253;
						case 162:
							return 1254;
						case 163:
							return 1258;
						default:
							switch (charSet)
							{
							case 177:
								return 1255;
							case 178:
								return 1256;
							case 179:
								return 0;
							case 180:
								return 0;
							case 181:
								return 0;
							case 186:
								return 1257;
							}
							break;
						}
						break;
					}
				}
			}
			else if (charSet <= 222)
			{
				if (charSet == 204)
				{
					return 1251;
				}
				if (charSet == 222)
				{
					return 874;
				}
			}
			else
			{
				if (charSet == 238)
				{
					return 1250;
				}
				if (charSet == 254)
				{
					return 437;
				}
				if (charSet == 255)
				{
					return 850;
				}
			}
			return 0;
		}

		// Token: 0x04000045 RID: 69
		public const string TagRtf = "rtf";

		// Token: 0x04000046 RID: 70
		public const int RtfVersion1 = 1;

		// Token: 0x04000047 RID: 71
		public const string TagGenerator = "generator";

		// Token: 0x04000048 RID: 72
		public const string TagViewKind = "viewkind";

		// Token: 0x04000049 RID: 73
		public const string TagEncodingAnsi = "ansi";

		// Token: 0x0400004A RID: 74
		public const string TagEncodingMac = "mac";

		// Token: 0x0400004B RID: 75
		public const string TagEncodingPc = "pc";

		// Token: 0x0400004C RID: 76
		public const string TagEncodingPca = "pca";

		// Token: 0x0400004D RID: 77
		public const string TagEncodingAnsiCodePage = "ansicpg";

		// Token: 0x0400004E RID: 78
		public const int AnsiCodePage = 1252;

		// Token: 0x0400004F RID: 79
		public const int SymbolFakeCodePage = 42;

		// Token: 0x04000050 RID: 80
		public static readonly Encoding AnsiEncoding = Encoding.GetEncoding(1252);

		// Token: 0x04000051 RID: 81
		public const string TagUnicodeSkipCount = "uc";

		// Token: 0x04000052 RID: 82
		public const string TagUnicodeCode = "u";

		// Token: 0x04000053 RID: 83
		public const string TagUnicodeAlternativeChoices = "upr";

		// Token: 0x04000054 RID: 84
		public const string TagUnicodeAlternativeUnicode = "ud";

		// Token: 0x04000055 RID: 85
		public const string TagFontTable = "fonttbl";

		// Token: 0x04000056 RID: 86
		public const string TagDefaultFont = "deff";

		// Token: 0x04000057 RID: 87
		public const string TagFont = "f";

		// Token: 0x04000058 RID: 88
		public const string TagFontKindNil = "fnil";

		// Token: 0x04000059 RID: 89
		public const string TagFontKindRoman = "froman";

		// Token: 0x0400005A RID: 90
		public const string TagFontKindSwiss = "fswiss";

		// Token: 0x0400005B RID: 91
		public const string TagFontKindModern = "fmodern";

		// Token: 0x0400005C RID: 92
		public const string TagFontKindScript = "fscript";

		// Token: 0x0400005D RID: 93
		public const string TagFontKindDecor = "fdecor";

		// Token: 0x0400005E RID: 94
		public const string TagFontKindTech = "ftech";

		// Token: 0x0400005F RID: 95
		public const string TagFontKindBidi = "fbidi";

		// Token: 0x04000060 RID: 96
		public const string TagFontCharset = "fcharset";

		// Token: 0x04000061 RID: 97
		public const string TagFontPitch = "fprq";

		// Token: 0x04000062 RID: 98
		public const string TagFontSize = "fs";

		// Token: 0x04000063 RID: 99
		public const string TagFontDown = "dn";

		// Token: 0x04000064 RID: 100
		public const string TagFontUp = "up";

		// Token: 0x04000065 RID: 101
		public const string TagFontSubscript = "sub";

		// Token: 0x04000066 RID: 102
		public const string TagFontSuperscript = "super";

		// Token: 0x04000067 RID: 103
		public const string TagFontNoSuperSub = "nosupersub";

		// Token: 0x04000068 RID: 104
		public const string TagThemeFontLoMajor = "flomajor";

		// Token: 0x04000069 RID: 105
		public const string TagThemeFontHiMajor = "fhimajor";

		// Token: 0x0400006A RID: 106
		public const string TagThemeFontDbMajor = "fdbmajor";

		// Token: 0x0400006B RID: 107
		public const string TagThemeFontBiMajor = "fbimajor";

		// Token: 0x0400006C RID: 108
		public const string TagThemeFontLoMinor = "flominor";

		// Token: 0x0400006D RID: 109
		public const string TagThemeFontHiMinor = "fhiminor";

		// Token: 0x0400006E RID: 110
		public const string TagThemeFontDbMinor = "fdbminor";

		// Token: 0x0400006F RID: 111
		public const string TagThemeFontBiMinor = "fbiminor";

		// Token: 0x04000070 RID: 112
		public const int DefaultFontSize = 24;

		// Token: 0x04000071 RID: 113
		public const string TagCodePage = "cpg";

		// Token: 0x04000072 RID: 114
		public const string TagColorTable = "colortbl";

		// Token: 0x04000073 RID: 115
		public const string TagColorRed = "red";

		// Token: 0x04000074 RID: 116
		public const string TagColorGreen = "green";

		// Token: 0x04000075 RID: 117
		public const string TagColorBlue = "blue";

		// Token: 0x04000076 RID: 118
		public const string TagColorForeground = "cf";

		// Token: 0x04000077 RID: 119
		public const string TagColorBackground = "cb";

		// Token: 0x04000078 RID: 120
		public const string TagColorBackgroundWord = "chcbpat";

		// Token: 0x04000079 RID: 121
		public const string TagColorHighlight = "highlight";

		// Token: 0x0400007A RID: 122
		public const string TagHeader = "header";

		// Token: 0x0400007B RID: 123
		public const string TagHeaderFirst = "headerf";

		// Token: 0x0400007C RID: 124
		public const string TagHeaderLeft = "headerl";

		// Token: 0x0400007D RID: 125
		public const string TagHeaderRight = "headerr";

		// Token: 0x0400007E RID: 126
		public const string TagFooter = "footer";

		// Token: 0x0400007F RID: 127
		public const string TagFooterFirst = "footerf";

		// Token: 0x04000080 RID: 128
		public const string TagFooterLeft = "footerl";

		// Token: 0x04000081 RID: 129
		public const string TagFooterRight = "footerr";

		// Token: 0x04000082 RID: 130
		public const string TagFootnote = "footnote";

		// Token: 0x04000083 RID: 131
		public const string TagDelimiter = ";";

		// Token: 0x04000084 RID: 132
		public const string TagExtensionDestination = "*";

		// Token: 0x04000085 RID: 133
		public const string TagTilde = "~";

		// Token: 0x04000086 RID: 134
		public const string TagHyphen = "-";

		// Token: 0x04000087 RID: 135
		public const string TagUnderscore = "_";

		// Token: 0x04000088 RID: 136
		public const string TagPage = "page";

		// Token: 0x04000089 RID: 137
		public const string TagSection = "sect";

		// Token: 0x0400008A RID: 138
		public const string TagParagraph = "par";

		// Token: 0x0400008B RID: 139
		public const string TagLine = "line";

		// Token: 0x0400008C RID: 140
		public const string TagTabulator = "tab";

		// Token: 0x0400008D RID: 141
		public const string TagEmDash = "emdash";

		// Token: 0x0400008E RID: 142
		public const string TagEnDash = "endash";

		// Token: 0x0400008F RID: 143
		public const string TagEmSpace = "emspace";

		// Token: 0x04000090 RID: 144
		public const string TagEnSpace = "enspace";

		// Token: 0x04000091 RID: 145
		public const string TagQmSpace = "qmspace";

		// Token: 0x04000092 RID: 146
		public const string TagBulltet = "bullet";

		// Token: 0x04000093 RID: 147
		public const string TagLeftSingleQuote = "lquote";

		// Token: 0x04000094 RID: 148
		public const string TagRightSingleQuote = "rquote";

		// Token: 0x04000095 RID: 149
		public const string TagLeftDoubleQuote = "ldblquote";

		// Token: 0x04000096 RID: 150
		public const string TagRightDoubleQuote = "rdblquote";

		// Token: 0x04000097 RID: 151
		public const string TagPlain = "plain";

		// Token: 0x04000098 RID: 152
		public const string TagParagraphDefaults = "pard";

		// Token: 0x04000099 RID: 153
		public const string TagSectionDefaults = "sectd";

		// Token: 0x0400009A RID: 154
		public const string TagBold = "b";

		// Token: 0x0400009B RID: 155
		public const string TagItalic = "i";

		// Token: 0x0400009C RID: 156
		public const string TagUnderLine = "ul";

		// Token: 0x0400009D RID: 157
		public const string TagUnderLineNone = "ulnone";

		// Token: 0x0400009E RID: 158
		public const string TagStrikeThrough = "strike";

		// Token: 0x0400009F RID: 159
		public const string TagHidden = "v";

		// Token: 0x040000A0 RID: 160
		public const string TagAlignLeft = "ql";

		// Token: 0x040000A1 RID: 161
		public const string TagAlignCenter = "qc";

		// Token: 0x040000A2 RID: 162
		public const string TagAlignRight = "qr";

		// Token: 0x040000A3 RID: 163
		public const string TagAlignJustify = "qj";

		// Token: 0x040000A4 RID: 164
		public const string TagStyleSheet = "stylesheet";

		// Token: 0x040000A5 RID: 165
		public const string TagInfo = "info";

		// Token: 0x040000A6 RID: 166
		public const string TagInfoVersion = "version";

		// Token: 0x040000A7 RID: 167
		public const string TagInfoRevision = "vern";

		// Token: 0x040000A8 RID: 168
		public const string TagInfoNumberOfPages = "nofpages";

		// Token: 0x040000A9 RID: 169
		public const string TagInfoNumberOfWords = "nofwords";

		// Token: 0x040000AA RID: 170
		public const string TagInfoNumberOfChars = "nofchars";

		// Token: 0x040000AB RID: 171
		public const string TagInfoId = "id";

		// Token: 0x040000AC RID: 172
		public const string TagInfoTitle = "title";

		// Token: 0x040000AD RID: 173
		public const string TagInfoSubject = "subject";

		// Token: 0x040000AE RID: 174
		public const string TagInfoAuthor = "author";

		// Token: 0x040000AF RID: 175
		public const string TagInfoManager = "manager";

		// Token: 0x040000B0 RID: 176
		public const string TagInfoCompany = "company";

		// Token: 0x040000B1 RID: 177
		public const string TagInfoOperator = "operator";

		// Token: 0x040000B2 RID: 178
		public const string TagInfoCategory = "category";

		// Token: 0x040000B3 RID: 179
		public const string TagInfoKeywords = "keywords";

		// Token: 0x040000B4 RID: 180
		public const string TagInfoComment = "comment";

		// Token: 0x040000B5 RID: 181
		public const string TagInfoDocumentComment = "doccomm";

		// Token: 0x040000B6 RID: 182
		public const string TagInfoHyperLinkBase = "hlinkbase";

		// Token: 0x040000B7 RID: 183
		public const string TagInfoCreationTime = "creatim";

		// Token: 0x040000B8 RID: 184
		public const string TagInfoRevisionTime = "revtim";

		// Token: 0x040000B9 RID: 185
		public const string TagInfoPrintTime = "printim";

		// Token: 0x040000BA RID: 186
		public const string TagInfoBackupTime = "buptim";

		// Token: 0x040000BB RID: 187
		public const string TagInfoYear = "yr";

		// Token: 0x040000BC RID: 188
		public const string TagInfoMonth = "mo";

		// Token: 0x040000BD RID: 189
		public const string TagInfoDay = "dy";

		// Token: 0x040000BE RID: 190
		public const string TagInfoHour = "hr";

		// Token: 0x040000BF RID: 191
		public const string TagInfoMinute = "min";

		// Token: 0x040000C0 RID: 192
		public const string TagInfoSecond = "sec";

		// Token: 0x040000C1 RID: 193
		public const string TagInfoEditingTimeMinutes = "edmins";

		// Token: 0x040000C2 RID: 194
		public const string TagUserProperties = "userprops";

		// Token: 0x040000C3 RID: 195
		public const string TagUserPropertyType = "proptype";

		// Token: 0x040000C4 RID: 196
		public const string TagUserPropertyName = "propname";

		// Token: 0x040000C5 RID: 197
		public const string TagUserPropertyValue = "staticval";

		// Token: 0x040000C6 RID: 198
		public const string TagUserPropertyLink = "linkval";

		// Token: 0x040000C7 RID: 199
		public const int PropertyTypeInteger = 3;

		// Token: 0x040000C8 RID: 200
		public const int PropertyTypeRealNumber = 5;

		// Token: 0x040000C9 RID: 201
		public const int PropertyTypeDate = 64;

		// Token: 0x040000CA RID: 202
		public const int PropertyTypeBoolean = 11;

		// Token: 0x040000CB RID: 203
		public const int PropertyTypeText = 30;

		// Token: 0x040000CC RID: 204
		public const string TagPicture = "pict";

		// Token: 0x040000CD RID: 205
		public const string TagPictureWrapper = "shppict";

		// Token: 0x040000CE RID: 206
		public const string TagPictureWrapperAlternative = "nonshppict";

		// Token: 0x040000CF RID: 207
		public const string TagPictureFormatEmf = "emfblip";

		// Token: 0x040000D0 RID: 208
		public const string TagPictureFormatPng = "pngblip";

		// Token: 0x040000D1 RID: 209
		public const string TagPictureFormatJpg = "jpegblip";

		// Token: 0x040000D2 RID: 210
		public const string TagPictureFormatPict = "macpict";

		// Token: 0x040000D3 RID: 211
		public const string TagPictureFormatOs2Metafile = "pmmetafile";

		// Token: 0x040000D4 RID: 212
		public const string TagPictureFormatWmf = "wmetafile";

		// Token: 0x040000D5 RID: 213
		public const string TagPictureFormatWinDib = "dibitmap";

		// Token: 0x040000D6 RID: 214
		public const string TagPictureFormatWinBmp = "wbitmap";

		// Token: 0x040000D7 RID: 215
		public const string TagPictureWidth = "picw";

		// Token: 0x040000D8 RID: 216
		public const string TagPictureHeight = "pich";

		// Token: 0x040000D9 RID: 217
		public const string TagPictureWidthGoal = "picwgoal";

		// Token: 0x040000DA RID: 218
		public const string TagPictureHeightGoal = "pichgoal";

		// Token: 0x040000DB RID: 219
		public const string TagPictureWidthScale = "picscalex";

		// Token: 0x040000DC RID: 220
		public const string TagPictureHeightScale = "picscaley";

		// Token: 0x040000DD RID: 221
		public const string TagParagraphNumberText = "pntext";

		// Token: 0x040000DE RID: 222
		public const string TagListNumberText = "listtext";
	}
}
