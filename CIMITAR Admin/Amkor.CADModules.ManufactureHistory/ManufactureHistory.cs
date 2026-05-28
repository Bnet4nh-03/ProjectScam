using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.ManufactureHistory.GrobalConstMFG;
using Amkor.CADModules.ManufactureHistory.SubForm;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.ManufactureHistory
{
	// Token: 0x02000005 RID: 5
	public partial class ManufactureHistory : BaseWinView
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00003A24 File Offset: 0x00001C24
		public ManufactureHistory()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://10.101.5.190:8080/";
			this._factorySetting._factoryName = "ATK_K5_M";
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this._isAdmin = true;
			cFunction.setFactory(this._factorySetting);
			this.InitializeComponent();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00003AB8 File Offset: 0x00001CB8
		public ManufactureHistory(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			cFunction.setFactory(factorySetting);
			string text = this._cimitarUser._userstring1.ToString();
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs.Length == 2 && commandLineArgs[1].ToUpper() == "DEBUG")
			{
				this._isAdmin = true;
				this._isDebug = true;
			}
			if (text.IndexOf("CAD_MAINT_MFG_ADMIN") != -1)
			{
				this._isAdmin = true;
			}
			this.InitializeComponent();
			this.Text = this._factorySetting._factoryName + " Manufacture History";
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003D94 File Offset: 0x00001F94
		private void ManufactureHistory_Shown(object sender, EventArgs e)
		{
			this.tpMaintenance.Controls.Clear();
			base.Invoke(new MethodInvoker(delegate()
			{
				Size size = default(Size);
				size.Height = this.tpMaintenance.Height;
				size.Width = this.tpMaintenance.Width;
				this.report = new Report(this._cimitarUser, this._factorySetting);
				this.report.TopLevel = false;
				this.report.TopMost = true;
				this.report.Size = size;
				this.report.Dock = DockStyle.Fill;
				this.tpMaintenance.Controls.Add(this.report);
				this.report.Show();
			}));
			this.tpSearch.Controls.Clear();
			base.Invoke(new MethodInvoker(delegate()
			{
				Size size = default(Size);
				size.Height = this.tpMaintenance.Height;
				size.Width = this.tpMaintenance.Width;
				this.history = new Search(this._cimitarUser, this._factorySetting);
				this.history.TopLevel = false;
				this.history.TopMost = true;
				this.history.Size = size;
				this.history.Dock = DockStyle.Fill;
				this.tpSearch.Controls.Add(this.history);
				this.history.Show();
			}));
			if (this._isAdmin)
			{
				this.tpAdmin.Controls.Clear();
				base.Invoke(new MethodInvoker(delegate()
				{
					Size size = default(Size);
					size.Height = this.tpMaintenance.Height;
					size.Width = this.tpMaintenance.Width;
					this.adminsetting = new AdminSetting(this._cimitarUser, this._factorySetting);
					this.adminsetting.TopLevel = false;
					this.adminsetting.TopMost = true;
					this.adminsetting.Size = size;
					this.adminsetting.Dock = DockStyle.Fill;
					this.tpAdmin.Controls.Add(this.adminsetting);
					this.adminsetting.Show();
				}));
			}
			else
			{
				this.tabControl.TabPages.Remove(this.tpAdmin);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003E44 File Offset: 0x00002044
		private void tabControl_Selected(object sender, TabControlEventArgs e)
		{
			if (e.TabPage == this.tpMaintenance)
			{
				if (this.report != null)
				{
					this.report.Show();
				}
			}
			else if (e.TabPage == this.tpSearch)
			{
				if (this.history != null)
				{
					this.history.Show();
				}
			}
		}

		// Token: 0x04000003 RID: 3
		private Report report;

		// Token: 0x04000004 RID: 4
		private Search history;

		// Token: 0x04000005 RID: 5
		private AdminSetting adminsetting;

		// Token: 0x04000006 RID: 6
		private bool _isAdmin = false;

		// Token: 0x04000007 RID: 7
		private bool _isDebug = false;
	}
}
