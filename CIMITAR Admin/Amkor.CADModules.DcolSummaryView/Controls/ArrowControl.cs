using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.DcolSummaryView.Properties;

namespace Amkor.CADModules.DcolSummaryView.Controls
{
	// Token: 0x0200000A RID: 10
	public class ArrowControl : UserControl
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00004DF8 File Offset: 0x00002FF8
		public ArrowControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00004E06 File Offset: 0x00003006
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00004E28 File Offset: 0x00003028
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

		// Token: 0x0400002C RID: 44
		private IContainer components;

		// Token: 0x0400002D RID: 45
		private PictureBox pictureBox1;
	}
}
