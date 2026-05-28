using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;

namespace Amkor.CADModules.Maintenance.RTFConverter.Parser
{
	// Token: 0x02000068 RID: 104
	public sealed class RtfParser : RtfParserBase
	{
		// Token: 0x060002BD RID: 701 RVA: 0x00006DC0 File Offset: 0x00004FC0
		public RtfParser()
		{
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00006E1C File Offset: 0x0000501C
		public RtfParser(params IRtfParserListener[] listeners) : base(listeners)
		{
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00006E78 File Offset: 0x00005078
		protected override void DoParse(IRtfSource rtfTextSource)
		{
			base.NotifyParseBegin();
			try
			{
				this.ParseRtf(rtfTextSource.Reader);
				base.NotifyParseSuccess();
			}
			catch (RtfException reason)
			{
				base.NotifyParseFail(reason);
				throw;
			}
			finally
			{
				base.NotifyParseEnd();
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00006EDC File Offset: 0x000050DC
		private void ParseRtf(TextReader reader)
		{
			this.curText = new StringBuilder();
			this.unicodeSkipCountStack.Clear();
			this.codePageStack.Clear();
			this.unicodeSkipCount = 1;
			this.level = 0;
			this.tagCountAtLastGroupStart = 0;
			this.tagCount = 0;
			this.fontTableStartLevel = -1;
			this.targetFont = null;
			this.expectingThemeFont = false;
			this.fontToCodePageMapping.Clear();
			this.hexDecodingBuffer.SetLength(0L);
			this.UpdateEncoding(1252);
			int num = 0;
			int num2 = RtfParser.PeekNextChar(reader, false);
			bool flag = false;
			while (num2 != -1)
			{
				int num3 = 0;
				bool flag2 = false;
				int num4 = num2;
				if (num4 <= 92)
				{
					switch (num4)
					{
					case 9:
						reader.Read();
						this.HandleTag(reader, new RtfTag("tab"));
						break;
					case 10:
					case 13:
						reader.Read();
						break;
					case 11:
					case 12:
						goto IL_40B;
					default:
					{
						if (num4 != 92)
						{
							goto IL_40B;
						}
						bool flag3 = !flag;
						if (flag3)
						{
							reader.Read();
						}
						int num5 = RtfParser.PeekNextChar(reader, true);
						int num6 = num5;
						if (num6 <= 42)
						{
							if (num6 <= 13)
							{
								if (num6 != 10 && num6 != 13)
								{
									goto IL_2C0;
								}
								reader.Read();
								this.HandleTag(reader, new RtfTag("par"));
							}
							else if (num6 != 39)
							{
								if (num6 != 42)
								{
									goto IL_2C0;
								}
								goto IL_298;
							}
							else
							{
								reader.Read();
								char c = (char)RtfParser.ReadOneByte(reader);
								char c2 = (char)RtfParser.ReadOneByte(reader);
								bool flag4 = !RtfParser.IsHexDigit((int)c);
								if (flag4)
								{
									throw new RtfHexEncodingException(Strings.InvalidFirstHexDigit(c));
								}
								bool flag5 = !RtfParser.IsHexDigit((int)c2);
								if (flag5)
								{
									throw new RtfHexEncodingException(Strings.InvalidSecondHexDigit(c2));
								}
								int num7 = int.Parse(c.ToString() + c2.ToString(), NumberStyles.HexNumber);
								this.hexDecodingBuffer.WriteByte((byte)num7);
								num3 = RtfParser.PeekNextChar(reader, false);
								flag2 = true;
								bool flag6 = true;
								bool flag7 = num3 == 92;
								if (flag7)
								{
									reader.Read();
									flag = true;
									int num8 = RtfParser.PeekNextChar(reader, false);
									bool flag8 = num8 == 39;
									if (flag8)
									{
										flag6 = false;
									}
								}
								bool flag9 = flag6;
								if (flag9)
								{
									this.DecodeCurrentHexBuffer();
								}
							}
						}
						else if (num6 <= 58)
						{
							if (num6 != 45 && num6 != 58)
							{
								goto IL_2C0;
							}
							goto IL_298;
						}
						else
						{
							if (num6 != 92)
							{
								if (num6 == 95)
								{
									goto IL_298;
								}
								switch (num6)
								{
								case 123:
								case 125:
									break;
								case 124:
								case 126:
									goto IL_298;
								default:
									goto IL_2C0;
								}
							}
							this.curText.Append(this.ReadOneChar(reader));
						}
						break;
						IL_298:
						this.HandleTag(reader, new RtfTag(this.ReadOneChar(reader).ToString() ?? ""));
						break;
						IL_2C0:
						this.ParseTag(reader);
						break;
					}
					}
				}
				else if (num4 != 123)
				{
					if (num4 != 125)
					{
						goto IL_40B;
					}
					reader.Read();
					this.FlushText();
					bool flag10 = this.level > 0;
					if (!flag10)
					{
						throw new RtfBraceNestingException(Strings.ToManyBraces);
					}
					this.unicodeSkipCount = (int)this.unicodeSkipCountStack.Pop();
					bool flag11 = this.fontTableStartLevel == this.level;
					if (flag11)
					{
						this.fontTableStartLevel = -1;
						this.targetFont = null;
						this.expectingThemeFont = false;
					}
					this.UpdateEncoding((int)this.codePageStack.Pop());
					this.level--;
					base.NotifyGroupEnd();
					num++;
				}
				else
				{
					reader.Read();
					this.FlushText();
					base.NotifyGroupBegin();
					this.tagCountAtLastGroupStart = this.tagCount;
					this.unicodeSkipCountStack.Push(this.unicodeSkipCount);
					this.codePageStack.Push((this.encoding == null) ? 0 : this.encoding.CodePage);
					this.level++;
				}
				IL_420:
				bool flag12 = this.level == 0 && base.IgnoreContentAfterRootGroup;
				if (flag12)
				{
					break;
				}
				bool flag13 = flag2;
				if (flag13)
				{
					num2 = num3;
				}
				else
				{
					num2 = RtfParser.PeekNextChar(reader, false);
					flag = false;
				}
				continue;
				IL_40B:
				this.curText.Append(this.ReadOneChar(reader));
				goto IL_420;
			}
			this.FlushText();
			reader.Close();
			bool flag14 = this.level > 0;
			if (flag14)
			{
				throw new RtfBraceNestingException(Strings.ToFewBraces);
			}
			bool flag15 = num == 0;
			if (flag15)
			{
				throw new RtfEmptyDocumentException(Strings.NoRtfContent);
			}
			this.curText = null;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00007394 File Offset: 0x00005594
		private void ParseTag(TextReader reader)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = null;
			bool flag = true;
			bool flag2 = false;
			int num = RtfParser.PeekNextChar(reader, true);
			while (!flag2)
			{
				bool flag3 = flag && RtfParser.IsASCIILetter(num);
				if (flag3)
				{
					stringBuilder.Append(this.ReadOneChar(reader));
				}
				else
				{
					bool flag4 = RtfParser.IsDigit(num) || (num == 45 && stringBuilder2 == null);
					if (flag4)
					{
						flag = false;
						bool flag5 = stringBuilder2 == null;
						if (flag5)
						{
							stringBuilder2 = new StringBuilder();
						}
						stringBuilder2.Append(this.ReadOneChar(reader));
					}
					else
					{
						flag2 = true;
						bool flag6 = stringBuilder2 != null && stringBuilder2.Length > 0;
						IRtfTag tag;
						if (flag6)
						{
							tag = new RtfTag(stringBuilder.ToString(), stringBuilder2.ToString());
						}
						else
						{
							tag = new RtfTag(stringBuilder.ToString());
						}
						bool flag7 = this.HandleTag(reader, tag);
						bool flag8 = num == 32 && !flag7;
						if (flag8)
						{
							reader.Read();
						}
					}
				}
				bool flag9 = !flag2;
				if (flag9)
				{
					num = RtfParser.PeekNextChar(reader, true);
				}
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x000074B4 File Offset: 0x000056B4
		private bool HandleTag(TextReader reader, IRtfTag tag)
		{
			bool flag = this.level == 0;
			if (flag)
			{
				throw new RtfStructureException(Strings.TagOnRootLevel(tag.ToString()));
			}
			bool flag2 = this.tagCount < 4;
			if (flag2)
			{
				this.UpdateEncoding(tag);
			}
			string name = tag.Name;
			bool flag3 = this.expectingThemeFont;
			bool flag4 = this.tagCountAtLastGroupStart == this.tagCount;
			if (flag4)
			{
				string text = name;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 875660080U)
				{
					if (num <= 644779004U)
					{
						if (num != 596946891U)
						{
							if (num != 644779004U)
							{
								goto IL_182;
							}
							if (!(text == "fdbmajor"))
							{
								goto IL_182;
							}
						}
						else if (!(text == "fhimajor"))
						{
							goto IL_182;
						}
					}
					else if (num != 747407905U)
					{
						if (num != 875660080U)
						{
							goto IL_182;
						}
						if (!(text == "fdbminor"))
						{
							goto IL_182;
						}
					}
					else if (!(text == "flominor"))
					{
						goto IL_182;
					}
				}
				else if (num <= 2134103081U)
				{
					if (num != 1835979141U)
					{
						if (num != 2134103081U)
						{
							goto IL_182;
						}
						if (!(text == "fbiminor"))
						{
							goto IL_182;
						}
					}
					else if (!(text == "flomajor"))
					{
						goto IL_182;
					}
				}
				else if (num != 2466964733U)
				{
					if (num != 3672565719U)
					{
						goto IL_182;
					}
					if (!(text == "fhiminor"))
					{
						goto IL_182;
					}
				}
				else if (!(text == "fbimajor"))
				{
					goto IL_182;
				}
				this.expectingThemeFont = true;
				IL_182:
				flag3 = true;
			}
			bool flag5 = flag3;
			if (flag5)
			{
				string a = name;
				if (!(a == "f"))
				{
					if (a == "fonttbl")
					{
						this.fontTableStartLevel = this.level;
					}
				}
				else
				{
					bool flag6 = this.fontTableStartLevel > 0;
					if (flag6)
					{
						this.targetFont = tag.FullName;
						this.expectingThemeFont = false;
					}
				}
			}
			bool flag7 = this.targetFont != null;
			if (flag7)
			{
				bool flag8 = "fcharset".Equals(name);
				if (flag8)
				{
					int valueAsNumber = tag.ValueAsNumber;
					int codePage = RtfSpec.GetCodePage(valueAsNumber);
					this.fontToCodePageMapping[this.targetFont] = codePage;
					this.UpdateEncoding(codePage);
				}
			}
			bool flag9 = this.fontToCodePageMapping.Count > 0 && "f".Equals(name);
			if (flag9)
			{
				int? num2 = (int?)this.fontToCodePageMapping[tag.FullName];
				bool flag10 = num2 != null;
				if (flag10)
				{
					this.UpdateEncoding(num2.Value);
				}
			}
			bool result = false;
			string a2 = name;
			if (!(a2 == "u"))
			{
				if (!(a2 == "uc"))
				{
					this.FlushText();
					base.NotifyTagFound(tag);
				}
				else
				{
					int valueAsNumber2 = tag.ValueAsNumber;
					bool flag11 = valueAsNumber2 < 0 || valueAsNumber2 > 10;
					if (flag11)
					{
						throw new RtfUnicodeEncodingException(Strings.InvalidUnicodeSkipCount(tag.ToString()));
					}
					this.unicodeSkipCount = valueAsNumber2;
				}
			}
			else
			{
				int valueAsNumber3 = tag.ValueAsNumber;
				char value = (char)valueAsNumber3;
				this.curText.Append(value);
				int i = 0;
				while (i < this.unicodeSkipCount)
				{
					int num3 = RtfParser.PeekNextChar(reader, true);
					int num4 = num3;
					if (num4 <= 32)
					{
						if (num4 != 10 && num4 != 13 && num4 != 32)
						{
							goto IL_37A;
						}
						reader.Read();
						result = true;
						bool flag12 = i == 0;
						if (flag12)
						{
							i--;
						}
					}
					else if (num4 != 92)
					{
						if (num4 != 123 && num4 != 125)
						{
							goto IL_37A;
						}
						i = this.unicodeSkipCount;
					}
					else
					{
						reader.Read();
						result = true;
						int num5 = RtfParser.ReadOneByte(reader);
						int num6 = num5;
						if (num6 == 39)
						{
							RtfParser.ReadOneByte(reader);
							RtfParser.ReadOneByte(reader);
						}
					}
					IL_385:
					i++;
					continue;
					IL_37A:
					reader.Read();
					result = true;
					goto IL_385;
				}
			}
			this.tagCount++;
			return result;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000078C0 File Offset: 0x00005AC0
		private void UpdateEncoding(IRtfTag tag)
		{
			string name = tag.Name;
			if (!(name == "ansi"))
			{
				if (!(name == "mac"))
				{
					if (!(name == "pc"))
					{
						if (!(name == "pca"))
						{
							if (name == "ansicpg")
							{
								this.UpdateEncoding(tag.ValueAsNumber);
							}
						}
						else
						{
							this.UpdateEncoding(850);
						}
					}
					else
					{
						this.UpdateEncoding(437);
					}
				}
				else
				{
					this.UpdateEncoding(10000);
				}
			}
			else
			{
				this.UpdateEncoding(1252);
			}
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00007960 File Offset: 0x00005B60
		private void UpdateEncoding(int codePage)
		{
			bool flag = this.encoding == null || codePage != this.encoding.CodePage;
			if (flag)
			{
				if (codePage != 42 && codePage != 1252)
				{
					this.encoding = Encoding.GetEncoding(codePage);
				}
				else
				{
					this.encoding = RtfSpec.AnsiEncoding;
				}
				this.byteToCharDecoder = null;
			}
			bool flag2 = this.byteToCharDecoder == null;
			if (flag2)
			{
				this.byteToCharDecoder = this.encoding.GetDecoder();
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x000079E8 File Offset: 0x00005BE8
		private static bool IsASCIILetter(int character)
		{
			return (character >= 97 && character <= 122) || (character >= 65 && character <= 90);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00007A18 File Offset: 0x00005C18
		private static bool IsHexDigit(int character)
		{
			return (character >= 48 && character <= 57) || (character >= 97 && character <= 102) || (character >= 65 && character <= 70);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00007A54 File Offset: 0x00005C54
		private static bool IsDigit(int character)
		{
			return character >= 48 && character <= 57;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00007A78 File Offset: 0x00005C78
		private static int ReadOneByte(TextReader reader)
		{
			int num = reader.Read();
			bool flag = num == -1;
			if (flag)
			{
				throw new RtfUnicodeEncodingException(Strings.UnexpectedEndOfFile);
			}
			return num;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00007AA8 File Offset: 0x00005CA8
		private char ReadOneChar(TextReader reader)
		{
			bool flag = false;
			int num = 0;
			while (!flag)
			{
				this.byteDecodingBuffer[num] = (byte)RtfParser.ReadOneByte(reader);
				num++;
				int num2;
				int num3;
				this.byteToCharDecoder.Convert(this.byteDecodingBuffer, 0, num, this.charDecodingBuffer, 0, 1, true, out num2, out num3, out flag);
				bool flag2 = flag && (num2 != num || num3 != 1);
				if (flag2)
				{
					throw new RtfMultiByteEncodingException(Strings.InvalidMultiByteEncoding(this.byteDecodingBuffer, num, this.encoding));
				}
			}
			return this.charDecodingBuffer[0];
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00007B44 File Offset: 0x00005D44
		private void DecodeCurrentHexBuffer()
		{
			long length = this.hexDecodingBuffer.Length;
			bool flag = length > 0L;
			if (flag)
			{
				byte[] array = this.hexDecodingBuffer.ToArray();
				char[] array2 = new char[length];
				int num = 0;
				bool flag2 = false;
				while (!flag2 && num < array.Length)
				{
					int num2;
					int num3;
					this.byteToCharDecoder.Convert(array, num, array.Length - num, array2, 0, array2.Length, true, out num2, out num3, out flag2);
					this.curText.Append(array2, 0, num3);
					num += num3;
				}
				this.hexDecodingBuffer.SetLength(0L);
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00007BE4 File Offset: 0x00005DE4
		private static int PeekNextChar(TextReader reader, bool mandatory)
		{
			int num = reader.Peek();
			bool flag = mandatory && num == -1;
			if (flag)
			{
				throw new RtfMultiByteEncodingException(Strings.EndOfFileInvalidCharacter);
			}
			return num;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00007C18 File Offset: 0x00005E18
		private void FlushText()
		{
			bool flag = this.curText.Length > 0;
			if (flag)
			{
				bool flag2 = this.level == 0;
				if (flag2)
				{
					throw new RtfStructureException(Strings.TextOnRootLevel(this.curText.ToString()));
				}
				base.NotifyTextFound(new RtfText(this.curText.ToString()));
				this.curText.Remove(0, this.curText.Length);
			}
		}

		// Token: 0x04000111 RID: 273
		private StringBuilder curText;

		// Token: 0x04000112 RID: 274
		private readonly Stack unicodeSkipCountStack = new Stack();

		// Token: 0x04000113 RID: 275
		private int unicodeSkipCount;

		// Token: 0x04000114 RID: 276
		private readonly Stack codePageStack = new Stack();

		// Token: 0x04000115 RID: 277
		private int level;

		// Token: 0x04000116 RID: 278
		private int tagCountAtLastGroupStart;

		// Token: 0x04000117 RID: 279
		private int tagCount;

		// Token: 0x04000118 RID: 280
		private int fontTableStartLevel;

		// Token: 0x04000119 RID: 281
		private string targetFont;

		// Token: 0x0400011A RID: 282
		private bool expectingThemeFont;

		// Token: 0x0400011B RID: 283
		private readonly Hashtable fontToCodePageMapping = new Hashtable();

		// Token: 0x0400011C RID: 284
		private Encoding encoding;

		// Token: 0x0400011D RID: 285
		private Decoder byteToCharDecoder;

		// Token: 0x0400011E RID: 286
		private readonly MemoryStream hexDecodingBuffer = new MemoryStream();

		// Token: 0x0400011F RID: 287
		private readonly byte[] byteDecodingBuffer = new byte[8];

		// Token: 0x04000120 RID: 288
		private readonly char[] charDecodingBuffer = new char[1];
	}
}
