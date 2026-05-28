using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.ManufactureHistory
{
	// Token: 0x02000006 RID: 6
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00004200 File Offset: 0x00002400
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000424C File Offset: 0x0000244C
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00004268 File Offset: 0x00002468
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new ManufactureHistory(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
