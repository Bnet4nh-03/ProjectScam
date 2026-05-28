using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.Maintenance
{
	// Token: 0x02000003 RID: 3
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00003158 File Offset: 0x00001358
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

		// Token: 0x0600000F RID: 15 RVA: 0x000031A0 File Offset: 0x000013A0
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000031BC File Offset: 0x000013BC
		public BaseWinView ExcuteModule()
		{
			bool flag = this._executeModule == null;
			if (flag)
			{
				this._executeModule = new Maintenance(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
