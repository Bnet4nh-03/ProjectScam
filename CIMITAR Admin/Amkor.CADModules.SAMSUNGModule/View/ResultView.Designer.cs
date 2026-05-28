namespace Amkor.CADModules.SAMSUNGModule.View
{
	// Token: 0x02000027 RID: 39
	public partial class ResultView : global::System.Windows.Forms.Form
	{
		// Token: 0x060000CE RID: 206 RVA: 0x0000BA43 File Offset: 0x00009C43
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000BA64 File Offset: 0x00009C64
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.gridResultList = new global::SourceGrid.Grid();
			this.groupBox21 = new global::System.Windows.Forms.GroupBox();
			this.cmd_Apply = new global::System.Windows.Forms.PictureBox();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.panel24 = new global::System.Windows.Forms.Panel();
			this.lblTop = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox21.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Apply).BeginInit();
			this.panel24.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 106);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(355, 502);
			this.panel1.TabIndex = 8;
			this.groupBox2.Controls.Add(this.gridResultList);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Size = new global::System.Drawing.Size(355, 502);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "List";
			this.gridResultList.BackColor = global::System.Drawing.Color.White;
			this.gridResultList.ClipboardMode = global::SourceGrid.ClipboardMode.All;
			this.gridResultList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.gridResultList.EnableSort = true;
			this.gridResultList.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gridResultList.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.gridResultList.Location = new global::System.Drawing.Point(3, 20);
			this.gridResultList.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gridResultList.Name = "gridResultList";
			this.gridResultList.OptimizeMode = global::SourceGrid.CellOptimizeMode.ForRows;
			this.gridResultList.SelectionMode = global::SourceGrid.GridSelectionMode.Cell;
			this.gridResultList.Size = new global::System.Drawing.Size(349, 478);
			this.gridResultList.TabIndex = 2;
			this.gridResultList.TabStop = true;
			this.gridResultList.ToolTipText = "";
			this.groupBox21.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox21.Controls.Add(this.cmd_Apply);
			this.groupBox21.Location = new global::System.Drawing.Point(295, 3);
			this.groupBox21.Name = "groupBox21";
			this.groupBox21.Size = new global::System.Drawing.Size(53, 61);
			this.groupBox21.TabIndex = 124;
			this.groupBox21.TabStop = false;
			this.groupBox21.Text = "Apply";
			this.cmd_Apply.Image = global::Amkor.CADModules.SAMSUNGModule.Properties.Resources.TableApply;
			this.cmd_Apply.Location = new global::System.Drawing.Point(10, 20);
			this.cmd_Apply.Name = "cmd_Apply";
			this.cmd_Apply.Size = new global::System.Drawing.Size(32, 32);
			this.cmd_Apply.TabIndex = 104;
			this.cmd_Apply.TabStop = false;
			this.cmd_Apply.Click += new global::System.EventHandler(this.cmd_Apply_Click);
			this.cmd_Apply.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cmd_Apply_MouseDown);
			this.cmd_Apply.MouseLeave += new global::System.EventHandler(this.cmd_Apply_MouseLeave);
			this.cmd_Apply.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.cmd_Apply_MouseMove);
			this.cmd_Apply.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.cmd_Apply_MouseUp);
			this.openFileDialog.FileName = "openFileDialog1";
			this.panel24.Controls.Add(this.lblTop);
			this.panel24.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel24.Location = new global::System.Drawing.Point(0, 0);
			this.panel24.Name = "panel24";
			this.panel24.Size = new global::System.Drawing.Size(355, 39);
			this.panel24.TabIndex = 19;
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new global::System.Drawing.Font("Segoe UI", 14f, global::System.Drawing.FontStyle.Bold);
			this.lblTop.Location = new global::System.Drawing.Point(12, 7);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new global::System.Drawing.Size(165, 25);
			this.lblTop.TabIndex = 15;
			this.lblTop.Text = "Uploading Result";
			this.lblTop.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.Controls.Add(this.groupBox21);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 39);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(355, 67);
			this.panel2.TabIndex = 20;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(355, 608);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel24);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MinimizeBox = false;
			base.Name = "ResultView";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Result";
			base.Load += new global::System.EventHandler(this.UploadUnit_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox21.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.cmd_Apply).EndInit();
			this.panel24.ResumeLayout(false);
			this.panel24.PerformLayout();
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000117 RID: 279
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400011A RID: 282
		private global::SourceGrid.Grid gridResultList;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.GroupBox groupBox21;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.PictureBox cmd_Apply;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.Panel panel24;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Label lblTop;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Panel panel2;
	}
}
