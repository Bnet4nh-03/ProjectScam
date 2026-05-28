using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
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
using Amkor.CADModules.Maintenance.SubForm.ReportSubControl;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using Report_Email;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x02000009 RID: 9
	public partial class Report : BaseWinView, IHCC
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000530B File Offset: 0x0000350B
		public HCC _hCC { get; }

		// Token: 0x0600002E RID: 46 RVA: 0x00005313 File Offset: 0x00003513
		private void pbClear_MouseEnter(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clearn_down;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00005326 File Offset: 0x00003526
		private void pbClear_MouseLeave(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00005339 File Offset: 0x00003539
		private void pbSubmit_MouseEnter(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit_down;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000534C File Offset: 0x0000354C
		private void pbSubmit_MouseLeave(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000535F File Offset: 0x0000355F
		private void btnClear_Click(object sender, EventArgs e)
		{
			this.clear();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000535F File Offset: 0x0000355F
		private void Report_Shown(object sender, EventArgs e)
		{
			this.clear();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00005368 File Offset: 0x00003568
		public Report(string sUserID, FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this._sUserID = sUserID;
			this._fileSizeHTML = 0L;
			this._fileSizeRTF = 0L;
			bool flag = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content");
			if (flag)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content");
			}
			bool flag2 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML");
			if (flag2)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML");
			}
			bool flag3 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
			if (flag3)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\download\\content");
			}
			bool flag4 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML");
			if (flag4)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\download\\HTML");
			}
			bool flag5 = !Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content");
			if (flag5)
			{
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\content");
			}
			this.queryMgr = new QueryMgr(this._factorySetting);
			this._hCC = new HCC(this._factorySetting, this._factorySetting._factoryName, true);
			this.InitializeComponent();
			base.Tag = MainPageType.Maintenance;
			this.btn_Close.Text = "Exit";
			this.panel_Preview.Visible = false;
			this._ri = new ReportInformation(this._factorySetting, this._hCC);
			this._ri.Dock = DockStyle.Fill;
			this.pnUserInformation.Controls.Add(this._rui);
			this._rui = new ReportUserInformation(this._factorySetting);
			this._rui.Dock = DockStyle.Fill;
			this.pnUserInformation.Controls.Add(this._rui);
			this._hi = new HCCInformation(this.queryMgr, this._hCC);
			this._hi.Dock = DockStyle.Top;
			this.pnHccInformation.Controls.Add(this._hi);
			this.pnHccInformation.AutoSize = true;
			this.pnHccInformation.Visible = false;
			this._rbi = new ReportBoardInformation(this._factorySetting, this._hCC, this.reportItem);
			this._rbi.Dock = DockStyle.Top;
			this.pnBoardInformation.Controls.Add(this._rbi);
			this._ri = new ReportInformation(this._factorySetting, this._hCC);
			this._ri.Dock = DockStyle.Top;
			this.pnReportInformation.Controls.Add(this._ri);
			this.pnReportInformation.AutoSize = true;
			this._rc = new ReportContent();
			this._rc.Dock = DockStyle.Fill;
			this.pnReportContent.Controls.Add(this._rc);
			this._ra = new ReportAttach();
			this._ra.Dock = DockStyle.Fill;
			this.pnReportAttach.Controls.Add(this._ra);
			this._ri._rbi = this._rbi;
			this._ri._hi = this._hi;
			this._ri._rui = this._rui;
			this._rui._ri = this._ri;
			this._hi._rbi = this._rbi;
			this._hi._ri = this._ri;
			this._rbi._hi = this._hi;
			this._rbi._ri = this._ri;
			this.Login();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00005724 File Offset: 0x00003924
		private void cbFont_DrawItem(object sender, DrawItemEventArgs e)
		{
			bool flag = (e.State & DrawItemState.Focus) == DrawItemState.None;
			if (flag)
			{
				ComboBox comboBox = (ComboBox)sender;
				string familyName = comboBox.Items[e.Index].ToString();
				Font font = new Font(familyName, comboBox.Font.SizeInPoints);
				e.DrawBackground();
				e.Graphics.DrawString(font.Name, font, Brushes.Black, (float)e.Bounds.X, (float)e.Bounds.Y);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000057B4 File Offset: 0x000039B4
		private bool sendEmail()
		{
			bool flag = !string.IsNullOrEmpty(this._hi.getLocation());
			if (flag)
			{
				this._ri.setHcctoMachine(this._hi.getLocation());
			}
			bool flag2 = !string.IsNullOrEmpty(this._sFileList.Replace(";", string.Empty));
			if (flag2)
			{
				this.reportItem.sFactory = this._ri.getFactory();
				bool flag3 = !cFunction.attachZip(this._ri.getReport(), this._ri.getRequestTime(), this.reportItem, this._ra.getFileList(), false, false);
				if (flag3)
				{
					return false;
				}
			}
			string text = string.Concat(new object[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintDataHistory]  @_InsertType=N'Report', @_status=1, @_ReportName=N'",
				this._ri.getReport(),
				"', @_Team=N'",
				this._rui.getTeam(),
				"', @_Name=N'",
				this._rui.getName(),
				"', @_Category=N'",
				this._ri.getCategory(),
				"', @_Machine=N'",
				this._ri.getMachine(),
				"', @_Model=N'",
				this._ri.getModel(),
				"', @_Comment=N'",
				Convert.ToBase64String(this._rc.MakeRFTFile(false)),
				"', @_RequestTime=N'",
				this._ri.getRequestTime(),
				"', @_FromMail=N'",
				this._rui.fromMail(),
				"', @_ToMailList=N'",
				this._rui.getToMail().Replace(Environment.NewLine, "").Trim(),
				"', @_CCMailList=N'",
				this._rui.getCCMail().Replace(Environment.NewLine, "").Trim(),
				"', @_FileList=N'",
				this._sFileList.Trim(),
				"', @_Corrective=N'",
				Convert.ToBase64String(this._rc.MakeRFTFile(true)),
				"', @_id=N'",
				this._sUserID.Trim(),
				"', @_mailForm=N'",
				Convert.ToBase64String(this._rc.MakeHTMLZip()),
				"', @_CheckItemContent=N'",
				this._rc.getCheckItemText(),
				"', @_RequirmentContent=N'",
				this._rc.getRequirmentText().Replace("'", "''"),
				"', @_Plant=N'",
				this._ri.getFactory(),
				"', @_HCCType=N'",
				this._hi.getBoardType(),
				"', @_HCCId=N'",
				this._ri.getHCCId(),
				"', @_HCCLocation=N'",
				this._hi.getLocation(),
				"', @_HCCMachine=N'",
				this._rbi.getMachine(),
				"', @_HCCLot=N'",
				this._rbi.getLot(),
				"', @_HCCBoard=N'",
				this._hi.getBoardNo(),
				"', @_HCCNickname=N'",
				this._hi.getNickname(),
				"', @_HCCHandlertype=N'",
				this._hi.getHandlerType(),
				"', @_HCCPKGtype=N'",
				this._hi.getPkgType(),
				"', @_HCCSite=N'",
				this._hi.getSiteCount().ToString(),
				"', @_Emergency=",
				this._ri.isEmergency()
			});
			bool flag4 = string.IsNullOrEmpty(this._hi.getLocation());
			if (flag4)
			{
				text = text + ", @_Rsc=N'" + this._ri.getRscDec() + "'";
			}
			else
			{
				text = text + ", @_Rsc=N'" + this._hi.getBoardNo() + "'";
			}
			DataSet dataSet = this.queryMgr.queryCall(text);
			bool flag5 = dataSet != null;
			if (flag5)
			{
				bool flag6 = dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows.Count > 0;
				if (flag6)
				{
					bool flag7 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
					if (flag7)
					{
						CEmailService cemailService = new CEmailService();
						bool flag8 = cemailService.ExcuteEmail(this._factorySetting, this.cbOutLook.Checked, this._ri.getReport(), "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.files", string.Empty, false, false);
						if (flag8)
						{
							MessageBox.Show(MessageLanguage.getMessage("request_complete"), MessageLanguage.getMessage("messagebox_notification"));
							return true;
						}
						text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintDeleteReport]";
						text = text + " @_ReportName=N'" + this._ri.getReport() + "'";
						text += ", @_User=N''";
						dataSet = this.queryMgr.queryCall(text);
						MessageBox.Show(MessageLanguage.getMessage("email_error"), MessageLanguage.getMessage("messagebox_notification"));
					}
					else
					{
						MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString().ToUpper(), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("upload_error"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
			else
			{
				MessageBox.Show(MessageLanguage.getMessage("upload_error2"), MessageLanguage.getMessage("messagebox_notification"));
			}
			return false;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00005D8C File Offset: 0x00003F8C
		public void clear()
		{
			this._rui.clear();
			this._ri.clear();
			this._ra.clear();
			this._rc.clear();
			this._ra.clear();
			this._rbi.clear();
			this._rbi.Visible = false;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005DF0 File Offset: 0x00003FF0
		private bool saveToHTML()
		{
			try
			{
				FileInfo fileInfo = new FileInfo(cConst.docPath);
				object fullName = fileInfo.FullName;
				object value = Missing.Value;
				bool flag = Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report");
				if (flag)
				{
					Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report", true);
				}
				Thread.Sleep(100);
				Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report");
				string text = string.Empty;
				bool flag2 = this._ri.getCategory() == this._hCC.Name && (this._ri.getFactory() == "K3" || this._ri.getFactory() == "K3_E");
				if (flag2)
				{
					text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\HCCreport.html");
					bool flag3 = string.IsNullOrEmpty(text);
					if (flag3)
					{
						return false;
					}
					text = text.Replace("HCC BOARD REPORT", "HCC " + this._ri.getContent() + " REPORT");
					text = text.Replace("@1", this._ri.getRequestTime());
					text = text.Replace("@2", this._rui.getTeam());
					text = text.Replace("@3", this._hCC.hCCParameter.location);
					text = text.Replace("@4", this._hCC.hCCParameter.nickname);
					text = text.Replace("@5", this._rui.getName());
					text = text.Replace("@6", this._hCC.hCCParameter.boardid);
					text = text.Replace("@7", this._hCC.hCCParameter.site);
					text = text.Replace("@8", this._hCC.hCCParameter.handlerType);
					text = text.Replace("@9", this._hCC.hCCParameter.pkgType);
					text = text.Replace("@-1", this._hCC.hCCParameter.boardType);
					IRtfDocument rtfDocument = RtfInterpreterTool.BuildDoc(this._rc.getCheckItemRTF(), new IRtfInterpreterListener[0]);
					RtfHtmlConverter rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					text = text.Replace("@-2", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.report));
					rtfDocument = RtfInterpreterTool.BuildDoc(this._rc.getRequirmentRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
					text = text.Replace("@-3", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.report));
					text = text.Replace("@-4", this._rbi.getMachine());
					text = text.Replace("@-5", this._rbi.getLot());
					bool flag4 = this._ri.getContent() != this._hCC.hCCContent.Board;
					if (flag4)
					{
						int num = text.IndexOf("<tr style='height:21.25pt' id='extraboard'>");
						int num2 = text.IndexOf("</tr>", num);
						text = text.Remove(num, num2 - num);
						num = text.IndexOf("<div class=WordSection2>");
						num2 = text.IndexOf("</div>", num);
						text = text.Remove(num, num2 - num);
					}
					bool flag5 = this._ri.getContent() != this._hCC.hCCContent.Board || this._hCC.hCCParameter.siteRow == 0 || this._hCC.hCCParameter.siteCol == 0;
					if (flag5)
					{
						text = text.Replace("@-6", string.Empty);
						bool flag6 = this._ri.getContent() == this._hCC.hCCContent.Etc;
						if (flag6)
						{
							int num3 = text.IndexOf("<tr style='height:21.25pt' id='information'>");
							int num4 = text.IndexOf(" <tr style='height:21.25pt' id='comment'>", num3) - 1;
							text = text.Remove(num3, num4 - num3);
						}
					}
					else
					{
						string text2 = this._hCC.siteMap.convertHTMLSitemap(this._hCC.hCCParameter, true, this._ri.getReport());
						bool flag7 = string.IsNullOrEmpty(text2.Trim());
						if (flag7)
						{
							MessageBox.Show(MessageLanguage.getMessage("board_regist"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return false;
						}
						text = text.Replace("@-6", text2);
						text = text.Replace("!2", string.Format("Good : {0} | Reject : {1} | Disable : {2}", this._hCC.siteMap._iGood, this._hCC.siteMap._iReject, this._hCC.siteMap._iDisable));
					}
				}
				else
				{
					text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\report.html");
					bool flag8 = string.IsNullOrEmpty(text);
					if (flag8)
					{
						return false;
					}
					text = text.Replace("@1", this._ri.getRequestTime());
					text = text.Replace("@2", this._rui.getTeam());
					bool flag9 = !string.IsNullOrEmpty(this._hi.getLocation());
					if (flag9)
					{
						bool flag10 = this._hi.existNickName() == "NICKNAME";
						if (flag10)
						{
							text = text.Replace("Rsc Dec", "Nick Name");
						}
						else
						{
							text = text.Replace("Rsc Dec", "Device");
						}
						text = text.Replace("Machine", "HCC Location");
						text = text.Replace("Case", "Board No");
						text = text.Replace("@3", this._hCC.hCCParameter.location);
					}
					else
					{
						text = text.Replace("@3", this._ri.getMachine());
					}
					text = text.Replace("@4", this._ri.getModel());
					text = text.Replace("@5", this._rui.getName());
					bool flag11 = !string.IsNullOrEmpty(this._hCC.hCCParameter.location);
					if (flag11)
					{
						text = text.Replace("@6", this._hCC.hCCParameter.nickname);
					}
					else
					{
						text = text.Replace("@6", this._ri.getRscDec());
					}
					bool flag12 = !string.IsNullOrEmpty(this._hi.getLocation());
					if (flag12)
					{
						text = text.Replace("@7", this._hCC.hCCParameter.boardid);
					}
					else
					{
						bool flag13 = this._ri.isEmergency() == 1;
						if (flag13)
						{
							text = text.Replace("Case", "Urgency");
							text = text.Replace("@7", "Emergency");
						}
						else
						{
							text = text.Replace("Case", string.Empty);
							text = text.Replace("@7", string.Empty);
						}
					}
					IRtfDocument rtfDocument2 = RtfInterpreterTool.BuildDoc(this._rc.getCheckItemRTF(), new IRtfInterpreterListener[0]);
					RtfHtmlConverter rtfHtmlConverter2 = new RtfHtmlConverter(rtfDocument2);
					text = text.Replace("@8", rtfHtmlConverter2.Convert(cConst.Upload.HTMLtype.report));
					rtfDocument2 = RtfInterpreterTool.BuildDoc(this._rc.getRequirmentRTF(), new IRtfInterpreterListener[0]);
					rtfHtmlConverter2 = new RtfHtmlConverter(rtfDocument2);
					text = text.Replace("@9", rtfHtmlConverter2.Convert(cConst.Upload.HTMLtype.report));
				}
				File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.html", text);
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "saveToHTML", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\Report.cs", 453);
				return false;
			}
			return true;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000065EC File Offset: 0x000047EC
		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show(MessageLanguage.getMessage("send_mail"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				this.panel_Preview.Visible = false;
				this.btn_Close.Text = "Exit";
				bool flag2 = this.sendEmail();
				if (flag2)
				{
					bool flag3 = this._ri.getCategory() == this._hCC.Name && this._ri.getContent() != "ETC";
					if (flag3)
					{
						bool flag4 = !cFunction.setMaintHCCStatus(this._factorySetting, this._ri.getContent(), this._hCC.hCCParameter.location, this._rbi.checkGood(), this._ri.getFactory());
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("send_mail_hw_error"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					this.clear();
				}
			}
			else
			{
				bool flag5 = dialogResult == DialogResult.No;
				if (flag5)
				{
					this.panel_Preview.Visible = false;
				}
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00006710 File Offset: 0x00004910
		public string Login()
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			bool flag = commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG";
			if (flag)
			{
				this._sUserID = "jisyang01";
			}
			bool flag2 = !string.IsNullOrEmpty(CIMitarLogin._id);
			string userData;
			if (flag2)
			{
				userData = this._rui.getUserData(CIMitarLogin._id);
			}
			else
			{
				userData = this._rui.getUserData(this._sUserID);
			}
			return userData;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00006789 File Offset: 0x00004989
		private void pbClear_Click(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
			this.clear();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000067A4 File Offset: 0x000049A4
		private void pbSubmit_Click(object sender, EventArgs e)
		{
			this.pbSubmit.Image = Resources.submit;
			bool flag = this._ri.getCategoryIndex() == -1;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("select_cateogry"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				bool flag2 = !this._rui.checkTeam();
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_team"), MessageLanguage.getMessage("messagebox_notification"));
				}
				else
				{
					bool flag3 = this._ri.getCategory() == "OTHER" || this._ri.getCategory() == this._hCC.Name;
					if (flag3)
					{
						bool flag4 = this._ri.getContentIndex() == -1;
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("select_other_content"), MessageLanguage.getMessage("messagebox_notification"));
							return;
						}
						bool flag5 = this._ri.getCategory() == this._hCC.Name;
						if (flag5)
						{
							bool flag6 = this._ri.getFactory() == "K3" && this._ri.getContent() != "Etc";
							if (flag6)
							{
								bool flag7 = string.IsNullOrEmpty(this._hi.getLocation().Trim());
								if (flag7)
								{
									MessageBox.Show(MessageLanguage.getMessage("input_location"), MessageLanguage.getMessage("messagebox_notification"));
									return;
								}
								bool flag8 = this._ri.getContent() == this._hCC.hCCContent.Board && string.IsNullOrEmpty(this._hCC.hCCParameter.boardType.Trim());
								if (flag8)
								{
									MessageBox.Show(MessageLanguage.getMessage("input_board_type"), MessageLanguage.getMessage("messagebox_notification"));
									return;
								}
								bool flag9 = this._ri.getContent() == this._hCC.hCCContent.Board && string.IsNullOrEmpty(this._hCC.hCCParameter.boardid.Trim());
								if (flag9)
								{
									MessageBox.Show(MessageLanguage.getMessage("input_board_no"), MessageLanguage.getMessage("messagebox_notification"));
									return;
								}
								bool flag10 = this._ri.getContent() != this._hCC.hCCContent.Etc && this._ri.getContent() != this._hCC.hCCContent.Board && string.IsNullOrEmpty(this._hCC.hCCParameter.boardType.Trim());
								if (flag10)
								{
									MessageBox.Show(MessageLanguage.getMessage("input_hardware_type"), MessageLanguage.getMessage("messagebox_notification"));
									return;
								}
								bool flag11 = this._ri.getFactory() == "K3" && this._ri.getContent() == this._hCC.hCCContent.Board && string.IsNullOrEmpty(this._rbi.getLot().Trim());
								if (flag11)
								{
									bool flag12 = MessageBox.Show(MessageLanguage.getMessage("input_hcc_lot"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
									if (flag12)
									{
										return;
									}
								}
								bool flag13 = this._rbi.checkStatus();
								if (flag13)
								{
									MessageBox.Show(MessageLanguage.getMessage("input_hcc_status"), MessageLanguage.getMessage("messagebox_notification"));
									return;
								}
							}
						}
						this._ri.setContenttoMachine();
					}
					bool flag14 = string.IsNullOrEmpty(this._rc.getCheckItemText());
					if (flag14)
					{
						MessageBox.Show(MessageLanguage.getMessage("input_checkitem"), MessageLanguage.getMessage("messagebox_notification"));
					}
					else
					{
						bool flag15 = string.IsNullOrEmpty(this._ri.getMachine());
						if (flag15)
						{
							MessageBox.Show(MessageLanguage.getMessage("input_machine_no"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							bool flag16 = string.IsNullOrEmpty(this._rc.getRequirmentText());
							if (flag16)
							{
								MessageBox.Show(MessageLanguage.getMessage("input_requirment"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								bool flag17 = string.IsNullOrEmpty(this._ri.getModel());
								if (flag17)
								{
									MessageBox.Show(MessageLanguage.getMessage("input_model"), MessageLanguage.getMessage("messagebox_notification"));
								}
								else
								{
									bool flag18 = string.IsNullOrEmpty(this._rui.getToMail());
									if (flag18)
									{
										MessageBox.Show(MessageLanguage.getMessage("input_ToMail"), MessageLanguage.getMessage("messagebox_notification"));
									}
									else
									{
										bool flag19 = string.IsNullOrEmpty(this._rui.getCCMail());
										if (flag19)
										{
											MessageBox.Show(MessageLanguage.getMessage("input_CCMail"), MessageLanguage.getMessage("messagebox_notification"));
										}
										else
										{
											bool flag20 = string.IsNullOrEmpty(this._rui.getName());
											if (flag20)
											{
												MessageBox.Show(MessageLanguage.getMessage("input_name"), MessageLanguage.getMessage("messagebox_notification"));
											}
											else
											{
												string str = string.Empty;
												str = this._ri.setReport();
												string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintListCount]";
												text = text + " @date=N'" + str + "'";
												DataSet dataSet = this.queryMgr.queryCall(text);
												bool flag21 = dataSet != null && dataSet.Tables.Count > 0;
												if (flag21)
												{
													int num = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ListCount"].ToString());
													bool flag22 = num == 0;
													if (flag22)
													{
														MessageBox.Show(MessageLanguage.getMessage("report_no_error"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
													}
													else
													{
														this._ri.setReportFormat(num);
														this._sFileList = string.Empty;
														for (int i = 0; i < this._ra.getFileList().Count; i++)
														{
															this._sFileList = this._sFileList + this._ra.getFileList()[i].sFilePath.Trim() + ";";
														}
														this._sFileList = this._sFileList.Replace("'", "''");
														bool flag23 = this.saveToHTML();
														if (flag23)
														{
															this.panel_Preview.BringToFront();
															this.panel_Preview.Dock = DockStyle.Fill;
															this.panel_Preview.Visible = true;
															this.btn_Close.Text = "Send";
															this.webBrowser1.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\report\\report.html");
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

		// Token: 0x0400003E RID: 62
		private QueryMgr queryMgr;

		// Token: 0x0400003F RID: 63
		private string _sUserID;

		// Token: 0x04000045 RID: 69
		private string _sFileList = string.Empty;

		// Token: 0x04000046 RID: 70
		private long _fileSizeHTML = 0L;

		// Token: 0x04000047 RID: 71
		private long _fileSizeRTF = 0L;

		// Token: 0x04000048 RID: 72
		private cReportItem reportItem = new cReportItem();

		// Token: 0x04000049 RID: 73
		private ReportUserInformation _rui;

		// Token: 0x0400004A RID: 74
		private ReportInformation _ri;

		// Token: 0x0400004B RID: 75
		private HCCInformation _hi;

		// Token: 0x0400004C RID: 76
		private ReportBoardInformation _rbi;

		// Token: 0x0400004D RID: 77
		private ReportContent _rc;

		// Token: 0x0400004E RID: 78
		private ReportAttach _ra;

		// Token: 0x0400004F RID: 79
		private const long _lMaxReportSize = 10485760L;
	}
}
