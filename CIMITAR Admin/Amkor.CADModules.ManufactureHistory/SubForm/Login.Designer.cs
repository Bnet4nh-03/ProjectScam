namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x02000010 RID: 16
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00005B00 File Offset: 0x00003D00
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00005B38 File Offset: 0x00003D38
		private void InitializeComponent()
		{
			this.tbID = new global::System.Windows.Forms.TextBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.btnLogin = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.tbPassword = new global::System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.tbID.Location = new global::System.Drawing.Point(99, 12);
			this.tbID.Name = "tbID";
			this.tbID.Size = new global::System.Drawing.Size(100, 21);
			this.tbID.TabIndex = 0;
			this.groupBox1.Controls.Add(this.btnLogin);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbPassword);
			this.groupBox1.Controls.Add(this.tbID);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(302, 81);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.btnLogin.Location = new global::System.Drawing.Point(215, 11);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new global::System.Drawing.Size(75, 51);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new global::System.EventHandler(this.btnLogin_Click);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(9, 44);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(72, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "PASSWORD";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(65, 17);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(16, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "ID";
			this.tbPassword.Location = new global::System.Drawing.Point(99, 41);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new global::System.Drawing.Size(100, 21);
			this.tbPassword.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(302, 81);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Login";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "User Info";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400002B RID: 43
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.TextBox tbID;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Button btnLogin;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.TextBox tbPassword;
	}
}
