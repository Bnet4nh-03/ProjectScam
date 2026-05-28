using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000097 RID: 151
	public class RtfInterpreterLoggerSettings
	{
		// Token: 0x060004F4 RID: 1268 RVA: 0x00010758 File Offset: 0x0000E958
		public RtfInterpreterLoggerSettings() : this(true)
		{
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00010764 File Offset: 0x0000E964
		public RtfInterpreterLoggerSettings(bool enabled)
		{
			this.Enabled = enabled;
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x000107D6 File Offset: 0x0000E9D6
		// (set) Token: 0x060004F7 RID: 1271 RVA: 0x000107DE File Offset: 0x0000E9DE
		public bool Enabled { get; set; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x000107E8 File Offset: 0x0000E9E8
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x00010800 File Offset: 0x0000EA00
		public string BeginDocumentText
		{
			get
			{
				return this.beginDocumentText;
			}
			set
			{
				this.beginDocumentText = value;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x0001080C File Offset: 0x0000EA0C
		// (set) Token: 0x060004FB RID: 1275 RVA: 0x00010824 File Offset: 0x0000EA24
		public string EndDocumentText
		{
			get
			{
				return this.endDocumentText;
			}
			set
			{
				this.endDocumentText = value;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x00010830 File Offset: 0x0000EA30
		// (set) Token: 0x060004FD RID: 1277 RVA: 0x00010848 File Offset: 0x0000EA48
		public string TextFormatText
		{
			get
			{
				return this.textFormatText;
			}
			set
			{
				this.textFormatText = value;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x00010854 File Offset: 0x0000EA54
		// (set) Token: 0x060004FF RID: 1279 RVA: 0x0001086C File Offset: 0x0000EA6C
		public string TextOverflowText
		{
			get
			{
				return this.textOverflowText;
			}
			set
			{
				this.textOverflowText = value;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x00010878 File Offset: 0x0000EA78
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x00010890 File Offset: 0x0000EA90
		public string SpecialCharFormatText
		{
			get
			{
				return this.specialCharFormatText;
			}
			set
			{
				this.specialCharFormatText = value;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0001089C File Offset: 0x0000EA9C
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x000108B4 File Offset: 0x0000EAB4
		public string BreakFormatText
		{
			get
			{
				return this.breakFormatText;
			}
			set
			{
				this.breakFormatText = value;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x000108C0 File Offset: 0x0000EAC0
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x000108D8 File Offset: 0x0000EAD8
		public string ImageFormatText
		{
			get
			{
				return this.imageFormatText;
			}
			set
			{
				this.imageFormatText = value;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x000108E4 File Offset: 0x0000EAE4
		// (set) Token: 0x06000507 RID: 1287 RVA: 0x000108FC File Offset: 0x0000EAFC
		public int TextMaxLength
		{
			get
			{
				return this.textMaxLength;
			}
			set
			{
				this.textMaxLength = value;
			}
		}

		// Token: 0x040001CE RID: 462
		private string beginDocumentText = Strings.LogBeginDocument;

		// Token: 0x040001CF RID: 463
		private string endDocumentText = Strings.LogEndDocument;

		// Token: 0x040001D0 RID: 464
		private string textFormatText = Strings.LogInsertText;

		// Token: 0x040001D1 RID: 465
		private string textOverflowText = Strings.LogOverflowText;

		// Token: 0x040001D2 RID: 466
		private string specialCharFormatText = Strings.LogInsertChar;

		// Token: 0x040001D3 RID: 467
		private string breakFormatText = Strings.LogInsertBreak;

		// Token: 0x040001D4 RID: 468
		private string imageFormatText = Strings.LogInsertImage;

		// Token: 0x040001D5 RID: 469
		private int textMaxLength = 80;
	}
}
