namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000002 RID: 2
	public partial class SelectDevice : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002613 File Offset: 0x00000813
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002634 File Offset: 0x00000834
		private void InitializeComponent()
		{
			this.grid_device = new global::SourceGrid.Grid();
			this.textBox_filter = new global::System.Windows.Forms.TextBox();
			this.button_Search = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label_selectedDevice = new global::System.Windows.Forms.Label();
			this.button_select = new global::System.Windows.Forms.Button();
			this.panel_grid = new global::System.Windows.Forms.Panel();
			this.button_CF = new global::System.Windows.Forms.Button();
			this.panel_grid.SuspendLayout();
			base.SuspendLayout();
			this.grid_device.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_device.EnableSort = true;
			this.grid_device.Location = new global::System.Drawing.Point(0, 0);
			this.grid_device.Name = "grid_device";
			this.grid_device.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_device.SelectionMode = global::SourceGrid.GridSelectionMode.Row;
			this.grid_device.Size = new global::System.Drawing.Size(305, 365);
			this.grid_device.TabIndex = 0;
			this.grid_device.TabStop = true;
			this.grid_device.ToolTipText = "";
			this.grid_device.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_device_MouseClick);
			this.grid_device.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_device_MouseDoubleClick);
			this.textBox_filter.Location = new global::System.Drawing.Point(25, 62);
			this.textBox_filter.Name = "textBox_filter";
			this.textBox_filter.Size = new global::System.Drawing.Size(193, 23);
			this.textBox_filter.TabIndex = 5;
			this.button_Search.Location = new global::System.Drawing.Point(221, 60);
			this.button_Search.Name = "button_Search";
			this.button_Search.Size = new global::System.Drawing.Size(100, 25);
			this.button_Search.TabIndex = 4;
			this.button_Search.Text = "Search";
			this.button_Search.UseVisualStyleBackColor = true;
			this.button_Search.Click += new global::System.EventHandler(this.button_Search_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(25, 36);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(51, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "Device : ";
			this.label_selectedDevice.AutoSize = true;
			this.label_selectedDevice.Font = new global::System.Drawing.Font("굴림", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 129);
			this.label_selectedDevice.Location = new global::System.Drawing.Point(92, 36);
			this.label_selectedDevice.Name = "label_selectedDevice";
			this.label_selectedDevice.Size = new global::System.Drawing.Size(95, 12);
			this.label_selectedDevice.TabIndex = 6;
			this.label_selectedDevice.Text = "Select Device";
			this.button_select.Location = new global::System.Drawing.Point(25, 3);
			this.button_select.Name = "button_select";
			this.button_select.Size = new global::System.Drawing.Size(100, 25);
			this.button_select.TabIndex = 10;
			this.button_select.Text = "Select";
			this.button_select.UseVisualStyleBackColor = true;
			this.button_select.Click += new global::System.EventHandler(this.button_select_Click);
			this.panel_grid.AutoScroll = true;
			this.panel_grid.Controls.Add(this.grid_device);
			this.panel_grid.Location = new global::System.Drawing.Point(25, 100);
			this.panel_grid.Name = "panel_grid";
			this.panel_grid.Size = new global::System.Drawing.Size(305, 365);
			this.panel_grid.TabIndex = 11;
			this.button_CF.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.button_CF.Location = new global::System.Drawing.Point(131, 3);
			this.button_CF.Name = "button_CF";
			this.button_CF.Size = new global::System.Drawing.Size(100, 25);
			this.button_CF.TabIndex = 12;
			this.button_CF.Text = "Cancel";
			this.button_CF.UseVisualStyleBackColor = true;
			this.button_CF.Click += new global::System.EventHandler(this.button_CF_Click);
			base.AcceptButton = this.button_Search;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = global::System.Drawing.Color.White;
			base.CancelButton = this.button_CF;
			base.ClientSize = new global::System.Drawing.Size(384, 494);
			base.Controls.Add(this.button_CF);
			base.Controls.Add(this.panel_grid);
			base.Controls.Add(this.button_select);
			base.Controls.Add(this.label_selectedDevice);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textBox_filter);
			base.Controls.Add(this.button_Search);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SelectDevice";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SelectDevice";
			base.Load += new global::System.EventHandler(this.SelectDevice_Load);
			this.panel_grid.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000004 RID: 4
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000005 RID: 5
		private global::SourceGrid.Grid grid_device;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.TextBox textBox_filter;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Button button_Search;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Label label_selectedDevice;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button button_select;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Panel panel_grid;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Button button_CF;
	}
}
