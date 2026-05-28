namespace Amkor.CADModules.ESIModule.View
{
	// Token: 0x02000031 RID: 49
	public partial class DetailLotViewer : global::System.Windows.Forms.Form
	{
		// Token: 0x06000187 RID: 391 RVA: 0x00026690 File Offset: 0x00024890
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000266B0 File Offset: 0x000248B0
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.gridDetailUnitList = new global::SourceGrid.Grid();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.cmdUnitExcel = new global::System.Windows.Forms.PictureBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cbStation = new global::System.Windows.Forms.ComboBox();
			this.rbAll = new global::System.Windows.Forms.RadioButton();
			this.rbPass = new global::System.Windows.Forms.RadioButton();
			this.rbFail = new global::System.Windows.Forms.RadioButton();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdUnitExcel).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(978, 486);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(3, 17);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(972, 466);
			this.panel1.TabIndex = 8;
			this.groupBox2.Controls.Add(this.gridDetailUnitList);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new global::System.Drawing.Point(0, 82);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(972, 384);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "List";
			this.gridDetailUnitList.BackColor = global::System.Drawing.Color.White;
			this.gridDetailUnitList.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.gridDetailUnitList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridDetailUnitList.EnableSort = true;
			this.gridDetailUnitList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridDetailUnitList.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridDetailUnitList.Location = new global::System.Drawing.Point(3, 17);
			this.gridDetailUnitList.Name = "gridDetailUnitList";
			this.gridDetailUnitList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridDetailUnitList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridDetailUnitList.Size = new global::System.Drawing.Size(966, 364);
			this.gridDetailUnitList.TabIndex = 2;
			this.gridDetailUnitList.TabStop = true;
			this.gridDetailUnitList.ToolTipText = "";
			this.groupBox3.Controls.Add(this.groupBox7);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.cbStation);
			this.groupBox3.Controls.Add(this.rbAll);
			this.groupBox3.Controls.Add(this.rbPass);
			this.groupBox3.Controls.Add(this.rbFail);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(972, 82);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox7.Controls.Add(this.cmdUnitExcel);
			this.groupBox7.Location = new global::System.Drawing.Point(911, 12);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(55, 61);
			this.groupBox7.TabIndex = 104;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Excel";
			this.cmdUnitExcel.Image = global::Amkor.CADModules.ESIModule.Properties.Resources.SaveExcel;
			this.cmdUnitExcel.Location = new global::System.Drawing.Point(12, 19);
			this.cmdUnitExcel.Name = "cmdUnitExcel";
			this.cmdUnitExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdUnitExcel.TabIndex = 103;
			this.cmdUnitExcel.TabStop = false;
			this.cmdUnitExcel.Click += new global::System.EventHandler(this.cmdUnitExcel_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(19, 48);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(43, 12);
			this.label1.TabIndex = 8;
			this.label1.Text = "Station";
			this.cbStation.FormattingEnabled = true;
			this.cbStation.Items.AddRange(new object[]
			{
				"ALL"
			});
			this.cbStation.Location = new global::System.Drawing.Point(65, 43);
			this.cbStation.Name = "cbStation";
			this.cbStation.Size = new global::System.Drawing.Size(311, 20);
			this.cbStation.Sorted = true;
			this.cbStation.TabIndex = 3;
			this.cbStation.SelectedIndexChanged += new global::System.EventHandler(this.cbStation_SelectedIndexChanged);
			this.rbAll.AutoSize = true;
			this.rbAll.Checked = true;
			this.rbAll.Location = new global::System.Drawing.Point(19, 20);
			this.rbAll.Name = "rbAll";
			this.rbAll.Size = new global::System.Drawing.Size(62, 16);
			this.rbAll.TabIndex = 7;
			this.rbAll.TabStop = true;
			this.rbAll.Text = "All Unit";
			this.rbAll.UseVisualStyleBackColor = true;
			this.rbAll.CheckedChanged += new global::System.EventHandler(this.rbAll_CheckedChanged);
			this.rbAll.Click += new global::System.EventHandler(this.rbAll_Click);
			this.rbPass.Location = new global::System.Drawing.Point(85, 20);
			this.rbPass.Name = "rbPass";
			this.rbPass.Size = new global::System.Drawing.Size(87, 16);
			this.rbPass.TabIndex = 4;
			this.rbPass.Text = "Pass Unit";
			this.rbPass.UseVisualStyleBackColor = true;
			this.rbPass.CheckedChanged += new global::System.EventHandler(this.rbAll_CheckedChanged);
			this.rbPass.Click += new global::System.EventHandler(this.rbPass_Click);
			this.rbFail.AutoSize = true;
			this.rbFail.Location = new global::System.Drawing.Point(173, 21);
			this.rbFail.Name = "rbFail";
			this.rbFail.Size = new global::System.Drawing.Size(68, 16);
			this.rbFail.TabIndex = 6;
			this.rbFail.Text = "Fail Unit";
			this.rbFail.UseVisualStyleBackColor = true;
			this.rbFail.CheckedChanged += new global::System.EventHandler(this.rbAll_CheckedChanged);
			this.rbFail.Click += new global::System.EventHandler(this.rbFail_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(978, 486);
			base.Controls.Add(this.groupBox1);
			base.MinimizeBox = false;
			base.Name = "DetailLotViewer";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DetailLotViewer";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.DetailLotViewer_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdUnitExcel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400028F RID: 655
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000290 RID: 656
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000291 RID: 657
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x04000292 RID: 658
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000293 RID: 659
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000294 RID: 660
		private global::SourceGrid.Grid gridDetailUnitList;

		// Token: 0x04000295 RID: 661
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000296 RID: 662
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x04000297 RID: 663
		private global::System.Windows.Forms.PictureBox cmdUnitExcel;

		// Token: 0x04000298 RID: 664
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000299 RID: 665
		private global::System.Windows.Forms.ComboBox cbStation;

		// Token: 0x0400029A RID: 666
		private global::System.Windows.Forms.RadioButton rbAll;

		// Token: 0x0400029B RID: 667
		private global::System.Windows.Forms.RadioButton rbPass;

		// Token: 0x0400029C RID: 668
		private global::System.Windows.Forms.RadioButton rbFail;
	}
}
