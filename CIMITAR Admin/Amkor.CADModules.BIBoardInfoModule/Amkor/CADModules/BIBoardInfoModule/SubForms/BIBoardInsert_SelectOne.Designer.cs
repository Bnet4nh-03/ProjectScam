namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000021 RID: 33
	public partial class BIBoardInsert_SelectOne : global::System.Windows.Forms.Form
	{
		// Token: 0x06000098 RID: 152 RVA: 0x0000CB68 File Offset: 0x0000AD68
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000CB88 File Offset: 0x0000AD88
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.grid_BIBoard = new global::SourceGrid.Grid();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(484, 151);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Information";
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.grid_BIBoard);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(3, 19);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel1.Size = new global::System.Drawing.Size(478, 129);
			this.panel1.TabIndex = 19;
			this.grid_BIBoard.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_BIBoard.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_BIBoard.EnableSort = true;
			this.grid_BIBoard.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_BIBoard.Location = new global::System.Drawing.Point(3, 3);
			this.grid_BIBoard.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_BIBoard.Name = "grid_BIBoard";
			this.grid_BIBoard.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_BIBoard.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_BIBoard.Size = new global::System.Drawing.Size(472, 123);
			this.grid_BIBoard.TabIndex = 18;
			this.grid_BIBoard.TabStop = true;
			this.grid_BIBoard.ToolTipText = "";
			this.grid_BIBoard.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_BIBoard_MouseDoubleClick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(490, 157);
			base.Controls.Add(this.groupBox1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "BIBoardInsert_SelectOne";
			base.Padding = new global::System.Windows.Forms.Padding(3);
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BIBoardInsert_SelectOne";
			base.Load += new global::System.EventHandler(this.BIBoardInsert_SelectOne_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.BIBoardInsert_SelectOne_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400011D RID: 285
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400011F RID: 287
		private global::SourceGrid.Grid grid_BIBoard;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Panel panel1;
	}
}
