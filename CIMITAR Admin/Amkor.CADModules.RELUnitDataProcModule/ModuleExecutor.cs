using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.RELUnitDataProcModule
{
	// Token: 0x0200000D RID: 13
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x06000065 RID: 101 RVA: 0x00003AF4 File Offset: 0x00001CF4
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			bool flag = this._executeModule.WindowState == FormWindowState.Minimized;
			if (flag)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003B3C File Offset: 0x00001D3C
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003B58 File Offset: 0x00001D58
		public BaseWinView ExcuteModule()
		{
			bool flag = this._executeModule == null;
			if (flag)
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
