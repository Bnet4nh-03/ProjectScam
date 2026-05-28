using System;
using System.IO;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support
{
	// Token: 0x02000071 RID: 113
	public static class RtfInterpreterTool
	{
		// Token: 0x0600033C RID: 828 RVA: 0x00009220 File Offset: 0x00007420
		public static IRtfDocument BuildDoc(string rtfText, params IRtfInterpreterListener[] listeners)
		{
			return RtfInterpreterTool.BuildDoc(rtfText, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00009240 File Offset: 0x00007440
		public static IRtfDocument BuildDoc(string rtfText, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			return RtfInterpreterTool.BuildDoc(RtfParserTool.Parse(rtfText, new IRtfParserListener[0]), settings, listeners);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00009268 File Offset: 0x00007468
		public static IRtfDocument BuildDoc(TextReader rtfTextSource, params IRtfInterpreterListener[] listeners)
		{
			return RtfInterpreterTool.BuildDoc(rtfTextSource, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00009288 File Offset: 0x00007488
		public static IRtfDocument BuildDoc(TextReader rtfTextSource, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			return RtfInterpreterTool.BuildDoc(RtfParserTool.Parse(rtfTextSource, new IRtfParserListener[0]), settings, listeners);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x000092B0 File Offset: 0x000074B0
		public static IRtfDocument BuildDoc(Stream rtfTextSource, params IRtfInterpreterListener[] listeners)
		{
			return RtfInterpreterTool.BuildDoc(rtfTextSource, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x000092D0 File Offset: 0x000074D0
		public static IRtfDocument BuildDoc(Stream rtfTextSource, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			return RtfInterpreterTool.BuildDoc(RtfParserTool.Parse(rtfTextSource, new IRtfParserListener[0]), settings, listeners);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x000092F8 File Offset: 0x000074F8
		public static IRtfDocument BuildDoc(IRtfSource rtfTextSource, params IRtfInterpreterListener[] listeners)
		{
			return RtfInterpreterTool.BuildDoc(rtfTextSource, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00009318 File Offset: 0x00007518
		public static IRtfDocument BuildDoc(IRtfSource rtfTextSource, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			return RtfInterpreterTool.BuildDoc(RtfParserTool.Parse(rtfTextSource, new IRtfParserListener[0]), settings, listeners);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00009340 File Offset: 0x00007540
		public static IRtfDocument BuildDoc(IRtfGroup rtfDocument, params IRtfInterpreterListener[] listeners)
		{
			return RtfInterpreterTool.BuildDoc(rtfDocument, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00009360 File Offset: 0x00007560
		public static IRtfDocument BuildDoc(IRtfGroup rtfDocument, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterListenerDocumentBuilder rtfInterpreterListenerDocumentBuilder = new RtfInterpreterListenerDocumentBuilder();
			bool flag = listeners == null;
			IRtfInterpreterListener[] array;
			if (flag)
			{
				array = new IRtfInterpreterListener[]
				{
					rtfInterpreterListenerDocumentBuilder
				};
			}
			else
			{
				array = new IRtfInterpreterListener[listeners.Length + 1];
				array[0] = rtfInterpreterListenerDocumentBuilder;
				listeners.CopyTo(array, 1);
			}
			RtfInterpreterTool.Interpret(rtfDocument, settings, array);
			return rtfInterpreterListenerDocumentBuilder.Document;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x000093B8 File Offset: 0x000075B8
		public static void Interpret(string rtfText, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterTool.Interpret(rtfText, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x000093C8 File Offset: 0x000075C8
		public static void Interpret(string rtfText, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterTool.Interpret(RtfParserTool.Parse(rtfText, new IRtfParserListener[0]), settings, listeners);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x000093DF File Offset: 0x000075DF
		public static void Interpret(TextReader rtfTextSource, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterTool.Interpret(rtfTextSource, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000093EF File Offset: 0x000075EF
		public static void Interpret(TextReader rtfTextSource, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterTool.Interpret(RtfParserTool.Parse(rtfTextSource, new IRtfParserListener[0]), settings, listeners);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00009406 File Offset: 0x00007606
		public static void Interpret(Stream rtfTextSource, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterTool.Interpret(rtfTextSource, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00009416 File Offset: 0x00007616
		public static void Interpret(Stream rtfTextSource, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterTool.Interpret(RtfParserTool.Parse(rtfTextSource, new IRtfParserListener[0]), settings, listeners);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000942D File Offset: 0x0000762D
		public static void Interpret(IRtfSource rtfTextSource, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterTool.Interpret(rtfTextSource, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000943D File Offset: 0x0000763D
		public static void Interpret(IRtfSource rtfTextSource, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterTool.Interpret(RtfParserTool.Parse(rtfTextSource, new IRtfParserListener[0]), settings, listeners);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00009454 File Offset: 0x00007654
		public static void Interpret(IRtfGroup rtfDocument, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreterTool.Interpret(rtfDocument, new RtfInterpreterSettings(), listeners);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00009464 File Offset: 0x00007664
		public static void Interpret(IRtfGroup rtfDocument, IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners)
		{
			RtfInterpreter rtfInterpreter = new RtfInterpreter(settings, new IRtfInterpreterListener[0]);
			bool flag = listeners != null;
			if (flag)
			{
				foreach (IRtfInterpreterListener rtfInterpreterListener in listeners)
				{
					bool flag2 = rtfInterpreterListener != null;
					if (flag2)
					{
						rtfInterpreter.AddInterpreterListener(rtfInterpreterListener);
					}
				}
			}
			rtfInterpreter.Interpret(rtfDocument);
		}
	}
}
