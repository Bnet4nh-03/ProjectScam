using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.RTFConverter;
using Amkor.CADModules.Maintenance.RTFConverter.Converter.Html;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;
using Amkor.CADModules.Maintenance.SubForm.MaintActionControl;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using Microsoft.Office.Interop.Word;
using Report_Email;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000C RID: 12
	public partial class cAction : Form, IHCC
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x0001E119 File Offset: 0x0001C319
		public HCC _hCC { get; }

		// Token: 0x060000A8 RID: 168 RVA: 0x0001E121 File Offset: 0x0001C321
		private void pbDelete_MouseLeave(object sender, EventArgs e)
		{
			this.pbDelete.Image = Resources.delete;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0001E134 File Offset: 0x0001C334
		private void pbDelete_MouseEnter(object sender, EventArgs e)
		{
			this.pbDelete.Image = Resources.delete_down;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0001E147 File Offset: 0x0001C347
		private void pbView_MouseLeave(object sender, EventArgs e)
		{
			this.pbView.Image = Resources.view;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0001E15A File Offset: 0x0001C35A
		private void pbView_MouseEnter(object sender, EventArgs e)
		{
			this.pbView.Image = Resources.view_down;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0001E16D File Offset: 0x0001C36D
		private void pbSubmit_MouseLeave(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0001E180 File Offset: 0x0001C380
		private void pbSubmit_MouseEnter(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit_down;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0001E193 File Offset: 0x0001C393
		private void pbHold_MouseLeave(object sender, EventArgs e)
		{
			this.pbHold.Image = Resources.hold;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0001E1A6 File Offset: 0x0001C3A6
		private void pbHold_MouseEnter(object sender, EventArgs e)
		{
			this.pbHold.Image = Resources.hold_down;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0001E1B9 File Offset: 0x0001C3B9
		private void pbClear_MouseEnter(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clearn_down;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0001E1CC File Offset: 0x0001C3CC
		private void pbClear_MouseLeave(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0001E1E0 File Offset: 0x0001C3E0
		public cAction()
		{
			this._ToEmailList.Clear();
			this._CCEmailList.Clear();
			this._queryMgr = null;
			this._sReport = "";
			this.InitializeComponent();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0001E2B4 File Offset: 0x0001C4B4
		public cAction(string sReport, FactorySettings _factorySettings, CIMitarAccount _cimitarUser)
		{
			this._fileSizeRTF = 0L;
			this._fileSizeHTML = 0L;
			this._sReport = sReport;
			this._sUserId = _cimitarUser._id;
			this._cimitarUser = _cimitarUser;
			this._factorySettings = _factorySettings;
			this._hCC = new HCC(_factorySettings, _factorySettings._factoryName, true);
			this._queryMgr = new QueryMgr(_factorySettings);
			this._cReportItem = new cReportItem();
			bool flag = _cimitarUser._userstring1 != null;
			if (flag)
			{
				string text = _cimitarUser._userstring1.ToString();
				bool flag2 = text.IndexOf("CAD_MAINT_ADMIN") != -1;
				if (flag2)
				{
					this._isAdmin = true;
				}
			}
			string[] commandLineArgs = Environment.GetCommandLineArgs();
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
			bool flag8 = Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.files");
			if (flag8)
			{
				Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.files", true);
			}
			this.InitializeComponent();
			this.tpReport.Text = "Report";
			base.Size = new Size(1300, 736);
			this.panel_PDF.Visible = false;
			this.btn_close.Enabled = true;
			this.pbEdite.Tag = "Edit";
			this.InitAllData();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0001E504 File Offset: 0x0001C704
		private void setTimer()
		{
			System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Interval = 500;
			timer.Tick += this.TimerTick;
			timer.Enabled = true;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0001E540 File Offset: 0x0001C740
		private void TimerTick(object sender, EventArgs e)
		{
			System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
			timer.Enabled = false;
			base.Close();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0001E564 File Offset: 0x0001C764
		private bool InitAllData()
		{
			bool reportData = this.GetReportData();
			bool result;
			if (reportData)
			{
				this._aui = new ActionUserInformation(this._factorySettings, this._cimitarUser, this._cReportItem);
				this._aui.Dock = DockStyle.Top;
				this._aui.Parent = this.panel3;
				this._aui.pbActionView.MouseClick += new MouseEventHandler(this.pbActionView_Click);
				this.panel3.Controls.Add(this._aui);
				this.panel3.AutoSize = true;
				this.panel8.AutoSize = true;
				this._ai = new ActionInformation(this._factorySettings, this._cReportItem);
				this._ai.Dock = DockStyle.Fill;
				this.pnActionInformation.Controls.Add(this._ai);
				this._ac = new ActionContent(this._cReportItem);
				this._ac.Dock = DockStyle.Fill;
				this.pnActionContent.Controls.Add(this._ac);
				this._ao = new ActionOther(this._cReportItem);
				this._ao.Dock = DockStyle.Top;
				this.pnPart.Controls.Add(this._ao);
				this.pnPart.AutoSize = true;
				this.tpReport.Text = "Request Report";
				this.DisplayItem();
				this.ControlMode(this._cReportItem.sReportStauts);
				this._ui = new RequestUserInformation(this._cReportItem);
				this.pnUserInformation.Height = this._ui.Height + this._ui.Height / 3;
				this._ui.Visible = true;
				this._ui.Dock = DockStyle.Fill;
				this._ui.Parent = this.pnUserInformation;
				this._ri = new RequestInformation(this._cReportItem, this._hCC);
				this.pnRequestInformation.Height = this._ri.Height + this._ri.Height / 3;
				this._ri.Visible = true;
				this._ri.Dock = DockStyle.Top;
				this._ri.Parent = this.pnRequestInformation;
				bool flag = this._cReportItem.sFactory == "K3" && this._cReportItem.sCategory == this._hCC.Name && this._cReportItem.sModel.ToUpper() != this._hCC.hCCContent.Etc;
				if (flag)
				{
					this.pnBoardInformation.Visible = true;
					this._ah = new ActionHCCStatus(this._factorySettings, this._cReportItem, this._hCC);
					this._ah.Dock = DockStyle.Left;
					this.pnActionHcc.Controls.Add(this._ah);
					bool flag2 = this._cReportItem.sModel == this._hCC.hCCContent.Board;
					if (flag2)
					{
						this._bi = new ActionBoardInformation(this._factorySettings, this._cReportItem, this._ah);
						this.pnBoardInformation.Height = this._bi.Height + this._bi.Height / 3;
						this._bi.Visible = true;
						this._bi.Dock = DockStyle.Fill;
						this._bi.Parent = this.pnBoardInformation;
					}
				}
				else
				{
					this.pnActionHcc.Dispose();
					this.pnBoardInformation.Dispose();
					bool flag3 = this._cReportItem.sModel.ToUpper() == "ETC";
					if (flag3)
					{
						this.pnActionOtehr.Visible = false;
					}
				}
				this._af = new ReportAttachmentFile(this._cReportItem);
				this.pnAttachment.Height = this._af.Height + this._af.Height / 3;
				this.pnAttachment.Visible = true;
				this._af.Visible = true;
				this._af.Dock = DockStyle.Fill;
				this._af.Parent = this.pnAttachment;
				this.pnLeft.AutoSize = true;
				this._rc = new ReportContentcs(this._cReportItem);
				this._rc.Dock = DockStyle.Fill;
				this._rc.Parent = this.pnRight;
				this._rc.Visible = true;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0001EA04 File Offset: 0x0001CC04
		private void pbActionView_Click(object sender, EventArgs e)
		{
			this._aui.pbActionView.Image = Resources.view;
			this.panel4.Visible = false;
			this.panel_PDF.Parent = this;
			this.panel_PDF.Dock = DockStyle.Fill;
			this.loadMailForm(true, "Exit", false);
			this.panel_PDF.Visible = true;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0001EA6C File Offset: 0x0001CC6C
		private void ControlMode(string status)
		{
			bool flag = false;
			bool flag2 = status.CompareTo("1") == 0;
			if (flag2)
			{
				this.tbFromAction.ReadOnly = flag;
				flag = true;
				this.btnHold.Enabled = flag;
				this.pbHold.Visible = flag;
				this.btnSummit.Enabled = flag;
				this.pbSubmit.Visible = flag;
				this.btnClear.Enabled = flag;
				this.pbClear.Visible = flag;
				bool flag3 = this._cReportItem.sId == this._sUserId || this._isAdmin;
				if (flag3)
				{
					this.pnDelete.Visible = true;
				}
				this.pnEdit.Visible = true;
			}
			else
			{
				bool flag4 = status.CompareTo("2") == 0;
				if (flag4)
				{
					flag = true;
					this.tbFromAction.ReadOnly = flag;
					flag = false;
					this.btnHold.Enabled = flag;
					this.pbHold.Visible = flag;
					this.btnClear.Enabled = flag;
					this.pbClear.Visible = flag;
					this.btnSummit.Enabled = flag;
					this.pbSubmit.Visible = flag;
					bool flag5 = this._sUserId == "jisyang01";
					if (flag5)
					{
						this.pnDelete.Visible = true;
					}
					else
					{
						this.pnDelete.Visible = false;
					}
					this.pnEdit.Visible = false;
				}
				else
				{
					bool flag6 = status.CompareTo("3") == 0;
					if (flag6)
					{
						flag = false;
						this.btnHold.Enabled = flag;
						this.pbHold.Visible = flag;
						this.tbFromAction.ReadOnly = flag;
						flag = true;
						this.btnSummit.Enabled = flag;
						this.pbSubmit.Visible = flag;
						this.btnClear.Enabled = flag;
						this.pbClear.Visible = flag;
						bool flag7 = this._cReportItem.sId == this._sUserId || this._isAdmin;
						if (flag7)
						{
							this.pnDelete.Visible = true;
						}
						this.pnEdit.Visible = true;
					}
				}
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0001ECA8 File Offset: 0x0001CEA8
		private void DisplayItem()
		{
			this.tbFrom.Text = this._cReportItem.sSender;
			this.tbFromAction.Text = this._cReportItem.sFromAction;
			this.tbReport.Text = this._cReportItem.sReportName;
			bool flag = this._cReportItem.sReportStauts.CompareTo("2") == 0;
			if (flag)
			{
				ActionConfirmation actionConfirmation = new ActionConfirmation(this._factorySettings, this._cReportItem, this._hCC);
				actionConfirmation.Dock = DockStyle.Fill;
				this.tpConfirmation.Controls.Add(actionConfirmation);
			}
			else
			{
				this.tabControl1.TabPages.Remove(this.tpConfirmation);
			}
			bool flag2 = this._cReportItem.sFactory == "K3" && this._cReportItem.sCategory.Trim().ToUpper() == "HCC";
			if (flag2)
			{
				this.pnPart.Visible = false;
			}
			bool flag3 = this._cReportItem.sId == this._sUserId;
			if (flag3)
			{
				this.pnDelete.Visible = true;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0001EDD8 File Offset: 0x0001CFD8
		private bool GetReportData()
		{
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintReportInfo] @_Report= N'" + this._sReport + "'";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			bool result;
			if (flag)
			{
				bool flag2 = dataSet.Tables[0].Rows.Count == 0;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("report_error"), MessageLanguage.getMessage("messagebox_notification"));
					this.setTimer();
					result = false;
				}
				else
				{
					this._cReportItem.sReportName = this._sReport;
					this._cReportItem.sFactory = dataSet.Tables[0].Rows[0]["Plant"].ToString();
					this._cReportItem.sReportStauts = dataSet.Tables[0].Rows[0]["status"].ToString();
					this._cReportItem.sReportName = dataSet.Tables[0].Rows[0]["ReportName"].ToString();
					this._cReportItem.sCategory = dataSet.Tables[0].Rows[0]["Category"].ToString();
					this._cReportItem.sMachineNo = dataSet.Tables[0].Rows[0]["Machine"].ToString();
					this._cReportItem.sType = dataSet.Tables[0].Rows[0]["Type"].ToString();
					this._cReportItem.sModel = dataSet.Tables[0].Rows[0]["Model"].ToString();
					this._cReportItem.sCase = dataSet.Tables[0].Rows[0]["Case"].ToString();
					this._cReportItem.Comment = dataSet.Tables[0].Rows[0]["Comment"].ToString();
					this._cReportItem.sRequestTime = dataSet.Tables[0].Rows[0]["RequestTime"].ToString().Trim();
					this._cReportItem.sRequestTime = this._cReportItem.sRequestTime.Substring(0, this._cReportItem.sRequestTime.Length - 3);
					this._cReportItem.sProblem = dataSet.Tables[0].Rows[0]["Problem"].ToString();
					this._cReportItem.sAection = dataSet.Tables[0].Rows[0]["Action"].ToString();
					this._cReportItem.sActionName = dataSet.Tables[0].Rows[0]["ActionName"].ToString();
					this._cReportItem.sActionTeam = dataSet.Tables[0].Rows[0]["ActionTeam"].ToString();
					this._cReportItem.sActionCCList = dataSet.Tables[0].Rows[0]["ToListAction"].ToString();
					this._cReportItem.sActionToList = dataSet.Tables[0].Rows[0]["CCListAction"].ToString();
					this._cReportItem.sToEmail = dataSet.Tables[0].Rows[0]["ToListReprot"].ToString();
					this._cReportItem.sCCEmail = dataSet.Tables[0].Rows[0]["CCListReprot"].ToString();
					this._cReportItem.sStartTime = dataSet.Tables[0].Rows[0]["StartTime"].ToString();
					this._cReportItem.sMailForm = dataSet.Tables[0].Rows[0]["mailForm"].ToString();
					this._cReportItem.sMailActionForm = dataSet.Tables[0].Rows[0]["mailActionForm"].ToString();
					this._cReportItem.sHoldName = dataSet.Tables[0].Rows[0]["Holdname"].ToString();
					this._cReportItem.sHoldTeam = dataSet.Tables[0].Rows[0]["Holdteam"].ToString();
					this._cReportItem.sHoldComment = dataSet.Tables[0].Rows[0]["HoldComment"].ToString();
					this._cReportItem.sFactor = dataSet.Tables[0].Rows[0]["Factor"].ToString();
					this._cReportItem.sHoldTime = ((dataSet.Tables[0].Rows[0]["Holdtime"] != null) ? dataSet.Tables[0].Rows[0]["Holdtime"].ToString() : string.Empty);
					this._cReportItem.Attachment = dataSet.Tables[0].Rows[0]["Files"].ToString();
					this._cReportItem.ActionAttachment = dataSet.Tables[0].Rows[0]["ActionFiles"].ToString();
					bool flag3 = dataSet.Tables[0].Columns.Contains("Corrective");
					if (flag3)
					{
						this._cReportItem.sCorrective = dataSet.Tables[0].Rows[0]["Corrective"].ToString();
					}
					bool flag4 = dataSet.Tables[0].Columns.Contains("Part");
					if (flag4)
					{
						this._cReportItem.sPart = dataSet.Tables[0].Rows[0]["Part"].ToString();
					}
					bool flag5 = dataSet.Tables[0].Columns.Contains("PartDescription");
					if (flag5)
					{
						this._cReportItem.sPartDescription = dataSet.Tables[0].Rows[0]["PartDescription"].ToString();
					}
					bool flag6 = dataSet.Tables[0].Columns.Contains("diff");
					if (flag6)
					{
						this._cReportItem.sMaintLevel = dataSet.Tables[0].Rows[0]["diff"].ToString();
					}
					bool flag7 = dataSet.Tables[0].Columns.Contains("Emergency");
					if (flag7)
					{
						this._cReportItem.bEmergency = !(dataSet.Tables[0].Rows[0]["Emergency"].ToString() == "0");
					}
					bool flag8 = dataSet.Tables[0].Columns.Contains("Location");
					if (flag8)
					{
						this._cReportItem.sHCCLocation = dataSet.Tables[0].Rows[0]["Location"].ToString();
					}
					bool flag9 = dataSet.Tables[0].Columns.Contains("HCCType");
					if (flag9)
					{
						this._cReportItem.sHCCType = dataSet.Tables[0].Rows[0]["HCCType"].ToString();
					}
					bool flag10 = dataSet.Tables[0].Columns.Contains("Lotname");
					if (flag10)
					{
						this._cReportItem.sHCCLotName = dataSet.Tables[0].Rows[0]["Lotname"].ToString();
					}
					bool flag11 = dataSet.Tables[0].Columns.Contains("HCCMachine");
					if (flag11)
					{
						this._cReportItem.sHCCMachine = dataSet.Tables[0].Rows[0]["HCCMachine"].ToString();
					}
					bool flag12 = dataSet.Tables[0].Columns.Contains("ProblemSite");
					if (flag12)
					{
						this._cReportItem.sHCCProblemSite = dataSet.Tables[0].Rows[0]["ProblemSite"].ToString();
					}
					bool flag13 = dataSet.Tables[0].Columns.Contains("DetailComment");
					if (flag13)
					{
						this._cReportItem.listDetails = dataSet.Tables[0].Rows[0]["DetailComment"].ToString().Split(new char[]
						{
							'|'
						}).ToList<string>();
					}
					bool flag14 = dataSet.Tables[0].Columns.Contains("EndTime") && dataSet.Tables[0].Rows[0]["EndTime"].ToString().IndexOf("1900") == -1;
					if (flag14)
					{
						this._cReportItem.sEndTime = dataSet.Tables[0].Rows[0]["EndTime"].ToString().Trim();
						this._cReportItem.sEndTime = this._cReportItem.sEndTime.Substring(0, this._cReportItem.sEndTime.Length - 3);
					}
					this._cReportItem.sName = dataSet.Tables[0].Rows[0]["Name"].ToString();
					this._cReportItem.sTeam = dataSet.Tables[0].Rows[0]["Team"].ToString();
					this._cReportItem.sId = dataSet.Tables[0].Rows[0]["id"].ToString();
					cConst.initContents(this._factorySettings, this._cReportItem.sFactory, this._cReportItem.sCategory);
					result = true;
				}
			}
			else
			{
				MessageBox.Show(MessageLanguage.getMessage("action_error"), MessageLanguage.getMessage("messagebox_notification"));
				result = false;
			}
			return result;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0001F980 File Offset: 0x0001DB80
		private bool loadMailForm(bool action, string buttonName, bool edit)
		{
			bool result;
			try
			{
				this.btn_close.Text = buttonName;
				if (edit)
				{
					this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.html");
				}
				else
				{
					bool flag = this.btn_close.Text.ToUpper() == "EXIT";
					if (flag)
					{
						if (action)
						{
							this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\action\\action.html");
						}
						else
						{
							this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML\\report\\report.html");
						}
					}
					else
					{
						this.web_Viewer.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action\\action.html");
					}
				}
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, MessageLanguage.getMessage("messagebox_error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0001FA60 File Offset: 0x0001DC60
		private void btnHold_Click(object sender, EventArgs e)
		{
			bool flag = this.pbEdite.Tag.ToString().CompareTo("Save") == 0;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("save_edit"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				bool flag2 = this._aui.tbTeam2.Text.Trim() == string.Empty;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("input_team"), MessageLanguage.getMessage("messagebox_notification"));
				}
				else
				{
					bool flag3 = this._aui.tbName2.Text.Trim() == string.Empty;
					if (flag3)
					{
						MessageBox.Show(MessageLanguage.getMessage("input_name"), MessageLanguage.getMessage("messagebox_notification"));
					}
					else
					{
						HoldForm holdForm = new HoldForm();
						bool flag4 = holdForm.ShowDialog() != DialogResult.OK;
						if (!flag4)
						{
							string sQuery = string.Concat(new string[]
							{
								"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintDataAction] @_SetType='Hold', @_ReportName= N'",
								this._sReport,
								"', @_Team=N'",
								this._aui.tbTeam2.Text.Trim(),
								"', @_Name=N'",
								this._aui.tbName2.Text.Trim(),
								"', @_HoldComment= N'",
								holdForm.getHoldComment(),
								"'"
							});
							DataSet dataSet = this._queryMgr.queryCall(sQuery);
							bool flag5 = dataSet != null && dataSet.Tables != null;
							if (flag5)
							{
								bool flag6 = dataSet.Tables.Count != 0;
								if (flag6)
								{
									bool flag7 = dataSet.Tables[0].Rows.Count != 0;
									if (flag7)
									{
										bool flag8 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
										if (flag8)
										{
											MessageBox.Show(MessageLanguage.getMessage("hold_save"), MessageLanguage.getMessage("messagebox_notification"));
											base.DialogResult = DialogResult.OK;
											base.Close();
											return;
										}
									}
								}
							}
							MessageBox.Show(MessageLanguage.getMessage("hold_save_fail"), MessageLanguage.getMessage("messagebox_notification"));
							base.DialogResult = DialogResult.Cancel;
							base.Close();
						}
					}
				}
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0001FCC0 File Offset: 0x0001DEC0
		private void btnSummit2_Click(object sender, EventArgs e)
		{
			bool flag = this.pbEdite.Tag.ToString() == "Save";
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("save_edit"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				DateTime dateTime = Convert.ToDateTime(this._cReportItem.sRequestTime);
				bool flag2 = this._ai.dtStartPicker.Value == Convert.ToDateTime(this._cReportItem.sRequestTime);
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("modify_starttime"), MessageLanguage.getMessage("messagebox_notification"));
				}
				else
				{
					bool flag3 = !string.IsNullOrEmpty(this._cReportItem.sHoldTime);
					if (flag3)
					{
						bool flag4 = this._ai.dtStartPicker.Value <= Convert.ToDateTime(this._cReportItem.sHoldTime);
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("hold_time_same"), MessageLanguage.getMessage("messagebox_notification"));
							return;
						}
					}
					bool flag5 = dateTime.Ticks > this._ai.dtStartPicker.Value.Ticks;
					if (flag5)
					{
						MessageBox.Show(MessageLanguage.getMessage("check_starttime"), MessageLanguage.getMessage("messagebox_notification"));
					}
					else
					{
						DateTime now = DateTime.Now;
						bool flag6 = now.Ticks < this._ai.dtStartPicker.Value.Ticks;
						if (flag6)
						{
							MessageBox.Show(MessageLanguage.getMessage("compare_starttime").Replace("@1", this._ai.dtStartPicker.Value.ToString("yyyy-MM-dd HH:mm")).Replace("@2", now.ToString("yyyy-MM-dd HH:mm")), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							bool flag7 = this._cReportItem.sFactory == "K5" && (this._cReportItem.sModel.ToUpper().Trim() == this._hCC.hCCContent.Board || this._cReportItem.sModel.ToUpper().Trim() == this._hCC.hCCContent.Socket);
							if (flag7)
							{
								bool flag8 = this._cReportItem.sMachineNo.Trim()[0] == 'S' || this._cReportItem.sMachineNo.Trim()[0] == 'P';
								if (flag8)
								{
									bool flag9 = !this._ao.isExistAttach();
									if (flag9)
									{
										MessageBox.Show(MessageLanguage.getMessage("check_attachment"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
										return;
									}
								}
							}
							bool flag10 = this._aui.cb_teamlist.Visible && this._aui.cb_teamlist.SelectedIndex == -1;
							if (flag10)
							{
								MessageBox.Show(MessageLanguage.getMessage("input_team"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								bool flag11 = this._aui.tbTeam2.Text.Trim() == string.Empty;
								if (flag11)
								{
									MessageBox.Show(MessageLanguage.getMessage("input_team"), MessageLanguage.getMessage("messagebox_notification"));
								}
								else
								{
									bool flag12 = this._aui.tbName2.Text.Trim() == string.Empty;
									if (flag12)
									{
										MessageBox.Show(MessageLanguage.getMessage("input_name"), MessageLanguage.getMessage("messagebox_notification"));
									}
									else
									{
										bool flag13 = this._ac.getProblemText().Length == 0;
										if (flag13)
										{
											MessageBox.Show(MessageLanguage.getMessage("input_problem"), MessageLanguage.getMessage("messagebox_notification"));
										}
										else
										{
											bool flag14 = this._ac.getActionText().Length == 0;
											if (flag14)
											{
												MessageBox.Show(MessageLanguage.getMessage("input_action"), MessageLanguage.getMessage("messagebox_notification"));
											}
											else
											{
												bool flag15 = this._aui.tbToList2.Text.Trim().Length == 0;
												if (flag15)
												{
													MessageBox.Show(MessageLanguage.getMessage("input_ToMail"), MessageLanguage.getMessage("messagebox_notification"));
												}
												else
												{
													bool flag16 = this._aui.tbCCList2.Text.Trim().Length == 0;
													if (flag16)
													{
														MessageBox.Show(MessageLanguage.getMessage("input_CCMail"), MessageLanguage.getMessage("messagebox_notification"));
													}
													else
													{
														bool flag17 = this._cReportItem.sCategory != "HCC" && this._ai.cbDifficulty.SelectedIndex == -1;
														if (flag17)
														{
															MessageBox.Show(MessageLanguage.getMessage("select_difficult"), MessageLanguage.getMessage("messagebox_notification"));
														}
														else
														{
															bool flag18 = this._ai.cbCase.SelectedIndex == -1;
															if (flag18)
															{
																MessageBox.Show(MessageLanguage.getMessage("select_case"), MessageLanguage.getMessage("messagebox_notification"));
															}
															else
															{
																bool flag19 = this._ai.cbFactor.SelectedIndex == -1;
																if (flag19)
																{
																	bool flag20 = this._cReportItem.sCategory.ToUpper().Trim() != "OTHER";
																	if (flag20)
																	{
																		MessageBox.Show(MessageLanguage.getMessage("select_factor"), MessageLanguage.getMessage("messagebox_notification"));
																	}
																}
																else
																{
																	bool flag21 = ((!(this._cReportItem.sFactory == "K3") && !(this._cReportItem.sFactory == "K3_E")) || !(this._cReportItem.sCategory.ToUpper().Trim() == this._hCC.Name)) && new Notification(MessageLanguage.getMessage("notify_parts"), MessageLanguage.getMessage("notify_parts_subtitle"), "YES", "CANCEL", SystemIcons.Warning, false).ShowDialog(this) == DialogResult.No;
																	if (!flag21)
																	{
																		bool flag22 = (this._cReportItem.sFactory == "K3" || this._cReportItem.sFactory == "K3_E") && this._cReportItem.sCategory.ToUpper().Trim() == this._hCC.Name;
																		if (flag22)
																		{
																			bool flag23 = this._hCC.hCCContent.Etc != this._cReportItem.sModel && this._ah.getHCCStatus() == 0;
																			if (flag23)
																			{
																				MessageBox.Show(MessageLanguage.getMessage("input_hcc_status"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
																				return;
																			}
																		}
																		bool flag24 = (this._cReportItem.sCategory.ToUpper().Trim() != "OTHER" && this._cReportItem.sCategory.ToUpper().Trim() != this._hCC.Name) || this._cReportItem.sFactory != "K5";
																		if (flag24)
																		{
																			Confirmation confirmation = new Confirmation(this._factorySettings, this._cReportItem);
																			bool flag25 = confirmation.ShowDialog() != DialogResult.OK;
																			if (flag25)
																			{
																				return;
																			}
																			this._detailList.Clear();
																			this._detailList = confirmation.getDetailCommentList();
																		}
																		else
																		{
																			bool flag26 = this._cReportItem.sCategory.ToUpper().Trim() == this._hCC.Name;
																			if (flag26)
																			{
																				bool flag27 = this._cReportItem.sModel.ToUpper() == this._hCC.hCCContent.Board || this._cReportItem.sModel.ToUpper() == this._hCC.hCCContent.Socket;
																				if (flag27)
																				{
																					BoardConfirmation boardConfirmation = new BoardConfirmation(this._factorySettings, this._cReportItem);
																					bool flag28 = boardConfirmation.ShowDialog() != DialogResult.OK;
																					if (flag28)
																					{
																						return;
																					}
																					this._detailList.Clear();
																					this._detailList = boardConfirmation.getDetailCommentList();
																				}
																			}
																		}
																		dateTime = DateTime.Now;
																		this._sFileList = string.Empty;
																		this._sPartTemp = string.Empty;
																		string empty = string.Empty;
																		this._ai.tbEndTime.Text = dateTime.ToString("yyyy-MM-dd HH:mm");
																		this._sFileList = this._ao.getAttachStringList();
																		this.saveToHTML();
																		this.panel4.Visible = false;
																		this.panel_PDF.Parent = this;
																		this.panel_PDF.Dock = DockStyle.Fill;
																		this.loadMailForm(true, "Send", false);
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

		// Token: 0x060000BE RID: 190 RVA: 0x000205B0 File Offset: 0x0001E7B0
		private void sendMail(bool editMode)
		{
			CEmailService cemailService = new CEmailService();
			if (editMode)
			{
				bool flag = cemailService.ExcuteEmail(this._factorySettings, false, this.tbReport.Text, "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.files", string.Empty, false, true);
				if (flag)
				{
					MessageBox.Show(MessageLanguage.getMessage("email_modify_complete"), MessageLanguage.getMessage("messagebox_notification"));
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
				bool flag2 = cemailService.ExcuteEmail(this._factorySettings, false, this._sReport.Trim(), "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action\\action.files", string.Empty, true, false);
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("email_action_complete"), MessageLanguage.getMessage("messagebox_notification"));
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
				else
				{
					string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintDataAction] @_SetType='Delete', @_ReportName=N'" + this._sReport.Trim() + "'";
					DataSet dataSet = this._queryMgr.queryCall(sQuery);
					MessageBox.Show(MessageLanguage.getMessage("email_error"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000206DF File Offset: 0x0001E8DF
		private void btnClear_Click(object sender, EventArgs e)
		{
			this._ai.clear(this._cReportItem);
			this._ac.clear();
			this._ao.clear();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0002070C File Offset: 0x0001E90C
		private void btn_Delete_Click(object sender, EventArgs e)
		{
			bool flag = MessageBox.Show(MessageLanguage.getMessage("email_delete"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNo) == DialogResult.Yes;
			if (flag)
			{
				string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintDeleteReport]";
				text = text + " @_ReportName=N'" + this._sReport.Trim() + "'";
				text = text + ", @_User=N'" + this._sUserId.Trim() + "'";
				DataSet dataSet = this._queryMgr.queryCall(text);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows.Count != 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows[0].ToString().CompareTo("NO,EXIST") != 0;
						if (flag4)
						{
							DateTime dateTime = Convert.ToDateTime(this._ai.tbRequestTime.Text.Trim());
							string str = string.Concat(new string[]
							{
								"\\\\v1cifsn1.vn.ds.amkor.com\\tfahcc$Maintenance\\Report\\",
								dateTime.Year.ToString(),
								"\\",
								dateTime.Month.ToString(),
								"\\",
								dateTime.Day.ToString()
							});
							string str2 = this.tbReport.Text.Replace("/", "_").Trim() + ".zip";
							string path = str + "\\" + str2;
							bool flag5 = File.Exists(path);
							if (flag5)
							{
								File.Delete(path);
							}
							base.DialogResult = DialogResult.OK;
							base.Close();
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("email_delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
				}
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000208F8 File Offset: 0x0001EAF8
		private bool updateReport(string ReportName)
		{
			string sQuery = string.Empty;
			sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintDataHistory]  @_InsertType=N'Update', @_Plant=N'",
				this._cReportItem.sFactory,
				"', @_ReportName=N'",
				ReportName,
				"', @_Comment=N'",
				Convert.ToBase64String(this._rc.MakeRFTFileReport(false)),
				"', @_Corrective=N'",
				Convert.ToBase64String(this._rc.MakeRFTFileReport(true)),
				"', @_mailForm=N'",
				Convert.ToBase64String(this._rc.MakeHTMLZipEdit()),
				"', @_id=N'",
				this._sUserId,
				"', @_CheckItemContent=N'",
				this._rc.getCheckItemText(),
				"', @_RequirmentContent=N'",
				this._rc.getRequirementText(),
				"'"
			});
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count != 0;
			if (flag)
			{
				bool flag2 = dataSet.Tables[0].Rows.Count != 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper().CompareTo("OK") == 0;
					if (flag3)
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
			return false;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00020AD4 File Offset: 0x0001ECD4
		private void btn_close_Click(object sender, EventArgs e)
		{
			bool flag = this.btn_close.Text == "Send";
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show(MessageLanguage.getMessage("send_mail"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bool flag3 = !string.IsNullOrEmpty(this._sFileList.Replace(";", string.Empty));
					if (flag3)
					{
						bool flag4 = !cFunction.attachZip(this.tbReport.Text.Trim(), this._ai.tbRequestTime.Text.Trim(), this._cReportItem, this._ao.getAttachList(), true, false);
						if (flag4)
						{
							return;
						}
					}
					string text = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintDataAction] @_SetType='Summit', @_ReportName=N'",
						this._sReport.Trim(),
						"', @_Team=N'",
						this._aui.tbTeam2.Text.Trim(),
						"', @_Name=N'",
						this._aui.tbName2.Text.Trim(),
						"', @_Problem=N'",
						Convert.ToBase64String(this._ac.MakeRFTFile(false)),
						"', @_Part=N'",
						this._ao.getPartString(),
						"', @_PartDescription=N'",
						this._ao.getPartDesString(),
						"', @_Action=N'",
						Convert.ToBase64String(this._ac.MakeRFTFile(true)),
						"', @_StartTime=N'",
						this._ai.dtStartPicker.Text.Trim(),
						"', @_EndTime=N'",
						this._ai.tbEndTime.Text.Trim(),
						"', @_FromEmail=N'",
						this.tbFromAction.Text.Trim(),
						"', @_ToEmail=N'",
						this._aui.tbToList2.Text.Replace(Environment.NewLine, "").Trim(),
						"', @_CCEmail=N'",
						this._aui.tbCCList2.Text.Replace(Environment.NewLine, "").Trim(),
						"', @_Files=N'",
						this._sFileList,
						"', @_Case=N'",
						this._ai.cbCase.SelectedItem.ToString().Trim(),
						"', @_mailForm=N'",
						Convert.ToBase64String(this._ac.MakeHTMLZip()),
						"', @_ProblemContent=N'",
						this._ac.getProblemText(),
						"', @_ActionContent=N'",
						this._ac.getActionText(),
						"'"
					});
					bool flag5 = this._cReportItem.sCategory.Trim() != this._hCC.Name;
					if (flag5)
					{
						text = text + ", @_Diff=N'" + this._ai.cbDifficulty.SelectedItem.ToString().Trim() + "'";
					}
					else
					{
						bool flag6 = (this._cReportItem.sFactory == "K3" || this._cReportItem.sFactory == "K3_E") && this._cReportItem.sCategory.Trim() == this._hCC.Name && this._cReportItem.sModel.Trim() != this._hCC.hCCContent.Etc;
						if (flag6)
						{
							text = string.Concat(new object[]
							{
								text,
								", @_HCCStatus=N'",
								this._ah.getHCCStatus(),
								"'"
							});
						}
					}
					bool flag7 = this._ai.cbFactor.SelectedIndex == -1;
					if (flag7)
					{
						text += ", @_Factor=N''";
					}
					else
					{
						text = text + ", @_Factor=N'" + this._ai.cbFactor.SelectedItem.ToString().Trim() + "'";
					}
					bool flag8 = this._detailList.Count != 0;
					if (flag8)
					{
						text += ", @_DetailComment=N'";
						for (int i = 0; i < this._detailList.Count; i++)
						{
							text = text + this._detailList[i].Replace("'", "''") + "|";
						}
						text = text.Remove(text.Length - 1);
						text += "'";
					}
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag9 = dataSet != null;
					if (flag9)
					{
						bool flag10 = dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "OK";
						if (flag10)
						{
							this._cReportItem.sStartTime = this._ai.dtStartPicker.Text;
							this._ai.downTimeAutoCalc();
							this.sendMail(false);
						}
						else
						{
							bool flag11 = dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0;
							if (flag11)
							{
								MessageBox.Show(MessageLanguage.getMessage("upload_error"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("upload_error2"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					bool flag12 = dialogResult == DialogResult.No;
					if (flag12)
					{
						this.panel4.Visible = true;
						this.panel_PDF.Visible = false;
					}
				}
			}
			else
			{
				bool flag13 = this.btn_close.Text == "Send(Edit)";
				if (flag13)
				{
					DialogResult dialogResult2 = MessageBox.Show(MessageLanguage.getMessage("send_mail_modify"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					bool flag14 = dialogResult2 == DialogResult.Yes;
					if (flag14)
					{
						this.updateReport(this.tbReport.Text.Trim());
					}
					else
					{
						bool flag15 = dialogResult2 == DialogResult.No;
						if (flag15)
						{
							this.panel4.Visible = true;
							this.panel_PDF.Visible = false;
						}
					}
				}
				else
				{
					this.panel4.Visible = true;
					this.panel_PDF.Visible = false;
				}
			}
			this._fileSizeHTML = 0L;
			this._fileSizeRTF = 0L;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000211F0 File Offset: 0x0001F3F0
		private bool saveToHTML()
		{
			bool result;
			try
			{
				FileInfo fileInfo = new FileInfo(cConst.actionDocPath);
				object fullName = fileInfo.FullName;
				object value = Missing.Value;
				Microsoft.Office.Interop.Word.Application application = (Microsoft.Office.Interop.Word.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
				Document document = (Document)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00020906-0000-0000-C000-000000000046")));
				bool flag = Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action");
				if (flag)
				{
					Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action", true);
				}
				Thread.Sleep(100);
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action");
				string text = string.Empty;
				bool flag2 = this._cReportItem.sCategory.Trim() == "HCC" && (this._cReportItem.sFactory == "K3" || this._cReportItem.sFactory == "K3_E");
				if (flag2)
				{
					text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\HCCaction.html");
					bool flag3 = string.IsNullOrEmpty(text);
					if (flag3)
					{
						return false;
					}
					HCCParameter hccparameter = null;
					bool flag4 = !cFunction.getHCCInfo(this._factorySettings, this._cReportItem.sFactory, this._cReportItem.sModel.Trim(), this._cReportItem.sMachineNo.Trim(), out hccparameter);
					if (flag4)
					{
						return false;
					}
					text = text.Replace("HCC BOARD REPORT", "HCC " + this._cReportItem.sModel.Trim() + " REPORT");
					text = text.Replace("@1", this._cReportItem.sRequestTime);
					text = text.Replace("@2", this._cReportItem.sTeam.Trim());
					text = text.Replace("@3", this._cReportItem.sMachineNo.Trim());
					text = text.Replace("@4", hccparameter.nickname);
					text = text.Replace("@5", this._cReportItem.sName.Trim());
					text = text.Replace("@6", hccparameter.boardid);
					text = text.Replace("@7", hccparameter.site);
					text = text.Replace("@8", hccparameter.handlerType);
					text = text.Replace("@9", hccparameter.pkgType);
					text = text.Replace("@-1", hccparameter.boardType);
					IRtfDocument rtfDocument = RtfInterpreterTool.BuildDoc(this._rc.getCheckItemRTF(), new IRtfInterpreterListener[0]);
					RtfHtmlConverter rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					text = text.Replace("@-2", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.report));
					rtfDocument = RtfInterpreterTool.BuildDoc(this._rc.getRequirementRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					text = text.Replace("@-3", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.report));
					text = text.Replace("@-4", this._cReportItem.sHCCMachine.Trim());
					text = text.Replace("@-5", this._cReportItem.sHCCLotName.Trim());
					bool flag5 = this._cReportItem.sModel.Trim() == this._hCC.hCCContent.Board;
					if (flag5)
					{
						bool flag6 = this._hCC.hCCParameter.siteRow == 0 || this._hCC.hCCParameter.siteCol == 0;
						if (flag6)
						{
							text = text.Replace("@-6", string.Empty);
						}
						else
						{
							string text2 = this._hCC.siteMap.convertHTMLSitemap(this._hCC.hCCParameter, true, this._cReportItem.sReportName);
							bool flag7 = string.IsNullOrEmpty(text2.Trim());
							if (flag7)
							{
								MessageBox.Show(MessageLanguage.getMessage("board_regist"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return false;
							}
							text = text.Replace("@-6", text2);
						}
					}
					else
					{
						int num = text.IndexOf("<tr style='height:21.25pt' id='extraboard'>");
						int num2 = text.IndexOf("</tr>", num);
						text = text.Remove(num, num2 - num);
						num = text.IndexOf("<div class=WordSection2>");
						num2 = text.IndexOf("</div>", num);
						text = text.Remove(num, num2 - num);
						bool flag8 = this._cReportItem.sModel.Trim() == this._hCC.hCCContent.Etc;
						if (flag8)
						{
							num = text.IndexOf("<tr style='height:21.25pt' id='information'>");
							num2 = text.IndexOf(" <tr style='height:21.25pt' id='comment'>", num) - 1;
							text = text.Remove(num, num2 - num);
						}
					}
					text = text.Replace("@-7", this._ai.dtStartPicker.Value.ToString("yyyy-MM-dd HH:mm"));
					text = text.Replace("@-8", this._ai.tbEndTime.Text);
					text = text.Replace("@-9", this._aui.tbTeam2.Text);
					text = text.Replace("!1", this._aui.tbName2.Text);
					bool flag9 = this._ah != null;
					if (flag9)
					{
						string newValue = string.Format("Good : {0} | Reject : {1} | Disable : {2}", this._hCC.siteMap._iGood, this._hCC.siteMap._iReject, this._hCC.siteMap._iDisable);
						text = text.Replace("!2", newValue);
					}
					else
					{
						text = text.Replace("!2", "");
					}
					rtfDocument = RtfInterpreterTool.BuildDoc(this._ac.getProblemRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					text = text.Replace("!3", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.action));
					rtfDocument = RtfInterpreterTool.BuildDoc(this._ac.getActionRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					text = text.Replace("!4", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.action));
				}
				else
				{
					text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\action.html");
					bool flag10 = string.IsNullOrEmpty(text);
					if (flag10)
					{
						return false;
					}
					bool flag11 = this._cReportItem.sCategory.Trim() == "HCC" && text.IndexOf("Machine") != -1;
					if (flag11)
					{
						text = text.Replace("Machine", "Location");
					}
					bool flag12 = this._cReportItem.sCategory.Trim() == "HCC" && text.IndexOf("Rsc Dec") != -1;
					if (flag12)
					{
						text = text.Replace("Rsc Dec", "Nick Name");
					}
					bool flag13 = this._cReportItem.sCategory.Trim() != "HCC";
					if (flag13)
					{
						text = text.Replace("Board No.", "");
						bool bEmergency = this._cReportItem.bEmergency;
						if (bEmergency)
						{
							text = text.Replace("Board No.", "Urgency");
							text = text.Replace("@7", "Emergency");
						}
					}
					bool flag14 = text.IndexOf("Maintenance Difficulty") != -1;
					if (flag14)
					{
						text = text.Replace("Maintenance Difficulty", "Case");
					}
					text = text.Replace("@1", this.tbReport.Text);
					text = text.Replace("@2", this._cReportItem.sTeam.Trim());
					text = text.Replace("@3", this._cReportItem.sMachineNo.Trim());
					text = text.Replace("@4", this._cReportItem.sModel.Trim());
					text = text.Replace("@5", this._cReportItem.sName.Trim());
					bool flag15 = this._cReportItem.sCategory.Trim() == this._hCC.Name;
					if (flag15)
					{
						bool flag16 = this._cReportItem.sModel.Trim() == this._hCC.hCCContent.Board;
						if (flag16)
						{
							HCCParameter hccparameter2 = null;
							bool hccinfo = cFunction.getHCCInfo(this._factorySettings, this._cReportItem.sFactory, this._cReportItem.sModel.Trim(), this._cReportItem.sMachineNo.Trim(), out hccparameter2);
							if (hccinfo)
							{
								bool flag17 = string.IsNullOrEmpty(hccparameter2.nickname.Trim()) && !string.IsNullOrEmpty(hccparameter2.device);
								if (flag17)
								{
									text = text.Replace("Nick Name", "Device");
									text = text.Replace("@6", hccparameter2.device);
								}
								else
								{
									text = text.Replace("@6", hccparameter2.nickname);
								}
							}
							else
							{
								text = text.Replace("@6", string.Empty);
							}
							text = text.Replace("@7", this._cReportItem.sType.Trim());
						}
						else
						{
							text = text.Replace("@6", this._cReportItem.sType.Trim());
							text = text.Replace("@7", string.Empty);
						}
					}
					else
					{
						text = text.Replace("@6", this._cReportItem.sType.Trim());
						text = text.Replace("@7", this.tbCase.Text);
					}
					IRtfDocument rtfDocument2 = RtfInterpreterTool.BuildDoc(this._rc.getCheckItemRTF(), new IRtfInterpreterListener[0]);
					RtfHtmlConverter rtfHtmlConverter2 = new RtfHtmlConverter(rtfDocument2);
					text = text.Replace("@8", rtfHtmlConverter2.Convert(cConst.Upload.HTMLtype.action));
					rtfDocument2 = RtfInterpreterTool.BuildDoc(this._rc.getRequirementRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter2 = new RtfHtmlConverter(rtfDocument2);
					text = text.Replace("@9", rtfHtmlConverter2.Convert(cConst.Upload.HTMLtype.action));
					text = text.Replace("@-10", this._ai.tbEndTime.Text);
					bool flag18 = this._ai.cbFactor.SelectedIndex == -1;
					if (flag18)
					{
						text = text.Replace("@-11", this._ai.cbCase.SelectedItem.ToString());
					}
					else
					{
						text = text.Replace("@-11", string.Concat(new string[]
						{
							this._ai.cbCase.SelectedItem.ToString(),
							Environment.NewLine,
							"(",
							this._ai.cbFactor.SelectedItem.ToString(),
							")"
						}));
					}
					text = text.Replace("@-12", this._aui.tbTeam2.Text);
					text = text.Replace("@-13", this._aui.tbName2.Text);
					rtfDocument2 = RtfInterpreterTool.BuildDoc(this._ac.getProblemRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter2 = new RtfHtmlConverter(rtfDocument2);
					text = text.Replace("@-14", rtfHtmlConverter2.Convert(cConst.Upload.HTMLtype.action));
					rtfDocument2 = RtfInterpreterTool.BuildDoc(this._ac.getActionRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter2 = new RtfHtmlConverter(rtfDocument2);
					text = text.Replace("@-15", rtfHtmlConverter2.Convert(cConst.Upload.HTMLtype.action));
					List<string> partList = this._ao.getPartList();
					List<string> partDesList = this._ao.getPartDesList();
					bool flag19 = partList.Count != 0;
					if (flag19)
					{
						int num3 = text.IndexOf("CHANGE PARTS");
						num3 = text.IndexOf("<tr style='height:17.15pt'>", num3);
						int num4 = text.IndexOf("</tr>", num3);
						string value2 = text.Substring(num3, num4 - num3);
						string[] array = partList[0].Split(new char[]
						{
							'|'
						});
						bool flag20 = array.Length > 1;
						if (flag20)
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
						num4 = text.IndexOf("</tr>", num3);
						for (int i = partList.Count - 1; i > 0; i--)
						{
							array = partList[i].Split(new char[]
							{
								'|'
							});
							bool flag21 = array.Length > 1;
							if (flag21)
							{
								text = text.Insert(num4 - 1, value2);
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
				}
				File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\action\\action.html", text);
				result = true;
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "saveToHTML", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\ActionForm.cs", 1409);
				result = false;
			}
			return result;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00022034 File Offset: 0x00020234
		private bool saveToHTMLbyEditor()
		{
			bool result;
			try
			{
				Clipboard.Clear();
				FileInfo fileInfo = new FileInfo(cConst.docPath);
				object fullName = fileInfo.FullName;
				object value = Missing.Value;
				Microsoft.Office.Interop.Word.Application application = (Microsoft.Office.Interop.Word.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
				Document document = (Document)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00020906-0000-0000-C000-000000000046")));
				bool flag = File.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.html");
				if (flag)
				{
					File.Delete("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.html");
					bool flag2 = Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.files");
					if (flag2)
					{
						Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.files", true);
					}
				}
				Thread.Sleep(100);
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report");
				string text = string.Empty;
				bool flag3 = this._cReportItem.sCategory.Trim() == "HCC" && (this._cReportItem.sFactory == "K3" || this._cReportItem.sFactory == "K3_E");
				if (flag3)
				{
					text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\HCCreport.html");
					bool flag4 = string.IsNullOrEmpty(text);
					if (flag4)
					{
						return false;
					}
					bool flag5 = this._cReportItem.sModel.Trim() != "BOARD";
					if (flag5)
					{
						int num = text.LastIndexOf("<div class=WordSection1>");
						int num2 = text.LastIndexOf("</div>");
						text = text.Remove(num, num2 - num);
					}
					text = text.Replace("HCC BOARD REPORT", "HCC " + this._cReportItem.sModel.Trim() + " REPORT");
					text = text.Replace("@1", this.tbReport.Text);
					text = text.Replace("@2", this._cReportItem.sTeam.Trim());
					text = text.Replace("@3", this._cReportItem.sMachineNo.Trim());
					text = text.Replace("@4", this._cReportItem.sHCCNickname);
					text = text.Replace("@5", this._cReportItem.sName.Trim());
					text = text.Replace("@6", this._cReportItem.sType);
					text = text.Replace("@7", this._cReportItem.sHCCSite);
					text = text.Replace("@8", this._cReportItem.sHCCHandlerType);
					text = text.Replace("@9", this._cReportItem.sHCCPKGType);
					text = text.Replace("@-1", this._cReportItem.sHCCType);
					IRtfDocument rtfDocument = RtfInterpreterTool.BuildDoc(this._rc.getCheckItemRTF(), new IRtfInterpreterListener[0]);
					RtfHtmlConverter rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					text = text.Replace("@-2", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.report));
					rtfDocument = RtfInterpreterTool.BuildDoc(this._rc.getRequirementRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					text = text.Replace("@-3", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.report));
					text = text.Replace("@-4", this._cReportItem.sHCCMachine.Trim());
					text = text.Replace("@-5", this._cReportItem.sHCCLotName.Trim());
					bool flag6 = this._cReportItem.sModel.Trim() != this._hCC.hCCContent.Board;
					if (flag6)
					{
						text = text.Replace("@-6", string.Empty);
					}
					else
					{
						bool flag7 = this._cReportItem.sModel.Trim() == this._hCC.hCCContent.Board;
						if (flag7)
						{
							HCCParameter hccparameter = null;
							bool hccinfo = cFunction.getHCCInfo(this._factorySettings, this._cReportItem.sFactory, this._cReportItem.sModel.Trim(), this._cReportItem.sMachineNo.Trim(), out hccparameter);
							if (hccinfo)
							{
								bool flag8 = string.IsNullOrEmpty(hccparameter.nickname.Trim()) && !string.IsNullOrEmpty(hccparameter.device);
								if (flag8)
								{
									text = text.Replace("Nick Name", "Device");
									text = text.Replace("@6", hccparameter.device);
								}
								else
								{
									text = text.Replace("@6", hccparameter.nickname);
								}
							}
							else
							{
								text = text.Replace("@6", string.Empty);
							}
							text = text.Replace("@7", this._cReportItem.sType.Trim());
							bool flag9 = this._cReportItem.sModel.Trim() == this._hCC.hCCContent.Board;
							if (flag9)
							{
								bool flag10 = this._hCC.hCCParameter.siteRow == 0 || this._hCC.hCCParameter.siteCol == 0;
								if (flag10)
								{
									text = text.Replace("@-6", string.Empty);
								}
								else
								{
									string text2 = this._hCC.siteMap.convertHTMLSitemap(this._hCC.hCCParameter, true, this._cReportItem.sReportName);
									bool flag11 = string.IsNullOrEmpty(text2.Trim());
									if (flag11)
									{
										MessageBox.Show(MessageLanguage.getMessage("board_regist"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
										return false;
									}
									text = text.Replace("@-6", text2);
								}
							}
							else
							{
								int num3 = text.LastIndexOf("<tr style='height:21.25pt' id='extraboard'>");
								int num4 = text.LastIndexOf("</tr>");
								text = text.Remove(num3, num4 - num3);
								num3 = text.LastIndexOf("<div class=WordSection2>");
								num4 = text.LastIndexOf("</div>");
								text = text.Remove(num3, num4 - num3);
							}
							bool flag12 = this._ah != null;
							if (flag12)
							{
								string newValue = string.Format("Good : {0} | Reject : {1} | Disable : {2}", this._hCC.siteMap._iGood, this._hCC.siteMap._iReject, this._hCC.siteMap._iDisable);
								text = text.Replace("!2", newValue);
							}
							else
							{
								text = text.Replace("!2", "");
							}
						}
						else
						{
							text = text.Replace("@6", this._cReportItem.sType.Trim());
							text = text.Replace("@7", string.Empty);
						}
					}
				}
				else
				{
					text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\report.html");
					bool flag13 = string.IsNullOrEmpty(text);
					if (flag13)
					{
						return false;
					}
					text = text.Replace("Case", string.Empty);
					text = text.Replace("@1", this.tbReport.Text);
					text = text.Replace("@2", this._cReportItem.sTeam.Trim());
					bool flag14 = this._cReportItem.sCategory.Trim() == this._hCC.Name;
					if (flag14)
					{
						text = text.Replace("Machine", "HCC Location");
						text = text.Replace("Rsc Dec", "Nick Name");
						text = text.Replace("Case", "Board No");
						text = text.Replace("@3", this._cReportItem.sMachineNo.Trim());
					}
					else
					{
						text = text.Replace("@3", this._cReportItem.sMachineNo.Trim());
					}
					text = text.Replace("@4", this._cReportItem.sModel.Trim());
					text = text.Replace("@5", this._cReportItem.sName.Trim());
					text = text.Replace("@6", this._cReportItem.sType.Trim());
					bool flag15 = this._cReportItem.sCategory.Trim() != this._hCC.Name;
					if (flag15)
					{
						text = text.Replace("@7", this.tbCase.Text);
					}
					else
					{
						text = text.Replace("@7", string.Empty);
					}
					IRtfDocument rtfDocument2 = RtfInterpreterTool.BuildDoc(this._rc.getCheckItemRTF(), new IRtfInterpreterListener[0]);
					RtfHtmlConverter rtfHtmlConverter2 = new RtfHtmlConverter(rtfDocument2);
					text = text.Replace("@8", rtfHtmlConverter2.Convert(cConst.Upload.HTMLtype.report));
					rtfDocument2 = RtfInterpreterTool.BuildDoc(this._rc.getRequirementRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter2 = new RtfHtmlConverter(rtfDocument2);
					text = text.Replace("@9", rtfHtmlConverter2.Convert(cConst.Upload.HTMLtype.report));
				}
				File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.html", text);
				result = true;
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "saveToHTMLbyEditor", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\ActionForm.cs", 1615);
				result = false;
			}
			return result;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00022988 File Offset: 0x00020B88
		private void btn_ActionViewer_Click(object sender, EventArgs e)
		{
			this.panel4.Visible = false;
			this.panel_PDF.Parent = this;
			this.panel_PDF.Dock = DockStyle.Fill;
			this.loadMailForm(true, "Exit", false);
			this.panel_PDF.Visible = true;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000229D8 File Offset: 0x00020BD8
		private void cAction_Shown(object sender, EventArgs e)
		{
			bool flag = this._cReportItem.sReportStauts == "3";
			if (flag)
			{
				HoldInfoForm holdInfoForm = new HoldInfoForm(this._cReportItem.sHoldTeam, this._cReportItem.sHoldName, this._cReportItem.sHoldTime, this._cReportItem.sHoldComment);
				holdInfoForm.ShowDialog();
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00022A3C File Offset: 0x00020C3C
		private void pbEdite_Click(object sender, EventArgs e)
		{
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
						return;
					}
					CIMitarLogin._id = login.id;
					this._aui.getUserData(login.id);
					login.Dispose();
				}
				this.pbEdite.Image = Resources.save;
				this.pbEdite.Tag = (this.lbEdite.Text = "Save");
				bool flag4 = this._cReportItem.sFactory == "K3" && this._cReportItem.sCategory == this._hCC.Name && this._cReportItem.sModel == this._hCC.hCCContent.Board;
				if (flag4)
				{
					this.gbBoardSiteMap.Visible = true;
				}
				this._rc.EditMode();
			}
			else
			{
				DialogResult dialogResult = MessageBox.Show(MessageLanguage.getMessage("modify_save"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
				bool flag5 = dialogResult == DialogResult.Yes || dialogResult == DialogResult.No;
				if (flag5)
				{
					this.pbEdite.Image = Resources.edit;
					this.pbEdite.Tag = (this.lbEdite.Text = "Edit");
					this.gbBoardSiteMap.Visible = false;
					this._rc.SaveMode();
					bool flag6 = dialogResult == DialogResult.Yes;
					if (flag6)
					{
						bool flag7 = this.saveToHTMLbyEditor();
						if (flag7)
						{
							this.panel4.Visible = false;
							this.panel_PDF.Parent = this;
							this.panel_PDF.Dock = DockStyle.Fill;
							this.loadMailForm(false, "Send(Edit)", true);
							this.panel_PDF.Visible = true;
						}
					}
					else
					{
						this._rc.SaveContent(this._cReportItem);
					}
				}
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00022C6C File Offset: 0x00020E6C
		private void pbView_Click(object sender, EventArgs e)
		{
			this.pbView.Image = Resources.view_down;
			this.panel_PDF.Parent = this;
			this.panel_PDF.Dock = DockStyle.Fill;
			this.loadMailForm(false, "Exit", false);
			this.panel_PDF.Visible = true;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00022CC0 File Offset: 0x00020EC0
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

		// Token: 0x060000CA RID: 202 RVA: 0x00022D14 File Offset: 0x00020F14
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

		// Token: 0x060000CB RID: 203 RVA: 0x00022D67 File Offset: 0x00020F67
		private void pbDelete_Click(object sender, EventArgs e)
		{
			this.pbDelete.Image = Resources.delete;
			this.btn_Delete_Click(null, null);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00022D84 File Offset: 0x00020F84
		private void pbSubmit_Click(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit;
			this.btnSummit2_Click(null, null);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00022DA1 File Offset: 0x00020FA1
		private void pbHold_Click(object sender, EventArgs e)
		{
			this.pbHold.Image = Resources.hold;
			this.btnHold_Click(null, null);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00022DBE File Offset: 0x00020FBE
		private void pbClear_Click(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
			this.btnClear_Click(null, null);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00022DDC File Offset: 0x00020FDC
		private void cAction_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				string path = "C:\\Temp\\CimitarAdmin\\Maint\\download\\" + this.tbReport.Text.Trim() + ".zip";
				bool flag = File.Exists(path);
				if (flag)
				{
					File.Delete(path);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00022E34 File Offset: 0x00021034
		private void tbHWDisableSite_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsDigit(e.KeyChar) && e.KeyChar != ',';
			if (flag)
			{
				e.Handled = true;
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00022E6C File Offset: 0x0002106C
		private void tbHCCDisableSite_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsDigit(e.KeyChar);
			if (flag)
			{
				e.Handled = true;
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00022E94 File Offset: 0x00021094
		private void pbBoardInforamtion_MouseLeave(object sender, EventArgs e)
		{
			this.pbBoardInforamtion.Image = Resources.board;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00022EA7 File Offset: 0x000210A7
		private void pbBoardInforamtion_MouseEnter(object sender, EventArgs e)
		{
			this.pbBoardInforamtion.Image = Resources.board_down;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00022EBC File Offset: 0x000210BC
		private void pbBoardInforamtion_Click(object sender, EventArgs e)
		{
			this.pbBoardInforamtion.Image = Resources.board;
			bool flag = this.pbEdite.Tag.ToString().CompareTo("Save") == 0;
			if (flag)
			{
				new SiteMapForm(this._factorySettings, this._cReportItem, this._hCC, true).ShowDialog();
			}
		}

		// Token: 0x0400017F RID: 383
		private RequestUserInformation _ui;

		// Token: 0x04000180 RID: 384
		private RequestInformation _ri;

		// Token: 0x04000181 RID: 385
		private ActionBoardInformation _bi;

		// Token: 0x04000182 RID: 386
		private ReportAttachmentFile _af;

		// Token: 0x04000183 RID: 387
		private ReportContentcs _rc;

		// Token: 0x04000184 RID: 388
		private ActionUserInformation _aui;

		// Token: 0x04000185 RID: 389
		private ActionInformation _ai;

		// Token: 0x04000186 RID: 390
		private ActionContent _ac;

		// Token: 0x04000187 RID: 391
		private ActionOther _ao;

		// Token: 0x04000188 RID: 392
		private ActionHCCStatus _ah;

		// Token: 0x0400018A RID: 394
		private string _sReport;

		// Token: 0x0400018B RID: 395
		private string _sUserId = string.Empty;

		// Token: 0x0400018C RID: 396
		private string _sFileList = string.Empty;

		// Token: 0x0400018D RID: 397
		private string _sPartTemp = string.Empty;

		// Token: 0x0400018E RID: 398
		private string _sPartDesTemp = string.Empty;

		// Token: 0x0400018F RID: 399
		private long _fileSizeRTF = 0L;

		// Token: 0x04000190 RID: 400
		private long _fileSizeHTML = 0L;

		// Token: 0x04000191 RID: 401
		private readonly long _lMaxReportSize = 1048576L;

		// Token: 0x04000192 RID: 402
		private bool _isAdmin = false;

		// Token: 0x04000193 RID: 403
		private FactorySettings _factorySettings;

		// Token: 0x04000194 RID: 404
		private QueryMgr _queryMgr;

		// Token: 0x04000195 RID: 405
		private cReportItem _cReportItem;

		// Token: 0x04000196 RID: 406
		private List<cEmailInfo> _ToEmailList = new List<cEmailInfo>();

		// Token: 0x04000197 RID: 407
		private List<cEmailInfo> _CCEmailList = new List<cEmailInfo>();

		// Token: 0x04000198 RID: 408
		private List<string> _detailList = new List<string>();

		// Token: 0x04000199 RID: 409
		private Dictionary<string, string> _FactorList = new Dictionary<string, string>();

		// Token: 0x0400019A RID: 410
		private Dictionary<string, string> _DeptMailList = new Dictionary<string, string>();

		// Token: 0x0400019B RID: 411
		private CIMitarAccount _cimitarUser;
	}
}
