namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000047 RID: 71
	public partial class ResultSocketView : global::System.Windows.Forms.Form
	{
		// Token: 0x06000335 RID: 821 RVA: 0x000509A2 File Offset: 0x0004EBA2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000509C4 File Offset: 0x0004EBC4
		private void InitializeComponent()
		{
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel25 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.grpApply = new global::System.Windows.Forms.GroupBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cmdClose = new global::System.Windows.Forms.PictureBox();
			this.cmdApply = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.gridResultList = new global::SourceGrid.Grid();
			this.panel24.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel2.SuspendLayout();
			this.grpApply.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(449, 44);
			this.panel24.TabIndex = 19;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(165, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Uploading Result";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel25.Controls.Add(this.label13);
			this.panel25.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel25.Location = new global::System.Drawing.Point(0, 506);
			this.panel25.Name = "panel25";
			this.panel25.Size = new global::System.Drawing.Size(449, 32);
			this.panel25.TabIndex = 28;
			this.label13.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label13.Location = new global::System.Drawing.Point(26, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(398, 15);
			this.label13.TabIndex = 15;
			this.label13.Text = "Copyright © 2017-2018 Amkor Technology Korea, Inc. All Rights Reserved.";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.cmdClose);
			this.panel2.Controls.Add(this.grpApply);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 455);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(449, 51);
			this.panel2.TabIndex = 31;
			this.grpApply.Controls.Add(this.label1);
			this.grpApply.Controls.Add(this.cmdApply);
			this.grpApply.Font = new global::System.Drawing.Font("Segoe UI", 1f);
			this.grpApply.Location = new global::System.Drawing.Point(3, 3);
			this.grpApply.Name = "grpApply";
			this.grpApply.Size = new global::System.Drawing.Size(151, 45);
			this.grpApply.TabIndex = 101;
			this.grpApply.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label1.Location = new global::System.Drawing.Point(1, 15);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(108, 15);
			this.label1.TabIndex = 102;
			this.label1.Text = "Block Carrier Apply";
			this.cmdClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableCancel;
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
			this.cmdApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cmdApply.Image = global::Amkor.CADModules.CarrierModule.Properties.Resources.TableApply;
			this.cmdApply.Location = new global::System.Drawing.Point(109, 8);
			this.cmdApply.Name = "cmdApply";
			this.cmdApply.Size = new global::System.Drawing.Size(32, 32);
			this.cmdApply.TabIndex = 24;
			this.cmdApply.TabStop = false;
			this.panel1.Controls.Add(this.gridResultList);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 44);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new global::System.Windows.Forms.Padding(3);
			this.panel1.Size = new global::System.Drawing.Size(449, 411);
			this.panel1.TabIndex = 32;
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
			base.Name = "ResultSocketView";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ResultSocketView";
			base.Load += new global::System.EventHandler(this.ResultSocketView_Load);
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.grpApply.ResumeLayout(false);
			this.grpApply.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmdClose).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.cmdApply).EndInit();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000558 RID: 1368
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000559 RID: 1369
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x0400055A RID: 1370
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x0400055B RID: 1371
		private global::System.Windows.Forms.Panel panel25;

		// Token: 0x0400055C RID: 1372
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400055D RID: 1373
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400055E RID: 1374
		private global::System.Windows.Forms.PictureBox cmdClose;

		// Token: 0x0400055F RID: 1375
		private global::System.Windows.Forms.GroupBox grpApply;

		// Token: 0x04000560 RID: 1376
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000561 RID: 1377
		private global::System.Windows.Forms.PictureBox cmdApply;

		// Token: 0x04000562 RID: 1378
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000563 RID: 1379
		private global::SourceGrid.Grid gridResultList;
	}
}
