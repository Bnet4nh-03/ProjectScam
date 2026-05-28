namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000050 RID: 80
	public partial class TestHistory : global::System.Windows.Forms.Form
	{
		// Token: 0x060003CA RID: 970 RVA: 0x000586E0 File Offset: 0x000568E0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00058700 File Offset: 0x00056900
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Amkor.CADModules.CarrierModule.View.TestHistory));
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.gridTestHistory = new global::SourceGrid.Grid();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtBarcode = new global::System.Windows.Forms.TextBox();
			this.cmbSite = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.cmdSearch = new global::System.Windows.Forms.PictureBox();
			this.cmbType = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			this.panel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSearch).BeginInit();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(939, 44);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(117, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Test History";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 517);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(939, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(345, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(238, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.gridTestHistory.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.gridTestHistory.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridTestHistory.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridTestHistory.EnableSort = true;
			this.gridTestHistory.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.gridTestHistory.Location = new global::System.Drawing.Point(3, 3);
			this.gridTestHistory.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridTestHistory.Name = "gridTestHistory";
			this.gridTestHistory.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridTestHistory.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridTestHistory.Size = new global::System.Drawing.Size(933, 379);
			this.gridTestHistory.TabIndex = 28;
			this.gridTestHistory.TabStop = true;
			this.gridTestHistory.ToolTipText = "";
			this.panel1.Controls.Add(this.gridTestHistory);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 81);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel1.Size = new global::System.Drawing.Size(939, 385);
			this.panel1.TabIndex = 29;
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.cmdClose);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 466);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(939, 51);
			this.panel2.TabIndex = 30;
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(893, 9);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 98;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			this.panel3.Controls.Add(this.cmbType);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.cmdSearch);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.cmbSite);
			this.panel3.Controls.Add(this.txtBarcode);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 44);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(939, 37);
			this.panel3.TabIndex = 31;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(13, 9);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(50, 15);
			this.label3.TabIndex = 91;
			this.label3.Text = "Barcode";
			this.txtBarcode.Location = new global::System.Drawing.Point(69, 6);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.ReadOnly = true;
			this.txtBarcode.Size = new global::System.Drawing.Size(279, 23);
			this.txtBarcode.TabIndex = 90;
			this.cmbSite.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbSite.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSite.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbSite.FormattingEnabled = true;
			this.cmbSite.Location = new global::System.Drawing.Point(553, 6);
			this.cmbSite.Name = "cmbSite";
			this.cmbSite.Size = new global::System.Drawing.Size(102, 23);
			this.cmbSite.TabIndex = 93;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(521, 9);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(26, 15);
			this.label4.TabIndex = 92;
			this.label4.Text = "Site";
			this.cmdSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("cmdSearch.Image");
			this.cmdSearch.Location = new global::System.Drawing.Point(675, 2);
			this.cmdSearch.Name = "cmdSearch";
			this.cmdSearch.Size = new global::System.Drawing.Size(32, 32);
			this.cmdSearch.TabIndex = 94;
			this.cmdSearch.TabStop = false;
			this.cmdSearch.Click += new global::System.EventHandler(this.cmdSearch_Click);
			this.cmdSearch.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdSearch_MouseDown);
			this.cmdSearch.MouseLeave += new global::System.EventHandler(this.cmdSearch_MouseLeave);
			this.cmdSearch.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdSearch_MouseMove);
			this.cmdSearch.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdSearch_MouseUp);
			this.cmbType.BackColor = global::System.Drawing.Color.LightGray;
			this.cmbType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Location = new global::System.Drawing.Point(401, 6);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new global::System.Drawing.Size(102, 23);
			this.cmbType.TabIndex = 96;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(363, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(32, 15);
			this.label1.TabIndex = 95;
			this.label1.Text = "Type";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(939, 549);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "TestHistory";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TestHistory";
			base.Load += new global::System.EventHandler(this.ResultView_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdSearch).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000605 RID: 1541
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000606 RID: 1542
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000607 RID: 1543
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x04000608 RID: 1544
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000609 RID: 1545
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400060A RID: 1546
		private global::SourceGrid.Grid gridTestHistory;

		// Token: 0x0400060B RID: 1547
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400060C RID: 1548
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400060D RID: 1549
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x0400060E RID: 1550
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400060F RID: 1551
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000610 RID: 1552
		private global::System.Windows.Forms.ComboBox cmbSite;

		// Token: 0x04000611 RID: 1553
		private global::System.Windows.Forms.TextBox txtBarcode;

		// Token: 0x04000612 RID: 1554
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000613 RID: 1555
		private global::System.Windows.Forms.PictureBox cmdSearch;

		// Token: 0x04000614 RID: 1556
		private global::System.Windows.Forms.ComboBox cmbType;

		// Token: 0x04000615 RID: 1557
		private global::System.Windows.Forms.Label label1;
	}
}
