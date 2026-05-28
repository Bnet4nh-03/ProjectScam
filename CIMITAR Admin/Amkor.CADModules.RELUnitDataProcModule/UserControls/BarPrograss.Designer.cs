namespace Amkor.CADModules.RELUnitDataProcModule.UserControls
{
	// Token: 0x02000016 RID: 22
	public partial class BarPrograss : global::System.Windows.Forms.Form
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x0000FAA4 File Offset: 0x0000DCA4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000FADC File Offset: 0x0000DCDC
		private void InitializeComponent()
		{
			this.colorProgressBar = new global::ColorProgressBar.ColorProgressBar();
			this.lblStatus = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.lbl_header = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.colorProgressBar.BarColor = global::System.Drawing.Color.FromArgb(240, 110, 170);
			this.colorProgressBar.BorderColor = global::System.Drawing.Color.White;
			this.colorProgressBar.FillStyle = global::ColorProgressBar.ColorProgressBar.FillStyles.Solid;
			this.colorProgressBar.Location = new global::System.Drawing.Point(15, 74);
			this.colorProgressBar.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.colorProgressBar.Maximum = 100;
			this.colorProgressBar.Minimum = 0;
			this.colorProgressBar.Name = "colorProgressBar";
			this.colorProgressBar.Size = new global::System.Drawing.Size(379, 12);
			this.colorProgressBar.Step = 1;
			this.colorProgressBar.TabIndex = 0;
			this.colorProgressBar.Value = 100;
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new global::System.Drawing.Point(12, 50);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new global::System.Drawing.Size(59, 15);
			this.lblStatus.TabIndex = 1;
			this.lblStatus.Text = "Loading...";
			this.panel1.BackColor = global::System.Drawing.Color.Gainsboro;
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.lbl_header);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(405, 37);
			this.panel1.TabIndex = 2;
			this.btnCancel.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new global::System.Drawing.Point(344, 7);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(58, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.lbl_header.AutoSize = true;
			this.lbl_header.Location = new global::System.Drawing.Point(12, 11);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new global::System.Drawing.Size(38, 15);
			this.lbl_header.TabIndex = 0;
			this.lbl_header.Text = "label1";
			this.panel2.BackColor = global::System.Drawing.Color.White;
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Controls.Add(this.lblStatus);
			this.panel2.Controls.Add(this.colorProgressBar);
			this.panel2.Location = new global::System.Drawing.Point(1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(405, 101);
			this.panel2.TabIndex = 3;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.Black;
			base.ClientSize = new global::System.Drawing.Size(407, 103);
			base.Controls.Add(this.panel2);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MaximizeBox = false;
			base.Name = "BarPrograss";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Please Wait..";
			base.Load += new global::System.EventHandler(this.BarPrograss_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000DF RID: 223
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040000E0 RID: 224
		private global::ColorProgressBar.ColorProgressBar colorProgressBar;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.Label lblStatus;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.Label lbl_header;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.Button btnCancel;
	}
}
