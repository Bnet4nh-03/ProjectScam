using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.HccRepHisModule.SubForms.TabPages
{
	// Token: 0x0200000B RID: 11
	public class Tab_Base : TabPage
	{
		// Token: 0x06000053 RID: 83 RVA: 0x000060D2 File Offset: 0x000042D2
		public Tab_Base()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000060E0 File Offset: 0x000042E0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00006100 File Offset: 0x00004300
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

		// Token: 0x04000053 RID: 83
		private IContainer components;

		// Token: 0x04000054 RID: 84
		public Panel panel1;
	}
}
