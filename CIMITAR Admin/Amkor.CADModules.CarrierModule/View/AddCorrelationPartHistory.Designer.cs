namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000039 RID: 57
	public partial class AddCorrelationPartHistory : global::System.Windows.Forms.Form
	{
		// Token: 0x06000290 RID: 656 RVA: 0x00046961 File Offset: 0x00044B61
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00046980 File Offset: 0x00044B80
		private void InitializeComponent()
		{
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.cmdApply = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.txtConfirmUser = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.txtCheckQty = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtQty = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.txtProdRemark = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtProduct = new global::System.Windows.Forms.TextBox();
			this.txtComment = new global::System.Windows.Forms.TextBox();
			this.dtpConfirmDate = new global::System.Windows.Forms.DateTimePicker();
			this.label43 = new global::System.Windows.Forms.Label();
			this.label44 = new global::System.Windows.Forms.Label();
			this.txtBarcode = new global::System.Windows.Forms.TextBox();
			this.label46 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(548, 44);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(120, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Add History";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 447);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(548, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(150, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(237, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdApply.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdApply.Location = new global::System.Drawing.Point(464, 9);
			this.cmdApply.Name = "cmdApply";
			this.cmdApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmdApply.TabIndex = 24;
			this.cmdApply.TabStop = false;
			this.cmdApply.Click += new global::System.EventHandler(this.cmdApply_Click);
			this.cmdApply.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseDown);
			this.cmdApply.MouseLeave += new global::System.EventHandler(this.cmdApply_MouseLeave);
			this.cmdApply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseMove);
			this.cmdApply.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseUp);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.txtConfirmUser);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.txtCheckQty);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtQty);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtProdRemark);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtProduct);
			this.panel1.Controls.Add(this.txtComment);
			this.panel1.Controls.Add(this.dtpConfirmDate);
			this.panel1.Controls.Add(this.label43);
			this.panel1.Controls.Add(this.label44);
			this.panel1.Controls.Add(this.txtBarcode);
			this.panel1.Controls.Add(this.label46);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 44);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel1.Size = new global::System.Drawing.Size(548, 352);
			this.panel1.TabIndex = 29;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label5.Location = new global::System.Drawing.Point(10, 145);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(77, 15);
			this.label5.TabIndex = 108;
			this.label5.Text = "Confirm User";
			this.txtConfirmUser.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtConfirmUser.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtConfirmUser.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtConfirmUser.Location = new global::System.Drawing.Point(94, 142);
			this.txtConfirmUser.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtConfirmUser.Name = "txtConfirmUser";
			this.txtConfirmUser.ReadOnly = true;
			this.txtConfirmUser.Size = new global::System.Drawing.Size(445, 23);
			this.txtConfirmUser.TabIndex = 107;
			this.txtConfirmUser.TextChanged += new global::System.EventHandler(this.textBox5_TextChanged);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label4.Location = new global::System.Drawing.Point(271, 114);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(62, 15);
			this.label4.TabIndex = 106;
			this.label4.Text = "Check Qty";
			this.txtCheckQty.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtCheckQty.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtCheckQty.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtCheckQty.Location = new global::System.Drawing.Point(339, 111);
			this.txtCheckQty.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtCheckQty.Name = "txtCheckQty";
			this.txtCheckQty.Size = new global::System.Drawing.Size(200, 23);
			this.txtCheckQty.TabIndex = 105;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label3.Location = new global::System.Drawing.Point(10, 114);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(26, 15);
			this.label3.TabIndex = 104;
			this.label3.Text = "Qty";
			this.txtQty.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtQty.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtQty.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtQty.Location = new global::System.Drawing.Point(94, 111);
			this.txtQty.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtQty.Name = "txtQty";
			this.txtQty.Size = new global::System.Drawing.Size(171, 23);
			this.txtQty.TabIndex = 103;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label2.Location = new global::System.Drawing.Point(10, 83);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(75, 15);
			this.label2.TabIndex = 102;
			this.label2.Text = "Prod Remark";
			this.txtProdRemark.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtProdRemark.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtProdRemark.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtProdRemark.Location = new global::System.Drawing.Point(94, 80);
			this.txtProdRemark.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtProdRemark.Name = "txtProdRemark";
			this.txtProdRemark.ReadOnly = true;
			this.txtProdRemark.Size = new global::System.Drawing.Size(445, 23);
			this.txtProdRemark.TabIndex = 101;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label1.Location = new global::System.Drawing.Point(10, 52);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(63, 15);
			this.label1.TabIndex = 100;
			this.label1.Text = "NickName";
			this.txtProduct.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtProduct.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtProduct.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtProduct.Location = new global::System.Drawing.Point(94, 49);
			this.txtProduct.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtProduct.Name = "txtProduct";
			this.txtProduct.ReadOnly = true;
			this.txtProduct.Size = new global::System.Drawing.Size(445, 23);
			this.txtProduct.TabIndex = 99;
			this.txtComment.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtComment.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtComment.Location = new global::System.Drawing.Point(94, 202);
			this.txtComment.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new global::System.Drawing.Size(448, 143);
			this.txtComment.TabIndex = 98;
			this.dtpConfirmDate.CustomFormat = "yyyy-MM-dd";
			this.dtpConfirmDate.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.dtpConfirmDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpConfirmDate.Location = new global::System.Drawing.Point(94, 172);
			this.dtpConfirmDate.Name = "dtpConfirmDate";
			this.dtpConfirmDate.Size = new global::System.Drawing.Size(152, 23);
			this.dtpConfirmDate.TabIndex = 96;
			this.label43.AutoSize = true;
			this.label43.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label43.Location = new global::System.Drawing.Point(10, 21);
			this.label43.Name = "label43";
			this.label43.Size = new global::System.Drawing.Size(50, 15);
			this.label43.TabIndex = 95;
			this.label43.Text = "Barcode";
			this.label44.AutoSize = true;
			this.label44.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label44.Location = new global::System.Drawing.Point(10, 208);
			this.label44.Name = "label44";
			this.label44.Size = new global::System.Drawing.Size(61, 15);
			this.label44.TabIndex = 92;
			this.label44.Text = "Comment";
			this.txtBarcode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtBarcode.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtBarcode.ImeMode = global::System.Windows.Forms.ImeMode.Alpha;
			this.txtBarcode.Location = new global::System.Drawing.Point(94, 18);
			this.txtBarcode.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new global::System.Drawing.Size(445, 23);
			this.txtBarcode.TabIndex = 91;
			this.label46.AutoSize = true;
			this.label46.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label46.Location = new global::System.Drawing.Point(10, 178);
			this.label46.Name = "label46";
			this.label46.Size = new global::System.Drawing.Size(78, 15);
			this.label46.TabIndex = 93;
			this.label46.Text = "Confirm Date";
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.cmdClose);
			this.panel2.Controls.Add(this.cmdApply);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 396);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(548, 51);
			this.panel2.TabIndex = 30;
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(502, 9);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 98;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(548, 479);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "AddCorrelationPartHistory";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Correlation Part History";
			base.Load += new global::System.EventHandler(this.AddSWHistory_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000480 RID: 1152
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000481 RID: 1153
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000482 RID: 1154
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x04000483 RID: 1155
		private global::System.Windows.Forms.PictureBox cmdApply;

		// Token: 0x04000484 RID: 1156
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000485 RID: 1157
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000486 RID: 1158
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000487 RID: 1159
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000488 RID: 1160
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x04000489 RID: 1161
		private global::System.Windows.Forms.TextBox txtComment;

		// Token: 0x0400048A RID: 1162
		private global::System.Windows.Forms.DateTimePicker dtpConfirmDate;

		// Token: 0x0400048B RID: 1163
		private global::System.Windows.Forms.Label label43;

		// Token: 0x0400048C RID: 1164
		private global::System.Windows.Forms.Label label44;

		// Token: 0x0400048D RID: 1165
		private global::System.Windows.Forms.TextBox txtBarcode;

		// Token: 0x0400048E RID: 1166
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400048F RID: 1167
		private global::System.Windows.Forms.TextBox txtCheckQty;

		// Token: 0x04000490 RID: 1168
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000491 RID: 1169
		private global::System.Windows.Forms.TextBox txtQty;

		// Token: 0x04000492 RID: 1170
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000493 RID: 1171
		private global::System.Windows.Forms.TextBox txtProdRemark;

		// Token: 0x04000494 RID: 1172
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000495 RID: 1173
		private global::System.Windows.Forms.TextBox txtProduct;

		// Token: 0x04000496 RID: 1174
		private global::System.Windows.Forms.Label label46;

		// Token: 0x04000497 RID: 1175
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000498 RID: 1176
		private global::System.Windows.Forms.TextBox txtConfirmUser;
	}
}
