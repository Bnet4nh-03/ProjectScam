using System;
using System.Globalization;
using System.Text;
using Amkor.CADModules.Maintenance.RTFConverter.Collection;
using Amkor.CADModules.Maintenance.RTFConverter.Logging;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000043 RID: 67
	public static class StringTool
	{
		// Token: 0x06000158 RID: 344 RVA: 0x00003690 File Offset: 0x00001890
		public static string FormatSafeInvariant(string format, params object[] args)
		{
			string result;
			try
			{
				result = string.Format(CultureInfo.InvariantCulture, format, args);
			}
			catch (FormatException exception)
			{
				StringTool.logger.Warn("invalid format string '" + format + "'", exception);
				result = format;
			}
			return result;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000036E4 File Offset: 0x000018E4
		public static string[] SplitQuoted(string toSplit, char quote, char escape, bool includeEmptyUnquotedSections, params char[] separator)
		{
			bool flag = toSplit == null;
			if (flag)
			{
				throw new ArgumentNullException("toSplit");
			}
			bool flag2 = separator == null || separator.Length == 0;
			if (flag2)
			{
				throw new ArgumentNullException("separator");
			}
			string text = new string(separator);
			bool flag3 = text.IndexOf(quote) >= 0 || text.IndexOf(escape) >= 0;
			if (flag3)
			{
				throw new ArgumentException(Strings.StringToolSeparatorIncludesQuoteOrEscapeChar, "separator");
			}
			StringCollection stringCollection = new StringCollection();
			StringBuilder stringBuilder = null;
			int length = toSplit.Length;
			bool flag4 = false;
			for (int i = 0; i < length; i++)
			{
				char c = toSplit[i];
				bool flag5 = c == escape;
				if (flag5)
				{
					bool flag6 = i < length - 1;
					if (!flag6)
					{
						throw new ArgumentException(Strings.StringToolMissingEscapedChar, "toSplit");
					}
					bool flag7 = stringBuilder == null;
					if (flag7)
					{
						stringBuilder = new StringBuilder();
					}
					i++;
					c = toSplit[i];
					char c2 = c;
					if (c2 <= 'r')
					{
						if (c2 != 'n')
						{
							if (c2 != 'r')
							{
								goto IL_18A;
							}
							stringBuilder.Append('\r');
						}
						else
						{
							stringBuilder.Append('\n');
						}
					}
					else if (c2 != 't')
					{
						if (c2 != 'x')
						{
							goto IL_18A;
						}
						bool flag8 = i < length - 2;
						if (!flag8)
						{
							throw new ArgumentException(Strings.StringToolMissingEscapedHexCode, "toSplit");
						}
						int num = StringTool.GetHexValue(toSplit[i + 1]) * 16;
						int hexValue = StringTool.GetHexValue(toSplit[i + 2]);
						char value = (char)(num + hexValue);
						stringBuilder.Append(value);
						i += 2;
					}
					else
					{
						stringBuilder.Append('\t');
					}
					goto IL_2B3;
					IL_18A:
					stringBuilder.Append(c);
				}
				else
				{
					bool flag9 = c == quote;
					if (flag9)
					{
						bool flag10 = stringBuilder != null;
						if (flag10)
						{
							stringCollection.Add(stringBuilder.ToString());
							stringBuilder = null;
						}
						else
						{
							bool flag11 = flag4;
							if (flag11)
							{
								stringCollection.Add(string.Empty);
							}
						}
						flag4 = !flag4;
					}
					else
					{
						bool flag12 = text.IndexOf(c) >= 0;
						if (flag12)
						{
							bool flag13 = flag4;
							if (flag13)
							{
								bool flag14 = stringBuilder == null;
								if (flag14)
								{
									stringBuilder = new StringBuilder();
								}
								stringBuilder.Append(c);
							}
							else
							{
								bool flag15 = stringBuilder != null;
								if (flag15)
								{
									stringCollection.Add(stringBuilder.ToString());
									stringBuilder = null;
								}
								else if (includeEmptyUnquotedSections)
								{
									bool flag16 = i == 0 || text.IndexOf(toSplit[i - 1]) >= 0;
									if (flag16)
									{
										stringCollection.Add(string.Empty);
									}
								}
							}
						}
						else
						{
							bool flag17 = stringBuilder == null;
							if (flag17)
							{
								stringBuilder = new StringBuilder();
							}
							stringBuilder.Append(c);
						}
					}
				}
				IL_2B3:;
			}
			bool flag18 = flag4;
			if (flag18)
			{
				throw new ArgumentException(Strings.StringToolUnbalancedQuotes, "toSplit");
			}
			bool flag19 = stringBuilder != null;
			if (flag19)
			{
				stringCollection.Add(stringBuilder.ToString());
			}
			string[] array = new string[stringCollection.Count];
			stringCollection.CopyTo(array, 0);
			return array;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00003A0C File Offset: 0x00001C0C
		private static int GetHexValue(char c)
		{
			bool flag = c >= 'a' && c <= 'f';
			int result;
			if (flag)
			{
				result = (int)(c - 'a' + '\n');
			}
			else
			{
				bool flag2 = c >= 'A' && c <= 'F';
				if (flag2)
				{
					result = (int)(c - 'A' + '\n');
				}
				else
				{
					bool flag3 = c >= '0' && c <= '9';
					if (!flag3)
					{
						throw new ArgumentException(Strings.StringToolContainsInvalidHexChar, "c");
					}
					result = (int)(c - '0');
				}
			}
			return result;
		}

		// Token: 0x040000E0 RID: 224
		private static readonly ILogger logger = Logger.GetLogger(typeof(StringTool));
	}
}
