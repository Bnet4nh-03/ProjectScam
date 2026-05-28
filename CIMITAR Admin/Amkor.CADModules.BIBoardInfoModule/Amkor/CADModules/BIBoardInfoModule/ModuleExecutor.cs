using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.BIBoardInfoModule
{
	// Token: 0x0200001C RID: 28
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00009ECE File Offset: 0x000080CE
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00009F00 File Offset: 0x00008100
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00009F0C File Offset: 0x0000810C
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new BIBoardInfoModule(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
