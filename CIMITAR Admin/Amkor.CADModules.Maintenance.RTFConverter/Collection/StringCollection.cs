using System;
using System.Collections;
using System.Text;

namespace Amkor.CADModules.Maintenance.RTFConverter.Collection
{
	// Token: 0x0200005D RID: 93
	public sealed class StringCollection : ReadOnlyCollectionBase, IStringCollection, IEnumerable
	{
		// Token: 0x0600026E RID: 622 RVA: 0x000060C0 File Offset: 0x000042C0
		public StringCollection()
		{
		}

		// Token: 0x0600026F RID: 623 RVA: 0x000060CA File Offset: 0x000042CA
		public StringCollection(ICollection collection)
		{
			base.InnerList.AddRange(collection);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x000060E4 File Offset: 0x000042E4
		public StringCollection(IStringCollection collection)
		{
			bool flag = collection == null;
			if (flag)
			{
				throw new ArgumentNullException("collection");
			}
			base.InnerList.Capacity = collection.Count;
			foreach (object obj in collection)
			{
				string value = (string)obj;
				base.InnerList.Add(value);
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00006170 File Offset: 0x00004370
		public StringCollection(params string[] items)
		{
			bool flag = items != null;
			if (flag)
			{
				foreach (string value in items)
				{
					base.InnerList.Add(value);
				}
			}
		}

		// Token: 0x170000EB RID: 235
		public string this[int index]
		{
			get
			{
				return base.InnerList[index] as string;
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x000061D8 File Offset: 0x000043D8
		public int Add(string item)
		{
			return base.InnerList.Add(item);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000061F6 File Offset: 0x000043F6
		public void Remove(string item)
		{
			base.InnerList.Remove(item);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00006206 File Offset: 0x00004406
		public void RemoveAt(int index)
		{
			base.InnerList.RemoveAt(index);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00006216 File Offset: 0x00004416
		public void Add(string item, int pos)
		{
			base.InnerList.Insert(pos, item);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00006228 File Offset: 0x00004428
		public void AddAll(IStringCollection items)
		{
			bool flag = items == null;
			if (flag)
			{
				throw new ArgumentNullException("items");
			}
			foreach (object obj in items)
			{
				string value = (string)obj;
				base.InnerList.Add(value);
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000629C File Offset: 0x0000449C
		public void AddCommaSeparated(string commaSeparatedList)
		{
			bool flag = !string.IsNullOrEmpty(commaSeparatedList);
			if (flag)
			{
				string[] array = commaSeparatedList.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					base.InnerList.Add(array[i].Trim());
				}
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000062F4 File Offset: 0x000044F4
		public static StringCollection FromCommaSeparated(string commaSeparatedList)
		{
			StringCollection stringCollection = new StringCollection();
			stringCollection.AddCommaSeparated(commaSeparatedList);
			return stringCollection;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00006318 File Offset: 0x00004518
		public string FormatCommaSeparated()
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			foreach (object obj in base.InnerList)
			{
				string value = (string)obj;
				bool flag2 = flag;
				if (flag2)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000063AC File Offset: 0x000045AC
		public void RemoveAll(IStringCollection items)
		{
			bool flag = items == null;
			if (flag)
			{
				throw new ArgumentNullException("items");
			}
			foreach (object obj in items)
			{
				string item = (string)obj;
				this.Remove(item);
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000641C File Offset: 0x0000461C
		public void Clear()
		{
			base.InnerList.Clear();
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000642C File Offset: 0x0000462C
		public void Sort()
		{
			int count = base.InnerList.Count;
			string[] array = new string[count];
			base.InnerList.CopyTo(array);
			Array.Sort<string>(array);
			for (int i = 0; i < count; i++)
			{
				base.InnerList[i] = array[i];
			}
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00006483 File Offset: 0x00004683
		public void CopyTo(string[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00006494 File Offset: 0x00004694
		public int IndexOf(string test)
		{
			int count = base.InnerList.Count;
			for (int i = 0; i < count; i++)
			{
				bool flag = CompareTool.AreEqual(test, base.InnerList[i]);
				if (flag)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x000064E4 File Offset: 0x000046E4
		public bool Contains(string test)
		{
			return this.IndexOf(test) >= 0;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00006504 File Offset: 0x00004704
		public override bool Equals(object obj)
		{
			return CollectionTool.AreEqual(this, obj);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00006520 File Offset: 0x00004720
		public override int GetHashCode()
		{
			return CollectionTool.ComputeHashCode(this);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00006538 File Offset: 0x00004738
		public override string ToString()
		{
			return CollectionTool.ToString(this);
		}

		// Token: 0x04000104 RID: 260
		public static readonly IStringCollection Empty = new StringCollection();
	}
}
