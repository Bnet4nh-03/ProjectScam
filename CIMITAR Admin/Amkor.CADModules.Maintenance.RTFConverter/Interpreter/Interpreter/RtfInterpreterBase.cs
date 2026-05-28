using System;
using System.Collections;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000091 RID: 145
	public abstract class RtfInterpreterBase : IRtfInterpreter
	{
		// Token: 0x06000494 RID: 1172 RVA: 0x0000DB6C File Offset: 0x0000BD6C
		protected RtfInterpreterBase(params IRtfInterpreterListener[] listeners) : this(new RtfInterpreterSettings(), listeners)
		{
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0000F288 File Offset: 0x0000D488
		protected RtfInterpreterBase(IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			bool flag = settings == null;
			if (flag)
			{
				throw new ArgumentNullException("settings");
			}
			this.settings = settings;
			bool flag2 = listeners != null;
			if (flag2)
			{
				foreach (IRtfInterpreterListener listener in listeners)
				{
					this.AddInterpreterListener(listener);
				}
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x0000F2F0 File Offset: 0x0000D4F0
		public IRtfInterpreterSettings Settings
		{
			get
			{
				return this.settings;
			}
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0000F308 File Offset: 0x0000D508
		public void AddInterpreterListener(IRtfInterpreterListener listener)
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

		// Token: 0x06000498 RID: 1176 RVA: 0x0000F368 File Offset: 0x0000D568
		public void RemoveInterpreterListener(IRtfInterpreterListener listener)
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

		// Token: 0x06000499 RID: 1177 RVA: 0x0000F3D4 File Offset: 0x0000D5D4
		public void Interpret(IRtfGroup rtfDocument)
		{
			bool flag = rtfDocument == null;
			if (flag)
			{
				throw new ArgumentNullException("rtfDocument");
			}
			this.DoInterpret(rtfDocument);
		}

		// Token: 0x0600049A RID: 1178
		protected abstract void DoInterpret(IRtfGroup rtfDocument);

		// Token: 0x0600049B RID: 1179 RVA: 0x0000F400 File Offset: 0x0000D600
		protected void NotifyBeginDocument()
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfInterpreterListener rtfInterpreterListener = (IRtfInterpreterListener)obj;
					rtfInterpreterListener.BeginDocument(this.context);
				}
			}
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0000F474 File Offset: 0x0000D674
		protected void NotifyInsertText(string text)
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfInterpreterListener rtfInterpreterListener = (IRtfInterpreterListener)obj;
					rtfInterpreterListener.InsertText(this.context, text);
				}
			}
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0000F4E8 File Offset: 0x0000D6E8
		protected void NotifyInsertSpecialChar(RtfVisualSpecialCharKind kind)
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfInterpreterListener rtfInterpreterListener = (IRtfInterpreterListener)obj;
					rtfInterpreterListener.InsertSpecialChar(this.context, kind);
				}
			}
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0000F55C File Offset: 0x0000D75C
		protected void NotifyInsertBreak(RtfVisualBreakKind kind)
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfInterpreterListener rtfInterpreterListener = (IRtfInterpreterListener)obj;
					rtfInterpreterListener.InsertBreak(this.context, kind);
				}
			}
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
		protected void NotifyInsertImage(RtfVisualImageFormat format, int width, int height, int desiredWidth, int desiredHeight, int scaleWidthPercent, int scaleHeightPercent, string imageDataHex)
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfInterpreterListener rtfInterpreterListener = (IRtfInterpreterListener)obj;
					rtfInterpreterListener.InsertImage(this.context, format, width, height, desiredWidth, desiredHeight, scaleWidthPercent, scaleHeightPercent, imageDataHex);
				}
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0000F650 File Offset: 0x0000D850
		protected void NotifyEndDocument()
		{
			bool flag = this.listeners != null;
			if (flag)
			{
				foreach (object obj in this.listeners)
				{
					IRtfInterpreterListener rtfInterpreterListener = (IRtfInterpreterListener)obj;
					rtfInterpreterListener.EndDocument(this.context);
				}
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000F6C4 File Offset: 0x0000D8C4
		protected RtfInterpreterContext Context
		{
			get
			{
				return this.context;
			}
		}

		// Token: 0x040001B2 RID: 434
		private readonly RtfInterpreterContext context = new RtfInterpreterContext();

		// Token: 0x040001B3 RID: 435
		private readonly IRtfInterpreterSettings settings;

		// Token: 0x040001B4 RID: 436
		private ArrayList listeners;
	}
}
