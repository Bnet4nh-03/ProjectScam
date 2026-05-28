using System;
using System.Globalization;
using System.Resources;
using System.Text;
using Itenso.Sys;

namespace Itenso.Rtf
{
	// Token: 0x02000002 RID: 2
	internal sealed class Strings : StringsBase
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static string InvalidFirstHexDigit(char hexDigit)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidFirstHexDigit"), new object[]
			{
				hexDigit
			});
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002088 File Offset: 0x00000288
		public static string InvalidSecondHexDigit(char hexDigit)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidSecondHexDigit"), new object[]
			{
				hexDigit
			});
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		public static string ToManyBraces
		{
			get
			{
				return Strings.inst.GetString("ToManyBraces");
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020E4 File Offset: 0x000002E4
		public static string ToFewBraces
		{
			get
			{
				return Strings.inst.GetString("ToFewBraces");
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002108 File Offset: 0x00000308
		public static string NoRtfContent
		{
			get
			{
				return Strings.inst.GetString("NoRtfContent");
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000212C File Offset: 0x0000032C
		public static string TagOnRootLevel(string tagName)
		{
			return StringsBase.Format(Strings.inst.GetString("TagOnRootLevel"), new object[]
			{
				tagName
			});
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000215C File Offset: 0x0000035C
		public static string InvalidUnicodeSkipCount(string tagName)
		{
			return StringsBase.Format(Strings.inst.GetString("InvalidUnicodeSkipCount"), new object[]
			{
				tagName
			});
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000218C File Offset: 0x0000038C
		public static string UnexpectedEndOfFile
		{
			get
			{
				return Strings.inst.GetString("UnexpectedEndOfFile");
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021B0 File Offset: 0x000003B0
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

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000223C File Offset: 0x0000043C
		public static string EndOfFileInvalidCharacter
		{
			get
			{
				return Strings.inst.GetString("EndOfFileInvalidCharacter");
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002260 File Offset: 0x00000460
		public static string TextOnRootLevel(string text)
		{
			return StringsBase.Format(Strings.inst.GetString("TextOnRootLevel"), new object[]
			{
				text
			});
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002290 File Offset: 0x00000490
		public static string MissingGroupForNewTag
		{
			get
			{
				return Strings.inst.GetString("MissingGroupForNewTag");
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000022B4 File Offset: 0x000004B4
		public static string MissingGroupForNewText
		{
			get
			{
				return Strings.inst.GetString("MissingGroupForNewText");
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000022D8 File Offset: 0x000004D8
		public static string MultipleRootLevelGroups
		{
			get
			{
				return Strings.inst.GetString("MultipleRootLevelGroups");
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000022FC File Offset: 0x000004FC
		public static string UnclosedGroups
		{
			get
			{
				return Strings.inst.GetString("UnclosedGroups");
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002320 File Offset: 0x00000520
		public static string LogGroupBegin
		{
			get
			{
				return Strings.inst.GetString("LogGroupBegin");
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002344 File Offset: 0x00000544
		public static string LogGroupEnd
		{
			get
			{
				return Strings.inst.GetString("LogGroupEnd");
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002368 File Offset: 0x00000568
		public static string LogOverflowText
		{
			get
			{
				return Strings.inst.GetString("LogOverflowText");
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000238C File Offset: 0x0000058C
		public static string LogParseBegin
		{
			get
			{
				return Strings.inst.GetString("LogParseBegin");
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000023B0 File Offset: 0x000005B0
		public static string LogParseEnd
		{
			get
			{
				return Strings.inst.GetString("LogParseEnd");
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000023D4 File Offset: 0x000005D4
		public static string LogParseFail
		{
			get
			{
				return Strings.inst.GetString("LogParseFail");
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000023F8 File Offset: 0x000005F8
		public static string LogParseFailUnknown
		{
			get
			{
				return Strings.inst.GetString("LogParseFailUnknown");
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000241C File Offset: 0x0000061C
		public static string LogParseSuccess
		{
			get
			{
				return Strings.inst.GetString("LogParseSuccess");
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002440 File Offset: 0x00000640
		public static string LogTag
		{
			get
			{
				return Strings.inst.GetString("LogTag");
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002464 File Offset: 0x00000664
		public static string LogText
		{
			get
			{
				return Strings.inst.GetString("LogText");
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly ResourceManager inst = StringsBase.NewInst(typeof(Strings));
	}
}
