namespace Amkor.CADModules.ESIModule.View
{
	// Token: 0x02000026 RID: 38
	public partial class _2DList : global::System.Windows.Forms.Form
	{
		// Token: 0x0600009E RID: 158 RVA: 0x0000712F File Offset: 0x0000532F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00007150 File Offset: 0x00005350
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.groupBox16 = new global::System.Windows.Forms.GroupBox();
			this.cmd_In_Apply = new global::System.Windows.Forms.PictureBox();
			this.groupBox17 = new global::System.Windows.Forms.GroupBox();
			this.cmd_In_Search = new global::System.Windows.Forms.PictureBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.grid2DList = new global::SourceGrid.Grid();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.cbAll = new global::System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.groupBox16.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_In_Apply).BeginInit();
			this.groupBox17.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_In_Search).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.cbAll);
			this.panel1.Controls.Add(this.groupBox16);
			this.panel1.Controls.Add(this.groupBox17);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1371, 76);
			this.panel1.TabIndex = 0;
			this.groupBox16.Controls.Add(this.cmd_In_Apply);
			this.groupBox16.Location = new global::System.Drawing.Point(101, 12);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new global::System.Drawing.Size(92, 61);
			this.groupBox16.TabIndex = 107;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "List Request";
			this.cmd_In_Apply.Image = global::Amkor.CADModules.ESIModule.Properties.Resources.TableApply;
			this.cmd_In_Apply.Location = new global::System.Drawing.Point(33, 19);
			this.cmd_In_Apply.Name = "cmd_In_Apply";
			this.cmd_In_Apply.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_In_Apply.TabIndex = 104;
			this.cmd_In_Apply.TabStop = false;
			this.cmd_In_Apply.Click += new global::System.EventHandler(this.cmd_In_Apply_Click);
			this.cmd_In_Apply.MouseLeave += new global::System.EventHandler(this.cmd_In_Apply_MouseLeave);
			this.cmd_In_Apply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmd_In_Apply_MouseMove);
			this.groupBox17.Controls.Add(this.cmd_In_Search);
			this.groupBox17.Location = new global::System.Drawing.Point(12, 12);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new global::System.Drawing.Size(83, 61);
			this.groupBox17.TabIndex = 104;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Import CSV";
			this.cmd_In_Search.Image = global::Amkor.CADModules.ESIModule.Properties.Resources.LoadExcel;
			this.cmd_In_Search.Location = new global::System.Drawing.Point(20, 19);
			this.cmd_In_Search.Name = "cmd_In_Search";
			this.cmd_In_Search.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_In_Search.TabIndex = 102;
			this.cmd_In_Search.TabStop = false;
			this.cmd_In_Search.Click += new global::System.EventHandler(this.cmd_In_Search_Click);
			this.cmd_In_Search.MouseLeave += new global::System.EventHandler(this.cmd_In_Search_MouseLeave);
			this.cmd_In_Search.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmd_In_Search_MouseMove);
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 76);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1371, 630);
			this.panel2.TabIndex = 1;
			this.panel3.AutoScroll = true;
			this.panel3.Controls.Add(this.grid2DList);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1369, 628);
			this.panel3.TabIndex = 126;
			this.grid2DList.EnableSort = true;
			this.grid2DList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.grid2DList.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.grid2DList.Location = new global::System.Drawing.Point(0, 0);
			this.grid2DList.Margin = new global::System.Windows.Forms.Padding(0);
			this.grid2DList.Name = "grid2DList";
			this.grid2DList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.grid2DList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.grid2DList.Size = new global::System.Drawing.Size(1369, 628);
			this.grid2DList.TabIndex = 125;
			this.grid2DList.TabStop = true;
			this.grid2DList.ToolTipText = "";
			this.openFileDialog.FileName = "openFileDialog";
			this.openFileDialog.Filter = "CSV File(*.csv)|*.csv";
			this.cbAll.AutoSize = true;
			this.cbAll.Location = new global::System.Drawing.Point(231, 54);
			this.cbAll.Name = "cbAll";
			this.cbAll.Size = new global::System.Drawing.Size(78, 16);
			this.cbAll.TabIndex = 16;
			this.cbAll.Text = "All Check";
			this.cbAll.UseVisualStyleBackColor = true;
			this.cbAll.Click += new global::System.EventHandler(this.cbAll_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1371, 706);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "_2DList";
			base.ShowIcon = false;
			this.Text = "FA Request List";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox16.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_In_Apply).EndInit();
			this.groupBox17.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_In_Search).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400010A RID: 266
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400010D RID: 269
		private global::SourceGrid.Grid grid2DList;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.GroupBox groupBox16;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.PictureBox cmd_In_Apply;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.GroupBox groupBox17;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.PictureBox cmd_In_Search;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.CheckBox cbAll;
	}
}
