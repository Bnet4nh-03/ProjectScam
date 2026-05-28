namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000030 RID: 48
	public partial class BoardConfirmation : global::System.Windows.Forms.Form
	{
		// Token: 0x0600030C RID: 780 RVA: 0x00062CFC File Offset: 0x00060EFC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00062D34 File Offset: 0x00060F34
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pbClear = new global::System.Windows.Forms.PictureBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.pbSubmit = new global::System.Windows.Forms.PictureBox();
			this.btnClear = new global::System.Windows.Forms.Button();
			this.btnSumit = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.dataGrid_confirm = new global::System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).BeginInit();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGrid_confirm).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pbClear);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.pbSubmit);
			this.panel1.Controls.Add(this.btnClear);
			this.panel1.Controls.Add(this.btnSumit);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 279);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(765, 50);
			this.panel1.TabIndex = 43;
			this.label1.AutoSize = true;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new global::System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(177, 12);
			this.label1.TabIndex = 46;
			this.label1.Text = "※|(파이프) 특수기호 사용불가 ";
			this.pbClear.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClear.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbClear.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.clear;
			this.pbClear.Location = new global::System.Drawing.Point(387, 0);
			this.pbClear.Name = "pbClear";
			this.pbClear.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbClear.Size = new global::System.Drawing.Size(48, 50);
			this.pbClear.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbClear.TabIndex = 44;
			this.pbClear.TabStop = false;
			this.pbClear.Click += new global::System.EventHandler(this.pbClear_Click);
			this.pbClear.MouseEnter += new global::System.EventHandler(this.pbClear_MouseEnter);
			this.pbClear.MouseLeave += new global::System.EventHandler(this.pbClear_MouseLeave);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new global::System.Drawing.Point(435, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(16, 50);
			this.panel3.TabIndex = 45;
			this.pbSubmit.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbSubmit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbSubmit.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.submit;
			this.pbSubmit.Location = new global::System.Drawing.Point(451, 0);
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
			this.btnClear.Location = new global::System.Drawing.Point(499, 0);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new global::System.Drawing.Size(118, 50);
			this.btnClear.TabIndex = 42;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Visible = false;
			this.btnClear.Click += new global::System.EventHandler(this.btnClear_Click);
			this.btnSumit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.btnSumit.Font = new global::System.Drawing.Font("Segoe UI Symbol", 12f, global::System.Drawing.FontStyle.Bold);
			this.btnSumit.Location = new global::System.Drawing.Point(617, 0);
			this.btnSumit.Name = "btnSumit";
			this.btnSumit.Size = new global::System.Drawing.Size(148, 50);
			this.btnSumit.TabIndex = 41;
			this.btnSumit.Text = "Submit";
			this.btnSumit.UseVisualStyleBackColor = true;
			this.btnSumit.Visible = false;
			this.btnSumit.Click += new global::System.EventHandler(this.btnSumit_Click);
			this.panel2.AutoScroll = true;
			this.panel2.Controls.Add(this.dataGrid_confirm);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(765, 279);
			this.panel2.TabIndex = 44;
			this.dataGrid_confirm.AllowUserToAddRows = false;
			this.dataGrid_confirm.AllowUserToDeleteRows = false;
			this.dataGrid_confirm.AllowUserToResizeColumns = false;
			this.dataGrid_confirm.AllowUserToResizeRows = false;
			this.dataGrid_confirm.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid_confirm.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dataGrid_confirm.Location = new global::System.Drawing.Point(0, 0);
			this.dataGrid_confirm.Name = "dataGrid_confirm";
			this.dataGrid_confirm.RowTemplate.Height = 23;
			this.dataGrid_confirm.ScrollBars = global::System.Windows.Forms.ScrollBars.None;
			this.dataGrid_confirm.Size = new global::System.Drawing.Size(765, 279);
			this.dataGrid_confirm.TabIndex = 2;
			this.dataGrid_confirm.CellClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_confirm_CellClick);
			this.dataGrid_confirm.CellPainting += new global::System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGrid_confirm_CellPainting);
			this.dataGrid_confirm.EditingControlShowing += new global::System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGrid_confirm_EditingControlShowing);
			this.dataGrid_confirm.SelectionChanged += new global::System.EventHandler(this.dataGrid_confirm_SelectionChanged);
			this.dataGrid_confirm.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.dataGrid_confirm_KeyPress);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(765, 329);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BoardConfirmation";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Board Confirmation";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).EndInit();
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGrid_confirm).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000537 RID: 1335
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000538 RID: 1336
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000539 RID: 1337
		private global::System.Windows.Forms.Button btnClear;

		// Token: 0x0400053A RID: 1338
		private global::System.Windows.Forms.Button btnSumit;

		// Token: 0x0400053B RID: 1339
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400053C RID: 1340
		private global::System.Windows.Forms.DataGridView dataGrid_confirm;

		// Token: 0x0400053D RID: 1341
		private global::System.Windows.Forms.PictureBox pbClear;

		// Token: 0x0400053E RID: 1342
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400053F RID: 1343
		private global::System.Windows.Forms.PictureBox pbSubmit;

		// Token: 0x04000540 RID: 1344
		private global::System.Windows.Forms.Label label1;
	}
}
