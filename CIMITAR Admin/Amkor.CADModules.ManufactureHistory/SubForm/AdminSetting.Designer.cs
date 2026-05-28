namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x0200000B RID: 11
	public partial class AdminSetting : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x06000036 RID: 54 RVA: 0x000049EC File Offset: 0x00002BEC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00004A24 File Offset: 0x00002C24
		private void InitializeComponent()
		{
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tpOperation = new global::System.Windows.Forms.TabPage();
			this.gbOperation = new global::System.Windows.Forms.GroupBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.grid_oepration = new global::SourceGrid.Grid();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.tbOperationName = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.tbOperationCode = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.btnDelOperation = new global::System.Windows.Forms.Button();
			this.btnAddOperation = new global::System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tpOperation.SuspendLayout();
			this.gbOperation.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel13.SuspendLayout();
			this.groupBox8.SuspendLayout();
			base.SuspendLayout();
			this.tabControl1.Controls.Add(this.tpOperation);
			this.tabControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new global::System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(1159, 590);
			this.tabControl1.TabIndex = 0;
			this.tpOperation.Controls.Add(this.gbOperation);
			this.tpOperation.Location = new global::System.Drawing.Point(4, 22);
			this.tpOperation.Name = "tpOperation";
			this.tpOperation.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpOperation.Size = new global::System.Drawing.Size(1151, 564);
			this.tpOperation.TabIndex = 0;
			this.tpOperation.Text = "Operation";
			this.tpOperation.UseVisualStyleBackColor = true;
			this.gbOperation.Controls.Add(this.panel1);
			this.gbOperation.Controls.Add(this.panel13);
			this.gbOperation.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gbOperation.Location = new global::System.Drawing.Point(3, 3);
			this.gbOperation.Name = "gbOperation";
			this.gbOperation.Size = new global::System.Drawing.Size(1145, 558);
			this.gbOperation.TabIndex = 8;
			this.gbOperation.TabStop = false;
			this.gbOperation.Text = "Register Opertaion";
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.grid_oepration);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(259, 17);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(883, 538);
			this.panel1.TabIndex = 8;
			this.grid_oepration.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_oepration.EnableSort = true;
			this.grid_oepration.FixedColumns = 2;
			this.grid_oepration.FixedRows = 1;
			this.grid_oepration.Font = new global::System.Drawing.Font("굴림체", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.grid_oepration.Location = new global::System.Drawing.Point(0, 0);
			this.grid_oepration.Name = "grid_oepration";
			this.grid_oepration.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_oepration.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_oepration.Size = new global::System.Drawing.Size(881, 536);
			this.grid_oepration.TabIndex = 26;
			this.grid_oepration.TabStop = true;
			this.grid_oepration.ToolTipText = "";
			this.panel13.Controls.Add(this.groupBox8);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel13.Location = new global::System.Drawing.Point(3, 17);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new global::System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panel13.Size = new global::System.Drawing.Size(256, 538);
			this.panel13.TabIndex = 7;
			this.groupBox8.Controls.Add(this.tbOperationName);
			this.groupBox8.Controls.Add(this.label1);
			this.groupBox8.Controls.Add(this.tbOperationCode);
			this.groupBox8.Controls.Add(this.label10);
			this.groupBox8.Controls.Add(this.btnDelOperation);
			this.groupBox8.Controls.Add(this.btnAddOperation);
			this.groupBox8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox8.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(250, 134);
			this.groupBox8.TabIndex = 5;
			this.groupBox8.TabStop = false;
			this.tbOperationName.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tbOperationName.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbOperationName.Location = new global::System.Drawing.Point(3, 72);
			this.tbOperationName.Name = "tbOperationName";
			this.tbOperationName.Size = new global::System.Drawing.Size(244, 21);
			this.tbOperationName.TabIndex = 30;
			this.label1.AutoSize = true;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label1.Location = new global::System.Drawing.Point(3, 55);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(106, 17);
			this.label1.TabIndex = 29;
			this.label1.Text = "Operation Name";
			this.tbOperationCode.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.tbOperationCode.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.tbOperationCode.Location = new global::System.Drawing.Point(3, 34);
			this.tbOperationCode.Name = "tbOperationCode";
			this.tbOperationCode.Size = new global::System.Drawing.Size(244, 21);
			this.tbOperationCode.TabIndex = 3;
			this.tbOperationCode.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tbOperationCode_KeyPress);
			this.label10.AutoSize = true;
			this.label10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label10.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label10.Location = new global::System.Drawing.Point(3, 17);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(102, 17);
			this.label10.TabIndex = 28;
			this.label10.Text = "Operation Code";
			this.btnDelOperation.Location = new global::System.Drawing.Point(156, 105);
			this.btnDelOperation.Name = "btnDelOperation";
			this.btnDelOperation.Size = new global::System.Drawing.Size(75, 23);
			this.btnDelOperation.TabIndex = 10;
			this.btnDelOperation.Text = "Del";
			this.btnDelOperation.UseVisualStyleBackColor = true;
			this.btnDelOperation.Click += new global::System.EventHandler(this.btnDelOperation_Click);
			this.btnAddOperation.Location = new global::System.Drawing.Point(78, 105);
			this.btnAddOperation.Name = "btnAddOperation";
			this.btnAddOperation.Size = new global::System.Drawing.Size(75, 23);
			this.btnAddOperation.TabIndex = 4;
			this.btnAddOperation.Text = "Add";
			this.btnAddOperation.UseVisualStyleBackColor = true;
			this.btnAddOperation.Click += new global::System.EventHandler(this.btnAddOperation_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1159, 590);
			base.Controls.Add(this.tabControl1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "AdminSetting";
			this.Text = "AdminSetting";
			base.Shown += new global::System.EventHandler(this.AdminSetting_Shown);
			this.tabControl1.ResumeLayout(false);
			this.tpOperation.ResumeLayout(false);
			this.gbOperation.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000010 RID: 16
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.TabPage tpOperation;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.GroupBox gbOperation;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.TextBox tbOperationName;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.TextBox tbOperationCode;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button btnDelOperation;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Button btnAddOperation;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400001D RID: 29
		private global::SourceGrid.Grid grid_oepration;
	}
}
