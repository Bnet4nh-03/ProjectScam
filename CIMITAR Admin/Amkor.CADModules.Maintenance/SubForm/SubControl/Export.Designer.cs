namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200003A RID: 58
	public partial class Export : global::System.Windows.Forms.Form
	{
		// Token: 0x060003A3 RID: 931 RVA: 0x0006D380 File Offset: 0x0006B580
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0006D3B8 File Offset: 0x0006B5B8
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radioButton3 = new global::System.Windows.Forms.RadioButton();
			this.radioButton1 = new global::System.Windows.Forms.RadioButton();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.lbTitle = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.radioButton3);
			this.panel1.Controls.Add(this.radioButton1);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(1, 0, 0, 0);
			this.panel1.Size = new global::System.Drawing.Size(222, 88);
			this.panel1.TabIndex = 0;
			this.radioButton3.AutoSize = true;
			this.radioButton3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.radioButton3.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.radioButton3.Location = new global::System.Drawing.Point(1, 44);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 1);
			this.radioButton3.Size = new global::System.Drawing.Size(221, 18);
			this.radioButton3.TabIndex = 3;
			this.radioButton3.TabStop = true;
			this.radioButton3.Tag = "1";
			this.radioButton3.Text = "HCC";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton1.AutoSize = true;
			this.radioButton1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.radioButton1.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.radioButton1.Location = new global::System.Drawing.Point(1, 26);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Padding = new global::System.Windows.Forms.Padding(3, 0, 0, 1);
			this.radioButton1.Size = new global::System.Drawing.Size(221, 18);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Tag = "0";
			this.radioButton1.Text = "General Category";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.panel3.Controls.Add(this.lbTitle);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(1, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(221, 26);
			this.panel3.TabIndex = 4;
			this.lbTitle.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.lbTitle.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.lbTitle.Location = new global::System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new global::System.Drawing.Size(221, 26);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Export Type";
			this.lbTitle.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 88);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(222, 26);
			this.panel2.TabIndex = 1;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.button2.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.button2.Location = new global::System.Drawing.Point(100, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(61, 26);
			this.button2.TabIndex = 17;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.button1.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.button1.Location = new global::System.Drawing.Point(161, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(61, 26);
			this.button1.TabIndex = 16;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click_1);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(222, 114);
			base.ControlBox = false;
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Export";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			base.TransparencyKey = global::System.Drawing.Color.Crimson;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040005D6 RID: 1494
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040005D7 RID: 1495
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040005D8 RID: 1496
		private global::System.Windows.Forms.RadioButton radioButton1;

		// Token: 0x040005D9 RID: 1497
		private global::System.Windows.Forms.RadioButton radioButton3;

		// Token: 0x040005DA RID: 1498
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040005DB RID: 1499
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040005DC RID: 1500
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040005DD RID: 1501
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040005DE RID: 1502
		private global::System.Windows.Forms.Label lbTitle;
	}
}
