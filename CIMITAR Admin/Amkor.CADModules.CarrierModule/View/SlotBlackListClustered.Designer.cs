namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000048 RID: 72
	public partial class SlotBlackListClustered : global::System.Windows.Forms.Form
	{
		// Token: 0x06000340 RID: 832 RVA: 0x00051891 File Offset: 0x0004FA91
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x000518B0 File Offset: 0x0004FAB0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.CarrierModule.View.SlotBlackListClustered));
			this.gridSlotBlackList = new global::SourceGrid.Grid();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.cmdSlotExcel = new global::System.Windows.Forms.PictureBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSlotExcel).BeginInit();
			base.SuspendLayout();
			this.gridSlotBlackList.AutoScrollMargin = new global::System.Drawing.Size(5, 5);
			this.gridSlotBlackList.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.gridSlotBlackList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridSlotBlackList.EnableSort = true;
			this.gridSlotBlackList.Location = new global::System.Drawing.Point(0, 0);
			this.gridSlotBlackList.Margin = new global::System.Windows.Forms.Padding(6, 3, 3, 3);
			this.gridSlotBlackList.Name = "gridSlotBlackList";
			this.gridSlotBlackList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridSlotBlackList.Padding = new global::System.Windows.Forms.Padding(5, 0, 0, 0);
			this.gridSlotBlackList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridSlotBlackList.Size = new global::System.Drawing.Size(743, 322);
			this.gridSlotBlackList.TabIndex = 0;
			this.gridSlotBlackList.TabStop = true;
			this.gridSlotBlackList.ToolTipText = "";
			this.panel1.Controls.Add(this.gridSlotBlackList);
			this.panel1.Location = new global::System.Drawing.Point(28, 84);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(743, 322);
			this.panel1.TabIndex = 4;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.textBox1.BackColor = global::System.Drawing.Color.LightGray;
			this.textBox1.Enabled = false;
			this.textBox1.Location = new global::System.Drawing.Point(82, 45);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(134, 21);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new global::System.EventHandler(this.textBox1_TextChanged);
			this.panel2.Controls.Add(this.groupBox8);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(771, 81);
			this.panel2.TabIndex = 5;
			this.groupBox8.BackColor = global::System.Drawing.SystemColors.ButtonFace;
			this.groupBox8.Controls.Add(this.cmdSlotExcel);
			this.groupBox8.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.groupBox8.Location = new global::System.Drawing.Point(651, 11);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(59, 67);
			this.groupBox8.TabIndex = 18;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Excel";
			this.cmdSlotExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdSlotExcel.Image");
			this.cmdSlotExcel.Location = new global::System.Drawing.Point(9, 18);
			this.cmdSlotExcel.Name = "cmdSlotExcel";
			this.cmdSlotExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdSlotExcel.TabIndex = 80;
			this.cmdSlotExcel.TabStop = false;
			this.cmdSlotExcel.Click += new global::System.EventHandler(this.cmdSlotExcel_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(36, 49);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(42, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "Date : ";
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(28, 438);
			this.panel3.TabIndex = 0;
			this.panel4.BackColor = global::System.Drawing.Color.Transparent;
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new global::System.Drawing.Point(28, 401);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(746, 37);
			this.panel4.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(774, 438);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Name = "SlotBlackListClustered";
			this.Text = "SlotTrendList";
			base.Load += new global::System.EventHandler(this.SlotBlackListClustered_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdSlotExcel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400056D RID: 1389
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400056E RID: 1390
		private global::SourceGrid.Grid gridSlotBlackList;

		// Token: 0x0400056F RID: 1391
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000570 RID: 1392
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x04000571 RID: 1393
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000572 RID: 1394
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000573 RID: 1395
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000574 RID: 1396
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x04000575 RID: 1397
		private global::System.Windows.Forms.PictureBox cmdSlotExcel;

		// Token: 0x04000576 RID: 1398
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x04000577 RID: 1399
		private global::System.Windows.Forms.Panel panel4;
	}
}
