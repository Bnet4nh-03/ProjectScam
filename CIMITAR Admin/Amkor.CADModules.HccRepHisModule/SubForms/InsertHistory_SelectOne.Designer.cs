namespace Amkor.CADModules.HccRepHisModule.SubForms
{
	// Token: 0x02000009 RID: 9
	public partial class InsertHistory_SelectOne : global::System.Windows.Forms.Form
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00004270 File Offset: 0x00002470
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004290 File Offset: 0x00002490
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.grid_RepairHistoryItem = new global::SourceGrid.Grid();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new global::System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(607, 242);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Information";
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.grid_RepairHistoryItem);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(3, 19);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel1.Size = new global::System.Drawing.Size(601, 220);
			this.panel1.TabIndex = 19;
			this.grid_RepairHistoryItem.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_RepairHistoryItem.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_RepairHistoryItem.EnableSort = true;
			this.grid_RepairHistoryItem.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.grid_RepairHistoryItem.Location = new global::System.Drawing.Point(3, 3);
			this.grid_RepairHistoryItem.Margin = new global::System.Windows.Forms.Padding(3, 5, 3, 5);
			this.grid_RepairHistoryItem.Name = "grid_RepairHistoryItem";
			this.grid_RepairHistoryItem.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_RepairHistoryItem.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid_RepairHistoryItem.Size = new global::System.Drawing.Size(595, 214);
			this.grid_RepairHistoryItem.TabIndex = 18;
			this.grid_RepairHistoryItem.TabStop = true;
			this.grid_RepairHistoryItem.ToolTipText = "";
			this.grid_RepairHistoryItem.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_BIBoard_MouseDoubleClick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(613, 248);
			base.Controls.Add(this.groupBox1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "InsertHistory_SelectOne";
			base.Padding = new global::System.Windows.Forms.Padding(3);
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "InsertHistory_SelectOne";
			base.Load += new global::System.EventHandler(this.BIBoardInsert_SelectOne_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.BIBoardInsert_SelectOne_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400002B RID: 43
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400002D RID: 45
		private global::SourceGrid.Grid grid_RepairHistoryItem;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Panel panel1;
	}
}
