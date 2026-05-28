namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000027 RID: 39
	public partial class SaveExcel_Sum : global::System.Windows.Forms.Form
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x00014765 File Offset: 0x00012965
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00014784 File Offset: 0x00012984
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.combo_Product = new global::System.Windows.Forms.ComboBox();
			this.pb_SaveExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pb_SaveExcel).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.pb_SaveExcel);
			this.groupBox1.Controls.Add(this.combo_Product);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(266, 60);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Product";
			this.combo_Product.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Product.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.combo_Product.FormattingEnabled = true;
			this.combo_Product.Location = new global::System.Drawing.Point(6, 22);
			this.combo_Product.Name = "combo_Product";
			this.combo_Product.Size = new global::System.Drawing.Size(215, 23);
			this.combo_Product.TabIndex = 0;
			this.pb_SaveExcel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pb_SaveExcel.Image = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.SaveExcel;
			this.pb_SaveExcel.InitialImage = global::Amkor.CADModules.BIBoardInfoModule.Properties.Resources.SaveExcel;
			this.pb_SaveExcel.Location = new global::System.Drawing.Point(227, 16);
			this.pb_SaveExcel.Name = "pb_SaveExcel";
			this.pb_SaveExcel.Size = new global::System.Drawing.Size(32, 33);
			this.pb_SaveExcel.TabIndex = 1;
			this.pb_SaveExcel.TabStop = false;
			this.pb_SaveExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pb_SaveExcel_MouseDown);
			this.pb_SaveExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pb_SaveExcel_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(272, 66);
			base.Controls.Add(this.groupBox1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "SaveExcel_Sum";
			base.Padding = new global::System.Windows.Forms.Padding(3);
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SaveExcel_Sum";
			base.Load += new global::System.EventHandler(this.SaveExcel_Sum_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.SaveExcel_Sum_KeyDown);
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pb_SaveExcel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040001A7 RID: 423
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.ComboBox combo_Product;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.PictureBox pb_SaveExcel;
	}
}
