using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.DcolSummaryView
{
	// Token: 0x02000017 RID: 23
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00007AE4 File Offset: 0x00005CE4
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00007B16 File Offset: 0x00005D16
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00007B20 File Offset: 0x00005D20
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new DcolView(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
