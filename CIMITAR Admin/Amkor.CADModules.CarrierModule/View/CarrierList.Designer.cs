namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200004C RID: 76
	public partial class CarrierList : global::System.Windows.Forms.Form
	{
		// Token: 0x0600038F RID: 911 RVA: 0x00055C0C File Offset: 0x00053E0C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00055C2C File Offset: 0x00053E2C
		private void InitializeComponent()
		{
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.gridResultList = new global::SourceGrid.Grid();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.cmdApply = new global::System.Windows.Forms.PictureBox();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).BeginInit();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(449, 44);
			this.panel24.TabIndex = 18;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(130, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Select Carrier";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 377);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(449, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(100, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(239, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(410, 7);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 24;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			this.gridResultList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridResultList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridResultList.EnableSort = true;
			this.gridResultList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridResultList.Location = new global::System.Drawing.Point(0, 0);
			this.gridResultList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridResultList.Name = "gridResultList";
			this.gridResultList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridResultList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridResultList.Size = new global::System.Drawing.Size(449, 288);
			this.gridResultList.TabIndex = 28;
			this.gridResultList.TabStop = true;
			this.gridResultList.ToolTipText = "";
			this.gridResultList.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.gridResultList_MouseDoubleClick);
			this.panel1.Controls.Add(this.gridResultList);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 44);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(449, 288);
			this.panel1.TabIndex = 29;
			this.panel2.Controls.Add(this.cmdApply);
			this.panel2.Controls.Add(this.cmdClose);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 332);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(449, 45);
			this.panel2.TabIndex = 30;
			this.cmdApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdApply.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdApply.Location = new global::System.Drawing.Point(372, 7);
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
			base.ClientSize = new global::System.Drawing.Size(449, 409);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "CarrierList";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Carrier";
			base.Load += new global::System.EventHandler(this.ResultView_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040005C2 RID: 1474
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040005C3 RID: 1475
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x040005C4 RID: 1476
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x040005C5 RID: 1477
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x040005C6 RID: 1478
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x040005C7 RID: 1479
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040005C8 RID: 1480
		private global::SourceGrid.Grid gridResultList;

		// Token: 0x040005C9 RID: 1481
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040005CA RID: 1482
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040005CB RID: 1483
		private global::System.Windows.Forms.PictureBox cmdApply;
	}
}
