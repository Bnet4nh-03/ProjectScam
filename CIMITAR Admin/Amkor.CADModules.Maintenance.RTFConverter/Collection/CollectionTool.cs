using System;
using System.Collections;
using System.Reflection;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Collection
{
	// Token: 0x0200005B RID: 91
	public static class CollectionTool
	{
		// Token: 0x0600025C RID: 604 RVA: 0x00005BDC File Offset: 0x00003DDC
		public static bool HaveSameContents(IEnumerable left, IEnumerable right)
		{
			bool flag = left == right;
			bool flag2 = !flag;
			if (flag2)
			{
				bool flag3 = left != null && right != null;
				if (flag3)
				{
					IEnumerator enumerator = right.GetEnumerator();
					flag = true;
					foreach (object obj in left)
					{
						bool flag4 = enumerator.MoveNext();
						if (!flag4)
						{
							flag = false;
							break;
						}
						object obj2 = enumerator.Current;
						bool flag5 = obj != obj2 && (obj == null || !obj.Equals(obj2));
						if (flag5)
						{
							flag = false;
							break;
						}
					}
					bool flag6 = flag && enumerator.MoveNext();
					if (flag6)
					{
						flag = false;
					}
				}
			}
			return flag;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00005CC0 File Offset: 0x00003EC0
		public static bool AreEqual(IEnumerable enumerable, object obj)
		{
			bool flag = enumerable == obj;
			bool flag2 = !flag && enumerable != null && obj != null && enumerable.GetType() == obj.GetType();
			if (flag2)
			{
				flag = CollectionTool.HaveSameContents(enumerable, obj as IEnumerable);
			}
			return flag;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00005D08 File Offset: 0x00003F08
		public static int AddHashCode(int hash, object obj)
		{
			int num = (obj != null) ? obj.GetHashCode() : 0;
			bool flag = hash != 0;
			if (flag)
			{
				num += hash * 31;
			}
			return num;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00005D3C File Offset: 0x00003F3C
		public static int AddHashCode(int hash, int objHash)
		{
			int num = objHash;
			bool flag = hash != 0;
			if (flag)
			{
				num += hash * 31;
			}
			return num;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00005D64 File Offset: 0x00003F64
		public static int ComputeHashCode(IEnumerable enumerable)
		{
			int num = 1;
			bool flag = enumerable == null;
			if (flag)
			{
				throw new ArgumentNullException("enumerable");
			}
			foreach (object obj in enumerable)
			{
				num = num * 31 + ((obj != null) ? obj.GetHashCode() : 0);
			}
			return num;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00005DE4 File Offset: 0x00003FE4
		public static string ToString(IEnumerable enumerable)
		{
			return CollectionTool.ToString(enumerable, "[", "]", ",", "null");
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00005E10 File Offset: 0x00004010
		public static string ToString(IEnumerable enumerable, string delimiterText)
		{
			return CollectionTool.ToString(enumerable, string.Empty, string.Empty, delimiterText, string.Empty);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00005E38 File Offset: 0x00004038
		public static string ToString(IEnumerable enumerable, string startText, string endText, string delimiterText, string undefinedValueText)
		{
			bool flag = enumerable == null;
			if (flag)
			{
				throw new ArgumentNullException("enumerable");
			}
			StringBuilder stringBuilder = new StringBuilder(startText);
			bool flag2 = true;
			foreach (object obj in enumerable)
			{
				bool flag3 = obj == null && string.IsNullOrEmpty(undefinedValueText);
				if (!flag3)
				{
					bool flag4 = flag2;
					if (flag4)
					{
						flag2 = false;
					}
					else
					{
						stringBuilder.Append(delimiterText);
					}
					bool flag5 = obj == null;
					if (flag5)
					{
						stringBuilder.Append(undefinedValueText);
					}
					else
					{
						bool flag6 = obj is DictionaryEntry;
						if (flag6)
						{
							DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
							stringBuilder.Append(dictionaryEntry.Key.ToString());
							stringBuilder.Append("=");
							stringBuilder.Append((dictionaryEntry.Value == null) ? undefinedValueText : dictionaryEntry.Value.ToString());
						}
						else
						{
							stringBuilder.Append(obj.ToString());
						}
					}
				}
			}
			stringBuilder.Append(endText);
			return stringBuilder.ToString();
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00005F78 File Offset: 0x00004178
		public static string EnumValuesToString(Type enumType)
		{
			return CollectionTool.EnumValuesToString(enumType, "[", "]", "|");
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00005FA0 File Offset: 0x000041A0
		public static string EnumValuesToString(Type enumType, string delimiterText)
		{
			return CollectionTool.EnumValuesToString(enumType, string.Empty, string.Empty, delimiterText);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00005FC4 File Offset: 0x000041C4
		public static string EnumValuesToString(Type enumType, string startText, string endText, string delimiterText)
		{
			bool flag = enumType == null;
			if (flag)
			{
				throw new ArgumentNullException("enumType");
			}
			StringBuilder stringBuilder = new StringBuilder(startText);
			FieldInfo[] fields = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			{
				bool flag2 = i > 0;
				if (flag2)
				{
					stringBuilder.Append(delimiterText);
				}
				stringBuilder.Append(fields[i].Name);
			}
			stringBuilder.Append(endText);
			return stringBuilder.ToString();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00006048 File Offset: 0x00004248
		public static int ParseEnumValue(Type enumType, string value, bool ignoreCase)
		{
			bool flag = enumType == null;
			if (flag)
			{
				throw new ArgumentNullException("enumType");
			}
			int result;
			try
			{
				result = (int)Enum.Parse(enumType, value, ignoreCase);
			}
			catch (ArgumentException)
			{
				try
				{
					throw new ArgumentException(Strings.CollectionToolInvalidEnum(value, enumType.Name, CollectionTool.EnumValuesToString(enumType)));
				}
				catch (FormatException)
				{
					result = 0;
				}
			}
			return result;
		}
	}
}
