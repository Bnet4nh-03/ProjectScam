using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.BoardCenterClient
{
	// Token: 0x02000005 RID: 5
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00006752 File Offset: 0x00004952
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00006784 File Offset: 0x00004984
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00006790 File Offset: 0x00004990
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
			{
				this._executeModule = new BoardCenterClientMain(this._fset, this._baseMain, this._cimitarUser, this._cimitarMenu);
				this._executeModule.Icon = this._cimitarMenu.icon;
				this._executeModule.MdiParent = this._baseMain;
				this._executeModule.Show();
			}
			return this._executeModule;
		}
	}
}
