using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.SBLAnalysisModule
{
	// Token: 0x02000014 RID: 20
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x0600008B RID: 139 RVA: 0x0000A750 File Offset: 0x00008950
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000A79C File Offset: 0x0000899C
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000A7B8 File Offset: 0x000089B8
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new SBLAnalysis(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
