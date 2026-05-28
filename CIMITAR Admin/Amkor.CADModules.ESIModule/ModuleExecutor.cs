using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.ESIModule
{
	// Token: 0x02000021 RID: 33
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x0600007A RID: 122 RVA: 0x00005AEC File Offset: 0x00003CEC
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005B1E File Offset: 0x00003D1E
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005B28 File Offset: 0x00003D28
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new ESI(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
