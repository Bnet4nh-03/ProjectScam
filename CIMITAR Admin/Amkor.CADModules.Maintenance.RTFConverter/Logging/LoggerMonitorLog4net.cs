using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x02000056 RID: 86
	public sealed class LoggerMonitorLog4net : ILoggerMonitor
	{
		// Token: 0x06000206 RID: 518 RVA: 0x0000509C File Offset: 0x0000329C
		public void Register(ILoggerListener loggerListener, string context)
		{
			bool flag = loggerListener == null;
			if (flag)
			{
				throw new ArgumentNullException("loggerListener");
			}
			string key = ArgumentCheck.NonemptyTrimmedString(context, "context");
			Hashtable obj = this.listenerListsByContext;
			lock (obj)
			{
				ArrayList arrayList = this.listenerListsByContext[key] as ArrayList;
				bool flag3 = arrayList == null;
				if (flag3)
				{
					arrayList = new ArrayList(5);
					this.listenerListsByContext.Add(key, arrayList);
				}
				ArrayList obj2 = arrayList;
				lock (obj2)
				{
					arrayList.Add(loggerListener);
				}
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000516C File Offset: 0x0000336C
		public void Unregister(ILoggerListener loggerListener, string context)
		{
			bool flag = loggerListener == null;
			if (flag)
			{
				throw new ArgumentNullException("loggerListener");
			}
			string key = ArgumentCheck.NonemptyTrimmedString(context, "context");
			Hashtable obj = this.listenerListsByContext;
			lock (obj)
			{
				ArrayList arrayList = this.listenerListsByContext[key] as ArrayList;
				bool flag3 = arrayList != null;
				if (flag3)
				{
					ArrayList obj2 = arrayList;
					lock (obj2)
					{
						arrayList.Remove(loggerListener);
					}
					bool flag5 = arrayList.Count == 0;
					if (flag5)
					{
						this.listenerListsByContext.Remove(key);
					}
				}
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00005244 File Offset: 0x00003444
		internal void Handle(ILoggerEvent loggerEvent)
		{
			bool flag = loggerEvent == null;
			if (flag)
			{
				throw new ArgumentNullException("loggerEvent");
			}
			string context = loggerEvent.Context;
			ArrayList arrayList = null;
			bool flag2 = this.listenerListsByContext.Count > 0;
			if (flag2)
			{
				Hashtable obj = this.listenerListsByContext;
				lock (obj)
				{
					arrayList = (this.listenerListsByContext[context] as ArrayList);
					bool flag4 = arrayList == null;
					if (flag4)
					{
						foreach (object obj2 in this.listenerListsByContext.Keys)
						{
							string text = (string)obj2;
							bool flag5 = context.StartsWith(text);
							if (flag5)
							{
								arrayList = (this.listenerListsByContext[text] as ArrayList);
								break;
							}
						}
					}
				}
			}
			bool flag6 = arrayList != null && arrayList.Count > 0;
			if (flag6)
			{
				ArrayList obj3 = arrayList;
				lock (obj3)
				{
					foreach (object obj4 in arrayList)
					{
						ILoggerListener loggerListener = (ILoggerListener)obj4;
						loggerListener.Handle(loggerEvent);
					}
				}
			}
		}

		// Token: 0x040000FA RID: 250
		private readonly Hashtable listenerListsByContext = new Hashtable();
	}
}
