namespace Amkor.CADModules.SBLModule
{
	// Token: 0x02000018 RID: 24
	public partial class RULESBLManager : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x0000E891 File Offset: 0x0000CA91
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000E8B0 File Offset: 0x0000CAB0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.SBLModule.RULESBLManager));
			this.grid_rules = new global::SourceGrid.Grid();
			this.textBox_keyword = new global::System.Windows.Forms.TextBox();
			this.panel_grid = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label23 = new global::System.Windows.Forms.Label();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.cmdDelete = new global::System.Windows.Forms.PictureBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.cmdAdd = new global::System.Windows.Forms.PictureBox();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.cmdExcel = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cmdSearch = new global::System.Windows.Forms.PictureBox();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label12 = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label_copyright = new global::System.Windows.Forms.Label();
			this.splitter10 = new global::System.Windows.Forms.Splitter();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.panel_grid.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdDelete).BeginInit();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdAdd).BeginInit();
			this.groupBox8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdExcel).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSearch).BeginInit();
			this.panel4.SuspendLayout();
			this.panel25.SuspendLayout();
			base.SuspendLayout();
			this.grid_rules.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grid_rules.EnableSort = true;
			this.grid_rules.Location = new global::System.Drawing.Point(3, 3);
			this.grid_rules.Name = "grid_rules";
			this.grid_rules.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid_rules.SelectionMode = global::SourceGrid.GridSelectionMode.Row;
			this.grid_rules.Size = new global::System.Drawing.Size(1078, 581);
			this.grid_rules.TabIndex = 0;
			this.grid_rules.TabStop = true;
			this.grid_rules.ToolTipText = "";
			this.grid_rules.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_rules_MouseClick);
			this.grid_rules.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.grid_rules_MouseDoubleClick);
			this.textBox_keyword.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.textBox_keyword.Location = new global::System.Drawing.Point(60, 17);
			this.textBox_keyword.Name = "textBox_keyword";
			this.textBox_keyword.Size = new global::System.Drawing.Size(260, 23);
			this.textBox_keyword.TabIndex = 1;
			this.textBox_keyword.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.textBox_keyword_KeyPress);
			this.panel_grid.AutoScroll = true;
			this.panel_grid.Controls.Add(this.grid_rules);
			this.panel_grid.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel_grid.Location = new global::System.Drawing.Point(0, 95);
			this.panel_grid.Name = "panel_grid";
			this.panel_grid.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel_grid.Size = new global::System.Drawing.Size(1084, 587);
			this.panel_grid.TabIndex = 5;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label23);
			this.panel1.Controls.Add(this.groupBox5);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox8);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.textBox_keyword);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1084, 61);
			this.panel1.TabIndex = 13;
			this.label23.AutoSize = true;
			this.label23.Location = new global::System.Drawing.Point(12, 20);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(42, 15);
			this.label23.TabIndex = 92;
			this.label23.Text = "Device";
			this.groupBox5.Controls.Add(this.cmdDelete);
			this.groupBox5.Location = new global::System.Drawing.Point(462, 2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(57, 57);
			this.groupBox5.TabIndex = 91;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Delete";
			this.cmdDelete.Image = global::Amkor.CADModules.SBLModule.Properties.Resources.TableRemove;
			this.cmdDelete.Location = new global::System.Drawing.Point(13, 17);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new global::System.Drawing.Size(32, 32);
			this.cmdDelete.TabIndex = 86;
			this.cmdDelete.TabStop = false;
			this.cmdDelete.Click += new global::System.EventHandler(this.cmdDelete_Click);
			this.cmdDelete.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdDelete_MouseDown);
			this.cmdDelete.MouseLeave += new global::System.EventHandler(this.cmdDelete_MouseLeave);
			this.cmdDelete.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdDelete_MouseMove);
			this.cmdDelete.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdDelete_MouseUp);
			this.groupBox3.Controls.Add(this.cmdAdd);
			this.groupBox3.Location = new global::System.Drawing.Point(405, 1);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox3.TabIndex = 27;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Add";
			this.cmdAdd.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdAdd.Image");
			this.cmdAdd.Location = new global::System.Drawing.Point(9, 18);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new global::System.Drawing.Size(32, 32);
			this.cmdAdd.TabIndex = 84;
			this.cmdAdd.TabStop = false;
			this.cmdAdd.Click += new global::System.EventHandler(this.cmdAdd_Click);
			this.cmdAdd.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdAdd_MouseDown);
			this.cmdAdd.MouseLeave += new global::System.EventHandler(this.cmdAdd_MouseLeave);
			this.cmdAdd.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdAdd_MouseMove);
			this.cmdAdd.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdAdd_MouseUp);
			this.groupBox8.Controls.Add(this.cmdExcel);
			this.groupBox8.Location = new global::System.Drawing.Point(525, 1);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(51, 58);
			this.groupBox8.TabIndex = 26;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Excel";
			this.cmdExcel.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdExcel.Image");
			this.cmdExcel.Location = new global::System.Drawing.Point(9, 18);
			this.cmdExcel.Name = "cmdExcel";
			this.cmdExcel.Size = new global::System.Drawing.Size(32, 32);
			this.cmdExcel.TabIndex = 80;
			this.cmdExcel.TabStop = false;
			this.cmdExcel.Click += new global::System.EventHandler(this.cmdExcel_Click);
			this.cmdExcel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseDown);
			this.cmdExcel.MouseLeave += new global::System.EventHandler(this.cmdExcel_MouseLeave);
			this.cmdExcel.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseMove);
			this.cmdExcel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdExcel_MouseUp);
			this.groupBox1.Controls.Add(this.cmdSearch);
			this.groupBox1.Location = new global::System.Drawing.Point(326, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(58, 58);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.cmdSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdSearch.Image");
			this.cmdSearch.Location = new global::System.Drawing.Point(12, 18);
			this.cmdSearch.Name = "cmdSearch";
			this.cmdSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdSearch.TabIndex = 1;
			this.cmdSearch.TabStop = false;
			this.cmdSearch.Click += new global::System.EventHandler(this.cmdSearch_Click);
			this.cmdSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdSearch_MouseDown);
			this.cmdSearch.MouseLeave += new global::System.EventHandler(this.cmdSearch_MouseLeave);
			this.cmdSearch.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdSearch_MouseMove);
			this.cmdSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdSearch_MouseUp);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1084, 34);
			this.panel4.TabIndex = 25;
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold);
			this.label12.Location = new global::System.Drawing.Point(12, 6);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(109, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "SBL Manager";
			this.panel25.Controls.Add(this.label_copyright);
			this.panel25.Controls.Add(this.splitter10);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 682);
			this.panel25.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(1084, 40);
			this.panel25.TabIndex = 26;
			this.label_copyright.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label_copyright.AutoSize = true;
			this.label_copyright.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label_copyright.Location = new global::System.Drawing.Point(331, 11);
			this.label_copyright.Name = "label_copyright";
			this.label_copyright.Size = new global::System.Drawing.Size(399, 15);
			this.label_copyright.TabIndex = 15;
			this.label_copyright.Text = "Copyright © 2017-2017 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.label_copyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.splitter10.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.splitter10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.splitter10.Location = new global::System.Drawing.Point(0, 0);
			this.splitter10.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.splitter10.Name = "splitter10";
			this.splitter10.Size = new global::System.Drawing.Size(1084, 1);
			this.splitter10.TabIndex = 14;
			this.splitter10.TabStop = false;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			base.ClientSize = new global::System.Drawing.Size(1084, 722);
			base.Controls.Add(this.panel_grid);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel4);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Name = "RULESBLManager";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RULE SBL Manager";
			base.Load += new global::System.EventHandler(this.RULESBLManager_Load);
			this.panel_grid.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdDelete).EndInit();
			this.groupBox3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdAdd).EndInit();
			this.groupBox8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdExcel).EndInit();
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdSearch).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000EA RID: 234
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000EB RID: 235
		private global::SourceGrid.Grid grid_rules;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.TextBox textBox_keyword;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.Panel panel_grid;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.Label label_copyright;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.Splitter splitter10;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.PictureBox cmdAdd;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.PictureBox cmdExcel;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.PictureBox cmdSearch;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.PictureBox cmdDelete;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.Label label23;
	}
}
