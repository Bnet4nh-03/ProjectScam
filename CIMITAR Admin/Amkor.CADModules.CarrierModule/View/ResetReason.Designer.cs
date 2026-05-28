namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200004E RID: 78
	public partial class ResetReason : global::System.Windows.Forms.Form
	{
		// Token: 0x0600039F RID: 927 RVA: 0x000564DC File Offset: 0x000546DC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x000564FC File Offset: 0x000546FC
		private void InitializeComponent()
		{
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.cmdApply = new global::System.Windows.Forms.PictureBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtResetReason = new global::System.Windows.Forms.TextBox();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			this.panel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).BeginInit();
			base.SuspendLayout();
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(398, 10);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 98;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			this.panel3.Controls.Add(this.cmdApply);
			this.panel3.Controls.Add(this.cmdClose);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.txtResetReason);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(445, 49);
			this.panel3.TabIndex = 31;
			this.cmdApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdApply.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdApply.Location = new global::System.Drawing.Point(360, 10);
			this.cmdApply.Name = "cmdApply";
			this.cmdApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmdApply.TabIndex = 99;
			this.cmdApply.TabStop = false;
			this.cmdApply.Click += new global::System.EventHandler(this.cmdApply_Click);
			this.cmdApply.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseDown);
			this.cmdApply.MouseLeave += new global::System.EventHandler(this.cmdApply_MouseLeave);
			this.cmdApply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseMove);
			this.cmdApply.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseUp);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(7, 17);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(76, 15);
			this.label3.TabIndex = 91;
			this.label3.Text = "Reset Reason";
			this.txtResetReason.Location = new global::System.Drawing.Point(89, 14);
			this.txtResetReason.Name = "txtResetReason";
			this.txtResetReason.Size = new global::System.Drawing.Size(254, 23);
			this.txtResetReason.TabIndex = 90;
			this.txtResetReason.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtResetReason_KeyPress);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(445, 49);
			base.Controls.Add(this.panel3);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "ResetReason";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Input Reset Reason";
			base.Load += new global::System.EventHandler(this.ResultView_Load);
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040005D6 RID: 1494
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040005D7 RID: 1495
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x040005D8 RID: 1496
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040005D9 RID: 1497
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040005DA RID: 1498
		private global::System.Windows.Forms.TextBox txtResetReason;

		// Token: 0x040005DB RID: 1499
		private global::System.Windows.Forms.PictureBox cmdApply;
	}
}
