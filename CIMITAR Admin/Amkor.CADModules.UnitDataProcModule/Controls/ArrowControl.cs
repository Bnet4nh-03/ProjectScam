using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.UnitDataProcModule.Properties;

namespace Amkor.CADModules.UnitDataProcModule.Controls
{
	// Token: 0x0200000A RID: 10
	public class ArrowControl : UserControl
	{
		// Token: 0x06000030 RID: 48 RVA: 0x000079C8 File Offset: 0x00005BC8
		public ArrowControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000079D6 File Offset: 0x00005BD6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000079F8 File Offset: 0x00005BF8
		private void InitializeComponent()
		{
			this.pictureBox1 = new PictureBox();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Image = Resources.arrow_right;
			this.pictureBox1.Location = new Point(9, 83);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(32, 32);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.pictureBox1);
			base.Name = "ArrowControl";
			base.Size = new Size(50, 200);
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400003E RID: 62
		private IContainer components;

		// Token: 0x0400003F RID: 63
		private PictureBox pictureBox1;
	}
}
