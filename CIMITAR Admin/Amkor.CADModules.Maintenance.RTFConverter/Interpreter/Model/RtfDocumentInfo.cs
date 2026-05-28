using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model
{
	// Token: 0x02000078 RID: 120
	public sealed class RtfDocumentInfo : IRtfDocumentInfo
	{
		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600037E RID: 894 RVA: 0x00009C30 File Offset: 0x00007E30
		// (set) Token: 0x0600037F RID: 895 RVA: 0x00009C48 File Offset: 0x00007E48
		public int? Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00009C54 File Offset: 0x00007E54
		// (set) Token: 0x06000381 RID: 897 RVA: 0x00009C6C File Offset: 0x00007E6C
		public int? Version
		{
			get
			{
				return this.version;
			}
			set
			{
				this.version = value;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00009C78 File Offset: 0x00007E78
		// (set) Token: 0x06000383 RID: 899 RVA: 0x00009C90 File Offset: 0x00007E90
		public int? Revision
		{
			get
			{
				return this.revision;
			}
			set
			{
				this.revision = value;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000384 RID: 900 RVA: 0x00009C9C File Offset: 0x00007E9C
		// (set) Token: 0x06000385 RID: 901 RVA: 0x00009CB4 File Offset: 0x00007EB4
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				this.title = value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00009CC0 File Offset: 0x00007EC0
		// (set) Token: 0x06000387 RID: 903 RVA: 0x00009CD8 File Offset: 0x00007ED8
		public string Subject
		{
			get
			{
				return this.subject;
			}
			set
			{
				this.subject = value;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00009CE4 File Offset: 0x00007EE4
		// (set) Token: 0x06000389 RID: 905 RVA: 0x00009CFC File Offset: 0x00007EFC
		public string Author
		{
			get
			{
				return this.author;
			}
			set
			{
				this.author = value;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00009D08 File Offset: 0x00007F08
		// (set) Token: 0x0600038B RID: 907 RVA: 0x00009D20 File Offset: 0x00007F20
		public string Manager
		{
			get
			{
				return this.manager;
			}
			set
			{
				this.manager = value;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600038C RID: 908 RVA: 0x00009D2C File Offset: 0x00007F2C
		// (set) Token: 0x0600038D RID: 909 RVA: 0x00009D44 File Offset: 0x00007F44
		public string Company
		{
			get
			{
				return this.company;
			}
			set
			{
				this.company = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600038E RID: 910 RVA: 0x00009D50 File Offset: 0x00007F50
		// (set) Token: 0x0600038F RID: 911 RVA: 0x00009D68 File Offset: 0x00007F68
		public string Operator
		{
			get
			{
				return this.operatorName;
			}
			set
			{
				this.operatorName = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00009D74 File Offset: 0x00007F74
		// (set) Token: 0x06000391 RID: 913 RVA: 0x00009D8C File Offset: 0x00007F8C
		public string Category
		{
			get
			{
				return this.category;
			}
			set
			{
				this.category = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00009D98 File Offset: 0x00007F98
		// (set) Token: 0x06000393 RID: 915 RVA: 0x00009DB0 File Offset: 0x00007FB0
		public string Keywords
		{
			get
			{
				return this.keywords;
			}
			set
			{
				this.keywords = value;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000394 RID: 916 RVA: 0x00009DBC File Offset: 0x00007FBC
		// (set) Token: 0x06000395 RID: 917 RVA: 0x00009DD4 File Offset: 0x00007FD4
		public string Comment
		{
			get
			{
				return this.comment;
			}
			set
			{
				this.comment = value;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00009DE0 File Offset: 0x00007FE0
		// (set) Token: 0x06000397 RID: 919 RVA: 0x00009DF8 File Offset: 0x00007FF8
		public string DocumentComment
		{
			get
			{
				return this.documentComment;
			}
			set
			{
				this.documentComment = value;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00009E04 File Offset: 0x00008004
		// (set) Token: 0x06000399 RID: 921 RVA: 0x00009E1C File Offset: 0x0000801C
		public string HyperLinkbase
		{
			get
			{
				return this.hyperLinkbase;
			}
			set
			{
				this.hyperLinkbase = value;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00009E28 File Offset: 0x00008028
		// (set) Token: 0x0600039B RID: 923 RVA: 0x00009E40 File Offset: 0x00008040
		public DateTime? CreationTime
		{
			get
			{
				return this.creationTime;
			}
			set
			{
				this.creationTime = value;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00009E4C File Offset: 0x0000804C
		// (set) Token: 0x0600039D RID: 925 RVA: 0x00009E64 File Offset: 0x00008064
		public DateTime? RevisionTime
		{
			get
			{
				return this.revisionTime;
			}
			set
			{
				this.revisionTime = value;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00009E70 File Offset: 0x00008070
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00009E88 File Offset: 0x00008088
		public DateTime? PrintTime
		{
			get
			{
				return this.printTime;
			}
			set
			{
				this.printTime = value;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00009E94 File Offset: 0x00008094
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x00009EAC File Offset: 0x000080AC
		public DateTime? BackupTime
		{
			get
			{
				return this.backupTime;
			}
			set
			{
				this.backupTime = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00009EB8 File Offset: 0x000080B8
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x00009ED0 File Offset: 0x000080D0
		public int? NumberOfPages
		{
			get
			{
				return this.numberOfPages;
			}
			set
			{
				this.numberOfPages = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00009EDC File Offset: 0x000080DC
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00009EF4 File Offset: 0x000080F4
		public int? NumberOfWords
		{
			get
			{
				return this.numberOfWords;
			}
			set
			{
				this.numberOfWords = value;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x00009F00 File Offset: 0x00008100
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x00009F18 File Offset: 0x00008118
		public int? NumberOfCharacters
		{
			get
			{
				return this.numberOfCharacters;
			}
			set
			{
				this.numberOfCharacters = value;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x00009F24 File Offset: 0x00008124
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x00009F3C File Offset: 0x0000813C
		public int? EditingTimeInMinutes
		{
			get
			{
				return this.editingTimeInMinutes;
			}
			set
			{
				this.editingTimeInMinutes = value;
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00009F48 File Offset: 0x00008148
		public void Reset()
		{
			this.id = null;
			this.version = null;
			this.revision = null;
			this.title = null;
			this.subject = null;
			this.author = null;
			this.manager = null;
			this.company = null;
			this.operatorName = null;
			this.category = null;
			this.keywords = null;
			this.comment = null;
			this.documentComment = null;
			this.hyperLinkbase = null;
			this.creationTime = null;
			this.revisionTime = null;
			this.printTime = null;
			this.backupTime = null;
			this.numberOfPages = null;
			this.numberOfWords = null;
			this.numberOfCharacters = null;
			this.editingTimeInMinutes = null;
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000A028 File Offset: 0x00008228
		public override string ToString()
		{
			return "RTFDocInfo";
		}

		// Token: 0x04000150 RID: 336
		private int? id;

		// Token: 0x04000151 RID: 337
		private int? version;

		// Token: 0x04000152 RID: 338
		private int? revision;

		// Token: 0x04000153 RID: 339
		private string title;

		// Token: 0x04000154 RID: 340
		private string subject;

		// Token: 0x04000155 RID: 341
		private string author;

		// Token: 0x04000156 RID: 342
		private string manager;

		// Token: 0x04000157 RID: 343
		private string company;

		// Token: 0x04000158 RID: 344
		private string operatorName;

		// Token: 0x04000159 RID: 345
		private string category;

		// Token: 0x0400015A RID: 346
		private string keywords;

		// Token: 0x0400015B RID: 347
		private string comment;

		// Token: 0x0400015C RID: 348
		private string documentComment;

		// Token: 0x0400015D RID: 349
		private string hyperLinkbase;

		// Token: 0x0400015E RID: 350
		private DateTime? creationTime;

		// Token: 0x0400015F RID: 351
		private DateTime? revisionTime;

		// Token: 0x04000160 RID: 352
		private DateTime? printTime;

		// Token: 0x04000161 RID: 353
		private DateTime? backupTime;

		// Token: 0x04000162 RID: 354
		private int? numberOfPages;

		// Token: 0x04000163 RID: 355
		private int? numberOfWords;

		// Token: 0x04000164 RID: 356
		private int? numberOfCharacters;

		// Token: 0x04000165 RID: 357
		private int? editingTimeInMinutes;
	}
}
