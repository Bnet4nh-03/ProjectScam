namespace Amkor.CADModules.ESIModule.View
{
	// Token: 0x0200002F RID: 47
	public partial class CommentForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600016C RID: 364 RVA: 0x00024DB0 File Offset: 0x00022FB0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00024DD0 File Offset: 0x00022FD0
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.tbComment = new global::System.Windows.Forms.TextBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnApply = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.tbComment);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(852, 281);
			this.panel1.TabIndex = 1;
			this.tbComment.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbComment.Location = new global::System.Drawing.Point(0, 68);
			this.tbComment.Multiline = true;
			this.tbComment.Name = "tbComment";
			this.tbComment.Size = new global::System.Drawing.Size(852, 213);
			this.tbComment.TabIndex = 4;
			this.panel2.BackColor = global::System.Drawing.Color.White;
			this.panel2.Controls.Add(this.btnApply);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(852, 68);
			this.panel2.TabIndex = 3;
			this.btnApply.BackColor = global::System.Drawing.Color.White;
			this.btnApply.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnApply.Location = new global::System.Drawing.Point(735, 14);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new global::System.Drawing.Size(105, 44);
			this.btnApply.TabIndex = 116;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = false;
			this.btnApply.Click += new global::System.EventHandler(this.btnApply_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(3, 22);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(99, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Comment";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(852, 281);
			base.Controls.Add(this.panel1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "CommentForm";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000270 RID: 624
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.TextBox tbComment;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.Button btnApply;
	}
}
