using System;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000040 RID: 64
	internal class SiteMapToolStripTextBox : ToolStripTextBox
	{
		// Token: 0x060003D4 RID: 980 RVA: 0x000722C4 File Offset: 0x000704C4
		public SiteMapToolStripTextBox(string waterMake = "")
		{
			base.BorderStyle = BorderStyle.FixedSingle;
			this.Size = new Size(161, 25);
			base.MouseDown += this.MouseEnterEvent;
			bool flag = !string.IsNullOrEmpty(waterMake);
			if (flag)
			{
				this.ForeColor = Color.Gray;
				this.Text = waterMake;
				this._waterMark = waterMake;
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0007233C File Offset: 0x0007053C
		private void MouseEnterEvent(object o, MouseEventArgs e)
		{
			bool flag = !string.IsNullOrEmpty(this._waterMark) && e.Button == MouseButtons.Left && ((ToolStripTextBox)o).Text.Equals(this._waterMark);
			if (flag)
			{
				((ToolStripTextBox)o).Text = string.Empty;
				((ToolStripTextBox)o).ForeColor = Color.Black;
			}
		}

		// Token: 0x04000615 RID: 1557
		private string _waterMark = string.Empty;
	}
}
