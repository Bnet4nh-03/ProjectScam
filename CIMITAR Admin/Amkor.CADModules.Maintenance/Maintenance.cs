using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.SubForm;
using Amkor.CADModules.Maintenance.SubForm.search;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.Maintenance
{
	// Token: 0x02000002 RID: 2
	public partial class Maintenance : BaseWinView
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Maintenance()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://testweb.amkor.co.kr/";
			this._factorySetting._factoryName = "ATK";
			this._factorySetting._urlServer = "http://10.201.16.55/";
			this._factorySetting._factoryName = "ATV";
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this._isAdmin = true;
			this._isDebug = true;
			try
			{
				bool flag = Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach");
				if (flag)
				{
					Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach", true);
				}
			}
			catch (Exception ex)
			{
			}
			cFunction.Initialize(this._factorySetting);
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002144 File Offset: 0x00000344
		public Maintenance(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			string text = this._cimitarUser._userstring1.ToString();
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			try
			{
				bool flag = Directory.Exists("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach");
				if (flag)
				{
					Directory.Delete("C:\\Temp\\CimitarAdmin\\Maint\\download\\attach", true);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			bool flag2 = commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG";
			if (flag2)
			{
				this._isAdmin = true;
				this._isDebug = true;
				this._factorySetting._factoryName = "ATK";
			}
			bool flag3 = text.IndexOf("CAD_MAINT_ADMIN") != -1;
			if (flag3)
			{
				this._isAdmin = true;
			}
			bool flag4 = text.IndexOf("CAD_MAINT_MID") != -1;
			if (flag4)
			{
				this._isMiddle = true;
			}
			cFunction.Initialize(this._factorySetting);
			this.InitializeComponent();
			base.Height = 700;
			this.Text = this._factorySetting._factoryName + " Maintenance";
			this.lbTitle.Text = this._factorySetting._factoryName + " Maintenance";
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000022D4 File Offset: 0x000004D4
		private void Maintenance_Shown(object sender, EventArgs e)
		{
			bool isDebug = this._isDebug;
			if (isDebug)
			{
				MessageBox.Show("Language is " + MessageLanguage.type);
			}
			bool isDebug2 = this._isDebug;
			if (isDebug2)
			{
				MessageBox.Show("This is ATV version");
			}
			this.tbReport.Controls.Clear();
			base.Invoke(new MethodInvoker(delegate()
			{
				Size size = default(Size);
				size.Height = 700;
				size.Width = 1280;
				this.report = new Report(this._cimitarUser._id, this._factorySetting);
				this.report.TopLevel = false;
				this.report.TopMost = true;
				this.report.Size = size;
				this.report.Dock = DockStyle.Fill;
				this.tbReport.Controls.Add(this.report);
				this.report.Show();
			}));
			this.tbStatus.Controls.Clear();
			base.Invoke(new MethodInvoker(delegate()
			{
				Size size = default(Size);
				size.Height = 700;
				size.Width = 1280;
				this.status = new cStatus(this._cimitarUser, this._factorySetting);
				this.status.TopLevel = false;
				this.status.TopMost = true;
				this.status.Size = size;
				this.status.Dock = DockStyle.Fill;
				this.tbStatus.Controls.Add(this.status);
			}));
			this.tbSearch.Controls.Clear();
			base.Invoke(new MethodInvoker(delegate()
			{
				Size size = default(Size);
				size.Height = 700;
				size.Width = 1280;
				this.searchForm = new SearchForm(this._cimitarUser, this._factorySetting);
				this.searchForm.TopLevel = false;
				this.searchForm.TopMost = true;
				this.searchForm.Size = size;
				this.searchForm.Dock = DockStyle.Fill;
				this.tbSearch.Controls.Add(this.searchForm);
			}));
			bool flag = this._isAdmin || this._isMiddle;
			if (flag)
			{
				this.tpTrend.Controls.Clear();
				base.Invoke(new MethodInvoker(delegate()
				{
					Size size = default(Size);
					size.Height = 700;
					size.Width = 1280;
					this.trendForm = new TrendForm(this._cimitarUser, this._factorySetting);
					this.trendForm.TopLevel = false;
					this.trendForm.TopMost = true;
					this.trendForm.Size = size;
					this.trendForm.Dock = DockStyle.Fill;
					this.tpTrend.Controls.Add(this.trendForm);
				}));
			}
			else
			{
				this.tpMain.TabPages.Remove(this.tpTrend);
			}
			bool flag2 = this._factorySetting._factoryName == "ATV";
			if (flag2)
			{
				this.tpMain.TabPages.Remove(this.tpTrend);
			}
			this.tpPM.Controls.Clear();
			base.Invoke(new MethodInvoker(delegate()
			{
				Size size = default(Size);
				size.Height = 700;
				size.Width = 1280;
				this.pmForm = new PMRequest(this._factorySetting, this._cimitarUser);
				this.pmForm.TopLevel = false;
				this.pmForm.TopMost = true;
				this.pmForm.Size = size;
				this.pmForm.Dock = DockStyle.Fill;
				this.pmForm.Visible = true;
				this.tpPM.Controls.Add(this.pmForm);
			}));
			bool isAdmin = this._isAdmin;
			if (isAdmin)
			{
				this.tpAdmin.Controls.Clear();
				base.Invoke(new MethodInvoker(delegate()
				{
					Size size = default(Size);
					size.Height = 700;
					size.Width = 1280;
					this.adminSetting = new AdminSetting(this._factorySetting);
					this.adminSetting.TopLevel = false;
					this.adminSetting.TopMost = true;
					this.adminSetting.Size = size;
					this.adminSetting.Dock = DockStyle.Fill;
					this.tpAdmin.Controls.Add(this.adminSetting);
				}));
			}
			else
			{
				this.tpMain.TabPages.Remove(this.tpAdmin);
			}
			string updateMessage = cFunction.getUpdateMessage(this._factorySetting, this._cimitarUser._id);
			bool flag3 = !string.IsNullOrEmpty(updateMessage.Trim());
			if (flag3)
			{
				new Notification("Update Notes", updateMessage, string.Empty, "CLOSE", SystemIcons.Information, true)
				{
					StartPosition = FormStartPosition.CenterParent
				}.ShowDialog(this);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000024D4 File Offset: 0x000006D4
		private void Maintenance_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = sender != this;
			if (flag)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000024F8 File Offset: 0x000006F8
		private void tabControl1_Selected(object sender, TabControlEventArgs e)
		{
			bool flag = e.TabPage == this.tbReport;
			if (flag)
			{
				this.report.Show();
				this.report.Login();
			}
			else
			{
				bool flag2 = e.TabPage == this.tbStatus;
				if (flag2)
				{
					this.status.Show();
				}
				else
				{
					bool flag3 = e.TabPage == this.tpAdmin;
					if (flag3)
					{
						this.adminSetting.Show();
					}
					else
					{
						bool flag4 = e.TabPage == this.tbSearch;
						if (flag4)
						{
							this.searchForm.Show();
						}
						else
						{
							bool flag5 = e.TabPage == this.tpTrend;
							if (flag5)
							{
								this.trendForm.Show();
							}
							else
							{
								bool flag6 = e.TabPage == this.tpPM;
								if (flag6)
								{
									this.pmForm.Show();
									this.pmForm.Login();
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04000001 RID: 1
		private Report report;

		// Token: 0x04000002 RID: 2
		private cStatus status;

		// Token: 0x04000003 RID: 3
		private AdminSetting adminSetting;

		// Token: 0x04000004 RID: 4
		private TrendForm trendForm;

		// Token: 0x04000005 RID: 5
		private SearchForm searchForm;

		// Token: 0x04000006 RID: 6
		private PMRequest pmForm;

		// Token: 0x04000007 RID: 7
		private const int _iFormHeight = 700;

		// Token: 0x04000008 RID: 8
		private const int _iFormWidth = 1280;

		// Token: 0x04000009 RID: 9
		private bool _isAdmin = false;

		// Token: 0x0400000A RID: 10
		private bool _isMiddle = false;

		// Token: 0x0400000B RID: 11
		private bool _isDebug = false;
	}
}
