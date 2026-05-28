namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000032 RID: 50
	public partial class HoldInfoForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600032D RID: 813 RVA: 0x0006511C File Offset: 0x0006331C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00065154 File Offset: 0x00063354
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pbCancel = new global::System.Windows.Forms.PictureBox();
			this.btn_Cancle = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.rbHoldComment = new global::System.Windows.Forms.RichTextBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.tbHoldTime = new global::System.Windows.Forms.TextBox();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.label37 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.tbHoldName = new global::System.Windows.Forms.TextBox();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.label27 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.tbHoldTeam = new global::System.Windows.Forms.TextBox();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.label28 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.pbCancel);
			this.panel1.Controls.Add(this.btn_Cancle);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 397);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(963, 48);
			this.panel1.TabIndex = 1;
			this.pbCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbCancel.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbCancel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.Location = new global::System.Drawing.Point(915, 0);
			this.pbCancel.Name = "pbCancel";
			this.pbCancel.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbCancel.Size = new global::System.Drawing.Size(48, 48);
			this.pbCancel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbCancel.TabIndex = 48;
			this.pbCancel.TabStop = false;
			this.pbCancel.Click += new global::System.EventHandler(this.pbCancel_Click);
			this.pbCancel.MouseEnter += new global::System.EventHandler(this.pbCancel_MouseEnter);
			this.pbCancel.MouseLeave += new global::System.EventHandler(this.pbCancel_MouseLeave);
			this.btn_Cancle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btn_Cancle.Location = new global::System.Drawing.Point(629, 0);
			this.btn_Cancle.Name = "btn_Cancle";
			this.btn_Cancle.Size = new global::System.Drawing.Size(150, 48);
			this.btn_Cancle.TabIndex = 1;
			this.btn_Cancle.Text = "Close";
			this.btn_Cancle.UseVisualStyleBackColor = true;
			this.btn_Cancle.Visible = false;
			this.btn_Cancle.Click += new global::System.EventHandler(this.btn_Cancle_Click);
			this.panel2.Controls.Add(this.rbHoldComment);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 54);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(5, 0, 0, 0);
			this.panel2.Size = new global::System.Drawing.Size(963, 343);
			this.panel2.TabIndex = 2;
			this.rbHoldComment.BackColor = global::System.Drawing.Color.LightGray;
			this.rbHoldComment.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.rbHoldComment.Location = new global::System.Drawing.Point(5, 0);
			this.rbHoldComment.Name = "rbHoldComment";
			this.rbHoldComment.ReadOnly = true;
			this.rbHoldComment.Size = new global::System.Drawing.Size(958, 343);
			this.rbHoldComment.TabIndex = 1;
			this.rbHoldComment.Text = "";
			this.panel3.Controls.Add(this.panel8);
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(963, 54);
			this.panel3.TabIndex = 4;
			this.panel8.Controls.Add(this.tbHoldTime);
			this.panel8.Controls.Add(this.panel9);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel8.Location = new global::System.Drawing.Point(400, 0);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new global::System.Windows.Forms.Padding(0, 0, 5, 0);
			this.panel8.Size = new global::System.Drawing.Size(200, 54);
			this.panel8.TabIndex = 39;
			this.tbHoldTime.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbHoldTime.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbHoldTime.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbHoldTime.Location = new global::System.Drawing.Point(0, 22);
			this.tbHoldTime.Name = "tbHoldTime";
			this.tbHoldTime.ReadOnly = true;
			this.tbHoldTime.Size = new global::System.Drawing.Size(195, 23);
			this.tbHoldTime.TabIndex = 34;
			this.panel9.Controls.Add(this.label37);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new global::System.Drawing.Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(195, 22);
			this.panel9.TabIndex = 35;
			this.label37.AutoSize = true;
			this.label37.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label37.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label37.Location = new global::System.Drawing.Point(0, 0);
			this.label37.Name = "label37";
			this.label37.Size = new global::System.Drawing.Size(68, 17);
			this.label37.TabIndex = 35;
			this.label37.Text = "Hold Time";
			this.panel6.Controls.Add(this.tbHoldName);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel6.Location = new global::System.Drawing.Point(200, 0);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new global::System.Windows.Forms.Padding(0, 0, 5, 0);
			this.panel6.Size = new global::System.Drawing.Size(200, 54);
			this.panel6.TabIndex = 38;
			this.tbHoldName.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbHoldName.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbHoldName.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbHoldName.Location = new global::System.Drawing.Point(0, 22);
			this.tbHoldName.Name = "tbHoldName";
			this.tbHoldName.ReadOnly = true;
			this.tbHoldName.Size = new global::System.Drawing.Size(195, 23);
			this.tbHoldName.TabIndex = 34;
			this.panel7.Controls.Add(this.label27);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(195, 22);
			this.panel7.TabIndex = 35;
			this.label27.AutoSize = true;
			this.label27.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.label27.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label27.Location = new global::System.Drawing.Point(0, 0);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(43, 17);
			this.label27.TabIndex = 31;
			this.label27.Text = "Name";
			this.panel4.Controls.Add(this.tbHoldTeam);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new global::System.Windows.Forms.Padding(5, 0, 5, 0);
			this.panel4.Size = new global::System.Drawing.Size(200, 54);
			this.panel4.TabIndex = 37;
			this.tbHoldTeam.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbHoldTeam.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbHoldTeam.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbHoldTeam.Location = new global::System.Drawing.Point(5, 22);
			this.tbHoldTeam.Name = "tbHoldTeam";
			this.tbHoldTeam.ReadOnly = true;
			this.tbHoldTeam.Size = new global::System.Drawing.Size(190, 23);
			this.tbHoldTeam.TabIndex = 34;
			this.panel5.Controls.Add(this.label28);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(5, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(190, 22);
			this.panel5.TabIndex = 35;
			this.label28.AutoSize = true;
			this.label28.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.label28.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label28.Location = new global::System.Drawing.Point(0, 0);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(77, 17);
			this.label28.TabIndex = 33;
			this.label28.Text = "Department";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(963, 445);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "HoldInfoForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Hold Information";
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000553 RID: 1363
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000554 RID: 1364
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000555 RID: 1365
		private global::System.Windows.Forms.Button btn_Cancle;

		// Token: 0x04000556 RID: 1366
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000557 RID: 1367
		private global::System.Windows.Forms.RichTextBox rbHoldComment;

		// Token: 0x04000558 RID: 1368
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000559 RID: 1369
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400055A RID: 1370
		private global::System.Windows.Forms.TextBox tbHoldTeam;

		// Token: 0x0400055B RID: 1371
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x0400055C RID: 1372
		private global::System.Windows.Forms.Label label28;

		// Token: 0x0400055D RID: 1373
		private global::System.Windows.Forms.Label label37;

		// Token: 0x0400055E RID: 1374
		private global::System.Windows.Forms.Label label27;

		// Token: 0x0400055F RID: 1375
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x04000560 RID: 1376
		private global::System.Windows.Forms.TextBox tbHoldTime;

		// Token: 0x04000561 RID: 1377
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000562 RID: 1378
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000563 RID: 1379
		private global::System.Windows.Forms.TextBox tbHoldName;

		// Token: 0x04000564 RID: 1380
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000565 RID: 1381
		private global::System.Windows.Forms.PictureBox pbCancel;
	}
}
