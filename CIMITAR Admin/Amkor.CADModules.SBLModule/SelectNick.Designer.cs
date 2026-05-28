namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000003 RID: 3
	public partial class SelectNick : global::System.Windows.Forms.Form
	{
		// Token: 0x06000017 RID: 23 RVA: 0x0000316B File Offset: 0x0000136B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000318C File Offset: 0x0000138C
		private void InitializeComponent()
		{
			this.grid_nick = new global::SourceGrid.Grid();
			this.textBox_filter = new global::System.Windows.Forms.TextBox();
			this.label_selectedNick = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.button_Search = new global::System.Windows.Forms.Button();
			this.button_select = new global::System.Windows.Forms.Button();
			this.panel_grid = new global::System.Windows.Forms.Panel();
			this.button_CF = new global::System.Windows.Forms.Button();
			this.panel_grid.SuspendLayout();
			base.SuspendLayout();
			this.grid_nick.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_nick.EnableSort = true;
			this.grid_nick.Location = new global::System.Drawing.Point(0, 0);
			this.grid_nick.Name = "grid_nick";
			this.grid_nick.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_nick.SelectionMode = global::SourceGrid.GridSelectionMode.Row;
			this.grid_nick.Size = new global::System.Drawing.Size(305, 353);
			this.grid_nick.TabIndex = 1;
			this.grid_nick.TabStop = true;
			this.grid_nick.ToolTipText = "";
			this.grid_nick.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_nick_MouseClick);
			this.grid_nick.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_nick_MouseDoubleClick);
			this.textBox_filter.Location = new global::System.Drawing.Point(25, 62);
			this.textBox_filter.Name = "textBox_filter";
			this.textBox_filter.Size = new global::System.Drawing.Size(193, 23);
			this.textBox_filter.TabIndex = 3;
			this.label_selectedNick.AutoSize = true;
			this.label_selectedNick.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label_selectedNick.Location = new global::System.Drawing.Point(95, 36);
			this.label_selectedNick.Name = "label_selectedNick";
			this.label_selectedNick.Size = new global::System.Drawing.Size(83, 12);
			this.label_selectedNick.TabIndex = 8;
			this.label_selectedNick.Text = "select NICK";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(25, 36);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(43, 15);
			this.label1.TabIndex = 7;
			this.label1.Text = "NICK : ";
			this.button_Search.Location = new global::System.Drawing.Point(220, 60);
			this.button_Search.Name = "button_Search";
			this.button_Search.Size = new global::System.Drawing.Size(100, 25);
			this.button_Search.TabIndex = 9;
			this.button_Search.Text = "Search";
			this.button_Search.UseVisualStyleBackColor = true;
			this.button_Search.Click += new global::System.EventHandler(this.button_Search_Click);
			this.button_select.Location = new global::System.Drawing.Point(25, 3);
			this.button_select.Name = "button_select";
			this.button_select.Size = new global::System.Drawing.Size(100, 25);
			this.button_select.TabIndex = 9;
			this.button_select.Text = "Select";
			this.button_select.UseVisualStyleBackColor = true;
			this.button_select.Click += new global::System.EventHandler(this.button_select_Click);
			this.panel_grid.AutoScroll = true;
			this.panel_grid.Controls.Add(this.grid_nick);
			this.panel_grid.Location = new global::System.Drawing.Point(25, 100);
			this.panel_grid.Name = "panel_grid";
			this.panel_grid.Size = new global::System.Drawing.Size(305, 353);
			this.panel_grid.TabIndex = 10;
			this.button_CF.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.button_CF.Location = new global::System.Drawing.Point(131, 3);
			this.button_CF.Name = "button_CF";
			this.button_CF.Size = new global::System.Drawing.Size(100, 25);
			this.button_CF.TabIndex = 11;
			this.button_CF.Text = "Cancel";
			this.button_CF.UseVisualStyleBackColor = true;
			this.button_CF.Click += new global::System.EventHandler(this.button_CF_Click);
			base.AcceptButton = this.button_Search;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = global::System.Drawing.Color.White;
			base.CancelButton = this.button_CF;
			base.ClientSize = new global::System.Drawing.Size(384, 462);
			base.Controls.Add(this.button_CF);
			base.Controls.Add(this.panel_grid);
			base.Controls.Add(this.button_select);
			base.Controls.Add(this.button_Search);
			base.Controls.Add(this.label_selectedNick);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textBox_filter);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SelectNick";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SelectNick";
			base.Load += new global::System.EventHandler(this.SelectNick_Load);
			this.panel_grid.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000010 RID: 16
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000011 RID: 17
		private global::SourceGrid.Grid grid_nick;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.TextBox textBox_filter;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Label label_selectedNick;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Button button_Search;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Button button_select;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Panel panel_grid;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Button button_CF;
	}
}
