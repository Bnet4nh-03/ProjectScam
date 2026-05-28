using System;
using System.Collections;
using System.Data;
using System.IO;
using ATDFW.Base.FrameWork;

namespace Amkor.CADModules.HccSTReportModule.Class
{
	// Token: 0x0200002F RID: 47
	internal class CReportCtrl
	{
		// Token: 0x060000ED RID: 237 RVA: 0x0001A41B File Offset: 0x0001861B
		public CReportCtrl()
		{
			this._instance = HccSTReportModule._instance;
			this._alFiles = new ArrayList();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0001A444 File Offset: 0x00018644
		public void Init(string fileDir)
		{
			DataSet dataSet = new DataSet();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_INIT_Ctrl] @flag = 'INIT'";
			dataSet = this._instance._cComm.QueryCall(sQuery);
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					this._plantCodes = dataSet.Tables[0].Rows[i]["plant_code_report"].ToString().Split(new char[]
					{
						';'
					});
					dataSet.Tables[0].Rows[i]["ownership"].ToString();
					dataSet.Tables[0].Rows[i]["hardware_type"].ToString();
					dataSet.Tables[0].Rows[i]["data_type"].ToString();
				}
			}
			this._fileDir = fileDir + "\\";
			if (Directory.Exists(this._fileDir))
			{
				foreach (string text in Directory.GetFiles(this._fileDir))
				{
				}
				return;
			}
			Directory.CreateDirectory(this._fileDir);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0001A5D4 File Offset: 0x000187D4
		public void InitDt()
		{
			this._dtEWS_PC = null;
			this._dtEWS_PIB = null;
			this._dtEWS_PT = null;
			this._dtEWS_KIT = null;
			this._dtFT_LB = null;
			this._dtFT_CK = null;
			this._dtFT_SK = null;
			this._dtFT_HS = null;
			this._dtFT_DUT = null;
			this._dtFT_LK = null;
			this._dtFT_DK = null;
			this._dtEQ = null;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0001A638 File Offset: 0x00018838
		public void UpdateWW()
		{
			this._iNowYear = DateTime.Now.Year;
			this._iNowWeek = WWDateManager.getworkweek(DateTime.Now, out this._iNowYear);
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_UPLOAD_Ctrl] @flag = 'SET_WW', @desc = '" + this._iNowYear.ToString() + this._iNowWeek.ToString("00") + "'";
			this._instance._cComm.QueryCall(sQuery);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0001A6AC File Offset: 0x000188AC
		public void GetData()
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_UPLOAD_Ctrl] @flag = 'GET_DATA'";
			DataSet dataSet = this._instance._cComm.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0)
			{
				if (dataSet.Tables[0].Rows.Count > 1)
				{
					this._dtEWS_PC = dataSet.Tables[0];
					this._dtEWS_PC.TableName = "EWS-PC";
				}
				if (dataSet.Tables[1].Rows.Count > 1)
				{
					this._dtEWS_PIB = dataSet.Tables[1];
					this._dtEWS_PIB.TableName = "EWS-PIB";
				}
				if (dataSet.Tables[2].Rows.Count > 1)
				{
					this._dtEWS_PT = dataSet.Tables[2];
					this._dtEWS_PT.TableName = "EWS-PT";
				}
				if (dataSet.Tables[3].Rows.Count > 1)
				{
					this._dtEWS_KIT = dataSet.Tables[3];
					this._dtEWS_KIT.TableName = "EWS-KIT";
				}
				if (dataSet.Tables[4].Rows.Count > 1)
				{
					this._dtFT_LB = dataSet.Tables[4];
					this._dtFT_LB.TableName = "FT-LB";
				}
				if (dataSet.Tables[5].Rows.Count > 1)
				{
					this._dtFT_CK = dataSet.Tables[5];
					this._dtFT_CK.TableName = "FT-CK";
				}
				if (dataSet.Tables[6].Rows.Count > 1)
				{
					this._dtFT_SK = dataSet.Tables[6];
					this._dtFT_SK.TableName = "FT-SK";
				}
				if (dataSet.Tables[7].Rows.Count > 1)
				{
					this._dtFT_HS = dataSet.Tables[7];
					this._dtFT_HS.TableName = "FT-HS";
				}
				if (dataSet.Tables[8].Rows.Count > 1)
				{
					this._dtFT_DUT = dataSet.Tables[8];
					this._dtFT_DUT.TableName = "FT-DUT";
				}
				if (dataSet.Tables[9].Rows.Count > 1)
				{
					this._dtFT_LK = dataSet.Tables[9];
					this._dtFT_LK.TableName = "FT-LK";
				}
				if (dataSet.Tables[10].Rows.Count > 1)
				{
					this._dtFT_DK = dataSet.Tables[10];
					this._dtFT_DK.TableName = "FT-DK";
				}
				if (dataSet.Tables[11].Rows.Count > 1)
				{
					this._dtEQ = dataSet.Tables[11];
					this._dtEQ.TableName = "EQ";
				}
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0001A9B0 File Offset: 0x00018BB0
		public void GetData(string plantCode)
		{
			this.InitDt();
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_UPLOAD_Ctrl] @flag = 'GET_DATA', @plantCode = '" + plantCode + "'";
			DataSet dataSet = this._instance._cComm.QueryCall(sQuery);
			if (dataSet.Tables.Count > 0)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					this._dtEWS_PC = dataSet.Tables[0];
					this._dtEWS_PC.TableName = "EWS-PC";
				}
				if (dataSet.Tables[1].Rows.Count > 0)
				{
					this._dtEWS_PIB = dataSet.Tables[1];
					this._dtEWS_PIB.TableName = "EWS-PIB";
				}
				if (dataSet.Tables[2].Rows.Count > 0)
				{
					this._dtEWS_PT = dataSet.Tables[2];
					this._dtEWS_PT.TableName = "EWS-PT";
				}
				if (dataSet.Tables[3].Rows.Count > 0)
				{
					this._dtEWS_KIT = dataSet.Tables[3];
					this._dtEWS_KIT.TableName = "EWS-KIT";
				}
				if (dataSet.Tables[4].Rows.Count > 0)
				{
					this._dtFT_LB = dataSet.Tables[4];
					this._dtFT_LB.TableName = "FT-LB";
				}
				if (dataSet.Tables[5].Rows.Count > 0)
				{
					this._dtFT_CK = dataSet.Tables[5];
					this._dtFT_CK.TableName = "FT-CK";
				}
				if (dataSet.Tables[6].Rows.Count > 0)
				{
					this._dtFT_SK = dataSet.Tables[6];
					this._dtFT_SK.TableName = "FT-SK";
				}
				if (dataSet.Tables[7].Rows.Count > 0)
				{
					this._dtFT_HS = dataSet.Tables[7];
					this._dtFT_HS.TableName = "FT-HS";
				}
				if (dataSet.Tables[8].Rows.Count > 0)
				{
					this._dtFT_DUT = dataSet.Tables[8];
					this._dtFT_DUT.TableName = "FT-DUT";
				}
				if (dataSet.Tables[9].Rows.Count > 0)
				{
					this._dtFT_LK = dataSet.Tables[9];
					this._dtFT_LK.TableName = "FT-LK";
				}
				if (dataSet.Tables[10].Rows.Count > 0)
				{
					this._dtFT_DK = dataSet.Tables[10];
					this._dtFT_DK.TableName = "FT-DK";
				}
				if (dataSet.Tables[11].Rows.Count > 0)
				{
					this._dtEQ = dataSet.Tables[11];
					this._dtEQ.TableName = "EQ";
				}
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0001ACC4 File Offset: 0x00018EC4
		public void MakeCSV()
		{
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_ST_Report_INIT_Ctrl] @flag = 'INIT'";
				dataSet = this._instance._cComm.QueryCall(sQuery);
				string text = string.Empty;
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						text = dataSet.Tables[0].Rows[i]["plant_code"].ToString();
						dataSet.Tables[0].Rows[i]["ownership"].ToString();
						dataSet.Tables[0].Rows[i]["hardware_type"].ToString();
						dataSet.Tables[0].Rows[i]["data_type"].ToString();
					}
				}
				string text2 = Environment.CurrentDirectory + "\\STReport\\";
				if (Directory.Exists(text2))
				{
					if (Directory.GetFiles(text2).Length != 0)
					{
						Directory.Delete(text2, true);
					}
					Directory.CreateDirectory(text2);
				}
				else
				{
					Directory.CreateDirectory(text2);
				}
				this._iNowYear = DateTime.Now.Year;
				this._iNowWeek = WWDateManager.getworkweek(DateTime.Now, out this._iNowYear);
				string text3 = string.Empty;
				CSVControl csvcontrol = new CSVControl();
				if (this._dtEWS_PC != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtEWS_PC.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtEWS_PC);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtEWS_PIB != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtEWS_PIB.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtEWS_PIB);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtEWS_PT != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtEWS_PT.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtEWS_PT);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtEWS_KIT != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtEWS_KIT.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtEWS_KIT);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtFT_LB != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtFT_LB.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtFT_LB);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtFT_CK != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtFT_CK.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtFT_CK);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtFT_SK != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtFT_SK.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtFT_SK);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtFT_HS != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtFT_HS.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtFT_HS);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtFT_DUT != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtFT_DUT.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtFT_DUT);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtFT_LK != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtFT_LK.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtFT_LK);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
				if (this._dtFT_DK != null)
				{
					text3 = string.Concat(new string[]
					{
						text2,
						text,
						"-",
						this._dtFT_DK.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text3, this._dtFT_DK);
					if (this._alFiles.IndexOf(text3) == -1)
					{
						this._alFiles.Add(text3);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0001B4F8 File Offset: 0x000196F8
		public void MakeCSV(string planCode)
		{
			try
			{
				this._iNowYear = DateTime.Now.Year;
				this._iNowWeek = WWDateManager.getworkweek(DateTime.Now, out this._iNowYear);
				string text = string.Empty;
				CSVControl csvcontrol = new CSVControl();
				if (this._dtEWS_PC != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtEWS_PC.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtEWS_PC);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtEWS_PIB != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtEWS_PIB.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtEWS_PIB);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtEWS_PT != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtEWS_PT.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtEWS_PT);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtEWS_KIT != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtEWS_KIT.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtEWS_KIT);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtFT_LB != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtFT_LB.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtFT_LB);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtFT_CK != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtFT_CK.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtFT_CK);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtFT_SK != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtFT_SK.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtFT_SK);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtFT_HS != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtFT_HS.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtFT_HS);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtFT_DUT != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtFT_DUT.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtFT_DUT);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtFT_LK != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtFT_LK.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtFT_LK);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtFT_DK != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtFT_DK.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtFT_DK);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
				if (this._dtEQ != null)
				{
					text = string.Concat(new string[]
					{
						this._fileDir,
						planCode,
						"-",
						this._dtEQ.TableName,
						"-",
						this._iNowYear.ToString(),
						this._iNowWeek.ToString("00"),
						".csv"
					});
					csvcontrol.generateCSV(text, this._dtEQ);
					if (this._alFiles.IndexOf(text) == -1)
					{
						this._alFiles.Add(text);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0400025B RID: 603
		private HccSTReportModule _instance;

		// Token: 0x0400025C RID: 604
		private DataTable _dtEWS_PC;

		// Token: 0x0400025D RID: 605
		private DataTable _dtEWS_PIB;

		// Token: 0x0400025E RID: 606
		private DataTable _dtEWS_PT;

		// Token: 0x0400025F RID: 607
		private DataTable _dtEWS_KIT;

		// Token: 0x04000260 RID: 608
		private DataTable _dtFT_LB;

		// Token: 0x04000261 RID: 609
		private DataTable _dtFT_CK;

		// Token: 0x04000262 RID: 610
		private DataTable _dtFT_SK;

		// Token: 0x04000263 RID: 611
		private DataTable _dtFT_HS;

		// Token: 0x04000264 RID: 612
		private DataTable _dtFT_DUT;

		// Token: 0x04000265 RID: 613
		private DataTable _dtFT_LK;

		// Token: 0x04000266 RID: 614
		private DataTable _dtFT_DK;

		// Token: 0x04000267 RID: 615
		private DataTable _dtEQ;

		// Token: 0x04000268 RID: 616
		private int _iNowYear;

		// Token: 0x04000269 RID: 617
		private int _iNowWeek;

		// Token: 0x0400026A RID: 618
		public string _fileDir = string.Empty;

		// Token: 0x0400026B RID: 619
		public string[] _plantCodes;

		// Token: 0x0400026C RID: 620
		private ArrayList _alFiles;
	}
}
