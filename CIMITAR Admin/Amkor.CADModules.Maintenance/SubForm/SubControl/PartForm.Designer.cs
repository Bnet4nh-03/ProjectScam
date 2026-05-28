namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000037 RID: 55
	public partial class PartForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000384 RID: 900 RVA: 0x0006B1C4 File Offset: 0x000693C4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0006B1FC File Offset: 0x000693FC
		private void InitializeComponent()
		{
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.Maintenance.SubForm.SubControl.PartForm));
			this.dataGridView = new global::System.Windows.Forms.DataGridView();
			this.Column1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new global::System.Windows.Forms.DataGridViewButtonColumn();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.pbApply = new global::System.Windows.Forms.PictureBox();
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.pbCancel = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView).BeginInit();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbApply).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).BeginInit();
			base.SuspendLayout();
			this.dataGridView.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.Column1,
				this.Column2,
				this.Column3,
				this.Column4
			});
			this.dataGridView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new global::System.Drawing.Point(0, 0);
			this.dataGridView.MultiSelect = false;
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowTemplate.Height = 23;
			this.dataGridView.Size = new global::System.Drawing.Size(444, 632);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.CellClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
			this.dataGridView.EditingControlShowing += new global::System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
			this.dataGridView.Paint += new global::System.Windows.Forms.PaintEventHandler(this.dataGridView_Paint);
			this.Column1.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			dataGridViewCellStyle.NullValue = " ";
			this.Column1.DefaultCellStyle = dataGridViewCellStyle;
			this.Column1.HeaderText = "Description";
			this.Column1.Name = "Column1";
			this.Column1.Width = 93;
			this.Column2.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.Column2.HeaderText = "Model";
			this.Column2.Name = "Column2";
			this.Column2.Width = 65;
			dataGridViewCellStyle2.Format = "N0";
			dataGridViewCellStyle2.NullValue = null;
			this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
			this.Column3.HeaderText = "Q'ty";
			this.Column3.Name = "Column3";
			this.Column4.HeaderText = "Delete";
			this.Column4.Name = "Column4";
			this.Column4.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.Column4.Text = "Delete";
			this.btnOK.Location = new global::System.Drawing.Point(46, 0);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(85, 45);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Visible = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.panel1.Controls.Add(this.pbApply);
			this.panel1.Controls.Add(this.panel18);
			this.panel1.Controls.Add(this.pbCancel);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 578);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(444, 54);
			this.panel1.TabIndex = 2;
			this.btnCancel.Location = new global::System.Drawing.Point(128, 0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(93, 45);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.pbApply.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbApply.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbApply.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbApply.Image");
			this.pbApply.Location = new global::System.Drawing.Point(317, 0);
			this.pbApply.Name = "pbApply";
			this.pbApply.Size = new global::System.Drawing.Size(52, 54);
			this.pbApply.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbApply.TabIndex = 97;
			this.pbApply.TabStop = false;
			this.pbApply.Click += new global::System.EventHandler(this.pbApply_Click);
			this.pbApply.MouseEnter += new global::System.EventHandler(this.pbApply_MouseEnter);
			this.pbApply.MouseLeave += new global::System.EventHandler(this.pbApply_MouseLeave);
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel18.Location = new global::System.Drawing.Point(369, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(23, 54);
			this.panel18.TabIndex = 96;
			this.pbCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbCancel.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbCancel.Image = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.InitialImage = global::Amkor.CADModules.Maintenance.Properties.Resources.cancel;
			this.pbCancel.Location = new global::System.Drawing.Point(392, 0);
			this.pbCancel.Name = "pbCancel";
			this.pbCancel.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbCancel.Size = new global::System.Drawing.Size(52, 54);
			this.pbCancel.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbCancel.TabIndex = 95;
			this.pbCancel.TabStop = false;
			this.pbCancel.Click += new global::System.EventHandler(this.pbCancel_Click);
			this.pbCancel.MouseEnter += new global::System.EventHandler(this.pbCancel_MouseEnter);
			this.pbCancel.MouseLeave += new global::System.EventHandler(this.pbCancel_MouseLeave);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(444, 632);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.dataGridView);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "PartForm";
			this.Text = "PartForm";
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView).EndInit();
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbApply).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbCancel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040005B0 RID: 1456
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040005B1 RID: 1457
		private global::System.Windows.Forms.DataGridView dataGridView;

		// Token: 0x040005B2 RID: 1458
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040005B3 RID: 1459
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040005B4 RID: 1460
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040005B5 RID: 1461
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column1;

		// Token: 0x040005B6 RID: 1462
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column2;

		// Token: 0x040005B7 RID: 1463
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column3;

		// Token: 0x040005B8 RID: 1464
		private global::System.Windows.Forms.DataGridViewButtonColumn Column4;

		// Token: 0x040005B9 RID: 1465
		private global::System.Windows.Forms.PictureBox pbApply;

		// Token: 0x040005BA RID: 1466
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x040005BB RID: 1467
		private global::System.Windows.Forms.PictureBox pbCancel;
	}
}
