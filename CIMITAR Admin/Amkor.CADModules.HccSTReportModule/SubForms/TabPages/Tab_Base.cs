using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x0200000B RID: 11
	public class Tab_Base : TabPage
	{
		// Token: 0x06000068 RID: 104 RVA: 0x0000EC50 File Offset: 0x0000CE50
		public Tab_Base()
		{
			this.InitializeComponent();
			this.AutoScroll = true;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000EC65 File Offset: 0x0000CE65
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000EC84 File Offset: 0x0000CE84
		private void InitializeComponent()
		{
			this.panel1 = new Panel();
			base.SuspendLayout();
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.AutoScroll = true;
			this.panel1.Location = new Point(3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new Padding(3);
			this.panel1.Size = new Size(1056, 254);
			this.panel1.TabIndex = 0;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel1);
			this.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Margin = new Padding(3, 4, 3, 4);
			base.Name = "Tab_Base";
			base.Padding = new Padding(3, 4, 3, 4);
			base.Size = new Size(1062, 262);
			base.ResumeLayout(false);
		}

		// Token: 0x04000096 RID: 150
		private IContainer components;

		// Token: 0x04000097 RID: 151
		public Panel panel1;
	}
}
