using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.HccSTReportModule
{
	// Token: 0x02000004 RID: 4
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x06000023 RID: 35 RVA: 0x0000A0B1 File Offset: 0x000082B1
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000A0E3 File Offset: 0x000082E3
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000A0F0 File Offset: 0x000082F0
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new HccSTReportModule(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
