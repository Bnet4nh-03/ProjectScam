using System;
using System.Globalization;
using System.Resources;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x0200003E RID: 62
	internal sealed class Strings : StringsBase
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000106 RID: 262 RVA: 0x0000284C File Offset: 0x00000A4C
		public static string ArgumentMayNotBeEmpty
		{
			get
			{
				return Strings.inst.GetString("ArgumentMayNotBeEmpty");
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00002870 File Offset: 0x00000A70
		public static string CollectionToolInvalidEnum(string value, string enumType, string possibleValues)
		{
			return StringsBase.Format(Strings.inst.GetString("CollectionToolInvalidEnum"), new object[]
			{
				value,
				enumType,
				possibleValues
			});
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000108 RID: 264 RVA: 0x000028A8 File Offset: 0x00000AA8
		public static string LoggerNameMayNotBeEmpty
		{
			get
			{
				return Strings.inst.GetString("LoggerNameMayNotBeEmpty");
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000109 RID: 265 RVA: 0x000028CC File Offset: 0x00000ACC
		public static string LoggerFactoryConfigError
		{
			get
			{
				return Strings.inst.GetString("LoggerFactoryConfigError");
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600010A RID: 266 RVA: 0x000028F0 File Offset: 0x00000AF0
		public static string ProgramPressAnyKeyToQuit
		{
			get
			{
				return Strings.inst.GetString("ProgramPressAnyKeyToQuit");
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00002914 File Offset: 0x00000B14
		public static string StringToolSeparatorIncludesQuoteOrEscapeChar
		{
			get
			{
				return Strings.inst.GetString("StringToolSeparatorIncludesQuoteOrEscapeChar");
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00002938 File Offset: 0x00000B38
		public static string StringToolMissingEscapedHexCode
		{
			get
			{
				return Strings.inst.GetString("StringToolMissingEscapedHexCode");
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600010D RID: 269 RVA: 0x0000295C File Offset: 0x00000B5C
		public static string StringToolMissingEscapedChar
		{
			get
			{
				return Strings.inst.GetString("StringToolMissingEscapedChar");
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00002980 File Offset: 0x00000B80
		public static string StringToolUnbalancedQuotes
		{
			get
			{
				return Strings.inst.GetString("StringToolUnbalancedQuotes");
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600010F RID: 271 RVA: 0x000029A4 File Offset: 0x00000BA4
		public static string StringToolContainsInvalidHexChar
		{
			get
			{
				return Strings.inst.GetString("StringToolContainsInvalidHexChar");
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000029C8 File Offset: 0x00000BC8
		public static string LoggerLogFileNotSupportedByType(string typeName)
		{
			return StringsBase.Format(Strings.inst.GetString("LoggerLogFileNotSupportedByType"), new object[]
			{
				typeName
			});
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000111 RID: 273 RVA: 0x000029F8 File Offset: 0x00000BF8
		public static string LoggerLoggingLevelXmlError
		{
			get
			{
				return Strings.inst.GetString("LoggerLoggingLevelXmlError");
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00002A1C File Offset: 0x00000C1C
		public static string LoggerLoggingLevelRepository
		{
			get
			{
				return Strings.inst.GetString("LoggerLoggingLevelRepository");
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00002A40 File Offset: 0x00000C40
		public static string InvalidFirstHexDigit(char hexDigit)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidFirstHexDigit"), new object[]
			{
				hexDigit
			});
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00002A78 File Offset: 0x00000C78
		public static string InvalidSecondHexDigit(char hexDigit)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidSecondHexDigit"), new object[]
			{
				hexDigit
			});
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00002AB0 File Offset: 0x00000CB0
		public static string ToManyBraces
		{
			get
			{
				return Strings.inst.GetString("ToManyBraces");
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00002AD4 File Offset: 0x00000CD4
		public static string ToFewBraces
		{
			get
			{
				return Strings.inst.GetString("ToFewBraces");
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00002AF8 File Offset: 0x00000CF8
		public static string NoRtfContent
		{
			get
			{
				return Strings.inst.GetString("NoRtfContent");
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00002B1C File Offset: 0x00000D1C
		public static string TagOnRootLevel(string tagName)
		{
			return StringsBase.Format(Strings.inst.GetString("TagOnRootLevel"), new object[]
			{
				tagName
			});
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00002B4C File Offset: 0x00000D4C
		public static string InvalidUnicodeSkipCount(string tagName)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidUnicodeSkipCount"), new object[]
			{
				tagName
			});
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00002B7C File Offset: 0x00000D7C
		public static string UnexpectedEndOfFile
		{
			get
			{
				return Strings.inst.GetString("UnexpectedEndOfFile");
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00002BA0 File Offset: 0x00000DA0
		public static string EndOfFileInvalidCharacter
		{
			get
			{
				return Strings.inst.GetString("EndOfFileInvalidCharacter");
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00002BC4 File Offset: 0x00000DC4
		public static string TextOnRootLevel(string text)
		{
			return StringsBase.Format(Strings.inst.GetString("TextOnRootLevel"), new object[]
			{
				text
			});
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00002BF4 File Offset: 0x00000DF4
		public static string MissingGroupForNewTag
		{
			get
			{
				return Strings.inst.GetString("MissingGroupForNewTag");
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00002C18 File Offset: 0x00000E18
		public static string MissingGroupForNewText
		{
			get
			{
				return Strings.inst.GetString("MissingGroupForNewText");
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00002C3C File Offset: 0x00000E3C
		public static string MultipleRootLevelGroups
		{
			get
			{
				return Strings.inst.GetString("MultipleRootLevelGroups");
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00002C60 File Offset: 0x00000E60
		public static string UnclosedGroups
		{
			get
			{
				return Strings.inst.GetString("UnclosedGroups");
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00002C84 File Offset: 0x00000E84
		public static string LogGroupBegin
		{
			get
			{
				return Strings.inst.GetString("LogGroupBegin");
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00002CA8 File Offset: 0x00000EA8
		public static string LogGroupEnd
		{
			get
			{
				return Strings.inst.GetString("LogGroupEnd");
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00002CCC File Offset: 0x00000ECC
		public static string LogOverflowText
		{
			get
			{
				return Strings.inst.GetString("LogOverflowText");
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00002CF0 File Offset: 0x00000EF0
		public static string LogParseBegin
		{
			get
			{
				return Strings.inst.GetString("LogParseBegin");
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00002D14 File Offset: 0x00000F14
		public static string LogParseEnd
		{
			get
			{
				return Strings.inst.GetString("LogParseEnd");
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00002D38 File Offset: 0x00000F38
		public static string LogParseFail
		{
			get
			{
				return Strings.inst.GetString("LogParseFail");
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00002D5C File Offset: 0x00000F5C
		public static string LogParseFailUnknown
		{
			get
			{
				return Strings.inst.GetString("LogParseFailUnknown");
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00002D80 File Offset: 0x00000F80
		public static string LogParseSuccess
		{
			get
			{
				return Strings.inst.GetString("LogParseSuccess");
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00002DA4 File Offset: 0x00000FA4
		public static string LogTag
		{
			get
			{
				return Strings.inst.GetString("LogTag");
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00002DC8 File Offset: 0x00000FC8
		public static string LogText
		{
			get
			{
				return Strings.inst.GetString("LogText");
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00002DEC File Offset: 0x00000FEC
		public static string ColorTableUnsupportedText(string text)
		{
			return StringsBase.Format(Strings.inst.GetString("ColorTableUnsupportedText"), new object[]
			{
				text
			});
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00002E1C File Offset: 0x0000101C
		public static string DuplicateFont(string fontId)
		{
			return StringsBase.Format(Strings.inst.GetString("DuplicateFont"), new object[]
			{
				fontId
			});
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00002E4C File Offset: 0x0000104C
		public static string EmptyDocument
		{
			get
			{
				return Strings.inst.GetString("EmptyDocument");
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00002E70 File Offset: 0x00001070
		public static string MissingDocumentStartTag
		{
			get
			{
				return Strings.inst.GetString("MissingDocumentStartTag");
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00002E94 File Offset: 0x00001094
		public static string InvalidDocumentStartTag(string expectedTag)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidDocumentStartTag"), new object[]
			{
				expectedTag
			});
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00002EC4 File Offset: 0x000010C4
		public static string MissingRtfVersion
		{
			get
			{
				return Strings.inst.GetString("MissingRtfVersion");
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00002EE8 File Offset: 0x000010E8
		public static string InvalidInitTagState(string tag)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidInitTagState"), new object[]
			{
				tag
			});
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00002F18 File Offset: 0x00001118
		public static string UndefinedFont(string fontId)
		{
			return StringsBase.Format(Strings.inst.GetString("UndefinedFont"), new object[]
			{
				fontId
			});
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00002F48 File Offset: 0x00001148
		public static string InvalidFontSize(int fontSize)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidFontSize"), new object[]
			{
				fontSize
			});
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00002F80 File Offset: 0x00001180
		public static string UndefinedColor(int colorIndex)
		{
			return StringsBase.Format(Strings.inst.GetString("UndefinedColor"), new object[]
			{
				colorIndex
			});
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00002FB8 File Offset: 0x000011B8
		public static string InvalidInitGroupState(string group)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidInitGroupState"), new object[]
			{
				group
			});
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00002FE8 File Offset: 0x000011E8
		public static string InvalidGeneratorGroup(string group)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidGeneratorGroup"), new object[]
			{
				group
			});
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00003018 File Offset: 0x00001218
		public static string InvalidInitTextState(string text)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidInitTextState"), new object[]
			{
				text
			});
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00003048 File Offset: 0x00001248
		public static string InvalidDefaultFont(string fontId, string allowedFontIds)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidDefaultFont"), new object[]
			{
				fontId,
				allowedFontIds
			});
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000139 RID: 313 RVA: 0x0000307C File Offset: 0x0000127C
		public static string InvalidTextContextState
		{
			get
			{
				return Strings.inst.GetString("InvalidTextContextState");
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000030A0 File Offset: 0x000012A0
		public static string UnsupportedRtfVersion(int version)
		{
			return StringsBase.Format(Strings.inst.GetString("UnsupportedRtfVersion"), new object[]
			{
				version
			});
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600013B RID: 315 RVA: 0x000030D8 File Offset: 0x000012D8
		public static string ImageFormatText
		{
			get
			{
				return Strings.inst.GetString("ImageFormatText");
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600013C RID: 316 RVA: 0x000030FC File Offset: 0x000012FC
		public static string LogBeginDocument
		{
			get
			{
				return Strings.inst.GetString("LogBeginDocument");
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00003120 File Offset: 0x00001320
		public static string LogEndDocument
		{
			get
			{
				return Strings.inst.GetString("LogEndDocument");
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00003144 File Offset: 0x00001344
		public static string LogInsertBreak
		{
			get
			{
				return Strings.inst.GetString("LogInsertBreak");
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00003168 File Offset: 0x00001368
		public static string LogInsertChar
		{
			get
			{
				return Strings.inst.GetString("LogInsertChar");
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000140 RID: 320 RVA: 0x0000318C File Offset: 0x0000138C
		public static string LogInsertImage
		{
			get
			{
				return Strings.inst.GetString("LogInsertImage");
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000141 RID: 321 RVA: 0x000031B0 File Offset: 0x000013B0
		public static string LogInsertText
		{
			get
			{
				return Strings.inst.GetString("LogInsertText");
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000031D4 File Offset: 0x000013D4
		public static string InvalidColor(int color)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidColor"), new object[]
			{
				color
			});
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000320C File Offset: 0x0000140C
		public static string InvalidCharacterSet(int charSet)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidCharacterSet"), new object[]
			{
				charSet
			});
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00003244 File Offset: 0x00001444
		public static string InvalidCodePage(int codePage)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidCodePage"), new object[]
			{
				codePage
			});
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000327C File Offset: 0x0000147C
		public static string FontSizeOutOfRange(int fontSize)
		{
			return StringsBase.Format(Strings.inst.GetString("FontSizeOutOfRange"), new object[]
			{
				fontSize
			});
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000032B4 File Offset: 0x000014B4
		public static string InvalidImageWidth(int width)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidImageWidth"), new object[]
			{
				width
			});
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000032EC File Offset: 0x000014EC
		public static string InvalidImageHeight(int height)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidImageHeight"), new object[]
			{
				height
			});
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00003324 File Offset: 0x00001524
		public static string InvalidImageDesiredHeight(int width)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidImageDesiredHeight"), new object[]
			{
				width
			});
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000335C File Offset: 0x0000155C
		public static string InvalidImageDesiredWidth(int height)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidImageDesiredWidth"), new object[]
			{
				height
			});
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00003394 File Offset: 0x00001594
		public static string InvalidImageScaleWidth(int scaleWidth)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidImageScaleWidth"), new object[]
			{
				scaleWidth
			});
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000033CC File Offset: 0x000015CC
		public static string InvalidImageScaleHeight(int scaleHeight)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidImageScaleHeight"), new object[]
			{
				scaleHeight
			});
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00003404 File Offset: 0x00001604
		public static string InvalidMultiByteEncoding(byte[] buffer, int index, Encoding encoding)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < index; i++)
			{
				stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0:X}", new object[]
				{
					buffer[i]
				}));
			}
			return StringsBase.Format(Strings.inst.GetString("InvalidMultiByteEncoding"), new object[]
			{
				stringBuilder.ToString(),
				encoding.EncodingName,
				encoding.CodePage
			});
		}

		// Token: 0x040000DF RID: 223
		private static readonly ResourceManager inst = StringsBase.NewInst(typeof(Strings));
	}
}
