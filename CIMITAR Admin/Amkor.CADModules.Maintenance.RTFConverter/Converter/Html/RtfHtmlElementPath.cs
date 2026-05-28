using System;
using System.Collections;
using System.Text;
using System.Web.UI;

namespace Amkor.CADModules.Maintenance.RTFConverter.Converter.Html
{
	// Token: 0x020000B2 RID: 178
	public class RtfHtmlElementPath
	{
		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000626 RID: 1574 RVA: 0x00013DB8 File Offset: 0x00011FB8
		public int Count
		{
			get
			{
				return this.elements.Count;
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x00013DD8 File Offset: 0x00011FD8
		public HtmlTextWriterTag Current
		{
			get
			{
				return (HtmlTextWriterTag)this.elements.Peek();
			}
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00013DFC File Offset: 0x00011FFC
		public bool IsCurrent(HtmlTextWriterTag tag)
		{
			return this.Current == tag;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x00013E18 File Offset: 0x00012018
		public bool Contains(HtmlTextWriterTag tag)
		{
			return this.elements.Contains(tag);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00013E3B File Offset: 0x0001203B
		public void Push(HtmlTextWriterTag tag)
		{
			this.elements.Push(tag);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00013E50 File Offset: 0x00012050
		public void Pop()
		{
			this.elements.Pop();
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00013E60 File Offset: 0x00012060
		public override string ToString()
		{
			bool flag = this.elements.Count == 0;
			string result;
			if (flag)
			{
				result = base.ToString();
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				bool flag2 = true;
				foreach (object obj in this.elements)
				{
					bool flag3 = !flag2;
					if (flag3)
					{
						stringBuilder.Insert(0, " > ");
					}
					stringBuilder.Insert(0, obj.ToString());
					flag2 = false;
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x04000244 RID: 580
		private readonly Stack elements = new Stack();
	}
}
