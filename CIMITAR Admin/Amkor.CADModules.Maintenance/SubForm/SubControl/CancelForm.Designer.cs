namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200002E RID: 46
	public partial class CancelForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060002ED RID: 749 RVA: 0x000613C0 File Offset: 0x0005F5C0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x000613F8 File Offset: 0x0005F5F8
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pbCancel = new global::System.Windows.Forms.PictureBox();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.pbOK = new global::System.Windows.Forms.PictureBox();
			this.rbContent7 = new global::System.Windows.Forms.RichTextBox();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbOK).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.pbCancel);
			this.panel1.Controls.Add(this.panel18);
			this.panel1.Controls.Add(this.pbOK);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 236);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(958, 48);
			this.panel1.TabIndex = 66;
			this.pbCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbCancel.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbCancel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.Location = new global::System.Drawing.Point(839, 0);
			this.pbCancel.Name = "pbCancel";
			this.pbCancel.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbCancel.Size = new global::System.Drawing.Size(48, 48);
			this.pbCancel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbCancel.TabIndex = 50;
			this.pbCancel.TabStop = false;
			this.pbCancel.Click += new global::System.EventHandler(this.pbCancel_Click);
			this.pbCancel.MouseEnter += new global::System.EventHandler(this.pbCancel_MouseEnter);
			this.pbCancel.MouseLeave += new global::System.EventHandler(this.pbCancel_MouseLeave);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel18.Location = new global::System.Drawing.Point(887, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(23, 48);
			this.panel18.TabIndex = 49;
			this.pbOK.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbOK.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbOK.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.apply;
			this.pbOK.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbOK.Location = new global::System.Drawing.Point(910, 0);
			this.pbOK.Name = "pbOK";
			this.pbOK.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbOK.Size = new global::System.Drawing.Size(48, 48);
			this.pbOK.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbOK.TabIndex = 48;
			this.pbOK.TabStop = false;
			this.pbOK.Click += new global::System.EventHandler(this.pbOK_Click);
			this.pbOK.MouseEnter += new global::System.EventHandler(this.pbCancel_MouseEnter);
			this.pbOK.MouseLeave += new global::System.EventHandler(this.pbCancel_MouseLeave);
			this.rbContent7.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.rbContent7.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rbContent7.Location = new global::System.Drawing.Point(0, 0);
			this.rbContent7.Name = "rbContent7";
			this.rbContent7.Size = new global::System.Drawing.Size(958, 236);
			this.rbContent7.TabIndex = 68;
			this.rbContent7.Text = "※취소 사유를 구체적으로 기입해주세요.";
			this.rbContent7.Click += new global::System.EventHandler(this.rbContent7_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(958, 284);
			base.Controls.Add(this.rbContent7);
			base.Controls.Add(this.panel1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "CancelForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cancel(Delete)";
			base.Shown += new global::System.EventHandler(this.CancelForm_Shown);
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbOK).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000525 RID: 1317
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000526 RID: 1318
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000527 RID: 1319
		private global::System.Windows.Forms.PictureBox pbCancel;

		// Token: 0x04000528 RID: 1320
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000529 RID: 1321
		private global::System.Windows.Forms.PictureBox pbOK;

		// Token: 0x0400052A RID: 1322
		private global::System.Windows.Forms.RichTextBox rbContent7;
	}
}
