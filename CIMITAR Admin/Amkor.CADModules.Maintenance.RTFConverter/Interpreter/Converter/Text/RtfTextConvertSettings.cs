using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Converter.Text
{
	// Token: 0x0200009D RID: 157
	public class RtfTextConvertSettings
	{
		// Token: 0x06000524 RID: 1316 RVA: 0x000110BB File Offset: 0x0000F2BB
		public RtfTextConvertSettings() : this("\r\n")
		{
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x000110CC File Offset: 0x0000F2CC
		public RtfTextConvertSettings(string breakText)
		{
			this.SetBreakText(breakText);
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000526 RID: 1318 RVA: 0x0001118E File Offset: 0x0000F38E
		// (set) Token: 0x06000527 RID: 1319 RVA: 0x00011196 File Offset: 0x0000F396
		public bool IsShowHiddenText { get; set; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x000111A0 File Offset: 0x0000F3A0
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x000111B8 File Offset: 0x0000F3B8
		public string TabulatorText
		{
			get
			{
				return this.tabulatorText;
			}
			set
			{
				this.tabulatorText = value;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x000111C4 File Offset: 0x0000F3C4
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x000111DC File Offset: 0x0000F3DC
		public string NonBreakingSpaceText
		{
			get
			{
				return this.nonBreakingSpaceText;
			}
			set
			{
				this.nonBreakingSpaceText = value;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x000111E8 File Offset: 0x0000F3E8
		// (set) Token: 0x0600052D RID: 1325 RVA: 0x00011200 File Offset: 0x0000F400
		public string EmSpaceText
		{
			get
			{
				return this.emSpaceText;
			}
			set
			{
				this.emSpaceText = value;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x0001120C File Offset: 0x0000F40C
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x00011224 File Offset: 0x0000F424
		public string EnSpaceText
		{
			get
			{
				return this.enSpaceText;
			}
			set
			{
				this.enSpaceText = value;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x00011230 File Offset: 0x0000F430
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x00011248 File Offset: 0x0000F448
		public string QmSpaceText
		{
			get
			{
				return this.qmSpaceText;
			}
			set
			{
				this.qmSpaceText = value;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x00011254 File Offset: 0x0000F454
		// (set) Token: 0x06000533 RID: 1331 RVA: 0x0001126C File Offset: 0x0000F46C
		public string EmDashText
		{
			get
			{
				return this.emDashText;
			}
			set
			{
				this.emDashText = value;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x00011278 File Offset: 0x0000F478
		// (set) Token: 0x06000535 RID: 1333 RVA: 0x00011290 File Offset: 0x0000F490
		public string EnDashText
		{
			get
			{
				return this.enDashText;
			}
			set
			{
				this.enDashText = value;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0001129C File Offset: 0x0000F49C
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x000112B4 File Offset: 0x0000F4B4
		public string OptionalHyphenText
		{
			get
			{
				return this.optionalHyphenText;
			}
			set
			{
				this.optionalHyphenText = value;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x000112C0 File Offset: 0x0000F4C0
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x000112D8 File Offset: 0x0000F4D8
		public string NonBreakingHyphenText
		{
			get
			{
				return this.nonBreakingHyphenText;
			}
			set
			{
				this.nonBreakingHyphenText = value;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x000112E4 File Offset: 0x0000F4E4
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x000112FC File Offset: 0x0000F4FC
		public string BulletText
		{
			get
			{
				return this.bulletText;
			}
			set
			{
				this.bulletText = value;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x00011308 File Offset: 0x0000F508
		// (set) Token: 0x0600053D RID: 1341 RVA: 0x00011320 File Offset: 0x0000F520
		public string LeftSingleQuoteText
		{
			get
			{
				return this.leftSingleQuoteText;
			}
			set
			{
				this.leftSingleQuoteText = value;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x0001132C File Offset: 0x0000F52C
		// (set) Token: 0x0600053F RID: 1343 RVA: 0x00011344 File Offset: 0x0000F544
		public string RightSingleQuoteText
		{
			get
			{
				return this.rightSingleQuoteText;
			}
			set
			{
				this.rightSingleQuoteText = value;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x00011350 File Offset: 0x0000F550
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x00011368 File Offset: 0x0000F568
		public string LeftDoubleQuoteText
		{
			get
			{
				return this.leftDoubleQuoteText;
			}
			set
			{
				this.leftDoubleQuoteText = value;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x00011374 File Offset: 0x0000F574
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x0001138C File Offset: 0x0000F58C
		public string RightDoubleQuoteText
		{
			get
			{
				return this.rightDoubleQuoteText;
			}
			set
			{
				this.rightDoubleQuoteText = value;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x00011396 File Offset: 0x0000F596
		// (set) Token: 0x06000545 RID: 1349 RVA: 0x0001139E File Offset: 0x0000F59E
		public string UnknownSpecialCharText { get; set; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x000113A8 File Offset: 0x0000F5A8
		// (set) Token: 0x06000547 RID: 1351 RVA: 0x000113C0 File Offset: 0x0000F5C0
		public string LineBreakText
		{
			get
			{
				return this.lineBreakText;
			}
			set
			{
				this.lineBreakText = value;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x000113CC File Offset: 0x0000F5CC
		// (set) Token: 0x06000549 RID: 1353 RVA: 0x000113E4 File Offset: 0x0000F5E4
		public string PageBreakText
		{
			get
			{
				return this.pageBreakText;
			}
			set
			{
				this.pageBreakText = value;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x000113F0 File Offset: 0x0000F5F0
		// (set) Token: 0x0600054B RID: 1355 RVA: 0x00011408 File Offset: 0x0000F608
		public string ParagraphBreakText
		{
			get
			{
				return this.paragraphBreakText;
			}
			set
			{
				this.paragraphBreakText = value;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x00011414 File Offset: 0x0000F614
		// (set) Token: 0x0600054D RID: 1357 RVA: 0x0001142C File Offset: 0x0000F62C
		public string SectionBreakText
		{
			get
			{
				return this.sectionBreakText;
			}
			set
			{
				this.sectionBreakText = value;
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x00011438 File Offset: 0x0000F638
		// (set) Token: 0x0600054F RID: 1359 RVA: 0x00011450 File Offset: 0x0000F650
		public string UnknownBreakText
		{
			get
			{
				return this.unknownBreakText;
			}
			set
			{
				this.unknownBreakText = value;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x0001145C File Offset: 0x0000F65C
		// (set) Token: 0x06000551 RID: 1361 RVA: 0x00011474 File Offset: 0x0000F674
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

		// Token: 0x06000552 RID: 1362 RVA: 0x00011480 File Offset: 0x0000F680
		public void SetBreakText(string breakText)
		{
			bool flag = breakText == null;
			if (flag)
			{
				throw new ArgumentNullException("breakText");
			}
			this.lineBreakText = breakText;
			this.pageBreakText = breakText + breakText;
			this.paragraphBreakText = breakText;
			this.sectionBreakText = breakText + breakText;
			this.unknownBreakText = breakText;
		}

		// Token: 0x040001E8 RID: 488
		public const string SeparatorCr = "\r";

		// Token: 0x040001E9 RID: 489
		public const string SeparatorLf = "\n";

		// Token: 0x040001EA RID: 490
		public const string SeparatorCrLf = "\r\n";

		// Token: 0x040001EB RID: 491
		public const string SeparatorLfCr = "\n\r";

		// Token: 0x040001EE RID: 494
		private string tabulatorText = "\t";

		// Token: 0x040001EF RID: 495
		private string nonBreakingSpaceText = " ";

		// Token: 0x040001F0 RID: 496
		private string emSpaceText = " ";

		// Token: 0x040001F1 RID: 497
		private string enSpaceText = " ";

		// Token: 0x040001F2 RID: 498
		private string qmSpaceText = " ";

		// Token: 0x040001F3 RID: 499
		private string emDashText = "-";

		// Token: 0x040001F4 RID: 500
		private string enDashText = "-";

		// Token: 0x040001F5 RID: 501
		private string optionalHyphenText = "-";

		// Token: 0x040001F6 RID: 502
		private string nonBreakingHyphenText = "-";

		// Token: 0x040001F7 RID: 503
		private string bulletText = "°";

		// Token: 0x040001F8 RID: 504
		private string leftSingleQuoteText = "`";

		// Token: 0x040001F9 RID: 505
		private string rightSingleQuoteText = "´";

		// Token: 0x040001FA RID: 506
		private string leftDoubleQuoteText = "``";

		// Token: 0x040001FB RID: 507
		private string rightDoubleQuoteText = "´´";

		// Token: 0x040001FC RID: 508
		private string lineBreakText;

		// Token: 0x040001FD RID: 509
		private string pageBreakText;

		// Token: 0x040001FE RID: 510
		private string paragraphBreakText;

		// Token: 0x040001FF RID: 511
		private string sectionBreakText;

		// Token: 0x04000200 RID: 512
		private string unknownBreakText;

		// Token: 0x04000201 RID: 513
		private string imageFormatText = Strings.ImageFormatText;
	}
}
