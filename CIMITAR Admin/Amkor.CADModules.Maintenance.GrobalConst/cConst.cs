using System;
using System.Collections.Generic;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.GrobalConst
{
	// Token: 0x02000004 RID: 4
	public static class cConst
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void clearCategory()
		{
			cConst.sCategory.Clear();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
		public static string convertPriority(int prioirty)
		{
			string result;
			if (prioirty != 1)
			{
				result = "Normal";
			}
			else
			{
				result = "High";
			}
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002088 File Offset: 0x00000288
		public static void addCategory(string name)
		{
			bool flag = !cConst.sCategory.Contains(name);
			if (flag)
			{
				cConst.sCategory.Add(name);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020B4 File Offset: 0x000002B4
		public static void initContents(FactorySettings factorySettings, string factory, string content)
		{
			cConst.listContents.Clear();
			cConst.CustContents.Clear();
			cConst.listContents = cFunction.getConfirmList(factorySettings, factory, content);
		}

		// Token: 0x0400000D RID: 13
		public static string docPath = Environment.CurrentDirectory + "\\RES\\maint\\report.dll";

		// Token: 0x0400000E RID: 14
		public static string actionDocPath = Environment.CurrentDirectory + "\\RES\\maint\\action.dll";

		// Token: 0x0400000F RID: 15
		public static Dictionary<int, string> listContents = new Dictionary<int, string>();

		// Token: 0x04000010 RID: 16
		public static Dictionary<string, string> CustContents = new Dictionary<string, string>();

		// Token: 0x04000011 RID: 17
		public static readonly Dictionary<int, string> listBoardContents = new Dictionary<int, string>();

		// Token: 0x04000012 RID: 18
		public static readonly string[] sPlant = new string[]
		{
			"K3",
			"K4",
			"K5",
			"K3_E",
			"K5_M"
		};

		// Token: 0x04000013 RID: 19
		public static readonly string[] sWorkType = new string[]
		{
			"PE activity",
			"Service(Vendor)",
			"PM activity",
			"MFG activity"
		};

		// Token: 0x04000014 RID: 20
		public static readonly List<string> sCategory = new List<string>();

		// Token: 0x04000015 RID: 21
		public const int K3 = 0;

		// Token: 0x04000016 RID: 22
		public const int K4 = 1;

		// Token: 0x04000017 RID: 23
		public const int K5 = 2;

		// Token: 0x04000018 RID: 24
		public const int K3_E = 3;

		// Token: 0x04000019 RID: 25
		public const int K5_M = 4;

		// Token: 0x0400001A RID: 26
		public const int ATV = 0;

		// Token: 0x0400001B RID: 27
		public const string sK3 = "K3";

		// Token: 0x0400001C RID: 28
		public const string sK4 = "K4";

		// Token: 0x0400001D RID: 29
		public const string sK5 = "K5";

		// Token: 0x0400001E RID: 30
		public const string sK3EV = "K3_E";

		// Token: 0x0400001F RID: 31
		public const string sK5M = "K5_M";

		// Token: 0x04000020 RID: 32
		public const string sATV = "ATV";

		// Token: 0x04000021 RID: 33
		public const string Request = "Request";

		// Token: 0x04000022 RID: 34
		public const string Close = "Close";

		// Token: 0x04000023 RID: 35
		public const string HClose = "Close(H)";

		// Token: 0x04000024 RID: 36
		public const string Hold = "Hold";

		// Token: 0x04000025 RID: 37
		public const string Hardware = "HARDWARE";

		// Token: 0x04000026 RID: 38
		public const string Software = "SOFTWARE";

		// Token: 0x04000027 RID: 39
		public const string PM = "PM(Request)";

		// Token: 0x04000028 RID: 40
		public const string PMAPP = "PM(Approval)";

		// Token: 0x04000029 RID: 41
		public const string PMDNE = "PM(Done)";

		// Token: 0x0400002A RID: 42
		public const string PMFIN = "PM(Final)";

		// Token: 0x0400002B RID: 43
		public const string PMCAN = "PM(Cancel)";

		// Token: 0x0400002C RID: 44
		public const string Other = "OTHER";

		// Token: 0x0400002D RID: 45
		public const string Etc = "Etc";

		// Token: 0x0400002E RID: 46
		public const string ACTIONMODE = "1";

		// Token: 0x0400002F RID: 47
		public const string ACTIONDONE = "2";

		// Token: 0x04000030 RID: 48
		public const string HOLDEMODE = "3";

		// Token: 0x04000031 RID: 49
		public const string MAINTDELETE = "99";

		// Token: 0x04000032 RID: 50
		public const string PMREQUEST = "11";

		// Token: 0x04000033 RID: 51
		public const string PMAPPROVAL = "12";

		// Token: 0x04000034 RID: 52
		public const string PMDONE = "13";

		// Token: 0x04000035 RID: 53
		public const string PMFINAL = "14";

		// Token: 0x04000036 RID: 54
		public const string PMCLOSE = "15";

		// Token: 0x04000037 RID: 55
		public const string PMACTIONCANCEL = "96";

		// Token: 0x04000038 RID: 56
		public const string PMREQUESTCANCEL = "97";

		// Token: 0x04000039 RID: 57
		public const string PMAPPROVALCANCEL = "98";

		// Token: 0x0400003A RID: 58
		public const string PMDELETE = "99";

		// Token: 0x0400003B RID: 59
		public static List<confir> _listConfir = new List<confir>();

		// Token: 0x0200001B RID: 27
		public class Upload
		{
			// Token: 0x040000FC RID: 252
			public const string tempDir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload";

			// Token: 0x040000FD RID: 253
			public const string tempContDir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content";

			// Token: 0x040000FE RID: 254
			public const string tempAttDir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\attach";

			// Token: 0x040000FF RID: 255
			public const string tempHTMLDir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML";

			// Token: 0x04000100 RID: 256
			public const string reportHTMLDir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report";

			// Token: 0x04000101 RID: 257
			public const string actionHTMLdir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action";

			// Token: 0x04000102 RID: 258
			public const string pmHTMLdir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm";

			// Token: 0x04000103 RID: 259
			public const string reportHTMLImageDir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.files";

			// Token: 0x04000104 RID: 260
			public const string actionHTMLImageDir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action\\action.files";

			// Token: 0x04000105 RID: 261
			public const string reportHTML = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.html";

			// Token: 0x04000106 RID: 262
			public const string actionHTML = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action\\action.html";

			// Token: 0x04000107 RID: 263
			public const string pmContent1HTML = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content1.html";

			// Token: 0x04000108 RID: 264
			public const string pmLogoHTML = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\logo.jpg";

			// Token: 0x04000109 RID: 265
			public const string pmContent2HTML = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content2.html";

			// Token: 0x0400010A RID: 266
			public const string pmContent3HTML = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content3.html";

			// Token: 0x0400010B RID: 267
			public const string pmContent4HTML = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content4.html";

			// Token: 0x0400010C RID: 268
			public const string pmContent5HTML = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content5.html";

			// Token: 0x0400010D RID: 269
			public const string pmContent6HTML = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content6.html";

			// Token: 0x0400010E RID: 270
			public const string reportZip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z";

			// Token: 0x0400010F RID: 271
			public const string reportCheckZip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\TempC.7z";

			// Token: 0x04000110 RID: 272
			public const string reportCheckRTF = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\TempC.rtf";

			// Token: 0x04000111 RID: 273
			public const string reportRequZip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Temp.7z";

			// Token: 0x04000112 RID: 274
			public const string reportRequRTF = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Temp.rtf";

			// Token: 0x04000113 RID: 275
			public const string pmZip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\pm.7z";

			// Token: 0x04000114 RID: 276
			public const string actionProblemZip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Problem.7z";

			// Token: 0x04000115 RID: 277
			public const string actionProblemRTF = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Temp_Problem.rtf";

			// Token: 0x04000116 RID: 278
			public const string actionActionZip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Action.7z";

			// Token: 0x04000117 RID: 279
			public const string actionActionRTF = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Temp_Action.rtf";

			// Token: 0x04000118 RID: 280
			public const string PMImageDir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm.files";

			// Token: 0x04000119 RID: 281
			public const string PMHTMLZip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z";

			// Token: 0x0400011A RID: 282
			public const string Content1 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content1.rtf";

			// Token: 0x0400011B RID: 283
			public const string Content2 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content2.rtf";

			// Token: 0x0400011C RID: 284
			public const string Content3 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content3.rtf";

			// Token: 0x0400011D RID: 285
			public const string Content4 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content4.rtf";

			// Token: 0x0400011E RID: 286
			public const string Content5 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content5.rtf";

			// Token: 0x0400011F RID: 287
			public const string Content6 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content6.rtf";

			// Token: 0x04000120 RID: 288
			public const string Content7 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content7.rtf";

			// Token: 0x04000121 RID: 289
			public const string Content8 = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content8.rtf";

			// Token: 0x04000122 RID: 290
			public const string Content1Zip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content1.7z";

			// Token: 0x04000123 RID: 291
			public const string Content2Zip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content2.7z";

			// Token: 0x04000124 RID: 292
			public const string Content3Zip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content3.7z";

			// Token: 0x04000125 RID: 293
			public const string Content4Zip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content4.7z";

			// Token: 0x04000126 RID: 294
			public const string Content5Zip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content5.7z";

			// Token: 0x04000127 RID: 295
			public const string Content6Zip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content6.7z";

			// Token: 0x04000128 RID: 296
			public const string Content7Zip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content7.7z";

			// Token: 0x04000129 RID: 297
			public const string Content8Zip = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\Content8.7z";

			// Token: 0x0400012A RID: 298
			public const string AttachReportFileDir = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\Report";

			// Token: 0x0400012B RID: 299
			public const string AttachActionFileDir = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\Action";

			// Token: 0x0400012C RID: 300
			public const string AttachPMActionFileDir = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K3\\PMAction";

			// Token: 0x0400012D RID: 301
			public const string AttachReportFileDir_E = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K3_E\\Report";

			// Token: 0x0400012E RID: 302
			public const string AttachActionFileDir_E = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K3_E\\Action";

			// Token: 0x0400012F RID: 303
			public const string AttachPMActionFileDir_E = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K3_E\\PMAction";

			// Token: 0x04000130 RID: 304
			public const string AttachReportFileDir_M = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K5_M\\Report";

			// Token: 0x04000131 RID: 305
			public const string AttachActionFileDir_M = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K5_M\\Action";

			// Token: 0x04000132 RID: 306
			public const string AttachPMActionFileDir_M = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K5_M\\PMAction";

			// Token: 0x04000133 RID: 307
			public const string AttachReportFileDir_ATV = "\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\Report";

			// Token: 0x04000134 RID: 308
			public const string AttachActionFileDir_ATV = "\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\Action";

			// Token: 0x04000135 RID: 309
			public const string AttachPMActionFileDir_ATV = "\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\PMAction";

			// Token: 0x04000136 RID: 310
			public const string AttachZipFile = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\attach\\Attachment.zip";

			// Token: 0x04000137 RID: 311
			public const string AttachFileDir = "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\attach\\File";

			// Token: 0x0200001E RID: 30
			public enum HTMLtype
			{
				// Token: 0x0400017B RID: 379
				none,
				// Token: 0x0400017C RID: 380
				report,
				// Token: 0x0400017D RID: 381
				action,
				// Token: 0x0400017E RID: 382
				pm
			}
		}

		// Token: 0x0200001C RID: 28
		public class Download
		{
			// Token: 0x04000138 RID: 312
			public const string tempDir = "C:\\Temp\\CimitarAdmin\\Maint\\download";

			// Token: 0x04000139 RID: 313
			public const string tempContDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content";

			// Token: 0x0400013A RID: 314
			public const string tempAttDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\attach";

			// Token: 0x0400013B RID: 315
			public const string tempHTMLDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML";

			// Token: 0x0400013C RID: 316
			public const string reportHTMLDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report";

			// Token: 0x0400013D RID: 317
			public const string actionHTMLdir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action";

			// Token: 0x0400013E RID: 318
			public const string pmHTMLDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM";

			// Token: 0x0400013F RID: 319
			public const string reportHTMLImageDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report\\report.files";

			// Token: 0x04000140 RID: 320
			public const string actionHTMLImageDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.files";

			// Token: 0x04000141 RID: 321
			public const string PMImageDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\pm.files";

			// Token: 0x04000142 RID: 322
			public const string reportHTML = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report\\report.html";

			// Token: 0x04000143 RID: 323
			public const string actionHTML = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.html";

			// Token: 0x04000144 RID: 324
			public const string pmContent1HTML = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content1.html";

			// Token: 0x04000145 RID: 325
			public const string pmContent2HTML = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content2.html";

			// Token: 0x04000146 RID: 326
			public const string pmContent3HTML = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content3.html";

			// Token: 0x04000147 RID: 327
			public const string pmContent4HTML = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content4.html";

			// Token: 0x04000148 RID: 328
			public const string pmContent5HTML = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content5.html";

			// Token: 0x04000149 RID: 329
			public const string pmContent6HTML = "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content6.html";

			// Token: 0x0400014A RID: 330
			public const string reportZip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\MailForm.7z";

			// Token: 0x0400014B RID: 331
			public const string reportCheckZip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.7z";

			// Token: 0x0400014C RID: 332
			public const string reportCheckRTF = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\TempC.rtf";

			// Token: 0x0400014D RID: 333
			public const string reportRequZip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.7z";

			// Token: 0x0400014E RID: 334
			public const string reportRequRTF = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp.rtf";

			// Token: 0x0400014F RID: 335
			public const string actionProblemZip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Problem.7z";

			// Token: 0x04000150 RID: 336
			public const string actionProblemRTF = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Problem.rtf";

			// Token: 0x04000151 RID: 337
			public const string actionActionZip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Action.7z";

			// Token: 0x04000152 RID: 338
			public const string actionActionRTF = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Temp_Action.rtf";

			// Token: 0x04000153 RID: 339
			public const string Content1Zip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.7z";

			// Token: 0x04000154 RID: 340
			public const string Content2Zip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content2.7z";

			// Token: 0x04000155 RID: 341
			public const string Content3Zip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.7z";

			// Token: 0x04000156 RID: 342
			public const string Content4Zip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.7z";

			// Token: 0x04000157 RID: 343
			public const string Content5Zip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.7z";

			// Token: 0x04000158 RID: 344
			public const string Content6Zip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content6.7z";

			// Token: 0x04000159 RID: 345
			public const string Content7Zip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.7z";

			// Token: 0x0400015A RID: 346
			public const string Content8Zip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.7z";

			// Token: 0x0400015B RID: 347
			public const string Content1 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content1.rtf";

			// Token: 0x0400015C RID: 348
			public const string Content2 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content2.rtf";

			// Token: 0x0400015D RID: 349
			public const string Content3 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content3.rtf";

			// Token: 0x0400015E RID: 350
			public const string Content4 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content4.rtf";

			// Token: 0x0400015F RID: 351
			public const string Content5 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content5.rtf";

			// Token: 0x04000160 RID: 352
			public const string Content6 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content6.rtf";

			// Token: 0x04000161 RID: 353
			public const string Content7 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content7.rtf";

			// Token: 0x04000162 RID: 354
			public const string Content8 = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\Content8.rtf";

			// Token: 0x04000163 RID: 355
			public const string pmHTMLZip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z";

			// Token: 0x04000164 RID: 356
			public const string testZip = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\test.7z";

			// Token: 0x04000165 RID: 357
			public const string testRTF = "C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\test.rtf";

			// Token: 0x04000166 RID: 358
			public const string AttachReportFileDir = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\Report";

			// Token: 0x04000167 RID: 359
			public const string AttachActionFileDir = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\Action";

			// Token: 0x04000168 RID: 360
			public const string AttachPMActionFileDir = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K3\\PMAction";

			// Token: 0x04000169 RID: 361
			public const string AttachReportFileDir_E = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K3_E\\Report";

			// Token: 0x0400016A RID: 362
			public const string AttachActionFileDir_E = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K3_E\\Action";

			// Token: 0x0400016B RID: 363
			public const string AttachPMActionFileDir_E = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K3_E\\PMAction";

			// Token: 0x0400016C RID: 364
			public const string AttachReportFileDir_M = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K5_M\\Report";

			// Token: 0x0400016D RID: 365
			public const string AttachActionFileDir_M = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K5_M\\Action";

			// Token: 0x0400016E RID: 366
			public const string AttachPMActionFileDir_M = "\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\K5_M\\PMAction";

			// Token: 0x0400016F RID: 367
			public const string AttachReportFileDir_ATV = "\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\Report";

			// Token: 0x04000170 RID: 368
			public const string AttachActionFileDir_ATV = "\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\Action";

			// Token: 0x04000171 RID: 369
			public const string AttachPMActionFileDir_ATV = "\\\\v1cifsn1\\tfahcc$\\Maintenance\\ATV\\PMAction";

			// Token: 0x04000172 RID: 370
			public const string AttachFileDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\File";

			// Token: 0x04000173 RID: 371
			public const string AttachFileActionDir = "C:\\Temp\\CimitarAdmin\\Maint\\download\\attach\\ActionFile";
		}

		// Token: 0x0200001D RID: 29
		public class CSV
		{
			// Token: 0x04000174 RID: 372
			public const string tempDir = "C:\\Temp\\CimitarAdmin\\CSV\\download";

			// Token: 0x04000175 RID: 373
			public const string CSVZip = "C:\\Temp\\CimitarAdmin\\CSV\\download\\Problem.7z";

			// Token: 0x04000176 RID: 374
			public const string actionCSVRTF = "C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp_Problem.rtf";

			// Token: 0x04000177 RID: 375
			public const string reportCheckCSVRTF = "C:\\Temp\\CimitarAdmin\\CSV\\download\\TempC.rtf";

			// Token: 0x04000178 RID: 376
			public const string reportRequCSvRTF = "C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp.rtf";

			// Token: 0x04000179 RID: 377
			public const string actionActionCSVRTF = "C:\\Temp\\CimitarAdmin\\CSV\\download\\Temp_Action.rtf";
		}
	}
}
