using System;
using System.Collections.Generic;
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
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.RTFConverter;
using Amkor.CADModules.Maintenance.RTFConverter.Converter.Html;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;
using Amkor.CADModules.Maintenance.SubForm.PMRequestSubControl;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using Report_Email;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000D RID: 13
	public partial class PMRequest : BaseWinView
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x000258D4 File Offset: 0x00023AD4
		public PMRequest(FactorySettings factorySetting, CIMitarAccount _cimitarUser)
		{
			this._factorySetting = factorySetting;
			this._queryMgr = new QueryMgr(this._factorySetting);
			this._sUserId = _cimitarUser._id;
			this._fileSizeRTF = 0L;
			this._cReportItem = new cReportItem();
			this.InitializeComponent();
			base.Tag = MainPageType.PreventMaintenance;
			this._pui = new PMUserInformation(this._cReportItem, this._factorySetting);
			this._pui.Dock = DockStyle.Fill;
			this.pnUserInformation.Controls.Add(this._pui);
			this._pi = new PMInformation(this._factorySetting, this._pui);
			this._pi.Dock = DockStyle.Top;
			this.pnPMInformation.Controls.Add(this._pi);
			this._pc = new PMContent();
			this._pc.Dock = DockStyle.Fill;
			this.pnContent.Controls.Add(this._pc);
			this._pa = new PMAttach();
			this._pa.Dock = DockStyle.Fill;
			this._pui.setPMInformation(this._pi);
			this.Login();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00025A68 File Offset: 0x00023C68
		private void pbPM_Click(object sender, EventArgs e)
		{
			this.pbPM.Image = Resources.pm;
			bool flag = this._pi.isCategoryNull();
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("select_cateogry"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				bool flag2 = this._pui.checkTeam();
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("input_team"), MessageLanguage.getMessage("messagebox_notification"));
				}
				else
				{
					bool flag3 = this._pi.checkPlanDate();
					if (flag3)
					{
						MessageBox.Show(MessageLanguage.getMessage("check_pm_palndate"), MessageLanguage.getMessage("messagebox_notification"));
					}
					else
					{
						bool flag4 = string.IsNullOrEmpty(this._pi.getMachine());
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("input_machine_no"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							bool flag5 = string.IsNullOrEmpty(this._pi.getModel());
							if (flag5)
							{
								MessageBox.Show(MessageLanguage.getMessage("input_model"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								bool flag6 = string.IsNullOrEmpty(this._pui.getToMail());
								if (flag6)
								{
									MessageBox.Show(MessageLanguage.getMessage("input_ToMail"), MessageLanguage.getMessage("messagebox_notification"));
								}
								else
								{
									bool flag7 = string.IsNullOrEmpty(this._pui.getCCMail());
									if (flag7)
									{
										MessageBox.Show(MessageLanguage.getMessage("input_CCMail"), MessageLanguage.getMessage("messagebox_notification"));
									}
									else
									{
										bool flag8 = string.IsNullOrEmpty(this._pui.getName());
										if (flag8)
										{
											MessageBox.Show(MessageLanguage.getMessage("input_name"), MessageLanguage.getMessage("messagebox_notification"));
										}
										else
										{
											bool flag9 = this._pc.isEmptyContent1();
											if (flag9)
											{
												MessageBox.Show(MessageLanguage.getMessage("input_pm_content1"), MessageLanguage.getMessage("messagebox_notification"));
											}
											else
											{
												bool flag10 = this._pc.isEmptyContent8();
												if (flag10)
												{
													MessageBox.Show(MessageLanguage.getMessage("input_pm_content2"), MessageLanguage.getMessage("messagebox_notification"));
												}
												else
												{
													bool flag11 = string.IsNullOrEmpty(this._pi.getEstimatedTime());
													if (flag11)
													{
														MessageBox.Show(MessageLanguage.getMessage("input_pm_estimate"), MessageLanguage.getMessage("messagebox_notification"));
													}
													else
													{
														bool flag12 = this._pi.isWorkTypeNULL();
														if (flag12)
														{
															MessageBox.Show(MessageLanguage.getMessage("input_pm_worktype"), MessageLanguage.getMessage("messagebox_notification"));
														}
														else
														{
															DateTime now = DateTime.Now;
															string text = string.Empty;
															text = this._pi.getFactory() + "_" + now.ToString("yyyyMMdd");
															string sQuery = string.Concat(new string[]
															{
																"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintListCount] @date=N'",
																text,
																"', @WorkType=N'",
																this._pi.getWorkType(),
																"', @PM=N'YES'"
															});
															DataSet dataSet = this._queryMgr.queryCall(sQuery);
															bool flag13 = dataSet != null && dataSet.Tables.Count > 0;
															if (flag13)
															{
																int num = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ListCount"].ToString());
																bool flag14 = num == 0;
																if (flag14)
																{
																	MessageBox.Show(MessageLanguage.getMessage("report_no_error"), MessageLanguage.getMessage("messagebox_error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
																}
																else
																{
																	text = string.Concat(new string[]
																	{
																		text,
																		"_",
																		this._pi.getMachine(),
																		"_",
																		this._pi.getModel(),
																		"_",
																		this._pui.getTeam(),
																		"_",
																		this._pi.getWorkType(),
																		"_",
																		string.Format("{0:D3}", num)
																	});
																	this.tbPMReport.Text = text;
																	Clipboard.Clear();
																	this.saveToHTML();
																	this.panel_Preview.Dock = DockStyle.Fill;
																	this.panel_Preview.Visible = true;
																	this.btn_Close.Text = "Send";
																	this.webBrowser1.Url = new Uri("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content1.html");
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

		// Token: 0x060000D9 RID: 217 RVA: 0x00025EBD File Offset: 0x000240BD
		private void pbClear_Click(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
			this.subItemClear();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00025ED8 File Offset: 0x000240D8
		private void pbClear_MouseLeave(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clear;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00025EEC File Offset: 0x000240EC
		private void pbClear_MouseEnter(object sender, EventArgs e)
		{
			this.pbClear.Image = Resources.clearn_down;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00025F00 File Offset: 0x00024100
		private void pbPM_MouseLeave(object sender, EventArgs e)
		{
			this.pbPM.Image = Resources.pm;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00025F14 File Offset: 0x00024114
		private void pbPM_MouseEnter(object sender, EventArgs e)
		{
			this.pbPM.Image = Resources.pm_down;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00025F28 File Offset: 0x00024128
		private void saveToHTML()
		{
			FileInfo fileInfo = new FileInfo(cConst.docPath);
			object fullName = fileInfo.FullName;
			object value = Missing.Value;
			this._RequestTime = DateTime.Now;
			bool flag = Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm");
			if (flag)
			{
				Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm", true);
			}
			Thread.Sleep(100);
			Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm");
			string text = File.ReadAllText(Environment.CurrentDirectory + "\\RES\\maint\\pm_content1.html");
			text = text.Replace("VENDOR SERVICE REPORT", this._pi.getWorkType() + " REPORT");
			text = text.Replace("7@", "■");
			text = text.Replace("@1", this._RequestTime.ToString("yyyy-MM-dd HH:mm"));
			text = text.Replace("@2", this._pi.getCategory());
			text = text.Replace("@3", this._pi.getMachine());
			bool flag2 = this._pi.getCategory().ToUpper() == "HCC";
			if (flag2)
			{
				text = text.Replace("M/C#", "Location");
			}
			text = text.Replace("@4", this._pi.getModel());
			text = text.Replace("@5", this._pi.getRscDec());
			text = text.Replace("@7", this._pi.getWorkType());
			text = text.Replace("@8", this._pi.getPlanDate());
			text = text.Replace("@9", this._pi.getEstimatedTime() + "(H)");
			IRtfDocument rtfDocument = RtfInterpreterTool.BuildDoc(this._pc.getContent1RTF(), new IRtfInterpreterListener[0]);
			RtfHtmlConverter rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
			text = text.Replace("@-4", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
			rtfDocument = RtfInterpreterTool.BuildDoc(this._pc.getContent8RTF(), new IRtfInterpreterListener[0]);
			rtfHtmlConverter = new RtfHtmlConverter(rtfDocument);
			text = text.Replace("@-5", rtfHtmlConverter.Convert(cConst.Upload.HTMLtype.pm));
			text = text.Replace("@-6", string.Concat(new string[]
			{
				this._pui.getTeam(),
				" ",
				this._pui.getName(),
				"(",
				this._RequestTime.ToString("yyyy-MM-dd HH:mm"),
				")"
			}));
			File.WriteAllText("C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm_content1.html", text);
			File.Copy(Environment.CurrentDirectory + "\\RES\\maint\\logo.jpg", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\logo.jpg", true);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000261B8 File Offset: 0x000243B8
		private void btn_Close_Click(object sender, EventArgs e)
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
					this.subItemClear();
				}
			}
			else
			{
				bool flag3 = dialogResult == DialogResult.No;
				if (flag3)
				{
					this.panel_Preview.Visible = false;
				}
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00026238 File Offset: 0x00024438
		private bool sendEmail()
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintPMHistory] @_command=N'insert', @_id=N'",
				this._sUserId.Trim(),
				"', @_status=11, @_PMReport=N'",
				this.tbPMReport.Text.Trim(),
				"', @_Team=N'",
				this._pui.getTeam(),
				"', @_Name=N'",
				this._pui.getName(),
				"', @_Asset=N'",
				this._pi.getAsset(),
				"', @_WorkType=N'",
				this._pi.getWorkType(),
				"', @_Category=N'",
				this._pi.getCategory(),
				"', @_Machine=N'",
				this._pi.getMachine(),
				"', @_Model=N'",
				this._pi.getModel(),
				"', @_RequestTime=N'",
				this._RequestTime.ToString("yyyy-MM-dd HH:mm"),
				"', @_FromMail=N'",
				this._pui.fromMail(),
				"', @_ToMailList=N'",
				this._pui.getToMail().Replace(Environment.NewLine, "").Trim(),
				"', @_CCMailList=N'",
				this._pui.getCCMail().Replace(Environment.NewLine, "").Trim(),
				"', @_Binary1=N'",
				Convert.ToBase64String(this._pc.MakeRFTFile(false)),
				"', @_mailForm=N'",
				Convert.ToBase64String(this._pc.MakeHTMLZip()),
				"', @_Content1=N'",
				this._pc.getContent1Text().Replace("'", "''"),
				"', @_Factory=N'",
				this._pi.getFactory(),
				"', @_Rsc=N'",
				this._pi.getRscDec(),
				"', @_PMStatus=N'",
				this._pi.checkPMDown().ToString(),
				"', @_PlanedDate=N'",
				this._pi.getPlanDate(),
				"', @_EstimatedTime=N'",
				this._pi.getEstimatedTime(),
				"', @_Content8=N'",
				this._pc.getContent8Text().Replace("'", "''"),
				"', @_Binary8=N'",
				Convert.ToBase64String(this._pc.MakeRFTFile(true)),
				"'"
			});
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null;
			if (flag)
			{
				bool flag2 = dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows.Count > 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
					if (flag3)
					{
						CEmailService cemailService = new CEmailService();
						bool flag4 = cemailService.ExcutePMEmail(this._factorySetting, this.tbPMReport.Text, "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm\\pm.files", "C:\\Temp\\CimitarAdmin\\Maint\\Upload\\HTML\\pm", false, false, false);
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("email_pm_complete"), MessageLanguage.getMessage("messagebox_notification"));
							return true;
						}
						sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintPMDeleteReport] @_PMReport=N'" + this.tbPMReport.Text + "', @_User=N''";
						dataSet = this._queryMgr.queryCall(sQuery);
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

		// Token: 0x060000E1 RID: 225 RVA: 0x00026688 File Offset: 0x00024888
		private void subItemClear()
		{
			this._pui.clear();
			this._pi.clear();
			this._pa.clear();
			this._pc.clear();
			this.tbPMReport.Text = string.Empty;
			this._ToEmailList.Clear();
			this._CCEmailList.Clear();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000266F0 File Offset: 0x000248F0
		public void Login()
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			bool flag = commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG";
			if (flag)
			{
				this._sUserId = "jisyang01";
			}
			bool flag2 = !string.IsNullOrEmpty(CIMitarLogin._id);
			if (flag2)
			{
				bool flag3 = !cFunction.getUserData(this._cReportItem, CIMitarLogin._id);
				if (flag3)
				{
					this._pui.manualLogin();
				}
				else
				{
					this._pui.setLogin(this._cReportItem);
				}
			}
			else
			{
				bool flag4 = !cFunction.getUserData(this._cReportItem, this._sUserId);
				if (flag4)
				{
					this._pui.manualLogin();
				}
				else
				{
					this._pui.setLogin(this._cReportItem);
				}
			}
		}

		// Token: 0x040001D7 RID: 471
		private PMUserInformation _pui;

		// Token: 0x040001D8 RID: 472
		private PMInformation _pi;

		// Token: 0x040001D9 RID: 473
		private PMContent _pc;

		// Token: 0x040001DA RID: 474
		private PMAttach _pa;

		// Token: 0x040001DB RID: 475
		private QueryMgr _queryMgr;

		// Token: 0x040001DC RID: 476
		private string _sFileList = string.Empty;

		// Token: 0x040001DD RID: 477
		private string _sUserId = string.Empty;

		// Token: 0x040001DE RID: 478
		private long _fileSizeRTF = 0L;

		// Token: 0x040001DF RID: 479
		private readonly long _lMaxReportSize = 1048576L;

		// Token: 0x040001E0 RID: 480
		private Dictionary<string, string> _DeptMailList = new Dictionary<string, string>();

		// Token: 0x040001E1 RID: 481
		private List<cEmailInfo> _ToEmailList = new List<cEmailInfo>();

		// Token: 0x040001E2 RID: 482
		private List<cEmailInfo> _CCEmailList = new List<cEmailInfo>();

		// Token: 0x040001E3 RID: 483
		private List<string> _detailList = new List<string>();

		// Token: 0x040001E4 RID: 484
		private DateTime _RequestTime;

		// Token: 0x040001E5 RID: 485
		private cReportItem _cReportItem;
	}
}
