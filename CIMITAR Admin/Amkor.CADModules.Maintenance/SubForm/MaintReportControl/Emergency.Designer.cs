namespace Amkor.CADModules.Maintenance.SubForm.MaintReportControl
{
	// Token: 0x0200002D RID: 45
	public partial class Emergency : global::System.Windows.Forms.Form
	{
		// Token: 0x060002E1 RID: 737 RVA: 0x00060D1C File Offset: 0x0005EF1C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00060D54 File Offset: 0x0005EF54
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pbCancel = new global::System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).BeginInit();
			base.SuspendLayout();
			this.label1.BackColor = global::System.Drawing.Color.LightGray;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new global::System.Drawing.Font("궁서", 36f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label1.Location = new global::System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(795, 50);
			this.label1.TabIndex = 0;
			this.label1.Text = "<EMERGENCY>";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.AutoSize = true;
			this.label3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new global::System.Drawing.Font("휴먼엑스포", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(0, 50);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(541, 108);
			this.label3.TabIndex = 2;
			this.label3.Text = "긴급 정비 의뢰가 남용될 경우, 본 기능의 취지는 퇴색될 것 입니다.\r\n아래 세 가지 조건이 모두 해당 할 경우에 긴급 정비 의뢰하시기 바랍니다.\r\n1. 긴급 자재인 경우\r\n2. 대체 장비가 없거나 부족할 경우\r\n3. 입고 시일이 매우 촉박할 경우\r\n4. 기타 시급히 우선적인 조치(정상화)가 필요한 경우";
			this.panel1.Controls.Add(this.pbCancel);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 177);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(795, 47);
			this.panel1.TabIndex = 3;
			this.pbCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbCancel.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbCancel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.Location = new global::System.Drawing.Point(747, 0);
			this.pbCancel.Name = "pbCancel";
			this.pbCancel.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbCancel.Size = new global::System.Drawing.Size(48, 47);
			this.pbCancel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbCancel.TabIndex = 47;
			this.pbCancel.TabStop = false;
			this.pbCancel.Click += new global::System.EventHandler(this.pbCancel_Click);
			this.pbCancel.MouseEnter += new global::System.EventHandler(this.pbCancel_MouseEnter);
			this.pbCancel.MouseLeave += new global::System.EventHandler(this.pbCancel_MouseLeave);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.LightGray;
			base.ClientSize = new global::System.Drawing.Size(795, 224);
			base.ControlBox = false;
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Emergency";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400051E RID: 1310
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400051F RID: 1311
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000520 RID: 1312
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000521 RID: 1313
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000522 RID: 1314
		private global::System.Windows.Forms.PictureBox pbCancel;
	}
}
