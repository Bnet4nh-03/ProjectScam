namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000025 RID: 37
	public partial class CheckBadgeNo : global::System.Windows.Forms.Form
	{
		// Token: 0x060000DB RID: 219 RVA: 0x000137B9 File Offset: 0x000119B9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000137D8 File Offset: 0x000119D8
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.btn_Confirm = new global::System.Windows.Forms.Button();
			this.rtb_Comment = new global::System.Windows.Forms.RichTextBox();
			this.tb_BadgeNo = new global::System.Windows.Forms.TextBox();
			this.lbl_Comment = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.btn_Confirm);
			this.groupBox1.Controls.Add(this.rtb_Comment);
			this.groupBox1.Controls.Add(this.tb_BadgeNo);
			this.groupBox1.Controls.Add(this.lbl_Comment);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Size = new global::System.Drawing.Size(305, 158);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User Information";
			this.btn_Confirm.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_Confirm.Location = new global::System.Drawing.Point(212, 127);
			this.btn_Confirm.Name = "btn_Confirm";
			this.btn_Confirm.Size = new global::System.Drawing.Size(75, 23);
			this.btn_Confirm.TabIndex = 4;
			this.btn_Confirm.Text = "Confirm";
			this.btn_Confirm.UseVisualStyleBackColor = true;
			this.btn_Confirm.Click += new global::System.EventHandler(this.btn_Confirm_Click);
			this.rtb_Comment.Location = new global::System.Drawing.Point(113, 48);
			this.rtb_Comment.Name = "rtb_Comment";
			this.rtb_Comment.Size = new global::System.Drawing.Size(174, 73);
			this.rtb_Comment.TabIndex = 3;
			this.rtb_Comment.Text = "";
			this.tb_BadgeNo.BackColor = global::System.Drawing.Color.White;
			this.tb_BadgeNo.Location = new global::System.Drawing.Point(113, 18);
			this.tb_BadgeNo.Name = "tb_BadgeNo";
			this.tb_BadgeNo.Size = new global::System.Drawing.Size(174, 23);
			this.tb_BadgeNo.TabIndex = 2;
			this.lbl_Comment.AutoSize = true;
			this.lbl_Comment.Location = new global::System.Drawing.Point(14, 48);
			this.lbl_Comment.Name = "lbl_Comment";
			this.lbl_Comment.Size = new global::System.Drawing.Size(67, 15);
			this.lbl_Comment.TabIndex = 1;
			this.lbl_Comment.Text = "Comment :";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(14, 21);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(93, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Badge Number :";
			base.AcceptButton = this.btn_Confirm;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(311, 164);
			base.Controls.Add(this.groupBox1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "CheckBadgeNo";
			base.Padding = new global::System.Windows.Forms.Padding(3);
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CheckBadgeNo";
			base.Load += new global::System.EventHandler(this.CheckBadgeNo_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.CheckBadgeNo_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000197 RID: 407
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000198 RID: 408
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000199 RID: 409
		private global::System.Windows.Forms.RichTextBox rtb_Comment;

		// Token: 0x0400019A RID: 410
		private global::System.Windows.Forms.TextBox tb_BadgeNo;

		// Token: 0x0400019B RID: 411
		private global::System.Windows.Forms.Label lbl_Comment;

		// Token: 0x0400019C RID: 412
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400019D RID: 413
		private global::System.Windows.Forms.Button btn_Confirm;
	}
}
