using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms.TabPages
{
	// Token: 0x0200002A RID: 42
	public class Tab_Base : TabPage
	{
		// Token: 0x06000125 RID: 293 RVA: 0x0001907C File Offset: 0x0001727C
		public Tab_Base()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0001908A File Offset: 0x0001728A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000190AC File Offset: 0x000172AC
		private void InitializeComponent()
		{
			this.panel1 = new Panel();
			base.SuspendLayout();
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(3);
			this.panel1.Size = new Size(1128, 629);
			this.panel1.TabIndex = 0;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel1);
			this.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Margin = new Padding(3, 4, 3, 4);
			base.Name = "Tab_Base";
			base.Padding = new Padding(3);
			base.Size = new Size(1134, 635);
			base.ResumeLayout(false);
		}

		// Token: 0x040001F6 RID: 502
		private IContainer components;

		// Token: 0x040001F7 RID: 503
		public Panel panel1;
	}
}
