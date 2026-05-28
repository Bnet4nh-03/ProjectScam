namespace Amkor.CADModules.SBLAnalysisModule.View
{
	// Token: 0x0200001B RID: 27
	public partial class ResultView : global::System.Windows.Forms.Form
	{
		// Token: 0x060000BA RID: 186 RVA: 0x0000B3A0 File Offset: 0x000095A0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000B3D8 File Offset: 0x000095D8
		private void InitializeComponent()
		{
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.gridResultList = new global::SourceGrid.Grid();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
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
			this.lblTop.Size = new global::System.Drawing.Size(100, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Bin Result";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 506);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(449, 32);
			this.panel25.TabIndex = 27;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(100, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(238, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2015 Amkor Technology Korea";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.gridResultList.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.gridResultList.ClipboardMode = global::SourceGrid.ClipboardMode.Copy;
			this.gridResultList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridResultList.EnableSort = true;
			this.gridResultList.Font = new global::System.Drawing.Font("Segoe UI", 8f);
			this.gridResultList.Location = new global::System.Drawing.Point(3, 3);
			this.gridResultList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridResultList.Name = "gridResultList";
			this.gridResultList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridResultList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridResultList.Size = new global::System.Drawing.Size(443, 405);
			this.gridResultList.TabIndex = 28;
			this.gridResultList.TabStop = true;
			this.gridResultList.ToolTipText = "";
			this.panel1.Controls.Add(this.gridResultList);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 44);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel1.Size = new global::System.Drawing.Size(449, 411);
			this.panel1.TabIndex = 29;
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.cmdClose);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 455);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(449, 51);
			this.panel2.TabIndex = 30;
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.SBLAnalysisModule.Properties.Resources.TableCancel;
			this.cmdClose.Location = new global::System.Drawing.Point(403, 9);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(32, 32);
			this.cmdClose.TabIndex = 98;
			this.cmdClose.TabStop = false;
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdClose.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseDown);
			this.cmdClose.MouseLeave += new global::System.EventHandler(this.cmdClose_MouseLeave);
			this.cmdClose.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
			this.cmdClose.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(449, 538);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel25);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "ResultView";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Result";
			base.Load += new global::System.EventHandler(this.ResultView_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000AA RID: 170
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040000AF RID: 175
		private global::SourceGrid.Grid gridResultList;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.PictureBox cmdClose;
	}
}
