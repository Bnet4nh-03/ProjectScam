namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000020 RID: 32
	public partial class BIBoardInsert : global::System.Windows.Forms.Form
	{
		// Token: 0x0600008E RID: 142 RVA: 0x0000B547 File Offset: 0x00009747
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000B568 File Offset: 0x00009768
		private void InitializeComponent()
		{
			this.l_subject = new global::System.Windows.Forms.Label();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.combo_BIBGoldTab = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.btn_set = new global::System.Windows.Forms.Button();
			this.tb_CountOfSockets = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.l_barcode = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.l_location = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.l_customer = new global::System.Windows.Forms.Label();
			this.l_device = new global::System.Windows.Forms.Label();
			this.l_bib_No = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.grid_Socket_Indv = new global::SourceGrid.Grid();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.pb_Search_Bdno = new global::System.Windows.Forms.PictureBox();
			this.tb_biboardno = new global::System.Windows.Forms.TextBox();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.pb_Update = new global::System.Windows.Forms.PictureBox();
			this.combo_Warranty = new global::System.Windows.Forms.ComboBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.groupBox3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Search_Bdno).BeginInit();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).BeginInit();
			base.SuspendLayout();
			this.l_subject.AutoSize = true;
			this.l_subject.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l_subject.Location = new global::System.Drawing.Point(12, 8);
			this.l_subject.Name = "l_subject";
			this.l_subject.Size = new global::System.Drawing.Size(161, 21);
			this.l_subject.TabIndex = 22;
			this.l_subject.Text = "Burn In Board Insert";
			this.groupBox3.Controls.Add(this.combo_Warranty);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.combo_BIBGoldTab);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.btn_set);
			this.groupBox3.Controls.Add(this.tb_CountOfSockets);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.l_barcode);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.l_location);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.l_customer);
			this.groupBox3.Controls.Add(this.l_device);
			this.groupBox3.Controls.Add(this.l_bib_No);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox3.Location = new global::System.Drawing.Point(16, 118);
			this.groupBox3.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox3.Size = new global::System.Drawing.Size(939, 80);
			this.groupBox3.TabIndex = 25;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "BI Board Information";
			this.combo_BIBGoldTab.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_BIBGoldTab.FormattingEnabled = true;
			this.combo_BIBGoldTab.Location = new global::System.Drawing.Point(843, 19);
			this.combo_BIBGoldTab.Name = "combo_BIBGoldTab";
			this.combo_BIBGoldTab.Size = new global::System.Drawing.Size(55, 23);
			this.combo_BIBGoldTab.TabIndex = 30;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(720, 22);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(80, 15);
			this.label5.TabIndex = 29;
			this.label5.Text = "BIB Gold Tab :";
			this.btn_set.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btn_set.Location = new global::System.Drawing.Point(617, 43);
			this.btn_set.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btn_set.Name = "btn_set";
			this.btn_set.Size = new global::System.Drawing.Size(37, 25);
			this.btn_set.TabIndex = 28;
			this.btn_set.Text = "Set";
			this.btn_set.UseVisualStyleBackColor = true;
			this.btn_set.Click += new global::System.EventHandler(this.btn_set_Click);
			this.tb_CountOfSockets.Location = new global::System.Drawing.Point(560, 45);
			this.tb_CountOfSockets.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_CountOfSockets.Name = "tb_CountOfSockets";
			this.tb_CountOfSockets.Size = new global::System.Drawing.Size(51, 23);
			this.tb_CountOfSockets.TabIndex = 15;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(451, 48);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(103, 15);
			this.label2.TabIndex = 11;
			this.label2.Text = "Count of Sockets :";
			this.l_barcode.AutoSize = true;
			this.l_barcode.Location = new global::System.Drawing.Point(555, 22);
			this.l_barcode.Name = "l_barcode";
			this.l_barcode.Size = new global::System.Drawing.Size(79, 15);
			this.l_barcode.TabIndex = 10;
			this.l_barcode.Text = "ABBURN IN-7";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(451, 22);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 15);
			this.label7.TabIndex = 9;
			this.label7.Text = "Barcode :";
			this.l_location.AutoSize = true;
			this.l_location.Location = new global::System.Drawing.Point(308, 48);
			this.l_location.Name = "l_location";
			this.l_location.Size = new global::System.Drawing.Size(64, 15);
			this.l_location.TabIndex = 8;
			this.l_location.Text = "BURN IN-7";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(231, 48);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(59, 15);
			this.label6.TabIndex = 7;
			this.label6.Text = "Location :";
			this.l_customer.AutoSize = true;
			this.l_customer.Location = new global::System.Drawing.Point(308, 22);
			this.l_customer.Name = "l_customer";
			this.l_customer.Size = new global::System.Drawing.Size(77, 15);
			this.l_customer.TabIndex = 6;
			this.l_customer.Text = "QUALCOMM";
			this.l_device.AutoSize = true;
			this.l_device.Location = new global::System.Drawing.Point(84, 48);
			this.l_device.Name = "l_device";
			this.l_device.Size = new global::System.Drawing.Size(86, 15);
			this.l_device.TabIndex = 5;
			this.l_device.Text = "RADAGAST AU";
			this.l_bib_No.AutoSize = true;
			this.l_bib_No.Location = new global::System.Drawing.Point(84, 22);
			this.l_bib_No.Name = "l_bib_No";
			this.l_bib_No.Size = new global::System.Drawing.Size(38, 15);
			this.l_bib_No.TabIndex = 4;
			this.l_bib_No.Text = "#1029";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(231, 22);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(68, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Customer : ";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(23, 48);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(51, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Device : ";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(23, 22);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(44, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "BIB ID :";
			this.grid_Socket_Indv.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_Socket_Indv.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_Socket_Indv.EnableSort = true;
			this.grid_Socket_Indv.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_Socket_Indv.Location = new global::System.Drawing.Point(0, 0);
			this.grid_Socket_Indv.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_Socket_Indv.Name = "grid_Socket_Indv";
			this.grid_Socket_Indv.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_Socket_Indv.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_Socket_Indv.Size = new global::System.Drawing.Size(1306, 485);
			this.grid_Socket_Indv.TabIndex = 17;
			this.grid_Socket_Indv.TabStop = true;
			this.grid_Socket_Indv.ToolTipText = "";
			this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel1.Controls.Add(this.grid_Socket_Indv);
			this.panel1.Location = new global::System.Drawing.Point(16, 205);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1306, 485);
			this.panel1.TabIndex = 27;
			this.groupBox2.Controls.Add(this.pb_Search_Bdno);
			this.groupBox2.Controls.Add(this.tb_biboardno);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.groupBox2.Location = new global::System.Drawing.Point(16, 39);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Size = new global::System.Drawing.Size(219, 72);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "BI Board No";
			this.pb_Search_Bdno.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Search_Bdno.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.lothistory;
			this.pb_Search_Bdno.Location = new global::System.Drawing.Point(173, 27);
			this.pb_Search_Bdno.Name = "pb_Search_Bdno";
			this.pb_Search_Bdno.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Search_Bdno.TabIndex = 0;
			this.pb_Search_Bdno.TabStop = false;
			this.pb_Search_Bdno.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Search_Bdno_MouseUp);
			this.tb_biboardno.Location = new global::System.Drawing.Point(16, 32);
			this.tb_biboardno.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tb_biboardno.Name = "tb_biboardno";
			this.tb_biboardno.Size = new global::System.Drawing.Size(143, 23);
			this.tb_biboardno.TabIndex = 12;
			this.tb_biboardno.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tb_biboardno_KeyPress);
			this.groupBox4.Controls.Add(this.pb_Update);
			this.groupBox4.Location = new global::System.Drawing.Point(241, 39);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(74, 72);
			this.groupBox4.TabIndex = 29;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Update";
			this.pb_Update.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_Update.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_Update.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.TableSave;
			this.pb_Update.Location = new global::System.Drawing.Point(21, 24);
			this.pb_Update.Name = "pb_Update";
			this.pb_Update.Size = new global::System.Drawing.Size(32, 33);
			this.pb_Update.TabIndex = 0;
			this.pb_Update.TabStop = false;
			this.pb_Update.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_Update_MouseDown);
			this.pb_Update.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_Update_MouseUp);
			this.combo_Warranty.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Warranty.FormattingEnabled = true;
			this.combo_Warranty.Location = new global::System.Drawing.Point(843, 45);
			this.combo_Warranty.Name = "combo_Warranty";
			this.combo_Warranty.Size = new global::System.Drawing.Size(55, 23);
			this.combo_Warranty.TabIndex = 32;
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(720, 48);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(61, 15);
			this.label8.TabIndex = 31;
			this.label8.Text = "Warranty :";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1334, 702);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.l_subject);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "BIBoardInsert";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BIBoardSocketInfo";
			base.Load += new global::System.EventHandler(this.BIBoardInsert_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.BIBoardInsert_KeyDown);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_Search_Bdno).EndInit();
			this.groupBox4.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_Update).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000FC RID: 252
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.Label l_subject;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.Label l_barcode;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.Label l_location;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.Label l_customer;

		// Token: 0x04000104 RID: 260
		private global::System.Windows.Forms.Label l_device;

		// Token: 0x04000105 RID: 261
		private global::System.Windows.Forms.Label l_bib_No;

		// Token: 0x04000106 RID: 262
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400010A RID: 266
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.TextBox tb_biboardno;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.Button btn_set;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.TextBox tb_CountOfSockets;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400010F RID: 271
		private global::SourceGrid.Grid grid_Socket_Indv;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.PictureBox pb_Search_Bdno;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.PictureBox pb_Update;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.ComboBox combo_BIBGoldTab;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.ComboBox combo_Warranty;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.Label label8;
	}
}
