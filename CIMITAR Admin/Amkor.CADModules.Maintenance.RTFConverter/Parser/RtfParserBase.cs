using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Parser
{
	// Token: 0x02000069 RID: 105
	public abstract class RtfParserBase : IRtfParser
	{
		// Token: 0x060002CD RID: 717 RVA: 0x00007C8D File Offset: 0x00005E8D
		protected RtfParserBase()
		{
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00007C98 File Offset: 0x00005E98
		protected RtfParserBase(params IRtfParserListener[] listeners)
		{
			bool flag = listeners != null;
			if (flag)
			{
				foreach (IRtfParserListener listener in listeners)
				{
					this.AddParserListener(listener);
				}
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060002CF RID: 719 RVA: 0x00007CD6 File Offset: 0x00005ED6
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x00007CDE File Offset: 0x00005EDE
		public bool IgnoreContentAfterRootGroup { get; set; }

		// Token: 0x060002D1 RID: 721 RVA: 0x00007CE8 File Offset: 0x00005EE8
		public void AddParserListener(IRtfParserListener listener)
		{
			bool flag = listener == null;
			if (flag)
			{
				throw new ArgumentNullException("listener");
			}
			bool flag2 = this.listeners == null;
			if (flag2)
			{
				this.listeners = new ArrayList();
			}
			bool flag3 = !this.listeners.Contains(listener);
			if (flag3)
			{
				this.listeners.Add(listener);
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00007D48 File Offset: 0x00005F48
		public void RemoveParserListener(IRtfParserListener listener)
		{
			bool flag = listener == null;
			if (flag)
			{
				throw new ArgumentNullException("listener");
			}
			bool flag2 = this.listeners != null;
			if (flag2)
			{
				bool flag3 = this.listeners.Contains(listener);
				if (flag3)
				{
					this.listeners.Remove(listener);
				}
				bool flag4 = this.listeners.Count == 0;
				if (flag4)
				{
					this.listeners = null;
				}
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00007DB4 File Offset: 0x00005FB4
		public void Parse(IRtfSource rtfTextSource)
		{
			bool flag = rtfTextSource == null;
			if (flag)
			{
				throw new ArgumentNullException("rtfTextSource");
			}
			this.DoParse(rtfTextSource);
		}

		// Token: 0x060002D4 RID: 724
		protected abstract void DoParse(IRtfSource rtfTextSource);

		// Token: 0x060002D5 RID: 725 RVA: 0x00007DE0 File Offset: 0x00005FE0
		protected void NotifyParseBegin()
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfParserListener rtfParserListener = (IRtfParserListener)obj;
					rtfParserListener.ParseBegin();
				}
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00007E50 File Offset: 0x00006050
		protected void NotifyGroupBegin()
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfParserListener rtfParserListener = (IRtfParserListener)obj;
					rtfParserListener.GroupBegin();
				}
			}
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00007EC0 File Offset: 0x000060C0
		protected void NotifyTagFound(IRtfTag tag)
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfParserListener rtfParserListener = (IRtfParserListener)obj;
					rtfParserListener.TagFound(tag);
				}
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00007F30 File Offset: 0x00006130
		protected void NotifyTextFound(IRtfText text)
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfParserListener rtfParserListener = (IRtfParserListener)obj;
					rtfParserListener.TextFound(text);
				}
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00007FA0 File Offset: 0x000061A0
		protected void NotifyGroupEnd()
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfParserListener rtfParserListener = (IRtfParserListener)obj;
					rtfParserListener.GroupEnd();
				}
			}
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00008010 File Offset: 0x00006210
		protected void NotifyParseSuccess()
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfParserListener rtfParserListener = (IRtfParserListener)obj;
					rtfParserListener.ParseSuccess();
				}
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00008080 File Offset: 0x00006280
		protected void NotifyParseFail(RtfException reason)
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfParserListener rtfParserListener = (IRtfParserListener)obj;
					rtfParserListener.ParseFail(reason);
				}
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x000080F0 File Offset: 0x000062F0
		protected void NotifyParseEnd()
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfParserListener rtfParserListener = (IRtfParserListener)obj;
					rtfParserListener.ParseEnd();
				}
			}
		}

		// Token: 0x04000122 RID: 290
		private ArrayList listeners;
	}
}
