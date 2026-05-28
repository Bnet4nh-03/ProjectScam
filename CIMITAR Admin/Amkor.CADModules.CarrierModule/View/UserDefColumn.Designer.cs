namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000049 RID: 73
	public partial class UserDefColumn : global::System.Windows.Forms.Form
	{
		// Token: 0x0600034E RID: 846 RVA: 0x0005223C File Offset: 0x0005043C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0005225C File Offset: 0x0005045C
		private void InitializeComponent()
		{
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.gridColumnList = new global::SourceGrid.Grid();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.cmdApply = new global::System.Windows.Forms.PictureBox();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).BeginInit();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(245, 44);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(139, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Select Column";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 506);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(245, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(3, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(238, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.gridColumnList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridColumnList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridColumnList.EnableSort = true;
			this.gridColumnList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridColumnList.Location = new global::System.Drawing.Point(0, 0);
			this.gridColumnList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridColumnList.Name = "gridColumnList";
			this.gridColumnList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridColumnList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridColumnList.Size = new global::System.Drawing.Size(245, 417);
			this.gridColumnList.TabIndex = 28;
			this.gridColumnList.TabStop = true;
			this.gridColumnList.ToolTipText = "";
			this.panel1.Controls.Add(this.gridColumnList);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 44);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(245, 417);
			this.panel1.TabIndex = 29;
			this.panel2.Controls.Add(this.cmdApply);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 461);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(245, 45);
			this.panel2.TabIndex = 30;
			this.cmdApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdApply.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdApply.Location = new global::System.Drawing.Point(206, 7);
			this.cmdApply.Name = "cmdApply";
			this.cmdApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmdApply.TabIndex = 26;
			this.cmdApply.TabStop = false;
			this.cmdApply.Click += new global::System.EventHandler(this.cmdApply_Click);
			this.cmdApply.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseDown);
			this.cmdApply.MouseLeave += new global::System.EventHandler(this.cmdApply_MouseLeave);
			this.cmdApply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseMove);
			this.cmdApply.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdApply_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(245, 538);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "UserDefColumn";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Column";
			base.Load += new global::System.EventHandler(this.UserDefColumn_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400057E RID: 1406
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400057F RID: 1407
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000580 RID: 1408
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x04000581 RID: 1409
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x04000582 RID: 1410
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000583 RID: 1411
		private global::SourceGrid.Grid gridColumnList;

		// Token: 0x04000584 RID: 1412
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000585 RID: 1413
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000586 RID: 1414
		private global::System.Windows.Forms.PictureBox cmdApply;
	}
}
