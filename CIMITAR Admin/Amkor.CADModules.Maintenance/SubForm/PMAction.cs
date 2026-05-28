using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.RTFConverter;
using Amkor.CADModules.Maintenance.RTFConverter.Converter.Html;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;
using Amkor.CADModules.Maintenance.SubForm.PMActionSubControl;
using Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Action;
using Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Approval;
using Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Final;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using Report_Email;
using SevenZip;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000A RID: 10
	public partial class PMAction : Form
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00006E5C File Offset: 0x0000505C
		private void pbSummit_MouseEnter(object sender, EventArgs e)
		{
			this.pbSummit.Image = Resources.submit_down;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00006E6F File Offset: 0x0000506F
		private void pbSummit_MouseLeave(object sender, EventArgs e)
		{
			this.pbSummit.Image = Resources.submit;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00006E82 File Offset: 0x00005082
		private void pbApprovalCancel_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.cancel_down;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00006E95 File Offset: 0x00005095
		private void pbApprovalCancel_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.cancel;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00006EA8 File Offset: 0x000050A8
		private void pbView_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.view;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00006EBB File Offset: 0x000050BB
		private void pbView_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.view_down;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00006ECE File Offset: 0x000050CE
		private void pbClear_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.clear;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00006EE1 File Offset: 0x000050E1
		private void pbClear_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.clearn_down;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00006EF4 File Offset: 0x000050F4
		private void pbApprove_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.approved;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00006F07 File Offset: 0x00005107
		private void pbApprove_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.approved_down;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00006F1A File Offset: 0x0000511A
		private void pbDelete_MouseLeave(object sender, EventArgs e)
		{
			this.pbRequestCancel.Image = Resources.cancel;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00006F2D File Offset: 0x0000512D
		private void pbDelete_MouseEnter(object sender, EventArgs e)
		{
			this.pbRequestCancel.Image = Resources.cancel_down;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00006F40 File Offset: 0x00005140
		public PMAction(string Report, FactorySettings factorySetting, CIMitarAccount cimitarUser)
		{
			this._factorySetting = factorySetting;
			this._queryMgr = new QueryMgr(factorySetting);
			this._cReportItem = new cReportItem();
			this._sFileList = string.Empty;
			bool flag = cimitarUser._userstring1 != null;
			if (flag)
			{
				string text = cimitarUser._userstring1.ToString();
				bool flag2 = text.IndexOf("CAD_MAINT_ADMIN") != -1;
				if (flag2)
				{
					this._isAdmin = true;
				}
			}
			bool flag3 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
			if (flag3)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
			}
			bool flag4 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content");
			if (flag4)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content");
			}
			bool flag5 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report");
			if (flag5)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report");
			}
			bool flag6 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action");
			if (flag6)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action");
			}
			bool flag7 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action");
			if (flag7)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action");
			}
			this.InitializeComponent();
			base.Tag = MainPageType.PreventMaintenance;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			bool flag8 = commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG";
			if (flag8)
			{
				this._isDebug = true;
				this._isAdmin = true;
			}
			else
			{
				this._sUserId = cimitarUser._id;
			}
			this.pbEdite.Tag = "Edit";
			bool reportData = this.GetReportData(Report);
			if (reportData)
			{
				this.DisplayItem();
				cConst.initContents(this._factorySetting, this._cReportItem.sFactory, this._cReportItem.sCategory);
				this._rui = new RequestUserInformation(this._cReportItem);
				this._rui.Dock = DockStyle.Top;
				this.pnUserInformation.Controls.Add(this._rui);
				this.pnUserInformation.AutoSize = true;
				this._ri = new RequestInformation(this._cReportItem);
				this._ri.Dock = DockStyle.Top;
				this.pnPMInformation.Controls.Add(this._ri);
				this.pnPMInformation.AutoSize = true;
				this._api = new ApInformation(this._cReportItem);
				this._api.Dock = DockStyle.Top;
				this.pnApInformation.Controls.Add(this._api);
				this.pnApInformation.AutoSize = true;
				this._prc = new PMRequestContent(this._cReportItem);
				this._prc.Dock = DockStyle.Fill;
				this.pnRequestContent.Controls.Add(this._prc);
				this.pnRequestContent.AutoSize = true;
				this._apc = new ApContent(this._cReportItem);
				this._apc.Dock = DockStyle.Fill;
				this.pnApContent.Controls.Add(this._apc);
				this._apui = new ApUserlInformation(this._factorySetting, this._cReportItem, this._factorySetting, cimitarUser, this._ri);
				this._apui.Dock = DockStyle.Top;
				this.pnApUserInformation.Controls.Add(this._apui);
				this.gbEditeTitle.Visible = false;
				this.gbCancel.Visible = false;
				bool flag9 = this._cReportItem.sReportStauts == "11";
				if (flag9)
				{
					this.gbEditeTitle.Visible = true;
					this.gbCancel.Visible = true;
					this.tabControl.SelectedTab = this.tpApproval;
					this.tabControl.TabPages.Remove(this.tpConfirmation);
					this.tabControl.TabPages.Remove(this.tpPMAction);
					this.tabControl.TabPages.Remove(this.tpPMFinal);
				}
				bool flag10 = this._cReportItem.sReportStauts == "12" || this._cReportItem.sReportStauts == "13" || this._cReportItem.sReportStauts == "14" || this._cReportItem.sReportStauts == "96";
				if (flag10)
				{
					this.gbApView.Visible = true;
					this.pnApFunction.Visible = false;
					bool flag11 = this._cReportItem.sReportStauts == "12";
					if (flag11)
					{
						this.tabControl.SelectedTab = this.tpPMAction;
						this.tabControl.TabPages.Remove(this.tpConfirmation);
						this.tabControl.TabPages.Remove(this.tpPMFinal);
					}
					this._aui = new ActionUserInformation(this._cReportItem, this._factorySetting, cimitarUser, this._ri, this._apui);
					this._aui.Dock = DockStyle.Top;
					this.pnActionUserInformation.Controls.Add(this._aui);
					this._ai = new ActionInformation(this._cReportItem, this._factorySetting);
					this._ai.Dock = DockStyle.Top;
					this.pnActionInformation.Controls.Add(this._ai);
					this.pnActionInformation.AutoSize = true;
					this._ac = new ActionContent(this._cReportItem);
					this._ac.Dock = DockStyle.Fill;
					this.pnActionContent.Controls.Add(this._ac);
					this._ao = new ActionOther(this._cReportItem);
					this._ao.Dock = DockStyle.Top;
					this.pnActionAttach.Controls.Add(this._ao);
				}
				bool flag12 = this._cReportItem.sReportStauts == "13" || this._cReportItem.sReportStauts == "14";
				if (flag12)
				{
					bool flag13 = this._cReportItem.sReportStauts == "14";
					if (flag13)
					{
						this.gbFinalView.Visible = true;
						this.pnFinalFunction.Visible = false;
						this.pnFinalInformation.Visible = true;
					}
					this.gbActionView.Visible = true;
					this.pnActionFuction.Visible = false;
					this.tabControl.SelectedTab = this.tpPMFinal;
					this._fui = new FinalUserInformation(this._cReportItem, this._factorySetting, cimitarUser, this._ri);
					this._fui.Dock = DockStyle.Top;
					this.pnFinalUserInformation.Controls.Add(this._fui);
					this._fi = new FinalInformation(this._cReportItem);
					this._fi.Dock = DockStyle.Top;
					this.pnFinalInformation.Controls.Add(this._fi);
					this.pnFinalUserInformation.AutoSize = true;
					this._fc = new FinalContent(this._cReportItem);
					this._fc.Dock = DockStyle.Fill;
					this.pnFinalContent.Controls.Add(this._fc);
					this.pnFinalContent.AutoSize = true;
					this._acm = new ActionConfirmation(this._factorySetting, this._cReportItem);
					this._acm.Dock = DockStyle.Fill;
					this.tpConfirmation.Controls.Add(this._acm);
				}
				bool flag14 = this._cReportItem.sReportStauts == "97" || this._cReportItem.sReportStauts == "98";
				if (flag14)
				{
					this.tabControl.TabPages.Remove(this.tpApproval);
					this.tabControl.TabPages.Remove(this.tpConfirmation);
					this.tabControl.TabPages.Remove(this.tpPMAction);
					this.tabControl.TabPages.Remove(this.tpPMFinal);
				}
				else
				{
					bool flag15 = this._cReportItem.sReportStauts == "96";
					if (flag15)
					{
						this.tabControl.TabPages.Remove(this.tpConfirmation);
						this.tabControl.TabPages.Remove(this.tpPMAction);
						this.tabControl.TabPages.Remove(this.tpPMFinal);
					}
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00007820 File Offset: 0x00005A20
		private void DisplayItem()
		{
			try
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				bool flag = this._cReportItem.sId == this._sUserId || this._isAdmin;
				if (flag)
				{
					this.gbCancel.Visible = true;
				}
				this.tbPMReport.Text = this._cReportItem.sReportName;
				bool flag2 = this._sUserId == "jisyang01" && this._isDebug;
				if (flag2)
				{
					this.gbCancel.Visible = true;
				}
				string[] array = this._cReportItem.sPart.Split(new char[]
				{
					';'
				});
				string[] array2 = this._cReportItem.sPartDescription.Split(new char[]
				{
					';'
				});
				for (int i = 0; i < array.Length; i++)
				{
					this._PartList.Add(array[i]);
				}
				for (int j = 0; j < array2.Length; j++)
				{
					this._PartDescription.Add(array2[j]);
				}
				bool flag3 = this._cReportItem.sReportStauts == "97" || this._cReportItem.sReportStauts == "98" || this._cReportItem.sReportStauts == "96";
				if (flag3)
				{
					cFunction.ExcuteSevenZipReport(this._cReportItem.sBinary7, null);
					this.ExcuteSevenZipMail(this._cReportItem.sCancelMail);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000079F8 File Offset: 0x00005BF8
		private bool GetReportData(string Report)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintReportInfo] @_Report= N'" + Report + "', @_Mode=N'PM'";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			bool result;
			if (flag)
			{
				bool flag2 = dataSet.Tables[0].Rows.Count == 0;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("report_error"), MessageLanguage.getMessage("messagebox_notification"));
					result = false;
				}
				else
				{
					this._cReportItem.sReportName = Report;
					this._cReportItem.sReportStauts = dataSet.Tables[0].Rows[0]["status"].ToString();
					this._cReportItem.sReportName = dataSet.Tables[0].Rows[0]["PMReport"].ToString();
					this._cReportItem.sCategory = dataSet.Tables[0].Rows[0]["Category"].ToString();
					this._cReportItem.sMachineNo = dataSet.Tables[0].Rows[0]["Machine"].ToString();
					this._cReportItem.sType = dataSet.Tables[0].Rows[0]["Type"].ToString();
					this._cReportItem.sModel = dataSet.Tables[0].Rows[0]["Model"].ToString();
					this._cReportItem.sCase = dataSet.Tables[0].Rows[0]["Case"].ToString();
					this._cReportItem.sContent1 = dataSet.Tables[0].Rows[0]["Content1"].ToString();
					this._cReportItem.sBinary1 = dataSet.Tables[0].Rows[0]["binary1"].ToString();
					this._cReportItem.sContent8 = dataSet.Tables[0].Rows[0]["Content8"].ToString();
					this._cReportItem.sBinary8 = dataSet.Tables[0].Rows[0]["binary8"].ToString();
					this._cReportItem.sRequestTime = dataSet.Tables[0].Rows[0]["RequestTime"].ToString().Trim();
					this._cReportItem.sToEmail = dataSet.Tables[0].Rows[0]["ToMail"].ToString();
					this._cReportItem.sCCEmail = dataSet.Tables[0].Rows[0]["CCMail"].ToString();
					this._cReportItem.sStartTime = dataSet.Tables[0].Rows[0]["StartTime"].ToString();
					this._cReportItem.sMailForm = dataSet.Tables[0].Rows[0]["requestMail"].ToString();
					this._cReportItem.sFactor = dataSet.Tables[0].Rows[0]["Factor"].ToString();
					this._cReportItem.sAsset = dataSet.Tables[0].Rows[0]["Asset"].ToString();
					this._cReportItem.sWorkType = dataSet.Tables[0].Rows[0]["WorkType"].ToString();
					this._cReportItem.sVendor = dataSet.Tables[0].Rows[0]["Vendor"].ToString();
					this._cReportItem.PMStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["PMStatus"].ToString());
					this._cReportItem.sPMPlanedDate = dataSet.Tables[0].Rows[0]["PlanedDate"].ToString();
					this._cReportItem.sPMEstimatedTime = dataSet.Tables[0].Rows[0]["EstimatedTime"].ToString();
					this._cReportItem.sFactory = dataSet.Tables[0].Rows[0]["Factory"].ToString();
					bool flag3 = dataSet.Tables[0].Columns.Contains("ActionFiles");
					if (flag3)
					{
						this._cReportItem.ActionAttachment = dataSet.Tables[0].Rows[0]["ActionFiles"].ToString();
					}
					bool flag4 = this._cReportItem.sReportStauts == "12" || this._cReportItem.sReportStauts == "13" || this._cReportItem.sReportStauts == "14" || this._cReportItem.sReportStauts == "96";
					if (flag4)
					{
						this._cReportItem.sContent2 = dataSet.Tables[0].Rows[0]["content2"].ToString();
						this._cReportItem.sBinary2 = dataSet.Tables[0].Rows[0]["binary2"].ToString();
						this._cReportItem.sApprovalTime = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["ApprovalTime"]).ToString("yyyy-MM-dd HH:mm");
						this._cReportItem.sApprovalName = dataSet.Tables[0].Rows[0]["ApprovalName"].ToString();
						this._cReportItem.sApprovalTeam = dataSet.Tables[0].Rows[0]["ApprovalTeam"].ToString();
						this._cReportItem.sApprovalMail = dataSet.Tables[0].Rows[0]["approvalMail"].ToString();
					}
					bool flag5 = this._cReportItem.sReportStauts == "13" || this._cReportItem.sReportStauts == "14";
					if (flag5)
					{
						this._cReportItem.sPMDoneName = dataSet.Tables[0].Rows[0]["DoneName"].ToString();
						this._cReportItem.sPMDoneTeam = dataSet.Tables[0].Rows[0]["DoneTeam"].ToString();
						this._cReportItem.sContent3 = dataSet.Tables[0].Rows[0]["Content3"].ToString();
						this._cReportItem.sBinary3 = dataSet.Tables[0].Rows[0]["binary3"].ToString();
						this._cReportItem.sContent4 = dataSet.Tables[0].Rows[0]["Content4"].ToString();
						this._cReportItem.sBinary4 = dataSet.Tables[0].Rows[0]["binary4"].ToString();
						this._cReportItem.sContent5 = dataSet.Tables[0].Rows[0]["Content5"].ToString();
						this._cReportItem.sBinary5 = dataSet.Tables[0].Rows[0]["binary5"].ToString();
						this._cReportItem.sPMDoneMail = dataSet.Tables[0].Rows[0]["DoneMail"].ToString();
						this._cReportItem.sCase = dataSet.Tables[0].Rows[0]["Case"].ToString();
						this._cReportItem.sFactor = dataSet.Tables[0].Rows[0]["Factor"].ToString();
						this._cReportItem.sPMDifficulty = dataSet.Tables[0].Rows[0]["diff"].ToString();
						this._cReportItem.ActionAttachment = dataSet.Tables[0].Rows[0]["ActionFiles"].ToString();
					}
					bool flag6 = this._cReportItem.sReportStauts == "14";
					if (flag6)
					{
						this._cReportItem.sPMFinalName = dataSet.Tables[0].Rows[0]["FinalName"].ToString();
						this._cReportItem.sPMFinalTeam = dataSet.Tables[0].Rows[0]["FinalTeam"].ToString();
						this._cReportItem.sPMFinalTime = dataSet.Tables[0].Rows[0]["FinalTime"].ToString();
						this._cReportItem.sPMFinalMail = dataSet.Tables[0].Rows[0]["FinalMail"].ToString();
						this._cReportItem.sContent6 = dataSet.Tables[0].Rows[0]["Content6"].ToString();
						this._cReportItem.sBinary6 = dataSet.Tables[0].Rows[0]["binary6"].ToString();
					}
					bool flag7 = this._cReportItem.sReportStauts == "98" || this._cReportItem.sReportStauts == "97" || this._cReportItem.sReportStauts == "96";
					if (flag7)
					{
						this._cReportItem.sBinary7 = dataSet.Tables[0].Rows[0]["binary7"].ToString();
						this._cReportItem.sContent7 = dataSet.Tables[0].Rows[0]["content7"].ToString();
						this._cReportItem.sCancelMail = dataSet.Tables[0].Rows[0]["CancelMail"].ToString();
					}
					bool flag8 = dataSet.Tables[0].Columns.Contains("HCCLocation");
					if (flag8)
					{
						string empty3 = string.Empty;
						string empty4 = string.Empty;
						string empty5 = string.Empty;
						string empty6 = string.Empty;
					}
					bool flag9 = dataSet.Tables[0].Columns.Contains("EndTime") && dataSet.Tables[0].Rows[0]["EndTime"].ToString().IndexOf("1900") == -1;
					if (flag9)
					{
						this._cReportItem.sEndTime = dataSet.Tables[0].Rows[0]["EndTime"].ToString().Trim();
						this._cReportItem.sEndTime = this._cReportItem.sEndTime.Substring(0, this._cReportItem.sEndTime.Length - 3);
					}
					this._cReportItem.sName = dataSet.Tables[0].Rows[0]["Name"].ToString();
					this._cReportItem.sTeam = dataSet.Tables[0].Rows[0]["Team"].ToString();
					bool flag10 = dataSet.Tables[0].Columns.Contains("Part");
					if (flag10)
					{
						this._cReportItem.sPart = dataSet.Tables[0].Rows[0]["Part"].ToString();
					}
					bool flag11 = dataSet.Tables[0].Columns.Contains("PartDescription");
					if (flag11)
					{
						this._cReportItem.sPartDescription = dataSet.Tables[0].Rows[0]["PartDescription"].ToString();
					}
					bool flag12 = dataSet.Tables[0].Columns.Contains("diff");
					if (flag12)
					{
						this._cReportItem.sMaintLevel = dataSet.Tables[0].Rows[0]["diff"].ToString();
					}
					bool flag13 = dataSet.Tables[0].Columns.Contains("DetailComment");
					if (flag13)
					{
						this._cReportItem.listDetails = dataSet.Tables[0].Rows[0]["DetailComment"].ToString().Split(new char[]
						{
							'|'
						}).ToList<string>();
					}
					this._cReportItem.sId = dataSet.Tables[0].Rows[0]["id"].ToString();
					result = true;
				}
			}
			else
			{
				MessageBox.Show(MessageLanguage.getMessage("report_error"), MessageLanguage.getMessage("messagebox_notification"));
				result = false;
			}
			return result;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00008928 File Offset: 0x00006B28
		private void CreateSevenZipFile(string sTargetFile, string sSevenZipFile, bool Directory)
		{
			try
			{
				bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
				if (is64BitOperatingSystem)
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x64.dll");
				}
				else
				{
					SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x86.dll");
				}
				SevenZipCompressor sevenZipCompressor = new SevenZipCompressor();
				sevenZipCompressor.CompressionMethod = CompressionMethod.Lzma;
				sevenZipCompressor.CompressionMode = CompressionMode.Create;
				sevenZipCompressor.CompressionLevel = CompressionLevel.Ultra;
				if (Directory)
				{
					sevenZipCompressor.CompressDirectory(sTargetFile, sSevenZipFile);
				}
				else
				{
					sevenZipCompressor.CompressFiles(sSevenZipFile, new string[]
					{
						sTargetFile
					});
				}
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "CreateSevenZipFile", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\PMAction.cs", 499);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000089E8 File Offset: 0x00006BE8
		private byte[] getBinarySevenFile(string sSevenZipFile)
		{
			FileStream fileStream = new FileStream(sSevenZipFile, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return array;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00008A24 File Offset: 0x00006C24
		private void ExcuteSevenZipMail(string sBody)
		{
			SevenZipExtractor sevenZipExtractor = null;
			FileStream fileStream = null;
			try
			{
				bool flag = string.IsNullOrEmpty(sBody);
				if (!flag)
				{
					byte[] array = Convert.FromBase64String(sBody);
					bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
					if (is64BitOperatingSystem)
					{
						SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x64.dll");
					}
					else
					{
						SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + "\\Modules\\7z_x86.dll");
					}
					bool flag2 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					if (flag2)
					{
						File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					}
					fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z", FileMode.Create);
					fileStream.Write(array, 0, array.Length);
					bool flag3 = fileStream != null;
					if (flag3)
					{
						fileStream.Close();
					}
					sevenZipExtractor = new SevenZipExtractor("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					bool flag4 = array.Length != 0 && File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content\\PMHTML.7z");
					if (flag4)
					{
						sevenZipExtractor.ExtractArchive("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM");
					}
				}
			}
			catch (Exception ex)
			{
				bool flag5 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content5.html");
				if (flag5)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content5.html");
				}
				bool flag6 = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content6.html");
				if (flag6)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content6.html");
				}
				cFunction.ErrorMessageBox(ex.Message.ToString(), "ExcuteSevenZipMail", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\PMAction.cs", 556);
			}
			finally
			{
				bool flag7 = sevenZipExtractor != null;
				if (flag7)
				{
					sevenZipExtractor.Dispose();
				}
				bool flag8 = fileStream != null;
				if (flag8)
				{
					fileStream.Dispose();
				}
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00008BB4 File Offset: 0x00006DB4
		private bool loadMailForm(string buttonName, string html)
		{
			bool result;
			try
			{
				this.btn_close.Text = buttonName;
				this.web_Viewer.Url = new Uri(html);
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, MessageLanguage.getMessage("messagebox_error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00008C18 File Offset: 0x00006E18
		private void pbView_Click(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.view;
			this.panel2.Visible = false;
			this.panel_PDF.Parent = this;
			this.panel_PDF.Dock = DockStyle.Fill;
			bool flag = sender.Equals(this.pbAprrovalVeiw);
			if (flag)
			{
				bool flag2 = this._cReportItem.sReportStauts == "96";
				if (flag2)
				{
					this.loadMailForm("Exit", "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content6.html");
				}
				else
				{
					this.loadMailForm("Exit", "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content2.html");
				}
			}
			else
			{
				bool flag3 = sender.Equals(this.pbDoneView);
				if (flag3)
				{
					this.loadMailForm("Exit", "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content3.html");
				}
				else
				{
					bool flag4 = sender.Equals(this.pbFinalView);
					if (flag4)
					{
						this.loadMailForm("Exit", "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content4.html");
					}
					else
					{
						bool flag5 = this._cReportItem.sReportStauts == "97" || this._cReportItem.sReportStauts == "98";
						if (flag5)
						{
							this.loadMailForm("Exit", "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content5.html");
						}
						else
						{
							this.loadMailForm("Exit", "C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\PM\\pm_content1.html");
						}
					}
				}
			}
			this.panel_PDF.Visible = true;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00008D68 File Offset: 0x00006F68
		private void pbEdite_Click(object sender, EventArgs e)
		{
			this.pbEdite.Image = Resources.edit;
			bool flag = this.pbEdite.Tag.ToString().CompareTo("Save") != 0;
			if (flag)
			{
				bool flag2 = string.IsNullOrEmpty(this._sUserId);
				if (flag2)
				{
					Login login = new Login();
					bool flag3 = login.ShowDialog() == DialogResult.OK;
					if (!flag3)
					{
						this._prc.readOnly(true);
						return;
					}
					CIMitarLogin._id = login.id;
					this.getUserData(login.id);
				}
				this.pbEdite.Image = Resources.save;
				this.pbEdite.Tag = (this.gbEditeTitle.Text = "Save");
				this._prc.readOnly(false);
			}
			else
			{
				DialogResult dialogResult = MessageBox.Show(MessageLanguage.getMessage("modify_save"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
				bool flag4 = dialogResult == DialogResult.Yes || dialogResult == DialogResult.No;
				if (flag4)
				{
					this.pbEdite.Tag = (this.gbEditeTitle.Text = "Edit");
					this.pbEdite.Image = Resources.edit;
					this._prc.readOnly(true);
					bool flag5 = dialogResult == DialogResult.Yes;
					if (flag5)
					{
						this.saveToHTMLbyEditor();
						this.panel4.Visible = false;
						this.panel_PDF.Parent = this;
						this.panel_PDF.Dock = DockStyle.Fill;
						this.loadMailForm("Send(Edit)", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content1.html");
						this.panel_PDF.Visible = true;
					}
					else
					{
						this._prc.reloadContent();
					}
				}
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00008F28 File Offset: 0x00007128
		private void saveToHTMLbyEditor()
		{
			Clipboard.Clear();
			FileInfo fileInfo = new FileInfo(cConst.docPath);
			object fullName = fileInfo.FullName;
			object value = Missing.Value;
			bool flag = Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm");
			if (flag)
			{
				Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm", true);
			}
			Thread.Sleep(100);
			Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm");
			string text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\pm_content1.html");
			foreach (string text2 in cConst.sWorkType)
			{
				bool flag2 = text2 == this._ri.getWorkType();
				if (flag2)
				{
					text = text.Replace("VENDOR SERVICE REPORT", text2.ToUpper() + " REPORT");
					break;
				}
			}
			text = text.Replace("7@", "■");
			text = text.Replace("@1", this._cReportItem.sRequestTime);
			text = text.Replace("@2", this._ri.getCategory());
			text = text.Replace("@3", this._ri.getMachine());
			text = text.Replace("@4", this._ri.getModel());
			text = text.Replace("@5", this._ri.getType());
			text = text.Replace("@7", this._ri.getWorkType());
			text = text.Replace("@8", this._ri.getPlenDate());
			text = text.Replace("@9", this._ri.getEstimatedTime());
			IRtfDocument rtfDocument = RtfInterpreterTool.BuildDoc(this._prc.getProblemRTF(), new IRtfInterpreterListener[0]);
			RtfHtmlConverter rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
			text = text.Replace("@-4", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
			rtfDocument = RtfInterpreterTool.BuildDoc(this._prc.getEvidenceRTF(), new IRtfInterpreterListener[0]);
			rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
			text = text.Replace("@-5", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
			text = text.Replace("@-6", string.Concat(new string[]
			{
				this._rui.getTeamText(),
				" ",
				this._rui.getTeamText(),
				"(",
				DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
				")"
			}));
			File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content1.html", text);
			File.Copy(Environment.CurrentDirectory + "\\RES\\maint\\logo.jpg", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\logo.jpg", true);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000091B0 File Offset: 0x000073B0
		private void pbDelete_Click(object sender, EventArgs e)
		{
			this.pbRequestCancel.Image = Resources.cancel;
			CancelForm cancelForm = new CancelForm(true, true);
			bool flag = cancelForm.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this._cReportItem.bRequestCancel = true;
				this._isCancel = true;
				this._rbCancelTemp = new RichTextBox();
				this._rbCancelTemp.Visible = false;
				this._rbCancelTemp.Tag = "7";
				this._rbCancelTemp.Rtf = cancelForm.getContent7().Rtf;
				this.saveToHTML(true);
				this.panel4.Visible = false;
				this.panel_PDF.Parent = this;
				this.panel_PDF.Dock = DockStyle.Fill;
				this.loadMailForm("Send", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content5.html");
				this.panel_PDF.Visible = true;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000928C File Offset: 0x0000748C
		private void btn_close_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			bool flag = this.btn_close.Text == "Send";
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show(MessageLanguage.getMessage("send_mail"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes && this._cReportItem.sReportStauts == "11" && !this._isCancel;
				if (flag2)
				{
					text = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintPMHistory] @_command=N'APPROVAL', @_status=N'12', @_PMReport=N'",
						this.tbPMReport.Text.Trim(),
						"', @_Team=N'",
						this._apui.getTeamString(),
						"', @_Name=N'",
						this._apui.getNameString(),
						"', @_FromMail=N'",
						this._cReportItem.sFromAction,
						"', @_ApprovalTime=N'",
						DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
						"', @_Content2=N'",
						this._apc.getApprovalString().Replace("'", "''"),
						"', @_Binary2=N'",
						this._apc.getBase64String(),
						"', @_mailForm=N'",
						Convert.ToBase64String(this.MakeHTMLZip()),
						"'"
					});
				}
				else
				{
					bool flag3 = dialogResult == DialogResult.Yes && this._cReportItem.sReportStauts == "12" && !this._isCancel;
					if (flag3)
					{
						bool flag4 = !string.IsNullOrEmpty(this._sFileList.Replace(";", string.Empty));
						if (flag4)
						{
							bool flag5 = !cFunction.attachZip(this.tbPMReport.Text.Trim(), this._ai.getRequestTime(), this._cReportItem, this._ao.getAttachList(), true, true);
							if (flag5)
							{
								MessageBox.Show(MessageLanguage.getMessage("attachment_error"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								return;
							}
						}
						text = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintPMHistory] @_command=N'DONE', @_status=N'13', @_PMReport=N'",
							this.tbPMReport.Text.Trim(),
							"', @_Team=N'",
							this._aui.getTeamString(),
							"', @_Name=N'",
							this._aui.getNameString(),
							"', @_Case=N'",
							this._ai.getCase(),
							"', @_Factor=N'",
							this._ai.getFactor(),
							"', @_Vendor=N'",
							this._ai.getVendorText(),
							"', @_FromMail=N'",
							this._cReportItem.sFromAction,
							"', @_Asset=N'",
							this._ai.getAsset(),
							"', @_StartTime=N'",
							this._ai.getStartTimeString(),
							"', @_EndTime=N'",
							DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
							"', @_Content3=N'",
							this._ac.getActionText().Replace("'", "''"),
							"', @_Binary3=N'",
							this._ac.getAction64String(),
							"', @_Content4=N'",
							this._ac.getResultText().Replace("'", "''"),
							"', @_Binary4=N'",
							this._ac.getResult64String(),
							"', @_Content5=N'",
							this._ac.getCommentText().Replace("'", "''"),
							"', @_Binary5=N'",
							this._ac.getComment64String(),
							"', @_mailForm=N'",
							Convert.ToBase64String(this.MakeHTMLZip()),
							"', @_diff=N'",
							this._ai.getDifficulty(),
							"', @_Files=N'",
							this._sFileList,
							"', @_Part=N'",
							this._ao.getPartString(),
							"', @_PartDescription=N'",
							this._ao.getPartDesString(),
							"'"
						});
						bool flag6 = this._detailList.Count != 0;
						if (flag6)
						{
							text += ", @_DetailComment=N'";
							for (int i = 0; i < this._detailList.Count; i++)
							{
								text = text + this._detailList[i].Replace("'", "''") + "|";
							}
							text = text.Remove(text.Length - 1);
							text += "'";
						}
					}
					else
					{
						bool flag7 = dialogResult == DialogResult.Yes && this._cReportItem.sReportStauts == "13";
						if (flag7)
						{
							text = string.Concat(new string[]
							{
								"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintPMHistory] @_command=N'FINAL', @_status=N'14', @_PMReport=N'",
								this.tbPMReport.Text.Trim(),
								"', @_Team=N'",
								this._fui.getTeamString(),
								"', @_FromMail=N'",
								this._cReportItem.sFromAction,
								"', @_Name=N'",
								this._fui.getNameString(),
								"', @_FinalTime=N'",
								this._fi.getFinalTimeText(),
								"', @_Content6=N'",
								this._fc.getFinalText().Replace("'", "''"),
								"', @_Binary6=N'",
								this._fc.getFinal64String(),
								"', @_mailForm=N'",
								Convert.ToBase64String(this.MakeHTMLZip()),
								"'"
							});
						}
						else
						{
							bool flag8 = dialogResult == DialogResult.Yes && this._isCancel;
							if (flag8)
							{
								bool flag9 = this._rbCancelTemp != null;
								if (flag9)
								{
									text = string.Concat(new string[]
									{
										"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintPMDeleteReport] @_PMReport=N'",
										this.tbPMReport.Text.Trim(),
										"', @_User=N'",
										this._sUserId.Trim(),
										"', @_Binary7=N'",
										cFunction.MakeRFTFile(this._rbCancelTemp),
										"', @_CancelMail=N'",
										Convert.ToBase64String(this.MakeHTMLZip()),
										"', @_Content7=N'",
										this._rbCancelTemp.Text.Trim().Replace("'", "''"),
										"'"
									});
									bool flag10 = this._cReportItem.sReportStauts == "12";
									if (flag10)
									{
										text += ", @_Command=N'ACTIONCANCEL'";
									}
									else
									{
										bool bRequestCancel = this._cReportItem.bRequestCancel;
										if (bRequestCancel)
										{
											text += ", @_Command=N'REQUESTCANCEL'";
										}
										else
										{
											text += ", @_Command=N'APPROVALCANCEL'";
										}
									}
								}
								else
								{
									MessageBox.Show(MessageLanguage.getMessage("pm_cancel_error"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
							}
							else
							{
								bool flag11 = dialogResult == DialogResult.No;
								if (flag11)
								{
									this.panel2.Visible = true;
									this.panel4.Visible = true;
									this.panel_PDF.Visible = false;
									this._isCancel = false;
								}
							}
						}
					}
				}
				bool flag12 = !string.IsNullOrEmpty(text);
				if (flag12)
				{
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag13 = dataSet != null;
					if (flag13)
					{
						bool flag14 = dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "OK";
						if (flag14)
						{
							this._cReportItem.sStartTime = this._api.getApprovalTime();
							this.sendMail(false);
						}
						else
						{
							bool flag15 = dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0;
							if (flag15)
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								MessageBox.Show(MessageLanguage.getMessage("upload_error"), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("upload_error2"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
			}
			else
			{
				bool flag16 = this.btn_close.Text == "Send(Edit)";
				if (flag16)
				{
					DialogResult dialogResult2 = MessageBox.Show(MessageLanguage.getMessage("send_mail_modify"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					bool flag17 = dialogResult2 == DialogResult.Yes;
					if (flag17)
					{
						this.updateReport(this.tbPMReport.Text.Trim());
					}
					else
					{
						bool flag18 = dialogResult2 == DialogResult.No;
						if (flag18)
						{
							this.panel2.Visible = true;
							this.panel4.Visible = true;
							this.panel_PDF.Visible = false;
						}
					}
				}
				else
				{
					this.panel2.Visible = true;
					this.panel4.Visible = true;
					this.panel_PDF.Visible = false;
				}
			}
			this._fileSizeHTML = 0L;
			this._fileSizeRTF = 0L;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00009C4C File Offset: 0x00007E4C
		private void sendMail(bool editMode)
		{
			CEmailService cemailService = new CEmailService();
			if (editMode)
			{
				bool flag = cemailService.ExcutePMEmail(this._factorySetting, this.tbPMReport.Text, "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm.files", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm", true, false, false);
				if (flag)
				{
					this._isCancel = false;
					MessageBox.Show(MessageLanguage.getMessage("pm_email_modify_send"), MessageLanguage.getMessage("messagebox_notification"));
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("email_error"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
			else
			{
				bool flag2 = cemailService.ExcutePMEmail(this._factorySetting, this.tbPMReport.Text, "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm.files", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm", false, true, false);
				if (flag2)
				{
					this._isCancel = false;
					MessageBox.Show(MessageLanguage.getMessage("email_pm_send_complete"), MessageLanguage.getMessage("messagebox_notification"));
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
				else
				{
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintPMHistory] @_command=N'Delete', @_status=N'",
						this._cReportItem.sReportStauts,
						"', @_PMReport=N'",
						this.tbPMReport.Text.Trim(),
						"'"
					});
					DataSet dataSet = this._queryMgr.queryCall(sQuery);
					MessageBox.Show(MessageLanguage.getMessage("email_error"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00009DB4 File Offset: 0x00007FB4
		private bool updateReport(string ReportName)
		{
			string sQuery = string.Empty;
			byte[] array = this.MakeHTMLZip();
			bool flag = array == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintPMHistory]  @_command=N'Update', @_PMReport=N'",
					ReportName,
					"', @_Binary1=N'",
					Convert.ToBase64String(this._prc.MakeRFTFile(true)),
					"', @_Binary8=N'",
					Convert.ToBase64String(this._prc.MakeRFTFile(false)),
					"', @_mailForm=N'",
					Convert.ToBase64String(array),
					"', @_id=N'",
					this._sUserId,
					"', @_FromMail=N'",
					this._cReportItem.sFromAction,
					"', @_Content1=N'",
					this._prc.getProblemString().Replace("'", "''"),
					"', @_Content8=N'",
					this._prc.getEvidenceString().Replace("'", "''"),
					"'"
				});
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows.Count != 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper().CompareTo("OK") == 0;
						if (flag4)
						{
							this.sendMail(true);
							return true;
						}
						MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString().Trim(), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("upload_error"), MessageLanguage.getMessage("messagebox_notification"));
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00009FC0 File Offset: 0x000081C0
		private byte[] MakeHTMLZip()
		{
			this.CreateSevenZipFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z", true);
			return this.getBinarySevenFile("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content\\MailForm.7z");
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00009FF0 File Offset: 0x000081F0
		private void pbEdite_MouseLeave(object sender, EventArgs e)
		{
			bool flag = this.pbEdite.Tag.ToString().CompareTo("Save") != 0;
			if (flag)
			{
				this.pbEdite.Image = Resources.edit;
			}
			else
			{
				this.pbEdite.Image = Resources.save;
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000A044 File Offset: 0x00008244
		private void pbEdite_MouseEnter(object sender, EventArgs e)
		{
			bool flag = this.pbEdite.Tag.ToString().CompareTo("Save") != 0;
			if (flag)
			{
				this.pbEdite.Image = Resources.edit_down;
			}
			else
			{
				this.pbEdite.Image = Resources.save_down;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000A098 File Offset: 0x00008298
		private void pbClear_Click(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.clear;
			bool flag = ((PictureBox)sender).Equals(this.pbClear);
			if (flag)
			{
				this._apc.clear();
			}
			else
			{
				bool flag2 = ((PictureBox)sender).Equals(this.pbClear2);
				if (flag2)
				{
					this._ai.clear();
					this._ac.clear();
					this._ao.clear();
				}
				else
				{
					bool flag3 = ((PictureBox)sender).Equals(this.pnFinalClear);
					if (flag3)
					{
						this._fc.clear();
					}
				}
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000A13C File Offset: 0x0000833C
		private void pbApprove_Click(object sender, EventArgs e)
		{
			bool flag = ((PictureBox)sender).Equals(this.pbApprove);
			if (flag)
			{
				this.pbApprove.Image = Resources.approved;
				bool flag2 = this.pbEdite.Tag.ToString() == "Save";
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("pm_rqeuest_save"), MessageLanguage.getMessage("messagebox_notification"));
					return;
				}
				bool flag3 = this._apui.getNameString() == string.Empty;
				if (flag3)
				{
					MessageBox.Show(MessageLanguage.getMessage("input_team"), MessageLanguage.getMessage("messagebox_notification"));
					return;
				}
				bool flag4 = this._apui.getTeamString() == string.Empty;
				if (flag4)
				{
					MessageBox.Show(MessageLanguage.getMessage("input_name"), MessageLanguage.getMessage("messagebox_notification"));
					return;
				}
				bool flag5 = this._apc.checkApprovalString();
				if (flag5)
				{
					MessageBox.Show(MessageLanguage.getMessage("input_pm_content3"), MessageLanguage.getMessage("messagebox_notification"));
					return;
				}
				bool flag6 = this._apui.getToList().Length == 0;
				if (flag6)
				{
					MessageBox.Show(MessageLanguage.getMessage("input_ToMail"), MessageLanguage.getMessage("messagebox_notification"));
					return;
				}
				bool flag7 = this._apui.getCCList().Length == 0;
				if (flag7)
				{
					MessageBox.Show(MessageLanguage.getMessage("input_CCMail"), MessageLanguage.getMessage("messagebox_notification"));
					return;
				}
				this._api.setApprovalTime();
				this.saveToHTML(false);
			}
			else
			{
				bool flag8 = ((PictureBox)sender).Equals(this.pnFinalApprove);
				if (flag8)
				{
					bool flag9 = this._fc.checkFinalText();
					if (flag9)
					{
						MessageBox.Show(MessageLanguage.getMessage("input_pm_content4"), MessageLanguage.getMessage("messagebox_notification"));
						return;
					}
					this._fi.setFinalTime();
					this.saveToHTML(false);
				}
			}
			this.panel4.Visible = false;
			this.panel_PDF.Parent = this;
			this.panel_PDF.Dock = DockStyle.Fill;
			string sReportStauts = this._cReportItem.sReportStauts;
			if (!(sReportStauts == "11"))
			{
				if (sReportStauts == "13")
				{
					this.loadMailForm("Send", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content4.html");
				}
			}
			else
			{
				this.loadMailForm("Send", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content2.html");
			}
			this.panel_PDF.Visible = true;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000A3C4 File Offset: 0x000085C4
		private bool saveToHTML(bool isCancel)
		{
			bool result;
			try
			{
				bool flag = Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm");
				if (flag)
				{
					Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm", true);
				}
				Thread.Sleep(100);
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm");
				string text = string.Empty;
				bool flag2 = this._cReportItem.sReportStauts == "11";
				if (flag2)
				{
					if (isCancel)
					{
						text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\pm_content5.html");
					}
					else
					{
						text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\pm_content2.html");
					}
				}
				else
				{
					bool flag3 = this._cReportItem.sReportStauts == "12";
					if (flag3)
					{
						if (isCancel)
						{
							text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\pm_content6.html");
						}
						else
						{
							text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\pm_content3.html");
						}
					}
					else
					{
						bool flag4 = this._cReportItem.sReportStauts == "13";
						if (flag4)
						{
							text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\pm_content4.html");
						}
					}
				}
				if (isCancel)
				{
					text = text.Replace("VENDOR SERVICE REPORT", this._ri.getWorkType() + " CANCEL REPORT");
				}
				else
				{
					text = text.Replace("VENDOR SERVICE REPORT", this._ri.getWorkType() + " REPORT");
				}
				text = text.Replace("7@", "■");
				text = text.Replace("@1", this._api.getRequestTime());
				text = text.Replace("@2", this._ri.getCategory());
				text = text.Replace("@3", this._ri.getMachine());
				text = text.Replace("@4", this._ri.getModel());
				text = text.Replace("@5", this._ri.getType());
				text = text.Replace("@7", this._ri.getWorkType());
				text = text.Replace("@8", this._ri.getPlenDate());
				text = text.Replace("@9", this._ri.getEstimatedTime());
				IRtfDocument rtfDocument = RtfInterpreterTool.BuildDoc(this._prc.getProblemRTF(), new IRtfInterpreterListener[0]);
				RtfHtmlConverter rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
				text = text.Replace("@-4", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
				rtfDocument = RtfInterpreterTool.BuildDoc(this._prc.getEvidenceRTF(), new IRtfInterpreterListener[0]);
				rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
				text = text.Replace("@-5", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
				text = text.Replace("@-6", string.Concat(new string[]
				{
					this._cReportItem.sTeam,
					" ",
					this._cReportItem.sName,
					"(",
					this._cReportItem.sRequestTime,
					")"
				}));
				bool flag5 = !isCancel;
				if (flag5)
				{
					rtfDocument = RtfInterpreterTool.BuildDoc(this._apc.getApprovalRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					text = text.Replace("@-7", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
					text = text.Replace("@-8", string.Concat(new string[]
					{
						this._apui.getTeamString(),
						" ",
						this._apui.getNameString(),
						"(",
						this._api.getApprovalTime(),
						")"
					}));
					bool flag6 = this._cReportItem.sReportStauts == "12" || this._cReportItem.sReportStauts == "13";
					if (flag6)
					{
						List<string> partList = this._ao.getPartList();
						List<string> partDesList = this._ao.getPartDesList();
						bool flag7 = partList.Count != 0;
						if (flag7)
						{
							int num = text.IndexOf("CHANGE PARTS");
							num = text.IndexOf("<tr style='height:17.15pt'>", num);
							int num2 = text.IndexOf("</tr>", num);
							string value = text.Substring(num, num2 - num);
							string[] array = partList[0].Split(new char[]
							{
								'|'
							});
							bool flag8 = array.Length > 1;
							if (flag8)
							{
								text = text.Replace("@-16", partDesList[0]);
								text = text.Replace("@-17", (array[0] != null) ? array[0] : "");
								text = text.Replace("@-18", (array[1] != null) ? array[1] : "");
							}
							else
							{
								text = text.Replace("@-16", string.Empty);
								text = text.Replace("@-17", string.Empty);
								text = text.Replace("@-18", string.Empty);
							}
							num2 = text.IndexOf("</tr>", num);
							for (int i = partList.Count - 1; i > 0; i--)
							{
								array = partList[i].Split(new char[]
								{
									'|'
								});
								bool flag9 = array.Length > 1;
								if (flag9)
								{
									text = text.Insert(num2 - 1, value);
									text = text.Replace("@-16", partDesList[i]);
									text = text.Replace("@-17", (array[0] != null) ? array[0] : "");
									text = text.Replace("@-18", (array[1] != null) ? array[1] : "");
								}
							}
						}
						else
						{
							text = text.Replace("@-16", string.Empty);
							text = text.Replace("@-17", string.Empty);
							text = text.Replace("@-18", string.Empty);
						}
						text = text.Replace("@-1", this._ai.getVendorText());
						text = text.Replace("@6", this._ai.getAsset());
						text = text.Replace("@-2", this._ai.getCase());
						text = text.Replace("@-3", this._ai.getFactor());
						rtfDocument = RtfInterpreterTool.BuildDoc(this._ac.getActionRTF(), new IRtfInterpreterListener[0]);
						rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
						text = text.Replace("@-9", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
						rtfDocument = RtfInterpreterTool.BuildDoc(this._ac.getResultRTF(), new IRtfInterpreterListener[0]);
						rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
						text = text.Replace("1@", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
						rtfDocument = RtfInterpreterTool.BuildDoc(this._ac.getCommentRTF(), new IRtfInterpreterListener[0]);
						rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
						text = text.Replace("2@", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
						text = text.Replace("3@", string.Concat(new string[]
						{
							this._aui.getTeamString(),
							" ",
							this._aui.getNameString(),
							"(",
							this._ai.getDoneTime(),
							")"
						}));
					}
					bool flag10 = this._cReportItem.sReportStauts == "12";
					if (flag10)
					{
						File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content3.html", text);
					}
					else
					{
						bool flag11 = this._cReportItem.sReportStauts == "11";
						if (flag11)
						{
							File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content2.html", text);
						}
						else
						{
							bool flag12 = this._cReportItem.sReportStauts == "13";
							if (flag12)
							{
								rtfDocument = RtfInterpreterTool.BuildDoc(this._fc.getFinalRTF(), new IRtfInterpreterListener[0]);
								rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
								text = text.Replace("4@", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
								text = text.Replace("3@", string.Concat(new string[]
								{
									this._cReportItem.sActionTeam,
									" ",
									this._cReportItem.sActionName,
									"(",
									this._cReportItem.sStartTime,
									")"
								}));
								text = text.Replace("5@", string.Concat(new string[]
								{
									this._fui.getTeamString(),
									" ",
									this._fui.getNameString(),
									"(",
									this._fi.getFinalTimeText(),
									")"
								}));
								File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content4.html", text);
							}
						}
					}
				}
				else
				{
					rtfDocument = RtfInterpreterTool.BuildDoc(this._rbCancelTemp.Rtf, new IRtfInterpreterListener[0]);
					rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					bool flag13 = this._api.getApprovalTime() == string.Empty;
					if (flag13)
					{
						text = text.Replace("@-7", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
						text = text.Replace("@-8", string.Concat(new string[]
						{
							this._cReportItem.sTeam,
							" ",
							this._cReportItem.sName,
							"(",
							this._cReportItem.sRequestTime,
							")"
						}));
						File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content5.html", text);
					}
					else
					{
						text = text.Replace("@-9", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
						rtfDocument = RtfInterpreterTool.BuildDoc(this._apc.getApprovalRTF(), new IRtfInterpreterListener[0]);
						rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
						text = text.Replace("@-7", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
						text = text.Replace("@-8", string.Concat(new string[]
						{
							this._apui.getTeamString(),
							" ",
							this._apui.getNameString(),
							"(",
							this._api.getApprovalTime(),
							")"
						}));
						text = text.Replace("3@", this._aui.getTeamString() + " " + this._aui.getNameString() + DateTime.Now.ToString("(yyyy-MM-dd HH:mm)"));
						File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content6.html", text);
					}
				}
				File.Copy(Environment.CurrentDirectory + "\\RES\\maint\\logo.jpg", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\logo.jpg", true);
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void cb_teamlist3_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000AE50 File Offset: 0x00009050
		private void pbSummit_Click(object sender, EventArgs e)
		{
			this.pbSummit.Image = Resources.submit;
			bool flag = this._aui.checkTeam();
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("input_team"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				bool flag2 = this._aui.getToString().Length == 0;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("input_ToMail"), MessageLanguage.getMessage("messagebox_notification"));
				}
				else
				{
					bool flag3 = this._aui.getCCString().Length == 0;
					if (flag3)
					{
						MessageBox.Show(MessageLanguage.getMessage("input_CCMail"), MessageLanguage.getMessage("messagebox_notification"));
					}
					else
					{
						bool flag4 = this._aui.getNameString().Length == 0;
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("input_name"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							bool flag5 = this._ai.checkAsset();
							if (flag5)
							{
								MessageBox.Show(MessageLanguage.getMessage("input_pm_asset"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								bool flag6 = this._ai.getCaseIndex() == -1;
								if (flag6)
								{
									MessageBox.Show(MessageLanguage.getMessage("select_pm_case"), MessageLanguage.getMessage("messagebox_notification"));
								}
								else
								{
									bool flag7 = this._ai.getFactorIndex() == -1;
									if (flag7)
									{
										MessageBox.Show(MessageLanguage.getMessage("select_factor"), MessageLanguage.getMessage("messagebox_notification"));
									}
									else
									{
										bool flag8 = this._ai.getDifficultyIndex() == -1;
										if (flag8)
										{
											MessageBox.Show(MessageLanguage.getMessage("select_pm_difficult"), MessageLanguage.getMessage("messagebox_notification"));
										}
										else
										{
											bool flag9 = this._ai.checkVendor();
											if (flag9)
											{
												MessageBox.Show(MessageLanguage.getMessage("select_pm_vendor"), MessageLanguage.getMessage("messagebox_notification"));
											}
											else
											{
												bool flag10 = this._ac.isProblemEmpty();
												if (flag10)
												{
													MessageBox.Show(MessageLanguage.getMessage("input_pm_content5"), MessageLanguage.getMessage("messagebox_notification"));
												}
												else
												{
													bool flag11 = this._ac.isResultEmpty();
													if (flag11)
													{
														MessageBox.Show(MessageLanguage.getMessage("input_pm_content6"), MessageLanguage.getMessage("messagebox_notification"));
													}
													else
													{
														DateTime d = Convert.ToDateTime(this._cReportItem.sRequestTime);
														DateTime dateTime = Convert.ToDateTime(this._cReportItem.sApprovalTime);
														DateTime now = DateTime.Now;
														bool flag12 = now.Ticks < this._ai.getStartTime().Ticks;
														if (flag12)
														{
															MessageBox.Show(MessageLanguage.getMessage("compare_starttime").Replace("@1", this._ai.getStartTime().ToString("yyyy-MM-dd HH:mm")).Replace("@2", now.ToString("yyyy-MM-dd HH:mm")), MessageLanguage.getMessage("messagebox_notification"));
														}
														else
														{
															bool flag13 = this._ai.getStartTime() == d || this._ai.getStartTime() == Convert.ToDateTime(this._cReportItem.sApprovalTime);
															if (flag13)
															{
																MessageBox.Show(MessageLanguage.getMessage("check_pm_starttime"), MessageLanguage.getMessage("messagebox_notification"));
															}
															else
															{
																bool flag14 = d.Ticks >= this._ai.getStartTime().Ticks;
																if (flag14)
																{
																	MessageBox.Show(MessageLanguage.getMessage("check_pm_request_starttime"), MessageLanguage.getMessage("messagebox_notification"));
																}
																else
																{
																	bool flag15 = dateTime.Ticks >= this._ai.getStartTime().Ticks;
																	if (flag15)
																	{
																		MessageBox.Show(MessageLanguage.getMessage("check_pm_approval_starttime"), MessageLanguage.getMessage("messagebox_notification"));
																	}
																	else
																	{
																		bool flag16 = new Notification(MessageLanguage.getMessage("notify_parts"), MessageLanguage.getMessage("notify_parts_subtitle"), "YES", "CANCEL", SystemIcons.Warning, false).ShowDialog(this) == DialogResult.No;
																		if (!flag16)
																		{
																			Confirmation confirmation = new Confirmation(this._factorySetting, this._cReportItem);
																			bool flag17 = confirmation.ShowDialog() != DialogResult.OK;
																			if (!flag17)
																			{
																				this._detailList.Clear();
																				this._detailList = confirmation.getDetailCommentList();
																				this._ai.setDoneTime();
																				this._sFileList = string.Empty;
																				for (int i = 0; i < this._ao.getAttachList().Count; i++)
																				{
																					this._sFileList = this._sFileList + this._ao.getAttachList()[i].sFilePath.Trim() + ";";
																				}
																				this._sFileList = this._sFileList.Replace("'", "''");
																				this.saveToHTML(false);
																				this.panel4.Visible = false;
																				this.panel_PDF.Parent = this;
																				this.panel_PDF.Dock = DockStyle.Fill;
																				this.loadMailForm("Send", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content3.html");
																				this.panel_PDF.Visible = true;
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000B38C File Offset: 0x0000958C
		private void pbApprovalCancel_Click(object sender, EventArgs e)
		{
			this.pbApprovalCancel.Image = Resources.cancel;
			CancelForm cancelForm = new CancelForm(true, true);
			bool flag = cancelForm.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this._cReportItem.bRequestCancel = false;
				this._isCancel = true;
				this._rbCancelTemp = new RichTextBox();
				this._rbCancelTemp.Tag = "7";
				this._rbCancelTemp.Visible = false;
				this._rbCancelTemp.Rtf = cancelForm.getContent7().Rtf;
				this.saveToHTML(true);
				this.panel4.Visible = false;
				this.panel_PDF.Parent = this;
				this.panel_PDF.Dock = DockStyle.Fill;
				bool flag2 = this._cReportItem.sReportStauts == "12";
				if (flag2)
				{
					this.loadMailForm("Send", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content6.html");
				}
				else
				{
					this.loadMailForm("Send", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content5.html");
				}
				this.panel_PDF.Visible = true;
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000B494 File Offset: 0x00009694
		private void PMAction_Shown(object sender, EventArgs e)
		{
			bool flag = this._cReportItem.sReportStauts == "98" || this._cReportItem.sReportStauts == "97" || this._cReportItem.sReportStauts == "96";
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("notify_pm_cancel") + " " + this._cReportItem.sContent7, MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				bool flag2 = this._cReportItem.sReportStauts == "12";
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("check_pm_startime_real"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000B55A File Offset: 0x0000975A
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000B568 File Offset: 0x00009768
		private void getUserData(string sUserID)
		{
			bool flag = !string.IsNullOrEmpty(CIMitarLogin._id);
			if (flag)
			{
				sUserID = CIMitarLogin._id;
			}
			string userData_SubFunc = cFunction.getUserData_SubFunc(sUserID);
			bool flag2 = userData_SubFunc.ToUpper().IndexOf("NOT EXIST") == -1;
			if (flag2)
			{
				string[] array = userData_SubFunc.Split(new char[]
				{
					';'
				});
				bool flag3 = array.Length != 0 && array.Length == 3 && this._cReportItem.sReportStauts == "11";
				if (flag3)
				{
					this._cReportItem.sActionName = array[0];
					this._cReportItem.sActionTeam = array[1];
					this._cReportItem.sFromAction = array[2];
				}
				else
				{
					bool flag4 = array.Length != 0 && array.Length == 3 && this._cReportItem.sReportStauts == "12";
					if (flag4)
					{
						this._cReportItem.sPMDoneName = array[0];
						this._cReportItem.sPMDoneTeam = array[1];
						this._cReportItem.sFromAction = array[2];
					}
					else
					{
						bool flag5 = array.Length != 0 && array.Length == 3 && this._cReportItem.sReportStauts == "13";
						if (!flag5)
						{
							MessageBox.Show(MessageLanguage.getMessage("emes_error"), MessageLanguage.getMessage("messagebox_error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
				}
			}
			else
			{
				bool flag6 = this._cReportItem.sReportStauts == "11";
				if (!flag6)
				{
					bool flag7 = this._cReportItem.sReportStauts == "12";
					if (!flag7)
					{
						bool flag8 = this._cReportItem.sReportStauts == "13";
						if (flag8)
						{
						}
					}
				}
			}
		}

		// Token: 0x04000051 RID: 81
		private RequestUserInformation _rui;

		// Token: 0x04000052 RID: 82
		private RequestInformation _ri;

		// Token: 0x04000053 RID: 83
		private ApUserlInformation _apui;

		// Token: 0x04000054 RID: 84
		private PMRequestContent _prc;

		// Token: 0x04000055 RID: 85
		private QueryMgr _queryMgr;

		// Token: 0x04000056 RID: 86
		private cReportItem _cReportItem = null;

		// Token: 0x04000057 RID: 87
		private ApInformation _api;

		// Token: 0x04000058 RID: 88
		private FactorySettings _factorySetting;

		// Token: 0x04000059 RID: 89
		private ApContent _apc;

		// Token: 0x0400005A RID: 90
		private ActionUserInformation _aui;

		// Token: 0x0400005B RID: 91
		private ActionInformation _ai;

		// Token: 0x0400005C RID: 92
		private ActionContent _ac;

		// Token: 0x0400005D RID: 93
		private FinalUserInformation _fui;

		// Token: 0x0400005E RID: 94
		private FinalInformation _fi;

		// Token: 0x0400005F RID: 95
		private FinalContent _fc;

		// Token: 0x04000060 RID: 96
		private ActionAttach _aa;

		// Token: 0x04000061 RID: 97
		private ActionConfirmation _acm;

		// Token: 0x04000062 RID: 98
		private RichTextBox _rbCancelTemp = null;

		// Token: 0x04000063 RID: 99
		private BarPrograss _barPrograss = null;

		// Token: 0x04000064 RID: 100
		private List<string> _PartList = new List<string>();

		// Token: 0x04000065 RID: 101
		private List<string> _PartDescription = new List<string>();

		// Token: 0x04000066 RID: 102
		private List<string> _detailList = new List<string>();

		// Token: 0x04000067 RID: 103
		private long _fileSizeRTF = 0L;

		// Token: 0x04000068 RID: 104
		private long _fileSizeHTML = 0L;

		// Token: 0x04000069 RID: 105
		private readonly long _lMaxReportSize = 1048576L;

		// Token: 0x0400006A RID: 106
		private bool _isAdmin = false;

		// Token: 0x0400006B RID: 107
		private bool _isDebug = false;

		// Token: 0x0400006C RID: 108
		private bool _isCancel = false;

		// Token: 0x0400006D RID: 109
		private string _sFileList = string.Empty;

		// Token: 0x0400006E RID: 110
		private string _sUserId = string.Empty;

		// Token: 0x0400006F RID: 111
		private ActionOther _ao;
	}
}
