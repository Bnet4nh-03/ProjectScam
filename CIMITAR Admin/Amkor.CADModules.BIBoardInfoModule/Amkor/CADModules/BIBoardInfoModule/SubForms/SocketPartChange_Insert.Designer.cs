namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000029 RID: 41
	public partial class SocketPartChange_Insert : global::System.Windows.Forms.Form
	{
		// Token: 0x06000121 RID: 289 RVA: 0x000186ED File Offset: 0x000168ED
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0001870C File Offset: 0x0001690C
		private void InitializeComponent()
		{
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.tb_DateIn = new global::System.Windows.Forms.TextBox();
			this.pb_Check = new global::System.Windows.Forms.PictureBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.tb_RepairTime = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tb_SocketBarcode = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.combo_Category = new global::System.Windows.Forms.ComboBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.tb_SocketNo = new global::System.Windows.Forms.TextBox();
			this.group_Update = new global::System.Windows.Forms.GroupBox();
			this.pb_Update = new global::System.Windows.Forms.PictureBox();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Check).BeginInit();
			this.group_Update.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).BeginInit();
			base.SuspendLayout();
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.tb_DateIn);
			this.groupBox2.Controls.Add(this.pb_Check);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.tb_RepairTime);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.tb_SocketBarcode);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.combo_Category);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.tb_SocketNo);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 14);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Size = new global::System.Drawing.Size(309, 162);
			this.groupBox2.TabIndex = 30;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Part Info";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(12, 129);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(50, 15);
			this.label4.TabIndex = 148;
			this.label4.Text = "In Date :";
			this.tb_DateIn.Location = new global::System.Drawing.Point(115, 126);
			this.tb_DateIn.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_DateIn.Name = "tb_DateIn";
			this.tb_DateIn.Size = new global::System.Drawing.Size(176, 23);
			this.tb_DateIn.TabIndex = 147;
			this.pb_Check.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Check.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.Cancel;
			this.pb_Check.Location = new global::System.Drawing.Point(275, 77);
			this.pb_Check.Name = "pb_Check";
			this.pb_Check.Size = new global::System.Drawing.Size(16, 17);
			this.pb_Check.TabIndex = 146;
			this.pb_Check.TabStop = false;
			this.pb_Check.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Check_MouseUp);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(12, 103);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(94, 15);
			this.label3.TabIndex = 40;
			this.label3.Text = "Repair Time(m) :";
			this.tb_RepairTime.Location = new global::System.Drawing.Point(115, 100);
			this.tb_RepairTime.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_RepairTime.Name = "tb_RepairTime";
			this.tb_RepairTime.Size = new global::System.Drawing.Size(176, 23);
			this.tb_RepairTime.TabIndex = 39;
			this.tb_RepairTime.Text = "20";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 77);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(94, 15);
			this.label2.TabIndex = 38;
			this.label2.Text = "Socket Barcode :";
			this.tb_SocketBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tb_SocketBarcode.Location = new global::System.Drawing.Point(115, 74);
			this.tb_SocketBarcode.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_SocketBarcode.Name = "tb_SocketBarcode";
			this.tb_SocketBarcode.Size = new global::System.Drawing.Size(154, 23);
			this.tb_SocketBarcode.TabIndex = 37;
			this.tb_SocketBarcode.TextChanged += new global::System.EventHandler(this.tb_SocketBarcode_TextChanged);
			this.tb_SocketBarcode.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tb_SocketBarcode_KeyDown);
			this.tb_SocketBarcode.Leave += new global::System.EventHandler(this.tb_SocketBarcode_Leave);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 25);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(58, 15);
			this.label1.TabIndex = 36;
			this.label1.Text = "Socket # :";
			this.combo_Category.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Category.FormattingEnabled = true;
			this.combo_Category.Location = new global::System.Drawing.Point(115, 48);
			this.combo_Category.Name = "combo_Category";
			this.combo_Category.Size = new global::System.Drawing.Size(176, 23);
			this.combo_Category.TabIndex = 35;
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(12, 51);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(64, 15);
			this.label9.TabIndex = 34;
			this.label9.Text = "Category : ";
			this.tb_SocketNo.Location = new global::System.Drawing.Point(115, 22);
			this.tb_SocketNo.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_SocketNo.Name = "tb_SocketNo";
			this.tb_SocketNo.Size = new global::System.Drawing.Size(176, 23);
			this.tb_SocketNo.TabIndex = 12;
			this.group_Update.Controls.Add(this.pb_Update);
			this.group_Update.Location = new global::System.Drawing.Point(327, 14);
			this.group_Update.Name = "group_Update";
			this.group_Update.Size = new global::System.Drawing.Size(74, 80);
			this.group_Update.TabIndex = 31;
			this.group_Update.TabStop = false;
			this.group_Update.Text = "Update";
			this.pb_Update.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Update.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_Update.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_Update.Location = new global::System.Drawing.Point(21, 28);
			this.pb_Update.Name = "pb_Update";
			this.pb_Update.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Update.TabIndex = 0;
			this.pb_Update.TabStop = false;
			this.pb_Update.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Update_MouseDown);
			this.pb_Update.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Update_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(416, 190);
			base.Controls.Add(this.group_Update);
			base.Controls.Add(this.groupBox2);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "SocketPartChange_Insert";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SocketPartChange_Insert";
			base.Load += new global::System.EventHandler(this.SocketPartChange_Insert_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.SocketPartChange_Insert_KeyDown);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Check).EndInit();
			this.group_Update.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040001E7 RID: 487
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.TextBox tb_SocketNo;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.TextBox tb_RepairTime;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.TextBox tb_SocketBarcode;

		// Token: 0x040001EE RID: 494
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040001EF RID: 495
		private global::System.Windows.Forms.ComboBox combo_Category;

		// Token: 0x040001F0 RID: 496
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040001F1 RID: 497
		private global::System.Windows.Forms.GroupBox group_Update;

		// Token: 0x040001F2 RID: 498
		private global::System.Windows.Forms.PictureBox pb_Update;

		// Token: 0x040001F3 RID: 499
		private global::System.Windows.Forms.PictureBox pb_Check;

		// Token: 0x040001F4 RID: 500
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040001F5 RID: 501
		private global::System.Windows.Forms.TextBox tb_DateIn;
	}
}
