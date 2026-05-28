using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.HccRepHisModule
{
	// Token: 0x02000004 RID: 4
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x0600001C RID: 28 RVA: 0x000034FF File Offset: 0x000016FF
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003531 File Offset: 0x00001731
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000353C File Offset: 0x0000173C
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new HccRepHisModule(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
