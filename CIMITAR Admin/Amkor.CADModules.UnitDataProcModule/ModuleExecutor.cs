using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.UnitDataProcModule
{
	// Token: 0x0200001B RID: 27
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x0000E118 File Offset: 0x0000C318
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000E14A File Offset: 0x0000C34A
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000E154 File Offset: 0x0000C354
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new UnitDataAnalysis(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
