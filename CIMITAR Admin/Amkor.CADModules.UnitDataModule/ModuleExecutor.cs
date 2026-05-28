using System;
using System.Windows.Forms;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.UnitDataModule
{
	// Token: 0x0200001C RID: 28
	internal class ModuleExecutor : CIMitarExecutor, ICIMitarExecutor
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00005624 File Offset: 0x00003824
		public void ActivateModule()
		{
			this._executeModule.Activate();
			this._executeModule.BringToFront();
			if (this._executeModule.WindowState == FormWindowState.Minimized)
			{
				this._executeModule.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005656 File Offset: 0x00003856
		public int DropModule()
		{
			this._executeModule = null;
			return 0;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00005660 File Offset: 0x00003860
		public BaseWinView ExcuteModule()
		{
			if (this._executeModule == null)
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
