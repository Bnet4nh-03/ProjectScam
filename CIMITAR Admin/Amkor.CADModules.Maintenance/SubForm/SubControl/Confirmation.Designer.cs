namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000031 RID: 49
	public partial class Confirmation : global::System.Windows.Forms.Form
	{
		// Token: 0x06000326 RID: 806 RVA: 0x000646F0 File Offset: 0x000628F0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00064728 File Offset: 0x00062928
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.dataGrid_confirm = new global::System.Windows.Forms.DataGridView();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pbClear = new global::System.Windows.Forms.PictureBox();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.pbSubmit = new global::System.Windows.Forms.PictureBox();
			this.btnClear = new global::System.Windows.Forms.Button();
			this.btnSumit = new global::System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGrid_confirm).BeginInit();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(769, 345);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.panel2.AutoScroll = true;
			this.panel2.Controls.Add(this.dataGrid_confirm);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(3, 17);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(763, 275);
			this.panel2.TabIndex = 42;
			this.panel2.Resize += new global::System.EventHandler(this.panel2_Resize);
			this.dataGrid_confirm.AllowUserToAddRows = false;
			this.dataGrid_confirm.AllowUserToDeleteRows = false;
			this.dataGrid_confirm.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid_confirm.Location = new global::System.Drawing.Point(0, 0);
			this.dataGrid_confirm.MultiSelect = false;
			this.dataGrid_confirm.Name = "dataGrid_confirm";
			this.dataGrid_confirm.RowTemplate.Height = 23;
			this.dataGrid_confirm.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGrid_confirm.Size = new global::System.Drawing.Size(763, 285);
			this.dataGrid_confirm.TabIndex = 2;
			this.dataGrid_confirm.CellClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_confirm_CellClick);
			this.dataGrid_confirm.CellEndEdit += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_confirm_CellEndEdit);
			this.dataGrid_confirm.CellEnter += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_confirm_CellEnter);
			this.dataGrid_confirm.CellMouseDown += new global::System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_confirm_CellMouseDown);
			this.dataGrid_confirm.CellPainting += new global::System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGrid_confirm_CellPainting);
			this.dataGrid_confirm.EditingControlShowing += new global::System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGrid_confirm_EditingControlShowing);
			this.dataGrid_confirm.SelectionChanged += new global::System.EventHandler(this.dataGrid_confirm_SelectionChanged);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pbClear);
			this.panel1.Controls.Add(this.panel18);
			this.panel1.Controls.Add(this.pbSubmit);
			this.panel1.Controls.Add(this.btnClear);
			this.panel1.Controls.Add(this.btnSumit);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(3, 292);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(763, 50);
			this.panel1.TabIndex = 41;
			this.label1.AutoSize = true;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new global::System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(177, 12);
			this.label1.TabIndex = 47;
			this.label1.Text = "※|(파이프) 특수기호 사용불가 ";
			this.pbClear.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClear.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbClear.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.Location = new global::System.Drawing.Point(378, 0);
			this.pbClear.Name = "pbClear";
			this.pbClear.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbClear.Size = new global::System.Drawing.Size(48, 50);
			this.pbClear.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbClear.TabIndex = 45;
			this.pbClear.TabStop = false;
			this.pbClear.Click += new global::System.EventHandler(this.pbClear_Click);
			this.pbClear.MouseEnter += new global::System.EventHandler(this.pbClear_MouseEnter);
			this.pbClear.MouseLeave += new global::System.EventHandler(this.pbClear_MouseLeave);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel18.Location = new global::System.Drawing.Point(426, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(23, 50);
			this.panel18.TabIndex = 44;
			this.pbSubmit.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbSubmit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbSubmit.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.submit;
			this.pbSubmit.Location = new global::System.Drawing.Point(449, 0);
			this.pbSubmit.Name = "pbSubmit";
			this.pbSubmit.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbSubmit.Size = new global::System.Drawing.Size(48, 50);
			this.pbSubmit.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbSubmit.TabIndex = 43;
			this.pbSubmit.TabStop = false;
			this.pbSubmit.Click += new global::System.EventHandler(this.pbSubmit_Click);
			this.pbSubmit.MouseEnter += new global::System.EventHandler(this.pbSubmit_MouseEnter);
			this.pbSubmit.MouseLeave += new global::System.EventHandler(this.pbSubmit_MouseLeave);
			this.btnClear.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnClear.Font = new global::System.Drawing.Font("Segoe UI Symbol", 12f, global::System.Drawing.FontStyle.Bold);
			this.btnClear.Location = new global::System.Drawing.Point(497, 0);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new global::System.Drawing.Size(118, 50);
			this.btnClear.TabIndex = 42;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Visible = false;
			this.btnClear.Click += new global::System.EventHandler(this.btnClear_Click);
			this.btnSumit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnSumit.Font = new global::System.Drawing.Font("Segoe UI Symbol", 12f, global::System.Drawing.FontStyle.Bold);
			this.btnSumit.Location = new global::System.Drawing.Point(615, 0);
			this.btnSumit.Name = "btnSumit";
			this.btnSumit.Size = new global::System.Drawing.Size(148, 50);
			this.btnSumit.TabIndex = 41;
			this.btnSumit.Text = "Submit";
			this.btnSumit.UseVisualStyleBackColor = true;
			this.btnSumit.Visible = false;
			this.btnSumit.Click += new global::System.EventHandler(this.btnSumit_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(769, 345);
			base.Controls.Add(this.groupBox1);
			base.MinimizeBox = false;
			base.Name = "Confirmation";
			this.Text = "Confirmation";
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGrid_confirm).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000548 RID: 1352
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000549 RID: 1353
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400054A RID: 1354
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400054B RID: 1355
		private global::System.Windows.Forms.Button btnClear;

		// Token: 0x0400054C RID: 1356
		private global::System.Windows.Forms.Button btnSumit;

		// Token: 0x0400054D RID: 1357
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400054E RID: 1358
		private global::System.Windows.Forms.PictureBox pbClear;

		// Token: 0x0400054F RID: 1359
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000550 RID: 1360
		private global::System.Windows.Forms.PictureBox pbSubmit;

		// Token: 0x04000551 RID: 1361
		private global::System.Windows.Forms.DataGridView dataGrid_confirm;

		// Token: 0x04000552 RID: 1362
		private global::System.Windows.Forms.Label label1;
	}
}
