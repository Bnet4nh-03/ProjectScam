namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000038 RID: 56
	public partial class Notification : global::System.Windows.Forms.Form
	{
		// Token: 0x0600038A RID: 906 RVA: 0x0006BB88 File Offset: 0x00069D88
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.tbSubTitle = new global::System.Windows.Forms.TextBox();
			this.lbMainTitle = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnYes = new global::System.Windows.Forms.Button();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.btnNo = new global::System.Windows.Forms.Button();
			this.saveFileDialog1 = new global::System.Windows.Forms.SaveFileDialog();
			this.panel1.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.White;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(464, 161);
			this.panel1.TabIndex = 0;
			this.panel6.BackColor = global::System.Drawing.Color.White;
			this.panel6.Controls.Add(this.tbSubTitle);
			this.panel6.Controls.Add(this.lbMainTitle);
			this.panel6.Controls.Add(this.panel5);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new global::System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new global::System.Windows.Forms.Padding(0, 1, 0, 1);
			this.panel6.Size = new global::System.Drawing.Size(462, 119);
			this.panel6.TabIndex = 6;
			this.tbSubTitle.BackColor = global::System.Drawing.Color.White;
			this.tbSubTitle.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.tbSubTitle.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.tbSubTitle.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbSubTitle.Font = new global::System.Drawing.Font("바탕", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.tbSubTitle.Location = new global::System.Drawing.Point(86, 46);
			this.tbSubTitle.Multiline = true;
			this.tbSubTitle.Name = "tbSubTitle";
			this.tbSubTitle.ReadOnly = true;
			this.tbSubTitle.Size = new global::System.Drawing.Size(376, 72);
			this.tbSubTitle.TabIndex = 5;
			this.tbSubTitle.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.lbMainTitle.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.lbMainTitle.Font = new global::System.Drawing.Font("휴먼엑스포", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.lbMainTitle.Location = new global::System.Drawing.Point(86, 1);
			this.lbMainTitle.Name = "lbMainTitle";
			this.lbMainTitle.Padding = new global::System.Windows.Forms.Padding(0, 0, 0, 1);
			this.lbMainTitle.Size = new global::System.Drawing.Size(376, 45);
			this.lbMainTitle.TabIndex = 0;
			this.lbMainTitle.Text = "Main Title";
			this.lbMainTitle.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel5.Controls.Add(this.pictureBox1);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel5.Location = new global::System.Drawing.Point(0, 1);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(86, 117);
			this.panel5.TabIndex = 2;
			this.panel5.Visible = false;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new global::System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(86, 117);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.panel2.BackColor = global::System.Drawing.Color.White;
			this.panel2.Controls.Add(this.btnYes);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.btnNo);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 119);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel2.Size = new global::System.Drawing.Size(462, 40);
			this.panel2.TabIndex = 7;
			this.btnYes.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnYes.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnYes.Location = new global::System.Drawing.Point(283, 3);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new global::System.Drawing.Size(75, 34);
			this.btnYes.TabIndex = 0;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new global::System.EventHandler(this.btnYes_Click);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel4.Location = new global::System.Drawing.Point(358, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(26, 34);
			this.panel4.TabIndex = 2;
			this.btnNo.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnNo.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnNo.Location = new global::System.Drawing.Point(384, 3);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new global::System.Drawing.Size(75, 34);
			this.btnNo.TabIndex = 1;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new global::System.EventHandler(this.btnNo_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(464, 161);
			base.ControlBox = false;
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Notification";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = " Notification";
			this.panel1.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040005BC RID: 1468
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040005BD RID: 1469
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040005BE RID: 1470
		private global::System.Windows.Forms.Label lbMainTitle;

		// Token: 0x040005BF RID: 1471
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040005C0 RID: 1472
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040005C1 RID: 1473
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040005C2 RID: 1474
		private global::System.Windows.Forms.Button btnYes;

		// Token: 0x040005C3 RID: 1475
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040005C4 RID: 1476
		private global::System.Windows.Forms.Button btnNo;

		// Token: 0x040005C5 RID: 1477
		private global::System.Windows.Forms.TextBox tbSubTitle;

		// Token: 0x040005C6 RID: 1478
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog1;
	}
}
