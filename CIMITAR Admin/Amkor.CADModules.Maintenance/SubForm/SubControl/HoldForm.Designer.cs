namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000033 RID: 51
	public partial class HoldForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600033B RID: 827 RVA: 0x00066064 File Offset: 0x00064264
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0006609C File Offset: 0x0006429C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.Maintenance.SubForm.SubControl.HoldForm));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pbHold = new global::System.Windows.Forms.PictureBox();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.pbCancel = new global::System.Windows.Forms.PictureBox();
			this.btn_OK = new global::System.Windows.Forms.Button();
			this.btn_Cancle = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.rbHoldComment = new global::System.Windows.Forms.RichTextBox();
			this.rb_HoldComment = new global::System.Windows.Forms.RichTextBox();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbHold).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).BeginInit();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.pbHold);
			this.panel1.Controls.Add(this.panel18);
			this.panel1.Controls.Add(this.pbCancel);
			this.panel1.Controls.Add(this.btn_OK);
			this.panel1.Controls.Add(this.btn_Cancle);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 397);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(963, 48);
			this.panel1.TabIndex = 1;
			this.pbHold.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbHold.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbHold.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.hold;
			this.pbHold.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbHold.Location = new global::System.Drawing.Point(544, 0);
			this.pbHold.Name = "pbHold";
			this.pbHold.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbHold.Size = new global::System.Drawing.Size(48, 48);
			this.pbHold.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbHold.TabIndex = 48;
			this.pbHold.TabStop = false;
			this.pbHold.Click += new global::System.EventHandler(this.pbHold_Click);
			this.pbHold.MouseEnter += new global::System.EventHandler(this.pbHold_MouseEnter);
			this.pbHold.MouseLeave += new global::System.EventHandler(this.pbHold_MouseLeave);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel18.Location = new global::System.Drawing.Point(592, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(23, 48);
			this.panel18.TabIndex = 47;
			this.pbCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbCancel.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbCancel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.Location = new global::System.Drawing.Point(615, 0);
			this.pbCancel.Name = "pbCancel";
			this.pbCancel.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbCancel.Size = new global::System.Drawing.Size(48, 48);
			this.pbCancel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbCancel.TabIndex = 46;
			this.pbCancel.TabStop = false;
			this.pbCancel.Click += new global::System.EventHandler(this.pbCancel_Click);
			this.pbCancel.MouseEnter += new global::System.EventHandler(this.pbCancel_MouseEnter);
			this.pbCancel.MouseLeave += new global::System.EventHandler(this.pbCancel_MouseLeave);
			this.btn_OK.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btn_OK.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btn_OK.Location = new global::System.Drawing.Point(663, 0);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new global::System.Drawing.Size(150, 48);
			this.btn_OK.TabIndex = 0;
			this.btn_OK.Text = "Hold";
			this.btn_OK.UseVisualStyleBackColor = true;
			this.btn_OK.Visible = false;
			this.btn_OK.Click += new global::System.EventHandler(this.btn_OK_Click);
			this.btn_Cancle.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btn_Cancle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btn_Cancle.Location = new global::System.Drawing.Point(813, 0);
			this.btn_Cancle.Name = "btn_Cancle";
			this.btn_Cancle.Size = new global::System.Drawing.Size(150, 48);
			this.btn_Cancle.TabIndex = 1;
			this.btn_Cancle.Text = "Cancel";
			this.btn_Cancle.UseVisualStyleBackColor = true;
			this.btn_Cancle.Visible = false;
			this.btn_Cancle.Click += new global::System.EventHandler(this.btn_Cancle_Click);
			this.panel2.Controls.Add(this.rbHoldComment);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(963, 181);
			this.panel2.TabIndex = 2;
			this.rbHoldComment.BackColor = global::System.Drawing.Color.LightGray;
			this.rbHoldComment.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.rbHoldComment.Font = new global::System.Drawing.Font("휴먼엑스포", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rbHoldComment.Location = new global::System.Drawing.Point(0, 0);
			this.rbHoldComment.Name = "rbHoldComment";
			this.rbHoldComment.ReadOnly = true;
			this.rbHoldComment.Size = new global::System.Drawing.Size(963, 181);
			this.rbHoldComment.TabIndex = 1;
			this.rbHoldComment.Text = componentResourceManager.GetString("rbHoldComment.Text");
			this.rb_HoldComment.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.rb_HoldComment.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rb_HoldComment.Location = new global::System.Drawing.Point(0, 181);
			this.rb_HoldComment.Name = "rb_HoldComment";
			this.rb_HoldComment.Size = new global::System.Drawing.Size(963, 216);
			this.rb_HoldComment.TabIndex = 65;
			this.rb_HoldComment.Text = "※Hold 사유 및 Release(조치 후 정상화) 시점을 가능한 구체적으로 명시해 주시기 바랍니다.";
			this.rb_HoldComment.Click += new global::System.EventHandler(this.rb_HoldComment_Click);
			this.rb_HoldComment.TextChanged += new global::System.EventHandler(this.rb_HoldComment_TextChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(963, 445);
			base.Controls.Add(this.rb_HoldComment);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "HoldForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Hold";
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbHold).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).EndInit();
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000567 RID: 1383
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000568 RID: 1384
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000569 RID: 1385
		private global::System.Windows.Forms.Button btn_OK;

		// Token: 0x0400056A RID: 1386
		private global::System.Windows.Forms.Button btn_Cancle;

		// Token: 0x0400056B RID: 1387
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400056C RID: 1388
		private global::System.Windows.Forms.RichTextBox rbHoldComment;

		// Token: 0x0400056D RID: 1389
		private global::System.Windows.Forms.RichTextBox rb_HoldComment;

		// Token: 0x0400056E RID: 1390
		private global::System.Windows.Forms.PictureBox pbHold;

		// Token: 0x0400056F RID: 1391
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000570 RID: 1392
		private global::System.Windows.Forms.PictureBox pbCancel;
	}
}
