namespace Amkor.CADModules.HccRepHisModule.SubForms
{
	// Token: 0x0200000A RID: 10
	public partial class InsertHistory : global::System.Windows.Forms.Form
	{
		// Token: 0x06000051 RID: 81 RVA: 0x00004E95 File Offset: 0x00003095
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004EB4 File Offset: 0x000030B4
		private void InitializeComponent()
		{
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.combo_HwType = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.tb_Barcode = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.tb_SerialNo = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.l_subject = new global::System.Windows.Forms.Label();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.pb_Insert = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.pb_Search = new global::System.Windows.Forms.PictureBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.tb_Device = new global::System.Windows.Forms.TextBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.l_SerialNo = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.tb_DefectedSite = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.tb_CustCode = new global::System.Windows.Forms.TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.tb_Action = new global::System.Windows.Forms.TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.tb_ProbDesc = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.l_NumOfSites = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.l_barcode = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.l_customer = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Insert).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Search).BeginInit();
			this.groupBox4.SuspendLayout();
			base.SuspendLayout();
			this.groupBox2.Controls.Add(this.combo_HwType);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.tb_Barcode);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.tb_SerialNo);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox2.Location = new global::System.Drawing.Point(16, 34);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Size = new global::System.Drawing.Size(418, 81);
			this.groupBox2.TabIndex = 38;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Search Condition";
			this.combo_HwType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_HwType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.combo_HwType.FormattingEnabled = true;
			this.combo_HwType.Location = new global::System.Drawing.Point(19, 41);
			this.combo_HwType.Name = "combo_HwType";
			this.combo_HwType.Size = new global::System.Drawing.Size(143, 23);
			this.combo_HwType.TabIndex = 53;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(16, 23);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(61, 15);
			this.label1.TabIndex = 52;
			this.label1.Text = "HW Type :";
			this.tb_Barcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tb_Barcode.Location = new global::System.Drawing.Point(268, 41);
			this.tb_Barcode.Name = "tb_Barcode";
			this.tb_Barcode.Size = new global::System.Drawing.Size(130, 23);
			this.tb_Barcode.TabIndex = 51;
			this.tb_Barcode.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tb_Barcode_KeyDown);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(265, 23);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(56, 15);
			this.label3.TabIndex = 50;
			this.label3.Text = "Barcode :";
			this.tb_SerialNo.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tb_SerialNo.Location = new global::System.Drawing.Point(168, 41);
			this.tb_SerialNo.Name = "tb_SerialNo";
			this.tb_SerialNo.Size = new global::System.Drawing.Size(91, 23);
			this.tb_SerialNo.TabIndex = 49;
			this.tb_SerialNo.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tb_SerialNo_KeyDown);
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(165, 23);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(33, 15);
			this.label6.TabIndex = 48;
			this.label6.Text = "S/N :";
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 8);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(155, 21);
			this.l_subject.TabIndex = 39;
			this.l_subject.Text = "HCC Repair History";
			this.groupBox3.Controls.Add(this.pb_Insert);
			this.groupBox3.Location = new global::System.Drawing.Point(773, 34);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(74, 81);
			this.groupBox3.TabIndex = 42;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Insert";
			this.pb_Insert.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Insert.Image = global::Amkor.CADModules.HccRepHisModule.Properties.Resources.TableSave;
			this.pb_Insert.InitialImage = global::Amkor.CADModules.HccRepHisModule.Properties.Resources.TableSave;
			this.pb_Insert.Location = new global::System.Drawing.Point(21, 29);
			this.pb_Insert.Name = "pb_Insert";
			this.pb_Insert.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Insert.TabIndex = 0;
			this.pb_Insert.TabStop = false;
			this.pb_Insert.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Insert_MouseDown);
			this.pb_Insert.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Insert_MouseUp);
			this.groupBox1.Controls.Add(this.pb_Search);
			this.groupBox1.Location = new global::System.Drawing.Point(440, 34);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(74, 81);
			this.groupBox1.TabIndex = 41;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.pb_Search.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Search.Image = global::Amkor.CADModules.HccRepHisModule.Properties.Resources.TableSearch;
			this.pb_Search.InitialImage = global::Amkor.CADModules.HccRepHisModule.Properties.Resources.TableSearch;
			this.pb_Search.Location = new global::System.Drawing.Point(21, 29);
			this.pb_Search.Name = "pb_Search";
			this.pb_Search.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Search.TabIndex = 0;
			this.pb_Search.TabStop = false;
			this.pb_Search.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Search_MouseDown);
			this.pb_Search.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Search_MouseUp);
			this.groupBox4.Controls.Add(this.tb_Device);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.l_SerialNo);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.tb_DefectedSite);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.tb_CustCode);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.tb_Action);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.tb_ProbDesc);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.l_NumOfSites);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.l_barcode);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.l_customer);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox4.Location = new global::System.Drawing.Point(16, 124);
			this.groupBox4.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Size = new global::System.Drawing.Size(831, 167);
			this.groupBox4.TabIndex = 43;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Hardware Information";
			this.tb_Device.Location = new global::System.Drawing.Point(119, 76);
			this.tb_Device.Name = "tb_Device";
			this.tb_Device.Size = new global::System.Drawing.Size(686, 23);
			this.tb_Device.TabIndex = 62;
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(23, 76);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(90, 15);
			this.label13.TabIndex = 61;
			this.label13.Text = "Board(Device) : ";
			this.l_SerialNo.AutoSize = true;
			this.l_SerialNo.Location = new global::System.Drawing.Point(100, 47);
			this.l_SerialNo.Name = "l_SerialNo";
			this.l_SerialNo.Size = new global::System.Drawing.Size(38, 15);
			this.l_SerialNo.TabIndex = 60;
			this.l_SerialNo.Text = "#1019";
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(23, 47);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(60, 15);
			this.label12.TabIndex = 59;
			this.label12.Text = "Serial No :";
			this.tb_DefectedSite.Location = new global::System.Drawing.Point(536, 44);
			this.tb_DefectedSite.Name = "tb_DefectedSite";
			this.tb_DefectedSite.Size = new global::System.Drawing.Size(91, 23);
			this.tb_DefectedSite.TabIndex = 58;
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(437, 47);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(85, 15);
			this.label10.TabIndex = 57;
			this.label10.Text = "Defected Site : ";
			this.tb_CustCode.Location = new global::System.Drawing.Point(322, 44);
			this.tb_CustCode.Name = "tb_CustCode";
			this.tb_CustCode.Size = new global::System.Drawing.Size(91, 23);
			this.tb_CustCode.TabIndex = 56;
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(231, 47);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(71, 15);
			this.label11.TabIndex = 55;
			this.label11.Text = "Cust Code : ";
			this.tb_Action.Location = new global::System.Drawing.Point(119, 128);
			this.tb_Action.Name = "tb_Action";
			this.tb_Action.Size = new global::System.Drawing.Size(686, 23);
			this.tb_Action.TabIndex = 54;
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(23, 131);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(48, 15);
			this.label8.TabIndex = 53;
			this.label8.Text = "Action :";
			this.tb_ProbDesc.Location = new global::System.Drawing.Point(119, 102);
			this.tb_ProbDesc.Name = "tb_ProbDesc";
			this.tb_ProbDesc.Size = new global::System.Drawing.Size(686, 23);
			this.tb_ProbDesc.TabIndex = 52;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(23, 105);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(66, 15);
			this.label5.TabIndex = 13;
			this.label5.Text = "Prob Desc :";
			this.l_NumOfSites.AutoSize = true;
			this.l_NumOfSites.Location = new global::System.Drawing.Point(533, 22);
			this.l_NumOfSites.Name = "l_NumOfSites";
			this.l_NumOfSites.Size = new global::System.Drawing.Size(19, 15);
			this.l_NumOfSites.TabIndex = 12;
			this.l_NumOfSites.Text = "12";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(437, 22);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(84, 15);
			this.label2.TabIndex = 11;
			this.label2.Text = "Num of Sites : ";
			this.l_barcode.AutoSize = true;
			this.l_barcode.Location = new global::System.Drawing.Point(319, 22);
			this.l_barcode.Name = "l_barcode";
			this.l_barcode.Size = new global::System.Drawing.Size(79, 15);
			this.l_barcode.TabIndex = 10;
			this.l_barcode.Text = "ABBURN IN-7";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(231, 22);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 15);
			this.label7.TabIndex = 9;
			this.label7.Text = "Barcode :";
			this.l_customer.AutoSize = true;
			this.l_customer.Location = new global::System.Drawing.Point(100, 22);
			this.l_customer.Name = "l_customer";
			this.l_customer.Size = new global::System.Drawing.Size(77, 15);
			this.l_customer.TabIndex = 6;
			this.l_customer.Text = "QUALCOMM";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(23, 22);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(68, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Customer : ";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(867, 311);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.l_subject);
			base.Controls.Add(this.groupBox2);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "InsertHistory";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "InsertHistory";
			base.Load += new global::System.EventHandler(this.InsertHistory_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.InsertHistory_KeyDown);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Insert).EndInit();
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Search).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000033 RID: 51
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.TextBox tb_SerialNo;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.PictureBox pb_Insert;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.PictureBox pb_Search;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.Label l_barcode;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.Label l_customer;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.Label l_NumOfSites;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.TextBox tb_Barcode;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.TextBox tb_Action;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.TextBox tb_ProbDesc;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.TextBox tb_DefectedSite;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.TextBox tb_CustCode;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.Label label11;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Label l_SerialNo;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.ComboBox combo_HwType;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.TextBox tb_Device;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.Label label13;
	}
}
