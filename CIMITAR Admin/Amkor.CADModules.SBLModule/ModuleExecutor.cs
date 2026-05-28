using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.SBLModule
{
	// Token: 0x0200001C RID: 28
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x060000DA RID: 218 RVA: 0x0000F704 File Offset: 0x0000D904
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000F736 File Offset: 0x0000D936
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000F740 File Offset: 0x0000D940
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new RULESBLManager(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
