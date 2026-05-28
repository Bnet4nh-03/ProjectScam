using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.CarrierModule
{
	// Token: 0x02000034 RID: 52
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x0600020C RID: 524 RVA: 0x0003EA3B File Offset: 0x0003CC3B
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0003EA6D File Offset: 0x0003CC6D
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0003EA78 File Offset: 0x0003CC78
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new Carrier(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
